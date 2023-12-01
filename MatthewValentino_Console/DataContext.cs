using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Bank4Us.CanoncialSchema;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
/// <summary>
///   Course Name: COSC 6360 Enterprise Architecture
///   Year: Fall 2023
///   Name: Matthew Valentino
///   Description: Example implementation of the Domain Driven Design Pattern.
///                https://en.wikipedia.org/wiki/Domain-driven_design                 
/// </summary>
namespace Bank4us.DataAccess
{
    public class DataContext : IdentityDbContext<Bank4Us.ApplicationUser>
    {
        public DataContext() { }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        //use same SQLserver connection lines from book, but added 
        //"TrustServerCertificate=True" at end to ensure the server can be connected to
        protected override void OnConfiguring(
        DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=Matt_Valentino;Initial Catalog=master;Integrated Security=False;User Id=mwv607;Password=SQLPassword;TrustServerCertificate=True;");
        }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        //Saving changes to SQL server at the end once the connection is made
        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        //Added the 4 entities I am using for these assignments
        public DbSet<Bank4Us.CanoncialSchema.Account> Accounts { get; set; }
        public DbSet<Bank4Us.CanoncialSchema.Customer> Customers { get; set; }
        public DbSet<Bank4Us.CanoncialSchema.Order> Orders { get; set; }
        public DbSet<Bank4Us.CanoncialSchema.Product> Products { get; set; }
    }
}