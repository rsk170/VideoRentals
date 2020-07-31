using AutoMapper;
using System.Web.Mvc;
using Vidly.Entities.Models;
using Vidly.Models;
using Vidly.ViewModels;
using Vidly.Services;
using Vidly.Services.Dto;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;

        private CustomersService _customers;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
            _customers = new CustomersService(_context);
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public void InitializeModel(CustomerViewModel model)
        {
            model.MembershipTypes = _customers.GetMembershipTypes();
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

            var dto = Mapper.Map<CustomerViewModel, CustomerDto>(model);

            _customers.SaveCustomer(dto);

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            Customer customer = _customers.GetCustomer(id);

            if (customer == null)
                return HttpNotFound();

            var model = Mapper.Map<Customer, CustomerViewModel>(customer);
            InitializeModel(model);

            return View("CustomerForm", model);
        }
    }
}