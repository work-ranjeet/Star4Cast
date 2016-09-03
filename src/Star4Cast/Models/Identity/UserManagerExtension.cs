
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Star4Cast.Models.Identity
{
    public static class UserManagerExtension
    {
        public static string GetFirstNameByUserIdAsync(this UserManager<ApplicationUser> manager, string userId)
        {
            var user = manager.FindByIdAsync(userId);

            return user.Result.FirstName;
        }

       
    }
}
