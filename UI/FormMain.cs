using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Windows.Forms;
using UI.Presenters;
using UI.Views;

namespace UI
{
    public partial class FormMain : MaterialForm, IMainView
    {
        MainPresenter main;
        private readonly MaterialSkinManager materialSkinManager;
        string curID;
        int curLevel;

        public event EventHandler Delete;
        public event EventHandler Import;
        public event EventHandler Add;
        public event EventHandler Export;
        public event EventHandler UpdateAccount;
        public event EventHandler Add_StudentTrain;
        public event EventHandler Add_Exams;
        public event EventHandler Update_StudentTrain;
        public event EventHandler Update_Exams;
        public event EventHandler Delete_Exams;
        public event EventHandler Delete_StudentTrain;
        public event EventHandler Check_Connection;
        public event EventHandler Save_Connection;
        public event EventHandler BackupDB;
        public event EventHandler RestoreDB;


        //phần câu hỏi
        public event EventHandler MainEvent_Add_Question;
        public event EventHandler MainEvent_Update_Question;
        public event EventHandler MainEvent_Delete_Question;
        public event EventHandler MainEvent_Import_Question;
        public event EventHandler MainEvent_Export_Question;

        //phần đề thi
        public event EventHandler MainEvent_Add_Topic;
        public event EventHandler MainEvent_Update_Topic;
        public event EventHandler MainEvent_Delete_Topic;

        //luyện thi
        public event EventHandler Training;

        //thi
        public event EventHandler MainEvent_BeginTheTest;
        public event EventHandler PrintToPDF_Exams;

        //in bảng điểm và thông tin cá nhân
        public event EventHandler MainEvent_PrintToPDF_StudentInformation;

        //datagridview hiển thị bên form main có hình thức get set để sử dụng sau này
        public DataGridView DTG_Topic_Main
        {
            get => dataGridViewQuestionKitList;
            set => dataGridViewQuestionKitList = value;
        }


        public DataGridView DTG_Question_Main
        {
            get => dataGridViewQuestionList;
            set => dataGridViewQuestionList = value;
        }

        public DataGridView data
        {
            get => dataGridViewSystemQLNguoiDung;

            set
            {
                dataGridViewSystemQLNguoiDung.DataSource = value;
            }
        }

        public DataGridView TrainData
        {
            get => dataGridViewMockExamList;
            set => dataGridViewMockExamList.DataSource = value;
        }
        public DataGridView KiThi { get => dataGridViewExamList; set => dataGridViewExamList.DataSource = value; }

        //bảng dataGridView của lịch thi để thi
        public DataGridView DTG_List_Of_Tests_Main
        {
            get => dataGridViewExamAvailablePicker;
            set => dataGridViewExamAvailablePicker = value;
        }

        //bảng của học sinh, dùng để xem lịch thi/kết quả
        public DataGridView DTG_LichThi_Va_ketQua
        {
            get => dataGridViewUserExamInfo;
            set => dataGridViewUserExamInfo = value;
        }

        public StudentInfo StudentData
        {
            get
            {
                StudentData = new StudentInfo();
                StudentData.FullName = textBoxUserInfoFullname.Text;
                StudentData.Email = textBoxUserInfoEmail.Text;
                StudentData.Gender = textBoxUserInfoGender.Text;
                StudentData.DayOfBirth = DateTime.Parse(textBoxUserInfoDateofBirth.Text);
                StudentData.Address = textBoxUserInfoAddress.Text;
                StudentData.ClassID = textBoxUserInfoClass.Text;

                return StudentData;
            }
            set
            {

                textBoxUserInfoFullname.Text = value.FullName;
                textBoxUserInfoEmail.Text = value.Email;
                textBoxUserInfoGender.Text = value.Gender;
                textBoxUserInfoDateofBirth.Text = value.DayOfBirth.ToString("MM/dd/yyyy");
                textBoxUserInfoAddress.Text = value.Address;
                textBoxUserInfoClass.Text = value.ClassID;
            }
        }

        public string SystemConnectionString
        {
            get { return textBoxSystemConnectionString.Text; }
            set { textBoxSystemConnectionString.Text = value; }
        }

        public string DBName
        {
            get { return ConfigurationManager.AppSettings["dbName"]; }
        }

        public delegate void SetOnAGain();

        public void SetTabTrainAndDoExamOn()
        {
            //bật lại "nút X tắt form"
            this.ControlBox = true;
            foreach (Control x in tabPageStudentTrain.Controls)
            {
                x.Enabled = true;
                x.Visible = true;
            }
            foreach (Control x in tabPageStudentExam.Controls)
            {
                x.Enabled = true;
                x.Visible = true;
            }
        }

        public DataGridView StudentTraining { get => dataGridViewTrainAvailablePicker; set => dataGridViewTrainAvailablePicker.DataSource = value; }

        public FormMain()
        {
            InitializeComponent();

            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);

            Load += FormMain_Load;

        }
        public FormMain(string ID, int Level)
        {


            curID = ID;
            curLevel = Level;

            InitializeComponent();

            // Initialize MaterialSkinManager
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);

            Load += FormMain_Load_ByPermission; //Load

            if (Level == 0)
            {
                materialTabControlQuanTri.TabPages.Remove(tabPageHocSinh);
                materialTabControlQuanTri.TabPages.Remove(tabPageGiaoVien);
            }
            else if (Level == 1)
            {
                materialTabControlQuanTri.TabPages.Remove(tabPageQuanTri);
            }
            else if (Level == 2)
            {
                materialTabControlQuanTri.TabPages.Remove(tabPageGiaoVien);
                materialTabControlQuanTri.TabPages.Remove(tabPageQuanTri);
            }
            else if (Level == 3)
            {
                materialTabControlQuanTri.TabPages.Remove(tabPageGiaoVien);
                materialTabControlQuanTri.TabPages.Remove(tabPageQuanTri);


                // remove tabcontrol
                materialTabControlHocSinhMenu.Controls.Remove(tabPageStudentExam);
                materialTabControlHocSinhMenu.Controls.Remove(tabPageStudentTrain);
            }

        }

        private void FormMain_Load_ByPermission(object sender, EventArgs e)
        {
            main = new MainPresenter(this, curID, curLevel);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            main = new MainPresenter(this);
        }

        private void buttonSystemExport_Click(object sender, EventArgs e)
        {
            Export?.Invoke(this, null);
        }

        private void buttonSystemImport_Click(object sender, EventArgs e)
        {
            Import?.Invoke(this, null);
        }

        private void buttonSystemInsert_Click(object sender, EventArgs e)
        {
            Add?.Invoke(this, null);
        }

        private void buttonSystemUpdate_Click(object sender, EventArgs e)
        {
            List<string> curSelect = new List<string>();
            var curId = dataGridViewSystemQLNguoiDung.SelectedRows[0].Cells["PERSONALID"].Value.ToString();
            var curLevel = dataGridViewSystemQLNguoiDung.SelectedRows[0].Cells["USERLEVEL"].Value.ToString();

            curSelect.Add(curId);
            curSelect.Add(curLevel.ToString());
            UpdateAccount?.Invoke(curSelect, null);
        }

        private void buttonSystemDelete_Click(object sender, EventArgs e)
        {
            //TODO
            List<string> curSelect = new List<string>();
            var curId = dataGridViewSystemQLNguoiDung.SelectedRows[0].Cells["PERSONALID"].Value.ToString();
            var curLevel = dataGridViewSystemQLNguoiDung.SelectedRows[0].Cells["USERLEVEL"].Value.ToString();

            curSelect.Add(curId);
            curSelect.Add(curLevel.ToString());

            Delete?.Invoke(curSelect, null);
        }

        private void buttonTeachAddExam_Click(object sender, EventArgs e)
        {
            Add_Exams?.Invoke(this, null);
        }

        private void buttonTeachAddMockExam_Click(object sender, EventArgs e)
        {
            Add_StudentTrain?.Invoke(this, null);
        }

        private void buttonUpdateMockExam_Click(object sender, EventArgs e)
        {

            if (dataGridViewMockExamList.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn 1 đối tượng ở datagridview để cập nhật");
            }
            else
            {
                var curID = dataGridViewMockExamList.SelectedRows[0].Cells["TRAININGID"].Value.ToString();
                var PersonalID = dataGridViewMockExamList.SelectedRows[0].Cells["PERSONALID"].Value.ToString();

                List<string> curSelect = new List<string>();
                curSelect.Add(curID);
                curSelect.Add(PersonalID);


                Update_StudentTrain?.Invoke(curSelect, null);
            }

        }

        private void buttonTeachUpdateExam_Click(object sender, EventArgs e)
        {
            if (dataGridViewExamList.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn 1 đối tượng ở datagridview để cập nhật");
            }
            else
            {
                var curSelect = dataGridViewExamList.SelectedRows[0].Cells["EXAMID"].Value.ToString();
                var curStatus = int.Parse(dataGridViewExamList.SelectedRows[0].Cells["STATUSOFEXAM"].Value.ToString());
                if (curStatus == 1)
                {
                    MessageBox.Show("Kì thì đã diễn ra hoặc đã hoàn tất, không thể sửa đổi!");
                }
                else
                {
                    Update_Exams?.Invoke(curSelect, null);
                }

            }
        }

        private void buttonTeachDeleteExam_Click(object sender, EventArgs e)
        {
            var curExamId = dataGridViewExamList.SelectedRows[0].Cells["EXAMID"].Value.ToString();
            var curStatus = int.Parse(dataGridViewExamList.SelectedRows[0].Cells["STATUSOFEXAM"].Value.ToString());

            if (curStatus == 1)
            {
                MessageBox.Show("Kì thì đã diễn ra hoặc đã hoàn tất, Không thể xóa!");
            }
            else
            {
                Delete_Exams?.Invoke(curExamId, null);
            }
        }

        private void buttonTeachDeleteMockExam_Click(object sender, EventArgs e)
        {
            var curID = dataGridViewMockExamList.SelectedRows[0].Cells["TRAININGID"].Value.ToString();
            var PersonalID = dataGridViewMockExamList.SelectedRows[0].Cells["PERSONALID"].Value.ToString();

            List<string> curSelect = new List<string>();
            curSelect.Add(curID);
            curSelect.Add(PersonalID);
            Delete_StudentTrain?.Invoke(curSelect, null);

        }

        private void buttonSystemConnectionStringTest_Click(object sender, EventArgs e)
        {
            Check_Connection?.Invoke(SystemConnectionString, null);
        }

        private void buttonSystemConnectionStringSave_Click(object sender, EventArgs e)
        {
            Save_Connection?.Invoke(SystemConnectionString, null);
        }

        private void buttonTeachAddQuestionKit_Click(object sender, EventArgs e)
        {
            MainEvent_Add_Topic?.Invoke(this, null);
        }

        private void buttonTeachUpdateQuestionKit_Click(object sender, EventArgs e)
        {
            if (dataGridViewQuestionKitList.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn 1 đối tượng ở datagridview để cập nhật!");
            }
            else
            {
                //lấy ra Topic-ID, truyền vào presenter
                var curID = dataGridViewQuestionKitList.SelectedRows[0].Cells["TOPICID"].Value.ToString();
                MainEvent_Update_Topic?.Invoke(curID, null);
            }
        }

        private void buttonTeachDeleteQuestionKit_Click(object sender, EventArgs e)
        {
            if (dataGridViewQuestionKitList.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn 1 đối tượng ở datagridview để Xóa!");
            }
            else
            {
                //lấy ra Topic-ID, truyền vào presenter
                var curID = dataGridViewQuestionKitList.SelectedRows[0].Cells["TOPICID"].Value.ToString();
                MainEvent_Delete_Topic?.Invoke(curID, null);
            }
        }

        private void buttonTeachExportQuestion_Click(object sender, EventArgs e)
        {
            MainEvent_Export_Question?.Invoke(this, null);
        }

        private void buttonTeachImportQuestion_Click(object sender, EventArgs e)
        {
            MainEvent_Import_Question?.Invoke(this, null);
        }

        private void buttonTeachDeleteQuestion_Click(object sender, EventArgs e)
        {
            if (dataGridViewQuestionList.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn 1 đối tượng ở datagridview để Xóa!");
            }
            else
            {
                //lấy ra câu hỏi-ID, truyền vào presenter
                var curQuestionID = dataGridViewQuestionList.SelectedRows[0].Cells["QUESTIONID"].Value.ToString();
                MainEvent_Delete_Question?.Invoke(curQuestionID, null);
            }
        }

        private void buttonTeachUpdateQuestion_Click(object sender, EventArgs e)
        {
            if (dataGridViewQuestionList.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn 1 đối tượng ở datagridview để cập nhật!");
            }
            else
            {
                //lấy ra câu hỏi-ID, truyền vào presenter
                var curQuestionID = dataGridViewQuestionList.SelectedRows[0].Cells["QUESTIONID"].Value.ToString();
                MainEvent_Update_Question?.Invoke(curQuestionID, null);
            }
        }

        private void buttonTeachAddQuestion_Click(object sender, EventArgs e)
        {
            MainEvent_Add_Question?.Invoke(this, null);
        }

        private void buttonTeachUpdateExam_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewExamList.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn 1 đối tượng ở datagridview để cập nhật");
            }
            else
            {
                var curSelect = dataGridViewExamList.SelectedRows[0].Cells["EXAMID"].Value.ToString();
                Update_Exams?.Invoke(curSelect, null);
            }
        }

        private void buttonUpdateMockExam_Click_1(object sender, EventArgs e)
        {
            if (dataGridViewMockExamList.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn 1 đối tượng ở datagridview để cập nhật");
            }
            else
            {
                var curID = dataGridViewMockExamList.SelectedRows[0].Cells["TRAININGID"].Value.ToString();
                var PersonalID = dataGridViewMockExamList.SelectedRows[0].Cells["PERSONALID"].Value.ToString();

                List<string> curSelect = new List<string>();
                curSelect.Add(curID);
                curSelect.Add(PersonalID);


                Update_StudentTrain?.Invoke(curSelect, null);
            }
        }

        private void buttonTeachDeleteExam_Click_1(object sender, EventArgs e)
        {
            var curExamId = dataGridViewExamList.SelectedRows[0].Cells["EXAMID"].Value.ToString();
            Delete_Exams?.Invoke(curExamId, null);
        }

        private void buttonTeachDeleteMockExam_Click_1(object sender, EventArgs e)
        {
            var curID = dataGridViewMockExamList.SelectedRows[0].Cells["TRAININGID"].Value.ToString();
            var PersonalID = dataGridViewMockExamList.SelectedRows[0].Cells["PERSONALID"].Value.ToString();

            List<string> curSelect = new List<string>();
            curSelect.Add(curID);
            curSelect.Add(PersonalID);
            Delete_StudentTrain?.Invoke(curSelect, null);
        }

        private void buttonTeachAddMockExam_Click_1(object sender, EventArgs e)
        {
            Add_StudentTrain?.Invoke(this, null);
        }

        //khi bấm nút bắt đầu thi
        private void buttonStudentExamBegin_Click(object sender, EventArgs e)
        {
            if (dataGridViewExamAvailablePicker.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn 1 đối tượng ở datagridview để bắt đầu thi");
                return;
            }
            //Ví dụ làm bài thi =======================================================================================

            //Check Time
            var TrainDate = dataGridViewExamAvailablePicker.SelectedRows[0].Cells["DATEOFEXAM"].Value.ToString();
            var CurSelectTime = DateTime.Parse(TrainDate).ToShortDateString();
            var TimeNow = DateTime.Now.ToShortDateString();
            if (DateTime.Compare(DateTime.Parse(CurSelectTime), DateTime.Parse(TimeNow)) > -1)
            {
                string StudentID = dataGridViewExamAvailablePicker.SelectedRows[0].Cells["PERSONALID"].Value.ToString();
                string TopicID = dataGridViewExamAvailablePicker.SelectedRows[0].Cells["TOPICID"].Value.ToString();

                UserControlExamProgress examProgress = new UserControlExamProgress(StudentID, TopicID, SetTabTrainAndDoExamOn, main.LoadAllDataGridView);
                tabPageStudentExam.Controls.Add(examProgress);
                examProgress.Location = new System.Drawing.Point(0, 0);
                examProgress.Size = new System.Drawing.Size(tabPageStudentExam.Width, tabPageStudentExam.Height);
                examProgress.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right);
                //Bring to front trong trường hợp bị che khuất
                examProgress.BringToFront();
                MainEvent_BeginTheTest?.Invoke(this, null);
                //Xoá control
                //tabPageStudentExam.Controls.Remove(examProgress);
                //=========================================================================================================
                foreach (Control x in tabPageStudentTrain.Controls)
                {
                    x.Enabled = false;
                    x.Visible = false;
                    this.ControlBox = false;
                }
            }
            else
            {
                MessageBox.Show("Kỳ thi này đã hết hạn");
            }
        }

        private void buttonStudentTrainBegin_Click(object sender, EventArgs e)
        {
            //Ví dụ làm bài luyện thi =======================================================================================


            //Check Time
            var TrainDate = dataGridViewTrainAvailablePicker.SelectedRows[0].Cells["TRAININGDATE"].Value.ToString();
            var CurSelectTime = DateTime.Parse(TrainDate).ToShortDateString();
            var TimeNow = DateTime.Now.ToShortDateString();

            if (DateTime.Compare(DateTime.Parse(CurSelectTime), DateTime.Parse(TimeNow)) > -1)
            {

                var TrainID = dataGridViewTrainAvailablePicker.SelectedRows[0].Cells["TRAININGID"].Value.ToString();
                var StudentID = dataGridViewTrainAvailablePicker.SelectedRows[0].Cells["PERSONALID"].Value.ToString();
                var TopicID = dataGridViewTrainAvailablePicker.SelectedRows[0].Cells["TOPICID"].Value.ToString();


                UserControlExamProgress trainProgress = new UserControlExamProgress(true, TrainID, StudentID, TopicID, SetTabTrainAndDoExamOn, main.LoadAllDataGridView);
                tabPageStudentTrain.Controls.Add(trainProgress);
                trainProgress.Location = new System.Drawing.Point(0, 0);
                trainProgress.Size = new System.Drawing.Size(tabPageStudentExam.Width, tabPageStudentExam.Height);
                trainProgress.Anchor = (AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Bottom | AnchorStyles.Right);
                //Bring to front trong trường hợp bị che khuất
                trainProgress.BringToFront();
                //Xoá control
                //tabPageStudentExam.Controls.Remove(examProgress);
                //=========================================================================================================
                Training?.Invoke(this, null);
                foreach (Control x in tabPageStudentExam.Controls)
                {
                    x.Enabled = false;
                    x.Visible = false;
                }
            }
            else
            {
                MessageBox.Show("Đã hết hạn luyện thi");
            }
        }

        private void buttonStudentTrainViewResult_Click(object sender, EventArgs e)
        {
            var TopicID = dataGridViewTrainAvailablePicker.SelectedRows[0].Cells["TOPICID"].Value.ToString();

            //Ví dụ==================================================
            FormUserTrainResult trainResult = new FormUserTrainResult(TopicID);
            trainResult.ShowDialog();
            //=======================================================
        }

        private void buttonStudentInfoUpdate_Click(object sender, EventArgs e)
        {
            ///cập nhật thông tin học sinh ở đây
        }

        private void buttonTeachPrintResults_Click(object sender, EventArgs e)
        {

            if (dataGridViewExamList.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Vui lòng chọn 1 đối tượng ở datagridview để in!");
            }
            else
            {
                var curSelect = dataGridViewExamList.SelectedRows[0].Cells["EXAMID"].Value.ToString();
                var curStatus = int.Parse(dataGridViewExamList.SelectedRows[0].Cells["STATUSOFEXAM"].Value.ToString());
                if (curStatus == 1)
                    PrintToPDF_Exams?.Invoke(curSelect, null);
                else
                    MessageBox.Show("Dữ liệu rỗng!");
            }
        }

        private void buttonStudentInfoPrint_Click(object sender, EventArgs e)
        {
            MainEvent_PrintToPDF_StudentInformation?.Invoke(curID, null);
        }

        private void buttonSystemBackup_Click(object sender, EventArgs e)
        {
            BackupDB?.Invoke(this, null);
        }

        private void buttonSystemRestore_Click(object sender, EventArgs e)
        {
            RestoreDB?.Invoke(this, null);
        }
    }
}
