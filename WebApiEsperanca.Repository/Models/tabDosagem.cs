using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiEsperanca.Repository.Models
{
    public class tabDosagem
    {
        [Key]
        public int codigo { get; set; }

        public string descricao { get; set; }

    }
}
