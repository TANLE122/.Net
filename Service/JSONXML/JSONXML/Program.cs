using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace JSONXML
{
    class Program
    {
        public class Person 
        {
            public string Name { get; set; }
            public int Age { get; set; }


        }
        static void Main()
        {
            string jsonString = "{\"Name\":\"John\",\"Age\":30}";

            Person person = JsonSerializer.Deserialize<Person>(jsonString);
            Console.WriteLine($"Name:{person.Name},Age:{Person.Age}");

        }


    }

}
