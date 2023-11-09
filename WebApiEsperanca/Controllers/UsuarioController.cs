using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApiEsperanca.Application.Service;
using WebApiEsperanca.Repository;

namespace WebApiEsperanca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly Context _ctx;
        public UsuarioController(Context context)
        {
            _ctx = context;
        }


        [HttpGet]
        [Authorize]
        [Route("obterUser")]
        public IActionResult ObterUsuario()
        {
            if (User.Identity is ClaimsIdentity identity)
            {
                var expirationClaim = identity.FindFirst("exp");
                if (expirationClaim != null)
                {
                    var expiration = long.Parse(expirationClaim.Value);
                    var now = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

                    if (now > expiration)
                    {
                        // O token está expirado
                        return Unauthorized("Token expirado");
                    }
                }
            }
            var identidade = (ClaimsIdentity)HttpContext.User.Identity;
            var codigo = identidade.FindFirst("usuarioCodigo").Value;
            if (codigo == null)
                return Unauthorized();

            var usuarioService = new UsuarioService(_ctx);
            return Ok(usuarioService.ObterUsuario(Convert.ToInt32(codigo)));
        }
    }
}