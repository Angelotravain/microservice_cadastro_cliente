using System.Linq.Expressions;

namespace EnderecoService.Repositories.Generic
{
    public interface IGeneric<T>
    {
        Task<bool> Salvar(T entidade);
        Task<bool> Atualizar(T entidade);
        Task<bool> Excluir(T entidade);
        Task<List<T>> Listar();
        Task<List<T>> Filtrar(Expression<Func<T, bool>>? filtro = null);
        Task<T?> FiltrarPorId(long id);
    }
}
