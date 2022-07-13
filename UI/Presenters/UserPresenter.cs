using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Models;
using UI.Views;

namespace UI.Presenters
{
    class UserPresenter
    {
        IUserView view;
        string curID { get; set; }
        int curLevel { get; set; }


        // INIT
        public UserPresenter(IUserView user) // Add
        {
            view = user;
            Initialize();
        }

        public UserPresenter(IUserView user, string PersonalID, int Level) // Update
        {
            view = user;
            curLevel = Level;
            curID = PersonalID;

            Initialize();

            LoadFormUpdate(curID, curLevel);
        }

        private void Initialize()
        {

            view.Add_User += View_Add;
            view.Update_User += View_Update;
        }


        // Form Load
        private void LoadFormUpdate(string curID, int level)
        {
            if (level == 0)
            {
                LoadAdmin(curID);
            } //Show Admin
            else if (level == 1)
            {
                LoadTeacher(curID);
            } //Show Teacher
            else if (level == 2)
            {

                LoadStudent(curID);
            } // Show Student
            else if (level == 3) // New account
            {
                LoadStudent(curID);
            }
        }



        //EVENT
        private void View_Update(object sender, EventArgs e)
        {

            if (UpdateAccount(curID))
            {
                MessageBox.Show("Cập nhật thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật thất bại");
            }
        }

        private void View_Add(object sender, EventArgs e)
        {
            string ID = GetNextPersonId(view.UserLevel); ;
            if (AddNew(ID))
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Thêm thất bại");
            }

        }


        // DELETE
        bool DeleteAdmin(string ID)
        {
            using (var db = new QLDTDataContext())
            {
                var ad = db.ADMINISTRATORs.Where(a => a.PERSONALID == ID).SingleOrDefault();
                if (ad != null)
                {
                    db.ADMINISTRATORs.DeleteOnSubmit(ad);
                    db.SubmitChanges();
                }
                return true;
            }
            return false;
        }

        bool DeleteTest(string ID)
        {
            using (var db = new QLDTDataContext())
            {
                var st = db.TESTs.Where(t => t.PERSONALID == ID).ToList();
                if (st.Count > 0)
                {
                    db.TESTs.DeleteAllOnSubmit(st);
                    db.SubmitChanges();
                }

                return true;
            }
            return false;
        }

        bool DeleteStudent(string ID)
        {
            using (var db = new QLDTDataContext())
            {
                var st = db.STUDENTs.Where(a => a.PERSONALID == ID).SingleOrDefault();
                if (st != null)
                {
                    db.STUDENTs.DeleteOnSubmit(st);
                    db.SubmitChanges();
                }
                return true;
            }
            return false;
        }

        bool DeleteStatic(string testID)
        {
            using (var db = new QLDTDataContext())
            {
                var st = db.STATISTICs.Where(a => a.TESTID == testID).ToList();
                if (st.Count > 0)
                {
                    db.STATISTICs.DeleteAllOnSubmit(st);
                    db.SubmitChanges();
                }
                return true;
            }
            return false;
        }

        bool DeleteResultOfTest(string TestID)
        {
            using (var db = new QLDTDataContext())
            {
                var st = db.RESULTOFTESTs.Where(a => a.TESTID == TestID).ToList();
                if (st.Count > 0)
                {
                    db.RESULTOFTESTs.DeleteAllOnSubmit(st);
                    db.SubmitChanges();
                }
                return true;
            }
            return false;
        }

        bool DeleteExamDetails(string ID)
        {
            using (var db = new QLDTDataContext())
            {
                var st = db.EXAM_DETAILs.Where(a => a.PERSONALID == ID).ToList();
                if (st.Count > 0)
                {
                    db.EXAM_DETAILs.DeleteAllOnSubmit(st);
                    db.SubmitChanges();
                }
                return true;
            }
            return false;
        }

        bool DeleteSchedule(string ID)
        {
            using (var db = new QLDTDataContext())
            {
                var st = db.SCHEDULEs.Where(a => a.PERSONALID == ID).ToList();
                if (st.Count > 0)
                {
                    db.SCHEDULEs.DeleteAllOnSubmit(st);
                    db.SubmitChanges();
                }
                return true;
            }
            return false;
        }

        bool DeleteTeacher(string ID)
        {
            using (var db = new QLDTDataContext())
            {
                var tc = db.TEACHERs.Where(a => a.PERSONALID == ID).SingleOrDefault();
                if (tc != null)
                {
                    db.TEACHERs.DeleteOnSubmit(tc);
                    db.SubmitChanges();
                }
                return true;
            }
            return false;
        }

        bool DeleteUser(string curID)
        {
            using (var db = new QLDTDataContext())
            {
                var user = db.USERACCOUNTs.Where(u => u.PERSONALID == curID).SingleOrDefault();
                if (user != null)
                {
                    db.USERACCOUNTs.DeleteOnSubmit(user);
                    db.SubmitChanges();
                    return true;
                }
            }
            return false;
        }

        bool DeleteTrainingHistory(string curID)
        {

            using (var db = new QLDTDataContext())
            {
                var HistoryID = db.TRAININGHISTORies.Where(t => t.PERSONALID == curID).ToList();

                if (HistoryID.Count > 0)
                {
                    db.TRAININGHISTORies.DeleteAllOnSubmit(HistoryID);
                    db.SubmitChanges();
                }
                return true;

            }
            return false;
        }

        bool DeleteTraining(string curID)
        {
            using (var db = new QLDTDataContext())
            {
                var trainID = db.TRAININGs.Where(t => t.PERSONALID == curID).ToList();

                if (trainID.Count > 0)
                {
                    db.TRAININGs.DeleteAllOnSubmit(trainID);
                    db.SubmitChanges();
                }
                return true;

            }
            return false;
        }

        bool DeleteQuestionStorge(string curID)
        {
            using (var db = new QLDTDataContext())
            {
                var st = db.QUESTIONSSTORAGEs.Where(t => t.PERSONALID == curID).ToList();
                if (st.Count > 0)
                {
                    db.QUESTIONSSTORAGEs.DeleteAllOnSubmit(st);
                    db.SubmitChanges();
                }
                return true;
            }
            return false;
        }

        //Kiểm tra trùng lắp
        bool checkReduplicateAdmin()
        {
            var ad = new ADMINISTRATOR();
            ad.FULLNAME = view.FullName.ToString();
            ad.GENDER = view.Gender.ToString();
            ad.DATEOFBIRTH = view.DayOfBirth;
            ad.ADR = view.Address.ToString();

            string email = view.Email.ToString();
            string pass = view.Password.ToString();


            using (var db = new QLDTDataContext())
            {
                var admin = (from a in db.ADMINISTRATORs
                             join us in db.USERACCOUNTs on a.PERSONALID equals us.PERSONALID
                             select new { a, us.EMAIL, us.PASS, us.USERLEVEL }).ToList();
                if (admin.Count > 0)
                {
                    foreach (var id in admin)
                    {
                        if (id.a.FULLNAME == ad.FULLNAME && id.EMAIL == email)
                            return true;
                    }
                }
            }
            return false;
        }
        bool checkReduplicateTeacher()
        {
            var tc = new TEACHER();
            tc.FULLNAME = view.FullName;
            tc.CLASSID = view.IDClass;
            tc.GENDER = view.Gender;
            tc.DATEOFBIRTH = view.DayOfBirth;
            tc.ADR = view.Address;
            tc.SUBJECTID = view.SubjectID;


            string email = view.Email.ToString();
            string pass = view.Password.ToString();

            using (var db = new QLDTDataContext())
            {
                var teacher = (from a in db.TEACHERs
                               join us in db.USERACCOUNTs on a.PERSONALID equals us.PERSONALID
                               select new { a, us.EMAIL, us.PASS, us.USERLEVEL }).ToList();
                if (teacher.Count > 0)
                {
                    foreach (var it in teacher)
                    {
                        if (it.a.FULLNAME == tc.FULLNAME && it.EMAIL == email && it.a.DATEOFBIRTH == tc.DATEOFBIRTH)
                        {
                            return true;
                        }
                    }
                }

            }
            return false;
        }
        bool checkReduplicateStudent()
        {
            var st = new STUDENT();
            st.FULLNAME = view.FullName;
            st.CLASSID = view.IDClass;
            st.GENDER = view.Gender;
            st.DATEOFBIRTH = view.DayOfBirth;
            st.ISPRO = view.isPro;
            st.ADR = view.Address;


            string email = view.Email;
            string pass = view.Password;

            using (var db = new QLDTDataContext())
            {
                var student = (from a in db.STUDENTs
                               join us in db.USERACCOUNTs on a.PERSONALID equals us.PERSONALID
                               select new { a, us.EMAIL, us.PASS, us.USERLEVEL }).ToList();
                if (student.Count > 0)
                {
                    foreach (var ist in student)
                    {
                        if (ist.a.FULLNAME == st.FULLNAME && ist.EMAIL == email && ist.a.DATEOFBIRTH == st.DATEOFBIRTH)
                            return true;
                    }
                }

            }
            return false;
        }

        bool CheckReduplicate(int level)
        {
            if (level == 0 && checkReduplicateAdmin())
                return true;
            if (level == 1 && checkReduplicateTeacher())
                return true;
            if (level == 2 && checkReduplicateStudent())
                return true;
            return false;
        }

        //ADDD
        bool AddNew(string ID)
        {
            DialogResult dialog = MessageBox.Show("Bạn có chắc chắn muốn thêm người dùng mới?", "Add admin", MessageBoxButtons.YesNo);

            if (dialog == DialogResult.Yes)
            {
                //Add to userAccount table
                if (CheckReduplicate(view.UserLevel) && curLevel != 3)
                {
                    MessageBox.Show("Tài khoản đã tồn tại");
                    return false;
                }
                else
                {
                    if (curLevel == 3)
                    {
                        DeleteStudent(curID);
                        DeleteUser(curID);
                        ID = GetNextPersonId(view.UserLevel);
                    }

                    // Add to UserAccount
                    if (view.UserLevel != 3)
                        Add_UserAccount(ID);

                    //Add to admin table
                    if (view.UserLevel == 0)
                    {
                        Add_Admin(ID);
                    }
                    //Add to teacher table
                    else if (view.UserLevel == 1)
                    {
                        Add_Teacher(ID);
                    }
                    //Add to student table
                    else if (view.UserLevel == 2)
                    {
                        Add_Student(ID);
                    }
                    //Add to new account
                    else if (view.UserLevel == 3)
                    {
                        MessageBox.Show("Không thể cập nhật về tài khoản mới");
                        return false;
                    }
                    return true;
                }
            }
            return false;

        }  //Tong quat

        bool Add_UserAccount(string ID)
        {
            using (var db = new QLDTDataContext())
            {
                var user = new USERACCOUNT();

                user.PERSONALID = ID;
                user.EMAIL = view.Email;
                user.PASS = view.Password;
                user.USERLEVEL = view.UserLevel;


                db.USERACCOUNTs.InsertOnSubmit(user);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        void Add_Admin(string ID)
        {
            using (var db = new QLDTDataContext())
            {
                var admin = new ADMINISTRATOR();

                admin.PERSONALID = ID;
                admin.FULLNAME = view.FullName;
                admin.GENDER = view.Gender;
                admin.DATEOFBIRTH = view.DayOfBirth;
                admin.ADMINONLYKEY = "123";
                admin.ADR = view.Address;
                db.ADMINISTRATORs.InsertOnSubmit(admin);
                db.SubmitChanges();
            }

        }

        void Add_Student(string ID)
        {
            using (var db = new QLDTDataContext())
            {
                var student = new STUDENT();

                student.PERSONALID = ID;
                student.FULLNAME = view.FullName;
                student.GENDER = view.Gender;
                student.DATEOFBIRTH = view.DayOfBirth;
                student.CLASSID = view.IDClass;
                student.ISPRO = view.isPro;
                student.ADR = view.Address;
                db.STUDENTs.InsertOnSubmit(student);
                db.SubmitChanges();
            }

        }

        void Add_Teacher(string ID)
        {
            using (var db = new QLDTDataContext())
            {
                var teacher = new TEACHER();

                teacher.PERSONALID = ID;
                teacher.FULLNAME = view.FullName;
                teacher.GENDER = view.Gender;
                teacher.DATEOFBIRTH = view.DayOfBirth;
                teacher.CLASSID = view.IDClass;
                teacher.SUBJECTID = view.SubjectID;
                teacher.ADR = view.Address;
                db.TEACHERs.InsertOnSubmit(teacher);
                db.SubmitChanges();
            }

        }


        //UPDATE
        bool UpdateAccount(string ID)
        {
            using (var db = new QLDTDataContext())
            {
                if (curLevel != view.UserLevel) //Đổi permission
                {
                    string NewID = GetNextPersonId(view.UserLevel);

                    if (AddNew(NewID))
                    {
                        if (curLevel == 0)
                        {
                            DeleteAdmin(ID);
                        }
                        else if (curLevel == 1)
                        {
                            DeleteTeacher(ID);
                        }
                        else if (curLevel == 2)
                        {
                            DeleteStudent(curID);
                            DeleteSchedule(curID);
                            DeleteExamDetails(curID);
                            DeleteQuestionStorge(curID);
                            var TestID = db.TESTs.Where(t => t.PERSONALID == curID).ToList();
                            if (TestID.Count > 0)
                            {
                                MessageBox.Show(TestID.First().PERSONALID.ToString());
                                DeleteResultOfTest(TestID.FirstOrDefault().TESTID);
                                DeleteStatic(TestID.FirstOrDefault().TESTID);
                                DeleteTest(curID);
                                // DeleteTrainingHistory(curID);
                                DeleteTraining(curID);
                            }
                        }
                        if (curLevel != 3)
                            DeleteUser(ID);
                        return true;
                    }
                    return false;
                }
                else
                {
                    Update_UserAccount(ID);
                    if (curLevel == 0)
                    {
                        var admin = db.ADMINISTRATORs.Where(a => a.PERSONALID == ID).SingleOrDefault();

                        if (admin == null)
                        {
                            Add_Admin(ID);
                        }
                        else
                        {
                            Update_Admin(ID);
                        }
                    } // Update Admin
                    else if (curLevel == 1)
                    {
                        var teacher = db.TEACHERs.Where(t => t.PERSONALID == ID);
                        if (teacher == null)
                        {
                            Add_Teacher(ID);
                        }
                        else
                        {
                            Update_Teacher(ID);
                        }
                    } //Update teacher
                    else if (curLevel == 2)
                    {
                        var student = db.STUDENTs.Where(st => st.PERSONALID == ID).SingleOrDefault();
                        if (student == null)
                        {
                            Add_Student(ID);
                        }
                        else
                        {
                            Update_Student(ID);
                        }
                    } //Can't update
                    else if (curLevel == 3)
                    {
                        MessageBox.Show("Vui lòng cấp quyền cho user này. Không thể cập nhật");
                        return false;

                    }
                    return true;
                }
            }
            return false;
        }

        bool Update_UserAccount(string ID)
        {
            using (var db = new QLDTDataContext())
            {
                var user = db.USERACCOUNTs.Where(u => u.PERSONALID == ID).SingleOrDefault();
                user.EMAIL = view.Email;
                user.PASS = view.Password;
                user.USERLEVEL = view.UserLevel;
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        bool Update_Admin(string ID)
        {
            using (var db = new QLDTDataContext())
            {
                var admin = db.ADMINISTRATORs.Where(a => a.PERSONALID == ID).SingleOrDefault();

                admin.FULLNAME = view.FullName;
                admin.GENDER = view.Gender;
                admin.DATEOFBIRTH = view.DayOfBirth;
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        bool Update_Student(string ID)
        {
            using (var db = new QLDTDataContext())
            {
                var st = db.STUDENTs.Where(student => student.PERSONALID == ID).SingleOrDefault();
                st.FULLNAME = view.FullName;
                st.GENDER = view.Gender;
                st.DATEOFBIRTH = view.DayOfBirth;
                st.CLASSID = view.IDClass;
                st.ISPRO = view.isPro;

                db.SubmitChanges();
                return true;
            }
            return false;
        }

        bool Update_Teacher(string ID)
        {
            using (var db = new QLDTDataContext())
            {
                var tc = db.TEACHERs.Where(teacher => teacher.PERSONALID == ID).SingleOrDefault();
                tc.FULLNAME = view.FullName;
                tc.GENDER = view.Gender;
                tc.DATEOFBIRTH = view.DayOfBirth;
                tc.CLASSID = view.IDClass;
                tc.SUBJECTID = view.SubjectID;

                db.SubmitChanges();
                return true;
            }
            return false;
        }



        //Load by ID
        string LoadPassWord(string ID)
        {
            string Pass = "";
            using (var db = new QLDTDataContext())
            {
                var Password = db.USERACCOUNTs.Where(e => e.PERSONALID == ID).Select(e => e.PASS);

                foreach (var item in Password)
                {
                    Pass = item.ToString();
                    break;
                }
            }
            return Pass;
        }

        string LoadEmail(string ID)
        {
            string Mail = "";
            using (var db = new QLDTDataContext())
            {
                var email = db.USERACCOUNTs.Where(e => e.PERSONALID == ID).Select(e => e.EMAIL);

                foreach (var item in email)
                {
                    Mail = item.ToString();
                    break;
                }
            }
            return Mail;
        }

        void LoadAdmin(string ID)
        {
            try
            {
                using (var db = new QLDTDataContext())
                {
                    var admin = db.ADMINISTRATORs.Where(ad => ad.PERSONALID == ID).SingleOrDefault();

                    view.FullName = admin.FULLNAME;
                    view.DayOfBirth = DateTime.Parse(admin.DATEOFBIRTH.ToString());
                    view.Email = LoadEmail(ID);
                    view.Password = LoadPassWord(ID);
                    view.Address = admin.ADR;
                    view.Gender = admin.GENDER;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Vui lòng thêm đầy đủ thông tin");
            }

        }

        void LoadStudent(string Id)
        {
            try
            {
                using (var db = new QLDTDataContext())
                {
                    var st = db.STUDENTs.Where(stu => stu.PERSONALID == Id).SingleOrDefault();

                    view.FullName = st.FULLNAME;
                    view.DayOfBirth = DateTime.Parse(st.DATEOFBIRTH.ToString());
                    view.Address = st.ADR;
                    view.Email = LoadEmail(curID);
                    view.Password = LoadPassWord(curID);
                    view.IDClass = st.CLASSID;
                    view.Gender = st.GENDER;
                    view.isPro = st.ISPRO;
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Vui lòng thêm đầy đủ thông tin");
            }
        }

        void LoadTeacher(string ID)
        {
            try
            {
                using (var db = new QLDTDataContext())
                {
                    var tc = db.TEACHERs.Where(teacher => teacher.PERSONALID == ID).SingleOrDefault();

                    view.FullName = tc.FULLNAME;
                    view.DayOfBirth = tc.DATEOFBIRTH;
                    view.Address = tc.ADR;
                    view.Email = LoadEmail(curID);
                    view.Password = LoadPassWord(curID);
                    view.IDClass = tc.CLASSID;
                    view.Gender = tc.GENDER;
                    view.SubjectID = tc.SUBJECTID;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }

        }



        // GET NEXT USER
        private string GetNextPersonId(int Level)
        {
            if (Level == 3)
            {
                Level = 2;
            }
            string ID = "";
            using (var db = new QLDTDataContext())
            {
                var LastID = db.USERACCOUNTs.Where(us => us.USERLEVEL == Level).Max(u => u.PERSONALID);

                if (Level == 2)
                {
                    LastID = db.USERACCOUNTs.Where(us => us.USERLEVEL == Level || us.USERLEVEL == 3).Max(u => u.PERSONALID);
                }

                if (LastID == null)
                {
                    if (Level == 0)
                        ID = "AD001";
                    else if (Level == 1)
                        ID = "TC001";
                    else if (Level == 2)
                        ID = "ST001";
                }
                else
                {
                    ID = LastID.ToString();

                    string temp = ID.Substring(0, 2); // cat 2 gia tri dau
                    int stt = int.Parse(ID.Substring(2, (ID.Count() - 2))) + 1; // lay cac gia tri con lai + 1;
                    ID = temp + stt.ToString("00#");
                }
            }
            return ID;
        }

    }
}
