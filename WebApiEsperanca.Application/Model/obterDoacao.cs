using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiEsperanca.Application.Model
{
    public class obterDoacao
    {
        public int codigo { get; set; }
        public string nomeUser {  get; set; }

        public string tipoProdutoCodigo { get; set; }

        public int statusCodigo { get; set; }
        public DateTime? validade { get; set; }
        public string nome { get; set; }
    }
}
