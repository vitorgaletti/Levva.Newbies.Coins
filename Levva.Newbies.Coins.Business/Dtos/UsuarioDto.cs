namespace Levva.Newbies.Coins.Business.Dtos {
    public class UsuarioDto {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public virtual List<TransacaoDto>? Transacoes { get; set; }
    }
}
