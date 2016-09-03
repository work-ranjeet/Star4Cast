using Microsoft.AspNetCore.Builder;
using Star4Cast.Data.DBContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Star4Cast.Models.Profile;
using System;
using System.Linq;
using Star4Cast.Data.DBContextExtensions;
using Star4Cast.Models.Identity;
using Star4Cast.Models.Common;

namespace Star4Cast.Data.DBContext.UserDb
{
    public static class DbContextDataSeeding
    {
        public static async void EnsureUsersAndRolesCreated(this IApplicationBuilder app)
        {
            var context = app.ApplicationServices.GetService<UserDbContext>();
            if (context.AllMigrationsApplied())
            {
                var roleManager = app.ApplicationServices.GetService<RoleManager<IdentityRole>>();
                foreach (var role in RoleList.Instance.All)
                {
                    if (!roleManager.RoleExistsAsync(role.ToUpper()).Result)
                    {
                        await roleManager.CreateAsync(new IdentityRole { Name = role });
                    }
                }

                var userManager = app.ApplicationServices.GetService<UserManager<ApplicationUser>>();
                foreach (var appUser in UserList.Instance.Users)
                {
                    var result = await userManager.CreateAsync(appUser, "Janeman@1783");
                    if (result.Succeeded)
                    {
                        await userManager.SetLockoutEnabledAsync(appUser, false);
                        await userManager.AddToRoleAsync(appUser, RoleList.Instance.Admin);
                    }
                }
                //context.SaveChanges();
            }
        }

        //public static void EnsureSocialAddressDataInserted(this UserDbContext context)
        //{

        //    if (context.AllMigrationsApplied())
        //    {
        //        if (!context.SocialAddress.Any())
        //        {
        //            context.SocialAddress.AddRange(
        //                    new SocialAddress { SocialName = SocialNames.FaceBook, PreUrl = "http://facebook.com/", PostLabel = "profile-or-page-url", PostUrl = "facebook", HelpUrl = "https://www.facebook.com/help/162586890471598", IconClass = "fa fa-facebook-square", Status = 1 },
        //                    new SocialAddress { SocialName = SocialNames.Twitter, PreUrl = "http://twitter.com/", PostLabel = "username", PostUrl = "twitter", HelpUrl = "https://support.twitter.com/articles/14609", IconClass = "fa fa-twitter-square", Status = 1 },
        //                    new SocialAddress { SocialName = SocialNames.YouTube, PreUrl = "http://youtube.com/", PostLabel = "custom-channel-url", PostUrl = "youtube", HelpUrl = "https://support.google.com/youtube/answer/2657968", IconClass = "fa fa-youtube-square", Status = 1 }
        //                );
        //        }

        //        context.SaveChanges();
        //    }
        //}

        //public static void EnsureCategoryInserted(this UserDbContext context)
        //{

        //    if (context.AllMigrationsApplied())
        //    {
        //        if (!context.JobCategory.Any())
        //        {
        //            var actor = context.JobCategory.Add(new JobCategory { CategoryName = "Actor", DisplayName = "Actor", CategoryDesc = "Actor Category", CategoryStatus = 1, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow }).Entity;
        //            context.JobSubCategory.AddRange(
        //                  new JobSubCategory
        //                  {
        //                      SubCategoryName = "Agencies",
        //                      DisplayName = "Agencies",
        //                      SubCategoryDesc = "Agencies",
        //                      SubCategoryStatus = 1,
        //                      SubCategoryType = "interest",
        //                      JobCategory = actor,
        //                      DttmCreated = DateTime.UtcNow,
        //                      DttmModified = DateTime.UtcNow
        //                  },
        //                  new JobSubCategory
        //                  {
        //                      SubCategoryName = "Entertainers",
        //                      DisplayName = "Entertainers",
        //                      SubCategoryDesc = "Entertainers",
        //                      SubCategoryStatus = 1,
        //                      SubCategoryType = "interest",
        //                      JobCategory = actor,
        //                      DttmCreated = DateTime.UtcNow,
        //                      DttmModified = DateTime.UtcNow
        //                  },
        //                  new JobSubCategory
        //                  {
        //                      SubCategoryName = "EventsPromotions",
        //                      DisplayName = "Events & Promotions",
        //                      SubCategoryDesc = "Events & Promotions",
        //                      SubCategoryStatus = 1,
        //                      SubCategoryType = "interest",
        //                      JobCategory = actor,
        //                      DttmCreated = DateTime.UtcNow,
        //                      DttmModified = DateTime.UtcNow
        //                  },
        //                  new JobSubCategory
        //                  {
        //                      SubCategoryName = "FeatureFilms",
        //                      DisplayName = "Feature Films",
        //                      SubCategoryDesc = "Feature Films",
        //                      SubCategoryStatus = 1,
        //                      SubCategoryType = "interest",
        //                      JobCategory = actor,
        //                      DttmCreated = DateTime.UtcNow,
        //                      DttmModified = DateTime.UtcNow
        //                  },
        //                  new JobSubCategory
        //                  {
        //                      SubCategoryName = "Musicvideos",
        //                      DisplayName = "Music videos",
        //                      SubCategoryDesc = "Music videos",
        //                      SubCategoryStatus = 1,
        //                      SubCategoryType = "interest",
        //                      JobCategory = actor,
        //                      DttmCreated = DateTime.UtcNow,
        //                      DttmModified = DateTime.UtcNow
        //                  },
        //                  new JobSubCategory
        //                  {
        //                      SubCategoryName = "Presenters",
        //                      DisplayName = "Presenters",
        //                      SubCategoryDesc = "Presenters",
        //                      SubCategoryStatus = 1,
        //                      SubCategoryType = "interest",
        //                      JobCategory = actor,
        //                      DttmCreated = DateTime.UtcNow,
        //                      DttmModified = DateTime.UtcNow
        //                  },
        //                  new JobSubCategory
        //                  {
        //                      SubCategoryName = "ShortFilms",
        //                      DisplayName = "Short Films",
        //                      SubCategoryDesc = "Short Films",
        //                      SubCategoryStatus = 1,
        //                      SubCategoryType = "interest",
        //                      JobCategory = actor,
        //                      DttmCreated = DateTime.UtcNow,
        //                      DttmModified = DateTime.UtcNow
        //                  },
        //                  new JobSubCategory
        //                  {
        //                      SubCategoryName = "TheatreMusicals",
        //                      DisplayName = "Theatre & Musicals",
        //                      SubCategoryDesc = "Theatre & Musicals",
        //                      SubCategoryStatus = 1,
        //                      SubCategoryType = "interest",
        //                      JobCategory = actor,
        //                      DttmCreated = DateTime.UtcNow,
        //                      DttmModified = DateTime.UtcNow
        //                  },
        //                  new JobSubCategory
        //                  {
        //                      SubCategoryName = "TVCommercials",
        //                      DisplayName = "TV Commercials",
        //                      SubCategoryDesc = "TV commercials",
        //                      SubCategoryStatus = 1,
        //                      SubCategoryType = "interest",
        //                      JobCategory = actor,
        //                      DttmCreated = DateTime.UtcNow,
        //                      DttmModified = DateTime.UtcNow
        //                  },
        //                  new JobSubCategory
        //                  {
        //                      SubCategoryName = "TVSeries",
        //                      DisplayName = "TV Series",
        //                      SubCategoryDesc = "TV Series",
        //                      SubCategoryStatus = 1,
        //                      SubCategoryType = "interest",
        //                      JobCategory = actor,
        //                      DttmCreated = DateTime.UtcNow,
        //                      DttmModified = DateTime.UtcNow
        //                  },
        //                  new JobSubCategory
        //                  {
        //                      SubCategoryName = "VoiceoverRadio",
        //                      DisplayName = "Voiceover & Radio",
        //                      SubCategoryDesc = "Voiceover & Radio",
        //                      SubCategoryStatus = 1,
        //                      SubCategoryType = "interest",
        //                      JobCategory = actor,
        //                      DttmCreated = DateTime.UtcNow,
        //                      DttmModified = DateTime.UtcNow
        //                  },
        //                  new JobSubCategory
        //                  {
        //                      SubCategoryName = "Web",
        //                      DisplayName = "Web",
        //                      SubCategoryDesc = "Web",
        //                      SubCategoryStatus = 1,
        //                      SubCategoryType = "interest",
        //                      JobCategory = actor,
        //                      DttmCreated = DateTime.UtcNow,
        //                      DttmModified = DateTime.UtcNow
        //                  },
        //                  new JobSubCategory
        //                  {
        //                      SubCategoryName = "Other",
        //                      DisplayName = "Other",
        //                      SubCategoryDesc = "Other",
        //                      SubCategoryStatus = 1,
        //                      SubCategoryType = "interest",
        //                      JobCategory = actor,
        //                      DttmCreated = DateTime.UtcNow,
        //                      DttmModified = DateTime.UtcNow
        //                  });

        //            var modal = context.JobCategory.Add(new JobCategory { CategoryName = "Modal", DisplayName = "Modal", CategoryDesc = "Modal Category", CategoryStatus = 1, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow }).Entity;
        //            context.JobSubCategory.AddRange(
        //                new JobSubCategory { SubCategoryName = "Agencies", DisplayName = "Agencies", SubCategoryDesc = "Agencies", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = modal, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //                new JobSubCategory { SubCategoryName = "Catwalk", DisplayName = "Catwalk", SubCategoryDesc = "Catwalk", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = modal, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //                new JobSubCategory { SubCategoryName = "CompetitionsPageants", DisplayName = "Competitions & Pageants", SubCategoryDesc = "Competitions and Pageants", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = modal, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //                new JobSubCategory { SubCategoryName = "EventsPromotions", DisplayName = "Events & Promotions", SubCategoryDesc = "Events and Promotions", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = modal, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //                new JobSubCategory { SubCategoryName = "Fitting", DisplayName = "Fitting", SubCategoryDesc = "Fitting", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = modal, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //                new JobSubCategory { SubCategoryName = "Hairmodels", DisplayName = "Hair models", SubCategoryDesc = "Hair models", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = modal, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //                new JobSubCategory { SubCategoryName = "Musicvideos", DisplayName = "Music videos", SubCategoryDesc = "Music videos", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = modal, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //                new JobSubCategory { SubCategoryName = "Presenters", DisplayName = "Presenters", SubCategoryDesc = "Presenters", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = modal, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //                new JobSubCategory { SubCategoryName = "Print", DisplayName = "Print", SubCategoryDesc = "Print", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = modal, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //                new JobSubCategory { SubCategoryName = "TimeforPrints", DisplayName = "Time for Prints", SubCategoryDesc = "Time for Prints", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = modal, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //                new JobSubCategory { SubCategoryName = "TVcommercials", DisplayName = "TV Commercials", SubCategoryDesc = "TV commercials", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = modal, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //                new JobSubCategory { SubCategoryName = "Other", DisplayName = "Other", SubCategoryDesc = "Other", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = modal, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow }
        //                );


        //            var musician = context.JobCategory.Add(new JobCategory { CategoryName = "Musician", DisplayName = "Musician", CategoryDesc = "Musician Category", CategoryStatus = 1, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow }).Entity;
        //            context.JobSubCategory.AddRange(
        //                new JobSubCategory { SubCategoryName = "Classical", DisplayName = "Classical", SubCategoryDesc = "Classical", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = musician, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //                new JobSubCategory { SubCategoryName = "Country", DisplayName = "Country", SubCategoryDesc = "Country", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = musician, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //                new JobSubCategory { SubCategoryName = "Electronic", DisplayName = "Electronic", SubCategoryDesc = "Electronic", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = musician, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //                new JobSubCategory { SubCategoryName = "Hiphop", DisplayName = "Hip-hop", SubCategoryDesc = "Hip-hop", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = musician, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //                new JobSubCategory { SubCategoryName = "Indie", DisplayName = "Indie", SubCategoryDesc = "Indie", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = musician, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //                new JobSubCategory { SubCategoryName = "Jazz", DisplayName = "Jazz", SubCategoryDesc = "Jazz", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = musician, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //                new JobSubCategory { SubCategoryName = "Metal", DisplayName = "Metal", SubCategoryDesc = "Metal", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = musician, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //                new JobSubCategory { SubCategoryName = "Pop", DisplayName = "Pop", SubCategoryDesc = "Pop", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = musician, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //                new JobSubCategory { SubCategoryName = "Rock", DisplayName = "Rock", SubCategoryDesc = "Rock", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = musician, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow }
        //            );

        //            var tvreality = context.JobCategory.Add(new JobCategory { CategoryName = "TVReality", DisplayName = "TV & Reality", CategoryDesc = "TV & Reality Category", CategoryStatus = 1, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow }).Entity;
        //            context.JobSubCategory.AddRange(
        //               new JobSubCategory { SubCategoryName = "Audiences", DisplayName = "Audiences", SubCategoryDesc = "Audiences", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = tvreality, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //               new JobSubCategory { SubCategoryName = "DocumentariesFactual", DisplayName = "Documentaries & Factual", SubCategoryDesc = "Documentaries and Factual", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = tvreality, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //               new JobSubCategory { SubCategoryName = "Gameshows", DisplayName = "Game shows", SubCategoryDesc = "Game shows", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = tvreality, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //               new JobSubCategory { SubCategoryName = "RealityTV", DisplayName = "Reality TV", SubCategoryDesc = "Reality TV", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = tvreality, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow }
        //            );

        //            var dancing = context.JobCategory.Add(new JobCategory { CategoryName = "Dancing", DisplayName = "Dancing", CategoryDesc = "Dancing Category", CategoryStatus = 1, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow }).Entity;
        //            context.JobSubCategory.AddRange(
        //              // Interest
        //              new JobSubCategory { SubCategoryName = "Audiences", DisplayName = "Audiences", SubCategoryDesc = "Audiences", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Choreographers", DisplayName = "Choreographers", SubCategoryDesc = "Choreographers", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Companies", DisplayName = "Companies", SubCategoryDesc = "Companies", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Competitions", DisplayName = "Competitions", SubCategoryDesc = "Competitions", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Liveperformance", DisplayName = "Live performance", SubCategoryDesc = "Live performance", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Musicvideos", DisplayName = "Music videos", SubCategoryDesc = "Music videos", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Photoshoots", DisplayName = "Photo shoots", SubCategoryDesc = "Photo shoots", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "TeachersInstructors", DisplayName = "Teachers / Instructors", SubCategoryDesc = "Teachers / Instructors", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "TVFilm", DisplayName = "TV & Film", SubCategoryDesc = "TV and Film", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Other", DisplayName = "Other", SubCategoryDesc = "Other", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },

        //              // Style
        //              new JobSubCategory { SubCategoryName = "Ballet", DisplayName = "Ballet", SubCategoryDesc = "Ballet", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Ballroom", DisplayName = "Ballroom", SubCategoryDesc = "Ballroom", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Bellydance", DisplayName = "Bellydance", SubCategoryDesc = "Bellydance", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Bollywood", DisplayName = "Bollywood", SubCategoryDesc = "Bollywood", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Breakdancing", DisplayName = "Breakdancing", SubCategoryDesc = "Breakdancing", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Contemporary", DisplayName = "Contemporary", SubCategoryDesc = "Contemporary", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Country", DisplayName = "Country", SubCategoryDesc = "Country", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Disco", DisplayName = "Disco", SubCategoryDesc = "Disco", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Folk", DisplayName = "Folk", SubCategoryDesc = "Folk", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "HipHop", DisplayName = "Hip Hop", SubCategoryDesc = "Hip Hop", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Jazz", DisplayName = "Jazz", SubCategoryDesc = "Jazz", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "LatinAmerican", DisplayName = "Latin American", SubCategoryDesc = "Latin American", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "RockRoll", DisplayName = "Rock & Roll", SubCategoryDesc = "Rock & Roll", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Salsa", DisplayName = "Salsa", SubCategoryDesc = "Salsa", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Swing", DisplayName = "Swing", SubCategoryDesc = "Swing", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Tango", DisplayName = "Tango", SubCategoryDesc = "Tango", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Tap", DisplayName = "Tap", SubCategoryDesc = "Tap", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Others", DisplayName = "Others", SubCategoryDesc = "Others", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow }
        //           //new JobSubCategory { SubCategoryName = "Audiences", DisplayName = "Audiences", SubCategoryDesc = "Audiences", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //           // new JobSubCategory { SubCategoryName = "Audiences", DisplayName = "Audiences", SubCategoryDesc = "Audiences", SubCategoryStatus = 1, SubCategoryType = "style", JobCategory = dancing, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow }
        //           );

        //            var filmstagecrew = context.JobCategory.Add(new JobCategory { CategoryName = "FilmStageCrew", DisplayName = "Film & Stage Crew", CategoryDesc = "Film & Stage Crew Category", CategoryStatus = 1, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow }).Entity;
        //            context.JobSubCategory.AddRange(
        //               new JobSubCategory { SubCategoryName = "ArtDepartment", DisplayName = "Art Department", SubCategoryDesc = "Art Department", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = filmstagecrew, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //               new JobSubCategory { SubCategoryName = "Camera", DisplayName = "Camera", SubCategoryDesc = "Camera", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = filmstagecrew, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //               new JobSubCategory { SubCategoryName = "Competitions", DisplayName = "Competitions", SubCategoryDesc = "Competitions", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = filmstagecrew, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //               new JobSubCategory { SubCategoryName = "Festivals", DisplayName = "Festivals", SubCategoryDesc = "Festivals", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = filmstagecrew, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //               new JobSubCategory { SubCategoryName = "Costume", DisplayName = "Costume", SubCategoryDesc = "Costume", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = filmstagecrew, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //               new JobSubCategory { SubCategoryName = "Editing", DisplayName = "Editing", SubCategoryDesc = "Editing", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = filmstagecrew, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //               new JobSubCategory { SubCategoryName = "Grip", DisplayName = "Grip", SubCategoryDesc = "Grip", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = filmstagecrew, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //               new JobSubCategory { SubCategoryName = "Lighting", DisplayName = "Lighting", SubCategoryDesc = "Lighting", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = filmstagecrew, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //               new JobSubCategory { SubCategoryName = "SoundMusic", DisplayName = "Sound & Music", SubCategoryDesc = "Sound & Music", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = filmstagecrew, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //               new JobSubCategory { SubCategoryName = "Other", DisplayName = "Other", SubCategoryDesc = "Other", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = filmstagecrew, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow }
        //            );

        //            var stylist = context.JobCategory.Add(new JobCategory { CategoryName = "Stylist", DisplayName = "Stylist", CategoryDesc = "Stylist Category", CategoryStatus = 1, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow }).Entity;
        //            context.JobSubCategory.AddRange(
        //              new JobSubCategory { SubCategoryName = "HairStylists", DisplayName = "Hair Stylists", SubCategoryDesc = "Hair Stylists", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = stylist, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "MakeupArtists", DisplayName = "Makeup Artists", SubCategoryDesc = "Makeup Artists", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = stylist, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Stylists", DisplayName = "Stylists", SubCategoryDesc = "Stylists", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = stylist, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow },
        //              new JobSubCategory { SubCategoryName = "Other", DisplayName = "Other", SubCategoryDesc = "Other", SubCategoryStatus = 1, SubCategoryType = "interest", JobCategory = stylist, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow }
        //            );

        //            var photographer = context.JobCategory.Add(new JobCategory { CategoryName = "Photographer", DisplayName = "Photographer", CategoryDesc = "Photographer Category", CategoryStatus = 1, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow }).Entity;
        //            var magazine = context.JobCategory.Add(new JobCategory { CategoryName = "Magazine", DisplayName = "Magazine", CategoryDesc = "Magazine Category", CategoryStatus = 1, DttmCreated = DateTime.UtcNow, DttmModified = DateTime.UtcNow }).Entity;


        //            context.SaveChanges();

        //        }

        //    }
        //}

        //public static void EnsureLanguageAndAscentInserted(this UserDbContext context)
        //{

        //    if (context.AllMigrationsApplied())
        //    {
        //        if (!context.Languages.Any())
        //        {

        //            context.Languages.AddRange(
        //                new Languages { Code = "", Language = "English", Status = 1 },
        //                new Languages { Code = "", Language = "Hindi", Status = 1 },
        //                new Languages { Code = "", Language = "Marathi", Status = 1 }
        //                );
        //        }

        //        if (!context.Accents.Any())
        //        {
        //            context.Accents.AddRange(
        //                new Accents { Accent = "Magahi", Status = 1 },
        //                new Accents { Accent = "Bhojpuri", Status = 1 },
        //                new Accents { Accent = "French", Status = 1 },
        //                new Accents { Accent = "Russian", Status = 1 }
        //                );
        //        }

        //        context.SaveChanges();
        //    }
        //}
    }
}
