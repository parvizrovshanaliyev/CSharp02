using Blog.Entities.Concrete;
using Blog.Entities.Dtos.Post;
using Blog.Services.Abstract;
using Blog.Shared.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using NToastNotify;
using System.Threading.Tasks;

namespace Blog.WebAPP.CORE.MVC.Controllers
{
    public class HomeController : Controller
    {
        #region fields

        private readonly IPostService _postService;
        private readonly AboutUsPageInfo _aboutUsPageInfo;
        private readonly IMailHelper _mailHelper;
        private readonly IToastNotification _toastNotification;
        #endregion

        #region ctor
        public HomeController(IPostService postService, IOptions<AboutUsPageInfo> aboutUsPageInfo, IMailHelper mailHelper, IToastNotification toastNotification)
        {
            _postService = postService;
            _mailHelper = mailHelper;
            _toastNotification = toastNotification;
            _aboutUsPageInfo = aboutUsPageInfo.Value;
        }
        #endregion

        #region loadData

        [HttpGet]
        public async Task<IActionResult> Index(PostFilterDto request)
        {
            var result = await _postService.GetAllByPagingAsync(request);

            return View((request, result));
        }

        #endregion

        #region other
        [HttpGet]
        public IActionResult AboutUs()
        {
            return View(_aboutUsPageInfo);
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Contact(EmailSendDto request)
        {
            if (!ModelState.IsValid)
            {
                return View(request);
            }

            await _mailHelper.SendContactMailAsync(request);

            _toastNotification.AddSuccessToastMessage("Your message has been sent successfully.", new ToastrOptions()
            {
                Title = "Success",
            });

            return View();
        }
        #endregion
    }
}