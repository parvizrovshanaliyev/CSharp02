using System.Collections.Generic;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Data;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class ViewDataTransferController : Controller
    {
        public IActionResult IndexViewData()
        {
            ViewData["products"] = DataSource.Products;
            return View();
        }

        public IActionResult IndexViewData2()
        {
            ViewData["products"] = DataSource.Products;
            return View();
        }


        public IActionResult IndexViewBag()
        {
            ViewBag.products = DataSource.Products;
            return View();
        }


        public IActionResult IndexTempData()
        {
            TempData["products"] = DataSource.Products;
            return View();
        }

        public IActionResult IndexTempData2()
        {
            var data = JsonSerializer.Serialize(DataSource.Products);

            TempData["products"] = data;

            return RedirectToAction("Redirect");
        }

        public IActionResult Redirect()
        {

           var data=TempData["products"].ToString();

           if (data != null)
           {
               List<Product> products = JsonSerializer.Deserialize<List<Product>>(data);
           }

           return View();
        }


        public IActionResult Tuple()
        {
            //(int a, int b) c = (5, 10);

            Product prod = new Product();
            //return View(new List<Product>());
            return View(prod);
        }
    }
}
