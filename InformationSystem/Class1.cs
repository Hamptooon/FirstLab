using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem
{

    public abstract class User
    {
        private static int globalId = 0;
        public string Name { get => Name; set => Name = value; }
        protected Globals.UserStatus status;
        public int Id { get => Id; private set => Id = value; }
        public User(string name)
        {
            Authorization();
            Id = ++globalId;
        }
        private void Authorization()
        {
            name = Console.ReadLine();
        }
        protected virtual void Info() { }
    }

 
}
