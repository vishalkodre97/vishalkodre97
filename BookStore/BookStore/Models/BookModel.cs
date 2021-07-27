using BookStore.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Please enter title")]
        [NewCustomValidation()]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter author")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Catagory { get; set; }
        [Required (ErrorMessage ="Please enter total pages")]
        public int? TotalPages { get; set; }
        public int LanguageId { get; set; }
        public string Language { get; set; }
    }
}
