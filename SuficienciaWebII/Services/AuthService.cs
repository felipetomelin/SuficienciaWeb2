using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SuficienciaWebII.Services
{
    public class AuthService : IAuthService
    {
        public (string, DateTime) GerarJwtAuth()
        {
            var tempoExpiracao = DateTime.UtcNow.AddHours(1);
            var secret = "this is my custom Secret key for authentication";
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "SeuIssuerAqui",
                audience: "PodeSerUmNomeDeUsuario",
                claims: null,
                expires: tempoExpiracao,
                signingCredentials: credentials);

            return (new JwtSecurityTokenHandler().WriteToken(token), tempoExpiracao);
        }
    }
}