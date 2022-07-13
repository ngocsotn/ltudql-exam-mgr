using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Text;
using System.Windows.Forms;
using UI.Models;
using UI.Presenters;

namespace UI.Views
{
    public partial class FormSystemUpdateUser : Form, IUserView
    {
        string curID;
        int CurLevel;
        UserPresenter user;


        // DEFAULT INIT
        public FormSystemUpdateUser()
        {
            InitializeComponent();
            Load += FormSystemUpdateUser_Load;
        }

        // INIT WITH PARAMETER FROM UPDATE
        UI.Presenters.MainPresenter.LoadAll HamABC = null;
        public FormSystemUpdateUser(string ID, int Level, UI.Presenters.MainPresenter.LoadAll x)
        {
            HamABC = x;
            curID = ID;
            CurLevel = Level;
            InitializeComponent();
            Load += FormSystemUpdateUser_Load;
        }

        //FORM LOAD
        private void FormSystemUpdateUser_Load(object sender, EventArgs e)
        {
            LoadComBoBoxPermission();
            LoadComBoxGender();

            user = new UserPresenter(this, curID, CurLevel);
        }

        //LOAD PERMISSION
        void LoadComBoBoxPermission()
        {
            using (var db = new QLDTDataContext())
            {
                var Query = db.PERMISSIONs;
                comboBoxPermission.DisplayMember = "Text";
                comboBoxPermission.ValueMember = "Value";

                foreach (var item in Query)
                {
                    comboBoxPermission.Items.Add(new { Text = item.PERMISSIONNAME, Value = item.PERMISSIONID });
                }

                comboBoxPermission.SelectedIndex = CurLevel;

            }
        }

        //LOAD GENDER
        void LoadComBoxGender()
        {
            //comboBoxGender.Items.Clear();
            comboBoxGender.DisplayMember = "Text";
            comboBoxGender.ValueMember = "Value";
            comboBoxGender.Items.Add(new { Text = "Nữ", Value = 0 });
            comboBoxGender.Items.Add(new { Text = "Nam", Value = 1 });
            comboBoxGender.Items.Add(new { Text = "Khác", Value = 2 });
            comboBoxGender.SelectedIndex = 0;
        }

        //LOAD CLASS FOR STUDENT
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

        //LOAD SUBJECT FOR TEACHER
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


        //LOAD COMBOBOX FOR FORM UPDATE
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
            }

            // NEw Account
            if (SelectedChangeID == 3)
            {
                comboBoxClass.Enabled = false;
                comboBoxSubject.Enabled = false;
            }
        }


        //## ATR
        public string FullName { get => textBoxFullName.Text; set => textBoxFullName.Text = value; }
        public string PersonalID { get; set; }
        public int UserLevel { get => comboBoxPermission.SelectedIndex; set => comboBoxPermission.SelectedIndex = value; }
        public string Email { get => textBoxEmail.Text; set { textBoxEmail.Text = value; } }
        public string Password { get => textBoxPassword.Text; set { textBoxPassword.Text = value; } }
        public string IDClass
        {
            get => (comboBoxClass.SelectedItem as dynamic).Value;
            set
            {
                for (int i = 0; i < comboBoxClass.Items.Count; i++)
                {
                    if ((comboBoxClass.Items[i] as dynamic).Value == value)
                    {
                        comboBoxClass.SelectedIndex = i;
                        break;
                    }
                }
            }
        }
        public DateTime DayOfBirth
        {
            get
            {
                DateTime dt = DateTime.Parse(maskedTextBoxDateofBirth.Text);
                return dt;
            }
            set
            {
                maskedTextBoxDateofBirth.Text = value.ToString("MM/dd/yyyy");
            }
        }
        public string Gender
        {
            get => (comboBoxGender.SelectedItem as dynamic).Text.ToString();

            set
            {
                if (value == "Nam")
                {
                    comboBoxGender.SelectedIndex = 1;
                }
                else if (value == "Nữ")
                {
                    comboBoxGender.SelectedIndex = 0;
                }
            }
        }
        public int isPro
        {
            get
            {
                if (checkBoxSpecializedClass.Checked)
                    return 1;
                return 0;
            }
            set
            {
                checkBoxSpecializedClass.Checked = false;
                if (value == 1)
                    checkBoxSpecializedClass.Checked = true;
            }
        }
        public string SubjectID
        {
            get => (comboBoxSubject.SelectedItem as dynamic).Value;
            set
            {
                for (int i = 0; i < comboBoxSubject.Items.Count; i++)
                {
                    if ((comboBoxSubject.Items[i] as dynamic).Value == value)
                    {
                        comboBoxSubject.SelectedIndex = i;
                    }
                }
            }
        }

        public string Address { get => textBoxAddress.Text; set => textBoxAddress.Text = value; }
        public int Permisson { get => (comboBoxPermission.SelectedItem as dynamic).Value; set => comboBoxPermission.SelectedIndex = value; }




        //## EVENT

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Update_User?.Invoke(this, null);
            this.HamABC();
        }

        private void comboBoxPermission_SelectedIndexChanged(object sender, EventArgs e)
        {
            int Index = (comboBoxPermission.SelectedItem as dynamic).Value;
            LoadComBoBox(Index);
        }

        //EVENT
        public event EventHandler Add_User;
        public event EventHandler Update_User;
        public event EventHandler Delete_User;
    }
}

