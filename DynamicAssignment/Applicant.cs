using System;
using System.Collections.Generic;

namespace DynamicAssignment
{
    public class Applicant
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Applicant(int id, string name)
        {
            ID = id;
            Name = name;
        }
    }
}

