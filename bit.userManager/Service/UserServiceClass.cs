namespace bit.userManager.Service
{
    public class UserServiceClass
    {
        public UserServiceClass() { }
        public string name = "john";

        public string getName(string userName)
        {
            userName = name;
            return userName; 
        }
    }
}
