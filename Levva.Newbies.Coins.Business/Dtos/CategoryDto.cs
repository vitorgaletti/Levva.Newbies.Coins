namespace Levva.Newbies.Coins.Business.Dtos {
    public class CategoryDto {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public virtual List<TransactionDto>? Transactions { get; set; }
    }
}
