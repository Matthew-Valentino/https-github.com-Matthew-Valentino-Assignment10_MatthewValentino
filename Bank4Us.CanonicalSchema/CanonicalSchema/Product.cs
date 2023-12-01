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
    public class Product : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}

