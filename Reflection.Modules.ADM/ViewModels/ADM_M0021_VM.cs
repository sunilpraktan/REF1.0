using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using System.Collections.Specialized;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.BusinessEntity.ADM;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Common;

namespace Reflection.Modules.ADM.ViewModels
{
    public class ADM_M0021_VM : WorkspaceViewModel<ADM_M030>
    {

        #region Variable Declaration


        WebServiceRepository<Classification> REPOSITORY_OBJ = new WebServiceRepository<Classification>();
        WebServiceRepository<Classification_MC> REPOSITORY_OBJ_TEMP = new WebServiceRepository<Classification_MC>();
        Classification_MC MC_TEMP = new Classification_MC();
        Classification_MC MC = new Classification_MC();
        ObjectSerializationService SERIALIZATION_OBJ = new ObjectSerializationService();
        IShowMessageViewService sms;
        bool NewRecord = true;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }


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
        private int _dgSelectedIndexItem;
        public int dgSelectedIndexItem
        {
            get
            {
                return _dgSelectedIndexItem;
            }
            set
            {
                if (_dgSelectedIndexItem != value)
                {
                    _dgSelectedIndexItem = value;
                    RaisePropertyChanged("dgSelectedIndexItem");
                }
            }
        }

        private Classification _MASTER_ENTITY;
        public Classification MASTER_ENTITY
        {
            get
            {
                return _MASTER_ENTITY;
            }
            set
            {
                if (_MASTER_ENTITY != value)
                {
                    _MASTER_ENTITY = value;
                    RaisePropertyChanged(nameof(MASTER_ENTITY));
                }
            }
        }
        private ObservableCollection<Classification> _CLASS_VALUES;
        public ObservableCollection<Classification> CLASS_VALUES
        {
            get { return _CLASS_VALUES; }
            set
            {
                if (_CLASS_VALUES != value)
                {
                    _CLASS_VALUES = value;
                    _CLASS_VALUES.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForClassValues);
                    RaisePropertyChanged("CLASS_VALUES");
                }
            }
        }

        private ObservableCollection<Classification> _PROFILE_VALUES;
        public ObservableCollection<Classification> PROFILE_VALUES
        {
            get { return _PROFILE_VALUES; }
            set
            {
                if (_PROFILE_VALUES != value)
                {
                    _PROFILE_VALUES = value;
                    _PROFILE_VALUES.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForProfile);
                    RaisePropertyChanged("PROFILE_VALUES");
                }
            }
        }
        
        private Classification _CLASS_OBJ;
        public Classification CLASS_OBJ
        {
            get
            {
                return _CLASS_OBJ;
            }
            set
            {
                if (_CLASS_OBJ != value)
                {
                    _CLASS_OBJ = value;
                    RaisePropertyChanged(nameof(CLASS_OBJ));
                }
            }
        }
        private Classification _PROFILE_OBJ;
        public Classification PROFILE_OBJ
        {
            get
            {
                return _PROFILE_OBJ;
            }
            set
            {
                if (_PROFILE_OBJ != value)
                {
                    _PROFILE_OBJ = value;
                    RaisePropertyChanged(nameof(PROFILE_OBJ));
                }
            }
        }

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

        private STD_REQ_PARA_BE _REQ_PARA_OBJ;
        public STD_REQ_PARA_BE REQ_PARA_OBJ
        {
            get { return _REQ_PARA_OBJ; }
            set
            {
                if (_REQ_PARA_OBJ != value)
                {
                    _REQ_PARA_OBJ = value;

                    RaisePropertyChanged("REQ_PARA_OBJ");
                }
            }
        }

        #endregion

        #region ICollections
        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }

        #endregion

        #region Autosuggest Initialization

        //public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(ADM_M0021_VM));
        //public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

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

                    if (SourceName == "class_type")
                    { AS_DEFAULT = AS_CLASS_TYPE; }
                    if (SourceName == "class_code")
                    { AS_DEFAULT = AS_CLASS; }
                }
            }
        }
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
        private AutoSuggestTextViewModel<dynamic> _AS_CLASS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CLASS
        {
            get { return _AS_CLASS; }
            set
            {
                if (_AS_CLASS != value)
                {
                    _AS_CLASS = value; RaisePropertyChanged("AS_CLASS");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_PROFILE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PROFILE
        {
            get { return _AS_PROFILE; }
            set
            {
                if (_AS_PROFILE != value)
                {
                    _AS_PROFILE = value; RaisePropertyChanged("AS_PROFILE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_OBJECT_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_OBJECT_TYPE
        {
            get { return _AS_OBJECT_TYPE; }
            set
            {
                if (_AS_OBJECT_TYPE != value)
                {
                    _AS_OBJECT_TYPE = value; RaisePropertyChanged("AS_OBJECT_TYPE");
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
        private AutoSuggestTextViewModel<dynamic> _AS_CLASS_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CLASS_TYPE
        {
            get { return _AS_CLASS_TYPE; }
            set
            {
                if (_AS_CLASS_TYPE != value)
                {
                    _AS_CLASS_TYPE = value; RaisePropertyChanged("AS_CLASS_TYPE");
                }
            }
        }

        #endregion

        #region Relay commands Declaration
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowClass { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdInsertObjectType { get; private set; }
        public RelayCommand<object> cmdInsertObject { get; private set; }
        public RelayCommand<object> cmdInsertStatus { get; private set; }
        public RelayCommand<object> cmdInsertStatusClass { get; private set; }
        public RelayCommand<object> cmdInsertClass { get; private set; }
        public RelayCommand<object> cmdInsertClassType { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_ClassValue { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_Profile { get; private set; }



        private void CommandInitialisation()
        {
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdLoadBackFlip = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items); });
            cmdDeleteDataGridRowItem = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow_Item(items); });
            cmdDeleteDataGridRowClass = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow_Class(items); });
            cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
            cmdInsertObjectType = new RelayCommand<object>(items => { if (items == null) { return; } InsertObjectType(items); });
            cmdInsertObject = new RelayCommand<object>(items => { if (items == null) { return; } InsertObject(items); });
            cmdInsertStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertStatus(items); });
            //cmdInsertStatusClass = new RelayCommand<object>(items => { if (items == null) { return; } InsertStatusClass(items); });
            cmdInsertClass = new RelayCommand<object>(items => { if (items == null) { return; } InsertClass(items); });
            cmdInsertClassType = new RelayCommand<object>(items => { if (items == null) { return; } InsertClassType(items); });
            cmdSelectionChanged_ClassValue = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_Class(items); });
            cmdSelectionChanged_Profile = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_Profile(items); });
        }

        #endregion

        #region Command Implementation

        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (PROFILE_VALUES.Count > i && string.IsNullOrWhiteSpace(PROFILE_OBJ.profile_name))
                {
                    PROFILE_VALUES.RemoveAt(i);
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void DeleteDataGridRow_Class(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (CLASS_VALUES.Count > i && string.IsNullOrWhiteSpace(CLASS_OBJ.class_code))
                {
                    CLASS_VALUES.RemoveAt(i);
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                }
                else
                {
                    DefaultValues();
                }

            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertStatus(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0013 POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUP_ENTITY_OBJ = MC.STATUS_LIST.Where(x => x.t_status.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M0013>().Count() > 0)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<ADM_M0013>().ToList()[0];
                    }
                }
                #endregion

                if (POPUP_ENTITY_OBJ != null)
                {
                    MASTER_ENTITY.t_status = POPUP_ENTITY_OBJ.t_status;
                    MASTER_ENTITY.t_display = POPUP_ENTITY_OBJ.t_display;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertClassType(object InputValue)
        {
            try
            {
                string Request = "";
                Classification POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUP_ENTITY_OBJ = MC.CLASS_TYPE_LIST.Where(x => x.class_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<Classification>().Count() > 0)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<Classification>().ToList()[0];
                    }
                }
                #endregion

                if (POPUP_ENTITY_OBJ != null)
                {
                    MASTER_ENTITY.class_type = POPUP_ENTITY_OBJ.class_type;
                    PROFILE_OBJ.class_type = POPUP_ENTITY_OBJ.class_type;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertClass(object InputValue)
        {
            try
            {
                string Request = "";
                Classification POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUP_ENTITY_OBJ = MC.CLASS_LIST.Where(x => x.class_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<Classification>().Count() > 0)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<Classification>().ToList()[0];
                    }
                }
                #endregion

                if (POPUP_ENTITY_OBJ != null)
                {
                    CLASS_OBJ.class_code = POPUP_ENTITY_OBJ.class_code;
                    CLASS_OBJ.class_no = POPUP_ENTITY_OBJ.class_no;
                    CLASS_OBJ.class_name = POPUP_ENTITY_OBJ.class_name;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertObjectType(object InputValue)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUP_ENTITY_OBJ = MC.OBJECT_TYPE_LIST.Where(x => x.obj_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }
                #endregion

                if (POPUP_ENTITY_OBJ != null)
                {
                    MASTER_ENTITY.obj_type = POPUP_ENTITY_OBJ.obj_type;
                    MASTER_ENTITY.obj_type_name = POPUP_ENTITY_OBJ.obj_type_name;

                    Request = "LOAD_OBJECTS" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (REQ_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + (doc_cat_vm ?? "AA") + "!@" + (REQ_PARA_OBJ.doc_type ?? doc_cat_vm) + "!@" + MASTER_ENTITY.obj_type + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm;
                    MC_TEMP = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<ADM_M0061_MC>(MC, Request, "ADM_M0123_BL", "ADM", Request, 0, "LOAD_INI");
                    MC.OBJECT_LIST = MC_TEMP.OBJECT_LIST;
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).obj_key);
                    TheFilter = (o, prefix) => (((STD_LIST_BE)o).obj_key ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).obj_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    AS_OBJECT = new AutoSuggestTextViewModel<dynamic>(MC.OBJECT_LIST, TheFilter, SuggestedValue, "obj_key", true);
                    AS_OBJECT.AutoSuggestVM.IsEmptyValueAllowed = false; AS_OBJECT.AutoSuggestVM.IsFreeTextAllowed = false;

                    
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertObject(object InputValue)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUP_ENTITY_OBJ = MC.OBJECT_LIST.Where(x => x.obj_key.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }
                #endregion

                if (POPUP_ENTITY_OBJ != null)
                {
                    MASTER_ENTITY.obj_key = POPUP_ENTITY_OBJ.obj_key;
                    MASTER_ENTITY.obj_name = POPUP_ENTITY_OBJ.obj_name;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void SelectionChanged_Profile(object InputValue)
        {
            try
            {
                if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<Classification>().ToList().Count > 0)
                    {
                        PROFILE_OBJ = ((IEnumerable)InputValue).Cast<Classification>().ToList()[0];
                    }
                }
            }
            catch (Exception ex)
            { /*sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();*/ }
        }
        private void SelectionChanged_Class(object InputValue)
        {
            try
            {
                if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<Classification>().ToList().Count > 0)
                    {
                        CLASS_OBJ = ((IEnumerable)InputValue).Cast<Classification>().ToList()[0];
                    }
                }
            }
            catch (Exception ex)
            { /*sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();*/ }
        }
        
        private void LoadBackFlipData(object para)
        {
            string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (REQ_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + (REQ_PARA_OBJ.doc_type ?? doc_cat_vm) + "!@" + (REQ_PARA_OBJ.active_code ?? "").ToString() + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy") + "!@" + AppSessionState.UserID + "!@" + REQ_PARA_OBJ.party_code + "!@" + REQ_PARA_OBJ.t_status;
            MC_TEMP = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<Classification_MC>(MC_TEMP, Request, "ADM_M0121_BL", "ADM", "", 0, "");

            BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC_TEMP.BACK_FLIP_LIST);
            BACKFLIP_COLLECTION.Filter = new Predicate<object>(FLTR_BACKFLIP);
            //BACKFLIP_COLLECTION.Refresh();
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                string ParametersStringValue = "";
                STD_LIST_BE ParameterEntityObject = null;
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    ParametersStringValue = ParameterObject.ToString().Trim();
                    if (ParametersStringValue.Length > 0)
                    {
                        if (ParametersStringValue == "ReferenceDocument")
                        {
                        }
                    }
                }
                else if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList()[0];
                        Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + ParameterEntityObject.class_no;
                        MC_TEMP = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<Classification_MC>(MC_TEMP, Request, "ADM_M0121_BL", "ADM", Request, 0, "LOAD_DOC_BY_DOC_NO");
                    }
                }
                EntityChangeEnable = false;

                if (MC_TEMP.MASTER_LIST != null)
                {
                    if (MC_TEMP.MASTER_LIST.Count > 0)
                    {
                        MASTER_ENTITY = MC_TEMP.MASTER_LIST[0];

                        if (MC_TEMP.OBJECT_CLASS_LIST != null)
                        {
                            if (MC_TEMP.CHAR_VALUE_OBV_LIST.Count > 0)
                            {
                                CLASS_VALUES.Clear();
                                CLASS_VALUES = MC_TEMP.OBJECT_CLASS_LIST;
                            }
                            else
                            {
                                CLASS_VALUES = new ObservableCollection<Classification>();
                            }
                        }
                        if (MC_TEMP.PROFILE_LIST != null)
                        {
                            if (MC_TEMP.PROFILE_LIST.Count > 0)
                            {
                                PROFILE_VALUES.Clear();
                                PROFILE_VALUES = MC_TEMP.PROFILE_LIST;
                            }
                            else
                            {
                                PROFILE_VALUES = new ObservableCollection<Classification>();
                            }
                        }
                    }
                }

                NewRecord = false;
                MainTabIndex = 0;
                EntityChangeEnable = false;
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        #endregion

        #region User Defined Functions
        public ADM_M0021_VM(string ts_code) : base()
        {
            sms = GetViewService<IShowMessageViewService>();
            ts_code_vm = ts_code;
            //doc_cat_vm = doc_cat_vm;
            MASTER_ENTITY = new Classification();
            CLASS_VALUES = new ObservableCollection<Classification>();
            CLASS_OBJ = new Classification();
            //Classification.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Master);
            //ADM_M0061_A.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Item);
            CLASS_VALUES.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForClassValues);

            PROFILE_VALUES = new ObservableCollection<Classification>();
            PROFILE_OBJ = new Classification();
            //Classification.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Master);
            //ADM_M0061_A.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Item);
            PROFILE_VALUES.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForProfile);

            MC_TEMP = new Classification_MC();
            MC = new Classification_MC();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            REQ_PARA_OBJ.from_date = DateTime.Now.Date;
            REQ_PARA_OBJ.to_date = DateTime.Now.Date;
            CommandInitialisation();
            LoadInitialData();
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (REQ_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + (doc_cat_vm ?? "AA") + "!@" + (REQ_PARA_OBJ.doc_type ?? doc_cat_vm) + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm;
                MC = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<ADM_M0061_MC>(MC, Request, "ADM_M0123_BL", "ADM", Request, 0, "LOAD_INI");


                #region AutoSuggest Initialization

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((Classification)x).class_type);
                TheFilter = (o, prefix) => ((Classification)o).class_type.ToLower().Contains(prefix.ToLower());
                AS_DEFAULT = new AutoSuggestTextViewModel<dynamic>(MC.CLASS_TYPE_LIST, TheFilter, SuggestedValue, "class_type", true);
                AS_DEFAULT.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                TheFilter = (o, prefix) => ((ADM_M0013)o).t_status.ToLower().Contains(prefix.ToLower()) || ((ADM_M0013)o).t_display.ToLower().Contains(prefix.ToLower());
                AS_STATUS = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_status", true);
                AS_STATUS.AutoSuggestVM.IsEmptyValueAllowed = false; AS_STATUS.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).obj_type);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).obj_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).obj_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_OBJECT_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.OBJECT_TYPE_LIST, TheFilter, SuggestedValue, "obj_type", true);
                AS_OBJECT_TYPE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_OBJECT_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((Classification)x).class_type);
                TheFilter = (o, prefix) => (((Classification)o).class_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((Classification)o).short_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_CLASS_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.CLASS_TYPE_LIST, TheFilter, SuggestedValue, "class_type", true);
                AS_CLASS_TYPE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_CLASS_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).obj_key);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).obj_key ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).obj_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_OBJECT = new AutoSuggestTextViewModel<dynamic>(MC.OBJECT_LIST, TheFilter, SuggestedValue, "obj_key", true);
                AS_OBJECT.AutoSuggestVM.IsEmptyValueAllowed = false; AS_OBJECT.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((Classification)x).class_code);
                TheFilter = (o, prefix) => (((Classification)o).class_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((Classification)o).class_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_CLASS = new AutoSuggestTextViewModel<dynamic>(MC.CLASS_LIST, TheFilter, SuggestedValue, "class_code", true);
                AS_CLASS.AutoSuggestVM.IsEmptyValueAllowed = false; AS_CLASS.AutoSuggestVM.IsFreeTextAllowed = false;


                #endregion

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
        private void CollectionChangedNotifyForClassValues(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && CLASS_VALUES.Count > 0) // Batch can only enable to add if items exists in Items Entity.
            {
                try
                {
                    foreach (Classification item in e.NewItems)
                    {
                        item.active = MASTER_ENTITY.active;
                        item.client = AppSessionState.client;
                        item.active = MASTER_ENTITY.active;
                    }
                }
                catch (Exception ex)
                { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
            }
            if (e.Action == NotifyCollectionChangedAction.Replace)
            { }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            { }
            if (e.Action == NotifyCollectionChangedAction.Move)
            { }
        }
        private void CollectionChangedNotifyForProfile(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add ) // Batch can only enable to add if items exists in Items Entity.
            {
                try
                {
                    foreach (Classification item in e.NewItems)
                    {
                        item.active = MASTER_ENTITY.active;
                        item.client = AppSessionState.client;
                        item.t_status = MASTER_ENTITY.t_status;
                    }
                }
                catch (Exception ex)
                { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
            }
            if (e.Action == NotifyCollectionChangedAction.Replace)
            { }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            { }
            if (e.Action == NotifyCollectionChangedAction.Move)
            { }
        }
        private bool Validation()
        {
            if (string.IsNullOrWhiteSpace(MASTER_ENTITY.obj_type))
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Object Type........"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MASTER_ENTITY.obj_key))
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert COnfiguration Object........"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MASTER_ENTITY.class_type))
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Class Type ...."); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MASTER_ENTITY.t_status))
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Status........"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MASTER_ENTITY.active))
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Record Active Status,Y: Active, N: Inactive, D: Deleted"); sms.ShowMessage();
                return false;
            }

            if (PROFILE_VALUES.Count < 1)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Profile Data ........"); sms.ShowMessage();
                return false;
            }
            else
            {
                // Validation for Quantity Item Duplication and Unit Code For Item Details
                foreach (var o in PROFILE_VALUES)
                {
                    if (o.profile_name != null && o.profile_name != "" && o.class_type != null)
                    {
                        int flag = 0;
                        foreach (var p in PROFILE_VALUES)
                        {
                            if (o.profile_name == p.profile_name)
                            {
                                flag++;
                            }
                        }
                        if (flag > 1)
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Cannot Save Duplicate Profile code {0} and Name {1} for Profile {2}", o.profile_name, o.profile_name, MASTER_ENTITY.class_type); sms.ShowMessage();
                            return false;
                        }
                        if (string.IsNullOrWhiteSpace(o.active))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Record Active Status at Material Level,Y: Active, N: Inactive, D: Deleted"); sms.ShowMessage();
                            return false;
                        }
                    }
                    else
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("please insert Value ........"); sms.ShowMessage();
                        return false;
                    }
                }

            }
            return true;
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
                           data.party_code != null && data.party_code.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.party_name != null && data.party_name.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
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

        #region Abstract Command Actions

        protected override void OnSaveAction(InquiryActionResult<ADM_M030> result)
        {
            try
            {
                CursorControl.SetBusyState();
                MASTER_ENTITY.XDOC_A = SERIALIZATION_OBJ.ObjectToXML(PROFILE_VALUES);
                MASTER_ENTITY.XDOC_B = SERIALIZATION_OBJ.ObjectToXML(CLASS_VALUES);
                this.MASTER_ENTITY.EndEdit();

                if (Validation() == true)
                {
                    if (NewRecord == true)
                    {
                        MASTER_ENTITY = REPOSITORY_OBJ.SaveWithReturnDomainObject<Classification>(MASTER_ENTITY, "ADM_M0123_BL", "ADM");
                    }
                    else if (NewRecord == false)
                    {
                        MASTER_ENTITY = REPOSITORY_OBJ.UpdateWithReturnDomainObject<Classification>(MASTER_ENTITY, "ADM_M0123_BL", "ADM");
                    }
                    if (MASTER_ENTITY.XDOC_A != null)
                    {
                        MC.PROFILE_LIST = (ObservableCollection<Classification>)new ObjectSerializationService().XMLToObject(MASTER_ENTITY.XDOC_A, MC.CHAR_VALUE_OBV_LIST);
                        PROFILE_VALUES.Clear();
                        PROFILE_VALUES = MC.PROFILE_LIST;
                    }
                    else
                    {
                        PROFILE_VALUES = new ObservableCollection<Classification>();
                    }
                    if (MASTER_ENTITY.XDOC_B != null)
                    {
                        MC.OBJECT_CLASS_LIST = (ObservableCollection<Classification>)new ObjectSerializationService().XMLToObject(MASTER_ENTITY.XDOC_B, MC.CHAR_VALUE_OBV_LIST);
                        CLASS_VALUES.Clear();
                        CLASS_VALUES = MC.OBJECT_CLASS_LIST;
                    }
                    else
                    {
                        CLASS_VALUES = new ObservableCollection<Classification>();
                    }
                    NewRecord = false;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void DefaultValues()
        {
            EntityChangeEnable = true;
            MASTER_ENTITY.doc_cat = doc_cat_vm;
            MASTER_ENTITY.doc_type = doc_cat_vm;
            MASTER_ENTITY.ts_code = ts_code_vm;
            MASTER_ENTITY.valid_from = DateTime.Now;
            MASTER_ENTITY.userid = AppSessionState.UserID;
            MASTER_ENTITY.session_id = AppSessionState.session_id;
            MASTER_ENTITY.active = "Y";
            MASTER_ENTITY.ind_char = "R";
            MASTER_ENTITY.ind_mv = "N";
            MASTER_ENTITY.client = AppSessionState.client;
            MASTER_ENTITY.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
            MASTER_ENTITY.t_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_display).FirstOrDefault();
            EntityChangeEnable = false;

            CLASS_OBJ = new Classification();
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M030> result)
        {
            NewRecord = true;

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M030> result)
        {
            try
            {
                //if (MasterEntity.value_code != null)
                //{
                //    this.MasterEntity.CancelEdit();
                //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //    showMessageService.ButtonSetup = DialogButton.Ok;
                //    showMessageService.Caption = "Save Changes";
                //    showMessageService.Text = String.Format("This record will delete forever", this.Title);
                //    if (showMessageService.ShowMessage() == DialogResult.Ok)
                //    {
                //        string response = repository.Delete(MasterEntity.value_code, "ParameterValueMaster", "Administration");
                //        MasterEntity = new ADM_M030();
                //        NewRecord = true;
                //    }
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
        protected override void OnDiscardAction(InquiryActionResult<ADM_M030> result)
        {
            //this.MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M030> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M030> result)
        {

            //MasterEntity = MasterEntity;
        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M030> result)
        {
            //MasterEntity = MasterEntity;
        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M030> result)
        {
            //MasterEntity = MasterEntity;
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M030> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M030> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M030> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M030> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M030> result)
        {
            throw new NotImplementedException();
        }
        #endregion



    }
}
