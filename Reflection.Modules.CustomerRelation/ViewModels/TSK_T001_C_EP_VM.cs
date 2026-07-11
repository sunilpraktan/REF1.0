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
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using System.Collections.Specialized;
using Reflection.BusinessEntity.CustomerRelation;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class TSK_T001_C_EP_VM : WorkspaceViewModel<TSK_T001_C>
    {
        #region Variable Declaration
        bool isNewRecord = true;
        string subject;
        string msg_body;

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

        private ObservableCollection<TSK_T001_C> _ItemsEntity;
        public ObservableCollection<TSK_T001_C> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value; RaisePropertyChanged("ItemsEntity");
                    ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("ItemsEntity");
                }
            }
        }

        private string _IsCheck;
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
        private int _dgSelectedIndex;
        public int dgSelectedIndex
        {
            get { return _dgSelectedIndex; }
            set { if (_dgSelectedIndex != value) { _dgSelectedIndex = value; RaisePropertyChanged("dgSelectedIndex"); } }
        }

        private int _dgSelectedIndexItem;
        public int dgSelectedIndexItem
        {
            get
            {
                return _dgSelectedIndexItem;
            }
            set
            {
                if (_dgSelectedIndexItem != value)
                {
                    _dgSelectedIndexItem = value;
                    RaisePropertyChanged("dgSelectedIndexItem");

                }
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
        private ICollectionView _CustomerCollection;
        public ICollectionView CustomerCollection
        {
            get { return _CustomerCollection; }
            set { _CustomerCollection = value; RaisePropertyChanged("CustomerCollection"); }
        }
        private ICollectionView _employeeCollection;
        public ICollectionView employeeCollection
        {
            get { return _employeeCollection; }
            set { _employeeCollection = value; RaisePropertyChanged("employeeCollection"); }
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
        private ICollectionView _SoAndQuotationCollection;
        public ICollectionView SoAndQuotationCollection
        {
            get { return _SoAndQuotationCollection; }
            set { _SoAndQuotationCollection = value; RaisePropertyChanged("SoAndQuotationCollection"); }
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
        private List<SEL_T001_QN> _SelectedSalesOrders;
        public List<SEL_T001_QN> SelectedSalesOrders
        {
            get { return _SelectedSalesOrders; }
            set
            {
                _SelectedSalesOrders = value;
                RaisePropertyChanged("SelectedSalesOrders");
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
        List<string> _StringListCustomer;
        public List<string> StringListCustomer
        {
            get { return _StringListCustomer; }
            set
            {
                if (_StringListCustomer != value)
                {
                    _StringListCustomer = value;
                }
            }
        }

        List<string> _StringListCustomerForGrid;
        public List<string> StringListCustomerForGrid
        {
            get { return _StringListCustomerForGrid; }
            set
            {
                if (_StringListCustomerForGrid != value)
                {
                    _StringListCustomerForGrid = value;
                }
            }
        }

        List<string> _StringListRefDoc;
        public List<string> StringListRefDoc
        {
            get { return _StringListRefDoc; }
            set
            {
                if (_StringListRefDoc != value)
                {
                    _StringListRefDoc = value;
                }
            }
        }
        #endregion

        #region Relay Commands Declaration
        public RelayCommand<Boolean> CheckedCustomerCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> cmdAssignParty { get; private set; }
        public RelayCommand<object> CommandParty { get; private set; }
       // public RelayCommand<object> CmdAddCustomerForGrid { get; private set; }
        public RelayCommand<object> CommandEmployee { get; private set; }
        public RelayCommand<object> CommandSales { get; private set; }
        public RelayCommand<object> CommandPactivity { get; private set; }
        public RelayCommand<object> Commandtime { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdAddSoOnSelected { get; private set; } // Added By Mayuri
        public RelayCommand<object> CmdAddCustomerForGrid { get; private set; } //
        public RelayCommand<object> CmdAddRefDoc { get; private set; }
        public RelayCommand<IList> dgSelectionChanged { get; private set; }
        public RelayCommand cmdLoadByParty { get; private set; }
        public RelayCommand CmdDeleteDataGridRowItem { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor for ViewModel
        /// </summary>
        /// <param name="NA"></param>
        public TSK_T001_C_EP_VM() : base()
        {
            MasterEntity = new TSK_T001_C();
            ReportParameters = new MISReportParameter();
            ItemsEntity = new ObservableCollection<TSK_T001_C>();
            _dsReport2 = new List<MIS_CRM_SalesEntity2>();
            FlipGridData = new List<TSK_T001_C_BackFlip>();
            MC = new MultipleContext_TSK_T001_C();
            MCTemp = new MultipleContext_TSK_T001_C();
            SelectedSalesOrders = new List<SEL_T001_QN>();
            CheckedCustomerCommand = new RelayCommand<bool>(checkcust);
            MasterEntity.ValidateAsync().Wait();
            TSK_T001_C.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            NotificationDataCollection = new List<NotificationData>();

            #region Command Initialisation

            CommandParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items, isNewRecord); });
            CommandEmployee = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmployee(items); });
            CommandSales = new RelayCommand<object>(items => { if (items == null) { return; } InsertSales(items); });
            CommandPactivity = new RelayCommand<object>(items => { if (items == null) { return; } InsertPactivity(items); });
            //CmdAddCustomerForGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCustomerForGrid(cmdPara, true, true, true); });
            Commandtime = new RelayCommand<object>(items => { if (items == null) { return; } CalculateDuration(items); });
            CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); }); // confirm assignment
            CmdAddSoOnSelected = new RelayCommand<object>(items => { if (items == null) { return; } InsertSO(items); });
            CmdAddCustomerForGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCustomerForGrid(cmdPara, true, true, true); });
            CmdAddRefDoc = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertRefDoc(cmdPara, true, true, true); });
            cmdLoadByParty = new RelayCommand(() => { LoadByParty(); });
            dgSelectionChanged = new RelayCommand<IList>( items => { if (items == null) { return;} GetSelectedChanged(items); });
            CmdDeleteDataGridRowItem = new RelayCommand(() => { OnRemove(); });
            #endregion

            LoadInitialData();

        }

        #endregion

        #region Relay Command Actions ·
        private void LoadByParty()
        {
            try
            {
                string Request = "";
                if (MasterEntity.PartyId == null || MasterEntity.PartyId == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Refernece Selection";
                    showMessageService.Text = String.Format("Please Select Party first", this.Title);
                    showMessageService.ShowMessage();
                }
                else
                {
                    MasterEntity.doc_cat = "EP";
                    Request = "LoadByParty" + "!@" + MasterEntity.PartyId + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.UserID + "!@" + MasterEntity.doc_cat;

                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_TSK_T001_C>(MCTemp, Request, "CRMActivity", "CRM", "LoadInitialData", 0, "");
                    if (MCTemp.ItemEntity.Count>0)
                    {
                        ItemsEntity = MCTemp.ItemEntity;
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Refernece Selection";
                        showMessageService.Text = String.Format("There is no records Save for this Party...", this.Title);
                        showMessageService.ShowMessage();
                    }
                    isNewRecord = false;
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
        private void OnRemove()
        {
            try
            {
                if (dgSelectedIndexItem!=-1)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id > 0)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].doc_no != null)
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
                                string response = repository.Delete(ItemsEntity[dgSelectedIndexItem].doc_no, "CRMActivity", "CRM");
                                                           
                                ItemsEntity = new ObservableCollection<TSK_T001_C>();
                                
                                isNewRecord = true;
                            }
                            DefaultValues();

                        }
                        string Request = "";
                        MasterEntity.doc_cat = "EP";
                        Request = "LoadByParty" + "!@" + MasterEntity.PartyId + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.UserID + "!@" + MasterEntity.doc_cat;

                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_TSK_T001_C>(MCTemp, Request, "CRMActivity", "CRM", "LoadInitialData", 0, "");
                        if (MCTemp.ItemEntity.Count > 0)
                        {
                            ItemsEntity = MCTemp.ItemEntity;
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
        private void GetSelectedChanged(IList items)
        {
            try
            {
                string Request = "";
                if (items.Count > 0 && dgSelectedIndexItem != -1 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    Request = "LoadSOAndQuotationDetails" + "!@" + ItemsEntity[dgSelectedIndexItem].PartyId + "!@" + ItemsEntity[dgSelectedIndexItem].location_Id + "!@" + ItemsEntity[dgSelectedIndexItem].comp_code;

                    MC = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_TSK_T001_C>(MC, Request, "CRMActivity", "CRM", "LoadPartDetail", 0, "");
                    if (MC.SalesOrderAndQuotation.Count > 0)
                    {
                        SelectedSalesOrders = MC.SalesOrderAndQuotation;
                        SoAndQuotationCollection = CollectionViewSource.GetDefaultView(MC.SalesOrderAndQuotation);
                        SoAndQuotationCollection.Filter = new Predicate<object>(Filter_RefDoc);
                        StringListRefDoc = MC.SalesOrderAndQuotation.Select(x => x.sono.ToString()).ToList();
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
        private void InsertParty(object InputValue, bool OverrideValue)
        {
            try
            {
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

                    Request = "LoadSOAndQuotationDetails" + "!@" + MasterEntity.PartyId + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;

                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_TSK_T001_C>(MCTemp, Request, "CRMActivity", "CRM", "LoadPartDetail", 0, "");
                    if (MCTemp.SalesOrderAndQuotation.Count > 0)
                    {
                        SelectedSalesOrders = MCTemp.SalesOrderAndQuotation;
                        SoAndQuotationCollection = CollectionViewSource.GetDefaultView(MC.SalesOrderAndQuotation);
                        SoAndQuotationCollection.Filter = new Predicate<object>(Filter_Customer);
                        StringListCustomer = MC.PartyMaster.Select(x => x.PartyId.ToString()).ToList();
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("No records exist..");
                        showMessageService.ShowMessage();

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
        private void InsertCustomerForGrid(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;

                //Command Parameter Read section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
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
                    if (((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }

                }

                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = ItemsEntity.Where(x => x.PartyId == POPUPEntityObject.PartyId).FirstOrDefault();
                    var IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.PartyId == POPUPEntityObject.PartyId).FirstOrDefault());

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                    {
                        ItemsEntity.Add(new TSK_T001_C()
                        {
                            id = 0,
                            active = true,
                            PartyId = POPUPEntityObject.PartyId,
                            party_name = POPUPEntityObject.PartyNm,                    
                         
                        });
                    
                    }

                    else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].PartyId = POPUPEntityObject.PartyId;
                            ItemsEntity[dgSelectedIndexItem].party_name = POPUPEntityObject.PartyNm;
                            ItemsEntity[dgSelectedIndexItem].active = true;

                        }
                        else if (ItemsEntity[dgSelectedIndexItem].PartyId != POPUPEntityObject.PartyId)
                        {
                            ItemsEntity[dgSelectedIndexItem].PartyId = POPUPEntityObject.PartyId;
                            ItemsEntity[dgSelectedIndexItem].party_name = POPUPEntityObject.PartyNm;
                       
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
        private void InsertRefDoc(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            SEL_T001_QN POPUPEntityObject = null;

            //Command Parameter Read section

            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    { POPUPEntityObject = MC.SalesOrderAndQuotation.Where(x => x.sono.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                    catch (Exception ex) { }
                }
            }
            else if (InputValue != null)
            {
                if (((IEnumerable)InputValue).Cast<SEL_T001_QN>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T001_QN>().ToList()[0];
                }
            }
            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(x => x.sono == POPUPEntityObject.sono).FirstOrDefault();
                var IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.PartyId == POPUPEntityObject.sono).FirstOrDefault());

                if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                {
                    ItemsEntity.Add(new TSK_T001_C()
                    {                  
                        sono = POPUPEntityObject.sono,                                      
                    });
                }
                else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        ItemsEntity[dgSelectedIndexItem].sono = POPUPEntityObject.sono;
                       
                    }
                    else if (ItemsEntity[dgSelectedIndexItem].sono != POPUPEntityObject.sono)
                    {
                        ItemsEntity[dgSelectedIndexItem].sono = POPUPEntityObject.sono;                   
                    }
                }
            }
        }
        private void InsertEmployee(object InputValue)
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
                else if (select == false)
                {
                    PartyCollection = CollectionViewSource.GetDefaultView(MC.PartyMaster);
                    PartyCollection.Filter = new Predicate<object>(Filter_Party);
                    StringListParty = MC.PartyMaster.Select(x => x.PartyId).ToList();
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
                    MasterEntity.project_location = POPUPEntityObject.location;
                    MasterEntity.PartyId = POPUPEntityObject.PartyId;
                    MasterEntity.party_name = POPUPEntityObject.party_name;



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
        private void InsertSO(object InputValue)
        {
            try
            {
                string Request = "";
                if (dgSelectedIndex != -1 && SelectedSalesOrders.Count>0)
                {
                    if (SelectedSalesOrders[dgSelectedIndex].sono != null)
                    {
                        MasterEntity.sono = SelectedSalesOrders[dgSelectedIndex].sono;
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
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
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
                    MasterEntity.XmlDataDocument_ItemsEntity = obj.ObjectToXML(ItemsEntity);

                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<TSK_T001_C>(MasterEntity, "ExpectedPayment", "CRM");
                        if (MasterEntity.doc_no != null)// && NotificationDataCollection.FindIndex(f => f.alert_name == "OnInsert") >= 0
                        {
                            NotifyMessage("OnInsert");
                        }
                        isNewRecord = false;
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<TSK_T001_C>(MasterEntity, "ExpectedPayment", "CRM");

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
                MasterEntity.doc_cat = "EP";
                MasterEntity.doc_type = "EP";
                isNewRecord = true;
                MasterEntity = new TSK_T001_C();
                ItemsEntity = new ObservableCollection<TSK_T001_C>();
                SelectedSalesOrders = new List<SEL_T001_QN>();
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
        protected override void OnDocumentAction()
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

        #region Event Handler

        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes

            if (sender.ToString() == "from_time" || sender.ToString() == "to_time")
            {

                if (MasterEntity.to_time != null)
                {
                    if (MasterEntity.from_time != null)
                    {



                        TimeSpan duration1 = DateTime.Parse(MasterEntity.to_time).Subtract(DateTime.Parse(MasterEntity.from_time));

                        MasterEntity.duration = (duration1).ToString();

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
                MasterEntity.doc_cat = "EP";
                MasterEntity.doc_type = "EP";
                string Request = "LoadInitialData" + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + AppSessionState.EmpId;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_TSK_T001_C>(MC, Request, "CRMActivity", "CRM", "LoadInitialData", 0, "");


                var Data = (from o in MC.BackFlipEntity where  (o.doc_type== "EP" && o.doc_cat == "EP") select o).ToList();

                //FlipGridData = MC.BackFlipEntity.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(Data);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

                PartyCollection = new CollectionViewSource { Source = MC.PartyMaster }.View;
                PartyCollection.Filter = new Predicate<object>(Filter_Party);
                StringListParty = MC.PartyMaster.Select(x => x.PartyId).ToList();

                CustomerCollection = CollectionViewSource.GetDefaultView(MC.PartyMaster);
                CustomerCollection.Filter = new Predicate<object>(Filter_Customer);
                StringListCustomer = MC.PartyMaster.Select(x => x.PartyId.ToString()).ToList();

                employeeCollection = CollectionViewSource.GetDefaultView(MC.EmployeeMaster.ToList());
                employeeCollection.Filter = new Predicate<object>(Filter_Employee);
                StringListemployee = MC.EmployeeMaster.Select(x => x.EmpId).ToList();

                salesCollection = CollectionViewSource.GetDefaultView(MC.SalesInquiryMaster);
                salesCollection.Filter = new Predicate<object>(Filter_Sales);
                StringListSales = MC.SalesInquiryMaster.Select(x => x.sono).ToList();

                ParentCollection = CollectionViewSource.GetDefaultView(MC.SheduleNumber);
                ParentCollection.Filter = new Predicate<object>(Filter_ParentNo);
                StringListparentactivity = MC.SheduleNumber.Select(x => x.doc_no).ToList();

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
            try
            {
                

                MasterEntity.add_by = AppSessionState.UserID;
                MasterEntity.editby = AppSessionState.UserID;
                MasterEntity.t_status = "Draft";
                MasterEntity.client = AppSessionState.client;
                MasterEntity.comp_code = AppSessionState.comp_code;
                MasterEntity.location_Id = AppSessionState.location_Id;
                MasterEntity.so_code = AppSessionState.so_code;
                MasterEntity.sg_code = AppSessionState.sg_code;
                MasterEntity.doc_date = System.DateTime.Now;
                MasterEntity.active = true;
                MasterEntity.owner = AppSessionState.EmpId;
                MasterEntity.EmpName = AppSessionState.EmpName;
                MasterEntity.doc_date = DateTime.Now ;
                MasterEntity.start_date = DateTime.Now;
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
              
                //if (MasterEntity.doc_date == null)
                //{
                //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //    showMessageService.ButtonSetup = DialogButton.Ok;
                //    showMessageService.Caption = "Required";
                //    showMessageService.Text = String.Format("Document Date Is Required", this.Title);
                //    showMessageService.ShowMessage();
                //    return false;
                //}
                if (dgSelectedIndexItem != -1)
                {
                    foreach (var o in ItemsEntity)
                    {
                        if (o.pay_expected_date == null )
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Required";
                            showMessageService.Text = String.Format("Pay Expected Date Is Required", this.Title);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if(o.doc_date==null )
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Required";
                            showMessageService.Text = String.Format("Document Date Is Required", this.Title);
                            showMessageService.ShowMessage();
                            return false;

                        }
                    }
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
                if (MasterEntity.XmlDataDocument_ItemsEntity != null)
                {
                    ItemsEntity.Clear();
                    ItemsEntity = (ObservableCollection<TSK_T001_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ItemsEntity, MC.ItemEntity);
                }
                else
                {
                    MC.ItemEntity = new ObservableCollection<TSK_T001_C>();
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
                Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, "No mail id", null, null, subject, MC.BackFlipEntity[0].msg_body, null);
            }
            catch (Exception ex)
            {

            }
        }
        #endregion

        #region 
       
        public void EntityViewModelPropertyChangedForItem(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false;/*MasterEntity.HasErrors;*/
            if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = ItemsEntity[dgSelectedIndexItem].HasErrors;
            }

        }

        void MyType_PropertyChangedForItem(object sender, PropertyChangedEventArgs e)
        {

            if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = false; /*dgItemsEntity[dgSelectedIndexItem].HasErrors;*/
            }
        }

        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            //////////////////////////////////Temp Test
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (TSK_T001_C item in e.NewItems)
                    item.PropertyChanged += this.MyType_PropertyChangedForItem;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (TSK_T001_C item in e.OldItems)
                    item.PropertyChanged -= this.MyType_PropertyChangedForItem;

            /////////////////////////////////Temp Test End
            //different kind of changes that may have occurred in collection
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (TSK_T001_C item in e.NewItems)
                {
                    //Added items
                    item.id = 0;
                    item.add_by = AppSessionState.UserID;
                    item.editby = AppSessionState.UserID;
                    item.comp_code = AppSessionState.comp_code;
                    item.location_Id = AppSessionState.location_Id;
                    item.active = true;
                    item.doc_cat = "EP";
                    item.doc_type = "EP";
                    item.doc_date = DateTime.Now;
                    item.pay_expected_date = DateTime.Now;
                    item.start_date = DateTime.Now;
                    item.t_status = "Draft";


                    item.PropertyChanged += EntityViewModelPropertyChangedForItem;
                }
                if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = ItemsEntity[dgSelectedIndexItem].HasErrors;
                }
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
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_Party.ToLower()))||
                            (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_Party.ToLower()));
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

        private string _FilterStringCustomer;
        public string FilterStringCustomer
        {
            get { return _FilterStringCustomer; }
            set
            {
                _FilterStringCustomer = value;
                RaisePropertyChanged("FilterStringCustomer");
                Filter_Customer();
            }
        }
        private void Filter_Customer()
        {
            if (_CustomerCollection != null)
            {
                _CustomerCollection.Refresh();
            }
        }
        public bool Filter_Customer(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringCustomer))
                {
                    return (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_FilterStringCustomer.ToLower())) ||
                           (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_FilterStringCustomer.ToLower()));

                }
                return true;
            }
            return false;
        }


        private string _FilterStringRefDoc;
        public string FilterStringRefDoc
        {
            get { return _FilterStringRefDoc; }
            set
            {
                _FilterStringRefDoc = value;
                RaisePropertyChanged("FilterStringRefDoc");
                Filter_RefDoc();
            }
        }
        private void Filter_RefDoc()
        {
            if (_SoAndQuotationCollection != null)
            {
                _SoAndQuotationCollection.Refresh();
            }
        }
        public bool Filter_RefDoc(object obj)
        {
            var data = obj as SEL_T001_QN;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringRefDoc))
                {
                    return (data.sono != null && data.sono.ToString().ToLower().Contains(_FilterStringRefDoc.ToLower())) ||
                           (data.sodate != null && data.sodate.ToString().ToLower().Contains(_FilterStringRefDoc.ToLower())) ||
                           (data.Seller_Name != null && data.Seller_Name.ToString().ToLower().Contains(_FilterStringRefDoc.ToLower())) ||
                           (data.sales_person_cd != null && data.sales_person_cd.ToString().ToLower().Contains(_FilterStringRefDoc.ToLower())) ||
                           (data.roundup_total != null && data.roundup_total.ToString().ToLower().Contains(_FilterStringRefDoc.ToLower())) ||
                           (data.buyer != null && data.buyer.ToString().ToLower().Contains(_FilterStringRefDoc.ToLower())) ||
                           (data.buyer_name != null && data.buyer_name.ToString().ToLower().Contains(_FilterStringRefDoc.ToLower()));
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
