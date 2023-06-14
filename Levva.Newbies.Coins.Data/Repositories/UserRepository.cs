using Levva.Newbies.Coins.Data.Interfaces;
using Levva.Newbies.Coins.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Levva.Newbies.Coins.Data.Repositories {
    public class UserRepository : Repository<User>, IUserRepository {
        public UserRepository(IContext context) : base(context) { }

        public async Task<User> CheckEmailAlreadyExists(string email) {
            return await Context.Set<User>().FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> CheckIfUserExists(Guid id) {
            return await Context.Set<User>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetByEmailAndPassword(string email, string password) {
            return await Context.Set<User>().FirstOrDefaultAsync(x => x.Email.Equals(email) && x.Password.Equals(password));
        }

        public async Task<Guid> GetIdByEmailUser(string email) {
            return (await Context.Set<User>().FirstOrDefaultAsync(
                    x => x.Email == email
                ))?.Id ?? Guid.Empty;   
        }
    }
}
