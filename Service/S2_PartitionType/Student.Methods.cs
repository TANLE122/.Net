using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartialClass
{
    public partial class Student
    {
        public override string ToString()
        {
            return $"{FirstName}{LastName} ({DateOfBirth.ToShortDateString()})";
        }
    }
}