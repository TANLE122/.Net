using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace GenericHostExample
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    // Đăng ký Hosted Service
                    services.AddHostedService<WorkerService>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.ClearProviders();
                    logging.AddConsole();
                })
                .Build();
            await host.RunAsync();
        }
    }

    public class WorkerService : BackgroundService
    {
        private readonly ILogger<WorkerService> _logger;

        public WorkerService(ILogger<WorkerService> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("WorkerService bắt đầu chạy lúc: {time}", DateTimeOffset.Now);

            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Working... {time}", DateTimeOffset.Now);
                await Task.Delay(5000, stoppingToken); 
            }
            _logger.LogInformation("WorkerService dừng lúc: {time}", DateTimeOffset.Now);
        }
    }
}




/*
 Generic hót là cơ chée chuẩn để khởi tạo va quản lý vòng đời ứng dụng 
Mot host là một đối tượng đogns gói tài nguyên app và chức năng trong đời của ứng dụng
The host thưongf được cấu hình ,xay dụng và chạy bàng code trong lớp Program.
IHostBuilder
Gọi  phương thức CreateDaeefaultBuilder() để tạo và cấu hình một đối tượng builder
Gọi Build() để tạo một đói tươngj IHost
Gọi Run or Runasync trên đói tượng host.
Một số trường hợp dùng Generic host :
Tạo console app có DI, logging ,cấu hình chuẩn 
Viết Worker Service (chạy background trên Window/Linux service ).
Chạy tác vụ nên trogn ASP.NET Core (Ví dụ như gửi email,queue ,..) 
Xây dựng microservice hợc sheduler , ...)
Khi bạn build Generic Host, nó trở thành “bộ khung vận hành” của ứng dụng — nó chịu trách nhiệm:

Thành phần	Mô tả
Configuration	Gom dữ liệu cấu hình từ nhiều nguồn: appsettings.json, biến môi trường, tham số dòng lệnh, secrets,… và đưa vào IConfiguration.
Logging	Tự thiết lập hệ thống logging (Console, Debug, File, Serilog, v.v.) thông qua ILogger — bạn không cần tự khởi tạo.
Dependency Injection (DI)	Tạo container dịch vụ chuẩn của .NET (IServiceProvider), quản lý lifecycle (Singleton, Scoped, Transient) cho bạn.
Hosted Services	Quản lý các dịch vụ chạy nền (IHostedService), đảm bảo chúng được start và stop đúng vòng đời.
Application Lifetime	Theo dõi trạng thái ứng dụng (bắt đầu, dừng, huỷ), phát tín hiệu dọn dẹp tài nguyên.
Environment	Biết ứng dụng đang chạy trong môi trường nào (Development, Staging, Production) và dùng config phù hợp.

Generi Host (thông qua Host.CreateDefaultBuilder(...) là khuôn (framework) chuẩn để khởi tạo vaf quản lý vòng đời ứng dụng .Net 
.Khi bạn Build() một IHost , bạn có một containerDI,còniguration , logging, lifecycle , lắng nghe sựu kiện start ,stop
IHostBuilder - dùng để câu hình host( thêm servie , config , logging,...) Host.CreateDefaultBuilder(args) trả về IHostBuilder đã được cấu hình mặc định 
IHost -object sau khi Build() .Đóng vai tro như ứng dụng đã được cấu hình mặc định (appsetting , )
IHost — object sau khi Build(). Đóng vai trò như “ứng dụng” đã được cấu hình. Có method như StartAsync(), StopAsync(), RunAsync(), và cung cấp Services (một IServiceProvider) để resolve dependencies.

IServiceProvider (accessible qua host.Services) — container DI để lấy service đã đăng ký.

IHostedService / BackgroundService — service chạy nền (background). AddHostedService<WorkerService>() đăng ký một IHostedService.

IHostEnvironment — thông tin môi trường (Development/Production), content root, v.v.

IConfiguration — cấu hình (appsettings.json, env vars, command-line).

IHostApplicationLifetime — token & API để tương tác với vòng đời ứng dụng (ApplicationStarted, ApplicationStopping, StopApplication()).
 */