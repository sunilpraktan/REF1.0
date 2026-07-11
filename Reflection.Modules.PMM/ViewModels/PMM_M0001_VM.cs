using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Services;
using System.Windows.Data;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using System.ComponentModel;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.PMM;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.FICO;
using GalaSoft.MvvmLight.Messaging;
using Reflection.ReportingServices;
using System.Net.Mail;
using System.Data;

namespace Reflection.Modules.PMM.ViewModels
{
    public class PMM_M0001_VM : WorkspaceViewModel<PMM_M0001>
    {
        WebServiceRepository<PMM_M0001> REPOSITORY = new WebServiceRepository<PMM_M0001>();
        WebServiceRepository<MC_PMM_BE> REPOSITORY_MC = new WebServiceRepository<MC_PMM_BE>();
        ObjectSerializationService SER_OBJ = new ObjectSerializationService();

        #region AutoSuggest Initialization

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _AS_COMPANY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_COMPANY
        {
            get { return _AS_COMPANY; }
            set
            {
                if (_AS_COMPANY != value)
                {
                    _AS_COMPANY = value; RaisePropertyChanged("AS_COMPANY");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_LOCATION { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_LOCATION
        {
            get { return _AS_LOCATION; }
            set
            {
                if (_AS_LOCATION != value)
                {
                    _AS_LOCATION = value; RaisePropertyChanged("AS_LOCATION");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_STATUS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_STATUS
        {
            get { return _AS_STATUS; }
            set
            {
                if (_AS_STATUS != value)
                {
                    _AS_STATUS = value; RaisePropertyChanged("AS_STATUS");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_CURRENCY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CURRENCY
        {
            get { return _AS_CURRENCY; }
            set
            {
                if (_AS_CURRENCY != value)
                {
                    _AS_CURRENCY = value; RaisePropertyChanged("AS_CURRENCY");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_CATEGORY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CATEGORY
        {
            get { return _AS_CATEGORY; }
            set
            {
                if (_AS_CATEGORY != value)
                {
                    _AS_CATEGORY = value; RaisePropertyChanged("AS_CATEGORY");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_ITEMS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ITEMS
        {
            get { return _AS_ITEMS; }
            set
            {
                if (_AS_ITEMS != value)
                {
                    _AS_ITEMS = value; RaisePropertyChanged("AS_ITEMS");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_OBJ_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_OBJ_TYPE
        {
            get { return _AS_OBJ_TYPE; }
            set
            {
                if (_AS_OBJ_TYPE != value)
                {
                    _AS_OBJ_TYPE = value; RaisePropertyChanged("AS_OBJ_TYPE");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_COUNTRY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_COUNTRY
        {
            get { return _AS_COUNTRY; }
            set
            {
                if (_AS_COUNTRY != value)
                {
                    _AS_COUNTRY = value; RaisePropertyChanged("AS_COUNTRY");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_EMPLOYEE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_EMPLOYEE
        {
            get { return _AS_EMPLOYEE; }
            set
            {
                if (_AS_EMPLOYEE != value)
                {
                    _AS_EMPLOYEE = value; RaisePropertyChanged("AS_EMPLOYEE");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_UOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM
        {
            get { return _AS_UOM; }
            set
            {
                if (_AS_UOM != value)
                {
                    _AS_UOM = value; RaisePropertyChanged("AS_UOM");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_UOM_CON { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM_CON
        {
            get { return _AS_UOM_CON; }
            set
            {
                if (_AS_UOM_CON != value)
                {
                    _AS_UOM_CON = value; RaisePropertyChanged("AS_UOM_CON");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_UOM_WT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM_WT
        {
            get { return _AS_UOM_WT; }
            set
            {
                if (_AS_UOM_WT != value)
                {
                    _AS_UOM_WT = value; RaisePropertyChanged("AS_UOM_WT");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_UOM_DIM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM_DIM
        {
            get { return _AS_UOM_DIM; }
            set
            {
                if (_AS_UOM_DIM != value)
                {
                    _AS_UOM_DIM = value; RaisePropertyChanged("AS_UOM_DIM");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_UOM_WTLOAD { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM_WTLOAD
        {
            get { return _AS_UOM_WTLOAD; }
            set
            {
                if (_AS_UOM_WTLOAD != value)
                {
                    _AS_UOM_WTLOAD = value; RaisePropertyChanged("AS_UOM_WTLOAD");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_UOM_VOLUME { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM_VOLUME
        {
            get { return _AS_UOM_VOLUME; }
            set
            {
                if (_AS_UOM_VOLUME != value)
                {
                    _AS_UOM_VOLUME = value; RaisePropertyChanged("AS_UOM_VOLUME");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_UOM_LENGTH { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM_LENGTH
        {
            get { return _AS_UOM_LENGTH; }
            set
            {
                if (_AS_UOM_LENGTH != value)
                {
                    _AS_UOM_LENGTH = value; RaisePropertyChanged("AS_UOM_LENGTH");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_UOM_EP { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM_EP
        {
            get { return _AS_UOM_EP; }
            set
            {
                if (_AS_UOM_EP != value)
                {
                    _AS_UOM_EP = value; RaisePropertyChanged("AS_UOM_EP");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_UOM_CP { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM_CP
        {
            get { return _AS_UOM_CP; }
            set
            {
                if (_AS_UOM_CP != value)
                {
                    _AS_UOM_CP = value; RaisePropertyChanged("AS_UOM_CP");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_UOM_MAX_SPEED { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM_MAX_SPEED
        {
            get { return _AS_UOM_MAX_SPEED; }
            set
            {
                if (_AS_UOM_MAX_SPEED != value)
                {
                    _AS_UOM_MAX_SPEED = value; RaisePropertyChanged("AS_UOM_MAX_SPEED");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_ENGINE_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ENGINE_TYPE
        {
            get { return _AS_ENGINE_TYPE; }
            set
            {
                if (_AS_ENGINE_TYPE != value)
                {
                    _AS_ENGINE_TYPE = value; RaisePropertyChanged("AS_ENGINE_TYPE");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_FUEL1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_FUEL1
        {
            get { return _AS_FUEL1; }
            set
            {
                if (_AS_FUEL1 != value)
                {
                    _AS_FUEL1 = value; RaisePropertyChanged("AS_FUEL1");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_FUEL2 { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_FUEL2
        {
            get { return _AS_FUEL2; }
            set
            {
                if (_AS_FUEL2 != value)
                {
                    _AS_FUEL2 = value; RaisePropertyChanged("AS_FUEL2");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_OIL_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_OIL_TYPE
        {
            get { return _AS_OIL_TYPE; }
            set
            {
                if (_AS_OIL_TYPE != value)
                {
                    _AS_OIL_TYPE = value; RaisePropertyChanged("AS_OIL_TYPE");
                }
            }
        }

        #endregion

        #region Declarations    
        private bool _isNewRecord { get; set; }
        public bool isNewRecord
        {
            get { return _isNewRecord; }
            set
            {
                if (_isNewRecord != value)
                {
                    _isNewRecord = value; RaisePropertyChanged("isNewRecord");
                }
            }
        }
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }
        private bool _isFleet { get; set; }
        public bool isFleet
        {
            get { return _isFleet; }
            set
            {
                if (_isFleet != value)
                {
                    _isFleet = value; RaisePropertyChanged("isFleet");
                }
            }
        }
        IShowMessageViewService sms;

        private MC_PMM_BE _MC;
        public MC_PMM_BE MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MC_PMM_BE _MC_TEMP;
        public MC_PMM_BE MC_TEMP
        {
            get { return _MC_TEMP; }
            set { _MC_TEMP = value; RaisePropertyChanged("MC_TEMP"); }
        }

        private PMM_M0001 _MasterEntity;
        public PMM_M0001 MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private PMM_M0021 _FleetEntity;
        public PMM_M0021 FleetEntity
        {
            get
            { return _FleetEntity; }
            set
            {
                _FleetEntity = value;
                RaisePropertyChanged("FleetEntity");
            }
        }

        private STD_REQ_PARA_BE _REQ_PARA_OBJ;
        public STD_REQ_PARA_BE REQ_PARA_OBJ
        {
            get
            {
                return _REQ_PARA_OBJ;
            }
            set
            {
                if (_REQ_PARA_OBJ != value)
                {
                    _REQ_PARA_OBJ = value;
                    RaisePropertyChanged(nameof(REQ_PARA_OBJ));
                }
            }
        }

        private int _MainTabIndex;
        public int MainTabIndex
        {
            get { return _MainTabIndex; }
            set
            {
                if (_MainTabIndex != value)
                {
                    _MainTabIndex = value;
                    RaisePropertyChanged("MainTabIndex");
                }
            }
        }

        #endregion

        #region ICollectionView
        private IEnumerable _UNIT_LIST;
        public IEnumerable UNIT_LIST
        {
            get { return _UNIT_LIST; }
            set
            {
                _UNIT_LIST = value;

                RaisePropertyChanged("UNIT_LIST");
            }
        }

        private IEnumerable _PARTY_LIST;
        public IEnumerable PARTY_LIST
        {
            get { return _PARTY_LIST; }
            set
            {
                _PARTY_LIST = value;

                RaisePropertyChanged("PARTY_LIST");
            }
        }
        private IEnumerable _GROUP_LIST;
        public IEnumerable GROUP_LIST
        {
            get { return _GROUP_LIST; }
            set
            {
                _GROUP_LIST = value;

                RaisePropertyChanged("GROUP_LIST");
            }
        }

        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }

        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        //public RelayCommand<object> cmdInsertCompany { get; private set; }
        //public RelayCommand<object> cmdInsertLocation { get; private set; }
        public RelayCommand<object> cmdInsertStatus { get; private set; }
        public RelayCommand<object> cmdInsertCategory { get; private set; }
        public RelayCommand<object> cmdInsertObjectType { get; private set; }
        public RelayCommand<STD_LIST_BE> cmdLoadDocument { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        public RelayCommand<object> cmdInsertEmployee { get; private set; }
        public RelayCommand<object> cmdSelectAll { get; private set; }

        #endregion

        #region Event Handler

        #endregion

        #region Constructor
        public PMM_M0001_VM(string ts_code,string doc_cat) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            MasterEntity = new PMM_M0001();
            FleetEntity = new PMM_M0021();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            MC = new MC_PMM_BE();
            MC_TEMP = new MC_PMM_BE();
            //PMM_M0001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            sms = this.GetViewService<IShowMessageViewService>();

            CommandInitialization();
            
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData(string company, string location)
        {
            try
            {
                isNewRecord = true;
                //string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + (REQ_PARA_OBJ.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (REQ_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + (REQ_PARA_OBJ.doc_no ?? "") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + REQ_PARA_OBJ.org_code + "!@" + (REQ_PARA_OBJ.group_code ?? "");
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + company + "!@" + location + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + (MasterEntity.equip_no ?? "") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm ;
                MC = REPOSITORY_MC.GetDataWithReturnDomainObject<MC_PMM_BE>(MC, Request, "PMM_M0001_BL", "PMM", "LoadAll", 0, "");

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M0002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0002)o).comp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", true);
                AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(MC.LOCATION_LIST, TheFilter, SuggestedValue, "location_id", true);
                AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = false; AS_LOCATION.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_STATUS = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_status", true);
                AS_STATUS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_STATUS.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((FICO_M0033)x).curr_code);
                TheFilter = (o, prefix) => (((FICO_M0033)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((FICO_M0033)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_CURRENCY = new AutoSuggestTextViewModel<dynamic>(MC.CURR_LIST, TheFilter, SuggestedValue, "curr_code", true);
                AS_CURRENCY.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).cat_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).cat_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).cat_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_CATEGORY = new AutoSuggestTextViewModel<dynamic>(MC.CATEGORY_LIST, TheFilter, SuggestedValue, "cat_code", true);
                AS_CATEGORY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_CATEGORY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code);
                TheFilter = (o, prefix) => (((STD_ITEM)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).equip_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).equip_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ITEMS = new AutoSuggestTextViewModel<dynamic>(MC.ITEM_LIST, TheFilter, SuggestedValue, "item_code", true);
                AS_ITEMS.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ITEMS.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).obj_type);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).obj_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).obj_type_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_OBJ_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.OBJECT_TYPE_LIST, TheFilter, SuggestedValue, "obj_type", true);
                AS_OBJ_TYPE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_OBJ_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).ctry_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).ctry_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).ctry_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COUNTRY = new AutoSuggestTextViewModel<dynamic>(MC.COUNTRY_LIST, TheFilter, SuggestedValue, "ctry_code", true);
                AS_COUNTRY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_OBJ_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id);
                TheFilter = (o, prefix) => (((STD_PERSONNEL)o).emp_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PERSONNEL)o).emp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_EMPLOYEE = new AutoSuggestTextViewModel<dynamic>(MC.PERSONNEL_LIST, TheFilter, SuggestedValue, "emp_id", true);
                AS_EMPLOYEE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_EMPLOYEE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM_CON = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST.Where(x => x.unit_code != null).ToList(), TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM_CON.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM_CON.AutoSuggestVM.IsFreeTextAllowed = false;

                List<UOMS> UOM_OBJ_WT = MC.UOM_LIST.Where(item => item.unit_code != null).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM_WT = new AutoSuggestTextViewModel<dynamic>(UOM_OBJ_WT, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM_WT.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM_WT.AutoSuggestVM.IsFreeTextAllowed = false;

                List<UOMS> UOM_OBJ_DIM = MC.UOM_LIST.Where(item => item.unit_code != null).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM_DIM = new AutoSuggestTextViewModel<dynamic>(UOM_OBJ_DIM, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM_DIM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM_DIM.AutoSuggestVM.IsFreeTextAllowed = false;

                List<UOMS> UOM_OBJ_WTLOAD = MC.UOM_LIST.Where(item => item.unit_code != null).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM_WTLOAD = new AutoSuggestTextViewModel<dynamic>(UOM_OBJ_WTLOAD, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM_WTLOAD.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM_WTLOAD.AutoSuggestVM.IsFreeTextAllowed = false;

                List<UOMS> UOM_OBJ_VOLUME = MC.UOM_LIST.Where(item => item.unit_code != null).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM_VOLUME = new AutoSuggestTextViewModel<dynamic>(UOM_OBJ_VOLUME, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM_VOLUME.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM_VOLUME.AutoSuggestVM.IsFreeTextAllowed = false;

                List<UOMS> UOM_OBJ_LENGTH = MC.UOM_LIST.Where(item => item.unit_code != null).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM_LENGTH = new AutoSuggestTextViewModel<dynamic>(UOM_OBJ_LENGTH, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM_LENGTH.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM_LENGTH.AutoSuggestVM.IsFreeTextAllowed = false;

                List<UOMS> UOM_OBJ_EP = MC.UOM_LIST.Where(item => item.unit_code != null).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM_EP = new AutoSuggestTextViewModel<dynamic>(UOM_OBJ_EP, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM_EP.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM_EP.AutoSuggestVM.IsFreeTextAllowed = false;

                List<UOMS> UOM_OBJ_CP = MC.UOM_LIST.Where(item => item.unit_code != null).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM_CP = new AutoSuggestTextViewModel<dynamic>(UOM_OBJ_CP, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM_CP.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM_CP.AutoSuggestVM.IsFreeTextAllowed = false;

                List<UOMS> UOM_OBJ_MAX = MC.UOM_LIST.Where(item => item.unit_code != null).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM_MAX_SPEED = new AutoSuggestTextViewModel<dynamic>(UOM_OBJ_MAX, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM_MAX_SPEED.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM_MAX_SPEED.AutoSuggestVM.IsFreeTextAllowed = false;

                List<Classification> UOM_OBJ_ENG = MC.CHAR_VALUE_LIST.Where(item => item.char_code == "ENGTP").ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((Classification)x).char_value);
                TheFilter = (o, prefix) => (((Classification)o).char_value ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((Classification)o).char_value ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ENGINE_TYPE = new AutoSuggestTextViewModel<dynamic>(UOM_OBJ_ENG, TheFilter, SuggestedValue, "char_value", true);
                AS_ENGINE_TYPE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ENGINE_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                List<Classification> UOM_OBJ_OIL = MC.CHAR_VALUE_LIST.Where(item => item.char_code == "IOLT").ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((Classification)x).char_value);
                TheFilter = (o, prefix) => (((Classification)o).char_value ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((Classification)o).char_value ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_OIL_TYPE = new AutoSuggestTextViewModel<dynamic>(UOM_OBJ_OIL, TheFilter, SuggestedValue, "char_value", true);
                AS_OIL_TYPE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_OIL_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                List<Classification> UOM_OBJ_FUEL1 = MC.CHAR_VALUE_LIST.Where(item => item.char_code == "FUL").ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((Classification)x).char_value);
                TheFilter = (o, prefix) => (((Classification)o).char_value ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((Classification)o).char_value ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_FUEL1 = new AutoSuggestTextViewModel<dynamic>(UOM_OBJ_FUEL1, TheFilter, SuggestedValue, "char_value", true);
                AS_FUEL1.AutoSuggestVM.IsEmptyValueAllowed = true; AS_FUEL1.AutoSuggestVM.IsFreeTextAllowed = false;

                List<Classification> UOM_OBJ_FUEL2 = MC.CHAR_VALUE_LIST.Where(item => item.char_code == "FUL").ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((Classification)x).char_value);
                TheFilter = (o, prefix) => (((Classification)o).char_value ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((Classification)o).char_value ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_FUEL2 = new AutoSuggestTextViewModel<dynamic>(UOM_OBJ_FUEL2, TheFilter, SuggestedValue, "char_value", true);
                AS_FUEL2.AutoSuggestVM.IsEmptyValueAllowed = true; AS_FUEL2.AutoSuggestVM.IsFreeTextAllowed = false;

                UNIT_LIST = MC.UOM_LIST;
                PARTY_LIST = MC.PARTY_LIST;
                GROUP_LIST = MC.GROUP_LIST;

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        private void DefaultValues()
        {
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.location_id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.active = "1";
            MasterEntity.valid_from = DateTime.Now;
            MasterEntity.valid_to = DateTime.Now.AddYears(10);
            MasterEntity.create_date = DateTime.Now;
            if(MC.STATUS_LIST != null)
            {
                if (MC.STATUS_LIST.Count > 0)
                {
                    MasterEntity.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
                    MasterEntity.t_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_display).FirstOrDefault();
                }
            }
            

            FleetEntity.client = AppSessionState.client;
            FleetEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            FleetEntity.active = "1";
            FleetEntity.valid_from = DateTime.Now;
            FleetEntity.valid_to = DateTime.Now.AddYears(10);

        }
        private void Logging()
        {
            MasterEntity.ts_code = this.ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;

            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private void CommandInitialization()
        {
            CursorControl.SetBusyState();
            try
            {
                #region Command Initialisation
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                //cmdInsertCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
                //cmdInsertLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertLocation(items); });
                cmdInsertStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertStatus(items); });
                cmdInsertCategory = new RelayCommand<object>(items => { if (items == null) { return; } InsertCategory(items); });
                cmdInsertObjectType = new RelayCommand<object>(items => { if (items == null) { return; } InsertObjectType(items); });
                cmdLoadDocument = new RelayCommand<STD_LIST_BE>(items => { if (items == null) { return; } LoadDocument(items); });
                cmdLoadBackFlip = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items); });
                cmdInsertEmployee = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmployee(items); });
                cmdSelectAll = new RelayCommand<object>(items => { if (items == null) { return; } SelectAll(items); });
                #endregion
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                DateTime d = DateTime.UtcNow;
                d = d.AddMonths(-1);
                REQ_PARA_OBJ.from_date = d;
                REQ_PARA_OBJ.to_date = DateTime.UtcNow;
                REQ_PARA_OBJ.active = true;
                REQ_PARA_OBJ.comp_code = AppSessionState.OBJ_COMPANY.comp_code;

                MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                MasterEntity.location_id = AppSessionState.OBJ_LOCATION.location_id;
                LoadInitialData(MasterEntity.comp_code, MasterEntity.location_id);
                DefaultValues();
                //if (!string.IsNullOrWhiteSpace(InputValue.element_id) && ts_code_vm != null)
                //{
                //    //LoadDocumentByDocumentNumber(InputValue);
                //}
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
                    Request = MasterEntity.client + "!@" + MasterEntity.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        //private void InsertCompany(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ADM_M0002 POPUPEntityObject = null;
        //        #region Command Parameter Read Section
        //        try
        //        {
        //            if (InputValue.GetType() == typeof(string) && InputValue != null)
        //            {
        //                Request = InputValue.ToString();
        //                if (Request.Length > 0)
        //                {
        //                    try
        //                    { POPUPEntityObject = MC.COMPANY_LIST.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                    catch (Exception ex) { }
        //                }
        //            }
        //            else if (InputValue != null)
        //            {
        //                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0002>().ToList()[0];
        //            }
        //        }
        //        catch (Exception ex) { }

        //        #endregion
        //        if (POPUPEntityObject != null)
        //        {
        //            //if (MasterEntity.comp_code != POPUPEntityObject.comp_code)
        //            //{
        //            //    MasterEntity.comp_code = POPUPEntityObject.comp_code;
        //            //    LoadInitialData();
        //            //}

        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;
        //            LoadInitialData(MasterEntity.comp_code, MasterEntity.location_id);
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
        //    }
        //}
        //private void InsertLocation(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ADM_M0003 POPUPEntityObject = null;
        //        #region Command Parameter Read Section
        //        try
        //        {
        //            if (InputValue.GetType() == typeof(string) && InputValue != null)
        //            {
        //                Request = InputValue.ToString();
        //                if (Request.Length > 0)
        //                {
        //                    try
        //                    { POPUPEntityObject = MC.LOCATION_LIST.Where(x => x.location_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                    catch (Exception ex) { }
        //                }
        //            }
        //            else if (InputValue != null)
        //            {
        //                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0003>().ToList()[0];
        //            }
        //        }
        //        catch (Exception ex) { }

        //        #endregion
        //        if (POPUPEntityObject != null)
        //        {
        //            MasterEntity.location_id = POPUPEntityObject.location_id;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
        //    }
        //}
        private void InsertStatus(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0013 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.STATUS_LIST.Where(x => x.t_status.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_display.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0013>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.t_status = POPUPEntityObject.t_status;
                    MasterEntity.t_display = POPUPEntityObject.t_display;
                }

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertCategory(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.CATEGORY_LIST.Where(x => x.cat_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.cat_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.equip_cat = POPUPEntityObject.cat_code;
                    MasterEntity.cat_name = POPUPEntityObject.cat_name;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void InsertObjectType(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.OBJECT_TYPE_LIST.Where(x => x.obj_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.obj_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.obj_type = POPUPEntityObject.obj_type;
                    MasterEntity.object_name = POPUPEntityObject.obj_name;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void SelectAll(object InputValue) // can be remove this function, we hahe include this code in Function of OK Button below the popup window.
        {
            try
            {
                STD_LIST_BE POPUPEntityObject = null;
                if (InputValue != null && ((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    foreach (var item in MC_TEMP.BACK_FLIP_LIST)
                    {
                        if (item.doc_no == POPUPEntityObject.doc_no)
                        {
                            item.selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void InsertEmployee(object InputValue)
        {
            try
            {
                string Request = "";
                STD_PERSONNEL POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PERSONNEL_LIST.Where(x => x.emp_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.emp_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PERSONNEL>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.emp_id = POPUPEntityObject.emp_id;
                    MasterEntity.emp_name = POPUPEntityObject.emp_name;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void LoadDocument(STD_LIST_BE ParameterObject)
        {
            try
            {
                CursorControl.SetBusyState();

                if (MasterEntity.comp_code != ParameterObject.comp_code) // call when document loading of different company
                {
                    LoadInitialData(ParameterObject.comp_code, ParameterObject.location_id);
                }

                string Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + ParameterObject.comp_code + "!@" + ParameterObject.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + ParameterObject.equip_no + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm;
                MC_TEMP = REPOSITORY_MC.GetDataWithReturnDomainObject<MC_PMS_BE>(MC_TEMP, Request, "PMM_M0001_BL", "PMM", "LoadAll", 0, "");
                if (MC_TEMP.EQUIPMENT_MASTER_LIST != null)
                {
                    if (MC_TEMP.EQUIPMENT_MASTER_LIST.Count > 0)
                    {
                        MasterEntity = MC_TEMP.EQUIPMENT_MASTER_LIST[0];
                        MainTabIndex = 0;
                    }
                    if (MC_TEMP.FLEET_LIST != null)
                    {
                        if (MC_TEMP.FLEET_LIST.Count > 0)
                        {
                            FleetEntity = MC_TEMP.FLEET_LIST[0];
                        }
                        else
                        {
                            FleetEntity = new PMM_M0021();
                        }
                    }
                    
                    //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void LoadBackFlipData(object ParameterObject)
        {
            try
            {
                CursorControl.SetBusyState();

                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + (REQ_PARA_OBJ.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (REQ_PARA_OBJ.location_id ?? "") + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + (REQ_PARA_OBJ.doc_no ?? "") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm;
                MC_TEMP = REPOSITORY_MC.GetDataWithReturnDomainObject<MC_PMS_BE>(MC_TEMP, Request, "PMM_M0001_BL", "PMM", "LoadAll", 0, "");
                if (MC_TEMP.BACK_FLIP_LIST != null)
                {
                    if (MC_TEMP.BACK_FLIP_LIST.Count > 0)
                    {
                        BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC_TEMP.BACK_FLIP_LIST);
                        BACKFLIP_COLLECTION.Filter = new Predicate<object>(FLTR_BACKFLIP);
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private bool Validation()
        {
            if (MasterEntity.equip_name == null || MasterEntity.equip_name == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter the Equipment Name");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.equip_cat == "S" && string.IsNullOrWhiteSpace(MasterEntity.party_code)) // && string.IsNullOrWhiteSpace(MasterEntity.customer_code)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter the Customer code for servicable Material");
                showMessageService.ShowMessage();
                return false;
            }
            //if (string.IsNullOrWhiteSpace(MasterEntity.item_code)) //NOTE: comment because item code get generated in INS SP if not supplied.
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Enter the Material Code for Equipment");
            //    showMessageService.ShowMessage();
            //    return false;
            //}

            return true;
        }


        #endregion

        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<PMM_M0001> result)
        {
            try
            {
                CursorControl.SetBusyState();
                if (Validation() == true)
                {
                    //if (string.IsNullOrWhiteSpace(MasterEntity.equip_no))
                    //{
                    //    isNewRecord = true;
                    //}
                    //else
                    //{
                    //    isNewRecord = false;
                    //}
                    Logging();
                    MasterEntity.XDOC_A = SER_OBJ.ObjectToXML(FleetEntity);

                    if (isNewRecord == true)
                    {
                        MasterEntity = REPOSITORY.SaveWithReturnDomainObject<PMM_M0001>(MasterEntity, "PMM_M0001_BL", "PMM");
                        if (!string.IsNullOrWhiteSpace(MasterEntity.XDOC_A))
                        {
                            MC.FLEET_LIST = (List<PMM_M0021>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_A, MC.FLEET_LIST);
                            MC_TEMP.FLEET_LIST = MC.FLEET_LIST;
                            if (MC.FLEET_LIST.Where(x => x.active == "1").ToList().Count > 0)
                            {
                                FleetEntity = MC.FLEET_LIST.Where(x => x.active == "1").ToList()[0];
                            }
                            else
                            {
                                FleetEntity = new PMM_M0021();
                            }
                        }
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = REPOSITORY.UpdateWithReturnDomainObject<PMM_M0001>(MasterEntity, "PMM_M0001_BL", "PMM");
                        if (!string.IsNullOrWhiteSpace(MasterEntity.XDOC_A))
                        {
                            MC.FLEET_LIST = (List<PMM_M0021>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_A, MC.FLEET_LIST);
                            MC_TEMP.FLEET_LIST = MC.FLEET_LIST;
                            if (MC.FLEET_LIST.Where(x => x.active == "1").ToList().Count > 0)
                            {
                                FleetEntity = MC.FLEET_LIST.Where(x => x.active == "1").ToList()[0];
                            }
                            else
                            {
                                FleetEntity = new PMM_M0021();
                            }
                        }
                    }
                    isNewRecord = false;
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = "Record save successfully!"; sms.ShowMessage();
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }

        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
           
        }
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.equip_no))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.equip_no.Replace("/", "--"), DocumentList = MC_TEMP.ATTACHMENT_LIST, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<PMM_M0001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PMM_M0001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PMM_M0001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PMM_M0001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PMM_M0001> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<PMM_M0001> result)
        {
            CursorControl.SetBusyState();
            isNewRecord = true;
            if (MasterEntity.comp_code != AppSessionState.OBJ_COMPANY.comp_code) // call when document loading of different company. call before Master Entity instance is being created.
            {
                LoadInitialData(AppSessionState.OBJ_COMPANY.comp_code, AppSessionState.OBJ_LOCATION.location_id);
            }
            MasterEntity = new PMM_M0001();
            FleetEntity = new PMM_M0021();
            MasterEntity.ValidateAsync().Wait();
            
            DefaultValues();
            //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
        }
        protected override void OnRemoveAction(InquiryActionResult<PMM_M0001> result)
        {
           
        }
        protected override void OnDiscardAction(InquiryActionResult<PMM_M0001> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<PMM_M0001> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<PMM_M0001> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<PMM_M0001> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<PMM_M0001> result)
        {
            try
            {
                CursorControl.SetBusyState();
                string report_name = "LabelQRBAR01.rdlc";
                QRCodeService QRGenerator = new QRCodeService();
                ReportManager ReportManager = new ReportManager();
                object[] objDataSource = new object[1];
                string[] objDataSourceName = new string[1];

                List<STD_LIST_BE> rptListObj = new List<STD_LIST_BE>();

                foreach (STD_LIST_BE item in MC_TEMP.BACK_FLIP_LIST)
                {
                    if (item.selected == true)
                    {
                        item.qr_image = QRGenerator.RenderQrCodeForLabel(item.equip_no, 15, "");
                        rptListObj.Add(item);
                    }
                }
                objDataSource[0] = rptListObj;
                objDataSourceName[0] = "dsLabel";
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORTS_STD\\MIS\\LabelQRBAR01.rdlc", "Label");

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

        #endregion

        #region Filters
        private string _FLTR_STR_BACKFLIP;
        public string FLTR_STR_BACKFLIP
        {
            get { return _FLTR_STR_BACKFLIP; }
            set
            {
                _FLTR_STR_BACKFLIP = value;
                RaisePropertyChanged("FLTR_STR_BACKFLIP");
                FLTR_COLL_BACKFLIP();
            }
        }
        private void FLTR_COLL_BACKFLIP()
        {
            if (BACKFLIP_COLLECTION != null)
            {
                BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool FLTR_BACKFLIP(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FLTR_STR_BACKFLIP))
                {
                    return (data.doc_no != null && data.doc_no.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.doc_date != null && data.doc_date.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.equip_no != null && data.equip_no.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.serial_no != null && data.serial_no.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           //data.obj_code != null && data.obj_code.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.obj_no != null && data.obj_no.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.equip_name != null && data.equip_name.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.cat_name != null && data.cat_name.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.party_code != null && data.party_code.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.party_name != null && data.party_name.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.item_code != null && data.item_code.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.item_name != null && data.item_name.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.doc_cat != null && data.ref_doc_cat.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.comp_code != null && data.comp_code.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.emp_name != null && data.emp_name.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower())
                       );
                }
                return true;
            }
            return false;
        }

        #endregion
    }
}
