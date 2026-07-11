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
using Reflection.BusinessEntity.CustomerRelation;
using Reflection.Presentation.Common;

namespace Reflection.Modules.CustomerRelation.ViewModels
{

    class MIS_Sales_InsuranceVM : WorkspaceViewModel<MIS_InsuranceEntity>
    {

        #region Declaration

        bool blNew = true;
        WebServiceRepository<MultipleContext_MIS_Sales_InsuranceBL> repository_MC = new WebServiceRepository<MultipleContext_MIS_Sales_InsuranceBL>();
        ObjectSerializationService obj = new ObjectSerializationService();
        WebServiceRepository<List<MIS_InsuranceRptEntity>> repository = new WebServiceRepository<List<MIS_InsuranceRptEntity>>();

        MultipleContext_MIS_Sales_InsuranceBL _MC = new MultipleContext_MIS_Sales_InsuranceBL();
        public MultipleContext_MIS_Sales_InsuranceBL MC
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

        private MIS_InsuranceEntity _ReportParameters;
        public MIS_InsuranceEntity ReportParameters
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

        private List<MIS_InsuranceRptEntity> _dsReport;
        public List<MIS_InsuranceRptEntity> dsReport
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
        #endregion

        #region List
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

        #region Dictionary for ComboList
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


        private Dictionary<string, string> _AccountTyDictionary;
        public Dictionary<string, string> AccountTyDictionary
        {
            get { return _AccountTyDictionary; }
            set
            {
                if (_AccountTyDictionary != value)
                {
                    _AccountTyDictionary = value;
                    RaisePropertyChanged("AccountTyDictionary");
                }
            }
        }
        #endregion

        #region ICollection

        private ICollectionView _CompanyCollection;
        public ICollectionView CompanyCollection
        {
            get { return _CompanyCollection; }
            set
            {
                _CompanyCollection = value;
                RaisePropertyChanged("CompanyCollection");
            }
        }
        private ICollectionView _PlantCollection;
        public ICollectionView PlantCollection
        {
            get { return _PlantCollection; }
            set
            {
                _PlantCollection = value;
                RaisePropertyChanged("PlantCollection");
            }
        }

        private ICollectionView _uomCollection;
        public ICollectionView UomCollection
        {
            get { return _uomCollection; }
            set { _uomCollection = value; RaisePropertyChanged("UomCollection"); }
        }


        private ICollectionView _FinCollection;
        public ICollectionView FinCollection
        {
            get { return _FinCollection; }
            set { _FinCollection = value; RaisePropertyChanged("FinCollection"); }
        }

        private ICollectionView _PostCollection;
        public ICollectionView PostCollection
        {
            get { return _PostCollection; }
            set { _PostCollection = value; RaisePropertyChanged("PostCollection"); }
        }
        

        private ICollectionView _TypeCollection;
        public ICollectionView TypeCollection
        {
            get { return _TypeCollection; }
            set { _TypeCollection = value; RaisePropertyChanged("TypeCollection"); }
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
        private List<string> _strListPlant;
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

        private List<string> _stringListUOM;
        public List<string> StringListUOM
        {
            get { return _stringListUOM; }
            set
            {
                if (_stringListUOM != value)
                {
                    _stringListUOM = value;
                }
            }
        }


        //Fin year
        private List<string> _StringListFinYr;
        public List<string> StringListFinYr
        {
            get { return _StringListFinYr; }
            set
            {
                if (_StringListFinYr != value)
                {
                    _StringListFinYr = value;
                }
            }
        }
        //Post Period
        private List<string> _StringListPost;
        public List<string> StringListPost
        {
            get { return _StringListPost; }
            set
            {
                if (_StringListPost != value)
                {
                    _StringListPost = value;
                }
            }
        }

     
        private List<ADM_M030_P> _StrType;
        public List<ADM_M030_P> StrType
        {
            get { return _StrType; }
            set
            {
                if (_StrType != value)
                {
                    _StrType = value;
                    RaisePropertyChanged("StrType");
                }
            }
        }
        #endregion

        #region RelayCommands      
        public RelayCommand<object> cmdCompanyChange { get; private set; }
        public RelayCommand<object> cmdPlantChange { get; private set; }
        public RelayCommand<object> cmdUnitChange { get; private set; }
        public RelayCommand cmdReport { get; private set; }
        public RelayCommand cmdClear { get; private set; }
        public RelayCommand<object> cmdFinYr { get; private set; }
        public RelayCommand<object> cmdPostPeriod { get; private set; }


        #endregion

        #region Constructor
        public MIS_Sales_InsuranceVM()
            : base()
        {
            CursorControl.SetBusyState();
            MC = new MultipleContext_MIS_Sales_InsuranceBL();
            ReportParameters = new MIS_InsuranceEntity();
            _dsReport = new List<MIS_InsuranceRptEntity>();
            ReportItemsDictionary = new Dictionary<string, string>();
          
           //ReportItemsDictionary.Add("R001","Insurance Report");
            ReportItemsDictionary.Add("R002","Insurance Report");

            AccountTyDictionary = new Dictionary<string, string>();
            AccountTyDictionary.Add("A01", "All");
            AccountTyDictionary.Add("A02", "Self");
            AccountTyDictionary.Add("A03", "Trading");

            cmdCompanyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            cmdPlantChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
            cmdUnitChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertUnit(items); });
           
            cmdReport = new RelayCommand(DisplayReport);
            cmdClear = new RelayCommand(ClearData);           
            cmdFinYr = new RelayCommand<object>(items => { if (items == null) { return; } InsertFinYr(items); });
            cmdPostPeriod = new RelayCommand<object>(items => { if (items == null) { return; } InsertPostPeriod(items); });

            LoadInitialData();
            DefaultValues();
        }


        private void InsertParty(object items, bool blNew, object sender)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region User Defined Function
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MIS_Sales_InsuranceBL>(MC, Request, "MIS_Sales_Insurance", "CRM", "LoadAll", 0, "");

                //Loading  Data on Popups.

                UomCollection = CollectionViewSource.GetDefaultView(MC.UnitDetails.ToList());
                UomCollection.Filter = new Predicate<object>(FilterUom);
                StringListUOM = MC.UnitDetails.Select(x => x.unit_code).ToList();

                //Fin year and Posting period
                FinCollection = CollectionViewSource.GetDefaultView(MC.FinYear.ToList());
                FinCollection.Filter = new Predicate<object>(FilterFinYr);
                StringListFinYr = MC.FinYear.Select(x => x.fin_year).ToList();

                PostCollection = CollectionViewSource.GetDefaultView(MC.PostPeriod.ToList());
                PostCollection.Filter = new Predicate<object>(FilterPost);
                StringListPost = MC.PostPeriod.Select(x => x.posting_period).ToList();

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
        private void ClearData()
        {

            try
            {
                ReportParameters = new MIS_InsuranceEntity();
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

        private void DefaultValues()
        {

            ReportParameters.comp_code = AppSessionState.comp_code;
            ReportParameters.location_Id = AppSessionState.location_Id;
            ReportParameters.fin_year = "16-17";
            ReportParameters.posting_period = "1";

            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            ReportParameters.FromDate = lastDayLastMonth.AddDays(0);
            ReportParameters.ToDate = DateTime.Now;
        }
    
        private void InsertCompany(object InputValue)
        {
            try
            {
            string Request = "";
            ADM_M002 POPUPEntityObject = null;
            #region Command Parameter Read Section
           
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

                #endregion

                if (POPUPEntityObject != null)
                {

                    ReportParameters.comp_code = POPUPEntityObject.comp_code;
                    ReportParameters.CompName = POPUPEntityObject.CompName;
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
        private void InsertPlant(object InputValue)
        {
            try
            {
            string Request = "";
            ADM_M003 POPUPEntityObject = null;
            #region Command Parameter Read Section
           
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

                #endregion

                if (POPUPEntityObject != null)
                {

                    ReportParameters.location_Id = POPUPEntityObject.location_Id;
                    ReportParameters.LoctnNm = POPUPEntityObject.LoctnNm;

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
        private void InsertUnit(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitDetails.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    ReportParameters.unit_name = POPUPEntityObject.unit_name;

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
     
        //Fin yr
        private void InsertFinYr(object InputValue)
        {
            try
            {
            string Request = "";
            ACC_M001A_P POPUPEntityObject = null;
            #region Command Parameter Read Section
           
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.FinYear.Where(x => x.fin_year.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M001A_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null)
                {

                    ReportParameters.fin_year = POPUPEntityObject.fin_year;
                    ReportParameters.post_year = POPUPEntityObject.post_year;
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
        //Posting Period
        private void InsertPostPeriod(object InputValue)
        {
            try
            {
            string Request = "";
            ACC_M001A_P POPUPEntityObject = null;
            #region Command Parameter Read Section
          
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PostPeriod.Where(x => x.posting_period.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M001A_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null)
                {

                    ReportParameters.posting_period = POPUPEntityObject.posting_period;
                    ReportParameters.short_desc = POPUPEntityObject.short_desc;
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

        private void DisplayReport()
        {
            CursorControl.SetBusyState();
            try
            {
                //Check if Report not selected then give a Message.
                if (ReportParameters.ReportCode == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Report Type");
                    showMessageService.ShowMessage();
                }

                //Check if Fields are not Selected then assign it to 'All'.
                if (ReportParameters.ReportCode != null)
                {
                    if (ReportParameters.unit_code == null) { ReportParameters.unit_code = "All"; }
                    if (ReportParameters.SalesAccount == null) { ReportParameters.SalesAccount = "All"; }                  

                }

                //Diaplay Selected Report.
                if (ReportParameters.ReportCode != null)
                {
                   
                    string RequestParameter = "Report" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.comp_code + "!@" + ReportParameters.location_Id + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParameters.unit_code  + "!@" + ReportParameters.Duration + "!@" + ReportParameters.Balance+ "!@" + ReportParameters.posting_period + "!@" + ReportParameters.fin_year +"!@" + ReportParameters.SalesAccount;
                    dsReport = repository.GetDataWithReturnDomainObject<List<MIS_InsuranceRptEntity>>(dsReport, RequestParameter, "MIS_Sales_Insurance", "CRM", "", 0, RequestParameter);

                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];
                    objDataSource[0] = dsReport;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == ReportParameters.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == ReportParameters.location_Id).ToList();
                    objDataSource[2] = Result;

                    objDataSourceName[0] = "dsMIS_InsuranceRptEntity";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsLocation";


                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\CRM\\" + GetReportFile(ReportParameters.ReportCode), getParametersList(), "");

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
            //Adding Parameters to display on Reports
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("ReportName", ReportParameters.ReportName);
                result.Add("comp_code", ReportParameters.comp_code);
                result.Add("location_Id", ReportParameters.location_Id);
                result.Add("Duration", ReportParameters.Duration);
                result.Add("Balance", ReportParameters.Balance);

                result.Add("unit_code", ReportParameters.unit_code);
                result.Add("SalesAccount", ReportParameters.SalesAccount);
                result.Add("fin_year", ReportParameters.fin_year);
                result.Add("posting_period", ReportParameters.posting_period);
                result.Add("short_desc", ReportParameters.short_desc);

                result.Add("FromDate", Convert.ToString(ReportParameters.FromDate));
                result.Add("ToDate", Convert.ToString(ReportParameters.ToDate));


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

        //Getting Selected Report File
        private string GetReportFile(string ReportCode)
        {
            string returnReportName = ""; 
            if (ReportCode == "R001")
            { returnReportName = "InsuranceRpt.rdlc"; }
            if (ReportCode == "R002")
            { returnReportName = "InsuranceRptWithoutTax.rdlc"; }
            return returnReportName;


        }

        #endregion

        #region . Filter .

        #region Company Filter
        private string _filterString_Company;
        public string FilterString_Company
        {
            get { return _filterString_Company; }
            set
            {
                _filterString_Company = value;
                RaisePropertyChanged("FilterString_Company");
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

        #region Plant Filter
        private string _filterString_plant;
        public string FilterString_plant
        {
            get { return _filterString_plant; }
            set
            {
                _filterString_plant = value;
                RaisePropertyChanged("FilterString_plant");
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

        #region UOM Filter
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
     
        #region Financial Year Filter
        private string _filterStringFinYr;
        public string FilterStringFinYr
        {
            get { return _filterStringFinYr; }
            set
            {
                _filterStringFinYr = value;
                RaisePropertyChanged("FilterStringFinYr");
                FilterCollectionFinYr();
            }
        }
        private void FilterCollectionFinYr()
        {
            if (_FinCollection != null)
            {
                _FinCollection.Refresh();
            }
        }
        public bool FilterFinYr(object obj)
        {
            var data = obj as ACC_M001A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringFinYr))
                {
                    return (data.post_year.ToString() != null && data.post_year.ToString().ToLower().Contains(_filterStringFinYr.ToLower())) ||
                        (data.fin_year.ToString() != null && data.fin_year.ToString().ToLower().Contains(_filterStringFinYr.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Posting Period Filter
        private string _filterStringPost;
        public string FilterStringPost
        {
            get { return _filterStringPost; }
            set
            {
                _filterStringPost = value;
                RaisePropertyChanged("FilterStringPost");
                FilterCollectionPost();
            }
        }
        private void FilterCollectionPost()
        {
            if (_PostCollection != null)
            {
                _PostCollection.Refresh();
            }
        }
        public bool FilterPost(object obj)
        {
            var data = obj as ACC_M001A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringPost))
                {
                    return (data.short_desc.ToString() != null && data.short_desc.ToString().ToLower().Contains(_filterStringPost.ToLower())) ||
                        (data.posting_period.ToString() != null && data.posting_period.ToString().ToLower().Contains(_filterStringPost.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion
        #endregion

        #region . Command Action .
        protected override void OnSaveAction(InquiryActionResult<MIS_InsuranceEntity> result)
        {

        }
        protected override void OnCreateAction(InquiryActionResult<MIS_InsuranceEntity> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<MIS_InsuranceEntity> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<MIS_InsuranceEntity> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<MIS_InsuranceEntity> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<MIS_InsuranceEntity> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<MIS_InsuranceEntity> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<MIS_InsuranceEntity> result)
        {

        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_InsuranceEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_InsuranceEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_InsuranceEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_InsuranceEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_InsuranceEntity> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
