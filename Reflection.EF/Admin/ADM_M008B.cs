using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.Admin
{
    public partial class ADM_M008B : ObjectBase
    {
        public int id { get; set; }
        public string TranCode { get; set; }
        public string TranName { get; set; }
        public string MenuName { get; set; }
        public string SbModCod { get; set; }
        public Nullable<int> UserTypCode { get; set; }
        public Nullable<int> ParentId { get; set; }
        public Nullable<int> ChildId { get; set; }
        public string location_Id { get; set; }
        public string DisTitl { get; set; }
        public string add_by { get; set; }
        public Nullable<bool> active { get; set; }
        public System.DateTime add_date { get; set; }
        public string editby { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string UserTyp { get; set; }
        public string LoctnNm { get; set; }
        public string Nspace { get; set; }
        public string ClsFileName { get; set; }
        public string Npath { get; set; }
        public string lang_key { get; set; }
    }
}
