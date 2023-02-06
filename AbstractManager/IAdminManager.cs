using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutoringManagementApp.EnumsFolder;

namespace TutoringManagementApp.AbstractManager
{
    public interface IAdminManager
    {
        public void ViewAllComment();
        // public TutorRatings AssignRating();
        public void RemoveComment();
        public void ChangePin(string email);
    }
}