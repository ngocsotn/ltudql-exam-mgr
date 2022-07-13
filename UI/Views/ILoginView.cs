using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Views
{
    public interface ILoginView
    {
        string UserID { get; set; }
        string Password { get; set; }
        bool HideForm { get; set; }
        event EventHandler Login;
        event EventHandler Register;
    }
}
