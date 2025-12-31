namespace Task2.ChainOfResponsibility
{
    public class User
    {
        public string Name { get; set; }
        public int Role { get; set; }

        public User(string name, int role)
        {
            Name = name;
            Role = role;
        }
    }
}
