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
    public partial class FormUserLogin : Form, ILoginView
    {
        LoginPresenter loginPresenter;
        public FormUserLogin()
        {
            InitializeComponent();
            Load += FormUserLogin_Load;
            KeyDown += FormUserLogin_KeyDown;
        }

        private void FormUserLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonLogin.PerformClick();
            }
        }

        private void FormUserLogin_Load(object sender, EventArgs e)
        {
            loginPresenter = new LoginPresenter(this);
            buttonLogin.Click += ButtonLogin_Click;
        }

        public string UserID { get => textBoxID.Text; set => textBoxID.Text = value; }
        public string Password { get => textBoxPassword.Text; set => textBoxPassword.Text = value; }
        private bool hideForm;
        public bool HideForm
        {
            get { return hideForm; }
            set
            {
                hideForm = value;
                if (hideForm == true)
                    Hide();
                else
                    Show();
            }
        }

        public event EventHandler Login;
        public event EventHandler Register;

        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            Login?.Invoke(this, null);
        }

        private void linkLabelRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Register?.Invoke(this, null);
        }
    }
}
