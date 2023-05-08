using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InformationSystem
{
    internal class Grant
    {
        public string Name { get => Name; private set => Name = value; }
        private float sumGrant;
        private int id;
        public int Id { get => Id; private set => Id = value; }

        public void GrantInformation()
        {
            Console.WriteLine("Информаци о гранте");
        }
    }
}
