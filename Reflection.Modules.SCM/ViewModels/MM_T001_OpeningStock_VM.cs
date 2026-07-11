using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
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
using Reflection.ReportingServices;

namespace Reflection.Modules.SCM.ViewModels
{
    public class MM_T001_OpeningStock_VM : WorkspaceViewModel<MM_T001>
    {
        #region Variable Declaration
        bool NewRecord = true;
        WebServiceRepository<MM_T001> repository = new WebServiceRepository<MM_T001>();
        WebServiceRepository<MC_MM_T001> repository_MC = new WebServiceRepository<MC_MM_T001>();
        WebServiceRepository<MC_MM_T001> repository_MCTemp = new WebServiceRepository<MC_MM_T001>();
        ObjectSerializationService obj = new ObjectSerializationService();
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        private MC_MM_T001 _MC = new MC_MM_T001();
        public MC_MM_T001 MC
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

        private MC_MM_T001 _MCTemp = new MC_MM_T001();
        public MC_MM_T001 MCTemp
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

        private MM_T001 _MasterEntity;
        public MM_T001 MasterEntity
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
        private ObservableCollection<MM_T001_A> _ItemsEntity;
        //Data source for Items DataGrid
        public ObservableCollection<MM_T001_A> ItemsEntity
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
                 //   ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("ItemsEntity");
                }
            }
        }

        private List<MM_T001_FLIP> _FlipGridData;
        public List<MM_T001_FLIP> FlipGridData
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

        private List<MM_M001> _StoreLocList = new List<MM_M001>();
        public List<MM_M001> StoreLocList
        {
            get { return _StoreLocList; }
            set
            {
                if (_StoreLocList != value)
                {
                    _StoreLocList = value;
                }
            }
        }

        public List<ADM_M003> _PlantList = new List<ADM_M003>();
        private List<ADM_M003> PlantList
        {
            get { return _PlantList; }
            set
            {
                if (_PlantList != value)
                {
                    _PlantList = value;
                }
            }
        }

        string store_location;

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

        private string _MStoreLoc;
        public string MStoreLoc
        {
            get { return _MStoreLoc; }
            set
            {
                if (_MStoreLoc != value)
                {
                    _MStoreLoc = value;
                    RaisePropertyChanged("MStoreLoc");
                }
            }
        }

        private bool _parameter;
        public bool parameter
        {
            get { return _parameter; }
            set
            {
                if (_parameter != value)
                {
                    _parameter = value;
                    RaisePropertyChanged("parameter");
                }
            }
        }

        // For Parameter
        private List<ADM_M031_P> _SelectedParaValueCollection = new List<ADM_M031_P>();
        public List<ADM_M031_P> SelectedParaValueCollection
        {
            get { return _SelectedParaValueCollection; }
            set
            {
                if (_SelectedParaValueCollection != value)
                {
                    _SelectedParaValueCollection = value;
                    RaisePropertyChanged("SelectedParaValueCollection");
                }
            }
        }

        private List<ADM_M031_P> _ParameterTemp = new List<ADM_M031_P>();
        public List<ADM_M031_P> ParameterTemp
        {
            get { return _ParameterTemp; }
            set
            {
                if (_ParameterTemp != value)
                {
                    _ParameterTemp = value;
                }
            }
        }

        public List<ADM_M001_M_P> _PurchaseOrganisationList;
        public List<ADM_M001_M_P> PurchaseOrganisationList
        {
            get
            {
                return _PurchaseOrganisationList;
            }
            set
            {
                _PurchaseOrganisationList = value;
                RaisePropertyChanged("PurchaseOrganisationList");
            }
        }

        public List<ADM_M001_P_P> _PurchaseGroupList;
        public List<ADM_M001_P_P> PurchaseGroupList
        {
            get
            {
                return _PurchaseGroupList;
            }
            set
            {
                _PurchaseGroupList = value;
                RaisePropertyChanged("PurchaseGroupList");
            }
        }
        #endregion

        #region StringList Variables

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

        private List<string> _strListStoreLoc;
        public List<string> StringListStoreLoc
        {
            get { return _strListStoreLoc; }
            set
            {
                if (_strListStoreLoc != value)
                {
                    _strListStoreLoc = value;
                }
            }
        }

        private List<string> _stringListItem;
        public List<string> StringListItem
        {
            get { return _stringListItem; }
            set
            {
                if (_stringListItem != value)
                {
                    _stringListItem = value;
                }
            }
        }

        private List<string> _stringListUom;
        public List<string> StringListUom
        {
            get { return _stringListUom; }
            set
            {
                if (_stringListUom != value)
                {
                    _stringListUom = value;
                }
            }
        }

        List<string> _strListPurchaseOrg;
        public List<string> StringListPurchaseOrg
        {
            get { return _strListPurchaseOrg; }
            set
            {
                if (_strListPurchaseOrg != value)
                {
                    _strListPurchaseOrg = value;
                }
            }
        }

        List<string> _strListPurchaseGroup;
        public List<string> StringListPurchaseGroup
        {
            get { return _strListPurchaseGroup; }
            set
            {
                if (_strListPurchaseGroup != value)
                {
                    _strListPurchaseGroup = value;
                }
            }
        }
        #endregion

        #region ICollectionView
        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }

        private ICollectionView _MStoreLocCollection;
        public ICollectionView MStoreLocCollection
        {
            get { return _MStoreLocCollection; }
            set { _MStoreLocCollection = value; RaisePropertyChanged("MStoreLocCollection"); }
        }

        private ICollectionView _MPlantCollection;
        public ICollectionView MPlantCollection
        {
            get { return _MPlantCollection; }
            set { _MPlantCollection = value; RaisePropertyChanged("MPlantCollection"); }
        }

        private ICollectionView _ItemCollection;
        public ICollectionView ItemCollection
        {
            get { return _ItemCollection; }
            set { _ItemCollection = value; RaisePropertyChanged("ItemCollection"); }
        }

        private ICollectionView _UOMCollection;
        public ICollectionView UOMCollection
        {
            get { return _UOMCollection; }
            set { _UOMCollection = value; RaisePropertyChanged("UOMCollection"); }
        }

        private ICollectionView _StoreLocCollection;
        public ICollectionView StoreLocCollection
        {
            get { return _StoreLocCollection; }
            set { _StoreLocCollection = value; RaisePropertyChanged("StoreLocCollection"); }
        }

        private ICollectionView _PlantCollection;
        public ICollectionView PlantCollection
        {
            get { return _PlantCollection; }
            set { _PlantCollection = value; RaisePropertyChanged("PlantCollection"); }
        }

        // for parameter
        private ICollectionView _ParameterCollection;
        public ICollectionView ParameterCollection
        {
            get { return _ParameterCollection; }
            set
            {
                _ParameterCollection = value;
                RaisePropertyChanged("ParameterCollection");
            }
        }

        private ICollectionView _po_orgCollection;
        public ICollectionView po_orgCollection
        {
            get { return _po_orgCollection; }
            set
            {
                _po_orgCollection = value;
                RaisePropertyChanged("po_orgCollection");
            }
        }
        private ICollectionView _pur_groupCollection;
        public ICollectionView Purchase_groupCollection
        {
            get { return _pur_groupCollection; }
            set
            {
                _pur_groupCollection = value;
                RaisePropertyChanged("Purchase_groupCollection");
            }
        }
        #endregion

        #region . Relay Commands .

        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> CommandMPlant { get; private set; }   //  M stands for Master 
        public RelayCommand<object> CommandMStoreLoc { get; private set; }

        // Item Details
        public RelayCommand<object> CommandInsertItem { get; private set; }
        public RelayCommand<object> CommandUOM { get; private set; }
        public RelayCommand<object> CommandPlant { get; private set; }
        public RelayCommand<object> CommandStoreLoc { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowItem { get; private set; }
        public RelayCommand<IList> SelectionChangeCommandItemDetails { get; private set; }
        public RelayCommand<object> CommandPurchaseOrg { get; private set; }
        public RelayCommand<object> CommandPurchaseGroup { get; private set; }

        // Parameter Commands
        public RelayCommand<IList> CollectionChangedCommand { get; private set; }
        public RelayCommand<IList> SelectionChangedParaValCommand { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region . Constructor .
        public MM_T001_OpeningStock_VM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new MM_T001();
            ItemsEntity = new ObservableCollection<MM_T001_A>();
            MCTemp = new MC_MM_T001();
            DefaultValues();
        
            MasterEntity.ValidateAsync().Wait();

           

            LoadInitialData();
        }
        public MM_T001_OpeningStock_VM(string ts_code,string doc_no)
            : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new MM_T001();
            ItemsEntity = new ObservableCollection<MM_T001_A>();
            MCTemp = new MC_MM_T001();
            DefaultValues();

            MasterEntity.ValidateAsync().Wait();



            LoadInitialData();
        }

        #endregion

        #region . User Defined Functions .
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_cat = "OS";
            MasterEntity.doc_type = "OS";
            MasterEntity.doc_code = "OS";
            MasterEntity.mov_tp = "112";
            MasterEntity.mov_name = "Opening Stock";
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.post_date = DateTime.Now;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.t_status = "001";
            //MasterEntity.fin_year = "15-16";
            //MasterEntity.posting_period = "10";
            MasterEntity.editby = AppSessionState.UserID;
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + "112" + "!@" + AppSessionState.EmpId; 
                MC = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "GoodsReceiptNote", "SCM", "LoadAll", 0, "");

                 #region . Command Initialization.

                    CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
                    CommandMPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertMPlant(items); });
                    CommandMStoreLoc = new RelayCommand<object>(items => { if (items == null) { return; } InsertMStoreLoc(items); });
                    CommandPurchaseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseOrg(items); });
                    CommandPurchaseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseGroup(items); });
                    // Item Details
                    CommandInsertItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertDataGridRow_Item(items, true, true, true); });
                    CommandUOM = new RelayCommand<object>(items => { if (items == null) { return; } InsertUOM(items, false, true, true); });
                    CommandPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items, false, true, true); });
                    CommandStoreLoc = new RelayCommand<object>(items => { if (items == null) { return; } InsertStoreLoc(items, false, true, true); });
                    CommandDeleteDataGridRowItem = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow_Item(items); });
                    SelectionChangeCommandItemDetails = new RelayCommand<IList>(items => { if (items == null) { return; } ItemDetailsSelectionChangedMethod(items); });
                    // Item Description Parameter
                    CollectionChangedCommand = new RelayCommand<IList>(items => { if (items == null) { return; } CollectionChanged(items); });
                    SelectionChangedParaValCommand = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedParaValue(items); });
                    cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                    cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                #endregion
                FlipGridData = MC.FlipGridList;
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_BackFlip);

                ItemCollection = CollectionViewSource.GetDefaultView(MC.ItemList);
                ItemCollection.Filter = new Predicate<object>(Filter_Item);
                StringListItem = MC.ItemList.Select(x => x.ItemCode).ToList();

                UOMCollection = CollectionViewSource.GetDefaultView(MC.UOMList);
                UOMCollection.Filter = new Predicate<object>(Filter_UOM);
                StringListUom = MC.UOMList.Select(x => x.unit_code).ToList();

                PlantList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                PlantCollection = CollectionViewSource.GetDefaultView(PlantList);
                PlantCollection.Filter = new Predicate<object>(Filter_Plant);
                StringListPlant = PlantList.Select(x => x.location_Id).ToList();

                StoreLocList = (List<MM_M001>)AppSessionState.store_location;
                StoreLocCollection = CollectionViewSource.GetDefaultView(StoreLocList);
                StoreLocCollection.Filter = new Predicate<object>(Filter_StoreLoc);
                //store_location = (from o in StoreLocList
                //                  where o.location_Id == AppSessionState.location_Id 
                //                  select o.store_code).ToList()[0];
                if (StoreLocList.Count == 1)
                {
                    store_location = StoreLocList[0].store_code;
                }

                MPlantCollection = CollectionViewSource.GetDefaultView(PlantList);
                MPlantCollection.Filter = new Predicate<object>(Filter_MPlant);

                MStoreLocCollection = CollectionViewSource.GetDefaultView(StoreLocList);
                MStoreLocCollection.Filter = new Predicate<object>(Filter_MStoreLoc);

                PurchaseOrganisationList = (List<ADM_M001_M_P>)AppSessionState.ADM_M001_M_List;
                po_orgCollection = CollectionViewSource.GetDefaultView(PurchaseOrganisationList);
                po_orgCollection.Filter = new Predicate<object>(Purorg_Filter);
                StringListPurchaseOrg = PurchaseOrganisationList.Select(x => x.po_code).ToList();

                if (PurchaseOrganisationList.Count != 0)
                {
                    if (PurchaseOrganisationList.Count == 1)
                    {
                        MasterEntity.po_code = PurchaseOrganisationList[0].po_code;
                        MasterEntity.pur_org = PurchaseOrganisationList[0].pur_org;
                    }
                }
                else
                {
                    MasterEntity.po_code = "";
                }

                PurchaseGroupList = (List<ADM_M001_P_P>)AppSessionState.ADM_M001_P_List;
                Purchase_groupCollection = CollectionViewSource.GetDefaultView(PurchaseGroupList);
                Purchase_groupCollection.Filter = new Predicate<object>(Purchase_grp_Filter);
                StringListPurchaseGroup = PurchaseGroupList.Select(x => x.pg_code).ToList();

                if (PurchaseGroupList.Count != 0)
                {
                    if (PurchaseGroupList.Count == 1)
                    {
                        MasterEntity.pg_code = PurchaseGroupList[0].pg_code;
                        MasterEntity.pg_name = PurchaseGroupList[0].pg_name;
                    }
                }
                else
                {
                    MasterEntity.pg_code = "";
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
                MM_T001_FLIP ParameterEntityObject = null;

                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<MM_T001_FLIP>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<MM_T001_FLIP>().ToList()[0];
                        NewRecord = false;
                        parameter = false;
                        string RequestParameterData = "GRNDetails" + "!@" + ParameterEntityObject.doc_no;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MCTemp, RequestParameterData, "GoodsReceiptNote", "SCM", "GRNDetails", 0, "");
                        MasterEntity = MCTemp.GRNMasterList[0];
                        ItemsEntity = MCTemp.ItemDetailsList;
                        SelectedTabControlIndex = 0;
                        MasterEntity.ts_code = ts_code_vm;
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
        private void InsertMPlant(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;
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
                            { POPUPEntityObject = PlantList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
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
        private void InsertMStoreLoc(object InputValue)
        {
            try
            {
                string Request = "";
                MM_M001 POPUPEntityObject = null;
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
                            { POPUPEntityObject = StoreLocList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M001>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MStoreLoc = POPUPEntityObject.store_code;
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
        private void InsertPurchaseOrg(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                ADM_M001_M_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = PurchaseOrganisationList.Where(x => x.po_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_M_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.po_code = POPUPEntityObject.po_code;
                    MasterEntity.pur_org = POPUPEntityObject.pur_org;
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
        private void InsertPurchaseGroup(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                ADM_M001_P_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = PurchaseGroupList.Where(x => x.pg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_P_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.pg_code = POPUPEntityObject.pg_code;
                    MasterEntity.pg_name = POPUPEntityObject.pg_name;
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
        // Item Details Functions
        private void InsertDataGridRow_Item(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                ADM_M022_P POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ItemPopupList.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                    {
                        ItemsEntity.Add(new MM_T001_A()
                        {
                            id = 0,
                            ItemCode = POPUPEntityObject.ItemCode,
                            description = POPUPEntityObject.ItemName,
                            unit_code = POPUPEntityObject.unit_code,
                            StockUnt = POPUPEntityObject.StockUnt,
                            SubCatCode = POPUPEntityObject.SubCatCode,
                            line_id = 0,
                            comp_code = AppSessionState.comp_code,
                            location_Id = MasterEntity.location_Id,
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID,
                            fin_year = "15-16",
                            posting_period = "10",
                            t_status = "Draft",
                            active = true,
                            batch_split = false,
                            store_code = MStoreLoc,
                            debcr_ind = "C",
                            client = AppSessionState.client
                        });
                    }
                    else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            ItemsEntity[dgSelectedIndexItem].ItemCode = POPUPEntityObject.ItemCode;
                            ItemsEntity[dgSelectedIndexItem].description = POPUPEntityObject.ItemName;
                            ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                            ItemsEntity[dgSelectedIndexItem].qty = POPUPEntityObject.qty;
                            ItemsEntity[dgSelectedIndexItem].StockUnt = POPUPEntityObject.StockUnt;
                            ItemsEntity[dgSelectedIndexItem].SubCatCode = POPUPEntityObject.SubCatCode;
                            ItemsEntity[dgSelectedIndexItem].active = true;
                            ItemsEntity[dgSelectedIndexItem].line_id = 0;
                            ItemsEntity[dgSelectedIndexItem].PartyId = MasterEntity.PartyId;
                            ItemsEntity[dgSelectedIndexItem].batch_split = false;
                            ItemsEntity[dgSelectedIndexItem].store_code = MStoreLoc;
                            ItemsEntity[dgSelectedIndexItem].comp_code = AppSessionState.comp_code;
                            ItemsEntity[dgSelectedIndexItem].client = AppSessionState.client;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].ItemCode != POPUPEntityObject.ItemCode)
                        {
                            ItemsEntity[dgSelectedIndexItem].ItemCode = "";
                            ItemsEntity[dgSelectedIndexItem].description = "";
                        }
                    }
                }


                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
                    {
                        ItemsEntity.RemoveAt(i);
                        if (ItemsEntity.Count == 0)
                        {
                            ItemsEntity.Add(newObj);
                        }
                    }
                }
                #endregion

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
        private void InsertUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                //AppSessionState.StringListValue = StringListUom;
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UOMList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                        {
                            ItemsEntity[dgSelectedIndexItem].unit_code = "";
                        }
                    }
                }
                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
                    {
                        ItemsEntity.RemoveAt(i);
                        if (ItemsEntity.Count == 0)
                        {
                            ItemsEntity.Add(newObj);
                        }
                    }
                }
                #endregion

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
        private void InsertPlant(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                //AppSessionState.StringListValue = StringListUom;
                string Request = "";
                ADM_M003 POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = PlantList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M003>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.location_Id == POPUPEntityObject.location_Id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.location_Id == POPUPEntityObject.location_Id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].location_Id = POPUPEntityObject.location_Id;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].location_Id != POPUPEntityObject.location_Id)
                        {
                            ItemsEntity[dgSelectedIndexItem].location_Id = "";
                        }
                    }
                }
                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
                    {
                        ItemsEntity.RemoveAt(i);
                        if (ItemsEntity.Count == 0)
                        {
                            ItemsEntity.Add(newObj);
                        }
                    }
                }
                #endregion
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
        private void InsertStoreLoc(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                //AppSessionState.StringListValue = StringListUom;
                string Request = "";
                MM_M001 POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = StoreLocList.Where(x => x.store_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<MM_M001>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M001>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.store_code == POPUPEntityObject.store_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.store_code == POPUPEntityObject.store_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].store_code = POPUPEntityObject.store_code;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].store_code != POPUPEntityObject.store_code)
                        {
                            ItemsEntity[dgSelectedIndexItem].store_code = "";
                        }
                    }
                }
                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
                    {
                        ItemsEntity.RemoveAt(i);
                        if (ItemsEntity.Count == 0)
                        {
                            ItemsEntity.Add(newObj);
                        }
                    }
                }
                #endregion
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

        //sandeep
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (dgSelectedIndexItem != -1 && ItemsEntity[i].id == 0)
                {
                    if (ItemsEntity.Count > i && ItemsEntity[dgSelectedIndexItem].id == 0)
                    {
                        ItemsEntity.RemoveAt(i);
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
        private void ItemDetailsSelectionChangedMethod(IList InputList)
        {
            IList list = InputList as IList;
            try
            {
                if (dgSelectedIndexItem != -1 && ItemsEntity.Count > 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    List<MM_T001_A> selectedlist = list.Cast<MM_T001_A>().ToList();

                    if (selectedlist.Count > 0)
                    {                     

                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ItemsEntity[dgSelectedIndexItem].StockUnt == true)
                        {
                            parameter = true;
                        }
                        else
                        {
                            parameter = false;
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

        //Validation Function
        private bool Validations()
        {
            if (ItemsEntity.Count < 1)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Validation";
                showMessageService.Text = String.Format("Item Details Must Have At Least One Item ");
                showMessageService.ShowMessage();
                return false;
            }


            if (MasterEntity.po_code == null || MasterEntity.po_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Validation";
                showMessageService.Text = String.Format("Please Select Purchase Organization(PO Code) in Shipping And Org Data Tab");
                showMessageService.ShowMessage();
                return false;
            }

            if (MasterEntity.pg_code == null || MasterEntity.pg_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Validation";
                showMessageService.Text = String.Format("Please Select Purchase Group(PG Code) in Shipping And Org Data Tab");
                showMessageService.ShowMessage();
                return false;
            }

            foreach (var o in ItemsEntity)
            {
                if (o.ItemCode != null && o.ItemCode != "" && o.active == true)
                {
                    if (o.qty == null || o.qty == 0)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Quantity cannot be null or 0 for item {0} At Index {1}", o.ItemCode, ItemsEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }

                    if (o.unit_code == null || o.unit_code == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Valid Unit Code for the item {0} At Index {1}", o.ItemCode, ItemsEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }
                    if (o.store_code == null || o.store_code == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Valid Store Code for the item {0} At Index {1}", o.ItemCode, ItemsEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }
                    if (o.location_Id == null || o.location_Id == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Valid Plant Code for the item {0} At Index {1}", o.ItemCode, ItemsEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }

                    if(o.batch_no != null || o.batch_no != "")
                    {
                        int flag = 0;
                        foreach (var p in ItemsEntity)
                        {
                            if (p.active == true && p.batch_no != null && p.batch_no == o.batch_no)
                            {
                                flag++;
                            }
                            if (flag > 1)
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Item {0} at Index {1} And Item {2} at Index {3} Have Same Batch Number\n Batch Number Should Be Unique for all batches",o.ItemCode, ItemsEntity.IndexOf(o), p.ItemCode, ItemsEntity.IndexOf(p));
                                showMessageService.ShowMessage();
                                return false;
                            }
                        }
                    }
                    #region . Parameter Validation .
                    // Validation For All Parameter Values Selected or Not

                    if (o.StockUnt == true && o.active == true)
                    {
                        var paralist = (from p in MC.ParameterList where p.SubCatCode == o.SubCatCode select p).ToList();

                        if (paralist.Count > 0)
                        {
                            string[] SkuList = new string[100];           //string array
                            List<string> SkuListt = new List<string>();    // stringlist

                            if (o.sku != null && o.sku != "")
                            {
                                SkuList = o.sku.Split('/');
                                SkuListt = SkuList.ToList();

                                foreach (var item in SkuList)
                                {
                                    if (item == "")
                                    {
                                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                        showMessageService.ButtonSetup = DialogButton.Ok;
                                        showMessageService.Caption = "Parameter Validation";
                                        showMessageService.Text = String.Format("All Parameters of item {0} of Index {1} are not selected..!!! \n Check Parameter at index {2} is selected or not.", o.ItemCode, ItemsEntity.IndexOf(o), SkuList.ToList().IndexOf(item));
                                        showMessageService.ShowMessage();
                                        return false;
                                    }
                                }
                            }
                            else
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Parameter Validation";
                                showMessageService.Text = String.Format("All Parameters of item {0} of Index {1} are not selected\n If you can see All Parameter Value Selected Please Select the Same Values Again ", o.ItemCode, ItemsEntity.IndexOf(o));
                                showMessageService.ShowMessage();
                                return false;
                            }
                        }

                    }
                    #endregion
                    
                }
            }
            return true;
        }

        //Parameter SKU Functions
        private void CollectionChanged(IList DataList)
        {
            IList list = DataList as IList;
            int a = dgSelectedIndexItem;
            string[] TempSkuList = new string[100];
            List<string> TempParaValueList = new List<string>();
            try
            {
                if (dgSelectedIndexItem != -1)   // This Condition is used to avoid error index out of range
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ItemsEntity.Count > 0 && dgSelectedIndexItem < ItemsEntity.Count && dgSelectedIndexItem != -1)
                    {
                        List<MM_T001_A> SelectedRowlist = list.Cast<MM_T001_A>().ToList();

                        if (SelectedRowlist[0].StockUnt == true)
                        {
                            var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();
                            ParameterTemp = paramlist.ToList();

                            if (paramlist.Count > 0 && ItemsEntity[dgSelectedIndexItem].sku != "" && ItemsEntity[dgSelectedIndexItem].sku != null)
                            {
                                TempSkuList = ItemsEntity[dgSelectedIndexItem].sku.Split('/');

                                for (int i = 0; i < paramlist.Count; i++)
                                {
                                    TempParaValueList = (from o in MC.ParamValueList where o.value_code == TempSkuList[i] select o.parametervalue).ToList();
                                    if (TempParaValueList.Count > 0)
                                    {
                                        paramlist[i].parametervalue = TempParaValueList[0];
                                    }
                                }

                                ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                            }
                            else
                            {
                                foreach (var o in ParameterTemp)
                                {
                                    o.parametervalue = null; o.value_code = null;
                                }
                                ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                            }
                            //-------------------------------

                            if (paramlist.Count > 0) //&& SelectedParaValueCollection.Count != paramlist.Count)
                            {
                                SelectedParaValueCollection = new List<ADM_M031_P>();

                                for (int i = 0; i < paramlist.Count; i++)
                                {
                                    SelectedParaValueCollection.Add(new ADM_M031_P()
                                    {
                                        // ItemCode = SelectedRowlist[0].ItemCode,
                                        dgselectedindex = dgSelectedIndexItem,
                                        //  value_code = SelectedParaValueList[0].value_code,
                                        para_code = paramlist[i].para_code,
                                        para_name = paramlist[i].para_name

                                    });
                                }


                                if (ItemsEntity[dgSelectedIndexItem].sku_desc != null)
                                {
                                    SelectedParaValueCollection = ParameterCollection.Cast<ADM_M031_P>().ToList();

                                    foreach (var o in SelectedParaValueCollection)
                                    {
                                        o.dgselectedindex = dgSelectedIndexItem;
                                        foreach (var p in MC.ParamValueList)
                                        {
                                            if (o.para_code == p.para_code && o.parametervalue == p.parametervalue)
                                            {
                                                o.value_code = p.value_code;
                                            }
                                        }
                                    }
                                }

                            }
                        }
                    }
                    else if (ItemsEntity[dgSelectedIndexItem].id != 0 && ItemsEntity.Count > 0 && dgSelectedIndexItem < ItemsEntity.Count)
                    {
                        //List<MM_T001_A> SelectedRowlist = list.Cast<MM_T001_A>().ToList();
                        //string[] TempSkuList = new string[100];
                        //List<string> TempParaValueList = new List<string>();

                        //if (SelectedRowlist[0].StockUnt == true)
                        //{
                        //    var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();
                        //    if (paramlist.Count > 0 && ItemDetailsEntity[dgSelectedIndexItem].sku != "" && ItemDetailsEntity[dgSelectedIndexItem].sku != null)
                        //    {
                        //        TempSkuList = ItemDetailsEntity[dgSelectedIndexItem].sku.Split('/');

                        //        for (int i = 0; i < paramlist.Count; i++)
                        //        {
                        //            TempParaValueList = (from o in MC.ParamValueList where o.value_code == TempSkuList[i] select o.parametervalue).ToList();
                        //            paramlist[i].parametervalue = TempParaValueList[0];
                        //        }

                        //        ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                        //    }
                        //}
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
        private void GetSelectedParaValue(IList parameter)
        {
            IList list = parameter as IList;
            List<ADM_M031_P> SelectedParaValueList = list.Cast<ADM_M031_P>().ToList();
            //  int a = ParadgSelectedIndex;
            int b = dgSelectedIndexItem;
            if (dgSelectedIndexItem != -1 && SelectedParaValueList.Count > 0 && ItemsEntity[dgSelectedIndexItem].StockUnt == true)
            {
                if (ItemsEntity[dgSelectedIndexItem].id == 0)
                {
                    #region 
                    if (SelectedParaValueList.Count > 0 && SelectedParaValueList[0].parametervalue != null && SelectedParaValueList[0].parametervalue != "")// && SelectedParaValueCollection.dgselectedindex.contains)
                    {
                        for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                        {
                            if (SelectedParaValueCollection[i].para_code == SelectedParaValueList[0].para_code && SelectedParaValueCollection[i].dgselectedindex == dgSelectedIndexItem)
                            {
                                SelectedParaValueCollection[i].parametervalue = SelectedParaValueList[0].parametervalue;

                                var paravaluetemp = (from o in MC.ParamValueList where o.para_code == SelectedParaValueCollection[i].para_code && o.parametervalue == SelectedParaValueCollection[i].parametervalue select o).ToList();

                                if (paravaluetemp.Count > 0)
                                {
                                    SelectedParaValueCollection[i].value_code = paravaluetemp[0].value_code;
                                }
                            }
                        }

                        // SKU Description
                        GetSkuDescription();

                        //Function for calculating SKU
                        CalculateSku();
                    }
                    #endregion
                }
                else if (ItemsEntity[dgSelectedIndexItem].id != 0)
                {

                }
            }
        }
        private void GetSkuDescription()
        {
            if (ItemsEntity[dgSelectedIndexItem].StockUnt == true && (ItemsEntity[dgSelectedIndexItem].sku_desc == null || ItemsEntity[dgSelectedIndexItem].sku_desc == ""))
            {
                for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                {
                    if ((ItemsEntity[dgSelectedIndexItem].sku_desc == "" || ItemsEntity[dgSelectedIndexItem].sku_desc == null) && (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA"))
                    {
                        ItemsEntity[dgSelectedIndexItem].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                    }
                    else if (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                    {
                        ItemsEntity[dgSelectedIndexItem].sku_desc = ItemsEntity[dgSelectedIndexItem].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                    }
                }
            }
            else if (ItemsEntity[dgSelectedIndexItem].StockUnt == true)
            {
                ItemsEntity[dgSelectedIndexItem].sku_desc = "";

                for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                {
                    if ((ItemsEntity[dgSelectedIndexItem].sku_desc == "" || ItemsEntity[dgSelectedIndexItem].sku_desc == null) && (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA"))
                    {
                        ItemsEntity[dgSelectedIndexItem].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                    }
                    else if (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                    {
                        ItemsEntity[dgSelectedIndexItem].sku_desc = ItemsEntity[dgSelectedIndexItem].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                    }
                }
            }
        }
        private void CalculateSku()
        {
            if (ItemsEntity[dgSelectedIndexItem].StockUnt == true && (ItemsEntity[dgSelectedIndexItem].sku == null || ItemsEntity[dgSelectedIndexItem].sku == ""))
            {
                for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                {
                    if (ItemsEntity[dgSelectedIndexItem].sku == "" || ItemsEntity[dgSelectedIndexItem].sku == null)
                    {
                        ItemsEntity[dgSelectedIndexItem].sku = SelectedParaValueCollection[i].value_code;
                    }
                    else
                    {
                        ItemsEntity[dgSelectedIndexItem].sku = ItemsEntity[dgSelectedIndexItem].sku + "/" + SelectedParaValueCollection[i].value_code;
                    }
                }
            }
            else  if (ItemsEntity[dgSelectedIndexItem].StockUnt == true)
            {
                ItemsEntity[dgSelectedIndexItem].sku = "";

                for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                {
                    if (ItemsEntity[dgSelectedIndexItem].sku == "" || ItemsEntity[dgSelectedIndexItem].sku == null)
                    {
                        ItemsEntity[dgSelectedIndexItem].sku = SelectedParaValueCollection[i].value_code;
                    }
                    else
                    {
                        ItemsEntity[dgSelectedIndexItem].sku = ItemsEntity[dgSelectedIndexItem].sku + "/" + SelectedParaValueCollection[i].value_code;
                    }

                }
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

        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<MM_T001> result)
        {
            try
            {
                if (Validations() == true)
                {
                    MasterEntity.XmlDataDocument_MM_T001_A = obj.ObjectToXML(ItemsEntity);

                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<MM_T001>(MasterEntity, "GoodsReceiptNote", "SCM");
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<MM_T001>(MasterEntity, "GoodsReceiptNote", "SCM");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    NewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                    parameter = false; // After Save Parameter Popup Should not Open Hence Disabling this Variable
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
            MasterEntity.ts_code = ts_code_vm;
            if (MasterEntity.XmlDataDocument_MM_T001_A != null)
            {
                MC.ItemDetailsList = (ObservableCollection<MM_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_MM_T001_A, MC.ItemDetailsList);
                ItemsEntity.Clear();
                ItemsEntity = MC.ItemDetailsList;
            }
            else
            {
                MC.ItemDetailsList = new ObservableCollection<MM_T001_A>();
            }           

            if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
            {
                MC.FlipGridList = (List<MM_T001_FLIP>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.FlipGridList);
                FlipGridData.Add(MC.FlipGridList[0]);
                FlipDataGridCollection.Refresh();

                SelectedTabControlIndex = 0;
            }
        }
        protected override void OnCreateAction(InquiryActionResult<MM_T001> result)
        {
            NewRecord = true; parameter = false;
            MasterEntity = new MM_T001();
            ItemsEntity = new ObservableCollection<MM_T001_A>();
            MasterEntity.ValidateAsync().Wait();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<MM_T001> result)
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
                string response = repository.Delete(MasterEntity.doc_no, "GoodsReceiptNote", "SCM");
                //FlipGridData.Remove(MasterEntity); Temp
                MasterEntity = new MM_T001();
                ItemsEntity = new ObservableCollection<MM_T001_A>();
                _FlipDataGridCollection.Refresh();
                NewRecord = true;
                parameter = false;
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<MM_T001> result)
        {
            MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<MM_T001> result)
        {
        }
        protected override void OnFlipAction(InquiryActionResult<MM_T001> result)
        {
        }
        protected override void OnHelpAction(InquiryActionResult<MM_T001> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<MM_T001> result)
        {
            if (MasterEntity.doc_no == null || MasterEntity.doc_no == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("You must have to save the record first..Then print it", this.Title);
                showMessageService.ShowMessage();
            }
            else
            {
                string Request = "Opening_Stock" + "!@" + MasterEntity.doc_no ;

                MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MCTemp, Request, "GoodsReceiptNote", "SCM", "LoadAll", 0, "");

                object[] objDataSource = new object[3];
                string[] objDataSourceName = new string[3];

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[0] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[1] = Result;

                objDataSource[2] = MCTemp.RptGRN;

                objDataSourceName[0] = "dsCompany";
                objDataSourceName[1] = "dsLocation";
                objDataSourceName[2] = "dsGRN";

                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\SCM\\OpeningStock.rdlc", "GRN");

            }


        }
        //protected override void OnExportAction(InquiryActionResult<MM_T001> result)
        //{
        //    try
        //    {
        //        List<MM_T001> Export_List = new List<MM_T001>();
        //        foreach (var o in DataGridCollection)
        //        {
        //            MM_T001 Data = o as MM_T001;
        //            Export_List.Add(Data);
        //        }

        //        //--------------------------------------

        //        ExportToExcel<MM_T001, List<MM_T001>> export = new ExportToExcel<MM_T001, List<MM_T001>>();
        //        ICollectionView view = CollectionViewSource.GetDefaultView(Export_List);
        //        export.dataToPrint = (List<MM_T001>)view.SourceCollection;

        //        export.GenerateReport();
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
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filter Functions

        #region . BackFlip .
        private string _filterString_BackFlip; //vendor
        public string FilterString_BackFlip
        {
            get { return _filterString_BackFlip; }
            set
            {
                _filterString_BackFlip = value;
                RaisePropertyChanged("FilterString_BackFlip");
                FilterCollection_BackFlip();
            }
        }
        private void FilterCollection_BackFlip()
        {
            if (FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_BackFlip(object obj)
        {
            var data = obj as MM_T001_FLIP;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BackFlip))
                {
                    return (data.mov_name != null && data.mov_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()) ||
                        data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()) ||     
                        data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion       

        #region . Item .
        private string _filterString_Item; //Transporter
        public string FilterString_Item
        {
            get { return _filterString_Item; }
            set
            {
                _filterString_Item = value;
                RaisePropertyChanged("FilterString_Item");
                FilterCollection_Item();
            }
        }
        private void FilterCollection_Item()
        {
            if (ItemCollection != null)
            {
                _ItemCollection.Refresh();
            }
        }
        public bool Filter_Item(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Item))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
                        data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
                        data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_Item.ToLower()) ||
                        data.StockUnt != null && data.StockUnt.ToString().ToLower().Contains(_filterString_Item.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . UOM .
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
            if (UOMCollection != null)
            {
                _UOMCollection.Refresh();
            }
        }
        public bool Filter_UOM(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_UOM))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_UOM.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Plant .
        private string _filterString_Plant;
        public string FilterString_Plant
        {
            get { return _filterString_Plant; }
            set
            {
                _filterString_Plant = value;
                RaisePropertyChanged("FilterString_Plant");
                FilterCollection_Plant();
            }
        }
        private void FilterCollection_Plant()
        {
            if (PlantCollection != null)
            {
                PlantCollection.Refresh();
            }
        }
        public bool Filter_Plant(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Plant))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_Plant.ToLower()) ||
                        data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_Plant.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Store Loc .
        private string _filterString_StoreLoc;
        public string FilterString_StoreLoc
        {
            get { return _filterString_StoreLoc; }
            set
            {
                _filterString_StoreLoc = value;
                RaisePropertyChanged("FilterString_StoreLoc");
                FilterCollection_StoreLoc();
            }
        }
        private void FilterCollection_StoreLoc()
        {
            if (StoreLocCollection != null)
            {
                _StoreLocCollection.Refresh();
            }
        }
        public bool Filter_StoreLoc(object obj)
        {
            var data = obj as MM_M001;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_StoreLoc))
                {
                    return (data.store_code != null && data.store_code.ToString().ToLower().Contains(_filterString_StoreLoc.ToLower()) ||
                        data.store_name != null && data.store_name.ToString().ToLower().Contains(_filterString_StoreLoc.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . MPlant .  
        // M stands for Master
        private string _filterString_MPlant;
        public string FilterString_MPlant
        {
            get { return _filterString_MPlant; }
            set
            {
                _filterString_MPlant = value;
                RaisePropertyChanged("FilterString_MPlant");
                FilterCollection_Plant();
            }
        }
        private void FilterCollection_MPlant()
        {
            if (MPlantCollection != null)
            {
                MPlantCollection.Refresh();
            }
        }
        public bool Filter_MPlant(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_MPlant))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_MPlant.ToLower()) ||
                        data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_MPlant.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . MStore Loc .

        private string _filterString_MStoreLoc;
        public string FilterString_MStoreLoc
        {
            get { return _filterString_MStoreLoc; }
            set
            {
                _filterString_MStoreLoc = value;
                RaisePropertyChanged("FilterString_MStoreLoc");
                FilterCollection_MStoreLoc();
            }
        }
        private void FilterCollection_MStoreLoc()
        {
            if (MStoreLocCollection != null)
            {
                _MStoreLocCollection.Refresh();
            }
        }
        public bool Filter_MStoreLoc(object obj)
        {
            var data = obj as MM_M001;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_MStoreLoc))
                {
                    return (data.store_code != null && data.store_code.ToString().ToLower().Contains(_filterString_MStoreLoc.ToLower()) ||
                        data.store_name != null && data.store_name.ToString().ToLower().Contains(_filterString_MStoreLoc.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region PO Code
        private string _filterString_PurOrg;
        public string FilterString_PurOrg
        {
            get { return _filterString_PurOrg; }
            set
            {
                _filterString_PurOrg = value;
                RaisePropertyChanged("FilterString_PurOrg");
                FilterCollection_PurOrg();
            }
        }
        private void FilterCollection_PurOrg()
        {
            if (po_orgCollection != null)
            {
                po_orgCollection.Refresh();
            }
        }
        public bool Purorg_Filter(object obj)
        {
            var data = obj as ADM_M001_M_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_PurOrg))
                {
                    return (data.po_code != null && data.po_code.ToString().ToLower().Contains(_filterString_PurOrg.ToLower())) ||
                       (data.pur_org != null && data.pur_org.ToString().ToLower().Contains(_filterString_PurOrg.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region PG Code
        private string _filterString_pur_grp;
        public string FilterString_pur_grp
        {
            get { return _filterString_pur_grp; }
            set
            {
                _filterString_pur_grp = value;
                RaisePropertyChanged("FilterString_pur_grp");
                FilterCollection_pur_grp();
            }
        }
        private void FilterCollection_pur_grp()
        {
            if (Purchase_groupCollection != null)
            {
                Purchase_groupCollection.Refresh();
            }
        }
        public bool Purchase_grp_Filter(object obj)
        {
            var data = obj as ADM_M001_P_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_pur_grp))
                {
                    return (data.pg_code != null && data.pg_code.ToString().ToLower().Contains(_filterString_pur_grp.ToLower())) ||
                        (data.pg_name != null && data.pg_name.ToString().ToLower().Contains(_filterString_pur_grp.ToLower()));
                }
                return true;
            }
            return false;
        }

        
        #endregion
        #endregion
    }
}

