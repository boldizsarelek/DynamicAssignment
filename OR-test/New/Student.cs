using System;
namespace OR_test.New
{
    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int[] Preferences { get; set; }
        public Student(int id, string name, int[] preferences)
        {
            this.ID = id;
            this.Name = name;
            this.Preferences = preferences;
        }
    }
}

