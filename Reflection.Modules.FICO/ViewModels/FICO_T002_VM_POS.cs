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
using System.Collections.Specialized;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using System.Reflection;
using GalaSoft.MvvmLight.Ioc;
using Reflection.Presentation.Core.VirtualDesktops;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.GEN;
using Reflection.BusinessEntity.Account;
using Reflection.BusinessEntity.FICO;
using Reflection.BusinessEntity.ADM;

// NOTE: Pending Point
// Batch selection is pending for selected item and goods posting. now add batch no in item collection. and prepare batch collection from item collection for goods posting.
// Status need to be change on every update like Save=01, Checkout=02,Paymnet & Goods Posting=03
// update mov_type_mi in adm_m0010 for SI doc_cat
// 6)	Default Reconciliation General Ledger (G/L) Account assignment for Customer, Material and Payment process.

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_T002_VM_POS : WorkspaceViewModel<SEL_T003>
    {
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(FICO_T002_VM_POS));
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
        private AutoSuggestTextViewModel<dynamic> _ASDefault1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault1
        {
            get { return _ASDefault1; }
            set
            {
                if (_ASDefault1 != value)
                {
                    _ASDefault1 = value; RaisePropertyChanged("ASDefault1");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDefault2 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault2
        {
            get { return _ASDefault2; }
            set
            {
                if (_ASDefault2 != value)
                {
                    _ASDefault2 = value; RaisePropertyChanged("ASDefault2");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDefault3 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault3
        {
            get { return _ASDefault3; }
            set
            {
                if (_ASDefault3 != value)
                {
                    _ASDefault3 = value; RaisePropertyChanged("ASDefault3");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASCountry { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCountry
        {
            get { return _ASCountry; }
            set
            {
                if (_ASCountry != value)
                {
                    _ASCountry = value; RaisePropertyChanged("ASCountry");
                }
            }
        }
        //private AutoSuggestTextViewModel<dynamic> _ASCompany { get; set; }
        //public AutoSuggestTextViewModel<dynamic> ASCompany
        //{
        //    get { return _ASCompany; }
        //    set
        //    {
        //        if (_ASCompany != value)
        //        {
        //            _ASCompany = value; RaisePropertyChanged("ASCompany");
        //        }
        //    }
        //}
        private AutoSuggestTextViewModel<dynamic> _ASTradeIndicator { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTradeIndicator
        {
            get { return _ASTradeIndicator; }
            set
            {
                if (_ASTradeIndicator != value)
                {
                    _ASTradeIndicator = value; RaisePropertyChanged("ASTradeIndicator");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDocType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocType
        {
            get { return _ASDocType; }
            set
            {
                if (_ASDocType != value)
                {
                    _ASDocType = value; RaisePropertyChanged("ASDocType");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASNotifyParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASNotifyParty
        {
            get { return _ASNotifyParty; }
            set
            {
                if (_ASNotifyParty != value)
                {
                    _ASNotifyParty = value; RaisePropertyChanged("ASNotifyParty");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASNotifyParty2 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASNotifyParty2
        {
            get { return _ASNotifyParty2; }
            set
            {
                if (_ASNotifyParty2 != value)
                {
                    _ASNotifyParty2 = value; RaisePropertyChanged("ASNotifyParty2");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASCurrency { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCurrency
        {
            get { return _ASCurrency; }
            set
            {
                if (_ASCurrency != value)
                {
                    _ASCurrency = value; RaisePropertyChanged("ASCurrency");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASdgCurrency { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASdgCurrency
        {
            get { return _ASdgCurrency; }
            set
            {
                if (_ASdgCurrency != value)
                {
                    _ASdgCurrency = value; RaisePropertyChanged("ASdgCurrency");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASSalesPerson { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSalesPerson
        {
            get { return _ASSalesPerson; }
            set
            {
                if (_ASSalesPerson != value)
                {
                    _ASSalesPerson = value; RaisePropertyChanged("ASSalesPerson");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASRef_doc_no { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRef_doc_no
        {
            get { return _ASRef_doc_no; }
            set
            {
                if (_ASRef_doc_no != value)
                {
                    _ASRef_doc_no = value; RaisePropertyChanged("ASRef_doc_no");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASItems { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItems
        {
            get { return _ASItems; }
            set
            {
                if (_ASItems != value)
                {
                    _ASItems = value; RaisePropertyChanged("ASItems");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASUOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUOM
        {
            get { return _ASUOM; }
            set
            {
                if (_ASUOM != value)
                {
                    _ASUOM = value; RaisePropertyChanged("ASUOM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASPayer { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPayer
        {
            get { return _ASPayer; }
            set
            {
                if (_ASPayer != value)
                {
                    _ASPayer = value; RaisePropertyChanged("ASPayer");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASWTUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWTUnit
        {
            get { return _ASWTUnit; }
            set
            {
                if (_ASWTUnit != value)
                {
                    _ASWTUnit = value; RaisePropertyChanged("ASWTUnit");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASVolUOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASVolUOM
        {
            get { return _ASVolUOM; }
            set
            {
                if (_ASVolUOM != value)
                {
                    _ASVolUOM = value; RaisePropertyChanged("ASVolUOM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASTaxacc { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTaxacc
        {
            get { return _ASTaxacc; }
            set
            {
                if (_ASTaxacc != value)
                {
                    _ASTaxacc = value; RaisePropertyChanged("ASTaxacc");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASConditionType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASConditionType
        {
            get { return _ASConditionType; }
            set
            {
                if (_ASConditionType != value)
                {
                    _ASConditionType = value; RaisePropertyChanged("ASConditionType");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASTR_MODE { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTR_MODE
        {
            get { return _ASTR_MODE; }
            set
            {
                if (_ASTR_MODE != value)
                {
                    _ASTR_MODE = value; RaisePropertyChanged("ASTR_MODE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDeclaration { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDeclaration
        {
            get { return _ASDeclaration; }
            set
            {
                if (_ASDeclaration != value)
                {
                    _ASDeclaration = value; RaisePropertyChanged("ASDeclaration");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASTaxDeclaration { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTaxDeclaration
        {
            get { return _ASTaxDeclaration; }
            set
            {
                if (_ASTaxDeclaration != value)
                {
                    _ASTaxDeclaration = value; RaisePropertyChanged("ASTaxDeclaration");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASTransporter { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTransporter
        {
            get { return _ASTransporter; }
            set
            {
                if (_ASTransporter != value)
                {
                    _ASTransporter = value; RaisePropertyChanged("ASTransporter");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASBillAdddress { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBillAdddress
        {
            get { return _ASBillAdddress; }
            set
            {
                if (_ASBillAdddress != value)
                {
                    _ASBillAdddress = value; RaisePropertyChanged("ASBillAdddress");
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
        private AutoSuggestTextViewModel<dynamic> _ASOurBank { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASOurBank
        {
            get { return _ASOurBank; }
            set
            {
                if (_ASOurBank != value)
                {
                    _ASOurBank = value; RaisePropertyChanged("ASOurBank");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASNastroBank { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASNastroBank
        {
            get { return _ASNastroBank; }
            set
            {
                if (_ASNastroBank != value)
                {
                    _ASNastroBank = value; RaisePropertyChanged("ASNastroBank");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASwithholding { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASwithholding
        {
            get { return _ASwithholding; }
            set
            {
                if (_ASwithholding != value)
                {
                    _ASwithholding = value; RaisePropertyChanged("ASwithholding");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASCostCentre { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCostCentre
        {
            get { return _ASCostCentre; }
            set
            {
                if (_ASCostCentre != value)
                {
                    _ASCostCentre = value; RaisePropertyChanged("ASCostCentre");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCustNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCustNo
        {
            get { return _ASCustNo; }
            set
            {
                if (_ASCustNo != value)
                {
                    _ASCustNo = value; RaisePropertyChanged("ASCustNo");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASPlant { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPlant
        {
            get { return _ASPlant; }
            set
            {
                if (_ASPlant != value)
                {
                    _ASPlant = value; RaisePropertyChanged("ASPlant");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASCFAgent { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCFAgent
        {
            get { return _ASCFAgent; }
            set
            {
                if (_ASCFAgent != value)
                {
                    _ASCFAgent = value; RaisePropertyChanged("ASCFAgent");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASEPCG { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASEPCG
        {
            get { return _ASEPCG; }
            set
            {
                if (_ASEPCG != value)
                {
                    _ASEPCG = value; RaisePropertyChanged("ASEPCG");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASAdvance { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAdvance
        {
            get { return _ASAdvance; }
            set
            {
                if (_ASAdvance != value)
                {
                    _ASAdvance = value; RaisePropertyChanged("ASAdvance");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASProductDes { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASProductDes
        {
            get { return _ASProductDes; }
            set
            {
                if (_ASProductDes != value)
                {
                    _ASProductDes = value; RaisePropertyChanged("ASProductDes");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASSalesOrg { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSalesOrg
        {
            get { return _ASSalesOrg; }
            set
            {
                if (_ASSalesOrg != value)
                {
                    _ASSalesOrg = value; RaisePropertyChanged("ASSalesOrg");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASSalesGroup { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSalesGroup
        {
            get { return _ASSalesGroup; }
            set
            {
                if (_ASSalesGroup != value)
                {
                    _ASSalesGroup = value; RaisePropertyChanged("ASSalesGroup");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASdgShipToParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASdgShipToParty
        {
            get { return _ASdgShipToParty; }
            set
            {
                if (_ASdgShipToParty != value)
                {
                    _ASdgShipToParty = value; RaisePropertyChanged("ASdgShipToParty");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASReportData { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASReportData
        {
            get { return _ASReportData; }
            set
            {
                if (_ASReportData != value)
                {
                    _ASReportData = value; RaisePropertyChanged("ASReportData");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASFltrt_status { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFltrt_status
        {
            get { return _ASFltrt_status; }
            set
            {
                if (_ASFltrt_status != value)
                {
                    _ASFltrt_status = value; RaisePropertyChanged("ASFltrt_status");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASFltrSoldToParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFltrSoldToParty
        {
            get { return _ASFltrSoldToParty; }
            set
            {
                if (_ASFltrSoldToParty != value)
                {
                    _ASFltrSoldToParty = value; RaisePropertyChanged("ASFltrSoldToParty");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASTaxTransporter { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTaxTransporter
        {
            get { return _ASTaxTransporter; }
            set
            {
                if (_ASTaxTransporter != value)
                {
                    _ASTaxTransporter = value; RaisePropertyChanged("ASTaxTransporter");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASHBcode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASHBcode
        {
            get { return _ASHBcode; }
            set
            {
                if (_ASHBcode != value)
                {
                    _ASHBcode = value; RaisePropertyChanged("ASHBcode");
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
                    if (SourceName == "ItemCode")
                    { ASDefault = ASItems; }
                    else if (SourceName == "unit_code")
                    { ASDefault = ASUOM; }
                    else if (SourceName == "weight_unit")
                    { ASDefault = ASWTUnit; }
                    else if (SourceName == "volume_unit")
                    { ASDefault = ASVolUOM; }
                    else if (SourceName == "curr_code")
                    { ASDefault1 = ASdgCurrency; }
                    else if (SourceName == "gl_code")
                    { ASDefault1 = ASTaxacc; }
                    else if (SourceName == "con_type")
                    { ASDefault1 = ASConditionType; }
                    else if (SourceName == "ship_to_Party")
                    { ASDefault = ASdgShipToParty; }
                    else if (SourceName == "TransporterId")
                    { ASDefault1 = ASTaxTransporter; }
                }
            }
        }

        #endregion

        #region Variable Declaration 
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }

        private string _Barcode;
        public string Barcode
        {
            get
            {
                return _Barcode;
            }
            set
            {
                if (_Barcode != value)
                {
                    _Barcode = value;
                    RaisePropertyChanged("Barcode");
                    //BarcodeScanned(_Barcode);
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

        private bool _isNewRecord;
        public bool isNewRecord
        {
            get { return _isNewRecord; }
            set
            {
                if (_isNewRecord != value)
                {
                    _isNewRecord = value;
                    RaisePropertyChanged("isNewRecord");
                }
            }
        }
        string PreviousUnitCode = "";
        string NewUnitCode = "";

        NUMBER_TO_WORDS_CONVERTER NOW_OBJ = new NUMBER_TO_WORDS_CONVERTER();
        clsChangeNumericToWords NumToWord = new clsChangeNumericToWords();
        WebServiceRepository<SEL_T003> REPO = new WebServiceRepository<SEL_T003>();
        WebServiceRepository<MC_SEL_T003> REPO_MC = new WebServiceRepository<MC_SEL_T003>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MC_SEL_T003 _MC = new MC_SEL_T003();
        public MC_SEL_T003 MC
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

        private MC_SEL_T003 _MC_TEMP = new MC_SEL_T003();
        public MC_SEL_T003 MC_TEMP
        {
            get { return _MC_TEMP; }
            set
            {
                if (_MC_TEMP != value)
                {
                    _MC_TEMP = value; RaisePropertyChanged("MC_TEMP");
                }
            }
        }
        
        private STD_DOC_TYPE _DOC_TYPE_OBJ;
        public STD_DOC_TYPE DOC_TYPE_OBJ
        {
            get { return _DOC_TYPE_OBJ; }
            set
            {
                if (_DOC_TYPE_OBJ != value)
                {
                    _DOC_TYPE_OBJ = value;
                    RaisePropertyChanged(nameof(DOC_TYPE_OBJ));
                }
            }
        }

        private SEL_T003 _MasterEntity;
        public SEL_T003 MasterEntity
        {
            get { return _MasterEntity; }
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

        private ObservableCollection<SEL_T003_A> _ItemsEntity;
        public ObservableCollection<SEL_T003_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value; RaisePropertyChanged("ItemsEntity");
                    ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CCN_ITEM);
                }
            }

        }

        private ObservableCollection<ACC_T006_C> _ConditionEntity;
        // All Document Taxes including Parent,Child & External
        public ObservableCollection<ACC_T006_C> ConditionEntity
        {
            get
            {
                return _ConditionEntity;
            }
            set
            {
                _ConditionEntity = value;
                ConditionEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CCN_CONDITION);
                RaisePropertyChanged("ConditionEntity");
            }
        }

        private ObservableCollection<MM_T001_B> _BatchEntity;
        public ObservableCollection<MM_T001_B> BatchEntity
        {
            get
            {
                return _BatchEntity;
            }
            set
            {
                _BatchEntity = value;
                RaisePropertyChanged("BatchEntity");
            }
        }
        private ObservableCollection<GEN_T011> _TermsConditionEntity;
        public ObservableCollection<GEN_T011> TermsConditionEntity
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
        private GEN_T011 _TCEntityObject;
        public GEN_T011 TCEntityObject
        {
            get
            {
                return _TCEntityObject;
            }
            set
            {
                if (_TCEntityObject != value)
                {
                    _TCEntityObject = value;
                    RaisePropertyChanged("TCEntityObject");
                }
            }
        }
        private SEL_T003_A _ITEM_OBJ;
        public SEL_T003_A ITEM_OBJ
        {
            get
            {
                return _ITEM_OBJ;
            }
            set
            {
                if (_ITEM_OBJ != value)
                {
                    _ITEM_OBJ = value;
                    RaisePropertyChanged(nameof(ITEM_OBJ));
                }
            }
        }

        private ACC_T006_C _CONDITION_OBJ;
        public ACC_T006_C CONDITION_OBJ
        {
            get
            {
                return _CONDITION_OBJ;
            }
            set
            {
                if (_CONDITION_OBJ != value)
                {
                    _CONDITION_OBJ = value;
                    RaisePropertyChanged(nameof(CONDITION_OBJ));
                }
            }
        }

        private MM_T001_B _BATCH_OBJ;
        public MM_T001_B BATCH_OBJ
        {
            get
            {
                return _BATCH_OBJ;
            }
            set
            {
                if (_BATCH_OBJ != value)
                {
                    _BATCH_OBJ = value;
                    RaisePropertyChanged(nameof(BATCH_OBJ));
                }
            }
        }

        private STD_REQ_PARA_BE _REQUEST_OBJ;
        public STD_REQ_PARA_BE REQUEST_OBJ
        {
            get { return _REQUEST_OBJ; }
            set
            {
                if (_REQUEST_OBJ != value)
                {
                    _REQUEST_OBJ = value;

                    RaisePropertyChanged("REQUEST_OBJ");
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

        private STD_PARTY _PARTY_OBJ;
        public STD_PARTY PARTY_OBJ
        {
            get
            {
                return _PARTY_OBJ;
            }
            set
            {
                if (_PARTY_OBJ != value)
                {
                    _PARTY_OBJ = value;
                    RaisePropertyChanged(nameof(PARTY_OBJ));
                }
            }
        }
        private FICO_M0004 _BANK_ACC_OBJ;
        public FICO_M0004 BANK_ACC_OBJ
        {
            get
            {
                return _BANK_ACC_OBJ;
            }
            set
            {
                if (_BANK_ACC_OBJ != value)
                {
                    _BANK_ACC_OBJ = value;
                    RaisePropertyChanged(nameof(BANK_ACC_OBJ));
                }
            }
        }
        private ADM_M0013 _STATUS_OBJ;
        public ADM_M0013 STATUS_OBJ
        {
            get
            {
                return _STATUS_OBJ;
            }
            set
            {
                if (_STATUS_OBJ != value)
                {
                    _STATUS_OBJ = value;
                    RaisePropertyChanged(nameof(STATUS_OBJ));
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_TERMS_CONDITION { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_TERMS_CONDITION
        {
            get { return _AS_TERMS_CONDITION; }
            set
            {
                if (_AS_TERMS_CONDITION != value)
                {
                    _AS_TERMS_CONDITION = value; RaisePropertyChanged("AS_TERMS_CONDITION");
                }
            }
        }
        private ICollectionView _TermsConditionCollection;
        public ICollectionView TermsConditionCollection
        {
            get { return _TermsConditionCollection; }
            set { _TermsConditionCollection = value; RaisePropertyChanged("TermsConditionCollection"); }
        }
        #endregion

        #region Filter For Flip Grid

        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }
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
            if (_BACKFLIP_COLLECTION != null)
            {
                _BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool FLTR_BACKFLIP(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FLTR_STR_BACKFLIP))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.valid_from != null && data.valid_from.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.short_text != null && data.short_text.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.cat_name != null && data.cat_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.t_display != null && data.t_display.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.cat_name != null && data.cat_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion


        #region Relay Commands Declaration
        public RelayCommand<object> cmdManageCustomer { get; private set; }
        public RelayCommand<object> cmdBarcodeScanned { get; private set; }
        public RelayCommand<object> cmdSelectionChangedItem { get; private set; }
        public RelayCommand<object> cmdRemoveItem { get; private set; }
        public RelayCommand<object> cmdCancel { get; private set; }
        public RelayCommand<object> cmdCheckout { get; private set; }
        public RelayCommand<object> cmdPrintInvoice { get; private set; }
        public RelayCommand<object> cmdPrintReceipt { get; private set; }
        public RelayCommand<object> cmdSave { get; private set; }

        public RelayCommand<object> cmdRoundUpManual { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdPrintReport { get; private set; }
        public RelayCommand<object> cmdRevertValidation { get; private set; }
        public RelayCommand<object> cmdLoadDocument { get; private set; }
        public RelayCommand<object> cmdLoadBackFlipData { get; private set; }
        public RelayCommand<GEN_T011> cmdDeleteDataGridTerms { get; private set; }
        public RelayCommand<object> cmdSCH_GEN_T011 { get; private set; }
        public RelayCommand<object> cmdInsertTermsConditions { get; private set; }
        public RelayCommand<object> cmdInsertTermsConditions2 { get; private set; }
        #endregion

        #region Constructor 
        public FICO_T002_VM_POS(string ts_code, string doc_cat) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;
            MC = new MC_SEL_T003();
            MC_TEMP = new MC_SEL_T003();
            MasterEntity = new SEL_T003();
            ItemsEntity = new ObservableCollection<SEL_T003_A>();
            ConditionEntity = new ObservableCollection<ACC_T006_C>();
            TermsConditionEntity = new ObservableCollection<GEN_T011>();
            ITEM_OBJ = new SEL_T003_A();
            CONDITION_OBJ = new ACC_T006_C();
            BATCH_OBJ = new MM_T001_B();
            PARTY_OBJ = new STD_PARTY();
            BANK_ACC_OBJ = new FICO_M0004();
            STATUS_OBJ = new ADM_M0013();
            DOC_TYPE_OBJ = new STD_DOC_TYPE();
            REQUEST_OBJ = new STD_REQ_PARA_BE();
            TCEntityObject = new GEN_T011();
            SEL_T003.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            SEL_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            ACC_T006_C.ModelEntityUpdated += new EventHandler(ModelUpdated_Tax);
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CCN_ITEM);
            ConditionEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCN_CONDITION);
            CommandInitialization();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public FICO_T002_VM_POS(string ts_code, string doc_cat,  string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;
            this.doc_no_vm = doc_no;
            MC = new MC_SEL_T003();
            MC_TEMP = new MC_SEL_T003();
            MasterEntity = new SEL_T003();
            ItemsEntity = new ObservableCollection<SEL_T003_A>();
            ConditionEntity = new ObservableCollection<ACC_T006_C>();
            TermsConditionEntity = new ObservableCollection<GEN_T011>();
            ITEM_OBJ = new SEL_T003_A();
            CONDITION_OBJ = new ACC_T006_C();
            BATCH_OBJ = new MM_T001_B();
            PARTY_OBJ = new STD_PARTY();
            BANK_ACC_OBJ = new FICO_M0004();
            STATUS_OBJ = new ADM_M0013();
            DOC_TYPE_OBJ = new STD_DOC_TYPE();
            REQUEST_OBJ = new STD_REQ_PARA_BE();
            TCEntityObject = new GEN_T011();
            SEL_T003.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            SEL_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            ACC_T006_C.ModelEntityUpdated += new EventHandler(ModelUpdated_Tax);
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CCN_ITEM);
            ConditionEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCN_CONDITION);
            CommandInitialization();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        #endregion

        #region User Defined Functions
        private void DefaultValues()
        {
            EntityChangeEnable = true;
            PARTY_OBJ = MC.PARTY_LIST.Where(x => x.ind_otp == "Y" || x.ind_otp == "Yes").FirstOrDefault();
            BANK_ACC_OBJ = MC.BANK_ACCOUNT_LIST.Where(x => x.ind_default == true).FirstOrDefault();
            STATUS_OBJ = MC.STATUS_LIST.Where(x => x.ind_default == "1").FirstOrDefault();// NOTE: make default compulsoary in Master or system master
            DOC_TYPE_OBJ = (from o in MC.DOC_TYPE_LIST where o.doc_cat == doc_cat_vm && o.default_doc == true select o).FirstOrDefault(); // NOTE: make default compulsoary in Master or system master

            if(MC.PAYTERM_LIST != null)
            {
                if (MC.PAYTERM_LIST.Count > 0)
                {
                    STD_LIST_BE PT_OBJ = MC.PAYTERM_LIST.Where(x => x.ind_default == "1").FirstOrDefault();
                    MasterEntity.pt_code = PT_OBJ.pt_code;
                    MasterEntity.pt_name = PT_OBJ.pt_name;
                }
            }
            

            if (PARTY_OBJ != null)
            {
                MasterEntity.t_status = STATUS_OBJ.t_status;
                MasterEntity.t_display = STATUS_OBJ.t_display;
            }
            
            if (PARTY_OBJ != null)
            {
                MasterEntity.PartyId = PARTY_OBJ.party_code;
                MasterEntity.party_code = PARTY_OBJ.party_code;
                MasterEntity.sold_to_party_name = PARTY_OBJ.party_name;
                MasterEntity.payer = PARTY_OBJ.party_code;
                MasterEntity.payer_name = PARTY_OBJ.party_name;
                MasterEntity.party_code_bil = PARTY_OBJ.party_code;
                MasterEntity.party_code_del = PARTY_OBJ.party_code;
                MasterEntity.add_code_bil = PARTY_OBJ.add_code_new;
                MasterEntity.add_code_del = PARTY_OBJ.add_code_new;
                MasterEntity.bill_address_id = PARTY_OBJ.id;
                MasterEntity.cp_code = PARTY_OBJ.cp_code_new;
            }

            MasterEntity.so_code = AppSessionState.so_code;
            MasterEntity.sg_code = AppSessionState.sg_code;

            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_cat = doc_cat_vm;
            MasterEntity.doc_type = (MasterEntity.doc_type ?? doc_cat_vm);

            MasterEntity.bill_cat = doc_cat_vm;
            MasterEntity.bill_type = (MasterEntity.doc_type ?? doc_cat_vm);
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.emp_id = AppSessionState.EmpId;
            MasterEntity.para1 = AppSessionState.EmpId;
            MasterEntity.emp_name = AppSessionState.EmpName;
            MasterEntity.active = true;
            MasterEntity.curr_code = AppSessionState.OBJ_COMPANY.curr_code;
            MasterEntity.lc_curr = AppSessionState.OBJ_COMPANY.curr_code;

            
            if (DOC_TYPE_OBJ != null)
            {
                MasterEntity.doc_type = DOC_TYPE_OBJ.doc_type;
                MasterEntity.doc_desc = DOC_TYPE_OBJ.doc_type_name;
            }

            if (BANK_ACC_OBJ != null)
            {
                MasterEntity.acc_no = BANK_ACC_OBJ.acc_no;
                MasterEntity.hb_acc = BANK_ACC_OBJ.hb_acc;
            }


            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.post_date = DateTime.Now;
            MasterEntity.entry_time = new TimeSpan();
            MasterEntity.entry_time = DateTime.Now.TimeOfDay;


            MasterEntity.ind_trade = "L"; // NOTE: This is now temp value, replace with logic as per customer country and our country. for this set customer entity object for this purpose or for any other. add one customer,contact person and address object ans set on selection of customer or in default values.
            MasterEntity.export_ind = "L";


            if (TermsConditionEntity != null)
            {
                if (TermsConditionEntity.Count <= 0)
                {
                    foreach (var item in MC.CONDITION_LIST)
                    {
                        //NOTE: Need to add group module and category assignment then make it perfect. now we vahe to add same condition for SN,QN & SO because of limit to doc_cat only.
                        if (item.ind_man == "1" && item.doc_cat == (doc_cat_vm ?? MasterEntity.doc_cat)) // NOTE: make perfect logic as then add this kind of code.  && item.doc_cat == (MasterEntity.doc_cat ?? doc_cat_vm)
                        {
                            //TCEntityObject = new GEN_T011();
                            //TermsConditionEntity.Add(TCEntityObject);
                            item.selected = true;
                            InsertTermsConditions(item.tc_code);
                        }
                    }
                }
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
        private void LoadInitialData()
        {
            try
            {
                isNewRecord = true;
                string Request = "LOAD_INI_POS" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@" + Convert.ToDateTime(DateTime.Now).ToString("MM/dd/yyyy") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + this.ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@!@" + AppSessionState.OBJ_COMPANY.curr_code;
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_SEL_T003>(MC, Request, "SEL_T003_BL_DEV", "FICO", "LoadAll", 0, "");

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code);
                TheFilter = (o, prefix) => (((STD_ITEM)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).barcode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).batch_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).ean_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ITEM = new AutoSuggestTextViewModel<dynamic>(MC.ITEM_LIST, TheFilter, SuggestedValue, "item_code", true);
                AS_ITEM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ITEM.AutoSuggestVM.IsFreeTextAllowed = true;

                TermsConditionCollection = CollectionViewSource.GetDefaultView(MC.CONDITION_LIST);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0051)x).tc_code);
                TheFilter = (o, prefix) => (((ADM_M0051)o).tc_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0051)o).con_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0051)o).long_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_TERMS_CONDITION = new AutoSuggestTextViewModel<dynamic>(MC.CONDITION_LIST, TheFilter, SuggestedValue, "tc_code", "tc_code", true);
                AS_TERMS_CONDITION.AutoSuggestVM.IsEmptyValueAllowed = true;

            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void LoadBackFlipData(object ParameterObject, string ParameterReference)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (REQUEST_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + (REQUEST_OBJ.doc_type ?? doc_cat_vm) + "!@!@!@" + ((REQUEST_OBJ.emp_id ?? MasterEntity.emp_id) ?? AppSessionState.EmpId) + "!@!@!@!@!@!@" + REQUEST_OBJ.active + "!@" + (REQUEST_OBJ.t_status ?? "") + "!@" + Convert.ToDateTime(REQUEST_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQUEST_OBJ.to_date).ToString("MM/dd/yyyy");
                MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_SEL_T003>(MC, Request, "SEL_T003_BL_DEV", "FICO", "LOAD_BACKFLIP", 0, "");

                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC_TEMP.BACK_FLIP_LIST.ToList());
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(FLTR_BACKFLIP);

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); 
            }

        }
       
        private void CommandInitialization()
        {
            CursorControl.SetBusyState();
            try
            {
                #region Command Initialisation
                cmdManageCustomer = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } ManageCustomer(cmdPara); });
                cmdBarcodeScanned = new RelayCommand<object>(items => { if (items == null) { return; } BarcodeScanned(items); });
                cmdSelectionChangedItem = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChangedItem(items); });
                cmdRemoveItem = new RelayCommand<object>(items => { if (items == null) { return; } RemoveItem(items); });
                cmdCancel = new RelayCommand<object>(items => { if (items == null) { return; } Cancel(items); });
                cmdCheckout = new RelayCommand<object>(items => { if (items == null) { return; } Checkout(items); });
                cmdPrintInvoice = new RelayCommand<object>(items => { if (items == null) { return; } PrintInvoice(items); });
                cmdPrintReceipt = new RelayCommand<object>(items => { if (items == null) { return; } PrintReceipt(items); });
                cmdSave = new RelayCommand<object>(items => { if (items == null) { return; } SaveRecord(items); });
                

                cmdRoundUpManual = new RelayCommand<object>(items => { if (items == null) { return; } InsertRoundUpManual(items, isNewRecord); });
                //cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdLoadDocument = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocument(cmdPara, "FlipGridReference"); });
                cmdLoadBackFlipData = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadBackFlipData(cmdPara, "FlipGridReference"); });
                cmdDeleteDataGridTerms = new RelayCommand<GEN_T011>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Terms(cmdPara); });
                cmdSCH_GEN_T011 = new RelayCommand<object>(items => { if (items == null) { return; } SCH_GEN_T011(items); });
                cmdInsertTermsConditions = new RelayCommand<object>(items => { if (items == null) { return; } InsertTermsConditions(items); });
                cmdInsertTermsConditions2 = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTermsConditions2(cmdPara); });
                #endregion
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }

        private void ManageCustomer(object InputValue)
        {
            try
            {
                STD_LIST_BE PARA_OBJ = new STD_LIST_BE();
                if(MasterEntity != null)
                {
                    if (!string.IsNullOrEmpty(MasterEntity.PartyId))
                    {
                        PARA_OBJ.party_code = MasterEntity.PartyId;
                        PARA_OBJ.add_code = MasterEntity.add_code_bil;
                        PARA_OBJ.add_code_del = MasterEntity.add_code_del;
                        PARA_OBJ.cp_code = MasterEntity.cp_code;
                        PARA_OBJ.client = AppSessionState.client;
                        PARA_OBJ.comp_code = (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code);
                        PARA_OBJ.location_id = (MasterEntity.location_Id ?? AppSessionState.OBJ_LOCATION.location_id);
                    }
                }

                CursorControl.SetBusyState();

                AppSessionState.ViewTitle = "New Account";
                AppSessionState.TransactionCode = "SD101";

                string path1 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.SDM.dll"); // this one is path option
                Assembly assembly = Assembly.LoadFile(path1);
                Type type = assembly.GetType("Reflection.Modules.SDM.Views.SDM_M0021");
                if (type != null)
                {
                    dynamic instance = Activator.CreateInstance(type, AppSessionState.TransactionCode, PARA_OBJ);
                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void BarcodeScanned(object InputValue)
        
        {
            try
            {
                //EPR_T003_A_P POPUPEntityObject = null;
                string barcode = InputValue.ToString();

                if (!string.IsNullOrWhiteSpace(barcode)) // condition change from Fix 9 to from DB
                {
                    InsertMaterial(InputValue, "Scan");
                }
                Barcode = "";
            }
            catch (Exception ex)
            { MessageBox.Show(ex.Message); }
        }
        private void InsertMaterial(object InputValue, string InputSource) // NOTE: do not allow to add Material without MasterEntity fields like comp_code,Location etc.
        {
            try
            {
                string Request = "";
                STD_ITEM SELECTED_OBJ = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { SELECTED_OBJ = MC.ITEM_LIST.Where(x => x.item_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || (x.barcode ?? "").Equals(Request, StringComparison.OrdinalIgnoreCase) == true || (x.batch_no ?? "").Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0] ; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_ITEM>().Count() > 0)
                    {
                        SELECTED_OBJ = ((IEnumerable)InputValue).Cast<STD_ITEM>().ToList()[0];
                    }
                }
                #endregion
                
                if (SELECTED_OBJ != null) 
                {
                    //var InputValueIfExists = ItemsEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                    //int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());

                    if (InputSource == "Scan") // if item added by scan event then new row need to add first.
                    {
                        //MM_T001_A OBJ_TEMP = new MM_T001_A();
                        //OBJ_TEMP = ITEM_OBJ;
                        ITEM_OBJ = new SEL_T003_A();
                        //ITEM_OBJ = OBJ_TEMP;
                        ITEM_OBJ.id = 0;
                    }
                    if (ITEM_OBJ.line_id == 0)
                    {
                        if(ItemsEntity.Count==0)
                        {
                            ITEM_OBJ.line_id = 1;
                        }
                        else
                        {
                            int MaxNo = ItemsEntity.Where(x => x.line_id != 0).Max(x => x.line_id);
                            ITEM_OBJ.line_id = MaxNo + 1;
                        }
                    }
                    ITEM_OBJ.ItemCode = SELECTED_OBJ.item_code;
                    ITEM_OBJ.description = SELECTED_OBJ.item_name;
                    ITEM_OBJ.item_desc = SELECTED_OBJ.item_name;
                    ITEM_OBJ.unit_code = SELECTED_OBJ.unit_code;
                    ITEM_OBJ.StockUnt = SELECTED_OBJ.ind_sku;
                    ITEM_OBJ.tax_id = SELECTED_OBJ.tax_id;
                    ITEM_OBJ.unit_price = SELECTED_OBJ.unit_price;
                    ITEM_OBJ.qty_price = 1;
                    ITEM_OBJ.price_qty = SELECTED_OBJ.unit_price;
                    ITEM_OBJ.price_qty_uom = SELECTED_OBJ.unit_code;
                    ITEM_OBJ.active = true;
                    ITEM_OBJ.location_Id = MasterEntity.location_Id;
                    ITEM_OBJ.comp_code = MasterEntity.comp_code;
                    ITEM_OBJ.client = AppSessionState.client;
                    ITEM_OBJ.item_cat = SELECTED_OBJ.item_cat;
                    //ITEM_OBJ.store_code = null; // store_location; // add as above
                    ITEM_OBJ.qty = 1; 
                    ITEM_OBJ.doc_cat = MasterEntity.doc_cat;
                    ITEM_OBJ.t_status = MasterEntity.t_status;
                    ITEM_OBJ.t_display = MasterEntity.t_display;
                    ITEM_OBJ.weight_unit = MasterEntity.weight_unit;
                    ITEM_OBJ.volume_unit = MasterEntity.volume_unit;
                    ITEM_OBJ.country_code = MasterEntity.country_code;
                    ITEM_OBJ.so_code = MasterEntity.so_code;
                    ITEM_OBJ.sg_code = MasterEntity.sg_code;


                    if (InputSource == "Scan")
                    {
                        ItemsEntity.Add(ITEM_OBJ);
                    }
                    foreach (var item in ItemsEntity)
                    {
                        Computation(item, (bool)DOC_TYPE_OBJ.auto_roundup, (int)DOC_TYPE_OBJ.roundup_digits);
                    }
                }
            }
            catch (Exception ex)
            {  }
        }
        private void SelectionChangedItem(object InputValue)
        {
            try
            {
                if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SEL_T003_A>().ToList().Count > 0)
                    {
                        if (ITEM_OBJ.line_id != ((IEnumerable)InputValue).Cast<SEL_T003_A>().ToList()[0].line_id)
                        {
                            ITEM_OBJ = ((IEnumerable)InputValue).Cast<SEL_T003_A>().ToList()[0];
                        }
                    }
                }
            }
            catch (Exception ex)
            { /*sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();*/ }
        }
        private void RemoveItem(object InputValue)
        {
            try
            {
                if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SEL_T003_A>().ToList().Count > 0)
                    {
                        foreach (var item in ((IEnumerable)InputValue).Cast<SEL_T003_A>().ToList())
                        {
                            if(item.id > 0)
                            {
                                item.active = false;
                            }
                            else
                            {
                                foreach (var item_obj in ConditionEntity.ToList())
                                {
                                    if (item_obj.id > 0 && item_obj.item_line_id == item.line_id && item_obj.item_row_id  == item.id)
                                    {
                                        item_obj.active = false;
                                    }
                                    else if(item_obj.id == 0 && item_obj.item_line_id == item.line_id && item_obj.item_row_id == item.id)
                                    {
                                        ConditionEntity.Remove(item_obj);
                                    }
                                }
                                ItemsEntity.Remove(item);
                                ////ConditionEntity.Remove(x => x.item_line_id == item.line_id);
                                //foreach (var xx in ConditionEntity.ToList())
                                //{
                                //    ConditionEntity.Remove(xx);
                                //}
                            }
                            
                        }

                        //ObservableCollection<ACC_T006_C> TempObj = new ObservableCollection<ACC_T006_C>();
                        //TempObj = ConditionEntity;

                        
                        foreach (var item in ItemsEntity)
                        {
                            Computation(item, (bool)DOC_TYPE_OBJ.auto_roundup, (int)DOC_TYPE_OBJ.roundup_digits);
                        }
                    }
                }
            }
            catch (Exception ex)
            { /*sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();*/ }
        }
        private void Cancel(object InputValue)
        {
            try
            {
                InquiryActionResult<SEL_T003> result = new WindowViewModel<SEL_T003>.InquiryActionResult<SEL_T003>();
                OnCreateAction(result);
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(MasterEntity, "PAY_CLEAR"));
            }
            catch (Exception ex)
            { /*sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();*/ }
        }
        private void Checkout(object InputValue) // Save invoice and validate
        {
            try
            {
                InquiryActionResult<SEL_T003> result = new WindowViewModel<SEL_T003>.InquiryActionResult<SEL_T003>();
                //STATUS_OBJ = MC.STATUS_LIST.Where(x => x.ind_default == "1" || x.ind_released == "1").FirstOrDefault();// NOTE: make default compulsoary in Master or system master
                ADM_M0013 STATUS_OBJ_T = MC.STATUS_LIST.Where(x => x.t_status == MasterEntity.t_status).FirstOrDefault();// NOTE: make default compulsoary in Master or system master
                if (STATUS_OBJ_T != null)
                {
                    if(STATUS_OBJ_T.ind_default=="1" || STATUS_OBJ_T.ind_released=="1")
                    {
                        OnSaveAction(result);
                        OnFevoriteAction(result); // NOTE: shift this call on paymnet receipt entry. load pending invoice before save payment means on save payment it will load pendng invoice , pick the required data and then save paymnet. this place not suitable because if cancell before paymnet then it will sho in pending or we need to cancel pending also by revert validation.
                        Messenger.Default.Send<NotificationMessage>(new NotificationMessage(MasterEntity, "POS_PAY"));
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Invoice is already proccessed!", this.Title);
                        showMessageService.ShowMessage();
                    }
                }
                
            }
            catch (Exception ex)
            { /*sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();*/ }
        }
        private void SaveRecord(object InputValue) // Save invoice and validate
        {
            try
            {
                InquiryActionResult<SEL_T003> result = new WindowViewModel<SEL_T003>.InquiryActionResult<SEL_T003>();
                ADM_M0013 STATUS_OBJ_T = MC.STATUS_LIST.Where(x => x.t_status == MasterEntity.t_status).FirstOrDefault();// NOTE: make default compulsoary in Master or system master
                if (STATUS_OBJ_T != null)
                {
                    if (STATUS_OBJ_T.ind_default == "1" || STATUS_OBJ_T.ind_released == "1")
                    {
                        OnSaveAction(result);
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Invoice is already proccessed!", this.Title);
                        showMessageService.ShowMessage();
                    }
                }

            }
            catch (Exception ex)
            { /*sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();*/ }
        }
        
        private void PrintInvoice(object InputValue)
        {
            try
            {
                InquiryActionResult<SEL_T003> result = new WindowViewModel<SEL_T003>.InquiryActionResult<SEL_T003>();
                OnPrintAction(result);
            }
            catch (Exception ex)
            { /*sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();*/ }
        }
        private void PrintReceipt(object InputValue)
        {
            try
            {
                //InquiryActionResult<SEL_T003> result = new WindowViewModel<SEL_T003>.InquiryActionResult<SEL_T003>();
                //OnPrintAction(result);
            }
            catch (Exception ex)
            { /*sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();*/ }
        }
        private void InsertDocType(object InputValue)
        {
            try
            {
                string Request = "";
                STD_DOC_TYPE POPUPEntityObject = null;
                IEnumerable<STD_DOC_TYPE> BEType = new List<STD_DOC_TYPE>();
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DOC_TYPE_LIST.Where(x => x.doc_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_DOC_TYPE>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_DOC_TYPE>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    DOC_TYPE_OBJ = POPUPEntityObject; // NOTE: make default compulsoary in Master or system master

                    MasterEntity.doc_type = POPUPEntityObject.doc_type;
                    MasterEntity.doc_desc = POPUPEntityObject.doc_desc;
                    MasterEntity.doc_cat = POPUPEntityObject.doc_cat;
                    MasterEntity.bill_cat = POPUPEntityObject.doc_cat;
                    MasterEntity.bill_type = POPUPEntityObject.doc_type;
                    doc_cat_vm = POPUPEntityObject.doc_cat;

                    if (ItemsEntity != null)
                    {
                        if (ItemsEntity.Count() > 0)
                        {
                            int count = ItemsEntity.Count();
                            ConditionEntity.Clear();
                            for (int i = 0; i < count; i++)
                            {
                                Computation(ITEM_OBJ, (bool)DOC_TYPE_OBJ.auto_roundup, (int)DOC_TYPE_OBJ.roundup_digits);
                            }
                        }
                    }
                }
            }
            catch (Exception Ex) { }
        }
        private void GoodsPosting()
        {
            try
            {
                CursorControl.SetBusyState();
                MM_T001 OBJ_MM_T001 = new MM_T001();
                List<MM_T001_A> OBJ_MM_T001_A = new List<MM_T001_A>();
                List<MM_T001_B> OBJ_MM_T001_B = new List<MM_T001_B>();

                if (!string.IsNullOrWhiteSpace(MasterEntity.bill_doc) && ItemsEntity.Count > 0 && MasterEntity.ind_post != "Y")
                {
                    OBJ_MM_T001 = new MM_T001();
                    OBJ_MM_T001.comp_code = MasterEntity.comp_code;
                    OBJ_MM_T001.doc_date = MasterEntity.bill_date ?? DateTime.Now;
                    OBJ_MM_T001.doc_code = "DI";
                    OBJ_MM_T001.doc_cat = "DI";
                    OBJ_MM_T001.sending_plant = MasterEntity.location_Id;
                    OBJ_MM_T001.source_doc_cat = MasterEntity.doc_cat;
                    OBJ_MM_T001.source_doc_type = MasterEntity.doc_type;
                    OBJ_MM_T001.source_doc_no = MasterEntity.bill_doc;
                    OBJ_MM_T001.PartyId = MasterEntity.PartyId;
                    OBJ_MM_T001.post_date = MasterEntity.bill_date ?? DateTime.Now;
                   
                    OBJ_MM_T001.receipt_date = MasterEntity.bill_date ?? DateTime.Now;
                    OBJ_MM_T001.tr_mode = MasterEntity.tr_mode;
                    OBJ_MM_T001.tr_party = MasterEntity.tr_party;
                    OBJ_MM_T001.entry_time = DateTime.Now.TimeOfDay;
                    OBJ_MM_T001.ref_doc = MasterEntity.bill_doc;
                    OBJ_MM_T001.ref_doc_date = MasterEntity.bill_date;
                    //OBJ_MM_T001.time_zone = // Note: not yet integrated
                    OBJ_MM_T001.mov_tp = DOC_TYPE_OBJ.mov_tp_mi ?? "105"; //105 Goods Issue for Sale
                    OBJ_MM_T001.EmpId = MasterEntity.emp_id;
                    //OBJ_MM_T001.dept_code = AppSessionState.d; // Note: not exists
                    OBJ_MM_T001.active = true;
                    OBJ_MM_T001.add_by = AppSessionState.UserID;
                    OBJ_MM_T001.userid = AppSessionState.UserID;
                    OBJ_MM_T001.t_status = MasterEntity.t_status; // Note: set proper logic for this doc_cat. do not assign status of other doc_cat.
                    OBJ_MM_T001.location_Id = MasterEntity.location_Id;
                    OBJ_MM_T001.doc_type = "DI";
                    OBJ_MM_T001.curr_code = MasterEntity.curr_code;
                    OBJ_MM_T001.amt_doccurr = MasterEntity.net_value;
                    OBJ_MM_T001.ex_rate = MasterEntity.exc_rate;
                    OBJ_MM_T001.client = AppSessionState.client;
                    OBJ_MM_T001.lang_key = AppSessionState.UserLanguage;
                    OBJ_MM_T001.ts_code = (from o in MC.DOCTYPE_LIST where o.doc_cat == MasterEntity.doc_cat select o.ts_code_mi).FirstOrDefault();
                    OBJ_MM_T001.session_id = AppSessionState.session_id;

                    DOC_TYPE_OBJ.store_code = (DOC_TYPE_OBJ.store_code ?? "001"); // NOTE: temp, remove once added logic in DB and VM.
                    foreach (var item in ItemsEntity)
                    {
                        if (item.active == true)
                        {
                            OBJ_MM_T001_A.Add(new MM_T001_A()
                            {
                                line_id = OBJ_MM_T001_A.Count() + 1,
                                comp_code = item.comp_code,
                                doc_date = MasterEntity.bill_date ?? DateTime.Now,
                                doc_cat = "DI",
                                doc_type = "DI",
                                mov_tp = OBJ_MM_T001.mov_tp,
                                //wa_code = item.wa_code,
                                store_code = item.store_code ?? DOC_TYPE_OBJ.store_code, // NOTE: need to fixed
                                batch_no = item.batch,
                                ItemCode = item.ItemCode,
                                sku = item.sku,
                                sku_desc = item.sku_desc,
                                PartyId = MasterEntity.PartyId,
                                curr_code = item.curr_code,
                                qty = item.qty,
                                challan_qty = item.qty,
                                unit_code = item.unit_code,
                                unit_price = item.unit_price,
                                debcr_ind = "D",
                                source_doc_type = MasterEntity.doc_type,
                                source_doc_no = MasterEntity.bill_doc,
                                ref_doc_no = MasterEntity.bill_doc,
                                ref_doc_type = MasterEntity.doc_type,
                                order_doc_type = item.ref_doc_type,
                                order_doc_no = item.order_no,
                                cost_center = item.cost_center,
                                profit_center = item.profit_center,
                                active = true,
                                add_by = AppSessionState.UserID,
                                item_cat = item.item_cat,
                                item_ok = true,
                                t_status = MasterEntity.t_status, // Note: set proper logic for this doc_cat. do not assign status of other doc_cat.,
                                location_Id = item.location_Id,
                                ref_item_line_id = item.line_id,
                                bom_no = item.bom_no,
                                source_doc_itemline_id = item.line_id,
                                lang_key = AppSessionState.UserLanguage,
                                client = AppSessionState.client,
                                post_date = MasterEntity.bill_date ?? DateTime.Now,
                                ref_doc_item_row_id = item.id,
                                ref_doc_cat = MasterEntity.doc_cat,
                                
                            });

                            

                            foreach (var itemBatch in ItemsEntity) // NOTE: temp ItemsEntity because batch split table not exists.
                            {
                                if (item.active == true && !string.IsNullOrWhiteSpace(itemBatch.batch))
                                {
                                    OBJ_MM_T001_B.Add(new MM_T001_B()
                                    {
                                        grn_id = 0,
                                        item_line_id = itemBatch.line_id,
                                        ItemCode = itemBatch.ItemCode,
                                        sr_line_no = OBJ_MM_T001_A.Count(),
                                        batch_no = itemBatch.batch,
                                        qty = itemBatch.qty,
                                        rec_qty = itemBatch.qty,
                                        unit_code = itemBatch.unit_code,
                                        t_status = OBJ_MM_T001.t_status,
                                        location_Id = itemBatch.location_Id,
                                        comp_code = itemBatch.comp_code,
                                        //wa_code = itemBatch.wa_code,
                                        store_code = itemBatch.store_code ?? DOC_TYPE_OBJ.store_code, // NOTE: need to fixed,
                                        active = true,
                                        add_by = AppSessionState.UserID,
                                        sku = itemBatch.sku,
                                        client = AppSessionState.client,
                                        ref_batch_row_id = itemBatch.id,
                                        //pack_no = itemBatch.pack_no,

                                    });
                                }
                            }
                        }
                    }


                    ObjectSerializationService objSer = new ObjectSerializationService();
                    OBJ_MM_T001.XmlDataDocument_MM_T001_A = objSer.ObjectToXML(OBJ_MM_T001_A);
                    OBJ_MM_T001.XmlDataDocument_MM_T001_B = objSer.ObjectToXML(OBJ_MM_T001_B);
                    WebServiceRepository<MM_T001> repositoryMI = new WebServiceRepository<MM_T001>();
                    string reader = repositoryMI.Save<MM_T001>(OBJ_MM_T001, "LOG_T001_BL_POST", "SDM");

                    int intreader = Convert.ToInt32(reader);

                    if (intreader > 0)
                    {
                       
                        MasterEntity.ind_post = "Y";
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
        public List<SEL_T003_A> TempItemList { get; set; }
        private void LoadDocument(object ParameterObject, string ParameterReference)
        {
            try
            {
                EntityChangeEnable = false;
                CursorControl.SetBusyState();
                string Request = "";
                //string ParametersStringValue = "";
                STD_LIST_BE ParameterEntityObject = null;

                if (ParameterObject != null)
                {
                    if (ParameterObject.GetType() == typeof(string) && ParameterReference == "DocumentNo")
                    {
                        Request = "LOAD_DOCUMENT" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + MasterEntity.location_Id + "!@" + this.doc_cat_vm + "!@" + MasterEntity.doc_type + "!@" + ParameterObject.ToString();
                        MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_SEL_T003>(MC_TEMP, Request, "SEL_T003_BL_DEV", "FICO", "", 0, "LOAD_DOCUMENT");
                    }
                    else if (((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList()[0];
                        Request = "LOAD_DOCUMENT" + "!@" + AppSessionState.client + "!@" + (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (MasterEntity.location_Id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + ParameterEntityObject.doc_no + "!@!@!@!@!@!@" + ParameterEntityObject.party_code;
                        MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_SEL_T003>(MC_TEMP, Request, "SEL_T003_BL_DEV", "FICO", "", 0, "LOAD_DOCUMENT");
                    }

                    if (MC_TEMP != null)
                    {
                        if (MC_TEMP.MasterEntity.Count > 0)
                        {
                            MasterEntity = MC_TEMP.MasterEntity[0];
                            MasterEntity.ts_code = ts_code_vm;
                        }
                        if (MC_TEMP.ItemsEntity.Count > 0)
                        {
                            ItemsEntity = MC_TEMP.ItemsEntity;
                        }
                        else
                        {
                            ItemsEntity = new ObservableCollection<SEL_T003_A>();
                        }

                        // NOTE: implementation & Test pending
                        ConditionEntity = MC_TEMP.ConditionEntity;
                  
                        if (ConditionEntity.Count() != '0')
                        {
                            ConditionEntity = MC_TEMP.ConditionEntity;
                        }
                        else
                        {
                            MC.ConditionEntity = new ObservableCollection<ACC_T006_C>();
                        }
                        if (MC_TEMP.TermsAndCondition != null)
                        {
                            TermsConditionEntity = MC_TEMP.TermsAndCondition;
                        }
                        else
                        {
                            TermsConditionEntity = new ObservableCollection<GEN_T011>();
                        }
                    }


                    SelectedTabControlIndex = 0;
                    MasterEntity.ts_code = ts_code_vm;
                    EntityChangeEnable = true;
                    isNewRecord = false;
                    Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        

        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                MasterEntity.ts_code = ts_code_vm;
                if (MasterEntity.XmlDataDocument_SEL_T003_A != null)
                {
                    MC.ItemsEntity = (ObservableCollection<SEL_T003_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_SEL_T003_A, MC.ItemsEntity);
                    ItemsEntity = MC.ItemsEntity;
                }
                else
                {
                    MC.ItemsEntity = new ObservableCollection<SEL_T003_A>();
                    ItemsEntity.Clear();
                }
                if (MasterEntity.XmlDataDocument_ACC_T006_C != null)
                {
                    MC.ConditionEntity = (ObservableCollection<ACC_T006_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_T006_C, MC.ConditionEntity);
                    ConditionEntity.Clear();
                    ConditionEntity = MC.ConditionEntity;
                }
                else
                {
                    MC.ConditionEntity = new ObservableCollection<ACC_T006_C>();
                }
                if (MasterEntity.XDOC_TC != null)
                {
                    MC.TermsAndCondition = (ObservableCollection<GEN_T011>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_TC, MC.TermsAndCondition);
                    TermsConditionEntity = MC.TermsAndCondition;
                }
                else
                {
                    TermsConditionEntity = new ObservableCollection<GEN_T011>();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                
                if (ITEM_OBJ != null)
                {
                    if (ITEM_OBJ.id == 0)
                    {
                        ItemsEntity.Remove(ITEM_OBJ);
                        foreach (var item in ItemsEntity)
                        {
                            Computation(item, (bool)DOC_TYPE_OBJ.auto_roundup, (int)DOC_TYPE_OBJ.roundup_digits);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
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
                    }
                    foreach (var item in ItemsEntity)
                    {
                        Computation(item, (bool)DOC_TYPE_OBJ.auto_roundup, (int)DOC_TYPE_OBJ.roundup_digits);
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                LoadInitialData();
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocument(doc_no_vm, "DocumentNo");
                }
                else
                {
                    DefaultValues();

                    if (REQUEST_OBJ != null)
                    {
                        REQUEST_OBJ.active = true;
                        REQUEST_OBJ.from_date = DateTime.Now;
                        REQUEST_OBJ.to_date = DateTime.Now;
                        REQUEST_OBJ.doc_cat = doc_cat_vm;
                        REQUEST_OBJ.doc_type = (MasterEntity.doc_type ?? doc_cat_vm);
                    }

                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }


        void ModelUpdated_Master(object sender, EventArgs e)
        {
            try
            {
            }
            catch
            { }
        }
       
       
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            if (EntityChangeEnable == true)
            {
                if (sender.ToString() == "line_id" || sender.ToString() == "qty" || sender.ToString() == "unit_price" || sender.ToString() == "tax_id" || sender.ToString() == "active" || sender.ToString() == "discount_type" || sender.ToString() == "discount" || sender.ToString() == "discount_amt")
                {
                    Computation(ITEM_OBJ, (bool)DOC_TYPE_OBJ.auto_roundup, (int)DOC_TYPE_OBJ.roundup_digits);//this is in use 
                }
                if (sender.ToString() == "gross_wt")
                {
                    MasterEntity.gross_wt = ItemsEntity.Where(item => item.active != false).Sum(item => item.gross_wt);
                }
                if (sender.ToString() == "volume")
                {
                    MasterEntity.volume = ItemsEntity.Where(item => item.active != false).Sum(item => item.volume);
                }
                if (sender.ToString() == "net_wt")
                {
                    MasterEntity.net_wt = ItemsEntity.Where(item => item.active != false).Sum(item => item.net_wt);
                }

                
            }
        }
        void ModelUpdated_Tax(object sender, EventArgs e) // make this function on lost focus because it is throwing overflow exception
        {
            //foreach (var item in ItemsEntity)
            //{
            //    Computation(item, (bool)DOC_TYPE_OBJ.auto_roundup, (int)DOC_TYPE_OBJ.roundup_digits);
            //}
        }
        private void CCN_CONDITION(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add) //  && ItemsEntity.Count > 0
                {
                    foreach (ACC_T006_C item in e.NewItems)
                    {

                        if (item.tax_code_id > 0)
                        { item.manual = "Auto"; item.con_type = "TAXC"; }
                        else { item.manual = "Manual"; item.sequence = 100; }
                        if (item.tax_name == null || item.tax_name.Trim() == "")
                        { item.tax_name = "CASH"; }
                        item.active = true;
                        item.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.symbol = MasterEntity.symbol;
                        item.local_curr = AppSessionState.CntryCurncy;
                        item.curr_code = MasterEntity.curr_code;
                        item.PartyId = MasterEntity.PartyId;  // Transporter
                        item.client = AppSessionState.client;
                        item.exch_rate = (MasterEntity.exc_rate ?? 1);

                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                { }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                { }
                if (e.Action == NotifyCollectionChangedAction.Move)
                { }
                int c = ConditionEntity.Count();
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void CCN_ITEM(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (SEL_T003_A item in e.NewItems)
                    {
                        item.symbol = MasterEntity.symbol;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                        item.active = true;
                        item.t_status = MasterEntity.t_status;
                        item.t_display = MasterEntity.t_display;
                        item.store_code = AppSessionState.OBJ_STORE.store_code;
                    }
                    //foreach (var item in ItemsEntity)
                    //{
                    //    Computation(item, (bool)DOC_TYPE_OBJ.auto_roundup, (int)DOC_TYPE_OBJ.roundup_digits);
                    //}
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                {}
                if (e.Action == NotifyCollectionChangedAction.Remove) //foreach (SEL_T003_A item in e.OldItems){}
                {
                    SEL_T003_A temp = (SEL_T003_A)e.OldItems[0];
                    // NOTE: implementation & Test pending
                    if (ConditionEntity.Count > 0) // Remove Taxes deleted item.
                    {
                        List<ACC_T006_C> copy = new List<ACC_T006_C>();
                        copy = ConditionEntity.ToList();
                        foreach (var tax in copy)
                        {
                            if (tax.ItemCode == temp.ItemCode && tax.sku == temp.sku && tax.item_row_id == temp.id)
                            {
                                ConditionEntity.Remove(tax);
                                Computation(tax, (bool)DOC_TYPE_OBJ.auto_roundup, (int)DOC_TYPE_OBJ.roundup_digits);
                            }
                        }

                    }

                    foreach (var item in ItemsEntity)
                    {
                        Computation(item, (bool)DOC_TYPE_OBJ.auto_roundup, (int)DOC_TYPE_OBJ.roundup_digits);
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Move){}
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertTermsConditions2(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0051 POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.CONDITION_LIST.Where(x => x.tc_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0051>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    bool varValue = TermsConditionEntity.Any(x => x.tc_code == POPUPEntityObject.tc_code);
                    if (varValue == true && TCEntityObject != null)
                    {
                        TCEntityObject.id = 0;
                        TCEntityObject.active = "1";
                        TCEntityObject.comp_code = MasterEntity.comp_code;
                        TCEntityObject.tc_code = POPUPEntityObject.tc_code;
                        TCEntityObject.seq_no = POPUPEntityObject.seq_no;
                        if (TCEntityObject.seq_no == 0 || TCEntityObject.seq_no == null)
                        {
                            int? maxValue = TermsConditionEntity.Max(x => x.seq_no);
                            TCEntityObject.seq_no = (maxValue ?? 0) + 1;
                        }
                        TCEntityObject.con_type = POPUPEntityObject.con_type;
                        TCEntityObject.con_group = POPUPEntityObject.con_group;
                        TCEntityObject.long_text = POPUPEntityObject.long_text;
                        TCEntityObject.short_text = POPUPEntityObject.short_text;
                    }
                }
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertTermsConditions(object InputValue)
        {
            try
            {
                ADM_M0051 OBJ_TC = new ADM_M0051();
                foreach (var item in MC.CONDITION_LIST)
                {
                    if (item.selected == true)
                    {
                        bool varValue = TermsConditionEntity.Any(x => x.tc_code == item.tc_code);
                        if (varValue == false)
                        {
                            if (item != null)
                            {
                                GEN_T011 obj_tcnew = new GEN_T011();
                                obj_tcnew.id = 0;
                                obj_tcnew.active = "1";
                                obj_tcnew.comp_code = MasterEntity.comp_code;
                                obj_tcnew.tc_code = item.tc_code;
                                obj_tcnew.seq_no = item.seq_no;
                                if (obj_tcnew.seq_no == 0 || obj_tcnew.seq_no == null)
                                {
                                    int? maxValue = TermsConditionEntity.Max(x => x.seq_no);
                                    obj_tcnew.seq_no = (maxValue ?? 0) + 1;
                                }
                                obj_tcnew.con_type = item.con_type;
                                obj_tcnew.con_group = item.con_group;
                                obj_tcnew.long_text = item.long_text;
                                obj_tcnew.short_text = item.short_text;

                                TermsConditionEntity.Add(obj_tcnew);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void SCH_GEN_T011(object InputValue)
        {
            try
            {
                TCEntityObject = (GEN_T011)InputValue;
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForTerms(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (GEN_T011 item in e.NewItems)
                    {
                        item.active = "1";
                        item.comp_code = MasterEntity.comp_code;
                        item.client = AppSessionState.client;
                        item.doc_cat = doc_cat_vm;
                        if (TermsConditionEntity != null)
                        {
                            item.sr_no = TermsConditionEntity.Count() + 1;
                        }
                        //item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                { }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                { }
                if (e.Action == NotifyCollectionChangedAction.Move)
                { }
            }
            catch (Exception ex)
            { //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); 
            }
        }
        private void DeleteDataGridRow_Terms(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (TCEntityObject.id == 0)
                {
                    TermsConditionEntity.Remove(TCEntityObject);
                }
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); 
            }
        }
        private void Computation(object OBJ_ITEM_LINE,bool AutoRoudup,int RoundupDigit)
        {
            try
            {
                ITEM_OBJ = (SEL_T003_A)OBJ_ITEM_LINE;

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

                if (ItemsEntity != null) //Condition satisfy only if Items collection is not empty.
                {
                    if (ITEM_OBJ.qty >= 0 && ITEM_OBJ.unit_price >= 0 && ITEM_OBJ.active != false) // Must not null or empty.
                    {
                        ITEM_OBJ.gross_value = Math.Round(((ITEM_OBJ.qty * ITEM_OBJ.unit_price) ?? 0), (int)DOC_TYPE_OBJ.roundup_digits);

                        if (ITEM_OBJ.discount == null)
                        {
                            ITEM_OBJ.discount = 0;
                        }
                        if (ITEM_OBJ.discount_type == "F")    // Manual Discount value instead of percent.
                        {
                            ITEM_OBJ.discount = 0;
                            ITEM_OBJ.subtotal = (ITEM_OBJ.gross_value) - (ITEM_OBJ.discount_amt);
                        }
                        else
                        {
                            //ITEM_OBJ.discount_amt = (ITEM_OBJ.gross_value * ((ITEM_OBJ.discount ?? 0) / 100));
                            ITEM_OBJ.discount_amt = decimal.Round((decimal)(ITEM_OBJ.gross_value * ((ITEM_OBJ.discount ?? 0) / 100)), (int)DOC_TYPE_OBJ.roundup_digits);
                            //ITEM_OBJ.subtotal = (ITEM_OBJ.gross_value - ITEM_OBJ.discount_amt);
                            ITEM_OBJ.subtotal = decimal.Round((decimal)((ITEM_OBJ.gross_value - ITEM_OBJ.discount_amt) ?? 0), (int)DOC_TYPE_OBJ.roundup_digits);
                        }
                    }
                    #region Calculate Taxes for New/Edited Items row.
                    if (!String.IsNullOrEmpty(ITEM_OBJ.tax_id) && ITEM_OBJ.active == true) //Condition satisfy only if Selected Item not null and Taxes are applied.
                    {
                        #region Tax Not Null

                        List<ACC_M013> TaxListTemp = new List<ACC_M013>();
                        string[] TaxArray = ITEM_OBJ.tax_id.Trim().Split(',');
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
                                        BasePrice = ITEM_OBJ.subtotal / TaxValue;
                                        BasicItemAmount = BasePrice;
                                        TaxAmount = ITEM_OBJ.subtotal - BasicItemAmount;
                                    }
                                    else if (SingleTax.price_include == false)
                                    {
                                        TaxValue = (SingleTax.amount) / 100;
                                        if (TaxListForBaseInclude.Length > 0)
                                        {
                                            PreviousTaxValueForBasePrice = ConditionEntity.Where(tax => tax.sequence < SingleTax.sequence && tax.item_line_id == ITEM_OBJ.line_id && tax.manual == "Auto" && tax.ItemCode == ITEM_OBJ.ItemCode && (tax.sku?.ToString() ?? "") == (ITEM_OBJ.sku?.ToString() ?? "") && tax.item_row_id == ITEM_OBJ.id && tax.tax_code_id.In(TaxListForBaseInclude)).Sum(tax => tax.tax_amount); // Get Base amount for Calculation.
                                        }
                                        if (SingleTax.parent_id != null) // Collect Base price for This single child Tax.
                                        {
                                            BasePrice = ConditionEntity.Where(tax => tax.tax_code_id == SingleTax.parent_id && tax.item_line_id == ITEM_OBJ.line_id && tax.manual == "Auto" && tax.ItemCode == ITEM_OBJ.ItemCode && (tax.sku?.ToString() ?? "") == (ITEM_OBJ.sku?.ToString() ?? "") && tax.item_row_id == ITEM_OBJ.id).Single().tax_amount;
                                        }
                                        else // Collect Base Price for this parent Tax.
                                        {
                                            BasePrice = ITEM_OBJ.subtotal + PreviousTaxValueForBasePrice;
                                        }
                                        BasicItemAmount = ITEM_OBJ.subtotal;
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
                                        BasePrice = ITEM_OBJ.subtotal - TaxValue;
                                        BasicItemAmount = BasePrice;
                                        TaxAmount = ITEM_OBJ.subtotal - BasicItemAmount;
                                    }
                                    else if (SingleTax.price_include == false)
                                    {
                                        BasePrice = ITEM_OBJ.subtotal;
                                        BasicItemAmount = BasePrice;
                                        TaxAmount = TaxValue;
                                    }
                                }
                                #endregion
                                #region Insert/Update Tax
                                TaxAmount = Math.Round(TaxAmount ?? 0, (int)DOC_TYPE_OBJ.roundup_digits);
                                int TaxIndex = 0;
                                var TaxVar = ConditionEntity.FirstOrDefault(T => T.tax_code_id == SingleTax.id && T.ItemCode == ITEM_OBJ.ItemCode && (T.sku?.ToString() ?? "") == (ITEM_OBJ.sku?.ToString() ?? "") && (T.item_line_id ?? 0) == ITEM_OBJ.line_id && T.item_row_id == ITEM_OBJ.id && T.manual == "Auto");
                                TaxIndex = ConditionEntity.IndexOf(TaxVar);
                                if (TaxVar != null && TaxIndex >= 0)
                                {
                                    ConditionEntity[TaxIndex].manual = "Auto";
                                    ConditionEntity[TaxIndex].active = true;
                                    ConditionEntity[TaxIndex].tax_amount = TaxAmount;
                                    ConditionEntity[TaxIndex].account_id = 0;
                                    ConditionEntity[TaxIndex].sequence = SingleTax.sequence;
                                    ConditionEntity[TaxIndex].doc_no = MasterEntity.bill_doc;
                                    ConditionEntity[TaxIndex].base_amount = BasePrice;
                                    ConditionEntity[TaxIndex].amount = SingleTax.amount;
                                    ConditionEntity[TaxIndex].tax_code_id = SingleTax.id;
                                    ConditionEntity[TaxIndex].account_analytic_id = 0;
                                    ConditionEntity[TaxIndex].base_code_id = SingleTax.id;
                                    ConditionEntity[TaxIndex].tax_name = SingleTax.description;
                                    //ConditionEntity[TaxIndex].curr_code = MasterEntity.curr_code;
                                    //ConditionEntity[TaxIndex].gl_code = "";
                                    ConditionEntity[TaxIndex].ItemCode = ITEM_OBJ.ItemCode;
                                    ConditionEntity[TaxIndex].sku = ITEM_OBJ.sku;
                                    ConditionEntity[TaxIndex].item_row_id = ITEM_OBJ.id;
                                    ConditionEntity[TaxIndex].item_line_id = ITEM_OBJ.line_id;
                                    //ConditionEntity[TaxIndex].fin_year = SingleTax.FinYear;
                                    ConditionEntity[TaxIndex].location_Id = MasterEntity.location_Id;
                                    ConditionEntity[TaxIndex].comp_code = MasterEntity.comp_code;
                                    ConditionEntity[TaxIndex].posting_period = MasterEntity.posting_period;
                                    ConditionEntity[TaxIndex].trns_key_code = "STX";

                                    ConditionEntity[TaxIndex].con_value = TaxAmount;
                                    ConditionEntity[TaxIndex].tax_code = SingleTax.tax_code;
                                    ConditionEntity[TaxIndex].PartyId = MasterEntity.PartyId;
                                    ConditionEntity[TaxIndex].exch_rate = MasterEntity.exc_rate;
                                    ConditionEntity[TaxIndex].client = AppSessionState.client;
                                    ConditionEntity[TaxIndex].symbol = MasterEntity.symbol;
                                    ConditionEntity[TaxIndex].local_curr = AppSessionState.CntryCurncy;


                                }
                                else
                                {
                                    ConditionEntity.Add(new ACC_T006_C()
                                    {
                                        id = 0,
                                        tax_amount = TaxAmount,
                                        account_id = 0,
                                        sequence = SingleTax.sequence,
                                        doc_no = MasterEntity.bill_doc,
                                        manual = "Auto",
                                        base_amount = BasePrice,
                                        amount = SingleTax.amount,
                                        tax_code_id = SingleTax.id,
                                        account_analytic_id = 0,
                                        base_code_id = SingleTax.id,
                                        tax_name = SingleTax.description,
                                        //curr_code = MasterEntity.curr_code,
                                        //gl_code = "",
                                        ItemCode = ITEM_OBJ.ItemCode,
                                        sku = ITEM_OBJ.sku,
                                        item_row_id = ITEM_OBJ.id,
                                        item_line_id = ITEM_OBJ.line_id,
                                        //fin_year = AppSessionState.FinYear,
                                        active = true,
                                        posting_period = MasterEntity.posting_period,
                                        location_Id = AppSessionState.OBJ_LOCATION.location_id,
                                        comp_code = AppSessionState.OBJ_COMPANY.comp_code,
                                        trns_key_code = "STX",

                                        con_value = TaxAmount,
                                        tax_code = SingleTax.tax_code,
                                        PartyId = MasterEntity.PartyId,
                                        exch_rate = MasterEntity.exc_rate,
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
                        string[] TaxArray2 = ITEM_OBJ.tax_id.Trim().Split(',');
                        List<ACC_T006_C> copy = new List<ACC_T006_C>();
                        copy = ConditionEntity.ToList();
                        foreach (var tax in copy)
                        {
                            bool DeleteFlag = true;
                            foreach (string SingleTax in TaxArray2)
                            {
                                if ((tax.tax_code_id.ToString() == SingleTax && tax.ItemCode == ITEM_OBJ.ItemCode && (tax.sku?.ToString() ?? "") == (ITEM_OBJ.sku?.ToString() ?? "") && tax.item_line_id == ITEM_OBJ.line_id && tax.item_row_id == ITEM_OBJ.id && tax.manual == "Auto") || tax.manual == "Manual")
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
                                    if (ChildTaxVar.parent_id.ToString() == SingleTax && tax.ItemCode == ITEM_OBJ.ItemCode && (tax.sku?.ToString() ?? "") == (ITEM_OBJ.sku?.ToString() ?? "") && tax.item_line_id == ITEM_OBJ.line_id && tax.item_row_id == ITEM_OBJ.id && tax.manual == "Auto")
                                    {
                                        CheckChildParentFlag = false;
                                        break;
                                    }
                                }
                                if (!CheckChildParentFlag) continue;
                                //var ParentTaxVar = ConditionEntity.FirstOrDefault(T => T.tax_code_id == ChildTaxVar.parent_id && T.ItemCode == ITEM_OBJ.ItemCode && (T.sku?.ToString() ?? "") == (ITEM_OBJ.sku?.ToString() ?? "") && T.line_id == ITEM_OBJ.line_id && T.item_line_id == ITEM_OBJ.id && T.manual == "Auto");
                                //if (ParentTaxVar == null)

                                if (tax.tax_code_id == ChildTaxVar.id && tax.ItemCode == ITEM_OBJ.ItemCode && (tax.sku?.ToString() ?? "") == (ITEM_OBJ.sku?.ToString() ?? "") && tax.item_line_id == ITEM_OBJ.line_id && tax.item_row_id == ITEM_OBJ.id && tax.manual == "Auto")
                                {
                                    ConditionEntity.Remove(tax);
                                }
                            }
                            else if (tax.tax_code_id == ChildTaxVar.id && tax.ItemCode == ITEM_OBJ.ItemCode && (tax.sku?.ToString() ?? "") == (ITEM_OBJ.sku?.ToString() ?? "") && tax.item_line_id == ITEM_OBJ.line_id && tax.item_row_id == ITEM_OBJ.id && tax.manual == "Auto")
                            {
                                ConditionEntity.Remove(tax);
                            }
                        }

                        #endregion

                    }
                    else //if (ITEM_OBJ.tax_id != null && ITEM_OBJ.active == false) // Remove previously assign Taxes from ConditionEntity if removed from Item.//Condition satisfy only if Selected Item not null and Active status is false.
                    {
                        List<ACC_T006_C> copy = new List<ACC_T006_C>();
                        copy = ConditionEntity.ToList();
                        foreach (var tax in copy)
                        {
                            if (tax.ItemCode == ITEM_OBJ.ItemCode && (tax.sku?.ToString() ?? "") == (ITEM_OBJ.sku?.ToString() ?? "") && tax.item_line_id == ITEM_OBJ.line_id && tax.item_row_id == ITEM_OBJ.id && tax.manual == "Auto")
                            {
                                if (tax.id == 0)
                                {
                                    ConditionEntity.Remove(tax);
                                }
                                else
                                {
                                    int Index = ConditionEntity.IndexOf(ConditionEntity.Where(X => X.ItemCode == ITEM_OBJ.ItemCode && (X.sku?.ToString() ?? "") == (ITEM_OBJ.sku?.ToString() ?? "") && X.item_line_id == ITEM_OBJ.line_id && X.item_row_id == ITEM_OBJ.id && X.manual == "Auto" && X.active == true).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.
                                    if (Index >= 0)
                                    {
                                        ConditionEntity.ElementAt(Index).active = false;
                                    }
                                }
                            }
                        }
                    }
                    #region Final Computation

                    decimal? taxTotal = ConditionEntity.Where(x => x.item_row_id == ITEM_OBJ.id && x.item_line_id == ITEM_OBJ.line_id).Sum(x => x.con_value);
                    ITEM_OBJ.net_value = ((ITEM_OBJ.gross_value + Math.Round((taxTotal ?? 0), (int)DOC_TYPE_OBJ.roundup_digits)) - (ITEM_OBJ.discount_amt ?? 0));
                    ITEM_OBJ.effective_value = ITEM_OBJ.net_value;
                    ITEM_OBJ.tax_amount = taxTotal;


                    TaxtTotal = ConditionEntity.Where(item => item.active != false && item.manual == "Auto").Sum(item => item.tax_amount);
                    MasterEntity.tax_amount = TaxtTotal;

                    UnTaxTotal = ItemsEntity.Where(item => item.active != false).Sum(item => item.subtotal);
                    MasterEntity.ass_value = UnTaxTotal;
                    MasterEntity.sub_total = UnTaxTotal;

                    net_value = UnTaxTotal + TaxtTotal;
                    MasterEntity.net_value = UnTaxTotal + TaxtTotal;
                    other_charges = ConditionEntity.Where(item => item.active != false && item.manual == "Manual").Sum(item => item.tax_amount);
                    MasterEntity.other_charges = other_charges;

                    GrandTotal = net_value + other_charges;
                    MasterEntity.invoice_amt = decimal.Round((decimal)GrandTotal, 2);

                    if (AutoRoudup == true)
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

                    #endregion

                    #endregion

                }
            }
            catch (Exception Ex) { }
        }
        private void DeleteTax(object InputValue) // NOTE: implementation & Test pending
        {
            try
            {
                int i = (int)InputValue;
                if (ConditionEntity.Count > i)
                {
                    //ConditionEntity.Remove(ConditionEntity.Where(x => x.tax_name == ConditionEntity[i].tax_name).Single());
                    List<ACC_T006_C> copyLocal = new List<ACC_T006_C>();
                    copyLocal = ConditionEntity.ToList();
                    foreach (var tax in copyLocal)
                    {
                        if (tax.tax_name == ConditionEntity[i].tax_name && tax.manual == "Manual")
                        {
                            ConditionEntity.Remove(tax);
                        }
                    }
                    Computation(ITEM_OBJ, (bool)DOC_TYPE_OBJ.auto_roundup, (int)DOC_TYPE_OBJ.roundup_digits); // NOTE: it is outside of the foreach loop in current VM. should we keep this in items foreach loop for computation because if item remove and other base include tax depends on this then all calculation required instead of single item. so first inactive taxes of this item and then recompute all
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private Dictionary<string, string> getParametersList(string paraValue)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("prepare_by", AppSessionState.Name);
                //result.Add("PrintOption", paraValue);
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
            return result;
        }
        
        
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            // NOTE: instead of hardcoded "POS_CUST" value, use variable like type_code from STD_LIST_BE so that we can use everyware and use notification value as a generic. like we can use it for identify calling screen so that it will get by right screen and not all, even that can also done by STD_LIST_BE object.
            if (msg.Notification == "POS_CUST") // Get signal from SDM_M0021_VM Save Button command
            {
                STD_LIST_BE OBJ_GEN = new STD_LIST_BE();
                OBJ_GEN = (STD_LIST_BE)msg.Sender;
                MasterEntity.PartyId = OBJ_GEN.party_code;
                MasterEntity.party_code = OBJ_GEN.party_code;
                MasterEntity.sold_to_party_name = OBJ_GEN.party_name;
                MasterEntity.party_code_bil = OBJ_GEN.party_code;
                MasterEntity.party_code_del = OBJ_GEN.party_code;
                MasterEntity.ship_to_party_name = OBJ_GEN.party_name;
                MasterEntity.add_code_bil = OBJ_GEN.add_code;
                MasterEntity.add_code_del = OBJ_GEN.add_code_del ?? OBJ_GEN.add_code;
                MasterEntity.cp_name = OBJ_GEN.cp_name;
                MasterEntity.cp_code = OBJ_GEN.cp_code;
                MasterEntity.payer = OBJ_GEN.party_code;
                MasterEntity.payer_name = OBJ_GEN.party_name;
                MasterEntity.bill_address_id = OBJ_GEN.id;
               

            }
            else if(msg.Notification == "POS_POST_STOCK")
            {
                GoodsPosting();
            }
        }

        #endregion

        #region Abstract Command actions
        private bool validation()
        {
            try
            {
                MasterEntity.userid = AppSessionState.UserID;
                MasterEntity.ts_code = ts_code_vm;

                foreach (var item in ItemsEntity)
                {
                    Computation(item, (bool)DOC_TYPE_OBJ.auto_roundup, (int)DOC_TYPE_OBJ.roundup_digits);
                }

                if (MasterEntity.ind_trade == null || MasterEntity.ind_trade == "")
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Transation Type is Required", this.Title); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.PartyId == null || MasterEntity.PartyId == "")
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Field Sold To Party is Required", this.Title); sms.ShowMessage();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(MasterEntity.add_code_bil))
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Billing Address is Required", this.Title); sms.ShowMessage();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(MasterEntity.so_code))
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Sales Organisation is Required", this.Title); sms.ShowMessage();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(MasterEntity.sg_code))
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Sales Group is Required", this.Title); sms.ShowMessage();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(MasterEntity.doc_type))
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("doc_Type is Required", this.Title); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.doc_date == null)
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("SI date is Required", this.Title); sms.ShowMessage();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(MasterEntity.curr_code))
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Document Currancy is Required", this.Title); sms.ShowMessage();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(MasterEntity.lc_curr))
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please enter Your Local Currancy In company Master", this.Title); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.curr_code == MasterEntity.lc_curr)
                {
                    MasterEntity.exc_rate = 1;
                    MasterEntity.lc_exc_rate = 1;
                }
                if (MasterEntity.exc_rate == null || MasterEntity.exc_rate <= 0)
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Exchange Rate is Required", this.Title); sms.ShowMessage();
                    return false;
                }

                if (MasterEntity.exc_rate != null && MasterEntity.exc_rate > 0)
                {
                    MasterEntity.lc_exc_rate = MasterEntity.exc_rate;
                }

                if (ItemsEntity.Count < 1)//when form is blank and we save the record
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("At Least Insert One Item...", this.Title); sms.ShowMessage();
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
                                    if (o.ItemCode == p.ItemCode && (o.sku?.ToString() ?? "") == (p.sku?.ToString() ?? "") && o.id == p.id && o.line_id != p.line_id && o.ref_doc_no == p.ref_doc_no && o.ref_item_row_id == p.ref_item_row_id && o.sd_doc == p.sd_doc && o.sd_row_id == p.sd_row_id && o.sd_line_id == p.sd_line_id)
                                    {
                                        flag++;
                                    }
                                }
                                if (flag > 1)
                                {
                                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1}", o.ItemCode, o.sku_desc); sms.ShowMessage();
                                    return false;
                                }
                            }
                            if (o.qty == null || o.qty == 0)
                            {
                                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Quantity cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc); sms.ShowMessage();
                                return false;
                            }
                            if (o.unit_price == null || o.unit_price == 0)
                            {
                                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Unit Price cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc); sms.ShowMessage();
                                return false;
                            }
                            if (o.tax_id != null || o.tax_id != "")
                            {
                                if (ConditionEntity.Count > 0)
                                {
                                    for (int i = 0; i < ConditionEntity.Count; i++)
                                    {

                                        if (ConditionEntity[i].con_type == null || ConditionEntity[i].con_type == "")
                                        {
                                            IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Condition Type is Required for Tax {0} ", ConditionEntity[i].tax_name); sms.ShowMessage();
                                            return false;
                                        }
                                    }
                                }

                            }

                        }
                        else
                        {
                            IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("please select Item ........", this.Title); sms.ShowMessage();
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return true;
        }
        protected override void OnSaveAction(InquiryActionResult<SEL_T003> result)
        {
            try
            {
                CursorControl.SetBusyState();
                if (validation() == true)
                {
                    Logging();
                    MasterEntity.XmlDataDocument_SEL_T003_A = obj.ObjectToXML(ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = obj.ObjectToXML(ConditionEntity);
                    MasterEntity.XDOC_TC = obj.ObjectToXML(TermsConditionEntity);
                    this.MasterEntity.EndEdit();

                    if (isNewRecord == true)
                    {
                        MasterEntity = REPO.SaveWithReturnDomainObject<SEL_T003>(MasterEntity, "SEL_T003_BL_DEV", "FICO");
                        SetBusinessEntitiesAfterLoad("Save", "");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = REPO.UpdateWithReturnDomainObject<SEL_T003>(MasterEntity, "SEL_T003_BL_DEV", "FICO");
                        SetBusinessEntitiesAfterLoad("Save", "");
                    }
                    //OnFevoriteAction(result); // NOTE: shift this call on paymnet receipt entry. load pending invoice before save payment means on save payment it will load pendng invoice , pick the required data and then save paymnet. this place not suitable because if cancell before paymnet then it will sho in pending or we need to cancel pending also by revert validation.
                    if (MasterEntity.bill_doc != null || MasterEntity.bill_doc != "")
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record saved Successfully ........", this.Title); sms.ShowMessage();
                    }
                    isNewRecord = false;

                    //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(MasterEntity,"POS_PAY")); shifted to Checkout method
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        protected override void OnCreateAction(InquiryActionResult<SEL_T003> result)
        {
            try
            {
                isNewRecord = true;
                MasterEntity = new SEL_T003();
                ItemsEntity = new ObservableCollection<SEL_T003_A>();
                ConditionEntity = new ObservableCollection<ACC_T006_C>();
                TermsConditionEntity = new ObservableCollection<GEN_T011>();
                ITEM_OBJ = new SEL_T003_A();
                CONDITION_OBJ = new ACC_T006_C();
                BATCH_OBJ = new MM_T001_B();
                PARTY_OBJ = new STD_PARTY();
                BANK_ACC_OBJ = new FICO_M0004();
                STATUS_OBJ = new ADM_M0013();
                DOC_TYPE_OBJ = new STD_DOC_TYPE();
                TCEntityObject = new GEN_T011();
                SEL_T003.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
                SEL_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
                ACC_T006_C.ModelEntityUpdated += new EventHandler(ModelUpdated_Tax);
                ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CCN_ITEM);
                ConditionEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CCN_CONDITION);
                DefaultValues();
            }
            catch (Exception ex) { }
        }
        protected override void OnRemoveAction(InquiryActionResult<SEL_T003> result)
        {
            try
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Delete Changes";
                showMessageService.Text =
                    String.Format(
                        "This record will delete forever '{0}'",
                            this.Title);

                if (showMessageService.ShowMessage() == DialogResult.Ok)
                {
                    this.MasterEntity.CancelEdit();
                    string response = REPO.Delete(MasterEntity.bill_doc, "SEL_T003_BL_DEV", "FICO");

                    MasterEntity = new SEL_T003();
                    ItemsEntity = new ObservableCollection<SEL_T003_A>();
                    isNewRecord = true;
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected override void OnDiscardAction(InquiryActionResult<SEL_T003> result)
        {
            try
            {
                //SelectedSEL_T001.CancelEdit();
                string post_key = MC.DOC_TYPE_LIST.Where(x => x.doc_type == MasterEntity.doc_type).ToList()[0].posting_key;
                //object[] obj = new { MasterEntity, ItemsEntity, ConditionEntity, post_key };
                object objParam = MasterEntity.bill_doc;
                //object[] obj = new[] { MasterEntity, ItemsEntity, ConditionEntity, post_key };

                string userAuth = "Reflection.Modules.Finance.Views.LedgerView"; // this one is path option
                string path1 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.Finance.dll");
                Assembly assembly = Assembly.LoadFile(path1);
                Type type = assembly.GetType(userAuth);
                if (type != null)
                {
                    //dynamic instance = Activator.CreateInstance(type, MasterEntity, ItemsEntity, ConditionEntity, post_key);
                    dynamic instance = Activator.CreateInstance(type, objParam);
                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected override void OnFevoriteAction(InquiryActionResult<SEL_T003> result)
        {
            try
            {
                if (MasterEntity.bill_doc != null && MasterEntity.bill_doc != "")
                {
                    if (MasterEntity.t_status != "06")
                    {
                        string Request = "ValidateInvoice" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.bill_doc + "!@" + AppSessionState.UserID;
                        //string Request = "ValidateInvoice" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.client + "!@" + MasterEntity.bill_doc + "!@" + AppSessionState.UserID + "!@" + this.ts_code_vm;
                        MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_SEL_T003>(MC_TEMP, Request, "SEL_T003_BL_DEV", "FICO", "Insert", 0, "");

                        if (MC_TEMP.MasterEntity.Count > 0 && MC.STATUS_LIST.Count > 0)
                        {
                            string t_status_validate = (from o in MC.STATUS_LIST where o.ind_valid == "1" select o.t_status).FirstOrDefault();
                            if (MC_TEMP.MasterEntity[0].t_status == t_status_validate)
                            {
                                MasterEntity.t_status = MC_TEMP.MasterEntity[0].t_status;
                                MasterEntity.t_display = (from o in MC.STATUS_LIST where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();
                                //IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Invoice Validate Succesfully...", this.Title); sms.ShowMessage();
                            }
                        }
                    }
                    else if (MasterEntity.t_status == "06")
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Invoice Validate Succesfully...", this.Title); sms.ShowMessage();
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        protected override void OnFlipAction(InquiryActionResult<SEL_T003> result)
        {
            try
            {
                //SelectedSEL_T001.CancelEdit();
                string post_key = MC.DOC_TYPE_LIST.Where(x => x.doc_type == MasterEntity.doc_type).ToList()[0].posting_key;
                //object[] obj = new { MasterEntity, ItemsEntity, ConditionEntity, post_key };
                object objParam = MasterEntity.bill_doc;
                //object[] obj = new[] { MasterEntity, ItemsEntity, ConditionEntity, post_key };

                string userAuth = "Reflection.Modules.Finance.Views.LedgerView"; // this one is path option
                string path1 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.Finance.dll");
                Assembly assembly = Assembly.LoadFile(path1);
                Type type = assembly.GetType(userAuth);
                if (type != null)
                {
                    //dynamic instance = Activator.CreateInstance(type, MasterEntity, ItemsEntity, ConditionEntity, post_key);
                    dynamic instance = Activator.CreateInstance(type, objParam);
                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected override void OnHelpAction(InquiryActionResult<SEL_T003> result)
        {}
        protected override void OnRefreshCommand(InquiryActionResult<SEL_T003> result)
        {
            LoadInitialData();
            DefaultValues();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<SEL_T003> result)
        {
        }

        protected override void OnValidateCommand(InquiryActionResult<SEL_T003> result)
        {}

        protected override void OnTraceCommand(InquiryActionResult<SEL_T003> result)
        {}

        protected override void OnMailCommand(InquiryActionResult<SEL_T003> result)
        {}
        
        protected override void OnPrintAction(InquiryActionResult<SEL_T003> result)
        {
            try
            {
                CursorControl.SetBusyState();
                string ReportName = "";

                object[] objDataSource = new object[6];
                string[] objDataSourceName = new string[6];

                var CmpResult = AppSessionState.COMPANY_LIST.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[0] = CmpResult;

                var Result = AppSessionState.LOCATION_LIST.Where(loc => loc.location_id == MasterEntity.location_Id).ToList();
                objDataSource[1] = Result;

                if (!string.IsNullOrWhiteSpace(MasterEntity.bill_doc))
                {
                    QRCodeService QRGenerator = new QRCodeService();
                    MasterEntity.qr_image = QRGenerator.RenderQrCodeForLabel(MasterEntity.bill_doc, 15, "");
                }
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
                objDataSource[4] = ConditionEntity;
                objDataSource[5] = TermsConditionEntity;

                objDataSourceName[0] = "dsCompany";
                objDataSourceName[1] = "dsLocation";
                objDataSourceName[2] = "dsMaster";
                objDataSourceName[3] = "dsItems";
                objDataSourceName[4] = "dsConditions";
                objDataSourceName[5] = "dsTC";

                ReportManager ReportManager = new ReportManager();
                ReportName = DOC_TYPE_OBJ.report_name.Split(',')[1];

                string ReportDisplayName = MasterEntity.sold_to_party_name + "_" + MasterEntity.bill_doc + "_" + MasterEntity.doc_date.Value.ToShortDateString();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORTS_STD\\TXN\\" + ReportName, getParametersList(null), ReportDisplayName);

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
                string DocumentList = "";
                CursorControl.SetBusyState();
                if (!string.IsNullOrEmpty(MasterEntity.bill_doc))
                {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.bill_doc.Replace("/", "--"), DocumentList = MC_TEMP.ATTACHMENT_LIST, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) });
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        #endregion
    }
}
