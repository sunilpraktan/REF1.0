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
    public class QMS_M030_G_VM : WorkspaceViewModel<QMS_M030_G>
    {
        bool NewRecord = true;

        WebServiceRepository<QMS_M030_G> repository = new WebServiceRepository<QMS_M030_G>();
        WebServiceRepository<MultipleContext_QMS_M030_G> repository_MC = new WebServiceRepository<MultipleContext_QMS_M030_G>();
        WebServiceRepository<MultipleContext_QMS_M030_G> repository_MCTemp = new WebServiceRepository<MultipleContext_QMS_M030_G>();
        ObjectSerializationService obj = new ObjectSerializationService();


        #region AutoSuggest TextBox Decleration
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(QMS_M030_G_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASQualification { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASQualification
        {
            get { return _ASQualification; }
            set
            {
                if (_ASQualification != value)
                {
                    _ASQualification = value; RaisePropertyChanged("ASQualification");
                }
            }
        }

        #endregion


        #region Decleration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private QMS_M030_G _MasterEntity;
        public QMS_M030_G MasterEntity
        {
            get { return _MasterEntity; }
            set { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); }
        }

        private MultipleContext_QMS_M030_G _MC;
        public MultipleContext_QMS_M030_G MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_QMS_M030_G _MCTemp;
        public MultipleContext_QMS_M030_G MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private List<QMS_M030_G_Flip> _FlipGridData;
        public List<QMS_M030_G_Flip> FlipGridData
        {
            get { return _FlipGridData; }
            set { _FlipGridData = value; RaisePropertyChanged("FlipGridData"); }
        }

        private int _SelectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _SelectedTabControlIndex; }
            set { _SelectedTabControlIndex = value; RaisePropertyChanged("SelectedTabControlIndex"); }
        }

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private List<COM_T003> _AttachmentCollection;
        public List<COM_T003> AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set
            {
                if (_AttachmentCollection != value)
                {
                    _AttachmentCollection = value;
                    RaisePropertyChanged("AttachmentCollection");
                }
            }
        }
        #endregion

        #region Relay Command Decelaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> CmdQualification { get; private set; }
        public RelayCommand<object> CmdLoadDocumentbyDocumentNumber { get; private set; }

        #endregion

        #region Constructor
        public QMS_M030_G_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new QMS_M030_G();
            NewRecord = true;
            MC = new MultipleContext_QMS_M030_G();
            MCTemp = new MultipleContext_QMS_M030_G();
            LoadInitialData();
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            CmdQualification = new RelayCommand<object>(items => { if (items == null) { return; } InsertQualification(items); });
            CmdLoadDocumentbyDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; }
            LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
        }
        public QMS_M030_G_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new QMS_M030_G();
            NewRecord = true;
            MC = new MultipleContext_QMS_M030_G();
            MCTemp = new MultipleContext_QMS_M030_G();
            LoadInitialData();
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            CmdQualification = new RelayCommand<object>(items => { if (items == null) { return; } InsertQualification(items); });
            CmdLoadDocumentbyDocumentNumber = new RelayCommand<object>(items => {
                if (items == null) { return; }
                LoadDocumentByDocumentNumber(items, "FlipGridReference");
            });
        }
        #endregion

        #region User Defined Methods
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.t_status = "Draft";
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.valid_from = System.DateTime.Now;
        }
        private bool Validation()
        {
            //if (MasterEntity.insp_method == null || MasterEntity.insp_method =="")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("please enter Inspection Method Code...");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            if (MasterEntity.method_desc == null || MasterEntity.method_desc == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("please enter Inspection Method Name...");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_M030_G>(MC, Request, "QMS_M0004_BL", "QMS", "LoadInitialData", 0, "");

                FlipGridData = MC.BackFlipData;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                #region AutoSuggest Initialisation

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M022_P)x).qualification ?? "");
                TheFilter = (o, prefix) => (((QMS_M022_P)o).qualification ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M022_P)o).description ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASQualification = new AutoSuggestTextViewModel<dynamic>(MC.QualificationMaster, TheFilter, SuggestedValue, "inspector_qualification", true);
                ASQualification.AutoSuggestVM.IsEmptyValueAllowed = true;
                #endregion

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
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.XmlDataDocument_QMS_M030_G_Flip != null && NewRecord == true && ParameterOption1 == "Save")
                {
                    MC.BackFlipData = (List<QMS_M030_G_Flip>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M030_G_Flip, MC.BackFlipData);
                    FlipGridData.Add(MC.BackFlipData[0]);
                    DataGridCollection.Refresh();
                }
                MasterEntity.ts_code = ts_code_vm;
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
            try
            {
                string Request = "";
                QMS_M030_G_Flip ParameterEntityObject = new QMS_M030_G_Flip();

                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterObject;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_M030_G>(MCTemp, Request, "QMS_M0004_BL", "QMS", "LoadDocumentByDocumentNumber", 0, "");
                }
                else if (((IEnumerable)ParameterObject).Cast<QMS_M030_G_Flip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<QMS_M030_G_Flip>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.insp_method;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_M030_G>(MCTemp, Request, "QMS_M0004_BL", "QMS", "LoadDocumentByDocumentNumber", 0, "");
                }
                if (MCTemp.MasterEntity.Count > 0)
                {
                    MasterEntity = MCTemp.MasterEntity[0];
                }

                if (MCTemp.Attachment != null)
                {
                    AttachmentCollection = MCTemp.Attachment;
                }
                else
                {
                    MCTemp.Attachment = new List<COM_T003>();
                }
                SelectedTabControlIndex = 0;
                NewRecord = false;
                MasterEntity.ts_code = ts_code_vm;
                var msg = new NotificationMessage("QMS_M030_G_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
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
        private void InsertQualification(object InputValue)
        {
            try
            {
                string Request = "";
                QMS_M022_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.QualificationMaster.Where(x => x.qualification.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M022_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.inspector_qualification = POPUPEntityObject.qualification;
                    MasterEntity.qualiDesc = POPUPEntityObject.description;

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
        protected override void OnCreateAction(InquiryActionResult<QMS_M030_G> result)
        {
            MasterEntity = new QMS_M030_G();
            NewRecord = true;
            DefaultValues();
        }

        protected override void OnDiscardAction(InquiryActionResult<QMS_M030_G> result)
        {
            
        }

        protected override void OnDocumentAction()
        {
            try
            {
                if (!string.IsNullOrEmpty(MasterEntity.insp_method))
                {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.insp_method.Replace("/", "--"), DocumentList = MCTemp.Attachment, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
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
        protected override void OnRefreshCommand(InquiryActionResult<QMS_M030_G> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_M030_G> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_M030_G> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_M030_G> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_M030_G> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<QMS_M030_G> result)
        {
            
        }

        protected override void OnFlipAction(InquiryActionResult<QMS_M030_G> result)
        {
           
        }

        protected override void OnHelpAction(InquiryActionResult<QMS_M030_G> result)
        {
          
        }

        protected override void OnPrintAction(InquiryActionResult<QMS_M030_G> result)
        {
            
        }

        protected override void OnRemoveAction(InquiryActionResult<QMS_M030_G> result)
        {
           
        }

        protected override void OnSaveAction(InquiryActionResult<QMS_M030_G> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.editby = AppSessionState.UserID;
                    this.MasterEntity.EndEdit();

                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<QMS_M030_G>(MasterEntity, "QMS_M0004_BL", "QMS");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<QMS_M030_G>(MasterEntity, "QMS_M0004_BL", "QMS");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.insp_method != null && NewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    else if (MasterEntity.insp_method != null && NewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    NewRecord = false;
                    var msg = new NotificationMessage("QMS_M030_G_VM");
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

        #endregion

        #region Filters For DataGrid
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
            var data = obj as QMS_M030_G_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.insp_method != null && data.insp_method.ToLower().Contains(_filterString.ToLower()) ||
                            data.method_desc != null && data.method_desc.ToLower().Contains(_filterString.ToLower()) ||
                            data.version_no != null && data.version_no.ToLower().Contains(_filterString.ToLower()) ||
                            data.t_status != null && data.t_status.ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }

        
        #endregion
    }


}
