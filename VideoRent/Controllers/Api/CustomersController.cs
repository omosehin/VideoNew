using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRent.App_Start;
using VideoRent.Dtos;
using VideoRent.Models;
using System.Data.Entity;

namespace VideoRent.Controllers.Api
{
    public class CustomersController : ApiController 
    {

        

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext( );

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }
        //GET  /api/customers
        public IHttpActionResult GetCustomers()
        {
            var customers = from b in _context.Customers
                            select new CustomerDto()
                            {
                                Id = b.Id,
                                Name = b.Name,
                                Birthdate = b.Birthdate,
                                IsSubscribedNewsLetter = b.IsSubscribedNewsLetter,
                            }; 
            return Ok(customers); 
          
            // return _context.Customers.ToList();
        }


        //GET  /api/customers/1 
        public CustomerDto GetCustomer(int id)

        {

            var customer = _context.Customers
                .Include(b => b.Name)
                .Select(b => new CustomerDto()
            {
                Id = b.Id,
                Name = b.Name,
                Birthdate = b.Birthdate,
                IsSubscribedNewsLetter = b.IsSubscribedNewsLetter
            }).SingleOrDefault(b => b.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return customer;
            /*
            var customer = _context.Customers.SingleOrDefault(c=>c.Id==id);
              if(customer == null)
                    throw new HttpResponseException(HttpStatusCode.NotFound);

    */

        }

        //POST /api/customers

            [HttpPost]
        public Customer CreateCustomer(Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

           
            
           _context.Customers.Add(customer);
           _context.SaveChanges();

            return customer;

        }



        //PUT  /api/customers/1
        [HttpPut]
        public Customer UpdateCustomer(int id, Customer customer)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribedNewsLetter = customer.IsSubscribedNewsLetter;
            customerInDb.MembershipType = customer.MembershipType;

            _context.SaveChanges();

            return customer;
        }

        //DELETE /api/Customers/1

        public void DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);
            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

        }


    }
}
