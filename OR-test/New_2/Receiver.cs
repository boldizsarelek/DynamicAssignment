using System;
using System.Collections.Generic;

namespace DynamicAssignment
{
	public class Receiver
	{
        public int ReceiverID { get; set; }
        public string ReceiverName { get; set; }
        public int MinimumCapacity { get; set; }
        public int MaximumCapacity { get; set; }
        public Receiver(int receiverID, string receiverName, int minimumCapacity, int maximumCapacity)
        {
            this.ReceiverID = receiverID;
            this.ReceiverName = receiverName;
            this.MinimumCapacity = minimumCapacity;
            this.MaximumCapacity = maximumCapacity;            
        }
    }
}

