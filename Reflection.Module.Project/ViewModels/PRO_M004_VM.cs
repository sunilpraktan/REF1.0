using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using Reflection.BusinessEntity.ProjectManagement;
using System.ComponentModel;
using System.Collections;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System;
using System.Linq;

namespace Reflection.Module.Project.ViewModels
{
    class PRO_M004_VM : WorkspaceViewModel<PRO_M004>
    {

        #region Declaration

        bool NewRecord = true;
        WebServiceRepository<PRO_M004> repository = new WebServiceRepository<PRO_M004>();
        WebServiceRepository<MultipleContext_PRO_M004> repository_MC = new WebServiceRepository<MultipleContext_PRO_M004>();
        WebServiceRepository<MultipleContext_PRO_M004> repository_MCTemp = new WebServiceRepository<MultipleContext_PRO_M004>();
        ObjectSerializationService obj = new ObjectSerializationService();

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        private MultipleContext_PRO_M004 _MC = new MultipleContext_PRO_M004();
        public MultipleContext_PRO_M004 MC
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
        private MultipleContext_PRO_M004 _MCTemp = new MultipleContext_PRO_M004();
        public MultipleContext_PRO_M004 MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value; RaisePropertyChanged("MCTemp");
                }
            }
        }

        private PRO_M004 _MasterEntity;
        public PRO_M004 MasterEntity
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
                    value.BeginEdit();
                }
            }
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

        #region Relay Command Declaration
        public RelayCommand<object> CommandLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region List
        private List<PRO_M004> _ProjectRoleViewList;
        public List<PRO_M004> ProjectRoleViewList
        {
            get { return _ProjectRoleViewList; }
            set
            {
                if (_ProjectRoleViewList != value)
                {
                    _ProjectRoleViewList = value;
                    RaisePropertyChanged("ProjectRoleViewList");
                }
            }
        }
        #endregion

        #region Collection
        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }
        #endregion

        #region Constructor
        public PRO_M004_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new PRO_M004();
            ProjectRoleViewList = new List<PRO_M004>();
            MasterEntity.ValidateAsync().Wait();
            
            LoadInitialData();
        }
        public PRO_M004_VM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new PRO_M004();
            ProjectRoleViewList = new List<PRO_M004>();
            MasterEntity.ValidateAsync().Wait();

            LoadInitialData();
        }
        #endregion

        #region User Defined Methods
        private void DefaultValues()
        {
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.location_Id  = AppSessionState.location_Id;
            MasterEntity.comp_code  = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                string ParametersStringValue = "";
                PRO_M004 ParameterEntityObject = null;
                MasterEntity = new PRO_M004();

                if (((IEnumerable)ParameterObject).Cast<PRO_M004>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<PRO_M004>().ToList()[0];

                    MasterEntity = ParameterEntityObject;
                }
                SelectedTabControlIndex = 0;
                MasterEntity.ts_code = ts_code_vm;
                NewRecord = false;
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
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    //isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                    AppSessionState.ViewOtherRecordAllowed = true;
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

        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                MasterEntity.ts_code = ts_code_vm;
                if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
                {
                    MC.ProjectRoleList = (List<PRO_M004>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.ProjectRoleList);
                    ProjectRoleViewList.Add(MC.ProjectRoleList[0]);
                    FlipDataGridCollection.Refresh();
                    FlipDataGridCollection.SortDescriptions.Add(new SortDescription("RoleCode", ListSortDirection.Descending));
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
        private bool Validation()
        {
            if (MasterEntity.RoleCode == null || MasterEntity.RoleCode == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter the Role Code...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.role_name == null || MasterEntity.role_name == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter the Role Name...");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        private void LoadInitialData()
        {
            try
            {

                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PRO_M004>(MC, Request, "ProjectRoleMaster", "PM", "LoadInitialData", 0, "");

                CommandLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                ProjectRoleViewList = MC.ProjectRoleList.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(ProjectRoleViewList);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGridData);
                DefaultValues();
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

        #region CommandAction
        protected override void OnCreateAction(InquiryActionResult<PRO_M004> result)
        {
            NewRecord = true;
            MasterEntity = new PRO_M004();
            MasterEntity.ValidateAsync().Wait();

            FlipDataGridCollection.Refresh();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<PRO_M004> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<PRO_M004> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<PRO_M004> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<PRO_M004> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<PRO_M004> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<PRO_M004> result)
        {

        }
        protected override void OnDocumentAction()
        {
            //if (!string.IsNullOrEmpty(MasterEntity.phase_name))
            //{
            //    //this.IsDocumentViewerShow = !IsDocumentViewerShow;
            //    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.phase_name.Replace("/", "--")});
            //}
        }
        protected override void OnRefreshCommand(InquiryActionResult<PRO_M004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PRO_M004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PRO_M004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PRO_M004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PRO_M004> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnSaveAction(InquiryActionResult<PRO_M004> result)
        {
            try
            {
                if (Validation() == true)
                {
                    
                    this.MasterEntity.EndEdit();
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<PRO_M004>(MasterEntity, "ProjectRoleMaster", "PM");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity.editby = AppSessionState.UserID;
                        MasterEntity.location_Id = AppSessionState.location_Id;

                        MasterEntity = repository.UpdateWithReturnDomainObject<PRO_M004>(MasterEntity, "ProjectRoleMaster", "PM");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Data Saved Successfully");
                    showMessageService.ShowMessage();
                    NewRecord = false;
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

        #region Filters

        #region Filter For Flip Grid Data
        private string _FilterStringFlipGridData;
        public string FilterStringFlipGridData
        {
            get { return _FilterStringFlipGridData; }
            set
            {
                _FilterStringFlipGridData = value;
                RaisePropertyChanged("FilterStringFlipGridData");
                Filter_FlipGrid();
            }
        }
        private void Filter_FlipGrid()
        {
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGridData(object obj)
        {
            var data = obj as PRO_M004;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringFlipGridData))
                {
                    return (data.RoleCode != null && data.RoleCode.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.role_name != null && data.role_name.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower()));
                }
                return true;
            }
            return false;
        }

        

        #endregion

        #endregion
    }
}
