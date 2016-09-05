using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Star4Cast.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using Star4Cast.Data.DBContext.ProfileDb;
using Star4Cast.Models.Profile;
using Star4Cast.ViewModels.ProfileManage;
using Star4Cast.Data.Repository;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace Star4Cast.Api
{
    [Authorize]
    [Route("web/[controller]/[action]")]
    public class ProfileController : Controller
    {
        private string _userid = null;
        private readonly ProfileDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        private string UserId
        {
            get
            {
                return string.IsNullOrEmpty(_userid) ? _userManager.GetUserId(HttpContext.User) : _userid;
            }
            set { this._userid = value; }
        }

        public ProfileController(ProfileDbContext context, UserManager<ApplicationUser> userManager)
        {
            _dbContext = context;
            _userManager = userManager;
        }

        /// <summary>
        /// Will return all Job categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<JobCategory>> GetJobCategory() => await Task.Run(() => _dbContext.JobCategory.Where(v => v.CategoryStatus == 1).ToList());

        /// <summary>
        /// Will return all Job sub categories, if category id is null.
        /// Other wise return all subcategory of passd category id
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        [HttpGet("{categoryId}")]
        public async Task<IEnumerable<JobSubCategory>> GetJobSubCategory(string categoryId = null) => await Task.Run(() =>
        {
            return categoryId == null
                ? _dbContext.JobSubCategory.Where(v => v.SubCategoryStatus == 1).ToList()
                : _dbContext.JobSubCategory.Where(v => v.SubCategoryStatus == 1 && v.JobCategoryId.ToString() == categoryId).ToList();
        });

        /// <summary>
        /// Will return all Job categories with sub categories
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<JobCategory>> GetAllJobCategory() => await Task.Run(() =>
        {
            return _dbContext.JobCategory.Include(inc => inc.SubCategoryList).ToList();
        });

        /// <summary>
        /// Will return all Job categories of currentl logged user
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IEnumerable<UserJobCat>> GetCurrentUserJobCategories() => await Task.Run(() =>
        {
            var userJobCatJoin = from jobCat in _dbContext.JobCategory.Where(jc => jc.CategoryStatus == 1)
                                 from userJobCat in _dbContext.UserJobCategory.Where(ujc => ujc.JobCategoryId == jobCat.Id && ujc.UserId == UserId)
                                 .DefaultIfEmpty()
                                 select new { jobCat, userJobCat };

            var userCatList = new List<UserJobCat>();
            

            userJobCatJoin.ToList().ForEach(val =>
            {
                userCatList.Add(
                    new UserJobCat
                    {
                        CatId = val.jobCat.Id,
                        CatName = val.jobCat.CategoryName,
                        DispName = val.jobCat.DisplayName,
                        UserJobCatId = val.userJobCat != null ? val.userJobCat.Id : new Guid(),
                        IsUserCategory = val.userJobCat != null
                    });
            });
            
            return userCatList.OrderBy(v => v.DispName);
        });

        [HttpGet]
        public async Task<UserAboutViewModel> GetUserAbout()
        {
            return await Task.Run(() =>
            {
                var about = (from abt in _dbContext.UserDetails
                             where abt.UserId == this.UserId
                             select new
                             {
                                 About = abt.About,
                                 UserId = abt.UserId,
                                 NickName = abt.Nickname
                             }).FirstOrDefault();

                var userAboutViewModel = new UserAboutViewModel()
                {
                    UserId = this.UserId,
                    About = about != null ? about.About : string.Empty,
                    NickName = about != null ? about.NickName : string.Empty,
                    UserSocialAddressList = new List<UserSocilaAddVM>()
                };

                var userSocialAddressResult = SocialAddressRepository.Instance.GetSocialAddressAsync(this.UserId);
                userAboutViewModel.UserSocialAddressList.AddRange(userSocialAddressResult.Result);

                return userAboutViewModel;
            });
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
