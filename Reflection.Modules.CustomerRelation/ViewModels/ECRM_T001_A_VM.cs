using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using Reflection.Presentation.Common;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class ECRM_T001_A_VM : WorkspaceViewModel<ECRM_T001_A>
    {
        #region Variable Declaration And Object 
        bool NewRecord = true;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        WebServiceRepository<ECRM_T001_A> repository = new WebServiceRepository<ECRM_T001_A>();
        WebServiceRepository<MultipleContext_ECRM_T001_A> repository_MC = new WebServiceRepository<MultipleContext_ECRM_T001_A>();
        WebServiceRepository<MultipleContext_ECRM_T001_A> repository_MCTemp = new WebServiceRepository<MultipleContext_ECRM_T001_A>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_ECRM_T001_A _MC = new MultipleContext_ECRM_T001_A();
        public MultipleContext_ECRM_T001_A MC
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

        private MultipleContext_ECRM_T001_A _MCTemp = new MultipleContext_ECRM_T001_A();
        public MultipleContext_ECRM_T001_A MCTemp
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

        private ECRM_T001_A _MasterEntity;
        public ECRM_T001_A MasterEntity
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

        private ECRM_T001_A _MasterEntityTemp;
        public ECRM_T001_A MasterEntityTemp
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

        private ObservableCollection<ECRM_T001_B> _ItemsEntity;
        //Data source for Items DataGrid
        public ObservableCollection<ECRM_T001_B> ItemsEntity
        {
            get
            {
                return _ItemsEntity;
            }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value;
                    // ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("ItemsEntity");
                }
            }
        }
        private List<SalesInvoice_SingleReport> _RptSampleAnalysis;
        public List<SalesInvoice_SingleReport> RptSampleAnalysis
        {
            get { return _RptSampleAnalysis; }
            set
            {
                if (_RptSampleAnalysis != value)
                {
                    _RptSampleAnalysis = value;
                    RaisePropertyChanged("RptSampleAnalysis");
                }
            }
        }
        private int _dgSelectedIndex;
        public int dgSelectedIndex
        {
            get
            {
                return _dgSelectedIndex;
            }
            set
            {
                if (_dgSelectedIndex != value)
                {
                    _dgSelectedIndex = value;
                    RaisePropertyChanged("dgSelectedIndex");

                }
            }
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

        private int _selectedTabControlIndex; // Added by madhuri
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

        private ObservableCollection<SalesInvoice_SingleReport> _dgReportMaster;
        public ObservableCollection<SalesInvoice_SingleReport> dgReportMaster
        {
            get { return _dgReportMaster; }
            set
            {
                if (_dgReportMaster != value)
                {
                    _dgReportMaster = value;


                    RaisePropertyChanged("dgReportMaster");

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
        private SearchEntity _SearchEntityObject;
        public SearchEntity SearchEntityObject
        {
            get
            {
                return _SearchEntityObject;
            }
            set
            {
                if (_SearchEntityObject != value)
                {
                    _SearchEntityObject = value;
                    RaisePropertyChanged(nameof(SearchEntityObject));
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
        private ICollectionView _plantCollection;
        public ICollectionView PlantCollection
        {
            get { return _plantCollection; }
            set { _plantCollection = value; RaisePropertyChanged("PlantCollection"); }
        }
        private ICollectionView _uomCollection;
        public ICollectionView UomCollection
        {
            get { return _uomCollection; }
            set { _uomCollection = value; RaisePropertyChanged("UomCollection"); }
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

        private ICollectionView _SampleFrom_Collection;
        public ICollectionView SampleFrom_Collection
        {
            get { return _SampleFrom_Collection; }
            set
            {
                _SampleFrom_Collection = value;
                RaisePropertyChanged("SampleFrom_Collection");
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
        private List<ECRM_T001_A_Flip> _FlipGridData;
        public List<ECRM_T001_A_Flip> FlipGridData
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
        public List<string> _stringListPlant;
        public List<string> StringListPlant
        {
            get
            {
                return _stringListPlant;
            }
            set
            {
                _stringListPlant = value;
                RaisePropertyChanged("StringListPlant");
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

        private List<string> _strListSampleFrom;
        public List<string> StringListSampleFrom
        {
            get { return _strListSampleFrom; }
            set
            {
                if (_strListSampleFrom != value)
                {
                    _strListSampleFrom = value;
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
        public List<ADM_M003> _Objplant = new List<ADM_M003>();
        private List<ADM_M003> Objplant
        {
            get { return _Objplant; }
            set
            {
                if (_Objplant != value)
                {
                    _Objplant = value;
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

        public List<ADM_M028_P> _SampleFromList;
        public List<ADM_M028_P> SampleFromList
        {
            get
            {
                return _SampleFromList;
            }
            set
            {
                _SampleFromList = value;
                RaisePropertyChanged("SampleFromList");
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

        #region Methods

        private void ModelUpdated_Item(object sender, EventArgs e)
        {
            LocalVariable = MasterEntity.location_Id;
            this.ErrorExist = MasterEntity.HasErrors;
        }

        private void ModelUpdated_Master(object sender, EventArgs e)
        {
            LocalVariable = MasterEntity.location_Id;
            this.ErrorExist = MasterEntity.HasErrors;
        }

        #endregion

        #region RelayCommand
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand CommandLoadDocumentFromSource { get; private set; }
        public RelayCommand<object> CommandPlantChanged { get; private set; }
        public RelayCommand<object> CommandAddUOM { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> CommandItem { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CommandSalseOrg { get; private set; }
        public RelayCommand<object> CommandSalseGroup { get; private set; }
        public RelayCommand<object> CommandSampleFrom { get; private set; }
        public RelayCommand<object> CommandLoadBackFlipData { get; private set; }
        #endregion

        #region Constructor
        public ECRM_T001_A_VM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            SearchEntityObject = new SearchEntity();
            MasterEntityTemp = new ECRM_T001_A();
            MasterEntity = new ECRM_T001_A();
            ItemsEntity = new ObservableCollection<ECRM_T001_B>();
            FlipGridData = new List<ECRM_T001_A_Flip>();
            MC = new MultipleContext_ECRM_T001_A();
            MCTemp = new MultipleContext_ECRM_T001_A();
            MasterEntity.ValidateAsync().Wait();
            ECRM_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            ECRM_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            //ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);

            LoadInitialData();
        }
        public ECRM_T001_A_VM(string ts_code, string doc_no)
            : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            SearchEntityObject = new SearchEntity();
            MasterEntityTemp = new ECRM_T001_A();
            MasterEntity = new ECRM_T001_A();
            ItemsEntity = new ObservableCollection<ECRM_T001_B>();
            FlipGridData = new List<ECRM_T001_A_Flip>();
            MC = new MultipleContext_ECRM_T001_A();
            MCTemp = new MultipleContext_ECRM_T001_A();
            MasterEntity.ValidateAsync().Wait();
            ECRM_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            ECRM_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            //ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);

            LoadInitialData();
        }
        private void LoadInitialData()
        {
            try
            {
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CommandPlantChanged = new RelayCommand<object>(items => { if (items == null) { return; } Insert_Plant(items); });
                CommandAddUOM = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_Unit(cmdPara, false, true, true); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CommandDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
                //CommandItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara, true, true, true); });
                CommandSalseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseOrg(items); });
                CommandSalseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseGroup(items); });
                CommandSampleFrom = new RelayCommand<object>(items => { if (items == null) { return; } InsertSampleFrom(items); });
                CommandLoadBackFlipData = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items); });

                MasterEntity.doc_cat = "SA";
                MasterEntity.doc_type = "SA";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.EmpId;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ECRM_T001_A>(MC, Request, "Sample_Analysis", "CRM", "LoadAll", 0, "");

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                UomCollection = CollectionViewSource.GetDefaultView(MC.UnitList.ToList());
                UomCollection.Filter = new Predicate<object>(FilterUnit);
                StringListUOM = MC.UnitList.Select(x => x.unit_code).ToList();

                SampleFrom_Collection = CollectionViewSource.GetDefaultView(MC.SampleFrmList.ToList());
                SampleFrom_Collection.Filter = new Predicate<object>(Filter_SampleFrom);
                StringListSampleFrom = MC.SampleFrmList.Select(x => x.PartyNm).ToList();

                SalesOrganisationList = (List<ADM_M001_A_P>)AppSessionState.ADM_M001_A_List;
                Salse_OrgCollection = CollectionViewSource.GetDefaultView(SalesOrganisationList);
                Salse_OrgCollection.Filter = new Predicate<object>(Filter_SalesOrg);
                StringListSalesOrg = SalesOrganisationList.Select(x => x.so_code).ToList();
                if (SalesOrganisationList.Count != 0)
                {
                    if (SalesOrganisationList.Count == 1)
                    {
                        MasterEntity.so_code = SalesOrganisationList[0].so_code;
                        MasterEntity.sales_org = SalesOrganisationList[0].sales_org;
                    }
                }
                else
                {
                    MasterEntity.so_code = "";
                }
                SalesGroupList = (List<ADM_M001_H_P>)AppSessionState.ADM_M001_H_List;
                Salse_GroupCollection = CollectionViewSource.GetDefaultView(SalesGroupList);
                Salse_GroupCollection.Filter = new Predicate<object>(Filter_SalesGroup);
                StringListSalesGroup = SalesGroupList.Select(x => x.sg_code).ToList();

                if (SalesGroupList.Count != 0)
                {
                    if (SalesGroupList.Count == 1)
                    {
                        MasterEntity.sg_code = SalesGroupList[0].sg_code;
                        MasterEntity.sg_name = SalesGroupList[0].sg_name;
                    }
                }
                else
                {
                    MasterEntity.sg_code = "";
                }

                Objplant = (List<ADM_M003>)AppSessionState.ADM_M003_List;

                PlantCollection = CollectionViewSource.GetDefaultView(Objplant.ToList());
                PlantCollection.Filter = new Predicate<object>(FilterPlant);
                StringListPlant = Objplant.Select(x => x.location_Id).ToList();

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

        #region validation
        private bool Validation()
        {

            try
            {
                if (MasterEntity.sample_to_plant == null || MasterEntity.sample_to_plant == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Sample Analysis To Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.trans_type == null || MasterEntity.trans_type == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("please select Transaction Type ....", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.copy == true)
                {
                    NewRecord = true;
                }
                if (ItemsEntity.Count < 1)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("please select Item ........");
                    showMessageService.ShowMessage();
                    return false;
                }

                if (dgSelectedIndex != -1)
                {
                    if (ItemsEntity[dgSelectedIndex].unit_code == null || ItemsEntity[dgSelectedIndex].unit_code == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Slelect Unit");
                        showMessageService.ShowMessage();
                        return false;

                    }

                    if (ItemsEntity[dgSelectedIndex].description == null || ItemsEntity[dgSelectedIndex].description == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Slelect Item Description..");
                        showMessageService.ShowMessage();
                        return false;

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

            return true;
        }
        #endregion

        #region Pending for set default values for Item
        //private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        //{
        //    if (e.Action == NotifyCollectionChangedAction.Add)
        //    {
        //        foreach (ECRM_T001_B item in e.NewItems)
        //        {
        //            //Added items

        //        }
        //        if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
        //        {
        //            this.ErrorExist = ItemsEntity[dgSelectedIndex].HasErrors;
        //            ItemsEntity[dgSelectedIndex].location_Id = AppSessionState.location_Id;
        //            ItemsEntity[dgSelectedIndex].comp_code = AppSessionState.comp_code;
        //            ItemsEntity[dgSelectedIndex].add_by = AppSessionState.UserID;
        //            ItemsEntity[dgSelectedIndex].fin_year = "15-16";
        //            ItemsEntity[dgSelectedIndex].posting_period = "10";
        //        }
        //    }

        //}
        #endregion

        #region User Defined Functions
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_cat = "SA";
            MasterEntity.doc_type = "SA";
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.sa_no = "";
            MasterEntity.sa_date = DateTime.Now;
            MasterEntity.t_status = "001";
            MasterEntity.client = AppSessionState.client;

            SearchEntityObject.from_date = DateTime.Now.Date;
            SearchEntityObject.to_date = DateTime.Now.Date;
            SearchEntityObject.active = true;
        }
        #endregion

        #region Relay Command Actions ·
        private void Insert_Plant(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;       
            
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = Objplant.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                }
           
            if (POPUPEntityObject != null)
            {
                MasterEntity.sample_to_plant = POPUPEntityObject.location_Id;
                MasterEntity.Plant_Name = POPUPEntityObject.LoctnNm;
                    MasterEntity.location_Id = POPUPEntityObject.location_Id;
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
        private void Insert_Unit(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                       
                        POPUPEntityObject = MC.UnitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; 
                      
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }
            
               if (POPUPEntityObject != null)
               {
                    ItemsEntity[dgSelectedIndex].active = true;
                    ItemsEntity[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                    ItemsEntity[dgSelectedIndex].location_Id = AppSessionState.location_Id;
                    ItemsEntity[dgSelectedIndex].comp_code = AppSessionState.comp_code;
                    ItemsEntity[dgSelectedIndex].add_by = AppSessionState.UserID;
              
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
        private void InsertSalseGroup(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M001_H_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SalesGroup.Where(x => x.sg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_H_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.sg_code = POPUPEntityObject.sg_code;
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
        private void InsertSalseOrg(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M001_A_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SalesOrg.Where(x => x.so_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_A_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.so_code = POPUPEntityObject.so_code;
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

        private void InsertSampleFrom(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SampleFrmList.Where(x => x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                if (POPUPEntityObject != null)
                {
                    MasterEntity.sample_frm = POPUPEntityObject.PartyNm;
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
                ECRM_T001_A_Flip ParameterEntityObject = null;
                MasterEntity = new ECRM_T001_A();
                ItemsEntity = new ObservableCollection<ECRM_T001_B>();

             
                    if (((IEnumerable)ParameterObject).Cast<ECRM_T001_A_Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ECRM_T001_A_Flip>().ToList()[0];
                        Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + ParameterEntityObject.sa_no;
                        NewRecord = false;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ECRM_T001_A>(MCTemp, Request, "Sample_Analysis", "CRM", "", 0, Request);
                        MasterEntity = MCTemp.MasterDetails[0];
                        ItemsEntity = MCTemp.ItemsDetails;
                    }
                SelectedTabControlIndex = 0;
                MasterEntity.ts_code = ts_code_vm;
                //SetBusinessEntitiesAfterLoad(ParametersStringValue, "");
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

        private void LoadBackFlipData(object Parameter)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id  + "!@" + Convert.ToDateTime(SearchEntityObject.from_date).ToString() + "!@" + Convert.ToDateTime(SearchEntityObject.to_date).ToString() + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + AppSessionState.EmpId + "!@" + SearchEntityObject.active;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ECRM_T001_A>(MCTemp, Request, "Sample_Analysis", "CRM", "LoadAll", 0, "");

                FlipGridData = MCTemp.DocumentDataFlipGrid.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                
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

        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i)
                {
                    ItemsEntity.RemoveAt(i);
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

        #region Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<ECRM_T001_A> result)
        {
            try
            { 
            if (Validation() == true)
            {
                //DefaultValues();
                MasterEntity.XmlDataDocument_ECRM_T001_B = obj.ObjectToXML(ItemsEntity);

                this.MasterEntity.EndEdit();
                if (NewRecord == true)
                {
                    MasterEntity = repository.SaveWithReturnDomainObject<ECRM_T001_A>(MasterEntity, "Sample_Analysis", "CRM");
                }
                else if (NewRecord == false)
                {
                    MasterEntity = repository.UpdateWithReturnDomainObject<ECRM_T001_A>(MasterEntity, "Sample_Analysis", "CRM");

                }
                SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.sa_no != null || MasterEntity.sa_no != "" && MasterEntity.active == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record saved Successfully ........");
                        showMessageService.ShowMessage();
                    }
                    NewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
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
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                
                if (MasterEntity.XmlDataDocument_ECRM_T001_B != null)
                {
                    MC.ItemsDetails = (ObservableCollection<ECRM_T001_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ECRM_T001_B, MC.ItemsDetails);
                    ItemsEntity = MC.ItemsDetails;
                }
                else
                {
                    MC.ItemsDetails = new ObservableCollection<ECRM_T001_B>();
                    ItemsEntity.Clear();
                }
                if (MasterEntity.XmlDataDocument_ECRM_T001_A_Flip != null && NewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<ECRM_T001_A_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ECRM_T001_A_Flip, MC.DocumentDataFlipGrid);
                    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                    DataGridCollection.Refresh();
                    DataGridCollection.SortDescriptions.Add(new SortDescription("doc_no", ListSortDirection.Descending));
                }
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
        protected override void OnCreateAction(InquiryActionResult<ECRM_T001_A> result)
        {

            NewRecord = true;
            MasterEntity = new ECRM_T001_A();
            MasterEntity.ValidateAsync().Wait();
            ItemsEntity = new ObservableCollection<ECRM_T001_B>();
            ItemsEntity.Clear();
            DefaultValues();


        }
        protected override void OnRemoveAction(InquiryActionResult<ECRM_T001_A> result)
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
                    string response = repository.Delete(MasterEntity.sa_no, "Sample_Analysis", "CRM");
                    MasterEntity = new ECRM_T001_A();
                    ItemsEntity = new ObservableCollection<ECRM_T001_B>();
                    _dataGridCollection.Refresh();
                    NewRecord = true;

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
        protected override void OnDiscardAction(InquiryActionResult<ECRM_T001_A> result)
        {
            MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ECRM_T001_A> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ECRM_T001_A> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ECRM_T001_A> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ECRM_T001_A> result)
        {
            try
            {
                string ReportName = "";
                if (MasterEntity.sa_no != null && MasterEntity.sa_no != " ")
                {
                  string Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + MasterEntity.sa_no;
                  MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ECRM_T001_A>(MCTemp, Request, "Sample_Analysis", "CRM", "", 0, Request);
                    

                    object[] objDataSource = new object[4];
                    string[] objDataSourceName = new string[4];

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[0] = Result;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    objDataSource[2] = MCTemp.MasterDetails;
                    objDataSource[3] = MCTemp.ItemsDetails;

                    objDataSourceName[0] = "dsLocation";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsSampleAnalysisMaster";
                    objDataSourceName[3] = "dsSampleAnalysisItem";

                    ReportManager ReportManager = new ReportManager();

                    var ReportStringList = (from o in MC.DocumentTypes where o.doc_type == MasterEntity.doc_type select o).ToList();
                    //if (MasterEntity.doc_type == "SA")
                    //{
                    if (MasterEntity.trans_type == "Local")
                    {
                        ReportName = ReportStringList[0].report_name.Split(',')[1];
                    }
                    else if (MasterEntity.trans_type == "Export")
                    {
                        ReportName = ReportStringList[0].report_name.Split(',')[0];
                    }
                    //}

                    string ReportDisplayName = MasterEntity.sample_frm + "_" + MasterEntity.sa_no + "_" + MasterEntity.sa_date.Value.ToShortDateString();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\" + ReportName, getParametersList(), ReportDisplayName);

                }
                else 
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Select Sample Analysis No.....", this.Title);
                    showMessageService.ShowMessage();

                }
                //if (MasterEntity.id > 0)
                // {
                //     MasterEntity = repository.SaveWithReturnDomainObject<ECRM_T001_A>(MasterEntity, "Sample_Analysis", "CRM");

                //     MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MC, "EPR_T001_Data", "Sample_Analysis", "CRM", "rptSampleAnalysis", 0, MasterEntity.sa_no);
                //     //dgReportMaster = MC.rptSalesAnalysis;
                //     //object objDS = new object();
                //     //objDS = MC.rptSalesAnalysis;

                //     ReportManager ReportManager = new ReportingServices.ReportManager();

                //    // ReportManager.DisplayReport(objDS, "dsSampleAnalysis", "\\CRM\\SampleAnalysis.rdlc");

                // }
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
        protected override void OnDocumentAction()
        {
            
        }
        protected override void OnRefreshCommand(InquiryActionResult<ECRM_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ECRM_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ECRM_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ECRM_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ECRM_T001_A> result)
        {
            throw new NotImplementedException();
        }
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("prepare_by", AppSessionState.Name);
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
        #endregion

        #region Filter
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
            var data = obj as ECRM_T001_A_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return (data.sa_no != null && data.sa_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()))||
                           (data.sa_date != null && data.sa_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()))||
                           (data.Plant_Nm != null && data.Plant_Nm.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()))||
                           (data.sample_frm != null && data.sample_frm.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()))||
                           (data.sample_when != null && data.sample_when.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()))||
                           (data.trans_type != null && data.trans_type.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.purpose != null && data.purpose.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                 }
                return true;
            }
            return false;
        }

        private string _filterString_Plant;
        public string FilterString_Plant
        {
            get { return _filterString_Plant; }
            set
            {
                _filterString_Plant = value;
                RaisePropertyChanged("FilterString_Plant");
                FilterCollectionPlant();
            }
        }
        private void FilterCollectionPlant()
        {
            if (_plantCollection != null)
            {
                _plantCollection.Refresh();
            }
        }
        public bool FilterPlant(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Plant))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_Plant.ToLower()) ||
                            data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_Plant.ToLower())
                        );
                }
                return true;
            }
            return false;
        }

        private string _filterString_UOM;
        public string FilterString_UOM
        {
            get { return _filterString_UOM; }
            set
            {
                _filterString_UOM = value;
                RaisePropertyChanged("FilterString_UOM");
                FilterCollection_UOM();
            }
        }
        private void FilterCollection_UOM()
        {
            if (_uomCollection != null)
            {
                _uomCollection.Refresh();
            }
        }
        public bool FilterUnit(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_UOM))
                {
                    return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterString_UOM.ToLower()));
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

        #region Filter Sample From

        private string _filterString_SampleFrom;
        public string FilterString_SapmleFrom
        {
            get { return _filterString_SampleFrom; }
            set
            {
                _filterString_SampleFrom = value;
                RaisePropertyChanged("FilterString_SapmleFrom");
                FilterCollection_SampleFrom();
            }
        }
        private void FilterCollection_SampleFrom()
        {
            if (_SampleFrom_Collection != null)
            {
                _SampleFrom_Collection.Refresh();
            }
        }
        public bool Filter_SampleFrom(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SampleFrom))
                {
                    return (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_SampleFrom.ToLower())) ||
                            (data.PartyNm  != null && data.PartyNm.ToString().ToLower().Contains(_filterString_SampleFrom.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

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
    }
}






