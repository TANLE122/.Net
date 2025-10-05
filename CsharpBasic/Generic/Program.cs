using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> ten = new List<string>()
            {
                "Tan","Hiep","Khanh","Duong"
            };
            ten.Add("Phuong");
            ten.Remove("Hiep");
            foreach (string t in ten)
            {
                Console.WriteLine(t);
            }
            bool check = ten.Contains("Phuong");
            Console.WriteLine(check);
            Console.WriteLine("Thuc hanh voi kieu du lieu Dict");

            Dictionary<string, int> diemthi = new Dictionary<string, int>
            {
                {"tan", 10 },
                {"hiep",12 },
                {"Khanh", 14 }
            };
            diemthi.Add("ta", 1);
            bool check2 = diemthi.Remove("Khanh");
            foreach (var item in diemthi)
            {
                if (item.Value >= 8)
                {
                    Console.WriteLine(item);
                }
            }

        }

    }
}

/*
 Collection là các caaus trúc dữu liệu được sử dungj để lưu  trữ và quản lys các đối tượng trong c#
Có 2 loàij collection trong c# Generic va Non-Generic 
Các generic collection trong c# như List<T> ,Dict<Tkey,Tvalue>
Các non-generic Collectin :Làm việc với kiểu dữ liệu không cụ thể , thưognf là object ArrayList ,Hashtable)
List <T>
Dictionary<Tkey,Tvalue>
Luưu  trứx các căpj khóa giá trị 
Dễ dàng truy cập giá trị thông qua khóa.
Dictionary<int ,string> Student = new  Dictionảy<string , int>{
{"Alice",90},
{"Bob", 85}
};
Console.WriteLine<studentScores["Alice"]);
Non-Generic :ArrayList:
Lưu trữ danh sách các phần tử có thứ tự ,nhưng không yêu cầu kiểu dữu liệu cụ thể.
using System.Collections
Hashtable:
Lưu trức cặp khóa giá trị , khóa và giá trị đều là kiểu object
Conccurrent collections
Được định nghĩa trong namespace System.Collections.Conccurrent.Nhưngx collection này được thiết kế để hoạt động tốt trong môi trường đa luồng 
+ConccurrentBag<>:
+ConccurrentDictinatinary<Tkey,Tvalue>:Dictinartonary>
+Immutable Collections :Đuợc định nghĩa trong namespace System.Collection.Imutable 
•	Non-Generic: Khi cần làm việc với kiểu dữ liệu hỗn hợp (hiếm gặp).
•	Generic: Nên ưu tiên sử dụng vì an toàn và hiệu suất cao.
•	Concurrent: Khi làm việc trong môi trường đa luồng.
•	Immutable: Khi cần đảm bảo tính bất biến của dữ liệu.


 */
