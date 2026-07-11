using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.QMS
{
    public class TO_BE_CHECK : ObjectBase
    {
        public string doc_no { get; set; }
        public System.DateTime prod_date { get; set; }
        public System.DateTime? clean_date { get; set; }
        public System.DateTime? doc_date { get; set; }
        public string batch_no { get; set; }
        public Nullable<int> machine_id { get; set; }
        public string machinecode { get; set; }
        public Nullable<decimal> counter_q { get; set; }
        public Nullable<decimal> rejection_q { get; set; }
        public string remarks { get; set; }
        public string m_operator { get; set; }
        public string shift_incharge { get; set; }
        public bool active { get; set; }
        public string doc_type { get; set; }
        public string doc_cat { get; set; }
        public string ItemCode { get; set; }
        public string unit_code { get; set; }
        public string EmpName { get; set; }
        public string operatornm { get; set; }
        public string ItemName { get; set; }
        public string t_status { get; set; }
        public string order_no { get; set; }
        public string ref_doc_type { get; set; }
        public string ref_doc_no { get; set; }
        public string wc_code { get; set; }
        public string grade { get; set; }
        public string comp_code { get; set; }
       
        public string doc_desc_user { get; set; }

        private DateTime? _FrmDate;
        public DateTime? FrmDate
        {
            get
            {
                return _FrmDate;
            }
            set
            {
                if (_FrmDate != value)
                {
                    _FrmDate = value;
                    RaisePropertyChanged("FrmDate");
                }
            }
        }
        private DateTime? _ToDate;
        public DateTime? ToDate
        {
            get
            {
                return _ToDate;
            }
            set
            {
                if (_ToDate != value)
                {
                    _ToDate = value;
                    RaisePropertyChanged("ToDate");
                }
            }
        }

    }
    public class MultipleContext_To_Be_Check
    {
        public List<SYS_M013> doc_typeList { get; set; }
        public List<TO_BE_CHECK> MasterEntity { get; set; }

    }
}
