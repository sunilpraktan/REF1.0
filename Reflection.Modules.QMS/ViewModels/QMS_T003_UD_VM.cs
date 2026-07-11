using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity.QMS;
using System.Reflection;
using Reflection.Presentation.Core.VirtualDesktops;
using GalaSoft.MvvmLight.Ioc;
using System.IO;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.QMS.ViewModels
{
    public class QMS_T003_UD_VM : WorkspaceViewModel<QMS_T003_A>
    {
        #region Variables Declaration
        WebServiceRepository<MC_QMS_T003> REPOSITORY = new WebServiceRepository<MC_QMS_T003>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MC_QMS_T003 _MC = new MC_QMS_T003();
        public MC_QMS_T003 MC
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

        private MC_QMS_T003 _MC_TEMP = new MC_QMS_T003();
        public MC_QMS_T003 MC_TEMP
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

        private QMS_T003_U _UD_OBJ;
        public QMS_T003_U UD_OBJ
        {
            get
            {
                return _UD_OBJ;
            }
            set
            {
                if (_UD_OBJ != value)
                {
                    _UD_OBJ = value;
                    RaisePropertyChanged(nameof(UD_OBJ));
                }
            }
        }

        private STD_LIST_BE _STD_OBJ;
        public STD_LIST_BE STD_OBJ
        {
            get
            {
                return _STD_OBJ;
            }
            set
            {
                if (_STD_OBJ != value)
                {
                    _STD_OBJ = value;
                    RaisePropertyChanged(nameof(STD_OBJ));
                }
            }
        }

        private QMS_T003 _MasterEntity;
        public QMS_T003 MasterEntity
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
                }
            }
        }

        private ObservableCollection<QMS_T003_N> _DefectEntity;
        public ObservableCollection<QMS_T003_N> DefectEntity
        {
            get
            {
                return _DefectEntity;
            }
            set
            {
                if (_DefectEntity != value)
                {
                    RaisePropertyChanged("DefectEntity");
                }
            }
        }

        private IEnumerable _UD_LIST;
        public IEnumerable UD_LIST
        {
            get { return _UD_LIST; }
            set
            {
                if (_UD_LIST != value)
                {
                    _UD_LIST = value; RaisePropertyChanged("UD_LIST");
                }
            }
        }

        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdSelectionChanged { get; private set; }
        public RelayCommand<object> cmdInsertUD { get; private set; }
        public RelayCommand<object> cmdInspection_Processing_DR { get; private set; }
        #endregion

        #region Constructor
        public QMS_T003_UD_VM(STD_LIST_BE LIST_PARA, QMS_T003 LOT_INFO) : base()
        {
            STD_OBJ = new STD_LIST_BE();
            STD_OBJ = LIST_PARA;
            MasterEntity = new QMS_T003();
            MasterEntity = LOT_INFO;
            MasterEntity.ip_text = LOT_INFO.ip_text;
            UD_OBJ = new QMS_T003_U();
            DefectEntity = new ObservableCollection<QMS_T003_N>();
            MC = new MC_QMS_T003();
            MC_TEMP = new MC_QMS_T003();
            QMS_T003_U.ModelEntityUpdated += new EventHandler(ModelUpdated_QMS_T003_U);
            CommandInitialization();
        }
        #endregion
        #region Default Functions
        private void CommandInitialization()
        {
            CursorControl.SetBusyState();
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdInspection_Processing_DR = new RelayCommand<object>(items => { if (items == null) { return; } Inspection_Processing_DR_Call(items); });
            cmdInsertUD = new RelayCommand<object>(items => { if (items == null) { return; } InsertUsageDecision(items); });
        }
        private void Logging()
        {
            MasterEntity.ts_code = STD_OBJ.ts_code;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.active = "1";
        }
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                // Comment all for NG2.0
                //string Request = "LOAD_INI_UD" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.tl_code + "!@" + MasterEntity.doc_no;
                //MC = REPOSITORY.GetDataWithReturnDomainObject<MC_QMS_T003>(MC, Request, "QMS_T003_BL", "QMS", "LOAD_INI_UD", 0, "");

                //UD_LIST = MC.CLASS_PROFILE_LIST;

                //if (MC.USAGE_DECISION.Count > 0)
                //{
                //    UD_OBJ = MC.USAGE_DECISION[0];
                //}
                //else
                //{
                //    UD_OBJ.client = AppSessionState.client;
                //    UD_OBJ.comp_code = MasterEntity.comp_code;
                //    UD_OBJ.location_id = MasterEntity.location_id;
                //    UD_OBJ.active = MasterEntity.active;
                //    UD_OBJ.doc_no = MasterEntity.doc_no;
                //    UD_OBJ.emp_id = AppSessionState.EmpId;
                //    UD_OBJ.qty_sample = MasterEntity.sample_size;
                //    UD_OBJ.qty_ustock = MasterEntity.insp_lot_qty;
                //    UD_OBJ.qty_inspected = MasterEntity.qty_inspected;
                //    UD_OBJ.t_status = MasterEntity.t_status;
                //    UD_OBJ.ts_code = STD_OBJ.ts_code;
                //    UD_OBJ.userid = AppSessionState.UserID;
                //    UD_OBJ.active = "1";
                //    MasterEntity.posting_date = DateTime.Now;
                //    MasterEntity.insp_end_date = DateTime.Now;

                //}


                //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(STD_OBJ.ts_code));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
                    Request = AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                LoadInitialData();
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(STD_OBJ.ts_code));
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
        private void OpenDocumentViewer(object InputValue)
        {
            WebServiceRepository<MultipleContext_Attachments> repository_MCAttachments = new WebServiceRepository<MultipleContext_Attachments>();
            List<COM_T003> Attachments = new List<COM_T003>();
            QMS_T003_A EntityObjectParameter = new QMS_T003_A();
            MultipleContext_Attachments MCAttachments = new MultipleContext_Attachments();
            try
            {
                string Request = "GetAllFiles" + "!@" + STD_OBJ.doc_no;
                //MCAttachments = repository_MCAttachments.GetData<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Reflection.BusinessLogic.ReflectionFileHandlingServices");
                MCAttachments = repository_MCAttachments.GetDataWithReturnDomainObject<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                if (!string.IsNullOrEmpty(STD_OBJ.doc_no))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = STD_OBJ.doc_no.Replace("/", "--"), DocumentList = MCAttachments.Attachments });
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        void ModelUpdated_QMS_T003_U(object sender, EventArgs e)
        {
            try
            {
                if (sender.ToString() == "value_code" && string.IsNullOrWhiteSpace(UD_OBJ.value_code) == false)
                {
                   
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>(); showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        private void InsertUsageDecision(object InputValue)
        {
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Classification POPUPEntityObject = MC.CLASS_PROFILE_LIST.Where(x => x.char_value.Equals(InputValue.ToString(), StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                    UD_OBJ.prof_code = POPUPEntityObject.profile_code;
                    UD_OBJ.prof_type = POPUPEntityObject.prof_type;
                    UD_OBJ.char_code = POPUPEntityObject.char_code;
                    UD_OBJ.char_value = POPUPEntityObject.char_value;
                    UD_OBJ.short_text = POPUPEntityObject.short_text;
                    UD_OBJ.v_code = POPUPEntityObject.v_code;
                    UD_OBJ.v_name = POPUPEntityObject.v_name;
                    UD_OBJ.q_score = POPUPEntityObject.quality_score;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>(); showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        private bool Validation()
        {
            try
            {
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
            return true;
        }

        private void Inspection_Processing_DR_Call(object item)
        {
            try
            {
                if (((IEnumerable)item).Cast<QMS_T003>().ToList().Count > 0)
                {
                    QMS_T003 ParameterEntityObject = ((IEnumerable)item).Cast<QMS_T003>().ToList()[0];
                    AppSessionState.ViewTitle = "Inspection Processing : Defect Recording";
                    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.QMS.dll");
                    Assembly assembly = Assembly.LoadFile(path1);
                    Type type = assembly.GetType("Reflection.Modules.QMS.Views.QMS_T013");
                    if (type != null)
                    {
                        dynamic instance = Activator.CreateInstance(type, "QM30", ParameterEntityObject.doc_no, ParameterEntityObject, "INSP_CHR");
                        SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                    }
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
        #endregion
        #region Abstract Commands

        /// <summary>
        /// 
        /// </summary>
        /// <param name="result"></param>
        protected override void OnCreateAction(InquiryActionResult<QMS_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<QMS_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<QMS_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<QMS_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<QMS_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<QMS_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<QMS_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnSaveAction(InquiryActionResult<QMS_T003_A> result)
        {
            try
            {
                if (Validation() == true)
                {
                    CursorControl.SetBusyState();
                    Logging();
                    MasterEntity.XDOC_U = obj.ObjectToXML(UD_OBJ);
                    MC_TEMP.INSP_LOT_LIST = new List<QMS_T003>();
                    MC_TEMP.INSP_LOT_LIST.Add(MasterEntity);
                    MC_TEMP = REPOSITORY.SaveWithReturnDomainObject<MC_QMS_T003>(MC_TEMP, "QMS_T014_BL", "QMS");

                    if (MC_TEMP.USAGE_DECISION != null)
                    {
                        if (MC_TEMP.USAGE_DECISION.Count > 0)
                        {
                            UD_OBJ = MC_TEMP.USAGE_DECISION[0];


                            // NOTE: Make This color and status info dynamic
                            if(MasterEntity.t_status=="01")
                            {
                                MasterEntity.color_code = "Yellow";
                                MasterEntity.t_display = "Draft";
                            }
                            else if (MasterEntity.t_status == "02")
                            {
                                MasterEntity.color_code = "Green";
                                MasterEntity.t_display = "Released";
                            }
                            else if (MasterEntity.t_status == "03")
                            {
                                MasterEntity.color_code = "Red";
                                MasterEntity.t_display = "Closed";
                            }

                            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(MasterEntity,"IL", "UD_UPDATE"));
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        protected override void OnRefreshCommand(InquiryActionResult<QMS_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_T003_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_T003_A> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
