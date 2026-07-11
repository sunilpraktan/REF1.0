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
    class QMS_M030_I_VM : WorkspaceViewModel<QMS_M030_I>
    {
        bool NewRecord = true;

        WebServiceRepository<QMS_M030_I> repository = new WebServiceRepository<QMS_M030_I>();
        WebServiceRepository<MultipleContext_QMS_M030_I> repository_MC = new WebServiceRepository<MultipleContext_QMS_M030_I>();
        WebServiceRepository<MultipleContext_QMS_M030_I> repository_MCTemp = new WebServiceRepository<MultipleContext_QMS_M030_I>();
        WebServiceRepository<MultipleContext_QMS_M030_I> repository_MCTemp1 = new WebServiceRepository<MultipleContext_QMS_M030_I>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest Initialization
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(QMS_M030_I_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASQuali { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASQuali
        {
            get { return _ASQuali; }
            set
            {
                if (_ASQuali != value)
                {
                    _ASQuali = value; RaisePropertyChanged("ASQuali");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUnit
        {
            get { return _ASUnit; }
            set
            {
                if (_ASUnit != value)
                {
                    _ASUnit = value; RaisePropertyChanged("ASUnit");
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

        #endregion

        #region Relay Command Decleration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocNo { get; private set; }
        public RelayCommand<object> CmdQualification { get; private set; }
        public RelayCommand<object> CmdUnit { get; private set; }
        public RelayCommand<object> CmdPlant { get; private set; }
        public RelayCommand<object> CmdCharType { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CmdRadiochanged { get; set; }
        #endregion

        #region Variable Decleration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private QMS_M030_I _MasterEntity;
        public QMS_M030_I MasterEntity
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

        private List<QMS_M030_I_Flip> _FlipGridData;
        public List<QMS_M030_I_Flip> FlipGridData
        {
            get { return _FlipGridData; }
            set { _FlipGridData = value; RaisePropertyChanged("FlipGridData"); }
        }


        private MultipleContext_QMS_M030_I _MC;
        public MultipleContext_QMS_M030_I MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_QMS_M030_I _MCTemp;
        public MultipleContext_QMS_M030_I MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_QMS_M030_I _MCTemp1;
        public MultipleContext_QMS_M030_I MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
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

        private string _visibilityFlag;
        public string visibilityFlag
        {
            get
            {
                return _visibilityFlag;
            }
            set
            {
                if (_visibilityFlag != value)
                {
                    _visibilityFlag = value;
                    RaisePropertyChanged(nameof(visibilityFlag));
                }
            }
        }

        private string _visibilityFlag1;
        public string visibilityFlag1
        {
            get
            {
                return _visibilityFlag1;
            }
            set
            {
                if (_visibilityFlag1 != value)
                {
                    _visibilityFlag1 = value;
                    RaisePropertyChanged(nameof(visibilityFlag1));
                }
            }
        }
        #endregion

        #region Constructor
        public QMS_M030_I_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new QMS_M030_I();
            MC = new MultipleContext_QMS_M030_I();
            MCTemp = new MultipleContext_QMS_M030_I();
            MCTemp1 = new MultipleContext_QMS_M030_I();
            LoadInitialData();
            DefaultValues();
        }
        public QMS_M030_I_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new QMS_M030_I();
            MC = new MultipleContext_QMS_M030_I();
            MCTemp = new MultipleContext_QMS_M030_I();
            MCTemp1 = new MultipleContext_QMS_M030_I();
            LoadInitialData();
            DefaultValues();
        }

        #endregion

        #region User Defined Methods
        private void DefaultValues()
        {
            MasterEntity.active = true;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;
            MasterEntity.from_date = System.DateTime.Now;
            MasterEntity.doc_date = System.DateTime.Now;
            MasterEntity.t_status = "Draft";

        }
        private bool Validation()
        {

            //if (MasterEntity.insp_char == null || MasterEntity.insp_char == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Inspection Characteristics Code...");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            if (MasterEntity.from_date == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Valid From Date...");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.insp_char_location == null || MasterEntity.insp_char_location == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Plant Code...");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.insp_char_type == null || MasterEntity.insp_char_type == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Char. Type...");
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
                CmdUnit = new RelayCommand<object>(items => { if (items == null) { return; } InsertUnit(items); });
                CmdQualification = new RelayCommand<object>(items => { if (items == null) { return; } InsertQualification(items); });
                CmdPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
                CmdCharType = new RelayCommand<object>(items => { if (items == null) { return; } ComboSelectionChanged(items); });
                CmdRadiochanged = new GalaSoft.MvvmLight.Command.RelayCommand(() => { RadioButtonSelectionChanged(); });
                #endregion
                string Request = "LoadInitialData" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_M030_I>(MC, Request, "MasterInspectionCharacteristics", "QMS", "LoadInitialData", 0, "");

                FlipGridData = MC.BackFlipData;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                #region AutoSuggest Initalization
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M022_P)x).qualification ?? "");
                TheFilter = (o, prefix) => (((QMS_M022_P)o).qualification ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M022_P)o).description ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASQuali = new AutoSuggestTextViewModel<dynamic>(MC.QualiMaster, TheFilter, SuggestedValue, "inspector_qualifiction", true);
                ASQuali.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitMaster, TheFilter, SuggestedValue, "uom_quantitative", true);
                ASUnit.AutoSuggestVM.IsEmptyValueAllowed = true;


                List<ADM_M003> Plant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantList = (from o in Plant where o.comp_code == AppSessionState.comp_code select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id ?? "");
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASPlant = new AutoSuggestTextViewModel<dynamic>(PlantList, TheFilter, SuggestedValue, "location_Id", true);
                ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;
                #endregion
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
        private void RadioButtonSelectionChanged()
        {
            if (MasterEntity.x1 == true)
            {
                MasterEntity.value1 = "A";
            }
            else if (MasterEntity.x2 == true)
            {
                MasterEntity.value1 = "B";
            }
            else if (MasterEntity.x3 == true)
            {
                MasterEntity.value1 = "C";
            }
            else if (MasterEntity.x4 == true)
            {
                MasterEntity.value1 = "D";
            }

            if (MasterEntity.m1 == true)
            {
                MasterEntity.value2 = "M";
            }
            else if (MasterEntity.m2 == true)
            {
                MasterEntity.value2 = "N";
            }
            else if (MasterEntity.m3 == true)
            {
                MasterEntity.value2 = "O";
            }

            if (MasterEntity.a1 == true)
            {
                MasterEntity.ind_value11 = "P";
            }
            else if (MasterEntity.a2 == true)
            {
                MasterEntity.ind_value11 = "Q";
            }
            else if (MasterEntity.a3 == true)
            {
                MasterEntity.ind_value11 = "R";
            }
            else if (MasterEntity.a4 == true)
            {
                MasterEntity.ind_value11 = "S";
            }
        }

        private void SetValues()
        {
            if (MasterEntity.value1 == "A")
            {
                MasterEntity.x1 = true;
                MasterEntity.x2 = false;
                MasterEntity.x3 = false;
                MasterEntity.x4 = false;
            }
            else if (MasterEntity.value1 == "B")
            {
                MasterEntity.x1 = false;
                MasterEntity.x2 = true;
                MasterEntity.x3 = false;
                MasterEntity.x4 = false;
            }
            else if (MasterEntity.value1 == "C")
            {
                MasterEntity.x1 = false;
                MasterEntity.x2 = false;
                MasterEntity.x3 = true;
                MasterEntity.x4 = false;
            }
            else if (MasterEntity.value1 == "D")
            {
                MasterEntity.x1 = false;
                MasterEntity.x2 = false;
                MasterEntity.x3 = false;
                MasterEntity.x4 = true;
            }

            if (MasterEntity.value2 == "M")
            {
                MasterEntity.m1 = true;
                MasterEntity.m2 = false;
                MasterEntity.m3 = false;
            }
            else if (MasterEntity.value2 == "N")
            {
                MasterEntity.m1 = false;
                MasterEntity.m2 = true;
                MasterEntity.m3 = false;
            }
            else if (MasterEntity.value2 == "O")
            {
                MasterEntity.m1 = false;
                MasterEntity.m2 = false;
                MasterEntity.m3 = true;
            }

            if (MasterEntity.ind_value11 == "P")
            {
                MasterEntity.a1 = true;
                MasterEntity.a2 = false;
                MasterEntity.a3 = false;
                MasterEntity.a4 = false;
            }
            else if (MasterEntity.ind_value11 == "Q")
            {
                MasterEntity.a1 = false;
                MasterEntity.a2 = true;
                MasterEntity.a3 = false;
                MasterEntity.a4 = false;
            }
            else if (MasterEntity.ind_value11 == "R")
            {
                MasterEntity.a1 = false;
                MasterEntity.a2 = false;
                MasterEntity.a3 = true;
                MasterEntity.a4 = false;
            }
            else if (MasterEntity.ind_value11 == "S")
            {
                MasterEntity.a1 = false;
                MasterEntity.a2 = false;
                MasterEntity.a3 = false;
                MasterEntity.a4 = true;
            }

            if (MasterEntity.insp_char_type == "Quantitative")
            {
                visibilityFlag = "Visible";
                visibilityFlag1 = "Visible";
            }
            else if (MasterEntity.insp_char_type == "Qualitative")
            {
                visibilityFlag = "Collapsed";
                visibilityFlag1 = "Visible";
            }

        }
        private void ComboSelectionChanged(object InputValue)
        {
            if (MasterEntity.insp_char_type == "Quantitative")
            {
                visibilityFlag = "Visible";
                visibilityFlag1 = "Visible";
            }
            else if (MasterEntity.insp_char_type == "Qualitative")
            {
                visibilityFlag = "Collapsed";
                visibilityFlag1 = "Visible";
            }
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MasterEntity.XmlDataDocument_QMS_M030_I_Flip != null && NewRecord == true && ParameterOption1 == "Save")
            {
                MC.BackFlipData = (List<QMS_M030_I_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_QMS_M030_I_Flip, MC.BackFlipData);
                FlipGridData.Add(MC.BackFlipData[0]);
                DataGridCollection.Refresh();
                DataGridCollection.SortDescriptions.Add(new SortDescription("insp_char", ListSortDirection.Descending));
            }
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            QMS_M030_I_Flip ParameterEntityObject = null;

            if (((IEnumerable)ParameterObject).Cast<QMS_M030_I_Flip>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<QMS_M030_I_Flip>().ToList()[0];
                Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.insp_char;
                NewRecord = false;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_QMS_M030_I>(MCTemp, Request, "MasterInspectionCharacteristics", "QMS", "LoadDocumentByDocumentNumber", 0, "");

                if (MCTemp.MasterEntity.Count > 0)
                {
                    MasterEntity = MCTemp.MasterEntity[0];
                }

            }
            SetValues();
            ReadOnlyFlag = true;
            SelectedTabControlIndex = 0;
            var msg = new NotificationMessage("QMS_M030_I_VM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        private void InsertQualification(object InputValue)
        {
            string Request = "";
            QMS_M022_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.QualiMaster.Where(x => x.qualification.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M022_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M022_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.inspector_qualification = POPUPEntityObject.qualification;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertUnit(object InputValue)
        {
            string Request = "";
            ADM_M038_B_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitMaster.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.uom_quantitative = POPUPEntityObject.unit_code;
                }
            }
            catch (Exception ex) { }
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
        private void InsertPlant(object InputValue)
        {
            string Request = "";
            ADM_M003 POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = PlantList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M003>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.insp_char_location = POPUPEntityObject.location_Id;
                }
            }
            catch (Exception ex) { }
        }
        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<QMS_M030_I> result)
        {
            MasterEntity = new QMS_M030_I();
            DefaultValues();
            ReadOnlyFlag = false;
            NewRecord = true;
            visibilityFlag = "Visible";
            visibilityFlag1 = "Visible";
            var msg = new NotificationMessage("QMS_M030_I_VM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }

        protected override void OnDiscardAction(InquiryActionResult<QMS_M030_I> result)
        {
            ReadOnlyFlag = false;
        }

        protected override void OnDocumentAction()
        {
            ReadOnlyFlag = false;
        }

        protected override void OnFevoriteAction(InquiryActionResult<QMS_M030_I> result)
        {
            ReadOnlyFlag = false;
        }

        protected override void OnFlipAction(InquiryActionResult<QMS_M030_I> result)
        {
            ReadOnlyFlag = false;
        }

        protected override void OnHelpAction(InquiryActionResult<QMS_M030_I> result)
        {
            ReadOnlyFlag = false;
        }

        protected override void OnPrintAction(InquiryActionResult<QMS_M030_I> result)
        {
            ReadOnlyFlag = false;
        }

        protected override void OnRemoveAction(InquiryActionResult<QMS_M030_I> result)
        {
            ReadOnlyFlag = false;
        }

        protected override void OnSaveAction(InquiryActionResult<QMS_M030_I> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.editby = AppSessionState.UserID;
                    this.MasterEntity.EndEdit();

                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<QMS_M030_I>(MasterEntity, "MasterInspectionCharacteristics", "QMS");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<QMS_M030_I>(MasterEntity, "MasterInspectionCharacteristics", "QMS");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Data Saved Successfully");
                    showMessageService.ShowMessage();
                    NewRecord = false;
                    ReadOnlyFlag = true;
                    SetValues();
                    var msg = new NotificationMessage("QMS_M030_I_VM");
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
        protected override void OnRefreshCommand(InquiryActionResult<QMS_M030_I> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_M030_I> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_M030_I> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_M030_I> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_M030_I> result)
        {
            throw new NotImplementedException();
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
            var data = obj as QMS_M030_I_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.insp_char != null && data.insp_char.ToLower().Contains(_filterString.ToLower()) ||
                            data.char_desc != null && data.char_desc.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.insp_char_type != null && data.insp_char_type.ToString().Contains(_filterString.ToLower()) ||
                            data.lower_limit != null && data.lower_limit.ToString().Contains(_filterString.ToLower()) ||
                            data.upp_limit != null && data.upp_limit.ToString().Contains(_filterString.ToLower()) ||
                            data.t_status != null && data.t_status.ToLower().Contains(_filterString.ToLower())
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
