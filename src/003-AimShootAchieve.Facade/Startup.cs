using _001_AimShootAchieve.Domain.Interfaces;
using _001_Domain.Entities;
using _001_Domain.Interfaces;
using _002_AimShootAchieve.Infrastructure.DAL;
using _002_AimShootAchieve.Infrastructure.Services;
using _002_Infrastructure.DAL;
using _002_Infrastructure.DAL.Repositories;
using _002_Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace _003_AimShootAchieve.Facade
{
    public class Startup
    {
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

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddDbContext<DatabaseContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IRepository<Verlanglijst>, VerlanglijstRepository>();
            services.AddScoped<IRepository<VerlanglijstItem>, VerlanglijstItemRepository>();
            services.AddScoped<IRepository<Lijst>, LijstRepository>();
            services.AddScoped<IRepository<LijstItem>, LijstItemRepository>();
            services.AddScoped<IRepository<Reis>, ReisRepository>();

            services.AddScoped<IVerlanglijstService, VerlanglijstService>();
            services.AddScoped<ILijstService, LijstService>();
            services.AddScoped<IHomeService, HomeService>();
            services.AddScoped<IReisService, ReisService>();
            services.AddScoped<IPublicService<Reis>, BasePublicService<Reis>>();
            services.AddScoped<IPublicService<Lijst>, BasePublicService<Lijst>>();
            services.AddScoped<IPublicService<Verlanglijst>, BasePublicService<Verlanglijst>>();

            services.AddIdentity<ApplicationUser, IdentityRole>(
                o => {
                    o.Password.RequireDigit = false;
                    o.Password.RequireUppercase = false;
                    o.Password.RequireNonAlphanumeric = false;
                    o.Password.RequireLowercase = false;
                    o.Password.RequiredLength = 6;    
                } )
                .AddEntityFrameworkStores<DatabaseContext>()
                .AddDefaultTokenProviders();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, UserManager<ApplicationUser> manager)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

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

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=index}/{id?}");
            });

            DatabaseInitializer.Initialize(manager);
        }
    }
}