using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.PMM;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Windows.Controls;

namespace Reflection.Modules.PMM.ViewModels
{
    public class PMM_T001_VM : WorkspaceViewModel<PMM_T001>
    {
        #region Private Local Variable Declaration
        private bool isNewRecord = true;
        private bool _EntityChangeEnable;
        private bool EntityChangeEnable
        {
            get { return _EntityChangeEnable; }
            set
            {
                if (_EntityChangeEnable != value)
                {
                    _EntityChangeEnable = value; RaisePropertyChanged("EntityChangeEnable");
                }
            }
        }

        private string ts_code_vm { get; set; }
        private string doc_no_vm { get; set; }
        private string doc_cat_vm { get; set; }

        WebServiceRepository<PMM_T001> REPO = new WebServiceRepository<PMM_T001>();
        WebServiceRepository<MC_PMM_T001_BE> REPO_MC = new WebServiceRepository<MC_PMM_T001_BE>();
        IShowMessageViewService sms;
        ObjectSerializationService SER_OBJ = new ObjectSerializationService();

        private MC_PMM_T001_BE _MC = new MC_PMM_T001_BE();
        public MC_PMM_T001_BE MC
        {
            get { return _MC; }
            set { if (_MC != value) { _MC = value; RaisePropertyChanged("MC"); } }
        }
        private MC_PMM_T001_BE _MC_TEMP = new MC_PMM_T001_BE();
        public MC_PMM_T001_BE MC_TEMP
        {
            get { return _MC_TEMP; }
            set { if (_MC_TEMP != value) { _MC_TEMP = value; RaisePropertyChanged("MC_TEMP"); } }
        }

        private PMM_T001 _MasterEntity;
        public PMM_T001 MasterEntity
        {
            get { return _MasterEntity; }
            set { if (_MasterEntity != value) { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); } }
        }

        private ObservableCollection<PMM_T001_A> _ItemEntity;
        public ObservableCollection<PMM_T001_A> ItemEntity
        {
            get { return _ItemEntity; }
            set
            {
                if (_ItemEntity != value)
                {
                    _ItemEntity = value;
                    //ItemEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyItemEntity);
                    RaisePropertyChanged("ItemEntity");
                }
            }
        }
        private PMM_T001_A _PMM_T001_A_OBJ;
        public PMM_T001_A PMM_T001_A_OBJ
        {
            get { return _PMM_T001_A_OBJ; }
            set { if (_PMM_T001_A_OBJ != value) { _PMM_T001_A_OBJ = value; RaisePropertyChanged("PMM_T001_A_OBJ"); } }
        }
        private ObservableCollection<PMM_T001_B> _CycleEntity;
        public ObservableCollection<PMM_T001_B> CycleEntity
        {
            get { return _CycleEntity; }
            set { if (_CycleEntity != value)
                    {
                        _CycleEntity = value;
                        CycleEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyCycleEntity);
                        RaisePropertyChanged("CycleEntity");
                    }
                }
        }
        private PMM_T001_B _PMM_T001_B_OBJ;
        public PMM_T001_B PMM_T001_B_OBJ
        {
            get { return _PMM_T001_B_OBJ; }
            set { if (_PMM_T001_B_OBJ != value) { _PMM_T001_B_OBJ = value; RaisePropertyChanged("PMM_T001_B_OBJ"); } }
        }
        private ObservableCollection<PMM_T002> _ScheduleEntity;
        public ObservableCollection<PMM_T002> ScheduleEntity
        {
            get { return _ScheduleEntity; }
            set {
                    if (_ScheduleEntity != value)
                    {
                        _ScheduleEntity = value;
                        ScheduleEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyScheduleEntityEntity);
                        RaisePropertyChanged("ScheduleEntity");
                    }
                }
        }
        private PMM_T002 _PMM_T002_OBJ;
        public PMM_T002 PMM_T002_OBJ
        {
            get { return _PMM_T002_OBJ; }
            set { if (_PMM_T002_OBJ != value) { _PMM_T002_OBJ = value; RaisePropertyChanged("PMM_T002_OBJ"); } }
        }

        private ObservableCollection<PMM_T003> _CallObjectEntity;
        public ObservableCollection<PMM_T003> CallObjectEntity
        {
            get { return _CallObjectEntity; }
            set
            {
                if (_CallObjectEntity != value)
                {
                    _CallObjectEntity = value;
                    RaisePropertyChanged("CallObjectEntity");
                }
            }
        }
        private PMM_T003 _PMM_T003_OBJ;
        public PMM_T003 PMM_T003_OBJ
        {
            get { return _PMM_T003_OBJ; }
            set { if (_PMM_T003_OBJ != value) { _PMM_T003_OBJ = value; RaisePropertyChanged("PMM_T003_OBJ"); } }
        }
        private bool _isTabChangeAllowed = true;
        public bool isTabChangeAllowed
        {
            get { return _isTabChangeAllowed; }
            set
            {
                if (_isTabChangeAllowed != value)
                {
                    _isTabChangeAllowed = value; RaisePropertyChanged("isTabChangeAllowed");
                }
            }
        }

        private STD_REQ_PARA_BE _REQUEST_PARA;
        public STD_REQ_PARA_BE REQUEST_PARA
        {
            get { return _REQUEST_PARA; }
            set
            {
                if (_REQUEST_PARA != value)
                {
                    _REQUEST_PARA = value;

                    RaisePropertyChanged("REQUEST_PARA");
                }
            }
        }

        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }

        private int _selectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _selectedTabControlIndex; }
            set
            {
                if (_selectedTabControlIndex != value)
                {
                    _selectedTabControlIndex = value;
                    RaisePropertyChanged("SelectedTabControlIndex");
                }
            }
        }

        #endregion

        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PMM_T001_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _AS_DEFAULT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DEFAULT
        {
            get { return _AS_DEFAULT; }
            set
            {
                if (_AS_DEFAULT != value)
                {
                    _AS_DEFAULT = value; RaisePropertyChanged("AS_DEFAULT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_DEFAULT_1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DEFAULT_1
        {
            get { return _AS_DEFAULT_1; }
            set
            {
                if (_AS_DEFAULT_1 != value)
                {
                    _AS_DEFAULT_1 = value; RaisePropertyChanged("AS_DEFAULT_1");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_REF_DOC { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_REF_DOC
        {
            get { return _AS_REF_DOC; }
            set
            {
                if (_AS_REF_DOC != value)
                {
                    _AS_REF_DOC = value; RaisePropertyChanged("AS_REF_DOC");
                }
            }
        }
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
        private AutoSuggestTextViewModel<dynamic> _AS_FUN_LOCATION { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_FUN_LOCATION
        {
            get { return _AS_FUN_LOCATION; }
            set
            {
                if (_AS_FUN_LOCATION != value)
                {
                    _AS_FUN_LOCATION = value; RaisePropertyChanged("AS_FUN_LOCATION");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_OBJECT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_OBJECT
        {
            get { return _AS_OBJECT; }
            set
            {
                if (_AS_OBJECT != value)
                {
                    _AS_OBJECT = value; RaisePropertyChanged("AS_OBJECT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_WORK_CENTER { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_WORK_CENTER
        {
            get { return _AS_WORK_CENTER; }
            set
            {
                if (_AS_WORK_CENTER != value)
                {
                    _AS_WORK_CENTER = value; RaisePropertyChanged("AS_WORK_CENTER");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_PLANT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PLANT
        {
            get { return _AS_PLANT; }
            set
            {
                if (_AS_PLANT != value)
                {
                    _AS_PLANT = value; RaisePropertyChanged("AS_PLANT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_UNIT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UNIT
        {
            get { return _AS_UNIT; }
            set
            {
                if (_AS_UNIT != value)
                {
                    _AS_UNIT = value; RaisePropertyChanged("AS_UNIT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_UNIT_CYCLE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UNIT_CYCLE
        {
            get { return _AS_UNIT_CYCLE; }
            set
            {
                if (_AS_UNIT_CYCLE != value)
                {
                    _AS_UNIT_CYCLE = value; RaisePropertyChanged("AS_UNIT_CYCLE");
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
        private AutoSuggestTextViewModel<dynamic> _AS_ORDER_CAT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ORDER_CAT
        {
            get { return _AS_ORDER_CAT; }
            set
            {
                if (_AS_ORDER_CAT != value)
                {
                    _AS_ORDER_CAT = value; RaisePropertyChanged("AS_ORDER_CAT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_PLAN_CAT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PLAN_CAT
        {
            get { return _AS_PLAN_CAT; }
            set
            {
                if (_AS_PLAN_CAT != value)
                {
                    _AS_PLAN_CAT = value; RaisePropertyChanged("AS_PLAN_CAT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_STRATEGY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_STRATEGY
        {
            get { return _AS_STRATEGY; }
            set
            {
                if (_AS_STRATEGY != value)
                {
                    _AS_STRATEGY = value; RaisePropertyChanged("AS_STRATEGY");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_TASK_LIST { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_TASK_LIST
        {
            get { return _AS_TASK_LIST; }
            set
            {
                if (_AS_TASK_LIST != value)
                {
                    _AS_TASK_LIST = value; RaisePropertyChanged("AS_TASK_LIST");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_COUNTER { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_COUNTER
        {
            get { return _AS_COUNTER; }
            set
            {
                if (_AS_COUNTER != value)
                {
                    _AS_COUNTER = value; RaisePropertyChanged("AS_COUNTER");
                }
            }
        }


        private DataGridCellInfo _cellInfo;
        public DataGridCellInfo CellInfo
        {
            get { return _cellInfo; }
            set
            {
                _cellInfo = value;
                SetAutoTextSource(_cellInfo);
                RaisePropertyChanged("CellInfo");
            }
        }
        private void SetAutoTextSource(DataGridCellInfo dgCellInfo)
        {
            if (dgCellInfo != null)
            {
                var column = dgCellInfo.Column as DataGridColumn;
                if (column != null)
                {
                    string headerName = column.Header.ToString();
                    string SourceName = column.SortMemberPath.ToString();
                    if (SourceName == "obj_no")
                    { AS_DEFAULT = AS_OBJECT; }
                    else if (SourceName == "unit_code")
                    { AS_DEFAULT = AS_UNIT_CYCLE; }
                    else if (SourceName == "mp_no")
                    { AS_DEFAULT = AS_COUNTER; }

                }
            }
        }

        #endregion
        #region Relay Command
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdLoadBackFlipData { get; private set; }
        public RelayCommand<object> cmdExecuteReference { get; private set; }
        public RelayCommand<object> cmdInsertObject { get; private set; }
        public RelayCommand<object> cmdSC_PMM_T001_B { get; private set; }
        public RelayCommand<object> cmdSC_PMM_T002 { get; private set; }
        //public RelayCommand<object> cmdInsertCompany { get; private set; }

        #endregion

        #region Constructor
        public PMM_T001_VM(string ts_code, string doc_cat) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            PMM_T001.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MC_PMM_T001_BE();
            MC_TEMP = new MC_PMM_T001_BE();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            MasterEntity = new PMM_T001();
            ItemEntity = new ObservableCollection<PMM_T001_A>();
            PMM_T001_A_OBJ = new PMM_T001_A();
            CycleEntity = new ObservableCollection<PMM_T001_B>();
            ScheduleEntity = new ObservableCollection<PMM_T002>();
            PMM_T001_B_OBJ = new PMM_T001_B();
            PMM_T002_OBJ = new PMM_T002();
            CallObjectEntity = new ObservableCollection<PMM_T003>();
            PMM_T003_OBJ = new PMM_T003();
            CycleEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyCycleEntity);
            ScheduleEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyScheduleEntityEntity);
            sms = this.GetViewService<IShowMessageViewService>();

            InitializeCommands();
        }
        public PMM_T001_VM(string ts_code, string doc_cat, string doc_no) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            PMM_T001.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MC_PMM_T001_BE();
            MC_TEMP = new MC_PMM_T001_BE();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            MasterEntity = new PMM_T001();
            ItemEntity = new ObservableCollection<PMM_T001_A>();
            PMM_T001_A_OBJ = new PMM_T001_A();
            CycleEntity = new ObservableCollection<PMM_T001_B>();
            ScheduleEntity = new ObservableCollection<PMM_T002>();
            PMM_T001_B_OBJ = new PMM_T001_B();
            PMM_T002_OBJ = new PMM_T002();
            CallObjectEntity = new ObservableCollection<PMM_T003>();
            PMM_T003_OBJ = new PMM_T003();

            CycleEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyCycleEntity);
            ScheduleEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyScheduleEntityEntity);
            sms = this.GetViewService<IShowMessageViewService>();

            InitializeCommands();
        }
        #endregion
        #region Standard Functions
        private void LoadInitialData(string company, string location)
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client.ToString() + "!@" + company + "!@" + location + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + AppSessionState.EmpId; // AppSessionState.EmpId + "SINGLE";
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_PMM_T001_BE>(MC, Request, "PMM_T001_BL", "PMM", " ", 0, "");

                #region Autosuggest

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).ref_doc_no);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).ref_doc_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).obj_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).obj_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).char_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_DEFAULT = new AutoSuggestTextViewModel<dynamic>(MC.REF_DOC_LIST, TheFilter, SuggestedValue, "ref_doc_no", true);
                AS_DEFAULT_1 = new AutoSuggestTextViewModel<dynamic>(MC.REF_DOC_LIST, TheFilter, SuggestedValue, "ref_doc_no", true);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).ref_doc_no);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).ref_doc_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).obj_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).obj_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).char_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_REF_DOC = new AutoSuggestTextViewModel<dynamic>(MC.REF_DOC_LIST, TheFilter, SuggestedValue, "ref_doc_no", true);
                AS_REF_DOC.AutoSuggestVM.IsEmptyValueAllowed = false; AS_REF_DOC.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M0002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0002)o).comp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", true);
                AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = true;

                //List<STD_PERSONNEL> EMP_OBJ_OPR = MC.PERSONNEL_LIST.Where(x => x.emp_type == "OPR").ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id);
                TheFilter = (o, prefix) => (((STD_PERSONNEL)o).emp_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PERSONNEL)o).emp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_EMPLOYEE = new AutoSuggestTextViewModel<dynamic>(MC.PERSONNEL_LIST, TheFilter, SuggestedValue, "emp_id", true);
                AS_EMPLOYEE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_EMPLOYEE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_STATUS = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_status", true);
                AS_STATUS.AutoSuggestVM.IsEmptyValueAllowed = false; AS_STATUS.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).location_id);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).short_text ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).location ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).char_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_FUN_LOCATION = new AutoSuggestTextViewModel<dynamic>(MC.FUNC_LOCATION_LIST, TheFilter, SuggestedValue, "location_id", true);
                AS_FUN_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = true; AS_FUN_LOCATION.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).wc_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).wc_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).wc_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).short_text ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).char_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_WORK_CENTER = new AutoSuggestTextViewModel<dynamic>(MC.WC_LIST, TheFilter, SuggestedValue, "wc_code", true);
                AS_WORK_CENTER.AutoSuggestVM.IsEmptyValueAllowed = true; AS_WORK_CENTER.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) ;
                AS_PLANT = new AutoSuggestTextViewModel<dynamic>(MC.LOCATION_LIST, TheFilter, SuggestedValue, "location_id", true);
                AS_PLANT.AutoSuggestVM.IsEmptyValueAllowed = false; AS_PLANT.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).equip_no);
                TheFilter = (o, prefix) => (((STD_ITEM)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).equip_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).equip_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_OBJECT = new AutoSuggestTextViewModel<dynamic>(MC.ITEM_LIST, TheFilter, SuggestedValue, "equip_no", true);
                AS_OBJECT.AutoSuggestVM.IsEmptyValueAllowed = false; AS_OBJECT.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UNIT = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                AS_UNIT.AutoSuggestVM.IsEmptyValueAllowed = false; AS_UNIT.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UNIT_CYCLE = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST.Where(x => x.unit_code != null).ToList(), TheFilter, SuggestedValue, "unit_code", true);
                AS_UNIT_CYCLE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_UNIT_CYCLE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_DOC_TYPE)x).doc_cat);
                TheFilter = (o, prefix) => (((STD_DOC_TYPE)o).doc_cat ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_DOC_TYPE)o).doc_type_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ORDER_CAT = new AutoSuggestTextViewModel<dynamic>(MC.ORDER_CAT_LIST, TheFilter, SuggestedValue, "doc_cat", true);
                AS_ORDER_CAT.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ORDER_CAT.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).cat_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).cat_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).cat_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_PLAN_CAT = new AutoSuggestTextViewModel<dynamic>(MC.PLAN_CAT_LIST, TheFilter, SuggestedValue, "cat_code", true);
                AS_PLAN_CAT.AutoSuggestVM.IsEmptyValueAllowed = false; AS_PLAN_CAT.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).value_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).value_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).short_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_STRATEGY = new AutoSuggestTextViewModel<dynamic>(MC.STRATEGY_LIST, TheFilter, SuggestedValue, "value_code", true);
                AS_STRATEGY.AutoSuggestVM.IsEmptyValueAllowed = false; AS_STRATEGY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).doc_no);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).doc_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).short_text ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_TASK_LIST = new AutoSuggestTextViewModel<dynamic>(MC.MASTER_TASK_LIST, TheFilter, SuggestedValue, "doc_no", true);
                AS_TASK_LIST.AutoSuggestVM.IsEmptyValueAllowed = false; AS_TASK_LIST.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).doc_no);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).doc_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).short_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COUNTER = new AutoSuggestTextViewModel<dynamic>(MC.MP_LIST, TheFilter, SuggestedValue, "doc_no", true);
                AS_COUNTER.AutoSuggestVM.IsEmptyValueAllowed = false; AS_COUNTER.AutoSuggestVM.IsFreeTextAllowed = false;

                #endregion
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void LoadDocumentByDocumentNumber(object InputValue)
        {
            try
            {
                EntityChangeEnable = false;
                SelectedTabControlIndex = 0;
                STD_LIST_BE POPUPEntityObject = null;
                string Request;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC_TEMP.BACK_FLIP_LIST.Where(x => x.doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    if (MasterEntity.comp_code != POPUPEntityObject.comp_code) // call when document loading of different company
                    {
                        LoadInitialData(POPUPEntityObject.comp_code, POPUPEntityObject.location_id);
                    }

                    Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client.ToString() + "!@" + POPUPEntityObject.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + POPUPEntityObject.doc_no;
                    MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_PMM_T001_BE>(MC_TEMP, Request, "PMM_T001_BL", "PMM", " ", 0, "");

                    if (MC_TEMP.MasterEntity != null)
                    {
                        if (MC_TEMP.MasterEntity.Count > 0)
                        {
                            MasterEntity = MC_TEMP.MasterEntity[0];
                        }
                    }
                    if (MC_TEMP.ItemsEntity != null)
                    {
                        if (MC_TEMP.ItemsEntity.Count > 0)
                        {
                            PMM_T001_A_OBJ = MC_TEMP.ItemsEntity[0];
                        }
                    }
                    if (MC_TEMP.CycleEntity != null)
                    {
                        if (MC_TEMP.CycleEntity.Count > 0)
                        {
                            CycleEntity = MC_TEMP.CycleEntity;
                        }
                    }
                    if (MC_TEMP.ScheduleEntity != null)
                    {
                        if (MC_TEMP.ScheduleEntity.Count > 0)
                        {
                            ScheduleEntity = MC_TEMP.ScheduleEntity;
                        }
                    }
                    if (MC_TEMP.CallObjectEntity != null)
                    {
                        if (MC_TEMP.CallObjectEntity.Count > 0)
                        {
                            CallObjectEntity = MC_TEMP.CallObjectEntity;
                        }
                    }
                }
                MasterEntity.ts_code = ts_code_vm;
                EntityChangeEnable = true;
                isNewRecord = false;
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void GetExecutionData(object InputValue)
        {
        }
        private void InitializeCommands()
        {
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEventCall(items); });
            cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items); });
            cmdLoadBackFlipData = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items); });
            cmdExecuteReference = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteReference(items); });
            cmdInsertObject = new RelayCommand<object>(items => { if (items == null) { return; } InsertObject(items); });
            cmdSC_PMM_T001_B = new RelayCommand<object>(items => { if (items == null) { return; } SC_PMM_T001_B(items); });
            cmdSC_PMM_T002 = new RelayCommand<object>(items => { if (items == null) { return; } SC_PMM_T002(items); });
            //cmdInsertCompany = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCompany(cmdPara); });
        }

        private void SC_PMM_T001_B(object InputValue)
        {
            try
            {
                PMM_T001_B_OBJ = (PMM_T001_B)InputValue;
            }
            catch (Exception ex) { }
        }
        private void SC_PMM_T002(object InputValue)
        {
            try
            {
                PMM_T002_OBJ = (PMM_T002)InputValue;
            }
            catch (Exception ex) { }
        }
        private void DefaultValues()
        {
            try
            {
                EntityChangeEnable = true;
                isNewRecord = true;
                MasterEntity.doc_cat = this.doc_cat_vm;
                MasterEntity.doc_type = this.doc_cat_vm;
                MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                MasterEntity.active = "1";
                MasterEntity.location_id = AppSessionState.OBJ_LOCATION.location_id;
                MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                MasterEntity.doc_date = DateTime.UtcNow;

                PMM_T001_A_OBJ.active = "1";
                PMM_T001_A_OBJ.location_id = AppSessionState.OBJ_LOCATION.location_id;
                PMM_T001_A_OBJ.comp_code = AppSessionState.OBJ_COMPANY.comp_code;

                DateTime d = DateTime.UtcNow;
                d = d.AddMonths(-1);
                REQUEST_PARA.from_date = d;
                REQUEST_PARA.to_date = DateTime.UtcNow;
                REQUEST_PARA.active = true;
                REQUEST_PARA.location_id = AppSessionState.OBJ_LOCATION.location_id;
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
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
        private bool Validation()
        {
            if (string.IsNullOrWhiteSpace(MasterEntity.mp_cat))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Category Is Required"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(PMM_T001_A_OBJ.obj_no))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Equipment/Object Is Required"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.str_code))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Strategy Required"); sms.ShowMessage();
                return false;
            }

            return true;
        }
        private void LoadBackFlipData(object InputValue)
        {
            try
            {
                EntityChangeEnable = false;
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + (REQUEST_PARA.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (REQUEST_PARA.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + (Utilities.NullIf(REQUEST_PARA.doc_type ?? doc_cat_vm) ?? "") + "!@" + (Utilities.NullIf(REQUEST_PARA.t_status) ?? "") + "!@" + REQUEST_PARA.active + "!@" + (Utilities.NullIf(REQUEST_PARA.emp_id) ?? AppSessionState.EmpId) + "!@" + Convert.ToDateTime(REQUEST_PARA.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQUEST_PARA.to_date).ToString("MM/dd/yyyy");
                MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_PMM_T001_BE>(MC_TEMP, Request, "PMM_T001_BL", "PMM", "LoadAll", 0, "");
                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC_TEMP.BACK_FLIP_LIST);
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(Filter_BackFlip);
                EntityChangeEnable = true;
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

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
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;
        //            LoadInitialData(MasterEntity.comp_code, MasterEntity.location_id);
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;

        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
        //            TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //            AS_PLANT = new AutoSuggestTextViewModel<dynamic>(MC.LOCATION_LIST, TheFilter, SuggestedValue, "location_id", true);
        //            AS_PLANT.AutoSuggestVM.IsEmptyValueAllowed = false; AS_PLANT.AutoSuggestVM.IsFreeTextAllowed = false;
        //            if (MC.LOCATION_LIST.Count == 1)
        //            {
        //                PMM_T001_A_OBJ.mp_plant = MC.LOCATION_LIST[0].location_id;
        //            }
        //            else
        //            {
        //                PMM_T001_A_OBJ.mp_plant = null;
        //            }
        //        }
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
        //    }
        //}
        private void InsertObject(object InputValue)
        {
            try
            {
                string Request = "";
                STD_ITEM POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.ITEM_LIST.Where(x => x.equip_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_ITEM>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_ITEM>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    PMM_T001_A_OBJ.item_code = POPUPEntityObject.item_code;
                    PMM_T001_A_OBJ.item_name = POPUPEntityObject.item_name;
                    PMM_T001_A_OBJ.obj_no = POPUPEntityObject.obj_no;
                    PMM_T001_A_OBJ.equip_no = POPUPEntityObject.equip_no;
                    PMM_T001_A_OBJ.equip_name = POPUPEntityObject.equip_name;

                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void ExecuteReference(object InputValue)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.REF_DOC_LIST.Where(x => x.ref_doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    //MasterEntity.mp_no = POPUPEntityObject.ref_doc_no;
                    //MasterEntity.mp_name = POPUPEntityObject.short_text;
                    //MasterEntity.char_no = POPUPEntityObject.char_no;
                    //MasterEntity.char_name = POPUPEntityObject.char_name;
                    //MasterEntity.unit_code = POPUPEntityObject.unit_code;
                    //MasterEntity.source_doc = POPUPEntityObject.ref_doc_no;
                    //MasterEntity.active = "1";
                    //MasterEntity.comp_code = POPUPEntityObject.comp_code;
                    //MasterEntity.obj_no = POPUPEntityObject.obj_no;
                    //MasterEntity.obj_name = POPUPEntityObject.obj_name;
                    //MasterEntity.mp_cat = POPUPEntityObject.cat_code;
                    //MasterEntity.pos_no = POPUPEntityObject.short_name;

                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        #endregion
        #region EntityChangeNotification Section
        void Model_MasterEntityChange(object sender, EventArgs e)
        {
            try
            {
                if (EntityChangeEnable == true)
                {
                    //if (sender.ToString() == "date_start" || sender.ToString() == "date_end")
                    //{
                    //    MasterEntity.dur
                    //}
                }
            }
            catch (Exception ex)
            { }
        }

        private void CCNotifyCycleEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (PMM_T001_B item in e.NewItems)
                    {
                        item.active = "1";
                        item.client = AppSessionState.client;
                        item.comp_code = MasterEntity.comp_code;
                        item.cycle_seq = CycleEntity.Count;
                        item.doc_no = MasterEntity.doc_no;
                        item.client = AppSessionState.client;
                        item.t_status = "01";
                        item.location_id = MasterEntity.location_id;
                        item.id = 0;
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private void CCNotifyScheduleEntityEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (PMM_T002 item in e.NewItems)
                    {
                        item.active = "1";
                        item.comp_code = MasterEntity.comp_code;
                        item.client = AppSessionState.client;
                        item.t_status = "01";
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        #endregion
        #region Command_Function

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
        private void WindowEventCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    //LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                }
                else
                {
                    MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                    MasterEntity.location_id = AppSessionState.OBJ_LOCATION.location_id;
                    LoadInitialData(MasterEntity.comp_code, MasterEntity.location_id);

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ConfirmationTypes)x).conf_type);
                    TheFilter = (o, prefix) => (((ConfirmationTypes)o).conf_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ConfirmationTypes)o).conf_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    DefaultValues();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        #endregion
        #region FilterMethods
        private string _filterString_BackFlip;
        public string FilterString_BackFlip
        {
            get { return _filterString_BackFlip; }
            set
            {
                _filterString_BackFlip = value;
                RaisePropertyChanged("FilterString_BackFlip");
                FilterCollection_BackFlip();
            }
        }
        private void FilterCollection_BackFlip()
        {
            if (_BACKFLIP_COLLECTION != null)
            {
                _BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool Filter_BackFlip(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BackFlip))
                {
                    return (data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.doc_title != null && data.doc_title.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.short_text != null && data.short_text.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.emp_name != null && data.emp_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.item_code != null && data.item_code.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.item_name != null && data.item_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.doc_date.ToString() != null && data.doc_date.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.obj_no != null && data.obj_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.obj_name != null && data.obj_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.char_code != null && data.char_code.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.char_name != null && data.char_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()));
                }
                return true;
            }
            return false;

        }


        #endregion

        #region Abstract Command
        protected override void OnCreateAction(InquiryActionResult<PMM_T001> result)
        {
            if (MasterEntity.comp_code != AppSessionState.OBJ_COMPANY.comp_code) // call when document loading of different company. call before Master Entity instance is being created.
            {
                LoadInitialData(AppSessionState.OBJ_COMPANY.comp_code, AppSessionState.OBJ_LOCATION.location_id);
            }
            PMM_T001.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MC_PMM_T001_BE();
            MC_TEMP = new MC_PMM_T001_BE();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            MasterEntity = new PMM_T001();
            ItemEntity = new ObservableCollection<PMM_T001_A>();
            PMM_T001_A_OBJ = new PMM_T001_A();
            CycleEntity = new ObservableCollection<PMM_T001_B>();
            ScheduleEntity = new ObservableCollection<PMM_T002>();
            PMM_T001_B_OBJ = new PMM_T001_B();
            PMM_T002_OBJ = new PMM_T002();
            CallObjectEntity = new ObservableCollection<PMM_T003>();
            PMM_T003_OBJ = new PMM_T003();
            CycleEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyCycleEntity);
            ScheduleEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyScheduleEntityEntity);
            DefaultValues();
        }
        protected override void OnDiscardAction(InquiryActionResult<PMM_T001> result)
        {

        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<PMM_T001> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<PMM_T001> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<PMM_T001> result)
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<PMM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PMM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PMM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PMM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PMM_T001> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnPrintAction(InquiryActionResult<PMM_T001> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<PMM_T001> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<PMM_T001> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.ts_code = ts_code_vm;
                    Logging();

                    List<PMM_T001_A> OBJ_A = new List<PMM_T001_A>();
                    List<PMM_T001_B> OBJ_B = new List<PMM_T001_B>();
                    OBJ_A.Add(PMM_T001_A_OBJ);

                    MasterEntity.XDOC_A = SER_OBJ.ObjectToXML(OBJ_A);
                    MasterEntity.XDOC_B = SER_OBJ.ObjectToXML(CycleEntity);
                    MasterEntity.XDOC_C = SER_OBJ.ObjectToXML(ScheduleEntity);
                    MasterEntity.XDOC_D = SER_OBJ.ObjectToXML(CallObjectEntity);

                    if (isNewRecord == true)
                    {
                        MasterEntity = REPO.SaveWithReturnDomainObject<PMM_T001>(MasterEntity, "PMM_T001_BL", "PMM");
                        isNewRecord = false;
                        SetBusinessEntitiesAfterLoad("Save", "");
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record Addred Successfully!", this.Title); sms.ShowMessage();
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = REPO.UpdateWithReturnDomainObject<PMM_T001>(MasterEntity, "PMM_T001_BL", "PMM");
                        isNewRecord = false;
                        SetBusinessEntitiesAfterLoad("Save", "");
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record Addred Successfully!", this.Title); sms.ShowMessage();
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                EntityChangeEnable = false;
                if (MasterEntity.XDOC_A != null)
                {
                    ItemEntity = (ObservableCollection<PMM_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_A, MC.ItemsEntity);
                    if(ItemEntity != null)
                    {
                        if(ItemEntity.Count > 0)
                        {
                            PMM_T001_A_OBJ = ItemEntity[0];
                        }
                    }
                }
                else
                {
                    ItemEntity = new ObservableCollection<PMM_T001_A>();
                }
                if (MasterEntity.XDOC_B != null)
                {
                    MC.CycleEntity = (ObservableCollection<PMM_T001_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_B, MC.CycleEntity);
                    CycleEntity.Clear();
                    CycleEntity = MC.CycleEntity;
                }
                else
                {
                    MC.CycleEntity = new ObservableCollection<PMM_T001_B>();
                }
                if (MasterEntity.XDOC_C != null)
                {
                    MC.ScheduleEntity = (ObservableCollection<PMM_T002>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_C, MC.ScheduleEntity);
                    ScheduleEntity.Clear();
                    ScheduleEntity = MC.ScheduleEntity;
                }
                else
                {
                    MC.ScheduleEntity = new ObservableCollection<PMM_T002>();
                }
                if (MasterEntity.XDOC_D != null)
                {
                    MC.CallObjectEntity = (ObservableCollection<PMM_T003>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_D, MC.CallObjectEntity);
                    CallObjectEntity.Clear();
                    CallObjectEntity = MC.CallObjectEntity;
                }
                else
                {
                    MC.CallObjectEntity = new ObservableCollection<PMM_T003>();
                }

                MasterEntity.ts_code = ts_code_vm;
                EntityChangeEnable = true;
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        #endregion
    }
}
