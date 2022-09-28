using Google.OrTools.LinearSolver;
using System.IO;
using System.Reflection.PortableExecutable;

namespace OR_test
{
    class Program
    {
        public static void Main()
        {

            //reading csv files
            int constraint_count;
            int application_count;

            List<Constraint> constraints = new List<Constraint>();
            List<Application> applications = new List<Application>();
            Console.WriteLine("Start \n");

            StreamReader reader = new StreamReader("/Users/boldizsarelek/Projects/OR-test/OR-test/Files/korlatok_szuk.txt");
            
            while (!reader.EndOfStream)
            {
                string[] tmp = reader.ReadLine().Split("\t");
                Constraint constraint = new Constraint
                {
                    ConstraintID = Convert.ToInt32(tmp[0]),
                    Type = Convert.ToChar(tmp[1]),
                    CompanyID = Convert.ToInt32(tmp[2]),
                    MinLimit = Convert.ToInt32(tmp[3]),
                    MaxLimit = Convert.ToInt32(tmp[4]),
                    Szp_ID = Convert.ToInt32(tmp[5]),
                };
                constraints.Add(constraint);
            }
            reader.Close();
            constraint_count = constraints.Count;

            reader = new StreamReader("/Users/boldizsarelek/Projects/OR-test/OR-test/Files/jelentkezesek_szuk.txt");
            while (!reader.EndOfStream)
            {
                string[] tmp = reader.ReadLine().Split("\t");
                Application application = new Application
                {
                    ApplicationID = Convert.ToInt32(tmp[0]),
                    StudentRank = Convert.ToInt32(tmp[1]),
                    CompanyRank = Convert.ToInt32(tmp[2]),
                    CompanyRank2 = Convert.ToInt32(tmp[3]),
                    ApplicationID2 = Convert.ToInt32(tmp[4]),
                    StudentID = Convert.ToInt32(tmp[5]),
                    CompanyID = Convert.ToInt32(tmp[6]),
                    Attribute1 = Convert.ToBoolean(Convert.ToInt32(tmp[7])),
                };
                applications.Add(application);
            }
            reader.Close();
            application_count = applications.Count;

            Console.WriteLine("korlatok {0} {1} {2}",
                constraints[constraint_count -1].ConstraintID,
                constraints[constraint_count -1].MaxLimit,
                constraints[constraint_count -1].Szp_ID);

            Console.WriteLine("jelentkezesek {0} {1} {2}",
                applications[application_count -1].ApplicationID,
                applications[application_count - 1].CompanyRank2,
                applications[application_count - 1].CompanyID);


            //writing lp file

            //objective (minimizing the preferences)
            StreamWriter writer = new StreamWriter("FELVI.lp");
            writer.WriteLine("min");
            for (int i = 0; i < applications.Count; i++)
            {
                writer.WriteLine(" + " + applications[i].StudentRank + " X" + applications[i].StudentID + "_" + applications[i].CompanyID);
            }

            //applicant's boundaries (1 applicant can only be assigned to one job)
            writer.WriteLine(" \n subject to");

            int applicant = applications[0].StudentID;
            writer.WriteLine("kE" + applicant + ":");
            for (int i = 0; i < applications.Count; i++)
            {
                if (applicant != applications[i].StudentID)
                {
                    writer.WriteLine(" = 1");
                    applicant = applications[i].StudentID;
                    writer.WriteLine("kE" + applicant + ":");
                }
                writer.WriteLine(" + X" + applications[i].StudentID + "_" + applications[i].CompanyID);     
            }
            writer.WriteLine(" = 1");

            //jobs' maximum limit boundaries

                //sorting the lists by companies
            List<Application> sortedApplications = applications.OrderBy(a => a.CompanyID).ToList();
            List<Constraint> sortedConstraints = constraints.OrderBy(c => c.CompanyID).ToList();

            int company = applications[0].CompanyID;
            int constraintIndex = constraints.IndexOf(constraints.Where(c => c.CompanyID == company).FirstOrDefault());

            writer.WriteLine("kSZP" + company + ":");
            for (int i = 0; i < sortedApplications.Count; i++)
            {
                if(company != sortedApplications[i].CompanyID)
                {
                    writer.WriteLine("<= " + constraints[constraintIndex].MaxLimit);
                    company = sortedApplications[i].CompanyID;
                    constraintIndex = constraints.IndexOf(constraints.Where(c => c.CompanyID == company).FirstOrDefault());
                    writer.WriteLine("kSZP" + company + ":");
                }
                writer.WriteLine(" + X" + sortedApplications[i].StudentID + "_" + sortedApplications[i].CompanyID);
            }
            writer.WriteLine("<= " + constraints[constraintIndex].MaxLimit);

            //jobs' minimum limit boundaries

            company = sortedApplications[0].CompanyID;
            constraintIndex = constraints.IndexOf(constraints.Where(c => c.CompanyID == company).FirstOrDefault());

            writer.WriteLine("kSZPa" + company + ":");
            for (int i = 0; i < sortedApplications.Count; i++)
            {
                if (company != sortedApplications[i].CompanyID)
                {
                    writer.WriteLine("<= " + constraints[constraintIndex].MinLimit);
                    company = sortedApplications[i].CompanyID;
                    constraintIndex = constraints.IndexOf(constraints.Where(c => c.CompanyID == company).FirstOrDefault());
                    writer.WriteLine("kSZPa" + company + ":");
                }
                writer.WriteLine(" + X" + sortedApplications[i].StudentID + "_" + sortedApplications[i].CompanyID);
            }
            writer.WriteLine("<= " + constraints[constraintIndex].MinLimit);



            writer.Close();
        }
    }
}

