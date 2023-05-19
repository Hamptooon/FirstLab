
namespace InformationSystem
{
    public class Expert : User
    {
        Random random = new Random();
        public static int ExpertsCount { get ; private set ; }
        public Expert(string name) : base(name)
        {
            ExpertsCount+=1;
            status = Globals.UserStatus.Expert;
        }

        public void GradingApplications(string nameApplication)
        {
            List<Application> waitedApplications = ApplicationsForEvaluate();
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
