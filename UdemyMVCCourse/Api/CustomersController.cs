using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Data.Entity;
using System.Net.Http;
using System.Security.Policy;
using System.Web.Http;
using AutoMapper;
using UdemyMVCCourse.DbContext;
using UdemyMVCCourse.DTOs;
using UdemyMVCCourse.Models;

namespace UdemyMVCCourse.Api
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        //GET /api/customers
        public IEnumerable<CustomerDto> GetCustomers()
        {

            var customersInDb = _context.Customers.Include(c => c.MembershipType).ToList();
            var customersDtos = Mapper.Map<IEnumerable<CustomerDto>>(customersInDb);
            return customersDtos;
        }

        //GET /api/customers/1
        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<CustomerDto>(customer));
        }


        public IHttpActionResult GetCustomers(string query)
        {
            var customers = _context.Customers.Where(c => c.Name.Contains(query)).ToList();
            if (!customers.Any())

            {
                return NotFound();
            }
            return Ok(Mapper.Map<IEnumerable<CustomerDto>>(customers));
        }

        //POST /api/customers
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customer = Mapper.Map<Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        //PUT /api/customers/1
        [HttpPut]
        public void UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

        }

        //DELETE /api/customers/1
        [HttpDelete]
        public void DeleteCustomer(int id)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Customers.Remove(customerInDb);

            _context.SaveChanges();

        }
    }
}
