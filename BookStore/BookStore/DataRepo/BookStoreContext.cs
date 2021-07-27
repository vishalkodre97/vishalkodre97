using BookStore.DataRepo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore
{
    public class BookStoreContext:DbContext
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            :base(options)
        {
                
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Language> Language { get; set; }
        public DbSet<BookImageGallery> BookImageGallery { get; set; }


    }
}
