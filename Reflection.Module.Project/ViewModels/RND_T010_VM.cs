using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity.ProjectManagement;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using System.Windows;
using Reflection.BusinessEntity;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.Project.ViewModels
{
    public class RND_T010_VM : WorkspaceViewModel<RND_T010_B> 
    {
        bool isNewRecord = true;
        WebServiceRepository<RND_T010_B> repository = new WebServiceRepository<RND_T010_B>();
        WebServiceRepository<MultipleContext_RND_T010> repository_MC = new WebServiceRepository<MultipleContext_RND_T010>();
        WebServiceRepository<MultipleContext_RND_T010> repository_MCTemp = new WebServiceRepository<MultipleContext_RND_T010>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(RND_T010_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _ASTestBedNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTestBedNo
        {
            get { return _ASTestBedNo; }
            set
            {
                if (_ASTestBedNo != value)
                {
                    _ASTestBedNo = value; RaisePropertyChanged("ASTestBedNo");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASProject { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASProject
        {
            get { return _ASProject; }
            set
            {
                if (_ASProject != value)
                {
                    _ASProject = value; RaisePropertyChanged("ASProject");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASEngineModel { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASEngineModel
        {
            get { return _ASEngineModel; }
            set
            {
                if (_ASEngineModel != value)
                {
                    _ASEngineModel = value; RaisePropertyChanged("ASEngineModel");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASEngineNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASEngineNo
        {
            get { return _ASEngineNo; }
            set
            {
                if (_ASEngineNo != value)
                {
                    _ASEngineNo = value; RaisePropertyChanged("ASEngineNo");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASTestType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTestType
        {
            get { return _ASTestType; }
            set
            {
                if (_ASTestType != value)
                {
                    _ASTestType = value; RaisePropertyChanged("ASTestType");
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
                    //if (SourceName == "entry_no")
                    //{ ASDefault = ASDatagridItem; }
                }
            }
        }

        #endregion

        #region Declarations
        
        private MultipleContext_RND_T010 _MC;
        public MultipleContext_RND_T010 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_RND_T010 _MCTemp;
        public MultipleContext_RND_T010 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_RND_T010 _MCTemp1;
        public MultipleContext_RND_T010 MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private RND_T010_B _MasterEntity;
        public RND_T010_B MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }        

        private int _dgSelectedIndexDashBoard;
        public int dgSelectedIndexDashBoard
        {
            get
            { return _dgSelectedIndexDashBoard; }
            set
            {
                if (_dgSelectedIndexDashBoard != value)
                {
                    _dgSelectedIndexDashBoard = value;
                    RaisePropertyChanged("dgSelectedIndexDashBoard");
                }
            }
        }

        private int _SelectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _SelectedTabControlIndex; }
            set
            {
                if (_SelectedTabControlIndex != value)
                {
                    _SelectedTabControlIndex = value;
                    RaisePropertyChanged("SelectedTabControlIndex");
                }
            }
        }

        private List<RND_T010_B_Flip> _dsReport;
        public List<RND_T010_B_Flip> dsReport
        {
            get { return _dsReport; }
            set
            {
                if (_dsReport != value)
                {
                    _dsReport = value;


                    RaisePropertyChanged("dsReport");

                }
            }
        }

        #endregion

        #region ICollectionView        

        private ICollectionView _DashBoardCollection;
        public ICollectionView DashBoardCollection
        {
            get { return _DashBoardCollection; }
            set
            {
                if (_DashBoardCollection != value)
                {
                    _DashBoardCollection = value;
                    RaisePropertyChanged("DashBoardCollection");
                }
            }
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

        #region Relay Commands Declaration       
        public GalaSoft.MvvmLight.Command.RelayCommand cmdLoadTestBed { get; private set; }
        public RelayCommand<object> cmdExportGrid { get; private set; }

        #endregion

        #region Event Handler

        #endregion

        #region Constructor
        public RND_T010_VM() : base()
        {
            MasterEntity = new RND_T010_B();
            //DashBoardEntity = new ObservableCollection<RND_T010_B>();
                       
            MC = new MultipleContext_RND_T010();
            MCTemp = new MultipleContext_RND_T010();
            MCTemp1 = new MultipleContext_RND_T010();

            cmdLoadTestBed = new GalaSoft.MvvmLight.Command.RelayCommand(() => { LoadTestBed(); });
            cmdExportGrid = new RelayCommand<object>(items => { if (items == null) { return; } ExportDocument(items); });

            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData";// + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_RND_T010>(MC, Request, "DAS_DashBoard", "PM", "LoadInitialData", 0, "");

                //DefaultValues();

                //DashBoardCollection = CollectionViewSource.GetDefaultView(MC.DashBoardEntity);
                //DashBoardCollection.Filter = new Predicate<object>(Filter);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((RND_T010_A_P)x).tb_code);
                TheFilter = (o, prefix) => ((RND_T010_A_P)o).tb_code.ToLower().Contains(prefix) || ((RND_T010_A_P)o).tb_name.ToLower().Contains(prefix);
                ASTestBedNo = new AutoSuggestTextViewModel<dynamic>(MC.TestBedNo, TheFilter, SuggestedValue, "tb_code", true);
                ASTestBedNo.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((RND_T010_B_P)x).project);
                TheFilter = (o, prefix) => ((RND_T010_B_P)o).project.ToLower().Contains(prefix);
                ASProject = new AutoSuggestTextViewModel<dynamic>(MC.DAS_DashBoard, TheFilter, SuggestedValue, "project", true);
                ASProject.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((RND_T010_B_P)x).eng_model);
                TheFilter = (o, prefix) => ((RND_T010_B_P)o).eng_model.ToLower().Contains(prefix);
                ASEngineModel = new AutoSuggestTextViewModel<dynamic>(MC.DAS_DashBoard, TheFilter, SuggestedValue, "eng_model", true);
                ASEngineModel.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((RND_T010_B_P)x).eng_no);
                TheFilter = (o, prefix) => ((RND_T010_B_P)o).eng_no.ToLower().Contains(prefix);
                ASEngineNo = new AutoSuggestTextViewModel<dynamic>(MC.DAS_DashBoard, TheFilter, SuggestedValue, "eng_no", true);
                ASEngineNo.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((RND_T010_B_P)x).test_type);
                TheFilter = (o, prefix) => ((RND_T010_B_P)o).test_type.ToLower().Contains(prefix);
                ASTestType = new AutoSuggestTextViewModel<dynamic>(MC.DAS_DashBoard, TheFilter, SuggestedValue, "test_type", true);
                ASTestType.AutoSuggestVM.IsEmptyValueAllowed = true;

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
        //    MasterEntity.location_Id = AppSessionState.location_Id;
        //    MasterEntity.comp_code = AppSessionState.comp_code;
        //    MasterEntity.add_by = AppSessionState.UserID;
        //    MasterEntity.editby = AppSessionState.UserID;
        //    MasterEntity.entry_dt = DateTime.Now;
        //    MasterEntity.active = true;
        //    MasterEntity.doc_cat = "FR";
        //    MasterEntity.doc_type = "FR";
        //    MasterEntity.user_source1 = AppSessionState.UserSource1;
        //    MasterEntity.user_source2 = AppSessionState.UserSource2;
        }

        private void LoadTestBed()
        {
            try
            {
                if (Validation() == true)
                {
                    if (MasterEntity.tb_code == null) { MasterEntity.tb_code = "All"; }
                    if (MasterEntity.project == null) { MasterEntity.project = "All"; }
                    if (MasterEntity.eng_model == null) { MasterEntity.eng_model = "All"; }
                    if (MasterEntity.eng_no == null) { MasterEntity.eng_no = "All"; }
                    if (MasterEntity.test_type == null) { MasterEntity.test_type = "All"; }

                    var Request = "LoadDAS_DashBoardFromFilter" + "!@" +  MasterEntity.tb_code + "!@" + MasterEntity.project + "!@" + MasterEntity.eng_model + "!@" + MasterEntity.eng_no + "!@" + MasterEntity.test_type;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_RND_T010>(MCTemp, Request, "DAS_DashBoard", "PM", "", 0, "");

                    DashBoardCollection = CollectionViewSource.GetDefaultView(MCTemp.DashBoardEntity);
                    DashBoardCollection.Filter = new Predicate<object>(Filter);
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
            //if (MasterEntity.tb_code == null || MasterEntity.tb_code == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Enter the Test Bed No...");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            //else if (MasterEntity.project == null || MasterEntity.project == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Enter the Project...");
            //    showMessageService.ShowMessage();
            //    return false;
            //}            

            return true;
        }
        private void ExportDocument(object InputValue)
        {
            try
            {

                // This is for List Collection
                dsReport = MCTemp.DashBoardEntity;

                ExportToExcel<RND_T010_B_Flip, List<RND_T010_B_Flip>> exportOC = new ExportToExcel<RND_T010_B_Flip, List<RND_T010_B_Flip>>();
                exportOC.ListCollectionData = dsReport;
                exportOC.GenerateReport();

                // This is for List ObservarableCollection
                //ExportToExcel<ACC_T002_Flip, List<ACC_T002_Flip>> exportList = new ExportToExcel<ACC_T002_Flip, List<ACC_T002_Flip>>();
                //exportList.ListCollectionData = FlipGridData;
                //exportList.GenerateReport();
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

        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<RND_T010_B> result)
        {
            
        }
        protected override void OnDocumentAction()
        {
            //if (!string.IsNullOrEmpty(MasterEntity.ItemCode))
            //{            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
            //    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.ItemCode.Replace("/", "--"), DocumentList = MCTemp.Attachment });
            //}
        }
        protected override void OnRefreshCommand(InquiryActionResult<RND_T010_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<RND_T010_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<RND_T010_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<RND_T010_B> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<RND_T010_B> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<RND_T010_B> result)
        {
            isNewRecord = true;
            MasterEntity = new RND_T010_B();
            
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<RND_T010_B> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text = String.Format("This record will be Deleted forever", this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
                //string response = repository.Delete(MasterEntity.SrNo, "FormReceivedFrmCustomer", "CRM");  
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<RND_T010_B> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<RND_T010_B> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<RND_T010_B> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<RND_T010_B> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<RND_T010_B> result)
        {

        }

        #endregion

        #region Filters

        #region Filters For DataGrid   
                    
        private string _filterString;
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
        private void FilterCollection()
        {
            if (_DashBoardCollection != null)
            {
                _DashBoardCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as RND_T010_B_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.tb_code != null && data.tb_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.project != null && data.project.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.eng_model != null && data.eng_model.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.eng_no != null && data.eng_no.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.test_type != null && data.test_type.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.f_name != null && data.f_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.E_Speed_000 != null && data.E_Speed_000.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.E_Torque_001 != null && data.E_Torque_001.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.SFCReset_002 != null && data.SFCReset_002.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.L_Weight_003 != null && data.L_Weight_003.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.L_Time_004 != null && data.L_Time_004.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.F_Weight_005 != null && data.F_Weight_005.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.T_WtrOut_006 != null && data.T_WtrOut_006.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.T_Exhaust_007 != null && data.T_Exhaust_007.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.P_LubOil_008 != null && data.P_LubOil_008.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_009 != null && data.Not_Prog_009.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_010 != null && data.Not_Prog_010.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_011 != null && data.Not_Prog_011.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_012 != null && data.Not_Prog_012.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_013 != null && data.Not_Prog_013.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_014 != null && data.Not_Prog_014.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_015 != null && data.Not_Prog_015.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_016 != null && data.Not_Prog_016.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_017 != null && data.Not_Prog_017.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_018 != null && data.Not_Prog_018.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_019 != null && data.Not_Prog_019.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_020 != null && data.Not_Prog_020.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_021 != null && data.Not_Prog_021.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_022 != null && data.Not_Prog_022.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_023 != null && data.Not_Prog_023.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_024 != null && data.Not_Prog_024.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_025 != null && data.Not_Prog_025.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_026 != null && data.Not_Prog_026.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_027 != null && data.Not_Prog_027.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_028 != null && data.Not_Prog_028.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_029 != null && data.Not_Prog_029.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_030 != null && data.Not_Prog_030.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.P_Ambient_031 != null && data.P_Ambient_031.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.P_WtrIn_032 != null && data.P_WtrIn_032.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.P_WtrOut_033 != null && data.P_WtrOut_033.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_034 != null && data.Not_Prog_034.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_035 != null && data.Not_Prog_035.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_036 != null && data.Not_Prog_036.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_037 != null && data.Not_Prog_037.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_038 != null && data.Not_Prog_038.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_039 != null && data.Not_Prog_039.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_040 != null && data.Not_Prog_040.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_041 != null && data.Not_Prog_041.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_042 != null && data.Not_Prog_042.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_043 != null && data.Not_Prog_043.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_044 != null && data.Not_Prog_044.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_045 != null && data.Not_Prog_045.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_046 != null && data.Not_Prog_046.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_047 != null && data.Not_Prog_047.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_048 != null && data.Not_Prog_048.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_049 != null && data.Not_Prog_049.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_050 != null && data.Not_Prog_050.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_051 != null && data.Not_Prog_051.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_052 != null && data.Not_Prog_052.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_053 != null && data.Not_Prog_053.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_054 != null && data.Not_Prog_054.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_055 != null && data.Not_Prog_055.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_056 != null && data.Not_Prog_056.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_057 != null && data.Not_Prog_057.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_058 != null && data.Not_Prog_058.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_059 != null && data.Not_Prog_059.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_060 != null && data.Not_Prog_060.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_061 != null && data.Not_Prog_061.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_062 != null && data.Not_Prog_062.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_063 != null && data.Not_Prog_063.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_064 != null && data.Not_Prog_064.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_065 != null && data.Not_Prog_065.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_066 != null && data.Not_Prog_066.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_067 != null && data.Not_Prog_067.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_068 != null && data.Not_Prog_068.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_069 != null && data.Not_Prog_069.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_070 != null && data.Not_Prog_070.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_071 != null && data.Not_Prog_071.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_072 != null && data.Not_Prog_072.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_073 != null && data.Not_Prog_073.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_074 != null && data.Not_Prog_074.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_075 != null && data.Not_Prog_075.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_076 != null && data.Not_Prog_076.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_077 != null && data.Not_Prog_077.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_078 != null && data.Not_Prog_078.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_079 != null && data.Not_Prog_079.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_080 != null && data.Not_Prog_080.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_081 != null && data.Not_Prog_081.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_082 != null && data.Not_Prog_082.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_083 != null && data.Not_Prog_083.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_084 != null && data.Not_Prog_084.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_085 != null && data.Not_Prog_085.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.NotProg_086 != null && data.NotProg_086.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.T_WI_PID_087 != null && data.T_WI_PID_087.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.T_WO_PID_088 != null && data.T_WO_PID_088.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.T_HTnkPID_089 != null && data.T_HTnkPID_089.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.T_PID4_090 != null && data.T_PID4_090.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_091 != null && data.Not_Prog_091.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_092 != null && data.Not_Prog_092.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_093 != null && data.Not_Prog_093.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_094 != null && data.Not_Prog_094.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_095 != null && data.Not_Prog_095.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_096 != null && data.Not_Prog_096.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_097 != null && data.Not_Prog_097.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_098 != null && data.Not_Prog_098.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_099 != null && data.Not_Prog_099.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_100 != null && data.Not_Prog_100.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.SmkValue_101 != null && data.SmkValue_101.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.BlowBy_102 != null && data.BlowBy_102.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.SFCWt_103 != null && data.SFCWt_103.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.F_Time_104 != null && data.F_Time_104.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.C_Factor_105 != null && data.C_Factor_105.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.AvgTrq_106 != null && data.AvgTrq_106.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.NC_Power_107 != null && data.NC_Power_107.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.NC_SFC_108 != null && data.NC_SFC_108.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Inj_Qty_109 != null && data.Inj_Qty_109.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.C_Trque_110 != null && data.C_Trque_110.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.C_Power_111 != null && data.C_Power_111.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.C_SFC_112 != null && data.C_SFC_112.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.F_Flow_113 != null && data.F_Flow_113.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Fuel_Flow_114 != null && data.Fuel_Flow_114.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.A_Power_hp_115 != null && data.A_Power_hp_115.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.C_Power_hp_116 != null && data.C_Power_hp_116.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.A_SFC_hp_117 != null && data.A_SFC_hp_117.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.C_SFC_hp_118 != null && data.C_SFC_hp_118.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.DiffPress_119 != null && data.DiffPress_119.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_120 != null && data.Not_Prog_120.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_121 != null && data.Not_Prog_121.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Not_Prog_122 != null && data.Not_Prog_122.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Strt_Tm_123 != null && data.Strt_Tm_123.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.ToTal_Hrs_124 != null && data.ToTal_Hrs_124.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.Alarm_125 != null && data.Alarm_125.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.tb_rowId != null && data.tb_rowId.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.ip_address != null && data.ip_address.ToString().ToLower().Contains(_filterString.ToLower()) 

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
