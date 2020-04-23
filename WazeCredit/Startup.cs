using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using WazeCredit.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WazeCredit.Service;
using WazeCredit.Utility.AppSettingsClasses;
using WazeCredit.Utility.DI_Config;
using WazeCredit.Middleware;
using WazeCredit.Service.LifeTimeExample;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace WazeCredit
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddTransient<IMarketForecaster, MarketForecasterV2>();
            //services.AddSingleton<IMarketForecaster>(new MarketForecasterV2());
            //services.AddTransient<MarketForecasterV2>();
            //services.AddSingleton(new MarketForecasterV2());
            //services.AddTransient(typeof(MarketForecasterV2));
            //services.AddTransient(typeof(IMarketForecaster), typeof(MarketForecasterV2));

            services.AddAppSettingsConfig(Configuration);


            //services.AddScoped<IValidationChecker, AddressValidationChecker>();
            //services.AddScoped<IValidationChecker, CreditValidationChecker>();
            //services.TryAddEnumerable(ServiceDescriptor.Scoped<IValidationChecker, AddressValidationChecker>());
            //services.TryAddEnumerable(ServiceDescriptor.Scoped<IValidationChecker, CreditValidationChecker>());

            services.TryAddEnumerable(new[] {
            ServiceDescriptor.Scoped<IValidationChecker, AddressValidationChecker>(),
            ServiceDescriptor.Scoped<IValidationChecker, CreditValidationChecker>()
            });

            services.AddScoped<ICreditValidator, CreditValidator>();

            services.AddTransient<TransientService>();
            services.AddScoped<ScopedService>();
            services.AddSingleton<SingletonService>();
            services.TryAddTransient<IMarketForecaster, MarketForecaster>();
            services.AddControllersWithViews().AddRazorRuntimeCompilation();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
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
            app.UseMiddleware<CustomMiddleware>();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
