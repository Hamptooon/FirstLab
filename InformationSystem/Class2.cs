using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem
{
    public class Globals
    {
        public enum UserStatus
        {
            Applicant,
            Expert,
            FundHolder
        }
        public enum ApplicationStatus
        {
            Waiting,
            Apply,
            Refusal
        }
    }
}
