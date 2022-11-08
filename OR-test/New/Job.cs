using System;
namespace OR_test.New
{
    public class Job
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int[] Preferences { get; set; }
        public int MinimumCapacity { get; set; }
        public int MaximumCapacity { get; set; }
        public Job(int id, string name, int[] preferences, int minimumCapacity, int maximumCapacity)
        {
            this.ID = id;
            this.Name = name;
            this.Preferences = preferences;
            this.MaximumCapacity = maximumCapacity;
        }
    }
}

