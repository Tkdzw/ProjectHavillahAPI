using Havillah.Api.Controllers.Shared;
using Havillah.Service.Helpers.Authentication;
using Havillah.Service.DTOs;
using Havillah.Service.DTOs.AuthDtos;
using Havillah.Service.Services.AuthService;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace Havillah.Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("auth")]
        public async Task<ActionResult<ServiceResponse<AuthResponseDto>>> Authenticate(AuthRequestDto request)
        {
            var response = await _authService.Authenticate(request, IpAddress());
            return Ok(response);
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<ServiceResponse<bool>>> Register(RegisterRequestDto request)
        {
            var response = await _authService.Register(request, Request.Headers.Origin);
            return Ok(response);
        }

        private string IpAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
