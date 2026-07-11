using Reflection.Presentation.ViewModel;
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
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class SEL_T002_VM : WorkspaceViewModel<SEL_T002>
    {
        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = MasterEntity.HasErrors;
            if (sender.ToString() == "confirm_qty" || sender.ToString() == "sch_qty")
            {
                if (ItemDataGridSelectedIndex != -1 && ItemDataGridCollection.Count > ItemDataGridSelectedIndex && ItemDataGridSelectedIndex >= 0)
                {
                    var temp = (from o in ItemDataGridCollection where o.ItemCode == ItemDataGridCollection[ItemDataGridSelectedIndex].ItemCode select o).ToList();
                    if (temp.Count > 0)
                    {
                        foreach (var o in temp)
                        {
                            temp[ItemDataGridSelectedIndex].bal_qty = o.sch_qty - Convert.ToDecimal(o.confirm_qty);
                        }
                    }
                }
            }
        }
        #region Variable Declarations
        bool blNew = true;
        string PreviousUnitCode = "";
        string NewUnitCode = "";
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        WebServiceRepository<SEL_T002> repository = new WebServiceRepository<SEL_T002>();
        WebServiceRepository<MultipleContext_SEL_T002> repository_MC = new WebServiceRepository<MultipleContext_SEL_T002>();
        WebServiceRepository<MultipleContext_SEL_T002> repository_MCTemp = new WebServiceRepository<MultipleContext_SEL_T002>();
        ObjectSerializationService obj = new ObjectSerializationService();
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
        private MultipleContext_SEL_T002 _MCTemp2 = new MultipleContext_SEL_T002();
        public MultipleContext_SEL_T002 MCTemp2
        {
            get { return _MCTemp2; }
            set
            {
                if (_MCTemp2 != value)
                {
                    _MCTemp2 = value; RaisePropertyChanged("MCTemp2");
                }
            }
        }
        private SEL_T002 _MasterEntity;
        public SEL_T002 MasterEntity
        {
            get { return _MasterEntity; }
            set { if (_MasterEntity != value) { _MasterEntity = value; RaisePropertyChanged(nameof(MasterEntity)); value.BeginEdit(); } }
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

        private List<SEL_T002> _MasterList;
        public List<SEL_T002> MasterList
        {
            get { return _MasterList; }
            set { if (_MasterList != value) { _MasterList = value; RaisePropertyChanged("MasterList"); } }
        }

        private SEL_T002_BackFlip _BackFlipEntity;
        public SEL_T002_BackFlip BackFlipEntity
        {
            get { return _BackFlipEntity; }
            set { if (_BackFlipEntity != value) { _BackFlipEntity = value; RaisePropertyChanged("BackFlipEntity"); } }
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
                    FilterScheduleShipToAdd();
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
                var msg = new NotificationMessage("SEL_T002_VM");
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
        #endregion
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SEL_T002_VM));
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
        private AutoSuggestTextViewModel<dynamic> _ASSoldToParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSoldToParty
        {
            get { return _ASSoldToParty; }
            set
            {
                if (_ASSoldToParty != value)
                {
                    _ASSoldToParty = value; RaisePropertyChanged("ASSoldToParty");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASReqNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASReqNo
        {
            get { return _ASReqNo; }
            set
            {
                if (_ASReqNo != value)
                {
                    _ASReqNo = value; RaisePropertyChanged("ASReqNo");
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
        public AutoSuggestTextViewModel<dynamic> ASDelLocation
        {
            get { return _ASDelLocation; }
            set
            {
                if (_ASDelLocation != value)
                {
                    _ASDelLocation = value; RaisePropertyChanged("ASDelLocation");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASItems { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItems
        {
            get { return _ASItems; }
            set
            {
                if (_ASItems != value)
                {
                    _ASItems = value; RaisePropertyChanged("ASItems");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASSalesNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSalesNo
        {
            get { return _ASSalesNo; }
            set
            {
                if (_ASSalesNo != value)
                {
                    _ASSalesNo = value; RaisePropertyChanged("ASSalesNo");
                }
            }
        }
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

        private AutoSuggestTextViewModel<dynamic> _ASSchShipToParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSchShipToParty
        {
            get { return _ASSchShipToParty; }
            set
            {
                if (_ASSchShipToParty != value)
                {
                    _ASSchShipToParty = value; RaisePropertyChanged("ASSchShipToParty");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASSchShipToAdd { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSchShipToAdd
        {
            get { return _ASSchShipToAdd; }
            set
            {
                if (_ASSchShipToAdd != value)
                {
                    _ASSchShipToAdd = value; RaisePropertyChanged("ASSchShipToAdd");
                }
            }
        }


        private AutoSuggestTextViewModel<dynamic> _ASdgRefNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASdgRefNo
        {
            get { return _ASdgRefNo; }
            set
            {
                if (_ASdgRefNo != value)
                {
                    _ASdgRefNo = value; RaisePropertyChanged("ASdgRefNo");
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
        private AutoSuggestTextViewModel<dynamic> _ASFltrt_status { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFltrt_status
        {
            get { return _ASFltrt_status; }
            set
            {
                if (_ASFltrt_status != value)
                {
                    _ASFltrt_status = value; RaisePropertyChanged("ASFltrt_status");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASFltrLocation { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFltrLocation
        {
            get { return _ASFltrLocation; }
            set
            {
                if (_ASFltrLocation != value)
                {
                    _ASFltrLocation = value; RaisePropertyChanged("ASFltrLocation");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASFltrSoldToParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFltrSoldToParty
        {
            get { return _ASFltrSoldToParty; }
            set
            {
                if (_ASFltrSoldToParty != value)
                {
                    _ASFltrSoldToParty = value; RaisePropertyChanged("ASFltrSoldToParty");
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
                    if (SourceName == "ItemCode")
                    { ASDefault = ASItems; }
                    else if (SourceName == "unit_code")
                    { ASDefault = ASUOM; }
                    else if (SourceName == "sono")
                    { ASDefault = ASSalesNo; }
                    else
                    if (SourceName == "ship_to_PartyNm")
                    { ASDefault = ASSchShipToParty; }
                    else if (SourceName == "ship_to_addNm")
                    {
                        ASDefault = ASSchShipToAdd;
                        FilterScheduleShipToAdd();
                    }
                    else if (SourceName == "ref_no")
                    { ASDefault = ASdgRefNo; }
                }
            }
        }
        #endregion     
        #region Observable Collection
        private ObservableCollection<SEL_T001_schedule_P> _SoScheduleCollectiontemp;
        public ObservableCollection<SEL_T001_schedule_P> SoScheduleCollectiontemp
        {
            get { return _SoScheduleCollectiontemp; }
            set { if (_SoScheduleCollectiontemp != value) { _SoScheduleCollectiontemp = value; RaisePropertyChanged("SoScheduleCollectiontemp"); } }
        }
        private ObservableCollection<SEL_T002_Req_P> _ReqDetailscollectiontemp;
        public ObservableCollection<SEL_T002_Req_P> ReqDetailscollectiontemp
        {
            get { return _ReqDetailscollectiontemp; }
            set { if (_ReqDetailscollectiontemp != value) { _ReqDetailscollectiontemp = value; RaisePropertyChanged("ReqDetailscollectiontemp"); } }
        }
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
        public RelayCommand<object> Commandparty { get; private set; }
        public RelayCommand<object> CommandSales { get; private set; }
        public RelayCommand<object> CommandScheduleRecby { get; private set; }
        public RelayCommand<object> CommandSchby { get; private set; }
        public RelayCommand<object> CommandAddItem { get; private set; }
        public RelayCommand<object> CommandSalesNo { get; private set; }
        public RelayCommand<object> CommandUnit { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByByDocumentNumber { get; private set; }
        public RelayCommand<object> CommandReqNo { get; private set; }
        public RelayCommand cmdInsertTransferOrder { get; private set; }
        public RelayCommand<object> CmdInsertReferenceDoc { get; private set; }
        public RelayCommand cmdLoadRefdocumentNo { get; private set; }
        public RelayCommand<object> cmdLoadAddress { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand cmdCloseStatus { get; private set; }
        public RelayCommand<object> cmdSchShipToParty { get; private set; }
        public RelayCommand<object> cmdSchShipToAdd { get; private set; }
        public RelayCommand<IList> dgSelectionChanged { get; private set; }
        public RelayCommand<object> CmdAddSelectedRef { get; private set; }
        public RelayCommand<object> CommandFltrLocation { get; private set; }
        public RelayCommand<object> CommandFltrStatus { get; private set; }
        public RelayCommand<object> CommandFltrSoldToParty { get; private set; }
        public RelayCommand<object> CommandLoadHistory { get; private set; }
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
        private ICollectionView _ItemCollection;
        public ICollectionView ItemCollection
        {
            get { return _ItemCollection; }
            set { _ItemCollection = value; RaisePropertyChanged("ItemCollection"); }
        }

        private ICollectionView _ReferenceDocCollection;
        public ICollectionView ReferenceDocCollection
        {
            get { return _ReferenceDocCollection; }
            set { _ReferenceDocCollection = value; RaisePropertyChanged("ReferenceDocCollection"); }
        }


        private ICollectionView _RequirementCollection1;
        public ICollectionView RequirementCollection1
        {
            get { return _RequirementCollection1; }
            set { _RequirementCollection1 = value; RaisePropertyChanged("RequirementCollection1"); }
        }
        private ICollectionView _DataGridCollectionBackFlip;
        public ICollectionView DataGridCollectionBackFlip
        {
            get { return _DataGridCollectionBackFlip; }
            set { _DataGridCollectionBackFlip = value; RaisePropertyChanged("DataGridCollectionBackFlip"); }
        }

        private ICollectionView _SoScheduleCollection;
        public ICollectionView SoScheduleCollection
        {
            get { return _SoScheduleCollection; }
            set { _SoScheduleCollection = value; RaisePropertyChanged("SoScheduleCollection"); }

        }

        #endregion
        #region String List
        private List<string> _StrList_Flip;
        public List<string> StrList_Flip
        {
            get { return _StrList_Flip; }
            set
            {
                if (_StrList_Flip != value)
                {
                    _StrList_Flip = value;
                }
            }
        }
        public List<ADM_M038_C> _UnitConversionList;
        public List<ADM_M038_C> UnitConversionList
        {
            get
            {
                return _UnitConversionList;
            }
            set
            {
                _UnitConversionList = value;
                RaisePropertyChanged("UnitConversionList");
            }
        }
        private List<string> _StrListItems;
        public List<string> StringListItems
        {
            get { return _StrListItems; }
            set
            {
                if (_StrListItems != value)
                {
                    _StrListItems = value;
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


        private List<SEL_T002_BackFlip> _BackFlipList;
        public List<SEL_T002_BackFlip> BackFlipList
        {
            get { return _BackFlipList; }
            set { if (_BackFlipList != value) { _BackFlipList = value; RaisePropertyChanged("BackFlipList"); } }
        }
        private List<SEL_T002_P_RefDoc> _refdoctempa;
        public List<SEL_T002_P_RefDoc> refdoctempa
        {
            get { return _refdoctempa; }
            set
            {
                if (_refdoctempa != value)
                {
                    _refdoctempa = value;
                }
            }
        }
        #endregion
        #region Constructor
        public SEL_T002_VM(string ts_code) : base()
        {
            CursorControl.SetBusyState();
            this.ts_code_vm = ts_code;
            NotificationDataCollection = new List<NotificationData>();
            //SEL_T002.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            SEL_T002_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            MC = new MultipleContext_SEL_T002();
            MCTemp = new MultipleContext_SEL_T002();
            ItemDataGridCollection = new ObservableCollection<SEL_T002_A>();
            RequestPara = new RequestParameters();
            MasterList = new List<SEL_T002>();
            MasterEntity = new SEL_T002();
            BackFlipEntity = new SEL_T002_BackFlip();
            post = true;
            MasterEntity.ValidateAsync().Wait();
            MasterEntity.sch_date = System.DateTime.Now;
            LoadInitialData();
        }
        public SEL_T002_VM(string ts_code, string doc_no) : base()
        {
            CursorControl.SetBusyState();
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            NotificationDataCollection = new List<NotificationData>();
            //SEL_T002.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            SEL_T002_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            MC = new MultipleContext_SEL_T002();
            MCTemp = new MultipleContext_SEL_T002();
            ItemDataGridCollection = new ObservableCollection<SEL_T002_A>();
            RequestPara = new RequestParameters();
            MasterList = new List<SEL_T002>();
            MasterEntity = new SEL_T002();
            BackFlipEntity = new SEL_T002_BackFlip();
            post = true;
            MasterEntity.ValidateAsync().Wait();
            MasterEntity.sch_date = System.DateTime.Now;
            LoadInitialData();
        }
        #endregion
        #region User Defined Function
        private void SetPopupSuggestionDataAfterLoad()
        {
            try
            {
                ASSoldToParty.AutoSuggestVM.Suggestion = MC.PartyMaster.Find(x => x.PartyId == MasterEntity.PartyId);
                ASReqNo.AutoSuggestVM.Suggestion = MC.Req_Details.Find(x => x.sch_no == MasterEntity.ref_no);
                //ASSchBy.AutoSuggestVM.Suggestion = MC.contactInfoMaster.Find(x => x.ContInfoId.ToString() == MasterEntity.ContInfoId.ToString());
                ASSchRecBy.AutoSuggestVM.Suggestion = MC.EmployeeEntity.Find(x => x.EmpId == MasterEntity.EmpId);

                //ASDelLocation.AutoSuggestVM.Suggestion = MC.DeliveryAddress.Find(x => x.SrNo == MasterEntity.del_address);

                ASFltrLocation.AutoSuggestVM.Suggestion = LocationList.Find(x => x.location_Id == RequestPara.location_id);
                ASFltrSoldToParty.AutoSuggestVM.Suggestion = MC.PartyMaster.Find(x => x.PartyNm == RequestPara.PartyId);
                ASFltrt_status.AutoSuggestVM.Suggestion = MC.t_statusList.Find(x => x.t_display == RequestPara.t_display);
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
        string DocumentList = "";
        private void AddSelectedRef(object InputValue)
        {
            try
            {
                SEL_T002_P_RefDoc POPUPEntityObject = null;
                string Request;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ScheduleReference.Where(x => x.Ref_DocNo.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<SEL_T002_P_RefDoc>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T002_P_RefDoc>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    if (POPUPEntityObject.t_status != "009")
                    {
                        MasterEntity.ref_doc_no = POPUPEntityObject.Ref_DocNo;
                        MasterEntity.ref_doc_cat = POPUPEntityObject.doc_cat;
                        MasterEntity.ref_doc_type = POPUPEntityObject.Ref_DocType;

                        DocumentList = "";
                        if (MasterEntity.ref_doc_cat == "SO")
                        {
                            refdoctempa = (from o in MC.ScheduleReference where o.doc_cat == "SO" select o).ToList();
                            ReferenceDocCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                            ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                        }
                       
                        var refdoc = from o in refdoctempa
                                     where o.PartyId == POPUPEntityObject.PartyId
                                            && o.PartyNm == POPUPEntityObject.PartyNm
                                            && o.so_code == POPUPEntityObject.so_code
                                            && o.curr_code == POPUPEntityObject.curr_code
                                            && o.del_address == POPUPEntityObject.del_address
                                            && o.doc_cat == POPUPEntityObject.doc_cat
                                            && o.p_term_code == POPUPEntityObject.p_term_code
                                            && o.incoterms == POPUPEntityObject.incoterms
                                            && o.country_nm_s == POPUPEntityObject.country_nm_s
                                     select o;
                        foreach (var item in refdoc)
                        {
                            if (item.Select == true)
                            {
                                DocumentList = DocumentList + "," + item.Ref_DocNo;
                            }
                        }
                        DocumentList = DocumentList.ToString().TrimStart(new char[] { ',' });
                        if (MasterEntity.ref_doc_cat == "SO")
                        {
                            if (POPUPEntityObject.Select == true)
                            {
                                ReferenceDocCollection = CollectionViewSource.GetDefaultView(refdoc);
                                ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                            }
                        }

                        if (DocumentList == "")
                        {
                            MasterEntity.ref_doc_no = null;
                            MasterEntity.ref_doc_cat = null;
                            MasterEntity.ref_doc_type = null;

                        }
                    }
                    else if (POPUPEntityObject.Select == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("This Document is Suspended. You Cannot Proceed with this Document.");
                        showMessageService.ShowMessage();
                    }
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
        private void InsertParty(object InputValue)
        {
            string Request = "";
            string RequestParameterData = "";
            ADM_M028_sch_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_sch_P>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    if (String.IsNullOrEmpty(MasterEntity.sch_no) != true || String.IsNullOrWhiteSpace(MasterEntity.sch_no) != true) //Condition: Only enter in the code block if ENtity Not null. Means It is in Edit Mode.
                    {
                        if (ItemDataGridCollection.Count > 0 && blNew == false)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Party Change Information";
                            showMessageService.Text = String.Format("Can not change party'{0}' in edit mode", this.Title);
                            showMessageService.ShowMessage();
                        }
                    }
                    else if (blNew == true && ItemDataGridCollection.Count > 0)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Party Selection";
                        showMessageService.Text = String.Format("If You Change The Party Items Will be removed'{0}'", this.Title);
                        if (showMessageService.ShowMessage() == DialogResult.Ok)
                        {
                            MasterEntity.PartyId = POPUPEntityObject.PartyId;
                            MasterEntity.PartyNm = POPUPEntityObject.PartyNm;

                            RequestParameterData = "LoadPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.PartyId;
                            MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T002>(MCTemp, RequestParameterData, "DeliverySchedule", "CRM", "", 0, "");

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).ContInfoId.ToString());
                            TheFilter = (o, prefix) => (((ADM_M028_C_P)o).ContInfoId.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower());
                            ASSchBy = new AutoSuggestTextViewModel<dynamic>(MCTemp.contactInfoMaster, TheFilter, SuggestedValue, "ContInfoId", true);
                            ASSchBy.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASSchBy.AutoSuggestVM.IsFreeTextAllowed = true;

                            if (MCTemp.contactInfoMaster.Count == 1)
                            {
                                MasterEntity.ContInfoId = MCTemp.contactInfoMaster[0].ContInfoId;
                                MasterEntity.contact_name = MCTemp.contactInfoMaster[0].PersonName;
                            }



                            SoScheduleCollection = CollectionViewSource.GetDefaultView(MCTemp.so_schedule);
                            RequirementCollection1 = CollectionViewSource.GetDefaultView(MCTemp.Req_Details);
                            MC.Req_Details = MCTemp.Req_Details;
                            //if (MC.Req_Details.Count() > 0)
                            //{
                            //    var ReqDetails = (from data in MC.Req_Details where data.ItemCode == ItemDataGridCollection[ItemDataGridSelectedIndex].ItemCode select data);
                            //    ReqDetailscollectiontemp = new ObservableCollection<SEL_T002_Req_P>(ReqDetails);
                            //}

                            ItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemsMaster);
                            ItemCollection.Filter = new Predicate<object>(Filter_Item);
                            StringListItems = MCTemp.ItemsMaster.Select(x => x.ItemCode).ToList();

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D_Add)x).SrNo.ToString());
                            TheFilter = (o, prefix) => (((ADM_M028_D_Add)o).SrNo.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower());
                            ASDelLocation = new AutoSuggestTextViewModel<dynamic>(MCTemp.DeliveryAddress, TheFilter, SuggestedValue, "del_address", true);
                            ASDelLocation.AutoSuggestVM.IsEmptyValueAllowed = true;
                            ASDelLocation.AutoSuggestVM.IsFreeTextAllowed = true;

                            if (MCTemp.DeliveryAddress.Count == 0)
                            {
                                MasterEntity.del_address = 0;
                                MasterEntity.del_add = "";
                                MasterEntity.Location = "";
                            }
                            if (MCTemp.DeliveryAddress.Count == 1)
                            {
                                MasterEntity.del_address = 0;
                                MasterEntity.del_add = "";
                                MasterEntity.Location = "";

                                MasterEntity.del_address = MCTemp.DeliveryAddress[0].SrNo;
                                MasterEntity.del_add = MCTemp.DeliveryAddress[0].del_add;
                                MasterEntity.Location = MCTemp.DeliveryAddress[0].Location;
                            }
                            else if (MCTemp.DeliveryAddress.Count > 1)
                            {
                                MasterEntity.del_address = 0;
                                MasterEntity.del_add = "";
                                MasterEntity.Location = "";

                                var DeliveryAddress = (from o in MCTemp.DeliveryAddress where o.AddType == "Delivery Address" select o).ToList();
                                if (DeliveryAddress.Count == 0)
                                {
                                    MasterEntity.del_address = 0;
                                    MasterEntity.del_add = ""; ;
                                    MasterEntity.Location = "";
                                }
                                else if (DeliveryAddress.Count == 1)
                                {
                                    MasterEntity.del_address = 0;
                                    MasterEntity.del_add = ""; ;
                                    MasterEntity.Location = "";

                                    MasterEntity.del_address = DeliveryAddress[0].SrNo;
                                    MasterEntity.del_add = DeliveryAddress[0].del_add;
                                    MasterEntity.Location = DeliveryAddress[0].Location;
                                }
                                else if (DeliveryAddress.Count > 1)
                                {
                                    MasterEntity.del_address = 0;
                                    MasterEntity.del_add = ""; ;
                                    MasterEntity.Location = "";

                                }
                            }

                            ItemDataGridCollection.Clear();

                        }
                    }
                    else
                    {

                        MasterEntity.PartyId = POPUPEntityObject.PartyId;
                        MasterEntity.PartyNm = POPUPEntityObject.PartyNm;

                        RequestParameterData = "LoadPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.PartyId;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T002>(MCTemp, RequestParameterData, "DeliverySchedule", "CRM", "", 0, "");

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).ContInfoId.ToString());
                        TheFilter = (o, prefix) => (((ADM_M028_C_P)o).ContInfoId.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASSchBy = new AutoSuggestTextViewModel<dynamic>(MCTemp.contactInfoMaster, TheFilter, SuggestedValue, "ContInfoId", true);
                        ASSchBy.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASSchBy.AutoSuggestVM.IsFreeTextAllowed = true;

                        if (MCTemp.contactInfoMaster.Count == 1)
                        {
                            MasterEntity.ContInfoId = MCTemp.contactInfoMaster[0].ContInfoId;
                            MasterEntity.contact_name = MCTemp.contactInfoMaster[0].PersonName;
                        }

                        SoScheduleCollection = CollectionViewSource.GetDefaultView(MCTemp.so_schedule);
                        RequirementCollection1 = CollectionViewSource.GetDefaultView(MCTemp.Req_Details);
                        MC.Req_Details = MCTemp.Req_Details;
                        //if (MC.Req_Details.Count() > 0)
                        //{
                        //    var ReqDetails = (from data in MC.Req_Details where data.ItemCode == ItemDataGridCollection[ItemDataGridSelectedIndex].ItemCode select data);
                        //    ReqDetailscollectiontemp = new ObservableCollection<SEL_T002_Req_P>(ReqDetails);
                        //}

                        ItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemsMaster);
                        ItemCollection.Filter = new Predicate<object>(Filter_Item);
                        StringListItems = MCTemp.ItemsMaster.Select(x => x.ItemCode).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D_Add)x).SrNo.ToString());
                        TheFilter = (o, prefix) => (((ADM_M028_D_Add)o).SrNo.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASDelLocation = new AutoSuggestTextViewModel<dynamic>(MCTemp.DeliveryAddress, TheFilter, SuggestedValue, "del_address", true);
                        ASDelLocation.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASDelLocation.AutoSuggestVM.IsFreeTextAllowed = true;

                        if (MCTemp.DeliveryAddress.Count == 0)
                        {
                            MasterEntity.del_address = 0;
                            MasterEntity.del_add = "";
                            MasterEntity.Location = "";
                        }
                        if (MCTemp.DeliveryAddress.Count == 1)
                        {
                            MasterEntity.del_address = 0;
                            MasterEntity.del_add = "";
                            MasterEntity.Location = "";

                            MasterEntity.del_address = MCTemp.DeliveryAddress[0].SrNo;
                            MasterEntity.del_add = MCTemp.DeliveryAddress[0].del_add;
                            MasterEntity.Location = MCTemp.DeliveryAddress[0].Location;
                        }
                        else if (MCTemp.DeliveryAddress.Count > 1)
                        {
                            MasterEntity.del_address = 0;
                            MasterEntity.del_add = "";
                            MasterEntity.Location = "";

                            var DeliveryAddress = (from o in MCTemp.DeliveryAddress where o.AddType == "Delivery Address" select o).ToList();
                            if (DeliveryAddress.Count == 0)
                            {
                                MasterEntity.del_address = 0;
                                MasterEntity.del_add = ""; ;
                                MasterEntity.Location = "";
                            }
                            else if (DeliveryAddress.Count == 1)
                            {
                                MasterEntity.del_address = 0;
                                MasterEntity.del_add = ""; ;
                                MasterEntity.Location = "";

                                MasterEntity.del_address = DeliveryAddress[0].SrNo;
                                MasterEntity.del_add = DeliveryAddress[0].del_add;
                                MasterEntity.Location = DeliveryAddress[0].Location;
                            }
                            else if (DeliveryAddress.Count > 1)
                            {
                                MasterEntity.del_address = 0;
                                MasterEntity.del_add = ""; ;
                                MasterEntity.Location = "";

                            }
                        }



                    }
                    var msg = new NotificationMessage("SEL_T002_VM");
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
        private void InsertSales(object InputValue)
        {
            string Request = "";
            SEL_T002_Req_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Req_Details.Where(x => x.sch_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T002_Req_P>().ToList()[0];
                }

                #endregion
                if (POPUPEntityObject != null)
                {

                    MasterEntity.ref_no = POPUPEntityObject.sch_no;

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
        private void InsertReqNo(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            SEL_T002_Req_P POPUPEntityObject = null;

            try
            {
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Req_Details.Where(x => x.sch_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SEL_T002_Req_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T002_Req_P>().ToList()[0];
                    }

                }

                #endregion

                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (ItemDataGridSelectedIndex >= 0 && ItemDataGridCollection.Count > ItemDataGridSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        ItemDataGridCollection[ItemDataGridSelectedIndex].ref_no = POPUPEntityObject.sch_no;

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

        private void InsertEmployee(object InputValue)
        {
            string Request = "";
            ADM_M024_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.EmployeeEntity.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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

                    MasterEntity.sch_rec_by_cd = POPUPEntityObject.EmpId;
                    MasterEntity.EmpId = POPUPEntityObject.EmpId;
                    MasterEntity.employee_name = POPUPEntityObject.EmpName;

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
                        { POPUPEntityObject = MCTemp.contactInfoMaster.Where(x => x.ContInfoId.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
        private void InsertItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M022_P ItemDetails = null;

                #region Command Parameter Read Section

                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)// && InputValue.ToString().Trim() != "")
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();

                    if (Request.Length > 0)
                    {
                        try
                        {
                            ItemDetails = MC.ItemsMaster.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    ItemDetails = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                }

                #endregion

                if (ItemDetails != null)
                {
                    var InputValueIfExists = ItemDataGridCollection.Where(X => X.ItemCode == ItemDetails.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemDataGridCollection.IndexOf(ItemDataGridCollection.Where(X => X.ItemCode == ItemDetails.ItemCode).FirstOrDefault()); // Prefer Primary Key for this instruction.
                    var LineId = ItemDataGridCollection.Count + 1;
                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemDataGridCollection.Count == ItemDataGridSelectedIndex)
                    {
                        ItemDataGridCollection.Add(new SEL_T002_A()
                        {
                            line_id = LineId,
                            ItemCode = ItemDetails.ItemCode,
                            ItemName = ItemDetails.ItemName,
                            custItemcode = ItemDetails.CustItemCode,
                            comp_code = AppSessionState.comp_code,
                            location_Id = AppSessionState.location_Id,
                            unit_code = ItemDetails.unit_code,
                            add_by = AppSessionState.UserID,
                            add_date = DateTime.Now,
                            editby = AppSessionState.UserID,
                            active = true,
                            t_status = MasterEntity.t_status,
                            t_display = MasterEntity.t_display,
                            fin_year = "17-18",
                            posting_period = "1",
                            sono = ItemDetails.ref_doc_no,
                            ref_doc_no = ItemDetails.ref_doc_no,
                            rate = ItemDetails.unit_price,
                            so_item_id = ItemDetails.so_item_id

                        });
                    }
                    else if (ItemDataGridSelectedIndex >= 0 && ItemDataGridCollection.Count > ItemDataGridSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        if (ItemDataGridCollection[ItemDataGridSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))// It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            if (ItemDataGridCollection[ItemDataGridSelectedIndex].line_id == 0)
                            {
                                ItemDataGridCollection[ItemDataGridSelectedIndex].line_id = ItemDataGridCollection.Count;
                            }
                            ItemDataGridCollection[ItemDataGridSelectedIndex].line_id = 0;
                            ItemDataGridCollection[ItemDataGridSelectedIndex].ItemCode = ItemDetails.ItemCode;
                            ItemDataGridCollection[ItemDataGridSelectedIndex].ItemName = ItemDetails.ItemName;
                            ItemDataGridCollection[ItemDataGridSelectedIndex].custItemcode = ItemDetails.CustItemCode;
                            ItemDataGridCollection[ItemDataGridSelectedIndex].unit_code = ItemDetails.unit_code;
                            ItemDataGridCollection[ItemDataGridSelectedIndex].comp_code = AppSessionState.comp_code;
                            ItemDataGridCollection[ItemDataGridSelectedIndex].location_Id = AppSessionState.location_Id;
                            ItemDataGridCollection[ItemDataGridSelectedIndex].add_by = AppSessionState.UserID;
                            ItemDataGridCollection[ItemDataGridSelectedIndex].active = true;
                            ItemDataGridCollection[ItemDataGridSelectedIndex].fin_year = "15-16";
                            ItemDataGridCollection[ItemDataGridSelectedIndex].posting_period = "1";
                            ItemDataGridCollection[ItemDataGridSelectedIndex].sono = ItemDetails.ref_doc_no;
                            ItemDataGridCollection[ItemDataGridSelectedIndex].ref_doc_no = ItemDetails.ref_doc_no;
                            ItemDataGridCollection[ItemDataGridSelectedIndex].so_item_id = ItemDetails.so_item_id;
                            ItemDataGridCollection[ItemDataGridSelectedIndex].rate = ItemDetails.rate;
                            ItemDataGridCollection[ItemDataGridSelectedIndex].t_status = MasterEntity.t_status;
                            ItemDataGridCollection[ItemDataGridSelectedIndex].t_display = MasterEntity.t_display;
                        }
                        else if (ItemDataGridCollection[ItemDataGridSelectedIndex].ItemCode != ItemDetails.ItemCode)
                        {
                            ItemDataGridCollection[ItemDataGridSelectedIndex].ItemCode = "";
                        }
                    }
                }
                ItemDetails.Select = false;

                #region Clear Empty Row

                SEL_T002_A newObj = new SEL_T002_A();
                for (int i = ItemDataGridCollection.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemDataGridCollection[i].ComparePropertiesTo(newObj);
                    if (ItemDataGridCollection[i].ComparePropertiesTo(newObj) && ItemDataGridCollection.Count > 1)
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
        private void InsertSalesNo(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {

            string Request = "";
            SEL_T001_schedule_P POPUPEntityObject = null;

            try
            {
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.so_schedule.Where(x => x.sono.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SEL_T001_schedule_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T001_schedule_P>().ToList()[0];
                    }

                }

                #endregion
                if (POPUPEntityObject != null)
                {
                    if (ItemDataGridSelectedIndex >= 0 && ItemDataGridCollection.Count > ItemDataGridSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        ItemDataGridCollection[ItemDataGridSelectedIndex].sono = POPUPEntityObject.sono;
                        ItemDataGridCollection[ItemDataGridSelectedIndex].ref_doc_no = POPUPEntityObject.sono;

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


        private void unitconversion()
        {
            try
            {
                var CurrantUnitCF = (from o in UnitConversionList where (o.unit_code == PreviousUnitCode) select o).ToList();
                var NewUnitCF = (from o in UnitConversionList where (o.unit_code == NewUnitCode) select o).ToList();
                if (CurrantUnitCF.Count > 0 && NewUnitCF.Count > 0)
                {
                    ItemDataGridCollection[ItemDataGridSelectedIndex].confirm_qty = (ItemDataGridCollection[ItemDataGridSelectedIndex].confirm_qty * CurrantUnitCF[0].c_factor) / NewUnitCF[0].c_factor;
                    ItemDataGridCollection[ItemDataGridSelectedIndex].rate = (ItemDataGridCollection[ItemDataGridSelectedIndex].rate / CurrantUnitCF[0].c_factor) * NewUnitCF[0].c_factor;
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
                            NewUnitCode = ItemDataGridCollection[ItemDataGridSelectedIndex].unit_code;
                        }
                        else if (ItemDataGridCollection[ItemDataGridSelectedIndex].unit_code != POPUPEntityObject.unit_code)
                        {
                            PreviousUnitCode = ItemDataGridCollection[ItemDataGridSelectedIndex].unit_code;
                            ItemDataGridCollection[ItemDataGridSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                            NewUnitCode = ItemDataGridCollection[ItemDataGridSelectedIndex].unit_code;
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
                        { Request = "LoadALL" + "!@" + ParametersStringValue; }
                        catch (Exception ex) { }
                    }

                }

                else if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<SEL_T002_BackFlip>().ToList().Count > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)ParameterObject).Cast<SEL_T002_BackFlip>().ToList()[0];

                        blNew = false;
                        string RequestParameterData = "LoadDocumentWithReferenceDocumentNumber" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + POPUPEntityObject.sch_no;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T002>(MCTemp, RequestParameterData, "DeliverySchedule", "CRM", "", 0, "");

                        MasterList = MCTemp.MasterEntity;
                        MasterEntity = MasterList[0];

                        SelectedTabControlIndex = 0;

                        ItemDataGridCollection = MCTemp.ItemsEntity;
                        MC.ItemsMaster = MCTemp.ItemsMaster;
                        ItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemsMaster);
                        ItemCollection.Filter = new Predicate<object>(Filter_Item);
                        StringListItems = MCTemp.ItemsMaster.Select(x => x.ItemCode).ToList();

                        SoScheduleCollection = CollectionViewSource.GetDefaultView(MCTemp.so_schedule);


                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T002_Req_P)x).sch_no);
                        TheFilter = (o, prefix) => (((SEL_T002_Req_P)o).sch_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASReqNo = new AutoSuggestTextViewModel<dynamic>(MCTemp.Req_Details, TheFilter, SuggestedValue, "ref_no", true);
                        ASReqNo.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASReqNo.AutoSuggestVM.IsFreeTextAllowed = true;

                        AttachmentCollection = MCTemp.Attachment;

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D_Add)x).SrNo.ToString());
                        TheFilter = (o, prefix) => (((ADM_M028_D_Add)o).SrNo.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASDelLocation = new AutoSuggestTextViewModel<dynamic>(MCTemp.DeliveryAddress, TheFilter, SuggestedValue, "del_address", true);
                        ASDelLocation.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASDelLocation.AutoSuggestVM.IsFreeTextAllowed = true;

                        blNew = false;

                        if (MasterEntity.t_status == "INPROCESS" || MasterEntity.t_status == "InProcess")
                        {
                            post = false;
                        }
                        if (MasterEntity.t_status == "DRAFT" || MasterEntity.t_status == "Draft" || MasterEntity.t_status == null)
                        {
                            post = true;
                        }
                    }
                }
                //SetPopupSuggestionDataAfterLoad();
                MasterEntity.ts_code = ts_code_vm;
                var msg = new NotificationMessage("SEL_T002_VM");
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
        private void LoadReferenceDocNo()
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "";

                if (DocumentList == null || DocumentList == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Refernece Selection";
                    showMessageService.Text = String.Format("Please Select Referance No", this.Title);
                    showMessageService.ShowMessage();
                }
                else
                {
                    Request = "LoadDocumentFromSOReferneceNo" + "!@" + DocumentList;

                    MCTemp2 = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T002>(MCTemp2, Request, "DeliverySchedule", "CRM", " ", 0, "");

                    if (MCTemp2.MasterEntity.Count > 0)
                    {
                        MasterEntity = MCTemp2.MasterEntity[0];
                    }
                    else
                    {
                        MasterEntity = new SEL_T002();
                    }
                   
                    if (MCTemp2.ItemsEntity != null)
                    {
                        ItemDataGridCollection = MCTemp2.ItemsEntity;

                    }
                    else
                    {
                        MCTemp2.ItemsEntity = new ObservableCollection<SEL_T002_A>();
                    }
                   
                    //MC.ItemsMaster = MCTemp2.ItemsMaster;

                    //ItemCollection = CollectionViewSource.GetDefaultView(MCTemp2.ItemsMaster);
                    //ItemCollection.Filter = new Predicate<object>(Filter_Item);
                    //StringListItems = MCTemp2.ItemsMaster.Select(x => x.ItemCode).ToList();

                    MCTemp.contactInfoMaster=MCTemp2.contactInfoMaster;
                    MCTemp.DeliveryAddress = MCTemp2.DeliveryAddress;
               

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_C_P)x).ContInfoId.ToString());
                    TheFilter = (o, prefix) => (((ADM_M028_C_P)o).ContInfoId.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASSchBy = new AutoSuggestTextViewModel<dynamic>(MCTemp.contactInfoMaster, TheFilter, SuggestedValue, "ContInfoId", true);
                    ASSchBy.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASSchBy.AutoSuggestVM.IsFreeTextAllowed = true;

                    if (MCTemp2.contactInfoMaster.Count == 1)
                    {
                        MasterEntity.ContInfoId = MCTemp2.contactInfoMaster[0].ContInfoId;
                        MasterEntity.contact_name = MCTemp2.contactInfoMaster[0].PersonName;
                    }

                    SoScheduleCollection = CollectionViewSource.GetDefaultView(MCTemp2.so_schedule);
                    if (MCTemp2.MasterEntity[0].del_address.ToString() != null)
                    {
                        MasterEntity.del_address = MCTemp2.MasterEntity[0].del_address;
                        MasterEntity.del_add = MCTemp2.MasterEntity[0].del_add;
                        MasterEntity.Location = MCTemp2.MasterEntity[0].Location;
                    }

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D_Add)x).SrNo.ToString());
                    TheFilter = (o, prefix) => (((ADM_M028_D_Add)o).SrNo.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASDelLocation = new AutoSuggestTextViewModel<dynamic>(MCTemp.DeliveryAddress, TheFilter, SuggestedValue, "del_address", true);
                    ASDelLocation.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASDelLocation.AutoSuggestVM.IsFreeTextAllowed = true;

                    DefaultValues();
                }
                //}
                var msg = new NotificationMessage("SEL_T002_VM");
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
        private void InsertFltrStatus(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M025 POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.t_statusList.Where(x => x.t_display.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M0013>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M025>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    RequestPara.t_status = POPUPEntityObject.t_status;
                    RequestPara.t_display = POPUPEntityObject.t_display;
                }
            }
            catch (Exception Ex) { }
        }
        private void InsertFltrLocation(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
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
                    if (((IEnumerable)InputValue).Cast<ADM_M003>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    RequestPara.location_id = POPUPEntityObject.location_Id;
                }
            }
            catch (Exception Ex) { }
        }
        private void LoadHistory()
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadHistory" + "!@" + AppSessionState.comp_code + "!@" + MasterEntity.location_Id + "!@" + "" + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + AppSessionState.EmpId + "!@" + Convert.ToDateTime(RequestPara.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(RequestPara.ToDate).ToString("MM/dd/yyyy") + "!@" + "" + "!@" + RequestPara.t_status + "!@" + RequestPara.active + "!@" + RequestPara.PartyId + "!@" + AppSessionState.client;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T002>(MCTemp, Request, "DeliverySchedule", "CRM", "", 0, "");

                BackFlipList = (from o in MCTemp.BackFlipEntity where o.doc_type == "SD" select o).ToList();
                DataGridCollectionBackFlip = CollectionViewSource.GetDefaultView(BackFlipList);
                DataGridCollectionBackFlip.Filter = new Predicate<object>(Filter_BackFlip);

                var msg = new NotificationMessage("SEL_T002_VM");
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
        private void InsertFltrSoldToParty(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M028_sch_P POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M028_sch_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_sch_P>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    RequestPara.PartyId = POPUPEntityObject.PartyId;
                    RequestPara.PartyId = POPUPEntityObject.PartyNm;
                }
            }
            catch (Exception Ex) { }
        }
        private void InsertReferenceDoc(object InputValue)
        {
            try
            {
                string Request = "";
                SEL_T002_P_RefDoc POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ScheduleReference.Where(x => x.Ref_DocNo.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SEL_T002_P_RefDoc>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T002_P_RefDoc>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ref_doc_no = POPUPEntityObject.Ref_DocNo;
                    MasterEntity.ref_doc_type = POPUPEntityObject.Ref_DocType;
                    MasterEntity.ref_doc_cat = POPUPEntityObject.doc_cat;
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
        private void InsertAddress(object InputValue)
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
                            { POPUPEntityObject = MCTemp.DeliveryAddress.Where(x => x.SrNo.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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
                    MasterEntity.del_address = POPUPEntityObject.SrNo;
                    MasterEntity.del_add = POPUPEntityObject.del_add;
                    MasterEntity.Location = POPUPEntityObject.Location;
                    if (ItemDataGridCollection.Count > 0)
                    {
                        foreach (var item in ItemDataGridCollection)
                        {
                            item.ship_to_add = POPUPEntityObject.SrNo.ToString();
                            item.ship_to_addNm = POPUPEntityObject.Location;

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
        private void InsertSchShipToParty(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "";
                string RequestParameterData = "";
                ADM_M028_sch_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true
                                                                  || x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M028_sch_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_sch_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (ItemDataGridCollection.Count > ItemDataGridSelectedIndex && ItemDataGridSelectedIndex != -1)
                    {
                        ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_party = POPUPEntityObject.PartyId;
                        ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_party_name = POPUPEntityObject.PartyNm;

                        RequestParameterData = "LoadPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_party;
                        MCTemp2 = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T002>(MCTemp2, RequestParameterData, "DeliverySchedule", "CRM", "", 0, "");

                        foreach (var item in MCTemp2.DeliveryAddress)
                        {
                            int IndexOfExistValue = MC.DeliveryAddress.IndexOf(MC.DeliveryAddress.Where(X => X.PartyId == POPUPEntityObject.PartyId).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.
                            if (IndexOfExistValue == -1)
                            {
                                MC.DeliveryAddress.Add(item);
                            }
                        }

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D_Add)x).Location);
                        TheFilter = (o, prefix) => (((ADM_M028_D_Add)o).Location ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_D_Add)o).SrNo.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                        ASSchShipToAdd = new AutoSuggestTextViewModel<dynamic>(MCTemp2.DeliveryAddress, TheFilter, SuggestedValue, "ship_to_addNm", "Location", true);
                        ASSchShipToAdd.AutoSuggestVM.IsEmptyValueAllowed = true;

                        if (MCTemp2.DeliveryAddress.Count == 0)
                        {
                            ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_add = "";
                            ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_addNm = "";

                        }
                        if (MCTemp2.DeliveryAddress.Count == 1)
                        {
                            ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_add = "";
                            ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_addNm = "";

                            ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_add = MCTemp2.DeliveryAddress[0].SrNo.ToString();
                            ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_addNm = MCTemp2.DeliveryAddress[0].Location;

                        }
                        else if (MCTemp2.DeliveryAddress.Count > 1)
                        {
                            ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_add = "";
                            ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_addNm = "";

                            var DeliveryAddress = (from o in MCTemp2.DeliveryAddress where o.AddType == "Delivery Address" select o).ToList();
                            if (DeliveryAddress.Count == 0)
                            {
                                ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_add = "";
                                ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_addNm = "";

                            }
                            else if (DeliveryAddress.Count == 1)
                            {
                                ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_add = "";
                                ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_addNm = "";

                                ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_add = DeliveryAddress[0].SrNo.ToString();
                                ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_addNm = DeliveryAddress[0].Location;

                            }
                            else if (DeliveryAddress.Count > 1)
                            {
                                ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_add = "";
                                ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_addNm = "";

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
        private void InsertSchShipToAddress(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "";
                ADM_M028_D_Add POPUPEntityObject = null;
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
                            { POPUPEntityObject = MCTemp2.DeliveryAddress.Where(x => x.SrNo.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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

                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    if (ItemDataGridCollection.Count > ItemDataGridSelectedIndex)
                    {
                        ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_add = POPUPEntityObject.SrNo.ToString();
                        ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_addNm = POPUPEntityObject.Location;
                        ItemDataGridCollection[ItemDataGridSelectedIndex].address_info = POPUPEntityObject.del_add;
                        MasterEntity.del_address = POPUPEntityObject.SrNo;
                        MasterEntity.del_add = POPUPEntityObject.del_add;
                        MasterEntity.Location = POPUPEntityObject.Location;
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

        private void FilterScheduleShipToAdd()
        {
            try
            {
                if (ItemDataGridCollection != null && ItemDataGridCollection.Count > ItemDataGridSelectedIndex && ItemDataGridSelectedIndex >= 0 && MCTemp2.DeliveryAddress != null)
                {

                    var tempAdd = (from o in MC.DeliveryAddress where o.PartyId == ItemDataGridCollection[ItemDataGridSelectedIndex].ship_to_party select o);
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D_Add)x).Location);
                    TheFilter = (o, prefix) => (((ADM_M028_D_Add)o).Location ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_D_Add)o).SrNo.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                    ASSchShipToAdd = new AutoSuggestTextViewModel<dynamic>(tempAdd, TheFilter, SuggestedValue, "ship_to_addNm", "Location", true);
                    ASSchShipToAdd.AutoSuggestVM.IsEmptyValueAllowed = true;

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
                MasterEntity.client = AppSessionState.client;
                MasterEntity.doc_cat = "SD";
                MasterEntity.doc_type = "SD";
                MasterEntity.ref_type = "Schedule";
                MasterEntity.location_Id = AppSessionState.location_Id;
                MasterEntity.comp_code = AppSessionState.comp_code;
                MasterEntity.add_by = AppSessionState.UserID;
                MasterEntity.editby = AppSessionState.UserID;
                MasterEntity.active = true;
                MasterEntity.t_status = "001";
                MasterEntity.t_display = "Draft";
                MasterEntity.sch_date = DateTime.Now;
                MasterEntity.ts_code = ts_code_vm;
                MasterEntity.user_source1 = AppSessionState.UserSource1;
                MasterEntity.user_source2 = AppSessionState.UserSource2;
                MasterEntity.userid = AppSessionState.UserID;
                DateTime d = DateTime.UtcNow;
                d = d.AddMonths(-1);
                RequestPara.FromDate = d;
                RequestPara.ToDate = DateTime.UtcNow;
                RequestPara.active = true;
                //SetPopupSuggestionDataAfterLoad();
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
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                MasterEntity.doc_cat = "SD";
                MasterEntity.doc_type = "SD";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code.ToString() + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T002>(MC, Request, "DeliverySchedule", "CRM", " ", 0, "");
                #region Command Initialization
                dgSelectionChanged = new RelayCommand<IList>(
                  items =>
                  {
                      if (items == null)
                      {
                          return;
                      }
                      GetSelectedChanged(items);
                  });
                ItemDataGridCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
                Commandparty = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items); });
                CommandSales = new RelayCommand<object>(items => { if (items == null) { return; } InsertSales(items); });
                CommandScheduleRecby = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmployee(items); });
                CommandSchby = new RelayCommand<object>(items => { if (items == null) { return; } InsertContactPerson(items); });
                CommandAddItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items, true, true, true); });
                CommandSalesNo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSalesNo(cmdPara, false, true, true); });
                CommandUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOM(cmdPara, false, true, true); });
                CommandLoadDocumentByByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara); });
                CommandReqNo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertReqNo(cmdPara, false, true, true); });
                cmdInsertTransferOrder = new RelayCommand(() => { Insert_TransferOrder(); });
                cmdCloseStatus = new RelayCommand(() => { CloseStatus(); });

                CmdInsertReferenceDoc = new RelayCommand<object>(items => { if (items == null) { return; } InsertReferenceDoc(items); });
                cmdLoadRefdocumentNo = new RelayCommand(() => { LoadReferenceDocNo(); });
                cmdLoadAddress = new RelayCommand<object>(items => { if (items == null) { return; } InsertAddress(items); });
                CmdDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });

                cmdMail = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } MailDocuments(cmdPara); });
                cmdPrint = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } PrintDocuments(cmdPara); });
                cmdSchShipToParty = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSchShipToParty(cmdPara, false, true, true); });
                cmdSchShipToAdd = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSchShipToAddress(cmdPara, false, true, true); });
                CmdAddSelectedRef = new RelayCommand<object>(items => { if (items == null) { return; } AddSelectedRef(items); });
                CommandFltrLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrLocation(items); });
                CommandFltrStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrStatus(items); });
                CommandFltrSoldToParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrSoldToParty(items); });
                CommandLoadHistory = new RelayCommand<object>(items => { if (items == null) { return; } LoadHistory(); });
                #endregion
                #region Autosuggest

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_sch_P)x).PartyNm);
                TheFilter = (o, prefix) => (((ADM_M028_sch_P)o).PartyId ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower()) || (((ADM_M028_sch_P)o).PartyNm ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower());
                AutoSuggestTextViewModel = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyNm", true);
                AutoSuggestTextViewModel.AutoSuggestVM.IsEmptyValueAllowed = true;
                AutoSuggestTextViewModel.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_sch_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_sch_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_sch_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSoldToParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyId", true);
                ASSoldToParty.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASSoldToParty.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T002_Req_P)x).sch_no);
                TheFilter = (o, prefix) => (((SEL_T002_Req_P)o).sch_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASReqNo = new AutoSuggestTextViewModel<dynamic>(MC.Req_Details, TheFilter, SuggestedValue, "ref_no", true);
                ASReqNo.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASReqNo.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSchRecBy = new AutoSuggestTextViewModel<dynamic>(MC.EmployeeEntity, TheFilter, SuggestedValue, "EmpId", true);
                ASSchRecBy.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASSchRecBy.AutoSuggestVM.IsFreeTextAllowed = true;

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

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_sch_P)x).PartyNm);
                TheFilter = (o, prefix) => (((ADM_M028_sch_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_sch_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASSchShipToParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "ship_to_PartyNm", "PartyNm", true);
                ASSchShipToParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                //Filters AutoSuggest
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASFltrt_status = new AutoSuggestTextViewModel<dynamic>(MC.t_statusList, TheFilter, SuggestedValue, "fltr_t_display", true);
                ASFltrt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_sch_P)x).PartyNm);
                TheFilter = (o, prefix) => ((ADM_M028_sch_P)o).PartyNm.ToString().ToLower().Contains(prefix.ToLower()) || ((ADM_M028_sch_P)o).PartyId.ToString().ToLower().Contains(prefix.ToLower());
                ASFltrSoldToParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "fltr_SoldToPartyNM", true);
                ASFltrSoldToParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                LocationList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var LocList = (from o in LocationList where o.location_Id == AppSessionState.location_Id select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => ((ADM_M003)o).location_Id.ToString().ToLower().Contains(prefix.ToLower());
                ASFltrLocation = new AutoSuggestTextViewModel<dynamic>(LocList, TheFilter, SuggestedValue, "fltr_location_Id", true);
                ASFltrLocation.AutoSuggestVM.IsEmptyValueAllowed = true;


                #endregion
                UnitConversionList = MC.UnitConversion;

                refdoctempa = (from o in MC.ScheduleReference where o.doc_cat == "SO" select o).ToList();
                ReferenceDocCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                NotificationDataCollection = MC.NotificationData;
                DefaultValues();

                var msg = new NotificationMessage("SEL_T002_VM");
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

                foreach (var o in ItemDataGridCollection)
                {

                    if (o.ItemCode != null && o.ItemCode != "" && o.ItemName != null)
                    {
                        int flag = 0;
                        if (o.id == 0)
                        {

                            foreach (var p in ItemDataGridCollection)
                            {
                                if (o.ItemCode == p.ItemCode && o.sku == p.sku && o.line_id == p.line_id)
                                {
                                    flag++;
                                }
                            }
                            if (flag > 1)
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                                showMessageService.ShowMessage();
                                return false;
                            }

                        }

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
        private void GetSelectedChanged(IList items)
        {
            try
            {

                if (MC.so_schedule != null && MC.so_schedule.Count > 0) { MC.so_schedule = MC.so_schedule; }
                else if (MCTemp.so_schedule != null && MCTemp.so_schedule.Count > 0) { MC.so_schedule = MCTemp.so_schedule; }
                else if (MCTemp2.so_schedule != null && MCTemp2.so_schedule.Count > 0) { MC.so_schedule = MCTemp2.so_schedule; }

                if (MC.Req_Details != null && MC.Req_Details.Count > 0) { MC.Req_Details = MC.Req_Details; }
                else if (MCTemp.Req_Details != null && MCTemp.Req_Details.Count > 0) { MC.Req_Details = MCTemp.Req_Details; }
                else if (MCTemp2.Req_Details != null && MCTemp2.Req_Details.Count > 0) { MC.Req_Details = MCTemp2.Req_Details; }

                if (items.Count > 0 && ItemDataGridSelectedIndex != -1 && ItemDataGridCollection.Count > ItemDataGridSelectedIndex)
                {
                    if (MC.so_schedule.Count() > 0)
                    {

                        var SoSchedule = (from data in MC.so_schedule where data.ItemCode == ItemDataGridCollection[ItemDataGridSelectedIndex].ItemCode select data);
                        SoScheduleCollectiontemp = new ObservableCollection<SEL_T001_schedule_P>(SoSchedule);

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_schedule_P)x).sono);
                        TheFilter = (o, prefix) => (((SEL_T001_schedule_P)o).sono ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SEL_T001_schedule_P)o).cust_ref ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASSalesNo = new AutoSuggestTextViewModel<dynamic>(SoSchedule, TheFilter, SuggestedValue, "sono", "sono", true);
                        ASSalesNo.AutoSuggestVM.IsEmptyValueAllowed = true;
                        ASSalesNo.AutoSuggestVM.IsFreeTextAllowed = false;
                    }
                    else
                    {
                        SoScheduleCollectiontemp = new ObservableCollection<SEL_T001_schedule_P>();

                    }
                    if (MC.Req_Details.Count() > 0)
                    {
                        var ReqDetails = (from data in MC.Req_Details where data.ItemCode == ItemDataGridCollection[ItemDataGridSelectedIndex].ItemCode select data);
                        ReqDetailscollectiontemp = new ObservableCollection<SEL_T002_Req_P>(ReqDetails);

                        
                    }
                    var ReqNoGrid = (from data in MC.Req_Details where data.ItemCode == ItemDataGridCollection[ItemDataGridSelectedIndex].ItemCode select data);
                    RequirementCollection1 = CollectionViewSource.GetDefaultView(ReqNoGrid);
                    RequirementCollection1.Filter = new Predicate<object>(Filter_RequirementNo1);

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T002_Req_P)x).sch_no);
                    TheFilter = (o, prefix) => (((SEL_T002_Req_P)o).sch_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASdgRefNo = new AutoSuggestTextViewModel<dynamic>(ReqNoGrid, TheFilter, SuggestedValue, "ref_no", "sch_no", true);
                    ASdgRefNo.AutoSuggestVM.IsEmptyValueAllowed = true;


                }
                else
                {

                    SoScheduleCollectiontemp = new ObservableCollection<SEL_T001_schedule_P>();
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
                            //if (ItemDataGridCollection[dgSelectedIndexItem].id > 0)
                            //{
                            //    item.so_item_id = ItemsEntity[dgSelectedIndexItem].id;
                            //}
                            //else
                            //{
                            //    item.so_item_id = 0;
                            //}
                            item.active = true;
                            item.t_status = MasterEntity.t_status;
                            item.t_display = MasterEntity.t_display;
                            item.editby = AppSessionState.UserID;
                            item.add_by = AppSessionState.UserID;
                            item.location_Id = AppSessionState.location_Id;
                            item.comp_code = MasterEntity.comp_code;

                            item.ship_to_party = MasterEntity.PartyId;
                            item.ship_to_party_name = MasterEntity.PartyNm;
                            item.ship_to_add = MasterEntity.del_address.ToString();
                            item.ship_to_addNm = MasterEntity.Location;
                            item.line_id = 1;
                            if (ItemDataGridCollection.Count > 0)
                            {
                                if (ItemDataGridCollection[0].PartyNm != null)
                                {
                                    item.PartyNm = ItemDataGridCollection[0].PartyNm;
                                    item.ship_mode = ItemDataGridCollection[0].ship_mode;
                                    item.PartyId = MasterEntity.PartyId;
                                }
                                item.para1 = ItemDataGridCollection[0].para1;
                                item.line_id = ItemDataGridCollection.Count;
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
                        new KeyValuePair<string, string>("[EMP]",MasterEntity.employee_name),
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
                    Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, VarData.to_mail_id, VarData.cc_mail_id, VarData.bcc_mail_id, VarData.subject, VarData.msg_body, null);

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
        #region Transfer Order
        // Used For Transfer Order
        #region Variable Declaration
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

        private SEL_T004 _MasterEntity_TempSEL_T004;
        public SEL_T004 MasterEntity_TempSEL_T004
        {
            get
            {
                return _MasterEntity_TempSEL_T004;
            }
            set
            {
                if (_MasterEntity_TempSEL_T004 != value)
                {
                    _MasterEntity_TempSEL_T004 = value;
                    RaisePropertyChanged("MasterEntity_TempSEL_T004");
                }
            }
        }

        private bool _post;
        public bool post
        {
            get { return _post; }
            set
            {
                if (_post != value)
                {
                    _post = value;
                    RaisePropertyChanged("post");
                }
            }
        }
        #endregion
        #region User Defined functions
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
                            post = false;

                            MasterEntity.t_status = "InProcess";

                            MasterEntity.XmlDataDocument_SEL_T002_A = obj.ObjectToXML(ItemDataGridCollection);
                            MasterEntity = repository.UpdateWithReturnDomainObject<SEL_T002>(MasterEntity, "DeliverySchedule", "CRM");

                            // Getting Inserted and Updated Record of ITEM Details SEL_T002_A
                            if (MasterEntity.XmlDataDocument_SEL_T002_A != null)
                            {
                                MCTemp.ItemsEntity = (ObservableCollection<SEL_T002_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_SEL_T002_A, MC.ItemsEntity);
                            }
                            else
                            {
                                MCTemp.ItemsEntity = new ObservableCollection<SEL_T002_A>();
                            }
                            ItemDataGridCollection = MCTemp.ItemsEntity;

                        }
                        else
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Transfer Order Generate Unsuccessful", this.Title);
                            showMessageService.ShowMessage();
                            post = true;
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
        private void CloseStatus()
        {
            try
            {
                MasterEntity.t_status = "003";
                MasterEntity.t_display = "Closed";
                foreach (var Item in ItemDataGridCollection)
                {
                    Item.t_status = "003";
                    Item.t_display = "Closed";
                }

                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Status Closed Successfully...");
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
        #endregion

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
                            MasterEntity.add_by = AppSessionState.UserID;
                            MasterEntity.editby = AppSessionState.UserID;
                            MasterEntity.doc_cat = "SD";
                            MasterEntity.doc_type = "SD";
                            MasterEntity.location_Id = AppSessionState.location_Id;
                            MasterEntity.comp_code = AppSessionState.comp_code;
                            MasterEntity.ts_code = ts_code_vm;
                            ObjectSerializationService objSer = new ObjectSerializationService();
                            MasterEntity.XmlDataDocument_SEL_T002_A = objSer.ObjectToXML(ItemDataGridCollection);

                            if (blNew == true)
                            {
                                MasterEntity = repository.SaveWithReturnDomainObject<SEL_T002>(MasterEntity, "DeliverySchedule", "CRM");
                                MasterList.Add(MasterEntity);
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
                                    MCTemp.BackFlipEntity = (List<SEL_T002_BackFlip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.BackFlipEntity);
                                    //BackFlipList.Insert(0,MCTemp.BackFlipEntity[0]);
                                    //DataGridCollectionBackFlip.Refresh();
                                    //DataGridCollectionBackFlip.SortDescriptions.Add(new SortDescription("sch_no", ListSortDirection.Descending));
                                }

                                blNew = false;
                            }
                            else if (blNew == false)
                            {
                                MasterEntity = repository.UpdateWithReturnDomainObject<SEL_T002>(MasterEntity, "DeliverySchedule", "CRM");
                                //DataGridCollectionBackFlip.Refresh();

                                if (MasterEntity.XmlDataDocument_FlipGrid != null && blNew == false)
                                {
                                    MCTemp.BackFlipEntity = (List<SEL_T002_BackFlip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.BackFlipEntity);
                                    //BackFlipList.Insert(0, MCTemp.BackFlipEntity[0]);
                                    //DataGridCollectionBackFlip.Refresh();
                                }

                            }


                            // Getting Inserted and Updated Record of ITEM Details LOG_T001_B
                            if (MasterEntity.XmlDataDocument_SEL_T002_A != null)
                            {
                                MC.ItemsEntity = (ObservableCollection<SEL_T002_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_SEL_T002_A, MC.ItemsEntity);
                            }
                            else
                            {
                                MC.ItemsEntity = new ObservableCollection<SEL_T002_A>();
                            }
                            ItemDataGridCollection = MC.ItemsEntity;

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
                var msg = new NotificationMessage("SEL_T002_VM");
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
        private void RemoveRefDoc()
        {
            try
            {
                if (MasterEntity.ref_doc_no != null)
                {
                    List<string> DocList = DocumentList.Split(',').ToList();
                    foreach (var item in DocList)
                    {
                        MC.ScheduleReference.RemoveAll(X => X.Ref_DocNo == item);
                    }

                    refdoctempa = (from o in MC.ScheduleReference where o.doc_cat == "SO" select o).ToList();
                    ReferenceDocCollection = CollectionViewSource.GetDefaultView(refdoctempa);
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
        protected override void OnCreateAction(InquiryActionResult<SEL_T002> result)
        {
            try
            {
                blNew = true;
                DocumentList = "";
                foreach (var item in MC.ScheduleReference)
                {
                    if (item.Select == true)
                    {
                        item.Select = false;
                    }
                }
                refdoctempa = (from o in MC.ScheduleReference where o.doc_cat == "SO" select o).ToList();
                ReferenceDocCollection = CollectionViewSource.GetDefaultView(refdoctempa);

                //MC = new MultipleContext_SEL_T002();
                ItemDataGridCollection = new ObservableCollection<SEL_T002_A>();
                SoScheduleCollectiontemp = new ObservableCollection<SEL_T001_schedule_P>();
                ReqDetailscollectiontemp = new ObservableCollection<SEL_T002_Req_P>();
                MasterList = new List<SEL_T002>();
                MasterEntity = new SEL_T002();
                DefaultValues();
                var msg = new NotificationMessage("SEL_T002_VM");
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
                    showMessageService.Text =
                        String.Format(
                            "This record will be Deleted forever '{0}'",
                                this.Title);
                    if (showMessageService.ShowMessage() == DialogResult.Ok)
                    {
                        this.MasterEntity.EndEdit();
                        string response = repository.Delete(MasterEntity.sch_no, "DeliverySchedule", "CRM");



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
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<SEL_T002> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<SEL_T002> result)
        {
        }
        protected override void OnHelpAction(InquiryActionResult<SEL_T002> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<SEL_T002> result)
        {
            //try
            //{

            //    string Request = "Delivery_Schedule" + "!@" + MasterEntity.sch_no;
            //    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T002>(MCTemp, Request, "DeliverySchedule", "CRM", "", 0, "");


            //    object[] objDataSource = new object[3];
            //    string[] objDataSourceName = new string[3];

            //    objDataSource[0] = MCTemp.RptDelivery_Schedule;

            //    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
            //    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
            //    objDataSource[1] = CmpResult;

            //    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
            //    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
            //    objDataSource[2] = Result;

            //    objDataSourceName[0] = "dsDelivery_Schedule";
            //    objDataSourceName[1] = "dsCompany";
            //    objDataSourceName[2] = "dsLocation";

            //    ReportManager ReportManager = new ReportManager();
            //    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\DeliverySchedule.rdlc", getParametersList(), "");

            //}
            //catch (Exception ex) {
            //}


        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<SEL_T002> result)
        {
            LoadInitialData();
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
        private string _filterString_ReqNo1;
        public string FilterString_ReqNo1
        {
            get { return _filterString_ReqNo1; }
            set
            {
                _filterString_ReqNo1 = value;
                RaisePropertyChanged("FilterString_ReqNo1");
                FilterCollection_RequirementNo1();
            }
        }
        private void FilterCollection_RequirementNo1()
        {
            if (_RequirementCollection1 != null)
            {
                _RequirementCollection1.Refresh();
            }
        }
        public bool Filter_RequirementNo1(object obj)
        {
            var data = obj as SEL_T002_Req_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ReqNo1))
                {
                    return (data.sch_no != null && data.sch_no.ToString().ToLower().Contains(_filterString_ReqNo1.ToLower()) ||
                        (data.sch_date != null && data.sch_date.ToString().ToLower().Contains(_filterString_ReqNo1.ToLower())));


                }
                return true;
            }
            return false;

        }

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

        //Filter Item
        private string _filterString_Item;
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
                if (!string.IsNullOrEmpty(_filterString_Item))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_Item.ToLower())) ||
                        (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_Item.ToLower())) ||
                        (data.CustItemCode != null && data.CustItemCode.ToString().ToLower().Contains(_filterString_Item.ToLower())) ||
                        (data.CustItemName != null && data.CustItemName.ToString().ToLower().Contains(_filterString_Item.ToLower()));

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
            var data = obj as SEL_T002_P_RefDoc;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_ReferenceDoc))
                {
                    return (data.Ref_DocNo != null && data.Ref_DocNo.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.Ref_date != null && data.Ref_date.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.Ref_DocType != null && data.Ref_DocType.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower())

                       );
                }
                return true;
            }
            return false;
        }

        
        #endregion

    }

}
