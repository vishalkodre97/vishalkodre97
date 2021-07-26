using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;

        public BooksController(BookRepository bookRepository, LanguageRepository languageRepository)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
        }

        public async Task<ViewResult> AddNewBook(bool isSuccess=false, int bookId=0)
        {
            var model = new BookModel();
            ViewBag.Language =new SelectList(await _languageRepository.GetLanguages(),"Id","Text");
            ViewBag.IsSuccess = isSuccess;
            ViewBag.Id = bookId;
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Text");
            return View();
        }
        public async Task<ViewResult> GetAllBooks() {
            var books =await _bookRepository.GetAllBooks();
            return View(books);
        }

        [RouteAttribute("Book-Details/{id}",Name ="BookDetails")]
        public async Task<ViewResult> GetBook(int id)
        {
            var book=await _bookRepository.GetBook(id);
            return View(book);
        }

        public List<BookModel> SearchBooks(string bookName, string author)
        {
            return _bookRepository.SearchBooks(bookName,author);
        }
    }
}
