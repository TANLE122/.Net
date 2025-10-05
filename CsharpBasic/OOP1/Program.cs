using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace OOP1
{
    internal class Program
    {
        static void Main(string[] args)
        {
        FullTimeEmployee Hieu = new FullTimeEmployee();
        ParttimeEmployee Nam = new ParttimeEmployee();
        intern Tan = new intern();
            Hieu.CaculatorSalary(20);
            Nam.CaculatorSalary(12);
            Tan.CaculatorSalary(23);
            Console.ReadLine();
        }
    }
}
class Employee
{
    public string Name { get; set; }
    public virtual void CaculatorSalary(int ngay)
    {
        int luong = ngay * 200000;
        Console.WriteLine($"Tong luong la : {luong}");
    }
}
class FullTimeEmployee:Employee
{
}
class ParttimeEmployee:Employee
{
    public override void CaculatorSalary(int ngay)
    {
        int luong = ngay * 150000;
        Console.WriteLine($"luong: {luong}");
    }
}
class intern : Employee
{
    public override void CaculatorSalary(int ngay)
    {;
        Console.WriteLine("Thuc tap sinh nen khong co banh trung thu nhe");
    }
    
}
