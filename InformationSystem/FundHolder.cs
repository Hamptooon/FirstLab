using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem
{
    public class FundHolder : User
    {
        Random random = new Random();
        private static int fundsHolderCount;
        public static int FundsHolderCount { get => fundsHolderCount; private set => fundsHolderCount = value; }
        public FundHolder(string name) : base(name)
        {
            FundsHolderCount++;
            status = Globals.UserStatus.FundHolder;
        }
        public void GiveGrant(string nameApplication)
        {
            List<Application> waitedApplications = ApplicationsForGranting();
            //string nameApplication = Console.ReadLine();
            Application currentApplication = DataBaseManager.FindApplication(waitedApplications, nameApplication);
            //bool isApply = Convert.ToBoolean(Console.ReadLine());
            int Apply = random.Next(0, 2);
            bool[] isApply = new bool[2] { true, false};
            currentApplication.checkApplying.Add(this, isApply[Apply]);
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
                    Console.WriteLine("give");
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
            //foreach (Application app in waitedApplications)
            //{
            //    if (app.checkApplying.ContainsKey(this))
            //    {
            //        waitedApplications.Remove(app);
            //    }
            //}
            for (int i = 0; i < waitedApplications.Count; i++)
            {
                if (waitedApplications[i].checkApplying.ContainsKey(this))
                {
                    waitedApplications.RemoveAt(i);
                    i--;
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


