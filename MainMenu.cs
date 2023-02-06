using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringManagementApp.AbstractManager;
using TutoringManagementApp.EnumsFolder;
using TutoringManagementApp.Manager;

namespace TutoringManagementApp
{
    public class MainMenu
    {
        IUserManager user = new UserManager();
        ITuteeManager tutee = new TuteeManager();
        ITutorManager tutor = new TutorManager();
        IAdminManager admin = new AdminManager();
        ISuperAdminManager superAdmin = new SuperAdminManager();
        
        public int GreetUser()
        {
            Console.WriteLine("Press '1' to Register an account \nPress 2 to Login");
            int registerOrLogin = Convert.ToInt32(Console.ReadLine()); 
            return registerOrLogin;
        }

        public void EnteringPage(int registerOrLogin)
        {
            if (registerOrLogin == 1)
            {
               Register();
                
            }
            else if (registerOrLogin == 2)
            {
                Login();
            }
            else
            {
                GreetUser();
                Login();
            }
        }
        public void Register()
        {
            Console.Write("Enter your Firstname: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter your Lastname(Surname): ");
            string lastName = Console.ReadLine();
            Console.Write("Enter your age: ");
            int age = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter 1 for Male \nEnter 2 for Female: ");
            Gender gender = (Gender) Enum.Parse(typeof(Gender), Console.ReadLine());
            if ((int)gender < 1 || (int) gender > 2)
            {
                Register();
            }
            Console.Write("Enter your email: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.WriteLine("Input you pin: ");
            int pin = Convert.ToInt32(Console.ReadLine());
            Console.Write("Re-Enter your pin: ");
            int reEnterPin = Convert.ToInt32(Console.ReadLine());
            user.CheckPin(pin, reEnterPin);
            Console.WriteLine("Enter 1 if you want to register as a Tutor");
            Console.WriteLine("Or Enter 2 if you want to register as a Tutee");
            UserType userType =(UserType) Enum.Parse(typeof(UserType),Console.ReadLine());
            bool justRegister = user.RegisterUser(UserManager.userDatabase.Count+1,firstName,lastName,age,gender,userType,email,pin);
            switch (userType)
            {
                case UserType.Tutor:
                
                if (justRegister)
                {
                    tutor.RegisterTutor(UserManager.userDatabase.Count,phoneNumber,pin);
                    Console.WriteLine("Registration suceesful");
                    Login();
                }
                break;

                case UserType.Tutee:
                if (justRegister)
                {
                    tutee.RegisterTutee(UserManager.userDatabase.Count,phoneNumber, pin);
                    Console.WriteLine("Registration suceesful");
                    Login();
                }
                break;
                default:
                Console.WriteLine("invalid input");
                Register();
                break;
            }


        }
        public void Login()
        {
            Console.Write("Input your Email: ");
            string email= Console.ReadLine();
            Console.Write("Input your pin: ");
            int pin = Convert.ToInt32(Console.ReadLine());
            UserType userType = user.LoginUser(pin,email);
            switch (userType)
            {
                case UserType.SuperAdmin:
                superAdminMenu();
                break;
                case UserType.Admin:
                AdminMenu(email);
                break;
                case UserType.Tutee:
                TuteeMenu(pin);
                break;
                case UserType.Tutor:
                int tutorIdNumber= tutor.GetTutorIdNumber(pin);
                TutorMenu(tutorIdNumber,pin);
                break;
                case UserType.Unknown:
                Console.WriteLine("Unregonised User");
                Login();
                break;
                default:
                Console.WriteLine("Unregonised User");
                Login();
                break;

            }
        }

        

        public void TutorMenu( int idNumber, int pin)
        {
            
            Console.WriteLine("Welcome!");
            Console.WriteLine("Enter: --> 1- ViewComments \n2- View Ratings \n3- View Interested Tutee \n4-Log Out");
            int pick = int.Parse(Console.ReadLine());
            switch (pick)
            {
                case 1:
                tutor.ViewComment(idNumber);
                TutorMenu(idNumber,pin);
                Console.WriteLine();
                break;
                case 2:
                tutor.viewRatings(pin);
                TutorMenu(idNumber,pin);
                Console.WriteLine();
                break;
                case 3:
                tutor.ViewInterstedTutee( pin);
                TutorMenu(idNumber,pin);
                Console.WriteLine();
                break;
                case 4:
                Console.WriteLine("Thanks for using our channel");
                EnteringPage(GreetUser());
                break;
                default:
                Console.WriteLine("Invalid Input");
                TutorMenu(idNumber,pin);
                Console.WriteLine();
                Console.WriteLine();
                break;

            }
        }
        public void TuteeMenu(int pin)
        {
            Tutor thisTutor = new Tutor();
            Tutee thisTutee = tutee.GetTutee(pin);
            int tutorId = default;
            Console.WriteLine();
            Console.WriteLine("Welcome!");
            Console.WriteLine("Enter: --> 1- View Tutors \n2- Pick Tutors \n3- Rate Tutors \n4- Comment about Tutor \n5 - View tutors Rating \n 6- Log Out");
            int pick = int.Parse(Console.ReadLine());
            switch (pick)
            {
                case 1:
                tutee.ViewTutors(TutorManager.tutorDatabase);
                TuteeMenu(pin);
                Console.WriteLine();
                break;
                case 2:
                Console.WriteLine("Input tutor Id Number");
                tutorId = Convert.ToInt32(Console.ReadLine());
                bool check = tutee.Check(tutorId); 
                if (check == true)
                {
                    thisTutor = tutor.GetTutor(tutorId);
                    tutee.PickTutor(thisTutor, thisTutee);
                    TuteeMenu(pin);
                }
                else
                {
                    TuteeMenu(pin);
                }
                Console.WriteLine();
                break;
                case 3:
                Console.WriteLine("Input tutor Id Number");
                tutorId = Convert.ToInt32(Console.ReadLine());
                bool check1 = tutee.Check(tutorId); 
                if (check1 == true)
                {
                    thisTutor = tutor.GetTutor(tutorId);
                    bool valid = tutee.RateTutor(thisTutor);
                    if (valid == false)
                    {
                        Console.WriteLine("Inavlid input");
                        TuteeMenu(pin);
                    }
                    else
                    {
                        TuteeMenu(pin);
                    }
                    
                }
                else
                {
                    TuteeMenu(pin);
                }
                Console.WriteLine();
                break;
                case 4:
                Console.WriteLine("Input tutor Id Number");
                tutorId = Convert.ToInt32(Console.ReadLine());
                bool check2 = tutee.Check(tutorId);
                if (check2 == true)
                {
                    thisTutor = tutor.GetTutor(tutorId);
                    tutee.CommentAboutTutor(thisTutor);
                    TuteeMenu(pin);
                }
                else
                {
                    TuteeMenu(pin);
                }
                break;
                case 5:
                tutee.ViewRatings();
                TuteeMenu(pin);
                break;
                case 6:
                Console.WriteLine("Thanks for using our channel");
                EnteringPage(GreetUser());
                break;
                default:
                Console.WriteLine("Invalid Input");
                TuteeMenu(pin);
                break;
        }
        }
        public void AdminMenu(string email)
        {
            Console.WriteLine("Welcome!");
            Console.WriteLine("Enter: --> 1- Change Pin \n2- View Comments \n3 - Remove Comments \n4 - Log Out");
            int pick = Convert.ToInt32(Console.ReadLine());
            switch (pick)
            {
                case 1:
                admin.ChangePin(email);
                AdminMenu(email);
                break;
                case 2:
                admin.ViewAllComment();
                AdminMenu(email);
                break;
                case 3:
                admin.RemoveComment();
                AdminMenu(email);
                break;
                case 4:
                Console.WriteLine("Thanks for using our channel");
                EnteringPage(GreetUser());
                break;
                default:
                Console.WriteLine("Invalid Input");
                AdminMenu(email);
                break;
            }

        }
        public void superAdminMenu()
        {
             Console.WriteLine("Welcome!");
            Console.WriteLine("Enter: --> 1- View Comments \n2- Create Admin \n3- View All Admin \n4- Log Out");
            int pick = Convert.ToInt32(Console.ReadLine());
            switch (pick)
            {

                case 1:
                superAdmin.ViewComment();
                superAdminMenu();
                break;
                case 2:
                superAdmin.CreatAdmin();
                superAdminMenu();
                break;
                case 3:
                superAdmin.ViewAllAdmin();
                superAdminMenu();
                break;
                case 4:
                EnteringPage(GreetUser());
                break;
                default:
                Console.WriteLine("Invalid Input");
                superAdminMenu();
                break;
            }
        }
        

    }
}