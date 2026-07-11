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
    public class MIS_CRM_Sales4_VM : WorkspaceViewModel<MIS_SalesReport3>
    {
        #region Variables Declaration

        bool blNew = true;
        WebServiceRepository<List<MIS_CRM_SalesEntity3>> repository = new WebServiceRepository<List<MIS_CRM_SalesEntity3>>();
        WebServiceRepository<MultipleContextMISReports3> repository_MC = new WebServiceRepository<MultipleContextMISReports3>();
        ObjectSerializationService obj = new ObjectSerializationService();

        MultipleContextMISReports3 _MC = new MultipleContextMISReports3();
        public MultipleContextMISReports3 MC
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

        private MIS_SalesReport3 _ReportParameters;
        public MIS_SalesReport3 ReportParameters
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

        private Dictionary<string, object> _DocCatDictionary;
        public Dictionary<string, object> DocCatDictionary
        {
            get { return _DocCatDictionary; }
            set
            {
                if (_DocCatDictionary != value)
                {
                    _DocCatDictionary = value;
                    RaisePropertyChanged("DocCatDictionary");
                }
            }
        }

        private Dictionary<string, object> _DocTypeDictionary;
        public Dictionary<string, object> DocTypeDictionary
        {
            get { return _DocTypeDictionary; }
            set
            {
                if (_DocTypeDictionary != value)
                {
                    _DocTypeDictionary = value;
                    RaisePropertyChanged("DocTypeDictionary");
                }
            }
        }

        private List<MIS_CRM_SalesEntity3> _dsReport;
        public List<MIS_CRM_SalesEntity3> dsReport
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


        public List<ADM_M001_A_P> _SalesOrganisationList;
        public List<ADM_M001_A_P> SalesOrganisationList
        {
            get
            {
                return _SalesOrganisationList;
            }
            set
            {
                _SalesOrganisationList = value;
                RaisePropertyChanged("SalesOrganisationList");
            }
        }

        public List<ADM_M001_H_P> _SalesGroupList;
        public List<ADM_M001_H_P> SalesGroupList
        {
            get
            {
                return _SalesGroupList;
            }
            set
            {
                _SalesGroupList = value;
                RaisePropertyChanged("SalesGroupList");
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

        private ICollectionView _DocCatCollection;
        public ICollectionView DocCatCollection
        {
            get { return _DocCatCollection; }
            set { _DocCatCollection = value; RaisePropertyChanged("DocCatCollection"); }
        }

        private ICollectionView _DocTypeCollection;
        public ICollectionView DocTypeCollection
        {
            get { return _DocTypeCollection; }
            set { _DocTypeCollection = value; RaisePropertyChanged("DocTypeCollection"); }
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
        private ICollectionView _CompanyCollection;
        public ICollectionView CompanyCollection
        {
            get { return _CompanyCollection; }
            set { _CompanyCollection = value; RaisePropertyChanged("CompanyCollection"); }
        }

        private ICollectionView _CategoryCollection;
        public ICollectionView CategoryCollection
        {
            get { return _CategoryCollection; }
            set { _CategoryCollection = value; RaisePropertyChanged("CategoryCollection"); }
        }

        private ICollectionView _TypeCollection;
        public ICollectionView TypeCollection
        {
            get { return _TypeCollection; }
            set { _TypeCollection = value; RaisePropertyChanged("TypeCollection"); }
        }

        private ICollectionView _PlantCollection;
        public ICollectionView PlantCollection
        {
            get { return _PlantCollection; }
            set { _PlantCollection = value; RaisePropertyChanged("PlantCollection"); }
        }


        private ICollectionView _sales_orgCollection;
        public ICollectionView Salse_OrgCollection
        {
            get { return _sales_orgCollection; }
            set
            {
                _sales_orgCollection = value;
                RaisePropertyChanged("Salse_OrgCollection");
            }
        }

        private ICollectionView _salse_GroupCollection;
        public ICollectionView Salse_GroupCollection
        {
            get { return _salse_GroupCollection; }
            set
            {
                _salse_GroupCollection = value;
                RaisePropertyChanged("Salse_GroupCollection");
            }
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

        private List<string> _strListCategory;
        public List<string> StrListCategory
        {
            get { return _strListCategory; }
            set
            {
                if (_strListCategory != value)
                {
                    _strListCategory = value;
                }
            }
        }

        private List<string> _strListType;
        public List<string> StrListType
        {
            get { return _strListType; }
            set
            {
                if (_strListType != value)
                {
                    _strListType = value;
                }
            }
        }

        private List<string> _strListSalesOrg;
        public List<string> StringListSalesOrg
        {
            get { return _strListSalesOrg; }
            set
            {
                if (_strListSalesOrg != value)
                {
                    _strListSalesOrg = value;
                }
            }
        }

        private List<string> _strListSalesGroup;
        public List<string> StringListSalesGroup
        {
            get { return _strListSalesGroup; }
            set
            {
                if (_strListSalesGroup != value)
                {
                    _strListSalesGroup = value;
                }
            }
        }
        private List<SYS_M001_P> _strListDocCat;
        public List<SYS_M001_P> StrListDocCat
        {
            get { return _strListDocCat; }
            set
            {
                if (_strListDocCat != value)
                {
                    _strListDocCat = value;
                    RaisePropertyChanged("StrListDocCat");
                }
            }
        }

        private List<SYS_M002_P> _strListDocType;
        public List<SYS_M002_P> StrListDocType
        {
            get { return _strListDocType; }
            set
            {
                if (_strListDocType != value)
                {
                    _strListDocType = value;
                    RaisePropertyChanged("StrListDocType");
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
        public RelayCommand<object> cmdDocCat { get; private set; }
        public RelayCommand<object> cmdDocType { get; private set; }
        public RelayCommand<object> cmdPlantChange { get; private set; }
        public RelayCommand<object> CommandSalseOrg { get; private set; }
        public RelayCommand<object> CommandSalseGroup { get; private set; }
        public RelayCommand<object> cmdCategoryChange { get; private set; }
        public RelayCommand<object> cmdSubCategoryChange { get; private set; }
        public RelayCommand<object> cmdTradeTypesChange { get; private set; }
        #endregion

        #region Constructor
        public MIS_CRM_Sales4_VM()
            : base()
        {
            CursorControl.SetBusyState();
            MC = new MultipleContextMISReports3();
            ReportParameters = new MIS_SalesReport3();
            _dsReport = new List<MIS_CRM_SalesEntity3>();
            ItemsDictionary = new Dictionary<string, string>();
            //ItemsDictionary.Add("R010", "Sales Document (Summary)");
            ItemsDictionary.Add("R001", "Sales Document(Order/Quotation/Inquiry)"); // NOTE: Remove once confirm from Client. Migrated to SR02 R0032 SDM_M032.rdlc
            ItemsDictionary.Add("R008", "Sales Register (Summary)");                // NOTE: Remove once confirm from Client. Migrated to FR02 R0016 FICO_M015.rdlc
            ItemsDictionary.Add("R002", "Sales Register");                          // NOTE: Remove once confirm from Client. Migrated to FR02 R0017 FICO_M016.rdlc
            ItemsDictionary.Add("R003", "Receivable Amount");
            ItemsDictionary.Add("R007", "Quotations Aging Report");
            ItemsDictionary.Add("R009", "Sales Inquiry Report");
            ItemsDictionary.Add("R011", "Transaction History Report");
            ItemsDictionary.Add("R013", "ItemWise Transaction History Report");
            // ItemsDictionary.Add("R014", "Document History");
            ItemsDictionary.Add("R015", "Document History Report");
            ItemsDictionary.Add("R012", "Non Finalize Quotation");
            ItemsDictionary.Add("R016", "Non Finalize Order");
            ItemsDictionary.Add("R018", "Monthwise Non Finalize Quotation");
            ItemsDictionary.Add("R019", "Transaction History Report (Qty)");
            ItemsDictionary.Add("R020", "Export Sales Party Wise Summary");
            ItemsDictionary.Add("R021", "GST Report");
            ItemsDictionary.Add("R027", "GST Report Item Wise");
            ItemsDictionary.Add("R023", "Pending Dispatch Order");
            ItemsDictionary.Add("R025", "Pending Dispatch Order Summury");
            ItemsDictionary.Add("R024", "Abstract Sales Report");



            StatusDictionary = new Dictionary<string, object>();
            StatusDictionary.Add("All", "All");
            StatusDictionary.Add("004", "Open");
            StatusDictionary.Add("003", "Closed");
            StatusDictionary.Add("001", "Draft");
            StatusDictionary.Add("013", "Cancelled");
            StatusDictionary.Add("002", "Released");


            cmdEmp = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmp(items); });
            cmdPartyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items, blNew); });
            cmdItemChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
            cmdCompanyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            cmdPlantChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
            cmdDocCat = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocCat(items); });
            cmdDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocType(items); });
            CommandReport = new RelayCommand(DisplayReport);
            CommandSalseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseOrg(items, blNew); });
            CommandSalseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseGroup(items, blNew); });
            cmdCategoryChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCategory(items); });
            cmdSubCategoryChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertSubCategory(items); });
            cmdTradeTypesChange = new RelayCommand<object>(items => { if (items == null) { return; } TradeTypes(items); });
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
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContextMISReports3>(MC, Request, "MIS_CRMSalesReport3", "CRM", "LoadAll", 0, "");

                EmployeeCollection = CollectionViewSource.GetDefaultView(MC.EmployeeList.ToList());
                EmployeeCollection.Filter = new Predicate<object>(FilterEmp);
                StrListEmp = MC.EmployeeList.Select(x => x.EmpId).ToList();

                PartyCollection = CollectionViewSource.GetDefaultView(MC.partyDetails);
                PartyCollection.Filter = new Predicate<object>(FilterParty);
                StringListParty = MC.partyDetails.Select(x => x.PartyId).ToList();

                ItemsCollection = CollectionViewSource.GetDefaultView(MC.ItemDetails);
                ItemsCollection.Filter = new Predicate<object>(FilterItem);
                StringListItems = MC.ItemDetails.Select(x => x.ItemCode).ToList();

                CategoryCollection = CollectionViewSource.GetDefaultView(MC.DocCatDetails);
                CategoryCollection.Filter = new Predicate<object>(FilterCategory);
                StrListCategory = MC.DocCatDetails.Select(x => x.doc_cat).ToList();



                //var DocCatList = (from o in MC.DocCatDetails
                //                  where o.doc_cat != null
                //                  select o).ToList();
                //_strListDocCat = DocCatList;
                //DocCatDictionary = _strListDocCat.ToDictionary(X => X.doc_cat.ToString(), X => (object)X.dcat_name);

                //var DocTypeList = (from o in MC.DocTypeDetails
                //                  where o.doc_cat == ReportParameters.doc_cat
                //                  select o).ToList();
                //_strListDocType = DocTypeList;
                //DocTypeDictionary = _strListDocType.ToDictionary(X => X.doc_type.ToString(), X => (object)X.doc_desc);

                ObjComp = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                CompanyCollection = CollectionViewSource.GetDefaultView(ObjComp.ToList());
                CompanyCollection.Filter = new Predicate<object>(FilterCompany);
                StringListCompany = ObjComp.Select(x => x.comp_code).ToList();

                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantCollection = CollectionViewSource.GetDefaultView(ObjPlant.ToList());
                PlantCollection.Filter = new Predicate<object>(FilterPlant);
                StringListPlant = ObjPlant.Select(x => x.location_Id).ToList();


                SalesOrganisationList = (List<ADM_M001_A_P>)AppSessionState.ADM_M001_A_List;
                Salse_OrgCollection = CollectionViewSource.GetDefaultView(SalesOrganisationList);
                Salse_OrgCollection.Filter = new Predicate<object>(Filter_SalesOrg);
                StringListSalesOrg = SalesOrganisationList.Select(x => x.so_code).ToList();
                if (SalesOrganisationList.Count != 0)
                {
                    if (SalesOrganisationList.Count == 1)
                    {
                        ReportParameters.so_code = SalesOrganisationList[0].so_code;
                        ReportParameters.sales_org = SalesOrganisationList[0].sales_org;
                    }
                }
                else
                {
                    ReportParameters.so_code = "";
                }
                SalesGroupList = (List<ADM_M001_H_P>)AppSessionState.ADM_M001_H_List;
                Salse_GroupCollection = CollectionViewSource.GetDefaultView(SalesGroupList);
                Salse_GroupCollection.Filter = new Predicate<object>(Filter_SalesGroup);
                StringListSalesGroup = SalesGroupList.Select(x => x.sg_code).ToList();

                if (SalesGroupList.Count != 0)
                {
                    if (SalesGroupList.Count == 1)
                    {
                        ReportParameters.sg_code = SalesGroupList[0].sg_code;
                        ReportParameters.sg_name = SalesGroupList[0].sg_name;
                    }
                }
                else
                {
                    ReportParameters.sg_code = "";
                }

                CategaryCollection = CollectionViewSource.GetDefaultView(MC.CategoryList);
                CategaryCollection.Filter = new Predicate<object>(FilterCategary);

                //SubCategaryCollection = CollectionViewSource.GetDefaultView(MC.SubCategoryList);
                //SubCategaryCollection.Filter = new Predicate<object>(FilterSubCategary);

                TradeTypesCollection = CollectionViewSource.GetDefaultView(MC.Trade_Types);
                TradeTypesCollection.Filter = new Predicate<object>(FilterTradeTypes);
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
            //ReportParameters.t_status = "";
            ReportParameters.comp_code = AppSessionState.comp_code;
            // ReportParameters.doc_cat = "";
            // ReportParameters.dcat_name = "";
            ReportParameters.doc_no = "";
            // ReportParameters.doc_type = "";
            //ReportParameters.fin_year = AppSessionState.FinYear;
            ReportParameters.location_Id = AppSessionState.location_Id;


            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, 4, 1);
            ReportParameters.FromDate = lastDayLastMonth;
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
                else
                {
                    if (ReportParameters.ReportCode != null)
                    {
                        if (ReportParameters.ReportCode == "R015" && (ReportParameters.doc_cat == null || ReportParameters.doc_cat == "") && (ReportParameters.doc_no == null || ReportParameters.doc_no == ""))
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Enter Doc No. & Doc Category", this.Title);
                            showMessageService.ShowMessage();
                        }
                        else
                        {
                            //if (ReportParameters.EmpId == null) { ReportParameters.EmpId = "All"; }
                            //if (ReportParameters.EmpName == null) { ReportParameters.EmpName = "All"; }
                            //if (ReportParameters.PartyId == null) { ReportParameters.PartyId = "All"; }
                            //if (ReportParameters.PartyNm == null) { ReportParameters.PartyNm = "All"; }
                            //if (ReportParameters.ItemCode == null) { ReportParameters.ItemCode = "All"; }
                            //if (ReportParameters.ItemName == null) { ReportParameters.ItemName = "All"; }
                            //if (ReportParameters.doc_cat == null) { ReportParameters.doc_cat = "All"; }
                            //if (ReportParameters.dcat_name == null) { ReportParameters.dcat_name = "All"; }
                            //if (ReportParameters.doc_type == null) { ReportParameters.doc_type = "All"; }
                            //if (ReportParameters.doc_desc == null) { ReportParameters.doc_desc = "All"; }



                            string RequestParameter = "Report" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.ItemCode + "!@" + ReportParameters.PartyId + "!@" + ReportParameters.location_Id + "!@" + AppSessionState.comp_code + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParameters.doc_no + "!@" + ReportParameters.doc_cat + "!@" + ReportParameters.EmpId + "!@" + ReportParameters.t_status + "!@" + ReportParameters.so_code + "!@" + ReportParameters.sg_code + "!@" + ReportParameters.agingperiod + "!@" + ReportParameters.doc_type + "!@" + ReportParameters.CatCode + "!@" + ReportParameters.ind_trade + "!@" + ReportParameters.SubCatCode;
                            dsReport = repository.GetDataWithReturnDomainObject<List<MIS_CRM_SalesEntity3>>(dsReport, RequestParameter, "MIS_CRMSalesReport3", "CRM", "", 0, RequestParameter);
                            ReportManager ReportManager = new ReportManager();
                            ReportManager.DisplayReport(dsReport, "dsMIS_CRM_SalesEntity3", "\\CRM\\" + GetReportFile(ReportParameters.ReportCode), getParametersList());
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
                result.Add("doc_type", ReportParameters.doc_no);
                result.Add("doc_cat", ReportParameters.doc_cat);
                result.Add("t_status", ReportParameters.t_status);
                result.Add("ReportNm", ReportParameters.ReportName);
                result.Add("doc_no", ReportParameters.EmpName);
                result.Add("comp_code", ReportParameters.comp_code);
                result.Add("location_Id", ReportParameters.location_Id);
                result.Add("ItemName", ReportParameters.ItemName);
                result.Add("dcat_name", ReportParameters.dcat_name);

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
                returnReportName = "SdReport.rdlc";
            }
            else if (ReportCode == "R002")
            {
                returnReportName = "SalesInvoice.rdlc";
            }
            else if (ReportCode == "R003")
            {
                returnReportName = "SalesInvoiceOutstanding.rdlc";
            }
            else if (ReportCode == "R007")
            {
                returnReportName = "QuotationsAgingReport.rdlc";
            }
            else if (ReportCode == "R008")
            {
                returnReportName = "SalesInvoice(Summary).rdlc";
            }
            else if (ReportCode == "R009")
            {
                returnReportName = "SalesInquiryReport.rdlc";
            }
            //else if (ReportCode == "R010")
            //{
            //    returnReportName = "SdReport(Summary).rdlc";
            //}
            else if (ReportCode == "R011")
            {
                returnReportName = "TransactionHistory.rdlc";
            }
            else if (ReportCode == "R012")
            {
                returnReportName = "NonFinaliseQuotation.rdlc";
            }
            else if (ReportCode == "R013")
            {
                returnReportName = "ItemWiseTransactionHistory.rdlc";
            }
            //else if (ReportCode == "R014")
            //{
            //    returnReportName = "DocNoHistory.rdlc";
            //}
            else if (ReportCode == "R015")
            {
                returnReportName = "DocNoHistory2.rdlc";
            }
            else if (ReportCode == "R016")
            {
                returnReportName = "NonFinaliseOrder.rdlc";
            }
            else if (ReportCode == "R018")
            {
                returnReportName = "MonthWiseNonFinaliseQuotation.rdlc";
            }
            else if (ReportCode == "R019")
            {
                returnReportName = "TransactionQtyHistory.rdlc";
            }
            else if (ReportCode == "R020")
            {
                returnReportName = "ExportSalesPartyWiseSummary.rdlc";
            }
            else if (ReportCode == "R021")
            {
                returnReportName = "GSTReport.rdlc";
            }
            else if (ReportCode == "R023")
            {
                returnReportName = "PendingDispatchOrder.rdlc";
            }
            else if (ReportCode == "R024")
            {
                returnReportName = "SalesAbstract.rdlc";
            }
            else if (ReportCode == "R025")
            {
                returnReportName = "PendingDispatchOrderSummury.rdlc";
            }
            else if (ReportCode == "R027")
            {
                returnReportName = "GSTReportItemWise.rdlc";
            }
            return returnReportName;
        }


        private void InsertEmp(object InputValue)
        {
            try
            {
                string stringEmp = "";
                string stringEmpNm = "";
                ReportParameters.EmpId = "";
                foreach (ADM_M024_P temp in MC.EmployeeList)
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

        }
        //private void InsertSalseOrg(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ADM_M001_A_P POPUPEntityObject = null;
        //        #region Command Parameter Read Section
        //        try
        //        {
        //            if (InputValue.GetType() == typeof(string) && InputValue != null)
        //            {
        //                Request = InputValue.ToString();
        //                if (Request.Length > 0)
        //                {
        //                    try
        //                    { POPUPEntityObject = MC.SalesOrg.Where(x => x.so_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                    catch (Exception ex) { }
        //                }
        //            }
        //            else if (InputValue != null)
        //            {
        //                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_A_P>().ToList()[0];
        //            }
        //        }
        //        catch (Exception ex) { }

        //        #endregion
        //        if (POPUPEntityObject != null)
        //        {
        //            ReportParameters.so_code = POPUPEntityObject.so_code;
        //        }
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

        private void InsertDocType(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M002_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.DocTypeDetails.Where(x => x.doc_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M002_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    ReportParameters.doc_type = POPUPEntityObject.doc_type;
                    ReportParameters.doc_desc = POPUPEntityObject.doc_desc;
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

        private void InsertDocCat(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M001_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.DocCatDetails.Where(x => x.doc_cat.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M001_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    ReportParameters.doc_cat = POPUPEntityObject.doc_cat;
                    ReportParameters.dcat_name = POPUPEntityObject.dcat_name;
                    var DocCatList = (from o in MC.DocTypeDetails where o.doc_cat == ReportParameters.doc_cat select o).ToList();

                    TypeCollection = CollectionViewSource.GetDefaultView(DocCatList);
                    TypeCollection.Filter = new Predicate<object>(FilterType);
                    StrListType = DocCatList.Select(x => x.doc_type).ToList();
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

        private void InsertSalseOrg(object InputValue, bool OverrideValue)
        {

            string so_code = "";
            string sales_org = "";
            ReportParameters.so_code = "";
            foreach (ADM_M001_A_P temp in SalesOrganisationList)
            {
                if (temp.Select == true)
                {
                    so_code = so_code + "," + temp.so_code;
                    sales_org = sales_org + "," + temp.sales_org;
                }
            }
            ReportParameters.so_code = so_code.ToString().TrimStart(new char[] { ',' });
            ReportParameters.sales_org = sales_org.ToString().TrimStart(new char[] { ',' });

        }

        private void InsertSalseGroup(object InputValue, bool OverrideValue)
        {

            string sg_code = "";
            string sg_name = "";
            ReportParameters.sg_code = "";
            foreach (ADM_M001_H_P temp in SalesGroupList)
            {
                if (temp.Select == true)
                {
                    sg_code = sg_code + "," + temp.sg_code;
                    sg_name = sg_name + "," + temp.sg_name;
                }
            }
            ReportParameters.sg_code = sg_code.ToString().TrimStart(new char[] { ',' });
            ReportParameters.sg_name = sg_name.ToString().TrimStart(new char[] { ',' });

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
        //    #region Command Parameter Read Section
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
        //    #endregion

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
                        data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterStringEmp.ToLower()));
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

        private string _filterString_Category;
        public string FilterString_Category
        {
            get { return _filterString_Category; }
            set
            {
                _filterString_Category = value;
                RaisePropertyChanged("FilterString_Category");
                FilterCollectionCategory();
            }
        }
        private void FilterCollectionCategory()
        {
            if (_CategoryCollection != null)
            {
                _CategoryCollection.Refresh();
            }
        }
        public bool FilterCategory(object obj)
        {
            var data = obj as SYS_M001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Category))
                {
                    return (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_filterString_Category.ToLower()) ||
                            (data.dcat_name != null && data.dcat_name.ToString().ToLower().Contains(_filterString_Category.ToLower()))
                        );
                }
                return true;
            }
            return false;
        }

        private string _filterString_Type;
        public string FilterString_Type
        {
            get { return _filterString_Type; }
            set
            {
                _filterString_Type = value;
                RaisePropertyChanged("FilterString_Type");
                FilterCollectionType();
            }
        }
        private void FilterCollectionType()
        {
            if (_TypeCollection != null)
            {
                _TypeCollection.Refresh();
            }
        }
        public bool FilterType(object obj)
        {
            var data = obj as SYS_M002_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Type))
                {
                    return (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_filterString_Category.ToLower()) ||
                            (data.doc_desc != null && data.doc_desc.ToString().ToLower().Contains(_filterString_Category.ToLower()))
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


        private string _filterString_SalesOrg;
        public string FilterString_SalesOrg
        {
            get { return _filterString_SalesOrg; }
            set
            {
                _filterString_SalesOrg = value;
                RaisePropertyChanged("FilterString_SalesOrg");
                FilterCollection_SalesOrg();
            }
        }
        private void FilterCollection_SalesOrg()
        {
            if (_sales_orgCollection != null)
            {
                _sales_orgCollection.Refresh();
            }
        }
        public bool Filter_SalesOrg(object obj)
        {
            var data = obj as ADM_M001_A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SalesOrg))
                {
                    return (data.so_code != null && data.so_code.ToString().ToLower().Contains(_filterString_SalesOrg.ToLower())) ||
                       (data.sales_org != null && data.sales_org.ToString().ToLower().Contains(_filterString_SalesOrg.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_SalesGroup;
        public string FilterString_SalesGroup
        {
            get { return _filterString_SalesGroup; }
            set
            {
                _filterString_SalesGroup = value;
                RaisePropertyChanged("FilterString_SalesGroup");
                FilterCollection_SalesGroup();
            }
        }
        private void FilterCollection_SalesGroup()
        {
            if (_salse_GroupCollection != null)
            {
                _salse_GroupCollection.Refresh();
            }
        }
        public bool Filter_SalesGroup(object obj)
        {
            var data = obj as ADM_M001_H_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SalesGroup))
                {
                    return (data.sg_code != null && data.sg_code.ToString().ToLower().Contains(_filterString_SalesGroup.ToLower())) ||
                       (data.sg_name != null && data.sg_name.ToString().ToLower().Contains(_filterString_SalesGroup.ToLower()));
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
        #endregion

        #region . Command Action .
        protected override void OnSaveAction(InquiryActionResult<MIS_SalesReport3> result)
        {

        }
        protected override void OnCreateAction(InquiryActionResult<MIS_SalesReport3> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<MIS_SalesReport3> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<MIS_SalesReport3> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<MIS_SalesReport3> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<MIS_SalesReport3> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<MIS_SalesReport3> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<MIS_SalesReport3> result)
        {

        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_SalesReport3> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_SalesReport3> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_SalesReport3> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_SalesReport3> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_SalesReport3> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }


}
