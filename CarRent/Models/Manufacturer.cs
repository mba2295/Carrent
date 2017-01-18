using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRent.Models
{
    public class Manufacturer
    {
        [Key]
        public int manufacturerId { get; set; }

        [StringLength(120)]
        public string manufacturerName { get; set; }

    }
}