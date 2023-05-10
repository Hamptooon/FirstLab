using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem
{
    public class Expert : User
    {
        public static int ExpertsCount { get => ExpertsCount; private set => ExpertsCount = value; }
        public Expert(string name) : base(name)
        {
            ExpertsCount++;
            status = Globals.UserStatus.Expert;
        }

        public void GradingApplications()
        {
            List<Application> waitedApplications = ApplicationsForEvaluate();
            string nameApplication = Console.ReadLine();
            Application currentApplication = DataBaseManager.FindApplication(waitedApplications, nameApplication);
            int grade = int.Parse(Console.ReadLine());
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
            foreach(Application app in waitedApplications)
            {
                if (app.checkExpersGraded.Contains(this))
                {
                    waitedApplications.Remove(app);
                }
            }
            return waitedApplications;
        }
        
 
    }
}
