
namespace PartuialClass
{
    using PartialClass;
    using static System.Console;
    class Program
    {
        static void Main(string[] args)
        {
            var student = new Student
            {
                ID = 1,
                FirstName = "Donal ",
                LastName = "Trump",
                DateOfBirth = new System.DateTime(1990, 12, 3),
                Major = "Computer Science",
                Specialization = "Information System "

            };
            WriteLine(student);
            ReadKey();

        }
    }
}
       

