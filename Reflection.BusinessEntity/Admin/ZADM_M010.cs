using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity
{
    public class ZADM_M010 : ObjectBase
    {
        private int _prod_id;
        public int prod_id
        {
            get { return _prod_id; }
            set { _prod_id = value; RaisePropertyChanged("prod_id"); }
        }

        private Nullable<int> _model_id;
        public Nullable<int> model_id
        {
            get { return _model_id; }
            set { _model_id = value; RaisePropertyChanged("model_id"); }
        }

        private Nullable<int> _wire_type_id;
        public Nullable<int> wire_type_id
        {
            get { return _wire_type_id; }
            set { _wire_type_id = value; RaisePropertyChanged("wire_type_id"); }
        }

        private Nullable<int> _wire_size_id;
        public Nullable<int> wire_size_id
        {
            get { return _wire_size_id; }
            set { _wire_size_id = value; RaisePropertyChanged("wire_size_id"); }
        }

        private Nullable<int> _ball_dia_id;
        public Nullable<int> ball_dia_id
        {
            get { return _ball_dia_id; }
            set { _ball_dia_id = value; RaisePropertyChanged("ball_dia_id"); }
        }

        private Nullable<int> _ball_type_id;
        public Nullable<int> ball_type_id
        {
            get { return _ball_type_id; }
            set { _ball_type_id = value; RaisePropertyChanged("ball_type_id"); }
        }

        private Nullable<decimal> _shank_dia;
        public Nullable<decimal> shank_dia
        {
            get { return _shank_dia; }
            set { _shank_dia = value; RaisePropertyChanged("shank_dia"); }
        }

        private string _shank_dia_tolce_plus;
        public string shank_dia_tolce_plus
        {
            get { return _shank_dia_tolce_plus; }
            set { _shank_dia_tolce_plus = value; RaisePropertyChanged("shank_dia_tolce_plus"); }
        }

        private string _shank_dia_tolce_mins;
        public string shank_dia_tolce_mins
        {
            get { return _shank_dia_tolce_mins; }
            set { _shank_dia_tolce_mins = value; RaisePropertyChanged("shank_dia_tolce_mins"); }
        }

        private Nullable<int> _tot_len_id;
        public Nullable<int> tot_len_id
        {
            get { return _tot_len_id; }
            set { _tot_len_id = value; RaisePropertyChanged("tot_len_id"); }
        }

        private string _tipshape;
        public string tipshape
        {
            get { return _tipshape; }
            set { _tipshape = value; RaisePropertyChanged("tipshape"); }
        }

        private string _tip_type;
        public string tip_type
        {
            get { return _tip_type; }
            set { _tip_type = value; RaisePropertyChanged("tip_type"); }
        }

        private string _blank;
        public string blank
        {
            get { return _blank; }
            set { _blank = value; RaisePropertyChanged("blank"); }
        }

        private Nullable<decimal> _extrapiece;
        public Nullable<decimal> extrapiece
        {
            get { return _extrapiece; }
            set { _extrapiece = value; RaisePropertyChanged("extrapiece"); }
        }

        private Nullable<int> _usedin_id;
        public Nullable<int> usedin_id
        {
            get { return _usedin_id; }
            set { _usedin_id = value; RaisePropertyChanged("usedin_id"); }
        }

        private Nullable<decimal> _noofball;
        public Nullable<decimal> noofball
        {
            get { return _noofball; }
            set { _noofball = value; RaisePropertyChanged("noofball"); }
        }

        private string _needlelen;
        public string needlelen
        {
            get { return _needlelen; }
            set { _needlelen = value; RaisePropertyChanged("needlelen"); }
        }

        private string _needlelen_tolce_plus;
        public string needlelen_tolce_plus
        {
            get { return _needlelen_tolce_plus; }
            set { _needlelen_tolce_plus = value; RaisePropertyChanged("needlelen_tolce_plus"); }
        }

        private string _needlelen_tolce_mins;
        public string needlelen_tolce_mins
        {
            get { return _needlelen_tolce_mins; }
            set { _needlelen_tolce_mins = value; RaisePropertyChanged("needlelen_tolce_mins"); }
        }

        private string _needledia;
        public string needledia
        {
            get { return _needledia; }
            set { _needledia = value; RaisePropertyChanged("needledia"); }
        }

        private string _needledia_tolce_plus;
        public string needledia_tolce_plus
        {
            get { return _needledia_tolce_plus; }
            set { _needledia_tolce_plus = value; RaisePropertyChanged("needledia_tolce_plus"); }
        }

        private string _needledia_tolce_mins;
        public string needledia_tolce_mins
        {
            get { return _needledia_tolce_mins; }
            set { _needledia_tolce_mins = value; RaisePropertyChanged("needledia_tolce_mins"); }
        }

        private string _shanklen;
        public string shanklen
        {
            get { return _shanklen; }
            set { _shanklen = value; RaisePropertyChanged("shanklen"); }
        }

        private string _shanklen_tolce_plus;
        public string shanklen_tolce_plus
        {
            get { return _shanklen_tolce_plus; }
            set { _shanklen_tolce_plus = value; RaisePropertyChanged("shanklen_tolce_plus"); }
        }

        private string _shanklen_tolce_mins;
        public string shanklen_tolce_mins
        {
            get { return _shanklen_tolce_mins; }
            set { _shanklen_tolce_mins = value; RaisePropertyChanged("shanklen_tolce_mins"); }
        }
        
        private string _needleangle;
        public string needleangle
        {
            get { return _needleangle; }
            set { _needleangle = value; RaisePropertyChanged("needleangle"); }
        }
       
        private string _frontpinlength;
        public string frontpinlength
        {
            get { return _frontpinlength; }
            set { _frontpinlength = value; RaisePropertyChanged("frontpinlength"); }
        }
        
        private string _pinlength;
        public string pinlength
        {
            get { return _pinlength; }
            set { _pinlength = value; RaisePropertyChanged("pinlength"); }
        }
        
        private string _frontpindia;
        public string frontpindia
        {
            get { return _frontpindia; }
            set { _frontpindia = value; RaisePropertyChanged("frontpindia"); }
        }
        
        private string _pindia;
        public string pindia
        {
            get { return _pindia; }
            set { _pindia = value; RaisePropertyChanged("pindia"); }
        }

        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set { _add_by = value; RaisePropertyChanged("add_by"); }
        }

        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set { _add_date = value; RaisePropertyChanged("add_date"); }
        }

        private string _editby;
        public string editby
        {
            get { return _editby; }
            set { _editby = value; RaisePropertyChanged("editby"); }
        }

        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set { _edit_date = value; RaisePropertyChanged("edit_date"); }
        }

        private string _prodnm;
        public string prodnm
        {
            get { return _prodnm; }
            set { _prodnm = value; RaisePropertyChanged("prodnm"); }
        }

        private string _ItemCode;
        public string ItemCode
        {
            get { return _ItemCode; }
            set { _ItemCode = value; RaisePropertyChanged("ItemCode"); }
        }

        private int _ink_id;
        public int ink_id
        {
            get { return _ink_id; }
            set { _ink_id = value; RaisePropertyChanged("ink_id"); }
        }

        private string _ink;
        public string ink
        {
            get { return _ink; }
            set { _ink = value; RaisePropertyChanged("ink"); }
        }

        private int _ild_id;
        public int ild_id
        {
            get { return _ild_id; }
            set { _ild_id = value; RaisePropertyChanged("ild_id"); }
        }

        private string _ild;
        public string ild
        {
            get { return _ild; }
            set { _ild = value; RaisePropertyChanged("ild"); }
        }

        private string _comp_code;
        public string comp_code
        {
            get { return _comp_code; }
            set { _comp_code = value; RaisePropertyChanged("comp_code"); }
        }

        private string _location_Id;
        public string location_Id
        {
            get { return _location_Id; }
            set { _location_Id = value; RaisePropertyChanged("location_Id"); }
        }

        private Nullable<bool> _lifeTest;
        public Nullable<bool> lifeTest
        {
            get { return _lifeTest; }
            set { _lifeTest = value; RaisePropertyChanged("lifeTest"); }
        }

        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set { _unit_code = value; RaisePropertyChanged("unit_code"); }
        }
        
        private Nullable<decimal> _ball_wt;
        public Nullable<decimal> ball_wt
        {
            get { return _ball_wt; }
            set { _ball_wt = value; RaisePropertyChanged("ball_wt"); }
        }
        
        private Nullable<decimal> _spring_wt;
        public Nullable<decimal> spring_wt
        {
            get { return _spring_wt; }
            set { _spring_wt = value; RaisePropertyChanged("spring_wt"); }
        }
        
        private string _prodname;
        public string prodname
        {
            get { return _prodname; }
            set { _prodname = value; RaisePropertyChanged("prodname"); }
        }
        
        private string _ball_content;
        public string ball_content
        {
            get { return _ball_content; }
            set { _ball_content = value; RaisePropertyChanged("ball_content"); }
        }
        
        private string _spring_content;
        public string spring_content
        {
            get { return _spring_content; }
            set { _spring_content = value; RaisePropertyChanged("spring_content"); }
        }
        private string _test_code;
        public string test_code
        {
            get { return _test_code; }
            set { _test_code = value; RaisePropertyChanged("test_code"); }
        }

        //Scalar
        private string _wire_type;
        public string wire_type
        {
            get { return _wire_type; }
            set { _wire_type = value; RaisePropertyChanged("wire_type"); }
        }

        private string _modelno;
        public string modelno
        {
            get { return _modelno; }
            set { _modelno = value; RaisePropertyChanged("modelno"); }
        }

        private decimal _wire_size;
        public decimal wire_size
        {
            get { return _wire_size; }
            set { _wire_size = value; RaisePropertyChanged("wire_size"); }
        }

        private decimal _ball_dia;
        public decimal ball_dia
        {
            get { return _ball_dia; }
            set { _ball_dia = value; RaisePropertyChanged("ball_dia"); }

        }

        private string _ball_type;
        public string ball_type
        {
            get { return _ball_type; }
            set { _ball_type = value; RaisePropertyChanged("ball_type"); }

        }

        private string _total_len;
        public string total_len
        {
            get { return _total_len; }
            set { _total_len = value; RaisePropertyChanged("total_len"); }

        }

        public string XmlDataDocument_FlipGrid { get; set; }
    }
    public class MultipleContext_ZADM_M010
    {
        public List<ZADM_M010_Flip> BackflipData { get; set; }
        public List<ZADM_M010> MasterEntity { get; set; }
        public List<ZADM_M009_P> ModelList { get; set; }
        public List<ZADM_M004_P> WireTypeList { get; set; }
        public List<ZADM_M003_P> WireSizeList { get; set; }
        public List<ZADM_M001_P> BallDiameterList { get; set; }
        public List<ZADM_M002_P> BallTypeList { get; set; }
        public List<ZADM_M008_P> TipLengthList { get; set; }
        public List<ZADM_M006_P> InkList { get; set; }
        public List<ZADM_M007_P> IldList { get; set; }
        public List<ADM_M038_B_P> UnitCodeList { get; set; }
        public List<COM_T003> AttachmentList { get; set; }
        public List<ECRM_T003_C_P> TestType { get; set; } // Test TYpe master

    }


}
