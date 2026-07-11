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
using Reflection.Presentation.Common;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class ECRM_T001_C_VM : WorkspaceViewModel<ECRM_T001_C>
    {
        #region Variable Declaration And Object 
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        bool NewRecord = true;
        WebServiceRepository<ECRM_T001_C> repository = new WebServiceRepository<ECRM_T001_C>();
        WebServiceRepository<MultipleContext_ECRM_T001_C> repository_MC = new WebServiceRepository<MultipleContext_ECRM_T001_C>();
        WebServiceRepository<MultipleContext_ECRM_T001_C> repository_MCTemp = new WebServiceRepository<MultipleContext_ECRM_T001_C>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_ECRM_T001_C _MC = new MultipleContext_ECRM_T001_C();
        public MultipleContext_ECRM_T001_C MC
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

        private MultipleContext_ECRM_T001_C _MCTemp = new MultipleContext_ECRM_T001_C();
        public MultipleContext_ECRM_T001_C MCTemp
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

        private ECRM_T001_C _MasterEntity;
        public ECRM_T001_C MasterEntity
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

        private ECRM_T001_C _MasterEntityTemp;
        public ECRM_T001_C MasterEntityTemp
        {
            get
            {
                return _MasterEntityTemp;
            }
            set
            {
                if (_MasterEntityTemp != value)
                {
                    _MasterEntityTemp = value;
                    RaisePropertyChanged("MasterEntityTemp");
                    value.BeginEdit();
                }
            }
        }

        private ObservableCollection<ECRM_T001_D> _ItemsEntity;
        //Data source for Items DataGrid
        public ObservableCollection<ECRM_T001_D> ItemsEntity
        {
            get
            {
                return _ItemsEntity;
            }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value;
                    // ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("ItemsEntity");
                }
            }
        }

        private int _dgSelectedIndex;
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

        private int _dgSelectedIndexItem;
        public int dgSelectedIndexItem
        {
            get
            {
                return _dgSelectedIndexItem;
            }
            set
            {
                if (_dgSelectedIndexItem != value)
                {
                    _dgSelectedIndexItem = value;
                    RaisePropertyChanged("dgSelectedIndexItem");

                }
            }
        }   

        private string _LocalVariable;
        public string LocalVariable
        {
            get
            {
                return _LocalVariable;
            }
            set
            {
                if (_LocalVariable != value)
                {

                    _LocalVariable = value;
                    RaisePropertyChanged("LocalVariable");
                }
            }
        }
        private int _selectedTabControlIndex; // Added by santosh
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

        #region ICollection
        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private ICollectionView _sample_AnalysisCollection;
        public ICollectionView Sample_AnalysisCollection
        {
            get { return _sample_AnalysisCollection; }
            set { _sample_AnalysisCollection = value; RaisePropertyChanged("Sample_AnalysisCollection"); }
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

        #region StringList Variables
        private List<ECRM_T001_C_Flip> _FlipGridData;
        public List<ECRM_T001_C_Flip> FlipGridData
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
        public List<string> _stringListSample_Analysis;
        public List<string> StringListSample_Analysis
        {
            get
            {
                return _stringListSample_Analysis;
            }
            set
            {
                _stringListSample_Analysis = value;
                RaisePropertyChanged("StringListSample_Analysis");
            }
        }


        #endregion

        #region Event
       
        private void ModelUpdated_Item(object sender, EventArgs e)
        {
            LocalVariable = MasterEntity.sa_no;
            this.ErrorExist = MasterEntity.HasErrors;
        }

        private void ModelUpdated_Master(object sender, EventArgs e)
        {
            LocalVariable = MasterEntity.location_Id;
            this.ErrorExist = MasterEntity.HasErrors;
        }
        #endregion

        #region RelayCommand
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> CommandSampleAnalysisChanged { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> cmdPrint { get; private set; }
        public RelayCommand<object> CommandLoadBackFlipData { get; private set; }
        #endregion

        #region User Defined Functions
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_cat = "SAR";
            MasterEntity.doc_type = "SAR";
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.sr_no = "";
            MasterEntity.sr_date = DateTime.Now;

            SearchEntityObject.from_date = DateTime.Now.Date;
            SearchEntityObject.to_date = DateTime.Now.Date;
            SearchEntityObject.active = true;
        }
        #endregion

        #region validation
        private bool Validation()
        {
            try
            {
                if (MasterEntity.sa_no == null || MasterEntity.sa_no == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Sample Analysis Number Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                //if (MasterEntity.analysis_for == null || MasterEntity.analysis_for == "")
                //{
                //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //    showMessageService.ButtonSetup = DialogButton.Ok;
                //    showMessageService.Caption = "Required";
                //    showMessageService.Text = String.Format("Analysis For Is Required", this.Title);
                //    showMessageService.ShowMessage();
                //    return false;
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
            return true;
        }
        #endregion

        #region Constructor
        public ECRM_T001_C_VM(string ts_code)
            : base()
        {
            SearchEntityObject = new SearchEntity();
            this.ts_code_vm = ts_code;
            MasterEntityTemp = new ECRM_T001_C();
            MasterEntity = new ECRM_T001_C();
            ItemsEntity = new ObservableCollection<ECRM_T001_D>();
            FlipGridData = new List<ECRM_T001_C_Flip>();
            MC = new MultipleContext_ECRM_T001_C();
            MCTemp = new MultipleContext_ECRM_T001_C();
            MasterEntity.ValidateAsync().Wait();
            ECRM_T001_C.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            ECRM_T001_D.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            LoadInitialData();
        }
        public ECRM_T001_C_VM(string ts_code, string doc_no)
            : base()
        {
            SearchEntityObject = new SearchEntity();
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;

            MasterEntityTemp = new ECRM_T001_C();
            MasterEntity = new ECRM_T001_C();
            ItemsEntity = new ObservableCollection<ECRM_T001_D>();
            FlipGridData = new List<ECRM_T001_C_Flip>();
            MC = new MultipleContext_ECRM_T001_C();
            MCTemp = new MultipleContext_ECRM_T001_C();
            MasterEntity.ValidateAsync().Wait();
            ECRM_T001_C.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            ECRM_T001_D.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            try
            {

                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CommandSampleAnalysisChanged = new RelayCommand<object>(items => { if (items == null) { return; } Insert_SampleAnalysis(items); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CommandDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
                cmdPrint = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } PrintDocuments(cmdPara); });
                CommandLoadBackFlipData = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items); });

                MasterEntity.doc_cat = "SAR";
                MasterEntity.doc_type = "SAR";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ECRM_T001_C>(MC, Request, "Sample_Response", "CRM", "LoadAll", 0, "");

                //FlipGridData = MC.DocumentDataFlipGrid.ToList();
                //DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                //DataGridCollection.Filter = new Predicate<object>(Filter);

                Sample_AnalysisCollection = CollectionViewSource.GetDefaultView(MC.SampleAnalysis.ToList());
                Sample_AnalysisCollection.Filter = new Predicate<object>(FilterSample);
                StringListSample_Analysis = MC.SampleAnalysis.Select(x => x.sa_no).ToList();

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
                    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
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

        #region Relay Command Actions 
        private MultipleContext_ECRM_T001_A _MCTempRS = new MultipleContext_ECRM_T001_A();
        public MultipleContext_ECRM_T001_A MCTempRS
        {
            get { return _MCTempRS; }
            set
            {
                if (_MCTempRS != value)
                {
                    _MCTempRS = value; RaisePropertyChanged("MCTemp");
                }
            }
        }
        private void PrintDocuments(object InputValue)
        {
            WebServiceRepository<MultipleContext_ECRM_T001_A> repository_MCTempRS = new WebServiceRepository<MultipleContext_ECRM_T001_A>();
            try
            {
                string ReportName = "";
                if (MasterEntity.sa_no != null && MasterEntity.sa_no != " ")
                {
                    string Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + MasterEntity.sa_no;
                    MCTempRS = repository_MCTempRS.GetDataWithReturnDomainObject<MultipleContext_ECRM_T001_A>(MCTempRS, Request, "Sample_Analysis", "CRM", "", 0, Request);


                    object[] objDataSource = new object[4];
                    string[] objDataSourceName = new string[4];

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[0] = Result;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    objDataSource[2] = MCTempRS.MasterDetails;
                    objDataSource[3] = MCTempRS.ItemsDetails;

                    objDataSourceName[0] = "dsLocation";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsSampleAnalysisMaster";
                    objDataSourceName[3] = "dsSampleAnalysisItem";

                    ReportManager ReportManager = new ReportManager();

                    ReportName = "SampleAnalysis.rdlc";

                    string ReportDisplayName = MCTempRS.MasterDetails[0].sample_frm + "_" + MasterEntity.sa_no + "_" + MCTempRS.MasterDetails[0].sa_date.Value.ToShortDateString();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, getParametersList(), ReportDisplayName);

                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Select Sample Analysis No.....", this.Title);
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
            try
            {
                result.Add("prepare_by", AppSessionState.Name);
            }
            catch (Exception ex)
            {
            }
            return result;
        }
        private void Insert_SampleAnalysis(object InputValue)
        {
            string Request = "";
            ECRM_T001_A_Sample POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.SampleAnalysis.Where(x => x.sa_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ECRM_T001_A_Sample>().ToList()[0];
                }

                if (POPUPEntityObject != null)
            {
                MasterEntity.sa_no = POPUPEntityObject.sa_no;
                MasterEntity.smoth_cb = POPUPEntityObject.smoth;
                MasterEntity.fading_cb = POPUPEntityObject.fadng;
                MasterEntity.ild_cb = POPUPEntityObject.ild;
                MasterEntity.gooping_cb = POPUPEntityObject.gooping;
                MasterEntity.skiping_cb = POPUPEntityObject.skiping;
                MasterEntity.deep_light_cb = POPUPEntityObject.deep_light;
                MasterEntity.wavi_cb = POPUPEntityObject.waviness;
                MasterEntity.static_lkg_cb = POPUPEntityObject.stat_lickage;
                MasterEntity.wrt_len_cb = POPUPEntityObject.wrt_length;
                MasterEntity.wrt_length_req = POPUPEntityObject.wrt_length_req;
                MasterEntity.ck_material_cb = POPUPEntityObject.ch_matrl;
                MasterEntity.ck_ball_dia_cb = POPUPEntityObject.ch_ball;
                MasterEntity.prepare_drg_cb = POPUPEntityObject.prepare_digram;
                MasterEntity.match_model_cb = POPUPEntityObject.mch_esem_model;
                MasterEntity.int_geometry_cb = POPUPEntityObject.in_geometry;
                MasterEntity.other_req1_cb = POPUPEntityObject.other_req1;
                MasterEntity.wrt_length_req = POPUPEntityObject.wrt_length_req;
                MasterEntity.sa_date = POPUPEntityObject.sa_date;

                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }

        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                string ParametersStringValue = "";
                ECRM_T001_C_Flip ParameterEntityObject = null;
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    if (ParameterReference == "DocumentNumber")
                    {
                        ParametersStringValue = ParameterObject.ToString().Trim();
                    }

                    if (ParametersStringValue.Length > 0)
                    {
                        try
                        { Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParametersStringValue; }
                        catch (Exception ex) { }
                    }
                }
                else if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<ECRM_T001_C_Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ECRM_T001_C_Flip>().ToList()[0];
                        Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParameterEntityObject.sr_no;
                        NewRecord = false;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ECRM_T001_C>(MCTemp, Request, "Sample_Response", "CRM", "", 0, Request);
                        MasterEntity = MCTemp.MasterDetails[0];
                        ItemsEntity = MCTemp.ItemsDetails;
                    }
                }
                SelectedTabControlIndex = 0;
                SetBusinessEntitiesAfterLoad(ParametersStringValue, "");
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        private void LoadBackFlipData(object Parameter)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + Convert.ToDateTime(SearchEntityObject.from_date).ToString() + "!@" + Convert.ToDateTime(SearchEntityObject.to_date).ToString() + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + AppSessionState.EmpId + "!@" + SearchEntityObject.active;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ECRM_T001_A>(MCTemp, Request, "Sample_Response", "CRM", "LoadAll", 0, "");

                FlipGridData = MCTemp.DocumentDataFlipGrid.ToList();
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

        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i)
                {
                    ItemsEntity.RemoveAt(i);
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        #endregion

        #region Filter
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
            var data = obj as ECRM_T001_C_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return (data.sr_no != null && data.sr_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.sr_date != null && data.sr_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.sa_no != null && data.sa_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.analysis_for != null && data.analysis_for.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.samp_details != null && data.samp_details.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.test_no != null && data.test_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.sa_date != null && data.sa_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.sample_re_date != null && data.sample_re_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.ball_material != null && data.ball_material.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_Sample;
        public string FilterString_Sample
        {
            get { return _filterString_Sample; }
            set
            {
                _filterString_Sample = value;
                RaisePropertyChanged("FilterString_Sample");
                FilterCollectionSample();
            }
        }
        private void FilterCollectionSample()
        {
            if (_sample_AnalysisCollection != null)
            {
                _sample_AnalysisCollection.Refresh();
            }
        }
        public bool FilterSample(object obj)
        {
            var data = obj as ECRM_T001_A_Sample;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Sample))
                {
                    return (data.sa_no != null && data.sa_no.ToString().ToLower().Contains(_filterString_Sample.ToLower()) ||
                         data.sa_date != null && data.sa_date.ToString().ToLower().Contains(_filterString_Sample.ToLower()) ||
                         data.smoth != null && data.smoth.ToString().ToLower().Contains(_filterString_Sample.ToLower()) ||
                         data.fadng != null && data.fadng.ToString().ToLower().Contains(_filterString_Sample.ToLower()) ||
                         data.ild != null && data.ild.ToString().ToLower().Contains(_filterString_Sample.ToLower()) ||
                         data.gooping != null && data.gooping.ToString().ToLower().Contains(_filterString_Sample.ToLower()) ||
                         data.skiping != null && data.skiping.ToString().ToLower().Contains(_filterString_Sample.ToLower()) ||
                         data.deep_light != null && data.deep_light.ToString().ToLower().Contains(_filterString_Sample.ToLower()) ||
                         data.waviness != null && data.waviness.ToString().ToLower().Contains(_filterString_Sample.ToLower()) ||
                         data.stat_lickage != null && data.stat_lickage.ToString().ToLower().Contains(_filterString_Sample.ToLower()) ||
                         data.wrt_length != null && data.wrt_length.ToString().ToLower().Contains(_filterString_Sample.ToLower()) ||
                         data.ch_ball != null && data.ch_ball.ToString().ToLower().Contains(_filterString_Sample.ToLower()) ||
                         data.ch_matrl != null && data.ch_matrl.ToString().ToLower().Contains(_filterString_Sample.ToLower()) ||
                         data.prepare_digram != null && data.prepare_digram.ToString().ToLower().Contains(_filterString_Sample.ToLower()) ||
                         data.mch_esem_model != null && data.mch_esem_model.ToString().ToLower().Contains(_filterString_Sample.ToLower()) ||
                         data.in_geometry != null && data.in_geometry.ToString().ToLower().Contains(_filterString_Sample.ToLower()) ||
                         data.other_req != null && data.other_req.ToString().ToLower().Contains(_filterString_Sample.ToLower()) ||
                         data.wrt_length_req != null && data.wrt_length_req.ToString().ToLower().Contains(_filterString_Sample.ToLower()));


                }
                return true;
            }
            return false;
        }

        #endregion

        #region Abstract Method
        protected override void OnCreateAction(InquiryActionResult<ECRM_T001_C> result)
        {
            NewRecord = true;
            MasterEntity = new ECRM_T001_C();
            MasterEntity.ValidateAsync().Wait();
            ItemsEntity = new ObservableCollection<ECRM_T001_D>();
            ItemsEntity.Clear();
            DefaultValues();
        }

        protected override void OnDiscardAction(InquiryActionResult<ECRM_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<ECRM_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<ECRM_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<ECRM_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<ECRM_T001_C> result)
        {
            try
            {
                string ReportName = "";
                if (MasterEntity.sr_no != null && MasterEntity.sr_no != " ")
                {
                    string Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + MasterEntity.sr_no;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ECRM_T001_A>(MCTemp, Request, "Sample_Response", "CRM", "", 0, Request);


                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[0] = Result;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    objDataSource[2] = MCTemp.MasterDetails;
                   // objDataSource[3] = MCTemp.ItemsDetails;

                    objDataSourceName[0] = "dsLocation";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsSAR";
                    //objDataSourceName[3] = "dsSampleAnalysisItem";

                    ReportManager ReportManager = new ReportManager();
                    ReportName = "SAR.rdlc";
                    string ReportDisplayName = MasterEntity.sr_no + "_" + MasterEntity.sr_date.Value.ToShortDateString();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, getParametersList(), ReportDisplayName);

                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Select SAR No.....", this.Title);
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
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.sr_no))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.sr_no.Replace("/", "--"), DocumentList = MCTemp.Attachment, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<ECRM_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ECRM_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ECRM_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ECRM_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ECRM_T001_C> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnRemoveAction(InquiryActionResult<ECRM_T001_C> result)
        {
            try
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Delete Changes";
                showMessageService.Text =
                    String.Format(
                        "This record will be Deleted forever '{0}'",
                            this.Title);
                if (showMessageService.ShowMessage() == DialogResult.Ok)
                {
                    this.MasterEntity.EndEdit();
                    string response = repository.Delete(MasterEntity.sa_no, "Sample_Response", "CRM");
                    MasterEntity = new ECRM_T001_C();
                    ItemsEntity = new ObservableCollection<ECRM_T001_D>();
                    _dataGridCollection.Refresh();
                    NewRecord = true;

                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }

        protected override void OnSaveAction(InquiryActionResult<ECRM_T001_C> result)
        {
            try
            {
                if (Validation() == true)
                {
                    //DefaultValues();
                    MasterEntity.XmlDataDocument_ECRM_T001_D = obj.ObjectToXML(ItemsEntity);

                    this.MasterEntity.EndEdit();
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ECRM_T001_C>(MasterEntity, "Sample_Response", "CRM");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ECRM_T001_C>(MasterEntity, "Sample_Response", "CRM");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    //if (MasterEntity.sr_no != null || MasterEntity.sr_no != "" && MasterEntity.active == true && NewRecord == false)
                    //{
                    //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    //    showMessageService.ButtonSetup = DialogButton.Ok;
                    //    showMessageService.Caption = "Message";
                    //    showMessageService.Text = String.Format("Data Updated Successfully");
                    //    showMessageService.ShowMessage();
                    //}
                    if (MasterEntity.sr_no != null || MasterEntity.sr_no != "" && MasterEntity.active == true )
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record saved Successfully ........");
                        showMessageService.ShowMessage();
                    }
                    NewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                }
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.XmlDataDocument_ECRM_T001_D != null && NewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<ECRM_T001_C_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ECRM_T001_C_Flip, MC.DocumentDataFlipGrid);
                    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                    DataGridCollection.Refresh();
                }
                MasterEntity.ts_code = ts_code_vm;
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }

        }

        
        #endregion
    }
}
