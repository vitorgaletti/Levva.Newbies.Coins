namespace Levva.Newbies.Coins.Business.Dtos {
    public class UserDto {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public virtual List<TransactionDto>? Transactions { get; set; }
    }

    public class UpdateUserDto {
        public string Name { get; set; }
    }
}
