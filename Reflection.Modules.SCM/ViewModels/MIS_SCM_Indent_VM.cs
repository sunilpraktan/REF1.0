using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.SCM;
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
using Reflection.ReportingServices;
using System.Windows.Data;
using Reflection.Presentation.Common;

namespace Reflection.Modules.SCM.ViewModels
{
    public class MIS_SCM_Indent_VM : WorkspaceViewModel<MIS_IndentReport>
    {
        #region Variables Declaration

        bool blNew = true;
        WebServiceRepository<List<MIS_SCM_Indent>> repository = new WebServiceRepository<List<MIS_SCM_Indent>>();
        WebServiceRepository<MultipleContext_MIS_SCM_Indent> repository_MC = new WebServiceRepository<MultipleContext_MIS_SCM_Indent>();
        ObjectSerializationService obj = new ObjectSerializationService();
        public string ts_code_vm { get; set; }
        private MultipleContext_MIS_SCM_Indent _MC;
        public MultipleContext_MIS_SCM_Indent MC
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

        private MIS_IndentReport _ReportParameters;
        public MIS_IndentReport ReportParameters
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

        private Dictionary<string, object> _StatusDictionary;
        public Dictionary<string, object> StatusDictionary
        {
            get { return _StatusDictionary; }
            set
            {
                if (_StatusDictionary != value)
                {
                    _StatusDictionary = value;
                    RaisePropertyChanged("StatusDictionary");
                }
            }
        }

        private List<MIS_SCM_Indent> _dsReport;
        public List<MIS_SCM_Indent> dsReport
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

        #endregion

        #region ICollection
        private ICollectionView _EmployeeCollection;
        public ICollectionView EmployeeCollection
        {
            get { return _EmployeeCollection; }
            set { _EmployeeCollection = value; RaisePropertyChanged("EmployeeCollection"); }
        }

        private ICollectionView _DepartmentCollection;
        public ICollectionView DepartmentCollection
        {
            get { return _DepartmentCollection; }
            set { _DepartmentCollection = value; RaisePropertyChanged("DepartmentCollection"); }
        }

        private ICollectionView _ItemsCollection;
        public ICollectionView ItemsCollection
        {
            get { return _ItemsCollection; }
            set { _ItemsCollection = value; RaisePropertyChanged("ItemsCollection"); }
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
        private ICollectionView _StatusCollection;
        public ICollectionView StatusCollection
        {
            get { return _StatusCollection; }
            set { _StatusCollection = value; RaisePropertyChanged("StatusCollection"); }
        }
        #endregion

        #region StringList Variables
        List<string> _StringListDepartment;
        public List<string> StringListDepartment
        {
            get { return _StringListDepartment; }
            set
            {
                if (_StringListDepartment != value)
                {
                    _StringListDepartment = value;
                }
            }
        }
        List<string> _stringListItems;
        public List<string> StringListItems
        {
            get { return _stringListItems; }
            set
            {
                if (_stringListItems != value)
                {
                    _stringListItems = value;
                }
            }
        }
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
        private List<string> _strListEmp;
        public List<string> StrListEmp
        {
            get { return _strListEmp; }
            set
            {
                if (_strListEmp != value)
                {
                    _strListEmp = value;
                }
            }
        }
        private List<MIS_SCM_Indent> _strListStatus;
        public List<MIS_SCM_Indent> StrListStatus
        {
            get { return _strListStatus; }
            set
            {
                if (_strListStatus != value)
                {
                    _strListStatus = value;
                    RaisePropertyChanged("StrListStatus");
                }
            }
        }
        #endregion

        #region RelayCommands      
        public RelayCommand CommandReport { get; private set; }
        public RelayCommand<object> cmdEmp { get; private set; }
        public RelayCommand CommandExport { get; private set; }
        public RelayCommand<object> CmdAddDepartment { get; private set; }
        public RelayCommand<object> cmdItemChange { get; private set; }
        public RelayCommand<object> cmdCompanyChange { get; private set; }
        public RelayCommand<object> cmdPlantChange { get; private set; }
        public RelayCommand<object> CmdInsertStatus { get; private set; }
        #endregion

        #region Constructor
        public MIS_SCM_Indent_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            CursorControl.SetBusyState();
            MC = new MultipleContext_MIS_SCM_Indent();
            ReportParameters = new MIS_IndentReport();
            dsReport = new List<MIS_SCM_Indent>();
            _dsReport = new List<MIS_SCM_Indent>();

            ItemsDictionary = new Dictionary<string, string>();
            ItemsDictionary.Add("R001", "Indent Report Details");
            
            cmdEmp = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmp(items); });
            CmdAddDepartment = new RelayCommand<object>(items => { if (items == null) { return; } InsertDepartment(items); });
            cmdItemChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
            cmdCompanyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            cmdPlantChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
            CmdInsertStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertStatus(items); });
            CommandReport = new RelayCommand(DisplayReport);

            LoadInitialData();
            DefaultValues();
        }
        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MIS_SCM_Indent>(MC, Request, "MIS_SCMIndentReport", "SCM", "LoadInitialData", 0, "");

                EmployeeCollection = CollectionViewSource.GetDefaultView(MC.EmployeeList.ToList());
                EmployeeCollection.Filter = new Predicate<object>(FilterEmp);
                StrListEmp = MC.EmployeeList.Select(x => x.EmpId).ToList();

                DepartmentCollection = CollectionViewSource.GetDefaultView(MC.DepartmentDetails);
                DepartmentCollection.Filter = new Predicate<object>(FilterDepartment);
                StringListDepartment = MC.DepartmentDetails.Select(x => x.DeptName).ToList();

                ItemsCollection = CollectionViewSource.GetDefaultView(MC.ItemDetails);
                ItemsCollection.Filter = new Predicate<object>(FilterItem);
                StringListItems = MC.ItemDetails.Select(x => x.ItemCode).ToList();

                StatusCollection = CollectionViewSource.GetDefaultView(MC.StatusDetails);
                StatusCollection.Filter = new Predicate<object>(FilterStatus);
                //var StatusList = (from o in MC.StatusDetails
                //                  where o.t_status != null
                //                  select o).ToList();
                //_strListStatus = StatusList;
                //StatusDictionary = _strListStatus.ToDictionary(X => X.t_status.ToString(), X => (object)X.t_status);

                ObjComp = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                CompanyCollection = CollectionViewSource.GetDefaultView(ObjComp.ToList());
                CompanyCollection.Filter = new Predicate<object>(FilterCompany);
                StringListCompany = ObjComp.Select(x => x.comp_code).ToList();

                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantCollection = CollectionViewSource.GetDefaultView(ObjPlant.ToList());
                PlantCollection.Filter = new Predicate<object>(FilterPlant);
                StringListPlant = ObjPlant.Select(x => x.location_Id).ToList();

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
            ReportParameters.comp_code = AppSessionState.comp_code;            
            //ReportParameters.fin_year = AppSessionState.FinYear;
            ReportParameters.location_Id = AppSessionState.location_Id;
            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            ReportParameters.FromDate = lastDayLastMonth.AddDays(0);
            ReportParameters.ToDate = DateTime.Now;
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
                    string RequestParameter = "Report" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.ItemCode + "!@" + ReportParameters.dept_code + "!@" + ReportParameters.location_Id + "!@" + ReportParameters.comp_code + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParameters.EmpId + "!@" + ReportParameters.t_status + "!@" + AppSessionState.client;
                    dsReport = repository.GetDataWithReturnDomainObject<List<MIS_SCM_Indent>>(dsReport, RequestParameter, "MIS_SCMIndentReport", "SCM", "", 0, "");
                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(dsReport, "dsMIS_SCM_Indent", "\\MIS\\SCM\\" + GetReportFile(ReportParameters.ReportCode), getParametersList());
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
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("FromDate", Convert.ToString(ReportParameters.FromDate));
                result.Add("ToDate", Convert.ToString(ReportParameters.ToDate));
                result.Add("ItemCode", ReportParameters.ItemCode);
                result.Add("dept_code", ReportParameters.dept_code);
                result.Add("DeptName", ReportParameters.DeptName);               
                result.Add("t_status", ReportParameters.t_status);
                result.Add("ReportName", ReportParameters.ReportName);
                result.Add("comp_code", ReportParameters.comp_code);
                result.Add("location_Id", ReportParameters.location_Id);
                result.Add("ItemName", ReportParameters.ItemName);
                result.Add("EmpName", ReportParameters.EmpName);
                result.Add("EmpId", ReportParameters.EmpId);
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
        private string GetReportFile(string ReportCode)
        {
            string returnReportName = "";
            if (ReportCode == "R001")
            {
                returnReportName = "IndentOrderDetails.rdlc";
            }
            
            return returnReportName;
        }
        private void InsertEmp(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M024_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.EmployeeList.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    ReportParameters.EmpId = POPUPEntityObject.EmpId;
                    ReportParameters.EmpName = POPUPEntityObject.EmpLName;
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
        private void InsertDepartment(object InputValue)
        {
            string Request = "";
            ADM_M025_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DepartmentDetails.Where(x => x.DeptName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M025_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M025_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                ReportParameters.DeptName = POPUPEntityObject.DeptName;
                ReportParameters.dept_code = POPUPEntityObject.dept_code;
            }
        }
        private void InsertItem(object InputValue)
        {

            string stringItems = "";
            string stringItemsNm = "";

            ReportParameters.ItemCode = "";
            foreach (ADM_M022_P temp in MC.ItemDetails)
            {
                if (temp.Select == true)
                {
                    stringItems = stringItems + "," + temp.ItemCode;
                    stringItemsNm = stringItemsNm + "," + temp.ItemName;

                }
            }
            ReportParameters.ItemCode = stringItems.ToString().TrimStart(new char[] { ',' });
            ReportParameters.ItemName = stringItemsNm.ToString().TrimStart(new char[] { ',' });

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
            }

        }
        private void InsertStatus(object InputValue)
        {

            string stringStatus = "";
            //string stringStatusNm = "";

            ReportParameters.ItemCode = "";
            foreach (MIS_SCM_Indent temp in MC.StatusDetails)
            {
                if (temp.Select == true)
                {
                    stringStatus = stringStatus + "," + temp.t_status;
                    //stringStatusNm = stringStatusNm + "," + temp.t_display;

                }
            }
            ReportParameters.t_status = stringStatus.ToString().TrimStart(new char[] { ',' });
            //ReportParameters. = stringStatusNm.ToString().TrimStart(new char[] { ',' });

        }

        #endregion


        #region . Filter .

        #region filterEmployee
        public bool FilterEmp(object obj)
        {
            var data = obj as ADM_M024_P;

            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringEmp))
                {
                    return (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterStringEmp.ToLower()) ||
                        data.EmpLName != null && data.EmpLName.ToString().ToLower().Contains(_filterStringEmp.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterStringEmp;
        public string filterStringEmp
        {
            get { return _filterStringEmp; }
            set
            {
                _filterStringEmp = value;
                RaisePropertyChanged("filterStringEmp");
                FilterCollectionEmp();
            }
        }
        private void FilterCollectionEmp()
        {
            if (_EmployeeCollection != null)
            {
                _EmployeeCollection.Refresh();
            }
        }
        #endregion

        private string _FilterStringDepartment;
        public string FilterStringDepartment
        {
            get { return _FilterStringDepartment; }
            set
            {
                _FilterStringDepartment = value;
                RaisePropertyChanged("FilterStringDepartment");
                FilterCollectionDept();
            }
        }
        private void FilterCollectionDept()
        {
            if (_DepartmentCollection != null)
            {
                _DepartmentCollection.Refresh();
            }
        }
        public bool FilterDepartment(object obj)
        {
            var data = obj as ADM_M025_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringDepartment))
                {
                    return (data.dept_code != null && data.dept_code.ToString().ToLower().Contains(_FilterStringDepartment.ToLower()) ||
                        (data.DeptName != null && data.DeptName.ToString().ToLower().Contains(_FilterStringDepartment.ToLower())));
                }
                return true;
            }
            return false;
        }

        private string _filterString_Item;
        public string FilterString_Item
        {
            get { return _filterString_Item; }
            set
            {
                _filterString_Item = value;
                RaisePropertyChanged("FilterString_Item");
                FilterCollectionItem();
            }
        }
        private void FilterCollectionItem()
        {
            if (_ItemsCollection != null)
            {
                _ItemsCollection.Refresh();
            }
        }
        public bool FilterItem(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Item))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
                            (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_Item.ToLower()))
                        );
                }
                return true;
            }
            return false;
        }

        private string _filterString_Status;
        public string FilterString_Status
        {
            get { return _filterString_Status; }
            set
            {
                _filterString_Status = value;
                RaisePropertyChanged("FilterString_Status");
                FilterCollectionStatus();
            }
        }
        private void FilterCollectionStatus()
        {
            if (_StatusCollection != null)
            {
                _StatusCollection.Refresh();
            }
        }
        public bool FilterStatus(object obj)
        {
            var data = obj as MIS_SCM_Indent;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Status))
                {
                    return (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_Status.ToLower()) ||
                            (data.t_display != null && data.t_display.ToString().ToLower().Contains(_filterString_Status.ToLower()))
                        );
                }
                return true;
            }
            return false;
        }

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

        #region . Command Action .
        protected override void OnSaveAction(InquiryActionResult<MIS_IndentReport> result)
        {

        }
        protected override void OnCreateAction(InquiryActionResult<MIS_IndentReport> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<MIS_IndentReport> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<MIS_IndentReport> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<MIS_IndentReport> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<MIS_IndentReport> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<MIS_IndentReport> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<MIS_IndentReport> result)
        {

        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_IndentReport> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_IndentReport> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_IndentReport> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_IndentReport> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_IndentReport> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
