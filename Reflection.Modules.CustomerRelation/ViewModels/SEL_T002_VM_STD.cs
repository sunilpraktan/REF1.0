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
using System.Collections.Specialized;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using System.Windows.Controls;
using Reflection.Presentation.Controls;
using System.Windows;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Services.Convertors;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.Presentation.Common;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class SEL_T002_VM_STD : WorkspaceViewModel<SEL_T002>
    {

        #region Variable Declarations
        bool blNew = true;
        string PreviousUnitCode = "";
        string NewUnitCode = "";
        private bool _EntityChangeEnable;
        private bool EntityChangeEnable
        {
            get { return _EntityChangeEnable; }
            set
            {
                if (_EntityChangeEnable != value)
                {
                    _EntityChangeEnable = value; RaisePropertyChanged("EntityChangeEnable");
                }
            }
        }
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }
        WebServiceRepository<SEL_T002> repository = new WebServiceRepository<SEL_T002>();
        WebServiceRepository<MultipleContext_SEL_T002> repository_MC = new WebServiceRepository<MultipleContext_SEL_T002>();
        WebServiceRepository<MultipleContext_SEL_T002> repository_MCTemp = new WebServiceRepository<MultipleContext_SEL_T002>();
        ObjectSerializationService obj = new ObjectSerializationService();
        List<SEL_T001_P> ReferenceDocFilteredList = new List<SEL_T001_P>(); // Reference document filtered collection store here.
        private MultipleContext_SEL_T002 _MC = new MultipleContext_SEL_T002();
        public MultipleContext_SEL_T002 MC
        {
            get { return _MC; }
            set { if (_MC != value) { _MC = value; RaisePropertyChanged("MC"); } }
        }

        private MultipleContext_SEL_T002 _MCTemp = new MultipleContext_SEL_T002();
        public MultipleContext_SEL_T002 MCTemp
        {
            get { return _MCTemp; }
            set { if (_MCTemp != value) { _MCTemp = value; RaisePropertyChanged("MCTemp"); } }
        }

        private SEL_T002 _MasterEntity;
        public SEL_T002 MasterEntity
        {
            get { return _MasterEntity; }
            set { if (_MasterEntity != value) { _MasterEntity = value; RaisePropertyChanged(nameof(MasterEntity)); value.BeginEdit(); } }
        }

        private int _ItemDataGridSelectedIndex;
        public int ItemDataGridSelectedIndex
        {
            get { return _ItemDataGridSelectedIndex; }
            set
            {
                if (_ItemDataGridSelectedIndex != value)
                {
                    _ItemDataGridSelectedIndex = value;
                    RaisePropertyChanged("ItemDataGridSelectedIndex");
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
                var msg = new NotificationMessage(ts_code_vm);
                Messenger.Default.Send<NotificationMessage>(msg);
            }
        }

        private bool _isTabChangeAllowed = true;
        public bool isTabChangeAllowed
        {
            get { return _isTabChangeAllowed; }
            set
            {
                if (_isTabChangeAllowed != value)
                {
                    _isTabChangeAllowed = value; RaisePropertyChanged("isTabChangeAllowed");
                }
            }
        }

        private RequestParameters _RequestPara;
        public RequestParameters RequestPara
        {
            get { return _RequestPara; }
            set
            {
                if (_RequestPara != value)
                {
                    _RequestPara = value;

                    RaisePropertyChanged("RequestPara");
                }
            }
        }
        #endregion
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SEL_T002_VM_STD));
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
        private AutoSuggestTextViewModel<dynamic> _ASSchMode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSchMode
        {
            get { return _ASSchMode; }
            set
            {
                if (_ASSchMode != value)
                {
                    _ASSchMode = value; RaisePropertyChanged("ASSchMode");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASSchBy { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSchBy
        {
            get { return _ASSchBy; }
            set
            {
                if (_ASSchBy != value)
                {
                    _ASSchBy = value; RaisePropertyChanged("ASSchBy");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASSchRecBy { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSchRecBy
        {
            get { return _ASSchRecBy; }
            set
            {
                if (_ASSchRecBy != value)
                {
                    _ASSchRecBy = value; RaisePropertyChanged("ASSchRecBy");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDelLocation { get; set; }
        private AutoSuggestTextViewModel<dynamic> _ASUOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUOM
        {
            get { return _ASUOM; }
            set
            {
                if (_ASUOM != value)
                {
                    _ASUOM = value; RaisePropertyChanged("ASUOM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASTR_MODE { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTR_MODE
        {
            get { return _ASTR_MODE; }
            set
            {
                if (_ASTR_MODE != value)
                {
                    _ASTR_MODE = value; RaisePropertyChanged("ASTR_MODE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASTR_PARTY { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTR_PARTY
        {
            get { return _ASTR_PARTY; }
            set
            {
                if (_ASTR_PARTY != value)
                {
                    _ASTR_PARTY = value; RaisePropertyChanged("ASTR_PARTY");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASShipToAdd { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASShipToAdd
        {
            get { return _ASShipToAdd; }
            set
            {
                if (_ASShipToAdd != value)
                {
                    _ASShipToAdd = value; RaisePropertyChanged("ASShipToAdd");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASt_status { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASt_status
        {
            get { return _ASt_status; }
            set
            {
                if (_ASt_status != value)
                {
                    _ASt_status = value; RaisePropertyChanged("ASt_status");
                }
            }
        }
        private DataGridCellInfo _cellInfo;
        public DataGridCellInfo CellInfo
        {
            get { return _cellInfo; }
            set
            {
                _cellInfo = value;
                SetAutoTextSource(_cellInfo);
                RaisePropertyChanged("CellInfo");
            }
        }
        private void SetAutoTextSource(DataGridCellInfo dgCellInfo)
        {
            if (dgCellInfo != null)
            {
                var column = dgCellInfo.Column as DataGridColumn;
                if (column != null)
                {
                    string headerName = column.Header.ToString();
                    string SourceName = column.SortMemberPath.ToString();
                    if (SourceName == "unit_code")
                    { ASDefault = ASUOM; }
                    else if (SourceName == "ship_to_add")
                    { ASDefault = ASShipToAdd; }
                    else if (SourceName == "tr_mode")
                    { ASDefault = ASTR_MODE; }
                    else if (SourceName == "tr_party")
                    { ASDefault = ASTR_PARTY; }
                }
            }
        }
        #endregion     
        #region Observable Collection
        private ObservableCollection<SEL_T002_A> _ItemDataGridCollection;
        public ObservableCollection<SEL_T002_A> ItemDataGridCollection
        {
            get { return _ItemDataGridCollection; }
            set
            {
                if (ItemDataGridCollection != value)
                {
                    _ItemDataGridCollection = value;
                    ItemDataGridCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
                    RaisePropertyChanged("ItemDataGridCollection");
                }
            }
        }

        #endregion
        #region Dictionary
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
        #region Relay Command
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdMail { get; private set; }
        public RelayCommand<object> cmdPrint { get; private set; }
        public RelayCommand<object> CommandSchby { get; private set; }
        public RelayCommand<object> CommandUnit { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand cmdInsertTransferOrder { get; private set; }
        public RelayCommand cmdExecuteReferenceDocuments { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> cmdShipToAdd { get; private set; }
        public RelayCommand<object> CmdAddSelectedRef { get; private set; }
        public RelayCommand<object> CommandLoadBackFlipData { get; private set; }
        public RelayCommand<object> cmdTR_Mode { get; private set; }
        public RelayCommand<object> cmdTR_Party { get; private set; }
        public RelayCommand<object> cmdSchedule_Mode { get; private set; }
        public RelayCommand<object> cmdCopySchedule { get; private set; }
        #endregion
        #region Collection View

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

        private ICollectionView _ReferenceDocCollection;
        public ICollectionView ReferenceDocCollection
        {
            get { return _ReferenceDocCollection; }
            set { _ReferenceDocCollection = value; RaisePropertyChanged("ReferenceDocCollection"); }
        }


        private ICollectionView _DataGridCollectionBackFlip;
        public ICollectionView DataGridCollectionBackFlip
        {
            get { return _DataGridCollectionBackFlip; }
            set { _DataGridCollectionBackFlip = value; RaisePropertyChanged("DataGridCollectionBackFlip"); }
        }

        #endregion
        #region Constructor
        public SEL_T002_VM_STD(string doc_cat, string ts_code) : base()
        {
            CursorControl.SetBusyState();
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            //ReferenceDocFilteredList = new List<SEL_T001_P>();
            NotificationDataCollection = new List<NotificationData>();
            SEL_T002_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            MC = new MultipleContext_SEL_T002();
            MCTemp = new MultipleContext_SEL_T002();
            ItemDataGridCollection = new ObservableCollection<SEL_T002_A>();
            RequestPara = new RequestParameters();
            MasterEntity = new SEL_T002();
            MasterEntity.ValidateAsync().Wait();
            MasterEntity.sch_date = System.DateTime.Now;
            LoadInitialData();
        }
        public SEL_T002_VM_STD(string doc_cat, string ts_code, string doc_no) : base()
        {
            CursorControl.SetBusyState();
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            NotificationDataCollection = new List<NotificationData>();
            SEL_T002_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            MC = new MultipleContext_SEL_T002();
            MCTemp = new MultipleContext_SEL_T002();
            ItemDataGridCollection = new ObservableCollection<SEL_T002_A>();
            RequestPara = new RequestParameters();
            MasterEntity = new SEL_T002();
            MasterEntity.ValidateAsync().Wait();
            MasterEntity.sch_date = System.DateTime.Now;
            LoadInitialData();
        }
        #endregion
        #region User Defined Function
        private void AddSelectedRef(object InputValue)
        {
            try
            {
                SEL_T001_P POPUPEntityObject = null;

                if (InputValue != null && ((IEnumerable)InputValue).Cast<SEL_T001_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T001_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    RequestPara.ref_doc = "";
                    if (POPUPEntityObject.Select == true)
                    {
                        ReferenceDocFilteredList = (from o in MC.Reference_Docs
                                                    where o.ship_to_party == POPUPEntityObject.ship_to_party
                                                           && o.so_code == POPUPEntityObject.so_code
                                                           && o.ref_doc_cat == POPUPEntityObject.ref_doc_cat
                                                    select o).ToList();
                        ReferenceDocCollection = CollectionViewSource.GetDefaultView(ReferenceDocFilteredList);
                        ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                    }
                    else if ((from o in ReferenceDocFilteredList where o.Select == true select o).ToList().Count <= 0)
                    {
                        ReferenceDocCollection = CollectionViewSource.GetDefaultView(MC.Reference_Docs);
                        ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                    }
                    foreach (var item in ReferenceDocFilteredList)
                    {
                        if (item.Select == true)
                        {
                            RequestPara.ref_doc = RequestPara.ref_doc + "," + item.id.ToString();
                        }
                    }
                    RequestPara.ref_doc = RequestPara.ref_doc.ToString().TrimStart(new char[] { ',' });
                }
            }
            catch (Exception Ex) { }
        }
        private void MailDocuments(object InputValue)
        {

        }
        private void PrintDocuments(Object InputValue)
        {

        }
        private void CopyScheduleLine(object InputValue)
        {
            string Request = "";
            List<SEL_T002_A> POPUPEntityObject = new List<SEL_T002_A> ();
            try
            {
                if (InputValue != null )
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T002_A>().ToList();
                    if (POPUPEntityObject.Count > 0)
                    {
                        

                        foreach (var itemObj in POPUPEntityObject)
                        {
                            decimal? currOrderQty = 0;
                            decimal? currBalanceQty = 0;
                            decimal? currScheduleQty = 0;

                            currScheduleQty = ItemDataGridCollection.Where(p => p.so_item_id == itemObj.so_item_id && p.id > 0).Sum(p => p.confirm_qty)?? 0;
                            if(MC.Reference_Docs.Where(p => p.id == itemObj.so_item_id).ToList().Count > 0)
                            {
                                currOrderQty = MC.Reference_Docs.Where(p => p.id == itemObj.so_item_id).ToList()[0].quantity ?? 0;
                            }
                            else
                            {
                                currOrderQty = 0;
                            }
                            if (MC.Reference_Docs.Where(p => p.id == itemObj.so_item_id).ToList().Count > 0)
                            {
                                currBalanceQty = MC.Reference_Docs.Where(p => p.id == itemObj.so_item_id).ToList()[0].bal_qty ?? 0;
                            }
                            else
                            {
                                currBalanceQty = 0;
                            }
                            decimal? totalBalQty = currScheduleQty + currBalanceQty;

                            ItemDataGridCollection.Add(new SEL_T002_A()
                            {
                                id = 0,
                                sch_cat = itemObj.sch_cat,
                                del_rel = "Y",
                                sono = itemObj.sono,
                                ref_no = itemObj.ref_no,
                                line_id = (int)ItemDataGridCollection.Count + 1,
                                ItemCode = itemObj.ItemCode,
                                ItemName = itemObj.ItemName,
                                unit_code = itemObj.unit_code,
                                sch_qty = itemObj.bal_qty, //itemObj.order_qty - ItemDataGridCollection.Where(p => p.so_item_id == itemObj.so_item_id).Sum(p => p.sch_qty), 
                                exp_date = itemObj.exp_date,
                                //desp_date = item.desp_date,
                                confirm_date = itemObj.confirm_date,
                                confirm_qty = itemObj.bal_qty, //itemObj.order_qty - ItemDataGridCollection.Where(p => p.so_item_id == itemObj.so_item_id).Sum(p => p.confirm_qty),
                                del_qty = itemObj.bal_qty, //itemObj.order_qty - ItemDataGridCollection.Where(p => p.so_item_id == itemObj.so_item_id).Sum(p => p.del_qty),
                                del_date = itemObj.del_date,
                                active = true,
                                t_status = MasterEntity.t_status,
                                sku = itemObj.sku,
                                //sku_desc = item.sk
                                location_Id = itemObj.location_Id,
                                comp_code = itemObj.comp_code,
                                rate = itemObj.rate,
                                rel_billing = "Y",
                                rel_delivery = "Y",
                                so_item_id = itemObj.so_item_id,
                                order_qty = itemObj.order_qty,
                                sch_date = itemObj.sch_date,
                                tr_mode = itemObj.tr_mode,
                                tr_type = itemObj.tr_type,
                                tr_party = itemObj.tr_party,
                                ref_doc_no = itemObj.ref_doc_no,
                                ref_doc_cat = itemObj.ref_doc_cat,
                                ref_doc_date = itemObj.ref_doc_date,
                                ref_doc_type = itemObj.ref_doc_type,
                                ship_to_party = itemObj.ship_to_party,
                                ship_to_party_name = itemObj.ship_to_party_name,
                                ship_to_add = itemObj.ship_to_add,
                                ship_to_addNm = itemObj.ship_to_addNm,
                                qty_price = itemObj.qty_price,
                                price_qty = itemObj.price_qty,
                                price_qty_uom = itemObj.price_qty_uom,
                                add_by = AppSessionState.UserID,
                                add_date = DateTime.Now,
                                editby = AppSessionState.UserID,
                                t_display = MasterEntity.t_display,
                                PartyId = itemObj.tr_party,
                                PartyNm = itemObj.PartyNm,
                                bal_qty = 0, //totalBalQty - ItemDataGridCollection.Where(p => p.so_item_id == itemObj.so_item_id).Sum(p => p.confirm_qty),
                                lead_time = itemObj.lead_time,
                                item_line_id = itemObj.item_line_id
                            });
                            //totalBalQty = totalBalQty - itemObj.confirm_qty;
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
        private void InsertSchedule_Mode(object InputValue)
        {
            string Request = "";
            SYS_M036 POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ScheduleMode.Where(x => x.sch_mode.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M036>().ToList()[0];
                }


                #endregion
                if (POPUPEntityObject != null)
                {

                    MasterEntity.sch_mode = POPUPEntityObject.sch_mode;
                    //MasterEntity.sc = POPUPEntityObject.contact_name;
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
        private void InsertContactPerson(object InputValue)
        {
            string Request = "";
            ADM_M028_C_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.contactInfoMaster.Where(x => x.ContInfoId.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_C_P>().ToList()[0];
                }


                #endregion
                if (POPUPEntityObject != null)
                {

                    MasterEntity.ContInfoId = POPUPEntityObject.ContInfoId;
                    MasterEntity.sch_by = POPUPEntityObject.contact_name;
                    MasterEntity.contact_name = POPUPEntityObject.PersonName;

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
        private void InsertTR_Mode(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M026 POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.TransportMode.Where(x => x.tr_mode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M026>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    ItemDataGridCollection[ItemDataGridSelectedIndex].tr_mode = POPUPEntityObject.tr_mode;
                    ItemDataGridCollection[ItemDataGridSelectedIndex].tr_name = POPUPEntityObject.tr_name;
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
        private void InsertTR_Party(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ServiceProviders.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    ItemDataGridCollection[ItemDataGridSelectedIndex].tr_party = POPUPEntityObject.PartyId;
                    ItemDataGridCollection[ItemDataGridSelectedIndex].PartyNm = POPUPEntityObject.PartyNm;
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
        private void InsertUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UOM.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemDataGridCollection.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemDataGridCollection.IndexOf(ItemDataGridCollection.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (ItemDataGridSelectedIndex >= 0 && ItemDataGridCollection.Count > ItemDataGridSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemDataGridCollection[ItemDataGridSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            PreviousUnitCode = ItemDataGridCollection[ItemDataGridSelectedIndex].unit_code;
                            ItemDataGridCollection[ItemDataGridSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                            NewUnitCode = POPUPEntityObject.unit_code;
                        }
                        else if (ItemDataGridCollection[ItemDataGridSelectedIndex].unit_code != POPUPEntityObject.unit_code)
                        {
                            PreviousUnitCode = ItemDataGridCollection[ItemDataGridSelectedIndex].unit_code;
                            ItemDataGridCollection[ItemDataGridSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                            NewUnitCode = POPUPEntityObject.unit_code;
                        }
                    }
                }
                #region Clear Empty Row
                SEL_T002_A newObj = new SEL_T002_A();
                for (int i = ItemDataGridCollection.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemDataGridCollection[i].ComparePropertiesTo(newObj);
                    if (ItemDataGridCollection[i].ComparePropertiesTo(newObj) == true && ItemDataGridCollection.Count > 1)
                    {
                        ItemDataGridCollection.RemoveAt(i);
                        if (ItemDataGridCollection.Count == 0)
                        {
                            ItemDataGridCollection.Add(newObj);
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
        private void LoadDocumentByDocumentNumber(object ParameterObject)
        {
            try
            {
                EntityChangeEnable = false;
                CursorControl.SetBusyState();
                string Request = "";
                string ParametersStringValue = "";
                SEL_T002_BackFlip POPUPEntityObject = null;


                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null)
                {
                    ParametersStringValue = ParameterObject.ToString().Trim();
                    if (ParametersStringValue.Length > 0)
                    {
                        try
                        { Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + AppSessionState.client + "!@" + ParametersStringValue; }
                        catch (Exception ex) { }
                    }

                }

                else if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<SEL_T002_BackFlip>().ToList().Count > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)ParameterObject).Cast<SEL_T002_BackFlip>().ToList()[0];

                        blNew = false;
                        string RequestParameterData = "LoadDocumentWithReferenceDocumentNumber" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + POPUPEntityObject.sch_no;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T002>(MCTemp, RequestParameterData, "DeliveryScheduleSTD", "CRM", "", 0, "");

                        MasterEntity = MCTemp.MasterEntity[0];
                        SelectedTabControlIndex = 0;
                        ItemDataGridCollection = MCTemp.ItemsEntity;
                        MC.ItemsMaster = MCTemp.ItemsMaster;
                        AttachmentCollection = MCTemp.Attachment;

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).ContInfoId.ToString());
                        TheFilter = (o, prefix) => (((ADM_M028_C_P)o).ContInfoId.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASSchBy = new AutoSuggestTextViewModel<dynamic>((from o in MCTemp.contactInfoMaster where o.PartyId == MasterEntity.PartyId select o).ToList(), TheFilter, SuggestedValue, "ContInfoId", true);
                        ASSchBy.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASSchBy.AutoSuggestVM.IsFreeTextAllowed = true;

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D_Add)x).SrNo.ToString());
                        TheFilter = (o, prefix) => (((ADM_M028_D_Add)o).SrNo.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASShipToAdd = new AutoSuggestTextViewModel<dynamic>((from o in MCTemp.DeliveryAddress where o.PartyId == MasterEntity.PartyId select o).ToList(), TheFilter, SuggestedValue, "SrNo", true);
                        ASShipToAdd.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASShipToAdd.AutoSuggestVM.IsFreeTextAllowed = true;

                        blNew = false;
                    }
                }
                MasterEntity.ts_code = ts_code_vm;
                EntityChangeEnable = true;
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));

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
        private void ExecuteReferenceDocuments()
        {
            try
            {
                EntityChangeEnable = false;
                if ((from o in ReferenceDocFilteredList where o.Select == true select o).ToList().Count > 0) // foreach for only selected rows.
                {
                    MasterEntity = new SEL_T002();

                    foreach (var item in (from o in ReferenceDocFilteredList where o.Select == true select o).ToList())
                    {
                        if (item.Select == true)
                        {
                            ItemDataGridCollection.Add(new SEL_T002_A()
                            {
                                id = 0,
                                sch_cat = item.doc_cat,
                                del_rel = "Y",
                                sono = item.ref_doc_no,
                                ref_no = item.ref_doc_no,
                                line_id = (int)ItemDataGridCollection.Count + 1,
                                ItemCode = item.ItemCode,
                                ItemName = item.Description,
                                unit_code = item.unit_code,
                                sch_qty = item.bal_qty,
                                exp_date = item.expect_date,
                                //desp_date = item.date_planned,
                                confirm_date = item.expect_date,
                                confirm_qty = item.bal_qty,
                                del_qty = item.bal_qty,
                                del_date = item.expect_date,
                                active = true,
                                t_status = (from o in MC.t_statusList where o.t_sequence == 1 select o).ToList()[0].t_status,
                                sku = item.sku,
                                //sku_desc = item.sk
                                location_Id = AppSessionState.location_Id,
                                comp_code = AppSessionState.comp_code,
                                rate = item.unit_price,
                                rel_billing = "Y",
                                rel_delivery = "Y",
                                so_item_id = item.id,
                                order_qty = item.quantity,
                                sch_date = DateTime.Now,
                                tr_mode = item.tr_mode,
                                tr_type = item.tr_type,
                                tr_party = item.tr_party,
                                ref_doc_no = item.ref_doc_no,
                                ref_doc_cat = item.ref_doc_cat,
                                ref_doc_date = item.ref_doc_date,
                                ref_doc_type = item.ref_doc_type,
                                ship_to_party = item.ship_to_party,
                                ship_to_party_name = item.ship_to_party_name,
                                ship_to_add = item.del_address.ToString(),
                                ship_to_addNm = item.location,
                                qty_price = item.qty_price,
                                price_qty = item.price_qty,
                                price_qty_uom = item.price_qty_uom,
                                add_by = AppSessionState.UserID,
                                add_date = DateTime.Now,
                                editby = AppSessionState.UserID,
                                t_display = (from o in MC.t_statusList where o.t_sequence == 1 select o).ToList()[0].t_display,
                                PartyId = item.tr_party,
                                PartyNm = item.party_name,
                                bal_qty = 0,
                                lead_time = 0,
                                item_line_id = item.line_id
                            });
                        }
                    }

                    MasterEntity.doc_cat = doc_cat_vm;
                    MasterEntity.doc_type = doc_cat_vm;
                    MasterEntity.ref_type = doc_cat_vm;
                    MasterEntity.PartyId = ItemDataGridCollection[0].ship_to_party;
                    MasterEntity.PartyNm = ItemDataGridCollection[0].ship_to_party_name;
                    MasterEntity.sch_date = DateTime.Now;
                    MasterEntity.EmpId = AppSessionState.EmpId;
                    MasterEntity.employee_name = AppSessionState.EmpName;
                    MasterEntity.sch_rec_by_cd = AppSessionState.EmpId;
                    MasterEntity.active = true;
                    MasterEntity.add_by = AppSessionState.UserID;
                    MasterEntity.add_date = DateTime.Now;
                    MasterEntity.t_status = (from o in MC.t_statusList where o.t_sequence == 1 select o).ToList()[0].t_status;
                    MasterEntity.location_Id = AppSessionState.location_Id;
                    MasterEntity.comp_code = AppSessionState.comp_code;
                    MasterEntity.del_address = Convert.ToInt32(ItemDataGridCollection[0].ship_to_add);
                    MasterEntity.del_add = (from o in MC.DeliveryAddress where o.SrNo == MasterEntity.del_address select o).ToList()[0].del_add;
                    MasterEntity.client = AppSessionState.client;
                    MasterEntity.Location = ItemDataGridCollection[0].ship_to_addNm;


                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).ContInfoId.ToString());
                    TheFilter = (o, prefix) => (((ADM_M028_C_P)o).ContInfoId.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASSchBy = new AutoSuggestTextViewModel<dynamic>((from o in MC.contactInfoMaster where o.PartyId == MasterEntity.PartyId select o).ToList(), TheFilter, SuggestedValue, "ContInfoId", true);
                    ASSchBy.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASSchBy.AutoSuggestVM.IsFreeTextAllowed = true;

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D_Add)x).SrNo.ToString());
                    TheFilter = (o, prefix) => (((ADM_M028_D_Add)o).SrNo.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASShipToAdd = new AutoSuggestTextViewModel<dynamic>((from o in MC.DeliveryAddress where o.PartyId == MasterEntity.PartyId select o).ToList(), TheFilter, SuggestedValue, "SrNo", true);
                    ASShipToAdd.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASShipToAdd.AutoSuggestVM.IsFreeTextAllowed = true;

                    if (MC.contactInfoMaster.Count == 1)
                    {
                        MasterEntity.ContInfoId = MC.contactInfoMaster[0].ContInfoId;
                        MasterEntity.contact_name = MC.contactInfoMaster[0].PersonName;
                    }
                    DefaultValues();
                    var msg = new NotificationMessage(ts_code_vm);
                    EntityChangeEnable = true;
                    Messenger.Default.Send<NotificationMessage>(msg);
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Refernece Document Selection";
                    showMessageService.Text = String.Format("Referance Document not selected No", this.Title);
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
        private void LoadBackFlipData()
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + RequestPara.location_id + "!@" + RequestPara.doc_cat + "!@" + RequestPara.doc_type + "!@" + RequestPara.emp_id + "!@" + RequestPara.user_id + "!@" + RequestPara.active + "!@" + RequestPara.t_status + "!@" + RequestPara.PartyId + "!@" + RequestPara.org_code + "!@" + RequestPara.group_code + "!@" + Convert.ToDateTime(RequestPara.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(RequestPara.ToDate).ToString("MM/dd/yyyy") + "!@" + RequestPara.doc_no;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T002>(MCTemp, Request, "DeliveryScheduleSTD", "CRM", "", 0, "");

                DataGridCollectionBackFlip = CollectionViewSource.GetDefaultView(MCTemp.BackFlipEntity);
                DataGridCollectionBackFlip.Filter = new Predicate<object>(Filter_BackFlip);

                var msg = new NotificationMessage(ts_code_vm);
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
                    LoadDocumentByDocumentNumber(doc_no_vm);
                    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
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
        private void InsertShipToAddress(object InputValue)
        {
            string Request = "";
            ADM_M028_D_Add POPUPEntityObject = null;
            try
            {
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            {
                                POPUPEntityObject = MC.DeliveryAddress.Where(x => x.SrNo.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_D_Add>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_add = POPUPEntityObject.SrNo.ToString();
                    ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_addNm = POPUPEntityObject.Location;
                    ItemDataGridCollection[ItemDataGridSelectedIndex].address_info = POPUPEntityObject.del_add;

                    MasterEntity.del_address = POPUPEntityObject.SrNo;
                    MasterEntity.del_add = POPUPEntityObject.del_add;
                    MasterEntity.Location = POPUPEntityObject.Location;
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
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemDataGridCollection.Count > i && ItemDataGridCollection[ItemDataGridSelectedIndex].id == 0)
                {
                    ItemDataGridCollection.RemoveAt(i);
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
        private void DefaultValues()
        {
            try
            {
                EntityChangeEnable = true;
                MasterEntity.client = AppSessionState.client;
                MasterEntity.doc_cat = doc_cat_vm;
                MasterEntity.doc_type = doc_cat_vm;
                MasterEntity.ts_code = ts_code_vm;
                MasterEntity.ref_type = "SD";
                MasterEntity.location_Id = AppSessionState.location_Id;
                MasterEntity.comp_code = AppSessionState.comp_code;
                MasterEntity.add_by = AppSessionState.UserID;
                MasterEntity.editby = AppSessionState.UserID;
                MasterEntity.active = true;
                MasterEntity.t_status = (from o in MC.t_statusList where o.t_sequence == 1 select o).ToList()[0].t_status;
                MasterEntity.t_display = (from o in MC.t_statusList where o.t_sequence == 1 select o).ToList()[0].t_display;
                MasterEntity.sch_date = DateTime.Now;
                MasterEntity.sch_rec_by_cd = AppSessionState.EmpId;
                MasterEntity.EmpId = AppSessionState.EmpId;
                MasterEntity.employee_name = AppSessionState.EmpName;
                MasterEntity.user_source1 = AppSessionState.UserSource1;
                MasterEntity.user_source2 = AppSessionState.UserSource2;
                MasterEntity.userid = AppSessionState.UserID;
                //DateTime d = DateTime.UtcNow;
                //d = d.AddMonths(-1);
                //MasterEntity.Fltr_FrmDate = d;
                //MasterEntity.Fltr_ToDate = DateTime.UtcNow;
                //MasterEntity.Fltr_active = true;
            }
            catch (Exception ex) { }
        }
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.comp_code.ToString() + "!@" + AppSessionState.location_Id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + AppSessionState.EmpId;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T002>(MC, Request, "DeliveryScheduleSTD", "CRM", " ", 0, "");
                #region Command Initialization

                ItemDataGridCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
                CommandSchby = new RelayCommand<object>(items => { if (items == null) { return; } InsertContactPerson(items); });
                CommandUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOM(cmdPara, false, true, true); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara); });
                cmdInsertTransferOrder = new RelayCommand(() => { Insert_TransferOrder(); });
                cmdExecuteReferenceDocuments = new RelayCommand(() => { ExecuteReferenceDocuments(); });
                CmdDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
                cmdMail = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } MailDocuments(cmdPara); });
                cmdPrint = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } PrintDocuments(cmdPara); });
                cmdShipToAdd = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertShipToAddress(cmdPara); });
                CmdAddSelectedRef = new RelayCommand<object>(items => { if (items == null) { return; } AddSelectedRef(items); });
                CommandLoadBackFlipData = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(); });
                cmdTR_Mode = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTR_Mode(cmdPara); });
                cmdTR_Party = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTR_Party(cmdPara); });
                cmdSchedule_Mode = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSchedule_Mode(cmdPara); });
                cmdCopySchedule = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } CopyScheduleLine(cmdPara); });
                #endregion
                #region Autosuggest

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_sch_P)x).PartyNm);
                TheFilter = (o, prefix) => (((ADM_M028_sch_P)o).PartyId ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower()) || (((ADM_M028_sch_P)o).PartyNm ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower());
                AutoSuggestTextViewModel = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyNm", true);
                AutoSuggestTextViewModel.AutoSuggestVM.IsEmptyValueAllowed = true;
                AutoSuggestTextViewModel.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode);
                TheFilter = (o, prefix) => (((ADM_M022_P)o).ItemCode ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower()) || (((ADM_M022_P)o).ItemName ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.ItemsMaster, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M038_B_P)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASUOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASUOM.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASUOM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M026)x).tr_mode);
                TheFilter = (o, prefix) => (((SYS_M026)o).tr_mode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M026)o).tr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTR_MODE = new AutoSuggestTextViewModel<dynamic>(MC.TransportMode, TheFilter, SuggestedValue, "tr_mode", "tr_mode", true);
                ASTR_MODE.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASTR_MODE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTR_PARTY = new AutoSuggestTextViewModel<dynamic>(MC.ServiceProviders, TheFilter, SuggestedValue, "tr_party", "PartyId", true);
                ASTR_PARTY.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASTR_PARTY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M036)x).sch_mode);
                TheFilter = (o, prefix) => (((SYS_M036)o).sch_mode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M036)o).mode_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSchMode = new AutoSuggestTextViewModel<dynamic>(MC.ScheduleMode, TheFilter, SuggestedValue, "sch_mode", true);
                ASSchMode.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASSchMode.AutoSuggestVM.IsFreeTextAllowed = false;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M036)x).em);
                //TheFilter = (o, prefix) => (((SYS_M036)o).sch_mode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M036)o).mode_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //ASSchRecBy = new AutoSuggestTextViewModel<dynamic>(MC.EmployeeEntity, TheFilter, SuggestedValue, "sch_mode", true);
                //ASSchRecBy.AutoSuggestVM.IsEmptyValueAllowed = true;
                //ASSchRecBy.AutoSuggestVM.IsFreeTextAllowed = false;

                #endregion

                ReferenceDocCollection = CollectionViewSource.GetDefaultView(MC.Reference_Docs); //(from o in MC.Reference_Docs where o.doc_cat == "SD" select o).ToList()
                ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                NotificationDataCollection = MC.NotificationData;
                DefaultValues();

                var msg = new NotificationMessage(ts_code_vm);
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
        private bool Validation()
        {
            try
            {
                if (MasterEntity.PartyId == null || MasterEntity.PartyId == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Field 'Party Name' is required.");
                    showMessageService.ShowMessage();

                    return false;
                }
                if (MasterEntity.EmpId == null || MasterEntity.EmpId == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Field 'Schedule Received By' is required.");
                    showMessageService.ShowMessage();

                    return false;
                }
                foreach (var o in ItemDataGridCollection)
                {

                    if (o.ItemCode != null && o.ItemCode != "" && o.ItemName != null)
                    {
                        if (o.sch_qty == null || o.sch_qty == 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Customer Schedule Qty Cannot be null or 0 for item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.unit_code == null || o.unit_code == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Enter Valid Unit Code for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.ship_to_add == null || o.ship_to_add == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Enter Valid Shipping Address for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        //if (o.confirm_qty == null || o.confirm_qty == 0)
                        //{
                        //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        //    showMessageService.ButtonSetup = DialogButton.Ok;
                        //    showMessageService.Caption = "Message";
                        //    showMessageService.Text = String.Format("Please Enter Valid Confirm Qty for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                        //    showMessageService.ShowMessage();
                        //    return false;
                        //}
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("please select Item ........");
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
        private void RemoveRefDoc()
        {
            try
            {
                if (MasterEntity.ref_doc_no != null)
                {
                    List<string> DocList = RequestPara.ref_doc.Split(',').ToList();
                    foreach (var item in DocList)
                    {
                        MC.Reference_Docs.RemoveAll(X => X.id.ToString() == item);
                    }
                    ReferenceDocCollection = CollectionViewSource.GetDefaultView((from o in MC.Reference_Docs where o.doc_cat == "SO" select o).ToList());
                    ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
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
        void Schedule_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {

                if (ItemDataGridCollection.Count > ItemDataGridSelectedIndex && ItemDataGridSelectedIndex >= 0)
                {
                    this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
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
        void Model_ItemUpdated(object sender, EventArgs e)
        {
            if (EntityChangeEnable == true)
            {
                this.ErrorExist = MasterEntity.HasErrors;
                if (sender.ToString() == "confirm_qty")
                {
                    if (ItemDataGridSelectedIndex != -1 && ItemDataGridCollection.Count > ItemDataGridSelectedIndex && ItemDataGridSelectedIndex >= 0)
                    {
                        decimal? currScheduleQty = 0;
                        decimal? currOrderQty = 0;
                        decimal? currBalanceQty = 0;
                        decimal? totalBalQty = 0;
                        currScheduleQty = ItemDataGridCollection.Where(p => p.so_item_id == ItemDataGridCollection[ItemDataGridSelectedIndex].so_item_id && p.id > 0).Sum(p => p.confirm_qty_org); // Sum of confirm qty of saved rows.
                        if (MC.Reference_Docs.Where(p => p.id == ItemDataGridCollection[ItemDataGridSelectedIndex].so_item_id).ToList().Count > 0)
                        {
                            currOrderQty = MC.Reference_Docs.Where(p => p.id == ItemDataGridCollection[ItemDataGridSelectedIndex].so_item_id).ToList()[0].quantity; // Order Qty of Sales Item Line id.
                        }
                        else
                        {
                            currOrderQty = 0;
                        }
                        if (MC.Reference_Docs.Where(p => p.id == ItemDataGridCollection[ItemDataGridSelectedIndex].so_item_id).ToList().Count > 0)
                        {
                            currBalanceQty = MC.Reference_Docs.Where(p => p.id == ItemDataGridCollection[ItemDataGridSelectedIndex].so_item_id).ToList()[0].bal_qty; // Balace Schedule Qty of Sales Item line id.
                        }
                        else
                        {
                            currBalanceQty = 0;
                        }
                        totalBalQty = currScheduleQty + currBalanceQty;
                        var temp = (from o in ItemDataGridCollection where o.so_item_id == ItemDataGridCollection[ItemDataGridSelectedIndex].so_item_id select o).ToList();
                        if (temp.Count > 0)
                        {
                            foreach (var o in (from o in ItemDataGridCollection where o.so_item_id == ItemDataGridCollection[ItemDataGridSelectedIndex].so_item_id select o).ToList())
                            {
                                if (o.confirm_qty.HasValue || o.sch_qty.HasValue)
                                {
                                    if (o.confirm_qty > 0)
                                    {
                                        o.bal_qty = totalBalQty - Convert.ToDecimal(o.confirm_qty);
                                        totalBalQty = totalBalQty - Convert.ToDecimal(o.confirm_qty);
                                    }
                                    else
                                    {
                                        o.bal_qty = totalBalQty - Convert.ToDecimal(o.sch_qty);
                                        totalBalQty = totalBalQty - Convert.ToDecimal(o.sch_qty);
                                    }
                                }
                                
                                //temp[ItemDataGridSelectedIndex].bal_qty = totalBalQty - Convert.ToDecimal(o.confirm_qty);
                                //totalBalQty = totalBalQty - Convert.ToDecimal(o.confirm_qty);
                            }
                        }
                    }
                }
                else if (sender.ToString() == "lead_time" || sender.ToString() == "desp_date")
                {
                    if (ItemDataGridSelectedIndex != -1 && ItemDataGridCollection.Count > ItemDataGridSelectedIndex && ItemDataGridSelectedIndex >= 0)
                    {
                        if (ItemDataGridCollection[ItemDataGridSelectedIndex].lead_time >= 0 && ItemDataGridCollection[ItemDataGridSelectedIndex].desp_date.HasValue == true)
                        {
                            ItemDataGridCollection[ItemDataGridSelectedIndex].del_date = ItemDataGridCollection[ItemDataGridSelectedIndex].desp_date.Value.AddDays(Convert.ToInt32(ItemDataGridCollection[ItemDataGridSelectedIndex].lead_time));
                        }
                    }
                }
            }
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                //This will get called when the property of an object inside the collection changes
                this.ErrorExist = false;/*MasterEntity.HasErrors;*/
                if (ItemDataGridCollection.Count > ItemDataGridSelectedIndex && ItemDataGridSelectedIndex >= 0)
                {
                    this.ErrorExist = false; /*ItemDataGridCollection[ItemDataGridSelectedIndex].HasErrors;*/
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
        private void CollectionChangedNotifyForSchedule(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (SEL_T002_A item in e.NewItems)
                        item.PropertyChanged += this.Schedule_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (SEL_T002_A item in e.OldItems)
                        item.PropertyChanged -= this.Schedule_PropertyChanged;

                /////////////////////////////////Temp Test End
                if (e.Action == NotifyCollectionChangedAction.Add && ItemDataGridCollection.Count > 0) // Schedule can only enable to add if items exists in Items Entity.
                {
                    foreach (SEL_T002_A item in e.NewItems)
                    {
                        try
                        {

                            //item.line_id = 1;
                            if (ItemDataGridCollection.Count > 0)
                            {
                                //item.PartyNm = ItemDataGridCollection[0].PartyNm;
                                //item.ship_mode = ItemDataGridCollection[0].ship_mode;
                                //item.PartyId = ItemDataGridCollection[0].PartyId;
                                //item.tr_mode = ItemDataGridCollection[0].tr_mode;
                                //item.tr_type = ItemDataGridCollection[0].tr_type;
                                //item.tr_party = ItemDataGridCollection[0].tr_party;
                                //item.para1 = ItemDataGridCollection[0].para1;
                                //item.line_id = ItemDataGridCollection.Count;
                            }
                            item.PropertyChanged += EntityViewModelPropertyChanged;

                        }
                        catch (Exception ex) { }
                    }
                }

                if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                }
                if (e.Action == NotifyCollectionChangedAction.Move)
                {
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
                List<NotificationData> objNotifyData = new List<NotificationData>();
                objNotifyData = NotificationDataCollection.Where(x => x.alert_name == AlertName).ToList();
                foreach (NotificationData VarData in objNotifyData)
                {
                    List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("[EMP]",AppSessionState.Name),
                        new KeyValuePair<string, string>("[DOC]", MasterEntity.ref_type),
                        new KeyValuePair<string, string>("[DOCNO]", MasterEntity.sch_no),
                        new KeyValuePair<string, string>("[DOCDATE]", MasterEntity.sch_date.ToString()),
                        new KeyValuePair<string, string>("[CUST]",MasterEntity.PartyNm),
                        new KeyValuePair<string, string>("[Comp]",AppSessionState.CompanyName),
                        new KeyValuePair<string, string>("[Attn]",VarData.EmpName),
                    };

                    foreach (KeyValuePair<string, string> kvp in kvpList)
                    {
                        VarData.subject = VarData.subject.Replace(kvp.Key, kvp.Value);
                        VarData.msg_body = VarData.msg_body.Replace(kvp.Key, kvp.Value);
                    }
                    //Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, VarData.to_mail_id, VarData.cc_mail_id, VarData.bcc_mail_id, VarData.subject, VarData.msg_body, null);
                    string t = MailMessenger.SendMail(AppSessionState.MailAccount, VarData.to_mail_id, VarData.cc_mail_id, VarData.bcc_mail_id, VarData.subject, VarData.msg_body, null);

                }

            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.Text = String.Format(ex.InnerException.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        #endregion
        #region Transfer Order
        WebServiceRepository<SEL_T004> repositoryTO = new WebServiceRepository<SEL_T004>();
        private SEL_T004 _ObjectSEL_T004;
        public SEL_T004 ObjectSEL_T004
        {
            get
            {
                return _ObjectSEL_T004;
            }
            set
            {
                if (_ObjectSEL_T004 != value)
                {
                    _ObjectSEL_T004 = value;
                    RaisePropertyChanged("ObjectSEL_T004");
                }
            }
        }
        private List<SEL_T004_A> _ObjectSEL_T004_A;
        public List<SEL_T004_A> ObjectSEL_T004_A
        {
            get { return _ObjectSEL_T004_A; }
            set
            {
                if (_ObjectSEL_T004_A != value)
                {
                    _ObjectSEL_T004_A = value;

                    RaisePropertyChanged("ObjectSEL_T004_A");

                }
            }
        }
        private void Insert_TransferOrder()
        {
            try
            {
                if (MasterEntity.sch_no != null && MasterEntity.sch_no != "" && ItemDataGridCollection.Count > 0)
                {
                    if (Validation() == true)
                    {
                        ObjectSEL_T004 = new SEL_T004();

                        ObjectSEL_T004.doc_cat = "DO";
                        ObjectSEL_T004.doc_type = "DO";
                        ObjectSEL_T004.doc_date = DateTime.Now;
                        ObjectSEL_T004.PartyNm = MasterEntity.PartyNm;
                        ObjectSEL_T004.delivery_no = MasterEntity.sch_no;
                        ObjectSEL_T004.location_Id = AppSessionState.location_Id;
                        ObjectSEL_T004.comp_code = AppSessionState.comp_code;
                        ObjectSEL_T004.add_by = AppSessionState.UserID;
                        ObjectSEL_T004.active = true;
                        ObjectSEL_T004.t_status = "Draft";
                        ObjectSEL_T004.fin_year = "16-17";
                        ObjectSEL_T004.posting_period = "1";
                        ObjectSEL_T004.start_date = MasterEntity.sch_date;
                        ObjectSEL_T004.ref_doc_cat = MasterEntity.doc_cat;

                        ObjectSEL_T004_A = new List<SEL_T004_A>();

                        foreach (var item in ItemDataGridCollection)
                        {
                            if (item.active == true)
                            {
                                ObjectSEL_T004_A.Add(new SEL_T004_A()
                                {
                                    id = 0,
                                    ItemCode = item.ItemCode,
                                    ItemName = item.ItemName,
                                    location_Id = AppSessionState.location_Id,
                                    sku = item.sku,
                                    sku_desc = item.sku_desc,
                                    unit_code = item.unit_code,
                                    qty = item.sch_qty,
                                    active = true,
                                    t_status = "Draft",
                                    comp_code = AppSessionState.comp_code,
                                    add_by = AppSessionState.UserID,
                                    item_code = 0,
                                    to_req_item = 0,
                                    sd_item_no = 0

                                });
                            }
                        }
                        ObjectSerializationService objSer = new ObjectSerializationService();
                        ObjectSEL_T004.XmlDataDocument_SEL_T004_A = objSer.ObjectToXML(ObjectSEL_T004_A);

                        ObjectSEL_T004 = repositoryTO.SaveWithReturnDomainObject<SEL_T004>(ObjectSEL_T004, "TransferOrder", "CRM");

                        if (ObjectSEL_T004.doc_no != null)
                        {

                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Transfer Order Generate Sucessful - {0}", ObjectSEL_T004.doc_no);
                            showMessageService.ShowMessage();
                        }
                        else
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Transfer Order Generate Unsuccessful", this.Title);
                            showMessageService.ShowMessage();
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
        #region Command Actions
        protected override void OnSaveAction(InquiryActionResult<SEL_T002> result)
        {
            try
            {
                CursorControl.SetBusyState();
                if (ItemDataGridCollection.Count > 0)
                {
                    if (Validation() == true)
                    {
                        try
                        {
                            ObjectSerializationService objSer = new ObjectSerializationService();
                            MasterEntity.XmlDataDocument_SEL_T002_A = objSer.ObjectToXML(ItemDataGridCollection);

                            if (blNew == true)
                            {
                                MasterEntity = repository.SaveWithReturnDomainObject<SEL_T002>(MasterEntity, "DeliveryScheduleSTD", "CRM");
                                if (MasterEntity.sch_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnInsert") >= 0)
                                {
                                    NotifyMessage("OnInsert");
                                }
                                if (MasterEntity.sch_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnApproval") >= 0)
                                {
                                    NotifyMessage("OnApproval");
                                }
                                // Adding Insert Record to Flip Grid
                                if (MasterEntity.XmlDataDocument_FlipGrid != null && blNew == true)
                                {
                                    MC.BackFlipEntity = (List<SEL_T002_BackFlip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.BackFlipEntity);
                                }
                                blNew = false;
                            }
                            else if (blNew == false)
                            {
                                MasterEntity = repository.UpdateWithReturnDomainObject<SEL_T002>(MasterEntity, "DeliveryScheduleSTD", "CRM");
                                NotifyMessage("OnInsert");
                                if (MasterEntity.XmlDataDocument_FlipGrid != null && blNew == false)
                                {
                                    MCTemp.BackFlipEntity = (List<SEL_T002_BackFlip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.BackFlipEntity);
                                }
                            }
                            // Getting Inserted and Updated Record
                            if (MasterEntity.XmlDataDocument_SEL_T002_A != null)
                            {
                                MC.ItemsEntity = (ObservableCollection<SEL_T002_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_SEL_T002_A, MC.ItemsEntity);
                            }
                            else
                            {
                                MC.ItemsEntity = new ObservableCollection<SEL_T002_A>();
                            }
                            ItemDataGridCollection = MC.ItemsEntity;

                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Record Save Successfully!", this.Title);
                            showMessageService.ShowMessage();
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
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Item Code AND Unit Code Is Required");
                        showMessageService.ShowMessage();

                    }
                    RemoveRefDoc();
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Item Code AND Unit Code Is Required");
                    showMessageService.ShowMessage();
                }
                var msg = new NotificationMessage(ts_code_vm);
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
        protected override void OnCreateAction(InquiryActionResult<SEL_T002> result)
        {
            try
            {
                blNew = true;
                foreach (var item in MC.Reference_Docs)
                {
                    if (item.Select == true)
                    {
                        item.Select = false;
                    }
                }
                ReferenceDocCollection = CollectionViewSource.GetDefaultView(MC.Reference_Docs); 
                ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                ItemDataGridCollection = new ObservableCollection<SEL_T002_A>();
                MasterEntity = new SEL_T002();
                DefaultValues();
                var msg = new NotificationMessage(ts_code_vm);
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
        protected override void OnRemoveAction(InquiryActionResult<SEL_T002> result)
        {
            try
            {
                if (MasterEntity.sch_no != null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Delete Changes";
                    showMessageService.Text = String.Format("This record will be Deleted forever '{0}'", this.Title);
                    if (showMessageService.ShowMessage() == DialogResult.Ok)
                    {
                        this.MasterEntity.EndEdit();
                        string response = repository.Delete(MasterEntity.sch_no, "DeliveryScheduleSTD", "CRM");
                        DataGridCollectionBackFlip.Refresh();
                        MasterEntity = new SEL_T002();
                        ItemDataGridCollection = new ObservableCollection<SEL_T002_A>();
                    }
                }
                blNew = true;
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
        protected override void OnDiscardAction(InquiryActionResult<SEL_T002> result)
        { }
        protected override void OnFevoriteAction(InquiryActionResult<SEL_T002> result)
        { }
        protected override void OnFlipAction(InquiryActionResult<SEL_T002> result)
        { }
        protected override void OnHelpAction(InquiryActionResult<SEL_T002> result)
        { }
        protected override void OnPrintAction(InquiryActionResult<SEL_T002> result)
        {

            try
            {
                string Request = "SO_Report" + "!@"  + MasterEntity.sch_no;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T002>(MCTemp, Request, "DeliveryScheduleSTD", "CRM", "", 0, "");
                object[] objDataSource = new object[5];
                string[] objDataSourceName = new string[5];



                objDataSource[0] = MCTemp.SalesOrderMaster;
                objDataSource[1] = MCTemp.SalesOrderEntity;
                objDataSource[2] = MCTemp.ItemsEntity;



                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[3] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[4] = Result;


                objDataSourceName[0] = "dsSalesQuotation";
                objDataSourceName[1] = "dsSalesQuotationItem";
                objDataSourceName[2] = "dsScheduleDetailsEntity";

                objDataSourceName[3] = "dsCompany";
                objDataSourceName[4] = "dsLocation";
                //objDataSourceName[4] = "dsScheduleDetailsEntity";


                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\SalesOrder2.rdlc", getParametersList(), "SalesOrder2");
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
        protected override void OnRefreshCommand(InquiryActionResult<SEL_T002> result)
        {
            string Request = "Refresh" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + (MasterEntity.doc_cat ?? this.doc_cat_vm) + "!@" + (MasterEntity.doc_type ?? doc_cat_vm) + "!@!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + this.ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code;
            MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T002>(MCTemp, Request, "DeliveryScheduleSTD", "CRM", " ", 0, "");

            MC.Reference_Docs = MCTemp.Reference_Docs;
            ReferenceDocCollection = CollectionViewSource.GetDefaultView(MC.Reference_Docs); //(from o in MC.Reference_Docs where o.doc_cat == "SD" select o).ToList()
            ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

        }

        protected override void OnLedgerViewCommand(InquiryActionResult<SEL_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<SEL_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<SEL_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<SEL_T002> result)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region FilterMethods
        //Filter StringBackFlip 
        private string _filterString_BackFlip;
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
            if (_DataGridCollectionBackFlip != null)
            {
                _DataGridCollectionBackFlip.Refresh();
            }
        }
        public bool Filter_BackFlip(object obj)
        {
            var data = obj as SEL_T002_BackFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BackFlip))
                {
                    return (data.sch_no != null && data.sch_no.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.Location != null && data.Location.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.del_add != null && data.del_add.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.sono != null && data.sono.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.sch_date != null && data.sch_date.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.contact_name != null && data.contact_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.employee_name != null && data.employee_name.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_BackFlip.ToLower())) ||
                           (data.t_display != null && data.t_display.ToString().ToLower().Contains(_filterString_BackFlip.ToLower()));
                }
                return true;
            }
            return false;

        }

        // Filter ReferenceDoc
        private string _FilterString_ReferenceDoc;
        public string FilterString_ReferenceDoc
        {
            get { return _FilterString_ReferenceDoc; }
            set
            {
                _FilterString_ReferenceDoc = value;
                RaisePropertyChanged("FilterString_ReferenceDoc");
                FilterCollection_ReferenceDoc();
            }
        }
        private void FilterCollection_ReferenceDoc()
        {
            if (_ReferenceDocCollection != null)
            {
                _ReferenceDocCollection.Refresh();
            }
        }
        public bool Filter_ReferenceDoc(object obj)
        {
            var data = obj as SEL_T001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_ReferenceDoc))
                {
                    return (data.sono != null && data.sono.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.ship_to_party_name != null && data.ship_to_party_name.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.ship_to_party != null && data.ship_to_party.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.sodate != null && data.sodate.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.so_code != null && data.so_code.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.location != null && data.location.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.cust_ref != null && data.cust_ref.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.date_planned != null && data.date_planned.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.expect_date != null && data.expect_date.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.Description != null && data.Description.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower())
                       );
                }
                return true;
            }
            return false;
        }

        
        #endregion
    }
}
