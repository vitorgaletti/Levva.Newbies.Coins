using Levva.Newbies.Coins.Domain.Models;

namespace Levva.Newbies.Coins.Data.Interfaces
{
    public interface ITransacaoRepository : IRepository<Transacao>
    {
        List<Transacao> GetAll(int limit = 10, int offset = 1);
    }
}
