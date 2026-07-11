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
using System.Windows;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using Reflection.BusinessEntity.CustomerRelation;
using Reflection.Presentation.Services.Convertors;
using System.Reflection;
using GalaSoft.MvvmLight.Ioc;
using Reflection.Presentation.Core.VirtualDesktops;
using Reflection.ReportingServices;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class PUR_T005_VM : WorkspaceViewModel<PUR_T005>
    {
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PUR_T005_VM));
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
        private AutoSuggestTextViewModel<dynamic> _ASIncoTerms { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASIncoTerms
        {
            get { return _ASIncoTerms; }
            set
            {
                if (_ASIncoTerms != value)
                {
                    _ASIncoTerms = value; RaisePropertyChanged("ASIncoTerms");
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

        private AutoSuggestTextViewModel<dynamic> _ASRefDocNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRefDocNo
        {
            get { return _ASRefDocNo; }
            set
            {
                if (_ASRefDocNo != value)
                {
                    _ASRefDocNo = value; RaisePropertyChanged("ASRefDocNo");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASSuppParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSuppParty
        {
            get { return _ASSuppParty; }
            set
            {
                if (_ASSuppParty != value)
                {
                    _ASSuppParty = value; RaisePropertyChanged("ASSuppParty");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPayee { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPayee
        {
            get { return _ASPayee; }
            set
            {
                if (_ASPayee != value)
                {
                    _ASPayee = value; RaisePropertyChanged("ASPayee");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASItemCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItemCode
        {
            get { return _ASItemCode; }
            set
            {
                if (_ASItemCode != value)
                {
                    _ASItemCode = value; RaisePropertyChanged("ASItemCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASItemCategory { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItemCategory
        {
            get { return _ASItemCategory; }
            set
            {
                if (_ASItemCategory != value)
                {
                    _ASItemCategory = value; RaisePropertyChanged("ASItemCategory");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUnit
        {
            get { return _ASUnit; }
            set
            {
                if (_ASUnit != value)
                {
                    _ASUnit = value; RaisePropertyChanged("ASUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASWeightUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWeightUnit
        {
            get { return _ASWeightUnit; }
            set
            {
                if (_ASWeightUnit != value)
                {
                    _ASWeightUnit = value; RaisePropertyChanged("ASWeightUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASVolUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASVolUnit
        {
            get { return _ASVolUnit; }
            set
            {
                if (_ASVolUnit != value)
                {
                    _ASVolUnit = value; RaisePropertyChanged("ASVolUnit");
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

        private AutoSuggestTextViewModel<dynamic> _ASDocCurr { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocCurr
        {
            get { return _ASDocCurr; }
            set
            {
                if (_ASDocCurr != value)
                {
                    _ASDocCurr = value; RaisePropertyChanged("ASDocCurr");
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

        private AutoSuggestTextViewModel<dynamic> _ASPaymentTerm { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPaymentTerm
        {
            get { return _ASPaymentTerm; }
            set
            {
                if (_ASPaymentTerm != value)
                {
                    _ASPaymentTerm = value; RaisePropertyChanged("ASPaymentTerm");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPaymentMethod { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPaymentMethod
        {
            get { return _ASPaymentMethod; }
            set
            {
                if (_ASPaymentMethod != value)
                {
                    _ASPaymentMethod = value; RaisePropertyChanged("ASPaymentMethod");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCompanyBank { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCompanyBank
        {
            get { return _ASCompanyBank; }
            set
            {
                if (_ASCompanyBank != value)
                {
                    _ASCompanyBank = value; RaisePropertyChanged("ASCompanyBank");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPartyBank { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPartyBank
        {
            get { return _ASPartyBank; }
            set
            {
                if (_ASPartyBank != value)
                {
                    _ASPartyBank = value; RaisePropertyChanged("ASPartyBank");
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

        private AutoSuggestTextViewModel<dynamic> _ASPurOrg { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPurOrg
        {
            get { return _ASPurOrg; }
            set
            {
                if (_ASPurOrg != value)
                {
                    _ASPurOrg = value; RaisePropertyChanged("ASPurOrg");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPurGrp { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPurGrp
        {
            get { return _ASPurGrp; }
            set
            {
                if (_ASPurGrp != value)
                {
                    _ASPurGrp = value; RaisePropertyChanged("ASPurGrp");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCostCenter { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCostCenter
        {
            get { return _ASCostCenter; }
            set
            {
                if (_ASCostCenter != value)
                {
                    _ASCostCenter = value; RaisePropertyChanged("ASCostCenter");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASJournal { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASJournal
        {
            get { return _ASJournal; }
            set
            {
                if (_ASJournal != value)
                {
                    _ASJournal = value; RaisePropertyChanged("ASJournal");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDefault4 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault4
        {
            get { return _ASDefault4; }
            set
            {
                if (_ASDefault4 != value)
                {
                    _ASDefault4 = value; RaisePropertyChanged("ASDefault4");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASLicence { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLicence
        {
            get { return _ASLicence; }
            set
            {
                if (_ASLicence != value)
                {
                    _ASLicence = value; RaisePropertyChanged("ASLicence");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASdgIncoTerms { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASdgIncoTerms
        {
            get { return _ASdgIncoTerms; }
            set
            {
                if (_ASdgIncoTerms != value)
                {
                    _ASdgIncoTerms = value; RaisePropertyChanged("ASdgIncoTerms");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBussPlace { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBussPlace
        {
            get { return _ASBussPlace; }
            set
            {
                if (_ASBussPlace != value)
                {
                    _ASBussPlace = value; RaisePropertyChanged("ASBussPlace");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASdgBussPlace { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASdgBussPlace
        {
            get { return _ASdgBussPlace; }
            set
            {
                if (_ASdgBussPlace != value)
                {
                    _ASdgBussPlace = value; RaisePropertyChanged("ASdgBussPlace");
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
                        { ASDefault = ASItemCode; }
                        else if (SourceName == "unit_code")
                        { ASDefault = ASUnit; }
                        else if (SourceName == "item_cat")
                        { ASDefault = ASItemCategory; }
                        else if (SourceName == "weight_unit")
                        { ASDefault = ASWeightUnit; }
                        else if (SourceName == "volume_unit")
                        { ASDefault = ASVolUnit; }
                        else if (SourceName == "buss_place")
                        { ASDefault = ASdgBussPlace; }
                        else if (SourceName == "ship_to_Party")
                        { ASDefault = ASdgShipToParty; }
                        else if (SourceName == "gl_code")
                        { ASDefault1 = ASTaxacc; }
                        else if (SourceName == "curr_code")
                        { ASDefault1 = ASdgCurrency; }
                        else if (SourceName == "con_type")
                        { ASDefault1 = ASConditionType; }
                        else if (SourceName == "licence_no")
                        { ASDefault4 = ASLicence; }
                        else if (SourceName == "incoterms")
                        { ASDefault4 = ASdgIncoTerms; }
                        else if (SourceName == "TransporterId")
                        { ASDefault1 = ASTaxTransporter; }
                    }
                }
            }
            catch (Exception Ex) { }
        }

        #endregion

        #region Variable Declaration
        bool isNewRecord = true;
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
        public string doc_no_vm { get; set; }
        private int RoundUpDecimals = 2;
        string Currency;
        public string ref_doc_cat { get; set; }
        WebServiceRepository<PUR_T005> repository = new WebServiceRepository<PUR_T005>();
        WebServiceRepository<MultipleContext_PUR_T005> repository_MC = new WebServiceRepository<MultipleContext_PUR_T005>();
        WebServiceRepository<MultipleContext_PUR_T005> repository_MCTemp = new WebServiceRepository<MultipleContext_PUR_T005>();
        ObjectSerializationService obj = new ObjectSerializationService();
        NumberToEnglish num = new NumberToEnglish();
        private MultipleContext_PUR_T005 _MC = new MultipleContext_PUR_T005();
        public MultipleContext_PUR_T005 MC
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
        private MultipleContext_PUR_T005 _MCTemp = new MultipleContext_PUR_T005();
        public MultipleContext_PUR_T005 MCTemp
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
        // All Document Taxes including Parent,Child & External
        public ObservableCollection<ACC_T006_C> TotalDocumentTaxes
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
        // Taxes for selected item.
        public ObservableCollection<ACC_T006_C> TotalDocumentTaxesItem
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
        //scalar fields
        private decimal _TotalQty;
        public decimal TotalQty
        {
            get { return _TotalQty; }
            set
            {
                if (_TotalQty != value)
                {
                    _TotalQty = value;
                    RaisePropertyChanged("TotalQty");
                }
            }
        }

        private decimal _TotalRate;
        public decimal TotalRate
        {
            get { return _TotalRate; }
            set
            {
                if (_TotalRate != value)
                {
                    _TotalRate = value;
                    RaisePropertyChanged("TotalRate");
                }
            }
        }

        private decimal _TotalValuation;
        public decimal TotalValuation
        {
            get { return _TotalValuation; }
            set
            {
                if (_TotalValuation != value)
                {
                    _TotalValuation = value;
                    RaisePropertyChanged("TotalValuation");
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

        private bool _MoveFlag;   //movement type enable disable
        public bool MoveFlag
        {
            get { return _MoveFlag; }
            set { _MoveFlag = value; RaisePropertyChanged("MoveFlag"); }
        }

        private bool _PartyEnable;
        public bool PartyEnable
        {
            get { return _PartyEnable; }
            set { _PartyEnable = value; RaisePropertyChanged("PartyEnable"); }
        }

        #endregion

        #region List
        private List<PUR_T005_Flip> _FlipGridData;
        public List<PUR_T005_Flip> FlipGridData
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

        public List<ADM_M001_M_P> _PurchaseOrganisationList;
        public List<ADM_M001_M_P> PurchaseOrganisationList
        {
            get
            {
                return _PurchaseOrganisationList;
            }
            set
            {
                _PurchaseOrganisationList = value;
                RaisePropertyChanged("PurchaseOrganisationList");
            }
        }

        public List<ADM_M001_P_P> _PurchaseGroupList;
        public List<ADM_M001_P_P> PurchaseGroupList
        {
            get
            {
                return _PurchaseGroupList;
            }
            set
            {
                _PurchaseGroupList = value;
                RaisePropertyChanged("PurchaseGroupList");
            }
        }
        public List<ACC_M019_P> _CostCenterList;
        public List<ACC_M019_P> CostCenterList
        {
            get
            {
                return _CostCenterList;
            }
            set
            {
                _CostCenterList = value;
                RaisePropertyChanged("CostCenterList");
            }
        }
        public List<PUR_T005_P_PI_ItemsList> _ItemListForPopup;
        public List<PUR_T005_P_PI_ItemsList> ItemListForPopup
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
        public List<ADM_M002> _CurrancyList;
        public List<ADM_M002> CurrancyList
        {
            get
            {
                return _CurrancyList;
            }
            set
            {
                _CurrancyList = value;
                RaisePropertyChanged("CurrancyList");
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
        private List<GetItemDetailsEntity> _SalesUnitPriceCollection;
        public List<GetItemDetailsEntity> SalesUnitPriceCollection
        {
            get { return _SalesUnitPriceCollection; }
            set { _SalesUnitPriceCollection = value; RaisePropertyChanged("SalesUnitPriceCollection"); }
        }
        private List<GetItemDetailsEntity> _SalesQFRCollection;
        public List<GetItemDetailsEntity> SalesQFRCollection
        {
            get { return _SalesQFRCollection; }
            set { _SalesQFRCollection = value; RaisePropertyChanged("SalesQFRCollection"); }
        }
        private List<GetItemDetailsEntity> _SalesDispatchCollection;
        public List<GetItemDetailsEntity> SalesDispatchCollection
        {
            get { return _SalesDispatchCollection; }
            set { _SalesDispatchCollection = value; RaisePropertyChanged("SalesDispatchCollection"); }
        }
        private List<GetItemDetailsEntity> _SalesProjDispatchCollection;
        public List<GetItemDetailsEntity> SalesProjDispatchCollection
        {
            get { return _SalesProjDispatchCollection; }
            set { _SalesProjDispatchCollection = value; RaisePropertyChanged("SalesProjDispatchCollection"); }
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
        private ICollectionView _payeeCollection;
        public ICollectionView PayeeCollection
        {
            get { return _payeeCollection; }
            set { _payeeCollection = value; RaisePropertyChanged("PayeeCollection"); }
        }
        private ICollectionView _uomCollection;
        public ICollectionView UomCollection
        {
            get { return _uomCollection; }
            set { _uomCollection = value; RaisePropertyChanged("UomCollection"); }
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
        private ICollectionView _payTermCollection;
        public ICollectionView PayTermCollection
        {
            get { return _payTermCollection; }
            set { _payTermCollection = value; RaisePropertyChanged("PayTermCollection"); }
        }
        private ICollectionView _paymethodCollection;
        public ICollectionView PayMethodCollection
        {
            get { return _paymethodCollection; }
            set { _paymethodCollection = value; RaisePropertyChanged("PayMethodCollection"); }
        }
        private ICollectionView _currancyCollection;
        public ICollectionView CurrancyCollection
        {
            get { return _currancyCollection; }
            set { _currancyCollection = value; RaisePropertyChanged("CurrancyCollection"); }
        }

        private ICollectionView _purchase_orgCollection;
        public ICollectionView Purchase_OrgCollection
        {
            get { return _purchase_orgCollection; }
            set { _purchase_orgCollection = value; RaisePropertyChanged("Purchase_OrgCollection"); }
        }

        private ICollectionView _purchase_groupCollection;
        public ICollectionView purchase_groupCollection
        {
            get { return _purchase_groupCollection; }
            set
            {
                _purchase_groupCollection = value;
                RaisePropertyChanged("purchase_groupCollection");
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
        private ICollectionView _dataGridviewFilter;
        // This DataGridView filter Schedule Lines for selected item. it will show only schedule for selected item.
        public ICollectionView DataGridViewFilter
        {
            get { return _dataGridviewFilter; }
            set { _dataGridviewFilter = value; RaisePropertyChanged("DataGridViewFilter"); }
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
        private ICollectionView _doc_typeCollection;
        public ICollectionView doc_typeCollection
        {
            get { return _doc_typeCollection; }
            set
            {
                _doc_typeCollection = value;
                RaisePropertyChanged("doc_typeCollection");
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
        //ItemListForPopup
        private ICollectionView _popupItemCollection;
        public ICollectionView PopupItemCollection
        {
            get { return _popupItemCollection; }
            set { _popupItemCollection = value; RaisePropertyChanged("PopupItemCollection"); }
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

        #region StringList Variables
        private List<string> _strListItems;
        public List<string> StringListItems
        {
            get { return _strListItems; }
            set
            {
                if (_strListItems != value)
                {
                    _strListItems = value;
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
                            MasterEntity.amt_in_wordsLoc = num.AmountInWords(Convert.ToDecimal(MasterEntity.loc_curr));
                        }
                        else
                        {
                            MasterEntity.amt_in_wordsLoc = "";
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

                    //This will get called when the property of an object inside the collection changes
                    this.ErrorExist = MasterEntity.HasErrors;
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
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
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
                    if (sender.ToString() == "qty" || sender.ToString() == "unit_price" || sender.ToString() == "tax_id" || sender.ToString() == "active" || sender.ToString() == "discount")
                    {

                        Computation(true, dgSelectedIndexItem, true); ;//this is in use 
                        QtyCalculation();
                        UpdateQtyInLicence();
                    }



                    this.ErrorExist = MasterEntity.HasErrors;
                    if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = ItemsEntity[dgSelectedIndexItem].HasErrors;

                    }
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
        private void CalWithHoldingTax()
        {
            try
            {
                if (MCTemp.withholdinglist != null && MasterEntity.withholding_tax != null && MasterEntity.withholding_tax != "")
                {
                    ACC_M025_P POPUPEntityObject = MCTemp.withholdinglist.Where(x => x.wtax_code == MasterEntity.withholding_tax).ToList()[0];
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
        private void TaxComputation_old(bool Compute)
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
                        if (ItemsEntity[dgSelectedIndexItem].qty > 0 && ItemsEntity[dgSelectedIndexItem].unit_price > 0 && ItemsEntity[dgSelectedIndexItem].active != false) // Must not null or empty.
                        {
                            if (ItemsEntity[dgSelectedIndexItem].discount == null || ItemsEntity[dgSelectedIndexItem].discount.ToString().Trim() == "")
                            {
                                ItemsEntity[dgSelectedIndexItem].discount = 0;
                            }
                            ItemsEntity[dgSelectedIndexItem].subtotal = (ItemsEntity[dgSelectedIndexItem].qty * ItemsEntity[dgSelectedIndexItem].unit_price) - ((ItemsEntity[dgSelectedIndexItem].qty * ItemsEntity[dgSelectedIndexItem].unit_price) * (ItemsEntity[dgSelectedIndexItem].discount / 100));
                        }
                        #region Remove previously assign Taxes to apply new for perticuler item row.
                        //if (TotalDocumentTaxes.Count > 0 && ItemsEntity[dgSelectedIndexItem].tax_id != null) // Remove previously assign Taxes to apply new for perticuler item row.//Condition satisfy only if Selected Item not null.
                        if (ItemsEntity[dgSelectedIndexItem].tax_id != null && ItemsEntity[dgSelectedIndexItem].active == true) // Remove previously assign Taxes to apply new for perticuler item row.//Condition satisfy only if Selected Item not null.
                        {
                            if (!String.IsNullOrEmpty(ItemsEntity[dgSelectedIndexItem].tax_id.Trim()) && ItemsEntity[dgSelectedIndexItem].active != false) //Condition satisfy only if Selected Item having Tax assigned.
                            {
                                List<ACC_T006_C> copy = new List<ACC_T006_C>();
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
                                                BasePrice = ItemsEntity[dgSelectedIndexItem].subtotal / TaxValue;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = ItemsEntity[dgSelectedIndexItem].subtotal - BasicItemAmount;
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
                                                    BasePrice = ItemsEntity[dgSelectedIndexItem].subtotal + PreviousTaxValueForBasePrice;
                                                }
                                                BasicItemAmount = ItemsEntity[dgSelectedIndexItem].subtotal;
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
                                                BasePrice = ItemsEntity[dgSelectedIndexItem].subtotal - TaxValue;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = ItemsEntity[dgSelectedIndexItem].subtotal - BasicItemAmount;
                                            }
                                            else if (SingleTax.Price_include == false)
                                            {
                                                BasePrice = ItemsEntity[dgSelectedIndexItem].subtotal;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = TaxValue;
                                            }
                                        }
                                        #endregion

                                        TotalDocumentTaxes.Add(new ACC_T006_C() { id = 0, tax_amount = TaxAmount, account_id = 0, sequence = SingleTax.sequence, doc_no = MasterEntity.doc_no, manual = "Auto", base_amount = BasePrice, amount = SingleTax.amount, tax_code_id = SingleTax.id, account_analytic_id = 0, base_code_id = SingleTax.id, tax_name = SingleTax.description, gl_code = "", ItemCode = ItemsEntity[dgSelectedIndexItem].ItemCode, sku = ItemsEntity[dgSelectedIndexItem].sku, item_line_id = ItemsEntity[dgSelectedIndexItem].id, fin_year = "2016", active = true, location_Id = AppSessionState.location_Id, comp_code = AppSessionState.comp_code });
                                    }

                                }

                                #endregion
                            }
                            else if (ItemsEntity[dgSelectedIndexItem].tax_id == "" || ItemsEntity[dgSelectedIndexItem].tax_id == null || ItemsEntity[dgSelectedIndexItem].active == false) // Remove previously assign Taxes from TotalDocumentTaxes if removed from Item.//Condition satisfy only if Selected Item not null and Active status is false.
                            {
                                List<ACC_T006_C> copy2 = new List<ACC_T006_C>();
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
                            List<ACC_T006_C> copy2 = new List<ACC_T006_C>();
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

                        TaxtTotal = TotalDocumentTaxes.Sum(x => x.tax_amount);
                        TaxtTotal = TotalDocumentTaxes.Where(item => item.active != false).Sum(item => item.tax_amount);
                        MasterEntity.tax_amount = TaxtTotal;
                        //UnTaxTotal = ItemsEntity.Sum(x => x.sub_total);
                        UnTaxTotal = ItemsEntity.Where(item => item.active != false).Sum(item => item.subtotal);
                        MasterEntity.acc_amount = UnTaxTotal;
                        GrandTotal = UnTaxTotal + TaxtTotal;
                        MasterEntity.total = GrandTotal;
                        MasterEntity.roundup_total = decimal.Round((decimal)GrandTotal);
                        MasterEntity.round_up = MasterEntity.roundup_total - GrandTotal;

                        if (MasterEntity.exch_rate == null && MasterEntity.exch_rate <= 0)
                        {
                            MasterEntity.exch_rate = 1;
                        }
                        MasterEntity.loc_curr = (Convert.ToDecimal(MasterEntity.roundup_total) * Convert.ToDecimal(MasterEntity.exch_rate));

                        if (MasterEntity.roundup_total > 0)
                        {
                            ADM_M037 curr_obj = new ADM_M037();
                            curr_obj = ((List<ADM_M037>)AppSessionState.CurrencyList).Where(x => x.curr_code == MasterEntity.curr_code).ToList()[0];
                            MasterEntity.amt_word = num.AmountInWords(Convert.ToDecimal(MasterEntity.roundup_total), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word);
                        }
                        else
                        { MasterEntity.amt_word = ""; }

                        //var GroupByTaxQuery = from wo in TotalDocumentTaxes
                        //                      group wo by wo.tax_name  // tax_code_id replace with tax_name due to manual Tax integration.
                        //            into g
                        //                      select new PUR_T002_D
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
                        //TotalDocumentTaxesSummury = new ObservableCollection<PUR_T002_D>(GroupByTaxQuery.OrderBy(tax => tax.tax_name));
                        #endregion
                        #endregion
                    }

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
                    decimal? local_tax_amt = 0;
                    decimal? local_total_amt = 0;
                    decimal? local_round_up = 0;
                    decimal? local_roundup_total = 0;
                    decimal? local_net_value = 0;

                    decimal? gross_value = 0;
                    decimal? effective_value = 0;
                    decimal? disc_amt = 0;
                    decimal? disc_percent_item = 0;
                    decimal? sub_total_item = 0;

                    decimal? gross_value_A = 0;
                    decimal? discount_amt_A = 0;
                    decimal? net_value_A = 0;


                    if (ItemsEntity != null && ItemsEntity.Count > 0 && ItemRowIndex >= 0 && ItemRowIndex < ItemsEntity.Count) //Condition satisfy only if Items collection is not empty.
                    {
                        if (ItemsEntity[ItemRowIndex].qty >= 0 && ItemsEntity[ItemRowIndex].unit_price >= 0 && ItemsEntity[ItemRowIndex].active != false) // Must not null or empty.
                        {
                            gross_value_A = (ItemsEntity[ItemRowIndex].qty * ItemsEntity[ItemRowIndex].unit_price);
                            gross_value_A = Math.Round((gross_value_A ?? 0), RoundUpDecimals);
                            ItemsEntity[ItemRowIndex].gross_value = gross_value_A;
                            ItemsEntity[ItemRowIndex].local_gross_value = (gross_value_A * MasterEntity.exch_rate);
                            if (ItemsEntity[ItemRowIndex].discount.HasValue)
                            {
                                disc_percent_item = ItemsEntity[ItemRowIndex].discount;
                            }
                            sub_total_item = Math.Round((gross_value_A ?? 0) - ((gross_value_A ?? 0) * ((disc_percent_item ?? 0) / 100)), RoundUpDecimals);
                            ItemsEntity[ItemRowIndex].subtotal = sub_total_item;
                            ItemsEntity[ItemRowIndex].local_subtotal = (sub_total_item * MasterEntity.exch_rate);
                            discount_amt_A = gross_value_A - sub_total_item;
                            ItemsEntity[ItemRowIndex].discount_amt = discount_amt_A;
                            ItemsEntity[ItemRowIndex].local_discount = (discount_amt_A * MasterEntity.exch_rate);
                            ItemsEntity[ItemRowIndex].net_value = sub_total_item;
                            ItemsEntity[ItemRowIndex].local_net_value = (sub_total_item * MasterEntity.exch_rate);
                            ItemsEntity[ItemRowIndex].effective_value = sub_total_item;
                        }
                        #region Calculate Taxes for New/Edited Items row.
                        if (!String.IsNullOrEmpty(ItemsEntity[ItemRowIndex].tax_id) && ItemsEntity[ItemRowIndex].active == true) //Condition satisfy only if Selected Item not null and Taxes are applied.
                        {
                            #region Tax Not Null

                            List<ACC_M013_P> TaxListTemp = new List<ACC_M013_P>();
                            string[] TaxArray = ItemsEntity[ItemRowIndex].tax_id.Trim().Split(',');
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
                                decimal? Temptax_amount_A = 0;
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

                                    net_value = 0;
                                    other_charges = 0;
                                    local_tax_amt = 0;
                                    local_total_amt = 0;
                                    local_round_up = 0;
                                    local_roundup_total = 0;
                                    local_net_value = 0;

                                    gross_value = 0;
                                    effective_value = 0;
                                    disc_amt = 0;
                                    net_value_A = 0;

                                    #region Percentage
                                    if (SingleTax.t_type == "Percentage" && SingleTax.amount > 0)
                                    {
                                        if (SingleTax.Price_include == true)
                                        {
                                            TaxValue = (SingleTax.amount) / 100 + 1;
                                            BasePrice = ItemsEntity[ItemRowIndex].subtotal / TaxValue;
                                            BasicItemAmount = BasePrice;
                                            TaxAmount = ItemsEntity[ItemRowIndex].subtotal - BasicItemAmount;
                                        }
                                        else if (SingleTax.Price_include == false)
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
                                        if (SingleTax.Price_include == true)
                                        {
                                            BasePrice = ItemsEntity[ItemRowIndex].subtotal - TaxValue;
                                            BasicItemAmount = BasePrice;
                                            TaxAmount = ItemsEntity[ItemRowIndex].subtotal - BasicItemAmount;
                                        }
                                        else if (SingleTax.Price_include == false)
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
                                            location_Id = AppSessionState.location_Id,
                                            comp_code = AppSessionState.comp_code,
                                            trns_key_code = "PTX",

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
                                    Temptax_amount_A = Temptax_amount_A + TaxAmount;
                                    ItemsEntity[ItemRowIndex].tax_amount = Temptax_amount_A;
                                    net_value_A = gross_value_A - discount_amt_A + Temptax_amount_A;
                                    ItemsEntity[ItemRowIndex].net_value = net_value_A;
                                    ItemsEntity[ItemRowIndex].local_net_value = (net_value_A * MasterEntity.exch_rate);
                                    ItemsEntity[ItemRowIndex].effective_value = net_value_A;
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
                                var ChildTaxVar = MC.TaxList.FirstOrDefault(T => T.id == tax.tax_code_id);
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

                        //TaxtTotal = TotalDocumentTaxes.Sum(x => x.tax_amount);
                        TaxtTotal = TotalDocumentTaxes.Where(item => item.active != false && item.manual == "Auto").Sum(item => item.tax_amount);
                        MasterEntity.tax_amount = TaxtTotal;
                        MasterEntity.tax_amount = TaxtTotal;

                        local_tax_amt = (TaxtTotal * MasterEntity.exch_rate);
                        MasterEntity.local_tax_amount = local_tax_amt;

                        //UnTaxTotal = ItemsEntity.Sum(x => x.sub_total);
                        UnTaxTotal = ItemsEntity.Where(item => item.active != false).Sum(item => item.subtotal);
                        MasterEntity.acc_amount = UnTaxTotal;


                        net_value = UnTaxTotal + TaxtTotal;
                        MasterEntity.net_value = net_value;
                        other_charges = TotalDocumentTaxes.Where(item => item.active != false && item.manual == "Manual").Sum(item => item.tax_amount);
                        MasterEntity.other_charges = other_charges;

                        local_net_value = (net_value * MasterEntity.exch_rate);
                        MasterEntity.local_net_value = local_net_value;

                        GrandTotal = net_value + other_charges;
                        MasterEntity.total = GrandTotal;

                        local_total_amt = (GrandTotal * MasterEntity.exch_rate);
                        MasterEntity.local_total = local_total_amt;

                        if (AutoRoundUpFlag == true)
                        {
                            MasterEntity.roundup_total = decimal.Round((decimal)GrandTotal);
                            MasterEntity.round_up = MasterEntity.roundup_total - GrandTotal;
                        }
                        else
                        {
                            MasterEntity.roundup_total = GrandTotal + MasterEntity.round_up;
                        }
                        MasterEntity.local_round_up = (MasterEntity.round_up * MasterEntity.exch_rate);
                        MasterEntity.local_roundup_total = (MasterEntity.roundup_total * MasterEntity.exch_rate);


                        gross_value = ItemsEntity.Where(item => item.active != false).Sum(item => item.qty * item.unit_price);
                        MasterEntity.gross_value = gross_value;

                        effective_value = GrandTotal;
                        MasterEntity.effective_value = effective_value;

                        disc_amt = gross_value - UnTaxTotal;
                        MasterEntity.disc_amt = disc_amt;

                        if (MasterEntity.roundup_total > 0 && !string.IsNullOrWhiteSpace(MasterEntity.curr_code))
                        {
                            ADM_M037 curr_obj = new ADM_M037();
                            curr_obj = ((List<ADM_M037>)AppSessionState.CurrencyList).Where(x => x.curr_code == MasterEntity.curr_code).ToList()[0];
                            MasterEntity.amt_word = num.AmountInWords(Convert.ToDecimal(MasterEntity.roundup_total), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word);
                        }
                        else
                        { MasterEntity.amt_word = ""; }
                        MasterEntity.loc_curr = (Convert.ToDecimal(MasterEntity.roundup_total) * Convert.ToDecimal(MasterEntity.exch_rate));
                        //var GroupByTaxQuery = from wo in TotalDocumentTaxes
                        //                      group wo by wo.tax_name
                        //            into g
                        //                      select new ACC_T006_C
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
                        //TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_C>(GroupByTaxQuery.OrderBy(tax => tax.tax_name));
                        #endregion
                        #endregion
                    }
                }
            }
            catch (Exception Ex) { }
        }
        private void TaxComputationOnReferance_old(bool Compute, int RowIndex)
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

                    if (ItemsEntity != null && ItemsEntity.Count > 0 && RowIndex >= 0 && RowIndex < ItemsEntity.Count) //Condition satisfy only if Items collection is not empty.
                    {
                        if (ItemsEntity[RowIndex].qty >= 0 && ItemsEntity[RowIndex].unit_price >= 0 && ItemsEntity[RowIndex].active != false) // Must not null or empty.
                        {
                            if (ItemsEntity[RowIndex].discount == null || ItemsEntity[RowIndex].discount.ToString().Trim() == "")
                            {
                                ItemsEntity[RowIndex].discount = 0;
                            }
                            ItemsEntity[RowIndex].subtotal = (ItemsEntity[RowIndex].qty * ItemsEntity[RowIndex].unit_price) - ((ItemsEntity[RowIndex].qty * ItemsEntity[RowIndex].unit_price) * (ItemsEntity[RowIndex].discount / 100));
                            // ItemsEntity[RowIndex].subtotal = ItemsEntity[RowIndex].qty * ItemsEntity[RowIndex].unit_price;
                        }
                        #region Remove previously assign Taxes to apply new for perticuler item row.
                        //if (TotalDocumentTaxes.Count > 0 && ItemsEntity[RowIndex].tax_id != null) // Remove previously assign Taxes to apply new for perticuler item row.//Condition satisfy only if Selected Item not null.
                        if (ItemsEntity[RowIndex].tax_id != null && ItemsEntity[RowIndex].active == true) // Remove previously assign Taxes from TotalDocumentTaxes to apply new for perticuler item row.//Condition satisfy only if Selected Item not null  and Active status is true.
                        {
                            if (!String.IsNullOrEmpty(ItemsEntity[RowIndex].tax_id.Trim()) && ItemsEntity[RowIndex].active != false) //Condition satisfy only if Selected Item having Tax assigned.
                            {
                                List<ACC_T006_C> copy = new List<ACC_T006_C>();
                                copy = TotalDocumentTaxes.ToList();
                                foreach (var tax in copy)
                                {
                                    if (tax.ItemCode == ItemsEntity[RowIndex].ItemCode && tax.sku == ItemsEntity[RowIndex].sku)
                                    {
                                        TotalDocumentTaxes.Remove(tax);
                                    }
                                }
                                #region Tax Not Null

                                List<ACC_M013_P> TaxListTemp = new List<ACC_M013_P>();
                                string[] TaxArray = ItemsEntity[RowIndex].tax_id.Trim().Split(',');
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
                                                BasePrice = ItemsEntity[RowIndex].subtotal / TaxValue;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = ItemsEntity[RowIndex].subtotal - BasicItemAmount;
                                            }
                                            else if (SingleTax.Price_include == false)
                                            {
                                                TaxValue = (SingleTax.amount) / 100;
                                                if (TaxListForBaseInclude.Length > 0)
                                                {
                                                    PreviousTaxValueForBasePrice = TotalDocumentTaxes.Where(tax => tax.sequence < SingleTax.sequence && tax.ItemCode == ItemsEntity[RowIndex].ItemCode && tax.sku == ItemsEntity[RowIndex].sku && tax.item_line_id == ItemsEntity[RowIndex].id && tax.tax_code_id.In(TaxListForBaseInclude)).Sum(tax => tax.tax_amount); // Get Base amount for Calculation.
                                                }
                                                if (SingleTax.parent_id != null) // Collect Base price for This single child Tax.
                                                {
                                                    BasePrice = TotalDocumentTaxes.Where(tax => tax.tax_code_id == SingleTax.parent_id && tax.ItemCode == ItemsEntity[RowIndex].ItemCode && tax.sku == ItemsEntity[RowIndex].sku && tax.item_line_id == ItemsEntity[RowIndex].id).Single().tax_amount;
                                                }
                                                else // Collect Base Price for this parent Tax.
                                                {
                                                    BasePrice = ItemsEntity[RowIndex].subtotal + PreviousTaxValueForBasePrice;
                                                }
                                                BasicItemAmount = ItemsEntity[RowIndex].subtotal;
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
                                                BasePrice = ItemsEntity[RowIndex].subtotal - TaxValue;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = ItemsEntity[RowIndex].subtotal - BasicItemAmount;
                                            }
                                            else if (SingleTax.Price_include == false)
                                            {
                                                BasePrice = ItemsEntity[RowIndex].subtotal;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = TaxValue;
                                            }
                                        }
                                        #endregion

                                        TotalDocumentTaxes.Add(new ACC_T006_C() { id = 0, tax_amount = TaxAmount, account_id = 0, sequence = SingleTax.sequence, doc_no = MasterEntity.doc_no, manual = "Auto", base_amount = BasePrice, amount = SingleTax.amount, tax_code_id = SingleTax.id, account_analytic_id = 0, base_code_id = SingleTax.id, tax_name = SingleTax.description, gl_code = "", ItemCode = ItemsEntity[RowIndex].ItemCode, sku = ItemsEntity[RowIndex].sku, item_line_id = ItemsEntity[RowIndex].id, fin_year = "2015", active = true, location_Id = AppSessionState.location_Id, comp_code = AppSessionState.comp_code });
                                    }

                                }

                                #endregion
                            }
                        }
                        else if (ItemsEntity[RowIndex].tax_id != null && ItemsEntity[RowIndex].active == false) // Remove previously assign Taxes from TotalDocumentTaxes if removed from Item.//Condition satisfy only if Selected Item not null and Active status is false.
                        {
                            List<ACC_T006_C> copy2 = new List<ACC_T006_C>();
                            copy2 = TotalDocumentTaxes.ToList();
                            foreach (var tax in copy2)
                            {
                                if (tax.ItemCode == ItemsEntity[RowIndex].ItemCode && tax.sku == ItemsEntity[RowIndex].sku)
                                {
                                    TotalDocumentTaxes.Remove(tax);
                                }
                            }
                        }
                        #region Final Computation
                        TaxtTotal = TotalDocumentTaxes.Sum(x => x.tax_amount);
                        TaxtTotal = TotalDocumentTaxes.Where(item => item.active != false).Sum(item => item.tax_amount);
                        MasterEntity.tax_amount = TaxtTotal;
                        //UnTaxTotal = ItemsEntity.Sum(x => x.sub_total);
                        UnTaxTotal = ItemsEntity.Where(item => item.active != false).Sum(item => item.subtotal);
                        MasterEntity.acc_amount = UnTaxTotal;
                        GrandTotal = UnTaxTotal + TaxtTotal;
                        MasterEntity.total = GrandTotal;
                        MasterEntity.roundup_total = decimal.Round((decimal)GrandTotal);
                        MasterEntity.round_up = MasterEntity.roundup_total - GrandTotal;
                        if (MasterEntity.exch_rate == null && MasterEntity.exch_rate <= 0)
                        {
                            MasterEntity.exch_rate = 1;
                        }
                        MasterEntity.loc_curr = (Convert.ToDecimal(MasterEntity.roundup_total) * Convert.ToDecimal(MasterEntity.exch_rate));

                        if (MasterEntity.roundup_total > 0)
                        {
                            ADM_M037 curr_obj = new ADM_M037();
                            curr_obj = ((List<ADM_M037>)AppSessionState.CurrencyList).Where(x => x.curr_code == MasterEntity.curr_code).ToList()[0];
                            MasterEntity.amt_word = num.AmountInWords(Convert.ToDecimal(MasterEntity.roundup_total), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word);
                        }
                        else
                        { MasterEntity.amt_word = ""; }

                        //var GroupByTaxQuery = from wo in TotalDocumentTaxes
                        //                      group wo by wo.tax_name // tax_code_id replace with tax_name due to manual Tax integration.
                        //            into g
                        //                      select new SEL_T003_C
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
                        //TotalDocumentTaxes = new ObservableCollection<SEL_T003_C>(GroupByTaxQuery.OrderBy(tax => tax.tax_name));
                        #endregion
                        #endregion
                    }


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
        private void QtyCalculation()
        {
            try
            {
                TotalQty = Convert.ToDecimal(ItemsEntity.Where(item => item.active != false).Sum(item => item.qty));
                TotalRate = Convert.ToDecimal(ItemsEntity.Where(item => item.active != false).Sum(item => item.unit_price));
                TotalValuation = TotalQty * TotalRate;
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
                        item.location_Id = AppSessionState.location_Id;
                        item.comp_code = AppSessionState.comp_code;
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
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
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
                        item.location_Id = AppSessionState.location_Id;
                        item.comp_code = AppSessionState.comp_code;
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
                        item.comp_code = AppSessionState.comp_code;
                        item.location_Id = AppSessionState.location_Id;
                        item.client = AppSessionState.client;
                        item.active = true;
                        item.add_by = AppSessionState.UserID;
                        item.editby = AppSessionState.UserID;
                        item.t_status = "001";
                        item.t_display = (from o in MC.t_statusList where o.t_status == item.t_status select o.t_display).FirstOrDefault();
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
                                Computation(true, dgSelectedIndexItem, true);
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
                        Computation(true, dgSelectedIndexItem, true);
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
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }

        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdRoundUpManual { get; private set; }
        public RelayCommand<object> CmdInsertSupplierParty { get; private set; }
        public RelayCommand<object> CmdInsertPayee { get; private set; }//check 
        public RelayCommand<object> CmdInsertPurchaseOrg { get; private set; }
        public RelayCommand<object> CmdInsertPurchaseGroup { get; private set; }
        public RelayCommand<object> CmdInsertUOM { get; private set; }
        public RelayCommand<object> CmdInsertPayTerms { get; private set; }
        public RelayCommand<object> CmdInsertPayMethod { get; private set; }
        public RelayCommand<object> CmdInsertCurrency { get; private set; }
        public RelayCommand<object> CmdInsertCostCenter { get; private set; }
        public RelayCommand<object> CmdInsertJournal { get; private set; }
        public RelayCommand<object> CmdInsertBank { get; private set; }
        public RelayCommand<object> CmdInsertPartyBank { get; private set; }
        public RelayCommand<object> CmdInsertTaxAccount { get; private set; }
        public RelayCommand<object> CmdInsertDocType { get; private set; }
        public RelayCommand<object> CmdInsertNastroBank { get; private set; }
        public RelayCommand<object> CmdInsertwtunit { get; private set; }
        public RelayCommand<object> CmdInsertVolUnit { get; private set; }
        public RelayCommand<object> CmdInsertReferenceDoc { get; private set; }
        public RelayCommand<object> CmdInsertItem { get; private set; }
        public RelayCommand<object> CmdInsertItemCategory { get; private set; }
        public RelayCommand<object> CmdLoadDocumentWithReferenceDocumentNumber { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CommandproductDescription { get; private set; }
        public RelayCommand<object> CommandFormType { get; private set; }
        public RelayCommand<object> CmdInsertPlant { get; private set; }
        public RelayCommand<object> commandSource { get; private set; }
        public RelayCommand<IList> CollectionChangedCommand { get; private set; }
        public RelayCommand<IList> SelectionChangedParaValCommand { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<IList> SelectionChangeCommandItemDetails { get; private set; }
        public RelayCommand<object> CommandAddSelectedTax { get; private set; }
        public RelayCommand<object> cmdDeleteTax { get; private set; }
        public RelayCommand<object> ManualTaxChangedCommand { get; private set; }
        public RelayCommand<object> TaxPopupCommand { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CommandForLoadBackFlip { get; private set; }
        public RelayCommand<object> cmdRefDoc { get; private set; }
        public RelayCommand<object> CommandIncoterms { get; private set; }
        public RelayCommand<object> CommandLicenseAdvance { get; private set; }
        public RelayCommand<object> CommandLicenseEPCG { get; private set; }
        public RelayCommand<object> CommandServiceProvider { get; private set; }
        public RelayCommand<object> CmdLicence { get; private set; }
        public RelayCommand<object> CmddgIncoterms { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowLicence { get; private set; }
        public RelayCommand<object> cmdBussPlace { get; private set; }
        public RelayCommand<object> cmddgBussPlace { get; private set; }
        public RelayCommand<object> CmddgShipToParty { get; private set; }
        public RelayCommand<object> CmdCondType { get; private set; }
        public RelayCommand<object> CmddgCurrency { get; private set; }
        public RelayCommand<object> cmdOpenAttachments { get; private set; }
        public RelayCommand<object> CmdItemInfo { get; private set; }
        public RelayCommand<object> CommandLoadHistory { get; private set; }
        public RelayCommand<object> CommandFltrDocType { get; private set; }
        public RelayCommand<object> CommandFltrStatus { get; private set; }
        public RelayCommand<object> CommandFltrSoldToParty { get; private set; }
        public RelayCommand<object> CmdAddSelectedRef { get; private set; }
        public RelayCommand<object> CmdWithoutRefernce { get; private set; }
        public RelayCommand<object> CmdAddTransporterForTax { get; private set; }
        public RelayCommand<object> Commandwithholding { get; private set; }
        public RelayCommand<object> cmdTraceReport { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdLocalCurrencyInvoice { get; private set; }

        #endregion

        #region Constructor
        public PUR_T005_VM(string ts_code) : base()
        {
            CursorControl.SetBusyState();
            this.ts_code_vm = ts_code;
            MC = new MultipleContext_PUR_T005();
            MCTemp = new MultipleContext_PUR_T005();
            MasterEntity = new PUR_T005();
            SalesUnitPriceCollection = new List<GetItemDetailsEntity>();
            SalesQFRCollection = new List<GetItemDetailsEntity>();
            SalesDispatchCollection = new List<GetItemDetailsEntity>();
            SalesProjDispatchCollection = new List<GetItemDetailsEntity>();
            ItemsEntity = new ObservableCollection<PUR_T005_A>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
            LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
            //TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_C>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
            dgTotalTaxSummury = new ObservableCollection<PUR_T005_B>();
            FlipGridData = new List<PUR_T005_Flip>();
            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            MasterEntity.FrmDate = lastDayLastMonth.AddDays(-23);
            MasterEntity.ToDate = System.DateTime.Now;

            //MasterEntity.ValidateAsync().Wait();
            PUR_T005.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            PUR_T005_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            NotificationDataCollection = new List<NotificationData>();
            MoveFlag = true;
            parameter = false;
            LoadInitialData();
        }
        public PUR_T005_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            CursorControl.SetBusyState();
            MC = new MultipleContext_PUR_T005();
            MCTemp = new MultipleContext_PUR_T005();
            MasterEntity = new PUR_T005();
            SalesUnitPriceCollection = new List<GetItemDetailsEntity>();
            SalesQFRCollection = new List<GetItemDetailsEntity>();
            SalesDispatchCollection = new List<GetItemDetailsEntity>();
            SalesProjDispatchCollection = new List<GetItemDetailsEntity>();
            ItemsEntity = new ObservableCollection<PUR_T005_A>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
            LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
            //TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_C>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
            dgTotalTaxSummury = new ObservableCollection<PUR_T005_B>();
            FlipGridData = new List<PUR_T005_Flip>();
            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            MasterEntity.FrmDate = lastDayLastMonth.AddDays(-23);
            MasterEntity.ToDate = System.DateTime.Now;
            //MasterEntity.ValidateAsync().Wait();
            PUR_T005.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            PUR_T005_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            NotificationDataCollection = new List<NotificationData>();
            MoveFlag = true;
            parameter = false;
            LoadInitialData();
        }

        #endregion

        #region LoadInitialData
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                MasterEntity.doc_cat = "PQ";
                MasterEntity.doc_type = "PQ";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.po_code + "!@" + AppSessionState.EmpId;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MC, Request, "PurchaseInvoice", "Procurement", "LoadAll", 0, "");
                #region 
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdRoundUpManual = new RelayCommand<object>(items => { if (items == null) { return; } InsertRoundUpManual(items, isNewRecord); });
                CmdInsertSupplierParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertSupplierParty(items, isNewRecord); });
                CmdInsertReferenceDoc = new RelayCommand<object>(items => { if (items == null) { return; } InsertReferenceDoc(items); });
                CmdInsertPayee = new RelayCommand<object>(items => { if (items == null) { return; } InsertPayee(items); });
                CmdInsertPurchaseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseOrg(items); });
                CmdInsertPurchaseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseGroup(items); });
                CmdInsertPayTerms = new RelayCommand<object>(items => { if (items == null) { return; } InsertPayTerm(items); });
                CmdInsertPayMethod = new RelayCommand<object>(items => { if (items == null) { return; } InsertPayMethod(items); });
                CmdInsertCurrency = new RelayCommand<object>(items => { if (items == null) { return; } InsertCurrency(items); });
                CmdInsertBank = new RelayCommand<object>(items => { if (items == null) { return; } InsertBank(items); });
                CmdInsertPartyBank = new RelayCommand<object>(items => { if (items == null) { return; } InsertPartyBank(items); });
                CmdInsertJournal = new RelayCommand<object>(items => { if (items == null) { return; } InsertJournal(items); });
                CmdInsertItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara, true, true, true); });
                CmdInsertItemCategory = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItemCategory(cmdPara, false, true, true); });
                CmdInsertUOM = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOM(cmdPara, false, true, true); });
                CmdInsertwtunit = new RelayCommand<object>(items => { if (items == null) { return; } InsertwtUOM(items, false, true, true); });
                CmdInsertVolUnit = new RelayCommand<object>(items => { if (items == null) { return; } InsertvolUOM(items, false, true, true); });
                CmdDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
                CmdInsertPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
                CmdInsertNastroBank = new RelayCommand<object>(items => { if (items == null) { return; } InsertNastroBank(items); });
                CollectionChangedCommand = new RelayCommand<IList>(items => { if (items == null) { return; } InsertCollectionChanged(items); });
                SelectionChangedParaValCommand = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedParaValue(items); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                SelectionChangeCommandItemDetails = new RelayCommand<IList>(items => { if (items == null) { return; } ItemDetailsSelectionChangedMethod(items); });
                CommandAddSelectedTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSelectedTax(cmdPara); });
                cmdDeleteTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteTax(cmdPara); });
                ManualTaxChangedCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertManualTaxChangedCommand(cmdPara); });
                TaxPopupCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertManualTaxChangedCommand(cmdPara); });
                CommandForLoadBackFlip = new GalaSoft.MvvmLight.Command.RelayCommand(Load);
                CmdInsertCostCenter = new RelayCommand<object>(items => { if (items == null) { return; } InsertCostCenter(items); });
                cmdRefDoc = new RelayCommand<object>(items => { if (items == null) { return; } InsertRefDoc(items); });
                CommandIncoterms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertIncoterms(cmdPara); });// confirm assignment
                CommandLicenseAdvance = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicenseAdvance(cmdPara); });// confirm assignment
                CommandLicenseEPCG = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicenseEPCG(cmdPara); });// confirm assignment
                CommandServiceProvider = new RelayCommand<object>(items => { if (items == null) { return; } InsertServiceProvider(items, true); });
                CmdLicence = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicence(cmdPara, false, true, true); });
                CommandDeleteDataGridRowLicence = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_ItemLicence(cmdPara); });// confirm assignment
                CmddgIncoterms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgIncoterms(cmdPara, false, true, true); });
                cmdBussPlace = new RelayCommand<object>(items => { if (items == null) { return; } InsertBussPlace(items); });
                cmddgBussPlace = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgBussPlace(cmdPara, false, true, true); });
                CmddgShipToParty = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgShipToParty(cmdPara, false, true, true); });
                CmdCondType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertConditiontype(cmdPara); });
                CmddgCurrency = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgCurrency(cmdPara); });
                cmdOpenAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenDocumentViewer(cmdPara); });
                CmdItemInfo = new RelayCommand<object>(items => { if (items == null) { return; } FilterItemSalesData(items); });
                CommandLoadHistory = new RelayCommand<object>(items => { if (items == null) { return; } LoadHistory(); });
                CommandFltrStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrStatus(items); });
                CommandFltrSoldToParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrSoldToParty(items); });
                CommandFltrDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrDocType(items); });
                CmdAddSelectedRef = new RelayCommand<object>(items => { if (items == null) { return; } AddSelectedRef(items); });
                CmdWithoutRefernce = new RelayCommand<object>(items => { if (items == null) { return; } LoadWithoutReference(items); });
                CmdAddTransporterForTax = new RelayCommand<object>(items => { if (items == null) { return; } InsertTransporterForTax(items); });
                Commandwithholding = new RelayCommand<object>(items => { if (items == null) { return; } InsertWithHolding(items); });
                cmdTraceReport = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } TraceReport(cmdPara); });
                cmdLocalCurrencyInvoice = new GalaSoft.MvvmLight.Command.RelayCommand(() => { PrintLocalCurrencyInvoice(); });
                #endregion
                #region Autosuggest

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyNm);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").Contains(prefix)
                                    || (((ADM_M028_P)o).PartyNm ?? "").Contains(prefix);
                AutoSuggestTextViewModel = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyNm", true);
                AutoSuggestTextViewModel.AutoSuggestVM.IsEmptyValueAllowed = true;
                AutoSuggestTextViewModel.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M037)x).ind_trade);
                TheFilter = (o, prefix) => (((SYS_M037)o).ind_trade ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M037)o).trade_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTradeIndicator = new AutoSuggestTextViewModel<dynamic>(MC.Trade_Types, TheFilter, SuggestedValue, "ind_trade", true);
                ASTradeIndicator.AutoSuggestVM.IsEmptyValueAllowed = false;
                ASTradeIndicator.AutoSuggestVM.IsFreeTextAllowed = false;

                //New PopUP - Incoterms
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M044_P)x).incoterms);
                TheFilter = (o, prefix) => ((ADM_M044_P)o).incoterms.ToLower().Contains(prefix)
                                || ((ADM_M044_P)o).inco_desc.ToLower().Contains(prefix);
                ASIncoTerms = new AutoSuggestTextViewModel<dynamic>(MC.Incoterms, TheFilter, SuggestedValue, "incoterms", true);
                ASIncoTerms.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - EPCG licence
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M041_P)x).lic_cod);
                TheFilter = (o, prefix) => (((ADM_M041_P)o).lic_cod ?? "").ToLower().Contains(prefix);
                ASEPCG = new AutoSuggestTextViewModel<dynamic>(MC.LicenseEPCG, TheFilter, SuggestedValue, "lic_cod", true);
                ASEPCG.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Advance Licence
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M041_P)x).lic_cod);
                TheFilter = (o, prefix) => (((ADM_M041_P)o).lic_cod ?? "").ToLower().Contains(prefix);
                ASAdvance = new AutoSuggestTextViewModel<dynamic>(MC.LicenseAdvance, TheFilter, SuggestedValue, "lic_cod", true);
                ASAdvance.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - C&F Agent
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToLower().Contains(prefix)
                                    || (((ADM_M028_P)o).PartyNm ?? "").ToLower().Contains(prefix);
                ASCFAgent = new AutoSuggestTextViewModel<dynamic>(MC.ServiceProviders, TheFilter, SuggestedValue, "PartyId", true);
                ASCFAgent.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Reference Document No
                MasterEntity.ref_doc_type = "Goods Receipt Note";
                RefDocTempData = (from o in MC.Purchase_Invoice_Reference where o.doc_cat == "GR" select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T005_P_RefDoc)x).Ref_DocNo);
                TheFilter = (o, prefix) => (((PUR_T005_P_RefDoc)o).Ref_DocNo ?? "").ToString().ToLower().Contains(prefix)
                                        || (((PUR_T005_P_RefDoc)o).Ref_date).ToString().ToLower().Contains(prefix)
                                        || (((PUR_T005_P_RefDoc)o).PartyNm ?? "").ToString().ToLower().Contains(prefix)
                                        || (((PUR_T005_P_RefDoc)o).doc_cat ?? "").ToString().ToLower().Contains(prefix);
                ASRefDocNo = new AutoSuggestTextViewModel<dynamic>(RefDocTempData, TheFilter, SuggestedValue, "Ref_DocNo", true);
                ASRefDocNo.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Supplier Party
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix);
                ASSuppParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyId", true);
                ASSuppParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Payee
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix);
                ASPayee = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "payee_payer", true);
                ASPayee.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - As default
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T005_P_PI_ItemsList)x).ItemCode);
                TheFilter = (o, prefix) => (((PUR_T005_P_PI_ItemsList)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((PUR_T005_P_PI_ItemsList)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                //New PopUP - Item Category
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M003_P)x).sditem_cat_code);
                TheFilter = (o, prefix) => (((SYS_M003_P)o).sditem_cat_code ?? "").ToString().ToLower().Contains(prefix);
                ASItemCategory = new AutoSuggestTextViewModel<dynamic>(MC.ItemCategoryList, TheFilter, SuggestedValue, "item_cat", "sditem_cat_code", true);
                ASItemCategory.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Unit
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix);
                ASUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitList, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASUnit.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASUnit.AutoSuggestVM.IsFreeTextAllowed = true;

                //New PopUP - Weight Unit
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix);
                ASWeightUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitList, TheFilter, SuggestedValue, "weight_unit", "unit_code", true);
                ASWeightUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Volume Unit
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix);
                ASVolUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitList, TheFilter, SuggestedValue, "volume_unit", "unit_code", true);
                ASVolUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Tax Account
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_P)o).gl_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault1 = new AutoSuggestTextViewModel<dynamic>(MC.AccountList, TheFilter, SuggestedValue, "gl_code", "gl_code", true);
                ASDefault1.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault1.AutoSuggestVM.IsFreeTextAllowed = true;

                //New PopUP - Tax Account              
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((ACC_M003_P)o).gl_name ?? "").ToString().ToLower().Contains(prefix);
                ASTaxacc = new AutoSuggestTextViewModel<dynamic>(MC.AccountList, TheFilter, SuggestedValue, "gl_code", "gl_code", true);
                ASTaxacc.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Doc. Currency
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037_P)o).curr_code ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((ADM_M037_P)o).curr_name ?? "").ToString().ToLower().Contains(prefix);
                ASDocCurr = new AutoSuggestTextViewModel<dynamic>(MC.CurrencyList, TheFilter, SuggestedValue, "curr_code", true);
                ASDocCurr.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Plant PayTerms
                ObjSupply = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix);
                ASPlant = new AutoSuggestTextViewModel<dynamic>(ObjSupply, TheFilter, SuggestedValue, "location_Id", true);
                ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Payment Terms
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M007_P)x).p_term_code);
                TheFilter = (o, prefix) => (((ACC_M007_P)o).p_term_code ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((ACC_M007_P)o).p_term ?? "").ToString().ToLower().Contains(prefix);
                ASPaymentTerm = new AutoSuggestTextViewModel<dynamic>(MC.PayTerms, TheFilter, SuggestedValue, "p_term_code", true);
                ASPaymentTerm.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Payment Method
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M021_P)x).pay_mode);
                TheFilter = (o, prefix) => (((ACC_M021_P)o).pay_mode ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((ACC_M021_P)o).text_name ?? "").ToString().ToLower().Contains(prefix);
                ASPaymentMethod = new AutoSuggestTextViewModel<dynamic>(MC.PayMethod, TheFilter, SuggestedValue, "pay_mode", true);
                ASPaymentMethod.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Company Bank
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M004_P)x).hb_code);
                TheFilter = (o, prefix) => (((ACC_M004_P)o).hb_code ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((ACC_M004_P)o).bank_name ?? "").ToString().ToLower().Contains(prefix);
                ASCompanyBank = new AutoSuggestTextViewModel<dynamic>(MC.BankList, TheFilter, SuggestedValue, "bank_code", true);
                ASCompanyBank.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Nastro Bank
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M004_P)x).bank_code);
                TheFilter = (o, prefix) => (((ACC_M004_P)o).bank_code ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((ACC_M004_P)o).bank_name ?? "").ToString().ToLower().Contains(prefix);
                ASNastroBank = new AutoSuggestTextViewModel<dynamic>(MC.BankList, TheFilter, SuggestedValue, "bank_code", true);
                ASNastroBank.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Purchase Organisation
                PurchaseOrganisationList = (List<ADM_M001_M_P>)AppSessionState.ADM_M001_M_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_M_P)x).po_code);
                TheFilter = (o, prefix) => (((ADM_M001_M_P)o).po_code ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((ADM_M001_M_P)o).pur_org ?? "").ToString().ToLower().Contains(prefix);
                ASPurOrg = new AutoSuggestTextViewModel<dynamic>(PurchaseOrganisationList, TheFilter, SuggestedValue, "po_code", true);
                ASPurOrg.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Purchase Group
                PurchaseGroupList = (List<ADM_M001_P_P>)AppSessionState.ADM_M001_P_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_P_P)x).pg_code);
                TheFilter = (o, prefix) => (((ADM_M001_P_P)o).pg_code ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((ADM_M001_P_P)o).pg_name ?? "").ToString().ToLower().Contains(prefix);
                ASPurGrp = new AutoSuggestTextViewModel<dynamic>(PurchaseGroupList, TheFilter, SuggestedValue, "pg_code", true);
                ASPurGrp.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Cost Center
                CostCenterList = MC.Cost_Centers;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M019_P)x).cost_center);
                TheFilter = (o, prefix) => (((ACC_M019_P)o).cost_center ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((ACC_M019_P)o).cost_center_Desc ?? "").ToString().ToLower().Contains(prefix);
                ASCostCenter = new AutoSuggestTextViewModel<dynamic>(CostCenterList, TheFilter, SuggestedValue, "cost_center", true);
                ASCostCenter.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Journal
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M005_P)x).j_code);
                TheFilter = (o, prefix) => (((ACC_M005_P)o).j_code ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((ACC_M005_P)o).j_name ?? "").ToString().ToLower().Contains(prefix);
                ASJournal = new AutoSuggestTextViewModel<dynamic>(MC.Journals, TheFilter, SuggestedValue, "j_code", true);
                ASJournal.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M044_P)x).incoterms);
                TheFilter = (o, prefix) => (((ADM_M044_P)o).incoterms ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M044_P)o).inco_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault4 = new AutoSuggestTextViewModel<dynamic>(MC.Incoterms, TheFilter, SuggestedValue, "incoterms", "incoterms", true);
                ASDefault4.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault4.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M041_P)x).lic_cod);
                TheFilter = (o, prefix) => (((ADM_M041_P)o).lic_cod ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M041_P)o).lic_type ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASLicence = new AutoSuggestTextViewModel<dynamic>(MC.LicenceList, TheFilter, SuggestedValue, "licence_no", "lic_cod", true);
                ASLicence.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M044_P)x).incoterms);
                TheFilter = (o, prefix) => (((ADM_M044_P)o).incoterms ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M044_P)o).inco_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASdgIncoTerms = new AutoSuggestTextViewModel<dynamic>(MC.Incoterms, TheFilter, SuggestedValue, "incoterms", "incoterms", true);
                ASdgIncoTerms.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_C_P)x).buss_place);
                TheFilter = (o, prefix) => (((ADM_M003_C_P)o).buss_place ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003_C_P)o).plc_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASBussPlace = new AutoSuggestTextViewModel<dynamic>(MC.BussinessPlaceList, TheFilter, SuggestedValue, "buss_place", true);
                ASBussPlace.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_C_P)x).buss_place);
                TheFilter = (o, prefix) => (((ADM_M003_C_P)o).buss_place ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003_C_P)o).plc_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASdgBussPlace = new AutoSuggestTextViewModel<dynamic>(MC.BussinessPlaceList, TheFilter, SuggestedValue, "buss_place", "buss_place", true);
                ASdgBussPlace.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASdgShipToParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "ship_to_Party", "PartyId", true);
                ASdgShipToParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_O_P)x).con_type);
                TheFilter = (o, prefix) => (((ACC_M003_O_P)o).con_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_O_P)o).con_desc ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_O_P)o).con_cat ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_O_P)o).pricing_pro ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASConditionType = new AutoSuggestTextViewModel<dynamic>(MC.ConditionTypeList, TheFilter, SuggestedValue, "con_type", "con_type", true);
                ASConditionType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037_P)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M037_P)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASdgCurrency = new AutoSuggestTextViewModel<dynamic>(MC.CurrencyList, TheFilter, SuggestedValue, "curr_code", "curr_code", true);
                ASdgCurrency.AutoSuggestVM.IsEmptyValueAllowed = true;

                #region AutoSuggest Initilazation : Filtrs for View

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyNm);
                TheFilter = (o, prefix) => ((ADM_M028_P)o).PartyNm.ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M028_P)o).PartyId.ToString().ToLower().Contains(prefix.ToLower());
                ASFltrSoldToParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "Fltr_PartyNm", true);
                ASFltrSoldToParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASFltrt_status = new AutoSuggestTextViewModel<dynamic>(MC.t_statusList, TheFilter, SuggestedValue, "Fltr_t_display", true);
                ASFltrt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M007)x).doc_type);
                TheFilter = (o, prefix) => ((SYS_M007)o).doc_type_user.ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M007)o).doc_type ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDocType = new AutoSuggestTextViewModel<dynamic>(MC.doc_typeList, TheFilter, SuggestedValue, "Fltr_doc_type", true);
                ASDocType.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M025_P)x).wtax_code);
                TheFilter = (o, prefix) => (((ACC_M025_P)o).wtax_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M025_P)o).wtax_ncode ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASwithholding = new AutoSuggestTextViewModel<dynamic>(MC.withholdinglist, TheFilter, SuggestedValue, "withholding_tax", true);
                ASwithholding.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTaxTransporter = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyId", "PartyId", true);
                ASTaxTransporter.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion


                PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListPopup);
                PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                StringListItems = MC.ItemListPopup.Select(x => x.ItemCode).ToList();

                MCTemp.ItemListPopup = MC.ItemListPopup;

                RefDocTempData = MC.Purchase_Invoice_Reference;

                var refdoc = (from o in MC.Purchase_Invoice_Reference where o.doc_cat == "PO" select o).ToList();

                ReferenceDocPOCollection = CollectionViewSource.GetDefaultView(refdoc);
                ReferenceDocPOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                refdoc = (from o in MC.Purchase_Invoice_Reference where o.doc_cat == "GR" select o).ToList();

                ReferenceDocGRNCollection = CollectionViewSource.GetDefaultView(refdoc);
                ReferenceDocGRNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                if (PurchaseOrganisationList.Count != 0)
                {
                    if (PurchaseOrganisationList.Count == 1)
                    {
                        MasterEntity.po_code = PurchaseOrganisationList[0].po_code;
                        MasterEntity.pur_org = PurchaseOrganisationList[0].pur_org;
                    }
                }
                else
                {
                    MasterEntity.po_code = "";
                }
                if (PurchaseGroupList.Count != 0)
                {
                    if (PurchaseGroupList.Count == 1)
                    {
                        MasterEntity.pg_code = PurchaseGroupList[0].pg_code;
                        MasterEntity.pg_name = PurchaseGroupList[0].pg_name;
                    }
                }
                else
                {
                    MasterEntity.pg_code = "";
                }

                TaxDictonery = new Dictionary<string, object>();
                TaxDictonery.Clear();
                TaxDictonery = MC.TaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);
                var TaxListParent = (from o in MC.TaxList
                                     where o.parent_id == null
                                     select o).ToList();
                SelectedTaxList = TaxListParent;
                TaxDictoneryParent = SelectedTaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);
                CurrancyList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                MasterEntity.local_curr = CurrancyList[0].curr_code;

                NotificationDataCollection = MC.NotificationData;

                DefaultValues();
                PartyEnable = true;
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
        private void LoadWithoutReference(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadWithoutReference" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.po_code + "!@" + AppSessionState.EmpId;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MC, Request, "PurchaseInvoice", "Procurement", "LoadWithoutReference", 0, "");
                MC.Cost_Centers = MCTemp.Cost_Centers;
                MC.CurrencyList = MCTemp.CurrencyList;
                MC.Incoterms = MCTemp.Incoterms;

                #region Autosuggest
                //New PopUP - Supplier Party
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix);
                ASSuppParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyId", false);
                ASSuppParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Cost Center
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M019_P)x).cost_center);
                TheFilter = (o, prefix) => (((ACC_M019_P)o).cost_center ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((ACC_M019_P)o).cost_center_Desc ?? "").ToString().ToLower().Contains(prefix);
                ASCostCenter = new AutoSuggestTextViewModel<dynamic>(MC.Cost_Centers, TheFilter, SuggestedValue, "cost_center", true);
                ASCostCenter.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Currency
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037_P)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M037_P)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASdgCurrency = new AutoSuggestTextViewModel<dynamic>(MC.CurrencyList, TheFilter, SuggestedValue, "curr_code", "curr_code", true);
                ASdgCurrency.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Doc. Currency
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037_P)o).curr_code ?? "").ToString().ToLower().Contains(prefix) ||
                                           (((ADM_M037_P)o).curr_name ?? "").ToString().ToLower().Contains(prefix);
                ASDocCurr = new AutoSuggestTextViewModel<dynamic>(MC.CurrencyList, TheFilter, SuggestedValue, "curr_code", true);
                ASDocCurr.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - IncoTerms
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M044_P)x).incoterms);
                TheFilter = (o, prefix) => (((ADM_M044_P)o).incoterms ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M044_P)o).inco_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASdgIncoTerms = new AutoSuggestTextViewModel<dynamic>(MC.Incoterms, TheFilter, SuggestedValue, "incoterms", "incoterms", true);
                ASdgIncoTerms.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion

                DefaultValues();
                PartyEnable = true;
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
        private async void FilterItemSalesData(object InputValue)
        {
            try
            {
                PUR_T005_A ItemsEntityObject = null;
                if (((IEnumerable)InputValue).Cast<PUR_T005_A>().Count() > 0)
                {
                    ItemsEntityObject = ((IEnumerable)InputValue).Cast<PUR_T005_A>().ToList()[0];
                    SalesUnitPriceCollection.Clear();
                    SalesQFRCollection.Clear();
                    SalesDispatchCollection.Clear();
                    SalesProjDispatchCollection.Clear();

                    string Request1 = "GetItemPrice" + "!@" + ItemsEntityObject.ItemCode + "!@" + MasterEntity.PartyId + "!@" + MasterEntity.po_no + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat;
                    MCTemp = await repository_MCTemp.GetDataWithReturnDomainObjectASynchronus<MultipleContext_PUR_T005>(MCTemp, Request1, "PurchaseInvoice", "Procurement", "", 0, "GetItemPriceData");

                    if (ItemsEntity != null && MCTemp.UnitPriceList != null && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < ItemsEntity.Count)
                    {
                        if (MCTemp.UnitPriceList.Count > 0 && ItemsEntity.Count > 0)
                        {

                            var tempUnitPrice = MCTemp.UnitPriceList;
                            SalesUnitPriceCollection = tempUnitPrice;
                        }
                    }

                    if (ItemsEntity != null && MCTemp.QFRList != null && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < ItemsEntity.Count)
                    {
                        if (MCTemp.QFRList.Count > 0 && ItemsEntity.Count > 0)
                        {

                            var tempQFR = MCTemp.QFRList;
                            SalesQFRCollection = tempQFR.ToList();
                        }
                    }

                    if (ItemsEntity != null && MCTemp.DispatchList != null && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < ItemsEntity.Count)
                    {
                        if (MCTemp.DispatchList.Count > 0 && ItemsEntity.Count > 0)
                        {

                            var tempDispatch = MCTemp.DispatchList;
                            SalesDispatchCollection = tempDispatch;
                        }
                    }

                    if (ItemsEntity != null && MCTemp.ProjectedDispList != null && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < ItemsEntity.Count)
                    {
                        if (MCTemp.ProjectedDispList.Count > 0 && ItemsEntity.Count > 0)
                        {

                            var tempProj = MCTemp.ProjectedDispList;
                            SalesProjDispatchCollection = tempProj;
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
                string Request = "GetAllFiles" + "!@" + AppSessionState.client + "!@" + (EntityObjectParameter.comp_code ?? AppSessionState.comp_code) + "!@" + (EntityObjectParameter.location_Id ?? AppSessionState.location_Id) + "!@" + (MasterEntity.doc_cat ?? "") + "!@" + (MasterEntity.doc_type ?? "") + "!@" + EntityObjectParameter.doc_no + "!@" + EntityObjectParameter.id.ToString();
                //MCAttachments = repository_MCAttachments.GetData<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Reflection.BusinessLogic.ReflectionFileHandlingServices");
                MCAttachments = repository_MCAttachments.GetDataWithReturnDomainObject<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                if (!string.IsNullOrEmpty(EntityObjectParameter.ItemCode))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), Row_ID = EntityObjectParameter.id.ToString(), DocumentList = MCAttachments.Attachments, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
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
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_cat = "PQ";
            MasterEntity.doc_type = "PQ";
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.client = AppSessionState.client;
            TotalQty = 0;
            MasterEntity.active = true;
            MasterEntity.t_status = "001";
            MasterEntity.t_display = (from o in MC.t_statusList where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();
            MasterEntity.doc_date = DateTime.Now;
            //MasterEntity.post_date = DateTime.Now;          
            MasterEntity.inv_rec_date = DateTime.Now;
            MasterEntity.entry_time = Convert.ToString(new TimeSpan());
            if (CurrancyList.Count > 0 && MasterEntity.curr_code == null)
            {
                MasterEntity.local_currency = CurrancyList[0].curr_code;
                Currency = AppSessionState.CntryCurncy;
                MasterEntity.curr_code = AppSessionState.CntryCurncy;
            }
            MasterEntity.local_currency = AppSessionState.CntryCurncy;

            MasterEntity.Fltr_active = true;
            MasterEntity.Fltr_FrmDate = DateTime.Now.AddMonths(-1);
            MasterEntity.Fltr_ToDate = DateTime.Now;
            MasterEntity.Fltr_doc_type = MasterEntity.doc_type;
            if (PurchaseOrganisationList.Count == 1)
            {
                MasterEntity.po_code = PurchaseOrganisationList[0].po_code;
                MasterEntity.pur_org = PurchaseOrganisationList[0].pur_org;
            }
            if (PurchaseGroupList.Count == 1)
            {
                MasterEntity.pg_code = PurchaseGroupList[0].pg_code;
                MasterEntity.pg_name = PurchaseGroupList[0].pg_name;
            }
            if (CostCenterList.Count == 1)
            {
                MasterEntity.cost_center = CostCenterList[0].cost_center;
                MasterEntity.cost_center_Desc = CostCenterList[0].cost_center_Desc;
            }
        }
        private bool validation()
        {
            try
            {
                if (MasterEntity.PartyId == null || MasterEntity.PartyId == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Party.......");
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.post_date == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Posting Date.......");
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.po_code == null || MasterEntity.po_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Purchase Organisation Code.......");
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.pg_code == null || MasterEntity.pg_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Purchase Group Code.......");
                    showMessageService.ShowMessage();
                    return false;
                }
                if (CostCenterList.Count > 0)
                {
                    if (CostCenterList.Count == null || MasterEntity.cost_center == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Field cost center Is Required Financial Processing Tab");
                        showMessageService.ShowMessage();
                        return false;
                    }
                }
                if (MasterEntity.curr_code == null || MasterEntity.curr_code == " ")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Currency Code..");
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.local_currency == MasterEntity.curr_code)
                {
                    MasterEntity.exch_rate = 1;
                }
                if (MasterEntity.ind_trade == null || MasterEntity.ind_trade == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Transation Type is Required");
                    showMessageService.ShowMessage();

                    return false;
                }
                if (MasterEntity.exch_rate == null || MasterEntity.exch_rate == 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Exchange Rate");
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.order_limit_tax == true)
                {
                    if (MasterEntity.order_limit < MasterEntity.roundup_total)//when form is blank and we save the record
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Invoice value Exceeds Maximum Order value.");
                        showMessageService.ShowMessage();
                        //if (showMessageService.ShowMessage() == DialogResult.Ok)
                        //{
                        return true;
                        //}
                        //else if (showMessageService.ShowMessage() == DialogResult.Cancel)
                        //{
                        //    return false;
                        //}
                    }
                }
                else if (MasterEntity.order_limit_tax == false)
                {
                    if (MasterEntity.order_limit < MasterEntity.ass_value)//when form is blank and we save the record
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Invoice value Exceeds Maximum Order value.");
                        showMessageService.ShowMessage();
                        //if (showMessageService.ShowMessage() == DialogResult.Ok)
                        //{
                        return true;
                        //}
                        //else if (showMessageService.ShowMessage() == DialogResult.Cancel)
                        //{
                        //    return false;
                        //}
                    }
                }
                if (ItemsEntity.Count < 1)//when form is blank and we save the record
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("At Least Insert One Item........");
                    showMessageService.ShowMessage();

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
                                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                    showMessageService.ButtonSetup = DialogButton.Ok;
                                    showMessageService.Caption = "Message";
                                    showMessageService.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                                    showMessageService.ShowMessage();
                                    return false;
                                }
                            }

                            if (o.qty == null || o.qty == 0)
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Quantity cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                                showMessageService.ShowMessage();
                                return false;
                            }
                            if (o.unit_price == null || o.unit_price == 0)
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Unit Price cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                                showMessageService.ShowMessage();
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

                                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                            showMessageService.ButtonSetup = DialogButton.Ok;
                                            showMessageService.Caption = "Message";
                                            showMessageService.Text = String.Format("Condition Type is Required for Tax {0} ", TotalDocumentTaxes[i].tax_name);
                                            showMessageService.ShowMessage();
                                            return false;

                                        }
                                    }
                                }
                            }
                        }
                        else
                        {

                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("please select Item ........");
                            showMessageService.ShowMessage();
                            return false;
                        }
                        #region . Parameter Validation .
                        // Validation For All Parameter Values Selected or Not
                        if (o.StockUnt == true && o.active == true)
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
                                            showMessageService.Text = String.Format("All Parameters of item {0} of Index {1} are not selected..!!! \n Check Parameter at index {2} is selected or not.", o.ItemCode, ItemsEntity.IndexOf(o), SkuList.ToList().IndexOf(item));
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
                                    showMessageService.Text = String.Format("All Parameters of item {0} of Index {1} are not selected\n If you can see All Parameter Value Selected Please Select the Same Values Again ", o.ItemCode, ItemsEntity.IndexOf(o));
                                    showMessageService.ShowMessage();
                                    return false;
                                }
                            }

                        }

                        #endregion
                    }
                }
                if (MasterEntity.t_status == "017")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Invoice Validated...");
                    showMessageService.ShowMessage();
                    return false;
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
                    Computation(true, dgSelectedIndexItem, true);
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
        private void InsertdgIncoterms(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M044_P POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.Incoterms.Where(x => x.incoterms.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M044_P>().ToList()[0];
                }

                #endregion


                if (POPUPEntityObject != null)
                {
                    if (dgSelectedIndexItemLicence >= 0 && LicenceDetailsEntity.Count > dgSelectedIndexItemLicence) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<ACC_T006_D> temp = LicenceDetailsEntity.ToList();
                        temp = (from o in temp where o.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode select o).ToList();
                        temp[dgSelectedIndexItemLicence].incoterms = POPUPEntityObject.incoterms;
                    }
                }
                #region Clear Empty Row
                ACC_T006_D newObj = new ACC_T006_D();
                for (int i = LicenceDetailsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = LicenceDetailsEntity[i].ComparePropertiesTo(newObj);
                    if (LicenceDetailsEntity[i].ComparePropertiesTo(newObj) == true && LicenceDetailsEntity.Count > 1)
                    {
                        LicenceDetailsEntity.RemoveAt(i);
                        if (LicenceDetailsEntity.Count == 0)
                        {
                            LicenceDetailsEntity.Add(newObj);
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
        private void InsertLicence(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M041_P POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.LicenceList.Where(x => x.lic_cod.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M041_P>().ToList()[0];
                }

                #endregion


                if (POPUPEntityObject != null)
                {
                    if (dgSelectedIndexItemLicence >= 0 && LicenceDetailsEntity.Count > dgSelectedIndexItemLicence) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<ACC_T006_D> temp = LicenceDetailsEntity.ToList();
                        temp = (from o in temp where o.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode select o).ToList();
                        temp[dgSelectedIndexItemLicence].licence_no = POPUPEntityObject.lic_cod;
                    }
                }
                #region Clear Empty Row
                ACC_T006_D newObj = new ACC_T006_D();
                for (int i = LicenceDetailsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = LicenceDetailsEntity[i].ComparePropertiesTo(newObj);
                    if (LicenceDetailsEntity[i].ComparePropertiesTo(newObj) == true && LicenceDetailsEntity.Count > 1)
                    {
                        LicenceDetailsEntity.RemoveAt(i);
                        if (LicenceDetailsEntity.Count == 0)
                        {
                            LicenceDetailsEntity.Add(newObj);
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
        private void InsertRoundUpManual(object InputValue, bool OverrideValue)
        {
            try
            {
                string Request = "";
                string RequestParameterData = "";

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        MasterEntity.round_up = Convert.ToDecimal(Request);
                        Computation(true, dgSelectedIndexItem, false);
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
        private void InsertSupplierParty(object InputValue, bool OverrideValue)
        {
            try
            {
                string Request = "";
                string RequestParameterData = "";
                ADM_M028_P POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {

                        POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }

                }

                if (POPUPEntityObject != null)
                {
                    if (String.IsNullOrEmpty(MasterEntity.doc_no) != true || String.IsNullOrWhiteSpace(MasterEntity.doc_no) != true) //Condition: Only enter in the code block if ENtity Not null. Means It is in Edit Mode.
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
                            MasterEntity.payee_name = POPUPEntityObject.PartyNm;
                            MasterEntity.curr_code = POPUPEntityObject.curr_code;
                            //ItemsEntity[dgSelectedIndexItem].recon_acc = POPUPEntityObject.recon_acc;
                            MasterEntity.symbol = POPUPEntityObject.symbol;
                            MasterEntity.gst_PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.buss_place = POPUPEntityObject.buss_place;
                            if (MasterEntity.curr_code == Currency)
                            {
                                MasterEntity.exch_rate = 1;
                            }
                        }
                    }
                    else if (isNewRecord == true && ItemsEntity.Count > 0)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Party Selection";
                        showMessageService.Text = String.Format("If You Change The Party Items Will be removed'{0}'", this.Title);
                        if (showMessageService.ShowMessage() == DialogResult.Ok)
                        {
                            MasterEntity.payee_payer = POPUPEntityObject.PartyId;
                            MasterEntity.payee_name = POPUPEntityObject.PartyNm;
                            MasterEntity.PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.supplier_party_Nm = POPUPEntityObject.PartyNm;
                            MasterEntity.curr_code = POPUPEntityObject.curr_code;
                            //MasterEntity.recon_acc = POPUPEntityObject.recon_acc;
                            MasterEntity.symbol = POPUPEntityObject.symbol;
                            MasterEntity.gst_PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.buss_place = POPUPEntityObject.buss_place;
                            if (MasterEntity.curr_code == Currency)
                            {
                                MasterEntity.exch_rate = 1;
                            }
                            RequestParameterData = "LoadFromSupplierPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.PartyId;
                            MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, RequestParameterData, "PurchaseInvoice", "Procurement", "", 0, "");

                            PopupItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListPopup);
                            PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                            StringListItems = MCTemp.ItemListPopup.Select(x => x.ItemCode).ToList();

                            //New PopUP - Item Code in Data grid
                            //SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T005_P_PI_ItemsList)x).ItemCode);
                            //TheFilter = (o, prefix) => ((PUR_T005_P_PI_ItemsList)o).ItemCode.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).ItemName.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).cstmr_itemcode.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).cstmr_itemdescr.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).MinQty.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).MaxQty.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).stock_total.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).Reorder.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).stock_reserve.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).stock_unr.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T005_P_PI_ItemsList)o).stock_in_transit.ToString().ToLower().Contains(prefix);
                            //ASItemCode = new AutoSuggestTextViewModel<dynamic>(MCTemp.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                            //ASItemCode.AutoSuggestVM.IsEmptyValueAllowed = true;
                            //ASItemCode.AutoSuggestVM.IsFreeTextAllowed = true;

                            ItemsEntity.Clear();
                        }
                    }
                    else
                    {
                        MasterEntity.payee_payer = POPUPEntityObject.PartyId;
                        MasterEntity.payee_name = POPUPEntityObject.PartyNm;
                        MasterEntity.PartyId = POPUPEntityObject.PartyId;
                        MasterEntity.supplier_party_Nm = POPUPEntityObject.PartyNm;
                        MasterEntity.curr_code = POPUPEntityObject.curr_code;
                        //ItemsEntity[dgSelectedIndexItem].recon_acc = POPUPEntityObject.recon_acc;
                        MasterEntity.symbol = POPUPEntityObject.symbol;
                        MasterEntity.gst_PartyId = POPUPEntityObject.PartyId;
                        MasterEntity.buss_place = POPUPEntityObject.buss_place;
                        if (MasterEntity.curr_code == Currency)
                        {
                            MasterEntity.exch_rate = 1;
                        }

                        RequestParameterData = "LoadFromSupplierPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + MasterEntity.PartyId;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, RequestParameterData, "PurchaseInvoice", "Procurement", "", 0, "");

                        PopupItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListPopup);
                        PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                        StringListItems = MCTemp.ItemListPopup.Select(x => x.ItemCode).ToList();

                        //New PopUP - Item Code in Data grid
                        //SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T005_P_PI_ItemsList)x).ItemCode);
                        //TheFilter = (o, prefix) => ((PUR_T005_P_PI_ItemsList)o).ItemCode.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).ItemName.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).cstmr_itemcode.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).cstmr_itemdescr.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).MinQty.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).MaxQty.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).stock_total.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).Reorder.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).stock_reserve.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).stock_unr.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T005_P_PI_ItemsList)o).stock_in_transit.ToString().ToLower().Contains(prefix);
                        //ASItemCode = new AutoSuggestTextViewModel<dynamic>(MCTemp.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                        //ASItemCode.AutoSuggestVM.IsEmptyValueAllowed = true;
                        //ASItemCode.AutoSuggestVM.IsFreeTextAllowed = true;

                        ItemsEntity.Clear();
                    }
                }
                var msg = new NotificationMessage("PUR_T005_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
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
        private void InsertBussPlace(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003_C_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.BussinessPlaceList.Where(x => x.buss_place.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.plc_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_C_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.buss_place = POPUPEntityObject.buss_place;
                    MasterEntity.plc_name = POPUPEntityObject.plc_name;
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
        private void InsertdgBussPlace(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M003_C_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BussinessPlaceList.Where(x => x.buss_place.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.plc_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_C_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (ItemsEntity.Count == dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        ItemsEntity.Add(new PUR_T005_A()
                        {


                            buss_place = POPUPEntityObject.buss_place


                        });

                    }
                    else if (ItemsEntity.Count > dgSelectedIndexItem)
                    {
                        ItemsEntity[dgSelectedIndexItem].buss_place = POPUPEntityObject.buss_place;

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
        private void InsertdgShipToParty(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {


                    if (ItemsEntity.Count == dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        ItemsEntity.Add(new PUR_T005_A()
                        {


                            ship_to_Party = POPUPEntityObject.PartyId,
                            ship_to_add = POPUPEntityObject.ship_to_add


                        });

                    }
                    else if (ItemsEntity.Count > dgSelectedIndexItem)
                    {
                        ItemsEntity[dgSelectedIndexItem].ship_to_Party = POPUPEntityObject.PartyId;
                        ItemsEntity[dgSelectedIndexItem].ship_to_add = POPUPEntityObject.ship_to_add;

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
        private void InsertConditiontype(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M003_O_P POPUPEntityObject = null;
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.ConditionTypeList.Where(x => x.con_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M003_O_P>().ToList()[0];
                    }
                }
                catch (Exception) { }
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (TotalDocumentTaxes.Count == dgSelectedIndexTaxSummury && dgSelectedIndexTaxSummury >= 0)
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
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].con_type = POPUPEntityObject.con_type;
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].con_cat = POPUPEntityObject.con_cat;
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].trns_key_code = POPUPEntityObject.trns_key_code;
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
        private void InsertdgCurrency(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M037_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
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

                #endregion

                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (TotalDocumentTaxes.Count == dgSelectedIndexTaxSummury && dgSelectedIndexTaxSummury >= 0)
                    {
                        TotalDocumentTaxes.Add(new ACC_T006_C()
                        {


                            curr_code = POPUPEntityObject.curr_code


                        });

                    }
                    else if (TotalDocumentTaxes.Count > dgSelectedIndexTaxSummury)
                    {
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].curr_code = POPUPEntityObject.curr_code;

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
        private void InsertPayee(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
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
                    if (((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.payee_payer = POPUPEntityObject.PartyId;
                    MasterEntity.payee_name = POPUPEntityObject.PartyNm;
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
        private void InsertReferenceDoc(object InputValue)
        {
            try
            {
                string Request = "";
                PUR_T005_P_RefDoc POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Purchase_Invoice_Reference.Where(x => x.Ref_DocNo.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<PUR_T005_P_RefDoc>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PUR_T005_P_RefDoc>().ToList()[0];
                    }

                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ref_doc_no = POPUPEntityObject.Ref_DocNo;
                    ref_doc_cat = POPUPEntityObject.doc_cat;
                    MasterEntity.ref_doc_type = POPUPEntityObject.Ref_DocType;

                    if (ref_doc_cat == "GR")
                    {
                        Request = "LoadGRN" + "!@" + MasterEntity.ref_doc_no;
                    }
                    else if (ref_doc_cat == "PO")
                    {
                        Request = "LoadPO" + "!@" + MasterEntity.ref_doc_no;
                    }

                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, Request, "PurchaseInvoice", "Procurement", "", 0, "FlipData");

                    if (MCTemp.ItemListPopup.Count > 0)
                    {
                        PopupItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListPopup);
                        PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                        StringListItems = MCTemp.ItemsEntity.Select(x => x.ItemCode).ToList();
                    }


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
        private void InsertItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                PUR_T005_P_PI_ItemsList POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        if (MCTemp.ItemListPopup.Count > 0)
                        {
                            POPUPEntityObject = MCTemp.ItemListPopup.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        else
                        {
                            POPUPEntityObject = MC.ItemListPopup.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PUR_T005_P_PI_ItemsList>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = ItemsEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());
                    var LineId = ItemsEntity.Count + 1;
                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1)) // && ItemsEntity.Count == dgSelectedIndexItem)
                    {
                        ItemsEntity.Add(new PUR_T005_A()
                        {
                            id = 0,
                            ItemCode = POPUPEntityObject.ItemCode,
                            item_desc = POPUPEntityObject.ItemName,
                            SubCatCode = POPUPEntityObject.SubCatCode,
                            StockUnt = Convert.ToBoolean(POPUPEntityObject.StockUnt),
                            ref_doc_no = ItemsEntity[0].po_no,
                            // ref_doc_type = MasterEntity.ref_doc_type,
                            ref_doc_type = String.IsNullOrEmpty(MasterEntity.ref_doc_no) ? "" : MasterEntity.ref_doc_type,
                            tax_id = POPUPEntityObject.tax_id,
                            unit_code = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM,
                            unit_price = String.IsNullOrEmpty(POPUPEntityObject.Rate_Catlog.ToString()) ? POPUPEntityObject.rate : POPUPEntityObject.Rate_Catlog,
                            qty = POPUPEntityObject.qty,
                            subtotal = POPUPEntityObject.sub_total,
                            active = true,
                            line_id = LineId,
                            location_Id = MasterEntity.location_Id,
                            comp_code = MasterEntity.comp_code,
                            add_by = AppSessionState.UserID,
                            client = AppSessionState.client,
                            item_cat = POPUPEntityObject.item_cat_id,
                            t_status = "001",
                            po_no = ItemsEntity[0].po_no,
                            //ship_to_Party = MasterEntity.ship_to_party,
                            //ship_to_add = MasterEntity.del_address,
                            buss_place = MasterEntity.buss_place,
                            doc_no = MasterEntity.doc_no,
                            PartyId = MasterEntity.PartyId,
                            curr_code = MasterEntity.curr_code,
                            pur_doc_no = ItemsEntity[0].po_no,
                            pur_doc_item_cd = POPUPEntityObject.ItemCode,
                            po_code = MasterEntity.po_code,
                            pg_code = MasterEntity.pg_code,
                            dc_code = MasterEntity.dc_code,
                            div_code = MasterEntity.div_code,
                            cost_center = MasterEntity.cost_center,
                            order_no = ItemsEntity[0].po_no
                        });
                    }
                    else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                        {
                            if (ItemsEntity[dgSelectedIndexItem].line_id == 0)
                            {
                                ItemsEntity[dgSelectedIndexItem].line_id = ItemsEntity.Count;
                            }
                            ItemsEntity[dgSelectedIndexItem].ItemCode = POPUPEntityObject.ItemCode;
                            ItemsEntity[dgSelectedIndexItem].item_desc = POPUPEntityObject.ItemName;
                            ItemsEntity[dgSelectedIndexItem].StockUnt = Convert.ToBoolean(POPUPEntityObject.StockUnt);
                            ItemsEntity[dgSelectedIndexItem].SubCatCode = POPUPEntityObject.SubCatCode;
                            ItemsEntity[dgSelectedIndexItem].location_Id = AppSessionState.location_Id;
                            ItemsEntity[dgSelectedIndexItem].comp_code = AppSessionState.comp_code;
                            ItemsEntity[dgSelectedIndexItem].add_by = AppSessionState.UserID;
                            ItemsEntity[dgSelectedIndexItem].active = true;
                            ItemsEntity[dgSelectedIndexItem].ref_doc_no = POPUPEntityObject.Ref_doc_no;
                            ItemsEntity[dgSelectedIndexItem].ref_doc_type = MasterEntity.ref_doc_type;
                            ItemsEntity[dgSelectedIndexItem].ref_doc_type = String.IsNullOrEmpty(MasterEntity.ref_doc_no) ? "" : MasterEntity.ref_doc_type;
                            ItemsEntity[dgSelectedIndexItem].tax_id = POPUPEntityObject.tax_id;
                            ItemsEntity[dgSelectedIndexItem].unit_code = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM;
                            ItemsEntity[dgSelectedIndexItem].unit_price = String.IsNullOrEmpty(POPUPEntityObject.Rate_Catlog.ToString()) ? POPUPEntityObject.rate : POPUPEntityObject.Rate_Catlog;
                            ItemsEntity[dgSelectedIndexItem].qty = POPUPEntityObject.qty;
                            ItemsEntity[dgSelectedIndexItem].subtotal = POPUPEntityObject.sub_total;
                            ItemsEntity[dgSelectedIndexItem].item_cat = POPUPEntityObject.item_cat_id;
                            ItemsEntity[dgSelectedIndexItem].po_no = ItemsEntity[0].po_no;
                            //ItemsEntity[dgSelectedIndexItem].ship_to_Party = MasterEntity.ship_to_party;
                            //ItemsEntity[dgSelectedIndexItem].ship_to_add = MasterEntity.del_address;
                            ItemsEntity[dgSelectedIndexItem].buss_place = MasterEntity.buss_place;
                            ItemsEntity[dgSelectedIndexItem].t_status = "001";
                            ItemsEntity[dgSelectedIndexItem].doc_no = MasterEntity.doc_no;
                            ItemsEntity[dgSelectedIndexItem].PartyId = MasterEntity.PartyId;
                            ItemsEntity[dgSelectedIndexItem].curr_code = MasterEntity.curr_code;
                            ItemsEntity[dgSelectedIndexItem].pur_doc_no = ItemsEntity[0].po_no;
                            ItemsEntity[dgSelectedIndexItem].pur_doc_item_cd = POPUPEntityObject.ItemCode;
                            ItemsEntity[dgSelectedIndexItem].po_code = MasterEntity.po_code;
                            ItemsEntity[dgSelectedIndexItem].pg_code = MasterEntity.pg_code;
                            ItemsEntity[dgSelectedIndexItem].dc_code = MasterEntity.dc_code;
                            ItemsEntity[dgSelectedIndexItem].div_code = MasterEntity.div_code;
                            ItemsEntity[dgSelectedIndexItem].cost_center = MasterEntity.cost_center;
                            ItemsEntity[dgSelectedIndexItem].order_no = POPUPEntityObject.ItemCode;
                            ItemsEntity[dgSelectedIndexItem].pur_doc_item_cd = POPUPEntityObject.ItemCode;
                            ItemsEntity[dgSelectedIndexItem].pur_doc_item_cd = ItemsEntity[0].po_no;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].ItemCode != POPUPEntityObject.ItemCode)
                        {
                            ItemsEntity[dgSelectedIndexItem].ItemCode = "";
                            ItemsEntity[dgSelectedIndexItem].item_desc = "";
                        }
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
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
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
                        POPUPEntityObject = MC.ItemCategoryList.Where(x => x.sditem_cat_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

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
            }
            #endregion
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MC.UnitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = ItemsEntity.Where(x => x.unit_code == POPUPEntityObject.unit_code).FirstOrDefault();
                    var IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault());
                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
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
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertwtUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                    }

                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.weight_unit == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.weight_unit == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].weight_unit = POPUPEntityObject.unit_code;
                            MasterEntity.para5 = POPUPEntityObject.unit_code;

                        }
                        else if (ItemsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                        {
                            ItemsEntity[dgSelectedIndexItem].weight_unit = "";
                        }
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
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertvolUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                //AppSessionState.StringListValue = StringListUOM;
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;


                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.volume_unit == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.volume_unit == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].volume_unit = POPUPEntityObject.unit_code;
                            MasterEntity.volume_unit = POPUPEntityObject.unit_code;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                        {
                            ItemsEntity[dgSelectedIndexItem].volume_unit = "";
                        }
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
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertPurchaseOrg(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                ADM_M001_M_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = PurchaseOrganisationList.Where(x => x.po_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_M_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.po_code = POPUPEntityObject.po_code;
                    MasterEntity.pur_org = POPUPEntityObject.pur_org;
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
        private void InsertPurchaseGroup(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                ADM_M001_P_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = PurchaseGroupList.Where(x => x.pg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_P_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.pg_code = POPUPEntityObject.pg_code;
                    MasterEntity.pg_name = POPUPEntityObject.pg_name;
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
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void InsertPayMethod(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M021_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PayMethod.Where(x => x.pay_mode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M021_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.pay_method = POPUPEntityObject.pay_mode;
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
                            { POPUPEntityObject = MC.AccountList.Where(x => x.gl_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                        TotalDocumentTaxes.Add(new ACC_T006_C()
                        {

                            gl_code = POPUPEntityObject.gl_code,
                            symbol = MasterEntity.symbol


                        });

                    }
                    else if (TotalDocumentTaxes.Count > dgSelectedIndexTaxSummury)
                    {
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].gl_code = POPUPEntityObject.gl_code;
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].symbol = MasterEntity.symbol;

                    }
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
        private void InsertCurrency(object InputValue)
        {
            try
            {
                string Request;
                ADM_M037_P POPUPEntityObject = null;
                #region Command Parameter read Section
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
                    MasterEntity.curr_code = POPUPEntityObject.curr_code;
                    MasterEntity.symbol = POPUPEntityObject.symbol;
                    if (MasterEntity.curr_code == Currency)
                    {
                        MasterEntity.exch_rate = 1;
                    }

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
        private void InsertBank(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M004_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BankList.Where(x => x.hb_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M004_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M004_P>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.bank_code = POPUPEntityObject.hb_code;
                    MasterEntity.bank_name = POPUPEntityObject.bank_name;
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
        private void InsertPartyBank(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M004_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PartyBanks.Where(x => x.pb_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M004_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M004_P>().ToList()[0];
                    }
                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.party_bank = POPUPEntityObject.pb_code;
                    MasterEntity.party_bank_name = POPUPEntityObject.acc_holder_name;
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
        private void InsertNastroBank(object InputValue)
        {
            try
            {

                string Request = "";
                ACC_M004_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BankList.Where(x => x.bank_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M004_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M004_P>().ToList()[0];
                    }

                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.nastro_bank_cd = POPUPEntityObject.bank_code;
                    MasterEntity.nastro_bank_name = POPUPEntityObject.bank_name;
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
        private void InsertCostCenter(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M019_P POPUPEntityObject = null;
                #region Command Parameter Read Section

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
                    if (((IEnumerable)InputValue).Cast<ACC_M019_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M019_P>().ToList()[0];
                    }

                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.cost_center = POPUPEntityObject.cost_center;
                    MasterEntity.cost_center_Desc = POPUPEntityObject.cost_center_Desc;
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
        private void InsertJournal(object InputValue)
        {
            try
            {

                string Request = "";
                ACC_M005_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Journals.Where(x => x.j_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M005_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M005_P>().ToList()[0];
                    }

                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.j_code = POPUPEntityObject.j_code;
                    MasterEntity.j_name = POPUPEntityObject.j_name;
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
        private void InsertPlant(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = ObjSupply.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M003>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                    }

                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.location_Id = POPUPEntityObject.location_Id;
                    //MasterEntity.PlantName = POPUPEntityObject.LoctnNm;
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
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i && ItemsEntity[dgSelectedIndexItem].id == 0)
                {
                    ItemsEntity.RemoveAt(i);
                    Computation(true, dgSelectedIndexItem, true);

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
        private void InsertManualTaxChangedCommand(object InputValue)
        {
            Computation(true, dgSelectedIndexItem, true);
        }
        private void DeleteTax(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (TotalDocumentTaxes.Count > i)
                {
                    //TotalDocumentTaxes.Remove(TotalDocumentTaxes.Where(x => x.tax_name == TotalDocumentTaxes[i].tax_name).Single());
                    List<ACC_T006_C> copyLocal = new List<ACC_T006_C>();
                    copyLocal = TotalDocumentTaxes.ToList();
                    foreach (var tax in copyLocal)
                    {
                        if (tax.tax_name == TotalDocumentTaxes[i].tax_name && tax.manual == "Manual")
                        {
                            TotalDocumentTaxes.Remove(tax);
                        }
                    }
                    Computation(true, dgSelectedIndexItem, true);
                }
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
                string ParametersStringValue = "";
                PUR_T005_Flip ParameterEntityObject = null;
                if (ParameterObject != null)
                {
                    if (ParameterObject.GetType() == typeof(string) && ParameterObject.ToString() == "ReferenceDocument") // This Block of code read parameter . First for string and Entity Object in else part.
                    {
                        ParametersStringValue = ParameterObject.ToString().Trim();
                        if (ParametersStringValue.Length > 0)
                        {
                            if (DocumentList == null || DocumentList == "")
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Refernece Selection";
                                showMessageService.Text = String.Format("Please Select Refernece No", this.Title);
                                showMessageService.ShowMessage();
                            }
                            else
                            {
                                if (MasterEntity.ref_doc_cat == "GR")
                                {
                                    Request = "LoadDocumentFromGRNumber" + "!@" + DocumentList;
                                }
                                else if (MasterEntity.ref_doc_cat == "PO")
                                {
                                    Request = "LoadDocumentFromPOReferneceNo" + "!@" + DocumentList;
                                }

                                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, Request, "PurchaseInvoice", "Procurement", "", 0, "FlipData");

                                if (MCTemp.MasterEntity.Count > 0)
                                {
                                    MasterEntity = MCTemp.MasterEntity[0];
                                    MasterEntity.comp_code = AppSessionState.comp_code;
                                    MasterEntity.location_Id = AppSessionState.location_Id;
                                    MasterEntity.t_status = "001";
                                    MasterEntity.t_display = (from o in MC.t_statusList where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();
                                    MasterEntity.active = true;
                                    MasterEntity.add_by = AppSessionState.UserID;
                                    MasterEntity.editby = AppSessionState.UserID;
                                    MasterEntity.user_source1 = AppSessionState.UserSource1;
                                    MasterEntity.user_source2 = AppSessionState.UserSource2;
                                    MasterEntity.client = AppSessionState.client;
                                    MasterEntity.doc_date = DateTime.Now;
                                    MasterEntity.post_date = DateTime.Now;
                                    MasterEntity.inv_rec_date = DateTime.Now;
                                    MasterEntity.entry_time = Convert.ToString(new TimeSpan());
                                    MasterEntity.Fltr_active = true;
                                    MasterEntity.Fltr_FrmDate = DateTime.Now.AddMonths(-1);
                                    MasterEntity.Fltr_ToDate = DateTime.Now;
                                    MasterEntity.Fltr_doc_type = MasterEntity.doc_type;
                                }
                                else
                                {
                                    MasterEntity = new PUR_T005();
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
                                if (MCTemp.ItemListPopup.Count > 0)
                                {
                                    MC.ItemListPopup = MCTemp.ItemListPopup;
                                    PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListPopup);
                                }

                                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T005_P_PI_ItemsList)x).ItemCode);
                                TheFilter = (o, prefix) => ((PUR_T005_P_PI_ItemsList)o).ItemCode.ToString().ToLower().Contains(prefix) ||
                                                           ((PUR_T005_P_PI_ItemsList)o).ItemName.ToString().ToLower().Contains(prefix);
                                ASItemCode = new AutoSuggestTextViewModel<dynamic>(MC.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                                ASItemCode.AutoSuggestVM.IsEmptyValueAllowed = true;
                                ASItemCode.AutoSuggestVM.IsFreeTextAllowed = true;

                                AttachmentCollection = CollectionViewSource.GetDefaultView(MC.Attachment);

                                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M004_P)x).pb_code);
                                TheFilter = (o, prefix) => (((ACC_M004_P)o).pb_code ?? "").ToLower().Contains(prefix) ||
                                                           (((ACC_M004_P)o).acc_holder_name ?? "").ToLower().Contains(prefix);
                                ASPartyBank = new AutoSuggestTextViewModel<dynamic>(MC.PartyBanks, TheFilter, SuggestedValue, "party_bank", true);
                                ASPartyBank.AutoSuggestVM.IsEmptyValueAllowed = true;

                                int count = ItemsEntity.Count();
                                TotalDocumentTaxes.Clear();
                                for (int i = 0; i < count; i++)
                                {
                                    Computation(true, i, true);

                                }
                                DefaultValues();
                                QtyCalculation();
                                if (dgSelectedIndexItem != -1)
                                {
                                    if (MasterEntity.loc_curr > 0)
                                    {
                                        MasterEntity.amt_in_wordsLoc = num.AmountInWords(Convert.ToDecimal(MasterEntity.loc_curr));
                                    }
                                }
                                else
                                {
                                    MasterEntity.amt_in_wordsLoc = "";
                                }
                                //MasterEntity.local_curr = "In Local Currency(" + CurrancyList[0].CntryCurncy + ")";
                                MasterEntity.local_curr = CurrancyList[0].curr_code;
                                if (PurchaseOrganisationList.Count != 0)
                                {
                                    if (PurchaseOrganisationList.Count == 1)
                                    {
                                        MasterEntity.po_code = PurchaseOrganisationList[0].po_code;
                                        MasterEntity.pur_org = PurchaseOrganisationList[0].pur_org;
                                    }
                                }
                                else
                                {
                                    MasterEntity.po_code = "";
                                }
                                if (PurchaseGroupList.Count != 0)
                                {
                                    if (PurchaseGroupList.Count == 1)
                                    {
                                        MasterEntity.pg_code = PurchaseGroupList[0].pg_code;
                                        MasterEntity.pg_name = PurchaseGroupList[0].pg_name;
                                    }
                                }
                                else
                                {
                                    MasterEntity.pg_code = "";
                                }
                                if (MasterEntity.local_currency == MasterEntity.curr_code)
                                {
                                    MasterEntity.exch_rate = 1;
                                }
                                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M025_P)x).wtax_code);
                                TheFilter = (o, prefix) => (((ACC_M025_P)o).wtax_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M025_P)o).wtax_ncode ?? "").ToString().ToLower().Contains(prefix.ToLower());
                                ASwithholding = new AutoSuggestTextViewModel<dynamic>(MCTemp.withholdinglist, TheFilter, SuggestedValue, "withholding_tax", true);
                                ASwithholding.AutoSuggestVM.IsEmptyValueAllowed = true;

                                if (MCTemp.withholdinglist.Count == 1)
                                {
                                    MasterEntity.withholding_tax = MCTemp.withholdinglist[0].wtax_code;
                                }
                            }
                        }
                    }
                    else if (ParameterObject != null)
                    {
                        isNewRecord = false;
                        parameter = false;
                        MoveFlag = false;
                        if (ParameterObject.GetType() == typeof(string) && ParameterReference == "DocumentNo")
                        {
                            Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParameterObject.ToString();
                        }
                        else if (((IEnumerable)ParameterObject).Cast<PUR_T005_Flip>().ToList().Count > 0)
                        {
                            ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<PUR_T005_Flip>().ToList()[0];
                            Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParameterEntityObject.doc_no + "!@" + ParameterEntityObject.PartyId + "!@" + AppSessionState.comp_code;
                        }
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, Request, "PurchaseInvoice", "Procurement", "", 0, "");
                        MasterEntity = MCTemp.MasterEntity[0];
                        ItemsEntity = MCTemp.ItemsEntity;
                        TotalDocumentTaxes = MCTemp.TaxEntity;
                        AttachmentCollection = CollectionViewSource.GetDefaultView(MCTemp.Attachment);

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

                        if (MCTemp.ItemListPopup.Count > 0)
                        {
                            PopupItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListPopup);
                            PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                            StringListItems = MCTemp.ItemListPopup.Select(x => x.ItemCode).ToList();
                        }

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T005_P_PI_ItemsList)x).ItemCode);
                        TheFilter = (o, prefix) => ((PUR_T005_P_PI_ItemsList)o).ItemCode.ToString().ToLower().Contains(prefix) ||
                                                   ((PUR_T005_P_PI_ItemsList)o).ItemName.ToString().ToLower().Contains(prefix);
                        ASItemCode = new AutoSuggestTextViewModel<dynamic>(MCTemp.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                        ASItemCode.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASItemCode.AutoSuggestVM.IsFreeTextAllowed = true;

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M025_P)x).wtax_code);
                        TheFilter = (o, prefix) => (((ACC_M025_P)o).wtax_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M025_P)o).wtax_ncode ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASwithholding = new AutoSuggestTextViewModel<dynamic>(MCTemp.withholdinglist, TheFilter, SuggestedValue, "withholding_tax", true);
                        ASwithholding.AutoSuggestVM.IsEmptyValueAllowed = true;
                        CalWithHoldingTax();

                        isNewRecord = false;
                        SelectedTabControlIndex = 0;
                        QtyCalculation();
                        if (dgSelectedIndexItem != -1)
                        {
                            if (MasterEntity.loc_curr > 0)
                            {
                                MasterEntity.amt_in_wordsLoc = num.AmountInWords(Convert.ToDecimal(MasterEntity.loc_curr));
                            }
                        }
                        else
                        {
                            MasterEntity.amt_in_wordsLoc = "";
                        }
                        //MasterEntity.local_curr = "In Local Currency(" + CurrancyList[0].CntryCurncy + ")";
                        MasterEntity.local_curr = CurrancyList[0].curr_code;

                        string RequestParameterData = "LoadFromSupplierPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.PartyId;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, RequestParameterData, "PurchaseInvoice", "Procurement", "", 0, "");

                        if (MCTemp.ItemListPopup.Count > 0)
                        {
                            PopupItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListPopup);
                            PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                            StringListItems = MCTemp.ItemListPopup.Select(x => x.ItemCode).ToList();

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T005_P_PI_ItemsList)x).ItemCode);
                            TheFilter = (o, prefix) => ((PUR_T005_P_PI_ItemsList)o).ItemCode.ToString().ToLower().Contains(prefix) ||
                                                       ((PUR_T005_P_PI_ItemsList)o).ItemName.ToString().ToLower().Contains(prefix);
                            ASItemCode = new AutoSuggestTextViewModel<dynamic>(MCTemp.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                            ASItemCode.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASItemCode.AutoSuggestVM.IsFreeTextAllowed = true;
                        }

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M004_P)x).pb_code);
                        TheFilter = (o, prefix) => (((ACC_M004_P)o).pb_code ?? "").ToLower().Contains(prefix) ||
                                                   (((ACC_M004_P)o).acc_holder_name ?? "").ToLower().Contains(prefix);
                        ASPartyBank = new AutoSuggestTextViewModel<dynamic>(MCTemp.PartyBanks, TheFilter, SuggestedValue, "party_bank", true);
                        ASPartyBank.AutoSuggestVM.IsEmptyValueAllowed = true;


                    }

                    SelectedTabControlIndex = 0;
                    SetPopupSuggestionDataAfterLoad();
                    PartyEnable = false;
                    EntityChangeEnable = true;
                    var msg = new NotificationMessage("PUR_T005_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);
                }
                MasterEntity.ts_code = ts_code_vm;
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
            ASRefDocNo.AutoSuggestVM.Suggestion = RefDocTempData.Find(x => x.Ref_DocNo == MasterEntity.ref_doc_no);
            ASSuppParty.AutoSuggestVM.Suggestion = MC.PartyMaster.Find(x => x.PartyId == MasterEntity.PartyId);
            //ASPayee.AutoSuggestVM.Suggestion = MC.PartyMaster.Find(x => x.PartyId == MasterEntity.payee_payer);
            //ASItemCode.AutoSuggestVM.Suggestion = MCTemp.ItemListPopup.Find(x => x.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode);
            //ASItemCategory.AutoSuggestVM.Suggestion = MC.ItemCategoryList.Find(x => x.sditem_cat_code == ItemsEntity[dgSelectedIndexItem].item_cat);
            //ASUnit.AutoSuggestVM.Suggestion = MC.UnitList.Find(x => x.unit_code == ItemsEntity[dgSelectedIndexItem].unit_code);
            //ASWeightUnit.AutoSuggestVM.Suggestion = MC.UnitList.Find(x => x.unit_code.ToString() == ItemsEntity[dgSelectedIndexItem].weight_unit);
            //ASVolUnit.AutoSuggestVM.Suggestion = MC.UnitList.Find(x => x.unit_code == ItemsEntity[dgSelectedIndexItem].volume_unit);
            //ASTaxacc.AutoSuggestVM.Suggestion = MC.AccountList.Find(x => x.gl_code == TotalDocumentTaxes[dgSelectedIndexTaxSummury].gl_code);
            ASDocCurr.AutoSuggestVM.Suggestion = MC.CurrencyList.Find(x => x.curr_code == MasterEntity.curr_code);
            ASPlant.AutoSuggestVM.Suggestion = ObjSupply.Find(x => x.location_Id == MasterEntity.location_Id);
            ASPaymentTerm.AutoSuggestVM.Suggestion = MC.PayTerms.Find(x => x.p_term_code == MasterEntity.p_term_code);
            ASPaymentMethod.AutoSuggestVM.Suggestion = MCTemp.PayMethod.Find(x => x.pay_mode == MasterEntity.pay_method);
            ASCompanyBank.AutoSuggestVM.Suggestion = MC.BankList.Find(x => x.bank_code == MasterEntity.bank_code);
            ASNastroBank.AutoSuggestVM.Suggestion = MC.BankList.Find(x => x.bank_code == MasterEntity.nastro_bank_cd);
            ASPurOrg.AutoSuggestVM.Suggestion = PurchaseOrganisationList.Find(x => x.po_code == MasterEntity.po_code);
            ASPurGrp.AutoSuggestVM.Suggestion = PurchaseGroupList.Find(x => x.pg_code == MasterEntity.pg_code);
            ASIncoTerms.AutoSuggestVM.Suggestion = MC.Incoterms.Find(x => x.incoterms == MasterEntity.incoterms);
            ASEPCG.AutoSuggestVM.Suggestion = MC.LicenseEPCG.Find(x => x.lic_cod == MasterEntity.lic_cod);
            ASAdvance.AutoSuggestVM.Suggestion = MC.LicenseAdvance.Find(x => x.lic_cod == MasterEntity.advance_lic);
            ASCFAgent.AutoSuggestVM.Suggestion = MC.ServiceProviders.Find(x => x.PartyId == MasterEntity.cf_agent_cd);
            ASCostCenter.AutoSuggestVM.Suggestion = MC.Cost_Centers.Find(x => x.cost_center == MasterEntity.cost_center);
            ASJournal.AutoSuggestVM.Suggestion = MC.Journals.Find(x => x.j_code == MasterEntity.j_code);
            ASwithholding.AutoSuggestVM.Suggestion = MC.withholdinglist.Find(x => x.wtax_code == MasterEntity.withholding_tax);

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
                if (MasterEntity.XmlDataDocument_FlipGrid != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<PUR_T005_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                    FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                    FlipDataGridCollection.SortDescriptions.Add(new SortDescription("doc_no", ListSortDirection.Descending));
                }
                QtyCalculation();
                if (dgSelectedIndexItem != -1)
                {
                    if (MasterEntity.loc_curr > 0)
                    {
                        MasterEntity.amt_in_wordsLoc = num.AmountInWords(Convert.ToDecimal(MasterEntity.loc_curr));
                    }
                }
                else
                {
                    MasterEntity.amt_in_wordsLoc = "";
                }
                //MasterEntity.local_curr = "In Local Currency(" + CurrancyList[0].CntryCurncy + ")";
                MasterEntity.local_curr = CurrancyList[0].curr_code;
                MasterEntity.ts_code = ts_code_vm;
                RemoveRefDoc();
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
                foreach (PUR_T005_A item in ItemsEntity)
                {
                    if (item.ref_doc_no != null)
                    {
                        MC.Purchase_Invoice_Reference.RemoveAll(X => X.Ref_DocNo == item.ref_doc_no);
                    }
                }
                if (MC.Purchase_Invoice_Reference.Count > 0)
                {
                    RefDocTempData = MC.Purchase_Invoice_Reference;
                    refdoctempa = (from o in MC.Purchase_Invoice_Reference where o.doc_cat == "PO" select o).ToList();
                    ReferenceDocPOCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                    ReferenceDocPOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                    var refdoctempGRN = (from o in MC.Purchase_Invoice_Reference where o.doc_cat == "GR" select o).ToList();
                    ReferenceDocGRNCollection = CollectionViewSource.GetDefaultView(refdoctempGRN);
                    ReferenceDocGRNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
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
        private void InsertCollectionChanged(IList DataList)
        {
            try
            {
                IList list = DataList as IList;
                int a = dgSelectedIndexItem;

                if (ItemsEntity[dgSelectedIndexItem].id == 0 && ItemsEntity.Count > 0 && dgSelectedIndexItem < ItemsEntity.Count && dgSelectedIndexItem != -1)
                {
                    List<PUR_T005_A> SelectedRowlist = list.Cast<PUR_T005_A>().ToList();

                    if (SelectedRowlist[0].StockUnt == true)
                    {
                        var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();
                        ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());

                        if (paramlist.Count > 0) //&& SelectedParaValueCollection.Count != paramlist.Count)
                        {
                            SelectedParaValueCollection = new List<ADM_M031_P>();

                            for (int i = 0; i < paramlist.Count; i++)
                            {
                                SelectedParaValueCollection.Add(new ADM_M031_P()
                                {

                                    dgselectedindex = dgSelectedIndexItem,
                                    para_code = paramlist[i].para_code,
                                    para_name = paramlist[i].para_name

                                });
                            }


                            if (ItemsEntity[dgSelectedIndexItem].sku_desc != null)
                            {
                                SelectedParaValueCollection = ParameterCollection.Cast<ADM_M031_P>().ToList();

                                foreach (var o in SelectedParaValueCollection)
                                {
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
                }
                else if (ItemsEntity[dgSelectedIndexItem].id != 0 && ItemsEntity.Count > 0 && dgSelectedIndexItem < ItemsEntity.Count)
                {
                    List<PUR_T005_A> SelectedRowlist = list.Cast<PUR_T005_A>().ToList();
                    string[] TempSkuList = new string[100];
                    List<string> TempParaValueList = new List<string>();

                    if (SelectedRowlist[0].StockUnt == true)
                    {
                        var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();
                        if (paramlist.Count > 0 && ItemsEntity[dgSelectedIndexItem].sku != "" && ItemsEntity[dgSelectedIndexItem].sku != null)
                        {
                            TempSkuList = ItemsEntity[dgSelectedIndexItem].sku.Split('/');

                            for (int i = 0; i < paramlist.Count; i++)
                            {
                                TempParaValueList = (from o in MC.ParamValueList where o.value_code == TempSkuList[i] select o.parametervalue).ToList();
                                paramlist[i].parametervalue = TempParaValueList[0];
                            }

                            ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                        }
                    }
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
        private void GetSelectedParaValue(IList parameter)
        {
            try
            {
                IList list = parameter as IList;
                List<ADM_M031_P> SelectedParaValueList = list.Cast<ADM_M031_P>().ToList();
                int a = ParadgSelectedIndex;
                int b = dgSelectedIndexItem;
                if (dgSelectedIndexItem != -1 && SelectedParaValueList.Count > 0 && ItemsEntity[dgSelectedIndexItem].StockUnt == true)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0)
                    {
                        #region 
                        if (SelectedParaValueList.Count > 0 && SelectedParaValueList[0].parametervalue != null && SelectedParaValueList[0].parametervalue != "")// && SelectedParaValueCollection.dgSelectedIndexItem.contains)
                        {
                            for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                            {
                                if (SelectedParaValueCollection[i].para_code == SelectedParaValueList[0].para_code && SelectedParaValueCollection[i].dgselectedindex == dgSelectedIndexItem)
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
                    else if (ItemsEntity[dgSelectedIndexItem].id != 0)
                    {

                    }
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
        private void ItemDetailsSelectionChangedMethod(IList InputList)
        {
            try
            {
                IList list = InputList as IList;

                if (dgSelectedIndexItem != -1 && ItemsEntity.Count > 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    List<PUR_T005_A> selectedlist = list.Cast<PUR_T005_A>().ToList();

                    if (selectedlist.Count > 0)
                    {

                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ItemsEntity[dgSelectedIndexItem].StockUnt == true)
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
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void GetSkuDescription()
        {
            try
            {
                if (ItemsEntity[dgSelectedIndexItem].sku_desc == null || ItemsEntity[dgSelectedIndexItem].sku_desc == "")
                {
                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].sku_desc == "" || ItemsEntity[dgSelectedIndexItem].sku_desc == null)
                        {
                            ItemsEntity[dgSelectedIndexItem].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                        else
                        {
                            ItemsEntity[dgSelectedIndexItem].sku_desc = ItemsEntity[dgSelectedIndexItem].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                    }
                }
                else
                {
                    ItemsEntity[dgSelectedIndexItem].sku_desc = "";

                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].sku_desc == "" || ItemsEntity[dgSelectedIndexItem].sku_desc == null)
                        {
                            ItemsEntity[dgSelectedIndexItem].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                        else
                        {
                            ItemsEntity[dgSelectedIndexItem].sku_desc = ItemsEntity[dgSelectedIndexItem].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                    }
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
        private void CalculateSku()
        {
            try
            {
                if (ItemsEntity[dgSelectedIndexItem].sku == null || ItemsEntity[dgSelectedIndexItem].sku == "")
                {
                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].sku == "" || ItemsEntity[dgSelectedIndexItem].sku == null)
                        {
                            ItemsEntity[dgSelectedIndexItem].sku = SelectedParaValueCollection[i].value_code;
                        }
                        else
                        {
                            ItemsEntity[dgSelectedIndexItem].sku = ItemsEntity[dgSelectedIndexItem].sku + "/" + SelectedParaValueCollection[i].value_code;
                        }
                    }
                }
                else
                {
                    ItemsEntity[dgSelectedIndexItem].sku = "";

                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].sku == "" || ItemsEntity[dgSelectedIndexItem].sku == null)
                        {
                            ItemsEntity[dgSelectedIndexItem].sku = SelectedParaValueCollection[i].value_code;
                        }
                        else
                        {
                            ItemsEntity[dgSelectedIndexItem].sku = ItemsEntity[dgSelectedIndexItem].sku + "/" + SelectedParaValueCollection[i].value_code;
                        }

                    }
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
        private void Load()
        {
            try
            {
                if (MasterEntity.FrmDate != null && MasterEntity.ToDate != null)
                {
                    string Request = "LoadFromDateToDate" + "!@" + Convert.ToDateTime(MasterEntity.FrmDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.ToDate).ToString("MM/dd/yyyy") + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.EmpId;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, Request, "PurchaseInvoice", "Procurement", "LoadAll", 0, " ");
                    FlipGridData = MCTemp.DocumentDataFlipGrid.ToList();
                    FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                    FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Date....", this.Title);
                    showMessageService.ShowMessage();

                }
            }
            catch (Exception Ex) { }
        }
        private List<PUR_T005_P_RefDoc> _RefDocTempData;
        public List<PUR_T005_P_RefDoc> RefDocTempData
        {
            get { return _RefDocTempData; }
            set
            {
                if (_RefDocTempData != value)
                {
                    _RefDocTempData = value;
                    RaisePropertyChanged("RefDocTempData");
                }
            }
        }
        private void InsertRefDoc(object InputValue)
        {
            try
            {
                if (MasterEntity.ref_doc_type == "Purchase Order")
                {
                    RefDocTempData = (from o in MC.Purchase_Invoice_Reference where o.doc_cat == "PO" select o).ToList();

                    ReferenceDocCollection = CollectionViewSource.GetDefaultView(RefDocTempData.ToList());
                    ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T005_P_RefDoc)x).Ref_DocNo);
                    TheFilter = (o, prefix) => ((PUR_T005_P_RefDoc)o).Ref_DocNo.ToString().ToLower().Contains(prefix)
                    || ((PUR_T005_P_RefDoc)o).Ref_date.ToString().ToLower().Contains(prefix)
                    || ((PUR_T005_P_RefDoc)o).PartyNm.ToString().ToLower().Contains(prefix)
                    || ((PUR_T005_P_RefDoc)o).doc_cat.ToString().ToLower().Contains(prefix);
                    ASRefDocNo = new AutoSuggestTextViewModel<dynamic>(RefDocTempData, TheFilter, SuggestedValue, "Ref_DocNo", true);
                    ASRefDocNo.AutoSuggestVM.IsEmptyValueAllowed = true;
                }
                else if (MasterEntity.ref_doc_type == "Goods Receipt Note")
                {
                    RefDocTempData = (from o in MC.Purchase_Invoice_Reference where o.doc_cat == "GR" select o).ToList();

                    ReferenceDocCollection = CollectionViewSource.GetDefaultView(RefDocTempData.ToList());
                    ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T005_P_RefDoc)x).Ref_DocNo);
                    TheFilter = (o, prefix) => ((PUR_T005_P_RefDoc)o).Ref_DocNo.ToString().ToLower().Contains(prefix)
                    || ((PUR_T005_P_RefDoc)o).Ref_date.ToString().ToLower().Contains(prefix)
                    || ((PUR_T005_P_RefDoc)o).PartyNm.ToString().ToLower().Contains(prefix)
                    || ((PUR_T005_P_RefDoc)o).doc_cat.ToString().ToLower().Contains(prefix);
                    ASRefDocNo = new AutoSuggestTextViewModel<dynamic>(RefDocTempData, TheFilter, SuggestedValue, "Ref_DocNo", true);
                    ASRefDocNo.AutoSuggestVM.IsEmptyValueAllowed = true;

                }
            }
            catch (Exception ex) { }
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
                    MasterEntity.advance_lic = POPUPEntityObject.lic_cod;
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
        private void InsertServiceProvider(object InputValue, bool OverrideValue)
        {
            string Request = "";
            ADM_M028_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
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
                    if (((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }

                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.cf_agent_cd = POPUPEntityObject.PartyId;
                    MasterEntity.cf_agent_name = POPUPEntityObject.PartyNm;
                }
            }
            catch (Exception ex)
            { }
        }
        private void LoadHistory()
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadHistory" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.EmpId + "!@" + Convert.ToDateTime(MasterEntity.Fltr_FrmDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.Fltr_ToDate).ToString("MM/dd/yyyy") + "!@" + MasterEntity.Fltr_t_status + "!@" + MasterEntity.Fltr_active + "!@" + MasterEntity.Fltr_doc_type + "!@" + MasterEntity.Fltr_PartyId + "!@" + AppSessionState.client;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MCTemp, Request, "PurchaseInvoice", "Procurement", "LoadAll", 0, "");

                MC.DocumentDataFlipGrid = MCTemp.DocumentDataFlipGrid;
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(MC.DocumentDataFlipGrid);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

                var msg = new NotificationMessage("PUR_T005_VM");
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
        private void InsertFltrDocType(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M007 POPUPEntityObject = null;
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.doc_typeList.Where(x => x.doc_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SYS_M007>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M007>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.Fltr_doc_type = POPUPEntityObject.doc_type;
                }
            }
            catch (Exception Ex) { }
        }
        private void InsertFltrStatus(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0013 POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.t_statusList.Where(x => x.t_display.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M0013>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0013>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.Fltr_t_status = POPUPEntityObject.t_status;
                    MasterEntity.Fltr_t_display = POPUPEntityObject.t_display;
                }
            }
            catch (Exception Ex) { }
        }
        private void InsertFltrSoldToParty(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;

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
                    if (((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.Fltr_PartyId = POPUPEntityObject.PartyId;
                    MasterEntity.Fltr_PartyNm = POPUPEntityObject.PartyNm;
                }
            }
            catch (Exception Ex) { }
        }
        string DocumentList = "";
        private void AddSelectedRef(object InputValue)
        {
            try
            {
                PUR_T005_P_RefDoc POPUPEntityObject = null;
                string Request;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Purchase_Invoice_Reference.Where(x => x.Ref_DocNo.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<PUR_T005_P_RefDoc>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PUR_T005_P_RefDoc>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    if (POPUPEntityObject.t_status != "009")
                    {
                        MasterEntity.ref_doc_no = POPUPEntityObject.Ref_DocNo;
                        MasterEntity.ref_doc_cat = POPUPEntityObject.doc_cat;
                        MasterEntity.ref_doc_type = POPUPEntityObject.Ref_DocType;

                        DocumentList = "";
                        if (MasterEntity.ref_doc_cat == "PO")
                        {
                            refdoctempa = (from o in MC.Purchase_Invoice_Reference where o.doc_cat == "PO" select o).ToList();
                            ReferenceDocPOCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                            ReferenceDocPOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                            var refdoctempGRN = (from o in MC.Purchase_Invoice_Reference where o.doc_cat == "GR" select o).ToList();
                            foreach (var item in refdoctempGRN)
                            {
                                item.Select = false;
                            }
                            ReferenceDocGRNCollection = CollectionViewSource.GetDefaultView(refdoctempGRN);
                            ReferenceDocGRNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                        }
                        else if (MasterEntity.ref_doc_cat == "GR")
                        {
                            refdoctempa = (from o in MC.Purchase_Invoice_Reference where o.doc_cat == "GR" select o).ToList();
                            ReferenceDocGRNCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                            ReferenceDocGRNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                            var refdoctempPO = (from o in MC.Purchase_Invoice_Reference where o.doc_cat == "PO" select o).ToList();
                            foreach (var item in refdoctempPO)
                            {
                                item.Select = false;
                            }
                            ReferenceDocPOCollection = CollectionViewSource.GetDefaultView(refdoctempPO);
                            ReferenceDocPOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                        }
                        var refdoc = from o in refdoctempa
                                     where o.PartyId == POPUPEntityObject.PartyId
                                         && o.PartyNm == POPUPEntityObject.PartyNm
                                         && o.po_code == POPUPEntityObject.po_code
                                         && o.curr_code == POPUPEntityObject.curr_code
                                         && o.bill_address_id == POPUPEntityObject.bill_address_id
                                         && o.doc_cat == POPUPEntityObject.doc_cat
                                         && o.p_term_code == POPUPEntityObject.p_term_code
                                         && o.incoterms == POPUPEntityObject.incoterms
                                         && o.country_code == POPUPEntityObject.country_code
                                         && o.country_nm_s == POPUPEntityObject.country_nm_s
                                         && o.issue_date == POPUPEntityObject.issue_date
                                     select o;
                        foreach (var item in refdoc)
                        {
                            if (item.Select == true)
                            {
                                DocumentList = DocumentList + "," + item.Ref_DocNo;
                            }
                        }
                        DocumentList = DocumentList.ToString().TrimStart(new char[] { ',' });
                        if (MasterEntity.ref_doc_cat == "PO")
                        {
                            if (POPUPEntityObject.Select == true)
                            {
                                ReferenceDocPOCollection = CollectionViewSource.GetDefaultView(refdoc);
                                ReferenceDocPOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                            }
                        }
                        else if (MasterEntity.ref_doc_cat == "GR")
                        {
                            if (POPUPEntityObject.Select == true)
                            {
                                ReferenceDocGRNCollection = CollectionViewSource.GetDefaultView(refdoc);
                                ReferenceDocGRNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                            }
                        }
                        if (DocumentList == "")
                        {
                            MasterEntity.ref_doc_no = null;
                            MasterEntity.ref_doc_cat = null;
                            MasterEntity.ref_doc_type = null;
                        }
                    }
                    else if (POPUPEntityObject.Select == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("This Document is Suspended. You Cannot Proceed with this Document.");
                        showMessageService.ShowMessage();
                    }
                }
            }
            catch (Exception Ex) { }
        }
        private void FilterLicenceDataGrid()
        {
            try
            {
                if (LicenceDetailsEntity != null && LicenceDetailsEntity.Count > 0 && dgSelectedIndexItem >= 0)
                {
                    DataGridViewFilter = CollectionViewSource.GetDefaultView(LicenceDetailsEntity);
                    DataGridViewFilter.Filter = adv => ((ACC_T006_D)adv).ItemCode.Equals(ItemsEntity[dgSelectedIndexItem].ItemCode);
                    DataGridViewFilter.Refresh();
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertTransporterForTax(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    if (TotalDocumentTaxes.Count > dgSelectedIndexTaxSummury)
                    {
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].PartyId = POPUPEntityObject.PartyId;
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].PartyNm = POPUPEntityObject.PartyNm;
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
        private void InsertWithHolding(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M025_P POPUPEntityObject = null;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.withholdinglist.Where(x => x.wtax_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M004_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M025_P>().ToList()[0];
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
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, Request, "PurchaseInvoice", "Procurement", "LoadAll", 0, "");

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
        private void PrintLocalCurrencyInvoice()
        {
            CursorControl.SetBusyState();
            string Request = "";
            try
            {

                if (MasterEntity.doc_no == null || MasterEntity.doc_no == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("You must save the record before printing it.", this.Title);
                    showMessageService.ShowMessage();
                }

                else
                {
                    Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + MasterEntity.doc_no + "!@" + MasterEntity.PartyId + "!@" + AppSessionState.comp_code;


                    string ReportName = "LocalCurrencyPurchaseInvoice.rdlc";
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, Request, "PurchaseInvoice", "Procurement", "", 0, "");


                    if (MasterEntity.roundup_total > 0)
                    {
                        ADM_M037 curr_obj = new ADM_M037();
                        curr_obj = ((List<ADM_M037>)AppSessionState.CurrencyList).Where(x => x.curr_code == AppSessionState.curr_code).ToList()[0];
                        MCTemp.MasterEntity[0].amt_word_local = num.AmountInWords(Convert.ToDecimal(MasterEntity.roundup_total * MasterEntity.exch_rate), AppSessionState.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word);
                    }
                    object[] objDataSource = new object[5];
                    string[] objDataSourceName = new string[5];
                    MC.MasterEntity.Clear();


                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[0] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[1] = Result;
                    objDataSource[2] = MCTemp.MasterEntity;
                    objDataSource[3] = MCTemp.ItemsEntity;
                    objDataSource[4] = MCTemp.TaxEntity;

                    objDataSourceName[0] = "dsCompanyInfo";
                    objDataSourceName[1] = "dsLocationInfo";
                    objDataSourceName[2] = "dsPurchaseDocument";
                    objDataSourceName[3] = "dsPurchaseDocumentItems";
                    objDataSourceName[4] = "dsPurchaseDocumentTax";



                    //var ReportStringList = (from o in MC.doc_typeList where o.doc_type == MasterEntity.doc_type select o).ToList();

                    //    ReportName = ReportStringList[0].report_name.Split(',')[0];


                    ReportManager ReportManager = new ReportManager();
                    string ReportDisplayName = MasterEntity.supplier_party_Nm + "_" + MasterEntity.doc_no + "_" + MasterEntity.doc_date.Value.ToShortDateString();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Procurment\\" + ReportName, getParametersList(), ReportDisplayName);

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
                result.Add("doc_no", MasterEntity.doc_no);
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
        #endregion

        #region Abstract Method
        protected override void OnCreateAction(InquiryActionResult<PUR_T005> result)
        {
            try
            {
                isNewRecord = true;
                parameter = false;
                MoveFlag = true;
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
                DefaultValues();
                foreach (var item in MC.Purchase_Invoice_Reference)
                {
                    item.Select = false;
                }
                var refdoc = (from o in MC.Purchase_Invoice_Reference where o.doc_cat == "PO" select o).ToList();

                ReferenceDocPOCollection = CollectionViewSource.GetDefaultView(refdoc);
                ReferenceDocPOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                refdoc = (from o in MC.Purchase_Invoice_Reference where o.doc_cat == "GR" select o).ToList();

                ReferenceDocGRNCollection = CollectionViewSource.GetDefaultView(refdoc);
                ReferenceDocGRNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                if (PurchaseOrganisationList.Count != 0)
                {
                    if (PurchaseOrganisationList.Count == 1)
                    {
                        MasterEntity.po_code = PurchaseOrganisationList[0].po_code;
                        MasterEntity.pur_org = PurchaseOrganisationList[0].pur_org;
                    }
                }
                else
                {
                    MasterEntity.po_code = "";
                }
                if (PurchaseGroupList.Count != 0)
                {
                    if (PurchaseGroupList.Count == 1)
                    {
                        MasterEntity.pg_code = PurchaseGroupList[0].pg_code;
                        MasterEntity.pg_name = PurchaseGroupList[0].pg_name;
                    }
                }
                else
                {
                    MasterEntity.pg_code = "";
                }
                PartyEnable = true;
                ref_doc_cat = "";
                var msg = new NotificationMessage("PUR_T005_VM");
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
                    if (MasterEntity.t_status != "017")
                    {
                        string Request = "ValidateInvoice" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_no + "!@" + AppSessionState.UserID;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, Request, "PurchaseInvoice", "Procurement", "LoadAll", 0, "");

                        if (MCTemp.MasterEntity.Count > 0)
                        {
                            if (MCTemp.MasterEntity[0].t_status == "017")
                            {
                                MasterEntity.t_status = MCTemp.MasterEntity[0].t_status;
                                MasterEntity.t_display = (from o in MC.t_statusList where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Invoice Validate Succesfully...");
                                showMessageService.ShowMessage();
                            }
                        }
                    }
                    else if (MasterEntity.t_status == "017")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Invoice Validated...");
                        showMessageService.ShowMessage();
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
        protected override void OnFlipAction(InquiryActionResult<PUR_T005> result)
        {
            try
            {
                //SelectedSEL_T001.CancelEdit();
                //string post_key = MC.doc_typeList.Where(x => x.doc_type == MasterEntity.doc_type).ToList()[0].posting_key;
                //object[] obj = new { MasterEntity, ItemsEntity, TotalDocumentTaxes, post_key };
                object objParam = MasterEntity.doc_no;
                //object[] obj = new[] { MasterEntity, ItemsEntity, TotalDocumentTaxes, post_key };

                string userAuth = "Reflection.Modules.Finance.Views.LedgerView"; // this one is path option
                string path1 = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.Finance.dll");
                Assembly assembly = Assembly.LoadFile(path1);
                Type type = assembly.GetType(userAuth);
                if (type != null)
                {
                    //dynamic instance = Activator.CreateInstance(type, MasterEntity, ItemsEntity, TotalDocumentTaxes, post_key);
                    dynamic instance = Activator.CreateInstance(type, objParam);
                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                }
            }
            catch (Exception ex)
            {

            }
        }
        protected override void OnHelpAction(InquiryActionResult<PUR_T005> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<PUR_T005> result)
        {
            CursorControl.SetBusyState();
            string Request = "";
            try
            {

                if (MasterEntity.doc_no == null || MasterEntity.doc_no == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("You must save the record before printing it.", this.Title);
                    showMessageService.ShowMessage();
                }

                else
                {
                    Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + MasterEntity.doc_no + "!@" + MasterEntity.PartyId + "!@" + AppSessionState.comp_code;


                    string ReportName = "PurchaseInvoice.rdlc";
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PUR_T005>(MCTemp, Request, "PurchaseInvoice", "Procurement", "", 0, "");

                    object[] objDataSource = new object[5];
                    string[] objDataSourceName = new string[5];
                    MC.MasterEntity.Clear();


                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[0] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[1] = Result;
                    objDataSource[2] = MCTemp.MasterEntity;
                    objDataSource[3] = MCTemp.ItemsEntity;
                    objDataSource[4] = MCTemp.TaxEntity;

                    objDataSourceName[0] = "dsCompanyInfo";
                    objDataSourceName[1] = "dsLocationInfo";
                    objDataSourceName[2] = "dsPurchaseDocument";
                    objDataSourceName[3] = "dsPurchaseDocumentItems";
                    objDataSourceName[4] = "dsPurchaseDocumentTax";



                    //var ReportStringList = (from o in MC.doc_typeList where o.doc_type == MasterEntity.doc_type select o).ToList();

                    //    ReportName = ReportStringList[0].report_name.Split(',')[0];


                    ReportManager ReportManager = new ReportManager();
                    string ReportDisplayName = MasterEntity.supplier_party_Nm + "_" + MasterEntity.doc_no + "_" + MasterEntity.doc_date.Value.ToShortDateString();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Procurment\\" + ReportName, getParametersList(), ReportDisplayName);

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
            try
            {
                CursorControl.SetBusyState();
                if (!string.IsNullOrEmpty(MasterEntity.doc_no))
                {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MCTemp.Attachment, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
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
        protected override void OnRefreshCommand(InquiryActionResult<PUR_T005> result)
        {
            LoadInitialData();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PUR_T005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PUR_T005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PUR_T005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PUR_T005> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnRemoveAction(InquiryActionResult<PUR_T005> result)
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
                    string response = repository.Delete(MasterEntity.doc_no, "PurchaseInvoice", "Procurement");

                    MasterEntity = new PUR_T005();
                    ItemsEntity = new ObservableCollection<PUR_T005_A>();
                    isNewRecord = true;
                    parameter = false;
                    MoveFlag = true;
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
        protected override void OnSaveAction(InquiryActionResult<PUR_T005> result)
        {
            try
            {
                CursorControl.SetBusyState();
                if (MasterEntity.ref_doc_no == null || MasterEntity.ref_doc_no == "")
                {
                    MasterEntity.ref_doc_type = "";
                }
                if (MasterEntity.ind_trade == "L")
                {
                    MasterEntity.export_ind = "L";
                }
                else if (MasterEntity.ind_trade == "I")
                {
                    MasterEntity.export_ind = "E";
                }
                else
                {
                    MasterEntity.export_ind = "L";
                }
                if (validation() == true)
                {
                    MasterEntity.XmlDataDocument_PUR_T005_A = obj.ObjectToXML(ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = obj.ObjectToXML(TotalDocumentTaxes);
                    MasterEntity.XmlDataDocument_ACC_T006_D = obj.ObjectToXML(LicenceDetailsEntity);
                    MasterEntity.editby = AppSessionState.UserID;
                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<PUR_T005>(MasterEntity, "PurchaseInvoice", "Procurement");
                        SetBusinessEntitiesAfterLoad("Save", "");
                        if (MasterEntity.doc_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnInsert") >= 0)
                        {
                            NotifyMessage("OnInsert", "Created");
                        }
                        if (MasterEntity.doc_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnApproval") >= 0)
                        {
                            NotifyMessage("OnApproval", "Created");
                        }
                        if (MasterEntity.doc_no != "" || MasterEntity.doc_no != null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Data Saved Successfully");
                            showMessageService.ShowMessage();
                        }
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<PUR_T005>(MasterEntity, "PurchaseInvoice", "Procurement");
                        SetBusinessEntitiesAfterLoad("Save", "");
                        if (MasterEntity.doc_no != "" || MasterEntity.doc_no != null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Data Update Successfully");
                            showMessageService.ShowMessage();
                        }
                    }
                    
                    isNewRecord = false;
                    parameter = false;
                    MoveFlag = false;
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
                    html += "<td width=10%> <p><strong><span style=color:#000080;> " + item.description + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.qty.ToString() + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.unit_code + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.unit_price.ToString() + "</span></strong></p> </td>";
                    html += "</tr>";
                }
            }
            html += "</table>";

            return html;
        }
        private void NotifyMessage(string AlertName, string operation)
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
                        new KeyValuePair<string, string>("[EMP]",AppSessionState.Name),
                        new KeyValuePair<string, string>("[DOC]", "Purchase Invoice"), //MasterEntity.doc_desc
                        new KeyValuePair<string, string>("[OPR]", operation),
                        new KeyValuePair<string, string>("[DOCNO]", MasterEntity.doc_no),
                        new KeyValuePair<string, string>("[Comp]","M/s: " +AppSessionState.CompanyName),
                        new KeyValuePair<string, string>("[TSTS]", MasterEntity.t_display),
                        new KeyValuePair<string, string>("[Attn]",VarData.EmpName),
                        new KeyValuePair<string, string>("[CUST]","M/s: " +  MasterEntity.supplier_party_Nm),
                        new KeyValuePair<string, string>("[CUR]",MasterEntity.curr_code.ToString()),
                        new KeyValuePair<string, string>("[OVAL]",MasterEntity.roundup_total.ToString()),
                        new KeyValuePair<string, string>("[DOCDATE]", MasterEntity.doc_date.ToString()),
                        new KeyValuePair<string, string>("[MODDT]", DateTime.Now.ToString()),
                        new KeyValuePair<string, string>("[PREF]", (MasterEntity.ref_doc_no ?? "").ToString() + " Dated: " + (MasterEntity.ref_date?.ToShortDateString())), //MasterEntity.cust_ref_date.HasValue ? MasterEntity.cust_ref_date.Value.ToString() : string.Empty;
                        new KeyValuePair<string, string>("[INCO]", ((MasterEntity.incoterms ?? "") + ", " + (MasterEntity.incoterm2 ?? ""))),
                        new KeyValuePair<string, string>("[ITEM_TABLE]", xx),
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
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        //private void NotifyMessage(string AlertName)
        //{
        //    try
        //    {
        //        List<NotificationData> objNotifyData = new List<NotificationData>();
        //        List<NotificationData> objNotifyDataTemp = new List<NotificationData>();
        //        NotificationData objNotifyDataObject = new NotificationData();
        //        string xx = ConvertDataTableToHTML();
        //        objNotifyDataTemp = NotificationDataCollection.Where(x => x.alert_name == AlertName).ToList();
        //        objNotifyDataTemp[0].CopyPropertiesTo<NotificationData>(objNotifyDataObject);
        //        objNotifyData.Add(objNotifyDataObject);
        //        foreach (NotificationData VarData in objNotifyData)
        //        {
        //            List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>()
        //        {
        //            new KeyValuePair<string, string>("[CUR]",MasterEntity.curr_code.ToString()),
        //            new KeyValuePair<string, string>("[OVAL]", MasterEntity.roundup_total.ToString()),
        //            new KeyValuePair<string, string>("[CUST]","M/s: " + MasterEntity.supplier_party_Nm),
        //            new KeyValuePair<string, string>("[EMP]",AppSessionState.Name),
        //            new KeyValuePair<string, string>("[DOC]", "Purchase Invoice"),
        //            new KeyValuePair<string, string>("[DOCNO]", MasterEntity.doc_no),
        //            new KeyValuePair<string, string>("[DOCDATE]", MasterEntity.doc_date.ToString()),
        //            new KeyValuePair<string, string>("[Comp]","M/s: " + AppSessionState.CompanyName),
        //            new KeyValuePair<string, string>("[Attn]",MC.NotificationData[0].EmpName),
        //        };
        //            foreach (KeyValuePair<string, string> kvp in kvpList)
        //            {
        //                VarData.subject = VarData.subject.Replace(kvp.Key, kvp.Value);
        //                VarData.msg_body = VarData.msg_body.Replace(kvp.Key, kvp.Value);
        //            }
        //            Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, VarData.to_mail_id, VarData.cc_mail_id, VarData.bcc_mail_id, VarData.subject, VarData.msg_body, null);

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        //showMessageService.ButtonSetup = DialogButton.Ok;
        //        //showMessageService.Caption = "Message";
        //        //showMessageService.Text = String.Format(ex.Message, this.Title);
        //        //showMessageService.ShowMessage();
        //    }
        //}

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
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as PUR_T005_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.supplier_party_Nm != null && data.supplier_party_Nm.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
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
            if (ReferenceDocPOCollection != null)
            {
                ReferenceDocPOCollection.Refresh();
            }
            if (ReferenceDocGRNCollection != null)
            {
                ReferenceDocGRNCollection.Refresh();
            }
        }
        public bool Filter_ReferenceDoc(object obj)
        {
            var data = obj as PUR_T005_P_RefDoc;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_ReferenceDoc))
                {
                    return (data.Ref_DocNo != null && data.Ref_DocNo.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.Ref_date != null && data.Ref_date.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.Ref_DocType != null && data.Ref_DocType.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower())
                       );
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
            var data = obj as PUR_T005_P_PI_ItemsList;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_ItemsListPopup))
                {
                    return (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower()) ||
                           (data.SubCatCode != null && data.SubCatCode.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            (data.item_cat_id != null && data.item_cat_id.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower()));
                }
                return true;
            }
            return false;
        }

        

        #endregion
    }
}