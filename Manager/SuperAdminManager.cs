using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringManagementApp.AbstractManager;

namespace TutoringManagementApp.Manager
{
    public class SuperAdminManager : ISuperAdminManager
    {
        AdminManager adminManager = new AdminManager();
        public void CreatAdmin()
        {
            Console.WriteLine("Enter Admin FirstName");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter Admin LastName");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter Admin age");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Gender");
            Gender gender = (Gender)Enum.Parse(typeof(Gender),Console.ReadLine());
            Console.WriteLine("Enter Admin Phone number");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Input the email of the new Admin ");
            string email = Console.ReadLine();
            Console.WriteLine("Input the default pin");
            int pin = int.Parse(Console.ReadLine());
            bool adminExist = false;
            foreach (var admin in AdminManager.AdminDatabase)
            {
                if (admin.Email == email)
                {
                    Console.WriteLine("Admin Already exists");
                    adminExist = true;
                }
            }
            if ( adminExist ==false)
            {
                 User newUser =new User(UserManager.userDatabase.Count+1,firstName,lastName,age, gender,EnumsFolder.UserType.Admin,email,pin);
                 UserManager.userDatabase.Add(newUser);
                Admin newadmin = new Admin(UserManager.userDatabase.Count,AdminManager.AdminDatabase.Count+1,phoneNumber, email, pin);
                AdminManager.AdminDatabase.Add(newadmin);
                Console.WriteLine("Admin created successfully");
            }
           
        }
        public void ViewAllAdmin()
        {
            bool notEmpty = false;
            if (AdminManager.AdminDatabase.Count > 0 )
            {
                notEmpty = true;
            }
            if (notEmpty == true)
            {
                foreach (var user in UserManager.userDatabase)
                {
                   if (user.UserType == EnumsFolder.UserType.Admin)
                   {
                        Console.WriteLine($"Name: {user.FirstName} {user.LastName}, Age: {user.Age}, {user.Gender.ToString()}");
                   }
                }
            }
            else
            {
                 MainMenu menu = new MainMenu();
                Console.WriteLine("No Admin Created Yet");
                Console.WriteLine("Do you want to create one?");
                char creatAdmin = Convert.ToChar(Console.ReadLine());
                switch (creatAdmin)
                {
                    case 'y' :
                    CreatAdmin();
                    break;
                    case 'n':
                    menu.superAdminMenu();
                    break;
                    default:
                    Console.WriteLine("Invalid Input");
                    menu.superAdminMenu();
                    break;
                }


            }
        }
        public void ViewComment()
        {
            bool commentExist = false;
            foreach (string comment in AdminManager.AllComments)
            {
                if (comment != null)
                {
                    commentExist = true;
                }
               
            }
            if (commentExist == true)
            {
                int number = 1;
                foreach (var comment in AdminManager.AllComments)
                {
                        Console.WriteLine(number +" - "+comment);
                        number++;
                }
            }
            else
            {
                Console.WriteLine("There are no comments in the database yet");
            }
            
        }
        
        
    }
}