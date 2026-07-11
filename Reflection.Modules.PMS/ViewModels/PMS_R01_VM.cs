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

namespace Reflection.Modules.PMS.ViewModels
{
    public class PMS_R01_VM : WorkspaceViewModel<STD_LIST_BE>
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
        private STD_LIST_BE _MIS_T001_OBJ = new STD_LIST_BE();
        public STD_LIST_BE MIS_T001_OBJ
        {
            get { return _MIS_T001_OBJ; }
            set { if (_MIS_T001_OBJ != value) { _MIS_T001_OBJ = value; RaisePropertyChanged("MIS_T001_OBJ"); } }
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
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PMS_R01_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        private AutoSuggestTextViewModel<dynamic> _AS_REPORT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_REPORT
        {
            get { return _AS_REPORT; }
            set
            {
                if (_AS_REPORT != value)
                {
                    _AS_REPORT = value; RaisePropertyChanged("AS_REPORT");
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

        #endregion

        #region RelayCommands  
        public RelayCommand<object> cmdGenerateReport { get; private set; }
        #endregion
        public PMS_R01_VM(string ts_code) : base()
        {
            sms = this.GetViewService<IShowMessageViewService>();
            ts_code_vm = ts_code;
            MC = new STD_MIS_MC_BE();
            MIS_T001_OBJ = new STD_LIST_BE();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            REQ_PARA_OBJ.ts_code = ts_code;
            STD_REQ_PARA_BE.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            cmdGenerateReport = new RelayCommand<object>(items => { if (items == null) { return; } DisplayReport(items); });
            LoadInitialData();
        }
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            try
            {
                if (sender.ToString() == "fin_year")
                {
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
                string Request = "LoadInitialData" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + ts_code_vm;
                MC = repository_MC.GetDataWithReturnDomainObject<STD_MIS_MC_BE>(MC, Request, "MIS_STD_MM_2", "SCM", " ", 0, "");

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).rpt_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).rpt_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).rpt_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_REPORT = new AutoSuggestTextViewModel<dynamic>(MC.REPORT_LIST, TheFilter, SuggestedValue, "rpt_code", true);
                AS_REPORT.AutoSuggestVM.IsEmptyValueAllowed = true; AS_REPORT.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M002)o).CompName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", true);
                AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_COMPANY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_id ?? "");
                TheFilter = (o, prefix) => (((ADM_M003)o).location_id ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003)o).location_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(MC.LOCATION_LIST, TheFilter, SuggestedValue, "location_id", true);
                AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = true; AS_LOCATION.AutoSuggestVM.IsFreeTextAllowed = false;

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

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code ?? "");
                TheFilter = (o, prefix) => (((STD_ITEM)o).ItemCode ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_ITEM)o).item_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_ITEMS = new AutoSuggestTextViewModel<dynamic>(MC.STD_ITEM_LIST, TheFilter, SuggestedValue, "item_code", true);
                AS_ITEMS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ITEMS.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM.AutoSuggestVM.IsFreeTextAllowed = false;


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
                else if (string.IsNullOrWhiteSpace(REQ_PARA_OBJ.comp_code))
                {
                    IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Company"); sms.ShowMessage();
                }
                else
                {
                    if (REQ_PARA_OBJ != null)
                    {
                        CursorControl.SetBusyState();
                        MIS_T001_OBJ = MC.REPORT_LIST.Where(x => x.rpt_code == REQ_PARA_OBJ.rpt_code && x.ts_code == REQ_PARA_OBJ.ts_code).ToList()[0];

                        string RequestParameter = "Report" + "!@" + AppSessionState.client + "!@" + REQ_PARA_OBJ.comp_code + "!@" + REQ_PARA_OBJ.location_id + "!@" + MIS_T001_OBJ.sql_code + "!@" + REQ_PARA_OBJ.item_cat + "!@" + REQ_PARA_OBJ.item_subcat + "!@" + REQ_PARA_OBJ.item_type + "!@" + REQ_PARA_OBJ.item_subtype + "!@" + REQ_PARA_OBJ.ts_code + "!@" + REQ_PARA_OBJ.color_code + "!@" + REQ_PARA_OBJ.color_code + "!@" + REQ_PARA_OBJ.color_code + "!@" + REQ_PARA_OBJ.item_code + "!@" + REQ_PARA_OBJ.color_code + "!@" + REQ_PARA_OBJ.color_code + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy") + "!@" + REQ_PARA_OBJ.store_code + "!@" + REQ_PARA_OBJ.unit_code;
                        MC_TEMP = repository_MC.GetDataWithReturnDomainObject<STD_MC_BE>(MC_TEMP, RequestParameter, "MIS_STD_MM_2", "SCM", " ", 0, "");

                        REQ_PARA_OBJ.rpt_title = MIS_T001_OBJ.rpt_title;
                        REQ_PARA_OBJ.comp_name = MC.COMPANY_LIST.Where(x => x.comp_code == REQ_PARA_OBJ.comp_code).ToList()[0].comp_name;
                        object[] objDataSource = new object[1];
                        string[] objDataSourceName = new string[1];

                        objDataSource[0] = MC_TEMP.STD_MIS_LIST;
                        objDataSourceName[0] = "dsMIS_1";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, MIS_T001_OBJ.rpt_path + MIS_T001_OBJ.rpt_file, getParametersList(), MIS_T001_OBJ.obj_name);
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
                result.Add("from_date", Convert.ToString(REQ_PARA_OBJ.from_date));
                result.Add("to_date", Convert.ToString(REQ_PARA_OBJ.to_date));
                result.Add("rpt_title", Convert.ToString(REQ_PARA_OBJ.rpt_title));
                result.Add("comp_code", Convert.ToString(REQ_PARA_OBJ.comp_code));
                result.Add("location_id", Convert.ToString(REQ_PARA_OBJ.location_id));
                result.Add("item_subcat_name", Convert.ToString(REQ_PARA_OBJ.item_subcat_name));
                result.Add("item_cat_name", Convert.ToString(REQ_PARA_OBJ.item_cat_name));
                result.Add("comp_name", Convert.ToString(REQ_PARA_OBJ.comp_name));
                result.Add("store_code", Convert.ToString(REQ_PARA_OBJ.store_code));
                result.Add("store_name", Convert.ToString(REQ_PARA_OBJ.store_name));
                result.Add("item_type_name", Convert.ToString(REQ_PARA_OBJ.item_type_name));
                result.Add("item_subtype_name", Convert.ToString(REQ_PARA_OBJ.item_subtype_name));
                result.Add("unit_code", Convert.ToString(REQ_PARA_OBJ.unit_code));
                result.Add("para1", Convert.ToString(REQ_PARA_OBJ.from_date.Value.ToShortDateString()) + " To " + Convert.ToString(REQ_PARA_OBJ.to_date.Value.ToShortDateString()));
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
