using System;
namespace DynamicAssignment
{
	public class ApplicantReceiver
	{
        public int ID { get; set; }
        public Applicant applicant { get; set; }
        public Receiver receiver { get; set; }
        public int applicantPreference { get; set; }
        public int receiverPreference { get; set; }

		

        public ApplicantReceiver()
		{
			


		}
	}
}

