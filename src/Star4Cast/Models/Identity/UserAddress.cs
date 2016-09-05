using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Star4Cast.Models.Identity
{
    public class UserAddress : IAddress
    {
        public int UserAddressId { get; set; }

        [MaxLength(50)]
        public string Flat { get; set; }

        [MaxLength(150)]
        [Display(Name = "Appartment/House Name")]
        public string AppOrHouseName { get; set; }

        [MaxLength(200)]
        [Display(Name = "Line One")]
        public string LineOne { get; set; }

        [MaxLength(200)]
        [Display(Name = "Line Two")]
        public string LineTwo { get; set; }

        [MaxLength(100)]
        [Display(Name = "City/Town")]
        public string CityOrTown { get; set; }

        [MaxLength(100)]
        [Display(Name = "State/Province")]
        public string StateOrProvince { get; set; }

        [MaxLength(10)]
        [Display(Name = "Zip/Postal Code")]
        public string ZipOrPostalCode { get; set; }

        [MaxLength(50)]
        public string Country { get; set; }

        [MaxLength(200)]        
        public string LandMark { get; set; }

        public DateTime DttmCreted { get; set; } = DateTime.UtcNow;

        public DateTime DttmModified { get; set; } = DateTime.UtcNow;

        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
    }
}