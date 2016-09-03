using Star4Cast.Models.Profile;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Star4Cast.Models.Common
{
    public class SocialAddress
    {
        public Guid Id { get; set; }

        [MaxLength(200)]
        public string SocialName { get; set; }

        [MaxLength(200)]
        public string PreUrl { get; set; }

        [MaxLength(200)]
        public string PostUrl { get; set; }

        [MaxLength(200)]
        public string PostLabel { get; set; }

        [MaxLength(200)]
        public string HelpUrl { get; set; }

        [MaxLength(100)]
        public string IconClass { get; set; }

        public int Status { get; set; } = 1;

        public ICollection<UserSocialAddress> UserSocialAddressList { get; set; }
    }
}
