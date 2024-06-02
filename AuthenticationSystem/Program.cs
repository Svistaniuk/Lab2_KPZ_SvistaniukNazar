using System;

namespace AuthenticationSystem
{
    public class Authenticator
    {
        private static readonly object lockObject = new object();
        private static Authenticator instance;

        private Authenticator() { }  

        public static Authenticator Instance
        {
            get
            {
                lock (lockObject)
                {
                    if (instance == null)
                    {
                        instance = new Authenticator();
                    }
                    return instance;
                }
            }
        }

        public void Authenticate(string username, string password)
        {
            Console.WriteLine($"Authenticating user '{username}' with password '{password}'...");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Authenticator authenticator1 = Authenticator.Instance;
            Authenticator authenticator2 = Authenticator.Instance;

            Console.WriteLine($"authenticator1 == authenticator2: {authenticator1 == authenticator2}");

            authenticator1.Authenticate("user1", "password123");
        }
    }
}
