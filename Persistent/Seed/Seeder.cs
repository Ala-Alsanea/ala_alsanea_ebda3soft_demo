using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ala_alsanea_ebda3soft_demo.Persistent.Enums;
using ala_alsanea_ebda3soft_demo.Persistent.Models;

namespace ala_alsanea_ebda3soft_demo.Persistent.Seed
{
    public class Seeder

    {
        private readonly AppDbContext _context;

        public Seeder(AppDbContext context)
        {
            _context = context;
        }


        public void SeedDataContext()
        {
            // seed data
            if (!_context.Accounts.Any())
            {


                // Invoice invoice = new Invoice();
                // invoice.InvoiceType = InvoiceType.bond;
                // invoice.PayType = PayType.Cash;
                // invoice.Qty = 10;
                // invoice.UnitPrice = 100;
                // invoice.Date = DateTime.Now; 

                // Account account1 = new Account();
                // account1.Name = "new user";
                // account1.accountType = AccountType.type1;
                // account1.Invoices = new List<Invoice>() { invoice };

                // invoice.Account = account1;           




                var account = new List<Account>()
                {
                    // account1,

                    new()
                    {
                        Name = "John 2",
                        accountType = AccountType.type1,
                    },
                    new()
                    {
                        Name = "John 3",
                        accountType = AccountType.type2,
                    },
                    new()
                    {
                        Name = "John 1",
                        accountType = AccountType.type1,
                    },
                };
                _context.Accounts.AddRange(account);
                _context.SaveChanges();
            }

            if (!_context.Categories.Any())
            {
                var categories = new List<Category>()
                {
                    new()
                    {
                        Name = "cat 1",
                        unit = UnitType.unit1
                    },
                    new()
                    {
                        Name = "cat 2",
                        unit = UnitType.unit2
                    },
                    new()
                    {
                        Name = "cat 3",
                        unit = UnitType.unit1
                    },
                };
                _context.Categories.AddRange(categories);
                _context.SaveChanges();
            }


        }
    }
}