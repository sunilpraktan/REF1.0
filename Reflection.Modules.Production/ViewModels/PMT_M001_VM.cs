using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
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
using System.Windows.Data;
using Reflection.BusinessEntity.Production;



namespace Reflection.Modules.Production.ViewModels
{
    public class PMT_M001_VM : WorkspaceViewModel<PMT_M001>
    {
        bool NewRecord = true;

        WebServiceRepository<PMT_M001> repository = new WebServiceRepository<PMT_M001>();
        WebServiceRepository<MultipleContext_PMT_M001> repository_MC = new WebServiceRepository<MultipleContext_PMT_M001>();
        WebServiceRepository<MultipleContext_PMT_M001> repository_MCTemp = new WebServiceRepository<MultipleContext_PMT_M001>();

        ObjectSerializationService obj = new ObjectSerializationService();

        #region Declaration        
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        private PMT_M001 _MasterEntity;
        public PMT_M001 MasterEntity
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

        private MultipleContext_PMT_M001 _MC;
        public MultipleContext_PMT_M001 MC
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

        private bool _ReadOnlyFlag;   //movement type enable disable
        public bool ReadOnlyFlag
        {
            get { return _ReadOnlyFlag; }
            set { _ReadOnlyFlag = value; RaisePropertyChanged("ReadOnlyFlag"); }
        }
        private List<PMT_M001> _FlipGridData;
        public List<PMT_M001> FlipGridData
        {
            get { return _FlipGridData; }
            set
            {
                if (_FlipGridData != value)
                {
                    _FlipGridData = value;

                    RaisePropertyChanged("FlipGridData");

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

        #region Collection
        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        #endregion

        #region StringList

        List<string> _stringListView;
        public List<string> StringListView
        {
            get { return _stringListView; }
            set
            {
                if (_stringListView != value)
                {
                    _stringListView = value;
                }
            }
        }

        #endregion

        #region Relay Command Decalration
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }

        #endregion

        #region Relay Command Actions

        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                PMT_M001 ParameterEntityObject = null;


                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<PMT_M001>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<PMT_M001>().ToList()[0];
                        Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.bdr_code;
                        MC = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PMT_M001>(MC, Request, "BreakDownReason", "Production", "LoadDocumentByDocumentNumber", 0, "");
                        MasterEntity = MC.MasterEntity[0];
                        MasterEntity.ts_code = ts_code_vm;
                        SelectedTabControlIndex = 0;
                        NewRecord = false;
                        ReadOnlyFlag = true;
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
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                MasterEntity.ts_code = ts_code_vm;
                if (MasterEntity.XmlDataDocument_PMT_M001_FLIP != null && NewRecord == true && ParameterOption1 == "Save")
                {
                    MC.FlipGridData = (List<PMT_M001>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PMT_M001_FLIP, MC.FlipGridData);
                    FlipGridData.Add(MC.FlipGridData[0]);
                    DataGridCollection.Refresh();
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
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
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

        #endregion

        #region Constructor 
        public PMT_M001_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new PMT_M001();
            FlipGridData = new List<PMT_M001>();
            MC = new MultipleContext_PMT_M001();
            MasterEntity.ValidateAsync().Wait();
            MasterEntity.client = AppSessionState.client;
            LoadInitialData();
        }
        public PMT_M001_VM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new PMT_M001();
            FlipGridData = new List<PMT_M001>();
            MC = new MultipleContext_PMT_M001();
            MasterEntity.ValidateAsync().Wait();
            MasterEntity.client = AppSessionState.client;
            LoadInitialData();
        }
        private void LoadInitialData()
        {
            try
            {
                ReadOnlyFlag = false;
                string Request = "LoadInitialData";
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PMT_M001>(MC, Request, "BreakDownReason", "Production", "LoadAll", 0, "");

                #region Command Initialisation
                CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                #endregion

                FlipGridData = MC.FlipGridData.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);   
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

        #region Validation
        private bool Validation()
        {
            if (MasterEntity.bdr_code == null || MasterEntity.bdr_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter BreakDown Reason Code...");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.bdr_desc == null || MasterEntity.bdr_desc == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter BreakDown Reason Description...");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        #endregion

        #region Abstract Methods
        protected override void OnSaveAction(InquiryActionResult<PMT_M001> result)
        {
            try
            {
                if (Validation() == true)
                {
                    this.MasterEntity.EndEdit();
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<PMT_M001>(MasterEntity, "BreakDownReason", "Production");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<PMT_M001>(MasterEntity, "BreakDownReason", "Production");
                    }

                    if (NewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();
                    }
                    if (NewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Updated Successfully");
                        showMessageService.ShowMessage();
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    NewRecord = false;
                    ReadOnlyFlag = true;
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
        protected override void OnCreateAction(InquiryActionResult<PMT_M001> result)
        {
            NewRecord = true;
            MasterEntity = new PMT_M001();
            ReadOnlyFlag = false;
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.client = AppSessionState.client;
        }
        protected override void OnRemoveAction(InquiryActionResult<PMT_M001> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<PMT_M001> result)
        {

        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<PMT_M001> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<PMT_M001> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<PMT_M001> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<PMT_M001> result)
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<PMT_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PMT_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PMT_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PMT_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PMT_M001> result)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region Filters
        private string _filterString_FlipGrid;
        public string FilterString_FlipGrid
        {
            get { return _filterString_FlipGrid; }
            set
            {
                _filterString_FlipGrid = value;
                RaisePropertyChanged("FilterString_FlipGrid");
                FilterCollection();
            }
        }
        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as PMT_M001;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return

                        (data.bdr_code  != null && data.bdr_code.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||   
                        (data.bdr_desc != null && data.bdr_desc.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }

        

        #endregion
    }
}
