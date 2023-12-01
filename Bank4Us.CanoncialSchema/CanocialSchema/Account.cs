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
    public class Account
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AccountId { get; set; }

        [Required]
        public int CustomerId { get; set; }

        //This link taught me how to use foreign keys in C#: https://www.entityframeworktutorial.net/code-first/foreignkey-dataannotations-attribute-in-code-first.aspx
        [ForeignKey("CustomerId")]
        public virtual Customer Customer { get; set; }

        public DateTime OpenDate { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression("Checking|Savings|Brokerage", ErrorMessage = "AccountType must be either 'Checking', 'Savings', or 'Brokerage'")]
        public string AccountType { get; set; }

        [Required]
        public decimal Balance { get; set; }

        [StringLength(255)]
        public string Comment { get; set; }
    }
}
