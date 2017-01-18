using CarRent.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRent.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable MembershipType { get; set; }
        public Customers customer { get; set; }
    }
}