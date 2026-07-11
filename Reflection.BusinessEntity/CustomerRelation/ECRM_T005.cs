using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.ComponentModel.DataAnnotations;
using Reflection.BusinessEntity;

namespace Reflection.BusinessEntity
{
    public class ECRM_T005: ObjectBase 
    {      

        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged("id");
                }
            }
        }

        private string _company_id;
        public string company_id
        {
            get { return _company_id; }
            set
            {
                if (_company_id != value)
                {
                    _company_id = value;
                    RaisePropertyChanged("company_id");
                }
            }
        }

        private string _plant;
        public string plant
        {
            get { return _plant; }
            set
            {
                if (_plant != value)
                { _plant = value; RaisePropertyChanged("plant"); }
            }
        }
       
        private string _inv_no;
        [Required(ErrorMessage = "Field 'Export Invoice No' is required.")]
        [DisplayName("Export Invoice No")]
        public string inv_no
        {
            get { return _inv_no; }
            set
            {
                if (_inv_no != value)
                { _inv_no = value; RaisePropertyChanged("inv_no"); }
            }
        }
       
        private decimal _exchange_rate;
        public decimal exchange_rate
        {
            get { return _exchange_rate; }
            set
            {
                if (_exchange_rate != value)
                {
                    _exchange_rate = value;
                    RaisePropertyChanged("exchange_rate");
                }
            }
        } 

        private string _cust_pur_inv;
        public string cust_pur_inv
        {
            get { return _cust_pur_inv; }
            set {
                if (_cust_pur_inv != value)
                {
                    _cust_pur_inv = value; RaisePropertyChanged("cust_pur_inv");
                }
            }
        }
        
        private string _pack_list;
        public string pack_list
        {
            get { return _pack_list; }
            set {
                if (_pack_list != value)
                {
                    _pack_list = value; RaisePropertyChanged("pack_list");
                }
            }
        }
      
        private string _sdf_form;
        public string sdf_form
        {
            get { return _sdf_form; }
            set
            {
                if (_sdf_form != value)
                {
                    _sdf_form = value; RaisePropertyChanged("sdf_form");
                }
            }
        }
       
        private string _decltn_lic;
        public string decltn_lic
        {
            get { return _decltn_lic; }
            set {
                if (_decltn_lic != value)
                {
                    _decltn_lic = value; RaisePropertyChanged("decltn_lic");

                }
            }
        }
      
        private string _insurance;
        public string insurance
        {
            get { return _insurance; }
            set {
                if (_insurance != value)
                {
                    _insurance = value; RaisePropertyChanged("insurance");

                }
            }
        }
    
        private string _brc;
        public string brc
        {
            get { return _brc; }
            set {
                if (_brc != value)
                {
                    _brc = value; RaisePropertyChanged("brc");

                }
            }
        }
   
        private string _adv_licenc_no;
        public string adv_licenc_no
        {
            get { return _adv_licenc_no; }
            set {
                if (_adv_licenc_no != value)
                {
                    _adv_licenc_no = value; RaisePropertyChanged("adv_licenc_no");

                }
            }
        }
    
        private string _epcg_licenc_no;
        public string epcg_licenc_no
        {
            get { return _epcg_licenc_no; }
            set {
                if (_epcg_licenc_no != value)
                {
                    _epcg_licenc_no = value; RaisePropertyChanged("epcg_licenc_no");

                }
            }
        }
   
        private string _dispch_mode;
        public string dispch_mode
        {
            get { return _dispch_mode; }
            set {
                if (_dispch_mode != value)
                {
                    _dispch_mode = value; RaisePropertyChanged("dispch_mode");

                }
            }
        }
     
        private string _final_destn_contry;
        public string final_destn_contry
        {
            get { return _final_destn_contry; }
            set {
                if (_final_destn_contry != value)
                {
                    _final_destn_contry = value; RaisePropertyChanged("final_destn_contry");

                }
            }
        }
        
        private string _final_destn_port;
        public string final_destn_port
        {
            get { return _final_destn_port; }
            set {
                if (_final_destn_port != value)
                {
                    _final_destn_port = value; RaisePropertyChanged("final_destn_port");

                }
            }
        }
       
        private decimal _gross_wt;
        public decimal gross_wt
        {
            get { return _gross_wt; }
            set
            {
                if (_gross_wt != value)
                {
                    _gross_wt = value;
                    RaisePropertyChanged("gross_wt");
                }
            }
        } 
     
        private decimal _net_wt;
        public decimal net_wt
        {
            get { return _net_wt; }
            set
            {
                if (_net_wt != value)
                {
                    _net_wt = value;
                    RaisePropertyChanged("net_wt");
                }
            }
        } 
     
        private string _ship_line;
        public string ship_line
        {
            get { return _ship_line; }
            set {
                if (_ship_line != value)
                {
                    _ship_line = value; RaisePropertyChanged("ship_line");

                }
            }
        }
     
        private string _air_line;
        public string air_line
        {
            get { return _air_line; }
            set {
                if (_air_line != value)
                {
                    _air_line = value; RaisePropertyChanged("air_line");

                }
            }
        }
    
        private string _air_way_billno;
        public string air_way_billno
        {
            get { return _air_way_billno; }
            set {
                if (_air_way_billno != value)
                {
                    _air_way_billno = value; RaisePropertyChanged("air_way_billno");

                }
            }
        }
   
        private Nullable<System.DateTime> _air_way_billdt;
        public Nullable<System.DateTime> air_way_billdt
        {
            get { return _air_way_billdt; }
            set {
                if (_air_way_billdt != value)
                {
                    _air_way_billdt = value; RaisePropertyChanged("air_way_billdt");

                }
            }
        }

        private string _ref_no;
        public string ref_no
        {
            get { return _ref_no; }
            set {
                if (_ref_no != value)
                {
                    _ref_no = value; RaisePropertyChanged("ref_no");

                }
            }
        }

        private Nullable<System.DateTime> _ref_date;
        public Nullable<System.DateTime> ref_date
        {
            get { return _ref_date; }
            set {
                if (_ref_date != value)
                {
                    _ref_date = value; RaisePropertyChanged("ref_date");

                }
            }
        }
 
        private string _etd;
        public string etd
        {
            get { return _etd; }
            set {
                if (_etd != value)
                {
                    _etd = value; RaisePropertyChanged("etd");

                }
            }
        }
 
        private string _eta;
        public string eta
        {
            get { return _eta; }
            set {
                if (_eta != value)
                {
                    _eta = value; RaisePropertyChanged("eta");

                }
            }
        }
    
        private string _acode;
        public string acode
        {
            get { return _acode; }
            set {
                if (_acode != value)
                {
                    _acode = value; RaisePropertyChanged("acode");

                }
            }
        }
     
        private string _dcinv_frwd_cust;
        public string dcinv_frwd_cust
        {
            get { return _dcinv_frwd_cust; }
            set {
                if (_dcinv_frwd_cust != value)
                {
                    _dcinv_frwd_cust = value; RaisePropertyChanged("dcinv_frwd_cust");

                }
            }
        }
   
        private Nullable<System.DateTime> _dcinv_frwd_cust_dt;
        public Nullable<System.DateTime> dcinv_frwd_cust_dt
        {
            get { return _dcinv_frwd_cust_dt; }
            set {
                if (_dcinv_frwd_cust_dt != value)
                {
                    _dcinv_frwd_cust_dt = value; RaisePropertyChanged("dcinv_frwd_cust_dt");

                }
            }
        }
      
        private string _dcinv_frwd_thr;
        public string dcinv_frwd_thr
            {
                get { return _dcinv_frwd_thr; }
                set {
                if (_dcinv_frwd_thr != value)
                {
                    _dcinv_frwd_thr = value; RaisePropertyChanged("dcinv_frwd_thr");

                }
            }
            }

        private string _dcpck_frwd_cust;
        public string dcpck_frwd_cust
        {
            get { return _dcpck_frwd_cust; }
            set {
                if (_dcpck_frwd_cust != value)
                {
                    _dcpck_frwd_cust = value; RaisePropertyChanged("dcpck_frwd_cust");

                }
            }
        }
     
        private Nullable<System.DateTime> _dcpck_frwd_cust_dt;
        public Nullable<System.DateTime> dcpck_frwd_cust_dt
        {
            get { return _dcpck_frwd_cust_dt; }
            set {
                if (_dcpck_frwd_cust_dt != value)
                {
                    _dcpck_frwd_cust_dt = value; RaisePropertyChanged("dcpck_frwd_cust_dt");

                }
            }
        }
   
        private string _dcpck_frwd_thr;
        public string dcpck_frwd_thr
        {
            get { return _dcpck_frwd_thr; }
            set {
                if (_dcpck_frwd_thr != value)
                {
                    _dcpck_frwd_thr = value; RaisePropertyChanged("dcpck_frwd_thr");

                }
            }
        }
   
        private string _dcair_frwd_cust;
        public string dcair_frwd_cust
        {
            get { return _dcair_frwd_cust; }
            set {
                if (_dcair_frwd_cust != value)
                {
                    _dcair_frwd_cust = value; RaisePropertyChanged("dcair_frwd_cust");

                }
            }
        }
 
        private Nullable<System.DateTime> _dcair_frwd_cust_dt;
        public Nullable<System.DateTime> dcair_frwd_cust_dt
        {
            get { return _dcair_frwd_cust_dt; }
            set {
                if (_dcair_frwd_cust_dt != value)
                {
                    _dcair_frwd_cust_dt = value; RaisePropertyChanged("dcair_frwd_cust_dt");

                }
            }
        }
     
        private string _dcair_frwd_thr;
        public string dcair_frwd_thr
        {
            get { return _dcair_frwd_thr; }
            set {
                if (_dcair_frwd_thr != value)
                {
                    _dcair_frwd_thr = value; RaisePropertyChanged("dcair_frwd_thr");

                }
            }
        }
  
        private string _dcinsur_frwd_cust;
        public string dcinsur_frwd_cust
        {
            get { return _dcinsur_frwd_cust; }
            set {
                if (_dcinsur_frwd_cust != value)
                {
                    _dcinsur_frwd_cust = value; RaisePropertyChanged("dcinsur_frwd_cust");

                }
            }
        }
      
        private Nullable<System.DateTime> _dcinsur_frwd_cust_dt;
        public Nullable<System.DateTime> dcinsur_frwd_cust_dt
        {
            get { return _dcinsur_frwd_cust_dt; }
            set {
                if (_dcinsur_frwd_cust_dt != value)
                {
                    _dcinsur_frwd_cust_dt = value; RaisePropertyChanged("dcinsur_frwd_cust_dt");

                }
            }
        }
     
        private string _dcinsur_frwd_thr;
        public string dcinsur_frwd_thr
        {
            get { return _dcinsur_frwd_thr; }
            set {
                if (_dcinsur_frwd_thr != value)
                {
                    _dcinsur_frwd_thr = value; RaisePropertyChanged("dcinsur_frwd_thr");

                }
            }
        }
       
        private string _dccertif_cust;
        public string dccertif_cust
        {
            get { return _dccertif_cust; }
            set {
                if (_dccertif_cust != value)
                {
                    _dccertif_cust = value; RaisePropertyChanged("dccertif_cust");

                }
            }
        }
        
        private Nullable<System.DateTime> _dccertif_cust_dt;
        public Nullable<System.DateTime> dccertif_cust_dt
        {
            get { return _dccertif_cust_dt; }
            set {
                if (_dccertif_cust_dt != value)
                {
                    _dccertif_cust_dt = value; RaisePropertyChanged("dccertif_cust_dt");

                }
            }
        }
        
        private string _dccertif_cust_thr;
        public string dccertif_cust_thr
        {
            get { return _dccertif_cust_thr; }
            set {
                if (_dccertif_cust_thr != value)
                {
                    _dccertif_cust_thr = value; RaisePropertyChanged("dccertif_cust_thr");

                }
            }
        }
       
        private string _dbinv_frwd_bnk;
        public string dbinv_frwd_bnk
        {
            get { return _dbinv_frwd_bnk; }
            set {
                if (_dbinv_frwd_bnk != value)
                {
                    _dbinv_frwd_bnk = value; RaisePropertyChanged("dbinv_frwd_bnk");

                }
            }
        }
       
        private Nullable<System.DateTime> _dbinv_frwd_bnk_dt;
        public Nullable<System.DateTime> dbinv_frwd_bnk_dt
        {
            get { return _dbinv_frwd_bnk_dt; }
            set {
                if (_dbinv_frwd_bnk_dt != value)
                {
                    _dbinv_frwd_bnk_dt = value; RaisePropertyChanged("dbinv_frwd_bnk_dt");

                }
            }
        }
       
        private string _dbinv_frwd_thr;
        public string dbinv_frwd_thr
        {
            get { return _dbinv_frwd_thr; }
            set {
                if (_dbinv_frwd_thr != value)
                {
                    _dbinv_frwd_thr = value; RaisePropertyChanged("dbinv_frwd_thr");

                }
            }
        }
        
        private string _dbpck_frwd_bnk;
        public string dbpck_frwd_bnk
        {
            get { return _dbpck_frwd_bnk; }
            set {
                if (_dbpck_frwd_bnk != value)
                {
                    _dbpck_frwd_bnk = value; RaisePropertyChanged("dbpck_frwd_bnk");

                }
            }
        }
        
        private Nullable<System.DateTime> _dbpck_frwd_bnk_dt;
        public Nullable<System.DateTime> dbpck_frwd_bnk_dt
        {
            get { return _dbpck_frwd_bnk_dt; }
            set {
                if (_dbpck_frwd_bnk_dt != value)
                {
                    _dbpck_frwd_bnk_dt = value; RaisePropertyChanged("dbpck_frwd_bnk_dt");

                }
            }
        }
       
        private string _dbpck_frwd_thr;
        public string dbpck_frwd_thr
        {
            get { return _dbpck_frwd_thr; }
            set {
                if (_dbpck_frwd_thr != value)
                {
                    _dbpck_frwd_thr = value; RaisePropertyChanged("dbpck_frwd_thr");

                }
            }
        }
       
        private string _dbair_frwd_bnk;
        public string dbair_frwd_bnk
        {
            get { return _dbair_frwd_bnk; }
            set {
                if (_dbair_frwd_bnk != value)
                {
                    _dbair_frwd_bnk = value; RaisePropertyChanged("dbair_frwd_bnk");

                }
            }
        }
        
        private Nullable<System.DateTime> _dbair_frwd_bnk_dt;
        public Nullable<System.DateTime> dbair_frwd_bnk_dt
        {
            get { return _dbair_frwd_bnk_dt; }
            set {
                if (_dbair_frwd_bnk_dt != value)
                {
                    _dbair_frwd_bnk_dt = value; RaisePropertyChanged("dbair_frwd_bnk_dt");

                }
            }
        }
        
        private string _dbair_frwd_thr;
        public string dbair_frwd_thr
        {
            get { return _dbair_frwd_thr; }
            set {
                if (_dbair_frwd_thr != value)
                {
                    _dbair_frwd_thr = value; RaisePropertyChanged("dbair_frwd_thr");

                }
            }
        }
        
        private string _dbinsur_frwd_bnk;
        public string dbinsur_frwd_bnk
        {
            get { return _dbinsur_frwd_bnk; }
            set {
                if (_dbinsur_frwd_bnk != value)
                {
                    _dbinsur_frwd_bnk = value; RaisePropertyChanged("dbinsur_frwd_bnk");

                }
            }
        }
       
        private Nullable<System.DateTime> _dbinsur_frwd_bnk_dt;
        public Nullable<System.DateTime> dbinsur_frwd_bnk_dt
        {
            get { return _dbinsur_frwd_bnk_dt; }
            set {
                if (_dbinsur_frwd_bnk_dt != value)
                {
                    _dbinsur_frwd_bnk_dt = value; RaisePropertyChanged("dbinsur_frwd_bnk_dt");

                }
            }
        }
       
        private string _dbinsur_frwd_thr;
        public string dbinsur_frwd_thr
        {
            get { return _dbinsur_frwd_thr; }
            set {
                if (_dbinsur_frwd_thr != value)
                {
                    _dbinsur_frwd_thr = value; RaisePropertyChanged("dbinsur_frwd_thr");

                }
            }
        }
        
        private string _dbcertif_bnk;
        public string dbcertif_bnk
        {
            get { return _dbcertif_bnk; }
            set {
                if (_dbcertif_bnk != value)
                {
                    _dbcertif_bnk = value; RaisePropertyChanged("dbcertif_bnk");

                }
            }
        }
       
        private Nullable<System.DateTime> _dbcertif_bnk_dt;
        public Nullable<System.DateTime> dbcertif_bnk_dt
        {
            get { return _dbcertif_bnk_dt; }
            set {
                if (_dbcertif_bnk_dt != value)
                {
                    _dbcertif_bnk_dt = value; RaisePropertyChanged("dbcertif_bnk_dt");

                }
            }
        }
        
        private string _dbcertif_bnk_thr;
        public string dbcertif_bnk_thr
        {
            get { return _dbcertif_bnk_thr; }
            set {
                if (_dbcertif_bnk_thr != value)
                {
                    _dbcertif_bnk_thr = value; RaisePropertyChanged("dbcertif_bnk_thr");

                }
            }
        }
        
        private string _curr;
        public string curr
        {
            get { return _curr; }
            set {
                if (_curr != value)
                {
                    _curr = value; RaisePropertyChanged("curr");

                }
            }
        }
       
        private decimal _inv_fc;      
        public decimal inv_fc
        {
            get { return _inv_fc; }
            set
            {
                if (_inv_fc != value)
                {
                    _inv_fc = value;
                    RaisePropertyChanged("inv_fc");
                }
            }
        } 
        
        private decimal _inv_rs;
        [ValidInteger(ErrorMessage = "Only numbers allowed")]
        [Required(ErrorMessage = "Only numbers allowed.")]
        [DisplayName("Invoice Value")]
        public decimal inv_rs
        {
            get { return _inv_rs; }
            set
            {
                if (_inv_rs != value)
                {
                    _inv_rs = value;
                    RaisePropertyChanged("inv_rs");
                }
            }
        } 
     
        private Nullable<System.DateTime> _brc_dt;
        public Nullable<System.DateTime> brc_dt
        {
            get { return _brc_dt; }
            set {
                if (_brc_dt != value)
                {
                    _brc_dt = value; RaisePropertyChanged("brc_dt");

                }
            }
        }
       
        private decimal _brc_inv_rs;       
        public decimal brc_inv_rs
        {
            get { return _brc_inv_rs; }
            set
            {
                if (_brc_inv_rs != value)
                {
                    _brc_inv_rs = value;
                    RaisePropertyChanged("brc_inv_rs");
                }
            }
        } 
       
        private string _brc_appl_for_bank;
        public string brc_appl_for_bank
        {
            get { return _brc_appl_for_bank; }
            set {
                if (_brc_appl_for_bank != value)
                {
                    _brc_appl_for_bank = value; RaisePropertyChanged("brc_appl_for_bank");

                }
            }
        }
       
        private Nullable<System.DateTime> _brc_appl_dt;
        public Nullable<System.DateTime> brc_appl_dt
        {
            get { return _brc_appl_dt; }
            set {
                if (_brc_appl_dt != value)
                {
                    _brc_appl_dt = value; RaisePropertyChanged("brc_appl_dt");

                }
            }
        }
       
        private string _brc_appl_bank;
        public string brc_appl_bank
        {
            get { return _brc_appl_bank; }
            set {
                if (_brc_appl_bank != value)
                {
                    _brc_appl_bank = value; RaisePropertyChanged("brc_appl_bank");

                }
            }
        }
       
        private string _brc_recv_for_bank;
        public string brc_recv_for_bank
        {
            get { return _brc_recv_for_bank; }
            set {
                if (_brc_recv_for_bank != value)
                {
                    _brc_recv_for_bank = value; RaisePropertyChanged("brc_recv_for_bank");

                }
            }
        }
        
        private Nullable<System.DateTime> _brc_recv_dt;
        public Nullable<System.DateTime> brc_recv_dt
        {
            get { return _brc_recv_dt; }
            set {
                if (_brc_recv_dt != value)
                {
                    _brc_recv_dt = value; RaisePropertyChanged("brc_recv_dt");

                }
            }
        }
       
        private string _brc_recv_bank;
        public string brc_recv_bank
        {
            get { return _brc_recv_bank; }
            set {
                if (_brc_recv_bank != value)
                {
                    _brc_recv_bank = value; RaisePropertyChanged("brc_recv_bank");

                }
            }
        }

        private decimal _bnk_chrg_comm;
        [ValidInteger(ErrorMessage = "Only numbers allowed")]
        [Required(ErrorMessage = "Only numbers allowed.")]
        [DisplayName("Bank Charges Commission")]
        public decimal bnk_chrg_comm
        {
            get { return _bnk_chrg_comm; }
            set {
                if (_bnk_chrg_comm != value)
                {
                    _bnk_chrg_comm = value; RaisePropertyChanged("bnk_chrg_comm");

                }
            }
        }

        private decimal _other_chrg;
        [ValidInteger(ErrorMessage = "Only numbers allowed")]
        [Required(ErrorMessage = "Only numbers allowed.")]
        [DisplayName("Other Charges")]
        public decimal other_chrg
        {
            get { return _other_chrg; }
            set {
                if (_other_chrg != value)
                {
                    _other_chrg = value; RaisePropertyChanged("other_chrg");
                }
            }
        }

        private decimal _short_pay;
        [ValidInteger(ErrorMessage = "Only numbers allowed")]
        [Required(ErrorMessage = "Only numbers allowed.")]
        [DisplayName("Short Payment Wrritten Off")]
        public decimal short_pay
        {
            get { return _short_pay; }
            set {
                if (_short_pay != value)
                {
                    _short_pay = value; RaisePropertyChanged("short_pay");

                }
            }
        }

        private decimal _bnk_chrg_comm_fc;
        public decimal bnk_chrg_comm_fc
        {
            get { return _bnk_chrg_comm_fc; }
            set {
                if (_bnk_chrg_comm_fc != value)
                {
                    _bnk_chrg_comm_fc = value; RaisePropertyChanged("bnk_chrg_comm_fc");

                }
            }
        }

        private decimal _other_chrg_fc;
        public decimal other_chrg_fc
        {
            get { return _other_chrg_fc; }
            set {
                if (_other_chrg_fc != value)
                {
                    _other_chrg_fc = value; RaisePropertyChanged("other_chrg_fc");

                }
            }
        }

        private decimal _short_pay_fc;
        public decimal short_pay_fc
        {
            get { return _short_pay_fc; }
            set {
                if (_short_pay_fc != value)
                {
                    _short_pay_fc = value; RaisePropertyChanged("short_pay_fc");

                }
            }
        }
        
        private string _shipp_billno;
        public string shipp_billno
        {
            get { return _shipp_billno; }
            set {
                if (_shipp_billno != value)
                {
                    _shipp_billno = value; RaisePropertyChanged("shipp_billno");

                }
            }
        }
     
        private Nullable<System.DateTime> _shipp_bill_dt;
        public Nullable<System.DateTime> shipp_bill_dt
        {
            get { return _shipp_bill_dt; }
            set {
                if (_shipp_bill_dt != value)
                {
                    _shipp_bill_dt = value; RaisePropertyChanged("shipp_bill_dt");

                }
            }
        }
        
        private decimal _fc_curr;
        public decimal fc_curr
        {
            get { return _fc_curr; }
            set
            {
                if (_fc_curr != value)
                {
                    _fc_curr = value;
                    RaisePropertyChanged("fc_curr");
                }
            }
        } 
        
        private decimal _exrate;
        public decimal exrate
        {
            get { return _exrate; }
            set
            {
                if (_exrate != value)
                {
                    _exrate = value;
                    RaisePropertyChanged("exrate");

                }
            }
        } 
       
        private decimal _fc_inv;
        public decimal fc_inv
        {
            get { return _fc_inv; }
            set
            {
                if (_fc_inv != value)
                {

                    _fc_inv = value;
                    RaisePropertyChanged("fc_inv");

                }
            }
        } 
      
        private decimal _rs_inv;
        [ValidInteger(ErrorMessage = "Only numbers allowed")]
        [Required(ErrorMessage = "Only numbers allowed.")]
        [DisplayName("Invoice Value")]
        public decimal rs_inv
        {
            get { return _rs_inv; }
            set
            {
                if (_rs_inv != value)
                {
                    _rs_inv = value;
                    RaisePropertyChanged("rs_inv");
                }
            }
        } 
       
        private decimal _fc_freight;
        public decimal fc_freight
        {
            get { return _fc_freight; }
            set
            {
                if (_fc_freight != value)
                {
                    _fc_freight = value;
                    RaisePropertyChanged("fc_freight");

                }
            }
        } 
        
        private decimal _rs_freight;
        [ValidInteger(ErrorMessage = "Only numbers allowed")]
        [Required(ErrorMessage = "Only numbers allowed.")]
        [DisplayName("Freight Value")]
        public decimal rs_freight
        {
            get { return _rs_freight; }
            set
            {
                if (_rs_freight != value)
                {
                    _rs_freight = value;
                    RaisePropertyChanged("rs_freight");

                }
            }
        } 
     
        private decimal _fc_insur;
        public decimal fc_insur
        {
            get { return _fc_insur; }
            set
            {
                if (_fc_insur != value)
                {
                    _fc_insur = value;
                    RaisePropertyChanged("fc_insur");
                }
            }
        } 
        
        private decimal _rs_insur;
        [ValidInteger(ErrorMessage = "Only numbers allowed")]
        [Required(ErrorMessage = "Only numbers allowed.")]
        [DisplayName("Insurance Value")]
        public decimal rs_insur
        {
            get { return _rs_insur; }
            set
            {
                if (_rs_insur != value)
                {
                    _rs_insur = value;
                    RaisePropertyChanged("rs_insur");

                }
            }
        } 
       
        private decimal _fc_comm;
        public decimal fc_comm
        {
            get { return _fc_comm; }
            set
            {
                if (_fc_comm != value)
                {
                    _fc_comm = value;
                    RaisePropertyChanged("fc_comm");

                }
            }
        } 
        
        private decimal _rs_comm;
        [ValidInteger(ErrorMessage = "Only numbers allowed")]
        [Required(ErrorMessage = "Only numbers allowed.")]
        [DisplayName("Commission Value")]
        public decimal rs_comm
        {
            get { return _rs_comm; }
            set
            {
                if (_rs_comm != value)
                {
                    _rs_comm = value;
                    RaisePropertyChanged("rs_comm");

                }
            }
        } 
        
        private decimal _fc_fob;
        [ValidInteger(ErrorMessage = "Only numbers allowed")]
        [Required(ErrorMessage = "Only numbers allowed.")]
        [DisplayName("FOB Value")]
        public decimal fc_fob
        {
            get { return _fc_fob; }
            set
            {
                if (_fc_fob != value)
                {
                    _fc_fob = value;
                    RaisePropertyChanged("fc_fob");

                }
            }
        } 
        
        private decimal _rs_fob;
        public decimal rs_fob
        {
            get { return _rs_fob; }
            set
            {
                if (_rs_fob != value)
                {
                    _rs_fob = value;
                    RaisePropertyChanged("rs_fob");

                }
            }
        } 
        
        private decimal _fc_import_allw;
        public decimal fc_import_allw
        {
            get { return _fc_import_allw; }
            set
            {
                if (_fc_import_allw != value)
                {
                    _fc_import_allw = value;
                    RaisePropertyChanged("fc_import_allw");

                }
            }
        }
       
        private decimal _rs_import_allw;
        [ValidInteger(ErrorMessage = "Only numbers allowed")]
        [Required(ErrorMessage = "Only numbers allowed.")]
        [DisplayName("Import Allowed")]
        public decimal rs_import_allw
        {
            get { return _rs_import_allw; }
            set
            {
                if (_rs_import_allw != value)
                {
                    _rs_import_allw = value;
                    RaisePropertyChanged("rs_import_allw");

                }
            }
        } 
        
        private decimal _fc_ship_inv;
        public decimal fc_ship_inv
        {
            get { return _fc_ship_inv; }
            set
            {
                if (_fc_ship_inv != value)
                {
                    _fc_ship_inv = value;
                    RaisePropertyChanged("fc_ship_inv");

                }
            }
        } 
      
        private decimal _rs_ship_inv;
        public decimal rs_ship_inv
        {
            get { return _rs_ship_inv; }
            set
            {
                if (_rs_ship_inv != value)
                {
                    _rs_ship_inv = value;
                    RaisePropertyChanged("rs_ship_inv");

                }
            }
        } 
      
        private decimal _ship_exchge_rate;
        public decimal ship_exchge_rate
        {
            get { return _ship_exchge_rate; }
            set
            {
                if (_ship_exchge_rate != value)
                {
                    _ship_exchge_rate = value;
                    RaisePropertyChanged("ship_exchge_rate");

                }
            }
        } 
   
        private string _gridppsdf;
        public string gridppsdf
        {
            get { return _gridppsdf; }
            set {
                if (_gridppsdf != value)
                {
                    _gridppsdf = value; RaisePropertyChanged("gridppsdf");

                }
            }
        }
        
        private Nullable<System.DateTime> _mate_recp_dt;
        public Nullable<System.DateTime> mate_recp_dt
        {
            get { return _mate_recp_dt; }
            set {
                if (_mate_recp_dt != value)
                {
                    _mate_recp_dt = value; RaisePropertyChanged("mate_recp_dt");

                }
            }
        }
      
        private Nullable<System.DateTime> _realization_dt;
        public Nullable<System.DateTime> realization_dt
        {
            get { return _realization_dt; }
            set {

                if (_realization_dt != value)
                {
                    _realization_dt = value; RaisePropertyChanged("realization_dt");

                }
            }
        }
               
        private string _nform_no;
        public string nform_no
        {
            get { return _nform_no; }
            set {
                if (_nform_no != value)
                {
                    _nform_no = value; RaisePropertyChanged("nform_no");

                }
            }
        }
      
        private Nullable<System.DateTime> _nform_dt;
        public Nullable<System.DateTime> nform_dt
        {
            get { return _nform_dt; }
            set {
                if (_nform_dt != value)
                {
                    _nform_dt = value; RaisePropertyChanged("nform_dt");

                }
            }
        }
       
        private string _epcopy;
        public string epcopy
        {
            get { return _epcopy; }
            set {
                if (_epcopy != value)
                {
                    _epcopy = value; RaisePropertyChanged("epcopy");

                }
            }
        }
       
        private string _sdffwtobank;
        public string sdffwtobank
        {
            get { return _sdffwtobank; }
            set {
                if (_sdffwtobank != value)
                {
                    _sdffwtobank = value; RaisePropertyChanged("sdffwtobank");

                }
            }
        }
       
        private string _excontrolcopy;
        public string excontrolcopy
        {
            get { return _excontrolcopy; }
            set {
                if (_excontrolcopy != value)
                {
                    _excontrolcopy = value; RaisePropertyChanged("excontrolcopy");

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
                    _active = value; RaisePropertyChanged("active");

                }
            }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");

                }
            }
        }

        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date");

                }
            }
        }

        private string _edit_by;
        public string edit_by
        {
            get { return _edit_by; }
            set {
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
            set {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date");

                }
            }
        }

        //XML doc 
        public string XmlDataDocument_ECRM_T005 { get; set; }
        ////Scalr        
        private Nullable<DateTime> _InvDate;
        public Nullable<DateTime> InvDate
        {
            get { return _InvDate; }
            set {
                if (_InvDate != value)
                {
                    _InvDate = value; RaisePropertyChanged("InvDate");

                }
            }
        }

        private string _acode_name;
        public string acode_name
        {
            get { return _acode_name; }
            set {

                if (_acode_name != value)
                {
                    _acode_name = value; RaisePropertyChanged("acode_name");

                }
            }
        }

        private string _PlantName;
        public string PlantName
        {
            get { return _PlantName; }
            set {
                if (_PlantName != value)
                {
                    _PlantName = value; RaisePropertyChanged("PlantName");

                }
            }
        }
    }

    public class MultipleContext_ECRM_T005
    {
        public List<ECRM_T005> PostDetails { get; set; } //ECRM_T005
        public ObservableCollection<ECRM_T005> GoodsDetails { get; set; }  // ECRM_T005       
        public List<SEL_T003_A_Popup> Invoice { get; set; } //Invoice
        public List<ADM_M027_PopUp> Agent { get; set; } //Agent        
        public List<ACC_M004_Popup> Bank { get; set; } //Bank      
        public List<ZADM_M019_Popup> Airline { get; set; } //Airline
    }
}
