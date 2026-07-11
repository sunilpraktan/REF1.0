using System.Threading.Tasks;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections;
using Reflection.ReportingServices;

namespace Reflection.Modules.SCM.ViewModels
{
    public class MM_T004_IO_VM : WorkspaceViewModel<MM_T004>
    {
        #region Variable Declaration And Object
        bool NewRecord = true;

        WebServiceRepository<MM_T004> repository = new WebServiceRepository<MM_T004>();
        WebServiceRepository<MultipleContext_MM_T004> repository_MC = new WebServiceRepository<MultipleContext_MM_T004>();
        ObjectSerializationService obj = new ObjectSerializationService();
        MultipleContext_MM_T004 MCTemp = new MultipleContext_MM_T004();

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        private MM_T004 _MasterEntity;
        public MM_T004 MasterEntity
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

        private MM_T004 _MasterEntityTemp;
        public MM_T004 MasterEntityTemp
        {
            get
            {
                return _MasterEntityTemp;
            }
            set
            {
                if (_MasterEntityTemp != value)
                {
                    _MasterEntityTemp = value;
                    RaisePropertyChanged("MasterEntityTemp");
                    value.BeginEdit();
                }
            }
        }

        MultipleContext_MM_T004 _MC = new MultipleContext_MM_T004();
        public MultipleContext_MM_T004 MC
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

        //MultipleContext_MM_T004 _MCTemp = new MultipleContext_MM_T004();
        //public MultipleContext_MM_T004 MCTemp
        //{
        //    get { return _MCTemp; }
        //    set
        //    {
        //        if (_MCTemp != value)
        //        {
        //            _MCTemp = value;

        //            RaisePropertyChanged("MCTemp");
        //        }
        //    }
        //}

        private List<MM_T004Flip> _FlipGridData;
        public List<MM_T004Flip> FlipGridData
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

        private string _LocalVariable;
        public string LocalVariable
        {
            get
            {
                return _LocalVariable;
            }
            set
            {
                if (_LocalVariable != value)
                {
                    _LocalVariable = value;
                    RaisePropertyChanged("LocalVariable");
                }
            }
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
        private DateTime _FromDate;
        public DateTime FromDate
        {
            get { return _FromDate; }
            set
            {
                if (_FromDate != value)
                {
                    _FromDate = value;
                    RaisePropertyChanged("FromDate");
                }
            }
        }

        private DateTime _ToDate;
        public DateTime ToDate
        {
            get { return _ToDate; }
            set
            {
                if (_ToDate != value)
                {
                    _ToDate = value;
                    RaisePropertyChanged("ToDate");
                }
            }
        }
        #endregion

        #region ICollection
        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private ICollectionView _partyCollection;
        public ICollectionView PartyCollection
        {
            get { return _partyCollection; }
            set { _partyCollection = value; RaisePropertyChanged("PartyCollection"); }
        }
        private ICollectionView _empCollection;
        public ICollectionView EmpCollection
        {
            get { return _empCollection; }
            set { _empCollection = value; RaisePropertyChanged("EmpCollection"); }
        }
        private ICollectionView _uomCollection;
        public ICollectionView UomCollection
        {
            get { return _uomCollection; }
            set { _uomCollection = value; RaisePropertyChanged("UomCollection"); }
        }
        private ICollectionView _departmentCollection;
        public ICollectionView DepartmentCollection
        {
            get { return _departmentCollection; }
            set { _departmentCollection = value; RaisePropertyChanged("DepartmentCollection"); }
        }
        private ICollectionView _ItemsCollection;
        public ICollectionView ItemsCollection
        {
            get { return _ItemsCollection; }
            set { _ItemsCollection = value; RaisePropertyChanged("ItemsCollection"); }
        }
        private ICollectionView _ContactInfoCollection;
        public ICollectionView ContactInfoCollection
        {
            get { return _ContactInfoCollection; }
            set { _ContactInfoCollection = value; RaisePropertyChanged("ContactInfoCollection"); }
        }
        private ICollectionView _transporterCollection;
        public ICollectionView TransporterCollection
        {
            get { return _transporterCollection; }
            set { _transporterCollection = value; RaisePropertyChanged("TransporterCollection"); }
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

        List<string> _strListEmployee;
        public List<string> StringListEmployee
        {
            get { return _strListEmployee; }
            set
            {
                if (_strListEmployee != value)
                {
                    _strListEmployee = value;
                }
            }
        }

        List<string> _stringListUOM;
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

        List<string> _strListDept;
        public List<string> StringListDept
        {
            get { return _strListDept; }
            set
            {
                if (_strListDept != value)
                {
                    _strListDept = value;
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

        List<string> _stringListContactInfo;
        public List<string> StringListContactInfo
        {
            get { return _stringListContactInfo; }
            set
            {
                if (_stringListContactInfo != value)
                { _stringListContactInfo = value; }
            }
        }

        private List<string> _srtListTransporter;
        public List<string> StringListTransporter
        {
            get { return _srtListTransporter; }
            set
            {
                if (_srtListTransporter != value)
                {
                    _srtListTransporter = value;
                }
            }
        }
        #endregion

        #region Relay Commands Declaration
        public RelayCommand CommandLoadDocumentFromSource { get; private set; }
        public RelayCommand<object> CommandPartyChanged { get; private set; }
        public RelayCommand<object> CommandEmployeeChanged { get; private set; }
        public RelayCommand<object> CommandAddUOM { get; private set; }
        public RelayCommand<object> CommandDepartmentChanged { get; private set; }
        public RelayCommand<object> CommandItemsChanged { get; private set; }
        public RelayCommand<object> CommandContactInfo { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> CommandTransporter { get; private set; }
        public RelayCommand<object> CommandAddRequester { get; private set; }
        public RelayCommand cmdLoadRecords { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region Constructor
        // private static MM_T004_VM Expose_ViewModel;
        public MM_T004_IO_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new MM_T004();
            FlipGridData = new List<MM_T004Flip>();
            MC = new MultipleContext_MM_T004();
         
            FromDate = DateTime.Now;
            ToDate = DateTime.Now;
            MasterEntity.ValidateAsync().Wait();
            MM_T004.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);

            
            LoadInitialData();
            //if (AppSessionState.DocumentType == MasterEntity.doc_type)
            //{
            //    //LoadDocumentByDocumentNumber(AppSessionState.DocumentNo.ToString(), "DocumentNumber");
            //}

        }
        public MM_T004_IO_VM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new MM_T004();
            FlipGridData = new List<MM_T004Flip>();
            MC = new MultipleContext_MM_T004();

            FromDate = DateTime.Now;
            ToDate = DateTime.Now;
            MasterEntity.ValidateAsync().Wait();
            MM_T004.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);


            LoadInitialData();
            

        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + "IW,OW";//+ "!@" + MasterEntity.doc_cat;
                //if (MasterEntity.doc_type == "IW" || MasterEntity.doc_type == "OW")
                //{
                //    string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + "IW,OW" + "!@" + MasterEntity.doc_cat;
                //}
                //else
                //{
                //    string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat;
                //}
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MM_T004>(MC, Request, "InwardOutward", "SCM", "LoadAll", 0, "");

                #region Command Initialisation
                //CommandLoadDocumentFromSource = new RelayCommand(() => LoadSourceDocument());
                CommandPartyChanged = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items); });
                CommandEmployeeChanged = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmployee(items); });
                CommandAddUOM = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_UOM(cmdPara, false, true, true); });
                CommandDepartmentChanged = new RelayCommand<object>(items => { if (items == null) { return; } InsertDeptment(items); });
                CommandItemsChanged = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
                CommandContactInfo = new RelayCommand<object>(items => { if (items == null) { return; } InsertContactPerson(items); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CommandTransporter = new RelayCommand<object>(items => { if (items == null) { return; } InsertTransporter(items, true); });
                CommandAddRequester = new RelayCommand<object>(items => { if (items == null) { return; } InsertRequester(items); });
                cmdLoadRecords = new RelayCommand(() => { LoadRecords(); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion
                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                PartyCollection = CollectionViewSource.GetDefaultView(MC.partyList);
                PartyCollection.Filter = new Predicate<object>(FilterParty);
                StringListParty = MC.partyList.Select(x => x.PartyNm).ToList();

                EmpCollection = CollectionViewSource.GetDefaultView(MC.EmpList.ToList());
                EmpCollection.Filter = new Predicate<object>(FilterEmployee);
                StringListEmployee = MC.EmpList.Select(x => x.EmpLName).ToList();

                UomCollection = CollectionViewSource.GetDefaultView(MC.unitList.ToList());
                UomCollection.Filter = new Predicate<object>(FilterUom);
                StringListUOM = MC.unitList.Select(x => x.unit_code).ToList();

                DepartmentCollection = CollectionViewSource.GetDefaultView(MC.deptList.ToList());
                DepartmentCollection.Filter = new Predicate<object>(FilterDept);
                StringListDept = MC.deptList.Select(x => x.dept_code).ToList();

                ItemsCollection = CollectionViewSource.GetDefaultView(MC.ItemList.ToList());
                ItemsCollection.Filter = new Predicate<object>(FilterItems);
                StringListItems = MC.ItemList.Select(x => x.ItemName).ToList();

                TransporterCollection = CollectionViewSource.GetDefaultView(MC.Transporters);
                TransporterCollection.Filter = new Predicate<object>(Filter_Transporter);
                StringListTransporter = MC.Transporters.Select(x => x.PartyNm).ToList();

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
        #endregion

        #region User Defined Functions
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
           
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.t_status = "001";
            MasterEntity.doc_no = "";
            MasterEntity.entry_date = DateTime.Now;
            MasterEntity.client = AppSessionState.client;
            //MasterEntity.user_source1 = AppSessionState.UserSource1;
            //MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
        }
        #endregion

        #region Validation
        private bool Validation()
        {
            try
            {
                if (MasterEntity.doc_type == null || MasterEntity.doc_type == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("please Select Order Type........");
                    showMessageService.ShowMessage();
                    return false;
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
            return true;
        }
        #endregion
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            LocalVariable = MasterEntity.PartyId;
            this.ErrorExist = MasterEntity.HasErrors;
        }
       
        #region Command Handler
        private void InsertParty(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.partyList.Where(x => x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch { MasterEntity.PartyNm = InputValue.ToString(); }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.PartyId = POPUPEntityObject.PartyId;
                    MasterEntity.PartyNm = POPUPEntityObject.PartyNm;
                    MasterEntity.issued_to_nm = POPUPEntityObject.PersonName;
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
        private void InsertEmployee(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M024_P POPUPEntityObject = null;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.EmpList.Where(x => x.EmpLName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch
                        { MasterEntity.EmpNm = InputValue.ToString(); }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M024_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.EmpId = POPUPEntityObject.EmpId;
                    MasterEntity.EmpNm = POPUPEntityObject.EmpLName;
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
        private void Insert_UOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try { POPUPEntityObject = MC.unitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch { MasterEntity.unit_code = InputValue.ToString(); }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.unit_code = POPUPEntityObject.unit_code;
                    //MasterEntity.unit_name = POPUPEntityObject.unit_name;
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
        private void InsertDeptment(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M025_P POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try { POPUPEntityObject = MC.deptList.Where(x => x.DeptName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch { MasterEntity.dept_Nm = InputValue.ToString(); }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M025_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M025_P>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.dept_code = POPUPEntityObject.dept_code;
                    MasterEntity.dept_Nm = POPUPEntityObject.DeptName;
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
        private void InsertItem(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M022_P POPUPEntityObject = null;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ItemList.Where(x => x.ItemName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { MasterEntity.ItemName = InputValue.ToString(); }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M022_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                    MasterEntity.ItemName = POPUPEntityObject.ItemName;
                    MasterEntity.unit_code = POPUPEntityObject.unit_code;
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
        private void InsertContactPerson(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M028_C_P POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.contactInfoMaster.Where(x => x.ContInfoId.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { MasterEntity.issued_by_nm = InputValue.ToString(); }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M028_C_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_C_P>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ContInfoId = POPUPEntityObject.ContInfoId;
                    MasterEntity.issued_by_nm = POPUPEntityObject.PersonName;
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
        private void InsertTransporter(object InputValue, bool OverrideValue)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Transporters.Where(x => x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { MasterEntity.service_provider_nm = InputValue.ToString(); }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }

                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.service_provider_id = POPUPEntityObject.PartyId;
                    MasterEntity.service_provider_nm = POPUPEntityObject.PartyNm;
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
        private void InsertRequester(object InputValue)
        {
            string Request = "";
            ADM_M024_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.EmpList.Where(x => x.EmpLName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        { MasterEntity.prepared_by_nm = InputValue.ToString(); }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M024_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.prepared_by = POPUPEntityObject.EmpId;
                    MasterEntity.prepared_by_nm = POPUPEntityObject.EmpLName;
                }
            }
            catch (Exception ex) { }
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                string ParametersStringValue = "";
                MM_T004Flip ParameterEntityObject = null;
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    if (ParameterReference == "DocumentNumber")
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
                    if (((IEnumerable)ParameterObject).Cast<MM_T004Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<MM_T004Flip>().ToList()[0];
                        Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + AppSessionState.client + "!@" + ParameterEntityObject.comp_code + "!@" + ParameterEntityObject.location_id + "!@" + ParameterEntityObject.trans_mode + "!@" + ParameterEntityObject.vehicle_no + "!@" + ParameterEntityObject.doc_no;
                        NewRecord = false;
                        string RequestParameterData = "LoadDocumentWithReferenceDocumentNumber" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + "" + "!@" + "" + "!@" + MasterEntity.location_Id;
                    }
                }
                MasterEntity = new MM_T004();
                MasterEntity = repository.GetDataWithReturnDomainObject<MM_T004>(MasterEntity, Request, "InwardOutward", "SCM", "LoadDocumentWithReferenceDocumentNumber", 0, "");
                SetBusinessEntitiesAfterLoad(ParametersStringValue, "");
                SelectedTabControlIndex = 0;
                MasterEntity.ts_code = ts_code_vm;
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
        private void LoadRecords()
        {
            try
            {
                if (FromDate == null || ToDate == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select From Date And To Date Before Loading");
                    showMessageService.ShowMessage();
                }
                else
                {
                    string Request = "LoadRecordsofSelectedDate" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + Convert.ToDateTime(FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(ToDate).ToString("MM/dd/yyyy");
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MM_T004>(MCTemp, Request, "InwardOutward", "SCM", "LoadRecordsofSelectedDate", 0, "");

                    FlipGridData = MCTemp.DocumentDataFlipGrid;
                    DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                    DataGridCollection.Refresh();

                }
            }
            catch
            {

            }
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
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
                    Request = MasterEntity.client + "!@" + MasterEntity.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region Abstract Command Actions 
        protected override void OnCreateAction(InquiryActionResult<MM_T004> result)
        {
            NewRecord = true;
            MasterEntity = new MM_T004();
            
            DefaultValues();
        }
        protected override void OnDiscardAction(InquiryActionResult<MM_T004> result)
        {            
        }
        protected override void OnFevoriteAction(InquiryActionResult<MM_T004> result)
        {           
        }
        protected override void OnFlipAction(InquiryActionResult<MM_T004> result)
        {           
        }
        protected override void OnHelpAction(InquiryActionResult<MM_T004> result)
        {           
        }
        protected override void OnPrintAction(InquiryActionResult<MM_T004> result)
        {
            try
            {
                if (MasterEntity.doc_no != null && MasterEntity.doc_no != " ")
                {
                    string Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + MasterEntity.doc_no;
                    MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MM_T004>(MC, Request, "InwardOutward", "SCM", "", 0, "LoadDocumentWithReferenceDocumentNumber");


                    object[] objDataSource = new object[3];
                    string[] objDataSourceName = new string[3];


                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[0] = Result;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[1] = CmpResult;
                    List<MM_T004> obj = new List<MM_T004>();
                    obj.Add(MasterEntity);
                    objDataSource[2] = obj;




                    objDataSourceName[0] = "dsLocation";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsMM_T004";



                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\SCM\\inward_outward.rdlc", "");

                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Select Document  No.....", this.Title);
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
        protected override void OnRemoveAction(InquiryActionResult<MM_T004> result)
        {
            try
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
                    string response = repository.Delete(MasterEntity.doc_no, "InwardOutward", "SCM");
                    //FlipGridData.Remove(MasterEntity); Temp
                    MasterEntity = new MM_T004();
                    NewRecord = true;

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
        protected override void OnSaveAction(InquiryActionResult<MM_T004> result)
        {
            try
            {
                if (MasterEntity.doc_type == "IW")
                {
                    MasterEntity.doc_cat = "IW";
                }
                else if (MasterEntity.doc_type == "OW")
                {
                    MasterEntity.doc_cat = "OW";
                }
                if (Validation() == true)
                {
                    MasterEntity.client = AppSessionState.client;
                    this.MasterEntity.EndEdit();
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<MM_T004>(MasterEntity, "InwardOutward", "SCM");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<MM_T004>(MasterEntity, "InwardOutward", "SCM");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    
                    if (MasterEntity.doc_no != null || MasterEntity.doc_no != "" || NewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();
                    }
                    else if (MasterEntity.doc_no != null || MasterEntity.doc_no != "" || NewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Updated Successfully");
                        showMessageService.ShowMessage();
                    }
                    NewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 

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
        protected override void OnDocumentAction()
        {
        }
        protected override void OnRefreshCommand(InquiryActionResult<MM_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MM_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MM_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MM_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MM_T004> result)
        {
            throw new NotImplementedException();
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                MasterEntity.ts_code = ts_code_vm;
                if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<MM_T004Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                    DataGridCollection.Refresh();
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
                FilterCollection();
            }
        }
        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as MM_T004Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return
                        (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()) ||
                        data.entry_date != null && data.entry_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()) ||
                        data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()) ||
                        data.EmpNm != null && data.EmpNm.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()) ||
                        data.del_note_no != null && data.del_note_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()) ||
                        data.del_note_date != null && data.del_note_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()) ||
                        data.pod_no != null && data.pod_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()) ||
                        data.posting_date != null && data.posting_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()) ||
                        data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()) ||
                        data.location != null && data.location.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()) ||
                        data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()) ||
                        data.trans_mode != null && data.trans_mode.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()) ||
                        data.prepared_by_nm != null && data.prepared_by_nm.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()) ||
                        data.lrno != null && data.lrno.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()) ||
                        data.date_of_receipt != null && data.date_of_receipt.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }
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
            if (_partyCollection != null)
            {
                _partyCollection.Refresh();
            }
        }
        public bool FilterParty(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_party))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_party.ToLower()) ||
                        data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_party.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_Emp;
        public string FilterString_Emp
        {
            get { return _filterString_Emp; }
            set
            {
                _filterString_Emp = value;
                RaisePropertyChanged("FilterString_Emp");
                FilterCollectionEmp();
            }
        }
        private void FilterCollectionEmp()
        {
            if (_empCollection != null)
            {
                _empCollection.Refresh();
            }
        }
        public bool FilterEmployee(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Emp))
                {
                    return (data.EmpLName != null && data.EmpLName.ToString().ToLower().Contains(_filterString_Emp.ToLower()) ||
                         data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterString_Emp.ToLower())
                        );
                }
                return true;
            }
            return false;
        }
        private string _filterString_uom;
        public string FilterString_uom
        {
            get { return _filterString_uom; }
            set
            {
                _filterString_uom = value;
                RaisePropertyChanged("FilterString_uom");
                FilterCollectionuom();
            }
        }
        private void FilterCollectionuom()
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
                if (!string.IsNullOrEmpty(_filterString_uom))
                {
                    return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterString_uom.ToLower()));
                }
                return true;
            }
            return false;
        }
        private string _filterStringDepartment;
        private void FilterCollectionDepartment()
        {
            if (_departmentCollection != null)
            {
                _departmentCollection.Refresh();
            }
        }
        public string FilterStringDepartment
        {
            get { return _filterStringDepartment; }
            set
            {
                _filterStringDepartment = value;
                RaisePropertyChanged("FilterStringDepartment");
                FilterCollectionDepartment();
            }
        }
        public bool FilterDept(object obj)
        {
            var data = obj as ADM_M025_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringDepartment))
                {
                    return (data.DeptName != null && data.DeptName.ToString().ToLower().Contains(_filterStringDepartment.ToLower()) ||
                            data.dept_code != null && data.dept_code.ToString().ToLower().Contains(_filterStringDepartment.ToLower()));

                }
                return true;
            }
            return false;
        }

        private string _filterStringItem;
        private void FilterCollectionItem()
        {
            if (_ItemsCollection != null)
            {
                _ItemsCollection.Refresh();
            }
        }
        public string FilterStringItem
        {
            get { return _filterStringItem; }
            set
            {
                _filterStringItem = value;
                RaisePropertyChanged("FilterStringItem");
                FilterCollectionItem();
            }
        }
        public bool FilterItems(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringItem))
                {
                    return (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterStringItem.ToLower())) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringItem.ToLower()));

                }
                return true;
            }
            return false;
        }
        private string _filterString_Contact;

        private void FilterCollection_Contact()
        {
            if (_ContactInfoCollection != null)
            {
                _ContactInfoCollection.Refresh();
            }
        }
        public string FilterString_Contact
        {
            get { return _filterString_Contact; }
            set
            {
                _filterString_Contact = value;
                RaisePropertyChanged("FilterString_Contact");
                FilterCollection_Contact();
            }
        }
        public bool Filter_Contact(object obj)
        {
            var data = obj as ADM_M028_C_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Contact))
                {
                    return (data.ContInfoId != null && data.ContInfoId.ToString().ToLower().Contains(_filterString_Contact.ToLower())) ||
                           (data.PersonName != null && data.PersonName.ToString().ToLower().Contains(_filterString_Contact.ToLower()));


                }
                return true;
            }
            return false;
        }
        private string _filterString_Transporter;
        public string FilterString_Transporter
        {
            get { return _filterString_Transporter; }
            set
            {
                _filterString_Transporter = value;
                RaisePropertyChanged("FilterString_Transporter");
                FilterCollection_Transporter();
            }
        }
        private void FilterCollection_Transporter()
        {
            if (_transporterCollection != null)
            {
                _transporterCollection.Refresh();
            }
        }
        public bool Filter_Transporter(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Transporter))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_Transporter.ToLower()) ||
                        data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_Transporter.ToLower()));
                }
                return true;
            }
            return false;
        }

       
        #endregion
    }
}
