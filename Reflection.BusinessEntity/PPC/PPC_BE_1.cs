using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.BusinessEntity.PPC
{
    public class PPC_M0002 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        //private string _client;
        //public string client
        //{
        //    get { return _client; }
        //    set
        //    {
        //        _client = value;
        //        RaisePropertyChanged("client");
        //    }
        //}
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
        private string _op_code;
        public string op_code
        {
            get { return _op_code; }
            set
            {
                _op_code = value;
                RaisePropertyChanged("op_code");
            }
        }


        private string _op_desc;
        public string op_desc
        {
            get { return _op_desc; }
            set
            {
                _op_desc = value;
                RaisePropertyChanged("op_desc");
            }
        }

        private string _op_name;
        public string op_name
        {
            get { return _op_name; }
            set
            {
                _op_name = value;
                RaisePropertyChanged("op_name");
            }
        }
        private string _act_type;
        public string act_type
        {
            get { return _act_type; }
            set
            {
                _act_type = value;
                RaisePropertyChanged("act_type");
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
    public class STD_PPC_BE
    {
        public string client { get; set; }
        public string comp_code { get; set; }
        public string location_id { get; set; }
        public string wc_code { get; set; }
        public string wc_name { get; set; }
        public string short_text { get; set; }
        public string text_name { get; set; }


    }


    public class MC_PPC_M0002 : MC_PPC_BE
    {
        public ObservableCollection<PPC_M0002> MASTER_LIST { get; set; }
    }

}
