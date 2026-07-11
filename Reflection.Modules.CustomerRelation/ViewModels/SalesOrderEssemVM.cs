using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using System.Collections.Specialized;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class SalesOrderEssemVM : WorkspaceViewModel<SEL_T001>
    {
        #region Variable Declaration
        bool isNewRecord = true;
        string PartyEmailId = "";
        string PersonEmailId = "";

        NumberToEnglish num = new NumberToEnglish();
        WebServiceRepository<SEL_T001> repository = new WebServiceRepository<SEL_T001>();
        WebServiceRepository<MultipleContext_SEL_T001> repository_MC = new WebServiceRepository<MultipleContext_SEL_T001>();
        WebServiceRepository<MultipleContext_SEL_T001> repository_MCTemp = new WebServiceRepository<MultipleContext_SEL_T001>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_SEL_T001 _MC = new MultipleContext_SEL_T001();
        public MultipleContext_SEL_T001 MC
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

        private MultipleContext_SEL_T001 _MCTemp = new MultipleContext_SEL_T001();
        public MultipleContext_SEL_T001 MCTemp
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

        private MultipleContext_SEL_T001 _MCTempp = new MultipleContext_SEL_T001();
        public MultipleContext_SEL_T001 MCTempp
        {
            get { return _MCTempp; }
            set
            {
                if (_MCTempp != value)
                {
                    _MCTempp = value; RaisePropertyChanged("MCTemp");
                }
            }
        }

        private SEL_T001 _MasterEntity;
        public SEL_T001 MasterEntity
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

        private ObservableCollection<SEL_T001_A> _ItemsEntity;
        //Data source for Items DataGrid
        public ObservableCollection<SEL_T001_A> ItemsEntity
        {
            get
            {
                return _ItemsEntity;
            }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value;
                    ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("ItemsEntity");
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
        private ObservableCollection<SEL_T001_E> _TermsConditionEntity;
        public ObservableCollection<SEL_T001_E> TermsConditionEntity
        {
            get
            {
                return _TermsConditionEntity;
            }
            set
            {
                if (_TermsConditionEntity != value)
                {
                    _TermsConditionEntity = value;
                    TermsConditionEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTerms);
                    RaisePropertyChanged("TermsConditionEntity");
                }
            }
        }


        private SEL_T002 _ScheduleEntity;
        public SEL_T002 ScheduleEntity
        {
            get
            {
                return _ScheduleEntity;
            }
            set
            {
                if (_ScheduleEntity != value)
                {
                    _ScheduleEntity = value;
                    RaisePropertyChanged("ScheduleEntity");
                }
            }
        }

        private ObservableCollection<SEL_T002_A> _ItemScheduleEntity;
        //Data Source for Schedule DataGrid
        public ObservableCollection<SEL_T002_A> ItemScheduleEntity
        {
            get
            {
                return _ItemScheduleEntity;
            }
            set
            {
                if (_ItemScheduleEntity != value)
                {
                    _ItemScheduleEntity = value;
                    // NotifyCollectionChangedEventHandler added to call CollectionChangedNotifyForSchedule function evry time. which will not work after one time use earlier.
                    ItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
                    RaisePropertyChanged("ItemScheduleEntity");
                }
            }
        }





        // List of item default or as per Party changes. * can be replace with ICollection View.
        public List<SEL_T001_P_SO_ItemsList> _ItemListForPopup;
        public List<SEL_T001_P_SO_ItemsList> ItemListForPopup
        {
            get
            {
                return _ItemListForPopup;
            }
            set
            {
                _ItemListForPopup = value;
                RaisePropertyChanged("ItemListForPopup");
            }
        }

        public List<ADM_M003> _locationList;
        public List<ADM_M003> LocationList
        {
            get
            {
                return _locationList;
            }
            set
            {
                _locationList = value;
                RaisePropertyChanged("LocationList");
            }
        }

        public List<ADM_M001_A_P> _SalesOrganisationList;
        public List<ADM_M001_A_P> SalesOrganisationList
        {
            get
            {
                return _SalesOrganisationList;
            }
            set
            {
                _SalesOrganisationList = value;
                RaisePropertyChanged("SalesOrganisationList");
            }
        }

        public List<ADM_M001_H_P> _SalesGroupList;
        public List<ADM_M001_H_P> SalesGroupList
        {
            get
            {
                return _SalesGroupList;
            }
            set
            {
                _SalesGroupList = value;
                RaisePropertyChanged("SalesGroupList");
            }
        }

        public List<ADM_M002> _companyList;
        public List<ADM_M002> CompanyList
        {
            get
            {
                return _companyList;
            }
            set
            {
                _companyList = value;
                RaisePropertyChanged("CompanyList");
            }
        }

        private bool _IsDocumentViewerShow;
        public bool IsDocumentViewerShow
        {
            get
            {
                return _IsDocumentViewerShow;
            }
            set
            {
                if (_IsDocumentViewerShow != value)
                {
                    _IsDocumentViewerShow = value;
                    RaisePropertyChanged("IsDocumentViewerShow");
                }
            }
        }

        private ObservableCollection<ACC_T006_B> _TotalDocumentTaxes;
        // All Document Taxes including Parent,Child & External
        public ObservableCollection<ACC_T006_B> TotalDocumentTaxes
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

        private ObservableCollection<ACC_T006_B> _TotalDocumentTaxesSummury;
        //Group by Taxes irespective of Items.
        public ObservableCollection<ACC_T006_B> TotalDocumentTaxesSummury
        {
            get
            {
                return _TotalDocumentTaxesSummury;
            }
            set
            {
                _TotalDocumentTaxesSummury = value;
                RaisePropertyChanged("TotalDocumentTaxesSummury");
            }
        }

        private ObservableCollection<ACC_T006_B> _TotalDocumentTaxesItem;
        // Taxes for selected item.
        public ObservableCollection<ACC_T006_B> TotalDocumentTaxesItem
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

        private ICollectionView _dataGridviewFilter;
        // This DataGridView filter Schedule Lines for selected item. it will show only schedule for selected item.
        public ICollectionView DataGridViewFilter
        {
            get { return _dataGridviewFilter; }
            set { _dataGridviewFilter = value; RaisePropertyChanged("DataGridViewFilter"); }
        }

        // Selected Index for Items DataGrid
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
                    FilterScheduleDataGrid();
                    if (TotalDocumentTaxesItem.Count > 0)
                    {
                        TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>(TotalDocumentTaxes.Where(tax => tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && tax.sku == ItemsEntity[dgSelectedIndexItem].sku && tax.item_line_id == ItemsEntity[dgSelectedIndexItem].id));
                    }
                }
            }
        }

        private int _dgSelectedIndexItemSchedule;
        // Selected Index for Items schedule DataGrid 
        public int dgSelectedIndexItemSchedule
        {
            get
            {
                return _dgSelectedIndexItemSchedule;
            }
            set
            {
                if (_dgSelectedIndexItemSchedule != value)
                {
                    _dgSelectedIndexItemSchedule = value;
                    RaisePropertyChanged("dgSelectedIndexItemSchedule");
                }
            }
        }
        private int _dgSelectedIndexRefDoc;
        public int dgSelectedIndexRefDoc
        {
            get
            {
                return _dgSelectedIndexRefDoc;
            }
            set
            {
                if (_dgSelectedIndexRefDoc != value)
                {
                    _dgSelectedIndexRefDoc = value;
                    RaisePropertyChanged("dgSelectedIndexRefDoc");
                }
            }
        }



        private int _dgSelectedIndexTerms;
        public int dgSelectedIndexTerms
        {
            get
            {
                return _dgSelectedIndexTerms;
            }
            set
            {
                if (_dgSelectedIndexTerms != value)
                {
                    _dgSelectedIndexTerms = value;
                    RaisePropertyChanged("dgSelectedIndexTerms");

                }
            }
        }
        private int _dgSelectedIndexTaxSummury;
        // Selected Index for Items schedule DataGrid 
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


        private List<SEL_T001_Flip> _FlipGridData;
        // Flip DataGrid Data Source
        public List<SEL_T001_Flip> FlipGridData
        {
            get { return _FlipGridData; }
            set
            {
                if (_FlipGridData != value)
                {
                    _FlipGridData = value;
                    RaisePropertyChanged("FlipGridData");
                }
            }
        }

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

        private List<ACC_M013_P> _SelectedTaxList;
        // Supporting for Filter Data Source for Parent Taxes. * can be remove.
        public List<ACC_M013_P> SelectedTaxList
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

        private List<COM_T003> _AttachmentCollection;
        public List<COM_T003> AttachmentCollection
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
        #region ICollection for Popup Control

        private ICollectionView _SupplierCollection;
        public ICollectionView SupplierCollection
        {
            get { return _SupplierCollection; }
            set
            {
                _SupplierCollection = value;
                RaisePropertyChanged("SupplierCollection");
            }
        }
        private ICollectionView _doc_typeCollection;
        public ICollectionView Doc_TypeCollection
        {
            get { return _doc_typeCollection; }
            set
            {
                _doc_typeCollection = value;
                RaisePropertyChanged("Doc_TypeCollection");
            }
        }
        private ICollectionView _dgTransporterCollection;
        public ICollectionView dgTransporterCollection
        {
            get { return _dgTransporterCollection; }
            set
            {
                _dgTransporterCollection = value;
                RaisePropertyChanged("dgTransporterCollection");
            }
        }


        private ICollectionView _GradeCollection;
        public ICollectionView GradeCollection
        {
            get { return _GradeCollection; }
            set
            {
                _GradeCollection = value;
                RaisePropertyChanged("GradeCollection");
            }
        }



        private ICollectionView _dgPOItemsFortaxval;
        public ICollectionView dgPOItemsFortaxval
        {
            get { return _dgPOItemsFortaxval; }
            set
            {
                _dgPOItemsFortaxval = value;
                RaisePropertyChanged("dgPOItemsFortaxval");
            }
        }


        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }

        private ICollectionView _partyCollection;
        public ICollectionView PartyCollection
        {
            get { return _partyCollection; }
            set { _partyCollection = value; RaisePropertyChanged("PartyCollection"); }
        }

        private ICollectionView _transporterCollection;
        public ICollectionView TransporterCollection
        {
            get { return _transporterCollection; }
            set { _transporterCollection = value; RaisePropertyChanged("TransporterCollection"); }
        }

        private ICollectionView _serviceProviderCollection;
        public ICollectionView ServiceProviderCollection
        {
            get { return _serviceProviderCollection; }
            set { _serviceProviderCollection = value; RaisePropertyChanged("ServiceProviderCollection"); }
        }

        private ICollectionView _uomCollection;
        public ICollectionView UomCollection
        {
            get { return _uomCollection; }
            set { _uomCollection = value; RaisePropertyChanged("UomCollection"); }
        }

        private ICollectionView _sellerCollection;
        public ICollectionView SellerCollection
        {
            get { return _sellerCollection; }
            set { _sellerCollection = value; RaisePropertyChanged("SellerCollection"); }
        }

        private ICollectionView _journalCollection;
        public ICollectionView journalCollection
        {
            get { return _journalCollection; }
            set
            {
                _journalCollection = value;
                RaisePropertyChanged("journalCollection");
            }
        }

        private ICollectionView _glCodeCollection;
        public ICollectionView GLCodeCollection
        {
            get { return _glCodeCollection; }
            set
            {
                _glCodeCollection = value;
                RaisePropertyChanged("GLCodeCollection");
            }
        }

        private ICollectionView _paytermCollection;
        public ICollectionView PayTermCollection
        {
            get { return _paytermCollection; }
            set { _paytermCollection = value; RaisePropertyChanged("PayTermCollection"); }
        }

        private ICollectionView _currencyCollection;
        public ICollectionView CurrencyCollection
        {
            get { return _currencyCollection; }
            set
            {
                _currencyCollection = value;
                RaisePropertyChanged("CurrencyCollection");
            }
        }

        private ICollectionView _sales_orgCollection;
        public ICollectionView Salse_OrgCollection
        {
            get { return _sales_orgCollection; }
            set
            {
                _sales_orgCollection = value;
                RaisePropertyChanged("Salse_OrgCollection");
            }
        }

        private ICollectionView _salse_GroupCollection;
        public ICollectionView Salse_GroupCollection
        {
            get { return _salse_GroupCollection; }
            set
            {
                _salse_GroupCollection = value;
                RaisePropertyChanged("Salse_GroupCollection");
            }
        }

        private ICollectionView _salse_DivCollection;
        public ICollectionView Salse_DivCollection
        {
            get { return _salse_DivCollection; }
            set
            {
                _salse_DivCollection = value;
                RaisePropertyChanged("Salse_DivCollection");
            }
        }

        private ICollectionView _itemcategoryCollection;
        public ICollectionView ItemcategoryCollection
        {
            get { return _itemcategoryCollection; }
            set
            {
                _itemcategoryCollection = value;
                RaisePropertyChanged("ItemcategoryCollection");
            }
        }

        private ICollectionView _cost_centerCollection;
        public ICollectionView Cost_CenterCollection
        {
            get { return _cost_centerCollection; }
            set
            {
                _cost_centerCollection = value;
                RaisePropertyChanged("Cost_CenterCollection");
            }
        }

        private ICollectionView _bankCollection;
        public ICollectionView BankCollection
        {
            get { return _bankCollection; }
            set
            {
                _bankCollection = value;
                RaisePropertyChanged("BankCollection");
            }
        }

        // Custom collection
        private ICollectionView _ballTypeCollection;
        public ICollectionView BallTypeCollection
        {
            get { return _ballTypeCollection; }
            set
            {
                _ballTypeCollection = value;
                RaisePropertyChanged("BallTypeCollection");
            }
        }

        private ICollectionView _ildCollection;
        public ICollectionView ILDCollection
        {
            get { return _ildCollection; }
            set
            {
                _ildCollection = value;
                RaisePropertyChanged("ILDCollection");
            }
        }

        private ICollectionView _wireTypeCollection;
        public ICollectionView WireTypeCollection
        {
            get { return _wireTypeCollection; }
            set
            {
                _wireTypeCollection = value;
                RaisePropertyChanged("WireTypeCollection");
            }
        }

        private ICollectionView _ballDiaCollection;
        public ICollectionView BallDiaCollection
        {
            get { return _ballDiaCollection; }
            set
            {
                _ballDiaCollection = value;
                RaisePropertyChanged("BallDiaCollection");
            }
        }

        private ICollectionView _inkCollection;
        public ICollectionView InkCollection
        {
            get { return _inkCollection; }
            set
            {
                _inkCollection = value;
                RaisePropertyChanged("InkCollection");
            }
        }

        // on party filter collection
        private ICollectionView _buyerCollection;
        public ICollectionView BuyerCollection
        {
            get { return _buyerCollection; }
            set { _buyerCollection = value; RaisePropertyChanged("BuyerCollection"); }
        }

        private ICollectionView _billingAddressCollection;
        public ICollectionView BillingAddressCollection
        {
            get { return _billingAddressCollection; }
            set { _billingAddressCollection = value; RaisePropertyChanged("BillingAddressCollection"); }
        }

        private ICollectionView _deliveryAddressCollection;
        public ICollectionView DeliveryAddressCollection
        {
            get { return _deliveryAddressCollection; }
            set { _deliveryAddressCollection = value; RaisePropertyChanged("DeliveryAddressCollection"); }
        }

        // collection for reference documents on load of partys details.
        private ICollectionView _ReferenceDocCollection;
        public ICollectionView ReferenceDocCollection
        {
            get { return _ReferenceDocCollection; }
            set { _ReferenceDocCollection = value; RaisePropertyChanged("ReferenceDocCollection"); }
        }

        private ICollectionView _LocationCollection;
        public ICollectionView LocationCollection
        {
            get { return _LocationCollection; }
            set { _LocationCollection = value; RaisePropertyChanged("LocationCollection"); }
        }

        private ICollectionView _PlantCollection;
        public ICollectionView PlantCollection
        {
            get { return _PlantCollection; }
            set { _PlantCollection = value; RaisePropertyChanged("PlantCollection"); }
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

        private ICollectionView _incotermsCollection;
        public ICollectionView IncotermsCollection
        {
            get { return _incotermsCollection; }
            set { _incotermsCollection = value; RaisePropertyChanged("Incoterms"); }
        }
        private ICollectionView _dgLocationCollection;
        public ICollectionView dgLocationCollection
        {
            get { return _dgLocationCollection; }
            set { _dgLocationCollection = value; RaisePropertyChanged("dgLocationCollection"); }
        }
        
        //ItemListForPopup
        private ICollectionView _popupItemCollection;
        public ICollectionView PopupItemCollection
        {
            get { return _popupItemCollection; }
            set { _popupItemCollection = value; RaisePropertyChanged("PopupItemCollection"); }
        }

        private ICollectionView _TermsConditionCollection;
        public ICollectionView TermsConditionCollection
        {
            get { return _TermsConditionCollection; }
            set { _TermsConditionCollection = value; RaisePropertyChanged("TermsConditionCollection"); }
        }

        private ICollectionView _CompanyCodeCollection;
        public ICollectionView CompanyCodeCollection
        {
            get { return _CompanyCodeCollection; }
            set { _CompanyCodeCollection = value; RaisePropertyChanged("CompanyCodeCollection"); }
        }

        #endregion
        #region StringList Variables

        private List<string> _strListDocType;
        public List<string> StringListDocumentTypes
        {
            get { return _strListDocType; }
            set
            {
                if (_strListDocType != value)
                {
                    _strListDocType = value;
                }
            }
        }


        private List<string> _StringListsupplier;
        public List<string> StringListsupplier
        {
            get { return _StringListsupplier; }
            set
            {
                if (_StringListsupplier != value)
                {
                    _StringListsupplier = value;
                }
            }
        }

        private List<string> _StringListdgTransporter;
        public List<string> StringListdgTransporter
        {
            get { return _StringListdgTransporter; }
            set
            {
                if (_StringListdgTransporter != value)
                {
                    _StringListdgTransporter = value;
                }
            }
        }

        private List<string> _srtListParty;
        public List<string> StringListParty
        {
            get { return _srtListParty; }
            set
            {
                if (_srtListParty != value)
                {
                    _srtListParty = value;
                }
            }
        }

        private List<string> _srtListTransporter;
        public List<string> StringListTransporter
        {
            get { return _srtListTransporter; }
            set
            {
                if (_srtListTransporter != value)
                {
                    _srtListTransporter = value;
                }
            }
        }

        private List<string> _srtListServiceProvider;
        public List<string> StringListServiceProvider
        {
            get { return _srtListServiceProvider; }
            set
            {
                if (_srtListServiceProvider != value)
                {
                    _srtListServiceProvider = value;
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

        private List<string> _strListSeller;
        public List<string> StringListSeller
        {
            get { return _strListSeller; }
            set
            {
                if (_strListSeller != value)
                {
                    _strListSeller = value;
                }
            }
        }

        private List<string> _strListJournal;
        public List<string> StringListJournal
        {
            get { return _strListJournal; }
            set
            {
                if (_strListJournal != value)
                {
                    _strListJournal = value;
                }
            }
        }

        private List<string> _strListGLCode;
        public List<string> StringListGLCode
        {
            get { return _strListGLCode; }
            set
            {
                if (_strListGLCode != value)
                {
                    _strListGLCode = value;
                }
            }
        }

        private List<string> _strListPayTerms;
        public List<string> StringListPayTerms
        {
            get { return _strListPayTerms; }
            set
            {
                if (_strListPayTerms != value)
                {
                    _strListPayTerms = value;
                }
            }
        }

        private List<string> _strListCurrency;
        public List<string> StringListCurrency
        {
            get { return _strListCurrency; }
            set
            {
                if (_strListCurrency != value)
                {
                    _strListCurrency = value;
                }
            }
        }

        private List<string> _strListSalesOrg;
        public List<string> StringListSalesOrg
        {
            get { return _strListSalesOrg; }
            set
            {
                if (_strListSalesOrg != value)
                {
                    _strListSalesOrg = value;
                }
            }
        }

        private List<string> _strListSalesGroup;
        public List<string> StringListSalesGroup
        {
            get { return _strListSalesGroup; }
            set
            {
                if (_strListSalesGroup != value)
                {
                    _strListSalesGroup = value;
                }
            }
        }

        private List<string> _strListSalesDivision;
        public List<string> StringListSalesDivision
        {
            get { return _strListSalesDivision; }
            set
            {
                if (_strListSalesDivision != value)
                {
                    _strListSalesDivision = value;
                }
            }
        }

        private List<string> _stringListItemCategory;
        public List<string> StringListItemCategory
        {
            get { return _stringListItemCategory; }
            set
            {
                if (_stringListItemCategory != value)
                {
                    _stringListItemCategory = value;
                }
            }
        }

        private List<string> _strListCostCenter;
        public List<string> StringListCostCenter
        {
            get { return _strListCostCenter; }
            set
            {
                if (_strListCostCenter != value)
                {
                    _strListCostCenter = value;
                }
            }
        }

        private List<string> _strListBanks;
        public List<string> StringListBanks
        {
            get { return _strListBanks; }
            set
            {
                if (_strListBanks != value)
                {
                    _strListBanks = value;
                }
            }
        }

        private List<string> _StringListTerms;
        public List<string> StringListTerms
        {
            get { return _StringListTerms; }
            set
            {
                if (_StringListTerms != value)
                {
                    _StringListTerms = value;
                }
            }
        }

        private List<string> _strListBallType;
        public List<string> StringListBallType
        {
            get { return _strListBallType; }
            set
            {
                if (_strListBallType != value)
                {
                    _strListBallType = value;
                }
            }
        }

        private List<string> _strListILD;
        public List<string> StringListILD
        {
            get { return _strListILD; }
            set
            {
                if (_strListILD != value)
                {
                    _strListILD = value;
                }
            }
        }

        private List<string> _strListWireType;
        public List<string> StringListWireType
        {
            get { return _strListWireType; }
            set
            {
                if (_strListWireType != value)
                {
                    _strListWireType = value;
                }
            }
        }

        private List<string> _strListBallDia;
        public List<string> StringListBallDia
        {
            get { return _strListBallDia; }
            set
            {
                if (_strListBallDia != value)
                {
                    _strListBallDia = value;
                }
            }
        }

        private List<string> _strListInk;
        public List<string> StringListInk
        {
            get { return _strListInk; }
            set
            {
                if (_strListInk != value)
                {
                    _strListInk = value;
                }
            }
        }

        private List<string> _strListBuyer;
        public List<string> StringListBuyer
        {
            get { return _strListBuyer; }
            set
            {
                if (_strListBuyer != value)
                {
                    _strListBuyer = value;
                }
            }
        }

        private List<string> _strListSoldToAddress;
        public List<string> StringListSoldToAddress
        {
            get { return _strListSoldToAddress; }
            set
            {
                if (_strListSoldToAddress != value)
                {
                    _strListSoldToAddress = value;
                }
            }
        }

        private List<string> _strListShipToAddress;
        public List<string> StringListShipToAddress
        {
            get { return _strListShipToAddress; }
            set
            {
                if (_strListShipToAddress != value)
                {
                    _strListShipToAddress = value;
                }
            }
        }

        List<string> _StringListTaxAcc;
        public List<string> StringListTaxAcc
        {
            get { return _StringListTaxAcc; }
            set
            {
                if (_StringListTaxAcc != value)
                {
                    _StringListTaxAcc = value;
                }
            }
        }

        private List<string> _stringListReferenceDoc;
        public List<string> StringListReferenceDoc
        {
            get { return _stringListReferenceDoc; }
            set
            {
                if (_stringListReferenceDoc != value)
                {
                    _stringListReferenceDoc = value;
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

        private List<string> _stringListLocations;
        public List<string> StringListLocations
        {
            get { return _stringListLocations; }
            set
            {
                if (_stringListLocations != value)
                {
                    _stringListLocations = value;
                }
            }
        }

        private List<string> _stringListIncoterms;
        public List<string> StringListIncoterms
        {
            get { return _stringListIncoterms; }
            set
            {
                if (_stringListIncoterms != value)
                {
                    _stringListIncoterms = value;
                }
            }
        }

        private List<string> _stringListLicenseAdvance;
        public List<string> StringListLicenseAdvance
        {
            get { return _stringListLicenseAdvance; }
            set
            {
                if (_stringListLicenseAdvance != value)
                {
                    _stringListLicenseAdvance = value;
                }
            }
        }

        private List<string> _stringListLicenseEPCG;
        public List<string> StringListLicenseEPCG
        {
            get { return _stringListLicenseEPCG; }
            set
            {
                if (_stringListLicenseEPCG != value)
                {
                    _stringListLicenseEPCG = value;
                }
            }
        }
        private List<string> _stringListLocationID;
        public List<string> StringListLocationID
        {
            get { return _stringListLocationID; }
            set
            {
                if (_stringListLocationID != value)
                {
                    _stringListLocationID = value;
                }
            }
        }
        private List<string> _StringListdgLocationID;
        public List<string> StringListdgLocationID
        {
            get { return _StringListdgLocationID; }
            set
            {
                if (_StringListdgLocationID != value)
                {
                    _StringListdgLocationID = value;
                }
            }
        }

        
        private List<string> _stringListPlant;
        public List<string> StringListPlant
        {
            get { return _stringListPlant; }
            set
            {
                if (_stringListPlant != value)
                {
                    _stringListPlant = value;
                }
            }
        }
        private List<string> _stringListCompanyCode;
        public List<string> StringListCompanyCode
        {
            get { return _stringListCompanyCode; }
            set
            {
                if (_stringListCompanyCode != value)
                {
                    _stringListCompanyCode = value;
                }
            }
        }

        #endregion
        #region Relay Commands Declaration
        public RelayCommand<object> Commandtransporter { get; private set; }
        public RelayCommand<object> cmddgLocation { get; private set; }
        public RelayCommand<object> cmdPlant { get; private set; }
        public RelayCommand<object> cmdSupplier { get; private set; }
        public RelayCommand<object> cmdTransporter { get; private set; }
        public RelayCommand<object> CommandDocType { get; private set; }
        public RelayCommand CommandLoadDocumentFromSource { get; private set; }
        public RelayCommand<object> CommandSoldToParty { get; private set; }
        public RelayCommand<object> CommandShipToParty { get; private set; }
        public RelayCommand<object> CommandNotifyParty { get; private set; }
        public RelayCommand<object> CommandTransporter { get; private set; }
        public RelayCommand<object> CommandServiceProvider { get; private set; }
        public RelayCommand<object> CommandUOM { get; private set; }
        public RelayCommand<object> CommandSeller { get; private set; }
        public RelayCommand<object> CommandJournal { get; private set; }
        public RelayCommand<object> CommandGLCode { get; private set; }
        public RelayCommand<object> CommandPayTerms { get; private set; }
        public RelayCommand<object> CommandCurrency { get; private set; }
        public RelayCommand<object> CommandSalseOrg { get; private set; }
        public RelayCommand<object> CommandSalseGroup { get; private set; }
        public RelayCommand<object> CommandSalseDivision { get; private set; }
        public RelayCommand<object> CommandItemCategory { get; private set; }
        public RelayCommand<object> CommandCostCenter { get; private set; }
        public RelayCommand<object> CommandBank { get; private set; }
        public RelayCommand<object> CommandNastroBank { get; private set; }
        public RelayCommand<object> CommandBallType { get; private set; }
        public RelayCommand<object> CommandILD { get; private set; }
        public RelayCommand<object> CommandWireType { get; private set; }
        public RelayCommand<object> CommandBallDia { get; private set; }
        public RelayCommand<object> CommandInk { get; private set; }
        public RelayCommand<object> CommandBuyer { get; private set; }
        public RelayCommand<object> CommandSoldToAddress { get; private set; }
        public RelayCommand<object> CommandReferenceDoc { get; private set; }
        public RelayCommand<object> CommandItem { get; private set; }
        public RelayCommand<object> CommandTerms { get; private set; }
        public RelayCommand<object> CommandShipToAddress { get; private set; }
        public RelayCommand<Boolean> CommandActiveInactiveCheck { get; private set; }
        public RelayCommand<object> CommandReferenceDocumentType { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByRefDocNumber { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridTerms { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowSchedule { get; private set; }
        public RelayCommand<object> CommandLocations { get; private set; }
        public RelayCommand<object> CommandLicenseAdvance { get; private set; }
        public RelayCommand<object> CommandLicenseEPCG { get; private set; }
        public RelayCommand<object> CommandIncoterms { get; private set; }
        public RelayCommand<object> cmdDeleteTax { get; private set; }
        public RelayCommand<object> CommandAddSelectedTax { get; private set; }
        public RelayCommand<object> ManualTaxChangedCommand { get; private set; }
        public RelayCommand<object> CommandGrade { get; private set; }
        public RelayCommand<object> cmdMail { get; private set; }
        public RelayCommand<object> cmdPrint { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }


        #endregion
        #region Constructor
        /// <summary>
        /// Constructor for ViewModel
        /// </summary>
        /// <param name="NA"></param>
        public SalesOrderEssemVM(): base()
        {
            IsDocumentViewerShow = false;

            MasterEntity = new SEL_T001();
            ItemsEntity = new ObservableCollection<SEL_T001_A>();
            ScheduleEntity = new SEL_T002();
            ItemScheduleEntity = new ObservableCollection<SEL_T002_A>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>();
            TermsConditionEntity = new ObservableCollection<SEL_T001_E>();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
            NotificationDataCollection = new List<NotificationData>();
            ItemListForPopup = new List<SEL_T001_P_SO_ItemsList>();
            FlipGridData = new List<SEL_T001_Flip>();
            MC = new MultipleContext_SEL_T001();
            MCTemp = new MultipleContext_SEL_T001();
            //MasterEntity.ValidateAsync().Wait();
            SEL_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            SEL_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            SEL_T002.ModelEntityUpdated += new EventHandler(ModelUpdated_ScheduleMaster);
            SEL_T002_A.ModelEntityUpdated += new EventHandler(ModelUpdated_ScheduleItem);

            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            ItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);

            #region Command Initialisation
           
            cmddgLocation = new RelayCommand<object>(items => { if (items == null) { return; } Insertdgplant(items); });
            cmdPlant = new RelayCommand<object>(items => { if (items == null) { return; } Insertplant(items); });
            cmdSupplier = new RelayCommand<object>(items => { if (items == null) { return; } InsertSupplier(items); });
            cmdTransporter = new RelayCommand<object>(items => { if (items == null) { return; } InsertdgTransporter(items); });
            CommandDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocType(items); });
            CommandLoadDocumentFromSource = new RelayCommand(() => LoadSourceDocument()); // confirm assignment
            CommandSoldToParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertSoldToParty(items, isNewRecord); });
            CommandShipToParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertShipToParty(items, isNewRecord); });
            CommandNotifyParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertNotifyParty(items, true); });
            CommandSoldToAddress = new RelayCommand<object>(items => { if (items == null) { return; } InsertSoldToAddress(items, true); });
            CommandShipToAddress = new RelayCommand<object>(items => { if (items == null) { return; } InsertShipToAddress(items, true); });
            CommandTransporter = new RelayCommand<object>(items => { if (items == null) { return; } InsertTransporter(items, false); });
            CommandServiceProvider = new RelayCommand<object>(items => { if (items == null) { return; } InsertServiceProvider(items, false); });
            CommandUOM = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOM(cmdPara, false, true, true); });
            CommandSeller = new RelayCommand<object>(items => { if (items == null) { return; } InsertSeller(items); });
            CommandGLCode = new RelayCommand<object>(items => { if (items == null) { return; } InsertGLCode(items); });
            CommandPayTerms = new RelayCommand<object>(items => { if (items == null) { return; } InsertPayTerm(items); });
            CommandCurrency = new RelayCommand<object>(items => { if (items == null) { return; } InsertCurrency(items); });
            CommandSalseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseOrg(items); });
            CommandSalseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseGroup(items); });
            CommandSalseDivision = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseDivision(items); });
            CommandItemCategory = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItemCategory(cmdPara, false, true, true); });
            CommandCostCenter = new RelayCommand<object>(items => { if (items == null) { return; } InsertCostCenter(items); });
            CommandBank = new RelayCommand<object>(items => { if (items == null) { return; } InsertBank(items); });
            CommandNastroBank = new RelayCommand<object>(items => { if (items == null) { return; } InsertNastroBank(items); });
            CommandBallType = new RelayCommand<object>(items => { if (items == null) { return; } InsertBallType(items); });
            CommandILD = new RelayCommand<object>(items => { if (items == null) { return; } InsertILD(items); });
            CommandWireType = new RelayCommand<object>(items => { if (items == null) { return; } InsertWireType(items); });
            CommandBallDia = new RelayCommand<object>(items => { if (items == null) { return; } InsertBallDia(items); });
            CommandInk = new RelayCommand<object>(items => { if (items == null) { return; } InsertInk(items); });
            CommandBuyer = new RelayCommand<object>(items => { if (items == null) { return; } InsertBuyer(items); });
            CommandItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara, true, true, true); });
            CommandTerms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTerms(cmdPara, true, true, true); });
            CommandDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });// confirm assignment
            CommandDeleteDataGridRowSchedule = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_ItemSchedule(cmdPara); });// confirm assignment
            CommandLocations = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLocation(cmdPara); });// confirm assignment
            CommandLicenseAdvance = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicenseAdvance(cmdPara); });// confirm assignment
            CommandLicenseEPCG = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicenseEPCG(cmdPara); });// confirm assignment
            CommandIncoterms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertIncoterms(cmdPara); });// confirm assignment
            CommandReferenceDocumentType = new RelayCommand<object>(items => { if (items == null) { return; } FilterReferenceDocumentNumbers(items); }); // confirm assignment
            CommandActiveInactiveCheck = new RelayCommand<bool>(CheckActiveStatus); // confirm assignment
            CommandReferenceDoc = new RelayCommand<object>(items => { if (items == null) { return; } InsertReferenceDoc(items); });
            CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); }); // confirm assignment
            CommandLoadDocumentByRefDocNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByReferenceDocumentNumber(cmdPara, "FlipGridReference"); }); // confirm assignment
            cmdDeleteTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteTax(cmdPara); });
            ManualTaxChangedCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertManualTaxChangedCommand(cmdPara); });
            CommandAddSelectedTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSelectedTax(cmdPara); });
            CommandGrade = new RelayCommand<object>(items => { if (items == null) { return; } InsertGrade(items); });
            cmdMail = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } MailDocuments(cmdPara); });
            cmdPrint = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } PrintDocuments(cmdPara); });
            cmdLoadBackFlip = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadBackFlipData(cmdPara); });
            CommandDeleteDataGridTerms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Terms(cmdPara); });

            #endregion
            LoadInitialData();
            if (AppSessionState.TransValue != null && AppSessionState.TransactionCode == MC.DocumentTypes[0].TranCode)
            {
                LoadDocumentByDocumentNumber(AppSessionState.TransValue, "DocumentNo");
                isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                AppSessionState.TransValue = null;
                AppSessionState.TransParameter = null;
                AppSessionState.ViewOtherRecordAllowed = true;
            }
        }

        #endregion
        #region Relay Command Actions ·
        private void MailDocuments(object InputValue)
        {

            try
            {
                string ToEmailId = "";
                if (!string.IsNullOrWhiteSpace(PartyEmailId) && !string.IsNullOrWhiteSpace(PersonEmailId))
                {
                    ToEmailId = PartyEmailId + "," + PersonEmailId;
                }
                else if (!string.IsNullOrWhiteSpace(PartyEmailId) && string.IsNullOrWhiteSpace(PersonEmailId))
                {
                    ToEmailId = PartyEmailId;
                }
                else if (string.IsNullOrWhiteSpace(PartyEmailId) && !string.IsNullOrWhiteSpace(PersonEmailId))
                {
                    ToEmailId = PersonEmailId;
                }
                else if (string.IsNullOrWhiteSpace(PartyEmailId) && string.IsNullOrWhiteSpace(PersonEmailId))
                {
                    ToEmailId = "";
                }


                if (!string.IsNullOrWhiteSpace(MasterEntity.sono))
                {
                    string Request = "SO_Report" + "!@" + MasterEntity.sono;
                    MasterEntity.doc_desc = "SALES ORDER";

                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, Request, "SalesOrderMaster", "CRM", "LoadDocumentWithDocumentNumber", 0, "");

                    object[] objDataSource = new object[7];
                    string[] objDataSourceName = new string[7];

                    TotalDocumentTaxes = MCTemp.TaxEntity;
                    objDataSource[0] = MCTemp.MasterEntity;
                    objDataSource[1] = MCTemp.ItemsEntity;
                    objDataSource[2] = TotalDocumentTaxes;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[3] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[4] = Result;
                    objDataSource[5] = MCTemp.ScheduleDetailsEntity;

                    objDataSourceName[0] = "dsSalesQuotation";
                    objDataSourceName[1] = "dsSalesQuotationItem";
                    objDataSourceName[2] = "dsSalesQuotationTax";
                    objDataSourceName[3] = "dsCompany";
                    objDataSourceName[4] = "dsLocation";
                    objDataSourceName[5] = "dsScheduleDetailsEntity";

                    ReportManager ReportManager = new ReportManager();
                    var SystemDocumentObject = (from o in MC.DocumentTypes where o.doc_cat == MasterEntity.doc_cat select o).ToList();
                    string ReportName = "";
                    string DisplaytName = "";
                    string MessageData = "";
                    string To = "";
                    string Cc = "";
                    string Bcc = "";
                    if (SystemDocumentObject.Count > 0 && ToEmailId != "")
                    {
                        To = ToEmailId;
                        Cc = "";
                        Bcc = AppSessionState.EmpEmailId;
                        ReportName = SystemDocumentObject[0].report_name.Split(',')[0];
                        DisplaytName = MasterEntity.doc_desc + "_" + MasterEntity.sono.Replace(@"/", "-").Replace(@"\", "-") + "_" + MasterEntity.sodate.Value.Date.ToShortDateString().Replace(@"/", string.Empty).Replace(@"\", string.Empty);
                        MessageData = "<h3>Commercial Document for RFQ!</h3><p>Dear Sir!</p><p>Please find attached herewith commercial document for Sales Order as per your requirements. </p><p>-" + AppSessionState.CompanyName + "</p>";

                        ReportManager.Mail(To, Cc, Bcc, objDataSource, objDataSourceName, null, "\\CRM\\" + ReportName, DisplaytName, "Sales Order Prepared against RFQ By " + AppSessionState.CompanyName, MessageData, "", ".pdf");
                    }

                }
            }
            catch (Exception ex) { }
        }
        private void PrintDocuments(Object InputValue)
        {
            try
            {
                string Request = "SO_Report" + "!@" + MasterEntity.sono;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, Request, "SalesOrderMaster", "CRM", "LoadDocumentWithDocumentNumber", 0, "");
                object[] objDataSource = new object[6];
                string[] objDataSourceName = new string[6];

                TotalDocumentTaxes = MCTemp.TaxEntity;

                objDataSource[0] = MCTemp.MasterEntity;
                objDataSource[1] = MCTemp.ItemsEntity;
                objDataSource[2] = TotalDocumentTaxes;


                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[3] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[4] = Result;
                objDataSource[5] = MCTemp.ScheduleDetailsEntity;

                objDataSourceName[0] = "dsSalesQuotation";
                objDataSourceName[1] = "dsSalesQuotationItem";
                objDataSourceName[2] = "dsSalesQuotationTax";
                objDataSourceName[3] = "dsCompany";
                objDataSourceName[4] = "dsLocation";
                objDataSourceName[5] = "dsScheduleDetailsEntity";


                ReportManager ReportManager = new ReportManager();
               // ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + MC.DocumentTypes[0].report_name, getParametersList(), MC.DocumentTypes[0].report_name); 
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\SalesOrder2.rdlc", getParametersList(),"SalesOrder2");
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
        private void InsertLocation(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = LocationList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    ItemsEntity[dgSelectedIndexItem].order_to_plant = POPUPEntityObject.location_Id;
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
     
        private void Insertplant(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = LocationList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.location_Id = POPUPEntityObject.location_Id;
                    MasterEntity.LoctnNm = POPUPEntityObject.LoctnNm;
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
        private void Insertdgplant(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = LocationList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.location_Id = POPUPEntityObject.location_Id;
                    MasterEntity.LoctnNm = POPUPEntityObject.LoctnNm;
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
        private void InsertReferenceDoc(object InputValue)
        {
            try
            {
                string Request = "";
                SEL_T001_P_RefDoc POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Sales_Order_Reference.Where(x => x.sono.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T001_P_RefDoc>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ref_doc_no = POPUPEntityObject.sono;
                    MasterEntity.ref_doc_date = POPUPEntityObject.sodate;
                    MasterEntity.cust_ref = POPUPEntityObject.cust_ref;
                    MasterEntity.cust_ref_date = POPUPEntityObject.cust_ref_date;

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
        private void InsertDocType(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M002 POPUPEntityObject = null;
                IEnumerable<SYS_M002> BEType = new List<SYS_M002>();
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
                            { POPUPEntityObject = MC.DocumentTypes.Where(x => x.doc_type_user.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M002>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null && MasterEntity.doc_type_user != POPUPEntityObject.doc_type_user) // Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (String.IsNullOrEmpty(MasterEntity.po_no) != true || String.IsNullOrWhiteSpace(MasterEntity.po_no) != true) // Only enter in the code block if ENtity Not null.
                    {
                        if (ItemsEntity.Count > 0 && isNewRecord == false && AppSessionState.comp_code != "1")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Party Change Information";
                            showMessageService.Text = String.Format("Can not change Document Type '{0}' in edit mode", this.Title);
                            showMessageService.ShowMessage();
                        }
                    }
                    else
                    {
                        MasterEntity.doc_type = POPUPEntityObject.doc_type;
                        MasterEntity.doc_type_user = POPUPEntityObject.doc_type_user;
                        MasterEntity.doc_desc = POPUPEntityObject.doc_desc;
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

        private void LoadBackFlipData(object InputValue)
        {
            try
            {

                MasterEntity.doc_cat = "SO";
                MasterEntity.doc_type = "SO";
                string Request = "LoadBackFlipData" + "!@" + AppSessionState.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + AppSessionState.EmpId;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, Request, "SalesOrderMaster", "CRM", "LoadAll", 0, "");

                FlipGridData = MCTemp.DocumentDataFlipGrid.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

            }
            catch(Exception ex) { }

        }

        // Pending assignment of LoadSourceDocument() Method.
        private void LoadSourceDocument()
        {
            // Load another previous record from database for provided Document number and generate new document.
        }
        private void InsertSoldToParty(object InputValue, bool OverrideValue)
        {
            try
            {
                //ADM_M028_PopUp.
                string Request = "";
                string RequestParameterData = "";
                ADM_M028_P POPUPEntityObject = null;
                //IEnumerable<ADM_M028_PopUp> BEType = new List<ADM_M028_PopUp>(); Garbej
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
                            { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //&& MasterEntity.PartyId != POPUPEntityObject.PartyId) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (String.IsNullOrEmpty(MasterEntity.sono) != true || String.IsNullOrWhiteSpace(MasterEntity.sono) != true) //Condition: Only enter in the code block if ENtity Not null. Means It is in Edit Mode.
                    {
                        if (ItemsEntity.Count > 0 && isNewRecord == false && AppSessionState.comp_code != "1")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Party Change Information";
                            showMessageService.Text = String.Format("Can not change party'{0}' in edit mode", this.Title);
                            showMessageService.ShowMessage();
                        }
                        else
                        {
                            MasterEntity.PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.party_name = POPUPEntityObject.PartyNm;
                            MasterEntity.curr_code = POPUPEntityObject.curr_code;
                            PartyEmailId = POPUPEntityObject.EmailId;

                            RequestParameterData = "LoadSoldToPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.PartyId;
                            MCTempp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTempp, RequestParameterData, "SalesOrderMaster", "CRM", "", 0, "");

                            MC.PartysContactInfo = MCTempp.PartysContactInfo;
                            MC.PartysSoldToAddresses = MCTempp.PartysSoldToAddresses;
                            MC.ItemListPopup = MCTempp.ItemListPopup;
                            


                            MC.TermsAndCondition = MCTempp.TermsAndCondition;

                            TermsConditionEntity = MC.TermsAndCondition;

                            BuyerCollection = CollectionViewSource.GetDefaultView(MC.PartysContactInfo);
                            BuyerCollection.Filter = new Predicate<object>(Filter_Buyer);
                            StringListBuyer = MC.PartysContactInfo.Select(x => x.ContInfoId.ToString()).ToList();
                            if (MC.PartysContactInfo.Count == 1)
                            {
                                MasterEntity.buyer = 0;
                                MasterEntity.buyer_name = "";
                                PersonEmailId = "";

                                MasterEntity.buyer_name = MC.PartysContactInfo[0].PersonName;
                                MasterEntity.buyer = MC.PartysContactInfo[0].ContInfoId;
                                PersonEmailId = MC.PartysContactInfo[0].PersnEmailId;
                            }
                            else if(MC.PartysContactInfo.Count==0)
                            {
                                MasterEntity.buyer = 0;
                                MasterEntity.buyer_name = "";
                                PersonEmailId = "";
                            }

                            BillingAddressCollection = CollectionViewSource.GetDefaultView(MC.PartysSoldToAddresses);
                            BillingAddressCollection.Filter = new Predicate<object>(Filter_BillingAddress);
                            StringListSoldToAddress = MC.PartysSoldToAddresses.Select(x => x.Location.ToString()).ToList();

                            if (MC.PartysSoldToAddresses.Count == 0)
                            {

                                MasterEntity.bill_address_id = 0;
                                MasterEntity.billing_address = "";
                                MasterEntity.country_nm = "";
                                MasterEntity.country_code = "";
                                MasterEntity.state_nm = "";
                                MasterEntity.city = "";
                                MasterEntity.address = "";
                                MasterEntity.address1 = "";
                                MasterEntity.pincode = "";
                            }

                            if (MC.PartysSoldToAddresses.Count == 1)
                            {

                                MasterEntity.bill_address_id = 0;
                                MasterEntity.billing_address = "";
                                MasterEntity.country_nm = "";
                                MasterEntity.country_code = "";
                                MasterEntity.state_nm = "";
                                MasterEntity.city = "";
                                MasterEntity.address = "";
                                MasterEntity.address1 = "";
                                MasterEntity.pincode = "";

                                MasterEntity.bill_address_id = MC.PartysSoldToAddresses[0].SrNo;
                                MasterEntity.billing_address = MC.PartysSoldToAddresses[0].Location;
                                MasterEntity.country_nm = MC.PartysSoldToAddresses[0].CntryName;
                                MasterEntity.country_code = MC.PartysSoldToAddresses[0].country_code;
                                MasterEntity.state_nm = MC.PartysSoldToAddresses[0].StatName;
                                MasterEntity.city = MC.PartysSoldToAddresses[0].City;
                                MasterEntity.address = MC.PartysSoldToAddresses[0].Add1;
                                MasterEntity.address1 = MC.PartysSoldToAddresses[0].Add2;
                                MasterEntity.pincode = MC.PartysSoldToAddresses[0].PinCode;
                            }
                            else if (MC.PartysSoldToAddresses.Count > 1)
                            {
                                MasterEntity.bill_address_id = 0;
                                MasterEntity.billing_address = "";
                                MasterEntity.country_nm = "";
                                MasterEntity.country_code = "";
                                MasterEntity.state_nm = "";
                                MasterEntity.city = "";
                                MasterEntity.address = "";
                                MasterEntity.address1 = "";
                                MasterEntity.pincode = "";

                                MasterEntity.bill_address_id = MC.PartysSoldToAddresses[0].SrNo;
                                MasterEntity.billing_address = MC.PartysSoldToAddresses[0].Location;
                                MasterEntity.country_nm = MC.PartysSoldToAddresses[0].CntryName;
                                MasterEntity.country_code = MC.PartysSoldToAddresses[0].country_code;
                                MasterEntity.state_nm = MC.PartysSoldToAddresses[0].StatName;
                                MasterEntity.city = MC.PartysSoldToAddresses[0].City;
                                MasterEntity.address = MC.PartysSoldToAddresses[0].Add1;
                                MasterEntity.address1 = MC.PartysSoldToAddresses[0].Add2;
                                MasterEntity.pincode = MC.PartysSoldToAddresses[0].PinCode;


                            }
                          
                            PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListPopup);
                            PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                            StringListItems = MC.ItemListPopup.Select(x => x.ItemCode).ToList();
                            isNewRecord = true;

                        }
                    }
                   else if (isNewRecord == true && ItemsEntity.Count > 0 && MasterEntity.PartyId != POPUPEntityObject.PartyId)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Party Selection";
                        showMessageService.Text = String.Format("If You Change The Party Items Will be removed'{0}'", this.Title);
                        if (showMessageService.ShowMessage() == DialogResult.Ok)
                        {
                            MasterEntity.PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.party_name = POPUPEntityObject.PartyNm;
                            MasterEntity.curr_code = POPUPEntityObject.curr_code;
                            PartyEmailId = POPUPEntityObject.EmailId;

                            RequestParameterData = "LoadSoldToPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.PartyId;
                            MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, RequestParameterData, "SalesOrderMaster", "CRM", "", 0, "");

                            MC.PartysContactInfo = MCTemp.PartysContactInfo;
                            MC.PartysSoldToAddresses = MCTemp.PartysSoldToAddresses;
                            MC.ItemListPopup = MCTemp.ItemListPopup;

                            MC.TermsAndCondition = MCTemp.TermsAndCondition;
                            TermsConditionEntity = MC.TermsAndCondition;

                            BuyerCollection = CollectionViewSource.GetDefaultView(MC.PartysContactInfo);
                            BuyerCollection.Filter = new Predicate<object>(Filter_Buyer);
                            StringListBuyer = MC.PartysContactInfo.Select(x => x.ContInfoId.ToString()).ToList();

                            BillingAddressCollection = CollectionViewSource.GetDefaultView(MC.PartysSoldToAddresses);
                            BillingAddressCollection.Filter = new Predicate<object>(Filter_BillingAddress);
                            StringListSoldToAddress = MC.PartysSoldToAddresses.Select(x => x.Location.ToString()).ToList();

                            PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListPopup);
                            PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                            StringListItems = MC.ItemListPopup.Select(x => x.ItemCode).ToList();

                            ItemsEntity.Clear();
                            ItemScheduleEntity.Clear();
                        }
                    }

                    else
                    {
                        MasterEntity.PartyId = POPUPEntityObject.PartyId;
                        MasterEntity.party_name = POPUPEntityObject.PartyNm;
                        MasterEntity.curr_code = POPUPEntityObject.curr_code;
                        PartyEmailId = POPUPEntityObject.EmailId;

                        RequestParameterData = "LoadSoldToPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.PartyId;
                        MCTempp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTempp, RequestParameterData, "SalesOrderMaster", "CRM", "", 0, "");

                        MC.PartysContactInfo = MCTempp.PartysContactInfo;
                        MC.PartysSoldToAddresses = MCTempp.PartysSoldToAddresses;
                        MC.ItemListPopup = MCTempp.ItemListPopup;

                        MC.TermsAndCondition = MCTempp.TermsAndCondition;

                        TermsConditionEntity = MC.TermsAndCondition;

                        BuyerCollection = CollectionViewSource.GetDefaultView(MC.PartysContactInfo);
                        BuyerCollection.Filter = new Predicate<object>(Filter_Buyer);
                        StringListBuyer = MC.PartysContactInfo.Select(x => x.ContInfoId.ToString()).ToList();
                        if (MC.PartysContactInfo.Count == 1)
                        {
                            MasterEntity.buyer = 0;
                            MasterEntity.buyer_name = "";
                            PersonEmailId = "";
                            MasterEntity.buyer_name = MC.PartysContactInfo[0].PersonName;
                            MasterEntity.buyer = MC.PartysContactInfo[0].ContInfoId;
                            PersonEmailId = MC.PartysContactInfo[0].PersnEmailId;
                        }
                        else if (MC.PartysContactInfo.Count == 0)
                        {
                            MasterEntity.buyer = 0;
                            MasterEntity.buyer_name = "";
                            PersonEmailId = "";
                        }

                        BillingAddressCollection = CollectionViewSource.GetDefaultView(MC.PartysSoldToAddresses);
                        BillingAddressCollection.Filter = new Predicate<object>(Filter_BillingAddress);
                        StringListSoldToAddress = MC.PartysSoldToAddresses.Select(x => x.Location.ToString()).ToList();

                        if (MC.PartysSoldToAddresses.Count ==0)
                        {

                            MasterEntity.bill_address_id = 0;
                            MasterEntity.billing_address = "";
                            MasterEntity.country_nm = "";
                            MasterEntity.country_code = "";
                            MasterEntity.state_nm = "";
                            MasterEntity.city = "";
                            MasterEntity.address = "";
                            MasterEntity.address1 = "";
                            MasterEntity.pincode = "";
                        }

                        if (MC.PartysSoldToAddresses.Count == 1)
                        {

                            MasterEntity.bill_address_id = 0;
                            MasterEntity.billing_address = "";
                            MasterEntity.country_nm = "";
                            MasterEntity.country_code = "";
                            MasterEntity.state_nm = "";
                            MasterEntity.city = "";
                            MasterEntity.address = "";
                            MasterEntity.address1 = "";
                            MasterEntity.pincode = "";

                            MasterEntity.bill_address_id = MC.PartysSoldToAddresses[0].SrNo;
                            MasterEntity.billing_address = MC.PartysSoldToAddresses[0].Location;
                            MasterEntity.country_nm = MC.PartysSoldToAddresses[0].CntryName;
                            MasterEntity.country_code = MC.PartysSoldToAddresses[0].country_code;
                            MasterEntity.state_nm = MC.PartysSoldToAddresses[0].StatName;
                            MasterEntity.city = MC.PartysSoldToAddresses[0].City;
                            MasterEntity.address = MC.PartysSoldToAddresses[0].Add1;
                            MasterEntity.address1 = MC.PartysSoldToAddresses[0].Add2;
                            MasterEntity.pincode = MC.PartysSoldToAddresses[0].PinCode;
                        }
                        else if (MC.PartysSoldToAddresses.Count > 1)
                        {
                            MasterEntity.bill_address_id = 0;
                            MasterEntity.billing_address = "";
                            MasterEntity.country_nm = "";
                            MasterEntity.country_code = "";
                            MasterEntity.state_nm = "";
                            MasterEntity.city = "";
                            MasterEntity.address = "";
                            MasterEntity.address1 = "";
                            MasterEntity.pincode = "";

                            MasterEntity.bill_address_id = MC.PartysSoldToAddresses[0].SrNo;
                            MasterEntity.billing_address = MC.PartysSoldToAddresses[0].Location;
                            MasterEntity.country_nm = MC.PartysSoldToAddresses[0].CntryName;
                            MasterEntity.country_code = MC.PartysSoldToAddresses[0].country_code;
                            MasterEntity.state_nm = MC.PartysSoldToAddresses[0].StatName;
                            MasterEntity.city = MC.PartysSoldToAddresses[0].City;
                            MasterEntity.address = MC.PartysSoldToAddresses[0].Add1;
                            MasterEntity.address1 = MC.PartysSoldToAddresses[0].Add2;
                            MasterEntity.pincode = MC.PartysSoldToAddresses[0].PinCode;


                        }
                        DeliveryAddressCollection = CollectionViewSource.GetDefaultView(MC.PartysSoldToAddresses);
                        DeliveryAddressCollection.Filter = new Predicate<object>(Filter_DeliveryAddress);
                        StringListShipToAddress = MC.PartysSoldToAddresses.Select(x => x.Location.ToString()).ToList();

                        PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListPopup);
                        PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                        StringListItems = MC.ItemListPopup.Select(x => x.ItemCode).ToList();
                        isNewRecord = true;

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
        private void InsertShipToParty(object InputValue, bool OverrideValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                string RequestParameterData = "";
                ADM_M028_P POPUPEntityObject = null;
                //IEnumerable<ADM_M028_PopUp> BEType = new List<ADM_M028_PopUp>(); Garbej
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
                            { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //&& MasterEntity.PartyId != POPUPEntityObject.PartyId) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.ship_to_party = POPUPEntityObject.PartyId;
                    MasterEntity.ship_to_party_name = POPUPEntityObject.PartyNm;

                    if (MasterEntity.PartyId != MasterEntity.ship_to_party)
                    {
                        RequestParameterData = "LoadShipToPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.ship_to_party;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, RequestParameterData, "SalesOrderMaster", "CRM", "", 0, "");
                        MC.PartysShipToAddresses = MCTemp.PartysShipToAddresses;
                        DeliveryAddressCollection = CollectionViewSource.GetDefaultView(MC.PartysShipToAddresses);
                        DeliveryAddressCollection.Filter = new Predicate<object>(Filter_DeliveryAddress);
                        StringListShipToAddress = MC.PartysShipToAddresses.Select(x => x.SrNo.ToString()).ToList();


                        if (MC.PartysShipToAddresses.Count == 0)
                        {
                            MasterEntity.del_address = 0;
                            MasterEntity.delivery_address = "";
                            MasterEntity.country_nm_s = "";
                            MasterEntity.state_nm_s = "";
                            MasterEntity.city_s = "";
                            MasterEntity.address1_s = "";
                            MasterEntity.address2_s = "";
                            MasterEntity.pincode_s = "";
                        }


                        if (MC.PartysShipToAddresses.Count == 1)
                        {
                            MasterEntity.del_address = 0;
                            MasterEntity.delivery_address = "";
                            MasterEntity.country_nm_s = "";
                            MasterEntity.state_nm_s = "";
                            MasterEntity.city_s = "";
                            MasterEntity.address1_s = "";
                            MasterEntity.address2_s = "";
                            MasterEntity.pincode_s = "";

                            MasterEntity.del_address = MC.PartysShipToAddresses[0].SrNo;
                            MasterEntity.delivery_address = MC.PartysShipToAddresses[0].Location;
                            MasterEntity.country_nm_s = MC.PartysShipToAddresses[0].CntryName;
                            MasterEntity.state_nm_s = MC.PartysShipToAddresses[0].StatName;
                            MasterEntity.city_s = MC.PartysShipToAddresses[0].City;
                            MasterEntity.address1_s = MC.PartysShipToAddresses[0].Add1;
                            MasterEntity.address2_s = MC.PartysShipToAddresses[0].Add2;
                            MasterEntity.pincode_s = MC.PartysShipToAddresses[0].PinCode;
                        }
                    }
                    else if (MasterEntity.PartyId == MasterEntity.ship_to_party)
                    {
                        MasterEntity.del_address = 0;
                        MasterEntity.delivery_address = "";
                        MasterEntity.country_nm_s = "";
                        MasterEntity.state_nm_s = "";
                        MasterEntity.city_s = "";
                        MasterEntity.address1_s = "";
                        MasterEntity.address2_s = "";
                        MasterEntity.pincode_s = "";


                        MasterEntity.del_address = MasterEntity.bill_address_id;
                        MasterEntity.delivery_address = MasterEntity.billing_address;
                        MasterEntity.country_nm_s = MasterEntity.country_nm;
                        MasterEntity.state_nm_s = MasterEntity.state_nm;
                        MasterEntity.city_s = MasterEntity.city;
                        MasterEntity.address1_s = MasterEntity.address;
                        MasterEntity.address2_s = MasterEntity.address1;
                        MasterEntity.pincode_s = MasterEntity.pincode;

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
        private void InsertNotifyParty(object InputValue, bool OverrideValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                string RequestParameterData = "";
                ADM_M028_P POPUPEntityObject = null;
                //IEnumerable<ADM_M028_PopUp> BEType = new List<ADM_M028_PopUp>(); Garbej
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
                            { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //&& MasterEntity.PartyId != POPUPEntityObject.PartyId) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.notify_party = POPUPEntityObject.PartyId;
                    MasterEntity.notify_party_name = POPUPEntityObject.PartyNm;
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
       
        private void InsertGrade(object InputValue)
        {
            try
            {

                string Request = "";
                string RequestParameterData = "";
                ADM_M045_P POPUPEntityObject = null;

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
                            { POPUPEntityObject = MC.GradeCollection.Where(x => x.grade_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M045_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //&& MasterEntity.PartyId != POPUPEntityObject.PartyId) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    ItemsEntity[dgSelectedIndexItem].para3 = POPUPEntityObject.grade_code;

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
        private void InsertTransporter(object InputValue, bool OverrideValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                string RequestParameterData = "";
                ADM_M028_P POPUPEntityObject = null;
                //IEnumerable<ADM_M028_PopUp> BEType = new List<ADM_M028_PopUp>(); Garbej
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
                            { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.transporter_cd = POPUPEntityObject.PartyId;
                    MasterEntity.TranParty_name = POPUPEntityObject.PartyNm;
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
        private void InsertSupplier(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                string RequestParameterData = "";
                ADM_M028_P POPUPEntityObject = null;

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
                            { POPUPEntityObject = MC.Supplier.Where(x => x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {

                    ItemsEntity[dgSelectedIndexItem].PartyId = POPUPEntityObject.PartyId;
                    ItemsEntity[dgSelectedIndexItem].PartyNm = POPUPEntityObject.PartyNm;

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
        private void InsertdgTransporter(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                string RequestParameterData = "";
                ADM_M028_P POPUPEntityObject = null;
                //IEnumerable<ADM_M028_PopUp> BEType = new List<ADM_M028_PopUp>(); Garbej
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
                            { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {

                    ItemScheduleEntity[dgSelectedIndexItemSchedule].PartyId = POPUPEntityObject.PartyId;
                    ItemScheduleEntity[dgSelectedIndexItemSchedule].PartyNm = POPUPEntityObject.PartyNm;

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
        private void InsertServiceProvider(object InputValue, bool OverrideValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                string RequestParameterData = "";
                ADM_M028_P POPUPEntityObject = null;
                //IEnumerable<ADM_M028_PopUp> BEType = new List<ADM_M028_PopUp>(); Garbej
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
                            { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.referring_party = POPUPEntityObject.PartyId;
                    MasterEntity.referring_party_name = POPUPEntityObject.PartyNm;
                    MasterEntity.refferencing_party = POPUPEntityObject.PartyId;
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
        private void InsertSoldToAddress(object InputValue, bool OverrideValue)
        {
            try
            {
                string Request = "";
                ADM_M028_D POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.PartysSoldToAddresses.Where(x => x.Location.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_D>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.bill_address_id = POPUPEntityObject.SrNo;
                    MasterEntity.billing_address = POPUPEntityObject.Location;
                    MasterEntity.country_nm = POPUPEntityObject.CntryName;      //add by sachin magar
                    MasterEntity.state_nm = POPUPEntityObject.StatName;
                    MasterEntity.city = POPUPEntityObject.City;
                    MasterEntity.address = POPUPEntityObject.Add1;
                    MasterEntity.address1 = POPUPEntityObject.Add2;
                    MasterEntity.pincode = POPUPEntityObject.PinCode;
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
        private void InsertShipToAddress(object InputValue, bool OverrideValue)
        {
            try
            {
                string Request = "";
                ADM_M028_D POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.PartysShipToAddresses.Where(x => x.Location.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_D>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.del_address = POPUPEntityObject.SrNo;
                    MasterEntity.delivery_address = POPUPEntityObject.Location;
                    MasterEntity.country_nm_s = POPUPEntityObject.CntryName;      //add by sachin magar
                    MasterEntity.state_nm_s = POPUPEntityObject.StatName;
                    MasterEntity.city_s = POPUPEntityObject.City;
                    MasterEntity.address1_s = POPUPEntityObject.Add1;
                    MasterEntity.address2_s = POPUPEntityObject.Add2;
                    MasterEntity.pincode_s = POPUPEntityObject.PinCode;
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
        private void InsertSeller(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M024_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Sellers.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.EmpId = POPUPEntityObject.EmpId;
                    MasterEntity.sales_person_cd = POPUPEntityObject.EmpId;
                    MasterEntity.seller_name = POPUPEntityObject.EmpName;
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
        private void InsertGLCode(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.GLCodes.Where(x => x.acc_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.gl_code = POPUPEntityObject.acc_code;
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
        private void InsertPayTerm(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M007_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PayTerms.Where(x => x.p_term_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M007_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.p_term_code = POPUPEntityObject.p_term_code;
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
        private void InsertCurrency(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M037_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Currencys.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M037_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.curr_code = POPUPEntityObject.curr_code;
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
        private void InsertSalseOrg(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M001_A_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SalesOrg.Where(x => x.so_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_A_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.so_code = POPUPEntityObject.so_code;
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
        private void InsertSalseGroup(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M001_H_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SalesGroup.Where(x => x.sg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_H_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.sg_code = POPUPEntityObject.sg_code;
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
        private void InsertSalseDivision(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M001_D_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SalesDiv.Where(x => x.div_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_D_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.div_code = POPUPEntityObject.div_code;
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
        private void InsertCostCenter(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M019_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Cost_Centers.Where(x => x.cost_center.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M019_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.cost_center = POPUPEntityObject.cost_center;
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
        private void InsertBank(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M004_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Banks.Where(x => x.bank_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M004_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.bank_code = POPUPEntityObject.bank_code;
                    MasterEntity.bank_name = POPUPEntityObject.bank_name;
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
        private void InsertNastroBank(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M004_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Banks.Where(x => x.bank_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M004_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.nastro_bank_cd = POPUPEntityObject.bank_code;
                    MasterEntity.nastro_bank_name = POPUPEntityObject.bank_name;
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
        private void InsertInk(object InputValue) // Para1
        {
            try
            {
                string Request = "";
                ZADM_M006_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Inks.Where(x => x.ink.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M006_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    ItemsEntity[dgSelectedIndexItem].para1 = POPUPEntityObject.ink;
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
        private void InsertInk2(object InputValue) // Para2
        {
            try
            {
                string Request = "";
                ZADM_M006_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Inks.Where(x => x.ink.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M006_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    ItemsEntity[dgSelectedIndexItem].para2 = POPUPEntityObject.ink;
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
        private void InsertInk3(object InputValue) // Para3
        {
            try
            {
                string Request = "";
                ZADM_M006_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Inks.Where(x => x.ink.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M006_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    ItemsEntity[dgSelectedIndexItem].para3 = POPUPEntityObject.ink;
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
        private void InsertBallType(object InputValue) // Para5
        {
            try
            {
                string Request = "";
                ZADM_M002_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.BallTypes.Where(x => x.ball_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M002_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    ItemsEntity[dgSelectedIndexItem].para5 = POPUPEntityObject.ball_type;
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
        private void InsertILD(object InputValue) // Para6
        {
            try
            {
                string Request = "";
                ZADM_M007_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.ILDs.Where(x => x.ild.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M007_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    ItemsEntity[dgSelectedIndexItem].para5 = POPUPEntityObject.ild;
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
        private void InsertWireType(object InputValue) // Para7
        {
            try
            {
                string Request = "";
                ZADM_M004_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.WireTypes.Where(x => x.wire_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M004_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    ItemsEntity[dgSelectedIndexItem].para7 = POPUPEntityObject.wire_type;
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
        private void InsertBallDia(object InputValue) // Para9
        {
            try
            {
                string Request = "";
                ZADM_M001_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.BallDias.Where(x => x.Ball_dia.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M001_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    ItemsEntity[dgSelectedIndexItem].para9 = POPUPEntityObject.Ball_dia.ToString();
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
        private void InsertBuyer(object InputValue) // Para10
        {
            try
            {
                string Request = "";
                ADM_M028_C_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PartysContactInfo.Where(x => x.ContInfoId.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_C_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.buyer = POPUPEntityObject.ContInfoId;
                    MasterEntity.buyer_name = POPUPEntityObject.PersonName;
                    PersonEmailId = POPUPEntityObject.PersnEmailId;
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
        private void InsertLicenseAdvance(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M041_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.LicenseAdvance.Where(x => x.lic_cod.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M041_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.adv_lic_cd = POPUPEntityObject.lic_cod;
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
        private void InsertLicenseEPCG(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M041_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.LicenseEPCG.Where(x => x.lic_cod.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M041_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.lic_cod = POPUPEntityObject.lic_cod;
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
        private void InsertIncoterms(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M044_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Incoterms.Where(x => x.incoterms.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M044_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.incoterms = POPUPEntityObject.incoterms;
                    MasterEntity.inco_desc = POPUPEntityObject.inco_desc;
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

        private void InsertItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                SEL_T001_P_SO_ItemsList POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ItemListPopup.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T001_P_SO_ItemsList>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                    {
                        ItemsEntity.Add(new SEL_T001_A()
                        {
                            id = 0,
                            ItemCode = POPUPEntityObject.ItemCode,
                            Description = POPUPEntityObject.ItemName,
                            CstmrItmCod = POPUPEntityObject.CstmrItmCod,
                            active = true,
                            line_id = 0,
                            location_Id = AppSessionState.location_Id,
                            ref_doc_no = MasterEntity.ref_doc_no,
                            ref_doc_type = MasterEntity.ref_doc_type,
                            sku = POPUPEntityObject.sku,
                            sku_desc = POPUPEntityObject.sku_desc,
                            tax_id = POPUPEntityObject.tax_id,
                            unit_code = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM,
                            unit_price = String.IsNullOrEmpty(POPUPEntityObject.Rate_Catlog.ToString()) ? POPUPEntityObject.rate : POPUPEntityObject.Rate_Catlog,
                            comp_code = AppSessionState.comp_code,
                            item_cat = POPUPEntityObject.item_cat_id,
                            para9 = POPUPEntityObject.needledia,
                            para10 = POPUPEntityObject.needleangle,
                            para11 = POPUPEntityObject.needlelen,
                            t_status = "Draft",
                            para3 = "A"
                        });
                    }
                    else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            ItemsEntity[dgSelectedIndexItem].ItemCode = POPUPEntityObject.ItemCode;
                            ItemsEntity[dgSelectedIndexItem].Description = POPUPEntityObject.ItemName;
                            ItemsEntity[dgSelectedIndexItem].CstmrItmCod = POPUPEntityObject.CstmrItmCod;
                            ItemsEntity[dgSelectedIndexItem].active = true;
                            ItemsEntity[dgSelectedIndexItem].line_id = 0;
                            ItemsEntity[dgSelectedIndexItem].quotation_no = MasterEntity.quotation_no;
                            ItemsEntity[dgSelectedIndexItem].ref_doc_no = MasterEntity.ref_doc_no;
                            ItemsEntity[dgSelectedIndexItem].ref_doc_type = MasterEntity.ref_doc_type;
                            ItemsEntity[dgSelectedIndexItem].sku = POPUPEntityObject.sku;
                            ItemsEntity[dgSelectedIndexItem].sku_desc = POPUPEntityObject.sku_desc;
                            ItemsEntity[dgSelectedIndexItem].tax_id = POPUPEntityObject.tax_id;
                            ItemsEntity[dgSelectedIndexItem].unit_code = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM;
                            ItemsEntity[dgSelectedIndexItem].unit_price = String.IsNullOrEmpty(POPUPEntityObject.Rate_Catlog.ToString()) ? POPUPEntityObject.rate : POPUPEntityObject.Rate_Catlog;
                            ItemsEntity[dgSelectedIndexItem].item_cat = POPUPEntityObject.item_cat_id;
                            ItemsEntity[dgSelectedIndexItem].para9 = POPUPEntityObject.needledia;
                            ItemsEntity[dgSelectedIndexItem].para10 = POPUPEntityObject.needleangle;
                            ItemsEntity[dgSelectedIndexItem].para11 = POPUPEntityObject.needlelen;
                            ItemsEntity[dgSelectedIndexItem].para3 = "A";

                        }
                        else if (ItemsEntity[dgSelectedIndexItem].ItemCode != POPUPEntityObject.ItemCode)
                        {
                            ItemsEntity[dgSelectedIndexItem].ItemCode = "";
                            ItemsEntity[dgSelectedIndexItem].Description ="";
                        }
                    }
                }
                #region Clear Empty Row
                SEL_T001_A newObj = new SEL_T001_A();
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
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
            #endregion
        }

        private void InsertTerms(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                CRM_M001_P POPUPEntityObject = null;
                //dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.TermsConditionCollection.Where(x => x.con_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<CRM_M001_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = TermsConditionEntity.Where(X => X.con_type == POPUPEntityObject.con_type).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = TermsConditionEntity.IndexOf(TermsConditionEntity.Where(X => X.con_type == POPUPEntityObject.con_type).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && TermsConditionEntity.Count == dgSelectedIndexTerms)
                    {
                        TermsConditionEntity.Add(new SEL_T001_E()
                        {
                            id = 0,
                            active = true,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            con_type = POPUPEntityObject.con_type,
                            long_text = POPUPEntityObject.long_text,
                            tc_code = POPUPEntityObject.tc_code,
                            sequence_code = POPUPEntityObject.sequence_code,
                            sequence1 = POPUPEntityObject.sequence1,
                            sequence2 = POPUPEntityObject.sequence2,
                            sequence3 = POPUPEntityObject.sequence3,
                            short_text = POPUPEntityObject.short_text,
                        });
                    }
                    else if (dgSelectedIndexTerms >= 0 && TermsConditionEntity.Count > dgSelectedIndexTerms) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (TermsConditionEntity[dgSelectedIndexTerms].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            TermsConditionEntity[dgSelectedIndexTerms].active = true;
                            TermsConditionEntity[dgSelectedIndexTerms].location_Id = AppSessionState.location_Id;
                            TermsConditionEntity[dgSelectedIndexTerms].comp_code = AppSessionState.comp_code;
                            TermsConditionEntity[dgSelectedIndexTerms].con_type = POPUPEntityObject.con_type;

                            TermsConditionEntity[dgSelectedIndexTerms].long_text = POPUPEntityObject.long_text;
                            TermsConditionEntity[dgSelectedIndexTerms].tc_code = POPUPEntityObject.tc_code;

                            TermsConditionEntity[dgSelectedIndexTerms].sequence_code = POPUPEntityObject.sequence_code;
                            TermsConditionEntity[dgSelectedIndexTerms].sequence1 = POPUPEntityObject.sequence1;
                            TermsConditionEntity[dgSelectedIndexTerms].sequence2 = POPUPEntityObject.sequence2;
                            TermsConditionEntity[dgSelectedIndexTerms].sequence3 = POPUPEntityObject.sequence3;
                            TermsConditionEntity[dgSelectedIndexTerms].short_text = POPUPEntityObject.short_text;


                        }
                        else if (TermsConditionEntity[dgSelectedIndexTerms].con_type != POPUPEntityObject.con_type)
                        {
                            TermsConditionEntity[dgSelectedIndexTerms].con_type = "";
                            TermsConditionEntity[dgSelectedIndexTerms].long_text = "";
                        }
                    }
                }
                #region Clear Empty Row
                SEL_T001_E newObj = new SEL_T001_E();
                for (int i = TermsConditionEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = TermsConditionEntity[i].ComparePropertiesTo(newObj);
                    if (TermsConditionEntity[i].ComparePropertiesTo(newObj) == true && TermsConditionEntity.Count > 1)
                    {
                        TermsConditionEntity.RemoveAt(i);
                        if (TermsConditionEntity.Count == 0)
                        {
                            TermsConditionEntity.Add(newObj);
                        }
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
            #endregion
        }
        private void InsertUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UOM.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                        {
                            ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        }
                    }
                }
                #region Clear Empty Row
                SEL_T001_A newObj = new SEL_T001_A();
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
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void InsertItemCategory(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                SYS_M003_P POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ItemLineCategory.Where(x => x.sditem_cat_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SYS_M003_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M003_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    ItemsEntity[dgSelectedIndexItem].item_cat = POPUPEntityObject.sditem_cat_code;
                }
                #region Clear Empty Row
                SEL_T001_A newObj = new SEL_T001_A();
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
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }

        private void CheckActiveStatus(bool select)
        {
            //Check weather Status of DataGrid Record is Active or Not. If changes encounter then update other functions accordingly to update Entities.

            try
            {
                //TaxTableCalculation();
                //TaxRowCalculation();
            }
            catch { }
        }

        //
        // Summary:
        //     This Method load Document Data for Reference document and for Flip DataGrid.
        //     Call for two seperate purpose
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            
            try
            {
                string RequestParameterData = "";
                string Request = "";
                string ParametersStringValue = "";
                SEL_T001_Flip ParameterEntityObject = null;

                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<SEL_T001_Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<SEL_T001_Flip>().ToList()[0];
                        Request = "LoadDocumentWithDocumentNumber" + "!@" + ParameterEntityObject.sono + "!@" + ParameterEntityObject.PartyId + "!@" + ParameterEntityObject.ship_to_party;
                        isNewRecord = false;

                        RequestParameterData = "LoadSoldToPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + ParameterEntityObject.PartyId;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, RequestParameterData, "SalesOrderMaster", "CRM", "", 0, "");

                        MC.ItemListPopup = MCTemp.ItemListPopup;
                        PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListPopup);
                        PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                        StringListItems = MC.ItemListPopup.Select(x => x.ItemCode).ToList();



                    }
                }

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, Request, "SalesOrderMaster", "CRM", "LoadDocumentWithDocumentNumber", 0, "");

                MC.PartysContactInfo = MCTemp.PartysContactInfo;
                MC.PartysSoldToAddresses = MCTemp.PartysSoldToAddresses;
                MC.PartysShipToAddresses = MCTemp.PartysShipToAddresses;


                BuyerCollection = CollectionViewSource.GetDefaultView(MC.PartysContactInfo);
                BuyerCollection.Filter = new Predicate<object>(Filter_Buyer);
                StringListBuyer = MC.PartysContactInfo.Select(x => x.ContInfoId.ToString()).ToList();

                BillingAddressCollection = CollectionViewSource.GetDefaultView(MC.PartysSoldToAddresses);
                BillingAddressCollection.Filter = new Predicate<object>(Filter_BillingAddress);
                StringListShipToAddress = MC.PartysSoldToAddresses.Select(x => x.SrNo.ToString()).ToList();

                DeliveryAddressCollection = CollectionViewSource.GetDefaultView(MC.PartysShipToAddresses);
                DeliveryAddressCollection.Filter = new Predicate<object>(Filter_DeliveryAddress);
                StringListShipToAddress = MC.PartysShipToAddresses.Select(x => x.SrNo.ToString()).ToList();

                if (MCTemp.ItemsEntity != null)
                {
                    ItemsEntity.Clear();
                    MasterEntity = MCTemp.MasterEntity[0];
                    PersonEmailId= MCTemp.MasterEntity[0].PersonEmailId;
                    PartyEmailId= MCTemp.MasterEntity[0].PartyEmailId;
                    ItemsEntity = MCTemp.ItemsEntity;
                }
                else
                {
                    MCTemp.ItemsEntity = new ObservableCollection<SEL_T001_A>();
                }
                if (MCTemp.TaxEntity != null)
                {
                    TotalDocumentTaxes.Clear();
                    TotalDocumentTaxes = MCTemp.TaxEntity;
                }
                else
                {
                    MCTemp.TaxEntity = new ObservableCollection<ACC_T006_B>();
                }
                if (MCTemp.ScheduleMasterEntity != null)
                {
                    if (MCTemp.ScheduleMasterEntity.Count > 0)
                    {
                        ScheduleEntity = MCTemp.ScheduleMasterEntity[0];
                    }
                }
                else
                {
                    MCTemp.ScheduleMasterEntity = new List<SEL_T002>();
                }
                if (MCTemp.ScheduleDetailsEntity != null)
                {
                    ItemScheduleEntity.Clear();
                    ItemScheduleEntity = MCTemp.ScheduleDetailsEntity;
                }
                else
                {
                    MCTemp.ScheduleDetailsEntity = new ObservableCollection<SEL_T002_A>();
                }
                if (MCTemp.Attachment != null)
                {
                    AttachmentCollection = MCTemp.Attachment;
                }
                else
                {
                    MCTemp.Attachment = new List<COM_T003>();
                }
                if (MCTemp.TermsAndCondition != null)
                {
                    TermsConditionEntity = MCTemp.TermsAndCondition;
                }
                else
                {
                    MCTemp.TermsAndCondition = new ObservableCollection<SEL_T001_E>();
                }
                SelectedTabControlIndex = 0;
                
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
        private void LoadDocumentByReferenceDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                string ParametersStringValue = "";
                SEL_T001_Flip ParameterEntityObject = null;
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    if (ParameterObject.ToString() == "ReferenceDocument")
                    {
                        if (String.IsNullOrEmpty(MasterEntity.ref_doc_no))
                        {
                            return;
                        }
                        ParametersStringValue = MasterEntity.ref_doc_no;
                        ParameterReference = ParameterObject.ToString();
                    }
                    else if (ParameterReference == "DocumentNumber")
                    {
                        ParametersStringValue = ParameterObject.ToString().Trim();
                    }

                    if (ParametersStringValue.Length > 0)
                    {
                        try
                        { Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParametersStringValue; }
                        catch (Exception ex) { }
                    }
                }


                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, Request, "SalesOrderMaster", "CRM", "LoadDocumentWithReferenceDocumentNumber", 0, "");
                if (MCTemp.ItemsEntity != null)
                {
                    ItemsEntity.Clear();
                    MasterEntity = MCTemp.MasterEntity[0];
                    PersonEmailId = MCTemp.MasterEntity[0].mail_id;
                    PartyEmailId = MCTemp.MasterEntity[0].PartyEmailId;
                    ItemsEntity = MCTemp.ItemsEntity;

                    if (MCTemp.MasterEntity[0].PartyId != MCTemp.MasterEntity[0].referring_party)
                    {
                        var refdoctemp = (from o in MC.PartyMaster where o.PartyType == "Architect" || o.PartyType == "Supplier/Customer" select o).ToList();

                        for (int i = 0; i < refdoctemp.Count; i++)
                        {
                            if (MCTemp.MasterEntity[0].PartyId == refdoctemp[i].PartyId)
                            {
                                MasterEntity.PartyId = "";
                                MasterEntity.party_name = "";
                                MasterEntity.ship_to_party = "";
                                MasterEntity.ship_to_party_name = "";
                                MasterEntity.delivery_address = "";
                                MasterEntity.billing_address = "";
                                MasterEntity.address = "";
                                MasterEntity.address1 = "";
                                MasterEntity.city = "";
                                MasterEntity.pincode = "";
                                MasterEntity.state_nm = "";
                                MasterEntity.country_nm = "";
                                MasterEntity.address1_s = "";
                                MasterEntity.address2_s = "";
                                MasterEntity.city_s = "";
                                MasterEntity.pincode_s = "";
                                MasterEntity.state_nm_s = "";
                                MasterEntity.country_nm_s = "";
                                MasterEntity.referring_party = refdoctemp[i].PartyId;
                                MasterEntity.referring_party_name = refdoctemp[i].PartyNm;
                                isNewRecord = false;
                            }
                        }
                    }
                }
                else
                {
                    MCTemp.ItemsEntity = new ObservableCollection<SEL_T001_A>();
                }
                if (MCTemp.TaxEntity != null)
                {
                    TotalDocumentTaxes.Clear();
                    TotalDocumentTaxes = MCTemp.TaxEntity;
                }
                else
                {
                    MCTemp.TaxEntity = new ObservableCollection<ACC_T006_B>();
                }
                if (MCTemp.ScheduleMasterEntity != null)
                {
                    if (MCTemp.ScheduleMasterEntity.Count > 0)
                    {
                        ScheduleEntity = MCTemp.ScheduleMasterEntity[0];
                    }
                }
                else
                {
                    MCTemp.ScheduleMasterEntity = new List<SEL_T002>();
                }
                if (MCTemp.ScheduleDetailsEntity != null)
                {
                    ItemScheduleEntity.Clear();
                    ItemScheduleEntity = MCTemp.ScheduleDetailsEntity;
                }
                else
                {
                    MCTemp.ScheduleDetailsEntity = new ObservableCollection<SEL_T002_A>();
                }
                if (MCTemp.TermsAndCondition != null)
                {
                    TermsConditionEntity = MCTemp.TermsAndCondition;
                }
                else
                {
                    MCTemp.TermsAndCondition = new ObservableCollection<SEL_T001_E>();
                }

                if (ParameterReference == "ReferenceDocument")
                {
                    MasterEntity.ref_doc_no = MasterEntity.sono;
                    MasterEntity.ref_doc_date = MasterEntity.po_date;
                    MasterEntity.ref_doc_type = MasterEntity.doc_type;
                    MasterEntity.shipped = false;
                    MasterEntity.shipped_date = null;
                    MasterEntity.doc_cat = "SO";
                    MasterEntity.doc_type = "SO";
                    MasterEntity.doc_type_user = "CL";
                    MasterEntity.doc_desc = "Close Order";
                    MasterEntity.sono = "";
                    MasterEntity.sodate = DateTime.Now;
                    MasterEntity.add_by = AppSessionState.UserID;
                    MasterEntity.editby = AppSessionState.UserID;
                    MasterEntity.active = true;
                    MasterEntity.t_status = "Draft";
                    MasterEntity.shipped = false;
                    MasterEntity.version = "v1.0";
                    ScheduleEntity.t_status = "Draft";
                    ScheduleEntity.sch_date = DateTime.Now;
                    ScheduleEntity.active = true;
                    ScheduleEntity.add_by = AppSessionState.UserID;
                    ScheduleEntity.id = 0;
                    isNewRecord = true;
                    var refdoctemp = (from o in MC.PartyMaster where o.PartyType == "Architect" select o).ToList();
                    if (MasterEntity.referring_party != null && MasterEntity.PartyId == null || MasterEntity.PartyId == "")
                    {
                        isNewRecord = false;//true
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
        private void InsertSelectedTax(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003_P POPUPEntityObject = null;
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.AccountList.Where(x => x.acc_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_P>().ToList()[0];
                    }
                }
                catch (Exception) { }
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (TotalDocumentTaxes.Count == dgSelectedIndexTaxSummury && dgSelectedIndexTaxSummury >= 0)
                    {
                        TotalDocumentTaxes.Add(new ACC_T006_B()
                        {

                            gl_code = POPUPEntityObject.acc_code


                        });

                    }
                    else if (TotalDocumentTaxes.Count > dgSelectedIndexTaxSummury)
                    {
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].gl_code = POPUPEntityObject.acc_code;

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

        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i && ItemsEntity[dgSelectedIndexItem].id == 0)
                {
                    ItemsEntity.RemoveAt(i);
                    TaxComputation(true);
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

        private void DeleteDataGridRow_Terms(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (TermsConditionEntity.Count > i && TermsConditionEntity[dgSelectedIndexTerms].id == 0)
                {
                    TermsConditionEntity.RemoveAt(i);

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

        private void DeleteDataGridRow_ItemSchedule(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemScheduleEntity.Count > i)
                {
                    ItemScheduleEntity.RemoveAt(i);
                    TaxComputation(true);
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
        private void InsertManualTaxChangedCommand(object InputValue)
        {
            TaxComputation(true);
        }
        private void DeleteTax(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (TotalDocumentTaxes.Count > i)
                {
                    //TotalDocumentTaxes.Remove(TotalDocumentTaxes.Where(x => x.tax_name == TotalDocumentTaxes[i].tax_name).Single());
                    List<ACC_T006_B> copyLocal = new List<ACC_T006_B>();
                    copyLocal = TotalDocumentTaxes.ToList();
                    foreach (var tax in copyLocal)
                    {
                        if (tax.tax_name == TotalDocumentTaxes[i].tax_name && tax.manual == "Manual")
                        {
                            TotalDocumentTaxes.Remove(tax);
                        }
                    }
                    TaxComputation(true);
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

        #endregion
        #region Abstract Command Actions
        private IEnumerable<T> MakeMeEnumerable<T>(T Entity)
        {
            yield return Entity;
        }
        protected override void OnSaveAction(InquiryActionResult<SEL_T001> result)
        {
            try
            {
                if (Validation() == true)
                {
                    this.StatusMessage = "Saving changes, please wait ...";
                    MasterEntity.XmlDataDocument_SEL_T001_A = obj.ObjectToXML(ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_B = obj.ObjectToXML(TotalDocumentTaxes);
                    //ScheduleEntity.PartyId = MasterEntity.PartyId; // cannot assign in default values method because Party not assign at that moment.
                    MasterEntity.XmlDataDocument_SEL_T002 = obj.ObjectToXML(ScheduleEntity);
                    MasterEntity.XmlDataDocument_SEL_T002_A = obj.ObjectToXML(ItemScheduleEntity);
                    MasterEntity.XmlDataDocument_SEL_T001_E = obj.ObjectToXML(TermsConditionEntity);

                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<SEL_T001>(MasterEntity, "SalesOrderMaster", "CRM");
                        if (MasterEntity.sono != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnInsert") >= 0)
                        {
                            NotifyMessage("OnInsert");
                        }
                        if (MasterEntity.sono != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnApproval") >= 0)
                        {
                            NotifyMessage("OnApproval");
                        }
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<SEL_T001>(MasterEntity, "SalesOrderMaster", "CRM");

                        if (MasterEntity.sono != null && NotificationDataCollection.Exists(element => element.alert_name == "OnUpdate") == true)
                        {
                            NotifyMessage("OnUpdate");
                        }
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    isNewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
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


        protected override void OnCreateAction(InquiryActionResult<SEL_T001> result)
        {
            try
            {
                isNewRecord = true;
                MasterEntity = new SEL_T001();
                //MasterEntity.ValidateAsync().Wait();
                ItemsEntity = new ObservableCollection<SEL_T001_A>();
                TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
                TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>();
                TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
                ScheduleEntity = new SEL_T002();
                TermsConditionEntity = new ObservableCollection<SEL_T001_E>();
                ItemScheduleEntity = new ObservableCollection<SEL_T002_A>();
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
        protected override void OnRemoveAction(InquiryActionResult<SEL_T001> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<SEL_T001> result)
        {
            //SelectedSEL_T001.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<SEL_T001> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<SEL_T001> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<SEL_T001> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<SEL_T001> result)
        {
            try
            {
                string Request = "SO_Report" + "!@" + MasterEntity.sono;
                string ReportName = "";

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, Request, "SalesOrderMaster", "CRM", "LoadDocumentWithDocumentNumber", 0, "");
                object[] objDataSource = new object[7];
                string[] objDataSourceName = new string[7];

                TotalDocumentTaxes = MCTemp.TaxEntity;

                objDataSource[0] = MCTemp.MasterEntity;
                objDataSource[1] = MCTemp.ItemsEntity;
                objDataSource[2] = TotalDocumentTaxes;


                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[3] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[4] = Result;
                objDataSource[5] = MCTemp.ScheduleDetailsEntity;
                objDataSource[6] = MCTemp.TermsAndCondition;

                objDataSourceName[0] = "dsSalesQuotation";
                objDataSourceName[1] = "dsSalesQuotationItem";
                objDataSourceName[2] = "dsSalesQuotationTax";
                objDataSourceName[3] = "dsCompany";
                objDataSourceName[4] = "dsLocation";
                objDataSourceName[5] = "dsScheduleDetailsEntity";
                objDataSourceName[6] = "dsTermsCondition";


                ReportManager ReportManager = new ReportManager();

                var ReportStringList = (from o in MC.DocumentTypes where o.doc_type == MasterEntity.doc_type select o).ToList();
                if (MasterEntity.doc_type == "EX")
                {
                    ReportName = ReportStringList[0].report_name.Split(',')[0];

                }
                else
                {
                    ReportName = ReportStringList[0].report_name.Split(',')[0];
                }

                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, getParametersList(), MC.DocumentTypes[0].report_name); //QuotationMurRpt.rdlc
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
                result.Add("prepare_by", AppSessionState.Name);
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
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.sono))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.sono.Replace("/", "--"), DocumentList = MCTemp.Attachment, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<SEL_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<SEL_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<SEL_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<SEL_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<SEL_T001> result)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Event Handler
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "quantity" || e.PropertyName == "unit_price" || e.PropertyName == "tax_id" || e.PropertyName == "active" || e.PropertyName == "discount")
                {
                    TaxComputation(true);
                }
                if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
                }
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (SEL_T001_A item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (SEL_T001_A item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    try
                    {
                        foreach (SEL_T001_A item in e.NewItems)
                        {

                            if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                            {
                                ItemsEntity[dgSelectedIndexItem].order_to_plant = MasterEntity.location_Id;
                            }

                            item.PropertyChanged += EntityViewModelPropertyChanged;
                        }
                        if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                        {
                            this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
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

                if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                    this.ErrorExist = false;/*MasterEntity.HasErrors;*/
                    if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    SEL_T001_A temp = (SEL_T001_A)e.OldItems[0];
                    foreach (var itemToRemove in ItemScheduleEntity.Where(x => (x.ItemCode == temp.ItemCode && x.id == 0 && x.sku == temp.sku)).ToList())
                    {
                        ItemScheduleEntity.Remove(itemToRemove);
                    }
                    if (TotalDocumentTaxes.Count > 0) // Remove Taxes deleted item.
                    {
                        List<ACC_T006_B> copy = new List<ACC_T006_B>();
                        copy = TotalDocumentTaxes.ToList();
                        foreach (var tax in copy)
                        {
                            if (tax.ItemCode == temp.ItemCode && tax.sku == temp.sku && tax.item_line_id == temp.id)
                            {
                                TotalDocumentTaxes.Remove(tax);
                                TaxComputation(true);
                            }
                        }

                    }

                    // option for Multiple condition where clause
                    //Accounts.Where(acc => !(acc.ColA == "X" || (acc.ColA == "Y" && acc.ColB == "T"))).ToArray();
                    //OR
                    //Accounts
                    //        .Where(acc => !(acc.ColA == "X"))
                    //        .Where(acc => !(acc.ColA == "Y" && acc.ColB == "T"))
                    //        .ToArray();
                    foreach (SEL_T001_A item in e.OldItems)
                    {
                        item.PropertyChanged -= EntityViewModelPropertyChanged;
                    }
                    if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = false;/*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Move)
                {
                }
            }
            catch (Exception ex) { }
        }
        void Schedule_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "qty")
                {
                    #region Check Schedule Qty Total should not exceed PO Qty.
                    //Check Schedule Qty Total should not exceed PO Qty.
                    decimal? TotalQtyOfScheduleForItem = 0;
                    TotalQtyOfScheduleForItem = ItemScheduleEntity.Where(item => item.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && item.sku == ItemsEntity[dgSelectedIndexItem].sku).Sum(item => item.sch_qty);
                    decimal? POQty = ItemsEntity[dgSelectedIndexItem].quantity;  // pending error : index > count
                    if (TotalQtyOfScheduleForItem > POQty)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "PO Schedule Information";
                        showMessageService.Text = String.Format("Schedule quantity exceeding Order limit. extra Quantity will required additional Sales Order", this.Title);
                        showMessageService.ShowMessage();
                    }
                    #endregion
                }
                if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
                }
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForSchedule(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (SEL_T002_A item in e.NewItems)
                        item.PropertyChanged += this.Schedule_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (SEL_T002_A item in e.OldItems)
                        item.PropertyChanged -= this.Schedule_PropertyChanged;

                /////////////////////////////////Temp Test End
                if (e.Action == NotifyCollectionChangedAction.Add && ItemsEntity.Count > 0) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (SEL_T002_A item in e.NewItems)
                    {
                        //Adde items Schedules Default Values from Items Entity
                        try
                        {
                            item.ItemCode = ItemsEntity[dgSelectedIndexItem].ItemCode;
                            item.unit_code = ItemsEntity[dgSelectedIndexItem].unit_code;
                            item.sku = ItemsEntity[dgSelectedIndexItem].sku;
                            item.sono = ItemsEntity[dgSelectedIndexItem].sono;
                            item.sch_qty = 0;
                            item.t_status = "Draft";
                            item.active = true;
                            item.editby = AppSessionState.UserID;
                            item.add_by = AppSessionState.UserID;
                            item.location_Id = AppSessionState.location_Id;
                            item.comp_code = AppSessionState.comp_code;
                            item.rate = 0;
                            item.line_id = 0;

                            item.PartyNm = ItemScheduleEntity[0].PartyNm;



                            item.PropertyChanged += EntityViewModelPropertyChanged;
                        }
                        catch (Exception ex) { }
                    }
                }

                if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                }
                if (e.Action == NotifyCollectionChangedAction.Move)
                {
                }
            }
            catch (Exception ex) { }
        }

        private void CollectionChangedNotifyForTotalTaxes(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (ACC_T006_B item in e.NewItems)
                        item.PropertyChanged += this.EntityViewModelPropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (ACC_T006_B item in e.OldItems)
                        item.PropertyChanged -= this.EntityViewModelPropertyChanged;

                /////////////////////////////////Temp Test End
                if (e.Action == NotifyCollectionChangedAction.Add && ItemsEntity.Count > 0) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (ACC_T006_B item in e.NewItems)
                    {

                        if (item.tax_code_id > 0)
                        { item.manual = "Auto"; }
                        else { item.manual = "Manual"; item.sequence = 100; }
                        if (item.tax_name == null || item.tax_name.Trim() == "")
                        { item.tax_name = "CASH"; }
                        item.active = true;
                        item.location_Id = AppSessionState.location_Id;
                        item.comp_code = AppSessionState.comp_code;
                        item.PropertyChanged += EntityViewModelPropertyChanged;
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
            catch (Exception ex) { }
        }


        private void CollectionChangedNotifyForTerms(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (SEL_T001_E item in e.NewItems)
                        item.PropertyChanged += this.EntityViewModelPropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (SEL_T001_E item in e.OldItems)
                        item.PropertyChanged -= this.EntityViewModelPropertyChanged;

                /////////////////////////////////Temp Test End
                if (e.Action == NotifyCollectionChangedAction.Add) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (SEL_T001_E item in e.NewItems)
                    {
                        item.editby = AppSessionState.UserID;
                        item.add_by = AppSessionState.UserID;
                        item.active = true;
                        item.location_Id = AppSessionState.location_Id;
                        item.comp_code = AppSessionState.comp_code;
                        item.doc_type = "SO";
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


        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false;/*MasterEntity.HasErrors;*/
            if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
            }

        }
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            try
            {
                //This will get called when the property of an object inside the collection changes
                if (sender.ToString() == "line_id" || sender.ToString() == "quantity" || sender.ToString() == "unit_price" || sender.ToString() == "tax_id" || sender.ToString() == "active" || sender.ToString() == "discount")
                {
                    TaxComputation(true);
                }
                this.ErrorExist = false; /*MasterEntity.HasErrors;*/
                if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = false;/*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
                }
            }
            catch (Exception ex) { }

        }


        void ModelUpdated_ScheduleMaster(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
        }

        void ModelUpdated_ScheduleItem(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
        }
        #endregion
        #region User Defined Functions

        private void LoadInitialData()
        {
            try
            {

                MasterEntity.doc_cat = "SO";
                MasterEntity.doc_type = "SO";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + AppSessionState.EmpId;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MC, Request, "SalesOrderMaster", "CRM", "LoadAll", 0, "");

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

                Doc_TypeCollection = CollectionViewSource.GetDefaultView(MC.DocumentTypes);
                Doc_TypeCollection.Filter = new Predicate<object>(Filter_DocType);
                StringListDocumentTypes = MC.DocumentTypes.Select(x => x.doc_type_user).ToList();

                PartyCollection = CollectionViewSource.GetDefaultView(MC.PartyMaster);
                PartyCollection.Filter = new Predicate<object>(Filter_Party);
                StringListParty = MC.PartyMaster.Select(x => x.PartyId).ToList();

                SupplierCollection = CollectionViewSource.GetDefaultView(MC.Supplier);
                SupplierCollection.Filter = new Predicate<object>(Filter_Supplier);
                StringListsupplier = MC.Supplier.Select(x => x.PartyNm).ToList();

                dgTransporterCollection = CollectionViewSource.GetDefaultView(MC.Transporters);
                dgTransporterCollection.Filter = new Predicate<object>(Filter_dgTransporter);
                StringListdgTransporter = MC.Transporters.Select(x => x.PartyNm).ToList();

                TransporterCollection = CollectionViewSource.GetDefaultView(MC.Transporters);
                TransporterCollection.Filter = new Predicate<object>(Filter_Transporter);
                StringListTransporter = MC.Transporters.Select(x => x.PartyId).ToList();

                ServiceProviderCollection = CollectionViewSource.GetDefaultView(MC.ServiceProviders);
                ServiceProviderCollection.Filter = new Predicate<object>(Filter_ServiceProvider);
                StringListServiceProvider = MC.ServiceProviders.Select(x => x.PartyId).ToList();

                UomCollection = CollectionViewSource.GetDefaultView(MC.UOM.ToList());
                UomCollection.Filter = new Predicate<object>(Filter_UOM);
                StringListUOM = MC.UOM.Select(x => x.unit_code).ToList();

                SellerCollection = CollectionViewSource.GetDefaultView(MC.Sellers.ToList());
                SellerCollection.Filter = new Predicate<object>(Filter_Seller);
                StringListSeller = MC.Sellers.Select(x => x.EmpId).ToList();

                journalCollection = CollectionViewSource.GetDefaultView(MC.Journals);
                journalCollection.Filter = new Predicate<object>(Filter_Journal);
                StringListJournal = MC.Journals.Select(x => x.j_code).ToList();

                GLCodeCollection = CollectionViewSource.GetDefaultView(MC.GLCodes);
                GLCodeCollection.Filter = new Predicate<object>(Filter_GLCode);
                StringListGLCode = MC.GLCodes.Select(x => x.acc_code).ToList();

                PayTermCollection = CollectionViewSource.GetDefaultView(MC.PayTerms.ToList());
                PayTermCollection.Filter = new Predicate<object>(Filter_PayTerms);
                StringListPayTerms = MC.PayTerms.Select(x => x.p_term_code).ToList();

                CurrencyCollection = CollectionViewSource.GetDefaultView(MC.Currencys);
                CurrencyCollection.Filter = new Predicate<object>(Filter_Currency);
                StringListCurrency = MC.Currencys.Select(x => x.curr_code).ToList();

                SalesOrganisationList = (List<ADM_M001_A_P>)AppSessionState.ADM_M001_A_List;
                Salse_OrgCollection = CollectionViewSource.GetDefaultView(SalesOrganisationList);
                Salse_OrgCollection.Filter = new Predicate<object>(Filter_SalesOrg);
                StringListSalesOrg = SalesOrganisationList.Select(x => x.so_code).ToList();
                if (SalesOrganisationList.Count != 0)
                {
                    if (SalesOrganisationList.Count == 1)
                    {
                        MasterEntity.so_code = SalesOrganisationList[0].so_code;
                        MasterEntity.sales_org = SalesOrganisationList[0].sales_org;
                    }
                }
                else
                {
                    MasterEntity.so_code = "";
                }
                SalesGroupList = (List<ADM_M001_H_P>)AppSessionState.ADM_M001_H_List;
                Salse_GroupCollection = CollectionViewSource.GetDefaultView(SalesGroupList);
                Salse_GroupCollection.Filter = new Predicate<object>(Filter_SalesGroup);
                StringListSalesGroup = SalesGroupList.Select(x => x.sg_code).ToList();

                if (SalesGroupList.Count != 0)
                {
                    if (SalesGroupList.Count == 1)
                    {
                        MasterEntity.sg_code = SalesGroupList[0].sg_code;
                        MasterEntity.sg_name = SalesGroupList[0].sg_name;
                    }
                }
                else
                {
                    MasterEntity.sg_code = "";
                }

                Salse_DivCollection = CollectionViewSource.GetDefaultView(MC.SalesDiv);
                Salse_DivCollection.Filter = new Predicate<object>(Filter_SalesGroup);
                StringListSalesDivision = MC.SalesDiv.Select(x => x.div_code).ToList();

                ItemcategoryCollection = CollectionViewSource.GetDefaultView(MC.ItemLineCategory);
                ItemcategoryCollection.Filter = new Predicate<object>(Filter_ItemCategory);
                StringListItemCategory = MC.ItemLineCategory.Select(x => x.sditem_cat_code).ToList();

                Cost_CenterCollection = CollectionViewSource.GetDefaultView(MC.Cost_Centers);
                Cost_CenterCollection.Filter = new Predicate<object>(Filter_Cost_Center);
                StringListCostCenter = MC.Cost_Centers.Select(x => x.cost_center).ToList();

                BankCollection = CollectionViewSource.GetDefaultView(MC.Banks);
                BankCollection.Filter = new Predicate<object>(Filter_Banks);
                StringListBanks = MC.Banks.Select(x => x.bank_code).ToList();

                BallTypeCollection = CollectionViewSource.GetDefaultView(MC.BallTypes);
                BallTypeCollection.Filter = new Predicate<object>(Filter_BallType);
                StringListBallType = MC.BallTypes.Select(x => x.ball_type).ToList();

                var IldCollection = (from o in MC.ILDs where o.ild_type=="P" select o).ToList();
                ILDCollection = CollectionViewSource.GetDefaultView(IldCollection.ToList());
                ILDCollection.Filter = new Predicate<object>(Filter_ILD);
                StringListILD = MC.ILDs.Select(x => x.ild).ToList();

                WireTypeCollection = CollectionViewSource.GetDefaultView(MC.WireTypes);
                WireTypeCollection.Filter = new Predicate<object>(Filter_WireType);
                StringListWireType = MC.WireTypes.Select(x => x.wire_type).ToList();

                BallDiaCollection = CollectionViewSource.GetDefaultView(MC.BallDias);
                BallDiaCollection.Filter = new Predicate<object>(Filter_BallDia);
                StringListBallDia = MC.BallDias.Select(x => x.Ball_dia.ToString()).ToList();

                InkCollection = CollectionViewSource.GetDefaultView(MC.Inks);
                InkCollection.Filter = new Predicate<object>(Filter_Ink);
                StringListInk = MC.Inks.Select(x => x.ink).ToList();

                GradeCollection = CollectionViewSource.GetDefaultView(MC.GradeCollection);
                GradeCollection.Filter = new Predicate<object>(Filter_Grade);

                IncotermsCollection = CollectionViewSource.GetDefaultView(MC.Incoterms);
                IncotermsCollection.Filter = new Predicate<object>(Filter_Incoterms);
                StringListIncoterms = MC.Incoterms.Select(x => x.incoterms).ToList();

                LicenseAdvanceCollection = CollectionViewSource.GetDefaultView(MC.LicenseAdvance);
                LicenseAdvanceCollection.Filter = new Predicate<object>(Filter_ADVANCELicense);
                StringListLicenseAdvance = MC.LicenseAdvance.Select(x => x.lic_cod).ToList();

                TermsConditionCollection = CollectionViewSource.GetDefaultView(MC.TermsConditionCollection);
                TermsConditionCollection.Filter = new Predicate<object>(Filter_Terms);
                StringListTerms = MC.TermsConditionCollection.Select(x => x.con_type).ToList();

                LicenseEPCGCollection = CollectionViewSource.GetDefaultView(MC.LicenseEPCG);
                LicenseEPCGCollection.Filter = new Predicate<object>(Filter_EPCGLicense);
                StringListLicenseEPCG = MC.LicenseEPCG.Select(x => x.lic_cod).ToList();

                var refdoctemp = (from o in MC.Sales_Order_Reference where o.doc_cat == "QN" select o).ToList();
                ReferenceDocCollection = CollectionViewSource.GetDefaultView(refdoctemp.ToList());
                ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                StringListReferenceDoc = MC.Sales_Order_Reference.Select(x => x.sono).ToList();

                TaxDictonery = new Dictionary<string, object>();
                TaxDictonery.Clear();
                TaxDictonery = MC.TaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);

                var TaxListParent = (from o in MC.TaxList
                                     where o.parent_id == null
                                     select o).ToList();
                SelectedTaxList = TaxListParent;
                TaxDictoneryParent = SelectedTaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);

                CompanyList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                CompanyCodeCollection = CollectionViewSource.GetDefaultView(CompanyList);
                //CompanyCodeCollection.Filter = new Predicate<object>(Filter_CompanyCode); // Pending Filter
                StringListCompanyCode = CompanyList.Select(x => x.comp_code).ToList();

                LocationList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                LocationCollection = CollectionViewSource.GetDefaultView(LocationList);
                LocationCollection.Filter = new Predicate<object>(Filter_dgLocation);
                StringListLocationID = LocationList.Select(x => x.location_Id).ToList();


                var location = (from o in LocationList where o.comp_code == AppSessionState.comp_code  select o).ToList();
                dgLocationCollection  = CollectionViewSource.GetDefaultView(location);
                dgLocationCollection.Filter = new Predicate<object>(Filter_dgLocation);
                StringListdgLocationID = location.Select(x => x.location_Id).ToList();


                NotificationDataCollection = MC.NotificationData;


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
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.XmlDataDocument_SEL_T001_A != null)
                {
                    ItemsEntity.Clear();
                    ItemsEntity = (ObservableCollection<SEL_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_SEL_T001_A, MC.ItemsEntity);
                    MasterEntity = MasterEntity;
                }
                else
                {
                    MC.ItemsEntity = new ObservableCollection<SEL_T001_A>();
                }
                if (MasterEntity.XmlDataDocument_ACC_T006_B != null)
                {
                    MC.TaxEntity = (ObservableCollection<ACC_T006_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_T006_B, MC.TaxEntity);
                    TotalDocumentTaxes.Clear();
                    TotalDocumentTaxes = MC.TaxEntity;
                    //var GroupByTaxQuery = from wo in TotalDocumentTaxes
                    //                      group wo by wo.tax_name  // tax_code_id replace with tax_name due to manual Tax integration.
                    //            into g
                    //                      select new ACC_T006_B
                    //                      {
                    //                          id = g.First().id,
                    //                          tax_amount = g.Sum(wo => wo.tax_amount),
                    //                          base_amount = g.Sum(wo => wo.base_amount),
                    //                          tax_code_id = g.First().tax_code_id,
                    //                          tax_name = g.First().tax_name,
                    //                          gl_code = g.First().gl_code,
                    //                          active = g.First().active,
                    //                          account_id = g.First().account_id,
                    //                      };
                    //TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>(GroupByTaxQuery.OrderBy(tax => tax.tax_name));
                }
                else
                {
                    MC.TaxEntity = new ObservableCollection<ACC_T006_B>();
                }
                if (MasterEntity.XmlDataDocument_SEL_T002 != null)
                {
                    List<SEL_T002> ScheduleEntityList = new List<SEL_T002>();
                    ScheduleEntityList = (List<SEL_T002>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_SEL_T002, ScheduleEntityList);
                    if (ScheduleEntityList.Count > 0)
                    {
                        ScheduleEntity = ScheduleEntityList[0];
                    }
                }
                else
                {
                    ScheduleEntity = new SEL_T002();
                }
                if (MasterEntity.XmlDataDocument_SEL_T002_A != null)
                {
                    MC.ScheduleDetailsEntity = (ObservableCollection<SEL_T002_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_SEL_T002_A, MC.ScheduleDetailsEntity);
                    ItemScheduleEntity.Clear();
                    ItemScheduleEntity = MC.ScheduleDetailsEntity;
                }
                else
                {
                    MC.ScheduleDetailsEntity = new ObservableCollection<SEL_T002_A>();
                }
                if (MasterEntity.XmlDataDocument_FlipGrid != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<SEL_T001_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                    
                }
                if (MasterEntity.XmlDataDocument_SEL_T001_E != null)
                {

                    MC.TermsAndCondition = (ObservableCollection<SEL_T001_E>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_SEL_T001_E, MC.TermsAndCondition);

                    TermsConditionEntity = MC.TermsAndCondition;
                }
                else
                {
                    TermsConditionEntity = new ObservableCollection<SEL_T001_E>();
                }

                _ReferenceDocCollection.Refresh();
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
            try
            {
                MasterEntity.doc_cat = "SO";
                MasterEntity.doc_type = "SO";

                MasterEntity.location_Id = AppSessionState.location_Id;
                MasterEntity.comp_code = AppSessionState.comp_code;
                MasterEntity.add_by = AppSessionState.UserID;
                MasterEntity.editby = AppSessionState.UserID;
                MasterEntity.active = true;
                MasterEntity.t_status = "Draft";
                MasterEntity.shipped = false;
                MasterEntity.version = "v1.0";
                MasterEntity.sodate = DateTime.Now;
                MasterEntity.sono = "";
                //MasterEntity.fin_year = "16-17";
                //MasterEntity.posting_period = "3";
                MasterEntity.ind_trade = "D";

                if (SalesOrganisationList.Count == 1)
                {
                    MasterEntity.so_code = SalesOrganisationList[0].so_code;
                    MasterEntity.sales_org = SalesOrganisationList[0].sales_org;
                }
                if (SalesGroupList.Count == 1)
                {
                    MasterEntity.sg_code = SalesGroupList[0].sg_code;
                    MasterEntity.sg_name = SalesGroupList[0].sg_name;
                }

                ScheduleEntity.t_status = "Draft";
                ScheduleEntity.sch_date = DateTime.Now;
                ScheduleEntity.active = true;
                ScheduleEntity.add_by = AppSessionState.UserID;
                ScheduleEntity.editby = AppSessionState.UserID;
                ScheduleEntity.comp_code = AppSessionState.comp_code;
                ScheduleEntity.location_Id = AppSessionState.location_Id;
                ScheduleEntity.id = 0;
                ScheduleEntity.PartyId = MasterEntity.PartyId;
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
        private void TaxComputation(bool Compute)
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

                    if (ItemsEntity != null && ItemsEntity.Count > 0 && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < ItemsEntity.Count) //Condition satisfy only if Items collection is not empty.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].quantity >= 0 && ItemsEntity[dgSelectedIndexItem].unit_price >= 0 && ItemsEntity[dgSelectedIndexItem].active != false) // Must not null or empty.
                        {
                            if (ItemsEntity[dgSelectedIndexItem].discount == null)
                            {
                                ItemsEntity[dgSelectedIndexItem].discount = 0;
                            }
                            ItemsEntity[dgSelectedIndexItem].sub_total = (ItemsEntity[dgSelectedIndexItem].quantity * ItemsEntity[dgSelectedIndexItem].unit_price) - ((ItemsEntity[dgSelectedIndexItem].quantity * ItemsEntity[dgSelectedIndexItem].unit_price) * (ItemsEntity[dgSelectedIndexItem].discount / 100));
                        }
                        #region Remove previously assign Taxes to apply new for perticuler item row.
                        //if (TotalDocumentTaxes.Count > 0 && ItemsEntity[dgSelectedIndexItem].tax_id != null) // Remove previously assign Taxes to apply new for perticuler item row.//Condition satisfy only if Selected Item not null.
                        if (ItemsEntity[dgSelectedIndexItem].tax_id != null && ItemsEntity[dgSelectedIndexItem].active == true) // Remove previously assign Taxes to apply new for perticuler item row.//Condition satisfy only if Selected Item not null.
                        {
                            if (!String.IsNullOrEmpty(ItemsEntity[dgSelectedIndexItem].tax_id.Trim()) && ItemsEntity[dgSelectedIndexItem].active != false) //Condition satisfy only if Selected Item having Tax assigned.
                            {
                                List<ACC_T006_B> copy = new List<ACC_T006_B>();
                                copy = TotalDocumentTaxes.ToList();
                                foreach (var tax in copy)
                                {
                                    if (tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && tax.sku == ItemsEntity[dgSelectedIndexItem].sku)
                                    {
                                        TotalDocumentTaxes.Remove(tax);
                                    }
                                }
                                #region Tax Not Null

                                List<ACC_M013_P> TaxListTemp = new List<ACC_M013_P>();
                                string[] TaxArray = ItemsEntity[dgSelectedIndexItem].tax_id.Trim().Split(',');
                                foreach (string SingleTax in TaxArray) // select all Taxes & Child Taxes which is applicablt for Item.
                                {
                                    foreach (ACC_M013_P PickTax in MC.TaxList)
                                    {
                                        if (PickTax.id == Convert.ToInt32(SingleTax) || PickTax.parent_id == Convert.ToInt32(SingleTax))
                                        {
                                            TaxListTemp.Add(PickTax); // collection of All Parent and Child Taxes applicable for current Item.
                                        }
                                    }
                                }
                                // pending check index
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
                                    foreach (ACC_M013_P SingleTax in TaxListTemp) // Foreach Loop for Computation of Induvidual Tax as per the proerties in Tax Master.
                                    {
                                        PreviousTaxValueForBasePrice = 0;
                                        BasePrice = 0;
                                        TaxAmount = 0;
                                        BasicItemAmount = 0;
                                        TaxValue = 0;
                                        TaxtTotal = 0;
                                        UnTaxTotal = 0;
                                        GrandTotal = 0;
                                        #region Percentage
                                        if (SingleTax.t_type == "Percentage" && SingleTax.amount > 0)
                                        {
                                            if (SingleTax.Price_include == true)
                                            {
                                                TaxValue = (SingleTax.amount) / 100 + 1;
                                                BasePrice = ItemsEntity[dgSelectedIndexItem].sub_total / TaxValue;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = ItemsEntity[dgSelectedIndexItem].sub_total - BasicItemAmount;
                                            }
                                            else if (SingleTax.Price_include == false)
                                            {
                                                TaxValue = (SingleTax.amount) / 100;
                                                if (TaxListForBaseInclude.Length > 0)
                                                {
                                                    PreviousTaxValueForBasePrice = TotalDocumentTaxes.Where(tax => tax.sequence < SingleTax.sequence && tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && tax.sku == ItemsEntity[dgSelectedIndexItem].sku && tax.item_line_id == ItemsEntity[dgSelectedIndexItem].id && tax.tax_code_id.In(TaxListForBaseInclude)).Sum(tax => tax.tax_amount); // Get Base amount for Calculation.
                                                }
                                                if (SingleTax.parent_id != null) // Collect Base price for This single child Tax.
                                                {
                                                    BasePrice = TotalDocumentTaxes.Where(tax => tax.tax_code_id == SingleTax.parent_id && tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && tax.sku == ItemsEntity[dgSelectedIndexItem].sku && tax.item_line_id == ItemsEntity[dgSelectedIndexItem].id).Single().tax_amount;
                                                }
                                                else // Collect Base Price for this parent Tax.
                                                {
                                                    BasePrice = ItemsEntity[dgSelectedIndexItem].sub_total + PreviousTaxValueForBasePrice;
                                                }
                                                BasicItemAmount = ItemsEntity[dgSelectedIndexItem].sub_total;
                                                TaxAmount = BasePrice * TaxValue;
                                            }
                                        }
                                        #endregion
                                        #region Fixed Amount
                                        else if (SingleTax.t_type == "Fixed Amount" && SingleTax.amount > 0)
                                        {
                                            TaxValue = SingleTax.amount;
                                            if (SingleTax.Price_include == true)
                                            {
                                                BasePrice = ItemsEntity[dgSelectedIndexItem].sub_total - TaxValue;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = ItemsEntity[dgSelectedIndexItem].sub_total - BasicItemAmount;
                                            }
                                            else if (SingleTax.Price_include == false)
                                            {
                                                BasePrice = ItemsEntity[dgSelectedIndexItem].sub_total;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = TaxValue;
                                            }
                                        }
                                        #endregion

                                        TotalDocumentTaxes.Add(new ACC_T006_B() { id = 0, tax_amount = TaxAmount, account_id = 0, sequence = SingleTax.sequence, doc_no = MasterEntity.po_no, manual = "Auto", base_amount = BasePrice, amount = SingleTax.amount, tax_code_id = SingleTax.id, account_analytic_id = 0, base_code_id = SingleTax.id, tax_name = SingleTax.description, gl_code = "", ItemCode = ItemsEntity[dgSelectedIndexItem].ItemCode, sku = ItemsEntity[dgSelectedIndexItem].sku, item_line_id = ItemsEntity[dgSelectedIndexItem].id, fin_year = "2015", active = true, location_Id = AppSessionState.location_Id, comp_code = AppSessionState.comp_code });
                                    }

                                }

                                #endregion
                            }
                            else if (ItemsEntity[dgSelectedIndexItem].tax_id == "" || ItemsEntity[dgSelectedIndexItem].tax_id == null || ItemsEntity[dgSelectedIndexItem].active == false) // Remove previously assign Taxes from TotalDocumentTaxes if removed from Item.//Condition satisfy only if Selected Item not null and Active status is false.
                            {
                                List<ACC_T006_B> copy2 = new List<ACC_T006_B>();
                                copy2 = TotalDocumentTaxes.ToList();
                                foreach (var tax in copy2)
                                {
                                    if (tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && tax.sku == ItemsEntity[dgSelectedIndexItem].sku)
                                    {
                                        TotalDocumentTaxes.Remove(tax);
                                    }
                                }
                            }
                        }

                        else if (ItemsEntity[dgSelectedIndexItem].tax_id != null && ItemsEntity[dgSelectedIndexItem].active == false) // Remove previously assign Taxes from TotalDocumentTaxes if removed from Item.//Condition satisfy only if Selected Item not null and Active status is false.
                        {
                            List<ACC_T006_B> copy2 = new List<ACC_T006_B>();
                            copy2 = TotalDocumentTaxes.ToList();
                            foreach (var tax in copy2)
                            {
                                if (tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && tax.sku == ItemsEntity[dgSelectedIndexItem].sku)
                                {
                                    TotalDocumentTaxes.Remove(tax);
                                }
                            }
                        }


                        #region Final Computation

                        //TaxtTotal = TotalDocumentTaxes.Sum(x => x.tax_amount);
                        TaxtTotal = TotalDocumentTaxes.Where(item => item.active != false).Sum(item => item.tax_amount);
                        MasterEntity.tax_amt = TaxtTotal;
                        //UnTaxTotal = ItemsEntity.Sum(x => x.sub_total);
                        UnTaxTotal = ItemsEntity.Where(item => item.active != false).Sum(item => item.sub_total);
                        MasterEntity.untax_amt = UnTaxTotal;
                        GrandTotal = UnTaxTotal + TaxtTotal;
                        MasterEntity.total_amt = GrandTotal;
                        MasterEntity.roundup_total = decimal.Round((decimal)GrandTotal);
                        MasterEntity.round_up = MasterEntity.roundup_total - GrandTotal;
                        if (MasterEntity.roundup_total > 0)
                        {
                            ADM_M037 curr_obj = new ADM_M037();
                            curr_obj = ((List<ADM_M037>)AppSessionState.CurrencyList).Where(x => x.curr_code == MasterEntity.curr_code).ToList()[0];
                            MasterEntity.amt_inword = num.AmountInWords(Convert.ToDecimal(MasterEntity.roundup_total), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word);
                        }
                        else
                        { MasterEntity.amt_inword = ""; }

                        //var GroupByTaxQuery = from wo in TotalDocumentTaxes
                        //                      group wo by wo.tax_name  // tax_code_id replace with tax_name due to manual Tax integration.
                        //            into g
                        //                      select new ACC_T006_B
                        //                      {
                        //                          id = g.First().id,
                        //                          tax_amount = g.Sum(wo => wo.tax_amount),
                        //                          base_amount = g.Sum(wo => wo.base_amount),
                        //                          tax_code_id = g.First().tax_code_id,
                        //                          tax_name = g.First().tax_name,
                        //                          gl_code = g.First().gl_code,
                        //                          active = g.First().active,
                        //                          account_id = g.First().account_id,
                        //                      };
                        //TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>(GroupByTaxQuery.OrderBy(tax => tax.tax_name));
                        #endregion
                        #endregion
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
        private bool Validation()
        {
            try
            {
                // Validation for Quantity Item Duplication and Unit Code For Item Details
                foreach (var o in ItemsEntity)
                {
                    int flag = 0;
                    if (o.id == 0)
                    {
                        foreach (var p in ItemsEntity)
                        {
                            if (o.ItemCode == p.ItemCode && o.sku == p.sku)
                            {
                                flag++;
                            }
                        }
                        if (flag > 1)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                            showMessageService.ShowMessage();
                            return false;
                        }
                    }

                    if (o.ItemCode != null && o.ItemCode != "" && o.Description != null)
                    {
                        if (MasterEntity.doc_type_user != "OP")
                        {
                            if (o.quantity == null || o.quantity == 0)
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Quantity cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                                showMessageService.ShowMessage();
                                return false;
                            }
                        }
                        if (MasterEntity.doc_type_user == "CL")
                        {

                            if (o.tax_id == null || o.tax_id == "")
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Please Enter At Least one tax for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                                showMessageService.ShowMessage();
                                return false;
                            }
                        }

                        if(o.para1==null || o.para1=="")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Enter Ink  for the item {0} ", o.ItemCode);
                            showMessageService.ShowMessage();
                            return false;

                        }
                        if (o.para5 == null || o.para5 == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Enter Ild for the item {0} ", o.ItemCode);
                            showMessageService.ShowMessage();
                            return false;

                        }
                        if (o.para3 == null || o.para3 == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Enter Grade for the item {0} ", o.ItemCode);
                            showMessageService.ShowMessage();
                            return false;

                        }
                    }
                }

                //Validation For Item Quantity Equal To Sum of Quantities of All Batches Of the Item 
                //bool breakfor = false;
                //for (int i = 0; i < ItemsEntity.Count; i++)
                //{
                //    decimal temp = 0;
                //    int flag = 0;

                //    for (int j = 0; j < ItemScheduleEntity.Count; j++)
                //    {
                //        if (ItemsEntity[i].ItemCode == ItemScheduleEntity[j].ItemCode && ItemsEntity[i].sku == ItemScheduleEntity[j].sku)
                //        {
                //            temp = temp + Convert.ToDecimal(ItemScheduleEntity[j].sch_qty);
                //            flag = 1;
                //        }
                //    }
                //    if (MasterEntity.doc_type_user != "OP")
                //    {
                //        if (ItemsEntity[i].quantity != temp && flag == 1)
                //        {
                //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //            showMessageService.ButtonSetup = DialogButton.Ok;
                //            showMessageService.Caption = "Message";
                //            showMessageService.Text = String.Format("Item Quantity is Not Equal to Sum of All Item Batches Quantities for Item {0} Parameter :{1} ", ItemsEntity[i].ItemCode, ItemsEntity[i].sku_desc);
                //            showMessageService.ShowMessage();
                //            breakfor = false;
                //            return false;
                //        }
                //    }
                //}
                if (MasterEntity.sales_person_cd == null || MasterEntity.sales_person_cd == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Sales Person Is Required");
                    showMessageService.ShowMessage();

                    return false;
                }
                if (MasterEntity.ind_trade == null || MasterEntity.ind_trade == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Transaction Type is Required");
                    showMessageService.ShowMessage();

                    return false;
                }
                if (MasterEntity.doc_type_user == null || MasterEntity.doc_type_user == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Order Type is Required");
                    showMessageService.ShowMessage();

                    return false;
                }
               
                if (MasterEntity.so_code == null || MasterEntity.so_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Sales Organisation is Required");
                    showMessageService.ShowMessage();

                    return false;
                }
                if (MasterEntity.sg_code == null || MasterEntity.sg_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Sales Group is Required");
                    showMessageService.ShowMessage();

                    return false;
                }

                if (MasterEntity.location_Id == null || MasterEntity.location_Id == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Plant is Required");
                    showMessageService.ShowMessage();

                    return false;
                }
                if (MasterEntity.curr_code == null || MasterEntity.curr_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Currancy is Required");
                    showMessageService.ShowMessage();

                    return false;
                }
                
                if (MasterEntity.PartyId == null || MasterEntity.PartyId == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Sold To Party is Required");
                    showMessageService.ShowMessage();

                    return false;
                }
                if (ItemsEntity.Count < 1)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Item Code is Required");
                    showMessageService.ShowMessage();

                    return false;

                }
                if (MasterEntity.copy == true)
                {
                    isNewRecord = true;
                    MasterEntity.ref_doc_no = "";

                }

                if (MasterEntity.doc_type_user == "OP")
                {
                    if (MasterEntity.valid_from_date == null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Validity From Date is Required");
                        showMessageService.ShowMessage();

                        return false;
                    }
                    if (MasterEntity.valid_to_date == null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Validity To Date is Required");
                        showMessageService.ShowMessage();

                        return false;
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
            return true;
        }

        // FilterScheduleDataGrid : Filter for Schedule Items as per selected item in ItemsEntity. This filter is work for ObserverableCollection.
        private void FilterScheduleDataGrid()
        {
            try
            {
                if (ItemScheduleEntity != null && ItemScheduleEntity.Count > 0 && dgSelectedIndexItem >= 0)
                {
                    DataGridViewFilter = CollectionViewSource.GetDefaultView(ItemScheduleEntity);
                    DataGridViewFilter.Filter = adv => ((SEL_T002_A)adv).ItemCode.Equals(ItemsEntity[dgSelectedIndexItem].ItemCode);
                    DataGridViewFilter.Refresh();
                }
            }
            catch (Exception ex)
            { }
        }

        private void NotifyMessage(string AlertName)
        {
            try
            {
                List<NotificationData> objNotifyData = new List<NotificationData>();

                objNotifyData = NotificationDataCollection.Where(x => x.alert_name == AlertName).ToList();
                foreach (NotificationData VarData in objNotifyData)
                {
                    List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("[EMP]",AppSessionState.Name),
                        new KeyValuePair<string, string>("[DOC]", MasterEntity.doc_desc),
                        new KeyValuePair<string, string>("[DOCNO]", MasterEntity.sono),
                        new KeyValuePair<string, string>("[Comp]","M/s: " +AppSessionState.CompanyName),
                        new KeyValuePair<string, string>("[Attn]",VarData.EmpName),
                        new KeyValuePair<string, string>("[CUST]","M/s: " +  MasterEntity.party_name),
                        new KeyValuePair<string, string>("[OVAL]",MasterEntity.roundup_total.ToString()),
                        new KeyValuePair<string, string>("[CUR]",MasterEntity.curr_code.ToString()),
                        new KeyValuePair<string, string>("[DOCDATE]", MasterEntity.sodate.ToString()),
                    };

                    foreach (KeyValuePair<string, string> kvp in kvpList)
                    {
                        VarData.subject = VarData.subject.Replace(kvp.Key, kvp.Value);
                        VarData.msg_body = VarData.msg_body.Replace(kvp.Key, kvp.Value);
                    }
                    Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, VarData.to_mail_id, VarData.cc_mail_id, VarData.bcc_mail_id, VarData.subject, VarData.msg_body, null);
                }
            }
            catch (Exception ex)
            {

            }
        }
        #endregion
       
        #region Filters

        private string _filterString_DocType;
        public string FilterString_DocType
        {
            get { return _filterString_DocType; }
            set
            {
                _filterString_DocType = value;
                RaisePropertyChanged("FilterString_DocType");
                FilterCollection_DocType();
            }
        }
        private void FilterCollection_DocType()
        {
            if (_doc_typeCollection != null)
            {
                _doc_typeCollection.Refresh();
            }
        }
        public bool Filter_DocType(object obj)
        {
            var data = obj as SYS_M002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_DocType))
                {
                    return (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_filterString_DocType.ToLower())) ||
                        (data.doc_desc != null && data.doc_desc.ToString().ToLower().Contains(_filterString_DocType.ToLower())) ||
                         (data.doc_type_user != null && data.doc_type_user.ToString().ToLower().Contains(_filterString_DocType.ToLower()));

                }
                return true;
            }
            return false;
        }

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
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as SEL_T001_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return (data.sono != null && data.sono.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.sodate != null && data.sodate.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.cust_ref != null && data.cust_ref.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.Seller != null && data.Seller.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.buyer_name != null && data.buyer_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.doc_type_user != null && data.doc_type_user.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.doc_desc_user != null && data.doc_desc_user.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.so_code != null && data.so_code.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.party_name != null && data.party_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_Party;
        public string FilterString_Party
        {
            get { return _filterString_Party; }
            set
            {
                _filterString_Party = value;
                RaisePropertyChanged("FilterString_Party");
                FilterCollection_Party();
            }
        }
        private void FilterCollection_Party()
        {
            if (_partyCollection != null)
            {
                _partyCollection.Refresh();
            }
        }
        public bool Filter_Party(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Party))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_Party.ToLower()) ||
                        data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_Party.ToLower()));
                }
                return true;
            }
            return false;
        }


        private string _FilterString_supplier;
        public string FilterString_supplier
        {
            get { return _FilterString_supplier; }
            set
            {
                _FilterString_supplier = value;
                RaisePropertyChanged("FilterString_supplier");
                FilterCollection_supplier();
            }
        }
        private void FilterCollection_supplier()
        {
            if (_SupplierCollection != null)
            {
                _SupplierCollection.Refresh();
            }
        }
        public bool Filter_Supplier(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_supplier))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_FilterString_supplier.ToLower()) ||
                        data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_FilterString_supplier.ToLower()));
                }
                return true;
            }
            return false;
        }





        private string _filterString_Transporter;
        public string FilterString_Transporter
        {
            get { return _filterString_Transporter; }
            set
            {
                _filterString_Transporter = value;
                RaisePropertyChanged("FilterString_Transporter");
                FilterCollection_Transporter();
            }
        }
        private void FilterCollection_Transporter()
        {
            if (_transporterCollection != null)
            {
                _transporterCollection.Refresh();
            }
        }
        public bool Filter_Transporter(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Transporter))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_Transporter.ToLower())) ||
                           (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_Transporter.ToLower()));
                }
                return true;
            }
            return false;
        }


        private string _filterString_dgTransporter;
        public string FilterString_dgTransporter
        {
            get { return _filterString_dgTransporter; }
            set
            {
                _filterString_dgTransporter = value;
                RaisePropertyChanged("FilterString_dgTransporter");
                FilterCollection_dgTransporter();
            }
        }
        private void FilterCollection_dgTransporter()
        {
            if (_dgTransporterCollection != null)
            {
                _dgTransporterCollection.Refresh();
            }
        }
        public bool Filter_dgTransporter(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_dgTransporter))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_dgTransporter.ToLower()) ||
                        data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_dgTransporter.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_ServiceProvider;
        public string FilterString_ServiceProvider
        {
            get { return _filterString_ServiceProvider; }
            set
            {
                _filterString_ServiceProvider = value;
                RaisePropertyChanged("FilterString_ServiceProvider");
                FilterCollection_ServiceProvider();
            }
        }
        private void FilterCollection_ServiceProvider()
        {
            if (_serviceProviderCollection != null)
            {
                _serviceProviderCollection.Refresh();
            }
        }
        public bool Filter_ServiceProvider(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ServiceProvider))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_ServiceProvider.ToLower()) ||
                        data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_ServiceProvider.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_UOM;
        public string FilterString_UOM
        {
            get { return _filterString_UOM; }
            set
            {
                _filterString_UOM = value;
                RaisePropertyChanged("FilterString_UOM");
                FilterCollection_UOM();
            }
        }
        private void FilterCollection_UOM()
        {
            if (_uomCollection != null)
            {
                _uomCollection.Refresh();
            }
        }
        public bool Filter_UOM(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_UOM))
                {
                    return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterString_UOM.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _FilterString_Saller;
        public string FilterString_Saller
        {
            get { return _FilterString_Saller; }
            set
            {
                _FilterString_Saller = value;
                RaisePropertyChanged("FilterString_Saller");
                FilterCollection_Seller();
            }
        }
        private void FilterCollection_Seller()
        {
            if (_sellerCollection != null)
            {
                _sellerCollection.Refresh();
            }
        }
        public bool Filter_Seller(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_Saller))
                {
                    return (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_FilterString_Saller.ToLower()) ||
                         data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_FilterString_Saller.ToLower())
                        );
                }
                return true;
            }
            return false;
        }

        private string _filterString_Journal;
        public string FilterString_Journal
        {
            get { return _filterString_Journal; }
            set
            {
                _filterString_Journal = value;
                RaisePropertyChanged("_filterString_Journal");
                FilterCollection_Journal();
            }
        }
        private void FilterCollection_Journal()
        {
            if (_journalCollection != null)
            {
                _journalCollection.Refresh();
            }
        }
        public bool Filter_Journal(object obj)
        {
            var data = obj as ACC_M005_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Journal))
                {
                    return (data.j_name != null && data.j_name.ToString().ToLower().Contains(_filterString_Journal.ToLower()) ||
                         data.j_code != null && data.j_code.ToString().ToLower().Contains(_filterString_Journal.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_GLCode;
        public string FilterString_GLCode
        {
            get { return _filterString_GLCode; }
            set
            {
                _filterString_GLCode = value;
                RaisePropertyChanged("FilterString_GLCode");
                FilterCollection_GLCode();
            }
        }
        private void FilterCollection_GLCode()
        {
            if (_glCodeCollection != null)
            {
                _glCodeCollection.Refresh();
            }
        }
        public bool Filter_GLCode(object obj)
        {
            var data = obj as ACC_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_GLCode))
                {
                    return (data.acc_code != null && data.acc_code.ToString().ToLower().Contains(_filterString_GLCode.ToLower()) ||
                         data.p_name != null && data.p_name.ToString().ToLower().Contains(_filterString_GLCode.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_PayTerms;
        public string FilterString_PayTerms
        {
            get { return _filterString_PayTerms; }
            set
            {
                _filterString_PayTerms = value;
                RaisePropertyChanged("FilterString_PayTerms");
                FilterCollection_PayTerms();
            }
        }
        private void FilterCollection_PayTerms()
        {
            if (_paytermCollection != null)
            {
                _paytermCollection.Refresh();
            }
        }
        public bool Filter_PayTerms(object obj)
        {
            var data = obj as ACC_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_PayTerms))
                {
                    return (data.p_term != null && data.p_term.ToString().ToLower().Contains(_filterString_PayTerms.ToLower()) ||
                        data.p_term_code != null && data.p_term_code.ToString().ToLower().Contains(_filterString_PayTerms.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_Currency;
        public string FilterString_Currency
        {
            get { return _filterString_Currency; }
            set
            {
                _filterString_Currency = value;
                RaisePropertyChanged("FilterString_Currency");
                FilterCollection_Currency();
            }
        }
        private void FilterCollection_Currency()
        {
            if (_currencyCollection != null)
            {
                _currencyCollection.Refresh();
            }
        }
        public bool Filter_Currency(object obj)
        {
            var data = obj as ADM_M037_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Currency))
                {
                    return (data.curr_code != null && data.curr_code.ToString().ToLower().Contains(_filterString_Currency.ToLower())) ||
                       (data.curr_name != null && data.curr_name.ToString().ToLower().Contains(_filterString_Currency.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_SalesOrg;
        public string FilterString_SalesOrg
        {
            get { return _filterString_SalesOrg; }
            set
            {
                _filterString_SalesOrg = value;
                RaisePropertyChanged("FilterString_SalesOrg");
                FilterCollection_SalesOrg();
            }
        }
        private void FilterCollection_SalesOrg()
        {
            if (_sales_orgCollection != null)
            {
                _sales_orgCollection.Refresh();
            }
        }
        public bool Filter_SalesOrg(object obj)
        {
            var data = obj as ADM_M001_A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SalesOrg))
                {
                    return (data.so_code != null && data.so_code.ToString().ToLower().Contains(_filterString_SalesOrg.ToLower())) ||
                       (data.sales_org != null && data.sales_org.ToString().ToLower().Contains(_filterString_SalesOrg.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_SalesGroup;
        public string FilterString_SalesGroup
        {
            get { return _filterString_SalesGroup; }
            set
            {
                _filterString_SalesGroup = value;
                RaisePropertyChanged("FilterString_SalesGroup");
                FilterCollection_SalesGroup();
            }
        }
        private void FilterCollection_SalesGroup()
        {
            if (_salse_GroupCollection != null)
            {
                _salse_GroupCollection.Refresh();
            }
        }
        public bool Filter_SalesGroup(object obj)
        {
            var data = obj as ADM_M001_H_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SalesGroup))
                {
                    return (data.sg_code != null && data.sg_code.ToString().ToLower().Contains(_filterString_SalesGroup.ToLower())) ||
                       (data.sg_name != null && data.sg_name.ToString().ToLower().Contains(_filterString_SalesGroup.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_SalesDivision;
        public string FilterString_SalesDivision
        {
            get { return _filterString_SalesDivision; }
            set
            {
                _filterString_SalesDivision = value;
                RaisePropertyChanged("FilterString_SalesDivision");
                FilterCollection_SalesDivision();
            }
        }
        private void FilterCollection_SalesDivision()
        {
            if (_salse_GroupCollection != null)
            {
                _salse_GroupCollection.Refresh();
            }
        }
        public bool Filter_SalesDivision(object obj)
        {
            var data = obj as ADM_M001_A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SalesDivision))
                {
                    return (data.so_code != null && data.so_code.ToString().ToLower().Contains(_filterString_SalesDivision.ToLower())) ||
                       (data.sales_org != null && data.sales_org.ToString().ToLower().Contains(_filterString_SalesDivision.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_ItemCategory;
        public string FilterString_ItemCategory
        {
            get { return _filterString_ItemCategory; }
            set
            {
                _filterString_ItemCategory = value;
                RaisePropertyChanged("FilterString_ItemCategory");
                FilterCollection_ItemCategory();
            }
        }
        private void FilterCollection_ItemCategory()
        {
            if (_itemcategoryCollection != null)
            {
                _itemcategoryCollection.Refresh();
            }
        }
        public bool Filter_ItemCategory(object obj)
        {
            var data = obj as SYS_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ItemCategory))
                {
                    return (data.sditem_cat_code != null && data.sditem_cat_code.ToString().ToLower().Contains(_filterString_ItemCategory.ToLower()) ||
                        data.item_cat_desc != null && data.item_cat_desc.ToString().ToLower().Contains(_filterString_ItemCategory.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_Cost_Center;
        public string FilterString_Cost_Center
        {
            get { return _filterString_Cost_Center; }
            set
            {
                _filterString_Cost_Center = value;
                RaisePropertyChanged("FilterString_Cost_Center");
                FilterCollection_Cost_Center();
            }
        }
        private void FilterCollection_Cost_Center()
        {
            if (_cost_centerCollection != null)
            {
                _cost_centerCollection.Refresh();
            }
        }
        public bool Filter_Cost_Center(object obj)
        {
            var data = obj as ACC_M019_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Cost_Center))
                {
                    return (data.cost_center != null && data.cost_center.ToString().ToLower().Contains(_filterString_Cost_Center.ToLower())) ||
                        (data.cost_center_Desc != null && data.cost_center_Desc.ToString().ToLower().Contains(_filterString_Cost_Center.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_Banks;
        public string FilterString_Banks
        {
            get { return _filterString_Banks; }
            set
            {
                _filterString_Banks = value;
                RaisePropertyChanged("FilterString_Banks");
                FilterCollection_Banks();
            }
        }
        private void FilterCollection_Banks()
        {
            if (_bankCollection != null)
            {
                _bankCollection.Refresh();
            }
        }
        public bool Filter_Banks(object obj)
        {
            var data = obj as ACC_M004_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Banks))
                {
                    return (data.bank_code != null && data.bank_code.ToString().ToLower().Contains(_filterString_Banks.ToLower()) ||
                         data.bank_name != null && data.bank_name.ToString().ToLower().Contains(_filterString_Banks.ToLower())
                        );
                }
                return true;
            }
            return false;
        }

        private string _filterString_BallType;
        public string FilterString_BallType
        {
            get { return _filterString_BallType; }
            set
            {
                _filterString_BallType = value;
                RaisePropertyChanged("FilterString_BallType");
                FilterCollection_BallType();
            }
        }
        private void FilterCollection_BallType()
        {
            if (_ballTypeCollection != null)
            {
                _ballTypeCollection.Refresh();
            }
        }
        public bool Filter_BallType(object obj)
        {
            var data = obj as ZADM_M002_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BallType))
                {
                    return (data.ball_type != null && data.ball_type.ToString().ToLower().Contains(_filterString_BallType.ToLower())) ||
                        (data.ball_type_id != null && data.ball_type_id.ToString().ToLower().Contains(_filterString_BallType.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_ILD;
        public string FilterString_ILD
        {
            get { return _filterString_ILD; }
            set
            {
                _filterString_ILD = value;
                RaisePropertyChanged("FilterString_ILD");
                FilterCollection_ILD();
            }
        }
        private void FilterCollection_ILD()
        {
            if (_ildCollection != null)
            {
                _ildCollection.Refresh();
            }
        }
        public bool Filter_ILD(object obj)
        {
            var data = obj as ZADM_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ILD))
                {
                    return (data.ild != null && data.ild.ToString().ToLower().Contains(_filterString_ILD.ToLower())) ||
                        (data.ild_id != null && data.ild_id.ToString().ToLower().Contains(_filterString_ILD.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_WireType;
        public string FilterString_WireType
        {
            get { return _filterString_WireType; }
            set
            {
                _filterString_WireType = value;
                RaisePropertyChanged("FilterString_WireType");
                FilterCollection_WireType();
            }
        }
        private void FilterCollection_WireType()
        {
            if (_wireTypeCollection != null)
            {
                _wireTypeCollection.Refresh();
            }
        }
        public bool Filter_WireType(object obj)
        {
            var data = obj as ZADM_M004_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_WireType))
                {
                    return (data.wire_type != null && data.wire_type.ToString().ToLower().Contains(_filterString_WireType.ToLower())) ||
                        (data.wire_type_id != null && data.wire_type_id.ToString().ToLower().Contains(_filterString_WireType.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_BallDia;
        public string FilterString_BallDia
        {
            get { return _filterString_BallDia; }
            set
            {
                _filterString_BallDia = value;
                RaisePropertyChanged("FilterString_BallDia");
                FilterCollection_BallDia();
            }
        }
        private void FilterCollection_BallDia()
        {
            if (_ballDiaCollection != null)
            {
                _ballDiaCollection.Refresh();
            }
        }
        public bool Filter_BallDia(object obj)
        {
            var data = obj as ZADM_M001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BallDia))
                {
                    return (data.Ball_dia != null && data.Ball_dia.ToString().ToLower().Contains(_filterString_BallDia.ToLower())) ||
                        (data.ball_dia_id != null && data.ball_dia_id.ToString().ToLower().Contains(_filterString_BallDia.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_Ink;
        public string FilterString_Ink
        {
            get { return _filterString_Ink; }
            set
            {
                _filterString_Ink = value;
                RaisePropertyChanged("FilterString_Ink");
                FilterCollection_Ink();
            }
        }
        private void FilterCollection_Ink()
        {
            if (_inkCollection != null)
            {
                _inkCollection.Refresh();
            }
        }
        public bool Filter_Ink(object obj)
        {
            var data = obj as ZADM_M006_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Ink))
                {
                    return (data.ink != null && data.ink.ToString().ToLower().Contains(_filterString_Ink.ToLower())) ||
                        (data.ink_id != null && data.ink_id.ToString().ToLower().Contains(_filterString_Ink.ToLower()));
                }
                return true;
            }
            return false;
        }




        private string _FilterString_Grade;
        public string FilterString_Grade
        {
            get { return _FilterString_Grade; }
            set
            {
                _FilterString_Grade = value;
                RaisePropertyChanged("FilterString_Grade");
                FilterCollection_Grade();
            }
        }
        private void FilterCollection_Grade()
        {
            if (_GradeCollection != null)
            {
                _GradeCollection.Refresh();
            }
        }
        public bool Filter_Grade(object obj)
        {
            var data = obj as ADM_M045_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_Grade))
                {
                    return (data.grade_code != null && data.grade_code.ToString().ToLower().Contains(_FilterString_Grade.ToLower()));

                }
                return true;
            }
            return false;
        }


        private string _filterString_Incoterms;
        public string FilterString_Incoterms
        {
            get { return _filterString_Incoterms; }
            set
            {
                _filterString_Incoterms = value;
                RaisePropertyChanged("FilterString_Incoterms");
                FilterCollection_Incoterms();
            }
        }
        private void FilterCollection_Incoterms()
        {
            if (_incotermsCollection != null)
            {
                _incotermsCollection.Refresh();
            }
        }
        public bool Filter_Incoterms(object obj)
        {
            var data = obj as ADM_M044_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Incoterms))
                {
                    return (data.incoterms != null && data.incoterms.ToString().ToLower().Contains(_filterString_Incoterms.ToLower())) ||
                        (data.inco_desc != null && data.inco_desc.ToString().ToLower().Contains(_filterString_Incoterms.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_ADVANCELicense;
        public string FilterString_ADVANCELicense
        {
            get { return _filterString_ADVANCELicense; }
            set
            {
                _filterString_ADVANCELicense = value;
                RaisePropertyChanged("FilterString_ADVANCELicense");
                FilterCollection_ADVANCELicense();
            }
        }
        private void FilterCollection_ADVANCELicense()
        {
            if (_licenseAdvanceCollection != null)
            {
                _licenseAdvanceCollection.Refresh();
            }
        }
        public bool Filter_ADVANCELicense(object obj)
        {
            var data = obj as ADM_M041_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ADVANCELicense))
                {
                    return (data.lic_cod != null && data.lic_cod.ToString().ToLower().Contains(_filterString_ADVANCELicense.ToLower())) ||
                        (data.lic_type != null && data.lic_type.ToString().ToLower().Contains(_filterString_ADVANCELicense.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_EPCGLicense;
        public string FilterString_EPCGLicense
        {
            get { return _filterString_ADVANCELicense; }
            set
            {
                _filterString_ADVANCELicense = value;
                RaisePropertyChanged("FilterString_EPCGLicense");
                FilterCollection_EPCGLicense();
            }
        }
        private void FilterCollection_EPCGLicense()
        {
            if (_licenseEPCGCollection != null)
            {
                _licenseEPCGCollection.Refresh();
            }
        }
        public bool Filter_EPCGLicense(object obj)
        {
            var data = obj as ADM_M041_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_EPCGLicense))
                {
                    return (data.lic_cod != null && data.lic_cod.ToString().ToLower().Contains(_filterString_EPCGLicense.ToLower())) ||
                        (data.lic_type != null && data.lic_type.ToString().ToLower().Contains(_filterString_EPCGLicense.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _FilterString_RefDocNo;
        public string FilterString_RefDocNo
        {
            get { return _FilterString_RefDocNo; }
            set
            {
                _FilterString_RefDocNo = value;
                RaisePropertyChanged("FilterString_RefDocNo");
                FilterCollection_ReferenceDoc();
            }
        }
        private void FilterCollection_ReferenceDoc()
        {
            if (_ReferenceDocCollection != null)
            {
                _ReferenceDocCollection.Refresh();
            }
        }
        public bool Filter_ReferenceDoc(object obj)
        {
            var data = obj as SEL_T001_P_RefDoc;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_RefDocNo))
                {
                    return (data.sono != null && data.sono.ToString().ToLower().Contains(_FilterString_RefDocNo.ToLower()) ||
                        data.cust_ref != null && data.cust_ref.ToString().ToLower().Contains(_FilterString_RefDocNo.ToLower()) ||
                         data.party_name != null && data.party_name.ToString().ToLower().Contains(_FilterString_RefDocNo.ToLower()) ||
                          data.sodate != null && data.sodate.ToString().ToLower().Contains(_FilterString_RefDocNo.ToLower())
                       );
                }
                return true;
            }
            return false;
        }

        private string _filterString_Buyer;
        public string FilterString_Buyer
        {
            get { return _filterString_Buyer; }
            set
            {
                _filterString_Buyer = value;
                RaisePropertyChanged("FilterString_Buyer");
                FilterCollection_Buyer();
            }
        }
        private void FilterCollection_Buyer()
        {
            if (_buyerCollection != null)
            {
                _buyerCollection.Refresh();
            }
        }
        public bool Filter_Buyer(object obj)
        {
            var data = obj as ADM_M028_C_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Buyer))
                {
                    return (data.PersonName != null && data.PersonName.ToString().ToLower().Contains(_filterString_Buyer.ToLower()) ||
                         data.Location != null && data.Location.ToString().ToLower().Contains(_filterString_Buyer.ToLower())
                        );
                }
                return true;
            }
            return false;
        }

        private string _filterString_BillingAddress;
        public string FilterString_BillingAddress
        {
            get { return _filterString_BillingAddress; }
            set
            {
                _filterString_BillingAddress = value;
                RaisePropertyChanged("FilterString_BillingAddress");
                FilterCollection_BillingAddress();
            }
        }
        private void FilterCollection_BillingAddress()
        {
            if (_billingAddressCollection != null)
            {
                _billingAddressCollection.Refresh();
            }

        }
        public bool Filter_BillingAddress(object obj)
        {
            var data = obj as ADM_M028_D;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BillingAddress))
                {
                    return (data.Location != null && data.Location.ToString().ToLower().Contains(_filterString_BillingAddress.ToLower()) ||
                         data.Add1 != null && data.Add1.ToString().ToLower().Contains(_filterString_BillingAddress.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_DeliveryAddress;
        public string FilterString_DeliveryAddress
        {
            get { return _filterString_DeliveryAddress; }
            set
            {
                _filterString_DeliveryAddress = value;
                RaisePropertyChanged("FilterString_DeliveryAddress");
                FilterCollection_DeliveryAddress();
            }
        }
        private void FilterCollection_DeliveryAddress()
        {
            if (_deliveryAddressCollection != null)
            {
                _deliveryAddressCollection.Refresh();
            }

        }
        public bool Filter_DeliveryAddress(object obj)
        {
            var data = obj as ADM_M028_D;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_DeliveryAddress))
                {
                    return (data.Location != null && data.Location.ToString().ToLower().Contains(_filterString_DeliveryAddress.ToLower()) ||
                        data.Add1 != null && data.Add1.ToString().ToLower().Contains(_filterString_DeliveryAddress.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_Location;
        public string FilterString_Location
        {
            get { return _filterString_Location; }
            set
            {
                _filterString_Location = value;
                RaisePropertyChanged("FilterString_Location");
                FilterCollection_Location();
            }
        }
        private void FilterCollection_Location()
        {
            if (_LocationCollection != null)
            {
                _LocationCollection.Refresh();
            }

        }
        public bool Filter_Location(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Location))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_Location.ToLower()) ||
                        data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_Location.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _FilterString_dgLocation;
        public string FilterString_dgLocation
        {
            get { return _FilterString_dgLocation; }
            set
            {
                _FilterString_dgLocation = value;
                RaisePropertyChanged("FilterString_dgLocation");
                FilterCollection_dgLocation();
            }
        }
        private void FilterCollection_dgLocation()
        {
            if (_LocationCollection != null)
            {
                _LocationCollection.Refresh();
            }

        }
        public bool Filter_dgLocation(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_dgLocation))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_FilterString_dgLocation.ToLower()) ||
                        data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_FilterString_dgLocation.ToLower()));
                }
                return true;
            }
            return false;
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
            var data = obj as SEL_T001_P_SO_ItemsList;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ItemsListPopup))
                {
                    return (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower()) ||
                           (data.CstmrItmCod != null && data.CstmrItmCod.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            (data.CstmrItmDesc != null && data.CstmrItmDesc.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower()));
                }
                return true;
            }
            return false;
        }
        //--filter terms and condition

        private string _FilterString_Terms;
        public string FilterString_Terms
        {
            get { return _FilterString_Terms; }
            set
            {
                _FilterString_Terms = value;
                RaisePropertyChanged("FilterString_Terms");
                FilterCollection_Terms();
            }
        }
        private void FilterCollection_Terms()
        {
            if (_TermsConditionCollection != null)
            {
                _TermsConditionCollection.Refresh();
            }
        }
        public bool Filter_Terms(object obj)
        {
            var data = obj as CRM_M001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_Terms))
                {
                    return (data.con_type != null && data.con_type.ToString().ToLower().Contains(_FilterString_Terms.ToLower())) ||
                           (data.long_text != null && data.long_text.ToString().ToLower().Contains(_FilterString_Terms.ToLower()));

                }
                return true;
            }
            return false;
        }


        private string _filterString_Plant;
        public string FilterString_Plant
        {
            get { return _filterString_Plant; }
            set
            {
                _filterString_Plant = value;
                RaisePropertyChanged("FilterString_Plant");
                FilterCollection_Palnt();
            }
        }
        private void FilterCollection_Palnt()
        {
            if (_PlantCollection != null)
            {
                _PlantCollection.Refresh();
            }

        }
        public bool Filter_Plant(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Plant))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_Plant.ToLower()) ||
                        data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_Plant.ToLower()));
                }
                return true;
            }
            return false;
        }


        //pending delete if not use
        private void FilterReferenceDocumentNumbers(object InputValue)
        {


        }

        
        #endregion


    }
}
