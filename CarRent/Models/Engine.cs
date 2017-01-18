using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRent.Models
{
    public class Engine
    {
        public int engineId { get; set; }
        public int CC { get; set; }

        public static implicit operator Engine(List<Engine> v)
        {
            throw new NotImplementedException();
        }
    }
}