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
    public class ExamPresenter
    {
        IExamView examView;
        string curExamID;
        public ExamPresenter(IExamView view)
        {
            examView = view;
            Initializer();
        }
        public ExamPresenter(IExamView view, string ExamID)
        {

            examView = view;
            curExamID = ExamID;
            Update_Initializer();
        }

        private void Update_Initializer()
        {
            LoadExamInfo();
            LoadStudentNotAdd();
            LoadStudentAdded();
            examView.Update_Exam += ExamView_Update_Exam;
            examView.SendToAdded += ExamView_SendToAdded; ;
            examView.RemoveFromAdded += ExamView_RemoveFromAdded;
        }



        private void LoadExamInfo()
        {
            using (var db = new QLDTDataContext())
            {
                var Exam = db.EXAMs.Where(ex => ex.EXAMID == curExamID).SingleOrDefault();
                var TopicID = db.EXAM_DETAILs.Where(tp => tp.EXAMID == curExamID).First();

                if (Exam != null)
                {
                    examView.Semester = Exam.SEMESTER;
                    examView.DateOfExam = DateTime.Parse(Exam.DATEOFEXAM.ToString());
                    examView.TypeOfExam = Exam.TYPEOFEXAM;
                    examView.StatusOfExam = Exam.STATUSOFEXAM;
                    examView.Year = Exam.YEAROFSEMESTER;
                }

                if (TopicID != null)
                {
                    examView.Topic = TopicID.TOPICID;
                }

            }
        }

        private void LoadStudentNotAdd()
        {
            using (var db = new QLDTDataContext())
            {
                var ListStudent = db.STUDENTs.Select(st => new { st.PERSONALID, st.FULLNAME }).ToList();
                var ExamStudent = db.EXAM_DETAILs.Where(ed => ed.EXAMID == curExamID);
                var StudentInfo = from item in db.STUDENTs
                                  join item2 in ExamStudent on item.PERSONALID equals item2.PERSONALID
                                  select new { item.PERSONALID, item.FULLNAME };
                if (ExamStudent.Count() > 0)
                {
                    var StudentNotAdd = ListStudent.Except(StudentInfo);


                    foreach (var item in StudentNotAdd)
                    {
                        examView.lbStudent.DisplayMember = "Text";
                        examView.lbStudent.ValueMember = "Value";

                        examView.lbStudent.Items.Add(new { Text = item.FULLNAME, Value = item.PERSONALID });

                    }
                }
            }
        }

        private void LoadStudentAdded()
        {
            using (var db = new QLDTDataContext())
            {
                var Exam = db.EXAMs.Where(ex => ex.EXAMID == curExamID);
                var ExamStudent = db.EXAM_DETAILs.Where(ed => ed.EXAMID == curExamID);
                if (ExamStudent.Count() > 0)
                {
                    var StudentInfo = from item in db.STUDENTs
                                      join item2 in ExamStudent on item.PERSONALID equals item2.PERSONALID
                                      select new { item.PERSONALID, item.FULLNAME };


                    foreach (var item in StudentInfo)
                    {
                        examView.lbStudentAdded.DisplayMember = "Text";
                        examView.lbStudentAdded.ValueMember = "Value";

                        examView.lbStudentAdded.Items.Add(new { Text = item.FULLNAME, Value = item.PERSONALID });

                    }
                }
            }
        }

        private DataTable ConvertToDataTable<TSource>(IEnumerable<TSource> source)
        {
            var props = typeof(TSource).GetProperties();

            var dt_mynewtable = new DataTable();
            dt_mynewtable.Columns.AddRange(
              props.Select(p => new DataColumn(p.Name, p.PropertyType.Name.Contains("Nullable") ? typeof(string) : p.PropertyType)).ToArray()
            );

            source.ToList().ForEach(
              i => dt_mynewtable.Rows.Add(props.Select(p => p.GetValue(i, null)).ToArray())
            );

            return dt_mynewtable;
        }

        private void ExamView_Update_Exam(object sender, EventArgs e)
        {
            //DELETE EXAM DETAILS 
            if (isExamOK())
            {
                try
                {
                    using (var db = new QLDTDataContext())
                    {
                        //DELETE EXAM DETAILS 
                        var examDT = db.EXAM_DETAILs.Where(ed => ed.EXAMID == curExamID).ToList();
                        if (examDT.Count > 0)
                        {
                            db.EXAM_DETAILs.DeleteAllOnSubmit(examDT);
                            db.SubmitChanges();
                        }
                        //Delete Schedule
                        var examSchedule = db.SCHEDULEs.Where(sch => sch.EXAMID == curExamID).ToList();
                        if (examSchedule.Count > 0)
                        {
                            db.SCHEDULEs.DeleteAllOnSubmit(examSchedule);
                            db.SubmitChanges();
                        }

                        //UPDATE EXAM
                        var curExam = db.EXAMs.Where(ex => ex.EXAMID == curExamID).SingleOrDefault();
                        curExam.SEMESTER = examView.Semester;
                        curExam.YEAROFSEMESTER = examView.Year;
                        curExam.TYPEOFEXAM = examView.TypeOfExam;
                        curExam.STATUSOFEXAM = examView.StatusOfExam;
                        curExam.DATEOFEXAM = examView.DateOfExam;



                        foreach (var item in examView.lbStudentAdded.Items)
                        {
                            //ADD NEW EXAM DETAILS
                            var examDetails = new EXAM_DETAIL();
                            examDetails.EXAMID = curExamID;
                            examDetails.PERSONALID = (item as dynamic).Value;
                            examDetails.TOPICID = examView.Topic;

                            db.EXAM_DETAILs.InsertOnSubmit(examDetails);
                            db.SubmitChanges();


                            // ADD NEW SCHEDULE
                            var schedule = new SCHEDULE();
                            schedule.PERSONALID = (item as dynamic).Value;
                            schedule.EXAMID = curExamID;
                            schedule.DATEOFTEST = examView.DateOfExam;

                            var subjectInfo = (from t in db.TOPICs
                                               join s in db.SUBJECTs on t.SUBJECTID equals s.SUBJECTID
                                               where t.TOPICID == examView.Topic
                                               select new { t.SUBJECTID, s.SUBJECTNAME }).SingleOrDefault();
                            schedule.SUBJECTID = subjectInfo.SUBJECTID;
                            schedule.NAMEOFSUBJECT = subjectInfo.SUBJECTNAME;
                            schedule.PLACE = "Phòng 500 máy tầng thượng khu Quân Sự";

                            db.SCHEDULEs.InsertOnSubmit(schedule);
                            db.SubmitChanges();


                        }



                    }
                    MessageBox.Show(string.Format(string.Format("Cập nhật kì thi: {0} thành công", curExamID)));

                }
                catch (Exception)
                {

                    MessageBox.Show(string.Format(string.Format("Cập nhật kì thi: {0} thất bại", curExamID)));
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin kì thi");
            }
        }

        private void Initializer()
        {

            examView.Add_Exam += ExamView_Add_Exam;
            examView.SendToAdded += ExamView_SendToAdded;
            examView.RemoveFromAdded += ExamView_RemoveFromAdded;

        }

        private void LoadTopic()
        {
            using (var db = new QLDTDataContext())
            {
                var Topics = db.TOPICs;
                examView.lbTopic.DisplayMember = "Text";
                examView.lbTopic.ValueMember = "Value";
                foreach (var item in Topics)
                {
                    examView.lbTopic.Items.Add(new { Text = item.SUBJECTID, Value = item.TOPICID });
                }
            }
        }

        private void LoadStudent()
        {

            using (var db = new QLDTDataContext())
            {
                var students = db.STUDENTs;
                examView.lbStudent.DisplayMember = "Text";
                examView.lbStudent.ValueMember = "Value";
                foreach (var item in students)
                {
                    examView.lbStudent.Items.Add(new { Text = item.FULLNAME, Value = item.PERSONALID });
                }
            }
        }

        private void ExamView_RemoveFromAdded(object sender, EventArgs e)
        {
            examView.lbStudentAdded.DisplayMember = "Text";
            examView.lbStudentAdded.ValueMember = "Value";
            int curIndex = examView.lbStudentAdded.SelectedIndex;


            examView.lbStudent.Items.Add(examView.lbStudentAdded.SelectedItem);
            examView.lbStudentAdded.Items.RemoveAt(examView.lbStudentAdded.SelectedIndex);
        }

        private void ExamView_SendToAdded(object sender, EventArgs e)
        {
            if (examView.lbStudent.SelectedItem != null)
            {
                int curIndex = examView.lbStudent.SelectedIndex;
                examView.lbStudentAdded.DisplayMember = "Text";
                examView.lbStudentAdded.ValueMember = "Value";

                examView.lbStudentAdded.Items.Add(examView.lbStudent.SelectedItem);
                examView.lbStudent.Items.RemoveAt(examView.lbStudent.SelectedIndex);

            }

            if (examView.lbTopic.SelectedItem != null)
            {
                examView.Topic = (examView.lbTopic.SelectedItem as dynamic).Value;
            }

        }

        private void ExamView_Add_Exam(object sender, EventArgs e)
        {
            if (isExamOK())
            {
                try
                {
                    using (var db = new QLDTDataContext())
                    {
                        string ExamID = GetNextExam();
                        var exam = new EXAM();
                        exam.EXAMID = ExamID;
                        exam.SEMESTER = "SE" + int.Parse(examView.Semester).ToString("0#");
                        exam.YEAROFSEMESTER = examView.Year;
                        exam.DATEOFEXAM = examView.DateOfExam;
                        exam.TYPEOFEXAM = examView.TypeOfExam;
                        exam.STATUSOFEXAM = examView.StatusOfExam;

                        db.EXAMs.InsertOnSubmit(exam);
                        db.SubmitChanges();



                        foreach (var item in examView.lbStudentAdded.Items)
                        {
                            var examDetails = new EXAM_DETAIL();
                            examDetails.EXAMID = ExamID;
                            examDetails.PERSONALID = (item as dynamic).Value;
                            examDetails.TOPICID = examView.Topic;

                            db.EXAM_DETAILs.InsertOnSubmit(examDetails);
                            db.SubmitChanges();

                            var schedule = new SCHEDULE();
                            schedule.PERSONALID = (item as dynamic).Value;
                            schedule.EXAMID = ExamID;
                            schedule.DATEOFTEST = examView.DateOfExam;

                            var subjectInfo = (from t in db.TOPICs
                                               join s in db.SUBJECTs on t.SUBJECTID equals s.SUBJECTID
                                               where t.TOPICID == examView.Topic
                                               select new { t.SUBJECTID, s.SUBJECTNAME }).SingleOrDefault();
                            schedule.SUBJECTID = subjectInfo.SUBJECTID;
                            schedule.NAMEOFSUBJECT = subjectInfo.SUBJECTNAME;
                            schedule.PLACE = "Phòng 500 máy tầng thượng khu Quân Sự";

                            db.SCHEDULEs.InsertOnSubmit(schedule);
                            db.SubmitChanges();
                        }
                        MessageBox.Show(string.Format("Thêm kì thì: {0} thành công", ExamID));
                    }

                }
                catch (Exception)
                {

                    MessageBox.Show("Thêm kì thi thất bại");
                }

            }
            else
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin kì thi");
            }
        }

        private bool isExamOK()
        {
            if (examView.Topic == "" || examView.lbStudentAdded.Items.Count <= 0)
            {
                return false;
            }
            return true;
        }

        private string GetNextExam()
        {
            using (var db = new QLDTDataContext())
            {
                var lastExamID = db.EXAMs.Max(e => e.EXAMID);


                if (lastExamID == null)
                    return "EXAM001";


                string NextID = "EXAM" + (int.Parse(lastExamID.Substring(4, lastExamID.Length - 4)) + 1).ToString("00#");
                return NextID;
            }


        }

    }
}
