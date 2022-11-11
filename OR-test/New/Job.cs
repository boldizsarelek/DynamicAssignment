using System;
namespace OR_test.New
{
    public class Company
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int[] StudentPoints { get; set; }
        public int MinimumCapacity { get; set; }
        public int MaximumCapacity { get; set; }
        public Company(int id, string name, int minimumCapacity, int maximumCapacity, int[] preferences = null, int[] studentPoints = null)
        {
            this.ID = id;
            this.Name = name;
            this.StudentPoints = studentPoints;
            this.MaximumCapacity = maximumCapacity;
        }
    }
}

