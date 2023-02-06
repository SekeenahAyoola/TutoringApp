using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringManagementApp.EnumsFolder;

namespace TutoringManagementApp
{
    public class Tutor 
    {
        public int UserId;
        public int TutorIdNumber{get; set;}
        public string PhoneNumber{get; set;}
        public string RegistrationNumber{get; set;}
        public Qualification Qualification{get; set;}
        public int Pin;
        public List<string> comments{get; set;}
        public TutorRatings tutorRating {get; set;}

    public Tutor(int tutorIdNumber, int userId, string phoneNumber, Qualification qualification, int pin)
    {
      
        Pin = pin;
        UserId = userId;
        TutorIdNumber = tutorIdNumber;
        PhoneNumber = phoneNumber;
        Qualification = qualification;
        RegistrationNumber = "T.2300"+tutorIdNumber.ToString();
    }
    public Tutor()
    {
        
    }
    
    }
}