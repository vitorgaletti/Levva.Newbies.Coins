using Levva.Newbies.Coins.Domain.Enums;

namespace Levva.Newbies.Coins.Domain.Models {
    public class Transaction {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public TypeTransaction Type { get; set; }
        public Guid CategoryId { get; set; }
        public Guid UserId { get; set; }

        public virtual Category Category { get; set; }
        public virtual User User { get; set; }

        
    }
}
