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
using System.Windows.Controls;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.QMS.ViewModels
{
    public class QMS_M0040_VM : WorkspaceViewModel<QMS_M0040>
    {
        bool NewRecord = true;

        WebServiceRepository<QMS_M0040> repository = new WebServiceRepository<QMS_M0040>();
        WebServiceRepository<MC_QMS_M0040> repository_MC = new WebServiceRepository<MC_QMS_M0040>();
        WebServiceRepository<MC_QMS_M0040> repository_MCTemp = new WebServiceRepository<MC_QMS_M0040>();
        WebServiceRepository<MC_QMS_M0040> repository_MCTemp1 = new WebServiceRepository<MC_QMS_M0040>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region Auto Suggest TextBox Decleration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(QMS_M0040_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASInspType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASInspType
        {
            get { return _ASInspType; }
            set
            {
                if (_ASInspType != value)
                {
                    _ASInspType = value; RaisePropertyChanged("ASInspType");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPlant { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPlant
        {
            get { return _ASPlant; }
            set
            {
                if (_ASPlant != value)
                {
                    _ASPlant = value; RaisePropertyChanged("ASPlant");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASItem { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItem
        {
            get { return _ASItem; }
            set
            {
                if (_ASItem != value)
                {
                    _ASItem = value; RaisePropertyChanged("ASItem");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASSampleProcedure { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSampleProcedure
        {
            get { return _ASSampleProcedure; }
            set
            {
                if (_ASSampleProcedure != value)
                {
                    _ASSampleProcedure = value; RaisePropertyChanged("ASSampleProcedure");
                }
            }
        }

        #endregion

        #region Decleration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private QMS_M0040 _MasterEntity;
        public QMS_M0040 MasterEntity
        {
            get { return _MasterEntity; }
            set { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); }
        }

        private List<ADM_M003> _PlantList = new List<ADM_M003>();
        public List<ADM_M003> PlantList
        {
            get { return _PlantList; }
            set
            {
                if (_PlantList != value)
                {
                    _PlantList = value;
                }
            }
        }

        private MC_QMS_M0040 _MC;
        public MC_QMS_M0040 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MC_QMS_M0040 _MCTemp;
        public MC_QMS_M0040 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MC_QMS_M0040 _MCTemp1;
        public MC_QMS_M0040 MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private List<QMS_M0040> _List1;
        public List<QMS_M0040> List1
        {
            get { return _List1; }
            set { _List1 = value; RaisePropertyChanged("List1"); }
        }
        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        #endregion

        #region Relay Command Decleration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> CmdInspectionType { get; private set; }
        public RelayCommand<object> CmdPlant { get; private set; }
        public RelayCommand<object> CmdItemCode { get; private set; }
        public RelayCommand<object> CmdSampleProcedure { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        #endregion

        #region Constructor
        public QMS_M0040_VM() : base()
        {
            MasterEntity = new QMS_M0040();
            MC = new MC_QMS_M0040();
            MCTemp = new MC_QMS_M0040();
            MCTemp1 = new MC_QMS_M0040();
            //MasterEntity.ItemCode = AppSessionState.TransValue.ToString();
            LoadInitialData();
            DefaultValues();
        }
        public QMS_M0040_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new QMS_M0040();
            MC = new MC_QMS_M0040();
            MCTemp = new MC_QMS_M0040();
            MCTemp1 = new MC_QMS_M0040();
            //MasterEntity.ItemCode = AppSessionState.TransValue.ToString();
            LoadInitialData();
            //DefaultValues();
        }
        public QMS_M0040_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new QMS_M0040();
            MC = new MC_QMS_M0040();
            MCTemp = new MC_QMS_M0040();
            MCTemp1 = new MC_QMS_M0040();
            MasterEntity.item_code = doc_no_vm;
            LoadInitialData();
            //DefaultValues();
        }
        #endregion

        #region User Defined Methods
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
                if (doc_no_vm != null && ts_code_vm != null && MC.MasterEntity.Count == 0)
                {
                    DefaultValues();
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
        private void LoadData(object InputValue)
        {
            try
            {
                string Request = "";
                QMS_M0040 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                    if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M0040>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity = POPUPEntityObject;
                }
                NewRecord = false;
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
        private void LoadInitialData()
        {
            try
            {
                #region Relay Command Initialization
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CmdInspectionType = new RelayCommand<object>(items => { if (items == null) { return; } InsertInspectionType(items); });
                CmdPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
                CmdItemCode = new RelayCommand<object>(items => { if (items == null) { return; } InsertItemCode(items); });
                CmdSampleProcedure = new RelayCommand<object>(items => { if (items == null) { return; } InsertSampleProcedure(items); });
                CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadData(items); });

                #endregion
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_no_vm + "!@" + doc_no_vm + "!@" + doc_no_vm;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_QMS_M0040>(MC, Request, "QMS_M0040_BL", "QMS", "LOAD_INI", 0, "");

                List1 = MC.MasterEntity;
                DataGridCollection = CollectionViewSource.GetDefaultView(List1);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                #region AutoSuggest Initialisation

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M039_P)x).insp_type ?? "");
                TheFilter = (o, prefix) => (((QMS_M039_P)o).insp_type ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M039_P)o).insp_type_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASInspType = new AutoSuggestTextViewModel<dynamic>(MC.InspType, TheFilter, SuggestedValue, "insp_type", true);
                ASInspType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode ?? "");
                TheFilter = (o, prefix) => (((ADM_M022_P)o).ItemCode ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M022_P)o).ItemName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASItem = new AutoSuggestTextViewModel<dynamic>(MC.ItemMaster, TheFilter, SuggestedValue, "ItemCode", true);
                ASItem.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M034_P)x).sp_code ?? "");
                TheFilter = (o, prefix) => (((QMS_M034_P)o).sp_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || ((QMS_M034_P)o).sp_desc.ToLower().Contains(prefix.ToString().ToLower());
                ASSampleProcedure = new AutoSuggestTextViewModel<dynamic>(MC.SampleProcedure, TheFilter, SuggestedValue, "sp_code", true);
                ASSampleProcedure.AutoSuggestVM.IsEmptyValueAllowed = true;

                var Plant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantList = (from o in Plant where o.comp_code == AppSessionState.comp_code select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id ?? "");
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASPlant = new AutoSuggestTextViewModel<dynamic>(PlantList, TheFilter, SuggestedValue, "location_Id", true);
                ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;

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
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.location_id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.valid_from = System.DateTime.Now;
            MasterEntity.active = "1";
            MasterEntity.t_status = "01";
            MasterEntity.item_code = doc_no_vm;
        }
        private bool Validation()
        {
            if (string.IsNullOrWhiteSpace(MasterEntity.insp_type))
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("please Select Inspection Type...");
                showMessageService.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.location_id))
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("please Select Plant Code...");
                showMessageService.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.item_code))
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("please Select Item Code...");
                showMessageService.ShowMessage();
                return false;
            }

            return true;
        }
        private void InsertInspectionType(object InputValue)
        {
            try
            {
                string Request = "";
                QMS_M039_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.InspType.Where(x => x.insp_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M039_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.insp_type = POPUPEntityObject.insp_type;
                    MasterEntity.t_name = POPUPEntityObject.insp_type_desc;


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
        private void InsertPlant(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;
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
                            { POPUPEntityObject = PlantList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.location_id = POPUPEntityObject.location_Id;

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
        private void InsertItemCode(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M022_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.ItemMaster.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.item_code = POPUPEntityObject.ItemCode;
                    MasterEntity.item_name = POPUPEntityObject.ItemName;

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
        private void InsertSampleProcedure(object InputValue)
        {
            try
            {
                string Request = "";
                QMS_M034_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.SampleProcedure.Where(x => x.sp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M034_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.sp_code = POPUPEntityObject.sp_code;
                    MasterEntity.sp_name = POPUPEntityObject.sp_desc;

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
                if (MasterEntity != null && NewRecord == true && ParameterOption1 == "Save")
                {
                    List1.Add(MasterEntity);
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

        #endregion

        #region Abstract Methods
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<QMS_M0040> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_M0040> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_M0040> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_M0040> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_M0040> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnSaveAction(InquiryActionResult<QMS_M0040> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.userid = AppSessionState.UserID;
                    this.MasterEntity.EndEdit();

                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<QMS_M0040>(MasterEntity, "QMS_M0040_BL", "QMS");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<QMS_M0040>(MasterEntity, "QMS_M0040_BL", "QMS");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.insp_type != null && NewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    else if (MasterEntity.insp_type != null && NewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    NewRecord = false;
                    var msg = new NotificationMessage(ts_code_vm);
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

        protected override void OnCreateAction(InquiryActionResult<QMS_M0040> result)
        {
            MasterEntity = new QMS_M0040();
            NewRecord = true;
            DefaultValues();
        }

        protected override void OnRemoveAction(InquiryActionResult<QMS_M0040> result)
        {

        }

        protected override void OnDiscardAction(InquiryActionResult<QMS_M0040> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<QMS_M0040> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<QMS_M0040> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<QMS_M0040> result)
        {

        }

        protected override void OnFevoriteAction(InquiryActionResult<QMS_M0040> result)
        {

        }

        #endregion

        #region Filters
        private string _FilterString;
        public string FilterString
        {
            get { return _FilterString; }
            set
            {
                _FilterString = value;
                RaisePropertyChanged("FilterString");
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
            var data = obj as QMS_M0040;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString))
                {
                    return (data.insp_type != null && data.insp_type.ToLower().Contains(_FilterString.ToLower()) ||
                            data.t_name != null && data.t_name.ToLower().Contains(_FilterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }

        
        #endregion

    }
}
