using Levva.Newbies.Coins.Business.Dtos;

namespace Levva.Newbies.Coins.Business.Services {
    public class TransactionResult {
        public List<TransactionDto> Transactions { get; set; }
        public int TotalPages { get; set; }
    }
}
