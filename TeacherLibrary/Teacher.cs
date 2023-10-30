using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeacherLibrary
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ClassAndSection { get; set; }

        public Teacher(int id, string name, string classAndSection)
        {
            Id = id;
            Name = name;
            ClassAndSection = classAndSection;
        }
    }
}
