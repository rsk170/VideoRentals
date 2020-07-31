using System.Collections.Generic;
using System.Linq;
using Vidly.Entities.Models;
using Vidly.Models;
using System.Data.Entity;
using AutoMapper;
using Vidly.Services.Dto;

namespace Vidly.Services
{
    public class CustomersService
    {
        private ApplicationDbContext _context;

        public CustomersService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public List<MembershipType> GetMembershipTypes()
        {
            return _context.MembershipTypes.ToList();
        }

        public List<CustomerListingItem> GetAllCustomers(string query = null)
        {
            var customersQuery = _context.Customers
                .Include(c => c.MembershipType);

            if (!string.IsNullOrWhiteSpace(query))
            {
                customersQuery = customersQuery.Where(
                    c => c.Name.Contains(query));
            }

            var customerListingItem = customersQuery.Select(c => new CustomerListingItem()
            {
                Id = c.Id,
                Name = c.Name,
                MembershipType = c.MembershipType.Name,
            });

            return customerListingItem.ToList();
        }

        public SaveCustomerResult SaveCustomer(CustomerDto model)
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
                if (!GetAllCustomers().Any(m => m.Id == model.Id))
                {
                    return SaveCustomerResult.NotFound;
                }

                customer = GetCustomer(model.Id);
                Mapper.Map(model, customer);
            }

            _context.SaveChanges();
            return SaveCustomerResult.Success;
        }
    }
}
