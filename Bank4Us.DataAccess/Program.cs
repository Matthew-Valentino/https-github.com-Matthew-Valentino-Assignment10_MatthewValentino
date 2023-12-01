using System;
using System.Collections.Generic;
using Bank4Us.Common.CanonicalSchema;
using Bank4Us.DataAccess.Core;

namespace Bank4Us.DataAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            using (DataContext db = new DataContext())
            {
                // Create a new customer
                Customer customer = new Customer
                {
                    FirstName = "Matt",
                    LastName = "Valentino",
                    CreatedBy = "admin",
                    CreatedOn = DateTime.Now
                };

                // Create a new account and link it to the customer
                Account account = new Account
                {
                    AccountType = Account.AccountTypeEnum.Checking,
                    OpenDate = DateTime.Now,
                    Balance = 500.00m,
                    Customer = customer  
                };

                // If Customer has a collection of Accounts, add the account to this collection
                customer.Accounts = new List<Account> { account };

                db.Customers.Add(customer);

                // Create a new order for the customer
                Order order = new Order
                {
                    OrderDate = DateTime.Now,
                    CustomerId = customer.Id,  
                    Products = new List<Product>
                    {
                        new Product { Name = "Product1", Price = 100.00m },
                        new Product { Name = "Product2", Price = 200.00m }
                    }
                };

                db.Orders.Add(order);
                db.SaveChanges();
            }
        }
    }
}
