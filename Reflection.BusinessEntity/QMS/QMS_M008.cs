using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_M008 : ObjectBase
    {
        
        private string _rig_code;
        public string rig_code
        {
            get { return _rig_code; }
            set { _rig_code = value; RaisePropertyChanged("rig_code"); }
        }

        private int _id;
        public int id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }

        private string _lab_code;
        public string lab_code
        {
            get { return _lab_code; }
            set { _lab_code = value; RaisePropertyChanged("lab_code"); }
        }

        private string _rig_abbr;
        public string rig_abbr
        {
            get { return _rig_abbr; }
            set { _rig_abbr = value; RaisePropertyChanged("rig_abbr"); }
        }

        private string _rig_name;
        public string rig_name
        {
            get { return _rig_name; }
            set { _rig_name = value; RaisePropertyChanged("rig_name"); }
        }

        private string _contprsn_code;
        public string contprsn_code
        {
            get { return _contprsn_code; }
            set { _contprsn_code = value; RaisePropertyChanged("contprsn_code"); }
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

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set { _active = value; RaisePropertyChanged("active"); }

        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }

        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }

        }

        //scalar
        private string _EmpName;
        public string EmpName
        {
            get { return _EmpName; }
            set { _EmpName = value; RaisePropertyChanged("EmpName"); }

        }

        private string _lab_name;
        public string lab_name
        {
            get { return _lab_name; }
            set { _lab_name = value; RaisePropertyChanged("lab_name"); }

        }

        public string XmlDataDocument_FlipGrid { get; set; }
    }
    public class MultipleContext_QMS_M008
    {
        public List<QMS_M008> MasterEntity { get; set; }
        public List<ADM_M024_P> ContactPersonList { get; set; }
        public List<ADM_M003_B_P> LabrotaryList { get; set; }
        public List<QMS_M008_Flip> BackFlipList { get; set; }
    }
}
