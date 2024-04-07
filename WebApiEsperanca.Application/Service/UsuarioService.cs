using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiEsperanca.Application.Model;
using WebApiEsperanca.Repository;
using WebApiEsperanca.Repository.Models;

namespace WebApiEsperanca.Application.Service
{
    public class UsuarioService
    {
        private readonly Context _ctx;
        public UsuarioService(Context context)
        {
            _ctx = context;
        }

        public TabUsuario ObterUsuario(int codigo)
        {
            try
            {
                return  _ctx.tabUsuario.FirstOrDefault(x => x.codigo == codigo);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<ListarUsuarios> ObterUsuarios()
        {
            try
            {
                List<ListarUsuarios> usuarios = new List<ListarUsuarios>();
                var user = _ctx.tabUsuario.ToList();
                var generos = _ctx.tabGenero.ToList();
                var tipos = _ctx.tabTipoUsuario.ToList();
                foreach (var item in user)
                {
                    string genero = generos.FirstOrDefault(x => x.codigo == item.generoCodigo)?.descricao;
                    string tipo = tipos.FirstOrDefault(y => y.codigo == item.tipoUsuarioCodigo)?.descricao;
                    usuarios.Add(new ListarUsuarios
                    {
                        codigo = item.codigo,
                        nome = item.nome,
                        email = item.email,
                        senha = item.senha,
                        cpf = item.cpf,
                        generoCodigo = genero,
                        tipoUsuarioCodigo = tipo,
                        telefone = item.telefone
                    });
                }
                return usuarios;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public GenericResponse<bool> atualizarUsuario(UsuarioRequest request, int id)
        {
            try
            {
                var usuario = _ctx.tabUsuario.FirstOrDefault(x => x.codigo == id);
                usuario.nome = request.nome;
                usuario.email = request.email;
                usuario.senha = request.senha;
                usuario.telefone = request.telefone;
                usuario.cpf = request.cpf;
                usuario.generoCodigo = request.generoCodigo;
                usuario.tipoUsuarioCodigo = request.tipoUsuarioCodigo;
                _ctx.tabUsuario.Update(usuario);
                _ctx.SaveChanges();
                 return new GenericResponse<bool>("Usuario atualizado com sucesso", true);
            }
            catch (Exception)
            {
                return new GenericResponse<bool>("Deu algum problema", false);
            }
        }
    }
}
