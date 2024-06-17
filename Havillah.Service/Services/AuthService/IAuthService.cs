using Havillah.Service.DTOs;
using Havillah.Service.DTOs.AuthDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Havillah.Service.Services.AuthService
{
    public interface IAuthService
    {
        Task<ServiceResponse<AuthResponseDto>> Authenticate(AuthRequestDto requestDto, string ipAddress);

        Task<ServiceResponse<bool>> Register(RegisterRequestDto model, string? origin);

    }
}
