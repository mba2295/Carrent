using CarRent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Web.Mvc;
using CarRent.ViewModels;

namespace CarRent.Controllers
{
    public class CarsController : Controller
    {
        ApplicationDbContext _dbContext;

        public CarsController()
        {
            _dbContext = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _dbContext.Dispose();
        }
        // GET: Cars
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.canAddCars))
                return View("Cars");

            return View("ReadOnlyCars");
        }

        public ActionResult Details(int id)
        {

            return View(_dbContext.Car.Include(Car => Car.carEngine).Include(Car => Car.condition).Include(Car => Car.carManufacturer).SingleOrDefault(Car => Car.carId == id));
        }


        [Authorize(Roles = RoleName.canAddCars)]
        public ActionResult New()
        {
            var engine = _dbContext.Engine.ToList();
            var manufacturer = _dbContext.Manufacturer.ToList();
            var condition = _dbContext.Condition.ToList();

            var carViewModel = new CarFormViewModel();
            carViewModel.carEngine = engine;
            carViewModel.carManufacturer = manufacturer;
            carViewModel.condition = condition;

            return View("CarForm", carViewModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Car car)
        {
            //ModelState.Remove("car.carId"); instead initalize car in New Action so that carId is initialized

            if (!ModelState.IsValid)
            {
                var carViewModel = new CarFormViewModel(car);


                carViewModel.carEngine = _dbContext.Engine.ToList();
                carViewModel.condition = _dbContext.Condition.ToList();
                carViewModel.carManufacturer = _dbContext.Manufacturer.ToList();

                return View("CarForm", carViewModel); ;
            }
            if (car.carId == 0)
            {
                _dbContext.Car.Add(car);
            }
            else
            {
                var carInDb = _dbContext.Car.SingleOrDefault(c => c.carId == car.carId);

                carInDb.model = car.model;
                carInDb.carYear = car.carYear;
                carInDb.conditionId = car.conditionId;
                carInDb.manufacturerId = car.manufacturerId;
                carInDb.engineId = car.engineId;

            }
            _dbContext.SaveChanges();
            return RedirectToAction("Index", "Cars");
        }

        public ActionResult Edit(int id)
        {
            var car = _dbContext.Car.SingleOrDefault(c => c.carId == id);
            if (car == null)
            {
                return HttpNotFound();
            }

            var carViewModel = new CarFormViewModel(car);
            carViewModel.carEngine = _dbContext.Engine.ToList();
            carViewModel.carManufacturer = _dbContext.Manufacturer.ToList();
            carViewModel.condition = _dbContext.Condition.ToList();


            return View("CarForm", carViewModel);

        }

        public ActionResult Delete(int id)
        {
            var car = _dbContext.Car.SingleOrDefault(c => c.carId == id);
            if (car == null)
            {
                return HttpNotFound();
            }
            else
            {
                _dbContext.Car.Remove(car);
                _dbContext.SaveChanges();
                return RedirectToAction("Index", "Cars");
            }
        }

    }
}
