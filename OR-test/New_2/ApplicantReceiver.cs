using System;
namespace DynamicAssignment
{
	public class ApplicantReceiver
	{
        public int ApplicantReceiverID { get; set; }
        public Applicant Applicant { get; set; }
        public Receiver Receiver { get; set; }
        public int ApplicantPreference { get; set; }
        public int ReceiverPoints { get; set; }

		

        public ApplicantReceiver(int applicantReceiverID, Applicant applicant, Receiver receiver, int applicantPreference, int receiverPoints)
		{
			ApplicantReceiverID = applicantReceiverID;
			Applicant = applicant;
			Receiver = receiver;
			ApplicantPreference = applicantPreference;
			ReceiverPoints = receiverPoints;
		}
	}
}

