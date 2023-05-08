using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem
{
    internal class Application
    {
        private static int globalId = 0;
        public string Name { get => Name; private set => Name = value; }
        private string information;
        private Globals.ApplicationStatus status;
        private int id;
        public int UserId { get => UserId; private set => UserId = value; }
        private int grantId;

        public Application(string name, string information, int userId, int grantId)
        {
            Name = name;
            this.information = information;
            status = Globals.ApplicationStatus.Waiting;
            UserId = userId;
            this.grantId = grantId;
            id = ++globalId;
        }

        private float _grade { get; set; }

        public void ApplicationInformation() 
        {
            Console.WriteLine("Информация о заявке");
        }

    }
}
