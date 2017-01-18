using CarRent.Models;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CarRent.ViewModels;

namespace CarRent.Controllers
{
    public class CustomersController : Controller
    {

        ApplicationDbContext _dbContext;
        public CustomersController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        // GET: Customers
        public ActionResult Index()
        {
            //return View(_dbContext.Customers.Include(c => c.membershipType).ToList());
            //returning null because ajax call is filling the view using the api
            return View();

        }

        public ActionResult Detail(int id)
        {
            var customer = _dbContext.Customers.Include(c => c.membershipType).SingleOrDefault(c => c.id == id);
            return View(customer);
        }

        public ActionResult New()
        {
            var membershipTypes = _dbContext.membershipType.ToList();
            var newCustomer = new CustomerFormViewModel();
            newCustomer.MembershipType = membershipTypes;
            newCustomer.customer = new Customers();
            return View("CustomerForm", newCustomer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.id == id);

            if (customer == null)
            {
                return HttpNotFound();
            }

            var customerViewModel = new CustomerFormViewModel();
            customerViewModel.customer = customer;
            customerViewModel.MembershipType = _dbContext.membershipType.ToList();

            return View("CustomerForm", customerViewModel);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customers customer)
        {
            //ModelState.Remove("customer.id"); instead initalize customer in New Action so that id is initialized
            if (!ModelState.IsValid)
            {
                var CustomerFormView = new CustomerFormViewModel();
                CustomerFormView.customer = customer;
                CustomerFormView.MembershipType = _dbContext.membershipType.ToList();
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return View("CustomerForm", CustomerFormView);
            }

            if (customer.id == 0)
            {
                _dbContext.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _dbContext.Customers.SingleOrDefault(c => c.id == customer.id);

                customerInDb.name = customer.name;
                customerInDb.dob = customer.dob;
                customerInDb.membershipTypeId = customer.membershipTypeId;
                customerInDb.subscribedNewsLetter = customer.subscribedNewsLetter;

            }

            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Customers");
        }


        public ActionResult Delete(int id)
        {
            var customer = _dbContext.Customers.SingleOrDefault(c => c.id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            else
            {
                _dbContext.Customers.Remove(customer);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Customers");
            }
        }




        //private IEnumerable<Customers> getCustomers()
        //{
        //    return new List<Customers>
        //    {
        //        new Customers {id=1,name="MBA"}
        //    };
        //}
    }
}