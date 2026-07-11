using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.ReportingServices;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services.Convertors;
using System.Collections.Specialized;
using System.Windows;
using Reflection.BusinessEntity.MM;
using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.PPC;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.Account;

namespace Reflection.Modules.PRO.ViewModels
{
    public class PRO_M0007_VM : WorkspaceViewModel<ADM_M0061>
    {
        #region Variable Declaration

        bool NewRecord = true;
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PRO_M0007_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        WebServiceRepository<ADM_M0061> REPOSITORY_OBJ = new WebServiceRepository<ADM_M0061>();
        WebServiceRepository<ADM_M0061_MC> REPOSITORY_OBJ_TEMP = new WebServiceRepository<ADM_M0061_MC>();
        ADM_M0061_MC MC_TEMP = new ADM_M0061_MC();
        ADM_M0061_MC MC = new ADM_M0061_MC();
        ObjectSerializationService SERIALIZATION_OBJ = new ObjectSerializationService();
        IShowMessageViewService sms;
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

        private ADM_M0061 _MasterEntity;
        public ADM_M0061 MasterEntity
        {
            get
            {
                return _MasterEntity;
            }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged(nameof(MasterEntity));
                    value.BeginEdit();
                }
            }
        }
        private ObservableCollection<ADM_M0061_A> _ItemsEntity;
        public ObservableCollection<ADM_M0061_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value;
                    _ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("ItemsEntity");
                }
            }
        }

        private List<ADM_M031_P> _SelectedParaValueCollection = new List<ADM_M031_P>();
        public List<ADM_M031_P> SelectedParaValueCollection
        {
            get { return _SelectedParaValueCollection; }
            set
            {
                if (_SelectedParaValueCollection != value)
                {
                    _SelectedParaValueCollection = value;
                    RaisePropertyChanged("SelectedParaValueCollection");
                }
            }
        }
        private ADM_M0061_A _ITEM_ENTITY_OBJ;
        public ADM_M0061_A ITEM_ENTITY_OBJ
        {
            get
            {
                return _ITEM_ENTITY_OBJ;
            }
            set
            {
                if (_ITEM_ENTITY_OBJ != value)
                {
                    _ITEM_ENTITY_OBJ = value;
                    RaisePropertyChanged(nameof(ITEM_ENTITY_OBJ));
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
        #region Dictionary
        private Dictionary<string, object> _taxDictonery;
        // Tax Popup Data Source
        public Dictionary<string, object> TaxDictonery
        {
            get { return _taxDictonery; }
            set
            {
                if (_taxDictonery != value)
                {
                    _taxDictonery = value;
                    RaisePropertyChanged("TaxDictonery");
                }
            }
        }
        private Dictionary<string, object> _taxDictoneryParent;
        //Parant Tax List data Source for Popup
        public Dictionary<string, object> TaxDictoneryParent
        {
            get { return _taxDictoneryParent; }
            set
            {
                if (_taxDictoneryParent != value)
                {
                    _taxDictoneryParent = value;
                    RaisePropertyChanged("TaxDictoneryParent");
                }
            }
        }

        private List<ACC_M013> _SelectedTaxList;
        // Supporting for Filter Data Source for Parent Taxes. * can be remove.
        public List<ACC_M013> SelectedTaxList
        {
            get { return _SelectedTaxList; }
            set
            {
                if (_SelectedTaxList != value)
                {
                    _SelectedTaxList = value;
                    RaisePropertyChanged("SelectedTaxList");
                }
            }
        }
        #endregion

        #region Autosuggest Initialization

        //public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PRO_M0007_VM));
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

                    if (SourceName == "item_code")
                    { AS_DEFAULT = AS_ITEM; }
                    else if (SourceName == "unit_code")
                    { AS_DEFAULT = AS_UOM; }
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

        private AutoSuggestTextViewModel<dynamic> _AS_PARTY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PARTY
        {
            get { return _AS_PARTY; }
            set
            {
                if (_AS_PARTY != value)
                {
                    _AS_PARTY = value; RaisePropertyChanged("AS_PARTY");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_ITEM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ITEM
        {
            get { return _AS_ITEM; }
            set
            {
                if (_AS_ITEM != value)
                {
                    _AS_ITEM = value; RaisePropertyChanged("AS_ITEM");
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

        #region ICollection

        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }
        private ICollectionView _ITEM_COLLECTION;
        public ICollectionView ITEM_COLLECTION
        {
            get { return _ITEM_COLLECTION; }
            set { _ITEM_COLLECTION = value; RaisePropertyChanged("ITEM_COLLECTION"); }
        }

        #endregion

        #region RelayCommand
        public RelayCommand<object> cmdInsertMaterial { get; private set; }
        public RelayCommand<object> cmdInsertUnit { get; private set; }
        public RelayCommand<object> cmdDataGridRowDelete { get; private set; }
        public RelayCommand<object> cmdSelectionChangedItem { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInsertParty { get; private set; }
        public RelayCommand<object> cmdInsertOrgGroup { get; private set; }
        #endregion

        #region . Constructor .
        public PRO_M0007_VM(string doc_cat, string ts_code)
            : base()
        {
            sms = GetViewService<IShowMessageViewService>();
            ts_code_vm = ts_code;
            doc_cat_vm = doc_cat;
            MasterEntity = new ADM_M0061();
            ItemsEntity = new ObservableCollection<ADM_M0061_A>();
            ITEM_ENTITY_OBJ = new ADM_M0061_A();
            ADM_M0061.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Master);
            ADM_M0061_A.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Item);
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            MC_TEMP = new ADM_M0061_MC();
            MC = new ADM_M0061_MC();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            REQ_PARA_OBJ.from_date = DateTime.Now.Date;
            REQ_PARA_OBJ.to_date = DateTime.Now.Date;
            CommandInitialisation();
        }
        public PRO_M0007_VM(string doc_cat, string ts_code, string doc_no)
            : base()
        {
            ts_code_vm = ts_code;
            doc_cat_vm = doc_cat;
            doc_no_vm = doc_no;
            sms = GetViewService<IShowMessageViewService>();
            ts_code_vm = ts_code;
            doc_cat_vm = doc_cat;
            MasterEntity = new ADM_M0061();
            ItemsEntity = new ObservableCollection<ADM_M0061_A>();
            ITEM_ENTITY_OBJ = new ADM_M0061_A();
            ADM_M0061.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Master);
            ADM_M0061_A.ModelEntityUpdated += new EventHandler(ModelChangeNotification_Item);
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            MC_TEMP = new ADM_M0061_MC();
            MC = new ADM_M0061_MC();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            REQ_PARA_OBJ.from_date = DateTime.Now.Date;
            REQ_PARA_OBJ.to_date = DateTime.Now.Date;
            CommandInitialisation();

        }

        #endregion

        #region Command Functions

        private void SelectionChangedItem(object InputValue)
        {
            try
            {
                if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M0061_A>().ToList().Count > 0)
                    {
                        ITEM_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<ADM_M0061_A>().ToList()[0];
                    }
                }
            }
            catch (Exception ex)
            { /*sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();*/ }
        }
        private void LoadBackFlipData(object para)
        {
            string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + (REQ_PARA_OBJ.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (REQ_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + (REQ_PARA_OBJ.doc_type ?? doc_cat_vm) + "!@" + (REQ_PARA_OBJ.active_code ?? "").ToString() + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy") + "!@" + AppSessionState.UserID + "!@" + REQ_PARA_OBJ.party_code + "!@" + REQ_PARA_OBJ.t_status;
            MC_TEMP = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<ADM_M0061>(MC_TEMP, Request, "ADM_M0061_BL", "ADM", "", 0, "");

            BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC_TEMP.BACK_FLIP_LIST);
            BACKFLIP_COLLECTION.Filter = new Predicate<object>(FLTR_BACKFLIP);
            //BACKFLIP_COLLECTION.Refresh();
        }
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
                    ITEM_ENTITY_OBJ.unit_code = POPUP_ENTITY_OBJ.unit_code;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertMaterial(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify) // NOTE: do not allow to add Material without MasterEntity fields like comp_code,Location etc.
        {
            try
            {
                string Request = "";
                STD_ITEM POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUP_ENTITY_OBJ = MC.STD_ITEM_LIST.Where(x => x.item_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_ITEM>().Count() > 0)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<STD_ITEM>().ToList()[0];
                    }
                }
                #endregion
                if (POPUP_ENTITY_OBJ != null && ITEM_ENTITY_OBJ != null) // Only enter in the code block if ENtity Not null.
                {
                    ITEM_ENTITY_OBJ.item_code = POPUP_ENTITY_OBJ.item_code;
                    ITEM_ENTITY_OBJ.item_name = POPUP_ENTITY_OBJ.item_name;
                    ITEM_ENTITY_OBJ.unit_code = POPUP_ENTITY_OBJ.unit_code;
                    ITEM_ENTITY_OBJ.ind_sku = Convert.ToBoolean(POPUP_ENTITY_OBJ.ind_sku);
                    ITEM_ENTITY_OBJ.active = "Y";
                    ITEM_ENTITY_OBJ.comp_code = MasterEntity.comp_code;
                    ITEM_ENTITY_OBJ.client = AppSessionState.client;
                    ITEM_ENTITY_OBJ.t_status = MasterEntity.t_status;
                    ITEM_ENTITY_OBJ.unit_price = POPUP_ENTITY_OBJ.purchase_price;
                    ITEM_ENTITY_OBJ.purchase_price = POPUP_ENTITY_OBJ.purchase_price;

                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertParty(object InputValue)
        {
            try
            {
                string Request = "";
                STD_PARTY POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUP_ENTITY_OBJ = MC.PARTY_LIST.Where(x => x.party_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_PARTY>().Count() > 0)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                    }
                }
                #endregion

                if (POPUP_ENTITY_OBJ != null)
                {
                    MasterEntity.party_code = POPUP_ENTITY_OBJ.party_code;
                    MasterEntity.party_name = POPUP_ENTITY_OBJ.party_name;
                    MasterEntity.obj_type = "P";
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertOrgGroup(object InputValue)
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
                            POPUP_ENTITY_OBJ = MC.ORG_GROUP_LIST.Where(x => x.group_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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
                    MasterEntity.group_code = POPUP_ENTITY_OBJ.group_code;
                    MasterEntity.group_name = POPUP_ENTITY_OBJ.group_name;
                    MasterEntity.org_code = POPUP_ENTITY_OBJ.org_code;
                    MasterEntity.org_name = POPUP_ENTITY_OBJ.org_name;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        #endregion

        #region Change Notification
        void ModelChangeNotification_Master(object sender, EventArgs e)
        {
            try
            {
                if (EntityChangeEnable == true)
                {
                    //if (sender.ToString() == "comp_code") // AS_LOCATION as per comp_code logic shift to InserCompany Function
                    //{
                    //    List<STD_LIST_BE> ORG_LIST_OBJ = MC.ORG_LIST.Where(item => item.comp_code == MasterEntity.comp_code).ToList();
                    //    SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).org_code);
                    //    TheFilter = (o, prefix) => (((STD_LIST_BE)o).org_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).org_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    //    AS_ORG = new AutoSuggestTextViewModel<dynamic>(ORG_LIST_OBJ, TheFilter, SuggestedValue, "org_code", true);
                    //    AS_ORG.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ORG.AutoSuggestVM.IsFreeTextAllowed = false;
                    //    if (ORG_LIST_OBJ.Count == 1)
                    //    {
                    //        MasterEntity.org_code = ORG_LIST_OBJ[0].org_code;
                    //        MasterEntity.org_name = ORG_LIST_OBJ[0].org_name;
                    //    }
                    //}
                    //if (sender.ToString() == "org_code")
                    //{
                    //    List<STD_LIST_BE> GROUP_LIST_OBJ = MC.ORG_GROUP_LIST.Where(item => item.org_code == MasterEntity.org_code).ToList();
                    //    SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).sg_code);
                    //    TheFilter = (o, prefix) => (((STD_LIST_BE)o).group_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).group_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    //    AS_ORG_GROUP = new AutoSuggestTextViewModel<dynamic>(GROUP_LIST_OBJ, TheFilter, SuggestedValue, "group_code", true);
                    //    AS_ORG_GROUP.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ORG_GROUP.AutoSuggestVM.IsFreeTextAllowed = false;
                    //    if (GROUP_LIST_OBJ.Count == 1)
                    //    {
                    //        MasterEntity.group_code = GROUP_LIST_OBJ[0].group_code;
                    //        MasterEntity.group_name = GROUP_LIST_OBJ[0].group_name;
                    //    }
                    //}

                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        void ModelChangeNotification_Item(object sender, EventArgs e)
        {
            try
            {
                if (EntityChangeEnable == true)
                {
                    if (sender.ToString() == "comp_code") // AS_LOCATION as per comp_code logic shift to InserCompany Function
                    {
                    }

                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }

        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && ItemsEntity.Count > 0) // Batch can only enable to add if items exists in Items Entity.
            {
                try
                {
                    foreach (ADM_M0061_A item in e.NewItems)
                    {
                        item.active = MasterEntity.active;
                        item.client = AppSessionState.client;
                        item.comp_code = MasterEntity.comp_code;
                        item.curr_code = MasterEntity.curr_code;
                        item.price_date = MasterEntity.price_date;
                        item.validity_date = MasterEntity.validity_date;
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

        #endregion

        #region . User Defined Function.
        private void CommandInitialisation()
        {
            cmdInsertMaterial = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertMaterial(cmdPara, true, true, true); });
            cmdInsertUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOM(cmdPara, false, true, true); });
            cmdDataGridRowDelete = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow_Item(items); });
            cmdSelectionChangedItem = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChangedItem(items); });
            cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
            cmdLoadBackFlip = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdInsertParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items); });
            cmdInsertOrgGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertOrgGroup(items); });
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + (MasterEntity.doc_type ?? doc_cat_vm) + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm;
                MC = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<ADM_M0061_MC>(MC, Request, "ADM_M0061_BL", "ADM", Request, 0, "LOAD_INI");

                #region AutoSuggest Initialization

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => ((UOMS)o).unit_code.ToLower().Contains(prefix.ToLower());
                AS_DEFAULT = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "item_code", true);
                AS_DEFAULT.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code);
                TheFilter = (o, prefix) => ((STD_ITEM)o).item_code.ToLower().Contains(prefix.ToLower()) || ((STD_ITEM)o).item_name.ToLower().Contains(prefix.ToLower());
                AS_ITEM = new AutoSuggestTextViewModel<dynamic>(MC.STD_ITEM_LIST, TheFilter, SuggestedValue, "item_code", "item_code", true);
                AS_ITEM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ITEM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).party_code);
                TheFilter = (o, prefix) => (((STD_PARTY)o).party_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).party_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_PARTY = new AutoSuggestTextViewModel<dynamic>(MC.PARTY_LIST, TheFilter, SuggestedValue, "party_code", true);
                AS_PARTY.AutoSuggestVM.IsEmptyValueAllowed = false; AS_PARTY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                TheFilter = (o, prefix) => ((ADM_M0002)o).comp_code.ToLower().Contains(prefix.ToLower()) || ((ADM_M0002)o).comp_name.ToLower().Contains(prefix.ToLower());
                AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", "comp_code", true);
                AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = false; AS_COMPANY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => ((UOMS)o).unit_code.ToLower().Contains(prefix.ToLower()) || ((UOMS)o).unit_name.ToLower().Contains(prefix.ToLower());
                AS_UOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                AS_UOM.AutoSuggestVM.IsEmptyValueAllowed = false; AS_UOM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                TheFilter = (o, prefix) => ((ADM_M0013)o).t_status.ToLower().Contains(prefix.ToLower()) || ((ADM_M0013)o).t_display.ToLower().Contains(prefix.ToLower());
                AS_STATUS = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_status", true);
                AS_STATUS.AutoSuggestVM.IsEmptyValueAllowed = false; AS_STATUS.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M037)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_CURRENCY = new AutoSuggestTextViewModel<dynamic>(MC.CURRENCY_LIST, TheFilter, SuggestedValue, "curr_code", true);
                AS_CURRENCY.AutoSuggestVM.IsEmptyValueAllowed = false; AS_CURRENCY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).group_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).group_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).group_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ORG_GROUP = new AutoSuggestTextViewModel<dynamic>(MC.ORG_GROUP_LIST, TheFilter, SuggestedValue, "group_code", true);
                AS_ORG_GROUP.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ORG_GROUP.AutoSuggestVM.IsFreeTextAllowed = false;
                if (MC.ORG_GROUP_LIST.Count == 1)
                {
                    MasterEntity.group_code = MC.ORG_GROUP_LIST[0].group_code;
                    MasterEntity.group_name = MC.ORG_GROUP_LIST[0].group_name;
                    MasterEntity.org_code = MC.ORG_GROUP_LIST[0].org_code;
                    MasterEntity.org_name = MC.ORG_GROUP_LIST[0].org_name;
                }

                var TaxListParent = (from o in MC.TAX_LIST where o.parent_id == null select o).ToList();
                SelectedTaxList = TaxListParent;
                TaxDictoneryParent = SelectedTaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).value_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).value_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).value_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_OBJ_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.STANDARD_LIST, TheFilter, SuggestedValue, "value_code", true);
                AS_OBJ_TYPE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_OBJ_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                #endregion

            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
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
                        Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + (REQ_PARA_OBJ.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (REQ_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + (REQ_PARA_OBJ.doc_type ?? doc_cat_vm) + "!@" + ParameterEntityObject.doc_no;
                        MC_TEMP = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<MC_MM_T001>(MC_TEMP, Request, "ADM_M0061_BL", "ADM", Request, 0, "LOAD_DOC_BY_DOC_NO");
                    }
                }
                EntityChangeEnable = false;

                if (MC_TEMP.MASTER_ENTITY_LIST != null)
                {
                    if (MC_TEMP.MASTER_ENTITY_LIST.Count > 0)
                    {
                        MasterEntity = MC_TEMP.MASTER_ENTITY_LIST[0];

                        if (MC_TEMP.ITEM_ENTITY_LIST != null)
                        {
                            if (MC_TEMP.ITEM_ENTITY_LIST.Count > 0)
                            {
                                ItemsEntity.Clear();
                                ItemsEntity = MC_TEMP.ITEM_ENTITY_LIST;
                            }
                            else
                            {
                                ItemsEntity = new ObservableCollection<ADM_M0061_A>();
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
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i && ITEM_ENTITY_OBJ.id == 0)
                {
                    ItemsEntity.RemoveAt(i);
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
                    LoadInitialData();
                    DefaultValues();
                }
                
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void DefaultValues()
        {
            EntityChangeEnable = true;
            MasterEntity.doc_cat = doc_cat_vm;
            MasterEntity.doc_type = doc_cat_vm;
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.location_id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.active = "Y";
            MasterEntity.obj_type = "P";
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
            MasterEntity.t_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_display).FirstOrDefault();
            EntityChangeEnable = false;
        }
        private bool Validation()
        {
            if (string.IsNullOrWhiteSpace(MasterEntity.comp_code))//when form is blank and we save the record
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Company........"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.curr_code))
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Currency........"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.t_status))
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Status........"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.active))
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Record Active Status,Y: Active, N: Inactive, D: Deleted"); sms.ShowMessage();
                return false;
            }
            if (ItemsEntity.Count < 1)//when form is blank and we save the record
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Item........"); sms.ShowMessage();
                return false;
            }
            else
            {
                // Validation for Quantity Item Duplication and Unit Code For Item Details
                foreach (var o in ItemsEntity)
                {
                    if (o.item_code != null && o.item_code != "" && o.item_name != null)
                    {
                        int flag = 0; //duplicate entry is allowed so commented : pending delete
                        if (o.id == 0)
                        {
                            foreach (var p in ItemsEntity)
                            {
                                if (o.item_code == p.item_code && o.sku == p.sku)
                                {
                                    flag++;
                                }
                            }
                            if (flag > 1)
                            {
                                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1} and machine {2}", o.item_code, o.item_name, o.item_code); sms.ShowMessage();
                                return false;
                            }
                        }
                        if (string.IsNullOrWhiteSpace(o.active))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Record Active Status at Material Level,Y: Active, N: Inactive, D: Deleted"); sms.ShowMessage();
                            return false;
                        }
                        if (string.IsNullOrWhiteSpace(o.item_code))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Material "); sms.ShowMessage();
                            return false;
                        }
                        if (string.IsNullOrWhiteSpace(o.unit_code))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Enter Valid Unit Code for the item {0} and Parameter {1}", o.item_code, o.item_name); sms.ShowMessage();
                            return false;
                        }
                    }
                    else
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("please select Item ........"); sms.ShowMessage();
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

        #region Abstract Commands

        protected override void OnSaveAction(InquiryActionResult<ADM_M0061> result)
        {
            try
            {
                CursorControl.SetBusyState();
                MasterEntity.XDOC_A = SERIALIZATION_OBJ.ObjectToXML(ItemsEntity);
                this.MasterEntity.EndEdit();

                if (Validation() == true)
                {
                    if (NewRecord == true)
                    {
                        MasterEntity = REPOSITORY_OBJ.SaveWithReturnDomainObject<ADM_M0061>(MasterEntity, "ADM_M0061_BL", "ADM");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = REPOSITORY_OBJ.UpdateWithReturnDomainObject<ADM_M0061>(MasterEntity, "ADM_M0061_BL", "ADM");
                    }
                    if (MasterEntity.XDOC_A != null)
                    {
                        MC.ITEM_ENTITY_LIST = (ObservableCollection<ADM_M0061_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_A, MC.ITEM_ENTITY_LIST);
                        ItemsEntity.Clear();
                        ItemsEntity = MC.ITEM_ENTITY_LIST;
                    }
                    else
                    {
                        ItemsEntity = new ObservableCollection<ADM_M0061_A>();
                    }
                    NewRecord = false;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M0061> result)
        {
            NewRecord = true;
            MasterEntity = new ADM_M0061();
            ItemsEntity = new ObservableCollection<ADM_M0061_A>();
            ITEM_ENTITY_OBJ = new ADM_M0061_A();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M0061> result)
        {
            sms.ButtonSetup = DialogButton.Ok;
            sms.Caption = "Delete Changes";
            sms.Text = String.Format("This record will delete forever '{0}'", this.Title);

            if (sms.ShowMessage() == DialogResult.Ok)
            {
                this.MasterEntity.CancelEdit();
                string response = REPOSITORY_OBJ.Delete(MasterEntity.doc_no, "ADM_M0061_BL", "ADM");
                MasterEntity = new ADM_M0061();
                ItemsEntity = new ObservableCollection<ADM_M0061_A>();
                NewRecord = true;
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M0061> result)
        {
            MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M0061> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M0061> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M0061> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M0061> result)
        {
        }
        protected override void OnDocumentAction()
        {
        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M0061> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M0061> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnValidateCommand(InquiryActionResult<ADM_M0061> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnTraceCommand(InquiryActionResult<ADM_M0061> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnMailCommand(InquiryActionResult<ADM_M0061> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
