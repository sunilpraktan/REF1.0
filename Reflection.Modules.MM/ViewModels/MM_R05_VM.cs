using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.MM;
using Reflection.Presentation.Common;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Reflection.ReportingServices;
using System.Collections.Generic;

namespace Reflection.Modules.MM.ViewModels
{
    public class MM_R05_VM : WorkspaceViewModel<STD_LIST_BE>
    {
        WebServiceRepository<STD_MIS_MC_BE> REPO_MC = new WebServiceRepository<STD_MIS_MC_BE>();
        ObjectSerializationService obj = new ObjectSerializationService();

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

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

        private STD_REQ_PARA_BE _REQ_PARA_OBJ;
        public STD_REQ_PARA_BE REQ_PARA_OBJ
        {
            get
            {
                return _REQ_PARA_OBJ;
            }
            set
            {
                if (_REQ_PARA_OBJ != value)
                {
                    _REQ_PARA_OBJ = value;
                    RaisePropertyChanged(nameof(REQ_PARA_OBJ));
                    value.BeginEdit();
                }
            }
        }
        private STD_MIS_BE _STD_MIS_OBJ = new STD_MIS_BE();
        public STD_MIS_BE STD_MIS_OBJ
        {
            get { return _STD_MIS_OBJ; }
            set { if (_STD_MIS_OBJ != value) { _STD_MIS_OBJ = value; RaisePropertyChanged("STD_MIS_OBJ"); } }
        }


        #region Autosuggest

        //public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(MM_R05_VM));
        //public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
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
        private AutoSuggestTextViewModel<dynamic> _AS_ASSETS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ASSETS
        {
            get { return _AS_ASSETS; }
            set
            {
                if (_AS_ASSETS != value)
                {
                    _AS_ASSETS = value; RaisePropertyChanged("AS_ASSETS");
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

        #region Relay Commands Declaration

        public RelayCommand<object> cmdGenerate { get; private set; }
        public RelayCommand<object> cmdPrint { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvokeDocument { get; private set; }

        #endregion

        public MM_R05_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            STD_MIS_OBJ = new STD_MIS_BE();
            InitializedCommands();
            LoadInitialData();
        }

        private void DisplayPrint()
        {
            try
            {

            }
            catch (Exception ex)
            {
                //sms.Text = String.Format(ex.Message, this.Title);
            }

        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + ts_code_vm;
                MC = REPO_MC.GetDataWithReturnDomainObject<STD_MIS_MC_BE>(MC, Request, "MM_R04", "MM", " ", 0, "");

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).view_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).view_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).obj_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_REPORTS = new AutoSuggestTextViewModel<dynamic>(MC.REPORT_LIST, TheFilter, SuggestedValue, "view_code", true);
                AS_REPORTS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_REPORTS.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M0002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0002)o).comp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", true);
                AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_COMPANY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id ?? "");
                TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M0003)o).location_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(MC.LOCATION_LIST, TheFilter, SuggestedValue, "location_id", true);
                AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = true; AS_LOCATION.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code ?? "");
                TheFilter = (o, prefix) => (((STD_ITEM)o).item_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_ITEM)o).item_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_ITEMS = new AutoSuggestTextViewModel<dynamic>(MC.STD_ITEM_LIST, TheFilter, SuggestedValue, "item_code", true);
                AS_ITEMS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ITEMS.AutoSuggestVM.IsFreeTextAllowed = false;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                //TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //AS_UOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                //AS_UOM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).equip_no);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).equip_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).equip_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ASSETS = new AutoSuggestTextViewModel<dynamic>(MC.ASSET_LIST, TheFilter, SuggestedValue, "equip_no", true);
                AS_ASSETS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ASSETS.AutoSuggestVM.IsFreeTextAllowed = false;


                DefaultValues(null);
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InitializedCommands()
        {
            cmdGenerate = new RelayCommand<object>(items => { if (items == null) { return; } GenerateData(items); });
            cmdPrint = new RelayCommand<object>(items => { if (items == null) { return; } DisplayReport(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdInvokeDocument = new RelayCommand<object>(items => { if (items == null) { return; } InvokeDocument(items); });
        }

        private void DefaultValues(string doc_info)
        {
            REQ_PARA_OBJ.from_date = DateTime.Now;
            REQ_PARA_OBJ.to_date = DateTime.Now;
            REQ_PARA_OBJ.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            REQ_PARA_OBJ.location_id = AppSessionState.OBJ_LOCATION.location_id;
            REQ_PARA_OBJ.value_code = "P";
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null)
                {
                    DefaultValues(null);
                    //MasterEntity.storage_level = "P";
                }
                else
                {
                    DefaultValues(null);
                }
                //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private void GenerateData(object InputValue)
        {
            try
            {
                REQ_PARA_OBJ.obj_code = "R0001";
                string Request = "REPORT" + "!@" + AppSessionState.client.ToString() + "!@" + REQ_PARA_OBJ.comp_code.ToString() + "!@" + REQ_PARA_OBJ.location_id + "!@" + REQ_PARA_OBJ.obj_code + "!@" + REQ_PARA_OBJ.store_code + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy") + "!@" + REQ_PARA_OBJ.unit_code + "!@" + REQ_PARA_OBJ.item_code + "!@" + REQ_PARA_OBJ.equip_no;
                MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<STD_MIS_MC_BE>(MC_TEMP, Request, "MM_R05", "MM", " ", 0, "");

                MC.STD_MIS_LIST = MC_TEMP.STD_MIS_LIST;
                DG_MIS_COLLECTION = CollectionViewSource.GetDefaultView(MC.STD_MIS_LIST);
                DG_MIS_COLLECTION.Filter = new Predicate<object>(FLT_DG_COLLECTION);
                DG_MIS_COLLECTION.Refresh();


            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        #region Filter
        private ICollectionView _DG_MIS_COLLECTION;
        public ICollectionView DG_MIS_COLLECTION
        {
            get { return _DG_MIS_COLLECTION; }
            set
            {
                _DG_MIS_COLLECTION = value;
                RaisePropertyChanged("DG_MIS_COLLECTION");
            }
        }

        private string _FLT_STR_DG_COLLECTION;
        public string FLT_STR_DG_COLLECTION
        {
            get { return _FLT_STR_DG_COLLECTION; }
            set
            {
                _FLT_STR_DG_COLLECTION = value;
                RaisePropertyChanged("FLT_STR_DG_COLLECTION");
                FLT_DG_COLLECTION_FUN();
            }
        }
        private void FLT_DG_COLLECTION_FUN()
        {
            if (_DG_MIS_COLLECTION != null)
            {
                _DG_MIS_COLLECTION.Refresh();
            }
        }
        public bool FLT_DG_COLLECTION(object obj)
        {
            var data = obj as STD_MIS_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FLT_STR_DG_COLLECTION))
                {
                    return (data.item_code != null && (data.item_code ?? "").ToString().ToLower().Contains(_FLT_STR_DG_COLLECTION.ToLower())) ||
                           (data.location_id != null && (data.location_id ?? "").ToString().ToLower().Contains(_FLT_STR_DG_COLLECTION.ToLower())) ||
                           (data.store_code != null && (data.store_code ?? "").ToString().ToLower().Contains(_FLT_STR_DG_COLLECTION.ToLower())) ||
                           (data.short_text != null && (data.short_text ?? "").ToString().ToLower().Contains(_FLT_STR_DG_COLLECTION.ToLower())) ||
                           (data.comp_code != null && (data.comp_code ?? "").ToString().ToLower().Contains(_FLT_STR_DG_COLLECTION.ToLower()));


                }
                return true;
            }
            return false;
        }
        #endregion
        private void DisplayReport(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                ReportManager ReportManager = new ReportManager();
                object[] objDataSource = new object[1];
                string[] objDataSourceName = new string[1];
                string ReportName = "";

                objDataSource[0] = MC.STD_MIS_LIST;
                objDataSourceName[0] = "dsMIS_1";

                string ReportDisplayName = "Trace Report";
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORTS_STD\\MIS\\MM_M137.rdlc",getParametersList(null), ReportDisplayName);

            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        private Dictionary<string, string> getParametersList(string paraValue)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("from_date", REQ_PARA_OBJ.from_date.ToString());
                result.Add("to_date", REQ_PARA_OBJ.to_date.ToString());
                result.Add("rpt_title", "Trace Report");
                result.Add("para1", $"{REQ_PARA_OBJ.item_code}");
                result.Add("comp_code", REQ_PARA_OBJ.to_date.ToString());
                result.Add("comp_name", REQ_PARA_OBJ.to_date.ToString());
                //result.Add("PrintOption", paraValue);
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
            return result;
        }
        private void InvokeDocument(object InputValue)
        {
            try
            {
                string Request = "";
                ReflectionFunctionService objRef = new ReflectionFunctionService();
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    STD_LIST_BE STD_LIST_OBJ = new STD_LIST_BE();
                    STD_LIST_OBJ.doc_cat = STD_MIS_OBJ.doc_cat;
                    STD_LIST_OBJ.doc_type = STD_MIS_OBJ.doc_type;
                    STD_LIST_OBJ.doc_no = STD_MIS_OBJ.doc_no;
                    STD_LIST_OBJ.client = AppSessionState.client;
                    STD_LIST_OBJ.comp_code = STD_MIS_OBJ.comp_code;
                    STD_LIST_OBJ.location_id = STD_MIS_OBJ.location_id;
                    STD_LIST_OBJ.request_type = "INVOKE_DOC";
                    STD_LIST_OBJ.request = "IDOC";

                    STD_LIST_OBJ.request = "GET_TSCODE!@" + AppSessionState.client + "!@" + STD_MIS_OBJ.comp_code + "!@" + (STD_MIS_OBJ.location_id ?? "") + "!@" + (STD_MIS_OBJ.doc_cat ?? "") + "!@" + (STD_MIS_OBJ.doc_type ?? "") + "!@" + STD_MIS_OBJ.doc_no;
                    objRef.Invoke_Documet(STD_LIST_OBJ);
                }
                #endregion
            }
            catch (Exception ex)
            { }
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
            //SelectedSEL_T001.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<STD_LIST_BE> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<STD_LIST_BE> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<STD_LIST_BE> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<STD_LIST_BE> result)
        {

        }
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
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
    }
}
