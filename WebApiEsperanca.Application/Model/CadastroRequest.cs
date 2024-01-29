using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiEsperanca.Application.Model
{
    public class CadastroRequest
    {
        public string nome { get; set; }

        public string email { get; set; }

        public string senha { get; set; }
        public string telefone { get; set; }

        public DateTime? dataNascimento { get; set; }
        public string rg { get; set; }

        public string cpf { get; set; }

        public int generoCodigo { get; set; }

        public int tipoUsuarioCodigo { get; set; }

        public string? cep { get; set; }

        public string? rua { get; set; }

        public string? bairro { get; set; }

        public string? cidade { get; set; }

        public int? uf { get; set; }

        public string? numeroResidencia { get; set; }

        public string? complemento { get; set; }

        public DateTime dataEmailEnviado { get; set; }

        public int unidadeCodigo { get; set; }

    }
}
