
namespace InformationSystem
{
    public class Applicant : User
    {
        public Applicant(string name) : base(name)
        {
            status = Globals.UserStatus.Applicant;
        }
        public void AddApplication(string name, string information, string grantName)
        {
            DataBaseManager.AddApplication(name,information, Id, grantName);
        }
        public void ApplicationsInformation()
        {
            DataBaseManager.ApplicationsForApplicantInformation(Id);
        }

        public void ChangeApplicationInformation(string applicationName)
        {
            DataBaseManager.ChangeApplicationInformation(applicationName, Id);
        }
       
    }
}
