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
    public class TrainPresenter
    {
        ITrainView trainView;
        string CurTrainID;
        string CurPersonID;

        //Khởi tạo này dành cho form add
        public TrainPresenter(ITrainView view)
        {
            trainView = view;
            Initialize();
        }
        private void Initialize()
        {
            //tạo xử lí sự kiện add
            trainView.Add_Train += TrainView_Add_Train;
        }
        //Khời tạo này dành cho form update
        public TrainPresenter(ITrainView view, string TrainID, string PersonID)
        {

            trainView = view;
            CurTrainID = TrainID;
            CurPersonID = PersonID;
            UpdateInitializer();
        }

        private void UpdateInitializer()
        {
            //Load dữ liệu lên form update (ko cần dùng sự kiện Load maybe có thể xóa)
            using (var db = new QLDTDataContext())
            {

                trainView.HocSinhID = CurPersonID;
                var TrainInfo = db.TRAININGHISTORies.Where(t => t.TRAININGID == CurTrainID && t.TRAININGID == CurTrainID).SingleOrDefault();

                if (TrainInfo != null)
                {
                    trainView.HocSinhID = TrainInfo.PERSONALID;
                    trainView.BoDe = TrainInfo.TOPICID;
                    trainView.HanChot = DateTime.Parse(TrainInfo.TRAININGDATE.ToString());
                }
            }


            //xử lí sự kiện update
            trainView.Update_Train += TrainView_Update_Train;

        }

        //Xử lí update
        private void TrainView_Update_Train(object sender, EventArgs e)
        {
            try
            {
                using (var db = new QLDTDataContext())
                {

                    // Delete
                    var curHistory = db.TRAININGHISTORies.Where(t => t.TRAININGID == CurTrainID && t.PERSONALID == CurPersonID).SingleOrDefault();

                    if(curHistory != null )
                    {
                        db.TRAININGHISTORies.DeleteOnSubmit(curHistory);
                        db.SubmitChanges();

                    }
                

                    //Update Training
                    var curTrain = db.TRAININGs.Where(tr => tr.TRAININGID == CurTrainID).SingleOrDefault();
                    curTrain.PERSONALID = trainView.HocSinhID;
                    db.SubmitChanges();

                    //Add Train history
                    var NewHistory = new TRAININGHISTORY();
                    NewHistory.TRAININGID = CurTrainID;
                    NewHistory.PERSONALID = trainView.HocSinhID;
                    NewHistory.TRAININGDATE = trainView.HanChot;
                    NewHistory.TOPICID = trainView.BoDe;
                    NewHistory.RESULT = "0";
                    NewHistory.OVERALLPROPERBILITY = 0;
                    NewHistory.TOTALCORRECT = 0;
                    NewHistory.TOTALINCORRECT = 0;

                    db.TRAININGHISTORies.InsertOnSubmit(NewHistory);
                    db.SubmitChanges();

                    MessageBox.Show(string.Format("Cập nhật thành công trainID:{0} thành công", CurTrainID));

                }
            }
            catch (Exception)
            {

                MessageBox.Show(string.Format("Cập nhật thành công trainID:{0} Thất bại", CurTrainID));
            }

        }

       

        private void TrainView_Add_Train(object sender, EventArgs e)
        {
            try
            {
                using (var db = new QLDTDataContext())
                {
                    var TrainID = GetNextTrainID();

                    var train = new TRAINING();
                    train.TRAININGID = TrainID;
                    train.PERSONALID = trainView.HocSinhID;

                    db.TRAININGs.InsertOnSubmit(train);
                    db.SubmitChanges();


                    var trainHistory = new TRAININGHISTORY();
                    trainHistory.TRAININGID = TrainID;
                    trainHistory.PERSONALID = trainView.HocSinhID;
                    trainHistory.TOPICID = trainView.BoDe;
                    trainHistory.TRAININGDATE = trainView.HanChot;
                    trainHistory.RESULT = "Chưa rõ";
                    trainHistory.OVERALLPROPERBILITY = 0;
                    trainHistory.TOTALCORRECT = 0;
                    trainHistory.TOTALINCORRECT = 0;



                    db.TRAININGHISTORies.InsertOnSubmit(trainHistory);
                    db.SubmitChanges();

                    MessageBox.Show("Thêm thành công trainID:{0}", TrainID);

                }
            }
            catch (Exception)
            {

                MessageBox.Show("Thêm kì thi thất bại");
            }

        }

        private string GetNextTrainID()
        {
            using (var db = new QLDTDataContext())
            {
                var LastTrainID = db.TRAININGs.Max(tr => tr.TRAININGID);


                if (LastTrainID == null)
                    return "TR001";

                var NextTrainID = LastTrainID.Substring(0, 2) + (int.Parse(LastTrainID.Substring(2, LastTrainID.Count() - 2)) + 1).ToString("00#");

                return NextTrainID;
            }
        }

        private DataTable ConvertToDataTable<TSource>(IEnumerable<TSource> source)
        {
            var props = typeof(TSource).GetProperties();

            var dt_mynewtable = new DataTable();
            dt_mynewtable.Columns.AddRange(
              props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray()
            );

            source.ToList().ForEach(
              i => dt_mynewtable.Rows.Add(props.Select(p => p.GetValue(i, null)).ToArray())
            );

            return dt_mynewtable;
        }
    }
}
