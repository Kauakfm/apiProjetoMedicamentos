using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApiEsperanca.Application.Model;
using WebApiEsperanca.Application.Service;
using WebApiEsperanca.Repository;

namespace WebApiEsperanca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DoacaoController : ControllerBase
    {
        private readonly Context _ctx;
        public DoacaoController(Context ctx)
        {
            _ctx = ctx;
        }

        [HttpPost]
        [Authorize]
        public IActionResult receberDoacao([FromBody] DoacaoRequest request)
        {
            var identidade = (ClaimsIdentity)HttpContext.User.Identity;
            var codigo = identidade.FindFirst("usuarioCodigo").Value;
            if(codigo == null)
            return Unauthorized();

            var doacaoService = new DoacaoService(_ctx);
            return Ok(doacaoService.receberDoacao(request, Convert.ToInt32(codigo)));
        }
        [HttpGet]
        [Authorize]
        public IActionResult obterDoacao()
        {
            var identidade = (ClaimsIdentity)HttpContext.User.Identity;
            var codigo = identidade.FindFirst("usuarioCodigo").Value;
            var status = identidade.FindFirst("tipo").Value;
            if (status != "1")
                return Unauthorized();

            var doacaoService = new DoacaoService(_ctx);
            return Ok(doacaoService.obterDoacoes());
        }
        [HttpGet]
        [Route("obter")]

        public IActionResult obtertabelas()
        {
            var doacaoService = new DoacaoService(_ctx);
            var sucesso = doacaoService.ObterTabelas();
            if(sucesso != null)
            {
                return Ok(sucesso);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Authorize]
        [Route("aprovar/{id}")]

        public IActionResult aprovarDoacao([FromBody] AprovarRequest request, int id)
        {
            var identidade = (ClaimsIdentity)HttpContext.User.Identity;
            var status = identidade.FindFirst("tipo").Value;
            if (status != "1")
                return Unauthorized();
            var doacaoService = new DoacaoService(_ctx);
            return Ok(doacaoService.aprovarDoacao(request,Convert.ToInt32(id)));
        }
    }
}
