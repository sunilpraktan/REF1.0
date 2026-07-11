using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Reflection.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.BusinessEntity.Admin;
using System.Collections;
using Reflection.BusinessEntity;
using System.Collections.Specialized;

namespace Reflection.Modules.Administration.ViewModels
{
    public class ZADM_M026_VM : WorkspaceViewModel<ZADM_M026>
    {
        #region Declaration

        bool isNewRecord = true;

        WebServiceRepository<ZADM_M026> repository = new WebServiceRepository<ZADM_M026>();
        WebServiceRepository<MultipleContext_ZADM_M026> repository_MC = new WebServiceRepository<MultipleContext_ZADM_M026>();
        WebServiceRepository<MultipleContext_ZADM_M026> repository_MCTemp = new WebServiceRepository<MultipleContext_ZADM_M026>();

        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_ZADM_M026 _MC = new MultipleContext_ZADM_M026();
        public MultipleContext_ZADM_M026 MC
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

        private MultipleContext_ZADM_M026 _MCTemp = new MultipleContext_ZADM_M026();
        public MultipleContext_ZADM_M026 MCTemp
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

        private ZADM_M026 _MasterEntity;
        public ZADM_M026 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged(nameof(MasterEntity));
                    value.BeginEdit();
                }
            }
        }
        private ZADM_M026 _ItemsEntityTemp;
        public ZADM_M026 ItemsEntityTemp
        {
            get { return _ItemsEntityTemp; }
            set
            {
                if (_ItemsEntityTemp != value)
                {
                    _ItemsEntityTemp = value; RaisePropertyChanged("ItemsEntityTemp");

                }
            }
        }
        private ObservableCollection<ZADM_M026> _ItemsEntity;
        public ObservableCollection<ZADM_M026> ItemsEntity
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
        private string _supplier_id;
        public string supplier_id
        {
            get { return _supplier_id; }
            set
            {
                _supplier_id = value;
                RaisePropertyChanged("supplier_id");
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
        #endregion

        #region List

        private List<ZADM_M026Flip> _FlipGridData;
        public List<ZADM_M026Flip> FlipGridData
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

        #region Collection

        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }



        private ICollectionView _SupplierCollection;
        public ICollectionView SupplierCollection
        {
            get { return _SupplierCollection; }
            set { _SupplierCollection = value; RaisePropertyChanged("SupplierCollection"); }
        }

        private ICollectionView _CustomerCollection;
        public ICollectionView CustomerCollection
        {
            get { return _CustomerCollection; }
            set { _CustomerCollection = value; RaisePropertyChanged("CustomerCollection"); }
        }

        private ICollectionView _ItemCollection;
        public ICollectionView ItemCollection
        {
            get { return _ItemCollection; }
            set { _ItemCollection = value; RaisePropertyChanged("ItemCollection"); }
        }

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

        private ICollectionView _ParameterValueCollection;
        public ICollectionView ParameterValueCollection
        {
            get { return _ParameterValueCollection; }
            set
            {
                _ParameterValueCollection = value;
                RaisePropertyChanged("ParameterValueCollection");
            }
        }


        #endregion

        #region StringList

        List<string> _StringListSupplier;
        public List<string> StringListSupplier
        {
            get { return _StringListSupplier; }
            set
            {
                if (_StringListSupplier != value)
                {
                    _StringListSupplier = value;
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

        List<string> _StringListItem;
        public List<string> StringListItem
        {
            get { return _StringListItem; }
            set
            {
                if (_StringListItem != value)
                {
                    _StringListItem = value;
                }
            }
        }

        List<string> _StringListParameter;
        public List<string> StringListParameter
        {
            get { return _StringListParameter; }
            set
            {
                if (_StringListParameter != value)
                {
                    _StringListParameter = value;
                }
            }
        }

        List<string> _StringListParameterValue;
        public List<string> StringListParameterValue
        {
            get { return _StringListParameterValue; }
            set
            {
                if (_StringListParameterValue != value)
                {
                    _StringListParameterValue = value;
                }
            }
        }

        #endregion

        #region Relay Command
        public RelayCommand<object> CmdAddSupplier { get; private set; }
        public RelayCommand<object> CmdAddCustomer { get; private set; }
        public RelayCommand<object> CmdAddCustomerMaster { get; private set; }
        public RelayCommand<object> CmdAddItem { get; private set; }
        public RelayCommand<object> CmdAddParameter { get; private set; }
        public RelayCommand<object> CmdAddParameterValue { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand CommandLoadDocumentByDocumentNumber { get; private set; }


        #endregion

        #region Constructor

        public ZADM_M026_VM() : base()
        {
            MasterEntity = new ZADM_M026();
            ItemsEntity = new ObservableCollection<ZADM_M026>();
            FlipGridData = new List<ZADM_M026Flip>();
            MC = new MultipleContext_ZADM_M026();
            MCTemp = new MultipleContext_ZADM_M026();
            MasterEntity.ValidateAsync().Wait();
            ZADM_M026.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            ZADM_M026.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            CmdAddSupplier = new RelayCommand<object>(items => { if (items == null) { return; } InsertSupplier(items, isNewRecord); });
            CmdAddCustomerMaster = new RelayCommand<object>(items => { if (items == null) { return; } InsertCustomerMaster(items, isNewRecord); });
            CmdAddCustomer = new RelayCommand<object>(items => { if (items == null) { return; } InsertCustomer(items, true, false, true); });
            CmdAddItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items, true, true, true); });
            CmdAddParameterValue = new RelayCommand<object>(items => { if (items == null) { return; } InsertParameterValue(items, true, true, true); });
            CmdDeleteDataGridRowItem = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow_Item(items); });
            CommandLoadDocumentByDocumentNumber = new RelayCommand(() => { LoadDetails(); });

            LoadInitialData();
        }

        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString();
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ZADM_M026>(MC, Request, "InkCatalog", "Administration", "LoadInitialData", 0, "");

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGridData);

                SupplierCollection = CollectionViewSource.GetDefaultView(MC.SupplierList);
                SupplierCollection.Filter = new Predicate<object>(Filter_Supplier);
                StringListSupplier = MC.SupplierList.Select(x => x.PartyId.ToString()).ToList();

                CustomerCollection = CollectionViewSource.GetDefaultView(MC.CustomerList);
                CustomerCollection.Filter = new Predicate<object>(Filter_Customer);
                StringListCustomer = MC.CustomerList.Select(x => x.PartyId.ToString()).ToList();

                ItemCollection = CollectionViewSource.GetDefaultView(MC.ItemList);
                ItemCollection.Filter = new Predicate<object>(Filter_Item);
                StringListItem = MC.ItemList.Select(x => x.ItemCode.ToString()).ToList();

                ParameterValueCollection = CollectionViewSource.GetDefaultView(MC.ParamValueList);
                ParameterValueCollection.Filter = new Predicate<object>(Filter_ParameterValue);
                StringListParameterValue = MC.ParamValueList.Select(x => x.value_code.ToString()).ToList();

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
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            //LocalVariable = MasterEntity.supplier_id;
            this.ErrorExist = MasterEntity.HasErrors;
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            //LocalVariable = MasterEntity.supplier_id;
            this.ErrorExist = MasterEntity.HasErrors;
        }

        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            string RequestParameterData = "";
            ZADM_M026Flip ParameterEntityObject = null;

            if (ParameterObject != null)
            {

                if (((IEnumerable)ParameterObject).Cast<ZADM_M026Flip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ZADM_M026Flip>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.id;
                    isNewRecord = false;
                    MasterEntity = new ZADM_M026();
                    MasterEntity = repository.GetDataWithReturnDomainObject<ZADM_M026>(MasterEntity, Request, "InkCatalog", "Administration", "LoadDocumentByDocumentNumber", 0, "");


                }

            }

        }
       

        #endregion
        private void LoadDetails()
        {
            
            string Request = "";
            if ((MasterEntity.supplier_id == null ||MasterEntity.supplier_id=="") || (MasterEntity.ItemCode==null || MasterEntity.ItemCode==""))
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Please Select Supplier & Item Code...", this.Title);
                showMessageService.ShowMessage();
            }
            else
            {
                if ((MasterEntity.supplier_id != null && MasterEntity.supplier_id != " ") && (MasterEntity.ItemCode != null && MasterEntity.ItemCode != " "))
                {
                    Request = "Load" + "!@" + MasterEntity.supplier_id + "!@" + MasterEntity.ItemCode;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ZADM_M026>(MCTemp, Request, "InkCatalog", "Administration", "", 0, "");

                }
                if ((MasterEntity.supplier_id != null && MasterEntity.supplier_id != " ") && (MasterEntity.ItemCode != null && MasterEntity.ItemCode != " ") && (MasterEntity.customer_id != null && MasterEntity.customer_id != " "))
                {
                    Request = "LoadAll" + "!@" + MasterEntity.supplier_id + "!@" + MasterEntity.ItemCode + "!@" + MasterEntity.customer_id;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ZADM_M026>(MCTemp, Request, "InkCatalog", "Administration", "", 0, "");

                }
                if ((MasterEntity.supplier_id == null || MasterEntity.supplier_id == " ") && (MasterEntity.ItemCode == null || MasterEntity.ItemCode == " ") && (MasterEntity.customer_id == null || MasterEntity.customer_id == " "))
                {
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ZADM_M026>(MCTemp, "LoadAllDetails", "InkCatalog", "Administration", "", 0, "");

                }
                ItemsEntity = MCTemp.ItemEntity;
            }
        }

        #region User Defined Functions
        private void DefaultValues()
        {
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.t_status = "Draft";
            MasterEntity.active = true;
        }
        private void InsertSupplier(object InputValue, bool OverrideValue)
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
                        { POPUPEntityObject = MC.SupplierList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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

                MasterEntity.supplier_id = POPUPEntityObject.PartyId;
                MasterEntity.SupplierNm = POPUPEntityObject.PartyNm;

            }
        }
        private void InsertCustomer(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                        { POPUPEntityObject = MC.CustomerList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
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
                if ((MasterEntity.supplier_id != null && MasterEntity.supplier_id != " ") &&( MasterEntity.ItemCode != null && MasterEntity.ItemCode != " ") && ( MasterEntity.price != null ))
                {
                    var InputValueIfExists = ItemsEntity.Where(x => x.customer_id == POPUPEntityObject.PartyId).FirstOrDefault();
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.customer_id == POPUPEntityObject.PartyId).FirstOrDefault());
                    //Insert
                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                    {
                        ItemsEntity.Add(new ZADM_M026()
                        {
                            id = 0,
                            customer_id = POPUPEntityObject.PartyId,
                            CustomerNm = POPUPEntityObject.PartyNm,
                            active = true,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID,

                            t_status = "Draft"

                        });
                    }
                    //update
                    else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                        {
                            ItemsEntity[dgSelectedIndexItem].customer_id = POPUPEntityObject.PartyId;
                            ItemsEntity[dgSelectedIndexItem].CustomerNm = POPUPEntityObject.PartyNm;
                            ItemsEntity[dgSelectedIndexItem].location_Id = AppSessionState.location_Id;
                            ItemsEntity[dgSelectedIndexItem].comp_code = AppSessionState.comp_code;
                            ItemsEntity[dgSelectedIndexItem].add_by = AppSessionState.UserID;
                            ItemsEntity[dgSelectedIndexItem].editby = AppSessionState.UserID;
                            ItemsEntity[dgSelectedIndexItem].active = true;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].customer_id != POPUPEntityObject.PartyId)
                        {
                            ItemsEntity[dgSelectedIndexItem].customer_id = "";
                            ItemsEntity[dgSelectedIndexItem].CustomerNm = "";
                        }
                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Please select supplier id and item code and price....", this.Title);
                    showMessageService.ShowMessage();
                   
                }


            }
        }
        private void InsertItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                        { POPUPEntityObject = MC.ItemList.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M022_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                    MasterEntity.ItemNm = POPUPEntityObject.ItemName;
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
        private void InsertParameterValue(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M030_P POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.ParamValueList.Where(x => x.value_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M030_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M030_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.ink_code = POPUPEntityObject.value_code;
                    MasterEntity.parametervalue = POPUPEntityObject.parametervalue;
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
        private void InsertCustomerMaster(object InputValue, bool OverrideValue)
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
                        { POPUPEntityObject = MC.CustomerList.Where(x => x.PartyId .Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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

                MasterEntity.customer_id = POPUPEntityObject.PartyId;
                MasterEntity.CustomerNm = POPUPEntityObject.PartyNm;

            }
        }
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i && ItemsEntity[dgSelectedIndexItem].id == 0)
                {
                    ItemsEntity.RemoveAt(i);
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
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false;/*MasterEntity.HasErrors;*/
            if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = ItemsEntity[dgSelectedIndexItem].HasErrors;
            }

        }
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
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
                foreach (ZADM_M026 item in e.NewItems)
                    item.PropertyChanged += this.MyType_PropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (ZADM_M026 item in e.OldItems)
                    item.PropertyChanged -= this.MyType_PropertyChanged;

            /////////////////////////////////Temp Test End
            //different kind of changes that may have occurred in collection
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (ZADM_M026 item in e.NewItems)
                {
                    //Added items
                    item.supplier_id = MasterEntity.supplier_id;
                    item.SupplierNm = MasterEntity.SupplierNm;
                    item.ItemCode = MasterEntity.ItemCode;
                    item.ItemNm = MasterEntity.ItemNm;
                    item.ink_code = MasterEntity.ink_code;
                    item.parametervalue = MasterEntity.parametervalue;
                    item.price= MasterEntity.price;
                    item.PropertyChanged += EntityViewModelPropertyChanged;
                }
                if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = ItemsEntity[dgSelectedIndexItem].HasErrors;
                }
            }
        }

        #region Validation
        private bool Validation()
        {

            if (MasterEntity.supplier_id == null || MasterEntity.supplier_id == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Supplier ID Is Required", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            if (ItemsEntity.Count < 1)
            {

                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("please select Customer ........");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.ItemCode == null || MasterEntity.ItemCode == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Item Code Is Required", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.ink_code == null || MasterEntity.ink_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Ink Code Is Required", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            // Validation for Customer Details
            foreach (var o in ItemsEntity)
            {
                int flag = 0;
                if (o.id == 0)
                {
                    foreach (var p in ItemsEntity)
                    {
                        if (o.customer_id == p.customer_id)
                        {
                            flag++;
                        }
                    }
                    if (flag > 1)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Cannot Save Duplicate Customer ", o.customer_id);
                        showMessageService.ShowMessage();
                        return false;
                    }
                }

               
                       
                   
            }

            return true;
        }

        #endregion

        #region Filters

        private string _FilterStringFlipGridData;
        public string FilterStringFlipGridData
        {
            get { return _FilterStringFlipGridData; }
            set
            {
                _FilterStringFlipGridData = value;
                RaisePropertyChanged("FilterStringFlipGridData");
                Filter_FlipGridCollection();
            }
        }
        private void Filter_FlipGridCollection()
        {
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGridData(object obj)
        {
            var data = obj as ZADM_M026Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringFlipGridData))
                {
                    return (data.id != null && data.id.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.supplier_id != null && data.supplier_id.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.SupplierNm != null && data.SupplierNm.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.customer_id != null && data.customer_id.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.CustomerNm != null && data.CustomerNm.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterStringSupplier;
        public string filterStringSupplier
        {
            get { return _filterStringSupplier; }
            set
            {
                _filterStringSupplier = value;
                RaisePropertyChanged("filterStringSupplier");
                Filter_SupplierCollection();
            }
        }
        private void Filter_SupplierCollection()
        {
            if (_SupplierCollection != null)
            {
                _SupplierCollection.Refresh();
            }
        }
        public bool Filter_Supplier(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(filterStringSupplier))
                {
                    return (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterStringSupplier.ToLower())) ||
                           (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterStringSupplier.ToLower())) ||
                            (data.EmailId != null && data.EmailId.ToString().ToLower().Contains(_filterStringSupplier.ToLower())) ||
                             (data.curr_code != null && data.curr_code.ToString().ToLower().Contains(_filterStringSupplier.ToLower()));

                }
                return true;
            }
            return false;
        }

        private string _filterStringCustomer;
        public string filterStringCustomer
        {
            get { return _filterStringCustomer; }
            set
            {
                _filterStringCustomer = value;
                RaisePropertyChanged("filterStringCustomer");
                Filter_CustomerCollection();
            }
        }
        private void Filter_CustomerCollection()
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
                if (!string.IsNullOrEmpty(filterStringCustomer))
                {
                    return (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterStringCustomer.ToLower())) ||
                           (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterStringCustomer.ToLower())) ||
                            (data.EmailId != null && data.EmailId.ToString().ToLower().Contains(_filterStringCustomer.ToLower())) ||
                             (data.curr_code != null && data.curr_code.ToString().ToLower().Contains(_filterStringCustomer.ToLower()));

                }
                return true;
            }
            return false;
        }

        private string _filterStringItem;
        public string filterStringItem
        {
            get { return _filterStringItem; }
            set
            {
                _filterStringItem = value;
                RaisePropertyChanged("filterStringItem");
                Filter_ItemCollection();
            }
        }
        private void Filter_ItemCollection()
        {
            if (_ItemCollection != null)
            {
                _ItemCollection.Refresh();
            }
        }
        public bool Filter_Item(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(filterStringItem))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringItem.ToLower())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterStringItem.ToLower())) ||
                            (data.SubCatCode != null && data.SubCatCode.ToString().ToLower().Contains(_filterStringItem.ToLower())) ||
                             (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringItem.ToLower()));

                }
                return true;
            }
            return false;
        }

        private string _filterStringParameter;
        public string filterStringParameter
        {
            get { return _filterStringParameter; }
            set
            {
                _filterStringParameter = value;
                RaisePropertyChanged("filterStringParameter");
                Filter_ParameterCollection();
            }
        }
        private void Filter_ParameterCollection()
        {
            if (_ParameterCollection != null)
            {
                _ParameterCollection.Refresh();
            }
        }
        public bool Filter_Parameter(object obj)
        {
            var data = obj as ADM_M031_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(filterStringParameter))
                {
                    return (data.para_code != null && data.para_code.ToString().ToLower().Contains(_filterStringParameter.ToLower())) ||
                           (data.para_name != null && data.para_name.ToString().ToLower().Contains(_filterStringParameter.ToLower())) ||
                           (data.SubCatCode != null && data.SubCatCode.ToString().ToLower().Contains(_filterStringParameter.ToLower()));

                }
                return true;
            }
            return false;
        }

        private string _filterStringParameterValue;
        public string filterStringParameterValue
        {
            get { return _filterStringParameterValue; }
            set
            {
                _filterStringParameterValue = value;
                RaisePropertyChanged("filterStringParameterValue");
                Filter_ParameterValueCollection();
            }
        }
        private void Filter_ParameterValueCollection()
        {
            if (_ParameterValueCollection != null)
            {
                _ParameterValueCollection.Refresh();
            }
        }
        public bool Filter_ParameterValue(object obj)
        {
            var data = obj as ADM_M030_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(filterStringParameterValue))
                {
                    return (data.value_code != null && data.value_code.ToString().ToLower().Contains(_filterStringParameterValue.ToLower())) ||
                           (data.para_code != null && data.para_code.ToString().ToLower().Contains(_filterStringParameterValue.ToLower())) ||
                           (data.parametervalue != null && data.parametervalue.ToString().ToLower().Contains(_filterStringParameterValue.ToLower()));

                }
                return true;
            }
            return false;
        }


        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<ZADM_M026> result)
        {

            isNewRecord = true;
            MasterEntity = new ZADM_M026();
            ItemsEntity = new ObservableCollection<ZADM_M026>();
            DefaultValues();

        }

        protected override void OnDiscardAction(InquiryActionResult<ZADM_M026> result)
        {
           
        }

        protected override void OnFevoriteAction(InquiryActionResult<ZADM_M026> result)
        {
            
        }

        protected override void OnFlipAction(InquiryActionResult<ZADM_M026> result)
        {
            
        }

        protected override void OnHelpAction(InquiryActionResult<ZADM_M026> result)
        {
           
        }

        protected override void OnPrintAction(InquiryActionResult<ZADM_M026> result)
        {
           
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ZADM_M026> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ZADM_M026> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ZADM_M026> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ZADM_M026> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ZADM_M026> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnRemoveAction(InquiryActionResult<ZADM_M026> result)
        {
        //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //    showMessageService.ButtonSetup = DialogButton.Ok;
        //    showMessageService.Caption = "Delete Changes";
        //    showMessageService.Text =
        //        String.Format(
        //            "This record will be Deleted forever '{0}'",
        //                this.Title);
        //    if (showMessageService.ShowMessage() == DialogResult.Ok)
        //    {
        //        this.MasterEntity.EndEdit();
        //        string response = repository.Delete(MasterEntity.id, "InkCatalog", "Administration");

        //        MasterEntity = new ZADM_M026();
        //        isNewRecord = true;

        //    }
        }

        protected override void OnSaveAction(InquiryActionResult<ZADM_M026> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.XmlDataDocument_ItemsEntity = obj.ObjectToXML(ItemsEntity);
                    this.MasterEntity.EndEdit();

                    if (isNewRecord == true)
                    {
                        //if(dgSelectedIndexItem>=0)
                        //{
                        //    ItemsEntity.Add(new ZADM_M026()
                        //    {
                        //        supplier_id = MasterEntity.supplier_id,
                        //        SupplierNm = MasterEntity.SupplierNm,
                        //    });
                        //}

                        MasterEntity= repository.SaveWithReturnDomainObject<ZADM_M026>(MasterEntity, "InkCatalog", "Administration");
                       

                     
                    }

                    else if (isNewRecord == false)
                    {

                        MasterEntity = repository.UpdateWithReturnDomainObject<ZADM_M026>(MasterEntity, "InkCatalog", "Administration");
                        //if (ItemsEntity[dgSelectedIndexItem].id != 0)
                        //{
                        //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        //    showMessageService.ButtonSetup = DialogButton.Ok;
                        //    showMessageService.Caption = "Message";
                        //    showMessageService.Text = String.Format("Data Updated Successfully");
                        //    showMessageService.ShowMessage();
                        //}
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    isNewRecord = false;
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
            if (MasterEntity.XmlDataDocument_ItemsEntity != null)
            {
                ItemsEntity.Clear();
                ItemsEntity = (ObservableCollection<ZADM_M026>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ItemsEntity, MC.ItemEntity);
            }
            else
            {
                MC.ItemEntity = new ObservableCollection<ZADM_M026>();
            }
            //ItemsEntity = MC.ItemEntity;
            MasterEntity.supplier_id = ItemsEntity[dgSelectedIndexItem].supplier_id;
            MasterEntity.ItemCode = ItemsEntity[dgSelectedIndexItem].ItemCode;
            MasterEntity.ink_code = ItemsEntity[dgSelectedIndexItem].ink_code;
            MasterEntity.SupplierNm = ItemsEntity[dgSelectedIndexItem].SupplierNm;
            MasterEntity.ItemNm = ItemsEntity[dgSelectedIndexItem].ItemNm;
            MasterEntity.parametervalue = ItemsEntity[dgSelectedIndexItem].parametervalue;
            MasterEntity.price = ItemsEntity[dgSelectedIndexItem].price;
            if (ItemsEntity[dgSelectedIndexItem].id != 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Data Saved Successfully");
                showMessageService.ShowMessage();
            }

        }

        



        #endregion
    }
}
