// فاتوره
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using ala_alsanea_ebda3soft_demo.Persistent.Enums;

namespace ala_alsanea_ebda3soft_demo.Persistent.Models
{
    public class Invoice
    {
        [Key]
        public long Id { get; set; }
        public long AccountId { get; set; }
        public long CategoryId { get; set; }
        public Account Account { get; set; }
        public Category Category { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public PayType PayType { get; set; }
        public double Qty { get; set; } = 0;
        public double UnitPrice { get; set; } = 0;

        [NotMapped]
        public double TotalPrice
        {
            get
            {
                return Qty * UnitPrice;
            }
        }

    public override string ToString()
    {
        return $"\nId: {Id}, \nAccount: {Account}, \nCategory: {Category}, \nInvoiceType: {InvoiceType}, Date: {Date}, PayType: {PayType}, Qty: {Qty}, UnitPrice: {UnitPrice}, TotalPrice: {TotalPrice}\n";
    }


    }
}