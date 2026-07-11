using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Production
{
    public class MIS_BOM_MRPEntity : ObjectBase
    {
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

        private Nullable<decimal> _qty;
        public Nullable<decimal> qty
        {
            get { return _qty; }
            set
            {
                _qty = value;
                RaisePropertyChanged("qty");
            }
        }
    }

   public class MultipleContextMIS_BOM_MRP
    {
        public List<ENG_T001_P> BOMList { get; set; }
        public List<Rpt_BillOfMaterial> Rpt_BillOfMaterialReport { get; set; }
        public ObservableCollection<MM_T003_A> ItemsEntity { get; set; }
        public List<MM_T003> MasterEntityIndent { get; set; }
        public List<ADM_M038_B_P> UnitList { get; set; }
    }
}
