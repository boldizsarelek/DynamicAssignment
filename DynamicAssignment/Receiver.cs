using System;
using System.Collections.Generic;

namespace DynamicAssignment
{
	public class Receiver
	{
        public int ID { get; set; }
        public string Name { get; set; }
        public Dictionary<int,int> Preferences { get; set; } //to be deleted
        public int MinimumCapacity { get; set; }
        public int MaximumCapacity { get; set; }
        public Receiver(int id, string name, int minimumCapacity, int maximumCapacity)
        {
            this.ID = id;
            this.Name = name;
            this.MaximumCapacity = maximumCapacity;            
        }
    }
}

