using Microsoft.AspNetCore.Mvc;
using WebApiEsperanca.Application.Model;
using WebApiEsperanca.Application.Service;
using WebApiEsperanca.Repository;

namespace WebApiEsperanca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CadastroController : ControllerBase
    {
        private readonly Context _ctx;
        public CadastroController (Context context)
        {
            _ctx = context; 
        }

        [HttpPost]
        public IActionResult Index([FromBody] CadastroRequest request)
        {
            var cadastroService = new CadastroService(_ctx);
            var sucesso = cadastroService.cadastrar(request);

            if (sucesso.response == true)
            {
                return Ok(sucesso);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpPost]
        [Route("EnviarEmailDeRedefinirSenha")]
        public IActionResult EnviarEmailDeRedefinirSenha([FromBody] EmailRequest request)
        {
            var cadastroService = new CadastroService(_ctx);
            var sucesso = cadastroService.EnviarEmailDeRedefinirSenha(request.Email);
            if (sucesso)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(sucesso);
            }

        }
        [HttpPost]
        [Route("EsqueciSenha/{id}")]
        public IActionResult RedefinirSenha([FromRoute] string id, [FromBody] RedefinirSenhaRequest request)
        {
            var cadastroService = new CadastroService(_ctx);
            var sucesso = cadastroService.RedefinirSenha(id, request);
            if (sucesso)
            {
                return NoContent();
            }
            else
            {
                return BadRequest(sucesso);
            }

        }
    }
}
