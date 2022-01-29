using Blog.Data.Abstract;
using Blog.Data.Concrete;
using Blog.Data.Concrete.EntityFramework.Context;
using Blog.Services.Abstract;
using Blog.Services.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Blog.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection LoadServices(this IServiceCollection services)
        {
            services.AddDbContext<BlogDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<ICategoryService, CategoryManager>();
            //services.AddScoped<IPostService, PostManager>();
            return services;
        }

    }
}
