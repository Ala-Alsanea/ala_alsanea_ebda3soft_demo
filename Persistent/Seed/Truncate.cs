using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ala_alsanea_ebda3soft_demo.Persistent.Seed
{
    public class Truncate
    {
                private readonly AppDbContext _context;

        public Truncate(AppDbContext context)
        {
            _context = context;
        }

        public void TruncateDatabase()
        {
            _context.Database.EnsureDeleted();
        }
    }
}