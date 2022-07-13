using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Views
{
    public interface IUserView
    {
        string PersonalID { get; set; }
        int UserLevel { get; set; }
        string Email { get; set; }
        string Password { get; set; }
        string Address { get; set; }

        string IDClass { get; set; }
        string FullName { get; set; }
        DateTime DayOfBirth { get; set; }
        string Gender { get; set; }

        //Student
        int isPro { get; set; }

        //Teacher
        string SubjectID { get; set; }


        // event EventHandler Add;
        event EventHandler Add_User;
        event EventHandler Update_User;
      
    }
}
