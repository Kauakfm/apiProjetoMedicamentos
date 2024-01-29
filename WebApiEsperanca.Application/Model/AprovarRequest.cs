using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiEsperanca.Application.Model
{
    public class AprovarRequest
    {
        public DateTime? dataAprovacao { get; set; }
        public int statusCodigo { get; set; }
        public string obs { get; set; }

        public int produtoDoadoCodigo { get; set; }
        public int usuarioBaixa { get; set; }
    }
}
