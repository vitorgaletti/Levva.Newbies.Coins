namespace Levva.Newbies.Coins.Data.Interfaces {
    public interface IRepository<T> {
        Task<T> Create(T entity);
        Task<T> Get(Guid Id);
        Task<List<T>> GetAll();
        Task Update(T entity);
        void Delete(Guid Id);
    }
}
