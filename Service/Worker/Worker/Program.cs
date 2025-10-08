using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.ComponentModel;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FolderWathcerWorker 
{
    public class FolderWatcherService : BackgroundService
    {
        private readonly ILogger<FolderWatcherService> _logger;
        private FileSystemWatcher _watcher;
        private readonly string _folderPath = @"C:\Download\";

        public FolderWatcherService(ILogger<FolderWatcherService> logger)
        {
            _logger = logger;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            if (!Directory.Exists(_folderPath))
            {
                Directory.CreateDirectory(_folderPath);
                _logger.LogInformation("Tao thu muc theo doi : {path}", _folderPath);
            }
            _watcher = new FileSystemWatcher(_folderPath)
            {
                EnableRaisingEvents = true,
                Filter = "*.*",
                NotifyFilter = NotifyFilters.FileName | NotifyFilters.CreationTime
            };
            _watcher.Created += OnCreated;

            _logger.LogInformation("Bat dau theo doi thu muc:{path}", _folderPath);
            return Task.CompletedTask;
        }
        private void OnCreated(object sender , FileSystemEventArgs e)
        {
            _logger.LogInformation("File moi duoc tao :{name} ", e.Name);
        }
        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _watcher?.Dispose();
            _logger.LogInformation("Dung theo doi thu muc.");
            return base.StopAsync(cancellationToken);
        }
    }
    public class Program
    {
        public static async Task Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                {
                    services.AddHostedService<FolderWatcherService>();
                })
                .ConfigureLogging(logging =>
                {
                    logging.AddConsole();
                })
                .Build();
            await host.RunAsync();
        }
    }
}




/*
 Worker Service là một ứng dụng .NET  chạy nền (background service) được xây dựng trên nền tảng Generic Host)
Nó thưognf dungf cho :
Xử lý dữ liệu định kỳ (cron ,ETL, Batch job )
Gửi email thông báo nền
Lắng nghe message từ RabbitMQ ,Kafka, ỏ Azure 

Khi bạn tạo một Worker Service  ,.NET 
Một Host (Generic Host) → quản lý toàn bộ vòng đời ứng dụng

Một hoặc nhiều Hosted Service → chạy nền bên trong Host

Cấu hình Dependency Injection (DI), Logging, Configuration
BackgroundService là lớp cơ sở trừu tuọng trong namespace 
 */