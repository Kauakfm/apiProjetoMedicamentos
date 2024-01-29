using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using WebApiEsperanca.Application.Model;
using WebApiEsperanca.Repository;
using WebApiEsperanca.Repository.Models;

namespace WebApiEsperanca.Application.Service
{
    public class DoacaoService
    {
        private readonly Context _ctx;
        public DoacaoService(Context context)
        {
            _ctx = context;
        }
        public GenericResponse<bool> receberDoacao(DoacaoRequest request, int codigo)
        {
            try
            {
                EmailService emailService = new EmailService();
                tabProdutoDoado doacao = new tabProdutoDoado();
                doacao.usuarioCodigo = codigo;
                doacao.tipoProdutoCodigo = request.tipoProdutoCodigo;
                doacao.codigoStatus = 2;
                doacao.nome = request.nome;
                doacao.qntd = request.qntd;
                doacao.validade = request.validade;
                doacao.dosagem = request.dosagem == 0 ? null : request.dosagem;
                doacao.forma = request.forma == 0 ? null : request.forma;
                _ctx.tabProdutoDoado.Add(doacao);
                _ctx.SaveChanges();

                var usuario = _ctx.tabUsuario.FirstOrDefault(x => x.codigo == codigo);
                var email = usuario?.email;

                var Template = $"{System.AppDomain.CurrentDomain.BaseDirectory}/Content/EmailHtml/Agradecimento.html";
                var htmlTemplate = System.IO.File.ReadAllText(Template);
                var htmlArrumado = htmlTemplate
                .Replace("@Nome", usuario.nome);
                emailService.EnviaEmail("Dose de esperança", email, "Realização da doação conluída", htmlArrumado);

                return new GenericResponse<bool>("doação realizada com sucesso", true);
            }
            catch (Exception)
            {
                return new GenericResponse<bool>("houve algum problema ao reaçizar sua doação", false);
            }
        }
        public List<obterDoacao> obterDoacoes()
        {
            try
            {
                List<obterDoacao> doacao = new List<obterDoacao>();
                var doacoes = _ctx.tabProdutoDoado.ToList();
                var tipoProduto = _ctx.tabTipoProduto.ToList();
                var usuario = _ctx.tabUsuario.ToList();
                foreach(var item in doacoes)
                {
                    string descnome = usuario.FirstOrDefault(x => x.codigo == item.usuarioCodigo)?.nome;
                    string descTipo = tipoProduto.FirstOrDefault(x => x.codigo == item.tipoProdutoCodigo)?.descricao;
                    doacao.Add(new obterDoacao {
                       codigo = item.codigo,
                       nome = item.nome,
                       nomeUser = descnome,
                       statusCodigo = item.codigoStatus,
                       tipoProdutoCodigo = descTipo,
                       validade = item.validade,
                    });
                }
                return doacao;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public TabelaInfo[] ObterDosagens()
        {
            return _ctx.tabDosagem
                .Select(d => new TabelaInfo { Codigo = d.codigo, Descricao = d.descricao })
                .ToArray();
        }

        public TabelaInfo[] ObterFormasMedicamento()
        {
            return _ctx.tabFormaMedicamento
                .Select(f => new TabelaInfo { Codigo = f.codigo, Descricao = f.descricao })
                .ToArray();
        }

        public TabelasDTO ObterTabelas()
        {
            var dosagens = ObterDosagens();
            var formasMedicamento = ObterFormasMedicamento();

            var tabelasDTO = new TabelasDTO
            {
                Dosagens = dosagens.ToList(),
                FormasMedicamento = formasMedicamento.ToList()
            };

            return tabelasDTO;
        }

        public GenericResponse<bool> aprovarDoacao(AprovarRequest request, int id)
        {
            try
            {
                var produto = _ctx.tabProdutoDoado.FirstOrDefault(x => x.codigo == id);
                var tabAprovar = _ctx.tabAprovacaoProduto.ToList();

                if(tabAprovar.Any(x => x.produtoDoadoCodigo == id))
                {
                    return new GenericResponse<bool>("Essa doação já foi aprovada", false);
                }
                tabAprovacaoProduto aprova = new tabAprovacaoProduto()
                {
                    produtoDoadoCodigo = id,
                    codigoStatus = request.statusCodigo,
                    obs = request.obs,
                    usuarioBaixa = request.usuarioBaixa,
                    dataAprovacao = DateTime.Now,
                };
                    _ctx.tabAprovacaoProduto.Add(aprova);
                    _ctx.SaveChanges();
                
                
                if (request.statusCodigo == 1)
                {
                    produto.codigoStatus = 1;
                    _ctx.tabProdutoDoado.Update(produto);
                    _ctx.SaveChanges();
                    return new GenericResponse<bool>("Doação aprovada com sucesso", true);
                }
                else if (request.statusCodigo == 3)
                {
                    produto.codigoStatus = 3;
                    _ctx.tabProdutoDoado.Update(produto);
                    _ctx.SaveChanges();
                    return new GenericResponse<bool>("Doação reprovada com sucesso", true);
                }
                return new GenericResponse<bool>("Status de doação não reconhecido", false);
            }
            catch (Exception ex)
            {
                return new GenericResponse<bool>("Ocorreu um erro ao processar a aprovação: " + ex.Message, false);
            }
        }

    }
}
