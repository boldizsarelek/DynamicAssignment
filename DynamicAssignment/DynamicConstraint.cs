using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicAssignment
{
    public class DynamicConstraint
    {
        public int ID { get; set; }
        public enum ConstraintType
        {
            LessThan,
            MoreThan,
            Between,
        }

        public ConstraintType BoundType { get; set; }

        private int lower;
        private int upper;

        public DynamicConstraint(List<ApplicantDynamicConstraint> data, int lowerBound, int upperBound)
        {
            lower = lowerBound;
            upper= upperBound;
            BoundType = ConstraintType.Between;
        }

        public void SetLowerBound(int lb)
        {

            lower = lb;
            if (BoundType == ConstraintType.LessThan)
            {
                BoundType = ConstraintType.Between;
            }
            else BoundType = ConstraintType.MoreThan;
        }
        public void SetUpperBound(int ub)
        {
            upper = ub;
            if (BoundType == ConstraintType.MoreThan)
            {
                BoundType = ConstraintType.Between;
            }
            else BoundType = ConstraintType.LessThan;
        }

        public int GetLowerBound()
        {
            return lower;
        }

        public int GetUpperBound()
        {
            return upper;
        }
    }
}
