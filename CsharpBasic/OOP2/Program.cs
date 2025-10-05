using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// 1. Renamed 'Device' to 'Animal' for better context (optional but recommended)
// 2. Correctly structured the abstract class declaration


/*Tính trừu tượng trogn oop là  kỹ thuật ẩn đi các chi tiết triển khai vbaf chỉ hiển thị cho người người dùng những chức năng cần thiết .Điều này giúp bạn tập trung vào  
 * Abbstrac class  là một lớp khôgn thế được khởi tạo trưcos tiếp ,chỉ có thể đưọc kế thừa bởi lớp ccon 
 * Một lớp trưuf tượng có thể chứa cả :
 * Phương thức  trừu tượng (không có than hàm, chỉ cso định nghĩa)
 * Phương thức bình thường có than hàm 
 *Khi bạn muốn cung cấp nhưng  cơ chế mặc định cho lớp con ,nhưng cũng yêu cầu các lớp con phải triển khia một số phương thức cụ thể  
 *
Interface :Là một tập hợp các phương thức ,thuộc tính mà các lớp thực thi triển khai .
Chỉ đnhj nghĩa cái gì cần làm (không cung cấp code triển khai )
Một lớp có thẻe thực thi nhiều interface( đa kế thừa)
Đăcj điẻm tất cả các phương thức mặc định alf public 
Không chưa code triển khai 
Khi nào cần dùng Abstract class và Interface 
Abstract class:
Khi các lớp con cânf kế thừa một loggic chung.
Khi cần một base calss với cả phương thức trừ tượng và không trừu tượng 
Abstract class :+ Khi các lớp con cần kế thừa một logic chung 
+Khi bạn cần một base class và cả phưogn thức trừu tượng và không truquf tượng 
Interface :
Khi các lớp không liên quan cần chia sẻ  hành vi 
Khi bạn cần đa kế thừa 

 */
namespace OOP2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SmartPhone realme32 = new SmartPhone();
            Laptop Dellinspiron = new Laptop();
            realme32.Name = "realme";
            realme32.GetDeviceInfo();
            realme32.ConnectToNetWork();
            Dellinspiron.Name = "dell";
            Dellinspiron.GetDeviceInfo();
            Dellinspiron.ConnectToNetWork();
  
            Console.ReadLine();
        }
    }

    public abstract class Device
    {
        public string Name { get; set; }
        public abstract void GetDeviceInfo();
    }
    public interface INETworkConnectable
    {
        void ConnectToNetWork();
    }
    public class SmartPhone : Device, INETworkConnectable
    {
        public override void GetDeviceInfo()
        {
            Console.WriteLine($"Ten thiet bi la:{Name}");
        }
        public void ConnectToNetWork()
        {
            Console.WriteLine("Dang ket noi den mang Myhtt");
        }

    }
    public class Laptop : Device, INETworkConnectable
    {
        public override void GetDeviceInfo()
        {
            Console.WriteLine($"Ten thiet bi la {Name}");
        }
        public void ConnectToNetWork()
        {
            Console.WriteLine("Dang ket noi den mang  Hust");
        }
    }
}
