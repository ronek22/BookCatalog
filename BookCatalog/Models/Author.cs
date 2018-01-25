using BookCatalog.Helpers.Validators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Display(Name = "First Name")]
        [StringLength(20, MinimumLength = 2)]
        [Capitalized]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [StringLength(20, MinimumLength = 2)]
        [Capitalized]
        public string LastName { get; set; }

        public List<Book> Books { get; set; }

    }
}
