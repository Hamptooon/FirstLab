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
        private string name;
        public string Name { get => name; set => name = value; }
        protected Globals.UserStatus status;
        public string Status { get => status.ToString(); }
        private int id;
        public int Id { get => id; private set => id = value; }
        public User(string name)
        {
            Name = name;
            Id = ++globalId;
        }
        protected virtual void Info() { }
    }

 
}
