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
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.FICO;
using Reflection.BusinessEntity.Account;
using Reflection.BusinessEntity.PMS;
using Reflection.BusinessEntity.GEN;
using System.Reflection;
using GalaSoft.MvvmLight.Ioc;
using Reflection.Presentation.Core.VirtualDesktops;
using Reflection.BusinessEntity.COM;

namespace Reflection.Modules.SDM.ViewModels
{
    public class SDM_T005_VM : WorkspaceViewModel<SEL_T001>
    {
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SDM_T005_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private IEnumerable _SUPPLIER_LIST { get; set; }
        public IEnumerable SUPPLIER_LIST
        {
            get { return _SUPPLIER_LIST; }
            set
            {
                if (_SUPPLIER_LIST != value)
                {
                    _SUPPLIER_LIST = value; RaisePropertyChanged("SUPPLIER_LIST");
                }
            }
        }
        private IEnumerable _PRICE_LIST { get; set; }
        public IEnumerable PRICE_LIST
        {
            get { return _PRICE_LIST; }
            set
            {
                if (_PRICE_LIST != value)
                {
                    _PRICE_LIST = value; RaisePropertyChanged("PRICE_LIST");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_DEFAULT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DEFAULT
        {
            get { return _AS_DEFAULT; }
            set
            {
                if (_AS_DEFAULT != value)
                {
                    _AS_DEFAULT = value; RaisePropertyChanged("AS_DEFAULT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_DEFAULT_1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DEFAULT_1
        {
            get { return _AS_DEFAULT_1; }
            set
            {
                if (_AS_DEFAULT_1 != value)
                {
                    _AS_DEFAULT_1 = value; RaisePropertyChanged("AS_DEFAULT_1");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_DEFAULT_2 { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DEFAULT_2
        {
            get { return _AS_DEFAULT_2; }
            set
            {
                if (_AS_DEFAULT_2 != value)
                {
                    _AS_DEFAULT_2 = value; RaisePropertyChanged("AS_DEFAULT_2");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_DEFAULT_3 { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DEFAULT_3
        {
            get { return _AS_DEFAULT_3; }
            set
            {
                if (_AS_DEFAULT_3 != value)
                {
                    _AS_DEFAULT_3 = value; RaisePropertyChanged("AS_DEFAULT_3");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_DEFAULT_4 { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DEFAULT_4
        {
            get { return _AS_DEFAULT_4; }
            set
            {
                if (_AS_DEFAULT_4 != value)
                {
                    _AS_DEFAULT_4 = value; RaisePropertyChanged("AS_DEFAULT_4");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_DEFAULT_5 { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DEFAULT_5
        {
            get { return _AS_DEFAULT_5; }
            set
            {
                if (_AS_DEFAULT_5 != value)
                {
                    _AS_DEFAULT_5 = value; RaisePropertyChanged("AS_DEFAULT_5");
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
        private AutoSuggestTextViewModel<dynamic> _AS_TRADE_INDICATOR { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_TRADE_INDICATOR
        {
            get { return _AS_TRADE_INDICATOR; }
            set
            {
                if (_AS_TRADE_INDICATOR != value)
                {
                    _AS_TRADE_INDICATOR = value; RaisePropertyChanged("AS_TRADE_INDICATOR");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_UOM_PRICE_QTY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM_PRICE_QTY
        {
            get { return _AS_UOM_PRICE_QTY; }
            set
            {
                if (_AS_UOM_PRICE_QTY != value)
                {
                    _AS_UOM_PRICE_QTY = value; RaisePropertyChanged("AS_UOM_PRICE_QTY");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_LINE_CATEGORY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_LINE_CATEGORY
        {
            get { return _AS_LINE_CATEGORY; }
            set
            {
                if (_AS_LINE_CATEGORY != value)
                {
                    _AS_LINE_CATEGORY = value; RaisePropertyChanged("AS_LINE_CATEGORY");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_DOC_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DOC_TYPE
        {
            get { return _AS_DOC_TYPE; }
            set
            {
                if (_AS_DOC_TYPE != value)
                {
                    _AS_DOC_TYPE = value; RaisePropertyChanged("AS_DOC_TYPE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_SOLD_TO_PARTY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_SOLD_TO_PARTY
        {
            get { return _AS_SOLD_TO_PARTY; }
            set
            {
                if (_AS_SOLD_TO_PARTY != value)
                {
                    _AS_SOLD_TO_PARTY = value; RaisePropertyChanged("AS_SOLD_TO_PARTY");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_SHIP_TO_PARTY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_SHIP_TO_PARTY
        {
            get { return _AS_SHIP_TO_PARTY; }
            set
            {
                if (_AS_SHIP_TO_PARTY != value)
                {
                    _AS_SHIP_TO_PARTY = value; RaisePropertyChanged("AS_SHIP_TO_PARTY");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_COMPETITOR { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_COMPETITOR
        {
            get { return _AS_COMPETITOR; }
            set
            {
                if (_AS_COMPETITOR != value)
                {
                    _AS_COMPETITOR = value; RaisePropertyChanged("AS_COMPETITOR");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_CURRENCY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CURRENCY
        {
            get { return _AS_CURRENCY; }
            set
            {
                if (_AS_CURRENCY != value)
                {
                    _AS_CURRENCY = value; RaisePropertyChanged("AS_CURRENCY");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_SALESMAN { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_SALESMAN
        {
            get { return _AS_SALESMAN; }
            set
            {
                if (_AS_SALESMAN != value)
                {
                    _AS_SALESMAN = value; RaisePropertyChanged("AS_SALESMAN");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_INCOTERMS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_INCOTERMS
        {
            get { return _AS_INCOTERMS; }
            set
            {
                if (_AS_INCOTERMS != value)
                {
                    _AS_INCOTERMS = value; RaisePropertyChanged("AS_INCOTERMS");
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
        private AutoSuggestTextViewModel<dynamic> _AS_TAX_CONDITION_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_TAX_CONDITION_TYPE
        {
            get { return _AS_TAX_CONDITION_TYPE; }
            set
            {
                if (_AS_TAX_CONDITION_TYPE != value)
                {
                    _AS_TAX_CONDITION_TYPE = value; RaisePropertyChanged("AS_TAX_CONDITION_TYPE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_PAY_TERMS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PAY_TERMS
        {
            get { return _AS_PAY_TERMS; }
            set
            {
                if (_AS_PAY_TERMS != value)
                {
                    _AS_PAY_TERMS = value; RaisePropertyChanged("AS_PAY_TERMS");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_UOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM
        {
            get { return _AS_UOM; }
            set
            {
                if (_AS_UOM != value)
                {
                    _AS_UOM = value; RaisePropertyChanged("AS_UOM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_STATUS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_STATUS
        {
            get { return _AS_STATUS; }
            set
            {
                if (_AS_STATUS != value)
                {
                    _AS_STATUS = value; RaisePropertyChanged("AS_STATUS");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_NOTIFY_PARTY_1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_NOTIFY_PARTY_1
        {
            get { return _AS_NOTIFY_PARTY_1; }
            set
            {
                if (_AS_NOTIFY_PARTY_1 != value)
                {
                    _AS_NOTIFY_PARTY_1 = value; RaisePropertyChanged("AS_NOTIFY_PARTY_1");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_NOTIFY_PARTY_2 { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_NOTIFY_PARTY_2
        {
            get { return _AS_NOTIFY_PARTY_2; }
            set
            {
                if (_AS_NOTIFY_PARTY_2 != value)
                {
                    _AS_NOTIFY_PARTY_2 = value; RaisePropertyChanged("AS_NOTIFY_PARTY_2");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_REF_PARTY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_REF_PARTY
        {
            get { return _AS_REF_PARTY; }
            set
            {
                if (_AS_REF_PARTY != value)
                {
                    _AS_REF_PARTY = value; RaisePropertyChanged("AS_REF_PARTY");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_SUPPLIER { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_SUPPLIER
        {
            get { return _AS_SUPPLIER; }
            set
            {
                if (_AS_SUPPLIER != value)
                {
                    _AS_SUPPLIER = value; RaisePropertyChanged("AS_SUPPLIER");
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
        private AutoSuggestTextViewModel<dynamic> _AS_ORG { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ORG
        {
            get { return _AS_ORG; }
            set
            {
                if (_AS_ORG != value)
                {
                    _AS_ORG = value; RaisePropertyChanged("AS_ORG");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ORG_GROUP { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ORG_GROUP
        {
            get { return _AS_ORG_GROUP; }
            set
            {
                if (_AS_ORG_GROUP != value)
                {
                    _AS_ORG_GROUP = value; RaisePropertyChanged("AS_ORG_GROUP");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_TR_MODE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_TR_MODE
        {
            get { return _AS_TR_MODE; }
            set
            {
                if (_AS_TR_MODE != value)
                {
                    _AS_TR_MODE = value; RaisePropertyChanged("AS_TR_MODE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_HB_ACC { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_HB_ACC
        {
            get { return _AS_HB_ACC; }
            set
            {
                if (_AS_HB_ACC != value)
                {
                    _AS_HB_ACC = value; RaisePropertyChanged("AS_HB_ACC");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_LICENCE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_LICENCE
        {
            get { return _AS_LICENCE; }
            set
            {
                if (_AS_LICENCE != value)
                {
                    _AS_LICENCE = value; RaisePropertyChanged("AS_LICENCE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_TAX_ACCOUNT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_TAX_ACCOUNT
        {
            get { return _AS_TAX_ACCOUNT; }
            set
            {
                if (_AS_TAX_ACCOUNT != value)
                {
                    _AS_TAX_ACCOUNT = value; RaisePropertyChanged("AS_TAX_ACCOUNT");
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
        private AutoSuggestTextViewModel<dynamic> _AS_BUYER { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_BUYER
        {
            get { return _AS_BUYER; }
            set
            {
                if (_AS_BUYER != value)
                {
                    _AS_BUYER = value; RaisePropertyChanged("AS_BUYER");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_BILLING_ADDRESS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_BILLING_ADDRESS
        {
            get { return _AS_BILLING_ADDRESS; }
            set
            {
                if (_AS_BILLING_ADDRESS != value)
                {
                    _AS_BILLING_ADDRESS = value; RaisePropertyChanged("AS_BILLING_ADDRESS");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_SHIPPING_ADDRESS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_SHIPPING_ADDRESS
        {
            get { return _AS_SHIPPING_ADDRESS; }
            set
            {
                if (_AS_SHIPPING_ADDRESS != value)
                {
                    _AS_SHIPPING_ADDRESS = value; RaisePropertyChanged("AS_SHIPPING_ADDRESS");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_REF_PARTY_PERSON { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_REF_PARTY_PERSON
        {
            get { return _AS_REF_PARTY_PERSON; }
            set
            {
                if (_AS_REF_PARTY_PERSON != value)
                {
                    _AS_REF_PARTY_PERSON = value; RaisePropertyChanged("AS_REF_PARTY_PERSON");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ELEMENT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ELEMENT
        {
            get { return _AS_ELEMENT; }
            set
            {
                if (_AS_ELEMENT != value)
                {
                    _AS_ELEMENT = value; RaisePropertyChanged("AS_ELEMENT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_PFCODE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PFCODE
        {
            get { return _AS_PFCODE; }
            set
            {
                if (_AS_PFCODE != value)
                {
                    _AS_PFCODE = value; RaisePropertyChanged("AS_PFCODE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_PF_PARTY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PF_PARTY
        {
            get { return _AS_PF_PARTY; }
            set
            {
                if (_AS_PF_PARTY != value)
                {
                    _AS_PF_PARTY = value; RaisePropertyChanged("AS_PF_PARTY");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_PFEMPLOYEE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PFEMPLOYEE
        {
            get { return _AS_PFEMPLOYEE; }
            set
            {
                if (_AS_PFEMPLOYEE != value)
                {
                    _AS_PFEMPLOYEE = value; RaisePropertyChanged("AS_PFEMPLOYEE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_PF_ADDRESS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PF_ADDRESS
        {
            get { return _AS_PF_ADDRESS; }
            set
            {
                if (_AS_PF_ADDRESS != value)
                {
                    _AS_PF_ADDRESS = value; RaisePropertyChanged("AS_PF_ADDRESS");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_BILLING_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_BILLING_TYPE
        {
            get { return _AS_BILLING_TYPE; }
            set
            {
                if (_AS_BILLING_TYPE != value)
                {
                    _AS_BILLING_TYPE = value; RaisePropertyChanged("AS_BILLING_TYPE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_DATE_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DATE_TYPE
        {
            get { return _AS_DATE_TYPE; }
            set
            {
                if (_AS_DATE_TYPE != value)
                {
                    _AS_DATE_TYPE = value; RaisePropertyChanged("AS_DATE_TYPE");
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
                    { AS_DEFAULT = AS_ITEM; }
                    else if (SourceName == "unit_code")
                    { AS_DEFAULT = AS_UOM; }
                    else if (SourceName == "price_qty_uom")
                    { AS_DEFAULT = AS_UOM_PRICE_QTY; }
                    else if (SourceName == "item_cat")
                    { AS_DEFAULT = AS_LINE_CATEGORY; }
                    else if (SourceName == "PartyNm")
                    { AS_DEFAULT_3 = AS_SUPPLIER; }
                    else if (SourceName == "ship_to_PartyNm")
                    { AS_DEFAULT_3 = AS_SHIP_TO_PARTY; }
                    else if (SourceName == "ship_to_addNm")
                    {
                        AS_DEFAULT_3 = AS_SHIPPING_ADDRESS;
                        FilterScheduleShipToAdd();
                    }
                    else if (SourceName == "Termscon_type")
                    { AS_DEFAULT_2 = AS_TERMS_CONDITION; }
                    else if (SourceName == "con_type")
                    { AS_DEFAULT_1 = AS_TAX_CONDITION_TYPE; }
                    else if (SourceName == "order_to_plant")
                    { AS_DEFAULT = AS_LOCATION; }
                    else if (SourceName == "curr_code")
                    { AS_DEFAULT_1 = AS_CURRENCY; }
                    else if (SourceName == "gl_code")
                    { AS_DEFAULT_1 = AS_TAX_ACCOUNT; }
                    else if (SourceName == "licence_no")
                    { AS_DEFAULT_4 = AS_LICENCE; }
                    else if (SourceName == "tr_mode")
                    { AS_DEFAULT_4 = AS_TR_MODE; }
                    else if (SourceName == "incoterms")
                    { AS_DEFAULT_4 = AS_INCOTERMS; }
                    else if (SourceName == "ship_to_Party")
                    { AS_DEFAULT = AS_SHIP_TO_PARTY; }
                    else if (SourceName == "pf_code")
                    { AS_DEFAULT_5 = AS_PFCODE; }
                    else if (SourceName == "pf_party_code")
                    { AS_DEFAULT_5 = AS_PF_PARTY; }
                    else if (SourceName == "pf_emp_id")
                    { AS_DEFAULT_5 = AS_PFEMPLOYEE; }
                    else if (SourceName == "pf_add_code")
                    { AS_DEFAULT_5 = AS_PF_ADDRESS; }

                }
            }
        }
        #endregion
        #region Variable Declaration
        string PartyEmailId = "";
        string PersonEmailId = "";
        string PreviousUnitCode = "";
        string NewUnitCode = "";
        string default_tax = null;
        decimal? unit_price;
        private bool AutoRoundupEnable = true;
        private int RoundUpDecimals = 2;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }
        public string doc_type_vm { get; set; }

        IShowMessageViewService sms;
        NUMBER_TO_WORDS_CONVERTER NOW_OBJ = new NUMBER_TO_WORDS_CONVERTER();
        WebServiceRepository<SEL_T001> repository = new WebServiceRepository<SEL_T001>();
        WebServiceRepository<MC_SDM_BE> repository_MC = new WebServiceRepository<MC_SDM_BE>();
        WebServiceRepository<MC_SDM_BE> repository_MCTemp = new WebServiceRepository<MC_SDM_BE>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private STD_LIST_BE _STD_LIST_OBJ;
        public STD_LIST_BE STD_LIST_OBJ
        {
            get { return _STD_LIST_OBJ; }
            set
            {
                if (_STD_LIST_OBJ != value)
                {
                    _STD_LIST_OBJ = value;
                    RaisePropertyChanged("STD_LIST_OBJ");
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
        private MC_SDM_BE _MC = new MC_SDM_BE();
        public MC_SDM_BE MC
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
        private MC_SDM_BE _MCTemp = new MC_SDM_BE();
        public MC_SDM_BE MCTemp
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
        private STD_ITEM _STD_ITEM_OBJ;
        public STD_ITEM STD_ITEM_OBJ
        {
            get { return _STD_ITEM_OBJ; }
            set
            {
                if (_STD_ITEM_OBJ != value)
                {
                    _STD_ITEM_OBJ = value;

                    RaisePropertyChanged("STD_ITEM_OBJ");
                }
            }
        }
        private STD_REQ_PARA_BE _REQUEST_PARA_OBJ;
        public STD_REQ_PARA_BE REQUEST_PARA_OBJ
        {
            get { return _REQUEST_PARA_OBJ; }
            set
            {
                if (_REQUEST_PARA_OBJ != value)
                {
                    _REQUEST_PARA_OBJ = value;

                    RaisePropertyChanged("REQUEST_PARA_OBJ");
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
        private SEL_T001_PART _PFEntityObject;
        public SEL_T001_PART PFEntityObject
        {
            get
            {
                return _PFEntityObject;
            }
            set
            {
                if (_PFEntityObject != value)
                {
                    _PFEntityObject = value;
                    RaisePropertyChanged("PFEntityObject");
                }
            }
        }

        private List<COM_T011> _ReleaseList;
        public List<COM_T011> ReleaseList
        {
            get
            {
                return _ReleaseList;
            }
            set
            {
                if (_ReleaseList != value)
                {
                    _ReleaseList = value;
                    RaisePropertyChanged("ReleaseList");
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
                //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }

        }
        private int _TabIndexItem;
        public int TabIndexItem
        {
            get { return _TabIndexItem; }
            set
            {
                if (_TabIndexItem != value)
                {
                    _TabIndexItem = value;
                    RaisePropertyChanged("TabIndexItem");
                }
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
        //// Selected Index for Items DataGrid
        //private int _dgSelectedIndexItem;
        //public int dgSelectedIndexItem
        //{
        //    get
        //    {
        //        return _dgSelectedIndexItem;
        //    }
        //    set
        //    {
        //        if (_dgSelectedIndexItem != value)
        //        {

        //            _dgSelectedIndexItem = value;
        //            RaisePropertyChanged("dgSelectedIndexItem");
        //            FilterScheduleDataGrid();
        //            FilterLicenceDataGrid();
        //            if (TotalDocumentTaxesItem.Count > 0 && ItemEntityObject != null) // NOTE: add Line Id code only.
        //            {
        //                TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>(TotalDocumentTaxes.Where(tax => tax.ItemCode == ItemEntityObject.ItemCode && (tax.sku?.ToString() ?? "") == (ItemEntityObject.sku?.ToString() ?? "") && tax.item_row_id == ItemEntityObject.id));
        //            }
        //        }
        //    }
        //}
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
        private ObservableCollection<SEL_T001_PART> _PartnerEntity;
        public ObservableCollection<SEL_T001_PART> PartnerEntity
        {
            get
            {
                return _PartnerEntity;
            }
            set
            {
                if (_PartnerEntity != value)
                {
                    _PartnerEntity = value;
                    PartnerEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForPartner);
                    RaisePropertyChanged("PartnerEntity");
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

        private ObservableCollection<ACC_T021> _BillingPlanEntity;
        public ObservableCollection<ACC_T021> BillingPlanEntity
        {
            get
            {
                return _BillingPlanEntity;
            }
            set
            {
                if (_BillingPlanEntity != value)
                {
                    _BillingPlanEntity = value; RaisePropertyChanged("BillingPlanEntity");
                }
            }
        }

        #endregion
        #region List // Collection to show previous pricing,Quality Issues, dispatch and project history. Old BE was GetItemDetailsEntity and collection object was SalesUnitPriceCollection, SalesQFRCollection, SalesDispatchCollection, SalesProjDispatchCollection
        private List<STD_LIST_BE> _PRICE_HISTORY_COLLECTION;
        public List<STD_LIST_BE> PRICE_HISTORY_COLLECTION
        {
            get { return _PRICE_HISTORY_COLLECTION; }
            set { _PRICE_HISTORY_COLLECTION = value; RaisePropertyChanged("PRICE_HISTORY_COLLECTION"); }
        }
        private List<STD_LIST_BE> _QMS_HISTORY_COLLECTION;
        public List<STD_LIST_BE> QMS_HISTORY_COLLECTION
        {
            get { return _QMS_HISTORY_COLLECTION; }
            set { _QMS_HISTORY_COLLECTION = value; RaisePropertyChanged("QMS_HISTORY_COLLECTION"); }
        }
        private List<STD_LIST_BE> _DISPATCH_HISTORY_COLLECTION;
        public List<STD_LIST_BE> DISPATCH_HISTORY_COLLECTION
        {
            get { return _DISPATCH_HISTORY_COLLECTION; }
            set { _DISPATCH_HISTORY_COLLECTION = value; RaisePropertyChanged("DISPATCH_HISTORY_COLLECTION"); }
        }
        private List<STD_LIST_BE> _PROJECTION_COLLECTION;
        public List<STD_LIST_BE> PROJECTION_COLLECTION
        {
            get { return _PROJECTION_COLLECTION; }
            set { _PROJECTION_COLLECTION = value; RaisePropertyChanged("PROJECTION_COLLECTION"); }
        }
        private List<ADM_M0071> _ParameterTemp = new List<ADM_M0071>();
        public List<ADM_M0071> ParameterTemp
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
        private List<ACC_M013> _SelectedTaxList;
        // Supporting for Filter Data Source for Parent Taxes. * can be remove.
        public List<ACC_M013> SelectedTaxList
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
        private IEnumerable _TASK_LIST;
        public IEnumerable TASK_LIST
        {
            get { return _TASK_LIST; }
            set
            {
                _TASK_LIST = value;

                RaisePropertyChanged("TASK_LIST");
            }
        }
        private IEnumerable _LOCATION_LIST;
        public IEnumerable LOCATION_LIST
        {
            get { return _LOCATION_LIST; }
            set
            {
                _LOCATION_LIST = value;

                RaisePropertyChanged("LOCATION_LIST");
            }
        }
        #endregion
        #region ICollection for Popup Control

        private IEnumerable _PROJECT_LIST;
        public IEnumerable PROJECT_LIST
        {
            get { return _PROJECT_LIST; }
            set { _PROJECT_LIST = value; RaisePropertyChanged("PROJECT_LIST"); }
        }

        private IEnumerable _ASSET_LIST;
        public IEnumerable ASSET_LIST
        {
            get { return _ASSET_LIST; }
            set { _ASSET_LIST = value; RaisePropertyChanged("ASSET_LIST"); }
        }

        private ICollectionView _REF_DOC_COLLECTION;
        public ICollectionView REF_DOC_COLLECTION
        {
            get { return _REF_DOC_COLLECTION; }
            set { _REF_DOC_COLLECTION = value; RaisePropertyChanged("REF_DOC_COLLECTION"); }
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
        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }
        private ICollectionView _ITEM_COLLECTION;
        public ICollectionView ITEM_COLLECTION
        {
            get { return _ITEM_COLLECTION; }
            set { _ITEM_COLLECTION = value; RaisePropertyChanged("ITEM_COLLECTION"); }
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

        public RelayCommand<object> cmdInsertSupplier { get; private set; }
        public RelayCommand<object> cmdInsertPartner { get; private set; }
        public RelayCommand<object> cmdInsertPFAddress { get; private set; }
        public RelayCommand<object> cmdInsertPFEmployee { get; private set; }
        public RelayCommand<object> cmdInsertPFCode { get; private set; }
        public RelayCommand<object> cmdInsertPFParty { get; private set; }
        public RelayCommand<object> cmdSelectionChangedPartner { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_SEL_T001_A { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_SEL_T001_E { get; private set; }
        public RelayCommand<object> cmdSelectionChangedSchedule { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdTR_Mode { get; private set; }
        public RelayCommand<object> cmdTR_ModeMaster { get; private set; }
        
        
        public RelayCommand<object> cmdInsertQty { get; private set; }
        public RelayCommand<object> cmddgLocation { get; private set; }
        public RelayCommand<object> cmdRefContactPerson { get; private set; }
        public RelayCommand<object> CmdLicence { get; private set; }
        public RelayCommand<object> cmddgTransporter { get; private set; }
        public RelayCommand<object> CommandDocType { get; private set; }
        public RelayCommand<object> CommandSoldToParty { get; private set; }
        public RelayCommand<object> CommandShipToParty { get; private set; }
        public RelayCommand<object> CommandNotifyParty { get; private set; }
        public RelayCommand<object> CommandNotifyParty2 { get; private set; }
        public RelayCommand<object> CommandTransporter { get; private set; }
        public RelayCommand<object> CommandServiceProvider { get; private set; }
        public RelayCommand<object> CommandUOM { get; private set; }
        public RelayCommand<object> CommandUOMPriceQty { get; private set; }
        public RelayCommand<object> CommandSeller { get; private set; }
        public RelayCommand<object> CommandPayTerms { get; private set; }
        public RelayCommand<object> CommandCurrency { get; private set; }
        public RelayCommand<object> CmddgCurrency { get; private set; }
        public RelayCommand<object> CommandSalseOrg { get; private set; }
        public RelayCommand<object> CommandSalseGroup { get; private set; }
        public RelayCommand<object> CommandItemCategory { get; private set; }
        public RelayCommand<object> CommandBuyer { get; private set; }
        public RelayCommand<object> CommandSoldToAddress { get; private set; }
        public RelayCommand<object> CommandItem { get; private set; }
        public RelayCommand<object> CommandTerms { get; private set; }
        public RelayCommand<object> CommandShipToAddress { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdExecuteReferenceDocuments { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridTerms { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowSchedule { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowLicence { get; private set; }
        //public RelayCommand<object> CommandLocations { get; private set; }
        public RelayCommand<object> CommandLicenseAdvance { get; private set; }
        public RelayCommand<object> CommandLicenseEPCG { get; private set; }
        public RelayCommand<object> CommandIncoterms { get; private set; }
        public RelayCommand<object> CmddgIncoterms { get; private set; }
        public RelayCommand<object> cmdDeleteTax { get; private set; }
        public RelayCommand<object> CommandAddSelectedTax { get; private set; }
        public RelayCommand<object> CmdCondType { get; private set; }
        public RelayCommand<object> ManualTaxChangedCommand { get; private set; }
        public RelayCommand<object> cmdMail { get; private set; }
        public RelayCommand<object> cmdPrint { get; private set; }
        public RelayCommand<object> cmdRefDoc { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        public RelayCommand<Boolean> AddRemoveManualTax { get; private set; }
        public RelayCommand<object> CmdUnitPrice { get; private set; }
        public RelayCommand<object> CmdItemInfo { get; private set; }
        public RelayCommand<object> cmdOpenAttachments { get; private set; }
        public RelayCommand<object> CmddgShipToParty { get; private set; }
        public RelayCommand<object> CmdInsert_t_status { get; private set; }
        public RelayCommand<object> cmdAddSelectedReferenceDocument { get; private set; }
        public RelayCommand<object> CommandFltrDocType { get; private set; }
        public RelayCommand<object> CommandFltrStatus { get; private set; }
        public RelayCommand<object> CommandFltrSoldToParty { get; private set; }
        public RelayCommand<object> CommandFilterSeller { get; private set; }
        public RelayCommand<object> cmdSchShipToParty { get; private set; }
        public RelayCommand<object> cmdSchShipToAdd { get; private set; }
        public RelayCommand<object> cmdInsertElement { get; private set; }
        public RelayCommand<object> cmdInsertTermsConditions { get; private set; }
        //public RelayCommand<object> cmdInsertCompany { get; private set; }
        //public RelayCommand<object> cmdInsertLocation { get; private set; }
        public RelayCommand<SEL_T001_PART> cmdDeleteDataGridRowPF { get; private set; }
        public RelayCommand<object> cmdCreateBillingPlan { get; private set; }
        public RelayCommand<object> cmdInsertPriceList { get; private set; }

        #endregion
        #region Constructor
        public SDM_T005_VM(string ts_code, string doc_cat,  string doc_type) : base()
        {
            CursorControl.SetBusyState();
            IsDocumentViewerShow = false;
            this.doc_cat_vm = doc_cat;
            this.doc_type_vm = (doc_type ?? doc_cat);
            this.ts_code_vm = ts_code;
            MasterEntity = new SEL_T001();
            ItemsEntity = new ObservableCollection<SEL_T001_A>();
            ScheduleEntity = new SEL_T002();
            PRICE_HISTORY_COLLECTION = new List<STD_LIST_BE>();
            QMS_HISTORY_COLLECTION = new List<STD_LIST_BE>();
            DISPATCH_HISTORY_COLLECTION = new List<STD_LIST_BE>();
            PROJECTION_COLLECTION = new List<STD_LIST_BE>();
            ItemScheduleEntity = new ObservableCollection<SEL_T002_A>();
            LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>();
            TermsConditionEntity = new ObservableCollection<GEN_T011>();
            BillingPlanEntity = new ObservableCollection<ACC_T021>();
            PartnerEntity = new ObservableCollection<SEL_T001_PART>();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
            NotificationDataCollection = new List<NotificationData>();
            FlipGridData = new List<STD_LIST_BE>();
            MC = new MC_SDM_BE();
            MCTemp = new MC_SDM_BE();
            SEL_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            SEL_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            SEL_T002.ModelEntityUpdated += new EventHandler(ModelUpdated_ScheduleMaster);
            SEL_T002_A.ModelEntityUpdated += new EventHandler(ModelUpdated_ScheduleItem);
            //ItemEntityObject = new SEL_T001_A();
            TCEntityObject = new GEN_T011();
            sms = this.GetViewService<IShowMessageViewService>();
            REQUEST_PARA_OBJ = new STD_REQ_PARA_BE();
            STD_ITEM_OBJ = new STD_ITEM();
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            ItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            PartnerEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForPartner);
            CommandInitialization();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public SDM_T005_VM(string ts_code, string doc_cat, string doc_type, string doc_no) : base()
        {
            CursorControl.SetBusyState();
            IsDocumentViewerShow = false;
            this.doc_cat_vm = doc_cat;
            this.doc_type_vm = (doc_type ?? doc_cat); ;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new SEL_T001();
            ItemsEntity = new ObservableCollection<SEL_T001_A>();
            ScheduleEntity = new SEL_T002();
            PRICE_HISTORY_COLLECTION = new List<STD_LIST_BE>();
            QMS_HISTORY_COLLECTION = new List<STD_LIST_BE>();
            DISPATCH_HISTORY_COLLECTION = new List<STD_LIST_BE>();
            PROJECTION_COLLECTION = new List<STD_LIST_BE>();
            ItemScheduleEntity = new ObservableCollection<SEL_T002_A>();
            LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>();
            TermsConditionEntity = new ObservableCollection<GEN_T011>();
            BillingPlanEntity = new ObservableCollection<ACC_T021>();
            PartnerEntity = new ObservableCollection<SEL_T001_PART>();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
            NotificationDataCollection = new List<NotificationData>();
            FlipGridData = new List<STD_LIST_BE>();
            MC = new MC_SDM_BE();
            MCTemp = new MC_SDM_BE();
            SEL_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            SEL_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            SEL_T002.ModelEntityUpdated += new EventHandler(ModelUpdated_ScheduleMaster);
            SEL_T002_A.ModelEntityUpdated += new EventHandler(ModelUpdated_ScheduleItem);
            //ItemEntityObject = new SEL_T001_A();
            TCEntityObject = new GEN_T011();
            sms = this.GetViewService<IShowMessageViewService>();
            REQUEST_PARA_OBJ = new STD_REQ_PARA_BE();
            STD_ITEM_OBJ = new STD_ITEM();
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            ItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            PartnerEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForPartner);
            CommandInitialization();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        public SDM_T005_VM(string ts_code, STD_LIST_BE STD_OBJ) : base() //NOTE: Not using yet, under construction // Once this fine we can revoce above one.
        {
            CursorControl.SetBusyState();
            IsDocumentViewerShow = false;
            STD_LIST_OBJ = new STD_LIST_BE();
            this.STD_LIST_OBJ = STD_OBJ;
            this.doc_cat_vm = STD_LIST_OBJ.doc_cat;
            this.doc_type_vm = (STD_LIST_OBJ.doc_type ?? STD_LIST_OBJ.doc_cat); ;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = STD_LIST_OBJ.doc_no;
            MasterEntity = new SEL_T001();
            ItemsEntity = new ObservableCollection<SEL_T001_A>();
            ScheduleEntity = new SEL_T002();
            PRICE_HISTORY_COLLECTION = new List<STD_LIST_BE>();
            QMS_HISTORY_COLLECTION = new List<STD_LIST_BE>();
            DISPATCH_HISTORY_COLLECTION = new List<STD_LIST_BE>();
            PROJECTION_COLLECTION = new List<STD_LIST_BE>();
            ItemScheduleEntity = new ObservableCollection<SEL_T002_A>();
            LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
            TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
            TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>();
            TermsConditionEntity = new ObservableCollection<GEN_T011>();
            BillingPlanEntity = new ObservableCollection<ACC_T021>();
            PartnerEntity = new ObservableCollection<SEL_T001_PART>();
            TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
            NotificationDataCollection = new List<NotificationData>();
            FlipGridData = new List<STD_LIST_BE>();
            MC = new MC_SDM_BE();
            MCTemp = new MC_SDM_BE();
            SEL_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            SEL_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            SEL_T002.ModelEntityUpdated += new EventHandler(ModelUpdated_ScheduleMaster);
            SEL_T002_A.ModelEntityUpdated += new EventHandler(ModelUpdated_ScheduleItem);
            //ItemEntityObject = new SEL_T001_A();
            TCEntityObject = new GEN_T011();
            sms = this.GetViewService<IShowMessageViewService>();
            REQUEST_PARA_OBJ = new STD_REQ_PARA_BE();
            STD_ITEM_OBJ = new STD_ITEM();
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            ItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
            TotalDocumentTaxes.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTotalTaxes);
            PartnerEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForPartner);
            CommandInitialization();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        #endregion
        #region Relay Command Actions ·
        private void FilterScheduleShipToAdd()
        {
            try
            {
                if (SelectedItemScheduleEntity != null && ItemScheduleEntity != null && ItemScheduleEntity.Count > 0 && ItemsEntity != null && ItemsEntity.Count > 0 && ItemEntityObject != null && MC.SHIPPING_ADDRESS_LIST != null  //dgSelectedIndexItem >= 0
                    && ItemEntityObject != null)
                {
                    var temp = (from o in ItemScheduleEntity where o.ItemCode == ItemEntityObject.ItemCode select o).ToList();
                    if (temp != null && temp.Count() > 0)
                    {
                        var tempAdd = (from o in MC.SHIPPING_ADDRESS_LIST where o.party_code == SelectedItemScheduleEntity.ship_to_party select o);
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).location);
                        TheFilter = (o, prefix) => (((STD_PARTY)o).location ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).add_code.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                        AS_SHIPPING_ADDRESS = new AutoSuggestTextViewModel<dynamic>(tempAdd, TheFilter, SuggestedValue, "ship_to_addNm", "location", true);
                        AS_SHIPPING_ADDRESS.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void MailDocuments(object InputValue)
        {
            CursorControl.SetBusyState();
            EntityChangeEnable = false;
            ReportManager ReportManager = new ReportManager();

            string ToEmailId = "";
            string ReportName = "";
            string DisplaytName = "";
            string MessageData = "";
            string To = "";
            string Cc = "";
            string Bcc = "";

            try
            {
                
                string Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.sono;
                string tempLocation = MasterEntity.location_Id;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, Request, "SEL_T001_BL", "SDM", "LOAD_DOC_BY_DOC_NO", 0, "");

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

                objDataSourceName[0] = "dsMaster";
                objDataSourceName[1] = "dsItemEntity";
                objDataSourceName[2] = "dsTaxEntity";
                objDataSourceName[3] = "dsCompany";
                objDataSourceName[4] = "dsLocation";
                objDataSourceName[5] = "dsScheduleEntity";
                objDataSourceName[6] = "dsTC";

                if (!string.IsNullOrWhiteSpace(MasterEntity.sono))
                {
                    var SystemDocumentObject = (from o in MC.DOC_TYPE_LIST where o.doc_cat == MasterEntity.doc_cat && o.doc_type == MasterEntity.doc_type select o).ToList();
                    if (SystemDocumentObject.Count > 0 && ToEmailId != "")
                    {
                        To = ToEmailId;
                        Cc = "";
                        Bcc = AppSessionState.EmpEmailId;
                        ReportName = SystemDocumentObject[0].report_name.Split(',')[0];
                        DisplaytName = MasterEntity.doc_desc + "_" + MasterEntity.party_name + "_" + MasterEntity.sono.Replace(@"/", "-").Replace(@"\", "-") + "_" + MasterEntity.sodate.Value.Date.ToShortDateString().Replace(@"/", string.Empty).Replace(@"\", string.Empty);
                        MessageData = "<h3>Commercial Document for Sales Order!</h3><p>Dear Sir!</p><p>Please find attached herewith commercial document for Sales Order as per your requirements. </p><p>-" + AppSessionState.CompanyName + "</p>";

                        ReportManager.Mail(To, Cc, Bcc, objDataSource, objDataSourceName, null, "\\REPORTS_STD\\TXN\\" + ReportName, DisplaytName, "Sales Order Prepared for " + AppSessionState.CompanyName, MessageData, "", ".pdf");
                    }
                }

                EntityChangeEnable = true;
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void PrintDocuments(Object InputValue)
        {
            try
            {
                string Request = "PRINT_DOCUMENT" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.sono;
                CursorControl.SetBusyState();
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, Request, "SEL_T001_BL", "SDM", "LOAD_DOC_BY_DOC_NO", 0, "");
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
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + MC.DOC_TYPE_LIST[0].report_name, getParametersList(), MC.DOC_TYPE_LIST[0].report_name); //QuotationMurRpt.rdlc
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }

        }
        private void InsertRefContactPerson(object InputValue) // Para10
        {
            try
            {
                string Request = "";
                STD_PARTY POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PARTY_CONTACT_LIST.Where(x => x.cp_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ref_party_contact = POPUPEntityObject.SrNo;
                    MasterEntity.ref_contact_name = POPUPEntityObject.full_name;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        //private void InsertLocationItem(object InputValue)
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
        //            ItemEntityObject.order_to_plant = POPUPEntityObject.location_id;
        //        }
        //    }
        //    catch (Exception ex)
        //    { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        //}
        private void LoadBackFlipData(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (REQUEST_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + (REQUEST_PARA_OBJ.doc_type ?? doc_cat_vm) + "!@!@" + AppSessionState.UserID + "!@" + (Utilities.NullIf(REQUEST_PARA_OBJ.emp_id) ?? AppSessionState.EmpId) + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + (REQUEST_PARA_OBJ.party_code ?? "") + "!@!@" + REQUEST_PARA_OBJ.active + "!@" + REQUEST_PARA_OBJ.t_status + "!@" + Convert.ToDateTime(REQUEST_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQUEST_PARA_OBJ.to_date).ToString("MM/dd/yyyy");
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, Request, "SEL_T001_BL", "SDM", "LoadAll", 0, "");

                FlipGridData = MCTemp.BACK_FLIP_LIST.ToList();
                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(FlipGridData);
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(Filter_FlipGrid);
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void Insertdgplant(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0003 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.LOCATION_LIST.Where(x => x.location_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0003>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.location_Id = POPUPEntityObject.location_id;
                    MasterEntity.LoctnNm = POPUPEntityObject.location_name;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
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
                //if (POPUPEntityObject != null && MasterEntity.doc_type_user != POPUPEntityObject.doc_type_user) // Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                //{
                if (POPUPEntityObject != null) // Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (String.IsNullOrEmpty(MasterEntity.po_no) != true || String.IsNullOrWhiteSpace(MasterEntity.po_no) != true) // Only enter in the code block if ENtity Not null.
                    {
                        if (ItemsEntity.Count > 0 && isNewRecord == false && MasterEntity.comp_code != "1")
                        {
                            sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Party Change Information";sms.Text = String.Format("Can not change Document Type '{0}' in edit mode", this.Title);sms.ShowMessage();
                        }
                    }
                    else
                    {
                        MasterEntity.doc_cat = POPUPEntityObject.doc_cat;
                        MasterEntity.doc_type = POPUPEntityObject.doc_type;
                        MasterEntity.doc_type_user = POPUPEntityObject.doc_type;
                        MasterEntity.doc_desc = POPUPEntityObject.doc_type_name;
                        AutoRoundupEnable = (bool)(POPUPEntityObject.auto_roundup ?? false);
                        RoundUpDecimals = (int)(POPUPEntityObject.roundup_digits ?? 2);
                        this.doc_cat_vm = POPUPEntityObject.doc_cat;

                        MasterEntity.valid_from_date = MasterEntity.sodate ?? DateTime.UtcNow;
                        MasterEntity.valid_to_date = (MasterEntity.sodate ?? DateTime.UtcNow).AddDays(POPUPEntityObject.valid_days ?? 90);
                        MasterEntity.validity_date = (MasterEntity.sodate ?? DateTime.UtcNow).AddDays(POPUPEntityObject.valid_days ?? 90);
                    }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void SelectionChanged_SEL_T001_A(object InputValue)
        {
            try
            {
                ItemEntityObject = (SEL_T001_A)InputValue;
                try // Display Item related information
                { STD_ITEM_OBJ = MC.STD_ITEM_LIST.Where(x => x.item_code == ItemEntityObject.ItemCode).ToList()[0]; }
                catch (Exception ex) { STD_ITEM_OBJ = null; }
                
                FilterScheduleDataGrid();
            }
            catch (Exception ex) { }
        }
        private void SelectionChanged_SEL_T001_E(object InputValue)
        {
            try
            {
                TCEntityObject = (GEN_T011)InputValue;
            }
            catch (Exception ex) { }
        }
        private void SelectionChangedPartner(object InputValue)
        {
            try
            {
                string old_party = PFEntityObject.party_code;
                PFEntityObject = (SEL_T001_PART)InputValue;
                if (PFEntityObject != null)
                {
                    if (PFEntityObject.party_code != old_party)
                    {

                        if (!string.IsNullOrWhiteSpace(PFEntityObject.party_code))
                        {
                            string RequestParameterData = "LOAD_PARTY_DATA" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@" + PFEntityObject.party_code + "!@" + (MasterEntity.so_code ?? AppSessionState.so_code) + "!@" + (MasterEntity.sg_code ?? AppSessionState.sg_code);
                            MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, RequestParameterData, "SEL_T001_BL", "SDM", "", 0, "");

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).emp_id);
                            TheFilter = (o, prefix) => (((STD_PARTY)o).emp_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).emp_name.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                            AS_PFEMPLOYEE = new AutoSuggestTextViewModel<dynamic>(MCTemp.PARTY_CONTACT_LIST, TheFilter, SuggestedValue, "emp_id", true);
                            AS_PFEMPLOYEE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_PFEMPLOYEE.AutoSuggestVM.IsFreeTextAllowed = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).add_code.ToString());
                            TheFilter = (o, prefix) => (((STD_PARTY)o).add_code.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).location.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                            AS_PF_ADDRESS = new AutoSuggestTextViewModel<dynamic>(MCTemp.BILLING_ADDRESS_LIST, TheFilter, SuggestedValue, "add_code", true);
                            AS_PF_ADDRESS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_PF_ADDRESS.AutoSuggestVM.IsFreeTextAllowed = true;

                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void ScheduleDataGridRowSelectionChanged(object InputValue)
        {
            try
            {
                SelectedItemScheduleEntity = (SEL_T002_A)InputValue;
            }
            catch (Exception ex){ }
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
            catch (Exception ex){ }
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                if (STD_LIST_OBJ != null && STD_LIST_OBJ.req_code == "VIEW")
                {
                    List<STD_LIST_BE> STD_LIST = new List<STD_LIST_BE>();
                    STD_LIST.Add(STD_LIST_OBJ);
                    LoadInitialData(STD_LIST_OBJ.comp_code, STD_LIST_OBJ.location_id);
                    CursorControl.SetBusyState();
                    LoadDocumentByDocumentNumber(STD_LIST, "DocumentNo");
                }
                else if (doc_no_vm != null && ts_code_vm != null) // NOTE: We can remove once above update everywahre
                {
                    LoadInitialData(AppSessionState.OBJ_COMPANY.comp_code, AppSessionState.OBJ_LOCATION.location_id);
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                    AppSessionState.ViewOtherRecordAllowed = true;
                }
                else
                {
                    LoadInitialData(AppSessionState.OBJ_COMPANY.comp_code, AppSessionState.OBJ_LOCATION.location_id);
                    DefaultValues();
                }
                //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertPFAddress(object InputValue, bool OverrideValue)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "";
                STD_PARTY POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MCTemp.BILLING_ADDRESS_LIST.Where(x => x.add_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.location.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null)
                {
                    PFEntityObject.add_code = POPUPEntityObject.add_code.ToString();
                    PFEntityObject.location = POPUPEntityObject.location;
                }
                else
                {
                    PFEntityObject.add_code = null;
                    PFEntityObject.location = null;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertPFEmployee(object InputValue, bool OverrideValue)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "";
                STD_PARTY POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MCTemp.PARTY_CONTACT_LIST.Where(x => x.emp_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.emp_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null)
                {
                    PFEntityObject.emp_id = POPUPEntityObject.emp_id;
                    PFEntityObject.emp_name = POPUPEntityObject.emp_name;
                    PFEntityObject.contact_no = POPUPEntityObject.mobile;
                    PFEntityObject.email_id = POPUPEntityObject.email_id;
                }
                else
                {
                    PFEntityObject.emp_id = null;
                    PFEntityObject.emp_name = null;
                    PFEntityObject.contact_no = null;
                    PFEntityObject.email_id = null;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertPFCode(object InputValue, bool OverrideValue)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PF_CODE_LIST.Where(x => x.value_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.value_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null) 
                {
                    PFEntityObject.pf_code = POPUPEntityObject.value_code;
                    PFEntityObject.pf_name = POPUPEntityObject.value_name;
                }
                else
                {
                    PFEntityObject.pf_code = null;
                    PFEntityObject.pf_name = null;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertPFParty(object InputValue, bool OverrideValue)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "";
                string RequestParameterData = "";
                STD_PARTY POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PARTY_LIST.Where(x => x.party_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.party_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null) 
                {
                    //if (PFEntityObject.party_code != POPUPEntityObject.party_code)
                    //{
                        PFEntityObject.party_code = POPUPEntityObject.party_code;
                        PFEntityObject.party_name = POPUPEntityObject.party_name;

                        if (!string.IsNullOrWhiteSpace(POPUPEntityObject.party_code))
                        {
                            RequestParameterData = "LOAD_PARTY_DATA" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@" + PFEntityObject.party_code + "!@" + (MasterEntity.so_code ?? AppSessionState.so_code) + "!@" + (MasterEntity.sg_code ?? AppSessionState.sg_code);
                            MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, RequestParameterData, "SEL_T001_BL", "SDM", "", 0, "");

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).emp_id);
                            TheFilter = (o, prefix) => (((STD_PARTY)o).emp_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).emp_name.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                            AS_PFEMPLOYEE = new AutoSuggestTextViewModel<dynamic>(MCTemp.PARTY_CONTACT_LIST, TheFilter, SuggestedValue, "emp_id", true);
                            AS_PFEMPLOYEE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_PFEMPLOYEE.AutoSuggestVM.IsFreeTextAllowed = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).add_code.ToString());
                            TheFilter = (o, prefix) => (((STD_PARTY)o).add_code.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).location.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                            AS_PF_ADDRESS = new AutoSuggestTextViewModel<dynamic>(MCTemp.BILLING_ADDRESS_LIST, TheFilter, SuggestedValue, "add_code", true);
                            AS_PF_ADDRESS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_PF_ADDRESS.AutoSuggestVM.IsFreeTextAllowed = true;

                            if (MCTemp.PARTY_CONTACT_LIST.Count == 1)
                            {
                                PFEntityObject.emp_id = MCTemp.PARTY_CONTACT_LIST[0].cp_code.ToString();
                                PFEntityObject.emp_name = MCTemp.PARTY_CONTACT_LIST[0].full_name;
                                PFEntityObject.email_id = MCTemp.PARTY_CONTACT_LIST[0].email_id;
                                PFEntityObject.contact_no = MCTemp.PARTY_CONTACT_LIST[0].mobile;
                            }
                            else
                            {
                                PFEntityObject.emp_id = null;
                                PFEntityObject.emp_name = null;
                                PFEntityObject.email_id = null;
                                PFEntityObject.contact_no = null;
                            }
                            if (MCTemp.BILLING_ADDRESS_LIST.Count == 1)
                            {
                                PFEntityObject.add_code = MCTemp.BILLING_ADDRESS_LIST[0].add_code.ToString();
                            }
                            else
                            {
                                PFEntityObject.add_code = null;
                            }
                        }
                    //}
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertPriceList(object InputValue)
        {
            try
            {
                if (!string.IsNullOrEmpty(MasterEntity.PartyId) && !string.IsNullOrEmpty(MasterEntity.catalogue_code) && isNewRecord==true)
                {
                    InsertSoldToParty(MasterEntity.PartyId, true);
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertSoldToParty(object InputValue, bool OverrideValue)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "";
                string RequestParameterData = "";
                bool ind_set_party = false; // if all condition match to set or edit party then this indicator will set to true and assign new party otherwise false and reset all values null or as earlier.
                STD_PARTY POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.PARTY_LIST.Where(x => x.party_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.party_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null) //&& MasterEntity.PartyId != POPUPEntityObject.PartyId) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if ((String.IsNullOrEmpty(MasterEntity.sono) != true || String.IsNullOrWhiteSpace(MasterEntity.sono) != true) && MasterEntity.PartyId != POPUPEntityObject.party_code) //Condition: Only enter in the code block if ENtity Not null. Means It is in Edit Mode.
                    {
                        if (ItemsEntity.Count > 0 && isNewRecord == false)
                        {
                            ind_set_party = false;
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Customer Change Information"; sms.Text = String.Format("Cannot change Customer'{0}' in edit mode", this.Title); sms.ShowMessage();
                        }
                        else
                        {
                            ind_set_party = true;
                        }
                    }
                    else if (isNewRecord == true && ItemsEntity.Count > 0 && MasterEntity.PartyId != POPUPEntityObject.party_code)
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Party Selection"; sms.Text = String.Format("If You Change The Party Items Will be removed if Catlog Present'{0}'", this.Title);
                        if (sms.ShowMessage() == DialogResult.Ok)
                        {
                            ind_set_party = true;
                            //Removing items from grid as per this condition.
                            var CATLOG_LIST = (from o in MCTemp.STD_ITEM_LIST where (o.item_code_party != "") select o).ToList();
                            if (CATLOG_LIST.Count > 0)
                            {
                                ItemsEntity.Clear();
                                ItemScheduleEntity.Clear();
                                LicenceDetailsEntity.Clear();
                            }
                        }
                    }
                    else if (isNewRecord == true && MasterEntity.party_name != POPUPEntityObject.party_name)
                    {
                        ind_set_party = true;
                    }
                    else if (isNewRecord == true && ItemsEntity.Count == 0)
                    {
                        ind_set_party = true;
                    }

                    if (ind_set_party == true)
                    {
                        MasterEntity.PartyId = POPUPEntityObject.party_code;
                        MasterEntity.party_name = POPUPEntityObject.party_name;
                        MasterEntity.p_term_code = POPUPEntityObject.p_term_code;
                        MasterEntity.p_term = POPUPEntityObject.p_term;
                        MasterEntity.curr_code = POPUPEntityObject.curr_code;
                        MasterEntity.symbol = POPUPEntityObject.symbol;
                        MasterEntity.gst_PartyId = POPUPEntityObject.party_code;
                        MasterEntity.buss_place = POPUPEntityObject.buss_place;
                        MasterEntity.bill_address_id = null;
                        MasterEntity.billing_address = null;
                        MasterEntity.country_nm = null;
                        MasterEntity.country_code = null;
                        MasterEntity.state_nm = null;
                        MasterEntity.city = null;
                        MasterEntity.address = null;
                        MasterEntity.address1 = null;
                        MasterEntity.pincode = null;
                        default_tax = POPUPEntityObject.default_tax;

                        if (MasterEntity.curr_code == AppSessionState.CntryCurncy)
                        {
                            MasterEntity.ex_rate = 1;
                        }
                        else
                        {
                            InsertCurrency(MasterEntity.curr_code ?? AppSessionState.curr_code);
                        }
                        PartyEmailId = POPUPEntityObject.email;
                        RequestParameterData = "LOAD_SOLD_TO_PARTY" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + (MasterEntity.doc_type ?? doc_type_vm) + "!@" + Convert.ToDateTime(MasterEntity.sodate).ToString("MM/dd/yyyy") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + MasterEntity.PartyId + "!@" + MasterEntity.curr_code + "!@" + (MasterEntity.catalogue_code ?? "");
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, RequestParameterData, "SEL_T001_BL", "SDM", "", 0, "");

                        
                        MC.PARTY_CONTACT_LIST = MCTemp.PARTY_CONTACT_LIST;
                        MC.BILLING_ADDRESS_LIST = MCTemp.BILLING_ADDRESS_LIST;
                        MC.STD_ITEM_LIST = MCTemp.STD_ITEM_LIST;
                        MC.CONDITION_LIST = MCTemp.CONDITION_LIST;
                        ITEM_COLLECTION = CollectionViewSource.GetDefaultView(MC.STD_ITEM_LIST);
                        ITEM_COLLECTION.Filter = new Predicate<object>(FLTR_ITEM);
                        TermsConditionCollection = CollectionViewSource.GetDefaultView(MC.CONDITION_LIST);

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0051)x).tc_code);
                        TheFilter = (o, prefix) => (((ADM_M0051)o).tc_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0051)o).con_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0051)o).long_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        AS_TERMS_CONDITION = new AutoSuggestTextViewModel<dynamic>(MC.CONDITION_LIST, TheFilter, SuggestedValue, "tc_code", "tc_code", true);
                        AS_TERMS_CONDITION.AutoSuggestVM.IsEmptyValueAllowed = true;

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code);
                        TheFilter = (o, prefix) => ((STD_ITEM)o).item_code.ToString().ToLower().Contains(prefix.ToLower()) || ((STD_ITEM)o).item_name.ToString().ToLower().Contains(prefix.ToLower());
                        AS_ITEM = new AutoSuggestTextViewModel<dynamic>(MC.STD_ITEM_LIST, TheFilter, SuggestedValue, "ItemCode", "item_code", true);
                        AS_ITEM.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ITEM.AutoSuggestVM.IsFreeTextAllowed = false;

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).full_name);
                        TheFilter = (o, prefix) => (((STD_PARTY)o).full_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).cp_code.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                        AS_BUYER = new AutoSuggestTextViewModel<dynamic>(MC.PARTY_CONTACT_LIST, TheFilter, SuggestedValue, "buyer_name", true);
                        AS_BUYER.AutoSuggestVM.IsEmptyValueAllowed = true;AS_BUYER.AutoSuggestVM.IsFreeTextAllowed = true;

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).add_code.ToString());
                        TheFilter = (o, prefix) => (((STD_PARTY)o).add_code.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).location.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                        AS_BILLING_ADDRESS = new AutoSuggestTextViewModel<dynamic>(MC.BILLING_ADDRESS_LIST, TheFilter, SuggestedValue, "add_code_bil", true);
                        AS_BILLING_ADDRESS.AutoSuggestVM.IsEmptyValueAllowed = true;
                        AS_BILLING_ADDRESS.AutoSuggestVM.IsFreeTextAllowed = true;

                        if (MC.PARTY_CONTACT_LIST.Count == 1)
                        {
                            MasterEntity.buyer_name = MC.PARTY_CONTACT_LIST[0].full_name;
                            MasterEntity.buyer = MC.PARTY_CONTACT_LIST[0].SrNo;
                            MasterEntity.cp_code = MC.PARTY_CONTACT_LIST[0].cp_code;
                            MasterEntity.mail_id = MC.PARTY_CONTACT_LIST[0].email;
                            PersonEmailId = MC.PARTY_CONTACT_LIST[0].email;
                            InsertBuyer(MasterEntity.buyer_name);
                        }
                        else
                        {
                            MasterEntity.buyer = null;
                            MasterEntity.buyer_name = null;
                            PersonEmailId = null;
                        }

                        if (MC.BILLING_ADDRESS_LIST.Count == 1)
                        {
                            MasterEntity.bill_address_id = MC.BILLING_ADDRESS_LIST[0].SrNo;
                            MasterEntity.add_code_bil = MC.BILLING_ADDRESS_LIST[0].add_code;
                            MasterEntity.billing_address = MC.BILLING_ADDRESS_LIST[0].location;
                            MasterEntity.country_nm = MC.BILLING_ADDRESS_LIST[0].country_name;
                            MasterEntity.country_code = MC.BILLING_ADDRESS_LIST[0].country_code;
                            MasterEntity.state_nm = MC.BILLING_ADDRESS_LIST[0].state_name;
                            MasterEntity.city = MC.BILLING_ADDRESS_LIST[0].city;
                            MasterEntity.address = MC.BILLING_ADDRESS_LIST[0].address1;
                            MasterEntity.address1 = MC.BILLING_ADDRESS_LIST[0].address2;
                            MasterEntity.pincode = MC.BILLING_ADDRESS_LIST[0].pin;
                        }
                        else if (MC.BILLING_ADDRESS_LIST.Count > 1)
                        {
                            var BillingAddress = (from o in MC.BILLING_ADDRESS_LIST where o.add_type == "Billing Address" select o).ToList();
                            if (BillingAddress.Count == 1)
                            {
                                MasterEntity.bill_address_id = BillingAddress[0].SrNo;
                                MasterEntity.add_code_bil = BillingAddress[0].add_code;
                                MasterEntity.billing_address = BillingAddress[0].location;
                                MasterEntity.country_nm = BillingAddress[0].country_name;
                                MasterEntity.country_code = BillingAddress[0].country_code;
                                MasterEntity.state_nm = BillingAddress[0].state_name;
                                MasterEntity.city = BillingAddress[0].city;
                                MasterEntity.address = BillingAddress[0].address1;
                                MasterEntity.address1 = BillingAddress[0].address2;
                                MasterEntity.pincode = BillingAddress[0].pin;
                            }
                        }
                        if (MasterEntity.country_code == ((List<ADM_M002>)AppSessionState.ADM_M002_List).Where(x => x.comp_code.Equals(MasterEntity.comp_code, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].country_code)
                        {
                            MasterEntity.ind_trade = "D";
                        }
                        else
                        {
                            MasterEntity.ind_trade = "E";
                        }

                        if (string.IsNullOrWhiteSpace(MasterEntity.ship_to_party))
                        {
                            MasterEntity.ship_to_party = MasterEntity.PartyId;
                            MasterEntity.ship_to_party_name = MasterEntity.party_name;
                            //InsertShipToParty(MasterEntity.ship_to_party, false);

                            if (InputValue.GetType() == typeof(string) && InputValue != null)
                            {
                                InsertShipToParty(MasterEntity.ship_to_party, false);
                            }
                            else if (InputValue != null)
                            {
                                InsertShipToParty(InputValue, false);
                            }

                        }
                        if (TermsConditionEntity != null)
                        {
                            if (TermsConditionEntity.Count <= 0)
                            {
                                foreach (var item in MC.CONDITION_LIST)
                                {
                                    //NOTE: Need to add group module and category assignment then make it perfect. now we vahe to add same condition for SN,QN & SO because of limit to doc_cat only.
                                    if (item.ind_man == "1" && item.party_code==MasterEntity.PartyId) // NOTE: make perfect logic as then add this kind of code.  && item.doc_cat == (MasterEntity.doc_cat ?? doc_cat_vm)
                                    {
                                        TCEntityObject = new GEN_T011();
                                        TermsConditionEntity.Add(TCEntityObject);
                                        InsertTerms(item.tc_code);
                                    }
                                    else if (item.ind_man == "1" && item.doc_cat == (MasterEntity.doc_cat ?? doc_cat_vm))
                                    {
                                        TCEntityObject = new GEN_T011();
                                        TermsConditionEntity.Add(TCEntityObject);
                                        InsertTerms(item.tc_code);
                                    }
                                }
                            }
                        }
                        
                        List<ACC_M013> tempTax = new List<ACC_M013>();

                        if (MasterEntity.buss_place == null)
                        {
                            tempTax = SelectedTaxList; // SelectedTaxList.Where(T => T.base_code_id == 1 || T.base_code_id == 2 || T.base_code_id == 3).ToList();
                            TaxDictoneryParent = tempTax.ToDictionary(X => X.id.ToString(), X => (object)X.description);
                        }
                        else if(MasterEntity.buss_place == ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(x => x.comp_code.Equals(MasterEntity.comp_code, StringComparison.OrdinalIgnoreCase) == true && x.location_Id.Equals(MasterEntity.location_Id, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].buss_place)
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
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertShipToParty(object InputValue, bool OverrideValue)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "";
                string RequestParameterData = "";
                STD_PARTY POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.PARTY_LIST.Where(x => x.party_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.party_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null) //&& MasterEntity.PartyId != POPUPEntityObject.PartyId) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.ship_to_party = POPUPEntityObject.party_code;
                    MasterEntity.ship_to_party_name = POPUPEntityObject.party_name;
                    MasterEntity.buss_place = POPUPEntityObject.buss_place;
                    default_tax = POPUPEntityObject.default_tax;

                    if (MasterEntity.PartyId != MasterEntity.ship_to_party) //&& (MasterEntity.ship_to_party != POPUPEntityObject.PartyId || MasterEntity.ship_to_party_name != POPUPEntityObject.PartyNm)
                    {
                        RequestParameterData = "LOAD_SHIP_TO_PARTY" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@" + Convert.ToDateTime(MasterEntity.sodate).ToString("MM/dd/yyyy") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + MasterEntity.ship_to_party + "!@" + MasterEntity.curr_code;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, RequestParameterData, "SEL_T001_BL", "SDM", "", 0, "");
                        MC.SHIPPING_ADDRESS_LIST = MCTemp.SHIPPING_ADDRESS_LIST;

                        // item list refresh for ship to party if catlog exists
                        if(MCTemp.STD_ITEM_LIST != null)
                        {
                            if (MCTemp.STD_ITEM_LIST.Count > 0)
                            {
                                MC.STD_ITEM_LIST = MCTemp.STD_ITEM_LIST;
                                ITEM_COLLECTION = CollectionViewSource.GetDefaultView(MC.STD_ITEM_LIST);
                                ITEM_COLLECTION.Filter = new Predicate<object>(FLTR_ITEM);

                                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code);
                                TheFilter = (o, prefix) => ((STD_ITEM)o).item_code.ToString().ToLower().Contains(prefix.ToLower()) || ((STD_ITEM)o).item_name.ToString().ToLower().Contains(prefix.ToLower());
                                AS_ITEM = new AutoSuggestTextViewModel<dynamic>(MC.STD_ITEM_LIST, TheFilter, SuggestedValue, "ItemCode", "item_code", true);
                                AS_ITEM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ITEM.AutoSuggestVM.IsFreeTextAllowed = true;
                            }
                        }
                        
                    }
                    else if (MasterEntity.PartyId == POPUPEntityObject.party_code) //&& (MasterEntity.ship_to_party != POPUPEntityObject.PartyId || MasterEntity.ship_to_party_name != POPUPEntityObject.PartyNm)
                    {
                        MC.SHIPPING_ADDRESS_LIST = MC.BILLING_ADDRESS_LIST;
                    }

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).add_code.ToString());
                    TheFilter = (o, prefix) => (((STD_PARTY)o).add_code.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).location.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                    AS_SHIPPING_ADDRESS = new AutoSuggestTextViewModel<dynamic>(MC.SHIPPING_ADDRESS_LIST, TheFilter, SuggestedValue, "add_code_del", true);
                    AS_SHIPPING_ADDRESS.AutoSuggestVM.IsEmptyValueAllowed = true;
                    AS_SHIPPING_ADDRESS.AutoSuggestVM.IsFreeTextAllowed = true;

                    MasterEntity.add_code_del = null;
                    MasterEntity.del_address = null;
                    MasterEntity.delivery_address = null;
                    MasterEntity.country_nm_s = null;
                    MasterEntity.state_nm_s = null;
                    MasterEntity.city_s = null;
                    MasterEntity.address1_s = null;
                    MasterEntity.address2_s = null;
                    MasterEntity.pincode_s = null;
                    

                    if (MC.SHIPPING_ADDRESS_LIST.Count == 0)
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Ship To Address Not Available For this Customer"); sms.ShowMessage();
                    }
                    else
                    {
                        if (MC.SHIPPING_ADDRESS_LIST.Count == 1)
                        {
                            MasterEntity.del_address = MC.SHIPPING_ADDRESS_LIST[0].SrNo;
                            MasterEntity.add_code_del = MC.SHIPPING_ADDRESS_LIST[0].add_code;
                            MasterEntity.delivery_address = MC.SHIPPING_ADDRESS_LIST[0].location;
                            MasterEntity.country_nm_s = MC.SHIPPING_ADDRESS_LIST[0].country_name;
                            MasterEntity.state_nm_s = MC.SHIPPING_ADDRESS_LIST[0].state_name;
                            MasterEntity.city_s = MC.SHIPPING_ADDRESS_LIST[0].city;
                            MasterEntity.address1_s = MC.SHIPPING_ADDRESS_LIST[0].address1;
                            MasterEntity.address2_s = MC.SHIPPING_ADDRESS_LIST[0].address2;
                            MasterEntity.pincode_s = MC.SHIPPING_ADDRESS_LIST[0].pin;
                            MasterEntity.buss_place = MC.SHIPPING_ADDRESS_LIST[0].buss_place;
                        }
                        else if (MC.SHIPPING_ADDRESS_LIST.Count > 1)
                        {
                            var DeliveryAddress = (from o in MC.SHIPPING_ADDRESS_LIST where o.add_type == "Delivery Address" select o).ToList();
                            if (DeliveryAddress.Count == 1)
                            {
                                MasterEntity.del_address = DeliveryAddress[0].SrNo;
                                MasterEntity.add_code_del = MC.SHIPPING_ADDRESS_LIST[0].add_code;
                                MasterEntity.delivery_address = DeliveryAddress[0].location;
                                MasterEntity.country_nm_s = DeliveryAddress[0].country_name;
                                MasterEntity.state_nm_s = DeliveryAddress[0].state_name;
                                MasterEntity.city_s = DeliveryAddress[0].city;
                                MasterEntity.address1_s = DeliveryAddress[0].address1;
                                MasterEntity.address2_s = DeliveryAddress[0].address2;
                                MasterEntity.pincode_s = DeliveryAddress[0].pin;
                                MasterEntity.buss_place = MC.SHIPPING_ADDRESS_LIST[0].buss_place;
                            }
                        }

                        List<ACC_M013> tempTax = new List<ACC_M013>();
                        if (MasterEntity.buss_place == null)
                        {
                            tempTax = SelectedTaxList; // SelectedTaxList.Where(T => T.base_code_id == 1 || T.base_code_id == 2 || T.base_code_id == 3).ToList();
                            TaxDictoneryParent = tempTax.ToDictionary(X => X.id.ToString(), X => (object)X.description);
                        }
                        else if(MasterEntity.buss_place == ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(x => x.comp_code.Equals(MasterEntity.comp_code, StringComparison.OrdinalIgnoreCase) == true && x.location_Id.Equals(MasterEntity.location_Id, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].buss_place)
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
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertNotifyParty(object InputValue, bool OverrideValue)
        {
            try
            {
                string Request = "";
                STD_PARTY POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.PARTY_LIST.Where(x => x.party_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //&& MasterEntity.PartyId != POPUPEntityObject.PartyId) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.notify_party = POPUPEntityObject.party_code;
                    MasterEntity.notify_party_name = POPUPEntityObject.party_name;
                }
            }
            catch (Exception ex){}
        }
        private void InsertNotifyParty2(object InputValue, bool OverrideValue)
        {
            try
            {
                string Request = "";
                STD_PARTY POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.PARTY_LIST.Where(x => x.party_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null) //&& MasterEntity.PartyId != POPUPEntityObject.PartyId) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.notify_party2 = POPUPEntityObject.party_code;
                    MasterEntity.notify_party_name2 = POPUPEntityObject.party_name;
                }
            }
            catch (Exception ex){}
        }
        private void InsertTransporter(object InputValue, bool OverrideValue)
        {
            try
            {
                string Request = "";
                STD_PARTY POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.SUPPLIER_LIST.Where(x => x.party_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.party_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.transporter_cd = POPUPEntityObject.party_code;
                    MasterEntity.transporter_name = POPUPEntityObject.party_name;
                    MasterEntity.tr_party = POPUPEntityObject.party_code;
                    MasterEntity.TranParty_name = POPUPEntityObject.party_name;
                }
            }
            catch (Exception ex){}
        }
        private void InsertdgTransporter(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                STD_PARTY POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.SUPPLIER_LIST.Where(x => x.party_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    if (dgSelectedIndexItemSchedule >= 0 && ItemScheduleEntity.Count > dgSelectedIndexItemSchedule) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        SelectedItemScheduleEntity.PartyId = POPUPEntityObject.party_code;
                        SelectedItemScheduleEntity.PartyNm = POPUPEntityObject.party_name;
                        SelectedItemScheduleEntity.tr_party = POPUPEntityObject.party_code;
                    }
                }
            }
            catch (Exception ex){}
        }
        private void InsertServiceProvider(object InputValue, bool OverrideValue)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "";
                string RequestParameterData = "";
                STD_PARTY POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.PARTY_LIST.Where(x => x.party_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.party_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }

                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.referring_party = POPUPEntityObject.party_code;
                    MasterEntity.referring_party_name = POPUPEntityObject.party_name;
                    MasterEntity.refferencing_party = POPUPEntityObject.party_code;
                    RequestParameterData = "LOAD_REFERING_PARTY" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + MasterEntity.referring_party;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, RequestParameterData, "SEL_T001_BL", "SDM", "", 0, "");
                    MC.OTHER_CONTACT_LIST = MCTemp.OTHER_CONTACT_LIST;

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).full_name);
                    TheFilter = (o, prefix) => ((STD_PARTY)o).full_name.ToString().ToLower().Contains(prefix.ToLower());
                    AS_REF_PARTY_PERSON = new AutoSuggestTextViewModel<dynamic>(MC.OTHER_CONTACT_LIST, TheFilter, SuggestedValue, "ref_contact_name", true);

                    if (MC.OTHER_CONTACT_LIST.Count == 1)
                    {
                        MasterEntity.ref_contact_name = MC.OTHER_CONTACT_LIST[0].full_name;
                        MasterEntity.ref_party_contact = MC.OTHER_CONTACT_LIST[0].SrNo;
                    }
                    else if (MC.OTHER_CONTACT_LIST.Count <= 0)
                    {
                        MasterEntity.ref_contact_name = "";
                        MasterEntity.ref_party_contact = 0;
                    }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertSoldToAddress(object InputValue, bool OverrideValue)
        {
            try
            {
                string Request = "";
                STD_PARTY POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.BILLING_ADDRESS_LIST.Where(x => x.add_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.location.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.bill_address_id = POPUPEntityObject.SrNo;
                    MasterEntity.add_code_bil = POPUPEntityObject.add_code;
                    MasterEntity.billing_address = POPUPEntityObject.location;
                    MasterEntity.country_nm = POPUPEntityObject.country_name;      
                    MasterEntity.state_nm = POPUPEntityObject.state_name;
                    MasterEntity.city = POPUPEntityObject.city;
                    MasterEntity.address = POPUPEntityObject.address1;
                    MasterEntity.address1 = POPUPEntityObject.address2;
                    MasterEntity.pincode = POPUPEntityObject.pin;
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
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertShipToAddress(object InputValue, bool OverrideValue)
        {
            try
            {
                string Request = "";
                STD_PARTY POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.SHIPPING_ADDRESS_LIST.Where(x => x.add_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.location.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.del_address = POPUPEntityObject.SrNo;
                    MasterEntity.add_code_del = POPUPEntityObject.add_code;
                    MasterEntity.delivery_address = POPUPEntityObject.location;
                    MasterEntity.country_nm_s = POPUPEntityObject.country_name;      
                    MasterEntity.state_nm_s = POPUPEntityObject.state_name;
                    MasterEntity.city_s = POPUPEntityObject.city;
                    MasterEntity.address1_s = POPUPEntityObject.address1;
                    MasterEntity.address2_s = POPUPEntityObject.address2;
                    MasterEntity.pincode_s = POPUPEntityObject.pin;
                    MasterEntity.buss_place = POPUPEntityObject.buss_place;


                    List<ACC_M013> tempTax = new List<ACC_M013>();
                    if (MasterEntity.buss_place == null)
                    {
                        tempTax = SelectedTaxList; // SelectedTaxList.Where(T => T.base_code_id == 1 || T.base_code_id == 2 || T.base_code_id == 3).ToList();
                        TaxDictoneryParent = tempTax.ToDictionary(X => X.id.ToString(), X => (object)X.description);
                    }
                    else if(MasterEntity.buss_place == ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(x => x.comp_code.Equals(MasterEntity.comp_code, StringComparison.OrdinalIgnoreCase) == true && x.location_Id.Equals(MasterEntity.location_Id, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].buss_place)
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
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertSeller(object InputValue)
        {
            try
            {
                string Request = "";
                STD_PERSONNEL POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PERSONNEL_LIST.Where(x => x.emp_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.emp_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PERSONNEL>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.EmpId = POPUPEntityObject.emp_id;
                    MasterEntity.sales_person_cd = POPUPEntityObject.emp_id;
                    MasterEntity.seller_name = POPUPEntityObject.emp_name;
                    MasterEntity.EmpEmailId = POPUPEntityObject.email_id;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertFilterSeller(object InputValue)
        {
            try
            {
                string Request = "";
                STD_PERSONNEL POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PERSONNEL_LIST.Where(x => x.emp_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.emp_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PERSONNEL>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.fltr_SalesPersonID = POPUPEntityObject.emp_id;
                    MasterEntity.fltr_SalesPersonNM = POPUPEntityObject.emp_name;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertSelectedTax(object InputValue)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.GL_LIST.Where(x => x.gl_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
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
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
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
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertPayTerm(object InputValue)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PAY_TERM_LIST.Where(x => x.p_term_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.p_term_code = POPUPEntityObject.p_term_code;
                    MasterEntity.p_term = POPUPEntityObject.p_term;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertCurrency(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M037 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.CURRENCY_LIST.Where(x => x.curr_code.Equals((Request ?? AppSessionState.curr_code), StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                if (POPUPEntityObject != null)
                {
                    STD_LIST_BE KEY_OBJ = null;
                    MasterEntity.curr_code = POPUPEntityObject.curr_code;
                    MasterEntity.symbol = POPUPEntityObject.symbol;
                    Request = "GET_KEY_DATA!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + (MasterEntity.doc_type ?? doc_cat_vm) + "!@" + Convert.ToDateTime(MasterEntity.sodate).ToString("MM/dd/yyyy") + "!@" + MasterEntity.curr_code + "!@" + AppSessionState.CntryCurncy + "!@" + MasterEntity.PartyId;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, Request, "SEL_T001_BL", "SDM", "GET_KEY_DATA", 0, "");

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
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
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
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertdgShipToParty(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                STD_PARTY POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PARTY_LIST.Where(x => x.party_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.party_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null && ItemEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if(ItemEntityObject != null) //if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        ItemEntityObject.ship_to_Party = POPUPEntityObject.party_code;
                        ItemEntityObject.ship_to_add = POPUPEntityObject.ship_to_add;
                    }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertSchShipToParty(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "";
                string RequestParameterData = "";
                STD_PARTY POPUPEntityObject = null;
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
                            POPUPEntityObject = MC.PARTY_LIST.Where(x => x.party_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true
                                                                  || x.party_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null && ItemEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    List<SEL_T002_A> temp = ItemScheduleEntity.ToList();
                    temp = ItemScheduleEntity.Where(x => x.ItemCode == ItemEntityObject.ItemCode).ToList();

                    if (temp.Count > dgSelectedIndexItemSchedule) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        SelectedItemScheduleEntity.ship_to_party = POPUPEntityObject.party_code;
                        SelectedItemScheduleEntity.ship_to_party_name = POPUPEntityObject.party_name;
                        RequestParameterData = "LoadShipToPartyDetails" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + (SelectedItemScheduleEntity.ship_to_party ?? MasterEntity.ship_to_party);
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, RequestParameterData, "SEL_T001_BL", "SDM", "", 0, "");
                        foreach (var item in MCTemp.SHIPPING_ADDRESS_LIST)
                        {
                            int IndexOfExistValue = MC.SHIPPING_ADDRESS_LIST.IndexOf(MC.SHIPPING_ADDRESS_LIST.Where(X => X.party_code == POPUPEntityObject.party_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.
                            if (IndexOfExistValue == -1)
                            {
                                MC.SHIPPING_ADDRESS_LIST.Add(item);
                            }
                        }

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).location);
                        TheFilter = (o, prefix) => (((STD_PARTY)o).location ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).add_code.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                        AS_SHIPPING_ADDRESS = new AutoSuggestTextViewModel<dynamic>(MCTemp.SHIPPING_ADDRESS_LIST, TheFilter, SuggestedValue, "ship_to_addNm", "Location", true);
                        AS_SHIPPING_ADDRESS.AutoSuggestVM.IsEmptyValueAllowed = true;

                        if (MCTemp.SHIPPING_ADDRESS_LIST.Count == 0)
                        {
                            SelectedItemScheduleEntity.ship_to_add = null;
                            SelectedItemScheduleEntity.add_code_del = null;
                            SelectedItemScheduleEntity.ship_to_addNm = "";
                        }
                        if (MCTemp.SHIPPING_ADDRESS_LIST.Count == 1)
                        {
                            SelectedItemScheduleEntity.ship_to_add = "";
                            SelectedItemScheduleEntity.add_code_del = null;
                            SelectedItemScheduleEntity.ship_to_addNm = "";

                            SelectedItemScheduleEntity.ship_to_add = MCTemp.SHIPPING_ADDRESS_LIST[0].SrNo.ToString();
                            SelectedItemScheduleEntity.add_code_del = MCTemp.SHIPPING_ADDRESS_LIST[0].add_code.ToString();
                            SelectedItemScheduleEntity.ship_to_addNm = MCTemp.SHIPPING_ADDRESS_LIST[0].location;
                        }
                        else if (MCTemp.SHIPPING_ADDRESS_LIST.Count > 1)
                        {
                            SelectedItemScheduleEntity.ship_to_add = "";
                            SelectedItemScheduleEntity.add_code_del = null;
                            SelectedItemScheduleEntity.ship_to_addNm = "";

                            var DeliveryAddress = (from o in MCTemp.SHIPPING_ADDRESS_LIST where o.add_type == "Delivery Address" select o).ToList();
                            if (DeliveryAddress.Count == 0)
                            {
                                SelectedItemScheduleEntity.ship_to_add = "";
                                SelectedItemScheduleEntity.add_code_del = null;
                                SelectedItemScheduleEntity.ship_to_addNm = "";
                            }
                            else if (DeliveryAddress.Count == 1)
                            {
                                SelectedItemScheduleEntity.ship_to_add = "";
                                SelectedItemScheduleEntity.add_code_del = null;
                                SelectedItemScheduleEntity.ship_to_addNm = "";

                                SelectedItemScheduleEntity.ship_to_add = DeliveryAddress[0].SrNo.ToString();
                                SelectedItemScheduleEntity.add_code_del = DeliveryAddress[0].add_code.ToString();
                                SelectedItemScheduleEntity.ship_to_addNm = DeliveryAddress[0].location;
                            }
                            else if (DeliveryAddress.Count > 1)
                            {
                                SelectedItemScheduleEntity.ship_to_add = "";
                                SelectedItemScheduleEntity.add_code_del = null;
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
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertSchShipToAddress(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                STD_PARTY POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.SHIPPING_ADDRESS_LIST.Where(x => x.location.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
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
                        SelectedItemScheduleEntity.add_code_del = POPUPEntityObject.add_code.ToString();
                        SelectedItemScheduleEntity.ship_to_addNm = POPUPEntityObject.location;

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
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertElement(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                PMS_T002 POPUPEntityObject = null;
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
                                if (doc_cat_vm == "CO") // If doc_cat is CO then it is Contract so only Project need to link with Contract.
                                {
                                    POPUPEntityObject = MC.ELEMENT_LIST.Where(x => x.project_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                                }
                                else // rest all is consider as Sales order so only Element of Project need to link.
                                {
                                    POPUPEntityObject = MC.ELEMENT_LIST.Where(x => x.element_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                                }
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PMS_T002>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null && ItemEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    ItemEntityObject.element_id = POPUPEntityObject.element_id;
                    ItemEntityObject.element_no = POPUPEntityObject.element_no;

                    MasterEntity.element_no = POPUPEntityObject.element_no;
                    MasterEntity.element_id = POPUPEntityObject.element_id;
                    MasterEntity.project_id = POPUPEntityObject.project_id;
                    MasterEntity.project_name = POPUPEntityObject.project_name;
                    MasterEntity.element_name = POPUPEntityObject.element_name;
                }
                else if (POPUPEntityObject != null)
                {
                    MasterEntity.element_no = POPUPEntityObject.element_no;
                    MasterEntity.element_id = POPUPEntityObject.element_id;
                    MasterEntity.project_id = POPUPEntityObject.project_id;
                }

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
        //            //if (MasterEntity.comp_code != POPUPEntityObject.comp_code)
        //            //{
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;
        //            LoadInitialData(MasterEntity.comp_code, (MasterEntity.location_Id ?? AppSessionState.OBJ_LOCATION.location_id));
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;
        //            // if company change then update related data which is applicable i.e. Company, Plant, Location, Sales Organisation, Sales Group till Sales area, related popup collections, Store Location and subsequent data of Store code. 
        //            // Following 2 Task is important in case of company change.
        //            //1) set null value to related fields of Entity i.e. Plant, Organisation and groups etc. 
        //            //2) Set defaults values for Plant, Organisation and groups etc.,
        //            ScheduleEntity.comp_code = MasterEntity.comp_code;
        //            List<STD_LIST_BE> ORG_LIST_OBJ = MC.ORG_LIST.Where(item => item.comp_code == MasterEntity.comp_code).ToList();
        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).so_code);
        //            TheFilter = (o, prefix) => (((STD_LIST_BE)o).so_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).so_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //            AS_ORG = new AutoSuggestTextViewModel<dynamic>(ORG_LIST_OBJ, TheFilter, SuggestedValue, "so_code", true);
        //            AS_ORG.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ORG.AutoSuggestVM.IsFreeTextAllowed = false;
        //            if (ORG_LIST_OBJ.Count == 1)
        //            {
        //                MasterEntity.so_code = ORG_LIST_OBJ[0].so_code;
        //                MasterEntity.sales_org = ORG_LIST_OBJ[0].so_name;
        //            }
        //            List<ADM_M0003> LOC_LIST_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == MasterEntity.comp_code).ToList();
        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
        //            TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //            AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_id", true);
        //            AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = true;
        //            if (LOC_LIST_OBJ.Count == 1)
        //            {
        //                MasterEntity.location_Id = LOC_LIST_OBJ[0].location_id;
        //                MasterEntity.LoctnNm = LOC_LIST_OBJ[0].location_name;
        //                ScheduleEntity.location_Id = MasterEntity.location_Id;
        //            }
        //            else
        //            {
        //                MasterEntity.location_Id = null;
        //                MasterEntity.LoctnNm = null;
        //                ScheduleEntity.location_Id = null;
        //            }
        //            MasterEntity.org_country_cd = ((List<ADM_M002>)AppSessionState.ADM_M002_List).Where(x => x.comp_code == MasterEntity.comp_code).ToList()[0].country_code;

        //        }
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
        //    }
        //}
        //private void InsertLocation(object InputValue)
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

        //            MasterEntity.LoctnNm = POPUPEntityObject.location_name;
        //            ScheduleEntity.location_Id = MasterEntity.location_Id;

        //            if (string.IsNullOrWhiteSpace(MasterEntity.location_Id) == false && SelectedTaxList != null)
        //            {
        //                List<ACC_M013> tempTax = new List<ACC_M013>();
        //                if (MasterEntity.buss_place == null)
        //                {
        //                    tempTax = SelectedTaxList; // SelectedTaxList.Where(T => T.base_code_id == 1 || T.base_code_id == 2 || T.base_code_id == 3).ToList();
        //                    TaxDictoneryParent = tempTax.ToDictionary(X => X.id.ToString(), X => (object)X.description);
        //                }
        //                else if (MasterEntity.buss_place == ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(x => x.comp_code.Equals(MasterEntity.comp_code, StringComparison.OrdinalIgnoreCase) == true && x.location_Id.Equals(MasterEntity.location_Id, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].buss_place)
        //                {
        //                    tempTax = SelectedTaxList.Where(T => T.base_code_id == 1 || T.base_code_id == 2 || T.base_code_id == null).ToList();
        //                    TaxDictoneryParent = tempTax.ToDictionary(X => X.id.ToString(), X => (object)X.description);
        //                }
        //                else if (MasterEntity.buss_place != ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(x => x.comp_code.Equals(MasterEntity.comp_code, StringComparison.OrdinalIgnoreCase) == true && x.location_Id.Equals(MasterEntity.location_Id, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].buss_place)
        //                {
        //                    tempTax = SelectedTaxList.Where(T => T.base_code_id == 3 || T.base_code_id == null).ToList();
        //                    TaxDictoneryParent = tempTax.ToDictionary(X => X.id.ToString(), X => (object)X.description);
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
        //    }
        //}
        private void InsertSalseOrg(object InputValue)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.ORG_LIST.Where(x => x.so_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.so_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.so_code = POPUPEntityObject.so_code;
                    MasterEntity.sales_org = POPUPEntityObject.so_name;

                    List<STD_LIST_BE> GROUP_LIST_OBJ = MC.ORG_GROUP_LIST.Where(item => item.so_code == MasterEntity.so_code).ToList();
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).sg_code);
                    TheFilter = (o, prefix) => (((STD_LIST_BE)o).sg_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).sg_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    AS_ORG_GROUP = new AutoSuggestTextViewModel<dynamic>(GROUP_LIST_OBJ, TheFilter, SuggestedValue, "sg_code", true);
                    AS_ORG_GROUP.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ORG_GROUP.AutoSuggestVM.IsFreeTextAllowed = false;
                    if (GROUP_LIST_OBJ.Count == 1)
                    {
                        MasterEntity.sg_code = GROUP_LIST_OBJ[0].sg_code;
                        MasterEntity.sg_name = GROUP_LIST_OBJ[0].sg_name;
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertSalseGroup(object InputValue)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.ORG_GROUP_LIST.Where(x => x.sg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.sg_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
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
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
                        { POPUPEntityObject = MC.TR_MODE_LIST.Where(x => x.tr_mode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
                        { POPUPEntityObject = MC.TR_MODE_LIST.Where(x => x.tr_mode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertBuyer(object InputValue) // Para10
        {
            try
            {
                string Request = "";
                STD_PARTY POPUPEntityObject = null;
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
                                POPUPEntityObject = MC.PARTY_CONTACT_LIST.Where(x => x.full_name.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.full_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }

                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.cp_code = POPUPEntityObject.cp_code;
                    MasterEntity.buyer = POPUPEntityObject.SrNo;
                    MasterEntity.buyer_name = POPUPEntityObject.full_name;
                    MasterEntity.mail_id = POPUPEntityObject.email;
                    MasterEntity.mobile_no = POPUPEntityObject.mobile;
                    PersonEmailId = POPUPEntityObject.email;


                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
                            { POPUPEntityObject = MC.LicenceList.Where(x => x.lic_cod.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
                            { POPUPEntityObject = MC.LicenceList.Where(x => x.lic_cod.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertIncoterms(object InputValue)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.INCOTERM_LIST.Where(x => x.incoterm.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.incoterms = POPUPEntityObject.incoterm;
                    MasterEntity.inco_desc = POPUPEntityObject.inco_desc;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertdgIncoterms(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.INCOTERM_LIST.Where(x => x.incoterm.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                }

                #endregion


                if (POPUPEntityObject != null && ItemEntityObject != null)
                {
                    if (dgSelectedIndexItemLicence >= 0 && LicenceDetailsEntity.Count > dgSelectedIndexItemLicence) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<ACC_T006_D> temp = LicenceDetailsEntity.ToList();
                        temp = (from o in temp where o.ItemCode == ItemEntityObject.ItemCode select o).ToList();
                        temp[dgSelectedIndexItemLicence].incoterms = POPUPEntityObject.incoterm;
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
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private async void InsertItem(object InputValue, decimal? item_qty, string bom_no,string long_text)
        {
            try
            {
                string Request = "";
                STD_ITEM POPUPEntityObject = null;
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
                            POPUPEntityObject = MC.STD_ITEM_LIST.Where(x => x.item_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.item_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_ITEM>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null && ItemEntityObject != null)
                {
                    if (item_qty.HasValue)
                    {
                        if (item_qty > 0)
                        {
                            try
                            {
                                ItemEntityObject = ItemsEntity.Where(x => x.ItemCode == POPUPEntityObject.item_code && x.bom_no == bom_no && x.item_cat == "EXD").ToList()[0];
                            }
                            catch (Exception ex)
                            {
                                ItemEntityObject = new SEL_T001_A();
                                ItemsEntity.Add(ItemEntityObject);
                            }

                            InsertItemCategory("EXD", false, true, true);
                            POPUPEntityObject.line_cat = "EXD";
                        }
                        else // if not Sales BOM then normal line_cat and relevent delivery & Billing will update.
                        {
                            InsertItemCategory(POPUPEntityObject.line_cat, false, true, true);
                        }
                    } // if not Sales BOM then normal line_cat and relevent delivery & Billing will update.
                    else
                    {
                        InsertItemCategory(POPUPEntityObject.line_cat, false, true, true);
                    }



                    if (ItemEntityObject.id == 0)
                    {
                        if (ItemEntityObject.line_id == 0)
                        {
                            ItemEntityObject.line_id = ItemsEntity.Count;
                        }

                        ItemEntityObject.ref_doc_type = MasterEntity.ref_doc_type;
                        ItemEntityObject.ref_doc_no = MasterEntity.ref_doc_no;

                        ItemEntityObject.ItemCode = POPUPEntityObject.item_code;
                        ItemEntityObject.quantity = 1; // NOTE: set this in setting as per document else leave null.
                        ItemEntityObject.Description = POPUPEntityObject.item_name;
                        ItemEntityObject.CstmrItmCod = POPUPEntityObject.item_code_party;
                        ItemEntityObject.active = true;
                        ItemEntityObject.sku = POPUPEntityObject.sku;
                        ItemEntityObject.sku_desc = POPUPEntityObject.sku_desc;
                        ItemEntityObject.tax_id = default_tax ?? POPUPEntityObject.tax_id;
                        ItemEntityObject.unit_code = POPUPEntityObject.unit_code;
                        ItemEntityObject.unit_price = POPUPEntityObject.unit_price;
                        ItemEntityObject.item_cat = POPUPEntityObject.line_cat;
                        ItemEntityObject.SubCatCode = POPUPEntityObject.item_subcat;
                        ItemEntityObject.StockUnt = POPUPEntityObject.ind_sku;

                        ItemEntityObject.ship_to_Party = MasterEntity.ship_to_party;
                        ItemEntityObject.ship_to_add = MasterEntity.del_address;
                        ItemEntityObject.buss_place = MasterEntity.buss_place;
                        ItemEntityObject.qty_price = 1;
                        ItemEntityObject.price_qty = POPUPEntityObject.unit_price;
                        ItemEntityObject.price_qty_uom = POPUPEntityObject.unit_code;
                        ItemEntityObject.weight_unit = POPUPEntityObject.weight_unit;
                        ItemEntityObject.volume_unit = POPUPEntityObject.volume_unit;
                        //ItemEntityObject.rel_billing = POPUPEntityObject.rel_billing;
                        //ItemEntityObject.rel_delivery = POPUPEntityObject.rel_delivery;
                        ItemEntityObject.discount_type = POPUPEntityObject.discount_type;
                        ItemEntityObject.discount = POPUPEntityObject.discount;
                        ItemEntityObject.discount_amt = POPUPEntityObject.discount;
                        ItemEntityObject.bom_no = (bom_no ?? POPUPEntityObject.bom_no);
                        //ItemEntityObject.cust_mat_no = POPUPEntityObject.equip_no; // it pick only first occurance of the row. so user need to insert from seperate popup
                        //NOTE: following line need to make sure that it is for Master or item Level.
                        MasterEntity.weight_unit = POPUPEntityObject.weight_unit;
                        MasterEntity.volume_unit = POPUPEntityObject.volume_unit;

                        if(item_qty.HasValue)
                        {
                            if (item_qty > 0)
                            {
                                ItemEntityObject.quantity = item_qty ?? POPUPEntityObject.qty;
                            }
                            ItemEntityObject.textdata = long_text;
                        }
                        if (POPUPEntityObject.qty.HasValue) // BOM Componant unit_price
                        {
                            ItemEntityObject.quantity = POPUPEntityObject.qty;
                        }
                        
                            InsertTaskList(ItemEntityObject.ItemCode);// Insert Tsk list no for RS doc_type.

                        // Folowing code will load popup list and default value if single exists for Customer Equipment for Repair & Maintainance.
                        var Obj_LIST = MC.STD_ITEM_LIST.Where(x => x.item_code.Equals(ItemEntityObject.ItemCode, StringComparison.OrdinalIgnoreCase) == true).ToList();
                        if (Obj_LIST != null)
                        {
                            ASSET_LIST = Obj_LIST;
                            if (Obj_LIST.Count == 1)
                            {
                                ItemEntityObject.cust_mat_no = Obj_LIST[0].equip_no;
                            }
                        }
                    }
                    else if (ItemEntityObject.ItemCode != POPUPEntityObject.ItemCode)
                    {
                        ItemEntityObject.ItemCode = null;
                        ItemEntityObject.Description = null;
                    }

                    if (SelectedItemScheduleEntity != null)
                    {
                        SelectedItemScheduleEntity.line_id = ItemScheduleEntity.Count;
                        SelectedItemScheduleEntity.item_line_id = ItemEntityObject.line_id;
                        SelectedItemScheduleEntity.so_item_id = ItemEntityObject.id;
                        SelectedItemScheduleEntity.ItemCode = ItemEntityObject.ItemCode;
                        SelectedItemScheduleEntity.unit_code = ItemEntityObject.unit_code;
                        SelectedItemScheduleEntity.sku = ItemEntityObject.sku;
                        SelectedItemScheduleEntity.order_qty = ItemEntityObject.quantity ?? 0;
                        SelectedItemScheduleEntity.PartyNm = ItemScheduleEntity.Count > 0 ? ItemScheduleEntity[0].PartyNm : MasterEntity.TranParty_name;
                        SelectedItemScheduleEntity.ship_mode = ItemScheduleEntity.Count > 0 ? ItemScheduleEntity[0].ship_mode : MasterEntity.ship_mode;
                        SelectedItemScheduleEntity.PartyId = ItemScheduleEntity.Count > 0 ? MasterEntity.transporter_cd : MasterEntity.transporter_cd;
                        SelectedItemScheduleEntity.del_qty = ItemScheduleEntity[0].bal_qty;
                        SelectedItemScheduleEntity.sch_qty = ItemScheduleEntity[0].bal_qty;
                        SelectedItemScheduleEntity.rate = ItemEntityObject.price_qty;
                    }


                    InsertQty(null); 
                    if (!string.IsNullOrWhiteSpace(POPUPEntityObject.tax_code) && ItemEntityObject != null)
                    {
                        
                        TotalDocumentTaxes.Clear();
                        foreach (var item in ItemsEntity)
                        {
                            ItemEntityObject = item;
                            Computation(true, AutoRoundupEnable);
                        }
                    }
                }
                
            }
            catch(Exception ex)
            { }
        }
        private void InsertTaskList(string item_code) 
        {
            // NOTE: 
            var ListData = (from o in MC.MASTER_TASK_LIST where o.item_code == item_code select o).ToList();// This will load data only for RS doc type for repaire & Maintiancence, Need task list exists for this doc_type. we can load for other doc_type also if required. change login in SP for that.
            TASK_LIST = ListData;

            if (ListData != null) // set fefault value if single item in list
            {
                if(ListData.Count==1)
                {
                    ItemEntityObject.tl_code = ListData[0].doc_no;
                }
            }

        }
        private void InsertPartner(object InputValue)
        {
            try
            {
                STD_LIST_BE PARA_OBJ = new STD_LIST_BE();
                

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    PARA_OBJ.ts_code = ts_code_vm;
                    PARA_OBJ.type_code = InputValue.ToString(); // type of Partner SP: Sold to Party, SH: Ship to, BP=Bill To, PP: Payer etc

                    if (MasterEntity != null)
                    {
                        if (!string.IsNullOrEmpty(MasterEntity.PartyId))
                        {
                            PARA_OBJ.party_code = MasterEntity.PartyId;
                            PARA_OBJ.add_code = MasterEntity.add_code_bil;
                            //PARA_OBJ.add_code_del = MasterEntity.add_code_del;
                            //PARA_OBJ.cp_code = MasterEntity.cp_code;
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void InsertSupplier(object InputValue) // Item supplier
        {
            try
            {
                CursorControl.SetBusyState();
                STD_LIST_BE PARA_OBJ = new STD_LIST_BE();

                if (ItemEntityObject != null)
                {
                    PARA_OBJ.ts_code = ts_code_vm;
                    PARA_OBJ.type_code = InputValue.ToString(); // type of Partner SP: Sold to Party, SH: Ship to, BP=Bill To, PP: Payer etc

                    if (MasterEntity != null && ItemEntityObject != null)
                    {
                        if (!string.IsNullOrEmpty(ItemEntityObject.ItemCode) && !string.IsNullOrEmpty(ItemEntityObject.supp_code))
                        {
                            string Request = "LOAD_SOLD_TO_PARTY" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + (MasterEntity.doc_type ?? doc_type_vm) + "!@" + Convert.ToDateTime(MasterEntity.sodate).ToString("MM/dd/yyyy") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + ItemEntityObject.supp_code + "!@" + MasterEntity.curr_code + "!@" + (MasterEntity.catalogue_code ?? "") + "!@" + (ItemEntityObject.ItemCode ?? "");
                            MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, Request, "SEL_T001_BL", "SDM", "", 0, "");

                            if (MCTemp.STD_ITEM_LIST != null)
                            {
                                if (MCTemp.STD_ITEM_LIST.Count > 0)
                                {
                                    if (MCTemp.STD_ITEM_LIST[0].party_code == ItemEntityObject.PartyId) // This is to filter ig data exists or fetch from generic catlog, because it get data form generic if no party specifc data is exists, we cannot make party compulsory in query
                                    {
                                        ItemEntityObject.unit_price = MCTemp.STD_ITEM_LIST[0].unit_price;
                                        ItemEntityObject.price_qty = MCTemp.STD_ITEM_LIST[0].unit_price;
                                    }
                                }
                            }
                        }
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void NotificationMessageReceived(NotificationMessage msg) // This is for Customer adding while creating SO
        {
            STD_LIST_BE OBJ_GEN = new STD_LIST_BE();
            if (msg.Sender != null)
            {
                if (msg.Sender.GetType() == typeof(STD_LIST_BE))
                {
                    OBJ_GEN = (STD_LIST_BE)msg.Sender;

                    if (OBJ_GEN != null)
                    {
                        if (OBJ_GEN.type_code != null && OBJ_GEN.ts_code == ts_code_vm) // Get signal from SDM_M0021_VM Save Button command
                        {
                            if (OBJ_GEN.type_code == "SP")
                            {
                                MasterEntity.PartyId = OBJ_GEN.party_code;
                                MasterEntity.party_name = OBJ_GEN.party_name;
                                MasterEntity.add_code_bil = OBJ_GEN.add_code;
                                MasterEntity.cp_code = OBJ_GEN.cp_code;
                                MasterEntity.bill_address_id = OBJ_GEN.id;
                                MasterEntity.p_term_code = OBJ_GEN.pt_code;
                                MasterEntity.p_term = OBJ_GEN.pt_name;
                                MasterEntity.curr_code = OBJ_GEN.curr_code ?? AppSessionState.curr_code;

                                // This section created to match to call InsertSoldToParty from Child window of new customer.
                                List<STD_PARTY> OBJ_PARTY_LIST = new List<STD_PARTY>();
                                STD_PARTY OBJ_PARTY = new STD_PARTY();
                                OBJ_PARTY.party_code = OBJ_GEN.party_code;
                                OBJ_PARTY.party_name = OBJ_GEN.party_name;
                                OBJ_PARTY.p_term_code = OBJ_GEN.pt_code;
                                OBJ_PARTY.curr_code = OBJ_GEN.curr_code;
                                OBJ_PARTY.symbol = OBJ_GEN.symbol;
                                OBJ_PARTY.add_code = OBJ_GEN.add_code;
                                OBJ_PARTY.cp_code = OBJ_GEN.cp_code;

                                OBJ_PARTY_LIST.Add(OBJ_PARTY);
                                InsertSoldToParty(OBJ_PARTY_LIST, true);

                            }
                            if (OBJ_GEN.type_code == "SH")
                            {
                                MasterEntity.ship_to_party = OBJ_GEN.party_code;
                                MasterEntity.ship_to_party_name = OBJ_GEN.party_name;
                                MasterEntity.add_code_del = OBJ_GEN.add_code;
                                MasterEntity.del_address = OBJ_GEN.id;

                                // This section created to match to call InsertSoldToParty from Child window of new customer.
                                List<STD_PARTY> OBJ_PARTY_LIST = new List<STD_PARTY>();
                                STD_PARTY OBJ_PARTY = new STD_PARTY();
                                OBJ_PARTY.party_code = OBJ_GEN.party_code;
                                OBJ_PARTY.party_name = OBJ_GEN.party_name;
                                OBJ_PARTY.add_code = OBJ_GEN.add_code;
                                OBJ_PARTY.cp_code = OBJ_GEN.cp_code;

                                OBJ_PARTY_LIST.Add(OBJ_PARTY);
                                InsertShipToParty(OBJ_PARTY_LIST, true);

                            }
                        }
                    }
                }
            }
        }
        private void InsertQty(object item_code) // Sales BOM fetch and add all componant with line category
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(ItemEntityObject.bom_no) && ItemEntityObject.quantity.HasValue && ItemEntityObject.quantity > 0 && (MasterEntity.doc_cat != "CO" || MasterEntity.ref_doc_type != "CO"))
                {
                    CursorControl.SetBusyState();
                    string Request = "SDM_BOM_EXPLODE" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@" + ItemEntityObject.bom_no + "!@" + ItemEntityObject.ItemCode + "!@" + ItemEntityObject.quantity.ToString() + "!@" + ItemEntityObject.unit_code;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, Request, "SEL_T001_BL", "SDM", "", 0, "");

                    if (MCTemp.BOM_LIST != null)
                    {
                        if (MCTemp.BOM_LIST.Count > 0)
                        {
                            InsertItemCategory("EXH", false, true, true);
                            foreach (var item in MCTemp.BOM_LIST)
                            {
                                InsertItem(item.item_code, item.qty, item.bom_no, item.long_text);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void CheckPrice(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {

            try
            {
                unit_price = Convert.ToDecimal(InputValue);
                string Request = ItemEntityObject.ItemCode;
                STD_ITEM POPUPEntityObject = null;
                POPUPEntityObject = MC.STD_ITEM_LIST.Where(x => x.item_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                if (POPUPEntityObject.high_value != null && POPUPEntityObject.low_value != null && POPUPEntityObject.high_value != 0 && POPUPEntityObject.low_value != 0 && ItemEntityObject != null)
                {
                    if (unit_price > POPUPEntityObject.high_value || unit_price < POPUPEntityObject.low_value)
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Unit Price Exceeds than Catlog Price ...", this.Title); sms.ShowMessage();
                        ItemEntityObject.alert1 = sms.Text;
                    }
                    else
                    {
                        ItemEntityObject.alert1 = null;
                    }

                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
                        //TCEntityObject.seq_no = POPUPEntityObject.seq_no;
                        TCEntityObject.short_text = POPUPEntityObject.short_text;
                        TCEntityObject.con_group = POPUPEntityObject.con_group;
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
                            //obj_tcnew.seq_no = TCEntityObject.seq_no ?? item.seq_no;
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
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void CreateBillingPlan(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "CREATE_BILLING_PLAN" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + REQUEST_PARA_OBJ.location_id + "!@" + doc_cat_vm + "!@" + (REQUEST_PARA_OBJ.doc_type ?? "") + "!@" + MasterEntity.sono + "!@" + AppSessionState.UserID + "!@" + (Utilities.NullIf(REQUEST_PARA_OBJ.emp_id) ?? AppSessionState.EmpId) + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + (REQUEST_PARA_OBJ.party_code ?? "") + "!@" + REQUEST_PARA_OBJ.active + "!@" + REQUEST_PARA_OBJ.t_status;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, Request, "SEL_T001_BL", "SDM", "LoadAll", 0, "");

                if(MCTemp.BillingPlanEntity != null)
                {
                    if (MCTemp.BillingPlanEntity.Count > 0)
                    {
                        BillingPlanEntity = MCTemp.BillingPlanEntity;
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        
        private void InsertUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                UOMS POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.UOM_LIST.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<UOMS>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null && ItemEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if(ItemEntityObject != null) //if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
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
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertUOMPriceQty(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                UOMS POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.UOM_LIST.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<UOMS>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null && ItemEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if(ItemEntityObject != null) //if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
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
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertItemCategory(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.LINE_CAT_LIST.Where(x => x.item_cat_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }
                #endregion
                if (POPUPEntityObject != null && ItemEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    ItemEntityObject.item_cat = POPUPEntityObject.item_cat_code;
                    ItemEntityObject.rel_billing = POPUPEntityObject.rel_billing;
                    ItemEntityObject.rel_delivery = POPUPEntityObject.rel_delivery;
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
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        //NOTE
        // Summary:
        //     This Method load Document Data for Reference document and for Flip DataGrid.
        //     Call for two seperate purpose
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            EntityChangeEnable = false;
            CursorControl.SetBusyState();
            try
            {
                CursorControl.SetBusyState();
                string RequestParameterData = "";
                string Request = "";
                string ParametersStringValue = "";
                STD_LIST_BE ParameterEntityObject = null;

                if (ParameterObject != null)
                {
                    if (ParameterObject.GetType() == typeof(string) && ParameterObject != null)
                    {
                        Request = ParameterObject.ToString();
                        if (Request.Length > 0)
                        {
                            Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@!@!@!@" + Request;
                            isNewRecord = false;
                        }
                    }
                    else if (((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList()[0];
                        Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + (MasterEntity.comp_code ?? ParameterEntityObject.comp_code) + "!@" + (MasterEntity.location_Id ?? ParameterEntityObject.location_id) + "!@" + doc_cat_vm + "!@" + (MasterEntity.doc_type ?? ParameterEntityObject.doc_type) + "!@" + ParameterEntityObject.doc_no + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + ParameterEntityObject.party_code;
                        isNewRecord = false;

                        RequestParameterData = "LOAD_SOLD_TO_PARTY" + "!@" + AppSessionState.client + "!@" + (MasterEntity.comp_code ?? ParameterEntityObject.comp_code) + "!@" + (MasterEntity.location_Id ?? ParameterEntityObject.location_id) + "!@" + doc_cat_vm + "!@" + (MasterEntity.doc_type ?? ParameterEntityObject.doc_type) + "!@" + Convert.ToDateTime(MasterEntity.sodate).ToString("MM/dd/yyyy") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + (MasterEntity.ship_to_party ?? ParameterEntityObject.party_code_ship) + "!@" + (MasterEntity.curr_code ?? ParameterEntityObject.curr_code);
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, RequestParameterData, "SEL_T001_BL", "SDM", "", 0, "");
                        
                        MC.STD_ITEM_LIST = MCTemp.STD_ITEM_LIST;
                        ITEM_COLLECTION = CollectionViewSource.GetDefaultView(MC.STD_ITEM_LIST);
                        ITEM_COLLECTION.Filter = new Predicate<object>(FLTR_ITEM);

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code);
                        TheFilter = (o, prefix) => ((STD_ITEM)o).item_code.ToString().ToLower().Contains(prefix.ToLower()) || ((STD_ITEM)o).item_name.ToString().ToLower().Contains(prefix.ToLower());
                        AS_ITEM = new AutoSuggestTextViewModel<dynamic>(MC.STD_ITEM_LIST, TheFilter, SuggestedValue, "ItemCode", "item_code", true);
                        AS_ITEM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ITEM.AutoSuggestVM.IsFreeTextAllowed = true;

                        

                    }
                }

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, Request, "SEL_T001_BL", "SDM", "LOAD_DOC_BY_DOC_NO", 0, "");

                MC.PARTY_CONTACT_LIST = MCTemp.PARTY_CONTACT_LIST;
                MC.BILLING_ADDRESS_LIST = MCTemp.BILLING_ADDRESS_LIST;
                MC.SHIPPING_ADDRESS_LIST = MCTemp.SHIPPING_ADDRESS_LIST;
                MC.CONDITION_LIST = MCTemp.CONDITION_LIST;
                ReleaseList = MCTemp.WORKFLOW_LIST;
                TermsConditionCollection = CollectionViewSource.GetDefaultView(MC.CONDITION_LIST);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0051)x).tc_code);
                TheFilter = (o, prefix) => (((ADM_M0051)o).tc_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0051)o).con_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0051)o).long_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_TERMS_CONDITION = new AutoSuggestTextViewModel<dynamic>(MC.CONDITION_LIST, TheFilter, SuggestedValue, "tc_code", "tc_code", true);
                AS_TERMS_CONDITION.AutoSuggestVM.IsEmptyValueAllowed = true;


                if (MCTemp.ItemsEntity != null)
                {
                    if (MCTemp.ItemsEntity.Count > 0)
                    {
                        ItemsEntity.Clear();
                        MasterEntity = MCTemp.MasterEntity[0];
                        PersonEmailId = MCTemp.MasterEntity[0].PersonEmailId;
                        PartyEmailId = MCTemp.MasterEntity[0].PartyEmailId;
                        ItemsEntity = MCTemp.ItemsEntity;
                        BillingPlanEntity = new ObservableCollection<ACC_T021>();

                    }
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
                if (MCTemp.ATTACHMENT_LIST != null)
                {
                    AttachmentCollection = MCTemp.ATTACHMENT_LIST;
                }
                else
                {
                    MCTemp.ATTACHMENT_LIST = new List<COM_T003>();
                }
                if (MCTemp.TermsAndCondition != null)
                {
                    TermsConditionEntity = MCTemp.TermsAndCondition;
                }
                else
                {
                    MCTemp.TermsAndCondition = new ObservableCollection<GEN_T011>();
                }
                if (MCTemp.PartnerEntity != null)
                {
                    PartnerEntity = MCTemp.PartnerEntity;
                }
                else
                {
                    MCTemp.PartnerEntity = new ObservableCollection<SEL_T001_PART>();
                }

                SelectedTabControlIndex = 0;
                AttachmentCount = MCTemp.ATTACHMENT_LIST.Count;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).full_name);
                TheFilter = (o, prefix) => (((STD_PARTY)o).full_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_BUYER = new AutoSuggestTextViewModel<dynamic>(MC.PARTY_CONTACT_LIST, TheFilter, SuggestedValue, "buyer_name", true);
                AS_BUYER.AutoSuggestVM.IsEmptyValueAllowed = true; AS_BUYER.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).add_code.ToString());
                TheFilter = (o, prefix) => ((STD_PARTY)o).add_code.ToString().ToString().ToLower().Contains(prefix.ToLower()) || ((STD_PARTY)o).location.ToString().ToLower().Contains(prefix.ToLower());
                AS_BILLING_ADDRESS = new AutoSuggestTextViewModel<dynamic>(MC.BILLING_ADDRESS_LIST, TheFilter, SuggestedValue, "add_code_bil", true);
                AS_BILLING_ADDRESS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_BILLING_ADDRESS.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).add_code.ToString());
                TheFilter = (o, prefix) => ((STD_PARTY)o).add_code.ToString().ToString().ToLower().Contains(prefix.ToLower()) || ((STD_PARTY)o).location.ToString().ToLower().Contains(prefix.ToLower());
                AS_SHIPPING_ADDRESS = new AutoSuggestTextViewModel<dynamic>(MC.SHIPPING_ADDRESS_LIST, TheFilter, SuggestedValue, "add_code_del", true);
                AS_SHIPPING_ADDRESS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_SHIPPING_ADDRESS.AutoSuggestVM.IsFreeTextAllowed = true;

                //foreach (var item in ItemsEntity)
                //{
                //    ItemEntityObject = item;
                //    Computation(true, AutoRoundupEnable);
                //}


                if (MasterEntity != null) // added this to end part of this code block because MCTemp is already used in above request, it will ovewrite in this section.
                {
                    if (!string.IsNullOrWhiteSpace(MasterEntity.ship_to_party))
                    {
                        
                        // item list refresh for ship to party if catlog exists
                        RequestParameterData = "LOAD_SHIP_TO_PARTY" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + MasterEntity.ship_to_party;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, RequestParameterData, "SEL_T001_BL", "SDM", "", 0, "");
                        //MC.SHIPPING_ADDRESS_LIST = MCTemp.SHIPPING_ADDRESS_LIST; // NOT: double assignment, no need here because it covers in load document query

                        if (MCTemp.STD_ITEM_LIST != null)
                        {
                            if (MCTemp.STD_ITEM_LIST.Count > 0)
                            {
                                MC.STD_ITEM_LIST = MCTemp.STD_ITEM_LIST;
                                ITEM_COLLECTION = CollectionViewSource.GetDefaultView(MC.STD_ITEM_LIST);
                                ITEM_COLLECTION.Filter = new Predicate<object>(FLTR_ITEM);

                                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code);
                                TheFilter = (o, prefix) => ((STD_ITEM)o).item_code.ToString().ToLower().Contains(prefix.ToLower()) || ((STD_ITEM)o).item_name.ToString().ToLower().Contains(prefix.ToLower());
                                AS_ITEM = new AutoSuggestTextViewModel<dynamic>(MC.STD_ITEM_LIST, TheFilter, SuggestedValue, "ItemCode", "item_code", true);
                                AS_ITEM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ITEM.AutoSuggestVM.IsFreeTextAllowed = true;
                            }
                        }

                    }
                }



                MasterEntity.ts_code = ts_code_vm;
                EntityChangeEnable = true;
                //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void ExecuteReferenceDocuments(object ParameterObject, string ParameterReference)
        {
            try
            {
                CursorControl.SetBusyState();
                EntityChangeEnable = false;
                string Request = "";
                string RequestParameter = "";
                //string ref_doc_cat_value = "";
                string ParametersStringValue = "";
                //STD_LIST_BE ParameterEntityObject = null;

                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {

                    if (DocumentList == null || DocumentList == "")
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Referance No", this.Title); sms.ShowMessage();
                    }
                    else
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
                            {
                                Request = "EXECUTE_DOC_BY_REF_DOC" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + (MasterEntity.doc_type ?? doc_type_vm)  + "!@" + MasterEntity.ref_doc_cat + "!@" + ParametersStringValue;
                                //ref_doc_cat_value = MasterEntity.ref_doc_type;
                                
                            }
                            catch (Exception ex) { }
                        }

                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, Request, "SEL_T001_BL", "SDM", "EXECUTE_DOC_BY_REF_DOC", 0, "");
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
                            MC.PARTY_CONTACT_LIST = MCTemp.PARTY_CONTACT_LIST;
                            MC.BILLING_ADDRESS_LIST = MCTemp.BILLING_ADDRESS_LIST;
                            MC.SHIPPING_ADDRESS_LIST = MCTemp.SHIPPING_ADDRESS_LIST;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).full_name);
                            TheFilter = (o, prefix) => ((STD_PARTY)o).full_name.ToString().ToLower().Contains(prefix.ToLower()) || ((STD_PARTY)o).cp_code.ToString().ToLower().Contains(prefix.ToLower());
                            AS_BUYER = new AutoSuggestTextViewModel<dynamic>(MC.PARTY_CONTACT_LIST, TheFilter, SuggestedValue, "buyer_name", true);
                            AS_BUYER.AutoSuggestVM.IsEmptyValueAllowed = true; AS_BUYER.AutoSuggestVM.IsFreeTextAllowed = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).add_code.ToString());
                            TheFilter = (o, prefix) => ((STD_PARTY)o).add_code.ToString().ToString().ToLower().Contains(prefix.ToLower()) || ((STD_PARTY)o).location.ToString().ToLower().Contains(prefix.ToLower());
                            AS_BILLING_ADDRESS = new AutoSuggestTextViewModel<dynamic>(MC.BILLING_ADDRESS_LIST, TheFilter, SuggestedValue, "add_code_bil", true);
                            AS_BILLING_ADDRESS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_BILLING_ADDRESS.AutoSuggestVM.IsFreeTextAllowed = true;

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).add_code.ToString());
                            TheFilter = (o, prefix) => ((STD_PARTY)o).add_code.ToString().ToString().ToLower().Contains(prefix.ToLower()) || ((STD_PARTY)o).location.ToString().ToLower().Contains(prefix.ToLower());
                            AS_SHIPPING_ADDRESS = new AutoSuggestTextViewModel<dynamic>(MC.SHIPPING_ADDRESS_LIST, TheFilter, SuggestedValue, "add_code_del", true);
                            AS_SHIPPING_ADDRESS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_SHIPPING_ADDRESS.AutoSuggestVM.IsFreeTextAllowed = true;


                            if (MCTemp.MasterEntity[0].PartyId != MCTemp.MasterEntity[0].referring_party)
                            {
                                var refdoctemp = (from o in MC.PARTY_LIST where o.party_type == "Supplier/Customer" select o).ToList();

                                for (int i = 0; i < refdoctemp.Count; i++)
                                {
                                    if (MCTemp.MasterEntity[0].PartyId == refdoctemp[i].party_code)
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
                                        MasterEntity.referring_party = refdoctemp[i].party_code;
                                        MasterEntity.referring_party_name = refdoctemp[i].party_name;
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
                        var ManualTaxList = (from o in MCTemp.TaxEntity where o.manual == "Manual" select o).ToList();

                        //int count = ItemsEntity.Count();
                        TotalDocumentTaxes.Clear();
                        foreach (var item in ItemsEntity)
                        {
                            ItemEntityObject = item;
                            Computation(true, AutoRoundupEnable);
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
                            MCTemp.TermsAndCondition = new ObservableCollection<GEN_T011>();
                        }
                        if (MCTemp.PartnerEntity != null)
                        {
                            PartnerEntity = MCTemp.PartnerEntity;
                        }
                        else
                        {
                            MCTemp.PartnerEntity = new ObservableCollection<SEL_T001_PART>();
                        }
                    }
                }
                if (ParameterReference == "ReferenceDocument")
                {
                    //MasterEntity.ref_doc_no = MasterEntity.sono;
                    //MasterEntity.ref_doc_date = MasterEntity.sodate;
                    //MasterEntity.ref_doc_type = MasterEntity.doc_type;
                    MasterEntity.shipped = false;
                    MasterEntity.shipped_date = null;
                    MasterEntity.doc_cat = doc_cat_vm;
                    MasterEntity.doc_type = doc_cat_vm;
                    MasterEntity.doc_type_user = doc_cat_vm;
                    MasterEntity.doc_desc = "Standard Order";
                    MasterEntity.sono = "";
                    MasterEntity.sodate = DateTime.Now;
                    MasterEntity.add_by = AppSessionState.UserID;
                    MasterEntity.editby = AppSessionState.UserID;
                    MasterEntity.userid = AppSessionState.UserID;
                    MasterEntity.active = true;
                    MasterEntity.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
                    MasterEntity.t_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_display).FirstOrDefault();
                    MasterEntity.shipped = false;
                    MasterEntity.version = "v1.0";
                    ScheduleEntity.t_status = MasterEntity.t_status;
                    ScheduleEntity.t_display = MasterEntity.t_display;
                    ScheduleEntity.cp_code = MasterEntity.cp_code;
                    ScheduleEntity.sch_date = DateTime.Now;
                    ScheduleEntity.active = true;
                    ScheduleEntity.add_by = AppSessionState.UserID;
                    ScheduleEntity.id = 0;
                    isNewRecord = true;

                }
                MasterEntity.ts_code = ts_code_vm;
                MasterEntity.user_source1 = AppSessionState.UserSource1;
                MasterEntity.user_source2 = AppSessionState.UserSource2;

                
                if (MasterEntity.ref_doc_type == "CO" && !string.IsNullOrWhiteSpace(ParametersStringValue))
                {
                    RequestParameter = "GET_BOM_ITEM_LIST" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + (MasterEntity.doc_type ?? doc_type_vm) + "!@" + Convert.ToDateTime(MasterEntity.sodate).ToString("MM/dd/yyyy") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + MasterEntity.PartyId + "!@" + MasterEntity.curr_code + "!@" + ParametersStringValue; // NOTE: We put this request also here because all values not available later after executing above requested server trip. ref_doc_cat and all fields set to null after server trip and assignment of new result to Master and item Entity.
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, RequestParameter, "SEL_T001_BL", "SDM", "", 0, "");
                    MC.STD_ITEM_LIST = MCTemp.STD_ITEM_LIST;

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code);
                    TheFilter = (o, prefix) => ((STD_ITEM)o).item_code.ToString().ToLower().Contains(prefix.ToLower()) || ((STD_ITEM)o).item_name.ToString().ToLower().Contains(prefix.ToLower());
                    AS_ITEM = new AutoSuggestTextViewModel<dynamic>(MCTemp.STD_ITEM_LIST, TheFilter, SuggestedValue, "ItemCode", "item_code", true);
                    AS_ITEM.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ITEM.AutoSuggestVM.IsFreeTextAllowed = false;

                }

                EntityChangeEnable = true;
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void ActiveInactiveTax(bool select)
        {
            Computation(true, AutoRoundupEnable); 
        }
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i && ItemEntityObject.id == 0)
                {
                    ItemsEntity.RemoveAt(i);
                    foreach (var item in ItemsEntity)
                    {
                        ItemEntityObject = item;
                        Computation(true, AutoRoundupEnable);
                    }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
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
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        
        private void DeleteDataGridRowPF(SEL_T001_PART InputValue)
        {
            try
            {
                
                if (PartnerEntity.Count > 0 && PFEntityObject.id==0)
                {
                    PartnerEntity.Remove(InputValue);
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void DeleteDataGridRow_ItemSchedule(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemScheduleEntity.Count > i)
                {
                    ItemScheduleEntity.RemoveAt(i);
                    //Computation(true, AutoRoundupEnable); 
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void DeleteDataGridRow_ItemLicence(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (LicenceDetailsEntity.Count > i)
                {
                    LicenceDetailsEntity.RemoveAt(i);
                    Computation(true, AutoRoundupEnable);
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertManualTaxChangedCommand(object InputValue)
        {
            try
            {
                Computation(true, AutoRoundupEnable);
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
                    Computation(true, AutoRoundupEnable);
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void unitconversion()
        {
            try
            {
                var CurrantUnitCF = (from o in MC.UOM_CONVERSION_LIST where (o.unit_code == PreviousUnitCode) select o).ToList();
                var NewUnitCF = (from o in MC.UOM_CONVERSION_LIST where (o.unit_code == NewUnitCode) select o).ToList();
                if (CurrantUnitCF.Count > 0 && NewUnitCF.Count > 0 && ItemEntityObject != null)
                {
                    ItemEntityObject.quantity = (ItemEntityObject.quantity * CurrantUnitCF[0].c_factor) / NewUnitCF[0].c_factor;
                    ItemEntityObject.unit_price = (ItemEntityObject.unit_price / CurrantUnitCF[0].c_factor) * NewUnitCF[0].c_factor;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void PriceComputation(string PreviousUnit, string NewUnit, string Source)
        {
            try
            {
                if (ItemEntityObject != null) // ItemsEntity.Count > 0 && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < ItemsEntity.Count
                {
                    if (ItemEntityObject.qty_price > 0 && ItemEntityObject.price_qty > 0 && string.IsNullOrWhiteSpace(ItemEntityObject.price_qty_uom) == false)
                    {
                        if (Source == "QtyUnit")
                        {
                            var PreviousUnitCF = (from o in MC.UOM_CONVERSION_LIST where (o.unit_code == PreviousUnit) select o).ToList();
                            var NewUnitCF = (from o in MC.UOM_CONVERSION_LIST where (o.unit_code == NewUnit) select o).ToList();

                            if (PreviousUnitCF.Count > 0 && NewUnitCF.Count > 0)
                            {
                                ItemEntityObject.quantity = (ItemEntityObject.quantity * PreviousUnitCF[0].c_factor) / NewUnitCF[0].c_factor;
                                ItemEntityObject.unit_price = (ItemEntityObject.unit_price / PreviousUnitCF[0].c_factor) * NewUnitCF[0].c_factor;
                            }
                        }
                        else if (Source == "PriceUnit")
                        {
                            var PreviousUnitCF = (from o in MC.UOM_CONVERSION_LIST where (o.unit_code == PreviousUnit) select o).ToList();
                            var NewUnitCF = (from o in MC.UOM_CONVERSION_LIST where (o.unit_code == NewUnit) select o).ToList();

                            if (PreviousUnitCF.Count > 0 && NewUnitCF.Count > 0)
                            {
                                ItemEntityObject.qty_price = (ItemEntityObject.qty_price * PreviousUnitCF[0].c_factor) / NewUnitCF[0].c_factor;
                            }
                        }

                        decimal? UnitPrice_Qty = 0;
                        string QtyUnit = ItemEntityObject.unit_code;
                        string PriceUnit = ItemEntityObject.price_qty_uom;
                        var QtyUnitCF = (from o in MC.UOM_CONVERSION_LIST where (o.unit_code == QtyUnit) select o).ToList();
                        var PriceUnitCF = (from o in MC.UOM_CONVERSION_LIST where (o.unit_code == PriceUnit) select o).ToList();
                        decimal? qty = ItemEntityObject.quantity;
                        decimal? qty_of_price = ItemEntityObject.qty_price;
                        decimal? price_of_qty = ItemEntityObject.price_qty;
                        if (QtyUnitCF != null && PriceUnitCF != null)
                        {
                            if (QtyUnitCF.Count > 0 && PriceUnitCF.Count > 0)
                            {
                                UnitPrice_Qty = ((((qty * QtyUnitCF[0].c_factor) / PriceUnitCF[0].c_factor) / qty_of_price) * price_of_qty) / qty;
                                ItemEntityObject.unit_price = decimal.Round(Convert.ToDecimal(UnitPrice_Qty), 4, MidpointRounding.AwayFromZero);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        string DocumentList = "";
        private void AddSelectedReferenceDocument(object InputValue)
        {
            try
            {
                STD_LIST_BE POPUPEntityObject = null;
                string Request;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.REF_DOC_LIST.Where(x => x.ref_doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ref_doc_no = POPUPEntityObject.ref_doc_no;
                    MasterEntity.ref_doc_cat = POPUPEntityObject.ref_doc_cat;
                    DocumentList = "";
                    foreach (var item in MC.REF_DOC_LIST)
                    {
                        if (item.ref_doc_cat != POPUPEntityObject.ref_doc_cat)
                        {
                            item.selected = false;
                        }
                    }
                    List<STD_LIST_BE> REF_DOC_OBJ = (from o in MC.REF_DOC_LIST where o.ref_doc_cat == POPUPEntityObject.ref_doc_cat select o).ToList();
                    var REF_DOC_TEMP = from o in REF_DOC_OBJ
                                    where o.party_code == POPUPEntityObject.party_code
                                        && o.party_name == POPUPEntityObject.party_name
                                        && o.so_code == POPUPEntityObject.so_code
                                        && o.curr_code == POPUPEntityObject.curr_code
                                        && o.ref_doc_cat == POPUPEntityObject.ref_doc_cat
                                        && o.ref_doc_type == POPUPEntityObject.ref_doc_type
                                        && o.incoterm == POPUPEntityObject.incoterm
                                        && o.country_key == POPUPEntityObject.country_key
                                    select o;
                    foreach (var item in REF_DOC_TEMP)
                    {
                        if (item.selected == true)
                        {
                            DocumentList = DocumentList + "," + item.ref_doc_no;
                        }
                    }
                    DocumentList = DocumentList.ToString().TrimStart(new char[] { ',' });
                    REF_DOC_COLLECTION = CollectionViewSource.GetDefaultView(REF_DOC_TEMP);
                    REF_DOC_COLLECTION.Filter = new Predicate<object>(FLTR_REF_DOC);
                    if (DocumentList == "")
                    {
                        MasterEntity.ref_doc_no = null;
                        MasterEntity.ref_doc_cat = null;
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
                STD_DOC_TYPE POPUPEntityObject = null;
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
                STD_PARTY POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PARTY_LIST.Where(x => x.party_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_PARTY>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.fltr_SoldToPartyID = POPUPEntityObject.party_code;
                    MasterEntity.fltr_SoldToPartyNM = POPUPEntityObject.party_name;
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
                    Logging();
                    this.StatusMessage = "Saving changes, please wait ...";
                    MasterEntity.XmlDataDocument_SEL_T001_A = obj.ObjectToXML(ItemsEntity);
                    MasterEntity.XDOC_SEL_T001_PART = obj.ObjectToXML(PartnerEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_B = obj.ObjectToXML(TotalDocumentTaxes);
                    MasterEntity.XmlDataDocument_SEL_T002 = obj.ObjectToXML(ScheduleEntity);
                    MasterEntity.XmlDataDocument_SEL_T002_A = obj.ObjectToXML(ItemScheduleEntity);
                    MasterEntity.XDOC_TC = obj.ObjectToXML(TermsConditionEntity);
                    MasterEntity.XmlDataDocument_ACC_T006_D = obj.ObjectToXML(LicenceDetailsEntity);
                    

                    this.MasterEntity.EndEdit();
                    
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<SEL_T001>(MasterEntity, "SEL_T001_BL", "SDM");
                        SetBusinessEntitiesAfterLoad("Save", "");
                        if (MasterEntity.sono != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnInsert") >= 0)
                        {
                            NotifyMessage("OnInsert","Created");
                        }
                        if (MasterEntity.sono != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnApproval") >= 0)
                        {
                            NotifyMessage("OnApproval", "Created");
                        }
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<SEL_T001>(MasterEntity, "SEL_T001_BL", "SDM");
                        SetBusinessEntitiesAfterLoad("Save", "");
                        if (MasterEntity.sono != null && NotificationDataCollection.Exists(element => element.alert_name == "OnUpdate") == true)
                        {
                            NotifyMessage("OnUpdate", "Modified");
                        }
                    }
                    if (MasterEntity.sono != null || MasterEntity.sono != "" && MasterEntity.active == true)
                    {
                        TabIndexItem = 0; // This is for shifting focus from Editor control
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record saved Successfully ........", this.Title); sms.ShowMessage();
                    }
                    isNewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                }
                RemoveRefDoc();
                
                //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
                        MC.REF_DOC_LIST.RemoveAll(X => X.ref_doc_no == item);
                    }
                    List<STD_LIST_BE> REF_DOC_TEMP = (from o in MC.REF_DOC_LIST where o.ref_doc_cat != null select o).ToList();
                    REF_DOC_COLLECTION = CollectionViewSource.GetDefaultView(REF_DOC_TEMP);
                    REF_DOC_COLLECTION.Filter = new Predicate<object>(FLTR_REF_DOC);
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        protected override void OnCreateAction(InquiryActionResult<SEL_T001> result)
        {
            try
            {
                isNewRecord = true;
                DocumentList = "";
                foreach (var item in MC.REF_DOC_LIST)
                {
                    if (item.selected == true)
                    {
                        item.selected = false;
                    }
                }
                //var refdoctempa = (from o in MC.REF_DOC_LIST where o.doc_cat == doc_cat_vm select o).ToList();
                REF_DOC_COLLECTION = CollectionViewSource.GetDefaultView(MC.REF_DOC_LIST);
                REF_DOC_COLLECTION.Filter = new Predicate<object>(FLTR_REF_DOC);
                MasterEntity = new SEL_T001();
                ItemsEntity = new ObservableCollection<SEL_T001_A>();
                TotalDocumentTaxes = new ObservableCollection<ACC_T006_B>();
                TotalDocumentTaxesSummury = new ObservableCollection<ACC_T006_B>();
                TotalDocumentTaxesItem = new ObservableCollection<ACC_T006_B>();
                ScheduleEntity = new SEL_T002();
                TermsConditionEntity = new ObservableCollection<GEN_T011>();
                PartnerEntity = new ObservableCollection<SEL_T001_PART>();
                ItemScheduleEntity = new ObservableCollection<SEL_T002_A>();
                LicenceDetailsEntity = new ObservableCollection<ACC_T006_D>();
                ItemEntityObject = null;
                TCEntityObject = null;
                BillingPlanEntity = new ObservableCollection<ACC_T021>();
                DefaultValues();
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
        protected override void OnPrintAction(InquiryActionResult<SEL_T001> result)
        {
            CursorControl.SetBusyState();
            EntityChangeEnable = false;
            try
            {
                string Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.sono;
                string ReportName = "";
                string tempLocation = MasterEntity.location_Id;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_SDM_BE>(MCTemp, Request, "SEL_T001_BL", "SDM", "LOAD_DOC_BY_DOC_NO", 0, "");
                object[] objDataSource = new object[8];
                string[] objDataSourceName = new string[8];
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
                objDataSource[7] = ReleaseList;

                objDataSourceName[0] = "dsMaster";
                objDataSourceName[1] = "dsItemEntity";
                objDataSourceName[2] = "dsTaxEntity";
                objDataSourceName[3] = "dsCompany";
                objDataSourceName[4] = "dsLocation";
                objDataSourceName[5] = "dsScheduleEntity";
                objDataSourceName[6] = "dsTC";
                objDataSourceName[7] = "dsRS";


                ReportManager ReportManager = new ReportManager();

                var ReportStringList = (from o in MC.DOC_TYPE_LIST where o.doc_type == MasterEntity.doc_type select o).ToList();
                ReportName = ReportStringList[0].report_name.Split(',')[0];
                string ReportDisplayName = MasterEntity.party_name + "_" + MasterEntity.sono + "_" + MasterEntity.sodate.Value.ToShortDateString();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORTS_STD\\TXN\\" + ReportName, getParametersList(), ReportDisplayName);
                EntityChangeEnable = true;
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
            return result;
        }
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.sono))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.sono.Replace("/", "--"), DocumentList = AttachmentCollection, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<SEL_T001> result)
        {
            LoadInitialData(MasterEntity.comp_code, MasterEntity.location_Id);
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
                        Computation(true, AutoRoundupEnable);
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                //if (e.NewItems != null && e.NewItems.Count != 0)
                //    foreach (SEL_T001_A item in e.NewItems)
                //        item.PropertyChanged += this.MyType_PropertyChanged;

                //if (e.OldItems != null && e.OldItems.Count != 0)
                //    foreach (SEL_T001_A item in e.OldItems)
                //        item.PropertyChanged -= this.MyType_PropertyChanged;
                
                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (SEL_T001_A item in e.NewItems)
                    {

                        item.symbol = MasterEntity.symbol;
                        item.id = 0;
                        if(ItemsEntity != null)
                        {
                            if(item.line_id== 0 || item.line_id == null) // NOTE: This event calls twice and to protect this to increse same line_id twice, this if condition added on 14/12/2022, also update same logic to other VM. Also this logic added to check max value and then increase one, earlier it was assigning row count to new value but if there are 5 item and one deleted then it was assigning same number again.
                            {
                                int maxValue = ItemsEntity.Max(x => x.line_id);
                                item.line_id = maxValue + 1;
                            }

                            // Commented this function because Explode BOM was not working if qty already exists
                            //if ((MasterEntity.doc_type=="RS" || MasterEntity.doc_type == "SO") && (item.quantity == 0 || item.quantity == null)) // NOTE: This event calls twice and to protect this to increse same line_id twice, this if condition added on 14/12/2022, also update same logic to other VM. Also this logic added to check max value and then increase one, earlier it was assigning row count to new value but if there are 5 item and one deleted then it was assigning same number again.
                            //{
                            //    item.quantity = 1;
                            //}
                            //if (ItemsEntity.Count > 0)
                            //{
                            //    int maxValue = ItemsEntity.Max(x => x.line_id);
                            //    item.line_id = maxValue++;
                            //}
                            //else
                            //{
                            //    item.line_id = ItemsEntity.Count;
                            //}

                        }
                        else
                        {
                            item.line_id = 1;
                        }
                        item.active = true;
                        item.client = AppSessionState.client;

                        item.location_Id = (MasterEntity.location_Id ?? AppSessionState.OBJ_LOCATION.location_id);
                        item.comp_code = (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code);
                        item.t_status = MasterEntity.t_status;
                        item.t_display = MasterEntity.t_display;
                        item.order_to_plant = (MasterEntity.location_Id ?? AppSessionState.OBJ_LOCATION.location_id);
                        item.element_id = MasterEntity.element_id;
                        item.element_no = MasterEntity.element_no;
                      
                        //item.PropertyChanged += EntityViewModelPropertyChanged;

                        //SEL_T002_A ItemObject = new SEL_T002_A();
                        //ItemObject.sch_cat = "SD";
                        //ItemObject.del_rel = "Y";
                        //ItemObject.sono = MasterEntity.sono;
                        //ItemObject.active = true;
                        //ItemObject.editby = AppSessionState.UserID;
                        //ItemObject.add_by = AppSessionState.UserID;
                        //ItemObject.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                        //ItemObject.comp_code = MasterEntity.comp_code;
                        //ItemObject.t_status = MasterEntity.t_status;
                        //ItemObject.t_display = MasterEntity.t_display;
                        //ItemObject.exp_date = MasterEntity.expect_date;
                        //ItemObject.desp_date = MasterEntity.expect_date;
                        //ItemObject.rel_delivery = "Y";
                        //ItemObject.rel_billing = "Y";
                        
                        //ItemObject.sch_date = MasterEntity.sodate;
                        //ItemObject.tr_mode = MasterEntity.tr_mode;
                        //ItemObject.tr_name = MasterEntity.tr_name;
                        //ItemObject.tr_type = MasterEntity.tr_type;
                        //ItemObject.tr_party = MasterEntity.tr_party;
                        //ItemObject.ref_doc_cat = MasterEntity.doc_cat;
                        //ItemObject.ref_doc_no = MasterEntity.sono;
                        //ItemObject.ref_doc_date = MasterEntity.sodate;
                        //ItemObject.ref_doc_type = MasterEntity.ref_doc_type;
                        //ItemObject.ship_to_party = MasterEntity.ship_to_party;
                        //ItemObject.ship_to_add = MasterEntity.del_address.ToString();
                        //ItemObject.ship_to_addNm = MasterEntity.delivery_address;
                        //ItemObject.lead_time = 1;
                        //ItemObject.ref_no = MasterEntity.sono;

                        //ItemScheduleEntity.Add(ItemObject);
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                    this.ErrorExist = false;/*MasterEntity.HasErrors;*/
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
                                Computation(true, AutoRoundupEnable);
                            }
                        }

                    }

                    foreach (SEL_T001_A item in e.OldItems)
                    {
                        item.PropertyChanged -= EntityViewModelPropertyChanged;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Move)
                {
                }

            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void CollectionChangedNotifyForPartner(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (SEL_T001_PART item in e.NewItems)
                    {
                        item.active = "1";
                        item.client = AppSessionState.client;
                        item.comp_code = (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code);
                        item.doc_no = MasterEntity.sono;
                        PFEntityObject = item;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                    this.ErrorExist = false;/*MasterEntity.HasErrors;*/
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
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
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "PO Schedule Information"; sms.Text = String.Format("Schedule quantity exceeding Order limit. extra Quantity will required additional Sales Order", this.Title); sms.ShowMessage();
                    }
                    #endregion
                }
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForSchedule(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                //if (e.NewItems != null && e.NewItems.Count != 0)
                //    foreach (SEL_T002_A item in e.NewItems)
                //        item.PropertyChanged += this.Schedule_PropertyChanged;

                //if (e.OldItems != null && e.OldItems.Count != 0)
                //    foreach (SEL_T002_A item in e.OldItems)
                //        item.PropertyChanged -= this.Schedule_PropertyChanged;

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
                            item.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                            item.comp_code = MasterEntity.comp_code;
                            item.rate = 0;
                            item.line_id = 1;
                            item.lead_time = 1;

                            item.ship_to_party = MasterEntity.ship_to_party;
                            item.ship_to_party_name = MasterEntity.ship_to_party_name;
                            item.ship_to_add = MasterEntity.del_address.ToString();
                            item.add_code_del = MasterEntity.add_code_del.ToString();
                            item.ship_to_addNm = MasterEntity.delivery_address;
                            ScheduleEntity.cp_code = MasterEntity.cp_code;
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
                            item.rel_billing = ItemEntityObject.rel_billing;
                            item.rel_delivery = ItemEntityObject.rel_delivery;
                            item.del_rel = ItemEntityObject.rel_delivery;
                            item.tr_mode = MasterEntity.tr_mode;
                            item.tr_name = MasterEntity.tr_name;
                            item.tr_type = MasterEntity.tr_type;
                            item.tr_party = MasterEntity.tr_party;
                         

                            item.PropertyChanged += EntityViewModelPropertyChanged;
                        }
                        catch (Exception ex) { }
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                {}
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {}
                if (e.Action == NotifyCollectionChangedAction.Move)
                {}
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
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
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }

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
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
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
                        if (item.seq_no == 0 || item.seq_no == null) 
                        {
                            int? maxValue = TermsConditionEntity.Max(x => x.seq_no);
                            item.seq_no = (maxValue ?? 0) + 1;
                        }
                        item.active = "1";
                        item.comp_code = MasterEntity.comp_code;
                        item.doc_cat = (MasterEntity.doc_cat ?? doc_cat_vm);
                        TCEntityObject = item;
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
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                //This will get called when the property of an object inside the collection changes
                this.ErrorExist = false;/*MasterEntity.HasErrors;*/
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        //This will get called when the property of an object inside the collection changes
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            try
            {
                if (EntityChangeEnable == true)
                {
                    this.ErrorExist = false; /*MasterEntity.HasErrors;*/
                    if (sender.ToString() == "ind_trade" && MC.BANK_ACCOUNT_LIST != null)
                    {
                        FICO_M0004 POPUPEntityObject = MC.BANK_ACCOUNT_LIST.Where(x => (x.ind_trade ?? "X").Equals(MasterEntity.ind_trade ?? "", StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        if (POPUPEntityObject != null)
                        {
                            MasterEntity.bank_code = POPUPEntityObject.bank_code;
                            MasterEntity.bank_name = POPUPEntityObject.bank_name;
                            MasterEntity.hb_acc = POPUPEntityObject.hb_acc;
                        }
                    }

                    
                    if (sender.ToString() == "so_code")
                    {
                        List<STD_LIST_BE> GROUP_LIST_OBJ = MC.ORG_GROUP_LIST.Where(item => item.so_code == MasterEntity.so_code).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).sg_code);
                        TheFilter = (o, prefix) => (((STD_LIST_BE)o).sg_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).sg_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        AS_ORG_GROUP = new AutoSuggestTextViewModel<dynamic>(GROUP_LIST_OBJ, TheFilter, SuggestedValue, "sg_code", true);
                        AS_ORG_GROUP.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ORG_GROUP.AutoSuggestVM.IsFreeTextAllowed = false;
                        if (GROUP_LIST_OBJ.Count == 1)
                        {
                            MasterEntity.sg_code = GROUP_LIST_OBJ[0].sg_code;
                            MasterEntity.sg_name = GROUP_LIST_OBJ[0].sg_name;
                        }
                    }
                    if (sender.ToString() == "hb_acc")
                    {
                        if (!string.IsNullOrWhiteSpace(MasterEntity.hb_acc) && MC.BANK_ACCOUNT_LIST.Count > 0)
                        {
                            MasterEntity.bank_name = MC.BANK_ACCOUNT_LIST.Where(b => b.hb_acc == MasterEntity.hb_acc).ToList()[0].bank_name;
                            MasterEntity.bank_code = MC.BANK_ACCOUNT_LIST.Where(b => b.hb_acc == MasterEntity.hb_acc).ToList()[0].bank_code;
                        }
                    }
                    
                    if (sender.ToString() == "curr_code")
                    {
                        ADM_M037 curr_obj = new ADM_M037();
                        curr_obj = MC.CURRENCY_LIST.Where(x => x.curr_code == MasterEntity.curr_code).ToList()[0];
                        if (!MasterEntity.ex_rate.HasValue)
                        {
                            MasterEntity.ex_rate = curr_obj.exch_rate;
                        }
                        if (MasterEntity.roundup_total > 0)
                        {
                            MasterEntity.amt_inword = NOW_OBJ.AmountInWords(Convert.ToDecimal(MasterEntity.roundup_total), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word,curr_obj.word_format);
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
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            try
            {
                if (EntityChangeEnable == true)
                {
                    //This will get called when the property of an object inside the collection changes
                    if (sender.ToString() == "quantity" || sender.ToString() == "price_qty" || sender.ToString() == "qty_price" || sender.ToString() == "price_qty_uom")
                    {
                        PriceComputation(null, null, null);
                        Computation(true, AutoRoundupEnable);
                    }
                    else if (sender.ToString() == "line_id" || sender.ToString() == "unit_price" || sender.ToString() == "tax_id" || sender.ToString() == "active" || sender.ToString() == "discount_type" || sender.ToString() == "discount" || sender.ToString() == "discount_amt")
                    {
                        Computation(true, AutoRoundupEnable);
                        UpdateQtyInLicence();
                        if (ItemScheduleEntity.Count > 0 && ItemsEntity.Count > 0 && isNewRecord == true && ItemEntityObject != null)
                        {
                            var item = ItemScheduleEntity.FirstOrDefault(i => i.line_id == ItemEntityObject.line_id);
                            if (item != null)
                            {
                                item.sch_qty = ItemEntityObject.quantity ?? 0;
                            }
                        }
                        //if(sender.ToString() == "quantity" && ItemEntityObject != null)
                        //{
                        //    InsertQty(ItemEntityObject.ItemCode);
                        //}
                    }
                    else if (sender.ToString() == "gross_wt")
                    {
                        MasterEntity.gross_wt = ItemsEntity.Where(item => item.active != false).Sum(item => Convert.ToDecimal(item.gross_wt));
                        MasterEntity.weight_unit = ItemsEntity[0].weight_unit;
                    }
                    else if (sender.ToString() == "volume")
                    {
                        MasterEntity.volume = ItemsEntity.Where(item => item.active != false).Sum(item => Convert.ToDecimal(item.volume));
                        MasterEntity.volume_unit = ItemsEntity[0].volume_unit;
                    }
                    else if (sender.ToString() == "net_wt")
                    {
                        MasterEntity.net_wt = ItemsEntity.Where(item => item.active != false).Sum(item => Convert.ToDecimal(item.net_wt));
                    }
                    this.ErrorExist = false; /*MasterEntity.HasErrors;*/
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        void ModelUpdated_ScheduleMaster(object sender, EventArgs e)
        {
            if (EntityChangeEnable == true){}
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
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        #endregion
        #region User Defined Functions
        private void DefaultValues()
        {
            try
            {
                EntityChangeEnable = true;
                AutoRoundupEnable = true;
                RoundUpDecimals = 2;
                MasterEntity.curr_code = AppSessionState.curr_code;
                MasterEntity.doc_cat = doc_cat_vm;
                MasterEntity.doc_type = doc_type_vm;
                if (doc_type_vm == "RS")
                {
                    MasterEntity.title = "Service Order";
                }

                var OrderType = (from o in MC.DOC_TYPE_LIST where o.doc_cat == doc_cat_vm && o.doc_type==doc_type_vm select o).ToList(); //set by constructor doc_type
                if(OrderType==null || doc_type_vm==null)
                {
                    OrderType = (from o in MC.DOC_TYPE_LIST where o.doc_cat == doc_cat_vm && o.default_doc == true select o).ToList(); // set if constructor not get doc_type value
                }

                if (OrderType != null)
                {
                    if (OrderType.Count() == 1)
                    {
                        MasterEntity.doc_type = OrderType[0].doc_type;
                        MasterEntity.doc_type_user = OrderType[0].doc_type;
                        MasterEntity.doc_desc = OrderType[0].doc_type_name;
                        MasterEntity.ind_source = OrderType[0].ind_source; ; // NOTE: make it in setting wether defalut value for customer reference a per Company or sales Org. it is indicator for source refernce of customer or direct without any reference of commision.

                        MasterEntity.valid_from_date = MasterEntity.sodate ?? DateTime.UtcNow;
                        MasterEntity.valid_to_date = (MasterEntity.sodate ?? DateTime.UtcNow).AddDays(OrderType[0].valid_days ?? 90);
                        MasterEntity.validity_date = (MasterEntity.sodate ?? DateTime.UtcNow).AddDays(OrderType[0].valid_days ?? 90);
                    }
                }

                MasterEntity.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
                MasterEntity.t_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_display).FirstOrDefault();

                MasterEntity.sales_person_cd = AppSessionState.EmpId;
                MasterEntity.seller_name = AppSessionState.EmpName;
                MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                MasterEntity.order_to_plant = AppSessionState.OBJ_LOCATION.location_id;
                ScheduleEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                ScheduleEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;

                MasterEntity.active = true;
                MasterEntity.shipped = false;
                MasterEntity.version = "v1.0";
                MasterEntity.sodate = DateTime.Now;
                MasterEntity.ind_trade = "D";
                MasterEntity.net_value = 0;
                MasterEntity.other_charges = 0;
                MasterEntity.withholding_value = 0;
                MasterEntity.withholding_ex_amt = 0;
                MasterEntity.client = AppSessionState.client;
                MasterEntity.expect_date = DateTime.Now;
                MasterEntity.org_country_cd = ((List<ADM_M002>)AppSessionState.ADM_M002_List).Where(x => x.comp_code == AppSessionState.OBJ_COMPANY.comp_code).ToList()[0].country_code;
                if (MasterEntity.curr_code == AppSessionState.CntryCurncy)
                {
                    MasterEntity.ex_rate = 1;
                }
                ScheduleEntity.t_status = MasterEntity.t_status;
                ScheduleEntity.t_display = MasterEntity.t_display;
                ScheduleEntity.sch_date = DateTime.Now;
                ScheduleEntity.active = true;
                ScheduleEntity.add_by = AppSessionState.UserID;
                ScheduleEntity.editby = AppSessionState.UserID;
                ScheduleEntity.cp_code = MasterEntity.cp_code;
                ScheduleEntity.id = 0;
                ScheduleEntity.PartyId = MasterEntity.PartyId;

                DateTime d = DateTime.UtcNow;
                d = d.AddMonths(-1);
                REQUEST_PARA_OBJ.from_date = d;
                REQUEST_PARA_OBJ.to_date = DateTime.UtcNow;
                REQUEST_PARA_OBJ.active = true;
                REQUEST_PARA_OBJ.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                REQUEST_PARA_OBJ.location_id = AppSessionState.OBJ_LOCATION.location_id;

                MasterEntity.partshipment = "Not Allowed";
                MasterEntity.transhipment = "Not Allowed";

                if (MC.BANK_ACCOUNT_LIST != null)
                {
                    if (MC.BANK_ACCOUNT_LIST.Count == 1)
                    {
                        MasterEntity.hb_acc = MC.BANK_ACCOUNT_LIST[0].hb_acc;
                    }
                }
                if (MC.BANK_ACCOUNT_LIST.Where(x => x.ind_default == true && x.comp_code == MasterEntity.comp_code).ToList().Count > 0)
                {
                    MasterEntity.bank_code = MC.BANK_ACCOUNT_LIST.Where(x => x.ind_default == true).ToList()[0].bank_code;
                    MasterEntity.bank_name = MC.BANK_ACCOUNT_LIST.Where(x => x.ind_default == true).ToList()[0].bank_name;
                    MasterEntity.hb_acc = MC.BANK_ACCOUNT_LIST.Where(x => x.ind_default == true).ToList()[0].hb_acc;
                }
                if (MC.DOC_TYPE_LIST != null && !string.IsNullOrWhiteSpace(MasterEntity.doc_type))
                {
                    if (MC.DOC_TYPE_LIST.Count > 0)
                    {
                        AutoRoundupEnable = (bool)(MC.DOC_TYPE_LIST.Find(x => x.doc_type == MasterEntity.doc_type).auto_roundup ?? false);
                        RoundUpDecimals = (int)(MC.DOC_TYPE_LIST.Find(x => x.doc_type == MasterEntity.doc_type).roundup_digits ?? 2);
                    }
                }

                if(MC.ORG_LIST != null)
                {
                    if (MC.ORG_LIST.Count == 1)
                    {
                        MasterEntity.so_code = MC.ORG_LIST[0].so_code;
                        MasterEntity.sales_org = MC.ORG_LIST[0].so_name;

                        if (MC.ORG_GROUP_LIST != null)
                        {
                            List<STD_LIST_BE> GROUP_LIST_OBJ = MC.ORG_GROUP_LIST.Where(item => item.so_code == MasterEntity.so_code).ToList();
                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).sg_code);
                            TheFilter = (o, prefix) => (((STD_LIST_BE)o).sg_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).sg_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                            AS_ORG_GROUP = new AutoSuggestTextViewModel<dynamic>(GROUP_LIST_OBJ, TheFilter, SuggestedValue, "sg_code", true);
                            AS_ORG_GROUP.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ORG_GROUP.AutoSuggestVM.IsFreeTextAllowed = false;
                            if (GROUP_LIST_OBJ.Count == 1)
                            {
                                MasterEntity.sg_code = GROUP_LIST_OBJ[0].sg_code;
                                MasterEntity.sg_name = GROUP_LIST_OBJ[0].sg_name;
                            }
                        }

                    }
                }
                

            }

            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void Logging() // NOTE: shift this function in global service project to reduce same code once field final and remove non standard fields like add_by.edit_by,add_date,edit_date with userid only and date will manage in SP.
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
        private void LoadInitialData(string company,string plant)
        {
            CursorControl.SetBusyState();
            try
            {
                isNewRecord = true;
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + company + "!@" + plant + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + (MasterEntity.sono ?? "") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "");
                MC = repository_MC.GetDataWithReturnDomainObject<MC_SDM_BE>(MC, Request, "SEL_T001_BL", "SDM", "LoadAll", 0, "");


                PROJECT_LIST = MC.ELEMENT_LIST;
                SUPPLIER_LIST = MC.SUPPLIER_LIST;
                PRICE_LIST = MC.PRICE_LIST;

                #region Autosuggest

                LOCATION_LIST = MC.LOCATION_LIST;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).item_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).item_code ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower()) || (((STD_LIST_BE)o).item_name ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower());
                AS_DEFAULT = new AutoSuggestTextViewModel<dynamic>(MC.TRADE_INDICATOR, TheFilter, SuggestedValue, "item_code", "item_code", true);
                AS_DEFAULT.AutoSuggestVM.IsEmptyValueAllowed = true; AS_DEFAULT.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).item_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).gl_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_DEFAULT_1 = new AutoSuggestTextViewModel<dynamic>(MC.TRADE_INDICATOR, TheFilter, SuggestedValue, "item_code", "item_code", true);
                AS_DEFAULT_1.AutoSuggestVM.IsEmptyValueAllowed = true; AS_DEFAULT_1.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).item_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_DEFAULT_2 = new AutoSuggestTextViewModel<dynamic>(MC.TRADE_INDICATOR, TheFilter, SuggestedValue, "item_code", "item_code", true);
                AS_DEFAULT_2.AutoSuggestVM.IsEmptyValueAllowed = true; AS_DEFAULT_2.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).item_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_DEFAULT_3 = new AutoSuggestTextViewModel<dynamic>(MC.TRADE_INDICATOR, TheFilter, SuggestedValue, "item_code", "item_code", true);
                AS_DEFAULT_3.AutoSuggestVM.IsEmptyValueAllowed = true; AS_DEFAULT_3.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).item_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_DEFAULT_4 = new AutoSuggestTextViewModel<dynamic>(MC.TRADE_INDICATOR, TheFilter, SuggestedValue, "incoterms", "incoterms", true);
                AS_DEFAULT_4.AutoSuggestVM.IsEmptyValueAllowed = true; AS_DEFAULT_4.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).item_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_DEFAULT_5 = new AutoSuggestTextViewModel<dynamic>(MC.TRADE_INDICATOR, TheFilter, SuggestedValue, "incoterms", "incoterms", true);
                AS_DEFAULT_5.AutoSuggestVM.IsEmptyValueAllowed = true; AS_DEFAULT_5.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M0002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0002)o).comp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", true);
                AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = true;

                ScheduleEntity.comp_code = company; ScheduleEntity.location_Id = plant;

                //NOTE: keep anyone form the following or use company and org relation at the time of loading,not here.
                //List<STD_LIST_BE> ORG_LIST_OBJ = MC.ORG_LIST.Where(item => item.comp_code == company).ToList();
                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).so_code);
                //TheFilter = (o, prefix) => (((STD_LIST_BE)o).so_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).so_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //AS_ORG = new AutoSuggestTextViewModel<dynamic>(ORG_LIST_OBJ, TheFilter, SuggestedValue, "so_code", true);
                //AS_ORG.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ORG.AutoSuggestVM.IsFreeTextAllowed = false;
                //if (ORG_LIST_OBJ.Count == 1)
                //{
                //    MasterEntity.so_code = ORG_LIST_OBJ[0].so_code;
                //    MasterEntity.sales_org = ORG_LIST_OBJ[0].so_name;
                //}

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).so_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).so_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).so_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ORG = new AutoSuggestTextViewModel<dynamic>(MC.ORG_LIST, TheFilter, SuggestedValue, "so_code", true);
                AS_ORG.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ORG.AutoSuggestVM.IsFreeTextAllowed = false;
                if (MC.ORG_LIST.Count == 1)
                {
                    MasterEntity.so_code = MC.ORG_LIST[0].so_code;
                    MasterEntity.sales_org = MC.ORG_LIST[0].so_name;
                }

                List<STD_LIST_BE> GROUP_LIST_OBJ = MC.ORG_GROUP_LIST.Where(item => item.so_code == MasterEntity.so_code).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).sg_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).sg_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).sg_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ORG_GROUP = new AutoSuggestTextViewModel<dynamic>(GROUP_LIST_OBJ, TheFilter, SuggestedValue, "sg_code", true);
                AS_ORG_GROUP.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ORG_GROUP.AutoSuggestVM.IsFreeTextAllowed = false;
                if (GROUP_LIST_OBJ.Count == 1)
                {
                    MasterEntity.sg_code = GROUP_LIST_OBJ[0].sg_code;
                    MasterEntity.sg_name = GROUP_LIST_OBJ[0].sg_name;
                }

                List<ADM_M0003> LOC_LIST_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code)).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_id", true);
                AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = true;
                if (LOC_LIST_OBJ.Count == 1)
                {
                    MasterEntity.location_Id = LOC_LIST_OBJ[0].location_id;
                    MasterEntity.LoctnNm = LOC_LIST_OBJ[0].location_name;
                    ScheduleEntity.location_Id = MasterEntity.location_Id;
                }
                else
                {
                    MasterEntity.location_Id = null;
                    MasterEntity.LoctnNm = null;
                    ScheduleEntity.location_Id = null;
                }

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).ind_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).ind_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).ind_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_TRADE_INDICATOR = new AutoSuggestTextViewModel<dynamic>(MC.TRADE_INDICATOR, TheFilter, SuggestedValue, "ind_trade", true);
                AS_TRADE_INDICATOR.AutoSuggestVM.IsEmptyValueAllowed = false; AS_TRADE_INDICATOR.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM_PRICE_QTY = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "price_qty_uom", "unit_code", true);
                AS_UOM_PRICE_QTY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM_PRICE_QTY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).item_cat_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).item_cat_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).item_cat_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_LINE_CATEGORY = new AutoSuggestTextViewModel<dynamic>(MC.LINE_CAT_LIST, TheFilter, SuggestedValue, "item_cat", "item_cat_code", true);
                AS_LINE_CATEGORY.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_DOC_TYPE)x).doc_type);
                TheFilter = (o, prefix) => (((STD_DOC_TYPE)o).doc_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_DOC_TYPE)o).doc_type_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_DOC_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.DOC_TYPE_LIST, TheFilter, SuggestedValue, "doc_type", true);
                AS_DOC_TYPE.AutoSuggestVM.IsEmptyValueAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).party_code);
                TheFilter = (o, prefix) => (((STD_PARTY)o).party_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).party_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).place ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).mobile ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_SOLD_TO_PARTY = new AutoSuggestTextViewModel<dynamic>(MC.PARTY_LIST, TheFilter, SuggestedValue, "party_code", true);
                AS_SOLD_TO_PARTY.AutoSuggestVM.IsEmptyValueAllowed = true;AS_SOLD_TO_PARTY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).party_code);
                TheFilter = (o, prefix) => (((STD_PARTY)o).party_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).party_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_SHIP_TO_PARTY = new AutoSuggestTextViewModel<dynamic>(MC.PARTY_LIST, TheFilter, SuggestedValue, "party_code", true);
                AS_SHIP_TO_PARTY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_SHIP_TO_PARTY.AutoSuggestVM.IsFreeTextAllowed = true;

                List<STD_PARTY> COMPETOTOR_LIST_OBJ = MC.PARTY_LIST.Where(item => item.party_type == "009").ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).party_code);
                TheFilter = (o, prefix) => (((STD_PARTY)o).party_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).party_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COMPETITOR = new AutoSuggestTextViewModel<dynamic>(COMPETOTOR_LIST_OBJ, TheFilter, SuggestedValue, "para15", "party_code", true);
                AS_COMPETITOR.AutoSuggestVM.IsEmptyValueAllowed = true; AS_COMPETITOR.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M037)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_CURRENCY = new AutoSuggestTextViewModel<dynamic>(MC.CURRENCY_LIST, TheFilter, SuggestedValue, "curr_code", true);
                AS_CURRENCY.AutoSuggestVM.IsEmptyValueAllowed = false; AS_CURRENCY.AutoSuggestVM.IsFreeTextAllowed  = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id);
                TheFilter = (o, prefix) => (((STD_PERSONNEL)o).emp_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PERSONNEL)o).emp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_SALESMAN = new AutoSuggestTextViewModel<dynamic>(MC.PERSONNEL_LIST, TheFilter, SuggestedValue, "emp_id", true);
                AS_SALESMAN.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).incoterm);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).incoterm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).inco_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_INCOTERMS = new AutoSuggestTextViewModel<dynamic>(MC.INCOTERM_LIST, TheFilter, SuggestedValue, "incoterms", "incoterm", true);
                AS_INCOTERMS.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0051)x).tc_code);
                TheFilter = (o, prefix) => (((ADM_M0051)o).tc_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0051)o).con_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0051)o).long_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_TERMS_CONDITION = new AutoSuggestTextViewModel<dynamic>(MC.CONDITION_LIST, TheFilter, SuggestedValue, "tc_code", "tc_code", true);
                AS_TERMS_CONDITION.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M003_O_P)x).con_type);
                TheFilter = (o, prefix) => (((ACC_M003_O_P)o).con_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_O_P)o).con_desc ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_O_P)o).con_cat ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ACC_M003_O_P)o).pricing_pro ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_TAX_CONDITION_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.ConditionTypeList, TheFilter, SuggestedValue, "con_type", "con_type", false);
                AS_TAX_CONDITION_TYPE.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).p_term_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).p_term_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).p_term ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_PAY_TERMS = new AutoSuggestTextViewModel<dynamic>(MC.PAY_TERM_LIST, TheFilter, SuggestedValue, "p_term_code", true);
                AS_PAY_TERMS.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                AS_UOM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_STATUS = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_status", true);
                AS_STATUS.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).party_code);
                TheFilter = (o, prefix) => (((STD_PARTY)o).party_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).party_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_NOTIFY_PARTY_1 = new AutoSuggestTextViewModel<dynamic>(MC.PARTY_LIST, TheFilter, SuggestedValue, "party_code", true);
                AS_NOTIFY_PARTY_1.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).party_code);
                TheFilter = (o, prefix) => (((STD_PARTY)o).party_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).party_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_NOTIFY_PARTY_2 = new AutoSuggestTextViewModel<dynamic>(MC.PARTY_LIST, TheFilter, SuggestedValue, "party_code", true);
                AS_NOTIFY_PARTY_2.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).party_code);
                TheFilter = (o, prefix) => (((STD_PARTY)o).party_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).party_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_REF_PARTY = new AutoSuggestTextViewModel<dynamic>(MC.SUPPLIER_LIST, TheFilter, SuggestedValue, "party_code", true);
                AS_REF_PARTY.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).party_code);
                TheFilter = (o, prefix) => (((STD_PARTY)o).party_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).party_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_SUPPLIER = new AutoSuggestTextViewModel<dynamic>(MC.SUPPLIER_LIST, TheFilter, SuggestedValue, "party_code", true);
                AS_SUPPLIER.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M026)x).tr_mode);
                TheFilter = (o, prefix) => (((SYS_M026)o).tr_mode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M026)o).tr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_TR_MODE = new AutoSuggestTextViewModel<dynamic>(MC.TR_MODE_LIST, TheFilter, SuggestedValue, "tr_mode", true);
                AS_TR_MODE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_TR_MODE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((FICO_M0004)x).hb_acc);
                TheFilter = (o, prefix) => (((FICO_M0004)o).hb_acc ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((FICO_M0004)o).hb_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((FICO_M0004)o).bank_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((FICO_M0004)o).acc_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_HB_ACC = new AutoSuggestTextViewModel<dynamic>(MC.BANK_ACCOUNT_LIST, TheFilter, SuggestedValue, "hb_acc", true);
                AS_HB_ACC.AutoSuggestVM.IsEmptyValueAllowed = true; AS_HB_ACC.AutoSuggestVM.IsFreeTextAllowed = false;
                if (MC.BANK_ACCOUNT_LIST != null)
                {
                    if (MC.BANK_ACCOUNT_LIST.Count == 1)
                    {
                        MasterEntity.hb_acc = MC.BANK_ACCOUNT_LIST[0].hb_acc;
                        MasterEntity.bank_code = MC.BANK_ACCOUNT_LIST[0].hb_code;
                        MasterEntity.bank_name = MC.BANK_ACCOUNT_LIST[0].gl_name;
                    }
                }
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M041_P)x).lic_cod);
                TheFilter = (o, prefix) => (((ADM_M041_P)o).lic_cod ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M041_P)o).lic_type ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_LICENCE = new AutoSuggestTextViewModel<dynamic>(MC.LicenceList, TheFilter, SuggestedValue, "licence_no", "lic_cod", true);
                AS_LICENCE.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).gl_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).gl_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).gl_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_TAX_ACCOUNT = new AutoSuggestTextViewModel<dynamic>(MC.GL_LIST, TheFilter, SuggestedValue, "gl_code", "gl_code", true);
                AS_TAX_ACCOUNT.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PMS_T002)x).element_id);
                TheFilter = (o, prefix) => (((PMS_T002)o).element_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PMS_T002)o).element_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ELEMENT = new AutoSuggestTextViewModel<dynamic>(MC.ELEMENT_LIST, TheFilter, SuggestedValue, "element_id", "element_id", true);
                AS_ELEMENT.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).value_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).value_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).value_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_PFCODE = new AutoSuggestTextViewModel<dynamic>(MC.PF_CODE_LIST, TheFilter, SuggestedValue, "pf_code", "value_code", true);
                AS_PFCODE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_PFCODE.AutoSuggestVM.IsFreeTextAllowed = false;

                List<STD_PARTY> PF_PARTY_OBJ = MC.PARTY_LIST.Where(item => item.party_code != null).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).party_code);
                TheFilter = (o, prefix) => (((STD_PARTY)o).party_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).party_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_PF_PARTY = new AutoSuggestTextViewModel<dynamic>(PF_PARTY_OBJ, TheFilter, SuggestedValue, "party_code", "party_code", true);
                AS_PF_PARTY.AutoSuggestVM.IsEmptyValueAllowed = false; AS_PF_PARTY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).type_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).type_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).short_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_BILLING_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.TYPE_LIST, TheFilter, SuggestedValue, "type_code", "billing_type", true);
                AS_BILLING_TYPE.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).type_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).type_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).short_text ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_DATE_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.PARA_TYPE_LIST, TheFilter, SuggestedValue, "type_code", "date_type", true);
                AS_DATE_TYPE.AutoSuggestVM.IsEmptyValueAllowed = true;


                #endregion

                var REF_DOC_TEMP = (from o in MC.REF_DOC_LIST where o.ref_doc_cat != null select o).ToList();
                REF_DOC_COLLECTION = CollectionViewSource.GetDefaultView(REF_DOC_TEMP);
                REF_DOC_COLLECTION.Filter = new Predicate<object>(FLTR_REF_DOC);

                TermsConditionCollection = CollectionViewSource.GetDefaultView(MC.CONDITION_LIST);

                TaxDictonery = new Dictionary<string, object>();
                TaxDictonery.Clear();
                TaxDictonery = MC.TAX_LIST.ToDictionary(X => X.id.ToString(), X => (object)X.description);

                var TaxListParent = (from o in MC.TAX_LIST where o.parent_id == null select o).ToList();
                SelectedTaxList = TaxListParent;
                TaxDictoneryParent = SelectedTaxList.ToDictionary(X => X.id.ToString(), X => (object)X.description);

                if (string.IsNullOrWhiteSpace(plant) == false && SelectedTaxList != null)
                {
                    List<ACC_M013> tempTax = new List<ACC_M013>();
                    if (MasterEntity.buss_place == null)
                    {
                        tempTax = SelectedTaxList; // SelectedTaxList.Where(T => T.base_code_id == 1 || T.base_code_id == 2 || T.base_code_id == 3).ToList();
                        TaxDictoneryParent = tempTax.ToDictionary(X => X.id.ToString(), X => (object)X.description);
                    }
                    else if (MasterEntity.buss_place == ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(x => x.comp_code.Equals((MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code), StringComparison.OrdinalIgnoreCase) == true && x.location_Id.Equals(MasterEntity.location_Id, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].buss_place)
                    {
                        tempTax = SelectedTaxList.Where(T => T.base_code_id == 1 || T.base_code_id == 2 || T.base_code_id == null).ToList();
                        TaxDictoneryParent = tempTax.ToDictionary(X => X.id.ToString(), X => (object)X.description);
                    }
                    else if (MasterEntity.buss_place != ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(x => x.comp_code.Equals((MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code), StringComparison.OrdinalIgnoreCase) == true && x.location_Id.Equals(MasterEntity.location_Id, StringComparison.OrdinalIgnoreCase) == true).ToList()[0].buss_place)
                    {
                        tempTax = SelectedTaxList.Where(T => T.base_code_id == 3 || T.base_code_id == null).ToList();
                        TaxDictoneryParent = tempTax.ToDictionary(X => X.id.ToString(), X => (object)X.description);
                    }
                }


                var title_data = (from o in MC.PARAMETERS_VALUES_LIST where o.para_code == "P003" select o);
                TITLE_COLLECTION = title_data;
                NotificationDataCollection = MC.NotificationData;
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void CommandInitialization()
        {
            CursorControl.SetBusyState();
            try
            {
                #region Command Initialisation
                cmdInsertSupplier = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSupplier(cmdPara); });
                cmdInsertPartner = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPartner(cmdPara); });
                cmdInsertQty = new RelayCommand<object>(items => { if (items == null) { return; } InsertQty(items); });
                cmdInsertPFAddress = new RelayCommand<object>(items => { if (items == null) { return; } InsertPFAddress(items, isNewRecord); });
                cmdInsertPFEmployee = new RelayCommand<object>(items => { if (items == null) { return; } InsertPFEmployee(items, isNewRecord); });
                cmdInsertPFCode = new RelayCommand<object>(items => { if (items == null) { return; } InsertPFCode(items, isNewRecord); });
                cmdInsertPFParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertPFParty(items, isNewRecord); });
                cmdSelectionChangedPartner = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChangedPartner(items); });
                cmdSelectionChanged_SEL_T001_A = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_SEL_T001_A(items); });
                cmdSelectionChanged_SEL_T001_E = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_SEL_T001_E(items); });
                cmdSelectionChangedSchedule = new RelayCommand<object>(items => { if (items == null) { return; } ScheduleDataGridRowSelectionChanged(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                AddRemoveManualTax = new RelayCommand<bool>(ActiveInactiveTax);
                cmddgLocation = new RelayCommand<object>(items => { if (items == null) { return; } Insertdgplant(items); });
                CmdLicence = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicence(cmdPara, false, true, true); });
                cmdTR_Mode = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTR_Mode(cmdPara); });
                cmdTR_ModeMaster = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTR_ModeMaster(cmdPara); });
                cmddgTransporter = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgTransporter(cmdPara, false, true, true); });
                CommandDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocType(items); });
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
                CommandPayTerms = new RelayCommand<object>(items => { if (items == null) { return; } InsertPayTerm(items); });
                CommandCurrency = new RelayCommand<object>(items => { if (items == null) { return; } InsertCurrency(items); });
                CmddgCurrency = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgCurrency(cmdPara); });
                CommandSalseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseOrg(items); });
                CommandSalseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseGroup(items); });
                CommandItemCategory = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItemCategory(cmdPara, false, true, true); });
                CommandBuyer = new RelayCommand<object>(items => { if (items == null) { return; } InsertBuyer(items); });
                CommandItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara, null,null,null); });
                CommandTerms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTerms(cmdPara); });
                CommandDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });// confirm assignment
                CommandDeleteDataGridRowSchedule = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_ItemSchedule(cmdPara); });// confirm assignment
                CommandDeleteDataGridRowLicence = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_ItemLicence(cmdPara); });// confirm assignment
                //CommandLocations = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLocationItem(cmdPara); });// confirm assignment
                CommandLicenseAdvance = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicenseAdvance(cmdPara); });// confirm assignment
                CommandLicenseEPCG = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLicenseEPCG(cmdPara); });// confirm assignment
                CommandIncoterms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertIncoterms(cmdPara); });// confirm assignment
                CmddgIncoterms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgIncoterms(cmdPara, false, true, true); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); }); // confirm assignment
                cmdExecuteReferenceDocuments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } ExecuteReferenceDocuments(cmdPara, "FlipGridReference"); }); // confirm assignment
                cmdDeleteTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteTax(cmdPara); });
                ManualTaxChangedCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertManualTaxChangedCommand(cmdPara); });
                CommandAddSelectedTax = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSelectedTax(cmdPara); });
                CmdCondType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertConditiontype(cmdPara); });
                cmdMail = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } MailDocuments(cmdPara); });
                cmdPrint = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } PrintDocuments(cmdPara); });
                CommandDeleteDataGridTerms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Terms(cmdPara); });
                cmdRefContactPerson = new RelayCommand<object>(items => { if (items == null) { return; } InsertRefContactPerson(items); });
                cmdLoadBackFlip = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadBackFlipData(cmdPara); });
                CmdUnitPrice = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } CheckPrice(cmdPara, false, true, true); });
                CmdItemInfo = new RelayCommand<object>(item => { if (item == null) { return; } FilterItemSalesData(item); });
                cmdOpenAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenDocumentViewer(cmdPara); });
                CmddgShipToParty = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertdgShipToParty(cmdPara, false, true, true); });
                CmdInsert_t_status = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_t_status(cmdPara); });
                cmdAddSelectedReferenceDocument = new RelayCommand<object>(items => { if (items == null) { return; } AddSelectedReferenceDocument(items); });
                CommandFltrDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrDocType(items); });
                CommandFltrStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrStatus(items); });
                CommandFltrSoldToParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrSoldToParty(items); });
                CommandFilterSeller = new RelayCommand<object>(items => { if (items == null) { return; } InsertFilterSeller(items); });
                cmdSchShipToParty = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSchShipToParty(cmdPara, false, true, true); });
                cmdSchShipToAdd = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSchShipToAddress(cmdPara, false, true, true); });
                cmdInsertElement = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertElement(cmdPara, false, true, true); });
                //cmdInsertCompany = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCompany(cmdPara); });
                //cmdInsertLocation = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLocation(cmdPara); });
                cmdDeleteDataGridRowPF = new RelayCommand<SEL_T001_PART>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowPF(cmdPara); });// confirm assignment
                cmdInsertTermsConditions = new RelayCommand<object>(items => { if (items == null) { return; } InsertTermsConditions(items); });
                cmdCreateBillingPlan = new RelayCommand<object>(items => { if (items == null) { return; } CreateBillingPlan(items); });
                cmdInsertPriceList = new RelayCommand<object>(items => { if (items == null) { return; } InsertPriceList(items); });
                #endregion
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void OpenDocumentViewer(object InputValue)
        {
            CursorControl.SetBusyState();
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
                string Request = "GetAllFiles" + "!@" + AppSessionState.client + "!@" + (EntityObjectParameter.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (EntityObjectParameter.location_Id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + (doc_cat_vm ?? "") + "!@" + doc_cat_vm + "!@" + EntityObjectParameter.sono + "!@" + EntityObjectParameter.id.ToString();
                MCAttachments = repository_MCAttachments.GetDataWithReturnDomainObject<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                if (!string.IsNullOrEmpty(EntityObjectParameter.ItemCode))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.sono.Replace("/", "--"), Row_ID = EntityObjectParameter.id.ToString(), DocumentList = MCAttachments.Attachments, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
                }

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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

                if (MasterEntity.XDOC_RS != null)
                {
                    MC.WORKFLOW_LIST = (List<COM_T011>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_RS, MC.WORKFLOW_LIST);
                    ReleaseList = MC.WORKFLOW_LIST;
                }
                else
                {
                    MC.WORKFLOW_LIST = new List<COM_T011>();
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
                if (MasterEntity.XDOC_TC != null)
                {
                    MC.TermsAndCondition = (ObservableCollection<GEN_T011>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_TC, MC.TermsAndCondition);
                    TermsConditionEntity = MC.TermsAndCondition;
                }
                else
                {
                    TermsConditionEntity = new ObservableCollection<GEN_T011>();
                }
                if (MasterEntity.XDOC_SEL_T001_PART != null)
                {
                    MC.PartnerEntity = (ObservableCollection<SEL_T001_PART>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_SEL_T001_PART, MC.PartnerEntity);
                    PartnerEntity = MC.PartnerEntity;
                }
                else
                {
                    PartnerEntity = new ObservableCollection<SEL_T001_PART>();
                }
                MasterEntity.ts_code = ts_code_vm;
                EntityChangeEnable = true;
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }

        private async void FilterItemSalesData(object InputValue)
        {
            try
            {
                SEL_T001_A SelectedItem = InputValue as SEL_T001_A;
                PRICE_HISTORY_COLLECTION = new List<STD_LIST_BE>();

                if (SelectedItem == null || string.IsNullOrWhiteSpace(SelectedItem.ItemCode) || MasterEntity == null)
                {
                    return;
                }

                string Request = "GET_LAST_5_ITEM_PRICES" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + SelectedItem.ItemCode;
                MCTemp = await repository_MCTemp.GetDataWithReturnDomainObjectASynchronus<MC_SDM_BE>(MCTemp, Request, "SEL_T001_BL", "SDM", "", 0, "");
                PRICE_HISTORY_COLLECTION = MCTemp.PRICE_LIST ?? new List<STD_LIST_BE>();
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok;
                sms.Caption = "Price History";
                sms.Text = ex.Message;
                sms.ShowMessage();
            }
        }
        private void Computation(bool Compute, bool AutoRoundUpFlag)
        {
            try
            {
                if (Compute == true && ItemEntityObject != null)
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

                    if (ItemsEntity != null && ItemsEntity.Count > 0 && !string.IsNullOrWhiteSpace(ItemEntityObject.ItemCode)) //Condition satisfy only if Items collection is not empty.
                    {
                        if (string.IsNullOrWhiteSpace(ItemEntityObject.rel_billing) || ItemEntityObject.rel_billing == "Y")
                        {
                            if (ItemEntityObject.quantity >= 0 && ItemEntityObject.unit_price >= 0 && ItemEntityObject.active != false) // Must not null or empty.
                            {
                                ItemEntityObject.gross_value = Math.Round(((ItemEntityObject.quantity * ItemEntityObject.unit_price) ?? 0), RoundUpDecimals);

                                if (ItemEntityObject.discount == null)
                                {
                                    ItemEntityObject.discount = 0;
                                }
                                if (ItemEntityObject.discount_type == "F")    // Manual Discount value instead of percent.
                                {
                                    ItemEntityObject.discount = 0;
                                    ItemEntityObject.sub_total = (ItemEntityObject.gross_value) - (ItemEntityObject.discount_amt);
                                }
                                else
                                {
                                    //ItemEntityObject.discount_amt = (ItemEntityObject.gross_value * ((ItemEntityObject.discount ?? 0) / 100));
                                    ItemEntityObject.discount_amt = decimal.Round((decimal)(ItemEntityObject.gross_value * ((ItemEntityObject.discount ?? 0) / 100)), RoundUpDecimals);
                                    //ItemEntityObject.sub_total = (ItemEntityObject.gross_value - ItemEntityObject.discount_amt);
                                    ItemEntityObject.sub_total = decimal.Round((decimal)((ItemEntityObject.gross_value - ItemEntityObject.discount_amt) ?? 0), RoundUpDecimals);
                                }

                            }
                            #region Calculate Taxes for New/Edited Items row.
                            if (!String.IsNullOrEmpty(ItemEntityObject.tax_id) && ItemEntityObject.active == true) //Condition satisfy only if Selected Item not null and Taxes are applied.
                            {
                                #region Tax Not Null

                                List<ACC_M013> TaxListTemp = new List<ACC_M013>();
                                string[] TaxArray = ItemEntityObject.tax_id.Trim().Split(',');
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
                                                BasePrice = ItemEntityObject.sub_total / TaxValue;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = ItemEntityObject.sub_total - BasicItemAmount;
                                            }
                                            else if (SingleTax.price_include == false)
                                            {
                                                TaxValue = (SingleTax.amount) / 100;
                                                if (TaxListForBaseInclude.Length > 0)
                                                {
                                                    PreviousTaxValueForBasePrice = TotalDocumentTaxes.Where(tax => tax.sequence < SingleTax.sequence && tax.item_line_id == ItemEntityObject.line_id && tax.manual == "Auto" && tax.ItemCode == ItemEntityObject.ItemCode && (tax.sku?.ToString() ?? "") == (ItemEntityObject.sku?.ToString() ?? "") && tax.item_row_id == ItemEntityObject.id && tax.tax_code_id.In(TaxListForBaseInclude)).Sum(tax => tax.tax_amount); // Get Base amount for Calculation.
                                                }
                                                if (SingleTax.parent_id != null) // Collect Base price for This single child Tax.
                                                {
                                                    BasePrice = TotalDocumentTaxes.Where(tax => tax.tax_code_id == SingleTax.parent_id && tax.item_line_id == ItemEntityObject.line_id && tax.manual == "Auto" && tax.ItemCode == ItemEntityObject.ItemCode && (tax.sku?.ToString() ?? "") == (ItemEntityObject.sku?.ToString() ?? "") && tax.item_row_id == ItemEntityObject.id).Single().tax_amount;
                                                }
                                                else // Collect Base Price for this parent Tax.
                                                {
                                                    BasePrice = ItemEntityObject.sub_total + PreviousTaxValueForBasePrice;
                                                }
                                                BasicItemAmount = ItemEntityObject.sub_total;
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
                                                BasePrice = ItemEntityObject.sub_total - TaxValue;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = ItemEntityObject.sub_total - BasicItemAmount;
                                            }
                                            else if (SingleTax.price_include == false)
                                            {
                                                BasePrice = ItemEntityObject.sub_total;
                                                BasicItemAmount = BasePrice;
                                                TaxAmount = TaxValue;
                                            }
                                        }
                                        #endregion
                                        #region Insert/Update Tax
                                        TaxAmount = Math.Round(TaxAmount ?? 0, RoundUpDecimals);
                                        int TaxIndex = 0;
                                        var TaxVar = TotalDocumentTaxes.FirstOrDefault(T => T.tax_code_id == SingleTax.id && T.ItemCode == ItemEntityObject.ItemCode && (T.sku?.ToString() ?? "") == (ItemEntityObject.sku?.ToString() ?? "") && T.item_line_id == ItemEntityObject.line_id && T.item_row_id == ItemEntityObject.id && T.manual == "Auto");
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
                                            TotalDocumentTaxes[TaxIndex].ItemCode = ItemEntityObject.ItemCode;
                                            TotalDocumentTaxes[TaxIndex].sku = ItemEntityObject.sku;
                                            TotalDocumentTaxes[TaxIndex].item_row_id = ItemEntityObject.id;
                                            TotalDocumentTaxes[TaxIndex].item_line_id = ItemEntityObject.line_id;
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
                                            TotalDocumentTaxes[TaxIndex].qty_price = ItemEntityObject.qty_price;
                                            TotalDocumentTaxes[TaxIndex].price_qty = ItemEntityObject.price_qty;
                                            TotalDocumentTaxes[TaxIndex].price_qty_uom = ItemEntityObject.price_qty_uom;

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
                                                ItemCode = ItemEntityObject.ItemCode,
                                                sku = ItemEntityObject.sku,
                                                item_row_id = ItemEntityObject.id,
                                                item_line_id = ItemEntityObject.line_id,
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
                                                qty_price = ItemEntityObject.qty_price,
                                                price_qty = ItemEntityObject.price_qty,
                                                price_qty_uom = ItemEntityObject.price_qty_uom
                                            });
                                        }
                                        #endregion
                                    }
                                }

                                #endregion

                                #region Remove Excluded Taxes.
                                string[] TaxArray2 = ItemEntityObject.tax_id.Trim().Split(',');
                                List<ACC_T006_B> copy = new List<ACC_T006_B>();
                                copy = TotalDocumentTaxes.ToList();
                                foreach (var tax in copy)
                                {
                                    bool DeleteFlag = true;
                                    foreach (string SingleTax in TaxArray2)
                                    {
                                        if ((tax.tax_code_id.ToString() == SingleTax && tax.ItemCode == ItemEntityObject.ItemCode && (tax.sku?.ToString() ?? "") == (ItemEntityObject.sku?.ToString() ?? "") && tax.item_line_id == ItemEntityObject.line_id && tax.item_row_id == ItemEntityObject.id && tax.manual == "Auto") || tax.manual == "Manual")
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
                                            if (ChildTaxVar.parent_id.ToString() == SingleTax && tax.ItemCode == ItemEntityObject.ItemCode && (tax.sku?.ToString() ?? "") == (ItemEntityObject.sku?.ToString() ?? "") && tax.item_line_id == ItemEntityObject.line_id && tax.item_row_id == ItemEntityObject.id && tax.manual == "Auto")
                                            {
                                                CheckChildParentFlag = false;
                                                break;
                                            }
                                        }
                                        if (!CheckChildParentFlag) continue;

                                        if (tax.tax_code_id == ChildTaxVar.id && tax.ItemCode == ItemEntityObject.ItemCode && (tax.sku?.ToString() ?? "") == (ItemEntityObject.sku?.ToString() ?? "") && tax.item_line_id == ItemEntityObject.line_id && tax.item_row_id == ItemEntityObject.id && tax.manual == "Auto")
                                        {
                                            TotalDocumentTaxes.Remove(tax);
                                        }
                                    }
                                    else if (tax.tax_code_id == ChildTaxVar.id && tax.ItemCode == ItemEntityObject.ItemCode && (tax.sku?.ToString() ?? "") == (ItemEntityObject.sku?.ToString() ?? "") && tax.item_line_id == ItemEntityObject.line_id && tax.item_row_id == ItemEntityObject.id && tax.manual == "Auto")
                                    {
                                        TotalDocumentTaxes.Remove(tax);
                                    }
                                }

                                #endregion

                            }
                            else //if (ItemEntityObject.tax_id != null && ItemEntityObject.active == false) // Remove previously assign Taxes from TotalDocumentTaxes if removed from Item.//Condition satisfy only if Selected Item not null and Active status is false.
                            {
                                List<ACC_T006_B> copy = new List<ACC_T006_B>();
                                copy = TotalDocumentTaxes.ToList();
                                foreach (var tax in copy)
                                {
                                    if (tax.ItemCode == ItemEntityObject.ItemCode && (tax.sku?.ToString() ?? "") == (ItemEntityObject.sku?.ToString() ?? "") && tax.item_line_id == ItemEntityObject.line_id && tax.item_row_id == ItemEntityObject.id && tax.manual == "Auto")
                                    {
                                        if (tax.id == 0)
                                        {
                                            TotalDocumentTaxes.Remove(tax);
                                        }
                                        else
                                        {
                                            int Index = TotalDocumentTaxes.IndexOf(TotalDocumentTaxes.Where(X => X.ItemCode == ItemEntityObject.ItemCode && (X.sku?.ToString() ?? "") == (ItemEntityObject.sku?.ToString() ?? "") && X.item_line_id == ItemEntityObject.line_id && X.item_row_id == ItemEntityObject.id && X.manual == "Auto" && X.active == true).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.
                                            if (Index >= 0)
                                            {
                                                TotalDocumentTaxes.ElementAt(Index).active = false;
                                            }
                                        }
                                    }
                                }


                            }

                            #region Final Computation

                            if (ItemsEntity.Count > 0) // calculate items total Tax and get Net & Effective value of the item.
                            {
                                decimal? taxTotal = TotalDocumentTaxes.Where(x => x.item_row_id == ItemEntityObject.id && x.item_line_id == ItemEntityObject.line_id).Sum(x => x.con_value);
                                ItemEntityObject.net_value = ((ItemEntityObject.gross_value + Math.Round((taxTotal ?? 0), RoundUpDecimals)) - (ItemEntityObject.discount_amt ?? 0));
                                ItemEntityObject.effective_value = ItemEntityObject.net_value;
                                ItemEntityObject.tax_amount = taxTotal;
                            }

                            TaxtTotal = TotalDocumentTaxes.Where(item => item.active != false && item.manual == "Auto").Sum(item => item.tax_amount);
                            MasterEntity.tax_amt = TaxtTotal;
                            MasterEntity.tax_amount = TaxtTotal;

                            UnTaxTotal = ItemsEntity.Where(item => item.active != false).Sum(item => item.sub_total);
                            MasterEntity.untax_amt = UnTaxTotal;


                            net_value = UnTaxTotal + TaxtTotal;
                            MasterEntity.net_value = net_value;
                            other_charges = TotalDocumentTaxes.Where(item => item.active != false && item.manual == "Manual").Sum(item => item.tax_amount);
                            MasterEntity.other_charges = other_charges;

                            GrandTotal = net_value + other_charges;
                            GrandTotal = decimal.Round((decimal)GrandTotal, 2);
                            MasterEntity.total_amt = GrandTotal;

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
                            MasterEntity.gross_value = ItemsEntity.Where(item => item.active != false).Sum(item => item.quantity * item.unit_price);
                            MasterEntity.effective_value = GrandTotal;
                            MasterEntity.disc_amt = MasterEntity.gross_value - UnTaxTotal;

                            if (MasterEntity.roundup_total > 0 && !string.IsNullOrWhiteSpace(MasterEntity.curr_code))
                            {
                                ADM_M037 curr_obj = new ADM_M037();
                                curr_obj = ((List<ADM_M037>)AppSessionState.CurrencyList).Where(x => x.curr_code == MasterEntity.curr_code).ToList()[0];
                                if (curr_obj.word_format == "F01" || string.IsNullOrWhiteSpace(curr_obj.word_format))
                                {
                                    MasterEntity.amt_inword = NUMBER_TO_WORDS_CONVERTER.AmountInWordsF01(MasterEntity.roundup_total.ToString(), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word, curr_obj.word_format, curr_obj.word_prefix, curr_obj.word_suffix);
                                }
                                else
                                {
                                    MasterEntity.amt_inword = NOW_OBJ.AmountInWords(Convert.ToDecimal(MasterEntity.roundup_total), MasterEntity.curr_code, curr_obj.monitory_unit, curr_obj.monitory_unit_prefix, curr_obj.tail_word, curr_obj.word_format);
                                }
                            }
                            else
                            { MasterEntity.amt_inword = ""; }

                            #endregion
                            #endregion
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
                        if (MasterEntity.doc_type != "OP" || MasterEntity.doc_cat != "OP")
                        {
                            if (o.quantity == null || o.quantity == 0)
                            {
                                sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Quantity cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                                sms.ShowMessage(); return false;
                            }
                        }

                        if ((MasterEntity.doc_type != "RS" || MasterEntity.doc_cat != "SO" || MasterEntity.doc_cat != "OP") && string.IsNullOrEmpty(o.tl_code) == true)
                        {
                            var TaskListData = (from x in MC.MASTER_TASK_LIST where x.item_code == o.ItemCode select o).ToList();// This will load data only for RS doc type for repaire & Maintiancence, Need task list exists for this doc_type. we can load for other doc_type also if required. change login in SP for that.

                            if (TaskListData != null) // set fefault value if single item in list
                            {
                                if (TaskListData.Count > 0)
                                {
                                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Select Task List for the item {0}", o.ItemCode);
                                    sms.ShowMessage(); return false;
                                }
                            }
                        }

                        if (o.unit_code == null || o.unit_code == "")
                        {
                            sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Please Enter Valid Unit Code for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                            sms.ShowMessage(); return false;
                        }

                        if (o.tax_id != null || o.tax_id != "")
                        {
                            if (TotalDocumentTaxes.Count > 0)
                            {
                                for (int i = 0; i < TotalDocumentTaxes.Count; i++)
                                {

                                    if (TotalDocumentTaxes[i].con_type == null || TotalDocumentTaxes[i].con_type == "")
                                    {
                                        sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Condition Type is Required for Tax {0} ", TotalDocumentTaxes[i].tax_name);
                                        sms.ShowMessage();return false;
                                    }
                                }
                            }
                        }
                    }

                    #region . Parameter Validation .    
                    // Validation For All Parameter Values Selected or Not

                    //if (o.StockUnt == true && o.active == true)
                    //{
                    //    var paralist = (from p in MC.PARAMETERS_LIST where p.SubCatCode == o.SubCatCode select p).ToList();

                    //    if (paralist.Count > 0)
                    //    {
                    //        string[] SkuList = new string[100];           //string array
                    //        List<string> SkuListt = new List<string>();    // stringlist

                    //        if (o.sku != null && o.sku != "")
                    //        {
                    //            SkuList = o.sku.Split('/');
                    //            SkuListt = SkuList.ToList();

                    //            foreach (var item in SkuList)
                    //            {
                    //                if (item == "")
                    //                {
                    //                    sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Parameter Validation";sms.Text = String.Format("All Parameters of item {0} of Index {1} are not selected..!!! \n Check Parameter at index {2} is selected or not.", o.ItemCode, ItemsEntity.IndexOf(o), SkuList.ToList().IndexOf(item));
                    //                    sms.ShowMessage();return false;
                    //                }
                    //            }
                    //        }
                    //        else
                    //        {
                    //            sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Parameter Validation";sms.Text = String.Format("All Parameters of item {0} of Index {1} are not selected\n If you can see All Parameter Value Selected Please Select the Same Values Again ", o.ItemCode, ItemsEntity.IndexOf(o));
                    //            sms.ShowMessage();return false;
                    //        }
                    //    }
                    //}
                    #endregion
                }

                if (string.IsNullOrWhiteSpace(MasterEntity.title) & (MasterEntity.doc_cat=="SN" || MasterEntity.doc_cat == "QN" || MasterEntity.doc_cat == "SO"))
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Document title Is Required"); sms.ShowMessage();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(MasterEntity.sales_person_cd))
                {
                    sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Sales Person Is Required");sms.ShowMessage();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(MasterEntity.ind_trade))
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message";sms.Text = String.Format("Transaction Type is Required");sms.ShowMessage();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(MasterEntity.doc_type))
                {
                    sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Document Type is Required");sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.ind_source==true)
                {
                    if (PartnerEntity != null)
                    {
                        if (PartnerEntity.Count > 0)
                        { //MC.PF_CODE_LIST
                            var pf_obj = PartnerEntity.Where(x => x.pf_code == "05" && x.party_code != null).ToList().FirstOrDefault();
                            if(pf_obj != null)
                            {
                                if(string.IsNullOrWhiteSpace(pf_obj.party_code))
                                {
                                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Reference Partner required"); sms.ShowMessage();
                                    return false;
                                }
                            }
                            else
                            {
                                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Reference Partner required"); sms.ShowMessage();
                                return false;
                            }
                        }
                        else
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Reference Partner required"); sms.ShowMessage();
                            return false;
                        }
                    }
                    else
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Reference Partner required"); sms.ShowMessage();
                        return false;
                    }
                }
                if (string.IsNullOrWhiteSpace(MasterEntity.so_code))
                {
                    sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Sales Organisation is Required");sms.ShowMessage();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(MasterEntity.sg_code))
                {
                    sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Sales Group is Required");sms.ShowMessage();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(MasterEntity.location_Id))
                {
                    sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Plant is Required");sms.ShowMessage();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(MasterEntity.order_to_plant))
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Execution Plant is Required"); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.ex_rate == null || !MasterEntity.ex_rate.HasValue)
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Currancy Exchange Rate is Required"); sms.ShowMessage();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(MasterEntity.curr_code))
                {
                    sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Currancy is Required");sms.ShowMessage();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(MasterEntity.party_name))
                {
                    sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Sold To Party is Required");sms.ShowMessage();
                    return false;
                }
                if (string.IsNullOrWhiteSpace(MasterEntity.ship_to_party_name) && (MasterEntity.doc_cat != "SN" && MasterEntity.doc_cat != "QN"))
                {
                    sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Ship To Party is Required");sms.ShowMessage();
                    return false;
                }
                if ((MasterEntity.del_address == null || MasterEntity.del_address == 0) && (MasterEntity.doc_cat != "SN" && MasterEntity.doc_cat != "QN"))
                {
                    sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Shipping Address Is Required");sms.ShowMessage();
                    return false;
                }
                if ((MasterEntity.bill_address_id == null || MasterEntity.bill_address_id == 0) && (MasterEntity.doc_cat != "SN" && MasterEntity.doc_cat != "QN"))
                {
                    sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Billing Address Is Required");sms.ShowMessage();
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
                    if (item_cat == "SIC" && (string.IsNullOrWhiteSpace(o.ship_to_add) || o.ship_to_add == "0") && (MasterEntity.doc_cat != "SN" && MasterEntity.doc_cat != "QN"))
                    {
                        sms.ButtonSetup = DialogButton.Ok;
                        sms.Caption = "Message";
                        sms.Text = String.Format("Shipping address required in Schedule!");
                        sms.ShowMessage();

                        return false;
                    }
                }
                if (ItemsEntity.Count < 1 && MasterEntity.doc_cat != "SN")
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Item Code is Required"); sms.ShowMessage();

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
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Validity From Date is Required for Open Order Category"); sms.ShowMessage();

                        return false;
                    }
                    if (MasterEntity.valid_to_date == null)
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Validity To Date is Required for Open Order Category"); sms.ShowMessage();

                        return false;
                    }

                }


            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format(ex.Message, this.Title);sms.ShowMessage();
            }
            return true;
        }

        // FilterScheduleDataGrid : Filter for Schedule Items as per selected item in ItemsEntity. This filter is work for ObserverableCollection.
        private void FilterScheduleDataGrid()
        {
            try
            {
                if (ItemScheduleEntity != null && ItemScheduleEntity.Count > 0
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
                sms.ButtonSetup = DialogButton.Ok;
                sms.Caption = "Message";
                sms.Text = String.Format(ex.Message, this.Title);
                sms.ShowMessage();
            }
        }
        private void FilterLicenceDataGrid()
        {
            try
            {
                if (LicenceDetailsEntity != null && LicenceDetailsEntity.Count > 0
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
                sms.ButtonSetup = DialogButton.Ok;
                sms.Caption = "Message";
                sms.Text = String.Format(ex.Message, this.Title);
                sms.ShowMessage();
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
                if (item.active == true && (item.rel_billing ?? "Y") =="Y")
                {
                    html += "<tr bgcolor=#d9e6f2>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.ItemCode + "</p></span></strong></p> </td>";
                    html += "<td width=10%> <p><strong><span style=color:#000080;> " + item.Description + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.quantity.ToString() + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.unit_code + "</span></strong></p> </td>";
                    //html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.unit_price.ToString() + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + (item.unit_price.HasValue ? decimal.Round(item.unit_price.Value, 2).ToString() : "") + "</span></strong></p> </td>";
                    html += "</tr>";
                }
            }
            html += "</table>";

            return html;
        }
        private void NotifyMessage(string AlertName,string operation)
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
                    VarData.cc_mail_id = (VarData.cc_mail_id ?? "") + ";" + (AppSessionState.EmpEmailId ?? "") + (MasterEntity.EmpEmailId == AppSessionState.EmpEmailId ? "" : (";" + MasterEntity.EmpEmailId));
                    Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, VarData.to_mail_id, VarData.cc_mail_id, VarData.bcc_mail_id, VarData.subject, VarData.msg_body, null);
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
            if (BACKFLIP_COLLECTION != null)
            {
                BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.party_code != null && data.party_code.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.party_name != null && data.party_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.party_ref_no != null && data.party_ref_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.emp_id != null && data.emp_id.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.emp_name != null && data.emp_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.person_name != null && data.person_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.doc_type_name != null && data.doc_type_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.so_name != null && data.so_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.sg_name != null && data.sg_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.t_display != null && data.t_display.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.document_value != null && (data.document_value ?? 0).ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _FLTR_STR_ITEM;
        public string FLTR_STR_ITEM
        {
            get { return _FLTR_STR_ITEM; }
            set
            {
                _FLTR_STR_ITEM = value;
                RaisePropertyChanged("FLTR_STR_ITEM");
                FLTR_COLL_ITEM();
            }
        }
        private void FLTR_COLL_ITEM()
        {
            if (ITEM_COLLECTION != null)
            {
                ITEM_COLLECTION.Refresh();
            }
        }
        public bool FLTR_ITEM(object obj)
        {
            var data = obj as STD_ITEM;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FLTR_STR_ITEM))
                {
                    return (data.item_name != null && data.item_name.ToString().ToLower().Contains(_FLTR_STR_ITEM.ToLower()) ||
                           (data.item_subcat != null && data.item_subcat.ToString().ToLower().Contains(_FLTR_STR_ITEM.ToLower())) ||
                            (data.item_cat != null && data.item_cat.ToString().ToLower().Contains(_FLTR_STR_ITEM.ToLower())) ||
                            data.item_code != null && data.item_code.ToString().ToLower().Contains(_FLTR_STR_ITEM.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _FLTR_STR_REF_DOC;
        public string FLTR_STR_REF_DOC
        {
            get { return _FLTR_STR_REF_DOC; }
            set
            {
                _FLTR_STR_REF_DOC = value;
                RaisePropertyChanged("FLTR_STR_REF_DOC");
                FLTR_COL_REF_DOC();
            }
        }
        private void FLTR_COL_REF_DOC()
        {
            if (REF_DOC_COLLECTION != null)
            {
                REF_DOC_COLLECTION.Refresh();
            }
        }
        public bool FLTR_REF_DOC(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FLTR_STR_REF_DOC))
                {
                    return (data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_FLTR_STR_REF_DOC.ToLower()) ||
                            data.party_code != null && data.party_code.ToString().ToLower().Contains(_FLTR_STR_REF_DOC.ToLower()) ||
                            data.party_name != null && data.party_name.ToString().ToLower().Contains(_FLTR_STR_REF_DOC.ToLower()) ||
                            data.ref_doc_date != null && data.ref_doc_date.ToString().ToLower().Contains(_FLTR_STR_REF_DOC.ToLower())
                       );
                }
                return true;
            }
            return false;
        }
        #endregion
    }
}
