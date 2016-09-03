using System;

namespace Star4Cast.Models.Profile
{
    public class UserLanguage
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
       // public ApplicationUser User { get; set; }

        public Guid LanguagesId { get; set; }
        public Languages Languages { get; set; }

        public DateTime DttmCreted { get; set; } = DateTime.UtcNow;

        public DateTime DttmModified { get; set; } = DateTime.UtcNow;
    }
}
