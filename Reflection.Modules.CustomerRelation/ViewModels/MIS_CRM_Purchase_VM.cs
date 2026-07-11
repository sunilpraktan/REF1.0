using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using System.Collections;
using Reflection.Presentation.Services;
using System.Data;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Common;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class MIS_CRM_Purchase_VM : WorkspaceViewModel<MIS_PurchaseReport>
    {
        #region Variables Declaration

        bool blNew = true;
        WebServiceRepository<List<MIS_CRM_PurchaseEntity>> repository = new WebServiceRepository<List<MIS_CRM_PurchaseEntity>>();
        WebServiceRepository<MultipleContextMIS_CRM_Purchase> repository_MC = new WebServiceRepository<MultipleContextMIS_CRM_Purchase>();
        ObjectSerializationService obj = new ObjectSerializationService();

        MultipleContextMIS_CRM_Purchase _MC = new MultipleContextMIS_CRM_Purchase();
        public MultipleContextMIS_CRM_Purchase MC
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

        private MIS_PurchaseReport _ReportParameters;
        public MIS_PurchaseReport ReportParameters
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

        private List<MIS_CRM_PurchaseEntity> _dsReport;
        public List<MIS_CRM_PurchaseEntity> dsReport
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
        private ICollectionView _StatusCollection;
        public ICollectionView StatusCollection
        {
            get { return _StatusCollection; }
            set { _StatusCollection = value; RaisePropertyChanged("StatusCollection"); }
        }

        private ICollectionView _EmployeeCollection;
        public ICollectionView EmployeeCollection
        {
            get { return _EmployeeCollection; }
            set { _EmployeeCollection = value; RaisePropertyChanged("EmployeeCollection"); }
        }

        private ICollectionView _PartyCollection;
        public ICollectionView PartyCollection
        {
            get { return _PartyCollection; }
            set { _PartyCollection = value; RaisePropertyChanged("PartyCollection"); }
        }

        private ICollectionView _ItemsCollection;
        public ICollectionView ItemsCollection
        {
            get { return _ItemsCollection; }
            set { _ItemsCollection = value; RaisePropertyChanged("ItemsCollection"); }
        }

        private ICollectionView _DocNoCollection;
        public ICollectionView DocNoCollection
        {
            get { return _DocNoCollection; }
            set { _DocNoCollection = value; RaisePropertyChanged("DocNoCollection"); }
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

        private ICollectionView _currancyCollection;
        public ICollectionView CurrancyCollection
        {
            get { return _currancyCollection; }
            set { _currancyCollection = value; RaisePropertyChanged("CurrancyCollection"); }
        }
        private ICollectionView _CategoryCollection;
        public ICollectionView CategoryCollection
        {
            get { return _CategoryCollection; }
            set { _CategoryCollection = value; RaisePropertyChanged("CategoryCollection"); }
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
        List<string> _stringListDocNo;
        public List<string> StringListDocNo
        {
            get { return _stringListDocNo; }
            set
            {
                if (_stringListDocNo != value)
                {
                    _stringListDocNo = value;
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
        private List<PUR_T001_A> _strListStatus;
        public List<PUR_T001_A> StrListStatus
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

        private List<string> _strListCurrency;
        public List<string> StringListCurrency
        {
            get { return _strListCurrency; }
            set
            {
                if (_strListCurrency != value)
                {
                    _strListCurrency = value;
                }
            }
        }
        #endregion

        #region RelayCommands      
        public RelayCommand CommandReport { get; private set; }
        public RelayCommand<object> cmdEmp { get; private set; }
        public RelayCommand CommandExport { get; private set; }
        public RelayCommand<object> cmdPartyChange { get; private set; }
        public RelayCommand<object> cmdItemChange { get; private set; }
        public RelayCommand<object> cmdCompanyChange { get; private set; }
        public RelayCommand<object> cmdPlantChange { get; private set; }
        public RelayCommand<object> cmdDocNoChange { get; private set; }
        public RelayCommand<object> CmdInsertCurrency { get; private set; }
        public RelayCommand<object> CmdInsertStatus { get; private set; }
        public RelayCommand<object> CmdInsertCategory { get; private set; }
        #endregion

        #region Constructor
        public MIS_CRM_Purchase_VM()
            : base()
        {
            CursorControl.SetBusyState();
            MC = new MultipleContextMIS_CRM_Purchase();
            ReportParameters = new MIS_PurchaseReport();         
            dsReport = new List<MIS_CRM_PurchaseEntity>();
            _dsReport = new List<MIS_CRM_PurchaseEntity>();
            ItemsDictionary = new Dictionary<string, string>();
            ItemsDictionary.Add("R001", "Purchase Enquiry(Details)");
            ItemsDictionary.Add("R002", "Purchase Enquiry(Summary)");
            ItemsDictionary.Add("R003", "Purchase Requisition(Details)");
            ItemsDictionary.Add("R004", "Purchase Requisition(Summary)");
            ItemsDictionary.Add("R005", "Purchase Requisition(Pending)");


            cmdEmp = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmp(items); });
            cmdPartyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items); });
            cmdItemChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
            cmdCompanyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            cmdPlantChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
            cmdDocNoChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocNo(items); });
            CmdInsertCurrency = new RelayCommand<object>(items => { if (items == null) { return; } InsertCurrency(items); });
            CmdInsertStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertStatus(items); });
            CmdInsertCategory = new RelayCommand<object>(items => { if (items == null) { return; } InsertCategory(items); });
            CommandReport = new RelayCommand(DisplayReport);
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
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContextMIS_CRM_Purchase>(MC, Request, "MIS_CRMPurchaseReport", "CRM", "LoadAll", 0, "");

                EmployeeCollection = CollectionViewSource.GetDefaultView(MC.EmployeeList.ToList());
                EmployeeCollection.Filter = new Predicate<object>(FilterEmp);
                StrListEmp = MC.EmployeeList.Select(x => x.EmpId).ToList();

                PartyCollection = CollectionViewSource.GetDefaultView(MC.partyDetails);
                PartyCollection.Filter = new Predicate<object>(FilterParty);
                StringListParty = MC.partyDetails.Select(x => x.PartyId).ToList();

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


                var LocWiseDoc = (from o in MC.DocNoList
                                      where o.location_Id == ReportParameters.location_Id
                                      select o).ToList();

                DocNoCollection = CollectionViewSource.GetDefaultView(LocWiseDoc.ToList());
                DocNoCollection.Filter = new Predicate<object>(FilterDocNo);
                StringListDocNo = MC.DocNoList.Select(x => x.po_no).ToList();

                CurrancyCollection = CollectionViewSource.GetDefaultView(MC.CurrencyList);
                CurrancyCollection.Filter = new Predicate<object>(Filter_Currency);
                StringListCurrency = MC.CurrencyList.Select(x => x.curr_code).ToList();

                CategoryCollection = CollectionViewSource.GetDefaultView(MC.CategoryDetails);
                CategoryCollection.Filter = new Predicate<object>(Filter_Category);
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
            ReportParameters.comp_code = AppSessionState.comp_code;
            ReportParameters.doc_cat = "";
            ReportParameters.dcat_name = "";
            ReportParameters.doc_no = "";
            ReportParameters.doc_type = "";
            //ReportParameters.fin_year = AppSessionState.FinYear;
            ReportParameters.location_Id = AppSessionState.location_Id;


            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            ReportParameters.FromDate = lastDayLastMonth.AddDays(0);
            ReportParameters.ToDate = DateTime.Now;
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
                //if (ReportParameters.ReportCode != null)
                //{
                //    if (ReportParameters.EmpId == null) { ReportParameters.EmpId = "All"; }
                //    // if (ReportParameters.EmpName  == null) { ReportParameters.EmpName  = "All"; }
                //    if (ReportParameters.PartyId == null) { ReportParameters.PartyId = "All"; }
                //    if (ReportParameters.PartyNm == null) { ReportParameters.PartyNm = "All"; }
                //    if (ReportParameters.ItemCode == null) { ReportParameters.ItemCode = "All"; }
                //    if (ReportParameters.ItemName == null) { ReportParameters.ItemName = "All"; }

                //}

                if (ReportParameters.ReportCode != null)
                {

                    string RequestParameter = "Report" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.ItemCode + "!@" + ReportParameters.PartyId + "!@" + ReportParameters.location_Id + "!@" + ReportParameters.comp_code + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParameters.po_no + "!@" + ReportParameters.EmpId + "!@" + ReportParameters.t_status + "!@" + ReportParameters.curr_code + "!@" + ReportParameters.CatCode + "!@" + AppSessionState.client;
                    dsReport = repository.GetDataWithReturnDomainObject<List<MIS_CRM_PurchaseEntity>>(dsReport, RequestParameter, "MIS_CRMPurchaseReport", "CRM", "", 0, RequestParameter);
                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(dsReport, "dsMIS_CRM_PurchaseEntity", "\\MIS\\Purchase\\" + GetReportFile(ReportParameters.ReportCode), getParametersList());
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
                result.Add("PartyId", ReportParameters.curr_code);
                result.Add("PartyNm", ReportParameters.PartyNm);
                result.Add("doc_type", ReportParameters.doc_type);
                result.Add("doc_cat", ReportParameters.doc_cat);
                result.Add("dcat_name", ReportParameters.dcat_name);
                result.Add("t_status", ReportParameters.t_status);
                result.Add("ReportName", ReportParameters.ReportName);
                result.Add("doc_no", ReportParameters.po_no);
                result.Add("comp_code", ReportParameters.comp_code);
                result.Add("location_Id", ReportParameters.location_Id);
                result.Add("ItemName", ReportParameters.ItemName);
               

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
                returnReportName = "PurchaseEnquiryDetails.rdlc";
            }
            if (ReportCode == "R002")
            {
                returnReportName = "PurchaseEnquirySummary.rdlc";
            }
            if (ReportCode == "R003")
            {
                returnReportName = "PurchaseReqDetails.rdlc";
            }
            if (ReportCode == "R004")
            {
                returnReportName = "PurchaseReqSummary.rdlc";
            }
            if (ReportCode == "R005")
            {
                returnReportName = "PurchaseReqSummary.rdlc";
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
  

        private void InsertParty(object InputValue)
        {
            string stringPartyId = "";
            string stringPartyNm = "";

            ReportParameters.PartyId = "";
            foreach (ADM_M028_P temp in MC.partyDetails)
            {
                if (temp.Select == true)
                {
                    stringPartyId = stringPartyId + "," + temp.PartyId;
                    stringPartyNm = stringPartyNm + "," + temp.PartyNm;

                }
            }
            ReportParameters.PartyId = stringPartyId.ToString().TrimStart(new char[] { ',' });
            ReportParameters.PartyNm = stringPartyNm.ToString().TrimStart(new char[] { ',' });

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
        private void InsertDocNo(object InputValue)
        {

            string stringDocNo = "";

            ReportParameters.po_no = "";
            foreach (PUR_T002_A_P temp in MC.DocNoList)
            {
                if (temp.Select == true)
                {
                    stringDocNo = stringDocNo + "," + temp.po_no;

                }
            }
            ReportParameters.po_no = stringDocNo.ToString().TrimStart(new char[] { ',' });

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
        private void InsertCurrency(object InputValue)
        {
            try
            {
                string Request;
                ADM_M037_P POPUPEntityObject = null;
                #region Command Parameter read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.CurrencyList.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M037_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null)
                {
                    ReportParameters.curr_code = POPUPEntityObject.curr_code;

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
        private void InsertStatus(object InputValue)
        {

            string stringStatus = "";
            //string stringStatusNm = "";

            ReportParameters.ItemCode = "";
            foreach (PUR_T001_A temp in MC.StatusDetails)
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
        private void InsertCategory(object InputValue)
        {

            string stringCategory = "";
            //string stringCategoryNm = "";

            ReportParameters.ItemCode = "";
            foreach (ADM_M018_P temp in MC.CategoryDetails)
            {
                if (temp.Select == true)
                {
                    stringCategory = stringCategory + "," + temp.CatCode;
                    //stringCategoryNm = stringCategoryNm + "," + temp.CatName;

                }
            }
            ReportParameters.CatCode = stringCategory.ToString().TrimStart(new char[] { ',' });
            //ReportParameters. = stringStatusNm.ToString().TrimStart(new char[] { ',' });

        }
        private void InsertPlant(object InputValue)
        {
            string stringLocation = "";
            string stringLocationNm = "";

            ReportParameters.location_Id = "";
            foreach (ADM_M003 temp in ObjPlant)
            {
                if (temp.Select == true)
                {
                    stringLocation = stringLocation + "," + temp.location_Id;
                    stringLocationNm = stringLocationNm + "," + temp.LoctnNm;

                }
            }
            ReportParameters.location_Id = stringLocation.ToString().TrimStart(new char[] { ',' });
            ReportParameters.LoctnNm = stringLocationNm.ToString().TrimStart(new char[] { ',' });

            var LocWiseDoc = (from o in MC.DocNoList
                              where o.location_Id == ReportParameters.location_Id
                              select o).ToList();

            DocNoCollection = CollectionViewSource.GetDefaultView(LocWiseDoc.ToList());
            DocNoCollection.Filter = new Predicate<object>(FilterDocNo);
            DocNoCollection.Refresh();

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
            var data = obj as PUR_T001_A;
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


        #region
        private string _filterString_DoCNo;
        public string FilterString_DoCNo
        {
            get { return _filterString_DoCNo; }
            set
            {
                _filterString_DoCNo = value;
                RaisePropertyChanged("FilterString_DoCNo");
                FilterCollectionDocNo();
            }
        }
        private void FilterCollectionDocNo()
        {
            if (_DocNoCollection != null)
            {
                _DocNoCollection.Refresh();
            }
        }
        public bool FilterDocNo(object obj)
        {
            var data = obj as PUR_T002_A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_DoCNo))
                {
                    return (data.po_no != null && data.po_no.ToString().ToLower().Contains(_filterString_DoCNo.ToLower()) ||
                            (data.po_date!= null && data.po_date.ToString().ToLower().Contains(_filterString_DoCNo.ToLower()))
                        );
                }
                return true;
            }
            return false;
        }
        #endregion


        #region
        private string _filterString_Category;
        public string FilterString_Category
        {
            get { return _filterString_Category; }
            set
            {
                _filterString_Category = value;
                RaisePropertyChanged("FilterString_Category");
                FilterCollection_Category();
            }
        }
        private void FilterCollection_Category()
        {
            if (_CategoryCollection != null)
            {
                _CategoryCollection.Refresh();
            }
        }
        public bool Filter_Category(object obj)
        {
            var data = obj as ADM_M018_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Category))
                {
                    return (data.CatCode != null && data.CatCode.ToString().ToLower().Contains(_filterString_Category.ToLower())) ||
                       (data.CatName != null && data.CatName.ToString().ToLower().Contains(_filterString_Category.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_Currency;
        public string FilterString_Currency
        {
            get { return _filterString_Currency; }
            set
            {
                _filterString_Currency = value;
                RaisePropertyChanged("FilterString_Currency");
                FilterCollection_Currency();
            }
        }
        private void FilterCollection_Currency()
        {
            if (_currancyCollection != null)
            {
                _currancyCollection.Refresh();
            }
        }
        public bool Filter_Currency(object obj)
        {
            var data = obj as ADM_M037_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Currency))
                {
                    return (data.curr_code != null && data.curr_code.ToString().ToLower().Contains(_filterString_Currency.ToLower())) ||
                       (data.curr_name != null && data.curr_name.ToString().ToLower().Contains(_filterString_Currency.ToLower()));
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

        #endregion

        #region . Command Action .
        protected override void OnSaveAction(InquiryActionResult<MIS_PurchaseReport> result)
        {

        }
        protected override void OnCreateAction(InquiryActionResult<MIS_PurchaseReport> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<MIS_PurchaseReport> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<MIS_PurchaseReport> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<MIS_PurchaseReport> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<MIS_PurchaseReport> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<MIS_PurchaseReport> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<MIS_PurchaseReport> result)
        {

        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_PurchaseReport> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_PurchaseReport> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_PurchaseReport> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_PurchaseReport> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_PurchaseReport> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
