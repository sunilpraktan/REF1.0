using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
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
using Reflection.ReportingServices;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.BusinessEntity.Finance;
using System.Windows.Controls;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ADM;
using System.Threading.Tasks;

namespace Reflection.Modules.SDM.ViewModels
{
    public class SDM_M0014_VM : WorkspaceViewModel<ADM_M028>
    {
        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SDM_M0014_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _ASDefault { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault
        {
            get { return _ASDefault; }
            set
            {
                if (_ASDefault != value)
                {
                    _ASDefault = value; RaisePropertyChanged("ASDefault");
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

        private AutoSuggestTextViewModel<dynamic> _ASBussGroup { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBussGroup
        {
            get { return _ASBussGroup; }
            set
            {
                if (_ASBussGroup != value)
                {
                    _ASBussGroup = value; RaisePropertyChanged("ASBussGroup");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAccountingGroup { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccountingGroup
        {
            get { return _ASAccountingGroup; }
            set
            {
                if (_ASAccountingGroup != value)
                {
                    _ASAccountingGroup = value; RaisePropertyChanged("ASAccountingGroup");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASReconAcc { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASReconAcc
        {
            get { return _ASReconAcc; }
            set
            {
                if (_ASReconAcc != value)
                {
                    _ASReconAcc = value; RaisePropertyChanged("ASReconAcc");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBusinessPlace { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBusinessPlace
        {
            get { return _ASBusinessPlace; }
            set
            {
                if (_ASBusinessPlace != value)
                {
                    _ASBusinessPlace = value; RaisePropertyChanged("ASBusinessPlace");
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
        private AutoSuggestTextViewModel<dynamic> _AS_STATE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_STATE
        {
            get { return _AS_STATE; }
            set
            {
                if (_AS_STATE != value)
                {
                    _AS_STATE = value; RaisePropertyChanged("AS_STATE");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAccGroup { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccGroup
        {
            get { return _ASAccGroup; }
            set
            {
                if (_ASAccGroup != value)
                {
                    _ASAccGroup = value; RaisePropertyChanged("ASAccGroup");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASTaxClass { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTaxClass
        {
            get { return _ASTaxClass; }
            set
            {
                if (_ASTaxClass != value)
                {
                    _ASTaxClass = value; RaisePropertyChanged("ASTaxClass");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBusinessPlace1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBusinessPlace1
        {
            get { return _ASBusinessPlace1; }
            set
            {
                if (_ASBusinessPlace1 != value)
                {
                    _ASBusinessPlace1 = value; RaisePropertyChanged("ASBusinessPlace1");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPayTerms { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPayTerms
        {
            get { return _ASPayTerms; }
            set
            {
                if (_ASPayTerms != value)
                {
                    _ASPayTerms = value; RaisePropertyChanged("ASPayTerms");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASFltrt_Currency { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFltrt_Currency
        {
            get { return _ASFltrt_Currency; }
            set
            {
                if (_ASFltrt_Currency != value)
                {
                    _ASFltrt_Currency = value; RaisePropertyChanged("ASFltrt_Currency");
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
                    if (SourceName == "BussinessPlace")
                    { ASDefault = ASBusinessPlace1; }
                }
            }
        }

        #endregion

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }
        bool isNewRecord = true;
        WebServiceRepository<ADM_M028> repository = new WebServiceRepository<ADM_M028>();
        WebServiceRepository<MultipleContext_ADM_M028> repository_MC = new WebServiceRepository<MultipleContext_ADM_M028>();
        WebServiceRepository<MultipleContext_ADM_M028> repository_MCTemp = new WebServiceRepository<MultipleContext_ADM_M028>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region Declarations
        private MultipleContext_ADM_M028 _MC;
        public MultipleContext_ADM_M028 MC
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

        private MultipleContext_ADM_M028 _MCTemp;
        public MultipleContext_ADM_M028 MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value;
                    RaisePropertyChanged("MCTemp");
                }
            }
        }
        private Dictionary<string, object> _taxDictoneryParent;
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
        //private ObservableCollection<ADM_M028> _TotalDocumentTaxesItem;
        //// Taxes for selected item.
        //public ObservableCollection<ADM_M028> TotalDocumentTaxesItem
        //{
        //    get
        //    {
        //        return _TotalDocumentTaxesItem;
        //    }
        //    set
        //    {
        //        _TotalDocumentTaxesItem = value;
        //        RaisePropertyChanged("TotalDocumentTaxesItem");
        //    }
        //}
        private int _dgSelectedIndexAddress;
        public int dgSelectedIndexAddress
        {
            get
            {
                return _dgSelectedIndexAddress;
            }
            set
            {
                if (_dgSelectedIndexAddress != value)
                {
                    _dgSelectedIndexAddress = value;
                    RaisePropertyChanged("dgSelectedIndexAddress");
                }
            }
        }

        private int _dgSelectedIndexContact;
        public int dgSelectedIndexContact
        {
            get
            {
                return _dgSelectedIndexContact;
            }
            set
            {
                if (_dgSelectedIndexContact != value)
                {
                    _dgSelectedIndexContact = value;
                    RaisePropertyChanged("dgSelectedIndexContact");
                }
            }
        }

        private ADM_M028 _MasterEntity;
        public ADM_M028 MasterEntity
        {
            get
            {
                this.ErrorExist = _MasterEntity.HasErrors;
                return _MasterEntity;
            }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged("MasterEntity");
                }
            }
        }

        private List<ADM_M013_P> _state;
        public List<ADM_M013_P> state
        {
            get { return _state; }
            set
            {
                if (_state != value)
                {
                    _state = value;
                    RaisePropertyChanged("state");
                }
            }
        }

        private List<STD_LIST_BE> _FlipGridData;
        public List<STD_LIST_BE> FlipGridData
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
        private STD_REQ_PARA_BE _REQ_PARA;
        public STD_REQ_PARA_BE REQ_PARA
        {
            get { return _REQ_PARA; }
            set
            {
                if (_REQ_PARA != value)
                {
                    _REQ_PARA = value;

                    RaisePropertyChanged("REQ_PARA");
                }
            }
        }

        private ObservableCollection<ADM_M028_C> _ContactEntity;
        public ObservableCollection<ADM_M028_C> ContactEntity
        {
            get { return _ContactEntity; }
            set
            {
                if (_ContactEntity != value)
                {
                    _ContactEntity = value;
                    RaisePropertyChanged("ContactEntity");
                }
            }
        }

        private ObservableCollection<ADM_M028_D> _AddressEntity;
        public ObservableCollection<ADM_M028_D> AddressEntity
        {
            get { return _AddressEntity; }
            set
            {
                if (_AddressEntity != value)
                {
                    _AddressEntity = value;
                    RaisePropertyChanged("AddressEntity");
                }
            }
        }

        private int _SelectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _SelectedTabControlIndex; }
            set
            {
                if (_SelectedTabControlIndex != value)
                {
                    _SelectedTabControlIndex = value;
                    RaisePropertyChanged("SelectedTabControlIndex");
                }
            }
        }

        #endregion

        #region ICollectionView

        private ICollectionView _CountryCollection;
        public ICollectionView CountryCollection
        {
            get { return _CountryCollection; }
            private set { _CountryCollection = value; RaisePropertyChanged("CountryCollection"); }
        }

        private ICollectionView _StateCollection;
        public ICollectionView StateCollection
        {
            get { return _StateCollection; }
            private set { _StateCollection = value; RaisePropertyChanged("StateCollection"); }
        }

        private ICollectionView _DepartmentCollection;
        public ICollectionView DepartmentCollection
        {
            get { return _DepartmentCollection; }
            private set { _DepartmentCollection = value; RaisePropertyChanged("DepartmentCollection"); }

        }

        private ICollectionView _DesignationCollection;
        public ICollectionView DesignationCollection
        {
            get { return _DesignationCollection; }
            private set { _DesignationCollection = value; RaisePropertyChanged("DesignationCollection"); }

        }

        private ICollectionView _LocationCollection;
        public ICollectionView LocationCollection
        {
            get { return _LocationCollection; }
            set { _LocationCollection = value; RaisePropertyChanged("LocationCollection"); }
        }

        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }

        private ICollectionView _EmployeeCollection;
        public ICollectionView EmployeeCollection
        {
            get { return _EmployeeCollection; }
            set { _EmployeeCollection = value; RaisePropertyChanged("EmployeeCollection"); }
        }

        private ICollectionView _CurrencyCollection;
        public ICollectionView CurrencyCollection
        {
            get { return _CurrencyCollection; }
            set { _CurrencyCollection = value; RaisePropertyChanged("CurrencyCollection"); }
        }

        private ICollectionView _PartyTypeCollection;
        public ICollectionView PartyTypeCollection
        {
            get { return _PartyTypeCollection; }
            set { _PartyTypeCollection = value; RaisePropertyChanged("PartyTypeCollection"); }
        }

        private ICollectionView _GroupCollection;
        public ICollectionView GroupCollection
        {
            get { return _GroupCollection; }
            set { _GroupCollection = value; RaisePropertyChanged("GroupCollection"); }
        }

        private IEnumerable _COUNTRY_COL;
        public IEnumerable COUNTRY_COL
        {
            get { return _COUNTRY_COL; }
            set
            {
                _COUNTRY_COL = value;

                RaisePropertyChanged("COUNTRY_COL");
            }
        }
        private IEnumerable _STATE_COL;
        public IEnumerable STATE_COL
        {
            get { return _STATE_COL; }
            set
            {
                _STATE_COL = value;

                RaisePropertyChanged("STATE_COL");
            }
        }
        private IEnumerable _PARTY_LIST; // Autosuggest while typing asunchroniously
        public IEnumerable PARTY_LIST
        {
            get { return _PARTY_LIST; }
            set
            {
                _PARTY_LIST = value;

                RaisePropertyChanged("PARTY_LIST");
            }
        }
        private IEnumerable _BUSS_TYPE_LIST;
        public IEnumerable BUSS_TYPE_LIST
        {
            get { return _BUSS_TYPE_LIST; }
            set
            {
                _BUSS_TYPE_LIST = value;

                RaisePropertyChanged("BUSS_TYPE_LIST");
            }
        }
        private IEnumerable _BUSS_SCOPE_LIST;
        public IEnumerable BUSS_SCOPE_LIST
        {
            get { return _BUSS_SCOPE_LIST; }
            set
            {
                _BUSS_SCOPE_LIST = value;

                RaisePropertyChanged("BUSS_SCOPE_LIST");
            }
        }
        private IEnumerable _REGION_LIST;
        public IEnumerable REGION_LIST
        {
            get { return _REGION_LIST; }
            set
            {
                _REGION_LIST = value;

                RaisePropertyChanged("REGION_LIST");
            }
        }
        #endregion

        #region StringLists

        List<string> _StringListEmployee;
        public List<string> StringListEmployee
        {
            get { return _StringListEmployee; }
            set
            {
                if (_StringListEmployee != value)
                {
                    _StringListEmployee = value;
                }
            }
        }

        List<string> _StringListLocation;
        public List<string> StringListLocation
        {
            get { return _StringListLocation; }
            set
            {
                if (_StringListLocation != value)
                {
                    _StringListLocation = value;
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

        List<string> _StringListState;
        public List<string> StringListState
        {
            get { return _StringListState; }
            set
            {
                if (_StringListState != value)
                {
                    _StringListState = value;
                }
            }
        }

        List<string> _StringListDepartments;
        public List<string> StringListDepartments
        {
            get { return _StringListDepartments; }
            set
            {
                if (_StringListDepartments != value)
                {
                    _StringListDepartments = value;
                }
            }
        }

        List<string> _StringListDesignations;
        public List<string> StringListDesignations
        {
            get { return _StringListDesignations; }
            set
            {
                if (_StringListDesignations != value)
                {
                    _StringListDesignations = value;
                }
            }
        }

        List<string> _StringListPartyType;
        public List<string> StringListPartyType
        {
            get { return _StringListPartyType; }
            set
            {
                if (_StringListPartyType != value)
                {
                    _StringListPartyType = value;
                }
            }
        }

        List<string> _StringListGroup;
        public List<string> StringListGroup
        {
            get { return _StringListGroup; }
            set
            {
                if (_StringListGroup != value)
                {
                    _StringListGroup = value;
                }
            }
        }
        #endregion

        #region RelayCommand
        //public RelayCommand<object> cmdNameTextChanged { get; private set; }
        //public RelayCommand<object> cmdInsertCompany { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInsertReconAccount { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdAddAccountingGroup { get; private set; }
        public RelayCommand<object> CmdAddBusinessGroup { get; private set; }
        public RelayCommand<object> CmdAddEmployee { get; private set; }
        public RelayCommand<object> CmdAddCountry { get; private set; }
        public RelayCommand<object> CmdAddState { get; private set; }
        public RelayCommand<object> CmdAddGodownLocation { get; private set; }
        public RelayCommand<object> CmdAddCurrency { get; private set; }
        public RelayCommand<object> CmdAddDesignation { get; private set; }
        public RelayCommand<object> CmdAddDepartment { get; private set; }
        public RelayCommand<object> CmdAddPartyType { get; private set; }
        public RelayCommand<object> CmdAddGroup { get; private set; }
        public RelayCommand<object> CmdBusinessPlace { get; private set; }
        public RelayCommand<object> CmdAddAccGroup { get; private set; }
        public RelayCommand<object> CmdAddTaxClass { get; private set; }
        public RelayCommand<object> CmdAddPayTerms { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowAddressEntity { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowContactEntity { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand ExportCommand { get; private set; }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                //string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.client;
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@1!@0";
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M028>(MC, Request, "ADM_M0028_BL", "ADM", "LoadInitialData", 0, "");

                var TaxListParent = (from o in MC.TAX_LIST where o.parent_id == null select o).ToList();
                TaxDictoneryParent = TaxListParent.ToDictionary(X => X.id.ToString(), X => (object)X.description);

                PARTY_LIST = MC.PARTY_LIST;
                BUSS_TYPE_LIST = MC.GROUP_LIST;
                BUSS_SCOPE_LIST = MC.SUB_GROUP_LIST;
                REGION_LIST = MC.REGION_LIST;

                #region .Autosuggest .

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_C_P)x).buss_place ?? "");
                TheFilter = (o, prefix) => (((ADM_M003_C_P)o).buss_place ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003_C_P)o).plc_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.BusinessPlace, TheFilter, SuggestedValue, "buss_place", "buss_place", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_J_P)x).BusinessTyp ?? "");
                TheFilter = (o, prefix) => (((ADM_M028_J_P)o).BusinessTyp ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M028_J_P)o).Name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASBussGroup = new AutoSuggestTextViewModel<dynamic>(MC.BussGroupList, TheFilter, SuggestedValue, "BusinessTyp", "BusinessTyp", true);
                ASBussGroup.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASBussGroup.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_H)x).acc_group);
                TheFilter = (o, prefix) => (((ACC_M003_H)o).acc_group ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_H)o).group_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASAccountingGroup = new AutoSuggestTextViewModel<dynamic>(MC.AccountingGroupList, TheFilter, SuggestedValue, "acc_group", true);
                ASAccountingGroup.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_P)o).gl_name.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                ASReconAcc = new AutoSuggestTextViewModel<dynamic>(MC.ReconAccountList, TheFilter, SuggestedValue, "gl_code", true);
                ASReconAcc.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_C_P)x).buss_place);
                TheFilter = (o, prefix) => (((ADM_M003_C_P)o).buss_place ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003_C_P)o).plc_name.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                ASBusinessPlace = new AutoSuggestTextViewModel<dynamic>(MC.BusinessPlace, TheFilter, SuggestedValue, "buss_place", true);
                ASBusinessPlace.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M013_B_P)x).tax_acc_group ?? "");
                TheFilter = (o, prefix) => (((ACC_M013_B_P)o).tax_acc_group ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M013_B_P)o).tax_acc_group_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASAccGroup = new AutoSuggestTextViewModel<dynamic>(MC.AccountGroup, TheFilter, SuggestedValue, "tax_acc_group", true);
                ASAccGroup.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M013_A_P)x).tax_cat_code ?? "");
                TheFilter = (o, prefix) => (((ACC_M013_A_P)o).tax_cat_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M013_A_P)o).tax_indicator ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M013_A_P)o).tax_indicator_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASTaxClass = new AutoSuggestTextViewModel<dynamic>(MC.TaxCategory, TheFilter, SuggestedValue, "tax_cat_code", true);
                ASTaxClass.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_C_P)x).buss_place ?? "");
                TheFilter = (o, prefix) => (((ADM_M003_C_P)o).buss_place ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003_C_P)o).plc_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASBusinessPlace1 = new AutoSuggestTextViewModel<dynamic>(MC.BusinessPlace, TheFilter, SuggestedValue, "buss_place", "buss_place", true);
                ASBusinessPlace1.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M007_P)x).p_term_code ?? "");
                TheFilter = (o, prefix) => (((ACC_M007_P)o).p_term_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ACC_M007_P)o).p_term ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASPayTerms = new AutoSuggestTextViewModel<dynamic>(MC.PayTerms, TheFilter, SuggestedValue, "p_term_code", "p_term_code", true);
                ASPayTerms.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => ((ADM_M037_P)o).curr_code.ToString().ToLower().Contains(prefix.ToLower());
                ASFltrt_Currency = new AutoSuggestTextViewModel<dynamic>(MC.Currency, TheFilter, SuggestedValue, "curr_code", true);
                ASFltrt_Currency.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M0002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0002)o).comp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", true);
                AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M012_P)x).country_code);
                TheFilter = (o, prefix) => (((ADM_M012_P)o).country_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M012_P)o).CntryName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COUNTRY = new AutoSuggestTextViewModel<dynamic>(MC.Country, TheFilter, SuggestedValue, "country_code", "country_code", true);
                AS_COUNTRY.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M013_P)x).state_code);
                TheFilter = (o, prefix) => (((ADM_M013_P)o).state_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M013_P)o).StatName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_STATE = new AutoSuggestTextViewModel<dynamic>(MC.State, TheFilter, SuggestedValue, "state_code", "state_code", true);
                AS_STATE.AutoSuggestVM.IsEmptyValueAllowed = true;

                COUNTRY_COL = MC.Country;
                STATE_COL = MC.State;

                #endregion

                EmployeeCollection = CollectionViewSource.GetDefaultView(MC.Employees);
                EmployeeCollection.Filter = new Predicate<object>(FilterEmployee);
                StringListEmployee = MC.Employees.Select(x => x.EmpName.ToString()).ToList();

                LocationCollection = CollectionViewSource.GetDefaultView(MC.Locations);
                LocationCollection.Filter = new Predicate<object>(FilterLocation);
                StringListLocation = MC.Locations.Select(x => x.LoctnNm.ToString()).ToList();

                CurrencyCollection = CollectionViewSource.GetDefaultView(MC.Currency);
                CurrencyCollection.Filter = new Predicate<object>(FilterCurrancy);
                StringListCurrency = MC.Currency.Select(x => x.curr_name.ToString()).ToList();

                CountryCollection = CollectionViewSource.GetDefaultView(MC.Country);
                CountryCollection.Filter = new Predicate<object>(FilterCountry);
                StringListCountry = MC.Country.Select(x => x.CntryName.ToString()).ToList();

                //StateCollection = CollectionViewSource.GetDefaultView(MC.State);
                //StateCollection.Filter = new Predicate<object>(FilterState);
                //StringListState = MC.State.Select(x => x.StatName.ToString()).ToList();

                DepartmentCollection = CollectionViewSource.GetDefaultView(MC.Departments);
                DepartmentCollection.Filter = new Predicate<object>(FilterDepartment);
                StringListDepartments = MC.Departments.Select(x => x.DeptName.ToString()).ToList();

                DesignationCollection = CollectionViewSource.GetDefaultView(MC.Designations);
                DesignationCollection.Filter = new Predicate<object>(FilterDesignation);
                StringListDesignations = MC.Designations.Select(x => x.DesigName.ToString()).ToList();

                PartyTypeCollection = CollectionViewSource.GetDefaultView(MC.PartyType);
                PartyTypeCollection.Filter = new Predicate<object>(FilterParty);
                StringListPartyType = MC.PartyType.Select(x => x.PartyType_Nm.ToString()).ToList();

                GroupCollection = CollectionViewSource.GetDefaultView(MC.Group);
                GroupCollection.Filter = new Predicate<object>(FilterGroup);
                StringListGroup = MC.Group.Select(x => x.grpNm.ToString()).ToList();

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

                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + REQ_PARA.comp_code + "!@" + REQ_PARA.location_id + "!@" + REQ_PARA.from_date + "!@" + REQ_PARA.active + "!@1!@";
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ADM_M028>(MCTemp, Request, "ADM_M0028_BL", "ADM", "LoadAll", 0, "");


                FlipGridData = MCTemp.BACK_FLIP_LIST.ToList();
                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(FlipGridData);
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(Filter_BackFlip);

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
                
                MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                REQ_PARA.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                LoadInitialData();
                DefaultValues();

                //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            { //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); 
            }
        }
        
        // Method to fetch suggestions asynchronously based on the TextBox text
        //private async void LoadSuggestionsFromDatabase(object para)
        //{
        //    if(MCTemp.PARTY_LIST == null)
        //    {
        //        await Task.Run(async () =>
        //        {
        //            await Task.Delay(50);
        //        });
        //        await FetchSuggestionsAsync();
        //    }
        //    else if (MCTemp.PARTY_LIST != null)
        //    {
        //        if (MCTemp.PARTY_LIST.Count == 0)
        //        {
        //            await FetchSuggestionsAsync();
        //        }
        //    }
        //}
        //private async Task FetchSuggestionsAsync()
        //{
        //    try
        //    {
        //        await Task.Run(async () =>
        //        {
        //            await Task.Delay(50);
        //        });
        //        string Request = "LOAD_PARTY" + "!@" + AppSessionState.client + "!@" + REQ_PARA.comp_code;
        //        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ADM_M028>(MCTemp, Request, "ADM_M0028_BL", "ADM", "LoadAll", 0, "");

        //        PARTY_LIST = MCTemp.PARTY_LIST;

        //    }
        //    catch (Exception ex)
        //    { }
        //}
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
        //        }
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
        //    }
        //}
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            STD_LIST_BE ParameterEntityObject = null;
            try
            {
                if (((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList()[0];
                    //Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.PartyId + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                    Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.client + "!@" + ParameterEntityObject.comp_code + "!@" + ParameterEntityObject.location_id + "!@!@!@" + ParameterEntityObject.party_code;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ADM_M028>(MCTemp, Request, "ADM_M0028_BL", "ADM", "LoadDocumentByDocumentNumber", 0, "");

                    if (MCTemp.MasterEntity.Count > 0)
                    {
                        MasterEntity = MCTemp.MasterEntity[0];
                        MasterEntity.editby = AppSessionState.UserID;
                    }
                    AddressEntity = MCTemp.AddressEntity;
                    ContactEntity = MCTemp.ContactEntity;

                    foreach (ADM_M028_D item in AddressEntity)
                    {
                        state = (from o in MC.State
                                 where o.country_code == item.country_code
                                 select o).ToList();

                        StateCollection = CollectionViewSource.GetDefaultView((state));
                        StateCollection.Filter = new Predicate<object>(FilterState);
                        StringListState = state.Select(x => x.StatName.ToString()).ToList();
                    }

                    SelectedTabControlIndex = 0;
                    SetBusinessEntitiesAfterLoad("Save", "");
                    SetPopupSuggestionDataAfterLoad();
                    var msg = new NotificationMessage("SDM_M0014_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);
                    isNewRecord = false;
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

        private void SetPopupSuggestionDataAfterLoad()
        {
            ASAccountingGroup.AutoSuggestVM.Suggestion = MC.AccountingGroupList.Find(x => x.acc_group == MasterEntity.acc_group);
            ASReconAcc.AutoSuggestVM.Suggestion = MC.ReconAccountList.Find(x => x.gl_code == MasterEntity.recon_acc);
            ASBusinessPlace.AutoSuggestVM.Suggestion = MC.BusinessPlace.Find(x => x.buss_place == MasterEntity.buss_place);
        }
        private void InsertLocation(object InputValue)
        {
            string Request = "";
            ADM_M003_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Locations.Where(x => x.LoctnNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M003_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.godown_location_name = POPUPEntityObject.LoctnNm;
                    MasterEntity.godown_location = POPUPEntityObject.location_Id;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertPartyType(object InputValue)
        {
            string Request = "";
            ADM_M028_B_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PartyType.Where(x => x.PartyType_Nm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M028_B_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_B_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.PartyType = POPUPEntityObject.PartyType;
                    MasterEntity.PartyType_Nm = POPUPEntityObject.PartyType_Nm;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertGroup(object InputValue)
        {
            string Request = "";
            ADM_M028_A_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Group.Where(x => x.grpNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M028_A_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_A_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.group1 = POPUPEntityObject.group1;
                    MasterEntity.grpNm = POPUPEntityObject.grpNm;
                }
            }
            catch (Exception ex) { }
        }

        private void InsertBusinessPlace(object InputValue)
        {
            string Request = "";
            ADM_M003_C_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BusinessPlace.Where(x => x.buss_place.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M003_C_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_C_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.buss_place = POPUPEntityObject.buss_place;
                    MasterEntity.plc_name = POPUPEntityObject.plc_name;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertPayTerms(object InputValue)
        {
            string Request = "";
            ACC_M007_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PayTerms.Where(x => x.p_term_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M007_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M007_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.p_term_code = POPUPEntityObject.p_term_code;
                    MasterEntity.p_term = POPUPEntityObject.p_term;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertAccountGroup(object InputValue)
        {
            string Request = "";
            ACC_M013_B_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.AccountGroup.Where(x => x.tax_acc_group.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M013_B_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M013_B_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.tax_acc_group = POPUPEntityObject.tax_acc_group;
                    MasterEntity.tax_acc_group_name = POPUPEntityObject.tax_acc_group_name;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertTaxClassification(object InputValue)
        {
            string Request = "";
            ACC_M013_A_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.TaxCategory.Where(x => x.tax_cat_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M013_A_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M013_A_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.tax_classification = POPUPEntityObject.tax_cat_code;
                    MasterEntity.tax_indicator = POPUPEntityObject.tax_indicator;
                    MasterEntity.tax_indicator_desc = POPUPEntityObject.tax_indicator_desc;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertCurrency(object InputValue)
        {
            string Request = "";
            ADM_M037_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Currency.Where(x => x.curr_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M037_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M037_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.curr_code = POPUPEntityObject.curr_code;
                    MasterEntity.curr_name = POPUPEntityObject.curr_name;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertEmployee(object InputValue)
        {
            string Request = "";
            ADM_M024_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Employees.Where(x => x.EmpName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M024_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.EmpId = POPUPEntityObject.EmpId;
                    MasterEntity.EmpNm = POPUPEntityObject.EmpName;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertCountry(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M012_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Country.Where(x => x.country_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M012_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M012_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = AddressEntity.Where(x => x.country_code == POPUPEntityObject.country_code).FirstOrDefault();
                    var IndexOfExistValue = AddressEntity.IndexOf(AddressEntity.Where(X => X.country_code == POPUPEntityObject.country_code).FirstOrDefault());

                    if (dgSelectedIndexAddress >= 0 && AddressEntity.Count > dgSelectedIndexAddress)
                    {
                        AddressEntity[dgSelectedIndexAddress].country_code = POPUPEntityObject.country_code;
                        AddressEntity[dgSelectedIndexAddress].CntryName = POPUPEntityObject.CntryName;

                        state = (from o in MC.State
                                 where o.country_code == AddressEntity[dgSelectedIndexAddress].country_code
                                 select o).ToList();
                        STATE_COL = state;

                        AddressEntity[dgSelectedIndexAddress].state_code = null;
                        AddressEntity[dgSelectedIndexAddress].StatName = null;

                        //if (((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        //{
                        //    AddressEntity[dgSelectedIndexAddress].country_code = POPUPEntityObject.country_code;
                        //    AddressEntity[dgSelectedIndexAddress].CntryName = POPUPEntityObject.CntryName;

                        //    state = (from o in MC.State
                        //             where o.country_code == AddressEntity[dgSelectedIndexAddress].country_code
                        //             select o).ToList();

                        //    StateCollection = CollectionViewSource.GetDefaultView((state));
                        //    StateCollection.Filter = new Predicate<object>(FilterState);
                        //    StringListState = state.Select(x => x.StatName.ToString()).ToList();
                        //}
                        //else if (AddressEntity[dgSelectedIndexAddress].country_code != POPUPEntityObject.country_code)
                        //{
                        //    AddressEntity[dgSelectedIndexAddress].country_code = POPUPEntityObject.country_code;
                        //    AddressEntity[dgSelectedIndexAddress].CntryName = POPUPEntityObject.CntryName;

                        //    state = (from o in MC.State
                        //             where o.country_code == AddressEntity[dgSelectedIndexAddress].country_code
                        //             select o).ToList();

                        //    StateCollection = CollectionViewSource.GetDefaultView((state));
                        //    StateCollection.Filter = new Predicate<object>(FilterState);
                        //    StringListState = state.Select(x => x.StatName.ToString()).ToList();
                        //}
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void InsertState(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M013_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = state.Where(x => x.state_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M013_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M013_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = AddressEntity.Where(x => x.state_code == POPUPEntityObject.state_code).FirstOrDefault();
                    var IndexOfExistValue = AddressEntity.IndexOf(AddressEntity.Where(X => X.state_code == POPUPEntityObject.state_code).FirstOrDefault());

                    if (dgSelectedIndexAddress >= 0 && AddressEntity.Count > dgSelectedIndexAddress)
                    {
                        AddressEntity[dgSelectedIndexAddress].state_code = POPUPEntityObject.state_code;
                        AddressEntity[dgSelectedIndexAddress].StatName = POPUPEntityObject.StatName;
                        //if (((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        //{
                        //    AddressEntity[dgSelectedIndexAddress].state_code = POPUPEntityObject.state_code;
                        //    AddressEntity[dgSelectedIndexAddress].StatName = POPUPEntityObject.StatName;
                        //}
                        //else if (AddressEntity[dgSelectedIndexAddress].state_code != POPUPEntityObject.state_code)
                        //{
                        //    AddressEntity[dgSelectedIndexAddress].state_code = POPUPEntityObject.state_code;
                        //    AddressEntity[dgSelectedIndexAddress].StatName = POPUPEntityObject.StatName;
                        //}
                    }

                }
            }
            catch (Exception ex) { }
        }
        private void InsertDesignation(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M026_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Designations.Where(x => x.DesigName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M026_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M026_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = ContactEntity.Where(x => x.desig_code == POPUPEntityObject.desig_code).FirstOrDefault();
                    var IndexOfExistValue = ContactEntity.IndexOf(ContactEntity.Where(X => X.desig_code == POPUPEntityObject.desig_code).FirstOrDefault());

                    if (dgSelectedIndexContact >= 0 && ContactEntity.Count > dgSelectedIndexContact)
                    {
                        if (((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ContactEntity[dgSelectedIndexContact].desig_code = POPUPEntityObject.desig_code;
                            ContactEntity[dgSelectedIndexContact].DesigName = POPUPEntityObject.DesigName;
                        }
                        else if (ContactEntity[dgSelectedIndexContact].desig_code != POPUPEntityObject.desig_code)
                        {
                            ContactEntity[dgSelectedIndexContact].desig_code = POPUPEntityObject.desig_code;
                            ContactEntity[dgSelectedIndexContact].DesigName = POPUPEntityObject.DesigName;
                        }
                    }

                }
            }
            catch (Exception ex) { }
        }
        private void InsertDepartment(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M025_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Departments.Where(x => x.DeptName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M025_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M025_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = ContactEntity.Where(x => x.desig_code == POPUPEntityObject.dept_code).FirstOrDefault();
                    var IndexOfExistValue = ContactEntity.IndexOf(ContactEntity.Where(X => X.desig_code == POPUPEntityObject.dept_code).FirstOrDefault());

                    if (dgSelectedIndexContact >= 0 && ContactEntity.Count > dgSelectedIndexContact)
                    {
                        if (((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ContactEntity[dgSelectedIndexContact].dept_code = POPUPEntityObject.dept_code;
                            ContactEntity[dgSelectedIndexContact].DeptName = POPUPEntityObject.DeptName;
                        }
                        else if (ContactEntity[dgSelectedIndexContact].dept_code != POPUPEntityObject.dept_code)
                        {
                            ContactEntity[dgSelectedIndexContact].dept_code = POPUPEntityObject.dept_code;
                            ContactEntity[dgSelectedIndexContact].DeptName = POPUPEntityObject.DeptName;
                        }
                    }

                }
                else
                {
                    ContactEntity[dgSelectedIndexContact].dept_code = null;
                    ContactEntity[dgSelectedIndexContact].DeptName = null;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertAccountingGroup(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003_H POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.AccountingGroupList.Where(x => x.acc_group.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M003_H>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_H>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.acc_group = POPUPEntityObject.acc_group;
                    MasterEntity.group_desc = POPUPEntityObject.group_desc;
                    MasterEntity.acc_group_type = POPUPEntityObject.acc_group_type;
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

        private void InsertBusinessGroup(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M028_J_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BussGroupList.Where(x => x.BusinessTyp.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M028_J_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_J_P>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.BusinesTyp = POPUPEntityObject.BusinessTyp;

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
            if (string.IsNullOrWhiteSpace(MasterEntity.comp_code))
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Please Select Company Code...", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.curr_code == null || MasterEntity.curr_code.ToString().Trim().Length == 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Please Select Currency...", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.abbr == null || MasterEntity.abbr.ToString().Trim().Length == 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Please input Abbreviation...", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.Location == null || MasterEntity.Location.ToString().Trim().Length == 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Please input Location...", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.PartyNm == null || MasterEntity.PartyNm.ToString().Trim().Length == 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Please input Customer name...", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            else if (string.IsNullOrWhiteSpace(MasterEntity.PartyType))
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Please input Customer Type...", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            //else if (MasterEntity.buss_place == null || MasterEntity.buss_place.ToString().Trim().Length == 0)
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Required";
            //    showMessageService.Text = String.Format("Please Select Business Place & GST IN No...", this.Title);
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            //else if (MasterEntity.gstinno == null || MasterEntity.gstinno.ToString().Trim().Length == 0)
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Required";
            //    showMessageService.Text = String.Format("Please Select GSTIN...", this.Title);
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            else if (MasterEntity.acc_group == null || MasterEntity.acc_group.ToString().Trim().Length == 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Please Select Accounting Group...", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            
            else if (MasterEntity.recon_acc == null || MasterEntity.recon_acc.ToString().Trim().Length == 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Please Select Reconcillation Ledger Account...", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            else if (AddressEntity.Count == 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("At least one registered Address required...", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            foreach (var o in AddressEntity)
            {
                if (o.Location == null || o.Location.ToString().Trim().Length == 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Address Location required", o.Location, o.PartyNm);
                    showMessageService.ShowMessage();
                    return false;
                }

                if (o.AddType == null || o.AddType.ToString().Trim().Length == 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Address Type {0} and Landmark {1}", o.AddType, o.Location);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (o.Add1 == null || o.Add1.ToString().Trim().Length == 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Address Line 1 {0} and Line 2 {1}", o.Add1, o.Add2);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (o.country_code == null || o.country_code.ToString().Trim().Length == 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Country {0} and State {1}", o.country_code, o.state_code);
                    showMessageService.ShowMessage();
                    return false;
                }
                //if (o.buss_place == null || o.buss_place.ToString().Trim().Length == 0)
                //{
                //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //    showMessageService.ButtonSetup = DialogButton.Ok;
                //    showMessageService.Caption = "Message";
                //    showMessageService.Text = String.Format("Please Enter buss_place {0} and GSTIN {1}", o.buss_place, o.gstinno);
                //    showMessageService.ShowMessage();
                //    return false;
                //}
                //if (o.gstinno == null || o.gstinno.ToString().Trim().Length == 0)
                //{
                //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //    showMessageService.ButtonSetup = DialogButton.Ok;
                //    showMessageService.Caption = "Message";
                //    showMessageService.Text = String.Format("Please Enter buss_place {0} and GSTIN {1}", o.buss_place, o.gstinno);
                //    showMessageService.ShowMessage();
                //    return false;
                //}
            }
            return true;
        }
        private void DeleteDataGridRowAddressEntity(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (AddressEntity.Count > i && AddressEntity[dgSelectedIndexAddress].active == false)
                {
                    AddressEntity.RemoveAt(i);
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
        private void DeleteDataGridRowContactEntity(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ContactEntity.Count > i && ContactEntity[dgSelectedIndexContact].active == false)
                {
                    ContactEntity.RemoveAt(i);
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
        private void InsertReconAccount(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ReconAccountList.Where(x => x.gl_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M003_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_P>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.recon_acc = POPUPEntityObject.gl_code;
                    MasterEntity.gl_name = POPUPEntityObject.gl_name;
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

        #region Constructor
        public SDM_M0014_VM(string ts_code,string doc_cat) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            MC = new MultipleContext_ADM_M028();
            MCTemp = new MultipleContext_ADM_M028();
            MasterEntity = new ADM_M028();
            AddressEntity = new ObservableCollection<ADM_M028_D>();
            ContactEntity = new ObservableCollection<ADM_M028_C>();
            //TotalDocumentTaxesItem = new ObservableCollection<ADM_M028>();
            MasterEntity.ValidateAsync().Wait();
            REQ_PARA = new STD_REQ_PARA_BE();
            //cmdNameTextChanged = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadSuggestionsFromDatabase(cmdPara); });
            //cmdInsertCompany = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCompany(cmdPara); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
            CmdAddGodownLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertLocation(items); });
            CmdAddPartyType = new RelayCommand<object>(items => { if (items == null) { return; } InsertPartyType(items); });
            CmdAddGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertGroup(items); });
            CmdAddCurrency = new RelayCommand<object>(items => { if (items == null) { return; } InsertCurrency(items); });
            CmdAddAccountingGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertAccountingGroup(items); });
            CmdAddBusinessGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertBusinessGroup(items); });
            cmdInsertReconAccount = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertReconAccount(cmdPara); });
            CmdAddEmployee = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmployee(items); });
            CmdAddCountry = new RelayCommand<object>(items => { if (items == null) { return; } InsertCountry(items, false, false, true); });
            CmdAddState = new RelayCommand<object>(items => { if (items == null) { return; } InsertState(items, false, false, true); });
            CmdAddDesignation = new RelayCommand<object>(items => { if (items == null) { return; } InsertDesignation(items, false, false, true); });
            CmdAddDepartment = new RelayCommand<object>(items => { if (items == null) { return; } InsertDepartment(items, false, false, true); });
            CmdBusinessPlace = new RelayCommand<object>(items => { if (items == null) { return; } InsertBusinessPlace(items); });
            CmdAddAccGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertAccountGroup(items); });
            CmdAddTaxClass = new RelayCommand<object>(items => { if (items == null) { return; } InsertTaxClassification(items); });
            CmdAddPayTerms = new RelayCommand<object>(items => { if (items == null) { return; } InsertPayTerms(items); });
            CmdDeleteDataGridRowAddressEntity = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowAddressEntity(items); });
            CmdDeleteDataGridRowContactEntity = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowContactEntity(items); });

            cmdLoadBackFlip = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadBackFlipData(cmdPara); });
            ExportCommand = new GalaSoft.MvvmLight.Command.RelayCommand(() => { ExportCommandPrint(); });


            //LoadInitialData();
        }

        #endregion

        #region Abstract Command Actions
        private void DefaultValues()
        {
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.Customer = true;
            MasterEntity.Supplier = false;
            MasterEntity.PartyType = "002";
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            //if (MC.COMPANY_LIST != null)
            //{
            //    if (MC.COMPANY_LIST.Count == 1)
            //    {
            //        MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            //        MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            //    }
            //}
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.XmlDataDocument_ADM_M028_D != null)
                {
                    AddressEntity.Clear();
                    MC.AddressEntity = (ObservableCollection<ADM_M028_D>)obj.XMLToObject(MasterEntity.XmlDataDocument_ADM_M028_D, MC.AddressEntity);
                    AddressEntity = MC.AddressEntity;
                }
                else
                {
                    MC.AddressEntity = new ObservableCollection<ADM_M028_D>();
                }

                if (MasterEntity.XmlDataDocument_ADM_M028_C != null)
                {
                    ContactEntity.Clear();
                    MC.ContactEntity = (ObservableCollection<ADM_M028_C>)obj.XMLToObject(MasterEntity.XmlDataDocument_ADM_M028_C, MC.ContactEntity);
                    ContactEntity = MC.ContactEntity;
                }
                else
                {
                    MC.ContactEntity = new ObservableCollection<ADM_M028_C>();
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
        protected override void OnSaveAction(InquiryActionResult<ADM_M028> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.ts_code = ts_code_vm;
                    MasterEntity.userid = AppSessionState.UserID;
                    MasterEntity.user_source1 = AppSessionState.UserSource1;
                    MasterEntity.user_source2 = AppSessionState.UserSource2;
                    //DefaultValues();
                    MasterEntity.XmlDataDocument_ADM_M028_D = obj.ObjectToXML(AddressEntity);
                    MasterEntity.XmlDataDocument_ADM_M028_C = obj.ObjectToXML(ContactEntity);
                    this.MasterEntity.EndEdit();

                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ADM_M028>(MasterEntity, "ADM_M0028_BL", "ADM");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ADM_M028>(MasterEntity, "ADM_M0028_BL", "ADM");
                    }

                    if (MasterEntity.PartyId != null && isNewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }

                    if (MasterEntity.PartyId != null && isNewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    isNewRecord = false;
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
        protected override void OnCreateAction(InquiryActionResult<ADM_M028> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M028();
            AddressEntity = new ObservableCollection<ADM_M028_D>();
            ContactEntity = new ObservableCollection<ADM_M028_C>();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M028> result)
        {
            if (MasterEntity.PartyId != null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Delete Changes";
                showMessageService.Text = String.Format("This record will delete forever", this.Title);
                if (showMessageService.ShowMessage() == DialogResult.Ok)
                {
                    //this.MasterEntity.CancelEdit();
                    //string response = repository.Delete(MasterEntity.PartyId, "ADM_M0028_BL", "ADM");
                    //MasterEntity = new ADM_M028();
                    //AddressEntity = new ObservableCollection<ADM_M028_D>();
                    //ContactEntity = new ObservableCollection<ADM_M028_C>();
                    //isNewRecord = true;
                }
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M028> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M028> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M028> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M028> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M028> result)
        {
            try
            {
                //string Request = "Party_Report" + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                string Request = "Party_Report" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + MasterEntity.PartyId;

                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M028>(MCTemp, Request, "ADM_M0028_BL", "ADM", "", 0, "");
                object[] objDataSource = new object[3];
                string[] objDataSourceName = new string[3];



                objDataSource[0] = MCTemp.RptPartyList;

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[1] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[2] = Result;



                objDataSourceName[0] = "dsRptParty";
                objDataSourceName[1] = "dsCompany";
                objDataSourceName[2] = "dsLocation";


                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Admin\\PartyDocument.rdlc", getParametersList(), "");
            }
            catch (Exception ex) { }
        }

        private void ExportCommandPrint()
        {
            try
            {
                //string Request = "Party_Report" + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                // string Request = AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id;

                //MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ADM_M024>(MCTemp, Request, "ADM_M0028_BL", "ADM", "", 0, "");
                // MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ADM_M024>(MCTemp, Request, "Employee_Master", "Administration", "LoadDocumentByDocumentNumber", 0, "");


                object[] objDataSource = new object[3];
                string[] objDataSourceName = new string[3];

                objDataSource[0] = MCTemp.DocumentDataFlipGrid;

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[1] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[2] = Result;



                objDataSourceName[0] = "dsRptParty";
                objDataSourceName[1] = "dsCompany";
                objDataSourceName[2] = "dsLocation";


                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Admin\\PartyDetailReport.rdlc", getParametersList(), "");
            }
            catch (Exception ex) { }
        }

        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.EmpId.ToString()))
            {
                //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.EmpId.ToString().Replace("/", "--"), DocumentList = MCTemp.AttachmentList, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M028> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M028> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M028> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M028> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M028> result)
        {
            throw new NotImplementedException();
        }
        #endregion

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

        #region Filters

        private string _filterStringEmployee;
        private string _filterStringCountry;
        private string _filterStringState;
        private string _filterStringLocation;
        private string _filterStringCurrancy;
        private string _filterStringDepartment;
        private string _filterStringDesignation;
        private string _filterStringParty;
        private string _filterStringGroup;

        #region Filter Employee
        public bool FilterEmployee(object obj)
        {

            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringEmployee))
                {
                    return (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterStringEmployee.ToLower()) ||
                        data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterStringEmployee.ToLower()));
                }
                return true;
            }
            return false;
        }

        public string FilterStringEmployee
        {
            get { return _filterStringEmployee; }
            set
            {
                _filterStringEmployee = value;
                RaisePropertyChanged("FilterStringEmployee");
                FilterCollectionEmployee();
            }
        }
        private void FilterCollectionEmployee()
        {
            if (_EmployeeCollection != null)
            {
                _EmployeeCollection.Refresh();
            }
        }

        #endregion

        #region Filter Country
        public bool FilterCountry(object obj)
        {
            var data = obj as ADM_M012_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringCountry))
                {
                    return (data.country_code != null && data.country_code.ToString().ToLower().Contains(_filterStringCountry.ToLower()) || data.CntryName != null && data.CntryName.ToString().ToLower().Contains(_filterStringCountry.ToLower()));
                }
                return true;
            }
            return false;
        }

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
        private void FilterCollectionCountry()
        {
            if (CountryCollection != null)
            {
                CountryCollection.Refresh();
            }
        }


        #endregion

        #region Filter State
        public bool FilterState(object obj)
        {
            var data = obj as ADM_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringState))
                {
                    return (data.state_code != null && data.state_code.ToString().ToLower().Contains(_filterStringState.ToLower()) || data.StatName != null && data.StatName.ToString().ToLower().Contains(_filterStringState.ToLower()));
                }
                return true;
            }
            return false;
        }

        public string FilterStringState
        {
            get { return _filterStringState; }
            set
            {
                _filterStringState = value;
                RaisePropertyChanged("FilterStringState");
                FilterCollectionState();
            }
        }
        private void FilterCollectionState()
        {
            if (StateCollection != null)
            {
                StateCollection.Refresh();
            }
        }


        #endregion

        #region Filter For DataGrid
        private string _filterStringBackFlip;
        public string filterStringBackFlip
        {
            get { return _filterStringBackFlip; }
            set
            {
                _filterStringBackFlip = value;
                RaisePropertyChanged("FilterString");
                Filter_BackFlipCollection();
            }
        }
        private void Filter_BackFlipCollection()
        {
            if (BACKFLIP_COLLECTION != null)
            {
                BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool Filter_BackFlip(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringBackFlip))
                {

                    return
                        (data.party_code != null && data.party_code.ToString().ToLower().Contains(_filterStringBackFlip.ToLower())) ||
                        (data.party_name != null && data.party_name.ToString().ToLower().Contains(_filterStringBackFlip.ToLower())) ||
                        (data.location != null && data.location.ToString().ToLower().Contains(_filterStringBackFlip.ToLower())) ||
                        (data.cat_code != null && data.cat_code.ToString().ToLower().Contains(_filterStringBackFlip.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter Location
        public bool FilterLocation(object obj)
        {
            var data = obj as ADM_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringLocation))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterStringLocation.ToLower()) || data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterStringLocation.ToLower()));
                }
                return true;
            }
            return false;
        }

        public string FilterStringLocation
        {
            get { return _filterStringLocation; }
            set
            {
                _filterStringLocation = value;
                RaisePropertyChanged("FilterStringLocation");
                FilterCollectionLocation();
            }
        }
        private void FilterCollectionLocation()
        {
            if (_LocationCollection != null)
            {
                _LocationCollection.Refresh();
            }
        }

        #endregion

        #region Filter Currancy
        public bool FilterCurrancy(object obj)
        {
            var data = obj as ADM_M037_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringCurrancy))
                {
                    return (data.curr_code != null && data.curr_code.ToString().ToLower().Contains(_filterStringCurrancy.ToLower()) || data.curr_name != null && data.curr_name.ToString().ToLower().Contains(_filterStringCurrancy.ToLower()));
                }
                return true;
            }
            return false;
        }

        public string FilterStringCurrancy
        {
            get { return _filterStringCurrancy; }
            set
            {
                _filterStringCurrancy = value;
                RaisePropertyChanged("FilterStringCurrancy");
                FilterCollectionCurrancy();
            }
        }
        private void FilterCollectionCurrancy()
        {
            if (_CurrencyCollection != null)
            {
                _CurrencyCollection.Refresh();
            }
        }

        #endregion

        #region Filter For Department
        public bool FilterDepartment(object obj)
        {
            var data = obj as ADM_M025_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringDepartment))
                {
                    return (data.dept_code != null && data.dept_code.ToString().ToLower().Contains(_filterStringDepartment.ToLower()) || data.DeptName != null && data.DeptName.ToString().ToLower().Contains(_filterStringDepartment.ToLower()));
                }
                return true;
            }
            return false;
        }

        public string FilterStringDepartment
        {
            get { return _filterStringDepartment; }
            set
            {
                _filterStringDepartment = value;
                RaisePropertyChanged("filterStringDepartment");
                FilterCollectionDepartment();
            }
        }
        private void FilterCollectionDepartment()
        {
            if (_DepartmentCollection != null)
            {
                _DepartmentCollection.Refresh();
            }
        }


        #endregion

        #region Filter Designation
        public bool FilterDesignation(object obj)
        {
            var data = obj as ADM_M026_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringDesignation))
                {
                    return (data.desig_code != null && data.desig_code.ToString().ToLower().Contains(_filterStringDesignation.ToLower()) || data.DesigName != null && data.DesigName.ToString().ToLower().Contains(_filterStringDesignation.ToLower()));
                }
                return true;
            }
            return false;
        }

        public string FilterStringDesignation
        {
            get { return _filterStringDesignation; }
            set
            {
                _filterStringDesignation = value;
                RaisePropertyChanged("FilterStringDesignation");
                FilterCollectionDesignation();
            }
        }
        private void FilterCollectionDesignation()
        {
            if (_DesignationCollection != null)
            {
                _DesignationCollection.Refresh();
            }
        }

        #endregion

        #region Filter PartyType

        public bool FilterParty(object obj)
        {
            var data = obj as ADM_M028_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringParty))
                {
                    return (data.PartyType != null && data.PartyType.ToString().ToLower().Contains(_filterStringParty.ToLower()) || data.PartyType_Nm != null && data.PartyType_Nm.ToString().ToLower().Contains(_filterStringParty.ToLower()));
                }
                return true;
            }
            return false;
        }

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
        private void FilterCollectionParty()
        {
            if (_PartyTypeCollection != null)
            {
                _PartyTypeCollection.Refresh();
            }
        }


        #endregion

        #region Filter Group

        public bool FilterGroup(object obj)
        {
            var data = obj as ADM_M028_A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringGroup))
                {
                    return (data.group1 != null && data.group1.ToString().ToLower().Contains(_filterStringGroup.ToLower()) || data.grpNm != null && data.grpNm.ToString().ToLower().Contains(_filterStringGroup.ToLower()));
                }
                return true;
            }
            return false;
        }

        public string FilterStringGroup
        {
            get { return _filterStringGroup; }
            set
            {
                _filterStringGroup = value;
                RaisePropertyChanged("FilterStringGroup");
                FilterCollectionGroup();
            }
        }
        private void FilterCollectionGroup()
        {
            if (_GroupCollection != null)
            {
                _GroupCollection.Refresh();
            }
        }


        #endregion

        #endregion

    }
}
