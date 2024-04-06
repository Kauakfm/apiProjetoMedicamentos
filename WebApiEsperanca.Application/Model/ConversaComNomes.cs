using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiEsperanca.Repository.Models;

namespace WebApiEsperanca.Application.Model
{
    public class ConversaComNomes
    {
        public int codigo { get; set; }
        public int codigoConversa { get; set; }
        public string? RemetenteNome { get; set; }
        public string? DestinatarioNome { get; set; }
        public string? Mensagem { get; set; }

        public string? horaMinuto { get; set; }
    }

}
