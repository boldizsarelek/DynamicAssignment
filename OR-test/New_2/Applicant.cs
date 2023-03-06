using System;
using System.Collections.Generic;

namespace DynamicAssignment
{
    public class Applicant
    {
        public int ApplicantID { get; set; }
        public string ApplicantName { get; set; }

        public Applicant(int applicantID, string applicantName)
        {
            ApplicantID = applicantID;
            ApplicantName = applicantName;
        }
    }
}

