using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Collections.Specialized;
using System.Threading.Tasks;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using Reflection.BusinessEntity.CustomerRelation;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class SEL_T001_Quot_VM : WorkspaceViewModel<SEL_T001>
    {
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SEL_T001_Quot_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        #region AutoSuggest TextBox Region for Master
        private AutoSuggestTextViewModel<dynamic> _ASSoldToParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSoldToParty
        {
            get { return _ASSoldToParty; }
            set
            {
                if (_ASSoldToParty != value)
                {
                    _ASSoldToParty = value; RaisePropertyChanged("ASSoldToParty");
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
        private AutoSuggestTextViewModel<dynamic> _ASShipToParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASShipToParty
        {
            get { return _ASShipToParty; }
            set
            {
                if (_ASShipToParty != value)
                {
                    _ASShipToParty = value; RaisePropertyChanged("ASShipToParty");
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

        private AutoSuggestTextViewModel<dynamic> _ASUOMPRICEQTY { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUOMPRICEQTY
        {
            get { return _ASUOMPRICEQTY; }
            set
            {
                if (_ASUOMPRICEQTY != value)
                {
                    _ASUOMPRICEQTY = value; RaisePropertyChanged("ASUOMPRICEQTY");
                }
            }
        }

        #endregion

        #region AutoSuggest TextBox Region for Sales Tab

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

        private AutoSuggestTextViewModel<dynamic> _ASRefferingParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRefferingParty
        {
            get { return _ASRefferingParty; }
            set
            {
                if (_ASRefferingParty != value)
                {
                    _ASRefferingParty = value; RaisePropertyChanged("ASRefferingParty");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASRefContPerson { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRefContPerson
        {
            get { return _ASRefContPerson; }
            set
            {
                if (_ASRefContPerson != value)
                {
                    _ASRefContPerson = value; RaisePropertyChanged("ASRefContPerson");
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
        #endregion

        #region AutoSuggest TextBox Region for Item Details Tab

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

        private AutoSuggestTextViewModel<dynamic> _ASItemLineCat { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItemLineCat
        {
            get { return _ASItemLineCat; }
            set
            {
                if (_ASItemLineCat != value)
                {
                    _ASItemLineCat = value; RaisePropertyChanged("ASItemLineCat");
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

        private AutoSuggestTextViewModel<dynamic> _ASOrderTo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASOrderTo
        {
            get { return _ASOrderTo; }
            set
            {
                if (_ASOrderTo != value)
                {
                    _ASOrderTo = value; RaisePropertyChanged("ASOrderTo");
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
        #endregion

        #region AutoSuggest TextBox Region for Delivery Schedule Tab

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

        private AutoSuggestTextViewModel<dynamic> _ASTransporterMaster { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTransporterMaster
        {
            get { return _ASTransporterMaster; }
            set
            {
                if (_ASTransporterMaster != value)
                {
                    _ASTransporterMaster = value; RaisePropertyChanged("ASTransporterMaster");
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
        #endregion

        #region AutoSuggest TextBox Region for Terms And Conditions Tab

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
        #endregion

        #region AutoSuggest TextBox Region for Filter View Tab

        private AutoSuggestTextViewModel<dynamic> _AS_FltrPlant { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_FltrPlant
        {
            get { return _AS_FltrPlant; }
            set
            {
                if (_AS_FltrPlant != value)
                {
                    _AS_FltrPlant = value; RaisePropertyChanged("AS_FltrPlant");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Fltr_status { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Fltr_status
        {
            get { return _AS_Fltr_status; }
            set
            {
                if (_AS_Fltr_status != value)
                {
                    _AS_Fltr_status = value; RaisePropertyChanged("AS_Fltr_status");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Fltr_SoldToParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Fltr_SoldToParty
        {
            get { return _AS_Fltr_SoldToParty; }
            set
            {
                if (_AS_Fltr_SoldToParty != value)
                {
                    _AS_Fltr_SoldToParty = value; RaisePropertyChanged("AS_Fltr_SoldToParty");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Fltr_SalesPerson { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Fltr_SalesPerson
        {
            get { return _AS_Fltr_SalesPerson; }
            set
            {
                if (_AS_Fltr_SalesPerson != value)
                {
                    _AS_Fltr_SalesPerson = value; RaisePropertyChanged("AS_Fltr_SalesPerson");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASFltr_DocType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFltr_DocType
        {
            get { return _ASFltr_DocType; }
            set
            {
                if (_ASFltr_DocType != value)
                {
                    _ASFltr_DocType = value; RaisePropertyChanged("ASFltr_DocType");
                }
            }
        }

        #endregion

        #region AutoSuggest TextBox Region  Other
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

        private AutoSuggestTextViewModel<dynamic> _ASDeliveryAdddress { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDeliveryAdddress
        {
            get { return _ASDeliveryAdddress; }
            set
            {
                if (_ASDeliveryAdddress != value)
                {
                    _ASDeliveryAdddress = value; RaisePropertyChanged("ASDeliveryAdddress");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASLocationId { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLocationId
        {
            get { return _ASLocationId; }
            set
            {
                if (_ASLocationId != value)
                {
                    _ASLocationId = value; RaisePropertyChanged("ASLocationId");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCompany { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCompany
        {
            get { return _ASCompany; }
            set
            {
                if (_ASCompany != value)
                {
                    _ASCompany = value; RaisePropertyChanged("ASCompany");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASLocation { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLocation
        {
            get { return _ASLocation; }
            set
            {
                if (_ASLocation != value)
                {
                    _ASLocation = value; RaisePropertyChanged("ASLocation");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASInk { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASInk
        {
            get { return _ASInk; }
            set
            {
                if (_ASInk != value)
                {
                    _ASInk = value; RaisePropertyChanged("ASInk");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASILD { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASILD
        {
            get { return _ASILD; }
            set
            {
                if (_ASILD != value)
                {
                    _ASILD = value; RaisePropertyChanged("ASILD");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBallType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBallType
        {
            get { return _ASBallType; }
            set
            {
                if (_ASBallType != value)
                {
                    _ASBallType = value; RaisePropertyChanged("ASBallType");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASGrade { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGrade
        {
            get { return _ASGrade; }
            set
            {
                if (_ASGrade != value)
                {
                    _ASGrade = value; RaisePropertyChanged("ASGrade");
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
        #endregion 

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
                    else if (SourceName == "sditem_cat_code")
                    { ASDefault = ASItemLineCat; }
                    else if (SourceName == "PartyNm")
                    { ASDefault3 = ASTransporter; }
                    else if (SourceName == "Termscon_type")
                    { ASDefault2 = ASTermsCond; }
                    else if (SourceName == "con_type")
                    { ASDefault1 = ASConditionType; }
                    else if (SourceName == "curr_code")
                    { ASDefault1 = ASdgCurrency; }
                    else if (SourceName == "order_to_plant")
                    { ASDefault = ASOrderTo; }
                    else if (SourceName == "para1")
                    { ASDefault = ASInk; }
                    else if (SourceName == "para2")
                    { ASDefault = ASBallType; }
                    else if (SourceName == "para5")
                    { ASDefault = ASILD; }
                    else if (SourceName == "para3")
                    { ASDefault = ASGrade; }
                    else if (SourceName == "gl_code")
                    { ASDefault1 = ASTaxacc; }
                }
            }
        }
        #endregion

        #region Variable Declaration
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
        public string doc_cat_vm { get; set; }
        bool isNewRecord = true;
        string PartyEmailId = "";
        string PersonEmailId = "";
        string PreviousUnitCode = "";
        string NewUnitCode = "";
        decimal? unit_price;
        decimal? higher_limit;
        decimal? lower_limit;
        string Currency;

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
        private RequestParameters _RequestPara;
        public RequestParameters RequestPara
        {
            get { return _RequestPara; }
            set
            {
                if (_RequestPara != value)
                {
                    _RequestPara = value;

                    RaisePropertyChanged("RequestPara");
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
        private Nullable<System.DateTime> _FrmDate;
        public Nullable<System.DateTime> FrmDate
        {
            get { return _FrmDate; }
            set
            {
                _FrmDate = value;
                RaisePropertyChanged("FrmDate");
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

        private List<SEL_T001_P_RefDoc> _refdoctempa;
        public List<SEL_T001_P_RefDoc> refdoctempa
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
                        TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>(TotalDocumentTaxes.Where(tax => tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[dgSelectedIndexItem].sku?.ToString() ?? "") && tax.item_row_id == ItemsEntity[dgSelectedIndexItem].id));
                    }

                }
            }
        }

        private bool _PrePrinted;
        public bool PrePrinted
        {
            get
            {
                return _PrePrinted;
            }
            set
            {
                _PrePrinted = value;
                RaisePropertyChanged("PrePrinted");
            }
        }

        private int _AttachmentCount;
        public int AttachmentCount
        {
            get { return _AttachmentCount; }
            set
            {
                if (_AttachmentCount != value)
                {
                    _AttachmentCount = value;
                    RaisePropertyChanged("AttachmentCount");
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

        public RelayCommand<IList> CollectionChangedCommand
        {
            get;
            private set;
        }

        public RelayCommand<IList> SelectionChangedParaValCommand
        {
            get;
            private set;
        }

        private bool _isTabChangeAllowed = true;
        public bool isTabChangeAllowed
        {
            get { return _isTabChangeAllowed; }
            set
            {
                if (_isTabChangeAllowed != value)
                {
                    _isTabChangeAllowed = value;
                    RaisePropertyChanged("isTabChangeAllowed");
                }
            }
        }
        #endregion

        #region ICollection for Popup Control

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
        private ICollectionView _doc_typeCollectionBf;
        public ICollectionView Doc_TypeCollectionBf
        {
            get { return _doc_typeCollectionBf; }
            set
            {
                _doc_typeCollectionBf = value;
                RaisePropertyChanged("Doc_TypeCollectionBf");
            }
        }
        private ICollectionView _dgLocationCollection;
        public ICollectionView dgLocationCollection
        {
            get { return _dgLocationCollection; }
            set { _dgLocationCollection = value; RaisePropertyChanged("dgLocationCollection"); }
        }
        private ICollectionView _PlantCollection;
        public ICollectionView PlantCollection
        {
            get { return _PlantCollection; }
            set { _PlantCollection = value; RaisePropertyChanged("PlantCollection"); }
        }
        private ICollectionView _RefContactPersonCollection;
        public ICollectionView RefContactPersonCollection
        {
            get { return _RefContactPersonCollection; }
            set
            {
                _RefContactPersonCollection = value;
                RaisePropertyChanged("RefContactPersonCollection");
            }
        }

        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }
        private List<SEL_T001_A> _SalesDataCollection;
        public List<SEL_T001_A> SalesDataCollection
        {
            get { return _SalesDataCollection; }
            set { _SalesDataCollection = value; RaisePropertyChanged("SalesDataCollection"); }
        }
        private List<SEL_T001_A> _SalesDataCollectionShow;
        public List<SEL_T001_A> SalesDataCollectionShow
        {
            get { return _SalesDataCollectionShow; }
            set { _SalesDataCollectionShow = value; RaisePropertyChanged("SalesDataCollectionShow"); }
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
        private List<string> _strListDocTypeBf;
        public List<string> StringListDocumentTypesBf
        {
            get { return _strListDocTypeBf; }
            set
            {
                if (_strListDocTypeBf != value)
                {
                    _strListDocTypeBf = value;
                }
            }
        }
        private List<string> _StringListContactPerson;
        public List<string> StringListContactPerson
        {
            get { return _StringListContactPerson; }
            set
            {
                if (_StringListContactPerson != value)
                {
                    _StringListContactPerson = value;
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
        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }


        #region Relay Commands Declaration for Master
        public RelayCommand<object> CommandSoldToParty { get; private set; }
        public RelayCommand<object> CommandShipToParty { get; private set; }
        public RelayCommand<object> CommandBuyer { get; private set; }
        public RelayCommand<object> CommandCurrency { get; private set; }
        public RelayCommand<object> CommandSeller { get; private set; }
        public RelayCommand<object> CmdInsert_t_status { get; private set; }
        public RelayCommand<object> cmdTR_ModeMaster { get; private set; }
        public RelayCommand<object> CommandTransporterMaster { get; private set; }
        #endregion

        #region Relay Commands Declaration for Sales Tab
        public RelayCommand<object> CommandIncoterms { get; private set; }
        public RelayCommand<object> CommandPayTerms { get; private set; }
        public RelayCommand<object> CommandServiceProvider { get; private set; }
        public RelayCommand<object> cmdRefContactPerson { get; private set; }
        public RelayCommand<object> CommandBank { get; private set; }
        public RelayCommand<object> CommandNastroBank { get; private set; }
        public RelayCommand<object> CommandSalseOrg { get; private set; }
        public RelayCommand<object> CommandSalseGroup { get; private set; }
        #endregion

        #region Relay Commands Declaration for ItemDetails Tab
        public RelayCommand<object> CommandItem { get; private set; }
        public RelayCommand<object> CommandItemCategory { get; private set; }
        public RelayCommand<object> CommandUOM { get; private set; }
        public RelayCommand<object> CommandUOMPriceQty { get; private set; }
        public RelayCommand<object> CmdUnitPrice { get; private set; }
        public RelayCommand<object> CommandLocations { get; private set; }
        public RelayCommand<object> CmdItemInfo { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> cmdOpenAttachments { get; private set; }
        public RelayCommand<object> CmdCondType { get; private set; }
        public RelayCommand<object> CommandAddSelectedTax { get; private set; }
        public RelayCommand<object> CmddgCurrency { get; private set; }
        public RelayCommand<Boolean> AddRemoveManualTax { get; private set; }
        public RelayCommand<object> cmdDeleteTax { get; private set; }
        #endregion

        #region Relay Commands Declaration for Delivery Schedule Tab
        public RelayCommand<object> cmdTransporter { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowSchedule { get; private set; }
        #endregion

        #region Relay Commands Declaration for Terms And Conditions Tab
        public RelayCommand<object> CommandTerms { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridTerms { get; private set; }
        public RelayCommand<object> CommandTermsScope { get; private set; }
        #endregion

        #region Relay Commands Declaration for View Filters Tab
        public RelayCommand<object> cmdFilterByPlant { get; private set; }
        public RelayCommand<object> CommandFltrStatus { get; private set; }
        public RelayCommand<object> CommandFltrSoldToParty { get; private set; }
        public RelayCommand<object> CommandFltrSeller { get; private set; }
        #endregion

        #region Other Commands

        public RelayCommand<object> CommandDocTypeBf { get; private set; }
        public RelayCommand<object> CommandDocType { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CommandLoadDocumentFromSource { get; private set; }
        public RelayCommand<object> CommandNotifyParty { get; private set; }
        public RelayCommand<object> CommandTransporter { get; private set; }
        public RelayCommand<object> CommandJournal { get; private set; }
        public RelayCommand<object> CommandGLCode { get; private set; }
        public RelayCommand<object> CommandSalseDivision { get; private set; }
        public RelayCommand<object> CommandCostCenter { get; private set; }
        public RelayCommand<object> CommandBallType { get; private set; }
        public RelayCommand<object> CommandILD { get; private set; }
        public RelayCommand<object> CommandWireType { get; private set; }
        public RelayCommand<object> CommandBallDia { get; private set; }
        public RelayCommand<object> CommandInk { get; private set; }
        public RelayCommand<object> CommandSoldToAddress { get; private set; }
        public RelayCommand<object> CommandReferenceDoc { get; private set; }
        public RelayCommand<object> CommandShipToAddress { get; private set; }
        public RelayCommand<Boolean> CommandActiveInactiveCheck { get; private set; }
        public RelayCommand<object> CommandReferenceDocumentType { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByRefDocNumber { get; private set; }
        public RelayCommand<object> CommandLicenseAdvance { get; private set; }
        public RelayCommand<object> CommandLicenseEPCG { get; private set; }
        public RelayCommand<object> ManualTaxChangedCommand { get; private set; }
        public RelayCommand<object> CommandMailDocuments { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        public RelayCommand<object> CommandGrade { get; private set; }
        public RelayCommand<object> CmdInsertCompany { get; private set; }
        public RelayCommand<object> CmdInsertLocationId { get; private set; }
        #endregion
        #endregion

        #region Constructor
        public SEL_T001_Quot_VM(string doc_cat, string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;
            NotificationDataCollection = new List<NotificationData>();
            MasterEntity = new SEL_T001();
            ItemsEntity = new ObservableCollection<SEL_T001_A>();
            ScheduleEntity = new SEL_T002();
            ItemScheduleEntity = new ObservableCollection<SEL_T002_A>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
            TermsConditionEntity = new ObservableCollection<SEL_T001_E>();
            ItemListForPopup = new List<SEL_T001_P_SO_ItemsList>();
            FlipGridData = new List<SEL_T001_Flip>();
            SalesDataCollection = new List<SEL_T001_A>();
            SalesDataCollectionShow = new List<SEL_T001_A>();

            SalesUnitPriceCollection = new List<GetItemDetailsEntity>();
            SalesQFRCollection = new List<GetItemDetailsEntity>();
            SalesDispatchCollection = new List<GetItemDetailsEntity>();
            SalesProjDispatchCollection = new List<GetItemDetailsEntity>();
            RequestPara = new RequestParameters();
            FrmDate = System.DateTime.Now;
            ToDate = System.DateTime.Now;
            MC = new MultipleContext_SEL_T001();
            MCTemp = new MultipleContext_SEL_T001();
            AddRemoveManualTax = new RelayCommand<bool>(ActiveInactiveTax);
            SEL_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            SEL_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            SEL_T002.ModelEntityUpdated += new EventHandler(ModelUpdated_ScheduleMaster);
            SEL_T002_A.ModelEntityUpdated += new EventHandler(ModelUpdated_ScheduleItem);
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            ItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
            //LoadInitialData();
            CommandInitialization();
        }
        public SEL_T001_Quot_VM(string doc_cat, string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            this.doc_cat_vm = doc_cat;
            NotificationDataCollection = new List<NotificationData>();
            MasterEntity = new SEL_T001();
            ItemsEntity = new ObservableCollection<SEL_T001_A>();
            ScheduleEntity = new SEL_T002();
            ItemScheduleEntity = new ObservableCollection<SEL_T002_A>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
            TermsConditionEntity = new ObservableCollection<SEL_T001_E>();
            ItemListForPopup = new List<SEL_T001_P_SO_ItemsList>();
            FlipGridData = new List<SEL_T001_Flip>();
            SalesDataCollection = new List<SEL_T001_A>();
            SalesDataCollectionShow = new List<SEL_T001_A>();

            SalesUnitPriceCollection = new List<GetItemDetailsEntity>();
            SalesQFRCollection = new List<GetItemDetailsEntity>();
            SalesDispatchCollection = new List<GetItemDetailsEntity>();
            SalesProjDispatchCollection = new List<GetItemDetailsEntity>();
            RequestPara = new RequestParameters();
            FrmDate = System.DateTime.Now;
            ToDate = System.DateTime.Now;
            MC = new MultipleContext_SEL_T001();
            MCTemp = new MultipleContext_SEL_T001();
            AddRemoveManualTax = new RelayCommand<bool>(ActiveInactiveTax);
            SEL_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            SEL_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            SEL_T002.ModelEntityUpdated += new EventHandler(ModelUpdated_ScheduleMaster);
            SEL_T002_A.ModelEntityUpdated += new EventHandler(ModelUpdated_ScheduleItem);
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            ItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
            //LoadInitialData();
            CommandInitialization();
        }

        #endregion

        #region Relay Command Actions ·

        #region Relay Command Actions : Master·
        private async void InsertSoldToParty(object InputValue, bool OverrideValue)
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
                            { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    if ((String.IsNullOrEmpty(MasterEntity.sono) != true || String.IsNullOrWhiteSpace(MasterEntity.sono) != true) && MasterEntity.PartyId != POPUPEntityObject.PartyId) //Condition: Only enter in the code block if ENtity Not null. Means It is in Edit Mode.
                    {
                        if (ItemsEntity.Count > 0 && isNewRecord == false && AppSessionState.comp_code != "001")
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
                            if (MasterEntity.curr_code == Currency)
                            {
                                MasterEntity.ex_rate = 1;
                            }
                            PartyEmailId = POPUPEntityObject.EmailId;

                            RequestParameterData = "LoadSoldToPartyDetails" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + MasterEntity.PartyId;
                            // RequestParameterData = "LoadSoldToPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.PartyId + "!@" + AppSessionState.client + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + MasterEntity.ts_code;
                            MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, RequestParameterData, "SalesQuotation", "CRM", "", 0, "");


                            MC.PartysContactInfo = MCTemp.PartysContactInfo;
                            MC.PartysSoldToAddresses = MCTemp.PartysSoldToAddresses;
                            MC.ItemListPopup = MCTemp.ItemListPopup;
                            MC.TermsAndCondition = MCTemp.TermsAndCondition;
                            TermsConditionEntity = MC.TermsAndCondition;

                            BuyerCollection = CollectionViewSource.GetDefaultView(MC.PartysContactInfo);
                            BuyerCollection.Filter = new Predicate<object>(Filter_Buyer);
                            StringListBuyer = MC.PartysContactInfo.Select(x => x.ContInfoId.ToString()).ToList();

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).PersonName);
                            TheFilter = (o, prefix) => (((ADM_M028_C_P)o).PersonName ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_C_P)o).ContInfoId.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                            ASBuyer = new AutoSuggestTextViewModel<dynamic>(MC.PartysContactInfo, TheFilter, SuggestedValue, "PersonName", true);
                            ASBuyer.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASBuyer.AutoSuggestVM.IsFreeTextAllowed = true;

                            BillingAddressCollection = CollectionViewSource.GetDefaultView(MC.PartysSoldToAddresses);
                            BillingAddressCollection.Filter = new Predicate<object>(Filter_BillingAddress);
                            StringListShipToAddress = MC.PartysSoldToAddresses.Select(x => x.Location.ToString()).ToList();

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).Location);
                            TheFilter = (o, prefix) => (((ADM_M028_D)o).Location ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_D)o).SrNo.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                            ASBillAdddress = new AutoSuggestTextViewModel<dynamic>(MC.PartysSoldToAddresses, TheFilter, SuggestedValue, "Location", true);
                            ASBillAdddress.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASBillAdddress.AutoSuggestVM.IsFreeTextAllowed = true;

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
                            else if (MC.PartysSoldToAddresses.Count == 1)
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

                                var BillingAddress = (from o in MC.PartysSoldToAddresses where o.AddType == "Billing Address" select o).ToList();
                                if (BillingAddress.Count == 0)
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
                                else if (BillingAddress.Count == 1)
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

                                    MasterEntity.bill_address_id = BillingAddress[0].SrNo;
                                    MasterEntity.billing_address = BillingAddress[0].Location;
                                    MasterEntity.country_nm = BillingAddress[0].CntryName;
                                    MasterEntity.country_code = BillingAddress[0].country_code;
                                    MasterEntity.state_nm = BillingAddress[0].StatName;
                                    MasterEntity.city = BillingAddress[0].City;
                                    MasterEntity.address = BillingAddress[0].Add1;
                                    MasterEntity.address1 = BillingAddress[0].Add2;
                                    MasterEntity.pincode = BillingAddress[0].PinCode;
                                }
                                else if (BillingAddress.Count > 1)
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
                            }
                            PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListPopup);
                            PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                            StringListItems = MC.ItemListPopup.Select(x => x.ItemCode).ToList();

                            //SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P_SO_ItemsList)x).ItemCode);
                            //TheFilter = (o, prefix) => (((SEL_T001_P_SO_ItemsList)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower ()) || (((SEL_T001_P_SO_ItemsList)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower ());
                            //ASItems = new AutoSuggestTextViewModel<dynamic>(MC.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                            //ASItems.AutoSuggestVM.IsEmptyValueAllowed = true;
                            //ASItems.AutoSuggestVM.IsFreeTextAllowed = true;

                            TermsConditionEntity = MC.TermsAndCondition;
                            TermsConditionCollection = CollectionViewSource.GetDefaultView(MC.TermsConditionCollection);
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
                            MasterEntity.symbol = POPUPEntityObject.symbol;
                            if (MasterEntity.curr_code == Currency)
                            {
                                MasterEntity.ex_rate = 1;
                            }

                            PartyEmailId = POPUPEntityObject.EmailId;
                            RequestParameterData = "LoadSoldToPartyDetails" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + MasterEntity.PartyId;

                            MCTemp = await repository_MCTemp.GetDataWithReturnDomainObjectASynchronus<MultipleContext_SEL_T001>(MCTemp, RequestParameterData, "SalesQuotation", "CRM", "", 0, "");

                            MC.PartysContactInfo = MCTemp.PartysContactInfo;
                            MC.PartysSoldToAddresses = MCTemp.PartysSoldToAddresses;
                            InsertShipToParty(MasterEntity.ship_to_party, false);
                            MC.ItemListPopup = MCTemp.ItemListPopup;

                            MC.TermsAndCondition = MCTemp.TermsAndCondition;
                            TermsConditionEntity = MC.TermsAndCondition;

                            BuyerCollection = CollectionViewSource.GetDefaultView(MC.PartysContactInfo);
                            BuyerCollection.Filter = new Predicate<object>(Filter_Buyer);
                            StringListBuyer = MC.PartysContactInfo.Select(x => x.ContInfoId.ToString()).ToList();

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).PersonName);
                            TheFilter = (o, prefix) => (((ADM_M028_C_P)o).PersonName ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_C_P)o).ContInfoId.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                            ASBuyer = new AutoSuggestTextViewModel<dynamic>(MC.PartysContactInfo, TheFilter, SuggestedValue, "PersonName", true);
                            ASBuyer.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASBuyer.AutoSuggestVM.IsFreeTextAllowed = true;

                            BillingAddressCollection = CollectionViewSource.GetDefaultView(MC.PartysSoldToAddresses);
                            BillingAddressCollection.Filter = new Predicate<object>(Filter_BillingAddress);
                            StringListShipToAddress = MC.PartysSoldToAddresses.Select(x => x.Location.ToString()).ToList();

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).Location);
                            TheFilter = (o, prefix) => (((ADM_M028_D)o).Location ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_D)o).SrNo.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                            ASBillAdddress = new AutoSuggestTextViewModel<dynamic>(MC.PartysSoldToAddresses, TheFilter, SuggestedValue, "Location", true);
                            ASBillAdddress.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASBillAdddress.AutoSuggestVM.IsFreeTextAllowed = true;

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
                            else if (MC.PartysSoldToAddresses.Count == 1)
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

                                var BillingAddress = (from o in MC.PartysSoldToAddresses where o.AddType == "Billing Address" select o).ToList();
                                if (BillingAddress.Count == 0)
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
                                else if (BillingAddress.Count == 1)
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

                                    MasterEntity.bill_address_id = BillingAddress[0].SrNo;
                                    MasterEntity.billing_address = BillingAddress[0].Location;
                                    MasterEntity.country_nm = BillingAddress[0].CntryName;
                                    MasterEntity.country_code = BillingAddress[0].country_code;
                                    MasterEntity.state_nm = BillingAddress[0].StatName;
                                    MasterEntity.city = BillingAddress[0].City;
                                    MasterEntity.address = BillingAddress[0].Add1;
                                    MasterEntity.address1 = BillingAddress[0].Add2;
                                    MasterEntity.pincode = BillingAddress[0].PinCode;
                                }
                                else if (BillingAddress.Count > 1)
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
                            }

                            PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListPopup);
                            PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                            StringListItems = MC.ItemListPopup.Select(x => x.ItemCode).ToList();

                            //SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P_SO_ItemsList)x).ItemCode);
                            //TheFilter = (o, prefix) => (((SEL_T001_P_SO_ItemsList)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower ()) || (((SEL_T001_P_SO_ItemsList)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower ());
                            //ASItems = new AutoSuggestTextViewModel<dynamic>(MC.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                            //ASItems.AutoSuggestVM.IsEmptyValueAllowed = true;
                            //ASItems.AutoSuggestVM.IsFreeTextAllowed = true;

                            ItemsEntity.Clear();
                            ItemScheduleEntity.Clear();
                        }
                    }
                    else if (MasterEntity.PartyId != POPUPEntityObject.PartyId || MasterEntity.party_name != POPUPEntityObject.PartyNm)
                    {
                        MasterEntity.PartyId = POPUPEntityObject.PartyId;
                        MasterEntity.party_name = POPUPEntityObject.PartyNm;
                        MasterEntity.curr_code = POPUPEntityObject.curr_code;
                        MasterEntity.symbol = POPUPEntityObject.symbol;
                        if (MasterEntity.curr_code == Currency)
                        {
                            MasterEntity.ex_rate = 1;
                        }
                        PartyEmailId = POPUPEntityObject.EmailId;

                        RequestParameterData = "LoadSoldToPartyDetails" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + MasterEntity.PartyId;
                        // RequestParameterData = "LoadSoldToPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.PartyId + "!@" + AppSessionState.client;
                        //MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, RequestParameterData, "SalesQuotation", "CRM", "", 0, "");
                        MCTemp = await repository_MCTemp.GetDataWithReturnDomainObjectASynchronus<MultipleContext_SEL_T001>(MCTemp, RequestParameterData, "SalesQuotation", "CRM", "", 0, "");

                        MC.PartysContactInfo = MCTemp.PartysContactInfo;
                        MC.PartysSoldToAddresses = MCTemp.PartysSoldToAddresses;
                        MC.ItemListPopup = MCTemp.ItemListPopup;
                        MC.TermsAndCondition = MCTemp.TermsAndCondition;
                        TermsConditionEntity = MC.TermsAndCondition;

                        BuyerCollection = CollectionViewSource.GetDefaultView(MC.PartysContactInfo);
                        BuyerCollection.Filter = new Predicate<object>(Filter_Buyer);
                        StringListBuyer = MC.PartysContactInfo.Select(x => x.ContInfoId.ToString()).ToList();

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).PersonName);
                        TheFilter = (o, prefix) => (((ADM_M028_C_P)o).PersonName ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_C_P)o).ContInfoId.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                        ASBuyer = new AutoSuggestTextViewModel<dynamic>(MC.PartysContactInfo, TheFilter, SuggestedValue, "PersonName", true);
                        ASBuyer.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASBuyer.AutoSuggestVM.IsFreeTextAllowed = true;

                        BillingAddressCollection = CollectionViewSource.GetDefaultView(MC.PartysSoldToAddresses);
                        BillingAddressCollection.Filter = new Predicate<object>(Filter_BillingAddress);
                        StringListShipToAddress = MC.PartysSoldToAddresses.Select(x => x.Location.ToString()).ToList();

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).Location);
                        TheFilter = (o, prefix) => (((ADM_M028_D)o).Location ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_D)o).SrNo.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                        ASBillAdddress = new AutoSuggestTextViewModel<dynamic>(MC.PartysSoldToAddresses, TheFilter, SuggestedValue, "Location", true);
                        ASBillAdddress.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASBillAdddress.AutoSuggestVM.IsFreeTextAllowed = true;

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
                        else if (MC.PartysSoldToAddresses.Count == 1)
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

                            var BillingAddress = (from o in MC.PartysSoldToAddresses where o.AddType == "Billing Address" select o).ToList();
                            if (BillingAddress.Count == 0)
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
                            else if (BillingAddress.Count == 1)
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

                                MasterEntity.bill_address_id = BillingAddress[0].SrNo;
                                MasterEntity.billing_address = BillingAddress[0].Location;
                                MasterEntity.country_nm = BillingAddress[0].CntryName;
                                MasterEntity.country_code = BillingAddress[0].country_code;
                                MasterEntity.state_nm = BillingAddress[0].StatName;
                                MasterEntity.city = BillingAddress[0].City;
                                MasterEntity.address = BillingAddress[0].Add1;
                                MasterEntity.address1 = BillingAddress[0].Add2;
                                MasterEntity.pincode = BillingAddress[0].PinCode;
                            }
                            else if (BillingAddress.Count > 1)
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
                        }

                        DeliveryAddressCollection = CollectionViewSource.GetDefaultView(MC.PartysSoldToAddresses);
                        DeliveryAddressCollection.Filter = new Predicate<object>(Filter_DeliveryAddress);
                        StringListShipToAddress = MC.PartysSoldToAddresses.Select(x => x.Location.ToString()).ToList();

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).SrNo.ToString());
                        TheFilter = (o, prefix) => ((ADM_M028_D)o).SrNo.ToString().ToString().ToLower().Contains(prefix.ToLower());
                        //ASDeliveryAdddress = new AutoSuggestTextViewModel<dynamic>(MC.PartysSoldToAddresses, TheFilter, SuggestedValue, "SrNo");
                        AutoSuggestTextViewModel.AutoSuggestVM.IsEmptyValueAllowed = true;

                        PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListPopup);
                        PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                        //StringListItems = MC.ItemListPopup.Select(x => x.ItemCode).ToList();

                        //SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P_SO_ItemsList)x).ItemCode);
                        //TheFilter = (o, prefix) => (((SEL_T001_P_SO_ItemsList)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower ()) || (((SEL_T001_P_SO_ItemsList)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower ());
                        //ASItems = new AutoSuggestTextViewModel<dynamic>(MC.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                        //ASItems.AutoSuggestVM.IsEmptyValueAllowed = true;
                        //ASItems.AutoSuggestVM.IsFreeTextAllowed = true;


                    }
                }
                var msg = new NotificationMessage("SEL_T001_Quot_VM");
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
                    LoadInitialData();
                    DefaultValues();

                    var tempt_display = (from o in MC.STATUS_LIST
                                         where o.t_status == MasterEntity.t_status
                                         select o).ToList();
                    MasterEntity.t_display = tempt_display[0].t_display;

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
                            {
                                POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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
                    MasterEntity.ship_to_party = POPUPEntityObject.PartyId;
                    MasterEntity.ship_to_party_name = POPUPEntityObject.PartyNm;


                    if (MasterEntity.PartyId != MasterEntity.ship_to_party)
                    {
                        RequestParameterData = "LoadShipToPartyDetails" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + MasterEntity.ship_to_party;
                        // RequestParameterData = "LoadShipToPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.ship_to_party + "!@" + AppSessionState.client;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, RequestParameterData, "SalesQuotation", "CRM", "", 0, "");
                        MC.PartysShipToAddresses = MCTemp.PartysShipToAddresses;

                        DeliveryAddressCollection = CollectionViewSource.GetDefaultView(MC.PartysShipToAddresses);
                        DeliveryAddressCollection.Filter = new Predicate<object>(Filter_DeliveryAddress);
                        StringListShipToAddress = MC.PartysShipToAddresses.Select(x => x.SrNo.ToString()).ToList();

                        //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).Location);
                        //TheFilter = (o, prefix) => ((ADM_M028_D)o).Location.ToString().ToLower().Contains(prefix.ToLower())  || ((ADM_M028_D)o).SrNo.ToString().ToLower().Contains(prefix.ToLower()) ;
                        //ASDeliveryAdddress = new AutoSuggestTextViewModel<dynamic>(MC.PartysShipToAddresses, TheFilter, SuggestedValue, "Location");
                        //ASDeliveryAdddress.AutoSuggestVM.IsEmptyValueAllowed = true;
                        //ASDeliveryAdddress.AutoSuggestVM.IsFreeTextAllowed = true;

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
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Ship To Address Not Available For this Party");
                            showMessageService.ShowMessage();
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
                        else if (MC.PartysShipToAddresses.Count > 1)
                        {
                            MasterEntity.del_address = 0;
                            MasterEntity.delivery_address = "";
                            MasterEntity.country_nm_s = "";
                            MasterEntity.state_nm_s = "";
                            MasterEntity.city_s = "";
                            MasterEntity.address1_s = "";
                            MasterEntity.address2_s = "";
                            MasterEntity.pincode_s = "";
                            var DeliveryAddress = (from o in MC.PartysShipToAddresses where o.AddType == "Delivery Address" select o).ToList();
                            if (DeliveryAddress.Count == 0)
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
                            else if (DeliveryAddress.Count == 1)
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
                            else if (DeliveryAddress.Count > 1)
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


                        }
                    }
                    else if (MasterEntity.PartyId == MasterEntity.ship_to_party)
                    {
                        MC.PartysShipToAddresses = MC.PartysSoldToAddresses;

                        DeliveryAddressCollection = CollectionViewSource.GetDefaultView(MC.PartysShipToAddresses);
                        DeliveryAddressCollection.Filter = new Predicate<object>(Filter_DeliveryAddress);
                        StringListShipToAddress = MC.PartysShipToAddresses.Select(x => x.SrNo.ToString()).ToList();

                        //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).Location);
                        //TheFilter = (o, prefix) => ((ADM_M028_D)o).Location.ToString().ToLower().Contains(prefix.ToLower())  || ((ADM_M028_D)o).SrNo.ToString().ToLower().Contains(prefix.ToLower()) ;
                        //ASDeliveryAdddress = new AutoSuggestTextViewModel<dynamic>(MC.PartysShipToAddresses, TheFilter, SuggestedValue, "Location");
                        //ASDeliveryAdddress.AutoSuggestVM.IsEmptyValueAllowed = true;
                        //ASDeliveryAdddress.AutoSuggestVM.IsFreeTextAllowed = true;

                        var DeliveryAddress = (from o in MC.PartysSoldToAddresses where o.AddType == "Delivery Address" select o).ToList();
                        if (DeliveryAddress.Count == 0)
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
                        else if (DeliveryAddress.Count == 1)
                        {
                            MasterEntity.del_address = 0;
                            MasterEntity.delivery_address = "";
                            MasterEntity.country_nm_s = "";
                            MasterEntity.state_nm_s = "";
                            MasterEntity.city_s = "";
                            MasterEntity.address1_s = "";
                            MasterEntity.address2_s = "";
                            MasterEntity.pincode_s = "";

                            MasterEntity.del_address = DeliveryAddress[0].SrNo;
                            MasterEntity.delivery_address = DeliveryAddress[0].Location;
                            MasterEntity.country_nm_s = DeliveryAddress[0].CntryName;
                            MasterEntity.state_nm_s = DeliveryAddress[0].StatName;
                            MasterEntity.city_s = DeliveryAddress[0].City;
                            MasterEntity.address1_s = DeliveryAddress[0].Add1;
                            MasterEntity.address2_s = DeliveryAddress[0].Add2;
                            MasterEntity.pincode_s = DeliveryAddress[0].PinCode;
                        }
                        else if (MC.PartysShipToAddresses.Count > 1)
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

                    }

                }
                var msg = new NotificationMessage("SEL_T001_Quot_VM");
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
                            { POPUPEntityObject = MC.PartysContactInfo.Where(x => x.ContInfoId.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.PersonName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }

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
                    MasterEntity.mobile_no = POPUPEntityObject.PersnMobNo;
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
                            { POPUPEntityObject = MC.STATUS_LIST.Where(x => x.t_status.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_display.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
        #endregion

        #region Relay Command Actions : Sales Tab·

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
                    MasterEntity.inco_desc = POPUPEntityObject.incoterms;
                }
                else
                {
                    MasterEntity.incoterms = null;
                    MasterEntity.incoterms = null;
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
                            {
                                POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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
                    MasterEntity.referring_party = POPUPEntityObject.PartyId;
                    MasterEntity.referring_party_name = POPUPEntityObject.PartyNm;
                    MasterEntity.refferencing_party = POPUPEntityObject.PartyId;

                    //RequestParameterData = "LoadRefferingPartyDetails" + "!@" + MasterEntity.referring_party;
                    RequestParameterData = "LoadRefferingPartyDetails" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + MasterEntity.referring_party;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, RequestParameterData, "SalesQuotation", "CRM", "", 0, "");

                    MC.RefPartyContactInfo = MCTemp.RefPartyContactInfo;

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).PersonName);
                    TheFilter = (o, prefix) => ((ADM_M028_C_P)o).PersonName.ToString().ToLower().Contains(prefix.ToLower());
                    ASRefContPerson = new AutoSuggestTextViewModel<dynamic>(MC.RefPartyContactInfo, TheFilter, SuggestedValue, "ref_contact_name", true);

                    RefContactPersonCollection = CollectionViewSource.GetDefaultView(MC.RefPartyContactInfo);
                    RefContactPersonCollection.Filter = new Predicate<object>(Filter_RefContactPerson);
                    StringListContactPerson = MC.RefPartyContactInfo.Select(x => x.ContInfoId.ToString()).ToList();

                    if (MC.RefPartyContactInfo.Count == 1)
                    {
                        MasterEntity.ref_contact_name = MC.RefPartyContactInfo[0].PersonName;
                        MasterEntity.ref_party_contact = MC.RefPartyContactInfo[0].ContInfoId;
                    }
                    else if (MC.RefPartyContactInfo.Count <= 0)
                    {

                        MasterEntity.ref_contact_name = "";
                        MasterEntity.ref_party_contact = 0;
                    }

                }
                var msg = new NotificationMessage("SEL_T001_Quot_VM");
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
        private void InsertRefContactPerson(object InputValue) // Para10
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
                    MasterEntity.ref_party_contact = POPUPEntityObject.ContInfoId;
                    MasterEntity.ref_contact_name = POPUPEntityObject.PersonName;


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
                            { POPUPEntityObject = SalesOrganisationList.Where(x => x.so_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.sales_org = POPUPEntityObject.sales_org;
                    MasterEntity.comp_code = POPUPEntityObject.comp_code;

                    //Load Sales Organization Wise Sales group                              
                    var SalesOrgWiseSalesGroup = (from o in SalesGroupList
                                                  where o.so_code == MasterEntity.so_code
                                                  select o).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_H_P)x).sg_code);
                    TheFilter = (o, prefix) => (((ADM_M001_H_P)o).sg_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M001_H_P)o).sg_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASSalesGroup = new AutoSuggestTextViewModel<dynamic>(SalesOrgWiseSalesGroup, TheFilter, SuggestedValue, "sg_code", true);

                    //Set Default values if count is 1   
                    if (SalesOrgWiseSalesGroup != null && SalesOrgWiseSalesGroup.Count == 1)
                    {
                        MasterEntity.sg_code = SalesOrgWiseSalesGroup[0].sg_code;
                        MasterEntity.sg_name = SalesOrgWiseSalesGroup[0].sg_name;
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
                            { POPUPEntityObject = SalesGroupList.Where(x => x.sg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.sg_name = POPUPEntityObject.sg_name;
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
        private void InsertTR_ModeMaster(object InputValue)
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
        private void InsertTransporterMaster(object InputValue, bool OverrideValue)
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
                            { POPUPEntityObject = MC.Transporters.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.transporter_name = POPUPEntityObject.PartyNm;
                    MasterEntity.tr_party = POPUPEntityObject.PartyId;
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
        #endregion

        #region Relay Command Actions : Item Details Tab·

        private async void InsertItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    var LineId = ItemsEntity.Count + 1;
                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                    {
                        ItemsEntity.Add(new SEL_T001_A()
                        {
                            id = 0,
                            line_id = LineId,
                            ItemCode = POPUPEntityObject.ItemCode,
                            Description = POPUPEntityObject.ItemName,
                            active = true,
                            para1 = POPUPEntityObject.ink,
                            para5 = POPUPEntityObject.ild,
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
                            para6 = POPUPEntityObject.tipshape,
                            para3 = "A",
                            SubCatCode = POPUPEntityObject.SubCatCode,
                            StockUnt = POPUPEntityObject.StockUnt,
                            para18 = POPUPEntityObject.wire_type,
                            para19 = POPUPEntityObject.wire_size.ToString(),
                            para20 = POPUPEntityObject.ball_dia.ToString(),
                            para2 = POPUPEntityObject.ball_type,
                            para8 = Convert.ToDecimal(POPUPEntityObject.total_len),
                            ship_to_Party = MasterEntity.ship_to_party,
                            ship_to_add = MasterEntity.del_address,
                            buss_place = MasterEntity.buss_place,
                            t_status = MasterEntity.t_status,
                            t_display = MasterEntity.t_display,
                            price_qty = String.IsNullOrEmpty(POPUPEntityObject.Rate_Catlog.ToString()) ? POPUPEntityObject.rate : POPUPEntityObject.Rate_Catlog,
                            qty_price = 1,
                            price_qty_uom = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM,
                            weight_unit = POPUPEntityObject.weight_unit,
                            volume_unit = POPUPEntityObject.volume_unit
                        });
                        MasterEntity.weight_unit = POPUPEntityObject.weight_unit;
                        MasterEntity.volume_unit = POPUPEntityObject.volume_unit;
                    }
                    else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            if (ItemsEntity[dgSelectedIndexItem].line_id == 0)
                            {
                                ItemsEntity[dgSelectedIndexItem].line_id = ItemsEntity.Count;
                            }
                            ItemsEntity[dgSelectedIndexItem].ItemCode = POPUPEntityObject.ItemCode;
                            ItemsEntity[dgSelectedIndexItem].Description = POPUPEntityObject.ItemName;
                            ItemsEntity[dgSelectedIndexItem].active = true;
                            ItemsEntity[dgSelectedIndexItem].para1 = POPUPEntityObject.ink;
                            ItemsEntity[dgSelectedIndexItem].para5 = POPUPEntityObject.ild;
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
                            ItemsEntity[dgSelectedIndexItem].para6 = POPUPEntityObject.tipshape;
                            ItemsEntity[dgSelectedIndexItem].para3 = "A";
                            ItemsEntity[dgSelectedIndexItem].SubCatCode = POPUPEntityObject.SubCatCode;
                            ItemsEntity[dgSelectedIndexItem].StockUnt = POPUPEntityObject.StockUnt;
                            ItemsEntity[dgSelectedIndexItem].t_status = "001";//"Draft";
                            ItemsEntity[dgSelectedIndexItem].para18 = POPUPEntityObject.wire_type;
                            ItemsEntity[dgSelectedIndexItem].para19 = POPUPEntityObject.wire_size.ToString();
                            ItemsEntity[dgSelectedIndexItem].para20 = POPUPEntityObject.ball_dia.ToString();
                            ItemsEntity[dgSelectedIndexItem].para2 = POPUPEntityObject.ball_type;
                            ItemsEntity[dgSelectedIndexItem].para8 = Convert.ToDecimal(POPUPEntityObject.total_len);
                            ItemsEntity[dgSelectedIndexItem].weight_unit = POPUPEntityObject.weight_unit;
                            ItemsEntity[dgSelectedIndexItem].volume_unit = POPUPEntityObject.volume_unit;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].ItemCode != POPUPEntityObject.ItemCode)
                        {
                            ItemsEntity[dgSelectedIndexItem].ItemCode = "";
                            ItemsEntity[dgSelectedIndexItem].Description = "";
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
                            PreviousUnitCode = ItemsEntity[dgSelectedIndexItem].unit_code;
                            ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                            NewUnitCode = ItemsEntity[dgSelectedIndexItem].unit_code;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                        {
                            PreviousUnitCode = ItemsEntity[dgSelectedIndexItem].unit_code;
                            ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                            NewUnitCode = ItemsEntity[dgSelectedIndexItem].unit_code;
                            PriceComputation(PreviousUnitCode, NewUnitCode, "QtyUnit");
                        }
                    }
                    unitconversion();
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
        private void InsertUOMPriceQty(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                            ItemsEntity[dgSelectedIndexItem].price_qty_uom = POPUPEntityObject.unit_code;
                            PriceComputation(ItemsEntity[dgSelectedIndexItem].price_qty_uom, POPUPEntityObject.unit_code, "PriceUnit");
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].price_qty_uom != POPUPEntityObject.unit_code)
                        {
                            ItemsEntity[dgSelectedIndexItem].price_qty_uom = POPUPEntityObject.unit_code;
                            PriceComputation(ItemsEntity[dgSelectedIndexItem].price_qty_uom, POPUPEntityObject.unit_code, "PriceUnit");
                        }
                    }
                    //unitconversion();
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
        private void CheckPrice(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {

            try
            {
                unit_price = Convert.ToDecimal(InputValue);
                string Request = ItemsEntity[dgSelectedIndexItem].ItemCode;
                SEL_T001_P_SO_ItemsList POPUPEntityObject = null;
                POPUPEntityObject = MC.ItemListPopup.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                if (POPUPEntityObject.higher_limit != null && POPUPEntityObject.lower_limit != null && POPUPEntityObject.higher_limit != 0 && POPUPEntityObject.lower_limit != 0)
                {
                    if (unit_price > POPUPEntityObject.higher_limit || unit_price < POPUPEntityObject.lower_limit)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Unit Price Exceeds than Catlog Price ...");
                        showMessageService.ShowMessage();
                        ItemsEntity[dgSelectedIndexItem].alert1 = showMessageService.Text;
                    }
                    else
                    {
                        ItemsEntity[dgSelectedIndexItem].alert1 = null;
                    }
                }
            }
            catch { }
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
        private async void FilterItemSalesData(object InputValue)
        {
            try
            {

                SEL_T001_A ItemsEntityObject = null;

                if (((IEnumerable)InputValue).Cast<SEL_T001_A>().Count() > 0)
                {
                    ItemsEntityObject = ((IEnumerable)InputValue).Cast<SEL_T001_A>().ToList()[0];
                    SalesUnitPriceCollection.Clear();
                    SalesQFRCollection.Clear();
                    SalesDispatchCollection.Clear();
                    SalesProjDispatchCollection.Clear();

                    string Request1 = "GetItemPrice" + "!@" + ItemsEntityObject.ItemCode + "!@" + MasterEntity.PartyId + "!@" + MasterEntity.sono + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat;
                    MCTemp = await repository_MCTemp.GetDataWithReturnDomainObjectASynchronus<MultipleContext_SEL_T001>(MCTemp, Request1, "SalesOrderMaster", "CRM", "", 0, "GetItemPriceData");


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
        private void OpenDocumentViewer(object InputValue)
        {
            WebServiceRepository<MultipleContext_Attachments> repository_MCAttachments = new WebServiceRepository<MultipleContext_Attachments>();
            List<COM_T003> Attachments = new List<COM_T003>();
            SEL_T001_A EntityObjectParameter = new SEL_T001_A();
            MultipleContext_Attachments MCAttachments = new MultipleContext_Attachments();
            try
            {
                if (InputValue != null)
                {
                    EntityObjectParameter = ((IEnumerable)InputValue).Cast<SEL_T001_A>().ToList()[0];
                }
                //string Request = "GetAllFiles" + "!@" + EntityObjectParameter.ItemCode;
                string Request = "GetAllFiles" + "!@" + AppSessionState.client + "!@" + (EntityObjectParameter.comp_code ?? AppSessionState.comp_code) + "!@" + (EntityObjectParameter.location_Id ?? AppSessionState.location_Id) + "!@" + (doc_cat_vm ?? "") + "!@" + doc_cat_vm + "!@" + EntityObjectParameter.sono + "!@" + EntityObjectParameter.id.ToString();
                //MCAttachments = repository_MCAttachments.GetData<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Reflection.BusinessLogic.ReflectionFileHandlingServices");
                MCAttachments = repository_MCAttachments.GetDataWithReturnDomainObject<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                if (!string.IsNullOrEmpty(EntityObjectParameter.ItemCode))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.sono.Replace("/", "--"), Row_ID = EntityObjectParameter.id.ToString(), DocumentList = MCAttachments.Attachments, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
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

        #region Relay Command Actions : Item Details Tab => 2nd DataGrid·
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
                            { POPUPEntityObject = MC.GLCodes.Where(x => x.gl_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                        { POPUPEntityObject = MC.Currencys.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
        private void DeleteTax(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (TotalDocumentTaxes.Count > i)
                {

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
        #endregion
        #endregion

        #region Relay Command Actions : Delivery Schedule Tab·

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
        private void DeleteDataGridRow_ItemSchedule(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemScheduleEntity.Count > i)
                {
                    ItemScheduleEntity.RemoveAt(i);
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
        private void CollectionChanged(IList DataList)
        {
            string[] TempSkuList = new string[100];
            List<string> TempParaValueList = new List<string>();
            IList list = DataList as IList;
            try
            {
                if (ItemsEntity[dgSelectedIndexItem].id == 0 && ItemsEntity.Count > 0 && dgSelectedIndexItem < ItemsEntity.Count && dgSelectedIndexItem != -1)
                {
                    List<SEL_T001_A> SelectedRowlist = list.Cast<SEL_T001_A>().ToList();

                    if (SelectedRowlist[0].StockUnt == true)
                    {
                        var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();

                        ParameterTemp = paramlist.ToList();

                        if (paramlist.Count > 0 && ItemsEntity[dgSelectedIndexItem].sku != "" && ItemsEntity[dgSelectedIndexItem].sku != null)
                        {
                            TempSkuList = ItemsEntity[dgSelectedIndexItem].sku.Split('/');

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
                                    o.dgselectedindex = dgSelectedIndexItem;
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
                else if (ItemsEntity[dgSelectedIndexItem].id != 0 && ItemsEntity.Count > 0 && dgSelectedIndexItem < ItemsEntity.Count)
                {
                    List<SEL_T001_A> SelectedRowlist = list.Cast<SEL_T001_A>().ToList();

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
                    else
                    {
                        ParameterCollection = CollectionViewSource.GetDefaultView(TempParaValueList);

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
                        if (SelectedParaValueList.Count > 0 && SelectedParaValueList[0].parametervalue != null && SelectedParaValueList[0].parametervalue != "")// && SelectedParaValueCollection.dgselectedindex.contains)
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
                if (ItemsEntity[dgSelectedIndexItem].sku_desc == null || ItemsEntity[dgSelectedIndexItem].sku_desc == "")
                {
                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if ((ItemsEntity[dgSelectedIndexItem].sku_desc == "" || ItemsEntity[dgSelectedIndexItem].sku_desc == null) && SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                        {
                            ItemsEntity[dgSelectedIndexItem].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                        else if (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
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
                        if ((ItemsEntity[dgSelectedIndexItem].sku_desc == "" || ItemsEntity[dgSelectedIndexItem].sku_desc == null) && SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                        {
                            ItemsEntity[dgSelectedIndexItem].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                        else if (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                        {
                            ItemsEntity[dgSelectedIndexItem].sku_desc = ItemsEntity[dgSelectedIndexItem].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
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
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();


            }

        }
        #endregion

        #region Relay Command Actions : Terms And Conditions Tab·

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
                        {
                            POPUPEntityObject = MC.TermsConditionCollection.Where(x => x.con_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.long_text.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
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
        private void InsertTermsScope(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M002_B POPUPEntityObject = null;
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
                        {
                            POPUPEntityObject = MC.ScopeList.Where(x => x.CatCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.cat_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002_B>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = TermsConditionEntity.Where(X => X.CatCode == POPUPEntityObject.CatCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = TermsConditionEntity.IndexOf(TermsConditionEntity.Where(X => X.CatCode == POPUPEntityObject.CatCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && TermsConditionEntity.Count == dgSelectedIndexTerms)
                    {
                        TermsConditionEntity.Add(new SEL_T001_E()
                        {
                            CatCode = POPUPEntityObject.CatCode,
                            //CatCode = POPUPEntityObject.cat_name,
                        });
                    }
                    else if (dgSelectedIndexTerms >= 0 && TermsConditionEntity.Count > dgSelectedIndexTerms) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (TermsConditionEntity[dgSelectedIndexTerms].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            TermsConditionEntity[dgSelectedIndexTerms].CatCode = POPUPEntityObject.CatCode;
                        }
                        else if (TermsConditionEntity[dgSelectedIndexTerms].CatCode != POPUPEntityObject.CatCode)
                        {
                            TermsConditionEntity[dgSelectedIndexTerms].CatCode = "";
                            //TermsConditionEntity[dgSelectedIndexTerms].long_text = "";
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
        #endregion

        #region Relay Command Actions : Filters for View Tab·

        private void FilterViewByPlant(object InputValue)
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
                    MasterEntity.fltr_location_Id = POPUPEntityObject.location_Id;
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
                        { POPUPEntityObject = MC.STATUS_LIST.Where(x => x.t_display.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.fltr_t_status = POPUPEntityObject.t_status;
                    MasterEntity.fltr_t_display = POPUPEntityObject.t_display;
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
        private void InsertFltrSeller(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M024_P POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
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
                    if (((IEnumerable)InputValue).Cast<ADM_M024_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.Fltr_SalesPersonID = POPUPEntityObject.EmpId;
                    MasterEntity.Fltr_SalesPersonNM = POPUPEntityObject.EmpName;
                }
            }
            catch (Exception Ex) { }
        }
        private void LoadBackFlipData(object InputValue)
        {
            try
            {

                string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + (RequestPara.location_Id ?? AppSessionState.location_Id) + "!@" + doc_cat_vm + "!@" + (RequestPara.doc_type ?? doc_cat_vm) + "!@!@" + AppSessionState.UserID + "!@" + (RequestPara.EmpId ?? AppSessionState.EmpId) + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + (Utilities.NullIf(RequestPara.PartyId) ?? "") + "!@!@" + RequestPara.active ?? "" + "!@" + (Utilities.NullIf(RequestPara.t_status) ?? "") + "!@" + RequestPara.FromDate.ToString() + "!@" + RequestPara.ToDate.ToString();
                //string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + RequestPara.location_Id + "!@" + (RequestPara.doc_cat ?? "QN") + "!@" + (Utilities.NullIf(RequestPara.doc_type_user) ?? "") + "!@" + (Utilities.NullIf(RequestPara.t_status) ?? "") + "!@" + RequestPara.active + "!@" + (Utilities.NullIf(RequestPara.EmpId) ?? AppSessionState.EmpId) + "!@" + Utilities.NullIf(RequestPara.PartyId) + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + Convert.ToDateTime(RequestPara.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(RequestPara.ToDate).ToString("MM/dd/yyyy");
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, Request, "SalesQuotation", "CRM", "LoadAll", 0, "");

                FlipGridData = MCTemp.DocumentDataFlipGrid.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex) { }

        }

        #endregion

        #region Relay Command Actions : Other.
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

        private void InsertDocTypeBf(object InputValue)
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
                if (POPUPEntityObject != null) // Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.doc_type = POPUPEntityObject.doc_type;
                    MasterEntity.doc_type_user = POPUPEntityObject.doc_type_user;
                    MasterEntity.doc_desc = POPUPEntityObject.doc_desc;
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
                        if (ItemsEntity.Count > 0 && isNewRecord == false)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Party Change Information";
                            showMessageService.Text = String.Format("Can not change Document Type '{0}' in edit mode", this.Title);
                            showMessageService.ShowMessage();
                        }
                    }
                    else if (isNewRecord == true && ItemsEntity.Count > 0)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Party Selection";
                        showMessageService.Text = String.Format("If You Change The Document Type some data Will be removed'{0}'", this.Title);
                        if (showMessageService.ShowMessage() == DialogResult.Ok)
                        {
                            MasterEntity.doc_cat = POPUPEntityObject.doc_cat;
                            MasterEntity.doc_type = POPUPEntityObject.doc_type;
                            MasterEntity.doc_type_user = POPUPEntityObject.doc_type_user;
                            MasterEntity.doc_desc = POPUPEntityObject.doc_desc;
                            this.doc_cat_vm = POPUPEntityObject.doc_cat;
                        }
                    }
                    else
                    {
                        MasterEntity.doc_cat = POPUPEntityObject.doc_cat;
                        MasterEntity.doc_type = POPUPEntityObject.doc_type;
                        MasterEntity.doc_type_user = POPUPEntityObject.doc_type_user;
                        MasterEntity.doc_desc = POPUPEntityObject.doc_desc;
                        this.doc_cat_vm = POPUPEntityObject.doc_cat;
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
        // Pending assignment of LoadSourceDocument() Method.
        private void LoadSourceDocument()
        {
            // Load another previous record from database for provided Document number and generate new document.
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
                    MasterEntity.transporter_name = POPUPEntityObject.PartyNm;
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
                    MasterEntity.location = POPUPEntityObject.Location;
                    MasterEntity.country_nm = POPUPEntityObject.CntryName;      //add by sachin magar
                    MasterEntity.country_code = POPUPEntityObject.country_code;
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
                            { POPUPEntityObject = MC.GLCodes.Where(x => x.gl_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.gl_code = POPUPEntityObject.gl_code;
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
                    MasterEntity.symbol = POPUPEntityObject.symbol;
                    if (MasterEntity.curr_code == Currency)
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

        private void unitconversion()
        {

            var CurrantUnitCF = (from o in UnitConversionList where (o.unit_code == PreviousUnitCode) select o).ToList();
            var NewUnitCF = (from o in UnitConversionList where (o.unit_code == NewUnitCode) select o).ToList();
            if (CurrantUnitCF.Count > 0 && NewUnitCF.Count > 0)
            {
                ItemsEntity[dgSelectedIndexItem].quantity = (ItemsEntity[dgSelectedIndexItem].quantity * CurrantUnitCF[0].c_factor) / NewUnitCF[0].c_factor;
                ItemsEntity[dgSelectedIndexItem].unit_price = (ItemsEntity[dgSelectedIndexItem].unit_price / CurrantUnitCF[0].c_factor) * NewUnitCF[0].c_factor;
            }
        }
        private void PriceComputation(string PreviousUnit, string NewUnit, string Source)
        {
            try
            {
                if (ItemsEntity.Count > 0 && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < ItemsEntity.Count)
                {
                    if (ItemsEntity[dgSelectedIndexItem].qty_price > 0 && ItemsEntity[dgSelectedIndexItem].price_qty > 0 && string.IsNullOrWhiteSpace(ItemsEntity[dgSelectedIndexItem].price_qty_uom) == false)
                    {
                        if (Source == "QtyUnit")
                        {
                            var PreviousUnitCF = (from o in UnitConversionList where (o.unit_code == PreviousUnit) select o).ToList();
                            var NewUnitCF = (from o in UnitConversionList where (o.unit_code == NewUnit) select o).ToList();

                            if (PreviousUnitCF.Count > 0 && NewUnitCF.Count > 0)
                            {
                                ItemsEntity[dgSelectedIndexItem].quantity = (ItemsEntity[dgSelectedIndexItem].quantity * PreviousUnitCF[0].c_factor) / NewUnitCF[0].c_factor;
                                ItemsEntity[dgSelectedIndexItem].unit_price = (ItemsEntity[dgSelectedIndexItem].unit_price / PreviousUnitCF[0].c_factor) * NewUnitCF[0].c_factor;
                            }
                        }
                        else if (Source == "PriceUnit")
                        {
                            var PreviousUnitCF = (from o in UnitConversionList where (o.unit_code == PreviousUnit) select o).ToList();
                            var NewUnitCF = (from o in UnitConversionList where (o.unit_code == NewUnit) select o).ToList();

                            if (PreviousUnitCF.Count > 0 && NewUnitCF.Count > 0)
                            {
                                ItemsEntity[dgSelectedIndexItem].qty_price = (ItemsEntity[dgSelectedIndexItem].qty_price * PreviousUnitCF[0].c_factor) / NewUnitCF[0].c_factor;
                            }
                        }

                        decimal? UnitPrice_Qty = 0;
                        string QtyUnit = ItemsEntity[dgSelectedIndexItem].unit_code;
                        string PriceUnit = ItemsEntity[dgSelectedIndexItem].price_qty_uom;
                        var QtyUnitCF = (from o in UnitConversionList where (o.unit_code == QtyUnit) select o).ToList();
                        var PriceUnitCF = (from o in UnitConversionList where (o.unit_code == PriceUnit) select o).ToList();
                        decimal? qty = ItemsEntity[dgSelectedIndexItem].quantity;
                        decimal? qty_of_price = ItemsEntity[dgSelectedIndexItem].qty_price;
                        decimal? price_of_qty = ItemsEntity[dgSelectedIndexItem].price_qty;

                        UnitPrice_Qty = ((((qty * QtyUnitCF[0].c_factor) / PriceUnitCF[0].c_factor) / qty_of_price) * price_of_qty) / qty;
                        ItemsEntity[dgSelectedIndexItem].unit_price = decimal.Round(Convert.ToDecimal(UnitPrice_Qty), 4, MidpointRounding.AwayFromZero);
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
            EntityChangeEnable = false;
            CursorControl.SetBusyState();
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
                        Request = "LoadDocumentWithDocumentNumber" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@" + ParameterEntityObject.sono + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + ParameterEntityObject.PartyId;
                        //Request = "LoadDocumentWithDocumentNumber" + "!@" + ParameterEntityObject.sono + "!@" + ParameterEntityObject.PartyId + "!@" + ParameterEntityObject.ship_to_party;
                        isNewRecord = false;

                        RequestParameterData = "LoadSoldToPartyDetails" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + ParameterEntityObject.PartyId;
                        //RequestParameterData = "LoadSoldToPartyDetails" + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + ParameterEntityObject.PartyId;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, RequestParameterData, "SalesQuotation", "CRM", "", 0, "");

                        MC.ItemListPopup = MCTemp.ItemListPopup;
                        PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListPopup);
                        PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                        StringListItems = MC.ItemListPopup.Select(x => x.ItemCode).ToList();

                        //SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P_SO_ItemsList)x).ItemCode);
                        //TheFilter = (o, prefix) => ((SEL_T001_P_SO_ItemsList)o).ItemCode.ToString().ToLower().Contains(prefix.ToLower()) || ((SEL_T001_P_SO_ItemsList)o).ItemName.ToString().ToLower().Contains(prefix.ToLower());
                        //ASItems = new AutoSuggestTextViewModel<dynamic>(MC.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                        //ASItems.AutoSuggestVM.IsEmptyValueAllowed = true;
                        //ASItems.AutoSuggestVM.IsFreeTextAllowed = true;
                    }
                }

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, Request, "SalesQuotation", "CRM", "LoadDocumentWithDocumentNumber", 0, "");

                MC.PartysContactInfo = MCTemp.PartysContactInfo;
                MC.PartysSoldToAddresses = MCTemp.PartysSoldToAddresses;
                MC.PartysShipToAddresses = MCTemp.PartysShipToAddresses;


                if (MCTemp.ItemsEntity != null)
                {
                    ItemsEntity.Clear();
                    MasterEntity = MCTemp.MasterEntity[0];
                    PersonEmailId = MCTemp.MasterEntity[0].PersonEmailId;
                    PartyEmailId = MCTemp.MasterEntity[0].PartyEmailId;
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
                AttachmentCount = MCTemp.Attachment.Count;



                BuyerCollection = CollectionViewSource.GetDefaultView(MC.PartysContactInfo);
                BuyerCollection.Filter = new Predicate<object>(Filter_Buyer);
                StringListBuyer = MC.PartysContactInfo.Select(x => x.ContInfoId.ToString()).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).PersonName);
                TheFilter = (o, prefix) => ((ADM_M028_C_P)o).PersonName.ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M028_C_P)o).ContInfoId.ToString().ToLower().Contains(prefix.ToLower());
                ASBuyer = new AutoSuggestTextViewModel<dynamic>(MC.PartysContactInfo, TheFilter, SuggestedValue, "PersonName", true);
                ASBuyer.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASBuyer.AutoSuggestVM.IsFreeTextAllowed = true;


                BillingAddressCollection = CollectionViewSource.GetDefaultView(MC.PartysSoldToAddresses);
                BillingAddressCollection.Filter = new Predicate<object>(Filter_BillingAddress);
                StringListShipToAddress = MC.PartysSoldToAddresses.Select(x => x.SrNo.ToString()).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).SrNo.ToString());
                TheFilter = (o, prefix) => ((ADM_M028_D)o).SrNo.ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M028_D)o).SrNo.ToString().ToLower().Contains(prefix.ToLower());
                ASBillAdddress = new AutoSuggestTextViewModel<dynamic>(MC.PartysSoldToAddresses, TheFilter, SuggestedValue, "bill_address_id", true);
                ASBillAdddress.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASBillAdddress.AutoSuggestVM.IsFreeTextAllowed = true;

                DeliveryAddressCollection = CollectionViewSource.GetDefaultView(MC.PartysShipToAddresses);
                DeliveryAddressCollection.Filter = new Predicate<object>(Filter_DeliveryAddress);
                StringListShipToAddress = MC.PartysShipToAddresses.Select(x => x.SrNo.ToString()).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).SrNo.ToString());
                TheFilter = (o, prefix) => ((ADM_M028_D)o).SrNo.ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M028_D)o).SrNo.ToString().ToLower().Contains(prefix.ToLower());
                ASDeliveryAdddress = new AutoSuggestTextViewModel<dynamic>(MC.PartysShipToAddresses, TheFilter, SuggestedValue, "del_address", true);
                ASDeliveryAdddress.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDeliveryAdddress.AutoSuggestVM.IsFreeTextAllowed = true;

                SetPopupSuggestionDataAfterLoad();
                MasterEntity.ts_code = ts_code_vm;
                Computation(true, dgSelectedIndexItem);

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
        private void LoadDocumentByReferenceDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                EntityChangeEnable = false;
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
                        { Request = "LoadDocumentWithReferenceDocumentNumberQT" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@!@!@!@" + ParametersStringValue; }
                        catch (Exception ex) { }
                    }
                }
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, Request, "SalesQuotation", "CRM", "LoadDocumentWithReferenceDocumentNumberQT", 0, "");
                if (MCTemp.ItemsEntity != null)
                {
                    ItemsEntity.Clear();
                    if (MCTemp.MasterEntity.Count > 0)
                    {
                        MasterEntity = MCTemp.MasterEntity[0];
                    }
                    if (MCTemp.MasterEntity[0].mail_id != "" || MCTemp.MasterEntity[0].mail_id != null)
                    {
                        PersonEmailId = MCTemp.MasterEntity[0].mail_id;
                    }
                    if (MCTemp.MasterEntity[0].PartyEmailId != "" || MCTemp.MasterEntity[0].PartyEmailId != null)
                    {
                        PartyEmailId = MCTemp.MasterEntity[0].PartyEmailId;
                    }



                    ItemsEntity = MCTemp.ItemsEntity;


                }
                else
                {
                    MCTemp.ItemsEntity = new ObservableCollection<SEL_T001_A>();
                }
                //int LineId = 1;
                //foreach (var item in ItemsEntity)
                //{
                //    item.line_id = LineId;
                //    LineId++;
                //}
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
                    MasterEntity.doc_cat = "QN";
                    MasterEntity.doc_type = "QN";
                    MasterEntity.doc_type_user = "QN";
                    MasterEntity.doc_type_user = "QN";
                    MasterEntity.doc_desc = "Sales Quotation";
                    MasterEntity.sono = "";
                    MasterEntity.sodate = DateTime.Now;
                    MasterEntity.add_by = AppSessionState.UserID;
                    MasterEntity.editby = AppSessionState.UserID;
                    MasterEntity.active = true;
                    MasterEntity.t_status = "001";//"Draft";
                    MasterEntity.shipped = false;
                    MasterEntity.version = "v1.0";
                    ScheduleEntity.t_status = "001"; //"Draft";
                    ScheduleEntity.sch_date = DateTime.Now;
                    ScheduleEntity.active = true;
                    ScheduleEntity.add_by = AppSessionState.UserID;
                    ScheduleEntity.id = 0;
                    isNewRecord = true;
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
        private void SetPopupSuggestionDataAfterLoad()
        {
            ASBuyer.AutoSuggestVM.Suggestion = MC.PartysContactInfo.Find(x => x.PersonName == MasterEntity.buyer_name);
            ASBillAdddress.AutoSuggestVM.Suggestion = MC.PartysSoldToAddresses.Find(x => x.SrNo == MasterEntity.bill_address_id);
            ASDeliveryAdddress.AutoSuggestVM.Suggestion = MC.PartysShipToAddresses.Find(x => x.SrNo == MasterEntity.del_address);
            ASCountry.AutoSuggestVM.Suggestion = MC.CountryMaster.Find(x => x.CntryName == MasterEntity.country_nm);
            ASSalesPerson.AutoSuggestVM.Suggestion = MC.Sellers.Find(x => x.EmpId == MasterEntity.sales_person_cd);
            ASCurrency.AutoSuggestVM.Suggestion = MC.Currencys.Find(x => x.curr_code == MasterEntity.curr_code);

            ASIncoTerms.AutoSuggestVM.Suggestion = MC.Incoterms.Find(x => x.incoterms == MasterEntity.incoterms);
            ASPayTerms.AutoSuggestVM.Suggestion = MC.PayTerms.Find(x => x.p_term_code == MasterEntity.p_term_code);
            ASRefferingParty.AutoSuggestVM.Suggestion = MC.ServiceProviders.Find(x => x.PartyId == MasterEntity.referring_party);
            ASOurBank.AutoSuggestVM.Suggestion = MC.Banks.Find(x => x.bank_code == MasterEntity.bank_code);
            ASNastroBank.AutoSuggestVM.Suggestion = MC.Banks.Find(x => x.bank_code == MasterEntity.nastro_bank_cd);

            LocationList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
            ASLocationId.AutoSuggestVM.Suggestion = LocationList.Find(x => x.location_Id == MasterEntity.location_Id);

            var LocList = (from o in LocationList where o.comp_code == AppSessionState.comp_code select o).ToList();
            ASLocation.AutoSuggestVM.Suggestion = LocList.Find(x => x.location_Id == MasterEntity.location_Id);

            ASSalesGroup.AutoSuggestVM.Suggestion = MC.SalesGroup.Find(x => x.sg_code == MasterEntity.sg_code);
            ASSalesOrg.AutoSuggestVM.Suggestion = MC.SalesOrg.Find(x => x.so_code == MasterEntity.so_code);

            refdoctempa = (from o in MC.Sales_Order_Reference where o.doc_cat == "SN" select o).ToList();
            ASRef_doc_no.AutoSuggestVM.Suggestion = refdoctempa.Find(x => x.sono == MasterEntity.ref_doc_no);

        }
        private void InsertManualTaxChangedCommand(object InputValue)
        {
            Computation(true, dgSelectedIndexItem);
        }
        private void ActiveInactiveTax(bool select)
        {
            Computation(true, dgSelectedIndexItem);
        }
        //private void InsertCompany(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ADM_M002 POPUPEntityObject = null;
        //        #region Command Parameter Read Section
        //        try
        //        {
        //            if (InputValue.GetType() == typeof(string) && InputValue != null)
        //            {
        //                Request = InputValue.ToString();
        //                if (Request.Length > 0)
        //                {
        //                    try
        //                    { POPUPEntityObject = CompanyList.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                    catch (Exception ex) { }
        //                }
        //            }
        //            else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M002>().Count() > 0)
        //            {
        //                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002>().ToList()[0];
        //            }
        //        }
        //        catch (Exception ex) { }

        //        #endregion
        //        if (POPUPEntityObject != null)
        //        {
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;

        //            //Filter Company Wise Sales Org
        //            var CompanyWiseSalesOrg = (from o in SalesOrganisationList
        //                                       where o.comp_code == MasterEntity.comp_code
        //                                       select o).ToList();

        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).so_code);
        //            TheFilter = (o, prefix) => (((ADM_M001_A_P)o).so_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M001_A_P)o).sales_org ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //            ASSalesOrg = new AutoSuggestTextViewModel<dynamic>(CompanyWiseSalesOrg, TheFilter, SuggestedValue, "so_code", true);

        //            //Set Default values if count is 1                 
        //            if (CompanyWiseSalesOrg != null && CompanyWiseSalesOrg.Count == 1)
        //            {
        //                MasterEntity.so_code = CompanyWiseSalesOrg[0].so_code;
        //                MasterEntity.sales_org = CompanyWiseSalesOrg[0].sales_org;
        //                var SalesOrgWiseSalesGroup = (from o in SalesGroupList
        //                                              where o.so_code == MasterEntity.so_code
        //                                              select o).ToList();

        //                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_H_P)x).sg_code);
        //                TheFilter = (o, prefix) => (((ADM_M001_H_P)o).sg_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M001_H_P)o).sg_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //                ASSalesGroup = new AutoSuggestTextViewModel<dynamic>(SalesOrgWiseSalesGroup, TheFilter, SuggestedValue, "sg_code", true);

        //                if (SalesOrgWiseSalesGroup != null && SalesOrgWiseSalesGroup.Count == 1)
        //                {
        //                    MasterEntity.sg_code = SalesOrgWiseSalesGroup[0].sg_code;
        //                    MasterEntity.sg_name = SalesOrgWiseSalesGroup[0].sg_name;
        //                }
        //            }

        //            //Filter Company Wise Location
        //            var CompanyWiseLocation = (from o in LocationList
        //                                       where o.comp_code == MasterEntity.comp_code
        //                                       select o).ToList();
        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
        //            TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //            ASLocationId = new AutoSuggestTextViewModel<dynamic>(CompanyWiseLocation, TheFilter, SuggestedValue, "location_Id", true);

        //            //Set Default values if  count is 1
        //            if (CompanyWiseLocation != null && CompanyWiseLocation.Count == 1)
        //            {
        //                MasterEntity.location_Id = CompanyWiseLocation[0].location_Id;
        //                MasterEntity.comp_code = CompanyWiseLocation[0].comp_code;
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
        //private void InsertLocationId(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ADM_M003 POPUPEntityObject = null;
        //        #region Command Parameter Read Section
        //        try
        //        {
        //            if (InputValue.GetType() == typeof(string) && InputValue != null)
        //            {
        //                Request = InputValue.ToString();
        //                if (Request.Length > 0)
        //                {
        //                    try
        //                    { POPUPEntityObject = LocationList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                    catch (Exception ex) { }
        //                }
        //            }
        //            else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M003>().Count() > 0)
        //            {
        //                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
        //            }
        //        }
        //        catch (Exception ex) { }

        //        #endregion
        //        if (POPUPEntityObject != null)
        //        {
        //            MasterEntity.location_Id = POPUPEntityObject.location_Id;
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;
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

        #endregion
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
                    MasterEntity.editby = AppSessionState.UserID;
                    MasterEntity.XmlDataDocument_SEL_T001_A = obj.ObjectToXML(ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_B = obj.ObjectToXML(TotalDocumentTaxes);
                    //ScheduleEntity.PartyId = MasterEntity.PartyId; // cannot assign in default values method because Party not assign at that moment.
                    MasterEntity.XmlDataDocument_SEL_T002 = obj.ObjectToXML(ScheduleEntity);
                    MasterEntity.XmlDataDocument_SEL_T002_A = obj.ObjectToXML(ItemScheduleEntity);
                    MasterEntity.XmlDataDocument_SEL_T001_E = obj.ObjectToXML(TermsConditionEntity);

                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<SEL_T001>(MasterEntity, "SalesQuotation", "CRM");
                        if (MasterEntity.sono != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnInsert") >= 0)
                        {
                            NotifyMessage("OnInsert", "Created");
                        }
                        if (MasterEntity.sono != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnApproval") >= 0)
                        {
                            NotifyMessage("OnApproval", "Created");
                        }
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<SEL_T001>(MasterEntity, "SalesQuotation", "CRM");
                        //MasterEntity = repository.SaveWithReturnDomainObject<SEL_T001>(MasterEntity, "SalesOrderMaster", "CRM");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.sono != null || MasterEntity.sono != "" && MasterEntity.active == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record saved Successfully ........");
                        showMessageService.ShowMessage();
                    }

                    isNewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 

                    MasterEntity.Fltr_FrmDate = DateTime.Now.AddMonths(-1);
                    MasterEntity.Fltr_ToDate = DateTime.Now;
                    MasterEntity.Fltr_active = true;
                    MasterEntity.Fltr_doc_type = "QN";
                    Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
            isNewRecord = true;
            MasterEntity = new SEL_T001();
            MasterEntity.ValidateAsync().Wait();
            ItemsEntity = new ObservableCollection<SEL_T001_A>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
            TermsConditionEntity = new ObservableCollection<SEL_T001_E>();
            ScheduleEntity = new SEL_T002();
            ItemScheduleEntity = new ObservableCollection<SEL_T002_A>();
            DefaultValues();

            var tempt_display = (from o in MC.STATUS_LIST
                                 where o.t_status == MasterEntity.t_status
                                 select o).ToList();
            MasterEntity.t_display = tempt_display[0].t_display;

            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>

        protected override void OnPrintAction(InquiryActionResult<SEL_T001> result)
        {
            CursorControl.SetBusyState();
            EntityChangeEnable = false;
            try
            {
                string Request = "SO_Report" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.sono;
                //string Request = "QN_Report" + "!@" + MasterEntity.sono;
                MasterEntity.doc_desc = "SALES QUOTATION";

                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MC, Request, "SalesQuotation", "CRM", "LoadAll", 0, "");

                object[] objDataSource = new object[7];
                string[] objDataSourceName = new string[7];


                objDataSource[0] = MCTemp.MasterEntity;
                objDataSource[1] = MCTemp.ItemsEntity;
                objDataSource[2] = MCTemp.TaxEntity; // TotalDocumentTaxes;


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
                string ReportName = "";
                var SystemDocumentObject = (from o in MC.DocumentTypes where o.doc_cat == MasterEntity.doc_cat select o).ToList();
                if (PrePrinted == true)
                {
                    ReportName = SystemDocumentObject[0].report_name.Split(',')[1]; ;
                }
                else
                {
                    ReportName = SystemDocumentObject[0].report_name.Split(',')[0];
                }
                string ReportDisplayName = MasterEntity.comp_code + "_" + MasterEntity.party_name + "_" + MasterEntity.sono + "_" + MasterEntity.sodate.Value.ToShortDateString();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, getParametersList(), ReportDisplayName); //QuotationMurRpt.rdlc
                EntityChangeEnable = true;
            }
            catch (Exception ex)
            {
            }
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


                if (!string.IsNullOrWhiteSpace(MasterEntity.sono))
                {
                    string Request = "SO_Report" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.sono;
                    //string Request = "QN_Report" + "!@" + MasterEntity.sono;
                    MasterEntity.doc_desc = "SALES QUOTATION";

                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MC, Request, "SalesQuotation", "CRM", "LoadAll", 0, "");

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
                        Cc = ToEmailId;
                        Bcc = AppSessionState.EmpEmailId;
                        ReportName = SystemDocumentObject[0].report_name.Split(',')[0];
                        DisplaytName = MasterEntity.doc_desc + "_" + MasterEntity.sono.Replace(@"/", "-").Replace(@"\", "-") + "_" + MasterEntity.sodate.Value.Date.ToShortDateString().Replace(@"/", string.Empty).Replace(@"\", string.Empty);
                        MessageData = "<h3>Commercial Document for RFQ!</h3><p>Dear Sir!</p><p>Please find attached herewith commercial document for Quotation as per your requirements. </p><p>-" + AppSessionState.CompanyName + "</p>";

                        ReportManager.Mail(To, Cc, Bcc, objDataSource, objDataSourceName, null, "\\CRM\\" + ReportName, DisplaytName, "Quotation Prepared against RFQ By " + AppSessionState.CompanyName, MessageData, "", ".pdf");
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Mail Send Successfully ........");
                        showMessageService.ShowMessage();
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Mail Cannot Be Send ........");
                        showMessageService.ShowMessage();
                    }

                }
            }
            catch (Exception ex) { }
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
            if (EntityChangeEnable == true)
            {
                if (e.PropertyName == "qty" || e.PropertyName == "unit_price" || e.PropertyName == "tax_id" || e.PropertyName == "active" || e.PropertyName == "discount" || e.PropertyName == "ItemCode" || e.PropertyName == "price_qty" || e.PropertyName == "qty_price" || e.PropertyName == "price_qty_uom")
                {
                    PriceComputation(null, null, null);
                    Computation(true, dgSelectedIndexItem);
                }
                if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
                }
            }
        }

        private void CollectionChangedNotifyForTotalTaxes(object sender, NotifyCollectionChangedEventArgs e)
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
                    { item.manual = "Auto"; item.con_type = "TAXC"; }
                    else { item.manual = "Manual"; item.sequence = 100; }
                    if (item.tax_name == null || item.tax_name.Trim() == "")
                    { item.tax_name = "CASH"; }
                    item.active = true;
                    item.location_Id = AppSessionState.location_Id;
                    item.comp_code = AppSessionState.comp_code;
                    item.PropertyChanged += EntityViewModelPropertyChanged;
                    item.symbol = MasterEntity.symbol;
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
        private void CollectionChangedNotifyForTerms(object sender, NotifyCollectionChangedEventArgs e)
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
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
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
                foreach (SEL_T001_A item in e.NewItems)
                {
                    //Adde items Schedules Default Values from Items Entity
                    item.symbol = MasterEntity.symbol;
                    item.active = true;
                    item.add_by = AppSessionState.UserID;
                    item.comp_code = AppSessionState.comp_code;
                    item.location_Id = AppSessionState.location_Id;
                    item.editby = AppSessionState.UserID;
                    //item.line_id = 0;
                    item.t_status = "001";//"Draft";


                }

                foreach (SEL_T001_A item in e.NewItems)
                {
                    //Added items
                    item.PropertyChanged += EntityViewModelPropertyChanged;
                }
                if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
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
                SEL_T001_A temp = (SEL_T001_A)e.OldItems[0];
                foreach (var itemToRemove in ItemScheduleEntity.Where(x => (x.ItemCode == temp.ItemCode && x.id == 0 && (x.sku?.ToString() ?? "") == (temp.sku?.ToString() ?? ""))).ToList())
                {
                    ItemScheduleEntity.Remove(itemToRemove);
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
                            Computation(true, dgSelectedIndexItem);
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
                    this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Move)
            {
            }
        }
        void Schedule_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "qty")
            {
                #region Check Schedule Qty Total should not exceed PO Qty.
                //Check Schedule Qty Total should not exceed PO Qty.
                decimal? TotalQtyOfScheduleForItem = 0;
                TotalQtyOfScheduleForItem = ItemScheduleEntity.Where(item => item.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && (item.sku?.ToString() ?? "") == (ItemsEntity[dgSelectedIndexItem].sku?.ToString() ?? "")).Sum(item => item.sch_qty);
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
                        if (ItemsEntity[dgSelectedIndexItem].ItemCode == null || ItemsEntity[dgSelectedIndexItem].ItemCode == "")
                        {
                            ItemsEntity[dgSelectedIndexItem].ItemCode = "";
                            item.ItemCode = "";
                            item.unit_code = "";
                            item.sku = ItemsEntity[dgSelectedIndexItem].sku;
                            item.sono = ItemsEntity[dgSelectedIndexItem].sono;
                            item.sch_qty = 0;
                            item.t_status = MasterEntity.t_status;
                            item.active = true;
                            item.editby = AppSessionState.UserID;
                            item.add_by = AppSessionState.UserID;
                            item.location_Id = AppSessionState.location_Id;
                            item.comp_code = AppSessionState.comp_code;
                            item.rate = 0;
                            item.line_id = ItemsEntity[dgSelectedIndexItem].line_id;
                            item.item_line_id = ItemsEntity[dgSelectedIndexItem].line_id;
                            item.sch_date = item.sch_date ?? DateTime.Now;
                            item.del_date = item.sch_date ?? DateTime.Now;
                            item.desp_date = item.sch_date ?? DateTime.Now;
                            item.exp_date = item.sch_date ?? DateTime.Now;
                            item.confirm_date = item.sch_date ?? DateTime.Now;
                            item.confirm_qty = item.confirm_qty ?? item.sch_qty ?? ItemsEntity[dgSelectedIndexItem].quantity;
                            item.sch_qty = item.sch_qty ?? ItemsEntity[dgSelectedIndexItem].quantity;
                            item.del_qty = item.del_qty ?? ItemsEntity[dgSelectedIndexItem].quantity;
                            item.sch_cat = "SD";
                            item.ship_to_party = ItemsEntity[dgSelectedIndexItem].ship_to_Party ?? MasterEntity.ship_to_party;
                            item.ship_to_add = MasterEntity.del_address.ToString();

                            item.PropertyChanged += EntityViewModelPropertyChanged;
                        }
                        else if (ItemsEntity.Count > 0 && ItemsEntity.Count > dgSelectedIndexItem && ItemsEntity[dgSelectedIndexItem].ItemCode != null || ItemsEntity[dgSelectedIndexItem].ItemCode != "")
                        {
                            item.ItemCode = ItemsEntity[dgSelectedIndexItem].ItemCode;
                            item.unit_code = ItemsEntity[dgSelectedIndexItem].unit_code;
                            item.sku = ItemsEntity[dgSelectedIndexItem].sku;
                            item.sono = ItemsEntity[dgSelectedIndexItem].sono;
                            item.sch_qty = 0;
                            item.t_status = MasterEntity.t_status;
                            item.active = true;
                            item.editby = AppSessionState.UserID;
                            item.add_by = AppSessionState.UserID;
                            item.location_Id = AppSessionState.location_Id;
                            item.comp_code = AppSessionState.comp_code;
                            item.rate = 0;
                            item.line_id = ItemsEntity[dgSelectedIndexItem].line_id;
                            item.item_line_id = ItemsEntity[dgSelectedIndexItem].line_id;
                            item.sch_date = item.sch_date ?? DateTime.Now;
                            item.del_date = item.sch_date ?? DateTime.Now;
                            item.desp_date = item.sch_date ?? DateTime.Now;
                            item.exp_date = item.sch_date ?? DateTime.Now;
                            item.confirm_date = item.sch_date ?? DateTime.Now;
                            item.confirm_qty = item.confirm_qty ?? item.sch_qty ?? ItemsEntity[dgSelectedIndexItem].quantity;
                            item.sch_qty = item.sch_qty ?? ItemsEntity[dgSelectedIndexItem].quantity;
                            item.del_qty = item.del_qty ?? ItemsEntity[dgSelectedIndexItem].quantity;
                            item.sch_cat = "SD";
                            item.ship_to_party = ItemsEntity[dgSelectedIndexItem].ship_to_Party ?? MasterEntity.ship_to_party;
                            item.ship_to_add = MasterEntity.del_address.ToString();

                            item.PropertyChanged += EntityViewModelPropertyChanged;
                        }
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
            if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
            }

        }
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            try
            {
                if (EntityChangeEnable == true)
                {
                    this.ErrorExist = false; /*MasterEntity.HasErrors;*/

                    // if company change then update related data which is applicable i.e. Company, Plant, Location, Sales Organisation, Sales Group till Sales area, related popup collections, Store Location and subsequent data of Store code. 
                    // Following 2 Task is important in case of company change.
                    //1) set null value to related fields of Entity i.e. Plant, Organisation and groups etc. 
                    //2) Set defaults values for Plant, Organisation and groups etc.,
                    if (sender.ToString() == "comp_code")
                    {
                        //MasterEntity.sales_person_cd = AppSessionState.EmpId; //NOTE: Can be decide later
                        //MasterEntity.seller_name = AppSessionState.EmpName; //NOTE: Can be decide later
                        //MasterEntity.location_Id = AppSessionState.location_Id; //NOTE: Can be decide later
                        ScheduleEntity.comp_code = MasterEntity.comp_code;

                        MasterEntity.so_code = null;
                        MasterEntity.sales_org = null;
                        MasterEntity.sg_code = null;
                        MasterEntity.sg_name = null;
                        MasterEntity.location_Id = null;
                        MasterEntity.LoctnNm = null;

                        SalesOrganisationList = ((List<ADM_M001_A_P>)AppSessionState.ADM_M001_A_List).Where(item => item.comp_code == MasterEntity.comp_code).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).so_code);
                        TheFilter = (o, prefix) => (((ADM_M001_A_P)o).so_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M001_A_P)o).sales_org ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASSalesOrg = new AutoSuggestTextViewModel<dynamic>(SalesOrganisationList, TheFilter, SuggestedValue, "so_code", true);
                        if (SalesOrganisationList.Count == 1)
                        {
                            MasterEntity.so_code = SalesOrganisationList[0].so_code;
                            MasterEntity.sales_org = SalesOrganisationList[0].sales_org;
                        }

                        LocationList = ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(item => item.comp_code == MasterEntity.comp_code).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                        TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASLocationId = new AutoSuggestTextViewModel<dynamic>(LocationList, TheFilter, SuggestedValue, "location_Id", true);
                        ASLocationId.AutoSuggestVM.IsEmptyValueAllowed = true;
                        if (LocationList.Count == 1)
                        {
                            MasterEntity.location_Id = LocationList[0].location_Id;
                            MasterEntity.LoctnNm = SalesGroupList[0].LoctnNm;
                            ScheduleEntity.location_Id = MasterEntity.location_Id;
                        }
                    }
                    if (sender.ToString() == "so_code")
                    {
                        MasterEntity.sg_code = null;
                        MasterEntity.sg_name = null;
                        SalesGroupList = ((List<ADM_M001_H_P>)AppSessionState.ADM_M001_H_List).Where(item => item.so_code == MasterEntity.so_code).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_H_P)x).sg_code);
                        TheFilter = (o, prefix) => (((ADM_M001_H_P)o).sg_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M001_H_P)o).sg_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASSalesGroup = new AutoSuggestTextViewModel<dynamic>(SalesGroupList, TheFilter, SuggestedValue, "sg_code", true);
                        if (SalesGroupList.Count == 1)
                        {
                            MasterEntity.sg_code = SalesGroupList[0].sg_code;
                            MasterEntity.sg_name = SalesGroupList[0].sg_name;
                        }
                    }
                    if (sender.ToString() == "hb_acc")
                    {
                        if (!string.IsNullOrWhiteSpace(MasterEntity.hb_acc) && MC.hbList.Count > 0)
                        {
                            MasterEntity.bank_name = MC.hbList.Where(b => b.hb_acc == MasterEntity.hb_acc).ToList()[0].bank_name;
                            MasterEntity.bank_code = MC.hbList.Where(b => b.hb_acc == MasterEntity.hb_acc).ToList()[0].bank_code;
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
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            if (EntityChangeEnable == true)
            {
                //This will get called when the property of an object inside the collection changes
                if (sender.ToString() == "line_id" || sender.ToString() == "quantity" || sender.ToString() == "unit_price" || sender.ToString() == "tax_id" || sender.ToString() == "active" || sender.ToString() == "discount" || sender.ToString() == "price_qty" || sender.ToString() == "qty_price" || sender.ToString() == "price_qty_uom")
                {
                    PriceComputation(null, null, null);
                    Computation(true, dgSelectedIndexItem);
                }
                this.ErrorExist = false; /*MasterEntity.HasErrors;*/
                if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
                }
            }

        }
        void ModelUpdated_ScheduleMaster(object sender, EventArgs e)
        {
            if (EntityChangeEnable == true)
            {

            }
        }
        void ModelUpdated_ScheduleItem(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            try
            {
                if (EntityChangeEnable == true)
                {
                    //This will get called when the property of an object inside the collection changes
                    if (sender.ToString() == "del_date")
                    {
                        ItemScheduleEntity[dgSelectedIndexItemSchedule].confirm_date = ItemScheduleEntity[dgSelectedIndexItemSchedule].del_date;
                    }
                }

            }
            catch (Exception ex) { }
        }


        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                isNewRecord = true;

                //string Request = "LoadInitialData" + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.so_code + "!@" + MasterEntity.sg_code + "!@" + MasterEntity.EmpId + "!@" + MasterEntity.client;
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + (MasterEntity.sono ?? "") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "");
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MC, Request, "SalesQuotation", "CRM", "LoadAll", 0, "");

                //MasterEntity.t_display = (from o in MC.t_StatusList where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();

                var tempt_display = (from o in MC.STATUS_LIST
                                     where o.t_status == MasterEntity.t_status
                                     select o).ToList();
                MasterEntity.t_display = tempt_display[0].t_display;

                UnitConversionList = MC.UnitConversion;

                #region AutoSuggest Initilazation

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASUOMPRICEQTY = new AutoSuggestTextViewModel<dynamic>(MC.UOM, TheFilter, SuggestedValue, "price_qty_uom", "unit_code", true);
                ASUOMPRICEQTY.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASUOMPRICEQTY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M037)x).ind_trade);
                TheFilter = (o, prefix) => (((SYS_M037)o).ind_trade ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M037)o).trade_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTradeIndicator = new AutoSuggestTextViewModel<dynamic>(MC.Trade_Types, TheFilter, SuggestedValue, "ind_trade", true);
                ASTradeIndicator.AutoSuggestVM.IsEmptyValueAllowed = false;
                ASTradeIndicator.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => ((ADM_M028_P)o).PartyNm.ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M028_P)o).PartyId.ToString().ToLower().Contains(prefix.ToLower());
                ASSoldToParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyId", true);
                ASSoldToParty.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASSoldToParty.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => ((ADM_M028_P)o).PartyNm.ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M028_P)o).PartyId.ToString().ToLower().Contains(prefix.ToLower());
                ASShipToParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyId", true);
                ASShipToParty.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASShipToParty.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyNm);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AutoSuggestTextViewModel = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyNm", true);
                AutoSuggestTextViewModel.AutoSuggestVM.IsEmptyValueAllowed = true;
                AutoSuggestTextViewModel.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M012_P)x).CntryName);
                TheFilter = (o, prefix) => (((ADM_M012_P)o).CntryName ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M012_P)o).country_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCountry = new AutoSuggestTextViewModel<dynamic>(MC.CountryMaster, TheFilter, SuggestedValue, "CntryName", true);
                ASCountry.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSalesPerson = new AutoSuggestTextViewModel<dynamic>(MC.Sellers, TheFilter, SuggestedValue, "EmpId", true);
                ASSalesPerson.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037_P)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M037_P)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCurrency = new AutoSuggestTextViewModel<dynamic>(MC.Currencys, TheFilter, SuggestedValue, "curr_code", true);
                ASCurrency.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037_P)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M037_P)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASdgCurrency = new AutoSuggestTextViewModel<dynamic>(MC.Currencys, TheFilter, SuggestedValue, "curr_code", "curr_code", true);
                ASdgCurrency.AutoSuggestVM.IsEmptyValueAllowed = true;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P_SO_ItemsList)x).ItemCode);
                //TheFilter = (o, prefix) => (((SEL_T001_P_SO_ItemsList)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SEL_T001_P_SO_ItemsList)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //ASItems = new AutoSuggestTextViewModel<dynamic>(MC.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                //ASItems.AutoSuggestVM.IsEmptyValueAllowed = true;
                //ASItems.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASUOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASUOM.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASUOM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P_SO_ItemsList)x).ItemCode);
                TheFilter = (o, prefix) => (((SEL_T001_P_SO_ItemsList)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SEL_T001_P_SO_ItemsList)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_P)o).gl_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault1 = new AutoSuggestTextViewModel<dynamic>(MC.GLCodes, TheFilter, SuggestedValue, "gl_code", "gl_code", true);
                ASDefault1.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault1.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_P)o).gl_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTaxacc = new AutoSuggestTextViewModel<dynamic>(MC.GLCodes, TheFilter, SuggestedValue, "gl_code", "gl_code", true);
                ASTaxacc.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_O_P)x).con_type);
                TheFilter = (o, prefix) => (((ACC_M003_O_P)o).con_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_O_P)o).con_desc ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_O_P)o).con_cat ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_O_P)o).pricing_pro ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASConditionType = new AutoSuggestTextViewModel<dynamic>(MC.ConditionTypeList, TheFilter, SuggestedValue, "con_type", "con_type", false);
                ASConditionType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((CRM_M001_P)x).con_type);
                TheFilter = (o, prefix) => (((CRM_M001_P)o).con_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((CRM_M001_P)o).long_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault2 = new AutoSuggestTextViewModel<dynamic>(MC.TermsConditionCollection, TheFilter, SuggestedValue, "con_type", "con_type", true);
                ASDefault2.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault2.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyNm);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault3 = new AutoSuggestTextViewModel<dynamic>(MC.Transporters, TheFilter, SuggestedValue, "PartyNm", "PartyNm", true);
                ASDefault3.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault3.AutoSuggestVM.IsFreeTextAllowed = true;

                refdoctempa = (from o in MC.Sales_Order_Reference where o.doc_cat == "SN" select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P_RefDoc)x).sono);
                TheFilter = (o, prefix) => ((SEL_T001_P_RefDoc)o).sono.ToString().ToLower().Contains(prefix.ToLower());
                ASRef_doc_no = new AutoSuggestTextViewModel<dynamic>(refdoctempa, TheFilter, SuggestedValue, "sono", true);
                ASRef_doc_no.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M003_P)x).sditem_cat_code);
                TheFilter = (o, prefix) => (((SYS_M003_P)o).sditem_cat_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M003_P)o).item_cat_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASItemLineCat = new AutoSuggestTextViewModel<dynamic>(MC.ItemLineCategory, TheFilter, SuggestedValue, "item_cat", "sditem_cat_code", true);
                ASItemLineCat.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTransporterMaster = new AutoSuggestTextViewModel<dynamic>(MC.Transporters, TheFilter, SuggestedValue, "transporter_cd", true);
                ASTransporterMaster.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyNm);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTransporter = new AutoSuggestTextViewModel<dynamic>(MC.Transporters, TheFilter, SuggestedValue, "PartyNm", "PartyNm", true);
                ASTransporter.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((CRM_M001_P)x).con_type);
                TheFilter = (o, prefix) => (((CRM_M001_P)o).con_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((CRM_M001_P)o).long_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTermsCond = new AutoSuggestTextViewModel<dynamic>(MC.TermsConditionCollection, TheFilter, SuggestedValue, "con_type", "con_type", true);
                ASTermsCond.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M044_P)x).incoterms);
                TheFilter = (o, prefix) => (((ADM_M044_P)o).incoterms ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M044_P)o).inco_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASIncoTerms = new AutoSuggestTextViewModel<dynamic>(MC.Incoterms, TheFilter, SuggestedValue, "incoterms", true);
                ASIncoTerms.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M007_P)x).p_term_code);
                TheFilter = (o, prefix) => (((ACC_M007_P)o).p_term_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M007_P)o).p_term ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPayTerms = new AutoSuggestTextViewModel<dynamic>(MC.PayTerms, TheFilter, SuggestedValue, "p_term_code", true);
                ASPayTerms.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASRefferingParty = new AutoSuggestTextViewModel<dynamic>(MC.ServiceProviders, TheFilter, SuggestedValue, "PartyId", true);
                ASRefferingParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M004_P)x).bank_code);
                TheFilter = (o, prefix) => (((ACC_M004_P)o).bank_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M004_P)o).bank_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASOurBank = new AutoSuggestTextViewModel<dynamic>(MC.Banks, TheFilter, SuggestedValue, "bank_code", true);
                ASOurBank.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M004_P)x).bank_code);
                TheFilter = (o, prefix) => (((ACC_M004_P)o).bank_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M004_P)o).bank_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASNastroBank = new AutoSuggestTextViewModel<dynamic>(MC.Banks, TheFilter, SuggestedValue, "bank_code", true);
                ASNastroBank.AutoSuggestVM.IsEmptyValueAllowed = true;



                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M002)o).CompName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCompany = new AutoSuggestTextViewModel<dynamic>((List<ADM_M002>)AppSessionState.ADM_M002_List, TheFilter, SuggestedValue, "comp_code", true);
                ASCompany.AutoSuggestVM.IsEmptyValueAllowed = true;
                MasterEntity.comp_code = AppSessionState.comp_code;

                LocationList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASLocationId = new AutoSuggestTextViewModel<dynamic>(LocationList, TheFilter, SuggestedValue, "location_Id", true);
                ASLocationId.AutoSuggestVM.IsEmptyValueAllowed = true;

                SalesOrganisationList = (List<ADM_M001_A_P>)AppSessionState.ADM_M001_A_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).so_code);
                TheFilter = (o, prefix) => (((ADM_M001_A_P)o).so_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M001_A_P)o).sales_org ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSalesOrg = new AutoSuggestTextViewModel<dynamic>(SalesOrganisationList, TheFilter, SuggestedValue, "so_code", true);

                SalesGroupList = (List<ADM_M001_H_P>)AppSessionState.ADM_M001_H_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_H_P)x).sg_code);
                TheFilter = (o, prefix) => (((ADM_M001_H_P)o).sg_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M001_H_P)o).sg_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSalesGroup = new AutoSuggestTextViewModel<dynamic>(SalesGroupList, TheFilter, SuggestedValue, "sg_code", true);
                ASSalesGroup.AutoSuggestVM.IsEmptyValueAllowed = false;
                //ASSalesGroup.AutoSuggestVM.IsFreeTextAllowed = true;

                var LocList = (from o in LocationList where o.comp_code == AppSessionState.comp_code select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASLocation = new AutoSuggestTextViewModel<dynamic>(LocList, TheFilter, SuggestedValue, "location_Id", true);
                ASLocation.AutoSuggestVM.IsEmptyValueAllowed = true;

                LocationList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASOrderTo = new AutoSuggestTextViewModel<dynamic>(LocationList, TheFilter, SuggestedValue, "order_to_plant", "location_Id", true);
                ASOrderTo.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M006_P)x).ink);
                TheFilter = (o, prefix) => (((ZADM_M006_P)o).ink ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASInk = new AutoSuggestTextViewModel<dynamic>(MC.Inks, TheFilter, SuggestedValue, "para1", "ink", true);
                ASInk.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M007_P)x).ild);
                TheFilter = (o, prefix) => (((ZADM_M007_P)o).ild ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASILD = new AutoSuggestTextViewModel<dynamic>(MC.ILDs, TheFilter, SuggestedValue, "para5", "ild", true);
                ASILD.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M002_P)x).ball_type);
                TheFilter = (o, prefix) => (((ZADM_M002_P)o).ball_type ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASBallType = new AutoSuggestTextViewModel<dynamic>(MC.BallTypes, TheFilter, SuggestedValue, "para2", "ball_type", true);
                ASBallType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M045_P)x).grade_code);
                TheFilter = (o, prefix) => (((ADM_M045_P)o).grade_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASGrade = new AutoSuggestTextViewModel<dynamic>(MC.GradeCollection, TheFilter, SuggestedValue, "para3", "grade_code", true);
                ASGrade.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M026)x).tr_mode);
                TheFilter = (o, prefix) => (((SYS_M026)o).tr_mode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M026)o).tr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTR_MODE = new AutoSuggestTextViewModel<dynamic>(MC.TransportMode, TheFilter, SuggestedValue, "tr_mode", true);
                ASTR_MODE.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASTR_MODE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASt_status = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_display", true);
                ASt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M004_P)x).hb_acc);
                TheFilter = (o, prefix) => (((ACC_M004_P)o).hb_acc ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M004_P)o).hb_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M004_P)o).bank_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M004_P)o).acc_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASHBcode = new AutoSuggestTextViewModel<dynamic>(MC.hbList, TheFilter, SuggestedValue, "hb_acc", true);
                ASHBcode.AutoSuggestVM.IsEmptyValueAllowed = true; ASHBcode.AutoSuggestVM.IsFreeTextAllowed = false;
                if (MC.hbList != null)
                {
                    if (MC.hbList.Count == 1)
                    {
                        MasterEntity.hb_acc = MC.hbList[0].hb_acc;
                    }
                }

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002_B)x).CatCode);
                TheFilter = (o, prefix) => (((ADM_M002_B)o).CatCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M002_B)o).cat_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASScope = new AutoSuggestTextViewModel<dynamic>(MC.ScopeList, TheFilter, SuggestedValue, "CatCode", true);
                ASScope.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASScope.AutoSuggestVM.IsFreeTextAllowed = false;

                #region AutoSuggest Initilazation : Filtrs for View

                var LocFilterList = (from o in LocationList where o.comp_code == AppSessionState.comp_code select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_FltrPlant = new AutoSuggestTextViewModel<dynamic>(LocFilterList, TheFilter, SuggestedValue, "location_Id", true);
                AS_FltrPlant.AutoSuggestVM.IsEmptyValueAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_Fltr_status = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_display", true);
                AS_Fltr_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_Fltr_SalesPerson = new AutoSuggestTextViewModel<dynamic>(MC.Sellers, TheFilter, SuggestedValue, "EmpId", true);
                AS_Fltr_SalesPerson.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyNm);
                TheFilter = (o, prefix) => ((ADM_M028_P)o).PartyNm.ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M028_P)o).PartyId.ToString().ToLower().Contains(prefix.ToLower());
                AS_Fltr_SoldToParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyNm", true);
                AS_Fltr_SoldToParty.AutoSuggestVM.IsEmptyValueAllowed = true;
                AS_Fltr_SoldToParty.AutoSuggestVM.IsFreeTextAllowed = true;
                #endregion

                #endregion
                PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListPopup);
                PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                StringListItems = MC.ItemListPopup.Select(x => x.ItemCode).ToList();

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

                #region Collection Lists for Old Pop_ups
                Doc_TypeCollection = CollectionViewSource.GetDefaultView(MC.DocumentTypes);
                Doc_TypeCollection.Filter = new Predicate<object>(Filter_DocType);
                StringListDocumentTypes = MC.DocumentTypes.Select(x => x.doc_type_user).ToList();

                Doc_TypeCollectionBf = new CollectionViewSource { Source = MC.DocumentTypes }.View;
                Doc_TypeCollectionBf.Filter = new Predicate<object>(Filter_DocTypeBf);
                StringListDocumentTypesBf = MC.DocumentTypes.Select(x => x.doc_type_user).ToList();

                PartyCollection = CollectionViewSource.GetDefaultView(MC.PartyMaster);
                PartyCollection.Filter = new Predicate<object>(Filter_Party);
                StringListParty = MC.PartyMaster.Select(x => x.PartyId).ToList();

                TransporterCollection = CollectionViewSource.GetDefaultView(MC.Transporters);
                TransporterCollection.Filter = new Predicate<object>(Filter_Transporter);
                StringListTransporter = MC.Transporters.Select(x => x.PartyId).ToList();

                dgTransporterCollection = CollectionViewSource.GetDefaultView(MC.Transporters);
                dgTransporterCollection.Filter = new Predicate<object>(Filter_dgTransporter);
                StringListdgTransporter = MC.Transporters.Select(x => x.PartyNm).ToList();

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
                StringListGLCode = MC.GLCodes.Select(x => x.gl_code).ToList();

                PayTermCollection = CollectionViewSource.GetDefaultView(MC.PayTerms.ToList());
                PayTermCollection.Filter = new Predicate<object>(Filter_PayTerms);
                StringListPayTerms = MC.PayTerms.Select(x => x.p_term_code).ToList();

                CurrencyCollection = CollectionViewSource.GetDefaultView(MC.Currencys);
                CurrencyCollection.Filter = new Predicate<object>(Filter_Currency);
                StringListCurrency = MC.Currencys.Select(x => x.curr_code).ToList();

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

                ILDCollection = CollectionViewSource.GetDefaultView(MC.ILDs);
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

                IncotermsCollection = CollectionViewSource.GetDefaultView(MC.Incoterms);
                IncotermsCollection.Filter = new Predicate<object>(Filter_Incoterms);
                StringListIncoterms = MC.Incoterms.Select(x => x.incoterms).ToList();

                LicenseAdvanceCollection = CollectionViewSource.GetDefaultView(MC.LicenseAdvance);
                LicenseAdvanceCollection.Filter = new Predicate<object>(Filter_ADVANCELicense);
                StringListLicenseAdvance = MC.LicenseAdvance.Select(x => x.lic_cod).ToList();

                LicenseEPCGCollection = CollectionViewSource.GetDefaultView(MC.LicenseEPCG);
                LicenseEPCGCollection.Filter = new Predicate<object>(Filter_EPCGLicense);
                StringListLicenseEPCG = MC.LicenseEPCG.Select(x => x.lic_cod).ToList();

                refdoctempa = (from o in MC.Sales_Order_Reference where o.doc_cat == "SN" select o).ToList();
                ReferenceDocCollection = CollectionViewSource.GetDefaultView(refdoctempa.ToList());
                ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                StringListReferenceDoc = MC.Sales_Order_Reference.Select(x => x.sono).ToList();

                PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListPopup);
                PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                StringListItems = MC.ItemListPopup.Select(x => x.ItemCode).ToList();

                TermsConditionCollection = CollectionViewSource.GetDefaultView(MC.TermsConditionCollection);
                TermsConditionCollection.Filter = new Predicate<object>(Filter_Terms);
                StringListTerms = MC.TermsConditionCollection.Select(x => x.con_type).ToList();

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
                LocationCollection.Filter = new Predicate<object>(Filter_Location);
                StringListLocationID = LocationList.Select(x => x.location_Id).ToList();

                PlantCollection = new CollectionViewSource { Source = LocationList }.View;
                PlantCollection.Filter = new Predicate<object>(Filter_Plant);
                StringListPlant = LocationList.Select(x => x.location_Id).ToList();

                var location = (from o in LocationList where o.comp_code == AppSessionState.comp_code select o).ToList();
                dgLocationCollection = CollectionViewSource.GetDefaultView(location);
                dgLocationCollection.Filter = new Predicate<object>(Filter_dgLocation);
                StringListdgLocationID = location.Select(x => x.location_Id).ToList();

                GradeCollection = CollectionViewSource.GetDefaultView(MC.GradeCollection);
                GradeCollection.Filter = new Predicate<object>(Filter_Grade);
                #endregion 

                NotificationDataCollection = MC.NotificationData;

                MasterEntity = MasterEntity;

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));

            }
            catch (Exception ex)
            { }

        }
        private void CommandInitialization()
        {
            CursorControl.SetBusyState();
            try
            {
                #region Command Initialization
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                #region Command Initialization for Master

                CommandSoldToParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertSoldToParty(items, isNewRecord); });
                CommandShipToParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertShipToParty(items, isNewRecord); });
                CommandBuyer = new RelayCommand<object>(items => { if (items == null) { return; } InsertBuyer(items); });
                CommandSeller = new RelayCommand<object>(items => { if (items == null) { return; } InsertSeller(items); });
                CmdInsert_t_status = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_t_status(cmdPara); });
                #endregion

                #region Command Initialization for Sales Tab

                CommandIncoterms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertIncoterms(cmdPara); });// confirm assignment
                CommandPayTerms = new RelayCommand<object>(items => { if (items == null) { return; } InsertPayTerm(items); });
                CommandServiceProvider = new RelayCommand<object>(items => { if (items == null) { return; } InsertServiceProvider(items, false); });
                cmdRefContactPerson = new RelayCommand<object>(items => { if (items == null) { return; } InsertRefContactPerson(items); });
                CommandBank = new RelayCommand<object>(items => { if (items == null) { return; } InsertBank(items); });
                CommandNastroBank = new RelayCommand<object>(items => { if (items == null) { return; } InsertNastroBank(items); });
                CommandSalseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseOrg(items); });
                CommandSalseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseGroup(items); });
                cmdTR_ModeMaster = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTR_ModeMaster(cmdPara); });
                CommandTransporterMaster = new RelayCommand<object>(items => { if (items == null) { return; } InsertTransporterMaster(items, false); });
                #endregion

                #region Command Initialization for ItemDetails Tab

                CommandItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara, true, true, true); });
                CommandItemCategory = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItemCategory(cmdPara, false, true, true); });
                CommandUOM = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOM(cmdPara, false, true, true); });
                CmdUnitPrice = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } CheckPrice(cmdPara, false, true, true); });
                CommandLocations = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLocation(cmdPara); });// confirm assignment
                CmdItemInfo = new RelayCommand<object>(items => { if (items == null) { return; } FilterItemSalesData(items); });
                CommandDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });// confirm assignment
                cmdOpenAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenDocumentViewer(cmdPara); });
                CmdCondType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertConditiontype(cmdPara); });
                CommandAddSelectedTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSelectedTax(cmdPara); });
                CmddgCurrency = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgCurrency(cmdPara); });
                cmdDeleteTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteTax(cmdPara); });
                CommandUOMPriceQty = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOMPriceQty(cmdPara, false, true, true); });
                #endregion

                #region Command Initialization for Delivery Schedule Tab

                cmdTransporter = new RelayCommand<object>(items => { if (items == null) { return; } InsertdgTransporter(items); });
                CommandDeleteDataGridRowSchedule = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_ItemSchedule(cmdPara); });// confirm assignment
                CollectionChangedCommand = new RelayCommand<IList>(items => { if (items == null) { return; } CollectionChanged(items); });
                SelectionChangedParaValCommand = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedParaValue(items); });
                #endregion

                #region Command Initialization for Terms And Conditions Tab

                CommandTerms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTerms(cmdPara, true, true, true); });
                CommandDeleteDataGridTerms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Terms(cmdPara); });
                CommandTermsScope = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTermsScope(cmdPara, true, true, true); });
                #endregion

                #region Command Initialization : Filters for View Tab

                cmdFilterByPlant = new RelayCommand<object>(items => { if (items == null) { return; } FilterViewByPlant(items); });
                CommandFltrStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrStatus(items); });
                CommandFltrSoldToParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrSoldToParty(items); });
                CommandFltrSeller = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrSeller(items); });
                #endregion

                #region Command Initialization : Other

                CommandDocTypeBf = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocTypeBf(items); });
                CommandDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocType(items); });
                CommandLoadDocumentFromSource = new GalaSoft.MvvmLight.Command.RelayCommand(() => LoadSourceDocument()); // confirm assignment
                CommandNotifyParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertNotifyParty(items, true); });
                CommandSoldToAddress = new RelayCommand<object>(items => { if (items == null) { return; } InsertSoldToAddress(items, true); });
                CommandShipToAddress = new RelayCommand<object>(items => { if (items == null) { return; } InsertShipToAddress(items, true); });
                CommandTransporter = new RelayCommand<object>(items => { if (items == null) { return; } InsertTransporter(items, false); });
                CommandGLCode = new RelayCommand<object>(items => { if (items == null) { return; } InsertGLCode(items); });
                CommandCurrency = new RelayCommand<object>(items => { if (items == null) { return; } InsertCurrency(items); });
                CommandSalseDivision = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseDivision(items); });
                CommandCostCenter = new RelayCommand<object>(items => { if (items == null) { return; } InsertCostCenter(items); });
                CommandBallType = new RelayCommand<object>(items => { if (items == null) { return; } InsertBallType(items); });
                CommandILD = new RelayCommand<object>(items => { if (items == null) { return; } InsertILD(items); });
                CommandWireType = new RelayCommand<object>(items => { if (items == null) { return; } InsertWireType(items); });
                CommandBallDia = new RelayCommand<object>(items => { if (items == null) { return; } InsertBallDia(items); });
                CommandInk = new RelayCommand<object>(items => { if (items == null) { return; } InsertInk(items); });
                CommandLicenseAdvance = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicenseAdvance(cmdPara); });// confirm assignment
                CommandLicenseEPCG = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicenseEPCG(cmdPara); });// confirm assignment
                CommandReferenceDocumentType = new RelayCommand<object>(items => { if (items == null) { return; } FilterReferenceDocumentNumbers(items); }); // confirm assignment
                CommandActiveInactiveCheck = new RelayCommand<bool>(CheckActiveStatus); // confirm assignment
                CommandReferenceDoc = new RelayCommand<object>(items => { if (items == null) { return; } InsertReferenceDoc(items); });
                CommandLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); }); // confirm assignment
                CommandLoadDocumentByRefDocNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByReferenceDocumentNumber(cmdPara, "FlipGridReference"); }); // confirm assignment
                ManualTaxChangedCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertManualTaxChangedCommand(cmdPara); });
                cmdLoadBackFlip = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadBackFlipData(cmdPara); });
                CommandMailDocuments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } MailDocuments(cmdPara); });
                CommandGrade = new RelayCommand<object>(items => { if (items == null) { return; } InsertGrade(items); });
                //CmdInsertCompany = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCompany(cmdPara); });
                //CmdInsertLocationId = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLocationId(cmdPara); });
                CommandSalseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseOrg(items); });
                CommandSalseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseGroup(items); });

                #endregion
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
                    //                      group wo by wo.tax_name
                    //                 into g
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
                    _FlipDataGridCollection.Refresh();
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
                if (MasterEntity.ref_doc_no != null)
                {
                    refdoctempa.RemoveAll(X => X.sono == MasterEntity.ref_doc_no);
                    MC.Sales_Order_Reference.RemoveAll(X => X.sono == MasterEntity.ref_doc_no);

                    ReferenceDocCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                    ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                    StringListReferenceDoc = MC.Sales_Order_Reference.Select(x => x.sono).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P_RefDoc)x).sono);
                    TheFilter = (o, prefix) => (((SEL_T001_P_RefDoc)o).sono ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASRef_doc_no = new AutoSuggestTextViewModel<dynamic>(refdoctempa, TheFilter, SuggestedValue, "sono", true);
                    ASRef_doc_no.AutoSuggestVM.IsEmptyValueAllowed = true;

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
        private void DefaultValues()
        {
            EntityChangeEnable = true;
            MasterEntity.doc_cat = "QN";
            MasterEntity.doc_type = "QN";
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.t_status = "001";
            MasterEntity.shipped = false;
            MasterEntity.version = "v1.0";
            MasterEntity.sodate = DateTime.Now;
            MasterEntity.sono = "";
            MasterEntity.client = AppSessionState.client;
            Currency = AppSessionState.CntryCurncy;
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.net_value = 0;
            MasterEntity.other_charges = 0;
            MasterEntity.withholding_value = 0;
            MasterEntity.withholding_ex_amt = 0;
            MasterEntity.org_country_cd = ((List<ADM_M002>)AppSessionState.ADM_M002_List).Where(x => x.comp_code == AppSessionState.comp_code).ToList()[0].country_code;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.Fltr_FrmDate = DateTime.Now.AddMonths(-1);
            MasterEntity.Fltr_ToDate = DateTime.Now;
            MasterEntity.Fltr_active = true;
            MasterEntity.Fltr_doc_type = MasterEntity.doc_type;
            FilterString_Party = "";

            DateTime d = DateTime.UtcNow;
            d = d.AddMonths(-1);
            RequestPara.FromDate = d;
            RequestPara.ToDate = DateTime.UtcNow;
            RequestPara.active = true;

            ScheduleEntity.t_status = MasterEntity.t_status;
            ScheduleEntity.t_display = MasterEntity.t_display;
            ScheduleEntity.sch_date = DateTime.Now;
            ScheduleEntity.active = true;
            ScheduleEntity.add_by = AppSessionState.UserID;
            ScheduleEntity.editby = AppSessionState.UserID;
            ScheduleEntity.comp_code = AppSessionState.comp_code;
            ScheduleEntity.location_Id = AppSessionState.location_Id;
            ScheduleEntity.id = 0;
            ScheduleEntity.PartyId = MasterEntity.PartyId;

            if (MC.hbList != null)
            {
                if (MC.hbList.Count == 1)
                {
                    MasterEntity.hb_acc = MC.hbList[0].hb_acc;
                }
            }
        }
        private void ComputationOld(bool Compute, int ItemRowIndex)
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


                if (ItemsEntity != null && ItemsEntity.Count > 0 && ItemRowIndex >= 0 && ItemRowIndex < ItemsEntity.Count) //Condition satisfy only if Items collection is not empty.
                {
                    if (ItemsEntity[ItemRowIndex].quantity >= 0 && ItemsEntity[ItemRowIndex].unit_price >= 0 && ItemsEntity[ItemRowIndex].active != false) // Must not null or empty.
                    {
                        if (ItemsEntity[ItemRowIndex].discount == null)
                        {
                            ItemsEntity[ItemRowIndex].discount = 0;
                        }
                        ItemsEntity[ItemRowIndex].sub_total = (ItemsEntity[ItemRowIndex].quantity * ItemsEntity[ItemRowIndex].unit_price) - ((ItemsEntity[ItemRowIndex].quantity * ItemsEntity[ItemRowIndex].unit_price) * (ItemsEntity[ItemRowIndex].discount / 100));
                        ItemsEntity[ItemRowIndex].local_sub_total = (ItemsEntity[ItemRowIndex].sub_total * MasterEntity.ex_rate);

                        discount_amt_A = ((ItemsEntity[ItemRowIndex].quantity * ItemsEntity[ItemRowIndex].unit_price) - ItemsEntity[ItemRowIndex].sub_total);
                        ItemsEntity[ItemRowIndex].discount_amt = discount_amt_A;
                        ItemsEntity[ItemRowIndex].local_discount = (discount_amt_A * MasterEntity.ex_rate);

                        gross_value_A = (ItemsEntity[ItemRowIndex].quantity * ItemsEntity[ItemRowIndex].unit_price);
                        ItemsEntity[ItemRowIndex].gross_value = gross_value_A;

                        // Code For Effective Value
                        effective_value_A = (ItemsEntity[ItemRowIndex].quantity * ItemsEntity[ItemRowIndex].unit_price);
                        ItemsEntity[ItemRowIndex].effective_value = effective_value_A;

                        // Code For Net Value
                        ItemsEntity[ItemRowIndex].net_value = (ItemsEntity[ItemRowIndex].quantity * ItemsEntity[ItemRowIndex].unit_price) - ((ItemsEntity[ItemRowIndex].quantity * ItemsEntity[ItemRowIndex].unit_price) * (ItemsEntity[ItemRowIndex].discount / 100));
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
                                tax_amount_A = 0;
                                net_value_A = 0;

                                #region Percentage
                                if (SingleTax.t_type == "Percentage" && SingleTax.amount > 0)
                                {
                                    if (SingleTax.Price_include == true)
                                    {
                                        TaxValue = (SingleTax.amount) / 100 + 1;
                                        BasePrice = ItemsEntity[ItemRowIndex].sub_total / TaxValue;
                                        BasicItemAmount = BasePrice;
                                        TaxAmount = ItemsEntity[ItemRowIndex].sub_total - BasicItemAmount;
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
                                            BasePrice = ItemsEntity[ItemRowIndex].sub_total + PreviousTaxValueForBasePrice;
                                        }
                                        BasicItemAmount = ItemsEntity[ItemRowIndex].sub_total;
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
                                        BasePrice = ItemsEntity[ItemRowIndex].sub_total - TaxValue;
                                        BasicItemAmount = BasePrice;
                                        TaxAmount = ItemsEntity[ItemRowIndex].sub_total - BasicItemAmount;
                                    }
                                    else if (SingleTax.Price_include == false)
                                    {
                                        BasePrice = ItemsEntity[ItemRowIndex].sub_total;
                                        BasicItemAmount = BasePrice;
                                        TaxAmount = TaxValue;
                                    }
                                }
                                #endregion
                                #region Insert/Update Tax
                                int TaxIndex = 0;
                                var TaxVar = TotalDocumentTaxes.FirstOrDefault(T => T.tax_code_id == SingleTax.id && T.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (T.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && T.item_line_id == ItemsEntity[ItemRowIndex].line_id && T.item_row_id == ItemsEntity[ItemRowIndex].id && T.manual == "Auto");
                                TaxIndex = TotalDocumentTaxes.IndexOf(TaxVar);
                                if (TaxVar != null && TaxIndex >= 0)
                                {
                                    TotalDocumentTaxes[TaxIndex].manual = "Auto";
                                    TotalDocumentTaxes[TaxIndex].active = true;
                                    TotalDocumentTaxes[TaxIndex].tax_amount = TaxAmount;
                                    TotalDocumentTaxes[TaxIndex].account_id = 0;
                                    TotalDocumentTaxes[TaxIndex].sequence = SingleTax.sequence;
                                    TotalDocumentTaxes[TaxIndex].doc_no = MasterEntity.sono;
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
                                        doc_no = MasterEntity.sono,
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

                                ItemsEntity[ItemRowIndex].tax_amount = tax_amount_A;
                                net_value_A = gross_value_A - discount_amt_A + tax_amount_A;
                                ItemsEntity[ItemRowIndex].net_value = net_value_A;
                                ItemsEntity[ItemRowIndex].local_net_value = (net_value_A * MasterEntity.ex_rate);


                            }
                        }

                        #endregion

                        #region Remove Excluded Taxes.
                        string[] TaxArray2 = ItemsEntity[ItemRowIndex].tax_id.Trim().Split(',');
                        List<ACC_T006_B> copy = new List<ACC_T006_B>();
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

                            if (ChildTaxVar != null)
                            {
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

                                    if (tax.tax_code_id == ChildTaxVar.id && tax.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == ItemsEntity[ItemRowIndex].line_id && tax.item_row_id == ItemsEntity[ItemRowIndex].id && tax.manual == "Auto")
                                    {
                                        TotalDocumentTaxes.Remove(tax);
                                    }
                                }
                                else if (tax.tax_code_id == ChildTaxVar.id && tax.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == ItemsEntity[ItemRowIndex].line_id && tax.item_row_id == ItemsEntity[ItemRowIndex].id && tax.manual == "Auto")
                                {
                                    TotalDocumentTaxes.Remove(tax);
                                }
                            }

                        }

                        #endregion

                        effective_value_A = net_value_A;
                        ItemsEntity[ItemRowIndex].effective_value = effective_value_A;
                    }
                    else //if (ItemsEntity[ItemRowIndex].tax_id != null && ItemsEntity[ItemRowIndex].active == false) // Remove previously assign Taxes from TotalDocumentTaxes if removed from Item.//Condition satisfy only if Selected Item not null and Active status is false.
                    {
                        List<ACC_T006_B> copy = new List<ACC_T006_B>();
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
                    MasterEntity.tax_amt = TaxtTotal;
                    MasterEntity.tax_amount = TaxtTotal;

                    local_tax_amt = (TaxtTotal * MasterEntity.ex_rate);
                    MasterEntity.local_tax_amt = local_tax_amt;

                    //UnTaxTotal = ItemsEntity.Sum(x => x.sub_total);
                    UnTaxTotal = ItemsEntity.Where(item => item.active != false).Sum(item => item.sub_total);
                    MasterEntity.untax_amt = UnTaxTotal;


                    net_value = UnTaxTotal + TaxtTotal;
                    MasterEntity.net_value = net_value;
                    other_charges = TotalDocumentTaxes.Where(item => item.active != false && item.manual == "Manual").Sum(item => item.tax_amount);
                    MasterEntity.other_charges = other_charges;

                    local_net_value = (net_value * MasterEntity.ex_rate);
                    MasterEntity.local_net_value = local_net_value;

                    GrandTotal = net_value + other_charges;
                    MasterEntity.total_amt = GrandTotal;

                    local_total_amt = (GrandTotal * MasterEntity.ex_rate);
                    MasterEntity.local_total_amt = local_total_amt;

                    MasterEntity.roundup_total = decimal.Round((decimal)GrandTotal);
                    local_roundup_total = (MasterEntity.roundup_total * MasterEntity.ex_rate);
                    MasterEntity.local_roundup_total = local_roundup_total;

                    MasterEntity.round_up = MasterEntity.roundup_total - GrandTotal;
                    local_round_up = (MasterEntity.round_up * MasterEntity.ex_rate);
                    MasterEntity.local_round_up = local_round_up;

                    gross_value = ItemsEntity.Where(item => item.active != false).Sum(item => item.quantity * item.unit_price);
                    MasterEntity.gross_value = gross_value;

                    effective_value = GrandTotal;
                    MasterEntity.effective_value = effective_value;

                    disc_amt = gross_value - UnTaxTotal;
                    MasterEntity.disc_amt = disc_amt;

                    if (MasterEntity.roundup_total > 0)
                    {
                        NumberToEnglish num = new NumberToEnglish();
                        ADM_M037 curr_obj = new ADM_M037();
                        curr_obj = ((List<ADM_M037>)AppSessionState.CurrencyList).Where(x => x.curr_code == MasterEntity.curr_code).ToList()[0];
                        MasterEntity.amt_inword = num.AmountInWords(Convert.ToDecimal(MasterEntity.roundup_total), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word);
                    }
                    else
                    { MasterEntity.amt_inword = ""; }

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


                    if (ItemsEntity != null && ItemsEntity.Count > 0 && ItemRowIndex >= 0 && ItemRowIndex < ItemsEntity.Count) //Condition satisfy only if Items collection is not empty.
                    {
                        if (ItemsEntity[ItemRowIndex].quantity >= 0 && ItemsEntity[ItemRowIndex].unit_price >= 0 && ItemsEntity[ItemRowIndex].active != false) // Must not null or empty.
                        {
                            if (ItemsEntity[ItemRowIndex].discount == null)
                            {
                                ItemsEntity[ItemRowIndex].discount = 0;
                            }
                            ItemsEntity[ItemRowIndex].sub_total = (ItemsEntity[ItemRowIndex].quantity * ItemsEntity[ItemRowIndex].unit_price) - ((ItemsEntity[ItemRowIndex].quantity * ItemsEntity[ItemRowIndex].unit_price) * (ItemsEntity[ItemRowIndex].discount / 100));
                            ItemsEntity[ItemRowIndex].local_sub_total = (ItemsEntity[ItemRowIndex].sub_total * MasterEntity.ex_rate);

                            discount_amt_A = ((ItemsEntity[ItemRowIndex].quantity * ItemsEntity[ItemRowIndex].unit_price) - ItemsEntity[ItemRowIndex].sub_total);
                            ItemsEntity[ItemRowIndex].discount_amt = discount_amt_A;
                            ItemsEntity[ItemRowIndex].local_discount = (discount_amt_A * MasterEntity.ex_rate);

                            gross_value_A = (ItemsEntity[ItemRowIndex].quantity * ItemsEntity[ItemRowIndex].unit_price);
                            ItemsEntity[ItemRowIndex].gross_value = gross_value_A;

                            // Code For Effective Value
                            effective_value_A = (ItemsEntity[ItemRowIndex].quantity * ItemsEntity[ItemRowIndex].unit_price);
                            ItemsEntity[ItemRowIndex].effective_value = effective_value_A;

                            // Code For Net Value
                            ItemsEntity[ItemRowIndex].net_value = (ItemsEntity[ItemRowIndex].quantity * ItemsEntity[ItemRowIndex].unit_price) - ((ItemsEntity[ItemRowIndex].quantity * ItemsEntity[ItemRowIndex].unit_price) * (ItemsEntity[ItemRowIndex].discount / 100));
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
                                    tax_amount_A = 0;
                                    net_value_A = 0;

                                    #region Percentage
                                    if (SingleTax.t_type == "Percentage" && SingleTax.amount > 0)
                                    {
                                        if (SingleTax.Price_include == true)
                                        {
                                            TaxValue = (SingleTax.amount) / 100 + 1;
                                            BasePrice = ItemsEntity[ItemRowIndex].sub_total / TaxValue;
                                            BasicItemAmount = BasePrice;
                                            TaxAmount = ItemsEntity[ItemRowIndex].sub_total - BasicItemAmount;
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
                                                BasePrice = ItemsEntity[ItemRowIndex].sub_total + PreviousTaxValueForBasePrice;
                                            }
                                            BasicItemAmount = ItemsEntity[ItemRowIndex].sub_total;
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
                                            BasePrice = ItemsEntity[ItemRowIndex].sub_total - TaxValue;
                                            BasicItemAmount = BasePrice;
                                            TaxAmount = ItemsEntity[ItemRowIndex].sub_total - BasicItemAmount;
                                        }
                                        else if (SingleTax.Price_include == false)
                                        {
                                            BasePrice = ItemsEntity[ItemRowIndex].sub_total;
                                            BasicItemAmount = BasePrice;
                                            TaxAmount = TaxValue;
                                        }
                                    }
                                    #endregion
                                    #region Insert/Update Tax
                                    int TaxIndex = 0;
                                    var TaxVar = TotalDocumentTaxes.FirstOrDefault(T => T.tax_code_id == SingleTax.id && T.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (T.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && T.item_line_id == ItemsEntity[ItemRowIndex].line_id && T.item_row_id == ItemsEntity[ItemRowIndex].id && T.manual == "Auto");
                                    TaxIndex = TotalDocumentTaxes.IndexOf(TaxVar);
                                    if (TaxVar != null && TaxIndex >= 0)
                                    {
                                        TotalDocumentTaxes[TaxIndex].manual = "Auto";
                                        TotalDocumentTaxes[TaxIndex].active = true;
                                        TotalDocumentTaxes[TaxIndex].tax_amount = TaxAmount;
                                        TotalDocumentTaxes[TaxIndex].account_id = 0;
                                        TotalDocumentTaxes[TaxIndex].sequence = SingleTax.sequence;
                                        TotalDocumentTaxes[TaxIndex].doc_no = MasterEntity.sono;
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
                                        TotalDocumentTaxes[TaxIndex].qty_price = ItemsEntity[ItemRowIndex].qty_price;
                                        TotalDocumentTaxes[TaxIndex].price_qty = ItemsEntity[ItemRowIndex].price_qty;
                                        TotalDocumentTaxes[TaxIndex].price_qty_uom = ItemsEntity[ItemRowIndex].price_qty_uom;

                                    }
                                    else
                                    {
                                        TotalDocumentTaxes.Add(new ACC_T006_B()
                                        {
                                            id = 0,
                                            tax_amount = TaxAmount,
                                            account_id = 0,
                                            sequence = SingleTax.sequence,
                                            doc_no = MasterEntity.sono,
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
                                            trns_key_code = "",

                                            con_value = TaxAmount,
                                            tax_code = SingleTax.tax_code,
                                            PartyId = MasterEntity.PartyId,
                                            exch_rate = MasterEntity.ex_rate,
                                            client = AppSessionState.client,
                                            symbol = MasterEntity.symbol,
                                            local_curr = AppSessionState.CntryCurncy,
                                            qty_price = ItemsEntity[ItemRowIndex].qty_price,
                                            price_qty = ItemsEntity[ItemRowIndex].price_qty,
                                            price_qty_uom = ItemsEntity[ItemRowIndex].price_qty_uom
                                        });
                                    }

                                    #endregion
                                    Temptax_amount_A = Temptax_amount_A + TaxAmount;
                                    tax_amount_A = Temptax_amount_A;

                                    ItemsEntity[ItemRowIndex].tax_amount = tax_amount_A;
                                    net_value_A = gross_value_A - discount_amt_A + tax_amount_A;
                                    ItemsEntity[ItemRowIndex].net_value = net_value_A;
                                    ItemsEntity[ItemRowIndex].local_net_value = (net_value_A * MasterEntity.ex_rate);


                                }
                            }

                            #endregion

                            #region Remove Excluded Taxes.
                            string[] TaxArray2 = ItemsEntity[ItemRowIndex].tax_id.Trim().Split(',');
                            List<ACC_T006_B> copy = new List<ACC_T006_B>();
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

                                    if (tax.tax_code_id == ChildTaxVar.id && tax.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == ItemsEntity[ItemRowIndex].line_id && tax.item_row_id == ItemsEntity[ItemRowIndex].id && tax.manual == "Auto")
                                    {
                                        TotalDocumentTaxes.Remove(tax);
                                    }
                                }
                                else if (tax.tax_code_id == ChildTaxVar.id && tax.ItemCode == ItemsEntity[ItemRowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[ItemRowIndex].sku?.ToString() ?? "") && tax.item_line_id == ItemsEntity[ItemRowIndex].line_id && tax.item_row_id == ItemsEntity[ItemRowIndex].id && tax.manual == "Auto")
                                {
                                    TotalDocumentTaxes.Remove(tax);
                                }
                            }

                            #endregion

                            effective_value_A = net_value_A;
                            ItemsEntity[ItemRowIndex].effective_value = effective_value_A;
                        }
                        else //if (ItemsEntity[ItemRowIndex].tax_id != null && ItemsEntity[ItemRowIndex].active == false) // Remove previously assign Taxes from TotalDocumentTaxes if removed from Item.//Condition satisfy only if Selected Item not null and Active status is false.
                        {
                            List<ACC_T006_B> copy = new List<ACC_T006_B>();
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


                        }

                        #region Final Computation

                        TaxtTotal = TotalDocumentTaxes.Where(item => item.active != false && item.manual == "Auto").Sum(item => item.tax_amount);
                        MasterEntity.tax_amt = TaxtTotal;
                        MasterEntity.tax_amount = TaxtTotal;

                        local_tax_amt = (TaxtTotal * MasterEntity.ex_rate);
                        MasterEntity.local_tax_amt = local_tax_amt;

                        UnTaxTotal = ItemsEntity.Where(item => item.active != false).Sum(item => item.sub_total);
                        MasterEntity.untax_amt = UnTaxTotal;


                        net_value = UnTaxTotal + TaxtTotal;
                        MasterEntity.net_value = net_value;
                        other_charges = TotalDocumentTaxes.Where(item => item.active != false && item.manual == "Manual").Sum(item => item.tax_amount);
                        MasterEntity.other_charges = other_charges;

                        local_net_value = (net_value * MasterEntity.ex_rate);
                        MasterEntity.local_net_value = local_net_value;

                        GrandTotal = net_value + other_charges;
                        MasterEntity.total_amt = GrandTotal;

                        local_total_amt = (GrandTotal * MasterEntity.ex_rate);
                        MasterEntity.local_total_amt = local_total_amt;

                        MasterEntity.roundup_total = decimal.Round((decimal)GrandTotal);
                        local_roundup_total = (MasterEntity.roundup_total * MasterEntity.ex_rate);
                        MasterEntity.local_roundup_total = local_roundup_total;

                        MasterEntity.round_up = MasterEntity.roundup_total - GrandTotal;
                        local_round_up = (MasterEntity.round_up * MasterEntity.ex_rate);
                        MasterEntity.local_round_up = local_round_up;

                        gross_value = ItemsEntity.Where(item => item.active != false).Sum(item => item.quantity * item.unit_price);
                        MasterEntity.gross_value = gross_value;

                        effective_value = GrandTotal;
                        MasterEntity.effective_value = effective_value;

                        disc_amt = gross_value - UnTaxTotal;
                        MasterEntity.disc_amt = disc_amt;

                        if (MasterEntity.roundup_total > 0 && !string.IsNullOrWhiteSpace(MasterEntity.curr_code))
                        {
                            NumberToEnglish num = new NumberToEnglish();
                            ADM_M037 curr_obj = new ADM_M037();
                            curr_obj = ((List<ADM_M037>)AppSessionState.CurrencyList).Where(x => x.curr_code == MasterEntity.curr_code).ToList()[0];
                            MasterEntity.amt_inword = num.AmountInWords(Convert.ToDecimal(MasterEntity.roundup_total), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word);
                        }
                        else
                        { MasterEntity.amt_inword = ""; }

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
            // Validation for Quantity Item Duplication and Unit Code For Item Details
            foreach (var o in ItemsEntity)
            {
                int flag = 0;
                if (o.id == 0 && o.ItemCode != null && o.ItemCode != "")
                {
                    foreach (var p in ItemsEntity)
                    {
                        if (o.line_id == p.line_id && o.ItemCode == p.ItemCode && (o.sku?.ToString() ?? "") == (p.sku?.ToString() ?? ""))
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
                if (o.ItemCode == null || o.ItemCode == "")
                {
                    foreach (var N in ItemScheduleEntity)
                    {
                        if (N.ItemCode == o.ItemCode)
                        {
                            N.unit_code = "";
                            N.line_id = o.line_id;
                            N.ItemCode = o.ItemCode;
                        }
                    }
                }
                if (o.ItemCode != null && o.ItemCode != "" && o.Description != null)
                {
                    //if (o.quantity == null || o.quantity == 0)
                    //{
                    //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    //    showMessageService.ButtonSetup = DialogButton.Ok;
                    //    showMessageService.Caption = "Message";
                    //    showMessageService.Text = String.Format("Quantity cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                    //    showMessageService.ShowMessage();
                    //    return false;
                    //}
                    foreach (var N in ItemScheduleEntity)
                    {
                        if (N.ItemCode == o.ItemCode)
                        {
                            N.line_id = o.line_id;
                            N.unit_code = o.unit_code;
                            N.ItemCode = o.ItemCode;
                        }
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
            for (int i = 0; i < ItemsEntity.Count; i++)
            {
                decimal temp = 0;
                int flag = 0;

                for (int j = 0; j < ItemScheduleEntity.Count; j++)
                {
                    if (ItemsEntity[i].ItemCode == ItemScheduleEntity[j].ItemCode && (ItemsEntity[i].sku?.ToString() ?? "") == (ItemScheduleEntity[j].sku?.ToString() ?? ""))
                    {
                        temp = temp + Convert.ToDecimal(ItemScheduleEntity[j].sch_qty);
                        flag = 1;
                    }
                }

                //if (ItemsEntity[i].quantity != temp && flag == 1)
                //{
                //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //    showMessageService.ButtonSetup = DialogButton.Ok;
                //    showMessageService.Caption = "Message";
                //    showMessageService.Text = String.Format("Item Quantity is Not Equal to Sum of All Item Batches Quantities for Item {0} Parameter :{1} ", ItemsEntity[i].ItemCode, ItemsEntity[i].sku_desc);
                //    showMessageService.ShowMessage();
                //    breakfor = false;
                //    return false;
                //}
            }
            if (MasterEntity.sales_person_cd == null || MasterEntity.sales_person_cd == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Sales Person Is Required");
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
            if (MasterEntity.ind_trade == null || MasterEntity.ind_trade == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Transaction Type is Required");
                showMessageService.ShowMessage();

                return false;
            }
            if (MasterEntity.party_name == null || MasterEntity.party_name == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Sold To Party is Required");
                showMessageService.ShowMessage();

                return false;
            }
            if (MasterEntity.copy == true)
            {
                isNewRecord = true;
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
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
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
                html += "<tr bgcolor=#d9e6f2>";
                html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.ItemCode + "</p></span></strong></p> </td>";
                html += "<td width=10%> <p><strong><span style=color:#000080;> " + item.Description + "</span></strong></p> </td>";
                html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.quantity.ToString() + "</span></strong></p> </td>";
                html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.unit_code + "</span></strong></p> </td>";
                html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.unit_price.ToString() + "</span></strong></p> </td>";
                html += "</tr>";
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
                        new KeyValuePair<string, string>("[DOCNO]", MasterEntity.sono),
                        new KeyValuePair<string, string>("[Comp]","M/s: " +AppSessionState.CompanyName),
                        new KeyValuePair<string, string>("[TSTS]", MasterEntity.t_display),
                        new KeyValuePair<string, string>("[Attn]",VarData.EmpName),
                        new KeyValuePair<string, string>("[CUST]","M/s: " +  MasterEntity.party_name),
                        new KeyValuePair<string, string>("[CUR]",MasterEntity.curr_code.ToString()),
                        new KeyValuePair<string, string>("[OVAL]",MasterEntity.roundup_total.ToString()),
                        new KeyValuePair<string, string>("[DOCDATE]", MasterEntity.sodate.ToString()),
                        new KeyValuePair<string, string>("[MODDT]", DateTime.Now.ToString()),
                        new KeyValuePair<string, string>("[PREF]", (MasterEntity.cust_ref ?? "").ToString() + " Dated: " + (MasterEntity.cust_ref_date?.ToShortDateString())), //MasterEntity.cust_ref_date.HasValue ? MasterEntity.cust_ref_date.Value.ToString() : string.Empty;
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
        private string _filterString_RefContact;
        public string FilterString_RefContact
        {
            get { return _filterString_RefContact; }
            set
            {
                _filterString_RefContact = value;
                RaisePropertyChanged("FilterString_RefContact");
                FilterCollection_RefContact();
            }
        }
        private void FilterCollection_RefContact()
        {
            if (_RefContactPersonCollection != null)
            {
                _RefContactPersonCollection.Refresh();
            }
        }
        public bool Filter_RefContactPerson(object obj)
        {
            var data = obj as ADM_M028_C_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_RefContact))
                {
                    return (data.PersonName != null && data.PersonName.ToString().ToLower().Contains(_filterString_RefContact.ToLower()) ||
                         data.ContInfoId != null && data.ContInfoId.ToString().ToLower().Contains(_filterString_RefContact.ToLower())
                        );
                }
                return true;
            }
            return false;
        }

        private string _filterString_DocTypeBf;
        public string FilterString_DocTypeBf
        {
            get { return _filterString_DocTypeBf; }
            set
            {
                _filterString_DocType = value;
                RaisePropertyChanged("FilterString_DocTypeBf");
                FilterCollection_DocTypeBf();
            }
        }
        private void FilterCollection_DocTypeBf()
        {
            if (_doc_typeCollectionBf != null)
            {
                _doc_typeCollectionBf.Refresh();
            }
        }
        public bool Filter_DocTypeBf(object obj)
        {
            var data = obj as SYS_M002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_DocTypeBf))
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
                if (!string.IsNullOrEmpty(_filterString_FlipGrid))
                {
                    return (data.sono != null && data.sono.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.sodate != null && data.sodate.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                         (data.Seller != null && data.Seller.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.buyer_name != null && data.buyer_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.so_code != null && data.so_code.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.party_name != null && data.party_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.remark1 != null && data.remark1.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.Seller != null && data.Seller.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
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
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_Transporter.ToLower()) ||
                        data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_Transporter.ToLower()));
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

        private string _filterString_Seller;
        public string FilterString_Seller
        {
            get { return _filterString_Seller; }
            set
            {
                _filterString_Seller = value;
                RaisePropertyChanged("FilterString_Seller");
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
                if (!string.IsNullOrEmpty(_filterString_Seller))
                {
                    return (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterString_Seller.ToLower()) ||
                         data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterString_Seller.ToLower())
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
                    return (data.gl_code != null && data.gl_code.ToString().ToLower().Contains(_filterString_GLCode.ToLower()) ||
                         data.gl_name != null && data.gl_name.ToString().ToLower().Contains(_filterString_GLCode.ToLower()));
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
                            data.bank_name != null && data.bank_name.ToString().ToLower().Contains(_filterString_Banks.ToLower()) ||
                            data.acc_number != null && data.acc_number.ToString().ToLower().Contains(_filterString_Banks.ToLower())
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
                if (!string.IsNullOrEmpty(_FilterString_ReferenceDoc))
                {
                    return (data.sono != null && data.sono.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower())) ||
                           (data.cust_ref != null && data.cust_ref.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower())) ||
                           (data.party_name != null && data.party_name.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower())) ||
                           (data.sodate != null && data.sodate.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower())) ||
                           (data.sodate != null && data.sodate.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower())) ||
                           (data.para3 != null && data.para3.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()));
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
                         data.Location != null && data.Location.ToString().ToLower().Contains(_filterString_Buyer.ToLower()));

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
                         data.SrNo != null && data.SrNo.ToString().ToLower().Contains(_filterString_BillingAddress.ToLower()));
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
                        data.SrNo != null && data.SrNo.ToString().ToLower().Contains(_filterString_DeliveryAddress.ToLower()));
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
            var data = obj as ADM_M003_P;
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
                           (data.SubCatCode != null && data.SubCatCode.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            (data.item_cat_id != null && data.item_cat_id.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower()));
                }
                return true;
            }
            return false;
        }
        //pending delete if not use
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
        private void FilterReferenceDocumentNumbers(object InputValue)
        {
        }


        #endregion
    }
}
