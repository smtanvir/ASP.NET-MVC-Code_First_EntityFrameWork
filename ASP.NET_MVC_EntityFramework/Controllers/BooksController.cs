using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASP.NET_MVC_EntityFramework.Models;
using ASP.NET_MVC_EntityFramework.Models.ViewModels;

namespace ASP.NET_MVC_EntityFramework.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        BookDbContext db = new BookDbContext();

        //Get Books
        [AllowAnonymous]
        public ActionResult Index()
        {
            //return View(db.Books.ToList());
            return View(db.Books.Include("Publisher").ToList());
        }

        //Insert: Books
        public ActionResult Create()
        {
            ViewBag.Publishers = new SelectList(db.Publishers, "Id", "PublisherName");
            return View();
        }
        [HttpPost]
        public ActionResult Create(BookViewModel bookView)
        {
            if (ModelState.IsValid)
            {
                if (bookView.CvImage != null)
                {
                    string filepath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(bookView.CvImage.FileName));
                    bookView.CvImage.SaveAs(Server.MapPath(filepath));

                    Book book = new Book
                    {
                        BookName = bookView.BookName,
                        AuthorName = bookView.AuthorName,
                        PublishDate = bookView.PublishDate,
                        PublisherId = bookView.PublisherId,
                        Price = bookView.Price,
                        CoverImage = filepath
                    };
                    db.Books.Add(book);
                    db.SaveChanges();
                    return PartialView("_Success");
                }
                else
                {
                    return PartialView("_Error");
                }
            }
            ViewBag.Publishers = new SelectList(db.Publishers, "Id", "PublisherName");
            return View(bookView);
        }

        //Update: Books
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            BookViewModel bookViewModel = new BookViewModel()
            {
                BookId = book.Id,
                BookName = book.BookName,
                AuthorName = book.AuthorName,
                PublishDate = book.PublishDate,
                PublisherId = book.PublisherId,
                Price = book.Price,
                CoverImagePath = book.CoverImage
            };
            ViewBag.Publishers = new SelectList(db.Publishers, "Id", "PublisherName", bookViewModel.PublisherId);
            return View(bookViewModel);
        }

        [HttpPost]
        public ActionResult Edit(BookViewModel bookView)
        {
            if (ModelState.IsValid)
            {
                string filepath = bookView.CoverImagePath;
                if (bookView.CvImage != null)
                {
                    filepath = Path.Combine("~/Images", Guid.NewGuid().ToString() + Path.GetExtension(bookView.CvImage.FileName));
                    bookView.CvImage.SaveAs(Server.MapPath(filepath));

                    Book book = new Book
                    {
                        Id = bookView.BookId,
                        BookName = bookView.BookName,
                        AuthorName = bookView.AuthorName,
                        PublishDate = bookView.PublishDate,
                        PublisherId = bookView.PublisherId,
                        Price = bookView.Price,
                        CoverImage = filepath
                    };
                    db.Entry(book).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index", "Books");
                }
                else
                {
                    Book book = new Book
                    {
                        Id = bookView.BookId,
                        BookName = bookView.BookName,
                        AuthorName = bookView.AuthorName,
                        PublishDate = bookView.PublishDate,
                        PublisherId = bookView.PublisherId,
                        Price = bookView.Price,
                        CoverImage = filepath
                    };
                    db.Entry(book).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index", "Books");
                }

            }
            ViewBag.Publishers = new SelectList(db.Publishers, "Id", "PublisherName", bookView.PublisherId);
            return View(bookView);
        }


        public ActionResult Delete(int id)
        {
            Book book = db.Books.Find(id);
            string fileName = book.CoverImage;
            string filePath = Server.MapPath(fileName);
            FileInfo file = new FileInfo(filePath);
            if (file.Exists)
            {
                file.Delete();
            }
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index", "Books");
        }
    }
}