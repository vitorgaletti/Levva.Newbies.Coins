using Levva.Newbies.Coins.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Levva.Newbies.Coins.Data.Repositories {
    public class Repository<T> : IRepository<T> where T : class {

        protected readonly IContext Context;
        private readonly DbSet<T> _entity;
        public IQueryable<T> Entity => _entity;
        public Repository(IContext context) {
            Context = context;
            _entity = Context.Set<T>();
        }

        public async Task<T> Create(T entity) {
            if (entity is IGuidIdEntity guidIdEntity) 
            {
                guidIdEntity.Id = Guid.NewGuid(); 
            }
            _entity.Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(Guid Id) {
            return _entity.Find(Id);
        }

        public async Task<List<T>> GetAll() {
            return _entity.ToList();
        }

        public async Task Update(T entity) {
            _entity.Update(entity);
           await Context.SaveChangesAsync();
        }

        public void Delete(Guid Id) {
            var entity = _entity.Find(Id);
            _entity.Remove(entity);
            Context.SaveChangesAsync();
        }

        
    }
}
