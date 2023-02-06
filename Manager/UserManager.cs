using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringManagementApp.AbstractManager;
using TutoringManagementApp.EnumsFolder;

namespace TutoringManagementApp.Manager
{
    
    public class UserManager : IUserManager

    {// remember to mock the superadmin
        public static List<User> userDatabase = new List<User>{
            new User(1,"Sekeenah", "Ayoola", 20,Gender.Female, UserType.SuperAdmin, "ayoolasekeenah@gmail.com", 4272),
            new User(2,"Habeedat", "Muritala",26,Gender.Female,UserType.Tutor,"habeedatmuritala@gmail.com",4273 ),
            new User(3,"Teslimah","Ayoola",12,Gender.Female,UserType.Tutee,"ayoolateslimah@gmail.com",2013),
            new User (4,"Samad","Adepo",26,Gender.Male,UserType.Admin,"samadadepo@gmail.com",4274)
        };
        
        
        public bool CheckExistence(string email)
        {
            foreach (var user in userDatabase)
            {
                if (user.Email == email)
                {
                    return true;
                }
            }
            return false;
        }

        public bool RegisterUser(int userId, string firstName, string lastName, int age, Gender gender, UserType userType, string email, int pin)
        {
            bool checkExistence = CheckExistence(email);
            if (checkExistence)
            {
                Console.WriteLine("User already exist");
                MainMenu menu = new MainMenu();
                menu.EnteringPage(menu.GreetUser());
                return false;
            }
            else

            {
                User user = new User(userId,firstName,lastName, age,gender,userType,email,pin);
                userDatabase.Add(user);
               return true;
            }
        }

        public UserType LoginUser(int pin, string email)
        {
            UserType userType = UserType.Unknown;
            foreach (var user in userDatabase)
            {
                if (user.Pin == pin && user.Email == email)
                {
                    userType = user.UserType;
                    return userType;
                }
            }
            return userType;
       }

        public void CheckPin(int pin , int reEnterPin)
        {
            if (pin != reEnterPin)
            {
                Console.Beep();
                Console.WriteLine("Pin not correct");
                Console.Write("Input your pin: ");
                pin = Convert.ToInt32(Console.ReadLine());
                Console.Write("Re-Enter your pin: ");
                reEnterPin = Convert.ToInt32(Console.ReadLine());
                CheckPin(pin, reEnterPin);
            }
            
        }
    }
}