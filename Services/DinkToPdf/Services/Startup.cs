using Microsoft.Extensions.FileProviders;

namespace GWI.Services.DinkToPdf.Services
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(env.ContentRootPath, "Exports")),
                RequestPath = "/Files"
            });
        }
    }
}