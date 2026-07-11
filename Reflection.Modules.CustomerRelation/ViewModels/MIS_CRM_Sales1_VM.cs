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
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.Presentation.Common;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class MIS_CRM_Sales1_VM : WorkspaceViewModel<MIS_SalesReports>
    {
        #region Declaration

        bool blNew = true;
        WebServiceRepository<List<MIS_CRM_SalesEntity1>> repository = new WebServiceRepository<List<MIS_CRM_SalesEntity1>>();
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

        private List<MIS_CRM_SalesEntity1> _dsReport;
        public List<MIS_CRM_SalesEntity1> dsReport
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
        private ICollectionView _CategaryCollection;
        public ICollectionView CategaryCollection
        {
            get { return _CategaryCollection; }
            set { _CategaryCollection = value; RaisePropertyChanged("CategaryCollection"); }
        }
        private ICollectionView _SubCategaryCollection;
        public ICollectionView SubCategaryCollection
        {
            get { return _SubCategaryCollection; }
            set { _SubCategaryCollection = value; RaisePropertyChanged("SubCategaryCollection"); }
        }
        private ICollectionView _TradeTypesCollection;
        public ICollectionView TradeTypesCollection
        {
            get { return _TradeTypesCollection; }
            set { _TradeTypesCollection = value; RaisePropertyChanged("TradeTypesCollection"); }
        }
        private ICollectionView _uomCollection;
        public ICollectionView UomCollection
        {
            get { return _uomCollection; }
            set { _uomCollection = value; RaisePropertyChanged("UomCollection"); }
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
        public RelayCommand<object> cmdPartyChange { get; private set; }
        public RelayCommand<object> cmdItemChange { get; private set; }
        public RelayCommand<object> cmdCompanyChange { get; private set; }
        public RelayCommand<object> cmdPlantChange { get; private set; }
        public RelayCommand<object> cmdCategoryChange { get; private set; }
        public RelayCommand<object> cmdTradeTypesChange { get; private set; }
        public RelayCommand<object> cmdSubCategoryChange { get; private set; }
        public RelayCommand<object> cmdUnitChange { get; private set; }
        #endregion

        #region Constructor
        public MIS_CRM_Sales1_VM()
            : base()
        {
            CursorControl.SetBusyState();
            MC = new MultipleContextMISReports();
            ReportParameters = new MISReportParameter();
            _dsReport = new List<MIS_CRM_SalesEntity1>();
            ItemsDictionary = new Dictionary<string, string>();
            ItemsDictionary.Add("R001", "Status of Sales Orders");
            ItemsDictionary.Add("R002", "Status of Sales Order v/s Schedule(Summary)");
            ItemsDictionary.Add("R009", "Status of Sales Order v/s Schedule(Detail)");
            ItemsDictionary.Add("R003", "Status of Sales Order v/s Supply(Summary)");
            ItemsDictionary.Add("R010", "Status of Sales Order v/s Supply(Detail)");
            ItemsDictionary.Add("R005", "Status of requirement v/s Schedule(Summary)");
            ItemsDictionary.Add("R004", "Status of requirement v/s  Schedule(Detail)");
            ItemsDictionary.Add("R006", "Order without Customer PO Numbers");
            ItemsDictionary.Add("R007", "Invoices withot Customer PO Numbers");
            ItemsDictionary.Add("R008", "Invoices withot Sales Order");
            ItemsDictionary.Add("R011", "Invoice Report(Summary)");
            ItemsDictionary.Add("R012", "Invoice Report(Detail)");
            ItemsDictionary.Add("R013", "Schedule Report(Summary)");
            ItemsDictionary.Add("R014", "Schedule Report(Detail)");
            ItemsDictionary.Add("R015", "Status of Sales Order v/s Schedule v/s Invoice(Summary)");
            ItemsDictionary.Add("R016", "Status of Sales Order v/s Schedule v/s Invoice(Detail)");
            ItemsDictionary.Add("R017", "Logistics Report");
            ItemsDictionary.Add("R018", "Sales Statement Report");
            ItemsDictionary.Add("R019", "Schedule Dispatch Report");
            ItemsDictionary.Add("R020", "Pending Sales Order Report"); // NOTE: Remove once confirm from Client. Migrated to FR02 R0033 SDM_R033.rdlc
            ItemsDictionary.Add("R021", "Customer Wise Order Status (Pending)");
            ItemsDictionary.Add("R023", "Customer Wise Order Status (All)");
            ItemsDictionary.Add("R022", "Dispatch Detail Report");
            ItemsDictionary.Add("R024", "Project Wise Sales Order");
            ItemsDictionary.Add("R025", "Sales Quotation Report");

            cmdPartyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items, blNew); });
            cmdItemChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
            cmdCompanyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            cmdPlantChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
            cmdCategoryChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCategory(items); });
            cmdTradeTypesChange = new RelayCommand<object>(items => { if (items == null) { return; } TradeTypes(items); });
            cmdSubCategoryChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertSubCategory(items); });
            cmdUnitChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertUnit(items); });
            CommandReport = new RelayCommand(DisplayReport);
            // SelectionChangedCommandgodown = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedGodown(items); });

            LoadInitialData();
            DefaultValues();
        }
        #endregion

        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContextMISReports>(MC, Request, "MIS_CRMSalesReports", "CRM", "LoadAll", 0, "");

                PartyCollection = CollectionViewSource.GetDefaultView(MC.partyDetails);
                PartyCollection.Filter = new Predicate<object>(FilterParty);
                StringListParty = MC.partyDetails.Select(x => x.PartyId).ToList();

                ItemsCollection = CollectionViewSource.GetDefaultView(MC.ItemDetails);
                ItemsCollection.Filter = new Predicate<object>(FilterItem);
                StringListItems = MC.ItemDetails.Select(x => x.ItemCode).ToList();

                ObjComp = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                CompanyCollection = CollectionViewSource.GetDefaultView(ObjComp.ToList());
                CompanyCollection.Filter = new Predicate<object>(FilterCompany);
                StringListCompany = ObjComp.Select(x => x.comp_code).ToList();

                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantCollection = CollectionViewSource.GetDefaultView(ObjPlant.ToList());
                PlantCollection.Filter = new Predicate<object>(FilterPlant);
                StringListPlant = ObjPlant.Select(x => x.location_Id).ToList();

                CategaryCollection = CollectionViewSource.GetDefaultView(MC.CategoryList);
                CategaryCollection.Filter = new Predicate<object>(FilterCategary);

                TradeTypesCollection = CollectionViewSource.GetDefaultView(MC.Trade_Types);
                TradeTypesCollection.Filter = new Predicate<object>(FilterTradeTypes);

                UomCollection = CollectionViewSource.GetDefaultView(MC.UOM.ToList());
                UomCollection.Filter = new Predicate<object>(FilterUom);

                //DefaultValues();
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
            ReportParameters.Location_Id = AppSessionState.location_Id;

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

        // User Defined Function
        private void DisplayReport()
        {
            CursorControl.SetBusyState();
            try
            {
                if (string.IsNullOrWhiteSpace(ReportParameters.ReportCode))
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Report Type");
                    showMessageService.ShowMessage();
                }
                else if (string.IsNullOrWhiteSpace(ReportParameters.unit_code))
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Unit of Measurement");
                    showMessageService.ShowMessage();
                }
                else if (ReportParameters.ReportCode != null)
                {
                    string RequestParameter = "Report" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.ItemCode + "!@" + ReportParameters.PartyId + "!@" + ReportParameters.Location_Id + "!@" + AppSessionState.comp_code + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParameters.doc_no + "!@" + ReportParameters.t_status + "!@" + ReportParameters.CatCode + "!@" + ReportParameters.ind_trade + "!@" + ReportParameters.SubCatCode + "!@" + ReportParameters.unit_code + "!@" + AppSessionState.client;
                    dsReport = repository.GetDataWithReturnDomainObject<List<MIS_CRM_SalesEntity1>>(dsReport, RequestParameter, "MIS_CRMSalesReports", "CRM", "", 0, RequestParameter);
                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(dsReport, "dsMIS_CRM_Sales1", "\\CRM\\" + GetReportFile(ReportParameters.ReportCode), getParametersList());
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
                result.Add("PartyId", ReportParameters.PartyId);
                result.Add("PartyNm", ReportParameters.PartyNm);
                result.Add("doc_type", ReportParameters.doc_type);
                result.Add("doc_cat", ReportParameters.doc_cat);
                result.Add("t_status", ReportParameters.t_status);
                result.Add("ReportNm", ReportParameters.ReportName);
                result.Add("doc_no", ReportParameters.doc_no);
                result.Add("comp_code", ReportParameters.comp_code);
                result.Add("Location_Id", ReportParameters.Location_Id);
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
            { returnReportName = "StatusOfClosePO.rdlc"; }
            else if (ReportCode == "R002")
            { returnReportName = "StatusOfPOScheduleSupply.rdlc"; }
            else if (ReportCode == "R009")
            { returnReportName = "StatusOfPOScheduleSupplyDetail.rdlc"; }
            else if (ReportCode == "R003")
            { returnReportName = "StatusOfPOSupply.rdlc"; }
            else if (ReportCode == "R010")
            { returnReportName = "StatusOfPOSupplyDetail.rdlc"; }
            else if (ReportCode == "R005")
            { returnReportName = "StatusRequirementSchedule.rdlc"; }
            else if (ReportCode == "R004")
            { returnReportName = "StatusRequirementScheduleDetail.rdlc"; }
            else if (ReportCode == "R006")
            { returnReportName = "S.OWithoutP.O.rdlc"; }
            else if (ReportCode == "R007")
            { returnReportName = "InvoicesWithoutPO.rdlc"; }
            else if (ReportCode == "R008")
            { returnReportName = "InvoicesWithoutPO.rdlc"; }
            else if (ReportCode == "R011")
            { returnReportName = "StatusOfPOSupply.rdlc"; }
            else if (ReportCode == "R012")
            { returnReportName = "StatusOfPOSupplyDetail.rdlc"; }
            else if (ReportCode == "R013")
            { returnReportName = "StatusOfPOScheduleSupply.rdlc"; }
            else if (ReportCode == "R014")
            { returnReportName = "StatusOfPOScheduleSupplyDetail.rdlc"; }
            else if (ReportCode == "R015")
            { returnReportName = "StatusOfPOScheduleDispatch.rdlc"; }
            else if (ReportCode == "R016")
            { returnReportName = "StatusOfPOScheduleDispatchDetail.rdlc"; }
            else if (ReportCode == "R017")
            { returnReportName = "CustomerWiseAutoSalesInvoice.rdlc"; }
            else if (ReportCode == "R018")
            { returnReportName = "SalesStatementReport.rdlc"; }
            else if (ReportCode == "R019")
            { returnReportName = "ScheduleDispatchReport.rdlc"; }
            else if (ReportCode == "R020")
            { returnReportName = "StatusOfClosePO.rdlc"; }
            else if (ReportCode == "R021")
            { returnReportName = "Customer_Wise_Order_Status.rdlc"; }
            else if (ReportCode == "R022")
            { returnReportName = "DispatchDetails.rdlc"; }
            else if (ReportCode == "R023")
            { returnReportName = "Customer_Wise_Order_Status.rdlc"; }
            else if (ReportCode == "R024")
            { returnReportName = "StatusOfClosePO.rdlc"; }
            else if (ReportCode == "R025")
            { returnReportName = "QuotationReport.rdlc"; }
            return returnReportName;
        }
        private void InsertParty(object InputValue, bool OverrideValue)
        {
            //string Request = "";
            //ADM_M028_P POPUPEntityObject = null;
            //try
            //{
            //    if (InputValue.GetType() == typeof(string) && InputValue != null)
            //    {
            //        Request = InputValue.ToString();
            //        if (Request.Length > 0)
            //        {
            //            try
            //            { POPUPEntityObject = MC.partyDetails.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
            //            catch (Exception ex) { }
            //        }
            //    }
            //    else if (InputValue != null)
            //    {
            //        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
            //    }
            //}
            //catch (Exception ex) { }

            //if (POPUPEntityObject != null)
            //{
            //    ReportParameters.PartyId = POPUPEntityObject.PartyId;
            //    ReportParameters.PartyNm = POPUPEntityObject.PartyNm;
            //}

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
            string Request = "";
            ADM_M022_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ItemDetails.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                ReportParameters.ItemCode = POPUPEntityObject.ItemCode;
                ReportParameters.ItemName = POPUPEntityObject.ItemName;
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

                ReportParameters.Location_Id = POPUPEntityObject.location_Id;
            }
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
                        { POPUPEntityObject = MC.UOM.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
        private void InsertCategory(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M018_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.CategoryList.Where(x => x.CatCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M018_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    ReportParameters.CatCode = POPUPEntityObject.CatCode;
                    ReportParameters.CatName = POPUPEntityObject.CatName;

                    if (POPUPEntityObject.CatCode != "" || POPUPEntityObject.CatCode != null)
                    {
                        var abc = from data in MC.SubCategoryList
                                  where data.CatCode == POPUPEntityObject.CatCode
                                  select data;

                        SubCategaryCollection = CollectionViewSource.GetDefaultView(abc.ToList());
                        SubCategaryCollection.Filter = new Predicate<object>(FilterSubCategary);

                    }
                    else
                    {
                        SubCategaryCollection = CollectionViewSource.GetDefaultView(MC.SubCategoryList.ToList());
                        SubCategaryCollection.Filter = new Predicate<object>(FilterSubCategary);
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
        private void InsertSubCategory(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M019_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SubCategoryList.Where(x => x.SubCatCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M019_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    ReportParameters.SubCatCode = POPUPEntityObject.SubCatCode;
                    ReportParameters.SubCatName = POPUPEntityObject.SubCatName;

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
        //private void InsertCategory(object InputValue)
        //{
        //    string Request = "";
        //    ADM_M018_P POPUPEntityObject = null;
        //    try
        //    {
        //        if (InputValue.GetType() == typeof(string) && InputValue != null)
        //        {
        //            Request = InputValue.ToString();
        //            if (Request.Length > 0)
        //            {
        //                try
        //                { POPUPEntityObject = MC.CategoryList.Where(x => x.CatCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                catch (Exception ex) { }
        //            }
        //        }
        //        else if (InputValue != null)
        //        {
        //            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M018_P>().ToList()[0];
        //        }
        //    }
        //    catch (Exception ex) { }

        //    if (POPUPEntityObject != null)
        //    {
        //        ReportParameters.CatCode = POPUPEntityObject.CatCode;
        //        ReportParameters.CatName = POPUPEntityObject.CatName;
        //    }
        //}
        private void TradeTypes(object InputValue)
        {
            string Request = "";
            SYS_M037 POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Trade_Types.Where(x => x.ind_trade.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M037>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                ReportParameters.ind_trade = POPUPEntityObject.ind_trade;
                ReportParameters.trade_name = POPUPEntityObject.trade_name;
            }
        }

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

        private string _filterString_Categary;
        public string FilterString_Categary
        {
            get { return _filterString_Categary; }
            set
            {
                _filterString_Categary = value;
                RaisePropertyChanged("FilterString_Categary");
                FilterCollectionCategary();
            }
        }
        private void FilterCollectionCategary()
        {
            if (_CategaryCollection != null)
            {
                _CategaryCollection.Refresh();
            }
        }
        public bool FilterCategary(object obj)
        {
            var data = obj as ADM_M018_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Categary))
                {
                    return (data.CatCode != null && data.CatCode.ToString().ToLower().Contains(_filterString_Categary.ToLower()) ||
                            (data.CatName != null && data.CatName.ToString().ToLower().Contains(_filterString_Categary.ToLower()))
                        );
                }
                return true;
            }
            return false;
        }

        private string _filterStringSubCategary;
        public string FilterStringSubCategary
        {
            get { return _filterStringSubCategary; }
            set
            {
                _filterStringSubCategary = value;
                RaisePropertyChanged("FilterStringSubCategary");
                FilterCollectionSubCategary();
            }
        }
        private void FilterCollectionSubCategary()
        {
            if (_SubCategaryCollection != null)
            {
                _SubCategaryCollection.Refresh();
            }
        }
        public bool FilterSubCategary(object obj)
        {
            var data = obj as ADM_M019_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringSubCategary))
                {
                    return (data.SubCatCode != null && data.SubCatCode.ToString().ToLower().Contains(_filterStringSubCategary.ToLower()) ||
                            (data.SubCatName != null && data.SubCatName.ToString().ToLower().Contains(_filterStringSubCategary.ToLower()))
                        );
                }
                return true;
            }
            return false;
        }

        private string _filterStringTradeTypes;
        public string FilterStringTradeTypes
        {
            get { return _filterStringTradeTypes; }
            set
            {
                _filterStringTradeTypes = value;
                RaisePropertyChanged("FilterStringTradeTypes");
                FilterCollectionTradeTypes();
            }
        }
        private void FilterCollectionTradeTypes()
        {
            if (_TradeTypesCollection != null)
            {
                _TradeTypesCollection.Refresh();
            }
        }
        public bool FilterTradeTypes(object obj)
        {
            var data = obj as SYS_M037;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringTradeTypes))
                {
                    return (data.ind_trade != null && data.ind_trade.ToString().ToLower().Contains(_filterStringTradeTypes.ToLower()) ||
                            (data.trade_name != null && data.trade_name.ToString().ToLower().Contains(_filterStringTradeTypes.ToLower()))
                        );
                }
                return true;
            }
            return false;
        }
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
    }

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
        private string _CatCode;
        public string CatCode
        {
            get { return _CatCode; }
            set
            {
                _CatCode = value;
                RaisePropertyChanged("CatCode");
            }
        }
        private string _CatName;
        public string CatName
        {
            get { return _CatName; }
            set
            {
                _CatName = value;
                RaisePropertyChanged("CatName");
            }
        }

        private string _SubCatCode;
        public string SubCatCode
        {
            get { return _SubCatCode; }
            set
            {
                _SubCatCode = value;
                RaisePropertyChanged("SubCatCode");
            }
        }
        private string _SubCatName;
        public string SubCatName
        {
            get { return _SubCatName; }
            set
            {
                _SubCatName = value;
                RaisePropertyChanged("SubCatName");
            }
        }
        private string _ind_trade;
        public string ind_trade
        {
            get { return _ind_trade; }
            set
            {
                _ind_trade = value;
                RaisePropertyChanged("ind_trade");
            }
        }
        private string _trade_name;
        public string trade_name
        {
            get { return _trade_name; }
            set
            {
                _trade_name = value;
                RaisePropertyChanged("trade_name");
            }
        }
        private string _unit_code;
        public string unit_code
        {
            get { return _unit_code; }
            set
            {
                _unit_code = value;
                RaisePropertyChanged("unit_code");
            }
        }
    }
}
