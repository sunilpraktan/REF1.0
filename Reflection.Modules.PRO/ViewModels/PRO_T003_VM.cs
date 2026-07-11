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
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.PRO.ViewModels
{
    public class PRO_T003_VM : WorkspaceViewModel<PUR_T002_A>
    {
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PRO_T003_VM));
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
        private AutoSuggestTextViewModel<dynamic> _ASFormType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFormType
        {
            get { return _ASFormType; }
            set
            {
                if (_ASFormType != value)
                {
                    _ASFormType = value; RaisePropertyChanged("ASFormType");
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
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        bool NewRecord = true;
        string Currency;
        string PartyEmailId = "";
        string PersonEmailId = "";
        string PreviousUnitCode = "";
        string NewUnitCode = "";
        public string ref_doc_cat { get; set; }
        NUMBER_TO_WORDS_CONVERTER NOW_OBJ = new NUMBER_TO_WORDS_CONVERTER();
        WebServiceRepository<PUR_T002_A> repository = new WebServiceRepository<PUR_T002_A>();
        WebServiceRepository<MultipleContext_PUR_T002_A> repository_MC = new WebServiceRepository<MultipleContext_PUR_T002_A>();
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

                    RaisePropertyChanged("MC");
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


        public List<PUR_T002_P_PR_ItemsList> _ItemListForPopup;
        public List<PUR_T002_P_PR_ItemsList> ItemListForPopup
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

        private ObservableCollection<PUR_T002_H> _TermsConditionEntity;
        public ObservableCollection<PUR_T002_H> TermsConditionEntity
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

        #region Temp Variables

        private ICollectionView _dataGridview;
        public ICollectionView DataGridView
        {
            get { return _dataGridview; }
            set { _dataGridview = value; RaisePropertyChanged("DataGridView"); }
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
                    if (TotalDocumentTaxesItem.Count > 0)
                    {
                        TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>(TotalDocumentTaxes.Where(tax => tax.ItemCode == dgItemsEntity[dgSelectedIndexItem].ItemCode && tax.sku == dgItemsEntity[dgSelectedIndexItem].sku && tax.item_line_id == dgItemsEntity[dgSelectedIndexItem].id));
                    }
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
                }
            }
        }
        private int _dgSelectedIndexSchedule;
        public int dgSelectedIndexSchedule
        {
            get
            {
                return _dgSelectedIndexSchedule;
            }
            set
            {
                if (_dgSelectedIndexSchedule != value)
                {

                    _dgSelectedIndexSchedule = value;
                    RaisePropertyChanged("dgSelectedIndexSchedule");
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


                    RaisePropertyChanged("SelectedChildTaxList");

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
        #region ICollection
        private ICollectionView _ReferenceDocRQCollection;
        public ICollectionView ReferenceDocRQCollection
        {
            get { return _ReferenceDocRQCollection; }
            set { _ReferenceDocRQCollection = value; RaisePropertyChanged("ReferenceDocRQCollection"); }
        }
        private ICollectionView _ReferenceDocINCollection;
        public ICollectionView ReferenceDocINCollection
        {
            get { return _ReferenceDocINCollection; }
            set { _ReferenceDocINCollection = value; RaisePropertyChanged("ReferenceDocINCollection"); }
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


        private ICollectionView _TermsConditionCollection;
        public ICollectionView TermsConditionCollection
        {
            get { return _TermsConditionCollection; }
            set { _TermsConditionCollection = value; RaisePropertyChanged("TermsConditionCollection"); }
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

        // Pending assignment of ItemCollection
        private ICollectionView _itemCollection;
        public ICollectionView ItemCollection
        {
            get { return _itemCollection; }
            set { _itemCollection = value; RaisePropertyChanged("ItemCollection"); }
        }


        #endregion
        #region StringList Variables

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


        #endregion
        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdContactPerson { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CommandLoadDocumentFromSource { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByRefDocNumber { get; private set; }
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
        public RelayCommand<object> SelectionChangedCommandCostCenter { get; private set; }
        public RelayCommand<object> SelectionChangedReferenceDocumentType { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }

        //DataGrid Record addtion commands 
        public RelayCommand<object> CommandAddItem { get; private set; }
        public RelayCommand<object> CommandAddUOM { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CommandAddItemCategory { get; private set; }
        public RelayCommand<object> CommandDeleteScheduleItem { get; private set; }
        public RelayCommand<object> CommandAddSelectedTax { get; private set; }
        public RelayCommand<object> cmdDeleteTax { get; private set; }
        public RelayCommand<object> ManualTaxChangedCommand { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridTerms { get; private set; }
        public RelayCommand<object> CommandTerms { get; private set; }
        public RelayCommand<object> CmdAddSelectedRef { get; private set; }
        public RelayCommand<object> CmdInsert_t_status { get; private set; }
        #endregion
        #region Constructor
        //private static PUR_T002_VM Expose_ViewModel;
        //public static PUR_T002_VM SharedViewModel()
        //{
        //    return Expose_ViewModel ?? (Expose_ViewModel = new PUR_T002_VM(null, null));
        //}
        public PRO_T003_VM(string ts_code)
            : base()
        {
            CursorControl.SetBusyState();
            this.ts_code_vm = ts_code;
            MasterEntityTemp = new PUR_T002_A(); // pending assignment
            MasterEntity = new PUR_T002_A();
            ItemListForPopup = new List<PUR_T002_P_PR_ItemsList>();
            dgItemsEntity = new ObservableCollection<PUR_T002_B>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
            dgTotalTaxSummury = new ObservableCollection<PUR_T002_C>();
            TermsConditionEntity = new ObservableCollection<PUR_T002_H>();
            ScheduleEntity = new PUR_T004_A();
            dgItemScheduleEntity = new ObservableCollection<PUR_T004_B>();
            FlipGridData = new List<PUR_T002_AFlip>();
            MC = new MultipleContext_PUR_T002_A();
            MCTemp = new MultipleContext_PUR_T002_A();
            MasterEntity.ValidateAsync().Wait();
            PUR_T002_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            PUR_T002_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            PUR_T004_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Schedule);
            dgItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            dgItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            LoadInitialData();
        }
        public PRO_T003_VM(string ts_code, string doc_no)
            : base()
        {
            CursorControl.SetBusyState();
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntityTemp = new PUR_T002_A(); // pending assignment
            MasterEntity = new PUR_T002_A();
            ItemListForPopup = new List<PUR_T002_P_PR_ItemsList>();
            dgItemsEntity = new ObservableCollection<PUR_T002_B>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
            dgTotalTaxSummury = new ObservableCollection<PUR_T002_C>();
            TermsConditionEntity = new ObservableCollection<PUR_T002_H>();
            ScheduleEntity = new PUR_T004_A();
            dgItemScheduleEntity = new ObservableCollection<PUR_T004_B>();
            FlipGridData = new List<PUR_T002_AFlip>();
            MC = new MultipleContext_PUR_T002_A();
            MCTemp = new MultipleContext_PUR_T002_A();
            MasterEntity.ValidateAsync().Wait();
            PUR_T002_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            PUR_T002_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            PUR_T004_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Schedule);
            dgItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            dgItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            LoadInitialData();
        }
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                MasterEntity.doc_cat = "QP";
                MasterEntity.doc_type = "QP";
                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.po_code + "!@" + AppSessionState.pg_code + "!@" + AppSessionState.EmpId;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MC, Request, "PRO_T002_BL", "PRO", "LoadAll", 0, "");
                #region Command Initialisation
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CommandLoadDocumentFromSource = new GalaSoft.MvvmLight.Command.RelayCommand(() => LoadSourceDocument());
                CommandActiveInactiveCheck = new RelayCommand<bool>(CheckActiveStatus);
                // Pending Task for Commands : change name of existing commands Name to start with Command.
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
                SelectionChangedCommandCostCenter = new RelayCommand<object>(items => { if (items == null) { return; } InsertCostCenter(items); });
                SelectionChangedReferenceDocumentType = new RelayCommand<object>(items => { if (items == null) { return; } FilterReferenceDocumentNumbers(items); }); // Pending Assignment
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CommandLoadDocumentByRefDocNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByReferenceDocumentNumber(cmdPara, "FlipGridReference"); });
                CommandAddItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_Item(cmdPara, true, true, true); });
                CommandAddItemCategory = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_ItemCategory(cmdPara, false, true, true); });
                CommandAddUOM = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDataGridRow_UOM(cmdPara, false, true, true); });
                CommandDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
                CommandDeleteScheduleItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_ItemSchedule(cmdPara); });
                cmdDeleteTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteTax(cmdPara); });
                CommandAddSelectedTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSelectedTax(cmdPara); });
                ManualTaxChangedCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertManualTaxChangedCommand(cmdPara); });
                CommandTerms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTerms(cmdPara, true, true, true); });
                CommandDeleteDataGridTerms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Terms(cmdPara); });
                cmdContactPerson = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertContactPerson(cmdPara); });
                CmdAddSelectedRef = new RelayCommand<object>(items => { if (items == null) { return; } AddSelectedRef(items); });
                CmdInsert_t_status = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_t_status(cmdPara); });
                #endregion
                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                #region Autosuggest

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyNm);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
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

                //New PopUP - Reference Document No
                var refdoctempaNew = (from o in MC.reference_docList where o.doc_cat == "QP" || o.doc_cat == "IN" || o.doc_cat == "RQ" select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T002_P_RefeDoc)x).po_no);
                TheFilter = (o, prefix) => (((PUR_T002_P_RefeDoc)o).po_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                // || ((PUR_T002_P_RefeDoc)o).party_name?? "").ToString().ToLower().Contains(prefix) ||
                //((PUR_T002_P_RefeDoc)o).supplier_ref.ToString().ToLower().Contains(prefix);
                ASRefDocNo = new AutoSuggestTextViewModel<dynamic>(refdoctempaNew, TheFilter, SuggestedValue, "po_no", true);
                ASRefDocNo.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASRefDocNo.AutoSuggestVM.IsFreeTextAllowed = true;

                //New Reference Popup Loading
                var refdoc = (from o in MC.reference_docList where o.doc_cat == "RQ" select o).ToList();
                ReferenceDocRQCollection = CollectionViewSource.GetDefaultView(refdoc);
                ReferenceDocRQCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                refdoc = (from o in MC.reference_docList where o.doc_cat == "IN" select o).ToList();
                ReferenceDocINCollection = CollectionViewSource.GetDefaultView(refdoc);
                ReferenceDocINCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);


                //New PopUP - OrderType
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M007)x).doc_type_user);
                TheFilter = (o, prefix) => (((SYS_M007)o).doc_type_user ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((SYS_M007)o).doc_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASOrderType = new AutoSuggestTextViewModel<dynamic>(MC.doc_typeList, TheFilter, SuggestedValue, "doc_type_user", true);
                ASOrderType.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - ValidatedBy
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M024_P)o).EmpLName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASValidatedBy = new AutoSuggestTextViewModel<dynamic>(MC.BuyerList, TheFilter, SuggestedValue, "EmpId", false);
                ASValidatedBy.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Supplier
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyNm);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSupplier = new AutoSuggestTextViewModel<dynamic>(MC.partyList, TheFilter, SuggestedValue, "party_name", true);
                ASSupplier.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASSupplier.AutoSuggestVM.IsFreeTextAllowed = false;

                //New PopUP - Buyer
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M024_P)o).EmpLName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASBuyer = new AutoSuggestTextViewModel<dynamic>(MC.BuyerList, TheFilter, SuggestedValue, "EmpId", false);
                ASBuyer.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Delivery Address
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_P)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003_P)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M003_P)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDelAddress = new AutoSuggestTextViewModel<dynamic>(MC.deladdrList, TheFilter, SuggestedValue, "location_Id", true);

                //New PopUP - Billing Address
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_P)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003_P)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M003_P)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASBillAddress = new AutoSuggestTextViewModel<dynamic>(MC.deladdrList, TheFilter, SuggestedValue, "location_Id", true);
                ASBillAddress.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Currency
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037_P)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M037_P)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCurrency = new AutoSuggestTextViewModel<dynamic>(MC.currencyList, TheFilter, SuggestedValue, "curr_code", true);
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

                //New PopUP - Requisition No
                var SalesPurchaseDocNew = (from o in MC.reference_docList where o.doc_cat == "RQ" select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T002_P_RefeDoc)x).po_no);
                TheFilter = (o, prefix) => (((PUR_T002_P_RefeDoc)o).po_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASReqNo = new AutoSuggestTextViewModel<dynamic>(SalesPurchaseDocNew, TheFilter, SuggestedValue, "po_no", "po_no", true);
                ASReqNo.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASReqNo.AutoSuggestVM.IsFreeTextAllowed = false;

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

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M013_P)x).description);
                TheFilter = (o, prefix) => (((ACC_M013_P)o).description ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASFormType = new AutoSuggestTextViewModel<dynamic>(MC.FormType, TheFilter, SuggestedValue, "FormDescription", true);
                ASFormType.AutoSuggestVM.IsEmptyValueAllowed = true;

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

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037_P)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M037_P)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASdgCurrency = new AutoSuggestTextViewModel<dynamic>(MC.currencyList, TheFilter, SuggestedValue, "curr_code", "curr_code", true);
                ASdgCurrency.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M008_P)x).con_type);
                TheFilter = (o, prefix) => (((MM_M008_P)o).con_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((MM_M008_P)o).long_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault2 = new AutoSuggestTextViewModel<dynamic>(MC.TermsConditionCollection, TheFilter, SuggestedValue, "con_type", "con_type", true);
                ASDefault2.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault2.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M008_P)x).con_type);
                TheFilter = (o, prefix) => (((MM_M008_P)o).con_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((MM_M008_P)o).long_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTermsCond = new AutoSuggestTextViewModel<dynamic>(MC.TermsConditionCollection, TheFilter, SuggestedValue, "con_type", "con_type", true);
                ASTermsCond.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASt_status = new AutoSuggestTextViewModel<dynamic>(MC.t_statusList, TheFilter, SuggestedValue, "t_display", true);
                ASt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion

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

                doc_typeCollection = CollectionViewSource.GetDefaultView(MC.doc_typeList);
                doc_typeCollection.Filter = new Predicate<object>(doctype_Filter);
                StringListDocumentTypes = MC.doc_typeList.Select(x => x.doc_type).ToList();

                currencyCollection = CollectionViewSource.GetDefaultView(MC.currencyList);
                currencyCollection.Filter = new Predicate<object>(currency_Filter);
                StringListCurrency = MC.currencyList.Select(x => x.curr_code).ToList();

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

                cost_centerCollection = CollectionViewSource.GetDefaultView(MC.cost_centerList);
                cost_centerCollection.Filter = new Predicate<object>(cost_center_Filter);
                StringListCostCenter = MC.cost_centerList.Select(x => x.cost_center).ToList();

                BilAdderCollection = CollectionViewSource.GetDefaultView(MC.billaddrList.ToList());
                BilAdderCollection.Filter = new Predicate<object>(Filterbilladdr);

                DelAddrCollection = CollectionViewSource.GetDefaultView(MC.deladdrList.ToList());
                DelAddrCollection.Filter = new Predicate<object>(Filterdeladdr);
                StringListDeliveryAddress = MC.deladdrList.Select(x => x.location_Id).ToList();

                TermsConditionCollection = CollectionViewSource.GetDefaultView(MC.TermsConditionCollection);
                TermsConditionCollection.Filter = new Predicate<object>(Filter_Terms);
                StringListTerms = MC.TermsConditionCollection.Select(x => x.con_type).ToList();

                itemcategoryCollection = CollectionViewSource.GetDefaultView(MC.itemcatList);
                itemcategoryCollection.Filter = new Predicate<object>(Filteritemcategory);
                StringListItemCategory = MC.itemcatList.Select(x => x.item_cat).ToList();

                dgPOItemsFortaxval = CollectionViewSource.GetDefaultView(MC.AccountList);
                dgPOItemsFortaxval.Filter = new Predicate<object>(FiltertaxAcc);
                StringListTaxAcc = MC.AccountList.Select(x => x.acc_code).ToList();

                validatedByCollection = CollectionViewSource.GetDefaultView(MC.BuyerList.ToList());
                validatedByCollection.Filter = new Predicate<object>(Filtervalidator);

                TaxDictonery = new Dictionary<string, object>();
                TaxDictonery.Clear();
                TaxDictonery = MC.TaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);

                var TaxListParent = (from o in MC.TaxList
                                     where o.parent_id == null
                                     select o).ToList();
                SelectedTaxList = TaxListParent;
                TaxDictoneryParent = SelectedTaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);




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
        #endregion
        #region User Defined Functions
        private void DefaultValues()
        {
            MasterEntity.doc_cat = "QP";
            MasterEntity.doc_type = "QP";
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.del_address_id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.bill_address_id = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.active = true;
            MasterEntity.rel_sts = "004";
            MasterEntity.t_status = "001";
            var tempt_display = (from o in MC.t_statusList
                                 where o.t_status == MasterEntity.t_status
                                 select o).ToList();
            MasterEntity.t_display = tempt_display[0].t_display;
            MasterEntity.po_no = "";
            MasterEntity.po_date = DateTime.Now;
            MasterEntity.shipped = false;
            MasterEntity.version = "v1.0";
            ScheduleEntity.t_status = MasterEntity.t_status;
            ScheduleEntity.t_display = MasterEntity.t_display;
            ScheduleEntity.sch_date = DateTime.Now;
            ScheduleEntity.active = true;
            ScheduleEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            ScheduleEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            ScheduleEntity.id = 0;
            ScheduleEntity.PartyId = MasterEntity.PartyId;
            Currency = AppSessionState.CntryCurncy;
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
        private void Computation(bool Compute, int ItemRowIndex)
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

                    decimal? gross_value_A = 0;
                    decimal? effective_value_A = 0;
                    decimal? discount_amt_A = 0;
                    decimal? tax_amount_A = 0;
                    decimal? net_value_A = 0;


                    if (dgItemsEntity != null && dgItemsEntity.Count > 0 && ItemRowIndex >= 0 && ItemRowIndex < dgItemsEntity.Count) //Condition satisfy only if Items collection is not empty.
                    {
                        if (dgItemsEntity[ItemRowIndex].qty >= 0 && dgItemsEntity[ItemRowIndex].unit_price >= 0 && dgItemsEntity[ItemRowIndex].active != false) // Must not null or empty.
                        {
                            if (dgItemsEntity[ItemRowIndex].discount == null)
                            {
                                dgItemsEntity[ItemRowIndex].discount = 0;
                            }
                            dgItemsEntity[ItemRowIndex].sub_total = (dgItemsEntity[ItemRowIndex].qty * dgItemsEntity[ItemRowIndex].unit_price) - ((dgItemsEntity[ItemRowIndex].qty * dgItemsEntity[ItemRowIndex].unit_price) * (dgItemsEntity[ItemRowIndex].discount / 100));
                            dgItemsEntity[ItemRowIndex].local_sub_total = (dgItemsEntity[ItemRowIndex].sub_total * MasterEntity.ex_rate);

                            discount_amt_A = ((dgItemsEntity[ItemRowIndex].qty * dgItemsEntity[ItemRowIndex].unit_price) - dgItemsEntity[ItemRowIndex].sub_total);
                            dgItemsEntity[ItemRowIndex].discount_amt = discount_amt_A;
                            dgItemsEntity[ItemRowIndex].local_discount = (discount_amt_A * MasterEntity.ex_rate);

                            gross_value_A = (dgItemsEntity[ItemRowIndex].qty * dgItemsEntity[ItemRowIndex].unit_price);
                            dgItemsEntity[ItemRowIndex].gross_value = gross_value_A;

                            // Code For Effective Value
                            effective_value_A = (dgItemsEntity[ItemRowIndex].qty * dgItemsEntity[ItemRowIndex].unit_price);
                            dgItemsEntity[ItemRowIndex].effective_value = effective_value_A;

                            // Code For Net Value
                            dgItemsEntity[ItemRowIndex].net_value = (dgItemsEntity[ItemRowIndex].qty * dgItemsEntity[ItemRowIndex].unit_price) - ((dgItemsEntity[ItemRowIndex].qty * dgItemsEntity[ItemRowIndex].unit_price) * (dgItemsEntity[ItemRowIndex].discount / 100));
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
                                    tax_amount_A = 0;
                                    net_value_A = 0;

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
                                    Temptax_amount_A = Temptax_amount_A + TaxAmount;
                                    tax_amount_A = Temptax_amount_A;

                                    dgItemsEntity[ItemRowIndex].tax_amount = tax_amount_A;
                                    net_value_A = gross_value_A - discount_amt_A + tax_amount_A;
                                    dgItemsEntity[ItemRowIndex].net_value = net_value_A;
                                    dgItemsEntity[ItemRowIndex].local_net_value = (net_value_A * MasterEntity.ex_rate);


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

                                    if (tax.tax_code_id == ChildTaxVar.id && tax.ItemCode == dgItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (dgItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == dgItemsEntity[ItemRowIndex].line_id && tax.item_row_id == dgItemsEntity[ItemRowIndex].id && tax.manual == "Auto")
                                    {
                                        TotalDocumentTaxes.Remove(tax);
                                    }
                                }
                                else if (tax.tax_code_id == ChildTaxVar.id && tax.ItemCode == dgItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (dgItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == dgItemsEntity[ItemRowIndex].line_id && tax.item_row_id == dgItemsEntity[ItemRowIndex].id && tax.manual == "Auto")
                                {
                                    TotalDocumentTaxes.Remove(tax);
                                }
                            }

                            #endregion

                            effective_value_A = net_value_A;
                            dgItemsEntity[ItemRowIndex].effective_value = effective_value_A;
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

                            //Code by kalpesh
                            //for (int i = 0; i < TotalDocumentTaxes.Count; i++)
                            //{
                            //    if (TotalDocumentTaxes[i].ItemCode == dgItemsEntity[ItemRowIndex].ItemCode && (TotalDocumentTaxes[i].sku?.ToString() ?? "") == (dgItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && TotalDocumentTaxes[i].item_line_id == dgItemsEntity[ItemRowIndex].line_id && TotalDocumentTaxes[i].item_row_id == dgItemsEntity[ItemRowIndex].id && TotalDocumentTaxes[i].manual == "Auto")
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
                        MasterEntity.amount_tax = TaxtTotal;
                        MasterEntity.tax_amount = TaxtTotal;

                        local_tax_amt = (TaxtTotal * MasterEntity.ex_rate);
                        MasterEntity.local_amount_tax = local_tax_amt;

                        //UnTaxTotal = dgItemsEntity.Sum(x => x.sub_total);
                        UnTaxTotal = dgItemsEntity.Where(item => item.active != false).Sum(item => item.sub_total);
                        MasterEntity.amount_untaxed = UnTaxTotal;


                        net_value = UnTaxTotal + TaxtTotal;
                        MasterEntity.net_value = net_value;
                        other_charges = TotalDocumentTaxes.Where(item => item.active != false && item.manual == "Manual").Sum(item => item.tax_amount);
                        MasterEntity.other_charges = other_charges;

                        local_net_value = (net_value * MasterEntity.ex_rate);
                        MasterEntity.local_net_value = local_net_value;

                        GrandTotal = net_value + other_charges;
                        MasterEntity.amount_total = GrandTotal;

                        local_total_amt = (GrandTotal * MasterEntity.ex_rate);
                        MasterEntity.local_amount_total = local_total_amt;

                        MasterEntity.roundup_total = decimal.Round((decimal)GrandTotal);
                        local_roundup_total = (MasterEntity.roundup_total * MasterEntity.ex_rate);
                        MasterEntity.local_roundup_total = local_roundup_total;

                        MasterEntity.round_up = MasterEntity.roundup_total - GrandTotal;
                        local_round_up = (MasterEntity.round_up * MasterEntity.ex_rate);
                        MasterEntity.local_round_up = local_round_up;

                        gross_value = dgItemsEntity.Where(item => item.active != false).Sum(item => item.qty * item.unit_price);
                        MasterEntity.gross_value = gross_value;

                        effective_value = GrandTotal;
                        MasterEntity.effective_value = effective_value;

                        disc_amt = gross_value - UnTaxTotal;
                        MasterEntity.disc_amt = disc_amt;


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
            // Validation for record modification depends on workflow and status
            foreach (var o in MC.doc_typeList)
            {

                if (o.doc_cat == MasterEntity.doc_cat && o.Workflow_id_temp != null)
                {
                    if (MasterEntity.t_status == "007" || MasterEntity.t_status == "002")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("You cannot edit record once it is Approved");
                        showMessageService.ShowMessage();
                        return false;
                    }
                }
            }

            // Validation for Quantity Item Duplication and Unit Code For Item Details
            foreach (var o in dgItemsEntity)
            {
                int flag = 0;
                if (o.id == 0)
                {
                    foreach (var p in dgItemsEntity)
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

                if (o.ItemCode != null && o.ItemCode != "" && o.description != null)
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
            }

            //Validation For Item Quantity Equal To Sum of Quantities of All Batches Of the Item 
            bool breakfor = false;
            for (int i = 0; i < dgItemsEntity.Count; i++)
            {
                decimal temp = 0;
                int flag = 0;

                for (int j = 0; j < dgItemScheduleEntity.Count; j++)
                {
                    if (dgItemsEntity[i].ItemCode == dgItemScheduleEntity[j].ItemCode && dgItemsEntity[i].sku == dgItemScheduleEntity[j].sku)
                    {
                        temp = temp + Convert.ToDecimal(dgItemScheduleEntity[j].qty);
                        flag = 1;
                    }
                }

                if (dgItemsEntity[i].qty != temp && flag == 1)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Item Quantity is Not Equal to Sum of All Item Batches Quantities for Item {0} Parameter :{1} ", dgItemsEntity[i].ItemCode, dgItemsEntity[i].sku_desc);
                    showMessageService.ShowMessage();
                    breakfor = false;
                    return false;
                }
            }
            if (MasterEntity.party_name == null || MasterEntity.party_name == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Field Supplier Is Required");
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
            if (MasterEntity.buyer == null || MasterEntity.buyer == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Field Buyer Is Required");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.copy == true)
            {
                NewRecord = true;
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



            return true;
        }
        #endregion
        #region Event Handler
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "qty" || e.PropertyName == "unit_price" || e.PropertyName == "tax_id" || e.PropertyName == "active" || e.PropertyName == "discount")
                {
                    Computation(true, dgSelectedIndexItem);
                }
                if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = false; /*dgItemsEntity[dgSelectedIndexItem].HasErrors;*/
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
        private void CollectionChangedNotifyForItem_(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (PUR_T002_B item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (PUR_T002_B item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (PUR_T002_B item in e.NewItems)
                    {
                        //Added items
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                    if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = false; /*dgItemsEntity[dgSelectedIndexItem].HasErrors;*/
                    }
                }

                if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                    this.ErrorExist = false; /*MasterEntity.HasErrors;*/
                    if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = false; /*dgItemsEntity[dgSelectedIndexItem].HasErrors;*/
                    }
                    this.ErrorExist = MasterEntity.HasErrors;
                    if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = dgItemsEntity[dgSelectedIndexItem].HasErrors;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    PUR_T002_B temp = (PUR_T002_B)e.OldItems[0];
                    foreach (var itemToRemove in dgItemScheduleEntity.Where(x => (x.ItemCode == temp.ItemCode && x.id == 0 && x.sku == temp.sku)).ToList())
                    {
                        dgItemScheduleEntity.Remove(itemToRemove);
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
                            }
                        }
                        Computation(true, dgSelectedIndexItem);
                    }


                    foreach (PUR_T002_B item in e.OldItems)
                    {
                        item.PropertyChanged -= EntityViewModelPropertyChanged;
                    }
                    if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = false; /*dgItemsEntity[dgSelectedIndexItem].HasErrors;*/
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
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (PUR_T002_B item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (PUR_T002_B item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (PUR_T002_B item in e.NewItems)
                    {
                        item.active = true;
                        item.add_by = AppSessionState.UserID;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                        item.editby = AppSessionState.UserID;
                        item.symbol = MasterEntity.symbol;
                        item.t_status = "001";
                        item.t_display = (from o in MC.t_statusList where o.t_status == item.t_status select o.t_display).FirstOrDefault();
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                    if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {


                        this.ErrorExist = false;/*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
                    }
                }

                if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                    this.ErrorExist = MasterEntity.HasErrors;
                    if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = dgItemsEntity[dgSelectedIndexItem].HasErrors;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    PUR_T002_B temp = (PUR_T002_B)e.OldItems[0];
                    foreach (var itemToRemove in dgItemScheduleEntity.Where(x => (x.ItemCode == temp.ItemCode && x.id == 0 && x.sku == temp.sku)).ToList())
                    {
                        dgItemScheduleEntity.Remove(itemToRemove);
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
                            }
                        }
                        Computation(true, dgSelectedIndexItem);
                    }


                    foreach (PUR_T002_B item in e.OldItems)
                    {
                        item.PropertyChanged -= EntityViewModelPropertyChanged;
                    }
                    if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
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
                    foreach (PUR_T002_H item in e.NewItems)
                        item.PropertyChanged += this.EntityViewModelPropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (PUR_T002_H item in e.OldItems)
                        item.PropertyChanged -= this.EntityViewModelPropertyChanged;

                /////////////////////////////////Temp Test End
                if (e.Action == NotifyCollectionChangedAction.Add) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (PUR_T002_H item in e.NewItems)
                    {
                        item.editby = AppSessionState.UserID;
                        item.add_by = AppSessionState.UserID;
                        item.active = true;
                        item.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;

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
                        item.exch_rate = MasterEntity.ex_rate;
                        item.local_curr = AppSessionState.CntryCurncy;
                        item.curr_code = MasterEntity.curr_code;

                        item.PropertyChanged += EntityViewModelPropertyChanged;
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
        void Schedule_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "qty")
                {
                    #region Check Schedule Qty Total should not exceed PO Qty.
                    //Check Schedule Qty Total should not exceed PO Qty.
                    decimal? TotalQtyOfScheduleForItem = 0;
                    TotalQtyOfScheduleForItem = dgItemScheduleEntity.Where(item => item.ItemCode == dgItemsEntity[dgSelectedIndexItem].ItemCode && item.sku == dgItemsEntity[dgSelectedIndexItem].sku).Sum(item => item.qty);
                    decimal? POQty = dgItemsEntity[dgSelectedIndexItem].qty;  // pending error : index > count
                    if (TotalQtyOfScheduleForItem > POQty)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "PO Schedule Information";
                        showMessageService.Text = String.Format("Schedule quantity exceeding PO limit. extra Quantity will required additional Purchase Order", this.Title);
                        showMessageService.ShowMessage();
                    }
                    #endregion
                }
                if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = false; /*dgItemsEntity[dgSelectedIndexItem].HasErrors;*/
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
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (PUR_T004_B item in e.NewItems)
                        item.PropertyChanged += this.Schedule_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (PUR_T004_B item in e.OldItems)
                        item.PropertyChanged -= this.Schedule_PropertyChanged;

                /////////////////////////////////Temp Test End
                if (e.Action == NotifyCollectionChangedAction.Add && dgItemsEntity.Count > 0) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (PUR_T004_B item in e.NewItems)
                    {
                        //Adde items Schedules Default Values from Items Entity

                        item.ItemCode = dgItemsEntity[dgSelectedIndexItem].ItemCode;
                        item.sku = dgItemsEntity[dgSelectedIndexItem].sku;
                        item.po_no = dgItemsEntity[dgSelectedIndexItem].po_no;
                        item.rec_qty = 0;
                        item.t_status = "001";
                        item.t_display = (from o in MC.t_statusList where o.t_status == item.t_status select o.t_display).FirstOrDefault();
                        item.active = true;
                        item.editby = AppSessionState.UserID;
                        item.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.rate = 0;
                        item.ref_doc_no = dgItemsEntity[dgSelectedIndexItem].ref_doc_no;
                        item.po_req_no = dgItemsEntity[dgSelectedIndexItem].pur_req_no;
                        item.bom_no = dgItemsEntity[dgSelectedIndexItem].bom_no;
                        item.pur_req_item_row_id = dgItemsEntity[dgSelectedIndexItem].per_req_item_row_id;
                        item.PropertyChanged += EntityViewModelPropertyChanged;
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
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
            if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = false;/*dgItemsEntity[dgSelectedIndexItem].HasErrors;*/
            }

        }
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            LocalVariable = MasterEntity.PartyId;
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            try
            {
                //This will get called when the property of an object inside the collection changes
                if (sender.ToString() == "qty" || sender.ToString() == "unit_price" || sender.ToString() == "tax_id" || sender.ToString() == "active" || sender.ToString() == "discount")
                {
                    Computation(true, dgSelectedIndexItem);
                }
                this.ErrorExist = false; /*MasterEntity.HasErrors;*/
                if (dgItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = false; /*dgItemsEntity[dgSelectedIndexItem].HasErrors;*/
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
            try
            {
                //This will get called when the property of an object inside the collection changes
                if (dgItemScheduleEntity.Count > 0 && dgItemScheduleEntity.Count > dgSelectedIndexItemSchedule && dgSelectedIndexItemSchedule >= 0)
                {

                    if (dgItemScheduleEntity[dgSelectedIndexItemSchedule].expected_date < MasterEntity.po_date)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Schedule date should be greater than Quotation Date ");
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
        #endregion
        #region Command Handler
        private void InsertParty(object InputValue, bool OverrideValue)
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
                            //{ POPUPEntityObject = MC.partyList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            {
                                POPUPEntityObject = MC.partyList.Where(x => x.PartyId.ToString().ToLower().Contains(Request.ToString().ToLower()) == true || x.PartyNm.ToString().ToLower().Contains(Request.ToString().ToLower()) == true).ToList()[0];
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
                    if ((String.IsNullOrEmpty(MasterEntity.po_no) != true || String.IsNullOrWhiteSpace(MasterEntity.po_no) != true) && MasterEntity.PartyId != POPUPEntityObject.PartyId) //Condition: Only enter in the code block if ENtity Not null. Means It is in Edit Mode.
                    {
                        if (dgItemsEntity.Count > 0 && NewRecord == false)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Party Change Information";
                            showMessageService.Text = String.Format("Cannot change party'{0}' in edit mode", this.Title);
                            showMessageService.ShowMessage();

                        }
                        else
                        {
                            MasterEntity.PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.party_name = POPUPEntityObject.PartyNm;
                            MasterEntity.curr_code = POPUPEntityObject.curr_code;
                            MasterEntity.symbol = POPUPEntityObject.symbol;
                            MasterEntity.gst_PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.buss_place = POPUPEntityObject.buss_place;
                            PartyEmailId = POPUPEntityObject.EmailId;
                            if (MasterEntity.curr_code == Currency)
                            {
                                MasterEntity.ex_rate = 1;
                            }


                            RequestParameterData = "LoadPartyDetails" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + "PO" + "!@" + "PO" + "!@" + AppSessionState.po_code + "!@" + MasterEntity.PartyId + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.pg_code;
                            MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, RequestParameterData, "PRO_T002_BL", "PRO", "", 0, "");

                            ContactPersonCollection = CollectionViewSource.GetDefaultView(MCTemp.ContactPerson);
                            ContactPersonCollection.Filter = new Predicate<object>(Filter_Contactperson);
                            StringListContactPerson = MCTemp.ContactPerson.Select(x => x.ContInfoId.ToString()).ToList();

                            //New PopUP - ContactPerson
                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).ContInfoId.ToString());
                            TheFilter = (o, prefix) => ((ADM_M028_C_P)o).ContInfoId.ToString().ToString().ToLower().Contains(prefix) ||
                                                       ((ADM_M028_C_P)o).PersonName.ToString().ToLower().Contains(prefix);
                            ASContactPerson = new AutoSuggestTextViewModel<dynamic>(MCTemp.ContactPerson, TheFilter, SuggestedValue, "ContInfoId", true);
                            ASContactPerson.AutoSuggestVM.IsEmptyValueAllowed = true;

                            if (MCTemp.ContactPerson.Count == 1 && MCTemp.ContactPerson.Count > 0)
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
                                MasterEntity.supplier_EmpId = "";
                                MasterEntity.supplier_EmpName = "";
                                MasterEntity.mail_id = "";

                            }


                            ItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListForPopup);
                            ItemCollection.Filter = new Predicate<object>(FilterItem);
                            StringListItems = MCTemp.ItemListForPopup.Select(x => x.ItemCode).ToList();

                            TermsConditionEntity = MCTemp.TermsAndCondition;

                        }
                    }
                    else if (NewRecord == true && dgItemsEntity.Count > 0 && MasterEntity.PartyId != POPUPEntityObject.PartyId)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Party Selection";
                        showMessageService.Text = String.Format("If You Change The Party Items Will be removed if Catlog Present'{0}'", this.Title);
                        if (showMessageService.ShowMessage() == DialogResult.Ok)
                        {

                            MasterEntity.PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.party_name = POPUPEntityObject.PartyNm;
                            MasterEntity.curr_code = POPUPEntityObject.curr_code;
                            MasterEntity.symbol = POPUPEntityObject.symbol;
                            MasterEntity.gst_PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.buss_place = POPUPEntityObject.buss_place;
                            PartyEmailId = POPUPEntityObject.EmailId;
                            if (MasterEntity.curr_code == Currency)
                            {
                                MasterEntity.ex_rate = 1;
                            }


                            RequestParameterData = "LoadPartyDetails" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + "PO" + "!@" + "PO" + "!@" + AppSessionState.po_code + "!@" + MasterEntity.PartyId + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.pg_code;
                            MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, RequestParameterData, "PRO_T002_BL", "PRO", "", 0, "");

                            ContactPersonCollection = CollectionViewSource.GetDefaultView(MCTemp.ContactPerson);
                            ContactPersonCollection.Filter = new Predicate<object>(Filter_Contactperson);
                            StringListContactPerson = MCTemp.ContactPerson.Select(x => x.ContInfoId.ToString()).ToList();

                            //New PopUP - ContactPerson
                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).ContInfoId.ToString());
                            TheFilter = (o, prefix) => ((ADM_M028_C_P)o).ContInfoId.ToString().ToString().ToLower().Contains(prefix) ||
                                                       ((ADM_M028_C_P)o).PersonName.ToString().ToLower().Contains(prefix);
                            ASContactPerson = new AutoSuggestTextViewModel<dynamic>(MCTemp.ContactPerson, TheFilter, SuggestedValue, "ContInfoId", true);
                            ASContactPerson.AutoSuggestVM.IsEmptyValueAllowed = true;

                            if (MCTemp.ContactPerson.Count == 1 && MCTemp.ContactPerson.Count > 0)
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
                                MasterEntity.supplier_EmpId = "";
                                MasterEntity.supplier_EmpName = "";
                                MasterEntity.mail_id = "";

                            }


                            ItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListForPopup);
                            ItemCollection.Filter = new Predicate<object>(FilterItem);
                            StringListItems = MCTemp.ItemListForPopup.Select(x => x.ItemCode).ToList();

                            TermsConditionEntity = MCTemp.TermsAndCondition;

                            var catlogList = (from o in MCTemp.ItemListForPopup
                                              where (o.cstmr_itemcode != "")
                                              select o).ToList();

                            if (catlogList.Count > 0)
                            {
                                dgItemsEntity.Clear();
                                dgItemScheduleEntity.Clear();
                            }

                        }
                        else
                        {
                            MasterEntity.PartyId = MasterEntity.PartyId;
                        }
                    }
                    else if (NewRecord == true && (MasterEntity.PartyId != POPUPEntityObject.PartyId || MasterEntity.party_name != POPUPEntityObject.PartyNm))
                    {
                        MasterEntity.PartyId = POPUPEntityObject.PartyId;
                        MasterEntity.party_name = POPUPEntityObject.PartyNm;
                        MasterEntity.curr_code = POPUPEntityObject.curr_code;
                        MasterEntity.symbol = POPUPEntityObject.symbol;
                        MasterEntity.gst_PartyId = POPUPEntityObject.PartyId;
                        MasterEntity.buss_place = POPUPEntityObject.buss_place;
                        PartyEmailId = POPUPEntityObject.EmailId;
                        if (MasterEntity.curr_code == Currency)
                        {
                            MasterEntity.ex_rate = 1;
                        }


                        RequestParameterData = "LoadPartyDetails" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + "PO" + "!@" + "PO" + "!@" + AppSessionState.po_code + "!@" + MasterEntity.PartyId + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.pg_code;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, RequestParameterData, "PRO_T002_BL", "PRO", "", 0, "");

                        ContactPersonCollection = CollectionViewSource.GetDefaultView(MCTemp.ContactPerson);
                        ContactPersonCollection.Filter = new Predicate<object>(Filter_Contactperson);
                        StringListContactPerson = MCTemp.ContactPerson.Select(x => x.ContInfoId.ToString()).ToList();

                        //New PopUP - ContactPerson
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).ContInfoId.ToString());
                        TheFilter = (o, prefix) => ((ADM_M028_C_P)o).ContInfoId.ToString().ToString().ToLower().Contains(prefix) ||
                                                   ((ADM_M028_C_P)o).PersonName.ToString().ToLower().Contains(prefix);
                        ASContactPerson = new AutoSuggestTextViewModel<dynamic>(MCTemp.ContactPerson, TheFilter, SuggestedValue, "ContInfoId", true);
                        ASContactPerson.AutoSuggestVM.IsEmptyValueAllowed = true;

                        if (MCTemp.ContactPerson.Count == 1 && MCTemp.ContactPerson.Count > 0)
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
                            MasterEntity.supplier_EmpId = "";
                            MasterEntity.supplier_EmpName = "";
                            MasterEntity.mail_id = "";

                        }


                        ItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListForPopup);
                        ItemCollection.Filter = new Predicate<object>(FilterItem);
                        StringListItems = MCTemp.ItemListForPopup.Select(x => x.ItemCode).ToList();

                        TermsConditionEntity = MCTemp.TermsAndCondition;

                    }

                }
                var msg = new NotificationMessage("PRO_T003_VM");
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
        private void InsertParty_(object InputValue, bool OverrideValue)
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
                            //{ POPUPEntityObject = MC.partyList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            {
                                POPUPEntityObject = MC.partyList.Where(x => x.PartyId.ToString().ToLower().Contains(Request.ToString().ToLower()) == true || x.PartyNm.ToString().ToLower().Contains(Request.ToString().ToLower()) == true).ToList()[0];
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
                    if ((String.IsNullOrEmpty(MasterEntity.po_no) != true || String.IsNullOrWhiteSpace(MasterEntity.po_no) != true) && MasterEntity.PartyId != POPUPEntityObject.PartyId) //Condition: Only enter in the code block if ENtity Not null. Means It is in Edit Mode.
                    {
                        if (dgItemsEntity.Count > 0 && NewRecord == false && AppSessionState.OBJ_COMPANY.comp_code != "1")
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
                            MasterEntity.symbol = POPUPEntityObject.symbol;
                            MasterEntity.gst_PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.buss_place = POPUPEntityObject.buss_place;
                            PartyEmailId = POPUPEntityObject.EmailId;
                            if (MasterEntity.curr_code == Currency)
                            {
                                MasterEntity.ex_rate = 1;
                            }

                        }
                    }
                    else if (NewRecord == true && dgItemsEntity.Count > 0 && MasterEntity.PartyId != POPUPEntityObject.PartyId)
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
                            MasterEntity.symbol = POPUPEntityObject.symbol;
                            MasterEntity.gst_PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.buss_place = POPUPEntityObject.buss_place;
                            PartyEmailId = POPUPEntityObject.EmailId;
                            if (MasterEntity.curr_code == Currency)
                            {
                                MasterEntity.ex_rate = 1;
                            }

                            RequestParameterData = "LoadPartyDetails" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.po_code + "!@" + MasterEntity.PartyId + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.pg_code;
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

                            if (MCTemp.ContactPerson.Count == 1 && MCTemp.ContactPerson.Count > 0)
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
                                MasterEntity.supplier_EmpId = "";
                                MasterEntity.supplier_EmpName = "";
                                MasterEntity.mail_id = "";

                            }

                            //ItemListForPopup = MCTemp.ItemListForPopup;
                            ItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListForPopup);
                            ItemCollection.Filter = new Predicate<object>(FilterItem);
                            StringListItems = MCTemp.ItemListForPopup.Select(x => x.ItemCode).ToList();

                            //New PopUP - Item Code in Data grid
                            //SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T002_P_PR_ItemsList)x).ItemCode);
                            //TheFilter = (o, prefix) => ((PUR_T002_P_PR_ItemsList)o).ItemCode.ToString().ToLower().Contains(prefix) ||
                            //                           ((PUR_T002_P_PR_ItemsList)o).ItemName.ToString().ToLower().Contains(prefix);
                            //ASItemCode = new AutoSuggestTextViewModel<dynamic>(MCTemp.ItemListForPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                            //ASItemCode.AutoSuggestVM.IsEmptyValueAllowed = true;
                            //ASItemCode.AutoSuggestVM.IsFreeTextAllowed = true;

                            dgItemsEntity.Clear();
                            dgItemScheduleEntity.Clear();
                            //LicenceDetailsEntity.Clear();
                        }
                    }
                    else if (MasterEntity.PartyId != POPUPEntityObject.PartyId || MasterEntity.party_name != POPUPEntityObject.PartyNm)
                    {
                        MasterEntity.PartyId = POPUPEntityObject.PartyId;
                        MasterEntity.party_name = POPUPEntityObject.PartyNm;
                        MasterEntity.curr_code = POPUPEntityObject.curr_code;
                        MasterEntity.symbol = POPUPEntityObject.symbol;
                        MasterEntity.gst_PartyId = POPUPEntityObject.PartyId;
                        MasterEntity.buss_place = POPUPEntityObject.buss_place;
                        PartyEmailId = POPUPEntityObject.EmailId;
                        if (MasterEntity.curr_code == Currency)
                        {
                            MasterEntity.ex_rate = 1;
                        }


                        RequestParameterData = "LoadPartyDetails" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + "PO" + "!@" + "PO" + "!@" + AppSessionState.po_code + "!@" + MasterEntity.PartyId + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.pg_code;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, RequestParameterData, "PRO_T002_BL", "PRO", "", 0, "");

                        ContactPersonCollection = CollectionViewSource.GetDefaultView(MCTemp.ContactPerson);
                        ContactPersonCollection.Filter = new Predicate<object>(Filter_Contactperson);
                        StringListContactPerson = MCTemp.ContactPerson.Select(x => x.ContInfoId.ToString()).ToList();

                        //New PopUP - ContactPerson
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).ContInfoId.ToString());
                        TheFilter = (o, prefix) => ((ADM_M028_C_P)o).ContInfoId.ToString().ToString().ToLower().Contains(prefix) ||
                                                   ((ADM_M028_C_P)o).PersonName.ToString().ToLower().Contains(prefix);
                        ASContactPerson = new AutoSuggestTextViewModel<dynamic>(MCTemp.ContactPerson, TheFilter, SuggestedValue, "ContInfoId", true);
                        ASContactPerson.AutoSuggestVM.IsEmptyValueAllowed = true;

                        if (MCTemp.ContactPerson.Count == 1 && MCTemp.ContactPerson.Count > 0)
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
                            MasterEntity.supplier_EmpId = "";
                            MasterEntity.supplier_EmpName = "";
                            MasterEntity.mail_id = "";

                        }


                        //ItemListForPopup = MCTemp.ItemListForPopup;

                        ItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListForPopup);
                        ItemCollection.Filter = new Predicate<object>(FilterItem);
                        StringListItems = MCTemp.ItemListForPopup.Select(x => x.ItemCode).ToList();

                        //New PopUP - Item Code in Data grid
                        //SuggestedValue = new ValueConverter(x => x == null ? "" : ((PUR_T002_P_PR_ItemsList)x).ItemCode);
                        //TheFilter = (o, prefix) => ((PUR_T002_P_PR_ItemsList)o).ItemCode.ToString().ToLower().Contains(prefix) ||
                        //                           ((PUR_T002_P_PR_ItemsList)o).ItemName.ToString().ToLower().Contains(prefix);
                        //ASItemCode = new AutoSuggestTextViewModel<dynamic>(MCTemp.ItemListForPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                        //ASItemCode.AutoSuggestVM.IsEmptyValueAllowed = true;
                        //ASItemCode.AutoSuggestVM.IsFreeTextAllowed = true;

                        TermsConditionEntity = MCTemp.TermsAndCondition;
                    }
                }
                var msg = new NotificationMessage("PRO_T003_VM");
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
        private void InsertDocType(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M007 POPUPEntityObject = null;
                IEnumerable<SYS_M007> BEType = new List<SYS_M007>();
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
                            { POPUPEntityObject = MC.doc_typeList.Where(x => x.doc_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M007>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null && MasterEntity.display_doc_type != POPUPEntityObject.doc_type) // Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (String.IsNullOrEmpty(MasterEntity.po_no) != true || String.IsNullOrWhiteSpace(MasterEntity.po_no) != true) // Only enter in the code block if ENtity Not null.
                    {
                        if (dgItemsEntity.Count > 0 && NewRecord == false)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Party Change Information";
                            showMessageService.Text = String.Format("Can not change Document Type '{0}' in edit mode", this.Title);
                            showMessageService.ShowMessage();
                        }
                    }
                    else if (NewRecord == true && dgItemsEntity.Count > 0)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Party Selection";
                        showMessageService.Text = String.Format("If You Change The Document Type some data Will be removed'{0}'", this.Title);
                        if (showMessageService.ShowMessage() == DialogResult.Ok)
                        {
                            MasterEntity.doc_type = POPUPEntityObject.doc_type;
                            // MasterEntity.display_doc_type = POPUPEntityObject.display_doc_type;
                            MasterEntity.doc_desc = POPUPEntityObject.doc_desc;
                        }
                    }
                    else
                    {
                        MasterEntity.doc_type = POPUPEntityObject.doc_type;
                        // MasterEntity.display_doc_type = POPUPEntityObject.display_doc_type;
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
                            { POPUPEntityObject = MC.ContactPerson.Where(x => x.PersonName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
        private void InsertCurrency(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                ADM_M037_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.currencyList.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
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
                ADM_M003_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.deladdrList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.del_address_id = POPUPEntityObject.location_Id;
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


        //
        // Summary:
        //     This Method load Document Data for Reference document and for Flip DataGrid.
        //     Call for two seperate purpose
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "";
                string ParametersStringValue = "";
                PUR_T002_AFlip ParameterEntityObject = null;
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
                        { Request = "LoadDocumentWithDocumentNumber" + "!@" + ParametersStringValue; }
                        catch (Exception ex) { }
                    }
                }
                else if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<PUR_T002_AFlip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<PUR_T002_AFlip>().ToList()[0];
                        Request = "LoadDocumentWithDocumentNumber" + "!@" + ParameterEntityObject.po_no;
                        NewRecord = false;
                        string RequestParameterData = "LoadPartyDetails" + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + "PO" + "!@" + "PO" + "!@" + AppSessionState.po_code;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, RequestParameterData, "PRO_T002_BL", "PRO", "", 0, "");
                        ItemListForPopup = MCTemp.ItemListForPopup;
                        StringListItems = ItemListForPopup.Select(x => x.ItemCode).ToList();
                    }
                }

                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, Request, "PRO_T002_BL", "PRO", "LoadDocumentWithDocumentNumber", 0, "");

                if (MCTemp.DocumentItems != null)
                {
                    dgItemsEntity.Clear();
                    dgItemsEntity = MCTemp.DocumentItems;
                    MasterEntity = MCTemp.DocumentMaster[0];
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

                if (MCTemp.DocumentDataFlipGrid != null && NewRecord == true && ParameterObject == "Save")
                {
                    FlipGridData = MCTemp.DocumentDataFlipGrid;
                    FlipGridData.Add(MCTemp.DocumentDataFlipGrid[0]);
                    DataGridCollection.Refresh();
                }

                if (MCTemp.TermsAndCondition != null)
                {
                    TermsConditionEntity = MCTemp.TermsAndCondition;
                }
                else
                {
                    MCTemp.TermsAndCondition = new ObservableCollection<PUR_T002_H>();
                }



                if (ParameterReference == "ReferenceDocument")
                {
                    MasterEntity.ref_doc_no = MasterEntity.po_no;
                    MasterEntity.ref_doc_date = MasterEntity.po_date;
                    MasterEntity.ref_doc_type = MasterEntity.doc_type;
                    MasterEntity.shipped = false;
                    MasterEntity.shipped_date = null;
                    MasterEntity.doc_cat = "QP";
                    MasterEntity.doc_type = "QP";
                    MasterEntity.doc_type_user = "QP";
                    MasterEntity.display_doc_type = "QP";
                    MasterEntity.doc_desc = "Purchase Order";
                    MasterEntity.po_no = "";
                    MasterEntity.po_date = DateTime.Now;
                    MasterEntity.add_by = AppSessionState.UserID;
                    MasterEntity.editby = AppSessionState.UserID;
                    MasterEntity.active = true;
                    MasterEntity.rel_sts = "004";
                    MasterEntity.t_status = "Draft";
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
                SelectedTabControlIndex = 0;
                SetPopupSuggestionDataAfterLoad();
                var msg = new NotificationMessage("PRO_T003_VM");
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

        private void SetPopupSuggestionDataAfterLoad()
        {
            ASDelAddress.AutoSuggestVM.Suggestion = MC.deladdrList.Find(x => x.location_Id == MasterEntity.del_address_id);
            ASPurOrg.AutoSuggestVM.Suggestion = PurchaseOrganisationList.Find(x => x.po_code == MasterEntity.po_code);

            ASOrderType.AutoSuggestVM.Suggestion = MC.doc_typeList.Find(x => x.doc_type_user == MasterEntity.doc_type_user);
            ASValidatedBy.AutoSuggestVM.Suggestion = MC.BuyerList.Find(x => x.EmpId == MasterEntity.buyer);
            ASSupplier.AutoSuggestVM.Suggestion = MC.partyList.Find(x => x.PartyId == MasterEntity.PartyId);

            //ASContactPerson.AutoSuggestVM.Suggestion = MCTemp.ContactPerson.Find(x => x.ContInfoId.ToString() == MasterEntity.supplier_EmpId);
            ASBuyer.AutoSuggestVM.Suggestion = MC.BuyerList.Find(x => x.EmpId == MasterEntity.buyer);
            ASBillAddress.AutoSuggestVM.Suggestion = MC.deladdrList.Find(x => x.location_Id == MasterEntity.bill_address_id);
            ASCurrency.AutoSuggestVM.Suggestion = MC.currencyList.Find(x => x.curr_code == MasterEntity.curr_code);
            ASPaymentTerm.AutoSuggestVM.Suggestion = MC.PayTerms.Find(x => x.p_term_code == MasterEntity.p_term_code);
            //ASTax.AutoSuggestVM.Suggestion = MC.TaxList.Find(x => x.id == TaxId);
            //ASItemCode.AutoSuggestVM.Suggestion = MCTemp.ItemListForPopup.Find(x => x.ItemCode == dgItemsEntity[dgSelectedIndexItem].ItemCode);
            //ASUnit.AutoSuggestVM.Suggestion = MC.unitList.Find(x => x.unit_code == dgItemsEntity[dgSelectedIndexItem].unit_code);
            //ASItemCategory.AutoSuggestVM.Suggestion = MC.itemcatList.Find(x => x.item_cat == dgItemsEntity[dgSelectedIndexItem].item_cat);
            //ASTaxacc.AutoSuggestVM.Suggestion = MC.AccountList.Find(x => x.acc_code == TotalDocumentTaxes[dgSelectedIndexTaxSummury].gl_code);

            //var SalesPurchaseDoc = (from o in MC.reference_docList where o.doc_cat == "RQ" select o).ToList();
            //ASReqNo.AutoSuggestVM.Suggestion = SalesPurchaseDoc.Find(x => x.po_no == dgItemScheduleEntity[dgSelectedIndexItemSchedule].po_req_no);

            ASPurGrp.AutoSuggestVM.Suggestion = PurchaseGroupList.Find(x => x.pg_code == MasterEntity.pg_code);
            ASDestWar.AutoSuggestVM.Suggestion = MC.WarehouseList.Find(x => x.wa_code == MasterEntity.wa_code);
            ASStorLoc.AutoSuggestVM.Suggestion = MC.storage_locList.Find(x => x.store_code == MasterEntity.stock_location_id);
            ASIncoTerms.AutoSuggestVM.Suggestion = MC.Incoterms.Find(x => x.incoterms == MasterEntity.incoterms);
            ASEPCG.AutoSuggestVM.Suggestion = MC.LicenseEPCG.Find(x => x.lic_cod == MasterEntity.lic_cod);
            ASAdvance.AutoSuggestVM.Suggestion = MC.LicenseAdvance.Find(x => x.lic_cod == MasterEntity.adv_lic_cd);
            ASCostCentre.AutoSuggestVM.Suggestion = MC.cost_centerList.Find(x => x.cost_center == MasterEntity.cost_center);
            //ASFormType.AutoSuggestVM.Suggestion = MC.FormType.Find(x => x.description == MasterEntity.FormDescription);
            ASBussPlace.AutoSuggestVM.Suggestion = MC.BussinessPlaceList.Find(x => x.buss_place == MasterEntity.buss_place);
        }

        // Pending assignment of LoadSourceDocument() Method.
        string DocumentList = "";
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
                    if (POPUPEntityObject.t_status != "009")
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
                                ReferenceDocINCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
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
        private void LoadDocumentByReferenceDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
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
                                { Request = "LoadDocumentFromRequisitionnumber" + "!@" + ParametersStringValue; }
                                catch (Exception ex) { }
                            }
                            MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, Request, "PRO_T002_BL", "PRO", "LoadDocumentFromRequisitionnumber", 0, "");
                            if (MCTemp.DocumentItems != null)
                            {
                                dgItemsEntity.Clear();
                                dgItemsEntity = MCTemp.DocumentItems;

                            }
                            else
                            {
                                MCTemp.DocumentItems = new ObservableCollection<PUR_T002_B>();
                            }

                            int count = dgItemsEntity.Count();
                            for (int i = 0; i < count; i++)
                            {
                                dgItemsEntity[i].user_source2 = "Local";
                                dgItemsEntity[i].bid_inv_no = "New";
                                SubTotalCalculation(i);
                                Computation(true, i);
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
                                Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParametersStringValue;

                            }
                            MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, Request, "PRO_T002_BL", "PRO", "LoadDocumentWithReferenceDocumentNumber", 0, "");

                            if (MCTemp.DocumentMaster.Count > 0)
                            {
                                MasterEntity = MCTemp.DocumentMaster[0];
                                PersonEmailId = MasterEntity.mail_id;
                                PartyEmailId = MasterEntity.EmailId;
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
                                TermsConditionEntity = MCTemp.TermsAndCondition;
                            }
                            else
                            {
                                MCTemp.TermsAndCondition = new ObservableCollection<PUR_T002_H>();
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
                        MasterEntity.doc_cat = "QP";
                        MasterEntity.doc_type = "QP";
                        MasterEntity.doc_type_user = "QP";
                        MasterEntity.doc_desc = "Purchase Quotation";
                        MasterEntity.po_no = "";
                        MasterEntity.po_date = DateTime.Now;
                        MasterEntity.add_by = AppSessionState.UserID;
                        MasterEntity.editby = AppSessionState.UserID;
                        MasterEntity.active = true;
                        MasterEntity.rel_sts = "004";
                        MasterEntity.t_status = "001";
                        MasterEntity.t_display = "Draft";
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
                var msg = new NotificationMessage("PRO_T003_VM");
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
        private void LoadSourceDocument()
        {
            // Load another previous record from database for provided Document number and generate new document.
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
        private void CheckActiveStatus(bool select)
        {
            //Check weather Status of DataGrid Record is Active or Not. If changes encounter then update other functions accordingly to update Entitoes.

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
        #region Interface Implementation

        //Pending decision for this old code of RaisePropertyChanged
        //public event PropertyChangedEventHandler PropertyChanged2;
        //private void RaisePropertyChanged(string propertyname)
        //{
        //    if (PropertyChanged2 != null)
        //    {
        //        PropertyChanged2(this, new PropertyChangedEventArgs(propertyname));
        //    }
        //}


        #endregion
        #region Abstract Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<PUR_T002_A> result)
        {
            CursorControl.SetBusyState();
            Logging();
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.XmlDataDocument_PUR_T002_B = obj.ObjectToXML(dgItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_B = obj.ObjectToXML(TotalDocumentTaxes);
                    MasterEntity.XmlDataDocument_PUR_T004_A = obj.ObjectToXML(ScheduleEntity);
                    MasterEntity.XmlDataDocument_PUR_T004_B = obj.ObjectToXML(dgItemScheduleEntity);
                    MasterEntity.XmlDataDocument_PUR_T002_H = obj.ObjectToXML(TermsConditionEntity);


                    this.MasterEntity.EndEdit();
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<PUR_T002_A>(MasterEntity, "PRO_T002_BL", "PRO");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<PUR_T002_A>(MasterEntity, "PRO_T002_BL", "PRO");

                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.po_no != null || MasterEntity.po_no != "" && MasterEntity.active == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record saved Successfully ........");
                        showMessageService.ShowMessage();
                    }
                    NewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                }
                var msg = new NotificationMessage("PRO_T003_VM");
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
                //                      group wo by wo.tax_code_id
                //           into g
                //                      select new ACC_T006_B
                //                      {
                //                          id = (int)g.Key,
                //                          tax_amount = g.Sum(wo => wo.tax_amount),
                //                          base_amount = g.Sum(wo => wo.base_amount),
                //                          tax_code_id = g.First().tax_code_id,
                //                          tax_name = g.First().tax_name,
                //                          account_id = g.First().account_id,
                //                      };
                //TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>(GroupByTaxQuery.OrderBy(tax => tax.tax_code_id));
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
            if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
            {
                MC.DocumentDataFlipGrid = (List<PUR_T002_AFlip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                DataGridCollection.Refresh();
                DataGridCollection.SortDescriptions.Add(new SortDescription("po_no", ListSortDirection.Descending));

            }
            if (MasterEntity.XmlDataDocument_PUR_T002_H != null)
            {

                MC.TermsAndCondition = (ObservableCollection<PUR_T002_H>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PUR_T002_H, MC.TermsAndCondition);

                TermsConditionEntity = MC.TermsAndCondition;
            }
            else
            {
                MC.TermsAndCondition = new ObservableCollection<PUR_T002_H>();
            }
            MasterEntity.ts_code = ts_code_vm;
            RemoveRefDoc();
        }
        private void RemoveRefDoc()
        {
            try
            {
                if (MasterEntity.ref_doc_no != null)
                {
                    List<string> DocList = DocumentList.Split(',').ToList();
                    foreach (var item in DocList)
                    {
                        MC.reference_docList.RemoveAll(X => X.po_no == item);
                    }

                    refdoctempa = (from o in MC.reference_docList where o.doc_cat == "RQ" select o).ToList();
                    ReferenceDocRQCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                    ReferenceDocRQCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                    refdoctempa = (from o in MC.reference_docList where o.doc_cat == "IN" select o).ToList();
                    ReferenceDocINCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                    ReferenceDocINCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

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
            refdoctempa = (from o in MC.reference_docList where o.doc_cat == "RQ" select o).ToList();
            ReferenceDocRQCollection = CollectionViewSource.GetDefaultView(refdoctempa);
            refdoctempa = (from o in MC.reference_docList where o.doc_cat == "IN" select o).ToList();
            ReferenceDocINCollection = CollectionViewSource.GetDefaultView(refdoctempa);

            MasterEntity = new PUR_T002_A();
            MasterEntity.ValidateAsync().Wait();
            dgItemsEntity = new ObservableCollection<PUR_T002_B>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>();
            TermsConditionEntity = new ObservableCollection<PUR_T002_H>();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
            dgTotalTaxSummury = new ObservableCollection<PUR_T002_C>();
            ScheduleEntity = new PUR_T004_A();
            dgItemScheduleEntity = new ObservableCollection<PUR_T004_B>();

            DefaultValues();
            var msg = new NotificationMessage("PRO_T003_VM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        protected override void OnRemoveAction(InquiryActionResult<PUR_T002_A> result)
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
                //FlipGridData.Remove(MasterEntity); Temp
                MasterEntity = new PUR_T002_A();
                dgItemsEntity = new ObservableCollection<PUR_T002_B>();
                _dataGridCollection.Refresh();
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
        protected override void OnDocumentAction()
        {

        }

        protected override void OnRefreshCommand(InquiryActionResult<PUR_T002_A> result)
        {
            throw new NotImplementedException();
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
        protected override void OnPrintAction(InquiryActionResult<PUR_T002_A> result)
        {
            CursorControl.SetBusyState();

            object[] objDataSource = new object[7];
            string[] objDataSourceName = new string[7];
            MC.DocumentMaster.Clear();
            MC.DocumentMaster.Add(MasterEntity);
            objDataSource[0] = MC.DocumentMaster;
            objDataSource[1] = dgItemsEntity;
            objDataSource[2] = TotalDocumentTaxesSummury; // TotalDocumentTaxes;
            objDataSource[3] = (List<ADM_M002>)AppSessionState.ADM_M002_List;

            List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
            var Result = TempList.Where(loc => loc.location_Id == MasterEntity.del_address_id).ToList();
            objDataSource[4] = Result;
            objDataSource[5] = MCTemp.DocumentScheduleDetails;
            objDataSource[6] = MCTemp.TermsAndCondition;

            objDataSourceName[0] = "dsPurchaseDocument";
            objDataSourceName[1] = "dsPurchaseDocumentItems";
            objDataSourceName[2] = "dsPurchaseDocumentTax";
            objDataSourceName[3] = "dsCompanyInfo";
            objDataSourceName[4] = "dsLocationInfo";
            objDataSourceName[5] = "dsScheduleDetail";
            objDataSourceName[6] = "dsTermsCondition";

            ReportManager ReportManager = new ReportManager();
            ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Procurment\\PurchaseDocument.rdlc", "Quotation");
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
            var data = obj as SYS_M007;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_doctype))
                {
                    return (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_filterString_doctype.ToLower())) ||
                        (data.doc_desc != null && data.doc_desc.ToString().ToLower().Contains(_filterString_doctype.ToLower())) ||
                         (data.doc_type_user != null && data.doc_type_user.ToString().ToLower().Contains(_filterString_doctype.ToLower()));


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
            var data = obj as ADM_M037_P;
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
            var data = obj as MM_M008_P;
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
                           data.partyId != null && data.partyId.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()));

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
                        { POPUPEntityObject = ItemListForPopup.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && dgItemsEntity.Count == dgSelectedIndexItem)
                    {
                        dgItemsEntity.Add(new PUR_T002_B()
                        {
                            id = 0,
                            ItemCode = POPUPEntityObject.ItemCode,
                            description = POPUPEntityObject.ItemName,
                            active = true,
                            line_id = 0,
                            location_Id = AppSessionState.OBJ_LOCATION.location_id,
                            PartyId = MasterEntity.PartyId,
                            pur_req_no = POPUPEntityObject.Req_NO,
                            pur_req_item = POPUPEntityObject.Pur_Req_Item_id,
                            qty = POPUPEntityObject.Req_Approve_qty,
                            quotation_no = MasterEntity.quotation_no,
                            ref_doc_no = MasterEntity.ref_doc_no,
                            ref_doc_type = MasterEntity.ref_doc_type,
                            sku = POPUPEntityObject.sku,
                            tax_id = POPUPEntityObject.tax_id,
                            unit_code = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM,
                            unit_price = POPUPEntityObject.b_rate,
                            comp_code = AppSessionState.OBJ_COMPANY.comp_code,
                            item_cat = POPUPEntityObject.item_cat,
                            t_status = MasterEntity.t_status,
                            t_display = MasterEntity.t_display
                        });
                    }
                    else if (dgSelectedIndexItem >= 0 && dgItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (dgItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            dgItemsEntity[dgSelectedIndexItem].ItemCode = POPUPEntityObject.ItemCode;
                            dgItemsEntity[dgSelectedIndexItem].description = POPUPEntityObject.ItemName;
                            dgItemsEntity[dgSelectedIndexItem].active = true;
                            dgItemsEntity[dgSelectedIndexItem].line_id = 0;
                            dgItemsEntity[dgSelectedIndexItem].pur_req_no = POPUPEntityObject.Req_NO;
                            dgItemsEntity[dgSelectedIndexItem].PartyId = MasterEntity.PartyId;
                            dgItemsEntity[dgSelectedIndexItem].qty = POPUPEntityObject.Req_Approve_qty;
                            dgItemsEntity[dgSelectedIndexItem].quotation_no = MasterEntity.quotation_no;
                            dgItemsEntity[dgSelectedIndexItem].ref_doc_no = MasterEntity.ref_doc_no;
                            dgItemsEntity[dgSelectedIndexItem].ref_doc_type = MasterEntity.ref_doc_type;
                            dgItemsEntity[dgSelectedIndexItem].sku = POPUPEntityObject.sku;
                            dgItemsEntity[dgSelectedIndexItem].tax_id = POPUPEntityObject.tax_id;
                            dgItemsEntity[dgSelectedIndexItem].unit_code = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM;
                            dgItemsEntity[dgSelectedIndexItem].unit_price = POPUPEntityObject.b_rate;
                            dgItemsEntity[dgSelectedIndexItem].item_cat = POPUPEntityObject.item_cat;
                            dgItemsEntity[dgSelectedIndexItem].t_status = MasterEntity.t_status;
                            dgItemsEntity[dgSelectedIndexItem].t_display = MasterEntity.t_display;
                        }
                        else if (dgItemsEntity[dgSelectedIndexItem].ItemCode != POPUPEntityObject.ItemCode)
                        {
                            dgItemsEntity[dgSelectedIndexItem].ItemCode = "";
                            dgItemsEntity[dgSelectedIndexItem].description = "";
                        }
                    }
                    int count = dgItemsEntity.Count();
                    TotalDocumentTaxes.Clear();
                    for (int i = 0; i < count; i++)
                    {
                        Computation(true, i);
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

        private void InsertTerms(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                MM_M008_P POPUPEntityObject = null;
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
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M008_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = TermsConditionEntity.Where(X => X.con_type == POPUPEntityObject.con_type).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = TermsConditionEntity.IndexOf(TermsConditionEntity.Where(X => X.con_type == POPUPEntityObject.con_type).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && TermsConditionEntity.Count == dgSelectedIndexTerms)
                    {
                        TermsConditionEntity.Add(new PUR_T002_H()
                        {
                            id = 0,
                            active = true,
                            location_Id = AppSessionState.OBJ_LOCATION.location_id,
                            comp_code = AppSessionState.OBJ_COMPANY.comp_code,
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
                            TermsConditionEntity[dgSelectedIndexTerms].location_Id = AppSessionState.OBJ_LOCATION.location_id;
                            TermsConditionEntity[dgSelectedIndexTerms].comp_code = AppSessionState.OBJ_COMPANY.comp_code;
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
                PUR_T002_H newObj = new PUR_T002_H();
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

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = dgItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = dgItemsEntity.IndexOf(dgItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && dgItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (dgItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            dgItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (dgItemsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                        {
                            dgItemsEntity[dgSelectedIndexItem].unit_code = "";
                        }
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
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (dgItemsEntity.Count > i && dgItemsEntity[dgSelectedIndexItem].id == 0)
                {
                    dgItemsEntity.RemoveAt(i);
                    Computation(true, dgSelectedIndexItem);
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

        private void InsertManualTaxChangedCommand(object InputValue)
        {
            Computation(true, dgSelectedIndexItem);
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
                    Computation(true, dgSelectedIndexItem);
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

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = dgItemsEntity.Where(X => X.item_cat == POPUPEntityObject.item_cat).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = dgItemsEntity.IndexOf(dgItemsEntity.Where(X => X.item_cat == POPUPEntityObject.item_cat).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && dgItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (dgItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            dgItemsEntity[dgSelectedIndexItem].item_cat = POPUPEntityObject.item_cat;
                        }
                        else if (dgItemsEntity[dgSelectedIndexItem].item_cat != POPUPEntityObject.item_cat)
                        {
                            dgItemsEntity[dgSelectedIndexItem].item_cat = "";
                        }
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

        // FilterScheduleDataGrid : Filter for Schedule Items as per selected item in dgItemsEntity. This filter is work for ObserverableCollection.
        private void FilterScheduleDataGrid()
        {
            try
            {
                //if (dgItemScheduleEntity != null && dgItemScheduleEntity.Count > 0 && dgSelectedIndexItem < dgItemScheduleEntity.Count && dgSelectedIndexItem >= 0)
                //{
                //    DataGridView = CollectionViewSource.GetDefaultView(dgItemScheduleEntity);
                //    DataGridView.Filter = adv => ((PUR_T004_B)adv).ItemCode.Equals(dgItemsEntity[dgSelectedIndexItem].ItemCode);
                //    DataGridView.Refresh();
                //}
                if (dgItemScheduleEntity != null && dgItemScheduleEntity.Count > 0 && dgSelectedIndexItem >= 0)
                {

                    DataGridView = CollectionViewSource.GetDefaultView(dgItemScheduleEntity);
                    DataGridView.Filter = adv => ((PUR_T004_B)adv).ItemCode.Equals(dgItemsEntity[dgSelectedIndexItem].ItemCode);
                    DataGridView.Refresh();

                }
            }
            catch (Exception ex)
            { }
        }




        #endregion
    }
}
