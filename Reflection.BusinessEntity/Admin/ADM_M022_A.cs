using System.Collections.Generic;

namespace Reflection.BusinessEntity.Admin
{
    public class ADM_M022_A:ObjectBase
    {
        private string _hs_code;
        public string hs_code
        {
            get { return _hs_code; }

            set
            {
                if (_hs_code != value)
                {
                    _hs_code = value; RaisePropertyChanged("hs_code");
                }
            }
        }

        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }

            set
            {
                if (_ItemCode != value)
                {
                    _ItemCode = value; RaisePropertyChanged("ItemCode");
                }
            }
        }

        private string _country_code;
        public string country_code
        {
            get { return _country_code; }

            set
            {
                if (_country_code != value)
                {
                    _country_code = value; RaisePropertyChanged("country_code");
                }
            }
        }
        public string _hsn_group_code { get; set; }
        public string hsn_group_code
        {
            get { return _hsn_group_code; }

            set
            {
                if (_hsn_group_code != value)
                {
                    _hsn_group_code = value; RaisePropertyChanged("hsn_group_code");
                }
            }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");
                }
            }
        }
        
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                if (_lang_key != value)
                {
                    _lang_key = value; RaisePropertyChanged("lang_key");
                }
            }
        }

        //scalar

        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }

            set
            {
                if (_ItemName != value)
                {
                    _ItemName = value; RaisePropertyChanged("ItemName");
                }
            }
        }

        private string _country_Name;
        public string country_Name
        {
            get { return _country_Name; }

            set
            {
                if (_country_Name != value)
                {
                    _country_Name = value; RaisePropertyChanged("country_Name");
                }
            }
        }

        public string XmlDataDocument_FlipGrid { get; set; }
    }

    public class MultipleContext_ADM_M022_A
    {
        public List<ADM_M022_A> MasterList { get; set; }
        public List<ADM_M022_A> FlipGridData { get; set; }
        public List<ADM_M022_P> ItemCodeList { get; set; }
        public List<ADM_M012_P> CountryCodeList { get; set; }
        public List<ADM_M020_P> HSNGroup { get; set; }
    }
}
