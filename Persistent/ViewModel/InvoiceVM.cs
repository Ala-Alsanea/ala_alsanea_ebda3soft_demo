using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ala_alsanea_ebda3soft_demo.Persistent.Enums;


namespace ala_alsanea_ebda3soft_demo.Persistent.ViewModel
{
    public class InvoiceVM
    {

        public long Id { get; set; }
        public long AccountId { get; set; }
        public long CategoryId { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public PayType PayType { get; set; }
        public double Qty { get; set; } = 0;
        public double UnitPrice { get; set; } = 0;


    }
}