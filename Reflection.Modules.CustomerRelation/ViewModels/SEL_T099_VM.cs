using Reflection.BusinessEntity.CustomerRelation;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class SEL_T099_VM : WorkspaceViewModel<SEL_T099>
    {
        #region Declaration
        bool isNewRecord = true;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        WebServiceRepository<SEL_T099> repository = new WebServiceRepository<SEL_T099>();
        WebServiceRepository<MultipleContext_SEL_T099> repository_MC = new WebServiceRepository<MultipleContext_SEL_T099>();
        WebServiceRepository<MultipleContext_SEL_T099> repository_MCTemp = new WebServiceRepository<MultipleContext_SEL_T099>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_SEL_T099 _MC = new MultipleContext_SEL_T099();
        public MultipleContext_SEL_T099 MC
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

        private MultipleContext_SEL_T099 _MCTemp = new MultipleContext_SEL_T099();
        public MultipleContext_SEL_T099 MCTemp
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

        private SEL_T099 _MasterEntity;
        public SEL_T099 MasterEntity
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

        private ObservableCollection<SEL_T099_A> _ItemsEntity;
        public ObservableCollection<SEL_T099_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value; RaisePropertyChanged("ItemsEntity");
                    RaisePropertyChanged("ItemsEntity");

                }
            }
        }
        private bool _IsDocumentViewerShow;
        public bool IsDocumentViewerShow
        {
            get
            {
                return _IsDocumentViewerShow;
            }
            set
            {
                if (_IsDocumentViewerShow != value)
                {
                    _IsDocumentViewerShow = value;
                    RaisePropertyChanged("IsDocumentViewerShow");
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
        NumberToEnglish num = new NumberToEnglish();
        #endregion

        #region List
        private List<SEL_T099_Flip> _FlipGridData;
        public List<SEL_T099_Flip> FlipGridData
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

        private ICollectionView _CustomerCollection;
        public ICollectionView CustomerCollection
        {
            get { return _CustomerCollection; }
            set { _CustomerCollection = value; RaisePropertyChanged("CustomerCollection"); }
        }
        private ICollectionView _InvoiceCollection;
        public ICollectionView InvoiceCollection
        {
            get { return _InvoiceCollection; }
            set { _InvoiceCollection = value; RaisePropertyChanged("InvoiceCollection"); }
        }
        private ICollectionView _popupItemCollection;
        public ICollectionView PopupItemCollection
        {
            get { return _popupItemCollection; }
            set { _popupItemCollection = value; RaisePropertyChanged("PopupItemCollection"); }
        }
        private ICollectionView _uomCollection;
        public ICollectionView UomCollection
        {
            get { return _uomCollection; }
            set { _uomCollection = value; RaisePropertyChanged("UomCollection"); }
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
        #endregion

        #region StringList
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
        List<string> _StringListInvoice;
        public List<string> StringListInvoice
        {
            get { return _StringListInvoice; }
            set
            {
                if (_StringListInvoice != value)
                {
                    _StringListInvoice = value;
                }
            }
        }
        private List<string> _strListUOM;
        public List<string> StringListUOM
        {
            get { return _strListUOM; }
            set
            {
                if (_strListUOM != value)
                {
                    _strListUOM = value;
                }
            }
        }
        private List<string> _strListItems;
        public List<string> StringListItems
        {
            get { return _strListItems; }
            set
            {
                if (_strListItems != value)
                {
                    _strListItems = value;
                }
            }
        }
        #endregion

        #region Filters
        // Filter For BackFlip

        private string _FilterStringFlipGridData;
        public string FilterStringFlipGridData
        {
            get { return _FilterStringFlipGridData; }
            set
            {
                _FilterStringFlipGridData = value;
                RaisePropertyChanged("FilterStringFlipGridData");
                Filter_FlipGrid();
            }
        }
        private void Filter_FlipGrid()
        {
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as SEL_T099_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringFlipGridData))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.invoice_no != null && data.invoice_no.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.CustomerNm != null && data.CustomerNm.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower()));
                }
                return true;
            }
            return false;
        }

        //Filter For Party
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

        //Filter For Invoice

        private string _FilterStringInvoice;
        public string FilterStringInvoice
        {
            get { return _FilterStringInvoice; }
            set
            {
                _FilterStringInvoice = value;
                RaisePropertyChanged("FilterStringInvoice");
                Filter_Invoice();
            }
        }
        private void Filter_Invoice()
        {
            if (_InvoiceCollection != null)
            {
                _InvoiceCollection.Refresh();
            }
        }
        public bool Filter_Invoice(object obj)
        {
            var data = obj as SEL_T003_POP;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringInvoice))
                {
                    return (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_FilterStringInvoice.ToLower())) ||
                           (data.bill_doc != null && data.bill_doc.ToString().ToLower().Contains(_FilterStringInvoice.ToLower())) ||
                           (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_FilterStringInvoice.ToLower())) ||
                           (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FilterStringInvoice.ToLower())) ||
                           (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_FilterStringInvoice.ToLower())) ||
                           (data.CustomerNm != null && data.CustomerNm.ToString().ToLower().Contains(_FilterStringInvoice.ToLower()));

                }
                return true;
            }
            return false;
        }
        //Filter For Items

        private string _filterString_ItemsListPopup;
        public string FilterString_ItemsListPopup
        {
            get { return _filterString_ItemsListPopup; }
            set
            {
                _filterString_ItemsListPopup = value;
                RaisePropertyChanged("FilterString_ItemsListPopup");
                FilterCollection_ItemsListPopup();
            }
        }
        private void FilterCollection_ItemsListPopup()
        {
            if (_popupItemCollection != null)
            {
                _popupItemCollection.Refresh();
            }
        }
        public bool Filter_ItemsListPopup(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_ItemsListPopup))
                {
                    return (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower()) ||
                           (data.SubCatCode != null && data.SubCatCode.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower())) ||
                            data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_ItemsListPopup.ToLower()));
                }
                return true;
            }
            return false;
        }

        //Filter For Unit
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
        public bool Filter_UOM(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_UOM))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_UOM.ToLower()) ||
                           (data.unit_abbrv != null && data.unit_abbrv.ToString().ToLower().Contains(_filterString_UOM.ToLower()) ||
                            data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterString_UOM.ToLower())));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Relay Command      
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> CmdAddCustomer { get; private set; }
        public RelayCommand<object> CmdAddInvoice { get; private set; }
        public RelayCommand<object> CmdAddItem { get; private set; }
        public RelayCommand<object> CmdAddUnit { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByDocumentNumber { get; private set; }

        #endregion

        #region Constructor
        public SEL_T099_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            IsDocumentViewerShow = false;
            MasterEntity = new SEL_T099();
            ItemsEntity = new ObservableCollection<SEL_T099_A>();
            FlipGridData = new List<SEL_T099_Flip>();
            MC = new MultipleContext_SEL_T099();
            MCTemp = new MultipleContext_SEL_T099();
            MasterEntity.ValidateAsync().Wait();
            SEL_T099.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            SEL_T099_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            LoadInitialData();

        }
        public SEL_T099_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            IsDocumentViewerShow = false;
            MasterEntity = new SEL_T099();
            ItemsEntity = new ObservableCollection<SEL_T099_A>();
            FlipGridData = new List<SEL_T099_Flip>();
            MC = new MultipleContext_SEL_T099();
            MCTemp = new MultipleContext_SEL_T099();
            MasterEntity.ValidateAsync().Wait();
            SEL_T099.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            SEL_T099_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            LoadInitialData();

        }
        private void LoadInitialData()
        {
            try
            {
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CmdAddCustomer = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCustomer(cmdPara, true, true, true); });
                CmdAddInvoice = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertInvoice(cmdPara, false, true, true); });
                CmdAddItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara, true, true, true); });
                CmdAddUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUnit(cmdPara, true, true, true); });
                CommandLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CmdDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });


                MasterEntity.doc_cat = "WE";
                MasterEntity.doc_type = "WE";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T099>(MC, Request, "Wastage_Entry", "CRM", " ", 0, "");

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

                CustomerCollection = CollectionViewSource.GetDefaultView(MC.CustomerDetails);
                CustomerCollection.Filter = new Predicate<object>(Filter_Customer);
                StringListCustomer = MC.CustomerDetails.Select(x => x.PartyId.ToString()).ToList();

                InvoiceCollection = CollectionViewSource.GetDefaultView(MC.InvoiceNoDetails);
                InvoiceCollection.Filter = new Predicate<object>(Filter_Invoice);
                StringListInvoice = MC.InvoiceNoDetails.Select(x => x.bill_doc.ToString()).ToList();

                PopupItemCollection = CollectionViewSource.GetDefaultView(MC.ItemDetails);
                PopupItemCollection.Filter = new Predicate<object>(Filter_ItemsListPopup);
                StringListItems = MC.ItemDetails.Select(x => x.ItemCode.ToString()).ToList();

                UomCollection = CollectionViewSource.GetDefaultView(MC.UomDetails);
                UomCollection.Filter = new Predicate<object>(Filter_UOM);
                StringListUOM = MC.UomDetails.Select(x => x.unit_code.ToString()).ToList();

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

        #region Event Handler
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            //this.ErrorExist = MasterEntity.HasErrors;
            if (sender.ToString() == "para3")
            {

                if (MasterEntity.para3 > 0)
                {
                    MasterEntity.amt_in_words = num.AmountInWords(Convert.ToDecimal(MasterEntity.para3));
                }
                else
                {
                    MasterEntity.amt_in_words = "";
                }
            }

        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            //this.ErrorExist = MasterEntity.HasErrors; 
            //if (sender.ToString() == "quantity" || sender.ToString() == "rate" || sender.ToString() == "active")
            //{
            //    //CalSubTotal();
            //    CalGrandTotal(true);
            //}
            if (sender.ToString() == "subtotal" || sender.ToString() == "active")
            {
                CalGrandTotal(true);
            }
            this.ErrorExist = false;/*MasterEntity.HasErrors;*/
            if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = ItemsEntity[dgSelectedIndexItem].HasErrors;
            }
        }
        #endregion

        #region User Defined Functions
        private void DefaultValues()
        {
            MasterEntity.doc_cat = "WE";
            MasterEntity.doc_type = "WE";
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.t_status = "Draft";
            MasterEntity.doc_no = "";
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.active = true;
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.client = AppSessionState.client;
        }
        private bool Validation()
        {
            if (ItemsEntity.Count < 1)
            {

                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Atleast One Record In Wastage Detail...");
                showMessageService.ShowMessage();
                return false;
            }
            if (dgSelectedIndexItem != -1)
            {
                foreach (var o in ItemsEntity)
                {
                    if (o.invoice_no == null || o.invoice_no == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Invoice Number Is Required", this.Title);
                        showMessageService.ShowMessage();
                        return false;
                    }
                }
            }


            return true;
        }
        #endregion

        #region Relay Command Implementation
        private void InsertCustomer(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    { POPUPEntityObject = MC.CustomerDetails.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    ItemsEntity.Add(new SEL_T099_A()
                    {
                        id = 0,
                        active = true,
                        PartyId = POPUPEntityObject.PartyId,
                        CustomerNm = POPUPEntityObject.PartyNm,
                        location_Id = AppSessionState.location_Id,
                        comp_code = AppSessionState.comp_code,
                        t_status = "Draft",
                        add_by = AppSessionState.UserID,
                        editby = AppSessionState.UserID
                    });
                }
                else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        ItemsEntity[dgSelectedIndexItem].PartyId = POPUPEntityObject.PartyId;
                        ItemsEntity[dgSelectedIndexItem].CustomerNm = POPUPEntityObject.PartyNm;
                        ItemsEntity[dgSelectedIndexItem].active = true;

                    }
                    else if (ItemsEntity[dgSelectedIndexItem].PartyId != POPUPEntityObject.PartyId)
                    {
                        ItemsEntity[dgSelectedIndexItem].PartyId = POPUPEntityObject.PartyId;
                        ItemsEntity[dgSelectedIndexItem].CustomerNm = POPUPEntityObject.PartyNm;
                    }
                }
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
        private void InsertInvoice(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            SEL_T003_POP POPUPEntityObject = null;

            //Command Parameter Read section

            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    { POPUPEntityObject = MC.InvoiceNoDetails.Where(x => x.bill_doc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                    catch (Exception ex) { }
                }
            }
            else if (InputValue != null)
            {
                if (((IEnumerable)InputValue).Cast<SEL_T003_POP>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T003_POP>().ToList()[0];
                }

            }

            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(x => x.invoice_no == POPUPEntityObject.bill_doc).FirstOrDefault();
                var IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.invoice_no == POPUPEntityObject.bill_doc).FirstOrDefault());

                if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                {
                    ItemsEntity.Add(new SEL_T099_A()
                    {
                        id = 0,
                        active = true,
                        invoice_no = POPUPEntityObject.bill_doc,
                        ref_doc_cat = POPUPEntityObject.ref_doc_cat,
                        ref_doc_type = POPUPEntityObject.ref_doc_type,
                        ref_doc_date = POPUPEntityObject.ref_doc_date,
                        location_Id = AppSessionState.location_Id,
                        comp_code = AppSessionState.comp_code,
                        t_status = "Draft",
                        add_by = AppSessionState.UserID,
                        editby = AppSessionState.UserID
                    });
                }
                else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        ItemsEntity[dgSelectedIndexItem].invoice_no = POPUPEntityObject.bill_doc;
                        ItemsEntity[dgSelectedIndexItem].ref_doc_cat = POPUPEntityObject.ref_doc_cat;
                        ItemsEntity[dgSelectedIndexItem].ref_doc_type = POPUPEntityObject.ref_doc_type;
                        ItemsEntity[dgSelectedIndexItem].ref_doc_date = POPUPEntityObject.ref_doc_date;
                        //ItemsEntity[dgSelectedIndexItem].PartyId = POPUPEntityObject.PartyId;
                        // ItemsEntity[dgSelectedIndexItem].CustomerNm = POPUPEntityObject.CustomerNm;
                        ItemsEntity[dgSelectedIndexItem].active = true;

                    }
                    else if (ItemsEntity[dgSelectedIndexItem].PartyId != POPUPEntityObject.PartyId)
                    {
                        ItemsEntity[dgSelectedIndexItem].invoice_no = POPUPEntityObject.bill_doc;
                        ItemsEntity[dgSelectedIndexItem].ref_doc_cat = POPUPEntityObject.ref_doc_cat;
                        ItemsEntity[dgSelectedIndexItem].ref_doc_type = POPUPEntityObject.ref_doc_type;
                        ItemsEntity[dgSelectedIndexItem].ref_doc_date = POPUPEntityObject.ref_doc_date;
                        //ItemsEntity[dgSelectedIndexItem].PartyId = POPUPEntityObject.PartyId;
                        //ItemsEntity[dgSelectedIndexItem].CustomerNm = POPUPEntityObject.CustomerNm;
                    }
                }
            }
        }
        private void InsertItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M022_P POPUPEntityObject = null;

            //Command Parameter Read section

            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    { POPUPEntityObject = MC.ItemDetails.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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

            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                var IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());

                if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                {
                    ItemsEntity.Add(new SEL_T099_A()
                    {
                        id = 0,
                        active = true,
                        ItemCode = POPUPEntityObject.ItemCode,
                        Description = POPUPEntityObject.ItemName,
                        location_Id = AppSessionState.location_Id,
                        comp_code = AppSessionState.comp_code,
                        t_status = "Draft",
                        add_by = AppSessionState.UserID,
                        editby = AppSessionState.UserID
                    });
                }
                else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        ItemsEntity[dgSelectedIndexItem].ItemCode = POPUPEntityObject.ItemCode;
                        ItemsEntity[dgSelectedIndexItem].Description = POPUPEntityObject.ItemName;
                        ItemsEntity[dgSelectedIndexItem].active = true;

                    }
                    else if (ItemsEntity[dgSelectedIndexItem].ItemCode != POPUPEntityObject.ItemCode)
                    {
                        ItemsEntity[dgSelectedIndexItem].ItemCode = POPUPEntityObject.ItemCode;
                        ItemsEntity[dgSelectedIndexItem].Description = POPUPEntityObject.ItemName;
                    }
                }
            }
        }
        private void InsertUnit(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M038_B_P POPUPEntityObject = null;

            //Command Parameter Read section

            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    { POPUPEntityObject = MC.UomDetails.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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

            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(x => x.unit_code == POPUPEntityObject.unit_code).FirstOrDefault();
                var IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault());

                if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                {
                    ItemsEntity.Add(new SEL_T099_A()
                    {
                        id = 0,
                        active = true,
                        unit_code = POPUPEntityObject.unit_code,
                        location_Id = AppSessionState.location_Id,
                        comp_code = AppSessionState.comp_code,
                        t_status = "Draft",
                        add_by = AppSessionState.UserID,
                        editby = AppSessionState.UserID
                    });
                }
                else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        // ItemsEntity[dgSelectedIndexItem].Description = POPUPEntityObject.ItemName;
                        ItemsEntity[dgSelectedIndexItem].active = true;

                    }
                    else if (ItemsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                    {
                        ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        //ItemsEntity[dgSelectedIndexItem].Description = POPUPEntityObject.ItemName;
                    }
                }
            }
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";

                SEL_T099_Flip ParameterEntityObject = null;
                MasterEntity = new SEL_T099();
                ItemsEntity = new ObservableCollection<SEL_T099_A>();

                if (((IEnumerable)ParameterObject).Cast<SEL_T099_Flip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<SEL_T099_Flip>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.doc_no;
                    SelectedTabControlIndex = 0;
                    isNewRecord = false;

                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T099>(MCTemp, Request, "Wastage_Entry", "CRM", "LoadDocumentByDocumentNumber", 0, "");
                    if (MCTemp.MasterEntity.Count > 0)
                    {
                        MasterEntity = MCTemp.MasterEntity[0];
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("This Record Is Inactive...");
                        showMessageService.ShowMessage();
                    }
                   
                    ItemsEntity = MCTemp.ItemsEntity;

                    CalGrandTotal(true);
                    if (MasterEntity.para3 > 0)
                    {
                        MasterEntity.amt_in_words = num.AmountInWords(Convert.ToDecimal(MasterEntity.para3));
                    }
                    else
                    {
                        MasterEntity.amt_in_words = "";
                    }

                    if (MCTemp.Attachment != null)
                    {
                        AttachmentCollection = MCTemp.Attachment;
                    }
                    else
                    {
                        MCTemp.Attachment = new List<COM_T003>();
                    }

                }
                MasterEntity.ts_code = ts_code_vm;
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

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<SEL_T099> result)
        {
            isNewRecord = true;
            MasterEntity = new SEL_T099();
            MasterEntity.ValidateAsync().Wait();
            ItemsEntity = new ObservableCollection<SEL_T099_A>();

            FlipDataGridCollection.Refresh();

            DefaultValues();
        }

        protected override void OnDiscardAction(InquiryActionResult<SEL_T099> result)
        {
           
        }

        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.doc_no.ToString()))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.ToString(), DocumentList = MCTemp.Attachment, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<SEL_T099> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<SEL_T099> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<SEL_T099> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<SEL_T099> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<SEL_T099> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<SEL_T099> result)
        {
          
        }

        protected override void OnFlipAction(InquiryActionResult<SEL_T099> result)
        {
           
        }

        protected override void OnHelpAction(InquiryActionResult<SEL_T099> result)
        {
           
        }

        protected override void OnPrintAction(InquiryActionResult<SEL_T099> result)
        {
           
        }

        protected override void OnRemoveAction(InquiryActionResult<SEL_T099> result)
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
                string response = repository.Delete(MasterEntity.doc_no, "Wastage_Entry", "CRM");


                MasterEntity = new SEL_T099();
                ItemsEntity = new ObservableCollection<SEL_T099_A>();

                isNewRecord = true;

                FlipDataGridCollection.Refresh();
            }
        }

        protected override void OnSaveAction(InquiryActionResult<SEL_T099> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.XmlDataDocument_SEL_T099_A = obj.ObjectToXML(ItemsEntity);

                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<SEL_T099>(MasterEntity, "Wastage_Entry", "CRM");

                        if (MasterEntity.doc_no != null || MasterEntity.doc_no != " ")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Data Saved Successfully");
                            showMessageService.ShowMessage();
                        }
                    }

                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<SEL_T099>(MasterEntity, "Wastage_Entry", "CRM");

                        if (MasterEntity.doc_no != null || MasterEntity.doc_no != " ")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Data Updated Successfully");
                            showMessageService.ShowMessage();
                        }
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    CalGrandTotal(true);
                    if (MasterEntity.para3 > 0)
                    {

                        MasterEntity.amt_in_words = num.AmountInWords(Convert.ToDecimal(MasterEntity.para3));
                    }
                    else
                    {
                        MasterEntity.amt_in_words = "";
                    }

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
            if (MasterEntity.XmlDataDocument_FlipGrid != null && isNewRecord == true && ParameterOption1 == "Save")
            {
                MC.DocumentDataFlipGrid = (List<SEL_T099_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                FlipDataGridCollection.Refresh();
                FlipDataGridCollection.SortDescriptions.Add(new SortDescription("doc_no", ListSortDirection.Descending));
            }
            if (MasterEntity.XmlDataDocument_SEL_T099_A != null)
            {
                ItemsEntity.Clear();
                ItemsEntity = (ObservableCollection<SEL_T099_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_SEL_T099_A, MC.ItemsEntity);

            }
            else
            {
                MC.ItemsEntity = new ObservableCollection<SEL_T099_A>();
            }
            MasterEntity.ts_code = ts_code_vm;
        }
        //private void CalSubTotal()
        //{
        //    try
        //    {

        //        decimal? quantity = 0;
        //        decimal? rate = 0;
        //        if (dgSelectedIndexItem != -1 && ItemsEntity.Count > 0)
        //        {
        //            if (ItemsEntity[dgSelectedIndexItem].quantity != null)
        //            {
        //                if (ItemsEntity[dgSelectedIndexItem].rate != null && ItemsEntity[dgSelectedIndexItem].rate != 0)
        //                {

        //                    ItemsEntity[dgSelectedIndexItem].subtotal = Convert.ToDecimal(ItemsEntity[dgSelectedIndexItem].quantity) * Convert.ToDecimal(ItemsEntity[dgSelectedIndexItem].rate);
        //                }

        //            }
        //        }
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
        private void CalGrandTotal(bool compute)
        {
            try
            {
                if (compute == true)
                {
                    MasterEntity.para3 = 0;
                    if (ItemsEntity.Count > 0)
                    {
                        for (int i = 0; i < ItemsEntity.Count; i++)
                        {
                            //if (ItemsEntity[i].subtotal == null)
                            //{
                            //    ItemsEntity[i].subtotal = 0;
                            //}
                            if (ItemsEntity[i].active == true)
                            {
                                MasterEntity.para3 = MasterEntity.para3 + Convert.ToDecimal(ItemsEntity[i].subtotal);
                            }
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

        
        #endregion
    }
}
