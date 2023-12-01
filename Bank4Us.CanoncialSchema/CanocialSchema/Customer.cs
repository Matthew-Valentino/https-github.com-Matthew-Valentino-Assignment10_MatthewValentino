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
    public class Customer
    {
        //used this link to figure out how to create primary key in c#: https://stackoverflow.com/questions/60663277/databasegenerateddatabasegeneratedoption-identity-vs-key
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CustomerId { get; set; }
        //used same link to figure out how to properly add string length and required
        [Required]
        [StringLength(255)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string City { get; set; }

        [StringLength(2)]
        public string State { get; set; }

        [StringLength(10)]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(1)]
        //creating an error message if M or F isnt input for gender
        [RegularExpression("M|F", ErrorMessage ="Must input gender as M or F")]
        public string Gender { get; set; }

        public DateTime? BirthDate { get; set; }

        [StringLength(50)]
        public string EmailAddress { get; set; }

        [StringLength(15)]
        public string HomePhone { get; set; }

        public Account Account
        {
            get => default;
            set
            {
            }
        }
    }
}
