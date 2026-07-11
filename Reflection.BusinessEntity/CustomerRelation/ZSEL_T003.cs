using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.CustomerRelation
{
    public class ZSEL_T003 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private string _sr_no;
        public string sr_no
        {
            get { return _sr_no; }
            set
            {
                if (_sr_no != value)
                {
                    _sr_no = value; RaisePropertyChanged("sr_no");
                }
            }
        }

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }

        private string _party_id;
        public string party_id
        {
            get { return _party_id; }
            set
            {
                if (_party_id != value)
                {
                    _party_id = value; RaisePropertyChanged("party_id");
                }
            }
        }

        private string _cust_name;
        public string cust_name
        {
            get { return _cust_name; }
            set
            {
                if (_cust_name != value)
                {
                    _cust_name = value; RaisePropertyChanged("cust_name");
                }
            }
        }

        private string _cust_id;
        public string cust_id
        {
            get { return _cust_id; }
            set
            {
                if (_cust_id != value)
                {
                    _cust_id = value; RaisePropertyChanged("cust_id");
                }
            }
        }

        private string _invoice_no;
        public string invoice_no
        {
            get { return _invoice_no; }
            set
            {
                if (_invoice_no != value)
                {
                    _invoice_no = value; RaisePropertyChanged("invoice_no");
                }
            }
        }

        private Nullable<System.DateTime> _date;
        public Nullable<System.DateTime> date
        {
            get { return _date; }
            set
            {
                if (_date != value)
                {
                    _date = value; RaisePropertyChanged("date");
                }
            }
        }

        private Nullable<decimal> _amount;
        public Nullable<decimal> amount
        {
            get { return _amount; }
            set
            {
                if (_amount != value)
                {
                    _amount = value; RaisePropertyChanged("amount", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _taxable_value;
        public Nullable<decimal> taxable_value
        {
            get { return _taxable_value; }
            set
            {
                if (_taxable_value != value)
                {
                    _taxable_value = value; RaisePropertyChanged("taxable_value", ModelEntityUpdated);
                }
            }
        }

        private string _gst_no;
        public string gst_no
        {
            get { return _gst_no; }
            set
            {
                if (_gst_no != value)
                {
                    _gst_no = value; RaisePropertyChanged("gst_no", ModelEntityUpdated);
                }
            }
        }

        private string _gst;
        public string gst
        {
            get { return _gst; }
            set
            {
                if (_gst != value)
                {
                    _gst = value; RaisePropertyChanged("gst", ModelEntityUpdated);
                }
            }
        }

        private string _cgst;
        public string cgst
        {
            get { return _cgst; }
            set
            {
                if (_cgst != value)
                {
                    _cgst = value; RaisePropertyChanged("cgst");
                }
            }
        }

        private string _sgst;
        public string sgst
        {
            get { return _sgst; }
            set
            {
                if (_sgst != value)
                {
                    _sgst = value; RaisePropertyChanged("sgst");
                }
            }
        }

        private string _igst;
        public string igst
        {
            get { return _igst; }
            set
            {
                if (_igst != value)
                {
                    _igst = value; RaisePropertyChanged("igst");
                }
            }
        }

        private Nullable<decimal> _gst_p;
        public Nullable<decimal> gst_p
        {
            get { return _gst_p; }
            set
            {
                if (_gst_p != value)
                {
                    _gst_p = value; RaisePropertyChanged("gst_p", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _cgst_p;
        public Nullable<decimal> cgst_p
        {
            get { return _cgst_p; }
            set
            {
                if (_cgst_p != value)
                {
                    _cgst_p = value; RaisePropertyChanged("cgst_p");
                }
            }
        }

        private Nullable<decimal> _sgst_p;
        public Nullable<decimal> sgst_p
        {
            get { return _sgst_p; }
            set
            {
                if (_sgst_p != value)
                {
                    _sgst_p = value; RaisePropertyChanged("sgst_p");
                }
            }
        }

        private Nullable<decimal> _igst_p;
        public Nullable<decimal> igst_p
        {
            get { return _igst_p; }
            set
            {
                if (_igst_p != value)
                {
                    _igst_p = value; RaisePropertyChanged("igst_p");
                }
            }
        }

        private Nullable<decimal> _gst_amt;
        public Nullable<decimal> gst_amt
        {
            get { return _gst_amt; }
            set
            {
                if (_gst_amt != value)
                {
                    _gst_amt = value; RaisePropertyChanged("gst_amt", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _cgst_amt;
        public Nullable<decimal> cgst_amt
        {
            get { return _cgst_amt; }
            set
            {
                if (_cgst_amt != value)
                {
                    _cgst_amt = value; RaisePropertyChanged("cgst_amt");
                }
            }
        }

        private Nullable<decimal> _sgst_amt;
        public Nullable<decimal> sgst_amt
        {
            get { return _sgst_amt; }
            set
            {
                if (_sgst_amt != value)
                {
                    _sgst_amt = value; RaisePropertyChanged("sgst_amt");
                }
            }
        }

        private Nullable<decimal> _igst_amt;
        public Nullable<decimal> igst_amt
        {
            get { return _igst_amt; }
            set
            {
                if (_igst_amt != value)
                {
                    _igst_amt = value; RaisePropertyChanged("igst_amt");
                }
            }
        }

        private string _hsn_code;
        public string hsn_code
        {
            get { return _hsn_code; }
            set
            {
                if (_hsn_code != value)
                {
                    _hsn_code = value; RaisePropertyChanged("hsn_code");
                }
            }
        }

        private string _buss_place;
        public string buss_place
        {
            get { return _buss_place; }
            set
            {
                if (_buss_place != value)
                {
                    _buss_place = value; RaisePropertyChanged("buss_place");
                }
            }
        }

        private string _supply_type;
        public string supply_type
        {
            get { return _supply_type; }
            set
            {
                if (_supply_type != value)
                {
                    _supply_type = value; RaisePropertyChanged("supply_type");
                }
            }
        }

        private string _invoice_type;
        public string invoice_type
        {
            get { return _invoice_type; }
            set
            {
                if (_invoice_type != value)
                {
                    _invoice_type = value; RaisePropertyChanged("invoice_type");
                }
            }
        }

        private string _rev_charge;
        public string rev_charge
        {
            get { return _rev_charge; }
            set
            {
                if (_rev_charge != value)
                {
                    _rev_charge = value; RaisePropertyChanged("rev_charge");
                }
            }
        }

        private string _e_comm;
        public string e_comm
        {
            get { return _e_comm; }
            set
            {
                if (_e_comm != value)
                {
                    _e_comm = value; RaisePropertyChanged("e_comm");
                }
            }
        }

        private string _section;
        public string section
        {
            get { return _section; }
            set
            {
                if (_section != value)
                {
                    _section = value; RaisePropertyChanged("section");
                }
            }
        }

        private Nullable<decimal> _cess_amt;
        public Nullable<decimal> cess_amt
        {
            get { return _cess_amt; }
            set
            {
                if (_cess_amt != value)
                {
                    _cess_amt = value; RaisePropertyChanged("cess_amt");
                }
            }
        }

        private Nullable<decimal> _qty;
        public Nullable<decimal> qty
        {
            get { return _qty; }
            set
            {
                if (_qty != value)
                {
                    _qty = value; RaisePropertyChanged("qty", ModelEntityUpdated);
                }
            }
        }

        private Nullable<decimal> _rate;
        public Nullable<decimal> rate
        {
            get { return _rate; }
            set
            {
                if (_rate != value)
                {
                    _rate = value; RaisePropertyChanged("rate", ModelEntityUpdated);
                }
            }
        }

        private string _item;
        public string item
        {
            get { return _item; }
            set
            {
                if (_item != value)
                {
                    _item = value; RaisePropertyChanged("item");
                }
            }
        }

        private Nullable<bool> _gst_no_ind;
        public Nullable<bool> gst_no_ind
        {
            get { return _gst_no_ind; }
            set
            {
                if (_gst_no_ind != value)
                {
                    _gst_no_ind = value; RaisePropertyChanged("gst_no_ind");
                }
            }
        }

        private string _remark;
        public string remark
        {
            get { return _remark; }
            set
            {
                if (_remark != value)
                {
                    _remark = value; RaisePropertyChanged("remark");
                }
            }
        }

        #region Default Fields
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                if (_t_status != value)
                {
                    _t_status = value;
                    RaisePropertyChanged("t_status");
                }
            }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                if (_add_by != value)
                {
                    _add_by = value;
                    RaisePropertyChanged("add_by");
                }
            }
        }

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value;
                    RaisePropertyChanged("add_date");
                }
            }
        }

        private string _edit_by;
        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                if (_edit_by != value)
                {
                    _edit_by = value; RaisePropertyChanged("edit_by");
                }
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date");
                }
            }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value;
                    RaisePropertyChanged("location_Id");
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
                    _comp_code = value;
                    RaisePropertyChanged("comp_code");
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
                    _lang_key = value;
                    RaisePropertyChanged("lang_key");
                }
            }
        }
        
        #endregion        

        //scalar
        private string _party_name;
        public string party_name
        {
            get { return _party_name; }
            set
            {
                if (_party_name != value)
                {
                    _party_name = value; RaisePropertyChanged("party_name");
                }
            }
        }

        private Nullable<System.DateTime> _from_dt;
        public Nullable<System.DateTime> from_dt
        {
            get { return _from_dt; }
            set
            {
                if (_from_dt != value)
                {
                    _from_dt = value; RaisePropertyChanged("from_dt");
                }
            }
        }

        private Nullable<System.DateTime> _to_dt;
        public Nullable<System.DateTime> to_dt
        {
            get { return _to_dt; }
            set
            {
                if (_to_dt != value)
                {
                    _to_dt = value; RaisePropertyChanged("to_dt");
                }
            }
        }

        private string _plc_name;
        public string plc_name
        {
            get { return _plc_name; }
            set
            {
                if (_plc_name != value)
                {
                    _plc_name = value; RaisePropertyChanged("plc_name");
                }
            }
        }

        private Nullable<decimal> _total_gst_amt;
        public Nullable<decimal> total_gst_amt
        {
            get { return _total_gst_amt; }
            set
            {
                if (_total_gst_amt != value)
                {
                    _total_gst_amt = value; RaisePropertyChanged("total_gst_amt", ModelEntityUpdated);
                }
            }
        }

        //XML doc 
        public string XmlDataDocument_ZSEL_T003 { get; set; }
        public string XmlDataDocument_ZSEL_T003_Flip { get; set; }
    }
    public class MultipleContext_ZSEL_T003
    {
        public List<ZSEL_T003_BackFlip> BackFlipEntity { get; set; }
        public List<ZSEL_T003> MasterData { get; set; }
        public ObservableCollection<ZSEL_T003> DetailData { get; set; }
        public List<ADM_M028_P> Party { get; set; }
        public List<ZSEL_T003_P> CustomerName { get; set; }
        public List<ZSEL_T003_P> PartyForFilter { get; set; }        
        public List<ZSEL_T003_A_P> HSNCode { get; set; }
        public List<ADM_M003_C_P> BussPlace { get; set; }
    }
    public class ZSEL_T003_BackFlip
    {
        public string sr_no { get; set; }
        public int id { get; set; }
        public string party_id { get; set; }
        public string cust_name { get; set; }
        public string cust_id { get; set; }
        public string invoice_no { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public Nullable<decimal> amount { get; set; }
        public Nullable<decimal> taxable_value { get; set; }
        public string gst_no { get; set; }
        public string gst { get; set; }
        public string cgst { get; set; }
        public string sgst { get; set; }
        public string igst { get; set; }
        public Nullable<decimal> gst_p { get; set; }
        public Nullable<decimal> cgst_p { get; set; }
        public Nullable<decimal> sgst_p { get; set; }
        public Nullable<decimal> igst_p { get; set; }
        public Nullable<decimal> gst_amt { get; set; }
        public Nullable<decimal> cgst_amt { get; set; }
        public Nullable<decimal> sgst_amt { get; set; }
        public Nullable<decimal> igst_amt { get; set; }
        public string hsn_code { get; set; }
        public string buss_place { get; set; }
        public string supply_type { get; set; }
        public string invoice_type { get; set; }
        public string rev_charge { get; set; }
        public string e_comm { get; set; }
        public string section { get; set; }
        public Nullable<decimal> cess_amt { get; set; }
        public string remark { get; set; }

        //Scalar
        public string party_name { get; set; }
    }
}
