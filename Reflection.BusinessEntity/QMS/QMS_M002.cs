using System;
using System.Collections.Generic;

namespace Reflection.BusinessEntity.QMS
{
    public class QMS_M002 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };
        private int _id;
        private string _sgrcode;
        private string _sgrname;
        private string _sgrdesc;
        private string _grcode;
        private string _add_by;
        private DateTime _add_date;
        private string _editby;
        private DateTime? _edit_date;
        private string _location_Id;
        private string _comp_code;
        private bool? _active;
        private string _language;


        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
                RaisePropertyChanged("id");
            }
        }
        public string sgrcode
        {
            get { return _sgrcode; }
            set
            {
                _sgrcode = value;
                RaisePropertyChanged("sgrcode");
            }
        }
        public string sgrname
        {
            get { return _sgrname; }
            set
            {
                _sgrname = value;
                RaisePropertyChanged("sgrname");
            }
        }

        public string sgrdesc
        {
            get { return _sgrdesc; }
            set
            {
                _sgrdesc = value;
                RaisePropertyChanged("sgrdesc");
            }
        }
        public string grcode
        {
            get { return _grcode; }
            set
            {
                _grcode = value;
                RaisePropertyChanged("grcode");
            }
        }
        public string add_by
        {
            get { return _add_by; }
            set
            {
                _add_by = value;
                RaisePropertyChanged("add_by");
            }
        }
        public DateTime add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }
        public string editby
        {
            get { return _editby; }
            set
            {
                _editby = value;
                RaisePropertyChanged("editby");
            }
        }
        public DateTime? edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }
        public string location_Id
        {
            get { return _location_Id; }
            set
            {
                _location_Id = value;
                RaisePropertyChanged("location_Id");
            }
        }
        public string comp_code
        {
            get { return _comp_code; }
            set
            {
                _comp_code = value;
                RaisePropertyChanged("comp_code");
            }
        }
        public bool? active
        {
            get { return _active; }
            set
            {
                _active = value;
                RaisePropertyChanged("active");
            }
        }
        public string language
        {
            get { return _language; }
            set
            {
                _language = value;
                RaisePropertyChanged("language");
            }
        }
        

        //--- Scalar
        private string _grname;
        public string grname
        {
            get { return _grname; }
            set
            {
                _grname = value;
                RaisePropertyChanged("grname");
            }
        }
        public string XmlDataDocument_QMS_M002FLIP { get; set; }
    }
    public class MultipleContext_QMS_M002
    {
        public List<QMS_M002Flip> DocumentDataFlipGrid { get; set; }//Back Flip data
        public List<QMS_M001_P> GroupCodeList { get; set; }//Group Details
        public List<QMS_M002> MasterList { get; set; }  //Master Entity List            

    }
}
