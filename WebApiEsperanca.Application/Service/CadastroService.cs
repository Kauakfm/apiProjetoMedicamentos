using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiEsperanca.Application.Model;
using WebApiEsperanca.Repository;
using WebApiEsperanca.Repository.Models;

namespace WebApiEsperanca.Application.Service
{
    public class CadastroService
    {
        private readonly Context _ctx;
        public CadastroService(Context context)
        {
            _ctx = context; 
        }


        public CadastroResponse<bool> cadastrar(CadastroRequest request)
        {
            try
            {
                EmailService emailService = new EmailService();
                TabUsuario user = new TabUsuario()
                {
                    nome = request.nome,
                    email = request.email,
                    senha = request.senha,
                    rg = request.rg,
                    cpf = request.cpf,
                    tipoUsuarioCodigo = 2,
                    generoCodigo = request.generoCodigo,
                    dataNascimento = request.dataNascimento,
                    dataEmailEnviado = DateTime.Now,
                    dataCriacao = DateTime.Now,
                    telefone = request.telefone,
                    cep = request.cep,
                    rua = request.rua,
                    bairro = request.bairro,
                    cidade = request.cidade,
                    uf = request.uf,
                    numeroResidencia = request.numeroResidencia,
                    complemento = request.complemento,
                    unidadeCodigo = request.unidadeCodigo,
                };
                if(_ctx.tabUsuario.Any(x =>x.email == request.email))
                {
                    return new CadastroResponse<bool>("Erro este email ja existe.", false);
                }
                if(_ctx.tabUsuario.Any(x => x.cpf == request.cpf))
                {
                    return new CadastroResponse<bool>("Erro este cpf ja existe.", false);
                }
                _ctx.tabUsuario.Add(user);
                _ctx.SaveChanges();
                var email = user.email;

                var Template = $"{System.AppDomain.CurrentDomain.BaseDirectory}/Content/EmailHtml/Cadastro.html";
                var htmlTemplate = System.IO.File.ReadAllText(Template);
                var htmlArrumado = htmlTemplate;
                emailService.EnviaEmail("Dose de esperança", email , "Realização do cadastro concluído", htmlArrumado);
                return new CadastroResponse<bool>("Sucesso cadastro realizado com sucesso", true);
            }
            catch (Exception)
            {
                return new CadastroResponse<bool>("Erro não foi possivel cadastra-lo", false);
            }
        }

    }
}
