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

    public class ReceiptController : Controller
    {
        private readonly ILogger<ReceiptController> _logger;
        private readonly AppDbContext _context;


        public ReceiptController(ILogger<ReceiptController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            List<Receipt> receipts = _context.Receipts
            .Include(i => i.Account)
            .ToList();

            return View(receipts);
        }

        public IActionResult Details(long id)
        {

            Receipt receipt = _context.Receipts
            .Include(i => i.Account)
            .Where(i => i.Id == id)
            .FirstOrDefault();

            if (null == receipt)
                return NotFound();

            return View(receipt);
        }



        public IActionResult Create()
        {

            // Get the list of accounts from your database
            var accounts = _context.Accounts.ToList();

            if (accounts.Count == 0)
            {
                return RedirectToAction("Create", "Account");
                // return NotFound("No Accounts found to create an invoice. Please create an account first.");
            }

            // Set ViewBag.Accounts
            ViewBag.Accounts = accounts;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReceiptVM receiptVM)
        {

            // Console.WriteLine("\ninvoice : " + invoice.ToString());
            // Console.WriteLine($"\n{invoiceVM.AccountId}\n");

            if (!ModelState.IsValid)
            {
                var accounts = _context.Accounts.ToList();

                // Set ViewBag.Accounts
                ViewBag.Accounts = accounts;

                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();
                // Log the errors or return them in the view
                foreach (var error in errors)
                {
                    Console.WriteLine($"\nKey: {error.Key}, Errors: {string.Join(", ", error.Errors.Select(e => e.ErrorMessage))}\n");
                }

                return View(receiptVM);

            }

            var accountExists = _context.Accounts.Any(a => a.Id == receiptVM.AccountId);

            if (!accountExists)
            {
                // Handle the case where the AccountId does not exist
                // You could return an error message to the view
                ModelState.AddModelError("", "The provided AccountId does not exist.");
                return View(receiptVM);
            }


            Receipt receipt = new Receipt
            {
                AccountId = receiptVM.AccountId,
                ReceiptType = receiptVM.ReceiptType,
                Price = receiptVM.Price,
                Description = receiptVM.Description
            };

            _context.Receipts.Add(receipt);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        public IActionResult Edit(long id)
        {
            Receipt? receipt = _context.Receipts
                                .Include(i => i.Account)
                                .FirstOrDefault(i => i.Id == id);

            if (receipt == null)
            {
                return View("Error");
            }

            ReceiptVM receiptVM = new ReceiptVM
            {
                Id = receipt.Id,
                AccountId = receipt.AccountId,
                ReceiptType = receipt.ReceiptType,
                Price = receipt.Price,
                Description = receipt.Description

            };

            // Populate the ViewBag properties
            ViewBag.Accounts = _context.Accounts.ToList();

            return View(receiptVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReceiptVM receiptVM)
        {
            // Console.WriteLine("\ninvoice : " + invoice.ToString());
            // Console.WriteLine($"\n{invoiceVM.AccountId}\n");

            if (!ModelState.IsValid)
            {
                var accounts = _context.Accounts.ToList();

                // Set ViewBag.Accounts
                ViewBag.Accounts = accounts;


                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();

                // Log the errors or return them in the view
                foreach (var error in errors)
                {
                    Console.WriteLine($"\nKey: {error.Key}, Errors: {string.Join(", ", error.Errors.Select(e => e.ErrorMessage))}\n");
                }

                return View(receiptVM);

            }

            var accountExists = _context.Accounts.Any(a => a.Id == receiptVM.AccountId);

            if (!accountExists)
            {
                // Handle the case where the AccountId does not exist
                // You could return an error message to the view
                ModelState.AddModelError("", "The provided AccountId does not exist.");
                return View(receiptVM);
            }


            Receipt receipt = new Receipt
            {
                Id = receiptVM.Id,
                AccountId = receiptVM.AccountId,
                ReceiptType = receiptVM.ReceiptType,
                Price = receiptVM.Price,
                Description = receiptVM.Description
            };

            _context.Receipts.Update(receipt);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            Receipt? receipt = await _context.Receipts.FindAsync(id);
            if (receipt == null)
            {
                return NotFound();
            }

            _context.Receipts.Remove(receipt);
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