using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebApiEsperanca.Repository;
using WebApiEsperanca.Repository.Models;

namespace WebApiEsperanca.Application.DaL
{
    public class SuporteDal<T> : IDal<T> where T : class
    {
        /// <summary>
        /// Cria um novo contexto do Banco de Dados.
        /// </summary>
        /// <returns>Retorna o novo contexto criado</returns>
        public Context CriarContexto()
        {
            return SuporteDal.CriarContexto();
        }

        /// <summary>
        /// Conta os registros com o filtro desejádo.
        /// </summary>
        /// <param name="where">Cláusula do filtro</param>
        /// <returns>Retorna a quantidade de registros contados no Banco de Dados</returns>
        public int Contar(Expression<Func<T, bool>> where)
        {
            return SuporteDal.Contar<T>(where);
        }

        /// <summary>
        /// Conta os registros com o filtro desejádo, precisando de um contexto.
        /// </summary>
        /// <param name="where">Cláusula do filtro</param>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <returns>Retorna a quantidade de registros contados no Banco de Dados</returns>
        public int Contar(Expression<Func<T, bool>> where, Context ctx)
        {
            return SuporteDal.Contar<T>(where, ctx);
        }

        /// <summary>
        /// Edita o Objeto já salvando os dados.
        /// </summary>
        /// <param name="table">Objeto que você deseja Editar</param>
        public void Editar(T table)
        {
            SuporteDal.Editar(table);
        }

        /// <summary>
        /// Edita o Objeto, precisando de um contexto e deixa opcional o salvamento.
        /// </summary>
        /// <param name="table">Objeto que você deseja Editar</param>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <param name="salvar">Opção de salvar os dados no banco - Default TRUE</param>
        public void Editar(T table, Context ctx, bool salvar = true)
        {
            SuporteDal.Editar<T>(table, ctx, salvar);
        }

        /// <summary>
        /// Exclui o registro no Banco de Dados, já salvando a exclusão.
        /// </summary>
        /// <param name="codigo">Código do registro que você deseja Excluir</param>
        public void Excluir(long codigo)
        {
            SuporteDal.Excluir<T>(codigo);
        }

        /// <summary>
        /// Exclui o registro no Banco de Dados, precisando de um contexto e deixa opcional o salvamento.
        /// </summary>
        /// <param name="codigo">Código do registro que você deseja Excluir</param>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <param name="salvar">Opção de salvar os dados no banco - Default TRUE</param>
        public void Excluir(long codigo, Context ctx, bool salvar = true)
        {
            SuporteDal.Excluir<T>(codigo, ctx, salvar);
        }

        /// <summary>
        /// Verifica se existe algum registro com o filtro desejádo.
        /// </summary>
        /// <param name="where">Cláusula do filtro</param>
        /// <returns>Retorna verdadeiro se achou algum registro com o filtro informado</returns>
        public bool ExisteAlgumRegistro(Expression<Func<T, bool>> where)
        {
            return SuporteDal.ExisteAlgumRegistro<T>(where);
        }

        /// <summary>
        /// Verifica se existe algum registro com o filtro desejádo, precisando de um contexto.
        /// </summary>
        /// <param name="where">Cláusula do filtro</param>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <returns>Retorna verdadeiro se achou algum registro com o filtro informado</returns>
        public bool ExisteAlgumRegistro(Expression<Func<T, bool>> where, Context ctx)
        {
            return SuporteDal.ExisteAlgumRegistro<T>(where, ctx);
        }

        /// <summary>
        /// Inclui o Objeto já salvando os dados.
        /// </summary>
        /// <param name="table">Objeto que você deseja Incluir</param>
        /// <returns>Retorna o Objeto incluido</returns>
        public T Incluir(T table)
        {
            return SuporteDal.Incluir<T>(table);
        }

        /// <summary>
        /// Inclui o Objeto, precisando de um contexto e deixa opcional o salvamento.
        /// </summary>
        /// <param name="table">Objeto que você deseja Incluir</param>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <param name="salvar">Opção de salvar os dados no banco - Default TRUE</param>
        /// <returns>Retorna o Objeto incluido</returns>
        public T Incluir(T table, Context ctx, bool salvar = true)
        {
            return SuporteDal.Incluir<T>(table, ctx, salvar);
        }

        /// <summary>
        /// Inclui os Objetos já salvando os dados.
        /// </summary>
        /// <param name="tables">Lista de Objetos que você deseja Incluir</param>
        /// <returns>Retorna os Objetos incluidos</returns>
        public List<T> Incluir(List<T> tables)
        {
            return SuporteDal.Incluir<T>(tables);
        }

        /// <summary>
        /// Inclui os Objetos, precisando de um contexto e deixa opcional o salvamento.
        /// </summary>
        /// <param name="tables">Lista de Objetos que você deseja Incluir</param>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <param name="salvar">Opção de salvar os dados no banco - Default TRUE</param>
        /// <returns>Retorna os Objetos incluidos</returns>
        public List<T> Incluir(List<T> tables, Context ctx, bool salvar = true)
        {
            return SuporteDal.Incluir<T>(tables, ctx, salvar);
        }

        /// <summary>
        /// Lista todos os Registros da tabela
        /// </summary>
        /// <returns>Retorna os Objetos listados</returns>
        public List<T> ListarTable()
        {
            return SuporteDal.ListarTable<T>();
        }

        /// <summary>
        /// Lista todos os Registros da tabela, precisando de um contexto.
        /// </summary>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <returns>Retorna os Objetos listados</returns>
        public List<T> Listar(Context ctx)
        {
            return SuporteDal.ListarTable<T>(ctx);
        }

        /// <summary>
        /// Pesquisa os registros com o filtro desejádo.
        /// </summary>
        /// <param name="where">Cláusula do filtro</param>
        /// <param name="includes">Nomes das tabelas que você deseja trazer junto com a pesquisa</param>
        /// <returns>Retorna os Objetos encontrados</returns>
        public T[] Pesquisar(Expression<Func<T, bool>> where, params string[] includes)
        {
            return SuporteDal.Pesquisar<T>(where, includes);
        }

        /// <summary>
        /// Pesquisa os registros com o filtro desejádo, precisando de um contexto.
        /// </summary>
        /// <param name="where">Cláusula do filtro</param>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <param name="includes">Nomes das tabelas que você deseja trazer junto com a pesquisa</param>
        /// <returns>Retorna os Objetos encontrados</returns>
        public T[] Pesquisar(Expression<Func<T, bool>> where, Context ctx, params string[] includes)
        {
            return SuporteDal.Pesquisar<T>(where, ctx, includes);
        }

        /// <summary>
        /// Pesquisa o primeiro registro com o filtro desejádo.
        /// </summary>
        /// <param name="where">Cláusula do filtro</param>
        /// <param name="includes">Nomes das tabelas que você deseja trazer junto com a pesquisa</param>
        /// <returns>Retorna o primeiro Objeto encontrado</returns>
        public T PesquisarFirstOrDefault(Expression<Func<T, bool>> where, params string[] includes)
        {
            return SuporteDal.PesquisarFirstOrDefault<T>(where, includes);
        }

        /// <summary>
        /// Pesquisa o primeiro registro com o filtro desejádo, precisando de um contexto.
        /// </summary>
        /// <param name="where">Cláusula do filtro</param>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <param name="includes">Nomes das tabelas que você deseja trazer junto com a pesquisa</param>
        /// <returns>Retorna o primeiro Objeto encontrado</returns>
        public T PesquisarFirstOrDefault(Expression<Func<T, bool>> where, Context ctx, params string[] includes)
        {
            return SuporteDal.PesquisarFirstOrDefault<T>(where, ctx, includes);
        }

        /// <summary>
        /// Pesquisa o registros com o código desejádo.
        /// </summary>
        /// <param name="codigo">Código do registro que você deseja Pesquisar</param>
        /// <returns>Retorna o Objeto encontrado</returns>
        public T PesquisarPorCodigo(long codigo)
        {
            return SuporteDal.PesquisarPorCodigo<T>(codigo);
        }

        /// <summary>
        /// Pesquisa o registros com o código desejádo, precisando de um contexto.
        /// </summary>
        /// <param name="codigo">Código do registro que você deseja Pesquisar</param>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <returns>Retorna o Objeto encontrado</returns>
        public T PesquisarPorCodigo(long codigo, Context ctx)
        {
            return SuporteDal.PesquisarPorCodigo<T>(codigo, ctx);
        }

        /// <summary>
        /// Salva o Contexto no Banco de Dados
        /// </summary>
        /// <param name="ctx"></param>
        public void Salvar(Context ctx)
        {
            SuporteDal.Salvar(ctx);
        }

        /// <summary>
        /// Coloca este objeto na fila de limpeza do Garbage Collector
        /// </summary>
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }


    }
    public static class SuporteDal
    {
        /// <summary>
        /// Cria um novo contexto do Banco de Dados.
        /// </summary>
        /// <returns>Retorna o novo contexto criado</returns>
        public static Context CriarContexto(Context context = null)
        {
            return context;
        }

        /// <summary>
        /// Conta os registros com o filtro desejádo.
        /// </summary>
        /// <param name="where">Cláusula do filtro</param>
        /// <returns>Retorna a quantidade de registros contados no Banco de Dados</returns>
        public static int Contar<T>(Expression<Func<T, bool>> where) where T : class
        {
            using (var ctx = CriarContexto())
            {
                return Contar<T>(where, ctx);
            }
        }

        /// <summary>
        /// Conta os registros com o filtro desejádo, precisando de um contexto.
        /// </summary>
        /// <param name="where">Cláusula do filtro</param>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <returns>Retorna a quantidade de registros contados no Banco de Dados</returns>
        public static int Contar<T>(Expression<Func<T, bool>> where, Context ctx) where T : class
        {
            DbSet<T> dbSet = ctx.Set<T>();
            return dbSet.AsNoTracking().Count<T>(where);
        }

        /// <summary>
        /// Edita o Objeto já salvando os dados.
        /// </summary>
        /// <param name="table">Objeto que você deseja Editar</param>
        public static void Editar<T>(T table) where T : class
        {
            using (var ctx = CriarContexto())
            {
                Editar<T>(table, ctx);
            }
        }

        public static async Task EditarAsync<T>(T table) where T : class
        {
            using (var ctx = CriarContexto())
            {
                try
                {
                    var dbSet = ctx.Set<T>();
                    dbSet.Attach(table);
                    ctx.Entry(table).State = EntityState.Modified;
                    await ctx.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    tabLogExcecao logEx = new tabLogExcecao();
                    logEx.excecao = ex.ToString();
                    logEx.referencia = "INCLUIR ANALISE CRITICA ANEXOS";
                    LogExcecaoDal.GravaLogExcecao(logEx, ctx);
                }
            }
        }

        /// <summary>
        /// Edita o Objeto, precisando de um contexto e deixa opcional o salvamento.
        /// </summary>
        /// <param name="table">Objeto que você deseja Editar</param>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <param name="salvar">Opção de salvar os dados no banco - Default TRUE</param>
        public static void Editar<T>(T table, Context ctx, bool salvar = true) where T : class
        {
            var dbSet = ctx.Set<T>();
            dbSet.Attach(table);
            ctx.Entry(table).State = EntityState.Modified;

            if (salvar)
                Salvar(ctx);
        }

        /// <summary>
        /// Exclui o registro no Banco de Dados, já salvando a exclusão.
        /// </summary>
        /// <param name="codigo">Código do registro que você deseja Excluir</param>
        public static void Excluir<T>(long codigo) where T : class
        {
            using (var ctx = CriarContexto())
            {
                Excluir<T>(codigo, ctx);
            }
        }

        public static void Excluir<T>(Expression<Func<T, bool>> where) where T : class
        {
            using (var ctx = CriarContexto())
            {
                var dados = ctx.Set<T>().Where(where);
                ctx.Set<T>().RemoveRange(dados);
                Salvar(ctx);
            }

        }

        /// <summary>
        /// Exclui o registro no Banco de Dados, precisando de um contexto e deixa opcional o salvamento.
        /// </summary>
        /// <param name="codigo">Código do registro que você deseja Excluir</param>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <param name="salvar">Opção de salvar os dados no banco - Default TRUE</param>
        public static void Excluir<T>(long codigo, Context ctx, bool salvar = true) where T : class
        {
            var dbSet = ctx.Set<T>();
            var objExcluir = dbSet.Find(codigo);
            if (objExcluir != null)
            {
                dbSet.Remove(objExcluir);

                if (salvar)
                    Salvar(ctx);
            }
        }

        /// <summary>
        /// Verifica se existe algum registro com o filtro desejádo.
        /// </summary>
        /// <param name="where">Cláusula do filtro</param>
        /// <returns>Retorna verdadeiro se achou algum registro com o filtro informado</returns>
        public static bool ExisteAlgumRegistro<T>(Expression<Func<T, bool>> where) where T : class
        {
            using (var ctx = CriarContexto())
            {
                return ExisteAlgumRegistro<T>(where, ctx);
            }
        }

        /// <summary>
        /// Verifica se existe algum registro com o filtro desejádo, precisando de um contexto.
        /// </summary>
        /// <param name="where">Cláusula do filtro</param>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <returns>Retorna verdadeiro se achou algum registro com o filtro informado</returns>
        public static bool ExisteAlgumRegistro<T>(Expression<Func<T, bool>> where, Context ctx) where T : class
        {
            DbSet<T> dbSet = ctx.Set<T>();
            return dbSet.AsNoTracking().Any<T>(where);
        }

        /// <summary>
        /// Inclui o Objeto já salvando os dados.
        /// </summary>
        /// <param name="table">Objeto que você deseja Incluir</param>
        /// <returns>Retorna o Objeto incluido</returns>
        public static T Incluir<T>(T table) where T : class
        {
            using (var ctx = CriarContexto())
            {
                return Incluir<T>(table, ctx);
            }
        }

        /// <summary>
        /// Inclui o Objeto, precisando de um contexto e deixa opcional o salvamento.
        /// </summary>
        /// <param name="table">Objeto que você deseja Incluir</param>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <param name="salvar">Opção de salvar os dados no banco - Default TRUE</param>
        /// <returns>Retorna o Objeto incluido</returns>
        public static T Incluir<T>(T table, Context ctx, bool salvar = true) where T : class
        {
            var dbSet = ctx.Set<T>();
            var entityEntry = dbSet.Add(table);

            if (salvar)
                Salvar(ctx);

            return entityEntry.Entity;
        }

        /// <summary>
        /// Inclui os Objetos já salvando os dados.
        /// </summary>
        /// <param name="tables">Lista de Objetos que você deseja Incluir</param>
        /// <returns>Retorna os Objetos incluidos</returns>
        public static List<T> Incluir<T>(List<T> tables) where T : class
        {
            using (var ctx = CriarContexto())
            {
                return Incluir<T>(tables, ctx);
            }
        }

        /// <summary>
        /// Inclui os Objetos, precisando de um contexto e deixa opcional o salvamento.
        /// </summary>
        /// <param name="tables">Lista de Objetos que você deseja Incluir</param>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <param name="salvar">Opção de salvar os dados no banco - Default TRUE</param>
        /// <returns>Retorna os Objetos incluidos</returns>
        public static List<T> Incluir<T>(List<T> tables, Context ctx, bool salvar = true) where T : class
        {
            var dbSet = ctx.Set<T>();

            for (int i = 0; i < tables.Count; i++)
            {
                var entityEntry = dbSet.Add(tables[i]);
                tables[i] = entityEntry.Entity;
            }
              

            if (salvar)
                Salvar(ctx);

            return tables;
        }

        /// <summary>
        /// Lista todos os Registros da tabela
        /// </summary>
        /// <returns>Retorna os Objetos listados</returns>
        public static List<T> ListarTable<T>(Context context = null) where T : class
        {
                return Listar<T>(context);
        }

        /// <summary>
        /// Lista todos os Registros da tabela, precisando de um contexto.
        /// </summary>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <returns>Retorna os Objetos listados</returns>
        public static List<T> Listar<T>(Context ctx) where T : class
        {
            var dbSet = ctx.Set<T>();
            return dbSet.AsNoTracking().ToList<T>();
        }

        /// <summary>
        /// Pesquisa os registros com o filtro desejádo.
        /// </summary>
        /// <param name="where">Cláusula do filtro</param>
        /// <param name="includes">Nomes das tabelas que você deseja trazer junto com a pesquisa</param>
        /// <returns>Retorna os Objetos encontrados</returns>
        public static T[] Pesquisar<T>(Expression<Func<T, bool>> where, params string[] includes) where T : class
        {
            using (var ctx = CriarContexto())
            {
                return Pesquisar<T>(where, ctx, includes);
            }
        }

        /// <summary>
        /// Pesquisa os registros com o filtro desejádo, precisando de um contexto.
        /// </summary>
        /// <param name="where">Cláusula do filtro</param>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <param name="includes">Nomes das tabelas que você deseja trazer junto com a pesquisa</param>
        /// <returns>Retorna os Objetos encontrados</returns>
        public static T[] Pesquisar<T>(Expression<Func<T, bool>> where, Context ctx, params string[] includes) where T : class
        {
            IQueryable<T> queryable = ctx.Set<T>();

            foreach (string include in includes)
                queryable = queryable.Include(include);

            return queryable.AsNoTracking().Where<T>(where).ToArray<T>();
        }

        /// <summary>
        /// Pesquisa o primeiro registro com o filtro desejádo.
        /// </summary>
        /// <param name="where">Cláusula do filtro</param>
        /// <param name="includes">Nomes das tabelas que você deseja trazer junto com a pesquisa</param>
        /// <returns>Retorna o primeiro Objeto encontrado</returns>
        public static T PesquisarFirstOrDefault<T>(Expression<Func<T, bool>> where, params string[] includes) where T : class
        {
            using (var ctx = CriarContexto())
            {
                return PesquisarFirstOrDefault<T>(where, ctx, includes);
            }
        }

        /// <summary>
        /// Pesquisa o primeiro registro com o filtro desejádo, precisando de um contexto.
        /// </summary>
        /// <param name="where">Cláusula do filtro</param>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <param name="includes">Nomes das tabelas que você deseja trazer junto com a pesquisa</param>
        /// <returns>Retorna o primeiro Objeto encontrado</returns>
        public static T PesquisarFirstOrDefault<T>(Expression<Func<T, bool>> where, Context ctx, params string[] includes) where T : class
        {
            IQueryable<T> queryable = ctx.Set<T>();

            foreach (string include in includes)
                queryable = queryable.Include(include);

            return queryable.AsNoTracking().FirstOrDefault<T>(where);
        }

        /// <summary>
        /// Pesquisa o registros com o código desejádo.
        /// </summary>
        /// <param name="codigo">Código do registro que você deseja Pesquisar</param>
        /// <returns>Retorna o Objeto encontrado</returns>
        public static T PesquisarPorCodigo<T>(long codigo) where T : class
        {
            using (var ctx = CriarContexto())
            {
                return PesquisarPorCodigo<T>(codigo, ctx);
            }
        }

        /// <summary>
        /// Pesquisa o registros com o código desejádo, precisando de um contexto.
        /// </summary>
        /// <param name="codigo">Código do registro que você deseja Pesquisar</param>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <returns>Retorna o Objeto encontrado</returns>
        public static T PesquisarPorCodigo<T>(long codigo, Context ctx) where T : class
        {
            var dbSet = ctx.Set<T>();
            return dbSet.Find(codigo);
        }

        /// <summary>
        /// Pesquisa o registros com o comando SQL Server.
        /// </summary>
        /// <param name="sql">Comando que você deseja Pesquisar</param>
        /// <param name="parameters">Parametros do comando</param>
        /// <returns>Retorna o Objeto encontrado</returns>
        public static IEnumerable<T> PesquisarSqlCommand<T>(string sql, params object[] parameters) where T : class
        {
            using (var ctx = CriarContexto())
            {
                return PesquisarSqlCommand<T>(sql, ctx, parameters);
            }
        }

        /// <summary>
        /// Pesquisa o registros com o comando SQL Server, precisando de um contexto.
        /// </summary>
        /// <param name="sql">Comando que você deseja Pesquisar</param>
        /// <param name="ctx">Contexto do Banco de Dados</param>
        /// <param name="parameters">Parametros do comando</param>
        /// <returns>Retorna o Objeto encontrado</returns>
        public static IEnumerable<T> PesquisarSqlCommand<T>(string sql, Context ctx, params object[] parameters) where T : class
        {
              return ctx.Set<T>().FromSqlRaw(sql, parameters);
        }

        /// <summary>
        /// Salva o Contexto no Banco de Dados
        /// </summary>
        /// <param name="ctx"></param>
        public static void Salvar(Context ctx)
        {
            try
            {
                ctx.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                throw new ApplicationException(MontarErroValidacao(dbEx));
            }
        }
        private static string MontarErroValidacao(DbEntityValidationException dbEx)
        {
            string erro = string.Empty;

            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    erro += string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage) + "</br>";
                }
            }

            return erro;
        }
    }
}
