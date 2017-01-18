using CarRent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRent.ViewModels
{
    public class CarFormViewModel
    {

        public IEnumerable<Manufacturer> carManufacturer { get; set; }
        public IEnumerable<Engine> carEngine { get; set; }
        public IEnumerable<Condition> condition { get; set; }

        public int? carId { get; set; }

        [Required(ErrorMessage = "Please enter Model Name")]
        public string model { get; set; }

        public int? manufacturerId { get; set; }



        public int? engineId { get; set; }



        public DateTime? carYear { get; set; }

        public int? conditionId { get; set; }

        public CarFormViewModel()
        {
            carId = 0;
        }

        public CarFormViewModel(Car car)
        {
            this.carId = car.carId;
            this.model = car.model;
            this.manufacturerId = car.manufacturerId;
            this.engineId = car.engineId;
            this.carYear = car.carYear;
            this.conditionId = car.conditionId;
        }



    }
}