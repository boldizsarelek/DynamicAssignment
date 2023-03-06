using System;
namespace DynamicAssignment
{
	public class ApplicantDynamicConstraint
	{
        public int ApplicantDynamicConstraintID { get; set; }
        public Applicant Applicant { get; set; }
		public DynamicConstraint DynamicConstraint { get; set; }
		public bool ApplicantData { get; set; }

		public ApplicantDynamicConstraint(int constraintID, Applicant applicant, DynamicConstraint constraint, bool applicantData)
		{
			Applicant= applicant;
			DynamicConstraint= constraint;
			ApplicantDynamicConstraintID= constraintID;
			ApplicantData= applicantData;
		}
	}
}

