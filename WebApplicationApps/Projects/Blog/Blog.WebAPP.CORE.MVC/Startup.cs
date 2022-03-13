using Blog.Services.AutoMapper.Profiles;
using Blog.Services.Extensions;
using Blog.Shared.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Text.Json.Serialization;
namespace Blog.WebAPP.CORE.MVC
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews()
                .AddRazorRuntimeCompilation()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                })
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                })
                .AddNToastNotifyToastr();

            JsonConvert.DefaultSettings = () => new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            services.AddSession();
            services.LoadServices();
            services.LoadSharedServices();
            services.AddAutoMapper(typeof(CategoryProfile), typeof(PostProfile), typeof(UserProfile));

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/Admin/Auth/Login");
                options.LogoutPath = new PathString("/Admin/Auth/Logout");
                options.AccessDeniedPath = new PathString("/Admin/Auth/AccessDenied");

                options.Cookie = new CookieBuilder()
                {
                    Name = "BlogProject",

                    // xss cross site scripting
                    /*
                     * Asagidaki js kodu ile web page uzerindeki cookie melumatlarini elde etmek mumkundur.
                     *
                     * {
                     *  var cookie=document.cookie;
                     *  window.alert(cookie);
                     * }
                     *
                     * Lakin http-only cookie-lere bu qeder asan reach ede bilmirik.
                     * bu tip attack-lar XSS (Cross Site Scripting) adlanir.
                     */
                    HttpOnly = true,
                    /*
                     * Cross site Request Forgery 'CSRF' attackinin qarshisini almaq ucun istifade edilir,
                     * web app-e userlerden elave kiminse her hanssa bir appden her hansisa bir userin cookie
                     * melumatindan istifade ederek request ata bilmesinin qarshisini alir.
                     */
                    SameSite = SameSiteMode.Strict,
                    /*
                     * sameAsRequest hem http hem https requestleri qebul edir .
                     * Duzgun yeni productionda olan app-da  CookieSecurePolicy.Always olmalidir. her zaman https request.
                     */
                    SecurePolicy = CookieSecurePolicy.SameAsRequest, // Always
                };


                options.SlidingExpiration = true;
                options.ExpireTimeSpan = System.TimeSpan.FromDays(7);
            });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseSession();
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();


            app.UseNToastNotify();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller}/{action=Index}/{id?}");

                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
