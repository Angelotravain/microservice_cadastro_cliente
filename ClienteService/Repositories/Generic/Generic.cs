using ClienteService.Data;
using ClienteService.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ClienteService.Repositories.Generic
{
    public class Generic<T> : IGeneric<T> where T : class, IEntity
    {
        private readonly ClienteContexto _clientContext;
        
        public Generic(ClienteContexto clientContext)
        {
            _clientContext = clientContext;
        }

        public async Task<long> Salvar(T entidade)
        {
            var existingEntity = _clientContext.ChangeTracker.Entries<T>()
                .FirstOrDefault(e => e.Entity.Id.Equals(entidade.Id));

            if (existingEntity != null)
                _clientContext.Entry(existingEntity.Entity).State = EntityState.Detached;

            if (existingEntity == null)
            {
                await _clientContext.Set<T>().AddAsync(entidade);
            }
            else
            {
                _clientContext.Set<T>().Update(entidade);
            }

            await _clientContext.SaveChangesAsync();

            return entidade.Id;
        }


        public async Task<bool> Atualizar(T entidade)
        {
            var existingEntityEntry = _clientContext.ChangeTracker.Entries<T>()
                .FirstOrDefault(e => ((dynamic)e.Entity).Id == ((dynamic)entidade).Id);

            if (existingEntityEntry != null)
            {
                _clientContext.Entry(existingEntityEntry.Entity).State = EntityState.Detached;
            }

            _clientContext.Set<T>().Update(entidade);
            await _clientContext.SaveChangesAsync();

            return true;
        }


        public async Task<bool> Excluir(T entidade)
        {
            var existingEntity = _clientContext.Set<T>().Local.FirstOrDefault(e => e.Id == entidade.Id);
            if (existingEntity != null)
            {
                _clientContext.Entry(existingEntity).State = EntityState.Detached;
            }

            _clientContext.Set<T>().Attach(entidade);
            _clientContext.Set<T>().Remove(entidade);
            await _clientContext.SaveChangesAsync();

            return true;
        }
        public async Task<List<T>> Listar()
        {
            return await _clientContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> Filtrar(Expression<Func<T, bool>>? filtro = null)
        {
            IQueryable<T> query = _clientContext.Set<T>();

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            return await query.ToListAsync();
        }

        public async Task<T?> FiltrarPorId(long id)
        {
            var retorno = await _clientContext.Set<T>().Where(b => b.Id == id).ToListAsync();
            if (retorno != null)
            {
                return retorno.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}
