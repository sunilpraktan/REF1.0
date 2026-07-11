using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.ProjectManagement;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.Presentation.Controls;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Module.Project.ViewModels
{
    class PPC_M0002_VM : WorkspaceViewModel<PPC_M0002>
    {
        bool NewRecord = true;
        WebServiceRepository<PPC_M0002> repository = new WebServiceRepository<PPC_M0002>();
        WebServiceRepository<MultipleContext_PPC_M0002> repository_MC = new WebServiceRepository<MultipleContext_PPC_M0002>();
        WebServiceRepository<MultipleContext_PPC_M0002> repository_MCTemp = new WebServiceRepository<MultipleContext_PPC_M0002>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest Initialization
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PPC_M0002_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        private DataGridCellInfo _cellInfo;
        public DataGridCellInfo CellInfo
        {
            get { return _cellInfo; }
            set
            {
                _cellInfo = value;
                SetAutoTextSource(_cellInfo);
                RaisePropertyChanged("CellInfo");
            }
        }

        private void SetAutoTextSource(DataGridCellInfo dgCellInfo)
        {
            if (dgCellInfo != null)
            {
                var column = dgCellInfo.Column as DataGridColumn;
                if (column != null)
                {
                    string headerName = column.Header.ToString();
                    string SourceName = column.SortMemberPath.ToString();
                    //if (SourceName == "insp_char")
                    //{ ASDefault = ASInspChar; }
                    //else if (SourceName == "insp_method")
                }
            }
        }
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

        #endregion
        #region Relay Command Decleration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocNo { get; private set; }

        #endregion
        #region Variable Decleration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private PPC_M0002 _MasterEntity;
        public PPC_M0002 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                    value.BeginEdit();
                }
            }
        }
        private List<PPC_M0002> _FlipGridData;
        public List<PPC_M0002> FlipGridData
        {
            get { return _FlipGridData; }
            set { _FlipGridData = value; RaisePropertyChanged("FlipGridData"); }
        }
        private MultipleContext_PPC_M0002 _MC;
        public MultipleContext_PPC_M0002 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_PPC_M0002 _MCTemp;
        public MultipleContext_PPC_M0002 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
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
        #region Constructor
        public PPC_M0002_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new PPC_M0002();
            MC = new MultipleContext_PPC_M0002();
            MCTemp = new MultipleContext_PPC_M0002();

            LoadInitialData();
            DefaultValues();
        }
        public PPC_M0002_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new PPC_M0002();
            MC = new MultipleContext_PPC_M0002();
            MCTemp = new MultipleContext_PPC_M0002();

            LoadInitialData();
            DefaultValues();
        }

        #endregion
        #region User Defined Methods
        private void DefaultValues()
        {
            //MasterEntity.active = true;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.location_id = AppSessionState.location_Id;

        }
        private bool Validation()
        {

            if (MasterEntity.op_code == null || MasterEntity.op_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Code...");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.op_desc == null || MasterEntity.op_desc == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Description...");
                showMessageService.ShowMessage();
                return false;
            }

            return true;
        }
        private void LoadInitialData()
        {
            try
            {
                #region RelayCommand Initialization
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CmdLoadDocumentByDocNo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });

                #endregion
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_PPC_M0002>(MC, Request, "Project_Master01", "PM", "LoadInitialData", 0, "");

                FlipGridData = MC.MasterEntity;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);


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


        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            PPC_M0002 ParameterEntityObject = null;

            if (((IEnumerable)ParameterObject).Cast<PPC_M0002>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<PPC_M0002>().ToList()[0];
                Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + ParameterEntityObject.op_code;
                NewRecord = false;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_PPC_M0002>(MCTemp, Request, "Project_Master01", "PM", "LoadDocumentByDocumentNumber", 0, "");

                if (MCTemp.MasterEntity.Count > 0)
                {
                    MasterEntity = MCTemp.MasterEntity[0];
                }

            }

            SelectedTabControlIndex = 0;
            var msg = new NotificationMessage("PPC_M0002_VM");
            Messenger.Default.Send<NotificationMessage>(msg);
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

        #endregion
        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<PPC_M0002> result)
        {
            MasterEntity = new PPC_M0002();
            DefaultValues();

            NewRecord = true;

            var msg = new NotificationMessage("PPC_M0002_VM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }

        protected override void OnDiscardAction(InquiryActionResult<PPC_M0002> result)
        {

        }

        protected override void OnDocumentAction()
        {

        }

        protected override void OnFevoriteAction(InquiryActionResult<PPC_M0002> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<PPC_M0002> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<PPC_M0002> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<PPC_M0002> result)
        {

        }

        protected override void OnRemoveAction(InquiryActionResult<PPC_M0002> result)
        {

        }

        protected override void OnSaveAction(InquiryActionResult<PPC_M0002> result)
        {
            try
            {
                if (Validation() == true)
                {

                    this.MasterEntity.EndEdit();

                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<PPC_M0002>(MasterEntity, "Project_Master01", "PM");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<PPC_M0002>(MasterEntity, "Project_Master01", "PM");
                    }

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Data Saved Successfully");
                    showMessageService.ShowMessage();
                    NewRecord = false;

                    var msg = new NotificationMessage("PPC_M0002_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);
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
        protected override void OnRefreshCommand(InquiryActionResult<PPC_M0002> result)
        {

        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PPC_M0002> result)
        {

        }

        protected override void OnValidateCommand(InquiryActionResult<PPC_M0002> result)
        {

        }

        protected override void OnTraceCommand(InquiryActionResult<PPC_M0002> result)
        {

        }

        protected override void OnMailCommand(InquiryActionResult<PPC_M0002> result)
        {

        }
        #endregion
        #region Filters
        #region Filter For Flip Grid
        private string _filterString;
        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                RaisePropertyChanged("FilterString");
                FilterCollection();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as PPC_M0002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.op_code != null && data.op_code.ToLower().Contains(_filterString.ToLower()) ||
                            data.op_desc != null && data.op_desc.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.act_type != null && data.act_type.ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }


        #endregion
        #endregion
    }
}
