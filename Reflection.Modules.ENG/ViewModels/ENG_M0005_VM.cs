using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ReflectionSystem;
using System.Globalization;
using Reflection.ReportingServices;
using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.PMM;
using Reflection.BusinessEntity.ENG;

namespace Reflection.Modules.PMM.ViewModels
{
    public class ENG_M0005_VM : WorkspaceViewModel<ENG_M0005>
    {
        #region Private Local Variable Declaration
        private bool isNewRecord = true;
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

        private string ts_code_vm { get; set; }
        private string doc_no_vm { get; set; }
        private string doc_cat_vm { get; set; }

        WebServiceRepository<ENG_M0005> REPO = new WebServiceRepository<ENG_M0005>();
        WebServiceRepository<MC_ENG_BE> REPO_MC = new WebServiceRepository<MC_ENG_BE>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MC_ENG_BE _MC = new MC_ENG_BE();
        public MC_ENG_BE MC
        {
            get { return _MC; }
            set { if (_MC != value) { _MC = value; RaisePropertyChanged("MC"); } }
        }
        private MC_ENG_BE _MC_TEMP = new MC_ENG_BE();
        public MC_ENG_BE MC_TEMP
        {
            get { return _MC_TEMP; }
            set { if (_MC_TEMP != value) { _MC_TEMP = value; RaisePropertyChanged("MC_TEMP"); } }
        }

        private ENG_M0005 _MasterEntity;
        public ENG_M0005 MasterEntity
        {
            get { return _MasterEntity; }
            set { if (_MasterEntity != value) { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); } }
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

        private STD_REQ_PARA_BE _REQUEST_PARA;
        public STD_REQ_PARA_BE REQUEST_PARA
        {
            get { return _REQUEST_PARA; }
            set
            {
                if (_REQUEST_PARA != value)
                {
                    _REQUEST_PARA = value;

                    RaisePropertyChanged("REQUEST_PARA");
                }
            }
        }

        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
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

        #endregion

        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(ENG_M0005_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

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
        private AutoSuggestTextViewModel<dynamic> _AS_CHAR { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CHAR
        {
            get { return _AS_CHAR; }
            set
            {
                if (_AS_CHAR != value)
                {
                    _AS_CHAR = value; RaisePropertyChanged("AS_CHAR");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_OBJECT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_OBJECT
        {
            get { return _AS_OBJECT; }
            set
            {
                if (_AS_OBJECT != value)
                {
                    _AS_OBJECT = value; RaisePropertyChanged("AS_OBJECT");
                }
            }
        }

        #endregion
        #region Relay Command
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdLoadBackFlipData { get; private set; }
        public RelayCommand<object> cmdInsertCharacteristic { get; private set; }
        //public RelayCommand<object> cmdInsertCompany { get; private set; }

        #endregion
        #region Abstract Command
        protected override void OnCreateAction(InquiryActionResult<ENG_M0005> result)
        {
            //if (MasterEntity.comp_code != AppSessionState.OBJ_COMPANY.comp_code) // call when document loading of different company. call before Master Entity instance is being created.
            //{
            //    LoadInitialData(AppSessionState.OBJ_COMPANY.comp_code, AppSessionState.OBJ_LOCATION.location_id);
            //}
            MasterEntity = new ENG_M0005();
            DefaultValues();
        }
        protected override void OnDiscardAction(InquiryActionResult<ENG_M0005> result)
        {

        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ENG_M0005> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ENG_M0005> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ENG_M0005> result)
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ENG_M0005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ENG_M0005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ENG_M0005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ENG_M0005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ENG_M0005> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnPrintAction(InquiryActionResult<ENG_M0005> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<ENG_M0005> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<ENG_M0005> result)
        {
            try
            {
                if (Validation() == true)
                {
                    Logging();

                    if (isNewRecord == true)
                    {
                        MasterEntity = REPO.SaveWithReturnDomainObject<ENG_M0005>(MasterEntity, "ENG_M0005_BL", "ENG");
                        isNewRecord = false;
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record Addred Successfully!", this.Title); sms.ShowMessage();
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = REPO.UpdateWithReturnDomainObject<ENG_M0005>(MasterEntity, "ENG_M0005_BL", "ENG");
                        isNewRecord = false;
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record Addred Successfully!", this.Title); sms.ShowMessage();
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }


        #endregion
        #region Constructor
        public ENG_M0005_VM(string ts_code, string doc_cat) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            ENG_M0005.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MC_ENG_BE();
            MC_TEMP = new MC_ENG_BE();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            MasterEntity = new ENG_M0005();
            InitializeCommands();
            
        }
        public ENG_M0005_VM(string ts_code, string doc_cat, string doc_no) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            ENG_M0005.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MC_ENG_BE();
            MC_TEMP = new MC_ENG_BE();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            MasterEntity = new ENG_M0005();
            InitializeCommands();
        }
        #endregion
        #region Standard Functions
        private void LoadInitialData(string company, string location)
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client.ToString() + "!@" + company + "!@" + location + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + AppSessionState.EmpId; // AppSessionState.EmpId + "SINGLE";
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_ENG_BE>(MC, Request, "ENG_M0005_BL", "ENG", " ", 0, "");

                #region Autosuggest

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M0002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0002)o).comp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", true);
                AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).obj_no);
                TheFilter = (o, prefix) => (((STD_ITEM)o).obj_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).obj_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_OBJECT = new AutoSuggestTextViewModel<dynamic>(MC.ITEM_LIST, TheFilter, SuggestedValue, "obj_no", true);
                AS_OBJECT.AutoSuggestVM.IsEmptyValueAllowed = false; AS_OBJECT.AutoSuggestVM.IsFreeTextAllowed = false;

                //List<STD_PERSONNEL> EMP_OBJ_OPR = MC.PERSONNEL_LIST.Where(x => x.emp_type == "OPR").ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((Classification)x).char_code);
                TheFilter = (o, prefix) => (((Classification)o).char_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((Classification)o).char_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_CHAR = new AutoSuggestTextViewModel<dynamic>(MC.CHAR_LIST, TheFilter, SuggestedValue, "char_code", true);
                AS_CHAR.AutoSuggestVM.IsEmptyValueAllowed = false; AS_CHAR.AutoSuggestVM.IsFreeTextAllowed = false;

                #endregion
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void LoadDocumentByDocumentNumber(object InputValue)
        {
            try
            {
                EntityChangeEnable = false;
                SelectedTabControlIndex = 0;
                STD_LIST_BE POPUPEntityObject = null;
                string Request;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC_TEMP.BACK_FLIP_LIST.Where(x => x.doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client.ToString() + "!@" + POPUPEntityObject.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + POPUPEntityObject.doc_no;
                    MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_ENG_BE>(MC_TEMP, Request, "ENG_M0005_BL", "ENG", " ", 0, "");

                    if (MC_TEMP.MEASUREMENT_POINT_LIST.Count > 0)
                    {
                        MasterEntity = MC_TEMP.MEASUREMENT_POINT_LIST[0];
                    }
                }
                MasterEntity.ts_code = ts_code_vm;
                EntityChangeEnable = true;
                isNewRecord = false;
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void GetExecutionData(object InputValue)
        {
        }
        private void InitializeCommands()
        {
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEventCall(items); });
            cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items); });
            cmdLoadBackFlipData = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items); });
            cmdInsertCharacteristic = new RelayCommand<object>(items => { if (items == null) { return; } InsertCharacteristic(items); });
            //cmdInsertCompany = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCompany(cmdPara); });
        }
        private void DefaultValues()
        {
            try
            {
                EntityChangeEnable = true;
                isNewRecord = true;
                MasterEntity.ts_code = this.ts_code_vm;
                MasterEntity.userid = AppSessionState.UserID;
                MasterEntity.session_id = AppSessionState.session_id;
                MasterEntity.client = AppSessionState.client;
                MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                MasterEntity.active = "1";
                MasterEntity.location_id = AppSessionState.OBJ_LOCATION.location_id;

                DateTime d = DateTime.UtcNow;
                d = d.AddMonths(-1);
                REQUEST_PARA.from_date = d;
                REQUEST_PARA.to_date = DateTime.UtcNow;
                REQUEST_PARA.active = true;
                REQUEST_PARA.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void Logging()
        {
            MasterEntity.ts_code = this.ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;
        }
        private bool Validation()
        {
            if (string.IsNullOrWhiteSpace(MasterEntity.pos_no))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Position Is Required"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.short_text))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Description Is Required"); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.obj_no))
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Object no & Name Required"); sms.ShowMessage();
                return false;
            }

            return true;
        }
        private void LoadBackFlipData(object InputValue)
        {
            try
            {
                EntityChangeEnable = false;
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (REQUEST_PARA.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + (Utilities.NullIf(REQUEST_PARA.doc_type ?? doc_cat_vm) ?? "") + "!@" + (Utilities.NullIf(REQUEST_PARA.t_status) ?? "") + "!@" + REQUEST_PARA.active + "!@" + (Utilities.NullIf(REQUEST_PARA.emp_id) ?? AppSessionState.EmpId) + "!@" + Convert.ToDateTime(REQUEST_PARA.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQUEST_PARA.to_date).ToString("MM/dd/yyyy");
                MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_ENG_BE>(MC_TEMP, Request, "ENG_M0005_BL", "ENG", "LoadAll", 0, "");
                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC_TEMP.BACK_FLIP_LIST);
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(Filter_BackFlip);
                EntityChangeEnable = true;
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }

        private void InsertCharacteristic(object InputValue)
        {
            try
            {
                string Request = "";
                Classification POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.CHAR_LIST.Where(x => x.char_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<Classification>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<Classification>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.char_code = POPUPEntityObject.char_code;
                    MasterEntity.char_name = POPUPEntityObject.char_name;
                    MasterEntity.unit_code = POPUPEntityObject.unit_code;
                    MasterEntity.char_no = POPUPEntityObject.no_of_char;
                    MasterEntity.decno = POPUPEntityObject.no_of_dec;
                    MasterEntity.low_limit = Convert.ToDouble(POPUPEntityObject.low_limit);
                    MasterEntity.up_limit = Convert.ToDouble(POPUPEntityObject.up_limit);
                    
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
        //            LoadInitialData(MasterEntity.comp_code, MasterEntity.location_id);
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;
        //        }
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
        //    }
        //}
        private void ExecuteReference(object InputValue)
        {
        }

        #endregion
        #region EntityChangeNotification Section
        void Model_MasterEntityChange(object sender, EventArgs e)
        {
            try
            {
                if (EntityChangeEnable == true)
                {
                    if (sender.ToString() == "prod_dt")
                    {
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion
        #region Command_Function

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
        private void WindowEventCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    //LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                }
                else
                {
                    MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                    MasterEntity.location_id = AppSessionState.OBJ_LOCATION.location_id;
                    LoadInitialData(MasterEntity.comp_code, MasterEntity.location_id);

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ConfirmationTypes)x).conf_type);
                    TheFilter = (o, prefix) => (((ConfirmationTypes)o).conf_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ConfirmationTypes)o).conf_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    DefaultValues();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        #endregion
        #region FilterMethods
        private string _filterString_BackFlip;
        public string FilterString_BackFlip
        {
            get { return _filterString_BackFlip; }
            set
            {
                _filterString_BackFlip = value;
                RaisePropertyChanged("FilterString_BackFlip");
                FilterCollection_BackFlip();
            }
        }
        private void FilterCollection_BackFlip()
        {
            if (_BACKFLIP_COLLECTION != null)
            {
                _BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool Filter_BackFlip(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BackFlip))
                {
                    return (data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                          (data.doc_title != null && data.doc_title.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                          (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                          (data.short_text != null && data.short_text.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                          (data.emp_name != null && data.emp_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                          (data.item_code != null && data.item_code.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                          (data.item_name != null && data.item_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                          (data.doc_date.ToString() != null && data.doc_date.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                          (data.obj_no != null && data.obj_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                          (data.obj_name != null && data.obj_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                          (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                          (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                          (data.char_code != null && data.char_code.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                          (data.char_name != null && data.char_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                          (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()));
                }
                return true;
            }
            return false;

        }


        #endregion
    }
}
