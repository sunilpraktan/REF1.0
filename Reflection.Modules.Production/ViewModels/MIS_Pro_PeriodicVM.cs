using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using System.Collections;
using Reflection.Presentation.Services;
using System.Data;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.BusinessEntity.Production;
using Reflection.Presentation.Common;

namespace Reflection.Modules.Production.ViewModels
{
    class MIS_Pro_PeriodicVM : WorkspaceViewModel<MIS_Pro_PeriodicEntity>
    {

        #region Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        bool blNew = true;
        WebServiceRepository<MultipleContext_MIS_Pro_PeriodicEntity> repository_MC = new WebServiceRepository<MultipleContext_MIS_Pro_PeriodicEntity>();
        ObjectSerializationService obj = new ObjectSerializationService();
        //Report Repository
        WebServiceRepository<List<Rpt_MIS_Periodic1>> repository = new WebServiceRepository<List<Rpt_MIS_Periodic1>>();
        MultipleContext_MIS_Pro_PeriodicEntity _MC = new MultipleContext_MIS_Pro_PeriodicEntity();
        public MultipleContext_MIS_Pro_PeriodicEntity MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value;

                    RaisePropertyChanged("MC");
                }
            }
        }

        private MIS_Pro_PeriodicEntity _ReportParametersEntity;
        public MIS_Pro_PeriodicEntity ReportParametersEntity
        {
            get
            {

                return _ReportParametersEntity;
            }
            set
            {
                _ReportParametersEntity = value;
                RaisePropertyChanged("ReportParametersEntity");
            }
        }

        public List<ADM_M002> _ObjComp = new List<ADM_M002>();
        private List<ADM_M002> ObjComp
        {
            get { return _ObjComp; }
            set
            {
                if (_ObjComp != value)
                {
                    _ObjComp = value;
                }
            }
        }

        public List<ADM_M003> _ObjPlant = new List<ADM_M003>();
        private List<ADM_M003> ObjPlant
        {
            get { return _ObjPlant; }
            set
            {
                if (_ObjPlant != value)
                {
                    _ObjPlant = value;
                }
            }
        }

        



        private List<Rpt_MIS_Periodic1> _dsReport;
        public List<Rpt_MIS_Periodic1> dsReport
        {
            get { return _dsReport; }
            set
            {
                if (_dsReport != value)
                {
                    _dsReport = value;


                    RaisePropertyChanged("dsReport");

                }
            }
        }

        #endregion

        #region

        private Dictionary<string, string> _ReportItemsDictionary;
        public Dictionary<string, string> ReportItemsDictionary
        {
            get { return _ReportItemsDictionary; }
            set
            {
                if (_ReportItemsDictionary != value)
                {
                    _ReportItemsDictionary = value;
                    RaisePropertyChanged("ReportItemsDictionary");
                }
            }
        }

        private Dictionary<string, string> _TipTypeDictionary;
        public Dictionary<string, string> TipTypeDictionary
        {
            get { return _TipTypeDictionary; }
            set
            {
                if (_TipTypeDictionary != value)
                {
                    _TipTypeDictionary = value;
                    RaisePropertyChanged("TipTypeDictionary");
                }
            }
        }

        private Dictionary<string, string> _SalesDictionary;
        public Dictionary<string, string> SalesDictionary
        {
            get { return _SalesDictionary; }
            set
            {
                if (_SalesDictionary != value)
                {
                    _SalesDictionary = value;
                    RaisePropertyChanged("SalesDictionary");
                }
            }
        }

        private Dictionary<string, string> _BlankDictionary;
        public Dictionary<string, string> BlankDictionary
        {
            get { return _BlankDictionary; }
            set
            {
                if (_BlankDictionary != value)
                {
                    _BlankDictionary = value;
                    RaisePropertyChanged("BlankDictionary");
                }
            }
        }

        private Dictionary<string, object> _MachTypeDictionary;
        public Dictionary<string, object> MachTypeDictionary
        {
            get { return _MachTypeDictionary; }
            set
            {
                if (_MachTypeDictionary != value)
                {
                    _MachTypeDictionary = value;
                    RaisePropertyChanged("MachTypeDictionary");
                }
            }
        }

        private Dictionary<string, object> _empDictionaryParent;
        public Dictionary<string, object> EmpDictionaryParent
        {
            get { return _empDictionaryParent; }
            set
            {
                if (_empDictionaryParent != value)
                {
                    _empDictionaryParent = value;
                    RaisePropertyChanged("EmpDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _PartyDictionary;
        public Dictionary<string, object> PartyDictionary
        {
            get { return _PartyDictionary; }
            set
            {
                if (_PartyDictionary != value)
                {
                    _PartyDictionary = value;
                    RaisePropertyChanged("PartyDictionary");
                }
            }
        }

        private Dictionary<string, object> _PartyDictionaryParent;
        public Dictionary<string, object> PartyDictionaryParent
        {
            get { return _PartyDictionaryParent; }
            set
            {
                if (_PartyDictionaryParent != value)
                {
                    _PartyDictionaryParent = value;
                    RaisePropertyChanged("PartyDictionaryParent");
                }
            }
        }


        private Dictionary<string, object> _compDictionaryParent;
        public Dictionary<string, object> CompDictionaryParent
        {
            get { return _compDictionaryParent; }
            set
            {
                if (_compDictionaryParent != value)
                {
                    _compDictionaryParent = value;
                    RaisePropertyChanged("CompDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _plantDictionaryParent;
        public Dictionary<string, object> PlantDictionaryParent
        {
            get { return _plantDictionaryParent; }
            set
            {
                if (_plantDictionaryParent != value)
                {
                    _plantDictionaryParent = value;
                    RaisePropertyChanged("PlantDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _unitDictionaryParent;
        public Dictionary<string, object> UnitDictionaryParent
        {
            get { return _unitDictionaryParent; }
            set
            {
                if (_unitDictionaryParent != value)
                {
                    _unitDictionaryParent = value;
                    RaisePropertyChanged("UnitDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _machineDictionaryParent;
        public Dictionary<string, object> machineDictionaryParent
        {
            get { return _machineDictionaryParent; }
            set
            {
                if (_machineDictionaryParent != value)
                {
                    _machineDictionaryParent = value;
                    RaisePropertyChanged("machineDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _catDictionaryParent;
        public Dictionary<string, object> CatDictionaryParent
        {
            get { return _catDictionaryParent; }
            set
            {
                if (_catDictionaryParent != value)
                {
                    _catDictionaryParent = value;
                    RaisePropertyChanged("CatDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _subCatDictionaryParent;
        public Dictionary<string, object> SubCatDictionaryParent
        {
            get { return _subCatDictionaryParent; }
            set
            {
                if (_subCatDictionaryParent != value)
                {
                    _subCatDictionaryParent = value;
                    RaisePropertyChanged("SubCatDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _ItemTyDictionaryParent;
        public Dictionary<string, object> ItemTyDictionaryParent
        {
            get { return _ItemTyDictionaryParent; }
            set
            {
                if (_ItemTyDictionaryParent != value)
                {
                    _ItemTyDictionaryParent = value;
                    RaisePropertyChanged("ItemTyDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _SubItemTyDictionaryParent;
        public Dictionary<string, object> SubItemTyDictionaryParent
        {
            get { return _SubItemTyDictionaryParent; }
            set
            {
                if (_SubItemTyDictionaryParent != value)
                {
                    _SubItemTyDictionaryParent = value;
                    RaisePropertyChanged("SubItemTyDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _GradeDictionaryParent;
        public Dictionary<string, object> GradeDictionaryParent
        {
            get { return _GradeDictionaryParent; }
            set
            {
                if (_GradeDictionaryParent != value)
                {
                    _GradeDictionaryParent = value;
                    RaisePropertyChanged("GradeDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _WireTyDictionaryParent;
        public Dictionary<string, object> WireTyDictionaryParent
        {
            get { return _WireTyDictionaryParent; }
            set
            {
                if (_WireTyDictionaryParent != value)
                {
                    _WireTyDictionaryParent = value;
                    RaisePropertyChanged("WireTyDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _BallTyDictionaryParent;
        public Dictionary<string, object> BallTyDictionaryParent
        {
            get { return _BallTyDictionaryParent; }
            set
            {
                if (_BallTyDictionaryParent != value)
                {
                    _BallTyDictionaryParent = value;
                    RaisePropertyChanged("BallTyDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _ILDDictionaryParent;
        public Dictionary<string, object> ILDDictionaryParent
        {
            get { return _ILDDictionaryParent; }
            set
            {
                if (_ILDDictionaryParent != value)
                {
                    _ILDDictionaryParent = value;
                    RaisePropertyChanged("ILDDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _InkDictionaryParent;
        public Dictionary<string, object> InkDictionaryParent
        {
            get { return _InkDictionaryParent; }
            set
            {
                if (_InkDictionaryParent != value)
                {
                    _InkDictionaryParent = value;
                    RaisePropertyChanged("InkDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _ShaftDictionaryParent;
        public Dictionary<string, object> ShaftDictionaryParent
        {
            get { return _ShaftDictionaryParent; }
            set
            {
                if (_ShaftDictionaryParent != value)
                {
                    _ShaftDictionaryParent = value;
                    RaisePropertyChanged("ShaftDictionaryParent");
                }
            }
        }

        private Dictionary<string, object> _FormTyDictionary;
        public Dictionary<string, object> FormTyDictionary
        {
            get { return _FormTyDictionary; }
            set
            {
                if (_FormTyDictionary != value)
                {
                    _FormTyDictionary = value;
                    RaisePropertyChanged("FormTyDictionary");
                }
            }
        }

        private Dictionary<string, object> _SalesTyDictionary;
        public Dictionary<string, object> SalesTyDictionary
        {
            get { return _SalesTyDictionary; }
            set
            {
                if (_SalesTyDictionary != value)
                {
                    _SalesTyDictionary = value;
                    RaisePropertyChanged("SalesTyDictionary");
                }
            }
        }

        #endregion

        #region ICollection

        private ICollectionView _PartyCollection;
        public ICollectionView PartyCollection
        {
            get { return _PartyCollection; }
            set { _PartyCollection = value; RaisePropertyChanged("PartyCollevtion"); }
        }

        private ICollectionView _MachineCollection;// Machine Collection
        public ICollectionView MachineCollection
        {
            get { return _MachineCollection; }
            set
            {
                _MachineCollection = value;
                RaisePropertyChanged("MachineCollection");
            }
        }

        private ICollectionView _ItemsCollection;
        public ICollectionView ItemsCollection
        {
            get { return _ItemsCollection; }
            set { _ItemsCollection = value; RaisePropertyChanged("ItemsCollection"); }
        }

        private ICollectionView _CompanyCollection;
        public ICollectionView CompanyCollection
        {
            get { return _CompanyCollection; }
            set
            {
                _CompanyCollection = value;
                RaisePropertyChanged("CompanyCollection");
            }
        }

        private ICollectionView _uomCollection;
        public ICollectionView UomCollection
        {
            get { return _uomCollection; }
            set { _uomCollection = value; RaisePropertyChanged("UomCollection"); }
        }

        private ICollectionView _PlantCollection;
        public ICollectionView PlantCollection
        {
            get { return _PlantCollection; }
            set { _PlantCollection = value; RaisePropertyChanged("PlantCollection"); }
        }

        #endregion

        #region StringList Variables
        private List<string> _stringListParty;
        public List<string> StringListParty
        {
            get { return _stringListParty; }
            set
            {
                if (_stringListParty != value)
                {
                    _stringListParty = value;
                }
            }
        }



        private List<string> _stringListItems;
        public List<string> StringListItems
        {
            get { return _stringListItems; }
            set
            {
                if (_stringListItems != value)
                {
                    _stringListItems = value;
                }
            }
        }
        private List<string> _srtListCompany;
        public List<string> StringListCompany
        {
            get { return _srtListCompany; }
            set
            {
                if (_srtListCompany != value)
                {
                    _srtListCompany = value;
                }
            }
        }

        List<string> _strListPlant;
        public List<string> StringListPlant
        {
            get { return _strListPlant; }
            set
            {
                if (_strListPlant != value)
                {
                    _strListPlant = value;
                }
            }
        }

        private List<ADM_M024_P> _strListEmployee;
        public List<ADM_M024_P> StringListEmployee
        {
            get { return _strListEmployee; }
            set
            {
                if (_strListEmployee != value)
                {
                    _strListEmployee = value;
                    RaisePropertyChanged("StringListEmployee");
                }
            }
        }

        private List<ADM_M002> _strListCompany;
        public List<ADM_M002> StrListCompany
        {
            get { return _strListCompany; }
            set
            {
                if (_strListCompany != value)
                {
                    _strListCompany = value;
                    RaisePropertyChanged("StrListCompany");
                }
            }
        }

        //private List<ADM_M003> _strListPlant;
        //public List<ADM_M003> StrListPlant
        //{
        //    get { return _strListPlant; }
        //    set
        //    {
        //        if (_strListPlant != value)
        //        {
        //            _strListPlant = value;
        //            RaisePropertyChanged("StrListPlant");
        //        }
        //    }
        //}

        private List<ADM_M038_B_P> _strListUnit;
        public List<ADM_M038_B_P> StrListUnit
        {
            get { return _strListUnit; }
            set
            {
                if (_strListUnit != value)
                {
                    _strListUnit = value;
                    RaisePropertyChanged("StrListUnit");
                }
            }
        }

        private List<ZADM_M013_P> _strListMachine;
        public List<ZADM_M013_P> StrListMachine
        {
            get { return _strListMachine; }
            set
            {
                if (_strListMachine != value)
                {
                    _strListMachine = value;
                    RaisePropertyChanged("StrListMachine");
                }
            }
        }

        private List<ADM_M018_P> _strListCategory;
        public List<ADM_M018_P> StrListCategory
        {
            get { return _strListCategory; }
            set
            {
                if (_strListCategory != value)
                {
                    _strListCategory = value;
                    RaisePropertyChanged("StrListCategory");
                }
            }
        }

        private List<ADM_M019_P> _strListSubCategory;
        public List<ADM_M019_P> StrListSubCategory
        {
            get { return _strListSubCategory; }
            set
            {
                if (_strListSubCategory != value)
                {
                    _strListSubCategory = value;
                    RaisePropertyChanged("StrListSubCategory");
                }
            }
        }

        private List<string> _stringListUOM;
        public List<string> StringListUOM
        {
            get { return _stringListUOM; }
            set
            {
                if (_stringListUOM != value)
                {
                    _stringListUOM = value;
                }
            }
        }

        List<string> _stringListMachine;
        public List<string> StringListMachine
        {
            get { return _stringListMachine; }
            set
            {
                if (_stringListMachine != value)
                {
                    _stringListMachine = value;
                }
            }
        }

        private List<ADM_M015_P> _strListItemTy;
        public List<ADM_M015_P> StrListItemTy
        {
            get { return _strListItemTy; }
            set
            {
                if (_strListItemTy != value)
                {
                    _strListItemTy = value;
                    RaisePropertyChanged("StrListItemTy");
                }
            }
        }

        private List<ADM_M045_P> _strListGrade;
        public List<ADM_M045_P> strListGrade
        {
            get { return _strListGrade; }
            set
            {
                if (_strListGrade != value)
                {
                    _strListGrade = value;
                    RaisePropertyChanged("strListGrade");
                }
            }
        }

        private List<ZADM_M002_P> _strListBallTy;
        public List<ZADM_M002_P> strListBallTy
        {
            get { return _strListBallTy; }
            set
            {
                if (_strListBallTy != value)
                {
                    _strListBallTy = value;
                    RaisePropertyChanged("strListBallTy");
                }
            }
        }

        private List<ZADM_M007_P> _strListILD;
        public List<ZADM_M007_P> strListILD
        {
            get { return _strListILD; }
            set
            {
                if (_strListILD != value)
                {
                    _strListILD = value;
                    RaisePropertyChanged("strListILD");
                }
            }
        }

        private List<ZADM_M006_P> _strListInk;
        public List<ZADM_M006_P> strListInk
        {
            get { return _strListInk; }
            set
            {
                if (_strListInk != value)
                {
                    _strListInk = value;
                    RaisePropertyChanged("_strListInk");
                }
            }
        }

        private List<ADM_M042_P> _strListShaft;
        public List<ADM_M042_P> strListShaft
        {
            get { return _strListShaft; }
            set
            {
                if (_strListShaft != value)
                {
                    _strListShaft = value;
                    RaisePropertyChanged("strListShaft");
                }
            }
        }

        private List<ACC_M013_P> _strListFormTy;
        public List<ACC_M013_P> strListFormTy
        {
            get { return _strListFormTy; }
            set
            {
                if (_strListFormTy != value)
                {
                    _strListFormTy = value;
                    RaisePropertyChanged("strListFormTy");
                }
            }
        }

        private List<SEL_T001_P> _strListSalesTy;
        public List<SEL_T001_P> strListSalesTy
        {
            get { return _strListSalesTy; }
            set
            {
                if (_strListSalesTy != value)
                {
                    _strListSalesTy = value;
                    RaisePropertyChanged("strListSalesTy");
                }
            }
        }



        private List<ZADM_M004_P> _strListWireTy;
        public List<ZADM_M004_P> strListWireTy
        {
            get { return _strListWireTy; }
            set
            {
                if (_strListWireTy != value)
                {
                    _strListWireTy = value;
                    RaisePropertyChanged("strListWireTy");
                }
            }
        }

        private List<ADM_M016_P> _strListSubItemTy;
        public List<ADM_M016_P> StrListSubItemTy
        {
            get { return _strListSubItemTy; }
            set
            {
                if (_strListSubItemTy != value)
                {
                    _strListSubItemTy = value;
                    RaisePropertyChanged("StrListSubItemTy");
                }
            }
        }


        #endregion

        #region RelayCommands      
        public RelayCommand cmdReport { get; private set; }
        public RelayCommand<object> cmdCompanyChange { get; private set; }
        public RelayCommand<object> cmdPartyChange { get; private set; }
        public RelayCommand<object> cmdItemChange { get; private set; }
        public RelayCommand<object> cmdUnitChange { get; private set; }
        public RelayCommand CommandForClearData { get; private set; }
        public RelayCommand<object> cmdMachine { get; private set; }
        public RelayCommand<object> cmdPlant { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }


        #endregion

        #region Constructor
        public MIS_Pro_PeriodicVM(string ts_code)
            : base()
        {
            CursorControl.SetBusyState();
            this.ts_code_vm = ts_code; 
            MC = new MultipleContext_MIS_Pro_PeriodicEntity();
            ReportParametersEntity = new MIS_Pro_PeriodicEntity();
            _dsReport = new List<Rpt_MIS_Periodic1>();
            ReportItemsDictionary = new Dictionary<string, string>();
    
            ReportItemsDictionary.Add("R001", "Item Wise Production");
            ReportItemsDictionary.Add("R002", "Machine Wise Production");
            ReportItemsDictionary.Add("R003", "Shift Wise Production");
            ReportItemsDictionary.Add("R004", "Item Wise Average Production");
            ReportItemsDictionary.Add("R005", "Item Wise Rejection");
            ReportItemsDictionary.Add("R006", "Machine Wise Rejection");
            ReportItemsDictionary.Add("R007", "Shortage Report");
            ReportItemsDictionary.Add("R008", "Wire Make Wise Production");
            ReportItemsDictionary.Add("R009", "Raw Material Consumption Report");
            ReportItemsDictionary.Add("R011", "Machine Wise Production Detail");
            //ReportItemsDictionary.Add("R010", "Essem Stock Statement");
            ReportItemsDictionary.Add("R012", "Monthly Conversion Report");
            ReportItemsDictionary.Add("R013", "Production Conversion to FG(Grade)");
            ReportItemsDictionary.Add("R014", "Production Conversion to RM");
            ReportItemsDictionary.Add("R015", "Machine Type Wise Production-Details");
            ReportItemsDictionary.Add("R016", "Machine Type Wise Production-Summary");
            ReportItemsDictionary.Add("R017", "Machine Wise Yearly Production");
            ReportItemsDictionary.Add("R018", "Item Wise Yearly Production");
            ReportItemsDictionary.Add("R019", "Machine Wise Total Production");
            ReportItemsDictionary.Add("R020", "Month Wise Average Production");
            ReportItemsDictionary.Add("R021", "Production Detail For Product");
            ReportItemsDictionary.Add("R022", "DateWise Total Production");
            ReportItemsDictionary.Add("R023", "DateWise Total Production Group By Engineer");
            ReportItemsDictionary.Add("R024", "MachineWise Total Production Group By Engineer");
            ReportItemsDictionary.Add("R025", "Monthly Conversion Details Report");
            ReportItemsDictionary.Add("R026", "Counter & Actual Production Report");
            ReportItemsDictionary.Add("R027", " Average Weight Finish Goods");
            ReportItemsDictionary.Add("R029", "Raw Material Consumption Report(Wiresize wise)");
            ReportItemsDictionary.Add("R030", "Raw Material Consumption Report(Ballsize wise)");
            ReportItemsDictionary.Add("R031", "Production Planning Report");
            ReportItemsDictionary.Add("R032", "Monthly Machine Conversion Report");
            ReportItemsDictionary.Add("R034", "Date Wise Wire Length Running Cycle");
            ReportItemsDictionary.Add("R035", "Date Wise Ball Running Cycle");
            ReportItemsDictionary.Add("R036", "Machine Running Status");
            ReportItemsDictionary.Add("R037", "Machine Capacity");

            TipTypeDictionary = new Dictionary<string, string>();
            TipTypeDictionary.Add("T01", "OBI");
            TipTypeDictionary.Add("T02", "GBI");
            TipTypeDictionary.Add("T03", "All");

            SalesDictionary = new Dictionary<string, string>();
            SalesDictionary.Add("S01", "All");
            SalesDictionary.Add("S02", "Self");
            SalesDictionary.Add("S03", "Trading");
         
            BlankDictionary = new Dictionary<string, string>();
            BlankDictionary.Add("B01", "All");
            BlankDictionary.Add("B02", "Yes");
            BlankDictionary.Add("B03", "No");

            MachTypeDictionary = new Dictionary<string, object>();
            MachTypeDictionary.Add("All", "All");
            MachTypeDictionary.Add("LX", "LX");
            MachTypeDictionary.Add("PM", "PM");
            #region Command Initialisation
            cmdPartyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items, blNew); });
            cmdCompanyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            cmdItemChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
            cmdMachine = new RelayCommand<object>(items => { if (items == null) { return; } InsertMachine(items); });
            cmdPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
            cmdUnitChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertUnit(items); });
            CommandForClearData = new RelayCommand(ClearData);
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

            cmdReport = new RelayCommand(DisplayReport);
            #endregion
            DefaultValues();
            LoadInitialData();
            
        }
       


        #endregion  foreach (int element in fibarray)

        #region User Defined Function
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MIS_Pro_PeriodicEntity>(MC, Request, "MIS_Pro_Periodics", "Production", "LoadAll", 0, "");


                //Load Data on Party
                PartyCollection = CollectionViewSource.GetDefaultView(MC.PartyMaster);
                PartyCollection.Filter = new Predicate<object>(FilterParty);


                //items
                ItemsCollection = CollectionViewSource.GetDefaultView(MC.ItemDetails);
                ItemsCollection.Filter = new Predicate<object>(FilterItem);

                //Employee
                var EmpListParent = (from o in MC.Employee
                                     where o.EmpId != null
                                     select o).ToList();
                _strListEmployee = EmpListParent;
                EmpDictionaryParent = _strListEmployee.ToDictionary(X => X.EmpId.ToString(), X => (object)X.EmpName);

                //Company
                ObjComp = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                CompanyCollection = CollectionViewSource.GetDefaultView(ObjComp.ToList());
                CompanyCollection.Filter = new Predicate<object>(FilterCompany);
                StringListCompany = ObjComp.Select(x => x.comp_code).ToList();

                // Plant or Location
                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantCollection = CollectionViewSource.GetDefaultView(ObjPlant.ToList());
                PlantCollection.Filter = new Predicate<object>(FilterPlant);
                StringListPlant = ObjPlant.Select(x => x.location_Id).ToList();

                //Unit

                UomCollection = CollectionViewSource.GetDefaultView(MC.UnitDetails.ToList());
                UomCollection.Filter = new Predicate<object>(FilterUom);
                StringListUOM = MC.UnitDetails.Select(x => x.unit_code).ToList();



                //machine code

                //var machineListParent = (from o in MC.machineDetails
                //                         where o.machine_id.ToString() != null
                //                         select o).ToList();
                //_strListMachine = machineListParent;
                //machineDictionaryParent = _strListMachine.ToDictionary(X => X.machine_id.ToString(), X => (object)X.machinecode);

                var LocWiseMachine = (from o in MC.machineDetails
                                      where o.location_Id == ReportParametersEntity.location_Id
                                      select o).ToList();
                MachineCollection = CollectionViewSource.GetDefaultView(LocWiseMachine.ToList());
                MachineCollection.Filter = new Predicate<object>(MachineFilter);
                StringListMachine = MC.machineDetails.Select(x => x.machinecode.ToString()).ToList();

                //Category
                var categoryListParent = (from o in MC.CategoryDetails
                                          where o.CatCode.ToString() != null
                                          select o).ToList();
                _strListCategory = categoryListParent;
                CatDictionaryParent = _strListCategory.ToDictionary(X => X.CatCode.ToString(), X => (object)X.CatName);

                //SubCategory
                var SubCatListParent = (from o in MC.SubCategoryDetails
                                        where o.SubCatCode != null
                                        select o).ToList();
                _strListSubCategory = SubCatListParent;
                SubCatDictionaryParent = _strListSubCategory.ToDictionary(X => X.SubCatCode.ToString(), X => (object)X.SubCatName);

                //ItemType  
                var ItemTyListParent = (from o in MC.ItemTyDetails
                                        where o.ItemTypeCd != null
                                        select o).ToList();
                _strListItemTy = ItemTyListParent;
                ItemTyDictionaryParent = _strListItemTy.ToDictionary(X => X.ItemTypeCd.ToString(), X => (object)X.ItemTypeNm);

                //SubItemType
                var SubItemTyListParent = (from o in MC.SubItemTyDetails
                                           where o.SubItemTpCd != null
                                           select o).ToList();
                _strListSubItemTy = SubItemTyListParent;
                SubItemTyDictionaryParent = _strListSubItemTy.ToDictionary(X => X.SubItemTpCd.ToString(), X => (object)X.SubItemTpNm);

                //Grade
                var GradeListParent = (from o in MC.GradeDetails
                                           where o.grade_code != null
                                           select o).ToList();
                _strListGrade = GradeListParent;
                GradeDictionaryParent = _strListGrade.ToDictionary(X => X.grade_code.ToString(), X => (object)X.grade_code);


                //Wire
                var WireListParent = (from o in MC.WireTypeDetails
                                       where o.wire_type_id.ToString()!= null
                                       select o).ToList();
                _strListWireTy = WireListParent;
                 WireTyDictionaryParent = _strListWireTy.ToDictionary(X => X.wire_type_id.ToString(), X => (object)X.wire_type);

                //BallType
                var BallTyListParent = (from o in MC.BallTypeDetails
                                      where o.ball_type_id.ToString() != null
                                      select o).ToList();
                _strListBallTy = BallTyListParent;
                BallTyDictionaryParent= _strListBallTy.ToDictionary(X => X.ball_type_id.ToString(), X => (object)X.ball_type);

                //ILD
                var ILDListParent = (from o in MC.ILDDetails
                                      where o.ild != null
                                      select o).ToList();
                _strListILD = ILDListParent;
                ILDDictionaryParent = _strListILD.ToDictionary(X => X.ild.ToString(), X => (object)X.ild);

                //Ink
                var InkListParent = (from o in MC.InkDetails
                                      where o.ink.ToString() != null
                                      select o).ToList();
                _strListInk = InkListParent;
                InkDictionaryParent = _strListInk.ToDictionary(X => X.ink.ToString(), X => (object)X.ink);

                //Shift
                var ShiftListParent = (from o in MC.ShiftDetails
                                      where o.shift != null
                                      select o).ToList();
                _strListShaft = ShiftListParent;
               ShaftDictionaryParent = _strListShaft.ToDictionary(X => X.shift.ToString(), X => (object)X.shift);


                //Form Type or tax Master
                var FormTyListParent = (from o in MC.FormTyDetails
                                       where o.id.ToString() != null
                                       select o).ToList();
                _strListFormTy = FormTyListParent;
                FormTyDictionary = _strListFormTy.ToDictionary(X => X.id.ToString(), X => (object)X.description);
               
                //Sales Type
                var SalesTyListParent = (from o in MC.SalesTyDetails
                                        where o.local_export!= null
                                        select o).ToList();
                _strListSalesTy = SalesTyListParent;
                SalesTyDictionary= _strListSalesTy.ToDictionary(X => X.local_export.ToString(), X => (object)X.local_export);
            }
            catch (Exception ex)
            {

                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void DefaultValues()
        {

            ReportParametersEntity.comp_code = AppSessionState.comp_code; 
            //ReportParametersEntity.fin_year = AppSessionState.FinYear;
            ReportParametersEntity.location_Id = AppSessionState.location_Id;
            ReportParametersEntity.ts_code = ts_code_vm;
            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            ReportParametersEntity.FromDate = lastDayLastMonth.AddDays(0);
            ReportParametersEntity.ToDate = DateTime.Now;
        }
        private void ClearData()
        {
            try
            {
                ReportParametersEntity = new MIS_Pro_PeriodicEntity();
                DefaultValues();
            }
            catch (Exception ex)
            {

                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        } 
        private void DisplayReport()
        {              
            CursorControl.SetBusyState();
            try
            {
                if (ReportParametersEntity.ReportCode.ToString() == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Report Type");
                    showMessageService.ShowMessage();
                }

                //Check if Fields are not Selected then assign it to 'All'.
                if (ReportParametersEntity.ReportCode.ToString() != "")
                {
                    if (ReportParametersEntity.PartyId == null) { ReportParametersEntity.PartyId = "All"; }
                    if (ReportParametersEntity.PartyNm == null) { ReportParametersEntity.PartyNm = "All"; }
                    if (ReportParametersEntity.ItemCode == null) { ReportParametersEntity.ItemCode = "All"; }
                    if (ReportParametersEntity.ItemName == null) { ReportParametersEntity.ItemName = "All"; }
                    if (ReportParametersEntity.EmpId == null) { ReportParametersEntity.EmpId = "All"; }
                    if (ReportParametersEntity.CatCode == null) { ReportParametersEntity.CatCode = "All"; }
                    if (ReportParametersEntity.CatName == null) { ReportParametersEntity.CatName = "All"; }
                    if (ReportParametersEntity.SubCatCode == null) { ReportParametersEntity.SubCatCode = "All"; }
                    if (ReportParametersEntity.ItemTypeCd == null) { ReportParametersEntity.ItemTypeCd = "All"; }
                    if (ReportParametersEntity.SubItemTpCd == null) { ReportParametersEntity.SubItemTpCd = "All"; }
                    if (ReportParametersEntity.TipType == null) { ReportParametersEntity.TipType = "All"; }
                    if (ReportParametersEntity.grade_code == null) { ReportParametersEntity.grade_code = "All"; }
                    if (ReportParametersEntity.local_export == null) { ReportParametersEntity.local_export = "All"; }
                    if (ReportParametersEntity.description == null) { ReportParametersEntity.description = "All"; }
                    if (ReportParametersEntity.wire_type == null) { ReportParametersEntity.wire_type = "All"; }
                    if (ReportParametersEntity.ball_type == null) { ReportParametersEntity.ball_type = "All"; }
                    if (ReportParametersEntity.ild == null) { ReportParametersEntity.ild = "All"; }
                    if (ReportParametersEntity.ink == null) { ReportParametersEntity.ink = "All"; }
                    if (ReportParametersEntity.SalesAccount == null) { ReportParametersEntity.SalesAccount = "All"; }
                    if (ReportParametersEntity.Blank == null) { ReportParametersEntity.Blank = "All"; }
                    if (ReportParametersEntity.shift == null) { ReportParametersEntity.shift = "All"; }
                    if (ReportParametersEntity.machine_id == null) { ReportParametersEntity.machine_id = 0; }
                    //if (ReportParametersEntity.unit_code == null) { ReportParametersEntity.unit_code = "All"; }
                    if (ReportParametersEntity.machinecode == null) { ReportParametersEntity.machinecode = "All"; }
                    if (ReportParametersEntity.mctype == null) { ReportParametersEntity.mctype = "All"; }

                }
                if (ReportParametersEntity.unit_code == null || ReportParametersEntity.unit_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Unit Code is Required");
                    showMessageService.ShowMessage();


                }

                else
                {

                    ReportParametersEntity = ReportParametersEntity;
                    if (ReportParametersEntity.ReportCode.ToString() != "")
                    {
                        string RequestParameter = "Report" + "!@" + ReportParametersEntity.ReportCode + "!@" + ReportParametersEntity.ItemCode + "!@" + ReportParametersEntity.PartyId + "!@" + ReportParametersEntity.location_Id + "!@" + ReportParametersEntity.comp_code + "!@" + Convert.ToDateTime(ReportParametersEntity.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParametersEntity.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParametersEntity.TipType + "!@" + ReportParametersEntity.unit_code + "!@" + ReportParametersEntity.shift + "!@" + ReportParametersEntity.machinecode + "!@" + ReportParametersEntity.wire_type + "!@" + ReportParametersEntity.ball_type + "!@" + ReportParametersEntity.ild + "!@" + ReportParametersEntity.ink + "!@" + ReportParametersEntity.Blank + "!@" + ReportParametersEntity.mctype + "!@" + ReportParametersEntity.grade_code;


                        dsReport = repository.GetDataWithReturnDomainObject<List<Rpt_MIS_Periodic1>>(dsReport, RequestParameter, "MIS_Pro_Periodics", "Production", "", 0, RequestParameter);

                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        objDataSource[0] = dsReport;

                        List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                        var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == ReportParametersEntity.comp_code).ToList();
                        objDataSource[1] = CmpResult;

                        List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                        var Result = TempList.Where(loc => loc.location_Id == ReportParametersEntity.location_Id).ToList();
                        objDataSource[2] = Result;


                        objDataSourceName[0] = "dsRpt_MIS_Periodic1";
                        objDataSourceName[1] = "dsCompany";
                        objDataSourceName[2] = "dsLocation";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\Production\\" + GetReportFile(ReportParametersEntity.ReportCode), getParametersList(), "");

                    }
                }
            }
            catch (Exception ex)
            {

                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("PartyId", ReportParametersEntity.PartyId);
                result.Add("PartyNm", ReportParametersEntity.PartyNm);
                result.Add("FromDate", Convert.ToString(ReportParametersEntity.FromDate));
                result.Add("ToDate", Convert.ToString(ReportParametersEntity.ToDate));
                result.Add("ItemCode", ReportParametersEntity.ItemCode);
                result.Add("ItemName", ReportParametersEntity.ItemName);
                result.Add("location_Id", ReportParametersEntity.location_Id);
                result.Add("comp_code", ReportParametersEntity.comp_code);
                result.Add("unit_code", ReportParametersEntity.unit_code);
                result.Add("grade_code", ReportParametersEntity.grade_code);
                result.Add("TipType", ReportParametersEntity.TipType);
                result.Add("wire_type", ReportParametersEntity.wire_type);
                result.Add("ball_type", ReportParametersEntity.ball_type);
                result.Add("ink", ReportParametersEntity.ink);
                result.Add("ild", ReportParametersEntity.ild);
                result.Add("CatCode", ReportParametersEntity.CatCode);
                result.Add("SubCatCode", ReportParametersEntity.SubCatCode);
                result.Add("ItemTypeCd", ReportParametersEntity.ItemTypeCd);
                result.Add("SubItemTpCd", ReportParametersEntity.SubItemTpCd);
                result.Add("ReportName", ReportParametersEntity.ReportName);
                result.Add("Blank", ReportParametersEntity.Blank);
                result.Add("SalesAccount", ReportParametersEntity.SalesAccount);
                result.Add("description", ReportParametersEntity.description);
                result.Add("OrderByName", ReportParametersEntity.OrderByName);
                result.Add("local_export", ReportParametersEntity.local_export);
                result.Add("machinecode", ReportParametersEntity.machinecode);
                result.Add("shift", ReportParametersEntity.shift);
                result.Add("mctype", ReportParametersEntity.mctype);

            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
            return result;
        }
        private string GetReportFile(string ReportCode)
        {
            string returnReportName = "";
            if (ReportCode == "R001")
            { returnReportName = "ProductionReport.rdlc"; }
            else if (ReportCode == "R002")
            { returnReportName = "ItemWiseProduction.rdlc"; }
            else if (ReportCode == "R003")
            { returnReportName = "ShiftWiseProduction1.rdlc"; }
            else if (ReportCode == "R004")
            { returnReportName = "ItemWiseAverageProduction.rdlc"; }
            else if (ReportCode == "R005")
            { returnReportName = "ItemWiseRejection.rdlc"; }
            else if (ReportCode == "R006")
            { returnReportName = "MachineWiseRejection.rdlc"; }
            else if (ReportCode == "R007")
            { returnReportName = "ShortageReport.rdlc"; }
            else if (ReportCode == "R008")
            { returnReportName = "WireWiseProductionReport.rdlc"; }
            else if (ReportCode == "R009")
            { returnReportName = "WireConsumptionReport.rdlc"; }
            else if (ReportCode == "R011")
            { returnReportName = "GradeWiseReport.rdlc"; }
            //else if (ReportCode == "R010")
            //{ returnReportName = "CurrentStockReport.rdlc"; }
            else if (ReportCode == "R012")
            { returnReportName = "MonthlyConversionrpt.rdlc"; }
            else if (ReportCode == "R025")
            { returnReportName = "MonthlyConversionDetailrpt.rdlc"; }
            else if (ReportCode == "R013")
            { returnReportName = "GradeConversionByProduct.rdlc"; }
            else if (ReportCode == "R014")
            { returnReportName = "ProductConversionByProduct.rdlc"; }
            else if (ReportCode == "R015")
            { returnReportName = "MCTypeWiseProduction.rdlc"; }
            else if (ReportCode == "R016")
            { returnReportName = "MCTypeWiseProductionSummary.rdlc"; }
            else if (ReportCode == "R017")
            { returnReportName = "MachineWiseYearlyPro.rdlc"; }
            else if (ReportCode == "R018")
            { returnReportName = "ItemWiseYearlyPro.rdlc"; }
            else if (ReportCode == "R019")
            { returnReportName = "MachineWiseTotalProduction.rdlc"; }
            else if (ReportCode == "R020")
            { returnReportName = "MonthWiseAverageProduction.rdlc"; }
            else if (ReportCode == "R021")
            { returnReportName = "ProductionDetail.rdlc"; }
            else if (ReportCode == "R022")
            { returnReportName = "DateWiseTotalProduction.rdlc"; }
            else if (ReportCode == "R023")
            { returnReportName = "DateWiseTotalProductionGroupByEngineer.rdlc"; }
            else if (ReportCode == "R024")
            { returnReportName = "MachineWiseTotalProductionGroupByEngineer.rdlc"; }
            else if (ReportCode == "R026")
            { returnReportName = "CounterActualProduction.rdlc"; }
            else if (ReportCode == "R027")
            { returnReportName = "AverageWeightReport.rdlc"; }
            else if (ReportCode == "R029")
            { returnReportName = "WireConsumptionReport1.rdlc"; }
            else if (ReportCode == "R030")
            { returnReportName = "WireConsumptionReport2.rdlc"; }
            else if (ReportCode == "R031")
            { returnReportName = "ProductionPlanningReport.rdlc"; }
            else if (ReportCode == "R032")
            { returnReportName = "MonthlyMachineConversionReport.rdlc"; }
            else if (ReportCode == "R034")
            { returnReportName = "DateWseWireLengthRunningStatus.rdlc"; }
            else if (ReportCode == "R035")
            { returnReportName = "DateWseBallRunningStatus.rdlc"; }
            else if (ReportCode == "R036")
            { returnReportName = "MachineRunningStatus.rdlc"; }
            else if (ReportCode == "R037")
            { returnReportName = "MachineCapacity.rdlc"; }
            return returnReportName;
        }
        private void InsertParty(object InputValue, bool OverrideValue)
        {

            string stringParty = "";
            string stringPartyNm = "";
            ReportParametersEntity.PartyId = "";
            foreach (ADM_M028_P temp in MC.PartyMaster)
            {
                if (temp.Select == true)
                {
                    stringParty = stringParty + "," + temp.PartyId;
                    stringPartyNm = stringPartyNm + "," + temp.PartyNm;
                }
            }
            ReportParametersEntity.PartyId = stringParty.ToString().TrimStart(new char[] { ',' });
            ReportParametersEntity.PartyNm = stringPartyNm.ToString().TrimStart(new char[] { ',' });

        }
        private void InsertItem(object InputValue)
        {

            string stringItems = "";
            string stringItemsNm = "";

            ReportParametersEntity.ItemCode = "";
            foreach (ADM_M022_P temp in MC.ItemDetails)
            {
                if (temp.Select == true)
                {
                    stringItems = stringItems + "," + temp.ItemCode;
                    stringItemsNm = stringItemsNm + "," + temp.ItemName;

                }
            }
            ReportParametersEntity.ItemCode = stringItems.ToString().TrimStart(new char[] { ',' });
            ReportParametersEntity.ItemName = stringItemsNm.ToString().TrimStart(new char[] { ',' });

        }
        private void InsertCompany(object InputValue)
        {
            string Request = "";
            ADM_M002 POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = ObjComp.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null)
                {

                    ReportParametersEntity.comp_code = POPUPEntityObject.comp_code;
                    ReportParametersEntity.CompName = POPUPEntityObject.CompName;
                }
            }

            catch (Exception ex)
            {

                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }

        }
        private void InsertMachine(object InputValue)
        {

            string stringMachineCode = "";
            ReportParametersEntity.machinecode = "";
            foreach (ZADM_M013_P temp in MC.machineDetails)
            {
                if (temp.Select == true)
                {
                    stringMachineCode = stringMachineCode + "," + temp.machinecode;
                }
            }
            ReportParametersEntity.machinecode = stringMachineCode.ToString().TrimStart(new char[] { ',' });
        }
        private void InsertUnit(object InputValue)
        {

           
            string Request = "";
            ADM_M038_B_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitDetails.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null)
                {

                    ReportParametersEntity.unit_code = POPUPEntityObject.unit_code;
                    ReportParametersEntity.unit_name = POPUPEntityObject.unit_name;

                }
            }

            catch (Exception ex)
            {

                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }

        private void InsertParty(object items, bool blNew, object sender)
        {
            throw new NotImplementedException();
        }
        //private void InsertPlant(object InputValue)
        //{
        //    string Request = "";
        //    ADM_M003 POPUPEntityObject = null;
        //    #region Command Parameter Read Section
        //    try
        //    {
        //        if (InputValue.GetType() == typeof(string) && InputValue != null)
        //        {
        //            Request = InputValue.ToString();
        //            if (Request.Length > 0)
        //            {
        //                try
        //                { POPUPEntityObject = ObjPlant.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                catch (Exception ex) { }
        //            }
        //        }
        //        else if (InputValue != null)
        //        {
        //            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
        //        }
        //    }
        //    catch (Exception ex) { }

        //    #endregion

        //    if (POPUPEntityObject != null)
        //    {

        //        ReportParametersEntity.location_Id = POPUPEntityObject.location_Id;

        //        var LocWiseMachine = (from o in MC.machineDetails
        //                              where o.location_Id == ReportParametersEntity.location_Id
        //                              select o).ToList();


        //        MachineCollection = CollectionViewSource.GetDefaultView(LocWiseMachine.ToList());
        //        MachineCollection.Filter = new Predicate<object>(MachineFilter);
        //        MachineCollection.Refresh();
        //    }

        //}

        private void InsertPlant(object InputValue)
        {
            string stringLocation = "";
            string stringLocationNm = "";

            ReportParametersEntity.location_Id = "";
            foreach (ADM_M003 temp in ObjPlant)
            {
                if (temp.Select == true)
                {
                    stringLocation = stringLocation + "," + temp.location_Id;
                    stringLocationNm = stringLocationNm + "," + temp.LoctnNm;

                }
            }
            ReportParametersEntity.location_Id = stringLocation.ToString().TrimStart(new char[] { ',' });
            ReportParametersEntity.LoctnNm = stringLocationNm.ToString().TrimStart(new char[] { ',' });


        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    //LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    //isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                    AppSessionState.ViewOtherRecordAllowed = true;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void Invoke_Reference_Document(object InputValue)
        {
            try
            {
                string Request = "";
                ReflectionFunctionService objRef = new ReflectionFunctionService();
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = ReportParametersEntity.client + "!@" + ReportParametersEntity.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }

        #endregion

        #region . Filter .
        private string _filterString_party;
        public string FilterString_party
        {
            get { return _filterString_party; }
            set
            {
                _filterString_party = value;
                RaisePropertyChanged("FilterString_party");
                FilterCollectionParty();
            }
        }
        private void FilterCollectionParty()
        {
            if (_PartyCollection != null)
            {
                _PartyCollection.Refresh();
            }
        }
        public bool FilterParty(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_party))
                {
                    return (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_party.ToLower()) ||
                        (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_party.ToLower())));
                }
                return true;
            }
            return false;
        }

        private string _filterString_Item;
        public string FilterString_Item
        {
            get { return _filterString_Item; }
            set
            {
                _filterString_Item = value;
                RaisePropertyChanged("FilterString_Item");
                FilterCollectionItem();
            }
        }
        private void FilterCollectionItem()
        {
            if (_ItemsCollection != null)
            {
                _ItemsCollection.Refresh();
            }
        }
        public bool FilterItem(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Item))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
                            (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_Item.ToLower()))
                        );
                }
                return true;
            }
            return false;
        }

        #region Filters For Machine
        private string _filterStringMachine;
        public string FilterStringMachine
        {
            get { return _filterStringMachine; }
            set
            {
                _filterStringMachine = value;
                RaisePropertyChanged("FilterStringMachine");
                FilterCollectionMachine();
            }
        }
        private void FilterCollectionMachine()
        {
            if (_MachineCollection != null)
            {
                _MachineCollection.Refresh();
            }
        }
        public bool MachineFilter(object obj)
        {
            var data = obj as ZADM_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMachine))
                {
                    return ((data.machinecode != null) && data.machinecode.ToLower().Contains(_filterStringMachine.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Company Filter
        private string _filterString_Company;
        public string FilterString_Company
        {
            get { return _filterString_Company; }
            set
            {
                _filterString_Company = value;
                RaisePropertyChanged("FilterString_Company");
                FilterCollectionCompany();
            }
        }
        private void FilterCollectionCompany()
        {
            if (_CompanyCollection != null)
            {
                _CompanyCollection.Refresh();
            }
        }
        public bool FilterCompany(object obj)
        {
            var data = obj as ADM_M002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Company))
                {
                    return (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterString_Company.ToLower()) ||
                            (data.CompName != null && data.CompName.ToString().ToLower().Contains(_filterString_Company.ToLower()))
                        );
                }
                return true;
            }
            return false;
        }
        #endregion

        private string _filterString_plant;
        public string FilterString_plant
        {
            get { return _filterString_plant; }
            set
            {
                _filterString_plant = value;
                RaisePropertyChanged("FilterString_Item");
                filterPlantCollection();
            }
        }
        private void filterPlantCollection()
        {
            if (_PlantCollection != null)
            {
                _PlantCollection.Refresh();
            }
        }
        public bool FilterPlant(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_plant))
                {
                    return (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_plant.ToLower()) ||
                        data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_plant.ToLower()));
                }
                return true;
            }
            return false;
        }


        private string _filterStringUom;
        public string FilterStringUom
        {
            get { return _filterStringUom; }
            set
            {
                _filterStringUom = value;
                RaisePropertyChanged("FilterStringUom");
                FilterCollectionUom();
            }
        }
        private void FilterCollectionUom()
        {
            if (_uomCollection != null)
            {
                _uomCollection.Refresh();
            }
        }
        public bool FilterUom(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringUom))
                {
                    return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringUom.ToLower()));
                }
                return true;
            }
            return false;
        }
     

        #endregion

        #region . Command Action .
        protected override void OnSaveAction(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {

        }
        protected override void OnCreateAction(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {

        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_Pro_PeriodicEntity> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }



}
