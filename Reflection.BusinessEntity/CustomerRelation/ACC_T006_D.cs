using System;

namespace Reflection.BusinessEntity
{
    public class ACC_T006_D : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id", ModelEntityUpdated);
                }
            }
        }
        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                if (_doc_no != value)

                {
                    _doc_no = value; RaisePropertyChanged("doc_no", ModelEntityUpdated);
                }
            }
        }
        private string _bill_entry_no;
        public string bill_entry_no
        {
            get { return _bill_entry_no; }
            set
            {
                if (_bill_entry_no != value)

                {
                    _bill_entry_no = value; RaisePropertyChanged("bill_entry_no", ModelEntityUpdated);
                }
            }
        }
        private DateTime? _bill_entry_date;
        public DateTime? bill_entry_date
        {
            get { return _bill_entry_date; }
            set
            {
                if (_bill_entry_date != value)
                {
                    _bill_entry_date = value; RaisePropertyChanged("bill_entry_date");
                }
            }                
        }
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set {
                if (_ItemCode != value)
                {
                    _ItemCode = value; RaisePropertyChanged("ItemCode", ModelEntityUpdated);
                }
            }                
        }
        private string _sku;
        public string sku
        {
            get { return _sku; }
            set {
                if (_sku != value)
                {
                    _sku = value; RaisePropertyChanged("sku", ModelEntityUpdated);
                }
            }               
        }
        private Nullable<int> _item_row_id;
        public Nullable<int> item_row_id
        {
            get { return _item_row_id; }
            set {
                if (_item_row_id != value)
                {
                    _item_row_id = value; RaisePropertyChanged("item_row_id", ModelEntityUpdated);
                }
            }               
        }
        private Nullable<int> _item_line_id;
        public Nullable<int> item_line_id
        {
            get { return _item_line_id; }
            set {
                if (_item_line_id != value)
                {
                    _item_line_id = value; RaisePropertyChanged("item_line_id", ModelEntityUpdated);
                }
            }              
        }



        private string _licence_no;
        public string licence_no
        {
            get { return _licence_no; }
            set {
                if (_licence_no != value)
                {
                    _licence_no = value; RaisePropertyChanged("licence_no", ModelEntityUpdated);
                }
            }                
        }
        private string _incoterms;
        public string incoterms
        {
            get { return _incoterms; }
            set {
                if (_incoterms != value)
                {
                    _incoterms = value; RaisePropertyChanged("incoterms", ModelEntityUpdated);
                }
            }                
        }
        private Nullable<decimal> _incoterm_value_doc { get; set; }
        public Nullable<decimal> incoterm_value_doc
        {
            get { return _incoterm_value_doc; }
            set {
                if (_incoterm_value_doc != value)
                {
                    _incoterm_value_doc = value; RaisePropertyChanged("incoterm_value_doc");
                }
            }                          
        }
        private Nullable<decimal> _incoterm_value_local { get; set; }
        public Nullable<decimal> incoterm_value_local
        {
            get { return _incoterm_value_local; }
            set {
                if (_incoterm_value_local != value)
                {
                    _incoterm_value_local = value; RaisePropertyChanged("incoterm_value_local");
                }
            }                
        }
        private Nullable<decimal> _qty { get; set; }
        public Nullable<decimal> qty
        {
            get { return _qty; }
            set {
                if (_qty != value)
                {
                    _qty = value; RaisePropertyChanged("qty");
                }
            }               
        }
        private Nullable<decimal> _qty_against_lic { get; set; }
        public Nullable<decimal> qty_against_lic
        {
            get { return _qty_against_lic; }
            set {
                if (_qty_against_lic != value)
                {
                    _qty_against_lic = value; RaisePropertyChanged("qty_against_lic");
                }
            }                
        }
        private Nullable<decimal> _value_lic_doc { get; set; }
        public Nullable<decimal> value_lic_doc
        {
            get { return _value_lic_doc; }
            set {
                if (_value_lic_doc != value)
                {
                    _value_lic_doc = value; RaisePropertyChanged("value_lic_doc");
                }
            }                
        }
        private Nullable<decimal> _value_lic_loc { get; set; }
        public Nullable<decimal> value_lic_loc
        {
            get { return _value_lic_loc; }
            set {
                if (_value_lic_loc != value)
                {
                    _value_lic_loc = value; RaisePropertyChanged("value_lic_loc");
                }
            }                
        }
        private string _asset_no;
        public string asset_no
        {
            get { return _asset_no; }
            set {
                if (_asset_no != value)
                {
                    _asset_no = value; RaisePropertyChanged("asset_no", ModelEntityUpdated);
                }
            }               
        }
        private string _sub_asset_no;
        public string sub_asset_no
        {
            get { return _sub_asset_no; }
            set {
                if (_sub_asset_no != value)
                {
                    _sub_asset_no = value; RaisePropertyChanged("sub_asset_no", ModelEntityUpdated);
                }
            }            
        }

        private string _order_no;
        public string order_no
        {
            get { return _order_no; }
            set {
                if (_order_no != value)
                {
                    _order_no = value; RaisePropertyChanged("order_no", ModelEntityUpdated);
                }
            }                
        }
        private string _invoice_no;
        public string invoice_no
        {
            get { return _invoice_no; }
            set {
                if (_invoice_no != value)
                {
                    _invoice_no = value; RaisePropertyChanged("invoice_no", ModelEntityUpdated);
                }
            }               
        }
        private string _asset_location;
        public string asset_location
        {
            get { return _asset_location; }
            set {
                if (_asset_location != value)
                {
                    _asset_location = value; RaisePropertyChanged("asset_location", ModelEntityUpdated);
                }
            }             
        }
        private Nullable<decimal> _exch_rate { get; set; }
        public Nullable<decimal> exch_rate
        {
            get { return _exch_rate; }
            set {
                if (_exch_rate != value)
                {
                    _exch_rate = value; RaisePropertyChanged("exch_rate");
                }
            }                
        }
        private Nullable<decimal> _cons_rate { get; set; }
        public Nullable<decimal> cons_rate
        {
            get { return _cons_rate; }
            set {
                if (_cons_rate != value)
                {
                    _cons_rate = value; RaisePropertyChanged("cons_rate");
                }
            }                
        }

        private string _ref_doc_no;
        public string ref_doc_no
        {
            get
            {
                return _ref_doc_no;
            }

            set
            {
                if (_ref_doc_no != value)
                {
                    _ref_doc_no = value; RaisePropertyChanged("ref_doc_no", ModelEntityUpdated);
                }                
            }
        }
        private string _ref_doc_type;
        public string ref_doc_type
        {
            get
            {
                return _ref_doc_type;
            }

            set
            {
                if (_ref_doc_type != value)
                {
                    _ref_doc_type = value; RaisePropertyChanged("ref_doc_type", ModelEntityUpdated);
                }               
            }
        }
        private DateTime? _ref_doc_date;
        public DateTime? ref_doc_date
        {
            get { return _ref_doc_date; }
            set
            {
                if (_ref_doc_date != value)
                {
                    _ref_doc_date = value; RaisePropertyChanged("ref_doc_date");
                }
            }                
        }

        private string _con_type;
        public string con_type
        {
            get
            {
                return _con_type;
            }

            set
            {
                if (_con_type != value)
                {
                    _con_type = value; RaisePropertyChanged("con_type", ModelEntityUpdated);
                }                
            }
        }
        private string _trns_key_code;
        public string trns_key_code
        {
            get
            {
                return _trns_key_code;
            }

            set
            {
                if (_trns_key_code != value)
                {
                    _trns_key_code = value; RaisePropertyChanged("trns_key_code", ModelEntityUpdated);
                }
            }               
        }
        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set {
                if (_fin_year != value)
                {
                    _fin_year = value; RaisePropertyChanged("fin_year", ModelEntityUpdated);
                }
            }               
        }
        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set {
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("posting_period", ModelEntityUpdated);
                }
            }               
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active", ModelEntityUpdated);
                }
            }                
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id", ModelEntityUpdated);
                }
            }                
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code", ModelEntityUpdated);
                }
            }                
        }
        private string _curr_code;
        public string curr_code
        {
            get { return _curr_code; }
            set {
                if (_curr_code != value)
                {
                    _curr_code = value; RaisePropertyChanged("curr_code", ModelEntityUpdated);
                }
            }               
        }
        private string _PartyId { get; set; }
        public string PartyId
        {
            get
            {
                return _PartyId;
            }

            set
            {
                if (_PartyId != value)
                {
                    _PartyId = value; RaisePropertyChanged("PartyId");
                }               
            }
        }
        private string _remark { get; set; }
        public string remark
        {
            get
            {
                return _remark;
            }

            set
            {
                if (_remark != value)
                {
                    _remark = value; RaisePropertyChanged("remark");
                }                
            }
        }
        private string _req_no;
        public string req_no
        {
            get { return _req_no; }
            set
            {
                if (_req_no != value)

                {
                    _req_no = value; RaisePropertyChanged("req_no", ModelEntityUpdated);
                }
            }
        }
    }
}
