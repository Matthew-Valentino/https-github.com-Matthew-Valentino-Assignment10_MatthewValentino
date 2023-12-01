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
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [Required]
        public int AccountId { get; set; }

        public int CustomerId { get; set; }
       
        [ForeignKey("AccountId")]
        public virtual Account Account { get; set; }

        public DateTime OrderDate { get; set; }//datetime is used to get the information on when an order was made

        [Required]
        public decimal Amount { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string OrderType { get; set; } 

        [StringLength(50)]
        public string Status { get; set; }  // Status of order

        public Customer Customer
        {
            get => default;
            set
            {
            }
        }

        public Product Product
        {
            get => default;
            set
            {
            }
        }
    }
}
