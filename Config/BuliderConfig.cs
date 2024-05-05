using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ala_alsanea_ebda3soft_demo.Persistent;
using ala_alsanea_ebda3soft_demo.Persistent.Seed;
using Microsoft.EntityFrameworkCore;

namespace ala_alsanea_ebda3soft_demo.Config
{
    public static class BuliderConfig
    {
        public static WebApplicationBuilder Boot(WebApplicationBuilder builder)
        {
            // bind cli commands
            builder.Services.AddTransient<Seeder>();
            builder.Services.AddTransient<Truncate>();

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnectionString")));

            // Get the service provider
            var serviceProvider = builder.Services.BuildServiceProvider();

            // Get a scope to retrieve scoped services
            using(var scope = serviceProvider.CreateScope())
            {
                // Get the AppDbContext instance
                var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                // Apply the migrations
                dbContext.Database.Migrate();
            }

            return builder;
        }
    }
}