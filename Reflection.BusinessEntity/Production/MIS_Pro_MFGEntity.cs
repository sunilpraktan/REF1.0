using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.Production
{
    public class MIS_Pro_MFGEntity : ObjectBase
    {

        private Nullable<DateTime> _FromDate;
        public Nullable<DateTime> FromDate
        {
            get { return _FromDate; }
            set
            {
                _FromDate = value;
                RaisePropertyChanged("FromDate");
            }
        }

        private Nullable<DateTime> _ToDate;
        public Nullable<DateTime> ToDate
        {
            get { return _ToDate; }
            set
            {
                _ToDate = value;
                RaisePropertyChanged("ToDate");
            }
        }

        private string _ReportName;
        public string ReportName
        {
            get { return _ReportName; }
            set
            {
                _ReportName = value;
                RaisePropertyChanged("ReportName");
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

        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set
            {
                _ItemCode = value;
                RaisePropertyChanged("ItemCode");

            }
        }

        private string _ItemName;
        public string ItemName
        {
            get { return _ItemName; }
            set
            {
                _ItemName = value;
                RaisePropertyChanged("ItemName");
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

        private string _LoctnNm;
        public string LoctnNm
        {
            get { return _LoctnNm; }
            set
            {
                _LoctnNm = value;
                RaisePropertyChanged("LoctnNm");
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
        
        private string _compName;
        public string CompName
        {
            get { return _compName; }
            set
            {
                _compName = value;
                RaisePropertyChanged("CompName");
            }
        }


        private string _doc_no;
        public string doc_no
        {
            get { return _doc_no; }
            set
            {
                _doc_no = value;
                RaisePropertyChanged("doc_no");
            }
        }

        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set
            {
                _doc_cat = value;
                RaisePropertyChanged("doc_cat");
            }
        }

        private string _doc_type;
        public string doc_type
        {
            get { return _doc_type; }
            set
            {
                _doc_type = value;
                RaisePropertyChanged("doc_type");
            }
        }

        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set
            {
                _fin_year = value;
                RaisePropertyChanged("fin_year");
            }
        }

        private string _para1;
        public string para1
        {
            get { return _para1; }
            set
            {
                _para1 = value;
                RaisePropertyChanged("para1");
            }
        }

        private string _para2;
        public string para2
        {
            get { return _para2; }
            set
            {
                _para2 = value;
                RaisePropertyChanged("para2");
            }
        }

        private string _para3;
        public string para3
        {
            get { return _para3; }
            set
            {
                _para3 = value;
                RaisePropertyChanged("para3");
            }
        }

        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }

        private string _EmpName;
        public string EmpName
        {
            get { return _EmpName; }
            set
            {
                _EmpName = value;
                RaisePropertyChanged("EmpName");
            }
        }

        private string _EmpId;
        public string EmpId
        {
            get { return _EmpId; }
            set
            {
                _EmpId = value;
                RaisePropertyChanged("EmpId");
            }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                _unit_code = value;
                RaisePropertyChanged("unit_code");
            }
        }

        private string _unit_name;
        public string unit_name
        {
            get { return _unit_name; }
            set
            {
                _unit_name = value;
                RaisePropertyChanged("unit_name");
            }
        }

        private string _ReportType;
        public string ReportType
        {
            get { return _ReportType; }
            set
            {
                _ReportType = value;
                RaisePropertyChanged("ReportType");
            }
        }

        private string _wire_type;
        public string wire_type
        {
            get { return _wire_type; }
            set
            {
                _wire_type = value;
                RaisePropertyChanged("wire_type");
            }
        }

        private int _wire_type_id;
        public int wire_type_id
        {
            get { return _wire_type_id; }
            set
            {
                _wire_type_id = value;
                RaisePropertyChanged("wire_type_id");
            }
        }

        private string _ball_type;
        public string ball_type
        {
            get { return _ball_type; }
            set
            {
                _ball_type = value;
                RaisePropertyChanged("ball_type");
            }
        }

        private int _ball_type_id;
        public int ball_type_id
        {
            get { return _ball_type_id; }
            set
            {
                _ball_type_id = value;
                RaisePropertyChanged("ball_type_id");
            }
        }

        private int _ild_id;
        public int ild_id
        {
            get { return _ild_id; }
            set
            {
                _ild_id = value;
                RaisePropertyChanged("ild_id");
            }
        }

        private string _ild;
        public string ild
        {
            get { return _ild; }
            set
            {
                _ild = value;
                RaisePropertyChanged("ild");
            }
        }

        private string _ild_type;
        public string ild_type
        {
            get { return _ild_type; }
            set
            {
                _ild_type = value;
                RaisePropertyChanged("ild_type");
            }
        }


        private int _ink_id;
        public int ink_id
        {
            get { return _ink_id; }
            set
            {
                _ink_id = value;
                RaisePropertyChanged("ink_id");
            }
        }

        private string _ink;
        public string ink
        {
            get { return _ink; }
            set
            {
                _ink = value;
                RaisePropertyChanged("ink");
            }
        }

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

        private string _description;
        public string description
        {
            get { return _description; }
            set
            {
                _description = value;
                RaisePropertyChanged("description");
            }
        }

        private string _TipType;
        public string TipType
        {
            get { return _TipType; }
            set
            {
                _TipType = value;
                RaisePropertyChanged("TipType");
            }
        }

        private string _TipCode;
        public string TipCode
        {
            get { return _TipCode; }
            set
            {
                _TipCode = value;
                RaisePropertyChanged("TipCode");
            }
        }

        private string _BlankCode;
        public string BlankCode
        {
            get { return _BlankCode; }
            set
            {
                _BlankCode = value;
                RaisePropertyChanged("BlankCode");
            }
        }

        private string _Blank;
        public string Blank
        {
            get { return _Blank; }
            set
            {
                _Blank = value;
                RaisePropertyChanged("Blank");
            }
        }
       
        private bool _Select;//scaler
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;
                    RaisePropertyChanged("Select");
                }
            }
        }
    }
    public class MultipleContext_MIS_Pro_MFG
    {
        public List<ZADM_M010_P> ItemDetails { get; set; }
        public List<ADM_M024_P> Employee { get; set; }
        public List<ADM_M038_B_P> UnitDetails { get; set; }
        public List<ZADM_M004_P> WireTypeDetails { get; set; }
        public List<ZADM_M002_P> BallTypeDetails { get; set; }
        public List<ZADM_M007_P> ILDDetails { get; set; }
        public List<ZADM_M006_P> InkDetails { get; set; }
        public List<ZADM_M010_P> TipTypes { get; set; }
        public List<ZADM_M010_P> BlankDetails { get; set; }
        public List<Rpt_MIS_Pro_MFG> RptProduction { get; set; }

    }
}
