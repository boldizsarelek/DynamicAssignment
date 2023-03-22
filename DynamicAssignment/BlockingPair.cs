using Google.OrTools.LinearSolver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicAssignment
{
    public class BlockingPair
    {
        public ApplicantReceiver BlockedApplication;
        public ApplicantReceiver BlockingApplication;
        public Variable Variable;
    }
}
