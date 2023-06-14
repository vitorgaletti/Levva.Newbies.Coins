namespace Levva.Newbies.Coins.Business.Dtos {
    public class LoginDto {

        public Guid Id { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string? Name { get; set; }
        public string? Token { get; set; }
    }

}
