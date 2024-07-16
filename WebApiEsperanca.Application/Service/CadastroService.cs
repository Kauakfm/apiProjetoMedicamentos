using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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


        public GenericResponse<bool> cadastrar(CadastroRequest request)
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
                if (_ctx.tabUsuario.Any(x => x.email == request.email))
                {
                    return new GenericResponse<bool>("Erro este email ja existe.", false);
                }
                if (_ctx.tabUsuario.Any(x => x.cpf == request.cpf))
                {
                    return new GenericResponse<bool>("Erro este cpf ja existe.", false);
                }
                _ctx.tabUsuario.Add(user);
                _ctx.SaveChanges();
                var email = user.email;

                var Template = $"{System.AppDomain.CurrentDomain.BaseDirectory}/Content/EmailHtml/Cadastro.html";
                var htmlTemplate = System.IO.File.ReadAllText(Template);
                var htmlArrumado = htmlTemplate;
                emailService.EnviaEmail("Dose de esperança", email, "Realização do cadastro concluído", htmlArrumado);
                return new GenericResponse<bool>("Sucesso cadastro realizado com sucesso", true);
            }
            catch (Exception)
            {
                return new GenericResponse<bool>("Erro não foi possivel cadastra-lo", false);
            }
        }
        private string criptografarID(int id)
        {
            var id1 = ((id * 362) - 34).ToString();
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            char[] characters = id1.ToCharArray();


            var retorno = "";

            foreach (var letra in characters)
            {
                Random random = new Random();

                int index = random.Next(0, alphabet.Length);

                retorno += alphabet[index] + letra.ToString();
            }
            return retorno;
        }
        private int descriptografarID(string token)
        {
            StringBuilder result = new StringBuilder();

            foreach (char c in token)
            {
                if (!char.IsLetter(c))
                {
                    result.Append(c);
                }
            }
            token = result.ToString();
            var id = (Convert.ToInt32(token) + 34) / 362;
            return id;
        }
        public bool EnviarEmailDeRedefinirSenha(string email)
        {
            try
            {
                EmailService emailService = new EmailService();
                var user = _ctx.tabUsuario.FirstOrDefault(x => x.email == email);
                if (user == null)
                    return false;


                var pathTemplate = $"{System.AppDomain.CurrentDomain.BaseDirectory}/Content/EmailHtml/RedefinirSenha.html";
                var html = System.IO.File.ReadAllText(pathTemplate);

                var htmlreformado = html.Replace("@codigo", criptografarID(user.codigo));
                htmlreformado = htmlreformado.Replace("@nome", user.nome.Split(" ")[0]);

                emailService.EnviaEmail("Dose de esperança", user.email, "Redefinição de senha", htmlreformado);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public bool RedefinirSenha(string token, RedefinirSenhaRequest request)
        {
            var id = descriptografarID(token);
            try
            {
                var usuario = _ctx.tabUsuario.FirstOrDefault(x => x.codigo == id);
                usuario.senha = request.senha;
                _ctx.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
