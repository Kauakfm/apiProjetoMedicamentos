using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiEsperanca.Application.Model
{
    public class DoacaoRequest
    {
        public int usuarioCodigo { get; set; } 
        public int tipoProdutoCodigo { get; set; }
        public int statusCodigo { get; set; }
        public string nome { get; set; }
        public int? forma { get; set; }
        public int? dosagem { get; set; }
        public int qntd { get; set; }
        public DateTime validade { get; set; }
    }
}
