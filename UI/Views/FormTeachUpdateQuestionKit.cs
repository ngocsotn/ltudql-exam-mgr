using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Models;
using UI.Presenters;

namespace UI.Views
{
    public partial class FormTeachUpdateQuestionKit : Form, ITopicView
    {
        string TopicID = "";
        TopicPresenter topic_Presenter;

        string curGradeID = "";
        string curSubjectID = "";
        string curQuestionID_NotAdd = "";
        string curQuestionID_Added = "";

        public string Subject
        {
            get => (comboBoxSubject.SelectedItem as dynamic).Value; set
            {
                for (int i = 0; i < comboBoxSubject.Items.Count; i++)
                {
                    if ((comboBoxSubject.Items[i] as dynamic).Value == value)
                    {
                        comboBoxSubject.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        public string Grade
        {
            get => (comboBoxGrade.SelectedItem as dynamic).Value; set
            {
                for (int i = 0; i < comboBoxGrade.Items.Count; i++)
                {
                    if ((comboBoxGrade.Items[i] as dynamic).Value == value)
                    {
                        comboBoxGrade.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        public int Time { get => int.Parse(textBoxTime.Text); set => textBoxTime.Text = value.ToString(); }
        public string Question_Content { get => richTextBoxQuestionContent.Text; set => richTextBoxQuestionContent.Text = value; }
        public string Question_ContentAdded { get => richTextBoxAddedQuestionContent.Text; set => richTextBoxAddedQuestionContent.Text = value; }
        public string Note { get => textBoxNote.Text; set => textBoxNote.Text = value; }

        public ListBox lb_Question { get => listBoxQuestions; set => listBoxQuestions = value; }
        public ListBox lb_QuestionAdded { get => listBoxAddedQuestions; set => listBoxAddedQuestions = value; }

        public event EventHandler TopicEvent_Add_Topic;
        public event EventHandler TopicEvent_Update_Topic;
        public event EventHandler TopicEvent_SendToAdded;
        public event EventHandler TopicEvent_RemoveFromAdded;
        public event EventHandler TopicEvent_Load;
        UI.Presenters.MainPresenter.LoadAll HamLoad = null;
        public FormTeachUpdateQuestionKit()
        {
            InitializeComponent();
        }
        public FormTeachUpdateQuestionKit(string inputID, UI.Presenters.MainPresenter.LoadAll x)
        {
            HamLoad = x;
            TopicID = inputID;
            InitializeComponent();
            Load += FormTeachUpdateQuestionKit_Load;
        }

        private void FormTeachUpdateQuestionKit_Load(object sender, EventArgs e)
        {
            // không cho sửa Khối và Môn do mỗi đề phải thuộc về 1 môn và khối nhất định
            comboBoxGrade.Enabled = false;
            comboBoxSubject.Enabled = false;
            buttonRemoveQuestions.Enabled = false;
            buttonAddQuestions.Enabled = false;
            topic_Presenter = new TopicPresenter(this, TopicID);
            //load lên form dựa trên topicID nhận vào từ đầu
            LoadSubject();
            LoadGrade();
            LoadTimeAndNote();
            LoadQuestionsAdded();
            LoadQuestions();
        }

        private void LoadSubject()
        {
            using (var db = new QLDTDataContext())
            {
                var singleTopic = db.TOPICs.Where(i => i.TOPICID == TopicID).FirstOrDefault();
                var list_Subject = db.SUBJECTs.Where(i => i.SUBJECTID == singleTopic.SUBJECTID);
                foreach (var item in list_Subject)
                {
                    comboBoxSubject.Items.Add(new { Text = item.SUBJECTNAME, Value = item.SUBJECTID });
                }
                curSubjectID = singleTopic.SUBJECTID;
                comboBoxSubject.DisplayMember = "Text";
                comboBoxSubject.ValueMember = "Value";
                if (comboBoxSubject.Items.Count > 0)
                {
                    comboBoxSubject.SelectedIndex = 0;
                }
            }
        }
        private void LoadGrade()
        {
            using (var db = new QLDTDataContext())
            {
                var singleTopic = db.TOPICs.Where(i => i.TOPICID == TopicID).FirstOrDefault();
                var list = db.GRADEs.Where(i => i.GRADEID == singleTopic.GRADEID);
                foreach (var item in list)
                {
                    comboBoxGrade.Items.Add(new { Text = item.DISPLAYNAME, Value = item.GRADEID });
                }
                curGradeID = singleTopic.GRADEID;
                comboBoxGrade.DisplayMember = "Text";
                comboBoxGrade.ValueMember = "Value";
                if (comboBoxGrade.Items.Count > 0)
                {
                    comboBoxGrade.SelectedIndex = 0;
                }
            }
        }
        private void LoadTimeAndNote()
        {
            using (var db = new QLDTDataContext())
            {
                var singleTopic = db.TOPICs.Where(i => i.TOPICID == TopicID).FirstOrDefault();
                var TopicDetails = db.TOPIC_DETAILs.Where(i => i.TOPICID == TopicID);
                foreach (var temp in TopicDetails)
                {
                    textBoxNote.Text = temp.NOTES;
                    break;
                }
                textBoxTime.Text = (singleTopic.TOTALTIME / 60).ToString();
            }
        }
        private void LoadQuestionsAdded()
        {
            richTextBoxAddedQuestionContent.Clear();
            listBoxAddedQuestions.DisplayMember = "Text";
            listBoxAddedQuestions.ValueMember = "Value";
            using (var db = new QLDTDataContext())
            {
                listBoxAddedQuestions.Items.Clear();
                //lấy list QUESTIONID từ details trước
                var ListOfQuestions = db.TOPIC_DETAILs.Where(i => i.TOPICID == TopicID).ToList();

                if(ListOfQuestions == null)
                {
                    return;
                }

                //lấy và load Question dựa vào questionID
                foreach (var singleQuestion in ListOfQuestions)
                {
                    var Question = db.QUESTIONs.Where(i => i.QUESTIONID == singleQuestion.QUESTIONID).FirstOrDefault();

                    listBoxAddedQuestions.Items.Add(new { Text = Question.QUESTIONID, Value = Question.QUESTIONID });
                }
                if (listBoxAddedQuestions.SelectedIndex < listBoxAddedQuestions.Items.Count - 1)
                    listBoxAddedQuestions.SelectedIndex += 1;
            }
        }
        private bool CheckIfQuestionExistInAdded(string QuestionID)
        {
            for (int i = 0; i < listBoxAddedQuestions.Items.Count; i++)
            {
                if ((listBoxAddedQuestions.Items[i] as dynamic).Value.ToString() == QuestionID)
                {
                    return false;
                }
            }
            return true;
        }
        private void LoadQuestions()
        {
            richTextBoxQuestionContent.Clear();
            listBoxQuestions.DisplayMember = "Text";
            listBoxQuestions.ValueMember = "Value";
            using (var db = new QLDTDataContext())
            {
                listBoxQuestions.Items.Clear();
                //lấy toàn bộ Question dựa theo mã khối và môn
                var ListOfQuestions = db.QUESTIONs.Where(i => i.SUBJECTID == curSubjectID.ToString() && i.GRADEID == curGradeID.ToString());
                //chỉ đưa vào những Question khác ID bên cột phải
                foreach (var singleQuestion in ListOfQuestions)
                {
                    if (CheckIfQuestionExistInAdded(singleQuestion.QUESTIONID))
                    {
                        listBoxQuestions.Items.Add(new { Text = singleQuestion.QUESTIONID, Value = singleQuestion.QUESTIONID });
                    }
                }
                if (listBoxQuestions.SelectedIndex < listBoxQuestions.Items.Count - 1)
                    listBoxQuestions.SelectedIndex += 1;
            }
        }

        private void listBoxQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            //khi user chọn 1 câu hỏi bên cây bên trái...
            buttonAddQuestions.Enabled = true;
            curQuestionID_NotAdd = "";
            richTextBoxQuestionContent.Clear();
            if (listBoxQuestions.SelectedItem != null)
            {
                curQuestionID_NotAdd = (listBoxQuestions.SelectedItem as dynamic).Value;
            }
            else
            {
                return;
            }
            using (var db = new QLDTDataContext())
            {
                var temp = db.QUESTIONs.Where(i => i.QUESTIONID == curQuestionID_NotAdd.ToString()).FirstOrDefault();
                string Content = temp.CONTENTOFQUESTION.ToString();
                string A = temp.A.ToString();
                string B = temp.B.ToString();
                string C = temp.C.ToString();
                string D = temp.D.ToString();
                string E = temp.E.ToString();
                string F = temp.F.ToString();
                string correct = temp.CORRECTANSWER.ToString();
                string hint = temp.HINT.ToString();
                if (hint == "")
                {
                    hint = "không có gợi ý!";
                }
                string difficult = temp.DIFFICULT.ToString();
                string IsPro = "Không";
                if (int.Parse(temp.ISPRO.ToString()) == 1)
                {
                    IsPro = "Có";
                }
                richTextBoxQuestionContent.Text =
                    "Mã số câu hỏi :" + temp.QUESTIONID.ToString() + "\n"
                    + "Nội dung: " + Content + "\n" + "A: " + A + "\n" + "B: " + B + "\n"
                    + "C: " + C + "\n" + "D: " + D + "\n" + "E: " + E + "\n" + "F: " + F + "\n"
                    + "Đáp án đúng: " + correct + "\n"
                    + "Gợi ý: " + hint + "\n"
                    + "Độ khó: " + difficult + "\n"
                    + "Chuyên hay không: " + IsPro;
            }
        }

        private void listBoxAddedQuestions_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRemoveQuestions.Enabled = true;
            curQuestionID_Added = "";
            //khi user chọn 1 câu hỏi bên cây bên phải...
            richTextBoxAddedQuestionContent.Clear();
            if (listBoxAddedQuestions.SelectedItem != null)
            {
                curQuestionID_Added = (listBoxAddedQuestions.SelectedItem as dynamic).Value;
            }
            else
            {
                return;
            }
            using (var db = new QLDTDataContext())
            {
                var temp = db.QUESTIONs.Where(i => i.QUESTIONID == curQuestionID_Added.ToString()).FirstOrDefault();
                string Content = temp.CONTENTOFQUESTION.ToString();
                string A = temp.A.ToString();
                string B = temp.B.ToString();
                string C = temp.C.ToString();
                string D = temp.D.ToString();
                string E = temp.E.ToString();
                string F = temp.F.ToString();
                string correct = temp.CORRECTANSWER.ToString();
                string hint = temp.HINT.ToString();
                if (hint == "")
                {
                    hint = "không có gợi ý";
                }
                string difficult = temp.DIFFICULT.ToString();
                string IsPro = "Không";
                if (int.Parse(temp.ISPRO.ToString()) == 1)
                {
                    IsPro = "Có";
                }

                richTextBoxAddedQuestionContent.Text =
                    "Mã số câu hỏi :" + temp.QUESTIONID.ToString() + "\n"
                    + "Nội dung: " + Content + "\n" + "A: " + A + "\n" + "B: " + B + "\n"
                    + "C: " + C + "\n" + "D: " + D + "\n" + "E: " + E + "\n" + "F: " + F + "\n"
                    + "Đáp án đúng: " + correct + "\n"
                    + "Gợi ý: " + hint + "\n"
                    + "Độ khó: " + difficult + "\n"
                    + "Chuyên hay không: " + IsPro;
            }
        }

        private void buttonAddQuestions_Click(object sender, EventArgs e)
        {
            TopicEvent_SendToAdded?.Invoke(this, null);
        }

        private void buttonRemoveQuestions_Click(object sender, EventArgs e)
        {
            TopicEvent_RemoveFromAdded?.Invoke(this, null);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            TopicEvent_Update_Topic?.Invoke(this, null);
            LoadQuestionsAdded();
            this.HamLoad();
        }
    }
}
