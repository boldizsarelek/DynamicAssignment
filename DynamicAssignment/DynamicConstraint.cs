using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicAssignment
{
    public class DynamicConstraint
    {
        public int ConstraintID { get; set; }
        //public int LowerBound { get; set; }
        //public int UpperBound { get; set; }

        public string ConstraintName { get; set; }

        public DynamicConstraint(int constraintID, /*int lowerBound,*/ /*int upperBound,*/ string constraintName)
        {
            ConstraintID = constraintID;
            //LowerBound = lowerBound;
            //UpperBound = upperBound;
            ConstraintName = constraintName;
        }





    }
}
