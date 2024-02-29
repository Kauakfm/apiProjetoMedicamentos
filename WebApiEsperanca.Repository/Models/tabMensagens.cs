using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiEsperanca.Repository.Models
{
    public class tabMensagens
    {
        public int id { get; set; }

        public int ConversaId { get; set; }

        public int RemetenteId { get; set; }

        public int DestinatarioId { get; set; }

        public string Conteudo { get; set; }

        public DateTime DataEnvio { get; set; }


    }
}
