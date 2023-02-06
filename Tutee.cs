using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringManagementApp.EnumsFolder;

namespace TutoringManagementApp
{
    public class Tutee 
    {
        public int UserId;
        public int TuteeIdNumber{get; set;}
        public TuteeLevel TuteeLevel{get; set;}
        public string PhoneNumber{get; set;}
        public string RegistrationNumber{get; set;}
        public int Pin;
        public Tutee(int tuteeIdNumber, int userId,TuteeLevel tuteeLevel, string phoneNumber, int pin)
        {
            Pin = pin;
            UserId = userId;
            TuteeIdNumber = tuteeIdNumber;
            TuteeLevel = tuteeLevel;
            PhoneNumber = phoneNumber;
            RegistrationNumber = "S.2300"+tuteeIdNumber.ToString();
        }
    }
}