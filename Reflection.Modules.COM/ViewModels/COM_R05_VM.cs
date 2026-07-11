using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.Common;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Reflection.Modules.COM.ViewModels
{
    public class COM_R05_VM : WorkspaceViewModel<STD_LIST_BE>
    {
        #region Variables Declaration
        IShowMessageViewService sms;
        public string ts_code_vm { get; set; }
        WebServiceRepository<STD_MC_BE> REPO_MC = new WebServiceRepository<STD_MC_BE>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private STD_MC_BE _MC = new STD_MC_BE();
        public STD_MC_BE MC
        {
            get { return _MC; }
            set { if (_MC != value) { _MC = value; RaisePropertyChanged("MC"); } }
        }
        private STD_MC_BE _MC_TEMP = new STD_MC_BE();
        public STD_MC_BE MC_TEMP
        {
            get { return _MC_TEMP; }
            set { if (_MC_TEMP != value) { _MC_TEMP = value; RaisePropertyChanged("MC_TEMP"); } }
        }
        private STD_LIST_BE _MasterEntity = new STD_LIST_BE();
        public STD_LIST_BE MasterEntity
        {
            get { return _MasterEntity; }
            set { if (_MasterEntity != value) { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); } }
        }
        private NotificationData _NOTF_OBJ = new NotificationData();
        public NotificationData NOTF_OBJ
        {
            get { return _NOTF_OBJ; }
            set { if (_NOTF_OBJ != value) { _NOTF_OBJ = value; RaisePropertyChanged("NOTF_OBJ"); } }
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

        private ICollectionView _DG_COLLECTION;
        public ICollectionView DG_COLLECTION
        {
            get { return _DG_COLLECTION; }
            set
            {
                _DG_COLLECTION = value;
                RaisePropertyChanged("DG_COLLECTION");
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
        #endregion


        #region RelayCommands  
        public RelayCommand<object> cmdExecuteNotification { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdLoadGridData { get; private set; }
        #endregion

        public COM_R05_VM() : base()
        {
            sms = this.GetViewService<IShowMessageViewService>();
            MC = new STD_MC_BE();
            MC_TEMP = new STD_MC_BE();
            MasterEntity = new STD_LIST_BE();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            REQ_PARA_OBJ.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            sms = this.GetViewService<IShowMessageViewService>();
            cmdExecuteNotification = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteNotification(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdLoadGridData = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadGridData(cmdPara); });
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                DateTime d = DateTime.UtcNow;
                d = d.AddMonths(-1);
                REQ_PARA_OBJ.from_date = d;
                REQ_PARA_OBJ.to_date = DateTime.UtcNow;
                REQ_PARA_OBJ.active = true;
                REQ_PARA_OBJ.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                REQ_PARA_OBJ.location_id = AppSessionState.OBJ_LOCATION.location_id;

                LoadInitialData();
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void LoadInitialData()
        {
            try
            {
                //string Request = "LOAD_INI" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id;
                //MC = REPO_MC.GetDataWithReturnDomainObject<STD_MC_BE>(MC, Request, "COM_R05_BL", "COM", " ", 0, "");

                //DG_COLLECTION = CollectionViewSource.GetDefaultView(MC.STANDARD_LIST);
                //DG_COLLECTION.Filter = new Predicate<object>(FLT_DG_COLLECTION);
                //DG_COLLECTION.Refresh();

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void LoadGridData(object Parameter)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (REQ_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + (REQ_PARA_OBJ.doc_cat ?? "") + "!@" + (REQ_PARA_OBJ.doc_type ?? "") + "!@" + (REQ_PARA_OBJ.active_code ?? "") + "!@" + (REQ_PARA_OBJ.t_status ?? "") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy");
                MC = REPO_MC.GetDataWithReturnDomainObject<STD_MC_BE>(MC, Request, "COM_R05_BL", "COM", "", 0, "");

                DG_COLLECTION = CollectionViewSource.GetDefaultView(MC.STANDARD_LIST);
                DG_COLLECTION.Filter = new Predicate<object>(FLT_DG_COLLECTION);
                DG_COLLECTION.Refresh();

            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void ExecuteNotification(object tem)
        {
            try
            {
                if (MC.STANDARD_LIST != null)
                {
                    if (MC.STANDARD_LIST.Count > 0)
                    {
                        foreach (var doc in MC.STANDARD_LIST) // iterate thriugh selected party to send RFQ
                        {
                            if (doc.selected == true)
                            {
                                MasterEntity = doc;
                                NOTF_OBJ = MC.NOTIFICATION_LIST.Where(x => x.doc_cat == doc.doc_cat && x.doc_type == doc.doc_type).FirstOrDefault();
                                if(NOTF_OBJ != null)
                                {
                                    if (!string.IsNullOrWhiteSpace(NOTF_OBJ.alert_id))
                                    {
                                        NotifyMessage(NOTF_OBJ);
                                    }
                                }
                            }
                        }
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Notification sent successfully!", this.Title); sms.ShowMessage();
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void NotifyMessage(NotificationData OBJ_NOTIFY)
        {
            try
            {
                List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>()
                {
                    new KeyValuePair<string, string>("[SUB]",OBJ_NOTIFY.subject),
                    new KeyValuePair<string, string>("[EMP]",MasterEntity.emp_name),
                    new KeyValuePair<string, string>("[DOC]", MasterEntity.doc_type_name),
                    new KeyValuePair<string, string>("[OPR]", OBJ_NOTIFY.description),
                    new KeyValuePair<string, string>("[DOCNO]", MasterEntity.doc_no),
                    new KeyValuePair<string, string>("[Comp]","M/s: " +AppSessionState.CompanyName),
                    new KeyValuePair<string, string>("[TSTS]", MasterEntity.t_display),
                    new KeyValuePair<string, string>("[Attn]",OBJ_NOTIFY.EmpName),
                    new KeyValuePair<string, string>("[CUST]","M/s: " +  MasterEntity.party_name),
                    new KeyValuePair<string, string>("[CUR]",MasterEntity.curr_code.ToString()),
                    new KeyValuePair<string, string>("[OVAL]",MasterEntity.document_value.ToString()),
                    new KeyValuePair<string, string>("[DOCDATE]", MasterEntity.doc_date.Value.ToShortDateString()),
                    new KeyValuePair<string, string>("[VALDATE]", MasterEntity.to_date.ToString()),
                };
                foreach (KeyValuePair<string, string> kvp in kvpList)
                {
                    OBJ_NOTIFY.subject = OBJ_NOTIFY.subject.Replace(kvp.Key, kvp.Value);
                    OBJ_NOTIFY.msg_body = OBJ_NOTIFY.msg_body.Replace(kvp.Key, kvp.Value);
                }
                if ((!string.IsNullOrWhiteSpace(MasterEntity.email_id) || !string.IsNullOrWhiteSpace(MasterEntity.cp_email))) // if it is inquiry/RFQ to upplier and Auto RQQ then add suppliers email id to TO section
                {
                    OBJ_NOTIFY.to_mail_id = (MasterEntity.email_id ?? "") + (MasterEntity.email_id == MasterEntity.cp_email ? "" : (";" + MasterEntity.cp_email));
                    OBJ_NOTIFY.cc_mail_id = (OBJ_NOTIFY.cc_mail_id ?? "") + ";" + (AppSessionState.EmpEmailId ?? "") + (MasterEntity.emp_email == AppSessionState.EmpEmailId ? "" : (";" + MasterEntity.emp_email));
                    Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, OBJ_NOTIFY.to_mail_id, OBJ_NOTIFY.cc_mail_id, OBJ_NOTIFY.bcc_mail_id, OBJ_NOTIFY.subject, OBJ_NOTIFY.msg_body, null);
                }
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        
        #region Abstract Classes Implementation
        protected override void OnDocumentAction(){}
        protected override void OnSaveAction(InquiryActionResult<STD_LIST_BE> result){}
        protected override void OnCreateAction(InquiryActionResult<STD_LIST_BE> result){}
        protected override void OnRemoveAction(InquiryActionResult<STD_LIST_BE> result){}
        protected override void OnDiscardAction(InquiryActionResult<STD_LIST_BE> result){}
        protected override void OnPrintAction(InquiryActionResult<STD_LIST_BE> result){}
        protected override void OnFlipAction(InquiryActionResult<STD_LIST_BE> result){}
        protected override void OnHelpAction(InquiryActionResult<STD_LIST_BE> result){}
        protected override void OnFevoriteAction(InquiryActionResult<STD_LIST_BE> result){}
        protected override void OnRefreshCommand(InquiryActionResult<STD_LIST_BE> result){}
        protected override void OnLedgerViewCommand(InquiryActionResult<STD_LIST_BE> result){}
        protected override void OnValidateCommand(InquiryActionResult<STD_LIST_BE> result){}
        protected override void OnTraceCommand(InquiryActionResult<STD_LIST_BE> result){}
        protected override void OnMailCommand(InquiryActionResult<STD_LIST_BE> result){}
        #endregion

        #region Filter

        private string _FSTR_BACKFLIP;
        public string FSTR_BACKFLIP
        {
            get { return _FSTR_BACKFLIP; }
            set
            {
                _FSTR_BACKFLIP = value;
                RaisePropertyChanged("FSTR_BACKFLIP");
                FLT_DG_COLLECTION_FUN();
            }
        }
        private void FLT_DG_COLLECTION_FUN()
        {
            if (_DG_COLLECTION != null)
            {
                _DG_COLLECTION.Refresh();
            }
        }
        public bool FLT_DG_COLLECTION(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FSTR_BACKFLIP))
                {
                    return (data.item_code != null && (data.item_code ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.comp_code != null && (data.comp_code ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.doc_no != null && (data.doc_no ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.doc_date != null && (data.doc_date.Value.ToShortDateString() ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.doc_type_name != null && (data.doc_type_name ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.party_code != null && (data.party_code ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.party_name != null && (data.party_name ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.t_display != null && (data.t_display ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.t_status != null && (data.t_status ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.location_id != null && (data.location_id ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.store_code != null && (data.store_code ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.short_text != null && (data.short_text ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.emp_id != null && (data.emp_id ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.emp_name != null && (data.emp_name ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.cp_code != null && (data.cp_code ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.cp_name != null && (data.cp_name ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.cp_no != null && (data.cp_no ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.cp_email != null && (data.cp_email ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.cn_code != null && (data.cn_code ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.cn_name != null && (data.cn_name ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.cn_text != null && (data.cn_text ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower())) ||
                        (data.comp_code != null && (data.comp_code ?? "").ToString().ToLower().Contains(FSTR_BACKFLIP.ToLower()));


                }
                return true;
            }
            return false;
        }
        #endregion
    }
}
