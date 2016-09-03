using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Star4Cast.Models.Profile
{
    public class JobSubCategory
    {
        public JobSubCategory()
        {
            this.UserJobSubCategoryList = new List<UserJobSubCategory>();
        }
        public Guid Id { get; set; }

        [MaxLength(150)]
        public string SubCategoryType { get; set; }

        [MaxLength(150)]
        public string DisplayName { get; internal set; }

        [MaxLength(150)]
        public string SubCategoryName { get; set; }

        [MaxLength(250)]
        public string SubCategoryDesc { get; set; }

        public int SubCategoryStatus { get; set; }

        public DateTime DttmCreated { get; set; }

        public DateTime DttmModified { get; set; }


        public Guid JobCategoryId { get; set; }

        public JobCategory JobCategory { get; set; }

        public IList<UserJobSubCategory> UserJobSubCategoryList { get; set; }

    }
}
