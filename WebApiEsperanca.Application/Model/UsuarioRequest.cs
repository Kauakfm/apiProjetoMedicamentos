using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiEsperanca.Application.Model
{
    public class UsuarioRequest
    {
        public string nome { get; set; }

        public string email { get; set; }

        public string senha { get; set; }

        public string telefone { get; set; }
        public string cpf { get; set; }

        public int generoCodigo { get; set; }

        public int tipoUsuarioCodigo { get; set; }

    }
}
