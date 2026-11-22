using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NationalBankSystem.Entities;

namespace NationalBankSystem.Data
{
    public class BankDbContext : DbContext
    {
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=NationalBankDB;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BankDbContext).Assembly);

            
            modelBuilder.Entity<Manager>().HasData(
                new Manager
                {
                    Id = 1,
                    FullName = "Tarek El-Masry",
                    Email = "tarek.masry@nationalbank.eg",
                    PhoneNumber = "01001112233",
                    HireDate = new DateOnly(2018, 5, 1)
                },
                new Manager
                {
                    Id = 2,
                    FullName = "Nadia Mansour",
                    Email = "nadia.mansour@nationalbank.eg",
                    PhoneNumber = "01004445566",
                    HireDate = new DateOnly(2019, 9, 15)
                }
            );

           
            modelBuilder.Entity<Branch>().HasData(
                new Branch
                {
                    Code = "CAI-01",
                    Name = "Cairo Main Branch",
                    Address = "15 Tahrir Square, Cairo",
                    PhoneNumber = "0227940001",
                    ManagerId = 1
                },
                new Branch
                {
                    Code = "ALX-01",
                    Name = "Alexandria Branch",
                    Address = "42 Fouad Street, Alexandria",
                    PhoneNumber = "034870002",
                    ManagerId = 2
                }
            );
        }
    }
}
