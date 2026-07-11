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
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ReflectionSystem;
using System.Reflection;
using Reflection.Presentation.Core.VirtualDesktops;
using GalaSoft.MvvmLight.Ioc;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class SEL_T003_Essem_VM1 : WorkspaceViewModel<SEL_T003>
    {
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SEL_T003_Essem_VM1));
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
        private AutoSuggestTextViewModel<dynamic> _ASDocCat { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocCat
        {
            get { return _ASDocCat; }
            set
            {
                if (_ASDocCat != value)
                {
                    _ASDocCat = value; RaisePropertyChanged("ASDocCat");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDocCat1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocCat1
        {
            get { return _ASDocCat1; }
            set
            {
                if (_ASDocCat1 != value)
                {
                    _ASDocCat1 = value; RaisePropertyChanged("ASDocCat1");
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
        private AutoSuggestTextViewModel<dynamic> _ASPlant1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPlant1
        {
            get { return _ASPlant1; }
            set
            {
                if (_ASPlant1 != value)
                {
                    _ASPlant1 = value; RaisePropertyChanged("ASPlant1");
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
        private AutoSuggestTextViewModel<dynamic> _ASGodown { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGodown
        {
            get { return _ASGodown; }
            set
            {
                if (_ASGodown != value)
                {
                    _ASGodown = value; RaisePropertyChanged("ASGodown");
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
        private AutoSuggestTextViewModel<dynamic> _ASSaleDivision { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSaleDivision
        {
            get { return _ASSaleDivision; }
            set
            {
                if (_ASSaleDivision != value)
                {
                    _ASSaleDivision = value; RaisePropertyChanged("ASSaleDivision");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDisbtnChannel { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDisbtnChannel
        {
            get { return _ASDisbtnChannel; }
            set
            {
                if (_ASDisbtnChannel != value)
                {
                    _ASDisbtnChannel = value; RaisePropertyChanged("ASDisbtnChannel");
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
        private AutoSuggestTextViewModel<dynamic> _ASProdNm { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASProdNm
        {
            get { return _ASProdNm; }
            set
            {
                if (_ASProdNm != value)
                {
                    _ASProdNm = value; RaisePropertyChanged("ASProdNm");
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
                    else if (SourceName == "item_cat")
                    { ASDefault = ASItemLineCat; }
                    else if (SourceName == "weight_unit")
                    { ASDefault = ASWTUnit; }
                    else if (SourceName == "volume_unit")
                    { ASDefault = ASVolUOM; }
                    else if (SourceName == "para2")
                    { ASDefault = ASInk; }
                    else if (SourceName == "para5")
                    { ASDefault = ASILD; }
                    else if (SourceName == "gl_code")
                    { ASDefault1 = ASTaxacc; }
                    else if (SourceName == "curr_code")
                    { ASDefault1 = ASdgCurrency; }
                    else if (SourceName == "con_type")
                    { ASDefault1 = ASConditionType; }
                    else if (SourceName == "buss_place")
                    { ASDefault = ASdgBussPlace; }
                    else if (SourceName == "ship_to_Party")
                    { ASDefault = ASdgShipToParty; }


                }
            }
        }

        #endregion

        #region Variable Declaration

        string Currency;
        string PartyEmailId = "";
        string PersonEmailId = "";
        string PreviousUnitCode = "";
        string NewUnitCode = "";
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
        public string doc_cat_vm { get; set; }
        public string doc_no_vm { get; set; }
        private bool _AutoRoundupEnable;
        private bool AutoRoundupEnable
        {
            get { return _AutoRoundupEnable; }
            set
            {
                if (_AutoRoundupEnable != value)
                {
                    _AutoRoundupEnable = value; RaisePropertyChanged("AutoRoundupEnable");
                }
            }
        }
        private int RoundUpDecimals = 2;
        public string ref_doc_cat { get; set; }
        public string PartyId { get; set; }
        NumberToEnglish num = new NumberToEnglish();
        WebServiceRepository<SEL_T003> repository = new WebServiceRepository<SEL_T003>();
        WebServiceRepository<MultipleContext_SEL_T003> repository_MC = new WebServiceRepository<MultipleContext_SEL_T003>();
        WebServiceRepository<MultipleContext_SEL_T003> repository_MCTemp = new WebServiceRepository<MultipleContext_SEL_T003>();
        WebServiceRepository<MultipleContext_LOG_T001_A> repositoryM = new WebServiceRepository<MultipleContext_LOG_T001_A>();

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
        private MultipleContext_SEL_T003 _MC = new MultipleContext_SEL_T003();
        public MultipleContext_SEL_T003 MC
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

        private MultipleContext_SEL_T003 _MCTemp = new MultipleContext_SEL_T003();
        public MultipleContext_SEL_T003 MCTemp
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

        private MultipleContext_LOG_T001_A _MCTemp2 = new MultipleContext_LOG_T001_A();
        public MultipleContext_LOG_T001_A MCTemp2
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

        private string _ReportOption;
        public string ReportOption
        {
            get { return _ReportOption; }
            set
            {
                if (_ReportOption != value)
                {
                    _ReportOption = value;
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
                    ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
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

        // Flip DataGrid Data Source
        private List<SEL_T003Flip> _FlipGridData;
        public List<SEL_T003Flip> FlipGridData
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

        // List of item default or as per Party changes. * can be replace with ICollection View.
        //remaining to create popup for item
        public List<SEL_T003_P_SI_ItemsList> _ItemListForPopup;
        public List<SEL_T003_P_SI_ItemsList> ItemListForPopup
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

        public List<SEL_T003_P_RefDoc> _refdoctempa;
        public List<SEL_T003_P_RefDoc> refdoctempa
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

        private ObservableCollection<ACC_T006_C> _TotalDocumentTaxesSummury;
        //Group by Taxes irespective of Items.
        public ObservableCollection<ACC_T006_C> TotalDocumentTaxesSummury
        {
            get
            {
                return _TotalDocumentTaxesSummury;
            }
            set
            {
                _TotalDocumentTaxesSummury = value;

                RaisePropertyChanged("TotalDocumentTaxesSummury");
                TotalDocumentTaxesSummury.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
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
                    //if (TotalDocumentTaxesItem.Count > 0)
                    //{
                    //    TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_C>(TotalDocumentTaxes.Where(tax => tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[dgSelectedIndexItem].sku?.ToString() ?? "") && tax.item_line_id == ItemsEntity[dgSelectedIndexItem].id));
                    //}
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

        #endregion

        #region ICollection for Popup Control

        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }

        private ICollectionView _AttachmentCollection;
        public ICollectionView AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set { _AttachmentCollection = value; RaisePropertyChanged("AttachmentCollection"); }
        }

        private ICollectionView _ParameterCollection;
        public ICollectionView ParameterCollection
        {
            get { return _ParameterCollection; }
            set { _ParameterCollection = value; RaisePropertyChanged("ParameterCollection"); }
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

        private ICollectionView _popupItemCollection;
        public ICollectionView PopupItemCollection
        {
            get { return _popupItemCollection; }
            set { _popupItemCollection = value; RaisePropertyChanged("PopupItemCollection"); }
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

        private ICollectionView _ReferenceDocSOCollection;
        public ICollectionView ReferenceDocSOCollection
        {
            get { return _ReferenceDocSOCollection; }
            set { _ReferenceDocSOCollection = value; RaisePropertyChanged("ReferenceDocSOCollection"); }
        }
        private ICollectionView _ReferenceDocDNCollection;
        public ICollectionView ReferenceDocDNCollection
        {
            get { return _ReferenceDocDNCollection; }
            set { _ReferenceDocDNCollection = value; RaisePropertyChanged("ReferenceDocDNCollection"); }
        }
        private ICollectionView _doc_typeCollection;
        public ICollectionView doc_typeCollection
        {
            get { return _doc_typeCollection; }
            set { _doc_typeCollection = value; RaisePropertyChanged("doc_typeCollection"); }
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

        private List<string> _StringListSOReferenceDoc;
        public List<string> StringListSOReferenceDoc
        {
            get { return _StringListSOReferenceDoc; }
            set
            {
                if (_StringListSOReferenceDoc != value)
                {
                    _StringListSOReferenceDoc = value;
                }
            }
        }
        private List<string> _StringListDNReferenceDoc;
        public List<string> StringListDNReferenceDoc
        {
            get { return _StringListDNReferenceDoc; }
            set
            {
                if (_StringListDNReferenceDoc != value)
                {
                    _StringListDNReferenceDoc = value;
                }
            }
        }

        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> CommandExchangeRate { get; private set; }
        public RelayCommand<object> cmdExportDocType { get; private set; }
        public RelayCommand<object> cmdRefDoc { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdPrintLable { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdPrintLableOne { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdPackingList { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdPrintReport { get; private set; }
        public RelayCommand<object> CommandSoldToParty { get; private set; }
        public RelayCommand<object> cmdTR_ModeMaster { get; private set; }
        public RelayCommand<object> CommandTransporter { get; private set; }
        public RelayCommand<object> CommandServiceProvider { get; private set; }
        public RelayCommand<object> CommandUOM { get; private set; }
        public RelayCommand<object> CommandJournal { get; private set; }
        public RelayCommand<object> CommandPayTerms { get; private set; }
        public RelayCommand<object> CommandCurrency { get; private set; }
        public RelayCommand<object> CmddgCurrency { get; private set; }
        public RelayCommand<object> CommandSalseOrg { get; private set; }
        public RelayCommand<object> cmdSalseGroup { get; private set; }
        public RelayCommand<object> CommandSalseDivision { get; private set; }
        public RelayCommand<object> CommandItemCategory { get; private set; }
        public RelayCommand<object> CommandCostCenter { get; private set; }
        public RelayCommand<object> CommandBank { get; private set; }
        public RelayCommand<object> CommandDocType { get; private set; }
        public RelayCommand<object> CommandNastroBank { get; private set; }
        public RelayCommand<object> CommandILD { get; private set; }
        public RelayCommand<object> CommandInk { get; private set; }
        public RelayCommand<object> CommandBuyer { get; private set; }
        public RelayCommand<object> CommandGodown { get; private set; }
        public RelayCommand<object> CommandReferenceDoc { get; private set; }
        public RelayCommand<object> CommandItem { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CommandLocations { get; private set; }
        public RelayCommand<object> CommandLicenseAdvance { get; private set; }
        public RelayCommand<object> CommandLicenseEPCG { get; private set; }
        public RelayCommand<object> CommandSoldToPartyAddress { get; private set; }
        public RelayCommand<object> CommandproductDescription { get; private set; }
        public RelayCommand<object> CommandFormType { get; private set; }
        public RelayCommand<object> CommandPayer { get; private set; }//check 
        public RelayCommand<object> CommandDeliveryAddress { get; private set; }
        public RelayCommand<object> cmdSeller { get; private set; }
        public RelayCommand<object> Commandwtunit
        {
            get;
            private set;
        }
        public RelayCommand<object> CommandVolUnit
        {
            get;
            private set;
        }
        public RelayCommand<object> CommandPlant
        {
            get;
            private set;
        }
        public RelayCommand<object> CommandCountry
        {
            get;
            private set;
        }
        public RelayCommand<object> Commandcf_agent
        {
            get;
            private set;
        }
        public RelayCommand<object> commandSource
        {
            get;
            private set;
        }
        public RelayCommand<object> CommandDistributionChannel { get; private set; }
        public RelayCommand<object> CommandAddSelectedTax { get; private set; }
        public RelayCommand<object> CmdCondType { get; private set; }
        public RelayCommand<object> CommandCustCatlogNo
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedParaValCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> CollectionChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> cmdDeleteTax { get; private set; }
        public RelayCommand<object> ManualTaxChangedCommand { get; private set; }
        public RelayCommand<object> CommandMailDocuments { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdForLoadBackFlip { get; private set; }
        public RelayCommand<object> cmdPrintChallan { get; private set; }
        public RelayCommand<object> CommandLocation { get; private set; }
        public RelayCommand<object> cmdOpenAttachments { get; private set; }
        public RelayCommand<object> cmdBussPlace { get; private set; }
        public RelayCommand<object> cmddgBussPlace { get; private set; }
        public RelayCommand<object> CmddgShipToParty { get; private set; }
        public RelayCommand<object> cmdReportData { get; private set; }
        public RelayCommand<object> CommandLoadHistory { get; private set; }
        public RelayCommand<object> CommandFltrDocType { get; private set; }
        public RelayCommand<object> CommandFltrStatus { get; private set; }
        public RelayCommand<object> CommandFltrSoldToParty { get; private set; }
        public RelayCommand<object> CmdAddSelectedRef { get; private set; }
        public RelayCommand<object> Commandwithholding { get; private set; }
        public RelayCommand<object> cmdNotifyParty { get; private set; }
        public RelayCommand<object> cmdNotifyParty2 { get; private set; }
        #endregion

        #region Dictionary for ComboList
        private Dictionary<string, object> _PrintOptionDictionary;
        public Dictionary<string, object> PrintOptionDictionary
        {
            get { return _PrintOptionDictionary; }
            set
            {
                if (_PrintOptionDictionary != value)
                {
                    _PrintOptionDictionary = value;
                    RaisePropertyChanged("PrintOptionDictionary");
                }
            }
        }

        #endregion

        #region Constructor 
        public SEL_T003_Essem_VM1(string doc_cat, string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;
            NotificationDataCollection = new List<NotificationData>();
            MC = new MultipleContext_SEL_T003();
            MasterEntity = new SEL_T003();

            PrintOptionDictionary = new Dictionary<string, object>();
            PrintOptionDictionary.Add("Original for Recipient", "Original for Recipient");
            PrintOptionDictionary.Add("Duplicate for Supplier/Transporter", "Duplicate for Supplier/Transporter");
            PrintOptionDictionary.Add("Triplicate for Supplier", "Triplicate for Supplier");

            ItemsEntity = new ObservableCollection<SEL_T003_A>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
            TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_C>();
            FlipGridData = new List<SEL_T003Flip>();
            FrmDate = System.DateTime.Now.AddMonths(-1);
            ToDate = System.DateTime.Now;
            SEL_T003.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            SEL_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            ACC_T006_C.ModelEntityUpdated += new EventHandler(ModelUpdated_Tax);
            TotalDocumentTaxesSummury.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            LoadInitialData();
        }
        public SEL_T003_Essem_VM1(string doc_cat, string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;
            this.doc_no_vm = doc_no;
            NotificationDataCollection = new List<NotificationData>();
            MC = new MultipleContext_SEL_T003();
            MasterEntity = new SEL_T003();

            PrintOptionDictionary = new Dictionary<string, object>();
            PrintOptionDictionary.Add("Original for Recipient", "Original for Recipient");
            PrintOptionDictionary.Add("Duplicate for Supplier/Transporter", "Duplicate for Supplier/Transporter");
            PrintOptionDictionary.Add("Triplicate for Supplier", "Triplicate for Supplier");

            ItemsEntity = new ObservableCollection<SEL_T003_A>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
            TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_C>();
            FlipGridData = new List<SEL_T003Flip>();
            FrmDate = System.DateTime.Now.AddMonths(-1);
            ToDate = System.DateTime.Now;
            SEL_T003.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            SEL_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            ACC_T006_C.ModelEntityUpdated += new EventHandler(ModelUpdated_Tax);
            TotalDocumentTaxesSummury.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            LoadInitialData();

        }

        #endregion

        #region UserDefinedfunction
        private void DefaultValues()
        {
            EntityChangeEnable = true;
            AutoRoundupEnable = true;
            MasterEntity.doc_cat = this.doc_cat_vm;
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_type = this.doc_cat_vm;
            MasterEntity.bill_type = this.doc_cat_vm;
            MasterEntity.bill_cat = this.doc_cat_vm;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.t_status = "001";
            MasterEntity.t_display = (from o in MC.STATUS_LIST where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();
            if (ref_doc_cat != "DN" && ref_doc_cat != "DC" && ref_doc_cat != "FD" && ref_doc_cat != "DE")
            {
                MasterEntity.doc_date = DateTime.Now;
                MasterEntity.post_date = DateTime.Now;
            }
            MasterEntity.entry_time = new TimeSpan();
            //MasterEntity.ind_trade = "D";
            MasterEntity.para7 = "SALE";
            MasterEntity.para4 = "LOCAL";
            MasterEntity.para3 = "SELF";
            MasterEntity.pay_ref = "CREDIT";
            MasterEntity.para9 = "External";
            MasterEntity.transhipment = "Allowed";
            MasterEntity.partshipment = "Allowed";
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            if (CompanyList.Count > 0)
            {
                MasterEntity.lc_curr = CompanyList[0].curr_code;
            }
            MasterEntity.net_value = 0;
            MasterEntity.other_charges = 0;
            MasterEntity.withholding_value = 0;
            MasterEntity.withholding_ex_amt = 0;
            MasterEntity.invoice_amtr = 0;
            Currency = AppSessionState.CntryCurncy;
            MasterEntity.Fltr_active = true;
            DateTime d = DateTime.Now;
            d = d.AddMonths(-1);
            MasterEntity.Fltr_FrmDate = d;
            MasterEntity.Fltr_ToDate = DateTime.Now;
            MasterEntity.Fltr_doc_type = MasterEntity.doc_type;
            if (MC.doc_typeList != null && !string.IsNullOrWhiteSpace(MasterEntity.doc_type))
            {
                AutoRoundupEnable = (bool)MC.doc_typeList.Find(x => x.doc_type == MasterEntity.doc_type).auto_roundup;
                RoundUpDecimals = (int)MC.doc_typeList.Find(x => x.doc_type == MasterEntity.doc_type).roundup_digits;
            }
        }
        private void LoadInitialData()
        {
            try
            {
                isNewRecord = true;
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + this.ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code;
                //string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + "PI,CI,SI" + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MC, Request, "SalesInvoice", "CRM", "LoadAll", 0, "");

                #region Command Initialisation
                SelectionChangedParaValCommand = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedParaValue(items); });
                CollectionChangedCommand = new RelayCommand<IList>(items => { if (items == null) { return; } InsertCollectionChanged(items); });
                CommandSoldToParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertSoldToParty(items, isNewRecord); });
                cmdTR_ModeMaster = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTR_ModeMaster(cmdPara); });
                CommandTransporter = new RelayCommand<object>(items => { if (items == null) { return; } InsertTransporter(items, true); });
                CommandServiceProvider = new RelayCommand<object>(items => { if (items == null) { return; } InsertServiceProvider(items, true); });
                CommandJournal = new RelayCommand<object>(items => { if (items == null) { return; } InsertJournal(items); });
                CommandPayTerms = new RelayCommand<object>(items => { if (items == null) { return; } InsertPayTerm(items); });
                CommandCurrency = new RelayCommand<object>(items => { if (items == null) { return; } InsertCurrency(items); });
                CmddgCurrency = new RelayCommand<object>(items => { if (items == null) { return; } InsertdgCurrency(items); });
                CommandSalseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseOrg(items); });
                CommandSalseDivision = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseDivision(items); });
                CommandCostCenter = new RelayCommand<object>(items => { if (items == null) { return; } InsertCostCenter(items); });
                CommandproductDescription = new RelayCommand<object>(items => { if (items == null) { return; } InsertproductDescription(items); });
                CommandBank = new RelayCommand<object>(items => { if (items == null) { return; } InsertBank(items); });
                CommandNastroBank = new RelayCommand<object>(items => { if (items == null) { return; } InsertNastroBank(items); });
                CommandILD = new RelayCommand<object>(items => { if (items == null) { return; } InsertILD(items); });
                CommandInk = new RelayCommand<object>(items => { if (items == null) { return; } InsertInk(items); });
                CommandItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara, true, true, true); });
                CommandUOM = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOM(cmdPara, false, true, true); });
                CommandItemCategory = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItemCategory(cmdPara, false, true, true); });
                CommandDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
                CommandLocations = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLocation(cmdPara); });
                CommandLicenseAdvance = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicenseAdvance(cmdPara); });
                CommandLicenseEPCG = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicenseEPCG(cmdPara); });
                CommandReferenceDoc = new RelayCommand<object>(items => { if (items == null) { return; } InsertReferenceDoc(items); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CommandFormType = new RelayCommand<object>(items => { if (items == null) { return; } InsertFormType(items); });
                CommandDeliveryAddress = new RelayCommand<object>(items => { if (items == null) { return; } InsertSoldToPartyAddress(items); });
                CommandDistributionChannel = new RelayCommand<object>(items => { if (items == null) { return; } InsertDistributionChannel(items); });
                CommandPayer = new RelayCommand<object>(items => { if (items == null) { return; } InsertPayer(items); });
                CommandDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocType(items); });
                CommandGodown = new RelayCommand<object>(items => { if (items == null) { return; } InsertGodown(items); });
                CommandCountry = new RelayCommand<object>(items => { if (items == null) { return; } InsertCountry(items); });
                CommandCustCatlogNo = new RelayCommand<object>(items => { if (items == null) { return; } InsertCustCatlogNo(items); });
                CommandPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
                Commandwtunit = new RelayCommand<object>(items => { if (items == null) { return; } InsertwtUOM(items, false, true, true); });
                CommandVolUnit = new RelayCommand<object>(items => { if (items == null) { return; } InsertvolUOM(items, false, true, true); });
                cmdDeleteTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteTax(cmdPara); });
                CommandAddSelectedTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSelectedTax(cmdPara); });
                CmdCondType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertConditiontype(cmdPara); });
                ManualTaxChangedCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertManualTaxChangedCommand(cmdPara); });
                cmdSeller = new RelayCommand<object>(items => { if (items == null) { return; } InsertSeller(items); });
                cmdSalseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseGroup(items); });
                cmdPrintLable = new GalaSoft.MvvmLight.Command.RelayCommand(() => { PrintLable(); });
                cmdPrintLableOne = new GalaSoft.MvvmLight.Command.RelayCommand(() => { PrintLable2(); });
                cmdPrintReport = new GalaSoft.MvvmLight.Command.RelayCommand(() => { PrintExportReport(); });
                cmdRefDoc = new RelayCommand<object>(items => { if (items == null) { return; } InsertRefDoc(items); });
                CommandMailDocuments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } MailDocuments(cmdPara); });
                cmdExportDocType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertExportDocType(cmdPara); });
                cmdForLoadBackFlip = new GalaSoft.MvvmLight.Command.RelayCommand(Load);
                cmdPrintChallan = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } PrintChallan(cmdPara); });
                CommandLocation = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLocations(cmdPara); });
                CommandExchangeRate = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LocalAmountCalculation(cmdPara); });
                cmdOpenAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenDocumentViewer(cmdPara); });
                cmdBussPlace = new RelayCommand<object>(items => { if (items == null) { return; } InsertBussPlace(items); });
                cmddgBussPlace = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgBussPlace(cmdPara, false, true, true); });
                CmddgShipToParty = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgShipToParty(cmdPara, false, true, true); });
                cmdReportData = new RelayCommand<object>(items => { if (items == null) { return; } InsertReportData(items); });
                CommandLoadHistory = new RelayCommand<object>(items => { if (items == null) { return; } LoadHistory(); });
                CommandFltrStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrStatus(items); });
                CommandFltrSoldToParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrSoldToParty(items); });
                CommandFltrDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrDocType(items); });
                CmdAddSelectedRef = new RelayCommand<object>(items => { if (items == null) { return; } AddSelectedRef(items); });
                Commandwithholding = new RelayCommand<object>(items => { if (items == null) { return; } InsertWithHolding(items); });
                cmdNotifyParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertNotifyParty(items, true); });
                cmdNotifyParty2 = new RelayCommand<object>(items => { if (items == null) { return; } InsertNotifyParty2(items, true); });
                post = true;

                #endregion
                #region Autosuggest
                MasterEntity.PrintOption = "";
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyNm);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AutoSuggestTextViewModel = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyNm", true);
                AutoSuggestTextViewModel.AutoSuggestVM.IsEmptyValueAllowed = true;
                AutoSuggestTextViewModel.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P_SI_ItemsList)x).ItemCode);
                TheFilter = (o, prefix) => (((SEL_T003_P_SI_ItemsList)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SEL_T003_P_SI_ItemsList)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASNotifyParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "notify_party", true);
                ASNotifyParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASNotifyParty2 = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "notify_party", true);
                ASNotifyParty2.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M037)x).ind_trade);
                TheFilter = (o, prefix) => (((SYS_M037)o).ind_trade ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M037)o).trade_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTradeIndicator = new AutoSuggestTextViewModel<dynamic>(MC.Trade_Types, TheFilter, SuggestedValue, "ind_trade", true);
                ASTradeIndicator.AutoSuggestVM.IsEmptyValueAllowed = false;
                ASTradeIndicator.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M003_P)x).sditem_cat_code);
                TheFilter = (o, prefix) => (((SYS_M003_P)o).sditem_cat_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M003_P)o).item_cat_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASItemLineCat = new AutoSuggestTextViewModel<dynamic>(MC.ItemCategoryList, TheFilter, SuggestedValue, "item_cat", "sditem_cat_code", true);
                ASItemLineCat.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASUOM = new AutoSuggestTextViewModel<dynamic>(MC.UnitList, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASUOM.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASUOM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASWTUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitList, TheFilter, SuggestedValue, "weight_unit", "unit_code", true);
                ASWTUnit.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASWTUnit.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASVolUOM = new AutoSuggestTextViewModel<dynamic>(MC.UnitList, TheFilter, SuggestedValue, "volume_unit", "unit_code", true);
                ASVolUOM.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASVolUOM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_P)o).gl_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDefault1 = new AutoSuggestTextViewModel<dynamic>(MC.AccountList, TheFilter, SuggestedValue, "gl_code", "gl_code", true);
                ASDefault1.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault1.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_P)x).gl_code);
                TheFilter = (o, prefix) => (((ACC_M003_P)o).gl_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_P)o).gl_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTaxacc = new AutoSuggestTextViewModel<dynamic>(MC.AccountList, TheFilter, SuggestedValue, "gl_code", "gl_code", true);
                ASTaxacc.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_O_P)x).con_type);
                TheFilter = (o, prefix) => (((ACC_M003_O_P)o).con_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_O_P)o).con_desc ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_O_P)o).con_cat ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_O_P)o).pricing_pro ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASConditionType = new AutoSuggestTextViewModel<dynamic>(MC.ConditionTypeList, TheFilter, SuggestedValue, "con_type", "con_type", false);
                ASConditionType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037_P)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M037_P)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASdgCurrency = new AutoSuggestTextViewModel<dynamic>(MC.CurrencysList, TheFilter, SuggestedValue, "curr_code", "curr_code", true);
                ASdgCurrency.AutoSuggestVM.IsEmptyValueAllowed = true;

                var refdoctempa1 = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "SO" || o.doc_cat == "DN" || o.doc_cat == "PI" || o.doc_cat == "CI" || o.doc_cat == "DC" select o).ToList();
                MasterEntity.ref_doc_type = "Delivery Note";
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P_RefDoc)x).Ref_DocNo);
                TheFilter = (o, prefix) => ((SEL_T003_P_RefDoc)o).Ref_DocNo.ToString().ToLower().Contains(prefix.ToLower());
                ASRef_doc_no = new AutoSuggestTextViewModel<dynamic>(refdoctempa1, TheFilter, SuggestedValue, "ref_doc_no", true);
                ASRef_doc_no.AutoSuggestVM.IsEmptyValueAllowed = true;

                var DocumentCat1 = (from o in MC.Export_Doc_Type where o.doc_cat == "SI" || o.doc_cat == "EI" || o.doc_cat == "CM" || o.doc_cat == "FS" select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M001_P)x).doc_cat);
                TheFilter = (o, prefix) => ((SYS_M001_P)o).doc_cat.ToString().ToLower().Contains(prefix.ToLower());
                ASDocCat = new AutoSuggestTextViewModel<dynamic>(DocumentCat1, TheFilter, SuggestedValue, "doc_cat", true);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPayer = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyId", true);
                ASPayer.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSalesPerson = new AutoSuggestTextViewModel<dynamic>(MC.SalesPerson, TheFilter, SuggestedValue, "para1", true);
                ASSalesPerson.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASSalesPerson.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037_P)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037_P)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M037_P)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCurrency = new AutoSuggestTextViewModel<dynamic>(MC.CurrencysList, TheFilter, SuggestedValue, "curr_code", true);
                ASCurrency.AutoSuggestVM.IsEmptyValueAllowed = true;

                ObjSupply = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPlant = new AutoSuggestTextViewModel<dynamic>(ObjSupply, TheFilter, SuggestedValue, "location_Id", true);
                ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCFAgent = new AutoSuggestTextViewModel<dynamic>(MC.ServiceProviders, TheFilter, SuggestedValue, "cf_agent_cd", true);
                ASCFAgent.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M041_P)x).lic_cod);
                TheFilter = (o, prefix) => (((ADM_M041_P)o).lic_cod ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASEPCG = new AutoSuggestTextViewModel<dynamic>(MC.LicenseEPCG, TheFilter, SuggestedValue, "lic_cod", true);
                ASEPCG.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M041_P)x).lic_cod);
                TheFilter = (o, prefix) => (((ADM_M041_P)o).lic_cod ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASAdvance = new AutoSuggestTextViewModel<dynamic>(MC.LicenseAdvance, TheFilter, SuggestedValue, "advance_lic", true);
                ASAdvance.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M020_P)x).ProdNm);
                TheFilter = (o, prefix) => (((ADM_M020_P)o).ProdNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M020_P)o).ProdNmCd ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASProductDes = new AutoSuggestTextViewModel<dynamic>(MC.Product_Description, TheFilter, SuggestedValue, "ProdNm", true);
                ASProductDes.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASProductDes.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M013_P)x).description);
                TheFilter = (o, prefix) => (((ACC_M013_P)o).description ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASFormType = new AutoSuggestTextViewModel<dynamic>(MC.FormType, TheFilter, SuggestedValue, "FormDescription", true);
                ASFormType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M002_P)x).wa_code);
                TheFilter = (o, prefix) => (((MM_M002_P)o).wa_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((MM_M002_P)o).wa_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASGodown = new AutoSuggestTextViewModel<dynamic>(MC.GodownList, TheFilter, SuggestedValue, "para5", true);
                ASGodown.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTransporter = new AutoSuggestTextViewModel<dynamic>(MC.Transporters, TheFilter, SuggestedValue, "transporter", true);
                ASTransporter.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M007_P)x).p_term_code);
                TheFilter = (o, prefix) => (((ACC_M007_P)o).p_term_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M007_P)o).p_term ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPayTerms = new AutoSuggestTextViewModel<dynamic>(MC.PayTerms, TheFilter, SuggestedValue, "p_term_code", true);
                ASPayTerms.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M004_P)x).bank_code);
                TheFilter = (o, prefix) => (((ACC_M004_P)o).bank_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M004_P)o).bank_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASOurBank = new AutoSuggestTextViewModel<dynamic>(MC.BanksList, TheFilter, SuggestedValue, "bank_code", true);
                ASOurBank.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M004_P)x).bank_code);
                TheFilter = (o, prefix) => (((ACC_M004_P)o).bank_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M004_P)o).bank_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASNastroBank = new AutoSuggestTextViewModel<dynamic>(MC.BanksList, TheFilter, SuggestedValue, "nastro_bank_cd", true);
                ASNastroBank.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M019_P)x).cost_center);
                TheFilter = (o, prefix) => (((ACC_M019_P)o).cost_center ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCostCentre = new AutoSuggestTextViewModel<dynamic>(MC.Cost_Centers, TheFilter, SuggestedValue, "cost_center", true);
                ASCostCentre.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M005_P)x).j_code);
                TheFilter = (o, prefix) => (((ACC_M005_P)o).j_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M005_P)o).j_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASJournal = new AutoSuggestTextViewModel<dynamic>(MC.Journals, TheFilter, SuggestedValue, "j_code", true);
                ASJournal.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M012_P)x).country_code);
                TheFilter = (o, prefix) => (((ADM_M012_P)o).country_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M012_P)o).CntryName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCountry = new AutoSuggestTextViewModel<dynamic>(MC.CountryList, TheFilter, SuggestedValue, "dest_country_cd", true);
                ASCountry.AutoSuggestVM.IsEmptyValueAllowed = true;

                SalesOrganisationList = (List<ADM_M001_A_P>)AppSessionState.ADM_M001_A_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_A_P)x).so_code);
                TheFilter = (o, prefix) => (((ADM_M001_A_P)o).so_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M001_A_P)o).sales_org ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSalesOrg = new AutoSuggestTextViewModel<dynamic>(SalesOrganisationList, TheFilter, SuggestedValue, "so_code", true);

                SalesGroupList = (List<ADM_M001_H_P>)AppSessionState.ADM_M001_H_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_H_P)x).sg_code);
                TheFilter = (o, prefix) => (((ADM_M001_H_P)o).sg_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M001_H_P)o).sg_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSalesGroup = new AutoSuggestTextViewModel<dynamic>(SalesGroupList, TheFilter, SuggestedValue, "sg_code", true);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_D_P)x).div_code);
                TheFilter = (o, prefix) => (((ADM_M001_D_P)o).div_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M001_D_P)o).div_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSaleDivision = new AutoSuggestTextViewModel<dynamic>(MC.SalesDiv, TheFilter, SuggestedValue, "div_code", true);
                ASSaleDivision.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_C_P)x).dc_code);
                TheFilter = (o, prefix) => (((ADM_M001_C_P)o).dc_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M001_C_P)o).dc_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDisbtnChannel = new AutoSuggestTextViewModel<dynamic>(MC.DistributionChannel, TheFilter, SuggestedValue, "dc_code", true);
                ASDisbtnChannel.AutoSuggestVM.IsEmptyValueAllowed = true;

                var location1 = (from o in ObjSupply where o.comp_code == AppSessionState.comp_code select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPlant1 = new AutoSuggestTextViewModel<dynamic>(location1, TheFilter, SuggestedValue, "location_Id", true);
                ASPlant1.AutoSuggestVM.IsEmptyValueAllowed = true;

                var DocumentCat2 = (from o in MC.Export_Doc_Type where o.doc_cat == "SI" || o.doc_cat == "EI" || o.doc_cat == "CM" || o.doc_cat == "FS" select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M001_P)x).doc_cat);
                TheFilter = (o, prefix) => ((SYS_M001_P)o).doc_cat.ToString().ToLower().Contains(prefix.ToLower());
                ASDocCat1 = new AutoSuggestTextViewModel<dynamic>(DocumentCat2, TheFilter, SuggestedValue, "doc_cat", true);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M006_P)x).ink);
                TheFilter = (o, prefix) => (((ZADM_M006_P)o).ink ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASInk = new AutoSuggestTextViewModel<dynamic>(MC.Inks, TheFilter, SuggestedValue, "para2", "ink", true);
                ASInk.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M007_P)x).ild);
                TheFilter = (o, prefix) => (((ZADM_M007_P)o).ild ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASILD = new AutoSuggestTextViewModel<dynamic>(MC.ILDs, TheFilter, SuggestedValue, "para5", "ild", true);
                ASILD.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => ((ADM_M028_P)o).PartyNm.ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M028_P)o).PartyId.ToString().ToLower().Contains(prefix.ToLower());
                ASSoldToParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyId", true);
                ASSoldToParty.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASSoldToParty.AutoSuggestVM.IsFreeTextAllowed = true;

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

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((Report_Data_P)x).data1);
                TheFilter = (o, prefix) => (((Report_Data_P)o).data1 ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((Report_Data_P)o).id.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASReportData = new AutoSuggestTextViewModel<dynamic>(MC.Report_DataList2, TheFilter, SuggestedValue, "data1", true);
                ASReportData.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M020_P)x).ProdNm);
                TheFilter = (o, prefix) => (((ADM_M020_P)o).ProdNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASProdNm = new AutoSuggestTextViewModel<dynamic>(MC.Product_Description, TheFilter, SuggestedValue, "ProdNm", "ProdNm", true);
                ASProdNm.AutoSuggestVM.IsEmptyValueAllowed = true;

                //Filters AutoSuggest
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASFltrt_status = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_display", true);
                ASFltrt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyNm);
                TheFilter = (o, prefix) => ((ADM_M028_P)o).PartyNm.ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M028_P)o).PartyId.ToString().ToLower().Contains(prefix.ToLower());
                ASFltrSoldToParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyNm", true);
                ASFltrSoldToParty.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASFltrSoldToParty.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M002)x).doc_type);
                TheFilter = (o, prefix) => ((SYS_M002)o).doc_type_user.ToString().ToLower().Contains(prefix.ToLower());
                ASDocType = new AutoSuggestTextViewModel<dynamic>(MC.doc_typeList, TheFilter, SuggestedValue, "doc_type", true);
                ASDocType.AutoSuggestVM.IsEmptyValueAllowed = false;
                ASDocType.AutoSuggestVM.Suggestion = MC.doc_typeList.Find(x => x.doc_type == MasterEntity.doc_type);

                //var refdoctemp = (from o in MC.doc_typeList where o.doc_type == "CM" || o.doc_type == "SI" select o).ToList();

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M002)x).doc_type);
                //TheFilter = (o, prefix) => ((SYS_M002)o).doc_type.ToString().ToLower().Contains(prefix.ToLower());
                //ASDocType = new AutoSuggestTextViewModel<dynamic>(refdoctemp, TheFilter, SuggestedValue, "doc_type", true);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M025_P)x).wtax_code);
                TheFilter = (o, prefix) => (((ACC_M025_P)o).wtax_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M025_P)o).wtax_ncode ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASwithholding = new AutoSuggestTextViewModel<dynamic>(MC.withholdinglist, TheFilter, SuggestedValue, "withholding_tax", true);
                ASwithholding.AutoSuggestVM.IsEmptyValueAllowed = true;

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
                #endregion

                UnitConversionList = MC.UnitConversion;

                var refdoc = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "SO" select o).ToList();

                ReferenceDocSOCollection = CollectionViewSource.GetDefaultView(refdoc);
                ReferenceDocSOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                refdoc = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "DN" select o).ToList();

                ReferenceDocDNCollection = CollectionViewSource.GetDefaultView(refdoc);
                ReferenceDocDNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);


                TaxDictonery = new Dictionary<string, object>();
                TaxDictonery.Clear();
                TaxDictonery = MC.TaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);

                var TaxListParent = (from o in MC.TaxList
                                     where o.parent_id == null
                                     select o).ToList();
                SelectedTaxList = TaxListParent;
                TaxDictoneryParent = SelectedTaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);

                NotificationDataCollection = MC.NotificationData;

                var DocumentCat = (from o in MC.Export_Doc_Type where o.doc_cat == "SI" || o.doc_cat == "EI" || o.doc_cat == "CM" || o.doc_cat == "FS" select o).ToList();
                //Export_doctype_Collection = CollectionViewSource.GetDefaultView(DocumentCat);
                //Export_doctype_Collection.Filter = new Predicate<object>(Exportdoctype_Filter);
                //StrListExportDocType = DocumentCat.Select(x => x.doc_cat).ToList();

                var refdoctemp = (from o in MC.doc_typeList where o.doc_cat == "SI" select o).ToList();
                doc_typeCollection = CollectionViewSource.GetDefaultView(refdoctemp.ToList());

                CompanyList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                MasterEntity.PrintOption = "";

                DefaultValues();
            }
            catch (Exception ex) { }
        }
        private void LoadHistory()
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + (MasterEntity.Fltr_doc_type ?? this.doc_cat_vm) + "!@!@!@" + AppSessionState.EmpId + "!@!@!@!@" + (MasterEntity.Fltr_PartyId ?? "") + "!@!@" + MasterEntity.Fltr_active + "!@" + MasterEntity.Fltr_t_status + "!@" + Convert.ToDateTime(MasterEntity.Fltr_FrmDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.Fltr_ToDate).ToString("MM/dd/yyyy");
                //string Request = "LoadBackFlipData" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.EmpId + "!@" + Convert.ToDateTime(MasterEntity.Fltr_FrmDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.Fltr_ToDate).ToString("MM/dd/yyyy") + "!@" + MasterEntity.Fltr_t_status + "!@" + MasterEntity.Fltr_active + "!@" + MasterEntity.Fltr_doc_type + "!@" + MasterEntity.Fltr_PartyId + "!@" + AppSessionState.client;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MCTemp, Request, "SalesInvoice", "CRM", "LoadHistory", 0, "");

                MC.DocumentDataFlipGrid = MCTemp.DocumentDataFlipGrid;
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(MC.DocumentDataFlipGrid);
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
        private void OpenDocumentViewer(object InputValue)
        {
            WebServiceRepository<MultipleContext_Attachments> repository_MCAttachments = new WebServiceRepository<MultipleContext_Attachments>();
            List<COM_T003> Attachments = new List<COM_T003>();
            SEL_T003_A EntityObjectParameter = new SEL_T003_A();
            MultipleContext_Attachments MCAttachments = new MultipleContext_Attachments();
            try
            {
                if (InputValue != null)
                {
                    EntityObjectParameter = ((IEnumerable)InputValue).Cast<SEL_T003_A>().ToList()[0];
                }
                string Request = "GetAllFiles" + "!@" + AppSessionState.client + "!@" + (EntityObjectParameter.comp_code ?? AppSessionState.comp_code) + "!@" + (EntityObjectParameter.location_Id ?? AppSessionState.location_Id) + "!@" + (EntityObjectParameter.doc_cat ?? "") + "!@" + (EntityObjectParameter.doc_cat ?? "") + "!@" + EntityObjectParameter.bill_doc + "!@" + EntityObjectParameter.id.ToString();
                //string Request = "GetAllFiles" + "!@" + EntityObjectParameter.ItemCode + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type; 
                //MCAttachments = repository_MCAttachments.GetData<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Reflection.BusinessLogic.ReflectionFileHandlingServices");
                MCAttachments = repository_MCAttachments.GetDataWithReturnDomainObject<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                if (!string.IsNullOrEmpty(EntityObjectParameter.ItemCode))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.bill_doc.Replace("/", "--"), Row_ID = EntityObjectParameter.id.ToString(), DocumentList = MCAttachments.Attachments, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
                }

            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void InsertReportData(object InputValue)
        {
            try
            {
                string Request = "";
                Report_Data_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Report_DataList2.Where(x => x.data1.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<Report_Data_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.data1 = POPUPEntityObject.data1;
                }
            }
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
                    //isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
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
                        ItemsEntity.Add(new SEL_T003_A()
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
                        ItemsEntity.Add(new SEL_T003_A()
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
        private void InsertproductDescription(object InputValue)
        {
            string Request = "";
            ADM_M020_P POPUPEntityObject = null;
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
                            POPUPEntityObject = MC.Product_Description.Where(x => x.ProdNmCd.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.ProdNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M020_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M020_P>().ToList()[0];
                    }

                }
            }
            catch (Exception ex)
            { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.ProdNmCd = POPUPEntityObject.ProdNmCd;
                MasterEntity.ProdNm = POPUPEntityObject.ProdNm;

            }
        }
        private void PrintExportReport()
        {
            try
            {
                CursorControl.SetBusyState();
                string ReportName = "";

                if (ReportOption == "DC/GatePass" || ReportOption == "ItemWise Rate")
                {
                    string Request = "";
                    if (ReportOption == "DC/GatePass")
                    {
                        ReportName = "DeliveryNote5.rdlc";
                    }
                    else if (ReportOption == "ItemWise Rate")
                    {
                        ReportName = "DeliveryNote6.rdlc";
                    }
                    if (MasterEntity.comp_code == "1")
                    {
                        //Request = "DN_Report1" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@" + MasterEntity.ref_doc_no;
                        Request = "DN_Report1" + "!@" + MasterEntity.ref_doc_no + "!@" + " " + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + MasterEntity.location_Id;
                        MCTemp2 = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp2, "LOG_T001_A_Data", "DeliveryNote", "SCM", "LoadAll", 0, Request);
                    }
                    else
                    {
                        Request = "DN_Report1" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@" + MasterEntity.ref_doc_no;
                       // Request = "DN_Report1" + "!@" + MasterEntity.ref_doc_no + "!@" + " " + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + MasterEntity.location_Id;
                        MCTemp2 = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp2, "LOG_T001_A_Data", "DeliveryNoteSTD", "SCM", "LoadAll", 0, Request);
                    }
                    object[] objDataSource = new object[4];
                    string[] objDataSourceName = new string[4];


                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[0] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[1] = Result;

                    objDataSource[2] = MCTemp2.RptDeliveryNoteList;
                    objDataSource[3] = MCTemp2.RptSalesInvoiceTax;

                    objDataSourceName[0] = "dsCompany";
                    objDataSourceName[1] = "dsLocation";
                    objDataSourceName[2] = "dsRptDeliveryNote";
                    objDataSourceName[3] = "dsRptSalesInvoiceTax";

                    ReportManager ReportManager = new ReportManager();

                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, getParametersList(""), ReportName);

                }

                else if (ReportOption == "DC/GatePass2")
                {
                    ReportName = "DeliveryNote4.rdlc";
                    string Request = "";
                    if (MasterEntity.comp_code == "1")
                    {
                        //Request = "DN_Report2" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@" + MasterEntity.ref_doc_no;
                        Request = "DN_Report2" + "!@" + MasterEntity.ref_doc_no + "!@" + "" + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + MasterEntity.location_Id;
                        MCTemp2 = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp2, "LOG_T001_A_Data", "DeliveryNote", "SCM", "LoadAll", 0, Request);
                    }
                    else
                    {
                        Request = "DN_Report2" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@" + MasterEntity.ref_doc_no;
                        //Request = "DN_Report2" + "!@" + MasterEntity.ref_doc_no + "!@" + "" + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + MasterEntity.location_Id;
                        MCTemp2 = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp2, "LOG_T001_A_Data", "DeliveryNoteSTD", "SCM", "LoadAll", 0, Request);
                    }
                    object[] objDataSource = new object[4];
                    string[] objDataSourceName = new string[4];


                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[0] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[1] = Result;

                    objDataSource[2] = MCTemp2.RptDeliveryNoteList;
                    objDataSource[3] = MCTemp2.RptSalesInvoiceTax;

                    objDataSourceName[0] = "dsCompany";
                    objDataSourceName[1] = "dsLocation";
                    objDataSourceName[2] = "dsRptDeliveryNote";
                    objDataSourceName[3] = "dsRptSalesInvoiceTax";

                    ReportManager ReportManager = new ReportManager();

                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, getParametersList(""), ReportName);

                }

                else if (ReportOption == "Item Packing Detail")
                {
                    ReportName = "ItemPackingDetail.rdlc";
                    string Request = "";

                    Request = "Item_packingDetail" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@" + MasterEntity.bill_doc;
                    //Request = "Item_packingDetail" + "!@" + MasterEntity.bill_doc + "!@" + "!@" + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + MasterEntity.location_Id;

                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MC, Request, "SalesInvoice", "CRM", "LoadAll", 0, "");

                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];

                    objDataSource[0] = MCTemp.RptItemPackingDetailList;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[2] = Result;

                    objDataSourceName[0] = "dsRptItemPackingDetail";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsLocation";

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, getParametersList(""), ReportName);

                }

                else if (ReportOption == "Batch Detail")
                {
                    ReportName = "PackingAndWeightListDetail.rdlc";
                    string Request = "";

                    Request = "BatchDetail" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@" + MasterEntity.bill_doc;
                    //Request = "BatchDetail" + "!@" + MasterEntity.bill_doc + "!@" + " " + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + MasterEntity.location_Id;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MC, Request, "SalesInvoice", "CRM", "LoadAll", 0, "");

                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];

                    objDataSource[0] = MCTemp.RptBatchDetailList;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[2] = Result;

                    objDataSourceName[0] = "dsRptBatchDetail";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsLocation";

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, getParametersList(""), ReportName);

                }

                else if (ReportOption == "Batch Summary")
                {
                    ReportName = "BatchDetailSummary.rdlc";
                    string Request = "";

                    Request = "BatchSummary" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@" + MasterEntity.bill_doc;
                    //Request = "BatchSummary" + "!@" + MasterEntity.bill_doc + "!@" + " " + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + MasterEntity.location_Id; 

                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MC, Request, "SalesInvoice", "CRM", "LoadAll", 0, "");

                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];

                    objDataSource[0] = MCTemp.RptBatchDetailList;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[2] = Result;

                    objDataSourceName[0] = "dsRptBatchDetail";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsLocation";

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, getParametersList(""), ReportName);

                }

                else if (ReportOption == "Weight Packing Detail")
                {
                    ReportName = "WeightPackingDetail.rdlc";
                    string Request = "";

                    Request = "WeightPackingDetail" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@" + MasterEntity.bill_doc;
                    //Request = "WeightPackingDetail" + "!@" + MasterEntity.bill_doc + "!@" + " " + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + MasterEntity.location_Id; 

                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MC, Request, "SalesInvoice", "CRM", "LoadAll", 0, "");

                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];

                    objDataSource[0] = MCTemp.RptBatchDetailList;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[2] = Result;

                    objDataSourceName[0] = "dsRptBatchDetail";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsLocation";

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, getParametersList(""), ReportName);

                }

                else if (ReportOption == "Packing List")
                {
                    try
                    {
                        ReportName = "PackingList2.rdlc";
                        if (MasterEntity.comp_code == "1")
                        {
                            //string Request = "DN_PackingList" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@" + MasterEntity.ref_doc_no;
                            string Request = "DN_PackingList" + "!@" + "PI" + "!@" + MasterEntity.ref_doc_no + "!@" + " " + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + MasterEntity.location_Id; 
                            MCTemp2 = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp2, "LOG_T001_A_Data", "DeliveryNote", "SCM", "LoadAll", 0, Request);
                        }
                        else
                        {
                            string Request = "DN_PackingList" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@" + MasterEntity.ref_doc_no;
                            //string Request = "DN_PackingList" + "!@" + "PI" + "!@" + MasterEntity.ref_doc_no + "!@" + " " + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + MasterEntity.location_Id; 
                            MCTemp2 = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp2, "LOG_T001_A_Data", "DeliveryNoteSTD", "SCM", "LoadAll", 0, Request);
                        }
                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                        var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                        objDataSource[0] = CmpResult;

                        List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                        var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                        objDataSource[1] = Result;

                        objDataSource[2] = MCTemp2.RptPackingListList;

                        objDataSourceName[0] = "dsCompany";
                        objDataSourceName[1] = "dsLocation";
                        objDataSourceName[2] = "RptPackingList";

                        ReportManager ReportManager = new ReportManager();

                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, "PackingList");
                    }
                    catch (Exception ex)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format(ex.Message, this.Title);
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
        private void PrintLable()
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "SI_Report" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@" + MasterEntity.bill_doc;
                //string Request = "SI_Report" + "!@" + MasterEntity.bill_doc + "!@" + " " + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + MasterEntity.location_Id; 
                string ReportName = "";

                MasterEntity.doc_desc = "SalesInvoice";
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MC, Request, "SalesInvoice", "CRM", "LoadAll", 0, "");

                object[] objDataSource = new object[5];
                string[] objDataSourceName = new string[5];
                //MC.Delivery_Note.Clear();
                //MC.Delivery_Note.Add(SelectedLOG_T001_A);          

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[0] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[1] = Result;

                objDataSource[2] = MCTemp.RptSalesInvoice;
                objDataSource[3] = MCTemp.RptSalesInvoiceItem;
                objDataSource[4] = MCTemp.TaxEntity;

                objDataSourceName[0] = "dsCompany";
                objDataSourceName[1] = "dsLocation";
                objDataSourceName[2] = "dsRptSalesInvoice";
                objDataSourceName[3] = "dsRptSalesInvoiceItem";
                objDataSourceName[4] = "dsRptSalesInvoiceTax";

                ReportManager ReportManager = new ReportManager();

                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\SalesInvoiceLabel.rdlc", ReportName);
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }

        }
        private void PrintLable2()
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "SI_Report" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + doc_cat_vm + "!@" + MasterEntity.bill_doc;
                //string Request = "SI_Report" + "!@" + MasterEntity.bill_doc;
                string ReportName = "";

                MasterEntity.doc_desc = "SalesInvoice";
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MC, Request, "SalesInvoice", "CRM", "LoadAll", 0, "");

                object[] objDataSource = new object[5];
                string[] objDataSourceName = new string[5];
                //MC.Delivery_Note.Clear();
                //MC.Delivery_Note.Add(SelectedLOG_T001_A);          

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[0] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[1] = Result;

                objDataSource[2] = MCTemp.RptSalesInvoice;
                objDataSource[3] = MCTemp.RptSalesInvoiceItem;
                objDataSource[4] = MCTemp.TaxEntity;

                objDataSourceName[0] = "dsCompany";
                objDataSourceName[1] = "dsLocation";
                objDataSourceName[2] = "dsRptSalesInvoice";
                objDataSourceName[3] = "dsRptSalesInvoiceItem";
                objDataSourceName[4] = "dsRptSalesInvoiceTax";

                ReportManager ReportManager = new ReportManager();

                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\SalesInvoiceLabel2.rdlc", ReportName);
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }

        }
        private void Load()
        {
            try
            {
                if (FrmDate != null && ToDate != null)
                {
                    string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + (MasterEntity.Fltr_doc_type ?? this.doc_cat_vm) + "!@!@!@" + AppSessionState.EmpId + "!@!@!@!@" + (MasterEntity.Fltr_PartyId ?? "") + "!@!@" + MasterEntity.Fltr_active + "!@" + MasterEntity.Fltr_t_status + "!@" + Convert.ToDateTime(FrmDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ToDate).ToString("MM/dd/yyyy");
                    //string Request = "LoadBackFlipData" + "!@" + AppSessionState.comp_code + "!@" + Convert.ToDateTime(FrmDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ToDate).ToString("MM/dd/yyyy") + "!@" + AppSessionState.EmpId + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat;

                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MCTemp, Request, "SalesInvoice", "CRM", "LoadAll", 0, "");
                    var Flipdata = (from o in MCTemp.DocumentDataFlipGrid where (o.doc_cat == "SI" || o.doc_cat == "CM" || o.doc_cat == "EI" || o.doc_cat == "FS") && o.doc_type != "BRP" && o.doc_type != "NSP" && o.doc_type != "SGP" && o.doc_type != "SSP" && o.doc_type != "TGP" select o).ToList();

                    FlipGridData = Flipdata.ToList();

                    FlipDataGridCollection = CollectionViewSource.GetDefaultView(Flipdata.ToList());
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
            string Request = "";
            SYS_M002 POPUPEntityObject = null;
            IEnumerable<SYS_M002> BEType = new List<SYS_M002>();

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
                    if (((IEnumerable)InputValue).Cast<SYS_M002>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M002>().ToList()[0];
                        AutoRoundupEnable = (bool)POPUPEntityObject.auto_roundup;
                        RoundUpDecimals = (int)POPUPEntityObject.roundup_digits;
                        if (ItemsEntity != null)
                        {
                            if (ItemsEntity.Count() > 0)
                            {
                                int count = ItemsEntity.Count();
                                TotalDocumentTaxes.Clear();
                                for (int i = 0; i < count; i++)
                                {
                                    Computation(true, i, AutoRoundupEnable);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
            if (POPUPEntityObject != null)
            {
                MasterEntity.doc_type = POPUPEntityObject.doc_type;
                MasterEntity.doc_desc = POPUPEntityObject.doc_desc;
                MasterEntity.doc_cat = POPUPEntityObject.doc_cat;
                MasterEntity.bill_cat = POPUPEntityObject.doc_cat;
                MasterEntity.bill_type = POPUPEntityObject.doc_type;
                this.doc_cat_vm = POPUPEntityObject.doc_cat;
                if (POPUPEntityObject.doc_type == "EI")
                {
                    MasterEntity.ind_trade = "E";
                }
                AutoRoundupEnable = (bool)POPUPEntityObject.auto_roundup;
                RoundUpDecimals = (int)POPUPEntityObject.roundup_digits;
            }

        }
        private void InsertExportDocType(object InputValue)
        {
            string Request = "";
            SYS_M001_P POPUPEntityObject = null;
            IEnumerable<SYS_M001_P> BEType = new List<SYS_M001_P>();

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
                        { POPUPEntityObject = MC.Export_Doc_Type.Where(x => x.doc_cat.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SYS_M001_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M001_P>().ToList()[0];
                    }
                }
            }
            catch (Exception ex) { }
            if (POPUPEntityObject != null)
            {

                MasterEntity.doc_cat = POPUPEntityObject.doc_cat;
                MasterEntity.doc_type = "";
                MasterEntity.doc_desc = "";

                var refdoctemp = (from o in MC.doc_typeList where o.doc_cat == POPUPEntityObject.doc_cat && o.doc_type != "BRP" && o.doc_type != "NSP" && o.doc_type != "SGP" && o.doc_type != "SSP" && o.doc_type != "TGP" select o).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M002)x).doc_type_user);
                TheFilter = (o, prefix) => ((SYS_M002)o).doc_type_user.ToString().ToLower().Contains(prefix.ToLower());
                ASDocType = new AutoSuggestTextViewModel<dynamic>(refdoctemp, TheFilter, SuggestedValue, "doc_type", true);

                if (refdoctemp.Count == 1 && refdoctemp.Count > 0)
                {
                    MasterEntity.doc_type = refdoctemp[0].doc_type;
                    MasterEntity.bill_type = refdoctemp[0].doc_type;
                    MasterEntity.doc_desc = refdoctemp[0].doc_desc;
                    AutoRoundupEnable = (bool)refdoctemp[0].auto_roundup;
                    RoundUpDecimals = (int)refdoctemp[0].roundup_digits;
                }
            }
            var msg = new NotificationMessage(ts_code_vm);
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        private void LocalAmountCalculation(object InputValue)
        {
            try
            {
                if (MasterEntity.exc_rate == 1)
                {
                    MasterEntity.invoice_amtr = MasterEntity.roundup_total;
                }
                else
                {
                    MasterEntity.invoice_amtr = MasterEntity.invoice_amt * MasterEntity.exc_rate;
                }

            }
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
        private void InsertCountry(object InputValue)
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
                    if (((IEnumerable)InputValue).Cast<ADM_M012_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M012_P>().ToList()[0];
                    }

                }
            }
            catch (Exception ex)
            { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.dest_country_cd = POPUPEntityObject.country_code;
                MasterEntity.CountryName = POPUPEntityObject.CntryName;

            }

        }
        private void InsertDistributionChannel(object InputValue)
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
                        { POPUPEntityObject = MC.DistributionChannel.Where(x => x.dc_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M001_C_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_C_P>().ToList()[0];
                    }

                }
            }
            catch (Exception ex)
            { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.dc_code = POPUPEntityObject.dc_code;
                MasterEntity.dc_name = POPUPEntityObject.dc_name;//scalar

            }
        }
        private void InsertRefDoc(object InputValue)
        {
            try
            {
                if (MasterEntity.ref_doc_type == "Sales Order")
                {
                    refdoctempa = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "SO" select o).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P_RefDoc)x).Ref_DocNo);
                    TheFilter = (o, prefix) => ((SEL_T003_P_RefDoc)o).Ref_DocNo.ToString().ToLower().Contains(prefix.ToLower());
                    ASRef_doc_no = new AutoSuggestTextViewModel<dynamic>(refdoctempa, TheFilter, SuggestedValue, "ref_doc_no", false);
                    ASRef_doc_no.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASRef_doc_no.AutoSuggestVM.IsFreeTextAllowed = true;
                }
                else if (MasterEntity.ref_doc_type == "Delivery Note")
                {
                    refdoctempa = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "DN" select o).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P_RefDoc)x).Ref_DocNo);
                    TheFilter = (o, prefix) => ((SEL_T003_P_RefDoc)o).Ref_DocNo.ToString().ToLower().Contains(prefix.ToLower());
                    ASRef_doc_no = new AutoSuggestTextViewModel<dynamic>(refdoctempa, TheFilter, SuggestedValue, "ref_doc_no", false);
                    ASRef_doc_no.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASRef_doc_no.AutoSuggestVM.IsFreeTextAllowed = true;
                }
                else if (MasterEntity.ref_doc_type == "Proforma Invoice")
                {
                    refdoctempa = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "PI" select o).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P_RefDoc)x).Ref_DocNo);
                    TheFilter = (o, prefix) => ((SEL_T003_P_RefDoc)o).Ref_DocNo.ToString().ToLower().Contains(prefix.ToLower());
                    ASRef_doc_no = new AutoSuggestTextViewModel<dynamic>(refdoctempa, TheFilter, SuggestedValue, "ref_doc_no", false);
                    ASRef_doc_no.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASRef_doc_no.AutoSuggestVM.IsFreeTextAllowed = true;
                }
                else if (MasterEntity.ref_doc_type == "Custom Invoice")
                {
                    refdoctempa = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "CI" select o).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P_RefDoc)x).Ref_DocNo);
                    TheFilter = (o, prefix) => ((SEL_T003_P_RefDoc)o).Ref_DocNo.ToString().ToLower().Contains(prefix.ToLower());
                    ASRef_doc_no = new AutoSuggestTextViewModel<dynamic>(refdoctempa, TheFilter, SuggestedValue, "ref_doc_no", false);
                    ASRef_doc_no.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASRef_doc_no.AutoSuggestVM.IsFreeTextAllowed = true;
                }
                else if (MasterEntity.ref_doc_type == "Delivery Note Consignee")
                {
                    refdoctempa = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "DC" select o).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P_RefDoc)x).Ref_DocNo);
                    TheFilter = (o, prefix) => ((SEL_T003_P_RefDoc)o).Ref_DocNo.ToString().ToLower().Contains(prefix.ToLower());
                    ASRef_doc_no = new AutoSuggestTextViewModel<dynamic>(refdoctempa, TheFilter, SuggestedValue, "ref_doc_no", false);
                    ASRef_doc_no.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASRef_doc_no.AutoSuggestVM.IsFreeTextAllowed = true;
                }
                else if (MasterEntity.ref_doc_type == "Delivery Note Export")
                {
                    refdoctempa = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "DE" select o).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P_RefDoc)x).Ref_DocNo);
                    TheFilter = (o, prefix) => ((SEL_T003_P_RefDoc)o).Ref_DocNo.ToString().ToLower().Contains(prefix.ToLower());
                    ASRef_doc_no = new AutoSuggestTextViewModel<dynamic>(refdoctempa, TheFilter, SuggestedValue, "ref_doc_no", false);
                    ASRef_doc_no.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASRef_doc_no.AutoSuggestVM.IsFreeTextAllowed = true;
                }
                else if (MasterEntity.ref_doc_type == "Free Delivery")
                {
                    refdoctempa = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "FD" select o).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P_RefDoc)x).Ref_DocNo);
                    TheFilter = (o, prefix) => ((SEL_T003_P_RefDoc)o).Ref_DocNo.ToString().ToLower().Contains(prefix.ToLower());
                    ASRef_doc_no = new AutoSuggestTextViewModel<dynamic>(refdoctempa, TheFilter, SuggestedValue, "ref_doc_no", false);
                    ASRef_doc_no.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASRef_doc_no.AutoSuggestVM.IsFreeTextAllowed = true;
                }
                var msg = new NotificationMessage(ts_code_vm);
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex) { }
        }
        private void InsertGodown(object InputValue)
        {
            string Request = "";
            MM_M002_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.GodownList.Where(x => x.wa_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<MM_M002_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M002_P>().ToList()[0];
                    }

                }
            }
            catch (Exception ex)
            { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.para5 = POPUPEntityObject.wa_code;
                MasterEntity.wa_name = POPUPEntityObject.wa_name;

            }
        }
        private void InsertPlant(object InputValue)
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
            }
            catch (Exception ex)
            { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.location_Id = POPUPEntityObject.location_Id;
                MasterEntity.PlantName = POPUPEntityObject.LoctnNm;
            }

        }
        private void InsertLocations(object InputValue)
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
            }
            catch (Exception ex)
            { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.location_Id = POPUPEntityObject.location_Id;
                MasterEntity.PlantName = POPUPEntityObject.LoctnNm;
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

                if (POPUPEntityObject != null && dgSelectedIndexItem >= 0) // Only enter in the code block if ENtity Not null.
                {
                    ItemsEntity[dgSelectedIndexItem].volume_unit = POPUPEntityObject.unit_code;
                    MasterEntity.volume_unit = POPUPEntityObject.unit_code;
                    //var InputValueIfExists = ItemsEntity.Where(X => X.volume_unit == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    //int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.volume_unit == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    //if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    //{
                    //    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    //    {
                    //        ItemsEntity[dgSelectedIndexItem].volume_unit = POPUPEntityObject.unit_code;
                    //        MasterEntity.volume_unit = POPUPEntityObject.unit_code;
                    //    }
                    //    else if (ItemsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                    //    {
                    //        ItemsEntity[dgSelectedIndexItem].volume_unit = "";
                    //    }
                    //}
                }

                #region Clear Empty Row
                //SEL_T003_A newObj = new SEL_T003_A();
                //for (int i = ItemsEntity.Count - 1; i >= 0; i--)
                //{
                //    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
                //    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
                //    {
                //        ItemsEntity.RemoveAt(i);
                //        if (ItemsEntity.Count == 0)
                //        {
                //            ItemsEntity.Add(newObj);
                //        }
                //    }
                //}
                #endregion
            }
            catch (Exception ex) { }
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

                if (POPUPEntityObject != null && dgSelectedIndexItem >= 0) // Only enter in the code block if ENtity Not null.
                {
                    ItemsEntity[dgSelectedIndexItem].weight_unit = POPUPEntityObject.unit_code;
                    MasterEntity.para8 = POPUPEntityObject.unit_code;
                    //var InputValueIfExists = ItemsEntity.Where(X => X.weight_unit == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    //int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.weight_unit == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    //if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    //{
                    //    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    //    {
                    //        ItemsEntity[dgSelectedIndexItem].weight_unit = POPUPEntityObject.unit_code;
                    //        MasterEntity.para8 = POPUPEntityObject.unit_code;

                    //    }
                    //    else if (ItemsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                    //    {
                    //        ItemsEntity[dgSelectedIndexItem].weight_unit = "";
                    //    }
                    //}
                }

                #region Clear Empty Row
                //SEL_T003_A newObj = new SEL_T003_A();
                //for (int i = ItemsEntity.Count - 1; i >= 0; i--)
                //{
                //    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
                //    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
                //    {
                //        ItemsEntity.RemoveAt(i);
                //        if (ItemsEntity.Count == 0)
                //        {
                //            ItemsEntity.Add(newObj);
                //        }
                //    }
                //}
                #endregion
            }
            catch (Exception ex) { }
        }
        private void InsertFormType(object InputValue)//incomplete
        {
            string Request = "";
            ACC_M013_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.FormType.Where(x => x.description.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_M013_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M013_P>().ToList()[0];
                    }

                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.form_type = POPUPEntityObject.id;
                MasterEntity.FormDescription = POPUPEntityObject.description;
            }
        }
        public List<SEL_T003_A> TempItemList { get; set; }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                EntityChangeEnable = false;
                CursorControl.SetBusyState();
                string Request = "";
                string ParametersStringValue = "";
                SEL_T003Flip ParameterEntityObject = null;
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    ParametersStringValue = ParameterObject.ToString().Trim();
                    if (ParametersStringValue.Length > 0)
                    {
                        try
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
                                if (MasterEntity.ref_doc_cat == "DN" || MasterEntity.ref_doc_cat == "DC" || MasterEntity.ref_doc_cat == "FD" || MasterEntity.ref_doc_cat == "DE")
                                {
                                    Request = "LoadDocumentFromDeliveryNo" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + this.doc_cat_vm + "!@" + this.doc_cat_vm + "!@" + DocumentList + "!@" + AppSessionState.UserID + "!@!@!@" + MasterEntity.ref_doc_cat;
                                    //Request = "LoadDocumentFromDeliveryNo" + "!@" + DocumentList + "!@" + MasterEntity.ref_doc_cat;
                                }
                                else if (MasterEntity.ref_doc_cat == "SO" || MasterEntity.ref_doc_cat == "SN" || MasterEntity.ref_doc_cat == "QN")
                                {
                                    Request = "LoadDocumentFromSalesOrderReferneceNo" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + this.doc_cat_vm + "!@" + this.doc_cat_vm + "!@" + DocumentList + "!@" + AppSessionState.UserID + "!@!@!@" + MasterEntity.ref_doc_cat;
                                    //Request = "LoadDocumentFromSalesOrderReferneceNo" + "!@" + DocumentList;
                                }
                                else if (MasterEntity.ref_doc_cat == "PI" || MasterEntity.ref_doc_cat == "CI")
                                {
                                    Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + this.doc_cat_vm + "!@" + this.doc_cat_vm + "!@" + DocumentList + "!@" + AppSessionState.UserID + "!@!@!@" + MasterEntity.ref_doc_cat + "!@!@" + MasterEntity.PartyId;
                                    //Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + DocumentList + "!@" + PartyId;
                                }
                                string doctype = "";
                                string doctypedesc = "";
                                string doc_cat = "";
                                string bill_doc = "";
                                string DocTypeP = "";
                                string RefDocNo = "";
                                string LocalExport = "";

                                doctype = MasterEntity.doc_type;
                                doctypedesc = MasterEntity.doc_desc;
                                doc_cat = MasterEntity.doc_cat;
                                bill_doc = MasterEntity.bill_doc;
                                RefDocNo = MasterEntity.ref_doc_no;
                                LocalExport = MasterEntity.ind_trade;
                                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MCTemp, Request, "SalesInvoice", "CRM", "", 0, "FlipData");
                                if (MCTemp.MasterEntity.Count > 0)
                                {
                                    MasterEntity = MCTemp.MasterEntity[0];
                                    MasterEntity.doc_cat = this.doc_cat_vm;
                                    MasterEntity.doc_type = this.doc_cat_vm;
                                    MasterEntity.bill_cat = this.doc_cat_vm;
                                    MasterEntity.bill_type = this.doc_cat_vm;
                                    MasterEntity.location_Id = AppSessionState.location_Id;
                                    MasterEntity.comp_code = AppSessionState.comp_code;
                                    MasterEntity.add_by = AppSessionState.UserID;
                                    MasterEntity.editby = AppSessionState.UserID;
                                    MasterEntity.client = AppSessionState.client;
                                    MasterEntity.active = true;
                                    MasterEntity.t_status = "001";
                                    MasterEntity.t_display = (from o in MC.STATUS_LIST where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();
                                    MasterEntity.doc_date = DateTime.Now;
                                    MasterEntity.post_date = DateTime.Now;
                                    MasterEntity.entry_time = new TimeSpan();
                                    MasterEntity.user_source1 = AppSessionState.UserSource1;
                                    MasterEntity.user_source2 = AppSessionState.UserSource2;
                                    MasterEntity.Fltr_active = true;
                                    MasterEntity.Fltr_FrmDate = DateTime.Now.AddMonths(-1);
                                    MasterEntity.Fltr_ToDate = DateTime.Now;
                                    MasterEntity.Fltr_doc_type = MasterEntity.doc_type;


                                    MasterEntity.bill_doc = bill_doc;
                                    PartyEmailId = MasterEntity.EmailId;
                                    PersonEmailId = MasterEntity.PersnEmailId;
                                    DocTypeP = MasterEntity.doc_type;
                                    MasterEntity.PrintOption = "";
                                    if (MC.doc_typeList != null && !string.IsNullOrWhiteSpace(MasterEntity.doc_type))
                                    {
                                        AutoRoundupEnable = (bool)MC.doc_typeList.Find(x => x.doc_type == MasterEntity.doc_type).auto_roundup;
                                        RoundUpDecimals = (int)MC.doc_typeList.Find(x => x.doc_type == MasterEntity.doc_type).roundup_digits;
                                    }
                                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D_P)x).Location);
                                    TheFilter = (o, prefix) => ((ADM_M028_D_P)o).Location.ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M028_D_P)o).SrNo.ToString().ToString().ToLower().Contains(prefix.ToLower());
                                    ASBillAdddress = new AutoSuggestTextViewModel<dynamic>(MCTemp.PartysSoldToAddresses, TheFilter, SuggestedValue, "Location", true);
                                }
                                else
                                {
                                    MasterEntity = new SEL_T003();
                                }
                                if (MCTemp.ItemsEntity.Count > 0)
                                {
                                    ItemsEntity = new ObservableCollection<SEL_T003_A>();
                                    foreach (var item in MCTemp.ItemsEntity)
                                    {
                                        ItemsEntity.Add(item);
                                    }
                                }
                                if (TotalDocumentTaxes.Count() != '0')
                                {
                                }
                                else
                                {
                                    MC.TaxEntity = new ObservableCollection<ACC_T006_C>();
                                }

                                MC.ItemListPopup = MCTemp.ItemListPopup;
                                PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemListPopup);
                                PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);

                                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P_SI_ItemsList)x).ItemCode);
                                TheFilter = (o, prefix) => (((SEL_T003_P_SI_ItemsList)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SEL_T003_P_SI_ItemsList)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                                ASItems = new AutoSuggestTextViewModel<dynamic>(MC.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);

                                if (ParametersStringValue == "ReferenceDocument" && ref_doc_cat == "PI")
                                {
                                    MasterEntity.ref_doc_no = RefDocNo;
                                    MasterEntity.bill_doc = "";
                                }
                                else if (ParametersStringValue == "ReferenceDocument" && ref_doc_cat == "CI")
                                {
                                    MasterEntity.ref_doc_no = RefDocNo;
                                    MasterEntity.bill_doc = "";
                                }
                                DefaultValues();
                                MasterEntity.doc_cat = doc_cat;
                                MasterEntity.doc_type = doctype;
                                MasterEntity.bill_cat = doc_cat;
                                MasterEntity.bill_type = doctype;
                                //MasterEntity.ind_trade = LocalExport;
                                int count = ItemsEntity.Count();
                                TotalDocumentTaxes.Clear();
                                for (int i = 0; i < count; i++)
                                {
                                    Computation(true, i, AutoRoundupEnable);
                                }
                                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M025_P)x).wtax_code);
                                TheFilter = (o, prefix) => (((ACC_M025_P)o).wtax_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M025_P)o).wtax_ncode ?? "").ToString().ToLower().Contains(prefix.ToLower());
                                ASwithholding = new AutoSuggestTextViewModel<dynamic>(MCTemp.withholdinglist, TheFilter, SuggestedValue, "withholding_tax", true);
                                ASwithholding.AutoSuggestVM.IsEmptyValueAllowed = true;

                                if (MCTemp.withholdinglist.Count == 1)
                                {
                                    MasterEntity.withholding_tax = MCTemp.withholdinglist[0].wtax_code;
                                }
                                if (doc_cat_vm == "SI" && MasterEntity.ind_tcs == "Y")
                                {
                                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("This Customer exceed total sales limit of 50,00,000, apply TCS Tax for this invoice", this.Title); sms.ShowMessage();
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<SEL_T003Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<SEL_T003Flip>().ToList()[0];
                        Request = "LoadDocumentWithDocumentNumber" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + ParameterEntityObject.bill_doc + "!@!@!@!@!@!@" + ParameterEntityObject.PartyId;
                        //Request = "LoadDocumentWithDocumentNumber" + "!@" + ParameterEntityObject.bill_doc + " !@" + ParameterEntityObject.PartyId + "!@" + AppSessionState.comp_code;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MCTemp, Request, "SalesInvoice", "CRM", "", 0, "FlipData");
                        if (MCTemp.MasterEntity.Count > 0)
                        {
                            MasterEntity = MCTemp.MasterEntity[0];
                        }
                        if (MCTemp.ItemsEntity.Count > 0)
                        {
                            ItemsEntity = MCTemp.ItemsEntity;
                        }
                        TotalDocumentTaxes = MCTemp.TaxEntity;
                        PartyEmailId = MasterEntity.EmailId;
                        PersonEmailId = MasterEntity.PersnEmailId;

                        if (TotalDocumentTaxes.Count() != '0')
                        {
                            TotalDocumentTaxes = MCTemp.TaxEntity;
                        }
                        else
                        {
                            MC.TaxEntity = new ObservableCollection<ACC_T006_C>();
                        }
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D_P)x).Location);
                        TheFilter = (o, prefix) => (((ADM_M028_D_P)o).Location ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_D_P)o).SrNo.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                        ASBillAdddress = new AutoSuggestTextViewModel<dynamic>(MCTemp.PartysSoldToAddresses, TheFilter, SuggestedValue, "billing_address", true);

                        PopupItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListPopup);
                        PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                        StringListItems = MCTemp.ItemListPopup.Select(x => x.ItemCode).ToList();

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P_SI_ItemsList)x).ItemCode);
                        TheFilter = (o, prefix) => (((SEL_T003_P_SI_ItemsList)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SEL_T003_P_SI_ItemsList)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASItems = new AutoSuggestTextViewModel<dynamic>(MCTemp.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((CRM_T001A_P)x).cust_cat_no);
                        TheFilter = (o, prefix) => (((CRM_T001A_P)o).cust_cat_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASCustNo = new AutoSuggestTextViewModel<dynamic>(MCTemp.CustCatlogNo, TheFilter, SuggestedValue, "cust_cat_no", true);
                        ASCustNo.AutoSuggestVM.IsEmptyValueAllowed = true;

                        AttachmentCollection = CollectionViewSource.GetDefaultView(MCTemp.Attachment);

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M025_P)x).wtax_code);
                        TheFilter = (o, prefix) => (((ACC_M025_P)o).wtax_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M025_P)o).wtax_ncode ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASwithholding = new AutoSuggestTextViewModel<dynamic>(MCTemp.withholdinglist, TheFilter, SuggestedValue, "withholding_tax", true);
                        ASwithholding.AutoSuggestVM.IsEmptyValueAllowed = true;

                        isNewRecord = false;
                        SelectedTabControlIndex = 0;
                        AttachmentCount = MC.Attachment.Count;
                        MasterEntity.PrintOption = "";
                    }
                }
                MasterEntity.ts_code = ts_code_vm;
                var msg = new NotificationMessage(ts_code_vm);
                EntityChangeEnable = true;
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex)
            {
            }
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
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
                    MC.TaxEntity = (ObservableCollection<ACC_T006_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_T006_C, MC.TaxEntity);
                    TotalDocumentTaxes.Clear();
                    TotalDocumentTaxes = MC.TaxEntity;
                    //var GroupByTaxQuery = from wo in TotalDocumentTaxes
                    //                      group wo by wo.tax_name // tax_code_id replace with tax_name due to manual Tax integration.
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
                    //TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>(GroupByTaxQuery.OrderBy(tax => tax.tax_name));
                }
                else
                {
                    MC.TaxEntity = new ObservableCollection<ACC_T006_C>();
                }
                if (MasterEntity.XmlDataDocument_FlipGrid != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<SEL_T003Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                    FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                    FlipDataGridCollection.Refresh();
                    FlipDataGridCollection.SortDescriptions.Add(new SortDescription("doc_date", ListSortDirection.Descending));
                }
                RemoveRefDoc();
                MasterEntity.ts_code = ts_code_vm;
            }
            catch (Exception ex)
            {
            }
        }
        private void RemoveRefDoc()
        {
            try
            {
                if (MasterEntity.ref_doc_no != null)
                {
                    MC.Sales_Invoice_Reference.RemoveAll(X => DocumentList.Contains(X.Ref_DocNo));

                    refdoctempa = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "SO" select o).ToList();
                    ReferenceDocSOCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                    ReferenceDocSOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                    refdoctempa = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "DN" select o).ToList();
                    ReferenceDocDNCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                    ReferenceDocDNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                }
                var msg = new NotificationMessage(ts_code_vm);
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
        private void InsertNastroBank(object InputValue)
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
                        { POPUPEntityObject = MC.BanksList.Where(x => x.bank_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.nastro_bank_cd = POPUPEntityObject.bank_code;
                MasterEntity.nastro_bank_name = POPUPEntityObject.bank_name;
            }
            var msg = new NotificationMessage(ts_code_vm);
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        private void InsertReferenceDoc(object InputValue)
        {
            try
            {
                string Request = "";
                SEL_T003_P_RefDoc POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Sales_Invoice_Reference.Where(x => x.Ref_DocNo.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SEL_T003_P_RefDoc>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T003_P_RefDoc>().ToList()[0];
                    }

                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ref_doc_no = POPUPEntityObject.Ref_DocNo;
                    ref_doc_cat = POPUPEntityObject.doc_cat;
                    MasterEntity.ref_doc_cat = POPUPEntityObject.doc_cat;
                    MasterEntity.ref_doc_type = POPUPEntityObject.Ref_DocType;
                    PartyId = POPUPEntityObject.PartyId;
                    MasterEntity.doc_cat = "";
                    MasterEntity.doc_type = "";
                    MasterEntity.doc_desc = "";


                    if (POPUPEntityObject.doc_cat == "DC")
                    {
                        var refdoctemp = (from o in MC.doc_typeList where o.doc_type == "CM" select o).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M002)x).doc_type_user);
                        TheFilter = (o, prefix) => ((SYS_M002)o).doc_type_user.ToString().ToLower().Contains(prefix.ToLower());
                        ASDocType = new AutoSuggestTextViewModel<dynamic>(refdoctemp, TheFilter, SuggestedValue, "doc_type", true);

                        MasterEntity.doc_type = refdoctemp[0].doc_type;
                        MasterEntity.doc_desc = refdoctemp[0].doc_desc;
                        MasterEntity.doc_cat = refdoctemp[0].doc_cat;
                        MasterEntity.bill_cat = refdoctemp[0].doc_cat;
                        MasterEntity.bill_type = refdoctemp[0].doc_type;
                    }
                    else if (POPUPEntityObject.doc_cat == "DE")
                    {
                        var refdoctemp = (from o in MC.doc_typeList where o.doc_cat == "EI" select o).ToList();

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M002)x).doc_type_user);
                        TheFilter = (o, prefix) => ((SYS_M002)o).doc_type_user.ToString().ToLower().Contains(prefix.ToLower());
                        ASDocType = new AutoSuggestTextViewModel<dynamic>(refdoctemp, TheFilter, SuggestedValue, "doc_type", true);

                        MasterEntity.doc_cat = refdoctemp[0].doc_cat;
                        MasterEntity.ind_trade = "E";

                    }
                    else if (POPUPEntityObject.doc_cat == "FD")
                    {
                        var refdoctemp = (from o in MC.doc_typeList where o.doc_type == "FS" select o).ToList();

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M002)x).doc_type_user);
                        TheFilter = (o, prefix) => ((SYS_M002)o).doc_type_user.ToString().ToLower().Contains(prefix.ToLower());
                        ASDocType = new AutoSuggestTextViewModel<dynamic>(refdoctemp, TheFilter, SuggestedValue, "doc_type", true);

                        MasterEntity.doc_type = refdoctemp[0].doc_type;
                        MasterEntity.doc_desc = refdoctemp[0].doc_desc;
                        MasterEntity.doc_cat = refdoctemp[0].doc_cat;
                        MasterEntity.bill_cat = refdoctemp[0].doc_cat;
                        MasterEntity.bill_type = refdoctemp[0].doc_type;
                    }
                    else if (MasterEntity.ref_doc_type == "EX")
                    {
                        var refdoctemp = (from o in MC.doc_typeList where o.doc_cat == "EI" select o).ToList();

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M002)x).doc_type_user);
                        TheFilter = (o, prefix) => ((SYS_M002)o).doc_type_user.ToString().ToLower().Contains(prefix.ToLower());
                        ASDocType = new AutoSuggestTextViewModel<dynamic>(refdoctemp, TheFilter, SuggestedValue, "doc_type", true);

                        MasterEntity.ind_trade = "E";
                        MasterEntity.doc_cat = refdoctemp[0].doc_cat;
                        MasterEntity.bill_cat = refdoctemp[0].doc_cat;
                    }

                    else
                    {
                        DefaultValues();
                    }
                }
                var msg = new NotificationMessage(ts_code_vm);
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex) { }

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
                            con_cat = POPUPEntityObject.con_cat


                        });

                    }
                    else if (TotalDocumentTaxes.Count > dgSelectedIndexTaxSummury)
                    {
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].con_type = POPUPEntityObject.con_type;
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].con_cat = POPUPEntityObject.con_cat;

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

                            gl_code = POPUPEntityObject.gl_code


                        });

                    }
                    else if (TotalDocumentTaxes.Count > dgSelectedIndexTaxSummury)
                    {
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].gl_code = POPUPEntityObject.gl_code;

                    }
                }
            }
            catch (Exception ex) { }
        }
        private void InsertLicenseEPCG(object InputValue)
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
                    if (((IEnumerable)InputValue).Cast<ADM_M041_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M041_P>().ToList()[0];
                    }

                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.lic_cod = POPUPEntityObject.lic_cod;

            }
        }
        private void InsertLicenseAdvance(object InputValue)
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
                        {
                            POPUPEntityObject = MC.LicenseAdvance.Where(x => x.lic_cod.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M041_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M041_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.advance_lic = POPUPEntityObject.lic_cod;
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertLocation(object InputValue)
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
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                ItemsEntity[dgSelectedIndexItem].location_Id = POPUPEntityObject.location_Id;
            }

        }
        private void InsertPayer(object InputValue)
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
            }
            catch (Exception ex)
            { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.payer = POPUPEntityObject.PartyId;
                MasterEntity.payer_name = POPUPEntityObject.PartyNm;
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
                            { POPUPEntityObject = MC.SalesPerson.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.para1 = POPUPEntityObject.EmpId;

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
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i && ItemsEntity[dgSelectedIndexItem].id == 0)
                {
                    ItemsEntity.RemoveAt(i);
                    Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
                }
            }
            catch (Exception ex) { }
        }
        private void InsertManualTaxChangedCommand(object InputValue)
        {
            try
            {
                Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
            }
            catch (Exception ex) { }
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
                    Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
                }
            }
            catch (Exception ex) { }
        }
        private void InsertItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                SEL_T003_P_SI_ItemsList POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MCTemp.ItemListPopup.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T003_P_SI_ItemsList>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = ItemsEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());
                    var LineId = ItemsEntity.Count + 1;
                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                    {
                        ItemsEntity.Add(new SEL_T003_A()
                        {
                            id = 0,
                            ItemCode = POPUPEntityObject.ItemCode,
                            item_desc = POPUPEntityObject.ItemName,
                            SubCatCode = POPUPEntityObject.SubCatCode,
                            StockUnt = Convert.ToBoolean(POPUPEntityObject.StockUnt),
                            ref_doc_no = MasterEntity.ref_doc_no,
                            ref_doc_type = MasterEntity.ref_doc_type,
                            tax_id = String.IsNullOrEmpty(POPUPEntityObject.tax_id) ? MasterEntity.form_type.ToString() : POPUPEntityObject.tax_id,
                            unit_code = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM,
                            unit_price = String.IsNullOrEmpty(POPUPEntityObject.Rate_Catlog.ToString()) ? POPUPEntityObject.rate : POPUPEntityObject.Rate_Catlog,
                            qty = POPUPEntityObject.qty,
                            subtotal = POPUPEntityObject.sub_total,
                            active = true,
                            line_id = LineId,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            client = AppSessionState.client,
                            add_by = AppSessionState.UserID,
                            item_cat = POPUPEntityObject.item_cat_id,
                            //ship_to_Party = MasterEntity.ship_to_party,
                            //ship_to_add = MasterEntity.del_address,
                            buss_place = MasterEntity.buss_place,
                            t_status = MasterEntity.t_status,
                            t_display = MasterEntity.t_display,
                            weight_unit = POPUPEntityObject.weight_unit,
                            volume_unit = POPUPEntityObject.volume_unit
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
                            //ItemsEntity[dgSelectedIndexItem].line_id = 0;
                            ItemsEntity[dgSelectedIndexItem].ref_doc_no = MasterEntity.ref_doc_no;
                            ItemsEntity[dgSelectedIndexItem].ref_doc_type = MasterEntity.ref_doc_type;
                            ItemsEntity[dgSelectedIndexItem].tax_id = String.IsNullOrEmpty(POPUPEntityObject.tax_id) ? MasterEntity.form_type.ToString() : POPUPEntityObject.tax_id;
                            ItemsEntity[dgSelectedIndexItem].unit_code = String.IsNullOrEmpty(POPUPEntityObject.Catlog_UOM) ? POPUPEntityObject.unit_code : POPUPEntityObject.Catlog_UOM;
                            ItemsEntity[dgSelectedIndexItem].unit_price = String.IsNullOrEmpty(POPUPEntityObject.Rate_Catlog.ToString()) ? POPUPEntityObject.rate : POPUPEntityObject.Rate_Catlog;
                            ItemsEntity[dgSelectedIndexItem].qty = POPUPEntityObject.qty;
                            ItemsEntity[dgSelectedIndexItem].subtotal = POPUPEntityObject.sub_total;
                            ItemsEntity[dgSelectedIndexItem].item_cat = POPUPEntityObject.item_cat_id;
                            //ItemsEntity[dgSelectedIndexItem].ship_to_Party = MasterEntity.ship_to_party;
                            //ItemsEntity[dgSelectedIndexItem].ship_to_add = MasterEntity.del_address;
                            ItemsEntity[dgSelectedIndexItem].buss_place = MasterEntity.buss_place;
                            ItemsEntity[dgSelectedIndexItem].client = AppSessionState.client;
                            ItemsEntity[dgSelectedIndexItem].t_status = "Draft";
                            ItemsEntity[dgSelectedIndexItem].weight_unit = POPUPEntityObject.weight_unit;
                            ItemsEntity[dgSelectedIndexItem].volume_unit = POPUPEntityObject.volume_unit;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].ItemCode != POPUPEntityObject.ItemCode)
                        {
                            ItemsEntity[dgSelectedIndexItem].ItemCode = "";
                            ItemsEntity[dgSelectedIndexItem].item_desc = "";
                        }
                    }

                }
                #region Clear Empty Row
                SEL_T003_A newObj = new SEL_T003_A();
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
            catch (Exception ex) { }
        }
        private void InsertInk(object InputValue)
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
                    if (((IEnumerable)InputValue).Cast<ZADM_M006_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M006_P>().ToList()[0];
                    }

                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                ItemsEntity[dgSelectedIndexItem].para2 = POPUPEntityObject.ink;
            }
        }
        private void InsertILD(object InputValue)
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
                    if (((IEnumerable)InputValue).Cast<ZADM_M007_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M007_P>().ToList()[0];
                    }

                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                ItemsEntity[dgSelectedIndexItem].para5 = POPUPEntityObject.ild;
            }
        }
        private void InsertBank(object InputValue)
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
                        { POPUPEntityObject = MC.BanksList.Where(x => x.bank_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.bank_code = POPUPEntityObject.bank_code;
                MasterEntity.bank_name = POPUPEntityObject.bank_name;
            }
        }
        private void InsertCostCenter(object InputValue)
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
                    if (((IEnumerable)InputValue).Cast<ACC_M019_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M019_P>().ToList()[0];
                    }

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
                    var InputValueIfExists = ItemsEntity.Where(X => X.item_cat == POPUPEntityObject.sditem_cat_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.item_cat == POPUPEntityObject.sditem_cat_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].item_cat = POPUPEntityObject.sditem_cat_code;

                        }
                        else if (ItemsEntity[dgSelectedIndexItem].item_cat != POPUPEntityObject.sditem_cat_code)
                        {
                            ItemsEntity[dgSelectedIndexItem].item_cat = "";
                        }
                    }
                }
                #region Clear Empty Row
                SEL_T003_A newObj = new SEL_T003_A();
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
            catch (Exception) { }
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
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = ItemsEntity.Where(x => x.unit_code == POPUPEntityObject.unit_code).FirstOrDefault();
                    var IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault());
                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
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
                        }
                    }
                    unitconversion();
                }
                #region Clear Empty Row
                SEL_T003_A newObj = new SEL_T003_A();
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
            catch (Exception ex) { }
        }
        private void unitconversion()
        {

            var CurrantUnitCF = (from o in UnitConversionList where (o.unit_code == PreviousUnitCode) select o).ToList();
            var NewUnitCF = (from o in UnitConversionList where (o.unit_code == NewUnitCode) select o).ToList();
            if (CurrantUnitCF.Count > 0 && NewUnitCF.Count > 0)
            {
                ItemsEntity[dgSelectedIndexItem].qty = (ItemsEntity[dgSelectedIndexItem].qty * CurrantUnitCF[0].c_factor) / NewUnitCF[0].c_factor;
                ItemsEntity[dgSelectedIndexItem].unit_price = (ItemsEntity[dgSelectedIndexItem].unit_price / CurrantUnitCF[0].c_factor) * NewUnitCF[0].c_factor;
            }
        }
        private void InsertSalseDivision(object InputValue)
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
                    if (((IEnumerable)InputValue).Cast<ADM_M001_D_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_D_P>().ToList()[0];
                    }

                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.div_code = POPUPEntityObject.div_code;
                MasterEntity.div_name = POPUPEntityObject.div_name;
            }
        }
        private void InsertSalseOrg(object InputValue)
        {
            string Request = "";
            ADM_M001_A_P POPUPEntityObject = null;
            #region Command parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = SalesOrganisationList.Where(x => x.so_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M001_A_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_A_P>().ToList()[0];
                    }

                }
            }
            catch (Exception ex) { }
            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.so_code = POPUPEntityObject.so_code;
                MasterEntity.sales_org = POPUPEntityObject.sales_org;
            }
        }
        private void InsertCurrency(object InputValue)
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
                        { POPUPEntityObject = MC.CurrencysList.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.exc_rate = 1;
                }

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
                        { POPUPEntityObject = MC.CurrencysList.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    if (Currency == TotalDocumentTaxes[dgSelectedIndexTaxSummury].curr_code)
                    {
                        TotalDocumentTaxes[dgSelectedIndexTaxSummury].exch_rate = 1;
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
        private void InsertJournal(object InputValue)
        {
            string Request = "";
            ACC_M005_P POPUPEntityObject = null;
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
            }
            catch (Exception ex)
            { }
            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.j_code = POPUPEntityObject.j_code;
                MasterEntity.j_name = POPUPEntityObject.j_name;
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
            }
            catch (Exception ex)
            { }
            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.cf_agent_cd = POPUPEntityObject.PartyId;
                MasterEntity.cf_agent_name = POPUPEntityObject.PartyNm;
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
        private void InsertTransporter(object InputValue, bool OverrideValue)
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
                        { POPUPEntityObject = MC.Transporters.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
            }
            catch (Exception ex)
            { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.tr_party = POPUPEntityObject.PartyId;
                MasterEntity.transporter_name = POPUPEntityObject.PartyNm;
            }
        }
        private void InsertCustCatlogNo(object InputValue)
        {
            string Request = "";
            string RequestParameterData = "";
            CRM_T001A_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {

                            POPUPEntityObject = MCTemp.CustCatlogNo.Where(x => x.cust_cat_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.description.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<CRM_T001A_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<CRM_T001A_P>().ToList()[0];
                    }

                }
            }
            catch (Exception ex)
            { }
            if (POPUPEntityObject != null)
            {
                MasterEntity.cust_cat_no = POPUPEntityObject.cust_cat_no;

                RequestParameterData = "LoadFromCatlogNo" + "!@" + AppSessionState.comp_code + "!@" + MasterEntity.cust_cat_no;
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MCTemp, RequestParameterData, "SalesInvoice", "CRM", "", 0, "");

                PopupItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListPopup);
                PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                StringListItems = MCTemp.ItemListPopup.Select(x => x.ItemCode).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P_SI_ItemsList)x).ItemCode);
                TheFilter = (o, prefix) => (((SEL_T003_P_SI_ItemsList)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SEL_T003_P_SI_ItemsList)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASItems = new AutoSuggestTextViewModel<dynamic>(MCTemp.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASItems.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASItems.AutoSuggestVM.IsFreeTextAllowed = true;

                ItemsEntity.Clear();

            }
            var msg = new NotificationMessage(ts_code_vm);
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        private void InsertSoldToParty(object InputValue, bool OverrideValue)//incomplete
        {
            try
            {
                string Request = "";
                string RequestParameterData = "";
                ADM_M028_P POPUPEntityObject = null;
                try
                {
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
                }
                catch (Exception ex)
                { }
                if (POPUPEntityObject != null)
                {
                    if ((String.IsNullOrEmpty(MasterEntity.bill_doc) != true || String.IsNullOrWhiteSpace(MasterEntity.bill_doc) != true) && MasterEntity.PartyId != POPUPEntityObject.PartyId) //Condition: Only enter in the code block if ENtity Not null. Means It is in Edit Mode.
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
                            MasterEntity.sold_to_party_name = POPUPEntityObject.PartyNm;
                            MasterEntity.p_term_code = POPUPEntityObject.p_term_code;
                            MasterEntity.curr_code = POPUPEntityObject.curr_code;
                            MasterEntity.symbol = POPUPEntityObject.symbol;
                            MasterEntity.gst_PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.buss_place = POPUPEntityObject.buss_place;
                            if (MasterEntity.curr_code == Currency)
                            {
                                MasterEntity.exc_rate = 1;
                            }
                            PartyEmailId = POPUPEntityObject.EmailId;
                            PersonEmailId = POPUPEntityObject.PersnEmailId;

                            RequestParameterData = "LoadFromSoldToPartyDetails" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + MasterEntity.doc_type + "!@!@!@!@!@!@!@" + MasterEntity.PartyId;
                            //RequestParameterData = "LoadFromSoldToPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + MasterEntity.PartyId;
                            MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MCTemp, RequestParameterData, "SalesInvoice", "CRM", "", 0, "");

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D_P)x).Location);
                            TheFilter = (o, prefix) => (((ADM_M028_D_P)o).Location ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_D_P)o).SrNo.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                            ASBillAdddress = new AutoSuggestTextViewModel<dynamic>(MCTemp.PartysSoldToAddresses, TheFilter, SuggestedValue, "billing_address", true);
                            ASBillAdddress.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASBillAdddress.AutoSuggestVM.IsFreeTextAllowed = true;

                            if (MCTemp.PartysSoldToAddresses.Count > 0 && MCTemp.PartysSoldToAddresses.Count == 1)
                            {
                                MasterEntity.bill_address_id = 0;
                                MasterEntity.billing_address = "";
                                MasterEntity.bill_address_id = MCTemp.PartysSoldToAddresses[0].SrNo;
                                MasterEntity.billing_address = MCTemp.PartysSoldToAddresses[0].Location;

                            }
                            else if (MCTemp.PartysSoldToAddresses.Count > 1)
                            {
                                MasterEntity.bill_address_id = 0;
                                MasterEntity.billing_address = "";
                            }
                            else if (MCTemp.PartysSoldToAddresses.Count == 0)
                            {
                                MasterEntity.bill_address_id = 0;
                                MasterEntity.billing_address = "";
                            }

                            PopupItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListPopup);
                            PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                            StringListItems = MCTemp.ItemListPopup.Select(x => x.ItemCode).ToList();

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P_SI_ItemsList)x).ItemCode);
                            TheFilter = (o, prefix) => (((SEL_T003_P_SI_ItemsList)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SEL_T003_P_SI_ItemsList)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                            ASItems = new AutoSuggestTextViewModel<dynamic>(MCTemp.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                            ASItems.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASItems.AutoSuggestVM.IsFreeTextAllowed = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((CRM_T001A_P)x).cust_cat_no);
                            TheFilter = (o, prefix) => (((CRM_T001A_P)o).cust_cat_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                            ASCustNo = new AutoSuggestTextViewModel<dynamic>(MCTemp.CustCatlogNo, TheFilter, SuggestedValue, "cust_cat_no", true);
                            ASCustNo.AutoSuggestVM.IsEmptyValueAllowed = true;

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
                            MasterEntity.sold_to_party_name = POPUPEntityObject.PartyNm;
                            MasterEntity.p_term_code = POPUPEntityObject.p_term_code;
                            MasterEntity.curr_code = POPUPEntityObject.curr_code;
                            MasterEntity.symbol = POPUPEntityObject.symbol;
                            MasterEntity.gst_PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.buss_place = POPUPEntityObject.buss_place;
                            if (MasterEntity.curr_code == Currency)
                            {
                                MasterEntity.exc_rate = 1;
                            }
                            PartyEmailId = POPUPEntityObject.EmailId;
                            PersonEmailId = POPUPEntityObject.PersnEmailId;

                            RequestParameterData = "LoadFromSoldToPartyDetails" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + MasterEntity.doc_type + "!@!@!@!@!@!@!@" + MasterEntity.PartyId;
                            //RequestParameterData = "LoadFromSoldToPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.PartyId;
                            MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MCTemp, RequestParameterData, "SalesInvoice", "CRM", "", 0, "");

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D_P)x).Location);
                            TheFilter = (o, prefix) => (((ADM_M028_D_P)o).Location ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_D_P)o).SrNo.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                            ASBillAdddress = new AutoSuggestTextViewModel<dynamic>(MCTemp.PartysSoldToAddresses, TheFilter, SuggestedValue, "billing_address", true);
                            ASBillAdddress.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASBillAdddress.AutoSuggestVM.IsFreeTextAllowed = true;

                            if (MCTemp.PartysSoldToAddresses.Count > 0 && MCTemp.PartysSoldToAddresses.Count == 1)
                            {
                                MasterEntity.bill_address_id = 0;
                                MasterEntity.billing_address = "";
                                MasterEntity.bill_address_id = MCTemp.PartysSoldToAddresses[0].SrNo;
                                MasterEntity.billing_address = MCTemp.PartysSoldToAddresses[0].Location;

                            }
                            else if (MCTemp.PartysSoldToAddresses.Count > 1)
                            {
                                MasterEntity.bill_address_id = 0;
                                MasterEntity.billing_address = "";
                            }
                            else if (MCTemp.PartysSoldToAddresses.Count == 0)
                            {
                                MasterEntity.bill_address_id = 0;
                                MasterEntity.billing_address = "";
                            }

                            PopupItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListPopup);
                            PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                            StringListItems = MCTemp.ItemListPopup.Select(x => x.ItemCode).ToList();

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P_SI_ItemsList)x).ItemCode);
                            TheFilter = (o, prefix) => (((SEL_T003_P_SI_ItemsList)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SEL_T003_P_SI_ItemsList)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                            ASItems = new AutoSuggestTextViewModel<dynamic>(MCTemp.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                            ASItems.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASItems.AutoSuggestVM.IsFreeTextAllowed = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((CRM_T001A_P)x).cust_cat_no);
                            TheFilter = (o, prefix) => (((CRM_T001A_P)o).cust_cat_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                            ASCustNo = new AutoSuggestTextViewModel<dynamic>(MCTemp.CustCatlogNo, TheFilter, SuggestedValue, "cust_cat_no", true);
                            ASCustNo.AutoSuggestVM.IsEmptyValueAllowed = true;

                            ItemsEntity.Clear();
                        }
                    }
                    else if (MasterEntity.PartyId != POPUPEntityObject.PartyId)
                    {
                        MasterEntity.PartyId = POPUPEntityObject.PartyId;
                        MasterEntity.sold_to_party_name = POPUPEntityObject.PartyNm;
                        MasterEntity.p_term_code = POPUPEntityObject.p_term_code;
                        MasterEntity.curr_code = POPUPEntityObject.curr_code;
                        MasterEntity.symbol = POPUPEntityObject.symbol;
                        MasterEntity.gst_PartyId = POPUPEntityObject.PartyId;
                        MasterEntity.buss_place = POPUPEntityObject.buss_place;
                        if (MasterEntity.curr_code == Currency)
                        {
                            MasterEntity.exc_rate = 1;
                        }
                        PartyEmailId = POPUPEntityObject.EmailId;
                        PersonEmailId = POPUPEntityObject.PersnEmailId;

                        RequestParameterData = "LoadFromSoldToPartyDetails" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + MasterEntity.doc_type + "!@!@!@!@!@!@!@" + MasterEntity.PartyId;
                        //RequestParameterData = "LoadFromSoldToPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + MasterEntity.PartyId;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MCTemp, RequestParameterData, "SalesInvoice", "CRM", "", 0, "");

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D_P)x).Location);
                        TheFilter = (o, prefix) => (((ADM_M028_D_P)o).Location ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_D_P)o).SrNo.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                        ASBillAdddress = new AutoSuggestTextViewModel<dynamic>(MCTemp.PartysSoldToAddresses, TheFilter, SuggestedValue, "billing_address", true);
                        ASBillAdddress.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASBillAdddress.AutoSuggestVM.IsFreeTextAllowed = true;

                        if (MCTemp.PartysSoldToAddresses.Count > 0 && MCTemp.PartysSoldToAddresses.Count == 1)
                        {
                            MasterEntity.bill_address_id = 0;
                            MasterEntity.billing_address = "";
                            MasterEntity.bill_address_id = MCTemp.PartysSoldToAddresses[0].SrNo;
                            MasterEntity.billing_address = MCTemp.PartysSoldToAddresses[0].Location;

                        }
                        else if (MCTemp.PartysSoldToAddresses.Count > 1)
                        {
                            MasterEntity.bill_address_id = 0;
                            MasterEntity.billing_address = "";
                        }
                        else if (MCTemp.PartysSoldToAddresses.Count == 0)
                        {
                            MasterEntity.bill_address_id = 0;
                            MasterEntity.billing_address = "";
                        }

                        PopupItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemListPopup);
                        PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                        StringListItems = MCTemp.ItemListPopup.Select(x => x.ItemCode).ToList();

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P_SI_ItemsList)x).ItemCode);
                        TheFilter = (o, prefix) => (((SEL_T003_P_SI_ItemsList)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SEL_T003_P_SI_ItemsList)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASItems = new AutoSuggestTextViewModel<dynamic>(MCTemp.ItemListPopup, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                        ASItems.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASItems.AutoSuggestVM.IsFreeTextAllowed = true;

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((CRM_T001A_P)x).cust_cat_no);
                        TheFilter = (o, prefix) => (((CRM_T001A_P)o).cust_cat_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASCustNo = new AutoSuggestTextViewModel<dynamic>(MCTemp.CustCatlogNo, TheFilter, SuggestedValue, "cust_cat_no", true);
                        ASCustNo.AutoSuggestVM.IsEmptyValueAllowed = true;

                        ItemsEntity.Clear();
                    }
                }
                var msg = new NotificationMessage(ts_code_vm);
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex) { }
        }
        private void InsertSoldToPartyAddress(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M028_D_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MCTemp.PartysSoldToAddresses.Where(x => x.Location.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        if (((IEnumerable)InputValue).Cast<ADM_M028_D_P>().Count() > 0)
                        {
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_D_P>().ToList()[0];
                        }

                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.bill_address_id = POPUPEntityObject.SrNo;
                    MasterEntity.billing_address = POPUPEntityObject.Location;
                }
            }
            catch (Exception ex) { }
        }
        // below 4 methods are for Parameters and Parameter Values
        private void InsertCollectionChanged(IList DataList)
        {
            try
            {
                string[] TempSkuList = new string[100];
                List<string> TempParaValueList = new List<string>();
                IList list = DataList as IList;
                int a = dgSelectedIndexItem;

                if (MC.ParameterList.Count > 0)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ItemsEntity.Count > 0 && dgSelectedIndexItem < ItemsEntity.Count && dgSelectedIndexItem != -1)
                    {
                        List<SEL_T003_A> SelectedRowlist = list.Cast<SEL_T003_A>().ToList();

                        if (SelectedRowlist[0].StockUnt == true && MC.ParameterList.Count > 0)
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
                                        // ItemCode = SelectedRowlist[0].ItemCode,
                                        dgselectedindex = dgSelectedIndexItem,
                                        //  value_code = SelectedParaValueList[0].value_code,
                                        para_code = paramlist[i].para_code,
                                        para_name = paramlist[i].para_name

                                    });
                                }


                                if (ItemsEntity[dgSelectedIndexItem].sku_desc != null)
                                {
                                    SelectedParaValueCollection = ParameterTemp.Cast<ADM_M031_P>().ToList();

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
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && MC.ParamValueList.Count > 0)
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
            catch (Exception ex) { }
        }
        private void GetSkuDescription()
        {
            try
            {
                if (ItemsEntity[dgSelectedIndexItem].sku_desc == null || ItemsEntity[dgSelectedIndexItem].sku_desc == "")
                {
                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].sku_desc == "" || ItemsEntity[dgSelectedIndexItem].sku_desc == null && SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
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
                        if (ItemsEntity[dgSelectedIndexItem].sku_desc == "" || ItemsEntity[dgSelectedIndexItem].sku_desc == null && SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
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
            catch (Exception ex) { }
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
            catch (Exception ex) { }
        }
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            if (EntityChangeEnable == true)
            {
                if (sender.ToString() == "withholding_tax")
                {
                    CalWithHoldingTax();
                }
                if (sender.ToString() == "hb_acc")
                {
                    if (!string.IsNullOrWhiteSpace(MasterEntity.hb_acc) && MC.hbList.Count > 0)
                    {
                        MasterEntity.bank_name = MC.hbList.Where(b => b.hb_acc == MasterEntity.hb_acc).ToList()[0].bank_name;
                        MasterEntity.bank_code = MC.hbList.Where(b => b.hb_acc == MasterEntity.hb_acc).ToList()[0].bank_code;
                    }
                }
                this.ErrorExist = false; /*MasterEntity.HasErrors;*/
            }
        }
        private void CalWithHoldingTax()
        {
            try
            {
                if (MC.withholdinglist != null && MasterEntity.withholding_tax != null && MasterEntity.withholding_tax != "")
                {
                    ACC_M025_P POPUPEntityObject = MC.withholdinglist.Where(x => x.wtax_code == MasterEntity.withholding_tax).ToList()[0];
                    if (POPUPEntityObject != null && POPUPEntityObject.wtax_per != 0)
                    {
                        MasterEntity.withholding_value = MasterEntity.net_value * (POPUPEntityObject.wtax_rate / POPUPEntityObject.wtax_per);
                        //MasterEntity.withholding_value = MasterEntity.net_value - MasterEntity.withholding_value;
                    }
                }
            }
            catch (Exception Ex) { }
        }
        void ModelUpdated_Tax(object sender, EventArgs e)
        {
            if (EntityChangeEnable == true)
            {
                //This will get called when the property of an object inside the collection changes
                if (sender.ToString() == "exch_rate" || sender.ToString() == "curr_code")
                {
                    Computation_ExchRate(true);//this is in use 
                }

                this.ErrorExist = false;
                if (TotalDocumentTaxes.Count > dgSelectedIndexTaxSummury && dgSelectedIndexTaxSummury >= 0)
                {
                    this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
                }
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
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (EntityChangeEnable == true)
            {
                if (e.PropertyName == "qty" || e.PropertyName == "unit_price" || e.PropertyName == "tax_id" || e.PropertyName == "active" || e.PropertyName == "discount")
                {
                    Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
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
                //if (e.PropertyName == "volume")
                //{
                //    foreach (var o in ItemsEntity)
                //    {
                //        MasterEntity.volume = ItemsEntity.Where(item => o.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && && (o.sku?.ToString() ?? "") == (ItemsEntity[dgSelectedIndexItem].sku?.ToString() ?? "")).Sum(item => Convert.ToDecimal(item.volume_unit));
                //    }

                //}
                if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
                }
            }
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            if (EntityChangeEnable == true)
            {
                //This will get called when the property of an object inside the collection changes
                if (sender.ToString() == "line_id" || sender.ToString() == "qty" || sender.ToString() == "unit_price" || sender.ToString() == "tax_id" || sender.ToString() == "active" || sender.ToString() == "discount")
                {
                    Computation(true, dgSelectedIndexItem, AutoRoundupEnable);//this is in use 
                }

                if (sender.ToString() == "gross_wt")
                {
                    MasterEntity.gross_wt = ItemsEntity.Where(item => item.active != false).Sum(item => item.gross_wt);
                }
                if (sender.ToString() == "volume")
                {
                    MasterEntity.volume = ItemsEntity.Where(item => item.active != false).Sum(item => item.volume);
                }
                if (sender.ToString() == "wt_net")
                {
                    MasterEntity.net_wt = ItemsEntity.Where(item => item.active != false).Sum(item => item.net_wt);
                }


                this.ErrorExist = false;
                if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItem].HasErrors;*/

                }
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
                        item.location_Id = AppSessionState.location_Id;
                        item.comp_code = AppSessionState.comp_code;
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                        item.symbol = MasterEntity.symbol;
                        item.local_curr = AppSessionState.CntryCurncy;
                        item.curr_code = MasterEntity.curr_code;

                        item.client = AppSessionState.client;
                        item.exch_rate = MasterEntity.exc_rate;
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
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (SEL_T003_A item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (SEL_T003_A item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (SEL_T003_A item in e.NewItems)
                    {
                        //Added items
                        item.symbol = MasterEntity.symbol;
                        item.user_source1 = AppSessionState.UserSource1;
                        item.user_source2 = AppSessionState.UserSource2;
                        item.comp_code = AppSessionState.comp_code;
                        item.location_Id = AppSessionState.location_Id;
                        item.active = true;
                        item.add_by = AppSessionState.UserID;
                        item.editby = AppSessionState.UserID;
                        item.t_status = "001";
                        item.t_display = (from o in MC.STATUS_LIST where o.t_status == item.t_status select o.t_display).FirstOrDefault();
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                    if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
                    }

                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                    this.ErrorExist = false; /*MasterEntity.HasErrors;*/
                    if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    SEL_T003_A temp = (SEL_T003_A)e.OldItems[0];
                    ////foreach (var itemToRemove in ItemScheduleEntity.Where(x => (x.ItemCode == temp.ItemCode && x.id == 0 && (x.sku?.ToString() ?? "") == (temp.sku?.ToString() ?? ""))).ToList())
                    ////{
                    ////    ItemScheduleEntity.Remove(itemToRemove);
                    ////}
                    if (TotalDocumentTaxes.Count > 0) // Remove Taxes deleted item.
                    {
                        List<ACC_T006_C> copy = new List<ACC_T006_C>();
                        copy = TotalDocumentTaxes.ToList();
                        foreach (var tax in copy)
                        {
                            if (tax.ItemCode == temp.ItemCode && tax.sku == temp.sku && tax.item_row_id == temp.id)
                            {
                                TotalDocumentTaxes.Remove(tax);
                                Computation(true, dgSelectedIndexItem, AutoRoundupEnable);
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
                    foreach (SEL_T003_A item in e.OldItems)
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
            catch (Exception ex) { }
        }
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
                        if (ItemsEntity[dgSelectedIndexItem].qty >= 0 && ItemsEntity[dgSelectedIndexItem].unit_price >= 0 && ItemsEntity[dgSelectedIndexItem].active != false) // Must not null or empty.
                        {
                            if (ItemsEntity[dgSelectedIndexItem].discount == null || ItemsEntity[dgSelectedIndexItem].discount.ToString().Trim() == "")
                            {
                                ItemsEntity[dgSelectedIndexItem].discount = 0;
                            }
                            ItemsEntity[dgSelectedIndexItem].subtotal = (ItemsEntity[dgSelectedIndexItem].qty * ItemsEntity[dgSelectedIndexItem].unit_price) - ((ItemsEntity[dgSelectedIndexItem].qty * ItemsEntity[dgSelectedIndexItem].unit_price) * (ItemsEntity[dgSelectedIndexItem].discount / 100));
                            // ItemsEntity[dgSelectedIndexItem].subtotal = ItemsEntity[dgSelectedIndexItem].qty * ItemsEntity[dgSelectedIndexItem].unit_price;
                        }
                        #region Remove previously assign Taxes to apply new for perticuler item row.
                        //if (TotalDocumentTaxes.Count > 0 && ItemsEntity[dgSelectedIndexItem].tax_id != null) // Remove previously assign Taxes to apply new for perticuler item row.//Condition satisfy only if Selected Item not null.
                        if (ItemsEntity[dgSelectedIndexItem].tax_id != null && ItemsEntity[dgSelectedIndexItem].active == true) // Remove previously assign Taxes from TotalDocumentTaxes to apply new for perticuler item row.//Condition satisfy only if Selected Item not null  and Active status is true.
                        {
                            if (!String.IsNullOrEmpty(ItemsEntity[dgSelectedIndexItem].tax_id.Trim()) && ItemsEntity[dgSelectedIndexItem].active != false) //Condition satisfy only if Selected Item having Tax assigned.
                            {
                                List<ACC_T006_C> copy = new List<ACC_T006_C>();
                                copy = TotalDocumentTaxes.ToList();
                                foreach (var tax in copy)
                                {
                                    if (tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[dgSelectedIndexItem].sku?.ToString() ?? ""))
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
                                                    PreviousTaxValueForBasePrice = TotalDocumentTaxes.Where(tax => tax.sequence < SingleTax.sequence && tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[dgSelectedIndexItem].sku?.ToString() ?? "") && tax.item_line_id == ItemsEntity[dgSelectedIndexItem].id && tax.tax_code_id.In(TaxListForBaseInclude)).Sum(tax => tax.tax_amount); // Get Base amount for Calculation.
                                                }
                                                if (SingleTax.parent_id != null) // Collect Base price for This single child Tax.
                                                {
                                                    BasePrice = TotalDocumentTaxes.Where(tax => tax.tax_code_id == SingleTax.parent_id && tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[dgSelectedIndexItem].sku?.ToString() ?? "") && tax.item_line_id == ItemsEntity[dgSelectedIndexItem].id).Single().tax_amount;
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

                                        TotalDocumentTaxes.Add(new ACC_T006_C()
                                        {
                                            id = 0
                                            ,
                                            tax_amount = TaxAmount
                                            ,
                                            account_id = 0,
                                            sequence = SingleTax.sequence
                                            ,
                                            doc_no = MasterEntity.po_no
                                            ,
                                            manual = "Auto"
                                            ,
                                            base_amount = BasePrice,
                                            amount = SingleTax.amount
                                            ,
                                            tax_code_id = SingleTax.id,
                                            account_analytic_id = 0
                                            ,
                                            base_code_id = SingleTax.id,
                                            tax_name = SingleTax.description
                                            ,
                                            curr_code = MasterEntity.curr_code
                                            //, gl_code = TotalDocumentTaxes[dgSelectedIndexTaxSummury].gl_code
                                            ,
                                            ItemCode = ItemsEntity[dgSelectedIndexItem].ItemCode
                                            ,
                                            sku = ItemsEntity[dgSelectedIndexItem].sku
                                            ,
                                            item_row_id = ItemsEntity[dgSelectedIndexItem].id
                                            ,
                                            fin_year = "2015",
                                            active = true
                                            ,
                                            location_Id = AppSessionState.location_Id
                                            ,
                                            comp_code = AppSessionState.comp_code
                                        });
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
                                    if (tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[dgSelectedIndexItem].sku?.ToString() ?? ""))
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
                                if (tax.ItemCode == ItemsEntity[dgSelectedIndexItem].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[dgSelectedIndexItem].sku?.ToString() ?? ""))
                                {
                                    TotalDocumentTaxes.Remove(tax);
                                }
                            }
                        }

                        #region Final Computation
                        //TaxtTotal = TotalDocumentTaxes.Sum(x => x.tax_amount);
                        TaxtTotal = TotalDocumentTaxes.Where(item => item.active != false).Sum(item => item.tax_amount);
                        MasterEntity.tax_amount = TaxtTotal;
                        //UnTaxTotal = ItemsEntity.Sum(x => x.sub_total);
                        UnTaxTotal = ItemsEntity.Where(item => item.active != false).Sum(item => item.subtotal);
                        MasterEntity.ass_value = UnTaxTotal;
                        MasterEntity.sub_total = UnTaxTotal;
                        GrandTotal = UnTaxTotal + TaxtTotal;
                        MasterEntity.invoice_amt = GrandTotal;
                        MasterEntity.roundup_total = decimal.Round((decimal)GrandTotal);
                        MasterEntity.round_up = MasterEntity.roundup_total - GrandTotal;
                        MasterEntity.invoice_amtr = MasterEntity.roundup_total * MasterEntity.exc_rate;
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
                        //TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>(GroupByTaxQuery.OrderBy(tax => tax.tax_name));
                        #endregion
                        #endregion
                    }


                }
            }
            catch (Exception ex) { }
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
                                    if (tax.ItemCode == ItemsEntity[RowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[RowIndex].sku?.ToString() ?? ""))
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
                                                    BasePrice = TotalDocumentTaxes.Where(tax => tax.tax_code_id == SingleTax.parent_id && tax.ItemCode == ItemsEntity[RowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[RowIndex].sku?.ToString() ?? "") && tax.item_line_id == ItemsEntity[RowIndex].id).Single().tax_amount;
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

                                        TotalDocumentTaxes.Add(new ACC_T006_C()
                                        {
                                            id = 0
                                        ,
                                            tax_amount = TaxAmount
                                        ,
                                            account_id = 0
                                        ,
                                            sequence = SingleTax.sequence
                                        ,
                                            doc_no = MasterEntity.po_no
                                        ,
                                            manual = "Auto"
                                        ,
                                            base_amount = BasePrice
                                        ,
                                            amount = SingleTax.amount
                                        ,
                                            tax_code_id = SingleTax.id
                                        ,
                                            account_analytic_id = 0
                                        ,
                                            base_code_id = SingleTax.id
                                        ,
                                            tax_name = SingleTax.description
                                        ,
                                            curr_code = MasterEntity.curr_code
                                        //,gl_code = TotalDocumentTaxesItem[RowIndex].gl_code
                                        ,
                                            ItemCode = ItemsEntity[RowIndex].ItemCode
                                        ,
                                            sku = ItemsEntity[RowIndex].sku
                                        ,
                                            item_row_id = ItemsEntity[RowIndex].id
                                        ,
                                            fin_year = "2015"
                                        ,
                                            active = true
                                        ,
                                            location_Id = AppSessionState.location_Id
                                        ,
                                            comp_code = AppSessionState.comp_code
                                        });
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
                                if (tax.ItemCode == ItemsEntity[RowIndex].ItemCode && (tax.sku?.ToString() ?? "") == (ItemsEntity[RowIndex].sku?.ToString() ?? ""))
                                {
                                    TotalDocumentTaxes.Remove(tax);
                                }
                            }
                        }
                        #region Final Computation
                        //TaxtTotal = TotalDocumentTaxes.Sum(x => x.tax_amount);
                        TaxtTotal = TotalDocumentTaxes.Where(item => item.active != false).Sum(item => item.tax_amount);
                        MasterEntity.tax_amount = TaxtTotal;
                        //UnTaxTotal = ItemsEntity.Sum(x => x.sub_total);
                        UnTaxTotal = ItemsEntity.Where(item => item.active != false).Sum(item => item.subtotal);
                        MasterEntity.ass_value = UnTaxTotal;
                        MasterEntity.sub_total = UnTaxTotal;
                        GrandTotal = UnTaxTotal + TaxtTotal;
                        MasterEntity.invoice_amt = GrandTotal;
                        MasterEntity.roundup_total = decimal.Round((decimal)GrandTotal);
                        MasterEntity.round_up = MasterEntity.roundup_total - GrandTotal;


                        MasterEntity.invoice_amtr = MasterEntity.roundup_total * MasterEntity.exc_rate;
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
                        //TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>(GroupByTaxQuery.OrderBy(tax => tax.tax_name));
                        #endregion
                        #endregion
                    }


                }
            }
            catch (Exception ex) { }
        }
        private void Computation_ExchRate(bool Compute)
        {
            if (Compute == true)
            {
                if (TotalDocumentTaxes.Count > 0)
                {
                    foreach (var o in TotalDocumentTaxes)
                    {
                        o.amt_local_curr = o.tax_amount * o.exch_rate;
                    }
                }
            }
        }
        private void Computation(bool Compute, int ItemRowIndex, bool AutoRoundUpFlag)
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
                        ItemsEntity[ItemRowIndex].local_gross_value = (gross_value_A * MasterEntity.exc_rate);
                        if (ItemsEntity[ItemRowIndex].discount.HasValue)
                        {
                            disc_percent_item = ItemsEntity[ItemRowIndex].discount;
                        }
                        sub_total_item = Math.Round((gross_value_A ?? 0) - ((gross_value_A ?? 0) * ((disc_percent_item ?? 0) / 100)), RoundUpDecimals);
                        ItemsEntity[ItemRowIndex].subtotal = sub_total_item;
                        ItemsEntity[ItemRowIndex].local_subtotal = (sub_total_item * MasterEntity.exc_rate);
                        discount_amt_A = gross_value_A - sub_total_item;
                        ItemsEntity[ItemRowIndex].discount_amt = discount_amt_A;
                        ItemsEntity[ItemRowIndex].local_discount = (discount_amt_A * MasterEntity.exc_rate);
                        ItemsEntity[ItemRowIndex].net_value = sub_total_item;
                        ItemsEntity[ItemRowIndex].local_net_value = (sub_total_item * MasterEntity.exc_rate);
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
                                TaxAmount = Math.Round(TaxAmount ?? 0, RoundUpDecimals);
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
                                    TotalDocumentTaxes[TaxIndex].doc_no = MasterEntity.bill_doc;
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
                                    TotalDocumentTaxes[TaxIndex].trns_key_code = "STX";

                                    TotalDocumentTaxes[TaxIndex].con_value = TaxAmount;
                                    TotalDocumentTaxes[TaxIndex].tax_code = SingleTax.tax_code;
                                    TotalDocumentTaxes[TaxIndex].PartyId = MasterEntity.PartyId;
                                    TotalDocumentTaxes[TaxIndex].exch_rate = MasterEntity.exc_rate;
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
                                        doc_no = MasterEntity.bill_doc,
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

                                Temptax_amount_A = Temptax_amount_A + TaxAmount;
                                ItemsEntity[ItemRowIndex].tax_amount = Temptax_amount_A;
                                net_value_A = gross_value_A - discount_amt_A + Temptax_amount_A;
                                ItemsEntity[ItemRowIndex].net_value = net_value_A;
                                ItemsEntity[ItemRowIndex].local_net_value = (net_value_A * MasterEntity.exc_rate);
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

                    local_tax_amt = (TaxtTotal * MasterEntity.exc_rate);
                    MasterEntity.local_tax_amount = local_tax_amt;

                    //UnTaxTotal = ItemsEntity.Sum(x => x.sub_total);
                    UnTaxTotal = ItemsEntity.Where(item => item.active != false).Sum(item => item.subtotal);
                    MasterEntity.ass_value = UnTaxTotal;
                    MasterEntity.sub_total = UnTaxTotal;
                    MasterEntity.local_sub_total = (UnTaxTotal * MasterEntity.exc_rate);
                    MasterEntity.local_ass_value = (UnTaxTotal * MasterEntity.exc_rate);

                    net_value = UnTaxTotal + TaxtTotal;
                    MasterEntity.net_value = net_value;
                    other_charges = TotalDocumentTaxes.Where(item => item.active != false && item.manual == "Manual").Sum(item => item.tax_amount);
                    MasterEntity.other_charges = other_charges;

                    local_net_value = (net_value * MasterEntity.exc_rate);
                    MasterEntity.local_net_value = local_net_value;

                    GrandTotal = net_value + other_charges;
                    GrandTotal = decimal.Round((decimal)GrandTotal, 2);
                    MasterEntity.invoice_amt = GrandTotal;

                    local_total_amt = (GrandTotal * MasterEntity.exc_rate);
                    MasterEntity.local_invoice_amt = local_total_amt;

                    if (AutoRoundUpFlag == true)
                    {
                        MasterEntity.roundup_total = decimal.Round((decimal)GrandTotal);
                        MasterEntity.local_roundup_total = (MasterEntity.roundup_total * MasterEntity.exc_rate);
                        MasterEntity.round_up = MasterEntity.roundup_total - GrandTotal;
                        MasterEntity.local_round_up = (MasterEntity.round_up * MasterEntity.exc_rate);
                    }
                    else
                    {
                        MasterEntity.round_up = 0;
                        MasterEntity.local_round_up = 0;
                        MasterEntity.roundup_total = GrandTotal + MasterEntity.round_up;
                        MasterEntity.local_roundup_total = (MasterEntity.roundup_total * MasterEntity.exc_rate);

                    }
                    MasterEntity.invoice_amtr = MasterEntity.roundup_total * MasterEntity.exc_rate ?? 1;
                    gross_value = ItemsEntity.Where(item => item.active != false).Sum(item => item.qty * item.unit_price);
                    MasterEntity.gross_value = gross_value;

                    effective_value = GrandTotal;
                    MasterEntity.effective_value = effective_value;

                    disc_amt = gross_value - UnTaxTotal;
                    MasterEntity.disc_amt = disc_amt;
                    MasterEntity.local_discount = (disc_amt * MasterEntity.exc_rate);

                    if (MasterEntity.roundup_total > 0 && !string.IsNullOrWhiteSpace(MasterEntity.curr_code))
                    {
                        ADM_M037 curr_obj = new ADM_M037();
                        curr_obj = ((List<ADM_M037>)AppSessionState.CurrencyList).Where(x => x.curr_code == MasterEntity.curr_code).ToList()[0];
                        MasterEntity.amt_word = num.AmountInWords(Convert.ToDecimal(MasterEntity.roundup_total), MasterEntity.curr_code, curr_obj.monitory_unit,curr_obj.monitory_unit_prefix,curr_obj.tail_word );
                    }
                    else
                    { MasterEntity.amt_word = ""; }

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
            Computation_ExchRate(true);
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
                    html += "<td width=10%> <p><strong><span style=color:#000080;> " + item.item_desc + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.qty.ToString() + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.unit_code + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.unit_price.ToString() + "</span></strong></p> </td>";
                    html += "</tr>";
                }
            }
            html += "</table>";

            return html;
        }
        private void NotifyMessage(string AlertName)
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
                        new KeyValuePair<string, string>("[EMP]",MasterEntity.seller_name),
                        new KeyValuePair<string, string>("[DOC]",MasterEntity.doc_desc),
                        new KeyValuePair<string, string>("[DOCNO]",MasterEntity.bill_doc),
                        new KeyValuePair<string, string>("[DOCDATE]",MasterEntity.doc_date.ToString()),
                        new KeyValuePair<string, string>("[Comp]",AppSessionState.CompanyName),
                        new KeyValuePair<string, string>("[CUR]",MasterEntity.curr_code.ToString()),
                        new KeyValuePair<string, string>("[OVAL]",MasterEntity.roundup_total.ToString()),
                        new KeyValuePair<string, string>("[CUST]",MasterEntity.sold_to_party_name),
                        new KeyValuePair<string, string>("[Attn]",MC.NotificationData[0].EmpName),
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
        private Dictionary<string, string> getParametersList(string paraValue)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("prepare_by", AppSessionState.Name);
                result.Add("PrintOption", paraValue);
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
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("prepare_by", AppSessionState.Name);
                //result.Add("PrintOption", paraValue);
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
        private bool validation()
        {
            try
            {
                if (MasterEntity.ind_trade == null || MasterEntity.ind_trade == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Transation Type is Required");
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (MasterEntity.PartyId == null || MasterEntity.PartyId == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Field Sold To Party is Required");
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (MasterEntity.bill_address_id == null || MasterEntity.bill_address_id <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Billing Address is Required");
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (MasterEntity.so_code == null || MasterEntity.so_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Sales Organisation is Required");
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (MasterEntity.sg_code == null || MasterEntity.sg_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Sales Group is Required");
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (MasterEntity.ProdNm == null || MasterEntity.ProdNm == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Product Description Is Not Selected still document is saving \n If you Required Product Description Please Update Later");
                    showMessageService.ShowMessage();

                }
                if (MasterEntity.doc_type == null || MasterEntity.doc_type == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("doc_Type is Required");
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (MasterEntity.doc_date == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("SI date is Required");
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (MasterEntity.post_date == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Post date is Required");
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (MasterEntity.curr_code == null || MasterEntity.curr_code == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Document Currency is Required");
                    showMessageService.ShowMessage();
                    return false;
                }
                else if (MasterEntity.lc_curr == null || MasterEntity.lc_curr == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please enter Your Local Currancy In company Master");
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.curr_code == MasterEntity.lc_curr)
                {
                    MasterEntity.exc_rate = 1;
                    MasterEntity.lc_exc_rate = 1;
                }
                if (MasterEntity.exc_rate == null || MasterEntity.exc_rate <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Exchange Rate is Required");
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.exc_rate != null && MasterEntity.exc_rate > 0)
                {
                    MasterEntity.lc_exc_rate = MasterEntity.exc_rate;
                }
                else if (MasterEntity.order_limit_tax == true)
                {
                    if (MasterEntity.order_limit < MasterEntity.roundup_total)//when form is blank and we save the record
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Invoice value Exceeds Maximum Order value.");
                        showMessageService.ShowMessage();
                        return false;
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
                        return false;
                    }
                }
                else if (ItemsEntity.Count < 1)//when form is blank and we save the record
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
                    GenerateSku();

                    foreach (var o in ItemsEntity)
                    {
                        if (o.ItemCode != null && o.ItemCode != "" && o.item_desc != null)
                        {
                            int flag = 0;
                            if (o.id == 0)
                            {
                                foreach (var p in ItemsEntity)
                                {
                                    if (o.ItemCode == p.ItemCode && (o.sku?.ToString() ?? "") == (p.sku?.ToString() ?? "") && o.para2 == p.para2 && o.para4 == p.para4 && o.para5 == p.para5 && o.id == p.id && o.line_id != p.line_id && o.ref_doc_no == p.ref_doc_no && o.ref_item_row_id == p.ref_item_row_id && o.sd_doc == p.sd_doc && o.sd_row_id == p.sd_row_id && o.sd_line_id == p.sd_line_id)
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
                            else if (o.qty == null || o.qty == 0)
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Quantity cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                                showMessageService.ShowMessage();
                                return false;
                            }
                            else if (o.StockUnt == true)
                            {
                                if (o.para2 == null || o.para2 == "")
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
                                if (o.para4 == null || o.para4 == "")
                                {
                                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                    showMessageService.ButtonSetup = DialogButton.Ok;
                                    showMessageService.Caption = "Message";
                                    showMessageService.Text = String.Format("Please Enter Grade for the item {0} ", o.ItemCode);
                                    showMessageService.ShowMessage();
                                    return false;
                                }
                            }
                            else if (MasterEntity.ind_trade == "D")
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

            }
            return true;
        }
        private void InsertFltrDocType(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M002 POPUPEntityObject = null;
                IEnumerable<SYS_M002> BEType = new List<SYS_M002>();
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
                SEL_T003_P_RefDoc POPUPEntityObject = null;
                string Request;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Sales_Invoice_Reference.Where(x => x.Ref_DocNo.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<SEL_T003_P_RefDoc>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T003_P_RefDoc>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    if (POPUPEntityObject.t_status != "009")
                    {
                        MasterEntity.ref_doc_no = POPUPEntityObject.Ref_DocNo;
                        MasterEntity.ref_doc_cat = POPUPEntityObject.doc_cat;
                        MasterEntity.ref_doc_type = POPUPEntityObject.Ref_DocType;

                        DocumentList = "";
                        if (MasterEntity.ref_doc_cat == "SO")
                        {
                            refdoctempa = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "SO" select o).ToList();
                            ReferenceDocSOCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                            ReferenceDocSOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                            var refdoctempDN = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "DN" select o).ToList();
                            foreach (var item in refdoctempDN)
                            {
                                item.Select = false;
                            }
                            ReferenceDocDNCollection = CollectionViewSource.GetDefaultView(refdoctempDN);
                            ReferenceDocDNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                        }
                        else if (MasterEntity.ref_doc_cat == "DN")
                        {
                            refdoctempa = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "DN" select o).ToList();
                            ReferenceDocDNCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                            ReferenceDocDNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                            var refdoctempSO = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "SO" select o).ToList();
                            foreach (var item in refdoctempSO)
                            {
                                item.Select = false;
                            }
                            ReferenceDocSOCollection = CollectionViewSource.GetDefaultView(refdoctempSO);
                            ReferenceDocSOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                        }
                        var refdoc = from o in refdoctempa
                                     where o.PartyId == POPUPEntityObject.PartyId
                                            && o.PartyNm == POPUPEntityObject.PartyNm
                                            && o.so_code == POPUPEntityObject.so_code
                                            && o.curr_code == POPUPEntityObject.curr_code
                                            && o.bill_address_id == POPUPEntityObject.bill_address_id
                                            && o.doc_cat == POPUPEntityObject.doc_cat
                                            && o.p_term_code == POPUPEntityObject.p_term_code
                                            && o.incoterms == POPUPEntityObject.incoterms
                                            && o.country_code == POPUPEntityObject.country_code
                                            //&& Convert.ToDateTime(o.goods_issue_date).ToString("MM/dd/yyyy") == Convert.ToDateTime(POPUPEntityObject.goods_issue_date).ToString("MM/dd/yyyy")
                                     select o;
                        foreach (var item in refdoc)
                        {
                            if (item.Select == true)
                            {
                                DocumentList = DocumentList + "," + item.Ref_DocNo;
                            }
                        }
                        DocumentList = DocumentList.ToString().TrimStart(new char[] { ',' });
                        if (MasterEntity.ref_doc_cat == "SO")
                        {
                            if (POPUPEntityObject.Select == true)
                            {
                                ReferenceDocSOCollection = CollectionViewSource.GetDefaultView(refdoc);
                                ReferenceDocSOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                            }
                        }
                        else if (MasterEntity.ref_doc_cat == "DN")
                        {
                            if (POPUPEntityObject.Select == true)
                            {
                                ReferenceDocDNCollection = CollectionViewSource.GetDefaultView(refdoc);
                                ReferenceDocDNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
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
            var data = obj as SEL_T003Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_FlipGrid))
                {
                    return (data.bill_doc != null && data.bill_doc.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.sold_to_party_name != null && data.sold_to_party_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
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
            var data = obj as SEL_T003_P_SI_ItemsList;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ItemsListPopup))
                {
                    return (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                           (data.cstmr_itemcode != null && data.cstmr_itemcode.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            (data.cstmr_itemdescr != null && data.cstmr_itemdescr.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            (data.MinQty != null && data.MinQty.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            (data.MaxQty != null && data.MaxQty.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            (data.stock_total != null && data.stock_total.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            (data.Reorder != null && data.Reorder.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower()));
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
            if (_ReferenceDocDNCollection != null)
            {
                _ReferenceDocDNCollection.Refresh();
            }
            if (_ReferenceDocSOCollection != null)
            {
                _ReferenceDocSOCollection.Refresh();
            }
        }
        public bool Filter_ReferenceDoc(object obj)
        {
            var data = obj as SEL_T003_P_RefDoc;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_ReferenceDoc))
                {
                    return (data.Ref_DocNo != null && data.Ref_DocNo.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.Ref_date != null && data.Ref_date.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.PartyNm != null && data.PartyNm.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.doc_cat != null && data.doc_cat.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.PartyId != null && data.PartyId.ToLower().Contains(_FilterString_ReferenceDoc.ToLower())
                       );
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Abstract command Actions
        protected override void OnSaveAction(InquiryActionResult<SEL_T003> result)
        {
            CursorControl.SetBusyState();
            try
            {
                if (MasterEntity.ind_trade == "D")
                {
                    MasterEntity.export_ind = "L";
                }
                else if (MasterEntity.ind_trade == "E")
                {
                    MasterEntity.export_ind = "E";
                }
                else
                {
                    MasterEntity.export_ind = "L";
                }
                if (validation() == true)
                {
                    MasterEntity.editby = AppSessionState.UserID;
                    ExchangeRateCalculation();
                    MasterEntity.XmlDataDocument_SEL_T003_A = obj.ObjectToXML(ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_C = obj.ObjectToXML(TotalDocumentTaxes);
                    this.MasterEntity.EndEdit();

                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<SEL_T003>(MasterEntity, "SalesInvoice", "CRM");
                        if (MasterEntity.bill_doc != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnInsert") >= 0)
                        {
                            NotifyMessage("OnInsert");
                        }
                        if (MasterEntity.bill_doc != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnApproval") >= 0)
                        {
                            NotifyMessage("OnApproval");
                        }
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<SEL_T003>(MasterEntity, "SalesInvoice", "CRM");

                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.bill_doc != null || MasterEntity.bill_doc != "")
                    {

                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record saved Successfully ........");
                        showMessageService.ShowMessage();
                    }
                    isNewRecord = false;
                }
                var msg = new NotificationMessage(ts_code_vm);
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
        protected override void OnCreateAction(InquiryActionResult<SEL_T003> result)
        {
            try
            {
                isNewRecord = true;
                MasterEntity = new SEL_T003();
                MasterEntity.ValidateAsync().Wait();
                ItemsEntity = new ObservableCollection<SEL_T003_A>();
                ItemsEntity.Clear();
                TotalDocumentTaxes = new ObservableCollection<ACC_T006_C>();
                TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_C>();
                TotalDocumentTaxesSummury.Clear();
                ref_doc_cat = "";
                GetSoSgCode();
                TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_C>();
                DefaultValues();

                //var refdoctemp = (from o in MC.doc_typeList where o.doc_type == "CM" || o.doc_type == "SI" select o).ToList();

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M002)x).doc_type);
                //TheFilter = (o, prefix) => ((SYS_M002)o).doc_type.ToString().ToLower().Contains(prefix.ToLower());
                //ASDocType = new AutoSuggestTextViewModel<dynamic>(refdoctemp, TheFilter, SuggestedValue, "doc_type", true);

                MasterEntity.ref_doc_type = "Delivery Note";

                refdoctempa = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "DN" select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P_RefDoc)x).Ref_DocNo);
                TheFilter = (o, prefix) => ((SEL_T003_P_RefDoc)o).Ref_DocNo.ToString().ToLower().Contains(prefix.ToLower());
                ASRef_doc_no = new AutoSuggestTextViewModel<dynamic>(refdoctempa, TheFilter, SuggestedValue, "ref_doc_no", true);

                var msg = new NotificationMessage(ts_code_vm);
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex)
            {

            }
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
                    string response = repository.Delete(MasterEntity.bill_doc, "SalesInvoice", "CRM");

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
                string post_key = MC.doc_typeList.Where(x => x.doc_type == MasterEntity.doc_type).ToList()[0].posting_key;
                //object[] obj = new { MasterEntity, ItemsEntity, TotalDocumentTaxes, post_key };
                object objParam = MasterEntity.bill_doc;
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
        protected override void OnFevoriteAction(InquiryActionResult<SEL_T003> result)
        {
            try
            {
                if (MasterEntity.bill_doc != null && MasterEntity.bill_doc != "")
                {
                    if (MasterEntity.t_status != "017")
                    {
                        string Request = "ValidateInvoice" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.bill_doc + "!@" + AppSessionState.UserID;
                        //string Request = "ValidateInvoice" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.client + "!@" + MasterEntity.bill_doc;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MCTemp, Request, "SalesInvoice", "CRM", "LoadAll", 0, "");

                        if (MCTemp.MasterEntity.Count > 0)
                        {
                            if (MCTemp.MasterEntity[0].t_status == "017")
                            {
                                MasterEntity.t_status = MCTemp.MasterEntity[0].t_status;
                                MasterEntity.t_display = (from o in MC.STATUS_LIST where o.t_status == MasterEntity.t_status select o.t_display).FirstOrDefault();
                                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Invoice Validate Succesfully...", this.Title); sms.ShowMessage();
                            }
                        }
                    }
                    else if (MasterEntity.t_status == "017")
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
                string post_key = MC.doc_typeList.Where(x => x.doc_type == MasterEntity.doc_type).ToList()[0].posting_key;
                //object[] obj = new { MasterEntity, ItemsEntity, TotalDocumentTaxes, post_key };
                object objParam = MasterEntity.bill_doc;
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
        protected override void OnHelpAction(InquiryActionResult<SEL_T003> result)
        {

        }
        public void Calculate_AmtTaxWord()
        {
            decimal? amt_sum_tax = 0;
            amt_sum_tax = MCTemp.TaxEntity.Where(item => item.active != false).Sum(item => item.tax_amount);
            if (amt_sum_tax > 0)
            {
                ADM_M037 curr_obj = new ADM_M037();
                curr_obj = ((List<ADM_M037>)AppSessionState.CurrencyList).Where(x => x.curr_code == MasterEntity.curr_code).ToList()[0];
                MCTemp.RptSalesInvoice[0].amt_word_tax = num.AmountInWords(Convert.ToDecimal(amt_sum_tax), "", "", "", "");
            }
            else
            {
                MCTemp.RptSalesInvoice[0].amt_word_tax = "";
            }

        }
        protected override void OnPrintAction(InquiryActionResult<SEL_T003> result)
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "SI_Report" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.bill_doc;
                //string Request = "SI_Report" + "!@" + MasterEntity.bill_doc + "!@" + "" + "!@" + MasterEntity.doc_cat;
                string ReportName = "";
                //string ReportString = "";

                MasterEntity.doc_desc = "SalesInvoice";

                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MC, Request, "SalesInvoice", "CRM", "LoadAll", 0, "");
                Calculate_AmtTaxWord();

                object[] objDataSource = new object[5];
                string[] objDataSourceName = new string[5];


                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[0] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[1] = Result;

                objDataSource[2] = MCTemp.RptSalesInvoice;
                objDataSource[3] = MCTemp.RptSalesInvoiceItem;
                objDataSource[4] = MCTemp.TaxEntity;

                objDataSourceName[0] = "dsCompany";
                objDataSourceName[1] = "dsLocation";
                objDataSourceName[2] = "dsRptSalesInvoice";
                objDataSourceName[3] = "dsRptSalesInvoiceItem";
                objDataSourceName[4] = "dsRptSalesInvoiceTax";

                ReportManager ReportManager = new ReportManager();

                var ReportStringList = (from o in MC.doc_typeList where o.doc_type == MasterEntity.doc_type select o).ToList();
                if (MasterEntity.doc_cat == "EI")
                {
                    if (MasterEntity.export_ind == "E")
                    {
                        ReportName = ReportStringList[0].report_name.Split(',')[0];
                    }

                }
                else if (MasterEntity.doc_type == "CM")
                {
                    ReportName = ReportStringList[0].report_name.Split(',')[0];
                }
                else if (MasterEntity.doc_type == "FS")
                {
                    ReportName = ReportStringList[0].report_name.Split(',')[0];
                }
                else if (MasterEntity.doc_type == "SZ")
                {
                    ReportName = ReportStringList[0].report_name.Split(',')[0];
                }
                else if (MasterEntity.doc_type == "ES")
                {
                    ReportName = ReportStringList[0].report_name.Split(',')[0];
                }
                else if (MasterEntity.doc_type == "SI")
                {
                    if (MasterEntity.export_ind == "E")
                    {

                        ReportName = ReportStringList[0].report_name.Split(',')[1];
                    }

                    else if (MasterEntity.export_ind == "L")
                    {
                        ReportName = ReportStringList[0].report_name.Split(',')[0];
                    }
                }
                string ReportDisplayName = MasterEntity.sold_to_party_name + "_" + MasterEntity.bill_doc + "_" + MasterEntity.doc_date.Value.ToShortDateString();
                if (MasterEntity.PrintOption != null && MasterEntity.PrintOption != "")
                {
                    string Temp = MasterEntity.PrintOption;
                    string[] Temp2 = Temp.Split(',');
                    for (int i = 0; i < Temp2.Length; i++)
                    {
                        Temp2[i] = Temp2[i].Trim();
                    }
                    foreach (var item in Temp2)
                    {
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, getParametersList(item), ReportDisplayName);
                    }
                }
                else
                {
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, getParametersList(), ReportDisplayName);
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void GetSoSgCode()
        {
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
                if (!string.IsNullOrWhiteSpace(MasterEntity.bill_doc))
                {
                    string Request = "SI_Report" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.bill_doc;
                    //string Request = "SI_Report" + "!@" + MasterEntity.bill_doc;

                    MasterEntity.doc_desc = "SalesInvoice";
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MC, Request, "SalesInvoice", "CRM", "LoadAll", 0, "");

                    object[] objDataSource = new object[5];
                    string[] objDataSourceName = new string[5];


                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[0] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[1] = Result;

                    objDataSource[2] = MCTemp.RptSalesInvoice;
                    objDataSource[3] = MCTemp.RptSalesInvoiceItem;
                    objDataSource[4] = MCTemp.TaxEntity;

                    objDataSourceName[0] = "dsCompany";
                    objDataSourceName[1] = "dsLocation";
                    objDataSourceName[2] = "dsRptSalesInvoice";
                    objDataSourceName[3] = "dsRptSalesInvoiceItem";
                    objDataSourceName[4] = "dsRptSalesInvoiceTax";

                    ReportManager ReportManager = new ReportManager();
                    var SystemDocumentObject = (from o in MC.doc_typeList where o.doc_cat == MasterEntity.doc_cat select o).ToList();

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
                        DisplaytName = MasterEntity.doc_desc + "_" + MasterEntity.bill_doc.Replace(@"/", "-").Replace(@"\", "-") + "_" + MasterEntity.doc_date.Value.Date.ToShortDateString().Replace(@"/", string.Empty).Replace(@"\", string.Empty);
                        MessageData = "<h3>Commercial Document for RFQ!</h3><p>Dear Sir!</p><p>Please find attached herewith commercial document for Sales Invoice as per your requirements. </p><p>-" + AppSessionState.CompanyName + "</p>";

                        ReportManager.Mail(To, Cc, Bcc, objDataSource, objDataSourceName, null, "\\CRM\\" + ReportName, DisplaytName, "Sales Invoice Prepared against RFQ By " + AppSessionState.CompanyName, MessageData, "", ".pdf");

                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Mail Sent Successfully...", this.Title);
                        showMessageService.ShowMessage();
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void PrintChallan(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                string ReportName = "";
                if (MasterEntity.comp_code == "1")
                {
                    //string Request = "DN_Report" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.ref_doc_no;
                    string Request = "DN_Report" + "!@" + MasterEntity.ref_doc_no;
                    MCTemp2 = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp2, "LOG_T001_A_Data", "DeliveryNote", "SCM", "LoadAll", 0, Request);
                }
                else
                {
                    string Request = "DN_Report" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.ref_doc_no;
                    //string Request = "DN_Report" + "!@" + MasterEntity.ref_doc_no;
                    MCTemp2 = repositoryM.GetDataWithReturnDomainObject<MultipleContext_LOG_T001_A>(MCTemp2, "LOG_T001_A_Data", "DeliveryNoteSTD", "SCM", "LoadAll", 0, Request);
                }
                object[] objDataSource = new object[3];
                string[] objDataSourceName = new string[3];

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[0] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[1] = Result;

                objDataSource[2] = MCTemp2.RptDeliveryNoteList;

                objDataSourceName[0] = "dsCompany";
                objDataSourceName[1] = "dsLocation";
                objDataSourceName[2] = "dsRptDeliveryNote";

                if (MasterEntity.ref_doc_cat == "DC")
                {
                    ReportName = MC.DocCategoryList[0].report_name;
                }
                else if (MasterEntity.ref_doc_cat == "DN")
                {
                    ReportName = MC.DocCategoryList[1].report_name;
                }
                ReportManager ReportManager = new ReportManager();
                if (MasterEntity.PrintOption != null && MasterEntity.PrintOption != "")
                {
                    string Temp = MasterEntity.PrintOption;
                    string[] Temp2 = Temp.Split(',');
                    for (int i = 0; i < Temp2.Length; i++)
                    {
                        Temp2[i] = Temp2[i].Trim();
                    }
                    foreach (var item in Temp2)
                    {
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, getParametersList(item), ReportName);
                    }
                }
                else
                {
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, getParametersList(), ReportName);
                }
            }
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
                string Grade = "";
                string Ink = "";
                string Ild = "";

                foreach (var o in ItemsEntity)
                {
                    if (o.id == 0 && o.StockUnt == true)
                    {
                        Grade = "";
                        Ink = "";
                        Ild = "";

                        if (MC.ParamValueList.Count > 0 && o.para4 != null && o.para4 != "" && o.para2 != null && o.para2 != "" && o.para5 != null && o.para5 != "")
                        {
                            Grade = MC.ParamValueList.Where(X => X.parametervalue.Trim() == o.para4.Trim() && X.para_code == "1004").Select(x => x.value_code).FirstOrDefault();

                            Ink = MC.ParamValueList.Where(X => X.parametervalue.Trim() == o.para2.Trim() && X.para_code == "1005").Select(x => x.value_code).FirstOrDefault();
                            Ild = MC.ParamValueList.Where(X => X.parametervalue.Trim() == o.para5.Trim() && X.para_code == "1006").Select(x => x.value_code).FirstOrDefault();

                            o.sku = Grade + "/" + Ink + "/" + Ild;
                            o.sku_desc = "Grade:" + o.para4 + "\t" + "Ink:" + o.para2 + "\t" + "Ild:" + o.para5;
                            foreach (var N in TotalDocumentTaxes)
                            {
                                if (N.ItemCode == o.ItemCode)
                                {
                                    N.sku = o.sku;
                                }
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
        private void ExchangeRateCalculation()
        {
            try
            {
                if (ItemsEntity.Count > 0 && dgSelectedIndexItem != -1)
                {
                    for (int i = 0; i < ItemsEntity.Count; i++)
                    {
                        ItemsEntity[i].loc_rate = ItemsEntity[i].unit_price * MasterEntity.exc_rate;
                        ItemsEntity[i].loc_amt = ItemsEntity[i].loc_rate * ItemsEntity[i].qty;
                        ItemsEntity[i].exch_rate = MasterEntity.exc_rate;
                        ItemsEntity[i].lc_exch_rate = MasterEntity.lc_exc_rate;
                        ItemsEntity[i].curr_code = MasterEntity.curr_code;
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
        protected override void OnDocumentAction()
        {
            try
            {
                CursorControl.SetBusyState();
                if (!string.IsNullOrEmpty(MasterEntity.bill_doc))
                {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.bill_doc.Replace("/", "--"), DocumentList = MCTemp.Attachment, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<SEL_T003> result)
        {
            string Request = "Refresh" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + (MasterEntity.doc_cat ?? this.doc_cat_vm) + "!@" + (MasterEntity.doc_type ?? doc_cat_vm) + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + this.ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code;
            //string Request = "Refresh" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + "PI,CI,SI" + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.client;
            MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T003>(MCTemp, Request, "SalesInvoice", "CRM", "", 0, "LoadAll");
            SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P_SI_ItemsList)x).ItemCode);
            MC.Sales_Invoice_Reference = MCTemp.Sales_Invoice_Reference;
            var refdoctempa1 = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "SO" || o.doc_cat == "DN" || o.doc_cat == "PI" || o.doc_cat == "CI" || o.doc_cat == "DC" select o).ToList();
            MasterEntity.ref_doc_type = "Delivery Note";
            SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_P_RefDoc)x).Ref_DocNo);
            TheFilter = (o, prefix) => ((SEL_T003_P_RefDoc)o).Ref_DocNo.ToString().ToLower().Contains(prefix.ToLower());
            ASRef_doc_no = new AutoSuggestTextViewModel<dynamic>(refdoctempa1, TheFilter, SuggestedValue, "ref_doc_no", true);
            ASRef_doc_no.AutoSuggestVM.IsEmptyValueAllowed = true;



            var refdoc = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "SO" select o).ToList();

            ReferenceDocSOCollection = CollectionViewSource.GetDefaultView(refdoc);
            ReferenceDocSOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

            refdoc = (from o in MC.Sales_Invoice_Reference where o.doc_cat == "DN" select o).ToList();

            ReferenceDocDNCollection = CollectionViewSource.GetDefaultView(refdoc);
            ReferenceDocDNCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<SEL_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<SEL_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<SEL_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<SEL_T003> result)
        {
            throw new NotImplementedException();
        }


        #endregion
    }
}