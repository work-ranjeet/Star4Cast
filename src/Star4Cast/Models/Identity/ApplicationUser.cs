using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Star4Cast.Models.Profile;
using System.ComponentModel.DataAnnotations;

namespace Star4Cast.Models.Identity
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.Addresses = new List<UserAddress>();
            //this.UserAsentsList = new List<UserAsents>();
            //this.UserLanguageList = new List<UserLanguage>();
            //this.UserJobCategoryList = new ArraySegment<UserJobCategory>();
            //this.UserJobSubCategoryList = new ArraySegment<UserJobSubCategory>();
        }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        public DateTime Dob { get; set; }

        [MaxLength(10)]
        public string Gender { get; set; }

        public bool IsCastingProfessional { get; set; } = false;

        [MaxLength(150)]
        public string OrgName { get; set; }

        [MaxLength(150)]
        public string OrgWebsite { get; set; }

        [MaxLength(150)]
        public string OrgDesiganation { get; set; }

        public ICollection<UserAddress> Addresses { get; set; }

        //public ICollection<UserLanguage> UserLanguageList { get; set; }
        //public ICollection<UserAsents> UserAsentsList { get; set; }

        //public ICollection<UserJobCategory> UserJobCategoryList { get; set; }

        //public ICollection<UserJobSubCategory> UserJobSubCategoryList { get; set; }

        //public IEnumerable<UserDetail> UserDetailList { get; set; }

        //public IEnumerable<PhysicalAppearance> PhysicalAppearanceList { get; set; }

        //public IEnumerable<UserSocialAddress> UserSocialAddressList { get; set; }



        //public Organization Organizations { get; set; }

    }
}
