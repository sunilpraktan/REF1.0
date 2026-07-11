using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.Finance;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.ReportingServices;
using System.Windows.Data;
using System.Collections;
using System.Collections.ObjectModel;
using Reflection.Presentation.Common;

namespace Reflection.Modules.Finance.ViewModels
{
    public class MIS_Finance4_VM : WorkspaceViewModel<MIS_Finance4Entity>
    {
        #region Variables Declaration

        bool blNew = true;
        WebServiceRepository<List<RptLedgerView>> repository = new WebServiceRepository<List<RptLedgerView>>();
        WebServiceRepository<MultipleContextMIS_Finance4> repository_MC = new WebServiceRepository<MultipleContextMIS_Finance4>();
        ObjectSerializationService obj = new ObjectSerializationService();

        MultipleContextMIS_Finance4 _MC = new MultipleContextMIS_Finance4();
        public MultipleContextMIS_Finance4 MC
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

        MultipleContextMIS_Finance4 _MCTemp = new MultipleContextMIS_Finance4();
        public MultipleContextMIS_Finance4 MCTemp
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

        private MIS_Finance4Entity _ReportParameters;
        public MIS_Finance4Entity ReportParameters
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



        private List<RptLedgerView> _dsReport;
        public List<RptLedgerView> dsReport
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

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set
            {
                _dataGridCollection = value;
                RaisePropertyChanged("DataGridCollection");
            }
        }

        private ObservableCollection<RptLedgerView> _DetailEntity;
        public ObservableCollection<RptLedgerView> DetailEntity
        {
            get { return _DetailEntity; }
            set
            {
                if (_DetailEntity != value)
                {
                    _DetailEntity = value; RaisePropertyChanged("DetailEntity");
                }
            }
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

        private List<SYS_M014_P> _strListDocCat;
        public List<SYS_M014_P> StrListDocCat
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


        #endregion

        #region RelayCommands      
        public RelayCommand CommandReport { get; private set; }
        public RelayCommand CommandExport { get; private set; }
        public RelayCommand<object> cmdCompanyChange { get; private set; }
        public RelayCommand<object> cmdPlantChange { get; private set; }
        public RelayCommand LoadCommand { get; private set; }
        public RelayCommand<object> cmdExportGrid { get; private set; }

        #endregion

        #region Constructor
        public MIS_Finance4_VM()
            : base()
        {
            CursorControl.SetBusyState();
            MC = new MultipleContextMIS_Finance4();
            ReportParameters = new MIS_Finance4Entity();
            _dsReport = new List<RptLedgerView>();
            ReportItemsDictionary = new Dictionary<string, string>();

            //ReportItemsDictionary.Add("R001", "Ledger Detail Report");

            cmdCompanyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            cmdPlantChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
            CommandReport = new RelayCommand(DisplayReport);
            LoadCommand = new RelayCommand(DisplayLedgerDetails);
            cmdExportGrid = new RelayCommand<object>(items => { if (items == null) { return; } ExportDocument(items); });

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
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContextMIS_Finance4>(MC, Request, "MIS_Finance4", "Finance", "LoadAll", 0, "");

                var DocCatList = (from o in MC.DocCatDetails
                                  where o.doc_cat != null
                                  select o).ToList();
                _strListDocCat = DocCatList;
                DocCatDictionary = _strListDocCat.ToDictionary(X => X.doc_cat.ToString(), X => (object)X.dcat_name);

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
            ReportParameters.doc_no = "";
            ReportParameters.location_Id = AppSessionState.location_Id;


            DateTime now = DateTime.Now;
            DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
            ReportParameters.FromDate = lastDayLastMonth.AddDays(0);
            ReportParameters.ToDate = DateTime.Now;
        }
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            
        }

        private void DisplayLedgerDetails()
        {
            try
            {

                string RequestParameter = "Load" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.doc_cat + "!@" + ReportParameters.location_Id + "!@" + AppSessionState.comp_code + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParameters.doc_no;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContextMIS_Finance4> (MC, RequestParameter, "MIS_Finance4", "Finance", "", 0,"");

                if (MC.LedgerViewList.Count >= 0)
                {
                    DataGridCollection = CollectionViewSource.GetDefaultView(MC.LedgerViewList);
                    DataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("No Data Available", this.Title);
                    showMessageService.ShowMessage();
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

        private void ExportDocument(object InputValue)
        {
            try
            {

                // This is for List Collection
                dsReport = MC.LedgerViewList;

                ExportToExcel<RptLedgerView, List<RptLedgerView>> exportOC = new ExportToExcel<RptLedgerView, List<RptLedgerView>>();
                exportOC.ListCollectionData = dsReport;
                exportOC.GenerateReport();

                // This is for List ObservarableCollection
                //ExportToExcel<ACC_T002_Flip, List<ACC_T002_Flip>> exportList = new ExportToExcel<ACC_T002_Flip, List<ACC_T002_Flip>>();
                //exportList.ListCollectionData = FlipGridData;
                //exportList.GenerateReport();
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
                      
                    if (ReportParameters.doc_cat == null) { ReportParameters.doc_cat = "All"; }
                    if (ReportParameters.dcat_name == null) { ReportParameters.dcat_name = "All"; }


                    string RequestParameter = "Load" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.doc_cat + "!@" + ReportParameters.location_Id + "!@" + AppSessionState.comp_code + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy") + "!@" + ReportParameters.doc_no;
                    dsReport = repository.GetDataWithReturnDomainObject<List<RptLedgerView>>(dsReport, RequestParameter, "MIS_Finance4", "Finance", "", 0, RequestParameter);

                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];

                    objDataSource[0] = dsReport;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == ReportParameters.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == ReportParameters.location_Id).ToList();
                    objDataSource[2] = Result;

                    objDataSourceName[0] = "dsLedgerViewList";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsLocation";

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\Finance\\" + GetReportFile(ReportParameters.ReportCode), getParametersList(), "");
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
                result.Add("doc_no", ReportParameters.doc_no);
                result.Add("doc_cat", ReportParameters.doc_cat);
                result.Add("dcat_name", ReportParameters.dcat_name);
                result.Add("ReportNm", ReportParameters.ReportName);
                result.Add("comp_code", ReportParameters.comp_code);
                result.Add("location_Id", ReportParameters.location_Id);
                
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
            //if (ReportCode == "R001")
            //{
            //    returnReportName = "SdReport.rdlc";
            //}
            
            return returnReportName;
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
       
        
        #endregion

       

        #region Filter

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


        private string _filterString_FlipGrid;
        public string FilterString_FlipGrid
        {
            get { return _filterString_FlipGrid; }
            set
            {
                _filterString_FlipGrid = value;
                RaisePropertyChanged("FilterString_FlipGrid");
                FilterCollection_FlipGrid();
            }
        }
        private void FilterCollection_FlipGrid()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as RptLedgerView;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_FlipGrid))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.gl_code != null && data.gl_code.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.gl_name != null && data.gl_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.doc_curr_amt != null && data.doc_curr_amt.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.loc_curr_amt != null && data.loc_curr_amt.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.dc_ind != null && data.dc_ind.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));


                }
                return true;
            }
            return false;
        }
        #endregion

        #region  Command Action 
        protected override void OnCreateAction(InquiryActionResult<MIS_Finance4Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<MIS_Finance4Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<MIS_Finance4Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<MIS_Finance4Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<MIS_Finance4Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<MIS_Finance4Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<MIS_Finance4Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnSaveAction(InquiryActionResult<MIS_Finance4Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_Finance4Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_Finance4Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_Finance4Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_Finance4Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_Finance4Entity> result)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
