using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Models;
using UI.Views;
using ExcelDataTable = Microsoft.Office.Interop.Excel.DataTable;
using Excel = Microsoft.Office.Interop.Excel;
using System.Globalization;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Diagnostics;
using Microsoft.SqlServer.Management.Smo;
using Microsoft.SqlServer.Management.Common;

namespace UI.Presenters
{
    public class MainPresenter
    {
        IMainView view;
        string CurrentUserID;
        int CurLevel;

        public MainPresenter()
        {
            Initialize();
        }

        public MainPresenter(IMainView main)
        {
            view = main;
            Initialize();
        }

        public MainPresenter(IMainView main, string ID, int Level)
        {
            CurrentUserID = ID;
            CurLevel = Level;
            view = main;
            Initialize();

            if (Level == 2 || Level == 3)
            {
                LoadStudentInfo();
            }
        }

        private void LoadStudentInfo()
        {
            StudentInfo studentInfo = new StudentInfo();

            using (var db = new QLDTDataContext())
            {

                var stuInfo = (from u in db.USERACCOUNTs
                               join st in db.STUDENTs on u.PERSONALID equals st.PERSONALID
                               where st.PERSONALID == CurrentUserID
                               select (new { u.PERSONALID, u.EMAIL, st.FULLNAME, st.GENDER, st.DATEOFBIRTH, st.ADR, st.CLASSID })).SingleOrDefault();

                if (stuInfo != null)
                {
                    studentInfo.FullName = stuInfo.FULLNAME;
                    studentInfo.Gender = stuInfo.GENDER;
                    studentInfo.DayOfBirth = stuInfo.DATEOFBIRTH;
                    studentInfo.Email = stuInfo.EMAIL;
                    studentInfo.ClassID = stuInfo.CLASSID;
                    studentInfo.Address = stuInfo.ADR;

                    view.StudentData = studentInfo;
                }
                //kì thi, môn thi, ngàythi, điểm

                view.DTG_LichThi_Va_ketQua.DataSource = GetStudentScoreBoard();

            }
        }

        private DataTable GetStudentScoreBoard()
        {
            DataTable kq = null;
            using (var db = new QLDTDataContext())
            {
                var Query = from _exam in db.EXAMs
                         join _examDetails in db.EXAM_DETAILs on _exam.EXAMID equals _examDetails.EXAMID
                         join _semester in db.SEMESTERs on _exam.SEMESTER equals _semester.SEMESTERID
                         join _topic in db.TOPICs on _examDetails.TOPICID equals _topic.TOPICID
                         join _test in db.TESTs on _examDetails.TOPICID equals _test.TOPICID
                         join _resultOfTest in db.RESULTOFTESTs on _test.TESTID equals _resultOfTest.TESTID
                         where (_test.PERSONALID == CurrentUserID) && (_examDetails.PERSONALID == CurrentUserID) && (_exam.TYPEOFEXAM==1)
                         select new { Ki_Thi = _exam.EXAMID, Hoc_Ky = _semester.NAME, Ngay_Thi = (_exam.DATEOFEXAM).ToShortDateString(), Mon_Hoc = _topic.SUBJECTID, Diem = _resultOfTest.SCORE };
                if(Query!=null)
                {
                    kq = ConvertToDataTable(Query);
                }
            }
            return kq;
        }

        //INIT
        private void Initialize()
        {
            var source = new BindingSource(LoadAccount(), null);
            var TrainSource = new BindingSource(LoadTrain(), null);
            var KiThiSource = LoadKiThi();
            var QuestionSource = LoadQuestion();
            var TopicSource = LoadTopic();
            var StudentTraining = LoadTrainDetails();
            var ListOfTestSource = Load_Exams_For_Test();

            view.data.DataSource = source;
            view.Delete += View_Delete;
            view.Import += View_Import;
            view.Add += View_Add;
            view.Export += View_Export;
            view.UpdateAccount += View_Update;
            view.Check_Connection += Check_Connection;
            view.Save_Connection += Save_Connection;
            view.BackupDB += View_BackupDB;
            view.RestoreDB += View_RestoreDB;

            view.Add_StudentTrain += View_Add_StudentTrain;
            view.Update_StudentTrain += View_Update_StudentTrain;
            view.Delete_StudentTrain += View_Delete_StudentTrain;


            //Kì thi
            view.Add_Exams += View_Add_Exams;
            view.Update_Exams += View_Update_Exams;
            view.Delete_Exams += View_Delete_Exams;
            view.PrintToPDF_Exams += View_PrintToPDF_Exams;


            //in bảng điểm và thông tin cá nhân của học sinh
            view.MainEvent_PrintToPDF_StudentInformation += View_MainEvent_PrintToPDF_StudentInformation;

            //Luyện thi

            view.Training += View_Training;

            //event cho làm bài thi, thi thật/thi thử
            view.MainEvent_BeginTheTest += View_MainEvent_BeginTheTest;

            //các event câu hỏi khi bấm các nút bên form main xử lý lại đây
            view.MainEvent_Add_Question += View_MainEvent_Add_Question;
            view.MainEvent_Update_Question += View_MainEvent_Update_Question;
            view.MainEvent_Delete_Question += View_MainEvent_Delete_Question;
            view.MainEvent_Export_Question += View_MainEvent_Export_Question;
            view.MainEvent_Import_Question += View_MainEvent_Import_Question;

            //các event đế thi khi bấm nút bên form main
            view.MainEvent_Add_Topic += View_MainEvent_Add_Topic;
            view.MainEvent_Update_Topic += View_MainEvent_Update_Topic;
            view.MainEvent_Delete_Topic += View_MainEvent_Delete_Topic;

            if (QuestionSource != null)
            {
                view.DTG_Question_Main.DataSource = QuestionSource;
            }

            if (TopicSource != null)
            {
                view.DTG_Topic_Main.DataSource = TopicSource;
            }
            if (TrainSource != null)
            {
                view.TrainData.DataSource = TrainSource;
            }

            if (KiThiSource != null)
            {
                view.KiThi.DataSource = KiThiSource;
            }
            if (StudentTraining != null)
            {
                view.StudentTraining.DataSource = StudentTraining;
            }
            if (ListOfTestSource != null)
            {
                view.DTG_List_Of_Tests_Main.DataSource = ListOfTestSource;
            }
        }

        private void View_RestoreDB(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Backup Files (*.bak;*.trn)|*.bak;*.trn";
            openFileDialog.ValidateNames = true;
            openFileDialog.RestoreDirectory = true;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string databaseName = view.DBName;
                string connectionString = view.SystemConnectionString;
                string filePath = openFileDialog.FileName;
                WaitingForm waiting = new WaitingForm();
                waiting.ShowInTaskbar = false;
                waiting.Shown += async (s, e2) =>
                {
                    await Task.Run(() =>
                    {
                        //Tác vụ làm tốn thời gian
                        RestoreDatabase(databaseName, connectionString, filePath);
                    });
                    waiting.Close();
                };
                waiting.ShowDialog();
            }
        }

        private void View_BackupDB(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Backup Files (*.bak;*.trn)|*.bak;*.trn";
            saveFileDialog.ValidateNames = true;
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string databaseName = view.DBName;
                string connectionString = view.SystemConnectionString;
                string destinationPath = saveFileDialog.FileName;
                if (File.Exists(destinationPath))
                    File.Delete(destinationPath);
                WaitingForm waiting = new WaitingForm();
                waiting.ShowInTaskbar = false;
                waiting.Shown += async (s, e2) =>
                {
                    await Task.Run(() =>
                    {
                        //Tác vụ tốn nhiều thời gian
                        BackupDatabase(databaseName, connectionString, destinationPath);
                    });
                    waiting.Close();
                };
                waiting.ShowDialog();
            }
        }

        private void BackupDatabase(string databaseName, string connectionString, string destinationPath)
        {
            Backup sqlBackup = new Backup();

            sqlBackup.Action = BackupActionType.Database;
            sqlBackup.BackupSetDescription = "Backup Date: " + DateTime.Now.ToShortDateString();
            sqlBackup.BackupSetName = "SqlBackup";

            sqlBackup.Database = databaseName;

            BackupDeviceItem deviceItem = new BackupDeviceItem(destinationPath, DeviceType.File);
            ServerConnection connection = new ServerConnection();
            connection.ConnectionString = connectionString;
            Server sqlServer = new Server(connection);

            sqlBackup.Initialize = true;
            sqlBackup.Checksum = true;
            sqlBackup.ContinueAfterError = true;

            sqlBackup.Devices.Add(deviceItem);
            sqlBackup.Incremental = false;

            sqlBackup.ExpirationDate = DateTime.Now.AddDays(3);
            sqlBackup.LogTruncation = BackupTruncateLogType.Truncate;

            sqlBackup.FormatMedia = false;

            sqlBackup.SqlBackup(sqlServer);
            connection.Disconnect();
        }

        private void RestoreDatabase(string databaseName, string connectionString, string filePath)
        {
            Restore sqlRestore = new Restore();

            BackupDeviceItem deviceItem = new BackupDeviceItem(filePath, DeviceType.File);
            sqlRestore.Devices.Add(deviceItem);
            sqlRestore.Database = databaseName;

            ServerConnection connection = new ServerConnection();
            connection.ConnectionString = connectionString;
            Server sqlServer = new Server(connection);

            RelocateFile DataFile = new RelocateFile();
            string MDF = sqlRestore.ReadFileList(sqlServer).Rows[0][1].ToString();
            DataFile.LogicalFileName = sqlRestore.ReadFileList(sqlServer).Rows[0][0].ToString();
            DataFile.PhysicalFileName = sqlServer.Databases[databaseName].FileGroups[0].Files[0].FileName;

            RelocateFile LogFile = new RelocateFile();
            string LDF = sqlRestore.ReadFileList(sqlServer).Rows[1][1].ToString();
            LogFile.LogicalFileName = sqlRestore.ReadFileList(sqlServer).Rows[1][0].ToString();
            LogFile.PhysicalFileName = sqlServer.Databases[databaseName].LogFiles[0].FileName;

            sqlRestore.RelocateFiles.Add(DataFile);
            sqlRestore.RelocateFiles.Add(LogFile);
            sqlRestore.ReplaceDatabase = true;
            Database db = sqlServer.Databases[databaseName];
            db.SetOffline();

            sqlRestore.SqlRestore(sqlServer);
            db.SetOnline();
            sqlServer.Refresh();
            connection.Disconnect();
        }

        private void View_MainEvent_PrintToPDF_StudentInformation(object sender, EventArgs e)
        {
            if (CurLevel == 2)
            {
                string ThongTinHocSinh = "THÔNG TIN VÀ BẢNG ĐIỂM HỌC SINH " + CurrentUserID.ToString() + "\n\n";
                using (var db = new QLDTDataContext())
                {
                    var stuInfo = (from u in db.USERACCOUNTs
                                   join st in db.STUDENTs on u.PERSONALID equals st.PERSONALID
                                   where st.PERSONALID == CurrentUserID
                                   select (new { u.PERSONALID, u.EMAIL, st.FULLNAME, st.GENDER, st.DATEOFBIRTH, st.ADR, st.CLASSID })).SingleOrDefault();

                    if (stuInfo != null)
                    {
                        ThongTinHocSinh += "Họ và Tên: " + stuInfo.FULLNAME.ToString() + "\n";
                        ThongTinHocSinh += "Giới tính: " + stuInfo.GENDER.ToString() + "    -    ";
                        ThongTinHocSinh += "Ngày sinh: " + stuInfo.DATEOFBIRTH.ToShortDateString() + "\n";
                        ThongTinHocSinh += "Email: " + stuInfo.EMAIL.ToString() + "\n";
                        ThongTinHocSinh += "Lớp học hiện tại: " + stuInfo.CLASSID.ToString() + "\n";
                        ThongTinHocSinh += "Địa chỉ: " + stuInfo.ADR.ToString() + "\n\n";
                    }
                }
                var bangDiem = GetStudentScoreBoard();
                ExportToPDF(bangDiem, "BangDiemCuaHocSinh_" + CurrentUserID, ThongTinHocSinh);
            }
        }


        //PRINT TO PDF
        private void View_PrintToPDF_Exams(object sender, EventArgs e)
        {
            string ExamID = sender as string;

            using (var db = new QLDTDataContext())
            {

                var nQuery = from ex in db.EXAMs
                             join exd in db.EXAM_DETAILs on ex.EXAMID equals exd.EXAMID
                             join tp in db.TOPICs on exd.TOPICID equals tp.TOPICID
                             join st in db.STUDENTs on exd.PERSONALID equals st.PERSONALID
                             join test in db.TESTs on exd.PERSONALID equals test.PERSONALID
                             join rs in db.RESULTOFTESTs on test.TESTID equals rs.TESTID
                             where test.TOPICID == tp.TOPICID && ex.EXAMID == ExamID
                 
                             select new { Subject = tp.SUBJECTID, Date = ex.DATEOFEXAM.ToShortDateString(), Name = st.FULLNAME, StudentID = exd.PERSONALID, Class = st.CLASSID,Score = rs.SCORE };

                var data = ConvertToDataTable(nQuery);
                if (data != null)
                {
                    ExportToPDF(data, ExamID, "DANH SÁCH HỌC SINH TRONG KỲ THI "+ExamID+"\n\n");
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu ");
                }
            }

        }


        private void ExportToPDF(DataTable dt, string FileName, string _paragraph)
        {
            string sylfaenpath = Environment.GetEnvironmentVariable("SystemRoot") + "\\fonts\\Arial.ttf";
            BaseFont sylfaen = BaseFont.CreateFont(sylfaenpath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
            Font head = new Font(sylfaen, 12f, Font.NORMAL, BaseColor.BLUE);
            Font normal = new Font(sylfaen, 10f, Font.NORMAL, BaseColor.BLACK);
            Font underline = new Font(sylfaen, 10f, Font.UNDERLINE, BaseColor.BLACK);
            string dateString = DateTime.Now.ToString();
            dateString = dateString.Replace("/", "");
            dateString = dateString.Replace(@"\", "");
            dateString = dateString.Replace(":", "");
            dateString = dateString.Replace("AM", "");
            dateString = dateString.Replace("PM", "");
            dateString = dateString.Replace(" ", "");

            var pdfdocument = new Document(PageSize.LETTER);
            string main_fielName = FileName + "_" + dateString;

            SaveFileDialog savefile = new SaveFileDialog();
            // set a default file name
            savefile.FileName = main_fielName + ".pdf";
            // set filters - this can be done in properties as well
            savefile.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

            if (savefile.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(savefile.FileName))
                    sw.WriteLine("Hello World!");
            }

            string _path = savefile.FileName;

            var filepdf = string.Format(_path);

            //ghi đè
            if (File.Exists(filepdf))
            {
                File.Delete(filepdf);
            }

            var pdfWriter = PdfWriter.GetInstance(pdfdocument, new FileStream(filepdf, FileMode.Create));
            pdfdocument.Open();

            //Paragraph p = new Paragraph();
            //p.Add(new Phrase(_paragraph,f));
            pdfdocument.Add(new Paragraph(_paragraph, normal));

            var pdfTable = new PdfPTable(dt.Columns.Count);
            pdfTable.WidthPercentage = 100;

            //dat ten cot
            foreach (DataColumn item in dt.Columns)
            {
                var pdfCell = new PdfPCell(new Phrase(item.ColumnName));
                pdfTable.AddCell(pdfCell);
            }

            // thêm giá trị cho từng cột
            foreach (DataRow row in dt.Rows)
            {
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    //MessageBox.Show(row[i].ToString());
                    var cell = new PdfPCell(new Phrase(row[i].ToString()));
                    pdfTable.AddCell(cell);
                }

            }
            pdfdocument.Add(pdfTable);
            pdfdocument.Close();

            ProcessStartInfo startInfo = new ProcessStartInfo(string.Format(_path));
            Process.Start(startInfo);

        }




        public delegate void LoadAll();
        public void LoadAllDataGridView()
        {
            var source = new BindingSource(LoadAccount(), null);
            var TrainSource = new BindingSource(LoadTrain(), null);
            var KiThiSource = LoadKiThi();
            var QuestionSource = LoadQuestion();
            var TopicSource = LoadTopic();
            var StudentTraining = LoadTrainDetails();
            var ListOfTestSource = Load_Exams_For_Test();

            if (CurLevel == 2)
            {
                LoadStudentInfo();
            }
            if (source != null)
            {
                view.data.DataSource = source;
            }
            if (QuestionSource != null)
            {
                view.DTG_Question_Main.DataSource = QuestionSource;
            }

            if (TopicSource != null)
            {
                view.DTG_Topic_Main.DataSource = TopicSource;
            }
            if (TrainSource != null)
            {
                view.TrainData.DataSource = TrainSource;
            }

            if (KiThiSource != null)
            {
                view.KiThi.DataSource = KiThiSource;
            }
            if (StudentTraining != null)
            {
                view.StudentTraining.DataSource = StudentTraining;
            }
            if (ListOfTestSource != null)
            {
                view.DTG_List_Of_Tests_Main.DataSource = ListOfTestSource;
            }
        }

        private void View_MainEvent_BeginTheTest(object sender, EventArgs e)
        {
            var Temp = Load_Exams_For_Test();
            if (Temp != null)
            {
                view.DTG_List_Of_Tests_Main.DataSource = Temp;
            }
        }

        private void View_Training(object sender, EventArgs e)
        {
            try
            {
                var StudentTraining = LoadTrainDetails();
                if (StudentTraining != null)
                {
                    view.StudentTraining.DataSource = StudentTraining;
                }
            }
            finally
            {
                var StudentTraining = LoadTrainDetails();
                if (StudentTraining != null)
                {
                    view.StudentTraining.DataSource = StudentTraining;
                }
            }
        }

        private object LoadQuestion()
        {
            using (var db = new QLDTDataContext())
            {
                return db.QUESTIONs.Count() > 0 ? ConvertToDataTable(db.QUESTIONs) : null;
            }
        }

        private object LoadTopic()
        {
            using (var db = new QLDTDataContext())
            {
                return db.TOPICs.Count() > 0 ? ConvertToDataTable(db.TOPICs.Select(tp => new { tp.TOPICID, tp.SUBJECTID, tp.GRADEID, tp.TOTALTIME })) : null;
            }
        }

        private void View_MainEvent_Add_Question(object sender, EventArgs e)
        {
            FormTeachAddQuestion frmAddQuestion = new FormTeachAddQuestion(LoadAllDataGridView);
            frmAddQuestion.ShowDialog();
            view.DTG_Question_Main.DataSource = LoadQuestion();
        }

        private void View_MainEvent_Add_Topic(object sender, EventArgs e)
        {
            FormTeachAddQuestionKit frmAddTopic = new FormTeachAddQuestionKit(LoadAllDataGridView);
            frmAddTopic.ShowDialog();
            view.DTG_Topic_Main.DataSource = LoadTopic();
        }

        bool DeteleAllTestByTestID(string TestID)
        {
            try
            {
                using (var db = new QLDTDataContext())
                {
                    //xóa Stat
                    var Query_Result1 = db.STATISTICs.Where(ex => ex.TESTID == TestID);
                    if (Query_Result1 != null)
                    {
                        db.STATISTICs.DeleteAllOnSubmit(Query_Result1);
                        db.SubmitChanges();
                    }

                    //xóa Process
                    var Query_Result2 = db.PROCESSes.Where(ex => ex.TESTID == TestID);
                    if (Query_Result2 != null)
                    {
                        db.PROCESSes.DeleteAllOnSubmit(Query_Result2);
                        db.SubmitChanges();
                    }

                    //xóa Result of test
                    var Query_Result3 = db.RESULTOFTESTs.Where(ex => ex.TESTID == TestID);
                    if (Query_Result3 != null)
                    {
                        db.RESULTOFTESTs.DeleteAllOnSubmit(Query_Result3);
                        db.SubmitChanges();
                    }

                    //xóa câu hỏi
                    var Query_Result6 = db.TESTs.Where(ex => ex.TESTID == TestID);
                    if (Query_Result6 != null)
                    {
                        db.TESTs.DeleteAllOnSubmit(Query_Result6);
                        db.SubmitChanges();
                    }

                }

                //MessageBox.Show(string.Format("Xóa câu hỏi: {0} thành công", curQuestionID));
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format("Xóa TEST: {0} thất bại", TestID));
            }
            return false;
        }

        private void View_MainEvent_Delete_Question(object sender, EventArgs e)
        {
            var curQuestionID = sender as string;
            try
            {
                using (var db = new QLDTDataContext())
                {
                    //kiểm tra trước khi xóa
                    var Query_Check = db.TOPIC_DETAILs.Where(ex => ex.QUESTIONID == curQuestionID).ToList();
                    for(int i = 0; i< Query_Check.Count;i++)
                    {
                        var temp = Query_Check[i].TOPICID;
                        var Query_Check2 = db.TRAININGHISTORies.Where(ex => ex.TOPICID == temp).ToList();
                        var Query_Check3 = db.EXAM_DETAILs.Where(ex => ex.TOPICID == temp).ToList();
                        if (Query_Check2.Count + Query_Check3.Count > 0)
                        {
                            MessageBox.Show("Không thể xóa vì câu hỏi đang nằm trong 1 đề thi được sử dụng!");
                            return;
                        }
                    }
                    //xóa trong process trước
                    var Query_Result = db.PROCESSes.Where(ex => ex.QUESTIONID == curQuestionID);
                    if (Query_Result != null)
                    {
                        db.PROCESSes.DeleteAllOnSubmit(Query_Result);
                        db.SubmitChanges();
                    }

                    //xóa trong topic Details
                    var Query_Result2 = db.TOPIC_DETAILs.Where(ex => ex.QUESTIONID == curQuestionID);
                    if (Query_Result2 != null)
                    {
                        db.TOPIC_DETAILs.DeleteAllOnSubmit(Query_Result2);
                        db.SubmitChanges();
                    }


                    //xóa trong Stat
                    var Query_Result3 = db.STATISTICs.Where(ex => ex.QUESTIONID == curQuestionID);
                    if (Query_Result3 != null)
                    {
                        db.STATISTICs.DeleteAllOnSubmit(Query_Result3);
                        db.SubmitChanges();
                    }


                    //xóa trong question storage
                    var Query_Result4 = db.QUESTIONSSTORAGEs.Where(ex => ex.QUESTIONID == curQuestionID);
                    if (Query_Result4 != null)
                    {
                        db.QUESTIONSSTORAGEs.DeleteAllOnSubmit(Query_Result4);
                        db.SubmitChanges();
                    }


                    //xóa trong percent
                    var Query_Result5 = db.PERCENTAGEOFQUESTIONs.Where(ex => ex.QUESTIONID == curQuestionID);
                    if (Query_Result5 != null)
                    {
                        db.PERCENTAGEOFQUESTIONs.DeleteAllOnSubmit(Query_Result5);
                        db.SubmitChanges();
                    }

                    //xóa câu hỏi
                    var Query_Result6 = db.QUESTIONs.Where(ex => ex.QUESTIONID == curQuestionID);
                    if (Query_Result6 != null)
                    {
                        db.QUESTIONs.DeleteAllOnSubmit(Query_Result6);
                        db.SubmitChanges();
                    }

                }

                MessageBox.Show(string.Format("Xóa câu hỏi: {0} thành công", curQuestionID));
                view.DTG_Question_Main.DataSource = LoadQuestion();
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format("Xóa câu hỏi: {0} thất bại", curQuestionID));
            }
        }

        private void View_MainEvent_Delete_Topic(object sender, EventArgs e)
        {
            var CurrentTopicID = sender as string;

            try
            {
                using (var db = new QLDTDataContext())
                {
                    //kiểm tra đề thi đã sử dụng chưa
                    var Query_Check = db.TRAININGHISTORies.Where(ex => ex.TOPICID == CurrentTopicID).ToList();
                    var Query_Check2= db.EXAM_DETAILs.Where(ex => ex.TOPICID == CurrentTopicID).ToList();
                    if (Query_Check.Count + Query_Check2.Count> 0)
                    {
                        MessageBox.Show("Không thể xóa vì đề thi đang được sử dụng!");
                        return;
                    }
                    //xóa train his
                    var Query_Result1 = db.TRAININGHISTORies.Where(ex => ex.TOPICID == CurrentTopicID);
                    if (Query_Result1 != null)
                    {
                        db.TRAININGHISTORies.DeleteAllOnSubmit(Query_Result1);
                        db.SubmitChanges();
                    }

                    //XÓA nhiều thứ trước khi xóa TRƯỚC TEST, lấy ID test ra
                    var temp = db.TESTs.Where(ex => ex.TOPICID == CurrentTopicID).ToList();
                    foreach (var i in temp)
                    {
                        DeteleAllTestByTestID(i.TESTID.ToString());
                    }


                    //xóa trong Exam Details
                    var Query_Result3 = db.EXAM_DETAILs.Where(ex => ex.TOPICID == CurrentTopicID);
                    if (Query_Result3 != null)
                    {
                        db.EXAM_DETAILs.DeleteAllOnSubmit(Query_Result3);
                        db.SubmitChanges();
                    }

                    //xóa trong TopicDetails
                    var Query_Result4 = db.TOPIC_DETAILs.Where(ex => ex.TOPICID == CurrentTopicID);
                    if (Query_Result4 != null)
                    {
                        db.TOPIC_DETAILs.DeleteAllOnSubmit(Query_Result4);
                        db.SubmitChanges();
                    }


                    //xóa đề thi
                    var Query_Result6 = db.TOPICs.Where(ex => ex.TOPICID == CurrentTopicID);
                    if (Query_Result6 != null)
                    {
                        db.TOPICs.DeleteAllOnSubmit(Query_Result6);
                        db.SubmitChanges();
                    }

                }

                MessageBox.Show(string.Format("Xóa đề thi: {0} thành công", CurrentTopicID));
                view.DTG_Topic_Main.DataSource = LoadTopic();
            }
            catch (Exception)
            {
                MessageBox.Show(string.Format("Xóa đề thi: {0} thất bại", CurrentTopicID));
            }
        }

        private string GetNextQuestionID()
        {
            using (var db = new QLDTDataContext())
            {
                var lastExamID = db.QUESTIONs.Max(e => e.QUESTIONID);
                if (lastExamID == null)
                    return "Q00001";
                int SoHienTai = int.Parse(lastExamID.Substring(1));
                SoHienTai++;
                return "Q" + SoHienTai.ToString("00000");
            }
        }

        bool CheckQuestionDuplicate(DataRow item)
        {
            var newQuestion = new QUESTION();
            newQuestion.GRADEID = item["GRADEID"].ToString();
            newQuestion.SUBJECTID = item["SUBJECTID"].ToString();
            newQuestion.CONTENTOFQUESTION = item["CONTENTOFQUESTION"].ToString();
            newQuestion.A = item["A"].ToString();
            newQuestion.B = item["B"].ToString();
            newQuestion.C = item["C"].ToString();
            newQuestion.D = item["D"].ToString();
            newQuestion.E = item["E"].ToString();
            newQuestion.F = item["F"].ToString();
            newQuestion.CORRECTANSWER = item["CORRECTANSWER"].ToString();
            newQuestion.HINT = item["HINT"].ToString();
            newQuestion.DIFFICULT = int.Parse(item["DIFFICULT"].ToString());
            newQuestion.ISPRO = int.Parse(item["ISPRO"].ToString());
            //nếu tồn tại 1 câu hỏi có các chỉ số trên, return true
            using (var db = new QLDTDataContext())
            {
                var listQuestion = db.QUESTIONs.Where(
                    i => i.CONTENTOFQUESTION == newQuestion.CONTENTOFQUESTION
                    && i.A == newQuestion.A
                    && i.B == newQuestion.B
                    && i.C == newQuestion.C
                    && i.D == newQuestion.D
                    && i.E == newQuestion.E
                    && i.F == newQuestion.F
                    && i.CONTENTOFQUESTION == newQuestion.CONTENTOFQUESTION).ToList();
                if (listQuestion.Count > 0)
                    return true;
            }
            return false;
        }
        private void View_MainEvent_Import_Question(object sender, EventArgs e)
        {
            var data = ReadExel();
            if (data.DataSet != null)
            {
                DialogResult dialog = MessageBox.Show("Bạn chắc chắn muốn thêm danh sách câu hỏi từ file đã chọn?", "Import Question(s)", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {
                    if (AddQuestions(data))
                    {
                        MessageBox.Show("Import thành công");
                    }
                    view.DTG_Question_Main.DataSource = LoadQuestion();
                }
            }
        }

        private void View_MainEvent_Export_Question(object sender, EventArgs e)
        {
            Excel.Application xla = new Excel.Application();
            Excel.Workbook wb = xla.Workbooks.Add(Excel.XlSheetType.xlWorksheet);
            //object missing = System.Reflection.Missing.Value;

            //wb.SaveAs(@"D:\a.xlsx",
            //            Excel.XlFileFormat.xlOpenXMLWorkbook, missing, missing,
            //            false, false, Excel.XlSaveAsAccessMode.xlNoChange,
            //            missing, missing, missing, missing, missing);
            Excel.Worksheet ws = (Excel.Worksheet)xla.ActiveSheet;

            xla.Visible = false;
            xla.Cells[1, 1] = "QUESTIONID";
            xla.Cells[1, 2] = "GRADEID";
            xla.Cells[1, 3] = "SUBJECTID";
            xla.Cells[1, 4] = "CONTENTOFQUESTION";
            xla.Cells[1, 5] = "A";
            xla.Cells[1, 6] = "B";
            xla.Cells[1, 7] = "C";
            xla.Cells[1, 8] = "D";
            xla.Cells[1, 9] = "E";
            xla.Cells[1, 10] = "F";
            xla.Cells[1, 11] = "CORRECTANSWER";
            xla.Cells[1, 12] = "HINT";
            xla.Cells[1, 13] = "DIFFICULT";
            xla.Cells[1, 14] = "ISPRO";

            int row = 2;

            using (var db = new QLDTDataContext())
            {
                var listQuestions = db.QUESTIONs;
                foreach (var item in listQuestions)
                {
                    xla.Cells[row, 1] = item.QUESTIONID.ToString();
                    xla.Cells[row, 2] = item.GRADEID.ToString();
                    xla.Cells[row, 3] = item.SUBJECTID.ToString();
                    xla.Cells[row, 4] = item.CONTENTOFQUESTION.ToString();
                    xla.Cells[row, 5] = item.A.ToString();
                    xla.Cells[row, 6] = item.B.ToString();
                    xla.Cells[row, 7] = item.C.ToString();
                    xla.Cells[row, 8] = item.D.ToString();
                    xla.Cells[row, 9] = item.E.ToString();
                    xla.Cells[row, 10] = item.F.ToString();
                    xla.Cells[row, 11] = item.CORRECTANSWER.ToString();
                    xla.Cells[row, 12] = item.HINT.ToString();
                    xla.Cells[row, 13] = item.DIFFICULT.ToString();
                    xla.Cells[row, 14] = item.ISPRO.ToString();

                    row++;
                }
            }
            xla.Columns.AutoFit();
            xla.Visible = true;
        }
        bool AddQuestions(DataTable dt)
        {
            using (var db = new QLDTDataContext())
            {
                int numOfQuestionsAdded = 0;
                foreach (DataRow item in dt.Rows)
                {
                    if (CheckQuestionDuplicate(item) == false)
                    {
                        numOfQuestionsAdded++;
                        //thêm câu hỏi...
                        string newQuestionID = GetNextQuestionID();
                        var newQuestion = new QUESTION();
                        newQuestion.QUESTIONID = newQuestionID;
                        newQuestion.GRADEID = item["GRADEID"].ToString();
                        newQuestion.SUBJECTID = item["SUBJECTID"].ToString();
                        newQuestion.CONTENTOFQUESTION = item["CONTENTOFQUESTION"].ToString();
                        newQuestion.A = item["A"].ToString();
                        newQuestion.B = item["B"].ToString();
                        newQuestion.C = item["C"].ToString();
                        newQuestion.D = item["D"].ToString();
                        newQuestion.E = item["E"].ToString();
                        newQuestion.F = item["F"].ToString();
                        newQuestion.CORRECTANSWER = item["CORRECTANSWER"].ToString();
                        newQuestion.HINT = item["HINT"].ToString();
                        newQuestion.DIFFICULT = int.Parse(item["DIFFICULT"].ToString());
                        newQuestion.ISPRO = int.Parse(item["ISPRO"].ToString());
                        ;
                        db.QUESTIONs.InsertOnSubmit(newQuestion);
                        db.SubmitChanges();
                    }
                }
                MessageBox.Show("Đã thêm " + numOfQuestionsAdded.ToString() + " Câu hỏi!");
                return true;
            }
            return false;
        }

        private void View_MainEvent_Update_Topic(object sender, EventArgs e)
        {
            var CurrentTopicID = sender as string;
            using (QLDTDataContext db = new QLDTDataContext())
            {
                var Query_Check = db.TRAININGHISTORies.Where(ex => ex.TOPICID == CurrentTopicID).ToList();
                var Query_Check2 = db.EXAM_DETAILs.Where(ex => ex.TOPICID == CurrentTopicID).ToList();
                if (Query_Check.Count + Query_Check2.Count > 0)
                {
                    MessageBox.Show("Không thể Thay đổi vì đề thi đang được sử dụng!");
                    return;
                }
            }
            FormTeachUpdateQuestionKit frmUPdateTopic = new FormTeachUpdateQuestionKit(CurrentTopicID, LoadAllDataGridView);
            frmUPdateTopic.ShowDialog();
            view.DTG_Topic_Main.DataSource = LoadTopic();
        }

        private void View_MainEvent_Update_Question(object sender, EventArgs e)
        {
            var curQuestionID = sender as string;
            using (var db = new QLDTDataContext())
            {
                //kiểm tra trước khi xóa
                var Query_Check = db.TOPIC_DETAILs.Where(ex => ex.QUESTIONID == curQuestionID).ToList();
                for (int i = 0; i < Query_Check.Count; i++)
                {
                    var temp = Query_Check[i].TOPICID;
                    var Query_Check2 = db.TRAININGHISTORies.Where(ex => ex.TOPICID == temp).ToList();
                    var Query_Check3 = db.EXAM_DETAILs.Where(ex => ex.TOPICID == temp).ToList();
                    if (Query_Check2.Count + Query_Check3.Count > 0)
                    {
                        MessageBox.Show("Không thể Chỉnh sửa vì câu hỏi đang nằm trong 1 đề thi được sử dụng!");
                        return;
                    }
                }
            }
                FormTeachUpdateQuestion frmUpdateQuestion = new FormTeachUpdateQuestion(curQuestionID, LoadAllDataGridView);
            frmUpdateQuestion.ShowDialog();
            view.DTG_Question_Main.DataSource = LoadQuestion();
        }

        private void Save_Connection(object sender, EventArgs e)
        {
            string ConnectionString = sender as string;
            if (CheckConnectionString(ConnectionString))
            {
                Utils.SettingsManager.AddUpdateAppSettings("connectionString", ConnectionString);
                MessageBox.Show("Hãy khởi động lại ứng dụng để thay đổi có hiệu lực.", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Kết nối không thành công, không thể lưu.", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void Check_Connection(object sender, EventArgs e)
        {
            string ConnectionString = sender as string;
            if (CheckConnectionString(ConnectionString))
                MessageBox.Show("Thành công!", "Kiểm tra kết nối", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                MessageBox.Show("Thất bại!", "Kiểm tra kết nối", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private bool CheckConnectionString(string ConnectionString)
        {
            try
            {
                using (QLDTDataContext db = new QLDTDataContext())
                {
                    db.Connection.ConnectionString = ConnectionString;
                    var testQuery = db.ADMINISTRATORs.Where(ad => ad.PERSONALID == "-1").SingleOrDefault();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void View_Delete_StudentTrain(object sender, EventArgs e)
        {
            var curSelect = sender as List<string>;
            var curTrainID = curSelect[0];
            var curPersonID = curSelect[1];
            try
            {
                using (var db = new QLDTDataContext())
                {
                    var curTrainHistory = db.TRAININGHISTORies.Where(th => th.TRAININGID == curTrainID && th.PERSONALID == curPersonID).SingleOrDefault();
                    if (curTrainHistory != null)
                    {
                        db.TRAININGHISTORies.DeleteOnSubmit(curTrainHistory);
                        db.SubmitChanges();
                    }

                    var curTrain = db.TRAININGs.Where(th => th.TRAININGID == curTrainID && th.PERSONALID == curPersonID).SingleOrDefault();
                    if (curTrain != null)
                    {
                        db.TRAININGs.DeleteOnSubmit(curTrain);
                        db.SubmitChanges();
                    }
                }

                view.TrainData.DataSource = LoadTrain();
                MessageBox.Show(string.Format("Xóa trainID: {0} thành công", curTrainID));
            }
            catch (Exception)
            {

                MessageBox.Show(string.Format("Xóa trainID: {0} thất bại", curTrainID));
            }

        }

        private void View_Delete_Exams(object sender, EventArgs e)
        {


            var curExamID = sender as string;
            //try
            //{
            using (var db = new QLDTDataContext())
            {

                //Delete Schedule
                var schedule = db.SCHEDULEs.Where(s => s.EXAMID == curExamID);
                if (schedule != null)
                {
                    db.SCHEDULEs.DeleteAllOnSubmit(schedule);
                    db.SubmitChanges();
                }

                //Delete Exam Details
                var CurExamDetails = db.EXAM_DETAILs.Where(ed => ed.EXAMID == curExamID);
                if (CurExamDetails != null)
                {
                    db.EXAM_DETAILs.DeleteAllOnSubmit(CurExamDetails);
                    db.SubmitChanges();
                }


                //Delete Percent tong quat cau lam dung 
                var percent = db.PERCENTAGEOFQUESTIONs.Where(p => p.EXAMID == curExamID);
                if (percent != null)
                {
                    db.PERCENTAGEOFQUESTIONs.DeleteAllOnSubmit(percent);
                    db.SubmitChanges();
                }



                //Delete Exam 
                var curExam = db.EXAMs.Where(ex => ex.EXAMID == curExamID);
                if (curExam != null)
                {
                    db.EXAMs.DeleteAllOnSubmit(curExam);
                    db.SubmitChanges();
                }

            }

            MessageBox.Show(string.Format("Xóa kì thi: {0} thành công", curExamID));
            view.KiThi.DataSource = LoadKiThi();
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show(string.Format("Xóa kì thi: {0} thất bại", curExamID));
            //}

        }

        private void View_Update_Exams(object sender, EventArgs e)
        {
            var curExamID = sender as string;
            FormTeachUpdateExam frmExamUpdate = new FormTeachUpdateExam(curExamID, LoadAllDataGridView);
            frmExamUpdate.ShowDialog();

            view.KiThi.DataSource = LoadKiThi();


        }

        private void View_Update_StudentTrain(object sender, EventArgs e)
        {
            var curSelect = sender as List<string>;
            FormTeachUpdateTrain frmUpdateTrain = new FormTeachUpdateTrain(curSelect[0], curSelect[1], LoadAllDataGridView);
            frmUpdateTrain.ShowDialog();
            view.TrainData.DataSource = LoadTrain();
        }

        private void View_Add_Exams(object sender, EventArgs e)
        {
            FormTeachAddExam frmExam = new FormTeachAddExam(LoadAllDataGridView);
            frmExam.ShowDialog();
            view.KiThi.DataSource = LoadKiThi();
        }

        private object LoadKiThi()
        {
            using (var db = new QLDTDataContext())
            {

                return db.EXAMs.Count() > 0 ? ConvertToDataTable(db.EXAMs.Select(ex => new { ex.EXAMID, ex.SEMESTER, ex.YEAROFSEMESTER, ex.TYPEOFEXAM, ex.STATUSOFEXAM, ex.DATEOFEXAM })) : null;
            }
        }

        private DataTable LoadTrain()
        {
            using (var db = new QLDTDataContext())
            {
                return db.TRAININGs.Count() > 0 ? ConvertToDataTable(db.TRAININGs.Select(t => new { t.TRAININGID, t.PERSONALID, t.OVERALLPROPERBILITY, t.TOTALCOMPLETED })) : null;
            }
        }
        private DataTable LoadTrainDetails()
        {
            using (var db = new QLDTDataContext())
            {
                return db.TRAININGHISTORies.Where(t => t.PERSONALID == CurrentUserID).Count() > 0 ?
                    ConvertToDataTable(db.TRAININGHISTORies.Where(t => t.PERSONALID == CurrentUserID).Select(tr => new { tr.TRAININGID, tr.PERSONALID, tr.TOPICID, tr.TRAININGDATE, tr.RESULT, tr.TOTALCORRECT, tr.TOTALINCORRECT, tr.OVERALLPROPERBILITY })) : null;
            }
        }

        //hàm load Danh sách lịch thi của học kì đã mở kì thi của 1 học sinh
        private object Load_Exams_For_Test()
        {
            using (var db = new QLDTDataContext())
            {
                //kết bảng exam , exam details và Subject
                var Results = from _exam in db.EXAMs
                              join _examDetails in db.EXAM_DETAILs on _exam.EXAMID equals _examDetails.EXAMID
                              join _topic in db.TOPICs on _examDetails.TOPICID equals _topic.TOPICID
                              where _exam.STATUSOFEXAM == 1 && _examDetails.PERSONALID == CurrentUserID
                              select new
                              {
                                  PERSONALID = _examDetails.PERSONALID,
                                  EXAMID = _exam.EXAMID,
                                  DATEOFEXAM = _exam.DATEOFEXAM
                                           ,
                                  SEMESTER = _exam.SEMESTER,
                                  YEAROFSEMESTER = _exam.YEAROFSEMESTER
                                           ,
                                  SUBJECTID = _topic.SUBJECTID,
                                  TYPEOFEXAM = _exam.TYPEOFEXAM,
                                  TOPICID = _examDetails.TOPICID
                              };

                //kiểm tra có nằm trong process, test và result of test ko, ko có thì insert vào
                DataTable temp = ConvertToDataTable(Results);
                //duyệt từng hàng, mỗi hàng là 1 đề của thí sinh này
                foreach (DataRow row in temp.Rows)
                {
                    var Query_1 = db.TESTs.Where(a => a.PERSONALID == CurrentUserID && a.TOPICID == row[7].ToString()).ToList();
                    if (Query_1.Count <= 0)
                    {
                        //chưa tồn tại đề này cho học sinh này, insert vào
                        string currentTopicID = row[7].ToString();
                        string newTestID = GetNextTestID();
                        int TongSoCauHoi = db.TOPIC_DETAILs.Where(a => a.TOPICID == currentTopicID).ToList().Count();
                        var ListCauHoi = db.TOPIC_DETAILs.Where(a => a.TOPICID == currentTopicID).ToList();

                        var newTest = new TEST();
                        newTest.TESTID = newTestID;
                        newTest.TIMELEFT = db.TOPICs.Where(a => a.TOPICID == currentTopicID).Select(x => x.TOTALTIME).FirstOrDefault();
                        newTest.DATEOFTEST = (DateTime)row[2];
                        newTest.TOPICID = currentTopicID;
                        newTest.PERSONALID = CurrentUserID;
                        newTest.COMPLETESTATUS = 0;

                        db.TESTs.InsertOnSubmit(newTest);
                        db.SubmitChanges();

                        //thêm vào result và process
                        var newResultOfTest = new RESULTOFTEST();
                        newResultOfTest.TESTID = newTestID;
                        newResultOfTest.TOTALCORRECT = 0;
                        newResultOfTest.TOTALINCORRECT = TongSoCauHoi;
                        newResultOfTest.SCORE = 0;
                        newResultOfTest.PASSSTATUS = "chưa rõ";

                        db.RESULTOFTESTs.InsertOnSubmit(newResultOfTest);
                        db.SubmitChanges();

                        foreach (var cauhoi in ListCauHoi)
                        {
                            var newProcess = new PROCESS();
                            newProcess.TESTID = newTestID;
                            newProcess.QUESTIONID = cauhoi.QUESTIONID.ToString();
                            newProcess.CHOICE = "";

                            db.PROCESSes.InsertOnSubmit(newProcess);
                            db.SubmitChanges();
                        }

                    }
                }
                return temp;
            }
        }

        private string GetNextTestID()
        {
            using (var db = new QLDTDataContext())
            {
                var theLastID = db.TESTs.Max(e => e.TESTID);
                if (theLastID == null)
                    return "T0001";
                string NextID = "T" + (int.Parse(theLastID.Substring(4, theLastID.Length - 4)) + 1).ToString("000#");
                return NextID;
            }
        }

        private void View_Add_StudentTrain(object sender, EventArgs e)
        {
            FormTeachAddTrain frmTrain = new FormTeachAddTrain(LoadAllDataGridView);
            frmTrain.ShowDialog();
            view.TrainData.DataSource = LoadTrain();
        }

        //EVENT
        private void View_Update(object sender, EventArgs e)
        {
            var curSelect = sender as List<string>;
            string CurrentUserID = curSelect[0];
            int Permission = int.Parse(curSelect[1]);
            FormSystemUpdateUser updateUser = new FormSystemUpdateUser(CurrentUserID, Permission, LoadAllDataGridView);
            updateUser.ShowDialog();
            view.data.DataSource = LoadAccount();
        }

        private void View_Export(object sender, EventArgs e)
        {

            Excel.Application xla = new Excel.Application();
            Excel.Workbook wb = xla.Workbooks.Add(Excel.XlSheetType.xlWorksheet);
            //object missing = System.Reflection.Missing.Value;

            //wb.SaveAs(@"D:\a.xlsx",
            //            Excel.XlFileFormat.xlOpenXMLWorkbook, missing, missing,
            //            false, false, Excel.XlSaveAsAccessMode.xlNoChange,
            //            missing, missing, missing, missing, missing);
            Excel.Worksheet ws = (Excel.Worksheet)xla.ActiveSheet;

            xla.Visible = false;
            xla.Cells[1, 1] = "PERSONALID";
            xla.Cells[1, 2] = "IDCLASS";
            xla.Cells[1, 3] = "FULLNAME";
            xla.Cells[1, 4] = "DATEOFBIRTH";
            xla.Cells[1, 5] = "ISPRO";
            xla.Cells[1, 6] = "GENDER";
            xla.Cells[1, 7] = "EMAIL";
            xla.Cells[1, 8] = "PASSWORD";
            xla.Cells[1, 9] = "USERLEVEL";
            xla.Cells[1, 10] = "ADR";
            xla.Cells[1, 11] = "SUBJECTID";

            //
            int row = 2;
            using (var db = new QLDTDataContext())
            {
                var students = from st in db.STUDENTs
                               join us in db.USERACCOUNTs on st.PERSONALID equals us.PERSONALID
                               select new { st, us.EMAIL, us.PASS, us.USERLEVEL };

                var teachers = from tc in db.TEACHERs
                               join us in db.USERACCOUNTs on tc.PERSONALID equals us.PERSONALID
                               select new { tc, us.EMAIL, us.PASS, us.USERLEVEL };

                var admins = from ad in db.ADMINISTRATORs
                             join us in db.USERACCOUNTs on ad.PERSONALID equals us.PERSONALID
                             select new { ad, us.EMAIL, us.PASS, us.USERLEVEL };


                foreach (var item in admins)
                {
                    xla.Cells[row, 1] = item.ad.PERSONALID.ToString(); ;
                    xla.Cells[row, 3] = item.ad.FULLNAME.ToString();

                    xla.Cells[row, 4] = DateTime.Parse(item.ad.DATEOFBIRTH.ToString()).ToString("MM/dd/yyyy");
                    xla.Cells[row, 6] = item.ad.GENDER.ToString();
                    xla.Cells[row, 7] = item.EMAIL.ToString();
                    xla.Cells[row, 8] = item.PASS.ToString();
                    xla.Cells[row, 9] = item.USERLEVEL;
                    xla.Cells[row, 10] = item.ad.ADR.ToString();

                    row++;
                }

                foreach (var item in teachers)
                {
                    xla.Cells[row, 1] = item.tc.PERSONALID.ToString();
                    xla.Cells[row, 2] = item.tc.CLASSID.ToString();
                    xla.Cells[row, 3] = item.tc.FULLNAME.ToString();
                    xla.Cells[row, 4] = DateTime.Parse(item.tc.DATEOFBIRTH.ToString()).ToString("MM/dd/yyyy");
                    xla.Cells[row, 6] = item.tc.GENDER.ToString();
                    xla.Cells[row, 7] = item.EMAIL.ToString();// EMAIL
                    xla.Cells[row, 8] = item.PASS.ToString();// PASSWORD
                    xla.Cells[row, 9] = item.USERLEVEL; //USERLEVEL
                    xla.Cells[row, 10] = item.tc.ADR.ToString();
                    xla.Cells[row, 11] = item.tc.SUBJECTID.ToString();//Subjec
                    row++;
                }


                foreach (var item in students)
                {
                    xla.Cells[row, 1] = item.st.PERSONALID.ToString();
                    xla.Cells[row, 2] = item.st.CLASSID.ToString();
                    xla.Cells[row, 3] = item.st.FULLNAME.ToString();
                    xla.Cells[row, 4] = DateTime.Parse(item.st.DATEOFBIRTH.ToString()).ToString("MM/dd/yyyy");
                    xla.Cells[row, 5] = item.st.ISPRO;
                    xla.Cells[row, 6] = item.st.GENDER.ToString();
                    xla.Cells[row, 7] = item.EMAIL.ToString();// EMAIL
                    xla.Cells[row, 8] = item.PASS.ToString();// PASSWORD
                    xla.Cells[row, 9] = item.USERLEVEL; //USERLEVEL
                    xla.Cells[row, 10] = item.st.ADR.ToString();

                    row++;
                }
            }

            xla.Columns.AutoFit();
            xla.Visible = true;
        }

        private void View_Add(object sender, EventArgs e)
        {
            FormSystemAddUser addUser = new FormSystemAddUser(LoadAllDataGridView);
            addUser.ShowDialog();
            view.data.DataSource = LoadAccount();
        }

        private void View_Delete(object sender, EventArgs e)
        {

            var curSelect = sender as List<string>;

            string CurrentUserID = curSelect[0];
            int Permission = int.Parse(curSelect[1]);



            DialogResult dialogDelete = MessageBox.Show("Bạn chắc chắn muốn xóa người dùng: " + CurrentUserID + " không?", "Xóa người dùng", MessageBoxButtons.YesNo);

            if (dialogDelete == DialogResult.Yes)
            {
                using (var db = new QLDTDataContext())
                {
                    if (Permission == 0)
                    {
                        try
                        {
                            DeleteAdmin(CurrentUserID);
                        }
                        catch (Exception)
                        {

                        }
                    }
                    if (Permission == 1)
                    {
                        try
                        {
                            DeleteTeacher(CurrentUserID);
                        }
                        catch (Exception)
                        {

                        }

                    }
                    if (Permission == 2 || Permission == 3)
                    {
                        DeleteStudent(CurrentUserID);
                        DeleteSchedule(CurrentUserID);
                        DeleteExamDetails(CurrentUserID);
                        DeleteQuestionStorge(CurrentUserID);
                        DeleteTrainingHistory(CurrentUserID);
                        DeleteTraining(CurrentUserID);

                        var TestID = db.TESTs.Where(t => t.PERSONALID == CurrentUserID).ToList();
                        if (TestID.Count > 0)
                        {
                            DeleteResultOfTest(TestID.FirstOrDefault().TESTID);
                            DeleteStatic(TestID.FirstOrDefault().TESTID);
                            DeleteTest(CurrentUserID);
                        }
                    }

                    if (DeleteUser(CurrentUserID))
                    {
                        MessageBox.Show("Xóa tài khoản: " + CurrentUserID + " thành công");
                    }
                    else
                    {
                        MessageBox.Show("Xóa tài khoản: " + CurrentUserID + " thất bại");
                    }

                    view.data.DataSource = LoadAccount();
                }

            }
        }

        bool DeleteQuestionStorge(string CurrentUserID)
        {
            using (var db = new QLDTDataContext())
            {
                var st = db.QUESTIONSSTORAGEs.Where(t => t.PERSONALID == CurrentUserID).ToList();
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
        bool checkReduplicateAdmin(DataRow item)
        {
            var ad = new ADMINISTRATOR();
            ad.FULLNAME = item["FULLNAME"].ToString();
            ad.GENDER = item["GENDER"].ToString();
            ad.DATEOFBIRTH = DateTime.Parse(item["DATEOFBIRTH"].ToString());
            ad.ADR = item["ADR"].ToString();

            string email = item["EMAIL"].ToString();
            string pass = item["PASSWORD"].ToString();

            using (var db = new QLDTDataContext())
            {
                var admin = (from a in db.ADMINISTRATORs
                             join us in db.USERACCOUNTs on a.PERSONALID equals us.PERSONALID
                             select new { a, us.EMAIL, us.PASS, us.USERLEVEL }).ToList();
                if (admin.Count > 0)
                {
                    foreach (var id in admin)
                    {
                        if (id.a.FULLNAME == ad.FULLNAME && id.EMAIL == email && id.a.DATEOFBIRTH == ad.DATEOFBIRTH)
                            return true;
                    }
                }
            }
            return false;
        }
        bool checkReduplicateTeacher(DataRow item)
        {
            var tc = new TEACHER();
            tc.FULLNAME = item["FULLNAME"].ToString();
            tc.CLASSID = item["IDCLASS"].ToString();
            tc.GENDER = item["GENDER"].ToString();
            tc.DATEOFBIRTH = DateTime.Parse(item["DATEOFBIRTH"].ToString());
            tc.ADR = item["ADR"].ToString();
            tc.SUBJECTID = item["SUBJECTID"].ToString();


            string email = item["EMAIL"].ToString();
            string pass = item["PASSWORD"].ToString();

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
        bool checkReduplicateStudent(DataRow item)
        {
            var st = new STUDENT();
            st.FULLNAME = item["FULLNAME"].ToString();
            st.CLASSID = item["IDCLASS"].ToString();
            st.GENDER = item["GENDER"].ToString();
            st.DATEOFBIRTH = DateTime.Parse(item["DATEOFBIRTH"].ToString());
            st.ISPRO = int.Parse(item["ISPRO"].ToString());
            st.ADR = item["ADR"].ToString();


            string email = item["EMAIL"].ToString();
            string pass = item["PASSWORD"].ToString();

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




        // Lấy ID tiếp theo tùy vào level
        private string GetNextPersonId(int Level)
        {
            string ID = "";
            using (var db = new QLDTDataContext())
            {
                var ListID = db.USERACCOUNTs.Where(u => u.USERLEVEL == Level).ToList();

                if (ListID.Count <= 0)
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
                    var NextID = ListID.OrderByDescending(od => od.PERSONALID).First();
                    ID = NextID.PERSONALID.ToString();

                    string temp = ID.Substring(0, 2); // cat 2 gia tri dau
                    int stt = int.Parse(ID.Substring(2, (ID.Count() - 2))) + 1; // lay cac gia tri con lai + 1;
                    ID = temp + stt.ToString("00#");
                }
            }
            return ID;
        }


        // Add from excel file
        bool AddUser(DataTable dt)
        {
            using (var db = new QLDTDataContext())
            {
                int st_count = 0;
                int tc_count = 0;
                int ad_count = 0;
                foreach (DataRow item in dt.Rows)
                {
                    int Permission = int.Parse(item["USERLEVEL"].ToString());
                    string ID = GetNextPersonId(Permission);


                    if (Permission == 0 && !checkReduplicateAdmin(item))
                    {
                        ad_count++;
                        Add_UserAccount(item, ID, Permission);
                        Add_Admin(item, ID);
                    }
                    else if (Permission == 1 && !checkReduplicateTeacher(item))
                    {
                        tc_count++;
                        Add_UserAccount(item, ID, Permission);
                        Add_Teacher(item, ID);
                    }
                    else if (Permission == 2 && !checkReduplicateStudent(item))
                    {
                        st_count++;
                        Add_UserAccount(item, ID, Permission);
                        Add_Student(item, ID);
                    }

                }
                MessageBox.Show("Đã thêm " + ad_count.ToString() + " admin");
                MessageBox.Show("Đã thêm " + st_count.ToString() + " student");
                MessageBox.Show("Đã thêm " + tc_count.ToString() + " teacher");
                return true;
            }


            return false;
        } // Tổng quan

        bool Add_UserAccount(DataRow item, string ID, int Permission)
        {
            using (var db = new QLDTDataContext())
            {
                var user = new USERACCOUNT();
                user.PERSONALID = ID;
                user.EMAIL = item["EMAIL"].ToString();
                user.PASS = item["PASSWORD"].ToString();
                user.USERLEVEL = Permission;


                db.USERACCOUNTs.InsertOnSubmit(user);
                db.SubmitChanges();

                return true;
            }
            return false;
        }

        bool Add_Admin(DataRow item, string ID)
        {
            using (var db = new QLDTDataContext())
            {
                var admin = new ADMINISTRATOR();
                admin.PERSONALID = ID;
                admin.FULLNAME = item["FULLNAME"].ToString();
                admin.GENDER = item["GENDER"].ToString();
                admin.DATEOFBIRTH = DateTime.Parse(item["DATEOFBIRTH"].ToString());
                admin.ADR = item["ADR"].ToString();
                admin.ADMINONLYKEY = "12312";

                db.ADMINISTRATORs.InsertOnSubmit(admin);
                db.SubmitChanges();

                return true;
            }
            return false;
        }

        bool Add_Teacher(DataRow item, string ID)
        {
            using (var db = new QLDTDataContext())
            {
                var tc = new TEACHER();
                tc.PERSONALID = ID;
                tc.FULLNAME = item["FULLNAME"].ToString();
                tc.CLASSID = item["IDCLASS"].ToString();
                tc.GENDER = item["GENDER"].ToString();
                tc.DATEOFBIRTH = DateTime.Parse(item["DATEOFBIRTH"].ToString());
                tc.ADR = item["ADR"].ToString();
                tc.SUBJECTID = item["SUBJECTID"].ToString();

                db.TEACHERs.InsertOnSubmit(tc);
                db.SubmitChanges();

                return true;
            }
            return false;
        }

        bool Add_Student(DataRow item, string ID)
        {
            using (var db = new QLDTDataContext())
            {
                var st = new STUDENT();
                st.PERSONALID = ID;
                st.FULLNAME = item["FULLNAME"].ToString();
                st.CLASSID = item["IDCLASS"].ToString();
                st.GENDER = item["GENDER"].ToString();
                st.DATEOFBIRTH = DateTime.Parse(item["DATEOFBIRTH"].ToString());
                st.ISPRO = int.Parse(item["ISPRO"].ToString());
                st.ADR = item["ADR"].ToString();

                db.STUDENTs.InsertOnSubmit(st);
                db.SubmitChanges();

                return true;
            }
            return false;
        }


        //IMPORT
        DataTable ReadExel()
        {
            DataTable dt = new DataTable();

            using (OpenFileDialog od = new OpenFileDialog() { Filter = "Excel files (*.xlsx;*.xls)|*.xlsx;*.xls|All files (*.*)|*.*", ValidateNames = true })
            {
                if (od.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = File.Open(od.FileName, FileMode.Open, FileAccess.Read);
                    IExcelDataReader reader = ExcelReaderFactory.CreateReader(fs);
                    DataSet ds = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    dt = ds.Tables[0];
                    reader.Close();
                }
                return dt;
            }
        }

        private void View_Import(object sender, EventArgs e)
        {
            var data = ReadExel();
            if (data.DataSet != null)
            {
                DialogResult dialog = MessageBox.Show("Bạn chắc chắn muốn thêm danh sách user từ file đã chọn?", "Import User", MessageBoxButtons.YesNo);

                if (dialog == DialogResult.Yes)
                {
                    if (AddUser(data))
                    {
                        MessageBox.Show("Import thành công");
                    }
                    view.data.DataSource = LoadAccount();
                }
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

        bool DeleteUser(string CurrentUserID)
        {
            using (var db = new QLDTDataContext())
            {
                var user = db.USERACCOUNTs.Where(u => u.PERSONALID == CurrentUserID).SingleOrDefault();
                db.USERACCOUNTs.DeleteOnSubmit(user);
                db.SubmitChanges();
                return true;
            }
            return false;
        }

        bool DeleteTrainingHistory(string CurrentUserID)
        {

            using (var db = new QLDTDataContext())
            {
                var HistoryID = db.TRAININGHISTORies.Where(t => t.PERSONALID == CurrentUserID).ToList();

                if (HistoryID.Count > 0)
                {
                    db.TRAININGHISTORies.DeleteAllOnSubmit(HistoryID);
                    db.SubmitChanges();
                }
                return true;

            }
            return false;
        }

        bool DeleteTraining(string CurrentUserID)
        {
            using (var db = new QLDTDataContext())
            {
                var trainID = db.TRAININGs.Where(t => t.PERSONALID == CurrentUserID).ToList();

                if (trainID.Count > 0)
                {
                    db.TRAININGs.DeleteAllOnSubmit(trainID);
                    db.SubmitChanges();
                }
                return true;

            }
            return false;
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

        private DataTable LoadAccount()
        {
            using (var db = new QLDTDataContext())
            {
                var UserList = db.USERACCOUNTs.Select(u => new { u.PERSONALID, u.EMAIL, u.PASS, u.USERLEVEL });

                return ConvertToDataTable(UserList);
            }
        }

    }
}
