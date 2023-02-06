using System;

namespace TutoringManagementApp
{
        class Program
    {
        //When caliing a manager class you are to instansiate the interface class not the implemented one
        static void Main(string[] args)
        {
           MainMenu menu = new MainMenu();
          int n = menu.GreetUser();
           menu.EnteringPage(n);
        }
    }
}
