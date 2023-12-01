using Bank4us.DataAccess;
using Bank4Us.CanoncialSchema;
using System;
using System.Collections.Generic;

namespace Bank4Us.DataAccess
{    /// <summary>
     ///   Course Name: COSC 6360 Enterprise Architecture
     ///   Year: Fall 2023
     ///   Name: Matthew Valentino
     ///   Description: Example implementation of the Domain Driven Design Pattern.
     ///                https://en.wikipedia.org/wiki/Domain-driven_design                 
     /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new DataContext())
            {
                //Essentially did the same thing for each entity where it's stored in a list before 
                //being saved at the end using context.SaveChanges()
                var accounts = new List<Account>
                {
                    new Account { CustomerId = 1, OpenDate = new DateTime(2023, 1, 15), AccountType = "Checking", Balance = 7850.25m, Comment = "Main checking account." },
                    new Account { CustomerId = 2, OpenDate = new DateTime(2022, 5, 20), AccountType = "Savings", Balance = 15600.00m, Comment = "Long-term savings account." },
                    new Account { CustomerId = 3, OpenDate = new DateTime(2023, 3, 10), AccountType = "Checking", Balance = 2345.65m, Comment = "Payroll account." },
                    new Account { CustomerId = 4, OpenDate = new DateTime(2023, 4, 5), AccountType = "Savings", Balance = 9800.00m, Comment = "Emergency fund." },
                    new Account { CustomerId = 5, OpenDate = new DateTime(2021, 11, 25), AccountType = "Brokerage", Balance = 152300.75m, Comment = "Investment account." }
                 };
                 context.Accounts.AddRange(accounts);


                // Add sample customers
                var customers = new List<Customer>
                {
                    new Customer { FirstName = "Alice", LastName = "Johnson", Address = "742 Evergreen Terrace", City = "Springfield", State = "IL", ZipCode = "62701", Gender = "F", BirthDate = new DateTime(1975, 4, 23), EmailAddress = "alicej@gmail.com", HomePhone = "217-555-0113" },
                    new Customer { FirstName = "Bob", LastName = "Smith", Address = "123 Oak Street", City = "Lincoln", State = "NE", ZipCode = "68508", Gender = "M", BirthDate = new DateTime(1988, 8, 12), EmailAddress = "bobsmith@marquette.edu", HomePhone = "402-555-0182" },
                    new Customer { FirstName = "Carol", LastName = "Davis", Address = "55 Elm Street", City = "Topeka", State = "KS", ZipCode = "66603", Gender = "F", BirthDate = new DateTime(1992, 12, 1), EmailAddress = "carold@gmail.com", HomePhone = "785-555-0129" },
                    new Customer { FirstName = "David", LastName = "Green", Address = "404 Notfound Blvd", City = "Hoboken", State = "NJ", ZipCode = "07030", Gender = "M", BirthDate = new DateTime(1978, 5, 19), EmailAddress = "davegreen@ymail.com", HomePhone = "201-555-0178" },
                    new Customer { FirstName = "Eva", LastName = "White", Address = "201 Imagination Way", City = "Orlando", State = "FL", ZipCode = "32801", Gender = "F", BirthDate = new DateTime(1985, 3, 29), EmailAddress = "evaw@gmail.com", HomePhone = "407-555-0225" }
                };

            context.Customers.AddRange(customers);


            var orders = new List<Order>
                {

                    new Order { OrderId = 1, OrderDate = new DateTime(2023, 11, 5), Amount = 150.00m, OrderType = "Online Purchase", Status = "Shipped" },
                    new Order { OrderId = 2, OrderDate = new DateTime(2023, 11, 4), Amount = 85.99m, OrderType = "In-Store Purchase", Status = "Completed" },
                    new Order { OrderId = 3, OrderDate = new DateTime(2023, 10, 22), Amount = 200.00m, OrderType = "Phone Order", Status = "Processing" },
                    new Order { OrderId = 4, OrderDate = new DateTime(2023, 11, 1), Amount = 300.00m, OrderType = "Service Charge", Status = "Completed" },
                    new Order { OrderId = 5, OrderDate = new DateTime(2023, 10, 15), Amount = 450.00m, OrderType = "Merchandise", Status = "Pending" }
                };
            context.Orders.AddRange(orders);


            var products = new List<Product>
                {
                    new Product { Name = "Premium Credit Card", Description = "Credit card with high rewards on travel and dining", InterestRate = 19.99m, Fee = 95.00m },
                    new Product { Name = "Standard Savings Account", Description = "No-fee savings account with a competitive interest rate", InterestRate = 1.25m, Fee = 0.00m },
                    new Product { Name = "Investment Fund", Description = "Diversified investment fund aiming for high long-term growth", InterestRate = 5.75m, Fee = 20.00m },
                    new Product { Name = "Mortgage Loan", Description = "30-year fixed-rate mortgage loan for new homeowners", InterestRate = 3.75m, Fee = 500.00m },
                    new Product { Name = "Auto Loan", Description = "Auto loan with flexible terms and competitive rates", InterestRate = 4.50m, Fee = 150.00m }
                };
            context.Products.AddRange(products);


            // Save changes to the database
            context.SaveChanges();
            }
        }
    }
}

