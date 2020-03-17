using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SmartShop.App.ModelEntity.Entities;
using SmartShop.App.ModelEntity.Interface;
using System;
using System.Linq;

namespace SmartShop.App.ModelEntity
{
    public class AppDbContext : IdentityDbContext<QHN_AppUser, QHN_AppRole, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<QHN_AppUser> AppUsers { get; set; }

        public DbSet<QHN_AppRole> AppRoles { get; set; }

        public DbSet<QHN_AppUserRole> AppUserRoles { get; set; }

        public DbSet<QHN_Function> Functions { get; set; }

        public DbSet<QHN_Color> QHN_Colors { get; set; }

        public DbSet<QHN_Image> QHN_Images { get; set; }

        public DbSet<QHN_LoggerAction> QHN_LoggerActions { get; set; }

        public DbSet<QHN_LoggerData> QHN_LoggerDatas { get; set; }

        public DbSet<QHN_Permisson> QHN_Permissons { get; set; }

        public DbSet<QHN_Product> QHN_Products { get; set; }

        public DbSet<QHN_ProductCategory> QHN_ProductCategories { get; set; }

        public DbSet<QHN_ProductColor> HN_ProductColors { get; set; }

        public DbSet<QHN_ProductComment> QHN_ProductComments { get; set; }

        public DbSet<QHN_ProductImage> QHN_ProductImages { get; set; }

        public DbSet<QHN_ProductTag> QHN_ProductTags { get; set; }

        public DbSet<QHN_SettingMetaData> QHN_SettingMetaDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("AppUserClaims").HasKey(x => x.Id);

            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("AppRoleClaims").HasKey(x => x.Id);

            builder.Entity<IdentityUserLogin<Guid>>().ToTable("AppUserLogins").HasKey(x => x.UserId);

            builder.Entity<IdentityUserRole<Guid>>().ToTable("AppUserRoles").HasKey(x => new { x.RoleId, x.UserId });

            builder.Entity<IdentityUserToken<Guid>>().ToTable("AppUserTokens").HasKey(x => new { x.UserId });

            //builder.Entity<AppUserRole>().HasKey(x => new { x.RoleId, x.UserId });

            //base.OnModelCreating(builder);
        }

        public override int SaveChanges()
        {
            var modified = ChangeTracker.Entries().Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (EntityEntry entity in modified)
            {
                var changeOrAddItem = entity.Entity as IDateTimeInterface;

                if (changeOrAddItem != null)
                {
                    if (entity.State == EntityState.Added)
                    {
                        changeOrAddItem.DateCreated = DateTime.Now;
                    }
                    else if (entity.State == EntityState.Modified)
                    {
                        changeOrAddItem.DateUpdated = DateTime.Now;
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}