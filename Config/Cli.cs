using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ala_alsanea_ebda3soft_demo.Persistent.Seed;

namespace ala_alsanea_ebda3soft_demo.Config
{
    public static class Cli
    {
        public static void Boot(WebApplication app, string[] args)
        {
            if (args.Length == 1 && args[0].ToLower() == "seed-db")
            {
                SeedData(app);
                // terminate the application and throw an exception
                app.StopAsync().GetAwaiter().GetResult();
            }

            if (args.Length == 1 && args[0].ToLower() == "truncate-database")
            {
                TruncateDatabase(app);
                // terminate the application and throw an exception
                app.StopAsync().GetAwaiter().GetResult();
            }

            static void SeedData(IHost app)
            {
                var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
                using var scope = scopedFactory?.CreateScope();
                var service = scope?.ServiceProvider.GetService<Seeder>();
                service?.SeedDataContext();
            }


            static void TruncateDatabase(IHost app)
            {
                var scopedFactory = app.Services.GetService<IServiceScopeFactory>();
                using var scope = scopedFactory?.CreateScope();
                var service = scope?.ServiceProvider.GetService<Truncate>();
                service?.TruncateDatabase();
            }
        }
    }
}