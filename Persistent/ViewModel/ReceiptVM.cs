using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ala_alsanea_ebda3soft_demo.Persistent.Enums;

namespace ala_alsanea_ebda3soft_demo.Persistent.ViewModel
{
    public class ReceiptVM
    {
        public long Id { get; set; }
        public long AccountId { get; set; }
        public ReceiptType ReceiptType { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public double Price { get; set; } = 0;
        public string Description { get; set; }
    }
}