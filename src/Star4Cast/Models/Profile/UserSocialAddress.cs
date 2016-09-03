using Star4Cast.Models.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Star4Cast.Models.Profile
{
    public class UserSocialAddress
    {
        public Guid Id { get; set; }

        [MaxLength(200)]
        public string SocialUserName { get; set; }

        public int Status { get; set; } = 1;

        public DateTime DttmCreted { get; set; } = DateTime.UtcNow;

        public DateTime DttmModified { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }

        //public ApplicationUser User { get; set; }

        public Guid SocialAddressId { get; set; }
        public SocialAddress SocialAddress { get; set; }
    }
}
