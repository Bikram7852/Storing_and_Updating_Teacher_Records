using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeacherLibrary;

namespace Storing_and_Updating_Teacher_Records
{
    internal class Program
    {
        private static string teacherDataFilePath = "teacher_data.txt";
        static void Main(string[] args)
        {
            Teacher teacher = new Teacher(1, "John Doe", "Class 10A");
            StoreTeacherData(teacher);
            Console.WriteLine("Before updating the teacher data: \n" + "Id = " + teacher.Id + " " + "\nName = " + teacher.Name + " " + "\nClass and Section = " + teacher.ClassAndSection);
            teacher.Name = "John Smith";
            teacher.ClassAndSection = "Class 12A";
            UpdateTeacherData(teacher);
            Teacher teacherData = GetTeacherData(1);
            Console.WriteLine();
            Console.WriteLine("After updating the teacher data: \n" + "Id = " + teacherData.Id + " " + "\nName = " + teacherData.Name + " " + "\nClass and Section = " + teacherData.ClassAndSection);
            Console.ReadLine();
        }
        private static void StoreTeacherData(Teacher teacher)
        {
            using (StreamWriter sw = new StreamWriter(teacherDataFilePath, true))
            {
                sw.WriteLine($"{teacher.Id},{teacher.Name},{teacher.ClassAndSection}");
            }
        }

        private static void UpdateTeacherData(Teacher teacher)
        {
            List<string> teacherDataLines = new List<string>();

            using (StreamReader sr = new StreamReader(teacherDataFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    teacherDataLines.Add(line);
                }
            }

            for (int i = 0; i < teacherDataLines.Count; i++)
            {
                string[] teacherDataFields = teacherDataLines[i].Split(',');

                if (teacherDataFields[0] == teacher.Id.ToString())
                {
                    teacherDataLines[i] = $"{teacher.Id},{teacher.Name},{teacher.ClassAndSection}";
                    break;
                }
            }

            using (StreamWriter sw = new StreamWriter(teacherDataFilePath, false))
            {
                foreach (string teacherDataLine in teacherDataLines)
                {
                    sw.WriteLine(teacherDataLine);
                }
            }
        }

        private static Teacher GetTeacherData(int teacherId)
        {
            Teacher teacher = null;

            using (StreamReader sr = new StreamReader(teacherDataFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] teacherDataFields = line.Split(',');

                    if (teacherDataFields[0] == teacherId.ToString())
                    {
                        teacher = new Teacher(teacherId, teacherDataFields[1], teacherDataFields[2]);
                        break;
                    }
                }
            }

            return teacher;
        }
    }
}
