using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiEsperanca.Repository.Models
{
    public class tabProdutoDoado
    {
        [Key]
        public int codigo { get; set; }

        public int usuarioCodigo { get; set; }

        public int tipoProdutoCodigo { get; set;}

        public int codigoStatus { get; set; }
        public int? forma { get; set; }
        public string? nome { get; set; }
        public int? dosagem { get; set; }
        public int? qntd { get; set; }

        public DateTime? validade { get; set; }
        
    }
}
