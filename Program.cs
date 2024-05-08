using ala_alsanea_ebda3soft_demo.Config;
using ala_alsanea_ebda3soft_demo.Persistent;
using ala_alsanea_ebda3soft_demo.Persistent.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using ala_alsanea_ebda3soft_demo.Persistent.Models;

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