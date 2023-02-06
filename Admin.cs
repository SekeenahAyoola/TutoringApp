using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringManagementApp.EnumsFolder;

namespace TutoringManagementApp
{
    public class Admin 
    {
        public int UserId;
        public int AdminIdNumber{ get; set;}
        public string PhoneNumber{get; set;}
        public int Pin;
        public string Email{get; set;}
        public Admin(int adminIdNumber, int userId, string phoneNumber, string email,int pin)
        {
            Pin = pin;
            Email = email;
            UserId = userId;
            AdminIdNumber = adminIdNumber;
            PhoneNumber =phoneNumber;
        
        }
        
    }
}