using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.Production
{
    public class MIS_QualityEntity : ObjectBase
    {
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

        private string _doc_desc;
        public string doc_desc
        {
            get { return _doc_desc; }
            set
            {
                _doc_desc = value;
                RaisePropertyChanged("doc_desc");
            }
        }


    }

    public class MultipleContextMIS_Quality
    {
        public List<ZADM_M013_P> machineDetails { get; set; }
        public List<Rpt_MIS_PDI_Entry> QualityReport { get; set; }
    }
}
