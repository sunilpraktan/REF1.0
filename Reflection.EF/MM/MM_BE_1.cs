using Reflection.EF.SCM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection.EF.MM
{
    //public class MC_MM_T001_BE : MC_MM_BE // Transaction specific MC Class
    //{
    //    public List<MM_T001> MASTER_ENTITY_LIST { get; set; }
    //    public List<MM_T001_A> ITEMS_ENTITY_LIST { get; set; }
    //    public List<MM_T001_B> BATCH_ENTITY_LIST { get; set; }
    //}
    public class MC_MM_T003 : MC_MM_BE // Transaction specific MC Class
    {
        public List<MM_T003> MASTER_ENTITY_LIST { get; set; }
        public List<MM_T003_A> ITEMS_ENTITY_LIST { get; set; }
        public List<MM_T001_B> BATCH_ENTITY_LIST { get; set; }
    }
    public class MC_MM_T004 : MC_MM_BE // Transaction specific MC Class
    {
        public List<MM_T004> MASTER_ENTITY_LIST { get; set; }
    }


    public class MM_M0001
    {
        public string client { get; set; }
        public string comp_code { get; set; }
        public string comp_name { get; set; }
        public string location_id { get; set; }
        public string store_code { get; set; }
        public string store_name { get; set; }
        public string ind_neg_stock { get; set; }
        public string ind_default { get; set; } // Default Storage Location
        public string rec_ship_point { get; set; } //NOTE: name not appropriat


        //NOTE: Remove this fields.
        public int? id { get; set; }
        public string CompName { get; set; }
        public string location_Id { get; set; }
        public string LoctnNm { get; set; }
        public string div_code { get; set; }
        public bool? neg_stock_ind { get; set; }
        public bool? default_storage_loc { get; set; }

       

    }
    public class MM_M0004
    {
        public string mov_tp { get; set; }
        public string mov_tp_name { get; set; }
        public string mov_tp_desc { get; set; }
        public string debit_credit { get; set; }
        public string con_post { get; set; }
        public string gr_block_stock { get; set; }
        public string batch_control { get; set; }
        public string insp_qa { get; set; }
        public string mov_cat { get; set; }
        public string rev_mov_tp { get; set; }
        public bool? active { get; set; }
        public string post_key_ref { get; set; }

        // Scaler Fields
        public string doc_type { get; set; }

    }
    public class MM_M0011 : ObjectBase
    {
        public string comp_code { get; set; }
        public string doc_cat { get; set; }
        public string item_cat { get; set; }
        public string active { get; set; }
        public bool? selected { get; set; }
    }

    public class MC_MM_T005 : MC_MM_BE
    {
        public List<MM_T005> MASTER_ENTITY_LIST { get; set; }
        public List<MM_T005_A> ITEMS_ENTITY_LIST { get; set; }
        public List<MM_T005_B> BATCH_ENTITY_LIST { get; set; }
    }

    public class MC_MM_T011 : MC_MM_BE
    {
        public List<MM_T011> ITEMS_ENTITY_LIST { get; set; }
    }

    public class MC_MM_S010 : MC_MM_BE
    {
        public List<MM_S010> MasterEntityList { get; set; }
        public List<MM_S010_A> ItemEntityList { get; set; }
    }

}
