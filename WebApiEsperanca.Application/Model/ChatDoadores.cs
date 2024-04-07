using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiEsperanca.Repository.Models;

namespace WebApiEsperanca.Application.Model
{
    public class ChatDoadores
    {
        public int codigo { get; set; }
        public string nome { get; set; }

        public List<tabProdutoDoado> doacao { get; set; }

        public  int qtdItensDoados { get; set; }
    }
}
