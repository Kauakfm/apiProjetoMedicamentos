using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiEsperanca.Application.Model
{
    public class TabelasDTO
    {
        public List<TabelaInfo> Dosagens { get; set; }
        public List<TabelaInfo> FormasMedicamento { get; set; }
    }
}
