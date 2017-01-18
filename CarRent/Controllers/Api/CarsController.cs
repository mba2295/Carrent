using System;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using CarRent.Models;
using System.Web.Routing;
using Glimpse.AspNet.Tab;
using System.Web;

namespace CarRent.Controllers.Api
{
    public class CarsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        

        // GET: api/Cars
        public IQueryable<Car> GetCar(string query = null)
        {
            var request = HttpContext.Current.Request;
            var cars = db.Car.Include(c => c.carManufacturer);
            try
            {
                if (request.UrlReferrer.ToString().Contains("Rentals/New"))
                {
                    cars = cars.Where(c => c.Available == true);

                }

                if (!String.IsNullOrWhiteSpace(query))
                    cars = cars.Where(c => c.model.Contains(query));


                return cars;
            }
            catch
            {
                return cars;
            }
        }

        // GET: api/Cars/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult GetCar(int id)
        {
            Car car = db.Car.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }

        // PUT: api/Cars/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCar(int id, Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != car.carId)
            {
                return BadRequest();
            }

            db.Entry(car).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Cars
        [ResponseType(typeof(Car))]
        public IHttpActionResult PostCar(Car car)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Car.Add(car);
            db.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + car.carId), car);

        }

        // DELETE: api/Cars/5
        [ResponseType(typeof(Car))]
        public IHttpActionResult Delete(int id)
        {
            Car car = db.Car.Find(id);
            if (car == null)
            {
                return NotFound();
            }

            db.Car.Remove(car);
            db.SaveChanges();

            return Ok(car);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CarExists(int id)
        {
            return db.Car.Count(e => e.carId == id) > 0;
        }
    }
}