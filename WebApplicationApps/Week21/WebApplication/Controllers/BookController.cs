using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class BookController : Controller
    {
        // GET: BookController
        /// <summary>
        /// Get All
        /// </summary>
        /// <returns></returns>
        public ActionResult Index()
        {
            return View(DataSource.Books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(string id)
        {
            var model = DataSource.Books.SingleOrDefault(i => i.Id == id);

            if (model != null) return View(model);

            ModelState.AddModelError("", "verilen id-ye uygun data tapilmadi");
            return View();

        }

        // GET: BookController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// v1
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        // POST: BookController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(string id, string name, string description, string status)
        //{
        //    try
        //    {
        //        var book = new Book
        //        {
        //            Id = id,
        //            Name = name,
        //            Description = description
        //        };
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        /// <summary>
        /// v2
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        // POST: BookController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create(IFormCollection collection)
        //{
        //    try
        //    {
        //        var id = collection["Id"];
        //        var name = collection["Name"];
        //        var desc = collection["Description"];
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        /// <summary>
        /// v3
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book model)
        {
            try
            {
                if (model == null)
                {
                    ModelState.AddModelError("", "model bos ola bilmez");

                    return View();
                }

                DataSource.Books.Add(model);

                return RedirectToAction(nameof(Index));//"Index"
            }
            catch
            {
                return View(model);
            }
        }

        // GET: BookController/Edit/5
        public ActionResult Edit(string id)
        {
            var model = DataSource.Books.SingleOrDefault(i => i.Id == id);

            if (model != null) return View(model);

            ModelState.AddModelError("", "model bos ola bilmez");
            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book model)
        {
            try
            {
                if (model == null)
                {
                    ModelState.AddModelError("", "model bos ola bilmez");
                    return View();
                }

                var book = DataSource.Books.SingleOrDefault(i => i.Id == model.Id);

                if (book == null)
                {
                    ModelState.AddModelError("", "verilen id-ye uygun data tapilmadi");

                    return View();
                }

                book.Name = model.Name;
                book.Description = model.Description;
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View(model);
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(string id)
        {
            var model = DataSource.Books.SingleOrDefault(i => i.Id == id);

            if (model != null) return View(model);

            ModelState.AddModelError("", "verilen id-ye uygun data tapilmadi");
            return View();

        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var model = DataSource.Books.SingleOrDefault(i => i.Id == id);

                if (model == null)
                {
                    ModelState.AddModelError("", "verilen id-ye uygun data tapilmadi");

                    return View();
                }

                DataSource.Books.Remove(model);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        /// <summary>
        /// QueryString  Example : bookquery?id=1&name=Book1&description=descBook
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="description"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult BookQuery(int id , string name , string description)
        {
            //QueryString
            //Request.QueryString
            //Request.Query
            var queryString = Request.QueryString;
            // queryString.HasValue == queryString == NULL return : true | false
            if (queryString.HasValue)
            {
                // code 
            }
            var bookId = Request.Query["id"];
            var bookName = Request.Query["name"];
            var bookDescription = Request.Query["description"];

            var foundedBook = DataSource.Books.SingleOrDefault(i => i.Id == bookId);

            var book = new Book
            {
                Id = bookId,
                Name = bookName,
                Description = bookDescription
            };

            //return View(foundedBook);
            //return Json(foundedBook);

            return new JsonResult(new
            {
                queryString,
                // action params
                id,
                name,
                description,
                // request.Query items
                bookId,
                bookName,
                bookDescription,

                book
            });
        }
        /// <summary>
        /// Route book/bookroute/1
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        public IActionResult BookRoute(string id)
        {
            // -Route
            //Request.RouteValues
            //    Tag Helper: asp - route

            var bookId = Request.RouteValues["id"];

            return new JsonResult(new
            {
                bookId,
                id,
            });
        }
        /// <summary>
        /// header : https://localhost:44377/book/bookheader
        ///
        /// https://go.postman.co/workspace/My-Workspace~8883c409-390d-4fdc-84ac-57e086b83442/collection/7051576-37fd2fdd-04fb-4f4f-80da-81bbecb0911b
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult BookHeader()
        {
            ////-Header
            ////Request.Headers

            var userToken = Request.Headers["user-token"];

            return new JsonResult(new
            {
                userToken
            });
        }


        










    }
}
