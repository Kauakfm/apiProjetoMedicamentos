using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiEsperanca.Application.Model
{
    public class ListarUsuarios
    {
        public int codigo { get; set; }
        public string nome { get; set; }

        public string email { get; set; }

        public string senha { get; set; }

        public string telefone { get; set; }
        public string cpf { get; set; }

        public string generoCodigo { get; set; }

        public string tipoUsuarioCodigo { get; set; }
    }
}
