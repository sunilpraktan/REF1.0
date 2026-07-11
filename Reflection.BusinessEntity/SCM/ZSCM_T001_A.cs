using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Reflection.BusinessEntity
{
    public class ZSCM_T001_A : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }
        private string _average_wt_no;     
        public string average_wt_no
        {
            get { return _average_wt_no; }
            set
            {
                _average_wt_no = value;
                RaisePropertyChanged("average_wt_no");
            }
        }
        private Nullable<System.DateTime> _average_wt_dt;
        public Nullable<System.DateTime> average_wt_dt
        {
            get { return _average_wt_dt; }
            set
            {
                _average_wt_dt = value;
                RaisePropertyChanged("average_wt_dt");
            }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }
        private string _finyr;
        public string finyr
        {
            get { return _finyr; }
            set
            {
                _finyr = value;
                RaisePropertyChanged("finyr");
            }
        }
        private string _Month;
        public string Month
        {
            get { return _Month; }
            set
            {
                _Month = value;
                RaisePropertyChanged("Month");
            }
        }
        private string _Year;
        public string Year
        {
            get { return _Year; }
            set
            {
                _Year = value;
                RaisePropertyChanged("Year");
            }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
            }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }
        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get{return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }
        
        public string XmlDataDocument_ZSCM_T001_B { get; set; }

       
    }
    public class ZSCM_T001_B : ObjectBase
    {
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }
        private int _average_wt_id;
        public int average_wt_id
        {
            get { return _average_wt_id; }
            set
            {
                _average_wt_id = value;
                RaisePropertyChanged("average_wt_id");
            }
        }
        private Nullable<int> _wire_type_id;
        public Nullable<int> wire_type_id
        {
            get { return _wire_type_id; }
            set
            {
                _wire_type_id = value;
                RaisePropertyChanged("wire_type_id");
            }
        }
        private Nullable<int> _make_id;
        public Nullable<int> make_id
        {
            get { return _make_id; }
            set
            {
                _make_id = value;
                RaisePropertyChanged("make_id");
            }
        }
        private Nullable<int> _wire_size_id;
        public Nullable<int> wire_size_id
        {
            get { return _wire_size_id; }
            set
            {
                _wire_size_id = value;
                RaisePropertyChanged("wire_size_id");
            }
        }
        private Nullable<int> _blank_len;
        public Nullable<int> blank_len
        {
            get { return _blank_len; }
            set
            {
                _blank_len = value;
                RaisePropertyChanged("blank_len");
            }
        }
        private decimal _avg_blank_wt;
        public decimal avg_blank_wt
        {
            get { return _avg_blank_wt; }
            set
            {
                _avg_blank_wt = value;
                RaisePropertyChanged("avg_blank_wt");
            }
        }
        private string  _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
            }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }
        private string _finyr;
        public string finyr
        {
            get { return _finyr; }
            set
            {
                _finyr = value;
                RaisePropertyChanged("finyr");
            }
        }
        private string _WireType;
        public string WireType
        {
            get { return _WireType; }
            set
            {
                _WireType = value;
                RaisePropertyChanged("WireType");
            }
        }
        private string _Make;
        public string Make
        {
            get { return _Make; }
            set
            {
                _Make = value;
                RaisePropertyChanged("Make");
            }
        }
        private Nullable<decimal> _WireDia;
        public Nullable<decimal> WireDia
        {
            get { return _WireDia; }
            set
            {
                _WireDia = value;
                RaisePropertyChanged("WireDia");
            }
        }
        private string _BlankLength;
        public string BlankLength
        {
            get { return _BlankLength; }
            set
            {
                _BlankLength = value;
                RaisePropertyChanged("BlankLength");
            }
        }
        private Nullable<System.DateTime> _entry_date;
        public Nullable<System.DateTime> entry_date
        {
            get { return _entry_date; }
            set
            {
                _entry_date = value;
                RaisePropertyChanged("entry_date");
            }
        }
        private decimal _wt1;
        public decimal wt1
        {
            get { return _wt1; }
            set
            {
                _wt1 = value;
                RaisePropertyChanged("wt1");
            }
        }
        private decimal _wt2;
        public decimal wt2
        {
            get { return _wt2; }
            set
            {
                _wt2 = value;
                RaisePropertyChanged("wt2");
            }
        }
        private decimal _wt3;
        public decimal wt3
        {
            get { return _wt3; }
            set
            {
                _wt3 = value;
                RaisePropertyChanged("wt3");
            }
        }

       private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
        private string _ReportCode;
        public string ReportCode
        {
            get { return _ReportCode; }
            set
            {
                _ReportCode = value;
                RaisePropertyChanged("ReportCode");
            }
        }
    }
    public class MultipleContext_ZSCM_T001_A
    {

        public List<ZSCM_T001_A> Avg_Wt { get; set; }//Average Blank Weight
        public ObservableCollection<ZSCM_T001_B> Avg_Wt_Details { get; set; }//Average Blank Weight Detaild
        public List<ZADM_M003_P> wiresize { get; set; }//Wire Size Master       
        public List<ZADM_M004_P> wiretype { get; set; }//Wire Type Master
        public List<ZADM_M008_P> TotLength { get; set; }//Total Length Master
        public List<ADM_M0032_P> Make { get; set; }// Make Master
        public List<ZSCM_T001_A_Mon> Month { get; set; }//Month Year From Average Blank Weight
        public List<ZSCM_T001_A_YR> Year { get; set; }//Month Year From Average Blank Weight
        public List<ZSCM_T001_A_Rpt> AvgB_Wt_Rpt { get; set; }//Month Year From Average Blank Weight

    }


    public class ZADM_M003_PopUp
    {   
        public int wire_size_id { get; set; }
         [DisplayName("Wire Size")]
        public decimal wire_size { get; set; }
    }
    public class ZADM_M004_PopUp
    {
        public int wire_type_id { get; set; }
        [DisplayName("Wire Type")]
        public string wire_type { get; set; }
    }
    ////public class ZADM_M008_PopUp
    ////{
    ////    public int tot_len_id { get; set; }
    ////    [DisplayName("Total Length")]
    ////    public string total_len { get; set; }
    ////}
    public class ADM_M0032_PopUp
    {
        public int MakeCode { get; set; }
        [DisplayName("Make")]
        public string Make { get; set; }
    }


    public class ZSCM_T001_A_Mon
    {
        public int Ord { get; set; }
        [DisplayName("Month")]
        public string Month { get; set; }

    }

    public class ZSCM_T001_A_YR
    {
        [DisplayName("Year")]
        public string Year { get; set; }

    }

    public class ZSCM_T001_A_Rpt
    {
        public string Month { get; set; }
        public string Year { get; set; }
        public Nullable<DateTime> Date { get; set; }
        public string Header1 { get; set; }
        public Nullable<decimal> avg_blank_wt { get; set; }
        public string Plant { get; set; }
        public Nullable<int> id { get; set; }
  

    }
}
