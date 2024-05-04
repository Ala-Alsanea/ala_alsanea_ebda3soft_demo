using ala_alsanea_ebda3soft_demo.Config;
using ala_alsanea_ebda3soft_demo.Persistent;
using ala_alsanea_ebda3soft_demo.Persistent.Seed;
using Microsoft.EntityFrameworkCore;

// var builder = WebApplication.CreateBuilder(args);

// // Add services to the container.
// builder.Services.AddControllersWithViews();
// builder.Services.AddDbContext<AppDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLServerConnectionString")));



// var app = builder.Build();


// // Configure the HTTP request pipeline.
// if (!app.Environment.IsDevelopment())
// {
//     app.UseExceptionHandler("/Home/Error");
//     // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//     app.UseHsts();
// }

// app.UseHttpsRedirection();
// app.UseStaticFiles();

// app.UseRouting();

// app.UseAuthorization();

// app.MapControllerRoute(
//     name: "default",
//     pattern: "{controller=Home}/{action=Index}/{id?}");

// app.Run();

// application start (framework)
var builder = WebApplication.CreateBuilder(args);
// initialize configuration (application)
var config = BuliderConfig.Boot(builder);
// application build (framework)
var app = config.Build();
// initialize CLI (application)
Cli.Boot(app, args);
// initialize bootstraping (application)
var bootstrap = Bootstrap.Boot(app);
// application run
bootstrap.Run();