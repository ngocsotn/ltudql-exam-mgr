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
    public class TopicPresenter
    {
        ITopicView topicview;
        string currTopicID = "";

        public TopicPresenter(ITopicView inputTopicView)
        {
            topicview = inputTopicView;
            Initializer();
        }
        public TopicPresenter(ITopicView inputTopicView, string inputTopicID)
        {
            topicview = inputTopicView;
            currTopicID = inputTopicID;
            Initializer();
        }

        private void Initializer()
        {

            topicview.TopicEvent_Add_Topic += Topicview_TopicEvent_Add_Topic;
            topicview.TopicEvent_SendToAdded += Topicview_TopicEvent_SendToAdded;
            topicview.TopicEvent_RemoveFromAdded += Topicview_TopicEvent_RemoveFromAdded;
            topicview.TopicEvent_Update_Topic += Topicview_TopicEvent_Update_Topic;
        }

        private void Topicview_TopicEvent_Update_Topic(object sender, EventArgs e)
        {
            if (IsTopicOK() == false)
            {
                MessageBox.Show("Bạn phải chọn ít nhất 10 câu hỏi cho bộ đề, không thể Cập nhật!");
                return;
            }
            try
            {
                using (var db = new QLDTDataContext())
                {
                    //cập nhật :thời gian cho topic, và các câu hỏi cho details
                    var curTopic = db.TOPICs.Where(ex => ex.TOPICID == currTopicID).SingleOrDefault();
                    curTopic.TOTALTIME = topicview.Time * 60;

                    // cập nhật các câu hỏi cho details theo cách hủy diệt: xóa sạch rồi insert lại where mã topic...
                    // xóa
                    var topicDT = db.TOPIC_DETAILs.Where(ed => ed.TOPICID == currTopicID).ToList();
                    if (topicDT.Count > 0)
                    {
                        db.TOPIC_DETAILs.DeleteAllOnSubmit(topicDT);
                        db.SubmitChanges();
                    }
                    //thêm lại
                    for (int i = 0; i < topicview.lb_QuestionAdded.Items.Count; i++)
                    {
                        var newTopicDetail = new TOPIC_DETAIL();

                        newTopicDetail.TOPICID = currTopicID;
                        newTopicDetail.QUESTIONID = (topicview.lb_QuestionAdded.Items[i] as dynamic).Value.ToString();
                        if (topicview.Note == "")
                        {
                            newTopicDetail.NOTES = " ";
                        }
                        else
                        {
                            newTopicDetail.NOTES = topicview.Note;
                        }

                        db.TOPIC_DETAILs.InsertOnSubmit(newTopicDetail);
                        db.SubmitChanges();
                    }
                }
                MessageBox.Show(string.Format("Cập nhật đề thi: {0} thành công", currTopicID));
            }
            catch (Exception)
            {

                MessageBox.Show("Cập nhật đề thi thất bại");
            }
        }

        private void Topicview_TopicEvent_RemoveFromAdded(object sender, EventArgs e)
        {
            if (topicview.lb_QuestionAdded.SelectedItem != null)
            {
                int curIndex = topicview.lb_QuestionAdded.SelectedIndex;
                topicview.lb_Question.DisplayMember = "Text";
                topicview.lb_Question.ValueMember = "Value";

                topicview.lb_Question.Items.Add(topicview.lb_QuestionAdded.SelectedItem);
                if (topicview.lb_QuestionAdded.SelectedIndex < topicview.lb_QuestionAdded.Items.Count - 1)
                    topicview.lb_QuestionAdded.SelectedIndex += 1;
                //xóa khỏi listbox cũ
                topicview.lb_QuestionAdded.Items.RemoveAt(curIndex);
            }
        }

        private void Topicview_TopicEvent_SendToAdded(object sender, EventArgs e)
        {
            if (topicview.lb_Question.SelectedItem != null)
            {
                int curIndex = topicview.lb_Question.SelectedIndex;
                topicview.lb_QuestionAdded.DisplayMember = "Text";
                topicview.lb_QuestionAdded.ValueMember = "Value";

                topicview.lb_QuestionAdded.Items.Add(topicview.lb_Question.SelectedItem);
                if (topicview.lb_Question.SelectedIndex < topicview.lb_Question.Items.Count - 1)
                    topicview.lb_Question.SelectedIndex += 1;
                //xóa khỏi listbox cũ
                topicview.lb_Question.Items.RemoveAt(curIndex);
            }
        }

        //hàm thêm vào DB
        private void Topicview_TopicEvent_Add_Topic(object sender, EventArgs e)
        {
            //MessageBox.Show(topicview.Subject + ',' + topicview.Grade +',' +topicview.Time+',' +topicview.lb_QuestionAdded.Items[0].ToString());
            if (IsTopicOK() == false)
            {
                MessageBox.Show("Bạn phải chọn ít nhất 10 câu hỏi cho bộ đề mới, không thể thêm!");
                return;
            }
            try
            {
                string NewTopicID = GetNextTopicID();
                //thêm vào topic
                using (var db = new QLDTDataContext())
                {
                    var newTopic = new TOPIC();

                    newTopic.TOPICID = NewTopicID;
                    newTopic.SUBJECTID = topicview.Subject;
                    newTopic.GRADEID = topicview.Grade;
                    newTopic.TOTALTIME = topicview.Time * 60; //trong DB là giây

                    db.TOPICs.InsertOnSubmit(newTopic);
                    db.SubmitChanges();


                    //thêm vào topic Details
                    for (int i = 0; i < topicview.lb_QuestionAdded.Items.Count; i++)
                    {
                        var newTopicDetail = new TOPIC_DETAIL();

                        newTopicDetail.TOPICID = NewTopicID;
                        newTopicDetail.QUESTIONID = (topicview.lb_QuestionAdded.Items[i] as dynamic).Value.ToString();
                        if (topicview.Note == "")
                        {
                            newTopicDetail.NOTES = " ";
                        }
                        else
                        {
                            newTopicDetail.NOTES = topicview.Note;
                        }

                        db.TOPIC_DETAILs.InsertOnSubmit(newTopicDetail);
                        db.SubmitChanges();
                    }
                    MessageBox.Show(string.Format("Thêm đề thi: {0} thành công", NewTopicID));
                }

            }
            catch (Exception)
            {

                MessageBox.Show("Thêm đề thi thất bại");
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

        private bool IsTopicOK()
        {
            //ít nhất 10 câu hỏi cho 1 đề
            if (topicview.lb_QuestionAdded == null || topicview.lb_QuestionAdded.Items.Count <= 9)
            {
                return false;
            }
            return true;
        }

        private string GetNextTopicID()
        {
            using (var db = new QLDTDataContext())
            {
                var lastExamID = db.TOPICs.Max(e => e.TOPICID);
                if (lastExamID == null)
                    return "TP001";
                string NextID = "TP" + (int.Parse(lastExamID.Substring(4, lastExamID.Length - 4)) + 1).ToString("00#");
                return NextID;
            }
        }
    }
}
