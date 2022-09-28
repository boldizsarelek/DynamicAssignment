using Google.OrTools.LinearSolver;
using System.IO;
using System.Reflection.PortableExecutable;

namespace OR_test
{
    class Program
    {
        public static void Main()
        {
            int constraint_count = 9;
            int application_count = 333;

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


            Console.WriteLine("korlatok {0} {1} {2}",
                constraints[constraint_count -1].ConstraintID,
                constraints[constraint_count -1].MaxLimit,
                constraints[constraint_count -1].Szp_ID);

            Console.WriteLine("jelentkezesek {0} {1} {2}",
                applications[application_count -1].ApplicationID,
                applications[application_count - 1].CompanyRank2,
                applications[application_count - 1].CompanyID);


        }
    }
}

