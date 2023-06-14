namespace Levva.Newbies.Coins.Domain.Models {
    public class Category {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public virtual List<Transaction> Transactions { get; set; }
    }
}

