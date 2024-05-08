using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ala_alsanea_ebda3soft_demo.Config
{
    public static class Bootstrap
    {
        public static WebApplication Boot(WebApplication app)
        {


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
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

            app.MapRazorPages();
            app.MapControllers();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");


            return app;
        }
    }
}