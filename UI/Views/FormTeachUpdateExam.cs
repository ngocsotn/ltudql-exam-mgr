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
    public partial class FormTeachUpdateExam : Form, IExamView
    {
        ExamPresenter examPresenter;
        string curExamID;

        public FormTeachUpdateExam()
        {
            InitializeComponent();
        }
        UI.Presenters.MainPresenter.LoadAll HamABC = null;
        public FormTeachUpdateExam(string curSelect, UI.Presenters.MainPresenter.LoadAll x)
        {
            InitializeComponent();
            HamABC = x;
            curExamID = curSelect;
            Load += FormTeachUpdateExam_Load;
        }

        private void FormTeachUpdateExam_Load(object sender, EventArgs e)
        {
            LoadTopic();
            LoadType();
            LoadStatus();
            examPresenter = new ExamPresenter(this, curExamID);
        }
        private void LoadType()
        {
            comboBoxExamType.DisplayMember = "Text";
            comboBoxExamType.ValueMember = "Value";


            comboBoxExamType.Items.Add(new { Text = "Thi thử", Value = 0 });
            comboBoxExamType.Items.Add(new { Text = "Thi thật", Value = 1 });
            comboBoxExamType.SelectedIndex = 0;
        }

        private void LoadTopic()
        {
            using (var db = new QLDTDataContext())
            {
                var Topics = db.TOPICs;

                listBoxQuestionKits.DisplayMember = "Text";
                listBoxQuestionKits.ValueMember = "Value";
                foreach (var item in Topics)
                {
                    listBoxQuestionKits.Items.Add(new { Text = item.SUBJECTID, Value = item.TOPICID });

                }
            }
        }

        private void LoadStatus()
        {
            comboBoxStatus.DisplayMember = "Text";
            comboBoxStatus.ValueMember = "Value";


            comboBoxStatus.Items.Add(new { Text = "Chưa Thi", Value = 0 });
            comboBoxStatus.Items.Add(new { Text = "Đã Thi", Value = 1 });
            comboBoxStatus.SelectedIndex = 0;
        }
        public string Semester { get => textBoxSemester.Text; set => textBoxSemester.Text = value; }
        public int Year { get => int.Parse(textBoxYear.Text); set => textBoxYear.Text = value.ToString(); }
        public int TypeOfExam { get => (comboBoxExamType.SelectedItem as dynamic).Value; set => comboBoxExamType.SelectedIndex = value; }
        public int StatusOfExam { get => (comboBoxStatus.SelectedItem as dynamic).Value; set => comboBoxStatus.SelectedIndex = value; }
        public ListBox lbStudent { get => listBoxStudents; set => listBoxStudents.DataSource = value; }
        public ListBox lbTopic { get => listBoxQuestionKits; set => listBoxQuestionKits.DataSource = value; }
        public ListBox lbStudentAdded { get => listBoxAddedStudents; set => listBoxAddedStudents.DataSource = value; }
        public string Topic { get => textBox1.Text; set => textBox1.Text = value; }
        public DateTime DateOfExam { get => DateTime.Parse(maskedTextBoxExamDate.Text); set => maskedTextBoxExamDate.Text = value.ToString(); }

        public event EventHandler Add_Exam;
        public event EventHandler SendToAdded;
        public event EventHandler RemoveFromAdded;
        public event EventHandler Update_Exam;

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAddQuestions_Click(object sender, EventArgs e)
        {
            SendToAdded?.Invoke(this, null);
        }

        private void buttonRemoveQuestions_Click(object sender, EventArgs e)
        {
            RemoveFromAdded?.Invoke(this, null);
        }

        private void listBoxStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonAddQuestions.Enabled = true;
            buttonRemoveQuestions.Enabled = false;
        }

        private void listBoxQuestionKits_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonAddQuestions.Enabled = true;
            buttonRemoveQuestions.Enabled = false;
        }

        private void listBoxAddedStudents_SelectedIndexChanged(object sender, EventArgs e)
        {
            buttonRemoveQuestions.Enabled = true;
            buttonAddQuestions.Enabled = false;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Update_Exam?.Invoke(this, null);
            this.HamABC();
        }
    }
}
