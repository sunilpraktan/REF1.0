using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.HRMS.Production
{
    public partial class PPC_M001 : ObjectBase
    {
        public string wc_code { get; set; }
        public int machine_id { get; set; }
        public string machinecode { get; set; }
        //public Nullable<int> machine_type_id { get; set; }
        public string machinedesc { get; set; }
        public string packingcode { get; set; }
        public Nullable<decimal> machineorder { get; set; }
        public Nullable<int> make_id { get; set; }
        public string electricitypara { get; set; }
        public string mechpara { get; set; }
        public string machinesrno { get; set; }
        public string actualsrno { get; set; }
        public string connload { get; set; }
        public string otherpara { get; set; }
        public string purchaseyr { get; set; }
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        //public Nullable<int> machine_subtype_id { get; set; }
        public string mctype { get; set; }
        public string EmpId { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<int> machinecap_id { get; set; }
        public string engineer { get; set; }
        public string wc_tp_code { get; set; }
        public string wc_stp_code { get; set; }
        public string wc_cat { get; set; }
        public string place { get; set; }
        public string cost_center { get; set; }
        public string profit_center { get; set; }
        public string responsible_person { get; set; }
        public string unit_code { get; set; }
        public string gr_code { get; set; }
        public Nullable<System.DateTime> start_dt { get; set; }
        public Nullable<System.DateTime> end_dt { get; set; }
        public string wc_short_name { get; set; }
        public string cap_code { get; set; }
        public string q_time { get; set; }
        public string q_time_unit { get; set; }
        public string min_q_time { get; set; }
        public string min_q_time_unit { get; set; }
        public string setup_time { get; set; }
        public string machine_time { get; set; }
        public string labour_time { get; set; }
        public string control_key { get; set; }
        public string ind_backflushing { get; set; }
        public string PartyId { get; set; }
        public string dimension_work { get; set; }
        public string plan_version { get; set; }
        public Nullable<bool> active { get; set; }

        //XML doc
        public string XmlDataDocument_PPC_M001_Flip { get; set; }

    }

    public partial class PPC_M002 : ObjectBase
    {
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string op_code { get; set; }
        public string op_desc { get; set; }
        public string act_type { get; set; }

    }

    public class PPC_M003 : ObjectBase
    {
        public string comp_code { get; set; }
        public string location_Id { get; set; }
        public string var_reson { get; set; }
        public string reson_desc { get; set; }

    }
}
