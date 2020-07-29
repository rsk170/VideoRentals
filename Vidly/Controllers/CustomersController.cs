using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Entities.Models;
using Vidly.Models;
using Vidly.ViewModels;


namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult New()
        {
            var model = new CustomerViewModel();

            InitializeModel(model);

            return View("CustomerForm", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(CustomerViewModel model)
        {
            if (!ModelState.IsValid)
            {
                InitializeModel(model);
                return View("CustomerForm", model);
            }

            Customer customer;
            if (model.Id == 0)
            {
                customer = new Customer();
                Mapper.Map(model, customer);
                _context.Customers.Add(customer);
            }
            else
            {
                customer = _context.Customers.Single(c => c.Id == model.Id);
                Mapper.Map(model, customer);
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return HttpNotFound();

            var model = Mapper.Map<Customer, CustomerViewModel>(customer);
            InitializeModel(model);

            return View("CustomerForm", model);
        }

        private void InitializeModel(CustomerViewModel model)
        {
            model.MembershipTypes = _context.MembershipTypes.ToList();
        }
    }
}