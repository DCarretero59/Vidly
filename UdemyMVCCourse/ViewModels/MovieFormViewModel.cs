using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UdemyMVCCourse.Models;

namespace UdemyMVCCourse.ViewModels
{
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }


        public string Title
        {
            get
            {
                return this.Movie.Id != 0 ? "Edit Movie" : "New Movie";
            }
        }

        public MovieFormViewModel()
        {
            this.Movie = new Movie();
        }

        public MovieFormViewModel(Movie movie)
        {
            this.Movie = movie;
        }
    }
}