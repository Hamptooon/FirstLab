
namespace InformationSystem
{

    public abstract class User
    {
        private static int globalId = 0;
        public string Name { get ; set ; }
        protected Globals.UserStatus status;
        public string Status { get => status.ToString(); }
        public int Id { get; private set ; }
        public User(string name)
        {
            Name = name;
            Id = ++globalId;
        }
        protected virtual void Info() { }
        public void ApplicationsInformation()
        {
            if (status == Globals.UserStatus.Applicant)
            {
                DataBaseManager.ApplicationsForApplicantInformation(Id);
            }
            else if (status == Globals.UserStatus.Expert)
            {
                DataBaseManager.ApplicationsWaitingForExpertInformation();
            }
            else if (status == Globals.UserStatus.FundHolder)
            {
                DataBaseManager.ApplicationsWaitingForFundHolderInformation();
            }
            else if (status == Globals.UserStatus.SystemAdministrator)
            {
                string applicantId = Console.ReadLine();
                DataBaseManager.ApplicationsForApplicantInformation(int.Parse(applicantId));
            }
        }
    }

 
}
