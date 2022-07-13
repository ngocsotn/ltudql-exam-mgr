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

    public class DoIngTest_TrainView_Presenter
    {
        public IDoingTest_TrainView doing;
        string CurSelectTrainID;
        string CurSelectPersonalID;
        string CurSelectTopicID;
        public DoIngTest_TrainView_Presenter(IDoingTest_TrainView view, string trainID, string personID, string topicID)
        {
            CurSelectTrainID = trainID;
            CurSelectPersonalID = personID;
            CurSelectTopicID = topicID;


            doing = view;
            Initialize();
        }

        private void Initialize()
        {
            using (var db = new QLDTDataContext())
            {
                MessageBox.Show(CurSelectTrainID);
                MessageBox.Show(CurSelectPersonalID);
                MessageBox.Show(CurSelectTopicID);
             
                //var 
            }
        }
    }
}
