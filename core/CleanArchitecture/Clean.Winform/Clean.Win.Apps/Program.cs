using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;
using Serilog.Events;
using Microsoft.Extensions.DependencyInjection;
using Clean.WinF.Applications.Features.Part.Interfaces;
using Clean.WinF.Applications.Features.Part.Services;
using Clean.WinF.Domain;
using Clean.WinF.Domain.Entities;
using Clean.WinF.Infrastructure;
using Clean.WinF.Infrastructure.Repositories;
using System.Windows.Forms.Design;
using Autofac;
using Clean.WinF.Domain.IRepository;
using Clean.WinF.Infrastructure.DBContext;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore;

namespace Clean.Win.Apps
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Implement serilog
            var fileName = string.Concat("Logs\\", DateTime.Now.ToString("yyyy-MM-dd"), ".log");
            Log.Logger = new LoggerConfiguration()
                        .MinimumLevel.Debug()    
                        .WriteTo.File(fileName, rollingInterval: RollingInterval.Day) // write logs to a file
                        .CreateLogger();

            //apply DI container
            //register part service here
            var services = new ServiceCollection();

            var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = ".\\Clean.WinF.Infrastructure\\clean_winf_db.db" };
            var connectionString = connectionStringBuilder.ToString();
            var connection = new SqliteConnection(connectionString);
            // scoped: services are created once per request
            //services.AddDbContext<ApplicationDBContext>( // entity framework DbContext, the default lifetime is 'scoped'
            //contextOptionsBuilder =>
            //{
            //    //contextOptionsBuilder.UseMySql(connectionStr, ServerVersion.AutoDetect(connectionStr), context => context.MigrationsAssembly("EET.Blueprint.API"));
            //    contextOptionsBuilder.UseSqlite(connection);
            //});

            services.AddDbContext<ApplicationDBContext>();
            using (var dbContext = new Clean.WinF.Infrastructure.DBContext.ApplicationDBContext())
            {
                // Execute migrations
                dbContext.Database.Migrate();
            }


            services.AddScoped(typeof(IAsyncRepository<>), typeof(EFRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPartCommandServices, PartCommandServices>();
            services.AddTransient<IPartQueryServices, PartQueryServices>();
            
            var serviceProvider = services.BuildServiceProvider();

            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //Apply DI into main thread
            IPartCommandServices partCommandService = serviceProvider.GetService<IPartCommandServices>();
            IPartQueryServices partQueryService = serviceProvider.GetService<IPartQueryServices>();

            Application.Run(new MainForm(partCommandService, partQueryService));
            //Application.Run(new MainForm());
        }
    }
}
