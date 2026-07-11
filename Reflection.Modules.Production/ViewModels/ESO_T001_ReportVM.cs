using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using System.ComponentModel;
using Reflection.ReportingServices;
using Reflection.BusinessEntity;

namespace Reflection.Modules.Production.ViewModels
{
    public class ESO_T001_ReportVM : WorkspaceViewModel<ESO_T001_RptEntity>
    {
        #region . Declaration .
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        bool blNew = true;
        WebServiceRepository<List<ESO_T001_rpt>> repository = new WebServiceRepository<List<ESO_T001_rpt>>();
        WebServiceRepository<MultipleContext_ESO_T001Report> repositoryM = new WebServiceRepository<MultipleContext_ESO_T001Report>();


        private ICollectionView _dataGridCollection;
        private string _filterString;
        private string _filterStringMachine;
        private string _filterStringDefect;
        private string _filterStringSorting;

        private int _dgSelectedIndex;
        private Dictionary<string, object> _items;
        private Dictionary<string, object> _selectedItems;

        private List<ESO_T001_rpt> _dsReport;
        public List<ESO_T001_rpt> dsReport
        {
            get { return _dsReport; }
            set
            {
                _dsReport = value;
            }
        }
        private Dictionary<string, string> _itemsDictionary;
        public Dictionary<string, string> ItemsDictionary
        {
            get { return _itemsDictionary; }
            set
            {
                if (_itemsDictionary != value)
                {
                    _itemsDictionary = value;
                    RaisePropertyChanged("ItemsDictionary");
                }
            }
        }


        #region ICollection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private ICollectionView _LoctnCollection;


        private ICollectionView _MachineCollection;//machine
        public ICollectionView MachineCollection
        {
            get { return _MachineCollection; }
            set
            {
                _MachineCollection = value;
                RaisePropertyChanged("MachineCollection");
            }
        }


        private ICollectionView _DefectCollection;//Defect
        public ICollectionView DefectCollection
        {
            get { return _DefectCollection; }
            set
            {
                _DefectCollection = value;
                RaisePropertyChanged("DefectCollection");
            }
        }

        private ICollectionView _SortingCollection;//ILD
        public ICollectionView SortingCollection
        {
            get { return _SortingCollection; }
            set
            {
                _SortingCollection = value;
                RaisePropertyChanged("SortingCollection");
            }
        }

      
        private int _selectedTabIndex;
        public int SelectedTabIndex
        {
            get { return _selectedTabIndex; }
            set
            {
                if (_selectedTabIndex != value)
                {
                    _selectedTabIndex = value;
                    RaisePropertyChanged("SelectedTabIndex");

                    if (SelectedTabIndex == 2)
                    {
                        //LoadSelectedTab();
                    }

                }
            }
        }
        #endregion

        #region RelayCommand

        public RelayCommand<IList> SelectionChangedCommandMachines //machine
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandUOM //UOM
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandDefect//ILD
        {
            get;
            private set;
        }

        public RelayCommand<IList> CellChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }


        #endregion

        #region ESO_T001

        private ESO_T001_RptEntity _ReportParameters;
        public ESO_T001_RptEntity ReportParameters
        {
            get
            {
                this.ErrorExist = _ReportParameters.HasErrors;
                return _ReportParameters;
            }
            set
            {
                if (_ReportParameters != value)
                {
                    _ReportParameters = value;
                    this.ErrorExist = _ReportParameters.HasErrors;
                    RaisePropertyChanged("ReportParameters");
                    value.BeginEdit();
                }
            }
        }
        private ESO_T001_ReportParameter _SelectedSortingReport;
        public ESO_T001_ReportParameter SelectedSortingReport
        {
            get
            {
                return _SelectedSortingReport;
            }
            set
            {
                if (_SelectedSortingReport != value)
                {
                    _SelectedSortingReport = value;
                    RaisePropertyChanged("SelectedSortingReport");

                }
            }
        }
        private static ObservableCollection<ESO_T001> _SortingDetails = new ObservableCollection<ESO_T001>();
        public ObservableCollection<ESO_T001> SortingDetails
        {
            get { return _SortingDetails; }
            set
            {
                if (_SortingDetails != value)
                {
                    _SortingDetails = value;
                    RaisePropertyChanged("SortingDetails");
                }
            }
        }
        #endregion

        #region ZADM_M013_P
        private List<ZADM_M013_P> _SelectedListOfMachines;
        public List<ZADM_M013_P> SelectedListOfMachines
        {
            get { return _SelectedListOfMachines; }
            set
            {
                if (_SelectedListOfMachines != value)
                {
                    _SelectedListOfMachines = value;
                    RaisePropertyChanged("SelectedListOfMachines");
                }
            }
        }

        private ObservableCollection<ZADM_M013_P> _MachineList;
        public ObservableCollection<ZADM_M013_P> MachineList
        {
            get { return _MachineList; }
            set
            {
                _MachineList = value;
                RaisePropertyChanged("MachineList");
            }
        }

        private ZADM_M013_P _SelectedMachineList;
        public ZADM_M013_P SelectedMachineList
        {
            get { return _SelectedMachineList; }
            set
            {
                if (_SelectedMachineList != value)
                {
                    _SelectedMachineList = value;

                    RaisePropertyChanged("SelectedMachineList");
                   
                }
            }
        }
        #endregion

        #region ADM_M038_B_P
        private List<ADM_M038_B_P> _SelectedListOfUOM;
        public List<ADM_M038_B_P> SelectedListOfUOM
        {
            get { return _SelectedListOfUOM; }
            set
            {
                if (_SelectedListOfUOM != value)
                {
                    _SelectedListOfUOM = value;
                    RaisePropertyChanged("SelectedListOfUOM");
                }
            }
        }
        private ObservableCollection<ADM_M038_B_P> _UOMList;
        public ObservableCollection<ADM_M038_B_P> UOMList
        {
            get { return _UOMList; }
            set
            {
                _UOMList = value;
                RaisePropertyChanged("UOMList");
            }
        }

        private ADM_M038_B_P _SelectedUOMList;
        public ADM_M038_B_P SelectedUOMList
        {
            get { return _SelectedUOMList; }
            set
            {
                if (_SelectedUOMList != value)
                {
                    _SelectedUOMList = value;


                    RaisePropertyChanged("SelectedUOMList");
                   
                }
            }
        }
        #endregion

        #region ZADM_M016_P
        private List<ZADM_M016_P> _SelectedListOfDefects;
        public List<ZADM_M016_P> SelectedListOfDefects
        {
            get { return _SelectedListOfDefects; }
            set
            {
                if (_SelectedListOfDefects != value)
                {
                    _SelectedListOfDefects = value;
                    RaisePropertyChanged("SelectedListOfDefects");
                }
            }
        }

        private ObservableCollection<ZADM_M016_P> _DefectList;
        public ObservableCollection<ZADM_M016_P> DefectList
        {
            get { return _DefectList; }
            set
            {
                _DefectList = value;
                RaisePropertyChanged("DefectList");
            }
        }

        private ZADM_M016_P _SelectedDefectList;
        public ZADM_M016_P SelectedDefectList
        {
            get { return _SelectedDefectList; }
            set
            {
                if (_SelectedDefectList != value)
                {
                    _SelectedDefectList = value;


                    RaisePropertyChanged("SelectedDefectList");
                  
                }
            }
        }
        #endregion

        #region ESO_T001_P
        private List<ESO_T001_P> _SelectedListOfSort;
        public List<ESO_T001_P> SelectedListOfSort
        {
            get { return _SelectedListOfSort; }
            set
            {
                if (_SelectedListOfSort != value)
                {
                    _SelectedListOfSort = value;
                    RaisePropertyChanged("SelectedListOfSort");
                }
            }
        }

        private ObservableCollection<ESO_T001_P> _SortList;
        public ObservableCollection<ESO_T001_P> SortList
        {
            get { return _SortList; }
            set
            {
                _SortList = value;
                RaisePropertyChanged("SortList");
            }
        }

        private ESO_T001_P _SelectedSortList;
        public ESO_T001_P SelectedSortList
        {
            get { return _SelectedSortList; }
            set
            {
                if (_SelectedSortList != value)
                {
                    _SelectedSortList = value;

                    RaisePropertyChanged("SelectedSortList");
                   
                }
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
        MultipleContext_ESO_T001Report _MC = new MultipleContext_ESO_T001Report();
        public MultipleContext_ESO_T001Report MC
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
        #endregion
        public ESO_T001_ReportVM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            ReportParameters = new ESO_T001_RptEntity();
            dsReport = new List<ESO_T001_rpt>();
            _dsReport = new List<ESO_T001_rpt>();
            SortingDetails = new ObservableCollection<ESO_T001>();
            ReportParameters.ValidateAsync().Wait();
            MC = new MultipleContext_ESO_T001Report();

            ItemsDictionary = new Dictionary<string, string>();
            ItemsDictionary.Add("R001", "Daily Defect Observation Report");
            ItemsDictionary.Add("R002", "Datewise Defect Report");
            ItemsDictionary.Add("R003", "Machinewise All Defects Report");

            
            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            ReportParameters.FrmDate = lastDayLastMonth.AddDays(-60);
           
            ReportParameters.ToDate = DateTime.Now;
            ReportParameters.SortingDate = DateTime.Now;
            ReportParameters.prod_dt = DateTime.Now;
            ReportParameters.entry_dt = System.DateTime.Now;
            ReportParameters.shift = "Both";
            LoadInitialData();
        }

        #region . User Defined Function .
       

        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<ESO_T001_RptEntity> tSelectedItemsList = list.Cast<ESO_T001_RptEntity>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                ReportParameters = (ESO_T001_RptEntity)tSelectedItemsList[0];
                blNew = false;
            }
        }

        private void GetSelectedMachine(IList machineList)
        {
            IList list = machineList as IList;
            List<ZADM_M013_P> Selectedmachinelist = list.Cast<ZADM_M013_P>().ToList();
            if (Selectedmachinelist.Count > 0)
            {
                ReportParameters.machinecode = Selectedmachinelist[0].machinecode;
            }
        }

        private void GetSelectedDefectDetails(IList defectList)
        {
            try
            {
                if (dgSelectedIndex != -1 && defectList.Count > 0)
                {
                    IList list = defectList as IList;
                    List<ZADM_M016_P> SelectedDefectDetailsTemp = list.Cast<ZADM_M016_P>().ToList();
                    if (SelectedDefectDetailsTemp.Count > 0)
                    {

                        ReportParameters.defects = SelectedDefectDetailsTemp[0].dfctdsc;
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
                    Request = ReportParameters.client + "!@" + ReportParameters.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        private void LoadInitialData()
        {
            try
            {

                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();           
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ESO_T001Report>(MC, Request, "SortingReport", "Production", "LoadAll", 0,"");
                //SelectedListOfSort = MC.SortList;

                #region Command Initialisation
                SelectionChangedCommandMachines = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedMachine(items); });
                SelectionChangedCommandDefect = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedDefectDetails(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion

                MachineCollection = CollectionViewSource.GetDefaultView(MC.MachineCodeList);
                MachineCollection.Filter = new Predicate<object>(MachineFilter);
                //StringListMachine = MC.MasterEntity.Select(x => x.machine_id.ToString()).ToList();

                DefectCollection = CollectionViewSource.GetDefaultView(MC.DefectList);
                DefectCollection.Filter = new Predicate<object>(DefectFilter);
                //StringListDefect = MC.MasterEntity.Select(x => x.defects.ToString()).ToList();


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
        private IEnumerable<T> MakeMeEnumerable<T>(T Entity)
        {
            yield return Entity;
        }
        protected override void OnSaveAction(InquiryActionResult<ESO_T001_RptEntity> result)
        {
        }
        protected override void OnCreateAction(InquiryActionResult<ESO_T001_RptEntity> result)
        {
            blNew = true;
            SortingDetails = new ObservableCollection<ESO_T001>();
            ReportParameters = new ESO_T001_RptEntity();
            ReportParameters.ValidateAsync().Wait();
        }
        protected override void OnRemoveAction(InquiryActionResult<ESO_T001_RptEntity> result)
        {
        }
        protected override void OnDiscardAction(InquiryActionResult<ESO_T001_RptEntity> result)
        {
        }
        protected override void OnFevoriteAction(InquiryActionResult<ESO_T001_RptEntity> result)
        {
        }
        protected override void OnFlipAction(InquiryActionResult<ESO_T001_RptEntity> result)
        {
        }
        protected override void OnHelpAction(InquiryActionResult<ESO_T001_RptEntity> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<ESO_T001_RptEntity> result)
        {
            if (ReportParameters.ReportCode == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Report Type");
                showMessageService.ShowMessage();
            }
            if (ReportParameters.ReportCode.ToString() != "")
            {
               if (ReportParameters.shift == null) {ReportParameters.shift = "Both";}
               if (ReportParameters.Engineer == null){ ReportParameters.Engineer = "ALL";}
               if (ReportParameters.machinecode == null){ReportParameters.machinecode = "ALL"; }
               if (ReportParameters.defects == null){ReportParameters.defects = "ALL"; }
            }
            string RequestParameter = "Report" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.comp_code + "!@"+ ReportParameters.location_Id + "!@" + ReportParameters.shift + "!@" + Convert.ToDateTime(ReportParameters.SortingDate).ToString("dd/MM/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.FrmDate).ToString("dd/MM/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("dd/MM/yyyy") + "!@"+ Convert.ToDateTime(ReportParameters.prod_dt).ToString("dd/MM/yyyy")+"!@" + ReportParameters.machinecode + "!@" + ReportParameters.defects + "!@" + ReportParameters.EmpId + "!@" + ReportParameters.doc_cat + "!@" + ReportParameters.unit_code;
            if (ReportParameters.ReportCode.ToString() != "")
            {
                dsReport = repository.GetDataWithReturnDomainObject<List<ESO_T001_rpt>>(dsReport, RequestParameter, "SortingReport", "Production", "", 0, RequestParameter);
                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(dsReport, "dsESO_T001_rpt", "\\Production\\" + GetReportFile(ReportParameters.ReportCode), getParametersList());
               
            }
          
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ESO_T001_RptEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ESO_T001_RptEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ESO_T001_RptEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ESO_T001_RptEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ESO_T001_RptEntity> result)
        {
            throw new NotImplementedException();
        }
        #endregion
        private string GetReportFile(string ReportCode)
        {
            string returnReportName = "";
            if (ReportCode == "R001")
            {
                returnReportName = "Sorting_DailyDefectObsRpt.rdlc";
            }
            if (ReportCode == "R002")
            {
                returnReportName = "DatewiseDefectRpt.rdlc";
            }
            if (ReportCode == "R003")
            {
                returnReportName = "MachinwiseAllDefects.rdlc";
            }
    
            return returnReportName;
        }
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("FrmDate", Convert.ToString(ReportParameters.FrmDate));
            result.Add("ToDate", Convert.ToString(ReportParameters.ToDate));
            result.Add("EntryDate", Convert.ToString(ReportParameters.SortingDate));

            if (ReportParameters.shift == null) { ReportParameters.shift = "Both"; }
            if (ReportParameters.Engineer == null) { ReportParameters.Engineer = "ALL"; }
            if (ReportParameters.machinecode == null) { ReportParameters.machinecode = "ALL"; }
            if (ReportParameters.defects == null) { ReportParameters.defects = "ALL"; }

            result.Add("shift", (ReportParameters.shift));
            result.Add("Engineer", (ReportParameters.Engineer));
            result.Add("machine", (ReportParameters.machinecode));
            result.Add("defect", (ReportParameters.defects));
            return result;
        }

        #region . Filters .

        #region Filters For Machine
        private void FilterCollectionMachine()
        {
            if (_MachineCollection != null)
            {
                _MachineCollection.Refresh();
            }
        }
        public string FilterStringMachine
        {
            get { return _filterStringMachine; }
            set
            {
                _filterStringMachine = value;
                RaisePropertyChanged("FilterStringMachine");
                FilterCollectionMachine();
            }
        }
        public bool MachineFilter(object obj)
        {
            var data = obj as ZADM_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMachine))
                {
                    return ((data.machinecode != null) && data.machinecode.ToLower().Contains(_filterStringMachine.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Defect
        private void FilterCollectionDefect()
        {
            if (_DefectCollection != null)
            {
                _DefectCollection.Refresh();
            }
        }
        public string FilterStringDefect
        {
            get { return _filterStringDefect; }
            set
            {
                _filterStringDefect = value;
                RaisePropertyChanged("FilterStringDefect");
                FilterCollectionDefect();
            }
        }
        public bool DefectFilter(object obj)
        {
            var data = obj as ZADM_M016_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringDefect))
                {
                    return ((data.dfctdsc != null) && data.dfctdsc.ToLower().Contains(_filterStringDefect.ToLower()));
                }
                return true;
            }
            return false;
        }

        

        #endregion

        #region Filters For Sorting
        //private void FilterCollectionSorting()
        //{
        //    if (_SortingCollection != null)
        //    {
        //        _SortingCollection.Refresh();
        //    }
        //}
        //public string FilterStringSorting
        //{
        //    get { return _filterStringSorting; }
        //    set
        //    {
        //        _filterStringSorting = value;
        //        RaisePropertychanged("FilterStringSorting");
        //        FilterCollectionSorting();
        //    }
        //}
        //public bool SortingFilter(object obj)
        //{
        //    var data = obj as ESO_T001;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_filterStringSorting))
        //        {
        //            return ((data.ItemCode != null) && data.ItemCode.ToLower().Contains(_filterStringSorting.ToLower())) ||
        //                   (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterStringSorting.ToLower())) ||
        //                   (data.CstmrItmCod != null && data.CstmrItmCod.ToString().ToLower().Contains(_filterStringSorting.ToLower())) ||
        //                   (data.CstmrItmDesc != null && data.CstmrItmDesc.ToString().ToLower().Contains(_filterStringSorting.ToLower())) ||
        //                   (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringSorting.ToLower()));

        //        }
        //        return true;
        //    }
        //    return false;
        //}

        #endregion

        #endregion


    }
}
