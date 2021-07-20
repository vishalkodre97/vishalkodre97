using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BooksController:Controller
    {
        private readonly BookRepository _bookRepository = null;

        public BooksController()
        {
            _bookRepository = new BookRepository();
        }
        public List<BookModel> GetAllBooks() {
            return _bookRepository.GetAllBooks();
        }

        public BookModel GetBook(int id)
        {
            return _bookRepository.GetBook(id);
        }

        public List<BookModel> SearchBooks(string bookName, string author)
        {
            return _bookRepository.SearchBooks(bookName,author);
        }
    }
}
