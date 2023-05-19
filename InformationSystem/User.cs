
namespace InformationSystem
{

    public abstract class User
    {
        private static int globalId = 0;
        public string Name { get ; set ; }
        protected Globals.UserStatus status;
        public string Status { get => status.ToString(); }
        public int Id { get; private set ; }
        public User(string name)
        {
            Name = name;
            Id = ++globalId;
        }
        protected virtual void Info() { }
    }

 
}
