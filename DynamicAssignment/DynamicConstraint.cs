using System;
using System.Collections.Generic;
using System.Text;

namespace DynamicAssignment
{
    public class DynamicConstraint
    {
        public ApplicantDynamicConstraint[] Data
        {
            get
            {
                return constraintDatas.ToArray();
            }
        }


        //Dynamic data to attach to applicants
        //Key:  StudentID
        public List<ApplicantDynamicConstraint> constraintDatas;
        public enum ConstraintType
        {
            LessThan,
            MoreThan,
            Between,
        }

        public ConstraintType BoundType;

        private int lower;
        private int upper;

        public DynamicConstraint(List<ApplicantDynamicConstraint> data)
        {
            constraintDatas = data;
        }
        public DynamicConstraint(List<ApplicantDynamicConstraint> data, int lowerBound, int upperBound)
        {
            constraintDatas = data;
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
