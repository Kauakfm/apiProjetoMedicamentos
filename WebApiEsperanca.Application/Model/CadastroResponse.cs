using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApiEsperanca.Application.Model
{
    public class CadastroResponse<T>
    {
        public string mensagem { get; set; }
        public T response { get; set; }
        public CadastroResponse(string mensagem, T response)
        {
            this.mensagem = mensagem;
            this.response = response;
        }
    }
}

