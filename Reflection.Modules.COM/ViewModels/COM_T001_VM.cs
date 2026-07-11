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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.Windows.Controls;
using Reflection.BusinessEntity.COM;
using System.Threading.Tasks;
using Reflection.Presentation.Common;
using Reflection.ReportingServices;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.COM.ViewModels
{
    public class COM_T001_VM : WorkspaceViewModel<COM_T001>
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

        WebServiceRepository<COM_T001> REPO = new WebServiceRepository<COM_T001>();
        WebServiceRepository<MC_COM_T001_BE> REPO_MC = new WebServiceRepository<MC_COM_T001_BE>();
        IShowMessageViewService sms;
        ObjectSerializationService SER_OBJ = new ObjectSerializationService();

        private MC_COM_T001_BE _MC = new MC_COM_T001_BE();
        public MC_COM_T001_BE MC
        {
            get { return _MC; }
            set { if (_MC != value) { _MC = value; RaisePropertyChanged("MC"); } }
        }
        private MC_COM_T001_BE _MC_TEMP = new MC_COM_T001_BE();
        public MC_COM_T001_BE MC_TEMP
        {
            get { return _MC_TEMP; }
            set { if (_MC_TEMP != value) { _MC_TEMP = value; RaisePropertyChanged("MC_TEMP"); } }
        }

        private COM_T001 _MasterEntity;
        public COM_T001 MasterEntity
        {
            get { return _MasterEntity; }
            set { if (_MasterEntity != value) { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); } }
        }

        private ObservableCollection<COM_T001_A> _ItemEntity;
        public ObservableCollection<COM_T001_A> ItemEntity
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
        private COM_T001_A _COM_T001_A_OBJ;
        public COM_T001_A COM_T001_A_OBJ
        {
            get { return _COM_T001_A_OBJ; }
            set { if (_COM_T001_A_OBJ != value) { _COM_T001_A_OBJ = value; RaisePropertyChanged("COM_T001_A_OBJ"); } }
        }
        private ObservableCollection<COM_T001_B> _TaskEntity;
        public ObservableCollection<COM_T001_B> TaskEntity
        {
            get { return _TaskEntity; }
            set
            {
                if (_TaskEntity != value)
                {
                    _TaskEntity = value;
                    //_TaskEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyTaskEntity);
                    RaisePropertyChanged("TaskEntity");
                }
            }
        }
        private COM_T001_B _COM_T001_B_OBJ;
        public COM_T001_B COM_T001_B_OBJ
        {
            get { return _COM_T001_B_OBJ; }
            set { if (_COM_T001_B_OBJ != value) { _COM_T001_B_OBJ = value; RaisePropertyChanged("COM_T001_B_OBJ"); } }
        }
        private ObservableCollection<COM_T001_C> _ActivityEntity;
        public ObservableCollection<COM_T001_C> ActivityEntity
        {
            get { return _ActivityEntity; }
            set
            {
                if (_ActivityEntity != value)
                {
                    _ActivityEntity = value;
                    //ActivityEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyActivityEntity);
                    RaisePropertyChanged("_ActivityEntity");
                }
            }
        }
        private COM_T001_C _COM_T001_C_OBJ;
        public COM_T001_C COM_T001_C_OBJ
        {
            get { return _COM_T001_C_OBJ; }
            set { if (_COM_T001_C_OBJ != value) { _COM_T001_C_OBJ = value; RaisePropertyChanged("COM_T001_C_OBJ"); } }
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
        private int _TabIndexItem;
        public int TabIndexItem
        {
            get { return _TabIndexItem; }
            set
            {
                if (_TabIndexItem != value)
                {
                    _TabIndexItem = value;
                    RaisePropertyChanged("TabIndexItem");
                }
            }
        }

        #endregion

        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(COM_T001_VM));
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
        private AutoSuggestTextViewModel<dynamic> _AS_REPORTER { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_REPORTER
        {
            get { return _AS_REPORTER; }
            set
            {
                if (_AS_REPORTER != value)
                {
                    _AS_REPORTER = value; RaisePropertyChanged("AS_REPORTER");
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
        private AutoSuggestTextViewModel<dynamic> _AS_ORDERS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ORDERS
        {
            get { return _AS_ORDERS; }
            set
            {
                if (_AS_ORDERS != value)
                {
                    _AS_ORDERS = value; RaisePropertyChanged("AS_ORDERS");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_NOT_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_NOT_TYPE
        {
            get { return _AS_NOT_TYPE; }
            set
            {
                if (_AS_NOT_TYPE != value)
                {
                    _AS_NOT_TYPE = value; RaisePropertyChanged("AS_NOT_TYPE");
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
        public RelayCommand<object> cmdSC_COM_T001_B { get; private set; }
        public RelayCommand<object> cmdSC_COM_T001_C { get; private set; }
        //public RelayCommand<object> cmdInsertCompany { get; private set; }

        #endregion

        #region Constructor
        public COM_T001_VM(string ts_code, string doc_cat) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            COM_T001.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MC_COM_T001_BE();
            MC_TEMP = new MC_COM_T001_BE();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            MasterEntity = new COM_T001();
            ItemEntity = new ObservableCollection<COM_T001_A>();
            COM_T001_A_OBJ = new COM_T001_A();
            TaskEntity = new ObservableCollection<COM_T001_B>();
            COM_T001_B_OBJ = new COM_T001_B();
            ActivityEntity = new ObservableCollection<COM_T001_C>();
            COM_T001_C_OBJ = new COM_T001_C();
            //TaskEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyTaskEntityEntity);
            //ActivityEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyActivityEntityEntity);
            sms = this.GetViewService<IShowMessageViewService>();

            InitializeCommands();
        }
        public COM_T001_VM(string ts_code, string doc_cat, string doc_no) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            COM_T001.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MC_COM_T001_BE();
            MC_TEMP = new MC_COM_T001_BE();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            MasterEntity = new COM_T001();
            ItemEntity = new ObservableCollection<COM_T001_A>();
            COM_T001_A_OBJ = new COM_T001_A();
            TaskEntity = new ObservableCollection<COM_T001_B>();
            COM_T001_B_OBJ = new COM_T001_B();
            ActivityEntity = new ObservableCollection<COM_T001_C>();
            COM_T001_C_OBJ = new COM_T001_C();

            //TaskEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyTaskEntity);
            //ActivityEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyActivityEntityEntity);
            sms = this.GetViewService<IShowMessageViewService>();

            InitializeCommands();
        }
        #endregion
        #region Standard Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (MasterEntity.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + AppSessionState.EmpId; // AppSessionState.EmpId + "SINGLE";
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_COM_T001_BE>(MC, Request, "COM_T001_BL", "COM", " ", 0, "");

                #region Autosuggest

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).ref_doc_no);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).ref_doc_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).obj_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).obj_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).char_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_DEFAULT = new AutoSuggestTextViewModel<dynamic>(MC.REF_DOC_LIST, TheFilter, SuggestedValue, "ref_doc_no", true);
                AS_DEFAULT_1 = new AutoSuggestTextViewModel<dynamic>(MC.REF_DOC_LIST, TheFilter, SuggestedValue, "ref_doc_no", true);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).ref_doc_no);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).ref_doc_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).obj_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).obj_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).char_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_REF_DOC = new AutoSuggestTextViewModel<dynamic>(MC.REF_DOC_LIST, TheFilter, SuggestedValue, "ref_doc_no", true);
                AS_REF_DOC.AutoSuggestVM.IsEmptyValueAllowed = false; AS_REF_DOC.AutoSuggestVM.IsFreeTextAllowed = false;

                //List<STD_PERSONNEL> EMP_OBJ_OPR = MC.PERSONNEL_LIST.Where(x => x.emp_type == "OPR").ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id);
                TheFilter = (o, prefix) => (((STD_PERSONNEL)o).emp_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PERSONNEL)o).emp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_EMPLOYEE = new AutoSuggestTextViewModel<dynamic>(MC.PERSONNEL_LIST, TheFilter, SuggestedValue, "emp_id", true);
                AS_EMPLOYEE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_EMPLOYEE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id);
                TheFilter = (o, prefix) => (((STD_PERSONNEL)o).emp_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PERSONNEL)o).emp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_REPORTER = new AutoSuggestTextViewModel<dynamic>(MC.PERSONNEL_LIST.Where(x => x.emp_id != null).ToList(), TheFilter, SuggestedValue, "emp_id", true);
                AS_REPORTER.AutoSuggestVM.IsEmptyValueAllowed = false; AS_REPORTER.AutoSuggestVM.IsFreeTextAllowed = false;

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

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M0002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0002)o).comp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", true);
                AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_PLANT = new AutoSuggestTextViewModel<dynamic>(MC.LOCATION_LIST, TheFilter, SuggestedValue, "location_id", true);
                AS_PLANT.AutoSuggestVM.IsEmptyValueAllowed = false; AS_PLANT.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).equip_no);
                TheFilter = (o, prefix) => (((STD_ITEM)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).equip_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).equip_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).obj_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_OBJECT = new AutoSuggestTextViewModel<dynamic>(MC.ITEM_LIST, TheFilter, SuggestedValue, "equip_no", true);
                AS_OBJECT.AutoSuggestVM.IsEmptyValueAllowed = false; AS_OBJECT.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UNIT = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                AS_UNIT.AutoSuggestVM.IsEmptyValueAllowed = false; AS_UNIT.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).order_no);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).order_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).equip_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ORDERS = new AutoSuggestTextViewModel<dynamic>(MC.REF_DOC_LIST, TheFilter, SuggestedValue, "order_no", true);
                AS_ORDERS.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ORDERS.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).not_type);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).cat_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).not_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).short_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_NOT_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.NOT_TYPE_LIST, TheFilter, SuggestedValue, "not_type", true);
                AS_NOT_TYPE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_NOT_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;


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
                if (POPUPEntityObject == null && InputValue != null)
                {
                    POPUPEntityObject = new STD_LIST_BE();
                    POPUPEntityObject.doc_no = InputValue.ToString();
                    POPUPEntityObject.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                }

                if (POPUPEntityObject != null)
                {
                    Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client.ToString() + "!@" + POPUPEntityObject.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + POPUPEntityObject.doc_no;
                    MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_COM_T001_BE>(MC_TEMP, Request, "COM_T001_BL", "COM", " ", 0, "");

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
                            COM_T001_A_OBJ = MC_TEMP.ItemsEntity[0];
                        }
                    }
                    if (MC_TEMP.TaskEntity != null)
                    {
                        if (MC_TEMP.TaskEntity.Count > 0)
                        {
                            TaskEntity = MC_TEMP.TaskEntity;
                        }
                    }
                    if (MC_TEMP.ActivityEntity != null)
                    {
                        if (MC_TEMP.ActivityEntity.Count > 0)
                        {
                            ActivityEntity = MC_TEMP.ActivityEntity;
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
            cmdSC_COM_T001_B = new RelayCommand<object>(items => { if (items == null) { return; } SC_COM_T001_B(items); });
            cmdSC_COM_T001_C = new RelayCommand<object>(items => { if (items == null) { return; } SC_COM_T001_C(items); });
            //cmdInsertCompany = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCompany(cmdPara); });
        }

        private void SC_COM_T001_B(object InputValue)
        {
            try
            {
                COM_T001_B_OBJ = (COM_T001_B)InputValue;
            }
            catch (Exception ex) { }
        }
        private void SC_COM_T001_C(object InputValue)
        {
            try
            {
                COM_T001_C_OBJ = (COM_T001_C)InputValue;
            }
            catch (Exception ex) { }
        }
        private void DefaultValues()
        {
            try
            {
                EntityChangeEnable = true;
                isNewRecord = true;
                MasterEntity.ts_code = this.ts_code_vm;
                MasterEntity.doc_cat = this.doc_cat_vm;
                MasterEntity.doc_type = this.doc_cat_vm;
                MasterEntity.userid = AppSessionState.UserID;
                MasterEntity.client = AppSessionState.client;
                MasterEntity.active = "1";
                MasterEntity.location_id = AppSessionState.OBJ_LOCATION.location_id;
                MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                MasterEntity.doc_date = DateTime.UtcNow;

                COM_T001_A_OBJ.active = "1";
                COM_T001_A_OBJ.location_id = AppSessionState.OBJ_LOCATION.location_id;
                COM_T001_A_OBJ.comp_code = AppSessionState.OBJ_COMPANY.comp_code;

                MasterEntity.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
                MasterEntity.t_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_display).FirstOrDefault();


                
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private bool Validation()
        {
            if (string.IsNullOrWhiteSpace(MasterEntity.not_type))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Category is required"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.emp_id))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Requester user is required"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.short_text))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Subject is required"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.long_text))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Notification content is required"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.equip_no))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Equipment/Object is required"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.obj_no))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Strategy required"); sms.ShowMessage();
                return false;
            }

            return true;
        }
        private void LoadBackFlipData(object InputValue)
        {
            try
            {
                EntityChangeEnable = false;
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (REQUEST_PARA.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + (Utilities.NullIf(REQUEST_PARA.doc_type ?? doc_cat_vm) ?? "") + "!@" + (Utilities.NullIf(REQUEST_PARA.t_status) ?? "") + "!@" + REQUEST_PARA.active + "!@" + (Utilities.NullIf(REQUEST_PARA.emp_id) ?? AppSessionState.EmpId) + "!@" + Convert.ToDateTime(REQUEST_PARA.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQUEST_PARA.to_date).ToString("MM/dd/yyyy");
                MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_COM_T001_BE>(MC_TEMP, Request, "COM_T001_BL", "COM", "LoadAll", 0, "");
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
        //            LoadInitialData();
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;

        //            List<ADM_M0003> LOC_LIST_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == MasterEntity.comp_code).ToList();
        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
        //            TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //            AS_PLANT = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_id", true);
        //            AS_PLANT.AutoSuggestVM.IsEmptyValueAllowed = false; AS_PLANT.AutoSuggestVM.IsFreeTextAllowed = false;
        //            if (LOC_LIST_OBJ.Count == 1)
        //            {
        //                MasterEntity.location_id = LOC_LIST_OBJ[0].location_id;
        //            }
        //            else
        //            {
        //                MasterEntity.location_id = null;
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
                            POPUPEntityObject = MC.ITEM_LIST.Where(x => x.equip_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true ).ToList()[0];
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
                    MasterEntity.item_code = POPUPEntityObject.item_code;
                    //MasterEntity.item_name = POPUPEntityObject.item_name;
                    MasterEntity.obj_no = POPUPEntityObject.obj_no;
                    MasterEntity.equip_no = POPUPEntityObject.equip_no;
                    MasterEntity.obj_name = POPUPEntityObject.equip_name;
                    MasterEntity.equip_name = POPUPEntityObject.equip_name;

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
                    if (sender.ToString() == "prod_dt")
                    {
                    }
                }
            }
            catch (Exception ex)
            { }
        }

        private void CCNotifyTaskEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (COM_T001_B item in e.NewItems)
                    {
                        item.active = "1";
                        item.client = AppSessionState.client;
                        item.comp_code = MasterEntity.comp_code;
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

        private void CCNotifyActivityEntityEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (COM_T001_C item in e.NewItems)
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
                    LoadDocumentByDocumentNumber(doc_no_vm); // NOTE: this need to be commented because there is no provision for uniform input to this function from BackFlip, Constructor & WindoesEventCall method of single string. make proper and then use constructor.
                }
                else
                {
                    LoadInitialData();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ConfirmationTypes)x).conf_type);
                    TheFilter = (o, prefix) => (((ConfirmationTypes)o).conf_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ConfirmationTypes)o).conf_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    DefaultValues();

                    DateTime d = DateTime.UtcNow;
                    d = d.AddMonths(-1);
                    REQUEST_PARA.from_date = d;
                    REQUEST_PARA.to_date = DateTime.UtcNow;
                    REQUEST_PARA.active = true;
                    REQUEST_PARA.location_id = AppSessionState.OBJ_LOCATION.location_id;
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
        protected override void OnCreateAction(InquiryActionResult<COM_T001> result)
        {
            COM_T001.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            REQUEST_PARA = new STD_REQ_PARA_BE();
            MasterEntity = new COM_T001();
            ItemEntity = new ObservableCollection<COM_T001_A>();
            COM_T001_A_OBJ = new COM_T001_A();
            TaskEntity = new ObservableCollection<COM_T001_B>();
            COM_T001_B_OBJ = new COM_T001_B();
            ActivityEntity = new ObservableCollection<COM_T001_C>();
            COM_T001_C_OBJ = new COM_T001_C();
            //TaskEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyTaskEntity);
            //ActivityEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCNotifyScheduleEntityEntity);
            DefaultValues();
            SelectedTabControlIndex = 0;
        }
        protected override void OnDiscardAction(InquiryActionResult<COM_T001> result)
        {

        }
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.doc_no))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MC_TEMP.ATTACHMENT_LIST, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            }
        }
        protected override void OnFevoriteAction(InquiryActionResult<COM_T001> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<COM_T001> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<COM_T001> result)
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<COM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<COM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<COM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<COM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<COM_T001> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnPrintAction(InquiryActionResult<COM_T001> result)
        {
            try
            {
                CursorControl.SetBusyState();
                string ReportName = "";
                STD_DOC_TYPE OBJ_DOC_TYPE = new STD_DOC_TYPE();
                object[] objDataSource = new object[3];
                string[] objDataSourceName = new string[3];

                objDataSource[0] = AppSessionState.COMPANY_LIST.Where(x => x.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[1] = AppSessionState.LOCATION_LIST.Where(x => x.comp_code == MasterEntity.comp_code && x.location_id == MasterEntity.location_id).ToList();


                if (MC.MasterEntity != null)
                {
                    if (MC.MasterEntity.Count > 0)
                    {
                        MC.MasterEntity.Clear();
                        MC.MasterEntity.Add(MasterEntity);
                    }
                    else
                    {
                        MC.MasterEntity.Add(_MasterEntity);
                    }
                }
                objDataSource[2] = MC.MasterEntity;

                objDataSourceName[0] = "dsCompany";
                objDataSourceName[1] = "dsLocation";
                objDataSourceName[2] = "dsMaster";

                ReportManager RManager = new ReportManager();

                var SystemDocumentObject = (from o in MC.DOC_TYPE_LIST where o.doc_cat == MasterEntity.doc_cat && o.doc_type == MasterEntity.doc_type select o).ToList();
                if (SystemDocumentObject != null)
                {
                    if (SystemDocumentObject.Count > 0)
                    {
                        OBJ_DOC_TYPE = SystemDocumentObject[0];
                    }
                }
                if (OBJ_DOC_TYPE.ind_digital == "0")
                {
                    ReportName = OBJ_DOC_TYPE.report_name.Split(',')[1];
                }
                else
                {
                    ReportName = OBJ_DOC_TYPE.report_name.Split(',')[0];
                }

                string ReportDisplayName = MasterEntity.order_no + "_" + MasterEntity.doc_date.Value.ToShortDateString();
                RManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORTS_STD\\TXN\\" + ReportName, getParametersList(), ReportDisplayName);
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("prepare_by", Convert.ToString(AppSessionState.Name));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();

            }
            return result;
        }
        protected override void OnRemoveAction(InquiryActionResult<COM_T001> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<COM_T001> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.ts_code = ts_code_vm;
                    MasterEntity.userid = AppSessionState.UserID;
                    MasterEntity.user_source1 = AppSessionState.UserSource1;
                    MasterEntity.user_source2 = AppSessionState.UserSource2;

                    List<COM_T001_A> OBJ_A = new List<COM_T001_A>();
                    List<COM_T001_B> OBJ_B = new List<COM_T001_B>();
                    OBJ_A.Add(COM_T001_A_OBJ);

                    MasterEntity.XDOC_A = SER_OBJ.ObjectToXML(OBJ_A);
                    MasterEntity.XDOC_B = SER_OBJ.ObjectToXML(TaskEntity);
                    MasterEntity.XDOC_C = SER_OBJ.ObjectToXML(ActivityEntity);
                    TabIndexItem = 0;
                    if (isNewRecord == true)
                    {
                        MasterEntity = REPO.SaveWithReturnDomainObject<COM_T001>(MasterEntity, "COM_T001_BL", "COM");
                        isNewRecord = false;
                        SetBusinessEntitiesAfterLoad("Save", "");
                        if (MasterEntity.doc_no != null && MC.NOTIFICATION_LIST.FindIndex(f => f.alert_name == "OnInsert") >= 0)
                        {
                            NotifyMessage("OnInsert", "Created");
                        }
                        if (MasterEntity.doc_no != null && MC.NOTIFICATION_LIST.FindIndex(f => f.alert_name == "OnApproval") >= 0)
                        {
                            NotifyMessage("OnApproval", "Created");
                        }
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record Addred Successfully!", this.Title); sms.ShowMessage();
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = REPO.UpdateWithReturnDomainObject<COM_T001>(MasterEntity, "COM_T001_BL", "COM");
                        isNewRecord = false;
                        SetBusinessEntitiesAfterLoad("Save", "");
                        if (MasterEntity.doc_no != null && MC.NOTIFICATION_LIST.FindIndex(f => f.alert_name == "OnUpdate") >= 0)
                        {
                            NotifyMessage("OnUpdate", "Modified");
                        }
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record Addred Successfully!", this.Title); sms.ShowMessage();
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void NotifyMessage(string AlertName, string operation)
        {
            try
            {
                List<NotificationData> objNotifyData = new List<NotificationData>();
                List<NotificationData> objNotifyDataTemp = new List<NotificationData>();
                NotificationData objNotifyDataObject = new NotificationData();
                objNotifyDataTemp = MC.NOTIFICATION_LIST.Where(x => x.alert_name == AlertName).ToList();
                objNotifyDataTemp[0].CopyPropertiesTo<NotificationData>(objNotifyDataObject);
                objNotifyData.Add(objNotifyDataObject);
                foreach (NotificationData VarData in objNotifyData)
                {
                    List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("[EMP]",MasterEntity.emp_name),
                        new KeyValuePair<string, string>("[DOC]", MasterEntity.doc_type_name),
                        new KeyValuePair<string, string>("[NOT]", MasterEntity.not_type_name),
                        new KeyValuePair<string, string>("[OPR]", operation),
                        new KeyValuePair<string, string>("[DOCNO]", MasterEntity.doc_no),
                        new KeyValuePair<string, string>("[Comp]","M/S: " + AppSessionState.OBJ_COMPANY.comp_name),
                        new KeyValuePair<string, string>("[TSTS]", MasterEntity.t_display),
                        new KeyValuePair<string, string>("[RESP]",MasterEntity.emp_name_res),
                        new KeyValuePair<string, string>("[Attn]",MasterEntity.emp_name_res), // NOTE: MasterEntity.emp_name, need to set responsible person automatically
                        new KeyValuePair<string, string>("[SUB]", MasterEntity.short_text ?? MasterEntity.not_type_name),
                        new KeyValuePair<string, string>("[OBJ]", MasterEntity.obj_name),
                        new KeyValuePair<string, string>("[PART]", MasterEntity.party_code),
                        new KeyValuePair<string, string>("[DOCDATE]", MasterEntity.doc_date.ToString()),
                        new KeyValuePair<string, string>("[BODYTEXT]", MasterEntity.long_text),
                    };

                    foreach (KeyValuePair<string, string> kvp in kvpList)
                    {
                        VarData.subject = VarData.subject.Replace(kvp.Key, kvp.Value);
                        VarData.msg_body = VarData.msg_body.Replace(kvp.Key, kvp.Value);
                    }
                    VarData.cc_mail_id = (VarData.cc_mail_id ?? "") + ";" + (AppSessionState.EmpEmailId ?? "") + ";" + (MasterEntity.email_res ?? "");
                    Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, VarData.to_mail_id, VarData.cc_mail_id, VarData.bcc_mail_id, VarData.subject, VarData.msg_body, null);
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
                    ItemEntity = (ObservableCollection<COM_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_A, MC.ItemsEntity);
                    if (ItemEntity != null)
                    {
                        if (ItemEntity.Count > 0)
                        {
                            COM_T001_A_OBJ = ItemEntity[0];
                        }
                    }
                }
                else
                {
                    ItemEntity = new ObservableCollection<COM_T001_A>();
                }
                if (MasterEntity.XDOC_B != null)
                {
                    MC.TaskEntity = (ObservableCollection<COM_T001_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_B, MC.TaskEntity);
                    TaskEntity.Clear();
                    TaskEntity = MC.TaskEntity;
                }
                else
                {
                    MC.TaskEntity = new ObservableCollection<COM_T001_B>();
                }
                if (MasterEntity.XDOC_C != null)
                {
                    MC.ActivityEntity = (ObservableCollection<COM_T001_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_C, MC.ActivityEntity);
                    ActivityEntity.Clear();
                    ActivityEntity = MC.ActivityEntity;
                }
                else
                {
                    MC.ActivityEntity = new ObservableCollection<COM_T001_C>();
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
