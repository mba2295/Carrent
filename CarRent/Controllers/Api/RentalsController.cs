using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CarRent.Models;
using CarRent.Dtos;

namespace CarRent.Controllers.Api
{
    public class RentalsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private ApplicationDbContext _context;

        public RentalsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult CreateNewRentals(RentalDto newRental)
        {

            try
            {
                var customer = _context.Customers.Single(
c => c.id == newRental.CustomerId);


                var cars = _context.Car.Where(
m => newRental.CarIds.Contains(m.carId)).ToList();



                foreach (var car in cars)
                {
                    if (car.Available == false)
                        return BadRequest("Car is not available.");

                    car.Available = false;
                    _context.Entry(car).State = EntityState.Modified;

                    var rental = new Rental
                    {
                        Customer = customer,
                        Car = car,
                        DateRented = DateTime.Now
                    };

                    _context.Rental.Add(rental);
                }
            }
            catch (InvalidOperationException)
            {
                return BadRequest("Car or Customer is invalid.");
            }
            _context.SaveChanges();

            return Ok();
        }

    }
}