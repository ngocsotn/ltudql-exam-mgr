using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Models;
using UI.Presenters;
using UI.Views;

//// chạy hàm gửi cho sever biết rằng user hết giờ và tự disable các nút trả lời
//Thread TimeIsOver = new Thread(TimesUpReport);
//TimeIsOver.IsBackground = true;
//                    TimeIsOver.Start();
namespace UI.Views
{
    public partial class UserControlExamProgress : UserControl
    {
        //Ví dụ===================================================================
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        
        List<string> answertemplate;
        int TotalTimeLeft = 1; //thời gian này là giây

        string CurrentTestID = "";
        //Dành cho train
        bool isTrain = false;
        string CurSelectTrainID = "";
        string CurSelectPersonalID = "";
        string CurSelectTopicID = "";
        int QuestionIndex = 0;
        bool submit = false;
        int totalAnswerd = 0;
        int questionTotal = 9;
        UI.FormMain.SetOnAGain Ham;
        UI.Presenters.MainPresenter.LoadAll HamABC = null;
        //Chứa danh sách câu hỏi
        public static List<QuestionInfo> listQuestions = new List<QuestionInfo>() { };

        //Chứa các câu trả lời
        List<Answers> listAnswers = new List<Answers>() { };

        Thread _threadHelloworld = null;

        //========================================================================
        public UserControlExamProgress()
        {
            InitializeComponent();
        }
        
        //dành cho thi
        public UserControlExamProgress(string PersonalID, string TopicID, UI.FormMain.SetOnAGain _haminput, UI.Presenters.MainPresenter.LoadAll x)
        {
            HamABC = x;
            Ham = _haminput;
            InitializeComponent();
            CurSelectPersonalID = PersonalID;
            CurSelectTopicID = TopicID;
            Initializer();
            if(CheckDaThiChua() == true)
            {
                MessageBox.Show("bạn đã hoàn thành bài thi này");
                return;
            }
            LoadFormProcess();
            Load += UserControlExamProgress_Test_Load;
            
        }


        //dành cho ôn luyện
        public UserControlExamProgress(bool isTrain, string TrainID, string PersonalID, string TopicID, UI.FormMain.SetOnAGain _haminput, UI.Presenters.MainPresenter.LoadAll x)
        {
            HamABC = x;
            Ham = _haminput;
            InitializeComponent();
            //Từ đây trở xuống dành cho luyện thi
            this.isTrain = isTrain;

            CurSelectTrainID = TrainID;
            CurSelectPersonalID = PersonalID;
            CurSelectTopicID = TopicID;
            Initializer();
            Load += UserControlExamProgress_Train_Load;
        }
        private void Initializer()
        {
            //Load câu hỏi
            using (var db = new QLDTDataContext())
            {
                //lấy time của đề thi
                var time = db.TOPICs.Where(t => t.TOPICID == CurSelectTopicID).Select(t => t.TOTALTIME).SingleOrDefault();

                if(time != null && time >0)
                {
                    TotalTimeLeft = time;
                }
                //Lấy các câu hỏi trong đề thi
                var questions = from dt in db.TOPIC_DETAILs
                                join q in db.QUESTIONs on dt.QUESTIONID equals q.QUESTIONID
                                where dt.TOPICID == CurSelectTopicID
                                select q;
                //lưu lại đề thi: lưu các câu hỏi vào danh sách
                foreach (var item in questions)
                {
                    QuestionInfo q = new QuestionInfo();
                    q.QuestionID = item.QUESTIONID.ToString();
                    q.QuestionContent = item.CONTENTOFQUESTION.ToString();
                    q.A = item.A;
                    q.B = item.B;
                    q.C = item.C;
                    q.D = item.D;
                    q.E = item.E;
                    q.F = item.F;
                    q.Answer = item.CORRECTANSWER;
                    q.Hint = item.HINT;

                    listQuestions.Add(q);
                }
            }

            //load một số thông tin ở trên form
            textBoxQuestionKit.Text = CurSelectTopicID; //mã đề
            textBoxQuestionTotal.Text = listQuestions.Count().ToString(); //tổng câu hỏi

            textBoxQuestionAnswered.Text = totalAnswerd.ToString(); // số câu đã trả lời
        }

        private void UserControlExamProgress_Test_Load(object sender, EventArgs e)
        {         
            textBoxQuestionResult.Visible = false;
            labelQuestionResult.Visible = false;

            //Progress bar
            if (TotalTimeLeft >= 0)
            {
                progressBarExam.Minimum = 0;
                progressBarExam.Maximum = TotalTimeLeft;
                progressBarExam.Value = TotalTimeLeft;
            }

            //textBoxTimeLeft
            TimeSpan time = TimeSpan.FromSeconds(progressBarExam.Value);
            textBoxTimeLeft.Text = time.ToString(@"mm\:ss");

            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Start();
            timer.Tick += Timer_Tick;

            //Cần phải nộp bài trước khi ngừng thi
            buttonExamEnd.Enabled = false;

            //Remove old buttons
            groupBoxQuestionPicker.Controls.Clear();
            questionTotal = listQuestions.Count(); //Giả sử có 67 câu hỏi
            int maxQuestionPerRow = 9;
            int y = 20;
            int index = 1;
            while (index < questionTotal)
            {
                int x = 5;
                for (int j = 0; j < maxQuestionPerRow; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(38, 38);
                    btn.Location = new Point(x, y);
                    btn.Name = string.Format("ButtonQuestion{0}", index);
                    btn.Text = index.ToString();
                    btn.BackColor = Color.White;
                    btn.Click += new EventHandler(this.buttonIcon_Click);
                    groupBoxQuestionPicker.Controls.Add(btn);
                    x += 38;
                    index++;
                    if (index > questionTotal)
                        break;
                }
                y += 38;
            }
            ChangeColor_Current_Button_ByButtonName("ButtonQuestion1");
            // Load câu hỏi lên form
            LoadAnswer(QuestionIndex);

            //chạy thread
            _threadHelloworld = new Thread(HelloWorld);
            _threadHelloworld.IsBackground = true;
            _threadHelloworld.Start();
        }

        private void SetTrangThaiThi(int TrangThai)
        {
            if (TrangThai < 0 || TrangThai > 1)
            {
                return;
            }
            using (var db = new QLDTDataContext())
            {
                var _test = db.TESTs.Where(a => a.TESTID == CurrentTestID && a.PERSONALID == CurSelectPersonalID).FirstOrDefault();
                _test.COMPLETESTATUS = TrangThai;
                db.SubmitChanges();
            }
        }

        private void HelloWorld()
        {
            while (TotalTimeLeft > 0 )
            {             
                if (TotalTimeLeft % 5 == 0)
                {
                    Submit_Test_For_Thread();
                    Thread.Sleep(900);
                }
                if(TotalTimeLeft < 2)
                {
                    Submit_Test_For_Thread();
                    SetTrangThaiThi(1);
                    return;
                }
            }
        }
        private void UserControlExamProgress_Train_Load(object sender, EventArgs e)
        {
            //Ví dụ======================================================
            //Progress bar
            if (TotalTimeLeft >= 0)
            {
                progressBarExam.Minimum = 0;
                progressBarExam.Maximum = TotalTimeLeft;
                progressBarExam.Value = TotalTimeLeft;
            }
            //textBoxTimeLeft
            TimeSpan time = TimeSpan.FromSeconds(progressBarExam.Value);
            textBoxTimeLeft.Text = time.ToString(@"mm\:ss");

            timer.Enabled = true;
            timer.Interval = 1000;
            timer.Start();
            timer.Tick += Timer_Tick;

            //Cần phải nộp bài trước khi ngừng thi
            buttonExamEnd.Enabled = false;

            //Remove old buttons
            groupBoxQuestionPicker.Controls.Clear();
            questionTotal = listQuestions.Count(); //Giả sử có 67 câu hỏi
            int maxQuestionPerRow = 9;
            int y = 20;
            int index = 1;
            while (index < questionTotal)
            {
                int x = 5;
                for (int j = 0; j < maxQuestionPerRow; j++)
                {
                    Button btn = new Button();
                    btn.Size = new Size(38, 38);
                    btn.Location = new Point(x, y);
                    btn.Name = string.Format("ButtonQuestion{0}", index);
                    btn.Text = index.ToString();
                    btn.BackColor = Color.White;
                    btn.Click += new EventHandler(this.buttonIcon_Click);
                    groupBoxQuestionPicker.Controls.Add(btn);
                    x += 38;
                    index++;
                    if (index > questionTotal)
                        break;
                }
                y += 38;
            }
            ChangeColor_Current_Button_ByButtonName("ButtonQuestion1");
            // Load câu hỏi lên form
            LoadAnswer(QuestionIndex);

        }
        private void LoadAnswer(int qIndex)
        {

            int ay = groupBoxQuestionDisplay.Location.Y + 50; //Vị trí hoàn hảo
            int ax = 12;//Vị trí hoàn hảo

            //Remove current CheckBox
            for (int i = 0; i < groupBoxQuestionDisplay.Controls.Count;)
            {
                if (groupBoxQuestionDisplay.Controls[i] is CheckBox && groupBoxQuestionDisplay.Controls[i].Name.StartsWith("checkboxAnswer"))
                {
                    groupBoxQuestionDisplay.Controls.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }


            answertemplate = new List<string>()
            {
                listQuestions[qIndex].A,
                listQuestions[qIndex].B,
                listQuestions[qIndex].C,
                listQuestions[qIndex].D,
                listQuestions[qIndex].E!=""?listQuestions[qIndex].E:null,
               listQuestions[qIndex].F!=""?listQuestions[qIndex].F:null
            };
            richTextBoxQuestionContent.Text = listQuestions[qIndex].QuestionContent;

            //Answer
            int answerTotal = 0;

            foreach (var item in answertemplate)
            {
                if(item !=null)
                {
                    answerTotal++;
                }
            }

            int awidth = groupBoxQuestionDisplay.Width + 25; //Chiều dài hoàn hảo
            int aheight = 42; //Chiều cao hoàn hảo
            int aindex = 0;


            List<int> MapChecked = new List<int>() { };


            for (int i = 0; i < listAnswers.Count(); i++)
            {
                if (listAnswers[i].QuestionIndex == qIndex)
                {
                    string[] Checked = listAnswers[i].Answer.Split(',');

                    foreach (var item in Checked)
                    {
                        if (item == "A")
                        {
                            MapChecked.Add(0);
                        }
                        if (item == "B")
                        {
                            MapChecked.Add(1);
                        }
                        if (item == "C")
                        {
                            MapChecked.Add(2);
                        }
                        if (item == "D")
                        {
                            MapChecked.Add(3);
                        }
                        if (item == "E")
                        {
                            MapChecked.Add(4);
                        }
                        if (item == "F")
                        {
                            MapChecked.Add(5);
                        }
                    }

                    break;
                }
            }

            while (aindex < answerTotal)
            {
                CheckBox cb = new CheckBox();
                cb.AutoSize = false;
                cb.CheckAlign = ContentAlignment.TopLeft;
                cb.TextAlign = ContentAlignment.TopLeft;
                cb.Size = new Size(awidth, aheight);
                cb.Location = new Point(ax, ay);
                cb.Name = string.Format("checkboxAnswer{0}", aindex);
                cb.Text = answertemplate[aindex];
                cb.Click += Cb_Click;

                if (MapChecked.Contains(aindex))
                {
                    cb.Checked = true;
                }

                groupBoxQuestionDisplay.Controls.Add(cb);
                aindex++;
                ay += 42;
            }

            if (submit && isTrain)
            {
                textBoxQuestionResult.Text = listQuestions[QuestionIndex].Answer;
            }
        }

        int CheckCorrect()
        {
            int NumberOfCorrect = 0;
            for (int i = 0; i < listQuestions.Count(); i++)
            {
                for (int j = 0; j < listAnswers.Count(); j++)
                {
                    if (listAnswers[j].QuestionIndex == i)
                    {
                        if (listQuestions[i].Answer == listAnswers[j].Answer)
                        {
                            NumberOfCorrect++;
                        }
                    }
                }
            }
            return NumberOfCorrect;
        }

        private void Cb_Click(object sender, EventArgs e)
        {
            //Lấy câu trả lời của học sinh
            List<string> Answered = new List<string>();
            Answered = checkedAnswerList();
            string Key = "";

            foreach (string answer in Answered)
            {
                Key += answer + ",";
            }
            if(Key.Count() > 1)
            {
                Key = Key.Remove(Key.Count() - 1);
            }

          

            //Chứa câu trả lời của học sinh
            Answers studentCheck = new Answers() { };
            studentCheck.QuestionIndex = QuestionIndex;
            studentCheck.Answer = Key;

            bool check = false;

            if (listAnswers != null)
            {
                for (int i = 0; i < listAnswers.Count(); i++)
                {
                    if (listAnswers[i].QuestionIndex == QuestionIndex)
                    {
                        listAnswers[i].Answer = Key;
                        check = true;
                        break;
                    }
                }

                if (check == false)
                {
                    listAnswers.Add(studentCheck);
                }
            }
            else
            {
                listAnswers.Add(studentCheck);
            }

            totalAnswerd = 0;
            foreach (var item in listAnswers)
            {
                if(item.Answer !="")
                {
                    totalAnswerd++;
                }
            }
            textBoxQuestionAnswered.Text = totalAnswerd.ToString();
        }

        //Tuỳ chỉnh định dạng cho phù hợp, đây chỉ là ví dụ
        //Một ví dụ return các câu trả lời đã check dạng List
        private List<string> checkedAnswerList()
        {
            List<string> answered = new List<string>();
            foreach (Control cb in groupBoxQuestionDisplay.Controls)
            {
                if (cb is CheckBox && cb.Name.StartsWith("checkboxAnswer"))
                {
                    CheckBox cbx = cb as CheckBox;
                    if (cbx.Checked)
                    {
                        string key = cb.Name.Substring(cb.Name.Length - 1);
                        answered.Add(key == "0" ? "A" : (key == "1" ? "B" : (key == "2" ? "C" : (key == "3" ? "D" : (key == "4" ? "E" : (key == "5" ? "F" : ""))))));
                    }
                }
            }
            return answered;
        }

        //Ví dụ==========================================================
        private void Timer_Tick(object sender, EventArgs e)
        {
            if (progressBarExam.Value > 0)
            {
                progressBarExam.Value--;
                TimeSpan time = TimeSpan.FromSeconds(progressBarExam.Value);
                TotalTimeLeft = progressBarExam.Value;
                textBoxTimeLeft.Text = time.ToString(@"mm\:ss");
            }
            else
            {
                //Nộp bài
                buttonSubmit.Enabled = false;
                buttonExamEnd.Enabled = true;
                timer.Stop();
                Submit_the_test();
            }
        }
        private void ChangeColor_Current_Button_ByButtonName(string buttonName)
        {
            foreach (Control i in groupBoxQuestionPicker.Controls)
            {
                if(i is Button && i.Name == buttonName)
                {
                    i.BackColor = Color.LightBlue;
                }
                if (i is Button && i.Name != buttonName)
                {
                    i.BackColor = Color.White;
                }
            }
        }

        private void buttonIcon_Click(object sender, EventArgs e)
        {
            //Change question
            var button = sender as Button;
            QuestionIndex = int.Parse(button.Text) - 1;
            LoadAnswer(QuestionIndex);
            //đổi màu nút đang dc chọn
            ChangeColor_Current_Button_ByButtonName(button.Name);
        }
        
        //mỗi 5-10s chạy hàm này, cập nhật Process và ResultOfTest
        private void Submit_Test_For_Thread()
        {
            using (var db = new QLDTDataContext())
            {
                //process
                for (int i = 0; i < listQuestions.Count(); i++)
                {
                    if (i < listAnswers.Count())
                    {
                        //MessageBox.Show(listQuestions[i].QuestionID+"="+ listAnswers[i].Answer);
                        //update process
                        var process_temp = db.PROCESSes.Where(a => a.TESTID == CurrentTestID && a.QUESTIONID == listQuestions[i].QuestionID).FirstOrDefault();
                        process_temp.CHOICE = listAnswers[i].Answer;
                        db.SubmitChanges();
                    }
                }
                //Result of Test
                var Result_temp = db.RESULTOFTESTs.Where(a => a.TESTID == CurrentTestID).FirstOrDefault();
                int SoCauDung = CheckCorrect();
                double Diem = ((SoCauDung * 1.0) / (listQuestions.Count() * 1.0))*10;
                Result_temp.TOTALCORRECT = SoCauDung;
                Result_temp.TOTALINCORRECT = listQuestions.Count() - SoCauDung;
                Result_temp.SCORE = Diem;
                Result_temp.PASSSTATUS = "rớt";
                if (Diem>=5.0)
                {
                    Result_temp.PASSSTATUS = "đậu";
                }
                db.SubmitChanges();

                //cập nhật thgian còn lại
                var Test_Temp = db.TESTs.Where(a => a.TESTID == CurrentTestID).FirstOrDefault();
                if (TotalTimeLeft >= 0)
                {
                    Test_Temp.TIMELEFT = TotalTimeLeft;
                    db.SubmitChanges();
                }
            }
        }

        private void Submit_the_test()
        {
            submit = true;
            //Nộp bài thi
            buttonExamEnd.Enabled = true;
            buttonSubmit.Enabled = false;
            groupBoxQuestionDisplay.Enabled = false;
            groupBoxQuestionPicker.Enabled = false;
            progressBarExam.Value = 0;

            //dành cho luyện
            if (isTrain && submit)
            {
                groupBoxQuestionPicker.Enabled = true; //để bấm xem đáp án(chỉ luyện thi)

                //Nộp bài luyện thi
                using (var db = new QLDTDataContext())
                {
                    var trHistory = db.TRAININGHISTORies.Where(t => t.TRAININGID == CurSelectTrainID && t.TOPICID == CurSelectTopicID && t.PERSONALID == CurSelectPersonalID).SingleOrDefault();

                    trHistory.TOTALCORRECT = CheckCorrect();
                    trHistory.TOTALINCORRECT = listQuestions.Count - CheckCorrect();
                    trHistory.OVERALLPROPERBILITY = (1.0 * trHistory.TOTALCORRECT / ((trHistory.TOTALINCORRECT + trHistory.TOTALCORRECT)) *1.0);
                    trHistory.RESULT = "Rớt";
                    if (trHistory.OVERALLPROPERBILITY > 0.5)
                    {
                        trHistory.RESULT = "Đậu";
                    }

                    db.SubmitChanges();

                }
            }
            else //thi
            {
                submit = true;
                timer.Stop();
                TotalTimeLeft = 0; //set = 0 thì thread sẽ lo, khỏi cần làm gì
                
                //set trong Test là thi rồi...
            }
        }

        //hàm để load để thi tiếp khi mất điện
        private void LoadFormProcess()
        {
            listAnswers.Clear();
            using (var db = new QLDTDataContext())
            {
                var _proccessList = db.PROCESSes.Where(a => a.TESTID == CurrentTestID).ToList();
                for(int i = 0; i < _proccessList.Count();i++)
                {
                    Answers studentCheck = new Answers() { };
                    studentCheck.QuestionIndex = i;
                    studentCheck.Answer = _proccessList[i].CHOICE;
                    listAnswers.Add(studentCheck);
                }

                var _test = db.TESTs.Where(a => a.TESTID == CurrentTestID && a.PERSONALID == CurSelectPersonalID).FirstOrDefault();
                if (_test.TIMELEFT > 0)
                {
                    TotalTimeLeft = _test.TIMELEFT;
                }
            }

            totalAnswerd = 0;
            foreach (var item in listAnswers)
            {
                if (item.Answer != "")
                {
                    totalAnswerd++;
                }
            }
            textBoxQuestionAnswered.Text = totalAnswerd.ToString();
        }

        //hàm check xem TEST này thi chưa, thi rồi thì ko cho làm gì
        private bool CheckDaThiChua()
        {
            using (var db = new QLDTDataContext())
            {
                var temp = db.TESTs.Where(a => a.PERSONALID == CurSelectPersonalID && a.TOPICID == CurSelectTopicID).FirstOrDefault();
                CurrentTestID = temp.TESTID;
                var _test = db.TESTs.Where(a => a.TESTID == CurrentTestID && a.PERSONALID == CurSelectPersonalID).FirstOrDefault();
                if(_test.COMPLETESTATUS == 1)
                {
                    buttonExamEnd.Enabled = true;
                    buttonSubmit.Visible = false;
                    groupBoxQuestionDisplay.Visible = false;
                    groupBoxQuestionPicker.Visible = false;
                    return true;
                }
            }
            return false;
        }

        //hàm dùng để xóa control này
        private void CloseThisControl()
        {
            submit = true;
            buttonExamEnd.Enabled = true;
            buttonSubmit.Enabled = false;
            groupBoxQuestionDisplay.Enabled = false;
            groupBoxQuestionPicker.Enabled = false;
            listQuestions.Clear();
            listAnswers.Clear();
            //xóa control nằm đè này ra khỏi form main
            this.Parent.Controls.Remove(this);
        }

        private void buttonExamEnd_Click(object sender, EventArgs e)
        {
            groupBoxQuestionDisplay.Enabled = false;
            groupBoxQuestionPicker.Enabled = false;
            progressBarExam.Value = 0;
            timer.Stop();
            //Submit_the_test();
            this.HamABC();
            this.Ham();
            CloseThisControl();       
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn sẽ không thể làm tiếp", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                Submit_the_test();
            }
        }

        private void buttonQuestionNext_Click(object sender, EventArgs e)
        {
            if (QuestionIndex + 1 < questionTotal)
            {
                QuestionIndex++;
                LoadAnswer(QuestionIndex);
                int numOfCurrentButtonOnView = QuestionIndex + 1;
                ChangeColor_Current_Button_ByButtonName("ButtonQuestion" + numOfCurrentButtonOnView.ToString());
            }
        }

        private void buttonShowHint_Click(object sender, EventArgs e)
        {
            MessageBox.Show(listQuestions[QuestionIndex].Hint);
        }
        //===============================================================
    }
}