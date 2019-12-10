using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VideoRent.Models;
using VideoRent.ViewModels;

namespace VideoRent.Controllers
{

    public class MoviesController : Controller
    {
        // GET: Movies


        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }

        public ActionResult New()
        {
            var genre = _context.Genres.ToList();

            var viewModel = new MovieFormViewModel
            {
                Genres = genre
            };

            return View("MovieForm", viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save( Movie movie)
        {
           
            if (!ModelState.IsValid)
            {
                var viewModel = new MovieFormViewModel(movie)
                {
                    Genres = _context.Genres.ToList()
                };
                return View("MovieForm", viewModel);
            }
            
            if (movie.Id == 0 )
            {
                movie.ReleaseDate = DateTime.Now;
                _context.Movies.Add(movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(c => c.Id == movie.Id);
                movieInDb.Name = movie.Name;
                movieInDb.GenreId = movie.GenreId;
                movieInDb.NumberInStock = movie.NumberInStock;
                movieInDb.ReleaseDate = movie.ReleaseDate;
                //_context.Movies.Add(movie);
            }
                _context.SaveChanges();
                return RedirectToAction("Index", "Movies");
        }
        public ActionResult Index()
        {
            var movie = _context.Movies.Include(c => c.Genre).ToList().OrderBy(c=>c.Name);
            return View(movie);
        }

        public ActionResult Detail(int id)
        {
            var movieDetail = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieDetail == null)
            {
                return HttpNotFound();
            }
            return View(movieDetail);
        }

        public ActionResult Edit(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c=>c.Id == id);
            var genre = _context.Genres.ToList();

            if (movie == null)
            {
                return HttpNotFound();
            }
            var viewModel = new MovieFormViewModel(movie)
            {
                Genres = genre,
            };

            return View("MovieForm",viewModel);
        }
    }

}