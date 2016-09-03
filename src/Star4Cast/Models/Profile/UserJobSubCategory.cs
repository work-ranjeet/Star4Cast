using System;

namespace Star4Cast.Models.Profile
{
    public class UserJobSubCategory
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }
        //public ApplicationUser User { get; set; }

        public Guid JobSubCategoryId { get; set; }
        public JobSubCategory JobSubCategory { get; set; }

        public DateTime DttmCreted { get; set; } = DateTime.UtcNow;

        public DateTime DttmModified { get; set; } = DateTime.UtcNow;
    }
}
