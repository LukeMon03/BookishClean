using Bookish.Net;
using Bookish.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Bookish.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        //cataloge page, duh
        public ActionResult Catalogue()
        {
            ViewBag.Message = "Your catalogue page.";
            var booksRepository = new BookRepository();
            var allBooks = booksRepository.GetAllBooks();

            return View(allBooks);
        }

        [HttpPost]
        public ActionResult Catalogue(SearchData searchData)
        {
            var bookRepository = new BookRepository();
            var searchbooks = bookRepository.SearchForBooks(searchData.SearchText);

            return View(searchbooks);
        }

        //This is needed for the homepage

        public ActionResult AddBook()
        {
            ViewBag.Message = "Add a book";
            return View("");
        }
        [HttpPost]
        public ActionResult AddBook(BookData bookData)
        {
            
            ViewBag.Message = "Add a book";
            var booksRepository = new BookRepository();
            booksRepository.AddBook(bookData.BookName, bookData.ISBN, bookData.Author);
            
            return View("");
        }
        public ActionResult GetAllUserCopies()
        {
            ViewBag.Message = "get all borrowed copies";
            var booksRepository = new BookRepository();
            // based on userid 
            int Kangaroo = 10000000;
            var getcopies = booksRepository.GetAllUserCopies(Kangaroo);

            return View(getcopies);
        }


    }
}