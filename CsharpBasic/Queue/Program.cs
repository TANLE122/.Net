using Microsoft.SqlServer.Server;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Queue
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<String> Khachhientai = new List<string>
            {
                "Le Trong Khac","Tran Van Chien","Le Trong Hien"
            };
            Queue<string> Khachhang = new Queue<string>(Khachhientai);
            Khachhang.Enqueue("Le Trong Tan");
            Khachhang.Enqueue("Tran Van Hiep");
            Khachhang.Enqueue("Le Thi Trang");
            foreach (string s in Khachhang)
            {
                Console.WriteLine(s);

            }
            Console.WriteLine("Khach hang tiep theo la:");
            if(Khachhang.Count > 0)
            {
                string Khachhangnext = Khachhang.Peek();
                Console.WriteLine($"Khach ang tiep theo sex duwoc goi la:{Khachhangnext}");
            }


            Stack<string> khachhang1 = new Stack<string>(Khachhientai);
            khachhang1.Push("Tan le");

            foreach(string s in khachhang1)
            {
                Console.WriteLine($"{s}");
            }
            Console.ReadLine();

        }
    }
}
