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
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity;


namespace Reflection.Module.Project.ViewModels
{
    public class PRO_M001_A_VM : WorkspaceViewModel<PRO_M001_A>
    {
        #region Declaration
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _ASDefault { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault
        {
            get { return _ASDefault; }
            set
            {
                if (_ASDefault != value)
                {
                    _ASDefault = value; RaisePropertyChanged("ASDefault");
                }
            }
        }
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        bool NewRecord = true;
        WebServiceRepository<PRO_M001_A> repository = new WebServiceRepository<PRO_M001_A>();
        WebServiceRepository<MultipleContext_PRO_M001_A> repository_MC = new WebServiceRepository<MultipleContext_PRO_M001_A>();
        WebServiceRepository<MultipleContext_PRO_M001_A> repository_MCTemp = new WebServiceRepository<MultipleContext_PRO_M001_A>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_PRO_M001_A _MC = new MultipleContext_PRO_M001_A();


        public MultipleContext_PRO_M001_A MC
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
        private MultipleContext_PRO_M001_A _MCTemp = new MultipleContext_PRO_M001_A();
        public MultipleContext_PRO_M001_A MCTemp
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

        private PRO_M001_A _MasterEntity;
        public PRO_M001_A MasterEntity
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
        private AutoSuggestTextViewModel<dynamic> _ASProCategory { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASProCategory
        {
            get { return _ASProCategory; }
            set
            {
                if (_ASProCategory != value)
                {
                    _ASProCategory = value; RaisePropertyChanged("ASProCategory");
                }
            }
        }

        #endregion

        #region Relay Command Declaration
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdProjectCategory { get; private set; }

        #endregion

        #region List

        private List<PRO_M001_A> _ProjectSubCategoryViewList;
        public List<PRO_M001_A> ProjectSubCategoryViewList
        {
            get { return _ProjectSubCategoryViewList; }
            set
            {
                if (_ProjectSubCategoryViewList != value)
                {
                    _ProjectSubCategoryViewList = value;
                    RaisePropertyChanged("ProjectSubCategoryViewList");
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

        public PRO_M001_A_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new PRO_M001_A();
            ProjectSubCategoryViewList = new List<PRO_M001_A>();
            MasterEntity.ValidateAsync().Wait();

            LoadInitialData();
        }
        public PRO_M001_A_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new PRO_M001_A();
            ProjectSubCategoryViewList = new List<PRO_M001_A>();
            MasterEntity.ValidateAsync().Wait();

            LoadInitialData();
        }

        #endregion

        #region User Defined Methods
        private void DefaultValues()
        {
            
            MasterEntity.active = true;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            
            MasterEntity.ts_code = ts_code_vm;

        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                string ParametersStringValue = "";
                PRO_M001_A ParameterEntityObject = null;
                MasterEntity = new PRO_M001_A();

                if (((IEnumerable)ParameterObject).Cast<PRO_M001_A>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<PRO_M001_A>().ToList()[0];

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
        private void InsertProjectCategory(object InputValue)
        {
            try
            {
                string Request = "";
                PRO_M001_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.ProjectCategoryList.Where(x => x.cat_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PRO_M001_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.cat_id = POPUPEntityObject.cat_id;
                    MasterEntity.cat_title = POPUPEntityObject.cat_title;

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
                    MC.ProjectSubCategoryList = (List<PRO_M001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_DataGridView, MC.ProjectSubCategoryList);
                    ProjectSubCategoryViewList.Add(MC.ProjectSubCategoryList[0]);
                    ViewDataGridCollection.Refresh();
                    ViewDataGridCollection.SortDescriptions.Add(new SortDescription("sub_cat_code", ListSortDirection.Descending));
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

            if (MasterEntity.sub_cat_code == null || MasterEntity.sub_cat_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Sub Category Code...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.sub_cat == null || MasterEntity.sub_cat == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Sub Category Name...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.cat_id == null || MasterEntity.cat_id == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Category...");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        private void LoadInitialData()
        {
            try
            {

                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PRO_M001_A>(MC, Request, "ProjectSubCategoryMaster", "PM", "LoadInitialData", 0, "");

                CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdProjectCategory = new RelayCommand<object>(items => { if (items == null) { return; } InsertProjectCategory(items); });

                ProjectSubCategoryViewList = MC.ProjectSubCategoryList.ToList();
                ViewDataGridCollection = CollectionViewSource.GetDefaultView(ProjectSubCategoryViewList);
                ViewDataGridCollection.Filter = new Predicate<object>(Filter_ProjectSubCategoryGridData);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_M001_P)x).cat_id.ToString());
                TheFilter = (o, prefix) => (((PRO_M001_P)o).cat_id.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((PRO_M001_P)o).cat_title ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASProCategory = new AutoSuggestTextViewModel<dynamic>(MC.ProjectCategoryList, TheFilter, SuggestedValue, "cat_id", true);
                ASProCategory.AutoSuggestVM.IsEmptyValueAllowed = true;

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
        protected override void OnCreateAction(InquiryActionResult<PRO_M001_A> result)
        {
            NewRecord = true;
            MasterEntity = new PRO_M001_A();
            MasterEntity.ValidateAsync().Wait();

            ViewDataGridCollection.Refresh();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<PRO_M001_A> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<PRO_M001_A> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<PRO_M001_A> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<PRO_M001_A> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<PRO_M001_A> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<PRO_M001_A> result)
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
        protected override void OnRefreshCommand(InquiryActionResult<PRO_M001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PRO_M001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PRO_M001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PRO_M001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PRO_M001_A> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnSaveAction(InquiryActionResult<PRO_M001_A> result)
        {
            try
            {
                if (Validation() == true)
                {
                    this.MasterEntity.EndEdit();

                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<PRO_M001_A>(MasterEntity, "ProjectSubCategoryMaster", "PM");
                    }
                    else if (NewRecord == false)
                    {
                       
                        MasterEntity.comp_code = AppSessionState.comp_code;
                        MasterEntity.client = AppSessionState.client;

                        MasterEntity = repository.UpdateWithReturnDomainObject<PRO_M001_A>(MasterEntity, "ProjectSubCategoryMaster", "PM");
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
        public bool Filter_ProjectSubCategoryGridData(object obj)
        {
            var data = obj as PRO_M001_A;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringProjectSubCategory))
                {
                    return (data.sub_cat != null && data.sub_cat.ToString().ToLower().Contains(_filterStringProjectSubCategory.ToLower()) ||
                            data.cat_id != null && data.cat_id.ToString().ToLower().Contains(_filterStringProjectSubCategory.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterStringProjectSubCategory;
        public string filterStringProjectSubCategory
        {
            get { return _filterStringProjectSubCategory; }
            set
            {
                _filterStringProjectSubCategory = value;
                RaisePropertyChanged("filterStringProjectSubCategory");
                FilterStringProjectSubCategory();
            }
        }
        private void FilterStringProjectSubCategory()
        {
            if (_ViewDataGridCollection != null)
            {
                _ViewDataGridCollection.Refresh();
            }
        }


        #endregion
    }
}
