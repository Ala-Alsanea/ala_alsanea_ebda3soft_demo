using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ala_alsanea_ebda3soft_demo.Persistent;
using ala_alsanea_ebda3soft_demo.Persistent.Models;
using ala_alsanea_ebda3soft_demo.Persistent.Seed;
using Microsoft.EntityFrameworkCore;

namespace ala_alsanea_ebda3soft_demo.Config
{
    public static class BuliderConfig
    {
        public static WebApplicationBuilder Boot(WebApplicationBuilder builder)
        {
            // bind cli commands
            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnectionString")));
            
            builder.Services.AddTransient<Seeder>();
            builder.Services.AddTransient<Truncate>();

            builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = true).AddEntityFrameworkStores<AppDbContext>();

            builder.Services.AddControllersWithViews();

            // Get the IWebHostEnvironment service
            var env = builder.Services.BuildServiceProvider().GetRequiredService<IWebHostEnvironment>();

            // Check if the application is in the development environment
            if (env.IsDevelopment())
            {
                Console.WriteLine("development env");
            }
            else
            {
                Console.WriteLine("deploy environment");

                var serviceProvider = builder.Services.BuildServiceProvider();
                // Get a scope to retrieve scoped services
                using (var scope = serviceProvider.CreateScope())
                {
                    // Get the AppDbContext instance
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    // Apply the migrations
                    dbContext.Database.Migrate();
                }
            }

            // Get the service provider

            return builder;
        }
    }
}