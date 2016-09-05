using Star4Cast.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Star4Cast.ViewModels.ProfileManage
{
    public class UserAboutViewModel
    {
        public UserAboutViewModel()
        {
            //UserSocialAddressList = new List<UserSocilaAddVM>();
        }

        public string UserId { get; set; }

        public string About { get; set; }

        public string NickName { get; set; }

        public List<UserSocilaAddVM> UserSocialAddressList { get; set; }       

    }

    public class UserSocilaAddVM 
    {
        public Guid UserSocialAddressId { get; set; }

        public int Status { get; set; }

        public string SocialUserName { get; set; }

        public string SocialName { get; set; }

        public string PreUrl { get; set; }

        public string PostUrl { get; set; }

        public string PostLabel { get; set; }

        public string HelpUrl { get; set; }

        public string IconClass { get; set; }
    }
}
