using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.QMS;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Common;

namespace Reflection.Modules.QMS.ViewModels
{
    public class QMS_M0034_VM : WorkspaceViewModel<QMS_M0034>
    {
        bool isNewRecord = true;

        WebServiceRepository<QMS_M0034> REPO = new WebServiceRepository<QMS_M0034>();
        WebServiceRepository<MC_QMS_M0034> REPO_MC = new WebServiceRepository<MC_QMS_M0034>();
        WebServiceRepository<MC_QMS_M0034> REPO_MC_TEMP = new WebServiceRepository<MC_QMS_M0034>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(QMS_M0034_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _AS_DEFAULT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DEFAULT
        {
            get { return _AS_DEFAULT; }
            set
            {
                if (_AS_DEFAULT != value)
                {
                    _AS_DEFAULT = value; RaisePropertyChanged("AS_DEFAULT");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_SAMPLE_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_SAMPLE_TYPE
        {
            get { return _AS_SAMPLE_TYPE; }
            set
            {
                if (_AS_SAMPLE_TYPE != value)
                {
                    _AS_SAMPLE_TYPE = value; RaisePropertyChanged("AS_SAMPLE_TYPE");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_VALUE_MODE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_VALUE_MODE
        {
            get { return _AS_VALUE_MODE; }
            set
            {
                if (_AS_VALUE_MODE != value)
                {
                    _AS_VALUE_MODE = value; RaisePropertyChanged("AS_VALUE_MODE");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_SCHEME { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_SCHEME
        {
            get { return _AS_SCHEME; }
            set
            {
                if (_AS_SCHEME != value)
                {
                    _AS_SCHEME = value; RaisePropertyChanged("AS_SCHEME");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_SEVERITY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_SEVERITY
        {
            get { return _AS_SEVERITY; }
            set
            {
                if (_AS_SEVERITY != value)
                {
                    _AS_SEVERITY = value; RaisePropertyChanged("AS_SEVERITY");
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
            try
            {
                if (dgCellInfo != null)
                {
                    var column = dgCellInfo.Column as DataGridColumn;
                    if (column != null)
                    {
                        string headerName = column.Header.ToString();
                        string SourceName = column.SortMemberPath.ToString();
                        //if (SourceName == "")
                        //{ ASDefault = ; }

                    }
                }
            }
            catch (Exception ex) { }
        }

        #endregion

        #region Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }

        #region Entities
        private QMS_M0034 _MasterEntity;
        public QMS_M0034 MasterEntity
        {
            get { return _MasterEntity; }
            set { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); }
        }
        #endregion

        private MC_QMS_M0034 _MC;
        public MC_QMS_M0034 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MC_QMS_M0034 _MC_TEMP;
        public MC_QMS_M0034 MC_TEMP
        {
            get { return _MC_TEMP; }
            set { _MC_TEMP = value; RaisePropertyChanged("MC_TEMP"); }
        }

        private STD_REQ_PARA_BE _REQ_PARA_OBJ;
        public STD_REQ_PARA_BE REQ_PARA_OBJ
        {
            get
            {
                return _REQ_PARA_OBJ;
            }
            set
            {
                if (_REQ_PARA_OBJ != value)
                {
                    _REQ_PARA_OBJ = value;
                    RaisePropertyChanged(nameof(REQ_PARA_OBJ));
                }
            }
        }


        private int _SelectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _SelectedTabControlIndex; }
            set { _SelectedTabControlIndex = value; RaisePropertyChanged("SelectedTabControlIndex"); }
        }

        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
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

        private string _visibilitty;
        public string visibilitty
        {
            get { return _visibilitty; }
            set { _visibilitty = value; RaisePropertyChanged("visibilitty"); }
        }

        private string _visibilitty1;
        public string visibilitty1
        {
            get { return _visibilitty1; }
            set { _visibilitty1 = value; RaisePropertyChanged("visibilitty1"); }
        }

        private string _visibilitty2;
        public string visibilitty2
        {
            get { return _visibilitty2; }
            set { _visibilitty2 = value; RaisePropertyChanged("visibilitty2"); }
        }

        private string _visibilitty3;
        public string visibilitty3
        {
            get { return _visibilitty3; }
            set { _visibilitty3 = value; RaisePropertyChanged("visibilitty3"); }
        }
        private bool _isTabChangeAllowed = true;
        public bool isTabChangeAllowed
        {
            get { return _isTabChangeAllowed; }
            set
            {
                if (_isTabChangeAllowed != value)
                {
                    _isTabChangeAllowed = value; RaisePropertyChanged("isTabChangeAllowed");
                }
            }
        }
        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdLoadDocument { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        public RelayCommand<object> cmdSampleType { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CmdRadiochanged { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CmdRadio1Changed { get; private set; }
        #endregion

        #region Constructor
        public QMS_M0034_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new QMS_M0034();
            MC = new MC_QMS_M0034();
            MC_TEMP = new MC_QMS_M0034();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            LoadInitialData();
            DefaultValues();
        }
        public QMS_M0034_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new QMS_M0034();
            MC = new MC_QMS_M0034();
            MC_TEMP = new MC_QMS_M0034();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            LoadInitialData();
            DefaultValues();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdLoadDocument = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
                cmdSampleType = new RelayCommand<object>(items => { if (items == null) { return; } InsertSampleType(items); });
                CmdRadiochanged = new GalaSoft.MvvmLight.Command.RelayCommand(() => { RadioButtonSelectionChanged(); });
                CmdRadio1Changed = new GalaSoft.MvvmLight.Command.RelayCommand(() => { RadioButtonSelectionChanged1(); });
                cmdLoadBackFlip = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadBackFlipData(cmdPara); });


                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id;
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_QMS_M0034>(MC, Request, "QMS_M0034_BL", "QMS", "LOAD_INI", 0, "");

                #region AutoSuggest Initialisation

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).sample_type ?? "");
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).sample_type ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_LIST_BE)o).long_text ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_SAMPLE_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.TYPE_LIST, TheFilter, SuggestedValue, "sample_type", true);
                AS_SAMPLE_TYPE.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).value_mode ?? "");
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).value_mode ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_LIST_BE)o).long_text ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_VALUE_MODE = new AutoSuggestTextViewModel<dynamic>(MC.VALUE_LIST, TheFilter, SuggestedValue, "value_mode", true);
                AS_VALUE_MODE.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).scheme ?? "");
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).scheme ?? "").ToLower().Contains(prefix.ToString().ToLower()) || ((STD_LIST_BE)o).long_text.ToLower().Contains(prefix.ToString().ToLower());
                AS_SCHEME = new AutoSuggestTextViewModel<dynamic>(MC.PARA_TYPE_LIST, TheFilter, SuggestedValue, "scheme", true);
                AS_SCHEME.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).severity ?? "");
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).severity ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_LIST_BE)o).short_text ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_SEVERITY = new AutoSuggestTextViewModel<dynamic>(MC.KEY_DATA_LIST, TheFilter, SuggestedValue, "severity", true);
                AS_SEVERITY.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion
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
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.location_id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.active = "1";
            MasterEntity.t_status = "01";
        }
        private void RadioButtonSelectionChanged()
        {
            if(MasterEntity.x1 == true)
            {
                MasterEntity.ind_insp_point = "A";
                MasterEntity.x2 = false;
                MasterEntity.x3 = false;
                MasterEntity.x4 = false;
            }
            else if(MasterEntity.x2 == true)
            {
                MasterEntity.ind_insp_point = "B";
                MasterEntity.x1 = false;
                MasterEntity.x3 = false;
                MasterEntity.x4 = false;
            }
            else if(MasterEntity.x3 ==true)
            {
                MasterEntity.ind_insp_point = "C";
                MasterEntity.x1 = false;
                MasterEntity.x2 = false;
                MasterEntity.x4 = false;
            }
            else if(MasterEntity.x4 == true)
            {
                MasterEntity.ind_insp_point = "D";
                MasterEntity.x1 = false;
                MasterEntity.x2 = false;
                MasterEntity.x3 = false;
            }
        }
        private void RadioButtonSelectionChanged1()
        {
            if (MasterEntity.r1 == true)
            {
                MasterEntity.multi_sample = "MS";
                MasterEntity.r2 = false;
                MasterEntity.r3 = false;
            }
            else if (MasterEntity.r2 == true)
            {
                MasterEntity.multi_sample = "IMS";
                MasterEntity.r1 = false;
                MasterEntity.r3 = false;
            }
            else if(MasterEntity.r3 == true)
            {
                MasterEntity.multi_sample = "DMS";
                MasterEntity.r1 = false;
                MasterEntity.r2 = false;
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
        private void Method()
        {
            if(MasterEntity.multi_sample == "MS")
            {
                MasterEntity.r1 = true;
                MasterEntity.r2 = false;
                MasterEntity.r3 = false;
            }
            else if(MasterEntity.multi_sample == "IMS")
            {
                MasterEntity.r1 = false;
                MasterEntity.r2 = true;
                MasterEntity.r3 = false;
            }
            else if(MasterEntity.multi_sample == "DMS")
            {
                MasterEntity.r1 = false;
                MasterEntity.r2 = false;
                MasterEntity.r3 = true;
            }

            if(MasterEntity.ind_insp_point == "A")
            {
                MasterEntity.x1 = true;
                MasterEntity.x2 = false;
                MasterEntity.x3 = false;
                MasterEntity.x4 = false;
            }
            else if(MasterEntity.ind_insp_point == "B")
            {
                MasterEntity.x1 = false;
                MasterEntity.x2 = true;
                MasterEntity.x3 = false;
                MasterEntity.x4 = false;
            }
            else if(MasterEntity.ind_insp_point == "C")
            {
                MasterEntity.x1 = false;
                MasterEntity.x2 = false;
                MasterEntity.x3 = true;
                MasterEntity.x4 = false;
            }
            else if(MasterEntity.ind_insp_point =="D")
            {
                MasterEntity.x1 = false;
                MasterEntity.x2 = false;
                MasterEntity.x3 = false;
                MasterEntity.x4 = true;
            }
        }
        private void InsertSampleType(object InputValue)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.TYPE_LIST.Where(x => x.sample_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.sample_type = POPUPEntityObject.sample_type;
                    MasterEntity.sp_type_desc = POPUPEntityObject.long_text;

                    if (MasterEntity.sample_type == "SAM001") // for Sample Type "100% Inspection"
                    {
                        visibilitty = "Visible";//for valuation Mode
                        visibilitty1 = "Collapsed";// for sample size & acceptance no
                        visibilitty2 = "Collapsed";//for severity & AQL Value And Sample Scheme
                        visibilitty3 = "Collapsed";//for Determination rule
                    }
                    else if (MasterEntity.sample_type == "SAM002")// for Sample Type "Fixed Sample"
                    {
                        visibilitty = "Visible";
                        visibilitty1 = "Visible";
                        visibilitty2 = "Collapsed";
                        visibilitty3 = "Visible";
                    }
                    else if (MasterEntity.sample_type == "SAM003")// for Sample Type "Percentage Sample"
                    {
                        visibilitty = "Visible";
                        visibilitty1 = "Collapsed";
                        visibilitty2 = "Visible";
                        visibilitty3 = "Visible";

                    }
                    else if (MasterEntity.sample_type == "SAM004")// for Sample Type "Sampling Scheme"
                    {     
                        visibilitty = "Visible";
                        visibilitty1 = "Visible";
                        visibilitty2 = "Collapsed";
                        visibilitty3 = "Visible";
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
        

        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                STD_LIST_BE ParameterEntityObject = new STD_LIST_BE();

                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    Request = "LOAD_DOCUMENT" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + ParameterObject;
                    MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_QMS_M0034>(MC_TEMP, Request, "QMS_M0034_BL", "QMS", "LOAD_DOCUMENT", 0, "");
                }
                else if (((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList()[0];
                    Request = "LOAD_DOCUMENT" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + ParameterEntityObject.sp_code;
                    MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_QMS_M0034>(MC_TEMP, Request, "QMS_M0034_BL", "QMS", "LOAD_DOCUMENT", 0, "");
                }
                if (MC_TEMP.MASTER_LIST.Count > 0)
                {
                    MasterEntity = MC_TEMP.MASTER_LIST[0];
                }

                if (MC_TEMP.ATTACHMENT_LIST != null)
                {
                    AttachmentCollection = MC_TEMP.ATTACHMENT_LIST;
                }
                else
                {
                    MC_TEMP.ATTACHMENT_LIST = new List<COM_T003>();
                }
                SelectedTabControlIndex = 0;
                isNewRecord = false;
                Method();
                MasterEntity.ts_code = ts_code_vm;
                var msg = new NotificationMessage(ts_code_vm);
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
        private bool Validation()
        {
            //if (MasterEntity.sp_code == null)
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("please enter sample Procedure Code...");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            return true;
        }
        private void LoadBackFlipData(object Parameter)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (REQ_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + (REQ_PARA_OBJ.active_code ?? "") + "!@" + (REQ_PARA_OBJ.t_status ?? "") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy");
                MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_QMS_M0034>(MC_TEMP, Request, "QMS_M0034_BL", "QMS", "LOAD_BACKFLIP", 0, "");

                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC_TEMP.BACK_FLIP_LIST.ToList());
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(FLTR_BACKFLIP);

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            { 
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); 
            }
        }
        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<QMS_M0034> result)
        {
            MasterEntity = new QMS_M0034();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            isNewRecord = true;
            DefaultValues();
        }

        protected override void OnDiscardAction(InquiryActionResult<QMS_M0034> result)
        {

        }

        protected override void OnDocumentAction()
        {
            try
            {
                if (!string.IsNullOrEmpty(MasterEntity.sp_code))
                {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.sp_code.Replace("/", "--"), DocumentList = MC_TEMP.ATTACHMENT_LIST });
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
        protected override void OnRefreshCommand(InquiryActionResult<QMS_M0034> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_M0034> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_M0034> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_M0034> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_M0034> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<QMS_M0034> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<QMS_M0034> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<QMS_M0034> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<QMS_M0034> result)
        {

        }

        protected override void OnRemoveAction(InquiryActionResult<QMS_M0034> result)
        {

        }

        protected override void OnSaveAction(InquiryActionResult<QMS_M0034> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.userid = AppSessionState.UserID;
                    this.MasterEntity.EndEdit();

                    if (isNewRecord == true)
                    {
                        MasterEntity = REPO.SaveWithReturnDomainObject<QMS_M0034>(MasterEntity, "QMS_M0034_BL", "QMS");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = REPO.UpdateWithReturnDomainObject<QMS_M0034>(MasterEntity, "QMS_M0034_BL", "QMS");
                    }

                    if (MasterEntity.sp_code != null && isNewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    else if (MasterEntity.sp_code != null && isNewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    isNewRecord = false;
                    Method();
                    var msg = new NotificationMessage("QMS_M0034_VM");
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

        #region Filter For Flip Grid
        private string _FLTR_STR_BACKFLIP;
        public string FLTR_STR_BACKFLIP
        {
            get { return _FLTR_STR_BACKFLIP; }
            set
            {
                _FLTR_STR_BACKFLIP = value;
                RaisePropertyChanged("FLTR_STR_BACKFLIP");
                FLTR_COLL_BACKFLIP();
            }
        }
        private void FLTR_COLL_BACKFLIP()
        {
            if (_BACKFLIP_COLLECTION != null)
            {
                _BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool FLTR_BACKFLIP(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FLTR_STR_BACKFLIP))
                {
                    return (data.sample_type != null && data.sample_type.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.sp_code != null && data.sp_code.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.short_text != null && data.short_text.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.value_mode != null && data.value_mode.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.t_status != null && data.t_status.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.scheme != null && data.scheme.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters

     

        #endregion

    }
}
