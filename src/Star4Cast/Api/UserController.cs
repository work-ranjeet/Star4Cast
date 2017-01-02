using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Star4Cast.Data.DBContext.UserDb;
using Star4Cast.Models.Identity;
using Microsoft.AspNetCore.Authorization;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Star4Cast.Api
{
    [Route("web/[controller]/[action]")]
    public class UserController : Controller
    {
        private string _userid = null;
        private readonly UserDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserController(UserDbContext context, UserManager<ApplicationUser> userManager)
        {
            _dbContext = context;
            _userManager = userManager;
        }
        private string UserId
        {
            get
            {
                return string.IsNullOrEmpty(_userid) ? _userManager.GetUserId(HttpContext.User) : _userid;
            }
            set { this._userid = value; }
        }

        [HttpGet]
        //[Authorize]
        public async Task<dynamic> GetCurrent()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            return new
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Name = user.FirstName + " " + user.LastName,
                Email = user.Email,
                Phone = user.PhoneNumber,
                Dob = user.Dob,
                Gender = user.Gender == "M" ? "Male" : user.Gender == "M" ? "Female" : "Others",
                IsCastingProfessional = user.IsCastingProfessional,
                OrgName = user.OrgName,
                OrgDesiganation = user.OrgDesiganation,
                OrgWebsite = user.OrgWebsite,
                Address = user.Addresses
            };
        }


        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<string>> GetRoles()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var role = await _userManager.GetRolesAsync(user);
            return role;
        }

        [HttpGet]
        //[Authorize]
        public async Task<UserAddress> GetCurrentUserAddress() => await Task.Run(() =>
        {
            return _dbContext.UserAddresses.FirstOrDefault(v => v.UserId == this.UserId);
        });
    }
}
