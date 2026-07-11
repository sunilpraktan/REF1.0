using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


namespace Reflection.BusinessEntity
{
    public class ECRM_T001_A : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        
        private int _id;
        public int id
        {
            get { return _id; }
            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }
        private string _sa_no;
        public string sa_no
        {
            get { return _sa_no; }
            set {
                if (_sa_no != value)
                { _sa_no = value; RaisePropertyChanged("sa_no"); }
        }
            }

        private Nullable<System.DateTime> _sa_date;
        public Nullable<System.DateTime> sa_date
        {
            get { return _sa_date; }
            set
            {
                if (value == null)
                {
                    _sa_date = DateTime.Now;
                }
                else
                {
                    _sa_date = value;
                }
                RaisePropertyChanged("sa_date");
            }
        }
        private string _sample_frm;
        public string sample_frm
        {
            get { return _sample_frm; }
            set
            {
                if (_sample_frm != value)
                {
                    _sample_frm = value; RaisePropertyChanged("sample_frm");
                }
            }
        }
        private string _sample_when;
        public string sample_when
        {
            get { return _sample_when; }
            set {
                if (_sample_when != value)
                {
                    _sample_when = value; RaisePropertyChanged("sample_when");

                }
            }
        }
        private string _purpose;
        public string purpose
        {
            get { return _purpose; }
            set {
                if (_purpose != value)
                {
                    _purpose = value; RaisePropertyChanged("purpose");

                }
            }
        }
        private string _bkgrnd;
        public string bkgrnd
        {
            get { return _bkgrnd; }
            set {
                if (_bkgrnd != value)
                {
                    _bkgrnd = value; RaisePropertyChanged("bkgrnd");
                }
            }
        }
        private string _courier;
        public string courier
        {
            get { return _courier; }
            set {
                if (_courier != value)
                {
                    _courier = value; RaisePropertyChanged("courier");

                }
            }
        }
        private string _docktno;
        public string docktno
        {
            get { return _docktno; }
            set {
                if (_docktno != value)
                {
                    _docktno = value; RaisePropertyChanged("docktno");
                }
            }
        }
        private string _disp_date;
        public string disp_date
        {
            get { return _disp_date; }
            set {
                if (_disp_date != value)
                {
                    _disp_date = value; RaisePropertyChanged("disp_date");

                }
            }
        }
        private Nullable<bool> _smoth;
        public Nullable<bool> smoth
        {
            get { return _smoth; }
            set {
                if (_smoth != value)
                {
                    _smoth = value; RaisePropertyChanged("smoth");

                }
            }
        }
        private Nullable<bool> _fadng;
        public Nullable<bool> fadng
        {
            get { return _fadng; }
            set {
                if (_fadng != value)
                {
                    _fadng = value; RaisePropertyChanged("fadng");


                }
            }
        }
        private Nullable<bool> _ild;
        public Nullable<bool> ild
        {
            get { return _ild; }
            set
            {
                if (_ild != value)
                {
                    _ild = value; RaisePropertyChanged("ild");

                }
            }
        }
        private Nullable<bool> _gooping;
        public Nullable<bool> gooping
        {
            get { return _gooping; }
            set {
                if (_gooping != value)
                {
                    _gooping = value; RaisePropertyChanged("gooping");

                }
            }
        }
        private Nullable<bool> _skiping;
        public Nullable<bool> skiping
        {
            get { return _skiping; }
            set
            {
                if (_skiping != value)
                {
                    _skiping = value; RaisePropertyChanged("skiping");

                }
            }
        }
        private Nullable<bool> _deep_light;
        public Nullable<bool> deep_light
        {
            get { return _deep_light; }
            set {
                if (_deep_light != value)
                {
                    _deep_light = value; RaisePropertyChanged("deep_light");

                }
            }
        }
        private Nullable<bool> _waviness;
        public Nullable<bool> waviness
        {
            get { return _waviness; }
            set {
                if (_waviness != value)
                {
                    _waviness = value; RaisePropertyChanged("waviness");

                }
            }
        }
        private Nullable<bool> _stat_lickage;
        public Nullable<bool> stat_lickage
        {
            get { return _stat_lickage; }
            set {
                if (_stat_lickage != value)
                {
                    _stat_lickage = value; RaisePropertyChanged("stat_lickage");

                }
            }
        }
        private Nullable<bool> _wrt_length;
        public Nullable<bool> wrt_length
        {
            get { return _wrt_length; }
            set {
                if (_wrt_length != value)
                {
                    _wrt_length = value; RaisePropertyChanged("wrt_length");

                }
            }
        }
        private string _wrt_length_req;
        public string wrt_length_req
        {
            get { return _wrt_length_req; }
            set
            {
                if (_wrt_length_req != value)
                {
                    _wrt_length_req = value; RaisePropertyChanged("wrt_length_req");

                }
            }
        }
        private Nullable<bool> _ch_ball;
        public Nullable<bool> ch_ball
        {
            get { return _ch_ball; }
            set {
                if (_ch_ball != value)
                {
                    _ch_ball = value; RaisePropertyChanged("ch_ball");
                }
            }
        }
        private Nullable<bool> _ch_matrl;
        public Nullable<bool> ch_matrl
        {
            get { return _ch_matrl; }
            set {
                if (_ch_matrl != value)
                {
                    _ch_matrl = value; RaisePropertyChanged("ch_matrl");

                }
            }
        }
        private Nullable<bool> _prepare_digram;
        public Nullable<bool> prepare_digram
        {
            get { return _prepare_digram; }
            set {
                if (_prepare_digram != value)
                {
                    _prepare_digram = value; RaisePropertyChanged("prepare_digram");

                }
            }
        }
        private Nullable<bool> _mch_esem_model;
        public Nullable<bool> mch_esem_model
        {
            get { return _mch_esem_model; }
            set {
                if (_mch_esem_model != value)
                {
                    _mch_esem_model = value; RaisePropertyChanged("mch_esem_model");

                }
            }
        }
        private Nullable<bool> _in_geometry;
        public Nullable<bool> in_geometry
        {
            get { return _in_geometry; }
            set {
                if (_in_geometry != value)
                {
                    _in_geometry = value; RaisePropertyChanged("in_geometry");

                }
            }
        }
        private string _other_req;
        public string other_req
        {
            get { return _other_req; }
            set {
                if (_other_req != value)
                {
                    _other_req = value; RaisePropertyChanged("other_req");

                }
            }
        }
        private string _remark;
        public string remark
        {
            get { return _remark; }
            set {
                if (_remark != value)
                {
                    _remark = value; RaisePropertyChanged("remark");

                }
            }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");


                }
            }
        }
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date");

                }
            }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set {
                if (_editby != value)
                {
                    _editby = value; RaisePropertyChanged("editby");

                }
            }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date");
                }
            }
        }
        private string _doc_cat;
        public string doc_cat
        {
            get { return _doc_cat; }
            set {
                if (_doc_cat != value)
                {
                    _doc_cat = value; RaisePropertyChanged("doc_cat");

                }
            }
        }
        private string _doc_code;
        public string doc_code
        {
            get { return _doc_code; }
            set {
                if (_doc_code != value)
                {
                    _doc_code = value; RaisePropertyChanged("doc_code");

                }
            }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");

                }
            }
        }
        
        private bool _active;
        public bool active
        {
            get { return _active; }
            set {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");

                }
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id");
                }
            }
        }

        private bool? _copy;
        public bool? copy
        {
            get { return _copy; }
            set {
                if (_copy != value)
                {
                    _copy = value; RaisePropertyChanged("copy");
                }
            }
        }

        private string _doc_type { get; set; }
        public string doc_type
        {
            get { return _doc_type; }
            set {
                if (_doc_type != value)
                {
                    _doc_type = value; RaisePropertyChanged("doc_type");

                }
            }
        }

        private string _Plant_Name;

        public string Plant_Name
        {
            get { return _Plant_Name; }
            set {
                if (_Plant_Name != value)
                {
                    _Plant_Name = value; RaisePropertyChanged("Plant_Name");
                }
            }
        }
        private string _t_status;
        public string t_status
        {
            get { return _t_status; }
            set {
                if (_t_status != value)
                {
                    _t_status = value; RaisePropertyChanged("t_status");

                }
            }
        }

        private string _sample_to_plant;
        public string sample_to_plant
        {
            get { return _sample_to_plant; }
            set {
                if (_sample_to_plant != value)
                {
                    _sample_to_plant = value; RaisePropertyChanged("sample_to_plant");
                }
            }
        }

        //private string _sample_to_plant;
        //[Required(ErrorMessage = "Field 'sample_to_plant' is required.")]
        //[DisplayName("Sample Analysis To")]
        //public string sample_to_plant
        //{
        //    get { return _sample_to_plant; }
        //    set { _sample_to_plant = value; RaisePropertyChanged("sample_to_plant"); }
        //}
        private string _sg_code;
        public string sg_code
        {
            get
            {
                return _sg_code;
            }

            set
            {
                if (_sg_code != value)
                {
                    _sg_code = value; RaisePropertyChanged("sg_code", ModelEntityUpdated);
                }
            }
        }
        private string _so_code;
        public string so_code
        {
            get
            {
                return _so_code;
            }

            set
            {
                if (_so_code != value)
                {
                    _so_code = value; RaisePropertyChanged("so_code", ModelEntityUpdated);
                }
            }
        }

        private string _sg_name;
        public string sg_name
        {
            get
            {
                return _sg_name;
            }

            set
            {
                if (_sg_name != value)
                {
                    _sg_name = value; RaisePropertyChanged("sg_name", ModelEntityUpdated);
                }
            }
        }
        private string _sales_org;
        public string sales_org
        {
            get
            {
                return _sales_org;
            }

            set
            {
                if (_sales_org != value)
                {
                    _sales_org = value; RaisePropertyChanged("sales_org", ModelEntityUpdated);
                }
            }
        }

        private string _sample_ink;
        public string sample_ink
        {
            get { return _sample_ink; }
            set {
                if (_sample_ink != value)
                {
                    _sample_ink = value; RaisePropertyChanged(" sample_ink ");

                }
            }
        }

        private Nullable<DateTime> _collection_Reciept_Date;
        public Nullable<DateTime> collection_Reciept_Date
        {
            get { return _collection_Reciept_Date; }
            set {
                if (_collection_Reciept_Date != value)
                {
                    _collection_Reciept_Date = value; RaisePropertyChanged(" collection_Reciept_Date ");

                }
            }
        }

        private string _conclusion;
        public string conclusion
        {
            get { return _conclusion; }
            set {
                if (_conclusion != value)
                {
                    _conclusion = value; RaisePropertyChanged("conclusion");

                }
            }
        }

        private string _needle_tip;
        public string needle_tip
        {
            get { return _needle_tip; }
            set {
                if (_needle_tip != value)
                {
                    _needle_tip = value; RaisePropertyChanged("needle_tip");

                }
            }
        }

        private string _trans_type;
        public string trans_type
        {
            get { return _trans_type; }
            set {
                if (_trans_type != value)
                {
                    _trans_type = value; RaisePropertyChanged("trans_type");

                }
            }
        }
        private Nullable<bool> _other_req1;
        public Nullable<bool> other_req1
        {
            get { return _other_req1; }
            set {
                if (_other_req1 != value)
                {
                    _other_req1 = value; RaisePropertyChanged("other_req1");

                }
            }
        }
        private string _sender_name;
        public string sender_name
        {
            get { return _sender_name; }
            set {
                if (_sender_name != value)
                {
                    _sender_name = value; RaisePropertyChanged("sender_name");
                }
            }
        }
        private string _prepaper_name;
        public string prepaper_name
        {
            get { return _prepaper_name; }
            set {
                if (_prepaper_name != value)
                {
                    _prepaper_name = value; RaisePropertyChanged("prepaper_name");

                }
            }
        }
        private string _approver_name;
        public string approver_name
        {
            get { return _approver_name; }
            set {
                if (_approver_name != value)
                {
                    _approver_name = value; RaisePropertyChanged("approver_name");

                }
            }
        }
        private Nullable<System.DateTime> _sar_date;
        public Nullable<System.DateTime> sar_date
        {
            get { return _sar_date; }
            set
            {
                if (_sar_date != value)
                {
                    _sar_date = value; RaisePropertyChanged("sar_date");

                }
            }
        }
        public string XmlDataDocument_ECRM_T001_B { get; set; }
        public string XmlDataDocument_ECRM_T001_A_Flip { get; set; }

    }
    public class ECRM_T001_B : ObjectBase
    {
        private int _id { get; set; }
        public int id
        {
            get { return _id; }
            set {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");

                }
            }
        }
        private string _sa_no;
        public string sa_no
        {
            get { return _sa_no; }
            set {
                if (_sa_no != value)
                {
                    _sa_no = value; RaisePropertyChanged("sa_no");

                }
            }
        }
        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set {
                if (_ItemCode != value)
                {
                    _ItemCode = value; RaisePropertyChanged("ItemCode");

                }
            }
        }
        private string _description;
        public string description
        {
            get { return _description; }
            set {
                if (_description != value)
                {
                    _description = value; RaisePropertyChanged("description");

                }
            }
        }

        private string _unit_code;
        [Required(ErrorMessage = "Field 'Unit' is required.")]
        public string unit_code
        {
            get
            {
                return _unit_code;
            }

            set
            {
                if (_unit_code != value)
                {
                    _unit_code = value; RaisePropertyChanged("unit_code");
                }
            }
        }
        private Nullable<decimal> _qty;
        [Required(ErrorMessage = "Field 'Quantity' is required.")]
        [DisplayName("Quantity")]
        public Nullable<decimal> qty
        {
            get { return _qty; }
            set {
                if (_qty != value)
                {
                    _qty = value; RaisePropertyChanged("qty");

                }
            }
        }
        private bool _active;
        public bool active
        {
            get { return _active; }
            set {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }
        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set {
                if (_location_Id != value)
                {
                    _location_Id = value; RaisePropertyChanged("location_Id");

                }
            }
        }
        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set {
                if (_comp_code != value)
                {
                    _comp_code = value; RaisePropertyChanged("comp_code");

                }
            }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set {
                if (_add_by != value)
                {
                    _add_by = value; RaisePropertyChanged("add_by");

                }
            }
        }
        private System.DateTime _add_date;
        public System.DateTime add_date
        {
            get { return _add_date; }
            set
            {
                if (_add_date != value)
                {
                    _add_date = value; RaisePropertyChanged("add_date");
                }
            }
        }
        private string _editby;
        public string editby
        {
            get { return _editby; }
            set {
                if (_editby != value)
                {
                    _editby = value; RaisePropertyChanged("editby");

                }
            }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set {
                if (_edit_date != value)
                {
                    _edit_date = value; RaisePropertyChanged("edit_date");

                }
            }
        }
        
        private string _fin_year;
        public string fin_year
        {
            get { return _fin_year; }
            set {
                if (_fin_year != value)
                {
                    _fin_year = value; RaisePropertyChanged("fin_year");

                }
            }
        }
        private string _posting_period;
        public string posting_period
        {
            get { return _posting_period; }
            set {
                if (_posting_period != value)
                {
                    _posting_period = value; RaisePropertyChanged("posting_period");

                }
            }
        }
        private string _item_type;
        [Required(ErrorMessage = "Field 'item_type' is required.")]
        public string item_type
        {
            get { return _item_type; }
            set {
                if (_item_type != value)
                {
                    _item_type = value; RaisePropertyChanged("item_type");

                }
            }
        }
        public static EventHandler ModelEntityUpdated { get; set; }
    }
    public class MultipleContext_ECRM_T001_A
    {
        public List<ECRM_T001_A_Flip> DocumentDataFlipGrid { get; set; }
        public List<ECRM_T001_A> MasterDetails { get; set; }
        public ObservableCollection<ECRM_T001_B> ItemsDetails { get; set; }
        public List<ADM_M038_B_P> UnitList { get; set; }
        public List<ADM_M001_A_P> SalesOrg { get; set; }
        public List<ADM_M028_P> SampleFrmList { get; set; }
        public List<ADM_M001_H_P> SalesGroup { get; set; }
        public List<SalesInvoice_SingleReport> RptSampleAnalysis { get; set; }
        public List<SYS_M002> DocumentTypes { get; set; }
    }
}
