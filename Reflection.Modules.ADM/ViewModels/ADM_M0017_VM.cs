using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
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
using Reflection.Presentation.Controls;
using Reflection.BusinessEntity.ADM;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Common;

namespace Reflection.Modules.ADM.ViewModels
{
    public class ADM_M0017_VM : WorkspaceViewModel<ADM_M0111>
    {

        #region Variable Declaration

        WebServiceRepository<ADM_M0111> REPOSITORY_OBJ = new WebServiceRepository<ADM_M0111>();
        WebServiceRepository<ADM_M0111_MC> REPOSITORY_OBJ_TEMP = new WebServiceRepository<ADM_M0111_MC>();
        ADM_M0111_MC MC_TEMP = new ADM_M0111_MC();
        ADM_M0111_MC MC = new ADM_M0111_MC();
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

        private ADM_M0111 _MASTER_ENTITY;
        public ADM_M0111 MASTER_ENTITY
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
        private ObservableCollection<ADM_M0112> _CHAR_VALUES;
        public ObservableCollection<ADM_M0112> CHAR_VALUES
        {
            get { return _CHAR_VALUES; }
            set
            {
                if (_CHAR_VALUES != value)
                {
                    _CHAR_VALUES = value;
                    _CHAR_VALUES.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForCharValues);
                    RaisePropertyChanged("CHAR_VALUES");
                }
            }
        }

       
        private ADM_M0112 _CHAR_VALUES_OBJ;
        public ADM_M0112 CHAR_VALUES_OBJ
        {
            get
            {
                return _CHAR_VALUES_OBJ;
            }
            set
            {
                if (_CHAR_VALUES_OBJ != value)
                {
                    _CHAR_VALUES_OBJ = value;
                    RaisePropertyChanged(nameof(CHAR_VALUES_OBJ));
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

        private IEnumerable _GROUP_LIST;
        public IEnumerable GROUP_LIST
        {
            get { return _GROUP_LIST; }
            set { _GROUP_LIST = value; RaisePropertyChanged("GROUP_LIST"); }
        }
        private IEnumerable _CHAR_LIST;
        public IEnumerable CHAR_LIST
        {
            get { return _CHAR_LIST; }
            set { _CHAR_LIST = value; RaisePropertyChanged("CHAR_LIST"); }
        }
        private IEnumerable _VC_CLASS_LIST;
        public IEnumerable VC_CLASS_LIST
        {
            get { return _VC_CLASS_LIST; }
            set { _VC_CLASS_LIST = value; RaisePropertyChanged("VC_CLASS_LIST"); }
        }
        private IEnumerable _PROFILE_TYPE_LIST;
        public IEnumerable PROFILE_TYPE_LIST
        {
            get { return _PROFILE_TYPE_LIST; }
            set
            {
                _PROFILE_TYPE_LIST = value;

                RaisePropertyChanged("PROFILE_TYPE_LIST");
            }
        }
        #endregion

        #region Autosuggest Initialization

        //public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(ADM_M0017_VM));
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

                    if (SourceName == "char_value")
                    { AS_DEFAULT = AS_CHAR_VALUES; }
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
        private AutoSuggestTextViewModel<dynamic> _AS_DATA_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DATA_TYPE
        {
            get { return _AS_DATA_TYPE; }
            set
            {
                if (_AS_DATA_TYPE != value)
                {
                    _AS_DATA_TYPE = value; RaisePropertyChanged("AS_DATA_TYPE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_CHAR_VALUES { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CHAR_VALUES // Currently not in use
        {
            get { return _AS_CHAR_VALUES; }
            set
            {
                if (_AS_CHAR_VALUES != value)
                {
                    _AS_CHAR_VALUES = value; RaisePropertyChanged("AS_CHAR_VALUES");
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
        private AutoSuggestTextViewModel<dynamic> _AS_ORG { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ORG
        {
            get { return _AS_ORG; }
            set
            {
                if (_AS_ORG != value)
                {
                    _AS_ORG = value; RaisePropertyChanged("AS_ORG");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ORG_GROUP { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ORG_GROUP
        {
            get { return _AS_ORG_GROUP; }
            set
            {
                if (_AS_ORG_GROUP != value)
                {
                    _AS_ORG_GROUP = value; RaisePropertyChanged("AS_ORG_GROUP");
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

        #endregion

        #region Relay commands Declaration
        public RelayCommand<object> cmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> cmdInsertUnit { get; private set; }
        public RelayCommand<object> cmdDataGridRowDelete { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_CharValue { get; private set; }
        public RelayCommand<object> cmdInsertStatus { get; private set; }
        public RelayCommand<object> cmdInsertDataType { get; private set; }

        private void CommandInitialisation()
        {
            cmdInsertUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOM(cmdPara, false, true, true); });
            cmdDataGridRowDelete = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow_Item(items); });
            cmdSelectionChanged_CharValue = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChangedCharValue(items); });
            cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
            cmdLoadBackFlip = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdInsertStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertStatus(items); });
            cmdInsertDataType = new RelayCommand<object>(items => { if (items == null) { return; } InsertDataType(items); });
        }

        #endregion

        #region Command Implementation

        private void InsertUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                UOMS POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUP_ENTITY_OBJ = MC.UOM_LIST.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<UOMS>().ToList()[0];
                    }
                }
                #endregion

                if (POPUP_ENTITY_OBJ != null)
                {
                    MASTER_ENTITY.unit_code = POPUP_ENTITY_OBJ.unit_code;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (CHAR_VALUES.Count > i && string.IsNullOrWhiteSpace(CHAR_VALUES_OBJ.char_code))
                {
                    CHAR_VALUES.RemoveAt(i);
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
        private void InsertDataType(object InputValue)
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
                            POPUP_ENTITY_OBJ = MC.DATA_TYPE_LIST.Where(x => x.data_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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
                    MASTER_ENTITY.data_type = POPUP_ENTITY_OBJ.data_type;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void SelectionChangedCharValue(object InputValue)
        {
            try
            {
                if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M0112>().ToList().Count > 0)
                    {
                        CHAR_VALUES_OBJ = ((IEnumerable)InputValue).Cast<ADM_M0112>().ToList()[0];
                        CHAR_VALUES_OBJ.selected = true;
                    }
                }
            }
            catch (Exception ex)
            { /*sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();*/ }
        }
        private void LoadBackFlipData(object para)
        {
            string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (REQ_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + (REQ_PARA_OBJ.doc_type ?? doc_cat_vm) + "!@" + (REQ_PARA_OBJ.active_code ?? "").ToString() + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy") + "!@" + AppSessionState.UserID + "!@" + REQ_PARA_OBJ.party_code + "!@" + REQ_PARA_OBJ.t_status;
            MC_TEMP = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<ADM_M0111_MC>(MC_TEMP, Request, "ADM_M0111_BL", "ADM", "", 0, "");

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
                        Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + ParameterEntityObject.int_char + "!@" + ParameterEntityObject.char_code;
                        MC_TEMP = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<ADM_M0111_MC>(MC_TEMP, Request, "ADM_M0111_BL", "ADM", Request, 0, "LOAD_DOC_BY_DOC_NO");
                    }
                }
                EntityChangeEnable = false;

                if (MC_TEMP.MASTER_LIST != null)
                {
                    if (MC_TEMP.MASTER_LIST.Count > 0)
                    {
                        MASTER_ENTITY = MC_TEMP.MASTER_LIST[0];

                        if (MC_TEMP.CHAR_VALUE_OBV_LIST != null)
                        {
                            if (MC_TEMP.CHAR_VALUE_OBV_LIST.Count > 0)
                            {
                                CHAR_VALUES.Clear();
                                CHAR_VALUES = MC_TEMP.CHAR_VALUE_OBV_LIST;
                            }
                            else
                            {
                                CHAR_VALUES = new ObservableCollection<ADM_M0112>();
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
        public ADM_M0017_VM(string ts_code) : base()
        {
            sms = GetViewService<IShowMessageViewService>();
            ts_code_vm = ts_code;
            //doc_cat_vm = doc_cat_vm;
            MASTER_ENTITY = new ADM_M0111();
            CHAR_VALUES = new ObservableCollection<ADM_M0112>();
            CHAR_VALUES_OBJ = new ADM_M0112();
            //ADM_M0111.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Master);
            //ADM_M0112.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Item);
            CHAR_VALUES.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForCharValues);
            MC_TEMP = new ADM_M0111_MC();
            MC = new ADM_M0111_MC();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            REQ_PARA_OBJ.from_date = DateTime.Now.Date;
            REQ_PARA_OBJ.to_date = DateTime.Now.Date;
            REQ_PARA_OBJ.active_code = "Y";
            CommandInitialisation();
            LoadInitialData();
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (REQ_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + (doc_cat_vm ?? "AA") + "!@" + (REQ_PARA_OBJ.doc_type ?? doc_cat_vm) + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm;
                MC = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<ADM_M0111_MC>(MC, Request, "ADM_M0111_BL", "ADM", Request, 0, "LOAD_INI");

                GROUP_LIST = MC.GROUP_LIST;
                CHAR_LIST = MC.KEY_DATA_LIST;
                VC_CLASS_LIST = MC.VC_CLASS_LIST;
                PROFILE_TYPE_LIST = MC.ProfileTypeList;

                #region AutoSuggest Initialization

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => ((UOMS)o).unit_code.ToLower().Contains(prefix.ToLower());
                AS_DEFAULT = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                AS_DEFAULT.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => ((UOMS)o).unit_code.ToLower().Contains(prefix.ToLower()) || ((UOMS)o).unit_name.ToLower().Contains(prefix.ToLower());
                AS_UOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                TheFilter = (o, prefix) => ((ADM_M0013)o).t_status.ToLower().Contains(prefix.ToLower()) || ((ADM_M0013)o).t_display.ToLower().Contains(prefix.ToLower());
                AS_STATUS = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_status", true);
                AS_STATUS.AutoSuggestVM.IsEmptyValueAllowed = false; AS_STATUS.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).data_type);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).data_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).short_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_DATA_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.DATA_TYPE_LIST, TheFilter, SuggestedValue, "data_type", true);
                AS_DATA_TYPE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_DATA_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).value_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).value_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).value_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_OBJ_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.VALUE_LIST, TheFilter, SuggestedValue, "data_type", true);
                AS_OBJ_TYPE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_OBJ_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M037)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_CURRENCY = new AutoSuggestTextViewModel<dynamic>(MC.CURRENCY_LIST, TheFilter, SuggestedValue, "curr_code", true);
                AS_CURRENCY.AutoSuggestVM.IsEmptyValueAllowed = false; AS_CURRENCY.AutoSuggestVM.IsFreeTextAllowed = false;

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
        private void CollectionChangedNotifyForCharValues(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && CHAR_VALUES.Count > 0) // Batch can only enable to add if items exists in Items Entity.
            {
                try
                {
                    foreach (ADM_M0112 item in e.NewItems)
                    {
                        item.active = MASTER_ENTITY.active;
                        item.client = AppSessionState.client;
                        //item.curr_code = MASTER_ENTITY.curr_code;
                        item.active = MASTER_ENTITY.active;
                        item.selected = true;
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
            if (string.IsNullOrWhiteSpace(MASTER_ENTITY.char_code))
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Characteristic........"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MASTER_ENTITY.char_name))
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Characteristic Description........"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MASTER_ENTITY.t_status))
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Status........"); sms.ShowMessage();
                return false;
            }
            //if (string.IsNullOrWhiteSpace(MASTER_ENTITY.unit_code))
            //{
            //    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Unit......"); sms.ShowMessage();
            //    return false;
            //}
            if (string.IsNullOrWhiteSpace(MASTER_ENTITY.active))
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Record Active Status,Y: Active, N: Inactive, D: Deleted"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MASTER_ENTITY.data_type))
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Data Type for Characteristics...."); sms.ShowMessage();
                return false;
            }
            // Validation for Quantity Item Duplication and Unit Code For Item Details
            foreach (var o in CHAR_VALUES)
            {
                if (!string.IsNullOrWhiteSpace(o.char_value)) // != null && o.char_value != "" && o.long_text != null
                {
                    int flag = 0;
                    foreach (var p in CHAR_VALUES)
                    {
                        if (o.char_value == p.char_value)
                        {
                            flag++;
                        }
                    }
                    if (flag > 1)
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Cannot Save Duplicate Char Value {0} and Name {1} for Characteristic {2}", o.char_code, o.char_name, MASTER_ENTITY.char_code); sms.ShowMessage();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(o.active))
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Record Active Status at Material Level,Y: Active, N: Inactive, D: Deleted"); sms.ShowMessage();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(o.char_value))
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Value "); sms.ShowMessage();
                        return false;
                    }
                    //if (string.IsNullOrWhiteSpace(o.long_text))
                    //{
                    //    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Enter Char Value for {0} and Description {1}", o.char_value, o.long_text); sms.ShowMessage();
                    //    return false;
                    //}
                }
                else
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("please insert Value ........"); sms.ShowMessage();
                    return false;
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
                    return (data.char_code != null && data.char_code.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.char_name != null && data.char_name.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.char_group != null && data.char_group.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.char_type != null && data.char_type.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.text_name != null && data.text_name.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.group_name != null && data.group_name.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                           data.t_display != null && data.t_display.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower())
                       );
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Abstract Command Actions
       
        protected override void OnSaveAction(InquiryActionResult<ADM_M0111> result)
        {
            try
            {
                CursorControl.SetBusyState();
                MASTER_ENTITY.XDOC_A = SERIALIZATION_OBJ.ObjectToXML(CHAR_VALUES.Where(x=> x.selected == true).ToList());
                this.MASTER_ENTITY.EndEdit();

                if (Validation() == true)
                {
                    if (NewRecord == true)
                    {
                        MASTER_ENTITY = REPOSITORY_OBJ.SaveWithReturnDomainObject<ADM_M0111>(MASTER_ENTITY, "ADM_M0111_BL", "ADM");
                    }
                    else if (NewRecord == false)
                    {
                        MASTER_ENTITY = REPOSITORY_OBJ.UpdateWithReturnDomainObject<ADM_M0111>(MASTER_ENTITY, "ADM_M0111_BL", "ADM");
                    }
                    if (MASTER_ENTITY.XDOC_A != null)
                    {
                        MC.CHAR_VALUE_OBV_LIST = (ObservableCollection<ADM_M0112>)new ObjectSerializationService().XMLToObject(MASTER_ENTITY.XDOC_A, MC.CHAR_VALUE_OBV_LIST);
                        CHAR_VALUES.Clear();
                        CHAR_VALUES = MC.CHAR_VALUE_OBV_LIST;
                    }
                    else
                    {
                        CHAR_VALUES = new ObservableCollection<ADM_M0112>();
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
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M0111> result)
        {
            NewRecord = true;
            MASTER_ENTITY = new ADM_M0111();
            CHAR_VALUES = new ObservableCollection<ADM_M0112>();
            CHAR_VALUES_OBJ = new ADM_M0112();
            CHAR_VALUES.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForCharValues);
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M0111> result)
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
                //        MasterEntity = new ADM_M0111();
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
        protected override void OnDiscardAction(InquiryActionResult<ADM_M0111> result)
        {
            //this.MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M0111> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M0111> result)
        {

            //MasterEntity = MasterEntity;
        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M0111> result)
        {
            //MasterEntity = MasterEntity;
        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M0111> result)
        {
            //MasterEntity = MasterEntity;
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M0111> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M0111> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M0111> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M0111> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M0111> result)
        {
            throw new NotImplementedException();
        }
        #endregion



    }
}
