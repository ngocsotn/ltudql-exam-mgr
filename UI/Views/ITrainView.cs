using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Views
{
    public interface ITrainView
    {
        // biến của 3 control trên form
        string HocSinhID{ get; set; }
        string BoDe{get; set; }
        DateTime HanChot { get; set; }


        //Sự kiện của form
        event EventHandler Add_Train;
        event EventHandler Update_Train;
        event EventHandler Load;
    }

}
