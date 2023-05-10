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
        public static void ApplicationsForApplicantInformation(int applicantId)
        {
            foreach (var application in _applicationsList)
            {
                if (application.UserId == applicantId)
                {
                   application.ApplicationInformation();
                }
            }
        }
        public static void ApplicationsWaitingForExpertInformation()
        {
            foreach (var application in _applicationsList)
            {
                if (application.status == Globals.ApplicationStatus.Waiting)
                {
                    application.ApplicationInformation();
                }
            }
        }

        public static void ApplicationsWaitingForFundHolderInformation()
        {
            foreach (var application in _applicationsList)
            {
                if (application.status == Globals.ApplicationStatus.WaitingApply)
                {
                    application.ApplicationInformation();
                }
            }
        }
        public static void ApplicationsApplyForFundHolderInformation()
        {
            foreach (var application in _applicationsList)
            {
                if (application.status == Globals.ApplicationStatus.Apply)
                {
                    application.ApplicationInformation();
                }
            }
        }
        public static void ChangeApplicationInformation(string applicationName, int userId)
        {
            Console.WriteLine("Что вы хотите поменять?");
            var choice = Console.ReadLine();
            foreach (var application in _applicationsList)
            {
                switch (choice)
                {
                    case "Информация":
                        Console.WriteLine("Введите новую информацию:");
                        application.Information = Console.ReadLine();
                        break;
                    case "Название":
                        Console.WriteLine("Введите новое название:");
                        application.Name = Console.ReadLine();
                        break;
                    case "Удалить заявку":
                        _applicationsList.RemoveAll(a => a.Name == applicationName && a.UserId == userId);
                        break;
                    default:
                        Console.WriteLine("Некорректный выбор.");
                        break;
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

        public static List<Application> GetApplicationsWithStatus(Globals.ApplicationStatus status)
        {
            List<Application> applicationList = new List<Application>();
            foreach (var app in _applicationsList)
            {
                if (app.status == status)
                {
                    applicationList.Add(app);
                }
            }
            return applicationList;
        }
        public static Application FindApplication(List<Application> waitedApplications, string name)
        {
            foreach (Application app in waitedApplications)
            {
                if (app.Name == name)
                {
                    return app;
                }
            }
            return null;
        }
        public static void AddUser(string name, Globals.UserStatus status)
        {
            User user;
            if (status == Globals.UserStatus.Applicant)
            {
                user = new Applicant(name);
            }
            else if (status == Globals.UserStatus.Expert)
            {
                user = new Expert(name);
            }
            else if (status == Globals.UserStatus.FundHolder)
            {
                user = new FundHolder(name);
            }
            else
            {
                return;
            }
            _userList.Add(user);
        }
        public static void DeleteUser(int userId)
        {
            foreach(var user in _userList)
            {
                if (user.Id == userId)
                {
                    _userList.Remove(user);
                }
            }
        }
        public static void ChangeUserName(int userId, string newName)
        {
            User selectUser = null;
            foreach(var user in _userList)
            {
                if (user.Id == userId)
                {
                    selectUser = user;
                    break;
                }
            }
            if (selectUser == null)
            {
                return;
            }
            selectUser.Name = newName;
            


        }
    }
}
