using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_M0044:ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private string _cont_code;
        private string _spec_code;
        private string _short_text;
        private double _qty;
        private string _unit_code;
        private string _active;

        public string cont_code
        {
            get { return _cont_code; }
            set
            {
                _cont_code = value;
                RaisePropertyChanged("cont_code");
            }
        }
        public string spec_code
        {
            get { return _spec_code; }
            set
            {
                _spec_code = value;
                RaisePropertyChanged("spec_code");
            }
        }
        public string short_text
        {
            get { return _short_text; }
            set
            {
                _short_text = value;
                RaisePropertyChanged("short_text");
            }
        }
        public double qty
        {
            get { return _qty; }
            set
            {
                _qty = value;
                RaisePropertyChanged("qty");
            }
        }
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                _unit_code = value;
                RaisePropertyChanged("unit_code");
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

   

    public class MC_QMS_M0044 : MC_QMS_BE
    { 
        public ObservableCollection<QMS_M0044> MASTER_LIST { get; set; }
    }

}
