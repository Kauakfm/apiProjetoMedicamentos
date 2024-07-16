using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiEsperanca.Repository.Models
{
    public class tabMensagens
    {
        [Key]
        public int codigo { get; set; }

        public int conversaCodigo { get; set; }

        public int RementeUsuarioCodigo { get; set; }

        public int DestinatarioUsuarioCodigo { get; set; }

        public string Conteudo { get; set; }

        public DateTime dataEnvio { get; set; }


    }
}
