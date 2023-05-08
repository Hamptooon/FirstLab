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
        protected string name;
        protected Globals.UserStatus status;
        public int Id { get => Id; private set => Id = value; }
        public User()
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
