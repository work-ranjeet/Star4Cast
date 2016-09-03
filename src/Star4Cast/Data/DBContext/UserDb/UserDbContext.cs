using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Star4Cast.Models.Identity;

namespace Star4Cast.Data.DBContext.UserDb
{
    public class UserDbContext : IdentityDbContext<ApplicationUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserAddress> UserAddresses { get; set; }
       // public DbSet<Organization> Organization { get; set; }

        //public DbSet<JobCategory> JobCategory { get; set; }
        //public DbSet<UserJobCategory> UserJobCategory { get; set; }

        //public DbSet<JobSubCategory> JobSubCategory { get; set; }
        //public DbSet<UserJobSubCategory> UserJobSubCategory { get; set; }

        //public DbSet<Languages> Languages { get; set; }
        //public DbSet<UserLanguage> UserLanguage { get; set; }

        //public DbSet<Accents> Accents { get; set; }
        //public DbSet<UserAsents> UserAsents { get; set; }

        //public DbSet<UserDetail> UserDetails { get; set; }
        //public DbSet<PhysicalAppearance> PhysicalAppearances { get; set; }

        //public DbSet<SocialAddress> SocialAddress { get; set; }
        //public DbSet<UserSocialAddress> UserSocialAddress { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // This needs to go before the other rules!
            builder.Entity<ApplicationUser>().ToTable("Users");
            builder.Entity<IdentityRole>().ToTable("Roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

            builder.Entity<UserAddress>().ToTable("UserAddresses");
            builder.Entity<UserAddress>().ConfigureAddress();
            builder.Entity<UserAddress>().HasOne<ApplicationUser>(c => c.User).WithMany(m => m.Addresses).HasForeignKey(v => v.UserId);


            //builder.Entity<Organization>().HasKey(c => c.Id);

            // Profile
            //builder.Entity<JobCategory>().HasKey(pk => pk.Id);
            //builder.Entity<JobSubCategory>().HasKey(pk => pk.Id);
            //builder.Entity<JobSubCategory>().HasOne<JobCategory>(c => c.JobCategory).WithMany(m => m.SubCategoryList).HasForeignKey(v => v.JobCategoryId);

            //builder.Entity<Languages>().HasKey(pk => pk.Id);
            //builder.Entity<UserLanguage>().HasKey(pk => pk.Id);
            //builder.Entity<UserLanguage>().HasOne<Languages>(c => c.Languages).WithMany(m => m.UserLanguageList).HasForeignKey(v => v.LanguagesId);
            //builder.Entity<UserLanguage>().HasOne<ApplicationUser>(c => c.User).WithMany(m => m.UserLanguageList).HasForeignKey(v => v.UserId);

            //builder.Entity<Accents>().HasKey(pk => pk.Id);
            //builder.Entity<UserAsents>().HasKey(pk => pk.Id);
            //builder.Entity<UserAsents>().HasOne<Accents>(c => c.Accents).WithMany(m => m.UserAsentsList).HasForeignKey(v => v.AccentsId);
            //builder.Entity<UserAsents>().HasOne<ApplicationUser>(c => c.User).WithMany(m => m.UserAsentsList).HasForeignKey(v => v.UserId);


            //builder.Entity<UserJobCategory>().HasKey(pk => pk.Id);
            //builder.Entity<UserJobCategory>().HasOne<JobCategory>(c => c.JobCategory).WithMany(m => m.UserJobCategoryList).HasForeignKey(v => v.JobCategoryId);
            //builder.Entity<UserJobCategory>().HasOne<ApplicationUser>(c => c.User).WithMany(m => m.UserJobCategoryList).HasForeignKey(v => v.UserId);

            //builder.Entity<UserJobSubCategory>().HasKey(pk => pk.Id);
            //builder.Entity<UserJobSubCategory>().HasOne<JobSubCategory>(c => c.JobSubCategory).WithMany(m => m.UserJobSubCategoryList).HasForeignKey(v => v.JobSubCategoryId);
            //builder.Entity<UserJobSubCategory>().HasOne<ApplicationUser>(c => c.User).WithMany(m => m.UserJobSubCategoryList).HasForeignKey(v => v.UserId);

            //builder.Entity<PhysicalAppearance>().HasKey(pk => pk.Id);
            ////builder.Entity<PhysicalAppearance>().ConfigurePhysicalAppearance();
            //builder.Entity<PhysicalAppearance>().HasOne<ApplicationUser>(fk => fk.User).WithMany(pk => pk.PhysicalAppearanceList).HasForeignKey(fk => fk.UserId);

            //builder.Entity<UserDetail>().HasKey(pk => pk.Id);
            ////builder.Entity<UserDetail>().ConfigureUserDetail();
            //builder.Entity<UserDetail>().HasOne<ApplicationUser>(fk => fk.User).WithMany(pk => pk.UserDetailList).HasForeignKey(fk => fk.UserId);

            //builder.Entity<SocialAddress>().HasKey(pk => pk.Id);
            //builder.Entity<UserSocialAddress>().HasKey(pk => pk.Id);
            //builder.Entity<UserSocialAddress>().HasOne<SocialAddress>(sa => sa.SocialAddress).WithMany(m => m.UserSocialAddressList).HasForeignKey(fk => fk.SocialAddressId);
            //builder.Entity<UserSocialAddress>().HasOne<ApplicationUser>(c => c.User).WithMany(m => m.UserSocialAddressList).HasForeignKey(v => v.UserId);

        }
    }

}
