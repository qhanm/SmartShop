using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SmartShop.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppRoleClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserClaims", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppUserLogins",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    ProviderKey = table.Column<string>(nullable: true),
                    ProviderDisplayName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserLogins", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "AppUserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserRoles", x => new { x.RoleId, x.UserId });
                });

            migrationBuilder.CreateTable(
                name: "AppUserTokens",
                columns: table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUserTokens", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "QHN_AppRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Description = table.Column<string>(maxLength: 150, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    Temp = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QHN_AppRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QHN_AppUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FullName = table.Column<string>(maxLength: 150, nullable: true),
                    Avatar = table.Column<string>(maxLength: 150, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    Temp = table.Column<string>(maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QHN_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QHN_Colors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Code = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QHN_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QHN_Images",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Size = table.Column<long>(nullable: false),
                    Url = table.Column<string>(maxLength: 250, nullable: true),
                    Alt = table.Column<string>(maxLength: 250, nullable: true),
                    Description = table.Column<string>(maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QHN_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QHN_LoggerActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 20, nullable: true),
                    Controller = table.Column<string>(maxLength: 30, nullable: true),
                    Action = table.Column<string>(maxLength: 30, nullable: true),
                    Message = table.Column<string>(maxLength: 500, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QHN_LoggerActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QHN_SettingMetaDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MetaKey = table.Column<string>(nullable: true),
                    MetaValue = table.Column<string>(nullable: false),
                    MetaType = table.Column<string>(nullable: true),
                    Setting1 = table.Column<string>(nullable: true),
                    Setting2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QHN_SettingMetaDatas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "QHN_Permissons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Create = table.Column<bool>(nullable: false),
                    Read = table.Column<bool>(nullable: false),
                    Delete = table.Column<bool>(nullable: false),
                    Update = table.Column<bool>(nullable: false),
                    Approved = table.Column<bool>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    FunctionId = table.Column<string>(nullable: false),
                    Temp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QHN_Permissons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QHN_Permissons_QHN_AppRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "QHN_AppRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QHN_LoggerDatas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<Guid>(nullable: false),
                    QHN_AppUserId = table.Column<Guid>(nullable: true),
                    CodeId = table.Column<string>(maxLength: 12, nullable: true),
                    Action = table.Column<string>(maxLength: 20, nullable: true),
                    Message = table.Column<string>(maxLength: 300, nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QHN_LoggerDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QHN_LoggerDatas_QHN_AppUsers_QHN_AppUserId",
                        column: x => x.QHN_AppUserId,
                        principalTable: "QHN_AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QHN_ProductCategories",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    ImageId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(maxLength: 300, nullable: true),
                    QHN_ImageId = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    SeoTitle = table.Column<string>(nullable: true),
                    SeoDescription = table.Column<string>(nullable: true),
                    SeoKeyword = table.Column<string>(nullable: true),
                    SeoAlias = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QHN_ProductCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QHN_ProductCategories_QHN_Images_QHN_ImageId",
                        column: x => x.QHN_ImageId,
                        principalTable: "QHN_Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QHN_Functions",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 150, nullable: true),
                    Url = table.Column<string>(maxLength: 150, nullable: true),
                    ParentId = table.Column<string>(maxLength: 100, nullable: true),
                    IconCss = table.Column<string>(nullable: true),
                    SortOrder = table.Column<int>(nullable: false),
                    IsRole = table.Column<bool>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    FunctionId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QHN_Functions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QHN_Functions_QHN_Permissons_FunctionId",
                        column: x => x.FunctionId,
                        principalTable: "QHN_Permissons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QHN_Products",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductCategoryId = table.Column<int>(nullable: false),
                    ProductCateogryId = table.Column<int>(nullable: true),
                    Name = table.Column<string>(maxLength: 255, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PromotionPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    OriginalPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Content = table.Column<string>(nullable: true),
                    HomeFlag = table.Column<bool>(nullable: false),
                    HotFlag = table.Column<bool>(nullable: false),
                    IsNew = table.Column<bool>(nullable: false),
                    IsSale = table.Column<bool>(nullable: false),
                    ViewCount = table.Column<int>(nullable: false),
                    Rating = table.Column<float>(nullable: false),
                    SeoTitle = table.Column<string>(maxLength: 255, nullable: true),
                    SeoDescription = table.Column<string>(nullable: true),
                    SeoKeyword = table.Column<string>(nullable: true),
                    SeoAlias = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    IsDelete = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QHN_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QHN_Products_QHN_ProductCategories_ProductCateogryId",
                        column: x => x.ProductCateogryId,
                        principalTable: "QHN_ProductCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QHN_ProductColors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    QHN_ProductId = table.Column<int>(nullable: true),
                    QHN_ColorId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QHN_ProductColors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QHN_ProductColors_QHN_Colors_QHN_ColorId",
                        column: x => x.QHN_ColorId,
                        principalTable: "QHN_Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QHN_ProductColors_QHN_Products_QHN_ProductId",
                        column: x => x.QHN_ProductId,
                        principalTable: "QHN_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QHN_ProductComments",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductId = table.Column<int>(nullable: false),
                    QHN_ProductId = table.Column<int>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateUpdated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QHN_ProductComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QHN_ProductComments_QHN_Products_QHN_ProductId",
                        column: x => x.QHN_ProductId,
                        principalTable: "QHN_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QHN_ProductImages",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageId = table.Column<int>(nullable: false),
                    ProductId = table.Column<int>(nullable: false),
                    QHN_ProductId = table.Column<int>(nullable: true),
                    QHN_ImageId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QHN_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QHN_ProductImages_QHN_Images_QHN_ImageId",
                        column: x => x.QHN_ImageId,
                        principalTable: "QHN_Images",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_QHN_ProductImages_QHN_Products_QHN_ProductId",
                        column: x => x.QHN_ProductId,
                        principalTable: "QHN_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "QHN_ProductTag",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TagName = table.Column<string>(nullable: true),
                    ProductId = table.Column<int>(nullable: false),
                    QHN_ProductId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QHN_ProductTag", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QHN_ProductTag_QHN_Products_QHN_ProductId",
                        column: x => x.QHN_ProductId,
                        principalTable: "QHN_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QHN_Functions_FunctionId",
                table: "QHN_Functions",
                column: "FunctionId");

            migrationBuilder.CreateIndex(
                name: "IX_QHN_LoggerDatas_QHN_AppUserId",
                table: "QHN_LoggerDatas",
                column: "QHN_AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_QHN_Permissons_RoleId",
                table: "QHN_Permissons",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_QHN_ProductCategories_QHN_ImageId",
                table: "QHN_ProductCategories",
                column: "QHN_ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_QHN_ProductColors_QHN_ColorId",
                table: "QHN_ProductColors",
                column: "QHN_ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_QHN_ProductColors_QHN_ProductId",
                table: "QHN_ProductColors",
                column: "QHN_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_QHN_ProductComments_QHN_ProductId",
                table: "QHN_ProductComments",
                column: "QHN_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_QHN_ProductImages_QHN_ImageId",
                table: "QHN_ProductImages",
                column: "QHN_ImageId");

            migrationBuilder.CreateIndex(
                name: "IX_QHN_ProductImages_QHN_ProductId",
                table: "QHN_ProductImages",
                column: "QHN_ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_QHN_Products_ProductCateogryId",
                table: "QHN_Products",
                column: "ProductCateogryId");

            migrationBuilder.CreateIndex(
                name: "IX_QHN_ProductTag_QHN_ProductId",
                table: "QHN_ProductTag",
                column: "QHN_ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AppRoleClaims");

            migrationBuilder.DropTable(
                name: "AppUserClaims");

            migrationBuilder.DropTable(
                name: "AppUserLogins");

            migrationBuilder.DropTable(
                name: "AppUserRoles");

            migrationBuilder.DropTable(
                name: "AppUserTokens");

            migrationBuilder.DropTable(
                name: "QHN_Functions");

            migrationBuilder.DropTable(
                name: "QHN_LoggerActions");

            migrationBuilder.DropTable(
                name: "QHN_LoggerDatas");

            migrationBuilder.DropTable(
                name: "QHN_ProductColors");

            migrationBuilder.DropTable(
                name: "QHN_ProductComments");

            migrationBuilder.DropTable(
                name: "QHN_ProductImages");

            migrationBuilder.DropTable(
                name: "QHN_ProductTag");

            migrationBuilder.DropTable(
                name: "QHN_SettingMetaDatas");

            migrationBuilder.DropTable(
                name: "QHN_Permissons");

            migrationBuilder.DropTable(
                name: "QHN_AppUsers");

            migrationBuilder.DropTable(
                name: "QHN_Colors");

            migrationBuilder.DropTable(
                name: "QHN_Products");

            migrationBuilder.DropTable(
                name: "QHN_AppRoles");

            migrationBuilder.DropTable(
                name: "QHN_ProductCategories");

            migrationBuilder.DropTable(
                name: "QHN_Images");
        }
    }
}
