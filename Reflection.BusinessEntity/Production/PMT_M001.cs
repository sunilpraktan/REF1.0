using System.Collections.Generic;

namespace Reflection.BusinessEntity.Production
{
    public class PMT_M001 : ObjectBase
    {
        private string _bdr_code;
        public string bdr_code
        {
            get
            {
                return _bdr_code;
            }

            set
            {
                _bdr_code = value; RaisePropertyChanged("bdr_code");
            }
        }

        private string _bdr_desc;
        public string bdr_desc
        {
            get
            {
                return _bdr_desc;
            }

            set
            {
                _bdr_desc = value; RaisePropertyChanged("bdr_desc");
            }
        }
        private string _comp_code { get; set; }
        public string comp_code
        {
            get { return _comp_code;}

            set { _comp_code = value; RaisePropertyChanged("comp_code");}
        }
        
        public string XmlDataDocument_PMT_M001_FLIP { get; set; }
    }

    public class MultipleContext_PMT_M001
    {
        public List<PMT_M001> MasterEntity { get; set; }
        public List<PMT_M001> FlipGridData { get; set; }
    }
}
