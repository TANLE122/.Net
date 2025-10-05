using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Array1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //string[] months = new string[12];
            //for(int month =1; month <=12; month++)
            //{
            //    DateTime firstday = new DateTime(DateTime.Now.Year, month, 1);
            //    string name = firstday.ToString("MMMM", CultureInfo.CreateSpecificCulture("en"));
            //    months[month - 1] = name;
            //}
            //foreach(string month in months)
            //{
            //    Console.WriteLine($"->{month}");
            //}
            //Console.ReadLine();
            Console.Title = "MultiArray";
            var multiarry = new int[5, 5];
            for  (int i = 0;  i < multiarry.GetLength(0); i++)
            {
                for (int c = 0; c < multiarry.GetLength(1); c++)
                {
                    multiarry[i, c] = (i + 1) * (c + 1);
                }
            }
            for (int c = 0; c < multiarry.GetLength(1); c++)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                if (c == 0) Console.WriteLine("{0,4}", "");
                else
                    Console.Write("{0,4}", "");
            }
            Console.WriteLine();
            for (int r= 0; r < multiarry.GetLength(0); r++)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("{0,4}", r + 1);
                Console.ResetColor();
                for (int c = 0; c < multiarry.GetLength(1); c++)
                {
                    Console.Write("{0,4}", multiarry[r, c]);
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }
}
// Mang độ dài cố định  
// Chỉ luữ trữ các phần tử sùng kiểu dữ liệu 
// Lưu trữ và  cấp phát các ô nhớ liên tiếp nhau



