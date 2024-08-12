using CDatos.Repositories;
using CDatos.Repositories.Contracts;
using CLogica.Implementations;
using CLogica.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using CDatos.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace EjemploRepositorios
{
    internal static class Program
    {
        public static IServiceProvider _serviceProvider { get; private set; }

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var host = CreateHostBuilder().Build();
            _serviceProvider = host.Services;

            Application.Run(_serviceProvider.GetRequiredService<Form1>());
        }

        static IHostBuilder CreateHostBuilder()
        {
            return Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) => {

                    services.AddTransient<IAutorLogic, AutorLogic>();

                    services.AddTransient<IAutorRepository, AutorRepository>();

                    services.AddTransient<Form1>();

                    services.AddDbContext<LibreriaContext>(options => options.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=LibreriaProg2024;Integrated Security=True;TrustServerCertificate=true"), ServiceLifetime.Transient);
                });
        }
    }
}