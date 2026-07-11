using Reflection.Presentation.ViewModel;
using GalaSoft.MvvmLight.Command;
using System;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls;
using System.Collections.Generic;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity.QMS;
using System.Collections.Specialized;
using System.Windows.Data;
using System.ComponentModel;
using System.Collections;
using System.Linq;
using Reflection.Presentation.Services.Convertors;



namespace Reflection.Modules.QMS.ViewModels
{
    public class QMS_M0003_VM : WorkspaceViewModel<QMS_M0003>
    {

        #region Private Local Variable Declaration
        private bool isNewRecord = true;
        private bool _EntityChangeEnable;
        public bool EntityChangeEnable 
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

        private string ts_code_vm { get; set; }//transaction screen code
        private string doc_no_vm { get; set; }
        private string doc_cat_vm { get; set; }

        WebServiceRepository<QMS_M0003> REPO = new WebServiceRepository<QMS_M0003>();//(transaction save,update karnyasathi)web service call karnyasathi
        WebServiceRepository<MC_QMS_BE> REPO_MC = new WebServiceRepository<MC_QMS_BE>();//pop up load hotana gheun yeto(numbers of list)
        ObjectSerializationService obj = new ObjectSerializationService();//(later explain) object serialised karnyacha class


        private MC_QMS_BE _MC = new MC_QMS_BE();
        public MC_QMS_BE MC 
        {
            get { return _MC; }
            set { if (_MC != value) { _MC = value; RaisePropertyChanged("MC"); } }
        }
        private MC_QMS_BE _MC_TEMP = new MC_QMS_BE();//survatiche pop up ,nanter jo data lagto to vahun aananyache kam kartoy
        public MC_QMS_BE MC_TEMP
        {
            get { return _MC_TEMP; }
            set { if (_MC_TEMP != value) { _MC_TEMP = value; RaisePropertyChanged("MC_TEMP"); } }
        }
        private QMS_M0003 _MasterEntity;//currently selected record(single entry)
        public QMS_M0003 MasterEntity
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
        #region ICollectionView
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
        #region Relay Command
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }//
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdLoadBackFlipData { get; private set; }
        public RelayCommand<object> cmdInsertCharacteristic { get; private set; }
        //public RelayCommand<object> cmdInsertCompany { get; private set; }

        #endregion
        #region Abstract Command
        protected override void OnCreateAction(InquiryActionResult<QMS_M0003> result)
        {
            //if (MasterEntity.comp_code != AppSessionState.OBJ_COMPANY.comp_code) // call when document loading of different company. call before Master Entity instance is being created.
            //{
            //    LoadInitialData(AppSessionState.OBJ_COMPANY.comp_code, AppSessionState.OBJ_LOCATION.location_id);
            //}
            MasterEntity = new QMS_M0003();
            DefaultValues();
        }
        protected override void OnDiscardAction(InquiryActionResult<QMS_M0003> result)
        {

        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<QMS_M0003> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<QMS_M0003> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<QMS_M0003> result)
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<QMS_M0003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_M0003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_M0003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_M0003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_M0003> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnPrintAction(InquiryActionResult<QMS_M0003> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<QMS_M0003> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<QMS_M0003> result)
        {
            try
            {
                if (Validation() == true)
                {
                    Logging();

                    if (isNewRecord == true)
                    {
                        MasterEntity = REPO.SaveWithReturnDomainObject<QMS_M0003>(MasterEntity, "QMS_M0003_BL", "QMS");
                        isNewRecord = false;
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record Addred Successfully!", this.Title); sms.ShowMessage();
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = REPO.UpdateWithReturnDomainObject<QMS_M0003>(MasterEntity, "QMS_M0003_BL", "QMS");
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
        public QMS_M0003_VM(string ts_code, string doc_cat) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            QMS_M0003.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MC_QMS_BE();
            MC_TEMP = new MC_QMS_BE();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            MasterEntity = new QMS_M0003();
            InitializeCommands();

        }
        public QMS_M0003_VM(string ts_code, string doc_cat, string doc_no) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            QMS_M0003.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MC_QMS_BE();
            MC_TEMP = new MC_QMS_BE();
            REQUEST_PARA = new STD_REQ_PARA_BE();
            MasterEntity = new QMS_M0003();
            InitializeCommands();
        }
        #endregion
        #region Standard Functions
        private void LoadInitialData(string company, string location)
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client.ToString() + "!@" + company + "!@" + location + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + AppSessionState.EmpId; // AppSessionState.EmpId + "SINGLE";
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_QMS_BE>(MC, Request, "QMS_M0003_BL", "QMS", " ", 0, "");
                //ItemsCollection = MC.MASTER_LIST;
                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC.BACK_FLIP_LIST);
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(Filter_BackFlip);
                //ItemsCollection ANI BACKFLIP_COLLECTION he ekach aahe ka
                LOCATION_LIST = MC.LOCATION_LIST;
               



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
                    MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_QMS_BE>(MC_TEMP, Request, "QMS_M0003_BL", "QMS", " ", 0, "");

                    if (MC_TEMP.FUNCTION_LOCATION_LIST.Count > 0)
                    {
                        MasterEntity = MC_TEMP.FUNCTION_LOCATION_LIST[0];
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
            //cmdInsertCharacteristic = new RelayCommand<object>(items => { if (items == null) { return; } InsertCharacteristic(items); });
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
        //    if (string.IsNullOrWhiteSpace(MasterEntity.fl_name))
        //    {
        //        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
        //        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("fl_name Is Required"); sms.ShowMessage();
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(MasterEntity.short_text))
        //    {
        //        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
        //        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Description Is Required"); sms.ShowMessage();
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(MasterEntity.reg_no))
        //    {
        //        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
        //        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("reg_no  & Name Required"); sms.ShowMessage();
        //        return false;
        //    }

            return true;
        }
        private void LoadBackFlipData(object InputValue)
        {
            try
            {
                EntityChangeEnable = false;
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (REQUEST_PARA.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + (Utilities.NullIf(REQUEST_PARA.doc_type ?? doc_cat_vm) ?? "") + "!@" + (Utilities.NullIf(REQUEST_PARA.t_status) ?? "") + "!@" + REQUEST_PARA.active + "!@" + (Utilities.NullIf(REQUEST_PARA.emp_id) ?? AppSessionState.EmpId) + "!@" + Convert.ToDateTime(REQUEST_PARA.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQUEST_PARA.to_date).ToString("MM/dd/yyyy");
                MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_ENG_BE>(MC_TEMP, Request, "QMS_M0003_BL", "QMS", "LoadAll", 0, "");
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

                    //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ConfirmationTypes)x).conf_type);
                    //TheFilter = (o, prefix) => (((ConfirmationTypes)o).conf_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ConfirmationTypes)o).conf_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
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
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                        
                          (data.cat_name != null && data.cat_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()));
                }
                return true;
            }
            return false;

        }


        #endregion




    }
}


