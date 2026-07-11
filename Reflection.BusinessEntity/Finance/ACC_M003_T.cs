using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003_T : ObjectBase //Account Determination Entity Class
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _trns_key_code;
        public string trns_key_code
        {
            get { return _trns_key_code; }
            set { _trns_key_code = value; RaisePropertyChanged("trns_key_code"); }
        }


        private string _gl_code_d;
        public string gl_code_d
        {
            get { return _gl_code_d; }
            set { _gl_code_d = value; RaisePropertyChanged("gl_code_d", ModelEntityUpdated); }
        }

        private string _gl_code_c;
        public string gl_code_c
        {
            get { return _gl_code_c; }
            set { _gl_code_c = value; RaisePropertyChanged("gl_code_c", ModelEntityUpdated); }
        }

        private string _coa_key;
        public string coa_key
        {
            get { return _coa_key; }
            set { _coa_key = value; RaisePropertyChanged("coa_key"); }
        }

        private string _value_group;
        public string value_group
        {
            get { return _value_group; }
            set { _value_group = value; RaisePropertyChanged("value_group", ModelEntityUpdated); }
        }

        private string _acc_var; 
        public string acc_var
        {
            get { return _acc_var; }
            set { _acc_var = value; RaisePropertyChanged("acc_var", ModelEntityUpdated); }
        }


        private string _value_class;
        public string value_class
        {
            get { return _value_class; }
            set { _value_class = value; RaisePropertyChanged("value_class", ModelEntityUpdated); }
        }

        

        private string _tax_code;
        public string tax_code
        {
            get { return _tax_code; }
            set { _tax_code = value; RaisePropertyChanged("tax_code"); }
        }

        private string _buss_place;
        public string buss_place
        {
            get { return _buss_place; }
            set { _buss_place = value; RaisePropertyChanged("buss_place"); }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }
        //Scalar

        public string TranCode { get; set; }

        private string _doc_desc;
        public string doc_desc
        {
            get { return _doc_desc; }
            set { _doc_desc = value; RaisePropertyChanged("doc_desc"); }
        }

        private string _group_desc;
        public string group_desc
        {
            get { return _group_desc; }
            set { _group_desc = value; RaisePropertyChanged("group_desc"); }
        }

        private string _gl_desc_d;
        public string gl_desc_d
        {
            get { return _gl_desc_d; }
            set { _gl_desc_d = value; RaisePropertyChanged("gl_desc_d"); }
        }

        private string _gl_desc_c;
        public string gl_desc_c
        {
            get { return _gl_desc_c; }
            set { _gl_desc_c = value; RaisePropertyChanged("gl_desc_c"); }
        }

        private bool _Click;
        public bool Click
        {
            get { return _Click; }
            set {_Click = value; RaisePropertyChanged("Click"); }
        }

        private string _tax_code_desc;
        public string tax_code_desc
        {
            get { return _tax_code_desc; }
            set { _tax_code_desc = value; RaisePropertyChanged("tax_code_desc"); }
        }

        private string _buss_Place_desc;
        public string buss_Place_desc
        {
            get { return _buss_Place_desc; }
            set { _buss_Place_desc = value; RaisePropertyChanged("buss_Place_desc"); }
        }


        private string _Tempcoa_key;
        public string Tempcoa_key
        {
            get { return _Tempcoa_key; }
            set { _Tempcoa_key = value; RaisePropertyChanged("Tempcoa_key"); }
        }
        
        public string XmlDataDocument_ACC_M003_T { get; set; }

    }
    public class MultipleContext_ACC_M003_T
    {
        public List<ACC_M003_T> postingDetreminationDataList { get; set; }
        public ObservableCollection<ACC_M003_T> DetailEntityList { get; set; }
        public List<ACC_M003_P> GLCodeDebitList { get; set; }
        public List<ACC_M003_P> GLCodeCreditList { get; set; }
        public List<ACC_M026_P> COA_KeyList { get; set; }
        public List<ACC_M003_V> ValueClassList { get; set; }
        public List<ACC_M003_F> PostingKeyRulesList { get; set; }
        public List<ACC_M003_T> GL_CodeList { get; set; }
        public List<ACC_M003_H> AccountGroupList { get; set; }
        public List<ACC_M003_G> ValueGroupList { get; set; }
        public List<ACC_M013_P> TaxCodeList { get; set; }
       // public List<ACC_M003_R_P> BussPlaceList { get; set; }
        public List<ADM_M003_C_P> BussPlaceList { get; set; }
    }
}
