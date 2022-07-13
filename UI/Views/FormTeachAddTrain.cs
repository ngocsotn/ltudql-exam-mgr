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
    public partial class FormTeachAddTrain : Form, ITrainView
    {
        TrainPresenter trainPresenter;
        UI.Presenters.MainPresenter.LoadAll HamABC = null;
        public FormTeachAddTrain(UI.Presenters.MainPresenter.LoadAll x)
        {
            HamABC = x;
            InitializeComponent();
            Load += FormTeachAddTrain_Load;
        }

        private void FormTeachAddTrain_Load(object sender, EventArgs e)
        {
            LoadStudent();
            LoadTopic();
            trainPresenter = new TrainPresenter(this);
        }


        //tạo biên transfer giá trị giữa giao diện và presenter 
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
            get => (comboBoxExamType.SelectedItem as dynamic).Value; set
            {
                for (int i = 0; i < comboBoxStatus.Items.Count; i++)
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
  

        // sự kiện ( transfer)
        public event EventHandler Add_Train;
        public event EventHandler Update_Train;



        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Add_Train?.Invoke(this, null);
            this.HamABC();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormTeachAddTrain_Load_1(object sender, EventArgs e)
        {
           
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

                if (comboBoxStatus.Items.Count > 0)
                {
                    comboBoxStatus.SelectedIndex = 1;
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

                if (comboBoxExamType.Items.Count > 0)
                {
                    comboBoxExamType.SelectedIndex = 1;
                }
            }
        }

        private DataTable ConvertToDataTable<TSource>(IEnumerable<TSource> source)
        {
            var props = typeof(TSource).GetProperties();

            var dt_mynewtable = new DataTable();
            dt_mynewtable.Columns.AddRange(
              props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray()
            );

            source.ToList().ForEach(
              i => dt_mynewtable.Rows.Add(props.Select(p => p.GetValue(i, null)).ToArray())
            );

            return dt_mynewtable;
        }
    }
}
