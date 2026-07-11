using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Reflection.WebServices.Gateway;
using System.Collections.ObjectModel;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using Reflection.Presentation.Services;
using System.Collections.Specialized;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using Reflection.Presentation.Services.Convertors;
using System.Reflection;
using GalaSoft.MvvmLight.Ioc;
using Reflection.Presentation.Core.VirtualDesktops;
using Reflection.ReportingServices;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.Account;
using Reflection.BusinessEntity.FICO;
using Reflection.BusinessEntity.Finance;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_T003_VM : WorkspaceViewModel<PUR_T005>
    {
        #region AutoSuggest TextBox Region
        //public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_T003_VM));
        //public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

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
        private AutoSuggestTextViewModel<dynamic> _AS_DEFAULT_2 { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DEFAULT_2
        {
            get { return _AS_DEFAULT_2; }
            set
            {
                if (_AS_DEFAULT_2 != value)
                {
                    _AS_DEFAULT_2 = value; RaisePropertyChanged("AS_DEFAULT_2");
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
        private AutoSuggestTextViewModel<dynamic> _AS_TAX_ACC { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_TAX_ACC
        {
            get { return _AS_TAX_ACC; }
            set
            {
                if (_AS_TAX_ACC != value)
                {
                    _AS_TAX_ACC = value; RaisePropertyChanged("AS_TAX_ACC");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_LICENCE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_LICENCE
        {
            get { return _AS_LICENCE; }
            set
            {
                if (_AS_LICENCE != value)
                {
                    _AS_LICENCE = value; RaisePropertyChanged("AS_LICENCE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_TAX_CONDITION_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_TAX_CONDITION_TYPE
        {
            get { return _AS_TAX_CONDITION_TYPE; }
            set
            {
                if (_AS_TAX_CONDITION_TYPE != value)
                {
                    _AS_TAX_CONDITION_TYPE = value; RaisePropertyChanged("AS_TAX_CONDITION_TYPE");
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
        private AutoSuggestTextViewModel<dynamic> _AS_WITHHOLDING { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_WITHHOLDING
        {
            get { return _AS_WITHHOLDING; }
            set
            {
                if (_AS_WITHHOLDING != value)
                {
                    _AS_WITHHOLDING = value; RaisePropertyChanged("AS_WITHHOLDING");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_SERVICE_PROVIDER { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_SERVICE_PROVIDER // Tax Grid Party like Transporter.
        {
            get { return _AS_SERVICE_PROVIDER; }
            set
            {
                if (_AS_SERVICE_PROVIDER != value)
                {
                    _AS_SERVICE_PROVIDER = value; RaisePropertyChanged("AS_SERVICE_PROVIDER");
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
            try
            {
                if (dgCellInfo != null)
                {
                    var column = dgCellInfo.Column as DataGridColumn;
                    if (column != null)
                    {
                        string headerName = column.Header.ToString();
                        string SourceName = column.SortMemberPath.ToString();
                        if (SourceName == "ItemCode")
                        { AS_DEFAULT = AS_ITEM; }
                        else if (SourceName == "gl_code")
                        { AS_DEFAULT_1 = AS_TAX_ACC; }
                        else if (SourceName == "curr_code")
                        { AS_DEFAULT_1 = AS_CURRENCY; }
                        else if (SourceName == "con_type")
                        { AS_DEFAULT_1 = AS_TAX_CONDITION_TYPE; }
                        else if (SourceName == "licence_no")
                        { AS_DEFAULT_2 = AS_LICENCE; }
                        else if (SourceName == "service_party")
                        { AS_DEFAULT_1 = AS_SERVICE_PROVIDER; }
                    }
                }
            }
            catch (Exception Ex) { }
        }

        #endregion

        #region Variable Declaration

        bool isNewRecord = true;
        public string ref_doc_cat { get; set; }
        public string ref_doc_list { get; set; }
        public string ref_party_code { get; set; }
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
        public string ts_code_vm { get; set; }
        public string doc_cat_vm { get; set; }
        public string doc_no_vm { get; set; }
        private bool AutoRoundupEnable = true;
        private int _RoundUpDecimals;
        private int RoundUpDecimals
        {
            get { return _RoundUpDecimals; }
            set
            {
                if (_RoundUpDecimals != value)
                {
                    _RoundUpDecimals = value; RaisePropertyChanged("RoundUpDecimals");
                }
            }
        }
        public string Currency { get; set; }
        
        IShowMessageViewService sms;
        WebServiceRepository<PUR_T005> repository = new WebServiceRepository<PUR_T005>();
        WebServiceRepository<MC_PUR_T005> repository_MC = new WebServiceRepository<MC_PUR_T005>();
        ObjectSerializationService obj = new ObjectSerializationService();
        NUMBER_TO_WORDS_CONVERTER NOW_OBJ = new NUMBER_TO_WORDS_CONVERTER();
        private MC_PUR_T005 _MC = new MC_PUR_T005();
        public MC_PUR_T005 MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value; RaisePropertyChanged("MC");

                }
            }

        }
        private MC_PUR_T005 _MCTemp = new MC_PUR_T005();
        public MC_PUR_T005 MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value; RaisePropertyChanged("MCTemp");
                }
            }
        }
        private STD_REQ_PARA_BE _REQUEST_PARA_OBJ;
        public STD_REQ_PARA_BE REQUEST_PARA_OBJ
        {
            get { return _REQUEST_PARA_OBJ; }
            set
            {
                if (_REQUEST_PARA_OBJ != value)
                {
                    _REQUEST_PARA_OBJ = value;

                    RaisePropertyChanged("REQUEST_PARA_OBJ");
                }
            }
        }
        private PUR_T005 _MasterEntity;
        public PUR_T005 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                    value.BeginEdit();
                }
            }
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
                    FilterLicenceDataGrid();
                }
            }
        }
        private int _dgSelectedIndexTaxSummury;
        public int dgSelectedIndexTaxSummury
        {
            get
            {
                return _dgSelectedIndexTaxSummury;
            }
            set
            {
                if (_dgSelectedIndexTaxSummury != value)
                {

                    _dgSelectedIndexTaxSummury = value;
                    RaisePropertyChanged("dgSelectedIndexTaxSummury");

                }
            }
        }
        private int _dgSelectedIndexItemLicence;
        public int dgSelectedIndexItemLicence
        {
            get
            {
                return _dgSelectedIndexItemLicence;
            }
            set
            {
                if (_dgSelectedIndexItemLicence != value)
                {
                    _dgSelectedIndexItemLicence = value;
                    RaisePropertyChanged("dgSelectedIndexItemLicence");
                }
            }
        }
        private PUR_T005_A _ItemEntityObject;
        public PUR_T005_A ItemEntityObject
        {
            get
            {
                return _ItemEntityObject;
            }
            set
            {
                if (_ItemEntityObject != value)
                {
                    _ItemEntityObject = value; RaisePropertyChanged("ItemEntityObject");
                }
            }
        }
        private ACC_T006_C _ConditionObject;
        public ACC_T006_C ConditionObject
        {
            get
            {
                return _ConditionObject;
            }
            set
            {
                if (_ConditionObject != value)
                {
                    _ConditionObject = value; RaisePropertyChanged("ConditionObject");
                }
            }
        }
        private ACC_T006_D _LicenseObject;
        public ACC_T006_D LicenseObject
        {
            get
            {
                return _LicenseObject;
            }
            set
            {
                if (_LicenseObject != value)
                {
                    _LicenseObject = value; RaisePropertyChanged("LicenseObject");
                }
            }
        }
        private bool _can_edit;
        public bool can_edit
        {
            get { return _can_edit; }
            set { _can_edit = value; RaisePropertyChanged("can_edit"); }
        }

        #endregion

        #region Dictionary
        private Dictionary<string, object> _taxDictonery;
        public Dictionary<string, object> TaxDictonery // Tax Popup Data Source
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
        public Dictionary<string, object> TaxDictoneryParent //Parant Tax List data Source for Popup
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
        private Dictionary<string, string> _RefDictionary;
        public Dictionary<string, string> RefDictionary
        {
            get { return _RefDictionary; }
            set
            {
                if (_RefDictionary != value)
                {
                    _RefDictionary = value;
                    RaisePropertyChanged("RefDictionary");
                }
            }
        }
        #endregion

        #region Collection

        private ObservableCollection<PUR_T005_A> _ItemsEntity;
        public ObservableCollection<PUR_T005_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value; RaisePropertyChanged("ItemsEntity");
                    ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                }
            }
        }
        private ObservableCollection<ACC_T006_D> _LicenceDetailsEntity;
        public ObservableCollection<ACC_T006_D> LicenceDetailsEntity
        {
            get
            {
                return _LicenceDetailsEntity;
            }
            set
            {
                if (_LicenceDetailsEntity != value)
                {
                    _LicenceDetailsEntity = value;
                    LicenceDetailsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForLicence);
                    RaisePropertyChanged("LicenceDetailsEntity");
                }
            }
        }
        private ObservableCollection<PUR_T005_B> _dgTotalTaxSummury;
        public ObservableCollection<PUR_T005_B> dgTotalTaxSummury
        {
            get
            {
                return _dgTotalTaxSummury;
            }
            set
            {
                if (_dgTotalTaxSummury != value)
                {
                    _dgTotalTaxSummury = value;

                    RaisePropertyChanged("dgTotalTaxSummury");

                }
            }
        }

        private ObservableCollection<ACC_T006_C> _TotalDocumentTaxes;
        public ObservableCollection<ACC_T006_C> TotalDocumentTaxes // All Document Taxes including Parent,Child & External
        {
            get
            {
                return _TotalDocumentTaxes;
            }
            set
            {
                _TotalDocumentTaxes = value;
                TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
                RaisePropertyChanged("TotalDocumentTaxes");
            }
        }

        private ObservableCollection<ACC_T006_C> _TotalDocumentTaxesItem;
        public ObservableCollection<ACC_T006_C> TotalDocumentTaxesItem // Taxes for selected item.
        {
            get
            {
                return _TotalDocumentTaxesItem;
            }
            set
            {
                _TotalDocumentTaxesItem = value;
                RaisePropertyChanged("TotalDocumentTaxesItem");
            }
        }

        private List<ACC_M013> _SelectedTaxList;
        public List<ACC_M013> SelectedTaxList // Supporting for Filter Data Source for Parent Taxes. * can be remove.
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

        private ICollectionView _popupItemCollection;
        public ICollectionView PopupItemCollection
        {
            get { return _popupItemCollection; }
            set { _popupItemCollection = value; RaisePropertyChanged("PopupItemCollection"); }
        }
        private ICollectionView _REF_DOC_COLLECTION;
        public ICollectionView REF_DOC_COLLECTION
        {
            get { return _REF_DOC_COLLECTION; }
            set { _REF_DOC_COLLECTION = value; RaisePropertyChanged("REF_DOC_COLLECTION"); }
        }
        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }
       
        
       
        private ICollectionView _ParameterValueCollection;
        public ICollectionView ParameterValueCollection
        {
            get { return _ParameterValueCollection; }
            set
            {
                _ParameterValueCollection = value;
                RaisePropertyChanged("ParameterValueCollection");
            }
        }
        private ICollectionView _taxAccountollection;
        public ICollectionView TaxAccountollection
        {
            get { return _taxAccountollection; }
            set { _taxAccountollection = value; RaisePropertyChanged("TaxAccountollection"); }
        }
        private ICollectionView _FormTypeCollection;
        public ICollectionView FormTypeCollection
        {
            get { return _FormTypeCollection; }
            set { _FormTypeCollection = value; RaisePropertyChanged("FormTypeCollection"); }
        }
        private ICollectionView _productDescriptionCollection;
        public ICollectionView ProductDescriptionCollection
        {
            get { return _productDescriptionCollection; }
            set { _productDescriptionCollection = value; RaisePropertyChanged("ProductDescriptionCollection"); }
        }
        private ICollectionView _CollectionPlant;
        public ICollectionView CollectionPlant
        {
            get { return _CollectionPlant; }
            set { _CollectionPlant = value; RaisePropertyChanged("CollectionPlant"); }
        }

        private List<NotificationData> _NotificationDataCollection;
        public List<NotificationData> NotificationDataCollection
        {
            get { return _NotificationDataCollection; }
            set
            {
                if (_NotificationDataCollection != value)
                {
                    _NotificationDataCollection = value;
                    RaisePropertyChanged("NotificationDataCollection");
                }
            }
        }

        private ICollectionView _CollectionCountry;
        public ICollectionView CollectionCountry
        {
            get { return _CollectionCountry; }
            set { _CollectionCountry = value; RaisePropertyChanged("CollectionCountry"); }
        }
        public List<ADM_M003> _ObjSupply = new List<ADM_M003>();
        private List<ADM_M003> ObjSupply
        {
            get { return _ObjSupply; }
            set
            {
                if (_ObjSupply != value)
                {
                    _ObjSupply = value;
                }
            }
        }
        

        private ICollectionView _AttachmentCollection;
        public ICollectionView AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set
            {
                if (_AttachmentCollection != value)
                {
                    _AttachmentCollection = value;
                    RaisePropertyChanged("AttachmentCollection");
                }
            }
        }

        private ICollectionView _WtUomCollection;
        public ICollectionView WtUomCollection
        {
            get { return _WtUomCollection; }
            set
            {
                _WtUomCollection = value;

                RaisePropertyChanged("WtUomCollection");
            }
        }
        private ICollectionView _VolUomCollection;
        public ICollectionView VolUomCollection
        {
            get { return _VolUomCollection; }
            set
            {
                _VolUomCollection = value;
                RaisePropertyChanged("VolUomCollection");
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
        private int _ParadgSelectedIndex;
        public int ParadgSelectedIndex
        {
            get
            {
                return _ParadgSelectedIndex;
            }
            set
            {
                if (_ParadgSelectedIndex != value)
                {
                    _ParadgSelectedIndex = value;
                    RaisePropertyChanged("ParadgSelectedIndex");
                }
            }
        }

        private ICollectionView _incotermsCollection;
        public ICollectionView IncotermsCollection
        {
            get { return _incotermsCollection; }
            set { _incotermsCollection = value; RaisePropertyChanged("IncotermsCollection"); }
        }


        private ICollectionView _licenseEPCGCollection;
        public ICollectionView LicenseEPCGCollection
        {
            get { return _licenseEPCGCollection; }
            set { _licenseEPCGCollection = value; RaisePropertyChanged("LicenseEPCG"); }
        }

        private ICollectionView _licenseAdvanceCollection;
        public ICollectionView LicenseAdvanceCollection
        {
            get { return _licenseAdvanceCollection; }
            set { _licenseAdvanceCollection = value; RaisePropertyChanged("LicenseAdvance"); }
        }

        private ICollectionView _serviceProviderCollection;
        public ICollectionView ServiceProviderCollection
        {
            get { return _serviceProviderCollection; }
            set { _serviceProviderCollection = value; RaisePropertyChanged("ServiceProviderCollection"); }
        }

        private ICollectionView _ReferenceDocPOCollection;
        public ICollectionView ReferenceDocPOCollection
        {
            get { return _ReferenceDocPOCollection; }
            set { _ReferenceDocPOCollection = value; RaisePropertyChanged("ReferenceDocPOCollection"); }
        }

        private ICollectionView _ReferenceDocGRNCollection;
        public ICollectionView ReferenceDocGRNCollection
        {
            get { return _ReferenceDocGRNCollection; }
            set { _ReferenceDocGRNCollection = value; RaisePropertyChanged("ReferenceDocGRNCollection"); }
        }
        public List<PUR_T005_P_RefDoc> _refdoctempa;
        public List<PUR_T005_P_RefDoc> refdoctempa
        {
            get
            {
                return _refdoctempa;
            }
            set
            {
                _refdoctempa = value;
                RaisePropertyChanged("refdoctempa");
            }
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

        #endregion

        #region Model Entity Update
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            try
            {
                if (EntityChangeEnable == true)
                {
                    if (sender.ToString() == "loc_curr")
                    {
                        if (MasterEntity.loc_curr > 0)
                        {
                            NumberToEnglish num = new NumberToEnglish();
                            MasterEntity.amt_in_wordsLoc = num.AmountInWords(Convert.ToDecimal(MasterEntity.loc_curr));
                        }
                        else
                        {
                            MasterEntity.amt_in_wordsLoc = null;
                        }

                    }
                    if (sender.ToString() == "curr_code")
                    {
                        if (MasterEntity.local_currency == MasterEntity.curr_code)
                        {
                            MasterEntity.exch_rate = 1;
                        }
                    }
                    if (sender.ToString() == "withholding_tax")
                    {
                        CalWithHoldingTax();
                    }
                    this.ErrorExist = MasterEntity.HasErrors;
                }
            }
            catch (Exception ex)
            {
            }
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        { //This will get called when the property of an object inside the collection changes
            this.ErrorExist = MasterEntity.HasErrors;
            if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = ItemsEntity[dgSelectedIndexItem].HasErrors;
            }
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            try
            {
                if (EntityChangeEnable == true)
                {
                    //This will get called when the property of an object inside the collection changes
                    if (sender.ToString() == "qty" || sender.ToString() == "unit_price" || sender.ToString() == "tax_id" || sender.ToString() == "active" || sender.ToString() == "discount_type" || sender.ToString() == "discount" || sender.ToString() == "discount_amt")
                    {
                        Computation(true, dgSelectedIndexItem, AutoRoundupEnable); ;//this is in use 
                        UpdateQtyInLicence();
                    }
                    this.ErrorExist = MasterEntity.HasErrors;
                    if (ItemsEntity.Count > 0 && ItemEntityObject != null)
                    {
                        this.ErrorExist = ItemEntityObject.HasErrors;
                    }
                }
            }
            catch (Exception ex)
            {}
        }
        private void CalWithHoldingTax()
        {
            try
            {
                if (MCTemp.WITHHOLDING_LIST != null && !string.IsNullOrWhiteSpace(MasterEntity.withholding_tax))
                {
                    STD_FICO_BE POPUPEntityObject = MCTemp.WITHHOLDING_LIST.Where(x => x.wtax_code == MasterEntity.withholding_tax).ToList()[0];
                    if (POPUPEntityObject != null && POPUPEntityObject.wtax_type == "INV" && POPUPEntityObject.wtax_per != 0)
                    {
                        MasterEntity.withholding_value = MasterEntity.net_value * (POPUPEntityObject.wtax_rate / POPUPEntityObject.wtax_per);
                        //MasterEntity.withholding_value = MasterEntity.net_value - MasterEntity.withholding_value;
                    }
                }
            }
            catch (Exception Ex) { }
        }

        #endregion

        #region TaxComputation Function
        private void Computation(bool Compute, int ItemRowIndex, bool AutoRoundUpFlag)
        {
            try
            {
                if (Compute == true)
                {
                    decimal? PreviousTaxValueForBasePrice = 0;
                    decimal? BasePrice = 0;
                    decimal? TaxAmount = 0;
                    decimal? BasicItemAmount = 0;
                    decimal? TaxValue = 0;
                    decimal? TaxtTotal = 0;
                    decimal? UnTaxTotal = 0;
                    decimal? GrandTotal = 0;

                    decimal? net_value = 0;
                    decimal? other_charges = 0;

                    if (ItemsEntity != null && ItemsEntity.Count > 0 && ItemRowIndex >= 0 && ItemRowIndex < ItemsEntity.Count) //Condition satisfy only if Items collection is not empty.
                    {
                        if (ItemsEntity[ItemRowIndex].qty >= 0 && ItemsEntity[ItemRowIndex].unit_price >= 0 && ItemsEntity[ItemRowIndex].active != false) // Must not null or empty.
                        {
                            ItemsEntity[ItemRowIndex].gross_value = Math.Round(((ItemsEntity[ItemRowIndex].qty * ItemsEntity[ItemRowIndex].unit_price) ?? 0), RoundUpDecimals);
                            
                            if (ItemsEntity[ItemRowIndex].discount == null)
                            {
                                ItemsEntity[ItemRowIndex].discount = 0;
                            }
                            if (ItemsEntity[ItemRowIndex].discount_type == "F")    // Manual Discount value instead of percent.
                            {
                                ItemsEntity[ItemRowIndex].discount = 0;
                                ItemsEntity[ItemRowIndex].subtotal = (ItemsEntity[ItemRowIndex].gross_value) - ItemsEntity[ItemRowIndex].discount_amt;
                            }
                            else
                            {
                                //ItemsEntity[ItemRowIndex].discount_amt = (ItemsEntity[ItemRowIndex].gross_value * ((ItemsEntity[ItemRowIndex].discount ?? 0) / 100));
                                ItemsEntity[ItemRowIndex].discount_amt = decimal.Round((decimal)(ItemsEntity[ItemRowIndex].gross_value * ((ItemsEntity[ItemRowIndex].discount ?? 0) / 100)), RoundUpDecimals);
                                //ItemsEntity[ItemRowIndex].subtotal = (ItemsEntity[ItemRowIndex].gross_value - ItemsEntity[ItemRowIndex].discount_amt);
                                ItemsEntity[ItemRowIndex].subtotal = decimal.Round((decimal)((ItemsEntity[ItemRowIndex].gross_value - ItemsEntity[ItemRowIndex].discount_amt) ?? 0), RoundUpDecimals);
                            }
                        }
                        #region Calculate Taxes for New/Edited Items row.
                        if (!String.IsNullOrEmpty(ItemsEntity[ItemRowIndex].tax_id) && ItemsEntity[ItemRowIndex].active == true) //Condition satisfy only if Selected Item not null and Taxes are applied.
                        {
                            #region Tax Not Null

                            List<ACC_M013> TaxListTemp = new List<ACC_M013>();
                            string[] TaxArray = ItemsEntity[ItemRowIndex].tax_id.Trim().Split(',');
                            foreach (string SingleTax in TaxArray) // select all Taxes & Child Taxes which is applicablt for Item.
                            {
                                foreach (ACC_M013 PickTax in MC.TAX_LIST)
                                {
                                    if (PickTax.id == Convert.ToInt32(SingleTax) || PickTax.parent_id == Convert.ToInt32(SingleTax))
                                    {
                                        TaxListTemp.Add(PickTax); // collection of All Parent and Child Taxes applicable for current Item.
                                    }
                                }
                            }

                            int?[] TaxListForBaseInclude = new int?[TaxListTemp.Count];
                            for (int i = 0; i < TaxListTemp.Count; i++) // Collect Taxes having property Include_base = true.
                            {
                                if (TaxListTemp[i].include_base_amount == true)
                                {
                                    TaxListForBaseInclude[i] = (int?)TaxListTemp[i].id;
                                }
                            }
                            TaxListTemp = TaxListTemp.OrderBy(tax => tax.sequence).ToList(); // Set ascending order of Taxex by sequence column to get Base amount for next/current Tax. Base Amount = Sub Total + Previous Tax Amount. (Previous Tax= Having column Include_Base_amount = True)
                            if (TaxListTemp.Count > 0)
                            {
                                foreach (ACC_M013 SingleTax in TaxListTemp) // Foreach Loop for Computation of Induvidual Tax as per the proerties in Tax Master.
                                {
                                    PreviousTaxValueForBasePrice = 0;
                                    BasePrice = 0;
                                    TaxAmount = 0;
                                    BasicItemAmount = 0;
                                    TaxValue = 0;
                                    TaxtTotal = 0;
                                    UnTaxTotal = 0;
                                    GrandTotal = 0;
                                    net_value = 0;
                                    other_charges = 0;

                                    #region Percentage
                                    if (SingleTax.t_type == "Percentage" && SingleTax.amount > 0)
                                    {
                                        if (SingleTax.price_include == true)
                                        {
                                            TaxValue = (SingleTax.amount) / 100 + 1;
                                            BasePrice = ItemsEntity[ItemRowIndex].subtotal / TaxValue;
                                            BasicItemAmount = BasePrice;
                                            TaxAmount = ItemsEntity[ItemRowIndex].subtotal - BasicItemAmount;
                                        }
                                        else if (SingleTax.price_include == false)
                                        {
                                            TaxValue = (SingleTax.amount) / 100;
                                            if (TaxListForBaseInclude.Length > 0)
                                            {
                                                PreviousTaxValueForBasePrice = TotalDocumentTaxes.Where(tax => tax.sequence < SingleTax.sequence && tax.item_line_id == ItemsEntity[ItemRowIndex].line_id && tax.manual == "Auto" && tax.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_row_id == ItemsEntity[ItemRowIndex].id && tax.tax_code_id.In(TaxListForBaseInclude)).Sum(tax => tax.tax_amount); // Get Base amount for Calculation.
                                            }
                                            if (SingleTax.parent_id != null) // Collect Base price for This single child Tax.
                                            {
                                                BasePrice = TotalDocumentTaxes.Where(tax => tax.tax_code_id == SingleTax.parent_id && tax.item_line_id == ItemsEntity[ItemRowIndex].line_id && tax.manual == "Auto" && tax.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_row_id == ItemsEntity[ItemRowIndex].id).Single().tax_amount;
                                            }
                                            else // Collect Base Price for this parent Tax.
                                            {
                                                BasePrice = ItemsEntity[ItemRowIndex].subtotal + PreviousTaxValueForBasePrice;
                                            }
                                            BasicItemAmount = ItemsEntity[ItemRowIndex].subtotal;
                                            TaxAmount = BasePrice * TaxValue;
                                        }
                                    }
                                    #endregion
                                    #region Fixed Amount
                                    else if (SingleTax.t_type == "Fixed Amount" && SingleTax.amount > 0)
                                    {
                                        TaxValue = SingleTax.amount;
                                        if (SingleTax.price_include == true)
                                        {
                                            BasePrice = ItemsEntity[ItemRowIndex].subtotal - TaxValue;
                                            BasicItemAmount = BasePrice;
                                            TaxAmount = ItemsEntity[ItemRowIndex].subtotal - BasicItemAmount;
                                        }
                                        else if (SingleTax.price_include == false)
                                        {
                                            BasePrice = ItemsEntity[ItemRowIndex].subtotal;
                                            BasicItemAmount = BasePrice;
                                            TaxAmount = TaxValue;
                                        }
                                    }
                                    #endregion
                                    #region Insert/Update Tax
                                    TaxAmount = Math.Round((TaxAmount ?? 0), RoundUpDecimals);
                                    int TaxIndex = 0;
                                    var TaxVar = TotalDocumentTaxes.FirstOrDefault(T => T.tax_code_id == SingleTax.id && T.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (T.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && (T.item_line_id ?? 0) == ItemsEntity[ItemRowIndex].line_id && T.item_row_id == ItemsEntity[ItemRowIndex].id && T.manual == "Auto");
                                    TaxIndex = TotalDocumentTaxes.IndexOf(TaxVar);
                                    if (TaxVar != null && TaxIndex >= 0)
                                    {
                                        TotalDocumentTaxes[TaxIndex].manual = "Auto";
                                        TotalDocumentTaxes[TaxIndex].active = true;
                                        TotalDocumentTaxes[TaxIndex].tax_amount = TaxAmount;
                                        TotalDocumentTaxes[TaxIndex].account_id = 0;
                                        TotalDocumentTaxes[TaxIndex].sequence = SingleTax.sequence;
                                        TotalDocumentTaxes[TaxIndex].doc_no = MasterEntity.doc_no;
                                        TotalDocumentTaxes[TaxIndex].base_amount = BasePrice;
                                        TotalDocumentTaxes[TaxIndex].amount = SingleTax.amount;
                                        TotalDocumentTaxes[TaxIndex].tax_code_id = SingleTax.id;
                                        TotalDocumentTaxes[TaxIndex].account_analytic_id = 0;
                                        TotalDocumentTaxes[TaxIndex].base_code_id = SingleTax.id;
                                        TotalDocumentTaxes[TaxIndex].tax_name = SingleTax.description;
                                        TotalDocumentTaxes[TaxIndex].ItemCode = ItemsEntity[ItemRowIndex].ItemCode;
                                        TotalDocumentTaxes[TaxIndex].sku = ItemsEntity[ItemRowIndex].sku;
                                        TotalDocumentTaxes[TaxIndex].item_row_id = ItemsEntity[ItemRowIndex].id;
                                        TotalDocumentTaxes[TaxIndex].item_line_id = ItemsEntity[ItemRowIndex].line_id;
                                        //TotalDocumentTaxes[TaxIndex].fin_year = SingleTax.FinYear;
                                        TotalDocumentTaxes[TaxIndex].location_Id = MasterEntity.location_Id;
                                        TotalDocumentTaxes[TaxIndex].comp_code = MasterEntity.comp_code;
                                        TotalDocumentTaxes[TaxIndex].posting_period = MasterEntity.posting_period;
                                        TotalDocumentTaxes[TaxIndex].trns_key_code = "PTX";

                                        TotalDocumentTaxes[TaxIndex].con_value = TaxAmount;
                                        TotalDocumentTaxes[TaxIndex].tax_code = SingleTax.tax_code;
                                        TotalDocumentTaxes[TaxIndex].PartyId = MasterEntity.PartyId;
                                        TotalDocumentTaxes[TaxIndex].exch_rate = MasterEntity.exch_rate;
                                        TotalDocumentTaxes[TaxIndex].client = AppSessionState.client;
                                        TotalDocumentTaxes[TaxIndex].symbol = MasterEntity.symbol;
                                        TotalDocumentTaxes[TaxIndex].local_curr = AppSessionState.CntryCurncy;
                                    }
                                    else
                                    {
                                        TotalDocumentTaxes.Add(new ACC_T006_C()
                                        {
                                            id = 0,
                                            tax_amount = TaxAmount,
                                            account_id = 0,
                                            sequence = SingleTax.sequence,
                                            doc_no = MasterEntity.doc_no,
                                            manual = "Auto",
                                            base_amount = BasePrice,
                                            amount = SingleTax.amount,
                                            tax_code_id = SingleTax.id,
                                            account_analytic_id = 0,
                                            base_code_id = SingleTax.id,
                                            tax_name = SingleTax.description,
                                            ItemCode = ItemsEntity[ItemRowIndex].ItemCode,
                                            sku = ItemsEntity[ItemRowIndex].sku,
                                            item_row_id = ItemsEntity[ItemRowIndex].id,
                                            item_line_id = ItemsEntity[ItemRowIndex].line_id,
                                            //fin_year = AppSessionState.FinYear,
                                            active = true,
                                            posting_period = MasterEntity.posting_period,
                                            location_Id = AppSessionState.OBJ_LOCATION.location_id,
                                            comp_code = AppSessionState.OBJ_COMPANY.comp_code,
                                            trns_key_code = "PTX",
                                            //t_status = MasterEntity.t_status,
                                            con_value = TaxAmount,
                                            tax_code = SingleTax.tax_code,
                                            PartyId = MasterEntity.PartyId,
                                            exch_rate = MasterEntity.exch_rate,
                                            client = AppSessionState.client,
                                            symbol = MasterEntity.symbol,
                                            local_curr = AppSessionState.CntryCurncy
                                        });
                                    }

                                    #endregion
                                }
                            }

                            #endregion

                            #region Remove Excluded Taxes.
                            string[] TaxArray2 = ItemsEntity[ItemRowIndex].tax_id.Trim().Split(',');
                            List<ACC_T006_C> copy = new List<ACC_T006_C>();
                            copy = TotalDocumentTaxes.ToList();
                            foreach (var tax in copy)
                            {
                                bool DeleteFlag = true;
                                foreach (string SingleTax in TaxArray2)
                                {
                                    if ((tax.tax_code_id.ToString() == SingleTax && tax.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == ItemsEntity[ItemRowIndex].line_id && tax.item_row_id == ItemsEntity[ItemRowIndex].id && tax.manual == "Auto") || tax.manual == "Manual")
                                    {
                                        DeleteFlag = false;
                                        break;
                                    }
                                }
                                if (!DeleteFlag) continue;
                                var ChildTaxVar = MC.TAX_LIST.FirstOrDefault(T => T.id == tax.tax_code_id);
                                if (ChildTaxVar.parent_id != null)
                                {
                                    bool CheckChildParentFlag = true;
                                    foreach (string SingleTax in TaxArray2)
                                    {
                                        if (ChildTaxVar.parent_id.ToString() == SingleTax && tax.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == ItemsEntity[ItemRowIndex].line_id && tax.item_row_id == ItemsEntity[ItemRowIndex].id && tax.manual == "Auto")
                                        {
                                            CheckChildParentFlag = false;
                                            break;
                                        }
                                    }
                                    if (!CheckChildParentFlag) continue;
                                    //var ParentTaxVar = TotalDocumentTaxes.FirstOrDefault(T => T.tax_code_id == ChildTaxVar.parent_id && T.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (T.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && T.line_id == ItemsEntity[ItemRowIndex].line_id && T.item_line_id == ItemsEntity[ItemRowIndex].id && T.manual == "Auto");
                                    //if (ParentTaxVar == null)

                                    if (tax.tax_code_id == ChildTaxVar.id && tax.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == ItemsEntity[ItemRowIndex].line_id && tax.item_row_id == ItemsEntity[ItemRowIndex].id && tax.manual == "Auto" && (tax.active == true || tax.id == 0))
                                    {
                                        TotalDocumentTaxes.Remove(tax);
                                    }
                                }
                                else if (tax.tax_code_id == ChildTaxVar.id && tax.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == ItemsEntity[ItemRowIndex].line_id && tax.item_row_id == ItemsEntity[ItemRowIndex].id && tax.manual == "Auto" && (tax.active == true || tax.id == 0))
                                {
                                    //TotalDocumentTaxes.Remove(tax);
                                    if (tax.id == 0)
                                    {
                                        TotalDocumentTaxes.Remove(tax);
                                    }
                                    else
                                    {
                                        int Index = TotalDocumentTaxes.IndexOf(TotalDocumentTaxes.Where(X => X.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && X.id == tax.id && (X.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && X.item_line_id == ItemsEntity[ItemRowIndex].line_id && X.item_row_id == ItemsEntity[ItemRowIndex].id && X.manual == "Auto" && X.active == true).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.
                                        if (Index >= 0)
                                        {
                                            TotalDocumentTaxes.ElementAt(Index).active = false;
                                        }
                                    }
                                }
                            }
                            #endregion
                        }
                        else //if (ItemsEntity[ItemRowIndex].tax_id != null && ItemsEntity[ItemRowIndex].active == false) // Remove previously assign Taxes from TotalDocumentTaxes if removed from Item.//Condition satisfy only if Selected Item not null and Active status is false.
                        {
                            List<ACC_T006_C> copy = new List<ACC_T006_C>();
                            copy = TotalDocumentTaxes.ToList();
                            foreach (var tax in copy)
                            {
                                if (tax.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == ItemsEntity[ItemRowIndex].line_id && tax.item_row_id == ItemsEntity[ItemRowIndex].id && tax.manual == "Auto")
                                {
                                    if (tax.id == 0)
                                    {
                                        TotalDocumentTaxes.Remove(tax);
                                    }
                                    else
                                    {
                                        int Index = TotalDocumentTaxes.IndexOf(TotalDocumentTaxes.Where(X => X.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (X.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && X.item_line_id == ItemsEntity[ItemRowIndex].line_id && X.item_row_id == ItemsEntity[ItemRowIndex].id && X.manual == "Auto" && X.active == true).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.
                                        if (Index >= 0)
                                        {
                                            TotalDocumentTaxes.ElementAt(Index).active = false;
                                        }
                                    }
                                }
                            }

                            //Code by kalpesh
                            //for (int i = 0; i < TotalDocumentTaxes.Count; i++)
                            //{
                            //    if (TotalDocumentTaxes[i].ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (TotalDocumentTaxes[i].sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && TotalDocumentTaxes[i].item_line_id == ItemsEntity[ItemRowIndex].line_id && TotalDocumentTaxes[i].item_row_id == ItemsEntity[ItemRowIndex].id && TotalDocumentTaxes[i].manual == "Auto")
                            //    {
                            //        if (TotalDocumentTaxes[i].id == 0)
                            //        {
                            //            TotalDocumentTaxes.RemoveAt(i);                                    
                            //        }
                            //        else
                            //        {
                            //            TotalDocumentTaxes[i].active = false;
                            //        }
                            //    }
                            //}

                            //Code ends here

                        }
                        #region Final Computation

                        if (ItemsEntity.Count > 0) // calculate items total Tax and get Net & Effective value of the item.
                        {
                            decimal? taxTotal = TotalDocumentTaxes.Where(x => x.item_row_id == ItemsEntity[ItemRowIndex].id && x.item_line_id == ItemsEntity[ItemRowIndex].line_id).Sum(x => x.con_value);
                            ItemsEntity[ItemRowIndex].net_value = ((ItemsEntity[ItemRowIndex].gross_value + Math.Round((taxTotal ?? 0), RoundUpDecimals)) - (ItemsEntity[ItemRowIndex].discount_amt ?? 0));
                            ItemsEntity[ItemRowIndex].effective_value = ItemsEntity[ItemRowIndex].net_value;
                            ItemsEntity[ItemRowIndex].tax_amount = taxTotal;
                            ItemsEntity[ItemRowIndex].tax_amt = taxTotal;
                        }

                        //TaxtTotal = TotalDocumentTaxes.Sum(x => x.tax_amount);
                        TaxtTotal = TotalDocumentTaxes.Where(item => item.active != false && item.manual == "Auto").Sum(item => item.tax_amount);
                        MasterEntity.tax_amount = TaxtTotal;
                        MasterEntity.tax_amount = TaxtTotal;

                        //UnTaxTotal = ItemsEntity.Sum(x => x.sub_total);
                        UnTaxTotal = ItemsEntity.Where(item => item.active != false).Sum(item => item.subtotal);
                        MasterEntity.acc_amount = UnTaxTotal;

                        net_value = UnTaxTotal + TaxtTotal;
                        MasterEntity.net_value = net_value;
                        other_charges = TotalDocumentTaxes.Where(item => item.active != false && item.manual == "Manual").Sum(item => item.tax_amount);
                        MasterEntity.other_charges = other_charges;

                        GrandTotal = net_value + other_charges;
                        GrandTotal = decimal.Round((decimal)GrandTotal, 2);
                        MasterEntity.total = GrandTotal;

                        if (AutoRoundUpFlag == true)
                        {
                            MasterEntity.roundup_total = decimal.Round((decimal)GrandTotal);
                            MasterEntity.round_up = MasterEntity.roundup_total - GrandTotal;
                        }
                        else
                        {
                            MasterEntity.round_up = 0;
                            MasterEntity.roundup_total = GrandTotal + MasterEntity.round_up;
                        }

                        MasterEntity.gross_value = ItemsEntity.Where(item => item.active != false).Sum(item => item.qty * item.unit_price);
                        MasterEntity.effective_value = GrandTotal;
                        MasterEntity.disc_amt = MasterEntity.gross_value - UnTaxTotal;

                        if (MasterEntity.roundup_total > 0 && !string.IsNullOrWhiteSpace(MasterEntity.curr_code))
                        {
                            ADM_M037 curr_obj = new ADM_M037();
                            curr_obj = ((List<ADM_M037>)AppSessionState.CurrencyList).Where(x => x.curr_code == MasterEntity.curr_code).ToList()[0];
                            if (curr_obj.word_format == "F01" || string.IsNullOrWhiteSpace(curr_obj.word_format))
                            {
                                MasterEntity.amt_word = NUMBER_TO_WORDS_CONVERTER.AmountInWordsF01(MasterEntity.roundup_total.ToString(), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word, curr_obj.word_format, curr_obj.word_prefix, curr_obj.word_suffix);
                            }
                            else
                            {
                                MasterEntity.amt_word = NOW_OBJ.AmountInWords(Convert.ToDecimal(MasterEntity.roundup_total), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word, curr_obj.word_format);
                            }
                        }
                        else
                        { MasterEntity.amt_word = ""; }
                        MasterEntity.loc_curr = (Convert.ToDecimal(MasterEntity.roundup_total) * Convert.ToDecimal(MasterEntity.exch_rate));
                        #endregion
                        #endregion
                    }
                }
            }
            catch (Exception Ex) { }
        }
        private void CollectionChangedNotifyForTotalTaxes(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (ACC_T006_C item in e.NewItems)
                        item.PropertyChanged += this.EntityViewModelPropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (ACC_T006_C item in e.OldItems)
                        item.PropertyChanged -= this.EntityViewModelPropertyChanged;

                /////////////////////////////////Temp Test End
                if (e.Action == NotifyCollectionChangedAction.Add && ItemsEntity.Count > 0) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (ACC_T006_C item in e.NewItems)
                    {

                        if (item.tax_code_id > 0)
                        { item.manual = "Auto"; item.con_type = "TAXC"; }
                        else { item.manual = "Manual"; item.sequence = 100; }
                        if (item.tax_name == null || item.tax_name.Trim() == "")
                        { item.tax_name = "CASH"; }
                        item.active = true;
                        item.symbol = MasterEntity.symbol;
                        item.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                        item.exch_rate = MasterEntity.exch_rate;
                        item.local_curr = AppSessionState.CntryCurncy;
                        item.curr_code = MasterEntity.curr_code;
                        item.PartyId = MasterEntity.PartyId;  // Transporter
                        item.client = AppSessionState.client;
                        item.exch_rate = MasterEntity.exch_rate;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                { }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                { }
                if (e.Action == NotifyCollectionChangedAction.Move)
                { }
                int c = TotalDocumentTaxes.Count();
            }
            catch (Exception ex)
            { //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void CollectionChangedNotifyForLicence(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (ACC_T006_D item in e.NewItems)
                        item.PropertyChanged += this.EntityViewModelPropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (ACC_T006_D item in e.OldItems)
                        item.PropertyChanged -= this.EntityViewModelPropertyChanged;

                /////////////////////////////////Temp Test End
                if (e.Action == NotifyCollectionChangedAction.Add) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (ACC_T006_D item in e.NewItems)
                    {
                        item.ItemCode = ItemsEntity[dgSelectedIndexItem].ItemCode;
                        item.sku = ItemsEntity[dgSelectedIndexItem].sku;
                        item.item_line_id = ItemsEntity[dgSelectedIndexItem].line_id;
                        item.order_no = MasterEntity.po_no;
                        item.ref_doc_no = MasterEntity.ref_doc_no;
                        item.ref_doc_type = MasterEntity.ref_doc_type;
                        item.ref_doc_date = MasterEntity.ref_date;

                        item.qty = ItemsEntity[dgSelectedIndexItem].qty;
                        item.incoterm_value_doc = ItemsEntity[dgSelectedIndexItem].net_value;
                        item.incoterm_value_local = ItemsEntity[dgSelectedIndexItem].local_net_value;
                        item.PartyId = MasterEntity.PartyId;
                        item.exch_rate = MasterEntity.exch_rate;
                        item.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.active = true;
                        item.con_type = "LIC";
                        item.trns_key_code = "LIC";
                        item.incoterms = MasterEntity.incoterms;
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                { }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                { }
                if (e.Action == NotifyCollectionChangedAction.Move)
                { }
            }
            catch (Exception ex) { }

        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (PUR_T005_A item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (PUR_T005_A item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (PUR_T005_A item in e.NewItems)
                    {
                        //Added items
                        item.symbol = MasterEntity.symbol;
                        //item.user_source1 = AppSessionState.UserSource1;
                        //item.user_source2 = AppSessionState.UserSource2;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                        item.client = AppSessionState.client;
                        item.active = true;
                        item.add_by = AppSessionState.UserID;
                        item.editby = AppSessionState.UserID;
                        //NOTE: t_status & t_display need to fetch with execute method, not required here. add logic in SQL for this kind of Transactions.
                        //item.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
                        //item.t_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_display).FirstOrDefault();
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                    if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = ItemsEntity[dgSelectedIndexItem].HasErrors;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                    this.ErrorExist = MasterEntity.HasErrors;
                    if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = ItemsEntity[dgSelectedIndexItem].HasErrors;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    PUR_T005_A temp = (PUR_T005_A)e.OldItems[0];
                    if (TotalDocumentTaxes.Count > 0) // Remove Taxes deleted item.
                    {
                        List<ACC_T006_C> copy = new List<ACC_T006_C>();
                        copy = TotalDocumentTaxes.ToList();
                        foreach (var tax in copy)
                        {
                            if (tax.ItemCode == temp.ItemCode && (tax.sku?.ToString() ?? "") == (temp.sku?.ToString() ?? "") && tax.item_row_id == temp.id)
                            {
                                TotalDocumentTaxes.Remove(tax);
                                Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
                            }
                        }

                    }
                    foreach (PUR_T005_A item in e.OldItems)
                    {
                        item.PropertyChanged -= EntityViewModelPropertyChanged;
                    }
                    if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = ItemsEntity[dgSelectedIndexItem].HasErrors;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Move) { }
            }
            catch (Exception ex) { }
        }
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (EntityChangeEnable == true)
                {
                    if (e.PropertyName == "qty" || e.PropertyName == "unit_price" || e.PropertyName == "tax_id" || e.PropertyName == "active" || e.PropertyName == "discount")
                    {
                        Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
                    }
                    if (e.PropertyName == "gross_wt")
                    {
                        MasterEntity.gross_wt = ItemsEntity.Where(item => item.active != false).Sum(item => item.gross_wt);
                    }
                    if (e.PropertyName == "volume")
                    {
                        MasterEntity.volume = ItemsEntity.Where(item => item.active != false).Sum(item => item.volume);
                    }
                    if (e.PropertyName == "net_wt")
                    {
                        MasterEntity.net_wt = ItemsEntity.Where(item => item.active != false).Sum(item => item.net_wt);
                    }

                    if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = ItemsEntity[dgSelectedIndexItem].HasErrors;
                    }
                }
            }
            catch (Exception ex)
            {}
        }
        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdRoundUpManual { get; private set; }
        public RelayCommand<object> cmdInsertItem { get; private set; }
        public RelayCommand<object> cmdExecuteReferenceDocument { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> cmdAddSelectedTax { get; private set; }
        public RelayCommand<object> cmdDeleteTax { get; private set; }
        public RelayCommand<object> ManualTaxChangedCommand { get; private set; }
        public RelayCommand<object> TaxPopupCommand { get; private set; }
        public RelayCommand<object> cmdServiceProvider { get; private set; }
        public RelayCommand<object> cmdLicence { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowLicence { get; private set; }
        public RelayCommand<object> cmdCondiionType { get; private set; }
        public RelayCommand<object> cmdCurrency { get; private set; }
        public RelayCommand<object> cmdOpenAttachments { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        public RelayCommand<object> cmdCollectReferenceDocuments { get; private set; }
        public RelayCommand<object> cmdInsertWithholding { get; private set; }
        public RelayCommand<object> cmdTraceReport { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_Item { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_Condition { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_License { get; private set; }

        #endregion

        #region Constructor
        public FICO_T003_VM(string doc_cat,string ts_code) : base()
        {
            CursorControl.SetBusyState();
            this.ts_code_vm = ts_code;
            doc_cat_vm = doc_cat;
            Currency = AppSessionState.CntryCurncy;
            MC = new MC_PUR_T005();
            MCTemp = new MC_PUR_T005();
            MasterEntity = new PUR_T005();
            ItemsEntity = new ObservableCollection<PUR_T005_A>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
            LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
            //TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_C>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
            dgTotalTaxSummury = new ObservableCollection<PUR_T005_B>();
            sms = this.GetViewService<IShowMessageViewService>();
            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            MasterEntity.FrmDate = lastDayLastMonth.AddDays(-23);
            MasterEntity.ToDate = System.DateTime.Now;
            REQUEST_PARA_OBJ = new STD_REQ_PARA_BE();
            REQUEST_PARA_OBJ.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            REQUEST_PARA_OBJ.location_id = AppSessionState.OBJ_LOCATION.location_id;
            REQUEST_PARA_OBJ.doc_cat = doc_cat_vm;
            REQUEST_PARA_OBJ.doc_type = doc_cat_vm;
            //MasterEntity.ValidateAsync().Wait();
            PUR_T005.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            PUR_T005_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            NotificationDataCollection = new List<NotificationData>();
            LoadInitialData();
        }
        public FICO_T003_VM(string doc_cat, string ts_code, string doc_no) : base()
        {
            CursorControl.SetBusyState();
            this.ts_code_vm = ts_code;
            doc_cat_vm = doc_cat;
            this.doc_no_vm = doc_no;
            Currency = AppSessionState.CntryCurncy;
            MC = new MC_PUR_T005();
            MCTemp = new MC_PUR_T005();
            MasterEntity = new PUR_T005();
            ItemsEntity = new ObservableCollection<PUR_T005_A>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
            LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
            //TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_C>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
            dgTotalTaxSummury = new ObservableCollection<PUR_T005_B>();
            sms = this.GetViewService<IShowMessageViewService>();
            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            MasterEntity.FrmDate = lastDayLastMonth.AddDays(-23);
            MasterEntity.ToDate = System.DateTime.Now;
            REQUEST_PARA_OBJ = new STD_REQ_PARA_BE();
            REQUEST_PARA_OBJ.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            REQUEST_PARA_OBJ.location_id = AppSessionState.OBJ_LOCATION.location_id;
            REQUEST_PARA_OBJ.doc_cat = doc_cat_vm;
            REQUEST_PARA_OBJ.doc_type = doc_cat_vm;
            //MasterEntity.ValidateAsync().Wait();
            PUR_T005.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            PUR_T005_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            NotificationDataCollection = new List<NotificationData>();
            LoadInitialData();
        }

        #endregion

        #region LoadInitialData
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (MasterEntity.location_Id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + (MasterEntity.doc_type ?? doc_cat_vm) + "!@" + MasterEntity.curr_code + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.UserID + "!@" + ts_code_vm;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MC, Request, "PUR_T005_BL", "FICO", "LoadAll", 0, "");
                #region 
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdRoundUpManual = new RelayCommand<object>(items => { if (items == null) { return; } InsertRoundUpManual(items, isNewRecord); });
                cmdInsertItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara, true, true, true); });
                cmdDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
                cmdExecuteReferenceDocument = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } ExecuteReferenceDocument(cmdPara, "FlipGridReference"); });
                cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                cmdAddSelectedTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSelectedTax(cmdPara); });
                cmdDeleteTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteTax(cmdPara); });
                ManualTaxChangedCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertManualTaxChangedCommand(cmdPara); });
                TaxPopupCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertManualTaxChangedCommand(cmdPara); });
                cmdLicence = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicence(cmdPara, false, true, true); });
                cmdDeleteDataGridRowLicence = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_ItemLicence(cmdPara); });// confirm assignment
                cmdCondiionType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertConditiontype(cmdPara); });
                cmdCurrency = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCurrency(cmdPara); });
                cmdLoadBackFlip = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadBackFlipData(cmdPara); });
                cmdOpenAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenDocumentViewer(cmdPara); });
                cmdCollectReferenceDocuments = new RelayCommand<object>(items => { if (items == null) { return; } CollectReferenceDocuments(items); });
                cmdServiceProvider = new RelayCommand<object>(items => { if (items == null) { return; } InsertServiceProvider(items); });
                cmdInsertWithholding = new RelayCommand<object>(items => { if (items == null) { return; } InsertWithholding(items); });
                cmdTraceReport = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } TraceReport(cmdPara); });
                cmdSelectionChanged_Condition = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } SelectionChanged_Condition(cmdPara); });
                cmdSelectionChanged_Item = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } SelectionChanged_Item(cmdPara); });
                cmdSelectionChanged_License = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } SelectionChanged_License(cmdPara); });

                #endregion
                #region Autosuggest
                // NOTE: if this single line declaration work for default AutoSUggest object then we will remove below commeted code throughout Project.
                AS_DEFAULT = new AutoSuggestTextViewModel<dynamic>(MC.INCOTERM_LIST, TheFilter, SuggestedValue, "incoterms", "incoterm", true);
                AS_DEFAULT_1 = new AutoSuggestTextViewModel<dynamic>(MC.INCOTERM_LIST, TheFilter, SuggestedValue, "incoterms", "incoterm", true);
                AS_DEFAULT_2 = new AutoSuggestTextViewModel<dynamic>(MC.INCOTERM_LIST, TheFilter, SuggestedValue, "incoterms", "incoterm", true);

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).incoterm);
                //TheFilter = (o, prefix) => (((STD_LIST_BE)o).incoterm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).inco_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //AS_DEFAULT = new AutoSuggestTextViewModel<dynamic>(MC.INCOTERM_LIST, TheFilter, SuggestedValue, "incoterms", "incoterm", true);
                //AS_DEFAULT.AutoSuggestVM.IsEmptyValueAllowed = true; AS_DEFAULT.AutoSuggestVM.IsFreeTextAllowed = true;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).incoterm);
                //TheFilter = (o, prefix) => (((STD_LIST_BE)o).incoterm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).inco_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //AS_DEFAULT_1 = new AutoSuggestTextViewModel<dynamic>(MC.INCOTERM_LIST, TheFilter, SuggestedValue, "incoterms", "incoterm", true);
                //AS_DEFAULT_1.AutoSuggestVM.IsEmptyValueAllowed = true; AS_DEFAULT_1.AutoSuggestVM.IsFreeTextAllowed = true;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).incoterm);
                //TheFilter = (o, prefix) => (((STD_LIST_BE)o).incoterm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).inco_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //AS_DEFAULT_2 = new AutoSuggestTextViewModel<dynamic>(MC.INCOTERM_LIST, TheFilter, SuggestedValue, "incoterms", "incoterm", true);
                //AS_DEFAULT_2.AutoSuggestVM.IsEmptyValueAllowed = true; AS_DEFAULT_2.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code);
                TheFilter = (o, prefix) => ((STD_ITEM)o).item_code.ToString().ToLower().Contains(prefix) || ((STD_ITEM)o).item_name.ToString().ToLower().Contains(prefix);
                AS_ITEM = new AutoSuggestTextViewModel<dynamic>(MC.STD_ITEM_LIST, TheFilter, SuggestedValue, "ItemCode", "item_code", true);
                AS_ITEM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ITEM.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((ACC_M003_P)o).gl_name ?? "").ToString().ToLower().Contains(prefix);
                AS_TAX_ACC = new AutoSuggestTextViewModel<dynamic>(MC.GL_ACCOUNT_LIST, TheFilter, SuggestedValue, "gl_code", "gl_code", true);
                AS_TAX_ACC.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_FICO_BE)x).lic_cod);
                TheFilter = (o, prefix) => (((STD_FICO_BE)o).lic_cod ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((STD_FICO_BE)o).lic_type ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_LICENCE = new AutoSuggestTextViewModel<dynamic>(MC.LICENCE_LIST, TheFilter, SuggestedValue, "licence_no", "lic_cod", true);
                AS_LICENCE.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_FICO_BE)x).con_type);
                TheFilter = (o, prefix) => (((STD_FICO_BE)o).con_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_FICO_BE)o).con_desc ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_FICO_BE)o).con_cat ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_FICO_BE)o).pricing_pro ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_TAX_CONDITION_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.CONDITION_TYPE_LIST, TheFilter, SuggestedValue, "con_type", "con_type", true);
                AS_TAX_CONDITION_TYPE.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M037)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_CURRENCY = new AutoSuggestTextViewModel<dynamic>(MC.CURRENCY_LIST, TheFilter, SuggestedValue, "curr_code", "curr_code", true);
                AS_CURRENCY.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_FICO_BE)x).wtax_code);
                TheFilter = (o, prefix) => (((STD_FICO_BE)o).wtax_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_FICO_BE)o).wtax_ncode ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_WITHHOLDING = new AutoSuggestTextViewModel<dynamic>(MC.WITHHOLDING_LIST, TheFilter, SuggestedValue, "withholding_tax", true);
                AS_WITHHOLDING.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).party_code);
                TheFilter = (o, prefix) => (((STD_PARTY)o).party_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).party_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_SERVICE_PROVIDER = new AutoSuggestTextViewModel<dynamic>(MC.PARTY_LIST, TheFilter, SuggestedValue, "PartyId", "party_code", true);
                AS_SERVICE_PROVIDER.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion

                PopupItemCollection = CollectionViewSource.GetDefaultView(MC.STD_ITEM_LIST);
                PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);

                REF_DOC_COLLECTION = CollectionViewSource.GetDefaultView(MC.REF_DOC_LIST);
                REF_DOC_COLLECTION.Filter = new Predicate<object>(Filter_ReferenceDoc);

                TaxDictonery = new Dictionary<string, object>();
                TaxDictonery.Clear();
                TaxDictonery = MC.TAX_LIST.ToDictionary(X => X.id.ToString(), X => (object)X.description);
                var TaxListParent = (from o in MC.TAX_LIST
                                     where o.parent_id == null
                                     select o).ToList();
                SelectedTaxList = TaxListParent;
                TaxDictoneryParent = SelectedTaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);
                MasterEntity.local_curr = ((List<ADM_M002>)AppSessionState.ADM_M002_List)[0].curr_code;

                NotificationDataCollection = MC.NOTIFICATION_LIST;

                DefaultValues();
                can_edit = true;
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private string _filterString_ItemsListPopup;
        public string FilterString_ItemsListPopup
        {
            get { return _filterString_ItemsListPopup; }
            set
            {
                _filterString_ItemsListPopup = value;
                RaisePropertyChanged("FilterString_ItemsListPopup");
                FilterCollection_ItemsListPopup();
            }
        }
        private void FilterCollection_ItemsListPopup()
        {
            if (_popupItemCollection != null)
            {
                _popupItemCollection.Refresh();
            }
        }
        public bool Filter_ItemsListPopup(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_ItemsListPopup))
                {
                    return (data.item_name != null && data.item_name.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower()) ||
                           (data.item_code != null && data.item_code.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            (data.cat_code != null && data.cat_code.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            data.item_cat != null && data.item_cat.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower()));
                }
                return true;
            }
            return false;
        }
        private void OpenDocumentViewer(object InputValue)
        {
            try
            {
                WebServiceRepository<MultipleContext_Attachments> repository_MCAttachments = new WebServiceRepository<MultipleContext_Attachments>();
                List<COM_T003> Attachments = new List<COM_T003>();
                PUR_T005_A EntityObjectParameter = new PUR_T005_A();
                MultipleContext_Attachments MCAttachments = new MultipleContext_Attachments();

                if (InputValue != null)
                {
                    EntityObjectParameter = ((IEnumerable)InputValue).Cast<PUR_T005_A>().ToList()[0];
                }
                //string Request = "GetAllFiles" + "!@" + EntityObjectParameter.ItemCode;
                string Request = "GetAllFiles" + "!@" + AppSessionState.client + "!@" + (EntityObjectParameter.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (EntityObjectParameter.location_Id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + (MasterEntity.doc_cat ?? "") + "!@" + (MasterEntity.doc_type ?? "") + "!@" + EntityObjectParameter.doc_no + "!@" + EntityObjectParameter.id.ToString();
                //MCAttachments = repository_MCAttachments.GetData<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Reflection.BusinessLogic.ReflectionFileHandlingServices");
                MCAttachments = repository_MCAttachments.GetDataWithReturnDomainObject<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                if (!string.IsNullOrEmpty(EntityObjectParameter.ItemCode))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), Row_ID = EntityObjectParameter.id.ToString(), DocumentList = MCAttachments.Attachments, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void UpdateQtyInLicence()
        {
            try
            {
                foreach (var m in LicenceDetailsEntity)
                {
                    foreach (var o in ItemsEntity)
                    {
                        if (o.ItemCode == m.ItemCode)
                        {
                            m.qty = o.qty;
                        }
                    }
                }
            }
            catch (Exception Ex) { }
        }
        private void DefaultValues()
        {
            EntityChangeEnable = true;
            MasterEntity.doc_cat = doc_cat_vm;
            MasterEntity.doc_type = doc_cat_vm;
            //MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            //MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.active = true;
            MasterEntity.local_currency = AppSessionState.OBJ_COMPANY.curr_code;
            //NOTE: t_status & t_display need to fetch with execute method, not required here. add logic in SQL for this kind of Transactions.
            //MasterEntity.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
            //MasterEntity.t_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_display).FirstOrDefault();

            REQUEST_PARA_OBJ.active = true;
            REQUEST_PARA_OBJ.from_date = DateTime.Now;
            REQUEST_PARA_OBJ.to_date = DateTime.Now;
            REQUEST_PARA_OBJ.doc_type = MasterEntity.doc_type;
            REQUEST_PARA_OBJ.doc_cat = doc_cat_vm;
            REQUEST_PARA_OBJ.doc_cat = (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code);

            if (MC.DOC_TYPE_LIST != null && !string.IsNullOrWhiteSpace(MasterEntity.doc_type))
            {
                AutoRoundupEnable = (bool)(MC.DOC_TYPE_LIST.Find(x => x.doc_type == MasterEntity.doc_type).auto_roundup ?? false);
                RoundUpDecimals = (int)(MC.DOC_TYPE_LIST.Find(x => x.doc_type == MasterEntity.doc_type).roundup_digits ?? 2);
            }
        }
        private void Logging()
        {
            MasterEntity.ts_code = this.ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;

            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private bool validation()
        {
            try
            {
                if (MasterEntity.PartyId == null || MasterEntity.PartyId == "")
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Party.......", this.Title); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.post_date == null)
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Party.......", this.Title); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.po_code == null || MasterEntity.po_code == "")
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Purchase Organisation Code.......", this.Title); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.pg_code == null || MasterEntity.pg_code == "")
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Purchase Group Code.......", this.Title); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.curr_code == null || MasterEntity.curr_code == " ")
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Enter Currency Code.....", this.Title); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.local_currency == MasterEntity.curr_code)
                {
                    MasterEntity.exch_rate = 1;
                }
                if (MasterEntity.ind_trade == null || MasterEntity.ind_trade == "")
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Transation Type is Required...", this.Title); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.exch_rate == null || MasterEntity.exch_rate == 0)
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Exchange Rate...", this.Title); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.order_limit_tax == true)
                {
                    if (MasterEntity.order_limit < MasterEntity.roundup_total)//when form is blank and we save the record
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Invoice value Exceeds Maximum Order value...", this.Title); sms.ShowMessage();
                        return true;
                    }
                }
                else if (MasterEntity.order_limit_tax == false)
                {
                    if (MasterEntity.order_limit < MasterEntity.ass_value)//when form is blank and we save the record
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Invoice value Exceeds Maximum Order value....", this.Title); sms.ShowMessage();
                        return true;
                    }
                }
                if (ItemsEntity.Count < 1)//when form is blank and we save the record
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("At Least Insert One Item...........", this.Title); sms.ShowMessage();
                    return false;
                }
                else
                {
                    foreach (var o in ItemsEntity)
                    {
                        if (o.ItemCode != null && o.ItemCode != "" && o.item_desc != null)
                        {
                            int flag = 0;
                            if (o.id == 0)
                            {
                                foreach (var p in ItemsEntity)
                                {
                                    if (o.ItemCode == p.ItemCode && o.sku == p.sku && o.ref_doc_no == p.ref_doc_no && o.po_no == p.po_no && o.line_id == p.line_id && p.active == true)
                                    {
                                        flag++;
                                    }
                                }
                                if (flag > 1)
                                {
                                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1}", o.ItemCode, o.sku_desc); sms.ShowMessage();
                                    return false;
                                }
                            }

                            if (o.qty == null || o.qty == 0)
                            {
                                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Quantity cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc); sms.ShowMessage();
                                return false;
                            }
                            if (o.unit_price == null || o.unit_price == 0)
                            {
                                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Unit Price cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc); sms.ShowMessage();
                                return false;
                            }
                            if (o.tax_id != null || o.tax_id != "")
                            {
                                if (TotalDocumentTaxes.Count > 0)
                                {
                                    for (int i = 0; i < TotalDocumentTaxes.Count; i++)
                                    {

                                        if (TotalDocumentTaxes[i].con_type == null || TotalDocumentTaxes[i].con_type == "")
                                        {
                                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Condition Type is Required for Tax {0} ", TotalDocumentTaxes[i].tax_name); sms.ShowMessage();
                                            return false;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("please select Item ...........", this.Title); sms.ShowMessage();
                            return false;
                        }
                    }
                }
                if (MasterEntity.t_status == (from o in MC.STATUS_LIST where o.ind_valid == "1" select o.t_status).FirstOrDefault())
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Invoice Validated......", this.Title); sms.ShowMessage();
                    return false;
                }
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("...", this.Title); sms.ShowMessage();
            }
            return true;
        }
        private void DeleteDataGridRow_ItemLicence(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (LicenceDetailsEntity.Count > i)
                {
                    LicenceDetailsEntity.RemoveAt(i);
                    Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertLicence(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                STD_FICO_BE POPUPEntityObject = null;
                dgSelectedIndexItemLicence = dgSelectedIndexItemLicence;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.LICENCE_LIST.Where(x => x.lic_cod.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_FICO_BE>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    if (dgSelectedIndexItemLicence >= 0 && LicenseObject != null) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        LicenseObject.licence_no = POPUPEntityObject.lic_cod;
                    }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
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
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                    AppSessionState.ViewOtherRecordAllowed = true;
                }
                else
                {
                    DefaultValues();
                }

            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertRoundUpManual(object InputValue, bool OverrideValue)
        {
            try
            {
                string Request = "";
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        MasterEntity.round_up = Convert.ToDecimal(Request);
                        Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
                    }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertConditiontype(object InputValue)
        {
            try
            {
                string Request = "";
                STD_FICO_BE POPUPEntityObject = null;
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.CONDITION_TYPE_LIST.Where(x => x.con_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_FICO_BE>().ToList()[0];
                    }
                }
                catch (Exception) { }
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (ConditionObject == null)
                    {
                        TotalDocumentTaxes.Add(new ACC_T006_C()
                        {
                            con_type = POPUPEntityObject.con_type,
                            con_cat = POPUPEntityObject.con_cat,
                            trns_key_code = POPUPEntityObject.trns_key_code
                        });
                    }
                    else if (TotalDocumentTaxes.Count > dgSelectedIndexTaxSummury)
                    {
                        ConditionObject.con_type = POPUPEntityObject.con_type;
                        ConditionObject.con_cat = POPUPEntityObject.con_cat;
                        ConditionObject.trns_key_code = POPUPEntityObject.trns_key_code;
                    }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertCurrency(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M037 POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.CURRENCY_LIST.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M037>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    ConditionObject.curr_code = POPUPEntityObject.curr_code;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void LoadBackFlipData(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + REQUEST_PARA_OBJ.location_id + "!@" + doc_cat_vm + "!@" + (REQUEST_PARA_OBJ.doc_type ?? "") + "!@!@" + AppSessionState.UserID + "!@" + (Utilities.NullIf(REQUEST_PARA_OBJ.emp_id) ?? AppSessionState.EmpId) + "!@" + ts_code_vm + "!@" + (REQUEST_PARA_OBJ.org_code ?? "") + "!@" + (REQUEST_PARA_OBJ.group_code ?? "") + "!@" + (REQUEST_PARA_OBJ.party_code ?? "") + "!@!@" + REQUEST_PARA_OBJ.active + "!@" + REQUEST_PARA_OBJ.t_status + "!@" + Convert.ToDateTime(REQUEST_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQUEST_PARA_OBJ.to_date).ToString("MM/dd/yyyy");
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, Request, "PUR_T005_BL", "FICO", "LoadAll", 0, "");

                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MCTemp.BACK_FLIP_LIST);
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(Filter_FlipGrid);
                var msg = new NotificationMessage(ts_code_vm);Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                        { POPUPEntityObject = MC.STD_ITEM_LIST.Where(x => x.item_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_ITEM>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = ItemsEntity.Where(x => x.ItemCode == POPUPEntityObject.item_code).FirstOrDefault();
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.item_code).FirstOrDefault());
                    var LineId = ItemsEntity.Count + 1;
                    if (InputValueIfExists == null && IndexOfExistValue == -1) // && ItemsEntity.Count == dgSelectedIndexItem)
                    {
                        ItemsEntity.Add(new PUR_T005_A()
                        {
                            id = 0,
                            ItemCode = POPUPEntityObject.item_code,
                            item_desc = POPUPEntityObject.item_name,
                            SubCatCode = POPUPEntityObject.item_subcat,
                            StockUnt = Convert.ToBoolean(POPUPEntityObject.stock_unit),
                            ref_doc_no = ItemsEntity[0].po_no,
                            // ref_doc_type = MasterEntity.ref_doc_type,
                            ref_doc_type = String.IsNullOrEmpty(MasterEntity.ref_doc_no) ? "" : MasterEntity.ref_doc_type,
                            tax_id = POPUPEntityObject.tax_id,
                            // NOTE: unit_code and unit_price need to fetch from catlog. catlod will load on Reference Document Execution.
                            //unit_code = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM,
                            //unit_price = String.IsNullOrEmpty(POPUPEntityObject.Rate_Catlog.ToString()) ? POPUPEntityObject.rate : POPUPEntityObject.Rate_Catlog,
                            unit_code = POPUPEntityObject.unit_code,
                            unit_price = POPUPEntityObject.unit_price,
                            qty = POPUPEntityObject.qty,
                            //subtotal = POPUPEntityObject.sub,
                            active = true,
                            line_id = LineId,
                            location_Id = MasterEntity.location_Id,
                            comp_code = MasterEntity.comp_code,
                            add_by = AppSessionState.UserID,
                            client = AppSessionState.client,
                            item_cat = POPUPEntityObject.item_cat,
                            t_status = MasterEntity.t_status,
                            po_no = ItemsEntity[0].po_no,
                            //ship_to_Party = MasterEntity.ship_to_party,
                            //ship_to_add = MasterEntity.del_address,
                            buss_place = MasterEntity.buss_place,
                            doc_no = MasterEntity.doc_no,
                            PartyId = MasterEntity.PartyId,
                            curr_code = MasterEntity.curr_code,
                            pur_doc_no = ItemsEntity[0].po_no,
                            po_code = MasterEntity.po_code,
                            pg_code = MasterEntity.pg_code,
                            dc_code = MasterEntity.dc_code,
                            div_code = MasterEntity.div_code,
                            cost_center = MasterEntity.cost_center,
                            order_no = ItemsEntity[0].po_no
                        });
                    }
                    else if (dgSelectedIndexItem >= 0 && ItemEntityObject != null)
                    {
                        if (ItemEntityObject.line_id == 0)
                        {
                            ItemEntityObject.line_id = ItemsEntity.Count;
                        }
                        ItemEntityObject.ItemCode = POPUPEntityObject.item_code;
                        ItemEntityObject.item_desc = POPUPEntityObject.item_name;
                        ItemEntityObject.StockUnt = Convert.ToBoolean(POPUPEntityObject.stock_unit);
                        ItemEntityObject.SubCatCode = POPUPEntityObject.item_subcat;
                        ItemEntityObject.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                        ItemEntityObject.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        ItemEntityObject.add_by = AppSessionState.UserID;
                        ItemEntityObject.active = true;
                        if(ItemsEntity.Count > 0 && POPUPEntityObject.item_cat=="SE")
                        {
                            ItemEntityObject.ref_doc_no = ItemsEntity[0].ref_doc_no;
                            ItemEntityObject.ref_doc_type = ItemsEntity[0].ref_doc_type;
                            ItemEntityObject.ref_doc_cat = ItemsEntity[0].ref_doc_cat;
                        }
                        ItemEntityObject.tax_id = POPUPEntityObject.tax_id;
                        // NOTE: unit_code & unit_price need to get from catlog at the time of Reference Document Execution. if not exists then use second option.
                        ItemEntityObject.unit_code = POPUPEntityObject.unit_code;
                        //ItemEntityObject.unit_price = POPUPEntityObject.rate;
                        ItemEntityObject.qty = POPUPEntityObject.qty;
                        //ItemEntityObject.subtotal = POPUPEntityObject.sub_total;
                        ItemEntityObject.item_cat = POPUPEntityObject.item_cat;
                        ItemEntityObject.po_no = ItemsEntity[0].po_no;
                        //ItemEntityObject.ship_to_Party = MasterEntity.ship_to_party;
                        //ItemEntityObject.ship_to_add = MasterEntity.del_address;
                        ItemEntityObject.buss_place = MasterEntity.buss_place;
                        ItemEntityObject.t_status = MasterEntity.t_status;
                        ItemEntityObject.doc_no = MasterEntity.doc_no;
                        ItemEntityObject.PartyId = MasterEntity.PartyId;
                        ItemEntityObject.curr_code = MasterEntity.curr_code;
                        ItemEntityObject.pur_doc_no = ItemsEntity[0].po_no;
                        ItemEntityObject.po_code = MasterEntity.po_code;
                        ItemEntityObject.pg_code = MasterEntity.pg_code;
                        ItemEntityObject.dc_code = MasterEntity.dc_code;
                        ItemEntityObject.div_code = MasterEntity.div_code;
                        ItemEntityObject.cost_center = MasterEntity.cost_center;
                        ItemEntityObject.order_no = POPUPEntityObject.ItemCode;
                        ItemEntityObject.pur_doc_item_cd = POPUPEntityObject.ItemCode;
                        ItemEntityObject.pur_doc_item_cd = ItemsEntity[0].po_no;
                    }
                }
                #region Clear Empty Row
                PUR_T005_A newObj = new PUR_T005_A();
                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
                    {
                        ItemsEntity.RemoveAt(i);
                        if (ItemsEntity.Count == 0)
                        {
                            ItemsEntity.Add(newObj);
                        }
                    }
                }
                #endregion
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertSelectedTax(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003 POPUPEntityObject = null;
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.GL_ACCOUNT_LIST.Where(x => x.gl_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003>().ToList()[0];
                    }
                }
                catch (Exception) { }
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (TotalDocumentTaxes.Count == dgSelectedIndexTaxSummury && ConditionObject != null)
                    {
                        TotalDocumentTaxes.Add(new ACC_T006_C()
                        {
                            gl_code = POPUPEntityObject.gl_code,
                            symbol = MasterEntity.symbol
                        });
                    }
                    else if (TotalDocumentTaxes.Count > dgSelectedIndexTaxSummury)
                    {
                        ConditionObject.gl_code = POPUPEntityObject.gl_code;
                        ConditionObject.symbol = MasterEntity.symbol;
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i && ItemEntityObject.id == 0)
                {
                    ItemsEntity.RemoveAt(i);
                    Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
                }
            }
            catch (Exception ex)
            {}
        }
        private void InsertManualTaxChangedCommand(object InputValue)
        {
            Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
        }
        private void DeleteTax(object InputValue)
        {
            try
            {
                ACC_T006_C taxObj = (ACC_T006_C)InputValue;
                if (taxObj.manual == "Manual")
                {
                    TotalDocumentTaxes.Remove(taxObj);
                }
                
                //if (TotalDocumentTaxes.Count > i)
                //{
                //    //TotalDocumentTaxes.Remove(TotalDocumentTaxes.Where(x => x.tax_name == TotalDocumentTaxes[i].tax_name).Single());
                //    List<ACC_T006_C> copyLocal = new List<ACC_T006_C>();
                //    copyLocal = TotalDocumentTaxes.ToList();
                //    foreach (var tax in copyLocal)
                //    {
                //        if (tax.tax_name == TotalDocumentTaxes[i].tax_name && tax.manual == "Manual")
                //        {
                //            TotalDocumentTaxes.Remove(tax);
                //        }
                //    }
                //    Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
                //}
            }
            catch (Exception Ex) { }
        }
        public List<PUR_T005_A> TempItemList { get; set; }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            EntityChangeEnable = false;
            CursorControl.SetBusyState();
            try
            {
                string Request = "";
                STD_LIST_BE ParameterEntityObject = null;
                if (ParameterObject != null)
                {
                    isNewRecord = false;
                    if (ParameterObject.GetType() == typeof(string) && ParameterReference == "DocumentNo")
                    {
                        Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@!@" + doc_cat_vm + "!@!@" + ParameterObject.ToString() + "!@!@" + AppSessionState.UserID + "!@" + ts_code_vm + "!@" + ParameterEntityObject.party_code; ;
                    }
                    else if (((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList()[0];
                        Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + (ParameterEntityObject.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@!@" + doc_cat_vm + "!@!@" + ParameterEntityObject.doc_no + "!@!@" + AppSessionState.UserID + "!@" + ts_code_vm + "!@" + ParameterEntityObject.party_code; ;
                    }
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, Request, "PUR_T005_BL", "FICO", "", 0, "");
                    if (MCTemp.MasterEntity.Count > 0)
                    {
                        MasterEntity = MCTemp.MasterEntity[0];
                        ItemsEntity = MCTemp.ItemsEntity;
                        TotalDocumentTaxes = MCTemp.TaxEntity;
                        AttachmentCollection = CollectionViewSource.GetDefaultView(MCTemp.ATTACHMENT_LIST);

                        if (TotalDocumentTaxes.Count() != '0')
                        {
                            TotalDocumentTaxes = MCTemp.TaxEntity;
                        }
                        else
                        {
                            MC.TaxEntity = new ObservableCollection<ACC_T006_C>();
                        }
                        if (MCTemp.LicenceEntity != null)
                        {
                            LicenceDetailsEntity.Clear();
                            LicenceDetailsEntity = MCTemp.LicenceEntity;
                        }
                        else
                        {
                            MCTemp.LicenceEntity = new ObservableCollection<ACC_T006_D>();
                        }
                        

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M025_P)x).wtax_code);
                        TheFilter = (o, prefix) => (((ACC_M025_P)o).wtax_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M025_P)o).wtax_ncode ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        AS_WITHHOLDING = new AutoSuggestTextViewModel<dynamic>(MCTemp.WITHHOLDING_LIST, TheFilter, SuggestedValue, "withholding_tax", true);
                        AS_WITHHOLDING.AutoSuggestVM.IsEmptyValueAllowed = true;
                        CalWithHoldingTax();

                        isNewRecord = false;
                        SelectedTabControlIndex = 0;
                        if (MasterEntity.loc_curr.HasValue)
                        {
                            if (MasterEntity.loc_curr > 0)
                            {
                                NumberToEnglish num = new NumberToEnglish();
                                MasterEntity.amt_in_wordsLoc = num.AmountInWords(Convert.ToDecimal(MasterEntity.loc_curr));
                            }
                        }
                        DefaultValues();
                        SelectedTabControlIndex = 0;
                        can_edit = false;
                        EntityChangeEnable = true;
                        var msg = new NotificationMessage(ts_code_vm);
                        Messenger.Default.Send<NotificationMessage>(msg);
                    }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }

        }
        private void ExecuteReferenceDocument(object ParameterObject, string ParameterReference)
        {
            EntityChangeEnable = false;
            CursorControl.SetBusyState();
            try
            {
                string Request = "";
                if (ParameterObject != null)
                {
                    if (ParameterObject.GetType() == typeof(string) && ParameterObject.ToString() == "ExecuteDocument") // This Block of code read parameter . First for string and Entity Object in else part.
                    {
                        if (string.IsNullOrWhiteSpace(ref_doc_list))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Refernece Selection"; sms.Text = String.Format("Please Select Refernece Document(s)", this.Title); sms.ShowMessage();
                        }
                        else
                        {
                            Request = "EXECUTE_REFERENCE" + "!@" + AppSessionState.client + "!@" + (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (MasterEntity.location_Id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + (MasterEntity.doc_type ?? doc_cat_vm) + "!@" + ref_doc_list + "!@" + ref_doc_cat + "!@" + AppSessionState.UserID + "!@" + ts_code_vm + "!@" + ref_party_code;
                            MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, Request, "PUR_T005_BL", "FICO", "", 0, "FlipData");

                            if (MCTemp.MasterEntity.Count > 0)
                            {
                                MasterEntity = MCTemp.MasterEntity[0];
                                DefaultValues();
                                MasterEntity.active = true;
                                MasterEntity.user_source1 = AppSessionState.UserSource1;
                                MasterEntity.user_source2 = AppSessionState.UserSource2;
                                //MasterEntity.userid = AppSessionState.UserID;
                                //MasterEntity.doc_date = DateTime.Now;
                                //MasterEntity.post_date = DateTime.Now;
                                //MasterEntity.inv_rec_date = DateTime.Now;
                                //MasterEntity.entry_time = Convert.ToString(new TimeSpan());
                                //MasterEntity.local_currency = CurrancyList[0].curr_code;
                                //MasterEntity.ts_code = ts_code_vm;
                                if (MasterEntity.local_currency == MasterEntity.curr_code)
                                {
                                    MasterEntity.exch_rate = 1;
                                }

                                if (MCTemp.ItemsEntity.Count > 0)
                                {
                                    ItemsEntity = new ObservableCollection<PUR_T005_A>();
                                    foreach (var item in MCTemp.ItemsEntity)
                                    {
                                        ItemsEntity.Add(item);
                                    }
                                }
                                else
                                {
                                    ItemsEntity = new ObservableCollection<PUR_T005_A>();
                                }
                                if (TotalDocumentTaxes.Count() != '0')
                                { }
                                else
                                {
                                    MC.TaxEntity = new ObservableCollection<ACC_T006_C>();
                                }
                                if (MCTemp.LicenceEntity != null)
                                {
                                    LicenceDetailsEntity.Clear();
                                    LicenceDetailsEntity = MCTemp.LicenceEntity;
                                }
                                else
                                {
                                    MCTemp.LicenceEntity = new ObservableCollection<ACC_T006_D>();
                                }
                                AttachmentCollection = CollectionViewSource.GetDefaultView(MC.ATTACHMENT_LIST);
                                int count = ItemsEntity.Count();
                                TotalDocumentTaxes.Clear();
                                for (int i = 0; i < count; i++)
                                {
                                    Computation(true, i, AutoRoundupEnable);
                                }
                                if (MasterEntity.loc_curr.HasValue)
                                {
                                    if (MasterEntity.loc_curr > 0)
                                    {
                                        NumberToEnglish num = new NumberToEnglish();
                                        MasterEntity.amt_in_wordsLoc = num.AmountInWords(Convert.ToDecimal(MasterEntity.loc_curr));
                                    }
                                }

                                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M025_P)x).wtax_code);
                                TheFilter = (o, prefix) => (((ACC_M025_P)o).wtax_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M025_P)o).wtax_ncode ?? "").ToString().ToLower().Contains(prefix.ToLower());
                                AS_WITHHOLDING = new AutoSuggestTextViewModel<dynamic>(MCTemp.WITHHOLDING_LIST, TheFilter, SuggestedValue, "withholding_tax", true);
                                AS_WITHHOLDING.AutoSuggestVM.IsEmptyValueAllowed = true;

                                if (MCTemp.WITHHOLDING_LIST.Count == 1)
                                {
                                    MasterEntity.withholding_tax = MCTemp.WITHHOLDING_LIST[0].wtax_code;
                                }
                            }
                        }
                    }
                    SelectedTabControlIndex = 0;
                    can_edit = false;
                    EntityChangeEnable = true;
                    var msg = new NotificationMessage(ts_code_vm); Messenger.Default.Send<NotificationMessage>(msg);
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }

        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.XmlDataDocument_PUR_T005_A != null)
                {
                    MC.ItemsEntity = (ObservableCollection<PUR_T005_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PUR_T005_A, MC.ItemsEntity);
                    ItemsEntity = MC.ItemsEntity;
                }
                else
                {
                    MC.ItemsEntity = new ObservableCollection<PUR_T005_A>();
                    ItemsEntity.Clear();
                }
                if (MasterEntity.XmlDataDocument_ACC_T006_C != null)
                {
                    MC.TaxEntity = (ObservableCollection<ACC_T006_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_T006_C, MC.TaxEntity);
                    TotalDocumentTaxes.Clear();
                    TotalDocumentTaxes = MC.TaxEntity;
                }
                else
                {
                    MC.TaxEntity = new ObservableCollection<ACC_T006_C>();
                }
                if (MasterEntity.XmlDataDocument_ACC_T006_D != null)
                {
                    MC.LicenceEntity = (ObservableCollection<ACC_T006_D>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_T006_D, MC.LicenceEntity);
                    LicenceDetailsEntity.Clear();
                    LicenceDetailsEntity = MC.LicenceEntity;
                }
                else
                {
                    MC.LicenceEntity = new ObservableCollection<ACC_T006_D>();
                }
             
                if (MasterEntity.loc_curr.HasValue)
                {
                    if (MasterEntity.loc_curr > 0)
                    {
                        NumberToEnglish num = new NumberToEnglish();
                        MasterEntity.amt_in_wordsLoc = num.AmountInWords(Convert.ToDecimal(MasterEntity.loc_curr));
                    }
                }
                else
                {
                    MasterEntity.amt_in_wordsLoc = null;
                }

                RemoveReferenceDocuments();
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }

        }
        private void RemoveReferenceDocuments()
        {
            try
            {
                foreach (PUR_T005_A item in ItemsEntity)
                {
                    if (item.ref_doc_no != null)
                    {
                        MC.REF_DOC_LIST.RemoveAll(X => X.ref_doc_cat == item.ref_doc_cat && X.ref_doc_no == item.ref_doc_no);
                    }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void CollectReferenceDocuments(object InputValue)
        {
            try
            {
                STD_LIST_BE POPUPEntityObject = null;
                string Request;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.REF_DOC_LIST.Where(x => x.ref_doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    ref_doc_list = "";
                    var ref_doc_filtered = from o in MC.REF_DOC_LIST
                                    where o.party_code == POPUPEntityObject.party_code
                                        && o.comp_code == POPUPEntityObject.comp_code
                                        && o.po_code == POPUPEntityObject.po_code
                                        && o.curr_code == POPUPEntityObject.curr_code
                                        && o.doc_cat == POPUPEntityObject.doc_cat
                                        && o.ref_doc_cat == POPUPEntityObject.ref_doc_cat
                                        && o.p_term_code == POPUPEntityObject.p_term_code
                                        && o.incoterm == POPUPEntityObject.incoterm
                                        && o.country_key == POPUPEntityObject.country_key
                                    select o;
                    foreach (var item in ref_doc_filtered)
                    {
                        if (item.selected == true)
                        {
                            ref_doc_list = ref_doc_list + "," + item.ref_doc_no;
                            ref_doc_cat = item.ref_doc_cat;
                            ref_party_code = item.party_code;
                        }
                    }
                    ref_doc_list = ref_doc_list.ToString().TrimStart(new char[] { ',' });

                    if (ref_doc_list != "")
                    {
                        REF_DOC_COLLECTION = CollectionViewSource.GetDefaultView(ref_doc_filtered);
                        REF_DOC_COLLECTION.Filter = new Predicate<object>(Filter_ReferenceDoc);
                    }
                    else
                    {
                        REF_DOC_COLLECTION = CollectionViewSource.GetDefaultView(MC.REF_DOC_LIST);
                        REF_DOC_COLLECTION.Filter = new Predicate<object>(Filter_ReferenceDoc);
                    }
                }
            }
            catch (Exception Ex) { }
        }
        private void FilterLicenceDataGrid()
        {
            try
            {
                if (LicenceDetailsEntity != null && LicenceDetailsEntity.Count > 0 && dgSelectedIndexItem >= 0 && ItemEntityObject != null)
                {
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertServiceProvider(object InputValue)
        {
            try
            {
                string Request = "";
                STD_PARTY POPUPEntityObject = null;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.PARTY_LIST.Where(x => x.party_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.party_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_PARTY>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    if (TotalDocumentTaxes.Count > 0 && ConditionObject != null)
                    {
                        ConditionObject.PartyId = POPUPEntityObject.party_code;
                        ConditionObject.PartyNm = POPUPEntityObject.party_name;
                    }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertWithholding(object InputValue)
        {
            try
            {
                string Request = "";
                STD_FICO_BE POPUPEntityObject = null;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WITHHOLDING_LIST.Where(x => x.wtax_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M004_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_FICO_BE>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.withholding_tax = POPUPEntityObject.wtax_code;
                }
            }
            catch (Exception ex) { }
        }
        private void TraceReport(object InputValue)
        {
            try
            {
                string Request = "";
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        Request = "Trace_Report" + "!" + Request;
                        string ReportName = "TraceReport_PI.rdlc";

                        MasterEntity.doc_desc = "PurchaseInvoice";
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, Request, "PUR_T005_BL", "FICO", "LoadAll", 0, "");

                        object[] objDataSource = new object[2];
                        string[] objDataSourceName = new string[2];

                        List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                        var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                        objDataSource[0] = CmpResult;
                        objDataSource[1] = MCTemp.TraceList;

                        objDataSourceName[0] = "dsCompany";
                        objDataSourceName[1] = "dsTraceList";


                        ReportManager ReportManager = new ReportManager();
                        string ReportDisplayName = "TraceReport" + "_" + MasterEntity.doc_no + "_" + MasterEntity.post_date.Value.ToShortDateString();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Procurment\\" + ReportName, getParametersList(), ReportDisplayName);



                    }
                }

            }
            catch (Exception ex) { }
        }
        private void SelectionChanged_Condition(object InputValue)
        {
            try
            {
                ConditionObject = (ACC_T006_C)InputValue;
            }
            catch (Exception ex) { }
        }
        private void SelectionChanged_Item(object InputValue)
        {
            try
            {
                ItemEntityObject = (PUR_T005_A)InputValue;
            }
            catch (Exception ex) { }
        }
        private void SelectionChanged_License(object InputValue)
        {
            try
            {
                LicenseObject = (ACC_T006_D)InputValue;
            }
            catch (Exception ex) { }
        }
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("prepare_by", MasterEntity.doc_no);
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
            return result;
        }
        #endregion

        #region Abstract Method
        protected override void OnCreateAction(InquiryActionResult<PUR_T005> result)
        {
            try
            {
                isNewRecord = true;
                MasterEntity = new PUR_T005();
                MasterEntity.ValidateAsync().Wait();
                ItemsEntity = new ObservableCollection<PUR_T005_A>();
                ItemsEntity.Clear();
                TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
                //TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_C>();
                dgTotalTaxSummury = new ObservableCollection<PUR_T005_B>();
                //TotalDocumentTaxesSummury.Clear();
                TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_C>();
                LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
                foreach (var item in MC.REF_DOC_LIST)
                {
                    item.selected = false;
                }
                REF_DOC_COLLECTION = CollectionViewSource.GetDefaultView(MC.REF_DOC_LIST);
                REF_DOC_COLLECTION.Filter = new Predicate<object>(Filter_ReferenceDoc);
                DefaultValues();
                can_edit = true;
                ref_doc_cat = null;
                var msg = new NotificationMessage(ts_code_vm);
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception Ex) { }
        }
        protected override void OnDiscardAction(InquiryActionResult<PUR_T005> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<PUR_T005> result)
        {
            try
            {
                if (MasterEntity.doc_no != null && MasterEntity.doc_no != "")
                {
                    if (MasterEntity.t_status != (from o in MC.STATUS_LIST where o.ind_valid == "1" select o.t_status).FirstOrDefault())
                    {
                        string Request = "ValidateInvoice" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_no + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.UserID + "!@" + ts_code_vm;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, Request, "PUR_T005_BL", "FICO", "LoadAll", 0, "");

                        if (MCTemp.MasterEntity.Count > 0)
                        {
                            if (MCTemp.MasterEntity[0].t_status == (from o in MC.STATUS_LIST where o.ind_validated == "1" select o.t_status).FirstOrDefault())
                            {
                                MasterEntity.t_status = MCTemp.MasterEntity[0].t_status;
                                MasterEntity.t_display = (from o in MC.STATUS_LIST where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();
                                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Invoice Validate Succesfully...", this.Title); sms.ShowMessage();
                            }
                        }
                    }
                    else if (MasterEntity.t_status == (from o in MC.STATUS_LIST where o.ind_valid == "1" select o.t_status).FirstOrDefault())
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Invoice Validated...", this.Title); sms.ShowMessage();
                    }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        protected override void OnFlipAction(InquiryActionResult<PUR_T005> result)
        {
            try
            {
                object objParam = MasterEntity.doc_no;
                string userAuth = "Reflection.Modules.Finance.Views.LedgerView"; // this one is path option
                string path1 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.Finance.dll");
                Assembly assembly = Assembly.LoadFile(path1);
                Type type = assembly.GetType(userAuth);
                if (type != null)
                {
                    dynamic instance = Activator.CreateInstance(type, objParam);
                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                }
            }
            catch (Exception ex)
            { }
        }
        protected override void OnHelpAction(InquiryActionResult<PUR_T005> result)
        {}
        protected override void OnPrintAction(InquiryActionResult<PUR_T005> result)
        {
            try
            {
                CursorControl.SetBusyState();
                object[] objDataSource = new object[5];
                string[] objDataSourceName = new string[5];

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[0] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.bill_address_id).ToList();
                objDataSource[1] = Result;

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
                objDataSource[3] = ItemsEntity;
                objDataSource[4] = TotalDocumentTaxes;

                objDataSourceName[0] = "dsCompany";
                objDataSourceName[1] = "dsLocation";
                objDataSourceName[2] = "dsMaster";
                objDataSourceName[3] = "dsItem";
                objDataSourceName[4] = "dsTax";

                ReportManager ReportManager = new ReportManager();
                var SystemDocumentObject = (from o in MC.DOC_TYPE_LIST where o.doc_cat == MasterEntity.doc_cat && o.doc_type == MasterEntity.doc_type select o).ToList();
                string ReportDisplayName = MasterEntity.supplier_party_Nm + "_" + MasterEntity.doc_no + "_" + MasterEntity.post_date.Value.ToShortDateString();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORTS_STD\\TXN\\" + SystemDocumentObject[0].report_name, getParametersList(), ReportDisplayName);
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        protected override void OnDocumentAction()
        {
            try
            {
                CursorControl.SetBusyState();
                if (!string.IsNullOrEmpty(MasterEntity.doc_no))
                {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MCTemp.ATTACHMENT_LIST, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) });
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        protected override void OnRefreshCommand(InquiryActionResult<PUR_T005> result)
        {
            LoadInitialData();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PUR_T005> result)
        {}

        protected override void OnValidateCommand(InquiryActionResult<PUR_T005> result)
        {}

        protected override void OnTraceCommand(InquiryActionResult<PUR_T005> result)
        {}

        protected override void OnMailCommand(InquiryActionResult<PUR_T005> result)
        {}
        protected override void OnRemoveAction(InquiryActionResult<PUR_T005> result)
        {
            try
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Delete Message"; 
                sms.Text =
                    String.Format(
                        "This record will delete forever '{0}'",
                            this.Title);
                if (sms.ShowMessage() == DialogResult.Ok)
                {
                    this.MasterEntity.CancelEdit();
                    string response = repository.Delete(MasterEntity.doc_no, "PUR_T005_BL", "FICO");
                    MasterEntity = new PUR_T005();
                    ItemsEntity = new ObservableCollection<PUR_T005_A>();
                    isNewRecord = true;
                }
            }
            catch (Exception ex)
            {}
        }
        protected override void OnSaveAction(InquiryActionResult<PUR_T005> result)
        {
            try
            {
                CursorControl.SetBusyState();
                if (validation() == true)
                {
                    Logging();

                    MasterEntity.XmlDataDocument_PUR_T005_A = obj.ObjectToXML(ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = obj.ObjectToXML(TotalDocumentTaxes);
                    MasterEntity.XmlDataDocument_ACC_T006_D = obj.ObjectToXML(LicenceDetailsEntity);

                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<PUR_T005>(MasterEntity, "PUR_T005_BL", "FICO");
                        SetBusinessEntitiesAfterLoad("Save", "");
                        if (MasterEntity.doc_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnInsert") >= 0)
                        {
                            NotifyMessage("OnInsert");
                        }
                        if (MasterEntity.doc_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnApproval") >= 0)
                        {
                            NotifyMessage("OnApproval");
                        }
                        if (MasterEntity.doc_no != "" || MasterEntity.doc_no != null)
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Data Saved Successfully", this.Title); sms.ShowMessage();
                        }
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<PUR_T005>(MasterEntity, "PUR_T005_BL", "FICO");
                        SetBusinessEntitiesAfterLoad("Save", "");
                        if (MasterEntity.doc_no != "" || MasterEntity.doc_no != null)
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Data Update Successfully", this.Title); sms.ShowMessage();
                        }
                    }
                    
                    isNewRecord = false;
                }
            }
            catch (Exception ex) { }
        }
        public string ConvertDataTableToHTML()
        {
            string html = "<table>";
            //add header row
            html += "<tr bgcolor=#e0e0eb>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Item Code </span></strong></p> </td>";
            html += "<td width=10%> <p><strong><span style=color:#000080;> Item Name </span></strong></p> </td>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Quantity </span></strong></p> </td>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Unit </span></strong></p> </td>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Unit Price </span></strong></p> </td>";
            html += "</tr>";

            foreach (var item in ItemsEntity)
            {
                if (item.active == true)
                {
                    html += "<tr bgcolor=#d9e6f2>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.ItemCode + "</p></span></strong></p> </td>";
                    html += "<td width=10%> <p><strong><span style=color:#000080;> " + item.item_desc + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.qty.ToString() + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.unit_code + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + (item.unit_price.HasValue ? decimal.Round(item.unit_price.Value, 2).ToString() : "") + "</span></strong></p> </td>";
                    html += "</tr>";
                }
            }
            html += "</table>";

            return html;
        }
        private void NotifyMessage(string AlertName)
        {
            try
            {
                List<NotificationData> objNotifyData = new List<NotificationData>();
                List<NotificationData> objNotifyDataTemp = new List<NotificationData>();
                NotificationData objNotifyDataObject = new NotificationData();
                string xx = ConvertDataTableToHTML();
                objNotifyDataTemp = NotificationDataCollection.Where(x => x.alert_name == AlertName).ToList();
                objNotifyDataTemp[0].CopyPropertiesTo<NotificationData>(objNotifyDataObject);
                objNotifyData.Add(objNotifyDataObject);
                foreach (NotificationData VarData in objNotifyData)
                {
                    List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("[CUR]",MasterEntity.curr_code.ToString()),
                    new KeyValuePair<string, string>("[OVAL]", MasterEntity.roundup_total.ToString()),
                    new KeyValuePair<string, string>("[CUST]","M/s: " + MasterEntity.supplier_party_Nm),
                    new KeyValuePair<string, string>("[EMP]",AppSessionState.Name),
                    new KeyValuePair<string, string>("[DOC]", MC.DOC_TYPE_LIST[0].doc_desc_user),
                    new KeyValuePair<string, string>("[DOCNO]", MasterEntity.doc_no),
                    new KeyValuePair<string, string>("[DOCDATE]", MasterEntity.doc_date.ToString()),
                    new KeyValuePair<string, string>("[Comp]","M/s: " + AppSessionState.CompanyName),
                    new KeyValuePair<string, string>("[Attn]",MC.NOTIFICATION_LIST[0].EmpName),
                };
                    foreach (KeyValuePair<string, string> kvp in kvpList)
                    {
                        VarData.subject = VarData.subject.Replace(kvp.Key, kvp.Value);
                        VarData.msg_body = VarData.msg_body.Replace(kvp.Key, kvp.Value);
                    }
                    VarData.cc_mail_id = (VarData.cc_mail_id ?? "") + ";" + (AppSessionState.EmpEmailId ?? "");
                    Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, VarData.to_mail_id, VarData.cc_mail_id, VarData.bcc_mail_id, VarData.subject, VarData.msg_body, null);

                }
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        #endregion

        #region Filter
        private string _filterString_FlipGrid;
        public string FilterString_FlipGrid
        {
            get { return _filterString_FlipGrid; }
            set
            {
                _filterString_FlipGrid = value;
                RaisePropertyChanged("FilterString_FlipGrid");
                FilterCollection_FlipGrid();
            }
        }
        private void FilterCollection_FlipGrid()
        {
            if (_BACKFLIP_COLLECTION != null)
            {
                _BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return (data.doc_no != null && (data.doc_no ?? "").ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.post_date != null && data.post_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.ref_doc_no != null && (data.ref_doc_no ?? "").ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.t_status != null && (data.t_status ?? "").ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.party_ref_no != null && (data.party_ref_no ?? "").ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.party_code != null && (data.party_code ?? "").ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.party_name != null && (data.party_name ?? "").ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _FilterString_ReferenceDoc;
        public string FilterString_ReferenceDoc
        {
            get { return _FilterString_ReferenceDoc; }
            set
            {
                _FilterString_ReferenceDoc = value;
                RaisePropertyChanged("FilterString_ReferenceDoc");
                FilterCollection_ReferenceDoc();
            }
        }
        private void FilterCollection_ReferenceDoc()
        {
            if (REF_DOC_COLLECTION != null)
            {
                REF_DOC_COLLECTION.Refresh();
            }
        }
        public bool Filter_ReferenceDoc(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_ReferenceDoc))
                {
                    return (data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.doc_cat_name != null && data.doc_cat_name.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.country_key != null && data.country_key.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.party_code != null && data.party_code.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.party_name != null && data.party_name.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower())
                       );
                }
                return true;
            }
            return false;
        }

        #endregion
    }
}
