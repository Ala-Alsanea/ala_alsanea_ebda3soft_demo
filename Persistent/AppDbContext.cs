using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ala_alsanea_ebda3soft_demo.Persistent.Models;
using Microsoft.EntityFrameworkCore;

namespace ala_alsanea_ebda3soft_demo.Persistent
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<Receipt> Receipts { get; set; }

        // override OnModelCreating

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the Invoice entity
            modelBuilder.Entity<Invoice>()
                .HasOne(a => a.Account)
                .WithMany(i => i.Invoices)
                .HasForeignKey(i => i.AccountId)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Invoices)
                .WithOne(i => i.Account)
                .HasForeignKey(i => i.AccountId)
                .IsRequired();


            modelBuilder.Entity<Invoice>()
                .HasOne(a => a.Category)
                .WithMany(i => i.Invoices)
                .HasForeignKey(i => i.CategoryId)
                .IsRequired();

            modelBuilder.Entity<Category>()
                .HasMany(a => a.Invoices)
                .WithOne(i => i.Category)
                .HasForeignKey(i => i.CategoryId)
                .IsRequired();

            modelBuilder.Entity<Receipt>()
                .HasOne(a => a.Account)
                .WithMany(i => i.Receipts)
                .HasForeignKey(i => i.AccountId)
                .IsRequired();

            modelBuilder.Entity<Account>()
                .HasMany(a => a.Receipts)
                .WithOne(i => i.Account)
                .HasForeignKey(i => i.AccountId)
                .IsRequired();


            // Add more configurations...
        }

    }
}