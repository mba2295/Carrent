using CarRent.Models;
using System;
using System.ComponentModel.DataAnnotations;

public class Rental
{
    public int Id { get; set; }

    [Required]
    public Customers Customer { get; set; }

    [Required]
    public Car Car { get; set; }

    public DateTime DateRented { get; set; }

    public DateTime? DateReturned { get; set; }
}
