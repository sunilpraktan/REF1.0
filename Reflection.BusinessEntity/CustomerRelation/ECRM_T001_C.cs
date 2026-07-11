using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity
{
    public class ECRM_T001_C : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        
        private string _sr_no;
        public string sr_no
        {
            get { return _sr_no; }
            set {
                if (_sr_no != value)
                {
                    _sr_no = value; RaisePropertyChanged("sr_no");
                }
            }
        }
        private Nullable<System.DateTime> _sr_date;
        public Nullable<System.DateTime> sr_date
        {
            get { return _sr_date; }
            set {
                if (_sr_date != value)
                {
                    _sr_date = value; RaisePropertyChanged("sr_date");
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
        private string _doc_type;
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
        private string _analysis_for;
        public string analysis_for
        {
            get { return _analysis_for; }
            set {
                if (_analysis_for != value)
                {
                    _analysis_for = value; RaisePropertyChanged("analysis_for");
                }
            }
        }
        private string _samp_details;
        public string samp_details
        {
            get { return _samp_details; }
            set {
                if (_samp_details != value)
                {
                    _samp_details = value; RaisePropertyChanged("samp_details");
                }
            }
        }
        private string _smooth;
        public string smooth
        {
            get { return _smooth; }
            set {
                if (_smooth != value)
                {
                    _smooth = value; RaisePropertyChanged("smooth");
                }
            }
        }
        private string _fading;
        public string fading
        {
            get { return _fading; }
            set {
                if (_fading != value)
                {
                    _fading = value; RaisePropertyChanged("fading");
                }
            }
        }
        private string _ild;
        public string ild
        {
            get { return _ild; }
            set {
                if (_ild != value)
                {
                    _ild = value; RaisePropertyChanged("ild");
                }
            }
        }
        private string _gooping;
        public string gooping
        {
            get { return _gooping; }
            set {
                if (_gooping != value)
                {
                    _gooping = value; RaisePropertyChanged("gooping");
                }
            }
        }
        private string _skiping;
        public string skiping
        {
            get { return _skiping; }
            set {
                if (_skiping != value)
                {
                    _skiping = value; RaisePropertyChanged("skiping");
                }
            }
        }
        private string _deep_light;
        public string deep_light
        {
            get { return _deep_light; }
            set {
                if (_deep_light != value)
                {
                    _deep_light = value; RaisePropertyChanged("deep_light");
                }
            }
        }
        private string _wavi;
        public string wavi
        {
            get { return _wavi; }
            set {
                if (_wavi != value)
                {
                    _wavi = value; RaisePropertyChanged("wavi");
                }
            }
        }
        private string _static_lkg;
        public string static_lkg
        {
            get { return _static_lkg; }
            set {
                if (_static_lkg != value)
                {
                    _static_lkg = value; RaisePropertyChanged("static_lkg");
                }
            }
        }
        private string _wrt_length;
        public string wrt_length
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
            set {
                if (_wrt_length_req != value)
                {
                    _wrt_length_req = value; RaisePropertyChanged("wrt_length_req");
                }
            }
        }
        private string _check_material;
        public string check_material
        {
            get { return _check_material; }
            set {
                if (_check_material != value)
                {
                    _check_material = value; RaisePropertyChanged("check_material");
                }
            }
        }
        private string _check_ball_dia;
        public string check_ball_dia
        {
            get { return _check_ball_dia; }
            set {
                if (_check_ball_dia != value)
                {
                    _check_ball_dia = value; RaisePropertyChanged("check_ball_dia");
                }
            }
        }
        private string _prepare_drg;
        public string prepare_drg
        {
            get { return _prepare_drg; }
            set {
                if (_prepare_drg != value)
                {
                    _prepare_drg = value; RaisePropertyChanged("prepare_drg");
                }
            }
        }

        private string _match_model;
        public string match_model
        {
            get { return _match_model; }
            set {
                if (_match_model != value)
                {
                    _match_model = value; RaisePropertyChanged("match_model");
                }
            }
        }
        private string _internal_geometry;
        public string internal_geometry
        {
            get { return _internal_geometry; }
            set {
                if (_internal_geometry != value)
                {
                    _internal_geometry = value; RaisePropertyChanged("internal_geometry");
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
        private string _ball_material;
        public string ball_material
        {
            get { return _ball_material; }
            set {
                if (_ball_material != value)
                {
                    _ball_material = value; RaisePropertyChanged("ball_material");
                }
            }
        }
        private string _max_ild;
        public string max_ild
        {
            get { return _max_ild; }
            set {
                if (_max_ild != value)
                {
                    _max_ild = value; RaisePropertyChanged("max_ild");
                }
            }
        }
        private string _min_ild;
        public string min_ild
        {
            get { return _min_ild; }
            set {
                if (_min_ild != value)
                {
                    _min_ild = value; RaisePropertyChanged("min_ild");
                }
            }
        }
        private string _avg_ild;
        public string avg_ild
        {
            get { return _avg_ild; }
            set {
                if (_avg_ild != value)
                {
                    _avg_ild = value; RaisePropertyChanged("avg_ild");
                }
            }
        }
        private string _avg_gooping;
        public string avg_gooping
        {
            get { return _avg_gooping; }
            set {
                if (_avg_gooping != value)
                {
                    _avg_gooping = value; RaisePropertyChanged("avg_gooping");
                }
            }
        }
        private string _test_no;
        public string test_no
        { 
            get { return _test_no; }
            set {
                if (_test_no != value)
                {
                    _test_no = value; RaisePropertyChanged("test_no");
                }
            }
        }
        private string _handfil;
        public string handfil
        {
            get { return _handfil; }
            set {
                if (_handfil != value)
                {
                    _handfil = value; RaisePropertyChanged("handfil");
                }
            }
        }
        private string _hausdtl;
        public string hausdtl
        {
            get { return _hausdtl; }
            set {
                if (_hausdtl != value)
                {
                    _hausdtl = value; RaisePropertyChanged("hausdtl");
                }
            }
        }

        private string _remdca;
        public string remdca
        {
            get { return _remdca; }
            set {
                if (_remdca != value)
                {
                    _remdca = value; RaisePropertyChanged("remdca");
                }
            }
        }
        private string _remdcb;
        public string remdcb
        {
            get { return _remdcb; }
            set {
                if (_remdcb != value)
                {
                    _remdcb = value; RaisePropertyChanged("remdcb");
                }
            }
        }
        private string _dcaflg;
        public string dcaflg
        {
            get { return _dcaflg; }
            set {
                if (_dcaflg != value)
                {
                    _dcaflg = value; RaisePropertyChanged("dcaflg");
                }
            }
        }
        private string _dcbflg;
        public string dcbflg
        {
            get { return _dcbflg; }
            set {
                if (_dcbflg != value)
                {
                    _dcbflg = value; RaisePropertyChanged("dcbflg");
                }
            }
        }
        private string _dcdone;
        public string dcdone
        {
            get { return _dcdone; }
            set {
                if (_dcdone != value)
                {
                    _dcdone = value; RaisePropertyChanged("dcdone");
                }
            }
        }
        private string _dcaid;
        public string dcaid
        {
            get { return _dcaid; }
            set {
                if (_dcaid != value)
                {
                    _dcaid = value; RaisePropertyChanged("dcaid");
                }
            }
        }
        private string _dcbid;
        public string dcbid
        {
            get { return _dcbid; }
            set {
                if (_dcbid != value)
                {
                    _dcbid = value; RaisePropertyChanged("dcbid");
                }
            }
        }
        private Nullable<System.DateTime> _dcadt;
        public Nullable<System.DateTime> dcadt
        {
            get { return _dcadt; }
            set {
                if (_dcadt != value)
                {
                    _dcadt = value; RaisePropertyChanged("dcadt");
                }
            }
        }
        private Nullable<System.DateTime> _dcbdt;
        public Nullable<System.DateTime> dcbdt
        {
            get { return _dcbdt; }
            set {
                if (_dcbdt != value)
                {
                    _dcbdt = value; RaisePropertyChanged("dcbdt");
                }
            }
        }
        private string _authflg;
        public string authflg
        {
            get { return _authflg; }
            set {
                if (_authflg != value)
                {
                    _authflg = value; RaisePropertyChanged("authflg");
                }
            }
        }
        private string _authby;
        public string authby
        {
            get { return _authby; }
            set {
                if (_authby != value)
                {
                    _authby = value; RaisePropertyChanged("authby");
                }
            }
        }
        private Nullable<System.DateTime> _authdt;
        public Nullable<System.DateTime> authdt
        {
            get { return _authdt; }
            set {
                if (_authdt != value)
                {
                    _authdt = value; RaisePropertyChanged("authdt");
                }
            }
        }
        private string _authnote;
        public string authnote
        {
            get { return _authnote; }
            set {
                if (_authnote != value)
                {
                    _authnote = value; RaisePropertyChanged("authnote");
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
        private Nullable<bool> _active;
        public bool? active
        {
            get { return _active; }
            set {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
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
            set {
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
        
        private Nullable<bool> _smoth_cb;
        public Nullable<bool> smoth_cb
        {
            get { return _smoth_cb; }
            set {
                if (_smoth_cb != value)
                {
                    _smoth_cb = value; RaisePropertyChanged("smoth_cb");
                }
            }
        }
        private Nullable<bool> _fading_cb;
        public Nullable<bool> fading_cb
        {
            get { return _fading_cb; }
            set {
                if (_fading_cb != value)
                {
                    _fading_cb = value; RaisePropertyChanged("fading_cb");
                }
            }
        }
        private Nullable<bool> _gooping_cb;
        public Nullable<bool> gooping_cb
        {
            get { return _gooping_cb; }
            set {
                if (_gooping_cb != value)
                {
                    _gooping_cb = value; RaisePropertyChanged("gooping_cb");
                }
            }
        }
        private Nullable<bool> _ild_cb;
        public Nullable<bool> ild_cb
        {
            get { return _ild_cb; }
            set {
                if (_ild_cb != value)
                {
                    _ild_cb = value; RaisePropertyChanged("ild_cb");
                }
            }
        }
        private Nullable<bool> _skiping_cb;
        public Nullable<bool> skiping_cb
        {
            get { return _skiping_cb; }
            set {
                if (_skiping_cb != value)
                {
                    _skiping_cb = value; RaisePropertyChanged("skiping_cb");
                }
            }
        }
        private Nullable<bool> _deep_light_cb;
        public Nullable<bool> deep_light_cb
        {
            get { return _deep_light_cb; }
            set {
                if (_deep_light_cb != value)
                {
                    _deep_light_cb = value; RaisePropertyChanged("deep_light_cb");
                }
            }
        }
        private Nullable<bool> _wavi_cb;
        public Nullable<bool> wavi_cb
        {
            get { return _wavi_cb; }
            set {
                if (_wavi_cb != value)
                {
                    _wavi_cb = value; RaisePropertyChanged("wavi_cb");
                }
            }
        }
        private Nullable<bool> _static_lkg_cb;
        public Nullable<bool> static_lkg_cb
        {
            get { return _static_lkg_cb; }
            set {
                if (_static_lkg_cb != value)
                {
                    _static_lkg_cb = value; RaisePropertyChanged("static_lkg_cb");
                }
            }
        }
        private Nullable<bool> _wrt_len_cb;
        public Nullable<bool> wrt_len_cb
        {
            get { return _wrt_len_cb; }
            set {
                if (_wrt_len_cb != value)
                {
                    _wrt_len_cb = value; RaisePropertyChanged("wrt_len_cb");
                }
            }
        }
        private Nullable<bool> _ck_material_cb;
        public Nullable<bool> ck_material_cb
        {
            get { return _ck_material_cb; }
            set {
                if (_ck_material_cb != value)
                {
                    _ck_material_cb = value; RaisePropertyChanged("ck_material_cb");
                }
            }
        }
        private Nullable<bool> _ck_ball_dia_cb;
        public Nullable<bool> ck_ball_dia_cb
        {
            get { return _ck_ball_dia_cb; }
            set {
                if (_ck_ball_dia_cb != value)
                {
                    _ck_ball_dia_cb = value; RaisePropertyChanged("ck_ball_dia_cb");
                }
            }
        }
        private Nullable<bool> _prepare_drg_cb;
        public Nullable<bool> prepare_drg_cb
        {
            get { return _prepare_drg_cb; }
            set {
                if (_prepare_drg_cb != value)
                {
                    _prepare_drg_cb = value; RaisePropertyChanged("prepare_drg_cb");
                }
            }
        }
        private Nullable<bool> _match_model_cb;
        public Nullable<bool> match_model_cb
        {
            get { return _match_model_cb; }
            set {
                if (_match_model_cb != value)
                {
                    _match_model_cb = value; RaisePropertyChanged("match_model_cb");
                }
            }
        }
        private Nullable<bool> _int_geometry_cb;
        public Nullable<bool> int_geometry_cb
        {
            get { return _int_geometry_cb; }
            set {
                if (_int_geometry_cb != value)
                {
                    _int_geometry_cb = value; RaisePropertyChanged("int_geometry_cb");
                }
            }
        }
        private Nullable<bool> _other_req1_cb;
        public Nullable<bool> other_req1_cb
        {
            get { return _other_req1_cb; }
            set {
                if (_other_req1_cb != value)
                {
                    _other_req1_cb = value; RaisePropertyChanged("other_req1_cb");
                }
            }
        }
        private DateTime? _sa_date;
        public DateTime? sa_date
        {
            get { return _sa_date; }
            set
            {
                if (_sa_date != value)
                {
                    _sa_date = value; RaisePropertyChanged("sa_date");
                }
            }
        }
        private DateTime? _sample_re_date;
        public DateTime? sample_re_date
        {
            get { return _sample_re_date; }
            set
            {
                if (_sample_re_date != value)
                {
                    _sample_re_date = value; RaisePropertyChanged("sample_re_date");
                }
            }
        }
        private string _needle_tip;
        public string needle_tip
        {
            get { return _needle_tip; }
            set
            {
                if (_needle_tip != value)
                {
                    _needle_tip = value; RaisePropertyChanged("needle_tip");
                }
            }
        }
        private string _conclusion;
        public string conclusion
        {
            get { return _conclusion; }
            set
            {
                if (_conclusion != value)
                {
                    _conclusion = value; RaisePropertyChanged("conclusion");
                }
            }
        }
        private Nullable<bool> _needle_tip_cb;
        public Nullable<bool> needle_tip_cb
        {
            get { return _needle_tip_cb; }
            set
            {
                if (_needle_tip_cb != value)
                {
                    _needle_tip_cb = value; RaisePropertyChanged("needle_tip_cb");
                }
            }
        }
        public string XmlDataDocument_ECRM_T001_D { get; set; }
        public string XmlDataDocument_ECRM_T001_C_Flip { get; set; }
    }
  
    public class ECRM_T001_D : ObjectBase
    {
       

        private int _id;
        public int id
        {
            get
            {
                return _id;
            }

            set
            {
                if (_id != value)
                {
                    _id = value; RaisePropertyChanged("id");
                }
            }
        }
        private string _sr_no;
        public string sr_no
        {
            get
            {
                return _sr_no;
            }

            set
            {
                if (_sr_no != value)
                {
                    _sr_no = value; RaisePropertyChanged("sr_no");
                }
            }
        }
        private string _sa_no;
        public string sa_no
        {
            get
            {
                return _sa_no;
            }

            set
            {
                if (_sa_no != value)
                {
                    _sa_no = value; RaisePropertyChanged("sa_no");
                }
            }
        }
        private string _skiping;
        public string skiping
        {
            get
            {
                return _skiping;
            }

            set
            {
                if (_skiping != value)
                {
                    _skiping = value; RaisePropertyChanged("skiping", ModelEntityUpdated);
                }
            }
        }
        private string _splash;
        public string splash
        {
            get
            {
                return _splash;
            }

            set
            {
                if (_splash != value)
                {
                    _splash = value; RaisePropertyChanged("splash", ModelEntityUpdated);
                }
            }
        }
        private string _pattern;
        public string pattern
        {
            get
            {
                return _pattern;
            }

            set
            {
                if (_pattern != value)
                {
                    _pattern = value; RaisePropertyChanged("pattern", ModelEntityUpdated);
                }
            }
        }
        private string _consistancy;
        public string consistancy
        {
            get
            {
                return _consistancy;
            }

            set
            {
                if (_consistancy != value)
                {
                    _consistancy = value; RaisePropertyChanged("consistancy", ModelEntityUpdated);
                }
            }
        }

        private string _deep_light;
        public string deep_light
        {
            get
            {
                return _deep_light;
            }

            set
            {
                if (_deep_light != value)
                {
                    _deep_light = value; RaisePropertyChanged("deep_light", ModelEntityUpdated);
                }
            }
        }
        private string _other;
        public string other
        {
            get
            {
                return _other;
            }

            set
            {
                if (_other != value)
                {
                    _other = value; RaisePropertyChanged("other", ModelEntityUpdated);
                }
            }
        }
        private Nullable<bool> _active;

        public bool? active
        {
            get
            {
                return _active;
            }

            set
            {
                if (_active != value)
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }
        }

        public static EventHandler ModelEntityUpdated { get; set; }
    }
    public class MultipleContext_ECRM_T001_C
    {
        public List<ECRM_T001_C_Flip> DocumentDataFlipGrid { get; set; }
        public List<ECRM_T001_C> MasterDetails { get; set; }
        public ObservableCollection<ECRM_T001_D> ItemsDetails { get; set; }
        public List<ECRM_T001_A_Sample> SampleAnalysis { get; set; }
        public List<COM_T003> Attachment { get; set; }

    }
}
