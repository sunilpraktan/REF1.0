using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity
{
    public class ADM_M026 : ObjectBase
    {
        private string _desig_code;
        public string desig_code
        {
            get { return _desig_code; }
            set { _desig_code = value; RaisePropertyChanged("desig_code"); }
        }

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _DesigName;
        public string DesigName
        {
            get { return _DesigName; }
            set { _DesigName = value; RaisePropertyChanged("DesigName"); }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }

        }

        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }

        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }

        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }

        }
        //scalar
        public string XmlDataDocument_FlipGrid { get; set; }
    }
    public class MultipleContext_ADM_M026
    {
        public List<ADM_M026> MasterEntity { get; set; }
        public List<ADM_M026_Flip> BackFlipList { get; set; }
    }

}
