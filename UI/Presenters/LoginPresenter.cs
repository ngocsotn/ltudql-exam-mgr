using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Models;
using UI.Views;

namespace UI.Presenters
{

    public class LoginPresenter
    {
        ILoginView loginView;
        public LoginPresenter(ILoginView view)
        {
            loginView = view;
            Initializer();

        }

        private void Initializer()
        {
            loginView.Login += LoginView_Login;
            loginView.Register += LoginView_Register;
        }

        private void LoginView_Register(object sender, EventArgs e)
        {
            FormUserRegister formUserRegister = new FormUserRegister();
            formUserRegister.Shown += FormUserRegister_Shown;
            formUserRegister.FormClosed += FormUserRegister_FormClosed;
            formUserRegister.ShowDialog();
        }

        private void FormUserRegister_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginView.HideForm = false;
        }

        private void FormUserRegister_Shown(object sender, EventArgs e)
        {
            loginView.HideForm = true;
        }

        private void LoginView_Login(object sender, EventArgs e)
        {
            try
            {
                using (var db = new QLDTDataContext())
                {
                    var FindUser = db.USERACCOUNTs.Where(u => u.PERSONALID == loginView.UserID && u.PASS == loginView.Password).SingleOrDefault();
                    if (FindUser == null)
                    {
                        MessageBox.Show("Thông tin đăng nhập không hợp lệ");
                    }
                    else if (FindUser != null)
                    {
                        FormMain frmMain = new FormMain(loginView.UserID, FindUser.USERLEVEL);
                        frmMain.Shown += FrmMain_Shown;
                        frmMain.FormClosed += FrmMain_FormClosed;
                        frmMain.ShowDialog();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi kết nối");
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            loginView.HideForm = false;
        }

        private void FrmMain_Shown(object sender, EventArgs e)
        {
            loginView.HideForm = true;
        }
    }
}
