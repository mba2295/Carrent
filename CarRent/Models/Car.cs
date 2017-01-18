using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarRent.Models
{
    public class Car
    {
        [Key]
        public int carId { get; set; }

        [Required(ErrorMessage ="Please enter Model Name")]
        public string model { get; set; }

        public int manufacturerId { get; set; }

        [ForeignKey("manufacturerId")]
        public Manufacturer carManufacturer { get; set; }


        public int engineId { get; set; }


        [ForeignKey("engineId")]
        public Engine carEngine { get; set; }

        public DateTime carYear { get; set; }

        public int conditionId { get; set; }

        [ForeignKey("conditionId")]
        public Condition condition { get; set; }

        public bool Available { get; set; }

    }
}