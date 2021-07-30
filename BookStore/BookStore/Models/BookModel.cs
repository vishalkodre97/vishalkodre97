using BookStore.Helpers;
using Microsoft.AspNetCore.Http;
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
        [StringLength(100,MinimumLength=5,ErrorMessage ="length should be grater than 5")]
        [Required(ErrorMessage ="Please enter title")]
        [NewCustomValidation()]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter author")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Catagory { get; set; }
        [Required (ErrorMessage ="Please enter total pages")]
        public int? TotalPages { get; set; }
        [Display (Name="Select Language")]
        public int LanguageId { get; set; }
        public string Language { get; set; }
        public IFormFile CoverImage { get; set; }
        public string CoverImageUrl { get; set; }
        [Display(Name ="Select multiple image gallery")]
        public IFormFileCollection GalleryFiles { get; set; }
        public List<GalleryModel> Gallery { get; set; }
        [Display(Name = "Upload book pdf file")]
        public IFormFile BookPdf { get; set; }
        public string BookPdfURL { get; set; }
       
    }
}
