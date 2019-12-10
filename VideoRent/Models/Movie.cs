using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VideoRent.Models
{
    public class Movie
    {
        public int Id { get; set; }

        [Required(ErrorMessage="The Name field is required")]
        [StringLength(255)]

        public string Name { get; set; }
        public Genre Genre { get; set; }

        [Display(Name = "Genre")]
        [Required(ErrorMessage = "The Genre field is required")]
        public byte GenreId { get; set; }

        public DateTime  ? DateAdded { get; set; }

        [Required(ErrorMessage = "The Released field is required")]
        [Display(Name ="Released Date")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Number In Stock")]
        [Required(ErrorMessage = "The Number in Stock field is required")]

        [Range(1,10)]
        public byte NumberInStock { get; set; }
    }
}