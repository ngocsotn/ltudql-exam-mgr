using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UI.Models;

namespace UI.Views
{
    public partial class FormUserTrainResult : Form
    {
        public FormUserTrainResult()
        {
            InitializeComponent();
        }
        string CurTopic;
        public FormUserTrainResult(string TopicID)
        {
            CurTopic = TopicID;
            InitializeComponent();
            Load += FormUserTrainResult_Load;
        }

        private void FormUserTrainResult_Load(object sender, EventArgs e)
        {
            using (var db = new QLDTDataContext())
            {
                var questions = from td in db.TOPIC_DETAILs
                                join q in db.QUESTIONs on td.QUESTIONID equals q.QUESTIONID
                                where td.TOPICID == CurTopic
                                select new { q.CONTENTOFQUESTION, q.CORRECTANSWER, q.HINT };
                
                if(questions != null)
                {
                    dataGridViewTrainAvailablePicker.DataSource = ConvertToDataTable(questions);
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
    }
}
