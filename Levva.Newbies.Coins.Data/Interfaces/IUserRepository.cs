using Levva.Newbies.Coins.Domain.Models;

namespace Levva.Newbies.Coins.Data.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetByEmailAndPassword(string email, string password);

        Task<User> CheckIfUserExists(Guid id);

        Task<User> CheckEmailAlreadyExists(string email);

        Task<Guid> GetIdByEmailUser(string email);
    }
}
