using System;
namespace OR_test.New
{
    public class ConstraintDynamic
    {
        public enum ConstraintType
        {
            LessThan,
            MoreThan,
            Between,
        }

        public ConstraintType TypeofConstraint { get; set; }
        public Dictionary<int, int> Data {get; set;}
        public int? Lower;
        public int? Upper;
        public ConstraintDynamic(string constraintType, Dictionary<int, int> data, int? lower = null, int? upper = null)
        {

            //todo: error handling/ making three constructors
            switch (constraintType)
            {
                case "lessThan":
                    this.TypeofConstraint = ConstraintType.LessThan;
                    this.Upper = upper;
                    break;
                case "moreThan":
                    this.TypeofConstraint = ConstraintType.MoreThan;
                    this.Lower = lower;
                    break;
                case "between":
                    this.TypeofConstraint = ConstraintType.Between;
                    this.Upper = upper;
                    this.Lower = lower;
                    break;
                default:
                    break;

            }
            this.Data = data;
        }
    }
}

