using Microsoft.AspNetCore.Identity;
using SmartShop.App.ModelEntity.Entities;
using SmartShop.App.ModelEntity.Enum;
using SmartShop.Extensions.Constant;
using SmartShop.Extensions.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartShop.App.ModelEntity
{
    public class Seeder
    {
		public static void SeederData(AppDbContext appDbContext)
		{
			using(var transaction = appDbContext.Database.BeginTransaction())
            {
                try
                {
                    appDbContext.Database.EnsureCreated();

                    QHN_AppUser appUser = new QHN_AppUser();

                    if (appDbContext.AppUsers.Count() == 0)
                    {
                        PasswordHasher<string> passwordHasher = new PasswordHasher<string>();

                        appUser.FullName = "Quach Hoai Nam";
                        appUser.UserName = "qhnam.67";
                        appUser.PasswordHash = passwordHasher.HashPassword(appUser.UserName, "631996");
                        appUser.NormalizedEmail = "QHNAM.67@GMAIL.COM";
                        appUser.NormalizedUserName = "QHNAM.67";
                        appUser.Email = "qhnam.67@gmail.com";
                        appUser.SecurityStamp = "123abc";
                        appUser.DateCreated = DateTime.Now;
                        appUser.DateUpdated = DateTime.Now;
                        appUser.PhoneNumber = "0123456789";
                        appUser.PhoneNumberConfirmed = true;
                        appUser.Status = Status.Active;

                        appDbContext.AppUsers.Add(appUser);

                    }

                    QHN_AppRole appRole = new QHN_AppRole();

                    if (appDbContext.AppRoles.Count() == 0)
                    {
                        appRole.Name = "SuperAdmin";
                        appRole.Description = "This is super admin";
                        appRole.Status = Status.Active;
                        appDbContext.AppRoles.Add(appRole);
                    }

                    if (appDbContext.UserRoles.Count() == 0)
                    {
                        appDbContext.AppUserRoles.Add(new QHN_AppUserRole()
                        {
                            UserId = appUser.Id,
                            RoleId = appRole.Id
                        });
                    }

                    if(appDbContext.Functions.Count() == 0)
                    {
                        appDbContext.Functions.AddRange(new List<QHN_Function>()
                        {
                            new QHN_Function() { Id = "DASHBOARD", Name = "Dashboard", IsRole = false, SortOrder = 1, Status = Status.Active, Url = "/admin", IconCss = "fa fa-home", ParentId = null},

                            // Media function
                            new QHN_Function() { Id = "MEDIA", Name = "Media", IsRole = false, SortOrder = 2, Status = Status.Active, Url = "#", IconCss = "fa fa-cloud-upload", ParentId = null},
                            new QHN_Function() { Id = "MEDIA_NEW", Name = "Upload", IsRole = false, SortOrder = 2, Status = Status.Active, Url = "/admin/media/upload", IconCss = "fa fa-upload", ParentId = "MEDIA"},
                            new QHN_Function() { Id = "MEDIA_LIST", Name = "List Media", IsRole = false, SortOrder = 2, Status = Status.Active, Url = "/admin/media", IconCss = "fa fa-picture-o", ParentId = "MEDIA"},
                        
                            //Product function
                            new QHN_Function() { Id = "PRODUCT", Name = "Product", IsRole = false, SortOrder = 3, Status = Status.Active, Url = "#", IconCss = "fa fa-database", ParentId = null},
                            new QHN_Function() { Id = "PRODUCT_NEW", Name = "Add New", IsRole = false, SortOrder = 3, Status = Status.Active, Url = "/admin/product/add", IconCss = "fa fa-plus-square-o", ParentId = "PRODUCT"},
                            new QHN_Function() { Id = "PRODUCT_LIST", Name = "List Product", IsRole = false, SortOrder = 3, Status = Status.Active, Url = "/admin/product", IconCss = "fa fa-reorder", ParentId = "PRODUCT"},
                            new QHN_Function() { Id = "PRODUCT_COLOR", Name = "Product Color", IsRole = false, SortOrder = 3, Status = Status.Active, Url = "admin/product/color", IconCss = "fa fa-tachometer", ParentId = "PRODUCT"},
                            new QHN_Function() { Id = "PRODUCT_COMMENT", Name = "Comment", IsRole = false, SortOrder = 3, Status = Status.Active, Url = "admin/product/comment", IconCss = "fa fa-group", ParentId = "PRODUCT"},
                        
                            // Product Category function
                            new QHN_Function() { Id = "CATEGORY", Name = "Category", IsRole = false, SortOrder = 4, Status = Status.Active, Url = "#", IconCss = "fa fa-cloud-upload", ParentId = null },
                            new QHN_Function() { Id = "CATEGORY_NEW", Name = "Add New", IsRole = false, SortOrder = 4, Status = Status.Active, Url = "/admin/category/add", IconCss = "fa fa-plus-square-o", ParentId = "CATEGORY" },
                            new QHN_Function() { Id = "CATEGORY_LIST", Name = "Category List", IsRole = false, SortOrder = 4, Status = Status.Active, Url = "/admin/category", IconCss = "fa fa-tachometer", ParentId = "CATEGORY"},
                           
                            // Setting function
                            new QHN_Function() { Id = "SETTING", Name = "Setting", IsRole = false, SortOrder = 6, Status = Status.Active, Url = "/admin/setting", IconCss = "fa fa-database", ParentId = null},
                            new QHN_Function() { Id = "SETTING_MEDIA", Name = "Media", IsRole = false, SortOrder = 6, Status = Status.Active, Url = "/admin/setting/media", IconCss = "fa fa-database", ParentId = "SETTING"},

                        
                            // User function
                            new QHN_Function(){ Id = "USER", Name = "User", IsRole = false, SortOrder = 5, Status = Status.Active, Url = "", IconCss = "fa fa-users", ParentId = null },
                            new QHN_Function(){ Id = "USER_NEW_USER", Name = "Add New User", IsRole = false, SortOrder = 5, Status = Status.Active, Url = "/admin/user/add-user", IconCss = "", ParentId = "USER" },
                            new QHN_Function(){ Id = "USER_LIST", Name = "List User", IsRole = false, SortOrder = 5, Status = Status.Active, Url = "/admin/user/list-user", IconCss = "", ParentId = "USER" },
                            new QHN_Function(){ Id = "USER_NEW_ROLE", Name = "Add New Role", IsRole = false, SortOrder = 5, Status = Status.Active, Url = "/admin/user/add-role", IconCss = "", ParentId = "USER" },
                            new QHN_Function(){ Id = "USER_LIST_ROLE", Name = "List Role", IsRole = false, SortOrder = 5, Status = Status.Active, Url = "/admin/user/list-role", IconCss = "", ParentId = "USER" },
                        }) ;
                    }

                    if(appDbContext.QHN_Permissons.Count() == 0)
                    {
                        appDbContext.QHN_Permissons.AddRange(new List<QHN_Permisson>()
                        {
                            new QHN_Permisson() { Create = true, Read = true, Delete = true, Update = true, Approved = true, FunctionId = "DASHBOARD", RoleId = appRole.Id, Temp = "" },
                            
                            // Media
                            new QHN_Permisson() { Create = true, Read = true, Delete = true, Update = true, Approved = true, FunctionId = "MEDIA", RoleId = appRole.Id, Temp = "" },
                            new QHN_Permisson() { Create = true, Read = true, Delete = true, Update = true, Approved = true, FunctionId = "MEDIA_NEW", RoleId = appRole.Id, Temp = "" },
                            new QHN_Permisson() { Create = true, Read = true, Delete = true, Update = true, Approved = true, FunctionId = "MEDIA_LIST", RoleId = appRole.Id, Temp = "" },
                            
                            // product
                            new QHN_Permisson() { Create = true, Read = true, Delete = true, Update = true, Approved = true, FunctionId = "PRODUCT", RoleId = appRole.Id, Temp = "" },
                            new QHN_Permisson() { Create = true, Read = true, Delete = true, Update = true, Approved = true, FunctionId = "PRODUCT_NEW", RoleId = appRole.Id, Temp = "" },
                            new QHN_Permisson() { Create = true, Read = true, Delete = true, Update = true, Approved = true, FunctionId = "PRODUCT_LIST", RoleId = appRole.Id, Temp = "" },
                            new QHN_Permisson() { Create = true, Read = true, Delete = true, Update = true, Approved = true, FunctionId = "PRODUCT_COLOR", RoleId = appRole.Id, Temp = "" },
                            new QHN_Permisson() { Create = true, Read = true, Delete = true, Update = true, Approved = true, FunctionId = "PRODUCT_COMMENT", RoleId = appRole.Id, Temp = "" },
                            
                            // category
                            new QHN_Permisson() { Create = true, Read = true, Delete = true, Update = true, Approved = true, FunctionId = "CATEGORY", RoleId = appRole.Id, Temp = "" },
                            new QHN_Permisson() { Create = true, Read = true, Delete = true, Update = true, Approved = true, FunctionId = "CATEGORY_NEW", RoleId = appRole.Id, Temp = "" },
                            new QHN_Permisson() { Create = true, Read = true, Delete = true, Update = true, Approved = true, FunctionId = "CATEGORY_LIST", RoleId = appRole.Id, Temp = "" },
                            
                            // srtting
                            new QHN_Permisson() { Create = true, Read = true, Delete = true, Update = true, Approved = true, FunctionId = "SETTING", RoleId = appRole.Id, Temp = "" },
                            new QHN_Permisson() { Create = true, Read = true, Delete = true, Update = true, Approved = true, FunctionId = "SETTING_MEDIA", RoleId = appRole.Id, Temp = "" },

                            // User
                            new QHN_Permisson() { Create = true, Read = true, Delete = true, Update = true, Approved = true, FunctionId = "USER", RoleId = appRole.Id, Temp = "" },
                            new QHN_Permisson() { Create = true, Read = true, Delete = true, Update = true, Approved = true, FunctionId = "USER_NEW_USER", RoleId = appRole.Id, Temp = "" },
                            new QHN_Permisson() { Create = true, Read = true, Delete = true, Update = true, Approved = true, FunctionId = "USER_LIST", RoleId = appRole.Id, Temp = "" },
                            new QHN_Permisson() { Create = true, Read = true, Delete = true, Update = true, Approved = true, FunctionId = "USER_NEW_ROLE", RoleId = appRole.Id, Temp = "" },
                            new QHN_Permisson() { Create = true, Read = true, Delete = true, Update = true, Approved = true, FunctionId = "USER_LIST_ROLE", RoleId = appRole.Id, Temp = "" },

                        });
                    }

                    if(appDbContext.QHN_SettingMetaDatas.Count() == 0)
                    {
                        appDbContext.QHN_SettingMetaDatas.AddRange(new List<QHN_SettingMetaData>()
                        {
                            new QHN_SettingMetaData() { MetaKey = SettingConstant.KEY_IMAGE_EXTENSION, MetaValue = ".jpg, .png", MetaType = SettingConstant.META_TYPE_MIDIA },
                            new QHN_SettingMetaData() { MetaKey = SettingConstant.KEY_IMAGE_UPLOAD_MAX_FILE_SIZE, MetaValue = "20", MetaType = SettingConstant.META_TYPE_MIDIA },
                            new QHN_SettingMetaData() { MetaKey = SettingConstant.KEY_IMAGE_UPLOAD_FILE_LIMIT, MetaValue = "5", MetaType = SettingConstant.META_TYPE_MIDIA },
                            new QHN_SettingMetaData() { MetaKey = SettingConstant.KEY_IMAGE_UPLOAD_ACCEPTED_FILE, MetaValue = "image/*", MetaType = SettingConstant.META_TYPE_MIDIA },
                        });
                    }

                    appDbContext.SaveChanges();
                    transaction.Commit();
                }
                catch(Exception exception)
                {
                    LoggerFile.WriteFile(exception);
                    transaction.Dispose();
                }
            }
			
		}
    }
}
