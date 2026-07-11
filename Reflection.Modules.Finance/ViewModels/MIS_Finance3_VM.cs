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
using Reflection.ReportingServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Collections;
using Reflection.Presentation.Controls;
using System.Windows;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Common;

namespace Reflection.Modules.Finance.ViewModels
{
    public class MIS_Finance3_VM : WorkspaceViewModel<MIS_Finance3Entity>
    {
        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(MIS_Finance3_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _ASDefault { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault
        {
            get { return _ASDefault; }
            set
            {
                if (_ASDefault != value)
                {
                    _ASDefault = value; RaisePropertyChanged("ASDefault");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASParty
        {
            get { return _ASParty; }
            set
            {
                if (_ASParty != value)
                {
                    _ASParty = value; RaisePropertyChanged("ASParty");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASGLCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGLCode
        {
            get { return _ASGLCode; }
            set
            {
                if (_ASGLCode != value)
                {
                    _ASGLCode = value; RaisePropertyChanged("ASGLCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASVendor { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASVendor
        {
            get { return _ASVendor; }
            set
            {
                if (_ASVendor != value)
                {
                    _ASVendor = value; RaisePropertyChanged("ASVendor");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASJEType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASJEType
        {
            get { return _ASJEType; }
            set
            {
                if (_ASJEType != value)
                {
                    _ASJEType = value; RaisePropertyChanged("ASJEType");
                }
            }
        }

        #endregion

        #region Variables Declaration

        bool blNew = true;
        WebServiceRepository<List<ACC_T006_A>> repository = new WebServiceRepository<List<ACC_T006_A>>();
        WebServiceRepository<MultipleContextMIS_Finance3> repository_MC = new WebServiceRepository<MultipleContextMIS_Finance3>();
        ObjectSerializationService obj = new ObjectSerializationService();

        MultipleContextMIS_Finance3 _MC = new MultipleContextMIS_Finance3();
        public MultipleContextMIS_Finance3 MC
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

        private MIS_Finance3Entity _ReportParameters;
        public MIS_Finance3Entity ReportParameters
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

        List<VendorPopup> vendors = new List<VendorPopup>();

        private List<ACC_T006_A> _dsReport;
        public List<ACC_T006_A> dsReport
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

        
        #endregion

        #region RelayCommands      
        public GalaSoft.MvvmLight.Command.RelayCommand CommandReport { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CommandExport { get; private set; }
        public RelayCommand<object> cmdCompanyChange { get; private set; }
        public RelayCommand<object> cmdPlantChange { get; private set; }
        public RelayCommand<object> cmdInsertJEType { get; private set; }
        public RelayCommand<object> cmdAddVendors { get; private set; }

        #endregion

        #region Constructor
        public MIS_Finance3_VM()
            : base()
        {
            CursorControl.SetBusyState();
            MC = new MultipleContextMIS_Finance3();
            ReportParameters = new MIS_Finance3Entity();
            _dsReport = new List<ACC_T006_A>();
            ReportItemsDictionary = new Dictionary<string, string>();

            ReportItemsDictionary.Add("R001", "Ledger Detail Report");
            
            cmdCompanyChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            cmdPlantChange = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
            cmdAddVendors = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertVendors(cmdPara); });
            cmdInsertJEType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertJEType(cmdPara); });
            CommandReport = new GalaSoft.MvvmLight.Command.RelayCommand(DisplayReport);

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
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContextMIS_Finance3>(MC, Request, "MIS_Finance3", "Finance", "LoadAll", 0, "");

                
                ObjComp = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                CompanyCollection = CollectionViewSource.GetDefaultView(ObjComp.ToList());
                CompanyCollection.Filter = new Predicate<object>(FilterCompany);
                StringListCompany = ObjComp.Select(x => x.comp_code).ToList();

                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantCollection = CollectionViewSource.GetDefaultView(ObjPlant.ToList());
                PlantCollection.Filter = new Predicate<object>(FilterPlant);
                StringListPlant = ObjPlant.Select(x => x.location_Id).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ACC_M022)x).JE_desc);
                TheFilter = (o, prefix) => ((ACC_M022)o).JE_type.ToLower().Contains(prefix) || ((ACC_M022)o).JE_desc.ToLower().ToString().Contains(prefix);
                ASJEType = new AutoSuggestTextViewModel<dynamic>(MC.JEType, TheFilter, SuggestedValue, "JE_desc", true);
                ASJEType.AutoSuggestVM.IsEmptyValueAllowed = true;
                               
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
                if (ReportParameters.ReportCode != null)
                {
                    if (ReportParameters.JE_type == null) { ReportParameters.JE_type = "All"; }
                    if (ReportParameters.JE_desc == null) { ReportParameters.JE_desc = "All"; }
                    if (ReportParameters.PartyId == null) { ReportParameters.PartyId = "All"; }
                    if (ReportParameters.PartyNm == null) { ReportParameters.PartyNm = "All"; }
                    if (ReportParameters.vendor_code == null) { ReportParameters.vendor_code = "All"; }

                }

                if (ReportParameters.ReportCode != null)
                {
                    string RequestParameter = "Report" + "!@" + ReportParameters.ReportCode + "!@" + ReportParameters.JE_type + "!@" + ReportParameters.location_Id + "!@" + AppSessionState.comp_code + "!@" + Convert.ToDateTime(ReportParameters.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ReportParameters.ToDate).ToString("MM/dd/yyyy")+ "!@" + ReportParameters.vendor_code + "!@" + ReportParameters.JE_desc;
                    dsReport = repository.GetDataWithReturnDomainObject<List<ACC_T006_A>>(dsReport, RequestParameter, "MIS_Finance3", "Finance", "", 0, RequestParameter);

                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];

                    objDataSource[0] = dsReport;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == ReportParameters.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == ReportParameters.location_Id).ToList();
                    objDataSource[2] = Result;

                    objDataSourceName[0] = "dsMIS_FinanceReportsEntity";
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
            if (ReportCode == "R001")
            {
                returnReportName = "LedgerDetailReport.rdlc";
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

        private void InsertVendors(object InputValue)
        {
            try
            {
                string Request = "";
                VendorPopup POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = vendors.Where(x => x.vendor_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<VendorPopup>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<VendorPopup>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    ReportParameters.vendor_code = POPUPEntityObject.vendor_code;

                    if (ReportParameters.JE_type == "JE100001")
                    {
                        vendors = (from o in MC.Vendors where o.JE_type == "ItemCode" select o).ToList();
                        ReportParameters.PartyId = POPUPEntityObject.vendor_code;
                        ReportParameters.PartyNm = POPUPEntityObject.vendor_name;
                    }
                    else if (ReportParameters.JE_type == "JE100002")
                    {
                        vendors = (from o in MC.Vendors where o.JE_type == "PartyId" select o).ToList();
                        ReportParameters.PartyId = POPUPEntityObject.vendor_code;
                        ReportParameters.PartyNm = POPUPEntityObject.vendor_name;
                    }
                    else if (ReportParameters.JE_type == "JE100003")
                    {
                        vendors = (from o in MC.Vendors where o.JE_type == "EmpId" select o).ToList();
                        ReportParameters.PartyId = POPUPEntityObject.vendor_code;
                        ReportParameters.PartyNm = POPUPEntityObject.vendor_name;
                    }
                    else if (ReportParameters.JE_type == "JE100004")
                    {
                        vendors = (from o in MC.Vendors where o.JE_type == "gl_code" select o).ToList();
                        ReportParameters.gl_code = POPUPEntityObject.vendor_code;
                    }
                }
                var msg = new NotificationMessage("MIS_Finance3_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
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

        private void InsertJEType(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M022 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.JEType.Where(x => x.JE_desc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M022>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M022>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    ReportParameters.JE_desc = POPUPEntityObject.JE_desc;
                    ReportParameters.JE_type = POPUPEntityObject.JE_type;

                    vendors = new List<VendorPopup>();
                    ASVendor = new AutoSuggestTextViewModel<dynamic>(vendors, TheFilter, SuggestedValue, "vendor_code", true);

                    if (ReportParameters.JE_type == "JE100001")
                    {
                        vendors = (from o in MC.Vendors where o.JE_type == "ItemCode" select o).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((VendorPopup)x).vendor_code);
                        TheFilter = (o, prefix) => ((VendorPopup)o).vendor_name.ToLower().Contains(prefix) || ((VendorPopup)o).vendor_code.ToLower().Contains(prefix);
                        ASVendor = new AutoSuggestTextViewModel<dynamic>(vendors, TheFilter, SuggestedValue, "vendor_code", true);
                        ASVendor.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASVendor.AutoSuggestVM.SuggestionPreview = null;
                    }
                    else if (ReportParameters.JE_type == "JE100002")
                    {
                        vendors = (from o in MC.Vendors where o.JE_type == "PartyId" select o).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((VendorPopup)x).vendor_code);
                        TheFilter = (o, prefix) => ((VendorPopup)o).vendor_name.ToLower().Contains(prefix) || ((VendorPopup)o).vendor_code.ToLower().Contains(prefix);
                        ASVendor = new AutoSuggestTextViewModel<dynamic>(vendors, TheFilter, SuggestedValue, "vendor_code", true);
                        ASVendor.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASVendor.AutoSuggestVM.SuggestionPreview = null;
                    }
                    else if (ReportParameters.JE_type == "JE100003")
                    {
                        vendors = (from o in MC.Vendors where o.JE_type == "EmpId" select o).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((VendorPopup)x).vendor_code);
                        TheFilter = (o, prefix) => ((VendorPopup)o).vendor_name.ToLower().Contains(prefix) || ((VendorPopup)o).vendor_code.ToLower().Contains(prefix);
                        ASVendor = new AutoSuggestTextViewModel<dynamic>(vendors, TheFilter, SuggestedValue, "vendor_code", true);
                        ASVendor.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASVendor.AutoSuggestVM.SuggestionPreview = null;
                    }
                    else if (ReportParameters.JE_type == "JE100004")
                    {
                        vendors = (from o in MC.Vendors where o.JE_type == "gl_code" select o).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((VendorPopup)x).vendor_code);
                        TheFilter = (o, prefix) => ((VendorPopup)o).vendor_name.ToLower().Contains(prefix) || ((VendorPopup)o).vendor_code.ToLower().Contains(prefix);
                        ASVendor = new AutoSuggestTextViewModel<dynamic>(vendors, TheFilter, SuggestedValue, "vendor_code",true);
                        ASVendor.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASVendor.AutoSuggestVM.SuggestionPreview = null;
                    }
                    var msg = new NotificationMessage("MIS_Finance3_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);
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


        #endregion

        #region  Command Action 
        protected override void OnCreateAction(InquiryActionResult<MIS_Finance3Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDiscardAction(InquiryActionResult<MIS_Finance3Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<MIS_Finance3Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<MIS_Finance3Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<MIS_Finance3Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<MIS_Finance3Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnRemoveAction(InquiryActionResult<MIS_Finance3Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnSaveAction(InquiryActionResult<MIS_Finance3Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<MIS_Finance3Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MIS_Finance3Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MIS_Finance3Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MIS_Finance3Entity> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MIS_Finance3Entity> result)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
