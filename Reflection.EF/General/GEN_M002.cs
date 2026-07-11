using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.General
{
    public partial class ADM_M054 : ObjectBase
    {
        public string cp_code { get; set; }
        public int id { get; set; }
        public string party_id { get; set; }
        public string sal_code { get; set; }
        public string f_name { get; set; }
        public string m_name { get; set; }
        public string l_name { get; set; }
        public string nick_name { get; set; }
        public string addr_code { get; set; }
        public string cp_code1 { get; set; }
        public string gender { get; set; }
        public byte[] photo { get; set; }
        public string ind_mar_status { get; set; }
        public string dept_code { get; set; }
        public string desig_code { get; set; }
        public Nullable<bool> active { get; set; }
        public string t_status { get; set; }
        public string add_by { get; set; }
        public System.DateTime add_date { get; set; }
        public string edit_by { get; set; }
        public Nullable<System.DateTime> edit_date { get; set; }
        public string location_Id { get; set; }
        public string comp_code { get; set; }
        public string lang_key { get; set; }
        //Scaler
        public string party_name { get; set; }
        public int? address_id { get; set; }
        public string address_name { get; set; }
        public string symbol { get; set; }
        public string DesigName { get; set; }
        public string DeptName { get; set; }
    }
}
