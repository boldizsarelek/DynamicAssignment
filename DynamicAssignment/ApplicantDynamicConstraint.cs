using System;
namespace DynamicAssignment
{
	public class ApplicantDynamicConstraint
	{
		public Applicant Applicant { get; set; }
		public DynamicConstraint DynamicConstraint { get; set; }
		public bool Data { get; set; }
		public int ID { get; set; }

		public ApplicantDynamicConstraint(int constraintID, Applicant applicant, DynamicConstraint dynamicConstraint, bool data)
		{
			Applicant= applicant;
			DynamicConstraint= dynamicConstraint;
			ID= constraintID;
			Data= data;
		}
	}
}

