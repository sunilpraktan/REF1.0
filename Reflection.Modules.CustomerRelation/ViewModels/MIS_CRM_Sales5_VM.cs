using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.ViewModel;
using Reflection.Presentation.Services;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Reflection.ReportingServices;
using System.Linq;
using System.Windows.Data;
using Reflection.Presentation.Common;
//Last updated by Priya on 15/10/2016 Time:11:48

namespace Reflection.Modules.CustomerRelation.ViewModels
{


    public class MIS_CRM_Sales5_VM : WorkspaceViewModel<MIS_SalesReports>
    {
        #region Variables Declaration
        bool blNew = true;
        WebServiceRepository<List<MIS_CRM_SalesEntity2>> repository = new WebServiceRepository<List<MIS_CRM_SalesEntity2>>();
        WebServiceRepository<MultipleContextMISReports> repository_MC = new WebServiceRepository<MultipleContextMISReports>();
        ObjectSerializationService obj = new ObjectSerializationService();

        MultipleContextMISReports _MC = new MultipleContextMISReports();
        public MultipleContextMISReports MC
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

        MultipleContextMISReports _MCTemp = new MultipleContextMISReports();
        public MultipleContextMISReports MCTemp
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
        private MISReportParameter _ReportParameters;
        public MISReportParameter ReportParameters
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
        #endregion

        #region Dictionary
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
        private Dictionary<string, string> _StatusDictionary;
        public Dictionary<string, string> StatusDictionary
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

        #endregion

        #region List

        private List<MIS_CRM_SalesEntity2> _dsReport2;
        public List<MIS_CRM_SalesEntity2> dsReport2
        {
            get { return _dsReport2; }
            set
            {
                if (_dsReport2 != value)
                {
                    _dsReport2 = value;


                    RaisePropertyChanged("dsReport2");

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
        private ICollectionView _EmpCollection;
        public ICollectionView EmpCollection
        {
            get { return _EmpCollection; }
            set
            {
                _EmpCollection = value;

                RaisePropertyChanged("EmpCollection");
            }
        }
        private ICollectionView _PartyCollection;
        public ICollectionView PartyCollection
        {
            get { return _PartyCollection; }
            set { _PartyCollection = value; RaisePropertyChanged("PartyCollevtion"); }
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
        #endregion

        #region StringList Variables
        List<string> _stringListParty;
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

        List<string> _strListEmployee;
        public List<string> StringListEmployee
        {
            get { return _strListEmployee; }
            set
            {
                if (_strListEmployee != value)
                {
                    _strListEmployee = value;
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
        #endregion

        #region RelayCommands      
        public RelayCommand CommandReport { get; private set; }
        public RelayCommand CommandExport { get; private set; }
        public RelayCommand<object> cmdEmployeeChange { get; private set; }
        public RelayCommand<object> cmdPartyChange { get; private set; }
        public RelayCommand<object> cmdItemChange { get; private set; }
        public RelayCommand<object> cmdCompanyChange { get; private set; }
        public RelayCommand<object> cmdPlantChange { get; private set; }
        public RelayCommand<IList> cmdPartyType { get; private set; }
        public RelayCommand<object> cmdGrpChange { get; private set; }

        #endregion

        #region Constructor
        public MIS_CRM_Sales5_VM()
            : base()
        {
            CursorControl.SetBusyState();
            MC = new MultipleContextMISReports();
            ReportParameters = new MISReportParameter();
            _dsReport2 = new List<MIS_CRM_SalesEntity2>();
            cmdPartyType = new RelayCommand<IList>(items => { if (items == null) { return; } InsertPartyType(items, blNew); });

            ItemsDictionary = new Dictionary<string, string>();
            ItemsDictionary.Add("R001", "Weekly Sales Report");
            ItemsDictionary.Add("R002", "Monthly Sales Report");
            ItemsDictionary.Add("R003", "DateWise Sales Report");
            ItemsDictionary.Add("R026", "DateWise Details Sales Report");
            

            StatusDictionary = new Dictionary<string, string>();
            StatusDictionary.Add("S001", "Working");
            StatusDictionary.Add("S002", "Pending");
            StatusDictionary.Add("S003", "Won");
            StatusDictionary.Add("S004", "Lost");
            StatusDictionary.Add("S005", "Cancelled");
            StatusDictionary.Add("S006", "No Requirement");


            cmdPartyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items, blNew); });
            cmdEmployeeChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmp(items, blNew); });
            cmdCompanyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            cmdPlantChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
            cmdGrpChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertGrp(items, blNew); });
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
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContextMISReports>(MC, Request, "MIS_CRM_SalesReport5", "CRM", "LoadAll", 0, "MIS_CRM_Sales2");

                PartyCollection = CollectionViewSource.GetDefaultView(MC.partyDetails);
                PartyCollection.Filter = new Predicate<object>(FilterParty);
                StringListParty = MC.partyDetails.Select(x => x.PartyId).ToList();

                EmpCollection = CollectionViewSource.GetDefaultView(MC.Employee);
                EmpCollection.Filter = new Predicate<object>(EmpFilter);
                StringListEmployee = MC.Employee.Select(x => x.EmpId).ToList();

                ObjComp = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                CompanyCollection = CollectionViewSource.GetDefaultView(ObjComp.ToList());
                CompanyCollection.Filter = new Predicate<object>(FilterCompany);
                StringListCompany = ObjComp.Select(x => x.comp_code).ToList();

                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantCollection = CollectionViewSource.GetDefaultView(ObjPlant.ToList());
                PlantCollection.Filter = new Predicate<object>(FilterPlant);
                StringListPlant = ObjPlant.Select(x => x.location_Id).ToList();

                PartyTypeCollection = CollectionViewSource.GetDefaultView(MC.PartyType);
                PartyTypeCollection.Filter = new Predicate<object>(FilterPartyType);

                GroupCollection = CollectionViewSource.GetDefaultView(MC.Group);
                GroupCollection.Filter = new Predicate<object>(FilterGroup);
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
            ReportParameters.t_status = "";
            //  ReportParameters.comp_code = AppSessionState.comp_code;
            ReportParameters.doc_cat = "";
            ReportParameters.doc_no = "";
            ReportParameters.doc_type = "";
            //ReportParameters.fin_year = AppSessionState.FinYear;
            ReportParameters.ItemCode = "";
            ReportParameters.ItemName = "";
            // ReportParameters.Location_Id = AppSessionState.location_Id;

            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, 4, 1);
            ReportParameters.FromDate = lastDayLastMonth;
            ReportParameters.ToDate = DateTime.Now;
        }


        private void InsertPartyType(object InputValue, bool OverrideValue)
        {

            string stringPartyType = "";
            string stringPartyNm = "";
            ReportParameters.PartyType = "";
            foreach (ADM_M028_B_P temp in MC.PartyType)
            {
                if (temp.Select == true)
                {
                    stringPartyType = stringPartyType + "," + temp.PartyType;
                    stringPartyNm = stringPartyNm + "," + temp.PartyType_Nm;
                }
            }
            ReportParameters.PartyType = stringPartyType.ToString().TrimStart(new char[] { ',' });
            ReportParameters.PartyType_Nm = stringPartyNm.ToString().TrimStart(new char[] { ',' });

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
                    if (ReportParameters.PartyNm == null) { ReportParameters.PartyNm = "All"; }
                    if (ReportParameters.PartyType == null) { ReportParameters.PartyType = "All"; }
                    if (ReportParameters.EmpName == null) { ReportParameters.EmpName = "All"; }
                    if (ReportParameters.act_action == null) { ReportParameters.act_action = "All"; }
                    if (ReportParameters.action_type == null) { ReportParameters.action_type = "All"; }
                    if (ReportParameters.StatusName == null) { ReportParameters.StatusName = "All"; }
                    if (ReportParameters.group1 == null) { ReportParameters.group1 = "All"; }
                    if (ReportParameters.prospectus == null) { ReportParameters.prospectus = "All"; }

                }
                if (ReportParameters.ReportCode != null)
                {

                    string RequestParameter = "Report" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.ItemCode + "!@" + ReportParameters.PartyId + "!@" + ReportParameters.Location_Id + "!@" + ReportParameters.comp_code + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParameters.doc_no + "!@" + ReportParameters.t_status + "!@" + ReportParameters.EmpId + "!@" + ReportParameters.act_action + "!@" + ReportParameters.action_type + "!@" + ReportParameters.PartyType + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + AppSessionState.UserID + "!@" + ReportParameters.StatusName + "!@" + ReportParameters.active;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContextMISReports>(MC, RequestParameter, "MIS_CRM_SalesReport5", "CRM", "", 0, "MIS_CRM_Sales2");

                    object[] objDataSource = new object[19];
                    string[] objDataSourceName = new string[19];

                    objDataSource[0] = MCTemp.RptMIS_CRMSales_List2;
                    objDataSource[1] = MCTemp.RptMIS_CRMDatewiseSales_List1;
                    objDataSource[2] = MCTemp.RptMIS_CRMDatewiseSales_List2;
                    objDataSource[3] = MCTemp.RptMIS_CRMDatewiseSales_List3;
                    objDataSource[4] = MCTemp.RptMIS_CRMDatewiseSales_List4;
                    objDataSource[5] = MCTemp.RptMIS_CRMDatewiseSales_List5;
                    objDataSource[6] = MCTemp.RptMIS_CRMDatewiseSales_List6;
                    objDataSource[7] = MCTemp.RptMIS_CRMDatewiseSales_List7;
                    objDataSource[8] = MCTemp.RptMIS_CRMDatewiseSales_List7N2;
                    objDataSource[9] = MCTemp.RptMIS_CRMDatewiseSales_List7N3;
                    objDataSource[10] = MCTemp.RptMIS_CRMDatewiseSales_List8;
                    objDataSource[11] = MCTemp.RptMIS_CRMDatewiseSales_List9;
                    objDataSource[12] = MCTemp.RptMIS_CRMDatewiseSales_List10;
                    objDataSource[13] = MCTemp.RptMIS_CRMDatewiseSales_List11;
                    objDataSource[14] = MCTemp.RptMIS_CRMDatewiseSales_List12;
                    objDataSource[15] = MCTemp.RptMIS_CRMDatewiseSales_List13;
                    objDataSource[16] = MCTemp.RptMIS_CRMDatewiseSales_List14;
                    objDataSource[17] = MCTemp.RptMIS_CRMDatewiseSales_List16;
                    objDataSource[18] = MCTemp.RptMIS_CRMDatewiseSales_List17;


                    objDataSourceName[0] = "dsMIS_CRM_Sales2";
                    objDataSourceName[1] = "dsRptMIS_CRMDatewiseSales1";
                    objDataSourceName[2] = "dsRptMIS_CRMDatewiseSales2N";
                    objDataSourceName[3] = "dsRptMIS_CRMDatewiseSales3";
                    objDataSourceName[4] = "dsRptMIS_CRMDatewiseSales4N";
                    objDataSourceName[5] = "dsRptMIS_CRMDatewiseSales5N";
                    objDataSourceName[6] = "dsRptMIS_CRMDatewiseSales6";
                    objDataSourceName[7] = "dsRptMIS_CRMDatewiseSales7N";
                    objDataSourceName[8] = "dsRptMIS_CRMDatewiseSales7N2";
                    objDataSourceName[9] = "dsRptMIS_CRMDatewiseSales7N3";
                    objDataSourceName[10] = "dsRptMIS_CRMDatewiseSales8N";
                    objDataSourceName[11] = "dsRptMIS_CRMDatewiseSales9";
                    objDataSourceName[12] = "dsRptMIS_CRMDatewiseSales10";
                    objDataSourceName[13] = "dsRptMIS_CRMDatewiseSales11N";
                    objDataSourceName[14] = "dsRptMIS_CRMDatewiseSales12";
                    objDataSourceName[15] = "dsRptMIS_CRMDatewiseSales13";
                    objDataSourceName[16] = "dsRptMIS_CRMDatewiseSales14";
                    objDataSourceName[17] = "dsRptMIS_CRMDatewiseSales16";
                    objDataSourceName[18] = "dsRptMIS_CRMDatewiseSales17N";

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + GetReportFile(ReportParameters.ReportCode), getParametersList(), "");
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
            { returnReportName = "WeeklyMonthlyRpt.rdlc"; }
            else if (ReportCode == "R002")
            { returnReportName = "MonthlyCRMRpt.rdlc"; }
            else if (ReportCode == "R003")
            { returnReportName = "DatewiseWeeklyMonthlyRpt.rdlc"; }
            else if (ReportCode == "R026")
            { returnReportName = "DatewiseSalesDetailsRpt.rdlc"; }
            return returnReportName;
        }
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("FromDate", Convert.ToString(ReportParameters.FromDate));
                result.Add("ToDate", Convert.ToString(ReportParameters.ToDate));
                result.Add("PartyId", ReportParameters.PartyId);
                result.Add("PartyNm", ReportParameters.PartyNm);
                result.Add("EmpName", ReportParameters.EmpName);
                result.Add("doc_type", ReportParameters.doc_type);
                result.Add("doc_cat", ReportParameters.doc_cat);
                result.Add("t_status", ReportParameters.t_status);
                result.Add("ReportNm", ReportParameters.ReportName);
                result.Add("doc_no", ReportParameters.doc_no);
                result.Add("comp_code", ReportParameters.comp_code);
                result.Add("Location_Id", ReportParameters.Location_Id);
                result.Add("act_action", ReportParameters.act_action);
                result.Add("action_type", ReportParameters.action_type);
                result.Add("PartyType", ReportParameters.PartyType);
                result.Add("StatusName", ReportParameters.StatusName);
                result.Add("group1", ReportParameters.group1);
                result.Add("prospectus", ReportParameters.prospectus);


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

        private void InsertEmp(object InputValue, bool OverrideValue)
        {
            try
            {
                string stringEmp = "";
                string stringEmpNm = "";
                ReportParameters.EmpId = "";
                foreach (ADM_M024_P temp in MC.Employee)
                {
                    if (temp.Select == true)
                    {
                        stringEmp = stringEmp + "," + temp.EmpId;
                        stringEmpNm = stringEmpNm + "," + temp.EmpName;
                    }
                }
                ReportParameters.EmpId = stringEmp.ToString().TrimStart(new char[] { ',' });
                ReportParameters.EmpName = stringEmpNm.ToString().TrimStart(new char[] { ',' });

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


        private void InsertParty(object InputValue, bool OverrideValue)
        {

            string stringParty = "";
            string stringPartyNm = "";
            ReportParameters.PartyId = "";
            foreach (ADM_M028_P temp in MC.partyDetails)
            {
                if (temp.Select == true)
                {
                    stringParty = stringParty + "," + temp.PartyId;
                    stringPartyNm = stringPartyNm + "," + temp.PartyNm;
                }
            }
            ReportParameters.PartyId = stringParty.ToString().TrimStart(new char[] { ',' });
            ReportParameters.PartyNm = stringPartyNm.ToString().TrimStart(new char[] { ',' });

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
            string stringLocation = "";
            string stringLocationNm = "";

            ReportParameters.Location_Id = "";
            foreach (ADM_M003 temp in ObjPlant)
            {
                if (temp.Select == true)
                {
                    stringLocation = stringLocation + "," + temp.location_Id;
                    stringLocationNm = stringLocationNm + "," + temp.LoctnNm;

                }
            }
            ReportParameters.Location_Id = stringLocation.ToString().TrimStart(new char[] { ',' });
            ReportParameters.LoctnNm = stringLocationNm.ToString().TrimStart(new char[] { ',' });


        }

        private void InsertGrp(object InputValue, bool OverrideValue)
        {
            string Request = "";
            ADM_M028_A_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Group.Where(x => x.grpNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M028_A_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_A_P>().ToList()[0];
                    }
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                ReportParameters.group1 = POPUPEntityObject.group1;
                ReportParameters.grpNm = POPUPEntityObject.grpNm;
            }

        }

        #endregion

        #region . Command Action .
        protected override void OnSaveAction(InquiryActionResult<MIS_SalesReports> result)
        {

        }
        protected override void OnCreateAction(InquiryActionResult<MIS_SalesReports> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<MIS_SalesReports> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<MIS_SalesReports> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<MIS_SalesReports> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<MIS_SalesReports> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<MIS_SalesReports> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<MIS_SalesReports> result)
        {

        }
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_SalesReports> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_SalesReports> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_SalesReports> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_SalesReports> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_SalesReports> result)
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
        #region Filters For Emp
        private void FilterCollectionEmp()
        {
            if (_EmpCollection != null)
            {
                _EmpCollection.Refresh();
            }
        }
        private string _filterStringEmp;
        public string FilterStringEmp
        {
            get { return _filterStringEmp; }
            set
            {
                _filterStringEmp = value;
                RaisePropertyChanged("FilterStringEmp");
                FilterCollectionEmp();
            }
        }
        public bool EmpFilter(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringEmp))
                {
                    return (data.EmpName != null && data.EmpName.ToLower().Contains(_filterStringEmp.ToLower())) ||
                            (data.EmpFName != null && data.EmpFName.ToLower().Contains(_filterStringEmp.ToLower())) ||
                             (data.EmpId != null && data.EmpId.ToLower().Contains(_filterStringEmp.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion


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


        private ICollectionView _PartyTypeCollection;
        public ICollectionView PartyTypeCollection
        {
            get { return _PartyTypeCollection; }
            set { _PartyTypeCollection = value; RaisePropertyChanged("PartyTypeCollection"); }
        }
        private ICollectionView _GroupCollection;
        public ICollectionView GroupCollection
        {
            get { return _GroupCollection; }
            set { _GroupCollection = value; RaisePropertyChanged("GroupCollection"); }
        }

        #region Filter Group
        public bool FilterGroup(object obj)
        {
            var data = obj as ADM_M028_A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringGroup))
                {
                    return (data.group1 != null && data.group1.ToString().ToLower().Contains(_filterStringGroup.ToLower()) || data.grpNm != null && data.grpNm.ToString().ToLower().Contains(_filterStringGroup.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterStringGroup;
        public string FilterStringGroup
        {
            get { return _filterStringGroup; }
            set
            {
                _filterStringGroup = value;
                RaisePropertyChanged("FilterStringGroup");
                FilterCollectionGroup();
            }
        }
        private void FilterCollectionGroup()
        {
            if (_GroupCollection != null)
            {
                _GroupCollection.Refresh();
            }
        }


        #endregion

        public bool FilterPartyType(object obj)
        {
            var data = obj as ADM_M028_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringPartyType))
                {
                    return (data.PartyType != null && data.PartyType.ToString().ToLower().Contains(_filterStringPartyType.ToLower()) || data.PartyType_Nm != null && data.PartyType_Nm.ToString().ToLower().Contains(_filterStringPartyType.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterStringPartyType;
        public string FilterStringPartyType
        {
            get { return _filterStringPartyType; }
            set
            {
                _filterStringPartyType = value;
                RaisePropertyChanged("FilterStringPartyType");
                FilterCollectionPartyType();
            }
        }
        private void FilterCollectionPartyType()
        {
            if (_PartyTypeCollection != null)
            {
                _PartyTypeCollection.Refresh();
            }
        }

        

        #endregion

        #region Entity Class
        public class MISReportParameter : ObjectBase
        {

            private Nullable<DateTime> _FromDate;
            public Nullable<DateTime> FromDate
            {
                get { return _FromDate; }
                set
                {
                    _FromDate = value;
                    RaisePropertyChanged("FromDate");
                }
            }

            private Nullable<DateTime> _ToDate;
            public Nullable<DateTime> ToDate
            {
                get { return _ToDate; }
                set
                {
                    _ToDate = value;
                    RaisePropertyChanged("ToDate");
                }
            }

            private string _LoctnNm;
            public string LoctnNm
            {
                get { return _LoctnNm; }
                set
                {
                    _LoctnNm = value;
                    RaisePropertyChanged("LoctnNm");
                }
            }

            private string _ReportCode;
            public string ReportCode
            {
                get { return _ReportCode; }
                set
                {
                    _ReportCode = value;
                    RaisePropertyChanged("ReportCode");
                }
            }
            private string _ReportName;
            public string ReportName
            {
                get { return _ReportName; }
                set
                {
                    _ReportName = value;
                    RaisePropertyChanged("ReportName");
                }
            }
            private bool _active;
            public bool active
            {
                get
                {
                    return _active;
                }

                set
                {
                    _active = value; RaisePropertyChanged("active");
                }
            }

            private string _StatusName;
            public string StatusName
            {
                get { return _StatusName; }
                set
                {
                    _StatusName = value;
                    RaisePropertyChanged("StatusName");
                }
            }
            private string _StatusCode;
            public string StatusCode
            {
                get { return _StatusCode; }
                set
                {
                    _StatusCode = value;
                    RaisePropertyChanged("StatusCode");
                }
            }

            private string _ItemCode;
            public string ItemCode
            {
                get { return _ItemCode; }
                set
                {
                    _ItemCode = value;
                    RaisePropertyChanged("ItemCode");
                }
            }

            private string _ItemName;
            public string ItemName
            {
                get { return _ItemName; }
                set
                {
                    _ItemName = value;
                    RaisePropertyChanged("ItemName");
                }
            }

            private string _PartyId;
            public string PartyId
            {
                get { return _PartyId; }
                set
                {
                    _PartyId = value;
                    RaisePropertyChanged("PartyId");
                }
            }

            private string _PartyNm;
            public string PartyNm
            {
                get { return _PartyNm; }
                set
                {
                    _PartyNm = value;
                    RaisePropertyChanged("PartyNm");
                }
            }

            private string _EmpId;
            public string EmpId
            {
                get { return _EmpId; }
                set
                {
                    _EmpId = value;
                    RaisePropertyChanged("EmpId");
                }
            }

            private string _EmpName;
            public string EmpName
            {
                get { return _EmpName; }
                set
                {
                    _EmpName = value;
                    RaisePropertyChanged("EmpName");
                }
            }

            private string _Location_Id;
            public string Location_Id
            {
                get { return _Location_Id; }
                set
                {
                    _Location_Id = value;
                    RaisePropertyChanged("Location_Id");
                }
            }

            private string _comp_code;
            public string comp_code
            {
                get { return _comp_code; }
                set
                {
                    _comp_code = value;
                    RaisePropertyChanged("comp_code");
                }
            }

            private string _doc_no;
            public string doc_no
            {
                get { return _doc_no; }
                set
                {
                    _doc_no = value;
                    RaisePropertyChanged("doc_no");
                }
            }

            private string _doc_cat;
            public string doc_cat
            {
                get { return _doc_cat; }
                set
                {
                    _doc_cat = value;
                    RaisePropertyChanged("doc_cat");
                }
            }

            private string _doc_type;
            public string doc_type
            {
                get { return _doc_type; }
                set
                {
                    _doc_type = value;
                    RaisePropertyChanged("doc_type");
                }
            }

            private string _fin_year;
            public string fin_year
            {
                get { return _fin_year; }
                set
                {
                    _fin_year = value;
                    RaisePropertyChanged("fin_year");
                }
            }

            private string _para1;
            public string para1
            {
                get { return _para1; }
                set
                {
                    _para1 = value;
                    RaisePropertyChanged("para1");
                }
            }

            private string _para2;
            public string para2
            {
                get { return _para2; }
                set
                {
                    _para2 = value;
                    RaisePropertyChanged("para2");
                }
            }

            private string _para3;
            public string para3
            {
                get { return _para3; }
                set
                {
                    _para3 = value;
                    RaisePropertyChanged("para3");
                }
            }

            private string _t_status;
            public string t_status
            {
                get { return _t_status; }
                set
                {
                    _t_status = value;
                    RaisePropertyChanged("t_status");
                }
            }
            private string _act_action;
            public string act_action
            {
                get { return _act_action; }
                set
                {
                    _act_action = value;
                    RaisePropertyChanged("act_action");
                }
            }
            private string _action_type;
            public string action_type
            {
                get { return _action_type; }
                set
                {
                    _action_type = value;
                    RaisePropertyChanged("action_type");
                }
            }
            private string _PartyType;

            public string PartyType
            {
                get { return _PartyType; }
                set
                {
                    _PartyType = value;
                    RaisePropertyChanged("PartyType");
                }
            }
            private string _PartyType_Nm;
            public string PartyType_Nm
            {
                get
                {
                    return _PartyType_Nm;
                }

                set
                {
                    _PartyType_Nm = value;
                    RaisePropertyChanged("PartyType_Nm");
                }
            }

            private string _group1;
            public string group1
            {
                get { return _group1; }
                set
                {
                    _group1 = value;
                    RaisePropertyChanged("group1");
                }
            }

            private string _grpNm;
            public string grpNm
            {
                get { return _grpNm; }
                set
                {
                    _grpNm = value;
                    RaisePropertyChanged("grpNm");
                }
            }

            private string _prospectus;
            public string prospectus
            {
                get { return _prospectus; }
                set
                {
                    _prospectus = value;
                    RaisePropertyChanged("prospectus");
                }
            }
        }
        #endregion
    }

}
