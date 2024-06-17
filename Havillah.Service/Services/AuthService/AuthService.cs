using AutoMapper;
using Havillah.Data.DbContexts;
using Havillah.Data.Entities;
using Havillah.Service.DTOs;
using Havillah.Service.DTOs.AuthDtos;
using Havillah.Service.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havillah.Service.Services.AuthService
{
    public class AuthService: IAuthService
    {
        public readonly HavillahDbContext _context;
        public readonly IMapper _mapper;
        public AuthService(HavillahDbContext context,IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public Task<ServiceResponse<AuthResponseDto>> Authenticate(AuthRequestDto requestDto, string ipAddress)
        {
            throw new NotImplementedException();
        }

        public async Task<ServiceResponse<bool>> Register(RegisterRequestDto request, string? origin)
        {
            try
            {
                if(await _context.Accounts.AnyAsync(x => x.Email == request.Email && !x.IsDeleted))
                {
                    //await SendAlreadyRegisteredEmail();
                    throw new ApplicationException("Email Already Exists");
                }

                var account = _mapper.Map<Account>(request);

                var isFirstAccount = await _context.Accounts.AnyAsync();
                account.Role = isFirstAccount ? Role.SuperAdmin : Role.User;

                account.Activated = isFirstAccount ? DateTime.UtcNow : null;

                return new ServiceResponse<bool>(true, "Registration successful, please check your email for verification instructions");
            }
            catch(Exception ex)
            {
                throw new AppException(ex.Message);
            }
            
        }
    }
}
