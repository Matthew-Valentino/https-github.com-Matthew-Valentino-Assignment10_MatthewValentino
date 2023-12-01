using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Bank4Us.Common.CanonicalSchema;
using Bank4Us.Common.Core;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Bank4Us.DataAccess.Core
{
    /// <summary>
    ///   Course Name: MSCS 6360 Enterprise Architecture
    ///   Year: Fall 2023
    /// Name: Matthew Valentino  
    ///   Description: Homework 8 focusing on entity framework core
    /// </summary>
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder); 
            optionsBuilder.UseSqlServer(@"Server=.\localhost;Database=Bank4Us_Assignment9;Trusted_Connection=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Customer>()
             .Property(c => c.CreatedBy)
             .HasDefaultValue("admin");

            builder.Entity<Customer>()
             .Property(c => c.UpdatedBy)
             .HasDefaultValue("admin");

            builder.Entity<Account>()
             .Property(c => c.CreatedBy)
             .HasDefaultValue("admin");

            builder.Entity<Account>()
             .Property(c => c.UpdatedBy)
             .HasDefaultValue("admin");

            builder.Entity<Order>()
             .Property(c => c.CreatedBy)
             .HasDefaultValue("admin");

            builder.Entity<Order>()
             .Property(c => c.UpdatedBy)
             .HasDefaultValue("admin");

            builder.Entity<Product>()
             .Property(c => c.CreatedBy) 
             .HasDefaultValue("admin");
            builder.Entity<Product>()   
             .Property(c => c.UpdatedBy)
             .HasDefaultValue("admin");
        }


        public virtual void Save()
        {
            base.SaveChanges();
        }

        #region Entities representing Database Objects
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Order> Orders { get; set;}
        public DbSet<Product> Products { get; set; }
        #endregion
    }
}
