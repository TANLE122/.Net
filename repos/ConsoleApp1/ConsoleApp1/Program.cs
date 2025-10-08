using Microsoft.Extensions.Logging;

// Cách đơn giản nhất - không cần hiểu DI
using var loggerFactory = LoggerFactory.Create(builder =>
{
    builder.AddConsole(); // Ghi log ra console
    builder.SetMinimumLevel(LogLevel.Information);
});

var logger = loggerFactory.CreateLogger<Program>();

logger.LogInformation("Hello World!");
logger.LogWarning("This is a warning");
logger.LogError("This is an error");

// Giữ cho console không tắt ngay
Console.WriteLine("Press any key to exit...");
Console.ReadKey();