using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem
{
    public class Expert : User
    {
        Random random = new Random();
        private static int expertsCount;
        public static int ExpertsCount { get => expertsCount; private set => expertsCount = value; }
        public Expert(string name) : base(name)
        {
            ExpertsCount+=1;
            status = Globals.UserStatus.Expert;
        }

        public void GradingApplications(string nameApplication)
        {
            List<Application> waitedApplications = ApplicationsForEvaluate();
            //string nameApplication = Console.ReadLine();
            Application currentApplication = DataBaseManager.FindApplication(waitedApplications, nameApplication);
            int grade = random.Next(1, 20);
            currentApplication.grades.Add(grade);
            currentApplication.checkExpersGraded.Add(this);
            if (currentApplication.checkExpersGraded.Count == ExpertsCount)
            {
                currentApplication.SetAverageGrade();
                currentApplication.status = Globals.ApplicationStatus.WaitingApply;
            }
        }
        public void ApplicationsWaitingInformation()
        {
            DataBaseManager.ApplicationsWaitingForExpertInformation();
        }
        private List<Application> ApplicationsForEvaluate()
        {
            List <Application> waitedApplications = new List<Application>();
            waitedApplications =  DataBaseManager.GetApplicationsWithStatus(Globals.ApplicationStatus.Waiting);
            //foreach(Application app in waitedApplications)
            //{
            //    if (app.checkExpersGraded.Contains(this))
            //    {
            //        waitedApplications.Remove(app);
            //    }
            //}
            for (int i = 0; i < waitedApplications.Count; i++)
            {
                if (waitedApplications[i].checkExpersGraded.Contains(this))
                {
                    waitedApplications.RemoveAt(i);
                    i--;
                }
            }
            return waitedApplications;
        }
        
 
    }
}
