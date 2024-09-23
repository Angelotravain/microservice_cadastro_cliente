using EnderecoService.Repositories.Generic;
using System.Linq.Expressions;

namespace EnderecoService.Services.Persistense
{
    public class BaseEntity<T> where T : class
    {
        protected readonly IGeneric<T> _generic;

        public BaseEntity(IGeneric<T> generic)
        {
            _generic = generic;
        }

        public virtual async Task<bool> Salvar(T entidade)
        {
            return await _generic.Salvar(entidade);
        }

        public virtual async Task<bool> Excluir(T entidade)
        {
           return await _generic.Excluir(entidade);
        }
        public virtual async Task<bool> Atualizar(T entidade)
        {
            return await _generic.Atualizar(entidade);
        }

        public virtual async Task<List<T>> Listar()
        {
            return await _generic.Listar();
        }

        public virtual async Task<T> FiltrarPorId(long id)
        {
            return await _generic.FiltrarPorId(id);
        }
        public virtual async Task<IEnumerable<T>> Filtrar(Expression<Func<T, bool>> filtro = null)
        {
            return await _generic.Filtrar(filtro);
        }
    }
}
