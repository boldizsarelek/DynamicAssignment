using Google.OrTools.LinearSolver;
using System.IO;
using System.Reflection.PortableExecutable;

namespace OR_test
{
    class Program
    {
        public static void Main()
        {
           void Old()
            {
                //reading csv files
                int constraintCount;
                int applicationCount;

                List<Constraint2> constraints = new List<Constraint2>();

                //applications ordered by students then companies
                List<Application> applications = new List<Application>();

                //applications ordered by students then their rankings
                List<Application> applicationsByRank = new List<Application>();

                //applications ordered by companies then students
                List<Application> applicationsByCompany = new List<Application>();

                //Console.WriteLine("Start \n");

                StreamReader reader = new StreamReader("Files/korlatok_szuk.txt");
                while (!reader.EndOfStream)
                {
                    string[] tmp = reader.ReadLine().Split("\t");
                    Constraint2 constraint = new Constraint2
                    {
                        ConstraintID = Convert.ToInt32(tmp[0]),
                        Type = Convert.ToChar(tmp[1]),
                        CompanyID = Convert.ToInt32(tmp[2]),
                        MaxLimit = Convert.ToInt32(tmp[3]),
                        MinLimit = Convert.ToInt32(tmp[4]),
                        Szp_ID = Convert.ToInt32(tmp[5]),
                    };
                    constraints.Add(constraint);
                }
                reader.Close();
                constraintCount = constraints.Count;

                reader = new StreamReader("Files/jelentkezesek_szuk.txt");
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
                applicationCount = applications.Count;

                applicationsByRank = applications.OrderBy(a => a.StudentID).ThenBy(a => a.StudentRank).ToList();

                //writing lp file

                //objective (minimizing the preferences)
                StreamWriter writer = new StreamWriter("FELVI.lp");
                StreamWriter writer2 = new StreamWriter("CELFGV.lp");
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
                applicationsByCompany = applications.OrderBy(a => a.CompanyID).ThenBy(a => a.StudentID).ToList();
                List<Constraint2> sortedConstraints = constraints.OrderBy(c => c.CompanyID).ToList();

                int company = applications[0].CompanyID;
                int constraintIndex = constraints.IndexOf(constraints.Where(c => c.CompanyID == company).FirstOrDefault());

                writer.WriteLine("kSZP" + company + ":");
                for (int i = 0; i < applicationsByCompany.Count; i++)
                {
                    if (company != applicationsByCompany[i].CompanyID)
                    {
                        writer.WriteLine("<= " + constraints[constraintIndex].MaxLimit);
                        company = applicationsByCompany[i].CompanyID;
                        constraintIndex = constraints.IndexOf(constraints.Where(c => c.CompanyID == company).FirstOrDefault());
                        writer.WriteLine("kSZP" + company + ":");
                    }
                    writer.WriteLine(" + X" + applicationsByCompany[i].StudentID + "_" + applicationsByCompany[i].CompanyID);
                }
                writer.WriteLine("<= " + constraints[constraintIndex].MaxLimit);

                //jobs' minimum limit boundaries

                company = applicationsByCompany[0].CompanyID;
                constraintIndex = constraints.IndexOf(constraints.Where(c => c.CompanyID == company).FirstOrDefault());

                writer.WriteLine("kSZPa" + company + ":");
                for (int i = 0; i < applicationsByCompany.Count; i++)
                {
                    if (company != applicationsByCompany[i].CompanyID)
                    {
                        writer.WriteLine("=> " + constraints[constraintIndex].MinLimit);
                        company = applicationsByCompany[i].CompanyID;
                        constraintIndex = constraints.IndexOf(constraints.Where(c => c.CompanyID == company).FirstOrDefault());
                        writer.WriteLine("kSZPa" + company + ":");
                    }
                    writer.WriteLine(" + X" + applicationsByCompany[i].StudentID + "_" + applicationsByCompany[i].CompanyID);
                }
                writer.WriteLine(">= " + constraints[constraintIndex].MinLimit);

                //jobs' foreign limitations (maximum number of foreign students per job)

                company = applicationsByCompany[0].CompanyID;

                writer.WriteLine("kSZPk" + company + ":");
                for (int i = 0; i < applicationsByCompany.Count; i++)
                {
                    if (company != applicationsByCompany[i].CompanyID)
                    {
                        writer.WriteLine("<= 2");
                        company = applicationsByCompany[i].CompanyID;
                        writer.WriteLine("kSZPk" + company + ":");
                    }
                    if (applicationsByCompany[i].Attribute1)
                    {
                        writer.WriteLine(" + X" + applicationsByCompany[i].StudentID + "_" + applicationsByCompany[i].CompanyID);
                    }
                }
                writer.WriteLine("<= 2");


                //stability limitations
                int k;
                int l;
                int studentRank;
                int studentID;
                string tmpString = "";

                int iCompare = 0;
                int applicantCompare = applicationsByRank[0].StudentID;

                for (int i = 0; i < applicationCount; i++)
                {

                    //Console.WriteLine("Iteration number {0} \n",i);

                    k = 0;
                    l = 0;
                    company = applicationsByRank[i].CompanyID;
                    studentRank = applicationsByRank[i].StudentRank;
                    studentID = applicationsByRank[i].StudentID;

                    //Console.WriteLine("Applications by rank: {0} {1} {2} {3} {4} {5} {6} {7}", applicationsByRank[i].ApplicationID, applicationsByRank[i].StudentRank, applicationsByRank[i].CompanyRank, applicationsByRank[i].CompanyRank2, applicationsByRank[i].ApplicationID2, applicationsByRank[i].StudentID, applicationsByRank[i].CompanyID, applicationsByRank[i].Attribute1);
                    //Console.WriteLine("Applications by company: {0} {1} {2} {3} {4} {5} {6} {7} \n", applicationsByCompany[i].ApplicationID, applicationsByCompany[i].StudentRank, applicationsByCompany[i].CompanyRank, applicationsByCompany[i].CompanyRank2, applicationsByCompany[i].ApplicationID2, applicationsByCompany[i].StudentID, applicationsByCompany[i].CompanyID, applicationsByCompany[i].Attribute1);

                    //Console.WriteLine("Company: {0}",company);
                    //Console.WriteLine("Student rank: {0}", studentRank);
                    //Console.WriteLine("Student ID: {0}",studentID);
                    //Console.WriteLine("Applicant compare: {0}",applicantCompare);
                    //Console.WriteLine("i Comparison: {0} \n",iCompare);

                    if (studentID != applicantCompare)
                    {
                        applicantCompare = studentID;
                        iCompare = i;
                        //Console.WriteLine("New applicant compare: {0}",applicantCompare);
                        //Console.WriteLine("New i Comparison: {0} \n", iCompare);
                    }


                    while (applicationsByCompany[k].CompanyID != company)
                    {
                        k++;
                    }


                    while (constraints[l].CompanyID != company)
                    {
                        l++;
                    }

                    tmpString = "";
                    //Console.WriteLine("iCompare: {0}", iCompare);
                    for (int j = iCompare; j <= i; j++)
                    {
                        tmpString += (" + X" + applicationsByRank[j].StudentID + "_" + applicationsByRank[j].CompanyID);
                        //Console.WriteLine("New tmpstring: {0}",tmpString);
                        //Console.WriteLine("j iteration: {0}", j);
                    }


                    do
                    {
                        //Console.WriteLine("Check: ({0} < {1}) && ({2} != {3}) && {4} > 0", applicationsByCompany[k].CompanyRank, applicationsByRank[i].CompanyRank, applicationsByCompany[k].StudentID, applicationsByRank[i].StudentID, applicationsByRank[i].StudentRank);

                        if ((applicationsByCompany[k].CompanyRank < applicationsByRank[i].CompanyRank) && (applicationsByCompany[k].StudentID != applicationsByRank[i].StudentID) && applicationsByRank[i].StudentRank > 0)
                        {
                            //Console.WriteLine("Check True");

                            writer.Write(tmpString + "- X" + applicationsByCompany[k].StudentID + "_" + applicationsByCompany[k].CompanyID);
                            writer.WriteLine(" + B" + applicationsByRank[i].StudentID + "_" + applicationsByCompany[k].StudentID + "_" + applicationsByRank[i].CompanyID + ">= 0");

                            //Console.WriteLine("+ B{0}_{1}_{2}", applicationsByRank[i].StudentID, applicationsByCompany[k].StudentID, applicationsByRank[i].CompanyID);

                            writer2.WriteLine(" + 100 B" + applicationsByRank[i].StudentID + "_" + applicationsByCompany[i].CompanyID + "_" + applicationsByRank[i].StudentID);
                        }
                        k++;
                        //Console.WriteLine("New k in while: {0}", k);

                        if (k == applicationsByCompany.Count)
                        {
                            break;
                        }



                        //Console.WriteLine("While check: {0} == {0}", applicationsByCompany[k].CompanyID, company);

                        //Console.WriteLine("While check: {0} == {0}", applicationsByCompany[k].CompanyID, company);
                    }
                    while (applicationsByCompany[k] != null && applicationsByCompany[k].CompanyID == company);
                }
                writer.Close();
            }

           void NewCode()
            {

                //invoking solver
                Solver solver = Solver.CreateSolver("SCIP");
                if (solver is null)
                {
                    return;
                }

                //reading student preferences
                List<int[]> studentList = new List<int[]>(); 
                StreamReader reader = new StreamReader("Files/preferences.txt");
                int rowIndex = 0;
                while (!reader.EndOfStream)
                {
                    string[] row = reader.ReadLine().Split("\t");
                    int columnNumber = row.Length;
                    int[] rowInt = new int[columnNumber];
                    for (int columnIndex = 0; columnIndex < columnNumber; columnIndex++)
                    {
                        rowInt[columnIndex] = Convert.ToInt32(row[columnIndex]);
                    }
                    studentList.Add(rowInt);
                    rowIndex++;
                }
                reader.Close();


                //making variables
                int studentNumber = studentList.Count();
                int companyNumber = studentList[0].Length;
                int[,] studentPreferences = new int[studentNumber, companyNumber];
                Variable[,] x = new Variable[studentNumber, companyNumber];

                for (int student = 0; student < studentNumber; student++)
                {
                    for (int company = 0; company < companyNumber; company++)
                    {
                        studentPreferences[student, company] = studentList[student][company];
                    }
                }


                //reading companies preferences
                int[,] companyPreferences = new int[studentNumber, companyNumber];
                reader = new StreamReader("companyPreferences.txt");
                for (int student = 0; student < studentNumber; student++)
                {
                    string[] row = reader.ReadLine().Split("\t");
                    for (int company = 0; company < companyNumber; company++)
                    {
                        companyPreferences[student, company] = Convert.ToInt32(row[company]);
                    }
                }


                //making boolean variables for modeling
                for (int student = 0; student < studentNumber; student++)
                {
                    for (int company = 0; company < companyNumber; company++)
                    {
                        x[student,company] = solver.MakeBoolVar($"x{student}_{company}");
                    }
                }

                //applicant's boundaries (1 applicant can only be assigned to one job)
                for (int student = 0; student < studentNumber; student++)
                {
                    Constraint constraint = solver.MakeConstraint(1, 1, "");
                    for (int company = 0; company < companyNumber; company++)
                    {
                        constraint.SetCoefficient(x[student, company], 1);
                    }
                }


                //jobs' boundaries (currently not real limits)
                for (int company = 0; company < companyNumber; company++)
                {
                    Constraint constraint = solver.MakeConstraint(1, 5, "");
                    for (int student = 0; student < studentNumber; student++)
                    {
                        constraint.SetCoefficient(x[student, company], 1);
                    }
                }

                //objective
                Objective objective = solver.Objective();
                for (int student = 0; student < studentNumber; student++)
                {
                    for (int company = 0; company < companyNumber; company++)
                    {
                        objective.SetCoefficient(x[student, company], studentPreferences[student, company]);
                    }
                }
                objective.SetMinimization();


                //solving
                Solver.ResultStatus resultStatus = solver.Solve();

                //reading solver output
                if (resultStatus == Solver.ResultStatus.OPTIMAL || resultStatus == Solver.ResultStatus.FEASIBLE)
                {
                    for (int student = 0; student < studentNumber; student++)
                    {
                        for (int company = 0; company < companyNumber; company++)
                        {
                            if (x[student, company].SolutionValue() > 0.5)
                            {
                                Console.WriteLine($"Student {student} assigned to job {company}");
                            }
                            else
                            {
                                //Console.WriteLine($"Student {i} NOT assigned to job {j}");
                            }
                        }
                    }
                    
                }
                else
                {
                    Console.WriteLine("No solution found");
                }
            }

            NewCode();
        }
    }
}

