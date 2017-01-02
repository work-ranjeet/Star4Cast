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
using Star4Cast.Data.Repository;
using Microsoft.Extensions.Configuration;

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
                var about = (from abt in _profileDbContext.UserDetails
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
                    if (val.UserSocialAddressId.ToString() == new Guid().ToString())
                    {
                        _profileDbContext.UserSocialAddress.Add(
                            new UserSocialAddress
                            {
                                Status = Convert.ToInt32(StatusEnum.Active),
                                SocialUserName = val.SocialUserName,
                                UserId = UserId,
                                SocialAddressId = socialAddressId
                            });

                    }
                    else
                    {
                        if (string.IsNullOrEmpty(val.SocialUserName))
                        {
                            var toDelete = _profileDbContext.UserSocialAddress.Where(v => v.Id.ToString() == val.UserSocialAddressId.ToString()).FirstOrDefault();
                            if (toDelete != null)
                                _profileDbContext.UserSocialAddress.Remove(toDelete);
                        }
                        else
                        {
                            var toUpdate = _profileDbContext.UserSocialAddress.Where(v => v.Id.ToString() == val.UserSocialAddressId.ToString()).FirstOrDefault();

                            if (toUpdate != null)
                            {
                                toUpdate.SocialUserName = val.SocialUserName;
                                toUpdate.Status = Convert.ToInt32(StatusEnum.Active);
                                _profileDbContext.UserSocialAddress.Update(toUpdate);
                            }
                        }
                    }
                });

                _profileDbContext.SaveChanges();
                userAboutVM.UserSocialAddressList.Clear();
                userAboutVM.UserSocialAddressList.AddRange(SocialAddressRepository.Instance.GetSocialAddressAsync(this.UserId).Result);
                return View(userAboutVM);
            });
        }

        [HttpGet] // Your info
        public async Task<IActionResult> TalentInfo()
        {
            return await Task.Run(() =>
            {
                var info = (from abt in _profileDbContext.UserDetails
                            where abt.UserId == this.UserId
                            select abt).FirstOrDefault();

                var talentInfoViewModel = new TalentInfoViewModel()
                {
                    UserId = this.UserId,
                    Nickname = info.Nickname ?? string.Empty,
                    DateOfBirth = info.DateOfBirth,
                    Age = info.Age,
                    BloodGroup = info.BloodGroup,
                    Disability = info.Disability,
                    HealthInfo = info.HealthInfo,
                    MaritalStatus =info.MaritalStatus,
                    MotherTongue = info.MotherTongue,
                    Religion= info.Religion


                };

                return View(talentInfoViewModel);
            });
        }

        //[HttpPost]
        //public async Task<IActionResult> TalentInfo(TalentInfoViewModel talentInfoVM)
        //{
        //    return await Task.Run(() =>
        //    {
        //        var about = _profileDbContext.UserDetails.ToList().Find(select => select.UserId == UserId);
        //        if (about != null)
        //        {
        //            about.About = userAboutVM.About;
        //            about.Nickname = userAboutVM.NickName;
        //            _profileDbContext.UserDetails.Update(about);
        //        }
        //        else
        //        {
        //            _profileDbContext.UserDetails.Add(new UserDetail { UserId = UserId, About = userAboutVM.About, Nickname = userAboutVM.NickName });
        //        }

        //        userAboutVM.UserSocialAddressList.ForEach(val =>
        //        {
        //            var socialAddressId = _profileDbContext.SocialAddress.FirstOrDefault(v => v.SocialName == val.SocialName).Id;
        //            if (val.UserSocialAddressId.ToString() == new Guid().ToString())
        //            {
        //                _profileDbContext.UserSocialAddress.Add(
        //                    new UserSocialAddress
        //                    {
        //                        Status = Convert.ToInt32(StatusEnum.Active),
        //                        SocialUserName = val.SocialUserName,
        //                        UserId = UserId,
        //                        SocialAddressId = socialAddressId
        //                    });

        //            }
        //            else
        //            {
        //                if (string.IsNullOrEmpty(val.SocialUserName))
        //                {
        //                    var toDelete = _profileDbContext.UserSocialAddress.Where(v => v.Id.ToString() == val.UserSocialAddressId.ToString()).FirstOrDefault();
        //                    if (toDelete != null)
        //                        _profileDbContext.UserSocialAddress.Remove(toDelete);
        //                }
        //                else
        //                {
        //                    var toUpdate = _profileDbContext.UserSocialAddress.Where(v => v.Id.ToString() == val.UserSocialAddressId.ToString()).FirstOrDefault();

        //                    if (toUpdate != null)
        //                    {
        //                        toUpdate.SocialUserName = val.SocialUserName;
        //                        toUpdate.Status = Convert.ToInt32(StatusEnum.Active);
        //                        _profileDbContext.UserSocialAddress.Update(toUpdate);
        //                    }
        //                }
        //            }
        //        });

        //        _profileDbContext.SaveChanges();
        //        userAboutVM.UserSocialAddressList.Clear();
        //        userAboutVM.UserSocialAddressList.AddRange(SocialAddressRepository.Instance.GetSocialAddressAsync(this.UserId).Result);
        //        return View(userAboutVM);
        //    });
        //}

    }
}
