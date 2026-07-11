using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.Production
{
    public class MIS_PDI_Entity : ObjectBase
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

        private Nullable<DateTime> _StartDate;
        public Nullable<DateTime> StartDate
        {
            get { return _StartDate; }
            set
            {
                _StartDate = value;
                RaisePropertyChanged("StartDate");
            }
        }

        private Nullable<DateTime> _EndDate;
        public Nullable<DateTime> EndDate
        {
            get { return _EndDate; }
            set
            {
                _EndDate = value;
                RaisePropertyChanged("EndDate");
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
                RaisePropertyChanged("Location_Id");
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

        private string _machinecode;
        public string machinecode
        {
            get { return _machinecode; }
            set
            {
                _machinecode = value;
                RaisePropertyChanged("machinecode");
            }
        }

        private Nullable<int> _machine_id;
        public Nullable<int> machine_id
        {
            get { return _machine_id; }
            set
            {
                _machine_id = value;
                RaisePropertyChanged("machine_id");
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

        private string _bill_doc;
        public string bill_doc
        {
            get { return _bill_doc; }
            set
            {
                _bill_doc = value;
                RaisePropertyChanged("bill_doc");
            }
        }

        private string _shift;
        public string shift
        {
            get { return _shift; }
            set
            {
                _shift = value;
                RaisePropertyChanged("shift");
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

        private string _CompName;
        public string CompName
        {
            get { return _CompName; }
            set
            {
                _CompName = value;
                RaisePropertyChanged("CompName");
            }
        }

        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set
            {
                _PartyId = value;
                RaisePropertyChanged("PartyId");
            }
        }

        private string _PartyNm;
        public string PartyNm
        {
            get { return _PartyNm; }
            set
            {
                _PartyNm = value;
                RaisePropertyChanged("PartyNm");
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

        private Nullable<int> _ink_id;
        public Nullable<int> ink_id
        {
            get { return _ink_id; }
            set
            {
                _ink_id = value;
                RaisePropertyChanged("ink_id");
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

        private Nullable<int> _ild_id;
        public Nullable<int> ild_id
        {
            get { return _ild_id; }
            set
            {
                _ild_id = value;
                RaisePropertyChanged("ild_id");
            }
        }



    }
    public class MultipleContext_MIS_PDI_Entry
    {
        public List<ADM_M028_P> PartyMaster { get; set; }
        public List<ZADM_M013_P> machineDetails { get; set; }
        public List<ZADM_M007_P> ILDDetails { get; set; }
        public List<ZADM_M006_P> InkDetails { get; set; }
        public List<ADM_M042_P> ShiftDetails { get; set; }
        public List<Rpt_MIS_PDI_Entry> RptPDIEntryList { get; set; }

    }
}

