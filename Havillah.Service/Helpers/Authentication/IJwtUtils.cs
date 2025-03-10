using Havillah.Data.Entities;


namespace Havillah.Service.Helpers.Authentication
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(Account account);
        public int? ValidateJwtToken(string token);
        public RefreshToken GenerateRefreshToken(string ipAddress);
    }

}
