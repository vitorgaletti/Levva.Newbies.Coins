using Levva.Newbies.Coins.Business.Dtos;

namespace Levva.Newbies.Coins.Business.Services {
    public class TransactionResult {
        public List<TransactionDto> Transactions { get; set; }
        public int TotalPages { get; set; }
        public decimal TotalIncomes { get; set; }
        public decimal TotalOutcomes { get; set; }
        public decimal TotalBalance { get; set; }
    }
}
