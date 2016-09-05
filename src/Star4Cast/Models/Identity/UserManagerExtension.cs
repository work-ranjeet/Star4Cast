
using Microsoft.AspNetCore.Identity;
using Star4Cast.Data.Repository;
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

        public static async Task<bool> HasAddressAsync<TUser>(this UserManager<TUser> User, string UserId) where TUser : class
        {
            return await Task.Factory.StartNew(() =>
            {
                var address = UserRepository.Instance.GetUserAddressAsync(UserId).Result;
                return address != null;
            });
        }

        public static async Task<UserAddress> GetAddressAsync<TUser>(this UserManager<TUser> User, string UserId) where TUser : class
        {
            return await Task.Factory.StartNew(() =>
            {
                return UserRepository.Instance.GetUserAddressAsync(UserId).Result;
            });
        }
    }
}
