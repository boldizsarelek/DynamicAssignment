using System;
using System.Collections.Generic;

namespace DynamicAssignment
{
    public class Applicant
    {
        public int ID;
        public string Name;
        public Dictionary<int, int> Preferences; //to be deleted

        public Applicant(int id, string name, Dictionary<int,int> preferences)
        {
            ID = id;
            Name = name;
            Preferences = preferences;
        }
    }
}

