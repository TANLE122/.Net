using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Singleton_pattern
{
    public class LazyInittiallizerSingleton
    {
        private  static LazyInittiallizerSingleton instance;
        private LazyInittiallizerSingleton()
        {
        }
        public static LazyInittiallizerSingleton getInstance()
        {
            if (instance == null)
            {
                instance = new LazyInittiallizerSingleton();
            }
            return instance;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Lấy thể hiện Singleton lần thứ nhất
            LazyInittiallizerSingleton instance1 = LazyInittiallizerSingleton.getInstance();

            // 2. Lấy thể hiện Singleton lần thứ hai
            LazyInittiallizerSingleton instance2 = LazyInittiallizerSingleton.getInstance();

            // Kiểm tra xem cả hai biến có cùng trỏ đến MỘT đối tượng duy nhất không
            if (instance1 == instance2)
            {
                Console.WriteLine("Cả hai biến đều trỏ đến cùng một đối tượng Singleton duy nhất.");
            }
            else
            {
                Console.WriteLine("Lỗi: Đã tạo nhiều hơn một đối tượng Singleton.");
            }

            // Dừng màn hình để xem kết quả
            Console.ReadKey();
        }
    }
}
/*
 *Sử dụng singleton khi chúng ta muốn :
 Đảm bảo việcc chỉ có một instance của lớp
 Có thể quản lý số lượng thể hiện của một lớp trogn giới hạn chỉ định 
Nguyên tắc imployment :
private constructor để hạn chế truy cập 
Đặt private static final varriable ddamr bảo biến đươcj hởi tạo bên trong class
Có một method public static để return instance được khởi tạo ở trên 
 */