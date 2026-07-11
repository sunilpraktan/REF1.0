using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Finance
{
    public class ACC_M003_Z : ObjectBase
    {
        

        private string _trans_scope;
        public string trans_scope
        {
            get { return _trans_scope; }
            set { _trans_scope = value; RaisePropertyChanged("trans_scope"); }
        }

        private string _con_type;
        public string con_type
        {
            get { return _con_type; }
            set { _con_type = value; RaisePropertyChanged("con_type"); }
        }

        private string _coa_key;
        public string coa_key
        {
            get { return _coa_key; }
            set { _coa_key = value; RaisePropertyChanged("coa_key"); }
        }

        private string _pg_code;
        public string pg_code
        {
            get { return _pg_code; }
            set { _pg_code = value; RaisePropertyChanged("pg_code"); }
        }

        private string _po_code;
        public string po_code
        {
            get { return _po_code; }
            set { _po_code = value; RaisePropertyChanged("po_code"); }
        }

        private string _party_acc_group;
        public string party_acc_group
        {
            get { return _party_acc_group; }
            set { _party_acc_group = value; RaisePropertyChanged("party_acc_group"); }
        }

        private string _item_acc_group;
        public string item_acc_group
        {
            get { return _item_acc_group; }
            set { _item_acc_group = value; RaisePropertyChanged("item_acc_group"); }
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
            set { _gl_code_d = value; RaisePropertyChanged("gl_code_d"); }
        }

        private string _gl_code_c;
        public string gl_code_c
        {
            get { return _gl_code_c; }
            set { _gl_code_c = value; RaisePropertyChanged("gl_code_c"); }
        }

        private string _item_cat;
        public string item_cat
        {
            get { return _item_cat; }
            set { _item_cat = value; RaisePropertyChanged("item_cat"); }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set { _doc_cat = value; RaisePropertyChanged("doc_cat"); }
        }

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set { _doc_type = value; RaisePropertyChanged("doc_type"); }
        }

        private string _key_code;
        public string key_code
        {
            get { return _key_code; }
            set { _key_code = value; RaisePropertyChanged("key_code"); }
        }

        private string _key_sequence;
        public string key_sequence
        {
            get { return _key_sequence; }
            set { _key_sequence = value; RaisePropertyChanged("key_sequence"); }
        }

        private int _line_id;
        public int line_id
        {
            get { return _line_id; }
            set { _line_id = value; RaisePropertyChanged("line_id"); }
        }

        private bool _active;
        public bool active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }
        }

        //Scalar
        private bool _Click;
        public bool Click
        {
            get
            {
                return _Click;
            }
            set
            {
                _Click = value;
                RaisePropertyChanged("Click");
            }
        }
    }
    public class MultipleContext_ACC_M003_Z
    {
        public ObservableCollection<ACC_M003_Z> PurchaseList { get; set; }
        public List<ACC_M003_J_P> ApplicationList { get; set; }
        public List<ACC_M003_S1_P> ConTypeList { get; set; }
        public List<ACC_M003_D_P> COAKeyList { get; set; }
        public List<ADM_M001_P_P> PGCodeList { get; set; }
        public List<ADM_M001_M_P> POCodeList { get; set; }
        public List<ACC_M003_H_P> PartyAccGroupList { get; set; }
        public List<ACC_M003_H_P> ItemAccGroupList { get; set; }
        public List<ACC_M003_E_P> TransKeyCodeList { get; set; }
        public List<ACC_M003_P> DebitGLCodeList { get; set; }
        public List<ACC_M003_P> CreditGLCodeList { get; set; }
        public List<SYS_M003_P> ItemCatList { get; set; }
        public List<SYS_M001_P> DocCatList { get; set; }
        public List<SYS_M002_P> DocTypeList { get; set; }
    }
}
