//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using VideoRent.Models;

//namespace VideoRent.Controllers
//{
//    public class ProductController : Controller
//    {

//        private ApplicationDbContext _context;

//        public ProductController()
//        {
//            _context = new ApplicationDbContext();
//        }

//        // GET: Product
//        public ActionResult Index()
//        {

//            var movie = _context.Movies.ToList();
//            return View(movie);
//        }

//        // GET: Product/Details/5
//        public ActionResult Details(int id)
//        {
//            return View();
//        }

//        // GET: Product/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Product/Create
//        [HttpPost]
//        public ActionResult Create(Movie movie)
//        {
//            try
//            {
//                // TODO: Add insert logic here
//                _context.Movies.Add(movie);
//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Product/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: Product/Edit/5
//        [HttpPost]
//        public ActionResult Edit(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add update logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Product/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: Product/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}
