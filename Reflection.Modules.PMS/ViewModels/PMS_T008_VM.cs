using System;
using System.Collections;
using System.Collections.Generic;
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
using Reflection.BusinessEntity.ADM;
using System.Data;
using Reflection.BusinessEntity.FICO;
using System.Reflection;
using GalaSoft.MvvmLight.Ioc;
using Reflection.Presentation.Core.VirtualDesktops;
using System.IO;

namespace Reflection.Modules.PMS.ViewModels
{
    public class PMS_T008_VM : WorkspaceViewModel<EPR_T001>, ITS_VIEW_MODEL
    {
        #region AutoSuggest Initialization

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

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

        private AutoSuggestTextViewModel<dynamic> _AS_TASK { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_TASK
        {
            get { return _AS_TASK; }
            set
            {
                if (_AS_TASK != value)
                {
                    _AS_TASK = value; RaisePropertyChanged("AS_TASK");
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

        private EPR_T001 _MasterEntity;
        public EPR_T001 MasterEntity
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
        private EPR_T001_A _EPR_T001_A_OBJ;
        public EPR_T001_A EPR_T001_A_OBJ
        {
            get { return _EPR_T001_A_OBJ; }
            set { if (_EPR_T001_A_OBJ != value) { _EPR_T001_A_OBJ = value; RaisePropertyChanged("EPR_T001_A_OBJ"); } }
        }
        private PMS_T002 _PhaseEntity;
        public PMS_T002 PhaseEntity
        {
            get { return _PhaseEntity; }
            set
            {
                if (_PhaseEntity != value)
                {
                    _PhaseEntity = value; RaisePropertyChanged("PhaseEntity");
                }
            }
        }

        private PMS_T001 _ProjectEntity;
        public PMS_T001 ProjectEntity
        {
            get { return _ProjectEntity; }
            set
            {
                if (_ProjectEntity != value)
                {
                    _ProjectEntity = value; RaisePropertyChanged("ProjectEntity");
                }
            }
        }

        private PMS_T006 _ScheduleEntity;
        public PMS_T006 ScheduleEntity
        {
            get { return _ScheduleEntity; }
            set
            {
                if (_ScheduleEntity != value)
                {
                    _ScheduleEntity = value; RaisePropertyChanged("ScheduleEntity");
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
        public RelayCommand<object> cmdOpenAttachments { get; private set; }
        public RelayCommand<object> cmdCreate { get; private set; }
        public RelayCommand<object> cmdSave { get; private set; }
        public RelayCommand<object> cmdDocumentAttachment { get; private set; }

        //NOTE: cmdComponantView, incomplete funtion because we have made provision for MasterEntity of EPR_T001 to send as parameter and with the 
        //help of BOM & Routing we assign componants for all operation. to assign direct at operation level, we need to send Operation 
        //as parameter with order header details then we can use this function to assign componants at Order Heder level or 
        //Operation Level or at Project Phase level. need to send generic paramter and level input for which we need to assign componants.
        public RelayCommand<EPR_T001> cmdComponantView { get; private set; }
        public RelayCommand<EPR_T001_A> cmdResourceView { get; private set; }

        #endregion

        #region DefalutValue
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_cat = doc_cat_vm;
            MasterEntity.doc_type = doc_cat_vm;
            MasterEntity.order_type = "N";
            MasterEntity.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
            MasterEntity.t_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_display).FirstOrDefault();
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.emp_id = AppSessionState.EmpId;
            MasterEntity.emp_name = AppSessionState.EmpName;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.comp_code = CTR_PARA_OBJ.comp_code;
            MasterEntity.project_id = CTR_PARA_OBJ.project_id;
            MasterEntity.project_name = CTR_PARA_OBJ.project_name;
            MasterEntity.element_id = CTR_PARA_OBJ.element_id;
            MasterEntity.element_name = CTR_PARA_OBJ.element_name;
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.active = true;
            MasterEntity.start_dt = DateTime.Now;
            MasterEntity.end_dt = DateTime.Now;
            MasterEntity.sch_start_date = DateTime.Now;
            MasterEntity.sch_end_date = DateTime.Now;

            MainTabIndex = 1;
        }
        #endregion

        #region Constructor
        public PMS_T008_VM(string ts_code, string doc_cat) : base()
        {
            IsDocumentViewerShow = false;
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            MasterEntity = new EPR_T001();
            EPR_T001_A_OBJ = new EPR_T001_A();
            ProjectEntity = new PMS_T001();
            PhaseEntity = new PMS_T002();
            ScheduleEntity = new PMS_T006();
            CTR_PARA_OBJ = new STD_LIST_BE();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            MC = new MC_PMS_BE();
            MC_TEMP = new MC_PMS_BE();
            EPR_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            sms = this.GetViewService<IShowMessageViewService>();
            CommandInitialization();
            LoadInitialData();
            DefaultValues();
        }
        public PMS_T008_VM(string ts_code, string doc_cat, STD_LIST_BE para_obj) : base()
        {
            IsDocumentViewerShow = false;
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            MasterEntity = new EPR_T001();
            EPR_T001_A_OBJ = new EPR_T001_A();
            ProjectEntity = new PMS_T001();
            PhaseEntity = new PMS_T002();
            ScheduleEntity = new PMS_T006();
            CTR_PARA_OBJ = new STD_LIST_BE();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            MC = new MC_PMS_BE();
            MC_TEMP = new MC_PMS_BE();
            //MasterEntity.ValidateAsync().Wait();
            CTR_PARA_OBJ = para_obj;
            EPR_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            sms = this.GetViewService<IShowMessageViewService>();
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
                cmdDocumentAttachment = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DocumentAttachment(cmdPara); });
                cmdComponantView = new RelayCommand<EPR_T001>(items => { if (items == null) { return; } ComponantView(items); });
                cmdResourceView = new RelayCommand<EPR_T001_A>(items => { if (items == null) { return; } ResourceView(items); });
                #endregion
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                isNewRecord = true;
                string Request = "LOAD_INI_TASK" + "!@" + AppSessionState.client + "!@" + (CTR_PARA_OBJ.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (CTR_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + CTR_PARA_OBJ.element_id + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + REQ_PARA_OBJ.org_code + "!@" + (REQ_PARA_OBJ.group_code ?? "");
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_SDM_BE>(MC, Request, "PMS_T008_BL", "PMS", "LoadAll", 0, "");

                if(MC.PROJECT_LIST != null)
                {
                    if(MC.PROJECT_LIST.Count > 0)
                    {
                        ProjectEntity = MC.PROJECT_LIST[0];
                    }
                }
                if (MC.ELEMENT_LIST != null)
                {
                    if (MC.ELEMENT_LIST.Count > 0)
                    {
                        PhaseEntity = MC.ELEMENT_LIST[0];
                    }
                }
                if (MC.SCHEDULE_LIST != null)
                {
                    if (MC.SCHEDULE_LIST.Count > 0)
                    {
                        //ScheduleEntity = MC.SCHEDULE_LIST[0];
                        if (MC.SCHEDULE_LIST.Where(x => x.active == "1").ToList().Count > 0)
                        {
                            ScheduleEntity = MC.SCHEDULE_LIST.Where(x => x.active == "1").ToList()[0];
                        }
                        else
                        {
                            ScheduleEntity = new PMS_T006();
                        }
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

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).short_text);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).short_text ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).short_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_TASK = new AutoSuggestTextViewModel<dynamic>(MC.TASK_STD_LIST, TheFilter, SuggestedValue, "short_text", true);
                AS_TASK.AutoSuggestVM.IsEmptyValueAllowed = true; AS_TASK.AutoSuggestVM.IsFreeTextAllowed = true;


                #endregion
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void Create(object InputValue)
        {
            try
            {
                isNewRecord = true;
                MasterEntity = new EPR_T001();
                MasterEntity.ValidateAsync().Wait();
                DefaultValues();

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
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
                    ParameterObject.order_no = MasterEntity.order_no;
                    ParameterObject.comp_code = MasterEntity.comp_code;
                    ParameterObject.location_id = MasterEntity.location_Id;

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
        private void DocumentAttachment(object InputValue)
        {
            try
            {
                if (!string.IsNullOrEmpty(MasterEntity.order_no))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.order_no.Replace("/", "--"), DocumentList = MC_TEMP.ATTACHMENT_LIST, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void Save(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                if (Validation() == true)
                {
                    if (string.IsNullOrWhiteSpace(MasterEntity.order_no))
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

                    if (isNewRecord == true)
                    {
                        MasterEntity = REPO.SaveWithReturnDomainObject<EPR_T001>(MasterEntity, "PMS_T008_BL", "PMS");
                        if (!string.IsNullOrWhiteSpace(MasterEntity.XDOC_A))
                        {
                            //ScheduleEntity.Clear();
                            MC.SCHEDULE_LIST = (List<PMS_T006>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_A, MC.SCHEDULE_LIST);
                        }
                        List<STD_LIST_BE> SLBE = new List<STD_LIST_BE>();
                        STD_LIST_BE SLBE_TEMP = new STD_LIST_BE();

                        SLBE_TEMP.client = MasterEntity.client;
                        SLBE_TEMP.ts_code = MasterEntity.ts_code;
                        SLBE_TEMP.comp_code = MasterEntity.comp_code;
                        SLBE_TEMP.location_id = MasterEntity.location_Id;
                        SLBE_TEMP.project_id = MasterEntity.project_id;
                        SLBE_TEMP.element_id = MasterEntity.element_id;
                        //SLBE.value_code = "REFRESH_PS";
                        SLBE.Add(SLBE_TEMP);
                        Messenger.Default.Send<NotificationMessage>(new NotificationMessage(SLBE, "REFRESH_PS"));
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = REPO.UpdateWithReturnDomainObject<EPR_T001>(MasterEntity, "PMS_T008_BL", "PMS");
                    }


                    isNewRecord = false;
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = "Record save successfully!"; sms.ShowMessage();

                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
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
                    MasterEntity.location_Id = POPUPEntityObject.location_id;
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
                string Request = "LOAD_TASK" + "!@" + AppSessionState.client + "!@" + ParameterObject.comp_code + "!@" + ParameterObject.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + ParameterObject.doc_no + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm;
                MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_PMS_BE>(MC_TEMP, Request, "PMS_T008_BL", "PMS", "LoadAll", 0, "");
                if(MC_TEMP.TASK_LIST != null)
                {
                    if(MC_TEMP.TASK_LIST.Count > 0)
                    {
                        MasterEntity = MC_TEMP.TASK_LIST[0];
                        Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
                    }
                }
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
        private bool Validation()
        {
            try
            {
                if (MasterEntity.project_id == null)
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please input Project ........"); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.comp_code == null)
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please input Company........"); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.location_Id == null)
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please input Location........"); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.emp_id == null)
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please input Responsible Person........"); sms.ShowMessage();
                    return false;
                }
                //if (MasterEntity.unit_code == null)
                //{
                //    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please input Project Name........"); sms.ShowMessage();
                //    return false;
                //}
                if (MasterEntity.sch_start_date.HasValue && ScheduleEntity.date_schedule.HasValue)
                {
                    if (MasterEntity.sch_start_date.Value.Date < ScheduleEntity.date_schedule.Value.Date)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Scheduled Start Date should not less than Master Task Start Date!");
                        showMessageService.ShowMessage();

                        return false;
                    }
                }
                if (MasterEntity.sch_end_date.HasValue && ScheduleEntity.date_finish.HasValue)
                {
                    if (MasterEntity.sch_end_date.Value.Date > ScheduleEntity.date_finish.Value.Date)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Scheduled End Date should not exceed date of Master Task End Date!");
                        showMessageService.ShowMessage();

                        return false;
                    }
                    if (MasterEntity.sch_end_date.Value.Date < ScheduleEntity.date_schedule.Value.Date || MasterEntity.sch_end_date.Value.Date < MasterEntity.sch_start_date.Value.Date)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Scheduled End Date should not less than start date of Phase Element or Project Start Date!");
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

        #region Abstract Method
        protected override void OnCreateAction(InquiryActionResult<EPR_T001> result)
        {
            isNewRecord = true;
            MasterEntity = new EPR_T001();
            MasterEntity.ValidateAsync().Wait();
            EPR_T001_A_OBJ = new EPR_T001_A();
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
