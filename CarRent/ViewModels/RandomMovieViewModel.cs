using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRent.ViewModels
{
    public class RandomMovieViewModel
    {
        public Car randomCar { get; set; }
        public List<Customers> customerList { get; set; }
    }
}