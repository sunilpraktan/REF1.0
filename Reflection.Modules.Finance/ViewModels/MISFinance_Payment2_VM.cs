using Reflection.BusinessEntity;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.WebServices.Gateway;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services;
using System.Windows.Data;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.ReportingServices;
using System.Collections;
using Reflection.Presentation.Common;

namespace Reflection.Modules.Finance.ViewModels
{
    public class MISFinance_Payment2_VM : WorkspaceViewModel<MIS_PaymentReports>
    {
        bool blNew = true;
        WebServiceRepository<List<MIS_PaymentReports>> repository = new WebServiceRepository<List<MIS_PaymentReports>>();
        WebServiceRepository<MultipleContextMIS_FinanceReport> repository_MC = new WebServiceRepository<MultipleContextMIS_FinanceReport>();
        ObjectSerializationService obj = new ObjectSerializationService();

        MultipleContextMIS_FinanceReport _MC = new MultipleContextMIS_FinanceReport();
        public MultipleContextMIS_FinanceReport MC
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

        MultipleContextMIS_FinanceReport _MCTemp = new MultipleContextMIS_FinanceReport();
        public MultipleContextMIS_FinanceReport MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value;

                    RaisePropertyChanged("MCTemp");
                }
            }
        }

        private ReportParameterFinance _ReportParametersEntity;
        public ReportParameterFinance ReportParametersEntity
        {
            get
            {

                return _ReportParametersEntity;
            }
            set
            {
                _ReportParametersEntity = value;
                RaisePropertyChanged("ReportParametersEntity");
            }
        }

        private MIS_PaymentReports _MIS_PaymentReportsEntity;
        public MIS_PaymentReports MIS_PaymentReportsEntity
        {
            get
            {

                return _MIS_PaymentReportsEntity;
            }
            set
            {
                _MIS_PaymentReportsEntity = value;
                RaisePropertyChanged("MIS_PaymentReportsEntity");
            }
        }

        private List<MIS_PaymentReports> _dsReport;
        public List<MIS_PaymentReports> dsReport
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

        private Dictionary<string, string> _ReportItemsDictionary;
        public Dictionary<string, string> ReportItemsDictionary
        {
            get { return _ReportItemsDictionary; }
            set
            {
                if (_ReportItemsDictionary != value)
                {
                    _ReportItemsDictionary = value;
                    RaisePropertyChanged("ReportItemsDictionary");
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
    

        #region Collection

        private ICollectionView _PartyCollection;
        public ICollectionView PartyCollection
        {
            get { return _PartyCollection; }
            set { _PartyCollection = value; RaisePropertyChanged("PartyCollevtion"); }
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

        private ICollectionView _EmployeeCollection;
        public ICollectionView EmployeeCollection
        {
            get { return _EmployeeCollection; }
            set { _EmployeeCollection = value; RaisePropertyChanged("EmployeeCollection"); }
        }

        #endregion

        #region StringList

        private List<string> _stringListParty;
        public List<string> StringListParty
        {
            get { return _stringListParty; }
            set
            {
                if (_stringListParty != value)
                {
                    _stringListParty = value;
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

        #endregion

        #region RelayCommands      
        public RelayCommand CommandReport { get; private set; }
        public RelayCommand<object> cmdCompanyChange { get; private set; }
        public RelayCommand<object> cmdPlantChange { get; private set; }
        public RelayCommand<object> cmdEmp { get; private set; }
        public RelayCommand<object> cmdPartyChange { get; private set; }
        #endregion

        #region Constructor
        public MISFinance_Payment2_VM() : base()
        {
            CursorControl.SetBusyState();
            MC = new MultipleContextMIS_FinanceReport();
            ReportParametersEntity = new ReportParameterFinance();
            _dsReport = new List<MIS_PaymentReports>();
            ReportItemsDictionary = new Dictionary<string, string>();
            ReportItemsDictionary.Add("R001", "Opening Balance (Details)");
            //ReportItemsDictionary.Add("R002", "Opening Balance (Summary)");
            //ReportItemsDictionary.Add("R003", "Expence Commercial (Details)");
            //ReportItemsDictionary.Add("R004", "Expence Commercial (Summary)");

            cmdCompanyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            cmdPlantChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
            cmdEmp = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmp(items); });
            cmdPartyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items, blNew); });

            CommandReport = new RelayCommand(DisplayReport);
            DefaultValues();
            LoadInitialData();

        }

        #endregion
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContextMIS_FinanceReport>(MCTemp, Request, "MIS_Finance_PaymentRpt", "Finance", "LoadAll", 0, "");

                //Load Data on Party
                PartyCollection = CollectionViewSource.GetDefaultView(MCTemp.PartyDetails);
                PartyCollection.Filter = new Predicate<object>(FilterParty);

                EmployeeCollection = CollectionViewSource.GetDefaultView(MCTemp.EmployeeList.ToList());
                EmployeeCollection.Filter = new Predicate<object>(FilterEmp);
                StrListEmp = MCTemp.EmployeeList.Select(x => x.EmpId).ToList();

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

        // User Defined Function
        private void DisplayReport()
        {
            CursorControl.SetBusyState();
            try
            {
                if (ReportParametersEntity.ReportCode.ToString() == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Report Type");
                    showMessageService.ShowMessage();
                }
                //Check if Fields are not Selected then assign it to 'All'.
                if (ReportParametersEntity.ReportCode.ToString() != "")
                {
                    if (ReportParametersEntity.PartyId ==null) { ReportParametersEntity.PartyId = "All"; }
                    if (ReportParametersEntity.PartyNm == null ) {ReportParametersEntity.PartyNm="All"; }
                  
                }
                ReportParametersEntity = ReportParametersEntity;
                if (ReportParametersEntity.ReportCode.ToString() != null)
                {
                    string RequestParameter = "Report" + "!@" + ReportParametersEntity.ReportCode + "!@" + ReportParametersEntity.PartyId + "!@" + ReportParametersEntity.location_Id + "!@" + ReportParametersEntity.comp_code + "!@" + Convert.ToDateTime(ReportParametersEntity.FromDate).ToString("MM/dd/yyyy") + "!@ " + Convert.ToDateTime(ReportParametersEntity.ToDate).ToString("MM/dd/yyyy") +"!@"+ReportParametersEntity.Customer + "!@" + ReportParametersEntity.Supplier;
                    MC = repository_MC.GetDataWithReturnDomainObject<MultipleContextMIS_FinanceReport>(MC, RequestParameter, "MIS_Finance_PaymentRpt2", "Finance", "", 0, RequestParameter);

                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];

                    objDataSource[0] = MC.RptPaymentBalanceEntity;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == ReportParametersEntity.location_Id).ToList();
                    objDataSource[2] = Result;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == ReportParametersEntity.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    objDataSourceName[0] = "dsRptPaymentBalance";
                    objDataSourceName[1] = "dsCompany"; 
                    objDataSourceName[2] = "dsLocation";
                    

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\Finance\\" + GetReportFile(ReportParametersEntity.ReportCode), getParametersList(), "");
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
                result.Add("FromDate", Convert.ToString(ReportParametersEntity.FromDate));
                result.Add("ToDate", Convert.ToString(ReportParametersEntity.ToDate));
                result.Add("PartyId", ReportParametersEntity.PartyId);
                result.Add("PartyNm", ReportParametersEntity.PartyNm);
                result.Add("doc_type", ReportParametersEntity.doc_type);
                result.Add("doc_cat", ReportParametersEntity.doc_cat);
                result.Add("t_status", ReportParametersEntity.t_status);
                result.Add("ReportName", ReportParametersEntity.ReportName);
                result.Add("doc_no", ReportParametersEntity.doc_no);
                result.Add("comp_code", ReportParametersEntity.comp_code);
                result.Add("location_Id", ReportParametersEntity.location_Id);
                result.Add("active", Convert.ToString(ReportParametersEntity.active));
                result.Add("Customer", Convert.ToString(ReportParametersEntity.Customer));
                result.Add("Supplier", Convert.ToString(ReportParametersEntity.Supplier));


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
                returnReportName = "OpeningBalanceMIS.rdlc";
            }
            else if (ReportCode == "R002")
            {
                returnReportName = "OpeningBalanceSummary.rdlc";
            }
            else if(ReportCode == "R003")
            {
                returnReportName = "ExpenceCommercialDetail.rdlc";
            }
            else if(ReportCode == "R004")
            {
                returnReportName = "ExpenceCommercialSummary.rdlc";
            }
            return returnReportName;
        }
        private void InsertParty(object InputValue, bool OverrideValue)
        {

            string stringParty = "";
            string stringPartyNm = "";
            ReportParametersEntity.PartyId = "";
            foreach (ADM_M028_P temp in MCTemp.PartyDetails)
            {
                if (temp.Select == true)
                {
                    stringParty = stringParty + "," + temp.PartyId;
                    stringPartyNm = stringPartyNm + "," + temp.PartyNm;
                }
            }
            ReportParametersEntity.PartyId = stringParty.ToString().TrimStart(new char[] { ',' });
            ReportParametersEntity.PartyNm = stringPartyNm.ToString().TrimStart(new char[] { ',' });

        }
        private void InsertEmp(object InputValue)
        {
            try
            {
                string stringEmp = "";
                string stringEmpNm = "";
                ReportParametersEntity.EmpId = "";
                foreach (ADM_M024_P temp in MCTemp.EmployeeList)
                {
                    if (temp.Select == true)
                    {
                        stringEmp = stringEmp + "," + temp.EmpId;
                        stringEmpNm = stringEmpNm + "," + temp.EmpName;
                    }
                }
                ReportParametersEntity.EmpId = stringEmp.ToString().TrimStart(new char[] { ',' });
                ReportParametersEntity.EmpName = stringEmpNm.ToString().TrimStart(new char[] { ',' });

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
                ReportParametersEntity.comp_code = POPUPEntityObject.comp_code;
            }




        }
        private void InsertPlant(object InputValue)
        {
            string stringLocation = "";
            string stringLocationNm = "";

            ReportParametersEntity.location_Id = "";
            foreach (ADM_M003 temp in ObjPlant)
            {
                if (temp.Select == true)
                {
                    stringLocation = stringLocation + "," + temp.location_Id;
                    stringLocationNm = stringLocationNm + "," + temp.LoctnNm;

                }
            }
            ReportParametersEntity.location_Id = stringLocation.ToString().TrimStart(new char[] { ',' });
            ReportParametersEntity.LoctnNm = stringLocationNm.ToString().TrimStart(new char[] { ',' });
        }

        #region defaultValues
        private void DefaultValues()
        {

            ReportParametersEntity.comp_code = AppSessionState.comp_code;
            //ReportParametersEntity.fin_year = AppSessionState.FinYear;
            ReportParametersEntity.location_Id = AppSessionState.location_Id;

            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            ReportParametersEntity.FromDate = lastDayLastMonth.AddDays(0);
            ReportParametersEntity.ToDate = DateTime.Now;
        }
        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<MIS_PaymentReports> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<MIS_PaymentReports> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<MIS_PaymentReports> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<MIS_PaymentReports> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<MIS_PaymentReports> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<MIS_PaymentReports> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRemoveAction(InquiryActionResult<MIS_PaymentReports> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnSaveAction(InquiryActionResult<MIS_PaymentReports> result)
        {
            throw new NotImplementedException();
        }

        #endregion

        #region . Filter .
        private string _filterString_party;
        public string FilterString_party
        {
            get { return _filterString_party; }
            set
            {
                _filterString_party = value;
                RaisePropertyChanged("FilterString_party");
                FilterCollectionParty();
            }
        }
        private void FilterCollectionParty()
        {
            if (_PartyCollection != null)
            {
                _PartyCollection.Refresh();
            }
        }
        public bool FilterParty(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_party))
                {
                    return (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_party.ToLower()) ||
                        (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_party.ToLower())));
                }
                return true;
            }
            return false;
        }

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

        protected override void OnRefreshCommand(InquiryActionResult<MIS_PaymentReports> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_PaymentReports> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_PaymentReports> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_PaymentReports> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_PaymentReports> result)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
