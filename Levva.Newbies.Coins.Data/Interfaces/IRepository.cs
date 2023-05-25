namespace Levva.Newbies.Coins.Data.Interfaces {
    public interface IRepository<T> {
        void Create(T entity);
        T Get(int Id);
        List<T> GetAll();
        void Update(T entity);
        void Delete(int Id);
    }
}
