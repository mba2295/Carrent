using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRent.Models
{
    public class MoreThan18YearAnnotation : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customers)validationContext.ObjectInstance;
            if (customer.membershipTypeId == MembershipType.Unknown || customer.membershipTypeId == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            else if (customer.dob == null)
            {
                return new ValidationResult("Date of Birth Required");
            }
            else
            {
                var age = DateTime.Today.Year - customer.dob.Value.Year;
                return (age > 18) ? ValidationResult.Success : new ValidationResult("Must be atleast 18 years old for Memberships except Pay as you Go");

            }
        }
    }
}