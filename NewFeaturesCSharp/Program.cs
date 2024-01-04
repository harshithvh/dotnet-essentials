using System;
using System.Collections.Generic;

namespace NewFeaturesCSharp
{
    class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Student student = new Student { Name = "Student1", Id = 1};

            List<Student> students = new List<Student>
            {
                new Student { Name = "Student1", Id = 1 },
                new Student { Name = "Student2", Id = 2 },
                new Student { Name = "Student3", Id = 3 }
            };

            Dictionary<int, Student> dictStudents = new Dictionary<int, Student>
            {
                { 1,new Student { Name = "Student1", Id = 1 }},
                { 2,new Student { Name = "Student2", Id = 2 }}
            };

            students.ForEach((item) => Console.WriteLine(item.Name));

            int? myint = null;

            Console.WriteLine(myint.HasValue ? myint.Value : "It is assigned to null");

        }
    }
}
