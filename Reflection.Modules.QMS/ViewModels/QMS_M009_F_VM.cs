using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.QMS;
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
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.QMS.ViewModels
{
    class QMS_M009_F_VM : WorkspaceViewModel<QMS_M009_F>
    {

        #region Declaration
        bool NewRecord = true;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        WebServiceRepository<QMS_M009_F> repository = new WebServiceRepository<QMS_M009_F>();
        WebServiceRepository<MultipleContext_QMS_M009_F> repository_MC = new WebServiceRepository<MultipleContext_QMS_M009_F>();
        WebServiceRepository<MultipleContext_QMS_M009_F> repository_MCTemp = new WebServiceRepository<MultipleContext_QMS_M009_F>();
        ObjectSerializationService obj = new ObjectSerializationService();
        private MultipleContext_QMS_M009_F _MC = new MultipleContext_QMS_M009_F();
        public MultipleContext_QMS_M009_F MC
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
        private MultipleContext_QMS_M009_F _MCTemp = new MultipleContext_QMS_M009_F();
        public MultipleContext_QMS_M009_F MCTemp
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

        private QMS_M009_F _MasterEntity;
        public QMS_M009_F MasterEntity
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

        private bool _ReadOnlyFlag;
        public bool ReadOnlyFlag
        {
            get
            {
                return _ReadOnlyFlag;
            }
            set
            {
                if (_ReadOnlyFlag != value)
                {
                    _ReadOnlyFlag = value;
                    RaisePropertyChanged(nameof(ReadOnlyFlag));
                }
            }
        }
        #endregion

        #region AutoSuggest TextBox Decleration
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(QMS_M009_F_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

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

        private AutoSuggestTextViewModel<dynamic> _ASCatlog { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCatlog
        {
            get { return _ASCatlog; }
            set
            {
                if (_ASCatlog != value)
                {
                    _ASCatlog = value; RaisePropertyChanged("ASCatlog");
                }
            }
        }

        #endregion

        #region Relay Command Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdCatlog { get; set; }
        #endregion

        #region List
        private List<QMS_M009_FFlip> _FlipGridData;
        public List<QMS_M009_FFlip> FlipGridData
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
        public QMS_M009_F_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new QMS_M009_F();
            FlipGridData = new List<QMS_M009_FFlip>();
            MCTemp = new MultipleContext_QMS_M009_F();
            MasterEntity.ValidateAsync().Wait();
            LoadInitialData();
        }
        public QMS_M009_F_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new QMS_M009_F();
            FlipGridData = new List<QMS_M009_FFlip>();
            MCTemp = new MultipleContext_QMS_M009_F();
            MasterEntity.ValidateAsync().Wait();
            LoadInitialData();
        }
        #endregion


        #region User Define Methods
        private void LoadInitialData()
        {
            try
            {
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CommandLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CmdCatlog = new RelayCommand<object>(items => { if (items == null) { return; } InsertCatlog(items); });

                string Request = "LoadInitialData";
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_M009_F>(MC, Request, "ParameterGroupMaster", "QMS", "LoadInitialData", 0, "");

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M032_P)x).para_type ?? "");
                TheFilter = (o, prefix) => (((QMS_M032_P)o).para_type ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M032_P)o).cat_type_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCatlog = new AutoSuggestTextViewModel<dynamic>(MC.CatlogMaster, TheFilter, SuggestedValue, "catlog_code", true);
                ASCatlog.AutoSuggestVM.IsEmptyValueAllowed = true;

                FlipGridData = MC.FlipGridData.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGridData);
                DefaultValues();
                ReadOnlyFlag = false;
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
        private void InsertCatlog(object InputValue)
        {
            string Request = "";
            QMS_M032_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.CatlogMaster.Where(x => x.para_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M032_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M032_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.para_type = POPUPEntityObject.para_type;
                    MasterEntity.CatlogName = POPUPEntityObject.cat_type_desc;
                }
            }
            catch (Exception ex) { }
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
            {
                MC.FlipGridData = (List<QMS_M009_FFlip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.FlipGridData);
                FlipGridData.Add(MC.FlipGridData[0]);
                FlipDataGridCollection.Refresh();
                FlipDataGridCollection.SortDescriptions.Add(new SortDescription("para_code", ListSortDirection.Descending));
            }
            MasterEntity.ts_code = ts_code_vm;
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            string ParametersStringValue = "";
            QMS_M009_FFlip ParameterEntityObject = null;
            MasterEntity = new QMS_M009_F();


            if (((IEnumerable)ParameterObject).Cast<QMS_M009_FFlip>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<QMS_M009_FFlip>().ToList()[0];
                Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.para_code;
                NewRecord = false;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_QMS_M009_F>(MCTemp, Request, "ParameterGroupMaster", "QMS", "LoadDocumentByDocumentNumber", 0, "");

                if (MCTemp.MasterEntity.Count > 0)
                {
                    MasterEntity = MCTemp.MasterEntity[0];
                }
                ReadOnlyFlag = true;

            }
            SelectedTabControlIndex = 0;
            MasterEntity.ts_code = ts_code_vm;
            var msg = new NotificationMessage("QMS_M009_F_VM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.t_status = "Draft";
            MasterEntity.valid_from = System.DateTime.Now;
            MasterEntity.test_code = "Test";
        }
        private bool Validation()
        {

            //if (MasterEntity.para_code == null || MasterEntity.para_code == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Enter Group Code...");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            if (MasterEntity.para_type == null || MasterEntity.para_type == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Catlog Code...");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<QMS_M009_F> result)
        {
            NewRecord = true;
            MasterEntity = new QMS_M009_F();
            MasterEntity.ValidateAsync().Wait();
            FlipDataGridCollection.Refresh();
            ReadOnlyFlag = false;
            DefaultValues();
        }

        protected override void OnDiscardAction(InquiryActionResult<QMS_M009_F> result)
        {
            ReadOnlyFlag = false;
        }

        protected override void OnDocumentAction()
        {
            ReadOnlyFlag = false;
        }

        protected override void OnFevoriteAction(InquiryActionResult<QMS_M009_F> result)
        {
            ReadOnlyFlag = false;
        }

        protected override void OnFlipAction(InquiryActionResult<QMS_M009_F> result)
        {
            ReadOnlyFlag = false;
        }

        protected override void OnHelpAction(InquiryActionResult<QMS_M009_F> result)
        {
            ReadOnlyFlag = false;
        }

        protected override void OnPrintAction(InquiryActionResult<QMS_M009_F> result)
        {
           
        }

        protected override void OnRemoveAction(InquiryActionResult<QMS_M009_F> result)
        {
            ReadOnlyFlag = false;
        }

        protected override void OnSaveAction(InquiryActionResult<QMS_M009_F> result)
        {
            try
            {
                if (Validation() == true)
                {
                    this.MasterEntity.EndEdit();
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<QMS_M009_F>(MasterEntity, "ParameterGroupMaster", "QMS");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<QMS_M009_F>(MasterEntity, "ParameterGroupMaster", "QMS");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Data Saved Successfully");
                    showMessageService.ShowMessage();
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
        protected override void OnRefreshCommand(InquiryActionResult<QMS_M009_F> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_M009_F> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_M009_F> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_M009_F> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_M009_F> result)
        {
            throw new NotImplementedException();
        }

        #endregion

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
            var data = obj as QMS_M009_FFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringFlipGridData))
                {
                    return (data.para_code != null && data.para_code.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.para_name != null && data.para_name.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.catlog_code != null && data.catlog_code.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                            (data.valid_from != null && data.valid_from.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower()));
                }
                return true;
            }
            return false;
        }

       

        #endregion
    }
}
