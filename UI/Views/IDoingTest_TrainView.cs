using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UI.Views
{
    public interface IDoingTest_TrainView
    {
        //mã bộ đề
        string TopicID { get; set; }
        //tổng số câu hỏi
        int TotalQuestions { get; set; }
        //các câu đã trả lời
        int TotalAnsered { get; set; }
        //thời gian (chuyển từ DB lên, DB ở dạng giây)
        int Time { get; set; }
        //nội dung câu hỏi
        string Question_Content { get; set; }
        //nội dung các câu A,B,C,D...
        string A { get; set; }
        string B { get; set; }
        string C { get; set; }
        string D { get; set; }
        string E { get; set; }
        string F { get; set; }
        //gợi ý(nếu có)
        string hint { get; set; }

        //đáp án
        bool IsAnswerA { get; set; }
        bool IsAnswerB { get; set; }
        bool IsAnswerC { get; set; }
        bool IsAnswerD { get; set; }
        bool IsAnswerE { get; set; }
        bool IsAnswerF { get; set; }


        //các event: tên chung: DoingTest_TrainView_Event
        //Event nộp bài
        event EventHandler DoingTest_TrainView_Event_Submit;
        //nhảy đến 1 câu hỏi nào đó khi người dùng bấm
        event EventHandler DoingTest_TrainView_Event_JumpToQuestion;
    }
}
