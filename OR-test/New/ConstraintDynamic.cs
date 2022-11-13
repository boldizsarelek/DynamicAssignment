using System;
namespace OR_test.New
{
    public class ConstraintDynamic
    {

        //Dynamic data to attach to applicants
        //Key:  StudentID
        public Dictionary<int, int> Data { get; set; }
        private enum ConstraintType
        {
            LessThan,
            MoreThan,
            Between,
        }

        private ConstraintType Type;

        private int? Lower;
        private int? Upper;

        public ConstraintDynamic(Dictionary<int, int> data)
        {
           Data = data;
        }
        public ConstraintDynamic(Dictionary<int, int> data, int lowerBound, int upperBound)
        {
            Data = data;
            Type = ConstraintType.Between;
        }

        public void SetLowerBound(int lb)
        {
            
            Lower = lb;
            if (Type == ConstraintType.LessThan)
            {
                Type = ConstraintType.Between;
            }
            else Type = ConstraintType.MoreThan;
        }
        public void SetUpperBound(int ub)
        {
            Upper = ub;
            if (Type == ConstraintType.MoreThan)
            {
                Type = ConstraintType.Between;
            }
            else Type = ConstraintType.LessThan;
        }

    }
    
}

