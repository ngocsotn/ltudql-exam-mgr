using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Views
{
    public interface IRegisterView
    {
        string FullName { get; set; }
        string Email { get; set; }
        string Gender { get; set; }
        DateTime DOB { get; set; }
        string ADR { get; set; }
        string Password { get; set; }

        event EventHandler Register;
    }
}
