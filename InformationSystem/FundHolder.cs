using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem
{
    public class FundHolder : User
    {
        public static int FundsHolderCount { get => FundsHolderCount; private set => FundsHolderCount = value; }
        public FundHolder(string name) : base(name)
        {
            FundsHolderCount++;
            status = Globals.UserStatus.FundHolder;
        }
        public void GiveGrant()
        {
            List<Application> waitedApplications = ApplicationsForGranting();
            string nameApplication = Console.ReadLine();
            Application currentApplication = DataBaseManager.FindApplication(waitedApplications, nameApplication);
            bool isApply = Convert.ToBoolean(Console.ReadLine());
            currentApplication.checkApplying.Add(this, isApply);
            if (currentApplication.checkApplying.Count == FundsHolderCount)
            {
                int counter = 0;
                foreach (var key in currentApplication.checkApplying.Values)
                {
                    if (key == true)
                    {
                        counter++;
                    }
                    else
                    {
                        counter--;
                    }
                }
                if (counter > 0)
                {
                    currentApplication.status = Globals.ApplicationStatus.Apply;
                }
                else
                {
                    currentApplication.status = Globals.ApplicationStatus.Refusal;
                }
            }
        }
        private List<Application> ApplicationsForGranting()
        {
            List<Application> waitedApplications = new List<Application>();
            waitedApplications = DataBaseManager.GetApplicationsWithStatus(Globals.ApplicationStatus.WaitingApply);
            foreach (Application app in waitedApplications)
            {
                if (app.checkApplying.ContainsKey(this))
                {
                    waitedApplications.Remove(app);
                }
            }
            return waitedApplications;
        }
        public void ApplicationsWaitingInformation()
        {
            DataBaseManager.ApplicationsWaitingForFundHolderInformation();
        }
        public void ApplicationsApplyInformation()
        {
            DataBaseManager.ApplicationsApplyForFundHolderInformation();
        }
    }
        

}


