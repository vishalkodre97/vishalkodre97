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
                Author=model.Author,
                Description = model.Description,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                UpdatedOn = DateTime.UtcNow,
                CoverImageUrl=model.CoverImageUrl,
                BookPdfURL=model.BookPdfURL
               
            };

            newBook.bookImageGallery = new List<BookImageGallery>();
            foreach (var file in model.Gallery)
            {
                newBook.bookImageGallery.Add(new BookImageGallery 
                { 
                Name=file.Name,
                URL=file.URL
                });
            }
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooks()
        {            
            return await _context.Books.Select(book => new BookModel() {
                Author = book.Author,
                Title = book.Title,
                Description = book.Description,
                Id = book.Id,
                LanguageId = book.LanguageId,
                TotalPages = book.TotalPages,
                Catagory = book.Catagory,
                CoverImageUrl = book.CoverImageUrl
            }).ToListAsync();
        }

        public async Task<List<BookModel>> GetTopBooks(int count)
        {
            return await _context.Books.Select(book => new BookModel()
            {
                Author = book.Author,
                Title = book.Title,
                Description = book.Description,
                Id = book.Id,
                LanguageId = book.LanguageId,
                TotalPages = book.TotalPages,
                Catagory = book.Catagory,
                CoverImageUrl = book.CoverImageUrl
            }).Take(count).ToListAsync();
        }
        public async Task<BookModel> GetBook(int id)
        {
            return await _context.Books.Where(x => x.Id == id)
                .Select(book => new BookModel() {
                    Author = book.Author,
                    Title = book.Title,
                    Description = book.Description,
                    LanguageId = book.LanguageId,
                    Language = book.Language.Text,
                    TotalPages = book.TotalPages,
                    Catagory = book.Catagory,
                    CoverImageUrl = book.CoverImageUrl,
                    Gallery = book.bookImageGallery.Select(g => new GalleryModel()
                    {
                        Id = g.Id,
                        Name = g.Name,
                        URL = g.URL

                    }).ToList(),
                    BookPdfURL=book.BookPdfURL
                }).FirstOrDefaultAsync();                
        }
        public List<BookModel> SearchBooks(string title, string authorName)
        {
            return null;
        }
       
    }
}
