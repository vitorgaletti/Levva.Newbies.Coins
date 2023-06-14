using Levva.Newbies.Coins.Business.Dtos;
using Levva.Newbies.Coins.Business.Services;

namespace Levva.Newbies.Coins.Business.Interfaces {
    public interface ITransactionService {
        Task<ResultService<TransactionDto>> Create(TransactionDto transaction);
        TransactionDto Get(Guid Id);
        Task<TransactionResult> GetAll(string? search, int limit, int offset);
        void Update(TransactionDto transaction);
        Task<ResultService> Delete(Guid Id);
    }
}
