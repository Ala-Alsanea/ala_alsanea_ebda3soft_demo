using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ala_alsanea_ebda3soft_demo.Persistent;
using ala_alsanea_ebda3soft_demo.Persistent.Enums;
using ala_alsanea_ebda3soft_demo.Persistent.Models;
using ala_alsanea_ebda3soft_demo.Persistent.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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




        public IActionResult Report(long id)
        {

            Category category = _context.Categories
            .Include(i => i.Invoices)
            .ThenInclude(i => i.Account)
            .Where(i => i.Id == id)
            .FirstOrDefault();

            if (null == category)
                return NotFound();

            // var invoicesBond = category.Invoices
            //     .Where(i => i.InvoiceType == InvoiceType.bond)
            //     .ToList();

            // var invoicesExchange = category.Invoices
            //     .Where(i => i.InvoiceType == InvoiceType.exchange)
            //     .ToList();

            return View(category);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryVM categoryVM)
        {

            if (!ModelState.IsValid)
            {
                return View(categoryVM);
            }

            Category category = new Category()
            {

                Name = categoryVM.Name,
                unit = categoryVM.unit
            };


            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(long id)
        {
            Category? category = _context.Categories.Find(id);
            if (category == null)
            {
                return View("Error");
            }

            CategoryVM categoryVM = new CategoryVM()
            {

                Name = category.Name,
                unit = category.unit
            };


            return View(categoryVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryVM categoryVM)
        {

            if (!ModelState.IsValid)
            {
                return View(categoryVM);
            }

            Category category = new Category()
            {

                Id = categoryVM.Id,
                Name = categoryVM.Name,
                unit = categoryVM.unit
            };

            _context.Categories.Update(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            Category? category = await _context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}