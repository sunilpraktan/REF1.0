using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_M0001 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _tsb_code;
        private string _traceability;
        private string _active;

        public string tsb_code
        {
            get { return _tsb_code; }
            set
            {
                _tsb_code = value;
                RaisePropertyChanged("tsb_code");
            }
        }
        public string traceability
        {
            get { return _traceability; }
            set
            {
                _traceability = value;
                RaisePropertyChanged("traceability");
            }
        }
        public string active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
        private bool? _selected { get; set; }
        public bool? selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value; RaisePropertyChanged("selected");
                }
            }
        }

    }

    public class MC_QMS_M0001 : MC_QMS_BE
    {
        public ObservableCollection<QMS_M0001> MASTER_LIST { get; set; }
    }

    public class QMS_M0039 : ObjectBase // NOTE: proper class not constructed with get set and all fields of table
    {
        public string insp_type { get; set; }
        public string short_text { get; set; }
        public string tl_type { get; set; }
        public string not_type { get; set; }
        public string notification_type { get; set; }
        public string usage_code { get; set; }
        public string active { get; set; }
    }
    public class QMS_M0047 : ObjectBase // NOTE: proper class not constructed with get set and all fields of table
    {
        public string insp_type { get; set; }
        public string lot_origin { get; set; }
        public string origin_var { get; set; }
        public string active { get; set; }

        //Scalar
        public string short_text { get; set; }
        public string lo_text { get; set; } // lot_origin name

        public override string ToString()
        {
            return string.Format("{0}", insp_type);
        }

    }
    public class QMS_M0048 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _fa_code;
        private string _f_action;
        private string _fa_use;
        private string _active;
        public string fa_code
        {
            get { return _fa_code; }
            set
            {
                _fa_code = value;
                RaisePropertyChanged("fa_code");
            }
        }
        public string f_action
        {
            get { return _f_action; }
            set
            {
                _f_action = value;
                RaisePropertyChanged("f_action");
            }
        }
        public string fa_use
        {
            get { return _fa_use; }
            set
            {
                _fa_use = value;
                RaisePropertyChanged("fa_use");
            }
        }
        public string active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
        private bool? _selected { get; set; }
        public bool? selected
        {
            get { return _selected; }
            set
            {
                if (_selected != value)
                {
                    _selected = value; RaisePropertyChanged("selected");
                }
            }
        }

    }
    public class QMS_M0031
    {
        public string def_class { get; set; }
        public string short_text { get; set; }
        public decimal? quality_score { get; set; }
        public DateTime? valid_from { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", def_class);
        }
    }
    public class QMS_M0032
    {
        public string prof_type { get; set; }
        public string short_text { get; set; }
        public string ind_set { get; set; }
        public string ind_value { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", prof_type);
        }
    }

    public class MC_QMS_M0048 : MC_QMS_BE
    {
        public ObservableCollection<QMS_M0048> MASTER_LIST { get; set; }
    }
    public class MC_QMS_M0033 : MC_QMS_BE
    {
        public List<QMS_M0033> MasterList { get; set; }
        public ObservableCollection<QMS_M0033_A> ItemsEntity { get; set; }
        public List<QMS_M0031> DefectClassList { get; set; }
        public List<QMS_M0032> ProfileTypeList { get; set; }
        
    }
}
