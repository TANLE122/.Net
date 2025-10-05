using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    // Entity: User
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public User(int id, string name, string email)
        {
            Id = id;
            Name = name;
            Email = email;
        }
    }

    // Generic DAO interface
    public interface IDao<T>
    {
        List<T> GetAll();
        T Get(int id);  // Trong C#, thường trả về null thay vì Optional
        void Save(T obj);
        void Update(T obj);
        void Delete(T obj);
    }

    // UserDao implement
    public class UserDao : IDao<User>
    {
        private List<User> users = new List<User>();

        public UserDao()
        {
            users.Add(new User(1, "GP Coder", "contact@gpcoder.com"));
            users.Add(new User(2, "Giang Phan", "gpcodervn@gmail.com"));
        }

        public List<User> GetAll()
        {
            return users;
        }

        public User Get(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public void Save(User user)
        {
            users.Add(user);
        }

        public void Update(User user)
        {
            var existingUser = Get(user.Id);
            if (existingUser != null)
            {
                existingUser.Name = user.Name;
                existingUser.Email = user.Email;
            }
        }

        public void Delete(User user)
        {
            var existingUser = Get(user.Id);
            if (existingUser != null)
            {
                users.Remove(existingUser);
            }
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        IDao<User> userDao = new UserDao();

        Console.WriteLine("All users:");
        foreach (var u in userDao.GetAll())
        {
            Console.WriteLine($"{u.Id} - {u.Name} - {u.Email}");
        }

        Console.WriteLine("\nGet user with id=1:");
        var user1 = userDao.Get(1);
        Console.WriteLine($"{user1.Id} - {user1.Name} - {user1.Email}");

        Console.WriteLine("\nUpdate user id=1:");
        userDao.Update(new User(1, "Updated Name", "updated@email.com"));
        Console.WriteLine($"{user1.Id} - {user1.Name} - {user1.Email}");

        Console.WriteLine("\nDelete user id=2:");
        userDao.Delete(new User(2, "", ""));
        foreach (var u in userDao.GetAll())
        {
            Console.WriteLine($"{u.Id} - {u.Name} - {u.Email}");
        }
    }
}
/*
 DAO  Data Access Object được thiết kêws để phân tách lớp logic lưu trữ dữ liệu trong một lớp riêng biệt  
Ý tưởng  là thay vì giao tiếp trưcj tiếp với csdl , hệ thống file , dịch vụ web.Chungs ta sex giao tiếp với hệ thống lưu trữ và tru
BusinessObject : đại diện cho Client, yêu cầu truy cập vào nguồn dữ liệu để lấy và lưu trữ dữ liệu.
DataAccessObject (DAO): là một interface định nghĩa các phương thức trừu tượng việc triển khai truy cập dữ liệu cơ bản cho BusinessObject để cho phép truy cập vào nguồn dữ liệu (DataSource).
DataAccessObjectConcrete : cài đặt các phương thức được định nghĩa trong DAO, lớp này sẽ thao tác trực tiếp với nguồn dữ liệu (DataSource).
DataSource : là nơi chứa dữ liệu, nó có thể là database, xml, json, text file, webservice, …
TransferObject : là một POJO (Plain old Java object) object, chứa các phương thức get/set được sử dụng để lưu trữ dữ liệu và được sử dụng trong DAO class.
 */