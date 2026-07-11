using Reflection.BusinessEntity.ProjectManagement;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections.ObjectModel;

namespace Reflection.Module.Project.ViewModels
{   // Project Management Timesheet View Model
    class PRO_T002_A_3_A_VM : WorkspaceViewModel<PRO_T002>
    {

        #region Variable Declaration

        WebServiceRepository<MultipleContext_PRO_T002> repository_MC = new WebServiceRepository<MultipleContext_PRO_T002>();
        WebServiceRepository<PRO_T002> repository = new WebServiceRepository<PRO_T002>();
        MultipleContext_PRO_T002 _MC = new MultipleContext_PRO_T002();
        MultipleContext_PRO_T002 MC_temp = new MultipleContext_PRO_T002();

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public MultipleContext_PRO_T002 MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value;

                    RaisePropertyChanged("MC");
                }
            }
        }

        private ObservableCollection<PRO_T002_A_3_A> _TimesheetEntity;
        public ObservableCollection<PRO_T002_A_3_A> TimesheetEntity
        {
            get
            {
                return _TimesheetEntity;
            }
            set
            {
                if (_TimesheetEntity != value)
                {
                    _TimesheetEntity = value;
                    RaisePropertyChanged(nameof(TimesheetEntity));
                    //value.BeginEdit();
                }
            }
        }

        private int _dgSelectedIndexTimesheet;
        public int dgselectedIndexWorkTimesheet
        {
            get { return _dgSelectedIndexTimesheet; }
            set
            {
                if (_dgSelectedIndexTimesheet != null)
                {
                    _dgSelectedIndexTimesheet = value;
                    RaisePropertyChanged("dgselectedIndexWork");

                }
            }
        }


        #endregion

        #region Constructor
        public PRO_T002_A_3_A_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            TimesheetEntity = new ObservableCollection<PRO_T002_A_3_A>();

            LoadInitialData();
        }
        public PRO_T002_A_3_A_VM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            TimesheetEntity = new ObservableCollection<PRO_T002_A_3_A>();

            LoadInitialData();
        }
        #endregion

        #region User Defined Methods

        private void LoadInitialData()
        {            

            if (AppSessionState.TransValueType != null)
            {
                string Request = "LoadIntialDataofTimesheet" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@!@!@" + AppSessionState.TransValueType + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "");
                //string Request = "LoadIntialDataofTimesheet" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.TransValueType;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PRO_T002>(MC, Request, "Tasks", "PM", "LoadAll", 0, "");

                TimesheetEntity = MC.TimesheetList;
                //SelectedTabControlIndex = 1;
                //DataGridCollection = MC.TaskViewList.Where(x => x.project_id == AppSessionState.TransValueType.ToString()).ToList();
                //TaskCollection = CollectionViewSource.GetDefaultView(DataGridCollection);

                AppSessionState.TransValueType = null;
            }

        }
        private bool Validations()
        {
            foreach (var o in TimesheetEntity)
            {
                if (o.check == true)
                {
                    if (o.invoicable == true && (o.invoice_percentage == null || o.invoice_percentage == 0))
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation ";
                        showMessageService.Text = String.Format("If Invoicable is Checked. Invoicable Percentage (%) is Compulsory..!!", this.Title);
                        showMessageService.ShowMessage();
                        return false;
                    }
                }

            }

            return true;
        }
        #endregion

        #region Abstract Command Actions                                                                                                                                                                                                                        
        protected override void OnSaveAction(InquiryActionResult<PRO_T002> result)
        {

            ObjectSerializationService objser = new ObjectSerializationService();

            if (Validations() == true)
            {
                    //TimesheetEntity = repository.UpdateWithReturnDomainObject<PRO_T002>(TimesheetEntity, "Tasks", "PM");
            }

        }
        protected override void OnCreateAction(InquiryActionResult<PRO_T002> result)
        {
            //NewRecord = true;
            //MasterEntity = new PRO_T002();
            //WorkSummaryEntity = new ObservableCollection<PRO_T002_A>();
            //DefaultValues();
            //TaskCollection.Refresh();

        }
        protected override void OnRemoveAction(InquiryActionResult<PRO_T002> result)
        {
            

        }
        protected override void OnDiscardAction(InquiryActionResult<PRO_T002> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<PRO_T002> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<PRO_T002> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<PRO_T002> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<PRO_T002> result)
        {

        }
        protected override void OnDocumentAction()
        {
            //if (!string.IsNullOrEmpty(MasterEntity.task_id))
            //{            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
            //    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.task_id.Replace("/", "--"), DocumentList = MC_temp.AttachmentData });
            //}
        }

        protected override void OnRefreshCommand(InquiryActionResult<PRO_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PRO_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PRO_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PRO_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PRO_T002> result)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
