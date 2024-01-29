using Microsoft.AspNetCore.Mvc;
using WebApiEsperanca.Application.Model;
using WebApiEsperanca.Application.Service;
using WebApiEsperanca.Repository;

namespace WebApiEsperanca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AutenticacaoController : ControllerBase
    {
        private readonly Context _ctx;
        public AutenticacaoController(Context ctx)
        {
            _ctx = ctx;
        }
        [HttpPost]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var autenticacao = new AutenticacaoService(_ctx);
            var token = autenticacao.GerarTokenporId(request);

            if (token == null)
            {
                return BadRequest();
            }
            else
            {
                return Ok(token);
            }
        }

    }
}
