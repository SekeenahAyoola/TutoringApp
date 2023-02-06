using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringManagementApp.EnumsFolder;

namespace TutoringManagementApp
{
    public class User
    {
        public List<User> userDatabase = new List<User>();
        public int UserId{get; set;}
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public int Age{get; set;}
        public Gender Gender{get; set;}
        public UserType UserType{get; set;}
        public string Email{get; set;}
        public int Pin{get; set;}
        public string UserName{get; set;}

        public User(int userId, string firstName, string lastName, int age, Gender gender, UserType userType,string email, int pin)
        {
            UserId = userId;
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Gender = gender;
            UserType = userType;
            Email = email;
            Pin = pin;
        }
        
    }
}