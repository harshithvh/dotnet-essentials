using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;

namespace CollectionDemo
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
            ArrayList al = new ArrayList();
            al.Add("Item1");
            al.Add("Item2");
            al.Add("Item3");
            al.Add("Item4");
            al.Add("Item6");
            // insert at index 4
            al.Insert(4, "Item5");

            string[] strings = { "Item7", "Item8", "Item9" };
            al.AddRange(strings);

            // The value of Capacity increases as elements are added
            Console.WriteLine($"Count {al.Count} and Capacity {al.Capacity}");

            Hashtable ht = new Hashtable();
            ht.Add(1, new Student { Name = "Student1", Id = 1 });
            ht.Add(2, new Student { Name = "Student2", Id = 2 });
            ht.Add(3, new Student { Name = "Student3", Id = 3 });


            foreach (Student item in ht.Values)
            {
                Console.WriteLine(item.Name);
            }
            // Since the Hashtable class stores objects as object types, it is necessary to cast the value to the desired type, in this case Student
            Student std = (Student)ht[3];
            //  ht.Remove(2);

            SortedList sortedList = new SortedList();

            Queue queue = new Queue();


            Stack stack = new Stack();
            // The dataStructures above can store data of any type(stored as objects) hence it is necessary to explicitly downcast everytime when retrieved
            // eg: Student std = (Student)ht[3];

            // The below DS are strict on the datatypes stored
            List<int> lstInts = new List<int>();
            lstInts.Add(10);//no upcasting

            int myint = lstInts[0];//no downcasting

            List<Student> students = new List<Student>();
            students.Add(new Student { Name = "Student1", Id = 1 });//no up-casting

            Student student = students[0];//no down-casting


            Dictionary<int, Student> studs = new Dictionary<int, Student>();
            studs.Add(1, new Student { Name = "Student1", Id = 1 });

            HashSet<string> hs1 = new HashSet<string>(); // similar to set in cpp
            hs1.Add("Item1");
            hs1.Add("Item2");
            hs1.Add("Item4");
            hs1.Add("Item4");
            hs1.Add("Item5");


            Console.WriteLine(hs1.Count);
            foreach (var item in hs1)
            {
                Console.WriteLine(item);
            }

            Stack<int> stack1 = new Stack<int>();
        }
    }
}
