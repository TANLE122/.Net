using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Vehicle vehicle = new Vehicle();
            Car car = new Car();
            Bike bike = new Bike();
            vehicle.Move();
            car.Move();
            bike.Move();

        }
    }
}
class Vehicle
{
    public string Name { get; set; }
    public virtual void Move()
    {
        Console.WriteLine("Di chuyen ngang");
    }
    public void Used()
    {
        Console.WriteLine("No may thi moi di duwoc");
    }
}
class Car : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Di chuyen phai");
    }
}
class Bike : Vehicle
{
    public override void Move()
    {
        Console.WriteLine("Bay len");
    }
}

/*
Đa hình :Là khả năng thực thi một hành vi(phương thức) theo nhiều cách khác nhau.
Có hai loại: một là khác tham sô ,2 là nghi đè hàm 

 */