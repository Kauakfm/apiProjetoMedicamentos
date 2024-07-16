using System.Linq.Expressions;
using WebApiEsperanca.Repository;

namespace WebApiEsperanca.Application.DaL
{
    public interface IDal<T> : IDisposable where T : class
    {
        Context CriarContexto();

        int Contar(Expression<Func<T, bool>> where);
        int Contar(Expression<Func<T, bool>> where, Context ctx);

        void Editar(T table);
        void Editar(T table, Context ctx, bool salvar = true);

        void Excluir(long codigo);
        void Excluir(long codigo, Context ctx, bool salvar = true);

        bool ExisteAlgumRegistro(Expression<Func<T, bool>> where);
        bool ExisteAlgumRegistro(Expression<Func<T, bool>> where, Context ctx);

        T Incluir(T table);
        T Incluir(T table, Context ctx, bool salvar = true);

        List<T> Incluir(List<T> tables);
        List<T> Incluir(List<T> tables, Context ctx, bool salvar = true);

        List<T> Listar();
        List<T> Listar(Context ctx);

        T[] Pesquisar(Expression<Func<T, bool>> where, params string[] includes);
        T[] Pesquisar(Expression<Func<T, bool>> where, Context ctx, params string[] includes);

        T PesquisarFirstOrDefault(Expression<Func<T, bool>> where, params string[] includes);
        T PesquisarFirstOrDefault(Expression<Func<T, bool>> where, Context ctx, params string[] includes);

        T PesquisarPorCodigo(long codigo);
        T PesquisarPorCodigo(long codigo, Context ctx);

        void Salvar(Context ctx);
    }
}
