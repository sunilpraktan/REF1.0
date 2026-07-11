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
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using GalaSoft.MvvmLight.Messaging;
using System.Windows.Controls;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Services.Convertors;
using System.Windows;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.IO;
using Reflection.Presentation.Common;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class ECRM_T002_A_RTQFR_VM : WorkspaceViewModel<ECRM_T002_A>
    {
        bool blNew = true;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        WebServiceRepository<ECRM_T002_A> repository = new WebServiceRepository<ECRM_T002_A>();
        WebServiceRepository<MultipleContext_ECRM_T002_A> repositoryM = new WebServiceRepository<MultipleContext_ECRM_T002_A>();
        MultipleContext_ECRM_T002_A MCTemp = new MultipleContext_ECRM_T002_A();
        MultipleContext_ECRM_T002_A MCQFR_No = new MultipleContext_ECRM_T002_A();

        #region AutoSuggest TextBox Declaration Region

        private ICollectionView _dataGridCollection;        
        private string _filterStringDefect_desc;        
        private string _filterString;
        private int _dgSelectedIndex;

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(ECRM_T002_A_RTQFR_VM));
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

        private AutoSuggestTextViewModel<dynamic> _AStestpro { get; set; }
        public AutoSuggestTextViewModel<dynamic> AStestpro
        {
            get { return _AStestpro; }
            set
            {
                if (_AStestpro != value)
                {
                    _AStestpro = value;
                    RaisePropertyChanged("AStestpro");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASdefect { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASdefect
        {
            get { return _ASdefect; }
            set
            {
                if (_ASdefect != value)
                {
                    _ASdefect = value;
                    RaisePropertyChanged("ASdefect");
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
                    if (SourceName == "test")
                    { ASDefault = AStestpro; }
                    if (SourceName == "defect")
                    { ASDefault = ASdefect; }
                }
            }
        }

        #endregion


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

        private int _dgSelectedIndexBatch;
        public int dgSelectedIndexBatch
        {
            get
            {
                return _dgSelectedIndexBatch;
            }
            set
            {
                if (_dgSelectedIndexBatch != value)
                {
                    _dgSelectedIndexBatch = value;
                    RaisePropertyChanged("dgSelectedIndexBatch");
                }
            }
        }

        private int _dgSelectedIndexAssignTotest;
        public int dgSelectedIndexAssignTotest
        {
            get
            { return _dgSelectedIndexAssignTotest; }
            set
            {
                if (_dgSelectedIndexAssignTotest != value)
                {
                    _dgSelectedIndexAssignTotest = value;
                    RaisePropertyChanged("dgSelectedIndexAssignTotest");
                }
            }
        }


        private ObservableCollection<SalesInvoice_SingleReport> _dgReportMaster;
        public ObservableCollection<SalesInvoice_SingleReport> dgReportMaster
        {
            get { return _dgReportMaster; }
            set
            {
                if (_dgReportMaster != value)
                {
                    _dgReportMaster = value;


                    RaisePropertyChanged("dgReportMaster");

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
        #region ICollection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private ICollectionView _Defect_descCollection;
        public ICollectionView Defect_descCollection
        {
            get { return _Defect_descCollection; }
            set
            {
                _Defect_descCollection = value;

                RaisePropertyChanged("Defect_descCollection");
            }
        }
        private ICollectionView _QFRNoCollection;
        public ICollectionView QFRNoCollection
        {
            get { return _QFRNoCollection; }
            set
            {
                _QFRNoCollection = value;

                RaisePropertyChanged("QFRNoCollection");
            }
        }
        private ICollectionView _test_procCollection;
        public ICollectionView test_procCollection
        {
            get { return _test_procCollection; }
            set
            {
                _test_procCollection = value;

                RaisePropertyChanged("test_procCollection");
            }
        }
        private SearchEntity _SearchEntityObject;
        public SearchEntity SearchEntityObject
        {
            get
            {
                return _SearchEntityObject;
            }
            set
            {
                if (_SearchEntityObject != value)
                {
                    _SearchEntityObject = value;
                    RaisePropertyChanged(nameof(SearchEntityObject));
                }
            }
        }
        #endregion

        #region RelayCommand
        public RelayCommand<object> cmdCopySchedule { get; private set; }
        public RelayCommand<object> cmdPrint { get; private set; }
        public RelayCommand<object> Cmdtestpro { get; private set; }
        public RelayCommand<object> cmddefect { get; private set; }
        
        public RelayCommand<object> cmdOpenAttachments { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }       
        public RelayCommand<IList> SelectionChangedCommandDefect_desc
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandQFRNo
        {
            get;
            private set;
        }
        public RelayCommand<object> CommandLoadBackFlipData { get; private set; }
        #endregion
        #region ZADM_M016_P
        private List<ZADM_M016_P> _SelectedListOfDefect_descList;
        public List<ZADM_M016_P> SelectedListOfDefect_descList
        {
            get { return _SelectedListOfDefect_descList; }
            set
            {
                if (_SelectedListOfDefect_descList != value)
                {
                    _SelectedListOfDefect_descList = value;
                    RaisePropertyChanged("SelectedListOfDefect_descList");
                }
            }
        }
        #endregion

        #region ECRM_T002_A
        private List<ECRM_T002_A> _SelectedList;
        public List<ECRM_T002_A> SelectedList
        {
            get { return _SelectedList; }
            set
            {
                if (_SelectedList != value)
                {
                    _SelectedList = value;
                    RaisePropertyChanged("SelectedList");
                }
            }
        }
        private ECRM_T002_A _SelectedECRM_T002_A;
        public ECRM_T002_A SelectedECRM_T002_A
        {
            get
            {
                this.ErrorExist = _SelectedECRM_T002_A.HasErrors;
                return _SelectedECRM_T002_A;
            }
            set
            {
                if (_SelectedECRM_T002_A != value)
                {
                    _SelectedECRM_T002_A = value;
                    this.ErrorExist = _SelectedECRM_T002_A.HasErrors;
                    RaisePropertyChanged("SelectedECRM_T002_A");
                    value.BeginEdit();
                }
            }
        }
        #endregion

        #region ECRM_T002_B
        private static ObservableCollection<ECRM_T002_B> _QFRDetails = new ObservableCollection<ECRM_T002_B>();
        public ObservableCollection<ECRM_T002_B> QFRDetails
        {
            get { return _QFRDetails; }
            set
            {
                if (_QFRDetails != value)
                {
                    _QFRDetails = value;

                    RaisePropertyChanged("QFRDetails");
                }
            }
        }
        private ObservableCollection<ECRM_T002_C> _testDetails;
        public ObservableCollection<ECRM_T002_C> testDetails
        {
            get
            {
                return _testDetails;
            }
            set
            {
                if (_testDetails != value)
                {
                    _testDetails = value;
                    //_TestEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForBatch);
                    RaisePropertyChanged("testDetails");
                }
            }
        }
        public ECRM_T002_B _SelectedECRM_T002_B { get; private set; }
        public ECRM_T002_B SelectedECRM_T002_B
        {
            get { return _SelectedECRM_T002_B; }
            set
            {
                if (_SelectedECRM_T002_B != value)
                {
                    _SelectedECRM_T002_B = value;
                    RaisePropertyChanged("SelectedECRM_T002_B");
                    // value.BeginEdit();
                }
            }
        }
        public ECRM_T002_C _SelectedECRM_T002_C { get; private set; }
        public ECRM_T002_C SelectedECRM_T002_C
        {
            get { return _SelectedECRM_T002_C; }
            set
            {
                if (_SelectedECRM_T002_C != value)
                {
                    _SelectedECRM_T002_C = value;
                    RaisePropertyChanged("SelectedECRM_T002_C");
                    // value.BeginEdit();
                }
            }
        }
        

        private List<ECRM_T002_B> _SelectedECRM_T002_B_List;
        public List<ECRM_T002_B> SelectedECRM_T002_B_List
        {
            get
            {
                return _SelectedECRM_T002_B_List;
            }
            set
            {
                _SelectedECRM_T002_B_List = value;
                RaisePropertyChanged("SelectedECRM_T002_B_List");
            }
        }
        private List<ECRM_T002_C> _SelectedECRM_T002_C_List;
        public List<ECRM_T002_C> SelectedECRM_T002_C_List
        {
            get
            {
                return _SelectedECRM_T002_C_List;
            }
            set
            {
                _SelectedECRM_T002_C_List = value;
                RaisePropertyChanged("SelectedECRM_T002_C_List");
            }
        }
        

        #endregion       
        public int dgSelectedIndex
        {
            get
            {
                return _dgSelectedIndex;
            }
            set
            {
                if (_dgSelectedIndex != value)
                {
                    _dgSelectedIndex = value;
                    RaisePropertyChanged("dgSelectedIndex");
                }
            }
        }
        MultipleContext_ECRM_T002_A _MC = new MultipleContext_ECRM_T002_A();
        public MultipleContext_ECRM_T002_A MC
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
       

        public ECRM_T002_A_RTQFR_VM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            SearchEntityObject = new SearchEntity();
            SelectedList = new List<ECRM_T002_A>();
            SelectedECRM_T002_A = new ECRM_T002_A();
            MC = new MultipleContext_ECRM_T002_A();
            QFRDetails = new ObservableCollection<ECRM_T002_B>();
            SelectedECRM_T002_B_List = new List<ECRM_T002_B>();
            SelectedECRM_T002_B = new ECRM_T002_B();
            MC.QFRDetails = new ObservableCollection<ECRM_T002_B>();

            testDetails = new ObservableCollection<ECRM_T002_C>();
            SelectedECRM_T002_C_List = new List<ECRM_T002_C>();
            SelectedECRM_T002_C = new ECRM_T002_C();
            MC.testDetails = new ObservableCollection<ECRM_T002_C>();

            SelectedECRM_T002_A.ValidateAsync().Wait();
            LoadInitialData();
            SelectedECRM_T002_A.doc_cat = "QR";
            SelectedECRM_T002_A.doc_type = "QR";
        }
        public ECRM_T002_A_RTQFR_VM(string ts_code, string doc_no)
            : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            SearchEntityObject = new SearchEntity();
            SelectedList = new List<ECRM_T002_A>();
            SelectedECRM_T002_A = new ECRM_T002_A();
            MC = new MultipleContext_ECRM_T002_A();
            QFRDetails = new ObservableCollection<ECRM_T002_B>();
            SelectedECRM_T002_B_List = new List<ECRM_T002_B>();
            SelectedECRM_T002_B = new ECRM_T002_B();
            MC.QFRDetails = new ObservableCollection<ECRM_T002_B>();

            testDetails = new ObservableCollection<ECRM_T002_C>();
            SelectedECRM_T002_C_List = new List<ECRM_T002_C>();
            SelectedECRM_T002_C = new ECRM_T002_C();
            MC.testDetails = new ObservableCollection<ECRM_T002_C>();

            SelectedECRM_T002_A.ValidateAsync().Wait();
            LoadInitialData();
            SelectedECRM_T002_A.doc_cat = "QR";
            SelectedECRM_T002_A.doc_type = "QR";

            SearchEntityObject.from_date = DateTime.Now.Date;
            SearchEntityObject.to_date = DateTime.Now.Date;
            SearchEntityObject.active = true;
            SelectedECRM_T002_A.rtqfr = true;
        }
        private void LoadInitialData()
        {
            try
            {
                #region Commands
                cmdCopySchedule = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } CopyScheduleLine(cmdPara); });
                cmdPrint = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } PrintDocuments(cmdPara); });
                cmdOpenAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenDocumentViewer(cmdPara); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                Cmdtestpro = new RelayCommand<object>(items => { if (items == null) { return; } Insert_TestProcedure(items, false, true, true); });
                cmddefect = new RelayCommand<object>(items => { if (items == null) { return; } Insert_Defect(items, false, true, true); });
                SelectionChangedCommand = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    GetSelectedQFR_Dtails(items);
                });

                SelectionChangedCommandDefect_desc = new RelayCommand<IList>(
             items =>
             {
                 if (items == null)
                 {
                     return;
                 }

                 GetSelectedDefect_descDetails(items);
             });
                SelectionChangedCommandQFRNo = new RelayCommand<IList>(
             items =>
             {
                 if (items == null)
                 {
                     return;
                 }

                 GetSelectedQFRNoDetails(items);
             });
                CommandLoadBackFlipData = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items); });
                #endregion
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.client + "!@" + AppSessionState.EmpId;
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MC, Request, "Quality_Feedback", "CRM", "LoadAll", 0, "");
                //MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MC, "ECRM_T002_A_Data", "Quality_Feedback", "CRM", "LoadAllRTQFR", 0, "");
                SelectedList = MC.QulityFeedback;

                SelectedECRM_T002_A.quality_feedback_date = DateTime.Now;
                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);              

                Defect_descCollection = CollectionViewSource.GetDefaultView(MC.Defect);
                Defect_descCollection.Filter = new Predicate<object>(Defect_descFilter);

                QFRNoCollection = CollectionViewSource.GetDefaultView(MC.QFRNo);
                //QFRNoCollection.Filter = new Predicate<object>(Filter);   

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M065_P)x).test_name);
                TheFilter = (o, prefix) => (((ADM_M065_P)o).test_id ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M065_P)o).test_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AStestpro = new AutoSuggestTextViewModel<dynamic>(MC.TestProcedure, TheFilter, SuggestedValue, "test_id", "test_id", true);
                AStestpro.AutoSuggestVM.IsEmptyValueAllowed = true;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ECRM_T002_B_P)x).defect_description);
                //TheFilter = (o, prefix) => (((ECRM_T002_B_P)o).defect_description ?? "").ToLower().Contains(prefix.ToString().ToLower());
                //ASdefect = new AutoSuggestTextViewModel<dynamic>(MC.DefectList, TheFilter, SuggestedValue, "defect_id", "defect_id", true);
                //ASdefect.AutoSuggestVM.IsEmptyValueAllowed = true;

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

        #region . User Defined Function .
        private void PrintDocuments(object InputValue)
        {
            try
            {
                if (SelectedECRM_T002_A.quality_feedback_no != null && SelectedECRM_T002_A.quality_feedback_no != " ")
                {
                    string Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + SelectedECRM_T002_A.quality_feedback_no;
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MCTemp, Request, "Quality_Feedback", "CRM", "", 0, "");
                    //MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MCTemp, "ECRM_T002_A_Data", "Quality_Feedback", "CRM", "QFR_Details", 0, SelectedECRM_T002_A.quality_feedback_no);
                    if (SelectedECRM_T002_A.report_type != "" && SelectedECRM_T002_A.report_type != null)
                    {
                        //if (SelectedECRM_T002_A.report_type == "Export")
                        //{
                        object[] objDataSource = new object[4];
                        string[] objDataSourceName = new string[4];

                        List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                        var Result = TempList.Where(loc => loc.location_Id == SelectedECRM_T002_A.location_Id).ToList();
                        objDataSource[2] = Result;

                        List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                        var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == SelectedECRM_T002_A.comp_code).ToList();
                        objDataSource[1] = CmpResult;

                        objDataSource[0] = MCTemp.QulityFeedback;
                        objDataSource[3] = MCTemp.QFRDetails;

                        objDataSourceName[2] = "dsLocation";
                        objDataSourceName[1] = "dsCompany";
                        objDataSourceName[0] = "dsECRM_T002_A";
                        objDataSourceName[3] = "dsECRM_T002_B";

                        ReportManager ReportManager = new ReportManager();
                        string ReportDisplayName = SelectedECRM_T002_A.PartyNm + "_" + SelectedECRM_T002_A.quality_feedback_no + "_" + SelectedECRM_T002_A.quality_feedback_date.Value.ToShortDateString();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\QualityFeedback1.rdlc", ReportDisplayName);
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Select Transaction Type...", this.Title);
                        showMessageService.ShowMessage();
                    }
                    //}
                    //else if (SelectedECRM_T002_A.report_type == "Local")
                    //{
                    //    object[] objDataSource = new object[4];
                    //    string[] objDataSourceName = new string[4];

                    //    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    //    var Result = TempList.Where(loc => loc.location_Id == SelectedECRM_T002_A.location_Id).ToList();
                    //    objDataSource[1] = Result;

                    //    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    //    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == SelectedECRM_T002_A.comp_code).ToList();
                    //    objDataSource[0] = CmpResult;

                    //    objDataSource[2] = MCTemp.QulityFeedback;
                    //    objDataSource[3] = MCTemp.QFRDetails;

                    //    objDataSourceName[1] = "dsLocation";
                    //    objDataSourceName[0] = "dsCompany";
                    //    objDataSourceName[2] = "ECRM_T002_AMaster";
                    //    objDataSourceName[3] = "ECRM_T002_BDetail";
                    //    ReportManager ReportManager = new ReportManager();
                    //    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\QualityFeedbackLocal.rdlc", "QualityFeedbackReport");
                    //}
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Select Quality feedback No.....", this.Title);
                    showMessageService.ShowMessage();

                }
                //if (MasterEntity.id > 0)
                // {
                //     MasterEntity = repository.SaveWithReturnDomainObject<ECRM_T001_A>(MasterEntity, "Sample_Analysis", "CRM");

                //     MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MC, "EPR_T001_Data", "Sample_Analysis", "CRM", "rptSampleAnalysis", 0, MasterEntity.sa_no);
                //     //dgReportMaster = MC.rptSalesAnalysis;
                //     //object objDS = new object();
                //     //objDS = MC.rptSalesAnalysis;

                //     ReportManager ReportManager = new ReportingServices.ReportManager();

                //    // ReportManager.DisplayReport(objDS, "dsSampleAnalysis", "\\CRM\\SampleAnalysis.rdlc");

                // }
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

        private void OpenDocumentViewer(object InputValue)
        {
            try
             {
                List<COM_T003> Attachments = new List<COM_T003>();
                ECRM_T002_C EntityObjectParameter = new ECRM_T002_C();
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    EntityObjectParameter.quality_feedback_no = SelectedECRM_T002_A.quality_feedback_no;
                    Attachments = (List<COM_T003>)MCTemp.Attachment.Where(x => x.doc_no == SelectedECRM_T002_A.quality_feedback_no && x.resource_name == null).ToList();
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = SelectedECRM_T002_A.quality_feedback_no.Replace("/", "--"), DocumentList = Attachments, client = AppSessionState.client, comp_code = (SelectedECRM_T002_A.comp_code ?? AppSessionState.comp_code) });
                }
                else if (InputValue != null)
                {
                    EntityObjectParameter = ((IEnumerable)InputValue).Cast<ECRM_T002_C>().ToList()[0];
                    if (EntityObjectParameter.quality_feedback_no != null)
                    {
                        Attachments = (List<COM_T003>)MCTemp.Attachment.Where(x => x.resource_name == (string)EntityObjectParameter.id.ToString()).ToList();
                        if (string.IsNullOrEmpty(EntityObjectParameter.quality_feedback_no) == false)
                        {
                            Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = EntityObjectParameter.quality_feedback_no.Replace("/", "--"), Row_ID = EntityObjectParameter.id.ToString(), DocumentList = Attachments, client = AppSessionState.client, comp_code = (SelectedECRM_T002_A.comp_code ?? AppSessionState.comp_code) });
                        }
                    }
                }

                //WebServiceRepository<MultipleContext_Attachments> repository_MCAttachments = new WebServiceRepository<MultipleContext_Attachments>();
                //List<COM_T003> Attachments = new List<COM_T003>();
                //ECRM_T002_C EntityObjectParameter = new ECRM_T002_C();
                //MultipleContext_Attachments MCAttachments = new MultipleContext_Attachments();

                //if (InputValue != null)
                //{
                //    EntityObjectParameter = ((IEnumerable)InputValue).Cast<ECRM_T002_C>().ToList()[0];
                //}
                //string Request = "GetAllFiles" + "!@" + EntityObjectParameter.id;
                //MCAttachments = repository_MCAttachments.GetData<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Reflection.BusinessLogic.ReflectionFileHandlingServices");

                //string id = EntityObjectParameter.id.ToString();

                //if (!string.IsNullOrEmpty(id))
                //{
                //    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = id.Replace("/", "--"), DocumentList = MCAttachments.Attachments });
                //}

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
                    Request = SelectedECRM_T002_A.client + "!@" + SelectedECRM_T002_A.comp_code + "!@" + InputValue.ToString();
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
                    //LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
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
        private void GetSelectedQFR_Dtails(IList QFRDetailList)
        {
            try
            {
                IList list = QFRDetailList as IList;
                List<ECRM_T002_A> GetSelectedQFRDetails = list.Cast<ECRM_T002_A>().ToList();

                if (GetSelectedQFRDetails.Count > 0)
                {
                    SelectedECRM_T002_A = (ECRM_T002_A)GetSelectedQFRDetails[0];
                    string Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + SelectedECRM_T002_A.quality_feedback_no;
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MCTemp, Request, "Quality_Feedback", "CRM", "", 0, "");


                    //MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MCTemp, "ECRM_T002_A_Data", "Quality_Feedback", "CRM", "Load_RTQFR", 0, SelectedECRM_T002_A.quality_feedback_no);


                    if (SelectedECRM_T002_A != null)
                    {
                        MC.QFRDetails = MCTemp.QFRDetails;
                        QFRDetails = MCTemp.QFRDetails;
                        testDetails = MCTemp.testDetails;
                        AttachmentCollection = MCTemp.Attachment;

                    }
                    SelectedECRM_T002_A.ts_code = ts_code_vm;
                    blNew = false;
                    SelectedTabControlIndex = 0;
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
        private void GetSelectedDefect_descDetails(IList Defect_descList)
        {
            try
            {
                IList list = Defect_descList as IList;
                List<ZADM_M016_P> SelectedDefect_descDetailsTemp = list.Cast<ZADM_M016_P>().ToList();

                if (SelectedDefect_descDetailsTemp.Count > 0 && dgSelectedIndex != -1)
                {
                    var q = QFRDetails.Where(X => X.defect_description == SelectedDefect_descDetailsTemp[0].dfctdsc).FirstOrDefault();

                    if (q != null)
                    {
                        if (QFRDetails.Count() > dgSelectedIndex)
                        {
                            QFRDetails[dgSelectedIndex].active = true;
                            QFRDetails[dgSelectedIndex].defect_description = SelectedDefect_descDetailsTemp[0].dfctdsc;
                            QFRDetails[dgSelectedIndex].defect_id = SelectedDefect_descDetailsTemp[0].dfctcda;
                        }
                    }
                    else
                    {
                        if (QFRDetails.Count() <= dgSelectedIndex)
                        {
                            QFRDetails.Add(new ECRM_T002_B() { defect_description = SelectedDefect_descDetailsTemp[0].dfctdsc, defect_id = SelectedDefect_descDetailsTemp[0].dfctcda });
                        }
                        else
                        {
                            QFRDetails[dgSelectedIndex].defect_description = SelectedDefect_descDetailsTemp[0].dfctdsc;
                            QFRDetails[dgSelectedIndex].defect_id = SelectedDefect_descDetailsTemp[0].dfctcda;
                        }
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
        private void GetSelectedQFRNoDetails(IList QFRNoList)
        {
            IList list = QFRNoList as IList;
            List<ECRM_T002_A_P> SelectedQFRNoDetailsTemp = list.Cast<ECRM_T002_A_P>().ToList();
            if (SelectedQFRNoDetailsTemp.Count > 0)
            {
                SelectedECRM_T002_A.quality_feedback_no = SelectedQFRNoDetailsTemp[0].quality_feedback_no;
               
                string Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + SelectedECRM_T002_A.quality_feedback_no;
                MCQFR_No = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MCQFR_No, Request, "Quality_Feedback", "CRM", "", 0, "");

                QFRDetails = new ObservableCollection<ECRM_T002_B>();
                testDetails = new ObservableCollection<ECRM_T002_C>();
                SelectedList = MCQFR_No.QulityFeedback;

                SelectedECRM_T002_A = (ECRM_T002_A)MCQFR_No.QulityFeedback[0];
                if (SelectedECRM_T002_A != null)
                {
                    ObservableCollection<ECRM_T002_B> result = (ObservableCollection<ECRM_T002_B>)MCQFR_No.QFRDetails.Cast<ECRM_T002_B>();
                    IEnumerable<ECRM_T002_B> barEnumerable =
                            from data in result
                            where data.quality_feedback_no == SelectedECRM_T002_A.quality_feedback_no
                            select data;

                    QFRDetails = new ObservableCollection<ECRM_T002_B>(barEnumerable);

                    ObservableCollection<ECRM_T002_C> result1 = (ObservableCollection<ECRM_T002_C>)MCQFR_No.testDetails.Cast<ECRM_T002_C>();
                    IEnumerable<ECRM_T002_C> barEnumerable1 =
                            from data in result1
                            where data.quality_feedback_no == SelectedECRM_T002_A.quality_feedback_no
                            select data;

                    testDetails = new ObservableCollection<ECRM_T002_C>(barEnumerable1);


                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ECRM_T002_B_P)x).defect_description);
                    TheFilter = (o, prefix) => (((ECRM_T002_B_P)o).defect_description ?? "").ToLower().Contains(prefix.ToString().ToLower());
                    ASdefect = new AutoSuggestTextViewModel<dynamic>(MCQFR_No.DefectList, TheFilter, SuggestedValue, "defect_id", "defect_id", true);
                    ASdefect.AutoSuggestVM.IsEmptyValueAllowed = true;

                    Defect_descCollection = CollectionViewSource.GetDefaultView(MCQFR_No.Defect);
                    Defect_descCollection.Filter = new Predicate<object>(Defect_descFilter);

                }

                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);



                blNew = false;
            }
        }
        //private void GetSelectedQFRNoDetails(IList QFRNoList)
        //{
        //    IList list = QFRNoList as IList;
        //    List<ECRM_T002_A_P> SelectedQFRNoDetailsTemp = list.Cast<ECRM_T002_A_P>().ToList();
        //    if (SelectedQFRNoDetailsTemp.Count > 0)
        //    {
        //        string Request = "QFR_No" + "!@" + SelectedECRM_T002_A.quality_feedback_no;
        //        MCQFR_No = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MCQFR_No, Request, "Quality_Feedback", "CRM", "", 0, "");

        //        //SelectedECRM_T002_A.quality_feedback_no = SelectedQFRNoDetailsTemp[0].quality_feedback_no;
        //        //MCQFR_No = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MCQFR_No, "ECRM_T002_A_Data", "Quality_Feedback", "CRM", "QFR_No", 0, SelectedECRM_T002_A.quality_feedback_no);
        //        QFRDetails = new ObservableCollection<ECRM_T002_B>();
        //        testDetails = new ObservableCollection<ECRM_T002_C>();
        //        SelectedList = MCQFR_No.QulityFeedback;

                

        //        SelectedECRM_T002_A = (ECRM_T002_A)MCQFR_No.QulityFeedback[0];
        //        //MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MCTemp, "ECRM_T002_A_Data", "Quality_Feedback", "CRM", "QFR_Details", 0, SelectedECRM_T002_A.quality_feedback_no);
        //        if (SelectedECRM_T002_A != null)
        //        {
        //            ObservableCollection<ECRM_T002_B> result = (ObservableCollection<ECRM_T002_B>)MCQFR_No.QFRDetails.Cast<ECRM_T002_B>();
        //            IEnumerable<ECRM_T002_B> barEnumerable =
        //                    from data in result
        //                    where data.quality_feedback_no == SelectedECRM_T002_A.quality_feedback_no
        //                    select data;

        //            QFRDetails = new ObservableCollection<ECRM_T002_B>(barEnumerable);

        //            ObservableCollection<ECRM_T002_C> result1 = (ObservableCollection<ECRM_T002_C>)MCQFR_No.testDetails.Cast<ECRM_T002_C>();
        //            IEnumerable<ECRM_T002_C> barEnumerable1 =
        //                    from data in result1
        //                    where data.quality_feedback_no == SelectedECRM_T002_A.quality_feedback_no
        //                    select data;

        //            testDetails = new ObservableCollection<ECRM_T002_C>(barEnumerable1);

                    
        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ECRM_T002_B_P)x).defect_description);
        //        TheFilter = (o, prefix) => (((ECRM_T002_B_P)o).defect_description ?? "").ToLower().Contains(prefix.ToString().ToLower());
        //        ASdefect = new AutoSuggestTextViewModel<dynamic>(MCQFR_No.DefectList, TheFilter, SuggestedValue, "defect_id", "defect_id", true);
        //        ASdefect.AutoSuggestVM.IsEmptyValueAllowed = true;

        //        Defect_descCollection = CollectionViewSource.GetDefaultView(MCQFR_No.Defect);
        //        Defect_descCollection.Filter = new Predicate<object>(Defect_descFilter);

        //        }

        //        DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
        //        DataGridCollection.Filter = new Predicate<object>(Filter);

                

        //        blNew = false;
        //    }
        //}
        private void Insert_TestProcedure(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M065_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.TestProcedure.Where(x => x.test_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.test_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M065_P>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {

                    if (dgSelectedIndexAssignTotest >= 0 && testDetails.Count > dgSelectedIndexAssignTotest) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        testDetails[dgSelectedIndexAssignTotest].test_id = POPUPEntityObject.test_id;
                        testDetails[dgSelectedIndexAssignTotest].test_name = POPUPEntityObject.test_name;

                        SelectedECRM_T002_A.active = true;
                    }
                    else if (testDetails[dgSelectedIndexAssignTotest].test_id != POPUPEntityObject.test_id)
                    {
                        testDetails[dgSelectedIndexAssignTotest].test_id = POPUPEntityObject.test_id;
                        testDetails[dgSelectedIndexAssignTotest].test_name = POPUPEntityObject.test_name;
                        SelectedECRM_T002_A.active = true;
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
        private void Insert_Defect(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ECRM_T002_B POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.QFRDetails.Where(x => x.defect_description.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ECRM_T002_B>().ToList()[0];
                }
                #endregion

                //if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                //{

                //    if (dgSelectedIndexAssignTotest >= 0 && TestEntity.Count > dgSelectedIndexAssignTotest) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                //    {

                //        TestEntity[dgSelectedIndexAssignTotest].defect_id = POPUPEntityObject.defect_id;
                //        //TestEntity[dgSelectedIndexAssignTotest].defect_description = POPUPEntityObject.defect_description;

                //        SelectedECRM_T002_A.active = true;
                //    }
                //    else if (TestEntity[dgSelectedIndexAssignTotest].defect_id != POPUPEntityObject.defect_id)
                //    {
                //        TestEntity[dgSelectedIndexAssignTotest].defect_id = POPUPEntityObject.defect_id;
                //        //TestEntity[dgSelectedIndexAssignTotest].test_name = POPUPEntityObject.test_name;
                //        SelectedECRM_T002_A.active = true;
                //    }
                //}
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
        private void CopyScheduleLine(object InputValue)
        {
            string Request = "";
            List<ECRM_T002_B> POPUPEntityObject = new List<ECRM_T002_B>();
            try
            {
                if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ECRM_T002_B>().ToList();
                    if (POPUPEntityObject.Count > 0)
                    {


                        foreach (var itemObj in POPUPEntityObject)
                        {
                            //decimal? currScheduleQty = QFRDetails.Where(p => p.defect_id == itemObj.defect_id && p.id > 0).Sum(p => p.confirm_qty);
                            //decimal? currOrderQty = MC.Reference_Docs.Where(p => p.id == itemObj.so_item_id).ToList()[0].quantity;
                            //decimal? currBalanceQty = MC.Reference_Docs.Where(p => p.id == itemObj.so_item_id).ToList()[0].bal_qty;
                            //decimal? totalBalQty = currScheduleQty + currBalanceQty;

                            QFRDetails.Add(new ECRM_T002_B()
                            {
                                id = 0,
                                defect_id = itemObj.defect_id,
                                defect_description = itemObj.defect_description,
                                material = itemObj.material,
                                no_of_sample = itemObj.no_of_sample,
                                batch_no = itemObj.batch_no,
                                observation_test = itemObj.observation_test,
                                active = false
                               
                               
                            });
                            //totalBalQty = totalBalQty - itemObj.confirm_qty;
                        }
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

        private void LoadBackFlipData(object Parameter)
        {
            try
            {
                SelectedECRM_T002_A.rtqfr = true;
                CursorControl.SetBusyState();
                string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + Convert.ToDateTime(SearchEntityObject.from_date).ToString() + "!@" + Convert.ToDateTime(SearchEntityObject.to_date).ToString() + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + AppSessionState.EmpId + "!@" + SearchEntityObject.active + "!@" + SelectedECRM_T002_A.rtqfr;
                MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MCTemp, Request, "Quality_Feedback", "CRM", "LoadAll", 0, "");

                SelectedList = MCTemp.QulityFeedback.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
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

        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<ECRM_T002_A> result)
        {
            try
            {
                SelectedECRM_T002_A.add_by = AppSessionState.UserID;              
                SelectedECRM_T002_A.location_Id = AppSessionState.location_Id;             
                SelectedECRM_T002_A.comp_code = AppSessionState.comp_code;
                SelectedECRM_T002_A.client = AppSessionState.client;
                SelectedECRM_T002_A.doc_cat = "QR";
                SelectedECRM_T002_A.doc_type = "QR";
                ObjectSerializationService objSer = new ObjectSerializationService();

                SelectedECRM_T002_A.XmlDataDocument_ECRM_T002_B = objSer.ObjectToXML(QFRDetails);
                SelectedECRM_T002_A.XmlDataDocument_ECRM_T002_C = objSer.ObjectToXML(testDetails);
                int y = 0;
                    SelectedECRM_T002_A.rtqfr = true;
                    if (SelectedECRM_T002_A.active == false)
                    {
                        y = 1;
                    }
                    SelectedECRM_T002_A = repository.UpdateWithReturnDomainObject<ECRM_T002_A>(SelectedECRM_T002_A, "Quality_Feedback", "CRM");
                    this.SelectedECRM_T002_A.EndEdit();
                    if (y == 1)
                    {
                        SelectedECRM_T002_A = new ECRM_T002_A();
                    }               
                _dataGridCollection.Refresh();
                try
                {
                    for (int i = 0; i < MC.QFRNo.Count(); i++)
                    {
                        if (MC.QFRNo[i].quality_feedback_no == SelectedECRM_T002_A.quality_feedback_no)
                        {
                            MC.QFRNo.RemoveAt(i);
                            break;
                        }
                    }

                    QFRNoCollection = CollectionViewSource.GetDefaultView(MC.QFRNo);
                }catch(Exception e){}

                if (SelectedECRM_T002_A.XmlDataDocument_ECRM_T002_B != null)
                {
                    MC.QFRDetails = (ObservableCollection<ECRM_T002_B>)new ObjectSerializationService().XMLToObject(SelectedECRM_T002_A.XmlDataDocument_ECRM_T002_B, MC.QFRDetails);
                }
                else
                {
                    MC.QFRDetails = new ObservableCollection<ECRM_T002_B>();
                }
                if (SelectedECRM_T002_A.XmlDataDocument_ECRM_T002_C != null)
                {
                    MC.testDetails = (ObservableCollection<ECRM_T002_C>)new ObjectSerializationService().XMLToObject(SelectedECRM_T002_A.XmlDataDocument_ECRM_T002_C, MC.testDetails);
                }
                else
                {
                    MC.testDetails = new ObservableCollection<ECRM_T002_C>();
                }
                QFRDetails = MC.QFRDetails;
                testDetails = MC.testDetails;
                if (SelectedECRM_T002_A != null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Data Saved Successfully");
                    showMessageService.ShowMessage();
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

        protected override void OnCreateAction(InquiryActionResult<ECRM_T002_A> result)
        {

            blNew = true;
            SelectedECRM_T002_A = new ECRM_T002_A();
            SelectedECRM_T002_A.ValidateAsync().Wait();
            QFRDetails = new ObservableCollection<ECRM_T002_B>();
            QFRDetails.Clear();
            _dataGridCollection.Refresh();
            SelectedECRM_T002_A.quality_feedback_date = DateTime.Now;
            SelectedECRM_T002_A.ts_code = ts_code_vm;
            SelectedECRM_T002_A.client = AppSessionState.client;
            QFRNoCollection.Refresh();
            testDetails = new ObservableCollection<ECRM_T002_C>();
            testDetails.Clear();

        }
        protected override void OnRemoveAction(InquiryActionResult<ECRM_T002_A> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text =
                String.Format(
                    "This record will delete forever '{0}'",
                        this.Title);

            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
                this.SelectedECRM_T002_A.CancelEdit();
                string response = repository.Delete(SelectedECRM_T002_A.quality_feedback_no, "Quality_Feedback", "CRM");
                SelectedList.Remove(SelectedECRM_T002_A);
                _dataGridCollection.Refresh();
                SelectedECRM_T002_A = new ECRM_T002_A();
                QFRDetails = new ObservableCollection<ECRM_T002_B>();
                testDetails = new ObservableCollection<ECRM_T002_C>();

            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ECRM_T002_A> result)
        {
            SelectedECRM_T002_A.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ECRM_T002_A> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ECRM_T002_A> result)
        {
            SelectedList = SelectedList;
            SelectedECRM_T002_A = SelectedECRM_T002_A;
        }
        protected override void OnHelpAction(InquiryActionResult<ECRM_T002_A> result)
        {
            SelectedList = SelectedList;
            SelectedECRM_T002_A = SelectedECRM_T002_A;
        }
        protected override void OnPrintAction(InquiryActionResult<ECRM_T002_A> result)
        {
            //try
            //{
            //    if (SelectedECRM_T002_A.id > 0)
            //    {
            //        MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MC, "EPR_T002_Data", "Quality_Feedback", "CRM", "rptQFR", 0, SelectedECRM_T002_A.quality_feedback_no);
            //        dgReportMaster = MC.rptQFR;
            //        object objDS = new object();
            //        objDS = MC.rptQFR;

            //        ReportManager ReportManager = new ReportingServices.ReportManager();

            //        ReportManager.DisplayReport(objDS, "DataSet1", "\\QMS\\QFR.rdlc");

            //    }
            //}
            //catch
            //{

            //}

            try
            {
                if (SelectedECRM_T002_A.quality_feedback_no != null && SelectedECRM_T002_A.quality_feedback_no != " ")
                {
                    string Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + SelectedECRM_T002_A.quality_feedback_no;
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MCTemp, Request, "Quality_Feedback", "CRM", "", 0, "");

                    //MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ECRM_T002_A>(MCTemp, "ECRM_T002_A_Data", "Quality_Feedback", "CRM", "rptQFR", 0, SelectedECRM_T002_A.quality_feedback_no);
                    if (SelectedECRM_T002_A.report_type != "" && SelectedECRM_T002_A.report_type != null)
                    {
                        //if (SelectedECRM_T002_A.report_type == "Export")
                        //{
                        object[] objDataSource = new object[4];
                        string[] objDataSourceName = new string[4];

                        List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                        var Result = TempList.Where(loc => loc.location_Id == SelectedECRM_T002_A.location_Id).ToList();
                        objDataSource[1] = Result;

                        List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                        var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == SelectedECRM_T002_A.comp_code).ToList();
                        objDataSource[0] = CmpResult;

                        objDataSource[2] = MCTemp.QulityFeedback;
                        objDataSource[3] = MCTemp.QFRDetails;

                        objDataSourceName[2] = "dsQualityMaster";
                        objDataSourceName[1] = "dsLocation";
                        objDataSourceName[0] = "dsCompany";
                        objDataSourceName[3] = "dsQualityItem";

                        ReportManager ReportManager = new ReportManager();
                        string ReportDisplayName = SelectedECRM_T002_A.PartyNm + "_" + SelectedECRM_T002_A.quality_feedback_no + "_" + SelectedECRM_T002_A.quality_feedback_date.Value.ToShortDateString();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\QMS\\QFR.rdlc", ReportDisplayName);
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Select Transaction Type...", this.Title);
                        showMessageService.ShowMessage();
                    }
                    //}
                    //else if (SelectedECRM_T002_A.report_type == "Local")
                    //{
                    //    object[] objDataSource = new object[4];
                    //    string[] objDataSourceName = new string[4];

                    //    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    //    var Result = TempList.Where(loc => loc.location_Id == SelectedECRM_T002_A.location_Id).ToList();
                    //    objDataSource[1] = Result;

                    //    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    //    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == SelectedECRM_T002_A.comp_code).ToList();
                    //    objDataSource[0] = CmpResult;

                    //    objDataSource[2] = MCTemp.QulityFeedback;
                    //    objDataSource[3] = MCTemp.QFRDetails;

                    //    objDataSourceName[1] = "dsLocation";
                    //    objDataSourceName[0] = "dsCompany";
                    //    objDataSourceName[2] = "ECRM_T002_AMaster";
                    //    objDataSourceName[3] = "ECRM_T002_BDetail";
                    //    ReportManager ReportManager = new ReportManager();
                    //    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\QualityFeedbackLocal.rdlc", "QualityFeedbackReport");
                    //}
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Select Quality feedback No.....", this.Title);
                    showMessageService.ShowMessage();

                }
                //if (MasterEntity.id > 0)
                // {
                //     MasterEntity = repository.SaveWithReturnDomainObject<ECRM_T001_A>(MasterEntity, "Sample_Analysis", "CRM");

                //     MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MC, "EPR_T001_Data", "Sample_Analysis", "CRM", "rptSampleAnalysis", 0, MasterEntity.sa_no);
                //     //dgReportMaster = MC.rptSalesAnalysis;
                //     //object objDS = new object();
                //     //objDS = MC.rptSalesAnalysis;

                //     ReportManager ReportManager = new ReportingServices.ReportManager();

                //    // ReportManager.DisplayReport(objDS, "dsSampleAnalysis", "\\CRM\\SampleAnalysis.rdlc");

                // }
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
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            //try
            //{
            //    result.Add("prepare_by", AppSessionState.Name);
            //}
            try
            {
                if (MCTemp.Attachment != null && MCTemp.Attachment.Count > 0)
                {
                    string path1 = Path.Combine(@"file:\" + AppDomain.CurrentDomain.BaseDirectory, "temp//" + MCTemp.Attachment[0].url);
                    result.Add("ImagePath", path1);
                }
                else
                {
                    result.Add("ImagePath", @"file:\" + AppDomain.CurrentDomain.BaseDirectory);
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
            return result;
        }
        //protected override void OnExportAction(InquiryActionResult<ECRM_T002_A> result)
        //{
        //    try
        //    {
        //        List<ECRM_T002_A> Export_List = new List<ECRM_T002_A>();
        //        foreach (var o in DataGridCollection)
        //        {
        //            ECRM_T002_A Data = o as ECRM_T002_A;
        //            Export_List.Add(Data);
        //        }

        //        //--------------------------------------

        //        ExportToExcel<ECRM_T002_A, List<ECRM_T002_A>> export = new ExportToExcel<ECRM_T002_A, List<ECRM_T002_A>>();
        //        ICollectionView view = CollectionViewSource.GetDefaultView(Export_List);
        //        export.dataToPrint = (List<ECRM_T002_A>)view.SourceCollection;

        //        export.GenerateReport();
        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format(ex.Message, this.Title);
        //        showMessageService.ShowMessage();
        //    }

        //}
        protected override void OnDocumentAction()
        {
            OpenDocumentViewer(SelectedECRM_T002_A.quality_feedback_no);
        }
        protected override void OnRefreshCommand(InquiryActionResult<ECRM_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ECRM_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ECRM_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ECRM_T002_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ECRM_T002_A> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region "Filters"      
        #region Filters For Defect_desc
        private void FilterCollectionDefect_desc()
        {
            if (_Defect_descCollection != null)
            {
                _Defect_descCollection.Refresh();
            }

        }
        public string FilterStringDefect_desc
        {
            get { return _filterStringDefect_desc; }
            set
            {
                _filterStringDefect_desc = value;
                RaisePropertyChanged("FilterStringDefect_desc");
                FilterCollectionDefect_desc();
            }
        }
        public bool Defect_descFilter(object obj)
        {
            var data = obj as ZADM_M016_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringDefect_desc))
                {
                    return (
                        (data.dfctdsc != null && data.dfctdsc.ToString().ToLower().Contains(_filterStringDefect_desc.ToLower())) ||
                        (data.scope != null && data.scope.ToString().ToLower().Contains(_filterStringDefect_desc.ToLower()))

                        );

                }
                return true;
            }
            return false;
        }

        #endregion     
        #region "Filter for Back Content Datagrid"
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
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ECRM_T002_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.quality_feedback_no != null && data.quality_feedback_no.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.quality_feedback_date != null && data.quality_feedback_date.ToString().ToLower().Contains(_filterString.ToLower())) ||

                    (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.ModelNm != null && data.ModelNm.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.product_name != null && data.product_name.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.rtqfr_no != null && data.rtqfr_no.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    (data.defected_qty != null && data.defected_qty.ToString().ToLower().Contains(_filterString.ToLower())
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
