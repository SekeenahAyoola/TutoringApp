using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringManagementApp.AbstractManager;
using TutoringManagementApp.EnumsFolder;

namespace TutoringManagementApp.Manager
{
    public class TuteeManager : ITuteeManager
    {
        
        AdminManager adminManager = new AdminManager();
        public static List<Tutee> tuteeDatabase = new List<Tutee>{
            new Tutee(1,3,TuteeLevel.Jss1,"0987666",2013)
        };
        
        public void CommentAboutTutor(Tutor tutor)
        {
            
            Console.WriteLine("WARNING ALL INAPPROPRAITE COMMENT WILL BE TAKEN DOWN");
            Console.WriteLine("Put down your comment");
            string comment = Console.ReadLine();
            bool tutorHasComment = false;
            foreach (var item in TutorManager.tutorCommentsDatabase)
            {
                if (item.Key == tutor)
                {
                    tutorHasComment = true;
                    break;
                }
            }
            if (tutorHasComment == true)
            {
                foreach (var item in TutorManager.tutorCommentsDatabase)
                {
                    if (item.Key == tutor)
                    {
                        item.Value.Add(comment);
                        Console.WriteLine("Thanks for leaving a comment");
                        break;
                    }
                }
            }
            else
            {
                List<string> comments = new List<string>
                {
                    comment
                };
                TutorManager.tutorCommentsDatabase.Add(tutor,comments);
                Console.WriteLine("Thanks for leaving a comment");
            }

            AdminManager.AllComments.Add(comment);
        }

        public Tutee GetTutee(int pin)
        {
            Tutee tutee = null;
           foreach (var item in tuteeDatabase)
           {
                if (item.Pin == pin)
                {
                    return item;
                }
           }
           return tutee;
        }

        public void PickTutor(Tutor tutor, Tutee tutee)
        {

            bool tutorHasTutee = false;
            foreach (var item in TutorManager.tuteesTutorChoice)
            {
                if (item.Key == tutor)
                {
                    tutorHasTutee = true;
                    break;
                }
            }
            if (tutorHasTutee == true)
            {
                foreach (var item in TutorManager.tuteesTutorChoice)
                {
                    if (item.Key == tutor)
                    {
                        item.Value.Add(tutee);
                        Console.WriteLine("Thanks for using our channel. Please await contact from tutor");
                    }
                }
            }
            else
            {
                List<Tutee> tutees = new List<Tutee>
                {
                    tutee
                };
                TutorManager.tuteesTutorChoice.Add(tutor,tutees);
                Console.WriteLine("Thanks for using our channel. Please await contact from tutor");
            }
        }

        public bool RateTutor(Tutor tutor)
        {   
            
            bool valid = true;
            bool alreadyRated = false;
            foreach (var item in TutorManager.RatingDatabase)
            {
                if (item.Key == tutor)
                {
                    alreadyRated = true;
                }
            }
            if (alreadyRated == true)
            { 

                //ViewTutors(TutorManager.tutorDatabase);
                Console.WriteLine("Help others choose a good tutor.");
                Console.WriteLine("Enter:\n1 - Poor \n2 - Not Good \n3 - Good \n4- Very Good \n5- Excellent");
                TutorRatings RateTutor = (TutorRatings)Enum.Parse(typeof(TutorRatings), Console.ReadLine());
                if ((int)RateTutor > 5 || (int)RateTutor < 0)
                {
                    valid = false;
                }
                if (valid == true)
                {
                    Console.WriteLine("Thanks for rating tutor");
                    foreach (var item in TutorManager.RatingDatabase)
                    {
                        if (tutor == item.Key)
                        {
                            item.Value.Add(RateTutor);
                            Console.WriteLine("Thanks for Rating");
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Help others choose a good tutor.");
                Console.WriteLine("Enter:\n1 - Poor \n2 - Not Good \n3 - Good \n4- Very Good \n5- Excellent");
                TutorRatings RateTutor = (TutorRatings)Enum.Parse(typeof(TutorRatings), Console.ReadLine());
                if ((int)RateTutor > 5 || (int)RateTutor < 0)
                {
                    valid = false;
                }
                else
                {
                    List<TutorRatings> tutorRatings = new List<TutorRatings>{
                    RateTutor
                    };
                    TutorManager.RatingDatabase.Add(tutor,tutorRatings);

                    Console.WriteLine("Thanks for rating tutor");
                    
                }
            }
            return valid;
        }

        public void RegisterTutee(int userId, string phoneNumber,int pin)
        {
            Console.WriteLine("What level are you?");
            Console.WriteLine("Input \n1 - JSS1 \n2 - JSS2 \n3 - JSS3 \n4 - SS1 \n5 - SS2 \n6 - SS3 \n: ");
            TuteeLevel tuteeLevel  = (TuteeLevel)Enum.Parse(typeof(TuteeLevel), Console.ReadLine());
            if ((int)tuteeLevel < 1 || (int)tuteeLevel > 6)
            {
                
                Console.WriteLine("Invalid input detected");
                RegisterTutee(userId,phoneNumber,pin);
            }
            Tutee tutee = new Tutee(tuteeDatabase.Count+1,userId, tuteeLevel, phoneNumber, pin);
            tuteeDatabase.Add(tutee);
        }

        public Dictionary<int, Tutor> ViewTutors(List<Tutor> tutors)
        {
            Dictionary<int, Tutor> AllTutors = new Dictionary<int, Tutor>();
            int i = 1;
            foreach (var tutor in tutors)
            {
                AllTutors.Add(i,TutorManager.tutorDatabase[i-1]);
                i++;
            }
            foreach (var item in AllTutors)
            {
                Console.Write("Tutor Id: "+item.Key);
                foreach (var user in UserManager.userDatabase)
                {
                    if(user.UserId == item.Value.UserId)
                    {
                        Console.Write($"  FullName: {user.FirstName} {user.LastName}, Gender: {user.Gender} ");
                        Console.WriteLine();
                    }
                }
                Console.Write($"Qualification: {item.Value.Qualification}\n");
                
            }
            
           
            return AllTutors;
        }
        public bool Check(int check)
        {
            bool exist = false;
            if (check <= TutorManager.tutorDatabase.Count)
            {
                exist = true;
                return exist;
            }
            else
            {
                Console.WriteLine("Tutor does not exist");
                return exist;
            }
        }

        public void ViewRatings()
        {
            bool hasRatings = false;
            foreach (var item in TutorManager.RatingDatabase)
            {
                if (item.Key != null)
                {
                    hasRatings = true;
                }
            }
           
            if (hasRatings == true)
            {
                foreach (var item in TutorManager.RatingDatabase)
                {
                    foreach (var tutor in UserManager.userDatabase)
                    {
                        if (item.Key.UserId == tutor.UserId)
                        {
                            Console.WriteLine($"Tutor Id:{item.Key.TutorIdNumber} TutorName: {tutor.FirstName} {tutor.LastName} QUalification:{item.Key.Qualification} -->");
                        }
                    }
                    int count = 1;
                    foreach (var rating in item.Value)
                    {
                        if (count ==1)
                        {

                            Console.WriteLine($"Rating(s):\n{count}- "+rating.ToString());
                        }
                        else
                        {
                            Console.WriteLine($"{count}- {rating.ToString()}");
                        }
                       count++;
                    }
                }
            }
            else
            {
                Console.WriteLine("There are no ratings yet");
            }
           
        }
    }
}