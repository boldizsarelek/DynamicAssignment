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
        public List<ApplicantReceiver> Pairs { get; }
        public List<BlockgingPair> BlockingPairs { get; }
        public int ObjectiveSum { get; }
        public string LpFile { get; }

        public AssignmentResult(string result, List<ApplicantReceiver> pairs, List<BlockgingPair> blockingPairs, int objectiveSum, string lpFile)
        {
            Result = result;
            Pairs = pairs;
            BlockingPairs = blockingPairs;
            ObjectiveSum = objectiveSum;
            LpFile = lpFile;
        }
    }
    public class BlockgingPair
    {
        public int blockedApplicantID;
        public int blockingApplicantID;
        public int blockingReceiverID;
    }
}
