using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookRepository _bookRepository = null;
        private readonly LanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;

        public BooksController(BookRepository bookRepository, 
           LanguageRepository languageRepository, IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;
            _webHostEnvironment = webHostEnvironment;
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
                if (bookModel.CoverImage != null)
                {
                    string folder = "booksImage/cover/";
                    bookModel.CoverImageUrl = await UploadImages(folder,bookModel.CoverImage);
                }
                if (bookModel.GalleryFiles != null)
                {
                    string folder = "booksImage/gallery/";
                    bookModel.Gallery = new List<GalleryModel>();
                    foreach (var file in bookModel.GalleryFiles)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            URL = await UploadImages(folder, file)
                        };
                        bookModel.Gallery.Add(gallery);
                    }
                    //bookModel.CoverImageUrl = await UploadImages(folder, bookModel.CoverImage);
                }

                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            ViewBag.Language = new SelectList(await _languageRepository.GetLanguages(), "Id", "Text");
            return View();
        }

        private async Task<string> UploadImages(string folderPath,IFormFile file)
        {

            folderPath += Guid.NewGuid() + "-" + file.FileName;
            
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);

            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));
            return "/"+folderPath;
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
