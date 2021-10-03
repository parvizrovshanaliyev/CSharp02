using System;
using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PhoneBook.Business.Services;
using PhoneBook.Core.Context;
using PhoneBook.Core.Repository;
//using Microsoft.Extensions.Hosting;

namespace PhoneBook.UI.WinFormsApp
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new LoginForm());

            var builder = new HostBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddScoped<LoginForm>();
                    services.AddLogging(configure => configure.AddConsole());
                    services.AddScoped<IPhoneBookDbContext, PhoneBookDbContext>();
                    services.AddScoped<IContactRepository, ContactRepository>();
                    services.AddScoped<IUserRepository, UserRepository>();
                    services.AddScoped<IContactService, ContactService>();
                    services.AddScoped<IUserService, UserService>();
                });

            var host = builder.Build();

            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;

                try
                {
                    var loginForm = services.GetRequiredService<LoginForm>();
                    Application.Run(loginForm);
                    Console.WriteLine("success");

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        //private static void ConfigureServices(ServiceCollection services)
        //{
        //    services
        //        .AddScoped<LoginForm>()
        //        //.AddLogging(configure => configure.AddConsole())
        //        //.AddScoped<IContactRepository, ContactRepository>()
        //        //.AddScoped<IUserRepository, UserRepository>()
        //        //.AddScoped<IContactService, ContactService>()
        //        .AddScoped<IUserService, UserService>();
        //        //.AddSingleton<IPhoneBookDbContext, PhoneBookDbContext>();
        //}
    }
}
