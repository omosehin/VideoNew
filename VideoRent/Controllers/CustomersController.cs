using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using VideoRent.Models;
using VideoRent.ViewModels;

namespace vidil.Controllers
{
    public class CustomersController : Controller
    {

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //we needed to dispose the db
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

          public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();

            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(), //wen we instantiate this customer here it value will be set to their default values this will resolve error of Id being validated
                MembershipTypes = membershipTypes
                
            };
            return View("CustomerForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Customer customer) //Model binding,MVC binds request data to this object
        {
            //validation
            if (!ModelState.IsValid) //return the normal view if not valid
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            };

            if(customer.Id == 0) //insert an hidden id in your view
            {
                
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedNewsLetter = customer.IsSubscribedNewsLetter;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
            public ActionResult Index()
        {

            // var customers = _context.Customers.ToList();//Immediately called the database instead of deffered excution which can be done through a foreach TO get customer Info only
             var customers = _context.Customers.Include(c =>c.MembershipType).ToList();//Immediately called the database instead of deffered excution which can be done through a foreach TO get customer Info only
            return View(customers);

        }

        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            var memberShipTypes = _context.MembershipTypes.ToList();
            if (customer == null)
            {
                return HttpNotFound(); //404 error
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = memberShipTypes
            };

            return View("CustomerForm",viewModel); //this will look for the view called new ,customerForm is the view name
        }



    }
}
