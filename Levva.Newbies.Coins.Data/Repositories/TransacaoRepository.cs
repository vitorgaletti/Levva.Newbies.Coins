using Levva.Newbies.Coins.Data.Interfaces;
using Levva.Newbies.Coins.Domain.Models;

namespace Levva.Newbies.Coins.Data.Repositories
{
    public class TransacaoRepository : Repository<Transacao>, ITransacaoRepository {
        
        public TransacaoRepository(IContext context) : base(context) { }
        public List<Transacao> GetAll(int limit = 10, int offset = 1) {
            return Entity.OrderBy(e => e.Id)
                .Skip((offset -1) * limit)
                .Take(limit)
                .ToList();
        }
    }
}
