using System;
using System.Text;
//note: following 2 namespaces are needed for defining relationships and constraints
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bank4Us.CanoncialSchema
{
    /// <summary>
    ///   Course Name: COSC 6360 Enterprise Architecture
    ///   Year: Fall 2023
    ///   Name: Matthew Valentino
    ///   Description: Example implementation of the Domain Driven Design Pattern.
    ///                https://en.wikipedia.org/wiki/Domain-driven_design                 
    /// </summary>
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        public decimal InterestRate { get; set; } 

        [Required]
        public decimal Fee { get; set; }  
    }
}
