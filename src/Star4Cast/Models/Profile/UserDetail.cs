using Star4Cast.Models.Common;
using Star4Cast.Models.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Star4Cast.Models.Profile
{
    public class UserDetail : IUserDetail
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        [MaxLength(1500)]
        public string About { get; set; }

        [MaxLength(200)]
        public string Nickname { get; set; }

        [MaxLength(200)]
        public string ProfileAddress { get; set; }

        public int Age { get; set; }

        public BloodGroup BloodGroup { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Disability { get; set; }

        [MaxLength(200)]
        public string HealthInfo { get; set; }

        public MariedStatus MaritalStatus { get; set; }

        [MaxLength(100)]
        public string MotherTongue { get; set; }

        [MaxLength(100)]
        public string Religion { get; set; }

        public DateTime DttmCreted { get; set; } = DateTime.UtcNow;

        public DateTime DttmModified { get; set; } = DateTime.UtcNow;

        //public ApplicationUser User { get; set; }
    }
}
