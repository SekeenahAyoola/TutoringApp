using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringManagementApp.EnumsFolder;

namespace TutoringManagementApp.AbstractManager
{
    public interface ITutorManager
    {
        public void ViewComment(int idNumber);
        public void ViewInterstedTutee(int idNumber);
        public void RegisterTutor(int userId, string phoneNumber, int pin);
        public void viewRatings(int id);
        public Tutor GetTutor(int tutorIdNumber);
        public int GetTutorIdNumber(int pin);
        public bool HasComment(int idNumber);
        public bool HasTutee(int idNumber);

        //public void PickTutee(int tuteeIdNumber);
    }
}