using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ala_alsanea_ebda3soft_demo.Persistent.Enums;

namespace ala_alsanea_ebda3soft_demo.Persistent.ViewModel
{
    public class AccountVM
    {
        
        public long Id { get; set; }

        public string Name { get; set; }

        public AccountType accountType { get; set; }
    }
}