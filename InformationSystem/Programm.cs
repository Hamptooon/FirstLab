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
            //Applicant[] applicants = new Applicant[30];
            //for (int i = 0; i < applicants.Length; i++)
            //{
            //    applicants[0] = new Applicant("Егор");
            //}
            //Expert[] experts = new Expert[10];
            //for (int i = 0; i < applicants.Length; i++)
            //{
            //    experts[0] = new Expert("Игорь");
            //}
            //FundHolder[] fundsHolders = new FundHolder[5];
            //for (int i = 0; i < applicants.Length; i++)
            //{
            //    fundsHolders[0] = new FundHolder("Илья");
            //}
            //DataBaseManager._userList = new List<User>(applicants);
            //DataBaseManager._userList.AddRange(experts);
            //DataBaseManager._userList.AddRange(fundsHolders);

            //foreach (var item in DataBaseManager._userList)
            //{
            //    if (item.Status == "Applicant")
            //    {
            //        var applicant = item as Applicant;
            //        applicant.AddApplication("asdas", "asdas", "ршшшр");
            //    }
            //    else if (item.Status == "Expert")
            //    {
            //        var expert = item as Expert;
            //        expert.GradingApplications();
            //    }
            //    else if (item.Status == "FundHolder")
            //    {
            //        var fundHolder = item as FundHolder;
            //        fundHolder.GiveGrant();
            //    }
            //}
            for (int i = 0; i < 50; i++)
            {
                DataBaseManager._userList.Add(new Applicant($"Егор_{i}"));
                DataBaseManager._userList.Add(new Expert($"Игорь_{i}"));
                DataBaseManager._userList.Add(new FundHolder($"Илья_{i}"));
            }
            Grant grant = new Grant("grant");
            //Applicant applicant = new Applicant("Егор");
            //Expert expert = new Expert("Игорь");
            //Expert expert2 = new Expert("Игорь2");
            //FundHolder fundHolder = new FundHolder("Илья");
            //DataBaseManager._userList = new List<User>();
            //DataBaseManager._userList.Add(applicant);
            //DataBaseManager._userList.Add(expert);
            //DataBaseManager._userList.Add(expert2);
            //DataBaseManager._userList.Add(fundHolder);
            DataBaseManager._grantsList.Add(grant);
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
            //applicant.AddApplication("Zayvka", "Info", "grant");
            //applicant.AddApplication("Zayvka_1", "Info", "grant");
            //applicant.ApplicationsInformation();
            //expert.GradingApplications();
            //expert2.GradingApplications();  
            //fundHolder.ApplicationsWaitingInformation();
            //applicant.ApplicationsInformation();
            //fundHolder.GiveGrant();
            //fundHolder.ApplicationsApplyInformation();
            //applicant.ApplicationsInformation();
            //SystemAdministrator admin = new SystemAdministrator("AAAA");
            //DataBaseManager.PrintAllUsers();
            //admin.DeleteUser(1);
            //DataBaseManager.PrintAllUsers();



        }

    }
}
