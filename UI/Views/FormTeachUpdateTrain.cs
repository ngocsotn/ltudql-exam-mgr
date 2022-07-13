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
    public partial class FormTeachUpdateTrain : Form, ITrainView
    {
        string CurPersonID;
        string CurTrainID;
        TrainPresenter trainPresenter;

        public FormTeachUpdateTrain()
        {
            InitializeComponent();
            Load += FormTeachUpdateTrain_Load;
        }

        UI.Presenters.MainPresenter.LoadAll HamABC = null;
        public FormTeachUpdateTrain(string CurID,string PersonID, UI.Presenters.MainPresenter.LoadAll x)
        {

            CurTrainID = CurID;
            CurPersonID = PersonID;
            HamABC = x;


            Load += FormTeachUpdateTrain_Load;
            InitializeComponent();
        }

        private void FormTeachUpdateTrain_Load(object sender, EventArgs e)
        {
            LoadTopic();
            LoadStudent();
            trainPresenter = new TrainPresenter(this,CurTrainID,CurPersonID);
        }

        private void LoadTopic()
        {
            using (var db = new QLDTDataContext())
            {
                var Topics = db.TOPICs;
                comboBoxStatus.DisplayMember = "Text";
                comboBoxStatus.ValueMember = "Value";
                foreach (var item in Topics)
                {
                    comboBoxStatus.Items.Add(new { Text = item.SUBJECTID, Value = item.TOPICID });
                }
            }
        }

        private void LoadStudent()
        {

            using (var db = new QLDTDataContext())
            {
                var students = db.STUDENTs;
                comboBoxExamType.DisplayMember = "Text";
                comboBoxExamType.ValueMember = "Value";
                foreach (var item in students)
                {
                    comboBoxExamType.Items.Add(new { Text = item.FULLNAME, Value = item.PERSONALID });
                }
            }
        }

        public string BoDe
        {
            get => (comboBoxStatus.SelectedItem as dynamic).Value;
            set
            {
                for (int i = 0; i < comboBoxStatus.Items.Count; i++)
                {
                    if ((comboBoxStatus.Items[i] as dynamic).Value == value)
                    {
                        comboBoxStatus.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        public string HocSinhID
        {
            get => (comboBoxExamType.SelectedItem as dynamic).Value;
            set
            {
                for (int i = 0; i < comboBoxExamType.Items.Count; i++)
                {
                    if ((comboBoxExamType.Items[i] as dynamic).Value == value)
                    {
                        comboBoxExamType.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        public DateTime HanChot { get => DateTime.Parse(maskedTextBoxExamDate.Text); set => maskedTextBoxExamDate.Text = value.ToString(); }

        public event EventHandler Add_Train;
        public event EventHandler Update_Train;

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Update_Train?.Invoke(this, null);
            this.HamABC();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
