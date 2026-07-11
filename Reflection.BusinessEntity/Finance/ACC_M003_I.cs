using System.Collections.Generic;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003_I : ObjectBase
    {

       
       
        private string _trns_key_code;
        public string trns_key_code
        {
            get { return _trns_key_code; }
            set { _trns_key_code = value; RaisePropertyChanged("trns_key_code"); }
        }

        private string _dr_key;
        public string dr_key
        {
            get { return _dr_key; }
            set { _dr_key = value; RaisePropertyChanged("dr_key"); }
        }

        private string _cr_key;
        public string cr_key
        {
            get { return _cr_key; }
            set { _cr_key = value; RaisePropertyChanged("cr_key"); }
        }

        private string _sp_gl_ind;
        public string sp_gl_ind
        {
            get { return _sp_gl_ind; }
            set { _sp_gl_ind = value; RaisePropertyChanged("sp_gl_ind"); }
        }

        private string _posting_desc_D;
        public string posting_desc_D
        {
            get { return _posting_desc_D; }
            set { _posting_desc_D = value; RaisePropertyChanged("posting_desc_D"); }
        }

        private string _posting_desc_C;
        public string posting_desc_C
        {
            get { return _posting_desc_C; }
            set { _posting_desc_C = value; RaisePropertyChanged("posting_desc_C"); }
        }
    }
    public class MultipleContext_ACC_M003_I
    {
        public List<ACC_M003_I> MasterEntityList { get; set; }
        public List<ACC_M003_I> PostingKey { get; set; }
        public List<ACC_M003_Q_P> PostingKeyMaster { get; set; }
    }
}
