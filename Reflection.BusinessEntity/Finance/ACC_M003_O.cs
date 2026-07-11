using System.Collections.Generic;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003_O : ObjectBase //Condition Type Master
    { 
        private string _con_type;
        public string con_type
        {
            get { return _con_type; }
            set { _con_type = value; RaisePropertyChanged("con_type"); }
        }

        private string _con_desc;
        public string con_desc
        {
            get { return _con_desc; }
            set { _con_desc = value; RaisePropertyChanged("con_desc"); }
        }

        private string _con_cat;
        public string con_cat
        {
            get { return _con_cat; }
            set { _con_cat = value; RaisePropertyChanged("con_cat"); }
        }

        private string _pricing_pro;
        public string pricing_pro
        {
            get { return _pricing_pro; }
            set { _pricing_pro = value; RaisePropertyChanged("pricing_pro"); }
        }

        public string XmlDataDocument_ACC_M003_O_FLIP { get; set; }
    }
    public class MultipleContext_ACC_M003_O
    {
        public List<ACC_M003_O> MasterEntity { get; set; }
        public List<ACC_M003_O> FlipGridData { get; set; }
        public List<COM_T003> Attachment { get; set; }
    }
}
