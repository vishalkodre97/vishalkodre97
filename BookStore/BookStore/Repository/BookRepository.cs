using BookStore.DataRepo;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;

        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Title = model.Title,
                LanguageId=model.LanguageId,
                Catagory=model.Catagory,
                CreatedOn = DateTime.UtcNow,
                Description = model.Description,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow
            };
            _context.Books.Add(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {
            var books = new List<BookModel>();
            var allBooks = await _context.Books.ToListAsync();
            if (allBooks?.Any() == true)
            {
                foreach (var book in allBooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Title = book.Title,
                        Description = book.Description,
                        Id = book.Id,
                        LanguageId = book.LanguageId,                        
                        TotalPages = book.TotalPages,
                        Catagory = book.Catagory
                    });
                }
            }
            return books;
        }

        public async Task<BookModel> GetBook(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(book=> new BookModel() {
                    Author = book.Author,
                    Title = book.Title,
                    Description = book.Description,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Text,
                    TotalPages = book.TotalPages,
                    Catagory = book.Catagory
                }).FirstOrDefaultAsync();                
        }

        public List<BookModel> SearchBooks(string title, string authorName)
        {
            return null;
        }
       
    }
}
