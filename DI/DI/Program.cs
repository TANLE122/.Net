using System;
using System.Net;

namespace Dependence_injection
{
    // Định nghĩa interface
    public interface IService
    {
        void DoWork();
    }

    // Implement interface
    public class ServiceA : IService
    {
        public void DoWork() => Console.WriteLine("Service A dang hoat dong...");
    }

    public class ServiceB : IService
	{
        public void DoWork() => Console.WriteLine("Service B dang hoat dong .....");
	}

    // Client sử dụng IService qua Constructor Injection
    public class Client
    {
        private readonly IService _service;

        public Client(IService service)
        {
            _service = service;
        }

        public void Run() => _service.DoWork();
    }

    // Entry point
    public class Program
    {
        public static void Main(string[] args)
        {
            // Tạo đối tượng Service
            IService serviceA = new ServiceA();
            IService serviceB = new ServiceB();

            // Inject Service vào Client
            Client clientA = new Client(serviceA);
            Client clientB = new Client(serviceB);

            // Gọi method Run
            clientA.Run();
            clientB.Run();
        }
    }
}
/*
DI là một kĩ thuật để giảm sự phụ thuộc chặt chẽ giữa các lớp ,giúp dễ code dễ mở rộng ,dễ test

Có 3 loai chính la: Constructor injection laf Inject dependency thong qua constructor 
Suử dụng Dependence injection thông qua 3 bước :
1.Sử dụng một interface hoặc base class để trừu tượng hóa việc triển khai phuj thuộc
2.Đăng ký phần phụ thuộc trong service container. ASP.NET Core cho phép chúng ta đăng ký các dịch vụ ứng dụng của mình với IoC container, trong phương thức ConfigureServices của lớp Startup. Phương thức ConfigureServices bao gồm một tham số kiểu IServiceCollection . được sử dụng để đăng ký các dịch vụ ứng dụng.
Đưa service vào phương thức khởi tạo của lớp mà nó được sử dụng.
Framework sẽ tạo một thể hiện của sự phụ thuộc và loại bỏ nó khi nó không còn cần thiết nữa.

Class nào implement interface thì có thể coi như là kiểu interface đó
*/