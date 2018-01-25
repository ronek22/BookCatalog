using BookCatalog.Helpers.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Models
{
    public class Book
    {
        public int BookId { get; set; }
        [StringLength(60, MinimumLength = 3)]
        [Capitalized]
        public string Title { get; set; }

        [Display(Name = "Number of pages")]
        [Range(1, 8000)]
        public int Length { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [NotFuture]
        public DateTime ReleaseDate { get; set; }

        [Range(1, 1000)]
        [DataType(DataType.Currency)]
        [Required]
        public decimal Price { get; set; }
        [Display(Name = "Author")]
        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}
