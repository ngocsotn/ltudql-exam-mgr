using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Presenters;

namespace UI.Views
{
    public partial class FormUserRegister : Form, IRegisterView
    {
        RegisterPresenter registerPresenter;
        public FormUserRegister()
        {
            InitializeComponent();
            Load += FormUserRegister_Load;
            KeyDown += FormUserRegister_KeyDown;
        }

        private void FormUserRegister_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonRegister.PerformClick();
            }
        }

        private void FormUserRegister_Load(object sender, EventArgs e)
        {
            LoadComBoxGender();
            registerPresenter = new RegisterPresenter(this);
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

        public string FullName { get => textBoxFullname.Text; set { } }
        public string Email { get => textBoxEmail.Text; set { } }
        public string Gender { get => (comboBoxGender.SelectedItem as dynamic).Text; set { comboBoxGender.SelectedIndex = int.Parse(value); } }
        public DateTime DOB { get => DateTime.Parse(maskedTextBoxDOB.Text); set { } }
        public string ADR { get => textBoxAddress.Text; set { } }
        public string Password { get => textBoxPassword.Text; set { } }

        public event EventHandler Register;

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            Register?.Invoke(this, null);
        }
    }
}
