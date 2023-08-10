using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SuficienciaWebII.Services;
using SuficienciaWebII.Views;

namespace SuficienciaWebII.Controllers
{
    [AllowAnonymous]
    public class AuthController : ApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        [Route("token")]
        public AutenticacaoViewModel AutenticarUsuario()
        {
            var (token, expiration) = _authService.GerarJwtAuth();

            return new AutenticacaoViewModel
            {
                Token = token,
                DataExpiracao = expiration,
            };
        }
    }
}