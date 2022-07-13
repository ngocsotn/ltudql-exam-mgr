using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Views
{
    public interface ITopicView
    {
        string Subject { get; set; }
        string Grade { get; set; }
        int Time { get; set; }
        string Question_Content { get; set; }
        string Question_ContentAdded { get; set; }
        string Note { get; set; }

        ListBox lb_Question { get; set; }
        ListBox lb_QuestionAdded { get; set; }

        //các event sử dụng chỉ form thêm/update của phần quản lý câu hỏi
        event EventHandler TopicEvent_Add_Topic;
        event EventHandler TopicEvent_Update_Topic;
        event EventHandler TopicEvent_SendToAdded;
        event EventHandler TopicEvent_RemoveFromAdded;
        event EventHandler TopicEvent_Load;
    }
}
