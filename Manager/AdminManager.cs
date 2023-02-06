using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringManagementApp.AbstractManager;
using TutoringManagementApp.EnumsFolder;

namespace TutoringManagementApp.Manager
{
    public class AdminManager : IAdminManager
    { 
        public static List<Admin> AdminDatabase = new List<Admin>{
            new Admin(1,4,"09234343","samadadepo@gmail.com",4274)
        };
        public static List<string> AllComments  = new List<string>();

        public void ChangePin(string email)
        {
            Console.WriteLine("Input previous pin");
            int oldPin = int.Parse(Console.ReadLine());
            //int newPin = oldPin;
            foreach (var admin in AdminDatabase)
            {
                if (admin.Email == email && oldPin == admin.Pin)
                {
                    Console.WriteLine("Enter your new pin: ");
                    int newPin = int.Parse(Console.ReadLine());
                    Console.WriteLine("Re-Enter Pin:");
                    int reEnterPin = int.Parse(Console.ReadLine());
                    if (newPin == reEnterPin)
                    {
                        admin.Pin = newPin;
                        foreach (var item in UserManager.userDatabase)
                        {
                            if (item.Pin == oldPin)
                            {
                                item.Pin = newPin;
                                Console.WriteLine("Pin changed successfully");
                            }
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("Unable to change pin");
                        ChangePin(email);
                    }
                }
            }
            
            
        }

        public void RemoveComment()
        {
           if (AllComments.Count != 0)
           {
                Console.WriteLine("What is the number of the comment you which to remove");
            int commentNumber = int.Parse(Console.ReadLine());
            for (int i = 0; i < commentNumber; i++)
            {
                if (i == commentNumber -1)
                {
                    AllComments.Remove(AllComments[i]);
                    Console.WriteLine("Comment removed successfully");
                }
            }
           }
           else
           {
                Console.WriteLine("Comment Database is Empty");
           }
            
            
        }


        public void ViewAllComment()
        {
            bool hasComment = false;
            foreach (var item in AllComments)
            {
                if (item !=null)
                {
                    hasComment = true;
                }
            }
            
            if (hasComment == true)
            {
                int number = 1;
                foreach (var comment in AllComments)
                {
                    Console.WriteLine(number +" - "+comment);
                    number++;
                }
            }
            else
            {
                Console.WriteLine("There are no comments yet");
            }
        }
        
        
    }
}