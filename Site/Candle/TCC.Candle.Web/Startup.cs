using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TCC.Candle.Data.IOC;
using TCC.Candle.Logic.IOC;

namespace TCC.Candle.Web
{
    public class Startup
    {
        private IConfiguration Configuration;

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder().SetBasePath(env.ContentRootPath).AddJsonFile("appsettings.json");
            Configuration = builder.Build();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton(Configuration);
            services.AddDataLayerServices();
            services.AddLogicLayerServices();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc(routes =>
            {
                // Default Route
                routes.MapRoute(name: "Default", template: "{controller=Home}/{action=Index}/{Id?}");
            });

            // Serve Static Files
            app.UseStaticFiles();


            // Assuring that static files are working properly
            //app.UseDirectoryBrowser();








            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Site it Down!");
            });
        }
    }
}
