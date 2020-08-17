using BrixBank.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace BrixBank.Data
{
    
    public class BrixBankContext : DbContext
    {
        //run migrations during startup .net core
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Rules> Rules { get; set; }
        public virtual DbSet<LoanRequest> LoanRequests { get; set; }

        public BrixBankContext()
        {
        }

        public BrixBankContext(DbContextOptions<BrixBankContext> options)
          : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           // modelBuilder.Entity<Customer>().HasIndex(x => new { x.Name }).IsUnique();
        }
    }
}
