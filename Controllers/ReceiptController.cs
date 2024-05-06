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
    [Route("[controller]")]
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
            List<Receipt> receipts = _context.Receipts.ToList();
            return View(receipts);
        }


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Receipt receipt)
        {

            if (!ModelState.IsValid)
            {
                return View(receipt);
            }
            _context.Receipts.Add(receipt);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(long id)
        {
            Receipt? receipt = _context.Receipts.Find(id);
            if (receipt == null)
            {
                return View("Error");
            }
            return View(receipt);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Receipt receipt)
        {

            if (!ModelState.IsValid)
            {
                return View(receipt);
            }
            _context.Receipts.Update(receipt);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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