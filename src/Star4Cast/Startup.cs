using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Star4Cast.Data;
using Star4Cast.Models;
using Star4Cast.Services;
using Star4Cast.Data.DBContext.ProfileDb;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Cookies;
using Star4Cast.Data.DBContext.UserDb;
using Star4Cast.Models.Identity;
using Star4Cast.Data.Configuration;

namespace Star4Cast
{
    public class Startup
    {
        public static IConfigurationRoot ConfigurationRoot { get; private set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();
            }

            builder.AddEnvironmentVariables();
            ConfigurationRoot = Configuration = builder.Build();
            //ConfigurationSingleton.Instance.Configuration = Configuration;
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddDbContext<UserDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("MSSQLServer")));
            services.AddDbContext<ProfileDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MSSQLServer")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<UserDbContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
            services.Configure<AuthMessageSenderOptions>(Configuration);

            services.Configure<IdentityOptions>(options =>
            {
                options.Cookies.ApplicationCookie.LoginPath = new PathString("/Account/Login");
                options.Cookies.ApplicationCookie.CookieHttpOnly = true;
                options.Cookies.ApplicationCookie.Events = new CookieAuthenticationEvents()
                {
                    OnRedirectToLogin = context =>
                    {
                        if (context.Request.Path.Value.StartsWith("/web"))
                        {
                            context.Response.Clear();
                            context.Response.StatusCode = 401;
                            return Task.FromResult(0);
                        }

                        context.Response.Redirect(context.RedirectUri);
                        return Task.FromResult(0);
                    }
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //loggerFactory.AddDebug();
            //loggerFactory.AddProvider(new SqlLoggerProvider());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseIdentity();


            using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>()
               .CreateScope())
            {

                serviceScope.ServiceProvider.GetService<UserDbContext>().Database.Migrate();
                app.EnsureUsersAndRolesCreated();

                serviceScope.ServiceProvider.GetService<ProfileDbContext>().EnsureSocialAddressDataInserted();
                serviceScope.ServiceProvider.GetService<ProfileDbContext>().EnsureCategoryInserted();
                serviceScope.ServiceProvider.GetService<ProfileDbContext>().EnsureLanguageAndAscentInserted();
            }

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
