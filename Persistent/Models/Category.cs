using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ala_alsanea_ebda3soft_demo.Persistent.Enums;

namespace ala_alsanea_ebda3soft_demo.Persistent.Models
{
    public class Category
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }

        public UnitType unit { get; set; }

        public ICollection<Invoice> Invoices { get; set; }


        public override string ToString()
        {
            return $"Id: {Id}, Name: {Name}, Unit: {unit}";
        }
    }
}