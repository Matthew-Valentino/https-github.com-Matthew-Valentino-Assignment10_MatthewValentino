using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Bank4Us.Common.Core;
using Newtonsoft.Json;

namespace Bank4Us.Common.CanonicalSchema
{
    /// <summary>
    ///   COSC 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Matthew Valentino
    ///   Description: Assignment 7 focusing on creating Entity Framework Core
    /// </summary>
    /// 
    public class Customer : BaseEntity
    {
        [JsonIgnore]
        [Key]
        public int Id { get; set; }
        [MaxLength(255)]
        public string FirstName { get; set; }
        [MaxLength(255)]
        public string LastName { get; set; }
        [MaxLength(255)]
        public string EmailAddress { get; set; }
        public List<Account> Accounts { get; set; }
        public int Age { get; set; }
        public String IdentificationNumber { get; set; }
        public object Loans { get; set; }
    }
}
