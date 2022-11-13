using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicAssignment
{
    public class DynamicConstraint
    {
        //Dynamic data to attach to applicants
        //Key:  StudentID
        public Dictionary<int, int> Data;
        public enum ConstraintType
        {
            LessThan,
            MoreThan,
            Between,
        }

        public ConstraintType BoundType;

        private int? Lower;
        private int? Upper;

        public DynamicConstraint(Dictionary<int, int> data)
        {
            Data = data;
        }
        public DynamicConstraint(Dictionary<int, int> data, int lowerBound, int upperBound)
        {
            Data = data;
            BoundType = ConstraintType.Between;
        }

        public void SetLowerBound(int lb)
        {

            Lower = lb;
            if (BoundType == ConstraintType.LessThan)
            {
                BoundType = ConstraintType.Between;
            }
            else BoundType = ConstraintType.MoreThan;
        }
        public void SetUpperBound(int ub)
        {
            Upper = ub;
            if (BoundType == ConstraintType.MoreThan)
            {
                BoundType = ConstraintType.Between;
            }
            else BoundType = ConstraintType.LessThan;
        }
    }
}
