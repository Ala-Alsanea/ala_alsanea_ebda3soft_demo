using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ala_alsanea_ebda3soft_demo.Persistent.Models
{
    public class Invoice
    {
                [Key]
        public long Id { get; set; }
    }
}