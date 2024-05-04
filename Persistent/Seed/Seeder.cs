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
                var account = new List<Account>()
                {
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


        }
    }
}