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
        private Customer GetCustomer(int id)
        {
            return _context.Customers.Single(c => c.Id == id);
        }

        private void InitializeModel(CustomerViewModel model)
        {
            model.MembershipTypes = _context.MembershipTypes.ToList();
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

            SaveCustomer(model);

            return RedirectToAction("Index", "Customers");
        }

        private void SaveCustomer(CustomerViewModel model)
        {
            Customer customer;
            if (model.Id == 0)
            {
                customer = new Customer();
                Mapper.Map(model, customer);
                _context.Customers.Add(customer);
            }
            else
            {
                customer = GetCustomer(model.Id);
                Mapper.Map(model, customer);
            }

            _context.SaveChanges();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            Customer customer = GetCustomer(id);

            if (customer == null)
                return HttpNotFound();

            var model = Mapper.Map<Customer, CustomerViewModel>(customer);
            InitializeModel(model);

            return View("CustomerForm", model);
        }
    }
}