using Blog.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading.Tasks;

namespace Blog.WebAPP.CORE.MVC.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class ViewCountFilterAttribute : Attribute, IAsyncActionFilter
    {
        #region Implementation of IAsyncActionFilter

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var postId = context.ActionArguments["id"];//1

            if (postId != null)
            {
                string postValue = context.HttpContext.Request.Cookies[$"post-{postId}"];// post-1

                if (string.IsNullOrEmpty(postValue))
                {
                    Set($"post-{postId}", postId.ToString(), 1, context.HttpContext.Response);

                    var postService = context.HttpContext.RequestServices.GetService<IPostService>();

                    if (postService != null) await postService.IncreaseViewCountAsync(Convert.ToInt32(postId));

                    await next();
                }
            }

            await next();
        }

        #endregion

        /// <summary>
        /// set the cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime"></param>
        /// <param name="response"></param>
        public void Set(string key, string value, int? expireTime, HttpResponse response)
        {
            CookieOptions option = new CookieOptions();

            option.Expires = expireTime.HasValue ? DateTime.Now.AddYears(expireTime.Value) : DateTime.Now.AddMonths(6);

            response.Cookies.Append(key, value, option);
        }

        /// <summary>
        /// delete the key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="response"></param>
        public void Remove(string key, HttpResponse response)
        {
            response.Cookies.Delete(key);
        }

    }
}
