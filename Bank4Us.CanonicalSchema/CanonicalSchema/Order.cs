using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Bank4Us.Common.Core;
using Newtonsoft.Json;


namespace Bank4Us.Common.CanonicalSchema
{    /// <summary>
     ///   COSC 6360 Enterprise Architecture
     ///   Year: Fall 2023
     ///   Name: Matthew Valentino
     ///   Description: Assignment 7 focusing on creating Entity Framework Core
     /// </summary>
     /// 
    public class Order : BaseEntity
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public List<Product> Products { get; set; }

        public bool IsDeposit()
        {
            throw new NotImplementedException();
        }

        public bool IsWithinProcessingTime()
        {
            throw new NotImplementedException();
        }
    }
}
