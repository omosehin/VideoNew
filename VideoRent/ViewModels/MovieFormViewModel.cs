using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VideoRent.Models;

namespace VideoRent.ViewModels
{
    
    public class MovieFormViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public int ? Id { get; set; }

        [Required]
        [StringLength(255)]

        public string Name { get; set; }

      
        [Display(Name = "Genre")]
        [Required]
        public byte ? GenreId { get; set; }


        [Required(ErrorMessage = "The Released field is required")]
        [Display(Name = "Released Date")]
        public DateTime ? ReleaseDate { get; set; }
        [Display(Name = "Number In Stock")]
        [Required(ErrorMessage = "The Number in Stock field is required")]

        [Range(1, 20)]
        public byte ? NumberInStock { get; set; }

        public string Title
        {
            get
            {
                    return Id != 0 ? "Edit Movie" :"New Movie";
            }
        }

        public MovieFormViewModel()
        {
            Id = 0; //default value to populate the id in view
            ReleaseDate = DateTime.Now;
            NumberInStock = 0;

        }
        public MovieFormViewModel(Movie movie)
        {
            Id = movie.Id;
            Name = movie.Name;
            ReleaseDate = movie.ReleaseDate;
            NumberInStock = movie.NumberInStock;
            GenreId = movie.GenreId; 
        }
    }
}