
//code located in the book for BaseEntity
using System;
using System.ComponentModel.DataAnnotations.Schema;
/// <summary>
///   Course Name: COSC 6360 Enterprise Architecture
///   Year: Fall 2023
///   Name: Matthew Valentino
///   Description: Example implementation of the Domain Driven Design Pattern.
///                https://en.wikipedia.org/wiki/Domain-driven_design                 
/// </summary>
public abstract class BaseEntity
{
    public BaseEntity()
    {
        this.CreatedOn = DateTime.Now;
        this.UpdatedOn = DateTime.Now;
        this.State = (int)EntityState.New;
    }

    public string CreatedBy { get; set; }
    public DateTime CreatedOn { get; set; }
    public string UpdatedBy { get; set; }
    public DateTime UpdatedOn { get; set; }
    
    [NotMapped]
    public int State { get; set; }

    public enum EntityState
    {
        New = 1,
        Update = 2,
        Delete = 3,
        Ignore = 4
    }
}
