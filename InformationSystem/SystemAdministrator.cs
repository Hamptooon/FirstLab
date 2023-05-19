
namespace InformationSystem
{
    public class SystemAdministrator : User
    {
        private static SystemAdministrator _instance;
        private SystemAdministrator(string name) : base(name)
        {
            status = Globals.UserStatus.SystemAdministrator;
        }
        public static SystemAdministrator GetInstance(string name) {
            if (_instance == null)
            {
                _instance = new SystemAdministrator(name);
            }
            return _instance;
        }
        public void AddUser(string name, Globals.UserStatus status)
        {
            DataBaseManager.AddUser(name, status);
        }
        public void DeleteUser(int userId)
        {
            DataBaseManager.DeleteUser(userId);
        }

        public void ChangeUserName(int userId, string newName)
        {
            DataBaseManager.ChangeUserName(userId, newName);
        }

        public void ChangeApplicationInfo(string applicationName, int userId)
        {
            DataBaseManager.ChangeApplicationInformation(applicationName, userId);
        }

        public void AddApplication(string name, string information, int userId, string grantName)
        {
            DataBaseManager.AddApplication(name, information, userId, grantName);
        }

        public void ApllicationsInformation(int applicantId)
        {
            DataBaseManager.ApplicationsForApplicantInformation(applicantId);
        }
    }
}
