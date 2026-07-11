using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.Production;
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
using System.Windows.Data;
using Reflection.ReportingServices;
using Reflection.Presentation.Common;

namespace Reflection.Modules.Production.ViewModels
{
    public class MIS_Quality_VM : WorkspaceViewModel<MIS_QualityEntity>
    {
        #region Variables Declaration

        bool blNew = true;
        WebServiceRepository<List<Rpt_MIS_PDI_Entry>> repository = new WebServiceRepository<List<Rpt_MIS_PDI_Entry>>();
        WebServiceRepository<MultipleContextMIS_Quality> repository_MC = new WebServiceRepository<MultipleContextMIS_Quality>();
        ObjectSerializationService obj = new ObjectSerializationService();
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        MultipleContextMIS_Quality _MC = new MultipleContextMIS_Quality();
        public MultipleContextMIS_Quality MC
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



        private MIS_QualityEntity _ReportParameters;
        public MIS_QualityEntity ReportParameters
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

        private Dictionary<string, object> _DocumentTypeDictionary;
        public Dictionary<string, object> DocumentTypeDictionary
        {
            get { return _DocumentTypeDictionary; }
            set
            {
                if (_DocumentTypeDictionary != value)
                {
                    _DocumentTypeDictionary = value;
                    RaisePropertyChanged("DocumentTypeDictionary");
                }
            }
        }

        private List<Rpt_MIS_PDI_Entry> _dsReport;
        public List<Rpt_MIS_PDI_Entry> dsReport
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

        private ICollectionView _MachineCollection;
        public ICollectionView MachineCollection
        {
            get { return _MachineCollection; }
            set { _MachineCollection = value; RaisePropertyChanged("MachineCollection"); }
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

        #endregion

        #region RelayCommands      
        public RelayCommand CommandReport { get; private set; }
        public RelayCommand CommandExport { get; private set; }
        public RelayCommand<object> cmdCompanyChange { get; private set; }
        public RelayCommand<object> cmdPlantChange { get; private set; }
        public RelayCommand<object> cmdMachine { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region Constructor
        public MIS_Quality_VM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            CursorControl.SetBusyState();
            MC = new MultipleContextMIS_Quality();
            ReportParameters = new MIS_QualityEntity();
            _dsReport = new List<Rpt_MIS_PDI_Entry>();
            ItemsDictionary = new Dictionary<string, string>();
            ItemsDictionary.Add("R001", "Datewise Quality Details");
            ItemsDictionary.Add("R002", "Process Inspection");
            ItemsDictionary.Add("R003", "ILD Report");
            ItemsDictionary.Add("R004", "Magnet Report");
            ItemsDictionary.Add("R005", "Ultrasonic Report");
            ItemsDictionary.Add("R006", "PDI Report");
            ItemsDictionary.Add("R007", "Writting Test Manual");
            ItemsDictionary.Add("R008", "Assorted Report");
            //ItemsDictionary.Add("R009", "PDI Done-Pending Packing Report"); shifted in MM Reports Standard
            //ItemsDictionary.Add("R010", "Process");

            DocumentTypeDictionary = new Dictionary<string, object>();
            //DocumentTypeDictionary.Add("All", "All");
            DocumentTypeDictionary.Add("A", "A");
            DocumentTypeDictionary.Add("B", "B");
            DocumentTypeDictionary.Add("C", "C");
            DocumentTypeDictionary.Add("D", "D");


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
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContextMIS_Quality>(MC, Request, "MIS_Quality_Report", "Production", "LoadAll", 0, "");

                #region Command Initialisation
                cmdCompanyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
                cmdPlantChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
                cmdMachine = new RelayCommand<object>(items => { if (items == null) { return; } InsertMachine(items); });
                CommandReport = new RelayCommand(DisplayReport);
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                #endregion

                ObjComp = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                CompanyCollection = CollectionViewSource.GetDefaultView(ObjComp.ToList());
                CompanyCollection.Filter = new Predicate<object>(FilterCompany);
                StringListCompany = ObjComp.Select(x => x.comp_code).ToList();

                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantCollection = CollectionViewSource.GetDefaultView(ObjPlant.ToList());
                PlantCollection.Filter = new Predicate<object>(FilterPlant);
                StringListPlant = ObjPlant.Select(x => x.location_Id).ToList();

                var LocWiseMachine = (from o in MC.machineDetails
                                      where o.location_Id == ReportParameters.location_Id
                                      select o).ToList();
                MachineCollection = CollectionViewSource.GetDefaultView(LocWiseMachine.ToList());
                MachineCollection.Filter = new Predicate<object>(MachineFilter);
                StringListMachine = MC.machineDetails.Select(x => x.machinecode.ToString()).ToList();


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
            ReportParameters.ts_code = ts_code_vm;

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
                else
                {


                    string RequestParameter = "Report" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.doc_type + "!@" + ReportParameters.comp_code + "!@" + ReportParameters.location_Id + "!@" + ReportParameters.machinecode + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy");
                    dsReport = repository.GetDataWithReturnDomainObject<List<Rpt_MIS_PDI_Entry>>(dsReport, RequestParameter, "MIS_Quality_Report", "Production", "", 0, RequestParameter);

                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];

                    objDataSource[0] = dsReport;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == ReportParameters.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == ReportParameters.location_Id).ToList();
                    objDataSource[2] = Result;

                    objDataSourceName[0] = "dsRpt_MIS_PDI_Entry";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsLocation";

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\MIS\\Production\\" + GetReportFile(ReportParameters.ReportCode), getParametersList(), "");

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
                result.Add("ReportNm", ReportParameters.ReportName);
                result.Add("comp_code", ReportParameters.comp_code);
                result.Add("location_Id", ReportParameters.location_Id);
                result.Add("machinecode", ReportParameters.machinecode);
                result.Add("doc_desc", ReportParameters.doc_type);
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
                returnReportName = "DatewiseQualityReport.rdlc";
            }
            else if (ReportCode == "R002")
            {
                returnReportName = "ProcessInspection.rdlc";
            }
            else if (ReportCode == "R003")
            {
                returnReportName = "TIP_WT_ILD_Report.rdlc";
            }
            else if (ReportCode == "R004")
            {
                returnReportName = "TIP_WT_Magnet.rdlc";
            }
            else if (ReportCode == "R005")
            {
                returnReportName = "TIP_UltrasonicReport.rdlc";
            }
            else if (ReportCode == "R006")
            {
                returnReportName = "TIP_PDIReport.rdlc";
            }
            else if (ReportCode == "R007")
            {
                returnReportName = "TIP_WT_Manual_Report.rdlc";
            }
            else if (ReportCode == "R008")
            {
                returnReportName = "TIP_WT_Assorted.rdlc";
            }
            else if (ReportCode == "R009")
            {
                returnReportName = "PDI_PackingPending.rdlc";
            }

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
            ReportParameters.location_Id = "";
            foreach (ADM_M003 temp in ObjPlant)
            {
                if (temp.Select == true)
                {
                    stringLocation = stringLocation + "," + temp.location_Id;
                }
            }
            ReportParameters.location_Id = stringLocation.ToString().TrimStart(new char[] { ',' });

            var LocWiseMachine = (from o in MC.machineDetails
                                  where o.location_Id == ReportParameters.location_Id
                                  select o).ToList();


            MachineCollection = CollectionViewSource.GetDefaultView(LocWiseMachine.ToList());
            MachineCollection.Filter = new Predicate<object>(MachineFilter);
            MachineCollection.Refresh();

        }
        private void InsertMachine(object InputValue)
        {
            string stringMachineCode = "";
            ReportParameters.machinecode = "";
            foreach (ZADM_M013_P temp in MC.machineDetails)
            {
                if (temp.Select == true)
                {
                    stringMachineCode = stringMachineCode + "," + temp.machinecode;
                }
            }
            ReportParameters.machinecode = stringMachineCode.ToString().TrimStart(new char[] { ',' });
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



        private string _filterStringMachine;
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
        private void FilterCollectionMachine()
        {
            if (_MachineCollection != null)
            {
                _MachineCollection.Refresh();
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

        #region Command Action 
        protected override void OnCreateAction(InquiryActionResult<MIS_QualityEntity> result)
        {

        }

        protected override void OnDiscardAction(InquiryActionResult<MIS_QualityEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<MIS_QualityEntity> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<MIS_QualityEntity> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<MIS_QualityEntity> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<MIS_QualityEntity> result)
        {

        }

        protected override void OnRemoveAction(InquiryActionResult<MIS_QualityEntity> result)
        {

        }

        protected override void OnSaveAction(InquiryActionResult<MIS_QualityEntity> result)
        {

        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_QualityEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_QualityEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_QualityEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_QualityEntity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_QualityEntity> result)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
