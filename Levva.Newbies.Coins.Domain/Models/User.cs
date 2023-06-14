﻿namespace Levva.Newbies.Coins.Domain.Models {
    public class User {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        
        public virtual List<Transaction>? Transactions { get; set; }
    }
}
