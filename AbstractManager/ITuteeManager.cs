using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringManagementApp.EnumsFolder;

namespace TutoringManagementApp.AbstractManager
{
    public interface ITuteeManager
    {
        public void RegisterTutee(int userId,string phoneNumber, int pin);
        public bool RateTutor(Tutor tutor);
        public bool Check(int check);
        public void PickTutor(Tutor tutor, Tutee tutee);

        //if there are multiple rating for a tutor the most occuring will be assinged.
        //Or rather the admin should view all ratings then assign the most reasonable raring based on comments
        public Dictionary<int, Tutor> ViewTutors(List<Tutor> tutor); // the list contaiins all field in the tutor class incliding rating except IdNumber
        public void CommentAboutTutor(Tutor tutor);
        public Tutee GetTutee(int pin);
        public void ViewRatings();
    }
}