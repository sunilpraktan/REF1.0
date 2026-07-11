using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.CustomerRelation;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Reflection.ReportingServices;
using System.Collections;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.Presentation.Common;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class MIS_CRM_Sales6_VM : WorkspaceViewModel<MIS_SalesReport6>
    {
        #region Declaration

        bool blNew = true;
        WebServiceRepository<MultipleContext_MIS_CRM_Sales6> repository_MC = new WebServiceRepository<MultipleContext_MIS_CRM_Sales6>();
        ObjectSerializationService obj = new ObjectSerializationService();
        WebServiceRepository<List<MIS_CRM_SalesEntity6>> repository = new WebServiceRepository<List<MIS_CRM_SalesEntity6>>();
        MultipleContext_MIS_CRM_Sales6 _MC = new MultipleContext_MIS_CRM_Sales6();
        public MultipleContext_MIS_CRM_Sales6 MC
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
        private MIS_SalesReport6 _ReportParametersEntity;
        public MIS_SalesReport6 ReportParametersEntity
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

        private List<MIS_CRM_SalesEntity6> _dsReport;
        public List<MIS_CRM_SalesEntity6> dsReport
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

        #region Dictionary

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

        private Dictionary<string, string> _DocumentDictionary;
        public Dictionary<string, string> DocumentDictionary
        {
            get { return _DocumentDictionary; }
            set
            {
                if (_DocumentDictionary != value)
                {
                    _DocumentDictionary = value;
                    RaisePropertyChanged("DocumentDictionary");
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

        private Dictionary<string, string> _OrderByDictionary;
        public Dictionary<string, string> OrderByDictionary
        {
            get { return _OrderByDictionary; }
            set
            {
                if (_OrderByDictionary != value)
                {
                    _OrderByDictionary = value;
                    RaisePropertyChanged("OrderByDictionary");
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

        private Dictionary<string, object> _DocumentDictionaryParent;
        public Dictionary<string, object> DocumentDictionaryParent
        {
            get { return _DocumentDictionaryParent; }
            set
            {
                if (_DocumentDictionaryParent != value)
                {
                    _DocumentDictionaryParent = value;
                    RaisePropertyChanged("DocumentDictionaryParent");
                }
            }
        }
        private Dictionary<string, object> _DocumentDictionaryType;
        public Dictionary<string, object> DocumentDictionaryType
        {
            get { return _DocumentDictionaryType; }
            set
            {
                if (_DocumentDictionaryType != value)
                {
                    _DocumentDictionaryType = value;
                    RaisePropertyChanged("DocumentDictionaryType");
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

        private Dictionary<string, string> _SalesTyDictionary;
        public Dictionary<string, string> SalesTyDictionary
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

        private Dictionary<string, string> _AccountTyDictionary;
        public Dictionary<string, string> AccountTyDictionary
        {
            get { return _AccountTyDictionary; }
            set
            {
                if (_AccountTyDictionary != value)
                {
                    _AccountTyDictionary = value;
                    RaisePropertyChanged("AccountTyDictionary");
                }
            }
        }

        private Dictionary<string, object> _SaleDictionary;
        public Dictionary<string, object> SaleDictionary
        {
            get { return _SaleDictionary; }
            set
            {
                if (_SaleDictionary != value)
                {
                    _SaleDictionary = value;
                    RaisePropertyChanged("SaleDictionary");
                }
            }
        }
        //private Dictionary<string, object> _Trade_TypesDictionaryParent;
        //public Dictionary<string, object> Trade_TypesDictionaryParent
        //{
        //    get { return _Trade_TypesDictionaryParent; }
        //    set
        //    {
        //        if (_Trade_TypesDictionaryParent != value)
        //        {
        //            _Trade_TypesDictionaryParent = value;
        //            RaisePropertyChanged("Trade_TypesDictionaryParent");
        //        }
        //    }
        //}
        #endregion


        #region ICollection

        private ICollectionView _PartyCollection;
        public ICollectionView PartyCollection
        {
            get { return _PartyCollection; }
            set { _PartyCollection = value; RaisePropertyChanged("PartyCollevtion"); }
        }

        private ICollectionView _ItemsCollection;
        public ICollectionView ItemsCollection
        {
            get { return _ItemsCollection; }
            set { _ItemsCollection = value; RaisePropertyChanged("ItemsCollection"); }
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
            set
            {
                _PlantCollection = value;
                RaisePropertyChanged("PlantCollection");
            }
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
        private ICollectionView _Trade_TypesCollection;
        public ICollectionView Trade_TypesCollection
        {
            get { return _Trade_TypesCollection; }
            set
            {
                _Trade_TypesCollection = value;
                RaisePropertyChanged("Trade_TypesCollection");
            }
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

        private List<string> _strListPlant;
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

        private List<SYS_M001_P> _strListDocument;
        public List<SYS_M001_P> strListDocument
        {
            get { return _strListDocument; }
            set
            {
                if (_strListDocument != value)
                {
                    _strListDocument = value;
                    RaisePropertyChanged("_strListDocument");
                }
            }
        }
        private List<SYS_M002_P> _strListDocumentType;
        public List<SYS_M002_P> strListDocumentType
        {
            get { return _strListDocumentType; }
            set
            {
                if (_strListDocumentType != value)
                {
                    _strListDocumentType = value;
                    RaisePropertyChanged("strListDocumentType");
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

        private List<SEL_T003_P> _strListSalesTy;
        public List<SEL_T003_P> strListSalesTy
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

        private List<SEL_T003_P> _strListAccountTy;
        public List<SEL_T003_P> strListAccountTy
        {
            get { return _strListAccountTy; }
            set
            {
                if (_strListAccountTy != value)
                {
                    _strListAccountTy = value;
                    RaisePropertyChanged("strListAccountTy");
                }
            }
        }

        private List<SEL_T003_P> _strListSale;
        public List<SEL_T003_P> strListSale
        {
            get { return _strListSale; }
            set
            {
                if (_strListSale != value)
                {
                    _strListSale = value;
                    RaisePropertyChanged("strListSale");
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

        #endregion

        #region RelayCommands      
        public RelayCommand cmdReport { get; private set; }
        public RelayCommand<object> cmdCompanyChange { get; private set; }
        public RelayCommand<object> cmdPartyChange { get; private set; }
        public RelayCommand<object> cmdItemChange { get; private set; }
        public RelayCommand<object> cmdUnitChange { get; private set; }
        public RelayCommand<object> cmdPlantChange { get; private set; }
        public RelayCommand CommandForClearData { get; private set; }

        #endregion

        #region Constructor
        public MIS_CRM_Sales6_VM()
            : base()
        {
            CursorControl.SetBusyState();
            MC = new MultipleContext_MIS_CRM_Sales6();
            ReportParametersEntity = new MIS_SalesReport6();
            _dsReport = new List<MIS_CRM_SalesEntity6>();
            ReportItemsDictionary = new Dictionary<string, string>();

            ReportItemsDictionary.Add("R001", "Party Wise Sales Statement Group by Product");
            ReportItemsDictionary.Add("R013", "Item Wise Sales Statement Group by Product");
            ReportItemsDictionary.Add("R002", "Party Wise Sales");
            ReportItemsDictionary.Add("R003", "Item Wise Stock Transfer Statement");
            ReportItemsDictionary.Add("R004", "Debit /Credit By Party");
            ReportItemsDictionary.Add("R005", "Sales Return To Company By Party");
            ReportItemsDictionary.Add("R006", "Invoice Wise Sales Report");
            ReportItemsDictionary.Add("R007", "Consignee Sales Report");
            ReportItemsDictionary.Add("R008", "Total Sale Statement");
            ReportItemsDictionary.Add("R009", "Item Wise Sales Statement(Details Report)");
            ReportItemsDictionary.Add("R010", "Item Wise Sales Statement(Local Report)");
            ReportItemsDictionary.Add("R011", "Party Wise Sales Statement(Details Report)");
            ReportItemsDictionary.Add("R012", "Party Wise Sales Statement(Local Report)");
            ReportItemsDictionary.Add("R014", "Date wise Transporter Details");
            ReportItemsDictionary.Add("R015", "Item Wise Sales Register");
            ReportItemsDictionary.Add("R016", "Sales According To Transporter Report");
            ReportItemsDictionary.Add("R017", "Pending Sales Order (Local)");
            ReportItemsDictionary.Add("R018", "Stock Report (Carton wise)");
            ReportItemsDictionary.Add("R019", "Pending Sales Order Statement");
            ReportItemsDictionary.Add("R020", "Pending Production Statement");
            ReportItemsDictionary.Add("R021", "Pending Batch Statement");
            ReportItemsDictionary.Add("R022", "Partywise Sales Statistics");
            ReportItemsDictionary.Add("R023", "Partywise-Itemwise Sales Statistics");
            ReportItemsDictionary.Add("R024", "Customerwise Sales Statistics Group by Wire Type");
            ReportItemsDictionary.Add("R025", "Sales Statistics Summary");
            ReportItemsDictionary.Add("R026", "SRF Summary");
            ReportItemsDictionary.Add("R027", "Rate Chart");
            ReportItemsDictionary.Add("R028", "QFR Summary");
            ReportItemsDictionary.Add("R029", "BATCH ILD");

            AccountTyDictionary = new Dictionary<string, string>();
            AccountTyDictionary.Add("A01", "All");
            AccountTyDictionary.Add("A02", "Self");
            AccountTyDictionary.Add("A03", "Trading");

            SalesTyDictionary = new Dictionary<string, string>();
            SalesTyDictionary.Add("S01", "All");
            SalesTyDictionary.Add("S02", "Local");
            SalesTyDictionary.Add("S03", "Export");
            SalesTyDictionary.Add("S04", "Consignee");
            SalesTyDictionary.Add("S05", "Domestic");

            SalesDictionary = new Dictionary<string, string>();
            SalesDictionary.Add("C01", "All");
            SalesDictionary.Add("C02", "FREE SAMPLE");
            SalesDictionary.Add("C03", "SALE");

            TipTypeDictionary = new Dictionary<string, string>();
            TipTypeDictionary.Add("T01", "OBI");
            TipTypeDictionary.Add("T02", "GBI");
            TipTypeDictionary.Add("T03", "All");

            OrderByDictionary = new Dictionary<string, string>();
            OrderByDictionary.Add("01", "ItemWise");
            OrderByDictionary.Add("02", "PartyWise");

            BlankDictionary = new Dictionary<string, string>();
            BlankDictionary.Add("B01", "All");
            BlankDictionary.Add("B02", "Yes");
            BlankDictionary.Add("B03", "No");

            cmdPartyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items, blNew); });
            cmdCompanyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            cmdPlantChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
            cmdUnitChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertUnit(items); });
            cmdItemChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
            CommandForClearData = new RelayCommand(ClearData);

            cmdReport = new RelayCommand(DisplayReport);

            DefaultValues();
            LoadInitialData();

        }


        private void InsertParty(object items, bool blNew, object sender)
        {
            throw new NotImplementedException();
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


        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MIS_CRM_Sales6>(MC, Request, "MIS_CRM_SalesReport6", "CRM", "LoadAll", 0, "");


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
                                      where o.wire_type_id.ToString() != null
                                      select o).ToList();
                _strListWireTy = WireListParent;
                WireTyDictionaryParent = _strListWireTy.ToDictionary(X => X.wire_type_id.ToString(), X => (object)X.wire_type);



                //BallType
                var BallTyListParent = (from o in MC.BallTypeDetails
                                        where o.ball_type_id.ToString() != null
                                        select o).ToList();
                _strListBallTy = BallTyListParent;
                BallTyDictionaryParent = _strListBallTy.ToDictionary(X => X.ball_type_id.ToString(), X => (object)X.ball_type);

                //ILD
                var ILDListParent = (from o in MC.ILDDetails
                                     where o.ild != null
                                     select o).ToList();
                _strListILD = ILDListParent;
                ILDDictionaryParent = _strListILD.ToDictionary(X => X.ild.ToString(), X => (object)X.ild);

                //Document Cat
                var DocumentListParent = (from o in MC.DocumentCategory
                                          where o.doc_cat.ToString() != null
                                          select o).ToList();
                _strListDocument = DocumentListParent;
                DocumentDictionaryParent = _strListDocument.ToDictionary(X => X.doc_cat.ToString(), X => (object)X.doc_cat);


                var DocumentListType = (from o in MC.DocumentTypes
                                        where o.doc_type.ToString() != null
                                        select o).ToList();
                _strListDocumentType = DocumentListType;
                DocumentDictionaryType = _strListDocumentType.ToDictionary(X => X.doc_type.ToString(), X => (object)X.doc_type);

                //Ink
                var InkListParent = (from o in MC.InkDetails
                                     where o.ink.ToString() != null
                                     select o).ToList();
                _strListInk = InkListParent;
                InkDictionaryParent = _strListInk.ToDictionary(X => X.ink.ToString(), X => (object)X.ink);


                //Form Type or tax Master
                var FormTyListParent = (from o in MC.FormTyDetails
                                        where o.id.ToString() != null
                                        select o).ToList();
                _strListFormTy = FormTyListParent;
                FormTyDictionary = _strListFormTy.ToDictionary(X => X.id.ToString(), X => (object)X.description);

                //so Code
                SalesOrganisationList = (List<ADM_M001_A_P>)AppSessionState.ADM_M001_A_List;
                Salse_OrgCollection = CollectionViewSource.GetDefaultView(SalesOrganisationList);
                Salse_OrgCollection.Filter = new Predicate<object>(Filter_SalesOrg);
                StringListSalesOrg = SalesOrganisationList.Select(x => x.so_code).ToList();
                if (SalesOrganisationList.Count != 0)
                {
                    if (SalesOrganisationList.Count == 1)
                    {
                        ReportParametersEntity.so_code = SalesOrganisationList[0].so_code;
                        ReportParametersEntity.sales_org = SalesOrganisationList[0].sales_org;
                    }
                }
                else
                {
                    ReportParametersEntity.so_code = "";
                }

                //Sg Code
                SalesGroupList = (List<ADM_M001_H_P>)AppSessionState.ADM_M001_H_List;
                Salse_GroupCollection = CollectionViewSource.GetDefaultView(SalesGroupList);
                Salse_GroupCollection.Filter = new Predicate<object>(Filter_SalesGroup);
                StringListSalesGroup = SalesGroupList.Select(x => x.sg_code).ToList();

                if (SalesGroupList.Count != 0)
                {
                    if (SalesGroupList.Count == 1)
                    {
                        ReportParametersEntity.sg_code = SalesGroupList[0].sg_code;
                        ReportParametersEntity.sg_name = SalesGroupList[0].sg_name;
                    }
                }
                else
                {
                    ReportParametersEntity.sg_code = "";
                }

                //Trade Types
                Trade_TypesCollection = CollectionViewSource.GetDefaultView(MC.Trade_Types);
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
            ReportParametersEntity.doc_cat = "SI,EI";


            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            ReportParametersEntity.FromDate = lastDayLastMonth.AddDays(0);
            ReportParametersEntity.ToDate = DateTime.Now;
        }
        private void ClearData()
        {
            try
            {
                ReportParametersEntity = new MIS_SalesReport6();
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

                if (ReportParametersEntity.ReportCode == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Report Type");
                    showMessageService.ShowMessage();
                }

                //Check if Fields are not Selected then assign it to 'All'.
                if (ReportParametersEntity.ReportCode != null)
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
                    if (ReportParametersEntity.SubCatName == null) { ReportParametersEntity.SubCatName = "All"; }
                    if (ReportParametersEntity.TipType == null) { ReportParametersEntity.TipType = "All"; }
                    if (ReportParametersEntity.grade_code == null) { ReportParametersEntity.grade_code = "All"; }
                    if (ReportParametersEntity.ind_trade == null) { ReportParametersEntity.ind_trade = "All"; }
                    if (ReportParametersEntity.description == null) { ReportParametersEntity.description = "All"; }
                    if (ReportParametersEntity.wire_type == null) { ReportParametersEntity.wire_type = "All"; }
                    //if (ReportParametersEntity.wire_type_id == null) { ReportParametersEntity.wire_type_id = 0; }
                    if (ReportParametersEntity.ball_type == null) { ReportParametersEntity.ball_type = "All"; }
                    if (ReportParametersEntity.ild == null) { ReportParametersEntity.ild = "All"; }
                    if (ReportParametersEntity.ink == null) { ReportParametersEntity.ink = "All"; }
                    if (ReportParametersEntity.SalesAccount == null) { ReportParametersEntity.SalesAccount = "All"; }
                    if (ReportParametersEntity.Blank == null) { ReportParametersEntity.Blank = "All"; }
                    if (ReportParametersEntity.para7 == null) { ReportParametersEntity.para7 = "All"; }
                    if (ReportParametersEntity.doc_cat == null) { ReportParametersEntity.doc_cat = "All"; }
                    if (ReportParametersEntity.doc_type == null) { ReportParametersEntity.doc_type = "All"; }

                    //if (ReportParametersEntity.unit_code == null) { ReportParametersEntity.unit_code = "All"; }
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

                    if (ReportParametersEntity.ReportCode == "R022")
                    {
                        string RequestParameter = "Report" + "!@" + ReportParametersEntity.ReportCode + "!@" + ReportParametersEntity.ItemCode + "!@" + ReportParametersEntity.PartyId + "!@" + ReportParametersEntity.location_Id + "!@" + ReportParametersEntity.comp_code + "!@" + Convert.ToDateTime(ReportParametersEntity.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParametersEntity.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParametersEntity.ind_trade + "!@" + ReportParametersEntity.unit_code + "!@" + ReportParametersEntity.SalesAccount + "!@" + ReportParametersEntity.CatCode + "!@" + ReportParametersEntity.SubCatCode + "!@" + ReportParametersEntity.ItemTypeCd + "!@" + ReportParametersEntity.SubItemTpCd + "!@" + ReportParametersEntity.id + "!@" + ReportParametersEntity.grade_code + "!@" + ReportParametersEntity.TipType + "!@" + ReportParametersEntity.wire_type + "!@" + ReportParametersEntity.ball_type + "!@" + ReportParametersEntity.ild + "!@" + ReportParametersEntity.ink + "!@" + ReportParametersEntity.Blank + "!@" + ReportParametersEntity.para7 + "!@" + ReportParametersEntity.doc_cat + "!@" + ReportParametersEntity.active1 + "!@" + ReportParametersEntity.doc_type;
                        dsReport = repository.GetDataWithReturnDomainObject<List<MIS_CRM_SalesEntity6>>(dsReport, RequestParameter, "MIS_CRM_SalesReport6", "CRM", "", 0, RequestParameter);

                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        objDataSource[0] = dsReport;

                        List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                        var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == ReportParametersEntity.comp_code).ToList();
                        objDataSource[1] = CmpResult;

                        List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                        var Result = TempList.Where(loc => loc.location_Id == ReportParametersEntity.location_Id).ToList();
                        objDataSource[2] = Result;


                        objDataSourceName[0] = "dsMIS_CRM_SalesEntity6";
                        objDataSourceName[1] = "dsCompany";
                        objDataSourceName[2] = "dsLocation";

                        if (ReportParametersEntity.wire_type == "1") { ReportParametersEntity.ItemCode = "BNP"; }
                        if (ReportParametersEntity.wire_type == "5") { ReportParametersEntity.ItemCode = "NS"; }
                        if (ReportParametersEntity.wire_type == "7") { ReportParametersEntity.ItemCode = "SS"; }
                        if (ReportParametersEntity.wire_type == "1,3") { ReportParametersEntity.ItemCode = "BNP,Brass"; }
                        if (ReportParametersEntity.wire_type == "3") { ReportParametersEntity.ItemCode = "BRASS"; }

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\CRM\\" + GetReportFile(ReportParametersEntity.ReportCode), getParametersList(), "");

                    }

                    else if (ReportParametersEntity.ReportCode == "R023")
                    {
                        string RequestParameter = "Report" + "!@" + ReportParametersEntity.ReportCode + "!@" + ReportParametersEntity.ItemCode + "!@" + ReportParametersEntity.PartyId + "!@" + ReportParametersEntity.location_Id + "!@" + ReportParametersEntity.comp_code + "!@" + Convert.ToDateTime(ReportParametersEntity.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParametersEntity.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParametersEntity.ind_trade + "!@" + ReportParametersEntity.unit_code + "!@" + ReportParametersEntity.SalesAccount + "!@" + ReportParametersEntity.CatCode + "!@" + ReportParametersEntity.SubCatCode + "!@" + ReportParametersEntity.ItemTypeCd + "!@" + ReportParametersEntity.SubItemTpCd + "!@" + ReportParametersEntity.id + "!@" + ReportParametersEntity.grade_code + "!@" + ReportParametersEntity.TipType + "!@" + ReportParametersEntity.wire_type + "!@" + ReportParametersEntity.ball_type + "!@" + ReportParametersEntity.ild + "!@" + ReportParametersEntity.ink + "!@" + ReportParametersEntity.Blank + "!@" + ReportParametersEntity.para7 + "!@" + ReportParametersEntity.doc_cat + "!@" + ReportParametersEntity.active1 + "!@" + ReportParametersEntity.doc_type;
                        dsReport = repository.GetDataWithReturnDomainObject<List<MIS_CRM_SalesEntity6>>(dsReport, RequestParameter, "MIS_CRM_SalesReport6", "CRM", "", 0, RequestParameter);

                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        objDataSource[0] = dsReport;

                        List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                        var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == ReportParametersEntity.comp_code).ToList();
                        objDataSource[1] = CmpResult;

                        List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                        var Result = TempList.Where(loc => loc.location_Id == ReportParametersEntity.location_Id).ToList();
                        objDataSource[2] = Result;


                        objDataSourceName[0] = "dsMIS_CRM_SalesEntity6";
                        objDataSourceName[1] = "dsCompany";
                        objDataSourceName[2] = "dsLocation";


                        //For wire type display purpose
                        if (ReportParametersEntity.wire_type == "1") { ReportParametersEntity.ItemCode = "BNP"; }
                        if (ReportParametersEntity.wire_type == "5") { ReportParametersEntity.ItemCode = "NS"; }
                        if (ReportParametersEntity.wire_type == "7") { ReportParametersEntity.ItemCode = "SS"; }
                        if (ReportParametersEntity.wire_type == "1,3") { ReportParametersEntity.ItemCode = "BNP,Brass"; }
                        if (ReportParametersEntity.wire_type == "3") { ReportParametersEntity.ItemCode = "BRASS"; }


                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\CRM\\" + GetReportFile(ReportParametersEntity.ReportCode), getParametersList(), "");

                    }

                    else
                    {
                        string RequestParameter = "Report" + "!@" + ReportParametersEntity.ReportCode + "!@" + ReportParametersEntity.ItemCode + "!@" + ReportParametersEntity.PartyId + "!@" + ReportParametersEntity.location_Id + "!@" + ReportParametersEntity.comp_code + "!@" + Convert.ToDateTime(ReportParametersEntity.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParametersEntity.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParametersEntity.ind_trade + "!@" + ReportParametersEntity.unit_code + "!@" + ReportParametersEntity.SalesAccount + "!@" + ReportParametersEntity.CatCode + "!@" + ReportParametersEntity.SubCatCode + "!@" + ReportParametersEntity.ItemTypeCd + "!@" + ReportParametersEntity.SubItemTpCd + "!@" + ReportParametersEntity.id + "!@" + ReportParametersEntity.grade_code + "!@" + ReportParametersEntity.TipType + "!@" + ReportParametersEntity.wire_type + "!@" + ReportParametersEntity.ball_type + "!@" + ReportParametersEntity.ild + "!@" + ReportParametersEntity.ink + "!@" + ReportParametersEntity.Blank + "!@" + ReportParametersEntity.para7 + "!@" + ReportParametersEntity.doc_cat + "!@" + ReportParametersEntity.active1 + "!@" + ReportParametersEntity.doc_type;
                        dsReport = repository.GetDataWithReturnDomainObject<List<MIS_CRM_SalesEntity6>>(dsReport, RequestParameter, "MIS_CRM_SalesReport6", "CRM", "", 0, RequestParameter);

                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        objDataSource[0] = dsReport;

                        List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                        var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == ReportParametersEntity.comp_code).ToList();
                        objDataSource[1] = CmpResult;

                        List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                        var Result = TempList.Where(loc => loc.location_Id == ReportParametersEntity.location_Id).ToList();
                        objDataSource[2] = Result;


                        objDataSourceName[0] = "dsMIS_CRM_SalesEntity6";
                        objDataSourceName[1] = "dsCompany";
                        objDataSourceName[2] = "dsLocation";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\CRM\\" + GetReportFile(ReportParametersEntity.ReportCode), getParametersList(), "");

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
                if (ReportParametersEntity.ReportCode == "R018")
                {
                    result.Add("FromDate", Convert.ToString(ReportParametersEntity.FromDate));
                    result.Add("ToDate", Convert.ToString(ReportParametersEntity.ToDate));
                    result.Add("PartyId", ReportParametersEntity.PartyId);
                    result.Add("PartyNm", ReportParametersEntity.PartyNm);
                    result.Add("comp_code", ReportParametersEntity.comp_code);
                    result.Add("location_Id", ReportParametersEntity.location_Id);
                    result.Add("ReportName", ReportParametersEntity.ReportName);
                    result.Add("ItemCode", ReportParametersEntity.ItemCode);
                    result.Add("ItemName", ReportParametersEntity.ItemName);
                    result.Add("unit_code", ReportParametersEntity.unit_code);
                    result.Add("PrintDate", DateTime.Now.ToShortDateString());
                    result.Add("local_export", ReportParametersEntity.ind_trade);
                }
                else if (ReportParametersEntity.ReportCode == "R019")
                {
                    result.Add("ReportName", ReportParametersEntity.ReportName);
                    result.Add("unit_code", ReportParametersEntity.unit_code);
                    result.Add("PrintDate", DateTime.Now.ToShortDateString());
                    result.Add("local_export", ReportParametersEntity.ind_trade);
                }
                else if (ReportParametersEntity.ReportCode == "R020")
                {
                    result.Add("ReportName", ReportParametersEntity.ReportName);
                    result.Add("unit_code", ReportParametersEntity.unit_code);
                    result.Add("PrintDate", DateTime.Now.ToShortDateString());
                    result.Add("local_export", ReportParametersEntity.ind_trade);
                }
                else if (ReportParametersEntity.ReportCode == "R021")
                {
                    result.Add("FromDate", Convert.ToString(ReportParametersEntity.FromDate));
                    result.Add("ToDate", Convert.ToString(ReportParametersEntity.ToDate));
                    result.Add("PartyId", ReportParametersEntity.PartyId);
                    result.Add("PartyNm", ReportParametersEntity.PartyNm);
                    result.Add("comp_code", ReportParametersEntity.comp_code);
                    result.Add("location_Id", ReportParametersEntity.location_Id);
                    result.Add("ReportName", ReportParametersEntity.ReportName);
                    result.Add("ItemCode", ReportParametersEntity.ItemCode);
                    result.Add("ItemName", ReportParametersEntity.ItemName);
                    result.Add("unit_code", ReportParametersEntity.unit_code);
                    result.Add("PrintDate", DateTime.Now.ToShortDateString());
                }
                else if (ReportParametersEntity.ReportCode == "R022")
                {
                    result.Add("FromDate", Convert.ToString(ReportParametersEntity.FromDate));
                    result.Add("ToDate", Convert.ToString(ReportParametersEntity.ToDate));
                    result.Add("PartyId", ReportParametersEntity.PartyId);
                    result.Add("PartyNm", ReportParametersEntity.PartyNm);
                    result.Add("comp_code", ReportParametersEntity.comp_code);
                    result.Add("location_Id", ReportParametersEntity.location_Id);
                    result.Add("ReportName", ReportParametersEntity.ReportName);
                    result.Add("ItemCode", ReportParametersEntity.ItemCode);
                    result.Add("ItemName", ReportParametersEntity.ItemName);
                    result.Add("unit_code", ReportParametersEntity.unit_code);
                    result.Add("PrintDate", DateTime.Now.ToShortDateString());
                    result.Add("wire_type", ReportParametersEntity.wire_type);
                    result.Add("local_export", ReportParametersEntity.ind_trade);
                }
                else if (ReportParametersEntity.ReportCode == "R023")
                {
                    result.Add("FromDate", Convert.ToString(ReportParametersEntity.FromDate));
                    result.Add("ToDate", Convert.ToString(ReportParametersEntity.ToDate));
                    result.Add("PartyId", ReportParametersEntity.PartyId);
                    result.Add("PartyNm", ReportParametersEntity.PartyNm);
                    result.Add("comp_code", ReportParametersEntity.comp_code);
                    result.Add("location_Id", ReportParametersEntity.location_Id);
                    result.Add("ReportName", ReportParametersEntity.ReportName);
                    result.Add("ItemCode", ReportParametersEntity.ItemCode);
                    result.Add("ItemName", ReportParametersEntity.ItemName);
                    result.Add("unit_code", ReportParametersEntity.unit_code);
                    result.Add("PrintDate", DateTime.Now.ToShortDateString());
                    result.Add("wire_type", ReportParametersEntity.wire_type);
                    result.Add("local_export", ReportParametersEntity.ind_trade);
                }
                else if (ReportParametersEntity.ReportCode == "R024")
                {
                    result.Add("FromDate", Convert.ToString(ReportParametersEntity.FromDate));
                    result.Add("ToDate", Convert.ToString(ReportParametersEntity.ToDate));
                    result.Add("PartyId", ReportParametersEntity.PartyId);
                    result.Add("PartyNm", ReportParametersEntity.PartyNm);
                    result.Add("comp_code", ReportParametersEntity.comp_code);
                    result.Add("location_Id", ReportParametersEntity.location_Id);
                    result.Add("ReportName", ReportParametersEntity.ReportName);
                    result.Add("ItemCode", ReportParametersEntity.ItemCode);
                    result.Add("ItemName", ReportParametersEntity.ItemName);
                    result.Add("unit_code", ReportParametersEntity.unit_code);
                    result.Add("PrintDate", DateTime.Now.ToShortDateString());
                    result.Add("wire_type", ReportParametersEntity.wire_type);
                    result.Add("local_export", ReportParametersEntity.ind_trade);
                }

                else if (ReportParametersEntity.ReportCode == "R025")
                {
                    result.Add("FromDate", Convert.ToString(ReportParametersEntity.FromDate));
                    result.Add("ToDate", Convert.ToString(ReportParametersEntity.ToDate));
                    result.Add("PartyId", ReportParametersEntity.PartyId);
                    result.Add("PartyNm", ReportParametersEntity.PartyNm);
                    result.Add("comp_code", ReportParametersEntity.comp_code);
                    result.Add("location_Id", ReportParametersEntity.location_Id);
                    result.Add("ReportName", ReportParametersEntity.ReportName);
                    result.Add("ItemCode", ReportParametersEntity.ItemCode);
                    result.Add("ItemName", ReportParametersEntity.ItemName);
                    result.Add("unit_code", ReportParametersEntity.unit_code);
                    result.Add("PrintDate", DateTime.Now.ToShortDateString());
                    result.Add("wire_type", ReportParametersEntity.wire_type);
                    result.Add("local_export", ReportParametersEntity.ind_trade);
                }
                else if (ReportParametersEntity.ReportCode == "R026" || ReportParametersEntity.ReportCode == "R028")
                {
                    result.Add("FromDate", Convert.ToString(ReportParametersEntity.FromDate));
                    result.Add("ToDate", Convert.ToString(ReportParametersEntity.ToDate));
                    result.Add("PartyId", ReportParametersEntity.PartyId);
                    result.Add("PartyNm", ReportParametersEntity.PartyNm);
                    result.Add("comp_code", ReportParametersEntity.comp_code);
                    result.Add("location_Id", ReportParametersEntity.location_Id);
                    result.Add("ReportName", ReportParametersEntity.ReportName);
                    result.Add("ItemCode", ReportParametersEntity.ItemCode);
                    result.Add("ItemName", ReportParametersEntity.ItemName);
                    result.Add("unit_code", ReportParametersEntity.unit_code);
                    result.Add("PrintDate", DateTime.Now.ToShortDateString());
                    result.Add("wire_type", ReportParametersEntity.wire_type);
                    result.Add("local_export", ReportParametersEntity.ind_trade);
                }
                else if (ReportParametersEntity.ReportCode == "R027")
                {
                    result.Add("FromDate", Convert.ToString(ReportParametersEntity.FromDate));
                    result.Add("ToDate", Convert.ToString(ReportParametersEntity.ToDate));
                    result.Add("PartyId", ReportParametersEntity.PartyId);
                    result.Add("PartyNm", ReportParametersEntity.PartyNm);
                    result.Add("comp_code", ReportParametersEntity.comp_code);
                    result.Add("location_Id", ReportParametersEntity.location_Id);
                    result.Add("ReportName", ReportParametersEntity.ReportName);
                    result.Add("ItemCode", ReportParametersEntity.ItemCode);
                    result.Add("ItemName", ReportParametersEntity.ItemName);
                    result.Add("unit_code", ReportParametersEntity.unit_code);
                    result.Add("PrintDate", DateTime.Now.ToShortDateString());
                    result.Add("wire_type", ReportParametersEntity.wire_type);
                    result.Add("local_export", ReportParametersEntity.ind_trade);
                }
                else if (ReportParametersEntity.ReportCode == "R029")
                {
                    result.Add("FromDate", Convert.ToString(ReportParametersEntity.FromDate));
                    result.Add("ToDate", Convert.ToString(ReportParametersEntity.ToDate));
                    result.Add("PartyId", ReportParametersEntity.PartyId);
                    result.Add("PartyNm", ReportParametersEntity.PartyNm);
                    result.Add("comp_code", ReportParametersEntity.comp_code);
                    result.Add("location_Id", ReportParametersEntity.location_Id);
                    result.Add("ReportName", ReportParametersEntity.ReportName);
                    result.Add("ItemCode", ReportParametersEntity.ItemCode);
                    result.Add("ItemName", ReportParametersEntity.ItemName);
                    result.Add("unit_code", ReportParametersEntity.unit_code);
                    result.Add("PrintDate", DateTime.Now.ToShortDateString());
                    result.Add("wire_type", ReportParametersEntity.wire_type);
                    result.Add("local_export", ReportParametersEntity.ind_trade);
                }
                else
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
                    result.Add("local_export", ReportParametersEntity.ind_trade);
                    result.Add("para7", ReportParametersEntity.para7);
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
            return result;
        }
        private string GetReportFile(string ReportCode)
        {
            string returnReportName = "";

            if (ReportCode == "R001")
            {
                returnReportName = "SalesReport.rdlc";
            }
            else if (ReportCode == "R002")
            {
                returnReportName = "ItemWiseSalesRpt.rdlc";
            }
            else if (ReportCode == "R003")
            {
                returnReportName = "ItemWiseStockTransferStatement.rdlc";
            }
            else if (ReportCode == "R004")
            {
                returnReportName = "CreditDebitByParty.rdlc";
            }
            else if (ReportCode == "R005")
            {
                returnReportName = "SalesReturn.rdlc";
            }
            else if (ReportCode == "R006")
            {
                returnReportName = "InvoiceWiseSalesReport.rdlc";
            }
            else if (ReportCode == "R007")
            {
                returnReportName = "ItemWiseSalesConsigneeRpt.rdlc";
            }
            else if (ReportCode == "R008")
            {
                returnReportName = "TotalSalesStatementRpt.rdlc.rdlc";
            }
            else if (ReportCode == "R009")
            {
                returnReportName = "ItemwiseSalesStatement(Detail).rdlc";
            }
            else if (ReportCode == "R010")
            {
                returnReportName = "ItemwiseSalesStatement(Local).rdlc";
            }
            else if (ReportCode == "R011")
            {
                returnReportName = "PartywiseSalesStatement(Detail).rdlc";
            }
            else if (ReportCode == "R012")
            {
                returnReportName = "PartywiseSalesStatement(Local).rdlc";
            }
            else if (ReportCode == "R013")
            {
                returnReportName = "ItemWiseSalesStmGrpProd.rdlc";
            }
            else if (ReportCode == "R014")
            {
                returnReportName = "DateWiseTransporter.rdlc";
            }
            else if (ReportCode == "R015")
            {
                returnReportName = "ItemwiseSalesRegister.rdlc";
            }
            else if (ReportCode == "R016")
            {
                returnReportName = "TransporterReport.rdlc";
            }
            else if (ReportCode == "R017")
            {
                returnReportName = "PurchaseOrderLocal.rdlc";
            }
            else if (ReportCode == "R018")
            {
                returnReportName = "CurrentStockFG.rdlc";
            }
            else if (ReportCode == "R019")
            {
                returnReportName = "PendingSalesOrder.rdlc";
            }
            else if (ReportCode == "R020")
            {
                returnReportName = "PendingProductionStatement.rdlc";
            }
            else if (ReportCode == "R021")
            {
                returnReportName = "PendingBatchReport.rdlc";
            }
            else if (ReportCode == "R022")
            {
                returnReportName = "ParywiseSalesStatistics.rdlc";
            }
            else if (ReportCode == "R023")
            {
                returnReportName = "ItemwiseSalesStatistics.rdlc";
            }
            else if (ReportCode == "R024")
            {
                returnReportName = "CustomerwiseSalesStatisticsGrpbyWireType.rdlc";
            }
            else if (ReportCode == "R025")
            {
                returnReportName = "SalesStatistics.rdlc";
            }
            else if (ReportCode == "R026")
            {
                returnReportName = "SRFSummary.rdlc";
            }
            else if (ReportCode == "R027")
            {
                returnReportName = "RateChart.rdlc";
            }
            else if (ReportCode == "R028")
            {
                returnReportName = "QFRSummary.rdlc";
            }
            else if (ReportCode == "R029")
            {
                returnReportName = "BATCH_ILD.rdlc";
            }


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

        #region Plant Filter
        private string _filterString_plant;
        public string FilterString_plant
        {
            get { return _filterString_plant; }
            set
            {
                _filterString_plant = value;
                RaisePropertyChanged("FilterString_plant");
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
        #endregion

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

        #endregion

        #region . Command Action .
        protected override void OnCreateAction(InquiryActionResult<MIS_SalesReport6> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<MIS_SalesReport6> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<MIS_SalesReport6> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<MIS_SalesReport6> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<MIS_SalesReport6> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<MIS_SalesReport6> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<MIS_SalesReport6> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnSaveAction(InquiryActionResult<MIS_SalesReport6> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_SalesReport6> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_SalesReport6> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_SalesReport6> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_SalesReport6> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_SalesReport6> result)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

