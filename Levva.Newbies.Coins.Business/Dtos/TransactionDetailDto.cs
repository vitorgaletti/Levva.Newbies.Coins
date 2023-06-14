using Levva.Newbies.Coins.Business.Dtos;
using Levva.Newbies.Coins.Domain.Enums;

public class TransactionDetailDto {
    public Guid Id { get; set; }
    public string Description { get; set; }
    public decimal Amount { get; set; }
    public DateTime CreatedAt { get; set; }
    public TypeTransaction Type { get; set; }
    public Guid CategoryId { get; set; }
    public string UserEmail { get; set; }
    public int TotalPages { get; set; }
    public virtual CategoryDto? Category { get; set; }
    public virtual UserDto? Usuario { get; set; }
}