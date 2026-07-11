using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.CustomerRelation;
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
using Reflection.ReportingServices;
using System.Windows.Data;
using Reflection.Presentation.Common;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class MIS_CRM_Sales7_VM : WorkspaceViewModel<MIS_SalesReport7>
    {


        #region Declaration

        bool blNew = true;
        WebServiceRepository<List<MIS_CRM_SalesEntity7>> repository = new WebServiceRepository<List<MIS_CRM_SalesEntity7>>();
        WebServiceRepository<MultipleContextMISReports7> repository_MC = new WebServiceRepository<MultipleContextMISReports7>();
        ObjectSerializationService obj = new ObjectSerializationService();

        MultipleContextMISReports7 _MC = new MultipleContextMISReports7();
        public MultipleContextMISReports7 MC
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

        private List<MIS_CRM_SalesEntity7> _dsReport;
        public List<MIS_CRM_SalesEntity7> dsReport
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
        #endregion

        #region RelayCommands      
        public RelayCommand CommandReport { get; private set; }
        public RelayCommand CommandExport { get; private set; }
        public RelayCommand<object> cmdPartyChange { get; private set; }
        public RelayCommand<object> cmdItemChange { get; private set; }
        public RelayCommand<object> cmdCompanyChange { get; private set; }
        public RelayCommand<object> cmdPlantChange { get; private set; }
        public RelayCommand<object> CommandSalseOrg { get; private set; }
        public RelayCommand<object> CommandSalseGroup { get; private set; }
        public RelayCommand cmdClear { get; private set; }
        #endregion

        #region List
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

        #region Constructor
        public MIS_CRM_Sales7_VM()
            : base()
        {
            CursorControl.SetBusyState();
            MC = new MultipleContextMISReports7();
            ReportParameters = new MISReportParameter();
            _dsReport = new List<MIS_CRM_SalesEntity7>();
            ItemsDictionary = new Dictionary<string, string>();
            ItemsDictionary.Add("R001", "Sales Report(Summary)");
            ItemsDictionary.Add("R002", "Sales Report(Detail)");
            ItemsDictionary.Add("R003", "Consolidated Sales Report");
            ItemsDictionary.Add("R004", "Sales Invoice Ageing");
            ItemsDictionary.Add("R005", "Sales Invoice Ageing Chart");
            ItemsDictionary.Add("R006", "Sales Invoice Ageing Summury");


            cmdPartyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items, blNew); });
            cmdItemChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
            cmdCompanyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            cmdPlantChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
            CommandSalseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseOrg(items, blNew); });
            CommandSalseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseGroup(items, blNew); });

            CommandReport = new RelayCommand(DisplayReport);
            cmdClear = new RelayCommand(ClearData);
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
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContextMISReports7>(MC, Request, "MIS_CRM_SalesReport7", "CRM", "LoadAll", 0, "");

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
            //ReportParameters.Location_Id = AppSessionState.location_Id;

            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            ReportParameters.FromDate = lastDayLastMonth.AddDays(-30);
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


                ReportParameters = ReportParameters;
                if (ReportParameters.ReportCode != null)
                {

                    string RequestParameter = "Report" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.ItemCode + "!@" + ReportParameters.PartyId + "!@" + ReportParameters.Location_Id + "!@" + ReportParameters.comp_code + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParameters.doc_no + "!@" + ReportParameters.so_code + "!@" + ReportParameters.sg_code + "!@" + ReportParameters.para1;
                    dsReport = repository.GetDataWithReturnDomainObject<List<MIS_CRM_SalesEntity7>>(dsReport, RequestParameter, "MIS_CRM_SalesReport7", "CRM", "", 0, RequestParameter);

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(dsReport, "dsMIS_CRM_SalesEntity7", "\\MIS\\CRM\\" + GetReportFile(ReportParameters.ReportCode), getParametersList());
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
                ADM_M002 obj = ((List<ADM_M002>)AppSessionState.ADM_M002_List).Where(loc => loc.comp_code == ReportParameters.comp_code).ToList()[0];

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
                result.Add("comp_code", obj.CompName);
                result.Add("Location_Id", ReportParameters.Location_Id);
                result.Add("ItemName", ReportParameters.ItemName);
                result.Add("sg_name", ReportParameters.sg_name);
                result.Add("sales_org", ReportParameters.sales_org);

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
            { returnReportName = "SalesDivisionSummary.rdlc"; }
            else if (ReportCode == "R002")
            { returnReportName = "SalesDivisionDetail.rdlc"; }
            else if (ReportCode == "R003")
            { returnReportName = "ConsolidatedSalesReport.rdlc"; }
            else if (ReportCode == "R004")
            { returnReportName = "SI_Aging.rdlc"; }
            else if (ReportCode == "R005")
            { returnReportName = "SI_Aging_Chart.rdlc"; }
            else if (ReportCode == "R006")
            { returnReportName = "SI_Aging_Summary.rdlc"; }

            return returnReportName;
        }

        private void InsertParty(object InputValue, bool OverrideValue)
        {
            string Request = "";
            ADM_M028_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.partyDetails.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                ReportParameters.PartyId = POPUPEntityObject.PartyId;
                ReportParameters.PartyNm = POPUPEntityObject.PartyNm;
            }



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
        private void ClearData()
        {
            ReportParameters = new MISReportParameter();
            DefaultValues();
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

        #endregion

        #region . Command Action .
        protected override void OnCreateAction(InquiryActionResult<MIS_SalesReport7> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<MIS_SalesReport7> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<MIS_SalesReport7> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<MIS_SalesReport7> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<MIS_SalesReport7> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<MIS_SalesReport7> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<MIS_SalesReport7> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnSaveAction(InquiryActionResult<MIS_SalesReport7> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_SalesReport7> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_SalesReport7> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_SalesReport7> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_SalesReport7> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_SalesReport7> result)
        {
            throw new NotImplementedException();
        }
        #endregion

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

            private string _sg_code;
            public string sg_code
            {
                get
                {
                    return _sg_code;
                }

                set
                {
                    _sg_code = value; RaisePropertyChanged("sg_code");
                }
            }

            private string _sales_org;
            public string sales_org
            {
                get
                {
                    return _sales_org;
                }

                set
                {
                    _sales_org = value; RaisePropertyChanged("sales_org");
                }
            }

            private string _sg_name;
            public string sg_name
            {
                get
                {
                    return _sg_name;
                }

                set
                {
                    _sg_name = value; RaisePropertyChanged("sg_name");
                }
            }

            public string _so_code;
            public string so_code
            {
                get
                {
                    return _so_code;
                }

                set
                {
                    _so_code = value; RaisePropertyChanged("so_code");
                }
            }


        }

    }
}
