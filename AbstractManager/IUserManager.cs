using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringManagementApp.EnumsFolder;

namespace TutoringManagementApp.AbstractManager
{
    public interface IUserManager
    {
        
        // Remember to check user existance before registering and login and to return null.
        public bool RegisterUser(int userId, string firstName, string lastName, int age, Gender gender, UserType userType,string email, int pin);
        public UserType LoginUser(int pin, string email);
        public void CheckPin(int pin , int reEnterPin);
        
    }
}