using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ala_alsanea_ebda3soft_demo.Persistent;
using ala_alsanea_ebda3soft_demo.Persistent.Models;
using ala_alsanea_ebda3soft_demo.Persistent.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ala_alsanea_ebda3soft_demo.Controllers
{
    // [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly AppDbContext _context;

        public AccountController(ILogger<AccountController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {

            List<Account> accounts = _context.Accounts.ToList();
            return View(accounts);
        }

        public IActionResult Details(long id)
        {

            Account account = _context.Accounts
            .Include(i => i.Receipts)
            .Include(i => i.Invoices)
            .Where(i => i.Id == id)
            .FirstOrDefault();

            if (null == account)
                return NotFound();

            return View(account);
        }


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AccountVM accountVM)
        {


            if (!ModelState.IsValid)
            {


                var errors = ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .Select(x => new { x.Key, x.Value.Errors })
                    .ToArray();

                // Log the errors or return them in the view
                foreach (var error in errors)
                {
                    Console.WriteLine($"\nKey: {error.Key}, Errors: {string.Join(", ", error.Errors.Select(e => e.ErrorMessage))}\n");
                }

                return View(accountVM);

            }

            Account account = new Account()
            {
                Name = accountVM.Name,
                accountType = accountVM.accountType
            };

            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(long id)
        {
            Account? account = _context.Accounts.FirstOrDefault(i=> i.Id == id);

            if (account == null)
            {
                return View("Error");
            }

            AccountVM accountVM = new AccountVM()
            {
                Id= account.Id,
                Name = account.Name,
                accountType = account.accountType
            };

            return View(accountVM);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AccountVM accountVM)
        {

            if (!ModelState.IsValid)
            {
                return View(accountVM);
            }

            Account account = new Account()
            {
                Id= accountVM.Id,
                Name = accountVM.Name,
                accountType = accountVM.accountType
            };

            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            Account? account = await _context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            _context.Accounts.Remove(account);
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