using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using Reflection.BusinessEntity.CustomerRelation;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class TSK_T001_C_VM : WorkspaceViewModel<TSK_T001_C>
    {
        #region Variable Declaration
        bool isNewRecord = true;
        string subject;
        string msg_body;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        WebServiceRepository<TSK_T001_C> repository = new WebServiceRepository<TSK_T001_C>();
        WebServiceRepository<List<MIS_CRM_SalesEntity2>> repository_MCRpt = new WebServiceRepository<List<MIS_CRM_SalesEntity2>>();
        WebServiceRepository<MultipleContext_TSK_T001_C> repository_MC = new WebServiceRepository<MultipleContext_TSK_T001_C>();
        WebServiceRepository<MultipleContext_TSK_T001_C> repository_MCTemp = new WebServiceRepository<MultipleContext_TSK_T001_C>();
        ObjectSerializationService obj = new ObjectSerializationService();
        private MultipleContext_TSK_T001_C _MC = new MultipleContext_TSK_T001_C();
        public MultipleContext_TSK_T001_C MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value; RaisePropertyChanged("MC");
                }
            }
        }

        private MultipleContext_TSK_T001_C _MCTemp = new MultipleContext_TSK_T001_C();
        public MultipleContext_TSK_T001_C MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value; RaisePropertyChanged("MCTemp");
                }
            }
        }

        private TSK_T001_C _MasterEntity;
        public TSK_T001_C MasterEntity
        {
            get
            {
                return _MasterEntity;
            }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged(nameof(MasterEntity));
                    value.BeginEdit();
                }
            }
        }
        private  string _IsCheck;
        public string IsCheck
        {
            get
            {
                return _IsCheck;
            }
            set
            {
                _IsCheck = value;
                 
                
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
        private List<TSK_T001_C_BackFlip> _FlipGridData;
        // Flip DataGrid Data Source
        public List<TSK_T001_C_BackFlip> FlipGridData
        {
            get { return _FlipGridData; }
            set
            {
                if (_FlipGridData != value)
                {
                    _FlipGridData = value;
                    RaisePropertyChanged("FlipGridData");
                }
            }
        }
        private Nullable<System.DateTime> _FrmDate;
        public Nullable<System.DateTime> FrmDate
        {
            get { return _FrmDate; }
            set
            {
                _FrmDate = value;
                RaisePropertyChanged("FrmDate");
            }
        }
        private Nullable<System.DateTime> _ToDate;
        public Nullable<System.DateTime> ToDate
        {
            get { return _ToDate; }
            set
            {
                _ToDate = value;
                RaisePropertyChanged("ToDate");
            }
        }

        private Nullable<System.DateTime> _FromDate;
        public Nullable<System.DateTime> FromDate
        {
            get { return _FromDate; }
            set
            {
                _FromDate = value;
                RaisePropertyChanged("FromDate");
            }
        }
        private Nullable<System.DateTime> _TooDate;
        public Nullable<System.DateTime> TooDate
        {
            get { return _TooDate; }
            set
            {
                _TooDate = value;
                RaisePropertyChanged("TooDate");
            }
        }
        private List<NotificationData> _NotificationDataCollection;
        public List<NotificationData> NotificationDataCollection
        {
            get { return _NotificationDataCollection; }
            set
            {
                if (_NotificationDataCollection != value)
                {
                    _NotificationDataCollection = value;
                    RaisePropertyChanged("NotificationDataCollection");
                }
            }
        }
        public List<ADM_M003> _locationList;
        public List<ADM_M003> LocationList
        {
            get
            {
                return _locationList;
            }
            set
            {
                _locationList = value;
                RaisePropertyChanged("LocationList");
            }
        }
        #endregion
        #region ICollection for Popup Control

        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }

        private ICollectionView _partyCollection;
        public ICollectionView PartyCollection
        {
            get { return _partyCollection; }
            set { _partyCollection = value; RaisePropertyChanged("PartyCollection"); }
        }

        private ICollectionView _employeeCollection;
        public ICollectionView employeeCollection
        {
            get { return _employeeCollection; }
            set { _employeeCollection = value; RaisePropertyChanged("employeeCollection"); }
        }

        private ICollectionView _UnvisitedCollection;
        public ICollectionView UnvisitedCollection
        {
            get { return _UnvisitedCollection; }
            set { _UnvisitedCollection = value; RaisePropertyChanged("UnvisitedCollection"); }
        }
        private ICollectionView _salesCollection;
        public ICollectionView salesCollection
        {
            get { return _salesCollection; }
            set { _salesCollection = value; RaisePropertyChanged("salesCollection"); }
        }
        private ICollectionView _parentCollection;
        public ICollectionView ParentCollection
        {
            get { return _parentCollection; }
            set { _parentCollection = value; RaisePropertyChanged("ParentCollection"); }
        }
        private ICollectionView _LocationCollection;
        public ICollectionView LocationCollection
        {
            get { return _LocationCollection; }
            set { _LocationCollection = value; RaisePropertyChanged("LocationCollection"); }
        }
        private List<COM_T003> _AttachmentCollection;
        public List<COM_T003> AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set
            {
                if (_AttachmentCollection != value)
                {
                    _AttachmentCollection = value;
                    RaisePropertyChanged("AttachmentCollection");
                }
            }
        }
        private ICollectionView _dgLocationCollection;
        public ICollectionView dgLocationCollection
        {
            get { return _dgLocationCollection; }
            set { _dgLocationCollection = value; RaisePropertyChanged("dgLocationCollection"); }
        }

        private int _selectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _selectedTabControlIndex; }
            set
            {
                if (_selectedTabControlIndex != value)
                {
                    _selectedTabControlIndex = value;
                    RaisePropertyChanged("SelectedTabControlIndex");
                }
            }
        }

        #endregion
        #region StringList Variables
        private List<string> _srtListParty;
        public List<string> StringListParty
        {
            get { return _srtListParty; }
            set
            {
                if (_srtListParty != value)
                {
                    _srtListParty = value;
                }
            }
        }
        private List<string> _StringListdgLocationID;
        public List<string> StringListdgLocationID
        {
            get { return _StringListdgLocationID; }
            set
            {
                if (_StringListdgLocationID != value)
                {
                    _StringListdgLocationID = value;
                }
            }
        }
        private List<string> _StringListLocation;
        public List<string> StringListLocation
        {
            get { return _StringListLocation; }
            set
            {
                if (_StringListLocation != value)
                {
                    _StringListLocation = value;
                }
            }
        }
        private List<string> _strListemployee;
        public List<string> StringListemployee
        {
            get { return _strListemployee; }
            set
            {
                if (_strListemployee != value)
                {
                    _strListemployee = value;
                }
            }
        }

        private List<string> _strListSales;
        public List<string> StringListSales
        {
            get { return _strListSales; }
            set
            {
                if (_strListSales != value)
                {
                    _strListSales = value;
                }
            }
        }

        private List<string> _strListUnvisited;
        public List<string> StrListUnvisited
        {
            get { return _strListUnvisited; }
            set
            {
                if (_strListUnvisited != value)
                {
                    _strListUnvisited = value;
                }
            }
        }
        private List<string> _stringListparentactivity;
        public List<string> StringListparentactivity
        {
            get { return _stringListparentactivity; }
            set
            {
                if (_stringListparentactivity != value)
                {
                    _stringListparentactivity = value;
                }
            }
        }
        #endregion
        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<Boolean> CheckedCustomerCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> cmddgLocation { get; private set; }
        public RelayCommand<object> cmdAssignParty { get; private set; }
        public RelayCommand<object> CommandParty { get; private set; }
        public RelayCommand<object> CommandEmployee { get; private set; }
        public RelayCommand<object> CommandSales { get; private set; }
        public RelayCommand<object> CommandPactivity { get; private set; }
        public RelayCommand<object> cmdUnvisited { get; private set; }
        public RelayCommand<object> Commandtime { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> CommandLocation { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        #endregion
        #region Constructor
        /// <summary>
        /// Constructor for ViewModel
        /// </summary>
        /// <param name="NA"></param>
        public TSK_T001_C_VM() : base()
        {
            MasterEntity = new TSK_T001_C();
            ReportParameters = new MISReportParameter();
            _dsReport2 = new List<MIS_CRM_SalesEntity2>();
            FlipGridData = new List<TSK_T001_C_BackFlip>();
            DateTime today = DateTime.Today;
            DateTime TenDaysBefore = today.AddDays(-10);
            FrmDate = TenDaysBefore;
            ToDate = System.DateTime.Now;
            FromDate = System.DateTime.Now;
            TooDate = System.DateTime.Now;
            MC = new MultipleContext_TSK_T001_C();
            MCTemp = new MultipleContext_TSK_T001_C();
            MasterEntity.ValidateAsync().Wait();
            TSK_T001_C.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            NotificationDataCollection = new List<NotificationData>();
            LoadInitialData();
        }
        public TSK_T001_C_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new TSK_T001_C();
            ReportParameters = new MISReportParameter();
            _dsReport2 = new List<MIS_CRM_SalesEntity2>();
            FlipGridData = new List<TSK_T001_C_BackFlip>();
            DateTime today = DateTime.Today;
            DateTime TenDaysBefore = today.AddDays(-10);
            FrmDate = TenDaysBefore;
            ToDate = System.DateTime.Now;
            FromDate = System.DateTime.Now;
            TooDate = System.DateTime.Now;
            MC = new MultipleContext_TSK_T001_C();
            MCTemp = new MultipleContext_TSK_T001_C();
            MasterEntity.ValidateAsync().Wait();
            TSK_T001_C.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            NotificationDataCollection = new List<NotificationData>();
            LoadInitialData();
        }
        public TSK_T001_C_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new TSK_T001_C();
            ReportParameters = new MISReportParameter();
            _dsReport2 = new List<MIS_CRM_SalesEntity2>();
            FlipGridData = new List<TSK_T001_C_BackFlip>();
            DateTime today = DateTime.Today;
            DateTime TenDaysBefore = today.AddDays(-10);
            FrmDate = TenDaysBefore;
            ToDate = System.DateTime.Now;
            FromDate = System.DateTime.Now;
            TooDate = System.DateTime.Now;
            MC = new MultipleContext_TSK_T001_C();
            MCTemp = new MultipleContext_TSK_T001_C();
            MasterEntity.ValidateAsync().Wait();
            TSK_T001_C.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            NotificationDataCollection = new List<NotificationData>();
            LoadInitialData();
        }
        #endregion
        #region Relay Command Actions ·
        private void Insertdgplant(object InputValue)
        {
            try
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
                            { POPUPEntityObject = LocationList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.location_Id = POPUPEntityObject.location_Id;
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
        private void InsertParty(object InputValue, bool OverrideValue)
        {
            try {
                string Request = "";
                string RequestParameterData = "";
                ADM_M028_P POPUPEntityObject = null;
                //IEnumerable<ADM_M028_PopUp> BEType = new List<ADM_M028_PopUp>(); Garbej
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
                            { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //&& MasterEntity.PartyId != POPUPEntityObject.PartyId) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.PartyId = POPUPEntityObject.PartyId;
                    MasterEntity.party_name = POPUPEntityObject.PartyNm;

                     Request = "LoadPartyDetail" + "!@" + MasterEntity.PartyId;
                     MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_TSK_T001_C>(MCTemp, Request, "CRMActivity", "CRM", "LoadPartDetail", 0, "");
                    if (MCTemp.ContactInfo.Count >0)
                    {
                        LocationCollection = CollectionViewSource.GetDefaultView(MCTemp.ContactInfo);
                        LocationCollection.Filter = new Predicate<object>(Filter_Location);
                        StringListLocation = MCTemp.ContactInfo.Select(x => x.PersonName).ToList();

                        MasterEntity.contact_person = "";
                        MasterEntity.person_number = "";
                        MasterEntity.EmailId = "";
                        MasterEntity.place = "";
                        MasterEntity.address = "";
                        MasterEntity.architect_grade = "";

                        MasterEntity.contact_person = MCTemp.ContactInfo[0].PersonName;
                        MasterEntity.person_number = MCTemp.ContactInfo[0].PersnMobNo;
                        MasterEntity.EmailId = MCTemp.ContactInfo[0].PersnEmailId;
                        MasterEntity.place = MCTemp.ContactInfo[0].Location;
                        MasterEntity.address = MCTemp.ContactInfo[0].Add1;
                        MasterEntity.architect_grade = MCTemp.ContactInfo[0].group1;
                    }
                    else
                    {
                        MasterEntity.contact_person = "";
                        MasterEntity.person_number = "";
                        MasterEntity.EmailId = "";
                        MasterEntity.place = "";
                        MasterEntity.address = "";
                        MasterEntity.architect_grade = "";
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
        private void InsertEmployee(object InputValue)
        {
            try {

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
                            { POPUPEntityObject = MC.EmployeeMaster.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.owner = POPUPEntityObject.EmpId;
                    MasterEntity.EmpName = POPUPEntityObject.EmpName;

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
        private void InsertUnvisited(object InputValue)
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
                            { POPUPEntityObject = MC.UnvisitedList.Where(x => x.EmpName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.para1 = POPUPEntityObject.EmpName;
                  
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
        private void checkcust(bool select)
        {
            try
            {
                if (select == true)
                {
                    var refdoctemp = (from o in MC.PartyMaster where o.EmpId == AppSessionState.EmpId select o).ToList();
                    PartyCollection = CollectionViewSource.GetDefaultView(refdoctemp);
                    PartyCollection.Filter = new Predicate<object>(Filter_Party);
                    StringListParty = MC.PartyMaster.Select(x => x.PartyId).ToList();
                }
                else if(select==false)
                {
                    PartyCollection = CollectionViewSource.GetDefaultView(MC.PartyMaster);
                    PartyCollection.Filter = new Predicate<object>(Filter_Party);
                    StringListParty = MC.PartyMaster.Select(x => x.PartyId).ToList();
                }
            }
            catch(Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();

            }

        }
        private void AssignSalesPersonParty(object InputValue)
        {
            try
            {
                string RequestParameter = "Report!@R020!@!@!@!@!@06/01/2016!@07/28/2016!@!@!@" + AppSessionState.EmpId + "!@All!@All!@All!@SO1!@M03!@shruti!@All!@False";
                        //string RequestParameter = "Report" + "!@" + "R020" + "!@" + ReportParameters.ItemCode + "!@" + ReportParameters.PartyId + "!@" + ReportParameters.Location_Id + "!@" + ReportParameters.comp_code + "!@" +"" + "!@" + "" + "!@" + ReportParameters.doc_no + "!@" + ReportParameters.t_status + "!@" + AppSessionState.EmpId + "!@" + ReportParameters.act_action + "!@" + ReportParameters.action_type + "!@" + ReportParameters.PartyType + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + AppSessionState.UserID + "!@" + ReportParameters.StatusName + "!@" + ReportParameters.active;
                        dsReport2 = repository_MCRpt.GetDataWithReturnDomainObject<List<MIS_CRM_SalesEntity2>>(dsReport2, RequestParameter, "MIS_CRMSalesReports", "CRM", "", 0, "MIS_CRM_Sales2");
                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(dsReport2, "dsMIS_CRM_Sales2", "\\CRM\\SalesPersonAssignedClientList.rdlc", getParametersList());
                    
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

                result.Add("PartyId", ReportParameters.PartyId);
                result.Add("PartyNm", "All");
                result.Add("EmpName", AppSessionState.EmpName);
                result.Add("doc_type", ReportParameters.doc_type);
                result.Add("doc_cat", ReportParameters.doc_cat);
                result.Add("t_status", ReportParameters.t_status);
                result.Add("ReportNm", "Assigned Client List Details");
                result.Add("doc_no", ReportParameters.doc_no);
                result.Add("comp_code", AppSessionState.comp_code);
                result.Add("Location_Id", AppSessionState.location_Id);
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
        private void CalculateDuration(object InputValue)
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
                            { POPUPEntityObject = MC.EmployeeMaster.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.owner = POPUPEntityObject.EmpId;
                    MasterEntity.EmpName = POPUPEntityObject.EmpName;


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
                    Request = MasterEntity.client + "!@" + MasterEntity.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
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
        private void InsertSales(object InputValue)
        {
            try
            {
                string Request = "";
                SEL_T001_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SalesInquiryMaster.Where(x => x.sono.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T001_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.sono = POPUPEntityObject.sono;
                    MasterEntity.s_status = POPUPEntityObject.t_status;
                    MasterEntity.project_name = POPUPEntityObject.para3;
                    MasterEntity.project_type = POPUPEntityObject.reference;
                    MasterEntity.project_location = POPUPEntityObject.project_location;
                    MasterEntity.PartyId = POPUPEntityObject.PartyId;
                    MasterEntity.party_name = POPUPEntityObject.party_name;

                }
                Request = "LoadPartyDetail" + "!@" + MasterEntity.PartyId;
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_TSK_T001_C>(MCTemp, Request, "CRMActivity", "CRM", "LoadPartDetail", 0, "");
                if (MCTemp.ContactInfo.Count > 0)
                {
                    LocationCollection = CollectionViewSource.GetDefaultView(MCTemp.ContactInfo);
                    LocationCollection.Filter = new Predicate<object>(Filter_Location);
                    StringListLocation = MCTemp.ContactInfo.Select(x => x.PersonName).ToList();

                    MasterEntity.contact_person = "";
                    MasterEntity.person_number = "";
                    MasterEntity.EmailId = "";
                    MasterEntity.place = "";
                    MasterEntity.address = "";
                    MasterEntity.architect_grade = "";

                    MasterEntity.contact_person = MCTemp.ContactInfo[0].PersonName;
                    MasterEntity.person_number = MCTemp.ContactInfo[0].PersnMobNo;
                    MasterEntity.EmailId = MCTemp.ContactInfo[0].PersnEmailId;
                    MasterEntity.place = MCTemp.ContactInfo[0].Location;
                    MasterEntity.address = MCTemp.ContactInfo[0].Add1;
                    MasterEntity.architect_grade = MCTemp.ContactInfo[0].group1;
                }
                else
                {
                    MasterEntity.contact_person = "";
                    MasterEntity.person_number = "";
                    MasterEntity.EmailId = "";
                    MasterEntity.place = "";
                    MasterEntity.address = "";
                    MasterEntity.architect_grade = "";
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
        private void InsertLocation(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M028_D_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MCTemp.ContactInfo.Where(x => x.PersonName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_D_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.contact_person = POPUPEntityObject.PersonName;
                    MasterEntity.person_number = POPUPEntityObject.PersnMobNo;
                    MasterEntity.EmailId = POPUPEntityObject.PersnEmailId;
                    MasterEntity.place = POPUPEntityObject.Location;
                    MasterEntity.address = POPUPEntityObject.Add1;
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
        private void InsertPactivity(object InputValue)
        {
            try
            {
                string Request = "";
                TSK_T001_C_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SheduleNumber.Where(x => x.doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<TSK_T001_C_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {

                    Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + POPUPEntityObject.doc_no;
                    MasterEntity = new TSK_T001_C();
                    MasterEntity = repository.GetDataWithReturnDomainObject<TSK_T001_C>(MasterEntity, Request, "CRMActivity", "CRM", "LoadDocumentWithReferenceDocumentNumber", 0, "");

                    if (MasterEntity != null)
                    {
                        MasterEntity.act_date = MasterEntity.act_date;
                        MasterEntity.act_desc = MasterEntity.act_desc;
                        MasterEntity.EmpName = MasterEntity.EmpName;
                        MasterEntity.duration = MasterEntity.duration;
                        MasterEntity.comp_code = AppSessionState.comp_code;
                        MasterEntity.location_Id = AppSessionState.location_Id;
                        MasterEntity.doc_date = System.DateTime.Now;
                        MasterEntity.end_date = MasterEntity.end_date;
                        MasterEntity.from_time = MasterEntity.from_time;
                        MasterEntity.note = MasterEntity.note;
                        MasterEntity.owner = MasterEntity.owner;
                        MasterEntity.parent_activity = MasterEntity.doc_no;
                        MasterEntity.act_action = "";
                        MasterEntity.doc_no = "";
                        isNewRecord = true;
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
        private void LoadBackFlipData(object InputValue)
        {
            try
            {
                string Request = "LoadBackFlipData" + "!@" + AppSessionState.comp_code + "!@" + MasterEntity.location_Id  + "!@" + AppSessionState.EmpId + "!@" + Convert.ToDateTime(FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(TooDate).ToString("MM/dd/yyyy")+"!@"+MasterEntity.owner;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_TSK_T001_C>(MCTemp, Request, "CRMActivity", "CRM", "LoadInitialData", 0, "");
                FlipGridData = MCTemp.BackFlipEntity.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);
            }
            catch (Exception ex) { }
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try {


                string Request = "";
                string ParametersStringValue = "";
                TSK_T001_C_BackFlip ParameterEntityObject = null;
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    if (ParameterObject.ToString() == "ReferenceDocument")
                    {
                        if (String.IsNullOrEmpty(""))
                        {
                            return;
                        }

                        ParameterReference = ParameterObject.ToString();
                    }
                    else if (ParameterReference == "DocumentNumber")
                    {
                        ParametersStringValue = ParameterObject.ToString().Trim();
                    }

                    if (ParametersStringValue.Length > 0)
                    {
                        try
                        { Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParametersStringValue; }
                        catch (Exception ex) { }
                    }
                }
                else if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<TSK_T001_C_BackFlip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<TSK_T001_C_BackFlip>().ToList()[0];
                        Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + ParameterEntityObject.doc_no;


                        AttachmentCollection = MC.Attachment;

                        isNewRecord = false;
                        MasterEntity = new TSK_T001_C();
                        MasterEntity = repository.GetDataWithReturnDomainObject<TSK_T001_C>(MasterEntity, Request, "CRMActivity", "CRM", "LoadDocumentWithReferenceDocumentNumber", 0, "");
                    }
                }
                MasterEntity.ts_code = ts_code_vm;
                SelectedTabControlIndex = 0;
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
        #region Abstract Command Actions
        private IEnumerable<T> MakeMeEnumerable<T>(T Entity)
        {
            yield return Entity;
        }
        protected override void OnSaveAction(InquiryActionResult<TSK_T001_C> result)
        {
            try
            {
                if (Validation() == true)
                {
                    if (MasterEntity.t_status == null)
                    {
                        MasterEntity.t_status = "Draft";

                    }
                    DefaultValues();
                   
                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<TSK_T001_C>(MasterEntity, "CRMActivity", "CRM");
                        if (MasterEntity.doc_no != null)// && NotificationDataCollection.FindIndex(f => f.alert_name == "OnInsert") >= 0
                        {
                            NotifyMessage("OnInsert");
                        }
                        isNewRecord = false;
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<TSK_T001_C>(MasterEntity, "CRMActivity", "CRM");

                    }
                    SetBackFlipEntitiesAfterLoad();
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
        protected override void OnCreateAction(InquiryActionResult<TSK_T001_C> result)
        {
            try
            {
                isNewRecord = true;
                MasterEntity = new TSK_T001_C();
                MasterEntity.ValidateAsync().Wait();

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
        protected override void OnRemoveAction(InquiryActionResult<TSK_T001_C> result)
        {
            try
            {
                if (MasterEntity.doc_no != null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Delete Changes";
                    showMessageService.Text =
                        String.Format(
                            "This record will be Deleted forever '{0}'",
                                this.Title);
                    if (showMessageService.ShowMessage() == DialogResult.Ok)
                    {
                        this.MasterEntity.EndEdit();
                        string response = repository.Delete(MasterEntity.doc_no, "CRMActivity", "CRM");

                        MasterEntity = new TSK_T001_C();

                        FlipDataGridCollection.Refresh();
                        isNewRecord = true;
                    }
                    DefaultValues();
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
        protected override void OnDiscardAction(InquiryActionResult<TSK_T001_C> result)
        {
           
        }
        protected override void OnFevoriteAction(InquiryActionResult<TSK_T001_C> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<TSK_T001_C> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<TSK_T001_C> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<TSK_T001_C> result)
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<TSK_T001_C> result)
        {
            throw new NotImplementedException();
        }
        #endregion
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        #region Event Handler

        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes

            if (sender.ToString() == "from_time" || sender.ToString() == "to_time" )
            {

                if (MasterEntity.to_time != null)
                {
                    if (MasterEntity.from_time != null)
                    {
                        TimeSpan duration1 = DateTime.Parse(MasterEntity.to_time).Subtract(DateTime.Parse(MasterEntity.from_time));
                   
                    MasterEntity.duration = (duration1 ).ToString();

                    }
                }

            }
            this.ErrorExist = MasterEntity.HasErrors;
          
        }

        #endregion
        #region User Defined Functions

        private void LoadInitialData()
        {
            try
            {
                #region Command Initialisation
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CheckedCustomerCommand = new RelayCommand<bool>(checkcust);
                cmddgLocation = new RelayCommand<object>(items => { if (items == null) { return; } Insertdgplant(items); });
                cmdAssignParty = new RelayCommand<object>(items => { if (items == null) { return; } AssignSalesPersonParty(items); });
                CommandParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items, isNewRecord); });
                CommandEmployee = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmployee(items); });
                CommandSales = new RelayCommand<object>(items => { if (items == null) { return; } InsertSales(items); });
                CommandPactivity = new RelayCommand<object>(items => { if (items == null) { return; } InsertPactivity(items); });
                CommandLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertLocation(items); });
                Commandtime = new RelayCommand<object>(items => { if (items == null) { return; } CalculateDuration(items); });
                cmdUnvisited = new RelayCommand<object>(items => { if (items == null) { return; } InsertUnvisited(items); });
                cmdLoadBackFlip = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadBackFlipData(cmdPara); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); }); // confirm assignment
                #endregion
                DefaultValues();

                string Request = "LoadInitialData" + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type +"!@"+AppSessionState.EmpId + "!@" + Convert.ToDateTime(FrmDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ToDate).ToString("MM/dd/yyyy");
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_TSK_T001_C>(MC, Request, "CRMActivity", "CRM", "LoadInitialData", 0, "");

                FlipGridData = MC.BackFlipEntity.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

                PartyCollection = CollectionViewSource.GetDefaultView(MC.PartyMaster);
                PartyCollection.Filter = new Predicate<object>(Filter_Party);
                StringListParty = MC.PartyMaster.Select(x => x.PartyId).ToList();

                employeeCollection = CollectionViewSource.GetDefaultView(MC.EmployeeMaster.ToList());
                employeeCollection.Filter = new Predicate<object>(Filter_Employee);
                StringListemployee = MC.EmployeeMaster.Select(x => x.EmpId).ToList();

                salesCollection = CollectionViewSource.GetDefaultView(MC.SalesInquiryMaster);
                salesCollection.Filter = new Predicate<object>(Filter_Sales);
                StringListSales = MC.SalesInquiryMaster.Select(x => x.sono).ToList();

                ParentCollection = CollectionViewSource.GetDefaultView(MC.SheduleNumber);
                ParentCollection.Filter = new Predicate<object>(Filter_ParentNo);
                StringListparentactivity = MC.SheduleNumber.Select(x => x.doc_no).ToList();

                UnvisitedCollection = CollectionViewSource.GetDefaultView(MC.UnvisitedList);
                UnvisitedCollection.Filter = new Predicate<object>(Filter_Unvisited_Person);
                StrListUnvisited = MC.UnvisitedList.Select(x => x.EmpName).ToList();

                LocationList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var location = (from o in LocationList where o.comp_code == AppSessionState.comp_code select o).ToList();
                dgLocationCollection = CollectionViewSource.GetDefaultView(location);
                dgLocationCollection.Filter = new Predicate<object>(Filter_dgLocation);
                StringListdgLocationID = location.Select(x => x.location_Id).ToList();
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
            try
            {
                MasterEntity.ts_code = ts_code_vm;
                if (MasterEntity.act_action == "Log" && MasterEntity.action_type == "Meeting")
                {
                    MasterEntity.doc_type = "LM";
                    MasterEntity.doc_cat = "LM";
                }

                else if (MasterEntity.act_action == "Schedule" && MasterEntity.action_type == "Meeting")
                {
                    MasterEntity.doc_type = "SM";
                    MasterEntity.doc_cat = "SM";
                }

                if (MasterEntity.act_action == "Log" && MasterEntity.action_type == "Call")
                {
                    MasterEntity.doc_type = "LC";
                    MasterEntity.doc_cat = "LC";
                }

                else if (MasterEntity.act_action == "Schedule" && MasterEntity.action_type == "Call")
                {
                    MasterEntity.doc_type = "SC";
                    MasterEntity.doc_cat = "SC";
                }


                MasterEntity.add_by = AppSessionState.UserID;
                MasterEntity.editby = AppSessionState.UserID;

                MasterEntity.comp_code = AppSessionState.comp_code;
                MasterEntity.location_Id = AppSessionState.location_Id;
                MasterEntity.so_code = AppSessionState.so_code;
                MasterEntity.sg_code = AppSessionState.sg_code;
                MasterEntity.doc_date = System.DateTime.Now;
                MasterEntity.active = true;
                MasterEntity.owner = AppSessionState.EmpId;
                MasterEntity.EmpName = AppSessionState.EmpName;
                MasterEntity.client = AppSessionState.client;
                MasterEntity.user_source1 = AppSessionState.UserSource1;
                MasterEntity.user_source2 = AppSessionState.UserSource2;
                MasterEntity.userid = AppSessionState.UserID;
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

        private bool Validation()
        {
            try
            {
                if (MasterEntity.action_type == null || MasterEntity.action_type == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Action Type Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.act_action == null || MasterEntity.act_action == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Activity Action Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.doc_date == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Document Date Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.start_date == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Start Date Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.address == null || MasterEntity.address == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Address Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.owner == null || MasterEntity.owner == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Employee Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.party_name == null || MasterEntity.party_name == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Party Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.priority == null || MasterEntity.priority == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Priority Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.from_time == null || MasterEntity.from_time == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Start Time Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.contact_person == null || MasterEntity.contact_person == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Contact Person Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.t_status == null || MasterEntity.t_status == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Status Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.EmailId == null || MasterEntity.EmailId == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Email_Id Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.project_name == null || MasterEntity.project_name == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Project Name Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.project_location == null || MasterEntity.project_location == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Project Location Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }



                return true;
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
            return true;
        }

        private void SetBackFlipEntitiesAfterLoad()
        {
            try
            {
                if (MasterEntity.BackFlipEntity != null)
                {
                    MC.BackFlipEntity = (List<TSK_T001_C_BackFlip>)new ObjectSerializationService().XMLToObject(MasterEntity.BackFlipEntity, MC.BackFlipEntity);
                    FlipGridData.Add(MC.BackFlipEntity[0]);
                    FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                    _FlipDataGridCollection.Refresh();
                }
                else
                {

                    MC.BackFlipEntity = new List<TSK_T001_C_BackFlip>();
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
        private void NotifyMessage(string AlertName)
        {
            try
            {
                List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>()
                {
                   new KeyValuePair<string, string>("[Comp]","M/s: " +AppSessionState.CompanyName),
                   new KeyValuePair<string, string>("[Attn]",AppSessionState.Name),
                   new KeyValuePair<string, string>("[CUST]","M/s: " +  MasterEntity.party_name),
                   new KeyValuePair<string, string>("[EMP]",AppSessionState.Name),
                   new KeyValuePair<string, string>("[DOCNO]", MasterEntity.doc_no),
                   new KeyValuePair<string, string>("[DOCDATE]", MasterEntity.doc_date .ToString()),
                };
                foreach (KeyValuePair<string, string> kvp in kvpList)
                {
                    subject = "DSR Document generated by " + AppSessionState.Name;
                    MC.BackFlipEntity[0].msg_body = MC.BackFlipEntity[0].msg_body.Replace(kvp.Key, kvp.Value); 
                }
                Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, "No mail ID", null, null, subject, MC.BackFlipEntity[0].msg_body, null);
            }
            catch (Exception ex)
            {
                
            }
        }
        #endregion
       
        #region Filters

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
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as TSK_T001_C_BackFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.contact_person != null && data.contact_person.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.party_name != null && data.party_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.sono != null && data.sono.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));

                }
                return true;
            }
            return false;
        }

        private string _filterString_Party;
        public string FilterString_Party
        {
            get { return _filterString_Party; }
            set
            {
                _filterString_Party = value;
                RaisePropertyChanged("FilterString_Party");
                FilterCollection_Party();
            }
        }
        private void FilterCollection_Party()
        {
            if (_partyCollection != null)
            {
                _partyCollection.Refresh();
            }
        }
        public bool Filter_Party(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Party))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_Party.ToLower()) ||
                        data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_Party.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_Location;
        public string FilterString_Location
        {
            get { return _filterString_Location; }
            set
            {
                _filterString_Location = value;
                RaisePropertyChanged("FilterString_Location");
                FilterCollection_Location();
            }
        }
        private void FilterCollection_Location()
        {
            if (_LocationCollection != null)
            {
                _LocationCollection.Refresh();
            }
        }
        public bool Filter_Location(object obj)
        {
            var data = obj as ADM_M028_D_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Location))
                {
                    return (data.PersonName != null && data.PersonName.ToString().ToLower().Contains(_filterString_Location.ToLower())) ||
                           (data.PersnMobNo != null && data.PersnMobNo.ToString().ToLower().Contains(_filterString_Location.ToLower())) ||
                           (data.PersnEmailId != null && data.PersnEmailId.ToString().ToLower().Contains(_filterString_Location.ToLower()));
                }
                return true;
            }
            return false;
        }


        private string _filterString_Employee;
        public string FilterString_Employee
        {
            get { return _filterString_Employee; }
            set
            {
                _filterString_Employee = value;
                RaisePropertyChanged("FilterString_Employee");
                FilterCollection_Employee();
            }
        }
        private void FilterCollection_Employee()
        {
            if (_employeeCollection != null)
            {
                _employeeCollection.Refresh();
            }
        }
        public bool Filter_Employee(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Employee))
                {
                    return (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterString_Employee.ToLower()) ||
                         data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterString_Employee.ToLower())
                );
                }
                return true;
            }
            return false;
        }

        private string _filterString_Unvisited;
        public string FilterString_Unvisited
        {
            get { return _filterString_Unvisited; }
            set
            {
                _filterString_Unvisited = value;
                RaisePropertyChanged("FilterString_Unvisited");
                FilterCollection_Unvisited();
            }
        }
        private void FilterCollection_Unvisited()
        {
            if (_UnvisitedCollection != null)
            {
                _UnvisitedCollection.Refresh();
            }
        }
        public bool Filter_Unvisited_Person(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Unvisited))
                {
                    return (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterString_Unvisited.ToLower()))||
                           (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterString_Unvisited.ToLower()))||
                           (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_Unvisited.ToLower())
                );
                }
                return true;
            }
            return false;
        }

        private string _FilterString_dgLocation;
        public string FilterString_dgLocation
        {
            get { return _FilterString_dgLocation; }
            set
            {
                _FilterString_dgLocation = value;
                RaisePropertyChanged("FilterString_dgLocation");
                FilterCollection_dgLocation();
            }
        }
        private void FilterCollection_dgLocation()
        {
            if (_LocationCollection != null)
            {
                _LocationCollection.Refresh();
            }

        }
        public bool Filter_dgLocation(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_dgLocation))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_FilterString_dgLocation.ToLower()) ||
                        data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_FilterString_dgLocation.ToLower()));
                }
                return true;
            }
            return false;
        }


        private string _filterString_Sales;
        public string FilterString_Sales
        {
            get { return _filterString_Sales; }
            set
            {
                _filterString_Sales = value;
                RaisePropertyChanged("FilterString_Sales");
                FilterCollection_Sales();
            }
        }
        private void FilterCollection_Sales()
        {
            if (_salesCollection != null)
            {
                _salesCollection.Refresh();
            }
        }
        public bool Filter_Sales(object obj)
        {
            var data = obj as SEL_T001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Sales))
                {
                    return (data.sono != null && data.sono.ToString().ToLower().Contains(_filterString_Sales.ToLower())) ||
                           (data.sodate != null && data.sodate.ToString().ToLower().Contains(_filterString_Sales.ToLower())) ||
                           (data.buyer_name != null && data.buyer_name.ToString().ToLower().Contains(_filterString_Sales.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_Sales.ToLower()));
                }
                return true;
            }
            return false;
        }
        private string _filterString_Parentactivity;
        public string FilterString_Parentactivity
        {
            get { return _filterString_Parentactivity; }
            set
            {
                _filterString_Parentactivity = value;
                RaisePropertyChanged("FilterString_Parentactivity");
                FilterCollection_Pactivity();
            }
        }
        private void FilterCollection_Pactivity()
        {
            if (_parentCollection != null)
            {
                _parentCollection.Refresh();
            }
        }
        public bool Filter_ParentNo(object obj)
        {
            var data = obj as TSK_T001_C_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Parentactivity))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_Parentactivity.ToLower())) ||
                           (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_Parentactivity.ToLower())) ||
                           (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_filterString_Parentactivity.ToLower()));
                          
                }
                return true;
            }
            return false;
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
