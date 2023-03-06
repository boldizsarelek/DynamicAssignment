using Google.OrTools.ConstraintSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicAssignment
{
    public class ReceiverDynamicConstraint
    {
        public int ReceiverConstraintID { get; set; }
        public Receiver Receiver { get; set; }
        public DynamicConstraint DynamicConstraint { get; set; }
        public int LowerBound { get; set; }
        public int UpperBound { get; set; }

        public ReceiverDynamicConstraint(int receiverConstraintID, Receiver receiver, DynamicConstraint dynamicConstraint, int lowerBound, int upperBound)
        {
            ReceiverConstraintID = receiverConstraintID;
            Receiver = receiver;
            DynamicConstraint = dynamicConstraint;
            LowerBound = lowerBound;
            UpperBound = upperBound;
        }

    }
}
