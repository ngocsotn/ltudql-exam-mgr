using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI.Views
{
    public interface IMainView
    {

        StudentInfo StudentData { get; set; }
        //dùng để in bảng điểm kèm thông tin học sinh
        event EventHandler MainEvent_PrintToPDF_StudentInformation;

        DataGridView DTG_Topic_Main { get; set; }
        DataGridView DTG_Question_Main { get; set; }
        DataGridView data { get; set; } //tabpage Quan trị
        DataGridView TrainData { get; set; } //tabpage GiaoVien
        DataGridView KiThi { get; set; }//tabpage GiaoVien
        DataGridView StudentTraining { get; set; } //luyện thi
        DataGridView DTG_List_Of_Tests_Main { get; set; } //thi thật/thi thử
        DataGridView DTG_LichThi_Va_ketQua { get; set; }
        string SystemConnectionString { get; set; }
        string DBName { get; }

        /// <summary>
        /// Main
        /// </summary>
        event EventHandler Delete;
        event EventHandler Import;
        event EventHandler Add;
        event EventHandler Export;
        event EventHandler UpdateAccount;
        event EventHandler Check_Connection;
        event EventHandler Save_Connection;
        event EventHandler BackupDB;
        event EventHandler RestoreDB;


        /// <summary>
        /// Train
        /// </summary>
        event EventHandler Add_StudentTrain;
        event EventHandler Update_StudentTrain;
        event EventHandler Delete_StudentTrain;

        //Kì thi
        event EventHandler Add_Exams;
        event EventHandler Update_Exams;
        event EventHandler Delete_Exams;
        event EventHandler PrintToPDF_Exams;

        //Luyện thi
        event EventHandler Training;

        //các event của Giáo viên- quản lý câu hỏi dựa trên form main
        event EventHandler MainEvent_Add_Question;
        event EventHandler MainEvent_Update_Question;
        event EventHandler MainEvent_Delete_Question;
        event EventHandler MainEvent_Import_Question;
        event EventHandler MainEvent_Export_Question;

        //các event của giáo viên-quản lý đề thi bên form main
        event EventHandler MainEvent_Add_Topic;
        event EventHandler MainEvent_Update_Topic;
        event EventHandler MainEvent_Delete_Topic;

        //event của thi
        event EventHandler MainEvent_BeginTheTest;
    }
}
