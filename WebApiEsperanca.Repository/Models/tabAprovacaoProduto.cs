using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiEsperanca.Repository.Models
{
    public class tabAprovacaoProduto
    {
        [Key]
        public int codigo { get; set; }

        public int produtoDoadoCodigo { get; set; }

        public int codigoStatus { get; set; }

        public string obs { get; set; }

        public int usuarioBaixa { get; set; }

        public DateTime dataAprovacao { get; set; }
    }
}
