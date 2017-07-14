using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using UdemyMVCCourse.DbContext;
using UdemyMVCCourse.DTOs;
using UdemyMVCCourse.Models;

namespace UdemyMVCCourse.Api
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
            if (disposing)
            {
                _context.Dispose();
            }
            base.Dispose(disposing);
        }

        // GET: api/Movies
        public IEnumerable<MovieDto> GetMovies()
        {
            var movies = Mapper.Map<IEnumerable<MovieDto>>(_context.Movies.Include(m => m.Genre).ToList());
            return movies;
        }

        public IHttpActionResult GetMovies(string query)
        {
            var movies = _context.Movies
                .Where(m => m.Name.Contains(query))
                .Where(m => m.StockAvailable > 0)
                .ToList();
            if (!movies.Any())

            {
                return NotFound();
            }
            return Ok(Mapper.Map<IEnumerable<MovieDto>>(movies));
        }

        // GET: api/Movies/5
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<MovieDto>(movie));
        }

        // PUT: api/Movies/5
        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult UpdateMovie(int id, MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
            {
                return NotFound();
            }

            Mapper.Map(movieDto, movieInDb);
            _context.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Movies
        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult CreateMovie(MovieDto movieDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var movie = Mapper.Map<Movie>(movieDto);
            _context.Movies.Add(movie);
            _context.SaveChanges();

            movieDto.Id = movie.Id;

            return Created(new Uri(Request.RequestUri + "/" + movie.Id), movieDto);
        }

        // DELETE: api/Movies/5
        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMovies)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
            {
                return NotFound();
            }

            _context.Movies.Remove(movie);
            _context.SaveChanges();

            return Ok(Mapper.Map<MovieDto>(movie));
        }
        
    }
}