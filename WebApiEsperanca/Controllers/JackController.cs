using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using WebApiEsperanca.Application.Model;
using WebApiEsperanca.Application.Service;
using WebApiEsperanca.Repository;

namespace WebApiEsperanca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class JackController : Controller
    {
        private readonly Context _ctx;
        public JackController(Context ctx)
        {
            _ctx = ctx;
        }
        [HttpGet]
        [Route("ObterUsuariosFieb")]
        public IActionResult ObterUsuariosJack()
        {
            var crudJackService = new CrudJack(_ctx);
            var sucesso = crudJackService.ObterUsuariosJack();
            if(sucesso != null)
            {
                return Ok(sucesso);
            }
            else
            {
                return BadRequest();
            }
            
        }
        [HttpGet]
        [Route("ObterUsuarioFieb/{id}")]
        public IActionResult ObterUsuarioJack(int id)
        {
            var crudJackService = new CrudJack(_ctx);
            var sucesso = crudJackService.ObterUsuarioJack(id);
            if (sucesso != null)
            {
                return Ok(sucesso);
            }
            else
            {
                return BadRequest();
            }

        }
        [HttpPost]
        [Route("InserirUsuarioFieb")]
        public IActionResult ObterUsuarioJack([FromBody] RequestJack request)
        {
            var crudJackService = new CrudJack(_ctx);
            var sucesso = crudJackService.InserirUsuarioJack(request);
            if (sucesso.response == true)
            {
                return Ok(sucesso.mensagem);
            }
            else
            {
                return BadRequest(sucesso.mensagem);
            }

        }
        [HttpPut]
        [Route("AtualizarUsuarioFieb/{id}")]
        public IActionResult AtualizarUsuarioJack([FromBody] RequestJack request, int id)
        {
            var crudJackService = new CrudJack(_ctx);
            var sucesso = crudJackService.AtualizarUsuarioJack(request, id);
            if (sucesso.response == true)
            {
                return Ok(sucesso.mensagem);
            }
            else
            {
                return BadRequest(sucesso.mensagem);
            }
        }
    }
}
