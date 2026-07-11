using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_M0034 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _sp_code;
        public string sp_code
        {
            get { return _sp_code; }
            set
            {
                _sp_code = value;
                RaisePropertyChanged("sp_code");
            }
        }

        private string _sp_desc;
        public string sp_desc
        {
            get { return _sp_desc; }
            set
            {
                _sp_desc = value;
                RaisePropertyChanged("sp_desc");
            }
        }

        private string _sample_type;
        public string sample_type
        {
            get { return _sample_type; }
            set
            {
                _sample_type = value;
                RaisePropertyChanged("sample_type");
            }
        }

        private string _sp_type_desc;
        public string sp_type_desc
        {
            get { return _sp_type_desc; }
            set
            {
                _sp_type_desc = value;
                RaisePropertyChanged("sp_type_desc");
            }
        }

        private string _valuation_mode;
        public string valuation_mode
        {
            get { return _valuation_mode; }
            set
            {
                _valuation_mode = value;
                RaisePropertyChanged("valuation_mode");
            }
        }

        private string _multi_sample;
        public string multi_sample
        {
            get { return _multi_sample; }
            set
            {
                _multi_sample = value;
                RaisePropertyChanged("multi_sample");
            }
        }

        private Nullable<int> _multi_sample_no;
        public Nullable<int> multi_sample_no
        {
            get { return _multi_sample_no; }
            set
            {
                _multi_sample_no = value;
                RaisePropertyChanged("multi_sample_no");
            }
        }

        private Nullable<int> _no_of_units;
        public Nullable<int> no_of_units
        {
            get { return _no_of_units; }
            set
            {
                _no_of_units = value;
                RaisePropertyChanged("no_of_units");
            }
        }

        private Nullable<int> _accept_no;
        public Nullable<int> accept_no
        {
            get { return _accept_no; }
            set
            {
                _accept_no = value;
                RaisePropertyChanged("accept_no");
            }
        }

        private string _k_factor;
        public string k_factor
        {
            get { return _k_factor; }
            set
            {
                _k_factor = value;
                RaisePropertyChanged("k_factor");
            }
        }

        private string _sp_used;
        public string sp_used
        {
            get { return _sp_used; }
            set
            {
                _sp_used = value;
                RaisePropertyChanged("sp_used");
            }
        }

        private string _sample_scheme;
        public string sample_scheme
        {
            get { return _sample_scheme; }
            set
            {
                _sample_scheme = value;
                RaisePropertyChanged("sample_scheme");
            }
        }

        private string _insp_severity;
        public string insp_severity
        {
            get { return _insp_severity; }
            set
            {
                _insp_severity = value;
                RaisePropertyChanged("insp_severity");
            }
        }

        private decimal? _sample_size;
        public decimal? sample_size
        {
            get { return _sample_size; }
            set
            {
                _sample_size = value;
                RaisePropertyChanged("sample_size");
            }
        }

        private Nullable<decimal> _accept_no_per;
        public Nullable<decimal> accept_no_per
        {
            get { return _accept_no_per; }
            set
            {
                _accept_no_per = value;
                RaisePropertyChanged("accept_no_per");
            }
        }

        private string _ind_insp_point;
        public string ind_insp_point
        {
            get { return _ind_insp_point; }
            set
            {
                _ind_insp_point = value;
                RaisePropertyChanged("ind_insp_point");
            }
        }

        private Nullable<int> _insp_freq;
        public Nullable<int> insp_freq
        {
            get { return _insp_freq; }
            set
            {
                _insp_freq = value;
                RaisePropertyChanged("insp_freq");
            }
        }

        private Nullable<int> _aql_value;
        public Nullable<int> aql_value
        {
            get { return _aql_value; }
            set
            {
                _aql_value = value;
                RaisePropertyChanged("aql_value");
            }
        }

        private string _control_chart_type;
        public string control_chart_type
        {
            get { return _control_chart_type; }
            set
            {
                _control_chart_type = value;
                RaisePropertyChanged("control_chart_type");
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

        private string _active;
        public string active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }

        

        private string _location_id;
        public string location_id
        {
            get { return _location_id; }
            set
            {
                _location_id = value;
                RaisePropertyChanged("location_id");
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

        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set
            {
                _lang_key = value;
                RaisePropertyChanged("lang_key");
            }
        }
        private string _sample_size_uom;
        public string sample_size_uom
        {
            get { return _sample_size_uom; }
            set
            {
                _sample_size_uom = value;
                RaisePropertyChanged("sample_size_uom");
            }
        }
        //public string XmlDataDocument_QMS_M034_Flip { get; set; }
        //scalar

        private string _scheme_name;
        public string scheme_name
        {
            get { return _scheme_name; }
            set
            {
                _scheme_name = value;
                RaisePropertyChanged("scheme_name");
            }
        }

        private string _severity_name;
        public string severity_name
        {
            get { return _severity_name; }
            set
            {
                _severity_name = value;
                RaisePropertyChanged("severity_name");
            }
        }

        private string _mode_name;
        public string mode_name
        {
            get { return _mode_name; }
            set
            {
                _mode_name = value;
                RaisePropertyChanged("mode_name");
            }
        }

        private string _type_name;
        public string type_name
        {
            get { return _type_name; }
            set
            {
                _type_name = value;
                RaisePropertyChanged("type_name");
            }
        }

        private bool _x1;
        public bool x1
        {
            get { return _x1; }
            set
            {
                _x1 = value;
                RaisePropertyChanged("x1");
            }
        }

        private bool _x2;
        public bool x2
        {
            get { return _x2; }
            set
            {
                _x2 = value;
                RaisePropertyChanged("x2");
            }
        }

        private bool _x3;
        public bool x3
        {
            get { return _x3; }
            set
            {
                _x3 = value;
                RaisePropertyChanged("x3");
            }
        }

        private bool _x4;
        public bool x4
        {
            get { return _x4; }
            set
            {
                _x4 = value;
                RaisePropertyChanged("x4");
            }
        }

        private bool _r1;
        public bool r1
        {
            get { return _r1; }
            set
            {
                _r1 = value;
                RaisePropertyChanged("r1");
            }
        }

        private bool _r2;
        public bool r2
        {
            get { return _r2; }
            set
            {
                _r2 = value;
                RaisePropertyChanged("r2");
            }
        }

        private bool _r3;
        public bool r3
        {
            get { return _r3; }
            set
            {
                _r3 = value;
                RaisePropertyChanged("r3");
            }
        }

    }

    public class MC_QMS_M0034 : MC_QMS_BE
    {
        public List<QMS_M0034> MASTER_LIST { get; set; }
    }

    //public class MultipleContext_QMS_M034
    //{
    //    public List<QMS_M034_Flip> BackFlipData { get; set; }
    //    public List<QMS_M037_P> SampleTypeMaster { get; set; }
    //    public List<QMS_M036_P> ValuationMode { get; set; }
    //    public List<QMS_M038_P> InspSeverity { get; set; }
    //    public List<QMS_M035_P> SampleScheme { get; set; }
    //    public List<QMS_M0034> MasterEntity { get; set; }
    //    public List<COM_T003> Attachment { get; set; }
    //}
}
