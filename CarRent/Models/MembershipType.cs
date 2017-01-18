using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CarRent.Models
{
    public class MembershipType
    {
        [Key]
        public byte id { get; set; }
        public short signUpFee { get; set; }
        public short durationInMonths { get; set; }
        public byte discountRate { get; set; }
        [Required]
        public string name { get; set; }

        public static readonly int Unknown = 0;
        public static readonly int PayAsYouGo = 1;



    }
}