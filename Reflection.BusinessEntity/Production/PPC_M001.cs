using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.Production
{
    public class PPC_M001 : ObjectBase
    {
        private string _wc_code;
        public string wc_code
        {
            get { return _wc_code; }
            set
            {
                _wc_code = value; RaisePropertyChanged("wc_code");
            }
        }

        private int _machine_id;
        public int machine_id
        {
            get { return _machine_id; }
            set
            {
                _machine_id = value; RaisePropertyChanged("machine_id");
            }
        }

        private string _machinecode;
        public string machinecode
        {
            get { return _machinecode; }
            set
            {
                _machinecode = value; RaisePropertyChanged("machinecode");
            }
        }

        //private Nullable<int> _machine_type_id;
        //public Nullable<int> machine_type_id
        //{
        //    get { return _machine_type_id; }
        //    set
        //    {
        //        _machine_type_id = value; RaisePropertyChanged("machine_type_id");
        //    }
        //}

        private string _machinedesc;
        public string machinedesc
        {
            get { return _machinedesc; }
            set
            {
                _machinedesc = value; RaisePropertyChanged("machinedesc");
            }
        }

        private string _packingcode;
        public string packingcode
        {
            get { return _packingcode; }
            set
            {
                _packingcode = value; RaisePropertyChanged("packingcode");
            }
        }

        private Nullable<decimal> _machineorder;
        public Nullable<decimal> machineorder
        {
            get { return _machineorder; }
            set
            {
                _machineorder = value; RaisePropertyChanged("machineorder");
            }
        }

        private Nullable<int> _make_id;
        public Nullable<int> make_id
        {
            get { return _make_id; }
            set
            {
                _make_id = value; RaisePropertyChanged("make_id");
            }
        }

        private string _electricitypara;
        public string electricitypara
        {
            get { return _electricitypara; }
            set
            {
                _electricitypara = value; RaisePropertyChanged("electricitypara");
            }
        }

        private string _mechpara;
        public string mechpara
        {
            get { return _mechpara; }
            set
            {
                _mechpara = value; RaisePropertyChanged("mechpara");
            }
        }

        private string _machinesrno;
        public string machinesrno
        {
            get { return _machinesrno; }
            set
            {
                _machinesrno = value; RaisePropertyChanged("machinesrno");
            }
        }

        private string _actualsrno;
        public string actualsrno
        {
            get { return _actualsrno; }
            set
            {
                _actualsrno = value; RaisePropertyChanged("actualsrno");
            }
        }

        private string _connload;
        public string connload
        {
            get { return _connload; }
            set
            {
                _connload = value; RaisePropertyChanged("connload");
            }
        }

        private string _otherpara;
        public string otherpara
        {
            get { return _otherpara; }
            set
            {
                _otherpara = value; RaisePropertyChanged("otherpara");
            }
        }

        private string _purchaseyr;
        public string purchaseyr
        {
            get { return _purchaseyr; }
            set
            {
                _purchaseyr = value; RaisePropertyChanged("purchaseyr");
            }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                _comp_code = value; RaisePropertyChanged("comp_code");
            }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value; RaisePropertyChanged("location_Id");
            }
        }

        //private Nullable<int> _machine_subtype_id;
        //public Nullable<int> machine_subtype_id
        //{
        //    get { return _machine_subtype_id; }
        //    set
        //    {
        //        _machine_subtype_id = value; RaisePropertyChanged("machine_subtype_id");
        //    }
        //}

        private string _mctype;
        public string mctype
        {
            get { return _mctype; }
            set
            {
                _mctype = value; RaisePropertyChanged("mctype");
            }
        }

        private string _EmpId;
        public string EmpId
        {
            get { return _EmpId; }
            set
            {
                _EmpId = value; RaisePropertyChanged("EmpId");
            }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value; RaisePropertyChanged("add_by");
            }
        }

        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value; RaisePropertyChanged("add_date");
            }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set
            {
                _editby = value; RaisePropertyChanged("editby");
            }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value; RaisePropertyChanged("edit_date");
            }
        }

        private Nullable<int> _machinecap_id;
        public Nullable<int> machinecap_id
        {
            get { return _machinecap_id; }
            set
            {
                _machinecap_id = value; RaisePropertyChanged("machinecap_id");
            }
        }

        private string _engineer;
        public string engineer
        {
            get { return _engineer; }
            set
            {
                _engineer = value; RaisePropertyChanged("engineer");
            }
        }

        private string _wc_tp_code;
        public string wc_tp_code
        {
            get { return _wc_tp_code; }
            set
            {
                _wc_tp_code = value; RaisePropertyChanged("wc_tp_code");
            }
        }

        private string _wc_stp_code;
        public string wc_stp_code
        {
            get { return _wc_stp_code; }
            set
            {
                _wc_stp_code = value; RaisePropertyChanged("wc_stp_code");
            }
        }

        private string _wc_cat;
        public string wc_cat
        {
            get { return _wc_cat; }
            set
            {
                _wc_cat = value; RaisePropertyChanged("wc_cat");
            }
        }

        private string _place;
        public string place
        {
            get { return _place; }
            set
            {
                _place = value; RaisePropertyChanged("place");
            }
        }

        private string _cost_center;
        public string cost_center
        {
            get { return _cost_center; }
            set
            {
                _cost_center = value; RaisePropertyChanged("cost_center");
            }
        }

        private string _profit_center;
        public string profit_center
        {
            get { return _profit_center; }
            set
            {
                _profit_center = value; RaisePropertyChanged("profit_center");
            }
        }

        private string _responsible_person;
        public string responsible_person
        {
            get { return _responsible_person; }
            set
            {
                _responsible_person = value; RaisePropertyChanged("responsible_person");
            }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                _unit_code = value; RaisePropertyChanged("unit_code");
            }
        }

        private string _gr_code;
        public string gr_code
        {
            get { return _gr_code; }
            set
            {
                _gr_code = value; RaisePropertyChanged("gr_code");
            }
        }

        
        private Nullable<System.DateTime> _start_dt;
        public Nullable<System.DateTime> start_dt
        {
            get { return _start_dt; }
            set
            {
                _start_dt = value; RaisePropertyChanged("start_dt");
            }
        }

        private Nullable<System.DateTime> _end_dt;
        public Nullable<System.DateTime> end_dt
        {
            get { return _end_dt; }
            set
            {
                _end_dt = value; RaisePropertyChanged("end_dt");
            }
        }

        private string _wc_short_name;
        public string wc_short_name
        {
            get { return _wc_short_name; }
            set
            {
                _wc_short_name = value; RaisePropertyChanged("wc_short_name");
            }
        }

        private string _cap_code;
        public string cap_code
        {
            get { return _cap_code; }
            set
            {
                _cap_code = value; RaisePropertyChanged("cap_code");
            }
        }

        private string _q_time;
        public string q_time
        {
            get { return _q_time; }
            set
            {
                _q_time = value; RaisePropertyChanged("q_time");
            }
        }

        private string _q_time_unit;
        public string q_time_unit
        {
            get { return _q_time_unit; }
            set
            {
                _q_time_unit = value; RaisePropertyChanged("q_time_unit");
            }
        }

        private string _min_q_time;
        public string min_q_time
        {
            get { return _min_q_time; }
            set
            {
                _min_q_time = value; RaisePropertyChanged("min_q_time");
            }
        }

        private string _min_q_time_unit;
        public string min_q_time_unit
        {
            get { return _min_q_time_unit; }
            set
            {
                _min_q_time_unit = value; RaisePropertyChanged("min_q_time_unit");
            }
        }

        private string _setup_time;
        public string setup_time
        {
            get { return _setup_time; }
            set
            {
                _setup_time = value; RaisePropertyChanged("setup_time");
            }
        }

        private string _machine_time;
        public string machine_time
        {
            get { return _machine_time; }
            set
            {
                _machine_time = value; RaisePropertyChanged("machine_time");
            }
        }

        private string _labour_time;
        public string labour_time
        {
            get { return _labour_time; }
            set
            {
                _labour_time = value; RaisePropertyChanged("labour_time");
            }
        }

        private string _control_key;
        public string control_key
        {
            get { return _control_key; }
            set
            {
                _control_key = value; RaisePropertyChanged("control_key");
            }
        }

        private string _ind_backflushing;
        public string ind_backflushing
        {
            get { return _ind_backflushing; }
            set
            {
                _ind_backflushing = value; RaisePropertyChanged("ind_backflushing");
            }
        }

        private string _PartyId;
        public string PartyId
        {
            get { return _PartyId; }
            set
            {
                _PartyId = value; RaisePropertyChanged("PartyId");
            }
        }

        private string _dimension_work;
        public string dimension_work
        {
            get { return _dimension_work; }
            set
            {
                _dimension_work = value; RaisePropertyChanged("dimension_work");
            }
        }

        private string _plan_version;
        public string plan_version
        {
            get { return _plan_version; }
            set
            {
                _plan_version = value; RaisePropertyChanged("plan_version");
            }
        }

        private Nullable<bool> _active;
        public Nullable<bool> active
        {
            get { return _active; }
            set
            {
                _active = value; RaisePropertyChanged("active");
            }
        }

        //XML doc         
        public string XmlDataDocument_PPC_M001_Flip { get; set; }

    }
    public class MultipleContext_PPC_M001
    {
        public List<PPC_M001_BackFlip> BackFlipEntity { get; set; }
        public List<ADM_M002_P> Company { get; set; }
        public List<ADM_M032_P> Make { get; set; }
        public List<ADM_M024_P> Employee { get; set; }
        public List<PPC_M001> MasterData { get; set; }
        public List<PPC_M001_A_P> WCType { get; set; }
        public List<PPC_M001_B_P> WCSubType { get; set; }
        public List<PPC_M001_C_P> WCCategory { get; set; }
        public List<PPC_M001_D_P> WCPlace { get; set; }
        public List<PPC_M001_E_P> WCCapacity { get; set; }
        public List<PPC_M001_F_P> WCControlKey { get; set; }
        public List<PPC_M001_G_P> WCGroup { get; set; }
        public List<ADM_M038_B_P> Unit { get; set; }
        public List<ADM_M028_P> Party { get; set; }
        public List<ADM_M003_P> Location { get; set; }
    }
    public class PPC_M001_BackFlip
    {
        public string wc_code { get; set; }
        public string wc_tp_code { get; set; }
        public string wc_stp_code { get; set; }
        public string wc_cat { get; set; }
        public string place { get; set; }
        public string cap_code { get; set; }
        public string control_key { get; set; }
        public string gr_code { get; set; }
        public string location_Id { get; set; }
        public Nullable<System.DateTime> start_dt { get; set; }
        public string machinecode { get; set; }
        public string machinedesc { get; set; }

    }

    public partial class PPC_M002 : ObjectBase
    {
       
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                _comp_code = value; RaisePropertyChanged("comp_code");
            }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value; RaisePropertyChanged("location_Id");
            }
        }
        private string _op_code;
        public string op_code
        {
            get { return _op_code; }
            set
            {
                _op_code = value; RaisePropertyChanged("op_code");
            }
        }
        private string _op_desc;
        public string op_desc
        {
            get { return _op_desc; }
            set
            {
                _op_desc = value; RaisePropertyChanged("op_desc");
            }
        }
        private string _act_type;
        public string act_type
        {
            get { return _act_type; }
            set
            {
                _act_type = value; RaisePropertyChanged("act_type");
            }
        }

    }

    public class PPC_M003 : ObjectBase
    {
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string var_reson { get; set; }
        public string reson_desc { get; set; }

    }
}
