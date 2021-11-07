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
        public ActionResult Index()
        {
            return View(DataSource.Books);
        }

        // GET: BookController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: BookController/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Book model)
        {
            try
            {

                DataSource.Books.Add(model);
                return RedirectToAction(nameof(Index));//"Index"
            }
            catch
            {
                return View();
            }
        }
        [HttpGet]
        public IActionResult BookQuery(int id , string name , string description)
        {
            //QueryString
            //Request.QueryString
            //Request.Query

            var queryString = Request.QueryString;
            if (queryString.HasValue)
            {
                // code 
            }
            //var id = Request.Query["id"];
            //var name = Request.Query["name"];
            //var description = Request.Query["description"];
            return new JsonResult(new
            {
                queryString,
                id,
                name,
                description
            });
        }
        //public ActionResult Create(int id, string name, string description, string status)
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

        // GET: BookController/Edit/5
        public ActionResult Edit(int id)
        {

            //-Route
            //Request.RouteValues
            //    Tag Helper: asp - route

            var bookId = Request.RouteValues["id"];


            //-Header
            //Request.Headers

            var userToken = Request.Headers["user-token"];

            return View();
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
