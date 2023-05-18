using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem
{
    public class Programm
    {
        static void Main(string[] args)
        {
            var systemAdmin = SystemAdministrator.GetInstance("AdMiN");

            for (int i = 0; i < 10; i++)
            {
                DataBaseManager._userList.Add(new Applicant($"Егор_{i}"));
                DataBaseManager._userList.Add(new Expert($"Игорь_{i}"));
                DataBaseManager._userList.Add(new FundHolder($"Илья_{i}"));
            }
            Grant grant = new Grant("grant");
            DataBaseManager._grantsList.Add(grant);
            //
            foreach (var applicant in DataBaseManager._userList)
            {
                if (applicant is Applicant)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        (applicant as Applicant).AddApplication($"Zayvka_{applicant.Name}_{i}", $"Info_{i}", $"grant");
                        (applicant as Applicant).ApplicationsInformation();
                    }
                }
            }
            foreach (var applicant in DataBaseManager._userList)
            {
                if (applicant is Applicant)
                {
                    foreach (var expert in DataBaseManager._userList)
                    {
                        if (expert is Expert)
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                (expert as Expert).GradingApplications($"Zayvka_{applicant.Name}_{i}");
                            }
                        }
                    }
                }
            }
            foreach (var applicant in DataBaseManager._userList)
            {
                if (applicant is Applicant)
                {
                    for (int i = 0; i < 10; i++)
                    {
                        (applicant as Applicant).ApplicationsInformation();
                    }
                }
            }
            foreach (var applicant in DataBaseManager._userList)
            {
                if (applicant is Applicant)
                {
                    foreach (var fundHolder in DataBaseManager._userList)
                    {
                        if (fundHolder is FundHolder)
                        {
                            for (int i = 0; i < 10; i++)
                            {
                                (fundHolder as FundHolder).GiveGrant($"Zayvka_{applicant.Name}_{i}");
                            }
                        }
                    }
                }
            }
            foreach (var applicant in DataBaseManager._userList)
            {
                if (applicant is Applicant)
                {
                    for (int i = 0; i < 100; i++)
                    {
                        (applicant as Applicant).ApplicationsInformation();
                    }
                }
            }
        }

    }
}
