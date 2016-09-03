using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Star4Cast.Migrations.ProfileDb
{
    public partial class ProfileDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    HelpUrl = table.Column<string>(maxLength: 200, nullable: true),
                    IconClass = table.Column<string>(maxLength: 100, nullable: true),
                    PostLabel = table.Column<string>(maxLength: 200, nullable: true),
                    PostUrl = table.Column<string>(maxLength: 200, nullable: true),
                    PreUrl = table.Column<string>(maxLength: 200, nullable: true),
                    SocialName = table.Column<string>(maxLength: 200, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialAddress", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Accent = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accents", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CategoryDesc = table.Column<string>(maxLength: 250, nullable: true),
                    CategoryName = table.Column<string>(maxLength: 150, nullable: true),
                    CategoryStatus = table.Column<int>(nullable: false),
                    DisplayName = table.Column<string>(maxLength: 150, nullable: true),
                    DttmCreated = table.Column<DateTime>(nullable: false),
                    DttmModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Languages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(maxLength: 50, nullable: true),
                    Language = table.Column<string>(maxLength: 100, nullable: true),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Languages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PhysicalAppearances",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    BodyType = table.Column<int>(nullable: false),
                    Chest = table.Column<int>(nullable: false),
                    DttmCreted = table.Column<DateTime>(nullable: false),
                    DttmModified = table.Column<DateTime>(nullable: false),
                    EyeColor = table.Column<int>(nullable: false),
                    HairColor = table.Column<int>(nullable: false),
                    HairLength = table.Column<int>(nullable: false),
                    HairType = table.Column<int>(nullable: false),
                    Height = table.Column<int>(nullable: false),
                    SkinColor = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Weight = table.Column<int>(nullable: false),
                    West = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhysicalAppearances", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserDetails",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    About = table.Column<string>(maxLength: 1500, nullable: true),
                    Age = table.Column<int>(nullable: false),
                    BloodGroup = table.Column<int>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    Disability = table.Column<string>(nullable: true),
                    DttmCreted = table.Column<DateTime>(nullable: false),
                    DttmModified = table.Column<DateTime>(nullable: false),
                    HealthInfo = table.Column<string>(maxLength: 200, nullable: true),
                    MaritalStatus = table.Column<int>(nullable: false),
                    MotherTongue = table.Column<string>(maxLength: 100, nullable: true),
                    Nickname = table.Column<string>(maxLength: 200, nullable: true),
                    ProfileAddress = table.Column<string>(maxLength: 200, nullable: true),
                    Religion = table.Column<string>(maxLength: 100, nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDetails", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserSocialAddress",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DttmCreted = table.Column<DateTime>(nullable: false),
                    DttmModified = table.Column<DateTime>(nullable: false),
                    SocialAddressId = table.Column<Guid>(nullable: false),
                    SocialUserName = table.Column<string>(maxLength: 200, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserSocialAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserSocialAddress_SocialAddress_SocialAddressId",
                        column: x => x.SocialAddressId,
                        principalTable: "SocialAddress",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserAsents",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AccentsId = table.Column<Guid>(nullable: false),
                    DttmCreted = table.Column<DateTime>(nullable: false),
                    DttmModified = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserAsents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserAsents_Accents_AccentsId",
                        column: x => x.AccentsId,
                        principalTable: "Accents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobSubCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DisplayName = table.Column<string>(maxLength: 150, nullable: true),
                    DttmCreated = table.Column<DateTime>(nullable: false),
                    DttmModified = table.Column<DateTime>(nullable: false),
                    JobCategoryId = table.Column<Guid>(nullable: false),
                    SubCategoryDesc = table.Column<string>(maxLength: 250, nullable: true),
                    SubCategoryName = table.Column<string>(maxLength: 150, nullable: true),
                    SubCategoryStatus = table.Column<int>(nullable: false),
                    SubCategoryType = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobSubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobSubCategory_JobCategory_JobCategoryId",
                        column: x => x.JobCategoryId,
                        principalTable: "JobCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserJobCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DttmCreted = table.Column<DateTime>(nullable: false),
                    DttmModified = table.Column<DateTime>(nullable: false),
                    JobCategoryId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJobCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserJobCategory_JobCategory_JobCategoryId",
                        column: x => x.JobCategoryId,
                        principalTable: "JobCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLanguage",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DttmCreted = table.Column<DateTime>(nullable: false),
                    DttmModified = table.Column<DateTime>(nullable: false),
                    LanguagesId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLanguage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLanguage_Languages_LanguagesId",
                        column: x => x.LanguagesId,
                        principalTable: "Languages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserJobSubCategory",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DttmCreted = table.Column<DateTime>(nullable: false),
                    DttmModified = table.Column<DateTime>(nullable: false),
                    JobSubCategoryId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserJobSubCategory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserJobSubCategory_JobSubCategory_JobSubCategoryId",
                        column: x => x.JobSubCategoryId,
                        principalTable: "JobSubCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobSubCategory_JobCategoryId",
                table: "JobSubCategory",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserAsents_AccentsId",
                table: "UserAsents",
                column: "AccentsId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJobCategory_JobCategoryId",
                table: "UserJobCategory",
                column: "JobCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserJobSubCategory_JobSubCategoryId",
                table: "UserJobSubCategory",
                column: "JobSubCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLanguage_LanguagesId",
                table: "UserLanguage",
                column: "LanguagesId");

            migrationBuilder.CreateIndex(
                name: "IX_UserSocialAddress_SocialAddressId",
                table: "UserSocialAddress",
                column: "SocialAddressId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PhysicalAppearances");

            migrationBuilder.DropTable(
                name: "UserAsents");

            migrationBuilder.DropTable(
                name: "UserDetails");

            migrationBuilder.DropTable(
                name: "UserJobCategory");

            migrationBuilder.DropTable(
                name: "UserJobSubCategory");

            migrationBuilder.DropTable(
                name: "UserLanguage");

            migrationBuilder.DropTable(
                name: "UserSocialAddress");

            migrationBuilder.DropTable(
                name: "Accents");

            migrationBuilder.DropTable(
                name: "JobSubCategory");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "SocialAddress");

            migrationBuilder.DropTable(
                name: "JobCategory");
        }
    }
}
