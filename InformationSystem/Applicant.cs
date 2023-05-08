using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem
{
    public class Applicant : User
    {
        public Applicant() : base()
        {
            status = Globals.UserStatus.Applicant;
        }
        private void AddApplication(string name, string information, int userId, int grantId)
        {
            DataBaseManager.AddApplication(name,information, userId, grantId);
        }
        private void ApplicationsInformation()
        {
            DataBaseManager.ApplicantsUserInformation(Id);
        }

        private void ChangeApplicationInformation(string name)
        {
            DataBaseManager.ChangeApplicantInformation(name);
        }
    }
}
