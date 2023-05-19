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
        public string Name { get ; private set ; }
        private float sumGrant;
        private int id = 0;

        public Grant(string name)
        {
            Name = name;
            sumGrant = 100f;
            Id = ++globalId;
        }

        public int Id { get; private set ; }

        public void GrantInformation()
        {
            Console.WriteLine("Информаци о гранте");
        }
    }
}
