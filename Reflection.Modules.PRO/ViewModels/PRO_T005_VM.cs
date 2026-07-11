using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
using Reflection.ReportingServices;
using System.Threading.Tasks;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using Reflection.BusinessEntity.CustomerRelation;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.GEN;

namespace Reflection.Modules.PRO.ViewModels
{
    // NOTE: add Billing and Delivery Plant address popup in schedule Grid. show address selection on front view so that user will select it before item add. if change then how to chage in schedule table?
    public class PRO_T005_VM : WorkspaceViewModel<PUR_T002_A>
    {
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PRO_T005_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
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
        private AutoSuggestTextViewModel<dynamic> _AS_SUP_PLANT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_SUP_PLANT
        {
            get { return _AS_SUP_PLANT; }
            set
            {
                if (_AS_SUP_PLANT != value)
                {
                    _AS_SUP_PLANT = value; RaisePropertyChanged("AS_SUP_PLANT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_REC_PLANT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_REC_PLANT
        {
            get { return _AS_REC_PLANT; }
            set
            {
                if (_AS_REC_PLANT != value)
                {
                    _AS_REC_PLANT = value; RaisePropertyChanged("AS_REC_PLANT");
                }
            }
        }
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
        private AutoSuggestTextViewModel<dynamic> _ASt_status { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASt_status
        {
            get { return _ASt_status; }
            set
            {
                if (_ASt_status != value)
                {
                    _ASt_status = value; RaisePropertyChanged("ASt_status");
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
        private AutoSuggestTextViewModel<dynamic> _ASScope { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASScope
        {
            get { return _ASScope; }
            set
            {
                if (_ASScope != value)
                {
                    _ASScope = value; RaisePropertyChanged("ASScope");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASTermsCond { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTermsCond
        {
            get { return _ASTermsCond; }
            set
            {
                if (_ASTermsCond != value)
                {
                    _ASTermsCond = value; RaisePropertyChanged("ASTermsCond");
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
        private AutoSuggestTextViewModel<dynamic> _ASComponant { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASComponant
        {
            get { return _ASComponant; }
            set
            {
                if (_ASComponant != value)
                {
                    _ASComponant = value; RaisePropertyChanged("ASComponant");
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

        private AutoSuggestTextViewModel<dynamic> _ASOrderType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASOrderType
        {
            get { return _ASOrderType; }
            set
            {
                if (_ASOrderType != value)
                {
                    _ASOrderType = value; RaisePropertyChanged("ASOrderType");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASValidatedBy { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASValidatedBy
        {
            get { return _ASValidatedBy; }
            set
            {
                if (_ASValidatedBy != value)
                {
                    _ASValidatedBy = value; RaisePropertyChanged("ASValidatedBy");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASSupplier { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSupplier
        {
            get { return _ASSupplier; }
            set
            {
                if (_ASSupplier != value)
                {
                    _ASSupplier = value; RaisePropertyChanged("ASSupplier");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASContactPerson { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASContactPerson
        {
            get { return _ASContactPerson; }
            set
            {
                if (_ASContactPerson != value)
                {
                    _ASContactPerson = value; RaisePropertyChanged("ASContactPerson");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBuyer { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBuyer
        {
            get { return _ASBuyer; }
            set
            {
                if (_ASBuyer != value)
                {
                    _ASBuyer = value; RaisePropertyChanged("ASBuyer");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDelAddress { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDelAddress
        {
            get { return _ASDelAddress; }
            set
            {
                if (_ASDelAddress != value)
                {
                    _ASDelAddress = value; RaisePropertyChanged("ASDelAddress");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBillAddress { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBillAddress
        {
            get { return _ASBillAddress; }
            set
            {
                if (_ASBillAddress != value)
                {
                    _ASBillAddress = value; RaisePropertyChanged("ASBillAddress");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_LOCATION { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_LOCATION
        {
            get { return _AS_LOCATION; }
            set
            {
                if (_AS_LOCATION != value)
                {
                    _AS_LOCATION = value; RaisePropertyChanged("AS_LOCATION");
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

        private AutoSuggestTextViewModel<dynamic> _ASTax { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTax
        {
            get { return _ASTax; }
            set
            {
                if (_ASTax != value)
                {
                    _ASTax = value; RaisePropertyChanged("ASTax");
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

        private AutoSuggestTextViewModel<dynamic> _ASReqNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASReqNo
        {
            get { return _ASReqNo; }
            set
            {
                if (_ASReqNo != value)
                {
                    _ASReqNo = value; RaisePropertyChanged("ASReqNo");
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

        private AutoSuggestTextViewModel<dynamic> _ASDestWar { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDestWar
        {
            get { return _ASDestWar; }
            set
            {
                if (_ASDestWar != value)
                {
                    _ASDestWar = value; RaisePropertyChanged("ASDestWar");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASStorLoc { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASStorLoc
        {
            get { return _ASStorLoc; }
            set
            {
                if (_ASStorLoc != value)
                {
                    _ASStorLoc = value; RaisePropertyChanged("ASStorLoc");
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
                    { ASDefault = ASItemCode; }
                    else if (SourceName == "unit_code")
                    { ASDefault = ASUnit; }
                    else if (SourceName == "item_cat")
                    { ASDefault = ASItemCategory; }
                    //else if (SourceName == "PartyNm")
                    //{ ASDefault3 = ASdgTransporter; }
                    else if (SourceName == "Termscon_type")
                    { ASDefault2 = ASTermsCond; }
                    else if (SourceName == "con_type")
                    { ASDefault1 = ASConditionType; }
                    //else if (SourceName == "order_to_plant")
                    //{ ASDefault = ASOrderTo; }
                    //else if (SourceName == "para1")
                    //{ ASDefault = ASInk; }
                    //else if (SourceName == "para5")
                    //{ ASDefault = ASILD; }
                    //else if (SourceName == "para3")
                    //{ ASDefault = ASGrade; }
                    else if (SourceName == "curr_code")
                    { ASDefault1 = ASdgCurrency; }
                    else if (SourceName == "gl_code")
                    { ASDefault1 = ASTaxacc; }
                    else if (SourceName == "licence_no")
                    { ASDefault4 = ASLicence; }
                    else if (SourceName == "incoterms")
                    { ASDefault4 = ASdgIncoTerms; }
                    else if (SourceName == "buss_place")
                    { ASDefault = ASdgBussPlace; }
                    else if (SourceName == "ship_to_Party")
                    { ASDefault = ASdgShipToParty; }
                }
            }

        }
        # endregion
        #region Variable Declaration
        string Currency;
        string PartyEmailId = "";
        string PersonEmailId = "";
        string PreviousUnitCode = "";
        string NewUnitCode = "";
        private bool AutoRoundupEnable = true;
        private int RoundUpDecimals = 2;
        private bool _NewRecord;
        public bool NewRecord
        {
            get { return _NewRecord; }
            set
            {
                if (_NewRecord != value)
                {
                    _NewRecord = value; RaisePropertyChanged("NewRecord");
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
        private string _ind_value;
        private string ind_value
        {
            get { return _ind_value; }
            set
            {
                if (_ind_value != value)
                {
                    _ind_value = value; RaisePropertyChanged("ind_value");
                }
            }
        }
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }

        private IEnumerable _TITLE_COLLECTION;
        public IEnumerable TITLE_COLLECTION
        {
            get { return _TITLE_COLLECTION; }
            set
            {
                _TITLE_COLLECTION = value;

                RaisePropertyChanged("TITLE_COLLECTION");
            }
        }

        public string ref_doc_cat { get; set; }
        NUMBER_TO_WORDS_CONVERTER NOW_OBJ = new NUMBER_TO_WORDS_CONVERTER();
        WebServiceRepository<PUR_T002_A> repository = new WebServiceRepository<PUR_T002_A>();
        WebServiceRepository<MultipleContext_PUR_T002_A> repository_MC = new WebServiceRepository<MultipleContext_PUR_T002_A>();
        WebServiceRepository<MultipleContext_PUR_T002_A> repository_MCTemp = new WebServiceRepository<MultipleContext_PUR_T002_A>();
        WebServiceRepository<MultipleContext_PUR_T002_A> repository_MCTemp_Report = new WebServiceRepository<MultipleContext_PUR_T002_A>();
        WebServiceRepository<PUR_T002_P_PR_ItemsList> repositoryItemList = new WebServiceRepository<PUR_T002_P_PR_ItemsList>();
        ObjectSerializationService obj = new ObjectSerializationService();
        MultipleContext_PUR_T002_A _MC = new MultipleContext_PUR_T002_A();
        public MultipleContext_PUR_T002_A MC
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
        MultipleContext_PUR_T002_A _MCTemp = new MultipleContext_PUR_T002_A();
        public MultipleContext_PUR_T002_A MCTemp
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
        MultipleContext_PUR_T002_A _MCTemp_Report = new MultipleContext_PUR_T002_A();
        public MultipleContext_PUR_T002_A MCTemp_Report
        {
            get { return _MCTemp_Report; }
            set
            {
                if (_MCTemp_Report != value)
                {
                    _MCTemp_Report = value;

                    RaisePropertyChanged("MCTemp_Report");
                }
            }
        }
        private MC_SDM_BE _MCTemp2 = new MC_SDM_BE(); // This is for BOM only
        public MC_SDM_BE MCTemp2
        {
            get { return _MCTemp2; }
            set
            {
                if (_MCTemp2 != value)
                {
                    _MCTemp2 = value; RaisePropertyChanged("MCTemp2");
                }
            }
        }
        private PUR_T002_A _MasterEntity;
        public PUR_T002_A MasterEntity
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
        private PUR_T002_B _ItemEntityObject;
        public PUR_T002_B ItemEntityObject
        {
            get
            {
                return _ItemEntityObject;
            }
            set
            {
                if (_ItemEntityObject != value)
                {
                    _ItemEntityObject = value;
                    RaisePropertyChanged("ItemEntityObject");
                }
            }
        }

        private PUR_T002_A _MasterEntityTemp;
        public PUR_T002_A MasterEntityTemp
        {
            get
            {
                return _MasterEntityTemp;
            }
            set
            {
                if (_MasterEntityTemp != value)
                {
                    _MasterEntityTemp = value;
                    RaisePropertyChanged("MasterEntityTemp");
                    value.BeginEdit();
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
        public List<ADM_M043_D> _ApprovalData { get; set; }
        public List<ADM_M043_D> ApprovalData
        {
            get
            {
                return _ApprovalData;
            }
            set
            {
                if (_ApprovalData != value)
                {
                    _ApprovalData = value;
                    RaisePropertyChanged("ApprovalData");
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
        private int _SelectedTabIndexItem;
        public int SelectedTabIndexItem
        {
            get
            {
                return _SelectedTabIndexItem;
            }
            set
            {
                if (_SelectedTabIndexItem != value)
                {
                    _SelectedTabIndexItem = value;
                    RaisePropertyChanged("SelectedTabIndexItem");
                    if (SelectedTabIndexItem == 3)
                    {
                        LoadComponantData(SelectedTabIndexItem);
                    }
                }
            }
        }
        private int _TaxId;
        public int TaxId
        {
            get { return _TaxId; }
            set
            {
                if (_TaxId != value)
                {
                    _TaxId = value;
                    RaisePropertyChanged("TaxId");
                }
            }
        }
        private string _TaxDescription;
        public string TaxDescription
        {
            get { return _TaxDescription; }
            set
            {
                if (_TaxDescription != value)
                {
                    _TaxDescription = value;
                    RaisePropertyChanged("TaxDescription");
                }
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
        private ObservableCollection<PUR_T002_B> _dgItemsEntity;
        public ObservableCollection<PUR_T002_B> dgItemsEntity
        {
            get
            {
                return _dgItemsEntity;
            }
            set
            {
                if (_dgItemsEntity != value)
                {
                    _dgItemsEntity = value;
                    dgItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("dgItemsEntity");
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
        public List<ADM_M038_C> _UnitConversionList;
        public List<ADM_M038_C> UnitConversionList
        {
            get
            {
                return _UnitConversionList;
            }
            set
            {
                _UnitConversionList = value;
                RaisePropertyChanged("UnitConversionList");
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

        private PUR_T004_A _ScheduleEntity;
        public PUR_T004_A ScheduleEntity
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
        private PUR_T004_B _SelectedItemScheduleEntity;
        //Data Source for Schedule DataGrid
        public PUR_T004_B SelectedItemScheduleEntity
        {
            get
            {
                return _SelectedItemScheduleEntity;
            }
            set
            {
                if (_SelectedItemScheduleEntity != value)
                {
                    _SelectedItemScheduleEntity = value;
                    RaisePropertyChanged("SelectedItemScheduleEntity");
                }
            }
        }
        private PUR_T002_C _SelectedItemComponantEntity;
        //Data Source for Schedule DataGrid
        public PUR_T002_C SelectedItemComponantEntity
        {
            get
            {
                return _SelectedItemComponantEntity;
            }
            set
            {
                if (_SelectedItemComponantEntity != value)
                {
                    _SelectedItemComponantEntity = value;
                    RaisePropertyChanged("SelectedItemComponantEntity");
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
        private ObservableCollection<PUR_T004_B> _dgItemScheduleEntity;
        public ObservableCollection<PUR_T004_B> dgItemScheduleEntity
        {
            get
            {
                return _dgItemScheduleEntity;
            }
            set
            {
                if (_dgItemScheduleEntity != value)
                {
                    _dgItemScheduleEntity = value;
                    // NotifyCollectionChangedEventHandler added to call CollectionChangedNotifyForSchedule function evry time. which will not work after one time use earlier.
                    _dgItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
                    RaisePropertyChanged("dgItemScheduleEntity");
                }
            }
        }
        private ObservableCollection<PUR_T002_C> _dgComponantEntity;
        public ObservableCollection<PUR_T002_C> dgComponantEntity
        {
            get
            {
                return _dgComponantEntity;
            }
            set
            {
                if (_dgComponantEntity != value)
                {
                    _dgComponantEntity = value;
                    _dgComponantEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForComponant);
                    RaisePropertyChanged("dgComponantEntity");
                }
            }
        }

        //Pending assignment of dgTotalTaxSummury
        private ObservableCollection<PUR_T002_C> _dgTotalTaxSummury;
        public ObservableCollection<PUR_T002_C> dgTotalTaxSummury
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

        private ObservableCollection<ACC_T006_B> _TotalDocumentTaxes;
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
        private STD_LIST_BE _STD_OBJECT;
        public STD_LIST_BE STD_OBJECT
        {
            get { return _STD_OBJECT; }
            set
            {
                if (_STD_OBJECT != value)
                {
                    _STD_OBJECT = value; RaisePropertyChanged("STD_OBJECT");
                }
            }
        }
        private SearchEntity _SearchEntityObject;
        public SearchEntity SearchEntityObject
        {
            get
            {
                return _SearchEntityObject;
            }
            set
            {
                if (_SearchEntityObject != value)
                {
                    _SearchEntityObject = value;
                    RaisePropertyChanged(nameof(SearchEntityObject));
                }
            }
        }

        #region Temp Variables

        private ICollectionView _dataGridview;
        public ICollectionView DataGridView
        {
            get { return _dataGridview; }
            set { _dataGridview = value; RaisePropertyChanged("DataGridView"); }
        }

        private ICollectionView _iCollectionViewTax;
        public ICollectionView ICollectionViewTax
        {
            get { return _iCollectionViewTax; }
            set { _iCollectionViewTax = value; RaisePropertyChanged("ICollectionViewTax"); }
        }

        private ICollectionView _dataGridviewFilter;
        // This DataGridView filter Schedule Lines for selected item. it will show only schedule for selected item.
        public ICollectionView DataGridViewFilter
        {
            get { return _dataGridviewFilter; }
            set { _dataGridviewFilter = value; RaisePropertyChanged("DataGridViewFilter"); }
        }

        #endregion

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
                    FilterLicenceDataGrid();
                    if (TotalDocumentTaxesItem.Count > 0 && ItemEntityObject != null)
                    {
                        TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>(TotalDocumentTaxes.Where(tax => tax.ItemCode == ItemEntityObject.ItemCode && (tax.sku?.ToString() ?? "") == (ItemEntityObject.sku?.ToString() ?? "") && tax.item_row_id == ItemEntityObject.id));
                    }
                    if (_dgSelectedIndexItem >= 0 && _dgSelectedIndexItem < dgItemsEntity.Count && ItemEntityObject != null)
                    {
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).doc_no);
                        TheFilter = (o, prefix) => (((STD_LIST_BE)o).doc_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) && (((STD_LIST_BE)o).item_code ?? "").ToString().ToLower().Contains(ItemEntityObject.ItemCode ?? "".ToLower()) && (((STD_LIST_BE)o).sku ?? "").ToString().ToLower().Contains(ItemEntityObject.sku ?? "".ToLower());
                        ASReqNo = new AutoSuggestTextViewModel<dynamic>(MC.PR_LIST, TheFilter, SuggestedValue, "po_req_no", "doc_no", true);
                        ASReqNo.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASReqNo.AutoSuggestVM.IsFreeTextAllowed = false;
                    }
                }
            }
        }
        private int _dgSelectedIndexComponant;
        public int dgSelectedIndexComponant
        {
            get
            {
                return _dgSelectedIndexComponant;
            }
            set
            {
                if (_dgSelectedIndexComponant != value)
                {
                    _dgSelectedIndexComponant = value;
                    RaisePropertyChanged("dgSelectedIndexComponant");
                    FilterComponantDataGrid();
                }
            }
        }

        //selected Index For Terms and condition
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

        // Selected Index for Items DataGrid 
        private int _dgSelectedIndexItemSchedule;
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

        private int _TaxDataGridSelectedIndex;
        public int TaxDataGridSelectedIndex
        {
            get
            {
                return _TaxDataGridSelectedIndex;
            }
            set
            {
                if (_TaxDataGridSelectedIndex != value)
                {

                    _TaxDataGridSelectedIndex = value;
                    RaisePropertyChanged("TaxDataGridSelectedIndex");
                }
            }
        }


        //Pending Assignment of dgSelectedIndex
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
                }
            }
        }
        private int _dgSelectedIndexTaxSummury;

        //Assignment : Tax Summury Display DataGrid
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
                    FilterTaxDataGrid();
                }
            }
        }

        private List<PUR_T002_AFlip> _FlipGridData;
        public List<PUR_T002_AFlip> FlipGridData
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

        // Pending Assignment of SelectedTaxList
        private List<ACC_M013_P> _SelectedTaxList;
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

        // Pending assignment
        private List<ACC_M013_PopUp> _SelectedChildTaxList;
        public List<ACC_M013_PopUp> SelectedChildTaxList
        {
            get { return _SelectedChildTaxList; }
            set
            {
                if (_SelectedChildTaxList != value)
                {
                    _SelectedChildTaxList = value;

                    //if (PropertyChanged != null)
                    //{
                    RaisePropertyChanged("SelectedChildTaxList");
                    //}
                }
            }
        }


        private List<ADM_M002> _CompanyList = new List<ADM_M002>();
        public List<ADM_M002> CompanyList
        {
            get { return _CompanyList; }
            set
            {
                if (_CompanyList != value)
                {
                    _CompanyList = value;
                }
            }
        }



        //Pending Assignment of dgSelectedIndex
        private string _LocalVariable;
        public string LocalVariable
        {
            get
            {
                return _LocalVariable;
            }
            set
            {
                if (_LocalVariable != value)
                {

                    _LocalVariable = value;
                    RaisePropertyChanged("LocalVariable");
                }
            }
        }
        //Pending Assignment of dgSelectedIndex
        private bool _ErrorValue;
        public bool ErrorValue
        {
            get
            {
                return _ErrorValue;
            }
            set
            {
                if (_ErrorValue != value)
                {

                    _ErrorValue = value;
                    this.ErrorExist = _ErrorValue;
                    RaisePropertyChanged("ErrorValue");
                }
            }
        }

        #endregion
        #region ICollection
        private ICollectionView _ReferenceDocINCollection;
        public ICollectionView ReferenceDocINCollection
        {
            get { return _ReferenceDocINCollection; }
            set { _ReferenceDocINCollection = value; RaisePropertyChanged("ReferenceDocINCollection"); }
        }
        private ICollectionView _ReferenceDocRQCollection;
        public ICollectionView ReferenceDocRQCollection
        {
            get { return _ReferenceDocRQCollection; }
            set { _ReferenceDocRQCollection = value; RaisePropertyChanged("ReferenceDocRQCollection"); }
        }
        private ICollectionView _ReferenceDocQPCollection;
        public ICollectionView ReferenceDocQPCollection
        {
            get { return _ReferenceDocQPCollection; }
            set { _ReferenceDocQPCollection = value; RaisePropertyChanged("ReferenceDocQPCollection"); }
        }
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
        private ICollectionView _FormTypeCollection;
        public ICollectionView FormTypeCollection
        {
            get { return _FormTypeCollection; }
            set { _FormTypeCollection = value; RaisePropertyChanged("FormTypeCollection"); }
        }

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private ICollectionView _ContactPersonCollection;
        public ICollectionView ContactPersonCollection
        {
            get { return _ContactPersonCollection; }
            set { _ContactPersonCollection = value; RaisePropertyChanged("ContactPersonCollection"); }
        }

        private ICollectionView _PR_ITEM_COLL;
        public ICollectionView PR_ITEM_COLL // This is for all PR items and from Item master items also who have pr_required indicator is set to false.
        {
            get { return _PR_ITEM_COLL; }
            set { _PR_ITEM_COLL = value; RaisePropertyChanged("PR_ITEM_COLL"); }
        }
        private ICollectionView _PR_ITEM_COLL_SORTED;
        public ICollectionView PR_ITEM_COLL_SORTED // This is for item colletion only from PR
        {
            get { return _PR_ITEM_COLL_SORTED; }
            set { _PR_ITEM_COLL_SORTED = value; RaisePropertyChanged("PR_ITEM_COLL_SORTED"); }
        }
        private ICollectionView _PARTY_ITEM_COLL;
        public ICollectionView PARTY_ITEM_COLL
        {
            get { return _PARTY_ITEM_COLL; }
            set { _PARTY_ITEM_COLL = value; RaisePropertyChanged("PARTY_ITEM_COLL"); }
        }
        private ICollectionView _ItemsCollection;
        public ICollectionView ItemsCollection // User for STO Item reference.
        {
            get { return _ItemsCollection; }
            set { _ItemsCollection = value; RaisePropertyChanged("ItemsCollection"); }
        }
        private ICollectionView _ComponantCollection;
        public ICollectionView ComponantCollection
        {
            get { return _ComponantCollection; }
            set { _ComponantCollection = value; RaisePropertyChanged("ComponantCollection"); }
        }
        private ICollectionView _partyCollection;
        public ICollectionView PartyCollection
        {
            get { return _partyCollection; }
            set { _partyCollection = value; RaisePropertyChanged("PartyCollection"); }
        }
        private ICollectionView _uomCollection;
        public ICollectionView UomCollection
        {
            get { return _uomCollection; }
            set { _uomCollection = value; RaisePropertyChanged("UomCollection"); }
        }
        private ICollectionView _buyerCollection;
        public ICollectionView BuyerCollection
        {
            get { return _buyerCollection; }
            set { _buyerCollection = value; RaisePropertyChanged("BuyerCollection"); }
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
        private ICollectionView _paytermCollection;
        public ICollectionView PayTermCollection
        {
            get { return _paytermCollection; }
            set { _paytermCollection = value; RaisePropertyChanged("PayTermCollection"); }
        }
        private ICollectionView _warehouseCollection;
        public ICollectionView warehouseCollection
        {
            get { return _warehouseCollection; }
            set { _warehouseCollection = value; RaisePropertyChanged("warehouseCollection"); }
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
        private ICollectionView _currencyCollection;
        public ICollectionView currencyCollection
        {
            get { return _currencyCollection; }
            set
            {
                _currencyCollection = value;
                RaisePropertyChanged("currencyCollection");
            }
        }
        private ICollectionView _po_orgCollection;
        public ICollectionView po_orgCollection
        {
            get { return _po_orgCollection; }
            set
            {
                _po_orgCollection = value;
                RaisePropertyChanged("po_orgCollection");
            }
        }
        private ICollectionView _pur_groupCollection;
        public ICollectionView Purchase_groupCollection
        {
            get { return _pur_groupCollection; }
            set
            {
                _pur_groupCollection = value;
                RaisePropertyChanged("Purchase_groupCollection");
            }
        }
        private ICollectionView _storage_locCollection;
        public ICollectionView storage_locCollection
        {
            get { return _storage_locCollection; }
            set
            {
                _storage_locCollection = value;
                RaisePropertyChanged("storage_locCollection");
            }
        }
        private ICollectionView _cost_centerCollection;
        public ICollectionView cost_centerCollection
        {
            get { return _cost_centerCollection; }
            set
            {
                _cost_centerCollection = value;
                RaisePropertyChanged("cost_centerCollection");
            }
        }
        private ICollectionView _billAddrCollection;
        public ICollectionView BilAdderCollection
        {
            get { return _billAddrCollection; }
            set { _billAddrCollection = value; RaisePropertyChanged("BilAdderCollection"); }
        }
        private ICollectionView _delAddrCollection;
        public ICollectionView DelAddrCollection
        {
            get { return _delAddrCollection; }
            set { _delAddrCollection = value; RaisePropertyChanged("DelAddrCollection"); }
        }
        private ICollectionView _itemcategoryCollection;
        public ICollectionView itemcategoryCollection
        {
            get { return _itemcategoryCollection; }
            set
            {
                _itemcategoryCollection = value;
                RaisePropertyChanged("itemcategoryCollection");
            }
        }
        private ICollectionView _validatedByCollection;
        public ICollectionView validatedByCollection
        {
            get { return _validatedByCollection; }
            set { _validatedByCollection = value; RaisePropertyChanged("validatedByCollection"); }
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

        private ICollectionView _ReferenceDocCollection;
        public ICollectionView ReferenceDocCollection
        {
            get { return _ReferenceDocCollection; }
            set { _ReferenceDocCollection = value; RaisePropertyChanged("ReferenceDocCollection"); }
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
        // Pending assignment of ItemCollection
        private ICollectionView _itemCollection;
        public ICollectionView ItemCollection
        {
            get { return _itemCollection; }
            set { _itemCollection = value; RaisePropertyChanged("ItemCollection"); }
        }
        //Terms and condition Collection
        private ICollectionView _TermsConditionCollection;
        public ICollectionView TermsConditionCollection
        {
            get { return _TermsConditionCollection; }
            set { _TermsConditionCollection = value; RaisePropertyChanged("TermsConditionCollection"); }
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
        #endregion
        #region StringList Variables

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

        private List<string> _strListFormType;
        public List<string> StringListFormtype
        {
            get { return _strListFormType; }
            set
            {
                if (_strListFormType != value)
                {
                    _strListFormType = value;
                }
            }
        }
        List<string> _srtValue;
        public List<string> StringListValue
        {
            get { return _srtValue; }
            set
            {
                if (_srtValue != value)
                {
                    _srtValue = value;
                }
            }
        }
        List<string> _StrListContactPerson;
        public List<string> StringListContactPerson
        {
            get { return _StrListContactPerson; }
            set
            {
                if (_StrListContactPerson != value)
                {
                    _StrListContactPerson = value;
                }
            }
        }

        private List<string> _strListRequisition;
        public List<string> strListRequisition
        {
            get { return _strListRequisition; }
            set
            {
                if (_strListRequisition != value)
                {
                    _strListRequisition = value;
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

        List<string> _strListDocType;
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

        List<string> _strListBuyer;
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

        List<string> _strListCurrency;
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

        List<string> _strListPayTerms;
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

        List<string> _strListPurchaseOrg;
        public List<string> StringListPurchaseOrg
        {
            get { return _strListPurchaseOrg; }
            set
            {
                if (_strListPurchaseOrg != value)
                {
                    _strListPurchaseOrg = value;
                }
            }
        }

        List<string> _strListPurchaseGroup;
        public List<string> StringListPurchaseGroup
        {
            get { return _strListPurchaseGroup; }
            set
            {
                if (_strListPurchaseGroup != value)
                {
                    _strListPurchaseGroup = value;
                }
            }
        }

        List<string> _strListPurchaseWearhouse;
        public List<string> StringListPurchaseWearhouse
        {
            get { return _strListPurchaseWearhouse; }
            set
            {
                if (_strListPurchaseWearhouse != value)
                {
                    _strListPurchaseWearhouse = value;
                }
            }
        }

        List<string> _strListPurchaseStorageLocation;
        public List<string> StringListPurchaseStorageLocation
        {
            get { return _strListPurchaseStorageLocation; }
            set
            {
                if (_strListPurchaseStorageLocation != value)
                {
                    _strListPurchaseStorageLocation = value;
                }
            }
        }

        List<string> _strListDeliveryAddress;
        public List<string> StringListDeliveryAddress
        {
            get { return _strListDeliveryAddress; }
            set
            {
                if (_strListDeliveryAddress != value)
                {
                    _strListDeliveryAddress = value;
                }
            }
        }

        List<string> _strListBillingAddress;
        public List<string> StringListBillingAddress
        {
            get { return _strListBillingAddress; }
            set
            {
                if (_strListBillingAddress != value)
                {
                    _strListBillingAddress = value;
                }
            }
        }

        List<string> _strListCostCenter;
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

        List<string> _stringListItems;
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

        List<string> _stringListUOM;
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

        List<string> _stringListItemCategory;
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
        private List<PUR_T002_P_RefeDoc> _refdoctempa;
        public List<PUR_T002_P_RefeDoc> refdoctempa
        {
            get { return _refdoctempa; }
            set
            {
                if (_refdoctempa != value)
                {
                    _refdoctempa = value;
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
        #endregion
        #region Relay Commands Declaration
        public RelayCommand<object> cmdSelectRefBulk { get; private set; }
        public RelayCommand<object> cmdExecuteRFQ { get; private set; }
        public RelayCommand<object> cmdInsertQty { get; private set; }
        //public RelayCommand<object> cmdInsertCompany { get; private set; }
        //public RelayCommand<object> cmdInsertPlant { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_PUR_T002_H { get; private set; }
        public RelayCommand<object> cmdSelectionChangedSchedule { get; private set; }
        public RelayCommand<object> cmdSelectionChangedComponant { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdContactPerson { get; private set; }
        public RelayCommand<object> cmdrequisition { get; private set; }
        public RelayCommand<Boolean> CommandActiveInactiveCheck { get; private set; }
        public RelayCommand<object> SelectionChangedCommandParty { get; private set; }
        public RelayCommand<object> SelectionChangedCommandDocType { get; private set; }
        public RelayCommand<object> SelectionChangedCommandBuyer { get; private set; }
        public RelayCommand<object> SelectionChangedCommandValidator { get; private set; }
        public RelayCommand<object> SelectionChangedCommandCurrency { get; private set; }
        public RelayCommand<object> SelectionChangedCommandPayTerms { get; private set; }
        public RelayCommand<object> SelectionChangedCommandPurchaseOrg { get; private set; }
        public RelayCommand<object> SelectionChangedCommandPurchaseGroup { get; private set; }
        public RelayCommand<object> SelectionChangedCommandWearhouse { get; private set; }
        public RelayCommand<object> SelectionChangedCommandStorageLocation { get; private set; }
        public RelayCommand<object> SelectionChangedCommandDeliveryAddress { get; private set; }
        public RelayCommand<object> SelectionChangedCommandBillingAddress { get; private set; }
        public RelayCommand<object> SelectionChangedCommandCostCenter { get; private set; }
        public RelayCommand<object> SelectionChangedReferenceDocumentType { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByRefDocNumber { get; private set; }
        public RelayCommand<object> CommandCreateDocumentByReferenceDocuments { get; private set; }
        public RelayCommand<object> cmdInsertItems { get; private set; } // for STO
        //DataGrid Record addtion commands 
        public RelayCommand<object> CommandAddItem { get; private set; }
        public RelayCommand<object> cmdAddComponant { get; private set; }
        public RelayCommand<object> CommandAddUOM { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CommandAddItemCategory { get; private set; }
        public RelayCommand<object> CommandDeleteScheduleItem { get; private set; }
        public RelayCommand<object> CommandAddSelectedTax { get; private set; }
        public RelayCommand<object> cmdDeleteTax { get; private set; }
        public RelayCommand<object> ManualTaxChangedCommand { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridTerms { get; private set; }
        public RelayCommand<object> CommandTerms { get; private set; }
        public RelayCommand<object> CommandMailDocuments { get; private set; }
        public RelayCommand<object> CommandIncoterms { get; private set; }
        public RelayCommand<object> CommandLicenseAdvance { get; private set; }
        public RelayCommand<object> CommandLicenseEPCG { get; private set; }
        public RelayCommand<object> CmdLicence { get; private set; }
        public RelayCommand<object> CmddgIncoterms { get; private set; }
        public RelayCommand<object> cmdBussPlace { get; private set; }
        public RelayCommand<object> cmddgBussPlace { get; private set; }
        public RelayCommand<object> CmddgShipToParty { get; private set; }
        public RelayCommand<object> CmdCondType { get; private set; }
        public RelayCommand<object> CmddgCurrency { get; private set; }
        public RelayCommand<object> cmdOpenAttachments { get; private set; }
        public RelayCommand<object> CmdItemInfo { get; private set; }
        public RelayCommand<object> CmdAddSelectedRef { get; private set; }
        public RelayCommand<object> CmdInsert_t_status { get; private set; }
        public RelayCommand<object> CommandLoadBackFlipData { get; private set; }
        public RelayCommand<object> cmdSupplingPlant { get; private set; }
        public RelayCommand<object> cmdReceivingPlant { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_PUR_T002_B { get; private set; }
        public RelayCommand<object> cmdExplodeBOM { get; private set; }
        public RelayCommand<object> cmdTR_Mode { get; private set; }
        public RelayCommand<object> cmdInsertTermsConditions { get; private set; }
        #endregion
        #region Constructor
        //private static PRO_T005_VM Expose_ViewModel;
        //public static PRO_T005_VM SharedViewModel()
        //{
        //    return Expose_ViewModel ?? (Expose_ViewModel = new PRO_T005_VM(null, null));
        //}
        public PRO_T005_VM(string doc_cat, string ts_code) : base()
        {
            CursorControl.SetBusyState();
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            SearchEntityObject = new SearchEntity();
            MasterEntityTemp = new PUR_T002_A(); // pending assignment
            MasterEntity = new PUR_T002_A();
            TCEntityObject = new GEN_T011();
            SalesUnitPriceCollection = new List<GetItemDetailsEntity>();
            SalesQFRCollection = new List<GetItemDetailsEntity>();
            SalesDispatchCollection = new List<GetItemDetailsEntity>();
            SalesProjDispatchCollection = new List<GetItemDetailsEntity>();
            ApprovalData = new List<ADM_M043_D>();
            LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
            dgItemsEntity = new ObservableCollection<PUR_T002_B>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
            TermsConditionEntity = new ObservableCollection<GEN_T011>();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
            dgTotalTaxSummury = new ObservableCollection<PUR_T002_C>();
            ScheduleEntity = new PUR_T004_A();
            dgItemScheduleEntity = new ObservableCollection<PUR_T004_B>();
            dgComponantEntity = new ObservableCollection<PUR_T002_C>();
            FlipGridData = new List<PUR_T002_AFlip>();
            MC = new MultipleContext_PUR_T002_A();
            MCTemp = new MultipleContext_PUR_T002_A();
            MCTemp_Report = new MultipleContext_PUR_T002_A();
            NotificationDataCollection = new List<NotificationData>();
            PUR_T002_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            PUR_T002_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            PUR_T004_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Schedule);
            PUR_T004_B.ModelEntityUpdated += new EventHandler(ModelUpdatedShedule);
            ACC_T006_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Tax);
            dgItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            dgItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
            dgComponantEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForComponant);
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            NewRecord = true;
            CommandInitialization();

        }
        public PRO_T005_VM(string doc_cat, string ts_code, string doc_no) : base()
        {
            CursorControl.SetBusyState();
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            SearchEntityObject = new SearchEntity();
            MasterEntityTemp = new PUR_T002_A(); // pending assignment
            MasterEntity = new PUR_T002_A();
            TCEntityObject = new GEN_T011();
            SalesUnitPriceCollection = new List<GetItemDetailsEntity>();
            SalesQFRCollection = new List<GetItemDetailsEntity>();
            SalesDispatchCollection = new List<GetItemDetailsEntity>();
            SalesProjDispatchCollection = new List<GetItemDetailsEntity>();
            ApprovalData = new List<ADM_M043_D>();
            LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
            dgItemsEntity = new ObservableCollection<PUR_T002_B>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
            TermsConditionEntity = new ObservableCollection<GEN_T011>();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
            dgTotalTaxSummury = new ObservableCollection<PUR_T002_C>();
            ScheduleEntity = new PUR_T004_A();
            dgItemScheduleEntity = new ObservableCollection<PUR_T004_B>();
            dgComponantEntity = new ObservableCollection<PUR_T002_C>();
            FlipGridData = new List<PUR_T002_AFlip>();
            MC = new MultipleContext_PUR_T002_A();
            MCTemp = new MultipleContext_PUR_T002_A();
            MCTemp_Report = new MultipleContext_PUR_T002_A();
            NotificationDataCollection = new List<NotificationData>();
            PUR_T002_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            PUR_T002_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            PUR_T004_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Schedule);
            PUR_T004_B.ModelEntityUpdated += new EventHandler(ModelUpdatedShedule);
            ACC_T006_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Tax);
            dgItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            dgItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
            dgComponantEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForComponant);
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            NewRecord = true;
            CommandInitialization();
        }

        public PRO_T005_VM(string ts_code, STD_LIST_BE REF_OBJ) : base()
        {
            CursorControl.SetBusyState();
            this.doc_cat_vm = REF_OBJ.doc_cat;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = REF_OBJ.doc_no;
            STD_OBJECT = new STD_LIST_BE();
            STD_OBJECT = REF_OBJ;

            SearchEntityObject = new SearchEntity();
            MasterEntityTemp = new PUR_T002_A(); // pending assignment
            MasterEntity = new PUR_T002_A();
            TCEntityObject = new GEN_T011();
            SalesUnitPriceCollection = new List<GetItemDetailsEntity>();
            SalesQFRCollection = new List<GetItemDetailsEntity>();
            SalesDispatchCollection = new List<GetItemDetailsEntity>();
            SalesProjDispatchCollection = new List<GetItemDetailsEntity>();
            ApprovalData = new List<ADM_M043_D>();
            LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
            dgItemsEntity = new ObservableCollection<PUR_T002_B>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
            TermsConditionEntity = new ObservableCollection<GEN_T011>();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
            dgTotalTaxSummury = new ObservableCollection<PUR_T002_C>();
            ScheduleEntity = new PUR_T004_A();
            dgItemScheduleEntity = new ObservableCollection<PUR_T004_B>();
            dgComponantEntity = new ObservableCollection<PUR_T002_C>();
            FlipGridData = new List<PUR_T002_AFlip>();
            MC = new MultipleContext_PUR_T002_A();
            MCTemp = new MultipleContext_PUR_T002_A();
            MCTemp_Report = new MultipleContext_PUR_T002_A();
            NotificationDataCollection = new List<NotificationData>();
            PUR_T002_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            PUR_T002_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            PUR_T004_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Schedule);
            PUR_T004_B.ModelEntityUpdated += new EventHandler(ModelUpdatedShedule);
            ACC_T006_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Tax);
            dgItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            dgItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
            dgComponantEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForComponant);
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            NewRecord = true;
            CommandInitialization();
        }
        private void LoadInitialData(string doc_cat_info, string ReferenceDoc)
        {
            CursorControl.SetBusyState();
            try
            {
                NewRecord = true;
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_info + "!@" + doc_cat_info + "!@" + (MasterEntity.po_no ?? "") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + (MasterEntity.po_code ?? AppSessionState.po_code) + "!@" + ((MasterEntity.pg_code ?? AppSessionState.pg_code) ?? "");
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MC, Request, "PRO_T002_BL", "PRO", "LoadAll", 0, "");


                var title_data = (from o in MC.PARAMETERS_VALUES_LIST where o.para_code == "P003" select o);
                TITLE_COLLECTION = title_data;

                #region Autosuggest

                //New PopUP - Supplier
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSupplier = new AutoSuggestTextViewModel<dynamic>(MC.partyList, TheFilter, SuggestedValue, "PartyId", true);
                ASSupplier.AutoSuggestVM.IsEmptyValueAllowed = true; ASSupplier.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_REC_PLANT = new AutoSuggestTextViewModel<dynamic>(MC.partyList, TheFilter, SuggestedValue, "rec_plant", true);
                AS_REC_PLANT.AutoSuggestVM.IsEmptyValueAllowed = true; AS_REC_PLANT.AutoSuggestVM.IsFreeTextAllowed = false;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                //TheFilter = (o, prefix) => ((ADM_M003)o).location_Id.ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //AS_SUP_PLANT = new AutoSuggestTextViewModel<dynamic>((List<ADM_M003>)AppSessionState.ADM_M003_List, TheFilter, SuggestedValue, "location_Id", true);
                //AS_SUP_PLANT.AutoSuggestVM.IsEmptyValueAllowed = true;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                //TheFilter = (o, prefix) => ((ADM_M003)o).location_Id.ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //AS_REC_PLANT = new AutoSuggestTextViewModel<dynamic>((List<ADM_M003>)AppSessionState.ADM_M003_List, TheFilter, SuggestedValue, "location_Id", true);
                //AS_REC_PLANT.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M037)x).ind_trade);
                TheFilter = (o, prefix) => (((SYS_M037)o).ind_trade ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M037)o).trade_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTradeIndicator = new AutoSuggestTextViewModel<dynamic>(MC.Trade_Types, TheFilter, SuggestedValue, "ind_trade", true);
                ASTradeIndicator.AutoSuggestVM.IsEmptyValueAllowed = false;
                ASTradeIndicator.AutoSuggestVM.IsFreeTextAllowed = false;



                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyNm);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AutoSuggestTextViewModel = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyNm", true);
                AutoSuggestTextViewModel.AutoSuggestVM.IsEmptyValueAllowed = true;
                AutoSuggestTextViewModel.AutoSuggestVM.IsFreeTextAllowed = true;

                //New PopUP - Incoterms
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M044_P)x).incoterms);
                TheFilter = (o, prefix) => (((ADM_M044_P)o).incoterms ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M044_P)o).inco_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASIncoTerms = new AutoSuggestTextViewModel<dynamic>(MC.Incoterms, TheFilter, SuggestedValue, "incoterms", true);
                ASIncoTerms.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - EPCG licence
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M041_P)x).lic_cod);
                TheFilter = (o, prefix) => (((ADM_M041_P)o).lic_cod ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASEPCG = new AutoSuggestTextViewModel<dynamic>(MC.LicenseEPCG, TheFilter, SuggestedValue, "lic_cod", true);
                ASEPCG.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Advance Licence
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M041_P)x).lic_cod);
                TheFilter = (o, prefix) => (((ADM_M041_P)o).lic_cod ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASAdvance = new AutoSuggestTextViewModel<dynamic>(MC.LicenseAdvance, TheFilter, SuggestedValue, "lic_cod", true);
                ASAdvance.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New Reference Popup Loading
                var refdoc = (from o in MC.reference_docList where o.doc_cat == "IN" select o).ToList();
                ReferenceDocINCollection = CollectionViewSource.GetDefaultView(refdoc);
                ReferenceDocINCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                refdoc = (from o in MC.reference_docList where o.doc_cat == "QP" select o).ToList();
                ReferenceDocQPCollection = CollectionViewSource.GetDefaultView(refdoc);
                ReferenceDocQPCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                PR_ITEM_COLL = CollectionViewSource.GetDefaultView(MC.PR_LIST);
                PR_ITEM_COLL.Filter = new Predicate<object>(FilterRequisitionNo);

                PR_ITEM_COLL_SORTED = CollectionViewSource.GetDefaultView(MC.PR_LIST.Where(x=> x.id != null));
                PR_ITEM_COLL_SORTED.Filter = new Predicate<object>(FilterRequisitionNo);

                //PARTY_ITEM_COLL = CollectionViewSource.GetDefaultView(MC.partyList);
                //PARTY_ITEM_COLL.Filter = new Predicate<object>(FilterParty);

                ItemsCollection = CollectionViewSource.GetDefaultView(MC.ItemListForPopup);
                ItemsCollection.Filter = new Predicate<object>(FilterReferenceItems);


                //New PopUP - OrderType
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_DOC_TYPE)x).doc_type);
                TheFilter = (o, prefix) => (((STD_DOC_TYPE)o).doc_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((STD_DOC_TYPE)o).doc_type_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASOrderType = new AutoSuggestTextViewModel<dynamic>(MC.DOC_TYPE_LIST, TheFilter, SuggestedValue, "doc_type", true);
                ASOrderType.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - ValidatedBy
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M024_P)o).EmpLName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASValidatedBy = new AutoSuggestTextViewModel<dynamic>(MC.BuyerList, TheFilter, SuggestedValue, "EmpId", false);
                ASValidatedBy.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Buyer
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M024_P)o).EmpLName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASBuyer = new AutoSuggestTextViewModel<dynamic>(MC.BuyerList, TheFilter, SuggestedValue, "EmpId", false);
                ASBuyer.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Delivery Address
                List<ADM_M003> AddressList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDelAddress = new AutoSuggestTextViewModel<dynamic>(AddressList, TheFilter, SuggestedValue, "location_Id", true);

                //New PopUP - Billing Address

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASBillAddress = new AutoSuggestTextViewModel<dynamic>(AddressList, TheFilter, SuggestedValue, "location_Id", true);
                ASBillAddress.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(MC.LOCATION_LIST, TheFilter, SuggestedValue, "location_Id", true);
                AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = false;

                if (AS_COMPANY == null)
                {
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                    TheFilter = (o, prefix) => (((ADM_M0002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                               (((ADM_M0002)o).comp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", true);
                    AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = false;
                }

                //New PopUP - Currency
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M037)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCurrency = new AutoSuggestTextViewModel<dynamic>(MC.CURRENCY_LIST, TheFilter, SuggestedValue, "curr_code", true);
                ASCurrency.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Payment Term
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M007_P)x).p_term_code);
                TheFilter = (o, prefix) => (((ACC_M007_P)o).p_term_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ACC_M007_P)o).p_term ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPaymentTerm = new AutoSuggestTextViewModel<dynamic>(MC.PayTerms, TheFilter, SuggestedValue, "p_term_code", true);
                ASPaymentTerm.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Tax
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M013_P)x).id.ToString());
                TheFilter = (o, prefix) => ((ACC_M013_P)o).id.ToString().ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ACC_M013_P)o).description ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTax = new AutoSuggestTextViewModel<dynamic>(MC.TaxList, TheFilter, SuggestedValue, "id", true);
                ASTax.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - As default
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T002_P_PR_ItemsList)x).ItemCode);
                TheFilter = (o, prefix) => (((PUR_T002_P_PR_ItemsList)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((PUR_T002_P_PR_ItemsList)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.ItemListForPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                //New PopUP - Unit
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASUnit = new AutoSuggestTextViewModel<dynamic>(MC.unitList, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASUnit.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASUnit.AutoSuggestVM.IsFreeTextAllowed = true;

                //New PopUP - Item Category
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M008_P)x).item_cat);
                TheFilter = (o, prefix) => (((SYS_M008_P)o).item_cat ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASItemCategory = new AutoSuggestTextViewModel<dynamic>(MC.itemcatList, TheFilter, SuggestedValue, "item_cat", "item_cat", true);
                ASItemCategory.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASItemCategory.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_P)o).gl_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault1 = new AutoSuggestTextViewModel<dynamic>(MC.AccountList, TheFilter, SuggestedValue, "gl_code", "gl_code", true);
                ASDefault1.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault1.AutoSuggestVM.IsFreeTextAllowed = true;

                //New PopUP - Tax Account
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_P)o).gl_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTaxacc = new AutoSuggestTextViewModel<dynamic>(MC.AccountList, TheFilter, SuggestedValue, "gl_code", "gl_code", true);
                ASTaxacc.AutoSuggestVM.IsEmptyValueAllowed = true;


                //New PopUP - Purchase Organization
                PurchaseOrganisationList = (List<ADM_M001_M_P>)AppSessionState.ADM_M001_M_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_M_P)x).po_code);
                TheFilter = (o, prefix) => (((ADM_M001_M_P)o).po_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M001_M_P)o).pur_org ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPurOrg = new AutoSuggestTextViewModel<dynamic>(PurchaseOrganisationList, TheFilter, SuggestedValue, "po_code", true);
                ASPurOrg.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASPurOrg.AutoSuggestVM.IsFreeTextAllowed = false;

                //New PopUP - Purchase Group
                PurchaseGroupList = (List<ADM_M001_P_P>)AppSessionState.ADM_M001_P_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_P_P)x).pg_code);
                TheFilter = (o, prefix) => (((ADM_M001_P_P)o).pg_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M001_P_P)o).pg_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPurGrp = new AutoSuggestTextViewModel<dynamic>(PurchaseGroupList, TheFilter, SuggestedValue, "pg_code", true);
                ASPurGrp.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Destination WareHouse
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M002_P)x).wa_code.ToString());
                TheFilter = (o, prefix) => (((MM_M002_P)o).wa_code ?? "").ToString().ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((MM_M002_P)o).wa_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDestWar = new AutoSuggestTextViewModel<dynamic>(MC.WarehouseList, TheFilter, SuggestedValue, "wa_code", true);
                ASDestWar.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Storage Location
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M001_P)x).store_code.ToString());
                TheFilter = (o, prefix) => (((MM_M001_P)o).store_code ?? "").ToString().ToString().ToLower().Contains(prefix.ToLower());
                // || ((MM_M001_P)o).wa_name.ToString().ToLower().Contains(prefix);
                ASStorLoc = new AutoSuggestTextViewModel<dynamic>(MC.storage_locList, TheFilter, SuggestedValue, "store_code", true);
                ASStorLoc.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Cost Centre
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M019_P)x).cost_center.ToString());
                TheFilter = (o, prefix) => (((ACC_M019_P)o).cost_center ?? "").ToString().ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ACC_M019_P)o).cost_center_Desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCostCentre = new AutoSuggestTextViewModel<dynamic>(MC.cost_centerList, TheFilter, SuggestedValue, "cost_center", true);
                ASCostCentre.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Journal
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M005_P)x).j_code.ToString());
                TheFilter = (o, prefix) => (((ACC_M005_P)o).j_code ?? "").ToString().ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ACC_M005_P)o).j_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASJournal = new AutoSuggestTextViewModel<dynamic>(MC.journalList, TheFilter, SuggestedValue, "j_code", true);
                ASJournal.AutoSuggestVM.IsEmptyValueAllowed = true;

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
                ASdgShipToParty = new AutoSuggestTextViewModel<dynamic>(MC.partyList, TheFilter, SuggestedValue, "ship_to_Party", "PartyId", true);
                ASdgShipToParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_O_P)x).con_type);
                TheFilter = (o, prefix) => (((ACC_M003_O_P)o).con_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_O_P)o).con_desc ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_O_P)o).con_cat ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_O_P)o).pricing_pro ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASConditionType = new AutoSuggestTextViewModel<dynamic>(MC.ConditionTypeList, TheFilter, SuggestedValue, "con_type", "con_type", false);
                ASConditionType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M037)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASdgCurrency = new AutoSuggestTextViewModel<dynamic>(MC.CURRENCY_LIST, TheFilter, SuggestedValue, "curr_code", "curr_code", true);
                ASdgCurrency.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0051)x).con_type);
                TheFilter = (o, prefix) => (((ADM_M0051)o).con_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0051)o).long_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault2 = new AutoSuggestTextViewModel<dynamic>(MC.CONDITION_LIST, TheFilter, SuggestedValue, "tc_code", "tc_code", true);
                ASDefault2.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault2.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0051)x).con_type);
                TheFilter = (o, prefix) => (((ADM_M0051)o).con_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0051)o).long_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTermsCond = new AutoSuggestTextViewModel<dynamic>(MC.CONDITION_LIST, TheFilter, SuggestedValue, "tc_code", "tc_code", true);
                ASTermsCond.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASt_status = new AutoSuggestTextViewModel<dynamic>(MC.t_statusList, TheFilter, SuggestedValue, "t_display", true);
                ASt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M026)x).tr_mode);
                TheFilter = (o, prefix) => (((SYS_M026)o).tr_mode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M026)o).tr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTR_MODE = new AutoSuggestTextViewModel<dynamic>(MC.TransportMode, TheFilter, SuggestedValue, "tr_mode", true);
                ASTR_MODE.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASTR_MODE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002_B)x).CatCode);
                TheFilter = (o, prefix) => (((ADM_M002_B)o).CatCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M002_B)o).cat_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASScope = new AutoSuggestTextViewModel<dynamic>(MC.ScopeList, TheFilter, SuggestedValue, "CatCode", true);
                ASScope.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASScope.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0051)x).tc_code);
                TheFilter = (o, prefix) => (((ADM_M0051)o).tc_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0051)o).con_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0051)o).long_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_TERMS_CONDITION = new AutoSuggestTextViewModel<dynamic>(MC.CONDITION_LIST, TheFilter, SuggestedValue, "tc_code", "tc_code", true);
                AS_TERMS_CONDITION.AutoSuggestVM.IsEmptyValueAllowed = true;
                #endregion

                ItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListForPopup);
                ItemCollection.Filter = new Predicate<object>(FilterItem);

                UnitConversionList = MC.UnitConversion;

                PartyCollection = CollectionViewSource.GetDefaultView(MC.partyList);
                PartyCollection.Filter = new Predicate<object>(FilterParty);
                StringListValue = MC.partyList.Select(x => x.PartyId).ToList();

                UomCollection = CollectionViewSource.GetDefaultView(MC.unitList.ToList());
                UomCollection.Filter = new Predicate<object>(FilterUom);
                StringListUOM = MC.unitList.Select(x => x.unit_code).ToList();

                BuyerCollection = CollectionViewSource.GetDefaultView(MC.BuyerList.ToList());
                BuyerCollection.Filter = new Predicate<object>(FilterBuyer);
                StringListBuyer = MC.BuyerList.Select(x => x.EmpId).ToList();

                journalCollection = CollectionViewSource.GetDefaultView(MC.journalList);
                journalCollection.Filter = new Predicate<object>(journal_Filter);

                PayTermCollection = CollectionViewSource.GetDefaultView(MC.PayTerms.ToList());
                PayTermCollection.Filter = new Predicate<object>(FilterPayTerms);
                StringListPayTerms = MC.PayTerms.Select(x => x.p_term_code).ToList();

                warehouseCollection = CollectionViewSource.GetDefaultView(MC.WarehouseList);
                warehouseCollection.Filter = new Predicate<object>(FilterCollectionWarehouse);
                StringListPurchaseWearhouse = MC.WarehouseList.Select(x => x.wa_code).ToList();

                doc_typeCollection = CollectionViewSource.GetDefaultView(MC.DOC_TYPE_LIST);
                doc_typeCollection.Filter = new Predicate<object>(doctype_Filter);
                StringListDocumentTypes = MC.DOC_TYPE_LIST.Select(x => x.doc_type).ToList();

                currencyCollection = CollectionViewSource.GetDefaultView(MC.CURRENCY_LIST);
                currencyCollection.Filter = new Predicate<object>(currency_Filter);
                StringListCurrency = MC.CURRENCY_LIST.Select(x => x.curr_code).ToList();

                PurchaseOrganisationList = (List<ADM_M001_M_P>)AppSessionState.ADM_M001_M_List;


                po_orgCollection = CollectionViewSource.GetDefaultView(PurchaseOrganisationList);
                po_orgCollection.Filter = new Predicate<object>(Purorg_Filter);
                StringListPurchaseOrg = PurchaseOrganisationList.Select(x => x.po_code).ToList();
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


                PurchaseGroupList = (List<ADM_M001_P_P>)AppSessionState.ADM_M001_P_List;
                Purchase_groupCollection = CollectionViewSource.GetDefaultView(PurchaseGroupList);
                Purchase_groupCollection.Filter = new Predicate<object>(Purchase_grp_Filter);
                StringListPurchaseGroup = PurchaseGroupList.Select(x => x.pg_code).ToList();

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

                storage_locCollection = CollectionViewSource.GetDefaultView(MC.storage_locList.ToList());
                storage_locCollection.Filter = new Predicate<object>(storage_loc_Filter);
                StringListPurchaseStorageLocation = MC.storage_locList.Select(x => x.store_code).ToList();

                CostCenterList = MC.cost_centerList;
                cost_centerCollection = CollectionViewSource.GetDefaultView(CostCenterList);
                cost_centerCollection.Filter = new Predicate<object>(cost_center_Filter);
                StringListCostCenter = CostCenterList.Select(x => x.cost_center).ToList();

                DelAddrCollection = CollectionViewSource.GetDefaultView(MC.deladdrList.ToList());
                DelAddrCollection.Filter = new Predicate<object>(Filterdeladdr);
                StringListDeliveryAddress = MC.deladdrList.Select(x => x.location_Id).ToList();

                itemcategoryCollection = CollectionViewSource.GetDefaultView(MC.itemcatList);
                itemcategoryCollection.Filter = new Predicate<object>(Filteritemcategory);
                StringListItemCategory = MC.itemcatList.Select(x => x.item_cat).ToList();

                validatedByCollection = CollectionViewSource.GetDefaultView(MC.BuyerList.ToList());
                validatedByCollection.Filter = new Predicate<object>(Filtervalidator);

                TermsConditionCollection = CollectionViewSource.GetDefaultView(MC.CONDITION_LIST);
                TermsConditionCollection.Filter = new Predicate<object>(Filter_Terms);
                StringListTerms = MC.TermsConditionCollection.Select(x => x.tc_code).ToList();

                dgPOItemsFortaxval = CollectionViewSource.GetDefaultView(MC.AccountList);
                dgPOItemsFortaxval.Filter = new Predicate<object>(FiltertaxAcc);
                StringListTaxAcc = MC.AccountList.Select(x => x.acc_code).ToList();

                FormTypeCollection = CollectionViewSource.GetDefaultView(MC.TaxList);
                FormTypeCollection.Filter = new Predicate<object>(Filter_FormType);
                StringListFormtype = MC.TaxList.Select(x => x.description).ToList();

                TaxDictonery = new Dictionary<string, object>();
                TaxDictonery.Clear();
                TaxDictonery = MC.TaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);

                var TaxListParent = (from o in MC.TaxList
                                     where o.parent_id == null
                                     select o).ToList();
                SelectedTaxList = TaxListParent;
                TaxDictoneryParent = SelectedTaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);




                List<ADM_M030_P> makelist = (from o in MC.ParameterValue where o.para_code == "1002" select o).ToList();
                MakeCollection = CollectionViewSource.GetDefaultView(makelist);
                MakeCollection.Filter = new Predicate<object>(FilterMake);
                StringListMake = makelist.Select(x => x.parametervalue).ToList();

                var Typelist = (from o in MC.ParameterValue where o.para_code == "1001" select o).ToList();
                TypeCollection = CollectionViewSource.GetDefaultView(Typelist.ToList());

                var matconlist = (from o in MC.ParameterValue where o.para_code == "1003" select o).ToList();
                MatConditionCollection = CollectionViewSource.GetDefaultView(matconlist.ToList());

                NotificationDataCollection = MC.NotificationData;

                IncotermsCollection = CollectionViewSource.GetDefaultView(MC.Incoterms);
                IncotermsCollection.Filter = new Predicate<object>(Filter_Incoterms);
                StringListIncoterms = MC.Incoterms.Select(x => x.incoterms).ToList();

                LicenseEPCGCollection = CollectionViewSource.GetDefaultView(MC.LicenseEPCG);
                LicenseEPCGCollection.Filter = new Predicate<object>(Filter_EPCGLicense);
                StringListLicenseEPCG = MC.LicenseEPCG.Select(x => x.lic_cod).ToList();

                LicenseAdvanceCollection = CollectionViewSource.GetDefaultView(MC.LicenseAdvance);
                LicenseAdvanceCollection.Filter = new Predicate<object>(Filter_ADVANCELicense);
                StringListLicenseAdvance = MC.LicenseAdvance.Select(x => x.lic_cod).ToList();

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
        private void CommandInitialization()
        {
            CursorControl.SetBusyState();
            try
            {
                #region Command Initialisation
                cmdSelectRefBulk = new RelayCommand<object>(items => { if (items == null) { return; } SelectRefBulk(items); });
                cmdExecuteRFQ = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteRFQ(items); });
                cmdInsertQty = new RelayCommand<object>(items => { if (items == null) { return; } InsertQty(items); });
                //cmdInsertCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
                //cmdInsertPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });

                cmdSelectionChanged_PUR_T002_H = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_PUR_T002_H(items); });
                cmdSelectionChangedSchedule = new RelayCommand<object>(items => { if (items == null) { return; } ScheduleDataGridRowSelectionChanged(items); });
                cmdSelectionChangedComponant = new RelayCommand<object>(items => { if (items == null) { return; } ComponantDataGridRowSelectionChanged(items); });
                CommandActiveInactiveCheck = new RelayCommand<bool>(CheckActiveStatus);
                // Pending Task for Commands : change name of existing commands Name to start with Command.
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                SelectionChangedCommandParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items, NewRecord); });
                SelectionChangedCommandDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocType(items); });
                SelectionChangedCommandBuyer = new RelayCommand<object>(items => { if (items == null) { return; } InsertBuyer(items); });
                SelectionChangedCommandValidator = new RelayCommand<object>(items => { if (items == null) { return; } InsertValidator(items); });
                SelectionChangedCommandCurrency = new RelayCommand<object>(items => { if (items == null) { return; } InsertCurrency(items); });
                SelectionChangedCommandPayTerms = new RelayCommand<object>(items => { if (items == null) { return; } InsertPayTerm(items); });
                SelectionChangedCommandPurchaseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseOrg(items); });
                SelectionChangedCommandPurchaseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseGroup(items); });
                SelectionChangedCommandWearhouse = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseWearhouse(items); });
                SelectionChangedCommandStorageLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseStorageLocation(items); });
                SelectionChangedCommandDeliveryAddress = new RelayCommand<object>(items => { if (items == null) { return; } InsertDeliveryAddress(items); });
                SelectionChangedCommandBillingAddress = new RelayCommand<object>(items => { if (items == null) { return; } InsertBillingAddress(items); });
                SelectionChangedCommandCostCenter = new RelayCommand<object>(items => { if (items == null) { return; } InsertCostCenter(items); });
                SelectionChangedReferenceDocumentType = new RelayCommand<object>(items => { if (items == null) { return; } FilterReferenceDocumentNumbers(items); }); // Pending Assignment
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CommandLoadDocumentByRefDocNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByReferenceDocumentNumber(cmdPara, "FlipGridReference"); });
                CommandCreateDocumentByReferenceDocuments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } CreateDocumentByReferenceDocumentNumber(cmdPara, "ReferenceDocuments"); });
                cmdInsertItems = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItems(cmdPara, "ReferenceDocuments", null, null); });
                CommandAddItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Item(cmdPara, true, true, true); });
                cmdAddComponant = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertComponant(cmdPara, true, true, true); });
                CommandAddItemCategory = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_ItemCategory(cmdPara, false, true, true); });
                CommandAddUOM = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_UOM(cmdPara, false, true, true); });
                CommandDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
                cmdDeleteTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteTax(cmdPara); });
                CommandDeleteScheduleItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_ItemSchedule(cmdPara); });
                CommandAddSelectedTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSelectedTax(cmdPara); });
                ManualTaxChangedCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertManualTaxChangedCommand(cmdPara); });
                CommandTerms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTerms(cmdPara); });
                CommandDeleteDataGridTerms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Terms(cmdPara); });
                cmdrequisition = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insertdgrequisition(cmdPara); });
                CommandMailDocuments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } MailDocuments(cmdPara); });
                cmdContactPerson = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertContactPerson(cmdPara); });
                CommandIncoterms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertIncoterms(cmdPara); });// confirm assignment
                CommandLicenseAdvance = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicenseAdvance(cmdPara); });// confirm assignment
                CommandLicenseEPCG = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicenseEPCG(cmdPara); });// confirm assignment
                CmddgIncoterms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgIncoterms(cmdPara, false, true, true); });
                CmdLicence = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicence(cmdPara, false, true, true); });
                cmdInsertTermsConditions = new RelayCommand<object>(items => { if (items == null) { return; } InsertTermsConditions(items); });
                cmdBussPlace = new RelayCommand<object>(items => { if (items == null) { return; } InsertBussPlace(items); });
                cmddgBussPlace = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgBussPlace(cmdPara, false, true, true); });
                CmddgShipToParty = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgShipToParty(cmdPara, false, true, true); });
                CmdCondType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertConditiontype(cmdPara); });
                CmddgCurrency = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgCurrency(cmdPara); });
                cmdOpenAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenDocumentViewer(cmdPara); });
                CmdItemInfo = new RelayCommand<object>(items => { if (items == null) { return; } FilterItemSalesData(items); });
                CmdAddSelectedRef = new RelayCommand<object>(items => { if (items == null) { return; } AddSelectedRef(items); });
                CmdInsert_t_status = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_t_status(cmdPara); });
                CommandLoadBackFlipData = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items); });
                cmdSupplingPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertSendingPlant(items); });
                cmdReceivingPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertRecPlant(items); });
                cmdSelectionChanged_PUR_T002_B = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_PUR_T002_B(items); });
                cmdExplodeBOM = new RelayCommand<object>(items => { if (items == null) { return; } ExplodeBOM(items); });
                cmdTR_Mode = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTR_Mode(cmdPara); });
                #endregion
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void SelectionChanged_PUR_T002_H(object InputValue)
        {
            try
            {
                TCEntityObject = (GEN_T011)InputValue;
            }
            catch (Exception ex) { }
        }
        private void InsertTR_Mode(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M026 POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.TransportMode.Where(x => x.tr_mode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M026>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.tr_mode = POPUPEntityObject.tr_mode;
                    MasterEntity.tr_name = POPUPEntityObject.tr_name;
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
        
        private void LoadComponantData(object param)
        {
            CursorControl.SetBusyState();
            int TabIndexValue = Convert.ToInt32(param);
            try
            {
                if (TabIndexValue == 3)
                {
                    if (ItemEntityObject != null)
                    {
                        if (!string.IsNullOrWhiteSpace(ItemEntityObject.ItemCode) && MC.ItemListForComponant != null)
                        {
                            if (MC.ItemListForComponant.Count <= 0)
                            {
                                string Request = "LoadItemsForComponant" + "!@" + AppSessionState.client + "!@" + (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (MasterEntity.location_Id ??  AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + (MasterEntity.po_code ?? AppSessionState.po_code) + "!@" + ((MasterEntity.pg_code ?? AppSessionState.pg_code) ?? "");
                                //string Request = "LoadItemsForComponant" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + MasterEntity.location_Id.ToString() + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + AppSessionState.po_code + "!@" + AppSessionState.pg_code + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.OBJ_LOCATION.location_id;
                                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, Request, "PRO_T002_BL", "PRO", "LoadAll", 0, "");
                                MC.ItemListForComponant = MCTemp.ItemListForComponant;
                                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code);
                                TheFilter = (o, prefix) => ((STD_ITEM)o).item_code.ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                                ASComponant = new AutoSuggestTextViewModel<dynamic>(MCTemp.ItemListForComponant, TheFilter, SuggestedValue, "item_code", true);
                                ASComponant.AutoSuggestVM.IsEmptyValueAllowed = false; ASComponant.AutoSuggestVM.IsFreeTextAllowed = false;

                                ComponantCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListForComponant);
                                ComponantCollection.Filter = new Predicate<object>(Componant_Filter);
                            }
                        }
                        else
                        {
                            IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Select Item first", this.Title); sms.ShowMessage();
                            SelectedTabIndexItem = 0;
                        }
                    }
                    else
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Select Item First", this.Title); sms.ShowMessage();
                        SelectedTabIndexItem = 0;
                    }
                }
            }
            catch (Exception ex)
            {
                SelectedTabIndexItem = 0;
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void ExplodeBOM(object param)
        {
            CursorControl.SetBusyState();
            try
            {
                if (ItemEntityObject != null)
                {
                    if (!string.IsNullOrWhiteSpace(ItemEntityObject.ItemCode) && ItemEntityObject.qty.HasValue)
                    {
                        string Request = "ExplodeBOM" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + ItemEntityObject.bom_no + "!@" + ItemEntityObject.ItemCode + "!@" + ItemEntityObject.unit_code + "!@" + ItemEntityObject.qty.ToString();
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, Request, "PRO_T002_BL", "PRO", "LoadAll", 0, "");

                        if (MCTemp.STD_LIST_OBJ != null)
                        {
                            if (MCTemp.STD_LIST_OBJ.Count > 0)
                            {
                                if (dgComponantEntity.Count > 0)
                                {
                                    foreach (var item in dgComponantEntity.Where(x => x.ref_item_line_id == ItemEntityObject.line_id && x.po_item_row_id == ItemEntityObject.id).ToList())
                                    {
                                        dgComponantEntity.Remove(item);
                                    }
                                }
                                foreach (var item in MCTemp.STD_LIST_OBJ)
                                {
                                    PUR_T002_C obj = new PUR_T002_C();
                                    obj.id = 0;
                                    if (dgComponantEntity.Count > 0)
                                    {
                                        obj.line_id = dgComponantEntity.Count;
                                    }
                                    {
                                        obj.line_id = 1;
                                    }
                                    obj.ref_item_line_id = ItemEntityObject.line_id;
                                    obj.po_no = MasterEntity.po_no;
                                    obj.po_item_row_id = ItemEntityObject.id;
                                    obj.sch_row_id = 0;
                                    obj.active = true;
                                    obj.t_status = MasterEntity.t_status;
                                    obj.client = AppSessionState.client;
                                    obj.comp_code = MasterEntity.comp_code;
                                    obj.location_id = ItemEntityObject.location_Id;
                                    obj.item_code = item.item_code;
                                    obj.sku = item.sku;
                                    obj.store_code = ItemEntityObject.store_code;
                                    obj.batch_no = null;
                                    obj.qty = item.qty ?? 0;
                                    obj.unit_code = ItemEntityObject.unit_code;
                                    obj.reserv_no = null;
                                    obj.reserv_item_row_id = null;
                                    obj.record_type = null;
                                    obj.requirement_type = null;
                                    obj.bom_no = item.bom_no;
                                    obj.bom_item_row_id = item.id;
                                    obj.routing_no = item.routing_no;
                                    obj.op_seq = item.op_seq;
                                    obj.operation_no = item.operation_no;
                                    obj.plan_counter = item.counter1;
                                    obj.object_no = null;
                                    obj.op_scrap = item.dc_value1 ?? 0;
                                    obj.comp_scrap = item.dc_value2 ?? 0;
                                    obj.order_no = MasterEntity.po_no;
                                    obj.order_item_row_id = ItemEntityObject.id;
                                    obj.item_name = item.item_name;
                                    obj.sku_desc = item.sku_desc;
                                    obj.t_display = ItemEntityObject.t_display;

                                    dgComponantEntity.Add(obj);
                                }
                            }
                        }
                    }
                    else
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Select Item first", this.Title); sms.ShowMessage();
                        SelectedTabIndexItem = 0;
                    }
                }
                else
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Select Item First", this.Title); sms.ShowMessage();
                    SelectedTabIndexItem = 0;
                }
            }
            catch (Exception ex)
            {
                SelectedTabIndexItem = 0;
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void UpdateQtyInLicence()
        {
            try
            {
                foreach (var m in LicenceDetailsEntity)
                {
                    foreach (var o in dgItemsEntity)
                    {
                        if (o.ItemCode == m.ItemCode)
                        {
                            m.qty = o.qty;
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
            WebServiceRepository<MultipleContext_Attachments> repository_MCAttachments = new WebServiceRepository<MultipleContext_Attachments>();
            List<COM_T003> Attachments = new List<COM_T003>();
            PUR_T002_B EntityObjectParameter = new PUR_T002_B();
            MultipleContext_Attachments MCAttachments = new MultipleContext_Attachments();
            try
            {
                if (InputValue != null)
                {
                    EntityObjectParameter = ((IEnumerable)InputValue).Cast<PUR_T002_B>().ToList()[0];
                }
                //string Request = "GetAllFiles" + "!@" + EntityObjectParameter.ItemCode;
                string Request = "GetAllFiles" + "!@" + AppSessionState.client + "!@" + (EntityObjectParameter.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (EntityObjectParameter.location_Id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + (doc_cat_vm ?? "") + "!@" + (doc_cat_vm ?? "") + "!@" + EntityObjectParameter.po_no + "!@" + EntityObjectParameter.id.ToString();
                //MCAttachments = repository_MCAttachments.GetData<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Reflection.BusinessLogic.ReflectionFileHandlingServices");
                MCAttachments = repository_MCAttachments.GetDataWithReturnDomainObject<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                if (!string.IsNullOrEmpty(EntityObjectParameter.ItemCode))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.po_no.Replace("/", "--"), Row_ID = EntityObjectParameter.id.ToString(), DocumentList = MCAttachments.Attachments, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
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
        #region User Defined Functions
        private async void FilterItemSalesData(object InputValue)
        {
            try
            {

                PUR_T002_B ItemsEntityObject = null;

                if (((IEnumerable)InputValue).Cast<PUR_T002_B>().Count() > 0)
                {
                    ItemsEntityObject = ((IEnumerable)InputValue).Cast<PUR_T002_B>().ToList()[0];
                    SalesUnitPriceCollection.Clear();
                    SalesQFRCollection.Clear();
                    SalesDispatchCollection.Clear();
                    SalesProjDispatchCollection.Clear();

                    string Request1 = "GetItemPrice" + "!@" + ItemsEntityObject.ItemCode + "!@" + MasterEntity.PartyId + "!@" + MasterEntity.po_no + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat;
                    MCTemp = await repository_MCTemp.GetDataWithReturnDomainObjectASynchronus<MultipleContext_PUR_T002_A>(MCTemp, Request1, "PRO_T002_BL", "PRO", "", 0, "GetItemPriceData");

                    if (dgItemsEntity != null && MCTemp.UnitPriceList != null && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < dgItemsEntity.Count)
                    {
                        if (MCTemp.UnitPriceList.Count > 0 && dgItemsEntity.Count > 0)
                        {

                            var tempUnitPrice = MCTemp.UnitPriceList;
                            SalesUnitPriceCollection = tempUnitPrice;
                        }
                    }

                    if (dgItemsEntity != null && MCTemp.QFRList != null && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < dgItemsEntity.Count)
                    {
                        if (MCTemp.QFRList.Count > 0 && dgItemsEntity.Count > 0)
                        {

                            var tempQFR = MCTemp.QFRList;
                            SalesQFRCollection = tempQFR.ToList();
                        }
                    }

                    if (dgItemsEntity != null && MCTemp.DispatchList != null && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < dgItemsEntity.Count)
                    {
                        if (MCTemp.DispatchList.Count > 0 && dgItemsEntity.Count > 0)
                        {

                            var tempDispatch = MCTemp.DispatchList;
                            SalesDispatchCollection = tempDispatch;
                        }
                    }

                    if (dgItemsEntity != null && MCTemp.ProjectedDispList != null && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < dgItemsEntity.Count)
                    {
                        if (MCTemp.ProjectedDispList.Count > 0 && dgItemsEntity.Count > 0)
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
        string DocumentList = "";
        private void LoadBackFlipData(object Parameter)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (SearchEntityObject.location_Id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + (SearchEntityObject.doc_type ?? "") + "!@!@" + AppSessionState.UserID + "!@" + (SearchEntityObject.EmpId ?? AppSessionState.EmpId) + "!@" + ts_code_vm + "!@" + AppSessionState.po_code + "!@" + (AppSessionState.pg_code ?? "") + "!@" + (SearchEntityObject.PartyId ?? "") + "!@!@" + SearchEntityObject.active + "!@" + SearchEntityObject.t_status + "!@" + Convert.ToDateTime(SearchEntityObject.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(SearchEntityObject.to_date).ToString("MM/dd/yyyy");
                //string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + Convert.ToDateTime(SearchEntityObject.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(SearchEntityObject.to_date).ToString("MM/dd/yyyy") + "!@" + AppSessionState.po_code + "!@" + AppSessionState.pg_code + "!@" + AppSessionState.EmpId + "!@" + SearchEntityObject.active;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, Request, "PRO_T002_BL", "PRO", "LoadAll", 0, "");

                FlipGridData = MCTemp.DocumentDataFlipGrid.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
        
        private void InsertTerms(object InputValue)
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
                    //bool varValue = TermsConditionEntity.Any(x => x.tc_code == POPUPEntityObject.tc_code);
                    if (TCEntityObject != null)
                    {
                        TCEntityObject.active = "1";
                        TCEntityObject.comp_code = MasterEntity.comp_code;
                        TCEntityObject.tc_code = POPUPEntityObject.tc_code;
                        TCEntityObject.con_type = POPUPEntityObject.con_type;
                        TCEntityObject.long_text = POPUPEntityObject.long_text;
                        TCEntityObject.seq_no = POPUPEntityObject.seq_no;
                        TCEntityObject.short_text = POPUPEntityObject.short_text;
                        TCEntityObject.con_group = POPUPEntityObject.con_group;
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
                        //TCEntityObject.active = "1";
                        //TCEntityObject.comp_code = MasterEntity.comp_code;
                        //TCEntityObject.tc_code = item.tc_code;
                        //TCEntityObject.con_type = item.con_type;
                        //TCEntityObject.long_text = item.long_text;
                        //TCEntityObject.seq_no = item.seq_no;
                        //TCEntityObject.short_text = item.short_text;
                        //TCEntityObject.con_group = item.con_group;

                        //bool varValue = TermsConditionEntity.Any(x => x.tc_code == item.tc_code);
                        //if (varValue == false)
                        //{
                        if (item != null)
                        {
                            GEN_T011 obj_tcnew = new GEN_T011();
                            obj_tcnew.id = 0;
                            obj_tcnew.active = "1";
                            obj_tcnew.comp_code = MasterEntity.comp_code;
                            obj_tcnew.tc_code = item.tc_code;
                            obj_tcnew.con_type = item.con_type;
                            obj_tcnew.long_text = item.long_text;
                            obj_tcnew.seq_no = item.seq_no;
                            obj_tcnew.short_text = item.short_text;
                            obj_tcnew.con_group = item.con_group;
                            TermsConditionEntity.Add(obj_tcnew);
                        }
                        //}
                    }
                }
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
                    if (dgItemsEntity.Count == dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        dgItemsEntity.Add(new PUR_T002_B()
                        {
                            buss_place = POPUPEntityObject.buss_place
                        });

                    }
                    else if (ItemEntityObject != null)
                    {
                        ItemEntityObject.buss_place = POPUPEntityObject.buss_place;

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
                        { POPUPEntityObject = MC.partyList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    if (dgItemsEntity.Count == dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        dgItemsEntity.Add(new PUR_T002_B()
                        {
                            //bill_address_id = POPUPEntityObject.PartyId,
                            //del_address_id = POPUPEntityObject.ship_to_add
                        });
                    }
                    else if (dgItemsEntity.Count > dgSelectedIndexItem)
                    {
                        //ItemEntityObject.bill_address_id = POPUPEntityObject.PartyId;
                        //ItemEntityObject.del_address_id = POPUPEntityObject.ship_to_add;
                    }
                }
            }
            catch (Exception ex)
            { }
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
                        TotalDocumentTaxes.Add(new ACC_T006_B()
                        {


                            con_type = POPUPEntityObject.con_type,
                            trns_key_code = POPUPEntityObject.con_cat


                        });

                    }
                    else if (TotalDocumentTaxes.Count > dgSelectedIndexTaxSummury)
                    {
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].con_type = POPUPEntityObject.con_type;
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].trns_key_code = POPUPEntityObject.con_cat;

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
                    if (TotalDocumentTaxes.Count == dgSelectedIndexTaxSummury && dgSelectedIndexTaxSummury >= 0)
                    {
                        TotalDocumentTaxes.Add(new ACC_T006_B()
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
        private void DefaultValues(string doc_cat_info)
        {
            EntityChangeEnable = true;
            ind_value = null;
            AutoRoundupEnable = true;
            NewRecord = true;
            RoundUpDecimals = 2;
            MasterEntity.doc_cat = this.doc_cat_vm;
            MasterEntity.doc_type = this.doc_cat_vm;
            MasterEntity.curr_code = AppSessionState.CntryCurncy;
            //MasterEntity.ex_rate = (from o in MC.CURRENCY_LIST where o.curr_code == MasterEntity.curr_code select o.exch_rate).FirstOrDefault();
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.bill_address_id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.del_address_id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.add_code_bil = AppSessionState.OBJ_LOCATION.add_code;
            MasterEntity.add_code_del = AppSessionState.OBJ_LOCATION.add_code;
            MasterEntity.active = true;
            //MasterEntity.rel_sts = "04";
            if (MC.t_statusList != null)
            {
                if (MC.t_statusList.Count > 0)
                {
                    MasterEntity.t_status = (from o in MC.t_statusList where o.ind_default == "1" select o.t_status).FirstOrDefault();
                    MasterEntity.t_display = (from o in MC.t_statusList where o.ind_default == "1" select o.t_display).FirstOrDefault();
                }
            }
            MasterEntity.po_no = null;
            MasterEntity.po_date = DateTime.Now; //DateTime.Now.Date // NOTE: commnet on 01/04//2024 because it was creating previous day date taking because of GMT 5:30 and date taking 12.00 AM time and it reduce GMT difference in database so it chage date to previous day. update porper logic.
            MasterEntity.order_date = DateTime.Now.Date;
            MasterEntity.shipped = false;
            MasterEntity.version = "v1.0";
            ScheduleEntity.t_status = MasterEntity.t_status;
            ScheduleEntity.t_display = MasterEntity.t_display;
            ScheduleEntity.sch_date = DateTime.Now;
            ScheduleEntity.active = true;
            
            ScheduleEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code; 
            ScheduleEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;

            if (doc_cat_info == "TO" || doc_cat_vm == "TO")
            {
                MasterEntity.supplying_plant = null;
                MasterEntity.rec_plant = AppSessionState.OBJ_LOCATION.location_id;
            }
            ScheduleEntity.id = 0;
            ScheduleEntity.PartyId = MasterEntity.PartyId;
            Currency = AppSessionState.CntryCurncy;
            MasterEntity.buyer = AppSessionState.EmpId;
            MasterEntity.BuyerName = AppSessionState.EmpName;
            MasterEntity.validator_code = AppSessionState.EmpId;
            MasterEntity.validator_name = AppSessionState.EmpName;
            MasterEntity.po_code = AppSessionState.po_code; // Determination required.
            MasterEntity.pg_code = AppSessionState.pg_code; // Determination required.
            MasterEntity.order_date = System.DateTime.Now;
            MasterEntity.ex_rate = 1;
            MasterEntity.local_export_ind = "D";
            MasterEntity.ind_trade = "L";

            

            dgSelectedIndex = -1;
            dgSelectedIndexItemSchedule = -1;
            dgSelectedIndexItem = -1;
            dgSelectedIndexTerms = -1;
            dgSelectedIndexTaxSummury = -1;
            TaxDataGridSelectedIndex = -1;
            dgSelectedIndexItemLicence = -1;

            SearchEntityObject.from_date = DateTime.Now.Date;
            SearchEntityObject.to_date = DateTime.Now.Date;
            SearchEntityObject.active = true;

            ScheduleEntity.active = true;
            ScheduleEntity.t_status = MasterEntity.t_status;
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
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;

            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
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

                    if (dgItemsEntity != null && dgItemsEntity.Count > 0 && ItemRowIndex >= 0 && ItemRowIndex < dgItemsEntity.Count) //Condition satisfy only if Items collection is not empty.
                    {
                        if (string.IsNullOrWhiteSpace(dgItemsEntity[ItemRowIndex].rel_billing) || dgItemsEntity[ItemRowIndex].rel_billing=="Y")
                        {
                            if (dgItemsEntity[ItemRowIndex].qty >= 0 && dgItemsEntity[ItemRowIndex].unit_price >= 0 && dgItemsEntity[ItemRowIndex].active != false) // Must not null or empty.
                            {
                                dgItemsEntity[ItemRowIndex].gross_value = Math.Round(((dgItemsEntity[ItemRowIndex].qty * dgItemsEntity[ItemRowIndex].unit_price) ?? 0), RoundUpDecimals);

                                if (dgItemsEntity[ItemRowIndex].discount == null)
                                {
                                    dgItemsEntity[ItemRowIndex].discount = 0;
                                }
                                if (dgItemsEntity[ItemRowIndex].discount_type == "F")    // Manual Discount value instead of percent.
                                {
                                    dgItemsEntity[ItemRowIndex].discount = 0;
                                    dgItemsEntity[ItemRowIndex].sub_total = (dgItemsEntity[ItemRowIndex].gross_value - dgItemsEntity[ItemRowIndex].discount_amt);
                                }
                                else
                                {
                                    //dgItemsEntity[ItemRowIndex].discount_amt = (dgItemsEntity[ItemRowIndex].gross_value * ((dgItemsEntity[ItemRowIndex].discount ?? 0) / 100));
                                    dgItemsEntity[ItemRowIndex].discount_amt = decimal.Round((decimal)(dgItemsEntity[ItemRowIndex].gross_value * ((dgItemsEntity[ItemRowIndex].discount ?? 0) / 100)), RoundUpDecimals);
                                    //dgItemsEntity[ItemRowIndex].sub_total = (dgItemsEntity[ItemRowIndex].gross_value - dgItemsEntity[ItemRowIndex].discount_amt);
                                    dgItemsEntity[ItemRowIndex].sub_total = decimal.Round((decimal)((dgItemsEntity[ItemRowIndex].gross_value - dgItemsEntity[ItemRowIndex].discount_amt) ?? 0), RoundUpDecimals);
                                }
                            }
                            #region Calculate Taxes for New/Edited Items row.
                            if (!String.IsNullOrEmpty(dgItemsEntity[ItemRowIndex].tax_id) && dgItemsEntity[ItemRowIndex].active == true) //Condition satisfy only if Selected Item not null and Taxes are applied.
                            {
                                #region Tax Not Null

                                List<ACC_M013_P> TaxListTemp = new List<ACC_M013_P>();
                                string[] TaxArray = dgItemsEntity[ItemRowIndex].tax_id.Trim().Split(',');
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

                                        #region Percentage
                                        if (SingleTax.t_type == "Percentage" && SingleTax.amount > 0)
                                        {
                                            if (SingleTax.Price_include == true)
                                            {
                                                TaxValue = (SingleTax.amount) / 100 + 1;
                                                BasePrice = dgItemsEntity[ItemRowIndex].sub_total / TaxValue;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = dgItemsEntity[ItemRowIndex].sub_total - BasicItemAmount;
                                            }
                                            else if (SingleTax.Price_include == false)
                                            {
                                                TaxValue = (SingleTax.amount) / 100;
                                                if (TaxListForBaseInclude.Length > 0)
                                                {
                                                    PreviousTaxValueForBasePrice = TotalDocumentTaxes.Where(tax => tax.sequence < SingleTax.sequence && tax.item_line_id == dgItemsEntity[ItemRowIndex].line_id && tax.manual == "Auto" && tax.ItemCode == dgItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (dgItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_row_id == dgItemsEntity[ItemRowIndex].id && tax.tax_code_id.In(TaxListForBaseInclude)).Sum(tax => tax.tax_amount); // Get Base amount for Calculation.
                                                }
                                                if (SingleTax.parent_id != null) // Collect Base price for This single child Tax.
                                                {
                                                    BasePrice = TotalDocumentTaxes.Where(tax => tax.tax_code_id == SingleTax.parent_id && tax.item_line_id == dgItemsEntity[ItemRowIndex].line_id && tax.manual == "Auto" && tax.ItemCode == dgItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (dgItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_row_id == dgItemsEntity[ItemRowIndex].id).Single().tax_amount;
                                                }
                                                else // Collect Base Price for this parent Tax.
                                                {
                                                    BasePrice = dgItemsEntity[ItemRowIndex].sub_total + PreviousTaxValueForBasePrice;
                                                }
                                                BasicItemAmount = dgItemsEntity[ItemRowIndex].sub_total;
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
                                                BasePrice = dgItemsEntity[ItemRowIndex].sub_total - TaxValue;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = dgItemsEntity[ItemRowIndex].sub_total - BasicItemAmount;
                                            }
                                            else if (SingleTax.Price_include == false)
                                            {
                                                BasePrice = dgItemsEntity[ItemRowIndex].sub_total;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = TaxValue;
                                            }
                                        }
                                        #endregion
                                        #region Insert/Update Tax
                                        TaxAmount = Math.Round(TaxAmount ?? 0, RoundUpDecimals);
                                        int TaxIndex = 0;
                                        var TaxVar = TotalDocumentTaxes.FirstOrDefault(T => T.tax_code_id == SingleTax.id && T.ItemCode == dgItemsEntity[ItemRowIndex].ItemCode && (T.sku?.ToString() ?? "") == (dgItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && T.item_line_id == dgItemsEntity[ItemRowIndex].line_id && T.item_row_id == dgItemsEntity[ItemRowIndex].id && T.manual == "Auto");
                                        TaxIndex = TotalDocumentTaxes.IndexOf(TaxVar);
                                        if (TaxVar != null && TaxIndex >= 0)
                                        {
                                            TotalDocumentTaxes[TaxIndex].manual = "Auto";
                                            TotalDocumentTaxes[TaxIndex].active = true;
                                            TotalDocumentTaxes[TaxIndex].tax_amount = TaxAmount;
                                            TotalDocumentTaxes[TaxIndex].account_id = 0;
                                            TotalDocumentTaxes[TaxIndex].sequence = SingleTax.sequence;
                                            TotalDocumentTaxes[TaxIndex].doc_no = MasterEntity.po_no;
                                            TotalDocumentTaxes[TaxIndex].base_amount = BasePrice;
                                            TotalDocumentTaxes[TaxIndex].amount = SingleTax.amount;
                                            TotalDocumentTaxes[TaxIndex].tax_code_id = SingleTax.id;
                                            TotalDocumentTaxes[TaxIndex].account_analytic_id = 0;
                                            TotalDocumentTaxes[TaxIndex].base_code_id = SingleTax.id;
                                            TotalDocumentTaxes[TaxIndex].tax_name = SingleTax.description;
                                            TotalDocumentTaxes[TaxIndex].ItemCode = dgItemsEntity[ItemRowIndex].ItemCode;
                                            TotalDocumentTaxes[TaxIndex].sku = dgItemsEntity[ItemRowIndex].sku;
                                            TotalDocumentTaxes[TaxIndex].item_row_id = dgItemsEntity[ItemRowIndex].id;
                                            TotalDocumentTaxes[TaxIndex].item_line_id = dgItemsEntity[ItemRowIndex].line_id;
                                            TotalDocumentTaxes[TaxIndex].location_Id = MasterEntity.location_Id;
                                            TotalDocumentTaxes[TaxIndex].comp_code = MasterEntity.comp_code;
                                            TotalDocumentTaxes[TaxIndex].posting_period = MasterEntity.posting_period;
                                            TotalDocumentTaxes[TaxIndex].trns_key_code = "";

                                            TotalDocumentTaxes[TaxIndex].con_value = TaxAmount;
                                            TotalDocumentTaxes[TaxIndex].tax_code = SingleTax.tax_code;
                                            TotalDocumentTaxes[TaxIndex].PartyId = MasterEntity.PartyId;
                                            TotalDocumentTaxes[TaxIndex].exch_rate = MasterEntity.ex_rate;
                                            TotalDocumentTaxes[TaxIndex].client = AppSessionState.client;
                                            TotalDocumentTaxes[TaxIndex].symbol = MasterEntity.symbol;
                                            TotalDocumentTaxes[TaxIndex].local_curr = AppSessionState.CntryCurncy;

                                        }
                                        else
                                        {
                                            TotalDocumentTaxes.Add(new ACC_T006_B()
                                            {
                                                id = 0,
                                                tax_amount = TaxAmount,
                                                account_id = 0,
                                                sequence = SingleTax.sequence,
                                                doc_no = MasterEntity.po_no,
                                                manual = "Auto",
                                                base_amount = BasePrice,
                                                amount = SingleTax.amount,
                                                tax_code_id = SingleTax.id,
                                                account_analytic_id = 0,
                                                base_code_id = SingleTax.id,
                                                tax_name = SingleTax.description,
                                                ItemCode = dgItemsEntity[ItemRowIndex].ItemCode,
                                                sku = dgItemsEntity[ItemRowIndex].sku,
                                                item_row_id = dgItemsEntity[ItemRowIndex].id,
                                                item_line_id = dgItemsEntity[ItemRowIndex].line_id,
                                                //fin_year = AppSessionState.FinYear,
                                                active = true,
                                                posting_period = MasterEntity.posting_period,
                                                location_Id = AppSessionState.OBJ_LOCATION.location_id,
                                                comp_code = AppSessionState.OBJ_COMPANY.comp_code,
                                                trns_key_code = "",

                                                con_value = TaxAmount,
                                                tax_code = SingleTax.tax_code,
                                                PartyId = MasterEntity.PartyId,
                                                exch_rate = MasterEntity.ex_rate,
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
                                string[] TaxArray2 = dgItemsEntity[ItemRowIndex].tax_id.Trim().Split(',');
                                List<ACC_T006_B> copy = new List<ACC_T006_B>();
                                copy = TotalDocumentTaxes.ToList();
                                foreach (var tax in copy)
                                {
                                    bool DeleteFlag = true;
                                    foreach (string SingleTax in TaxArray2)
                                    {
                                        if ((tax.tax_code_id.ToString() == SingleTax && tax.ItemCode == dgItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (dgItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == dgItemsEntity[ItemRowIndex].line_id && tax.item_row_id == dgItemsEntity[ItemRowIndex].id && tax.manual == "Auto") || tax.manual == "Manual")
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
                                            if (ChildTaxVar.parent_id.ToString() == SingleTax && tax.ItemCode == dgItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (dgItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == dgItemsEntity[ItemRowIndex].line_id && tax.item_row_id == dgItemsEntity[ItemRowIndex].id && tax.manual == "Auto")
                                            {
                                                CheckChildParentFlag = false;
                                                break;
                                            }
                                        }
                                        if (!CheckChildParentFlag) continue;
                                        //var ParentTaxVar = TotalDocumentTaxes.FirstOrDefault(T => T.tax_code_id == ChildTaxVar.parent_id && T.ItemCode == dgItemsEntity[ItemRowIndex].ItemCode && (T.sku?.ToString() ?? "") == (dgItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && T.line_id == dgItemsEntity[ItemRowIndex].line_id && T.item_line_id == dgItemsEntity[ItemRowIndex].id && T.manual == "Auto");
                                        //if (ParentTaxVar == null)

                                        if (tax.tax_code_id == ChildTaxVar.id && tax.ItemCode == dgItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (dgItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == dgItemsEntity[ItemRowIndex].line_id && tax.item_row_id == dgItemsEntity[ItemRowIndex].id && tax.manual == "Auto" && (tax.active == true || tax.id == 0))
                                        {
                                            TotalDocumentTaxes.Remove(tax);
                                        }
                                    }
                                    else if (tax.tax_code_id == ChildTaxVar.id && tax.ItemCode == dgItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (dgItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == dgItemsEntity[ItemRowIndex].line_id && tax.item_row_id == dgItemsEntity[ItemRowIndex].id && tax.manual == "Auto" && (tax.active == true || tax.id == 0))
                                    {
                                        if (tax.id == 0)
                                        {
                                            TotalDocumentTaxes.Remove(tax);
                                        }
                                        else
                                        {
                                            int Index = TotalDocumentTaxes.IndexOf(TotalDocumentTaxes.Where(X => X.ItemCode == dgItemsEntity[ItemRowIndex].ItemCode && X.id == tax.id && (X.sku?.ToString() ?? "") == (dgItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && X.item_line_id == dgItemsEntity[ItemRowIndex].line_id && X.item_row_id == dgItemsEntity[ItemRowIndex].id && X.manual == "Auto" && X.active == true).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.
                                            if (Index >= 0)
                                            {
                                                TotalDocumentTaxes.ElementAt(Index).active = false;
                                            }
                                        }
                                    }
                                }

                                #endregion

                            }
                            else //if (dgItemsEntity[ItemRowIndex].tax_id != null && dgItemsEntity[ItemRowIndex].active == false) // Remove previously assign Taxes from TotalDocumentTaxes if removed from Item.//Condition satisfy only if Selected Item not null and Active status is false.
                            {
                                List<ACC_T006_B> copy = new List<ACC_T006_B>();
                                copy = TotalDocumentTaxes.ToList();
                                foreach (var tax in copy)
                                {
                                    if (tax.ItemCode == dgItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (dgItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == dgItemsEntity[ItemRowIndex].line_id && tax.item_row_id == dgItemsEntity[ItemRowIndex].id && tax.manual == "Auto")
                                    {
                                        if (tax.id == 0)
                                        {
                                            TotalDocumentTaxes.Remove(tax);
                                        }
                                        else
                                        {
                                            int Index = TotalDocumentTaxes.IndexOf(TotalDocumentTaxes.Where(X => X.ItemCode == dgItemsEntity[ItemRowIndex].ItemCode && (X.sku?.ToString() ?? "") == (dgItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && X.item_line_id == dgItemsEntity[ItemRowIndex].line_id && X.item_row_id == dgItemsEntity[ItemRowIndex].id && X.manual == "Auto" && X.active == true).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.
                                            if (Index >= 0)
                                            {
                                                TotalDocumentTaxes.ElementAt(Index).active = false;
                                            }
                                        }
                                    }
                                }
                            }
                            #region Final Computation

                            if (dgItemsEntity.Count > 0) // calculate items total Tax and get Net & Effective value of the item.
                            {
                                decimal? taxTotal = TotalDocumentTaxes.Where(x => x.item_row_id == dgItemsEntity[ItemRowIndex].id && x.item_line_id == dgItemsEntity[ItemRowIndex].line_id).Sum(x => x.con_value);
                                dgItemsEntity[ItemRowIndex].net_value = ((dgItemsEntity[ItemRowIndex].gross_value + Math.Round((taxTotal ?? 0), RoundUpDecimals)) - (dgItemsEntity[ItemRowIndex].discount_amt ?? 0));
                                dgItemsEntity[ItemRowIndex].effective_value = dgItemsEntity[ItemRowIndex].net_value;
                                dgItemsEntity[ItemRowIndex].tax_amount = taxTotal;
                            }

                            TaxtTotal = TotalDocumentTaxes.Where(item => item.active != false && item.manual == "Auto").Sum(item => item.tax_amount);
                            MasterEntity.amount_tax = TaxtTotal;
                            MasterEntity.tax_amount = TaxtTotal;

                            UnTaxTotal = dgItemsEntity.Where(item => item.active != false).Sum(item => item.sub_total);
                            MasterEntity.amount_untaxed = UnTaxTotal;

                            net_value = UnTaxTotal + TaxtTotal;
                            MasterEntity.net_value = net_value;
                            other_charges = TotalDocumentTaxes.Where(item => item.active != false && item.manual == "Manual").Sum(item => item.tax_amount);
                            MasterEntity.other_charges = other_charges;

                            GrandTotal = net_value + other_charges;
                            MasterEntity.amount_total = GrandTotal;

                            MasterEntity.local_roundup_total = (MasterEntity.roundup_total * MasterEntity.ex_rate);

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
                            MasterEntity.gross_value = dgItemsEntity.Where(item => item.active != false).Sum(item => item.qty * item.unit_price); ;
                            MasterEntity.effective_value = GrandTotal;
                            MasterEntity.disc_amt = MasterEntity.gross_value - UnTaxTotal;

                            if (MasterEntity.roundup_total > 0 && !string.IsNullOrWhiteSpace(MasterEntity.curr_code))
                            {
                                ADM_M037 curr_obj = new ADM_M037();
                                curr_obj = ((List<ADM_M037>)AppSessionState.CurrencyList).Where(x => x.curr_code == MasterEntity.curr_code).ToList()[0];
                                if (curr_obj.word_format == "F01" || string.IsNullOrWhiteSpace(curr_obj.word_format))
                                {
                                    MasterEntity.amt_in_words = NUMBER_TO_WORDS_CONVERTER.AmountInWordsF01(MasterEntity.roundup_total.ToString(), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word, curr_obj.word_format, curr_obj.word_prefix, curr_obj.word_suffix);
                                }
                                else
                                {
                                    MasterEntity.amt_in_words = NOW_OBJ.AmountInWords(Convert.ToDecimal(MasterEntity.roundup_total), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word, curr_obj.word_format);
                                }
                            }
                            else
                            { MasterEntity.amt_in_words = ""; }

                            //var GroupByTaxQuery = from wo in TotalDocumentTaxes
                            //                      group wo by wo.tax_name
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
            // Validation for Quantity Item Duplication and Unit Code For Item Details
            foreach (var o in dgItemsEntity)
            {
                int flag = 0;
                if (o.id == 0)
                {
                    foreach (var p in dgItemsEntity)
                    {
                        if (o.ItemCode == p.ItemCode && o.sku == p.sku && o.line_id == p.line_id && o.id == p.id)
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

                if (o.ItemCode != null && o.ItemCode != "" && o.description != null)
                {
                    if (MasterEntity.doc_type != "OP")
                    {
                        if (o.qty == null || o.qty == 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Quantity cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
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

            }

            //Validation For Item Quantity Equal To Sum of Quantities of All Batches Of the Item 
            bool breakfor = false;
            for (int i = 0; i < dgItemsEntity.Count; i++)
            {
                decimal temp = 0;
                int flag = 0;

                for (int j = 0; j < dgItemScheduleEntity.Count; j++)
                {
                    if (dgItemsEntity[i].ItemCode == dgItemScheduleEntity[j].ItemCode && dgItemsEntity[i].sku == dgItemScheduleEntity[j].sku && dgItemsEntity[i].id == (dgItemScheduleEntity[j].po_item_row_id ?? 0) && dgItemsEntity[i].line_id == dgItemScheduleEntity[j].item_line_id) // && dgItemsEntity[i].po_no == dgItemScheduleEntity[j].ref_doc_no
                    {
                        temp = temp + Convert.ToDecimal(dgItemScheduleEntity[j].qty);
                        flag = 1;
                    }
                }
                if (MasterEntity.doc_type != "NP")
                {
                    if (dgItemsEntity[i].qty != temp && flag == 1)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Item Quantity is Not Equal to Sum of All Items in Schedule Quantities for Item {0} Parameter :{1} ", dgItemsEntity[i].ItemCode, dgItemsEntity[i].sku_desc);
                        showMessageService.ShowMessage();
                        breakfor = false;
                        return false;
                    }
                }
            }

            if (MasterEntity.buyer == null || MasterEntity.buyer == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Field Buyer Is Required");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.revision_ind == "1" && (string.IsNullOrWhiteSpace(MasterEntity.rev_ref_no) || string.IsNullOrWhiteSpace(MasterEntity.revision_no)))
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Revision reference note and revision number is required");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.ex_rate == null || !MasterEntity.ex_rate.HasValue)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Exchange Rate Required");
                showMessageService.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.ind_trade))
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Transaction Type Required");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.curr_code == null || MasterEntity.curr_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Field Currancy Is Required");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.copy == true)
            {
                NewRecord = true;
            }

            if (MasterEntity.doc_cat == "OP")
            {
                if (MasterEntity.valid_from_date == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Field Validity From Date Is Required for Open Order Category");
                    showMessageService.ShowMessage();
                    return false;

                }
                if (MasterEntity.valid_to_date == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Field Validity To Date Is Required for Open Order Category");
                    showMessageService.ShowMessage();
                    return false;
                }

            }
            if ((MasterEntity.PartyId == null || MasterEntity.PartyId == "") && this.doc_cat_vm != "TO")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Field Supplier Is Required");
                showMessageService.ShowMessage();
                return false;
            }
            if ((MasterEntity.supplying_plant == null || MasterEntity.supplying_plant == "" || MasterEntity.rec_plant == null || MasterEntity.rec_plant == "") && this.doc_cat_vm == "TO")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Field Suppling and Receiving Plant Is Required");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.po_code == null || MasterEntity.po_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Field Purchase Organisation Is Required");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.pg_code == null || MasterEntity.pg_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Field Purchase Group Is Required");
                showMessageService.ShowMessage();
                return false;
            }
            if ((MasterEntity.bill_address_id == null || MasterEntity.bill_address_id == "") && this.doc_cat_vm != "TO")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Billing Address Is Required");
                showMessageService.ShowMessage();
                return false;
            }
            if ((MasterEntity.del_address_id == null || MasterEntity.del_address_id == "") && this.doc_cat_vm != "TO")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Delivery Address Is Required");
                showMessageService.ShowMessage();
                return false;
            }
            if (dgItemsEntity.Count < 1)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Field ItemCode Is Required");
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

            return true;
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

            foreach (var item in dgItemsEntity)
            {
                if (item.active == true && (item.rel_billing ?? "Y")=="Y")
                {
                    html += "<tr bgcolor=#d9e6f2>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.ItemCode + "</p></span></strong></p> </td>";
                    html += "<td width=10%> <p><strong><span style=color:#000080;> " + item.description + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.qty.ToString() + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.unit_code + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + (item.unit_price.HasValue ? decimal.Round(item.unit_price.Value, 2).ToString() : "") + "</span></strong></p> </td>";
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
                        new KeyValuePair<string, string>("[DOC]", MasterEntity.doc_desc),
                        new KeyValuePair<string, string>("[OPR]", operation),
                        new KeyValuePair<string, string>("[DOCNO]", MasterEntity.po_no),
                        new KeyValuePair<string, string>("[Comp]","M/s: " +AppSessionState.CompanyName),
                        new KeyValuePair<string, string>("[TSTS]", MasterEntity.t_display),
                        new KeyValuePair<string, string>("[Attn]",VarData.EmpName),
                        new KeyValuePair<string, string>("[CUST]","M/s: " +  MasterEntity.party_name),
                        new KeyValuePair<string, string>("[CUR]",MasterEntity.curr_code.ToString()),
                        new KeyValuePair<string, string>("[OVAL]",MasterEntity.roundup_total.ToString()),
                        new KeyValuePair<string, string>("[DOCDATE]", MasterEntity.po_date.ToString()),
                        new KeyValuePair<string, string>("[MODDT]", DateTime.Now.ToString()),
                        new KeyValuePair<string, string>("[PREF]", (MasterEntity.supplier_ref ?? "").ToString() + " Dated: " + (MasterEntity.supplier_ref_date?.ToShortDateString())), //MasterEntity.cust_ref_date.HasValue ? MasterEntity.cust_ref_date.Value.ToString() : string.Empty;
                        new KeyValuePair<string, string>("[INCO]", ((MasterEntity.incoterms ?? "") + ", " + (MasterEntity.incoterm2 ?? ""))),
                        new KeyValuePair<string, string>("[ITEM_TABLE]", xx),
                    };

                    foreach (KeyValuePair<string, string> kvp in kvpList)
                    {
                        VarData.subject = VarData.subject.Replace(kvp.Key, kvp.Value);
                        VarData.msg_body = VarData.msg_body.Replace(kvp.Key, kvp.Value);
                    }
                    if(ind_value=="AUTO" && doc_cat_vm=="IN" && (!string.IsNullOrWhiteSpace(PartyEmailId) || !string.IsNullOrWhiteSpace(PersonEmailId))) // if it is inquiry/RFQ to upplier and Auto RQQ then add suppliers email id to TO section
                    {
                        VarData.to_mail_id = (PartyEmailId ?? "") + (PartyEmailId == PersonEmailId ? "" : (";" + PersonEmailId));
                    }
                    VarData.cc_mail_id = (VarData.cc_mail_id ?? "") + ";" + (AppSessionState.EmpEmailId ?? "") + (MasterEntity.EmpEmailId == AppSessionState.EmpEmailId ? "" : (";" + MasterEntity.EmpEmailId));
                    Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, VarData.to_mail_id, VarData.cc_mail_id, VarData.bcc_mail_id, VarData.subject, VarData.msg_body, null);
                }
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void ClearValuesFromPopupCollection(object objCollection)
        {

        }
        private void ClearValuesFromReferencePopupCollection(object objCollection)
        {

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
        #endregion
        #region Event Handler
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (EntityChangeEnable == true)
            {
                if (e.PropertyName == "qty" || e.PropertyName == "unit_price" || e.PropertyName == "tax_id" || e.PropertyName == "active" || e.PropertyName == "discount")
                {
                    Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
                }
                if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = false;
                }
            }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                //if (e.NewItems != null && e.NewItems.Count != 0)
                //    foreach (PUR_T002_B item in e.NewItems)
                //        item.PropertyChanged += this.MyType_PropertyChanged;

                //if (e.OldItems != null && e.OldItems.Count != 0)
                //    foreach (PUR_T002_B item in e.OldItems)
                //        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (PUR_T002_B item in e.NewItems)
                    {
                        ItemEntityObject = item;
                        //Added items commented bacause it is adding on reference command
                        //item.line_id = dgItemsEntity.Count;
                        if (dgItemsEntity != null)
                        {
                            if (item.line_id == 0) // NOTE: This event calls twice and to protect this to increse same line_id twice, this if condition added on 14/12/2022, also update same logic to other VM. Also this logic added to check max value and then increase one, earlier it was assigning row count to new value but if there are 5 item and one deleted then it was assigning same number again.
                            {
                                int maxValue = dgItemsEntity.Max(x => x.line_id);
                                item.line_id = maxValue + 1;
                            }
                        }
                        else
                        {
                            item.line_id = 1;
                        }

                        item.symbol = MasterEntity.symbol;
                        item.p_term_code = MasterEntity.p_term_code;
                        item.PropertyChanged += EntityViewModelPropertyChanged;

                    }
                    if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0 && ItemEntityObject != null)
                    {
                        this.ErrorExist = ItemEntityObject.HasErrors;
                    }
                }

                if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                    this.ErrorExist = false; /*MasterEntity.HasErrors;*/
                    if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0 && ItemEntityObject != null)
                    {
                        this.ErrorExist = ItemEntityObject.HasErrors;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    PUR_T002_B temp = (PUR_T002_B)e.OldItems[0];
                    foreach (var itemToRemove in dgItemScheduleEntity.Where(x => (x.ItemCode == temp.ItemCode && x.id == 0 && (x.sku?.ToString() ?? "") == (temp.sku?.ToString() ?? ""))).ToList())
                    {
                        dgItemScheduleEntity.Remove(itemToRemove);
                    }
                    if (TotalDocumentTaxes.Count > 0) // Remove Taxes deleted item.
                    {
                        List<ACC_T006_B> copy = new List<ACC_T006_B>();
                        copy = TotalDocumentTaxes.ToList();
                        foreach (var tax in copy)
                        {
                            if (tax.ItemCode == temp.ItemCode && (tax.sku?.ToString() ?? "") == (temp.sku?.ToString() ?? "") && tax.item_row_id == temp.id)
                            {
                                TotalDocumentTaxes.Remove(tax);
                                Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
                            }
                        }
                        //TaxComputation(true);
                    }

                    // option for Multiple condition where clause
                    //Accounts.Where(acc => !(acc.ColA == "X" || (acc.ColA == "Y" && acc.ColB == "T"))).ToArray();
                    //OR
                    //Accounts
                    //        .Where(acc => !(acc.ColA == "X"))
                    //        .Where(acc => !(acc.ColA == "Y" && acc.ColB == "T"))
                    //        .ToArray();
                    foreach (PUR_T002_B item in e.OldItems)
                    {
                        item.PropertyChanged -= EntityViewModelPropertyChanged;
                    }
                    if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0 && ItemEntityObject != null)
                    {
                        this.ErrorExist = ItemEntityObject.HasErrors;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Move)
                {
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

        private void CollectionChangedNotifyForTerms(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (GEN_T011 item in e.NewItems)
                        item.PropertyChanged += this.EntityViewModelPropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (GEN_T011 item in e.OldItems)
                        item.PropertyChanged -= this.EntityViewModelPropertyChanged;

                /////////////////////////////////Temp Test End
                if (e.Action == NotifyCollectionChangedAction.Add) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (GEN_T011 item in e.NewItems)
                    {
                        item.id = 0;
                        item.active = "1";
                        item.comp_code = MasterEntity.comp_code;
                        item.doc_cat = (MasterEntity.doc_cat ?? doc_cat_vm);

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
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        void Schedule_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (SelectedItemScheduleEntity != null && ItemEntityObject != null)
                {
                    if (e.PropertyName == "qty")
                    {
                        if (MasterEntity.doc_type != "OP")
                        {
                            #region Check Schedule Qty Total should not exceed PO Qty.
                            //Check Schedule Qty Total should not exceed PO Qty.
                            decimal? TotalQtyOfScheduleForItem = 0;
                            TotalQtyOfScheduleForItem = dgItemScheduleEntity.Where(item => item.ItemCode == ItemEntityObject.ItemCode && item.sku == ItemEntityObject.sku && item.po_req_no == ItemEntityObject.req_no).Sum(item => item.confirm_qty);
                            decimal? POQty = ItemEntityObject.qty;  // pending error : index > count
                            if (TotalQtyOfScheduleForItem > POQty && MasterEntity.doc_cat != "OP" && MasterEntity.doc_cat != null)
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "PO Schedule Information";
                                showMessageService.Text = String.Format("Schedule quantity exceeding PO limit. extra Quantity will required additional Purchase Order", this.Title);
                                showMessageService.ShowMessage();
                            }
                        }
                        #endregion
                    }
                    else if (e.PropertyName == "expected_date")
                    {
                        #region Check Schedule Date greater than PO Date.
                        //Check Schedule Qty Total should not exceed PO Qty.
                        //List<PUR_T004_B> data = new List<PUR_T004_B>();
                        //data = dgItemScheduleEntity.Where(item => item.ItemCode == ItemEntityObject.ItemCode && item.sku == ItemEntityObject.sku && item.po_req_no == ItemEntityObject.req_no).ToList();
                        //var date = data.Select(x => x.expected_date);
                        //foreach (var verObj in date)
                        //{
                        //    var ScheduleDate = Convert.ToDateTime(verObj).Date;
                        //    var PoDate = Convert.ToDateTime(MasterEntity.po_date).Date;

                        //    if (sch_date < PoDate)
                        //    {
                        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        //        showMessageService.ButtonSetup = DialogButton.Ok;
                        //        showMessageService.Caption = "PO Schedule Information";
                        //        showMessageService.Text = String.Format("Schedule  Date Should be greater than PO Date.", this.Title);
                        //        showMessageService.ShowMessage();
                        //    }
                        //}

                        int index = dgItemScheduleEntity.IndexOf((PUR_T004_B)DataGridViewFilter.CurrentItem);
                        if (Convert.ToDateTime(dgItemScheduleEntity[index].expected_date).Date < Convert.ToDateTime(MasterEntity.po_date).Date)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "PO Schedule Information";
                            showMessageService.Text = String.Format("Schedule  Date Should be greater than PO Date.", this.Title);
                            showMessageService.ShowMessage();
                        }

                        #endregion
                    }
                    else if (e.PropertyName == "confirm_date" && MasterEntity.doc_cat== "PO" && MasterEntity.doc_cat == "QP")
                    {
                        if (Convert.ToDateTime(SelectedItemScheduleEntity.confirm_date).Date < Convert.ToDateTime(MasterEntity.po_date).Date)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "PO Schedule Information";
                            showMessageService.Text = String.Format("Schedule Confirmation Date Should be greater than Document Date.", this.Title);
                            showMessageService.ShowMessage();
                        }
                    }
                    if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0 && ItemEntityObject != null)
                    {
                        this.ErrorExist = ItemEntityObject.HasErrors;
                    }
                    MasterEntity.ts_code = ts_code_vm;
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
        private void CollectionChangedNotifyForSchedule(object sender, NotifyCollectionChangedEventArgs e)
        {
            //////////////////////////////////Temp Test
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (PUR_T004_B item in e.NewItems)
                    item.PropertyChanged += this.Schedule_PropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (PUR_T004_B item in e.OldItems)
                    item.PropertyChanged -= this.Schedule_PropertyChanged;

            /////////////////////////////////Temp Test End
            if (e.Action == NotifyCollectionChangedAction.Add && dgItemsEntity.Count > 0 && ItemEntityObject != null) // Schedule can only enable to add if items exists in Items Entity.
            {
                try
                {
                    foreach (PUR_T004_B item in e.NewItems)
                    {
                        //Adde items Schedules Default Values from Items Entity
                        if (ItemEntityObject.id > 0)
                        {
                            item.po_item_row_id = ItemEntityObject.id;
                        }
                        else
                        {
                            item.so_item_id = 0;
                        }
                        item.id = 0;
                        item.ItemCode = ItemEntityObject.ItemCode;
                        item.line_id = dgItemScheduleEntity.Count;
                        item.sku = ItemEntityObject.sku;
                        item.sku_desc = ItemEntityObject.sku_desc;
                        item.po_no = ItemEntityObject.po_no;
                        item.qty = ItemEntityObject.qty;

                        var temp = (from o in dgItemScheduleEntity where o.item_line_id == ItemEntityObject.line_id select o).ToList();
                        if (temp.Count > 0)
                        {
                            foreach (var o in temp)
                            {
                                //item.qty = o.qty - Convert.ToDecimal(o.confirm_qty); // commented on 09-06-2023 because it was calculating wrong
                                item.bal_qty = o.qty - Convert.ToDecimal(o.confirm_qty);
                                item.po_req_no = o.po_req_no;
                            }
                        }
                        item.rec_qty = 0;
                        item.confirm_qty = item.qty;
                        item.confirm_date = ItemEntityObject.date_planned;
                        //item.expected_date = ItemEntityObject.date_planned;
                        item.t_status = MasterEntity.t_status;
                        item.t_display = (from o in MC.t_statusList where o.t_status == item.t_status select o.t_display).FirstOrDefault();
                        item.active = true;
                        item.editby = AppSessionState.UserID;
                        item.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.rate = ItemEntityObject.unit_price;
                        item.unit_code = ItemEntityObject.unit_code;
                        item.del_address_id = ItemEntityObject.del_address_id;
                        item.bill_address_id = ItemEntityObject.bill_address_id;
                        item.add_code_del = MasterEntity.add_code_del;
                        item.add_code_bil = MasterEntity.add_code_bil;
                        //item.tr_mode = item.tr_mode;
                        //item.tr_mode = item.tr_type;
                        //item.tr_mode = item.transporter_cd;
                        //item.ref_doc_no = MasterEntity.ref_doc_no; // need correct info of Schedule Grid
                        //item.po_req_no = ItemEntityObject.req_no; // need correct info of Schedule Grid
                        item.bom_no = ItemEntityObject.bom_no;
                        item.client = AppSessionState.client;
                        item.item_line_id = ItemEntityObject.line_id;
                        

                        var tempData = dgItemScheduleEntity.Where(X => X.item_line_id == item.item_line_id);
                        if (tempData.Count() > 0)
                        {
                            dgSelectedIndexItemSchedule = tempData.Count() - 1;
                        }
                        if (dgItemScheduleEntity.Count > 0 && dgSelectedIndexItemSchedule > 0)
                        {
                            //item.po_req_no = dgItemScheduleEntity[dgSelectedIndexItemSchedule-1].po_req_no;
                            //item.pur_req_item_row_id = dgItemScheduleEntity[dgSelectedIndexItemSchedule-1].pur_req_item_row_id;
                            item.ship_mode = dgItemScheduleEntity[dgSelectedIndexItemSchedule - 1].ship_mode;
                            item.bill_address_id = dgItemScheduleEntity[dgSelectedIndexItemSchedule - 1].bill_address_id;
                            item.del_address_id = dgItemScheduleEntity[dgSelectedIndexItemSchedule - 1].del_address_id;
                        }
                        item.PropertyChanged += EntityViewModelPropertyChanged;
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
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                //dgItemScheduleEntity.Remove(x => x.)
                //PUR_T002_B temp = (PUR_T002_B)e.NewItems[0];
                //foreach (var itemToRemove in dgItemScheduleEntity.Where(x => x.ItemCode == temp.ItemCode).ToList())
                //{
                //    dgItemScheduleEntity.Remove(itemToRemove);
                //}
            }
            if (e.Action == NotifyCollectionChangedAction.Move)
            {

            }
        }
        private void CollectionChangedNotifyForTotalTaxes(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (ACC_T006_B item in e.NewItems)
                        item.PropertyChanged += this.Schedule_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (ACC_T006_B item in e.OldItems)
                        item.PropertyChanged -= this.Schedule_PropertyChanged;

                /////////////////////////////////Temp Test End
                if (e.Action == NotifyCollectionChangedAction.Add && dgItemsEntity.Count > 0) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (ACC_T006_B item in e.NewItems)
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
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                        item.exch_rate = MasterEntity.ex_rate;
                        item.local_curr = AppSessionState.CntryCurncy;
                        item.curr_code = MasterEntity.curr_code;

                        item.client = AppSessionState.client;
                        item.exch_rate = MasterEntity.ex_rate;

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
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
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
                if (e.Action == NotifyCollectionChangedAction.Add && ItemEntityObject != null) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (ACC_T006_D item in e.NewItems)
                    {
                        item.ItemCode = ItemEntityObject.ItemCode;
                        item.sku = ItemEntityObject.sku;
                        item.item_line_id = ItemEntityObject.line_id;

                        item.qty = ItemEntityObject.qty;
                        item.incoterm_value_doc = ItemEntityObject.net_value;
                        item.incoterm_value_local = ItemEntityObject.local_net_value;
                        item.PartyId = MasterEntity.PartyId;
                        item.exch_rate = MasterEntity.ex_rate;
                        item.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.active = true;
                        item.con_type = "LIC";
                        item.trns_key_code = "LIC";
                        item.incoterms = MasterEntity.incoterms;
                        item.req_no = ItemEntityObject.req_no;
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
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }

        }
        private void CollectionChangedNotifyForComponant(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && dgItemsEntity.Count > 0 && ItemEntityObject != null) // Schedule can only enable to add if items exists in Items Entity.
            {
                try
                {
                    foreach (PUR_T002_C item in e.NewItems)
                    {
                        if (ItemEntityObject.id > 0)
                        {
                            item.po_item_row_id = ItemEntityObject.id;
                        }
                        else
                        {
                            item.po_item_row_id = 0;
                        }
                        item.id = 0;
                        item.line_id = dgComponantEntity.Count;
                        item.ref_item_line_id = ItemEntityObject.line_id;
                        item.po_no = MasterEntity.po_no;
                        item.active = true;
                        item.t_status = MasterEntity.t_status;
                        item.t_display = (from o in MC.t_statusList where o.t_status == item.t_status select o.t_display).FirstOrDefault();
                        item.client = AppSessionState.client;
                        item.comp_code = MasterEntity.comp_code;
                        item.location_id = ItemEntityObject.location_Id;

                        item.bom_no = ItemEntityObject.bom_no;
                        //item.bom_item_row_id = ItemEntityObject.bo;
                        item.order_no = MasterEntity.po_no;
                        item.order_item_row_id = ItemEntityObject.id;
                    }
                }
                catch (Exception ex)
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
                }
            }

            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                //dgItemScheduleEntity.Remove(x => x.)
                //PUR_T002_B temp = (PUR_T002_B)e.NewItems[0];
                //foreach (var itemToRemove in dgItemScheduleEntity.Where(x => x.ItemCode == temp.ItemCode).ToList())
                //{
                //    dgItemScheduleEntity.Remove(itemToRemove);
                //}
            }
            if (e.Action == NotifyCollectionChangedAction.Move)
            {

            }
        }
        void Componant_PropertyChanged(object sender, PropertyChangedEventArgs e)
        { }
        void ModelUpdated_Tax(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes 
            //if (sender.ToString() == "tax_amount" || sender.ToString() == "gl_code" || sender.ToString() == "tax_name")
            //{
            //    if (TotalDocumentTaxes.Count > 0)
            //    {
            //        if (TotalDocumentTaxes[dgSelectedIndexTaxSummury].tax_name == null || TotalDocumentTaxes[dgSelectedIndexTaxSummury].tax_name.ToString().Trim() == "")
            //        {
            //            TotalDocumentTaxes[dgSelectedIndexTaxSummury].tax_name = "CASH";
            //        }

            //        //TaxComputation(true);
            //    }
            //}

            //int x = TotalDocumentTaxes.Count();

        }
        void ModelUpdatedShedule(object sender, EventArgs e)
        {
            try
            {
                //This will get called when the property of an object inside the collection changes
                if (sender.ToString() == "qty" && NewRecord == true && SelectedItemScheduleEntity != null)
                {
                    var SalesPurchaseDoc = (from o in MC.reference_docList where o.doc_cat == "RQ" select o).ToList();
                    List<PUR_T002_P_RefeDoc> RequisitionNo = SalesPurchaseDoc;

                    foreach (var Item in RequisitionNo)
                    {
                        if (MasterEntity.ref_doc_no == Item.po_no && dgItemScheduleEntity.Count > 0)
                        {

                            SelectedItemScheduleEntity.po_req_no = MasterEntity.ref_doc_no;
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
        private void QuotationDateMassage()
        {
            try
            {



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




        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                //This will get called when the property of an object inside the collection changes
                this.ErrorExist = false;/*MasterEntity.HasErrors;*/
                if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0 && ItemEntityObject != null)
                {
                    this.ErrorExist = ItemEntityObject.HasErrors;
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
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            if (EntityChangeEnable == true || sender.ToString() == "p_term_code")
            {
                if(sender.ToString() == "p_term_code")
                {
                    MasterEntity.instructions = null;
                    if (MC.PAY_TERMD != null)
                    {
                        if (MC.PAY_TERMD.Count > 0)
                        {
                            var ptd_obj = MC.PAY_TERMD.Where(b => b.pt_code == MasterEntity.p_term_code).ToList();
                            if(ptd_obj != null)
                            {
                                if (ptd_obj.Count > 0)
                                {
                                    string strInstruction = "Payment Brekup";
                                    foreach (var item in ptd_obj)
                                    {
                                        if (item.pay_amount.HasValue && MasterEntity.roundup_total.HasValue)
                                        {
                                            //decimal? percent = Math.Round(((item.pay_amount * MasterEntity.roundup_total) / 100),2);
                                            decimal percent = Math.Round(Convert.ToDecimal((item.pay_amount * MasterEntity.roundup_total) / 100), 2);
                                            strInstruction = strInstruction + System.Environment.NewLine + percent.ToString() + " on " + item.days.ToString() + " Days";
                                        }
                                    }
                                    MasterEntity.instructions = strInstruction;
                                }
                            }
                        }
                    }
                }
            }
            this.ErrorExist = false;/* MasterEntity.HasErrors;*/
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
                        Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
                        UpdateQtyInLicence();
                        if (dgItemScheduleEntity.Count > 0 && dgItemsEntity.Count > 0 && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < dgItemsEntity.Count && dgSelectedIndexItem < dgItemScheduleEntity.Count && NewRecord == true && ItemEntityObject != null)
                        {
                            var item = dgItemScheduleEntity.FirstOrDefault(i => i.item_line_id == ItemEntityObject.line_id);
                            if (item != null)
                            {
                                item.qty = ItemEntityObject.qty ?? 0;
                            }
                        }

                    }
                    this.ErrorExist = false;/*MasterEntity.HasErrors;*/
                    if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0 && ItemEntityObject != null)
                    {
                        this.ErrorExist = ItemEntityObject.HasErrors;
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
        void ModelUpdated_Schedule(object sender, EventArgs e)
        {
            if (EntityChangeEnable == true)
            {
                //This will get called when the property of an object inside the collection changes ModelUpdated_TaxSummury
                if ((sender.ToString() == "confirm_qty" || sender.ToString() == "qty") && ItemEntityObject != null && SelectedItemScheduleEntity != null)
                {
                    int ItemIndex = 0;
                    decimal? ItemQty = 0;
                    if (ItemEntityObject.line_id > 0 && ItemEntityObject.qty.HasValue == true)
                    {
                        ItemIndex = ItemEntityObject.line_id;
                        ItemQty = ItemEntityObject.qty;

                        foreach (var item in dgItemScheduleEntity)
                        {
                            if (item.item_line_id == ItemIndex)
                            {
                                item.bal_qty = ItemQty - Convert.ToDecimal(item.confirm_qty);
                                ItemQty = ItemQty - item.confirm_qty;
                            }
                        }
                    }



                    //if (dgItemScheduleEntity.Count > dgSelectedIndexItemSchedule && dgSelectedIndexItemSchedule >= 0)
                    //{

                    //    var temp = (from o in dgItemScheduleEntity where o.ItemCode == ItemEntityObject.ItemCode && o.item_line_id == ItemEntityObject.line_id select o).ToList();
                    //    if (temp.Count > 0 && dgSelectedIndexItemSchedule < temp.Count)
                    //    {
                    //        foreach (var o in temp)
                    //        {
                    //            temp[dgSelectedIndexItemSchedule].bal_qty = o.qty - Convert.ToDecimal(o.confirm_qty);
                    //        }
                    //    }
                    //}
                }
            }
        }

        #endregion
        #region Command Handler
        private void SelectRefBulk(object InputValue) // can be remove this function, we hahe include this code in Function of OK Button below the popup window.
        {
            try
            {
                STD_LIST_BE POPUPEntityObject = null;
                //DocumentList = "";
                if (InputValue != null && ((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    foreach (var item in MC.PR_LIST)
                    {
                        //if (item.select == true)
                        //{
                        //    DocumentList = DocumentList + item.id.ToString() + ",";
                        //}
                        if (item.doc_no == POPUPEntityObject.doc_no)
                        {
                            item.selected = true;
                        }
                    }
                    PR_ITEM_COLL = CollectionViewSource.GetDefaultView(MC.PR_LIST);
                    PR_ITEM_COLL.Filter = new Predicate<object>(FilterRequisitionNo);
                }
            }
            catch (Exception ex)
            {
            }
        }

        private void AddSelectedRef(object InputValue)
        {
            try
            {
                PUR_T002_P_RefeDoc POPUPEntityObject = null;
                string Request;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.reference_docList.Where(x => x.po_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<PUR_T002_P_RefeDoc>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PUR_T002_P_RefeDoc>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    if (POPUPEntityObject.t_status != "09") // Does not required this check as we do not load unwanted reference in popup.
                    {
                        MasterEntity.ref_doc_no = POPUPEntityObject.po_no;
                        ref_doc_cat = POPUPEntityObject.doc_cat;


                        DocumentList = "";
                        if (ref_doc_cat == "RQ")
                        {

                            refdoctempa = (from o in MC.reference_docList where o.doc_cat == "RQ" select o).ToList();
                            ReferenceDocRQCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                            ReferenceDocRQCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                            var refdoctempIN = (from o in MC.reference_docList where o.doc_cat == "IN" select o).ToList();
                            foreach (var item in refdoctempIN)
                            {
                                item.Select = false;
                            }
                            ReferenceDocINCollection = CollectionViewSource.GetDefaultView(refdoctempIN);
                            ReferenceDocINCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                            var refdoctempQP = (from o in MC.reference_docList where o.doc_cat == "QP" select o).ToList();
                            foreach (var item in refdoctempQP)
                            {
                                item.Select = false;
                            }
                            ReferenceDocQPCollection = CollectionViewSource.GetDefaultView(refdoctempQP);
                            ReferenceDocQPCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                        }
                        else if (ref_doc_cat == "IN")
                        {
                            refdoctempa = (from o in MC.reference_docList where o.doc_cat == "IN" select o).ToList();
                            ReferenceDocINCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                            ReferenceDocINCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                            var refdoctempRQ = (from o in MC.reference_docList where o.doc_cat == "RQ" select o).ToList();
                            foreach (var item in refdoctempRQ)
                            {
                                item.Select = false;
                            }
                            ReferenceDocRQCollection = CollectionViewSource.GetDefaultView(refdoctempRQ);
                            ReferenceDocRQCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                            var refdoctempQP = (from o in MC.reference_docList where o.doc_cat == "QP" select o).ToList();
                            foreach (var item in refdoctempQP)
                            {
                                item.Select = false;
                            }
                            ReferenceDocQPCollection = CollectionViewSource.GetDefaultView(refdoctempQP);
                            ReferenceDocQPCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                        }
                        else if (ref_doc_cat == "QP")
                        {
                            refdoctempa = (from o in MC.reference_docList where o.doc_cat == "QP" select o).ToList();
                            ReferenceDocQPCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                            ReferenceDocQPCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                            var refdoctempIN = (from o in MC.reference_docList where o.doc_cat == "IN" select o).ToList();
                            foreach (var item in refdoctempIN)
                            {
                                item.Select = false;
                            }
                            ReferenceDocINCollection = CollectionViewSource.GetDefaultView(refdoctempIN);
                            ReferenceDocINCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                            var refdoctempRQ = (from o in MC.reference_docList where o.doc_cat == "RQ" select o).ToList();
                            foreach (var item in refdoctempRQ)
                            {
                                item.Select = false;
                            }
                            ReferenceDocRQCollection = CollectionViewSource.GetDefaultView(refdoctempRQ);
                            ReferenceDocRQCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                        }

                        var refdoc = from o in refdoctempa
                                     where o.partyId == POPUPEntityObject.partyId
                                            && o.party_name == POPUPEntityObject.party_name
                                            && o.po_code == POPUPEntityObject.po_code
                                            && o.curr_code == POPUPEntityObject.curr_code
                                            && o.del_address == POPUPEntityObject.del_address
                                            && o.doc_cat == POPUPEntityObject.doc_cat
                                            && o.p_term_code == POPUPEntityObject.p_term_code
                                            && o.incoterms == POPUPEntityObject.incoterms
                                            && o.country_nm_s == POPUPEntityObject.country_nm_s
                                     select o;

                        foreach (var item in refdoc)
                        {
                            if (item.Select == true)
                            {
                                DocumentList = DocumentList + "," + item.po_no;
                            }
                        }
                        DocumentList = DocumentList.ToString().TrimStart(new char[] { ',' });
                        if (ref_doc_cat == "RQ")
                        {
                            if (POPUPEntityObject.Select == true)
                            {
                                ReferenceDocRQCollection = CollectionViewSource.GetDefaultView(refdoc);
                                ReferenceDocRQCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                            }
                        }
                        else if (ref_doc_cat == "IN")
                        {
                            if (POPUPEntityObject.Select == true)
                            {
                                ReferenceDocINCollection = CollectionViewSource.GetDefaultView(refdoc);
                                ReferenceDocINCollection = CollectionViewSource.GetDefaultView(refdoc);
                            }
                        }
                        else if (ref_doc_cat == "QP")
                        {
                            if (POPUPEntityObject.Select == true)
                            {
                                ReferenceDocQPCollection = CollectionViewSource.GetDefaultView(refdoc);
                                ReferenceDocQPCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                            }
                        }
                        if (DocumentList == "")
                        {
                            MasterEntity.ref_doc_no = null;
                            MasterEntity.ref_doc_date = null;
                            ref_doc_cat = null;

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
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }

        private void ExecuteRFQ(object item_code) // Sales BOM fetch and add all componant with line category
        {
            try
            {
                if(MC.partyList != null)
                {
                    if (MC.partyList.Count > 0)
                    {
                        InquiryActionResult<PUR_T002_A> result = new WindowViewModel<PUR_T002_A>.InquiryActionResult<PUR_T002_A>();

                        foreach (var party in MC.partyList) // iterate thriugh selected party to send RFQ
                        {
                            if (party.selected==true)
                            {
                                OnCreateAction(result);
                                ind_value = "AUTO";
                                InsertParty(party.party_code, NewRecord);
                                CreateDocumentByReferenceDocumentNumber("PR_REFERENCE", "RFQ");
                                OnSaveAction(result);

                                
                            }
                        }
                        RemoveRefDoc(null);
                        foreach (var item in MC.partyList.ToList())
                        {
                            if (item.selected == true) // if this call during Auto RFQ then auto function will not work after first RFQ because all selected item will get clear so checking ind_value also. Call this function after completion of Auto RFQ.
                            {
                                item.selected=false;
                            }
                        }
                        PartyCollection = CollectionViewSource.GetDefaultView(MC.partyList);
                        PartyCollection.Filter = new Predicate<object>(FilterParty);

                        if (ind_value == "AUTO" && !string.IsNullOrWhiteSpace(MasterEntity.po_no) && MasterEntity.active == true)
                        {
                            SelectedTabIndexItem = 0; // This is for shifting focus from Editor control
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("RFQ sent Successfully ........");
                            showMessageService.ShowMessage();
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        
        // This function will add item into PUR_T002_B as well as PUR_T004_B if duplicate item found with different Requisition or Schedule of Requisition.
        // PUR_T002_B will maintain single item and detail assignment of Item with requisition and schedule will be maintain in PUR_T004_B Entiry.
        private void CreateDocumentByReferenceDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string DocumentList = "";
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null && !string.IsNullOrWhiteSpace(MasterEntity.PartyId) && MasterEntity.po_date.HasValue) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    foreach (var item in MC.PR_LIST)
                    {
                        if (item.selected == true)
                        {
                            DocumentList = DocumentList + item.id.ToString() + ",";
                        }
                    }
                    if (DocumentList == null || DocumentList == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Refernece Selection";
                        showMessageService.Text = String.Format("Please Select Referance No", this.Title);
                        showMessageService.ShowMessage();
                    }
                    else
                    {

                        if (ParameterObject.ToString() == "PR_REFERENCE" && MasterEntity.t_status == (from o in MC.t_statusList where o.ind_default == "1" select o.t_status).FirstOrDefault())
                        {
                            if (MasterEntity.doc_type == "PO") //if (ParameterReference == "ParameterReference") // Only get this function call if doc_cat is Purchase Order, for Inquiry and quotation this is not advisable. From Builk RFQ it should not work so we have passed different vaue.
                            {
                                string Request = "GET_CATLOG!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + (MasterEntity.doc_type ?? doc_cat_vm) + "!@" + Convert.ToDateTime(MasterEntity.po_date).ToString("MM/dd/yyyy") + "!@" + MasterEntity.PartyId + "!@" + DocumentList;
                                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, Request, "PRO_T002_BL", "PRO", "GET_CATLOG", 0, "");
                                //MC.CATALOG_LIST = MCTemp.CATALOG_LIST;
                                if (MC.CATALOG_LIST != null)
                                {
                                    if (MC.CATALOG_LIST.Count > 0)
                                    {
                                        MC.CATALOG_LIST.Clear();
                                        MC.CATALOG_LIST = MCTemp.CATALOG_LIST;
                                    }
                                    else
                                    {
                                        MC.CATALOG_LIST = MCTemp.CATALOG_LIST;
                                    }
                                }
                            }
                            if (dgItemsEntity.Count == 0)
                            {
                                dgSelectedIndexItem = -1;
                            }

                            foreach (var item in MC.PR_LIST)
                            {
                                if (item.selected == true)
                                {
                                    ADM_M0061_A catalog_obj = null;
                                    if (MC.CATALOG_LIST != null)
                                    {
                                        if (MC.CATALOG_LIST.Count > 0) // Get Price from Catlog if exists. id to id comparision for accuracy to select exactly same item from Requisition reference and Catlog. id value in catlog collection is the same as requisition id value.
                                        {
                                            try
                                            { catalog_obj = MC.CATALOG_LIST.Where(x => x.id.ToString().Equals(item.id.ToString(), StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                                            catch (Exception ex) { }
                                        }
                                    }

                                    var InputValueIfExists = dgItemsEntity.Where(x => x.ref_item_row_id == item.id && x.ItemCode == item.item_code && x.sku == item.sku && x.del_address_id == MasterEntity.del_address_id && (x.unit_price ?? 0) == (item.cost ?? 0)).FirstOrDefault(); // Prefer Primary Key for this instruction.
                                    int intIndex = dgItemsEntity.IndexOf(dgItemsEntity.Where(x => x.ref_item_row_id == item.id && x.ItemCode == item.item_code && x.sku == item.sku && x.del_address_id == MasterEntity.del_address_id && (x.unit_price ?? 0) == (item.cost ?? 0)).FirstOrDefault()); // Prefer Primary Key for this instruction.
                                    var CheckIfExistsAlready = dgItemScheduleEntity.Where(x => x.pur_req_item_row_id == item.id && x.ItemCode == item.item_code).FirstOrDefault(); // check wether this item exists in Order or not for PR row id if not then first time or if yes then re addition should not happen.
                                    if (InputValueIfExists == null && CheckIfExistsAlready == null) // If Last condition !string.IsNullOrWhiteSpace(item.req_no) satisfy then PR is exists for item if not then item can add in PO without PR, In Item Master Indicator is set for PO witout PR. and item will get load in reference popup.
                                    {
                                        PUR_T002_B ItemObject = new PUR_T002_B();
                                        MasterEntity.po_code = MasterEntity.po_code ?? item.po_code;
                                        MasterEntity.pg_code = MasterEntity.pg_code ?? item.pg_code;
                                        ItemObject.id = 0;
                                        //ItemObject.line_id = dgItemsEntity.Count;
                                        ItemObject.ref_doc_no = item.doc_no;
                                        ItemObject.ref_doc_date = item.doc_date;
                                        ItemObject.ref_doc_type = item.doc_type;
                                        ItemObject.ref_item_line_id = (int)item.line_id;
                                        ItemObject.ref_item_row_id = item.id;
                                        ItemObject.ItemCode = item.item_code;
                                        ItemObject.sku = item.sku;
                                        ItemObject.sku_desc = item.sku_desc;
                                        ItemObject.textdata = item.long_text;
                                        ItemObject.item_cat = item.item_cat;
                                        ItemObject.description = item.item_name;


                                        // Catlog value assignment section.
                                        if (catalog_obj != null)
                                        {
                                            ItemObject.unit_price = (catalog_obj.unit_price ?? item.cost);
                                            ItemObject.tax_id = catalog_obj.tax_code;
                                            ItemObject.unit_code = catalog_obj.unit_code;
                                            ItemObject.discount = catalog_obj.discount;
                                            ItemObject.discount_type = catalog_obj.disc_type;
                                            ItemObject.description = ((catalog_obj.item_code_party ?? "") + " " + (catalog_obj.item_name ?? ItemObject.description)).Trim();

                                            if (!MasterEntity.ex_rate.HasValue)
                                            {
                                                MasterEntity.ex_rate = catalog_obj.exch_rate_pur;
                                            }
                                        }
                                        else
                                        {
                                            ItemObject.unit_price = item.cost;
                                            ItemObject.unit_code = item.unit_code;
                                        }
                                        ItemObject.qty = item.qty ?? 1;
                                        ItemObject.date_planned = item.plan_date;
                                        ItemObject.t_status = MasterEntity.t_status;
                                        //ItemObject.t_display = "Draft";
                                        item.t_display = (from o in MC.t_statusList where o.t_status == item.t_status select o.t_display).FirstOrDefault();
                                        ItemObject.comp_code = MasterEntity.comp_code;
                                        ItemObject.location_Id = MasterEntity.location_Id;
                                        ItemObject.textdata = item.long_text;
                                        ItemObject.per_req_item_row_id = item.id;
                                        ItemObject.active = true;
                                        ItemObject.req_no = item.doc_no;
                                        ItemObject.requester_name = item.emp_name;
                                        ItemObject.pur_req_item = item.id;
                                        ItemObject.pur_req_no = item.doc_no;
                                        ItemObject.rec_plant = item.location_id;
                                        ItemObject.bom_no = item.bom_no;
                                        ItemObject.del_address_id = MasterEntity.del_address_id;
                                        ItemObject.bill_address_id = MasterEntity.bill_address_id;
                                        ItemObject.p_term_code = MasterEntity.p_term_code;
                                        //ItemObject.p_term_code = MasterEntity.p_term_code;
                                        ItemObject.user_source1 = item.user_source1;
                                        ItemObject.user_source2 = item.user_source2;
                                        ItemObject.bid_inv_no = "New";
                                        ItemObject.rel_billing = "Y";
                                        ItemObject.rel_delivery = "Y";

                                        
                                        dgItemsEntity.Add(ItemObject);
                                        

                                        dgSelectedIndexItem = dgItemsEntity.Count - 1;
                                        if (ItemObject.qty > 0 && ItemObject.unit_price > 0)
                                        {
                                            Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
                                        }
                                        if (!string.IsNullOrWhiteSpace(ItemObject.bom_no))
                                        {
                                            ItemEntityObject = ItemObject;
                                            InsertQty(ItemObject.ItemCode);
                                        }

                                        PUR_T004_B ScheduleItemEntityObject = new PUR_T004_B();
                                        ScheduleItemEntityObject.id = 0;
                                        ScheduleItemEntityObject.item_line_id = ItemObject.line_id;
                                        ScheduleItemEntityObject.po_no = MasterEntity.po_no;
                                        ScheduleItemEntityObject.line_id = dgItemScheduleEntity.Count;
                                        ScheduleItemEntityObject.ItemCode = item.item_code;
                                        ScheduleItemEntityObject.sku = item.sku;
                                        ScheduleItemEntityObject.sku_desc = item.sku_desc;
                                        ScheduleItemEntityObject.qty = item.qty;
                                        ScheduleItemEntityObject.expected_date = item.plan_date;
                                        ScheduleItemEntityObject.confirm_date = item.plan_date;
                                        ScheduleItemEntityObject.confirm_qty = item.qty;
                                        ScheduleItemEntityObject.t_status = MasterEntity.t_status;
                                        ScheduleItemEntityObject.t_display = (from o in MC.t_statusList where o.t_status == item.t_status select o.t_display).FirstOrDefault();
                                        ScheduleItemEntityObject.active = true;
                                        ScheduleItemEntityObject.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                                        ScheduleItemEntityObject.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                                        ScheduleItemEntityObject.unit_code = dgItemsEntity[dgSelectedIndexItem].unit_code;
                                        ScheduleItemEntityObject.rate = dgItemsEntity[dgSelectedIndexItem].unit_price ?? item.cost;
                                        ScheduleItemEntityObject.po_req_no = item.doc_no;
                                        ScheduleItemEntityObject.po_item_row_id = dgItemsEntity[dgSelectedIndexItem].id;
                                        //ScheduleItemEntityObject.tr_mode = item.tr_mode;
                                        //ScheduleItemEntityObject.tr_mode = item.tr_type;
                                        //ScheduleItemEntityObject.tr_mode = item.transporter_cd;
                                        ScheduleItemEntityObject.ref_doc_no = item.doc_no;
                                        ScheduleItemEntityObject.ref_doc_cat = item.doc_cat;
                                        ScheduleItemEntityObject.ref_doc_type = item.doc_type;
                                        ScheduleItemEntityObject.ref_doc_date = item.doc_date;
                                        ScheduleItemEntityObject.pur_req_item_row_id = item.id;
                                        ScheduleItemEntityObject.client = AppSessionState.client;
                                        //ScheduleItemEntityObject.del_address_id = MasterEntity.del_address_id;
                                        //ScheduleItemEntityObject.bill_address_id = MasterEntity.bill_address_id;
                                        ScheduleItemEntityObject.del_address_id = dgItemsEntity[dgSelectedIndexItem].del_address_id;
                                        ScheduleItemEntityObject.bill_address_id = dgItemsEntity[dgSelectedIndexItem].bill_address_id;
                                        ScheduleItemEntityObject.add_code_bil = MasterEntity.add_code_bil;
                                        ScheduleItemEntityObject.add_code_del = MasterEntity.add_code_del;
                                        ScheduleItemEntityObject.bom_no = dgItemsEntity[dgSelectedIndexItem].bom_no;
                                        ScheduleItemEntityObject.editby = AppSessionState.UserID;

                                        dgItemScheduleEntity.Add(ScheduleItemEntityObject);
                                    }
                                    else if (CheckIfExistsAlready == null) // && !string.IsNullOrWhiteSpace(item.req_no)
                                    {
                                        dgItemsEntity[intIndex].qty = dgItemsEntity[intIndex].qty + item.qty;
                                        int intIndexSchedule = dgItemScheduleEntity.IndexOf(dgItemScheduleEntity.Where(x => x.ItemCode == item.item_code && x.sku == item.sku && x.expected_date == item.plan_date && x.po_req_no == item.doc_no && x.pur_req_item_row_id == item.id).FirstOrDefault());
                                        if (intIndexSchedule == -1)
                                        {
                                            PUR_T004_B ScheduleItemEntityObject = new PUR_T004_B();
                                            ScheduleItemEntityObject.id = 0;
                                            ScheduleItemEntityObject.item_line_id = dgItemsEntity[dgSelectedIndexItem].line_id;
                                            ScheduleItemEntityObject.po_no = MasterEntity.po_no;
                                            ScheduleItemEntityObject.line_id = dgItemScheduleEntity.Count;
                                            ScheduleItemEntityObject.ItemCode = item.item_code;
                                            ScheduleItemEntityObject.sku = item.sku;
                                            ScheduleItemEntityObject.sku_desc = item.sku_desc;
                                            ScheduleItemEntityObject.qty = item.qty;
                                            ScheduleItemEntityObject.expected_date = item.plan_date;
                                            ScheduleItemEntityObject.confirm_date = item.plan_date;
                                            ScheduleItemEntityObject.confirm_qty = item.qty;
                                            ScheduleItemEntityObject.t_status = MasterEntity.t_status;
                                            ScheduleItemEntityObject.t_display = (from o in MC.t_statusList where o.t_status == ScheduleItemEntityObject.t_status select o.t_display).FirstOrDefault();
                                            ScheduleItemEntityObject.active = true;
                                            ScheduleItemEntityObject.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                                            ScheduleItemEntityObject.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                                            ScheduleItemEntityObject.unit_code = dgItemsEntity[dgSelectedIndexItem].unit_code;
                                            ScheduleItemEntityObject.rate = dgItemsEntity[dgSelectedIndexItem].unit_price ?? item.cost;
                                            ScheduleItemEntityObject.po_req_no = item.doc_no;
                                            ScheduleItemEntityObject.po_item_row_id = dgItemsEntity[dgSelectedIndexItem].id;
                                            //ScheduleItemEntityObject.tr_mode = item.tr_mode;
                                            //ScheduleItemEntityObject.tr_mode = item.tr_type;
                                            //ScheduleItemEntityObject.tr_mode = item.transporter_cd;
                                            ScheduleItemEntityObject.ref_doc_no = item.doc_no;
                                            ScheduleItemEntityObject.ref_doc_cat = item.doc_cat;
                                            ScheduleItemEntityObject.ref_doc_type = item.doc_type;
                                            ScheduleItemEntityObject.ref_doc_date = item.doc_date;
                                            ScheduleItemEntityObject.pur_req_item_row_id = item.id;
                                            ScheduleItemEntityObject.client = AppSessionState.client;
                                            //ScheduleItemEntityObject.del_address_id = MasterEntity.del_address_id;
                                            //ScheduleItemEntityObject.bill_address_id = MasterEntity.bill_address_id;
                                            ScheduleItemEntityObject.del_address_id = dgItemsEntity[dgSelectedIndexItem].del_address_id;
                                            ScheduleItemEntityObject.bill_address_id = dgItemsEntity[dgSelectedIndexItem].bill_address_id;
                                            ScheduleItemEntityObject.add_code_bil = MasterEntity.add_code_bil;
                                            ScheduleItemEntityObject.add_code_del = MasterEntity.add_code_del;
                                            ScheduleItemEntityObject.bom_no = dgItemsEntity[dgSelectedIndexItem].bom_no;
                                            ScheduleItemEntityObject.editby = AppSessionState.UserID;

                                            dgItemScheduleEntity.Add(ScheduleItemEntityObject);
                                        }
                                        else
                                        {
                                            dgItemScheduleEntity[intIndexSchedule].qty = dgItemScheduleEntity[intIndexSchedule].qty + item.qty;
                                            dgItemScheduleEntity[intIndexSchedule].confirm_qty = dgItemScheduleEntity[intIndexSchedule].confirm_qty + item.qty;
                                        }
                                    }
                                    //else if (CheckIfExistsAlready == null && string.IsNullOrWhiteSpace(item.doc_no)) // if item without PR  need to append with already exust item
                                    //{
                                    //    dgItemsEntity[intIndex].qty = dgItemsEntity[intIndex].qty + item.qty;
                                    //    dgItemScheduleEntity[intIndex].qty = dgItemScheduleEntity[intIndex].qty + item.qty;
                                    //    dgItemScheduleEntity[intIndex].confirm_qty = dgItemScheduleEntity[intIndex].confirm_qty + item.qty;
                                    //}


                                }
                            }

                            if (dgItemScheduleEntity.Count > 0)
                            {
                                dgSelectedIndexItem = 1;
                                dgSelectedIndexItem = 0;
                            }
                        }
                        else
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Refernece Selection";
                            showMessageService.Text = String.Format("Item cannot add in Release Mode of Document!", this.Title);
                            showMessageService.ShowMessage();
                        }
                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Supplier, Docuemnt Date or Object not selected ", this.Title);
                    showMessageService.ShowMessage();
                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
        private void CreateDocumentByReferenceDocumentNumberBackup(object ParameterObject, string ParameterReference)
        {
            try
            {
                string DocumentList = "";
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null && !string.IsNullOrWhiteSpace(MasterEntity.PartyId) && MasterEntity.po_date.HasValue) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    foreach (var item in MC.PR_LIST)
                    {
                        if (item.selected == true)
                        {
                            DocumentList = DocumentList + item.id.ToString() + ",";
                        }
                    }
                    if (DocumentList == null || DocumentList == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Refernece Selection";
                        showMessageService.Text = String.Format("Please Select Referance No", this.Title);
                        showMessageService.ShowMessage();
                    }
                    else
                    {

                        if (ParameterObject.ToString() == "PR_REFERENCE" && MasterEntity.t_status == (from o in MC.t_statusList where o.ind_default == "1" select o.t_status).FirstOrDefault())
                        {
                            string Request = "GET_CATLOG!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + (MasterEntity.doc_type ?? doc_cat_vm) + "!@" + Convert.ToDateTime(MasterEntity.po_date).ToString("MM/dd/yyyy") + "!@" + MasterEntity.PartyId + "!@" + DocumentList;
                            MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, Request, "PRO_T002_BL", "PRO", "GET_CATLOG", 0, "");

                            if (MC.CATALOG_LIST != null)
                            {
                                if (MC.CATALOG_LIST.Count > 0)
                                {
                                    MC.CATALOG_LIST.Clear();
                                    MC.CATALOG_LIST = MCTemp.CATALOG_LIST;
                                }
                                else
                                {
                                    MC.CATALOG_LIST = MCTemp.CATALOG_LIST;
                                }
                            }

                            if (dgItemsEntity.Count == 0)
                            {
                                dgSelectedIndexItem = -1;
                            }

                            foreach (var item in MC.PR_LIST)
                            {
                                if (item.selected == true)
                                {
                                    ADM_M0061_A catalog_obj = null;
                                    if (MC.CATALOG_LIST != null)
                                    {
                                        if (MC.CATALOG_LIST.Count > 0) // Get Price from Catlog if exists. id to id comparision for accuracy to select exactly same item from Requisition reference and Catlog. id value in catlog collection is the same as requisition id value.
                                        {
                                            try
                                            { catalog_obj = MC.CATALOG_LIST.Where(x => x.id.ToString().Equals(item.id.ToString(), StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                                            catch (Exception ex) { }
                                        }
                                    }

                                    var InputValueIfExists = dgItemsEntity.Where(x => x.ref_item_row_id == item.id && x.ItemCode == item.item_code && x.sku == item.sku && x.del_address_id == MasterEntity.del_address_id && (x.unit_price ?? 0) == (item.cost ?? 0)).FirstOrDefault(); // Prefer Primary Key for this instruction.
                                    int intIndex = dgItemsEntity.IndexOf(dgItemsEntity.Where(x => x.ref_item_row_id == item.id && x.ItemCode == item.item_code && x.sku == item.sku && x.del_address_id == MasterEntity.del_address_id && (x.unit_price ?? 0) == (item.cost ?? 0)).FirstOrDefault()); // Prefer Primary Key for this instruction.
                                    var CheckIfExistsAlready = dgItemScheduleEntity.Where(x => x.pur_req_item_row_id == item.id && x.ItemCode == item.item_code).FirstOrDefault(); // check wether this item exists in Order or not for PR row id if not then first time or if yes then re addition should not happen.
                                    if (InputValueIfExists == null && CheckIfExistsAlready == null) // If Last condition !string.IsNullOrWhiteSpace(item.req_no) satisfy then PR is exists for item if not then item can add in PO without PR, In Item Master Indicator is set for PO witout PR. and item will get load in reference popup.
                                    {
                                        PUR_T002_B ItemObject = new PUR_T002_B();
                                        MasterEntity.po_code = MasterEntity.po_code ?? item.po_code;
                                        MasterEntity.pg_code = MasterEntity.pg_code ?? item.pg_code;
                                        ItemObject.id = 0;
                                        //ItemObject.line_id = dgItemsEntity.Count;
                                        ItemObject.ref_doc_no = item.doc_no;
                                        ItemObject.ref_doc_date = item.doc_date;
                                        ItemObject.ref_doc_type = item.doc_type;
                                        ItemObject.ref_item_line_id = (int)item.line_id;
                                        ItemObject.ref_item_row_id = item.id;
                                        ItemObject.ItemCode = item.item_code;
                                        ItemObject.sku = item.sku;
                                        ItemObject.sku_desc = item.sku_desc;
                                        ItemObject.textdata = item.long_text;
                                        ItemObject.item_cat = item.item_cat;
                                        ItemObject.description = item.item_name;


                                        // Catlog value assignment section.
                                        if (catalog_obj != null)
                                        {
                                            ItemObject.unit_price = (catalog_obj.unit_price ?? item.cost);
                                            ItemObject.tax_id = catalog_obj.tax_code;
                                            ItemObject.unit_code = catalog_obj.unit_code;
                                            ItemObject.discount = catalog_obj.discount;
                                            ItemObject.discount_type = catalog_obj.disc_type;
                                            ItemObject.description = ((catalog_obj.item_code_party ?? "") + " " + (catalog_obj.item_name ?? ItemObject.description)).Trim();

                                            if (!MasterEntity.ex_rate.HasValue)
                                            {
                                                MasterEntity.ex_rate = catalog_obj.exch_rate_pur;
                                            }
                                        }
                                        else
                                        {
                                            ItemObject.unit_price = item.cost;
                                            ItemObject.unit_code = item.unit_code;
                                        }
                                        ItemObject.qty = item.qty;
                                        ItemObject.date_planned = item.plan_date;
                                        ItemObject.t_status = MasterEntity.t_status;
                                        //ItemObject.t_display = "Draft";
                                        item.t_display = (from o in MC.t_statusList where o.t_status == item.t_status select o.t_display).FirstOrDefault();
                                        ItemObject.comp_code = MasterEntity.comp_code;
                                        ItemObject.location_Id = MasterEntity.location_Id;
                                        ItemObject.textdata = item.long_text;
                                        ItemObject.per_req_item_row_id = item.id;
                                        ItemObject.active = true;
                                        ItemObject.req_no = item.doc_no;
                                        ItemObject.requester_name = item.emp_name;
                                        ItemObject.pur_req_item = item.id;
                                        ItemObject.pur_req_no = item.doc_no;
                                        ItemObject.rec_plant = item.location_id;
                                        ItemObject.bom_no = item.bom_no;
                                        ItemObject.del_address_id = MasterEntity.del_address_id;
                                        ItemObject.bill_address_id = MasterEntity.bill_address_id;
                                        ItemObject.p_term_code = MasterEntity.p_term_code;
                                        //ItemObject.p_term_code = MasterEntity.p_term_code;
                                        ItemObject.user_source1 = item.user_source1;
                                        ItemObject.user_source2 = item.user_source2;
                                        ItemObject.bid_inv_no = "New";
                                        ItemObject.rel_billing = "Y";
                                        ItemObject.rel_delivery = "Y";

                                        dgItemsEntity.Add(ItemObject);
                                        dgSelectedIndexItem = dgItemsEntity.Count - 1;
                                        if (ItemObject.qty > 0 && ItemObject.unit_price > 0)
                                        {
                                            Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
                                        }
                                        if (!string.IsNullOrWhiteSpace(ItemObject.bom_no))
                                        {
                                            ItemEntityObject = ItemObject;
                                            InsertQty(ItemObject.ItemCode);
                                        }

                                        PUR_T004_B ScheduleItemEntityObject = new PUR_T004_B();
                                        ScheduleItemEntityObject.id = 0;
                                        ScheduleItemEntityObject.item_line_id = ItemObject.line_id;
                                        ScheduleItemEntityObject.po_no = MasterEntity.po_no;
                                        ScheduleItemEntityObject.line_id = dgItemScheduleEntity.Count;
                                        ScheduleItemEntityObject.ItemCode = item.item_code;
                                        ScheduleItemEntityObject.sku = item.sku;
                                        ScheduleItemEntityObject.sku_desc = item.sku_desc;
                                        ScheduleItemEntityObject.qty = item.qty;
                                        ScheduleItemEntityObject.expected_date = item.plan_date;
                                        ScheduleItemEntityObject.confirm_date = item.plan_date;
                                        ScheduleItemEntityObject.confirm_qty = item.qty;
                                        ScheduleItemEntityObject.t_status = MasterEntity.t_status;
                                        ScheduleItemEntityObject.t_display = (from o in MC.t_statusList where o.t_status == item.t_status select o.t_display).FirstOrDefault();
                                        ScheduleItemEntityObject.active = true;
                                        ScheduleItemEntityObject.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                                        ScheduleItemEntityObject.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                                        ScheduleItemEntityObject.unit_code = dgItemsEntity[dgSelectedIndexItem].unit_code;
                                        ScheduleItemEntityObject.rate = dgItemsEntity[dgSelectedIndexItem].unit_price ?? item.cost;
                                        ScheduleItemEntityObject.po_req_no = item.doc_no;
                                        ScheduleItemEntityObject.po_item_row_id = dgItemsEntity[dgSelectedIndexItem].id;
                                        //ScheduleItemEntityObject.tr_mode = item.tr_mode;
                                        //ScheduleItemEntityObject.tr_mode = item.tr_type;
                                        //ScheduleItemEntityObject.tr_mode = item.transporter_cd;
                                        ScheduleItemEntityObject.ref_doc_no = item.doc_no;
                                        ScheduleItemEntityObject.ref_doc_cat = item.doc_cat;
                                        ScheduleItemEntityObject.ref_doc_type = item.doc_type;
                                        ScheduleItemEntityObject.ref_doc_date = item.doc_date;
                                        ScheduleItemEntityObject.pur_req_item_row_id = item.id;
                                        ScheduleItemEntityObject.client = AppSessionState.client;
                                        //ScheduleItemEntityObject.del_address_id = MasterEntity.del_address_id;
                                        //ScheduleItemEntityObject.bill_address_id = MasterEntity.bill_address_id;
                                        ScheduleItemEntityObject.del_address_id = dgItemsEntity[dgSelectedIndexItem].del_address_id;
                                        ScheduleItemEntityObject.bill_address_id = dgItemsEntity[dgSelectedIndexItem].bill_address_id;
                                        ScheduleItemEntityObject.add_code_bil = MasterEntity.add_code_bil;
                                        ScheduleItemEntityObject.add_code_del = MasterEntity.add_code_del;
                                        ScheduleItemEntityObject.bom_no = dgItemsEntity[dgSelectedIndexItem].bom_no;
                                        ScheduleItemEntityObject.editby = AppSessionState.UserID;

                                        dgItemScheduleEntity.Add(ScheduleItemEntityObject);
                                    }
                                    else if (CheckIfExistsAlready == null) // && !string.IsNullOrWhiteSpace(item.req_no)
                                    {
                                        dgItemsEntity[intIndex].qty = dgItemsEntity[intIndex].qty + item.qty;
                                        int intIndexSchedule = dgItemScheduleEntity.IndexOf(dgItemScheduleEntity.Where(x => x.ItemCode == item.item_code && x.sku == item.sku && x.expected_date == item.plan_date && x.po_req_no == item.doc_no && x.pur_req_item_row_id == item.id).FirstOrDefault());
                                        if (intIndexSchedule == -1)
                                        {
                                            PUR_T004_B ScheduleItemEntityObject = new PUR_T004_B();
                                            ScheduleItemEntityObject.id = 0;
                                            ScheduleItemEntityObject.item_line_id = dgItemsEntity[dgSelectedIndexItem].line_id;
                                            ScheduleItemEntityObject.po_no = MasterEntity.po_no;
                                            ScheduleItemEntityObject.line_id = dgItemScheduleEntity.Count;
                                            ScheduleItemEntityObject.ItemCode = item.item_code;
                                            ScheduleItemEntityObject.sku = item.sku;
                                            ScheduleItemEntityObject.sku_desc = item.sku_desc;
                                            ScheduleItemEntityObject.qty = item.qty;
                                            ScheduleItemEntityObject.expected_date = item.plan_date;
                                            ScheduleItemEntityObject.confirm_date = item.plan_date;
                                            ScheduleItemEntityObject.confirm_qty = item.qty;
                                            ScheduleItemEntityObject.t_status = MasterEntity.t_status;
                                            ScheduleItemEntityObject.t_display = (from o in MC.t_statusList where o.t_status == ScheduleItemEntityObject.t_status select o.t_display).FirstOrDefault();
                                            ScheduleItemEntityObject.active = true;
                                            ScheduleItemEntityObject.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                                            ScheduleItemEntityObject.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                                            ScheduleItemEntityObject.unit_code = dgItemsEntity[dgSelectedIndexItem].unit_code;
                                            ScheduleItemEntityObject.rate = dgItemsEntity[dgSelectedIndexItem].unit_price ?? item.cost;
                                            ScheduleItemEntityObject.po_req_no = item.doc_no;
                                            ScheduleItemEntityObject.po_item_row_id = dgItemsEntity[dgSelectedIndexItem].id;
                                            //ScheduleItemEntityObject.tr_mode = item.tr_mode;
                                            //ScheduleItemEntityObject.tr_mode = item.tr_type;
                                            //ScheduleItemEntityObject.tr_mode = item.transporter_cd;
                                            ScheduleItemEntityObject.ref_doc_no = item.doc_no;
                                            ScheduleItemEntityObject.ref_doc_cat = item.doc_cat;
                                            ScheduleItemEntityObject.ref_doc_type = item.doc_type;
                                            ScheduleItemEntityObject.ref_doc_date = item.doc_date;
                                            ScheduleItemEntityObject.pur_req_item_row_id = item.id;
                                            ScheduleItemEntityObject.client = AppSessionState.client;
                                            //ScheduleItemEntityObject.del_address_id = MasterEntity.del_address_id;
                                            //ScheduleItemEntityObject.bill_address_id = MasterEntity.bill_address_id;
                                            ScheduleItemEntityObject.del_address_id = dgItemsEntity[dgSelectedIndexItem].del_address_id;
                                            ScheduleItemEntityObject.bill_address_id = dgItemsEntity[dgSelectedIndexItem].bill_address_id;
                                            ScheduleItemEntityObject.add_code_bil = MasterEntity.add_code_bil;
                                            ScheduleItemEntityObject.add_code_del = MasterEntity.add_code_del;
                                            ScheduleItemEntityObject.bom_no = dgItemsEntity[dgSelectedIndexItem].bom_no;
                                            ScheduleItemEntityObject.editby = AppSessionState.UserID;

                                            dgItemScheduleEntity.Add(ScheduleItemEntityObject);
                                        }
                                        else
                                        {
                                            dgItemScheduleEntity[intIndexSchedule].qty = dgItemScheduleEntity[intIndexSchedule].qty + item.qty;
                                            dgItemScheduleEntity[intIndexSchedule].confirm_qty = dgItemScheduleEntity[intIndexSchedule].confirm_qty + item.qty;
                                        }
                                    }
                                    //else if (CheckIfExistsAlready == null && string.IsNullOrWhiteSpace(item.doc_no)) // if item without PR  need to append with already exust item
                                    //{
                                    //    dgItemsEntity[intIndex].qty = dgItemsEntity[intIndex].qty + item.qty;
                                    //    dgItemScheduleEntity[intIndex].qty = dgItemScheduleEntity[intIndex].qty + item.qty;
                                    //    dgItemScheduleEntity[intIndex].confirm_qty = dgItemScheduleEntity[intIndex].confirm_qty + item.qty;
                                    //}


                                }
                            }

                            if (dgItemScheduleEntity.Count > 0)
                            {
                                dgSelectedIndexItem = 1;
                                dgSelectedIndexItem = 0;
                            }
                        }
                        else
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Refernece Selection";
                            showMessageService.Text = String.Format("Item cannot add in Release Mode of Document!", this.Title);
                            showMessageService.ShowMessage();
                        }
                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Supplier, Docuemnt Date or Object not selected ", this.Title);
                    showMessageService.ShowMessage();
                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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

        private void InsertItems(object ParameterObject, string ParameterReference, decimal? item_qty, string bom_no) // insert item for STO item reference
        {
            try
            {
                if (MC.ItemListForPopup.Count > 0 && string.IsNullOrWhiteSpace(MasterEntity.rec_plant) == false) // This Block of code read parameter . First for string and Entity Object in else part.
                {

                    if (dgItemsEntity.Count == 0)
                    {
                        dgSelectedIndexItem = -1;
                    }

                    foreach (var item in MC.ItemListForPopup)
                    {
                        if (item.Select == true)
                        {
                            PUR_T002_B ItemObject = new PUR_T002_B();
                            ItemObject.id = 0;
                            //ItemObject.line_id = dgItemsEntity.Count;
                            ItemObject.ItemCode = item.ItemCode;
                            ItemObject.sku = item.sku;
                            ItemObject.sku_desc = item.sku_desc;
                            ItemObject.item_cat = item.item_cat;
                            ItemObject.description = item.ItemName;
                            ItemObject.bom_no = item.bom_no;
                            ItemObject.unit_code = item.unit_code;
                            ItemObject.unit_price = 0;
                            ItemObject.date_planned = DateTime.Now;
                            ItemObject.t_status = MasterEntity.t_status;
                            ItemObject.t_display = (from o in MC.t_statusList where o.t_status == ItemObject.t_status select o.t_display).FirstOrDefault();
                            ItemObject.comp_code = MasterEntity.comp_code;
                            ItemObject.location_Id = MasterEntity.location_Id;
                            ItemObject.active = true;
                            ItemObject.rec_plant = MasterEntity.rec_plant;
                            ItemObject.del_address_id = MasterEntity.del_address_id;
                            ItemObject.bill_address_id = MasterEntity.bill_address_id;
                            ItemObject.p_term_code = MasterEntity.p_term_code;
                            //ItemObject.p_term_code = MasterEntity.p_term_code;
                            ItemObject.user_source1 = AppSessionState.UserSource1;
                            ItemObject.user_source2 = AppSessionState.UserSource2;
                            ItemObject.rel_billing = "Y";
                            ItemObject.rel_delivery = "Y";

                            dgItemsEntity.Add(ItemObject);
                            dgSelectedIndexItem = dgItemsEntity.Count - 1;
                            if (ItemObject.qty > 0 && ItemObject.unit_price > 0)
                            {
                                Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
                            }

                            PUR_T004_B ScheduleItemEntityObject = new PUR_T004_B();
                            ScheduleItemEntityObject.id = 0;
                            ScheduleItemEntityObject.item_line_id = ItemObject.line_id;
                            ScheduleItemEntityObject.po_no = MasterEntity.po_no;
                            ScheduleItemEntityObject.line_id = dgItemScheduleEntity.Count;
                            ScheduleItemEntityObject.ItemCode = item.ItemCode;
                            ScheduleItemEntityObject.sku = item.sku;
                            ScheduleItemEntityObject.sku_desc = item.sku_desc;
                            ScheduleItemEntityObject.expected_date = DateTime.Now;
                            ScheduleItemEntityObject.confirm_date = DateTime.Now;
                            ScheduleItemEntityObject.t_status = MasterEntity.t_status;
                            ScheduleItemEntityObject.t_display = (from o in MC.t_statusList where o.t_status == ScheduleItemEntityObject.t_status select o.t_display).FirstOrDefault();
                            ScheduleItemEntityObject.active = true;
                            ScheduleItemEntityObject.location_Id = MasterEntity.location_Id;
                            ScheduleItemEntityObject.comp_code = MasterEntity.comp_code;
                            ScheduleItemEntityObject.unit_code = item.unit_code;
                            ScheduleItemEntityObject.client = AppSessionState.client;
                            ScheduleItemEntityObject.del_address_id = MasterEntity.del_address_id;
                            ScheduleItemEntityObject.bill_address_id = MasterEntity.bill_address_id;
                            ScheduleItemEntityObject.add_code_bil = MasterEntity.add_code_bil;
                            ScheduleItemEntityObject.add_code_del = MasterEntity.add_code_del;
                            ScheduleItemEntityObject.bom_no = dgItemsEntity[dgSelectedIndexItem].bom_no;
                            ScheduleItemEntityObject.editby = AppSessionState.UserID;

                            dgItemScheduleEntity.Add(ScheduleItemEntityObject);
                            if (!string.IsNullOrWhiteSpace(ItemEntityObject.bom_no))
                            {
                                InsertQty(ItemObject.ItemCode);
                            }
                        }
                    }

                    if (dgItemScheduleEntity.Count > 0)
                    {
                        dgSelectedIndexItem = 1;
                        dgSelectedIndexItem = 0;
                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Select Receiving Plant", this.Title);
                    showMessageService.ShowMessage();
                }

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
                EntityChangeEnable = false;
                string Request = "";
                string ParametersStringValue = "";
                PUR_T002_AFlip ParameterEntityObject = null;

                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {

                    if (DocumentList == null || DocumentList == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Refernece Selection";
                        showMessageService.Text = String.Format("Please Select Referance No", this.Title);
                        showMessageService.ShowMessage();
                    }
                    else
                    {
                        if (ref_doc_cat == "RQ")
                        {
                            if (ParameterObject.ToString() == "ReferenceDocument")
                            {
                                if (String.IsNullOrEmpty(DocumentList))
                                {
                                    return;
                                }
                                ParametersStringValue = DocumentList;
                                ParameterReference = ParameterObject.ToString();
                            }
                            else if (ParameterReference == "DocumentNumber")
                            {
                                ParametersStringValue = ParameterObject.ToString().Trim();
                            }

                            if (ParametersStringValue.Length > 0)
                            {
                                try
                                { Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + AppSessionState.client + "!@" + (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@!@!@!@" + ParametersStringValue; }
                                //{ Request = "LoadDocumentFromRequisitionnumber" + "!@" + ParametersStringValue; }
                                catch (Exception ex) { }
                            }
                            MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, Request, "PRO_T002_BL", "PRO", "LoadDocumentFromRequisitionnumber", 0, "");
                            foreach (var o in MCTemp.DocumentItems)
                            {
                                var InputValueIfExists = dgItemsEntity.Where(X => X.ItemCode == o.ItemCode && X.req_no == o.req_no).FirstOrDefault(); // Prefer Primary Key for this instruction.

                                if (InputValueIfExists == null)
                                {
                                    dgItemsEntity.Add(o);
                                }
                            }
                            //if (MCTemp.DocumentItems != null)
                            //{
                            //    dgItemsEntity.Clear();
                            //    dgItemsEntity = MCTemp.DocumentItems;

                            //}
                            //else
                            //{
                            //    MCTemp.DocumentItems = new ObservableCollection<PUR_T002_B>();
                            //}


                            int count = dgItemsEntity.Count();
                            for (int i = 0; i < count; i++)
                            {
                                dgItemsEntity[i].user_source2 = "Local";
                                dgItemsEntity[i].bid_inv_no = "New";
                                SubTotalCalculation(i);
                                Computation(true, i, AutoRoundupEnable);
                            }

                        }
                        else if (ref_doc_cat == "IN" || ref_doc_cat == "QP")
                        {
                            if (ParameterObject.ToString() == "ReferenceDocument")
                            {
                                if (String.IsNullOrEmpty(DocumentList))
                                {
                                    return;
                                }
                                ParametersStringValue = DocumentList;
                                ParameterReference = ParameterObject.ToString();
                            }
                            else if (ParameterReference == "DocumentNumber")
                            {
                                ParametersStringValue = ParameterObject.ToString().Trim();
                            }
                            if (ParametersStringValue.Length > 0)
                            {
                                Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + AppSessionState.client + "!@" + (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@!@!@!@" + ParametersStringValue;
                                //Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParametersStringValue;
                            }
                            MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, Request, "PRO_T002_BL", "PRO", "LoadDocumentWithReferenceDocumentNumber", 0, "");

                            if (MCTemp.DocumentMaster.Count > 0)
                            {
                                MasterEntity = MCTemp.DocumentMaster[0];
                                PersonEmailId = MasterEntity.mail_id;
                                PartyEmailId = MasterEntity.EmailId;

                            }
                            var temp = (from o in MC.partyList where o.PartyId == MasterEntity.PartyId select o).ToList();
                            if (temp.Count == 0)
                            {
                                MasterEntity.PartyId = "";
                                MasterEntity.party_name = "";
                                MCTemp.DocumentItems = null;
                                MCTemp.DocumentScheduleDetails = null;
                                MCTemp.DocumentTaxDetails = null;
                            }


                            if (MCTemp.DocumentItems != null)
                            {
                                dgItemsEntity.Clear();
                                dgItemsEntity = MCTemp.DocumentItems;

                            }
                            else
                            {
                                MCTemp.DocumentItems = new ObservableCollection<PUR_T002_B>();
                            }



                            if (MCTemp.DocumentTaxDetails != null)
                            {
                                TotalDocumentTaxes = MCTemp.DocumentTaxDetails;
                            }
                            else
                            {
                                MCTemp.DocumentTaxDetails = new ObservableCollection<ACC_T006_B>();
                            }
                            if (MCTemp.DocumentScheduleMaster != null)
                            {
                                if (MCTemp.DocumentScheduleMaster.Count > 0)
                                {
                                    ScheduleEntity = MCTemp.DocumentScheduleMaster[0];
                                }
                            }
                            else
                            {
                                ScheduleEntity = new PUR_T004_A();
                            }
                            if (MCTemp.DocumentScheduleDetails != null)
                            {
                                dgItemScheduleEntity.Clear();
                                dgItemScheduleEntity = MCTemp.DocumentScheduleDetails;
                            }
                            else
                            {
                                MCTemp.DocumentScheduleDetails = new ObservableCollection<PUR_T004_B>();
                            }

                            if (MCTemp.TermsAndCondition != null)
                            {
                                TermsConditionEntity = MCTemp.TCondition;
                            }
                            else
                            {
                                TermsConditionEntity = new ObservableCollection<GEN_T011>();
                            }
                            if (MCTemp.ComponantList != null)
                            {
                                dgComponantEntity = MCTemp.ComponantList;
                            }
                            else
                            {
                                dgComponantEntity = new ObservableCollection<PUR_T002_C>();
                            }
                        }
                    }
                }

                if (ref_doc_cat != "RQ")
                {
                    if (ParameterReference == "ReferenceDocument")
                    {
                        MasterEntity.ref_doc_no = MasterEntity.po_no;
                        MasterEntity.ref_doc_date = MasterEntity.po_date;
                        MasterEntity.ref_doc_type = MasterEntity.doc_type;
                        MasterEntity.shipped = false;
                        MasterEntity.shipped_date = null;
                        MasterEntity.doc_cat = doc_cat_vm;
                        MasterEntity.doc_type = doc_cat_vm;
                        MasterEntity.doc_type_user = doc_cat_vm;
                        MasterEntity.doc_desc = "Purchase Order";
                        MasterEntity.po_no = "";
                        MasterEntity.po_date = DateTime.Now;
                        MasterEntity.add_by = AppSessionState.UserID;
                        MasterEntity.editby = AppSessionState.UserID;
                        MasterEntity.active = true;
                        //MasterEntity.rel_sts = "04";
                        MasterEntity.t_status = (from o in MC.t_statusList where o.ind_default == "1" select o.t_status).FirstOrDefault();
                        MasterEntity.t_display = (from o in MC.t_statusList where o.ind_default == "1" select o.t_display).FirstOrDefault();
                        MasterEntity.shipped = false;
                        MasterEntity.version = "v1.0";
                        ScheduleEntity.t_status = MasterEntity.t_status;
                        ScheduleEntity.t_display = MasterEntity.t_display;
                        ScheduleEntity.sch_date = DateTime.Now;
                        ScheduleEntity.active = true;
                        ScheduleEntity.add_by = AppSessionState.UserID;
                        ScheduleEntity.id = 0;
                        NewRecord = true;
                    }
                }
                MasterEntity.ts_code = ts_code_vm;
                EntityChangeEnable = true;
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
        private void InsertSendingPlant(object InputValue) // NOTE: Depricated as partyInsert will do the same job.
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
                            { POPUPEntityObject = ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.supplying_plant = POPUPEntityObject.location_Id;
                    //MasterEntity.supplantnm = POPUPEntityObject.LoctnNm;
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
        private void InsertRecPlantOld(object InputValue)
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
                            { POPUPEntityObject = ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.rec_plant = POPUPEntityObject.location_Id;
                    MasterEntity.PartyId = POPUPEntityObject.supplier_code;
                    //MasterEntity.party_name = POPUPEntityObject.l;
                    if (doc_cat_vm == "TO")
                    {
                        MasterEntity.del_address_id = POPUPEntityObject.location_Id;
                        MasterEntity.bill_address_id = POPUPEntityObject.location_Id;
                        MasterEntity.add_code_bil = POPUPEntityObject.add_code;
                        MasterEntity.add_code_del = POPUPEntityObject.add_code;

                        foreach (var item in dgItemsEntity)
                        {
                            item.bill_address_id = MasterEntity.bill_address_id;
                            item.del_address_id = MasterEntity.del_address_id;
                        }
                        foreach (var item in dgItemScheduleEntity)
                        {
                            item.bill_address_id = MasterEntity.bill_address_id;
                            item.del_address_id = MasterEntity.del_address_id;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void InsertRecPlant(object InputValue)
        {
            try
            {
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
                            {
                                POPUPEntityObject = MC.partyList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
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
                    MasterEntity.rec_plant = POPUPEntityObject.location_id;
                    MasterEntity.rec_plant_name = POPUPEntityObject.PartyNm;
                    MasterEntity.location_Id = POPUPEntityObject.location_id;
                    if (doc_cat_vm == "TO")
                    {
                        MasterEntity.del_address_id = POPUPEntityObject.location_id;
                        MasterEntity.bill_address_id = POPUPEntityObject.location_id;
                        MasterEntity.add_code_bil = POPUPEntityObject.add_code;
                        MasterEntity.add_code_del = POPUPEntityObject.add_code;

                        foreach (var item in dgItemsEntity)
                        {
                            item.bill_address_id = MasterEntity.bill_address_id;
                            item.del_address_id = MasterEntity.del_address_id;
                        }
                        foreach (var item in dgItemScheduleEntity)
                        {
                            item.bill_address_id = MasterEntity.bill_address_id;
                            item.del_address_id = MasterEntity.del_address_id;
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
        private void InsertParty(object InputValue, bool OverrideValue)
        {
            try
            {
                //if (InputValue.GetType() == typeof(string) && InputValue.ToString() != "")
                //{
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
                            {
                                POPUPEntityObject = MC.partyList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
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
                    if (dgItemsEntity.Count > 0 && NewRecord == false && MasterEntity.PartyId != POPUPEntityObject.PartyId)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Supplier Change Information";
                        showMessageService.Text = String.Format("Cannot change Supplier'{0}' in edit mode", this.Title);
                        showMessageService.ShowMessage();

                    }
                    else if (NewRecord == true && (MasterEntity.PartyId != POPUPEntityObject.PartyId || MasterEntity.party_name != POPUPEntityObject.PartyNm))
                    {
                        MasterEntity.PartyId = POPUPEntityObject.PartyId;
                        MasterEntity.add_code = POPUPEntityObject.add_code;
                        MasterEntity.party_name = POPUPEntityObject.PartyNm;
                        MasterEntity.curr_code = POPUPEntityObject.curr_code;
                        MasterEntity.country_code = POPUPEntityObject.country_code;
                        MasterEntity.symbol = POPUPEntityObject.symbol;
                        MasterEntity.gst_PartyId = POPUPEntityObject.PartyId;
                        MasterEntity.buss_place = POPUPEntityObject.buss_place;
                        MasterEntity.supplying_plant = POPUPEntityObject.location_id;
                        PartyEmailId = POPUPEntityObject.EmailId;

                        if (MasterEntity.curr_code == Currency)
                        {
                            MasterEntity.ex_rate = 1;
                        }
                        else
                        {
                            InsertCurrency(MasterEntity.curr_code);
                        }

                        // NOTE: MasterEntity.country_code should not be null ot change field name to proper and meaning also because it is not define whether it is our country or party's country.
                        if (!string.IsNullOrWhiteSpace(MasterEntity.country_code) && MasterEntity.country_code == AppSessionState.OBJ_COMPANY.ctr_code)
                        {
                            MasterEntity.ind_trade = "L";
                        }
                        else if (!string.IsNullOrWhiteSpace(MasterEntity.country_code) && MasterEntity.country_code != AppSessionState.OBJ_COMPANY.ctr_code)
                        {
                            MasterEntity.ind_trade = "I";
                        }
                        else
                        {
                            MasterEntity.ind_trade = "L";
                        }
                        RequestParameterData = "LoadPartyDetails" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.po_code + "!@" + (AppSessionState.pg_code ?? "") + "!@" + MasterEntity.PartyId;
                        //RequestParameterData = "LoadPartyDetails" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + "PO" + "!@" + "PO" + "!@" + AppSessionState.po_code + "!@" + MasterEntity.PartyId + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.pg_code;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, RequestParameterData, "PRO_T002_BL", "PRO", "", 0, "");

                        ContactPersonCollection = CollectionViewSource.GetDefaultView(MCTemp.ContactPerson);
                        ContactPersonCollection.Filter = new Predicate<object>(Filter_Contactperson);
                        StringListContactPerson = MCTemp.ContactPerson.Select(x => x.ContInfoId.ToString()).ToList();

                        //New PopUP - ContactPerson
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).ContInfoId.ToString());
                        TheFilter = (o, prefix) => ((ADM_M028_C_P)o).ContInfoId.ToString().ToLower().Contains(prefix) ||
                                                   ((ADM_M028_C_P)o).PersonName.ToString().ToLower().Contains(prefix);
                        ASContactPerson = new AutoSuggestTextViewModel<dynamic>(MCTemp.ContactPerson, TheFilter, SuggestedValue, "ContInfoId", true);
                        ASContactPerson.AutoSuggestVM.IsEmptyValueAllowed = true;

                        //MC.CONDITION_LIST = MCTemp.CONDITION_LIST;
                        MC.ContactPerson = MCTemp.ContactPerson;

                        if(TermsConditionEntity != null)
                        {
                            if (TermsConditionEntity.Count==0)
                            {
                                foreach (var item in MC.CONDITION_LIST) // add only if no conditions exists and compulsory need to add first time.
                                {
                                    if (item.ind_man == "Y")
                                    {
                                        TCEntityObject = new GEN_T011();
                                        TermsConditionEntity.Add(TCEntityObject);
                                        InsertTerms(item.tc_code);
                                    }
                                }
                            }
                        }
                        

                        foreach (var item in MCTemp.CONDITION_LIST) // add only party conditions so use MCTemp not MC.
                        {
                            if (item.ind_man == "Y")
                            {
                                TCEntityObject = new GEN_T011();
                                TermsConditionEntity.Add(TCEntityObject);
                                InsertTerms(item.tc_code);
                            }
                        }

                        if (MCTemp.ContactPerson.Count >= 1 && MCTemp.ContactPerson.Count > 0)
                        {
                            MasterEntity.supplier_EmpId = "";
                            MasterEntity.supplier_EmpName = "";
                            MasterEntity.mail_id = "";
                            MasterEntity.supplier_EmpId = Convert.ToString(MCTemp.ContactPerson[0].ContInfoId);
                            MasterEntity.supplier_EmpName = MCTemp.ContactPerson[0].PersonName;
                            MasterEntity.mail_id = MCTemp.ContactPerson[0].PersnEmailId;
                            PersonEmailId = MCTemp.ContactPerson[0].PersnEmailId;
                        }
                        else if (MCTemp.ContactPerson.Count == 0)
                        {
                            MasterEntity.supplier_EmpId = null;
                            MasterEntity.supplier_EmpName = null;
                            MasterEntity.mail_id = null;

                        }
                    }
                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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


                if (POPUPEntityObject != null && ItemEntityObject != null)
                {
                    if (dgSelectedIndexItemLicence >= 0 && LicenceDetailsEntity.Count > dgSelectedIndexItemLicence) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<ACC_T006_D> temp = LicenceDetailsEntity.ToList();
                        temp = (from o in temp where o.ItemCode == ItemEntityObject.ItemCode select o).ToList();
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


                if (POPUPEntityObject != null && ItemEntityObject != null)
                {
                    if (dgSelectedIndexItemLicence >= 0 && LicenceDetailsEntity.Count > dgSelectedIndexItemLicence) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<ACC_T006_D> temp = LicenceDetailsEntity.ToList();
                        temp = (from o in temp where o.ItemCode == ItemEntityObject.ItemCode select o).ToList();
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
        private void InsertContactPerson(object InputValue)
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
                            { POPUPEntityObject = MC.ContactPerson.Where(x => x.ContInfoId.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {
                    MasterEntity.supplier_EmpId = Convert.ToString(POPUPEntityObject.ContInfoId);
                    MasterEntity.supplier_EmpName = POPUPEntityObject.PersonName;
                    MasterEntity.mail_id = POPUPEntityObject.PersnEmailId;
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
        private void InsertDocType(object InputValue)
        {
            try
            {
                string Request = "";
                STD_DOC_TYPE POPUPEntityObject = null;
                IEnumerable<STD_DOC_TYPE> BEType = new List<STD_DOC_TYPE>();
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
                            { POPUPEntityObject = MC.DOC_TYPE_LIST.Where(x => x.doc_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_DOC_TYPE>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) // && MasterEntity.doc_type_user != POPUPEntityObject.doc_type_user) // Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (String.IsNullOrEmpty(MasterEntity.po_no) != true || String.IsNullOrWhiteSpace(MasterEntity.po_no) != true) // Only enter in the code block if ENtity Not null.
                    {
                        if (dgItemsEntity.Count > 0 && NewRecord == false) // && MasterEntity.t_status != "01"
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Change Information";
                            showMessageService.Text = String.Format("Can not change Document Type '{0}' in edit mode", this.Title);
                            showMessageService.ShowMessage();
                        }
                        else //if (MasterEntity.t_status == "01")
                        {
                            MasterEntity.doc_cat = POPUPEntityObject.doc_cat;
                            MasterEntity.doc_type = POPUPEntityObject.doc_type;
                            MasterEntity.doc_type_user = POPUPEntityObject.doc_type_name;
                            MasterEntity.doc_desc = POPUPEntityObject.doc_type_name;
                            AutoRoundupEnable = (bool)(POPUPEntityObject.auto_roundup ?? false);
                            RoundUpDecimals = (int)(POPUPEntityObject.roundup_digits ?? 2);
                        }
                    }
                    else if (NewRecord == true && dgItemsEntity.Count > 0)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Supplier Selection";
                        showMessageService.Text = String.Format("If You Change The Document Type some data Will be removed'{0}'", this.Title);
                        if (showMessageService.ShowMessage() == DialogResult.Ok)
                        {
                            MasterEntity.doc_cat = POPUPEntityObject.doc_cat;
                            MasterEntity.doc_type = POPUPEntityObject.doc_type;
                            MasterEntity.doc_type_user = POPUPEntityObject.doc_type_name;
                            MasterEntity.doc_desc = POPUPEntityObject.doc_type_name;
                            AutoRoundupEnable = (bool)(POPUPEntityObject.auto_roundup ?? false);
                            RoundUpDecimals = (int)(POPUPEntityObject.roundup_digits ?? 2);
                        }
                    }
                    else
                    {
                        MasterEntity.doc_cat = POPUPEntityObject.doc_cat;
                        MasterEntity.doc_type = POPUPEntityObject.doc_type;
                        MasterEntity.doc_type_user = POPUPEntityObject.doc_type_name;
                        MasterEntity.doc_desc = POPUPEntityObject.doc_type_name;
                        AutoRoundupEnable = (bool)(POPUPEntityObject.auto_roundup ?? false);
                        RoundUpDecimals = (int)(POPUPEntityObject.roundup_digits ?? 2);
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
        
        private void InsertQty(object item_code) // Sales BOM fetch and add all componant with line category
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(ItemEntityObject.bom_no) && ItemEntityObject.qty.HasValue && ItemEntityObject.qty > 0)
                {
                    WebServiceRepository<MC_SDM_BE> repository_MCTemp2 = new WebServiceRepository<MC_SDM_BE>();
                    string Request = "SDM_BOM_EXPLODE" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@" + ItemEntityObject.bom_no + "!@" + ItemEntityObject.ItemCode + "!@" + ItemEntityObject.qty.ToString() + "!@" + ItemEntityObject.unit_code;
                    MCTemp2 = repository_MCTemp2.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp2, Request, "SEL_T001_BL", "SDM", "", 0, "");

                    if (MCTemp2.BOM_LIST != null)
                    {
                        if (MCTemp2.BOM_LIST.Count > 0)
                        {
                            InsertDataGridRow_ItemCategory("EXH", false, true, true);
                            foreach (var item in MCTemp2.BOM_LIST)
                            {
                                //InsertItems(item.item_code,null, item.qty, item.bom_no);
                                PUR_T002_B ItemObject = new PUR_T002_B();
                                try
                                {
                                    ItemObject = dgItemsEntity.Where(x => x.ItemCode == item.item_code && x.bom_no == ItemEntityObject.bom_no && x.item_cat == "EXD").ToList()[0];
                                }
                                catch (Exception ex)
                                {
                                    ItemObject = new PUR_T002_B();
                                }
                                
                                ItemObject.id = 0;
                                //ItemObject.line_id = dgItemsEntity.Count + 1;
                                ItemObject.ItemCode = item.item_code;
                                ItemObject.description = item.item_name;
                                ItemObject.sku = item.sku;
                                ItemObject.sku_desc = item.sku_desc;
                                ItemObject.item_cat = "EXD";
                                ItemObject.bom_no = ItemEntityObject.bom_no;
                                ItemObject.unit_code = item.unit_code;
                                ItemObject.unit_price = 0;
                                ItemObject.date_planned = DateTime.Now;
                                ItemObject.t_status = MasterEntity.t_status;
                                ItemObject.t_display = MasterEntity.t_display;
                                ItemObject.comp_code = MasterEntity.comp_code;
                                ItemObject.location_Id = MasterEntity.location_Id;
                                ItemObject.active = true;
                                ItemObject.rec_plant = MasterEntity.rec_plant;
                                ItemObject.del_address_id = MasterEntity.del_address_id;
                                ItemObject.bill_address_id = MasterEntity.bill_address_id;
                                ItemObject.p_term_code = MasterEntity.p_term_code;
                                //ItemObject.p_term_code = MasterEntity.p_term_code;
                                ItemObject.user_source1 = AppSessionState.UserSource1;
                                ItemObject.user_source2 = AppSessionState.UserSource2;
                                ItemObject.rel_billing = "N";
                                ItemObject.rel_delivery = "Y";
                                
                                if (item.qty.HasValue)
                                {
                                    if (item.qty > 0)
                                    {
                                        ItemObject.qty = item.qty;
                                    }
                                    ItemObject.textdata = item.long_text;
                                }

                                try
                                {
                                    ItemObject = dgItemsEntity.Where(x => x.ItemCode == item.item_code && x.bom_no == ItemEntityObject.bom_no && x.item_cat == "EXD").ToList()[0];
                                }
                                catch (Exception ex)
                                {
                                    dgItemsEntity.Add(ItemObject); // add new item if not exists
                                }

                                //dgItemsEntity.Add(ItemObject);
                                dgSelectedIndexItem = dgItemsEntity.Count - 1;
                                if (ItemObject.qty > 0 && ItemObject.unit_price > 0)
                                {
                                    Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
                                }

                                //PUR_T004_B ScheduleItemEntityObject = new PUR_T004_B();
                                //ScheduleItemEntityObject.id = 0;
                                //ScheduleItemEntityObject.item_line_id = ItemObject.line_id;
                                //ScheduleItemEntityObject.po_no = MasterEntity.po_no;
                                //ScheduleItemEntityObject.line_id = dgItemScheduleEntity.Count;
                                //ScheduleItemEntityObject.ItemCode = item.item_code;
                                //ScheduleItemEntityObject.sku = item.sku;
                                //ScheduleItemEntityObject.sku_desc = item.sku_desc;
                                //ScheduleItemEntityObject.expected_date = DateTime.Now;
                                //ScheduleItemEntityObject.confirm_date = DateTime.Now;
                                //ScheduleItemEntityObject.t_status = MasterEntity.t_status;
                                //ScheduleItemEntityObject.t_display = (from o in MC.t_statusList where o.t_status == ScheduleItemEntityObject.t_status select o.t_display).FirstOrDefault();
                                //ScheduleItemEntityObject.active = true;
                                //ScheduleItemEntityObject.location_Id = MasterEntity.location_Id;
                                //ScheduleItemEntityObject.comp_code = MasterEntity.comp_code;
                                //ScheduleItemEntityObject.unit_code = item.unit_code;
                                //ScheduleItemEntityObject.client = AppSessionState.client;
                                //ScheduleItemEntityObject.del_address_id = MasterEntity.del_address_id;
                                //ScheduleItemEntityObject.bill_address_id = MasterEntity.bill_address_id;
                                //ScheduleItemEntityObject.bom_no = ItemEntityObject.bom_no;
                                //ScheduleItemEntityObject.editby = AppSessionState.UserID;

                                //dgItemScheduleEntity.Add(ScheduleItemEntityObject);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
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
                catch (Exception ex)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format(ex.Message, this.Title);
                    showMessageService.ShowMessage();
                }
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (TotalDocumentTaxes.Count == dgSelectedIndexTaxSummury && dgSelectedIndexTaxSummury >= 0)
                    {
                        TotalDocumentTaxes.Add(new ACC_T006_B()
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
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void SelectionChanged_PUR_T002_B(object InputValue)
        {
            try
            {
                ItemEntityObject = (PUR_T002_B)InputValue;
                FilterScheduleDataGrid();
                FilterComponantDataGrid();
            }
            catch (Exception ex) { }
        }
        private void Insert_t_status(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0013 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.t_statusList.Where(x => x.t_status.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_display.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0013>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.t_status = POPUPEntityObject.t_status;
                    MasterEntity.t_display = POPUPEntityObject.t_display;
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
        //            if(MasterEntity.comp_code != POPUPEntityObject.comp_code)
        //            {
        //                MasterEntity.comp_code = POPUPEntityObject.comp_code;
        //                ScheduleEntity.comp_code = POPUPEntityObject.comp_code;
        //                ScheduleEntity.location_Id = null;
        //                MasterEntity.bill_address_id = null;
        //                MasterEntity.del_address_id = null;
        //                MasterEntity.location_Id = null;
        //                if (doc_cat_vm == "TO")
        //                {
        //                    MasterEntity.supplying_plant = null;
        //                    MasterEntity.rec_plant = null;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format(ex.Message, this.Title);
        //        showMessageService.ShowMessage();
        //    }
        //}
        //private void InsertPlant(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ADM_M0003 POPUPEntityObject = null;
        //        #region Command Parameter Read Section
        //        try
        //        {
        //            if (InputValue.GetType() == typeof(string) && InputValue != null)
        //            {
        //                Request = InputValue.ToString();
        //                if (Request.Length > 0)
        //                {
        //                    try
        //                    { POPUPEntityObject = MC.LOCATION_LIST.Where(x => x.location_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                    catch (Exception ex) { }
        //                }
        //            }
        //            else if (InputValue != null)
        //            {
        //                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0003>().ToList()[0];
        //            }
        //        }
        //        catch (Exception ex) { }

        //        #endregion
        //        if (POPUPEntityObject != null)
        //        {
        //            MasterEntity.location_Id = POPUPEntityObject.location_id;
        //            ScheduleEntity.comp_code = POPUPEntityObject.comp_code;
        //            ScheduleEntity.location_Id = POPUPEntityObject.location_id;
        //            MasterEntity.bill_address_id = POPUPEntityObject.location_id;
        //            MasterEntity.del_address_id = POPUPEntityObject.location_id;
        //            if (doc_cat_vm == "TO")
        //            {
        //                MasterEntity.supplying_plant = null;
        //                MasterEntity.rec_plant = POPUPEntityObject.location_id;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format(ex.Message, this.Title);
        //        showMessageService.ShowMessage();
        //    }
        //}
        private void InsertBuyer(object InputValue)
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
                            { POPUPEntityObject = MC.BuyerList.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {
                    MasterEntity.buyer = POPUPEntityObject.EmpId;
                    MasterEntity.BuyerName = POPUPEntityObject.EmpLName;
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
        private void InsertValidator(object InputValue)
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
                            { POPUPEntityObject = MC.BuyerList.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.validator_code = POPUPEntityObject.EmpId;
                    MasterEntity.validator_name = POPUPEntityObject.EmpLName;
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
                //ADM_M028_PopUp
                string Request = "";
                ADM_M037 POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.CURRENCY_LIST.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M037>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    STD_LIST_BE KEY_OBJ = null;
                    MasterEntity.curr_code = POPUPEntityObject.curr_code;
                    MasterEntity.symbol = POPUPEntityObject.symbol;

                    Request = "GET_KEY_DATA!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + (MasterEntity.doc_type ?? doc_cat_vm) + "!@" + Convert.ToDateTime(MasterEntity.po_date).ToString("MM/dd/yyyy") + "!@" + MasterEntity.curr_code + "!@" + AppSessionState.CntryCurncy + "!@" + MasterEntity.PartyId;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, Request, "PRO_T002_BL", "PRO", "GET_KEY_DATA", 0, "");
                    MC.KEY_DATA_LIST = MCTemp.KEY_DATA_LIST;
                    if (MC.KEY_DATA_LIST != null)
                    {
                        if (MC.KEY_DATA_LIST.Count > 0)
                        {
                            try
                            { KEY_OBJ = MC.KEY_DATA_LIST.Where(x => x.curr_code.Equals(MasterEntity.curr_code, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                            if (KEY_OBJ != null)
                            {
                                MasterEntity.ex_rate = KEY_OBJ.exch_rate ?? POPUPEntityObject.exch_rate;
                            }
                        }
                        else
                        {
                            MasterEntity.ex_rate = POPUPEntityObject.exch_rate;
                            if (MasterEntity.curr_code == AppSessionState.CntryCurncy)
                            {
                                MasterEntity.ex_rate = 1;
                            }
                        }
                    }
                    else
                    {
                        MasterEntity.ex_rate = POPUPEntityObject.exch_rate;
                        if (MasterEntity.curr_code == AppSessionState.CntryCurncy)
                        {
                            MasterEntity.ex_rate = 1;
                        }
                    }
                    if (MasterEntity.curr_code == AppSessionState.CntryCurncy)
                    {
                        MasterEntity.ex_rate = 1;
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
        private void InsertPayTerm(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                ACC_M007_P POPUPEntityObject = null;
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
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
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
                            { POPUPEntityObject = MC.purchase_orgList.Where(x => x.po_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
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
                            { POPUPEntityObject = MC.Purchase_groupList.Where(x => x.pg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void InsertPurchaseWearhouse(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                MM_M002_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.WarehouseList.Where(x => x.wa_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M002_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.wa_code = POPUPEntityObject.wa_code;
                    MasterEntity.wa_name = POPUPEntityObject.wa_name;
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
        private void InsertPurchaseStorageLocation(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                MM_M001_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.storage_locList.Where(x => x.store_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M001_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.stock_location_id = POPUPEntityObject.store_code;
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
        private void InsertDeliveryAddress(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
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
                            { POPUPEntityObject = ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.del_address_id = POPUPEntityObject.location_Id;
                    if (dgItemsEntity.Count > 0)
                    {
                        foreach (var item in dgItemsEntity)
                        {
                            item.del_address_id = POPUPEntityObject.location_Id;
                        }
                    }
                    if (dgItemScheduleEntity.Count > 0)
                    {
                        foreach (var item in dgItemScheduleEntity)
                        {
                            item.del_address_id = POPUPEntityObject.location_Id;
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
        private void ScheduleDataGridRowSelectionChanged(object InputValue)
        {
            try
            {
                SelectedItemScheduleEntity = (PUR_T004_B)InputValue;
                //if (InputValue != null && ((IEnumerable)InputValue).Cast<SEL_T002_A>().ToList().Count > 0)
                //{
                //    SelectedItemScheduleEntity = ((IEnumerable)InputValue).Cast<SEL_T002_A>().ToList()[0];
                //}

            }
            catch (Exception ex)
            { }
        }
        private void ComponantDataGridRowSelectionChanged(object InputValue)
        {
            try
            {
                SelectedItemComponantEntity = (PUR_T002_C)InputValue;
            }
            catch (Exception ex)
            { }
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (STD_OBJECT != null && STD_OBJECT.req_code == "VIEW")
                {
                    LoadInitialData(doc_cat_vm, null);
                    DefaultValues(doc_cat_vm);
                    //List<STD_LIST_BE> STD_LIST_OBJ = new List<STD_LIST_BE>();
                    //STD_LIST_OBJ.Add(REF_OBJECT);
                    LoadDocumentByDocumentNumber(STD_OBJECT.doc_no, "DocumentNo");
                }
                else if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    //isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                    AppSessionState.ViewOtherRecordAllowed = true;
                }
                else
                {
                    LoadInitialData(doc_cat_vm, null);
                    DefaultValues(doc_cat_vm);
                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
        private void InsertBillingAddress(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
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
                            { POPUPEntityObject = ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.bill_address_id = POPUPEntityObject.location_Id;
                    MasterEntity.add_code_bil = POPUPEntityObject.add_code;

                    if (dgItemsEntity.Count > 0)
                    {
                        foreach (var item in dgItemsEntity)
                        {
                            item.bill_address_id = POPUPEntityObject.location_Id;
                        }
                    }
                    if (dgItemScheduleEntity.Count > 0)
                    {
                        foreach (var item in dgItemScheduleEntity)
                        {
                            item.bill_address_id = POPUPEntityObject.location_Id;
                            item.add_code_bil = POPUPEntityObject.add_code;
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
        private void InsertCostCenter(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                ACC_M019_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.cost_centerList.Where(x => x.cost_center.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.cost_center = POPUPEntityObject.cost_center;
                    MasterEntity.cost_center_Desc = POPUPEntityObject.cost_center_Desc;
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
        private void Insertdgrequisition(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                PUR_T004_B SelectedScheduleRow = null;
                STD_LIST_BE POPUPEntityObject = null;
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
                            {
                                POPUPEntityObject = MC.PR_LIST.Where(x => x.doc_no.Equals(SelectedScheduleRow.po_req_no, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        SelectedScheduleRow = ((IEnumerable)InputValue).Cast<PUR_T004_B>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (SelectedScheduleRow != null && SelectedScheduleRow.po_req_no != null && SelectedScheduleRow.po_req_no != "") //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    int intIndexSch = dgItemScheduleEntity.IndexOf(dgItemScheduleEntity.Where(x => x.ItemCode == SelectedScheduleRow.ItemCode && x.sku == SelectedScheduleRow.sku && x.line_id == SelectedScheduleRow.line_id).FirstOrDefault());
                    POPUPEntityObject = MC.PR_LIST.Where(x => x.doc_no.Equals(SelectedScheduleRow.po_req_no, StringComparison.OrdinalIgnoreCase) == true && x.item_code.Equals(SelectedScheduleRow.ItemCode, StringComparison.OrdinalIgnoreCase) == true && (x.sku ?? "").Equals(SelectedScheduleRow.sku ?? "") == true).ToList()[0];

                    dgItemScheduleEntity[intIndexSch].ItemCode = POPUPEntityObject.item_code;
                    dgItemScheduleEntity[intIndexSch].sku = POPUPEntityObject.sku;
                    dgItemScheduleEntity[intIndexSch].sku_desc = POPUPEntityObject.sku_desc;
                    dgItemScheduleEntity[intIndexSch].po_req_no = POPUPEntityObject.doc_no;
                    dgItemScheduleEntity[intIndexSch].ref_doc_no = POPUPEntityObject.doc_no;
                    dgItemScheduleEntity[intIndexSch].ref_doc_cat = POPUPEntityObject.doc_cat;
                    dgItemScheduleEntity[intIndexSch].ref_doc_type = POPUPEntityObject.doc_type;
                    dgItemScheduleEntity[intIndexSch].ref_doc_date = POPUPEntityObject.doc_date;
                    dgItemScheduleEntity[intIndexSch].pur_req_item_row_id = POPUPEntityObject.id;
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
        private void SubTotalCalculation(int RowIndex)
        {
            try
            {
                if (dgItemsEntity.Count > 0)
                {
                    dgItemsEntity[RowIndex].sub_total = (dgItemsEntity[RowIndex].qty * dgItemsEntity[RowIndex].unit_price) - ((dgItemsEntity[RowIndex].qty * dgItemsEntity[RowIndex].unit_price) * (dgItemsEntity[RowIndex].discount / 100));
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

        //
        // Summary:
        //     This Method load Document Data for Reference document and for Flip DataGrid.
        //     Call for two seperate purpose
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference) //For Flip
        {
            EntityChangeEnable = false;
            CursorControl.SetBusyState();
            try
            {
                string Request = "";
                string ParametersStringValue = "";

                PUR_T002_AFlip ParameterEntityObject = null;

                if (ParameterObject.GetType() == typeof(string))
                {
                    ParameterEntityObject = new PUR_T002_AFlip(); // NOTE: all this assignment is temporary because below it is hardcoded for "LoadPartyDetails" request. make it dynamic and remove all from here.
                    ParameterEntityObject.comp_code = STD_OBJECT.comp_code;
                    ParameterEntityObject.location_id = STD_OBJECT.location_id;
                    ParameterEntityObject.po_code = STD_OBJECT.po_code;
                    ParameterEntityObject.pg_code = STD_OBJECT.pg_code;
                    ParameterEntityObject.PartyId = STD_OBJECT.party_code;
                    Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@!@!@!@" + ParameterObject.ToString();
                    //Request = "LOAD_DOC_BY_DOC_NO" + "!@" + ParameterObject.ToString();
                }
                else
                {
                    if (((IEnumerable)ParameterObject).Cast<PUR_T002_AFlip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<PUR_T002_AFlip>().ToList()[0];
                        Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + ParameterEntityObject.comp_code + "!@!@!@!@" + ParameterEntityObject.po_no + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + ParameterEntityObject.po_code + "!@" + (ParameterEntityObject.pg_code ?? "") + "!@" + ParameterEntityObject.PartyId;
                        //Request = "LOAD_DOC_BY_DOC_NO" + "!@" + ParameterEntityObject.po_no;
                    }
                }
                NewRecord = false;
                string RequestParameterData = "LoadPartyDetails" + "!@" + AppSessionState.client + "!@" + (MasterEntity.comp_code ?? ParameterEntityObject.comp_code) + "!@" + (MasterEntity.location_Id ?? ParameterEntityObject.location_id) + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + (ParameterEntityObject.po_code ?? AppSessionState.po_code) + "!@" + ((ParameterEntityObject.pg_code ?? AppSessionState.pg_code) ?? "") + "!@" + (ParameterEntityObject == null ? "" : ParameterEntityObject.PartyId);
                //string RequestParameterData = "LoadPartyDetails" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + "PO" + "!@" + "PO" + "!@" + AppSessionState.po_code + "!@" + AppSessionState.pg_code + "!@" + AppSessionState.EmpId;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, RequestParameterData, "PRO_T002_BL", "PRO", "", 0, "");

                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, Request, "PRO_T002_BL", "PRO", "LOAD_DOC_BY_DOC_NO", 0, "");
                ApprovalData = MCTemp.ApprovalData;


                if (MCTemp.DocumentItems != null)
                {
                    dgItemsEntity.Clear();
                    dgItemsEntity = MCTemp.DocumentItems;
                    if (MCTemp.DocumentMaster.Count > 0)
                    {
                        MasterEntity = MCTemp.DocumentMaster[0];
                        MasterEntity.supplier_EmpId = MCTemp.DocumentMaster[0].supplier_EmpId;
                    }
                    PersonEmailId = MasterEntity.PersnEmailId;
                    PartyEmailId = MasterEntity.EmailId;
                    MasterEntity.p_term_code = MasterEntity.p_term_code; // NOTE: It is reassign to reset instruction values because it is cleared at MCTemp assignment and do not reinvoke PropertyCHange on assignment of Master Entity after LoadDocument. FIx this on priority.
                }
                else
                {
                    MCTemp.DocumentItems = new ObservableCollection<PUR_T002_B>();
                }
                if (MCTemp.DocumentTaxDetails != null)
                {
                    TotalDocumentTaxes = MCTemp.DocumentTaxDetails;
                }
                else
                {
                    MCTemp.DocumentTaxDetails = new ObservableCollection<ACC_T006_B>();
                }
                if (MCTemp.DocumentScheduleMaster != null)
                {
                    if (MCTemp.DocumentScheduleMaster.Count > 0)
                    {
                        ScheduleEntity = MCTemp.DocumentScheduleMaster[0];
                    }
                }
                else
                {
                    ScheduleEntity = new PUR_T004_A();
                }
                if (MCTemp.DocumentScheduleDetails != null)
                {
                    dgItemScheduleEntity.Clear();
                    dgItemScheduleEntity = MCTemp.DocumentScheduleDetails;
                }
                else
                {
                    MCTemp.DocumentScheduleDetails = new ObservableCollection<PUR_T004_B>();
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
                if (MCTemp.Attachment != null)
                {
                    AttachmentCollection = MCTemp.Attachment;
                }
                else
                {
                    MCTemp.Attachment = new List<COM_T003>();
                }
                if (MCTemp.DocumentDataFlipGrid != null && NewRecord == true && ParameterObject == "Save")
                {
                    FlipGridData = MCTemp.DocumentDataFlipGrid;
                    FlipGridData.Add(MCTemp.DocumentDataFlipGrid[0]);
                    DataGridCollection.Refresh();
                }

                if (MCTemp.TermsAndCondition != null)
                {
                    TermsConditionEntity = MCTemp.TCondition;
                }
                else
                {
                    MCTemp.TCondition = new ObservableCollection<GEN_T011>();
                }
                if (MCTemp.ComponantList != null)
                {
                    dgComponantEntity = MCTemp.ComponantList;
                }
                else
                {
                    dgComponantEntity = new ObservableCollection<PUR_T002_C>();
                }

                //New PopUP - ContactPerson
                //List<ADM_M028_C_P> ContactPerson = MCTemp.ContactPerson.Where(x => x.supplier_EmpId != null).ToList();
                string strConPerson = "";
                if (MCTemp.DocumentMaster.Count > 0)
                {
                    strConPerson = MCTemp.DocumentMaster[0].supplier_EmpId;
                }
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).supplier_EmpId.ToString());
                TheFilter = (o, prefix) => ((ADM_M028_C_P)o).ContInfoId.ToString().ToLower().Contains(prefix) ||
                                            ((ADM_M028_C_P)o).supplier_EmpId.ToString().ToLower().Contains(prefix) ||
                                           ((ADM_M028_C_P)o).PersonName.ToString().ToLower().Contains(prefix);
                ASContactPerson = new AutoSuggestTextViewModel<dynamic>(MCTemp.ContactPerson, TheFilter, SuggestedValue, "supplier_EmpId", true);
                ASContactPerson.AutoSuggestVM.IsEmptyValueAllowed = true;
                MasterEntity.supplier_EmpId = strConPerson;
                MC.ContactPerson = MCTemp.ContactPerson;
                SelectedTabControlIndex = 0;
                SetPopupSuggestionDataAfterLoad();
                MasterEntity.ts_code = ts_code_vm;
                EntityChangeEnable = true;
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
            try
            {
                ASDelAddress.AutoSuggestVM.Suggestion = MC.deladdrList.Find(x => x.location_Id == MasterEntity.del_address_id);
                ASPurOrg.AutoSuggestVM.Suggestion = PurchaseOrganisationList.Find(x => x.po_code == MasterEntity.po_code);


                ASOrderType.AutoSuggestVM.Suggestion = MC.DOC_TYPE_LIST.Find(x => x.doc_type_user == MasterEntity.doc_type_user);
                ASValidatedBy.AutoSuggestVM.Suggestion = MC.BuyerList.Find(x => x.EmpId == MasterEntity.buyer);
                ASSupplier.AutoSuggestVM.Suggestion = MC.partyList.Find(x => x.PartyId == MasterEntity.PartyId);

                ASBuyer.AutoSuggestVM.Suggestion = MC.BuyerList.Find(x => x.EmpId == MasterEntity.buyer);
                ASBillAddress.AutoSuggestVM.Suggestion = MC.deladdrList.Find(x => x.location_Id == MasterEntity.bill_address_id);
                ASCurrency.AutoSuggestVM.Suggestion = MC.CURRENCY_LIST.Find(x => x.curr_code == MasterEntity.curr_code);
                ASPaymentTerm.AutoSuggestVM.Suggestion = MC.PayTerms.Find(x => x.p_term_code == MasterEntity.p_term_code);

                ASPurGrp.AutoSuggestVM.Suggestion = PurchaseGroupList.Find(x => x.pg_code == MasterEntity.pg_code);
                ASDestWar.AutoSuggestVM.Suggestion = MC.WarehouseList.Find(x => x.wa_code == MasterEntity.wa_code);
                ASStorLoc.AutoSuggestVM.Suggestion = MC.storage_locList.Find(x => x.store_code == MasterEntity.stock_location_id);
                ASIncoTerms.AutoSuggestVM.Suggestion = MC.Incoterms.Find(x => x.incoterms == MasterEntity.incoterms);
                ASEPCG.AutoSuggestVM.Suggestion = MC.LicenseEPCG.Find(x => x.lic_cod == MasterEntity.lic_cod);
                ASAdvance.AutoSuggestVM.Suggestion = MC.LicenseAdvance.Find(x => x.lic_cod == MasterEntity.adv_lic_cd);
                ASCostCentre.AutoSuggestVM.Suggestion = MC.cost_centerList.Find(x => x.cost_center == MasterEntity.cost_center);
                ASBussPlace.AutoSuggestVM.Suggestion = MC.BussinessPlaceList.Find(x => x.buss_place == MasterEntity.buss_place);

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

        #endregion
        #region Validation Region


#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        #endregion

        #region Abstract Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<PUR_T002_A> result)
        {
            CursorControl.SetBusyState();
            try
            {
                if (Validation() == true)
                {
                    this.StatusMessage = "Saving changes, please wait ...";
                    Logging();
                    MasterEntity.XmlDataDocument_PUR_T002_B = obj.ObjectToXML(dgItemsEntity);
                    MasterEntity.XmlDataDocument_PUR_T002_C = obj.ObjectToXML(dgComponantEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_B = obj.ObjectToXML(TotalDocumentTaxes);
                    MasterEntity.XmlDataDocument_PUR_T004_A = obj.ObjectToXML(ScheduleEntity);
                    MasterEntity.XmlDataDocument_PUR_T004_B = obj.ObjectToXML(dgItemScheduleEntity);
                    MasterEntity.XDOC_TC = obj.ObjectToXML(TermsConditionEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_D = obj.ObjectToXML(LicenceDetailsEntity);


                    this.MasterEntity.EndEdit();
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<PUR_T002_A>(MasterEntity, "PRO_T002_BL", "PRO");
                        SetBusinessEntitiesAfterLoad("Save", "");
                        if (MasterEntity.po_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnInsert") >= 0)
                        {
                            NotifyMessage("OnInsert", "Created");
                        }
                        if (MasterEntity.po_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnApproval") >= 0)
                        {
                            NotifyMessage("OnApproval", "Created");
                        }
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<PUR_T002_A>(MasterEntity, "PRO_T002_BL", "PRO");
                        SetBusinessEntitiesAfterLoad("Save", "");
                        if (MasterEntity.po_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnUpdate") >= 0)
                        {
                            NotifyMessage("OnUpdate", "Created");
                        }
                        if (MasterEntity.po_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnApproval") >= 0)
                        {
                            NotifyMessage("OnApproval", "Created");
                        }
                    }
                   
                    if (ind_value==null && !string.IsNullOrWhiteSpace(MasterEntity.po_no) && MasterEntity.active == true)
                    {
                        SelectedTabIndexItem = 0; // This is for shifting focus from Editor control
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record saved Successfully ........");
                        showMessageService.ShowMessage();
                    }
                    if (MasterEntity.active == false)
                    {
                        NewRecord = true;
                        MasterEntity = new PUR_T002_A();
                        MasterEntity.ValidateAsync().Wait();
                        dgItemsEntity = new ObservableCollection<PUR_T002_B>();
                        TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
                        TermsConditionEntity = new ObservableCollection<GEN_T011>();
                        LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
                        dgTotalTaxSummury = new ObservableCollection<PUR_T002_C>();
                        ScheduleEntity = new PUR_T004_A();
                        dgItemScheduleEntity = new ObservableCollection<PUR_T004_B>();

                    }
                    NewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                }
                SelectedTabIndexItem = 0;
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
            if (MasterEntity.XmlDataDocument_PUR_T002_B != null)
            {

                dgItemsEntity.Clear();
                dgItemsEntity = (ObservableCollection<PUR_T002_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PUR_T002_B, MC.DocumentItems);
                MasterEntity = MasterEntity;
            }
            else
            {
                MC.DocumentItems = new ObservableCollection<PUR_T002_B>();
            }
            if (MasterEntity.XmlDataDocument_ACC_T006_B != null)
            {
                MC.DocumentTaxDetails = (ObservableCollection<ACC_T006_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_T006_B, MC.DocumentTaxDetails);
                TotalDocumentTaxes.Clear();
                TotalDocumentTaxes = MC.DocumentTaxDetails;
                //var GroupByTaxQuery = from wo in TotalDocumentTaxes
                //                      group wo by wo.tax_name
                //           into g
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
                MC.DocumentTaxDetails = new ObservableCollection<ACC_T006_B>();
            }
            if (MasterEntity.XmlDataDocument_PUR_T004_A != null)
            {
                List<PUR_T004_A> ScheduleEntityList = new List<PUR_T004_A>();
                ScheduleEntityList = (List<PUR_T004_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PUR_T004_A, ScheduleEntityList);
                if (ScheduleEntityList.Count > 0)
                {
                    ScheduleEntity = ScheduleEntityList[0];
                }
            }
            else
            {
                ScheduleEntity = new PUR_T004_A();
            }
            if (MasterEntity.XmlDataDocument_PUR_T004_B != null)
            {
                MC.DocumentScheduleDetails = (ObservableCollection<PUR_T004_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PUR_T004_B, MC.DocumentScheduleDetails);
                dgItemScheduleEntity.Clear();
                dgItemScheduleEntity = MC.DocumentScheduleDetails;
            }
            else
            {
                MC.DocumentScheduleDetails = new ObservableCollection<PUR_T004_B>();
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
            if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
            {
                MC.DocumentDataFlipGrid = (List<PUR_T002_AFlip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                if (DataGridCollection != null)
                {
                    DataGridCollection.Refresh();
                    DataGridCollection.SortDescriptions.Add(new SortDescription("po_no", ListSortDirection.Descending));
                }
            }
            if (MasterEntity.XDOC_TC != null)
            {

                MC.TCondition = (ObservableCollection<GEN_T011>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_TC, MC.TCondition);

                TermsConditionEntity = MC.TCondition;
            }
            else
            {
                MC.TCondition = new ObservableCollection<GEN_T011>();
            }
            if (MasterEntity.XmlDataDocument_PUR_T002_C != null)
            {
                if (dgComponantEntity.Count > 0)
                {
                    dgComponantEntity.Clear();
                }
                dgComponantEntity = (ObservableCollection<PUR_T002_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PUR_T002_C, MC.ComponantList);
            }
            else
            {
                MC.ComponantList = new ObservableCollection<PUR_T002_C>();
                dgComponantEntity = new ObservableCollection<PUR_T002_C>();
            }

            RemoveRefDoc(ind_value);

        }
        private void RemoveRefDoc(string request)
        {
            try
            {
                List<STD_LIST_BE> TempListReq = MC.PR_LIST;
                foreach (var item in TempListReq.ToList())
                {
                    if (item.selected == true && request == null) // if this call during Auto RFQ then auto function will not work after first RFQ because all selected item will get clear so checking ind_value also. Call this function after completion of Auto RFQ.
                    {
                        MC.PR_LIST.Remove(item);
                    }
                }
                ReferenceDocRQCollection = CollectionViewSource.GetDefaultView(MC.PR_LIST);
                ReferenceDocRQCollection.Filter = new Predicate<object>(FilterRequisitionNo);
                ReferenceDocRQCollection.Refresh();

                PR_ITEM_COLL_SORTED = CollectionViewSource.GetDefaultView(MC.PR_LIST.Where(x => x.id != null));
                PR_ITEM_COLL_SORTED.Filter = new Predicate<object>(FilterRequisitionNo);

                PR_ITEM_COLL = CollectionViewSource.GetDefaultView(MC.PR_LIST);
                PR_ITEM_COLL.Filter = new Predicate<object>(FilterRequisitionNo);
                //if (MasterEntity.ref_doc_no != null)
                //{
                //    List<string> DocList = DocumentList.Split(',').ToList();
                //    foreach (var item in DocList)
                //    {
                //        MC.reference_docList.RemoveAll(X => X.po_no == item);
                //    }

                //    refdoctempa = (from o in MC.reference_docList where o.doc_cat == "RQ" select o).ToList();
                //    ReferenceDocRQCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                //    ReferenceDocRQCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                //    refdoctempa = (from o in MC.reference_docList where o.doc_cat == "IN" select o).ToList();
                //    ReferenceDocINCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                //    ReferenceDocINCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                //    refdoctempa = (from o in MC.reference_docList where o.doc_cat == "QP" select o).ToList();
                //    ReferenceDocQPCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                //    ReferenceDocQPCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
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
        protected override void OnCreateAction(InquiryActionResult<PUR_T002_A> result)
        {
            NewRecord = true;
            DocumentList = "";
            foreach (var item in MC.reference_docList)
            {
                if (item.Select == true)
                {
                    item.Select = false;
                }
            }
            //refdoctempa = (from o in MC.reference_docList where o.doc_cat == "RQ" select o).ToList();
            //ReferenceDocRQCollection = CollectionViewSource.GetDefaultView(refdoctempa);
            refdoctempa = (from o in MC.reference_docList where o.doc_cat == "IN" select o).ToList();
            ReferenceDocINCollection = CollectionViewSource.GetDefaultView(refdoctempa);
            refdoctempa = (from o in MC.reference_docList where o.doc_cat == "QP" select o).ToList();
            ReferenceDocQPCollection = CollectionViewSource.GetDefaultView(refdoctempa);

            MasterEntity = new PUR_T002_A();
            //MasterEntity.ValidateAsync().Wait();
            dgItemsEntity = new ObservableCollection<PUR_T002_B>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
            TermsConditionEntity = new ObservableCollection<GEN_T011>();
            dgTotalTaxSummury = new ObservableCollection<PUR_T002_C>();
            ScheduleEntity = new PUR_T004_A();
            dgItemScheduleEntity = new ObservableCollection<PUR_T004_B>();
            dgComponantEntity = new ObservableCollection<PUR_T002_C>();
            LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
            TCEntityObject = new GEN_T011();
            DefaultValues(this.doc_cat_vm);
            
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
        }
        protected override void OnRemoveAction(InquiryActionResult<PUR_T002_A> result)
        {
            if (MasterEntity.active == false)
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
                    this.MasterEntity.EndEdit();
                    string response = repository.Delete(MasterEntity.po_no, "PRO_T002_BL", "PRO");

                    MasterEntity = new PUR_T002_A();
                    dgItemsEntity = new ObservableCollection<PUR_T002_B>();
                    _dataGridCollection.Refresh();
                }
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<PUR_T002_A> result)
        {
            MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<PUR_T002_A> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<PUR_T002_A> result)
        {


        }
        protected override void OnHelpAction(InquiryActionResult<PUR_T002_A> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<PUR_T002_A> result)
        {
            CursorControl.SetBusyState();
            string Request = "";
            try
            {

                if (MasterEntity.po_no == null || MasterEntity.po_no == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("You must save the record before printing it.", this.Title);
                    showMessageService.ShowMessage();
                }
                //else if (MasterEntity.t_status != (from o in MC.t_statusList where o.ind_released == "1" select o.t_status).FirstOrDefault())
                //{
                //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //    showMessageService.ButtonSetup = DialogButton.Ok;
                //    showMessageService.Caption = "Information";
                //    showMessageService.Text = String.Format("Document cannot print or mail till the release or approved status!", this.Title);
                //    showMessageService.ShowMessage();
                //}
                else
                {
                    string ReportName = "";

                    object[] objDataSource = new object[8];
                    string[] objDataSourceName = new string[8];
                    if (MC.DocumentMaster != null)
                    {
                        if (MC.DocumentMaster.Count > 0)
                        {
                            MC.DocumentMaster.Clear();
                            MC.DocumentMaster.Add(MasterEntity);
                        }
                        else
                        {
                            MC.DocumentMaster.Add(MasterEntity);
                        }
                    }

                    objDataSource[0] = MC.DocumentMaster;
                    objDataSource[1] = dgItemsEntity;
                    objDataSource[2] = TotalDocumentTaxes;
                    objDataSource[3] = ((List<ADM_M002>)AppSessionState.ADM_M002_List).Where(loc => loc.comp_code == MasterEntity.comp_code).ToList();

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.del_address_id).ToList();
                    var ResultBillingAddress = TempList.Where(loc => loc.location_Id == MasterEntity.bill_address_id).ToList();
                    objDataSource[4] = Result;
                    objDataSource[5] = dgItemScheduleEntity;
                    objDataSource[6] = TermsConditionEntity;
                    objDataSource[7] = ResultBillingAddress;

                    objDataSourceName[0] = "dsMaster";
                    objDataSourceName[1] = "dsItem";
                    objDataSourceName[2] = "dsTax";
                    objDataSourceName[3] = "dsCompany";
                    objDataSourceName[4] = "dsLocation";
                    objDataSourceName[5] = "dsSchedule";
                    objDataSourceName[6] = "dsTC";
                    objDataSourceName[7] = "dsBillingAddress";

                    var ReportStringList = (from o in MC.DOC_TYPE_LIST where o.doc_type == MasterEntity.doc_type select o).ToList();
                    if (MasterEntity.doc_type == "IO")
                    {
                        ReportName = ReportStringList[0].report_name.Split(',')[0];

                    }
                    else
                    {
                        ReportName = ReportStringList[0].report_name.Split(',')[0];
                    }

                    ReportManager ReportManager = new ReportManager();
                    string ReportDisplayName = MasterEntity.party_name + "_" + MasterEntity.po_no + "_" + MasterEntity.po_date.Value.ToShortDateString();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORTS_STD\\TXN\\" + ReportName, getParametersList(), ReportDisplayName);

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
            if (!string.IsNullOrEmpty(MasterEntity.po_no))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.po_no.Replace("/", "--"), DocumentList = MCTemp.Attachment, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<PUR_T002_A> result)
        {
            LoadInitialData(doc_cat_vm, null);
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PUR_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PUR_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PUR_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PUR_T002_A> result)
        {
            throw new NotImplementedException();
        }
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

                if (MasterEntity.po_no == null || MasterEntity.po_no == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("You must save the record before printing it.", this.Title);
                    showMessageService.ShowMessage();
                }
                else if (MasterEntity.t_status != (from o in MC.t_statusList where o.ind_released == "1" select o.t_status).FirstOrDefault())
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Information";
                    showMessageService.Text = String.Format("Document cannot print or mail till the release or approved status!", this.Title);
                    showMessageService.ShowMessage();
                }
                else if(MasterEntity.t_status != (from o in MC.t_statusList where o.ind_released == "1" select o.t_status).FirstOrDefault())
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Information";
                    showMessageService.Text = String.Format("Document cannot print or mail till the release or approved status!", this.Title);
                    showMessageService.ShowMessage();
                }
                else if (!string.IsNullOrWhiteSpace(MasterEntity.po_no))
                {
                    string ReportName = "";
                    ReportManager RPT_MGR = new ReportManager();
                    object[] objDataSource = new object[8];
                    string[] objDataSourceName = new string[8];
                    if (MC.DocumentMaster != null)
                    {
                        if (MC.DocumentMaster.Count > 0)
                        {
                            MC.DocumentMaster.Clear();
                            MC.DocumentMaster.Add(MasterEntity);
                        }
                        else
                        {
                            MC.DocumentMaster.Add(MasterEntity);
                        }
                    }

                    objDataSource[0] = MC.DocumentMaster;
                    objDataSource[1] = dgItemsEntity;
                    objDataSource[2] = TotalDocumentTaxes;
                    objDataSource[3] = ((List<ADM_M002>)AppSessionState.ADM_M002_List).Where(loc => loc.comp_code == MasterEntity.comp_code).ToList();

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.del_address_id).ToList();
                    var ResultBillingAddress = TempList.Where(loc => loc.location_Id == MasterEntity.bill_address_id).ToList();
                    objDataSource[4] = Result;
                    objDataSource[5] = dgItemScheduleEntity;
                    objDataSource[6] = TermsConditionEntity;
                    objDataSource[7] = ResultBillingAddress;

                    objDataSourceName[0] = "dsProMaster";
                    objDataSourceName[1] = "dsProItems";
                    objDataSourceName[2] = "dsProTax";
                    objDataSourceName[3] = "dsCompany";
                    objDataSourceName[4] = "dsLocation";
                    objDataSourceName[5] = "dsSchedule";
                    objDataSourceName[6] = "dsTermsCondition";
                    objDataSourceName[7] = "dsBillingAddress";

                    var SystemDocumentObject = (from o in MC.DOC_TYPE_LIST where o.doc_type == MasterEntity.doc_type select o).ToList();
                    
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
                        DisplaytName = MasterEntity.doc_desc + "_" + MasterEntity.po_no.Replace(@"/", "-").Replace(@"\", "-") + "_" + MasterEntity.po_date.Value.Date.ToShortDateString().Replace(@"/", string.Empty).Replace(@"\", string.Empty);
                        MessageData = "<h3>Commercial Document for RFQ!</h3><p>Dear Sir!</p><p>Please find attached herewith commercial document for Purchase Order as per your requirements. </p><p>-" + AppSessionState.CompanyName + "</p>";

                        RPT_MGR.Mail(To, Cc, Bcc, objDataSource, objDataSourceName, null, "\\REPORTS_STD\\TXN\\" + ReportName, DisplaytName, "Purchase Order Prepared against RFQ By " + AppSessionState.CompanyName, MessageData, "", ".pdf");
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

        #endregion
        #region Filters


        private string _FilterString_ContactPerson;
        public string FilterString_ContactPerson
        {
            get { return _FilterString_ContactPerson; }
            set
            {
                _FilterString_ContactPerson = value;
                RaisePropertyChanged("FilterString_ContactPerson");
                FilterContactPersonCollection();
            }
        }
        private void FilterContactPersonCollection()
        {
            if (_ContactPersonCollection != null)
            {
                _ContactPersonCollection.Refresh();
            }
        }
        public bool Filter_Contactperson(object obj)
        {
            var data = obj as ADM_M028_C_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_ContactPerson))
                {
                    return (data.ContInfoId != null && data.ContInfoId.ToString().ToLower().Contains(_FilterString_ContactPerson.ToLower())) ||
                        (data.PersonName != null && data.PersonName.ToString().ToLower().Contains(_FilterString_ContactPerson.ToLower()));

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
                //NotifyPropertyChanged("FilterString_FlipGrid");
                FilterCollection();
            }
        }
        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as PUR_T002_AFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return (data.po_no != null && data.po_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.po_date != null && data.po_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                         (data.Buyer_Name != null && data.Buyer_Name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.supplier_ref != null && data.supplier_ref.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.t_display != null && data.t_display.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.party_name != null && data.party_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }

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
            if (_partyCollection != null)
            {
                _partyCollection.Refresh();
            }
        }
        public bool FilterParty(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_party))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_party.ToLower()) ||
                        data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_party.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_uom;
        public string FilterString_uom
        {
            get { return _filterString_uom; }
            set
            {
                _filterString_uom = value;
                RaisePropertyChanged("FilterString_uom");
                FilterCollectionuom();
            }
        }
        private void FilterCollectionuom()
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
                if (!string.IsNullOrEmpty(_filterString_uom))
                {
                    return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterString_uom.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_Buyer;
        public string FilterString_buyer
        {
            get { return _filterString_Buyer; }
            set
            {
                _filterString_Buyer = value;
                RaisePropertyChanged("FilterString_buyer");
                FilterCollectionbuyer();
            }
        }
        private void FilterCollectionbuyer()
        {
            if (_buyerCollection != null)
            {
                _buyerCollection.Refresh();
            }
        }
        public bool FilterBuyer(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Buyer))
                {
                    return (data.EmpLName != null && data.EmpLName.ToString().ToLower().Contains(_filterString_Buyer.ToLower()) ||
                         data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterString_Buyer.ToLower())
                        );
                }
                return true;
            }
            return false;
        }

        private string _filterString_journal;
        public string FilterString_journal
        {
            get { return _filterString_journal; }
            set
            {
                _filterString_journal = value;
                RaisePropertyChanged("FilterString_journal");
                FilterCollection_journal();
            }
        }
        private void FilterCollection_journal()
        {
            if (journalCollection != null)
            {
                journalCollection.Refresh();
            }
        }
        public bool journal_Filter(object obj)
        {
            var data = obj as ACC_M005_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_journal))
                {
                    return (data.j_name != null && data.j_name.ToString().ToLower().Contains(_filterString_journal.ToLower()) ||
                         data.j_code != null && data.j_code.ToString().ToLower().Contains(_filterString_journal.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_payterms;
        public string FilterString_Payterms
        {
            get { return _filterString_payterms; }
            set
            {
                _filterString_payterms = value;
                RaisePropertyChanged("FilterString_Payterms");
                FilterCollectionPayTerm();
            }
        }
        private void FilterCollectionPayTerm()
        {
            if (_paytermCollection != null)
            {
                _paytermCollection.Refresh();
            }
        }
        public bool FilterPayTerms(object obj)
        {
            var data = obj as ACC_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_payterms))
                {
                    return (data.p_term != null && data.p_term.ToString().ToLower().Contains(_filterString_payterms.ToLower()) ||
                        data.p_term_code != null && data.p_term_code.ToString().ToLower().Contains(_filterString_payterms.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_warehouse;
        public string FilterString_Warehouse
        {
            get { return _filterString_warehouse; }
            set
            {
                _filterString_warehouse = value;
                RaisePropertyChanged("FilterString_Warehouse");
                FilterCollectionWarehouse();
            }
        }
        private void FilterCollectionWarehouse()
        {
            if (_warehouseCollection != null)
            {
                _warehouseCollection.Refresh();
            }
        }
        public bool FilterCollectionWarehouse(object obj)
        {
            var data = obj as MM_M002_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_warehouse))
                {
                    return (data.wa_code != null && data.wa_code.ToString().ToLower().Contains(_filterString_warehouse.ToLower()) ||
                       data.wa_name != null && data.wa_name.ToString().ToLower().Contains(_filterString_warehouse.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_doctype;
        public string FilterString_doctype
        {
            get { return _filterString_doctype; }
            set
            {
                _filterString_doctype = value;
                RaisePropertyChanged("FilterString_doctype");
                FilterCollection_doctype();
            }
        }
        private void FilterCollection_doctype()
        {
            if (_doc_typeCollection != null)
            {
                _doc_typeCollection.Refresh();
            }
        }
        public bool doctype_Filter(object obj)
        {
            var data = obj as STD_DOC_TYPE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_doctype))
                {
                    return (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_filterString_doctype.ToLower())) ||
                        (data.doc_type_name != null && data.doc_type_name.ToString().ToLower().Contains(_filterString_doctype.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_currency;
        public string FilterString_currency
        {
            get { return _filterString_currency; }
            set
            {
                _filterString_currency = value;
                RaisePropertyChanged("FilterString_currency");
                FilterCollection_currency();
            }
        }
        private void FilterCollection_currency()
        {
            if (_currencyCollection != null)
            {
                _currencyCollection.Refresh();
            }
        }
        public bool currency_Filter(object obj)
        {
            var data = obj as ADM_M037;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_currency))
                {
                    return (data.curr_code != null && data.curr_code.ToString().ToLower().Contains(_filterString_currency.ToLower())) ||
                       (data.curr_name != null && data.curr_name.ToString().ToLower().Contains(_filterString_currency.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_PurOrg;
        public string FilterString_PurOrg
        {
            get { return _filterString_PurOrg; }
            set
            {
                _filterString_PurOrg = value;
                RaisePropertyChanged("FilterString_PurOrg");
                FilterCollection_PurOrg();
            }
        }
        private void FilterCollection_PurOrg()
        {
            if (po_orgCollection != null)
            {
                po_orgCollection.Refresh();
            }
        }
        public bool Purorg_Filter(object obj)
        {
            var data = obj as ADM_M001_M_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_PurOrg))
                {
                    return (data.po_code != null && data.po_code.ToString().ToLower().Contains(_filterString_PurOrg.ToLower())) ||
                       (data.pur_org != null && data.pur_org.ToString().ToLower().Contains(_filterString_PurOrg.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_pur_grp;
        public string FilterString_pur_grp
        {
            get { return _filterString_pur_grp; }
            set
            {
                _filterString_pur_grp = value;
                RaisePropertyChanged("FilterString_pur_grp");
                FilterCollection_pur_grp();
            }
        }
        private void FilterCollection_pur_grp()
        {
            if (Purchase_groupCollection != null)
            {
                Purchase_groupCollection.Refresh();
            }
        }
        public bool Purchase_grp_Filter(object obj)
        {
            var data = obj as ADM_M001_P_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_pur_grp))
                {
                    return (data.pg_code != null && data.pg_code.ToString().ToLower().Contains(_filterString_pur_grp.ToLower())) ||
                        (data.pg_name != null && data.pg_name.ToString().ToLower().Contains(_filterString_pur_grp.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_storage_loc;
        public string FilterString_storage_loc
        {
            get { return _filterString_storage_loc; }
            set
            {
                _filterString_storage_loc = value;
                RaisePropertyChanged("FilterString_storage_loc");
                FilterCollection_storage_loc();
            }
        }
        private void FilterCollection_storage_loc()
        {
            if (_storage_locCollection != null)
            {
                _storage_locCollection.Refresh();
            }
        }
        public bool storage_loc_Filter(object obj)
        {
            var data = obj as MM_M001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_storage_loc))
                {
                    return (data.store_code != null && data.store_code.ToString().ToLower().Contains(_filterString_storage_loc.ToLower())) ||
                        (data.store_name != null && data.store_name.ToString().ToLower().Contains(_filterString_storage_loc.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_cost_center;
        public string FilterString_cost_center
        {
            get { return _filterString_cost_center; }
            set
            {
                _filterString_cost_center = value;
                RaisePropertyChanged("FilterString_cost_center");
                FilterCollection_cost_center();
            }
        }
        private void FilterCollection_cost_center()
        {
            if (cost_centerCollection != null)
            {
                cost_centerCollection.Refresh();
            }
        }
        public bool cost_center_Filter(object obj)
        {
            var data = obj as ACC_M019_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_cost_center))
                {
                    return (data.cost_center != null && data.cost_center.ToString().ToLower().Contains(_filterString_cost_center.ToLower())) ||
                        (data.cost_center_Desc != null && data.cost_center_Desc.ToString().ToLower().Contains(_filterString_cost_center.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_billaddr;
        public string FilterString_billaddr
        {
            get { return _filterString_billaddr; }
            set
            {
                _filterString_billaddr = value;
                RaisePropertyChanged("FilterString_billaddr");
                FilterCollectionbilladdr();
            }
        }
        private void FilterCollectionbilladdr()
        {
            if (_billAddrCollection != null)
            {
                _billAddrCollection.Refresh();
            }
            else if (_billAddrCollection != null)
            {
                _billAddrCollection.Refresh();
            }

        }
        public bool Filterbilladdr(object obj)
        {
            var data = obj as ADM_M002_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_billaddr))
                {
                    return (data.CompName != null && data.CompName.ToString().ToLower().Contains(_filterString_billaddr.ToLower()) ||
                         data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterString_billaddr.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_deladdr;
        public string FilterString_deladdr
        {
            get { return _filterString_deladdr; }
            set
            {
                _filterString_deladdr = value;
                RaisePropertyChanged("FilterString_deladdr");
                FilterCollectiondeladdr();
            }
        }
        private void FilterCollectiondeladdr()
        {
            if (_delAddrCollection != null)
            {
                _delAddrCollection.Refresh();
            }
            else if (_billAddrCollection != null)
            {
                _billAddrCollection.Refresh();
            }

        }
        public bool Filterdeladdr(object obj)
        {
            var data = obj as ADM_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_deladdr))
                {
                    return (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_deladdr.ToLower()) ||
                        data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_deladdr.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_itemcategory;
        public string FilterString_itemcategory
        {
            get { return _filterString_itemcategory; }
            set
            {
                _filterString_itemcategory = value;
                RaisePropertyChanged("_filterString_itemcategory");
                FilterCollectionitemcategory();
            }
        }
        private void FilterCollectionitemcategory()
        {
            if (_itemcategoryCollection != null)
            {
                _itemcategoryCollection.Refresh();
            }
        }
        public bool Filteritemcategory(object obj)
        {
            var data = obj as SYS_M008_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_itemcategory))
                {
                    return (data.item_cat != null && data.item_cat.ToString().ToLower().Contains(_filterString_itemcategory.ToLower()) ||
                        data.cat_desc != null && data.cat_desc.ToString().ToLower().Contains(_filterString_itemcategory.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _FilterStringValidator;
        public string FilterStringValidator
        {
            get { return _FilterStringValidator; }
            set
            {
                _FilterStringValidator = value;
                RaisePropertyChanged("FilterStringValidator");
                FilterCollectionvalidator();
            }
        }
        private void FilterCollectionvalidator()
        {
            if (_validatedByCollection != null)
            {
                _validatedByCollection.Refresh();
            }
        }
        public bool Filtervalidator(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringValidator))
                {
                    return (data.EmpLName != null && data.EmpLName.ToString().ToLower().Contains(_FilterStringValidator.ToLower()) ||
                        data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_FilterStringValidator.ToLower())
                       );
                }
                return true;
            }
            return false;
        }
        private void FilterLicenceDataGrid()
        {
            try
            {
                if (LicenceDetailsEntity != null && LicenceDetailsEntity.Count > 0 && ItemEntityObject != null)
                {

                    DataGridViewFilter = CollectionViewSource.GetDefaultView(LicenceDetailsEntity);
                    DataGridViewFilter.Filter = adv => ((ACC_T006_D)adv).ItemCode.Equals(ItemEntityObject.ItemCode);
                    DataGridViewFilter.Refresh();
                }

            }
            catch (Exception ex)
            { }
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





        #region . TaxAccount Filter.
        private string _FilterString_tax;
        public string FilterString_tax
        {
            get { return _FilterString_tax; }
            set
            {
                _FilterString_tax = value;
                RaisePropertyChanged("FilterString_tax");
                FilterCollectiontaxAcc();
            }
        }
        private void FilterCollectiontaxAcc()
        {
            if (_dgPOItemsFortaxval != null)
            {
                _dgPOItemsFortaxval.Refresh();
            }
        }
        public bool FiltertaxAcc(object obj)
        {
            var data = obj as ACC_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_tax))
                {
                    return (data.acc_code != null && data.acc_code.ToString().ToLower().Contains(_FilterString_tax.ToLower())) ||
                           (data.p_name != null && data.p_name.ToString().ToLower().Contains(_FilterString_tax.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        private string _filterString_FormType;
        public string FilterString_FormType
        {
            get { return _filterString_FormType; }
            set
            {
                _filterString_FormType = value;
                RaisePropertyChanged("FilterString_FormType");
                FilterCollection_FormType();
            }
        }
        private void FilterCollection_FormType()
        {
            if (_FormTypeCollection != null)
            {
                _FormTypeCollection.Refresh();
            }
        }
        public bool Filter_FormType(object obj)
        {
            var data = obj as ACC_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_FormType))
                {
                    return (data.description != null && data.description.ToString().ToLower().Contains(_filterString_FormType.ToLower())) ||
                    (data.id != null && data.id.ToString().ToLower().Contains(_filterString_FormType.ToLower()));

                }
                return true;
            }
            return false;
        }


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
            if (_itemCollection != null)
            {
                _itemCollection.Refresh();
            }
        }
        public bool FilterItem(object obj)
        {
            var data = obj as PUR_T002_P_PR_ItemsList;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Item))
                {
                    return (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
                           (data.SubCatCode != null && data.SubCatCode.ToString().ToLower().Contains(_filterString_Item.ToLower())) ||
                            (data.Req_NO != null && data.Req_NO.ToString().ToLower().Contains(_filterString_Item.ToLower())) ||
                            data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_Item.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _FilterString_Componant;
        public string FilterString_Componant
        {
            get { return _FilterString_Componant; }
            set
            {
                _FilterString_Componant = value;
                RaisePropertyChanged("FilterString_Componant");
                FilterCollection_Componant();
            }
        }
        private void FilterCollection_Componant()
        {
            if (_ComponantCollection != null)
            {
                _ComponantCollection.Refresh();
            }
        }
        public bool Componant_Filter(object obj)
        {
            var data = obj as STD_ITEM;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_Componant))
                {
                    return (data.item_code != null && data.item_code.ToString().ToLower().Contains(_FilterString_Componant.ToLower())) ||
                        (data.item_name != null && data.item_name.ToString().ToLower().Contains(_FilterString_Componant.ToLower())) ||
                         (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_FilterString_Componant.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_scheduleItem;
        public string FilterString_scheduleItem
        {
            get { return _filterString_scheduleItem; }
            set
            {
                _filterString_scheduleItem = value;
                RaisePropertyChanged("_FilterString_scheduleItem");
                FilterCollectionscheduleItem();
            }
        }
        private void FilterCollectionscheduleItem()
        {
            if (_itemCollection != null)
            {
                _itemCollection.Refresh();
            }
        }
        // Pending Issue
        public bool FilterscheduleItem(object obj)
        {
            //var data = obj as PurchaseOrder_deliveryschedule;
            //if (data != null)
            //{
            //    if (!string.IsNullOrEmpty(_filterString_scheduleItem))
            //    {
            //        return (data.item_name != null && data.item_name.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
            //               (data.item_code != null && data.item_code.ToString().ToLower().Contains(_filterString_Item.ToLower())));
            //    }
            //    return true;
            //}
            return false;
        }

        // Pending Integration of FilterString_RefDocNo


        //New Reference filters
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
            if (ReferenceDocRQCollection != null)
            {
                ReferenceDocRQCollection.Refresh();
            }
            if (ReferenceDocINCollection != null)
            {
                ReferenceDocINCollection.Refresh();
            }
            if (ReferenceDocQPCollection != null)
            {
                ReferenceDocQPCollection.Refresh();
            }
        }
        public bool Filter_ReferenceDoc(object obj)
        {
            var data = obj as PUR_T002_P_RefeDoc;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_ReferenceDoc))
                {


                    return (data.po_no != null && data.po_no.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           (data.quotation_no != null && data.quotation_no.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower())) ||
                           (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower())) ||
                           (data.party_name != null && data.party_name.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower())) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower())) ||
                           data.partyId != null && data.partyId.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()));

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
            var data = obj as ADM_M0051;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_Terms))
                {
                    return (data.tc_code != null && data.tc_code.ToString().ToLower().Contains(_FilterString_Terms.ToLower())) ||
                        (data.con_group != null && data.con_group.ToString().ToLower().Contains(_FilterString_Terms.ToLower())) ||
                           (data.long_text != null && data.long_text.ToString().ToLower().Contains(_FilterString_Terms.ToLower()));

                }
                return true;
            }
            return false;
        }
        //pending delete if not use

        // filter string Requisition No

        private string _FilterString_Requisition;
        public string FilterString_Requisition
        {
            get { return _FilterString_Requisition; }
            set
            {
                _FilterString_Requisition = value;
                RaisePropertyChanged("FilterString_Requisition");
                FilterCollection_Requisition();
            }
        }
        private void FilterCollection_Requisition()
        {
            if (_PR_ITEM_COLL != null)
            {
                _PR_ITEM_COLL_SORTED.Refresh();
                _PR_ITEM_COLL.Refresh();
            }
        }
        public bool FilterRequisitionNo(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_Requisition))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(FilterString_Requisition.ToLower()) ||
                           (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(FilterString_Requisition.ToLower())) ||
                           (data.item_code != null && data.item_code.ToString().ToLower().Contains(FilterString_Requisition.ToLower())) ||
                           (data.item_name != null && data.item_name.ToString().ToLower().Contains(FilterString_Requisition.ToLower())) ||
                           (data.sku_desc != null && data.sku_desc.ToString().ToLower().Contains(FilterString_Requisition.ToLower())) ||
                           (data.plan_date != null && data.plan_date.ToString().ToLower().Contains(FilterString_Requisition.ToLower())) ||
                           (data.note != null && data.note.ToString().ToLower().Contains(FilterString_Requisition.ToLower())) ||
                           (data.po_code != null && data.po_code.ToString().ToLower().Contains(FilterString_Requisition.ToLower())) ||
                           (data.pg_code != null && data.pg_code.ToString().ToLower().Contains(FilterString_Requisition.ToLower())) ||
                           (data.location_id != null && data.location_id.ToString().ToLower().Contains(FilterString_Requisition.ToLower())) ||
                           (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(FilterString_Requisition.ToLower())) ||
                           data.emp_name != null && data.emp_name.ToString().ToLower().Contains(FilterString_Requisition.ToLower()));

                }
                return true;
            }
            return false;
        }

        // filter string Requisition No

        private string _FilterString_Items;
        public string FilterString_Items
        {
            get { return _FilterString_Items; }
            set
            {
                _FilterString_Items = value;
                RaisePropertyChanged("FilterString_Items");
                FilterCollection_Items();
            }
        }
        private void FilterCollection_Items()
        {
            if (_ItemsCollection != null)
            {
                _ItemsCollection.Refresh();
            }
        }
        public bool FilterReferenceItems(object obj)
        {
            var data = obj as PUR_T002_P_PR_ItemsList;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_Items))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_FilterString_Items.ToLower()) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_FilterString_Items.ToLower())) ||
                           data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_FilterString_Items.ToLower()));


                }
                return true;
            }
            return false;
        }

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
        //Filter Make
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

        private void FilterReferenceDocumentNumbers(object InputValue)
        {


        }
        #endregion
        #region DataGrid Functions - Items DataGrid
        private void InsertDataGridRow_Item(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                PUR_T002_P_PR_ItemsList POPUPEntityObject = null;
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
                        {
                            POPUPEntityObject = MC.ItemListForPopup.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.ItemName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PUR_T002_P_PR_ItemsList>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = dgItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = dgItemsEntity.IndexOf(dgItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.
                    var LineId = dgItemsEntity.Count + 1;
                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && dgItemsEntity.Count == dgSelectedIndexItem)
                    {
                        dgItemsEntity.Add(new PUR_T002_B()
                        {
                            id = 0,
                            ItemCode = POPUPEntityObject.ItemCode,
                            description = POPUPEntityObject.ItemName,
                            active = true,
                            line_id = LineId,
                            location_Id = AppSessionState.OBJ_LOCATION.location_id,
                            PartyId = MasterEntity.PartyId,
                            pur_req_no = POPUPEntityObject.Req_NO,
                            pur_req_item = POPUPEntityObject.Pur_Req_Item_id,
                            user_source2 = "Local",
                            bid_inv_no = "New",
                            qty = POPUPEntityObject.Req_QTY,
                            quotation_no = MasterEntity.quotation_no,
                            ref_doc_no = MasterEntity.ref_doc_no,
                            ref_doc_type = MasterEntity.ref_doc_type,
                            sku = POPUPEntityObject.sku,
                            sku_desc = POPUPEntityObject.sku_desc,
                            //tax_id = Convert.ToString(TaxId),
                            tax_id = String.IsNullOrEmpty(POPUPEntityObject.tax_id) ? MasterEntity.form_type.ToString() : POPUPEntityObject.tax_id,
                            unit_code = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM,
                            unit_price = POPUPEntityObject.b_rate,
                            comp_code = AppSessionState.OBJ_COMPANY.comp_code,
                            item_cat = POPUPEntityObject.item_cat,
                            remark = POPUPEntityObject.note,
                            req_no = POPUPEntityObject.Req_NO,
                            //ship_to_Party = MasterEntity.ship_to_party,
                            //ship_to_add = MasterEntity.del_address,
                            buss_place = MasterEntity.buss_place,
                            t_status = MasterEntity.t_status,
                            t_display = MasterEntity.t_display
                        });
                    }
                    else if (dgSelectedIndexItem >= 0 && dgItemsEntity.Count > dgSelectedIndexItem && ItemEntityObject != null) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemEntityObject.id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            ItemEntityObject.ItemCode = POPUPEntityObject.ItemCode;
                            ItemEntityObject.description = POPUPEntityObject.ItemName;
                            ItemEntityObject.active = true;
                            //ItemEntityObject.line_id = 0;
                            ItemEntityObject.pur_req_no = POPUPEntityObject.Req_NO;
                            ItemEntityObject.PartyId = MasterEntity.PartyId;
                            ItemEntityObject.user_source2 = "Local";
                            ItemEntityObject.bid_inv_no = "New";
                            ItemEntityObject.qty = POPUPEntityObject.Req_QTY;
                            ItemEntityObject.quotation_no = MasterEntity.quotation_no;
                            ItemEntityObject.ref_doc_no = MasterEntity.ref_doc_no;
                            ItemEntityObject.ref_doc_type = MasterEntity.ref_doc_type;
                            ItemEntityObject.sku = POPUPEntityObject.sku;
                            ItemEntityObject.sku_desc = POPUPEntityObject.sku_desc;
                            //ItemEntityObject.tax_id = Convert.ToString(TaxId);
                            ItemEntityObject.tax_id = String.IsNullOrEmpty(POPUPEntityObject.tax_id) ? MasterEntity.form_type.ToString() : POPUPEntityObject.tax_id;
                            ItemEntityObject.unit_code = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM;
                            ItemEntityObject.unit_price = POPUPEntityObject.b_rate;
                            ItemEntityObject.item_cat = POPUPEntityObject.item_cat;
                            ItemEntityObject.remark = POPUPEntityObject.note;
                            ItemEntityObject.req_no = POPUPEntityObject.Req_NO;
                            //ItemEntityObject.ship_to_Party = MasterEntity.ship_to_party;
                            //ItemEntityObject.ship_to_add = MasterEntity.del_address;
                            ItemEntityObject.buss_place = MasterEntity.buss_place;
                            ItemEntityObject.t_status = MasterEntity.t_status;
                            ItemEntityObject.t_display = MasterEntity.t_display;

                        }
                        else if (ItemEntityObject.ItemCode != POPUPEntityObject.ItemCode)
                        {
                            ItemEntityObject.ItemCode = "";
                            ItemEntityObject.description = "";
                        }
                    }
                    int count = dgItemsEntity.Count();
                    TotalDocumentTaxes.Clear();
                    for (int i = 0; i < count; i++)
                    {
                        Computation(true, i, AutoRoundupEnable);
                    }
                }
                #region Clear Empty Row
                PUR_T002_B newObj = new PUR_T002_B();
                for (int i = dgItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = dgItemsEntity[i].ComparePropertiesTo(newObj);
                    if (dgItemsEntity[i].ComparePropertiesTo(newObj) == true && dgItemsEntity.Count > 1)
                    {
                        dgItemsEntity.RemoveAt(i);
                        if (dgItemsEntity.Count == 0)
                        {
                            dgItemsEntity.Add(newObj);
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
        private void InsertComponant(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                STD_ITEM POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.ItemListForComponant.Where(x => x.item_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.item_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
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
                    var InputValueIfExists = dgComponantEntity.Where(X => X.item_code == POPUPEntityObject.item_code && (X.sku ?? "") == (POPUPEntityObject.sku ?? "") && X.ref_item_line_id == ItemEntityObject.line_id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = dgComponantEntity.IndexOf(dgComponantEntity.Where(X => X.item_code == POPUPEntityObject.item_code && (X.sku ?? "") == (POPUPEntityObject.sku ?? "") && X.ref_item_line_id == ItemEntityObject.line_id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.
                    var LineId = dgItemsEntity.Count + 1;
                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && dgComponantEntity.Count == dgSelectedIndexComponant)
                    {
                        dgComponantEntity.Add(new PUR_T002_C()
                        {
                            id = 0,
                            line_id = LineId,
                            ref_item_line_id = ItemEntityObject.line_id,
                            po_no = MasterEntity.po_no,
                            po_item_row_id = ItemEntityObject.id,
                            sch_row_id = SelectedItemScheduleEntity == null ? 0 : SelectedItemScheduleEntity.id,
                            active = true,
                            t_status = MasterEntity.t_status,
                            client = AppSessionState.client,
                            comp_code = MasterEntity.comp_code,
                            location_id = MasterEntity.location_Id,
                            item_code = POPUPEntityObject.item_code,
                            item_name = POPUPEntityObject.item_name,
                            sku = POPUPEntityObject.sku,
                            sku_desc = POPUPEntityObject.sku_desc,
                            store_code = ItemEntityObject.store_code,
                            batch_no = ItemEntityObject.batch_no,
                            qty = 0,
                            unit_code = String.IsNullOrEmpty(ItemEntityObject.unit_code) ? POPUPEntityObject.unit_code : ItemEntityObject.unit_code,
                            //reserv_no=,
                            //reserv_item_row_id
                            //record_type
                            //requirement_type
                            bom_no = ItemEntityObject.bom_no,
                            //bom_item_row_id = ItemEntityObject.bo
                            //routing_no
                            // op_seq
                            //operation_no
                            //plan_counter
                            //object_no
                            op_scrap = 0,
                            comp_scrap = 0,
                            order_no = MasterEntity.po_no,
                            order_item_row_id = ItemEntityObject.id,
                            t_display = MasterEntity.t_display
                        });
                    }
                    else if (SelectedItemComponantEntity != null)
                    {
                        if (SelectedItemComponantEntity.line_id == 0)
                        {
                            SelectedItemComponantEntity.line_id = dgComponantEntity.Count;
                        }
                        SelectedItemComponantEntity.id = 0;
                        SelectedItemComponantEntity.ref_item_line_id = ItemEntityObject.line_id;
                        SelectedItemComponantEntity.po_no = MasterEntity.po_no;
                        SelectedItemComponantEntity.po_item_row_id = ItemEntityObject.id;
                        SelectedItemComponantEntity.sch_row_id = SelectedItemScheduleEntity == null ? 0 : SelectedItemScheduleEntity.id;
                        SelectedItemComponantEntity.active = true;
                        SelectedItemComponantEntity.t_status = MasterEntity.t_status;
                        SelectedItemComponantEntity.client = AppSessionState.client;
                        SelectedItemComponantEntity.comp_code = MasterEntity.comp_code;
                        SelectedItemComponantEntity.location_id = MasterEntity.location_Id;
                        SelectedItemComponantEntity.item_code = POPUPEntityObject.item_code;
                        SelectedItemComponantEntity.item_name = POPUPEntityObject.item_name;
                        SelectedItemComponantEntity.sku = POPUPEntityObject.sku;
                        SelectedItemComponantEntity.sku_desc = POPUPEntityObject.sku_desc;
                        SelectedItemComponantEntity.store_code = ItemEntityObject.store_code;
                        SelectedItemComponantEntity.batch_no = ItemEntityObject.batch_no;
                        SelectedItemComponantEntity.qty = 0;
                        SelectedItemComponantEntity.unit_code = String.IsNullOrEmpty(ItemEntityObject.unit_code) ? POPUPEntityObject.unit_code : ItemEntityObject.unit_code;
                        //SelectedItemComponantEntity.reserv_no=;
                        //SelectedItemComponantEntity.reserv_item_row_id;
                        //SelectedItemComponantEntity.record_type;
                        //SelectedItemComponantEntity.requirement_type;
                        SelectedItemComponantEntity.bom_no = ItemEntityObject.bom_no;
                        //SelectedItemComponantEntity.bom_item_row_id = ItemEntityObject.bo;
                        //SelectedItemComponantEntity.routing_no;
                        //SelectedItemComponantEntity.op_seq;
                        //SelectedItemComponantEntity.operation_no;
                        //SelectedItemComponantEntity.plan_counter;
                        //SelectedItemComponantEntity.object_no;
                        SelectedItemComponantEntity.op_scrap = 0;
                        SelectedItemComponantEntity.comp_scrap = 0;
                        SelectedItemComponantEntity.order_no = MasterEntity.po_no;
                        SelectedItemComponantEntity.order_item_row_id = ItemEntityObject.id;
                        SelectedItemComponantEntity.t_display = MasterEntity.t_display;
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
       
        private void InsertDataGridRow_UOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                //AppSessionState.StringListValue = StringListUOM;
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
                        { POPUPEntityObject = MC.unitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null && ItemEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = dgItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = dgItemsEntity.IndexOf(dgItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && dgItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemEntityObject.id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            PreviousUnitCode = ItemEntityObject.unit_code;
                            ItemEntityObject.unit_code = POPUPEntityObject.unit_code;
                            NewUnitCode = ItemEntityObject.unit_code;
                        }
                        else if (ItemEntityObject.unit_code != POPUPEntityObject.unit_code)
                        {
                            PreviousUnitCode = ItemEntityObject.unit_code;
                            ItemEntityObject.unit_code = "";
                            PreviousUnitCode = ItemEntityObject.unit_code;
                        }
                    }
                    unitconversion();
                }
                #region Clear Empty Row
                PUR_T002_B newObj = new PUR_T002_B();
                for (int i = dgItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = dgItemsEntity[i].ComparePropertiesTo(newObj);
                    if (dgItemsEntity[i].ComparePropertiesTo(newObj) == true && dgItemsEntity.Count > 1)
                    {
                        dgItemsEntity.RemoveAt(i);
                        if (dgItemsEntity.Count == 0)
                        {
                            dgItemsEntity.Add(newObj);
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
        private void unitconversion()
        {
            try
            {
                var CurrantUnitCF = (from o in UnitConversionList where (o.unit_code == PreviousUnitCode) select o).ToList();
                var NewUnitCF = (from o in UnitConversionList where (o.unit_code == NewUnitCode) select o).ToList();
                if (CurrantUnitCF.Count > 0 && NewUnitCF.Count > 0 && ItemEntityObject != null)
                {
                    ItemEntityObject.qty = (ItemEntityObject.qty * CurrantUnitCF[0].c_factor) / NewUnitCF[0].c_factor;
                    ItemEntityObject.unit_price = (ItemEntityObject.unit_price / CurrantUnitCF[0].c_factor) * NewUnitCF[0].c_factor;
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
        private void DeleteDataGridRow_ItemLicence(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (LicenceDetailsEntity.Count > i)
                {
                    LicenceDetailsEntity.RemoveAt(i);
                    Computation(true, dgSelectedIndexItemLicence, AutoRoundupEnable);
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
                if (dgItemsEntity.Count > i && ItemEntityObject.id == 0)
                {
                    dgItemsEntity.RemoveAt(i);
                    int count = dgItemsEntity.Count();
                    for (int x = 0; x < count; x++)
                    {
                        SubTotalCalculation(x);
                        Computation(true, x, AutoRoundupEnable);
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
        //private void DeleteTax(object InputValue) sunil
        //{
        //    int i = (int)InputValue;
        //    if (TotalDocumentTaxesSummury.Count > i)
        //    {
        //        TotalDocumentTaxes.Remove(TotalDocumentTaxes.Where(x => x.tax_name == TotalDocumentTaxesSummury[i].tax_name).Single());
        //        TotalDocumentTaxesSummury.RemoveAt(i);
        //        TaxComputation(true);
        //    }
        //}
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
                    Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
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
                if (dgItemScheduleEntity.Count > i)
                {
                    dgItemScheduleEntity.RemoveAt(i);
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
            Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
        }
        private void InsertDataGridRow_ItemCategory(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {


                string Request = "";
                SYS_M008_P POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.itemcatList.Where(x => x.item_cat.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SYS_M008_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M008_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null && ItemEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    ItemEntityObject.item_cat = POPUPEntityObject.item_cat;
                    ItemEntityObject.rel_billing = POPUPEntityObject.rel_billing;
                    ItemEntityObject.rel_delivery = POPUPEntityObject.rel_delivery;
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
        // FilterScheduleDataGrid : Filter for Schedule Items as per selected item in dgItemsEntity. This filter is work for ObserverableCollection.
        private void FilterScheduleDataGrid()
        {
            try
            {
                if (dgItemScheduleEntity != null && dgItemScheduleEntity.Count > 0 && ItemEntityObject != null)
                {

                    if (ItemEntityObject.ItemCode != null)
                    {
                        DataGridViewFilter = CollectionViewSource.GetDefaultView(dgItemScheduleEntity);
                        DataGridViewFilter.Filter = adv => ((PUR_T004_B)adv).ItemCode.Equals(ItemEntityObject.ItemCode) && (((PUR_T004_B)adv).sku ?? "").Equals(ItemEntityObject.sku ?? "") && (((PUR_T004_B)adv).item_line_id).Equals(ItemEntityObject.line_id);
                        DataGridViewFilter.Refresh();
                    }

                }
                else
                {
                    DataGridViewFilter = CollectionViewSource.GetDefaultView(dgItemScheduleEntity);
                    DataGridViewFilter.Filter = adv => ((PUR_T004_B)adv).ItemCode.Equals("") && (((PUR_T004_B)adv).sku ?? "").Equals("");
                    DataGridViewFilter.Refresh();
                }
            }
            catch (Exception ex)
            { }
        }
        private void FilterTaxDataGrid()
        {
            //try
            //{
            //    if (TotalDocumentTaxes != null && TotalDocumentTaxes.Count > 0 && dgSelectedIndexTaxSummury < TotalDocumentTaxes.Count && dgSelectedIndexTaxSummury >= 0)
            //    {
            //        if (TotalDocumentTaxes[dgSelectedIndexTaxSummury].tax_name != null)
            //        {
            //            ICollectionViewTax = CollectionViewSource.GetDefaultView(TotalDocumentTaxes);
            //            ICollectionViewTax.Filter = adv => ((ACC_T006_B)adv).tax_name.Equals(TotalDocumentTaxes[dgSelectedIndexTaxSummury].tax_name);
            //            ICollectionViewTax.Refresh();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{ }
        }
        private void FilterComponantDataGrid()
        {
            try
            {
                if (dgComponantEntity != null && dgComponantEntity.Count > 0 && ItemEntityObject != null)
                {
                    if (ItemEntityObject.ItemCode != null)
                    {
                        DataGridViewFilter = CollectionViewSource.GetDefaultView(dgComponantEntity);
                        DataGridViewFilter.Filter = adv => ((PUR_T002_C)adv).po_item_row_id.Equals(ItemEntityObject.id) && (((PUR_T002_C)adv).ref_item_line_id).Equals(ItemEntityObject.line_id);
                        DataGridViewFilter.Refresh();
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion
    }
}
