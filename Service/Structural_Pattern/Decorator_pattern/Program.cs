using System;
using System.Globalization;
using System.Linq.Expressions;


namespace Decorator
{
    public interface IEmployeeComponent
    {
        string GetName();
        void DoTask();
        void Join(DateTime joinDate);
        void Terminate(DateTime terminateDate);

        // Default method (C# 8.0+)
        public string FormatDate(DateTime theDate)
        {
            return theDate.ToString("dd/MM/yyyy");
        }

        public void ShowBasicInformation()
        {
            Console.WriteLine("-------");
            Console.WriteLine("The basic information of " + GetName());

            Join(DateTime.Now);

            DateTime terminateDate = DateTime.Now.AddMonths(6);
            Terminate(terminateDate);
        }
    }

}
public class EmployeeConcreteCompoment : EmployeeBase
    {
        private String name;
        public EmployeeConcreteCompoment(string name)
        {
            this.name = name;
        }
        public override string GetName()
        {
            return name;
        }
        public override void Join(DateTime joinDate)
        {
            Console.WriteLine(GetName() + " " + joinDate.ToString(name));
        }
        public override void Terminate(DateTime terminateDate)
        {
            Console.WriteLine(GetName() + "" + FormatDate(terminateDate));
        }
        public override void DoTask()
        {
            
        }
    }
    public abstract class EmployeeDecorator : EmployeeBase
    {
        protected EmployeeBase employee;
        protected EmployeeDecorator(EmployeeBase employee)
        {
            this.employee = employee;
        }
        public override string GetName()
        {
            return employee.GetName();
        }
        public override void Join(DateTime joinDate)
        {
            employee.Join(joinDate);
        }
        public void terminate(DateTime terminateDate)
        {
            employee.Terminate(terminateDate);
        }
    }

   public class Manager : EmployeeDecorator
    {
        public Manager(EmployeeBase employee) : base(employee) { }

        public void CreateRequirement()
        {
            Console.WriteLine($"{employee.GetName()} is creating requirements.");
        }

        public void AssignTask()
        {
            Console.WriteLine($"{employee.GetName()} is assigning tasks.");
        }

        public void ManageProgress()
        {
            Console.WriteLine($"{employee.GetName()} is managing the progress.");
        }

        public override void DoTask()
        {
       // gọi DoTask() của employee gốc
            CreateRequirement();
            AssignTask();
            ManageProgress();
        }
    }
}

/*
Decorator  cho phép người dugnf thêm chức năng mới vào đói tượng hiện tại mà không muốn ảnh hưởng  đến các dối tượng khác .kiểu thiết kế này có cấu trúc hoặt đôngj như một lớp bao bọc (wrap)
cho lớp hiện tại mà không muốn ảnh hưởng đến các đối tượng mới .Decorator pattern còn được gọi là Warpper hay Smartproxy
Decorator pattern hoạt đọng dựa trên một đối tượng đặc biệt ,được gọi là decorator (hay Wrapper ).Nó có cùng một interface như một sối tượng mà nó cần bao bọc (wrap) ,vid vậy phía client sẽ không nhạn đuọc khi bạn đưa cho nó 
Tất cả  các warpper có một trường đẻ lưu trữ một giá trị của một đối tượng gốc.
 */