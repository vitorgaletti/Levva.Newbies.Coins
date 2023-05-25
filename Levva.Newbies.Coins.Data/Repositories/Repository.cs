﻿using Levva.Newbies.Coins.Data.Interfaces;
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

        public void Create(T entity) {
            _entity.Add(entity);
            Context.SaveChanges();
        }

        public T Get(int Id) {
            return _entity.Find(Id);
        }

        public List<T> GetAll() {
            return _entity.ToList();
        }

        public void Update(T entity) {
            _entity.Update(entity);
            Context.SaveChanges();
        }

        public void Delete(int Id) {
            var entity = _entity.Find(Id);
            _entity.Remove(entity);
            Context.SaveChanges();
        }

        
    }
}
