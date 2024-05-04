using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ala_alsanea_ebda3soft_demo.Persistent;
using ala_alsanea_ebda3soft_demo.Persistent.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ala_alsanea_ebda3soft_demo.Controllers
{
    // [Route("[controller]")]
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
                private readonly AppDbContext _context;


        public CategoryController(ILogger<CategoryController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Category> categories = _context.Categories.ToList();
            // Console.WriteLine(categories);
            return View(categories);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}