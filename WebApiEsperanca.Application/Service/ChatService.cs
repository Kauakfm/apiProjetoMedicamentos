using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiEsperanca.Application.Model;
using WebApiEsperanca.Repository;
using WebApiEsperanca.Repository.Models;

namespace WebApiEsperanca.Application.Service
{
    public class ChatService
    {
        private readonly Context _ctx;

        public ChatService(Context context)
        {
            _ctx = context;
        }
        public List<ChatDoadores> ObterUsuariosPorDoacao()
        {
            try
            {
                List<ChatDoadores> objChat = new List<ChatDoadores>();
                objChat = _ctx.tabUsuario.Where(x => x.tipoUsuarioCodigo == 2
                && _ctx.tabProdutoDoado.Any(p => p.usuarioCodigo == x.codigo)).OrderBy(y => y.codigo)
                .Select(x => new ChatDoadores
                {
                    codigo = x.codigo,
                    nome = x.nome,
                    doacao = _ctx.tabProdutoDoado.Where(c => c.usuarioCodigo == x.codigo).ToList(),
                    qtdItensDoados = _ctx.tabProdutoDoado.Where(c => c.usuarioCodigo == x.codigo).Count(),
                    avatar = string.IsNullOrEmpty(x.foto) ? "https://api.dicebear.com/8.x/bottts-neutral/svg?seed=Max" : x.foto
                }).ToList();


                return objChat;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public int CriarNovaConversa(int remetenteUsuarioCodigo, int destinatarioUsuarioCodigo)
        {
            try
            {
                tabMensagens objMensagens = new tabMensagens();
                objMensagens = BuscarConversa(remetenteUsuarioCodigo, destinatarioUsuarioCodigo);
                if (objMensagens != null)
                {
                    return objMensagens.conversaCodigo;
                }
                else
                {
                    tabConversas obj = new tabConversas();
                    _ctx.tabConversas.Add(obj);
                    _ctx.SaveChanges();
                    Inserirmensagem(obj.codigo, remetenteUsuarioCodigo, destinatarioUsuarioCodigo, "Olá! Tudo bem?");
                    return obj.codigo;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public bool Inserirmensagem(int conversaCodigo,int remetenteCodigo, int destinatarioCodigo,  string conteudo)
        {
            try
            {
                tabMensagens objMensagem = new tabMensagens();
                objMensagem.conversaCodigo = conversaCodigo;
                objMensagem.RementeUsuarioCodigo = remetenteCodigo;
                objMensagem.DestinatarioUsuarioCodigo = destinatarioCodigo;
                objMensagem.Conteudo = conteudo;
                objMensagem.dataEnvio = DateTime.Now;
                _ctx.tabMensagens.Add(objMensagem);
                _ctx.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public tabMensagens BuscarConversa(int remetenteUsuarioCodigo, int destinatarioUsuarioCodigo)
        {
            var conversa = _ctx.tabMensagens.FirstOrDefault(x =>
       (x.RementeUsuarioCodigo == remetenteUsuarioCodigo && x.DestinatarioUsuarioCodigo == destinatarioUsuarioCodigo) ||
       (x.RementeUsuarioCodigo == destinatarioUsuarioCodigo && x.DestinatarioUsuarioCodigo == remetenteUsuarioCodigo));

            return conversa;
        }
    }
}
