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

    public class RegisterPresenter
    {
        IRegisterView registerView;
        public RegisterPresenter(IRegisterView view)
        {
            registerView = view;
            Initializer();
        }

        private void Initializer()
        {
            registerView.Register += RegisterView_Register;
        }
        bool checkDuplication()
        {

            using (var db = new QLDTDataContext())
            {
                var nQuery = db.USERACCOUNTs.Where(u => u.EMAIL == registerView.Email);
                if (nQuery != null)
                    return false;
            }

            return true;
        }
        private void RegisterView_Register(object sender, EventArgs e)
        {
        
            if (!checkDuplication())
            {
                using (var db = new QLDTDataContext())
                {
                    string ID = "";
                    var LastID = db.USERACCOUNTs.Where(us => us.USERLEVEL == 2 || us.USERLEVEL == 3).Max(u => u.PERSONALID);

                    if (LastID == null)
                    {
                        ID = "ST001";
                    }
                    else
                    {
                        ID = LastID.ToString();

                        string temp = ID.Substring(0, 2); // cat 2 gia tri dau
                        int stt = int.Parse(ID.Substring(2, (ID.Count() - 2))) + 1; // lay cac gia tri con lai + 1;
                        ID = temp + stt.ToString("00#");
                    }


                    var user = new USERACCOUNT();
                    user.PERSONALID = ID;
                    user.EMAIL = registerView.Email;
                    user.PASS = registerView.Password;
                    user.USERLEVEL = 3;
                    db.USERACCOUNTs.InsertOnSubmit(user);
                    db.SubmitChanges();


                    var student = new STUDENT();
                    student.PERSONALID = ID;
                    student.FULLNAME = registerView.FullName;
                    student.GENDER = registerView.Gender;
                    student.DATEOFBIRTH = DateTime.Parse(registerView.DOB.ToString());
                    student.CLASSID = null;
                    student.ISPRO = 0;
                    student.ADR = registerView.ADR;
                    db.STUDENTs.InsertOnSubmit(student);
                    db.SubmitChanges();


                    MessageBox.Show(string.Format("Đăng ký thành công, ID đăng nhập của bạn là:{0}\nHãy ghi nhớ thông tin đăng nhập.", ID), "Mẫu kết quả", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    var x = sender as Form;
                    x.Close();
                }
            }
            else
            {
                MessageBox.Show("Tài khoản đã tồn tại");
            }

        }
    }
}
