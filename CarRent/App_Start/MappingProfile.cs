using CarRent.Models;
using CarRent.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarRent.App_Start
{
    public class MappingProfile:AutoMapper.Profile
    {
       public MappingProfile()
        {
            CreateMap<Customers, CustomerDto>();

            CreateMap<CustomerDto, Customers>();
        }
    }
}