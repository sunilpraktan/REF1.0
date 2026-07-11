using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Data;
using Reflection.ReportingServices;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Services.Convertors;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class SEL_T004_VM: WorkspaceViewModel<SEL_T004>
    {
        #region Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        bool isNewRecord = true;
        //public string ref_doc_cat { get; set; }
        WebServiceRepository<SEL_T004> repository = new WebServiceRepository<SEL_T004>();
        WebServiceRepository<MultipleContext_SEL_T004> repository_MC = new WebServiceRepository<MultipleContext_SEL_T004>();
        WebServiceRepository<MultipleContext_SEL_T004> repository_MCTemp = new WebServiceRepository<MultipleContext_SEL_T004>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SEL_T004_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _ASDeliveryAdddress { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDeliveryAdddress
        {
            get { return _ASDeliveryAdddress; }
            set
            {
                if (_ASDeliveryAdddress != value)
                {
                    _ASDeliveryAdddress = value; RaisePropertyChanged("ASDeliveryAdddress");
                }
            }
        }

        #endregion

        private MultipleContext_SEL_T004 _MC = new MultipleContext_SEL_T004();
        public MultipleContext_SEL_T004 MC
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
        private MultipleContext_SEL_T004 _MCTemp = new MultipleContext_SEL_T004();
        public MultipleContext_SEL_T004 MCTemp
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
        private string _ts_code;
        public string ts_code
        {
            get
            {
                return _ts_code;
            }
            set
            {
                if (_ts_code != value)
                {
                    _ts_code = value;
                }
            }
        }
        private string _party_id;
        public string party_id
        {
            get
            {
                return _party_id;
            }
            set
            {
                if (_party_id != value)
                {
                    _party_id = value;
                    RaisePropertyChanged(nameof(party_id));
                }
            }
        }
        private SEL_T004 _MasterEntity;
        public SEL_T004 MasterEntity
        {
            get { return _MasterEntity; }
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
        private ObservableCollection<SEL_T004_A> _ItemEntity;
        public ObservableCollection<SEL_T004_A> ItemEntity
        {
            get { return _ItemEntity; }
            set
            {
                if (_ItemEntity != value)
                {
                    _ItemEntity = value; RaisePropertyChanged("ItemEntity");
                   
                }
            }

        }
        private List<SEL_T004Flip> _FlipGridData;
        public List<SEL_T004Flip> FlipGridData
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
                var msg = new NotificationMessage("SEL_T004_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
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
        
        public List<SEL_T003_P_RefDoc> _Dispatch_Order_Reference;
        public List<SEL_T003_P_RefDoc> Dispatch_Order_Reference
        {
            get
            {
                return _Dispatch_Order_Reference;
            }
            set
            {
                _Dispatch_Order_Reference = value;
                RaisePropertyChanged("Dispatch_Order_Reference");
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
        
        private ICollectionView _locationCollection;
        public ICollectionView locationCollection
        {
            get { return _locationCollection; }
            set
            {
                _locationCollection = value;
                RaisePropertyChanged("locationCollection");
            }
        }
        private ICollectionView _ReferenceDocCollection;
        public ICollectionView ReferenceDocCollection
        {
            get { return _ReferenceDocCollection; }
            set { _ReferenceDocCollection = value; RaisePropertyChanged("ReferenceDocCollection"); }
        }

        private ICollectionView _ReferenceDocSOCollection;// deletion
        public ICollectionView ReferenceDocSOCollection
        {
            get { return _ReferenceDocSOCollection; }
            set { _ReferenceDocSOCollection = value; RaisePropertyChanged("ReferenceDocSOCollection"); }
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

        #region StringList Variables

        private List<string> _strListReferenceDoc;
        public List<string> StringListReferenceDoc
        {
            get { return _strListReferenceDoc; }
            set
            {
                if (_strListReferenceDoc != value)
                {
                    _strListReferenceDoc = value;
                }
            }
        }
        
        private List<string> _strListReferanceDocNo;
        public List<string> StringListReferanceDocNo
        {
            get { return _strListReferanceDocNo; }
            set
            {
                if (_strListReferanceDocNo != value)
                {
                    _strListReferanceDocNo = value;
                }
            }
        }
        List<string> _stringListPlant;
        public List<string> stringListPlant
        {
            get { return _stringListPlant; }
            set
            {
                if (_stringListPlant != value)
                {
                    _stringListPlant = value;
                }
            }
        }
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

        private AutoSuggestTextViewModel<dynamic> _ASTransporter { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTransporter
        {
            get { return _ASTransporter; }
            set
            {
                if (_ASTransporter != value)
                {
                    _ASTransporter = value; RaisePropertyChanged("ASTransporter");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASShippingMode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASShippingMode
        {
            get { return _ASShippingMode; }
            set
            {
                if (_ASShippingMode != value)
                {
                    _ASShippingMode = value; RaisePropertyChanged("ASShippingMode");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASPlant { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPlant
        {
            get { return _ASPlant; }
            set
            {
                if (_ASPlant != value)
                {
                    _ASPlant = value; RaisePropertyChanged("ASPlant");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDocType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocType
        {
            get { return _ASDocType; }
            set
            {
                if (_ASDocType != value)
                {
                    _ASDocType = value; RaisePropertyChanged("ASDocType");
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
       
        public List<ADM_M003> _PlantList;
        public List<ADM_M003> PlantList
        {
            get
            {
                return _PlantList;
            }
            set
            {
                _PlantList = value;
                RaisePropertyChanged("PlantList");
            }
        }



        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByReferenceDocumentNumber { get; private set; }
        public RelayCommand<object> CmdAddSelectedRef { get; private set; }
        public RelayCommand<object> CmdInsert_t_status { get; private set; }
        public RelayCommand<object> CommandTransporter { get; private set; }
        public RelayCommand<object> CommandPlant{ get; private set; }
        public RelayCommand<object> CommandStatus { get; private set; }
        public RelayCommand<object> CommandLoadHistory { get; private set; }
        public RelayCommand<object> CommandShippingMode { get; private set; }
        public RelayCommand<object> CommandShipToAddress { get; private set; }
        #endregion

        #region UserDefine Function
        private void DefaultValues(string ts_code)
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_cat = "DO";
            MasterEntity.doc_type = "DO";
            MasterEntity.client = AppSessionState.client;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.t_status = "001";
            MasterEntity.t_display = "Draft";
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.plan_ex_date = DateTime.Now;
            MasterEntity.client_del_receive_date = DateTime.Now;
            MasterEntity.dispatch_date = DateTime.Now;
            MasterEntity.ts_code = ts_code;
            this.ts_code = ts_code;
        }
        #endregion
       
        #region Constructor
        public SEL_T004_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MC = new MultipleContext_SEL_T004();
            MasterEntity = new SEL_T004();
            ItemEntity = new ObservableCollection<SEL_T004_A>();
            FlipGridData = new List<SEL_T004Flip>();
            NotificationDataCollection = new List<NotificationData>();
            LoadInitialData();
            DefaultValues(AppSessionState.TransactionCode);
            this.ts_code = AppSessionState.TransactionCode;
        }
        public SEL_T004_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MC = new MultipleContext_SEL_T004();
            MasterEntity = new SEL_T004();
            ItemEntity = new ObservableCollection<SEL_T004_A>();
            FlipGridData = new List<SEL_T004Flip>();
            NotificationDataCollection = new List<NotificationData>();
            LoadInitialData();
            DefaultValues(AppSessionState.TransactionCode);
            this.ts_code = AppSessionState.TransactionCode;
        }
        public SEL_T004_VM(string doc_no, string ts_code,string ts_name_display) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MC = new MultipleContext_SEL_T004();
            MasterEntity = new SEL_T004();
            ItemEntity = new ObservableCollection<SEL_T004_A>();
            FlipGridData = new List<SEL_T004Flip>();
            NotificationDataCollection = new List<NotificationData>();
            LoadInitialData();
            //review
            if (doc_no != null && doc_no !="")
            {
                LoadDocumentByDocumentNumber(doc_no, "DocumentNo");
                isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                AppSessionState.TransValue = null;
                AppSessionState.TransParameter = null;
                AppSessionState.ViewOtherRecordAllowed = true;
            }

        }
        private void LoadInitialData()
        {
            try
            {
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CommandDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
                CommandLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CommandLoadDocumentByReferenceDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByReferenceDocumentNumber(cmdPara, "NewReferenceDocument"); });
                CmdAddSelectedRef = new RelayCommand<object>(items => { if (items == null) { return; } AddSelectedRef(items); });
                CommandTransporter = new RelayCommand<object>(items => { if (items == null) { return; } InsertTransporter(items, false); });
                CommandPlant = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPlant(cmdPara, false, false, true); });
                CommandStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertStatus(items); });
                CommandLoadHistory = new RelayCommand<object>(items => { if (items == null) { return; } LoadHistory(); });
                CommandShippingMode = new RelayCommand<object>(items => { if (items == null) { return; } InsertShippingMode(items); });
                CommandShipToAddress = new RelayCommand<object>(items => { if (items == null) { return; } InsertShipToAddress(items, true); });

                MasterEntity.doc_cat = "DO";
                MasterEntity.doc_type = "DO";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.client; ;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T004>(MC, Request, "TransferOrder", "CRM", "LoadAll", 0, Request);

                locationCollection = CollectionViewSource.GetDefaultView((List<ADM_M003>)AppSessionState.ADM_M003_List);
                locationCollection.Filter = new Predicate<object>(FilterLocation);
                stringListPlant = ((List<ADM_M003>)AppSessionState.ADM_M003_List).Select(x => x.location_Id).ToList();

                NotificationDataCollection = MC.NotificationData;

                ReferenceDocSOCollection = CollectionViewSource.GetDefaultView(MC.Dispatch_Order_Reference);
                ReferenceDocSOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
               
                #region Autosuggest

                SuggestedValue = new ValueConverter(x => x == null ? "Draft" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASt_status = new AutoSuggestTextViewModel<dynamic>(MC.t_statusList, TheFilter, SuggestedValue, "t_display", true);
                ASt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).transporter_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASTransporter = new AutoSuggestTextViewModel<dynamic>(MC.Transporters, TheFilter, SuggestedValue, "tr_party", true);
                ASTransporter.AutoSuggestVM.IsEmptyValueAllowed = true;

                PlantList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPlant = new AutoSuggestTextViewModel<dynamic>(PlantList, TheFilter, SuggestedValue, "location_Id", "location_Id", true);
                ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M002_P)x).doc_type);
                TheFilter = (o, prefix) => (((SYS_M002_P)o).doc_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M002_P)o).doc_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDocType = new AutoSuggestTextViewModel<dynamic>(MC.doc_typeList, TheFilter, SuggestedValue, "doc_type", "doc_type", true);
                ASDocType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M026)x).tr_mode);
                TheFilter = (o, prefix) => (((SYS_M026)o).tr_mode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M026)o).tr_mode ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASShippingMode = new AutoSuggestTextViewModel<dynamic>(MC.ShippingTypes, TheFilter, SuggestedValue, "tr_mode", true);
                ASShippingMode.AutoSuggestVM.IsEmptyValueAllowed = true;
                
                #endregion

                DefaultValues(AppSessionState.TransactionCode);
                var msg = new NotificationMessage("SEL_T004_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
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

        #region Relay Command Implementation
        private void AddSelectedRef(object InputValue)
        {
            try
            {
                SEL_T003_P_RefDoc POPUPEntityObject = null;
                string Request;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Dispatch_Order_Reference.Where(x => x.Ref_DocNo.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<SEL_T003_P_RefDoc>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T003_P_RefDoc>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    if (POPUPEntityObject.t_status != "009")
                    {
                        MasterEntity.ref_doc_no = POPUPEntityObject.Ref_DocNo;
                        MasterEntity.ref_doc_cat = POPUPEntityObject.doc_cat;
                        MasterEntity.ref_doc_type = POPUPEntityObject.Ref_DocType;
                        DocumentList = "";
                        List<SEL_T003_P_RefDoc> refdoctempa = null;
                        if (MasterEntity.ref_doc_cat == "SO")
                        {
                            refdoctempa = (from o in MC.Dispatch_Order_Reference where o.doc_cat == "SO" select o).ToList();
                            ReferenceDocSOCollection = CollectionViewSource.GetDefaultView(refdoctempa);
                            ReferenceDocSOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                        }
                        var refdoc = from o in refdoctempa
                                     where o.PartyId == POPUPEntityObject.PartyId
                                            && o.PartyNm == POPUPEntityObject.PartyNm
                                            && o.so_code == POPUPEntityObject.so_code
                                            && o.curr_code == POPUPEntityObject.curr_code
                                            && o.bill_address_id == POPUPEntityObject.bill_address_id
                                            && o.doc_cat == POPUPEntityObject.doc_cat
                                            && o.p_term_code == POPUPEntityObject.p_term_code
                                            && o.incoterms == POPUPEntityObject.incoterms
                                            && o.country_code == POPUPEntityObject.country_code
                                            && o.ref_cat == POPUPEntityObject.ref_cat
                                            && o.ship_to_add == POPUPEntityObject.ship_to_add
                                            && o.doc_type == POPUPEntityObject.doc_type
                                            && Convert.ToDateTime(o.goods_issue_date).ToString("MM/dd/yyyy") == Convert.ToDateTime(POPUPEntityObject.goods_issue_date).ToString("MM/dd/yyyy")
                                     select o;
                        foreach (var item in refdoc)
                        {
                            if (item.Select == true)
                            {
                                party_id = item.PartyId;
                                DocumentList = DocumentList + "," + item.id.ToString();
                            }
                        }
                        DocumentList = DocumentList.ToString().TrimStart(new char[] { ',' });
                        if (POPUPEntityObject.Select == true)
                        {
                            ReferenceDocSOCollection = CollectionViewSource.GetDefaultView(refdoc);
                            ReferenceDocSOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
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
        private void LoadDocumentByReferenceDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                string ParametersStringValue = "";
                SEL_T004Flip ParameterEntityObject = null;
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    ParametersStringValue = ParameterObject.ToString().Trim();
                    if (ParametersStringValue.Length > 0)
                    {
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
                            Request = "LoadDocumentWithReferenceDocumentNumber" + "!@" + DocumentList + "!@" + party_id + "!@" + party_id;
                            MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T004>(MCTemp, Request, "TransferOrder", "CRM", "", 0, Request);
                            if (MCTemp.ItemsEntity.Count > 0)
                            {
                                MasterEntity = MCTemp.MasterEntity[0];
                                ItemEntity = MCTemp.ItemsEntity;
                                MasterEntity.ts_code = this.ts_code;
                            }
                            DefaultValues(AppSessionState.TransactionCode);
                        }

                    }
                }
                else if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<SEL_T004Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<SEL_T004Flip>().ToList()[0];
                        Request = "LoadDocumentFromBackFlip" + "!@" + ParameterEntityObject.doc_no + "!@" + ParameterEntityObject.ref_doc_cat + "!@" + party_id;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T004>(MCTemp, Request, "TransferOrder", "CRM", "", 0, Request);
                        MasterEntity = MCTemp.MasterEntity[0];

                        ItemEntity = MCTemp.ItemsEntity;
                        AttachmentCollection = MC.Attachment;
                        SelectedTabControlIndex = 0;
                        isNewRecord = false;
                        // SetBusinessEntitiesAfterLoad(ParametersStringValue, "");
                    }
                }

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).SrNo.ToString());
                TheFilter = (o, prefix) => (((ADM_M028_D)o).SrNo.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_D)o).SrNo.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                ASDeliveryAdddress = new AutoSuggestTextViewModel<dynamic>(MCTemp.PartysShipToAddresses, TheFilter, SuggestedValue, "del_address", true);
                ASDeliveryAdddress.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDeliveryAdddress.AutoSuggestVM.IsFreeTextAllowed = true;
                MasterEntity.ts_code = ts_code_vm;

                var msg = new NotificationMessage("SEL_T004_VM");
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
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                string ParametersStringValue = "";
                SEL_T004Flip ParameterEntityObject = null;
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    ParametersStringValue = ParameterObject.ToString().Trim();
                    if (ParametersStringValue.Length > 0)
                    {
                        
                        Request = "LoadDocumentFromBackFlip" + "!@" + ParametersStringValue + "!@" + party_id + "!@" + party_id;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T004>(MCTemp, Request, "TransferOrder", "CRM", "", 0, Request);
                        MasterEntity = MCTemp.MasterEntity[0];
                        MasterEntity.ts_code = this.ts_code;
                        ItemEntity = MCTemp.ItemsEntity;
                        AttachmentCollection = MC.Attachment;
                        SelectedTabControlIndex = 0;
                        isNewRecord = false;
                    }
                }
                else if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<SEL_T004Flip>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<SEL_T004Flip>().ToList()[0];
                        Request = "LoadDocumentFromBackFlip" + "!@" + ParameterEntityObject.doc_no + "!@" + ParameterEntityObject.ref_doc_cat + "!@" + ParameterEntityObject.ship_to_party;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_SEL_T004>(MCTemp, Request, "TransferOrder", "CRM", "", 0, Request);
                        MasterEntity = MCTemp.MasterEntity[0];
                        MasterEntity.ts_code = this.ts_code;
                        ItemEntity = MCTemp.ItemsEntity;
                        AttachmentCollection = MC.Attachment;
                        SelectedTabControlIndex = 0;
                        isNewRecord = false;
                        // SetBusinessEntitiesAfterLoad(ParametersStringValue, "");
                    }
                }

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_D)x).SrNo.ToString());
                TheFilter = (o, prefix) => (((ADM_M028_D)o).SrNo.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_D)o).SrNo.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                ASDeliveryAdddress = new AutoSuggestTextViewModel<dynamic>(MCTemp.PartysShipToAddresses, TheFilter, SuggestedValue, "del_address", true);
                ASDeliveryAdddress.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDeliveryAdddress.AutoSuggestVM.IsFreeTextAllowed = true;

                var msg = new NotificationMessage("SEL_T004_VM");
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
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.XmlDataDocument_SEL_T004_A != null)
                {
                    MC.ItemsEntity = (ObservableCollection<SEL_T004_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_SEL_T004_A, MC.ItemsEntity);
                    ItemEntity = MC.ItemsEntity;

                }
                else
                {
                    MC.ItemsEntity = new ObservableCollection<SEL_T004_A>();
                    ItemEntity.Clear();
                }

                if (MasterEntity.XmlDataDocument_FlipGrid != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<SEL_T004Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                    FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                    FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);
                    FlipDataGridCollection.Refresh();
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
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemEntity.Count > i)
                {
                    ItemEntity.RemoveAt(i);
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
                        new KeyValuePair<string, string>("[EMP]", MasterEntity.add_by),
                        new KeyValuePair<string, string>("[DOC]",MC.doc_typeList[0].doc_desc_user),
                        new KeyValuePair<string, string>("[DOCNO]", MasterEntity.doc_no),
                        new KeyValuePair<string, string>("[DOCDATE]", MasterEntity.doc_date.ToString()),
                        new KeyValuePair<string, string>("[CUST]",MasterEntity.PartyNm),
                        new KeyValuePair<string, string>("[Attn]",VarData.EmpName),
                        new KeyValuePair<string, string>("[Comp]",AppSessionState.CompanyName),
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
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }
        }
        string DocumentList = "";
        
        private void InsertStatus(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0013 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.t_statusList.Where(x => x.t_status.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_display.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0013>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.t_status = POPUPEntityObject.t_status;
                    MasterEntity.t_display = POPUPEntityObject.t_display;
                }
                var msg = new NotificationMessage("SEL_T004_VM");
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
        private void InsertTransporter(object InputValue, bool OverrideValue)
        {
            try
            {
                //ADM_M028_PopUp
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
                            { POPUPEntityObject = MC.Transporters.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.transporter_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.tr_party = POPUPEntityObject.PartyId;
                    MasterEntity.transporter_name = POPUPEntityObject.transporter_name;
                }
                var msg = new NotificationMessage("SEL_T004_VM");
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
        private void InsertPlant(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;
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
                            POPUPEntityObject = PlantList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    MasterEntity.location_Id = POPUPEntityObject.location_Id;
                    MasterEntity.comp_code = POPUPEntityObject.comp_code;
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.location_Id = POPUPEntityObject.location_Id;
                    MasterEntity.comp_code = POPUPEntityObject.comp_code;
                }
                var msg = new NotificationMessage("SEL_T004_VM");
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
        private void LoadHistory()
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadHistory" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + Convert.ToDateTime(MasterEntity.Fltr_FrmDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.Fltr_ToDate).ToString("MM/dd/yyyy") + "!@" + MasterEntity.Fltr_active;

                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T004>(MCTemp, Request, "TransferOrder", "CRM", "LoadAll", 0, Request);

                FlipGridData = MCTemp.DocumentDataFlipGrid.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);
                
                var msg = new NotificationMessage("SEL_T004_VM");
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
        private void InsertStatus_Backflip(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0013 POPUPEntityObject = null;

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
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0013>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.fltr_t_status = POPUPEntityObject.t_status;
                    MasterEntity.fltr_t_display = POPUPEntityObject.t_display;
                }
            }
            catch (Exception Ex) { }
        }
        private void InsertShippingMode(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M026 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.ShippingTypes.Where(x => x.tr_mode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.tr_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M026>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.tr_mode = POPUPEntityObject.tr_mode;
                    MasterEntity.shipping_type_name = POPUPEntityObject.tr_name;
                }
                var msg = new NotificationMessage("SEL_T004_VM");
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
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
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
        private void InsertShipToAddress(object InputValue, bool OverrideValue)
        {
            try
            {
                string Request = "";
                ADM_M028_D POPUPEntityObject = null;
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
                            { POPUPEntityObject = MCTemp.PartysShipToAddresses.Where(x => x.SrNo.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.Location.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_D>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.ship_to_add = POPUPEntityObject.SrNo.ToString();
                    MasterEntity.del_address = POPUPEntityObject.address_full;
                    MasterEntity.ship_to_address_location = POPUPEntityObject.Location;      //add by sachin magar
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

        private void RemoveRefDoc()
        {
            try
            {
                List<SEL_T003_P_RefDoc> TempListReq = MC.Dispatch_Order_Reference;
                foreach (var item in TempListReq.ToList())
                {
                    if (item.Select == true)
                    {
                        MC.Dispatch_Order_Reference.Remove(item);
                    }
                }
                ReferenceDocSOCollection = CollectionViewSource.GetDefaultView(MC.Dispatch_Order_Reference);
                ReferenceDocSOCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                ReferenceDocSOCollection.Refresh();
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
            var data = obj as SEL_T004Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.sono != null && data.sono.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.cust_ref != null && data.cust_ref.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.delivery_no != null && data.delivery_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }

        #region Filters For Plant 
     
        private void FilterCollectionlocation()
        {
            if (_locationCollection != null)
            {
                _locationCollection.Refresh();
            }
        }
        private string _filterStringLocation;
        public string FilterStringLocation
        {
            get { return _filterStringLocation; }
            set
            {
                _filterStringLocation = value;
                RaisePropertyChanged("FilterStringLocation");
                FilterCollectionlocation();
            }
        }
        public bool FilterLocation(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringLocation))
                {
                    return (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterStringLocation.ToLower()) ||
                         data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterStringLocation.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

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
            if (ReferenceDocSOCollection != null)
            {
                ReferenceDocSOCollection.Refresh();
            }
        }
        public bool Filter_ReferenceDoc(object obj)
        {
            var data = obj as SEL_T003_P_RefDoc;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_ReferenceDoc))
                {
                    return (data.sono != null && data.sono.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.desp_date != null && data.desp_date.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.PartyNm != null && data.PartyNm.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.ItemCode != null && data.ItemCode.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.Description != null && data.Description.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.Ref_DocNo != null && data.Ref_DocNo.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.Ref_date != null && data.Ref_date.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.del_date != null && data.del_date.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.sch_no != null && data.sch_no.ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.PartyId != null && data.PartyId.ToLower().Contains(_FilterString_ReferenceDoc.ToLower())
                       );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Validation
        private bool validation()
        {
            try
            {
                foreach (var o in Dispatch_Order_Reference)
                {
                    if (Convert.ToDecimal(o.quantity) > Convert.ToDecimal(o.sch_qty))
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Despatch Quantity Cannot be greater than Schedule Quantity");

                        showMessageService.ShowMessage();
                        return false;
                    }
                }

                if (ItemEntity.Count < 1)//when form is blank and we save the record
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("At Least Insert One Item........");
                    showMessageService.ShowMessage();

                    return false;
                }
                else
                {
                    foreach (var o in ItemEntity)
                    {
                        if (o.ItemCode != null && o.ItemCode != "" && o.ItemName != null)
                        {
                            int flag = 0;
                            if (o.id == 0)
                            {
                                foreach (var p in ItemEntity)
                                {
                                    if (o.ItemCode == p.ItemCode && o.sku == p.sku)
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

        #region Abstract Method
        protected override void OnSaveAction(InquiryActionResult<SEL_T004> result)
        {
            try
            {
                if (validation() == true)
                {
                    MasterEntity.XmlDataDocument_SEL_T004_A = obj.ObjectToXML(ItemEntity);
                    this.MasterEntity.EndEdit();

                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<SEL_T004>(MasterEntity, "TransferOrder", "CRM");
                        if (MasterEntity.doc_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnInsert") >= 0)
                        {
                            NotifyMessage("OnInsert");
                        }
                        if (MasterEntity.doc_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnApproval") >= 0)
                        {
                            NotifyMessage("OnApproval");
                        }
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<SEL_T004>(MasterEntity, "TransferOrder", "CRM");

                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    isNewRecord = false;
                    RemoveRefDoc();
                    var msg = new NotificationMessage("SEL_T004_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);
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
        protected override void OnCreateAction(InquiryActionResult<SEL_T004> result)
        {
            isNewRecord = true;
            MasterEntity = new SEL_T004();
            MasterEntity.ValidateAsync().Wait();
            ItemEntity = new ObservableCollection<SEL_T004_A>();
            ItemEntity.Clear();
            DefaultValues(AppSessionState.TransactionCode);
            var msg = new NotificationMessage("SEL_T004_VM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        protected override void OnRemoveAction(InquiryActionResult<SEL_T004> result)
        {
            try
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Delete Changes";
                showMessageService.Text =
                    String.Format(
                        "This record will delete forever '{0}'",
                            this.Title);

                if (showMessageService.ShowMessage() == DialogResult.Ok)
                {
                    this.MasterEntity.CancelEdit();
                    string response = repository.Delete(MasterEntity.doc_no, "TransferOrder", "CRM");

                    MasterEntity = new SEL_T004();
                    ItemEntity = new ObservableCollection<SEL_T004_A>();
                    FlipDataGridCollection.Refresh();
                    isNewRecord = true;
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
        protected override void OnDiscardAction(InquiryActionResult<SEL_T004> result)
        {
            //SelectedSEL_T001.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<SEL_T004> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<SEL_T004> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<SEL_T004> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<SEL_T004> result)
        {
            try
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
                    //SEL_T004Flip ParameterEntityObject = null;
                    //ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<SEL_T004Flip>().ToList()[0];
                    string Request = "LoadDocumentFromBackFlip" + "!@" + MasterEntity.doc_no + "!@" + MasterEntity.ref_doc_cat;

                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T004>(MCTemp, Request, "TransferOrder", "CRM", "LoadAll", 0, Request);

                    object[] objDataSource = new object[4];
                    string[] objDataSourceName = new string[4];


                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[0] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[1] = Result;

                    objDataSource[2] = MCTemp.MasterEntity;
                    objDataSource[3] = MCTemp.ItemsEntity;

                    objDataSourceName[0] = "dsCompany";
                    objDataSourceName[1] = "dsLocation";
                    objDataSourceName[2] = "dsDispatch_RPT";
                    objDataSourceName[3] = "dsDispatch__Item_RPT";

                    ReportManager ReportManager = new ReportManager();
                    //ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\Dispatch_Order.rdlc", "GRN_P2P");

                    string ReportDisplayName = MasterEntity.ship_to_party_name + "_" + MasterEntity.doc_no + "_" + MasterEntity.doc_date.Value.ToShortDateString();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\Dispatch_Order.rdlc" , getParametersList(), ReportDisplayName); //QuotationMurRpt.rdlc

                }
            }
            catch (Exception ex)
            { }
        }
        protected override void OnDocumentAction()
        {
            var msg = new NotificationMessage("SEL_T004_VM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }

        protected override void OnRefreshCommand(InquiryActionResult<SEL_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<SEL_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<SEL_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<SEL_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<SEL_T004> result)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}


   
       