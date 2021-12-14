using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Students.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname{ get; set; }
        public string Faculty { get; set; }
        public int Course { get; set; }
    }
}
