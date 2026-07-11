using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using Reflection.Presentation.Services;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity.QMS;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using System.Windows;
using System.Collections.Specialized;
using Reflection.Presentation.Services.Convertors;
using System.Reflection;
using Reflection.Presentation.Core.VirtualDesktops;
using GalaSoft.MvvmLight.Ioc;
using System.IO;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.QMS.ViewModels
{
    public class QMS_T003_DR_VM : WorkspaceViewModel<QMS_T003_A>
    {
        #region Variables Declaration
        WebServiceRepository<QMS_T003> repository = new WebServiceRepository<QMS_T003>();
        WebServiceRepository<MC_QMS_T003> repository_MC = new WebServiceRepository<MC_QMS_T003>();
        ObjectSerializationService obj = new ObjectSerializationService();
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }
        public string defect_level_vm { get; set; }
        public string defect_level_value_text { get; set; }
        private bool _isNewRecord;
        public bool isNewRecord
        {
            get { return _isNewRecord; }
            set
            {
                if (_isNewRecord != value)
                {
                    _isNewRecord = value;
                    RaisePropertyChanged("isNewRecord");
                }
            }
        }

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
        private string _defect_level_value;
        public string defect_level_value
        {
            get
            {
                return _defect_level_value;
            }
            set
            {
                if (_defect_level_value != value)
                {
                    _defect_level_value = value;
                    RaisePropertyChanged("defect_level_value");
                }
            }
        }
        private string _defect_level_label;
        public string defect_level_label
        {
            get
            {
                return _defect_level_label;
            }
            set
            {
                if (_defect_level_label != value)
                {
                    _defect_level_label = value;
                    RaisePropertyChanged("defect_level_label");
                }
            }
        }
        private int _dgSelectedIndexDefect;
        public int dgSelectedIndexDefect
        {
            get
            {
                return _dgSelectedIndexDefect;
            }
            set
            {
                if (_dgSelectedIndexDefect != value)
                {
                    _dgSelectedIndexDefect = value;
                    RaisePropertyChanged("dgSelectedIndexDefect");
                }
            }
        }
        private QMS_T003_A _SelectedCharEntityRR;
        public QMS_T003_A SelectedCharEntityRR
        {
            get
            {
                return _SelectedCharEntityRR;
            }
            set
            {
                if (_SelectedCharEntityRR != value)
                {
                    _SelectedCharEntityRR = value;
                    RaisePropertyChanged(nameof(SelectedCharEntityRR));
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

        private ObservableCollection<QMS_T003_N> _DREntityCollection;
        public ObservableCollection<QMS_T003_N> DREntityCollection
        {
            get
            {
                return _DREntityCollection;
            }
            set
            {
                if (_DREntityCollection != value)
                {
                    _DREntityCollection = value;
                    RaisePropertyChanged("DREntityCollection");
                }
            }
        }

        private List<Classification> _ParaValueList;
        public List<Classification> ParaValueList
        {
            get
            {
                return _ParaValueList;
            }
            set
            {
                if (_ParaValueList != value)
                {
                    _ParaValueList = value;
                    RaisePropertyChanged("ParaValueList");
                }
            }
        }

        #endregion
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(QMS_T003_DR_VM));
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
        private AutoSuggestTextViewModel<dynamic> _ASPara_Value { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPara_Value
        {
            get { return _ASPara_Value; }
            set
            {
                if (_ASPara_Value != value)
                {
                    _ASPara_Value = value; RaisePropertyChanged("ASPara_Value");
                }
            }
        }


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
                    if (SourceName == "value_code" && dgSelectedIndexDefect >= 0)
                    {
                        //SuggestedValue = new ValueConverter(x => x == null ? "" : ((Classification)x).value_code);
                        //TheFilter = (o, prefix) => (((Classification)o).value_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((Classification)o).para_value ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        //ASPara_Value = new AutoSuggestTextViewModel<dynamic>(MC.Profile_Values, TheFilter, SuggestedValue, "value_code", "value_code", true);
                        //ASPara_Value.AutoSuggestVM.IsEmptyValueAllowed = true;
                        //ASPara_Value.AutoSuggestVM.IsFreeTextAllowed = true;
                        ASDefault = ASPara_Value;
                    }
                }
            }
        }

        private ICollectionView _SingleResultCollectionFilter;
        // This DataGridView filter Schedule Lines for selected item. it will show only schedule for selected item.
        public ICollectionView SingleResultCollectionFilter
        {
            get { return _SingleResultCollectionFilter; }
            set { _SingleResultCollectionFilter = value; RaisePropertyChanged("SingleResultCollectionFilter"); }
        }
        #endregion
        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdSelectionChanged { get; private set; }
        public RelayCommand<object> cmdInspection_Processing_DR { get; private set; }


        #endregion
        #region Constructor
        public QMS_T003_DR_VM(string ts_code, QMS_T003 lot_info, string defect_level) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = lot_info.doc_no;
            this.defect_level_vm = defect_level;
            SelectedCharEntityRR = new QMS_T003_A();
            MasterEntity = new QMS_T003();
            MasterEntity = lot_info;
            MasterEntity.ts_code = ts_code_vm;
            ParaValueList = new List<Classification>();
            MC = new MC_QMS_T003();
            DREntityCollection = new ObservableCollection<QMS_T003_N>();
            QMS_T003_N.ModelEntityUpdated += new EventHandler(ModelUpdated_QMS_T003_N);
            CommandInitialization();
        }
        public QMS_T003_DR_VM(string ts_code, QMS_T003 lot_info, string defect_level, QMS_T003_A char_info) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = lot_info.doc_no;
            this.defect_level_vm = defect_level;
            SelectedCharEntityRR = new QMS_T003_A();
            SelectedCharEntityRR = char_info;
            MasterEntity = new QMS_T003();
            MasterEntity = lot_info;
            MasterEntity.ts_code = ts_code_vm;
            ParaValueList = new List<Classification>();
            MC = new MC_QMS_T003();
            DREntityCollection = new ObservableCollection<QMS_T003_N>();
            QMS_T003_N.ModelEntityUpdated += new EventHandler(ModelUpdated_QMS_T003_N);
            CommandInitialization();
        }
        #endregion
        #region Default Functions
        void ModelUpdated_QMS_T003_N(object sender, EventArgs e)
        {
            try
            {
                Classification POPUPEntityObject = null;
                string InputValue;
                if (sender.ToString() == "value_code" && dgSelectedIndexDefect >= 0)
                {
                    InputValue = DREntityCollection[dgSelectedIndexDefect].value_code;
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        if (InputValue.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.CLASS_PROFILE_LIST.Where(x => x.para_value.Equals(InputValue, StringComparison.OrdinalIgnoreCase) == true || x.value_code.Equals(InputValue, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<Classification>().ToList()[0];
                    }
                    if (POPUPEntityObject != null)
                    {
                        DREntityCollection[dgSelectedIndexDefect].defect_level = defect_level_vm;
                        DREntityCollection[dgSelectedIndexDefect].para_value = POPUPEntityObject.para_value;
                        DREntityCollection[dgSelectedIndexDefect].def_class_name = POPUPEntityObject.def_class_name;
                        DREntityCollection[dgSelectedIndexDefect].defect_class = POPUPEntityObject.def_class;
                        DREntityCollection[dgSelectedIndexDefect].para_name = POPUPEntityObject.para_name;
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>(); showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        private void DefaultValues()
        {
            if (defect_level_vm == "C")
            {
                defect_level_label = "Charactoristic";
                defect_level_value = SelectedCharEntityRR.char_code;
                defect_level_value_text = SelectedCharEntityRR.char_name;
            }
            else if (defect_level_vm == "L")
            {
                defect_level_label = "Inspection Lot";
                defect_level_value = MasterEntity.doc_no;
            }
            else if (defect_level_vm == "O")
            {
                defect_level_label = "Operation";
                defect_level_value = SelectedCharEntityRR.op_no;
                defect_level_value_text = SelectedCharEntityRR.op_name;
            }
        }
        private void Logging()
        {
            MasterEntity.ts_code = this.ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;

            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private void CommandInitialization()
        {
            CursorControl.SetBusyState();
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdSelectionChanged = new RelayCommand<object>(items => { if (items == null) { return; } DataGridRowSelectionChanged(items); });
            cmdInspection_Processing_DR = new RelayCommand<object>(items => { if (items == null) { return; } Inspection_Processing_DR_Call(items); });
        }
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "LoadInitialData_DR" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_id + "!@" + doc_no_vm + "!@" + defect_level_vm + "!@" + defect_level_value + "!@" + MasterEntity.plan_no;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_QMS_T003>(MC, Request, "InspectionLot_Process", "QMS", "LoadDocumentByDocumentNumber", 0, "");

                //ParaValueList = MC.Profile_Values.Where(x => x.value_code == DREntityCollection[dgSelectedIndexDefect].value_code).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((Classification)x).value_code);
                TheFilter = (o, prefix) => (((Classification)o).value_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((Classification)o).para_value ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPara_Value = new AutoSuggestTextViewModel<dynamic>(MC.CLASS_PROFILE_LIST, TheFilter, SuggestedValue, "value_code", "value_code", true);
                ASPara_Value.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASPara_Value.AutoSuggestVM.IsFreeTextAllowed = false;
                ASDefault = ASPara_Value;

                DREntityCollection = MC.DEFECT_RR;



                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadInitialData();
                    DefaultValues();
                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
        private void DataGridRowSelectionChanged(object InputValue)
        {

        }
        private void OpenDocumentViewer(object InputValue)
        {
            WebServiceRepository<MultipleContext_Attachments> repository_MCAttachments = new WebServiceRepository<MultipleContext_Attachments>();
            List<COM_T003> Attachments = new List<COM_T003>();
            QMS_T003_A EntityObjectParameter = new QMS_T003_A();
            MultipleContext_Attachments MCAttachments = new MultipleContext_Attachments();
            try
            {
                string Request = "GetAllFiles" + "!@" + doc_no_vm;
                //MCAttachments = repository_MCAttachments.GetData<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Reflection.BusinessLogic.ReflectionFileHandlingServices");
                MCAttachments = repository_MCAttachments.GetDataWithReturnDomainObject<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                if (!string.IsNullOrEmpty(doc_no_vm))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = doc_no_vm.Replace("/", "--"), DocumentList = MCAttachments.Attachments });
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
                    Logging();
                    MasterEntity.XDOC_N = obj.ObjectToXML(DREntityCollection);

                    QMS_T003 MasterEntityTemp = repository.SaveWithReturnDomainObject<QMS_T003>(MasterEntity, "InspectionLot_Process_DR", "QMS");
                    if (MasterEntityTemp.XDOC_N != null)
                    {
                        DREntityCollection = (ObservableCollection<QMS_T003_N>)new ObjectSerializationService().XMLToObject(MasterEntityTemp.XDOC_N, DREntityCollection);
                    }
                    else
                    {
                        DREntityCollection = new ObservableCollection<QMS_T003_N>();
                    }
                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

       

        #endregion
    }
}
