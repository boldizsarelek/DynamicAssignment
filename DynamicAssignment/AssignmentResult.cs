using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicAssignment
{
    public class AssignmentResult
    {
        public string Result { get; }
        public Dictionary<Applicant, Receiver> Pairs { get; }
        public Dictionary<Applicant, Receiver> BlockingPairs { get; }
        public int ObjectiveSum { get; }

        public AssignmentResult(string result, Dictionary<Applicant, Receiver> pairs, Dictionary<Applicant, Receiver> blockingPairs, int objectiveSum)
        {
            Result = result;
            Pairs = pairs;
            BlockingPairs = blockingPairs;
            ObjectiveSum = objectiveSum;
        }
    }
}
