using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ala_alsanea_ebda3soft_demo.Persistent;
using ala_alsanea_ebda3soft_demo.Persistent.Models;
using ala_alsanea_ebda3soft_demo.Persistent.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ala_alsanea_ebda3soft_demo.Controllers
{
    // [Route("[controller]")]
    [Authorize]

    public class InvoiceController : Controller
    {
        private readonly ILogger<InvoiceController> _logger;

        private readonly AppDbContext _context;

        public InvoiceController(ILogger<InvoiceController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }


        public IActionResult Index()
        {
            List<Invoice> invoices = _context.Invoices
                    .Include(i => i.Account)
                    .Include(i => i.Category)
                    .ToList();

            Console.WriteLine(invoices);
            return View(invoices);
        }

        public IActionResult Details(long id)
        {

            Invoice invoice = _context.Invoices
            .Include(i => i.Account)
            .Include(i => i.Category)
            .Where(i => i.Id == id)
            .FirstOrDefault();

            if (null == invoice)
                return NotFound();

            return View(invoice);
        }

        public IActionResult Create()
        {

            // Get the list of accounts from your database
            var accounts = _context.Accounts.ToList();
            var category = _context.Categories.ToList();

            // if (accounts.Count == 0 || category.Count == 0)
            // {

            //     return NotFound("No Accounts or Categories found to create an invoice. Please create an account or category first.");
            // }

            if (accounts.Count == 0)
            {
                // Redirect to the account creation page
                return RedirectToAction("Create", "Account");
            }

            if (category.Count == 0)
            {
                // Redirect to the category creation page
                return RedirectToAction("Create", "Category");
            }

            // Set ViewBag.Accounts
            ViewBag.Accounts = accounts;
            ViewBag.Category = category;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceVM invoiceVM)
        {

            // Console.WriteLine("\ninvoice : " + invoice.ToString());
            // Console.WriteLine($"\n{invoiceVM.AccountId}\n");

            if (!ModelState.IsValid)
            {
                var accounts = _context.Accounts.ToList();
                var category = _context.Categories.ToList();

                // Set ViewBag.Accounts
                ViewBag.Accounts = accounts;
                ViewBag.Category = category;


                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();

                // Log the errors or return them in the view
                foreach (var error in errors)
                {
                    Console.WriteLine($"\nKey: {error.Key}, Errors: {string.Join(", ", error.Errors.Select(e => e.ErrorMessage))}\n");
                }

                return View(invoiceVM);

            }

            var accountExists = _context.Accounts.Any(a => a.Id == invoiceVM.AccountId);
            var categoryExists = _context.Categories.Any(a => a.Id == invoiceVM.CategoryId);

            if (!accountExists || !categoryExists)
            {
                // Handle the case where the AccountId does not exist
                // You could return an error message to the view
                ModelState.AddModelError("", "The provided AccountId does not exist.");
                return View(invoiceVM);
            }


            Invoice invoice = new Invoice
            {
                AccountId = invoiceVM.AccountId,
                CategoryId = invoiceVM.CategoryId,
                InvoiceType = invoiceVM.InvoiceType,
                PayType = invoiceVM.PayType,
                Qty = invoiceVM.Qty,
                UnitPrice = invoiceVM.UnitPrice
            };

            _context.Invoices.Add(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public IActionResult Edit(long id)
        {
            Invoice? invoice = _context.Invoices
                                .Include(i => i.Account)
                                .Include(i => i.Category)
                                .FirstOrDefault(i => i.Id == id);

            if (invoice == null)
            {
                return View("Error");
            }

            InvoiceVM invoiceVM = new InvoiceVM
            {
                Id = invoice.Id,
                AccountId = invoice.AccountId,
                CategoryId = invoice.CategoryId,
                InvoiceType = invoice.InvoiceType,
                PayType = invoice.PayType,
                Qty = invoice.Qty,
                UnitPrice = invoice.UnitPrice
            };

            // Populate the ViewBag properties
            ViewBag.Accounts = _context.Accounts.ToList();
            ViewBag.Category = _context.Categories.ToList();

            return View(invoiceVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(InvoiceVM invoiceVM)
        {
            // Console.WriteLine("\ninvoice : " + invoice.ToString());
            // Console.WriteLine($"\n{invoiceVM.AccountId}\n");

            if (!ModelState.IsValid)
            {
                var accounts = _context.Accounts.ToList();
                var category = _context.Categories.ToList();

                // Set ViewBag.Accounts
                ViewBag.Accounts = accounts;
                ViewBag.Category = category;


                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();

                // Log the errors or return them in the view
                foreach (var error in errors)
                {
                    Console.WriteLine($"\nKey: {error.Key}, Errors: {string.Join(", ", error.Errors.Select(e => e.ErrorMessage))}\n");
                }

                return View(invoiceVM);

            }

            var accountExists = _context.Accounts.Any(a => a.Id == invoiceVM.AccountId);
            var categoryExists = _context.Categories.Any(a => a.Id == invoiceVM.CategoryId);

            if (!accountExists || !categoryExists)
            {
                // Handle the case where the AccountId does not exist
                // You could return an error message to the view
                ModelState.AddModelError("", "The provided AccountId does not exist.");
                return View(invoiceVM);
            }


            Invoice invoice = new Invoice
            {
                Id = invoiceVM.Id,
                AccountId = invoiceVM.AccountId,
                CategoryId = invoiceVM.CategoryId,
                InvoiceType = invoiceVM.InvoiceType,
                PayType = invoiceVM.PayType,
                Qty = invoiceVM.Qty,
                UnitPrice = invoiceVM.UnitPrice
            };

            _context.Invoices.Update(invoice);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            Invoice? invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            _context.Invoices.Remove(invoice);
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