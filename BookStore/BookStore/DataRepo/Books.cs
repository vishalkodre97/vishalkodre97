﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.DataRepo
{
    public class Books
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Catagory { get; set; }
        public int TotalPages { get; set; }
        public int LanguageId { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public string CoverImageUrl { get; set; }
        public Language Language { get; set; }
        public ICollection<BookImageGallery> bookImageGallery { get; set; }
    }
}
