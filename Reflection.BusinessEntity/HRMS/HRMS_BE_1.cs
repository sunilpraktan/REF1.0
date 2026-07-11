using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.HRMS
{
    public class STD_HRMS_BE
    {
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string emp_id { get; set; }
        public string emp_name { get; set; }
        public string dept_code { get; set; }
        public string dept_name { get; set; }
        public string dsgn_code { get; set; }
        public string dsgn_name { get; set; }

    }
    public class HRM_M0024 : ObjectBase
    {
        private int? _id;
        public int? id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }
        private string _qf_code;
        public string qf_code
        {
            get { return _qf_code; }
            set { _qf_code = value; RaisePropertyChanged("qf_code"); }
        }

        private string _qf_name;
        public string qf_name
        {
            get { return _qf_name; }
            set { _qf_name = value; RaisePropertyChanged("qf_name"); }

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
    }
    public class MC_HRM_M0024 : MC_ADM_BE
    {
        public ObservableCollection<HRM_M0024> MASTER_LIST { get; set; }

    }

    public class HRM_M0026 : ObjectBase
    {
        private int? _id;
        public int? id
        {
            get { return _id; }
            set { _id = value; RaisePropertyChanged("id"); }
        }
        private string _desig_code;
        public string desig_code
        {
            get { return _desig_code; }
            set { _desig_code = value; RaisePropertyChanged("desig_code"); }
        }

        private string _short_text;
        public string short_text
        {
            get { return _short_text; }
            set { _short_text = value; RaisePropertyChanged("short_text"); }

        }
        private string _desig_name;
        public string desig_name
        {
            get { return _desig_name; }
            set { _desig_name = value; RaisePropertyChanged("desig_name"); }

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
    }
    public class MC_HRM_M0026 : MC_ADM_BE
    {
        public ObservableCollection<HRM_M0026> MASTER_LIST { get; set; }

    }

}
