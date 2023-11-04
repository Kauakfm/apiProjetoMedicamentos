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
    }
}
