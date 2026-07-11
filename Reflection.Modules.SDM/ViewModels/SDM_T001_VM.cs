using Reflection.Presentation.ViewModel;
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
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using System.Threading.Tasks;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.Presentation.Common;

namespace Reflection.Modules.SDM.ViewModels
{
    public class SDM_T001_VM : WorkspaceViewModel<STD_LIST_BE>
    {
        #region Declaration
        WebServiceRepository<MC_SDM_BE> REPO_MC = new WebServiceRepository<MC_SDM_BE>();
        ObjectSerializationService SER_OBJ = new ObjectSerializationService();
        IShowMessageViewService sms;

        public string ts_code_vm { get; set; }
        public string doc_cat_vm { get; set; }

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
        private STD_LIST_BE _MasterEntity;
        public STD_LIST_BE MasterEntity
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
                    RaisePropertyChanged("MasterEntity");
                }
            }
        }

        private ObservableCollection<STD_LIST_BE> _ItemsEntity;
        public ObservableCollection<STD_LIST_BE> ItemsEntity
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
                    RaisePropertyChanged("ItemsEntity");
                }
            }
        }

        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }

        #endregion

        #region Relay Commands Declaration

        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdLoadDocument { get; private set; }
        public RelayCommand<object> cmdMail { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        public RelayCommand<object> cmdOpenAttachments { get; private set; }


        #endregion

        public SDM_T001_VM(string ts_code,string doc_cat) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            MasterEntity = new STD_LIST_BE();
            MC = new MC_SDM_BE();
            sms = this.GetViewService<IShowMessageViewService>();
            REQUEST_PARA_OBJ = new STD_REQ_PARA_BE();
            CommandInitialization();
            //LoadInitialData(AppSessionState.OBJ_COMPANY.comp_code, AppSessionState.OBJ_LOCATION.location_id);
        }

        private void CommandInitialization()
        {
            CursorControl.SetBusyState();
            try
            {
                #region Command Initialisation
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                //cmdLoadDocument = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Load(cmdPara, "FlipGridReference"); }); // confirm assignment
                cmdLoadBackFlip = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadBackFlipData(cmdPara); });
                //cmdMail = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } MailDocuments(cmdPara); });
                
                //cmdOpenAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenDocumentViewer(cmdPara); });
                #endregion
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        private void LoadInitialData(string company, string plant)
        {
            CursorControl.SetBusyState();
            try
            {
                CursorControl.SetBusyState();
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + REQUEST_PARA_OBJ.location_id + "!@" + (REQUEST_PARA_OBJ.doc_cat ?? doc_cat_vm) + "!@" + (REQUEST_PARA_OBJ.doc_type ?? doc_cat_vm) + "!@!@" + AppSessionState.UserID + "!@" + (Utilities.NullIf(REQUEST_PARA_OBJ.emp_id) ?? AppSessionState.EmpId) + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + (REQUEST_PARA_OBJ.party_code ?? "") + "!@!@" + REQUEST_PARA_OBJ.active + "!@" + REQUEST_PARA_OBJ.t_status + "!@" + Convert.ToDateTime(REQUEST_PARA_OBJ.from_date ?? Convert.ToDateTime("01/01/1900")).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQUEST_PARA_OBJ.to_date ?? Convert.ToDateTime("01/01/2099")).ToString("MM/dd/yyyy");
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_SDM_BE>(MC, Request, "SEL_T001_BL", "SDM", "LoadAll", 0, "");

                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC.BACK_FLIP_LIST.ToList());
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(FLTR_BACKFLIP);

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void LoadBackFlipData(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + REQUEST_PARA_OBJ.location_id + "!@" + (REQUEST_PARA_OBJ.doc_cat ?? doc_cat_vm) + "!@" + (REQUEST_PARA_OBJ.doc_type ?? doc_cat_vm) + "!@!@" + AppSessionState.UserID + "!@" + (Utilities.NullIf(REQUEST_PARA_OBJ.emp_id) ?? AppSessionState.EmpId) + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + (REQUEST_PARA_OBJ.party_code ?? "") + "!@!@" + REQUEST_PARA_OBJ.active + "!@" + REQUEST_PARA_OBJ.t_status + "!@" + Convert.ToDateTime(REQUEST_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQUEST_PARA_OBJ.to_date).ToString("MM/dd/yyyy");
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_SDM_BE>(MC, Request, "SEL_T001_BL", "SDM", "LoadAll", 0, "");

                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC.BACK_FLIP_LIST.ToList());
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(FLTR_BACKFLIP);
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }

        #region Relay Command Actions ·
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
            catch (Exception ex) { }
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                LoadInitialData(AppSessionState.OBJ_COMPANY.comp_code, AppSessionState.OBJ_LOCATION.location_id);
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }

        #endregion

        #region Filters

        private string _FLTR_STR_BACKFLIP;
        public string FLTR_STR_BACKFLIP
        {
            get { return _FLTR_STR_BACKFLIP; }
            set
            {
                _FLTR_STR_BACKFLIP = value;
                RaisePropertyChanged("FLTR_STR_BACKFLIP");
                FLTR_COL_BACKFLIP();
            }
        }
        private void FLTR_COL_BACKFLIP()
        {
            if (BACKFLIP_COLLECTION != null)
            {
                BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool FLTR_BACKFLIP(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FLTR_STR_BACKFLIP))
                {
                    return (data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower()) ||
                            data.party_code != null && data.party_code.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower()) ||
                            data.party_name != null && data.party_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower()) ||
                            data.ref_doc_date != null && data.ref_doc_date.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())
                       );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Abstract Command Actions
        private IEnumerable<T> MakeMeEnumerable<T>(T Entity)
        {
            yield return Entity;
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
            //if (!string.IsNullOrEmpty(MasterEntity.doc_no))
            //{            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
            //    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.sono.Replace("/", "--"), DocumentList = MCTemp.ATTACHMENT_LIST, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            //}
        }
        protected override void OnRefreshCommand(InquiryActionResult<STD_LIST_BE> result)
        {
            LoadInitialData(MasterEntity.comp_code, MasterEntity.location_id);
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
