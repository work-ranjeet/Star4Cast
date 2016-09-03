using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Star4Cast.ViewModels.ProfileManage
{
    public class UserJobCategoryViewModal
    {
        public UserJobCategoryViewModal()
        {
            UserJobCatList = new List<UserJobCat>();
        }

        public string UserId { get; set; }  
        
        public List<UserJobCat> UserJobCatList { get; set; }

    }

    public class UserJobCat
    {
        public Guid CatId { get; set; }

        public string CatName { get; set; }

        public string DispName { get; set; }

        public Guid UserJobCatId { get; set; }

        public bool IsUserCategory { get; set; }
    }
}
