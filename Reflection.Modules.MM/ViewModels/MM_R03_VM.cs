using System;
using Reflection.BusinessEntity;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Controls;
using System.Windows.Data;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Collections.Generic;
using Reflection.ReportingServices;
using System.Linq;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.MM.ViewModels
{
    public class MM_R03_VM : WorkspaceViewModel<STD_LIST_BE>
    {
        #region Variables Declaration
        IShowMessageViewService sms;
        public string ts_code_vm { get; set; }
        WebServiceRepository<STD_MIS_MC_BE> repository_MC = new WebServiceRepository<STD_MIS_MC_BE>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private STD_MIS_MC_BE _MC = new STD_MIS_MC_BE();
        public STD_MIS_MC_BE MC
        {
            get { return _MC; }
            set { if (_MC != value) { _MC = value; RaisePropertyChanged("MC"); } }
        }
        private STD_MIS_MC_BE _MC_TEMP = new STD_MIS_MC_BE();
        public STD_MIS_MC_BE MC_TEMP
        {
            get { return _MC_TEMP; }
            set { if (_MC_TEMP != value) { _MC_TEMP = value; RaisePropertyChanged("MC_TEMP"); } }
        }
        private STD_LIST_BE _MIS_OBJ = new STD_LIST_BE();
        public STD_LIST_BE MIS_OBJ
        {
            get { return _MIS_OBJ; }
            set { if (_MIS_OBJ != value) { _MIS_OBJ = value; RaisePropertyChanged("MIS_OBJ"); } }
        }
        private STD_REQ_PARA_BE _REQ_PARA_OBJ;
        public STD_REQ_PARA_BE REQ_PARA_OBJ
        {
            get
            {
                return _REQ_PARA_OBJ;
            }
            set
            {
                _REQ_PARA_OBJ = value;
                RaisePropertyChanged("REQ_PARA_OBJ");
            }
        }

        #endregion

        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(MM_R03_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        private AutoSuggestTextViewModel<dynamic> _AS_REPORTS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_REPORTS
        {
            get { return _AS_REPORTS; }
            set
            {
                if (_AS_REPORTS != value)
                {
                    _AS_REPORTS = value; RaisePropertyChanged("AS_REPORTS");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_SORT_ORDER { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_SORT_ORDER
        {
            get { return _AS_SORT_ORDER; }
            set
            {
                if (_AS_SORT_ORDER != value)
                {
                    _AS_SORT_ORDER = value; RaisePropertyChanged("AS_SORT_ORDER");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ENUM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ENUM
        {
            get { return _AS_ENUM; }
            set
            {
                if (_AS_ENUM != value)
                {
                    _AS_ENUM = value; RaisePropertyChanged("AS_ENUM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_DOC_CAT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DOC_CAT
        {
            get { return _AS_DOC_CAT; }
            set
            {
                if (_AS_DOC_CAT != value)
                {
                    _AS_DOC_CAT = value; RaisePropertyChanged("AS_DOC_CAT");
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
        private AutoSuggestTextViewModel<dynamic> _AS_CUSTOMERS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CUSTOMERS
        {
            get { return _AS_CUSTOMERS; }
            set
            {
                if (_AS_CUSTOMERS != value)
                {
                    _AS_CUSTOMERS = value; RaisePropertyChanged("AS_CUSTOMERS");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_CUSTOMERS_SHIP_TO { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CUSTOMERS_SHIP_TO
        {
            get { return _AS_CUSTOMERS_SHIP_TO; }
            set
            {
                if (_AS_CUSTOMERS_SHIP_TO != value)
                {
                    _AS_CUSTOMERS_SHIP_TO = value; RaisePropertyChanged("AS_CUSTOMERS_SHIP_TO");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ORGANISATION { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ORGANISATION
        {
            get { return _AS_ORGANISATION; }
            set
            {
                if (_AS_ORGANISATION != value)
                {
                    _AS_ORGANISATION = value; RaisePropertyChanged("AS_ORGANISATION");
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
        private AutoSuggestTextViewModel<dynamic> _AS_PERSONNEL { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PERSONNEL
        {
            get { return _AS_PERSONNEL; }
            set
            {
                if (_AS_PERSONNEL != value)
                {
                    _AS_PERSONNEL = value; RaisePropertyChanged("AS_PERSONNEL");
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
        private AutoSuggestTextViewModel<dynamic> _AS_ITEMS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ITEMS
        {
            get { return _AS_ITEMS; }
            set
            {
                if (_AS_ITEMS != value)
                {
                    _AS_ITEMS = value; RaisePropertyChanged("AS_ITEMS");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ITEM_CATEGORY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ITEM_CATEGORY
        {
            get { return _AS_ITEM_CATEGORY; }
            set
            {
                if (_AS_ITEM_CATEGORY != value)
                {
                    _AS_ITEM_CATEGORY = value; RaisePropertyChanged("AS_ITEM_CATEGORY");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ITEM_SUB_CATEGORY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ITEM_SUB_CATEGORY
        {
            get { return _AS_ITEM_SUB_CATEGORY; }
            set
            {
                if (_AS_ITEM_SUB_CATEGORY != value)
                {
                    _AS_ITEM_SUB_CATEGORY = value; RaisePropertyChanged("AS_ITEM_SUB_CATEGORY");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ITEM_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ITEM_TYPE
        {
            get { return _AS_ITEM_TYPE; }
            set
            {
                if (_AS_ITEM_TYPE != value)
                {
                    _AS_ITEM_TYPE = value; RaisePropertyChanged("AS_ITEM_TYPE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ITEM_SUB_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ITEM_SUB_TYPE
        {
            get { return _AS_ITEM_SUB_TYPE; }
            set
            {
                if (_AS_ITEM_SUB_TYPE != value)
                {
                    _AS_ITEM_SUB_TYPE = value; RaisePropertyChanged("AS_ITEM_SUB_TYPE");
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
        private AutoSuggestTextViewModel<dynamic> _AS_CURR_UOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CURR_UOM
        {
            get { return _AS_CURR_UOM; }
            set
            {
                if (_AS_CURR_UOM != value)
                {
                    _AS_CURR_UOM = value; RaisePropertyChanged("AS_CURR_UOM");
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
        private AutoSuggestTextViewModel<dynamic> _AS_FIN_YEAR { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_FIN_YEAR
        {
            get { return _AS_FIN_YEAR; }
            set
            {
                if (_AS_FIN_YEAR != value)
                {
                    _AS_FIN_YEAR = value; RaisePropertyChanged("AS_FIN_YEAR");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_POSTING_PERIOD { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_POSTING_PERIOD
        {
            get { return _AS_POSTING_PERIOD; }
            set
            {
                if (_AS_POSTING_PERIOD != value)
                {
                    _AS_POSTING_PERIOD = value; RaisePropertyChanged("AS_POSTING_PERIOD");
                }
            }
        }
        #endregion

        #region RelayCommands  
        public RelayCommand<object> cmdGenerateReport { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdUpdateClosingStock { get; private set; }
        public RelayCommand<object> cmdUpdateCurrentStock { get; private set; }
        #endregion
        public MM_R03_VM(string ts_code) : base()
        {
            sms = this.GetViewService<IShowMessageViewService>();
            ts_code_vm = ts_code;
            MC = new STD_MIS_MC_BE();
            MIS_OBJ = new STD_LIST_BE();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            REQ_PARA_OBJ.ts_code = ts_code;
            STD_REQ_PARA_BE.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            cmdGenerateReport = new RelayCommand<object>(items => { if (items == null) { return; } DisplayReport(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdUpdateClosingStock = new RelayCommand<object>(items => { if (items == null) { return; } UpdateClosingStock(items); });
            cmdUpdateCurrentStock = new RelayCommand<object>(items => { if (items == null) { return; } UpdateCurrentStock(items); });
            LoadInitialData();

        }
        private void UpdateClosingStock(object obj)
        {
            try
            {
                CursorControl.SetBusyState();

                string Request = "UPDATE_CLOSING" + "!@" + AppSessionState.client + "!@" + REQ_PARA_OBJ.comp_code + "!@" + REQ_PARA_OBJ.location_id + "!@" + REQ_PARA_OBJ.doc_cat + "!@" + REQ_PARA_OBJ.doc_type + "!@" + MIS_OBJ.ts_code + "!@" + MIS_OBJ.view_code + "!@" + MIS_OBJ.sql_code + "!@" + REQ_PARA_OBJ.party_code + "!@" + REQ_PARA_OBJ.para1 + "!@" + REQ_PARA_OBJ.so_code + "!@" + REQ_PARA_OBJ.sg_code + "!@" + REQ_PARA_OBJ.emp_id + "!@" + REQ_PARA_OBJ.ind_code + "!@" + REQ_PARA_OBJ.item_code + "!@" + REQ_PARA_OBJ.item_cat + "!@" + REQ_PARA_OBJ.item_subcat + "!@" + REQ_PARA_OBJ.item_type + "!@" + REQ_PARA_OBJ.item_subtype + "!@" + REQ_PARA_OBJ.country_key + "!@" + REQ_PARA_OBJ.para2 + "!@" + REQ_PARA_OBJ.para3 + "!@" + REQ_PARA_OBJ.incoterm + "!@" + REQ_PARA_OBJ.curr_code + "!@" + REQ_PARA_OBJ.curr_unit + "!@" + REQ_PARA_OBJ.unit_code + "!@" + REQ_PARA_OBJ.t_status + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy") + "!@" + REQ_PARA_OBJ.para4 + "!@" + REQ_PARA_OBJ.field_code + "!@" + REQ_PARA_OBJ.field_direction + "!@" + REQ_PARA_OBJ.fin_year + "!@" + REQ_PARA_OBJ.posting_period;
                MC_TEMP = repository_MC.GetDataWithReturnDomainObject<STD_MIS_MC_BE>(MC_TEMP, Request, "MM_R03", "MM", " ", 0, "");



                if (MC_TEMP.STD_MIS_LIST[0].item_code == "Updated")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Closing Updated Sucessfully", this.Title);
                    showMessageService.ShowMessage();
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Updating Fails ", this.Title);
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
        private void UpdateCurrentStock(object obj)
        {
            try
            {

                CursorControl.SetBusyState();
                string Request = "UPDATE_CURRENT" + "!@" + AppSessionState.client + "!@" + REQ_PARA_OBJ.comp_code + "!@" + REQ_PARA_OBJ.location_id + "!@" + REQ_PARA_OBJ.doc_cat + "!@" + REQ_PARA_OBJ.doc_type + "!@" + MIS_OBJ.ts_code + "!@" + MIS_OBJ.view_code + "!@" + MIS_OBJ.sql_code + "!@" + REQ_PARA_OBJ.party_code + "!@" + REQ_PARA_OBJ.para1 + "!@" + REQ_PARA_OBJ.so_code + "!@" + REQ_PARA_OBJ.sg_code + "!@" + REQ_PARA_OBJ.emp_id + "!@" + REQ_PARA_OBJ.ind_code + "!@" + REQ_PARA_OBJ.item_code + "!@" + REQ_PARA_OBJ.item_cat + "!@" + REQ_PARA_OBJ.item_subcat + "!@" + REQ_PARA_OBJ.item_type + "!@" + REQ_PARA_OBJ.item_subtype + "!@" + REQ_PARA_OBJ.country_key + "!@" + REQ_PARA_OBJ.para2 + "!@" + REQ_PARA_OBJ.para3 + "!@" + REQ_PARA_OBJ.incoterm + "!@" + REQ_PARA_OBJ.curr_code + "!@" + REQ_PARA_OBJ.curr_unit + "!@" + REQ_PARA_OBJ.unit_code + "!@" + REQ_PARA_OBJ.t_status + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy") + "!@" + REQ_PARA_OBJ.para4 + "!@" + REQ_PARA_OBJ.field_code + "!@" + REQ_PARA_OBJ.field_direction + "!@" + REQ_PARA_OBJ.fin_year + "!@" + REQ_PARA_OBJ.posting_period;
                MC_TEMP = repository_MC.GetDataWithReturnDomainObject<STD_MC_BE>(MC_TEMP, Request, "MIS_STD_MM_3", "SCM", " ", 0, "");

                if (MC_TEMP.STD_MIS_LIST[0].item_code == "Updated")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Current Stock Updated Sucessfully", this.Title);
                    showMessageService.ShowMessage();
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Sorry Current Stock Updating Fails ", this.Title);
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
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                REQ_PARA_OBJ.ts_code = ts_code_vm;
                REQ_PARA_OBJ.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                REQ_PARA_OBJ.from_date = DateTime.Now;
                REQ_PARA_OBJ.to_date = DateTime.Now;

                if (MC.COMPANY_LIST != null)
                {
                    if (MC.COMPANY_LIST.Count == 1)
                    {
                        REQ_PARA_OBJ.comp_code = MC.COMPANY_LIST[0].comp_code;
                    }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            try
            {
                if (sender.ToString() == "fin_year")
                {
                    List<STD_LIST_BE> pp_list = MC.POSTING_PERIOD_LIST.Where(o => o.fin_year == REQ_PARA_OBJ.fin_year).Distinct().ToList();
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).posting_period);
                    TheFilter = (o, prefix) => (((STD_LIST_BE)o).posting_period ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).display_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    AS_POSTING_PERIOD = new AutoSuggestTextViewModel<dynamic>(pp_list, TheFilter, SuggestedValue, "posting_period", true);
                    AS_POSTING_PERIOD.AutoSuggestVM.IsEmptyValueAllowed = true; AS_POSTING_PERIOD.AutoSuggestVM.IsFreeTextAllowed = false;
                }
                if (sender.ToString() == "posting_period")
                {
                    List<STD_LIST_BE> pp_list2 = MC.POSTING_PERIOD_LIST.Where(o => o.fin_year == REQ_PARA_OBJ.fin_year && o.posting_period == REQ_PARA_OBJ.posting_period).ToList();
                    if (pp_list2 != null)
                    {
                        if (pp_list2.Count > 0)
                        {
                            REQ_PARA_OBJ.para1 = pp_list2[0].display_name;
                            REQ_PARA_OBJ.fin_year = pp_list2[0].fin_year;
                            REQ_PARA_OBJ.posting_period = pp_list2[0].posting_period;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + ts_code_vm;
                MC = repository_MC.GetDataWithReturnDomainObject<STD_MIS_MC_BE>(MC, Request, "MM_R03", "MM", " ", 0, "");

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).view_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).view_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).obj_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_REPORTS = new AutoSuggestTextViewModel<dynamic>(MC.REPORT_LIST, TheFilter, SuggestedValue, "view_code", true);
                AS_REPORTS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_REPORTS.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).field_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).field_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).display_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_SORT_ORDER = new AutoSuggestTextViewModel<dynamic>(MC.SORT_ORDER_LIST, TheFilter, SuggestedValue, "field_code", true);
                AS_SORT_ORDER.AutoSuggestVM.IsEmptyValueAllowed = true; AS_SORT_ORDER.AutoSuggestVM.IsFreeTextAllowed = false;

                var ENUM_LIST = Enum.GetValues(typeof(ENUM_SORT_DIRECTION))
                               .Cast<ENUM_SORT_DIRECTION>()
                               .Select(t => new ENUM_STD_LIST
                               {
                                   enum_value = t.ToString()
                               });
                List<ENUM_STD_LIST> ENUM_LIST_OBJ = new List<ENUM_STD_LIST>();
                ENUM_LIST_OBJ = ENUM_LIST.ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ENUM_STD_LIST)x).enum_value);
                TheFilter = (o, prefix) => (((ENUM_STD_LIST)o).enum_value ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ENUM_STD_LIST)o).enum_value ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ENUM = new AutoSuggestTextViewModel<dynamic>(ENUM_LIST_OBJ, TheFilter, SuggestedValue, "Direction", true);
                AS_ENUM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ENUM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_DOC_CAT)x).doc_cat);
                TheFilter = (o, prefix) => (((STD_DOC_CAT)o).doc_cat ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_DOC_CAT)o).cat_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_DOC_CAT = new AutoSuggestTextViewModel<dynamic>(MC.DOC_CAT_LIST, TheFilter, SuggestedValue, "doc_cat", true);
                AS_DOC_CAT.AutoSuggestVM.IsEmptyValueAllowed = true; AS_DOC_CAT.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_DOC_TYPE)x).doc_type);
                TheFilter = (o, prefix) => (((STD_DOC_TYPE)o).doc_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_DOC_TYPE)o).type_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_DOC_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.DOC_TYPE_LIST, TheFilter, SuggestedValue, "doc_type", true);
                AS_DOC_TYPE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_DOC_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M0002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0002)o).comp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", true);
                AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_COMPANY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id ?? "");
                TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M0003)o).location_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(MC.LOCATION_LIST, TheFilter, SuggestedValue, "location_id", true);
                AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = true; AS_LOCATION.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).party_code ?? "");
                TheFilter = (o, prefix) => (((STD_PARTY)o).party_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_PARTY)o).party_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_CUSTOMERS = new AutoSuggestTextViewModel<dynamic>(MC.PARTY_LIST, TheFilter, SuggestedValue, "party_code", true);
                AS_CUSTOMERS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_CUSTOMERS.AutoSuggestVM.IsFreeTextAllowed = false;

                List<STD_PARTY> PARTY_LIST_SHIP_TO = MC.PARTY_LIST.Where(x => x.party_code != null).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).party_code ?? "");
                TheFilter = (o, prefix) => (((STD_PARTY)o).party_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_PARTY)o).party_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_CUSTOMERS_SHIP_TO = new AutoSuggestTextViewModel<dynamic>(PARTY_LIST_SHIP_TO, TheFilter, SuggestedValue, "party_code", true);
                AS_CUSTOMERS_SHIP_TO.AutoSuggestVM.IsEmptyValueAllowed = true; AS_CUSTOMERS_SHIP_TO.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).po_code ?? "");
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).po_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_LIST_BE)o).po_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_ORGANISATION = new AutoSuggestTextViewModel<dynamic>(MC.ORG_LIST, TheFilter, SuggestedValue, "po_code", true);
                AS_ORGANISATION.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ORGANISATION.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).pg_code ?? "");
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).pg_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_LIST_BE)o).pg_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_ORG_GROUP = new AutoSuggestTextViewModel<dynamic>(MC.ORG_GROUP_LIST, TheFilter, SuggestedValue, "pg_code", true);
                AS_ORG_GROUP.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ORG_GROUP.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id ?? "");
                TheFilter = (o, prefix) => (((STD_PERSONNEL)o).emp_id ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_PERSONNEL)o).emp_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_PERSONNEL = new AutoSuggestTextViewModel<dynamic>(MC.PERSONNEL_LIST, TheFilter, SuggestedValue, "emp_id", true);
                AS_PERSONNEL.AutoSuggestVM.IsEmptyValueAllowed = true; AS_PERSONNEL.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).ind_code ?? "");
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).ind_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_LIST_BE)o).ind_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_TRADE_INDICATOR = new AutoSuggestTextViewModel<dynamic>(MC.TRADE_INDICATOR, TheFilter, SuggestedValue, "ind_code", true);
                AS_TRADE_INDICATOR.AutoSuggestVM.IsEmptyValueAllowed = true; AS_TRADE_INDICATOR.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code ?? "");
                TheFilter = (o, prefix) => (((STD_ITEM)o).ItemCode ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_ITEM)o).item_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_ITEMS = new AutoSuggestTextViewModel<dynamic>(MC.STD_ITEM_LIST, TheFilter, SuggestedValue, "item_code", true);
                AS_ITEMS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ITEMS.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M018)x).item_cat ?? "");
                TheFilter = (o, prefix) => (((ADM_M018)o).item_cat ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M018)o).item_cat_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_ITEM_CATEGORY = new AutoSuggestTextViewModel<dynamic>(MC.ITEM_CAT_LIST, TheFilter, SuggestedValue, "item_cat", true);
                AS_ITEM_CATEGORY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ITEM_CATEGORY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M019)x).item_subcat ?? "");
                TheFilter = (o, prefix) => (((ADM_M019)o).item_subcat ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M019)o).item_subcat_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_ITEM_SUB_CATEGORY = new AutoSuggestTextViewModel<dynamic>(MC.ITEM_SUBCAT_LIST, TheFilter, SuggestedValue, "item_subcat", true);
                AS_ITEM_SUB_CATEGORY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ITEM_SUB_CATEGORY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M015)x).item_type ?? "");
                TheFilter = (o, prefix) => (((ADM_M015)o).item_type ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M015)o).item_type_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_ITEM_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.ITEM_TYPE_LIST, TheFilter, SuggestedValue, "item_type", true);
                AS_ITEM_TYPE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ITEM_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M016)x).item_subtype ?? "");
                TheFilter = (o, prefix) => (((ADM_M016)o).item_subtype ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M016)o).item_subtype_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_ITEM_SUB_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.ITEM_SUBTYPE_LIST, TheFilter, SuggestedValue, "item_subtype", true);
                AS_ITEM_SUB_TYPE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ITEM_SUB_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).country_key ?? "");
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).country_key ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_LIST_BE)o).country_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_COUNTRY = new AutoSuggestTextViewModel<dynamic>(MC.COUNTRY_LIST, TheFilter, SuggestedValue, "country_key", true);
                AS_COUNTRY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_COUNTRY.AutoSuggestVM.IsFreeTextAllowed = false;

                //--17) Region List
                //--18) Customer Group List

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).incoterm ?? "");
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).incoterm ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_LIST_BE)o).inco_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_INCOTERMS = new AutoSuggestTextViewModel<dynamic>(MC.INCOTERM_LIST, TheFilter, SuggestedValue, "incoterm", true);
                AS_INCOTERMS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_INCOTERMS.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037)x).curr_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M037)o).curr_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M037)o).curr_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_CURRENCY = new AutoSuggestTextViewModel<dynamic>(MC.CURRENCY_LIST, TheFilter, SuggestedValue, "curr_code", true);
                AS_CURRENCY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_CURRENCY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM.AutoSuggestVM.IsFreeTextAllowed = false;

                List<UOMS> CURR_UOM_LIST = MC.UOM_LIST.Where(x => x.unit_code != null).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_CURR_UOM = new AutoSuggestTextViewModel<dynamic>(CURR_UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                AS_CURR_UOM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_CURR_UOM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_STATUS = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_status", true);
                AS_STATUS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_STATUS.AutoSuggestVM.IsFreeTextAllowed = false;

                List<STD_LIST_BE> fin_year_list = MC.POSTING_PERIOD_LIST.GroupBy(test => test.fin_year)
                   .Select(grp => grp.First())
                   .ToList().Distinct().ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).fin_year);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).fin_year ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).display_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_FIN_YEAR = new AutoSuggestTextViewModel<dynamic>(fin_year_list, TheFilter, SuggestedValue, "fin_year", true);
                AS_FIN_YEAR.AutoSuggestVM.IsEmptyValueAllowed = true; AS_FIN_YEAR.AutoSuggestVM.IsFreeTextAllowed = false;


            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void DisplayReport(object tem)
        {
            try
            {
                if (REQ_PARA_OBJ == null)
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Report Type"); sms.ShowMessage();
                }
                else
                {
                    MIS_OBJ = MC.REPORT_LIST.Where(x => x.view_code == REQ_PARA_OBJ.view_code && x.ts_code == REQ_PARA_OBJ.ts_code).ToList()[0];
                }
                if (string.IsNullOrWhiteSpace(REQ_PARA_OBJ.view_code))
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Report Type"); sms.ShowMessage();
                }
                else if (string.IsNullOrWhiteSpace(REQ_PARA_OBJ.comp_code))
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Company"); sms.ShowMessage();
                }
                else if (MIS_OBJ.sql_code == "R0005" && string.IsNullOrWhiteSpace(REQ_PARA_OBJ.item_cat))
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Material Category"); sms.ShowMessage();
                }
                else
                {
                    if (REQ_PARA_OBJ != null)
                    {
                        CursorControl.SetBusyState();
                        //MIS_OBJ = MC.REPORT_LIST.Where(x => x.view_code == REQ_PARA_OBJ.view_code && x.ts_code == REQ_PARA_OBJ.ts_code).ToList()[0];

                        string Request = "REPORT" + "!@" + AppSessionState.client + "!@" + REQ_PARA_OBJ.comp_code + "!@" + REQ_PARA_OBJ.location_id + "!@" + REQ_PARA_OBJ.doc_cat + "!@" + REQ_PARA_OBJ.doc_type + "!@" + MIS_OBJ.ts_code + "!@" + MIS_OBJ.view_code + "!@" + MIS_OBJ.sql_code + "!@" + REQ_PARA_OBJ.party_code + "!@" + REQ_PARA_OBJ.para1 + "!@" + REQ_PARA_OBJ.so_code + "!@" + REQ_PARA_OBJ.sg_code + "!@" + REQ_PARA_OBJ.emp_id + "!@" + REQ_PARA_OBJ.ind_code + "!@" + REQ_PARA_OBJ.item_code + "!@" + REQ_PARA_OBJ.item_cat + "!@" + REQ_PARA_OBJ.item_subcat + "!@" + REQ_PARA_OBJ.item_type + "!@" + REQ_PARA_OBJ.item_subtype + "!@" + REQ_PARA_OBJ.country_key + "!@" + REQ_PARA_OBJ.para2 + "!@" + REQ_PARA_OBJ.para3 + "!@" + REQ_PARA_OBJ.incoterm + "!@" + REQ_PARA_OBJ.curr_code + "!@" + REQ_PARA_OBJ.curr_unit + "!@" + REQ_PARA_OBJ.unit_code + "!@" + REQ_PARA_OBJ.t_status + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy") + "!@" + REQ_PARA_OBJ.para4 + "!@" + REQ_PARA_OBJ.field_code + "!@" + REQ_PARA_OBJ.field_direction + "!@" + REQ_PARA_OBJ.fin_year + "!@" + REQ_PARA_OBJ.posting_period;
                        MC_TEMP = repository_MC.GetDataWithReturnDomainObject<STD_MC_BE>(MC_TEMP, Request, "MM_R03", "MM", " ", 0, "");

                        REQ_PARA_OBJ.obj_code = MIS_OBJ.obj_code;
                        REQ_PARA_OBJ.obj_name = MIS_OBJ.obj_name;
                        REQ_PARA_OBJ.comp_name = MC.COMPANY_LIST.Where(x => x.comp_code == REQ_PARA_OBJ.comp_code).ToList()[0].comp_name;
                        object[] objDataSource = new object[1];
                        string[] objDataSourceName = new string[1];

                        objDataSource[0] = MC_TEMP.STD_MIS_LIST;
                        objDataSourceName[0] = "dsMIS_1";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, MIS_OBJ.obj_path + MIS_OBJ.obj_file, getParametersList(), MIS_OBJ.obj_name);
                    }
                    else
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("No record found", this.Title); sms.ShowMessage();
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("from_date", Convert.ToString(REQ_PARA_OBJ.from_date ?? System.DateTime.Now));
                result.Add("to_date", Convert.ToString(REQ_PARA_OBJ.to_date ?? System.DateTime.Now));
                result.Add("rpt_title", Convert.ToString(REQ_PARA_OBJ.obj_name));
                result.Add("comp_code", Convert.ToString(REQ_PARA_OBJ.comp_code));
                result.Add("comp_name", Convert.ToString(REQ_PARA_OBJ.comp_name));
                result.Add("para1", Convert.ToString(REQ_PARA_OBJ.para4));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();

            }
            return result;
        }
        #region Abstract Classes Implementation
        protected override void OnDocumentAction()
        {

        }

        protected override void OnSaveAction(InquiryActionResult<STD_LIST_BE> result)
        {

        }

        protected override void OnCreateAction(InquiryActionResult<STD_LIST_BE> result)
        {
        }

        protected override void OnRemoveAction(InquiryActionResult<STD_LIST_BE> result)
        {

        }

        protected override void OnDiscardAction(InquiryActionResult<STD_LIST_BE> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<STD_LIST_BE> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<STD_LIST_BE> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<STD_LIST_BE> result)
        {

        }

        protected override void OnFevoriteAction(InquiryActionResult<STD_LIST_BE> result)
        {

        }

        protected override void OnRefreshCommand(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
