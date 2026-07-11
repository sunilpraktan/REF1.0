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
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.PMS;
//using Reflection.BusinessEntity.PMS.ViewModels;
using Reflection.BusinessEntity.ADM;
using System.Data;
using Reflection.BusinessEntity.FICO;
using Reflection.BusinessEntity.ReflectionSystem;
using System.Reflection;
using Reflection.Presentation.Core.VirtualDesktops;
using GalaSoft.MvvmLight.Ioc;
using System.IO;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Reflection.Modules.PMS.ViewModels
{
    public class PMS_T009_VM : WorkspaceViewModel<EPR_T001>, ITS_VIEW_MODEL
    {
        #region AutoSuggest Initialization

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _AS_PARTY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PARTY
        {
            get { return _AS_PARTY; }
            set
            {
                if (_AS_PARTY != value)
                {
                    _AS_PARTY = value; RaisePropertyChanged("AS_PARTY");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_STATUS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_STATUS
        {
            get { return _AS_STATUS; }
            set
            {
                if (_AS_STATUS != value)
                {
                    _AS_STATUS = value; RaisePropertyChanged("AS_STATUS");
                }
            }
        }

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
        private AutoSuggestTextViewModel<dynamic> _AS_EMPLOYEE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_EMPLOYEE
        {
            get { return _AS_EMPLOYEE; }
            set
            {
                if (_AS_EMPLOYEE != value)
                {
                    _AS_EMPLOYEE = value; RaisePropertyChanged("AS_EMPLOYEE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_COST_CENTER { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_COST_CENTER
        {
            get { return _AS_COST_CENTER; }
            set
            {
                if (_AS_COST_CENTER != value)
                {
                    _AS_COST_CENTER = value; RaisePropertyChanged("AS_COST_CENTER");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_PROFIT_CENTER { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PROFIT_CENTER
        {
            get { return _AS_PROFIT_CENTER; }
            set
            {
                if (_AS_PROFIT_CENTER != value)
                {
                    _AS_PROFIT_CENTER = value; RaisePropertyChanged("AS_PROFIT_CENTER");
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
        private AutoSuggestTextViewModel<dynamic> _AS_OPERATION { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_OPERATION
        {
            get { return _AS_OPERATION; }
            set
            {
                if (_AS_OPERATION != value)
                {
                    _AS_OPERATION = value; RaisePropertyChanged("AS_OPERATION");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_UOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM
        {
            get { return _AS_UOM; }
            set
            {
                if (_AS_UOM != value)
                {
                    _AS_UOM = value; RaisePropertyChanged("AS_UOM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_UOM_WORK { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM_WORK
        {
            get { return _AS_UOM_WORK; }
            set
            {
                if (_AS_UOM_WORK != value)
                {
                    _AS_UOM_WORK = value; RaisePropertyChanged("AS_UOM_WORK");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_UOM_WORK_DUR { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM_WORK_DUR
        {
            get { return _AS_UOM_WORK_DUR; }
            set
            {
                if (_AS_UOM_WORK_DUR != value)
                {
                    _AS_UOM_WORK_DUR = value; RaisePropertyChanged("AS_UOM_WORK_DUR");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_PRIORITY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PRIORITY
        {
            get { return _AS_PRIORITY; }
            set
            {
                if (_AS_PRIORITY != value)
                {
                    _AS_PRIORITY = value; RaisePropertyChanged("AS_PRIORITY");
                }
            }
        }
        #endregion

        #region Variable Declaration

        WebServiceRepository<EPR_T001> REPO = new WebServiceRepository<EPR_T001>();
        WebServiceRepository<MC_PMS_BE> REPO_MC = new WebServiceRepository<MC_PMS_BE>();
        ObjectSerializationService SER_OBJ = new ObjectSerializationService();

        private bool _isNewRecord { get; set; }
        public bool isNewRecord
        {
            get { return _isNewRecord; }
            set
            {
                if (_isNewRecord != value)
                {
                    _isNewRecord = value; RaisePropertyChanged("isNewRecord");
                }
            }
        }
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }
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
        IShowMessageViewService sms;

        private MC_PMS_BE _MC = new MC_PMS_BE();
        public MC_PMS_BE MC
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

        private MC_PMS_BE _MC_TEMP = new MC_PMS_BE();
        public MC_PMS_BE MC_TEMP
        {
            get { return _MC_TEMP; }
            set
            {
                if (_MC_TEMP != value)
                {
                    _MC_TEMP = value; RaisePropertyChanged("MC_TEMP");

                }
            }

        }

        private STD_REQ_PARA_BE _REQ_PARA_OBJ;
        public STD_REQ_PARA_BE REQ_PARA_OBJ
        {
            get
            {
                return _REQ_PARA_OBJ;
            }
            set
            {
                if (_REQ_PARA_OBJ != value)
                {
                    _REQ_PARA_OBJ = value;
                    RaisePropertyChanged(nameof(REQ_PARA_OBJ));
                }
            }
        }

        private int _MainTabIndex;
        public int MainTabIndex
        {
            get { return _MainTabIndex; }
            set
            {
                if (_MainTabIndex != value)
                {
                    _MainTabIndex = value;
                    RaisePropertyChanged("MainTabIndex");
                }
            }
        }

        private EPR_T001_A _MasterEntity;
        public EPR_T001_A MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                }
            }
        }
        
        private EPR_T001_B _DetailsEntity;
        public EPR_T001_B DetailsEntity
        {
            get { return _DetailsEntity; }
            set
            {
                if (_DetailsEntity != value)
                {
                    _DetailsEntity = value; RaisePropertyChanged("DetailsEntity");
                }
            }
        }
        private EPR_T001 _OrderEntity;
        public EPR_T001 OrderEntity
        {
            get { return _OrderEntity; }
            set
            {
                if (_OrderEntity != value)
                {
                    _OrderEntity = value; RaisePropertyChanged("OrderEntity");
                }
            }
        }

        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }

        private STD_LIST_BE _BACKFLIP_OBJ;
        public STD_LIST_BE BACKFLIP_OBJ
        {
            get
            {
                return _BACKFLIP_OBJ;
            }
            set
            {
                if (_BACKFLIP_OBJ != value)
                {
                    _BACKFLIP_OBJ = value;
                    RaisePropertyChanged(nameof(BACKFLIP_OBJ));
                }
            }
        }
        private STD_LIST_BE _CTR_PARA_OBJ;
        public STD_LIST_BE CTR_PARA_OBJ
        {
            get
            {
                return _CTR_PARA_OBJ;
            }
            set
            {
                if (_CTR_PARA_OBJ != value)
                {
                    _CTR_PARA_OBJ = value;
                    RaisePropertyChanged(nameof(CTR_PARA_OBJ));
                }
            }
        }
        private STD_LIST_BE _SELECTED_TV_OBJ;
        public STD_LIST_BE SELECTED_TV_OBJ
        {
            get
            {
                return _SELECTED_TV_OBJ;
            }
            set
            {
                if (_SELECTED_TV_OBJ != value)
                {
                    _SELECTED_TV_OBJ = value;
                    RaisePropertyChanged(nameof(SELECTED_TV_OBJ));
                }
            }
        }

        #endregion
        public string Name
        {
            get
            {
                return "Home Page";
            }
        }
        private STD_LIST_BE _doc_info_para = new STD_LIST_BE();
        public STD_LIST_BE doc_info_para
        {
            get { return _doc_info_para; }
            set
            {
                if (_doc_info_para != value)
                {
                    _doc_info_para = value; RaisePropertyChanged("doc_info_para");

                }
            }

        }
        private EPR_T001_C _DEP_OBJ;
        public EPR_T001_C DEP_OBJ
        {
            get
            {
                return _DEP_OBJ;
            }
            set
            {
                if (_DEP_OBJ != value)
                {
                    _DEP_OBJ = value;
                    RaisePropertyChanged(nameof(DEP_OBJ));
                }
            }
        }
        private ObservableCollection<EPR_T001_C> _DependencyItem;
        public ObservableCollection<EPR_T001_C> DependencyItem
        {
            get
            {
                return _DependencyItem;
            }
            set
            {
                if (_DependencyItem != value)
                {
                    _DependencyItem = value;
                    DependencyItem.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CCNotifyItem);
                    RaisePropertyChanged("DependencyItem");
                }
            }
        }

        private IEnumerable _TSK_ACT_COL;
        public IEnumerable TSK_ACT_COL
        {
            get { return _TSK_ACT_COL; }
            set
            {
                _TSK_ACT_COL = value;

                RaisePropertyChanged("TSK_ACT_COL");
            }
        }
        #region Model Entity Update
        void ModelUpdated_Master(object sender, EventArgs e)
        {
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
        }

        #endregion
        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<STD_LIST_BE> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInsertLocation { get; private set; }
        public RelayCommand<object> cmdInsertStatus { get; private set; }
        public RelayCommand<object> cmdInsertEmployee { get; private set; }
        public RelayCommand<STD_LIST_BE> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdCreate { get; private set; }
        public RelayCommand<object> cmdSave { get; private set; }
        public RelayCommand<object> cmdInsertOperation { get; private set; }
        public RelayCommand<object> cmdDocumentAttachment { get; private set; }

        //NOTE: cmdComponantView, incomplete funtion because we have made provision for MasterEntity of EPR_T001 to send as parameter and with the 
        //help of BOM & Routing we assign componants for all operation. to assign direct at operation level, we need to send Operation 
        //as parameter with order header details then we can use this function to assign componants at Order Heder level or 
        //Operation Level or at Project Phase level. need to send generic paramter and level input for which we need to assign componants.
        public RelayCommand<EPR_T001_A> cmdComponantView { get; private set; }
        public RelayCommand<EPR_T001_A> cmdResourceView { get; private set; }

        #endregion

        #region DefalutValue
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_cat = doc_cat_vm;
            MasterEntity.doc_type = doc_cat_vm;
            MasterEntity.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
            MasterEntity.t_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_display).FirstOrDefault();
            MasterEntity.emp_id = AppSessionState.EmpId;
            MasterEntity.emp_name = AppSessionState.EmpName;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.comp_code = CTR_PARA_OBJ.comp_code;
            MasterEntity.location_id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.order_no = OrderEntity.order_no;
            MasterEntity.active = true;

            if (MC.ACTIVITY_LIST != null)
            {
                if (MC.ACTIVITY_LIST.Count > 0)
                {
                    OrderEntity = MC.TASK_LIST[0];
                    string maxOp = MC.ACTIVITY_LIST.Max(t =>  Convert.ToInt32(t.operation_no)).ToString();
                    EPR_T001_A tempObj = MC.ACTIVITY_LIST.Where(x => x.operation_no == maxOp && x.order_no==CTR_PARA_OBJ.order_no).ToList()[0];
                    MasterEntity.operation_no = (Convert.ToInt32(maxOp) + Convert.ToInt32(10)).ToString();
                    MasterEntity.plan_counter = tempObj.plan_counter;
                    MasterEntity.task_list_type = tempObj.task_list_type;
                    MasterEntity.control_key = tempObj.control_key;
                    MasterEntity.group_counter = tempObj.group_counter;
                    MasterEntity.location_id = tempObj.location_id;
                    MasterEntity.op_seq = tempObj.op_seq + 1;
                    MasterEntity.line_id = tempObj.line_id + 1;
                    MasterEntity.no_of_emp = tempObj.no_of_emp;
                    MasterEntity.unit_code = tempObj.unit_code;
                    MasterEntity.plan_no = tempObj.plan_no;
                }
                else
                {
                    MasterEntity.operation_no = "10";
                    MasterEntity.plan_counter = 1;
                    MasterEntity.task_list_type = "R";
                    MasterEntity.control_key = "05";
                    MasterEntity.group_counter = "1";
                    MasterEntity.op_seq = 1;
                    MasterEntity.line_id = 1;
                    MasterEntity.no_of_emp = 1;
                }
                DetailsEntity.line_id_opr = MasterEntity.line_id;
            }
            DetailsEntity.sch_start = DateTime.Now;
            DetailsEntity.sch_end = DateTime.Now;
            DetailsEntity.forecast_start = DateTime.Now;
            DetailsEntity.forecast_end = DateTime.Now;
            DetailsEntity.actual_start = DateTime.Now;
            DetailsEntity.actual_end = DateTime.Now;


            MainTabIndex = 1;
        }
        private bool Validation()
        {
            try
            {
                if (MasterEntity.doc_type == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Please Select Document Type........");
                    showMessageService.ShowMessage();

                    return false;
                }
                if (DetailsEntity.sch_start.HasValue && OrderEntity.sch_start_date.HasValue)
                {
                    if (DetailsEntity.sch_start.Value.Date < OrderEntity.sch_start_date.Value.Date)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Scheduled Start Date should not less than Master Task Start Date!");
                        showMessageService.ShowMessage();

                        return false;
                    }
                }
                if (DetailsEntity.sch_end.HasValue && OrderEntity.sch_end_date.HasValue)
                {
                    if (DetailsEntity.sch_end.Value.Date > OrderEntity.sch_end_date.Value.Date)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Scheduled End Date should not exceed date of Master Task End Date!");
                        showMessageService.ShowMessage();

                        return false;
                    }
                    if (DetailsEntity.sch_end.Value.Date < OrderEntity.sch_start_date.Value.Date || DetailsEntity.sch_end.Value.Date < DetailsEntity.sch_start.Value.Date)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Scheduled End Date should not less than start date of Tas Activity or Master Task Start Date!");
                        showMessageService.ShowMessage();

                        return false;
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

        #region Constructor
        public PMS_T009_VM(string ts_code, string doc_cat) : base()
        {
            IsDocumentViewerShow = false;
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            MasterEntity = new EPR_T001_A();
            DetailsEntity = new EPR_T001_B();
            OrderEntity = new EPR_T001();
            DependencyItem = new ObservableCollection<EPR_T001_C>();
            DependencyItem.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CCNotifyItem);
            DEP_OBJ = new EPR_T001_C();
            CTR_PARA_OBJ = new STD_LIST_BE();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            MC = new MC_PMS_BE();
            MC_TEMP = new MC_PMS_BE();
            BACKFLIP_OBJ = new STD_LIST_BE();
            SELECTED_TV_OBJ = new STD_LIST_BE();
            //MasterEntity.ValidateAsync().Wait();
            sms = this.GetViewService<IShowMessageViewService>();
            PMS_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            CommandInitialization();
            LoadInitialData();
            DefaultValues();
        }
        public PMS_T009_VM(string ts_code, string doc_cat, STD_LIST_BE para_obj) : base()
        {
            IsDocumentViewerShow = false;
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            MasterEntity = new EPR_T001_A();
            DetailsEntity = new EPR_T001_B();
            OrderEntity = new EPR_T001();
            DependencyItem = new ObservableCollection<EPR_T001_C>();
            DependencyItem.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CCNotifyItem);
            DEP_OBJ = new EPR_T001_C();
            CTR_PARA_OBJ = new STD_LIST_BE();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            MC = new MC_PMS_BE();
            MC_TEMP = new MC_PMS_BE();
            BACKFLIP_OBJ = new STD_LIST_BE();
            SELECTED_TV_OBJ = new STD_LIST_BE();
            //MasterEntity.ValidateAsync().Wait();
            CTR_PARA_OBJ = para_obj;
            sms = this.GetViewService<IShowMessageViewService>();
            PMS_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            CommandInitialization();
            LoadInitialData();
            DefaultValues();

        }
        #endregion

        #region Method Implementation
        private void CommandInitialization()
        {
            CursorControl.SetBusyState();
            try
            {
                #region Command Initialisation
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<STD_LIST_BE>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInsertLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertLocation(items); });
                cmdInsertStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertStatus(items); });
                cmdInsertEmployee = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertEmployee(cmdPara); });
                cmdLoadDocumentByDocumentNumber = new RelayCommand<STD_LIST_BE>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara); }); // confirm assignment
                cmdCreate = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Create(cmdPara); });
                cmdSave = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Save(cmdPara); });
                cmdInsertOperation = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertOperation(cmdPara); });
                cmdDocumentAttachment = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DocumentAttachment(cmdPara); });
                cmdComponantView = new RelayCommand<EPR_T001_A>(items => { if (items == null) { return; } ComponantView(items); });
                cmdResourceView = new RelayCommand<EPR_T001_A>(items => { if (items == null) { return; } ResourceView(items); });
                #endregion
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void FilterDependency()
        {
            try
            {
                if (DependencyItem != null && DependencyItem.Count > 0 && MasterEntity != null && DEP_OBJ != null)
                {
                    //var temp = (from o in DependencyItem where o.ItemCode == DEP_OBJ.ItemCode select o).ToList();
                    //if (temp != null && temp.Count() > 0)
                    //{
                    //    //var tempAdd = (from o in MC.SHIPPING_ADDRESS_LIST where o.party_code == SelectedItemScheduleEntity.ship_to_party select o);
                    //    //SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).location);
                    //    //TheFilter = (o, prefix) => (((STD_PARTY)o).location ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).add_code.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                    //    //AS_SHIPPING_ADDRESS = new AutoSuggestTextViewModel<dynamic>(tempAdd, TheFilter, SuggestedValue, "ship_to_addNm", "location", true);
                    //    //AS_SHIPPING_ADDRESS.AutoSuggestVM.IsEmptyValueAllowed = true;
                    //}
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                isNewRecord = true;
                string Request = "LOAD_INI_ACTIVITY" + "!@" + AppSessionState.client + "!@" + (CTR_PARA_OBJ.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (CTR_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + (CTR_PARA_OBJ.order_no ?? "") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + CTR_PARA_OBJ.org_code + "!@" + (CTR_PARA_OBJ.group_code ?? "");
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_PMS_BE>(MC, Request, "PMS_T009_BL", "PMS", "LoadAll", 0, "");

                if(MC.TASK_LIST != null)
                {
                    if(MC.TASK_LIST.Count > 0)
                    {
                        OrderEntity = MC.TASK_LIST[0];
                    }
                }
                
                #region Autosuggest

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(MC.LOCATION_LIST, TheFilter, SuggestedValue, "location_id", true);
                AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_STATUS = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_status", true);
                AS_STATUS.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id);
                TheFilter = (o, prefix) => (((STD_PERSONNEL)o).emp_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PERSONNEL)o).emp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_EMPLOYEE = new AutoSuggestTextViewModel<dynamic>(MC.PERSONNEL_LIST, TheFilter, SuggestedValue, "emp_id", true);
                AS_EMPLOYEE.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((FICO_M0019)x).cc_code);
                TheFilter = (o, prefix) => (((FICO_M0019)o).cc_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((FICO_M0019)o).cc_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COST_CENTER = new AutoSuggestTextViewModel<dynamic>(MC.COST_CENTER_LIST, TheFilter, SuggestedValue, "cc_code", true);
                AS_COST_CENTER.AutoSuggestVM.IsEmptyValueAllowed = true; AS_COST_CENTER.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((FICO_M0020)x).pc_code);
                TheFilter = (o, prefix) => (((FICO_M0020)o).pc_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((FICO_M0020)o).pc_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_PROFIT_CENTER = new AutoSuggestTextViewModel<dynamic>(MC.PROFIT_CENTER_LIST, TheFilter, SuggestedValue, "pc_code", true);
                AS_PROFIT_CENTER.AutoSuggestVM.IsEmptyValueAllowed = true; AS_PROFIT_CENTER.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).wc_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).wc_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).wc_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_WORK_CENTER = new AutoSuggestTextViewModel<dynamic>(MC.WC_LIST, TheFilter, SuggestedValue, "wc_code", true);
                AS_WORK_CENTER.AutoSuggestVM.IsEmptyValueAllowed = true; AS_WORK_CENTER.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M051)x).control_key);
                TheFilter = (o, prefix) => (((SYS_M051)o).control_key ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M051)o).control_key_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_CONTROL_KEY = new AutoSuggestTextViewModel<dynamic>(MC.CONTROL_KEY_LIST, TheFilter, SuggestedValue, "control_key", true);
                AS_CONTROL_KEY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_CONTROL_KEY.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).op_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).op_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).operation_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_OPERATION = new AutoSuggestTextViewModel<dynamic>(MC.OPERATION_LIST, TheFilter, SuggestedValue, "op_code", true);
                AS_OPERATION.AutoSuggestVM.IsEmptyValueAllowed = true; AS_OPERATION.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM_WORK = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM_WORK.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM_WORK_DUR = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM_WORK_DUR.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM_WORK_DUR.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0040)x).pr_code);
                TheFilter = (o, prefix) => (((ADM_M0040)o).pr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0040)o).text_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_PRIORITY = new AutoSuggestTextViewModel<dynamic>(MC.PRIORITY_LIST, TheFilter, SuggestedValue, "pr_code", true);
                AS_PRIORITY.AutoSuggestVM.IsEmptyValueAllowed = true; AS_PRIORITY.AutoSuggestVM.IsFreeTextAllowed = false;


                #endregion
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void CCNotifyItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (EPR_T001_C item in e.NewItems)
                    {

                        item.op_doc = MasterEntity.doc_no;
                        item.active = "1";
                        item.client = AppSessionState.client;

                    }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }

        private void Create(object InputValue)
        {
            try
            {
                isNewRecord = true;
                MasterEntity = new EPR_T001_A();
                DetailsEntity = new EPR_T001_B();
                DependencyItem = new ObservableCollection<EPR_T001_C>();
                DEP_OBJ = new EPR_T001_C();
                //OrderEntity = new EPR_T001();
                MasterEntity.ValidateAsync().Wait();
                DefaultValues();

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void DocumentAttachment(object InputValue)
        {
            try
            {
                if (!string.IsNullOrEmpty(MasterEntity.doc_no))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MC_TEMP.ATTACHMENT_LIST, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void ComponantView(EPR_T001_A ParameterObject)
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
                    STD_OBJ.location_id = MasterEntity.location_id;
                    STD_OBJ.doc_cat = "RR";
                    STD_OBJ.doc_type = "RR";
                    STD_OBJ.order_no = MasterEntity.order_no;
                    STD_OBJ.ref_doc_cat = MasterEntity.doc_cat;
                    STD_OBJ.ref_doc_type = MasterEntity.doc_type;
                    STD_OBJ.ref_doc_no = MasterEntity.doc_no;
                    STD_OBJ.ref_row_id = MasterEntity.id;
                    STD_OBJ.op_code = MasterEntity.op_code;
                    STD_OBJ.op_no = MasterEntity.operation_no;
                    STD_OBJ.mov_tp = "114";
                    STD_OBJ.request_type = "RESERVATION";
                    STD_OBJ.request = "AT_RES";
                    STD_OBJ.project_id = CTR_PARA_OBJ.project_id;
                    STD_OBJ.element_id = CTR_PARA_OBJ.element_id;
                    STD_OBJ.store_code = CTR_PARA_OBJ.store_code;
                    STD_OBJ.bom_no = CTR_PARA_OBJ.bom_no;
                    STD_OBJ.bom_item_row_id = CTR_PARA_OBJ.bom_item_row_id;
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
        private void Save(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                if (Validation() == true)
                {
                    if (string.IsNullOrWhiteSpace(MasterEntity.doc_no))
                    {
                        isNewRecord = true;
                    }
                    else
                    {
                        isNewRecord = false;
                    }

                    MasterEntity.ts_code = ts_code_vm;
                    MasterEntity.userid = AppSessionState.UserID;
                    MasterEntity.user_source1 = AppSessionState.UserSource1;
                    MasterEntity.user_source2 = AppSessionState.UserSource2;
                    //MasterEntity.XDOC_B = SER_OBJ.ObjectToXML(DetailsEntity);

                    OrderEntity.ts_code = ts_code_vm;
                    OrderEntity.userid = AppSessionState.UserID;
                    OrderEntity.user_source1 = ts_code_vm;
                    OrderEntity.user_source2 = ts_code_vm;
                    List<EPR_T001_A> opObj = new List<EPR_T001_A>();
                    List<EPR_T001_B> dateObj = new List<EPR_T001_B>();
                    opObj.Add(MasterEntity);
                    dateObj.Add(DetailsEntity);
                    OrderEntity.XDOC_A = SER_OBJ.ObjectToXML(opObj);
                    OrderEntity.XDOC_B = SER_OBJ.ObjectToXML(dateObj);
                    OrderEntity.XDOC_C = SER_OBJ.ObjectToXML(DependencyItem);

                    if (isNewRecord == true)
                    {
                        OrderEntity = REPO.UpdateWithReturnDomainObject<EPR_T001>(OrderEntity, "PMS_T009_BL", "PMS");
                        if (!string.IsNullOrWhiteSpace(OrderEntity.XDOC_A))
                        {
                            MC.ACTIVITY_LIST = (List<EPR_T001_A>)new ObjectSerializationService().XMLToObject(OrderEntity.XDOC_A, MC.ACTIVITY_LIST);
                            if (MC.ACTIVITY_LIST.Count > 0)
                            {
                                MasterEntity = MC.ACTIVITY_LIST.Where(x => x.operation_no == MasterEntity.operation_no).ToList()[0];
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(OrderEntity.XDOC_B))
                        {
                            MC.ACTIVITY_DATES_LIST = (List<EPR_T001_B>)new ObjectSerializationService().XMLToObject(OrderEntity.XDOC_B, MC.ACTIVITY_DATES_LIST);
                            if (MC.ACTIVITY_DATES_LIST.Count > 0)
                            {
                                DetailsEntity = MC.ACTIVITY_DATES_LIST.Where(x => x.operation_row_id == MasterEntity.id).ToList()[0];
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(OrderEntity.XDOC_C))
                        {
                            MC.DEPENDENCY_LIST = (ObservableCollection<EPR_T001_C>)new ObjectSerializationService().XMLToObject(OrderEntity.XDOC_C, MC.DEPENDENCY_LIST);
                            if (MC.DEPENDENCY_LIST.Count > 0)
                            {
                                DependencyItem = new ObservableCollection<EPR_T001_C>(MC.DEPENDENCY_LIST.Where(x => x.op_doc == MasterEntity.doc_no));
                            }
                        }
                        List<STD_LIST_BE> SLBE = new List<STD_LIST_BE>();
                        STD_LIST_BE SLBE_TEMP = new STD_LIST_BE();

                        SLBE_TEMP.client = MasterEntity.client;
                        SLBE_TEMP.ts_code = MasterEntity.ts_code;
                        SLBE_TEMP.comp_code = MasterEntity.comp_code;
                        SLBE_TEMP.location_id = MasterEntity.location_id;
                        SLBE_TEMP.project_id = OrderEntity.project_id;
                        SLBE_TEMP.element_id = OrderEntity.element_id;
                       
                        SLBE.Add(SLBE_TEMP);
                        Messenger.Default.Send<NotificationMessage>(new NotificationMessage(SLBE, "REFRESH_PS"));
                    }
                    else if (isNewRecord == false)
                    {
                        OrderEntity = REPO.UpdateWithReturnDomainObject<EPR_T001>(OrderEntity, "PMS_T009_BL", "PMS");
                        if (!string.IsNullOrWhiteSpace(OrderEntity.XDOC_A))
                        {
                            MC.ACTIVITY_LIST = (List<EPR_T001_A>)new ObjectSerializationService().XMLToObject(OrderEntity.XDOC_A, MC.ACTIVITY_LIST);
                            if (MC.ACTIVITY_LIST.Count > 0)
                            {
                                MasterEntity = MC.ACTIVITY_LIST.Where(x => x.operation_no == MasterEntity.operation_no).ToList()[0];
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(OrderEntity.XDOC_B))
                        {
                            MC.ACTIVITY_DATES_LIST = (List<EPR_T001_B>)new ObjectSerializationService().XMLToObject(OrderEntity.XDOC_B, MC.ACTIVITY_DATES_LIST);
                            if (MC.ACTIVITY_DATES_LIST.Count > 0)
                            {
                                DetailsEntity = MC.ACTIVITY_DATES_LIST.Where(x => x.operation_row_id == MasterEntity.id).ToList()[0];
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(OrderEntity.XDOC_C))
                        {
                            MC.DEPENDENCY_LIST = (ObservableCollection<EPR_T001_C>)new ObjectSerializationService().XMLToObject(OrderEntity.XDOC_C, MC.DEPENDENCY_LIST);
                            if (MC.DEPENDENCY_LIST.Count > 0)
                            {
                                DependencyItem = new ObservableCollection<EPR_T001_C>(MC.DEPENDENCY_LIST.Where(x => x.op_doc == MasterEntity.doc_no));
                            }
                        }
                    }


                    isNewRecord = false;
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = "Record save successfully!"; sms.ShowMessage();

                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertOperation(object InputValue)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.OPERATION_LIST.Where(x => x.op_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.operation_desc = POPUPEntityObject.operation_desc;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertLocation(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0003 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.LOCATION_LIST.Where(x => x.location_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0003>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.location_id = POPUPEntityObject.location_id;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
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
                            { POPUPEntityObject = MC.STATUS_LIST.Where(x => x.t_status.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_display.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertEmployee(object InputValue)
        {
            try
            {
                string Request = "";
                STD_PERSONNEL POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PERSONNEL_LIST.Where(x => x.emp_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PERSONNEL>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.emp_id = POPUPEntityObject.emp_id;
                    MasterEntity.emp_name = POPUPEntityObject.emp_name;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void LoadDocumentByDocumentNumber(STD_LIST_BE ParameterObject)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + ParameterObject.comp_code + "!@" + ParameterObject.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + ParameterObject.order_no + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm;
                MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_PMS_BE>(MC_TEMP, Request, "PMS_T009_BL", "PMS", "LoadAll", 0, "");

                if (MC_TEMP.TASK_LIST.Count > 0)
                {
                    MC.TASK_LIST = MC_TEMP.TASK_LIST;
                    OrderEntity = MC_TEMP.TASK_LIST[0];
                }
                
                if(MC_TEMP.ACTIVITY_LIST.Count > 0)
                {
                    MC.ACTIVITY_LIST = MC_TEMP.ACTIVITY_LIST;
                    MasterEntity = MC_TEMP.ACTIVITY_LIST.Where(x => x.doc_no==ParameterObject.doc_no).ToList()[0];
                    //TSK_ACT_COL = MC_TEMP.ACTIVITY_LIST;
                    TSK_ACT_COL = MC_TEMP.ACTIVITY_LIST.Where(x => x.doc_no != MasterEntity.doc_no && x.id > 0).ToList();
                }
                if (MC_TEMP.ACTIVITY_DATES_LIST.Count > 0)
                {
                    MC.ACTIVITY_DATES_LIST = MC_TEMP.ACTIVITY_DATES_LIST;
                    DetailsEntity = MC_TEMP.ACTIVITY_DATES_LIST.Where(x => x.operation_row_id == MasterEntity.id).ToList()[0];
                }
                if (MC_TEMP.DEPENDENCY_LIST.Count > 0)
                {
                    MC.DEPENDENCY_LIST = MC_TEMP.DEPENDENCY_LIST;
                    //var dep = MC_TEMP.DEPENDENCY_LIST.Where(x => x.op_doc == MasterEntity.doc_no).ToList();
                    DependencyItem = new ObservableCollection<EPR_T001_C>(MC_TEMP.DEPENDENCY_LIST.Where(x => x.op_doc == MasterEntity.doc_no));
                    //DEP_OBJ = MC_TEMP.DEPENDENCY_LIST.Where(x => x.activity_no == MasterEntity.doc_no).ToList()[0];
                    //DependencyItem = MC_TEMP.DEPENDENCY_LIST.Where(x => x.activity_no == MasterEntity.doc_no).ToList();

                

                }
                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void WindowEvetCall(STD_LIST_BE InputValue)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(InputValue.doc_no) && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(InputValue);
                }
                else
                {
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

        #region Abstract Method
        protected override void OnCreateAction(InquiryActionResult<EPR_T001> result)
        {
            isNewRecord = true;
            MasterEntity = new EPR_T001_A();
            DetailsEntity = new EPR_T001_B();
            DependencyItem = new ObservableCollection<EPR_T001_C>();
            DependencyItem.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CCNotifyItem);
            DEP_OBJ = new EPR_T001_C();
            OrderEntity = new EPR_T001();
            MasterEntity.ValidateAsync().Wait();
            DefaultValues();
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
        }
        protected override void OnDiscardAction(InquiryActionResult<EPR_T001> result)
        { }
        protected override void OnFevoriteAction(InquiryActionResult<EPR_T001> result)
        { }
        protected override void OnFlipAction(InquiryActionResult<EPR_T001> result)
        { }
        protected override void OnHelpAction(InquiryActionResult<EPR_T001> result)
        { }
        protected override void OnPrintAction(InquiryActionResult<EPR_T001> result)
        {
        }
        protected override void OnRemoveAction(InquiryActionResult<EPR_T001> result)
        {
        }
        protected override void OnSaveAction(InquiryActionResult<EPR_T001> result)
        {
        }
        protected override void OnDocumentAction()
        { }
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

        #endregion
       
    }
}
