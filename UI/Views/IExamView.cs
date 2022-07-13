using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Views
{
    public interface IExamView
    {

        string Semester { get; set; }
        int Year { get; set; }
        int TypeOfExam { get; set; }
        int StatusOfExam { get; set; }
        string Topic { get; set; }
        DateTime DateOfExam { get; set; }
        ListBox lbStudent { get; set; }
        ListBox lbTopic { get; set; }
        ListBox lbStudentAdded { get; set; }

        event EventHandler Add_Exam;
        event EventHandler Update_Exam;
        event EventHandler SendToAdded;
        event EventHandler RemoveFromAdded;
        event EventHandler Load;
    }
}
