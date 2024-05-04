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

            return builder;
        }
    }
}