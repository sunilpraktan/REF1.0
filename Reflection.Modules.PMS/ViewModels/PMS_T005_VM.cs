using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.PMS;
using Reflection.BusinessEntity.ADM;
using System.Data;

namespace Reflection.Modules.PMS.ViewModels
{
    public class PMS_T005_VM : WorkspaceViewModel<PMS_T004>, ITS_VIEW_MODEL
    {
        #region AutoSuggest Initialization

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

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

      


        #endregion

        #region Variable Declaration

        WebServiceRepository<PMS_T004> REPO = new WebServiceRepository<PMS_T004>();
        WebServiceRepository<MC_PMS_BE> REPO_MC = new WebServiceRepository<MC_PMS_BE>();
        ObjectSerializationService SER_OBJ = new ObjectSerializationService();

        private bool _isNewRecord { get; set; }
        public bool isNewRecord
        {
            get { return _isNewRecord; }
            set
            {
                if (_isNewRecord != value)
                {
                    _isNewRecord = value; RaisePropertyChanged("isNewRecord");
                }
            }
        }
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }
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
        IShowMessageViewService sms;

        private MC_PMS_BE _MC = new MC_PMS_BE();
        public MC_PMS_BE MC
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

        private MC_PMS_BE _MC_TEMP = new MC_PMS_BE();
        public MC_PMS_BE MC_TEMP
        {
            get { return _MC_TEMP; }
            set
            {
                if (_MC_TEMP != value)
                {
                    _MC_TEMP = value; RaisePropertyChanged("MC_TEMP");

                }
            }

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
                }
            }
        }

        private int _MainTabIndex;
        public int MainTabIndex
        {
            get { return _MainTabIndex; }
            set
            {
                if (_MainTabIndex != value)
                {
                    _MainTabIndex = value;
                    RaisePropertyChanged("MainTabIndex");
                }
            }
        }

        private PMS_T004 _MasterEntity;
        public PMS_T004 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                }
            }
        }

        private STD_LIST_BE _CTR_PARA_OBJ;
        public STD_LIST_BE CTR_PARA_OBJ
        {
            get
            {
                return _CTR_PARA_OBJ;
            }
            set
            {
                if (_CTR_PARA_OBJ != value)
                {
                    _CTR_PARA_OBJ = value;
                    RaisePropertyChanged(nameof(CTR_PARA_OBJ));
                }
            }
        }

        #endregion
        public string Name
        {
            get
            {
                return "Home Page";
            }
        }
        private STD_LIST_BE _doc_info_para = new STD_LIST_BE();
        public STD_LIST_BE doc_info_para
        {
            get { return _doc_info_para; }
            set
            {
                if (_doc_info_para != value)
                {
                    _doc_info_para = value; RaisePropertyChanged("doc_info_para");

                }
            }

        }

        #region Model Entity Update
        void ModelUpdated_Master(object sender, EventArgs e)
        {
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
        }

        #endregion
        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<STD_LIST_BE> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInsertStatus { get; private set; }
        public RelayCommand<STD_LIST_BE> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdOpenAttachments { get; private set; }
        public RelayCommand<object> cmdCreate { get; private set; }
        public RelayCommand<object> cmdSave { get; private set; }
        public RelayCommand<object> cmdDocumentAttachment { get; private set; }

        #endregion

        #region DefalutValue
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_cat = doc_cat_vm;
            MasterEntity.doc_type = doc_cat_vm;

            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.active = "1";
            MasterEntity.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
            MasterEntity.t_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_display).FirstOrDefault();
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;

            MasterEntity.client = AppSessionState.client;
            MasterEntity.comp_code = CTR_PARA_OBJ.comp_code;
            MasterEntity.project_id = CTR_PARA_OBJ.project_id;
            MasterEntity.project_name = CTR_PARA_OBJ.project_name;
            MasterEntity.element_name = CTR_PARA_OBJ.element_name;
            MasterEntity.element_no = CTR_PARA_OBJ.element_no;
            MasterEntity.element_id = CTR_PARA_OBJ.element_id;

            MainTabIndex = 1;
        }
        #endregion

        #region Constructor
        public PMS_T005_VM(string ts_code, string doc_cat) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            MasterEntity = new PMS_T004();
            CTR_PARA_OBJ = new STD_LIST_BE();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            MC = new MC_PMS_BE();
            MC_TEMP = new MC_PMS_BE();
            PMS_T004.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            sms = this.GetViewService<IShowMessageViewService>();
            CommandInitialization();
            LoadInitialData();
            DefaultValues();
        }
        public PMS_T005_VM(string ts_code, string doc_cat, STD_LIST_BE para_obj) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            MasterEntity = new PMS_T004();
            CTR_PARA_OBJ = new STD_LIST_BE();
            CTR_PARA_OBJ = para_obj;
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            MC = new MC_PMS_BE();
            MC_TEMP = new MC_PMS_BE();
            PMS_T004.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            sms = this.GetViewService<IShowMessageViewService>();
            CommandInitialization();
            LoadInitialData();
            DefaultValues();
        }
        #endregion

        #region Method Implementation
        private void CommandInitialization()
        {
            CursorControl.SetBusyState();
            try
            {
                #region Command Initialisation
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<STD_LIST_BE>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInsertStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertStatus(items); });
                cmdLoadDocumentByDocumentNumber = new RelayCommand<STD_LIST_BE>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara); }); // confirm assignment
                cmdCreate = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Create(cmdPara); });
                cmdSave = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Save(cmdPara); });
                //cmdOpenAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenDocumentViewer(cmdPara); });
                cmdDocumentAttachment = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DocumentAttachment(cmdPara); });

                #endregion
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                isNewRecord = true;
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + (REQ_PARA_OBJ.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (REQ_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + (MasterEntity.project_id ?? "") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + REQ_PARA_OBJ.org_code + "!@" + (REQ_PARA_OBJ.group_code ?? "");
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_SDM_BE>(MC, Request, "PMS_T004_BL", "PMS", "LoadAll", 0, "");

                #region Autosuggest

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_STATUS = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_status", true);
                AS_STATUS.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void Create(object InputValue)
        {
            try
            {
                isNewRecord = true;
                MasterEntity = new PMS_T004();
                MasterEntity.ValidateAsync().Wait();
                DefaultValues();

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void DocumentAttachment(object InputValue)
        {
            try
            {
                if (!string.IsNullOrEmpty(MasterEntity.doc_no))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MC_TEMP.ATTACHMENT_LIST, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void Save(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                if (Validation() == true)
                {
                    if (string.IsNullOrWhiteSpace(MasterEntity.doc_no))
                    {
                        isNewRecord = true;
                    }
                    else
                    {
                        isNewRecord = false;
                    }
                    MasterEntity.ts_code = ts_code_vm;
                    MasterEntity.userid = AppSessionState.UserID;

                    if (isNewRecord == true)
                    {
                        MasterEntity = REPO.SaveWithReturnDomainObject<PMS_T004>(MasterEntity, "PMS_T004_BL", "PMS");
                        List<STD_LIST_BE> SLBE = new List<STD_LIST_BE>();
                        STD_LIST_BE SLBE_TEMP = new STD_LIST_BE();

                        SLBE_TEMP.client = MasterEntity.client;
                        SLBE_TEMP.ts_code = MasterEntity.ts_code;
                        SLBE_TEMP.comp_code = MasterEntity.comp_code;
                        SLBE_TEMP.project_id = MasterEntity.project_id;
                        SLBE_TEMP.project_name = MasterEntity.project_name;
                        SLBE_TEMP.element_id = MasterEntity.element_id;
                        SLBE_TEMP.element_no = MasterEntity.element_no;
                        //SLBE.value_code = "REFRESH_PS";
                        SLBE.Add(SLBE_TEMP);
                        Messenger.Default.Send<NotificationMessage>(new NotificationMessage(SLBE, "REFRESH_PS"));
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = REPO.UpdateWithReturnDomainObject<PMS_T004>(MasterEntity, "PMS_T004_BL", "PMS");
                    }


                    isNewRecord = false;
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = "Record save successfully!"; sms.ShowMessage();

                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void LoadDocumentByDocumentNumber(STD_LIST_BE ParameterObject)
        {
            try
            {
                CursorControl.SetBusyState();

                string Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + ParameterObject.comp_code + "!@" + ParameterObject.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + ParameterObject.doc_no + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm;
                MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_PMS_BE>(MC_TEMP, Request, "PMS_T004_BL", "PMS", "LoadAll", 0, "");
                if (MC_TEMP.MILESTONE_LIST != null)
                {
                    if (MC_TEMP.MILESTONE_LIST.Count > 0)
                    {
                        MasterEntity = MC_TEMP.MILESTONE_LIST[0];
                        Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertStatus(object InputValue)
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
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void WindowEvetCall(STD_LIST_BE InputValue)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(InputValue.doc_no) && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(InputValue);
                }
                else
                {
                    DefaultValues();
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
        private bool Validation()
        {
            try
            {
                if (MasterEntity.comp_code == null)
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please input Company........"); sms.ShowMessage();
                    return false;
                }

                if (MasterEntity.short_text == null)
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please input Description........"); sms.ShowMessage();
                    return false;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please input Company........");
            }
            return true;
        }
        #endregion

        #region Abstract Method
        protected override void OnCreateAction(InquiryActionResult<PMS_T004> result)
        {
            isNewRecord = true;
            MasterEntity = new PMS_T004();
            MasterEntity.ValidateAsync().Wait();
            DefaultValues();
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
        }
        protected override void OnDiscardAction(InquiryActionResult<PMS_T004> result)
        {}
        protected override void OnFevoriteAction(InquiryActionResult<PMS_T004> result)
        {}
        protected override void OnFlipAction(InquiryActionResult<PMS_T004> result)
        {}
        protected override void OnHelpAction(InquiryActionResult<PMS_T004> result)
        {}
        protected override void OnPrintAction(InquiryActionResult<PMS_T004> result)
        {}
        protected override void OnRemoveAction(InquiryActionResult<PMS_T004> result)
        {}
        protected override void OnSaveAction(InquiryActionResult<PMS_T004> result)
        {}
        protected override void OnDocumentAction()
        {}
        protected override void OnRefreshCommand(InquiryActionResult<PMS_T004> result)
        {}
        protected override void OnLedgerViewCommand(InquiryActionResult<PMS_T004> result)
        {}
        protected override void OnValidateCommand(InquiryActionResult<PMS_T004> result)
        {}
        protected override void OnTraceCommand(InquiryActionResult<PMS_T004> result)
        {}
        protected override void OnMailCommand(InquiryActionResult<PMS_T004> result)
        {}

        #endregion
    }
}
