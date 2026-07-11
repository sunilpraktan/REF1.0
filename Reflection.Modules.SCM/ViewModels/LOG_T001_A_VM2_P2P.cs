using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Reflection.ReportingServices;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Common;

namespace Reflection.Modules.SCM.ViewModels
{
    class LOG_T001_A_VM2_P2P : WorkspaceViewModel<LOG_T001_A>
    {
        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = SelectedLOG_T001_A.HasErrors;
        }

        #region . Declaration .
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        bool blNew = true; bool firstrow = true;

        private bool _batchdatagrid;
        public bool batchdatagrid
        {
            get { return _batchdatagrid; }
            set
            {
                if (_batchdatagrid != value)
                {
                    _batchdatagrid = value;
                    RaisePropertyChanged("batchdatagrid");
                }
            }
        }

        private bool _split;
        public bool split
        {
            get { return _split; }
            set
            {
                if (_split != value)
                {
                    _split = value;
                    RaisePropertyChanged("split");
                }
            }
        }

        private bool _post;
        public bool post
        {
            get { return _post; }
            set
            {
                if (_post != value)
                {
                    _post = value;
                    RaisePropertyChanged("post");
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
        WebServiceRepository<LOG_T001_A> repository = new WebServiceRepository<LOG_T001_A>();
        WebServiceRepository<MM_T001> repositoryMI = new WebServiceRepository<MM_T001>();
        WebServiceRepository<MultipleContext_LOG_T001_A> repositoryM = new WebServiceRepository<MultipleContext_LOG_T001_A>();

        private MultipleContext_LOG_T001_A _MC;
        public MultipleContext_LOG_T001_A MC
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
        MultipleContext_LOG_T001_A MCTemp = new MultipleContext_LOG_T001_A();
        private List<ADM_M022_P> _ItemsList;
        public List<ADM_M022_P> ItemsList
        {
            get { return _ItemsList; }
            set
            {
                //if (_ItemsList != value)
                //{
                _ItemsList = value;

                RaisePropertyChanged("ItemsList");
                //}
            }
        }
        private List<MM_M001> _StoreLocList = new List<MM_M001>();
        public List<MM_M001> StoreLocList
        {
            get { return _StoreLocList; }
            set
            {
                if (_StoreLocList != value)
                {
                    _StoreLocList = value;
                }
            }
        }
        private List<MM_S003_P> _BatchList = new List<MM_S003_P>();
        public List<MM_S003_P> BatchList
        {
            get { return _BatchList; }
            set
            {
                if (_BatchList != value)
                {
                    _BatchList = value;

                    RaisePropertyChanged("BatchList");
                }
            }
        }
        public List<ADM_M003> _PlantList = new List<ADM_M003>();
        private List<ADM_M003> PlantList
        {
            get { return _PlantList; }
            set
            {
                if (_PlantList != value)
                {
                    _PlantList = value;
                }
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
        private List<ADM_M031_P> _ParameterTemp = new List<ADM_M031_P>();
        public List<ADM_M031_P> ParameterTemp
        {
            get { return _ParameterTemp; }
            set
            {
                if (_ParameterTemp != value)
                {
                    _ParameterTemp = value;
                }
            }
        }
        private bool _parameter;
        public bool parameter
        {
            get { return _parameter; }
            set
            {
                if (_parameter != value)
                {
                    _parameter = value;
                    RaisePropertyChanged("parameter");
                }
            }
        }
        string store_location;

        private string _MasterMake;
        public string MasterMake
        {
            get { return _MasterMake; }
            set { _MasterMake = value; RaisePropertyChanged("MasterMake"); }
        }

        private string _MasterMatCon;
        public string MasterMatCon
        {
            get { return _MasterMatCon; }
            set { _MasterMatCon = value; RaisePropertyChanged("MasterMatCon"); }
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

        private Nullable<System.DateTime> _FromDate;
        public Nullable<System.DateTime> FromDate
        {
            get { return _FromDate; }
            set
            {
                _FromDate = value;
                RaisePropertyChanged("FromDate");
            }
        }
        private Nullable<System.DateTime> _ToDate;
        public Nullable<System.DateTime> ToDate
        {
            get { return _ToDate; }
            set
            {
                _ToDate = value;
                RaisePropertyChanged("ToDate");
            }
        }
        private string _DelType;
        public string DelType
        {
            get { return _DelType; }
            set
            {
                if (_DelType != value)
                {
                    _DelType = value;
                    RaisePropertyChanged("DelType");
                }
            }
        }

        private string _Plant;
        public string Plant
        {
            get { return _Plant; }
            set
            {
                if (_Plant != value)
                {
                    _Plant = value;
                    RaisePropertyChanged("Plant");
                }
            }
        }
        #endregion

        #region StringList for AutoComplete

        List<string> _StringListDelType;
        public List<string> StringListDelType
        {
            get { return _StringListDelType; }
            set
            {
                if (_StringListDelType != value)
                {
                    _StringListDelType = value;
                }
            }
        }
        List<string> _StringListDelType2;
        public List<string> StringListDelType2
        {
            get { return _StringListDelType2; }
            set
            {
                if (_StringListDelType2 != value)
                {
                    _StringListDelType2 = value;
                }
            }
        }

        List<string> _StringListSoldParty;
        public List<string> StringListSoldParty
        {
            get { return _StringListSoldParty; }
            set
            {
                if (_StringListSoldParty != value)
                {
                    _StringListSoldParty = value;
                }
            }
        }

        List<string> _StringListShipParty;
        public List<string> StringListShipParty
        {
            get { return _StringListShipParty; }
            set
            {
                if (_StringListShipParty != value)
                {
                    _StringListShipParty = value;
                }
            }
        }

        List<string> _StringListDocType;
        public List<string> StringListDocType
        {
            get { return _StringListDocType; }
            set
            {
                if (_StringListDocType != value)
                {
                    _StringListDocType = value;
                }
            }
        }

        List<string> _StringListOrderNo;
        public List<string> StringListOrderNo
        {
            get { return _StringListOrderNo; }
            set
            {
                if (_StringListOrderNo != value)
                {
                    _StringListOrderNo = value;
                }
            }
        }

        List<string> _StringListCurrency;
        public List<string> StringListCurrency
        {
            get { return _StringListCurrency; }
            set
            {
                if (_StringListCurrency != value)
                {
                    _StringListCurrency = value;
                }
            }
        }

        List<string> _StringListSalesOrg;
        public List<string> StringListSalesOrg
        {
            get { return _StringListSalesOrg; }
            set
            {
                if (_StringListSalesOrg != value)
                {
                    _StringListSalesOrg = value;
                }
            }
        }

        List<string> _StringListItems;
        public List<string> StringListItems
        {
            get { return _StringListItems; }
            set
            {
                if (_StringListItems != value)
                {
                    _StringListItems = value;
                }
            }
        }

        List<string> _StringListDC;
        public List<string> StringListDC
        {
            get { return _StringListDC; }
            set
            {
                if (_StringListDC != value)
                {
                    _StringListDC = value;
                }
            }
        }

        List<string> _StringListDivCode;
        public List<string> StringListDivCode
        {
            get { return _StringListDivCode; }
            set
            {
                if (_StringListDivCode != value)
                {
                    _StringListDivCode = value;
                }
            }
        }

        List<string> _StringListSalesOffice;
        public List<string> StringListSalesOffice
        {
            get { return _StringListSalesOffice; }
            set
            {
                if (_StringListSalesOffice != value)
                {
                    _StringListSalesOffice = value;
                }
            }
        }

        List<string> _StringListSalesGroup;
        public List<string> StringListSalesGroup
        {
            get { return _StringListSalesGroup; }
            set
            {
                if (_StringListSalesGroup != value)
                {
                    _StringListSalesGroup = value;
                }
            }
        }

        List<string> _StringListItemCat;
        public List<string> StringListItemCat
        {
            get { return _StringListItemCat; }
            set
            {
                if (_StringListItemCat != value)
                {
                    _StringListItemCat = value;
                }
            }
        }

        List<string> _StringListUom;
        public List<string> StringListUom
        {
            get { return _StringListUom; }
            set
            {
                if (_StringListUom != value)
                {
                    _StringListUom = value;
                }
            }
        }

        List<string> _StringListWtUom;
        public List<string> StringListWtUom
        {
            get { return _StringListWtUom; }
            set
            {
                if (_StringListWtUom != value)
                {
                    _StringListWtUom = value;
                }
            }
        }

        List<string> _StringListVolUom;
        public List<string> StringListVolUom
        {
            get { return _StringListVolUom; }
            set
            {
                if (_StringListVolUom != value)
                {
                    _StringListVolUom = value;
                }
            }
        }

        List<string> _StringListStoreLocB;
        public List<string> StringListStoreLocB
        {
            get { return _StringListStoreLocB; }
            set
            {
                if (_StringListStoreLocB != value)
                {
                    _StringListStoreLocB = value;
                }
            }
        }

        List<string> _StringListCountry;
        public List<string> StringListCountry
        {
            get { return _StringListCountry; }
            set
            {
                if (_StringListCountry != value)
                {
                    _StringListCountry = value;
                }
            }
        }

        List<string> _StringListDestCountry;
        public List<string> StringListDestCountry
        {
            get { return _StringListDestCountry; }
            set
            {
                if (_StringListDestCountry != value)
                {
                    _StringListDestCountry = value;
                }
            }
        }

        List<string> _StringListEPCG;
        public List<string> StringListEPCG
        {
            get { return _StringListEPCG; }
            set
            {
                if (_StringListEPCG != value)
                {
                    _StringListEPCG = value;
                }
            }
        }

        List<string> _StringListAdvLic;
        public List<string> StringListAdvLic
        {
            get { return _StringListAdvLic; }
            set
            {
                if (_StringListAdvLic != value)
                {
                    _StringListAdvLic = value;
                }
            }
        }

        List<string> _StringListTransporter;
        public List<string> StringListTransporter
        {
            get { return _StringListTransporter; }
            set
            {
                if (_StringListTransporter != value)
                {
                    _StringListTransporter = value;
                }
            }
        }

        List<string> _StringListCFAgent;
        public List<string> StringListCFAgent
        {
            get { return _StringListCFAgent; }
            set
            {
                if (_StringListCFAgent != value)
                {
                    _StringListCFAgent = value;
                }
            }
        }

        List<string> _StringListBatch;
        public List<string> StringListBatch
        {
            get { return _StringListBatch; }
            set
            {
                if (_StringListBatch != value)
                {
                    _StringListBatch = value;
                }
            }
        }

        List<string> _StringListSendingPlant;
        public List<string> StringListSendingPlant
        {
            get { return _StringListSendingPlant; }
            set
            {
                if (_StringListSendingPlant != value)
                {
                    _StringListSendingPlant = value;
                }
            }
        }

        List<string> _StringListReceivingPlant;
        public List<string> StringListReceivingPlant
        {
            get { return _StringListReceivingPlant; }
            set
            {
                if (_StringListReceivingPlant != value)
                {
                    _StringListReceivingPlant = value;
                }
            }
        }

        List<string> _strListMake;
        public List<string> StringListMake
        {
            get { return _strListMake; }
            set
            {
                if (_strListMake != value)
                {
                    _strListMake = value;
                    RaisePropertyChanged("StringListMake");
                }
            }
        }
        #endregion

        #region LOG_T001_A

        private List<LOG_T001_A> _SelectedList;
        public List<LOG_T001_A> SelectedList
        {
            get { return _SelectedList; }
            set
            {
                if (_SelectedList != value)
                {
                    _SelectedList = value;
                    RaisePropertyChanged("SelectedList");
                }
            }
        }

        private LOG_T001_A _SelectedLOG_T001_A;
        public LOG_T001_A SelectedLOG_T001_A
        {
            get
            {
                this.ErrorExist = _SelectedLOG_T001_A.HasErrors;
                return _SelectedLOG_T001_A;
            }
            set
            {
                if (_SelectedLOG_T001_A != value)
                {
                    _SelectedLOG_T001_A = value;
                    //        this.ErrorExist = _SelectedLOG_T001_A.HasErrors;
                    RaisePropertyChanged("SelectedLOG_T001_A");
                    value.BeginEdit();
                }
            }
        }

        #endregion

        #region LOG_T001_B

        private ObservableCollection<LOG_T001_B> _Del_Note_Dtails;
        public ObservableCollection<LOG_T001_B> Del_Note_Dtails
        {
            get { return _Del_Note_Dtails; }
            set
            {
                if (_Del_Note_Dtails != value)
                {
                    _Del_Note_Dtails = value;
                    RaisePropertyChanged("Del_Note_Dtails");
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

        private int _dgSelectedIndex;
        public int dgSelectedIndex
        {
            get
            {
                return _dgSelectedIndex;
            }
            set
            {
                if (_dgSelectedIndex != value)
                {
                    _dgSelectedIndex = value;
                    RaisePropertyChanged("dgSelectedIndex");
                    FilterBatchDataGrid();
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
        #endregion

        #region LOG_T001_C

        private ObservableCollection<LOG_T001_C> _ItemBatch_list = new ObservableCollection<LOG_T001_C>();
        public ObservableCollection<LOG_T001_C> ItemBatch_list
        {
            get { return _ItemBatch_list; }
            set
            {
                if (_ItemBatch_list != value)
                {
                    _ItemBatch_list = value;

                    RaisePropertyChanged("ItemBatch_list");
                }
            }
        }

        private int _batchsplitSelectedIndex;
        public int batchsplitSelectedIndex
        {
            get
            {
                return _batchsplitSelectedIndex;
            }
            set
            {
                if (_batchsplitSelectedIndex != value)
                {
                    _batchsplitSelectedIndex = value;
                    RaisePropertyChanged("batchsplitSelectedIndex");
                }
            }
        }
        #endregion

        #region Matrial Issue Object
        // Used For Goods Posting
        private MM_T001 _ObjectMM_T001;
        public MM_T001 ObjectMM_T001
        {
            get
            {
                return _ObjectMM_T001;
            }
            set
            {
                if (_ObjectMM_T001 != value)
                {
                    _ObjectMM_T001 = value;
                    RaisePropertyChanged("ObjectMM_T001");
                }
            }
        }

        private List<MM_T001_A> _ObjectMM_T001_A;
        public List<MM_T001_A> ObjectMM_T001_A
        {
            get { return _ObjectMM_T001_A; }
            set
            {
                if (_ObjectMM_T001_A != value)
                {
                    _ObjectMM_T001_A = value;

                    RaisePropertyChanged("ObjectMM_T001_A");

                }
            }
        }

        private List<MM_T001_B> _ObjectMM_T001_B;
        public List<MM_T001_B> ObjectMM_T001_B
        {
            get { return _ObjectMM_T001_B; }
            set
            {
                if (_ObjectMM_T001_B != value)
                {
                    _ObjectMM_T001_B = value;

                    RaisePropertyChanged("ObjectMM_T001_B");
                }
            }
        }
        #endregion

        #region . ICollectionView .

        private ICollectionView _ship_toPartyCollection;
        public ICollectionView ship_toPartyCollection
        {
            get { return _ship_toPartyCollection; }
            set
            {
                _ship_toPartyCollection = value;

                RaisePropertyChanged("ship_toPartyCollection");
            }
        }

        private ICollectionView _DeliveryAddCollection;
        public ICollectionView DeliveryAddCollection
        {
            get { return _DeliveryAddCollection; }
            set
            {
                _DeliveryAddCollection = value;

                RaisePropertyChanged("DeliveryAddCollection");
            }
        }
        private ICollectionView _sold_toPartyCollection;
        public ICollectionView sold_toPartyCollection
        {
            get { return _sold_toPartyCollection; }
            set
            {
                _sold_toPartyCollection = value;

                RaisePropertyChanged("sold_toPartyCollection");
            }
        }
        private ICollectionView _BillAddressCollection;
        public ICollectionView BillAddressCollection
        {
            get { return _BillAddressCollection; }
            set
            {
                _BillAddressCollection = value;

                RaisePropertyChanged("BillAddressCollection");
            }
        }
        private ICollectionView _Del_TypeCollection;
        public ICollectionView Del_TypeCollection
        {
            get { return _Del_TypeCollection; }
            set
            {
                _Del_TypeCollection = value;

                RaisePropertyChanged("Del_TypeCollection");
            }
        }
        private ICollectionView _Del_TypeCollection2;
        public ICollectionView Del_TypeCollection2
        {
            get { return _Del_TypeCollection2; }
            set { _Del_TypeCollection2 = value; RaisePropertyChanged("Del_TypeCollection2"); }
        }
        private ICollectionView _DocTypeCollection;
        public ICollectionView DocTypeCollection
        {
            get { return _DocTypeCollection; }
            set
            {
                _DocTypeCollection = value;
                RaisePropertyChanged("DocTypeCollection");
            }
        }

        private ICollectionView _S_OrderCollection;
        public ICollectionView S_OrderCollection
        {
            get { return _S_OrderCollection; }
            set
            {
                _S_OrderCollection = value;

                RaisePropertyChanged("S_OrderCollection");
            }
        }

        private ICollectionView _curr_nameCollection;
        public ICollectionView curr_nameCollection
        {
            get { return _curr_nameCollection; }
            set
            {
                _curr_nameCollection = value;

                RaisePropertyChanged("curr_nameCollection");
            }
        }

        private ICollectionView _so_codeCollection;
        public ICollectionView so_codeCollection
        {
            get { return _so_codeCollection; }
            set
            {
                _so_codeCollection = value;

                RaisePropertyChanged("so_codeCollection");
            }
        }

        private ICollectionView _dc_codeCollection;
        public ICollectionView dc_codeCollection
        {
            get { return _dc_codeCollection; }
            set
            {
                _dc_codeCollection = value;

                RaisePropertyChanged("dc_codeCollection");
            }
        }

        private ICollectionView _div_codeCollection;
        public ICollectionView div_codeCollection
        {
            get { return _div_codeCollection; }
            set
            {
                _div_codeCollection = value;

                RaisePropertyChanged("div_codeCollection");
            }
        }

        private ICollectionView _soff_codeCollection;
        public ICollectionView soff_codeCollection
        {
            get { return _soff_codeCollection; }
            set
            {
                _soff_codeCollection = value;

                RaisePropertyChanged("soff_codeCollection");
            }
        }

        private ICollectionView _sg_codeCollection;
        public ICollectionView sg_codeCollection
        {
            get { return _sg_codeCollection; }
            set
            {
                _sg_codeCollection = value;

                RaisePropertyChanged("sg_codeCollection");
            }
        }

        private ICollectionView _Item_CatCollection;
        public ICollectionView Item_CatCollection
        {
            get { return _Item_CatCollection; }
            set
            {
                _Item_CatCollection = value;

                RaisePropertyChanged("Item_CatCollection");
            }
        }

        private ICollectionView _uomCollection;
        public ICollectionView uomCollection
        {
            get { return _uomCollection; }
            set
            {
                _uomCollection = value;

                RaisePropertyChanged("uomCollection");
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

        private ICollectionView _Store_LoctnBCollection;
        public ICollectionView Store_LoctnBCollection
        {
            get { return _Store_LoctnBCollection; }
            set
            {
                _Store_LoctnBCollection = value;

                RaisePropertyChanged("Store_LoctnBCollection");
            }
        }

        private ICollectionView _CountryCollection;
        public ICollectionView CountryCollection
        {
            get { return _CountryCollection; }
            set
            {
                _CountryCollection = value;

                RaisePropertyChanged("CountryCollection");
            }
        }

        private ICollectionView _dest_countryCollection;
        public ICollectionView dest_countryCollection
        {
            get { return _dest_countryCollection; }
            set
            {
                _dest_countryCollection = value;

                RaisePropertyChanged("dest_countryCollection");
            }
        }

        private ICollectionView _advanceLicCollection;
        public ICollectionView advanceLicCollection
        {
            get { return _advanceLicCollection; }
            set
            {
                _advanceLicCollection = value;
                RaisePropertyChanged("advanceLicCollection");
            }
        }

        private ICollectionView _epcgLicCollection;
        public ICollectionView epcgLicCollection
        {
            get { return _epcgLicCollection; }
            set
            {
                _epcgLicCollection = value;
                RaisePropertyChanged("epcgLicCollection");
            }
        }

        private ICollectionView _TransporterCollection;
        public ICollectionView TransporterCollection
        {
            get { return _TransporterCollection; }
            set
            {
                _TransporterCollection = value;

                RaisePropertyChanged("TransporterCollection");
            }
        }

        private ICollectionView _cf_agentCollection;
        public ICollectionView cf_agentCollection
        {
            get { return _cf_agentCollection; }
            set
            {
                _cf_agentCollection = value;

                RaisePropertyChanged("cf_agentCollection");
            }
        }

        private ICollectionView _ItemsCollection;
        public ICollectionView ItemsCollection
        {
            get { return _ItemsCollection; }
            set
            {
                _ItemsCollection = value;

                RaisePropertyChanged("ItemsCollection");
            }
        }

        private ICollectionView _ParameterCollection;
        public ICollectionView ParameterCollection
        {
            get { return _ParameterCollection; }
            set
            {
                _ParameterCollection = value;
                RaisePropertyChanged("ParameterCollection");
            }
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

        private ICollectionView _DelAddressCollection;
        public ICollectionView DelAddressCollection
        {
            get { return _DelAddressCollection; }
            set
            {
                _DelAddressCollection = value;
                RaisePropertyChanged("DelAddressCollection");
            }
        }

        private ICollectionView _FlipDeliveryNoteCollection;
        public ICollectionView FlipDeliveryNoteCollection
        {
            get { return _FlipDeliveryNoteCollection; }
            set
            {
                _FlipDeliveryNoteCollection = value;
                RaisePropertyChanged("FlipDeliveryNoteCollection");
            }
        }

        private ICollectionView _BatchCollection;
        public ICollectionView BatchCollection
        {
            get { return _BatchCollection; }
            set
            {
                _BatchCollection = value;
                RaisePropertyChanged("BatchCollection");
            }
        }

        private ICollectionView _DataGridView;
        public ICollectionView DataGridView
        {
            get { return _DataGridView; }
            set
            {
                _DataGridView = value;
                RaisePropertyChanged("DataGridView");
            }
        }
        private ICollectionView _SendingPlant;
        public ICollectionView SendingPlant
        {
            get { return _SendingPlant; }
            set
            {
                _SendingPlant = value;
                RaisePropertyChanged("SendingPlant");
            }
        }
        private ICollectionView _ReceivingPlant;
        public ICollectionView ReceivingPlant
        {
            get { return _ReceivingPlant; }
            set
            {
                _ReceivingPlant = value;
                RaisePropertyChanged("ReceivingPlant");
            }
        }

        private ICollectionView _MakeCollection;
        public ICollectionView MakeCollection
        {
            get { return _MakeCollection; }
            set { _MakeCollection = value; RaisePropertyChanged("MakeCollection"); }
        }

        private ICollectionView _TypeCollection;
        public ICollectionView TypeCollection
        {
            get { return _TypeCollection; }
            set { _TypeCollection = value; RaisePropertyChanged("TypeCollection"); }
        }

        private ICollectionView _MatConditionCollection;
        public ICollectionView MatConditionCollection
        {
            get { return _MatConditionCollection; }
            set { _MatConditionCollection = value; RaisePropertyChanged("MatConditionCollection"); }
        }
        #endregion

        #region . Relay Command .
        public RelayCommand<object> CommandSendingPlant { get; private set; }
        public RelayCommand<object> CommandRecPlant { get; private set; }
        public RelayCommand<object> SelectionChangedCommandDel_Type
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandsold_toParty
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandship_toParty
        {
            get;
            private set;
        }
        public RelayCommand<object> GetSelectedDocType
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandS_Order
        {
            get;
            private set;
        }

        public RelayCommand<object> SelectionChangedCommandTransporter
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommanddest_country
        {
            get;
            private set;
        }

        public RelayCommand<object> SelectionChangedCommandcf_agent
        {
            get;
            private set;
        }

        public RelayCommand<object> SelectionCommand_epcg
        {
            get;
            private set;
        }

        public RelayCommand<object> SelectionCommand_advance
        {
            get;
            private set;
        }

        public RelayCommand<object> SelectionChangedCommandCountry
        {
            get;
            private set;
        }

        public RelayCommand<object> SelectionChangedCommandso_code
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommanddc_code
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommanddiv_code
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandsoff_code
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandsg_code
        {
            get;
            private set;
        }

        public RelayCommand<object> SelectionChangedCommanduom
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandwtunit
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandVolUnit
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandStore_LoctnB
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandItem_Cat
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandLoadSODetails
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandcurr_name
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandItems
        {
            get;
            private set;
        }
        public RelayCommand<object> ActiveInActiveChangeCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> DataGridRowDeleteCommand
        {
            get;
            private set;
        }

        public RelayCommand<object> BatchDataGridRowDeleteCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> CollectionChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandInvicAdd
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandDelAdd
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedParaValCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> GetDeliveryNoteDetails
        {
            get;
            private set;
        }

        public RelayCommand<object> SelectionChangedCommandStoreLocationB
        {
            get;
            private set;
        }

        public RelayCommand<IList> BatchCollectionChangeCommand
        {
            get;
            private set;
        }

        public RelayCommand<object> SelectionChangedBatchCommand
        {
            get;
            private set;
        }

        public RelayCommand<object> SelectionChangedBatchDetailsCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> ItemBatchCollectionChangeCommand
        {
            get;
            private set;
        }
        public RelayCommand<string> SelectionChangedCommandBarcode
        {
            get;
            private set;
        }
        public RelayCommand PostBtnClickCommand
        {
            get;
            private set;
        }
        public RelayCommand ReportCommandPackingList
        {
            get;
            private set;
        }

        public RelayCommand BatchSplitClick
        {
            get;
            private set;
        }
        public RelayCommand WeightAndVolumeCalculationCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandDel_Type2
        {
            get;
            private set;
        }

        public RelayCommand<IList> cmdMake { get; private set; }
        public RelayCommand<object> cmdMasterMake { get; private set; }
        public RelayCommand<object> cmdOpenAttachments { get; private set; }
        public RelayCommand<object> cmdReloadViewDataGrid { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region . Constructor .
        public LOG_T001_A_VM2_P2P(string ts_code)
            : base()
        {
            parameter = false;
            this.ts_code_vm = ts_code;
            LOG_T001_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);


            ItemsList = new List<ADM_M022_P>(); // used in  ITEM DATAGRID
            SelectedList = new List<LOG_T001_A>();
            SelectedLOG_T001_A = new LOG_T001_A();
            MC = new MultipleContext_LOG_T001_A();
            MCTemp = new MultipleContext_LOG_T001_A();

            Del_Note_Dtails = new ObservableCollection<LOG_T001_B>();
            ItemBatch_list = new ObservableCollection<LOG_T001_C>();

            SelectedLOG_T001_A.location_Id = AppSessionState.location_Id;
            SelectedLOG_T001_A.PartyId = "NA";
            SelectedLOG_T001_A.ship_to_party = "NA";
            SelectedLOG_T001_A.delivery_date = DateTime.Now;
            SelectedLOG_T001_A.goods_issue_date = DateTime.Now;
            SelectedLOG_T001_A.delivery_type = "ST";
            SelectedLOG_T001_A.client = AppSessionState.client;
            SelectedLOG_T001_A.user_source1 = AppSessionState.UserSource1;
            SelectedLOG_T001_A.user_source2 = AppSessionState.UserSource2;

            SelectedLOG_T001_A.ValidateAsync().Wait();
            post = true;
            SelectedTabControlIndex = 0;

            

            LoadInitialData();
            //if (AppSessionState.TransValue != null && AppSessionState.TransactionCode == MC.DocCategoryList[0].TranCode)
            //{
            //    LoadSODetails(AppSessionState.TransValue);
            //    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
            //    AppSessionState.TransValue = null;
            //    AppSessionState.TransId = null;
            //    AppSessionState.TransParameter = null;
            //    AppSessionState.ViewOtherRecordAllowed = true;
            //}
        }
        public LOG_T001_A_VM2_P2P(string ts_code,string doc_no)
            : base()
        {
            parameter = false;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            LOG_T001_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);


            ItemsList = new List<ADM_M022_P>(); // used in  ITEM DATAGRID
            SelectedList = new List<LOG_T001_A>();
            SelectedLOG_T001_A = new LOG_T001_A();
            MC = new MultipleContext_LOG_T001_A();
            MCTemp = new MultipleContext_LOG_T001_A();

            Del_Note_Dtails = new ObservableCollection<LOG_T001_B>();
            ItemBatch_list = new ObservableCollection<LOG_T001_C>();

            SelectedLOG_T001_A.location_Id = AppSessionState.location_Id;
            SelectedLOG_T001_A.PartyId = "NA";
            SelectedLOG_T001_A.ship_to_party = "NA";
            SelectedLOG_T001_A.delivery_date = DateTime.Now;
            SelectedLOG_T001_A.goods_issue_date = DateTime.Now;
            SelectedLOG_T001_A.delivery_type = "ST";
            SelectedLOG_T001_A.client = AppSessionState.client;
            SelectedLOG_T001_A.user_source1 = AppSessionState.UserSource1;
            SelectedLOG_T001_A.user_source2 = AppSessionState.UserSource2;

            SelectedLOG_T001_A.ValidateAsync().Wait();
            post = true;
            SelectedTabControlIndex = 0;

            

            LoadInitialData();
            //if (AppSessionState.TransValue != null && AppSessionState.TransactionCode == MC.DocCategoryList[0].TranCode)
            //{
            //    LoadSODetails(AppSessionState.TransValue);
            //    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
            //    AppSessionState.TransValue = null;
            //    AppSessionState.TransId = null;
            //    AppSessionState.TransParameter = null;
            //    AppSessionState.ViewOtherRecordAllowed = true;
            //}
        }
        #endregion

        #region . User Defined Functions .
        private void OpenDocumentViewer(object InputValue)
        {
            WebServiceRepository<MultipleContext_Attachments> repository_MCAttachments = new WebServiceRepository<MultipleContext_Attachments>();
            List<COM_T003> Attachments = new List<COM_T003>();
            LOG_T001_B EntityObjectParameter = new LOG_T001_B();
            MultipleContext_Attachments MCAttachments = new MultipleContext_Attachments();
            try
            {
                if (InputValue != null)
                {
                    EntityObjectParameter = ((IEnumerable)InputValue).Cast<LOG_T001_B>().ToList()[0];
                }
                //string Request = "GetAllFiles" + "!@" + EntityObjectParameter.ItemCode;
                string Request = "GetAllFiles" + "!@" + AppSessionState.client + "!@" + (EntityObjectParameter.comp_code ?? AppSessionState.comp_code) + "!@" + (EntityObjectParameter.location_Id ?? AppSessionState.location_Id) + "!@!@!@" + EntityObjectParameter.delivery_no + "!@"+ EntityObjectParameter.id.ToString();
                //MCAttachments = repository_MCAttachments.GetData<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Reflection.BusinessLogic.ReflectionFileHandlingServices");
                MCAttachments = repository_MCAttachments.GetDataWithReturnDomainObject<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                if (!string.IsNullOrEmpty(EntityObjectParameter.ItemCode))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = SelectedLOG_T001_A.delivery_no.Replace("/", "--"), Row_ID = EntityObjectParameter.id.ToString(), DocumentList = MCAttachments.Attachments, client = AppSessionState.client, comp_code = SelectedLOG_T001_A.comp_code });
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
        private void LoadInitialData()
        {
            try
            {

                // string company = AppSessionState.comp_code.ToString() + "@" + AppSessionState.location_Id.ToString();
                SelectedLOG_T001_A.doc_type = "DN";
                SelectedLOG_T001_A.doc_cat = "DN";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id
                    + "!@" + SelectedLOG_T001_A.doc_type + "!@" + SelectedLOG_T001_A.doc_cat + "!@" + "TO" + "!@" + "ST" + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.client;

                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MC, "LOG_T001_A_Data", "DeliveryNote", "SCM", "LoadAll", 0, Request);

                #region COMMAND INITIALIZATION
                SelectionChangedCommandDel_Type = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedDel_TypeDetails(items);
                });

                SelectionChangedCommandsold_toParty = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedsold_toPartyDetails(items);
                });

                SelectionChangedCommandship_toParty = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedship_toPartyDetails(items);
                });

                GetSelectedDocType = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    getselecteddoctype(items);
                });

                SelectionChangedCommandS_Order = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedS_OrderDetails(items);
                });

                SelectionChangedCommandTransporter = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedTransporterDetails(items);
                });

                SelectionChangedCommanddest_country = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelecteddest_countryDetails(items);
                });

                SelectionChangedCommandcf_agent = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedcf_agentDetails(items);
                });

                SelectionCommand_epcg = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    getSelected_epcg(items);
                });

                SelectionCommand_advance = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    getSelected_advance(items);
                });

                SelectionChangedCommandCountry = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedCountryDetails(items);
                });

                SelectionChangedCommandso_code = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedso_codeDetails(items);
                });

                SelectionChangedCommanddc_code = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelecteddc_codeDetails(items);
                });

                SelectionChangedCommanddiv_code = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelecteddiv_codeDetails(items);
                });

                SelectionChangedCommandsoff_code = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedsoff_codeDetails(items);
                });

                SelectionChangedCommandsg_code = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedsg_codeDetails(items);
                });

                SelectionChangedCommanduom = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedUomDetails(items, false, true, true);
                });

                SelectionChangedCommandwtunit = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedwtUOMDetails(items, false, true, true);
                });

                SelectionChangedCommandVolUnit = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedvolUOMNmDetails(items, false, true, true);
                });

                SelectionChangedCommandStore_LoctnB = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedStore_LoctnBDetails(items);
                });

                SelectionChangedCommandItem_Cat = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedItem_CatDetails(items, false, true, true);
                });

                SelectionChangedCommandLoadSODetails = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    LoadSODetails(items);
                });
                SelectionChangedCommandcurr_name = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedcurr_nameDetails(items);
                });
                cmdMasterMake = new RelayCommand<object>(
                items => {
                    if (items == null) { return; }
                    InsertMasterMake(items);
                });
                // item Details
                SelectionChangedCommandItems = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedItemsDetails(items, true, true, true);
                });
                DataGridRowDeleteCommand = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    DeleteDataGridRow_Item(items);
                });
                BatchDataGridRowDeleteCommand = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    DeleteBatchDataGridRow_Item(items);
                });


                CollectionChangedCommand = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    CollectionChanged(items);

                });

                SelectionChangedCommandInvicAdd = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedInvicAddDetails(items);
                });

                SelectionChangedCommandDelAdd = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedDelAddDetails(items);
                });

                SelectionChangedParaValCommand = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedParaValue(items);
                });

                GetDeliveryNoteDetails = new RelayCommand<IList>(
                Items =>
                {
                    if (Items == null)
                    {
                        return;
                    }
                    GetSelectedDeliveryNote(Items);
                });

                SelectionChangedCommandStoreLocationB = new RelayCommand<object>(
                Items =>
                {
                    if (Items == null)
                    {
                        return;
                    }
                    GetSelectedStoreLocationB(Items, false, true, true);
                });

                //BATCH
                BatchCollectionChangeCommand = new RelayCommand<IList>(
                Items =>
                {
                    if (Items == null)
                    {
                        return;
                    }
                    GetBatchCollection(Items);
                });
                ItemBatchCollectionChangeCommand = new RelayCommand<IList>(
                Items =>
                {
                    if (Items == null)
                    {
                        return;
                    }
                    GetItemBatchCollection(Items);
                });

                SelectionChangedBatchCommand = new RelayCommand<object>(
                Items =>
                {
                    if (Items == null)
                    {
                        return;
                    }
                    GetSelectedBatch(Items, false, true, true);   // used for batch up on Item Details Tab
            });

                SelectionChangedBatchDetailsCommand = new RelayCommand<object>(
                Items =>
                {
                    if (Items == null)
                    {
                        return;
                    }
                    GetSelectedBatchForItem(Items, true, false, true);  // used for batch popup on batch details tab
            });

                // For Barcode Reading
                SelectionChangedCommandBarcode = new RelayCommand<string>(
                Items =>
                {
                    if (Items == null)
                    {
                        return;
                    }
                    GetBatchbyBarcode(Items);
                });

                // Post Button
                PostBtnClickCommand = new RelayCommand(
                () =>
                {
                    Post();
                });

                ReportCommandPackingList = new RelayCommand(
                () =>
                {
                    PackingListReport();
                });
                BatchSplitClick = new RelayCommand(
                () =>
                {
                    BatchSplit();
                });

                WeightAndVolumeCalculationCommand = new RelayCommand(
                () =>
                {
                    CalculateWeightAndVolume();
                });

                ActiveInActiveChangeCommand = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    ItemActiveInActiveMethod(items);
                });
                SelectionChangedCommandDel_Type2 = new RelayCommand<object>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }

                    GetSelectedDel_TypeDetails2(items);
                });

                CommandSendingPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertSendingPlant(items); });
                CommandRecPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertRecPlant(items); });

                cmdMake = new RelayCommand<IList>
               (cmdPara => { if (cmdPara == null) { return; } InsertMake(cmdPara, false, true, true); });
                cmdOpenAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenDocumentViewer(cmdPara); });

                cmdReloadViewDataGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } ReloadViewDataGrid(cmdPara); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion
                SelectedLOG_T001_A.t_status = "001";
                SelectedLOG_T001_A.t_display = (from o in MC.t_statusList where o.t_status == SelectedLOG_T001_A.t_status select o.t_display).FirstOrDefault();

                Del_TypeCollection = CollectionViewSource.GetDefaultView(MC.DeliveryTypeList);
                Del_TypeCollection.Filter = new Predicate<object>(Del_TypeFilter);
                StringListDelType = MC.DeliveryTypeList.Select(x => x.delivery_type).ToList();

                Del_TypeCollection2 = new CollectionViewSource { Source = MC.DeliveryTypeList }.View;
                Del_TypeCollection2.Filter = new Predicate<object>(Del_TypeFilter2);
                StringListDelType2 = MC.DeliveryTypeList.Select(x => x.delivery_type).ToList();

                sold_toPartyCollection = CollectionViewSource.GetDefaultView(MC.PartyList);
                sold_toPartyCollection.Filter = new Predicate<object>(SoldToPartyFilter);
                StringListSoldParty = MC.PartyList.Select(x => x.PartyId).ToList();

                ship_toPartyCollection = CollectionViewSource.GetDefaultView(MC.PartyList);
                ship_toPartyCollection.Filter = new Predicate<object>(PartyFilter);
                StringListShipParty = MC.PartyList.Select(x => x.PartyId).ToList();

                DocTypeCollection = CollectionViewSource.GetDefaultView(MC.DocTypeList);
                StringListDocType = MC.DocTypeList.Select(x => x.doc_type_user).ToList();

                S_OrderCollection = CollectionViewSource.GetDefaultView(MC.OrderList);
                S_OrderCollection.Filter = new Predicate<object>(S_OrderFilter);
                StringListOrderNo = MC.OrderList.Select(x => x.order_no).ToList();

                curr_nameCollection = CollectionViewSource.GetDefaultView(MC.CurrencyList);
                curr_nameCollection.Filter = new Predicate<object>(curr_nameFilter);
                StringListCurrency = MC.CurrencyList.Select(x => x.curr_code).ToList();

                SalesOrganisationList = (List<ADM_M001_A_P>)AppSessionState.ADM_M001_A_List;
                so_codeCollection = CollectionViewSource.GetDefaultView(SalesOrganisationList);
                so_codeCollection.Filter = new Predicate<object>(so_codeFilter);
                StringListSalesOrg = SalesOrganisationList.Select(x => x.so_code).ToList();
                if (SalesOrganisationList.Count != 0)
                {
                    if (SalesOrganisationList.Count == 1)
                    {
                        SelectedLOG_T001_A.so_code = SalesOrganisationList[0].so_code;
                        SelectedLOG_T001_A.sales_orgnm = SalesOrganisationList[0].sales_org;
                    }
                }
                else
                {
                    SelectedLOG_T001_A.so_code = "";
                }

                ItemsCollection = CollectionViewSource.GetDefaultView(MC.ItemList);
                ItemsCollection.Filter = new Predicate<object>(ItemsFilter);
                StringListItems = MC.ItemList.Select(x => x.ItemCode).ToList();

                List<ADM_M030_P> makelist = (from o in MC.ParamValueList where o.para_code == "1002" select o).ToList();
                MakeCollection = CollectionViewSource.GetDefaultView(makelist);
                MakeCollection.Filter = new Predicate<object>(FilterMake);
                StringListMake = makelist.Select(x => x.parametervalue).ToList();

                var Typelist = (from o in MC.ParamValueList where o.para_code == "1001" select o).ToList();
                TypeCollection = CollectionViewSource.GetDefaultView(Typelist.ToList());

                var matconlist = (from o in MC.ParamValueList where o.para_code == "1003" select o).ToList();
                MatConditionCollection = CollectionViewSource.GetDefaultView(matconlist.ToList());

                dc_codeCollection = CollectionViewSource.GetDefaultView(MC.DistributionChannelList);
                dc_codeCollection.Filter = new Predicate<object>(dc_codeFilter);
                StringListDC = MC.DistributionChannelList.Select(x => x.dc_code).ToList();

                div_codeCollection = CollectionViewSource.GetDefaultView(MC.SalesDivisionList);
                div_codeCollection.Filter = new Predicate<object>(div_codeFilter);
                StringListDivCode = MC.SalesDivisionList.Select(x => x.div_code).ToList();

                soff_codeCollection = CollectionViewSource.GetDefaultView(MC.SalesOfficeList);
                soff_codeCollection.Filter = new Predicate<object>(soff_codeFilter);
                StringListSalesOffice = MC.SalesOfficeList.Select(x => x.soff_code).ToList();

                SalesGroupList = (List<ADM_M001_H_P>)AppSessionState.ADM_M001_H_List;
                sg_codeCollection = CollectionViewSource.GetDefaultView(SalesGroupList);
                sg_codeCollection.Filter = new Predicate<object>(sg_codeFilter);
                StringListSalesGroup = SalesGroupList.Select(x => x.sg_code).ToList();

                if (SalesGroupList.Count != 0)
                {
                    if (SalesGroupList.Count == 1)
                    {
                        SelectedLOG_T001_A.sg_code = SalesGroupList[0].sg_code;
                        SelectedLOG_T001_A.sgnm = SalesGroupList[0].sg_name;
                    }
                }
                else
                {
                    SelectedLOG_T001_A.sg_code = "";
                }

                Item_CatCollection = CollectionViewSource.GetDefaultView(MC.ItemCategoryList);
                Item_CatCollection.Filter = new Predicate<object>(Item_CatFilter);
                StringListItemCat = MC.ItemCategoryList.Select(x => x.sditem_cat_code).ToList();

                uomCollection = CollectionViewSource.GetDefaultView(MC.UomList);
                uomCollection.Filter = new Predicate<object>(uomFilter);
                StringListUom = MC.UomList.Select(x => x.unit_code).ToList();

                WtUomCollection = CollectionViewSource.GetDefaultView(MC.UomList);
                WtUomCollection.Filter = new Predicate<object>(FilterCollectionWtUom);
                StringListWtUom = MC.UomList.Select(x => x.unit_code).ToList();

                VolUomCollection = CollectionViewSource.GetDefaultView(MC.UomList);
                VolUomCollection.Filter = new Predicate<object>(FilterCollectionVolUom);
                StringListVolUom = MC.UomList.Select(x => x.unit_code).ToList();

                Store_LoctnBCollection = CollectionViewSource.GetDefaultView(MC.StoreLocList);
                Store_LoctnBCollection.Filter = new Predicate<object>(Store_LoctnFilter);
                StringListStoreLocB = MC.StoreLocList.Select(x => x.store_code).ToList();

                StoreLocList = (List<MM_M001>)AppSessionState.store_location;
                store_location = (from o in StoreLocList
                                  where o.location_Id == AppSessionState.location_Id && o.default_storage_loc == Convert.ToBoolean(1)
                                  select o.store_code).ToList()[0];
                //if (StoreLocList.Count == 1)
                //{
                //    store_location = StoreLocList[0].store_code;
                //}

                CountryCollection = CollectionViewSource.GetDefaultView(MC.CountryList);
                CountryCollection.Filter = new Predicate<object>(CountryFilter);
                StringListCountry = MC.CountryList.Select(x => x.country_code).ToList();

                dest_countryCollection = CollectionViewSource.GetDefaultView(MC.CountryList);
                dest_countryCollection.Filter = new Predicate<object>(dest_countryFilter);
                StringListDestCountry = MC.CountryList.Select(x => x.country_code).ToList();

                var epcgList = (from o in MC.licList
                                where o.curr_name == "EPCG"
                                select o).ToList();

                epcgLicCollection = CollectionViewSource.GetDefaultView(epcgList.ToList());
                epcgLicCollection.Filter = new Predicate<object>(epcgFilter);
                StringListEPCG = epcgList.Select(x => x.curr_code).ToList();

                var advanceList = (from o in MC.licList
                                   where o.curr_name == "ADVANCE"
                                   select o).ToList();

                advanceLicCollection = CollectionViewSource.GetDefaultView(advanceList.ToList());
                advanceLicCollection.Filter = new Predicate<object>(advanceFilter);
                StringListAdvLic = advanceList.Select(x => x.curr_code).ToList();

                TransporterCollection = CollectionViewSource.GetDefaultView(MC.PartyTranList);
                TransporterCollection.Filter = new Predicate<object>(TransporterFilter);
                StringListTransporter = MC.PartyTranList.Select(x => x.PartyId).ToList();

                cf_agentCollection = CollectionViewSource.GetDefaultView(MC.PartyTranList);
                cf_agentCollection.Filter = new Predicate<object>(cf_agentFilter);
                StringListCFAgent = MC.PartyTranList.Select(x => x.PartyId).ToList();

                BatchCollection = CollectionViewSource.GetDefaultView(MC.BatchesList.ToList());
                StringListBatch = MC.BatchesList.Select(x => x.batch_no).ToList();

                FlipDeliveryNoteCollection = CollectionViewSource.GetDefaultView(MC.FlipGridList);
                FlipDeliveryNoteCollection.Filter = new Predicate<object>(FlipFilter);

                PlantList = (List<ADM_M003>)AppSessionState.ADM_M003_List;


                SendingPlant = CollectionViewSource.GetDefaultView(PlantList);
                SendingPlant.Filter = new Predicate<object>(Filter_SendingPlant);
                StringListSendingPlant = PlantList.Select(x => x.location_Id).ToList();

                ReceivingPlant = CollectionViewSource.GetDefaultView(PlantList);
                ReceivingPlant.Filter = new Predicate<object>(Filter_RecPlant);
                StringListReceivingPlant = PlantList.Select(x => x.location_Id).ToList();

                SelectedLOG_T001_A.origion_country = (from o in PlantList where o.location_Id == SelectedLOG_T001_A.location_Id select o.country_code).FirstOrDefault();
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
        // GET details of BackFlip Selected Record
        private void InsertSendingPlant(object InputValue)
        {
            try
            {

                string Request = "";
                ADM_M003 POPUPEntityObject = null;
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
                            { POPUPEntityObject = PlantList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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

                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    SelectedLOG_T001_A.location_Id = POPUPEntityObject.location_Id;
                    SelectedLOG_T001_A.supplantnm = POPUPEntityObject.LoctnNm;
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
        private void InsertRecPlant(object InputValue)
        {
            try
            {

                string Request = "";
                ADM_M003 POPUPEntityObject = null;
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
                            { POPUPEntityObject = PlantList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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

                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    SelectedLOG_T001_A.rec_plant = POPUPEntityObject.location_Id;
                    SelectedLOG_T001_A.recplantnm = POPUPEntityObject.LoctnNm;
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
        private void GetSelectedDeliveryNote(IList DeliveryNote)
        {
            try
            {

                IList list = DeliveryNote as IList;
                List<LOG_T001_A_FLIP> GetSelectedDeliveryNoteTemp = list.Cast<LOG_T001_A_FLIP>().ToList();


                if (GetSelectedDeliveryNoteTemp.Count > 0)
                {
                    string Request = "DelNoteDetails" + "!@" + GetSelectedDeliveryNoteTemp[0].delivery_no;
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp, "", "DeliveryNote", "SCM", "DelNoteDetails", 0, Request);

                    SelectedLOG_T001_A = MCTemp.Delivery_Note[0];
                    SelectedLOG_T001_A.ts_code = ts_code_vm;
                    Del_Note_Dtails = MCTemp.DelNoteItemDetails;
                    ItemBatch_list = MCTemp.ItemBatchDetails;
                    FilterBatchDataGrid();

                    blNew = false; parameter = false;

                    if (SelectedLOG_T001_A.t_status == "011") // 011==> "Shipped" Status
                    {
                        post = false;
                    }
                    if (SelectedLOG_T001_A.t_status == "001" || SelectedLOG_T001_A.t_status == null) // 001 ==> "Draft" Status
                    {
                        post = true;
                    }

                    SelectedTabControlIndex = 0;

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
        private void ReloadViewDataGrid(object InputValue)
        {
            try
            {
                string Request = "LoadRecordsofSelectedDate" + "!@" + AppSessionState.comp_code + "!@" + Plant + "!@" + "ST"  + "!@" + Convert.ToDateTime(FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ToDate).ToString("MM/dd/yyyy") ;
                MCTemp = repositoryM.GetDataWithReturnDomainObject<LOG_T001_A>(MCTemp, "LOG_T001_A_Data", "DeliveryNote", "SCM", "LoadRecordsofSelectedDate", 0, Request);
                //MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MC, "LOG_T001_A_Data", "DeliveryNote", "SCM", "LoadAll", 0, Request);
                //   FlipGridData = MCTemp.FlipGridList;
                FlipDeliveryNoteCollection = CollectionViewSource.GetDefaultView(MCTemp.FlipGridList);
                FlipDeliveryNoteCollection.Filter = new Predicate<object>(FlipFilter);
                FlipDeliveryNoteCollection.Refresh();

            }
            catch (Exception ex) { }
        }
        private void LoadSODetails(object items)
        {
            try
            {
                if (Convert.ToString(items) == SelectedLOG_T001_A.order_no)
                {
                    if (SelectedLOG_T001_A.order_no == null || SelectedLOG_T001_A.order_no == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Order Selection";
                        showMessageService.Text = String.Format("Please Select Order No", this.Title);
                        showMessageService.ShowMessage();
                    }
                    else
                    {
                        // string company = AppSessionState.comp_code.ToString() + "!@" + AppSessionState.location_Id.ToString() + "!@" + doc_type_Order + "!@" + SelectedLOG_T001_A.order_no;
                        string Request = "OrderDetails" + "!@" + SelectedLOG_T001_A.ref_doc_cat
                            + "!@" + SelectedLOG_T001_A.order_no;

                        MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp, "LOG_T001_A_Data", "DeliveryNote", "SCM", "OrderDetails", 0, Request);

                        if (MCTemp.OrderDataList.Count > 0)
                        {
                            SelectedLOG_T001_A.tr_party = MCTemp.OrderDataList[0].transporter_cd;
                            SelectedLOG_T001_A.transporternm = MCTemp.OrderDataList[0].transporternm;
                            SelectedLOG_T001_A.location_Id = MCTemp.OrderDataList[0].supplying_plant;
                            SelectedLOG_T001_A.rec_plant = MCTemp.OrderDataList[0].rec_plant;
                            SelectedLOG_T001_A.supplantnm = MCTemp.OrderDataList[0].supplantnm;
                            SelectedLOG_T001_A.recplantnm = MCTemp.OrderDataList[0].recplantnm;
                            SelectedLOG_T001_A.ts_code = ts_code_vm;
                            if (MCTemp.ItemList.Count > 0)
                            {
                                ItemsCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemList);
                                ItemsCollection.Filter = new Predicate<object>(ItemsFilter);
                            }
                            else   // when it is less than 0 filter don't work and it is necessory to show item collection null hence this condition otherwise it will show previous items
                            {
                                ItemsCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemList);
                            }

                        }
                        else
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Loading Fail...!!!", this.Title);
                            showMessageService.ShowMessage();
                        }
                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Order Selection";
                    showMessageService.Text = String.Format("Please Enter Valid Order No", this.Title);
                    showMessageService.ShowMessage();
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
        private void Post()
        {
            try
            {
                CursorControl.SetBusyState();
                if (SelectedLOG_T001_A.delivery_no != null && SelectedLOG_T001_A.delivery_no != "" && Del_Note_Dtails.Count > 0)
                {
                    if (Validation() == true)
                    {
                        ObjectMM_T001 = new MM_T001();

                        ObjectMM_T001.comp_code = SelectedLOG_T001_A.comp_code;
                        ObjectMM_T001.doc_date = SelectedLOG_T001_A.goods_issue_date ?? DateTime.Now;
                        ObjectMM_T001.doc_code = "DI";
                        ObjectMM_T001.doc_cat = "DI";
                        ObjectMM_T001.rec_plant = SelectedLOG_T001_A.rec_plant;
                        ObjectMM_T001.sending_plant = SelectedLOG_T001_A.location_Id;
                        ObjectMM_T001.source_doc_cat = SelectedLOG_T001_A.doc_cat;
                        ObjectMM_T001.source_doc_type = SelectedLOG_T001_A.doc_type;
                        ObjectMM_T001.source_doc_no = SelectedLOG_T001_A.delivery_no;
                        ObjectMM_T001.PartyId = SelectedLOG_T001_A.ship_to_party;
                        ObjectMM_T001.post_date = SelectedLOG_T001_A.goods_issue_date ?? DateTime.Now;
                        ObjectMM_T001.bill_ladding = SelectedLOG_T001_A.ladding_bill;
                        ObjectMM_T001.bill_ladding_dt = SelectedLOG_T001_A.ladding_date;
                        ObjectMM_T001.del_note = SelectedLOG_T001_A.delivery_no;
                        ObjectMM_T001.del_note_date = SelectedLOG_T001_A.delivery_date;
                        ObjectMM_T001.receipt_date = SelectedLOG_T001_A.goods_issue_date ?? DateTime.Now;
                        ObjectMM_T001.tr_mode = SelectedLOG_T001_A.tr_mode;
                        ObjectMM_T001.tr_party = SelectedLOG_T001_A.tr_party;
                        ObjectMM_T001.tranp_agency_name = SelectedLOG_T001_A.transporternm;
                        //ObjectMM_T001.trns_type = MasterEntity.; // Note: similer field not exists yet.
                        ObjectMM_T001.entry_time = DateTime.Now.TimeOfDay;
                        ObjectMM_T001.ref_doc = SelectedLOG_T001_A.delivery_no;
                        ObjectMM_T001.order_doc_type = SelectedLOG_T001_A.ref_doc_type;
                        ObjectMM_T001.order_doc_no = SelectedLOG_T001_A.ref_docno;
                        ObjectMM_T001.ref_doc_date = SelectedLOG_T001_A.delivery_date;
                        //ObjectMM_T001.time_zone = // Note: not yet integrated
                        ObjectMM_T001.mov_tp = (from o in MC.DocCategoryList where o.doc_cat == SelectedLOG_T001_A.doc_cat select o.mov_tp_mi).FirstOrDefault(); //150 Goods Issue for Sale
                        ObjectMM_T001.EmpId = SelectedLOG_T001_A.EmpId;
                        //ObjectMM_T001.dept_code = AppSessionState.d; // Note: not exists
                        ObjectMM_T001.active = true;
                        ObjectMM_T001.add_by = AppSessionState.UserID;
                        ObjectMM_T001.t_status = "001";
                        ObjectMM_T001.location_Id = SelectedLOG_T001_A.location_Id;
                        ObjectMM_T001.doc_type = "DI";
                        ObjectMM_T001.curr_code = SelectedLOG_T001_A.curr_code;
                        ObjectMM_T001.amt_doccurr = SelectedLOG_T001_A.net_value;
                        ObjectMM_T001.ex_rate = SelectedLOG_T001_A.exchange_rate;
                        ObjectMM_T001.client = AppSessionState.client;
                        ObjectMM_T001.lang_key = AppSessionState.UserLanguage;
                        //ObjectMM_T001.way_bill_no = MasterEntity.wa;// Note: not exists
                        //ObjectMM_T001.way_bill_date = MasterEntity.wa;// Note: not exists
                        //ObjectMM_T001.way_bill_value = MasterEntity.wa;// Note: not exists
                        ObjectMM_T001.ts_code = (from o in MC.DocCategoryList where o.doc_cat == SelectedLOG_T001_A.doc_cat select o.ts_code_mi).FirstOrDefault();
                        ObjectMM_T001_A = new List<MM_T001_A>();

                        foreach (var item in Del_Note_Dtails)
                        {
                            if (item.active == true)
                            {
                                ObjectMM_T001_A.Add(new MM_T001_A()
                                {
                                    line_id = ObjectMM_T001_A.Count() + 1,
                                    comp_code = item.comp_code,
                                    doc_date = SelectedLOG_T001_A.goods_issue_date ?? DateTime.Now,
                                    doc_cat = "DI",
                                    doc_type = "DI",
                                    mov_tp = (from o in MC.DocCategoryList where o.doc_cat == SelectedLOG_T001_A.doc_cat select o.mov_tp_mi).FirstOrDefault(), //150 Goods Issue for Sale
                                    wa_code = item.wa_code,
                                    store_code = item.store_code,
                                    batch_no = item.batch_no,
                                    ItemCode = item.ItemCode,
                                    sku = item.sku,
                                    sku_desc = item.sku_desc,
                                    PartyId = SelectedLOG_T001_A.ship_to_party,
                                    sono = item.sono,
                                    so_item_cd = item.so_item_code,
                                    curr_code = item.curr_code,
                                    qty = item.qty,
                                    challan_qty = item.qty,
                                    unit_code = item.unit_code,
                                    unit_price = item.net_price,
                                    debcr_ind = "D",
                                    source_doc_type = SelectedLOG_T001_A.doc_type,
                                    source_doc_no = SelectedLOG_T001_A.delivery_no,
                                    ref_doc_no = SelectedLOG_T001_A.delivery_no,
                                    ref_doc_type = SelectedLOG_T001_A.doc_type,
                                    order_doc_type = item.ref_doc_type,
                                    order_doc_no = item.order_no,
                                    ref_doc_item_cd = item.ref_doc_item_code,
                                    cost_center = item.cost_center,
                                    profit_center = item.profit_center,
                                    order_no = SelectedLOG_T001_A.order_no,
                                    active = true,
                                    add_by = AppSessionState.UserID,
                                    item_cat = item.item_cat,
                                    item_ok = true,
                                    t_status = "001",
                                    location_Id = item.location_Id,
                                    ri_plant = SelectedLOG_T001_A.rec_plant,
                                    vendor_batch_no = item.batch_no_ven,
                                    ref_item_line_id = item.ref_item_line_id,
                                    bom_no = item.bom_no,
                                    source_doc_itemline_id = item.ref_item_line_id,
                                    order_doc_item_id = item.order_item_row_id,
                                    lang_key = AppSessionState.UserLanguage,
                                    client = AppSessionState.client,
                                    post_date = SelectedLOG_T001_A.goods_issue_date ?? DateTime.Now,
                                    ref_doc_item_row_id = item.ref_item_row_id,
                                    ref_doc_cat = item.ref_doc_cat,
                                    so_item_row_id = item.so_item_row_id,
                                    order_doc_cat = item.order_doc_cat,
                                    dn_item_row_id = item.id
                                });

                                ObjectMM_T001_B = new List<MM_T001_B>();

                                foreach (var itemBatch in ItemBatch_list)
                                {
                                    if (item.active == true && item.id == itemBatch.del_item_row_id)
                                    {
                                        ObjectMM_T001_B.Add(new MM_T001_B()
                                        {
                                            grn_id = 0,
                                            item_line_id = itemBatch.line_id,
                                            ItemCode = itemBatch.ItemCode,
                                            sr_line_no = ObjectMM_T001_A.Count(),
                                            batch_no = itemBatch.batch_no,
                                            qty = itemBatch.qty,
                                            rec_qty = itemBatch.qty,
                                            unit_code = itemBatch.unit_code,
                                            t_status = ObjectMM_T001.t_status,
                                            location_Id = itemBatch.location_Id,
                                            comp_code = itemBatch.comp_code,
                                            wa_code = itemBatch.wa_code,
                                            store_code = itemBatch.store_code,
                                            active = true,
                                            add_by = AppSessionState.UserID,
                                            sku = itemBatch.sku,
                                            client = AppSessionState.client,
                                            ref_batch_row_id = itemBatch.id
                                        });
                                    }
                                }
                            }
                        }

                        ObjectSerializationService objSer = new ObjectSerializationService();
                        ObjectMM_T001.XmlDataDocument_MM_T001_A = objSer.ObjectToXML(ObjectMM_T001_A);
                        ObjectMM_T001.XmlDataDocument_MM_T001_B = objSer.ObjectToXML(ObjectMM_T001_B);

                        string reader = repositoryMI.Save<MM_T001>(ObjectMM_T001, "DeliveryNotePost", "SCM");

                        int intreader = Convert.ToInt32(reader);

                        if (intreader > 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Posting Successful", this.Title);
                            showMessageService.ShowMessage();
                            post = false;
                            SelectedLOG_T001_A.goods_issue = true;
                            SelectedLOG_T001_A.t_status = "011";
                            SelectedLOG_T001_A.t_display = (from o in MC.t_statusList where o.t_status == SelectedLOG_T001_A.t_status select o.t_display).FirstOrDefault();
                            SelectedLOG_T001_A.goods_issue = true;
                            SelectedLOG_T001_A.ts_code = ts_code_vm;

                            ObjectSerializationService objSer1 = new ObjectSerializationService();
                            SelectedLOG_T001_A.XmlDataDocument_LOG_T001_B = objSer1.ObjectToXML(Del_Note_Dtails);
                            SelectedLOG_T001_A.XmlDataDocument_LOG_T001_C = objSer1.ObjectToXML(ItemBatch_list);

                            //First Record Will Update
                            SelectedLOG_T001_A = repository.UpdateWithReturnDomainObject<LOG_T001_A>(SelectedLOG_T001_A, "DeliveryNote", "SCM");

                            // Getting Inserted and Updated Record of ITEM Details LOG_T001_B
                            if (SelectedLOG_T001_A.XmlDataDocument_LOG_T001_B != null)
                            {
                                MCTemp.DelNoteItemDetails = (ObservableCollection<LOG_T001_B>)new ObjectSerializationService().XMLToObject(SelectedLOG_T001_A.XmlDataDocument_LOG_T001_B, MC.DelNoteItemDetails);
                            }
                            else
                            {
                                MCTemp.DelNoteItemDetails = new ObservableCollection<LOG_T001_B>();
                            }
                            Del_Note_Dtails = MCTemp.DelNoteItemDetails;

                            // Getting Inserted and Updated Record of ITEM BATCH Details LOG_T001_C
                            if (SelectedLOG_T001_A.XmlDataDocument_LOG_T001_C != null)
                            {
                                MCTemp.ItemBatchDetails = (ObservableCollection<LOG_T001_C>)new ObjectSerializationService().XMLToObject(SelectedLOG_T001_A.XmlDataDocument_LOG_T001_C, MC.ItemBatchDetails);
                            }
                            else
                            {
                                MCTemp.ItemBatchDetails = new ObservableCollection<LOG_T001_C>();
                            }
                            ItemBatch_list = MCTemp.ItemBatchDetails;
                        }
                        else
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Posting Unsuccessful", this.Title);
                            showMessageService.ShowMessage();
                            post = true;
                        }
                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Goods Posting";
                    showMessageService.Text = String.Format("Not Allowed to Post If Delivery Number is Not generated.\n Please Save the Record First And Then Click on Post \n Also At List 1 Item Must Be Added to Post the Note", this.Title);
                    showMessageService.ShowMessage();
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
        private void GetSelectedDel_TypeDetails(object InputValue)
        {
            try
            {

                string Request = "";
                SYS_M005_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.DeliveryTypeList.Where(x => x.delivery_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M005_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {
                    SelectedLOG_T001_A.delivery_type = POPUPEntityObject.delivery_type;
                    SelectedLOG_T001_A.del_desc = POPUPEntityObject.del_desc;
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
        private void GetSelectedsold_toPartyDetails(object InputValue)
        {
            try
            {

                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PartyList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {
                    SelectedLOG_T001_A.PartyId = POPUPEntityObject.PartyId;
                    SelectedLOG_T001_A.soldpartynm = POPUPEntityObject.PartyNm;

                    var billaddress = (from o in MC.PartyAddressList where o.PartyId == POPUPEntityObject.PartyId select o).ToList();

                    if (billaddress.Count == 1)
                    {
                        SelectedLOG_T001_A.bill_address_id = billaddress[0].SrNo;
                        SelectedLOG_T001_A.bill_addloc = billaddress[0].Location;
                    }

                    if (billaddress.Count > 1)
                    {
                        BillAddressCollection = CollectionViewSource.GetDefaultView(billaddress.ToList());
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
        private void GetSelectedship_toPartyDetails(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PartyList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {
                    SelectedLOG_T001_A.ship_to_party = POPUPEntityObject.PartyId;
                    SelectedLOG_T001_A.shippartynm = POPUPEntityObject.PartyNm;

                    var deliveryaddress = (from o in MC.PartyAddressList where o.PartyId == POPUPEntityObject.PartyId select o).ToList();

                    if (deliveryaddress.Count == 1)
                    {
                        SelectedLOG_T001_A.del_address = deliveryaddress[0].SrNo;
                        SelectedLOG_T001_A.del_addloc = deliveryaddress[0].Location;
                    }

                    if (deliveryaddress.Count > 1)
                    {
                        DelAddressCollection = CollectionViewSource.GetDefaultView(deliveryaddress.ToList());
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
        private void getselecteddoctype(object InputValue)
        {
            try
            {

                string Request = "";
                SYS_M002_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.DocTypeList.Where(x => x.doc_type_user.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M002_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    SelectedLOG_T001_A.ref_doc_type = POPUPEntityObject.doc_type_user;
                    SelectedLOG_T001_A.ref_doc_cat = POPUPEntityObject.doc_cat;

                    var doctypewise = (from o in MC.OrderList
                                       where o.doc_cat == SelectedLOG_T001_A.ref_doc_cat
                                       select o).ToList();

                    S_OrderCollection = CollectionViewSource.GetDefaultView(doctypewise.ToList());
                    S_OrderCollection.Filter = new Predicate<object>(S_OrderFilter);
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
        private void GetSelectedS_OrderDetails(object InputValue)
        {
            try
            {

                string Request = "";
                Order_No_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.OrderList.Where(x => x.order_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<Order_No_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    SelectedLOG_T001_A.order_no = POPUPEntityObject.order_no;
                    //  SelectedLOG_T001_A.ref_docno = POPUPEntityObject.order_no;
                    SelectedLOG_T001_A.ref_doc_cat = POPUPEntityObject.doc_cat;
                    SelectedLOG_T001_A.ref_doc_type = POPUPEntityObject.doc_type;
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
        private void GetSelectedTransporterDetails(object InputValue)
        {
            try
            {

                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PartyTranList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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

                if (POPUPEntityObject != null)
                {
                    SelectedLOG_T001_A.tr_party = POPUPEntityObject.PartyId;
                    SelectedLOG_T001_A.transporternm = POPUPEntityObject.PartyNm;
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
        private void GetSelecteddest_countryDetails(object InputValue)
        {
            try
            {

                string Request = "";
                ADM_M012_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.CountryList.Where(x => x.country_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M012_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    SelectedLOG_T001_A.country_code = POPUPEntityObject.country_code;
                    SelectedLOG_T001_A.dest_countrynm = POPUPEntityObject.CntryName;
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
        private void GetSelectedcf_agentDetails(object InputValue)
        {
            try
            {

                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PartyList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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

                if (POPUPEntityObject != null)
                {
                    SelectedLOG_T001_A.cf_agent_code = POPUPEntityObject.PartyId;
                    SelectedLOG_T001_A.cf_agentnm = POPUPEntityObject.PartyNm;
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
        private void getSelected_epcg(object InputValue)
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
                            { POPUPEntityObject = MC.CurrencyList.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    SelectedLOG_T001_A.lic_cod = POPUPEntityObject.curr_code;
                    SelectedLOG_T001_A.epcgnm = POPUPEntityObject.curr_name;
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
        private void getSelected_advance(object InputValue)
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
                            { POPUPEntityObject = MC.CurrencyList.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    SelectedLOG_T001_A.advance_lic = POPUPEntityObject.curr_code;
                    SelectedLOG_T001_A.adv_lic_nm = POPUPEntityObject.curr_name;
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
        private void GetSelectedCountryDetails(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M012_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.CountryList.Where(x => x.country_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M012_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    SelectedLOG_T001_A.origion_country = POPUPEntityObject.country_code;
                    SelectedLOG_T001_A.countrynm = POPUPEntityObject.CntryName;
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
        private void GetSelectedso_codeDetails(object InputValue)
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
                            { POPUPEntityObject = MC.SalesOrgList.Where(x => x.so_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    SelectedLOG_T001_A.so_code = POPUPEntityObject.so_code;
                    SelectedLOG_T001_A.sales_orgnm = POPUPEntityObject.sales_org;
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
        private void GetSelecteddc_codeDetails(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M001_C_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.DistributionChannelList.Where(x => x.dc_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_C_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    SelectedLOG_T001_A.dc_code = Convert.ToString(POPUPEntityObject.dc_code);
                    SelectedLOG_T001_A.dcnm = Convert.ToString(POPUPEntityObject.dc_name);
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
        private void GetSelecteddiv_codeDetails(object InputValue)
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
                            { POPUPEntityObject = MC.SalesDivisionList.Where(x => x.div_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    SelectedLOG_T001_A.div_code = POPUPEntityObject.div_code;
                    SelectedLOG_T001_A.divnm = POPUPEntityObject.div_name;
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
        private void GetSelectedsoff_codeDetails(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M001_I_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SalesOfficeList.Where(x => x.soff_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_I_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    SelectedLOG_T001_A.soff_code = POPUPEntityObject.soff_code;
                    SelectedLOG_T001_A.sales_offnm = POPUPEntityObject.sales_off;
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
        private void GetSelectedsg_codeDetails(object InputValue)
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
                            { POPUPEntityObject = MC.SalesGroupList.Where(x => x.sg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    SelectedLOG_T001_A.sg_code = Convert.ToString(POPUPEntityObject.sg_code);
                    SelectedLOG_T001_A.sgnm = Convert.ToString(POPUPEntityObject.sg_name);

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
        private void GetSelectedInvicAddDetails(IList AddList)
        {
            try
            {
                IList list = AddList as IList;
                List<ADM_M029_P> GetSelectedAddDetailsTemp = list.Cast<ADM_M029_P>().ToList();

                if (GetSelectedAddDetailsTemp.Count > 0)
                {
                    SelectedLOG_T001_A.bill_address_id = GetSelectedAddDetailsTemp[0].SrNo;
                    SelectedLOG_T001_A.bill_addloc = GetSelectedAddDetailsTemp[0].Location;
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
        private void GetSelectedDelAddDetails(IList AddList)
        {
            try
            {
                IList list = AddList as IList;
                List<ADM_M029_PopUp1> GetSelectedAddDetailsTemp = list.Cast<ADM_M029_PopUp1>().ToList();
                if (GetSelectedAddDetailsTemp.Count > 0)
                {
                    SelectedLOG_T001_A.del_address = Convert.ToInt32(GetSelectedAddDetailsTemp[0].id);
                    SelectedLOG_T001_A.del_addloc = GetSelectedAddDetailsTemp[0].Location;
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
        private void GetSelectedcurr_nameDetails(object InputValue)
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
                            { POPUPEntityObject = MC.CurrencyList.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    SelectedLOG_T001_A.curr_code = POPUPEntityObject.curr_code;
                    SelectedLOG_T001_A.currnm = POPUPEntityObject.curr_name;
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
        private void CalculateWeightAndVolume()
        {
            try
            {
                if (SelectedLOG_T001_A.wt_goods == null)
                {
                    SelectedLOG_T001_A.wt_goods = 0;
                }
                if (SelectedLOG_T001_A.volume == null)
                {
                    SelectedLOG_T001_A.volume = 0;
                }
                if (SelectedLOG_T001_A.net_weight == null)
                {
                    SelectedLOG_T001_A.net_weight = 0;
                }
                if (SelectedLOG_T001_A.net_value == null)
                {
                    SelectedLOG_T001_A.net_value = 0;
                }
                SelectedLOG_T001_A.wt_goods = 0;
                SelectedLOG_T001_A.volume = 0;
                SelectedLOG_T001_A.net_weight = 0;
                SelectedLOG_T001_A.net_value = 0;

                foreach (var item in Del_Note_Dtails)
                {
                    if (item.active == true)
                    {
                        SelectedLOG_T001_A.wt_goods = SelectedLOG_T001_A.wt_goods + item.gross_wt;
                        SelectedLOG_T001_A.volume = SelectedLOG_T001_A.volume + item.volume;
                        SelectedLOG_T001_A.net_weight = SelectedLOG_T001_A.net_weight + item.net_wt;
                        SelectedLOG_T001_A.net_value = SelectedLOG_T001_A.net_value + item.net_value;
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
        private void InsertMasterMake(object InputValue)
        {
            try
            {

                string Request = "";
                ADM_M030_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            {
                                POPUPEntityObject = MC.ParamValueList.Where(x => x.parametervalue.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M030_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterMake = POPUPEntityObject.parametervalue;
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
        //B DG UOMS
        private void GetSelectedUomDetails(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                //AppSessionState.StringListValue = StringListUOM;
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UomList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    var InputValueIfExists = Del_Note_Dtails.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = Del_Note_Dtails.IndexOf(Del_Note_Dtails.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && Del_Note_Dtails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (Del_Note_Dtails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            Del_Note_Dtails[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (Del_Note_Dtails[dgSelectedIndex].unit_code != POPUPEntityObject.unit_code)
                        {
                            Del_Note_Dtails[dgSelectedIndex].unit_code = "";
                        }
                    }
                }

                #region Clear Empty Row
                LOG_T001_B newObj = new LOG_T001_B();
                for (int i = Del_Note_Dtails.Count - 1; i >= 0; i--)
                {
                    bool xx = Del_Note_Dtails[i].ComparePropertiesTo(newObj);
                    if (Del_Note_Dtails[i].ComparePropertiesTo(newObj) == true && Del_Note_Dtails.Count > 1)
                    {
                        Del_Note_Dtails.RemoveAt(i);
                        if (Del_Note_Dtails.Count == 0)
                        {
                            Del_Note_Dtails.Add(newObj);
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
        private void GetSelectedwtUOMDetails(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                //AppSessionState.StringListValue = StringListUOM;
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UomList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    var InputValueIfExists = Del_Note_Dtails.Where(X => X.weight_unit == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = Del_Note_Dtails.IndexOf(Del_Note_Dtails.Where(X => X.weight_unit == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && Del_Note_Dtails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (Del_Note_Dtails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            Del_Note_Dtails[dgSelectedIndex].weight_unit = POPUPEntityObject.unit_code;
                        }
                        else if (Del_Note_Dtails[dgSelectedIndex].unit_code != POPUPEntityObject.unit_code)
                        {
                            Del_Note_Dtails[dgSelectedIndex].weight_unit = "";
                        }
                    }
                }

                #region Clear Empty Row
                LOG_T001_B newObj = new LOG_T001_B();
                for (int i = Del_Note_Dtails.Count - 1; i >= 0; i--)
                {
                    bool xx = Del_Note_Dtails[i].ComparePropertiesTo(newObj);
                    if (Del_Note_Dtails[i].ComparePropertiesTo(newObj) == true && Del_Note_Dtails.Count > 1)
                    {
                        Del_Note_Dtails.RemoveAt(i);
                        if (Del_Note_Dtails.Count == 0)
                        {
                            Del_Note_Dtails.Add(newObj);
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
        private void GetSelectedvolUOMNmDetails(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                //AppSessionState.StringListValue = StringListUOM;
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UomList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    var InputValueIfExists = Del_Note_Dtails.Where(X => X.volumeunit == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = Del_Note_Dtails.IndexOf(Del_Note_Dtails.Where(X => X.volumeunit == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && Del_Note_Dtails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (Del_Note_Dtails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            Del_Note_Dtails[dgSelectedIndex].volumeunit = POPUPEntityObject.unit_code;
                        }
                        else if (Del_Note_Dtails[dgSelectedIndex].unit_code != POPUPEntityObject.unit_code)
                        {
                            Del_Note_Dtails[dgSelectedIndex].volumeunit = "";
                        }
                    }
                }

                #region Clear Empty Row
                LOG_T001_B newObj = new LOG_T001_B();
                for (int i = Del_Note_Dtails.Count - 1; i >= 0; i--)
                {
                    bool xx = Del_Note_Dtails[i].ComparePropertiesTo(newObj);
                    if (Del_Note_Dtails[i].ComparePropertiesTo(newObj) == true && Del_Note_Dtails.Count > 1)
                    {
                        Del_Note_Dtails.RemoveAt(i);
                        if (Del_Note_Dtails.Count == 0)
                        {
                            Del_Note_Dtails.Add(newObj);
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
        private void GetSelectedStore_LoctnBDetails(object Store_LoctnBList)
        {
            try
            {
                IList list = Store_LoctnBList as IList;
                List<MM_M001_P> SelectedStore_LoctnBDetailsTemp = list.Cast<MM_M001_P>().ToList();

                if (SelectedStore_LoctnBDetailsTemp.Count > 0)
                {
                    if (Del_Note_Dtails.Count > 0 && dgSelectedIndex != -1 && Del_Note_Dtails.Count > dgSelectedIndex)
                    {
                        Del_Note_Dtails[dgSelectedIndex].store_code = SelectedStore_LoctnBDetailsTemp[0].store_code;
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
        private void GetSelectedItem_CatDetails(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                SYS_M003_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ItemCategoryList.Where(x => x.sditem_cat_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    var InputValueIfExists = Del_Note_Dtails.Where(X => X.item_cat == POPUPEntityObject.sditem_cat_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = Del_Note_Dtails.IndexOf(Del_Note_Dtails.Where(X => X.item_cat == POPUPEntityObject.sditem_cat_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && Del_Note_Dtails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (Del_Note_Dtails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            Del_Note_Dtails[dgSelectedIndex].item_cat = POPUPEntityObject.sditem_cat_code;
                        }
                        else if (Del_Note_Dtails[dgSelectedIndex].item_cat != POPUPEntityObject.sditem_cat_code)
                        {
                            Del_Note_Dtails[dgSelectedIndex].item_cat = "";
                        }
                    }
                }
                #region Clear Empty Row
                LOG_T001_B newObj = new LOG_T001_B();
                for (int i = Del_Note_Dtails.Count - 1; i >= 0; i--)
                {
                    bool xx = Del_Note_Dtails[i].ComparePropertiesTo(newObj);
                    if (Del_Note_Dtails[i].ComparePropertiesTo(newObj) == true && Del_Note_Dtails.Count > 1)
                    {
                        Del_Note_Dtails.RemoveAt(i);
                        if (Del_Note_Dtails.Count == 0)
                        {
                            Del_Note_Dtails.Add(newObj);
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
        private void GetSelectedStoreLocationB(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                MM_M001_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.StoreLocList.Where(x => x.store_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<MM_M001_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M001_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = Del_Note_Dtails.Where(X => X.store_code == POPUPEntityObject.store_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = Del_Note_Dtails.IndexOf(Del_Note_Dtails.Where(X => X.store_code == POPUPEntityObject.store_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && Del_Note_Dtails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (Del_Note_Dtails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            Del_Note_Dtails[dgSelectedIndex].store_code = POPUPEntityObject.store_code;
                        }
                        else if (Del_Note_Dtails[dgSelectedIndex].item_cat != POPUPEntityObject.store_code)
                        {
                            Del_Note_Dtails[dgSelectedIndex].store_code = "";
                        }
                    }
                }
                #region Clear Empty Row
                LOG_T001_B newObj = new LOG_T001_B();
                for (int i = Del_Note_Dtails.Count - 1; i >= 0; i--)
                {
                    bool xx = Del_Note_Dtails[i].ComparePropertiesTo(newObj);
                    if (Del_Note_Dtails[i].ComparePropertiesTo(newObj) == true && Del_Note_Dtails.Count > 1)
                    {
                        Del_Note_Dtails.RemoveAt(i);
                        if (Del_Note_Dtails.Count == 0)
                        {
                            Del_Note_Dtails.Add(newObj);
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
        private void GetSelectedItemsDetails(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                //ItemsList = MC.ItemList;
                string Request = "";
                ADM_M022_P ItemDetails = new ADM_M022_P();
                dgSelectedIndex = dgSelectedIndex;

                #region Command Parameter Read Section

                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)// && InputValue.ToString().Trim() != "")
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();

                    if (Request.Length > 0)
                    {
                        try
                        {
                            ItemDetails = MC.ItemList.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; ItemDetails.Select = true;
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    ItemDetails = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                }

                #endregion

                if (ItemDetails != null)
                {
                    var InputValueIfExists = Del_Note_Dtails.Where(X => X.ItemCode == ItemDetails.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = Del_Note_Dtails.IndexOf(Del_Note_Dtails.Where(X => X.ItemCode == ItemDetails.ItemCode).FirstOrDefault()); // Prefer Primary Key for this instruction.
                    var LineId = Del_Note_Dtails.Count + 1;
                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && Del_Note_Dtails.Count == dgSelectedIndex && ItemDetails.Select == true)
                    {
                        Del_Note_Dtails.Add(new LOG_T001_B()
                        {
                            line_id = LineId,
                            ItemCode = ItemDetails.ItemCode,
                            Item_desc = ItemDetails.ItemName,
                            qty = Convert.ToDecimal(ItemDetails.qty),
                            unit_code = ItemDetails.unit_code,
                            SubCatCode = ItemDetails.SubCatCode,
                            StockUnt = ItemDetails.StockUnt,
                            comp_code = AppSessionState.comp_code,
                            location_Id = SelectedLOG_T001_A.location_Id,
                            add_by = AppSessionState.UserID,
                            active = true,
                            client = AppSessionState.client,
                            user_source1 = AppSessionState.UserSource1,
                            user_source2 = AppSessionState.UserSource2,
                            t_status = SelectedLOG_T001_A.t_status,
                            t_display = SelectedLOG_T001_A.t_display,
                            //fin_year = "16-17",
                            //posting_period = "1",
                            store_code = store_location,
                            para2 = "Local ",
                            para3 = MasterMatCon,
                            para1 = MasterMake,
                            order_no = ItemDetails.order_no,
                            sono = ItemDetails.sono,
                            so_item_line_id = ItemDetails.so_item_line_id,
                            so_item_row_id = ItemDetails.so_item_row_id,
                            ref_doc = ItemDetails.ref_doc,
                            ref_item_line_id = ItemDetails.ref_item_line_id,
                            ref_item_row_id = ItemDetails.ref_item_row_id
                        });
                    }
                    else if (dgSelectedIndex >= 0 && Del_Note_Dtails.Count > dgSelectedIndex && ItemDetails.Select == true) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (Del_Note_Dtails[dgSelectedIndex].ItemCode == null && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            if (Del_Note_Dtails[dgSelectedIndex].line_id == 0)
                            {
                                Del_Note_Dtails[dgSelectedIndex].line_id = Del_Note_Dtails.Count;
                            }
                            Del_Note_Dtails[dgSelectedIndex].ItemCode = ItemDetails.ItemCode;
                            Del_Note_Dtails[dgSelectedIndex].Item_desc = ItemDetails.ItemName;
                            Del_Note_Dtails[dgSelectedIndex].qty = Convert.ToDecimal(ItemDetails.qty);
                            Del_Note_Dtails[dgSelectedIndex].unit_code = ItemDetails.unit_code;
                            Del_Note_Dtails[dgSelectedIndex].StockUnt = ItemDetails.StockUnt;
                            Del_Note_Dtails[dgSelectedIndex].SubCatCode = ItemDetails.SubCatCode;
                            Del_Note_Dtails[dgSelectedIndex].comp_code = AppSessionState.comp_code;
                            Del_Note_Dtails[dgSelectedIndex].location_Id = SelectedLOG_T001_A.location_Id;
                            Del_Note_Dtails[dgSelectedIndex].add_by = AppSessionState.UserID;
                            Del_Note_Dtails[dgSelectedIndex].active = true;
                            Del_Note_Dtails[dgSelectedIndex].order_no = ItemDetails.order_no;
                            Del_Note_Dtails[dgSelectedIndex].sono = ItemDetails.sono;
                            Del_Note_Dtails[dgSelectedIndex].so_item_line_id = ItemDetails.so_item_line_id;
                            Del_Note_Dtails[dgSelectedIndex].so_item_row_id = ItemDetails.so_item_row_id;
                            Del_Note_Dtails[dgSelectedIndex].ref_doc = ItemDetails.ref_doc;
                            Del_Note_Dtails[dgSelectedIndex].ref_item_line_id = ItemDetails.ref_item_line_id;
                            Del_Note_Dtails[dgSelectedIndex].ref_item_row_id = ItemDetails.ref_item_row_id;

                        }
                        else if (Del_Note_Dtails[dgSelectedIndex].ItemCode != ItemDetails.ItemCode)
                        {
                            Del_Note_Dtails[dgSelectedIndex].ItemCode = "";
                        }
                    }
                }
                //ItemDetails.Select = false;
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
                if (Del_Note_Dtails.Count > i && Del_Note_Dtails[i].id == 0)
                {
                    // First Its Batches Will be removed And then Item  
                    ObservableCollection<LOG_T001_C> BatchTemp = ItemBatch_list;

                    for (int j = ItemBatch_list.Count - 1; j >= 0; j--)
                    {
                        if (Del_Note_Dtails[i].ItemCode == ItemBatch_list[j].ItemCode && Del_Note_Dtails[i].sku == ItemBatch_list[j].sku)
                        {
                            ItemBatch_list.Remove(ItemBatch_list[j]);
                        }
                    }

                    Del_Note_Dtails.RemoveAt(i);
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
        private void DeleteBatchDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemBatch_list.Count > i && ItemBatch_list[i].id == 0)
                {
                    ItemBatch_list.RemoveAt(i);
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
        private void ItemActiveInActiveMethod(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (Del_Note_Dtails.Count >= i && Del_Note_Dtails[i].id != 0)
                {
                    if (Del_Note_Dtails[i].active == false)
                    {
                        foreach (var item in ItemBatch_list)
                        {
                            if (item.ItemCode == Del_Note_Dtails[i].ItemCode && item.sku == Del_Note_Dtails[i].sku && item.active == true)
                            {
                                item.active = false;
                            }
                        }
                    }
                }
                else if (Del_Note_Dtails[i].id == 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Item {0} is Unsaved item. It is Recommanded to Delete This Item rather than inactivating it ", this.Title);
                    showMessageService.ShowMessage();
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
        private void BatchSplit()
        {
            try
            {
                if (dgSelectedIndex != -1 && Del_Note_Dtails.Count > 0)
                {
                    if (Del_Note_Dtails[dgSelectedIndex].split_allowed == true)
                    {
                        batchdatagrid = true; // if batch split checkbox is checked then only batchsplit is allowed
                    }
                    else
                    {
                        batchdatagrid = false;
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
        private void GetSelectedBatch(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                MM_S003_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BatchesList.Where(x => x.batch_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<MM_S003_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_S003_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = Del_Note_Dtails.Where(X => X.batch_no == POPUPEntityObject.batch_no).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = Del_Note_Dtails.IndexOf(Del_Note_Dtails.Where(X => X.batch_no == POPUPEntityObject.batch_no).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && Del_Note_Dtails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (Del_Note_Dtails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            var Batchtemp = (from o in ItemBatch_list where o.ItemCode == POPUPEntityObject.ItemCode && o.sku == POPUPEntityObject.sku select o).ToList();

                            if (POPUPEntityObject.stock_total >= Del_Note_Dtails[dgSelectedIndex].qty)
                            {
                                if (Batchtemp.Count == 0)
                                {
                                    Del_Note_Dtails[dgSelectedIndex].batch_no = POPUPEntityObject.batch_no;

                                    ItemBatch_list.Add(new LOG_T001_C()
                                    {
                                        ItemCode = POPUPEntityObject.ItemCode,
                                        batch_no = POPUPEntityObject.batch_no,
                                        store_code = POPUPEntityObject.store_code,
                                        unit_code = Del_Note_Dtails[dgSelectedIndex].unit_code,
                                        qty = Del_Note_Dtails[dgSelectedIndex].qty,
                                        //qty = ItemDetails.quantity,   
                                        comp_code = AppSessionState.comp_code,
                                        location_Id = SelectedLOG_T001_A.location_Id,
                                        add_by = AppSessionState.UserID,
                                        sku = POPUPEntityObject.sku,
                                        active = true,
                                        fin_year = "15-16",
                                        posting_period = "1"
                                    });
                                }

                                else if (Batchtemp.Count == 1)
                                {
                                    var record = ItemBatch_list.Where(X => X.ItemCode == POPUPEntityObject.ItemCode && X.sku == POPUPEntityObject.sku).FirstOrDefault();
                                    int IndexOfrecord = ItemBatch_list.IndexOf(ItemBatch_list.Where(X => X.ItemCode == POPUPEntityObject.ItemCode && X.sku == POPUPEntityObject.sku).FirstOrDefault());

                                    ItemBatch_list[IndexOfrecord].ItemCode = POPUPEntityObject.ItemCode;
                                    ItemBatch_list[IndexOfrecord].batch_no = POPUPEntityObject.batch_no;
                                    ItemBatch_list[IndexOfrecord].store_code = POPUPEntityObject.store_code;
                                    ItemBatch_list[IndexOfrecord].unit_code = Del_Note_Dtails[dgSelectedIndex].unit_code;
                                    ItemBatch_list[IndexOfrecord].qty = Del_Note_Dtails[dgSelectedIndex].qty;
                                    ItemBatch_list[IndexOfrecord].comp_code = AppSessionState.comp_code;
                                    ItemBatch_list[IndexOfrecord].location_Id = SelectedLOG_T001_A.location_Id;
                                    ItemBatch_list[IndexOfrecord].add_by = AppSessionState.UserID;
                                    ItemBatch_list[IndexOfrecord].sku = POPUPEntityObject.sku;
                                    ItemBatch_list[IndexOfrecord].active = true;
                                    ItemBatch_list[IndexOfrecord].fin_year = "15-16";
                                    ItemBatch_list[IndexOfrecord].posting_period = "1";

                                    Del_Note_Dtails[dgSelectedIndex].batch_no = POPUPEntityObject.batch_no;
                                }
                            }
                            else
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Batch Not Selected. Batch Available Quantity {0} is Less than Item Quantity {1}", POPUPEntityObject.stock_total, Del_Note_Dtails[dgSelectedIndex].qty);
                                showMessageService.ShowMessage();
                            }
                        }
                        else if (Del_Note_Dtails[dgSelectedIndex].batch_no != POPUPEntityObject.batch_no)
                        {
                            Del_Note_Dtails[dgSelectedIndex].batch_no = "";
                        }
                    }
                }
                #region Clear Empty Row
                LOG_T001_B newObj = new LOG_T001_B();
                for (int i = Del_Note_Dtails.Count - 1; i >= 0; i--)
                {
                    bool xx = Del_Note_Dtails[i].ComparePropertiesTo(newObj);
                    if (Del_Note_Dtails[i].ComparePropertiesTo(newObj) == true && Del_Note_Dtails.Count > 1)
                    {
                        Del_Note_Dtails.RemoveAt(i);
                        if (Del_Note_Dtails.Count == 0)
                        {
                            Del_Note_Dtails.Add(newObj);
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
        private void InsertMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                ADM_M030_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {

                            POPUPEntityObject = MC.ParamValueList.Where(x => x.parametervalue.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M030_P>().Count() > 0)
                    {

                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M030_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = Del_Note_Dtails.Where(X => X.para1 == POPUPEntityObject.parametervalue).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = Del_Note_Dtails.IndexOf(Del_Note_Dtails.Where(X => X.para1 == POPUPEntityObject.parametervalue).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && Del_Note_Dtails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (Del_Note_Dtails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            Del_Note_Dtails[dgSelectedIndex].para1 = POPUPEntityObject.parametervalue;
                        }
                        else if (Del_Note_Dtails[dgSelectedIndex].para1 != POPUPEntityObject.parametervalue)
                        {
                            Del_Note_Dtails[dgSelectedIndex].para1 = "";
                        }
                    }
                    #region Clear Empty Row
                    LOG_T001_B newObj = new LOG_T001_B();
                    for (int i = Del_Note_Dtails.Count - 1; i >= 0; i--)
                    {
                        bool xx = Del_Note_Dtails[i].ComparePropertiesTo(newObj);
                        if (Del_Note_Dtails[i].ComparePropertiesTo(newObj) == true && Del_Note_Dtails.Count > 1)
                        {
                            Del_Note_Dtails.RemoveAt(i);
                            if (Del_Note_Dtails.Count == 0)
                            {
                                Del_Note_Dtails.Add(newObj);
                            }
                        }
                    }

                    #endregion
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
        private void GetSelectedDel_TypeDetails2(object InputValue)
        {
            try
            {

                string Request = "";
                SYS_M005_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.DeliveryTypeList.Where(x => x.delivery_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<SYS_M005_P>().ToList().Count > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M005_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {
                    DelType = POPUPEntityObject.delivery_type;
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
        private void GenerateSku()
        {
            try
            {
                string makecode = "";
                string typecode = "";
                string matconcode = "";

                foreach (var o in Del_Note_Dtails)
                {
                    if (o.id == 0 && o.StockUnt == true)
                    {
                        makecode = "";
                        typecode = "";
                        matconcode = "";

                        if (o.para1 != null && o.para2 != null && o.para3 != null && o.para1 != "")
                        {
                            makecode = MC.ParamValueList.Where(X => X.parametervalue.Trim() == o.para1.Trim() && X.para_code == "1002").Select(x => x.value_code).FirstOrDefault();
                            typecode = MC.ParamValueList.Where(X => X.parametervalue.Trim() == o.para2.Trim() && X.para_code == "1001").Select(x => x.value_code).FirstOrDefault();
                            matconcode = MC.ParamValueList.Where(X => X.parametervalue.Trim() == o.para3.Trim() && X.para_code == "1003").Select(x => x.value_code).FirstOrDefault();

                            o.sku = makecode + "/" + typecode + "/" + matconcode;
                            o.sku_desc = "Make:" + o.para1 + "\t" + "Type:" + o.para2 + "\t" + "MaterialCondition:" + o.para3;

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
           
        }
        // below 4 methods are for Parameters and Parameter Values
        private void CollectionChanged(IList DataList)
        {

            string[] TempSkuList = new string[100];
            List<string> TempParaValueList = new List<string>();
            IList list = DataList as IList;
            int a = dgSelectedIndex;
            try
            {
                if (Del_Note_Dtails[dgSelectedIndex].id == 0 && Del_Note_Dtails.Count > 0 && dgSelectedIndex < Del_Note_Dtails.Count && dgSelectedIndex != -1)
                {
                    List<LOG_T001_B> SelectedRowlist = list.Cast<LOG_T001_B>().ToList();

                    if (SelectedRowlist[0].StockUnt == true)
                    {
                        var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();

                        ParameterTemp = paramlist.ToList();

                        if (paramlist.Count > 0 && Del_Note_Dtails[dgSelectedIndex].sku != "" && Del_Note_Dtails[dgSelectedIndex].sku != null)
                        {
                            TempSkuList = Del_Note_Dtails[dgSelectedIndex].sku.Split('/');

                            for (int i = 0; i < paramlist.Count; i++)
                            {
                                TempParaValueList = (from o in MC.ParamValueList where o.value_code == TempSkuList[i] select o.parametervalue).ToList();
                                if (TempParaValueList.Count > 0)
                                {
                                    paramlist[i].parametervalue = TempParaValueList[0];
                                }
                            }

                            ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                        }
                        else
                        {
                            foreach (var o in ParameterTemp)
                            {
                                o.parametervalue = null; o.value_code = null;
                            }
                            ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                        }

                        if (paramlist.Count > 0) //&& SelectedParaValueCollection.Count != paramlist.Count)
                        {
                            SelectedParaValueCollection = new List<ADM_M031_P>();

                            for (int i = 0; i < paramlist.Count; i++)
                            {
                                SelectedParaValueCollection.Add(new ADM_M031_P()
                                {
                                    // ItemCode = SelectedRowlist[0].ItemCode,
                                    dgselectedindex = dgSelectedIndex,
                                    //  value_code = SelectedParaValueList[0].value_code,
                                    para_code = paramlist[i].para_code,
                                    para_name = paramlist[i].para_name

                                });
                            }


                            if (Del_Note_Dtails[dgSelectedIndex].sku_desc != null)
                            {
                                SelectedParaValueCollection = ParameterCollection.Cast<ADM_M031_P>().ToList();

                                foreach (var o in SelectedParaValueCollection)
                                {
                                    o.dgselectedindex = dgSelectedIndex;
                                    foreach (var p in MC.ParamValueList)
                                    {
                                        if (o.para_code == p.para_code && o.parametervalue == p.parametervalue)
                                        {
                                            o.value_code = p.value_code;
                                        }
                                    }
                                }
                            }

                        }
                    }
                    else
                    {
                        ParameterCollection = CollectionViewSource.GetDefaultView(TempParaValueList);
                    }
                }
                else if (Del_Note_Dtails[dgSelectedIndex].id != 0 && Del_Note_Dtails.Count > 0 && dgSelectedIndex < Del_Note_Dtails.Count)
                {
                    //List<LOG_T001_B> SelectedRowlist = list.Cast<LOG_T001_B>().ToList();
                    //string[] TempSkuList = new string[100];
                    //List<string> TempParaValueList = new List<string>();

                    //if (SelectedRowlist[0].StockUnt == true)
                    //{
                    //    var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();
                    //    if (paramlist.Count > 0 && Del_Note_Dtails[dgSelectedIndex].sku != "" && Del_Note_Dtails[dgSelectedIndex].sku != null)
                    //    {
                    //        TempSkuList = Del_Note_Dtails[dgSelectedIndex].sku.Split('/');

                    //        for (int i = 0; i < paramlist.Count; i++)
                    //        {
                    //            TempParaValueList = (from o in MC.ParamValueList where o.value_code == TempSkuList[i] select o.parametervalue).ToList();
                    //            paramlist[i].parametervalue = TempParaValueList[0];
                    //        }

                    //        ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                    //    }
                    //}
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
        private void GetSelectedParaValue(IList parameter)
        {
            try
            {
                IList list = parameter as IList;
                List<ADM_M031_P> SelectedParaValueList = list.Cast<ADM_M031_P>().ToList();
                int a = ParadgSelectedIndex;
                int b = dgSelectedIndex;
                if (dgSelectedIndex != -1 && SelectedParaValueList.Count > 0 && Del_Note_Dtails[dgSelectedIndex].StockUnt == true)
                {
                    if (Del_Note_Dtails[dgSelectedIndex].id == 0)
                    {
                        #region 
                        if (SelectedParaValueList.Count > 0 && SelectedParaValueList[0].parametervalue != null && SelectedParaValueList[0].parametervalue != "")// && SelectedParaValueCollection.dgselectedindex.contains)
                        {
                            for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                            {
                                if (SelectedParaValueCollection[i].para_code == SelectedParaValueList[0].para_code && SelectedParaValueCollection[i].dgselectedindex == dgSelectedIndex)
                                {
                                    SelectedParaValueCollection[i].parametervalue = SelectedParaValueList[0].parametervalue;

                                    var paravaluetemp = (from o in MC.ParamValueList where o.para_code == SelectedParaValueCollection[i].para_code && o.parametervalue == SelectedParaValueCollection[i].parametervalue select o).ToList();

                                    if (paravaluetemp.Count > 0)
                                    {
                                        SelectedParaValueCollection[i].value_code = paravaluetemp[0].value_code;
                                    }
                                }
                            }

                            // SKU Description
                            GetSkuDescription();

                            //Function for calculating SKU
                            CalculateSku();
                        }
                        #endregion
                    }
                    else if (Del_Note_Dtails[dgSelectedIndex].id != 0)
                    {

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
        private void GetSkuDescription()
        {
            try
            {
                if (Del_Note_Dtails[dgSelectedIndex].sku_desc == null || Del_Note_Dtails[dgSelectedIndex].sku_desc == "")
                {
                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if ((Del_Note_Dtails[dgSelectedIndex].sku_desc == "" || Del_Note_Dtails[dgSelectedIndex].sku_desc == null) && SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                        {
                            Del_Note_Dtails[dgSelectedIndex].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                        else if (SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                        {
                            Del_Note_Dtails[dgSelectedIndex].sku_desc = Del_Note_Dtails[dgSelectedIndex].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                    }
                }
                else
                {
                    Del_Note_Dtails[dgSelectedIndex].sku_desc = "";

                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if ((Del_Note_Dtails[dgSelectedIndex].sku_desc == "" || Del_Note_Dtails[dgSelectedIndex].sku_desc == null) && SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                        {
                            Del_Note_Dtails[dgSelectedIndex].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                        else if (SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                        {
                            Del_Note_Dtails[dgSelectedIndex].sku_desc = Del_Note_Dtails[dgSelectedIndex].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
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
            
        }
        private void CalculateSku()
        {
            try
            {
                if (Del_Note_Dtails[dgSelectedIndex].sku == null || Del_Note_Dtails[dgSelectedIndex].sku == "")
                {
                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if (Del_Note_Dtails[dgSelectedIndex].sku == "" || Del_Note_Dtails[dgSelectedIndex].sku == null)
                        {
                            Del_Note_Dtails[dgSelectedIndex].sku = SelectedParaValueCollection[i].value_code;
                        }
                        else
                        {
                            Del_Note_Dtails[dgSelectedIndex].sku = Del_Note_Dtails[dgSelectedIndex].sku + "/" + SelectedParaValueCollection[i].value_code;
                        }
                    }
                }
                else
                {
                    Del_Note_Dtails[dgSelectedIndex].sku = "";

                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if (Del_Note_Dtails[dgSelectedIndex].sku == "" || Del_Note_Dtails[dgSelectedIndex].sku == null)
                        {
                            Del_Note_Dtails[dgSelectedIndex].sku = SelectedParaValueCollection[i].value_code;
                        }
                        else
                        {
                            Del_Note_Dtails[dgSelectedIndex].sku = Del_Note_Dtails[dgSelectedIndex].sku + "/" + SelectedParaValueCollection[i].value_code;
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
            
        }
        // for BATCH
        private void GetBatchCollection(IList BatchList) // get batch collection by selected index Item Details
        {
            IList list = BatchList as IList;
            try
            {
                if (dgSelectedIndex != -1 && Del_Note_Dtails.Count > 0 && Del_Note_Dtails.Count > dgSelectedIndex)
                {
                    List<LOG_T001_B> SelectedBatchlist = list.Cast<LOG_T001_B>().ToList();

                    if (SelectedBatchlist.Count > 0)
                    {
                        var BatchTemp = (from o in MC.BatchesList where o.ItemCode == SelectedBatchlist[0].ItemCode && o.sku == SelectedBatchlist[0].sku select o).ToList();

                        BatchCollection = CollectionViewSource.GetDefaultView(BatchTemp.ToList());

                        if (BatchTemp.Count > 1)
                        {
                            split = true;   // if there are more than one batch for selected item then only batch split checkbox is allowed to check
                        }
                        else
                        {
                            split = false;
                        }

                        if (Del_Note_Dtails[dgSelectedIndex].split_allowed == true)
                        {
                            batchdatagrid = true; // if batch split checkbox is checked then only batchsplit is allowed
                        }
                        else
                        {
                            batchdatagrid = false;
                        }

                        if (Del_Note_Dtails[dgSelectedIndex].id == 0 && Del_Note_Dtails[dgSelectedIndex].StockUnt == true)
                        {
                            parameter = true;
                        }
                        else
                        {
                            parameter = false;
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
        }
        private void GetItemBatchCollection(IList ItemBatch)
        {
            //IList list = BatchList as IList;
            //try
            //{
            //    if (dgSelectedIndex != -1 && Del_Note_Dtails.Count > 0 && Del_Note_Dtails.Count > dgSelectedIndex)
            //    {
            //        List<LOG_T001_C> SelectedBatchlist = list.Cast<LOG_T001_C>().ToList();

            //        if (SelectedBatchlist.Count > 0)
            //        {
            //            var BatchTemp = (from o in MC.BatchesList where o.ItemCode == SelectedBatchlist[0].ItemCode && o.sku == SelectedBatchlist[0].sku select o).ToList();

            //            BatchCollection = CollectionViewSource.GetDefaultView(BatchTemp.ToList());
            //        }                   
            //    }
            //}
            //catch (Exception ex)
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format(ex.Message, this.Title);
            //    showMessageService.ShowMessage();
            //}
        }
        private void GetSelectedBatchForItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                MM_S003_P BatchDetails = new MM_S003_P();

                #region Command Parameter Read Section

                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();

                    if (Request.Length > 0)
                    {
                        try
                        {
                            BatchDetails = BatchList.Where(x => x.batch_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; BatchDetails.Select = true;
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    BatchDetails = ((IEnumerable)InputValue).Cast<MM_S003_P>().ToList()[0];
                }

                #endregion

                if (BatchDetails != null)
                {
                    var InputValueIfExists = ItemBatch_list.Where(X => X.batch_no == BatchDetails.batch_no).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemBatch_list.IndexOf(ItemBatch_list.Where(X => X.batch_no == BatchDetails.batch_no).FirstOrDefault()); // Prefer Primary Key for this instruction.

                    var FilteredBatch = (from o in ItemBatch_list
                                         where o.ItemCode == Del_Note_Dtails[dgSelectedIndex].ItemCode &&
                                            o.sku == Del_Note_Dtails[dgSelectedIndex].sku
                                         select o).ToList();

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && FilteredBatch.Count == batchsplitSelectedIndex && BatchDetails.Select == true)
                    {
                        ItemBatch_list.Add(new LOG_T001_C()
                        {
                            ItemCode = BatchDetails.ItemCode,
                            batch_no = BatchDetails.batch_no,
                            store_code = BatchDetails.store_code,
                            unit_code = Del_Note_Dtails[dgSelectedIndex].unit_code,
                            //qty = ItemDetails.quantity,   
                            comp_code = AppSessionState.comp_code,
                            location_Id = AppSessionState.location_Id,
                            add_by = AppSessionState.UserID,
                            sku = BatchDetails.sku,
                            active = true,
                            fin_year = "15-16",
                            posting_period = "1"
                        });
                    }
                    else if (batchsplitSelectedIndex >= 0 && BatchDetails.Select == true && ItemBatch_list.Count > batchsplitSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemBatch_list[batchsplitSelectedIndex].ItemCode == null && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            ItemBatch_list[batchsplitSelectedIndex].ItemCode = BatchDetails.ItemCode;
                            ItemBatch_list[batchsplitSelectedIndex].batch_no = BatchDetails.batch_no;
                            //Del_Note_Dtails[dgSelectedIndex].qty = ItemDetails.quantity;

                            ItemBatch_list[batchsplitSelectedIndex].store_code = BatchDetails.store_code;
                            ItemBatch_list[batchsplitSelectedIndex].comp_code = AppSessionState.comp_code;
                            ItemBatch_list[batchsplitSelectedIndex].location_Id = AppSessionState.location_Id;
                            ItemBatch_list[batchsplitSelectedIndex].add_by = AppSessionState.UserID;
                            ItemBatch_list[batchsplitSelectedIndex].unit_code = Del_Note_Dtails[dgSelectedIndex].unit_code;
                            ItemBatch_list[batchsplitSelectedIndex].sku = BatchDetails.sku;
                            ItemBatch_list[batchsplitSelectedIndex].active = true;
                            ItemBatch_list[batchsplitSelectedIndex].fin_year = "15-16";
                            ItemBatch_list[batchsplitSelectedIndex].posting_period = "1";
                        }
                        else if (ItemBatch_list[batchsplitSelectedIndex].batch_no != BatchDetails.batch_no)
                        {
                            ItemBatch_list[batchsplitSelectedIndex].batch_no = "";
                        }
                    }
                }

                #region Clear Empty Row

                LOG_T001_C newObj = new LOG_T001_C();
                for (int i = ItemBatch_list.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemBatch_list[i].ComparePropertiesTo(newObj);
                    if (ItemBatch_list[i].ComparePropertiesTo(newObj) && ItemBatch_list.Count > 1)
                    {
                        ItemBatch_list.RemoveAt(i);
                        if (ItemBatch_list.Count == 0)
                        {
                            ItemBatch_list.Add(newObj);
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
        private void FilterBatchDataGrid()
        {
            try
            {
                if (ItemBatch_list != null && ItemBatch_list.Count > 0 && dgSelectedIndex < ItemBatch_list.Count && dgSelectedIndex >= 0)
                {
                    DataGridView = CollectionViewSource.GetDefaultView(ItemBatch_list);
                    DataGridView.Filter = adv => ((LOG_T001_C)adv).ItemCode.Equals(Del_Note_Dtails[dgSelectedIndex].ItemCode);
                    DataGridView.Refresh();
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
        private void GetBatchbyBarcode(string InputValue)
        {
            
            string Request = "";
            MM_S003_P POPUPEntityObject = null;

            //if (InputValue.GetType() == typeof(string) && InputValue != null)
            //{
            Request = InputValue.ToString();
            if (Request.Length > 0)
            {
                try
                {
                    POPUPEntityObject = MC.BatchesList.Where(x => x.batch_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                }
                catch (Exception ex)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Invalid Barcode", this.Title);
                    showMessageService.ShowMessage();
                }
            }
                            


            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemBatch_list.Where(X => X.batch_no == POPUPEntityObject.batch_no).FirstOrDefault();
                int IndexOfExistValue = ItemBatch_list.IndexOf(ItemBatch_list.Where(X => X.batch_no == POPUPEntityObject.batch_no).FirstOrDefault()); // Prefer Primary Key for this instruction.

                if (IndexOfExistValue == -1)
                {
                    // var IfExists = Del_Note_Dtails.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistItem = Del_Note_Dtails.IndexOf(Del_Note_Dtails.Where(X => X.ItemCode == POPUPEntityObject.ItemCode && X.sku == POPUPEntityObject.sku && X.active == true).FirstOrDefault()); // Prefer Primary Key for this instruction.//&& X.unit_code == POPUPEntityObject.unit_code                               

                    if (IndexOfExistItem != -1)
                    {
                        Del_Note_Dtails[IndexOfExistItem].split_allowed = true;

                        ItemBatch_list.Add(new LOG_T001_C()
                        {
                            ItemCode = POPUPEntityObject.ItemCode,
                            batch_no = POPUPEntityObject.batch_no,
                            store_code = POPUPEntityObject.store_code,
                            unit_code = Del_Note_Dtails[IndexOfExistItem].unit_code,
                            //qty = ItemDetails.quantity,   
                            comp_code = AppSessionState.comp_code,
                            location_Id = AppSessionState.location_Id,
                            add_by = AppSessionState.UserID,
                            sku = POPUPEntityObject.sku,
                            active = true,
                            fin_year = "15-16",
                            posting_period = "1"
                        });
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Batch is Not Added Because Item {0}, Parameter SKU {1} is not present in Item Details\n Or Item is InActive", POPUPEntityObject.ItemCode, POPUPEntityObject.sku);
                        showMessageService.ShowMessage();
                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Batch already Exist", this.Title);
                    showMessageService.ShowMessage();
                }
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
        //PackingList Report

        private void PackingListReport()
        {
            try
            {
                if (post == false)
                {
                    string Request = "DN_PackingList" + "!@" + SelectedLOG_T001_A.ref_doc_cat + "!@" + SelectedLOG_T001_A.delivery_no;
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp, "LOG_T001_A_Data", "DeliveryNote", "SCM", "LoadAll", 0, Request);

                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];
                    //MC.Delivery_Note.Clear();
                    //MC.Delivery_Note.Add(SelectedLOG_T001_A);          

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == SelectedLOG_T001_A.comp_code).ToList();
                    objDataSource[0] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == SelectedLOG_T001_A.location_Id).ToList();
                    objDataSource[1] = Result;

                    objDataSource[2] = MCTemp.RptPackingListList;

                    objDataSourceName[0] = "dsCompany";
                    objDataSourceName[1] = "dsLocation";
                    objDataSourceName[2] = "RptPackingList";


                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\PackingList.rdlc", "PackingList");
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Goods Not Posted...!!! Cannot Print", this.Title);
                    showMessageService.ShowMessage();
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
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadSODetails(doc_no_vm);
                    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
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
                    Request = SelectedLOG_T001_A.client + "!@" + SelectedLOG_T001_A.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region . Validation Function .

        private bool Validation()
        {
            //if (SelectedLOG_T001_A.so_code == null || SelectedLOG_T001_A.so_code == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Validation";
            //    showMessageService.Text = String.Format("Please Select Sales Organization in Organizational Data Tab.");
            //    showMessageService.ShowMessage();
            //    return false;
            //}

            //if (SelectedLOG_T001_A.sg_code == null || SelectedLOG_T001_A.sg_code == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Validation";
            //    showMessageService.Text = String.Format("Please Select Sales Group in Organizational Data Tab.");
            //    showMessageService.ShowMessage();
            //    return false;
            //}

            GenerateSku();

            #region . Validation for Item Duplication, null Unit Code and Null or 0 Quantity For All Active Unsaved Items .
            // Validation for Quantity Item Duplication and Unit Code For Item Details
            foreach (var o in Del_Note_Dtails)
            {
                int flag = 0;
                if (o.id == 0 && o.active == true)
                {
                    foreach (var p in Del_Note_Dtails)
                    {
                        if (o.ItemCode == p.ItemCode && o.sku == p.sku && p.active == true)
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

                if (o.ItemCode != null && o.ItemCode != "")
                {
                    if (o.qty == null || o.qty == 0)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Quantity cannot be null or 0 for item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                        showMessageService.ShowMessage();
                        return false;
                    }

                    if (o.unit_code == null || o.unit_code == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Valid Unit Code for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                        showMessageService.ShowMessage();
                        return false;
                    }
                    if (o.store_code == null || o.store_code == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Valid Store Code for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                        showMessageService.ShowMessage();
                        return false;
                    }
                    if (o.para1 == null || o.para1 == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Make for the item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, Del_Note_Dtails.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }
                    if (o.para2 == null || o.para2 == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Type for the item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, Del_Note_Dtails.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }
                    if (o.para3 == null || o.para3 == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Material Condition for the item {0} and Parameter {1} At Index {2}", o.ItemCode, o.sku_desc, Del_Note_Dtails.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }
                }
                #region . Parameter Validation .
                // Validation For All Parameter Values Selected or Not

                if (o.StockUnt == true && o.active == true && o.id == 0)
                {
                    var paralist = (from p in MC.ParameterList where p.SubCatCode == o.SubCatCode select p).ToList();

                    if (paralist.Count > 0)
                    {
                        string[] SkuList = new string[100];           //string array
                        List<string> SkuListt = new List<string>();    // stringlist

                        if (o.sku != null && o.sku != "")
                        {
                            SkuList = o.sku.Split('/');
                            SkuListt = SkuList.ToList();

                            foreach (var item in SkuList)
                            {
                                if (item == "")
                                {
                                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                    showMessageService.ButtonSetup = DialogButton.Ok;
                                    showMessageService.Caption = "Parameter Validation";
                                    showMessageService.Text = String.Format("All Parameters of item {0} are not selected..!!! \n If you can see All Parameter Values Selected Please Select the Same Values Again ", o.ItemCode);
                                    showMessageService.ShowMessage();
                                    return false;
                                }
                            }
                        }
                        else
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Parameter Validation";
                            showMessageService.Text = String.Format("All Parameters of item {0} are not selected\n If you can see All Parameter Value Selected Please Select the Same Values Again ", o.ItemCode);
                            showMessageService.ShowMessage();
                            return false;
                        }
                    }

                }
                #endregion
            }

            #endregion

            #region . Active Batch Quantity Exceeds Capacity/Remaining Capacity of Stock Quantity.
            //Validation for Entered Batch Quantity More than Stock Quantity
            for (int a = 0; a < ItemBatch_list.Count; a++)
            {
                for (int b = 0; b < MC.BatchesList.Count; b++)
                {
                    if (ItemBatch_list[a].batch_no == MC.BatchesList[b].batch_no && ItemBatch_list[a].active == true)
                    {
                        if (ItemBatch_list[a].qty > MC.BatchesList[b].stock_total)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Batch {0} Quantity {1} Exceeds Batch Capacity/RemainingCapacity {2} ", ItemBatch_list[a].batch_no, ItemBatch_list[a].qty, MC.BatchesList[b].stock_total);
                            showMessageService.ShowMessage();
                            return false;
                        }
                    }
                }
            }
            #endregion

            #region . Item Quantity Batch Quantity Validation.
            //Validation For Item Quantity Equal To Sum of Quantities of All Active Batches Of the Item 
            //bool breakfor = false;
            for (int i = 0; i < Del_Note_Dtails.Count; i++)
            {
                decimal temp = 0;
                int flag = 0;

                if (Del_Note_Dtails[i].active == true)
                {
                    for (int j = 0; j < ItemBatch_list.Count; j++)
                    {
                        if (Del_Note_Dtails[i].ItemCode == ItemBatch_list[j].ItemCode && Del_Note_Dtails[i].sku == ItemBatch_list[j].sku && ItemBatch_list[j].active == true)
                        {
                            temp = temp + Convert.ToDecimal(ItemBatch_list[j].qty);
                            flag = 1;
                        }
                    }

                    if (Del_Note_Dtails[i].qty != temp && flag == 1)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Item Quantity is Not Equal to Sum of All Item Batches Quantities\n for Item {0} Parameter :{1} ", Del_Note_Dtails[i].ItemCode, Del_Note_Dtails[i].sku_desc);
                        showMessageService.ShowMessage();
                        //breakfor = false;
                        return false;
                    }
                }
            }
            #endregion

            return true;
        }

        #endregion

        #region . Command Actions .
        protected override void OnSaveAction(InquiryActionResult<LOG_T001_A> result)
        {
            try
            {
                SelectedLOG_T001_A.ts_code = ts_code_vm;
                SelectedLOG_T001_A.add_by = AppSessionState.UserID;
                SelectedLOG_T001_A.editby = AppSessionState.UserID;
                SelectedLOG_T001_A.doc_type = "DN";
                SelectedLOG_T001_A.doc_cat = "DN";
                SelectedLOG_T001_A.comp_code = AppSessionState.comp_code;
                SelectedLOG_T001_A.client = AppSessionState.client;

                if (SelectedLOG_T001_A.location_Id == null || SelectedLOG_T001_A.location_Id == "")
                {
                    SelectedLOG_T001_A.location_Id = AppSessionState.location_Id;
                }


                if (Validation() == true)// && (SelectedLOG_T001_A.t_status != "SHIPPED" && SelectedLOG_T001_A.t_status != "Shipped"))
                {
                    ObjectSerializationService objSer = new ObjectSerializationService();
                    SelectedLOG_T001_A.XmlDataDocument_LOG_T001_B = objSer.ObjectToXML(Del_Note_Dtails);
                    SelectedLOG_T001_A.XmlDataDocument_LOG_T001_C = objSer.ObjectToXML(ItemBatch_list);

                    if (blNew == true)
                    {
                        SelectedLOG_T001_A = repository.SaveWithReturnDomainObject<LOG_T001_A>(SelectedLOG_T001_A, "DeliveryNote", "SCM");
                        SelectedList.Add(SelectedLOG_T001_A);

                        // Adding Insert Record to Flip Grid
                        if (SelectedLOG_T001_A.XmlDataDocument_LOG_T001_D != null && blNew == true)
                        {
                            MCTemp.FlipGridList = (List<LOG_T001_A_FLIP>)new ObjectSerializationService().XMLToObject(SelectedLOG_T001_A.XmlDataDocument_LOG_T001_D, MC.FlipGridList);
                            MC.FlipGridList.Add(MCTemp.FlipGridList[0]);
                            FlipDeliveryNoteCollection.Refresh();
                        }
                        blNew = false;
                    }
                    else if (blNew == false)
                    {
                        SelectedLOG_T001_A = repository.UpdateWithReturnDomainObject<LOG_T001_A>(SelectedLOG_T001_A, "DeliveryNote", "SCM");
                    }

                    parameter = false; // After Save Parameter Popup Should not Open Hence Disabling this Variable

                    // Getting Inserted and Updated Record of ITEM Details LOG_T001_B
                    if (SelectedLOG_T001_A.XmlDataDocument_LOG_T001_B != null)
                    {
                        MCTemp.DelNoteItemDetails = (ObservableCollection<LOG_T001_B>)new ObjectSerializationService().XMLToObject(SelectedLOG_T001_A.XmlDataDocument_LOG_T001_B, MC.DelNoteItemDetails);
                    }
                    else
                    {
                        MCTemp.DelNoteItemDetails = new ObservableCollection<LOG_T001_B>();
                    }
                    Del_Note_Dtails = MCTemp.DelNoteItemDetails;

                    // Getting Inserted and Updated Record of ITEM BATCH Details LOG_T001_C
                    if (SelectedLOG_T001_A.XmlDataDocument_LOG_T001_C != null)
                    {
                        MCTemp.ItemBatchDetails = (ObservableCollection<LOG_T001_C>)new ObjectSerializationService().XMLToObject(SelectedLOG_T001_A.XmlDataDocument_LOG_T001_C, MC.ItemBatchDetails);
                    }
                    else
                    {
                        MCTemp.ItemBatchDetails = new ObservableCollection<LOG_T001_C>();
                    }
                    ItemBatch_list = MCTemp.ItemBatchDetails;

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Data Saved Successfully");
                    showMessageService.ShowMessage();

                    RemoveRefDoc();
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
        private void RemoveRefDoc()
        {
            try
            {
                if (SelectedLOG_T001_A.order_no != null)
                {
                    MC.OrderList.RemoveAll(X => X.order_no == SelectedLOG_T001_A.order_no);
                }
                var msg = new NotificationMessage("LOG_T001_A_VM2_P2P");
                Messenger.Default.Send<NotificationMessage>(msg);
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
        protected override void OnCreateAction(InquiryActionResult<LOG_T001_A> result)
        {
            try
            {
                blNew = true; parameter = false;
                SelectedLOG_T001_A = new LOG_T001_A();
                SelectedLOG_T001_A.delivery_date = DateTime.Now;
                SelectedLOG_T001_A.PartyId = "NA";
                SelectedLOG_T001_A.ship_to_party = "NA";
                SelectedLOG_T001_A.delivery_date = DateTime.Now;
                SelectedLOG_T001_A.goods_issue_date = DateTime.Now;
                SelectedLOG_T001_A.delivery_type = "ST";
                SelectedLOG_T001_A.ValidateAsync().Wait();
                Del_Note_Dtails = new ObservableCollection<LOG_T001_B>();
                ItemBatch_list = new ObservableCollection<LOG_T001_C>();
                post = true; batchdatagrid = false;
                ItemsCollection = CollectionViewSource.GetDefaultView(MC.ItemList);
                ItemsCollection.Filter = new Predicate<object>(ItemsFilter);
                StringListItems = MC.ItemList.Select(x => x.ItemCode).ToList();
                SelectedLOG_T001_A.ts_code = ts_code_vm;
                if (SalesOrganisationList.Count != 0)
                {
                    if (SalesOrganisationList.Count == 1)
                    {
                        SelectedLOG_T001_A.so_code = SalesOrganisationList[0].so_code;
                        SelectedLOG_T001_A.sales_orgnm = SalesOrganisationList[0].sales_org;
                    }
                }
                else
                {
                    SelectedLOG_T001_A.so_code = "";
                }


                if (SalesGroupList.Count != 0)
                {
                    if (SalesGroupList.Count == 1)
                    {
                        SelectedLOG_T001_A.sg_code = SalesGroupList[0].sg_code;
                        SelectedLOG_T001_A.sgnm = SalesGroupList[0].sg_name;
                    }
                }
                else
                {
                    SelectedLOG_T001_A.sg_code = "";
                }
                SelectedLOG_T001_A.t_status = "001";
                SelectedLOG_T001_A.t_display = (from o in MC.t_statusList where o.t_status == SelectedLOG_T001_A.t_status select o.t_display).FirstOrDefault();
                SelectedLOG_T001_A.origion_country = (from o in PlantList where o.location_Id == SelectedLOG_T001_A.location_Id select o.country_code).FirstOrDefault();
                SelectedLOG_T001_A.location_Id = AppSessionState.location_Id;
                SelectedLOG_T001_A.supplantnm = (from o in PlantList where o.location_Id == SelectedLOG_T001_A.location_Id select o.LoctnNm).FirstOrDefault();
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

        protected override void OnRemoveAction(InquiryActionResult<LOG_T001_A> result)
        {
            try
            {
                if (SelectedLOG_T001_A.delivery_no == null || SelectedLOG_T001_A.delivery_no == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Record is Unsaved. No Need to Delete it.\n If you Want to Create Fresh Record Click on Create", this.Title);
                    showMessageService.ShowMessage();
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Delete Changes";
                    showMessageService.Text =
                        String.Format(
                            "This record will be Deleted forever '{0}'",
                                this.Title);
                    if (showMessageService.ShowMessage() == DialogResult.Ok)
                    {
                        this.SelectedLOG_T001_A.EndEdit();
                        string response = repository.Delete(SelectedLOG_T001_A.delivery_no, "DeliveryNote", "SCM");
                        //FlipGridData.Remove(MasterEntity); Temp
                        SelectedLOG_T001_A = new LOG_T001_A();
                        SelectedLOG_T001_A.delivery_date = DateTime.Now;
                        SelectedLOG_T001_A.goods_issue_date = DateTime.Now;
                        Del_Note_Dtails = new ObservableCollection<LOG_T001_B>();
                        ItemBatch_list = new ObservableCollection<LOG_T001_C>();
                        SelectedLOG_T001_A.ValidateAsync().Wait();
                        FlipDeliveryNoteCollection.Refresh();
                        blNew = true;
                        post = true;
                        batchdatagrid = false;
                        parameter = false;
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

        protected override void OnDiscardAction(InquiryActionResult<LOG_T001_A> result)
        {
            SelectedLOG_T001_A.CancelEdit();
        }

        protected override void OnFevoriteAction(InquiryActionResult<LOG_T001_A> result)
        {
        }

        protected override void OnFlipAction(InquiryActionResult<LOG_T001_A> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<LOG_T001_A> result)
        {
        }

        protected override void OnPrintAction(InquiryActionResult<LOG_T001_A> result)
        {
            try
            {
                if (post == false)
                {
                    string Request = "DN_Report" + "!@" + SelectedLOG_T001_A.delivery_no;
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp, "LOG_T001_A_Data", "DeliveryNote", "SCM", "LoadAll", 0, Request);

                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];


                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == SelectedLOG_T001_A.comp_code).ToList();
                    objDataSource[0] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == SelectedLOG_T001_A.location_Id).ToList();
                    objDataSource[1] = Result;

                    objDataSource[2] = MCTemp.RptDeliveryNoteList;

                    objDataSourceName[0] = "dsCompany";
                    objDataSourceName[1] = "dsLocation";
                    objDataSourceName[2] = "dsDeliveryNote_P2P";


                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\SCM\\DeliveryNote_P2P.rdlc", getParametersList(), "DeliveryNote_P2P");
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Goods Not Posted...!!! Cannot Print", this.Title);
                    showMessageService.ShowMessage();
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
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<LOG_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<LOG_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<LOG_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<LOG_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<LOG_T001_A> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region . Filters .

        #region Filters For Del_Type
        private void FilterCollectionDel_Type()
        {
            if (_Del_TypeCollection != null)
            {
                _Del_TypeCollection.Refresh();
            }
        }

        private string _filterStringDel_Type;
        public string FilterStringDel_Type
        {
            get { return _filterStringDel_Type; }
            set
            {
                _filterStringDel_Type = value;
                RaisePropertyChanged("FilterStringDel_Type");
                FilterCollectionDel_Type();
            }
        }
        public bool Del_TypeFilter(object obj)
        {
            var data = obj as SYS_M005_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringDel_Type))
                {
                    return (data.delivery_type != null && data.delivery_type.ToString().ToLower().Contains(_filterStringDel_Type.ToLower())) ||
                        (data.del_desc != null && data.del_desc.ToString().ToLower().Contains(_filterStringDel_Type.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Del_Type
        private void FilterCollectionDel_Type2()
        {
            if (_Del_TypeCollection2 != null)
            {
                _Del_TypeCollection2.Refresh();
            }
        }

        private string _filterStringDel_Type2;
        public string FilterStringDel_Type2
        {
            get { return _filterStringDel_Type2; }
            set
            {
                _filterStringDel_Type2 = value;
                RaisePropertyChanged("FilterStringDel_Type2");
                FilterCollectionDel_Type2();
            }
        }
        public bool Del_TypeFilter2(object obj)
        {
            var data = obj as SYS_M005_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringDel_Type2))
                {
                    return (data.delivery_type != null && data.delivery_type.ToString().ToLower().Contains(_filterStringDel_Type2.ToLower())) ||
                        (data.del_desc != null && data.del_desc.ToString().ToLower().Contains(_filterStringDel_Type2.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Sold To Party
        private void FilterCollectionSoldToParty()
        {
            if (_sold_toPartyCollection != null)
            {
                _sold_toPartyCollection.Refresh();
            }
        }

        private string _filterStringSoldToParty;
        public string filterStringSoldToParty
        {
            get { return _filterStringSoldToParty; }
            set
            {
                _filterStringSoldToParty = value;
                RaisePropertyChanged("filterStringSoldToParty");
                FilterCollectionSoldToParty();
            }
        }

        public bool SoldToPartyFilter(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringSoldToParty))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterStringSoldToParty.ToLower())
                        || data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterStringSoldToParty.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Ship to Party
        private void FilterCollectionParty()
        {
            if (_ship_toPartyCollection != null)
            {
                _ship_toPartyCollection.Refresh();
            }
        }

        private string _filterStringParty;
        public string FilterStringParty
        {
            get { return _filterStringParty; }
            set
            {
                _filterStringParty = value;
                RaisePropertyChanged("FilterStringParty");
                FilterCollectionParty();
            }
        }

        public bool PartyFilter(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringParty))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterStringParty.ToLower())
                        || data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterStringParty.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region . Sending Plant .
        private string _filterString_SendingPlant;
        public string FilterString_SendingPlant
        {
            get { return _filterString_SendingPlant; }
            set
            {
                _filterString_SendingPlant = value;
                RaisePropertyChanged("FilterString_SendingPlant");
                FilterCollection_SendingPlant();
            }
        }
        private void FilterCollection_SendingPlant()
        {
            if (SendingPlant != null)
            {
                SendingPlant.Refresh();
            }
        }
        public bool Filter_SendingPlant(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SendingPlant))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_SendingPlant.ToLower()) ||
                        data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_SendingPlant.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Rec Plant .
        private string _filterString_RecPlant;
        public string FilterString_RecPlant
        {
            get { return _filterString_RecPlant; }
            set
            {
                _filterString_RecPlant = value;
                RaisePropertyChanged("FilterString_RecPlant");
                FilterCollection_RecPlant();
            }
        }
        private void FilterCollection_RecPlant()
        {
            if (ReceivingPlant != null)
            {
                ReceivingPlant.Refresh();
            }
        }
        public bool Filter_RecPlant(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_RecPlant))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_RecPlant.ToLower()) ||
                        data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_RecPlant.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For S_Order
        private void FilterCollectionS_Order()
        {
            if (_S_OrderCollection != null)
            {
                _S_OrderCollection.Refresh();
            }
        }

        private string _filterStringS_Order;
        public string FilterStringS_Order
        {
            get { return _filterStringS_Order; }
            set
            {
                _filterStringS_Order = value;
                RaisePropertyChanged("FilterStringS_Order");
                FilterCollectionS_Order();
            }
        }

        public bool S_OrderFilter(object obj)
        {
            var data = obj as Order_No_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringS_Order))
                {
                    return (data.order_no != null && data.order_no.ToString().ToLower().Contains(_filterStringS_Order.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For curr_name
        private void FilterCollectioncurr_name()
        {
            if (_curr_nameCollection != null)
            {
                _curr_nameCollection.Refresh();
            }
        }
        private string _filterStringcurr_name;
        public string FilterStringcurr_name
        {
            get { return _filterStringcurr_name; }
            set
            {
                _filterStringcurr_name = value;
                RaisePropertyChanged("FilterStringcurr_name");
                FilterCollectioncurr_name();
            }
        }
        public bool curr_nameFilter(object obj)
        {
            var data = obj as ADM_M037_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringcurr_name))
                {
                    return (data.curr_name != null && data.curr_name.ToString().ToLower().Contains(_filterStringcurr_name.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For so_code
        private void FilterCollectionso_code()
        {
            if (_so_codeCollection != null)
            {
                _so_codeCollection.Refresh();
            }
        }
        private string _filterStringso_code;
        public string FilterStringso_code
        {
            get { return _filterStringso_code; }
            set
            {
                _filterStringso_code = value;
                RaisePropertyChanged("FilterStringso_code");
                FilterCollectionso_code();
            }
        }
        public bool so_codeFilter(object obj)
        {
            var data = obj as ADM_M001_A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringso_code))
                {
                    return (data.sales_org != null && data.sales_org.ToString().ToLower().Contains(_filterStringso_code.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For dc_code
        private void FilterCollectiondc_code()
        {
            if (_dc_codeCollection != null)
            {
                _dc_codeCollection.Refresh();
            }
        }
        private string _filterStringdc_code;
        public string FilterStringdc_code
        {
            get { return _filterStringdc_code; }
            set
            {
                _filterStringdc_code = value;
                RaisePropertyChanged("FilterStringdc_code");
                FilterCollectiondc_code();
            }
        }
        public bool dc_codeFilter(object obj)
        {
            var data = obj as ADM_M001_C_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringdc_code))
                {
                    return (data.dc_name != null && data.dc_name.ToString().ToLower().Contains(_filterStringdc_code.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For div_code
        private void FilterCollectiondiv_code()
        {
            if (_div_codeCollection != null)
            {
                _div_codeCollection.Refresh();
            }
        }
        private string _filterStringdiv_code;
        public string FilterStringdiv_code
        {
            get { return _filterStringdiv_code; }
            set
            {
                _filterStringdiv_code = value;
                RaisePropertyChanged("FilterStringdiv_code");
                FilterCollectiondiv_code();
            }
        }
        public bool div_codeFilter(object obj)
        {
            var data = obj as ADM_M001_D_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringdiv_code))
                {
                    return (data.div_name != null && data.div_name.ToString().ToLower().Contains(_filterStringdiv_code.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For soff_code
        private void FilterCollectionsoff_code()
        {
            if (_soff_codeCollection != null)
            {
                _soff_codeCollection.Refresh();
            }
        }
        private string _filterStringsoff_code;
        public string FilterStringsoff_code
        {
            get { return _filterStringsoff_code; }
            set
            {
                _filterStringsoff_code = value;
                RaisePropertyChanged("FilterStringsoff_code");
                FilterCollectionsoff_code();
            }
        }
        public bool soff_codeFilter(object obj)
        {
            var data = obj as ADM_M001_I_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringsoff_code))
                {
                    return (data.sales_off != null && data.sales_off.ToString().ToLower().Contains(_filterStringsoff_code.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For sg_code
        private void FilterCollectionsg_code()
        {
            if (_sg_codeCollection != null)
            {
                _sg_codeCollection.Refresh();
            }
        }
        private string _filterStringsg_code;
        public string FilterStringsg_code
        {
            get { return _filterStringsg_code; }
            set
            {
                _filterStringsg_code = value;
                RaisePropertyChanged("FilterStringsg_code");
                FilterCollectionsg_code();
            }
        }
        public bool sg_codeFilter(object obj)
        {
            var data = obj as ADM_M001_H_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringsg_code))
                {
                    return (data.sg_name != null && data.sg_name.ToString().ToLower().Contains(_filterStringsg_code.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Item_Cat
        private void FilterCollectionItem_Cat()
        {
            if (_Item_CatCollection != null)
            {
                _Item_CatCollection.Refresh();
            }
        }
        private string _filterStringItem_Cat;
        public string FilterStringItem_Cat
        {
            get { return _filterStringItem_Cat; }
            set
            {
                _filterStringItem_Cat = value;
                RaisePropertyChanged("FilterStringItem_Cat");
                FilterCollectionItem_Cat();
            }
        }
        public bool Item_CatFilter(object obj)
        {
            var data = obj as SYS_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringItem_Cat))
                {
                    return (data.item_cat_desc != null && data.item_cat_desc.ToString().ToLower().Contains(_filterStringItem_Cat.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For uom
        private void FilterCollectionuom()
        {
            if (_uomCollection != null)
            {
                _uomCollection.Refresh();
            }
        }
        private string _filterStringuom;
        public string FilterStringuom
        {
            get { return _filterStringuom; }
            set
            {
                _filterStringuom = value;
                RaisePropertyChanged("FilterStringuom");
                FilterCollectionuom();
            }
        }
        public bool uomFilter(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringuom))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringuom.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Weight Uom
        private void FilterCollectionWtUom()
        {
            if (_WtUomCollection != null)
            {
                _WtUomCollection.Refresh();
            }
        }
        private string _filterStringWtUom;
        public string FilterStringWtUom
        {
            get { return _filterStringWtUom; }
            set
            {
                _filterStringWtUom = value;
                RaisePropertyChanged("FilterStringWtUom");
                FilterCollectionWtUom();
            }
        }
        public bool FilterCollectionWtUom(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringWtUom))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringWtUom.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Volume Uom
        private void FilterCollectionVolUom()
        {
            if (_VolUomCollection != null)
            {
                _VolUomCollection.Refresh();
            }
        }
        private string _filterStringVolUom;
        public string FilterStringVolUom
        {
            get { return _filterStringVolUom; }
            set
            {
                _filterStringVolUom = value;
                RaisePropertyChanged("FilterStringVolUom");
                FilterCollectionVolUom();
            }
        }
        public bool FilterCollectionVolUom(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringVolUom))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringVolUom.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Store_Loctn
        private void FilterCollectionStore_Loctn()
        {
            //if (_Store_LoctnCollection != null)
            //{
            //    _Store_LoctnCollection.Refresh();
            //}
            if (_Store_LoctnBCollection != null)
            {
                _Store_LoctnBCollection.Refresh();
            }
            //if (_Store_LoctnCCollection != null)
            //{
            //    _Store_LoctnCCollection.Refresh();
            //}
        }
        private string _filterStringStore_Loctn;
        public string FilterStringStore_Loctn
        {
            get { return _filterStringStore_Loctn; }
            set
            {
                _filterStringStore_Loctn = value;
                RaisePropertyChanged("FilterStringStore_Loctn");
                FilterCollectionStore_Loctn();
            }
        }
        public bool Store_LoctnFilter(object obj)
        {
            var data = obj as MM_M001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringStore_Loctn))
                {
                    return (data.store_code != null && data.store_code.ToString().ToLower().Contains(_filterStringStore_Loctn.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For CountryFilter
        private void FilterCollectionCountry()
        {
            if (_CountryCollection != null)
            {
                _CountryCollection.Refresh();
            }
        }
        private string _filterStringCountry;
        public string FilterStringCountry
        {
            get { return _filterStringCountry; }
            set
            {
                _filterStringCountry = value;
                RaisePropertyChanged("FilterStringCountry");
                FilterCollectionCountry();
            }
        }
        public bool CountryFilter(object obj)
        {
            var data = obj as Reflection.BusinessEntity.ADM_M012_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringCountry))
                {
                    return (data.CntryName != null && data.CntryName.ToString().ToLower().Contains(_filterStringCountry.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For dest_countryFilter
        private void FilterCollectiondest_country()
        {
            if (_dest_countryCollection != null)
            {
                _dest_countryCollection.Refresh();
            }
        }
        private string _filterStringdest_country;
        public string FilterStringdest_country
        {
            get { return _filterStringdest_country; }
            set
            {
                _filterStringdest_country = value;
                RaisePropertyChanged("FilterStringdest_country");
                FilterCollectiondest_country();
            }
        }
        public bool dest_countryFilter(object obj)
        {
            var data = obj as Reflection.BusinessEntity.ADM_M012_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringdest_country))
                {
                    return (data.CntryName != null && data.CntryName.ToString().ToLower().Contains(_filterStringdest_country.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For EPCG
        private void FilterCollectionepcg()
        {
            if (_epcgLicCollection != null)
            {
                _epcgLicCollection.Refresh();
            }
        }
        private string _filterStringepcg;
        public string FilterStringepcg
        {
            get { return _filterStringepcg; }
            set
            {
                _filterStringepcg = value;
                RaisePropertyChanged("filterStringepcg");
                FilterCollectionepcg();
            }
        }
        public bool epcgFilter(object obj)
        {
            var data = obj as ADM_M037_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringepcg))
                {
                    return (data.curr_code != null && data.curr_code.ToString().ToLower().Contains(_filterStringepcg.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For ADVANCE
        private void FilterCollectionadvance()
        {
            if (_advanceLicCollection != null)
            {
                _advanceLicCollection.Refresh();
            }
        }
        private string _filterStringadvance;
        public string FilterStringadvance
        {
            get { return _filterStringadvance; }
            set
            {
                _filterStringadvance = value;
                RaisePropertyChanged("filterStringadvance");
                FilterCollectionadvance();
            }
        }
        public bool advanceFilter(object obj)
        {
            var data = obj as ADM_M037_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringadvance))
                {
                    return (data.curr_code != null && data.curr_code.ToString().ToLower().Contains(_filterStringadvance.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For TransporterFilter
        private void FilterCollectionTransporter()
        {
            if (_TransporterCollection != null)
            {
                _TransporterCollection.Refresh();
            }
        }
        private string _filterStringTransporter;
        public string FilterStringTransporter
        {
            get { return _filterStringTransporter; }
            set
            {
                _filterStringTransporter = value;
                RaisePropertyChanged("FilterStringTransporter");
                FilterCollectionTransporter();
            }
        }
        public bool TransporterFilter(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringTransporter))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterStringTransporter.ToLower())
                        || data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterStringTransporter.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For cf_agentFilter
        private void FilterCollectioncf_agent()
        {
            if (_cf_agentCollection != null)
            {
                _cf_agentCollection.Refresh();
            }
        }
        private string _filterStringcf_agent;
        public string FilterStringcf_agent
        {
            get { return _filterStringcf_agent; }
            set
            {
                _filterStringcf_agent = value;
                RaisePropertyChanged("FilterStringcf_agent");
                FilterCollectioncf_agent();
            }
        }
        public bool cf_agentFilter(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringcf_agent))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterStringcf_agent.ToLower()) ||
                        data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterStringcf_agent.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Items
        private void FilterCollectionItems()
        {
            if (_ItemsCollection != null)
            {
                _ItemsCollection.Refresh();
            }
        }
        private string _filterStringItems;
        public string FilterStringItems
        {
            get { return _filterStringItems; }
            set
            {
                _filterStringItems = value;
                RaisePropertyChanged("FilterStringItems");
                FilterCollectionItems();
            }
        }
        public bool ItemsFilter(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringItems))
                {
                    return (data.ItemCode != null && data.ItemCode.ToLower().Contains(_filterStringItems.ToLower())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterStringItems.ToLower())) ||
                           //(data.q != null && data.quantity.ToString().ToLower().Contains(_filterStringItems.ToLower())) ||
                           (data.unit_code != null && data.unit_code.ToLower().Contains(_filterStringItems.ToLower()));
                    //((data.ink != null) && data.ink.ToLower().Contains(_filterStringItems.ToLower())) ||
                    //((data.ild != null) && data.ild.ToLower().Contains(_filterStringItems.ToLower())) ||
                    //((data.grade != null) && data.grade.ToLower().Contains(_filterStringItems.ToLower())) ||
                    //((data.Description != null) && data.Description.ToLower().Contains(_filterStringItems.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters for Flip Gatagrid

        private void FlipCollection()
        {
            if (_FlipDeliveryNoteCollection != null)
            {
                _FlipDeliveryNoteCollection.Refresh();
            }
        }
        private string _filterStringFlip;
        public string FilterStringFlip
        {
            get { return _filterStringFlip; }
            set
            {
                _filterStringFlip = value;
                RaisePropertyChanged("FilterStringFlip");
                FlipCollection();
            }
        }
        public bool FlipFilter(object obj)
        {
            var data = obj as LOG_T001_A_FLIP;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringFlip))
                {
                    return (data.delivery_no != null && data.delivery_no.ToLower().Contains(_filterStringFlip.ToLower())) ||
                           (data.delivery_date != null && data.delivery_date.ToString().ToLower().Contains(_filterStringFlip.ToLower())) ||
                           (data.soldpartynm != null && data.soldpartynm.ToString().ToLower().Contains(_filterStringFlip.ToLower())) ||
                           (data.order_no != null && data.order_no.ToLower().Contains(_filterStringFlip.ToLower())) ||
                           (data.t_status != null && data.t_status.ToLower().Contains(_filterStringFlip.ToLower())) ||
                           (data.del_desc != null && data.del_desc.ToLower().Contains(_filterStringFlip.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Make
        private string _filterStringMake;
        private void FilterCollectionMake()
        {
            if (_MakeCollection != null)
            {
                _MakeCollection.Refresh();
            }
        }
        public string FilterStringMake
        {
            get { return _filterStringMake; }
            set
            {
                _filterStringMake = value;
                RaisePropertyChanged("FilterStringMake");
                FilterCollectionMake();
            }
        }
        public bool FilterMake(object obj)
        {
            var data = obj as ADM_M030_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMake))
                {
                    return data.parametervalue != null && data.parametervalue.ToString().ToLower().Contains(_filterStringMake.ToLower());
                }
                return true;
            }
            return false;
        }

        

        #endregion

        #endregion
    }
}
