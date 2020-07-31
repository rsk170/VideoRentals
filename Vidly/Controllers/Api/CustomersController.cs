using AutoMapper;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Dtos;
using Vidly.Models;
using Vidly.Entities.Models;
using Vidly.Services;
using Vidly.Services.Dto;

namespace Vidly.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        private CustomersService _customers;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
            _customers = new CustomersService(_context);
        }

        //GET /api/customers
        public IHttpActionResult GetCustomers(string query = null)
        {
            var items = _customers.GetAllCustomers(query);
            return Ok(items);
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _customers.GetCustomer(id);

            if (customer == null)
                return NotFound();

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customerDto.Id), customerDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public IHttpActionResult UpdateCustomer(CustomerDto customerDto, int id)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var customerInDb = _customers.GetCustomer(id);

            if (customerInDb == null)
                return NotFound();

            Mapper.Map(customerDto, customerInDb); 

            _context.SaveChanges();
            return Ok();
        }

        //DELETE /api/customers/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _customers.GetCustomer(id);

            if (customerInDb == null)
                NotFound();

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}