using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Star4Cast.Data.DBContext.ProfileDb;

namespace Star4Cast.Migrations.ProfileDb
{
    [DbContext(typeof(ProfileDbContext))]
    partial class ProfileDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.0-rtm-21431")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Star4Cast.Models.Common.SocialAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HelpUrl")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("IconClass")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("PostLabel")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("PostUrl")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("PreUrl")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("SocialName")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("SocialAddress");
                });

            modelBuilder.Entity("Star4Cast.Models.Profile.Accents", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Accent")
                        .HasAnnotation("MaxLength", 150);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Accents");
                });

            modelBuilder.Entity("Star4Cast.Models.Profile.JobCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CategoryDesc")
                        .HasAnnotation("MaxLength", 250);

                    b.Property<string>("CategoryName")
                        .HasAnnotation("MaxLength", 150);

                    b.Property<int>("CategoryStatus");

                    b.Property<string>("DisplayName")
                        .HasAnnotation("MaxLength", 150);

                    b.Property<DateTime>("DttmCreated");

                    b.Property<DateTime>("DttmModified");

                    b.HasKey("Id");

                    b.ToTable("JobCategory");
                });

            modelBuilder.Entity("Star4Cast.Models.Profile.JobSubCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DisplayName")
                        .HasAnnotation("MaxLength", 150);

                    b.Property<DateTime>("DttmCreated");

                    b.Property<DateTime>("DttmModified");

                    b.Property<Guid>("JobCategoryId");

                    b.Property<string>("SubCategoryDesc")
                        .HasAnnotation("MaxLength", 250);

                    b.Property<string>("SubCategoryName")
                        .HasAnnotation("MaxLength", 150);

                    b.Property<int>("SubCategoryStatus");

                    b.Property<string>("SubCategoryType")
                        .HasAnnotation("MaxLength", 150);

                    b.HasKey("Id");

                    b.HasIndex("JobCategoryId");

                    b.ToTable("JobSubCategory");
                });

            modelBuilder.Entity("Star4Cast.Models.Profile.Languages", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code")
                        .HasAnnotation("MaxLength", 50);

                    b.Property<string>("Language")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Languages");
                });

            modelBuilder.Entity("Star4Cast.Models.Profile.PhysicalAppearance", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BodyType");

                    b.Property<int>("Chest");

                    b.Property<DateTime>("DttmCreted");

                    b.Property<DateTime>("DttmModified");

                    b.Property<int>("EyeColor");

                    b.Property<int>("HairColor");

                    b.Property<int>("HairLength");

                    b.Property<int>("HairType");

                    b.Property<int>("Height");

                    b.Property<int>("SkinColor");

                    b.Property<string>("UserId");

                    b.Property<int>("Weight");

                    b.Property<int>("West");

                    b.HasKey("Id");

                    b.ToTable("PhysicalAppearances");
                });

            modelBuilder.Entity("Star4Cast.Models.Profile.UserAsents", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("AccentsId");

                    b.Property<DateTime>("DttmCreted");

                    b.Property<DateTime>("DttmModified");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AccentsId");

                    b.ToTable("UserAsents");
                });

            modelBuilder.Entity("Star4Cast.Models.Profile.UserDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("About")
                        .HasAnnotation("MaxLength", 1500);

                    b.Property<int>("Age");

                    b.Property<int>("BloodGroup");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("Disability");

                    b.Property<DateTime>("DttmCreted");

                    b.Property<DateTime>("DttmModified");

                    b.Property<string>("HealthInfo")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<int>("MaritalStatus");

                    b.Property<string>("MotherTongue")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("Nickname")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("ProfileAddress")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<string>("Religion")
                        .HasAnnotation("MaxLength", 100);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.ToTable("UserDetails");
                });

            modelBuilder.Entity("Star4Cast.Models.Profile.UserJobCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DttmCreted");

                    b.Property<DateTime>("DttmModified");

                    b.Property<Guid>("JobCategoryId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("JobCategoryId");

                    b.ToTable("UserJobCategory");
                });

            modelBuilder.Entity("Star4Cast.Models.Profile.UserJobSubCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DttmCreted");

                    b.Property<DateTime>("DttmModified");

                    b.Property<Guid>("JobSubCategoryId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("JobSubCategoryId");

                    b.ToTable("UserJobSubCategory");
                });

            modelBuilder.Entity("Star4Cast.Models.Profile.UserLanguage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DttmCreted");

                    b.Property<DateTime>("DttmModified");

                    b.Property<Guid>("LanguagesId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("LanguagesId");

                    b.ToTable("UserLanguage");
                });

            modelBuilder.Entity("Star4Cast.Models.Profile.UserSocialAddress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DttmCreted");

                    b.Property<DateTime>("DttmModified");

                    b.Property<Guid>("SocialAddressId");

                    b.Property<string>("SocialUserName")
                        .HasAnnotation("MaxLength", 200);

                    b.Property<int>("Status");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SocialAddressId");

                    b.ToTable("UserSocialAddress");
                });

            modelBuilder.Entity("Star4Cast.Models.Profile.JobSubCategory", b =>
                {
                    b.HasOne("Star4Cast.Models.Profile.JobCategory", "JobCategory")
                        .WithMany("SubCategoryList")
                        .HasForeignKey("JobCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Star4Cast.Models.Profile.UserAsents", b =>
                {
                    b.HasOne("Star4Cast.Models.Profile.Accents", "Accents")
                        .WithMany("UserAsentsList")
                        .HasForeignKey("AccentsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Star4Cast.Models.Profile.UserJobCategory", b =>
                {
                    b.HasOne("Star4Cast.Models.Profile.JobCategory", "JobCategory")
                        .WithMany("UserJobCategoryList")
                        .HasForeignKey("JobCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Star4Cast.Models.Profile.UserJobSubCategory", b =>
                {
                    b.HasOne("Star4Cast.Models.Profile.JobSubCategory", "JobSubCategory")
                        .WithMany("UserJobSubCategoryList")
                        .HasForeignKey("JobSubCategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Star4Cast.Models.Profile.UserLanguage", b =>
                {
                    b.HasOne("Star4Cast.Models.Profile.Languages", "Languages")
                        .WithMany("UserLanguageList")
                        .HasForeignKey("LanguagesId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Star4Cast.Models.Profile.UserSocialAddress", b =>
                {
                    b.HasOne("Star4Cast.Models.Common.SocialAddress", "SocialAddress")
                        .WithMany("UserSocialAddressList")
                        .HasForeignKey("SocialAddressId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
