using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Views
{
    public interface IQuestionView
    {
        string Subject { get; set; }
        string Grade { get; set; }
        int Difficult { get; set; }
        string Question_Content { get; set; }
        string A { get; set; }
        string B { get; set; }
        string C { get; set; }
        string D { get; set; }
        string E { get; set; }
        string F { get; set; }
        string hint { get; set; }
        bool IsPro { get; set; }
        bool IsAnswerA { get; set; }
        bool IsAnswerB { get; set; }
        bool IsAnswerC { get; set; }
        bool IsAnswerD { get; set; }
        bool IsAnswerE { get; set; }
        bool IsAnswerF { get; set; }

        event EventHandler QuestionEvent_Add_Question;
        event EventHandler QuestionEvent_Update_Question;
        event EventHandler QuestionEvent_Load_Question;
    }
}
