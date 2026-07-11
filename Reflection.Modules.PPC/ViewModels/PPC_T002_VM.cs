using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ReflectionSystem;
using Reflection.BusinessEntity.Production;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using System.Collections.Specialized;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.FICO;
using Reflection.BusinessEntity.MM;
using System.IO;
using System.Reflection;
using GalaSoft.MvvmLight.Ioc;
using Reflection.Presentation.Core.VirtualDesktops;
using Reflection.ReportingServices;
using System.Threading.Tasks;
using Reflection.BusinessEntity.GEN;

namespace Reflection.Modules.PPC.ViewModels
{
    public class PPC_T002_VM : WorkspaceViewModel<EPR_T001>
    {
        #region Private Local Variable Declaration
        IShowMessageViewService sms;
        private bool _isNewRecord { get; set; }
        private bool isNewRecord
        {
            get { return _isNewRecord; }
            set
            {
                if (_isNewRecord != value)
                { _isNewRecord = value; RaisePropertyChanged("isNewRecord"); }
            }
        }
        private bool _EntityChangeEnable { get; set; }
        private bool EntityChangeEnable
        {
            get { return _EntityChangeEnable; }
            set
            {
                if (_EntityChangeEnable != value)
                { _EntityChangeEnable = value; RaisePropertyChanged("EntityChangeEnable"); }
            }
        }
        private string ts_code_vm { get; set; }
        private string doc_no_vm { get; set; }
        private string doc_cat_vm { get; set; }
        private string doc_type_vm { get; set; }
        private string SelectedReferenceDocuments;

        WebServiceRepository<EPR_T001> REPO = new WebServiceRepository<EPR_T001>();
        WebServiceRepository<MC_PPC_BE> REPO_MC = new WebServiceRepository<MC_PPC_BE>();
        WebServiceRepository<STD_MC_BE> REPO_STD = new WebServiceRepository<STD_MC_BE>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MC_PPC_BE _MC = new MC_PPC_BE();
        public MC_PPC_BE MC
        {
            get { return _MC; }
            set { if (_MC != value) { _MC = value; RaisePropertyChanged("MC"); } }
        }
        private MC_PPC_BE _MCTemp = new MC_PPC_BE();
        public MC_PPC_BE MC_TEMP
        {
            get { return _MCTemp; }
            set { if (_MCTemp != value) { _MCTemp = value; RaisePropertyChanged("MC_TEMP"); } }
        }
        private STD_MC_BE _MC_STD = new STD_MC_BE();
        public STD_MC_BE MC_STD
        {
            get { return _MC_STD; }
            set { if (_MC_STD != value) { _MC_STD = value; RaisePropertyChanged("MC_STD"); } }
        }
        List<PPC_T004_A> ReferenceDocFilteredList = new List<PPC_T004_A>(); // Reference document filtered collection store here.

        private EPR_T001 _MasterEntity;
        public EPR_T001 MasterEntity
        {
            get { return _MasterEntity; }
            set { if (_MasterEntity != value) { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); } }
        }
        private ObservableCollection<EPR_T001_A> _EPR_T001_A_OBJ_OC;
        public ObservableCollection<EPR_T001_A> EPR_T001_A_OBJ_OC
        {
            get
            {
                return _EPR_T001_A_OBJ_OC;
            }
            set
            {
                if (_EPR_T001_A_OBJ_OC != value)
                {
                    _EPR_T001_A_OBJ_OC = value;
                    EPR_T001_A_OBJ_OC.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForOperationEntity);
                    RaisePropertyChanged("EPR_T001_A_OBJ_OC");
                }
            }
        }
        private EPR_T001_A _EPR_T001_A_OBJ;
        public EPR_T001_A EPR_T001_A_OBJ
        {
            get { return _EPR_T001_A_OBJ; }
            set { if (_EPR_T001_A_OBJ != value) { _EPR_T001_A_OBJ = value; RaisePropertyChanged("EPR_T001_A_OBJ"); } }
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
        private STD_LIST_BE _STD_LIST_OBJECT;
        public STD_LIST_BE STD_LIST_OBJECT
        {
            get
            {
                return _STD_LIST_OBJECT;
            }
            set
            {
                if (_STD_LIST_OBJECT != value)
                {
                    _STD_LIST_OBJECT = value;
                    RaisePropertyChanged("STD_LIST_OBJECT");
                }
            }
        }
        private IEnumerable _VALUE_COLLECTION;
        public IEnumerable VALUE_COLLECTION
        {
            get { return _VALUE_COLLECTION; }
            set
            {
                if (_VALUE_COLLECTION != value)
                {
                    _VALUE_COLLECTION = value; RaisePropertyChanged("VALUE_COLLECTION");
                }
            }
        }
        private ObservableCollection<GEN_T021> _CLASS_OCL;
        public ObservableCollection<GEN_T021> CLASS_OCL
        {
            get
            {
                return _CLASS_OCL;
            }
            set
            {
                if (_CLASS_OCL != value)
                {
                    _CLASS_OCL = value; RaisePropertyChanged("CLASS_OCL");
                }
            }
        }
        private GEN_T021 _CLASS_OBJ;
        public GEN_T021 CLASS_OBJ
        {
            get
            {
                return _CLASS_OBJ;
            }
            set
            {
                if (_CLASS_OBJ != value)
                {
                    _CLASS_OBJ = value; RaisePropertyChanged("CLASS_OBJ");
                    SC_CLASS_OBJ(CLASS_OBJ);
                }
            }
        }
        
        private STD_REQ_PARA_BE _REQ_PARA_OBJ;
        public STD_REQ_PARA_BE REQ_PARA_OBJ
        {
            get { return _REQ_PARA_OBJ; }
            set
            {
                if (_REQ_PARA_OBJ != value)
                {
                    _REQ_PARA_OBJ = value;

                    RaisePropertyChanged("REQ_PARA_OBJ");
                }
            }
        }
        private ICollectionView _ReferenceDocCollection;
        public ICollectionView ReferenceDocCollection
        {
            get { return _ReferenceDocCollection; }
            set { _ReferenceDocCollection = value; RaisePropertyChanged("ReferenceDocCollection"); }
        }
        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }
        private ICollectionView _ProductionOrderChart;
        public ICollectionView ProductionOrderChart
        {
            get { return _ProductionOrderChart; }
            set { _ProductionOrderChart = value; RaisePropertyChanged("ProductionOrderChart"); }
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
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }

        }
        private int _TabIndexItem;
        public int TabIndexItem
        {
            get { return _TabIndexItem; }
            set
            {
                if (_TabIndexItem != value)
                {
                    _TabIndexItem = value;
                    RaisePropertyChanged("TabIndexItem");
                }
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
        private IEnumerable _METHOD_LIST;
        public IEnumerable METHOD_LIST
        {
            get { return _METHOD_LIST; }
            set
            {
                _METHOD_LIST = value;

                RaisePropertyChanged("METHOD_LIST");
            }
        }
        private IEnumerable _COM_LIST;
        public IEnumerable COM_LIST
        {
            get { return _COM_LIST; }
            set
            {
                _COM_LIST = value;

                RaisePropertyChanged("COM_LIST");
            }
        }
        #endregion

        #region Automation Variables

        private ICollectionView _GRID_COLLECTION; // This will use to show Sales order in child Model Window from where Production Order get created for this list automatically or manually.
        public ICollectionView GRID_COLLECTION
        {
            get { return _GRID_COLLECTION; }
            set
            {
                if (_GRID_COLLECTION != value)
                {
                    _GRID_COLLECTION = value;

                    RaisePropertyChanged("GRID_COLLECTION");

                }
            }

        }

        private STD_LIST_BE _SO_OBJ; // This is binded to SelectedItem property of SO List Model Window.
        public STD_LIST_BE SO_OBJ
        {
            get
            {
                return _SO_OBJ;
            }
            set
            {
                if (_SO_OBJ != value)
                {
                    _SO_OBJ = value; RaisePropertyChanged("SO_OBJ");
                }
            }
        }

        #endregion 
        #region Automation Relay Command
        public RelayCommand<object> cmdExecuteBulkOrders { get; private set; }
        public RelayCommand<object> cmdInvokeDocument { get; private set; }

        #endregion

        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PPC_T002_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
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
        private AutoSuggestTextViewModel<dynamic> _ASItem { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItem
        {
            get { return _ASItem; }
            set
            {
                if (_ASItem != value)
                {
                    _ASItem = value; RaisePropertyChanged("ASItem");
                }
            }
        }
        //private AutoSuggestTextViewModel<dynamic> _AS_COMPANY { get; set; }
        //public AutoSuggestTextViewModel<dynamic> AS_COMPANY
        //{
        //    get { return _AS_COMPANY; }
        //    set
        //    {
        //        if (_AS_COMPANY != value)
        //        {
        //            _AS_COMPANY = value; RaisePropertyChanged("AS_COMPANY");
        //        }
        //    }
        //}
        private AutoSuggestTextViewModel<dynamic> _AS_LOCATION { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_LOCATION
        {
            get { return _AS_LOCATION; }
            set
            {
                if (_AS_LOCATION != value)
                {
                    _AS_LOCATION = value; RaisePropertyChanged("AS_LOCATION");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_LOCATION_PLAN { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_LOCATION_PLAN
        {
            get { return _AS_LOCATION_PLAN; }
            set
            {
                if (_AS_LOCATION_PLAN != value)
                {
                    _AS_LOCATION_PLAN = value; RaisePropertyChanged("AS_LOCATION_PLAN");
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
        private AutoSuggestTextViewModel<dynamic> _ASStatus { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASStatus
        {
            get { return _ASStatus; }
            set
            {
                if (_ASStatus != value)
                {
                    _ASStatus = value; RaisePropertyChanged("ASStatus");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASShift { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASShift
        {
            get { return _ASShift; }
            set
            {
                if (_ASShift != value)
                {
                    _ASShift = value; RaisePropertyChanged("ASShift");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASProfitCenter { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASProfitCenter
        {
            get { return _ASProfitCenter; }
            set
            {
                if (_ASProfitCenter != value)
                {
                    _ASProfitCenter = value; RaisePropertyChanged("ASProfitCenter");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASCostCenter { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCostCenter
        {
            get { return _ASCostCenter; }
            set
            {
                if (_ASCostCenter != value)
                {
                    _ASCostCenter = value; RaisePropertyChanged("ASCostCenter");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASRouting { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRouting
        {
            get { return _ASRouting; }
            set
            {
                if (_ASRouting != value)
                {
                    _ASRouting = value; RaisePropertyChanged("ASRouting");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASBOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBOM
        {
            get { return _ASBOM; }
            set
            {
                if (_ASBOM != value)
                {
                    _ASBOM = value; RaisePropertyChanged("ASBOM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ASSET { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ASSET
        {
            get { return _AS_ASSET; }
            set
            {
                if (_AS_ASSET != value)
                {
                    _AS_ASSET = value; RaisePropertyChanged("AS_ASSET");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASEmployee { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASEmployee
        {
            get { return _ASEmployee; }
            set
            {
                if (_ASEmployee != value)
                {
                    _ASEmployee = value; RaisePropertyChanged("ASEmployee");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASStoreCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASStoreCode
        {
            get { return _ASStoreCode; }
            set
            {
                if (_ASStoreCode != value)
                {
                    _ASStoreCode = value; RaisePropertyChanged("ASStoreCode");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ORDER_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ORDER_TYPE
        {
            get { return _AS_ORDER_TYPE; }
            set
            {
                if (_AS_ORDER_TYPE != value)
                {
                    _AS_ORDER_TYPE = value; RaisePropertyChanged("AS_ORDER_TYPE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_WORK_CENTER { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_WORK_CENTER
        {
            get { return _AS_WORK_CENTER; }
            set
            {
                if (_AS_WORK_CENTER != value)
                {
                    _AS_WORK_CENTER = value; RaisePropertyChanged("AS_WORK_CENTER");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_CONTROL_KEY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CONTROL_KEY
        {
            get { return _AS_CONTROL_KEY; }
            set
            {
                if (_AS_CONTROL_KEY != value)
                {
                    _AS_CONTROL_KEY = value; RaisePropertyChanged("AS_CONTROL_KEY");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_OPERATIONS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_OPERATIONS
        {
            get { return _AS_OPERATIONS; }
            set
            {
                if (_AS_OPERATIONS != value)
                {
                    _AS_OPERATIONS = value; RaisePropertyChanged("AS_OPERATIONS");
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
                    if (SourceName == "wc_code")
                    {
                        if (EPR_T001_A_OBJ != null && MC.WC_LIST.Count > 0)
                        {
                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).wc_code ?? "");
                            TheFilter = (o, prefix) => (((STD_LIST_BE)o).wc_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_LIST_BE)o).wc_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            AS_WORK_CENTER = new AutoSuggestTextViewModel<dynamic>(MC.WC_LIST.Where(x => x.location_id == EPR_T001_A_OBJ.location_id).ToList(), TheFilter, SuggestedValue, "wc_code", "wc_code", true);
                            AS_WORK_CENTER.AutoSuggestVM.IsEmptyValueAllowed = true;
                        }
                        ASDefault = AS_WORK_CENTER;
                    }
                    else if (SourceName == "control_key")
                    { ASDefault = AS_CONTROL_KEY; }
                    else if (SourceName == "location_id")
                    { ASDefault = AS_LOCATION_PLAN; }
                    else if (SourceName == "op_code")
                    { ASDefault = AS_OPERATIONS; }


                }
            }
        }

        #endregion
        #region Relay Command
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdReferenceDocumentSelection { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdLoadBackFlipData { get; private set; }
        public RelayCommand<object> cmdProductionOrderChart { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_EPR_T001_A { get; private set; }
        public RelayCommand<object> cmdExecuteReferenceDocuments { get; private set; }
        public RelayCommand<object> cmdOperation { get; private set; }
        public RelayCommand<object> cmdInsertItemCode { get; private set; }
        public RelayCommand<object> cmdInsertStoreCode { get; private set; }
        public RelayCommand<object> cmdOperationEntityRowDelete { get; private set; }
        public RelayCommand<object> cmdInsertRouting { get; private set; }

        //NOTE: cmdComponantView, incomplete funtion because we have made provision for MasterEntity of EPR_T001 to send as parameter and with the 
        //help of BOM & Routing we assign componants for all operation. to assign direct at operation level, we need to send Operation 
        //as parameter with order header details then we can use this function to assign componants at Order Heder level or 
        //Operation Level or at Project Phase level. need to send generic paramter and level input for which we need to assign componants.
        public RelayCommand<EPR_T001> cmdComponantView { get; private set; }
        public RelayCommand<EPR_T001_A> cmdResourceView { get; private set; }
        public RelayCommand<EPR_T001> cmdHistory { get; private set; }
        public RelayCommand<EPR_T001> cmdTrace { get; private set; }
        public RelayCommand<EPR_T001> cmdLogReport { get; private set; }
        //public RelayCommand<object> cmdInsertCompany { get; private set; }
        //public RelayCommand<object> cmdInsertLocation { get; private set; } // Production Plant
        private void SelectedRequestBulk(object InputValue) // can be remove this function, we hahe include this code in Function of OK Button below the popup window.
        {
            try
            {
                STD_LIST_BE POPUPEntityObject = null;
                //DocumentList = "";
                if (InputValue != null && ((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    if (POPUPEntityObject.selected == true)
                    {
                        foreach (var item in MC.GRID_COLLECTION)
                        {
                            if (item.doc_no == POPUPEntityObject.doc_no)
                            {
                                item.selected = true;
                            }
                        }
                        GRID_COLLECTION = CollectionViewSource.GetDefaultView(MC.GRID_COLLECTION);
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        public RelayCommand<object> cmdSelectRequestBulk { get; private set; }
        #endregion

        #region Abstract Command
        protected override void OnCreateAction(InquiryActionResult<EPR_T001> result)
        {
            if (MasterEntity.comp_code != AppSessionState.OBJ_COMPANY.comp_code) // call when document loading of different company. call before Master Entity instance is being created.
            {
                LoadInitialData(AppSessionState.OBJ_COMPANY.comp_code, AppSessionState.OBJ_LOCATION.location_id);
            }
            MasterEntity = new EPR_T001();
            EPR_T001_A_OBJ = new EPR_T001_A();
            EPR_T001_A_OBJ_OC = new ObservableCollection<EPR_T001_A>();
            CLASS_OCL = new ObservableCollection<GEN_T021>();
            CLASS_OBJ = new GEN_T021();
            EPR_T001_A_OBJ_OC.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForOperationEntity);
            DefaultValues();
            isNewRecord = true;
            if (MC.DOC_TYPE_LIST_NEW.Count > 0)
            {
                if (MC.DOC_TYPE_LIST_NEW.Where(x => x.doc_type == doc_cat_vm).ToList().Count > 0)
                {
                    //MasterEntity.ind_batch = MC.DOC_TYPE_LIST_NEW.Where(x => x.doc_type == doc_cat_vm).ToList()[0].ind_batch;
                    MasterEntity.ind_batch = "A";
                }
                else
                {
                    MasterEntity.ind_batch = "A";
                }
            }
            SelectedTabControlIndex = 0;
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
        }
        protected override void OnDiscardAction(InquiryActionResult<EPR_T001> result)
        {

        }
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.order_no))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.order_no.Replace("/", "--"), DocumentList = MC_TEMP.ATTACHMENT_LIST, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<EPR_T001> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<EPR_T001> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<EPR_T001> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<EPR_T001> result)
        {
            try
            {
                CursorControl.SetBusyState();
                string ReportName = "";
                ADM_M0010 OBJ_DOC_TYPE = new ADM_M0010();
                object[] objDataSource = new object[14];
                string[] objDataSourceName = new string[14];

                objDataSource[0] = AppSessionState.COMPANY_LIST.Where(x => x.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[1] = AppSessionState.LOCATION_LIST.Where(x => x.comp_code == MasterEntity.comp_code && x.location_id==MasterEntity.location_Id).ToList();


                if (!string.IsNullOrWhiteSpace(MasterEntity.order_no))
                {
                    QRCodeService QRGenerator = new QRCodeService();
                    MasterEntity.qr_image = QRGenerator.RenderQrCodeForLabel(MasterEntity.order_no, 15, "");
                }

                if (MC.MasterEntity != null)
                {
                    if (MC.MasterEntity.Count > 0)
                    {
                        MC.MasterEntity.Clear();
                        MC.MasterEntity.Add(MasterEntity);
                    }
                    else
                    {
                        MC.MasterEntity.Add(_MasterEntity);
                    }
                }
                objDataSource[2] = MC.MasterEntity;
                objDataSource[3] = EPR_T001_A_OBJ_OC;
                objDataSource[4] = MC.DOC_TYPE_LIST_NEW.Where(x => x.doc_cat == MasterEntity.doc_cat && x.doc_type == MasterEntity.doc_type).ToList();
                objDataSource[5] = MC.SO_LIST;
                objDataSource[6] = MC.QN_LIST;
                objDataSource[7] = MC.SN_LIST;
                objDataSource[8] = MC.GM_LIST;
                objDataSource[9] = MC.DN_LIST;
                objDataSource[10] = MC.EQUIPMENT_LIST;
                objDataSource[11] = MC.INVOICE_LIST;
                objDataSource[12] = CLASS_OCL;
                objDataSource[13] = MC.SO_ITEM_LIST;

                objDataSourceName[0] = "dsCompany";
                objDataSourceName[1] = "dsLocation";
                objDataSourceName[2] = "dsMaster";
                objDataSourceName[3] = "dsOperation";
                objDataSourceName[4] = "dsDocType";
                objDataSourceName[5] = "dsSO";
                objDataSourceName[6] = "dsQN";
                objDataSourceName[7] = "dsSN";
                objDataSourceName[8] = "dsGM";
                objDataSourceName[9] = "dsDN";
                objDataSourceName[10] = "dsAsset";
                objDataSourceName[11] = "dsSI";
                objDataSourceName[12] = "dsClassification";
                objDataSourceName[13] = "dsItems";

                ReportManager ReportManager = new ReportManager();

                var SystemDocumentObject = (from o in MC.DOC_TYPE_LIST_NEW where o.doc_cat == MasterEntity.doc_cat && o.doc_type == MasterEntity.doc_type select o).ToList();
                if (SystemDocumentObject != null)
                {
                    if (SystemDocumentObject.Count > 0)
                    {
                        OBJ_DOC_TYPE = SystemDocumentObject[0];
                    }
                }
                if (OBJ_DOC_TYPE.ind_digital == "0")
                {
                    ReportName = OBJ_DOC_TYPE.report_name.Split(',')[1];
                }
                else
                {
                    ReportName = OBJ_DOC_TYPE.report_name.Split(',')[0];
                }

                string ReportDisplayName = MasterEntity.order_no + "_" + MasterEntity.doc_date.Value.ToShortDateString();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORTS_STD\\TXN\\" + ReportName, getParametersList(), ReportDisplayName);
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        protected override void OnRemoveAction(InquiryActionResult<EPR_T001> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<EPR_T001> result)
        {
            CursorControl.SetBusyState();
            try
            {
                if(TabIndexItem == 3)
                {
                    TabIndexItem = 0; // This is for shifting focus from Editor control
                }
                
                if (Validation() == true)
                {
                    Logging();
                    MasterEntity.XDOC_A = obj.ObjectToXML(EPR_T001_A_OBJ_OC);
                    MasterEntity.XDOC_VC = obj.ObjectToXML(CLASS_OCL);

                    if (isNewRecord == true)
                    {
                        MasterEntity = REPO.SaveWithReturnDomainObject<EPR_T001>(MasterEntity, "EPR_T001_BL", "PPC");

                        if (MasterEntity.order_no != null && MC.NOTIFICATION_LIST.FindIndex(f => f.alert_name == "OnInsert") >= 0)
                        {
                            NotifyMessage("OnInsert", "Created");
                        }
                        if (MasterEntity.order_no != null && MC.NOTIFICATION_LIST.FindIndex(f => f.alert_name == "OnApproval") >= 0)
                        {
                            NotifyMessage("OnApproval", "Created");
                        }
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = REPO.UpdateWithReturnDomainObject<EPR_T001>(MasterEntity, "EPR_T001_BL", "PPC");
                        NotifyMessage("OnInsert", "Created");
                        if (MasterEntity.order_no != null && MC.NOTIFICATION_LIST.Exists(element => element.alert_name == "OnUpdate") == true)
                        {
                            NotifyMessage("OnUpdate", "Modified");
                        }
                    }
                    SaveClassification("");

                    MasterEntity.ts_code = ts_code_vm;
                    MasterEntity.userid = AppSessionState.UserID;
                    SetBusinessEntitiesAfterLoad("Save", "");
                    RemoveSelectedReferenceDocuments();
                    isNewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                    Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
                    if (MasterEntity.order_no != null || MasterEntity.order_no != "")
                    {
                        
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                        sms.ButtonSetup = DialogButton.Ok;
                        sms.Caption = "Message";
                        sms.Text = String.Format("Record saved Successfully ........");
                        sms.ShowMessage();
                    }
                }
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

        private void SaveClassification(string request)
        {
            try
            {
                if(CLASS_OCL != null)
                {
                    if (CLASS_OCL.Count > 0)
                    {
                        if(isNewRecord==true)
                        {
                            foreach (var item in CLASS_OCL)
                            {
                                item.doc_no = MasterEntity.order_no;
                                item.active = "1";
                            }
                        }
                        else
                        {
                            foreach (var item in CLASS_OCL)
                            {
                                item.doc_no = MasterEntity.order_no;
                                item.active = "1";
                            }
                        }

                        MC_STD.GEN_CHAR_VALUE_LIST = CLASS_OCL;
                        MC_STD = REPO_STD.SaveWithReturnDomainObject<STD_MC_BE>(MC_STD, "GEN_T021_BL", "GEN");
                        CLASS_OCL = MC_STD.GEN_CHAR_VALUE_LIST;
                    }
                }
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        public string ConvertDataTableToHTML()
        {
            string html = "<table>";
            //add header row
            html += "<tr bgcolor=#e0e0eb>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Op Code </span></strong></p> </td>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Op No </span></strong></p> </td>";
            html += "<td width=50%> <p><strong><span style=color:#000080;> Operation Description </span></strong></p> </td>";
            //html += "<td width=5%> <p><strong><span style=color:#000080;> Unit </span></strong></p> </td>";
            html += "<td width=10%> <p><strong><span style=color:#000080;> Unit Price </span></strong></p> </td>";
            html += "</tr>";

            foreach (var item in EPR_T001_A_OBJ_OC)
            {
                if (item.active == true )
                {
                    html += "<tr bgcolor=#d9e6f2>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.op_code + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.operation_no + "</p></span></strong></p> </td>";
                    html += "<td width=10%> <p><strong><span style=color:#000080;> " + item.operation_desc + "</span></strong></p> </td>";
                    //html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.quantity.ToString() + "</span></strong></p> </td>";
                    //html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.unit_code + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + (item.unit_price.HasValue ? decimal.Round(item.unit_price.Value, 2).ToString() : "") + "</span></strong></p> </td>";
                    html += "</tr>";
                }
            }
            html += "</table>";

            return html;
        }
        private void NotifyMessage(string AlertName, string operation)
        {
            try
            {
                List<NotificationData> objNotifyData = new List<NotificationData>();
                List<NotificationData> objNotifyDataTemp = new List<NotificationData>();
                NotificationData objNotifyDataObject = new NotificationData();
                string xx = ConvertDataTableToHTML();
                objNotifyDataTemp = MC.NOTIFICATION_LIST.Where(x => x.alert_name == AlertName).ToList();
                objNotifyDataTemp[0].CopyPropertiesTo<NotificationData>(objNotifyDataObject);
                objNotifyData.Add(objNotifyDataObject);
                foreach (NotificationData VarData in objNotifyData)
                {
                    List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("[EMP]",AppSessionState.EmpName),
                        new KeyValuePair<string, string>("[DOC]", MasterEntity.doc_type_name),
                        new KeyValuePair<string, string>("[TITLE]", MasterEntity.title ?? MasterEntity.short_text),
                        new KeyValuePair<string, string>("[OPR]", operation),
                        new KeyValuePair<string, string>("[DOCNO]", MasterEntity.order_no),
                        new KeyValuePair<string, string>("[DOCDATE]", MasterEntity.doc_date.ToString()),
                         new KeyValuePair<string, string>("[MODDT]", DateTime.Now.ToString()),
                        new KeyValuePair<string, string>("[Comp]","M/S: " + AppSessionState.OBJ_COMPANY.comp_name),
                        new KeyValuePair<string, string>("[TSTS]", MasterEntity.t_display),
                        new KeyValuePair<string, string>("[RESP]",MasterEntity.emp_name),
                        new KeyValuePair<string, string>("[Attn]",MasterEntity.emp_name),
                        new KeyValuePair<string, string>("[SUB]", MasterEntity.short_text),
                        new KeyValuePair<string, string>("[OBJ]", ((MasterEntity.equip_no ?? MasterEntity.ItemCode) ?? "") + " " + MasterEntity.ItemName),
                        //new KeyValuePair<string, string>("[PART]", MasterEntity.party_code),
                        new KeyValuePair<string, string>("[BODYTEXT]", MasterEntity.long_text),
                        new KeyValuePair<string, string>("[ITEM_TABLE]", xx),
                    };

                    foreach (KeyValuePair<string, string> kvp in kvpList)
                    {
                        VarData.subject = VarData.subject.Replace(kvp.Key, kvp.Value);
                        VarData.msg_body = VarData.msg_body.Replace(kvp.Key, kvp.Value);
                    }
                    VarData.cc_mail_id = (VarData.cc_mail_id ?? "") + ";" + (VarData.cc_mail_id == AppSessionState.EmpEmailId ? "" : (";" + AppSessionState.EmpEmailId));
                    Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, VarData.to_mail_id, VarData.cc_mail_id, VarData.bcc_mail_id, VarData.subject, VarData.msg_body, null);
                }
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MasterEntity.XDOC_A != null)
            {
                EPR_T001_A_OBJ_OC.Clear();
                EPR_T001_A_OBJ_OC = (ObservableCollection<EPR_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_A, MC.OperationEntity);
            }
            else
            {
                MC.OperationEntity = new ObservableCollection<EPR_T001_A>();
            }

            MasterEntity.ts_code = ts_code_vm;
        }

        #endregion
        #region Constructor
        public PPC_T002_VM(string ts_code, string doc_cat, string doc_type) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.doc_type_vm = doc_type;
            this.ts_code_vm = ts_code;
            EPR_T001.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MC_PPC_BE();
            MC_TEMP = new MC_PPC_BE();
            MC_STD = new STD_MC_BE();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            MasterEntity = new EPR_T001();
            EPR_T001_A_OBJ = new EPR_T001_A();
            EPR_T001_A_OBJ_OC = new ObservableCollection<EPR_T001_A>();
            EPR_T001_A_OBJ_OC.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForOperationEntity);
            CLASS_OCL = new ObservableCollection<GEN_T021>();
            CLASS_OBJ = new GEN_T021();
            sms = this.GetViewService<IShowMessageViewService>();
            InitializeCommands();
        }
        public PPC_T002_VM(string ts_code, string doc_cat, string doc_type, string doc_no) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.doc_type_vm = doc_type;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            EPR_T001.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MC_PPC_BE();
            MC_TEMP = new MC_PPC_BE();
            MC_STD = new STD_MC_BE();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            MasterEntity = new EPR_T001();
            EPR_T001_A_OBJ = new EPR_T001_A();
            EPR_T001_A_OBJ_OC = new ObservableCollection<EPR_T001_A>();
            EPR_T001_A_OBJ_OC.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForOperationEntity);
            CLASS_OCL = new ObservableCollection<GEN_T021>();
            CLASS_OBJ = new GEN_T021();
            sms = this.GetViewService<IShowMessageViewService>();
            InitializeCommands();
        }
        public PPC_T002_VM(string ts_code, string doc_cat, string doc_type, STD_LIST_BE STD_LIST_OBJ) : base() // Constructor for Document creation automatically rather than user input.
        {
            isNewRecord = true;
            STD_LIST_OBJECT = new STD_LIST_BE();
            STD_LIST_OBJECT = STD_LIST_OBJ;
            this.doc_cat_vm = doc_cat;
            this.doc_type_vm = doc_type;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = STD_LIST_OBJECT.doc_no;
            EPR_T001.ModelEntityUpdated += new EventHandler(Model_MasterEntityChange);
            MC = new MC_PPC_BE();
            MC_TEMP = new MC_PPC_BE();
            MC_STD = new STD_MC_BE();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            MasterEntity = new EPR_T001();
            EPR_T001_A_OBJ = new EPR_T001_A();
            EPR_T001_A_OBJ_OC = new ObservableCollection<EPR_T001_A>();
            EPR_T001_A_OBJ_OC.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForOperationEntity);
            CLASS_OCL = new ObservableCollection<GEN_T021>();
            CLASS_OBJ = new GEN_T021();
            sms = this.GetViewService<IShowMessageViewService>();
            InitializeCommands();
            LoadInitialData(STD_LIST_OBJECT);
        }
        #endregion
        #region Standard Functions
        private void LoadInitialData(string company, string location)
        {
            try
            {
                string Request = "LOAD_INI_PPC" + "!@" + AppSessionState.client.ToString() + "!@" + company + "!@" + location + "!@" + doc_cat_vm + "!@" + AppSessionState.EmpId + "!@" + doc_type_vm;
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_PPC_BE>(MC, Request, "EPR_T001_BL", "PPC", " ", 0, "");

                #region New Popup Collection

                UNIT_LIST = MC.UOM_LIST;
                METHOD_LIST = MC.METHOD_LIST;
                COM_LIST = MC.COMON_LIST;

                #endregion
                #region New Popup Collection

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0010)x).doc_type);
                TheFilter = (o, prefix) => (((ADM_M0010)o).doc_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0010)o).doc_type_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDocType = new AutoSuggestTextViewModel<dynamic>(MC.DOC_TYPE_LIST_NEW, TheFilter, SuggestedValue, "doc_type", true);
                ASDocType.AutoSuggestVM.IsEmptyValueAllowed = false; ASDocType.AutoSuggestVM.IsFreeTextAllowed = false;

                
                TheFilter = (o, prefix) => (((STD_ITEM)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).equip_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).equip_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                if (doc_cat_vm == "NR")
                {
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).equip_no);
                    ASItem = new AutoSuggestTextViewModel<dynamic>(MC.STD_ITEM_LIST, TheFilter, SuggestedValue, "equip_no", true);
                }
                else
                {
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code);
                    ASItem = new AutoSuggestTextViewModel<dynamic>(MC.STD_ITEM_LIST, TheFilter, SuggestedValue, "item_code", true);
                }
                ASItem.AutoSuggestVM.IsEmptyValueAllowed = false; ASItem.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASUOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                ASUOM.AutoSuggestVM.IsEmptyValueAllowed = false; ASUOM.AutoSuggestVM.IsFreeTextAllowed = false;

                //string camp_value = MasterEntity.comp_code;
                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                //TheFilter = (o, prefix) => (((ADM_M0002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0002)o).comp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", true);
                //AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = true;
                //MasterEntity.comp_code = camp_value;

                string loc_value = MasterEntity.location_Id;
                List<ADM_M0003> LOC_LIST_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == AppSessionState.OBJ_COMPANY.comp_code).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_id", true);
                AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = false; AS_LOCATION.AutoSuggestVM.IsFreeTextAllowed = false;
                MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;

                string loc_value2 = MasterEntity.planning_plant;
                MasterEntity.location_Id = loc_value;
                List<ADM_M0003> LOC_LIST_OBJ2 = MC.LOCATION_LIST.Where(item => item.comp_code == AppSessionState.OBJ_COMPANY.comp_code).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_LOCATION_PLAN = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ2, TheFilter, SuggestedValue, "location_id", true);
                AS_LOCATION_PLAN.AutoSuggestVM.IsEmptyValueAllowed = true; AS_LOCATION_PLAN.AutoSuggestVM.IsFreeTextAllowed = false;
                MasterEntity.planning_plant = loc_value2;

                List<MM_M0001> StoreList = (MC.STORE_LIST.Where(item => item.location_Id == MasterEntity.location_Id).ToList());
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0001)x).store_code);
                TheFilter = (o, prefix) => (((MM_M0001)o).store_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((MM_M0001)o).store_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASStoreCode = new AutoSuggestTextViewModel<dynamic>(StoreList, TheFilter, SuggestedValue, "store_code", true);
                ASStoreCode.AutoSuggestVM.IsEmptyValueAllowed = true; ASStoreCode.AutoSuggestVM.IsFreeTextAllowed = false;
                if (StoreList.Count == 1)
                {
                    MasterEntity.store_code = StoreList[0].store_code;
                }
                else if (StoreList.Exists(x => x.store_code.Equals(MasterEntity.store_code)) == false || string.IsNullOrWhiteSpace(MasterEntity.store_code) == true)
                {
                    MasterEntity.store_code = null;
                }

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).shift_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).shift_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASShift = new AutoSuggestTextViewModel<dynamic>(MC.SHIFT_LIST, TheFilter, SuggestedValue, "shift_code", true);
                ASShift.AutoSuggestVM.IsEmptyValueAllowed = true; ASShift.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id);
                TheFilter = (o, prefix) => (((STD_PERSONNEL)o).emp_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PERSONNEL)o).emp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASEmployee = new AutoSuggestTextViewModel<dynamic>(MC.PERSONNEL_LIST, TheFilter, SuggestedValue, "emp_id", true);
                ASEmployee.AutoSuggestVM.IsEmptyValueAllowed = true; ASEmployee.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASStatus = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_status", true);
                ASStatus.AutoSuggestVM.IsEmptyValueAllowed = false; ASStatus.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((FICO_M0020)x).pc_code);
                TheFilter = (o, prefix) => (((FICO_M0020)o).pc_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((FICO_M0020)o).pc_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASProfitCenter = new AutoSuggestTextViewModel<dynamic>(MC.PROFIT_CENTER_LIST, TheFilter, SuggestedValue, "pc_code", true);
                ASProfitCenter.AutoSuggestVM.IsEmptyValueAllowed = true; ASProfitCenter.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((FICO_M0019)x).cc_code);
                TheFilter = (o, prefix) => (((FICO_M0019)o).cc_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((FICO_M0019)o).cc_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCostCenter = new AutoSuggestTextViewModel<dynamic>(MC.COST_CENTER_LIST, TheFilter, SuggestedValue, "cc_code", true);
                ASCostCenter.AutoSuggestVM.IsEmptyValueAllowed = true; ASCostCenter.AutoSuggestVM.IsFreeTextAllowed = false;


                List<ORDER_TYPE> OT_LIST = new List<ORDER_TYPE>();
                ORDER_TYPE OT = new ORDER_TYPE();
                OT.order_type = "N";
                OT.order_type_name = "New Order";
                OT_LIST.Add(OT);
                ORDER_TYPE OT2 = new ORDER_TYPE();
                OT2.order_type = "R";
                OT2.order_type_name = "Rework Order";
                OT_LIST.Add(OT2);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ORDER_TYPE)x).order_type);
                TheFilter = (o, prefix) => (((ORDER_TYPE)o).order_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ORDER_TYPE)o).order_type_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ORDER_TYPE = new AutoSuggestTextViewModel<dynamic>(OT_LIST, TheFilter, SuggestedValue, "order_type", true);
                AS_ORDER_TYPE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ORDER_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M051)x).control_key ?? "");
                TheFilter = (o, prefix) => (((SYS_M051)o).control_key ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((SYS_M051)o).control_key_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_CONTROL_KEY = new AutoSuggestTextViewModel<dynamic>(MC.CONTROL_KEY_LIST, TheFilter, SuggestedValue, "control_key", "control_key", true);
                AS_CONTROL_KEY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_CONTROL_KEY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).op_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).op_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).op_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_OPERATIONS = new AutoSuggestTextViewModel<dynamic>(MC.OPERATION_LIST, TheFilter, SuggestedValue, "op_code", "op_code", true);
                AS_OPERATIONS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_OPERATIONS.AutoSuggestVM.IsFreeTextAllowed = false;

                #endregion
                if (MC.DOC_TYPE_LIST_NEW.Count > 0)
                {
                    if (MC.DOC_TYPE_LIST_NEW.Where(x => x.doc_type == doc_cat_vm).ToList().Count > 0)
                    {
                        //MasterEntity.ind_batch = MC.DOC_TYPE_LIST_NEW.Where(x => x.doc_type == doc_cat_vm).ToList()[0].ind_batch; // NOTE: pending, A: Auto, M: Manual batch generation.
                        MasterEntity.ind_batch = "A";
                    }
                    else
                    {
                        MasterEntity.ind_batch = "A";
                    }

                    
                }

                ReferenceDocCollection = CollectionViewSource.GetDefaultView(MC.REF_DOC_LIST);
                ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);

                if (LOC_LIST_OBJ.Count == 1)
                {
                    MasterEntity.location_Id = LOC_LIST_OBJ[0].location_id;
                }
                else if (LOC_LIST_OBJ.Exists(x => x.location_id.Equals(MasterEntity.location_Id)) == false || string.IsNullOrWhiteSpace(MasterEntity.location_Id) == true)
                {
                    MasterEntity.location_Id = null;
                }
                

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        public void LoadInitialData(STD_LIST_BE STD_LIST_OBJ)
        {
            MC = new MC_PPC_BE();
            string Request = "LOAD_SO_FOR_PPC" + "!@" + AppSessionState.client + "!@" + STD_LIST_OBJ.comp_code + "!@" + STD_LIST_OBJ.location_id + "!@" + STD_LIST_OBJ.doc_cat + "!@" + STD_LIST_OBJ.doc_type + "!@" + STD_LIST_OBJ.ref_doc_no + "!@" + STD_LIST_OBJ.ref_doc_cat + "!@" + STD_LIST_OBJ.emp_id + "!@" + STD_LIST_OBJ.userid;
            MC = REPO_MC.GetDataWithReturnDomainObject<MC_PPC_BE>(MC, Request, "EPR_T001_BL", "PPC", "LoadAll", 0, "");

            GRID_COLLECTION = CollectionViewSource.GetDefaultView(MC.GRID_COLLECTION);

            if (MC.GRID_COLLECTION != null) // This will assign value to generate single order from method CreateDocument(STD_LIST_OBJECT) if bulk order creation then no need of this code.
            {
                if (MC.GRID_COLLECTION.Count >= 1)
                {
                    STD_LIST_OBJECT.item_code = MC.GRID_COLLECTION[0].item_code;
                    STD_LIST_OBJECT.item_name = MC.GRID_COLLECTION[0].item_name;
                    STD_LIST_OBJECT.tl_code = MC.GRID_COLLECTION[0].tl_code;
                }
            }
        }
        private void LoadDocumentByDocumentNumber(object InputValue)
        {
            try
            {
                EntityChangeEnable = false;
                SelectedTabControlIndex = 0;
                STD_LIST_BE POPUPEntityObject = null;
                SelectedReferenceDocuments = null;
                string Request,bom_value,routing_value;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BACK_FLIP_LIST.Where(x => x.order_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && InputValue.GetType() == typeof(STD_LIST_BE))
                {
                    POPUPEntityObject = (STD_LIST_BE)InputValue;
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    if (MasterEntity.comp_code != POPUPEntityObject.comp_code) // call when document loading of different company
                    {
                        LoadInitialData(POPUPEntityObject.comp_code, POPUPEntityObject.location_id);
                    }

                    SelectedReferenceDocuments = POPUPEntityObject.id.ToString();
                    Request = "LOAD_DOC_PPC_PMM" + "!@" + AppSessionState.client + "!@" + POPUPEntityObject.comp_code + "!@" + POPUPEntityObject.location_id + "!@" + POPUPEntityObject.doc_cat + "!@" + POPUPEntityObject.doc_type + "!@" + POPUPEntityObject.doc_no;
                    MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_PPC_BE>(MC_TEMP, Request, "EPR_T001_BL", "PPC", " ", 0, "");

                    

                    if (MC_TEMP.ORDER_LIST.Count > 0)
                    {

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).routing_no);
                        TheFilter = (o, prefix) => (((STD_LIST_BE)o).doc_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASRouting = new AutoSuggestTextViewModel<dynamic>(MC_TEMP.ROUTING_LIST, TheFilter, SuggestedValue, "routing_no", true);
                        ASRouting.AutoSuggestVM.IsEmptyValueAllowed = true; ASRouting.AutoSuggestVM.IsFreeTextAllowed = false;

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).bom_no);
                        TheFilter = (o, prefix) => (((STD_LIST_BE)o).bom_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASBOM = new AutoSuggestTextViewModel<dynamic>(MC_TEMP.BOM_LIST, TheFilter, SuggestedValue, "bom_no", true);
                        ASBOM.AutoSuggestVM.IsEmptyValueAllowed = true; ASBOM.AutoSuggestVM.IsFreeTextAllowed = false;

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).equip_no);
                        TheFilter = (o, prefix) => (((STD_LIST_BE)o).equip_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).equip_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).serial_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        AS_ASSET = new AutoSuggestTextViewModel<dynamic>(MC_TEMP.ASSET_LIST, TheFilter, SuggestedValue, "equip_no", true);
                        AS_ASSET.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ASSET.AutoSuggestVM.IsFreeTextAllowed = false;

                        MasterEntity = MC_TEMP.ORDER_LIST[0];
                        EPR_T001_A_OBJ_OC = MC_TEMP.OperationEntity;
                        //EPR_T001_B_OBJ_OC = MC_TEMP.OperationEntity;
                        bom_value = MasterEntity.bom_no;
                        routing_value = MasterEntity.routing_no;

                        MasterEntity.bom_no= bom_value;
                        MasterEntity.routing_no= routing_value;

                        MC.ApprovalData = MC_TEMP.ApprovalData;
                        MC.SO_LIST = MC_TEMP.SO_LIST;
                        MC.QN_LIST = MC_TEMP.QN_LIST;
                        MC.SN_LIST = MC_TEMP.SN_LIST;
                        MC.GM_LIST = MC_TEMP.GM_LIST;
                        MC.EQUIPMENT_LIST = MC_TEMP.EQUIPMENT_LIST;
                        MC.PMM_LIST = MC_TEMP.PMM_LIST;
                        MC.DN_LIST = MC_TEMP.DN_LIST;
                        MC.INVOICE_LIST = MC_TEMP.INVOICE_LIST;

                        LoadClassification(""); // load Classification data once master entity exists.
                    }

                }
                MasterEntity.ts_code = ts_code_vm;
                MasterEntity.userid = AppSessionState.UserID;
                MasterEntity.user_source1 = AppSessionState.UserSource1;
                MasterEntity.user_source2 = AppSessionState.UserSource2;
                isNewRecord = false;
                EntityChangeEnable = true;
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }

        private void LoadClassification(string request)
        {
            try
            {
                if (MC.GEN_CHAR_VALUE_LIST != null)
                {
                    if (MC.GEN_CHAR_VALUE_LIST.Count > 0)
                    {
                        string Request = "LOAD_DOCUMENT" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.order_no;
                        MC_STD = REPO_STD.GetDataWithReturnDomainObject<STD_MC_BE>(MC_STD, Request, "GEN_T021_BL", "GEN","LoadAll", 0, "");
                        CLASS_OCL = MC_STD.GEN_CHAR_VALUE_LIST;

                        if (CLASS_OCL == null)
                        {
                            if (MC.GEN_CHAR_VALUE_LIST.Count > 0)
                            {
                                CLASS_OCL = MC.GEN_CHAR_VALUE_LIST;
                            }
                        }
                        else if(CLASS_OCL.Count == 0)
                        {
                            if (MC.GEN_CHAR_VALUE_LIST.Count > 0)
                            {
                                CLASS_OCL = MC.GEN_CHAR_VALUE_LIST;
                            }
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InitializeCommands()
        {
            cmdExecuteReferenceDocuments = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteReferenceDocuments(items); });
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEventCall(items); });
            cmdReferenceDocumentSelection = new RelayCommand<object>(items => { if (items == null) { return; } CollectSelectedReferenceDocuments(items); });
            cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items); });
            cmdLoadBackFlipData = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items); });
            cmdSelectionChanged_EPR_T001_A = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_EPR_T001_A(items); });
            cmdOperation = new RelayCommand<object>(items => { if (items == null) { return; } InsertOperation(items); });
            cmdInsertItemCode = new RelayCommand<object>(items => { if (items == null) { return; } InsertItemCode(items); });
            cmdInsertStoreCode = new RelayCommand<object>(items => { if (items == null) { return; } InsertStoreCode(items); });
            cmdOperationEntityRowDelete = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteOperationEntityRow(cmdPara); });
            cmdInsertRouting = new RelayCommand<object>(items => { if (items == null) { return; } InsertRouting(items); });
            cmdComponantView = new RelayCommand<EPR_T001>(items => { if (items == null) { return; } ComponantView(items); });
            cmdResourceView = new RelayCommand<EPR_T001_A>(items => { if (items == null) { return; } ResourceView(items); });
            cmdHistory = new RelayCommand<EPR_T001>(items => { if (items == null) { return; } HistoryReport(items); });
            cmdTrace = new RelayCommand<EPR_T001>(items => { if (items == null) { return; } TraceReport(items); });
            cmdLogReport = new RelayCommand<EPR_T001>(items => { if (items == null) { return; } LogReport(items); });
            //cmdInsertCompany = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCompany(cmdPara); });
            //cmdInsertLocation = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLocation(cmdPara); });
            cmdSelectRequestBulk = new RelayCommand<object>(items => { if (items == null) { return; } SelectedRequestBulk(items); });
            #region . Automation Command Initialization .
            cmdExecuteBulkOrders = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteBulkOrders(items); });
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            #endregion
        }
        private void DefaultValues()
        {
            try
            {
                EntityChangeEnable = true;
                isNewRecord = true;
                MasterEntity.doc_cat = this.doc_cat_vm;
                MasterEntity.doc_type = doc_type_vm;
                MasterEntity.order_type = "N";

                if (MC.STATUS_LIST != null)
                {
                    if (MC.STATUS_LIST.Count > 0)
                    {
                        MasterEntity.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
                        MasterEntity.t_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_display).FirstOrDefault();
                    }
                }
                
                MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                MasterEntity.active = true;
                MasterEntity.doc_date = DateTime.UtcNow;
                MasterEntity.start_dt = DateTime.UtcNow;
                MasterEntity.end_dt = DateTime.UtcNow;
                MasterEntity.sch_start_date = DateTime.UtcNow;
                MasterEntity.sch_end_date = DateTime.UtcNow;
                MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                MasterEntity.planning_plant = AppSessionState.OBJ_LOCATION.location_id;

                if (MC.STORE_LIST != null)
                {
                    if (MC.STORE_LIST.Count > 0)
                    {
                        List<MM_M0001> StoreList = (MC.STORE_LIST.Where(item => item.location_Id == MasterEntity.location_Id).ToList());
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0001)x).store_code);
                        TheFilter = (o, prefix) => (((MM_M0001)o).store_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((MM_M0001)o).store_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASStoreCode = new AutoSuggestTextViewModel<dynamic>(StoreList, TheFilter, SuggestedValue, "store_code", true);
                        ASStoreCode.AutoSuggestVM.IsEmptyValueAllowed = true; ASStoreCode.AutoSuggestVM.IsFreeTextAllowed = false;
                        if (StoreList.Count == 1)
                        {
                            MasterEntity.store_code = StoreList[0].store_code;
                        }
                        else if (StoreList.Exists(x => x.store_code.Equals(MasterEntity.store_code)) == false || string.IsNullOrWhiteSpace(MasterEntity.store_code) == true)
                        {
                            MasterEntity.store_code = null;
                        }
                    }
                }

                if (MC.GEN_CHAR_VALUE_LIST != null)
                {
                    if (MC.GEN_CHAR_VALUE_LIST.Count > 0)
                    {
                        CLASS_OCL = MC.GEN_CHAR_VALUE_LIST;
                    }
                }
                
                DateTime d = DateTime.UtcNow;
                d = d.AddMonths(-1);
                REQ_PARA_OBJ.from_date = d;
                REQ_PARA_OBJ.to_date = DateTime.UtcNow;
                REQ_PARA_OBJ.active = true;
                REQ_PARA_OBJ.comp_code = MasterEntity.comp_code;
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void Logging()
        {
            MasterEntity.ts_code = this.ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;

            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;

            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private bool Validation()
        {
            foreach (var o in EPR_T001_A_OBJ_OC)
            {
                int flag = 0;
                if (o.id == 0)
                {
                    foreach (var p in EPR_T001_A_OBJ_OC)
                    {
                        if (o.line_id == p.line_id && (o.operation_no?.ToString() ?? "") == (p.operation_no?.ToString() ?? ""))
                        {
                            flag++;
                        }
                    }
                    if (flag > 1)
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Duplicate Operation Sequence and number cannot be Allowed or 0 for the item {0} and Parameter {1}", o.line_id, o.operation_desc); sms.ShowMessage();
                        return false;
                    }
                }
                if (!o.line_id.HasValue || string.IsNullOrWhiteSpace(o.operation_no) || o.line_id == 0 || string.IsNullOrWhiteSpace(o.location_id))
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Operation Sequence and number cannot be null or 0 for the item {0} and Parameter {1}", o.line_id, o.operation_desc); sms.ShowMessage();
                    return false;
                }
            }
            if (EPR_T001_A_OBJ_OC == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Operation Data required.");
                showMessageService.ShowMessage();

                return false;
            }
            if (EPR_T001_A_OBJ_OC != null)
            {
                if (EPR_T001_A_OBJ_OC.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Operation Data required.");
                    showMessageService.ShowMessage();
                    return false;
                }

            }
            if (!MasterEntity.doc_date.HasValue)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Order Document Date required.");
                showMessageService.ShowMessage();

                return false;
            }
            if (!MasterEntity.start_dt.HasValue)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Start Date required.");
                showMessageService.ShowMessage();

                return false;
            }
            if (!MasterEntity.end_dt.HasValue)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Finish Date required.");
                showMessageService.ShowMessage();

                return false;
            }
            if (!MasterEntity.sch_start_date.HasValue)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Scheduled Start Date required.");
                showMessageService.ShowMessage();

                return false;
            }
            if (!MasterEntity.sch_end_date.HasValue)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Scheduled Finish Date required.");
                showMessageService.ShowMessage();

                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.routing_no) && MasterEntity.doc_cat == "OR")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("TaskList/Routing Information Is Required");
                showMessageService.ShowMessage();

                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.bom_no) && MasterEntity.doc_cat == "OR")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Bill of Material is Required");
                showMessageService.ShowMessage();

                return false;
            }
            if (MasterEntity.doc_type == null || MasterEntity.doc_type == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Order Type is Required");
                showMessageService.ShowMessage();

                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.store_code))
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Store Core is Required");
                showMessageService.ShowMessage();

                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.emp_id))
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Employee id is Required");
                showMessageService.ShowMessage();

                return false;
            }
            return true;
        }
        private void RemoveSelectedReferenceDocuments()
        {
            try
            {
                if (SelectedReferenceDocuments != null)
                {
                    List<string> DocList = SelectedReferenceDocuments.Split(',').ToList();
                    foreach (var item in DocList)
                    {
                        MC.REF_DOC_LIST.RemoveAll(X => X.ref_doc_no.ToString() == item);
                    }
                    ReferenceDocCollection = CollectionViewSource.GetDefaultView(MC.REF_DOC_LIST);
                    ReferenceDocCollection.Filter = new Predicate<object>(Filter_ReferenceDoc);
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void CollectSelectedReferenceDocuments(object InputValue)
        {
            try
            {
                STD_LIST_BE POPUPEntityObject = null;
                SelectedReferenceDocuments = null;
                string Request;
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.REF_DOC_LIST.Where(x => x.search_key1.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    SelectedReferenceDocuments = POPUPEntityObject.ref_doc_no.ToString();
                    MasterEntity.ref_doc_no = SelectedReferenceDocuments;
                    MasterEntity.ref_doc_type = POPUPEntityObject.ref_doc_cat;
                    MasterEntity.ItemCode = POPUPEntityObject.item_code;
                    MasterEntity.ItemName = POPUPEntityObject.item_name;
                    MasterEntity.equip_no = POPUPEntityObject.equip_no;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void SelectionChanged_EPR_T001_A(object InputValue)
        {
            try
            {
                EPR_T001_A_OBJ = (EPR_T001_A)InputValue;
            }
            catch (Exception ex) { }
        }
        private void SC_CLASS_OBJ(object InputValue)
        {
            try
            {
                if (InputValue != null && MC.CLASS_PROFILE_LIST != null)
                {
                    VALUE_COLLECTION = MC.CLASS_PROFILE_LIST.Where(x => x.char_code == (CLASS_OBJ.char_code ?? "")).ToList();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void LoadBackFlipData(object InputValue)
        {
            try
            {
                EntityChangeEnable = false;
                string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + REQ_PARA_OBJ.location_id + "!@" + doc_cat_vm + "!@" + (Utilities.NullIf(REQ_PARA_OBJ.doc_type) ?? doc_cat_vm) + "!@" + (Utilities.NullIf(REQ_PARA_OBJ.t_status) ?? "") + "!@" + REQ_PARA_OBJ.active + "!@" + (Utilities.NullIf(REQ_PARA_OBJ.emp_id) ?? AppSessionState.EmpId) + "!@" + Utilities.NullIf(REQ_PARA_OBJ.party_code) + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy");
                MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MC_TEMP, Request, "EPR_T001_BL", "PPC", "LoadAll", 0, "");
                MC.BACK_FLIP_LIST = MC_TEMP.BACK_FLIP_LIST;
                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC.BACK_FLIP_LIST.ToList());
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(Filter_BackFlip);
                EntityChangeEnable = true;
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }

        #endregion
        #region EntityChangeNotification Section
        void Model_MasterEntityChange(object sender, EventArgs e)
        {
            try
            {
                if (EntityChangeEnable == true)
                {

                    //if (sender.ToString() == "comp_code")
                    //{

                    //}
                    //if (sender.ToString() == "location_Id" && string.IsNullOrWhiteSpace(MasterEntity.location_Id) == false)
                    //{

                    //}
                    //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
        #region Command_Function
        private void ExecuteReferenceDocuments(object inputValue)
        {
            EntityChangeEnable = false;
            string ObjVlaue = (string)inputValue;
            string bom_value, routing_value;
            string Request = "EXE_REF_DOC" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + SelectedReferenceDocuments + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + ObjVlaue;
            MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_PPC_BE>(MC_TEMP, Request, "EPR_T001_BL", "PPC", " ", 0, "");

            if (MC_TEMP.MasterEntity.Count > 0)
            {
                MasterEntity = MC_TEMP.MasterEntity[0];
                EPR_T001_A_OBJ_OC = MC_TEMP.OperationEntity;
                bom_value = MasterEntity.bom_no;
                routing_value = MasterEntity.routing_no;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).routing_no);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).doc_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASRouting = new AutoSuggestTextViewModel<dynamic>(MC_TEMP.ROUTING_LIST, TheFilter, SuggestedValue, "routing_no", true);
                ASRouting.AutoSuggestVM.IsEmptyValueAllowed = true; ASRouting.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).bom_no);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).doc_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASBOM = new AutoSuggestTextViewModel<dynamic>(MC_TEMP.BOM_LIST, TheFilter, SuggestedValue, "bom_no", true);
                ASBOM.AutoSuggestVM.IsEmptyValueAllowed = true; ASBOM.AutoSuggestVM.IsFreeTextAllowed = true;

                MasterEntity.bom_no = bom_value;
                MasterEntity.routing_no = routing_value;

                STD_LIST_BE obj_Temp = MC.REF_DOC_LIST.Where(x => x.ref_doc_no.Equals(SelectedReferenceDocuments, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                MasterEntity.qty = obj_Temp.order_qty;
            }
            EntityChangeEnable = true;
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
        }
        private void ExecuteBulkOrders(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                if (MC.GRID_COLLECTION != null)
                {
                    if (MC.GRID_COLLECTION.Count > 0)
                    {
                        foreach (var item in MC.GRID_COLLECTION)
                        {
                            if (item.selected == true && string.IsNullOrWhiteSpace(item.order_no))
                            {
                                CreateDocumentinBackground(item);
                            }
                        }
                        LoadInitialData(STD_LIST_OBJECT); // After creation of orders this will get back updated infor for child popup model window.
                        //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Service Order(s) created successfully!", this.Title); sms.ShowMessage();
                    }

                }
                else
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Reference Document Number!", this.Title); sms.ShowMessage();
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void CreateDocumentinBackground(STD_LIST_BE STD_LIST_OBJ) // This is executed when Bulk auto order creation from Child WIndow.
        {
            try
            {
                string Request = "EXECUTE_DOCUMENT" + "!@" + AppSessionState.client + "!@" + STD_LIST_OBJ.comp_code + "!@" + STD_LIST_OBJ.location_id + "!@" + STD_LIST_OBJ.doc_cat + "!@" + STD_LIST_OBJ.doc_type + "!@" + STD_LIST_OBJ.ref_doc_no + "!@" + STD_LIST_OBJ.ref_doc_cat + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.UserID + "!@" + STD_LIST_OBJ.ts_code + "!@" + STD_LIST_OBJ.tl_code + "!@" + STD_LIST_OBJ.item_code + "!@" + STD_LIST_OBJ.barcode + "!@" + STD_LIST_OBJ.equip_no + "!@" + STD_LIST_OBJ.item_code_party;
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_PPC_BE>(MC, Request, "EPR_T001_BL", "PPC", "", 0, "");

                if (MC.MasterEntity.Count > 0)
                {
                    MasterEntity = MC.MasterEntity[0];
                    EPR_T001_A_OBJ_OC = MC.OperationEntity;
                    Logging();
                    MasterEntity.XDOC_A = obj.ObjectToXML(EPR_T001_A_OBJ_OC);
                    MasterEntity = REPO.SaveWithReturnDomainObject<EPR_T001>(MasterEntity, "EPR_T001_BL", "PPC");
                }
            }
            catch (Exception ex)
            {}
        }
        private void CreateDocument(STD_LIST_BE STD_LIST_OBJ) // This is executed when single auto order creation
        {
            try
            {
                string Request = "EXECUTE_DOCUMENT" + "!@" + AppSessionState.client + "!@" + STD_LIST_OBJ.comp_code + "!@" + STD_LIST_OBJ.location_id + "!@" + STD_LIST_OBJ.doc_cat + "!@" + STD_LIST_OBJ.doc_type + "!@" + STD_LIST_OBJ.ref_doc_no + "!@" + STD_LIST_OBJ.ref_doc_cat + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.UserID + "!@" + STD_LIST_OBJ.ts_code + "!@" + STD_LIST_OBJ.tl_code + "!@" + STD_LIST_OBJ.item_code + "!@" + STD_LIST_OBJ.barcode + "!@" + (STD_LIST_OBJ.equip_no ?? "") + "!@" + (STD_LIST_OBJ.item_code_party ?? "");
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_PPC_BE>(MC, Request, "EPR_T001_BL", "PPC", "", 0, "");

                if (MC.MasterEntity.Count > 0)
                {
                    MasterEntity = MC.MasterEntity[0];
                    EPR_T001_A_OBJ_OC = MC.OperationEntity;
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
                STD_LIST_BE POPUPEntityObject;
                ReflectionFunctionService objRef = new ReflectionFunctionService();
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = AppSessionState.client + "!@" + (MasterEntity.comp_code ?? SO_OBJ.comp_code) + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                else if (InputValue != null && InputValue.GetType() == typeof(STD_LIST_BE))
                {
                    POPUPEntityObject = (STD_LIST_BE)InputValue;
                    POPUPEntityObject.doc_no = POPUPEntityObject.order_no;
                    POPUPEntityObject.client = AppSessionState.client;
                    Request = "GET_TSCODE!@" + AppSessionState.client + "!@" + POPUPEntityObject.comp_code + "!@" + (POPUPEntityObject.order_no ?? "").ToString() + "!@" + POPUPEntityObject.doc_cat + "!@" + POPUPEntityObject.doc_type + "!@" + (POPUPEntityObject.order_no ?? "");
                    POPUPEntityObject.request = Request;
                    objRef.Invoke_Documet(POPUPEntityObject);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        private void WindowEventCall(object InputValue)
        {
            try
            {
                
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    //LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    // Added on 27/09/2023 for Testing order
                    if (STD_LIST_OBJECT != null)
                    {
                        //LoadInitialData(STD_LIST_OBJECT.comp_code, STD_LIST_OBJECT.location_id);
                        LoadDocumentByDocumentNumber(STD_LIST_OBJECT); // Added on 27/09/2023 for Testing order
                    }
                }
                else if (STD_LIST_OBJECT != null)
                {
                    if (STD_LIST_OBJECT.type_code == "SINGLE_PROCESS")
                    {
                        CreateDocument(STD_LIST_OBJECT);
                    }
                    else
                    {
                        LoadDocumentByDocumentNumber(STD_LIST_OBJECT); // Added on 27/09/2023 for Testing order
                    }
                }
                else
                {
                    DefaultValues();
                    MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                    MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
                    LoadInitialData(MasterEntity.comp_code, MasterEntity.location_Id);
                    DefaultValues();
                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertOperation(object InputValue)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;

                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.OPERATION_LIST.Where(x => x.op_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<PPC_M002>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    EPR_T001_A_OBJ.op_code = POPUPEntityObject.op_code;
                    EPR_T001_A_OBJ.operation_desc = POPUPEntityObject.op_name;
                }
                //else
                //{
                //    EPR_T001_A_OBJ.op_code = null;
                //    EPR_T001_A_OBJ.operation_desc = null;
                //}
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertItemCode(object InputValue)
        {
            try
            {
                string Request = "";
                STD_ITEM POPUPEntityObject = null;

                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.STD_ITEM_LIST.Where(x => x.item_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.item_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || (x.equip_no ?? "").Equals(Request, StringComparison.OrdinalIgnoreCase) == true || (x.equip_name ?? "").Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_ITEM>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_ITEM>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.ItemCode = POPUPEntityObject.item_code;
                    MasterEntity.ItemName = POPUPEntityObject.item_name;
                    MasterEntity.unit_code = POPUPEntityObject.unit_code;
                    MasterEntity.equip_no = POPUPEntityObject.equip_no;
                    MasterEntity.obj_no = POPUPEntityObject.item_code;

                    EntityChangeEnable = false;
                    string Request2 = "LoadData_For_Selected_ItemCode" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_type_vm + "!@" + MasterEntity.ItemCode;
                    MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_PPC_BE>(MC_TEMP, Request2, "EPR_T001_BL", "PPC", " ", 0, "");

                    MC.BOM_LIST = MC_TEMP.BOM_LIST;
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).bom_no);
                    TheFilter = (o, prefix) => (((STD_LIST_BE)o).bom_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).bom_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASBOM = new AutoSuggestTextViewModel<dynamic>(MC_TEMP.BOM_LIST, TheFilter, SuggestedValue, "bom_no", true);
                    ASBOM.AutoSuggestVM.IsEmptyValueAllowed = true; ASBOM.AutoSuggestVM.IsFreeTextAllowed = false;
                    if (MC_TEMP.BOM_LIST.Count == 1)
                    {
                        MasterEntity.bom_no = MC_TEMP.BOM_LIST[0].bom_no;
                    }
                    else if (MC_TEMP.BOM_LIST.Exists(x => x.bom_no.Equals(MasterEntity.bom_no)) == false || string.IsNullOrWhiteSpace(MasterEntity.location_Id) == true)
                    {
                        MasterEntity.bom_no = null;
                    }

                    MC.ROUTING_LIST = MC_TEMP.ROUTING_LIST;
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).routing_no);
                    TheFilter = (o, prefix) => (((STD_LIST_BE)o).doc_no ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                    ASRouting = new AutoSuggestTextViewModel<dynamic>(MC_TEMP.ROUTING_LIST, TheFilter, SuggestedValue, "routing_no", true);
                    ASRouting.AutoSuggestVM.IsEmptyValueAllowed = true; ASRouting.AutoSuggestVM.IsFreeTextAllowed = true;
                    if (MC_TEMP.ROUTING_LIST.Count == 1)
                    {
                        MasterEntity.routing_no = MC_TEMP.ROUTING_LIST[0].doc_no;

                        string Request3 = "Load_Operations_For_Selected_Routing" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_type_vm + "!@" + MasterEntity.routing_no;
                        MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_PPC_BE>(MC_TEMP, Request3, "EPR_T001_BL", "PPC", " ", 0, "");

                        if (MC_TEMP.OperationEntity != null && isNewRecord==true)
                        {
                            if (MC_TEMP.OperationEntity.Count > 0)
                            {
                                foreach(EPR_T001_A item in MC_TEMP.OperationEntity)
                                {
                                    //EPR_T001_A_OBJ_OC = MC_TEMP.OperationEntity;
                                    EPR_T001_A_OBJ_OC.Add(item);
                                }
                                
                            }
                        }
                    }
                    else if (MC_TEMP.ROUTING_LIST.Exists(x => x.doc_no.Equals(MasterEntity.routing_no)) == false || string.IsNullOrWhiteSpace(MasterEntity.routing_no) == true)
                    {
                        MasterEntity.routing_no = null;
                    }


                    EntityChangeEnable = true;
                }
                //else
                //{
                //    //IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Selected Item Not exists", this.Title); sms.ShowMessage();
                //    MasterEntity.ItemCode = null;
                //    MasterEntity.ItemName = null;
                //}
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        
        private void DeleteOperationEntityRow(object InputValue)
        {
            try
            {
                if (EPR_T001_A_OBJ_OC != null && EPR_T001_A_OBJ != null)
                {
                    if (EPR_T001_A_OBJ.id == 0)
                    {
                        EPR_T001_A_OBJ_OC.Remove(EPR_T001_A_OBJ);
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertStoreCode(object InputValue)
        {
            try
            {
                string Request = "";
                MM_M0001 POPUPEntityObject = null;

                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            List<MM_M0001> StoreList = (MC.STORE_LIST.Where(item => item.location_Id == MasterEntity.location_Id).ToList());
                            POPUPEntityObject = StoreList.Where(x => x.store_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<MM_M0001>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M0001>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.store_code = POPUPEntityObject.store_code;
                }
                //else
                //{
                //    //IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Selected Storeage Location not exists.", this.Title); sms.ShowMessage();
                //    MasterEntity.store_code = null;
                //}
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertRouting(object InputValue)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.ROUTING_LIST.Where(x => x.doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (MasterEntity.routing_no != POPUPEntityObject.doc_no || EPR_T001_A_OBJ_OC.Count == 0)
                    {
                        MasterEntity.routing_no = POPUPEntityObject.doc_no;

                        EntityChangeEnable = false;
                        string Request2 = "Load_Operations_For_Selected_Routing" + "!@" + AppSessionState.client.ToString() + "!@" + AppSessionState.OBJ_COMPANY.comp_code.ToString() + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + MasterEntity.routing_no;
                        MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_PPC_BE>(MC_TEMP, Request2, "EPR_T001_BL", "PPC", " ", 0, "");

                        if (MC_TEMP.OperationEntity != null)
                        {
                            if (MC_TEMP.OperationEntity.Count > 0)
                            {
                                EPR_T001_A_OBJ_OC = MC_TEMP.OperationEntity;
                            }
                        }
                    }
                    EntityChangeEnable = true;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void HistoryReport(EPR_T001 ParameterObject)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(MasterEntity.order_no))
                {
                    CursorControl.SetBusyState();

                    string RequestParameter = "ORDER_HISTORY" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.order_no ;
                    MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_PPC_BE>(MC_TEMP, RequestParameter, "EPR_T001_BL", "PPC", " ", 0, "");

                    REQ_PARA_OBJ.obj_code = "RP0001"; //MIS_OBJ.obj_code
                    REQ_PARA_OBJ.obj_name = "Maintainance History"; //MIS_OBJ.obj_name
                    REQ_PARA_OBJ.comp_name = MC.COMPANY_LIST.Where(x => x.comp_code == MasterEntity.comp_code).ToList()[0].comp_name;
                    object[] objDataSource = new object[4];
                    string[] objDataSourceName = new string[4];

                    objDataSource[0] = MC_TEMP.STD_MIS_LIST;
                    objDataSource[1] = MC_TEMP.STD_MIS_LIST2;
                    objDataSource[2] = MC_TEMP.STD_MIS_LIST3;
                    objDataSource[3] = MC_TEMP.STD_MIS_LIST4;
                    objDataSourceName[0] = "dsMIS_1";
                    objDataSourceName[1] = "dsConfirmation";
                    objDataSourceName[2] = "dsReservation";
                    objDataSourceName[3] = "dsConsumption";

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORTS_STD\\MIS\\PMM_M001.rdlc", "");

                }
                else
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Order document number required!"); sms.ShowMessage();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void TraceReport(EPR_T001 ParameterObject)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(MasterEntity.order_no))
                {
                    CursorControl.SetBusyState();

                    string RequestParameter = "TRACE_REPORT" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + (MasterEntity.location_Id ?? "") + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.equip_no + "!@" + MasterEntity.order_no;
                    MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_PPC_BE>(MC_TEMP, RequestParameter, "EPR_T001_BL", "PPC", " ", 0, "");

                    REQ_PARA_OBJ.obj_code = "RP0002"; //MIS_OBJ.obj_code
                    REQ_PARA_OBJ.obj_name = "Material History for  " + (MasterEntity.ItemName ?? ""); //MIS_OBJ.obj_name
                    REQ_PARA_OBJ.comp_name = MC.COMPANY_LIST.Where(x => x.comp_code == MasterEntity.comp_code).ToList()[0].comp_name;
                    object[] objDataSource = new object[1];
                    string[] objDataSourceName = new string[1];

                    objDataSource[0] = MC_TEMP.STD_MIS_LIST;
                    objDataSourceName[0] = "dsMIS_1";

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORTS_STD\\MIS\\PMM_M002.rdlc", "");

                }
                else
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Order document number required!"); sms.ShowMessage();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void LogReport(EPR_T001 ParameterObject)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(MasterEntity.order_no))
                {
                    CursorControl.SetBusyState();

                    string RequestParameter = "LOG_REPORT" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.equip_no + "!@" + MasterEntity.order_no;
                    MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_PPC_BE>(MC_TEMP, RequestParameter, "EPR_T001_BL", "PPC", " ", 0, "");

                    REQ_PARA_OBJ.obj_code = "RP0003"; //MIS_OBJ.obj_code
                    REQ_PARA_OBJ.obj_name = "Log Book for  " + (MasterEntity.ItemName ?? ""); //MIS_OBJ.obj_name
                    REQ_PARA_OBJ.comp_name = MC.COMPANY_LIST.Where(x => x.comp_code == MasterEntity.comp_code).ToList()[0].comp_name;
                    object[] objDataSource = new object[1];
                    string[] objDataSourceName = new string[1];

                    objDataSource[0] = MC_TEMP.STD_MIS_LIST;
                    objDataSourceName[0] = "dsMIS_1";

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORTS_STD\\MIS\\PMM_M003.rdlc", "");

                }
                else
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Order document number required!"); sms.ShowMessage();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        //private void InsertCompany(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ADM_M0002 POPUPEntityObject = null;
        //        #region Command Parameter Read Section
        //        try
        //        {
        //            if (InputValue.GetType() == typeof(string) && InputValue != null)
        //            {
        //                Request = InputValue.ToString();
        //                if (Request.Length > 0)
        //                {
        //                    try
        //                    { POPUPEntityObject = MC.COMPANY_LIST.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                    catch (Exception ex) { }
        //                }
        //            }
        //            else if (InputValue != null)
        //            {
        //                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0002>().ToList()[0];
        //            }
        //        }
        //        catch (Exception ex) { }

        //        #endregion
        //        if (POPUPEntityObject != null)
        //        {
        //            //if (MasterEntity.comp_code != POPUPEntityObject.comp_code)
        //            //{
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;
        //            LoadInitialData(MasterEntity.comp_code, MasterEntity.location_Id);
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;

        //            string loc_value = MasterEntity.location_Id;
        //            List<ADM_M0003> LOC_LIST_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == MasterEntity.comp_code).ToList();
        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
        //            TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //            AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_id", true);
        //            AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = true;
        //            MasterEntity.location_Id = loc_value;

        //            if (LOC_LIST_OBJ.Count == 1)
        //            {
        //                MasterEntity.location_Id = LOC_LIST_OBJ[0].location_id;

        //                List<MM_M0001> StoreList = (MC.STORE_LIST.Where(item => item.location_Id == MasterEntity.location_Id).ToList());
        //                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0001)x).store_code);
        //                TheFilter = (o, prefix) => (((MM_M0001)o).store_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((MM_M0001)o).store_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //                ASStoreCode = new AutoSuggestTextViewModel<dynamic>(StoreList, TheFilter, SuggestedValue, "store_code", true);
        //                ASStoreCode.AutoSuggestVM.IsEmptyValueAllowed = true; ASStoreCode.AutoSuggestVM.IsFreeTextAllowed = false;
        //                if (StoreList.Count == 1)
        //                {
        //                    MasterEntity.store_code = StoreList[0].store_code;
        //                }
        //                else if (StoreList.Exists(x => x.store_code.Equals(MasterEntity.store_code)) == false || string.IsNullOrWhiteSpace(MasterEntity.store_code) == true)
        //                {
        //                    MasterEntity.store_code = null;
        //                }
        //            }
        //            else
        //            {
        //                MasterEntity.location_Id = null;
        //            }
        //            string loc_value2 = MasterEntity.planning_plant;
        //            List<ADM_M0003> LOC_LIST_OBJ2 = MC.LOCATION_LIST.Where(item => item.comp_code == MasterEntity.comp_code).ToList();
        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
        //            TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //            AS_LOCATION_PLAN = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ2, TheFilter, SuggestedValue, "location_id", true);
        //            AS_LOCATION_PLAN.AutoSuggestVM.IsEmptyValueAllowed = true; AS_LOCATION_PLAN.AutoSuggestVM.IsFreeTextAllowed = false;
        //            MasterEntity.planning_plant = loc_value2;
        //        }
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
        //    }
        //}
        //private void InsertLocation(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ADM_M0003 POPUPEntityObject = null;
        //        #region Command Parameter Read Section
        //        try
        //        {
        //            if (InputValue.GetType() == typeof(string) && InputValue != null)
        //            {
        //                Request = InputValue.ToString();
        //                if (Request.Length > 0)
        //                {
        //                    try
        //                    { POPUPEntityObject = MC.LOCATION_LIST.Where(x => x.location_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                    catch (Exception ex) { }
        //                }
        //            }
        //            else if (InputValue != null)
        //            {
        //                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0003>().ToList()[0];
        //            }
        //        }
        //        catch (Exception ex) { }

        //        #endregion
        //        if (POPUPEntityObject != null)
        //        {
        //            MasterEntity.location_Id = POPUPEntityObject.location_id;

        //            List<MM_M0001> StoreList = (MC.STORE_LIST.Where(item => item.location_Id == MasterEntity.location_Id).ToList());
        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0001)x).store_code);
        //            TheFilter = (o, prefix) => (((MM_M0001)o).store_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((MM_M0001)o).store_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //            ASStoreCode = new AutoSuggestTextViewModel<dynamic>(StoreList, TheFilter, SuggestedValue, "store_code", true);
        //            ASStoreCode.AutoSuggestVM.IsEmptyValueAllowed = true; ASStoreCode.AutoSuggestVM.IsFreeTextAllowed = false;
        //            if (StoreList.Count == 1)
        //            {
        //                MasterEntity.store_code = StoreList[0].store_code;
        //            }
        //            else if (StoreList.Exists(x => x.store_code.Equals(MasterEntity.store_code)) == false || string.IsNullOrWhiteSpace(MasterEntity.store_code) == true)
        //            {
        //                MasterEntity.store_code = null;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
        //    }
        //}
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("prepare_by", Convert.ToString(AppSessionState.Name));
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>();
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();

            }
            return result;
        }
        private void ComponantView(EPR_T001 ParameterObject)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(MasterEntity.order_no))
                {
                    CursorControl.SetBusyState();
                    AppSessionState.ViewTitle = "Componant Assignment";
                    AppSessionState.TransactionCode = "MS22";

                    STD_LIST_BE STD_OBJ = new STD_LIST_BE();
                    STD_OBJ.comp_code = MasterEntity.comp_code;
                    STD_OBJ.location_id = MasterEntity.location_Id;
                    STD_OBJ.doc_cat = "RR";
                    STD_OBJ.doc_type = "RR";
                    STD_OBJ.order_no = MasterEntity.order_no;
                    STD_OBJ.ref_doc_cat = MasterEntity.doc_cat;
                    STD_OBJ.ref_doc_type = MasterEntity.doc_type;
                    STD_OBJ.ref_doc_no = MasterEntity.order_no;
                    STD_OBJ.ref_row_id = MasterEntity.id;
                    STD_OBJ.item_code = MasterEntity.ItemCode;
                    STD_OBJ.mov_tp = "114";
                    STD_OBJ.request_type = "RESERVATION";
                    STD_OBJ.request = "PT_RES";
                    STD_OBJ.project_id = MasterEntity.project_id;
                    STD_OBJ.element_id = MasterEntity.element_id;
                    STD_OBJ.store_code = MasterEntity.store_code;
                    STD_OBJ.bom_no = MasterEntity.bom_no;
                    //STD_OBJ.bom_item_row_id = MasterEntity.bom_item_row_id;
                    // NOTE: Need to fix
                    //STD_OBJ.order_item_row_id = MasterEntity.order_item_row_id;
                    //STD_OBJ.bom_exp_no = MasterEntity.bom_exp_no;

                    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.MM.dll");
                    Assembly assembly = Assembly.LoadFile(path1);
                    Type type = assembly.GetType("Reflection.Modules.MM.Views.MM_T013");
                    if (type != null)
                    {
                        dynamic instance = Activator.CreateInstance(type, "MS22", "RR", STD_OBJ);
                        SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                    }
                }
                else
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Order document number required to assign Componants!"); sms.ShowMessage();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        private void ResourceView(EPR_T001_A ParameterObject)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(MasterEntity.order_no))
                {
                    CursorControl.SetBusyState();
                    AppSessionState.ViewTitle = "Resources";
                    AppSessionState.TransactionCode = "MS23";

                    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.MM.dll");
                    Assembly assembly = Assembly.LoadFile(path1);
                    Type type = assembly.GetType("Reflection.Modules.MM.Views.MM_T015");
                    if (type != null)
                    {
                        dynamic instance = Activator.CreateInstance(type, "MS23", "00", ParameterObject);
                        SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                    }
                }
                else
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Order document number required to assign Componants!"); sms.ShowMessage();
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        #endregion
        #region FilterMethods
        // Filter BackFlip
        private string _FLTR_STR_BACKFLIP;
        public string FLTR_STR_BACKFLIP
        {
            get { return _FLTR_STR_BACKFLIP; }
            set
            {
                _FLTR_STR_BACKFLIP = value;
                RaisePropertyChanged("FLTR_STR_BACKFLIP");
                FilterCollection_BackFlip();
            }
        }
        private void FilterCollection_BackFlip()
        {
            if (_BACKFLIP_COLLECTION != null)
            {
                _BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool Filter_BackFlip(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FLTR_STR_BACKFLIP))
                {
                    return (data.order_no != null && data.order_no.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                           (data.location_id != null && data.location_id.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                           (data.item_code != null && data.item_code.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                           (data.item_name != null && data.item_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                           (data.date_start.ToString() != null && data.date_start.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                           (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                           (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                           //(data.routing_no != null && data.routing_no.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                           //(data.emm_id != null && data.emm_id.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                           (data.t_display != null && data.t_display.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower()));
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
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_ReferenceDoc))
                {
                    return (data.order_no != null && data.order_no.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.doc_date.ToString() != null && data.doc_date.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           (data.title ?? "").ToString() != null && (data.title ?? "").ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.location_id != null && data.location_id.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.item_code != null && data.item_code.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.item_name != null && data.item_name.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.doc_type_name != null && data.doc_type_name.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower()) ||
                           data.order_no != null && data.order_no.ToString().ToLower().Contains(_FilterString_ReferenceDoc.ToLower())
                       );
                }
                return true;
            }
            return false;
        }

        // Filter Order Chart
        private string _FilterString_Order_Chart;
        public string FilterString_Order_Chart
        {
            get { return _FilterString_Order_Chart; }
            set
            {
                _FilterString_Order_Chart = value;
                RaisePropertyChanged("FilterString_Order_Chart");
                FilterCollection_Order_Chart();
            }
        }
        private void FilterCollection_Order_Chart()
        {
            if (_ProductionOrderChart != null)
            {
                _ProductionOrderChart.Refresh();
            }
        }
        public bool Filter_Order_Chart(object obj)
        {
            var data = obj as EPR_T001;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_Order_Chart))
                {
                    return (data.order_no != null && data.order_no.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.doc_date.ToString() != null && data.doc_date.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.planning_plant != null && data.planning_plant.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.routing_no != null && data.routing_no.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.bom_no != null && data.bom_no.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.t_status != null && data.t_status.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.t_display != null && data.t_display.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.start_dt.ToString() != null && data.start_dt.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower()) ||
                           data.end_dt.ToString() != null && data.end_dt.ToString().ToLower().Contains(_FilterString_Order_Chart.ToLower())
                       );
                }
                return true;
            }
            return false;
        }


        #endregion

        #region Collection Change Event
        private void CollectionChangedNotifyForOperationEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {

                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (EPR_T001_A item in e.NewItems)
                    {
                        item.line_id = EPR_T001_A_OBJ_OC.Count;
                        item.userid = AppSessionState.UserID;
                        item.add_date = System.DateTime.Now;
                        item.comp_code = MasterEntity.comp_code;
                        item.doc_cat = "AT";
                        item.doc_type = "AT";
                        item.client = AppSessionState.client;
                        item.t_status = "01";
                        item.plan_no = EPR_T001_A_OBJ.bom_no;
                        item.task_list_type = "R";
                        item.active = true;
                        item.group_counter = "1";
                        item.id = 0;
                        item.no_of_emp = 1;
                        //item.operation_row_id = "R"; // Fetch from New Order data for rework order.
                        item.operation_no = (item.operation_no ?? (EPR_T001_A_OBJ_OC.Count * 10).ToString());
                        item.op_seq = EPR_T001_A_OBJ_OC.Count;
                        item.order_no = EPR_T001_A_OBJ.order_no;
                        item.plan_counter = 1;
                        //item.ref_line_id = EPR_T001_A_OBJ.order_no; // Fetch from New Order data for rework order.
                        item.scrap_factor = 0;


                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {

                }
            }
            catch (Exception ex)
            { }
        }
        #endregion
    }
}