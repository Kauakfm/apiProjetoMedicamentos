using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Security.Claims;
using WebApiEsperanca.Application.Model;
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
        [Route("obterUser/{id}")]
        public IActionResult ObterUsuario(int id)
        {   
            var identidade = (ClaimsIdentity)HttpContext.User.Identity;
            var codigo = identidade.FindFirst("tipo").Value;
            if (codigo != "1")
                return Unauthorized();
            var usuarioService = new UsuarioService(_ctx);
            return Ok(usuarioService.ObterUsuario(Convert.ToInt32(id)));
        }

        [HttpGet]
        [Authorize]
        [Route("obterUsuarios")]
        public IActionResult ObterUsuarios()
        {
            var identidade = (ClaimsIdentity)HttpContext.User.Identity;
            var status = identidade.FindFirst("tipo").Value;
            if(status != "1")
                return Unauthorized();
            var usuarioService = new UsuarioService(_ctx);
            return Ok(usuarioService.ObterUsuarios());

        }
        [HttpPut]
        [Authorize]
        [Route("atualizar/{id}")]
        public IActionResult AtualizarUsuario([FromBody] UsuarioRequest request ,int id)
        {
            var identidade = (ClaimsIdentity)HttpContext.User.Identity;
            var tipo = identidade.FindFirst("tipo").Value;
            if(tipo != "1")
                return Unauthorized();  
            var usuarioService = new UsuarioService(_ctx);
            return Ok(usuarioService.atualizarUsuario(request, Convert.ToInt32(id)));
        }
    }
}