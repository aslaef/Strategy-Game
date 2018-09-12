using Hangfire;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Strategy_game.Context;
using Strategy_game.ServiceInterfaces;
using Strategy_game.Services;

namespace Strategy_game
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
            services.AddTransient<IStrategyService, StrategyService>();
            services.AddTransient<IUnitBuildingSetterService, UnitBuildingSetterService>();
            services.AddTransient<IPlatoonService, PlatoonService>();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //hangfire:
            services.AddHangfire(x => x.UseSqlServerStorage(Configuration.GetConnectionString("ApplitactionDbContext")));
            //hangfire
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddDbContext<ApplitactionDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("ApplitactionDbContext")));

            
        
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            //hangfire:

            app.UseHangfireServer();
            app.UseHangfireDashboard();

            //hangfire-
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });
            RecurringJob.AddOrUpdate<IStrategyService>(
                S => S.DoOneRound(),
                Cron.Minutely);
            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
