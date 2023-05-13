using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem
{
    public class Grant
    {
        private static int globalId = 0;
        private string name;
        public string Name { get => name; private set => name = value; }
        private float sumGrant;
        private int id = 0;

        public Grant(string name)
        {
            Name = name;
            this.sumGrant = 100f;
            id = ++globalId;
        }

        public int Id { get => id; private set => id = value; }

        public void GrantInformation()
        {
            Console.WriteLine("Информаци о гранте");
        }
    }
}
