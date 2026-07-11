using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.MM;
using Reflection.BusinessEntity.SCM;
using Reflection.Presentation.Common;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Reflection.Modules.MM.ViewModels
{
    class MM_T009_VM : WorkspaceViewModel<MM_S010>
    {
        #region Variable Declaration
        bool isNewRecord = true;
        WebServiceRepository<MC_MM_S010> REPOSITORY = new WebServiceRepository<MC_MM_S010>();
        WebServiceRepository<STD_MIS_MC_BE> REPO_TEMP = new WebServiceRepository<STD_MIS_MC_BE>();
        ObjectSerializationService obj = new ObjectSerializationService();

        public string ts_code_vm { get; set; }
        public string doc_cat_vm { get; set; }
        public string doc_type_vm { get; set; }
        public string doc_no_vm { get; set; }

        private MC_MM_S010 _MC = new MC_MM_S010();
        public MC_MM_S010 MC
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

        private MC_MM_S010 _MCTEMP = new MC_MM_S010();
        public MC_MM_S010 MCTEMP
        {
            get { return _MCTEMP; }
            set
            {
                if (_MCTEMP != value)
                {
                    _MCTEMP = value; RaisePropertyChanged("MCTEMP");
                }
            }
        }

        private STD_MIS_MC_BE _MC_MIS = new STD_MIS_MC_BE();
        public STD_MIS_MC_BE MC_MIS
        {
            get { return _MC_MIS; }
            set
            {
                if (_MC_MIS != value)
                {
                    _MC_MIS = value; RaisePropertyChanged("MC_MIS");
                }
            }
        }

        private MM_S010 _MasterEntity;
        public MM_S010 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged("MasterEntity");
                }
            }
        }

        private ObservableCollection<MM_S010_A> _ItemsEntity;
        public ObservableCollection<MM_S010_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value;
                    ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("ItemsEntity");
                }
            }
        }

        private MM_S010_A _ItemsEntityObj;
        public MM_S010_A ItemsEntityObj
        {
            get { return _ItemsEntityObj; }
            set
            {
                if (_ItemsEntityObj != value)
                {
                    _ItemsEntityObj = value;
                    RaisePropertyChanged("ItemsEntityObj");
                }
            }
        }

        private STD_REQ_PARA_BE _REQ_PARA;
        public STD_REQ_PARA_BE REQ_PARA
        {
            get { return _REQ_PARA; }
            set
            {
                if (_REQ_PARA != value)
                {
                    _REQ_PARA = value;
                    RaisePropertyChanged("REQ_PARA");
                }
            }
        }

        private STD_DOC_TYPE _DOC_TYPE_OBJ;
        public STD_DOC_TYPE DOC_TYPE_OBJ
        {
            get { return _DOC_TYPE_OBJ; }
            set
            {
                if (_DOC_TYPE_OBJ != value)
                {
                    _DOC_TYPE_OBJ = value;
                    RaisePropertyChanged(nameof(DOC_TYPE_OBJ));
                }
            }
        }

        private IEnumerable _BATCH_LIST;
        public IEnumerable BATCH_LIST
        {
            get { return _BATCH_LIST; }
            set
            {
                _BATCH_LIST = value;

                RaisePropertyChanged("BATCH_LIST");
            }
        }

        private IEnumerable _STORE_LIST;
        public IEnumerable STORE_LIST
        {
            get { return _STORE_LIST; }
            set
            {
                _STORE_LIST = value;

                RaisePropertyChanged("STORE_LIST");
            }
        }

        private IEnumerable _ITEM_LIST;
        public IEnumerable ITEM_LIST
        {
            get { return _ITEM_LIST; }
            set
            {
                _ITEM_LIST = value;

                RaisePropertyChanged("ITEM_LIST");
            }
        }

        private IEnumerable _UNIT_LIST;
        public IEnumerable UNIT_LIST
        {
            get { return _UNIT_LIST; }
            set
            {
                _UNIT_LIST = value;

                RaisePropertyChanged("UNIT_LIST");
            }
        }

        private IEnumerable _CAT_LIST;
        public IEnumerable CAT_LIST
        {
            get { return _CAT_LIST; }
            set
            {
                _CAT_LIST = value;
                RaisePropertyChanged("CAT_LIST");
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

        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }

        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdExecuteLoadingItems { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> cmdLoadDocument { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdSelectAll { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        #endregion

        #region Constructor
        public MM_T009_VM(string ts_code,string doc_cat,string doc_type) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;
            this.doc_type_vm = doc_type;
            MasterEntity = new MM_S010();
            ItemsEntity = new ObservableCollection<MM_S010_A>();
            MC = new MC_MM_S010();
            MCTEMP = new MC_MM_S010();
            MC_MIS = new STD_MIS_MC_BE();
            REQ_PARA = new STD_REQ_PARA_BE();
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            MM_S010_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            InitializeCommands();
        }
        public MM_T009_VM(string ts_code, string doc_cat, string doc_type, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;
            this.doc_type_vm = doc_type;
            this.doc_no_vm = doc_no;
            MasterEntity = new MM_S010();
            ItemsEntity = new ObservableCollection<MM_S010_A>();
            MC = new MC_MM_S010();
            MCTEMP = new MC_MM_S010();
            MC_MIS = new STD_MIS_MC_BE();
            REQ_PARA = new STD_REQ_PARA_BE();
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            MM_S010_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            InitializeCommands();
        }
        #endregion

        #region Abstract Methods
        protected override void OnDocumentAction()
        {
        }
        protected override void OnSaveAction(InquiryActionResult<MM_S010> result)
        {
            List<MM_S010_A> SelectedItemList = new List<MM_S010_A>();
            if (ItemsEntity.Count > 0)
            {
                foreach (MM_S010_A item in ItemsEntity)
                {
                    if (item.check == true)
                    {
                        SelectedItemList.Add(item);
                    }
                }
            }

            if (Validation() == true)
            {
                try
                {
                    Logging();
                    MCTEMP = new MC_MM_S010();
                    MasterEntity.XmlDataDocument_MM_S010_A = obj.ObjectToXML(SelectedItemList);
                    this.MasterEntity.EndEdit();
                    MCTEMP.request = obj.ObjectToXML(MasterEntity);
                    
                    if (isNewRecord == true)
                    {
                        MCTEMP = REPOSITORY.SaveWithReturnDomainObject<MC_MM_S010>(MCTEMP, "MM_S010_BL", "MM");
                    }
                    else if (isNewRecord == false)
                    {
                        MCTEMP = REPOSITORY.UpdateWithReturnDomainObject<MC_MM_S010>(MCTEMP, "MM_S010_BL", "MM");
                    }
                    MasterEntity = MCTEMP.MasterEntityList[0];
                    ItemsEntity = MCTEMP.ItemEntityList;
                    isNewRecord = false;
                    if (MasterEntity.doc_no != null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
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
        }
        protected override void OnCreateAction(InquiryActionResult<MM_S010> result)
        {
            isNewRecord = true;
            MasterEntity = new MM_S010();
            DefaultValues();
            ItemsEntity = new ObservableCollection<MM_S010_A>();
        }
        protected override void OnRemoveAction(InquiryActionResult<MM_S010> result)
        {
        }
        protected override void OnDiscardAction(InquiryActionResult<MM_S010> result)
        { }
        protected override void OnPrintAction(InquiryActionResult<MM_S010> result)
        {
            MasterEntity = MasterEntity;
        }
        protected override void OnFlipAction(InquiryActionResult<MM_S010> result)
        { }
        protected override void OnHelpAction(InquiryActionResult<MM_S010> result)
        { }
        protected override void OnFevoriteAction(InquiryActionResult<MM_S010> result)
        {
        }
        protected override void OnRefreshCommand(InquiryActionResult<MM_S010> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnLedgerViewCommand(InquiryActionResult<MM_S010> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnValidateCommand(InquiryActionResult<MM_S010> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnTraceCommand(InquiryActionResult<MM_S010> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnMailCommand(InquiryActionResult<MM_S010> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region User Defined Functions
        private void DefaultValues()
        {
            MasterEntity.doc_cat = doc_cat_vm;
            MasterEntity.doc_type = doc_type_vm;
            MasterEntity.active = true;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.post_date = DateTime.Now;
            MasterEntity.plann_date = DateTime.Now;

            if (MC.STATUS_LIST != null)
            {
                if (MC.STATUS_LIST.Count > 0)
                {
                    MasterEntity.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
                    //MasterEntity.t_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_display).FirstOrDefault();
                }
            }
            if (MC.DOC_TYPE_LIST != null)
            {
                if (MC.DOC_TYPE_LIST.Count > 0)
                {
                    DOC_TYPE_OBJ = (from o in MC.DOC_TYPE_LIST where o.doc_cat == doc_cat_vm && o.default_doc == true select o).FirstOrDefault();
                }
            }
            if (DOC_TYPE_OBJ != null)
            {
                MasterEntity.doc_type = DOC_TYPE_OBJ.doc_type;
                //MasterEntity.doc_type_name = DOC_TYPE_OBJ.doc_type_name;
            }
            if (MC.STORE_LIST != null)
            {
                if (MC.STORE_LIST.Count > 0)
                {
                    MasterEntity.store_code = MC.STORE_LIST[0].store_code;
                }
            }

        }
        private void Logging()
        {
            MasterEntity.ts_code = this.ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;
        }
        private void InitializeCommands()
        {
            cmdExecuteLoadingItems = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteLoadingItems(items); });
            CmdDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
            cmdLoadDocument = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdSelectAll = new RelayCommand<object>(items => { if (items == null) { return; } SelectAll(items); });
            cmdLoadBackFlip = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlip(items); });

        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_type_vm;
                MC = REPOSITORY.GetDataWithReturnDomainObject<MC_MM_S010>(MC, Request, "MM_S010_BL", "MM", "LoadAll", 0, "");

                STORE_LIST = MC.STORE_LIST;
                UNIT_LIST = MC.UOM_LIST;
                CAT_LIST = MC.ITEM_CAT_LIST;

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
        private void ExecuteLoadingItems(object input)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(MasterEntity.store_code) || !MasterEntity.post_date.HasValue || !MasterEntity.doc_date.HasValue)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Store Code, Document and posting dates required", this.Title);
                    showMessageService.ShowMessage();
                }
                else
                {
                    CursorControl.SetBusyState();

                    string Request = "REPORT" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_type_vm + "!@MR02!@R0001!@R0005!@!@!@!@!@!@!@!@" + (REQ_PARA.item_cat ?? "") + "!@" + (REQ_PARA.item_subcat ?? "") + "!@" + (REQ_PARA.item_type ?? "") + "!@" + (REQ_PARA.item_subtype ?? "") + "!@!@!@!@!@!@!@" + (REQ_PARA.unit_code ?? "") + "!@!@" + Convert.ToDateTime(MasterEntity.post_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.post_date).ToString("MM/dd/yyyy") + "!@!@!@!@!@";
                    MC_MIS = REPO_TEMP.GetDataWithReturnDomainObject<STD_MIS_MC_BE>(MC_MIS, Request, "MM_R02", "MM", "", 0, "");

                    if (MC_MIS.STD_MIS_LIST != null)
                    {
                        if (MC_MIS.STD_MIS_LIST.Count > 0)
                        {
                            ItemsEntity.Clear();
                            foreach (STD_MIS_BE item in MC_MIS.STD_MIS_LIST)
                            {
                                MM_S010_A objNew = new MM_S010_A();
                                objNew.id = (item.id ?? 0);
                                objNew.ItemCode = item.item_code;
                                objNew.ItemName = item.item_name;
                                objNew.unit_code = item.unit_code;
                                objNew.batch_no = item.batch_no;
                                objNew.client = AppSessionState.client;
                                objNew.comp_code = item.comp_code;
                                objNew.location_Id = item.location_id;
                                objNew.store_code = (item.store_code ?? MasterEntity.store_code);
                                objNew.sku = item.sku;
                                objNew.post_date = MasterEntity.post_date;
                                objNew.item_counted = false;
                                objNew.difference_posted = false;
                                objNew.prebook_qty = item.closing_qty ?? 0;
                                objNew.quantity = item.qty ?? 0;
                                objNew.base_unit_code = item.unit_code; // NOTE: make this correct
                                objNew.qty_unit_entry = item.closing_qty ?? 0;
                                objNew.entry_unit = item.unit_code;
                                objNew.phy_count_value = item.closing_value ?? 0; // (item.qty * (item.closing_rate ?? 0));
                                objNew.book_value = item.closing_value ?? 0;
                                objNew.active = true;
                                objNew.rate = item.closing_rate ?? 0;
                                objNew.varience = 0;
                                objNew.check = false;
                                objNew.t_status = (item.t_status ?? MasterEntity.t_status);

                                ItemsEntity.Add(objNew);
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
                showMessageService.Text = String.Format(ex.InnerException.ToString(), this.Title);
                showMessageService.ShowMessage();
            }
        }
        //Below 4 methods are for calculations of physical stock
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add && ItemsEntity.Count > 0)
            {
                foreach (MM_S010_A item in e.NewItems)
                {
                    if (ItemsEntity.Count > 0) // && ItemsEntity.Count > dgSelectedIndexItem)
                    {
                        item.t_status = MasterEntity.t_status;
                        item.editby = AppSessionState.UserID;
                        item.location_Id = (MasterEntity.location_Id ?? AppSessionState.OBJ_LOCATION.location_id);
                        item.comp_code = (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code);
                    }
                }
            }
        }
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "prebook_qty" || e.PropertyName == "qty_unit_entry" || e.PropertyName == "rate")
            {
                Calculation(true);
            }
        }
        private void Calculation(bool compute)
        {
            try
            {
                if (compute == true)
                {
                    if (ItemsEntityObj != null && ItemsEntity.Count > 0)
                    {
                        for (int i = 0; i < ItemsEntity.Count; i++)
                        {
                            //ItemsEntity[i].active = true;
                            if (ItemsEntity[i].active != false)
                            {
                                ItemsEntity[i].qty_diff = (ItemsEntity[i].prebook_qty) - (ItemsEntity[i].qty_unit_entry);
                                ItemsEntity[i].shortage_access = (ItemsEntity[i].qty_unit_entry) - (ItemsEntity[i].prebook_qty);
                                if (ItemsEntity[i].prebook_qty != 0)
                                {
                                    ItemsEntity[i].varience = ((ItemsEntity[i].shortage_access) / (ItemsEntity[i].prebook_qty)) * 100;
                                }
                                ItemsEntity[i].book_value = (ItemsEntity[i].prebook_qty) * (ItemsEntity[i].rate);
                                ItemsEntity[i].phy_count_value = (ItemsEntity[i].qty_unit_entry) * (ItemsEntity[i].rate);
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
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            if (sender.ToString() == "qty_unit_entry" || sender.ToString() == "rate")
            {
                if (ItemsEntity.Count > 0 && ItemsEntityObj != null)
                {
                    ItemsEntityObj.active = true;
                    ItemsEntityObj.check = true;
                    Calculation(true);
                }
            }
        }
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i) // && ItemsEntity[dgSelectedIndexItem].id == 0)
                {
                    ItemsEntity.RemoveAt(i);
                    Calculation(true);
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
        private void LoadBackFlip(object input)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (REQ_PARA.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + REQ_PARA.active + "!@" + (REQ_PARA.t_status ?? "") + "!@" + Convert.ToDateTime(REQ_PARA.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA.to_date).ToString("MM/dd/yyyy");
                MCTEMP = REPOSITORY.GetDataWithReturnDomainObject<MC_MM_S010>(MCTEMP, Request, "MM_S010_BL", "MM", "LoadAll", 0, "");

                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MCTEMP.BACK_FLIP_LIST.ToList());
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(FLTR_BACKFLIP);

            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.InnerException.ToString(), this.Title);
                showMessageService.ShowMessage();
            }
        }

        private bool Validation()
        {
            if (string.IsNullOrWhiteSpace(MasterEntity.store_code))
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select store code");
                showMessageService.ShowMessage();
                return false;
            }
            if (!MasterEntity.doc_date.HasValue)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select document date");
                showMessageService.ShowMessage();
                return false;
            }
            if (!MasterEntity.post_date.HasValue)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Posting Date");
                showMessageService.ShowMessage();
                return false;
            }
            if (ItemsEntity.Count < 1)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Item is Required");
                showMessageService.ShowMessage();
                return false;
            }
            
            #region . Validation for Item Duplication, null Unit Code and Null or 0 Quantity For All Active Unsaved Items .
            foreach (var o in ItemsEntity)
            {
                int flag = 0;
                if (o.id == 0 && o.active == true)
                {
                    foreach (var p in ItemsEntity)
                    {
                        if (o.ItemCode == p.ItemCode && o.sku == p.sku)
                        {
                            flag++;
                        }
                    }
                }

                if (o.ItemCode != null && o.ItemCode != "")
                {
                    if (o.unit_code == null || o.unit_code == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Valid Unit Code for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                        showMessageService.ShowMessage();
                        return false;
                    }
                }
            }
            #endregion  
            return true;
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject)
        {
            STD_LIST_BE POPUPEntityObject = null;
            if (ParameterObject != null)
            {
                if (((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList()[0];

                    isNewRecord = false;
                    string RequestParameterData = "LOAD_DOCUMENT" + "!@" + AppSessionState.client + "!@" + POPUPEntityObject.comp_code + "!@" + POPUPEntityObject.location_id + "!@" + POPUPEntityObject.doc_cat + "!@" + POPUPEntityObject.doc_type + "!@" + POPUPEntityObject.doc_no;
                    MCTEMP = REPOSITORY.GetDataWithReturnDomainObject<MC_MM_S010>(MCTEMP, RequestParameterData, "MM_S010_BL", "MM", "", 0, "");
                    if (MCTEMP.MasterEntityList.Count > 0)
                    {
                        MasterEntity = MCTEMP.MasterEntityList[0];
                        ItemsEntity = MCTEMP.ItemEntityList;
                        MasterEntity.ts_code = ts_code_vm;
                        isNewRecord = false;
                    }
                    SelectedTabControlIndex = 0;
                }
            }
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm);
                }
                else
                {
                    
                    LoadInitialData();
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
        private void SelectAll(object InputValue) 
        {
            try
            {
                foreach (var item in ItemsEntity)
                {
                    item.check = true;
                }
            }
            catch (Exception ex)
            {}
        }

        #endregion

        #region Filters
        #region Filter For Physical Item List
        private string _FLTR_STR_STOCK;
        public string FLTR_STR_STOCK
        {
            get { return _FLTR_STR_STOCK; }
            set
            {
                _FLTR_STR_STOCK = value;
                RaisePropertyChanged("FLTR_STR_STOCK");
                FLTR_COLL_STOCK();
            }
        }
        private ICollectionView _dataGridviewFilter;
        // This DataGridView filter Schedule Lines for selected item. it will show only schedule for selected item.
        public ICollectionView DataGridViewFilter
        {
            get { return _dataGridviewFilter; }
            set { _dataGridviewFilter = value; RaisePropertyChanged("DataGridViewFilter"); }
        }
        private void FLTR_COLL_STOCK()
        {
            try
            {
                if (ItemsEntity != null)
                {
                    if (ItemsEntity.Count > 0)
                    {
                        DataGridViewFilter = CollectionViewSource.GetDefaultView(ItemsEntity);
                        DataGridViewFilter.Filter = adv => ((MM_S010_A)adv).ItemCode.ToLower().Contains(FLTR_STR_STOCK) || ((MM_S010_A)adv).ItemName.ToLower().Contains(FLTR_STR_STOCK.ToLower());
                        DataGridViewFilter.Refresh();
                    }

                }
            }
            catch (Exception ex)
            {}
        }


        #endregion

        #region Filter For Flip Grid
        private string _FLTR_STR_BACKFLIP;
        public string FLTR_STR_BACKFLIP
        {
            get { return _FLTR_STR_BACKFLIP; }
            set
            {
                _FLTR_STR_BACKFLIP = value;
                RaisePropertyChanged("FLTR_STR_BACKFLIP");
                FLTR_COLL_BACKFLIP();
            }
        }
        private void FLTR_COLL_BACKFLIP()
        {
            if (_BACKFLIP_COLLECTION != null)
            {
                _BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool FLTR_BACKFLIP(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FLTR_STR_BACKFLIP))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.post_date != null && data.post_date.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.store_code != null && data.store_code.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.t_status != null && data.t_status.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.t_display != null && data.t_display.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.cat_name != null && data.cat_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.location_id != null && data.location_id.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.username != null && data.username.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #endregion
    }
}
