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
using Reflection.Presentation.Services;
using System.ComponentModel;
using Reflection.ReportingServices;
using Reflection.BusinessEntity;
using System.Data;
using Reflection.Presentation.Common;

namespace Reflection.Modules.Production.ViewModels
{
    public class MIS_Sorting_ReportsVM : WorkspaceViewModel<ESO_T001_RptEntity>
    {
        #region Variables Declaration

        bool blNew = true;
        WebServiceRepository<List<ESO_T001_rpt>> repository = new WebServiceRepository<List<ESO_T001_rpt>>();
        WebServiceRepository<MultipleContext_ESO_T001Report> repository_MC = new WebServiceRepository<MultipleContext_ESO_T001Report>();
        ObjectSerializationService obj = new ObjectSerializationService();
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
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

        private ESO_T001_RptEntity _ReportParameters;
        public ESO_T001_RptEntity ReportParameters
        {
            get
            {

                return _ReportParameters;
            }
            set
            {
                _ReportParameters = value;
                RaisePropertyChanged("ReportParameters");
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

        private Dictionary<string, string> _SortTyDictionary;
        public Dictionary<string, string> SortTyDictionary
        {
            get { return _SortTyDictionary; }
            set
            {
                if (_SortTyDictionary != value)
                {
                    _SortTyDictionary = value;
                    RaisePropertyChanged("SortTyDictionary");
                }
            }
        }

        private Dictionary<string, string> _SortCatDictionary;
        public Dictionary<string, string> SortCatDictionary
        {
            get { return _SortCatDictionary; }
            set
            {
                if (_SortCatDictionary != value)
                {
                    _SortCatDictionary = value;
                    RaisePropertyChanged("SortCatDictionary");
                }
            }
        }


        private Dictionary<string, string> _MachTypeDictionary;
        public Dictionary<string, string> MachTypeDictionary
        {
            get { return _MachTypeDictionary; }
            set
            {
                if (_MachTypeDictionary != value)
                {
                    _MachTypeDictionary = value;
                    RaisePropertyChanged("MachTypeDictionary");
                }
            }
        }
        private Dictionary<string, object> _PMTypeDictionary;
        public Dictionary<string, object> PMTypeDictionary
        {
            get { return _PMTypeDictionary; }
            set
            {
                if (_PMTypeDictionary != value)
                {
                    _PMTypeDictionary = value;
                    RaisePropertyChanged("PMTypeDictionary");
                }
            }
        }

        private List<ESO_T001_rpt> _dsReport;
        public List<ESO_T001_rpt> dsReport
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

        public List<ADM_M002> _ObjComp = new List<ADM_M002>();
        private List<ADM_M002> ObjComp
        {
            get { return _ObjComp; }
            set
            {
                if (_ObjComp != value)
                {
                    _ObjComp = value;
                }
            }
        }

        public List<ADM_M003> _ObjPlant = new List<ADM_M003>();
        private List<ADM_M003> ObjPlant
        {
            get { return _ObjPlant; }
            set
            {
                if (_ObjPlant != value)
                {
                    _ObjPlant = value;
                }
            }
        }


        private List<ZADM_M013_P> _strListMachine;
        public List<ZADM_M013_P> StrListMachine
        {
            get { return _strListMachine; }
            set
            {
                if (_strListMachine != value)
                {
                    _strListMachine = value;
                    RaisePropertyChanged("StrListMachine");
                }
            }
        }

        private List<ZADM_M016_P> _strListDefect;
        public List<ZADM_M016_P> StrListDefect
        {
            get { return _strListDefect; }
            set
            {
                if (_strListDefect != value)
                {
                    _strListDefect = value;
                    RaisePropertyChanged("StrListDefect");
                }
            }
        }

        #endregion

        #region ICollection
        private ICollectionView _ShiftCollection; //
        public ICollectionView ShiftCollection
        {
            get { return _ShiftCollection; }
            set
            {
                _ShiftCollection = value;
                RaisePropertyChanged("ShiftCollection");
            }
        }


        private ICollectionView _ShiftInchargeCollection;// Shiftincharge Collection
        public ICollectionView ShiftInchargeCollection
        {
            get { return _ShiftInchargeCollection; }
            set
            {
                _ShiftInchargeCollection = value;
                RaisePropertyChanged("ShiftInchargeCollection");
            }
        }
        private ICollectionView _CompanyCollection;
        public ICollectionView CompanyCollection
        {
            get { return _CompanyCollection; }
            set { _CompanyCollection = value; RaisePropertyChanged("CompanyCollection"); }
        }
        private ICollectionView _PlantCollection;
        public ICollectionView PlantCollection
        {
            get { return _PlantCollection; }
            set { _PlantCollection = value; RaisePropertyChanged("PlantCollection"); }
        }


        private ICollectionView _MachineCollection;// Machine Collection
        public ICollectionView MachineCollection
        {
            get { return _MachineCollection; }
            set
            {
                _MachineCollection = value;
                RaisePropertyChanged("MachineCollection");
            }
        }


        private ICollectionView _DefectListCollection;// Defect List For popup Collection
        public ICollectionView DefectListCollection
        {
            get { return _DefectListCollection; }
            set
            {
                _DefectListCollection = value;
                RaisePropertyChanged("DefectListCollection");
            }
        }

        private ICollectionView _uomCollection;
        public ICollectionView UomCollection
        {
            get { return _uomCollection; }
            set { _uomCollection = value; RaisePropertyChanged("UomCollection"); }
        }

        #endregion


        #region StringList Variables

        private List<string> _srtListCompany;
        public List<string> StringListCompany
        {
            get { return _srtListCompany; }
            set
            {
                if (_srtListCompany != value)
                {
                    _srtListCompany = value;
                }
            }
        }
        List<string> _strListPlant;
        public List<string> StringListPlant
        {
            get { return _strListPlant; }
            set
            {
                if (_strListPlant != value)
                {
                    _strListPlant = value;
                }
            }
        }


        List<string> _stringListMachine;
        public List<string> StringListMachine
        {
            get { return _stringListMachine; }
            set
            {
                if (_stringListMachine != value)
                {
                    _stringListMachine = value;
                }
            }
        }

        List<string> _StringListDefect;
        public List<string> StringListDefect
        {
            get { return _StringListDefect; }
            set
            {
                if (_StringListDefect != value)
                {
                    _StringListDefect = value;
                }
            }
        }

        List<string> _StringListShift;
        public List<string> StringListShift
        {
            get { return _StringListShift; }
            set
            {
                if (_StringListShift != value)
                {
                    _StringListShift = value;
                }
            }
        }

        List<string> _StringListShiftIncharge;
        public List<string> StringListShiftIncharge
        {
            get { return _StringListShiftIncharge; }
            set
            {
                if (_StringListShiftIncharge != value)
                {
                    _StringListShiftIncharge = value;
                }
            }
        }
        private List<ZADM_M013_P> _strListEngineer;
        public List<ZADM_M013_P> strListEngineer
        {
            get { return _strListEngineer; }
            set
            {
                if (_strListEngineer != value)
                {
                    _strListEngineer = value;
                    RaisePropertyChanged("strListEngineer");
                }
            }
        }

        #endregion

        #region RelayCommands      
        public RelayCommand CommandReport { get; private set; }
        public RelayCommand cmdClear { get; private set; }
        public RelayCommand<object> cmdShift { get; private set; }
        public RelayCommand<object> cmdShiftIncharge { get; private set; }
        public RelayCommand<object> cmdCompany { get; private set; }
        public RelayCommand<object> cmdPlant { get; private set; }
        public RelayCommand<object> cmdMachine { get; private set; }
        public RelayCommand<object> cmdDefect { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdUnitChange { get; private set; }
        #endregion

        #region Constructor
        public MIS_Sorting_ReportsVM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            CursorControl.SetBusyState();
            MC = new MultipleContext_ESO_T001Report();
            ReportParameters = new ESO_T001_RptEntity();
            dsReport = new List<ESO_T001_rpt>();
            _dsReport = new List<ESO_T001_rpt>();
            ItemsDictionary = new Dictionary<string, string>();

            ItemsDictionary.Add("R001", "Daily Defect Observation Report");
            ItemsDictionary.Add("R002", "Datewise Defect Report");
            ItemsDictionary.Add("R003", "Machinewise All Defects Report");
            ItemsDictionary.Add("R004", "MonthWise Report");
            ItemsDictionary.Add("R005", "Sorting Rejection Report");
            ItemsDictionary.Add("R006", "Machine/Shiftwise  All Defects Report");
            ItemsDictionary.Add("R007", "MonthWise Defect Report");
            ItemsDictionary.Add("R008", "MonthWise Machine Report");
            ItemsDictionary.Add("R009", "Top 5 Shift WiseDefects Report");
            ItemsDictionary.Add("R010", "Defect Condition Wise Report");
            ItemsDictionary.Add("R011", "Daily Rejection Report");
            ItemsDictionary.Add("R012", "Monthly Rejection Report");
            ItemsDictionary.Add("R013", "Sorting Details Report");

            SortTyDictionary = new Dictionary<string, string>();
            SortTyDictionary.Add("All", "All");
            SortTyDictionary.Add("MS", "Manual Sorting");
            SortTyDictionary.Add("AS", "Automatic Sorting");

            SortCatDictionary = new Dictionary<string, string>();
            SortCatDictionary.Add("C001", "All");
            SortCatDictionary.Add("C002", "Ball Sorting");
            SortCatDictionary.Add("C003", "Chip Sorting");

            MachTypeDictionary = new Dictionary<string, string>();
            MachTypeDictionary.Add("All", "All");
            MachTypeDictionary.Add("LX", "LX");
            MachTypeDictionary.Add("PM", "PM");

            //PMTypeDictionary = new Dictionary<string, string>();
            //PMTypeDictionary.Add("All", "All");
            //PMTypeDictionary.Add("PM1", "PM1");
            //PMTypeDictionary.Add("PM2", "PM2");


            DefaultValues();
            LoadInitialData();

        }
        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ESO_T001Report>(MC, Request, "SortingReport", "Production", "LoadAll", 0, "");

                #region Command Initialisation
                cmdCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
                cmdPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
                cmdShift = new RelayCommand<object>(items => { if (items == null) { return; } InsertShift(items); });
                cmdShiftIncharge = new RelayCommand<object>(items => { if (items == null) { return; } InsertShiftIncharge(items); });
                cmdMachine = new RelayCommand<object>(items => { if (items == null) { return; } InsertMachine(items); });
                cmdDefect = new RelayCommand<object>(items => { if (items == null) { return; } InsertDefect(items); });
                CommandReport = new RelayCommand(DisplayReport);
                cmdClear = new RelayCommand(ClearData);
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                cmdUnitChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertUnit(items); });

                #endregion
                ObjComp = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                CompanyCollection = CollectionViewSource.GetDefaultView(ObjComp.ToList());
                CompanyCollection.Filter = new Predicate<object>(FilterCompany);
                StringListCompany = ObjComp.Select(x => x.comp_code).ToList();

                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantCollection = CollectionViewSource.GetDefaultView(ObjPlant.ToList());
                PlantCollection.Filter = new Predicate<object>(FilterPlant);
                StringListPlant = ObjPlant.Select(x => x.location_Id).ToList();

                var LocWiseMachine = (from o in MC.MachineCodeList
                                      where o.location_Id == ReportParameters.location_Id
                                      select o).ToList();
                MachineCollection = CollectionViewSource.GetDefaultView(LocWiseMachine.ToList());
                MachineCollection.Filter = new Predicate<object>(MachineFilter);
                StringListMachine = MC.MachineCodeList.Select(x => x.machinecode.ToString()).ToList();

                DefectListCollection = CollectionViewSource.GetDefaultView(MC.DefectList);
                DefectListCollection.Filter = new Predicate<object>(DefectFilter);
                StringListDefect = MC.DefectList.Select(x => x.dfctdsc.ToString()).ToList();

                ShiftCollection = CollectionViewSource.GetDefaultView(MC.Shift);
                ShiftCollection.Filter = new Predicate<object>(FilterShift);
                StringListShift = MC.Shift.Select(x => x.shift.ToString()).ToList();

                ShiftInchargeCollection = CollectionViewSource.GetDefaultView(MC.ShiftIncharge);
                ShiftInchargeCollection.Filter = new Predicate<object>(FilterShiftIncharge);
                StringListShiftIncharge = MC.ShiftIncharge.Select(x => x.EmpId.ToString()).ToList();

                var EngineerParent = (from o in MC.EngineerDetails
                                      where o.location_Id == ReportParameters.location_Id
                                      select o).ToList();
                _strListEngineer = EngineerParent;
                PMTypeDictionary = _strListEngineer.ToDictionary(X => X.engineer.ToString(), X => (object)X.engineer);

                UomCollection = CollectionViewSource.GetDefaultView(MC.UOMList.ToList());
                UomCollection.Filter = new Predicate<object>(FilterUom);
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

            ReportParameters.doc_cat = "SR";
            ReportParameters.doc_type = "SR";
            ReportParameters.location_Id = AppSessionState.location_Id;
            ReportParameters.comp_code = AppSessionState.comp_code;
            ReportParameters.add_by = AppSessionState.UserID;
            ReportParameters.editby = AppSessionState.UserID;
            ReportParameters.doc_no = "";
            ReportParameters.active = true;
            ReportParameters.add_date = DateTime.Now;
            ReportParameters.entry_dt = System.DateTime.Now;
            ReportParameters.prod_dt = System.DateTime.Now;
            ReportParameters.fin_year = "16-17";
            ReportParameters.ts_code = ts_code_vm;

            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            ReportParameters.FrmDate = lastDayLastMonth.AddDays(0);
            ReportParameters.ToDate = DateTime.Now;
        }
        private void ClearData()
        {

            try
            {
                ReportParameters = new ESO_T001_RptEntity();
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
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            // LocalVariable = aCC_T001.PartyId;
            //this.ErrorExist = aCC_T001.HasErrors;
        }
        private void DisplayReport()
        {
            CursorControl.SetBusyState();
            try
            {
                if (ReportParameters.ReportCode == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Report Type");
                    showMessageService.ShowMessage();
                }

                if (ReportParameters.ReportCode != null)
                {
                    if (ReportParameters.shift == null) { ReportParameters.shift = "Both"; }
                    if (ReportParameters.shift_incharge == null) { ReportParameters.shift_incharge = "ALL"; }
                    if (ReportParameters.machinecode == null) { ReportParameters.machinecode = "ALL"; }
                    if (ReportParameters.defect_type == null) { ReportParameters.defect_type = "ALL"; }
                    if (ReportParameters.sort_type == null) { ReportParameters.sort_type = "ALL"; }
                    if (ReportParameters.sort_cat == null) { ReportParameters.sort_cat = "ALL"; }
                    if (ReportParameters.mctype == null) { ReportParameters.mctype = "ALL"; }
                    if (ReportParameters.engineer == null) { ReportParameters.engineer = "ALL"; }
                    if (ReportParameters.unit_code == null) { ReportParameters.unit_code = "ALL"; }
                }

                if (ReportParameters.ReportCode != null)
                {
                    string RequestParameter = "Report" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.comp_code + "!@" + ReportParameters.location_Id + "!@" + ReportParameters.shift + "!@" + Convert.ToDateTime(ReportParameters.entry_dt).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.FrmDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.prod_dt).ToString("MM/dd/yyyy") + "!@" + ReportParameters.machinecode + "!@" + ReportParameters.defect_type + "!@" + ReportParameters.EmpId + "!@" + ReportParameters.doc_cat + "!@" + ReportParameters.Sort_Code + "!@" + ReportParameters.sort_cat + "!@" + ReportParameters.fin_year + "!@" + ReportParameters.mctype + "!@" + ReportParameters.engineer + "!@" + ReportParameters.unit_code;
                    dsReport = repository.GetDataWithReturnDomainObject<List<ESO_T001_rpt>>(dsReport, RequestParameter, "SortingReport", "Production", "", 0, RequestParameter);

                    DateTime startDate = Convert.ToDateTime(ReportParameters.FrmDate);
                    DateTime endDate = Convert.ToDateTime(ReportParameters.ToDate);

                    int month = (endDate.Month - startDate.Month) + 1;
                    ReportParameters.no_of_months = month;

                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];

                    objDataSource[0] = dsReport;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == ReportParameters.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == ReportParameters.location_Id).ToList();
                    objDataSource[2] = Result;

                    objDataSourceName[0] = "dsMIS_Sorting_Report";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsLocation";

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\Production\\" + GetReportFile(ReportParameters.ReportCode), getParametersList(), "MIS_Sorting_Report");

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
        private string GetReportFile(string ReportCode)
        {
            string returnReportName = "";
            if (ReportCode == "R001")
            {
                returnReportName = "DailyDefectReport.rdlc";
            }
            if (ReportCode == "R002")
            {
                returnReportName = "DatewiseDefectReport.rdlc";
            }
            if (ReportCode == "R003")
            {
                returnReportName = "MachineWiseDefectReport.rdlc";
            }
            if (ReportCode == "R004")
            {
                returnReportName = "MonthWiseDefectReport.rdlc";
            }
            if (ReportCode == "R005")
            {
                returnReportName = "MachineWiseDefectReportHz.rdlc";
            }
            if (ReportCode == "R006")
            {
                returnReportName = "ShiftMachWiseDefect.rdlc";
            }
            if (ReportCode == "R007")
            {
                returnReportName = "DefectMonthWiseRpt.rdlc";
            }
            if (ReportCode == "R008")
            {
                returnReportName = "MachineMonthWiseRpt.rdlc";
            }
            if (ReportCode == "R009")
            {
                returnReportName = "Top5DefectReport.rdlc";
            }
            if (ReportCode == "R010")
            {
                returnReportName = "Defect_cond_ShiftMachWise.rdlc";
            }
            if (ReportCode == "R011")
            {
                returnReportName = "SortingDefectReport.rdlc";
            }
            if (ReportCode == "R012")
            {
                returnReportName = "MonthlyRejection.rdlc";
            }
            if (ReportCode == "R013")
            {
                returnReportName = "SortingDetails.rdlc";
            }
            return returnReportName;
        }
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            result.Add("ReportName", Convert.ToString(ReportParameters.ReportName));
            result.Add("FrmDate", Convert.ToString(ReportParameters.FrmDate));
            result.Add("ToDate", Convert.ToString(ReportParameters.ToDate));
            result.Add("entry_dt", Convert.ToString(ReportParameters.entry_dt));
            result.Add("prod_dt", Convert.ToString(ReportParameters.prod_dt));
            result.Add("shift", (ReportParameters.shift));
            result.Add("shift_incharge", (ReportParameters.engineer));
            result.Add("machinecode", (ReportParameters.machinecode));
            result.Add("defect_type", (ReportParameters.defect_type));
            result.Add("sort_type", (ReportParameters.sort_type));
            result.Add("sort_cat", (ReportParameters.sort_cat));
            result.Add("comp_code", (ReportParameters.comp_code));
            result.Add("location_Id", (ReportParameters.location_Id));
            result.Add("mctype", (ReportParameters.mctype));
            result.Add("no_of_months", Convert.ToString(ReportParameters.no_of_months));
            return result;
        }
        private void InsertCompany(object InputValue)
        {
            string Request = "";
            ADM_M002 POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = ObjComp.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            #endregion

            if (POPUPEntityObject != null)
            {

                ReportParameters.comp_code = POPUPEntityObject.comp_code;
            }




        }
        private void InsertPlant(object InputValue)
        {
            string Request = "";
            ADM_M003 POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = ObjPlant.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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

            if (POPUPEntityObject != null)
            {

                ReportParameters.location_Id = POPUPEntityObject.location_Id;

                var LocWiseMachine = (from o in MC.MachineCodeList
                                      where o.location_Id == ReportParameters.location_Id
                                      select o).ToList();


                MachineCollection = CollectionViewSource.GetDefaultView(LocWiseMachine.ToList());
                MachineCollection.Filter = new Predicate<object>(MachineFilter);
                MachineCollection.Refresh();

                var LocWiseEng = (from o in MC.EngineerDetails
                                  where o.location_Id == ReportParameters.location_Id
                                  select o).ToList();
                _strListEngineer = LocWiseEng;
                PMTypeDictionary = _strListEngineer.ToDictionary(X => X.engineer.ToString(), X => (object)X.engineer);

            }

        }
        private void InsertShift(object InputValue)
        {
            string Request = "";
            ADM_M042_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Shift.Where(x => x.shift.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M042_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                ReportParameters.shift = POPUPEntityObject.shift;
            }
        }
        private void InsertShiftIncharge(object InputValue)
        {
            string Request = "";
            ADM_M024_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ShiftIncharge.Where(x => x.EmpName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                ReportParameters.shift_incharge = POPUPEntityObject.EmpId;
                ReportParameters.ShiftInchargeName = POPUPEntityObject.EmpName;
            }
        }

        private void InsertMachine(object InputValue)
        {

            string stringMachineCode = "";
            ReportParameters.machinecode = "";
            foreach (ZADM_M013_P temp in MC.MachineCodeList)
            {
                if (temp.Select == true)
                {
                    stringMachineCode = stringMachineCode + "," + temp.machinecode;
                }
            }
            ReportParameters.machinecode = stringMachineCode.ToString().TrimStart(new char[] { ',' });

        }
        private void InsertDefect(object InputValue)
        {

            string stringDefect = "";
            ReportParameters.defect_type = "";
            foreach (ZADM_M016_P temp in MC.DefectList)
            {
                if (temp.Select == true)
                {
                    stringDefect = stringDefect + "," + temp.dfctdsc;
                }
            }
            ReportParameters.defect_type = stringDefect.ToString().TrimStart(new char[] { ',' });

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

        private void InsertUnit(object InputValue)
        {


            string Request = "";
            ADM_M038_B_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UOMList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null)
                {

                    ReportParameters.unit_code = POPUPEntityObject.unit_code;
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



        #region . Filter .
        #region Filter string Company
        private string _filterString_Company;
        public string FilterString_Company
        {
            get { return _filterString_Company; }
            set
            {
                _filterString_Company = value;
                RaisePropertyChanged("FilterString_Plant");
                FilterCollectionCompany();
            }
        }
        private void FilterCollectionCompany()
        {
            if (_CompanyCollection != null)
            {
                _CompanyCollection.Refresh();
            }
        }
        public bool FilterCompany(object obj)
        {
            var data = obj as ADM_M002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Company))
                {
                    return (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterString_Company.ToLower()) ||
                            (data.CompName != null && data.CompName.ToString().ToLower().Contains(_filterString_Company.ToLower()))
                        );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Machine
        private string _filterStringMachine;
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
        private string _filterStringDefect;
        private void FilterCollectionDefect()
        {
            if (_DefectListCollection != null)
            {
                _DefectListCollection.Refresh();
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

        #region Filter string Plant
        private string _filterString_plant;
        public string FilterString_plant
        {
            get { return _filterString_plant; }
            set
            {
                _filterString_plant = value;
                RaisePropertyChanged("FilterString_Item");
                filterPlantCollection();
            }
        }
        private void filterPlantCollection()
        {
            if (_PlantCollection != null)
            {
                _PlantCollection.Refresh();
            }
        }
        public bool FilterPlant(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_plant))
                {
                    return (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_plant.ToLower()) ||
                        data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_plant.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter string Shift Incharge
        private string _FilterStringShiftIncharge;
        public string FilterStringShiftIncharge
        {
            get { return _FilterStringShiftIncharge; }
            set
            {
                _FilterStringShiftIncharge = value;
                RaisePropertyChanged("FilterStringShiftIncharge");
                FilterCollectionShiftIncharge();
            }
        }
        private void FilterCollectionShiftIncharge()
        {
            if (_ShiftInchargeCollection != null)
            {
                _ShiftInchargeCollection.Refresh();
            }
        }
        public bool FilterShiftIncharge(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringShiftIncharge))
                {
                    return (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_FilterStringShiftIncharge.ToLower())) ||
                           (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_FilterStringShiftIncharge.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter string Shift
        private string _FilterStringShift;
        public string FilterStringShift
        {
            get { return _FilterStringShift; }
            set
            {
                _FilterStringShift = value;
                RaisePropertyChanged("FilterStringShift");
                FilterCollectionShift();
            }
        }
        private void FilterCollectionShift()
        {
            if (_ShiftCollection != null)
            {
                _ShiftCollection.Refresh();
            }
        }
        public bool FilterShift(object obj)
        {
            var data = obj as ADM_M042_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringShift))
                {
                    return (data.shift != null && data.shift.ToString().ToLower().Contains(_FilterStringShift.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter string unit

        #endregion
        private string _filterStringUom;
        public string FilterStringUom
        {
            get { return _filterStringUom; }
            set
            {
                _filterStringUom = value;
                RaisePropertyChanged("FilterStringUom");
                FilterCollectionUom();
            }
        }
        private void FilterCollectionUom()
        {
            if (_uomCollection != null)
            {
                _uomCollection.Refresh();
            }
        }
        public bool FilterUom(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringUom))
                {
                    return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringUom.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Command Action .
        protected override void OnSaveAction(InquiryActionResult<ESO_T001_RptEntity> result)
        {

        }
        protected override void OnCreateAction(InquiryActionResult<ESO_T001_RptEntity> result)
        {

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

        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
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
    }
}