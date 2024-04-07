using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WebApiEsperanca.Application.Service;
using WebApiEsperanca.Repository;

namespace WebApiEsperanca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ChatController : ControllerBase
    {
        private readonly Context _ctx;
        public ChatController(Context ctx)
        {
            _ctx = ctx;
        }
        [HttpGet]
        [Authorize]
        public IActionResult ObterUsuariosPorDoacao()
        {
            var identidade = (ClaimsIdentity)HttpContext.User.Identity;
            var codigo = identidade.FindFirst("usuarioCodigo").Value;

            var chatService = new ChatService(_ctx);
            return Ok(chatService.ObterUsuariosPorDoacao());

        }
        [HttpPost]
        [Authorize]
        [Route("criaConversa/{remeCod}/{destCod}")]
        public IActionResult CriarNovaConversa(int remeCod, int destCod)
        {
            var identidade = (ClaimsIdentity)HttpContext.User.Identity;
            var codigo = identidade.FindFirst("usuarioCodigo").Value;

            var chatService = new ChatService(_ctx);
            return Ok(chatService.CriarNovaConversa(remeCod, destCod));
        }

        [HttpPost]
        [Authorize]
        [Route("inseriMensagem/{conCod}/{remCod}/{destCod}/{conteudo}")]
        public IActionResult Inserirmensagem(int conCod,int remCod, int destCod, string conteudo)
        {
            var identidade = (ClaimsIdentity)HttpContext.User.Identity;
            var codigo = identidade.FindFirst("usuarioCodigo").Value;

            var chatService = new ChatService(_ctx);
            return Ok(chatService.Inserirmensagem(conCod, remCod, destCod, conteudo));
        }
    }
}
