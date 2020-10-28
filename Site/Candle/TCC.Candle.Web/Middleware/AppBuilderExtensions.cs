using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace TCC.Candle.Web.Middleware
{
    public static class AppBuilderExtensions
    {
        /// <summary>
        /// Extending UseStaticFiles method to serve node packages from node_modules directory
        /// </summary>
        /// <param name="app"></param>
        /// <param name="root">the root of your appliction aka ContentRootPath</param>
        /// <returns></returns>
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root)
        {
            string path = Path.Combine(root, "node_modules");

            var options = new StaticFileOptions();
            options.FileProvider = new PhysicalFileProvider(path);
            options.RequestPath = "/static";


            app.UseStaticFiles(options);
            return app;

        }


    }
}
