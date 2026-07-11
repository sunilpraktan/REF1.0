using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ZADM_M013 : ObjectBase
    {
        public int machine_id { get; set; }
        public string machinecode { get; set; }
        public Nullable<int> machine_type_id { get; set; }
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
        public Nullable<int> machine_subtype_id { get; set; }
        public string mctype { get; set; }
        public string add_by { get; set; }
        public Nullable<System.DateTime> add_date { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public Nullable<int> machinecap_id { get; set; }
        public string comp_code { get; set; }
        public string EmpId { get; set; }
        public string editby { get; set; }
        public string location_Id { get; set; }
        public string CompName { get; set; }
        public string machine_type { get; set; }
        public string machine_subtype { get; set; }
        public string EmpName { get; set; }
        public string Make { get; set; }
    }

}
