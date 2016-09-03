using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Star4Cast.Models.Profile
{
    public class JobCategory
    {
        public JobCategory()
        {
            SubCategoryList = new List<JobSubCategory>();
            UserJobCategoryList =new List<UserJobCategory>();
        }

        public Guid Id { get; set; }

        [MaxLength(150)]
        public string CategoryName { get; set; }

        [MaxLength(150)]
        public string DisplayName { get; internal set; }

        [MaxLength(250)]
        public string CategoryDesc { get; set; }

        public int CategoryStatus { get; set; }

        public DateTime DttmCreated { get; set; }

        public DateTime DttmModified { get; set; }


        public ICollection<JobSubCategory> SubCategoryList { get; set; }

        public ICollection<UserJobCategory> UserJobCategoryList { get; set; }

        

    }
}
