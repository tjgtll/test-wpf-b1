using b1_task2.BLL.Models;
using b1_task2.BLL.Services;
using b1_task2.DAL.DataDbContext;
using b1_task2.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.IO;
using System.Windows;

namespace b1_task2.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider _serviceProvider;
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            IConfiguration configuration = new Microsoft.Extensions.Configuration.ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            _serviceProvider = new ServiceCollection()
                .AddDbContext<b1TaskDbContext>(options =>
                    options.UseSqlServer(configuration.GetConnectionString("MyDbConnection")))
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IService<ChartOfAccountDTO>, ChartOfAccountService>()
                .AddScoped<IService<BalanceSheetDTO>, BalanceSheetService>()
                .AddScoped<IExcelFileManagerService, ExcelFileManagerService>()
                .BuildServiceProvider();

            var chartOfAccountService = _serviceProvider.GetRequiredService<IService<ChartOfAccountDTO>>();
            var balanceSheetService = _serviceProvider.GetRequiredService<IService<BalanceSheetDTO>>();
            var excelFileManagerService = _serviceProvider.GetRequiredService<IExcelFileManagerService>();
            var mainWindow = new MainWindow(chartOfAccountService, balanceSheetService, excelFileManagerService);
            mainWindow.Show();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _serviceProvider?.Dispose();

            base.OnExit(e);
        }
    }
}
