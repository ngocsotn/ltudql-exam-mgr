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
    public class QuestionPresenter
    {
        IQuestionView questionView;
        string curQuestionID = "";

        public QuestionPresenter(IQuestionView inputView)
        {
            questionView = inputView;
            Initializer();
        }
        public QuestionPresenter(IQuestionView inputView, string inputQuestionID)
        {
            questionView = inputView;
            curQuestionID = inputQuestionID;
            Initializer();
        }

        private void Initializer()
        {
            questionView.QuestionEvent_Add_Question += QuestionView_QuestionEvent_Add_Question;
            questionView.QuestionEvent_Update_Question += QuestionView_QuestionEvent_Update_Question;
            questionView.QuestionEvent_Load_Question += QuestionView_QuestionEvent_Load_Question;
        }

        private void QuestionView_QuestionEvent_Load_Question(object sender, EventArgs e)
        {
            LoadTheQuestion();
        }

        private void QuestionView_QuestionEvent_Update_Question(object sender, EventArgs e)
        {
            if (!IsQuestionOK())
            {
                MessageBox.Show("Không thể Cập nhật, Phải có ít nhất 4 câu trả lời ABCD, ít nhất 1 đáp án và phải có nội dung!");
                return;
            }
            try
            {

                string NewQuestionID = curQuestionID;
                using (var db = new QLDTDataContext())
                {
                    //xóa ra
                    var QuestionDelete = db.QUESTIONs.Where(i => i.QUESTIONID == curQuestionID).FirstOrDefault();
                    if (QuestionDelete != null)
                    {
                        db.QUESTIONs.DeleteOnSubmit(QuestionDelete);
                        db.SubmitChanges();
                    }
                    //thêm lại


                    var newQuestion = new QUESTION();
                    newQuestion.QUESTIONID = NewQuestionID;
                    newQuestion.CONTENTOFQUESTION = questionView.Question_Content;
                    newQuestion.A = questionView.A;
                    newQuestion.B = questionView.B;
                    newQuestion.C = questionView.C;
                    newQuestion.D = questionView.D;
                    newQuestion.E = questionView.E;
                    newQuestion.F = questionView.F;
                    newQuestion.DIFFICULT = questionView.Difficult;
                    newQuestion.HINT = questionView.hint;
                    newQuestion.ISPRO = 0;
                    if (questionView.IsPro)
                    {
                        newQuestion.ISPRO = 1;
                    }
                    newQuestion.GRADEID = questionView.Grade;
                    newQuestion.SUBJECTID = questionView.Subject;
                    newQuestion.CORRECTANSWER = GetNewAnswerString();
                    db.QUESTIONs.InsertOnSubmit(newQuestion);
                    db.SubmitChanges();


                    MessageBox.Show(string.Format("Cập nhật câu hỏi: {0} thành công", NewQuestionID));
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Cập nhật câu hỏi thất bại");
            }
        }

        private void QuestionView_QuestionEvent_Add_Question(object sender, EventArgs e)
        {
            if (!IsQuestionOK())
            {
                MessageBox.Show("Không thể thêm, Phải có ít nhất 4 câu trả lời ABCD, ít nhất 1 đáp án và phải có nội dung!");
                return;
            }
            try
            {
                string NewQuestionID = GetNextQuestionID();
                using (var db = new QLDTDataContext())
                {
                    var newQuestion = new QUESTION();
                    newQuestion.QUESTIONID = NewQuestionID;
                    newQuestion.CONTENTOFQUESTION = questionView.Question_Content;
                    newQuestion.A = questionView.A;
                    newQuestion.B = questionView.B;
                    newQuestion.C = questionView.C;
                    newQuestion.D = questionView.D;
                    newQuestion.E = questionView.E;
                    newQuestion.F = questionView.F;
                    newQuestion.DIFFICULT = questionView.Difficult;
                    newQuestion.HINT = questionView.hint;
                    newQuestion.ISPRO = 0;
                    if (questionView.IsPro)
                    {
                        newQuestion.ISPRO = 1;
                    }
                    newQuestion.GRADEID = questionView.Grade;
                    newQuestion.SUBJECTID = questionView.Subject;
                    newQuestion.CORRECTANSWER = GetNewAnswerString();
                    db.QUESTIONs.InsertOnSubmit(newQuestion);
                    db.SubmitChanges();


                    MessageBox.Show(string.Format("Thêm câu hỏi: {0} thành công", NewQuestionID));
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Thêm câu hỏi thất bại");
            }
        }

        private void LoadTheQuestion()
        {
            using (var db = new QLDTDataContext())
            {
                var currentQuestion = db.QUESTIONs.Where(i => i.QUESTIONID == curQuestionID).FirstOrDefault();
                LoadComboBoxAndCheckBox(currentQuestion);
                LoadAllContent(currentQuestion);
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

        private string GetNewAnswerString()
        {
            string Answer = "";
            bool IsFirst = true;
            if (questionView.IsAnswerA)
            {
                Answer += "A";
                IsFirst = false;
            }
            if (questionView.IsAnswerB)
            {
                if (!IsFirst)
                {
                    Answer += ",";
                }
                Answer += "B";
                IsFirst = false;
            }
            if (questionView.IsAnswerC)
            {
                if (!IsFirst)
                {
                    Answer += ",";
                }
                Answer += "C";
                IsFirst = false;
            }
            if (questionView.IsAnswerD)
            {
                if (!IsFirst)
                {
                    Answer += ",";
                }
                Answer += "D";
                IsFirst = false;
            }
            if (questionView.IsAnswerE)
            {
                if (!IsFirst)
                {
                    Answer += ",";
                }
                Answer += "E";
                IsFirst = false;
            }
            if (questionView.IsAnswerF)
            {
                if (!IsFirst)
                {
                    Answer += ",";
                }
                Answer += "F";
                IsFirst = false;
            }
            return Answer;
        }

        private void SetAnswerFollowingString(string AnswerString)
        {
            if (AnswerString.Contains("A"))
            {
                questionView.IsAnswerA = true;
            }
            if (AnswerString.Contains("B"))
            {
                questionView.IsAnswerB = true;
            }
            if (AnswerString.Contains("C"))
            {
                questionView.IsAnswerC = true;
            }
            if (AnswerString.Contains("D"))
            {
                questionView.IsAnswerD = true;
            }
            if (AnswerString.Contains("E"))
            {
                questionView.IsAnswerE = true;
            }
            if (AnswerString.Contains("F"))
            {
                questionView.IsAnswerF = true;
            }

        }

        private bool CheckAtLeastOneAnswer()
        {
            if (questionView.IsAnswerA == true)
                return true;
            else if (questionView.IsAnswerB == true)
                return true;
            else if (questionView.IsAnswerC == true)
                return true;
            else if (questionView.IsAnswerD == true)
                return true;
            else if (questionView.IsAnswerE == true)
                return true;
            else if (questionView.IsAnswerF == true)
                return true;
            return false;
        }

        private bool IsQuestionOK()
        {
            //ít nhất 10 câu hỏi cho 1 đề
            if (questionView.A.Length < 1 || questionView.B.Length < 1 || questionView.C.Length < 1 || questionView.D.Length < 1
                || questionView.Question_Content.Length < 10 || CheckAtLeastOneAnswer() == false)
            {
                return false;
            }
            return true;
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

        private void LoadComboBoxAndCheckBox(QUESTION inputQuestion)
        {
            //các đáp án
            SetAnswerFollowingString(inputQuestion.CORRECTANSWER);
            //ispro
            questionView.IsPro = false;
            if (inputQuestion.ISPRO == 1)
            {
                questionView.IsPro = true;
            }
            //các comboBox khác
            questionView.Grade = inputQuestion.GRADEID;
            questionView.Subject = inputQuestion.SUBJECTID;
            questionView.Difficult = inputQuestion.DIFFICULT;
        }
        private void LoadAllContent(QUESTION inputQuestion)
        {
            questionView.Question_Content = inputQuestion.CONTENTOFQUESTION;
            questionView.A = inputQuestion.A;
            questionView.B = inputQuestion.B;
            questionView.C = inputQuestion.C;
            questionView.D = inputQuestion.D;
            questionView.E = inputQuestion.E;
            questionView.F = inputQuestion.F;
            questionView.hint = inputQuestion.HINT;
        }
    }
}
