using System;
using System.Collections.ObjectModel;

namespace Reflection.BusinessEntity
{
    public class ADM_M036 : ObjectBase
    {
        public static event EventHandler ModelEntityUpdated = delegate { };

        private int _id;
        public int id { get { return _id; } set { _id = value; RaisePropertyChanged("id"); } }
        private int _location_id;
        public int location_id { get { return _location_id; } set { _location_id = value; RaisePropertyChanged("location_id"); RaisePropertyChanged("StatAbbre", ModelEntityUpdated); } }
        private int _item_code;
        public int item_code { get { return _item_code; } set { _item_code = value; RaisePropertyChanged("item_code"); } }
        private Nullable<bool> _aists;
        public Nullable<bool> aists { get { return _aists; } set { _aists = value; RaisePropertyChanged("aists"); } }
        private Nullable<System.DateTime> _add_date;
        public Nullable<System.DateTime> add_date { get { return _add_date; } set { _add_date = value; RaisePropertyChanged("add_date"); } }
        private string _add_by;
        public string add_by { get { return _add_by; } set { _add_by = value; RaisePropertyChanged("add_by"); } }
        private Nullable<System.DateTime> _edit_date;
        public Nullable<System.DateTime> edit_date { get { return _edit_date; } set { _edit_date = value; RaisePropertyChanged("edit_date"); } }
        private string _edit_by;
        public string edit_by { get { return _edit_by; } set { _edit_by = value; RaisePropertyChanged("edit_by"); } }
        private string _location_name;
        public string location_name { get { return _location_name; } set { _location_name = value; RaisePropertyChanged("location_name"); } }
        private string _item_name;
        public string item_name { get { return _item_name; } set { _item_name = value; RaisePropertyChanged("item_name"); } }

        public string XmlDataDocument { get; set; }

    }
    public class MultipleContext_ADM_M036
    {
        public ObservableCollection<ADM_M003_popup1> location_master { get; set; }  //ItmTp Master       
        public ObservableCollection<ADM_M022_PP_1> item_master { get; set; }  //ItmTp Master    
    }
    public class ADM_M022_PP_1 : ObjectBase//, INotifyPropertyChanged
    {
        private int _SrNo;
        public int SrNo { get { return _SrNo; } set { _SrNo = value; RaisePropertyChanged("SrNo"); } }
        private string _ItemCode { get; set; }
        public string ItemCode { get { return _ItemCode; } set { _ItemCode = value; RaisePropertyChanged("ItemCode"); } }
        private string _ItemName;
        public string ItemName { get { return _ItemName; } set { _ItemName = value; RaisePropertyChanged("ItemName"); } }
        internal bool _Select { get; set; }
        public bool Select
        {
            get { return _Select; }
            set
            {
                if (_Select != value)
                {
                    _Select = value;

                    RaisePropertyChanged("Select");
                }
            }
        }

    }
    public class ADM_M003_popup1
    {
        public int Location_Id { get; set; }
        public string LoctnCode { get; set; }
        public string LoctnNm { get; set; }
        public string LoctnAbbre { get; set; }
        public Nullable<int> CompCode { get; set; }
        public string Add1 { get; set; }
        public string Add2 { get; set; }
        public string City { get; set; }
        public Nullable<int> StatCode { get; set; }
        public Nullable<int> CntryCode { get; set; }
        public string PinCode { get; set; }
        public string PhOffi { get; set; }
        public string PhOffiExt { get; set; }
        public string FaxNo { get; set; }
        public string MailId { get; set; }
        public string CentCode { get; set; }
        public Nullable<int> ActivtCode { get; set; }
        public string UserId { get; set; }
        public Nullable<System.DateTime> AddDate { get; set; }
        public string EditBy { get; set; }
        public Nullable<System.DateTime> EditDate { get; set; }
        public Nullable<bool> AiSts { get; set; }
        public string CountryName { get; set; }
        public string StateName { get; set; }
        public string ActivityName { get; set; }
        public string CompanyName { get; set; }
    }
}
