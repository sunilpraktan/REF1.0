using System;
using System.Collections.Generic;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using Reflection.BusinessEntity.ProjectManagement;
using System.ComponentModel;
using System.Collections;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;

namespace Reflection.Module.Project.ViewModels
{
    public class PRO_M001_VM : WorkspaceViewModel<PRO_M001>
    {
        #region Declaration

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        bool NewRecord = true;
        WebServiceRepository<PRO_M001> repository = new WebServiceRepository<PRO_M001>();
        WebServiceRepository<MultipleContext_PRO_M001> repository_MC = new WebServiceRepository<MultipleContext_PRO_M001>();
        WebServiceRepository<MultipleContext_PRO_M001> repository_MCTemp = new WebServiceRepository<MultipleContext_PRO_M001>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_PRO_M001 _MC = new MultipleContext_PRO_M001();


        public MultipleContext_PRO_M001 MC
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
        private MultipleContext_PRO_M001 _MCTemp = new MultipleContext_PRO_M001();
        public MultipleContext_PRO_M001 MCTemp
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

        private PRO_M001 _MasterEntity;
        public PRO_M001 MasterEntity
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
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }

        #endregion

        #region List

        private List<PRO_M001> _ProjectCategoryViewList;
        public List<PRO_M001> ProjectCategoryViewList
        {
            get { return _ProjectCategoryViewList; }
            set
            {
                if (_ProjectCategoryViewList != value)
                {
                    _ProjectCategoryViewList = value;
                    RaisePropertyChanged("ProjectCategoryViewList");
                }
            }
        }
        #endregion

        #region Collection

        private ICollectionView _ViewDataGridCollection;
        public ICollectionView ViewDataGridCollection
        {
            get { return _ViewDataGridCollection; }
            set { _ViewDataGridCollection = value; RaisePropertyChanged("ViewDataGridCollection"); }
        }
        #endregion

        #region Constructor

        public PRO_M001_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new PRO_M001();
            ProjectCategoryViewList = new List<PRO_M001>();
            MasterEntity.ValidateAsync().Wait();

            LoadInitialData();
        }
        public PRO_M001_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new PRO_M001();
            ProjectCategoryViewList = new List<PRO_M001>();
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
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.ts_code = ts_code_vm;

        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                string ParametersStringValue = "";
                PRO_M001 ParameterEntityObject = null;
                MasterEntity = new PRO_M001();

                if (((IEnumerable)ParameterObject).Cast<PRO_M001>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<PRO_M001>().ToList()[0];

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
                if (MasterEntity.XmlDataDocument_DataGridView != null && NewRecord == true && ParameterOption1 == "Save")
                {
                    MC.ProjectCategoryList = (List<PRO_M001>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_DataGridView, MC.ProjectCategoryList);
                    ProjectCategoryViewList.Add(MC.ProjectCategoryList[0]);
                    ViewDataGridCollection.Refresh();
                    ViewDataGridCollection.SortDescriptions.Add(new SortDescription("cat_id", ListSortDirection.Descending));
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

            if (MasterEntity.cat_id == null || MasterEntity.cat_id == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Category Code...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.cat_title == null || MasterEntity.cat_title == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Category Name...");
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
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PRO_M001>(MC, Request, "ProjectCategoryMaster", "PM", "LoadInitialData", 0, "");

                CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                ProjectCategoryViewList = MC.ProjectCategoryList.ToList();
                ViewDataGridCollection = CollectionViewSource.GetDefaultView(ProjectCategoryViewList);
                ViewDataGridCollection.Filter = new Predicate<object>(Filter_ProjectCategoryGridData);
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
        protected override void OnCreateAction(InquiryActionResult<PRO_M001> result)
        {
            NewRecord = true;
            MasterEntity = new PRO_M001();
            MasterEntity.ValidateAsync().Wait();

            ViewDataGridCollection.Refresh();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<PRO_M001> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<PRO_M001> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<PRO_M001> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<PRO_M001> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<PRO_M001> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<PRO_M001> result)
        {

        }
        protected override void OnDocumentAction()
        {
            //if (!string.IsNullOrEmpty(MasterEntity.cat_id.ToString()))
            //{
            //    //this.IsDocumentViewerShow = !IsDocumentViewerShow;
            //    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.cat_id.ToString().Replace("/", "--") });
            //}
        }
        protected override void OnRefreshCommand(InquiryActionResult<PRO_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PRO_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PRO_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PRO_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PRO_M001> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnSaveAction(InquiryActionResult<PRO_M001> result)
        {
            try
            {
                if (Validation() == true)
                {
                    this.MasterEntity.EndEdit();

                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<PRO_M001>(MasterEntity, "ProjectCategoryMaster", "PM");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity.editby = AppSessionState.UserID;
                        MasterEntity.comp_code = AppSessionState.comp_code;
                        MasterEntity.location_Id = AppSessionState.location_Id;

                        MasterEntity = repository.UpdateWithReturnDomainObject<PRO_M001>(MasterEntity, "ProjectCategoryMaster", "PM");
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

        #region Filter Project Categories
        public bool Filter_ProjectCategoryGridData(object obj)
        {
            var data = obj as PRO_M001;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringProjectCategory))
                {
                    return (data.cat_title != null && data.cat_title.ToString().ToLower().Contains(_filterStringProjectCategory.ToLower()) ||
                            data.cat_id != null && data.cat_id.ToString().ToLower().Contains(_filterStringProjectCategory.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterStringProjectCategory;
        public string filterStringProjectCategory
        {
            get { return _filterStringProjectCategory; }
            set
            {
                _filterStringProjectCategory = value;
                RaisePropertyChanged("filterStringProjectCategory");
                FilterStringProjectCategory();
            }
        }
        private void FilterStringProjectCategory()
        {
            if (_ViewDataGridCollection != null)
            {
                _ViewDataGridCollection.Refresh();
            }
        }


        #endregion
    }
}
