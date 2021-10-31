using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    /*
     *-IActionResult
       -ActionResult
       -ViewResult
       -PartialViewResult
       - .cshtml donderir esas istifade meqsedi UI-da mueyyen hissesin render olunmasidir,
       Normal ViewResult geri donerken UI -da umumi render prosesi bas verir ve sehife reload/refresh olunur.
       Partial View umumi olmadigindan sehifenin mueyyen hissesi , modal, popUP, Card ve sair oldugundan 
       geri donen deyer ajax vasitesile sadece hemin hissesinin renderine sebeb olur ve anliq deyisiklikleri 
       umumi sehife refresh olmadan gore bilirik.
       -JsonResult
       -EmptyResult
       -ContentResult
     */
    //[NonController]
    public class HomeController : Controller
    {
        //[NonAction]
        public IActionResult Index()
        {
            ViewResult viewResult = View();

            return viewResult;
        }

        public ActionResult IndexAction()
        {
            ViewResult viewResult = View();

            return viewResult;
        }


        public PartialViewResult IndexPartial()
        {
            return PartialView();
        }


        public JsonResult IndexJson()
        {
            return new JsonResult(new Blog(){Id = 1,Title = "first title",Description = "second description"});
        }

        public IActionResult IndexContent()
        {
            return Content("hello world");
        }
    }
}
