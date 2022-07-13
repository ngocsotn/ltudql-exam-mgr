using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Models;
using UI.Presenters;
using UI.Views;

namespace UI.Views
{
    public partial class FormSystemAddUser : Form, IUserView
    {
        UserPresenter user;
        UI.Presenters.MainPresenter.LoadAll HamABC = null;
        public FormSystemAddUser(UI.Presenters.MainPresenter.LoadAll x)
        {
            HamABC = x;
            InitializeComponent();
            Load += FormSystemAddUser_Load;
        }

        public event EventHandler Add_User;
        public event EventHandler Update_User;
        public event EventHandler Delete_User;


        private void FormSystemAddUser_Load(object sender, EventArgs e)
        {
            user = new UserPresenter(this);
            buttonAdd.Click += ButtonAdd_Click;
            buttonCancel.Click += ButtonCancel_Click;

            LoadComBoBoxPermission();
            LoadComBoxGender();
        }

        //CONVER QUERY TO DATATABLE LINQ
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

        void LoadComBoBoxPermission()
        {
            using (var db = new QLDTDataContext())
            {
                var Query = db.PERMISSIONs;
                comboBoxPermission.DisplayMember = "Text";
                comboBoxPermission.ValueMember = "Value";

                foreach (var item in Query)
                {
                    if (item.PERMISSIONID != 3)
                        comboBoxPermission.Items.Add(new { Text = item.PERMISSIONNAME, Value = item.PERMISSIONID });
                }
                comboBoxPermission.SelectedIndex = 0;
            }
        }
        void LoadComBoxGender()
        {
            comboBoxGender.DisplayMember = "Text";
            comboBoxGender.ValueMember = "Value";
            comboBoxGender.Items.Add(new { Text = "Nữ", Value = 0 });
            comboBoxGender.Items.Add(new { Text = "Nam", Value = 1 });
            comboBoxGender.Items.Add(new { Text = "Khác", Value = 2 });
            comboBoxGender.SelectedIndex = 0;
        }
        void LoadComBoBoxClass()
        {

            using (var db = new QLDTDataContext())
            {
                var ListClass = db.CLASSes;


                foreach (var item in ListClass)
                {

                    comboBoxClass.Items.Add(new { Text = item.CLASSNAME, Value = item.CLASSID });
                }

                comboBoxClass.DisplayMember = "Text";
                comboBoxClass.ValueMember = "Value";
                comboBoxClass.SelectedIndex = 0;
            }
        }
        void LoadComBoBoxSubject()
        {
            using (var db = new QLDTDataContext())
            {
                var ListClass = db.SUBJECTs;


                foreach (var item in ListClass)
                {

                    comboBoxSubject.Items.Add(new { Text = item.SUBJECTNAME, Value = item.SUBJECTID });
                }
                comboBoxSubject.DisplayMember = "Text";
                comboBoxSubject.ValueMember = "Value";
                comboBoxSubject.SelectedIndex = 0;
            }
        }


        // LOAD COMBOBOX FOR FORM ADD
        private void LoadComBoBox(int SelectedChangeID)
        {
            // LOAD ADMIN
            if (SelectedChangeID == 0)
            {
                comboBoxClass.Enabled = false;
                comboBoxSubject.Enabled = false;
                checkBoxSpecializedClass.Enabled = false;
            }
            // LOAD TEACHER
            if (SelectedChangeID == 1)
            {
                comboBoxClass.Items.Clear();
                comboBoxSubject.Items.Clear();

                LoadComBoBoxSubject();
                LoadComBoBoxClass();
                comboBoxClass.Enabled = true;
                comboBoxSubject.Enabled = true;
                checkBoxSpecializedClass.Enabled = false;


            }
            //LOAD STUDENT
            if (SelectedChangeID == 2)
            {
                comboBoxClass.Items.Clear();
                comboBoxSubject.Items.Clear();

                comboBoxClass.Enabled = true;
                comboBoxSubject.Enabled = false;
                checkBoxSpecializedClass.Enabled = true;

                LoadComBoBoxClass();
                comboBoxSubject.DataSource = null;
            }
        }




        // ATR
        public string PersonalID { get; set; }
        public int UserLevel { get => (comboBoxPermission.SelectedItem as dynamic).Value; set => comboBoxPermission.SelectedIndex = value; }
        public string Email { get => textBoxEmail.Text; set { textBoxEmail.Text = value; } }
        public string Password { get => textBoxPassword.Text; set { textBoxPassword.Text = value; } }
        public string IDClass { get => (comboBoxClass.SelectedItem as dynamic).Value; set => int.Parse(value); }
        public string FullName { get => textBoxFullname.Text; set { textBoxFullname.Text = value; } }
        public DateTime DayOfBirth
        {
            get
            {
                DateTime dt = DateTime.Parse(maskedTextBoxDateofBirth.Text);
                return dt;
            }
            set
            {
                maskedTextBoxDateofBirth.Text = value.ToString();
            }
        }
        public string Gender { get => (comboBoxGender.SelectedItem as dynamic).Text; set { comboBoxGender.SelectedIndex = int.Parse(value); } }
        //public string AdminKeyOnly { get => textBoxAdminKeyOnly.Text; set { textBoxAdminKeyOnly.Text = value; } }
        public int isPro
        {
            get
            {
                if (checkBoxSpecializedClass.Checked)
                {
                    return 1;
                }
                else
                {
                    return 0;
                }
            }
            set
            {

            }
        }
        public string SubjectID
        {
            get => (comboBoxSubject.SelectedItem as dynamic).Value;
            set
            {

            }
        }

        public string Address { get => textBoxAddress.Text; set => textBoxAddress.Text = value; }

        // EVENT
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Add_User?.Invoke(this, null);
        }

        private void comboBoxPermission_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Index = (comboBoxPermission.SelectedItem as dynamic).Value;
            LoadComBoBox(Index);


        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            Add_User?.Invoke(this, null);
            this.HamABC();
        }
    }
}
