using CarRent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRent.Dtos
{
    public class CustomerDto
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter Customer name"), StringLength(150)]
        public string name { get; set; }

        [MoreThan18YearAnnotation]
        public DateTime? dob { get; set; }

        public bool subscribedNewsLetter { get; set; }

        public byte membershipTypeId { get; set; }
    }
}