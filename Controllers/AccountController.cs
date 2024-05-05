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


        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Account account)
        {

            if (!ModelState.IsValid)
            {
                return View(account);
            }
            _context.Accounts.Add(account);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



        public IActionResult Edit(long id)
        {
            Account? account = _context.Accounts.Find(id);
            if (account == null)
            {
                return View("Error");
            }
            return View(account);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Account account)
        {

            if (!ModelState.IsValid)
            {
                return View(account);
            }
            _context.Accounts.Update(account);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(long id)
        {
            var account = await _context.Accounts.FindAsync(id);
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