using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem
{
    public class SystemAdministrator : User
    {
        public SystemAdministrator(string name) : base(name)
        {
            status = Globals.UserStatus.SystemAdministrator;
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
    }
}
