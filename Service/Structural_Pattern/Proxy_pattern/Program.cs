using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy_Protection
{
    public interface UserService
    {
        void load();
        void insert();
    }
    public class UserServiceImpl : UserService
    {
        private string name;
        public UserServiceImpl(string name)
        {
            this.name = name;
        }
        public void load()
        {
            Console.WriteLine($"{name} + Loaded");
        }
        public void insert()
        {
            Console.WriteLine($"{name} + inserted");
        }
    }
    public class UserServiceProxy : UserService
    {
        private string role;
        private UserService userService;
        public UserServiceProxy(string name, string role)
        {
            this.role = role;
            userService = new UserServiceImpl(name);
        }
        public void load()
        {
            userService.load();
        }
        public void insert()
        {
            if (isAdmin())
            {
                userService.insert();
            }
            else
            {
                Console.WriteLine("Error");
            }
        }
        private bool isAdmin()
        {
            return string.Equals(this.role, "admin", StringComparison.OrdinalIgnoreCase);
        }
    }
    public class Client
    {
        public static void Main(string[] args)
        {
            UserService admin = new UserServiceProxy("gpcoder", "admin");
            admin.load();
            admin.insert();

            UserService customer = new UserServiceProxy("customer", "guest");
            customer.load();
            customer.insert();
            Console.ReadLine();
        }
    }
}
/*
Proxy pattern là mẫu thiêts kế mà ở đó tất cả truy cập trực tiếp đến một đối tượng nào đó sẽ được chuyển hướng đến một đối tượng trung gian 

Cài đặt proxy pattern có những đặc điểm sau :
Cung cấp mức truy cập gián tiếp vào một đối tượng 
Tham chiếu vào đối tượng dích và chuyển tiếp cá yêu câuf đến đối tươngj đó 
Cả Proxy và đối tượng  đích đều kế thừa haowjc thực thi chung một lớp giao diện.Mã 
 */