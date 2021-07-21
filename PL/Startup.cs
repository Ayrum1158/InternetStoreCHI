using BL;
using BL.Services;
using Core.Interfaces;
using Core.Setup;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession((options) =>
            {
                options.Cookie.IsEssential = true;
            });

            var config = Configuration.GetSection(DBOptions.DBOptionsKey);
            services.Configure<DBOptions>(config);

            var dbOptions = config.Get<DBOptions>();
            services.AddDALServices(dbOptions);

            services.AddControllersWithViews();

            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICryptor, СryptographyService>();
            services.AddTransient<IProductService, ProductService>();

            services.AddTransient<DBFillTestClass>();
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
                app.UseExceptionHandler("Error");
            }

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}");

                endpoints.MapControllers();
            });
        }
    }
}
