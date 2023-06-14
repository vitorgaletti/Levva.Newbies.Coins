using Levva.Newbies.Coins.Domain.Enums;

namespace Levva.Newbies.Coins.Business.Dtos {
    public class TransactionDto {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public TypeTransaction Type { get; set; }
        public Guid CategoryId { get; set; }
        public string UserEmail { get; set; }
        public virtual CategoryDto? Category { get; set; }
        public virtual UserDto? Usuario { get; set; }
    }
}
