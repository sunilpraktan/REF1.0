using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Services;
using System.Windows.Data;
using System.Collections.ObjectModel;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.FICO;
using System.Collections.Specialized;
using System.Collections;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0032_VM : WorkspaceViewModel<ACC_M0032>
    {
        private string ts_code_vm { get; set; }
        WebServiceRepository<List<ACC_M0032>> repository = new WebServiceRepository<List<ACC_M0032>>();
        WebServiceRepository<MC_ACC_M0032> repository_MC = new WebServiceRepository<MC_ACC_M0032>();
        WebServiceRepository<MC_ACC_M0032> repository_MC_TEMP = new WebServiceRepository<MC_ACC_M0032>();
        ObjectSerializationService SERIALIZATION_OBJ = new ObjectSerializationService();
        IShowMessageViewService sms;

        #region AutoSuggest TextBox Declaration Region

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
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
        private AutoSuggestTextViewModel<dynamic> _AS_CURR_FROM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CURR_FROM
        {
            get { return _AS_CURR_FROM; }
            set
            {
                if (_AS_CURR_FROM != value)
                {
                    _AS_CURR_FROM = value; RaisePropertyChanged("AS_CURR_FROM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_CURR_TO { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CURR_TO
        {
            get { return _AS_CURR_TO; }
            set
            {
                if (_AS_CURR_TO != value)
                {
                    _AS_CURR_TO = value; RaisePropertyChanged("AS_CURR_TO");
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
                    if (SourceName == "curr_code_from")
                    { AS_DEFAULT = AS_CURR_FROM; }
                    else if (SourceName == "curr_code_to")
                    { AS_DEFAULT = AS_CURR_TO; }
                }
            }
        }

        #endregion

        #region Declarations       

        private MC_ACC_M0032 _MC;
        public MC_ACC_M0032 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }
        private MC_ACC_M0032 _MC_TEMP;
        public MC_ACC_M0032 MC_TEMP
        {
            get { return _MC_TEMP; }
            set { _MC_TEMP = value; RaisePropertyChanged("MC_TEMP"); }
        }
        private ACC_M0032 _ACC_M0032_OBJ;
        public ACC_M0032 ACC_M0032_OBJ
        {
            get
            { return _ACC_M0032_OBJ; }
            set
            {
                _ACC_M0032_OBJ = value;
                RaisePropertyChanged("ACC_M0032_OBJ");
            }
        }
        private STD_REQ_PARA_BE _REQUEST_PARA;
        public STD_REQ_PARA_BE REQUEST_PARA
        {
            get { return _REQUEST_PARA; }
            set { _REQUEST_PARA = value; RaisePropertyChanged("REQUEST_PARA"); }
        }
        #endregion

        #region ICollectionView
        private ObservableCollection<ACC_M0032> _ACC_M0032_OC;
        public ObservableCollection<ACC_M0032> ACC_M0032_OC
        {
            get { return _ACC_M0032_OC; }
            set
            {
                if (_ACC_M0032_OC != value)
                {
                    _ACC_M0032_OC = value;
                    ACC_M0032_OC.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotify_Item);
                    RaisePropertyChanged("ACC_M0032_OC");
                }
            }
        }

        #endregion

        #region Relay Commands Declaration       
        public RelayCommand<object> cmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> cmdInsertCurrencyFrom { get; private set; }
        public RelayCommand<object> cmdInsertCurrencyTo { get; private set; }
        public RelayCommand<object> cmdSelectionChangedItem { get; private set; }
        public RelayCommand<object> cmdLoadData { get; private set; }
        public RelayCommand<object> btnUpdateRates { get; private set; }

        #endregion
        #region Constructor
        public FICO_M0032_VM(string ts_code) : base()
        {
            ts_code_vm = ts_code;
            ACC_M0032_OBJ = new ACC_M0032();
            ACC_M0032_OC = new ObservableCollection<ACC_M0032>();
            MC = new MC_ACC_M0032();
            MC_TEMP = new MC_ACC_M0032();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            sms = this.GetViewService<IShowMessageViewService>();
            cmdDeleteDataGridRowItem = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRowItem(items); });
            cmdInsertCurrencyFrom = new RelayCommand<object>(items => { if (items == null) { return; } InsertCurrencyFrom(items); });
            cmdInsertCurrencyTo = new RelayCommand<object>(items => { if (items == null) { return; } InsertCurrencyTo(items); });
            cmdSelectionChangedItem = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChangedItem(items); });
            cmdLoadData = new RelayCommand<object>(items => { if (items == null) { return; } LoadData(items); });
            btnUpdateRates = new RelayCommand<object>(items => { if (items == null) { return; } UpdateRates(items); });
            ACC_M0032_OC.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotify_Item);
            LoadInitialData();
        }
        private void UpdateRates(object InputValue)
        {
            try
            {
                string Request = "LOAD_RECORDS" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + ts_code_vm + "!@" + ts_code_vm + "!@" + AppSessionState.UserID + "!@" + AppSessionState.UserID;
                MC_TEMP = repository_MC.GetDataWithReturnDomainObject<MC_ACC_M0032>(MC, Request, "FICO_M0032_BL", "FICO", "LOAD_INI", 0, "");

                if (MC_TEMP.MASTER_ENTITY_LIST != null)
                {
                    ACC_M0032_OC = MC_TEMP.MASTER_ENTITY_LIST;
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record Saved and Updated Successfully", this.Title); sms.ShowMessage();
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void LoadData(object InputValue)
        {
            try
            {
                string Request = "LOAD_RECORDS" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + ts_code_vm + "!@" + ts_code_vm + "!@" + Convert.ToDateTime(REQUEST_PARA.from_date).ToString("MM/dd/yyyy") + "!@" + AppSessionState.UserID;
                MC_TEMP = repository_MC.GetDataWithReturnDomainObject<MC_ACC_M0032>(MC, Request, "FICO_M0032_BL", "FICO", "LOAD_INI", 0, "");

                if (MC_TEMP.MASTER_ENTITY_LIST != null)
                {
                    ACC_M0032_OC = MC_TEMP.MASTER_ENTITY_LIST;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void SelectionChangedItem(object InputValue)
        {
            try
            {
                ACC_M0032_OBJ = (ACC_M0032)InputValue;
            }
            catch (Exception ex) { }
        }
        #endregion
        private void InsertCurrencyFrom(object InputValue)
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
                if (POPUPEntityObject != null)
                {
                    ACC_M0032_OBJ.curr_code_from = POPUPEntityObject.curr_code;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertCurrencyTo(object InputValue)
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
                if (POPUPEntityObject != null)
                {
                    ACC_M0032_OBJ.curr_code_to = POPUPEntityObject.curr_code;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void CollectionChangedNotify_Item(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add) 
                {
                    foreach (ACC_M0032 item in e.NewItems)
                    {
                        item.selected = true;
                        item.active = "Y";
                        item.client = AppSessionState.client;
                        item.id = 0;
                        item.ratio_from = 1;
                        item.ratio_to = 1;
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

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + ts_code_vm + "!@" + AppSessionState.UserID;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_ACC_M0032>(MC, Request, "FICO_M0032_BL", "FICO", "LOAD_INI", 0, "");

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037)o).curr_code ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower()) || (((ADM_M037)o).curr_name ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower());
                AS_DEFAULT = new AutoSuggestTextViewModel<dynamic>(MC.CURRENCY_LIST, TheFilter, SuggestedValue, "curr_code_from", "curr_code", true);
                AS_DEFAULT.AutoSuggestVM.IsEmptyValueAllowed = true; AS_DEFAULT.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037)o).curr_code ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower()) || (((ADM_M037)o).curr_name ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower());
                AS_CURR_FROM = new AutoSuggestTextViewModel<dynamic>(MC.CURRENCY_LIST, TheFilter, SuggestedValue, "curr_code_from", "curr_code", true);
                AS_CURR_FROM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_CURR_FROM.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M037)x).curr_code);
                TheFilter = (o, prefix) => (((ADM_M037)o).curr_code ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower()) || (((ADM_M037)o).curr_name ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower());
                AS_CURR_TO = new AutoSuggestTextViewModel<dynamic>(MC.CURRENCY_LIST, TheFilter, SuggestedValue, "curr_code_to", "curr_code", true);
                AS_CURR_TO.AutoSuggestVM.IsEmptyValueAllowed = true; AS_CURR_TO.AutoSuggestVM.IsFreeTextAllowed = true;

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format(ex.Message, this.Title);sms.ShowMessage();
            }
        }
        private void DeleteDataGridRowItem(object InputValue)
        {
            try
            {
                if (ACC_M0032_OBJ != null)
                {
                    if (ACC_M0032_OBJ.id == 0)
                    {
                        ACC_M0032_OC.Remove(ACC_M0032_OBJ);
                    }
                }
            }
            catch (Exception ex){}
        }

        private bool Validation()
        {
            foreach (var o in ACC_M0032_OC)
            {
                if (!string.IsNullOrWhiteSpace(o.curr_code_from) || !string.IsNullOrWhiteSpace(o.curr_code_to) || !o.exch_rate.HasValue)
                {
                    if (!o.ratio_from.HasValue || !o.ratio_to.HasValue)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Ratio cannot be null or 0 for the Currency {0} and Currency {1}", o.curr_code_from, o.curr_code_to);
                        showMessageService.ShowMessage();
                        return false;
                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("please select currency pair and input exchange rate for the pair.");
                    showMessageService.ShowMessage();
                    return false;
                }
            }
            return true;
        }

        #endregion

        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<ACC_M0032> result)
        {
            try
            {
                List<ACC_M0032> REQUEST_LIST_OBJ = new List<ACC_M0032>();

                foreach (ACC_M0032 item in ACC_M0032_OC)
                {
                    if (item.selected == true)
                    {
                        REQUEST_LIST_OBJ.Add(item);
                    }
                }

                if (REQUEST_LIST_OBJ.Count > 0)
                {
                    string strReturn = repository.Save<List<ACC_M0032>>(REQUEST_LIST_OBJ, "FICO_M0032_BL", "FICO");

                    MC_TEMP = (MC_ACC_M0032)new ObjectSerializationService().XMLToObject(strReturn, MC_TEMP);
                    
                    if (MC_TEMP.MASTER_ENTITY_LIST != null)
                    {
                        ACC_M0032_OC = MC_TEMP.MASTER_ENTITY_LIST;
                        sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Record Saved and Updated Successfully", this.Title);sms.ShowMessage();
                    }
                }
                else
                {
                    sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format("Please select the Rows to Add/Update ");sms.ShowMessage();
                }
            }

            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format(ex.Message, this.Title);sms.ShowMessage();
            }
        }

        protected override void OnDocumentAction()
        {
        }
        protected override void OnRefreshCommand(InquiryActionResult<ACC_M0032> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M0032> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M0032> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M0032> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M0032> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ACC_M0032> result)
        {
            ACC_M0032_OC = new ObservableCollection<ACC_M0032>();
        }
        protected override void OnRemoveAction(InquiryActionResult<ACC_M0032> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text = String.Format("This record will be Deleted forever", this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
                //string response = repository.Delete(MasterEntity.SrNo, "FormReceivedFrmCustomer", "CRM");  
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ACC_M0032> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_M0032> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ACC_M0032> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ACC_M0032> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ACC_M0032> result)
        {

        }

        #endregion
       
    }
}
