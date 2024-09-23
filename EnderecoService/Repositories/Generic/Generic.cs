using EnderecoService.Data;
using EnderecoService.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EnderecoService.Repositories.Generic
{
    public class Generic<T> : IGeneric<T> where T : class, IEntity
    {
        private readonly EnderecoContext _enderecoContext;

        public Generic(EnderecoContext clientContext)
        {
            _enderecoContext = clientContext;
        }

        public async Task<bool> Salvar(T entidade)
        {
            var existingEntity = _enderecoContext.ChangeTracker.Entries<T>()
                .FirstOrDefault(e => e.Entity.Id.Equals(entidade.Id));

            if (existingEntity != null)
                _enderecoContext.Entry(existingEntity.Entity).State = EntityState.Detached;

            if (existingEntity == null)
                await _enderecoContext.Set<T>().AddAsync(entidade);
            else
                _enderecoContext.Set<T>().Update(entidade);

            try
            {
                await _enderecoContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao salvar: {ex.Message}");
            }

            return true;
        }


        public async Task<bool> Atualizar(T entidade)
        {
            var existingEntityEntry = _enderecoContext.ChangeTracker.Entries<T>()
                .FirstOrDefault(e => ((dynamic)e.Entity).Id == ((dynamic)entidade).Id);

            if (existingEntityEntry != null)
            {
                _enderecoContext.Entry(existingEntityEntry.Entity).State = EntityState.Detached;
            }

            _enderecoContext.Set<T>().Update(entidade);
            await _enderecoContext.SaveChangesAsync();

            return true;
        }


        public async Task<bool> Excluir(T entidade)
        {
            var existingEntity = _enderecoContext.Set<T>().Local.FirstOrDefault(e => e.Id == entidade.Id);
            if (existingEntity != null)
            {
                _enderecoContext.Entry(existingEntity).State = EntityState.Detached;
            }

            _enderecoContext.Set<T>().Attach(entidade);
            _enderecoContext.Set<T>().Remove(entidade);
            await _enderecoContext.SaveChangesAsync();

            return true;
        }
        public async Task<List<T>> Listar()
        {
            return await _enderecoContext.Set<T>().ToListAsync();
        }

        public async Task<List<T>> Filtrar(Expression<Func<T, bool>>? filtro = null)
        {
            IQueryable<T> query = _enderecoContext.Set<T>();

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            return await query.ToListAsync();
        }

        public async Task<T?> FiltrarPorId(long id)
        {
            var retorno = await _enderecoContext.Set<T>().Where(b => b.Id == id).ToListAsync();
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
