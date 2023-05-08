using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem
{
    public static class DataBaseManager
    {
        private static List<User> _userList = new List<User>();
        private static List<Application> _applicationsList = new List<Application>();
        private static List<Grant> _grantsList = new List<Grant>();

        public static void AddApplication(string name, string information, int userId, string grantName)
        {
            Console.WriteLine("Добавление информации в бд");
            int grantId = 0;
            foreach (var grant in _grantsList)
            {
                if (grant.Name == grantName)
                {
                    grantId = grant.Id;
                    _applicationsList.Add(new Application(name, information, userId, grantId));
                }
                else
                {
                    Console.WriteLine("Грант не найден");
                    return;
                }
            }
        }
        public static void ApplicantsUserInformation(int applicantId)
        {
            foreach (var application in _applicationsList)
            {
                if (application.UserId == applicantId)
                {
                   application.ApplicationInformation();
                }
            }
        }
        public static void ApplicantsInformation()
        {
            foreach (var application in _applicationsList)
            {
                application.ApplicationInformation();
            }
        }
        public static void ChangeApplicantInformation(string applicationName, int userId)
        {
            foreach(var application in _applicationsList)
            {
                if (application.Name == applicationName && application.UserId == userId)
                {

                }
            }
        }

        public static void GrantInformation(string name)
        {
            foreach (var grant in _grantsList)
            {
                if (grant.Name == name)
                {
                    grant.GrantInformation();
                }
            }
        }
    }
}
