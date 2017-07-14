using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using UdemyMVCCourse.Models;

namespace UdemyMVCCourse.DTOs
{
    public class RentalDto
    {
        [Required]
        public int CustomerId { get; set; }

        [Required]
        public List<int> MoviesIds { get; set; }
    }
}