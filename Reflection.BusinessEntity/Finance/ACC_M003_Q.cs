using System.Collections.Generic;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003_Q : ObjectBase
    {
        

        private string _posting_key;
        public string posting_key
        {
            get { return _posting_key; }
            set { _posting_key = value; RaisePropertyChanged("posting_key"); }
        }

        private string _posting_type;
        public string posting_type
        {
            get { return _posting_type; }
            set { _posting_type = value; RaisePropertyChanged("posting_type"); }
        }

        private string _posting_desc;
        public string posting_desc
        {
            get { return _posting_desc; }
            set { _posting_desc = value; RaisePropertyChanged("posting_desc"); }
        }

        private string _post_desc2;
        public string post_desc2
        {
            get { return _post_desc2; }
            set { _post_desc2 = value; RaisePropertyChanged("post_desc2"); }
        }

        private string _ind_decr;
        public string ind_decr
        {
            get { return _ind_decr; }
            set { _ind_decr = value; RaisePropertyChanged("ind_decr"); }
        }

        private string _acc_type;
        public string acc_type
        {
            get { return _acc_type; }
            set { _acc_type = value; RaisePropertyChanged("acc_type"); }
        }

        public string XmlDataDocument_ACC_M003_Q_FLIP { get; set; }       
        
    }

    public class MultipleContext_ACC_M003_Q
    {
        public List<ACC_M003_Q> MasterEntity { get; set; }
        public List<ACC_M003_Q> FlipGridData { get; set; }
        public List<COM_T003> Attachment { get; set; }
    }
}
