using System;

namespace Star4Cast.Models.Profile
{
    public class UserAsents
    {
        public Guid Id { get; set; }

        public DateTime DttmCreted { get; set; } = DateTime.UtcNow;

        public DateTime DttmModified { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }
       // public ApplicationUser User { get; set; }


        public Guid AccentsId { get; set; }
        public Accents Accents { get; set; }
    }
}
