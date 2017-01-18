using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRent.Models
{
    public class Customers
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Please enter Customer name"), StringLength(150)]
        [Display(Name = "Name")]
        public string name { get; set; }

        [Display(Name = "Date of Birth")]
        [MoreThan18YearAnnotation]
        public DateTime? dob { get; set; }

        [Display(Name = "Subscribe to News Letter")]
        public bool subscribedNewsLetter { get; set; }
        public MembershipType membershipType { get; set; }
        public byte membershipTypeId { get; set; }

    }
}