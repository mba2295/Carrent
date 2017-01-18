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

namespace CarRent.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Customers
        public IQueryable<Customers> GetCustomers(string query = null)
        {
            var customers = db.Customers.Include(c => c.membershipType);

            if (!String.IsNullOrWhiteSpace(query))
                customers = customers.Where(c => c.name.Contains(query));
            return customers;
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customers))]
        public IHttpActionResult GetCustomers(int id)
        {
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return NotFound();
            }

            return Ok(customers);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomers(int id, Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customers.id)
            {
                return BadRequest();
            }

            db.Entry(customers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersExists(id))
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

        // POST: api/Customers
        [ResponseType(typeof(Customers))]
        public IHttpActionResult PostCustomers(Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Customers.Add(customers);
            db.SaveChanges();

            return Created(new Uri(Request.RequestUri + "/" + customers.id), customers);
        }

        // DELETE: api/Customers/5
        [ResponseType(typeof(Customers))]
        public IHttpActionResult DeleteCustomers(int id)
        {
            Customers customers = db.Customers.Find(id);
            if (customers == null)
            {
                return NotFound();
            }

            db.Customers.Remove(customers);
            db.SaveChanges();

            return Ok(customers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomersExists(int id)
        {
            return db.Customers.Count(e => e.id == id) > 0;
        }
    }
}