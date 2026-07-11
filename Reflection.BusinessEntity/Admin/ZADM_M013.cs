using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Reflection.BusinessEntity
{
    public class ZADM_M013 :ObjectBase,IDataErrorInfo
    {
        private int _machine_id;
        private string _machinecode;
        private Nullable<int> _machine_type_id;
        private string _machinedesc;
        private Nullable<decimal> _machineorder;
        private Nullable<int> _make_id;
        private string _electricitypara;
        private string _mechpara;
        private string _machinesrno;
        private string _actualsrno;
        private string _connload;
        private string _otherpara;
        private string _purchaseyr;
        private Nullable<int> _Comp_Id;
        private Nullable<int> _machine_subtype_id;
        private string _mctype;
        private Nullable<int> _empid;
        private string _add_by;
        private Nullable<System.DateTime> _add_date;
        private string _edit_by;
        private Nullable<System.DateTime> _edit_date;
        private string _CompName;
        private string _machine_type;
        private string _machine_subtype;
        private string _packingcode;
        private Nullable<int> _machinecap_id;
        private string _Make;
        private string _Capacity;
        private string _empname;
        private string _Request;

        public int machine_id
        {
            get { return _machine_id; }
            set
            {
                _machine_id = value;
                RaisePropertyChanged("machine_id");
            }
        }


        [Required(ErrorMessage = "Field 'Machine No' is required.")]
        [DisplayName("Machine No")]
        public string machinecode
        {
            get { return _machinecode; }
            set
            {
                _machinecode = value;
                RaisePropertyChanged("machinecode");
            }
        }

        public Nullable<int> machine_type_id
        {
            get { return _machine_type_id; }
            set
            {
                _machine_type_id = value;
                RaisePropertyChanged("machine_type_id");
            }
        }

        public string machinedesc
        {
            get { return _machinedesc; }
            set 
            {
                _machinedesc = value;
                RaisePropertyChanged("machinedesc");
            }
        }

        [Required(ErrorMessage = "Field 'Machine Order' is required.")]
        [ValidInteger(ErrorMessage = "Numbers only please.")]
        [DisplayName("Machine Order")]
        public Nullable<decimal> machineorder
        {
            get { return _machineorder; }
            set 
            {
                _machineorder = value;
                RaisePropertyChanged("machineorder");
            }
        }

        public Nullable<int> make_id
        {
            get { return _make_id; }
            set
            {
                _make_id = value;
                RaisePropertyChanged("make_id");
            }
        }

        public string electricitypara
        {
            get { return _electricitypara; }
            set
            {
                _electricitypara = value;
                RaisePropertyChanged("electricitypara");
            }
        }

        public string mechpara
        {
            get { return _mechpara; }
            set
            {
                _mechpara = value;
                RaisePropertyChanged("mechpara");
            }
        }

        public string machinesrno
        {
            get { return _machinesrno; }
            set
            {
                _machinesrno = value;
                RaisePropertyChanged("machinesrno");
            }
        }

        public string actualsrno
        {
            get { return _actualsrno; }
            set
            {
                _actualsrno = value;
                RaisePropertyChanged("actualsrno");
            }
        }

        public string connload
        {
            get { return _connload; }
            set
            {
                _connload = value;
                RaisePropertyChanged("connload");
            }
        }

        public string otherpara
        {
            get { return _otherpara; }
            set
            {
                _otherpara = value;
                RaisePropertyChanged("otherpara");
            }
        }

        public string purchaseyr
        {
            get { return _purchaseyr; }
            set
            {
                _purchaseyr = value;
                RaisePropertyChanged("purchaseyr");
            }
        }

        public Nullable<int> Comp_Id
        {
            get { return _Comp_Id; }
            set
            {
                _Comp_Id = value;
                RaisePropertyChanged("Comp_Id");
            }
        }

        public Nullable<int> machine_subtype_id
        {
            get { return _machine_subtype_id; }
            set
            {
                _machine_subtype_id = value;
                RaisePropertyChanged("machine_subtype_id");
            }
        }

        public string mctype
        {
            get { return _mctype; }
            set
            {
                _mctype = value;
                RaisePropertyChanged("mctype");
            }
        }

        public Nullable<int> empid
        {
            get { return _empid; }
            set
            {
                _empid = value;
                RaisePropertyChanged("empid");
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

        public Nullable<System.DateTime> add_date
        {
            get { return _add_date; }
            set
            {
                _add_date = value;
                RaisePropertyChanged("add_date");
            }
        }

        public string edit_by
        {
            get { return _edit_by; }
            set
            {
                _edit_by = value;
                RaisePropertyChanged("edit_by");
            }
        }

        public Nullable<System.DateTime> edit_date
        {
            get { return _edit_date; }
            set
            {
                _edit_date = value;
                RaisePropertyChanged("edit_date");
            }
        }

        [Required(ErrorMessage = "Field 'Unit' is required.")]
        [DisplayName("Unit")]
        public string CompName
        {
            get { return _CompName; }
            set
            {
                _CompName = value;
                RaisePropertyChanged("CompName");
            }
        }

        [Required(ErrorMessage = "Field 'Machine Type' is required.")]
        [DisplayName("Machine Type")]
        public string machine_type
        {
            get { return _machine_type; }
            set
            {
                _machine_type = value;
                RaisePropertyChanged("machine_type");
            }
        }

        [Required(ErrorMessage = "Field 'Machine Sub Type' is required.")]
        [DisplayName("Machine Sub Type")]
        public string machine_subtype
        {
            get { return _machine_subtype; }
            set
            {
                _machine_subtype = value;
                RaisePropertyChanged("machine_subtype");
            }
        }

        [Required(ErrorMessage = "Field 'Packing Code' is required.")]
        [DisplayName("Packing Code")]
        public string packingcode
        {
            get { return _packingcode; }
            set
            {
                _packingcode = value;
                RaisePropertyChanged("packingcode");
            }
        }

        public Nullable<int> machinecap_id
        {
            get { return _machinecap_id; }
            set
            {
                _machinecap_id = value;
                RaisePropertyChanged("machinecap_id");
            }
        }

        public string Make
        {
            get { return _Make; }
            set
            {
                _Make = value;
                RaisePropertyChanged("Make");
            }
        }

        public string Capacity
        {
            get { return _Capacity; }
            set
            {
                _Capacity = value;
                RaisePropertyChanged("Capacity");
            }
        }

        [Required(ErrorMessage = "Field 'Machine Owner' is required.")]
        [DisplayName("Machine Owner")]
        public string empname
        {
            get { return _empname; }
            set
            {
                _empname = value;
                RaisePropertyChanged("empname");
            }
        }

        public string Request
        {
            get { return _Request; }
            set
            {
                _Request = value;
                RaisePropertyChanged("Request");
            }
        }

        string IDataErrorInfo.Error
        {
            get { throw new NotImplementedException(); }
        }

        string IDataErrorInfo.this[string columnName]
        {
            get { throw new NotImplementedException(); }
        }

       
    }
    public class MultipleContext_ZADM_M013
    {
        public List<ZADM_M013> MachineMaster_1 { get; set; }   //Machine Master   
        //public ObservableCollection<ZADM_M013> MachineMaster_1 { get; set; }   //Machine Master   
        public ObservableCollection<ADM_M002_PopUp> GroupCompanyMaster_1 { get; set; }  //Group Company Master 
        public ObservableCollection<ZADM_M011_PopUp> MachineTypeMaster_1 { get; set; }  //Machine Type Master  
        public ObservableCollection<ZADM_M012_PopUp> MachineSubTypeMaster_1 { get; set; }  //Machine Sub Type Master  
        public ObservableCollection<ADM_M032_P> MakeMaster_1 { get; set; }  //Make Master  
        //public ObservableCollection<ADM_M041_PopUp> MachineCapacityMaster_1 { get; set; }  //Machine Capacity Master  
       // public ObservableCollection<ADM_M038_B_PopUp_Capacity> UOMMaster_1 { get; set; }  //Unit Of Measurement Master  
        public ObservableCollection<ADM_M024_PopUp1> EmployeeMaster_1 { get; set; }  //Unit Of Measurement Master  
    }
    public class ADM_M038_B_PopUp_Capacity
    {
         [DisplayName("Capacity")]
        public string Capacity { get; set; }
    }  

    public class ZADM_M011_PopUp
    {
        public Nullable<int> machine_type_id { get; set; }
        [DisplayName("Machine Type")]
        public string machine_type { get; set; }
    }

    public class ZADM_M012_PopUp
    {
        public Nullable<int> machine_subtype_id { get; set; }
        [DisplayName("Machine Subtype")]
        public string machine_subtype { get; set; }
    }

    public class ADM_M041_PopUp
    {
       // public Nullable<int> machinecap_id { get; set; }
        [DisplayName("Machine Capacity")]
        public string Capacity { get; set; }
    }

    public class ADM_M024_PopUp1
    {
        public int id { get; set; }
        [DisplayName("Machine Owner")]
        public string MachineOwner { get; set; }
    }
}
