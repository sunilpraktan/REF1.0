using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public partial class ZADM_M009 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _model_id;
        public int model_id
        {
            get { return _model_id; }
            set
            {
                _model_id = value;
                RaisePropertyChanged("model_id");
            }
        }
        private string _basicmodel;
        // [Required(ErrorMessage = "Field 'Model Name' is required.")]
        public string basicmodel
        {
            get { return _basicmodel; }
            set
            {
                _basicmodel = value;
                RaisePropertyChanged("basicmodel");
            }
        }
        private string _modelno;
        [Required(ErrorMessage = "Field 'Model No' is required.")]
        public string modelno
        {
            get { return _modelno; }
            set
            {
                _modelno = value;
                RaisePropertyChanged("modelno");
            }
        }
        private string _modeldesc;
        public string modeldesc
        {
            get { return _modeldesc; }
            set
            {
                _modeldesc = value;
                RaisePropertyChanged("modeldesc");
            }
        }
        private Nullable<System.DateTime> _date;
        public Nullable<System.DateTime> date
        {
            get { return _date; }
            set
            {
                _date = value;
                RaisePropertyChanged("date");
            }
        }
        private Nullable<int> _wire_size_id;
        public Nullable<int> wire_size_id
        {
            get { return _wire_size_id; }
            set
            {
                _wire_size_id = value;
                RaisePropertyChanged("wire_size_id");
            }
        }
        private string _drwgno;
        public string drwgno
        {
            get { return _drwgno; }
            set
            {
                _drwgno = value;
                RaisePropertyChanged("drwgno");
            }
        }
        private byte[] _drgflnm;
        public byte[] drgflnm
        {
            get { return _drgflnm; }
            set
            {
                _drgflnm = value;
                RaisePropertyChanged("drgflnm");
            }
        }
        private string _add_by;
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }
        private string _edit_by;
        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                _edit_by = value;
                RaisePropertyChanged("edit_by");
            }
        }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }
        private Nullable<decimal> _wire_size;
        public Nullable<decimal> wire_size
        {
            get { return _wire_size; }
            set
            {
                _wire_size = value;
                RaisePropertyChanged("wire_size");
            }
        }        
     
        public string XmlDataDocument_FlipGrid { get; set; }
    }
    public class MultipleContext_ZADM_M009
    {
        public List<ZADM_M009> MasterEntity { get; set; }//Model Master
        public List<ZADM_M009_Flip> DocumentDataFlipGrid { get; set; } //Flip
        public List<ZADM_M003_PopUp> wiresize { get; set; }//Wiresize Master 
        public List<COM_T003> AttachmentList { get; set; }
    }
}

