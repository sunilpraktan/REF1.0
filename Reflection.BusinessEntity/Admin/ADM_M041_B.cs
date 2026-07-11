using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity.Admin
{
    public class ADM_M041_B:ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        public int id
        {
            get
            {
                return _id;
            }
                
                set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
         }

        private string _sion_no;
        public string sion_no
        {
            get
            {
                return _sion_no;
            }

            set
            {
                _sion_no = value;
                RaisePropertyChanged("sion_no");
            }
        }
        private string _sion_desc;
        public string sion_desc
        {
            get
            {
                return _sion_desc;
            }              
                set
            {
                _sion_desc = value;
                RaisePropertyChanged("sion_desc");
            }
        }
        private string _exp_wire_dia;
        public string exp_wire_dia
        {
            get
            {
                return _exp_wire_dia;
            }
            set
            {
                _exp_wire_dia = value;
                RaisePropertyChanged("exp_wire_dia");
            }
        }

        private decimal? _exp_qty_pcs;
        public decimal? exp_qty_pcs
        {
            get
            {
                return _exp_qty_pcs;
            }
                set
            {
                _exp_qty_pcs = value;
                RaisePropertyChanged("exp_qty_pcs");
            }
         }

        private decimal? _exp_qty_kg;
        public decimal? exp_qty_kg
        {
            get
            {
                return _exp_qty_kg;
            }
            set
            {
                _exp_qty_kg = value;
                RaisePropertyChanged("exp_qty_kg");
            }
        }

        private decimal? _exp_maxlimit_kg;
        public decimal? exp_maxlimit_kg
        {
            get
            {
                return _exp_maxlimit_kg;
            }
            set
            {
                _exp_maxlimit_kg = value;
                RaisePropertyChanged("exp_maxlimit_kg");
            }
        }


        private string _imp_wire_type;
        public string imp_wire_type
        {
            get
            {
                return _imp_wire_type;
            }
            set
            {
                _imp_wire_type = value;
                RaisePropertyChanged("imp_wire_type");
            }
        }

        private string _imp_wire_dia;
        public string imp_wire_dia
        {
            get
            {
                return _imp_wire_dia;
            }
            set
            {
                _imp_wire_dia = value;
                RaisePropertyChanged("imp_wire_dia");
            }
        }

        private decimal? _imp_wire_qty_allowed;
        public decimal? imp_wire_qty_allowed
        {
            get
            {
                return _imp_wire_qty_allowed;
            }
            set
            {
                _imp_wire_qty_allowed = value;
                RaisePropertyChanged("imp_wire_qty_allowed");
            }
        }

        private string _imp_ball_type;
        public string imp_ball_type
        {
            get
            {
                return _imp_ball_type;
            }
            set
            {
                _imp_ball_type = value;
                RaisePropertyChanged("imp_ball_type");
            }
        }


        private string _imp_ball_dia;
        public string imp_ball_dia
        {
            get
            {
                return _imp_ball_dia;
            }
            set
            {
                _imp_ball_dia = value;
                RaisePropertyChanged("imp_ball_dia");
            }
        }

        private decimal? _imp_ball_qty_allowed;
        public decimal? imp_ball_qty_allowed
        {
            get
            {
                return _imp_ball_qty_allowed;
            }
            set
            {
                _imp_ball_qty_allowed = value;
                RaisePropertyChanged("imp_ball_qty_allowed");
            }
        }

        private decimal? _import_value;
        public decimal? import_value
        {
            get
            {
                return _import_value;
            }
            set
            {
                _import_value = value;
                RaisePropertyChanged("import_value");
            }
        }

        private decimal? _imp_maxlimit;
        public decimal? imp_maxlimit
        {
            get
            {
                return _imp_maxlimit;
            }
            set
            {
                _imp_maxlimit = value;
                RaisePropertyChanged("imp_maxlimit");
            }
        }

        private string _add_by;
        public string add_by
        {
            get
            {
                return _add_by;
            }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }

        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get
            {
                return _add_date;

            }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }


        private string _editby;
        public string editby
        {
            get
            {
                return _editby;
            }
            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get
            {
                return _edit_date;

            }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }

        private string _t_status;
        public string t_status
        {
            get
            {
                return _t_status;
            }
            set
            {
                _t_status = value;
                RaisePropertyChanged("t_status");
            }
        }

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get
            {
                return _comp_code;
            }
            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }

        private string _location_Id;
        public string location_Id
        {
            get
            {
                return _location_Id;
            }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }
        private string _lang_key;
        public string lang_key
        {
            get { return _lang_key; }
            set { _lang_key = value; RaisePropertyChanged("lang_key"); }
        }

        public string XmlDataDocument_ADM_M041_B_Flip { get; set; }
        public string XmlDataDocument_ADM_M041_B { get; set; }
    }

    public class MultipleContext_ADM_M041_B
    {
        public List<ADM_M041_B_Flip> FlipGridData { get; set; }// BackFlip
        public List<ADM_M041_B> MasterEntity { get; set; }// MasterEntity
        public List<ZADM_M003_P> WireDia { get; set; }// wire Diameter
        public List<ZADM_M004_P> WireType { get; set; }// wire Type
        public List<ZADM_M001_P> BallDia { get; set; }// Ball Dia Type
        public List<ZADM_M002_P> BallType { get; set; }// Ball Type
        public ObservableCollection<ADM_M041_B> ItemEntity { get; set; }

    }
    public class ADM_M041_B_Flip
    {
        public int id { get; set; }
        public string sion_no { get; set; }
        public string sion_desc { get; set; }
        public string imp_wire_type { get; set; }
        public string imp_wire_dia { get; set; }
        public string imp_ball_type { get; set; }
        public string imp_ball_dia { get; set; }
        public string t_status { get; set; }


    }
}
