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
using System.Windows;
using Reflection.Presentation.Controls;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using Reflection.BusinessEntity.CustomerRelation;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class SEL_T001_VM : WorkspaceViewModel<SEL_T001>
    {
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SEL_T001_VM));
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
        private AutoSuggestTextViewModel<dynamic> _ASSalesPersonView { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSalesPersonView
        {
            get { return _ASSalesPersonView; }
            set
            {
                if (_ASSalesPersonView != value)
                {
                    _ASSalesPersonView = value; RaisePropertyChanged("ASSalesPersonView");
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

        private AutoSuggestTextViewModel<dynamic> _ASSOtype { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSOtype
        {
            get { return _ASSOtype; }
            set
            {
                if (_ASSOtype != value)
                {
                    _ASSOtype = value; RaisePropertyChanged("ASSOtype");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDoctype { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDoctype
        {
            get { return _ASDoctype; }
            set
            {
                if (_ASDoctype != value)
                {
                    _ASDoctype = value; RaisePropertyChanged("ASDoctype");
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

        private AutoSuggestTextViewModel<dynamic> _ASdgTransporter { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASdgTransporter
        {
            get { return _ASdgTransporter; }
            set
            {
                if (_ASdgTransporter != value)
                {
                    _ASdgTransporter = value; RaisePropertyChanged("ASdgTransporter");
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
        private AutoSuggestTextViewModel<dynamic> _ASSchShipToParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSchShipToParty
        {
            get { return _ASSchShipToParty; }
            set
            {
                if (_ASSchShipToParty != value)
                {
                    _ASSchShipToParty = value; RaisePropertyChanged("ASSchShipToParty");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASSchShipToAdd { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSchShipToAdd
        {
            get { return _ASSchShipToAdd; }
            set
            {
                if (_ASSchShipToAdd != value)
                {
                    _ASSchShipToAdd = value; RaisePropertyChanged("ASSchShipToAdd");
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
        private AutoSuggestTextViewModel<dynamic> _ASFilterLocation { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFilterLocation
        {
            get { return _ASFilterLocation; }
            set
            {
                if (_ASFilterLocation != value)
                {
                    _ASFilterLocation = value; RaisePropertyChanged("ASFilterLocation");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASFltrt_DocType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFltrt_DocType
        {
            get { return _ASFltrt_DocType; }
            set
            {
                if (_ASFltrt_DocType != value)
                {
                    _ASFltrt_DocType = value; RaisePropertyChanged("ASFltrt_DocType");
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
        private AutoSuggestTextViewModel<dynamic> _ASCF_Agent { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCF_Agent
        {
            get { return _ASCF_Agent; }
            set
            {
                if (_ASCF_Agent != value)
                {
                    _ASCF_Agent = value; RaisePropertyChanged("ASCF_Agent");
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
                    else if (SourceName == "price_qty_uom")
                    { ASDefault = ASUOMPRICEQTY; }
                    else if (SourceName == "item_cat")
                    { ASDefault = ASItemLineCat; }
                    else if (SourceName == "PartyNm")
                    { ASDefault3 = ASdgTransporter; }
                    else if (SourceName == "ship_to_PartyNm")
                    { ASDefault3 = ASSchShipToParty; }
                    else if (SourceName == "ship_to_addNm")
                    {
                        ASDefault3 = ASSchShipToAdd;
                        FilterScheduleShipToAdd();
                    }
                    else if (SourceName == "Termscon_type")
                    { ASDefault2 = ASTermsCond; }
                    else if (SourceName == "con_type")
                    { ASDefault1 = ASConditionType; }
                    else if (SourceName == "order_to_plant")
                    { ASDefault = ASOrderTo; }
                    else if (SourceName == "para1")
                    { ASDefault = ASInk; }
                    else if (SourceName == "para5")
                    { ASDefault = ASILD; }
                    else if (SourceName == "para3")
                    { ASDefault = ASGrade; }
                    else if (SourceName == "curr_code")
                    { ASDefault1 = ASdgCurrency; }
                    else if (SourceName == "gl_code")
                    { ASDefault1 = ASTaxacc; }
                    else if (SourceName == "licence_no")
                    { ASDefault4 = ASLicence; }
                    else if (SourceName == "tr_mode")
                    { ASDefault4 = ASTR_MODE; }
                    else if (SourceName == "incoterms")
                    { ASDefault4 = ASdgIncoTerms; }
                    else if (SourceName == "buss_place")
                    { ASDefault = ASdgBussPlace; }
                    else if (SourceName == "ship_to_Party")
                    { ASDefault = ASdgShipToParty; }

                }
            }
        }
        #endregion
        #region Variable Declaration
        string PartyEmailId = "";
        string PersonEmailId = "";
        string PreviousUnitCode = "";
        string NewUnitCode = "";
        decimal? unit_price;
        string Currency = "";
        private bool AutoRoundupEnable = true;
        private int RoundUpDecimals = 2;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }
        NumberToEnglish num = new NumberToEnglish();
        WebServiceRepository<SEL_T001> repository = new WebServiceRepository<SEL_T001>();
        WebServiceRepository<MultipleContext_SEL_T001> repository_MC = new WebServiceRepository<MultipleContext_SEL_T001>();
        WebServiceRepository<MultipleContext_SEL_T001> repository_MCTemp = new WebServiceRepository<MultipleContext_SEL_T001>();
        ObjectSerializationService obj = new ObjectSerializationService();

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
        private SEL_T001_A _ItemEntityObject;
        public SEL_T001_A ItemEntityObject
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
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
        private SEL_T002_A _SelectedItemScheduleEntity;
        //Data Source for Schedule DataGrid
        public SEL_T002_A SelectedItemScheduleEntity
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
                    if (TotalDocumentTaxesItem.Count > 0 && ItemEntityObject != null) // NOTE: add Line Id code only.
                    {
                        TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>(TotalDocumentTaxes.Where(tax => tax.ItemCode == ItemEntityObject.ItemCode && (tax.sku?.ToString() ?? "") == (ItemEntityObject.sku?.ToString() ?? "") && tax.item_row_id == ItemEntityObject.id));
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
        #endregion
        #region ObservableCollection
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
        #endregion
        #region List
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
        #endregion
        #region ICollection for Popup Control
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
        private ICollectionView _ReferenceDocSNCollection;
        public ICollectionView ReferenceDocSNCollection
        {
            get { return _ReferenceDocSNCollection; }
            set { _ReferenceDocSNCollection = value; RaisePropertyChanged("ReferenceDocSNCollection"); }
        }
        private ICollectionView _ReferenceDocQNCollection;
        public ICollectionView ReferenceDocQNCollection
        {
            get { return _ReferenceDocQNCollection; }
            set { _ReferenceDocQNCollection = value; RaisePropertyChanged("ReferenceDocQNCollection"); }
        }

        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
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
        private ICollectionView _dataGridviewFilter;
        // This DataGridView filter Schedule Lines for selected item. it will show only schedule for selected item.
        public ICollectionView DataGridViewFilter
        {
            get { return _dataGridviewFilter; }
            set { _dataGridviewFilter = value; RaisePropertyChanged("DataGridViewFilter"); }
        }

        #endregion
        #region Relay Commands Declaration
        public RelayCommand<object> cmdSelectionChanged_SEL_T001_A { get; private set; }
        public RelayCommand<object> cmdSelectionChangedSchedule { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdTR_Mode { get; private set; }
        public RelayCommand<object> cmdTR_ModeMaster { get; private set; }
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
        public RelayCommand<object> cmddgLocation { get; private set; }
        public RelayCommand<object> CommandDocTypeBf { get; private set; }
        public RelayCommand<object> cmdRefContactPerson { get; private set; }
        public RelayCommand<object> cmdPlant { get; private set; }
        public RelayCommand<object> CmdLicence { get; private set; }
        public RelayCommand<object> cmdSupplier { get; private set; }
        public RelayCommand<object> cmddgTransporter { get; private set; }
        public RelayCommand<object> CommandDocType { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CommandLoadDocumentFromSource { get; private set; }
        public RelayCommand<object> CommandSoldToParty { get; private set; }
        public RelayCommand<object> CommandShipToParty { get; private set; }
        public RelayCommand<object> CommandNotifyParty { get; private set; }
        public RelayCommand<object> CommandNotifyParty2 { get; private set; }
        public RelayCommand<object> CommandTransporter { get; private set; }
        public RelayCommand<object> CommandServiceProvider { get; private set; }
        public RelayCommand<object> CommandUOM { get; private set; }
        public RelayCommand<object> CommandUOMPriceQty { get; private set; }
        public RelayCommand<object> CommandSeller { get; private set; }
        public RelayCommand<object> CommandGLCode { get; private set; }
        public RelayCommand<object> CommandPayTerms { get; private set; }
        public RelayCommand<object> CommandCurrency { get; private set; }
        public RelayCommand<object> CmddgCurrency { get; private set; }
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
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByRefDocNumber { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridTerms { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowSchedule { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowLicence { get; private set; }
        public RelayCommand<object> CommandLocations { get; private set; }
        public RelayCommand<object> CommandLicenseAdvance { get; private set; }
        public RelayCommand<object> CommandLicenseEPCG { get; private set; }
        public RelayCommand<object> CommandIncoterms { get; private set; }
        public RelayCommand<object> CmddgIncoterms { get; private set; }
        public RelayCommand<object> cmdDeleteTax { get; private set; }
        public RelayCommand<object> CommandAddSelectedTax { get; private set; }
        public RelayCommand<object> CmdCondType { get; private set; }
        public RelayCommand<object> ManualTaxChangedCommand { get; private set; }
        public RelayCommand<object> CommandGrade { get; private set; }
        public RelayCommand<object> cmdMail { get; private set; }
        public RelayCommand<object> cmdPrint { get; private set; }
        public RelayCommand<object> cmdRefDoc { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        public RelayCommand<Boolean> AddRemoveManualTax { get; private set; }
        public RelayCommand<object> CmdUnitPrice { get; private set; }
        public RelayCommand<object> CmdItemInfo { get; private set; }
        public RelayCommand<object> cmdOpenAttachments { get; private set; }
        public RelayCommand<object> cmdBussPlace { get; private set; }
        public RelayCommand<object> cmddgBussPlace { get; private set; }
        public RelayCommand<object> CmddgShipToParty { get; private set; }
        public RelayCommand<object> CmdInsert_t_status { get; private set; }
        public RelayCommand<object> CmdAddSelectedRef { get; private set; }
        public RelayCommand<object> CommandFltrDocType { get; private set; }
        public RelayCommand<object> CommandFltrStatus { get; private set; }
        public RelayCommand<object> CommandFltrSoldToParty { get; private set; }
        public RelayCommand<object> CommandFilterSeller { get; private set; }
        public RelayCommand<object> cmdSchShipToParty { get; private set; }
        public RelayCommand<object> cmdSchShipToAdd { get; private set; }
        public RelayCommand<object> CommandTermsScope { get; private set; }
        
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor for ViewModel
        /// </summary> 
        /// <param name="NA"></param>
        public SEL_T001_VM(string doc_cat, string ts_code) : base()
        {
            IsDocumentViewerShow = false;
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            MasterEntity = new SEL_T001();
            ItemsEntity = new ObservableCollection<SEL_T001_A>();
            ScheduleEntity = new SEL_T002();
            SalesUnitPriceCollection = new List<GetItemDetailsEntity>();
            SalesQFRCollection = new List<GetItemDetailsEntity>();
            SalesDispatchCollection = new List<GetItemDetailsEntity>();
            SalesProjDispatchCollection = new List<GetItemDetailsEntity>();
            ItemScheduleEntity = new ObservableCollection<SEL_T002_A>();
            LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>();
            TermsConditionEntity = new ObservableCollection<SEL_T001_E>();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
            NotificationDataCollection = new List<NotificationData>();
            ItemListForPopup = new List<SEL_T001_P_SO_ItemsList>();
            FlipGridData = new List<SEL_T001_Flip>();
            FrmDate = System.DateTime.Now;
            ToDate = System.DateTime.Now;
            MC = new MultipleContext_SEL_T001();
            MCTemp = new MultipleContext_SEL_T001();
            SEL_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            SEL_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            SEL_T002.ModelEntityUpdated += new EventHandler(ModelUpdated_ScheduleMaster);
            SEL_T002_A.ModelEntityUpdated += new EventHandler(ModelUpdated_ScheduleItem);
            //ItemEntityObject = new SEL_T001_A();
            RequestPara = new RequestParameters();
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            ItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            //LoadInitialData();
            CommandInitialization();
        }
        public SEL_T001_VM(string doc_cat, string ts_code, string doc_no) : base()
        {
            IsDocumentViewerShow = false;
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new SEL_T001();
            ItemsEntity = new ObservableCollection<SEL_T001_A>();
            ScheduleEntity = new SEL_T002();
            SalesUnitPriceCollection = new List<GetItemDetailsEntity>();
            SalesQFRCollection = new List<GetItemDetailsEntity>();
            SalesDispatchCollection = new List<GetItemDetailsEntity>();
            SalesProjDispatchCollection = new List<GetItemDetailsEntity>();
            ItemScheduleEntity = new ObservableCollection<SEL_T002_A>();
            LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>();
            TermsConditionEntity = new ObservableCollection<SEL_T001_E>();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
            NotificationDataCollection = new List<NotificationData>();
            ItemListForPopup = new List<SEL_T001_P_SO_ItemsList>();
            FlipGridData = new List<SEL_T001_Flip>();
            FrmDate = System.DateTime.Now;
            ToDate = System.DateTime.Now;
            MC = new MultipleContext_SEL_T001();
            MCTemp = new MultipleContext_SEL_T001();
            SEL_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            SEL_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            SEL_T002.ModelEntityUpdated += new EventHandler(ModelUpdated_ScheduleMaster);
            SEL_T002_A.ModelEntityUpdated += new EventHandler(ModelUpdated_ScheduleItem);
            //ItemEntityObject = new SEL_T001_A();
            RequestPara = new RequestParameters();
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            ItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            //LoadInitialData();
            CommandInitialization();
        }
        #endregion
        #region Relay Command Actions ·
        private void FilterScheduleShipToAdd()
        {
            try
            {
                if (SelectedItemScheduleEntity != null && ItemScheduleEntity != null && ItemScheduleEntity.Count > 0 && ItemsEntity != null && ItemsEntity.Count > 0 && dgSelectedIndexItem >= 0 && MC.PartysShipToAddresses != null
                    && ItemEntityObject != null)
                {
                    var temp = (from o in ItemScheduleEntity where o.ItemCode == ItemEntityObject.ItemCode select o).ToList();
                    if (temp != null && temp.Count() > 0)
                    {
                        var tempAdd = (from o in MC.PartysShipToAddresses where o.PartyId == SelectedItemScheduleEntity.ship_to_party select o);
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).Location);
                        TheFilter = (o, prefix) => (((ADM_M028_D)o).Location ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_D)o).SrNo.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                        ASSchShipToAdd = new AutoSuggestTextViewModel<dynamic>(tempAdd, TheFilter, SuggestedValue, "ship_to_addNm", "Location", true);
                        ASSchShipToAdd.AutoSuggestVM.IsEmptyValueAllowed = true;
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
                string Request = "SO_Report" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.sono;

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
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + MC.DocumentTypes[0].report_name, getParametersList(), MC.DocumentTypes[0].report_name); //QuotationMurRpt.rdlc
            }
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
                    ItemEntityObject.order_to_plant = POPUPEntityObject.location_Id;
                }
            }
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
                //string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + RequestPara.location_Id + "!@" + (RequestPara.doc_cat ?? "SO") + "!@" + (Utilities.NullIf(RequestPara.doc_type_user) ?? "") + "!@" + (Utilities.NullIf(RequestPara.t_status) ?? "") + "!@" + RequestPara.active + "!@" + (Utilities.NullIf(RequestPara.EmpId) ?? AppSessionState.EmpId) + "!@" + Utilities.NullIf(RequestPara.PartyId) + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + Convert.ToDateTime(RequestPara.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(RequestPara.ToDate).ToString("MM/dd/yyyy") + "!@" + AppSessionState.UserID + "!@" + MasterEntity.ts_code;
                string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + RequestPara.location_Id + "!@" + doc_cat_vm + "!@" + (RequestPara.doc_type ?? "") + "!@!@" + AppSessionState.UserID + "!@" + (Utilities.NullIf(RequestPara.EmpId) ?? AppSessionState.EmpId) + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + (RequestPara.PartyId ?? "") + "!@!@" + RequestPara.active + "!@" + RequestPara.t_status + "!@" + Convert.ToDateTime(RequestPara.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(RequestPara.ToDate).ToString("MM/dd/yyyy");
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, Request, "SalesOrderMaster", "CRM", "LoadAll", 0, "");

                FlipGridData = MCTemp.DocumentDataFlipGrid.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);
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
                            {
                                POPUPEntityObject = MC.DocumentTypes.Where(x => x.doc_type_user.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.doc_desc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
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
                    MasterEntity.doc_cat = POPUPEntityObject.doc_cat;
                    MasterEntity.doc_type = POPUPEntityObject.doc_type;
                    MasterEntity.doc_type_user = POPUPEntityObject.doc_type_user;
                    MasterEntity.doc_desc = POPUPEntityObject.doc_desc;
                    AutoRoundupEnable = (bool)POPUPEntityObject.auto_roundup;
                    RoundUpDecimals = (int)POPUPEntityObject.roundup_digits;
                }
            }
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
                //if (POPUPEntityObject != null && MasterEntity.doc_type_user != POPUPEntityObject.doc_type_user) // Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                //{

                if (POPUPEntityObject != null) // Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (String.IsNullOrEmpty(MasterEntity.po_no) != true || String.IsNullOrWhiteSpace(MasterEntity.po_no) != true) // Only enter in the code block if ENtity Not null.
                    {
                        if (ItemsEntity.Count > 0 && isNewRecord == false && MasterEntity.comp_code != "1")
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
                        MasterEntity.doc_cat = POPUPEntityObject.doc_cat;
                        MasterEntity.doc_type = POPUPEntityObject.doc_type;
                        MasterEntity.doc_type_user = POPUPEntityObject.doc_type_user;
                        MasterEntity.doc_desc = POPUPEntityObject.doc_desc;
                        AutoRoundupEnable = (bool)POPUPEntityObject.auto_roundup;
                        RoundUpDecimals = (int)POPUPEntityObject.roundup_digits;
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
        private void SelectionChanged_SEL_T001_A(object InputValue)
        {
            try
            {
                ItemEntityObject = (SEL_T001_A)InputValue;
                FilterScheduleDataGrid();
            }
            catch (Exception ex) { }
        }
        private void ScheduleDataGridRowSelectionChanged(object InputValue)
        {
            try
            {
                SelectedItemScheduleEntity = (SEL_T002_A)InputValue;
                //if (InputValue != null && ((IEnumerable)InputValue).Cast<SEL_T002_A>().ToList().Count > 0)
                //{
                //    SelectedItemScheduleEntity = ((IEnumerable)InputValue).Cast<SEL_T002_A>().ToList()[0];
                //}

            }
            catch (Exception ex)
            { }
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
                    LoadInitialData();
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                    AppSessionState.ViewOtherRecordAllowed = true;
                }
                else
                {
                    DefaultValues();
                    LoadInitialData();
                    DefaultValues();
                    var OrderType = (from o in MC.DocumentTypes where o.doc_cat == "SO" && o.default_doc == true select o).ToList();
                    if (OrderType.Count == 1)
                    {
                        MasterEntity.doc_type = OrderType[0].doc_type;
                        MasterEntity.doc_type_user = OrderType[0].doc_type_user;
                        MasterEntity.doc_desc = OrderType[0].doc_desc_user;
                    }
                    var tempt_display = (from o in MC.STATUS_LIST
                                         where o.t_status == MasterEntity.t_status
                                         select o).ToList();
                    MasterEntity.t_display = tempt_display[0].t_display;
                    if (MC.Banks.Where(x => x.ind_default == true && x.comp_code == MasterEntity.comp_code).ToList().Count > 0)
                    {
                        MasterEntity.bank_code = MC.Banks.Where(x => x.ind_default == true).ToList()[0].bank_code;
                        MasterEntity.bank_name = MC.Banks.Where(x => x.ind_default == true).ToList()[0].bank_name;
                        MasterEntity.hb_acc = MC.Banks.Where(x => x.ind_default == true).ToList()[0].hb_acc;
                    }
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
                        if (ItemsEntity.Count > 0 && isNewRecord == false)
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
                            MasterEntity.p_term_code = POPUPEntityObject.p_term_code;
                            MasterEntity.ship_to_party = MasterEntity.PartyId;
                            MasterEntity.ship_to_party_name = MasterEntity.party_name;
                            MasterEntity.curr_code = POPUPEntityObject.curr_code;
                            MasterEntity.symbol = POPUPEntityObject.symbol;
                            MasterEntity.gst_PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.buss_place = POPUPEntityObject.buss_place;
                            MasterEntity.j_code = POPUPEntityObject.VendorCd;
                            //MasterEntity.country_code = POPUPEntityObject.cou;
                            //string company_Country = ((List<ADM_M002_P>)AppSessionState.ADM_M002_List)[0].c;
                            //if (MasterEntity.country_code==AppSessionState.co)
                            if (MasterEntity.curr_code == Currency)
                            {
                                MasterEntity.ex_rate = 1;
                            }



                            PartyEmailId = POPUPEntityObject.EmailId;
                            RequestParameterData = "LoadSoldToPartyDetails" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + MasterEntity.PartyId;
                            //RequestParameterData = "LoadSoldToPartyDetails" + "!@" + MasterEntity.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.PartyId + "!@" + AppSessionState.client + "!@" + MasterEntity.EmpId + "!@" + AppSessionState.UserID + "!@" + MasterEntity.ts_code;
                            MCTempp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTempp, RequestParameterData, "SalesOrderMaster", "CRM", "", 0, "");

                            MC.PartysContactInfo = MCTempp.PartysContactInfo;
                            MC.PartysSoldToAddresses = MCTempp.PartysSoldToAddresses;
                            InsertShipToParty(MasterEntity.ship_to_party, false);
                            MC.ItemListPopup = MCTempp.ItemListPopup;

                            MC.TermsAndCondition = MCTempp.TermsAndCondition;

                            TermsConditionEntity = MC.TermsAndCondition;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).PersonName);
                            TheFilter = (o, prefix) => (((ADM_M028_C_P)o).PersonName ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_C_P)o).ContInfoId.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                            ASBuyer = new AutoSuggestTextViewModel<dynamic>(MC.PartysContactInfo, TheFilter, SuggestedValue, "buyer_name", true);
                            ASBuyer.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASBuyer.AutoSuggestVM.IsFreeTextAllowed = true;

                            if (MC.PartysContactInfo.Count == 1)
                            {
                                MasterEntity.buyer = 0;
                                MasterEntity.buyer_name = "";
                                PersonEmailId = "";
                                MasterEntity.buyer_name = MC.PartysContactInfo[0].PersonName;
                                MasterEntity.buyer = MC.PartysContactInfo[0].ContInfoId;
                                MasterEntity.mail_id = MC.PartysContactInfo[0].PersnEmailId;
                                PersonEmailId = MC.PartysContactInfo[0].PersnEmailId;
                                InsertBuyer(MasterEntity.buyer_name);
                            }
                            else if (MC.PartysContactInfo.Count == 0)
                            {
                                MasterEntity.buyer = 0;
                                MasterEntity.buyer_name = "";
                                PersonEmailId = "";
                            }

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).SrNo.ToString());
                            TheFilter = (o, prefix) => (((ADM_M028_D)o).SrNo.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_D)o).SrNo.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                            ASBillAdddress = new AutoSuggestTextViewModel<dynamic>(MC.PartysSoldToAddresses, TheFilter, SuggestedValue, "bill_address_id", true);
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
                                if (MasterEntity.country_code == ((List<ADM_M002>)AppSessionState.ADM_M002_List).Where(x => x.comp_code.Equals(MasterEntity.comp_code, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].country_code)
                                {
                                    MasterEntity.ind_trade = "D";
                                }
                                else
                                {
                                    MasterEntity.ind_trade = "E";
                                }
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
                            //SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P_SO_ItemsList)x).ItemCode);
                            //TheFilter = (o, prefix) => (((SEL_T001_P_SO_ItemsList)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SEL_T001_P_SO_ItemsList)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
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
                        showMessageService.Text = String.Format("If You Change The Party Items Will be removed if Catlog Present'{0}'", this.Title);
                        if (showMessageService.ShowMessage() == DialogResult.Ok)
                        {

                            MasterEntity.PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.party_name = POPUPEntityObject.PartyNm;
                            MasterEntity.p_term_code = POPUPEntityObject.p_term_code;
                            MasterEntity.ship_to_party = MasterEntity.PartyId;
                            MasterEntity.ship_to_party_name = MasterEntity.party_name;
                            MasterEntity.curr_code = POPUPEntityObject.curr_code;
                            MasterEntity.symbol = POPUPEntityObject.symbol;
                            MasterEntity.gst_PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.buss_place = POPUPEntityObject.buss_place;
                            MasterEntity.j_code = POPUPEntityObject.VendorCd;
                            if (MasterEntity.curr_code == Currency)
                            {
                                MasterEntity.ex_rate = 1;
                            }

                            PartyEmailId = POPUPEntityObject.EmailId;
                            //RequestParameterData = "LoadSoldToPartyDetails" + "!@" + MasterEntity.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.PartyId + "!@" + AppSessionState.client + "!@" + MasterEntity.EmpId + "!@" + AppSessionState.UserID + "!@" + MasterEntity.ts_code; 
                            RequestParameterData = "LoadSoldToPartyDetails" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + MasterEntity.PartyId;
                            MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, RequestParameterData, "SalesOrderMaster", "CRM", "", 0, "");

                            MC.PartysContactInfo = MCTemp.PartysContactInfo;
                            MC.PartysSoldToAddresses = MCTemp.PartysSoldToAddresses;
                            InsertShipToParty(MasterEntity.ship_to_party, false);
                            MC.ItemListPopup = MCTemp.ItemListPopup;

                            MC.TermsAndCondition = MCTemp.TermsAndCondition;
                            TermsConditionEntity = MC.TermsAndCondition;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).PersonName);
                            TheFilter = (o, prefix) => (((ADM_M028_C_P)o).PersonName ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_C_P)o).ContInfoId.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                            ASBuyer = new AutoSuggestTextViewModel<dynamic>(MC.PartysContactInfo, TheFilter, SuggestedValue, "buyer_name", true);
                            ASBuyer.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASBuyer.AutoSuggestVM.IsFreeTextAllowed = true;

                            if (MC.PartysContactInfo.Count == 1)
                            {
                                MasterEntity.buyer = 0;
                                MasterEntity.buyer_name = "";
                                PersonEmailId = "";

                                MasterEntity.buyer_name = MC.PartysContactInfo[0].PersonName;
                                MasterEntity.buyer = MC.PartysContactInfo[0].ContInfoId;
                                PersonEmailId = MC.PartysContactInfo[0].PersnEmailId;
                                InsertBuyer(MasterEntity.buyer_name);
                            }
                            else if (MC.PartysContactInfo.Count == 0)
                            {
                                MasterEntity.buyer = 0;
                                MasterEntity.buyer_name = "";
                                PersonEmailId = "";
                            }

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).SrNo.ToString());
                            TheFilter = (o, prefix) => (((ADM_M028_D)o).SrNo.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_D)o).SrNo.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                            ASBillAdddress = new AutoSuggestTextViewModel<dynamic>(MC.PartysSoldToAddresses, TheFilter, SuggestedValue, "bill_address_id", true);
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
                                if (MasterEntity.country_code == ((List<ADM_M002>)AppSessionState.ADM_M002_List).Where(x => x.comp_code.Equals(MasterEntity.comp_code, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].country_code)
                                {
                                    MasterEntity.ind_trade = "D";
                                }
                                else
                                {
                                    MasterEntity.ind_trade = "E";
                                }
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
                            InsertBuyer(MasterEntity.buyer_name);
                            PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListPopup);
                            PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                            //SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P_SO_ItemsList)x).ItemCode);
                            //TheFilter = (o, prefix) => (((SEL_T001_P_SO_ItemsList)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SEL_T001_P_SO_ItemsList)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                            //ASItems = new AutoSuggestTextViewModel<dynamic>(MC.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                            //ASItems.AutoSuggestVM.IsEmptyValueAllowed = true;
                            //ASItems.AutoSuggestVM.IsFreeTextAllowed = true;

                            TermsConditionEntity = MC.TermsAndCondition;
                            TermsConditionCollection = CollectionViewSource.GetDefaultView(MC.TermsConditionCollection);

                            var catlogList = (from o in MCTemp.ItemListPopup
                                              where (o.cstmr_itemcode != "")
                                              select o).ToList();

                            if (catlogList.Count > 0)
                            {
                                ItemsEntity.Clear();
                                ItemScheduleEntity.Clear();
                                LicenceDetailsEntity.Clear();
                            }

                        }
                        else
                        {
                            MasterEntity.PartyId = MasterEntity.PartyId;
                        }
                    }

                    else if (isNewRecord == true && MasterEntity.party_name != POPUPEntityObject.PartyNm)
                    {
                        MasterEntity.PartyId = POPUPEntityObject.PartyId;
                        MasterEntity.party_name = POPUPEntityObject.PartyNm;
                        MasterEntity.p_term_code = POPUPEntityObject.p_term_code;
                        MasterEntity.ship_to_party = MasterEntity.PartyId;
                        MasterEntity.ship_to_party_name = MasterEntity.party_name;
                        MasterEntity.curr_code = POPUPEntityObject.curr_code;
                        MasterEntity.symbol = POPUPEntityObject.symbol;
                        MasterEntity.gst_PartyId = POPUPEntityObject.PartyId;
                        MasterEntity.buss_place = POPUPEntityObject.buss_place;
                        MasterEntity.country_code = POPUPEntityObject.country_code;
                        MasterEntity.j_code = POPUPEntityObject.VendorCd;
                        //var OrderType = (from o in ((List<ADM_M002_P>)AppSessionState.ADM_M002_List) where o.comp_code == MasterEntity.comp_code select o).ToList()[0].country_code;
                        //string company_Country = ((List<ADM_M002_P>)AppSessionState.ADM_M002_List)[0].country_code;
                        if (MasterEntity.curr_code == Currency)
                        {
                            MasterEntity.ex_rate = 1;
                        }
                        PartyEmailId = POPUPEntityObject.EmailId;

                        RequestParameterData = "LoadSoldToPartyDetails" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + MasterEntity.PartyId;
                        //RequestParameterData = "LoadSoldToPartyDetails" + "!@" + MasterEntity.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.PartyId + "!@" + AppSessionState.client + "!@" + MasterEntity.EmpId + "!@" + AppSessionState.UserID + "!@" + MasterEntity.ts_code; 
                        MCTempp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTempp, RequestParameterData, "SalesOrderMaster", "CRM", "", 0, "");

                        MC.PartysContactInfo = MCTempp.PartysContactInfo;
                        MC.PartysSoldToAddresses = MCTempp.PartysSoldToAddresses;
                        InsertShipToParty(MasterEntity.ship_to_party, false);
                        MC.ItemListPopup = MCTempp.ItemListPopup;

                        MC.TermsAndCondition = MCTempp.TermsAndCondition;

                        TermsConditionEntity = MC.TermsAndCondition;

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).PersonName);
                        TheFilter = (o, prefix) => (((ADM_M028_C_P)o).PersonName ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_C_P)o).ContInfoId.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                        ASBuyer = new AutoSuggestTextViewModel<dynamic>(MC.PartysContactInfo, TheFilter, SuggestedValue, "buyer_name", true);
                        ASBuyer.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASBuyer.AutoSuggestVM.IsFreeTextAllowed = true;

                        if (MC.PartysContactInfo.Count == 1)
                        {
                            MasterEntity.buyer = 0;
                            MasterEntity.buyer_name = "";
                            PersonEmailId = "";
                            MasterEntity.buyer_name = MC.PartysContactInfo[0].PersonName;
                            MasterEntity.buyer = MC.PartysContactInfo[0].ContInfoId;
                            MasterEntity.mail_id = MC.PartysContactInfo[0].PersnEmailId;
                            PersonEmailId = MC.PartysContactInfo[0].PersnEmailId;
                            InsertBuyer(MasterEntity.buyer_name);
                        }
                        else if (MC.PartysContactInfo.Count == 0)
                        {
                            MasterEntity.buyer = 0;
                            MasterEntity.buyer_name = "";
                            PersonEmailId = "";
                        }


                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).SrNo.ToString());
                        TheFilter = (o, prefix) => (((ADM_M028_D)o).SrNo.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_D)o).SrNo.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                        ASBillAdddress = new AutoSuggestTextViewModel<dynamic>(MC.PartysSoldToAddresses, TheFilter, SuggestedValue, "bill_address_id", true);
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
                            if (MasterEntity.country_code == ((List<ADM_M002>)AppSessionState.ADM_M002_List).Where(x => x.comp_code.Equals(MasterEntity.comp_code, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].country_code)
                            {
                                MasterEntity.ind_trade = "D";
                            }
                            else
                            {
                                MasterEntity.ind_trade = "E";
                            }
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
                                if (MasterEntity.country_code == ((List<ADM_M002>)AppSessionState.ADM_M002_List).Where(x => x.comp_code.Equals(MasterEntity.comp_code, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].country_code)
                                {
                                    MasterEntity.ind_trade = "D";
                                }
                                else
                                {
                                    MasterEntity.ind_trade = "E";
                                }
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
                        InsertBuyer(MasterEntity.buyer_name);
                        PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListPopup);
                        PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);

                        //SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P_SO_ItemsList)x).ItemCode);
                        //TheFilter = (o, prefix) => (((SEL_T001_P_SO_ItemsList)o).ItemCode ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower()) || (((SEL_T001_P_SO_ItemsList)o).ItemName ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower());
                        //ASItems = new AutoSuggestTextViewModel<dynamic>(MC.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                        //ASItems.AutoSuggestVM.IsEmptyValueAllowed = true;
                        //ASItems.AutoSuggestVM.IsFreeTextAllowed = true;

                        TermsConditionEntity = MC.TermsAndCondition;
                        TermsConditionCollection = CollectionViewSource.GetDefaultView(MC.TermsConditionCollection);

                    }


                    List<ACC_M013_P> tempTax = new List<ACC_M013_P>();
                    if (MasterEntity.buss_place == ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(x => x.comp_code.Equals(MasterEntity.comp_code, StringComparison.OrdinalIgnoreCase) == true && x.location_Id.Equals(MasterEntity.location_Id, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].buss_place)
                    {
                        tempTax = SelectedTaxList.Where(T => T.base_code_id == 1 || T.base_code_id == 2 || T.base_code_id == null).ToList();
                        TaxDictoneryParent = tempTax.ToDictionary(X => X.id.ToString(), X => (object)X.description);
                    }
                    else if (MasterEntity.buss_place != ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(x => x.comp_code.Equals(MasterEntity.comp_code, StringComparison.OrdinalIgnoreCase) == true && x.location_Id.Equals(MasterEntity.location_Id, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].buss_place)
                    {
                        tempTax = SelectedTaxList.Where(T => T.base_code_id == 3 || T.base_code_id == null).ToList();
                        TaxDictoneryParent = tempTax.ToDictionary(X => X.id.ToString(), X => (object)X.description);
                    }
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
                    MasterEntity.ship_to_party = POPUPEntityObject.PartyId;
                    MasterEntity.ship_to_party_name = POPUPEntityObject.PartyNm;

                    if (MasterEntity.PartyId != MasterEntity.ship_to_party) //&& (MasterEntity.ship_to_party != POPUPEntityObject.PartyId || MasterEntity.ship_to_party_name != POPUPEntityObject.PartyNm)
                    {
                        RequestParameterData = "LoadShipToPartyDetails" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + MasterEntity.ship_to_party;
                        //RequestParameterData = "LoadShipToPartyDetails" + "!@" + MasterEntity.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.ship_to_party + "!@" + AppSessionState.client + "!@" + MasterEntity.EmpId + "!@" + AppSessionState.UserID + "!@" + MasterEntity.ts_code; 
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, RequestParameterData, "SalesOrderMaster", "CRM", "", 0, "");
                        MC.PartysShipToAddresses = MCTemp.PartysShipToAddresses;

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).SrNo.ToString());
                        TheFilter = (o, prefix) => (((ADM_M028_D)o).SrNo.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_D)o).SrNo.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                        ASDeliveryAdddress = new AutoSuggestTextViewModel<dynamic>(MC.PartysShipToAddresses, TheFilter, SuggestedValue, "del_address", true);
                        ASDeliveryAdddress.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASDeliveryAdddress.AutoSuggestVM.IsFreeTextAllowed = true;

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

                                MasterEntity.del_address = DeliveryAddress[0].SrNo;
                                MasterEntity.delivery_address = DeliveryAddress[0].Location;
                                MasterEntity.country_nm_s = DeliveryAddress[0].CntryName;
                                MasterEntity.state_nm_s = DeliveryAddress[0].StatName;
                                MasterEntity.city_s = DeliveryAddress[0].City;
                                MasterEntity.address1_s = DeliveryAddress[0].Add1;
                                MasterEntity.address2_s = DeliveryAddress[0].Add2;
                                MasterEntity.pincode_s = DeliveryAddress[0].PinCode;
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
                    else if (MasterEntity.PartyId == POPUPEntityObject.PartyId) //&& (MasterEntity.ship_to_party != POPUPEntityObject.PartyId || MasterEntity.ship_to_party_name != POPUPEntityObject.PartyNm)
                    {
                        MC.PartysShipToAddresses = MC.PartysSoldToAddresses;

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).SrNo.ToString());
                        TheFilter = (o, prefix) => (((ADM_M028_D)o).SrNo.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_D)o).SrNo.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                        ASDeliveryAdddress = new AutoSuggestTextViewModel<dynamic>(MC.PartysShipToAddresses, TheFilter, SuggestedValue, "del_address", true);
                        ASDeliveryAdddress.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASDeliveryAdddress.AutoSuggestVM.IsFreeTextAllowed = true;

                        var DeliveryAddress = MC.PartysShipToAddresses;
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
        private void InsertNotifyParty2(object InputValue, bool OverrideValue)
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
                    MasterEntity.notify_party2 = POPUPEntityObject.PartyId;
                    MasterEntity.notify_party_name2 = POPUPEntityObject.PartyNm;
                }
            }
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
                if (POPUPEntityObject != null && ItemEntityObject != null) //&& MasterEntity.PartyId != POPUPEntityObject.PartyId) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    ItemEntityObject.para3 = POPUPEntityObject.grade_code;

                }
            }
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
                if (POPUPEntityObject != null && ItemEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {

                    ItemEntityObject.PartyId = POPUPEntityObject.PartyId;
                    ItemEntityObject.PartyNm = POPUPEntityObject.PartyNm;

                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }

        private void InsertdgTransporter(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                dgSelectedIndexItemSchedule = dgSelectedIndexItemSchedule;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Transporters.Where(x => x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                }

                #endregion


                if (POPUPEntityObject != null)
                {
                    if (dgSelectedIndexItemSchedule >= 0 && ItemScheduleEntity.Count > dgSelectedIndexItemSchedule) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        SelectedItemScheduleEntity.PartyId = POPUPEntityObject.PartyId;
                        SelectedItemScheduleEntity.PartyNm = POPUPEntityObject.PartyNm;
                        SelectedItemScheduleEntity.tr_party = POPUPEntityObject.PartyId;
                        SelectedItemScheduleEntity.PartyNm = POPUPEntityObject.PartyNm;
                    }
                }
                #region Clear Empty Row
                SEL_T002_A newObj = new SEL_T002_A();
                for (int i = ItemScheduleEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemScheduleEntity[i].ComparePropertiesTo(newObj);
                    if (ItemScheduleEntity[i].ComparePropertiesTo(newObj) == true && ItemScheduleEntity.Count > 1)
                    {
                        ItemScheduleEntity.RemoveAt(i);
                        if (ItemScheduleEntity.Count == 0)
                        {
                            ItemScheduleEntity.Add(newObj);
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
                    RequestParameterData = "LoadRefferingPartyDetails" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + MasterEntity.referring_party;
                    //RequestParameterData = "LoadRefferingPartyDetails" + "!@" + MasterEntity.referring_party + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.EmpId + "!@" + AppSessionState.UserID +"!@"+ MasterEntity.ts_code;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, RequestParameterData, "SalesOrderMaster", "CRM", "", 0, "");

                    MC.RefPartyContactInfo = MCTemp.RefPartyContactInfo;

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).PersonName);
                    TheFilter = (o, prefix) => ((ADM_M028_C_P)o).PersonName.ToString().ToLower().Contains(prefix.ToLower());
                    ASRefContPerson = new AutoSuggestTextViewModel<dynamic>(MC.RefPartyContactInfo, TheFilter, SuggestedValue, "ref_contact_name", true);

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
            }
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
                            { POPUPEntityObject = MC.PartysSoldToAddresses.Where(x => x.SrNo.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.Location.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.country_code = POPUPEntityObject.country_code;
                    if (MasterEntity.country_code == ((List<ADM_M002>)AppSessionState.ADM_M002_List).Where(x => x.comp_code.Equals(MasterEntity.comp_code, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].country_code)
                    {
                        MasterEntity.ind_trade = "D";
                    }
                    else
                    {
                        MasterEntity.ind_trade = "E";
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
                            { POPUPEntityObject = MC.PartysShipToAddresses.Where(x => x.SrNo.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.Location.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                            { POPUPEntityObject = MC.Sellers.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.EmpName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
        private void InsertFilterSeller(object InputValue)
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
                            { POPUPEntityObject = MC.Sellers.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.EmpName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.fltr_SalesPersonID = POPUPEntityObject.EmpId;
                    MasterEntity.fltr_SalesPersonNM = POPUPEntityObject.EmpName;
                }
            }
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


                if (POPUPEntityObject != null && ItemEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
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
                string RequestParameterData = "";
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

                if (POPUPEntityObject != null && ItemEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        ItemEntityObject.ship_to_Party = POPUPEntityObject.PartyId;
                        ItemEntityObject.ship_to_add = POPUPEntityObject.ship_to_add;

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
        private void InsertSchShipToParty(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                string RequestParameterData = "";
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
                        {
                            POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true
                                                                  || x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null && ItemEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    List<SEL_T002_A> temp = ItemScheduleEntity.ToList();
                    temp = ItemScheduleEntity.Where(x => x.ItemCode == ItemEntityObject.ItemCode).ToList();

                    if (temp.Count > dgSelectedIndexItemSchedule) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        SelectedItemScheduleEntity.ship_to_party = POPUPEntityObject.PartyId;
                        SelectedItemScheduleEntity.ship_to_party_name = POPUPEntityObject.PartyNm;
                        RequestParameterData = "LoadShipToPartyDetails" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + SelectedItemScheduleEntity.ship_to_party;
                        //RequestParameterData = "LoadShipToPartyDetails" + "!@" + MasterEntity.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + SelectedItemScheduleEntity.ship_to_party + "!@" + AppSessionState.client + "!@" + MasterEntity.EmpId + "!@" + AppSessionState.UserID + "!@" + MasterEntity.ts_code;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, RequestParameterData, "SalesOrderMaster", "CRM", "", 0, "");
                        foreach (var item in MCTemp.PartysShipToAddresses)
                        {
                            int IndexOfExistValue = MC.PartysShipToAddresses.IndexOf(MC.PartysShipToAddresses.Where(X => X.PartyId == POPUPEntityObject.PartyId).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.
                            if (IndexOfExistValue == -1)
                            {
                                MC.PartysShipToAddresses.Add(item);
                            }
                        }

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).Location);
                        TheFilter = (o, prefix) => (((ADM_M028_D)o).Location ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_D)o).SrNo.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                        ASSchShipToAdd = new AutoSuggestTextViewModel<dynamic>(MCTemp.PartysShipToAddresses, TheFilter, SuggestedValue, "ship_to_addNm", "Location", true);
                        ASSchShipToAdd.AutoSuggestVM.IsEmptyValueAllowed = true;

                        if (MCTemp.PartysShipToAddresses.Count == 0)
                        {
                            SelectedItemScheduleEntity.ship_to_add = null;
                            SelectedItemScheduleEntity.ship_to_addNm = "";
                        }
                        if (MCTemp.PartysShipToAddresses.Count == 1)
                        {
                            SelectedItemScheduleEntity.ship_to_add = "";
                            SelectedItemScheduleEntity.ship_to_addNm = "";

                            SelectedItemScheduleEntity.ship_to_add = MCTemp.PartysShipToAddresses[0].SrNo.ToString();
                            SelectedItemScheduleEntity.ship_to_addNm = MCTemp.PartysShipToAddresses[0].Location;
                        }
                        else if (MCTemp.PartysShipToAddresses.Count > 1)
                        {
                            SelectedItemScheduleEntity.ship_to_add = "";
                            SelectedItemScheduleEntity.ship_to_addNm = "";

                            var DeliveryAddress = (from o in MCTemp.PartysShipToAddresses where o.AddType == "Delivery Address" select o).ToList();
                            if (DeliveryAddress.Count == 0)
                            {
                                SelectedItemScheduleEntity.ship_to_add = "";
                                SelectedItemScheduleEntity.ship_to_addNm = "";
                            }
                            else if (DeliveryAddress.Count == 1)
                            {
                                SelectedItemScheduleEntity.ship_to_add = "";
                                SelectedItemScheduleEntity.ship_to_addNm = "";

                                SelectedItemScheduleEntity.ship_to_add = DeliveryAddress[0].SrNo.ToString();
                                SelectedItemScheduleEntity.ship_to_addNm = DeliveryAddress[0].Location;
                            }
                            else if (DeliveryAddress.Count > 1)
                            {
                                SelectedItemScheduleEntity.ship_to_add = "";
                                SelectedItemScheduleEntity.ship_to_addNm = "";

                            }
                        }
                    }

                    #region Clear Empty Row
                    SEL_T002_A newObj = new SEL_T002_A();
                    for (int i = ItemScheduleEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = ItemScheduleEntity[i].ComparePropertiesTo(newObj);
                        if (ItemScheduleEntity[i].ComparePropertiesTo(newObj) == true && ItemScheduleEntity.Count > 1)
                        {
                            ItemScheduleEntity.RemoveAt(i);
                            if (ItemScheduleEntity.Count == 0)
                            {
                                ItemScheduleEntity.Add(newObj);
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
        private void InsertSchShipToAddress(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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

                if (POPUPEntityObject != null && ItemEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {

                    List<SEL_T002_A> temp = ItemScheduleEntity.ToList();
                    temp = ItemScheduleEntity.Where(x => x.ItemCode == ItemEntityObject.ItemCode).ToList();

                    if (dgSelectedIndexItemSchedule >= 0 && temp.Count > dgSelectedIndexItemSchedule) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        SelectedItemScheduleEntity.ship_to_add = POPUPEntityObject.SrNo.ToString();
                        SelectedItemScheduleEntity.ship_to_addNm = POPUPEntityObject.Location;

                    }
                }
                #region Clear Empty Row
                SEL_T002_A newObj = new SEL_T002_A();
                for (int i = ItemScheduleEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemScheduleEntity[i].ComparePropertiesTo(newObj);
                    if (ItemScheduleEntity[i].ComparePropertiesTo(newObj) == true && ItemScheduleEntity.Count > 1)
                    {
                        ItemScheduleEntity.RemoveAt(i);
                        if (ItemScheduleEntity.Count == 0)
                        {
                            ItemScheduleEntity.Add(newObj);
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
                            { POPUPEntityObject = SalesOrganisationList.Where(x => x.so_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.sales_org.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                            { POPUPEntityObject = SalesGroupList.Where(x => x.sg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.sg_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    SelectedItemScheduleEntity.tr_mode = POPUPEntityObject.tr_mode;
                    SelectedItemScheduleEntity.tr_name = POPUPEntityObject.tr_name;
                }
            }
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
                    MasterEntity.hb_acc = POPUPEntityObject.hb_acc;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
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
                            {
                                POPUPEntityObject = MC.PartysContactInfo.Where(x => x.PersonName.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.PersonName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }

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
                    MasterEntity.mail_id = POPUPEntityObject.PersnEmailId;
                    MasterEntity.mobile_no = POPUPEntityObject.PersnMobNo;
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
                        {
                            POPUPEntityObject = MC.ItemListPopup.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.ItemName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
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
                    dgSelectedIndexItem = ItemsEntity.Count;
                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                    {
                        ItemsEntity.Add(new SEL_T001_A()
                        {
                            id = 0,
                            ItemCode = POPUPEntityObject.ItemCode,
                            Description = POPUPEntityObject.ItemName,
                            CstmrItmCod = POPUPEntityObject.CstmrItmCod,
                            active = true,
                            line_id = LineId,
                            location_Id = AppSessionState.location_Id,
                            ref_doc_no = MasterEntity.ref_doc_no,
                            ref_doc_type = MasterEntity.ref_doc_type,
                            sku = POPUPEntityObject.sku,
                            sku_desc = POPUPEntityObject.sku_desc,
                            tax_id = POPUPEntityObject.tax_id,
                            unit_code = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM,
                            unit_price = String.IsNullOrEmpty(POPUPEntityObject.Rate_Catlog.ToString()) ? POPUPEntityObject.rate : POPUPEntityObject.Rate_Catlog,
                            comp_code = MasterEntity.comp_code,
                            item_cat = POPUPEntityObject.item_cat_id,
                            para9 = POPUPEntityObject.needledia,
                            para10 = POPUPEntityObject.needleangle,
                            para11 = POPUPEntityObject.needlelen,
                            SubCatCode = POPUPEntityObject.SubCatCode,
                            StockUnt = POPUPEntityObject.StockUnt,
                            ship_to_Party = MasterEntity.ship_to_party,
                            ship_to_add = MasterEntity.del_address,
                            buss_place = MasterEntity.buss_place,
                            t_status = MasterEntity.t_status,
                            t_display = MasterEntity.t_display,
                            price_qty = String.IsNullOrEmpty(POPUPEntityObject.Rate_Catlog.ToString()) ? POPUPEntityObject.rate : POPUPEntityObject.Rate_Catlog,
                            qty_price = 1,
                            price_qty_uom = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM,
                            weight_unit = POPUPEntityObject.weight_unit,
                            volume_unit = POPUPEntityObject.volume_unit,

                        });
                        MasterEntity.weight_unit = POPUPEntityObject.weight_unit;
                        MasterEntity.volume_unit = POPUPEntityObject.volume_unit;
                        dgSelectedIndexItem = ItemsEntity.Count - 1;
                        if (dgSelectedIndexItem >= 0 && dgSelectedIndexItem <= ItemsEntity.Count && POPUPEntityObject.item_cat_id == "SIC" && MasterEntity.doc_type != "OP" && ItemEntityObject != null)
                        {
                            SEL_T002_A ItemObject = new SEL_T002_A();
                            ItemObject.sch_cat = "SD";
                            ItemObject.del_rel = "Y";
                            ItemObject.item_line_id = ItemEntityObject.line_id;
                            ItemObject.sono = MasterEntity.sono;
                            ItemObject.line_id = ItemScheduleEntity.Count;
                            ItemObject.ItemCode = POPUPEntityObject.ItemCode;
                            ItemObject.unit_code = POPUPEntityObject.unit_code;
                            //ItemObject.sch_qty = ItemEntityObject.quantity ?? 0;

                            ItemObject.sku = POPUPEntityObject.sku;
                            ItemObject.exp_date = MasterEntity.expect_date;
                            ItemObject.desp_date = MasterEntity.expect_date;
                            ItemObject.t_status = ItemEntityObject.t_status;
                            ItemObject.t_display = ItemEntityObject.t_display;
                            ItemObject.active = true;
                            ItemObject.editby = AppSessionState.UserID;
                            ItemObject.add_by = AppSessionState.UserID;
                            ItemObject.location_Id = AppSessionState.location_Id;
                            ItemObject.comp_code = MasterEntity.comp_code;
                            //ItemObject.rate = ItemEntityObject.unit_price; 

                            ItemObject.rel_delivery = "Y";
                            ItemObject.rel_billing = "Y";
                            ItemObject.so_item_id = ItemEntityObject.id;
                            ItemObject.order_qty = ItemEntityObject.quantity ?? 0;
                            ItemObject.sch_date = MasterEntity.sodate;
                            ItemObject.tr_mode = MasterEntity.tr_mode;
                            ItemObject.tr_name = MasterEntity.tr_name;
                            ItemObject.tr_type = MasterEntity.tr_type;
                            ItemObject.tr_party = MasterEntity.tr_party;
                            ItemObject.ref_doc_cat = MasterEntity.doc_cat;
                            ItemObject.ref_doc_no = MasterEntity.sono;
                            ItemObject.ref_doc_date = MasterEntity.sodate;
                            ItemObject.ref_doc_type = MasterEntity.ref_doc_type;
                            ItemObject.ship_to_party = MasterEntity.ship_to_party;
                            ItemObject.ship_to_add = MasterEntity.del_address.ToString();
                            ItemObject.ship_to_addNm = MasterEntity.delivery_address;
                            ItemObject.PartyNm = ItemScheduleEntity.Count > 0 ? ItemScheduleEntity[0].PartyNm : MasterEntity.TranParty_name;
                            ItemObject.ship_mode = ItemScheduleEntity.Count > 0 ? ItemScheduleEntity[0].ship_mode : MasterEntity.ship_mode;
                            ItemObject.para1 = ItemScheduleEntity.Count > 0 ? ItemScheduleEntity[0].para1 : MasterEntity.para1; // ItemScheduleEntity[0].para1;
                            ItemObject.PartyId = ItemScheduleEntity.Count > 0 ? MasterEntity.transporter_cd : MasterEntity.transporter_cd;
                            ItemObject.lead_time = 1;
                            ItemScheduleEntity.Add(ItemObject);
                            ItemObject.ref_no = MasterEntity.sono; //santosh
                            ItemObject.del_qty = ItemScheduleEntity[0].bal_qty;
                            ItemObject.sch_qty = ItemScheduleEntity[0].bal_qty;
                            ItemObject.rate = ItemEntityObject.price_qty;
                            //ItemScheduleEntity.Add(new SEL_T002_A()
                            //{
                            //    sch_cat = "SD",
                            //    del_rel ="Y",
                            //    item_line_id= ItemEntityObject.line_id,
                            //    sono = MasterEntity.sono,
                            //    //ref_doc_no = POPUPEntityObject.
                            //    line_id = ItemScheduleEntity.Count,
                            //    ItemCode = POPUPEntityObject.ItemCode,
                            //    unit_code = POPUPEntityObject.unit_code,
                            //    sch_qty = ItemEntityObject.quantity ?? 0,
                            //    sku = POPUPEntityObject.sku,
                            //    exp_date = MasterEntity.expect_date,
                            //    desp_date = MasterEntity.expect_date,
                            //    t_status = ItemEntityObject.t_status,
                            //    t_display = ItemEntityObject.t_display,
                            //    active = true,
                            //    editby = AppSessionState.UserID,
                            //    add_by = AppSessionState.UserID,
                            //    location_Id = AppSessionState.location_Id,
                            //    comp_code = MasterEntity.comp_code,
                            //    rate = ItemEntityObject.unit_price,
                            //    rel_delivery = "Y",
                            //    rel_billing="Y",
                            //    so_item_id = ItemEntityObject.id,
                            //    order_qty = ItemEntityObject.quantity ?? 0,
                            //    sch_date = MasterEntity.sodate,
                            //    tr_mode=MasterEntity.tr_mode,
                            //    tr_name = MasterEntity.tr_name,
                            //    tr_type=MasterEntity.tr_type,
                            //    tr_party=MasterEntity.tr_party,
                            //    ref_doc_cat = MasterEntity.doc_cat,
                            //    ref_doc_no=MasterEntity.sono,
                            //    ref_doc_date=MasterEntity.sodate,
                            //    ref_doc_type=MasterEntity.ref_doc_type,
                            //    ship_to_party = MasterEntity.ship_to_party,
                            //    ship_to_add = MasterEntity.del_address.ToString(),
                            //    ship_to_addNm = MasterEntity.delivery_address,
                            //    PartyNm = ItemScheduleEntity.Count > 0 ? ItemScheduleEntity[0].PartyNm : MasterEntity.TranParty_name,
                            //    ship_mode = ItemScheduleEntity.Count > 0 ? ItemScheduleEntity[0].ship_mode : MasterEntity.ship_mode,
                            //    para1 = ItemScheduleEntity.Count > 0 ? ItemScheduleEntity[0].para1 : ItemScheduleEntity[0].para1,
                            //    PartyId = ItemScheduleEntity.Count > 0 ? MasterEntity.transporter_cd : MasterEntity.transporter_cd,
                            //    lead_time = 1,
                            //});
                        }
                        dgSelectedIndexItem = ItemsEntity.Count + 1;
                    }
                    else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem && ItemEntityObject != null) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemEntityObject.id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            if (ItemEntityObject.line_id == 0)
                            {
                                ItemEntityObject.line_id = ItemsEntity.Count;
                            }
                            ItemEntityObject.ItemCode = POPUPEntityObject.ItemCode;
                            ItemEntityObject.Description = POPUPEntityObject.ItemName;
                            ItemEntityObject.CstmrItmCod = POPUPEntityObject.CstmrItmCod;
                            ItemEntityObject.active = true;
                            ItemEntityObject.quotation_no = MasterEntity.quotation_no;
                            ItemEntityObject.ref_doc_no = MasterEntity.ref_doc_no;
                            ItemEntityObject.ref_doc_type = MasterEntity.ref_doc_type;
                            ItemEntityObject.sku = POPUPEntityObject.sku;
                            ItemEntityObject.sku_desc = POPUPEntityObject.sku_desc;
                            ItemEntityObject.tax_id = POPUPEntityObject.tax_id;
                            ItemEntityObject.unit_code = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM;
                            ItemEntityObject.unit_price = String.IsNullOrEmpty(POPUPEntityObject.Rate_Catlog.ToString()) ? POPUPEntityObject.rate : POPUPEntityObject.Rate_Catlog;
                            ItemEntityObject.location_Id = AppSessionState.location_Id;
                            ItemEntityObject.comp_code = MasterEntity.comp_code;
                            ItemEntityObject.item_cat = POPUPEntityObject.item_cat_id;
                            ItemEntityObject.para9 = POPUPEntityObject.needledia;
                            ItemEntityObject.para10 = POPUPEntityObject.needleangle;
                            ItemEntityObject.para11 = POPUPEntityObject.needlelen;
                            ItemEntityObject.SubCatCode = POPUPEntityObject.SubCatCode;
                            ItemEntityObject.StockUnt = POPUPEntityObject.StockUnt;
                            ItemEntityObject.t_status = MasterEntity.t_status;
                            ItemEntityObject.t_display = MasterEntity.t_display;
                            ItemEntityObject.order_to_plant = AppSessionState.location_Id;
                            ItemEntityObject.ship_to_Party = MasterEntity.ship_to_party;
                            ItemEntityObject.ship_to_add = MasterEntity.del_address;
                            ItemEntityObject.buss_place = MasterEntity.buss_place;
                            ItemEntityObject.qty_price = 1;
                            ItemEntityObject.price_qty = String.IsNullOrEmpty(POPUPEntityObject.Rate_Catlog.ToString()) ? POPUPEntityObject.rate : POPUPEntityObject.Rate_Catlog;
                            ItemEntityObject.price_qty_uom = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM;
                            ItemEntityObject.weight_unit = POPUPEntityObject.weight_unit;
                            ItemEntityObject.volume_unit = POPUPEntityObject.volume_unit;
                        }
                        else if (ItemEntityObject.ItemCode != POPUPEntityObject.ItemCode)
                        {
                            ItemEntityObject.ItemCode = "";
                            ItemEntityObject.Description = "";
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
        private void CheckPrice(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {

            try
            {
                unit_price = Convert.ToDecimal(InputValue);
                string Request = ItemEntityObject.ItemCode;
                SEL_T001_P_SO_ItemsList POPUPEntityObject = null;
                POPUPEntityObject = MC.ItemListPopup.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                if (POPUPEntityObject.higher_limit != null && POPUPEntityObject.lower_limit != null && POPUPEntityObject.higher_limit != 0 && POPUPEntityObject.lower_limit != 0 && ItemEntityObject != null)
                {
                    if (unit_price > POPUPEntityObject.higher_limit || unit_price < POPUPEntityObject.lower_limit)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Unit Price Exceeds than Catlog Price ...");
                        showMessageService.ShowMessage();
                        ItemEntityObject.alert1 = showMessageService.Text;
                    }
                    else
                    {
                        ItemEntityObject.alert1 = null;
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
                            location_Id = MasterEntity.location_Id,
                            comp_code = MasterEntity.comp_code,
                            con_type = POPUPEntityObject.con_type,
                            long_text = POPUPEntityObject.long_text,
                            tc_code = POPUPEntityObject.tc_code,
                            sequence_code = POPUPEntityObject.sequence_code,
                            sequence1 = POPUPEntityObject.sequence1,
                            sequence2 = POPUPEntityObject.sequence2,
                            sequence3 = POPUPEntityObject.sequence3,
                            short_text = POPUPEntityObject.short_text,
                            con_desc = POPUPEntityObject.con_desc,
                        });
                    }
                    else if (dgSelectedIndexTerms >= 0 && TermsConditionEntity.Count > dgSelectedIndexTerms) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (TermsConditionEntity[dgSelectedIndexTerms].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            TermsConditionEntity[dgSelectedIndexTerms].active = true;
                            TermsConditionEntity[dgSelectedIndexTerms].location_Id = MasterEntity.location_Id;
                            TermsConditionEntity[dgSelectedIndexTerms].comp_code = MasterEntity.comp_code;
                            TermsConditionEntity[dgSelectedIndexTerms].con_type = POPUPEntityObject.con_type;

                            TermsConditionEntity[dgSelectedIndexTerms].long_text = POPUPEntityObject.long_text;
                            TermsConditionEntity[dgSelectedIndexTerms].tc_code = POPUPEntityObject.tc_code;

                            TermsConditionEntity[dgSelectedIndexTerms].sequence_code = POPUPEntityObject.sequence_code;
                            TermsConditionEntity[dgSelectedIndexTerms].sequence1 = POPUPEntityObject.sequence1;
                            TermsConditionEntity[dgSelectedIndexTerms].sequence2 = POPUPEntityObject.sequence2;
                            TermsConditionEntity[dgSelectedIndexTerms].sequence3 = POPUPEntityObject.sequence3;
                            TermsConditionEntity[dgSelectedIndexTerms].short_text = POPUPEntityObject.short_text;
                            TermsConditionEntity[dgSelectedIndexTerms].con_desc = POPUPEntityObject.con_desc;

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

                if (POPUPEntityObject != null && ItemEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
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
                            ItemEntityObject.unit_code = POPUPEntityObject.unit_code;
                            NewUnitCode = ItemEntityObject.unit_code;
                            PriceComputation(PreviousUnitCode, NewUnitCode, "QtyUnit");
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

                if (POPUPEntityObject != null && ItemEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemEntityObject.id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemEntityObject.price_qty_uom = POPUPEntityObject.unit_code;
                            PriceComputation(ItemEntityObject.price_qty_uom, POPUPEntityObject.unit_code, "PriceUnit");
                        }
                        else if (ItemEntityObject.price_qty_uom != POPUPEntityObject.unit_code)
                        {
                            ItemEntityObject.price_qty_uom = POPUPEntityObject.unit_code;
                            PriceComputation(ItemEntityObject.price_qty_uom, POPUPEntityObject.unit_code, "PriceUnit");
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

                if (POPUPEntityObject != null && ItemEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    ItemEntityObject.item_cat = POPUPEntityObject.sditem_cat_code;
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
                    if (ParameterObject.GetType() == typeof(string) && ParameterObject != null)
                    {
                        Request = ParameterObject.ToString();
                        if (Request.Length > 0)
                        {
                            Request = "LoadDocumentWithDocumentNumber" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@!@!@!@" + Request;
                            isNewRecord = false;
                        }
                    }
                    else if (((IEnumerable)ParameterObject).Cast<SEL_T001_Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<SEL_T001_Flip>().ToList()[0];
                        Request = "LoadDocumentWithDocumentNumber" + "!@" + AppSessionState.client + "!@" + (MasterEntity.comp_code ?? ParameterEntityObject.comp_code) + "!@" + (MasterEntity.location_Id ?? ParameterEntityObject.comp_code) + "!@" + doc_cat_vm + "!@" + (MasterEntity.doc_type ?? ParameterEntityObject.doc_type) + "!@" + ParameterEntityObject.sono + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + (ParameterEntityObject.PartyId ?? ParameterEntityObject.PartyId);
                        //Request = "LoadDocumentWithDocumentNumber" + "!@" + ParameterEntityObject.sono + "!@" + ParameterEntityObject.PartyId + "!@" + ParameterEntityObject.ship_to_party + "!@" + AppSessionState.client + "!@" + AppSessionState.UserID + "!@" + MasterEntity.EmpId + "!@" + MasterEntity.ts_code; 
                        isNewRecord = false;


                        RequestParameterData = "LoadSoldToPartyDetails" + "!@" + AppSessionState.client + "!@" + (MasterEntity.comp_code ?? ParameterEntityObject.comp_code) + "!@" + (MasterEntity.location_Id ?? ParameterEntityObject.location_id) + "!@" + doc_cat_vm + "!@" + (MasterEntity.doc_type ?? ParameterEntityObject.doc_type) + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + (ParameterEntityObject.PartyId ?? ParameterEntityObject.PartyId);
                        //RequestParameterData = "LoadSoldToPartyDetails" + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + ParameterEntityObject.PartyId + "!@" + AppSessionState.client + "!@" + AppSessionState.UserID + "!@" + MasterEntity.EmpId + "!@" + MasterEntity.ts_code;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, RequestParameterData, "SalesOrderMaster", "CRM", "", 0, "");

                        MC.ItemListPopup = MCTemp.ItemListPopup;
                        PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListPopup);
                        PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P_SO_ItemsList)x).ItemCode);
                        TheFilter = (o, prefix) => ((SEL_T001_P_SO_ItemsList)o).ItemCode.ToString().ToLower().Contains(prefix.ToLower()) || ((SEL_T001_P_SO_ItemsList)o).ItemName.ToString().ToLower().Contains(prefix.ToLower());
                        ASItems = new AutoSuggestTextViewModel<dynamic>(MC.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                        ASItems.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASItems.AutoSuggestVM.IsFreeTextAllowed = true;
                    }
                }

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, Request, "SalesOrderMaster", "CRM", "LoadDocumentWithDocumentNumber", 0, "");

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

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).PersonName);
                TheFilter = (o, prefix) => (((ADM_M028_C_P)o).PersonName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASBuyer = new AutoSuggestTextViewModel<dynamic>(MC.PartysContactInfo, TheFilter, SuggestedValue, "buyer_name", true);
                ASBuyer.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASBuyer.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).SrNo.ToString());
                TheFilter = (o, prefix) => ((ADM_M028_D)o).SrNo.ToString().ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M028_D)o).SrNo.ToString().ToLower().Contains(prefix.ToLower());
                ASBillAdddress = new AutoSuggestTextViewModel<dynamic>(MC.PartysSoldToAddresses, TheFilter, SuggestedValue, "bill_address_id", true);
                ASBillAdddress.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASBillAdddress.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).SrNo.ToString());
                TheFilter = (o, prefix) => ((ADM_M028_D)o).SrNo.ToString().ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M028_D)o).SrNo.ToString().ToLower().Contains(prefix.ToLower());
                ASDeliveryAdddress = new AutoSuggestTextViewModel<dynamic>(MC.PartysShipToAddresses, TheFilter, SuggestedValue, "del_address", true);
                ASDeliveryAdddress.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDeliveryAdddress.AutoSuggestVM.IsFreeTextAllowed = true;

                //SetPopupSuggestionDataAfterLoad();
                Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
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
                //ASSOtype.AutoSuggestVM.Suggestion = MC.DocumentTypes.Find(x => x.doc_type_user == MasterEntity.doc_type_user);
                //ASDoctype.AutoSuggestVM.Suggestion = MC.DocumentTypes.Find(x => x.doc_type_user == MasterEntity.doc_type_user);
                //ASSoldToParty.AutoSuggestVM.Suggestion = MC.PartyMaster.Find(x => x.PartyId == MasterEntity.PartyId);
                //ASShipToParty.AutoSuggestVM.Suggestion = MC.PartyMaster.Find(x => x.PartyId == MasterEntity.ship_to_party);

                //ASNotifyParty.AutoSuggestVM.Suggestion = MC.PartyMaster.Find(x => x.PartyId == MasterEntity.notify_party);
                //ASTransporter.AutoSuggestVM.Suggestion = MC.Transporters.Find(x => x.PartyId == MasterEntity.transporter_cd);

                //if (ASBuyer != null)
                //{
                //    ASBuyer.AutoSuggestVM.Suggestion = MC.PartysContactInfo.Find(x => x.PersonName == MasterEntity.buyer_name);
                //    ASBillAdddress.AutoSuggestVM.Suggestion = MC.PartysSoldToAddresses.Find(x => x.SrNo.ToString() == MasterEntity.bill_address_id.ToString());
                //    ASDeliveryAdddress.AutoSuggestVM.Suggestion = MC.PartysShipToAddresses.Find(x => x.SrNo == MasterEntity.del_address);
                //}
                //ASSalesPersonView.AutoSuggestVM.Suggestion = MC.Sellers.Find(x => x.EmpName == MasterEntity.fltr_SalesPersonNM);
                //ASSalesPerson.AutoSuggestVM.Suggestion = MC.Sellers.Find(x => x.EmpId == MasterEntity.sales_person_cd);
                //ASCurrency.AutoSuggestVM.Suggestion = MC.Currencys.Find(x => x.curr_code == MasterEntity.curr_code);

                //ASIncoTerms.AutoSuggestVM.Suggestion = MC.Incoterms.Find(x => x.incoterms == MasterEntity.incoterms);
                //ASPayTerms.AutoSuggestVM.Suggestion = MC.PayTerms.Find(x => x.p_term_code == MasterEntity.p_term_code);
                //ASRefferingParty.AutoSuggestVM.Suggestion = MC.ServiceProviders.Find(x => x.PartyId == MasterEntity.referring_party);
                //ASOurBank.AutoSuggestVM.Suggestion = MC.Banks.Find(x => x.bank_code == MasterEntity.bank_code);
                //ASNastroBank.AutoSuggestVM.Suggestion = MC.Banks.Find(x => x.bank_code == MasterEntity.nastro_bank_cd);

                //LocationList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                //ASLocation.AutoSuggestVM.Suggestion = LocationList.Find(x => x.location_Id == MasterEntity.location_Id);

                //ASSalesGroup.AutoSuggestVM.Suggestion = MC.SalesGroup.Find(x => x.sg_code == MasterEntity.sg_code);
                //ASSalesOrg.AutoSuggestVM.Suggestion = MC.SalesOrg.Find(x => x.so_code == MasterEntity.so_code);
                //ASt_status.AutoSuggestVM.Suggestion = MC.t_statusList.Find(x => x.t_display == MasterEntity.t_display);

                ////ASFltrt_DocType.AutoSuggestVM.Suggestion = MC.DocumentTypes.Find(x => x.doc_type == MasterEntity.Fltr_doc_type);
                ////ASFltrSoldToParty.AutoSuggestVM.Suggestion = MC.PartyMaster.Find(x => x.PartyNm == MasterEntity.fltr_SoldToPartyNM);
                ////ASFltrt_status.AutoSuggestVM.Suggestion = MC.t_statusList.Find(x => x.t_display == MasterEntity.fltr_t_display);
            }
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
                CursorControl.SetBusyState();
                EntityChangeEnable = false;
                string Request = "";
                string ParametersStringValue = "";
                SEL_T001_Flip ParameterEntityObject = null;

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
                        if (MasterEntity.ref_doc_cat == "SN")
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
                                { Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@!@!@!@" + ParametersStringValue; }
                                catch (Exception ex) { }
                            }
                        }
                        else if (MasterEntity.ref_doc_cat == "QN")
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
                                Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@!@!@!@" + ParametersStringValue;

                            }

                        }


                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, Request, "SalesOrderMaster", "CRM", "LoadDocumentWithReferenceDocumentNumber", 0, "");
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
                            MC.PartysContactInfo = MCTemp.PartysContactInfo;
                            MC.PartysSoldToAddresses = MCTemp.PartysSoldToAddresses;
                            MC.PartysShipToAddresses = MCTemp.PartysShipToAddresses;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).PersonName);
                            TheFilter = (o, prefix) => ((ADM_M028_C_P)o).PersonName.ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M028_C_P)o).ContInfoId.ToString().ToLower().Contains(prefix.ToLower());
                            ASBuyer = new AutoSuggestTextViewModel<dynamic>(MC.PartysContactInfo, TheFilter, SuggestedValue, "buyer_name", true);
                            ASBuyer.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASBuyer.AutoSuggestVM.IsFreeTextAllowed = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).SrNo.ToString());
                            TheFilter = (o, prefix) => ((ADM_M028_D)o).SrNo.ToString().ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M028_D)o).SrNo.ToString().ToLower().Contains(prefix.ToLower());
                            ASBillAdddress = new AutoSuggestTextViewModel<dynamic>(MC.PartysSoldToAddresses, TheFilter, SuggestedValue, "bill_address_id", true);
                            ASBillAdddress.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASBillAdddress.AutoSuggestVM.IsFreeTextAllowed = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).SrNo.ToString());
                            TheFilter = (o, prefix) => ((ADM_M028_D)o).SrNo.ToString().ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M028_D)o).SrNo.ToString().ToLower().Contains(prefix.ToLower());
                            ASDeliveryAdddress = new AutoSuggestTextViewModel<dynamic>(MC.PartysShipToAddresses, TheFilter, SuggestedValue, "del_address", true);
                            ASDeliveryAdddress.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASDeliveryAdddress.AutoSuggestVM.IsFreeTextAllowed = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).SrNo.ToString());
                            TheFilter = (o, prefix) => ((ADM_M028_D)o).SrNo.ToString().ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M028_D)o).SrNo.ToString().ToLower().Contains(prefix.ToLower());
                            ASSchShipToAdd = new AutoSuggestTextViewModel<dynamic>(MC.PartysShipToAddresses, TheFilter, SuggestedValue, "del_address", true);
                            ASSchShipToAdd.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASSchShipToAdd.AutoSuggestVM.IsFreeTextAllowed = true;


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
                                        //isNewRecord = false;
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
                            TotalDocumentTaxes = MCTemp.TaxEntity;

                        }
                        else
                        {
                            MCTemp.TaxEntity = new ObservableCollection<ACC_T006_B>();
                        }
                        var ManualTaxList = (from o in MCTemp.TaxEntity
                                             where o.manual == "Manual"
                                             select o).ToList();


                        int count = ItemsEntity.Count();
                        TotalDocumentTaxes.Clear();
                        for (int i = 0; i < count; i++)
                        {
                            Computation(true, i, AutoRoundupEnable);
                        }
                        foreach (var item in ManualTaxList)
                        {
                            TotalDocumentTaxes.Add(item);
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
                    }
                }
                if (ParameterReference == "ReferenceDocument")
                {
                    MasterEntity.ref_doc_no = MasterEntity.sono;
                    MasterEntity.ref_doc_date = MasterEntity.sodate;
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

        private void ActiveInactiveTax(bool select)
        {
            Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
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
        private void InsertManualTaxChangedCommand(object InputValue)
        {
            try
            {
                Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
            }
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

        private void unitconversion()
        {
            try
            {
                var CurrantUnitCF = (from o in UnitConversionList where (o.unit_code == PreviousUnitCode) select o).ToList();
                var NewUnitCF = (from o in UnitConversionList where (o.unit_code == NewUnitCode) select o).ToList();
                if (CurrantUnitCF.Count > 0 && NewUnitCF.Count > 0 && ItemEntityObject != null)
                {
                    ItemEntityObject.quantity = (ItemEntityObject.quantity * CurrantUnitCF[0].c_factor) / NewUnitCF[0].c_factor;
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
        private void PriceComputation(string PreviousUnit, string NewUnit, string Source)
        {
            try
            {
                if (ItemsEntity.Count > 0 && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < ItemsEntity.Count && ItemEntityObject != null)
                {
                    if (ItemEntityObject.qty_price > 0 && ItemEntityObject.price_qty > 0 && string.IsNullOrWhiteSpace(ItemEntityObject.price_qty_uom) == false)
                    {
                        if (Source == "QtyUnit")
                        {
                            var PreviousUnitCF = (from o in UnitConversionList where (o.unit_code == PreviousUnit) select o).ToList();
                            var NewUnitCF = (from o in UnitConversionList where (o.unit_code == NewUnit) select o).ToList();

                            if (PreviousUnitCF.Count > 0 && NewUnitCF.Count > 0)
                            {
                                ItemEntityObject.quantity = (ItemEntityObject.quantity * PreviousUnitCF[0].c_factor) / NewUnitCF[0].c_factor;
                                ItemEntityObject.unit_price = (ItemEntityObject.unit_price / PreviousUnitCF[0].c_factor) * NewUnitCF[0].c_factor;
                            }
                        }
                        else if (Source == "PriceUnit")
                        {
                            var PreviousUnitCF = (from o in UnitConversionList where (o.unit_code == PreviousUnit) select o).ToList();
                            var NewUnitCF = (from o in UnitConversionList where (o.unit_code == NewUnit) select o).ToList();

                            if (PreviousUnitCF.Count > 0 && NewUnitCF.Count > 0)
                            {
                                ItemEntityObject.qty_price = (ItemEntityObject.qty_price * PreviousUnitCF[0].c_factor) / NewUnitCF[0].c_factor;
                            }
                        }

                        decimal? UnitPrice_Qty = 0;
                        string QtyUnit = ItemEntityObject.unit_code;
                        string PriceUnit = ItemEntityObject.price_qty_uom;
                        var QtyUnitCF = (from o in UnitConversionList where (o.unit_code == QtyUnit) select o).ToList();
                        var PriceUnitCF = (from o in UnitConversionList where (o.unit_code == PriceUnit) select o).ToList();
                        decimal? qty = ItemEntityObject.quantity;
                        decimal? qty_of_price = ItemEntityObject.qty_price;
                        decimal? price_of_qty = ItemEntityObject.price_qty;

                        UnitPrice_Qty = ((((qty * QtyUnitCF[0].c_factor) / PriceUnitCF[0].c_factor) / qty_of_price) * price_of_qty) / qty;
                        ItemEntityObject.unit_price = decimal.Round(Convert.ToDecimal(UnitPrice_Qty), 4, MidpointRounding.AwayFromZero);
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

        private void CollectionChanged(IList DataList)
        {
            string[] TempSkuList = new string[100];
            List<string> TempParaValueList = new List<string>();
            IList list = DataList as IList;
            try
            {
                if (ItemEntityObject.id == 0 && ItemsEntity.Count > 0 && dgSelectedIndexItem < ItemsEntity.Count && ItemEntityObject != null)
                {
                    List<SEL_T001_A> SelectedRowlist = list.Cast<SEL_T001_A>().ToList();

                    if (SelectedRowlist[0].StockUnt == true)
                    {
                        var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();

                        ParameterTemp = paramlist.ToList();

                        if (paramlist.Count > 0 && ItemEntityObject.sku != "" && ItemEntityObject.sku != null)
                        {
                            TempSkuList = ItemEntityObject.sku.Split('/');

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


                            if (ItemEntityObject.sku_desc != null)
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
                else if (ItemEntityObject.id != 0 && ItemsEntity.Count > 0 && dgSelectedIndexItem < ItemsEntity.Count && ItemEntityObject != null)
                {
                    List<SEL_T001_A> SelectedRowlist = list.Cast<SEL_T001_A>().ToList();

                    if (SelectedRowlist[0].StockUnt == true)
                    {
                        var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();
                        if (paramlist.Count > 0 && ItemEntityObject.sku != "" && ItemEntityObject.sku != null)
                        {
                            TempSkuList = ItemEntityObject.sku.Split('/');

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
                if (dgSelectedIndexItem != -1 && SelectedParaValueList.Count > 0 && ItemEntityObject.StockUnt == true)
                {
                    if (ItemEntityObject.id == 0)
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
                    else if (ItemEntityObject.id != 0)
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
                if (ItemEntityObject.sku_desc == null || ItemEntityObject.sku_desc == "")
                {
                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if ((ItemEntityObject.sku_desc == "" || ItemEntityObject.sku_desc == null) && SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                        {
                            ItemEntityObject.sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                        else if (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                        {
                            ItemEntityObject.sku_desc = ItemEntityObject.sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                    }
                }
                else
                {
                    ItemEntityObject.sku_desc = "";

                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if ((ItemEntityObject.sku_desc == "" || ItemEntityObject.sku_desc == null) && SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                        {
                            ItemEntityObject.sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                        else if (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                        {
                            ItemEntityObject.sku_desc = ItemEntityObject.sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
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
                if (ItemEntityObject.sku == null || ItemEntityObject.sku == "")
                {
                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if (ItemEntityObject.sku == "" || ItemEntityObject.sku == null)
                        {
                            ItemEntityObject.sku = SelectedParaValueCollection[i].value_code;
                        }
                        else
                        {
                            ItemEntityObject.sku = ItemEntityObject.sku + "/" + SelectedParaValueCollection[i].value_code;
                        }
                    }
                }
                else
                {
                    ItemEntityObject.sku = "";

                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if (ItemEntityObject.sku == "" || ItemEntityObject.sku == null)
                        {
                            ItemEntityObject.sku = SelectedParaValueCollection[i].value_code;
                        }
                        else
                        {
                            ItemEntityObject.sku = ItemEntityObject.sku + "/" + SelectedParaValueCollection[i].value_code;
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
        string DocumentList = "";
        private void AddSelectedRef(object InputValue)
        {
            try
            {
                SEL_T001_P_RefDoc POPUPEntityObject = null;
                string Request;

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
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<SEL_T001_P_RefDoc>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T001_P_RefDoc>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    if (POPUPEntityObject.t_status != "009")
                    {
                        MasterEntity.ref_doc_no = POPUPEntityObject.sono;
                        MasterEntity.ref_doc_cat = POPUPEntityObject.doc_cat;


                        DocumentList = "";
                        if (MasterEntity.ref_doc_cat == "SN")
                        {
                            refdoctempa = (from o in MC.Sales_Order_Reference where o.doc_cat == "SN" select o).ToList();
                            ReferenceDocSNCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                            ReferenceDocSNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                            var refdoctempQN = (from o in MC.Sales_Order_Reference where o.doc_cat == "QN" select o).ToList();
                            foreach (var item in refdoctempQN)
                            {
                                item.Select = false;
                            }
                            ReferenceDocQNCollection = CollectionViewSource.GetDefaultView(refdoctempQN);
                            ReferenceDocQNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                        }
                        else if (MasterEntity.ref_doc_cat == "QN")
                        {
                            refdoctempa = (from o in MC.Sales_Order_Reference where o.doc_cat == "QN" select o).ToList();
                            ReferenceDocQNCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                            ReferenceDocQNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                            var refdoctempSN = (from o in MC.Sales_Order_Reference where o.doc_cat == "SN" select o).ToList();
                            foreach (var item in refdoctempSN)
                            {
                                item.Select = false;
                            }
                            ReferenceDocSNCollection = CollectionViewSource.GetDefaultView(refdoctempSN);
                            ReferenceDocSNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                        }
                        var refdoc = from o in refdoctempa
                                     where o.PartyId == POPUPEntityObject.PartyId
                                            && o.party_name == POPUPEntityObject.party_name
                                            && o.so_code == POPUPEntityObject.so_code
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
                                DocumentList = DocumentList + "," + item.sono;
                            }
                        }
                        DocumentList = DocumentList.ToString().TrimStart(new char[] { ',' });
                        if (MasterEntity.ref_doc_cat == "SN")
                        {
                            if (POPUPEntityObject.Select == true)
                            {
                                ReferenceDocSNCollection = CollectionViewSource.GetDefaultView(refdoc);
                                ReferenceDocSNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                            }
                        }
                        else if (MasterEntity.ref_doc_cat == "QN")
                        {
                            if (POPUPEntityObject.Select == true)
                            {
                                ReferenceDocQNCollection = CollectionViewSource.GetDefaultView(refdoc);
                                ReferenceDocQNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                            }
                        }
                        if (DocumentList == "")
                        {
                            MasterEntity.ref_doc_no = null;
                            MasterEntity.ref_doc_cat = null;

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


        private void InsertFltrDocType(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M002 POPUPEntityObject = null;
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DocumentTypes.Where(x => x.doc_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SYS_M002>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M002>().ToList()[0];
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
                    MasterEntity.fltr_SoldToPartyID = POPUPEntityObject.PartyId;
                    MasterEntity.fltr_SoldToPartyNM = POPUPEntityObject.PartyNm;
                }
            }
            catch (Exception Ex) { }
        }
        #endregion
        #region Abstract Command Actions
        private IEnumerable<T> MakeMeEnumerable<T>(T Entity)
        {
            yield return Entity;
        }
        protected override void OnSaveAction(InquiryActionResult<SEL_T001> result)
        {
            CursorControl.SetBusyState();
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.editby = AppSessionState.UserID;
                    this.StatusMessage = "Saving changes, please wait ...";
                    MasterEntity.XmlDataDocument_SEL_T001_A = obj.ObjectToXML(ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_B = obj.ObjectToXML(TotalDocumentTaxes);
                    MasterEntity.XmlDataDocument_SEL_T002 = obj.ObjectToXML(ScheduleEntity);
                    MasterEntity.XmlDataDocument_SEL_T002_A = obj.ObjectToXML(ItemScheduleEntity);
                    MasterEntity.XmlDataDocument_SEL_T001_E = obj.ObjectToXML(TermsConditionEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_D = obj.ObjectToXML(LicenceDetailsEntity);

                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<SEL_T001>(MasterEntity, "SalesOrderMaster", "CRM");
                        SetBusinessEntitiesAfterLoad("Save", "");
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
                        MasterEntity = repository.UpdateWithReturnDomainObject<SEL_T001>(MasterEntity, "SalesOrderMaster", "CRM");
                        SetBusinessEntitiesAfterLoad("Save", "");
                        if (MasterEntity.sono != null && NotificationDataCollection.Exists(element => element.alert_name == "OnUpdate") == true)
                        {
                            NotifyMessage("OnUpdate", "Modified");
                        }
                    }
                    
                    if (MasterEntity.sono != null || MasterEntity.sono != "" && MasterEntity.active == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record saved Successfully ........");
                        showMessageService.ShowMessage();
                    }
                    isNewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                }
                RemoveRefDoc();
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
        private void RemoveRefDoc()
        {
            try
            {
                if (MasterEntity.ref_doc_no != null)
                {
                    List<string> DocList = DocumentList.Split(',').ToList();
                    foreach (var item in DocList)
                    {
                        MC.Sales_Order_Reference.RemoveAll(X => X.sono == item);
                    }

                    refdoctempa = (from o in MC.Sales_Order_Reference where o.doc_cat == "SN" select o).ToList();
                    ReferenceDocSNCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                    ReferenceDocSNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                    refdoctempa = (from o in MC.Sales_Order_Reference where o.doc_cat == "QN" select o).ToList();
                    ReferenceDocQNCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                    ReferenceDocQNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);


                }

            }
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
                DocumentList = "";
                foreach (var item in MC.Sales_Order_Reference)
                {
                    if (item.Select == true)
                    {
                        item.Select = false;
                    }
                }
                var refdoctempa = (from o in MC.Sales_Order_Reference where o.doc_cat == "SN" select o).ToList();
                ReferenceDocSNCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                refdoctempa = (from o in MC.Sales_Order_Reference where o.doc_cat == "QN" select o).ToList();
                ReferenceDocQNCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                MasterEntity = new SEL_T001();
                //MasterEntity.ValidateAsync().Wait();
                ItemsEntity = new ObservableCollection<SEL_T001_A>();
                TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
                TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>();
                TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
                ScheduleEntity = new SEL_T002();
                TermsConditionEntity = new ObservableCollection<SEL_T001_E>();
                ItemScheduleEntity = new ObservableCollection<SEL_T002_A>();
                LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
                ItemEntityObject = null;
                DefaultValues();

                var OrderType = (from o in MC.DocumentTypes where o.doc_cat == "SO" && o.default_doc == true select o).ToList();
                if (OrderType.Count == 1)
                {
                    MasterEntity.doc_type = OrderType[0].doc_type;
                    MasterEntity.doc_type_user = OrderType[0].doc_type_user;
                    MasterEntity.doc_desc = OrderType[0].doc_desc_user;
                }
                var tempt_display = (from o in MC.STATUS_LIST
                                     where o.t_status == MasterEntity.t_status
                                     select o).ToList();
                MasterEntity.t_display = tempt_display[0].t_display;
                if (MC.Banks.Where(x => x.ind_default == true && x.comp_code == MasterEntity.comp_code).ToList().Count > 0)
                {
                    MasterEntity.bank_code = MC.Banks.Where(x => x.ind_default == true).ToList()[0].bank_code;
                    MasterEntity.bank_name = MC.Banks.Where(x => x.ind_default == true).ToList()[0].bank_name;
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
        //protected override void OnPrintAction(InquiryActionResult<SEL_T001> result)
        //{
        //    CursorControl.SetBusyState();
        //    try
        //    {
        //        string Request = "SO_Report" + "!@" + MasterEntity.sono;
        //        string ReportName = "";

        //        object[] objDataSource = new object[7];
        //        string[] objDataSourceName = new string[7];


        //        List<SEL_T001> masterList = new List<SEL_T001>();
        //        masterList.Add(MasterEntity);
        //        objDataSource[0] = masterList; //masterList; //
        //        objDataSource[1] = ItemsEntity;
        //        objDataSource[2] = TotalDocumentTaxes;


        //        List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
        //        var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
        //        objDataSource[3] = CmpResult;

        //        List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
        //        var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
        //        objDataSource[4] = Result;
        //        objDataSource[5] = ItemScheduleEntity;
        //        objDataSource[6] = TermsConditionEntity;

        //        objDataSourceName[0] = "dsSalesQuotation";
        //        objDataSourceName[1] = "dsSalesQuotationItem";
        //        objDataSourceName[2] = "dsSalesQuotationTax";
        //        objDataSourceName[3] = "dsCompany";
        //        objDataSourceName[4] = "dsLocation";
        //        objDataSourceName[5] = "dsScheduleDetailsEntity";
        //        objDataSourceName[6] = "dsTermsCondition";


        //        ReportManager ReportManager = new ReportManager();

        //        var ReportStringList = (from o in MC.DocumentTypes where o.doc_type == MasterEntity.doc_type select o).ToList();
        //        if (MasterEntity.doc_type == "EX")
        //        {
        //            ReportName = ReportStringList[0].report_name.Split(',')[0];

        //        }
        //        else
        //        {
        //            ReportName = ReportStringList[0].report_name.Split(',')[0];
        //        }
        //        string ReportDisplayName = MasterEntity.party_name + "_" + MasterEntity.sono + "_" + MasterEntity.sodate.Value.ToShortDateString();
        //        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, getParametersList(), ReportDisplayName);
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
        protected override void OnPrintAction(InquiryActionResult<SEL_T001> result)
        {
            CursorControl.SetBusyState();
            EntityChangeEnable = false;
            try
            {
                string Request = "SO_Report" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.sono;
                //string Request = "SO_Report" + "!@" + MasterEntity.sono + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" +AppSessionState.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type +"!@" + MasterEntity .EmpId + "!@" + MasterEntity.ts_code;
                string ReportName = "";
                string tempLocation = MasterEntity.location_Id;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, Request, "SalesOrderMaster", "CRM", "LoadDocumentWithDocumentNumber", 0, "");
                object[] objDataSource = new object[7];
                string[] objDataSourceName = new string[7];
                MCTemp.MasterEntity[0].location_Id = tempLocation;


                objDataSource[0] = MCTemp.MasterEntity;
                objDataSource[1] = MCTemp.ItemsEntity;
                objDataSource[2] = MCTemp.TaxEntity;


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
                string ReportDisplayName = MasterEntity.party_name + "_" + MasterEntity.sono + "_" + MasterEntity.sodate.Value.ToShortDateString();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, getParametersList(), ReportDisplayName);
                EntityChangeEnable = true;
            }
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
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.sono.Replace("/", "--"), DocumentList = MCTemp.Attachment, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<SEL_T001> result)
        {
            LoadInitialData();
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
                if (EntityChangeEnable == true)
                {
                    if (e.PropertyName == "quantity" || e.PropertyName == "unit_price" || e.PropertyName == "tax_id" || e.PropertyName == "active" || e.PropertyName == "discount" || e.PropertyName == "price_qty" || e.PropertyName == "qty_price" || e.PropertyName == "price_qty_uom")
                    {
                        PriceComputation(null, null, null);
                        Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
                    }
                    if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = false; /*ItemEntityObject.HasErrors;*/
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
                    foreach (SEL_T001_A item in e.NewItems)
                    {

                        item.symbol = MasterEntity.symbol;
                        item.client = AppSessionState.client;
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                    if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = false; /*ItemEntityObject.HasErrors;*/
                    }
                }

                if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                    this.ErrorExist = false;/*MasterEntity.HasErrors;*/
                    if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = false; /*ItemEntityObject.HasErrors;*/
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
                                Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
                            }
                        }

                    }

                    foreach (SEL_T001_A item in e.OldItems)
                    {
                        item.PropertyChanged -= EntityViewModelPropertyChanged;
                    }
                    if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = false;/*ItemEntityObject.HasErrors;*/
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
        void Schedule_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "qty" && ItemEntityObject != null)
                {
                    #region Check Schedule Qty Total should not exceed PO Qty.
                    //Check Schedule Qty Total should not exceed PO Qty.
                    decimal? TotalQtyOfScheduleForItem = 0;
                    TotalQtyOfScheduleForItem = ItemScheduleEntity.Where(item => item.ItemCode == ItemEntityObject.ItemCode && (item.sku?.ToString() ?? "") == (ItemEntityObject.sku?.ToString() ?? "")).Sum(item => item.sch_qty);
                    decimal? POQty = ItemEntityObject.quantity;  // pending error : index > count
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
                    this.ErrorExist = false; /*ItemEntityObject.HasErrors;*/
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
                if (e.Action == NotifyCollectionChangedAction.Add && ItemsEntity.Count > 0 && ItemEntityObject != null) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (SEL_T002_A item in e.NewItems)
                    {
                        try
                        {
                            if (ItemEntityObject.id > 0)
                            {
                                item.so_item_id = ItemEntityObject.id;
                            }
                            else
                            {
                                item.so_item_id = 0;
                            }
                            item.ItemCode = ItemEntityObject.ItemCode;
                            item.unit_code = ItemEntityObject.unit_code;
                            item.sku = ItemEntityObject.sku;
                            item.sch_cat = "SD";
                            item.sono = ItemEntityObject.sono;
                            item.sch_qty = ItemEntityObject.quantity;
                            item.bal_qty = ItemEntityObject.quantity;
                            var temp = (from o in ItemScheduleEntity where o.item_line_id == ItemEntityObject.line_id select o).ToList();
                            if (temp.Count > 0 && ItemEntityObject.quantity > 0)
                            {
                                decimal? tempVar = ItemEntityObject.quantity;
                                foreach (var o in temp)
                                {
                                    o.bal_qty = tempVar - Convert.ToDecimal(o.confirm_qty);
                                    tempVar = tempVar - Convert.ToDecimal(o.confirm_qty);
                                }
                                item.sch_qty = tempVar;
                                item.bal_qty = tempVar;
                            }

                            //if (temp.Count > 0)
                            //{
                            //    foreach (var o in temp)
                            //    {
                            //        item.sch_qty = o.sch_qty - Convert.ToDecimal(o.confirm_qty);
                            //        item.bal_qty = o.sch_qty - Convert.ToDecimal(o.confirm_qty);
                            //    }
                            //}
                            item.t_status = ItemEntityObject.t_status;
                            item.t_display = ItemEntityObject.t_display;
                            item.active = true;
                            item.editby = AppSessionState.UserID;
                            item.add_by = AppSessionState.UserID;
                            item.location_Id = AppSessionState.location_Id;
                            item.comp_code = MasterEntity.comp_code;
                            item.rate = 0;
                            item.line_id = 1;
                            item.lead_time = 0;

                            item.ship_to_party = MasterEntity.ship_to_party;
                            item.ship_to_party_name = MasterEntity.ship_to_party_name;
                            item.ship_to_add = MasterEntity.del_address.ToString();
                            item.ship_to_addNm = MasterEntity.delivery_address;

                            if (ItemScheduleEntity.Count > 0)
                            {
                                item.PartyNm = ItemScheduleEntity[0].PartyNm;
                                item.ship_mode = ItemScheduleEntity[0].ship_mode;
                                item.para1 = ItemScheduleEntity[0].para1;
                                item.line_id = ItemScheduleEntity.Count;
                                item.lead_time = ItemScheduleEntity[0].lead_time;
                            }
                            if (ItemScheduleEntity.Count > 0)
                            {

                                if (ItemScheduleEntity[0].PartyNm == null)
                                {
                                    item.ship_mode = MasterEntity.ship_mode;
                                    item.PartyNm = MasterEntity.TranParty_name;
                                    item.PartyId = MasterEntity.transporter_cd;
                                }
                                else
                                {
                                    item.PartyNm = ItemScheduleEntity[0].PartyNm;
                                    item.ship_mode = ItemScheduleEntity[0].ship_mode;
                                    item.PartyId = MasterEntity.transporter_cd;
                                }
                                item.para1 = ItemScheduleEntity[0].para1;
                                item.line_id = ItemScheduleEntity.Count;
                            }
                            item.item_line_id = ItemEntityObject.line_id;
                            if (ItemScheduleEntity.Where(p => p.item_line_id == ItemEntityObject.line_id).ToList().Count > 1)
                            {
                                MasterEntity.partshipment = "Allowed";
                            }

                            item.sch_date = item.sch_date ?? DateTime.Now;
                            item.del_date = item.sch_date ?? DateTime.Now;
                            item.desp_date = item.sch_date ?? DateTime.Now;
                            item.exp_date = item.sch_date ?? DateTime.Now;
                            item.confirm_date = item.sch_date ?? DateTime.Now;

                            //item.confirm_qty = item.confirm_qty ?? item.sch_qty ?? ItemEntityObject.quantity;
                            //item.sch_qty = item.sch_qty ?? ItemEntityObject.quantity;
                            //item.del_qty = item.del_qty ?? ItemEntityObject.quantity;

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
                if (e.Action == NotifyCollectionChangedAction.Add) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (ACC_T006_D item in e.NewItems)
                    {
                        item.ItemCode = ItemEntityObject.ItemCode;
                        item.sku = ItemEntityObject.sku;
                        item.item_line_id = ItemEntityObject.line_id;

                        item.qty = ItemEntityObject.quantity;
                        item.incoterm_value_doc = ItemEntityObject.net_value;
                        item.incoterm_value_local = ItemEntityObject.local_net_value;
                        item.PartyId = MasterEntity.PartyId;
                        item.exch_rate = MasterEntity.ex_rate;
                        item.location_Id = MasterEntity.location_Id;
                        item.comp_code = MasterEntity.comp_code;
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
                        item.location_Id = MasterEntity.location_Id;
                        item.comp_code = MasterEntity.comp_code;
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
                        item.location_Id = MasterEntity.location_Id;
                        item.comp_code = MasterEntity.comp_code;
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
                if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = false; /*ItemEntityObject.HasErrors;*/
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }

        //This will get called when the property of an object inside the collection changes
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            try
            {
                if (EntityChangeEnable == true)
                {
                    this.ErrorExist = false; /*MasterEntity.HasErrors;*/
                    if (sender.ToString() == "ind_trade" && MC.Banks != null)
                    {
                        ACC_M004_P POPUPEntityObject = MC.Banks.Where(x => (x.ind_trade ?? "X").Equals(MasterEntity.ind_trade ?? "", StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        if (POPUPEntityObject != null)
                        {
                            MasterEntity.bank_code = POPUPEntityObject.bank_code;
                            MasterEntity.bank_name = POPUPEntityObject.bank_name;
                            MasterEntity.hb_acc = POPUPEntityObject.hb_acc;
                        }
                    }

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

                        //MasterEntity.so_code = null;
                        //MasterEntity.sales_org = null;
                        //MasterEntity.sg_code = null;
                        //MasterEntity.sg_name = null;
                        //MasterEntity.location_Id = null;
                        //MasterEntity.LoctnNm = null;
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
                        ASLocation = new AutoSuggestTextViewModel<dynamic>(LocationList, TheFilter, SuggestedValue, "location_Id", true);
                        ASLocation.AutoSuggestVM.IsEmptyValueAllowed = true;
                        if (LocationList.Count == 1)
                        {
                            MasterEntity.location_Id = LocationList[0].location_Id;
                            MasterEntity.LoctnNm = SalesGroupList[0].LoctnNm;
                            ScheduleEntity.location_Id = MasterEntity.location_Id;
                        }
                        MasterEntity.org_country_cd = ((List<ADM_M002>)AppSessionState.ADM_M002_List).Where(x => x.comp_code == MasterEntity.comp_code).ToList()[0].country_code;
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
                    if (sender.ToString() == "location_Id" && string.IsNullOrWhiteSpace(MasterEntity.location_Id) == false && SelectedTaxList != null)
                    {
                        List<ACC_M013_P> tempTax = new List<ACC_M013_P>();
                        if (MasterEntity.buss_place == null)
                        {
                            tempTax = SelectedTaxList; // SelectedTaxList.Where(T => T.base_code_id == 1 || T.base_code_id == 2 || T.base_code_id == 3).ToList();
                            TaxDictoneryParent = tempTax.ToDictionary(X => X.id.ToString(), X => (object)X.description);
                        }
                        else if (MasterEntity.buss_place == ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(x => x.comp_code.Equals(MasterEntity.comp_code, StringComparison.OrdinalIgnoreCase) == true && x.location_Id.Equals(MasterEntity.location_Id, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].buss_place)
                        {
                            tempTax = SelectedTaxList.Where(T => T.base_code_id == 1 || T.base_code_id == 2 || T.base_code_id == null).ToList();
                            TaxDictoneryParent = tempTax.ToDictionary(X => X.id.ToString(), X => (object)X.description);
                        }
                        else if (MasterEntity.buss_place != ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(x => x.comp_code.Equals(MasterEntity.comp_code, StringComparison.OrdinalIgnoreCase) == true && x.location_Id.Equals(MasterEntity.location_Id, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].buss_place)
                        {
                            tempTax = SelectedTaxList.Where(T => T.base_code_id == 3 || T.base_code_id == null).ToList();
                            TaxDictoneryParent = tempTax.ToDictionary(X => X.id.ToString(), X => (object)X.description);
                        }
                    }
                    if (sender.ToString() == "curr_code")
                    {
                        if (MasterEntity.roundup_total > 0)
                        {
                            ADM_M037 curr_obj = new ADM_M037();
                            curr_obj = ((List<ADM_M037>)AppSessionState.CurrencyList).Where(x => x.curr_code == MasterEntity.curr_code).ToList()[0];
                            MasterEntity.amt_inword = num.AmountInWords(Convert.ToDecimal(MasterEntity.roundup_total), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word);
                        }
                    }
                    if (sender.ToString() == "incoterms")
                    {
                        if (!string.IsNullOrWhiteSpace(MasterEntity.incoterms))
                        {
                            if (MasterEntity.incoterms != "EXW" && MasterEntity.incoterms != "FOB")
                            {
                                MasterEntity.incoterm2 = MasterEntity.port_desc;
                            }
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
            try
            {
                if (EntityChangeEnable == true)
                {
                    //This will get called when the property of an object inside the collection changes
                    if (sender.ToString() == "line_id" || sender.ToString() == "quantity" || sender.ToString() == "unit_price" || sender.ToString() == "tax_id" || sender.ToString() == "active" || sender.ToString() == "discount" || sender.ToString() == "price_qty" || sender.ToString() == "qty_price" || sender.ToString() == "price_qty_uom")
                    {
                        PriceComputation(null, null, null);
                        Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
                        UpdateQtyInLicence();
                        if (ItemScheduleEntity.Count > 0 && ItemsEntity.Count > 0 && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < ItemsEntity.Count && dgSelectedIndexItem < ItemScheduleEntity.Count && isNewRecord == true && ItemEntityObject != null)
                        {
                            var item = ItemScheduleEntity.FirstOrDefault(i => i.line_id == ItemEntityObject.line_id);
                            if (item != null)
                            {
                                item.sch_qty = ItemEntityObject.quantity ?? 0;
                            }
                        }
                    }
                    if (sender.ToString() == "gross_wt")
                    {
                        MasterEntity.gross_wt = ItemsEntity.Where(item => item.active != false).Sum(item => Convert.ToDecimal(item.gross_wt));
                        MasterEntity.weight_unit = ItemsEntity[0].weight_unit;
                    }
                    if (sender.ToString() == "volume")
                    {
                        MasterEntity.volume = ItemsEntity.Where(item => item.active != false).Sum(item => Convert.ToDecimal(item.volume));
                        MasterEntity.volume_unit = ItemsEntity[0].volume_unit;
                    }
                    if (sender.ToString() == "net_wt")
                    {
                        MasterEntity.net_wt = ItemsEntity.Where(item => item.active != false).Sum(item => Convert.ToDecimal(item.net_wt));
                    }
                    this.ErrorExist = false; /*MasterEntity.HasErrors;*/
                    if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = false;/*ItemEntityObject.HasErrors;*/
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
                if (EntityChangeEnable == true && ItemEntityObject != null)
                {
                    if (SelectedItemScheduleEntity != null)
                    {
                        if (sender.ToString() == "del_date") // Note: remove this logic after purpose of this both fields become seperate. not it is same but confirm Date & Delivery date are seperate meaning so no same assignment require.
                        {
                            SelectedItemScheduleEntity.confirm_date = SelectedItemScheduleEntity.del_date;
                        }
                        if (sender.ToString() == "confirm_qty" || sender.ToString() == "sch_qty")
                        {
                            var temp = (from o in ItemScheduleEntity where o.item_line_id == ItemEntityObject.line_id select o).ToList();
                            if (temp.Count > 0 && ItemEntityObject.quantity > 0)
                            {
                                decimal? tempVar = ItemEntityObject.quantity;
                                foreach (var o in temp)
                                {
                                    if (o.confirm_qty.HasValue || o.sch_qty.HasValue)
                                    {
                                        if (o.confirm_qty > 0)
                                        {
                                            o.bal_qty = tempVar - Convert.ToDecimal(o.confirm_qty);
                                            tempVar = tempVar - Convert.ToDecimal(o.confirm_qty);
                                        }
                                        else
                                        {
                                            o.bal_qty = tempVar - Convert.ToDecimal(o.sch_qty);
                                            tempVar = tempVar - Convert.ToDecimal(o.sch_qty);
                                        }
                                    }

                                }
                            }
                        }
                        if (sender.ToString() == "confirm_date")
                        {
                            if (SelectedItemScheduleEntity.lead_time >= 0 && SelectedItemScheduleEntity.confirm_date.HasValue == true)
                            {
                                SelectedItemScheduleEntity.desp_date = SelectedItemScheduleEntity.confirm_date; //.Value.AddDays(Convert.ToInt32(SelectedItemScheduleEntity.lead_time));
                                SelectedItemScheduleEntity.del_date = SelectedItemScheduleEntity.confirm_date.Value.AddDays(Convert.ToInt32(SelectedItemScheduleEntity.lead_time));
                                if (ItemScheduleEntity != null)
                                {
                                    if (ItemScheduleEntity.Count > 0)
                                    {
                                        MasterEntity.shipment_date = ItemScheduleEntity.Max(dt => dt.confirm_date);
                                    }
                                }
                            }
                        }
                        if (sender.ToString() == "lead_time" || sender.ToString() == "desp_date")
                        {
                            if (SelectedItemScheduleEntity.lead_time >= 0 && SelectedItemScheduleEntity.desp_date.HasValue == true)
                            {
                                SelectedItemScheduleEntity.del_date = SelectedItemScheduleEntity.desp_date.Value.AddDays(Convert.ToInt32(SelectedItemScheduleEntity.lead_time));
                            }
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
        #region User Defined Functions
        private void DefaultValues()
        {
            try
            {
                EntityChangeEnable = true;
                MasterEntity.ts_code = this.ts_code_vm;
                MasterEntity.doc_cat = "SO";
                if (MC.DocumentTypes != null)
                {
                    if (MC.DocumentTypes.Count() == 1)
                    {
                        MasterEntity.doc_type = MC.DocumentTypes[0].doc_type;
                    }
                }
                MasterEntity.sales_person_cd = AppSessionState.EmpId;
                MasterEntity.seller_name = AppSessionState.EmpName;
                MasterEntity.comp_code = AppSessionState.comp_code;
                MasterEntity.location_Id = AppSessionState.location_Id;
                MasterEntity.add_by = AppSessionState.UserID;
                MasterEntity.editby = AppSessionState.UserID;
                MasterEntity.user_source1 = AppSessionState.UserSource1;
                MasterEntity.user_source2 = AppSessionState.UserSource2;
                MasterEntity.userid = AppSessionState.UserID;
                MasterEntity.active = true;
                MasterEntity.t_status = "001";
                MasterEntity.shipped = false;
                MasterEntity.version = "v1.0";
                MasterEntity.sodate = DateTime.Now;
                MasterEntity.sono = "";
                MasterEntity.ind_trade = "D";
                MasterEntity.net_value = 0;
                MasterEntity.other_charges = 0;
                MasterEntity.withholding_value = 0;
                MasterEntity.withholding_ex_amt = 0;
                Currency = AppSessionState.CntryCurncy;
                MasterEntity.client = AppSessionState.client;
                MasterEntity.expect_date = DateTime.Now;
                MasterEntity.org_country_cd = ((List<ADM_M002>)AppSessionState.ADM_M002_List).Where(x => x.comp_code == AppSessionState.comp_code).ToList()[0].country_code;

                ScheduleEntity.t_status = MasterEntity.t_status;
                ScheduleEntity.t_display = MasterEntity.t_display;
                ScheduleEntity.sch_date = DateTime.Now;
                ScheduleEntity.active = true;
                ScheduleEntity.add_by = AppSessionState.UserID;
                ScheduleEntity.editby = AppSessionState.UserID;
                ScheduleEntity.location_Id = AppSessionState.location_Id;
                ScheduleEntity.comp_code = AppSessionState.comp_code;
                ScheduleEntity.id = 0;
                ScheduleEntity.PartyId = MasterEntity.PartyId;


                DateTime d = DateTime.UtcNow;
                d = d.AddMonths(-1);
                RequestPara.FromDate = d;
                RequestPara.ToDate = DateTime.UtcNow;
                RequestPara.active = true;

                MasterEntity.valid_from_date = DateTime.UtcNow;
                MasterEntity.valid_to_date = DateTime.UtcNow.AddMonths(3);
                MasterEntity.validity_date = DateTime.UtcNow.AddMonths(3);

                MasterEntity.partshipment = "Not Allowed";
                MasterEntity.transhipment = "Not Allowed";
                //SetPopupSuggestionDataAfterLoad();

                if (MC.hbList != null)
                {
                    if (MC.hbList.Count == 1)
                    {
                        MasterEntity.hb_acc = MC.hbList[0].hb_acc;
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
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                isNewRecord = true;
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + (MasterEntity.sono ?? "") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "");
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MC, Request, "SalesOrderMaster", "CRM", "LoadAll", 0, "");

                var OrderType = (from o in MC.DocumentTypes where o.doc_cat == "SO" && o.default_doc == true select o).ToList();
                if (OrderType.Count == 1)
                {
                    MasterEntity.doc_type = OrderType[0].doc_type;
                    MasterEntity.doc_type_user = OrderType[0].doc_type_user;
                    MasterEntity.doc_desc = OrderType[0].doc_desc_user;
                }
                var tempt_display = (from o in MC.STATUS_LIST
                                     where o.t_status == (MasterEntity.t_status ?? "001")
                                     select o).ToList();
                MasterEntity.t_display = tempt_display[0].t_display;
                if (MC.Banks.Where(x => x.ind_default == true && x.comp_code == MasterEntity.comp_code).ToList().Count > 0)
                {
                    MasterEntity.bank_code = MC.Banks.Where(x => x.ind_default == true).ToList()[0].bank_code;
                    MasterEntity.bank_name = MC.Banks.Where(x => x.ind_default == true).ToList()[0].bank_name;
                }

                #region Autosuggest

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M002)o).CompName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCompany = new AutoSuggestTextViewModel<dynamic>((List<ADM_M002>)AppSessionState.ADM_M002_List, TheFilter, SuggestedValue, "comp_code", true);
                ASCompany.AutoSuggestVM.IsEmptyValueAllowed = true;
                MasterEntity.comp_code = AppSessionState.comp_code;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M037)x).ind_trade);
                TheFilter = (o, prefix) => (((SYS_M037)o).ind_trade ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M037)o).trade_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTradeIndicator = new AutoSuggestTextViewModel<dynamic>(MC.Trade_Types, TheFilter, SuggestedValue, "ind_trade", true);
                ASTradeIndicator.AutoSuggestVM.IsEmptyValueAllowed = false;
                ASTradeIndicator.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASUOMPRICEQTY = new AutoSuggestTextViewModel<dynamic>(MC.UOM, TheFilter, SuggestedValue, "price_qty_uom", "unit_code", true);
                ASUOMPRICEQTY.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASUOMPRICEQTY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyNm);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower());
                AutoSuggestTextViewModel = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyNm", true);
                AutoSuggestTextViewModel.AutoSuggestVM.IsEmptyValueAllowed = true;
                AutoSuggestTextViewModel.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P_SO_ItemsList)x).ItemCode);
                TheFilter = (o, prefix) => (((SEL_T001_P_SO_ItemsList)o).ItemCode ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower()) || (((SEL_T001_P_SO_ItemsList)o).ItemName ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M003_P)x).sditem_cat_code);
                TheFilter = (o, prefix) => (((SYS_M003_P)o).sditem_cat_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M003_P)o).item_cat_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASItemLineCat = new AutoSuggestTextViewModel<dynamic>(MC.ItemLineCategory, TheFilter, SuggestedValue, "item_cat", "sditem_cat_code", true);
                ASItemLineCat.AutoSuggestVM.IsEmptyValueAllowed = true;

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

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M044_P)x).incoterms);
                TheFilter = (o, prefix) => (((ADM_M044_P)o).incoterms ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M044_P)o).inco_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault4 = new AutoSuggestTextViewModel<dynamic>(MC.Incoterms, TheFilter, SuggestedValue, "incoterms", "incoterms", true);
                ASDefault4.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault4.AutoSuggestVM.IsFreeTextAllowed = true;



                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M002)x).doc_type_user);
                TheFilter = (o, prefix) => (((SYS_M002)o).doc_type_user ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M002)o).doc_desc_user ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSOtype = new AutoSuggestTextViewModel<dynamic>(MC.DocumentTypes, TheFilter, SuggestedValue, "doc_type_user", true);
                ASSOtype.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSoldToParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyId", true);
                ASSoldToParty.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASSoldToParty.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASShipToParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "ship_to_party", true);
                ASShipToParty.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASShipToParty.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASNotifyParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "notify_party", true);
                ASNotifyParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASNotifyParty2 = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "notify_party", true);
                ASNotifyParty2.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037_P)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M037_P)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCurrency = new AutoSuggestTextViewModel<dynamic>(MC.Currencys, TheFilter, SuggestedValue, "curr_code", true);
                ASCurrency.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037_P)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M037_P)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASdgCurrency = new AutoSuggestTextViewModel<dynamic>(MC.Currencys, TheFilter, SuggestedValue, "curr_code", "curr_code", true);
                ASdgCurrency.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M007_P)x).p_term_code);
                TheFilter = (o, prefix) => (((ACC_M007_P)o).p_term_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M007_P)o).p_term ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPayTerms = new AutoSuggestTextViewModel<dynamic>(MC.PayTerms, TheFilter, SuggestedValue, "p_term_code", true);
                ASPayTerms.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSalesPerson = new AutoSuggestTextViewModel<dynamic>(MC.Sellers, TheFilter, SuggestedValue, "sales_person_cd", true);
                ASSalesPerson.AutoSuggestVM.IsEmptyValueAllowed = true;


                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSalesPersonView = new AutoSuggestTextViewModel<dynamic>(MC.Sellers, TheFilter, SuggestedValue, "EmpId", true);
                ASSalesPersonView.AutoSuggestVM.IsEmptyValueAllowed = true;

                SalesOrganisationList = ((List<ADM_M001_A_P>)AppSessionState.ADM_M001_A_List).Where(item => item.comp_code == (MasterEntity.comp_code ?? AppSessionState.comp_code)).ToList();
                //SalesOrganisationList = (List<ADM_M001_A_P>)AppSessionState.ADM_M001_A_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).so_code);
                TheFilter = (o, prefix) => (((ADM_M001_A_P)o).so_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M001_A_P)o).sales_org ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSalesOrg = new AutoSuggestTextViewModel<dynamic>(SalesOrganisationList, TheFilter, SuggestedValue, "so_code", true);

                SalesGroupList = ((List<ADM_M001_H_P>)AppSessionState.ADM_M001_H_List).Where(item => item.so_code == AppSessionState.so_code).ToList();
                //SalesGroupList = (List<ADM_M001_H_P>)AppSessionState.ADM_M001_H_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_H_P)x).sg_code);
                TheFilter = (o, prefix) => (((ADM_M001_H_P)o).sg_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M001_H_P)o).sg_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSalesGroup = new AutoSuggestTextViewModel<dynamic>(SalesGroupList, TheFilter, SuggestedValue, "sg_code", true);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASRefferingParty = new AutoSuggestTextViewModel<dynamic>(MC.ServiceProviders, TheFilter, SuggestedValue, "referring_party", true);
                ASRefferingParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M004_P)x).bank_code);
                TheFilter = (o, prefix) => (((ACC_M004_P)o).bank_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M004_P)o).bank_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASOurBank = new AutoSuggestTextViewModel<dynamic>(MC.Banks, TheFilter, SuggestedValue, "bank_code", true);
                ASOurBank.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M004_P)x).bank_code);
                TheFilter = (o, prefix) => (((ACC_M004_P)o).bank_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M004_P)o).bank_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASNastroBank = new AutoSuggestTextViewModel<dynamic>(MC.Banks, TheFilter, SuggestedValue, "nastro_bank_cd", true);
                ASNastroBank.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M044_P)x).incoterms);
                TheFilter = (o, prefix) => (((ADM_M044_P)o).incoterms ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M044_P)o).inco_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASIncoTerms = new AutoSuggestTextViewModel<dynamic>(MC.Incoterms, TheFilter, SuggestedValue, "incoterms", true);
                ASIncoTerms.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTransporter = new AutoSuggestTextViewModel<dynamic>(MC.Transporters, TheFilter, SuggestedValue, "transporter_cd", true);
                ASTransporter.AutoSuggestVM.IsEmptyValueAllowed = true;

                LocationList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                // var LocList = (from o in LocationList where o.location_Id == AppSessionState.location_Id select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASLocation = new AutoSuggestTextViewModel<dynamic>(LocationList, TheFilter, SuggestedValue, "location_Id", true);
                ASLocation.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M002)x).doc_type_user);
                TheFilter = (o, prefix) => (((SYS_M002)o).doc_type_user ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M002)o).doc_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDoctype = new AutoSuggestTextViewModel<dynamic>(MC.DocumentTypes, TheFilter, SuggestedValue, "doc_type_user", true);
                ASDoctype.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((CRM_M001_P)x).con_type);
                TheFilter = (o, prefix) => (((CRM_M001_P)o).con_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((CRM_M001_P)o).long_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTermsCond = new AutoSuggestTextViewModel<dynamic>(MC.TermsConditionCollection, TheFilter, SuggestedValue, "con_type", "con_type", true);
                ASTermsCond.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyNm);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASdgTransporter = new AutoSuggestTextViewModel<dynamic>(MC.Transporters, TheFilter, SuggestedValue, "PartyNm", "PartyNm", true);
                ASdgTransporter.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASUOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASUOM.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASUOM.AutoSuggestVM.IsFreeTextAllowed = false;


                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASOrderTo = new AutoSuggestTextViewModel<dynamic>(LocationList, TheFilter, SuggestedValue, "order_to_plant", "location_Id", true);
                ASOrderTo.AutoSuggestVM.IsEmptyValueAllowed = true;

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

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASt_status = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_display", true);
                ASt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                //Filters AutoSuggest
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASFltrt_status = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_status", true);
                ASFltrt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => ((ADM_M028_P)o).PartyNm.ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M028_P)o).PartyId.ToString().ToLower().Contains(prefix.ToLower());
                ASFltrSoldToParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyId", true);
                ASFltrSoldToParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M002)x).doc_type_user);
                TheFilter = (o, prefix) => ((SYS_M002)o).doc_type_user.ToString().ToLower().Contains(prefix.ToLower());
                ASFltrt_DocType = new AutoSuggestTextViewModel<dynamic>(MC.DocumentTypes, TheFilter, SuggestedValue, "doc_type_user", true);
                ASFltrt_DocType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyNm);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSchShipToParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "ship_to_PartyNm", "PartyNm", true);
                ASSchShipToParty.AutoSuggestVM.IsEmptyValueAllowed = true;
                //ASSchShipToParty.AutoSuggestVM.SuggestionPreview = null;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASFilterLocation = new AutoSuggestTextViewModel<dynamic>(LocationList, TheFilter, SuggestedValue, "location_Id", true);
                ASFilterLocation.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M019_P)x).cost_center);
                TheFilter = (o, prefix) => (((ACC_M019_P)o).cost_center ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCostCentre = new AutoSuggestTextViewModel<dynamic>(MC.Cost_Centers, TheFilter, SuggestedValue, "cost_center", true);
                ASCostCentre.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M026)x).tr_mode);
                TheFilter = (o, prefix) => (((SYS_M026)o).tr_mode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M026)o).tr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTR_MODE = new AutoSuggestTextViewModel<dynamic>(MC.TransportMode, TheFilter, SuggestedValue, "tr_mode", true);
                ASTR_MODE.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASTR_MODE.AutoSuggestVM.IsFreeTextAllowed = false;

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
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCF_Agent = new AutoSuggestTextViewModel<dynamic>(MC.ServiceProviders, TheFilter, SuggestedValue, "PartyId", true);
                ASCF_Agent.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASCF_Agent.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002_B)x).CatCode);
                TheFilter = (o, prefix) => (((ADM_M002_B)o).CatCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M002_B)o).cat_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASScope = new AutoSuggestTextViewModel<dynamic>(MC.ScopeList, TheFilter, SuggestedValue, "CatCode", true);
                ASScope.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASScope.AutoSuggestVM.IsFreeTextAllowed = false;
                #endregion

                UnitConversionList = MC.UnitConversion;

                var refdoc = (from o in MC.Sales_Order_Reference where o.doc_cat == "SN" select o).ToList();

                ReferenceDocSNCollection = CollectionViewSource.GetDefaultView(refdoc);
                ReferenceDocSNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                refdoc = (from o in MC.Sales_Order_Reference where o.doc_cat == "QN" select o).ToList();

                ReferenceDocQNCollection = CollectionViewSource.GetDefaultView(refdoc);
                ReferenceDocQNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                TermsConditionCollection = CollectionViewSource.GetDefaultView(MC.TermsConditionCollection);

                TaxDictonery = new Dictionary<string, object>();
                TaxDictonery.Clear();
                TaxDictonery = MC.TaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);

                var TaxListParent = (from o in MC.TaxList
                                     where o.parent_id == null
                                     select o).ToList();
                SelectedTaxList = TaxListParent;
                TaxDictoneryParent = SelectedTaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);

                NotificationDataCollection = MC.NotificationData;

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
        private void CommandInitialization()
        {
            CursorControl.SetBusyState();
            try
            {
                #region Command Initialisation
                cmdSelectionChanged_SEL_T001_A = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_SEL_T001_A(items); });
                cmdSelectionChangedSchedule = new RelayCommand<object>(items => { if (items == null) { return; } ScheduleDataGridRowSelectionChanged(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                AddRemoveManualTax = new RelayCommand<bool>(ActiveInactiveTax);
                cmddgLocation = new RelayCommand<object>(items => { if (items == null) { return; } Insertdgplant(items); });
                CommandDocTypeBf = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocTypeBf(items); });
                cmdPlant = new RelayCommand<object>(items => { if (items == null) { return; } Insertplant(items); });
                CmdLicence = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicence(cmdPara, false, true, true); });
                cmdSupplier = new RelayCommand<object>(items => { if (items == null) { return; } InsertSupplier(items); });
                cmdTR_Mode = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTR_Mode(cmdPara); });
                cmdTR_ModeMaster = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTR_ModeMaster(cmdPara); });
                cmddgTransporter = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgTransporter(cmdPara, false, true, true); });
                CommandDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocType(items); });
                CommandLoadDocumentFromSource = new GalaSoft.MvvmLight.Command.RelayCommand(() => LoadSourceDocument()); // confirm assignment
                CommandSoldToParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertSoldToParty(items, isNewRecord); });
                CommandShipToParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertShipToParty(items, isNewRecord); });
                CommandNotifyParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertNotifyParty(items, true); });
                CommandNotifyParty2 = new RelayCommand<object>(items => { if (items == null) { return; } InsertNotifyParty2(items, true); });
                CommandSoldToAddress = new RelayCommand<object>(items => { if (items == null) { return; } InsertSoldToAddress(items, true); });
                CommandShipToAddress = new RelayCommand<object>(items => { if (items == null) { return; } InsertShipToAddress(items, true); });
                CommandTransporter = new RelayCommand<object>(items => { if (items == null) { return; } InsertTransporter(items, false); });
                CommandServiceProvider = new RelayCommand<object>(items => { if (items == null) { return; } InsertServiceProvider(items, false); });
                CommandUOM = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOM(cmdPara, false, true, true); });
                CommandUOMPriceQty = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOMPriceQty(cmdPara, false, true, true); });
                CommandSeller = new RelayCommand<object>(items => { if (items == null) { return; } InsertSeller(items); });
                CommandGLCode = new RelayCommand<object>(items => { if (items == null) { return; } InsertGLCode(items); });
                CommandPayTerms = new RelayCommand<object>(items => { if (items == null) { return; } InsertPayTerm(items); });
                CommandCurrency = new RelayCommand<object>(items => { if (items == null) { return; } InsertCurrency(items); });
                CmddgCurrency = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgCurrency(cmdPara); });
                CommandSalseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseOrg(items); });
                CommandSalseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseGroup(items); });
                CommandSalseDivision = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseDivision(items); });
                CommandItemCategory = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItemCategory(cmdPara, false, true, true); });
                CommandCostCenter = new RelayCommand<object>(items => { if (items == null) { return; } InsertCostCenter(items); });
                CommandBank = new RelayCommand<object>(items => { if (items == null) { return; } InsertBank(items); });
                CommandNastroBank = new RelayCommand<object>(items => { if (items == null) { return; } InsertNastroBank(items); });
                CommandBuyer = new RelayCommand<object>(items => { if (items == null) { return; } InsertBuyer(items); });
                CommandItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara, true, true, true); });
                CommandTerms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTerms(cmdPara, true, true, true); });
                CommandDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });// confirm assignment
                CommandDeleteDataGridRowSchedule = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_ItemSchedule(cmdPara); });// confirm assignment
                CommandDeleteDataGridRowLicence = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_ItemLicence(cmdPara); });// confirm assignment
                CommandLocations = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLocation(cmdPara); });// confirm assignment
                CommandLicenseAdvance = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicenseAdvance(cmdPara); });// confirm assignment
                CommandLicenseEPCG = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicenseEPCG(cmdPara); });// confirm assignment
                CommandIncoterms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertIncoterms(cmdPara); });// confirm assignment
                CmddgIncoterms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgIncoterms(cmdPara, false, true, true); });
                CommandActiveInactiveCheck = new RelayCommand<bool>(CheckActiveStatus); // confirm assignment
                CommandReferenceDoc = new RelayCommand<object>(items => { if (items == null) { return; } InsertReferenceDoc(items); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); }); // confirm assignment
                CommandLoadDocumentByRefDocNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByReferenceDocumentNumber(cmdPara, "FlipGridReference"); }); // confirm assignment
                cmdDeleteTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteTax(cmdPara); });
                ManualTaxChangedCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertManualTaxChangedCommand(cmdPara); });
                CommandAddSelectedTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSelectedTax(cmdPara); });
                CmdCondType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertConditiontype(cmdPara); });
                CommandGrade = new RelayCommand<object>(items => { if (items == null) { return; } InsertGrade(items); });
                cmdMail = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } MailDocuments(cmdPara); });
                cmdPrint = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } PrintDocuments(cmdPara); });
                CommandDeleteDataGridTerms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Terms(cmdPara); });
                cmdRefContactPerson = new RelayCommand<object>(items => { if (items == null) { return; } InsertRefContactPerson(items); });
                cmdLoadBackFlip = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadBackFlipData(cmdPara); });
                CmdUnitPrice = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } CheckPrice(cmdPara, false, true, true); });
                CmdItemInfo = new RelayCommand<object>(items => { if (items == null) { return; } FilterItemSalesData(items); });
                cmdOpenAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenDocumentViewer(cmdPara); });
                cmdBussPlace = new RelayCommand<object>(items => { if (items == null) { return; } InsertBussPlace(items); });
                cmddgBussPlace = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgBussPlace(cmdPara, false, true, true); });
                CmddgShipToParty = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgShipToParty(cmdPara, false, true, true); });
                CollectionChangedCommand = new RelayCommand<IList>(items => { if (items == null) { return; } CollectionChanged(items); });
                SelectionChangedParaValCommand = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedParaValue(items); });
                CmdInsert_t_status = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_t_status(cmdPara); });
                CmdAddSelectedRef = new RelayCommand<object>(items => { if (items == null) { return; } AddSelectedRef(items); });
                CommandFltrDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrDocType(items); });
                CommandFltrStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrStatus(items); });
                CommandFltrSoldToParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrSoldToParty(items); });
                CommandFilterSeller = new RelayCommand<object>(items => { if (items == null) { return; } InsertFilterSeller(items); });
                cmdSchShipToParty = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSchShipToParty(cmdPara, false, true, true); });
                cmdSchShipToAdd = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSchShipToAddress(cmdPara, false, true, true); });
                CommandTermsScope = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTermsScope(cmdPara, true, true, true); });
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
                            m.qty = o.quantity;
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
            SEL_T001_A EntityObjectParameter = new SEL_T001_A();
            MultipleContext_Attachments MCAttachments = new MultipleContext_Attachments();
            try
            {
                if (InputValue != null)
                {
                    EntityObjectParameter = ((IEnumerable)InputValue).Cast<SEL_T001_A>().ToList()[0];
                }
                string Request = "GetAllFiles" + "!@" + AppSessionState.client + "!@" + (EntityObjectParameter.comp_code ?? AppSessionState.comp_code) + "!@" + (EntityObjectParameter.location_Id ?? AppSessionState.location_Id) + "!@" + (doc_cat_vm ?? "") + "!@" + doc_cat_vm + "!@" + EntityObjectParameter.sono + "!@" + EntityObjectParameter.id.ToString();
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
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                EntityChangeEnable = false;
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
                EntityChangeEnable = true;
            }
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

                    //string Request1 = "GetItemPrice" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.sono  + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + MasterEntity.PartyId + "!@" + ItemsEntityObject.ItemCode;
                    string Request1 = "GetItemPrice" + "!@" + ItemsEntityObject.ItemCode + "!@" + MasterEntity.PartyId + "!@" + MasterEntity.sono + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.EmpId + "!@" + AppSessionState.UserID + "!@" + MasterEntity.ts_code;
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
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
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
                            gross_value_A = Math.Round((gross_value_A ?? 0), RoundUpDecimals);
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
                                    TaxAmount = Math.Round(TaxAmount ?? 0, RoundUpDecimals);
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
                                            location_Id = MasterEntity.location_Id,
                                            comp_code = MasterEntity.comp_code,
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
                            if (o.ItemCode == p.ItemCode && (o.sku?.ToString() ?? "") == (p.sku?.ToString() ?? ""))
                            {
                                flag++;
                            }
                        }

                    }
                    foreach (var N in TotalDocumentTaxes)
                    {
                        if (N.ItemCode == o.ItemCode)
                        {
                            N.sku = o.sku;
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
                if (MasterEntity.party_name == null || MasterEntity.party_name == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Sold To Party is Required");
                    showMessageService.ShowMessage();

                    return false;
                }
                if (MasterEntity.ship_to_party_name == null || MasterEntity.ship_to_party_name == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Ship To Party is Required");
                    showMessageService.ShowMessage();

                    return false;
                }
                if (MasterEntity.del_address == null || MasterEntity.del_address == 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Shipping Address Is Required");
                    showMessageService.ShowMessage();

                    return false;
                }
                if (MasterEntity.bill_address_id == null || MasterEntity.bill_address_id == 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Billing Address Is Required");
                    showMessageService.ShowMessage();

                    return false;
                }
                foreach (var o in ItemScheduleEntity)
                {
                    string item_cat = ""; //ItemsEntity.FirstOrDefault(i => i.line_id == o.line_id).item_cat;
                    var item = ItemsEntity.FirstOrDefault(i => i.line_id == o.line_id);
                    if (item != null)
                    {
                        item_cat = ItemEntityObject.item_cat ?? "";
                    }
                    if (item_cat == "SIC" && (o.ship_to_add == null || o.ship_to_add == "" || o.ship_to_add == "0"))
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Shipping address required in Schedule!");
                        showMessageService.ShowMessage();

                        return false;
                    }
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

                }

                if (MasterEntity.doc_cat == "OP")
                {
                    if (MasterEntity.valid_from_date == null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Validity From Date is Required for Open Order Category");
                        showMessageService.ShowMessage();

                        return false;
                    }
                    if (MasterEntity.valid_to_date == null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Validity To Date is Required for Open Order Category");
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
                if (ItemScheduleEntity != null && ItemScheduleEntity.Count > 0 && dgSelectedIndexItem >= 0
                       && ItemsEntity != null && ItemsEntity.Count > 0 && ItemEntityObject != null)
                {

                    if (ItemEntityObject.ItemCode != null)
                    {
                        DataGridViewFilter = CollectionViewSource.GetDefaultView(ItemScheduleEntity);
                        DataGridViewFilter.Filter = adv => ((SEL_T002_A)adv).item_line_id.Equals(ItemEntityObject.line_id) && ((SEL_T002_A)adv).ItemCode.Equals(ItemEntityObject.ItemCode);
                        DataGridViewFilter.Refresh();
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
        private void FilterLicenceDataGrid()
        {
            try
            {
                if (LicenceDetailsEntity != null && LicenceDetailsEntity.Count > 0 && dgSelectedIndexItem >= 0
                    && ItemsEntity != null && ItemsEntity.Count > 0 && ItemEntityObject != null)
                {
                    if (ItemEntityObject.ItemCode != null)
                    {
                        DataGridViewFilter = CollectionViewSource.GetDefaultView(LicenceDetailsEntity);
                        DataGridViewFilter.Filter = adv => ((ACC_T006_D)adv).ItemCode.Equals(ItemEntityObject.ItemCode);
                        DataGridViewFilter.Refresh();
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
                    html += "<td width=10%> <p><strong><span style=color:#000080;> " + item.Description + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.quantity.ToString() + "</span></strong></p> </td>";
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
        #endregion
        #region Filters
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
                        (data.sales_org != null && data.sales_org.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.sg_name != null && data.sg_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.t_display != null && data.t_display.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.reference != null && data.reference.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.remark1 != null && data.remark1.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.party_name != null && data.party_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
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
                            (data.CstmrItmCod != null && data.CstmrItmCod.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            (data.CstmrItmDesc != null && data.CstmrItmDesc.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower()));
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
            if (ReferenceDocSNCollection != null)
            {
                ReferenceDocSNCollection.Refresh();
            }
            if (ReferenceDocQNCollection != null)
            {
                ReferenceDocQNCollection.Refresh();
            }
        }
        public bool Filter_ReferenceDoc(object obj)
        {
            var data = obj as SEL_T001_P_RefDoc;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_ReferenceDoc))
                {
                    return (data.sono != null && data.sono.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                            data.cust_ref != null && data.cust_ref.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                            data.party_name != null && data.party_name.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                            data.sodate != null && data.sodate.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower())
                       );
                }
                return true;
            }
            return false;
        }


        #endregion
    }
}
