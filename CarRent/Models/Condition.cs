using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRent.Models
{
    public class Condition
    {
        [Key]
        public int conditionId { get; set; }
        public string condtion { get; set; }
    }
}