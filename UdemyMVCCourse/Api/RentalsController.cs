using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using UdemyMVCCourse.DbContext;
using UdemyMVCCourse.DTOs;
using UdemyMVCCourse.Models;

namespace UdemyMVCCourse.Api
{
    public class RentalsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public RentalsController()
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

        [HttpPost]
        public IHttpActionResult SaveRental(RentalDto rentalDto)
        {

            //if (!rentalDto.MoviesIds.Any())
            //{
            //    return BadRequest("No Movie Ids have been given.");

            //}

            var customer = _context.Customers
                .Single(c => c.Id == rentalDto.CustomerId);

            //if (customer == null)
            //{
            //    return BadRequest("CustomerId is not valid.");
            //}

            var movies = _context.Movies
                .Where(m => rentalDto.MoviesIds.Contains(m.Id)).ToList();
            //if (movies.Count != rentalDto.MoviesIds.Count)
            //{
            //    return BadRequest("One or more Movie Ids are invalid.");
            //}


            foreach (var movie in movies)
            {
                if (movie.StockAvailable == 0)
                {
                    return BadRequest("Movie " + movie.Name + " is not available.");
                }
                _context.Rentals.Add(
                    new Rental
                    {
                        CustomerId = customer.Id,
                        MovieId = movie.Id,
                        DateRented = DateTime.Now
                    }
                );
                movie.StockAvailable--;
            }
            _context.SaveChanges();


            return Ok();
        }
    }
}
