using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiEsperanca.Application.DaL;
using WebApiEsperanca.Application.Model;
using WebApiEsperanca.Repository;
using WebApiEsperanca.Repository.Models;

namespace WebApiEsperanca.Application.Service
{
    public class CrudJack
    {
        private readonly Context _ctx;

        public CrudJack(Context ctx)
        {
            _ctx = ctx;
        }

        public List<tabUsuarioJack> ObterUsuariosJack()
        {
            //return _ctx.tabUsuarioJack.ToList();
            return SuporteDal.Listar<tabUsuarioJack>().ToList();
        }
        public tabUsuarioJack ObterUsuarioJack(int id)
        {
            return _ctx.tabUsuarioJack.Where(x => x.codigo == id).FirstOrDefault();
        }
        public GenericResponse<bool> InserirUsuarioJack(RequestJack request)
        {
            try
            {
                tabUsuarioJack objUsuarioJack = new tabUsuarioJack();
                if (!string.IsNullOrEmpty(request.nome) && !string.IsNullOrEmpty(request.email) && !string.IsNullOrEmpty(request.senha))
                {
                    objUsuarioJack.nome = request.nome;
                    objUsuarioJack.email = request.email;
                    objUsuarioJack.senha = request.senha;
                    objUsuarioJack.serie = request.serie;
                    _ctx.tabUsuarioJack.Add(objUsuarioJack);
                    _ctx.SaveChanges();
                    return new GenericResponse<bool>("Usuário inserido!", true);
                }
                return new GenericResponse<bool>("Preencha os campos!", false);
            }
            catch (Exception)
            {

                throw;
            }
        }
        public GenericResponse<bool> AtualizarUsuarioJack(RequestJack request, int id)
        {
            try
            {
                tabUsuarioJack objUsuarioJack = new tabUsuarioJack();
                objUsuarioJack = _ctx.tabUsuarioJack.FirstOrDefault(x => x.codigo == id);
                if (objUsuarioJack != null)
                {
                    if (!string.IsNullOrEmpty(request.nome) && !string.IsNullOrEmpty(request.email) && !string.IsNullOrEmpty(request.senha))
                    {
                        objUsuarioJack.nome = request.nome;
                        objUsuarioJack.email = request.email;
                        objUsuarioJack.senha = request.senha;
                        objUsuarioJack.serie = request.serie;
                        _ctx.tabUsuarioJack.Update(objUsuarioJack);
                        _ctx.SaveChanges();
                        return new GenericResponse<bool>("Usuário Atualizado", true);
                    }
                    else { return new GenericResponse<bool>("Preencha os campos", false); }
                }
                else { return new GenericResponse<bool>("Usuario não encontrado", false); }
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
