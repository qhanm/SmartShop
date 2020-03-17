using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SmartShop.App.AutoMapper;
using SmartShop.App.DataProvider.Interfaces;
using SmartShop.App.DataProvider.Repositories;
using SmartShop.App.DataProvider.Serivces;
using SmartShop.App.ModelEntity;
using SmartShop.App.ModelEntity.Entities;

namespace SmartShop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            /**
             *Using UseSqlServer
             *  Install-Package Microsoft.EntityFrameworkCore.SqlServer
             * 
             */
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            /**
             * Add multi db context
             */
            services.AddIdentity<QHN_AppUser, QHN_AppRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
            }).AddEntityFrameworkStores<AppDbContext>()
            .AddRoles<QHN_AppRole>()
            .AddDefaultTokenProviders();

            services.AddScoped<UserManager<QHN_AppUser>, UserManager<QHN_AppUser>>();
            services.AddScoped<RoleManager<QHN_AppRole>, RoleManager<QHN_AppRole>>();

            services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddTransient(typeof(IRepository<,>), typeof(Repository<,>));

            // DI interface container
            services.AddTransient<IFunctionServiceInterFace, FunctionService>();
            services.AddTransient<IUserServiceInterface, UserService>();
            services.AddTransient<ISettingServiceInterface, SettingService>();
            services.AddTransient<IMediaServiceInterface, MediaService>();

            // config mapper
            #region config mapper
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.AddProfile(new MapperViewModelToEntity());
            });

            IMapper mapper = mappingConfig.CreateMapper();

            services.AddSingleton(mapper);
            #endregion end config mapper


            // set redirect page login admin dashboard when user go to dashboard
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Account/AccessDenied");
                options.Cookie.Name = "Cookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(720);
                options.LoginPath = new PathString("/admin/login");
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });

            // set request json default field(uppercase)
            services.AddControllersWithViews().
            AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                options.JsonSerializerOptions.PropertyNamingPolicy = null;
            });

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);//We set Time here 
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            }); // enable configuration session

            //services.AddMvc(options => options.EnableEndpointRouting = false);

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
         
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseSession();
            //app.UseMvc();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "admin",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
