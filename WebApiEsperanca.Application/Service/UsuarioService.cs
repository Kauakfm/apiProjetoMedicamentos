using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                var user = _ctx.tabUsuario.FirstOrDefault(x => x.codigo == codigo);
                return user;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
