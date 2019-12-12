using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VideoRent.Models;

namespace VideoRent.Controllers.Api
{
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();

        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();

        }

        [HttpGet]
        //api/Movies
        public IHttpActionResult GetMovie()
        {
            return Ok(_context.Movies.ToList());
        }

        //api/Movies/1

        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movie == null)
            {
               return Content(HttpStatusCode.NotFound,"Movie not found") ;
            }
            return  Ok(movie);

        }

        [HttpPost]
        //api/Movies

        public IHttpActionResult CreateMovie(Movie movie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            _context.Movies.Add(movie);
            _context.SaveChanges();
            return Created(new Uri(Request.RequestUri + "/" + movie.Id) ,movie);
        }

        [HttpPut]
        public Movie UpdateMovie(int id,Movie movie)
        {
            if (!ModelState.IsValid)
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            var movieInDb = _context.Movies.SingleOrDefault(c => c.Id == id);
            if (movieInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            movieInDb.Name = movie.Name;
            _context.SaveChanges();


            return movie;
        }

        [HttpDelete]

        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.Find(id);
            if (movie == null)
            {
                return Content(HttpStatusCode.NotFound, "Movie not found");
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return Ok(movie);

        }
    }
}
