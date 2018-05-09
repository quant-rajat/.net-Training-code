using Library.Contracts.Services;
using Library.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        IBookServices bookService;
        public BookController(IBookServices BookService)
        {
            this.bookService = BookService;
        }


        // GET: Book
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        //POST: Book
        [HttpPost]
        public ActionResult Index(BookModel bookmodel)
        {
            Book book = null;
            
            if (ModelState.IsValid)
            {
               book= bookService.FindBookById(bookmodel.id);
                if (book != null)
                {
                   
                    return View();
                }
                else
                    return View(bookmodel.id);
            }
            else
            {
                ModelState.AddModelError("Login Error", "Invalid Id");
                return View(bookmodel.id);
            }
        }
        public ActionResult ListBooks()
        {
            List<Book> booklist = bookService.ListAllBooks();
            if (booklist == null)
            {
                return RedirectToAction("ShowBook", "Home");
            }
            else
            {
                return View(booklist);
            }

        }
       
    }
}