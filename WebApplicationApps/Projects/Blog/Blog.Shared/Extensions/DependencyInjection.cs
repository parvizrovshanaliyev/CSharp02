using Blog.Shared.Helpers;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddSharedServices(this IServiceCollection services)
        {
            services.AddSingleton<IFileHelper, FileHelper>();
            return services;
        }
    }
}