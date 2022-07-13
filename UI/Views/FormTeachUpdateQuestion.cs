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
    public partial class FormTeachUpdateQuestion : Form, IQuestionView
    {
        string QuestionID = "";
        QuestionPresenter question_presenter;
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
        public int Difficult
        {
            get => (comboBoxDifficultly.SelectedItem as dynamic).Value;
            set
            {
                for (int i = 0; i < comboBoxDifficultly.Items.Count; i++)
                {
                    if ((comboBoxDifficultly.Items[i] as dynamic).Value == value)
                    {
                        comboBoxDifficultly.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        public string Question_Content { get => richTextBoxQuestionContent.Text; set => richTextBoxQuestionContent.Text = value; }
        public string A { get => textBoxAnswerA.Text; set => textBoxAnswerA.Text = value; }
        public string B { get => textBoxAnswerB.Text; set => textBoxAnswerB.Text = value; }
        public string C { get => textBoxAnswerC.Text; set => textBoxAnswerC.Text = value; }
        public string D { get => textBoxAnswerD.Text; set => textBoxAnswerD.Text = value; }
        public string E { get => textBoxAnswerE.Text; set => textBoxAnswerE.Text = value; }
        public string F { get => textBoxAnswerF.Text; set => textBoxAnswerF.Text = value; }
        public string hint { get => textBoxQuestionHint.Text; set => textBoxQuestionHint.Text = value; }
        public bool IsPro { get => checkBoxSpecializedClass.Checked; set => checkBoxSpecializedClass.Checked = value; }
        public bool IsAnswerA { get => checkBoxCorrectAnswerA.Checked; set => checkBoxCorrectAnswerA.Checked = value; }
        public bool IsAnswerB { get => checkBoxCorrectAnswerB.Checked; set => checkBoxCorrectAnswerB.Checked = value; }
        public bool IsAnswerC { get => checkBoxCorrectAnswerC.Checked; set => checkBoxCorrectAnswerC.Checked = value; }
        public bool IsAnswerD { get => checkBoxCorrectAnswerD.Checked; set => checkBoxCorrectAnswerD.Checked = value; }
        public bool IsAnswerE { get => checkBoxCorrectAnswerE.Checked; set => checkBoxCorrectAnswerE.Checked = value; }
        public bool IsAnswerF { get => checkBoxCorrectAnswerF.Checked; set => checkBoxCorrectAnswerF.Checked = value; }

        public event EventHandler QuestionEvent_Add_Question;
        public event EventHandler QuestionEvent_Update_Question;
        public event EventHandler QuestionEvent_Load_Question; //dành cho update
        UI.Presenters.MainPresenter.LoadAll HamLoadAll = null;
        public FormTeachUpdateQuestion()
        {
            InitializeComponent();
        }
        public FormTeachUpdateQuestion(string inputID)
        {
            QuestionID = inputID;
            InitializeComponent();
            Load += FormTeachUpdateQuestion_Load;
        }
        public FormTeachUpdateQuestion(string inputID, UI.Presenters.MainPresenter.LoadAll x )
        {
            QuestionID = inputID;
            InitializeComponent();
            HamLoadAll = x;
            Load += FormTeachUpdateQuestion_Load;
        }

        private void FormTeachUpdateQuestion_Load(object sender, EventArgs e)
        {
            question_presenter = new QuestionPresenter(this, QuestionID);
            LoadGrade();
            LoadSubject();
            LoadDifficult();
            LoadQuestion(); //dành cho update
        }
        private void LoadSubject()
        {
            using (var db = new QLDTDataContext())
            {
                var list_Subject = db.SUBJECTs;


                foreach (var item in list_Subject)
                {

                    comboBoxSubject.Items.Add(new { Text = item.SUBJECTNAME, Value = item.SUBJECTID });
                }

                comboBoxSubject.DisplayMember = "Text";
                comboBoxSubject.ValueMember = "Value";
                comboBoxSubject.SelectedIndex = 0;

            }
        }
        private void LoadGrade()
        {
            using (var db = new QLDTDataContext())
            {
                var list = db.GRADEs;


                foreach (var item in list)
                {

                    comboBoxGrade.Items.Add(new { Text = item.DISPLAYNAME, Value = item.GRADEID });
                }

                comboBoxGrade.DisplayMember = "Text";
                comboBoxGrade.ValueMember = "Value";
                comboBoxGrade.SelectedIndex = 0;
            }
        }
        private void LoadDifficult()
        {
            comboBoxDifficultly.Items.Add(new { Text = "Dễ", Value = 1 });
            comboBoxDifficultly.Items.Add(new { Text = "Trung bình", Value = 2 });
            comboBoxDifficultly.Items.Add(new { Text = "Khó", Value = 3 });
            comboBoxDifficultly.DisplayMember = "Text";
            comboBoxDifficultly.ValueMember = "Value";
            comboBoxDifficultly.SelectedIndex = 0;
        }
        private void LoadQuestion()
        {
            QuestionEvent_Load_Question?.Invoke(this, null);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            QuestionEvent_Update_Question?.Invoke(this, null);
            this.HamLoadAll();
        }
    }
}
