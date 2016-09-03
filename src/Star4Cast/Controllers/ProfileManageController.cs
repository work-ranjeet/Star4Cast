using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Star4Cast.Data.DBContext.ProfileDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Star4Cast.Models.Identity;
using Star4Cast.ViewModels.ProfileManage;
using Star4Cast.Models.Profile;
using Star4Cast.Models.Common;

namespace Star4Cast.Controllers
{
    [Authorize]
    public class ProfileManageController : Controller
    {
        private string _userid = null;
        private readonly ProfileDbContext _profileDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private string UserId
        {
            get
            {
                return string.IsNullOrEmpty(_userid) ? _userManager.GetUserId(HttpContext.User) : _userid;
            }
            set { this._userid = value; }
        }
        public ProfileManageController(ProfileDbContext context, UserManager<ApplicationUser> userManager)
        {
            _profileDbContext = context;
            _userManager = userManager;
        }


        public async Task<IActionResult> TalentProfile()
        {
            return await Task.Run(() => View());
        }

        [HttpGet]
        public async Task<IActionResult> JobCategory()
        {
            return await Task.Run(() =>
            {
                var userJobCatJoin = from jobCat in _profileDbContext.JobCategory.Where(jc => jc.CategoryStatus == 1)
                                     from userJobCat in _profileDbContext.UserJobCategory.Where(ujc => ujc.JobCategoryId == jobCat.Id && ujc.UserId == UserId)
                                     .DefaultIfEmpty()
                                     select new { jobCat, userJobCat };

                var userCatList = new UserJobCategoryViewModal();
                userCatList.UserId = UserId;

                userJobCatJoin.ForEachAsync(val =>
                {
                    userCatList.UserJobCatList.Add(
                        new UserJobCat
                        {
                            CatId = val.jobCat.Id,
                            CatName = val.jobCat.CategoryName,
                            DispName = val.jobCat.DisplayName,
                            UserJobCatId = val.userJobCat != null ? val.userJobCat.Id : new Guid(),
                            IsUserCategory = val.userJobCat != null
                        });
                });

                return View(userCatList);
                //return await Task.Run(() => View(userCatList));
            });
        }

        [HttpPost]
        public async Task<IActionResult> JobCategory(UserJobCategoryViewModal category)
        {
            category.UserJobCatList.ForEach(val =>
            {
                var user = _profileDbContext.UserJobCategory.ToList().Find(v => v.JobCategoryId == val.CatId);
                if (val.IsUserCategory)
                {
                    if (user == null)
                    {
                        _profileDbContext.UserJobCategory.Add(new Models.Profile.UserJobCategory
                        {
                            UserId = category.UserId,
                            JobCategoryId = val.CatId
                        });
                    }
                }
                else
                {
                    if (user != null)
                    {
                        var toDelete = _profileDbContext.UserJobCategory.Where(v => v.JobCategoryId == val.CatId).FirstOrDefault();
                        if (toDelete != null)
                            _profileDbContext.UserJobCategory.Remove(toDelete);
                    }
                }
            });

            _profileDbContext.SaveChanges();
            return await Task.Run(() => View(category));
        }


        [HttpGet]
        public async Task<IActionResult> About()
        {
            return await Task.Run(() =>
            {
                var about = (from abt in _profileDbContext.UserDetails where abt.UserId == this.UserId select new { About = abt.About, UserId = abt.UserId, NickName = abt.Nickname }).FirstOrDefault();

                var userAboutViewModel = new UserAboutViewModel()
                {
                    UserId = this.UserId,
                    About = about != null ? about.About : string.Empty,
                    NickName = about != null ? about.NickName : string.Empty,
                    UserSocialAddressList = new List<UserSocilaAddVM>()
                };

                var userSocialAddressJoin = from socialAdd in _profileDbContext.SocialAddress.Where(sa => sa.Status == 1)
                                            from userSocialAdd in _profileDbContext.UserSocialAddress.Where(usa => usa.SocialAddressId == socialAdd.Id && usa.Status == 1 && usa.UserId == this.UserId).DefaultIfEmpty()
                                            select new { socialAdd, userSocialAdd };

                userSocialAddressJoin.ToList().ForEach(val =>
                {
                    userAboutViewModel.UserSocialAddressList.Add(
                        new UserSocilaAddVM
                        {
                            UserSocialAddressId = val.userSocialAdd != null ? val.userSocialAdd.Id : new Guid(),
                            SosialUserName = val.userSocialAdd != null ? val.userSocialAdd.SocialUserName : string.Empty,
                            SocialName = val.socialAdd.SocialName,
                            PreUrl = val.socialAdd.PreUrl,
                            PostUrl = val.socialAdd.PostUrl,
                            PostLabel = val.socialAdd.PostLabel,
                            HelpUrl = val.socialAdd.HelpUrl,
                            IconClass = val.socialAdd.IconClass
                            //Status = StatusEnum.Active
                        });

                });

                return View(userAboutViewModel);
            });
        }

        [HttpPost]
        public async Task<IActionResult> About(UserAboutViewModel userAboutVM)
        {
            return await Task.Run(() =>
            {
                var about = _profileDbContext.UserDetails.ToList().Find(select => select.UserId == UserId);
                if (about != null)
                {
                    about.About = userAboutVM.About;
                    about.Nickname = userAboutVM.NickName;
                    _profileDbContext.UserDetails.Update(about);
                }
                else
                {
                    _profileDbContext.UserDetails.Add(new UserDetail { UserId = UserId, About = userAboutVM.About, Nickname = userAboutVM.NickName });
                }

                userAboutVM.UserSocialAddressList.ForEach(val =>
                {
                    var socialAddressId = _profileDbContext.SocialAddress.FirstOrDefault(v => v.SocialName == val.SocialName).Id;
                    if (val.UserSocialAddressId == new Guid())
                    {
                        _profileDbContext.UserSocialAddress.Add(
                            new UserSocialAddress
                            {
                                Status = 1,
                                //SocialUserName = val.SosialUserName,
                                UserId = UserId,
                                SocialAddressId = socialAddressId
                            });

                    }
                    else
                    {
                        if (string.IsNullOrEmpty(val.SosialUserName))
                        {
                            var toDelete = _profileDbContext.UserSocialAddress.Where(v => v.Id == val.UserSocialAddressId).FirstOrDefault();
                            if (toDelete != null)
                                _profileDbContext.UserSocialAddress.Remove(toDelete);
                        }
                        else
                        {
                            var toUpdate = _profileDbContext.UserSocialAddress.Where(v => v.Id == val.UserSocialAddressId).FirstOrDefault();

                            if (toUpdate != null)
                            {
                                //toUpdate.SocialUserName = val.SosialUserName;
                                //toUpdate.Status = val.Status;
                                _profileDbContext.UserSocialAddress.Update(toUpdate);
                            }
                        }
                    }
                });

                _profileDbContext.SaveChanges();
                return View(userAboutVM);
            });
        }

    }
}
