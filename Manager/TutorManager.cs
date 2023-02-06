using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringManagementApp.AbstractManager;
using TutoringManagementApp.EnumsFolder;

namespace TutoringManagementApp.Manager
{
    public class TutorManager : ITutorManager
    {
       
        public static List<Tutor> tutorDatabase = new List<Tutor>{
            new Tutor(1,2,"0987655",Qualification.NationalDiploma,4272)
        };
        public static Dictionary<Tutor, List<TutorRatings>> RatingDatabase = new Dictionary<Tutor, List<TutorRatings>>();
        public  static Dictionary<Tutor, List<string>> tutorCommentsDatabase = new Dictionary<Tutor, List<string>>();
        public static Dictionary<Tutor, List<Tutee>> tuteesTutorChoice = new Dictionary<Tutor, List<Tutee>>();
       
       
        public void RegisterTutor(int userId, string phoneNumber, int pin)
        {
            Console.WriteLine("What is your qualification?");
            Console.WriteLine("Enter 1- NationalDiploma");
            Qualification qualification  = (Qualification)Enum.Parse(typeof(Qualification), Console.ReadLine());
             if ((int)qualification != 1 )
            {
                MainMenu menu =  new MainMenu();
                Console.WriteLine("Invalid input detected");
               RegisterTutor(userId,phoneNumber,pin);
            }
            Tutor tutor = new Tutor(tutorDatabase.Count+1,userId, phoneNumber, qualification, pin);
            tutorDatabase.Add(tutor);
        }
        public void ViewComment( int id )
        {
            bool hasComment = HasComment(id);
            if(hasComment == true)
            {
                int count = 1;
                foreach (var item in tutorCommentsDatabase)
                {
                    if (id == item.Key.TutorIdNumber)
                    {
                        foreach (var comment in item.Value)
                        {
                            Console.WriteLine(count +"- "+comment);
                            count++;
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("You have no comments yet");
            }
           
        }

        public void ViewInterstedTutee(int pin)
        {
            bool tutorHasTutee = HasTutee(pin);
            if (tutorHasTutee == true)
            {
                foreach (var item in tuteesTutorChoice)
                {
                    if (pin == item.Key.Pin)
                    {
                        
                    foreach (var tutee in item.Value)
                    {
                        int count =1;
                        Console.WriteLine($"{count}:");
                        foreach (var user in UserManager.userDatabase)
                        {
                            if (user.UserId == tutee.UserId)
                            {
                                Console.Write($"Name: {user.FirstName} {user.LastName}, Gender: {user.Gender.ToString()}, ");
                                Console.WriteLine($"Level:{tutee.TuteeLevel.ToString()}, Phone Number: {tutee.PhoneNumber}");
                            }
                        }
                        count++;
                    }
                    Console.WriteLine("You can now contact desired Tutee");
                    }

                }
            }
            else
            {
                Console.WriteLine("Sorry, You don't have any interested tutee");
            }
            
        }

        public Tutor GetTutor(int tutorIdNumber)
        {
            Tutor tutor = null;
            foreach (var item in TutorManager.tutorDatabase)
            {
                if (item.TutorIdNumber == tutorIdNumber)
                {
                    tutor = item;
                }
            }
            return tutor;
        }

        public int GetTutorIdNumber(int pin)
        {
            int idNumber = 0;
            foreach (var item in TutorManager.tutorDatabase)
                {
                    if (item.Pin == pin)
                    {
                        idNumber = item.TutorIdNumber;
                    }
                }
            return idNumber;
        }

        public void viewRatings(int pin)
        {
            bool hasRatings = HasRatings(pin);
            if (hasRatings == true)
            {
                foreach (var item in RatingDatabase)
                {
                    if (item.Key.Pin == pin )
                    {
                        Console.Write($"Tutor Id: {item.Key.TutorIdNumber} -->");
                        int count = 1;
                        foreach (var rating in item.Value)
                        {
                            if (count == 1)
                            {
                                Console.WriteLine($"Rating(s):{count} - "+rating.ToString());
                            }
                            else
                            {
                                Console.WriteLine($"{count} - {rating.ToString()}");
                            }
                            count++;
                        }
                    }
                }
            
            }
            else
            {
                Console.WriteLine("You have no ratings");
            }
        
        }

        public bool HasComment(int idNumber)
        {
            Tutor tutor = GetTutor(idNumber);
            bool hasComment = false;
            foreach (var tut in tutorCommentsDatabase)
            {
                if (tut.Key.TutorIdNumber == idNumber)
                {
                    hasComment = true;
                }
            }
            return hasComment;
        }

        public bool HasTutee(int pin)
        {
            bool hasTutee = false;
            if (tuteesTutorChoice.Count > 0)
            { 
                foreach (var tut in tuteesTutorChoice)
                {
                    if (tut.Key.Pin == pin)
                    {
                        hasTutee = true;
                    }
                }
                return hasTutee;
            }
            
            else
            {
                return hasTutee;
            }
           
        }
        public bool HasRatings(int pin)
        {
            bool hasRatings = false;
            foreach (var tut in RatingDatabase)
            {
                if (tut.Key.Pin == pin)
                {
                    
                    hasRatings = true;
                }
            }
            return hasRatings;
        }
    }
}