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
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using System.Windows.Controls;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services.Convertors;
using Reflection.ReportingServices;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.PMS;
using Reflection.BusinessEntity.ADM;
using System.Data;
using System.Windows.Input;
using Reflection.BusinessEntity.MM;

namespace Reflection.Modules.PMS.ViewModels
{
    public class PMS_T001_VM : WorkspaceViewModel<PMS_T001>
    {
        #region AutoSuggest Initialization

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _AS_COMPANY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_COMPANY
        {
            get { return _AS_COMPANY; }
            set
            {
                if (_AS_COMPANY != value)
                {
                    _AS_COMPANY = value; RaisePropertyChanged("AS_COMPANY");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_DOC_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DOC_TYPE
        {
            get { return _AS_DOC_TYPE; }
            set
            {
                if (_AS_DOC_TYPE != value)
                {
                    _AS_DOC_TYPE = value; RaisePropertyChanged("AS_DOC_TYPE");
                }
            }
        }

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


        #endregion

        #region Variable Declaration

        WebServiceRepository<PMS_T001> REPO = new WebServiceRepository<PMS_T001>();
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

        private UserControl _UC_OBJ = new UserControl();
        public UserControl UC_OBJ
        {
            get { return _UC_OBJ; }
            set
            {
                if (_UC_OBJ != value)
                {
                    _UC_OBJ = value; RaisePropertyChanged("UC_OBJ");

                }
            }
        }

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

        private PMS_T001 _MasterEntity;
        public PMS_T001 MasterEntity
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

        //private ObservableCollection<STD_LIST_BE> _TREE_LIST_VIEW;
        //public ObservableCollection<STD_LIST_BE> TREE_LIST_VIEW
        //{
        //    get
        //    {
        //        return _TREE_LIST_VIEW;
        //    }
        //    set
        //    {
        //        if (_TREE_LIST_VIEW != value)
        //        {
        //            _TREE_LIST_VIEW = value;
        //            RaisePropertyChanged("TREE_LIST_VIEW");
        //        }
        //    }
        //}

        DataSet _ItemsSet = new DataSet();
        public DataSet ItemsSet
        {
            get { return _ItemsSet; }
            set
            {
                if (_ItemsSet != value)
                {
                    _ItemsSet = value;

                    RaisePropertyChanged("ItemsSet");
                }
            }
        }
        DataView _ItemsView = new DataView();
        public DataView ItemsView
        {
            get { return _ItemsView; }
            set
            {
                if (_ItemsView != value)
                {
                    _ItemsView = value;

                    RaisePropertyChanged("ItemsView");
                }
            }
        }

        private ITS_VIEW_MODEL _CURRENT_TS_VM;
        public ITS_VIEW_MODEL CURRENT_TS_VM
        {
            get
            {
                return _CURRENT_TS_VM;
            }
            set
            {
                if (_CURRENT_TS_VM != value)
                {
                    _CURRENT_TS_VM = value;
                    RaisePropertyChanged("CURRENT_TS_VM");
                }
            }
        }
        private List<ITS_VIEW_MODEL> _TS_VIEW_MODEL;
        public List<ITS_VIEW_MODEL> TS_VIEW_MODEL
        {
            get
            {
                if (_TS_VIEW_MODEL == null)
                    _TS_VIEW_MODEL = new List<ITS_VIEW_MODEL>();

                return _TS_VIEW_MODEL;
            }
        }

        #endregion

        #region Model Entity Update
        void ModelUpdated_Master(object sender, EventArgs e)
        {
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
        }

        #endregion
        #region Relay Commands Declaration
        public RelayCommand<object> cmdSelectionChanged_SEL_T001_A { get; private set; }
        public RelayCommand<object> cmdSelectionChanged_SEL_T001_E { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmddgLocation { get; private set; }
        public RelayCommand<object> CommandDocType { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdExecuteReferenceDocuments { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridTerms { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        public RelayCommand<object> cmdOpenAttachments { get; private set; }
        public RelayCommand<object> cmdOpenChildWindow { get; private set; }
        public RelayCommand<PMS_T002> cmdCreateMilestone { get; private set; }
        public RelayCommand<PMS_T002> cmdCreateTask { get; private set; }
        public RelayCommand<EPR_T001> cmdCreateActivity { get; private set; }


        #endregion

        #region DefalutValue
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_cat = doc_cat_vm;
            MasterEntity.doc_type = doc_cat_vm;
            MasterEntity.location_id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.active = "1";
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.date_start = DateTime.Now;
            MasterEntity.emp_id = AppSessionState.EmpId;
            MasterEntity.emp_name = AppSessionState.EmpName;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MainTabIndex = 1;
            
            DateTime d = DateTime.UtcNow;
            d = d.AddMonths(-1);
            REQ_PARA_OBJ.from_date = d;
            REQ_PARA_OBJ.to_date = DateTime.UtcNow;
            //REQ_PARA_OBJ.from_date = DateTime.Now;
            //REQ_PARA_OBJ.to_date = DateTime.Now;
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
        public PMS_T001_VM(string ts_code) : base()
        {
            IsDocumentViewerShow = false;
            //this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            MasterEntity = new PMS_T001();

            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            MC = new MC_PMS_BE();
            MC_TEMP = new MC_PMS_BE();
            BACKFLIP_OBJ = new STD_LIST_BE();
            SELECTED_TV_OBJ = new STD_LIST_BE();
            //MasterEntity.ValidateAsync().Wait();
            sms = this.GetViewService<IShowMessageViewService>();
            // Add available pages
            TS_VIEW_MODEL.Add(new PMS_T002_VM("RS02", "PS"));
            TS_VIEW_MODEL.Add(new PMS_T003_VM("RS03", "PH"));
            TS_VIEW_MODEL.Add(new PMS_T005_VM("RS05", "PL"));
            TS_VIEW_MODEL.Add(new PMS_T008_VM("RS08", "PT"));
            TS_VIEW_MODEL.Add(new PMS_T009_VM("RS09", "AT"));

            // Set starting page
            //CURRENT_TS_VM = TS_VIEW_MODEL[0];
            Messenger.Default.Register<NotificationMessage>(this, RefreshTreeViewOnSave);
            PMS_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            CommandInitialization();

            LoadInitialData();
            DefaultValues();
        }
        public PMS_T001_VM(string ts_code, string doc_no) : base()
        {
            IsDocumentViewerShow = false;
            //this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            MasterEntity = new PMS_T001();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            MC = new MC_PMS_BE();
            MC_TEMP = new MC_PMS_BE();
            BACKFLIP_OBJ = new STD_LIST_BE();
            SELECTED_TV_OBJ = new STD_LIST_BE();
            sms = this.GetViewService<IShowMessageViewService>();
            //MasterEntity.ValidateAsync().Wait();
            // Add available pages
            TS_VIEW_MODEL.Add(new PMS_T002_VM("RS02", "PS"));
            TS_VIEW_MODEL.Add(new PMS_T003_VM("RS03", "PH"));
            TS_VIEW_MODEL.Add(new PMS_T005_VM("RS05", "PL"));
            TS_VIEW_MODEL.Add(new PMS_T008_VM("RS08", "PT"));
            TS_VIEW_MODEL.Add(new PMS_T009_VM("RS09", "AT"));

            //// Set starting page
            //CURRENT_TS_VM = TS_VIEW_MODEL[0];


            PMS_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            CommandInitialization();
            LoadInitialData();
            DefaultValues();

        }
        #endregion

        #region Method Implementation
        private void RefreshTreeViewOnSave(NotificationMessage msg)
        {
            if (msg.Notification == "REFRESH_PS")
            {
                LoadDocumentByDocumentNumber(msg.Sender, msg.Notification);
            }
            
        }
        private void CommandInitialization()
        {
            CursorControl.SetBusyState();
            try
            {
                #region Command Initialisation
                //cmdSelectionChanged_SEL_T001_A = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_SEL_T001_A(items); });
                //cmdSelectionChanged_SEL_T001_E = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_SEL_T001_E(items); });
                //cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                //cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                //cmddgLocation = new RelayCommand<object>(items => { if (items == null) { return; } Insertdgplant(items); });
                //CommandDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocType(items); });
                //CommandDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });// confirm assignment
                cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); }); // confirm assignment
                //cmdExecuteReferenceDocuments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } ExecuteReferenceDocuments(cmdPara, "FlipGridReference"); }); // confirm assignment
                //CommandDeleteDataGridTerms = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Terms(cmdPara); });
                cmdLoadBackFlip = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadBackFlipData(cmdPara); });
                //cmdOpenAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenDocumentViewer(cmdPara); });
                cmdOpenChildWindow = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenChildWindow(cmdPara); });
                cmdCreateMilestone = new RelayCommand<PMS_T002>(cmdPara => { if (cmdPara == null) { return; } CreateMilestone(cmdPara); });
                cmdCreateTask = new RelayCommand<PMS_T002>(cmdPara => { if (cmdPara == null) { return; } CreateTask(cmdPara); });
                cmdCreateActivity = new RelayCommand<EPR_T001>(cmdPara => { if (cmdPara == null) { return; } CreateActivity(cmdPara); });
                #endregion
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void CreateMilestone(PMS_T002 ParameterObject)
        {
            try
            {
                CursorControl.SetBusyState();
                STD_LIST_BE OBJ_TEMP = new STD_LIST_BE();

                OBJ_TEMP.doc_cat = "PL";
                OBJ_TEMP.doc_type = "PL";
                OBJ_TEMP.comp_code = ParameterObject.comp_code;
                OBJ_TEMP.location_id = ParameterObject.location_id;
                OBJ_TEMP.project_id = ParameterObject.project_id;
                OBJ_TEMP.project_no = ParameterObject.project_no;
                OBJ_TEMP.project_name = ParameterObject.project_name;
                OBJ_TEMP.emp_id = ParameterObject.emp_id;
                OBJ_TEMP.element_id = ParameterObject.element_id;
                OBJ_TEMP.element_no = ParameterObject.element_no;
                OBJ_TEMP.element_name = ParameterObject.element_name;
                OBJ_TEMP.order_no = null;
                OBJ_TEMP.operation_no = null;
                OBJ_TEMP.doc_no = null;
                OBJ_TEMP.ts_code = null;
                OBJ_TEMP.type_code = null;


                SELECTED_TV_OBJ = OBJ_TEMP;

                if (!string.IsNullOrWhiteSpace(OBJ_TEMP.doc_cat))
                {
                    if (OBJ_TEMP.doc_cat == "PL" && !string.IsNullOrWhiteSpace(OBJ_TEMP.element_id))
                    {
                        UC_OBJ = new Reflection.Modules.PMS.Views.PMS_T005();
                        UC_OBJ.DataContext = new PMS_T005_VM("RS05", "PL", OBJ_TEMP);
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void CreateTask(PMS_T002 ParameterObject)
        {
            try
            {
                CursorControl.SetBusyState();
                STD_LIST_BE OBJ_TEMP = new STD_LIST_BE();
                
                OBJ_TEMP.doc_cat = "PT";
                OBJ_TEMP.doc_type = "PT";
                OBJ_TEMP.comp_code = ParameterObject.comp_code;
                OBJ_TEMP.location_id = ParameterObject.location_id;
                OBJ_TEMP.project_id = ParameterObject.project_id;
                OBJ_TEMP.project_no = ParameterObject.project_no;
                OBJ_TEMP.project_name = ParameterObject.project_name;
                OBJ_TEMP.emp_id = ParameterObject.emp_id;
                OBJ_TEMP.element_id = ParameterObject.element_id;
                OBJ_TEMP.element_no = ParameterObject.element_no;
                OBJ_TEMP.element_name = ParameterObject.element_name;
                OBJ_TEMP.order_no = null;
                OBJ_TEMP.operation_no = null;
                OBJ_TEMP.doc_no = null;
                OBJ_TEMP.ts_code = null;
                OBJ_TEMP.type_code = null;


                SELECTED_TV_OBJ = OBJ_TEMP;

                if (!string.IsNullOrWhiteSpace(OBJ_TEMP.doc_cat))
                {
                    if (OBJ_TEMP.doc_cat == "PT")
                    {
                        //if (TS_VIEW_MODEL[3].doc_info_para.doc_no != OBJ_TEMP.doc_no)
                        //{
                        //    TS_VIEW_MODEL[3] = new PMS_T008_VM("RS08", "PT", OBJ_TEMP);
                        //    TS_VIEW_MODEL[3].doc_info_para = OBJ_TEMP;
                        //    CURRENT_TS_VM = TS_VIEW_MODEL[3];
                        //}
                        //else
                        //{
                        //    CURRENT_TS_VM = TS_VIEW_MODEL[3];
                        //}

                        if (TS_VIEW_MODEL[3].doc_info_para.doc_no != OBJ_TEMP.doc_no || TS_VIEW_MODEL[3].doc_info_para.doc_no==null)
                        {
                            TS_VIEW_MODEL[3].doc_info_para = OBJ_TEMP;
                            UC_OBJ = new Reflection.Modules.PMS.Views.PMS_T008();
                            UC_OBJ.DataContext = new PMS_T008_VM("RS08", "PT", OBJ_TEMP);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void CreateActivity(EPR_T001 ParameterObject)
        {
            try
            {
                CursorControl.SetBusyState();
                STD_LIST_BE OBJ_TEMP = new STD_LIST_BE();

                OBJ_TEMP.doc_cat = "AT";
                OBJ_TEMP.doc_type = "AT";
                OBJ_TEMP.comp_code = ParameterObject.comp_code;
                OBJ_TEMP.location_id = ParameterObject.location_Id;
                OBJ_TEMP.emp_id = ParameterObject.emp_id;
                OBJ_TEMP.element_id = ParameterObject.element_id;
                OBJ_TEMP.element_no = ParameterObject.element_no;
                OBJ_TEMP.element_name = ParameterObject.element_name;
                OBJ_TEMP.order_no = ParameterObject.order_no;
                OBJ_TEMP.operation_no = null;
                OBJ_TEMP.doc_no = null;
                OBJ_TEMP.ts_code = null;
                OBJ_TEMP.type_code = null;


                SELECTED_TV_OBJ = OBJ_TEMP;

                if (!string.IsNullOrWhiteSpace(OBJ_TEMP.doc_cat))
                {
                    if (OBJ_TEMP.doc_cat == "AT")
                    {
                        //TS_VIEW_MODEL[4] = new PMS_T009_VM("RS09", "AT", OBJ_TEMP);
                        //CURRENT_TS_VM = TS_VIEW_MODEL[4];

                        //if (TS_VIEW_MODEL[4].doc_info_para.doc_no != OBJ_TEMP.doc_no)
                        //{
                        //    TS_VIEW_MODEL[4] = new PMS_T009_VM("RS09", "AT", OBJ_TEMP);
                        //    TS_VIEW_MODEL[4].doc_info_para = OBJ_TEMP;
                        //    CURRENT_TS_VM = TS_VIEW_MODEL[4];
                        //}
                        //else
                        //{
                        //    CURRENT_TS_VM = TS_VIEW_MODEL[4];
                        //}

                        if (TS_VIEW_MODEL[4].doc_info_para.doc_no != OBJ_TEMP.doc_no || TS_VIEW_MODEL[4].doc_info_para.doc_no == null)
                        {
                            TS_VIEW_MODEL[4].doc_info_para = OBJ_TEMP;
                            UC_OBJ = new Reflection.Modules.PMS.Views.PMS_T009();
                            UC_OBJ.DataContext = new PMS_T009_VM("RS09", "AT", OBJ_TEMP);
                        }
                    }
                }
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
                //string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + (REQ_PARA_OBJ.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (REQ_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + (MasterEntity.project_id ?? "") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + REQ_PARA_OBJ.org_code + "!@" + (REQ_PARA_OBJ.group_code ?? "");
                //MC = REPO_MC.GetDataWithReturnDomainObject<MC_SDM_BE>(MC, Request, "PMS_T001_BL", "PMS", "LoadAll", 0, "");

                #region Autosuggest

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                //TheFilter = (o, prefix) => (((ADM_M0002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0002)o).comp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", true);
                //AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = true;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_DOC_TYPE)x).doc_type);
                //TheFilter = (o, prefix) => (((STD_DOC_TYPE)o).doc_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_DOC_TYPE)o).doc_type_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //AS_DOC_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.DOC_TYPE_LIST, TheFilter, SuggestedValue, "doc_type", true);
                //AS_DOC_TYPE.AutoSuggestVM.IsEmptyValueAllowed = false;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                //TheFilter = (o, prefix) => (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //AS_STATUS = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_status", true);
                //AS_STATUS.AutoSuggestVM.IsEmptyValueAllowed = true;

                STD_LIST_BE OBJ_TEMP = new STD_LIST_BE();
                OBJ_TEMP.doc_cat = "PS";
                OBJ_TEMP.doc_type = "PS";
                OBJ_TEMP.comp_code =AppSessionState.OBJ_COMPANY.comp_code;
                OBJ_TEMP.location_id = AppSessionState.OBJ_LOCATION.location_id;
                OBJ_TEMP.project_id = null;
                OBJ_TEMP.emp_id = AppSessionState.EmpId;
                OBJ_TEMP.emp_name = AppSessionState.EmpName;
                OBJ_TEMP.element_id = null;
                OBJ_TEMP.order_no = null;
                OBJ_TEMP.operation_no = null;
                OBJ_TEMP.doc_no = null; // milestone no
                OBJ_TEMP.ts_code = null;
                OBJ_TEMP.type_code = null;
                //OpenChildWindow(OBJ_TEMP);

                SELECTED_TV_OBJ = OBJ_TEMP;
                if (OBJ_TEMP.doc_cat == "PS")
                {
                    UC_OBJ = new Reflection.Modules.PMS.Views.PMS_T002();
                    UC_OBJ.DataContext = new PMS_T002_VM("RS02", "PS", OBJ_TEMP);
                    //if (TS_VIEW_MODEL[0].doc_info_para.doc_no != OBJ_TEMP.doc_no)
                    //{
                    //    TS_VIEW_MODEL[0] = new PMS_T002_VM("RS02", "PS", OBJ_TEMP);
                    //    TS_VIEW_MODEL[0].doc_info_para = OBJ_TEMP;
                    //    CURRENT_TS_VM = TS_VIEW_MODEL[0];
                    //}
                    //else
                    //{
                    //    CURRENT_TS_VM = TS_VIEW_MODEL[0];
                    //}
                }

                #endregion
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void OpenChildWindow(object para_obj) // NOTE: reduce load initialize for popup for UserControl by shifting all popup in PMS_T001_VM and bind to the control so that every time usercontrol will not take server trip time. only one time load on project loading. do not load on first time because every project can have differet company.
        {
            CursorControl.SetBusyState();
            STD_LIST_BE OBJ_TEMP = new STD_LIST_BE();
            var item = (DataRowView)para_obj;
            OBJ_TEMP.doc_cat = item["doc_cat"].ToString();
            OBJ_TEMP.doc_type = item["doc_type"].ToString();
            OBJ_TEMP.client = item["client"].ToString();
            OBJ_TEMP.comp_code = item["comp_code"].ToString();
            OBJ_TEMP.location_id = item["location_id"].ToString();
            OBJ_TEMP.project_id = item["project_id"].ToString();
            OBJ_TEMP.project_no = string.IsNullOrWhiteSpace(item["project_no"].ToString()) ? (int?)null : int.Parse(item["project_no"].ToString());
            OBJ_TEMP.project_name = item["project_name"].ToString();
            OBJ_TEMP.emp_id = item["emp_id"].ToString();
            OBJ_TEMP.element_id = item["element_id"].ToString();
            OBJ_TEMP.element_name = item["element_name"].ToString();
            OBJ_TEMP.element_no = string.IsNullOrWhiteSpace(item["element_no"].ToString()) ? (int?)null : int.Parse(item["element_no"].ToString());
            OBJ_TEMP.order_no = item["order_no"].ToString();
            OBJ_TEMP.operation_no = item["operation_no"].ToString();
            OBJ_TEMP.doc_no = item["doc_no"].ToString(); // milestone no
            OBJ_TEMP.ts_code = item["ts_code"].ToString();
            OBJ_TEMP.type_code = item["type_code"].ToString();


            SELECTED_TV_OBJ = OBJ_TEMP;

            if (!string.IsNullOrWhiteSpace(OBJ_TEMP.doc_cat))
            {
                if (OBJ_TEMP.doc_cat == "PS")
                {
                    //if (!TS_VIEW_MODEL.Contains(viewModel))
                    //    TS_VIEW_MODEL.Add(viewModel);

                    //TS_VIEW_MODEL.Add(new PMS_T002_VM("RS02", OBJ_TEMP));
                    //if(TS_VIEW_MODEL[0].con)
                    //if (TS_VIEW_MODEL[0].doc_info_para.doc_no != OBJ_TEMP.doc_no)
                    //{
                    //    TS_VIEW_MODEL[0] = new PMS_T002_VM("RS02", "PS", OBJ_TEMP);
                    //    TS_VIEW_MODEL[0].doc_info_para = OBJ_TEMP;
                    //    CURRENT_TS_VM = TS_VIEW_MODEL[0];
                    //}
                    //else
                    //{
                    //    CURRENT_TS_VM = TS_VIEW_MODEL[0];
                    //}

                    //if (TS_VIEW_MODEL[0].doc_info_para.doc_no != OBJ_TEMP.doc_no || TS_VIEW_MODEL[0].doc_info_para.doc_no == null)
                    //{
                        //TS_VIEW_MODEL[0].doc_info_para = OBJ_TEMP;
                        UC_OBJ = new Reflection.Modules.PMS.Views.PMS_T002();
                        UC_OBJ.DataContext = new PMS_T002_VM("RS02", "PS", OBJ_TEMP);
                    //}
                }
                else if (OBJ_TEMP.doc_cat == "PH")
                {
                    //if (TS_VIEW_MODEL[1].doc_info_para.doc_no != OBJ_TEMP.doc_no)
                    //{
                        //TS_VIEW_MODEL[1].doc_info_para = OBJ_TEMP;
                        UC_OBJ = new Reflection.Modules.PMS.Views.PMS_T003();
                        UC_OBJ.DataContext = new PMS_T003_VM("RS03", "PH", OBJ_TEMP);
                    //}
                }
                else if (OBJ_TEMP.doc_cat == "PHG")
                {
                    if (TS_VIEW_MODEL[1].doc_info_para.doc_no != OBJ_TEMP.doc_no)
                    {
                        TS_VIEW_MODEL[1].doc_info_para = OBJ_TEMP;
                        TS_VIEW_MODEL[1] = new PMS_T003_VM("RS03", "PH", OBJ_TEMP);
                        CURRENT_TS_VM = TS_VIEW_MODEL[1];
                    }
                    else
                    {
                        CURRENT_TS_VM = TS_VIEW_MODEL[1];
                    }
                }
                else if (OBJ_TEMP.doc_cat == "PL")
                {
                    //if (TS_VIEW_MODEL[2].doc_info_para.doc_no != OBJ_TEMP.doc_no)
                    //{
                    //    TS_VIEW_MODEL[2] = new PMS_T005_VM("RS05", "PL", OBJ_TEMP);
                    //    TS_VIEW_MODEL[2].doc_info_para = OBJ_TEMP;
                    //    CURRENT_TS_VM = TS_VIEW_MODEL[2];
                    //}
                    //else
                    //{
                    //    CURRENT_TS_VM = TS_VIEW_MODEL[2];
                    //}

                    //if (TS_VIEW_MODEL[2].doc_info_para.doc_no != OBJ_TEMP.doc_no || TS_VIEW_MODEL[2].doc_info_para.doc_no == null)
                    //{
                        //TS_VIEW_MODEL[2].doc_info_para = OBJ_TEMP;
                        UC_OBJ = new Reflection.Modules.PMS.Views.PMS_T005();
                        UC_OBJ.DataContext = new PMS_T005_VM("RS05", "PL", OBJ_TEMP);
                    //}
                }
                else if (OBJ_TEMP.doc_cat == "PT")
                {
                    //if (TS_VIEW_MODEL[3].doc_info_para.doc_no != OBJ_TEMP.doc_no)
                    //{
                    //    TS_VIEW_MODEL[3] = new PMS_T008_VM("RS08", "PT", OBJ_TEMP);
                    //    TS_VIEW_MODEL[3].doc_info_para = OBJ_TEMP;
                    //    CURRENT_TS_VM = TS_VIEW_MODEL[3];
                    //}
                    //else
                    //{
                    //    CURRENT_TS_VM = TS_VIEW_MODEL[3];
                    //}

                    //if (TS_VIEW_MODEL[3].doc_info_para.doc_no != OBJ_TEMP.doc_no || TS_VIEW_MODEL[3].doc_info_para.doc_no == null)
                    //{
                        //TS_VIEW_MODEL[3].doc_info_para = OBJ_TEMP;
                        UC_OBJ = new Reflection.Modules.PMS.Views.PMS_T008();
                        UC_OBJ.DataContext = new PMS_T008_VM("RS08", "PT", OBJ_TEMP);
                    //}

                }
                else if (OBJ_TEMP.doc_cat == "AT")
                {
                    //TS_VIEW_MODEL[4] = new PMS_T009_VM("RS09", "AT", OBJ_TEMP);
                    //CURRENT_TS_VM = TS_VIEW_MODEL[4];

                    //if (TS_VIEW_MODEL[4].doc_info_para.doc_no != OBJ_TEMP.doc_no)
                    //{
                    //    TS_VIEW_MODEL[4] = new PMS_T009_VM("RS09", "AT", OBJ_TEMP);
                    //    TS_VIEW_MODEL[4].doc_info_para = OBJ_TEMP;
                    //    CURRENT_TS_VM = TS_VIEW_MODEL[4];
                    //}
                    //else
                    //{
                    //    CURRENT_TS_VM = TS_VIEW_MODEL[4];
                    //}

                    //if (TS_VIEW_MODEL[4].doc_info_para.doc_no != OBJ_TEMP.doc_no || TS_VIEW_MODEL[4].doc_info_para.doc_no == null)
                    //{
                        //TS_VIEW_MODEL[4].doc_info_para = OBJ_TEMP;
                        UC_OBJ = new Reflection.Modules.PMS.Views.PMS_T009();
                        UC_OBJ.DataContext = new PMS_T009_VM("RS09", "AT", OBJ_TEMP);
                    //}
                }
                
            }

            //if (!TS_VIEW_MODEL.Contains(viewModel))
            //    TS_VIEW_MODEL.Add(viewModel);

            //CURRENT_TS_VM = TS_VIEW_MODEL
            //    .FirstOrDefault(vm => vm == viewModel);
        }
        private void LoadBackFlipData(object Parameter)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + (REQ_PARA_OBJ.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (REQ_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@PS!@PS!@!@" + AppSessionState.UserID + "!@" + (Utilities.NullIf(REQ_PARA_OBJ.emp_id) ?? AppSessionState.EmpId) + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + (REQ_PARA_OBJ.party_code ?? "") + "!@!@" + REQ_PARA_OBJ.active + "!@" + REQ_PARA_OBJ.t_status + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy");
                MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_SDM_BE>(MC_TEMP, Request, "PMS_T001_BL", "PMS", "LoadAll", 0, "");

                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC_TEMP.BACK_FLIP_LIST.ToList());
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(FLTR_BACKFLIP);

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                CursorControl.SetBusyState();
                STD_LIST_BE ParameterEntityObject = null;

                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList()[0];

                        string Request = "LOAD_TREE_DATA" + "!@" + AppSessionState.client + "!@" + ParameterEntityObject.comp_code + "!@" + ParameterEntityObject.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + ParameterEntityObject.project_id + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm;
                        MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_PMS_BE>(MC_TEMP, Request, "PMS_T001_BL", "PMS", "LoadAll", 0, "");

                        if (ItemsSet != null)
                        {
                            if (ItemsSet.Tables.Count > 0)
                            {
                                ItemsSet.Relations.RemoveAt(0);
                                ItemsSet.Tables.Clear();
                            }
                            ItemsSet.Tables.Add(ConvertToDataTable(MC_TEMP.TREE_LIST_VIEW));
                        }
                        else
                        {
                            ItemsSet.Tables.Add(ConvertToDataTable(MC_TEMP.TREE_LIST_VIEW));
                        }
                        if (ItemsSet.Relations.Count == 0)
                        {
                            ItemsSet.Relations.Add("rsParentChild",
                                    ItemsSet.Tables[0].Columns["node_code"],
                                    ItemsSet.Tables[0].Columns["parent_id"], false);
                            ItemsView = ItemsSet.Tables[0].DefaultView;
                            ItemsView.RowFilter = "parent_id IS NULL"; //see what happens when i am commented out
                        }
                        //MasterEntity = MC_TEMP.PROJECT_LIST[0];
                        // This will open default project window with data. NOTE: we can avoid server trip by adding one query of project in LOAD_TREE_DATA request.
                        if (TS_VIEW_MODEL[0].doc_info_para.doc_no != ParameterEntityObject.project_id)
                        {
                            TS_VIEW_MODEL[0] = new PMS_T002_VM("RS02", "PS", ParameterEntityObject);
                            TS_VIEW_MODEL[0].doc_info_para = ParameterEntityObject;
                            CURRENT_TS_VM = TS_VIEW_MODEL[0];
                        }
                        else
                        {
                            CURRENT_TS_VM = TS_VIEW_MODEL[0];
                        }
                        MainTabIndex = 0;
                    }
                }
                //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
        private void ExecuteReference()
        {
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

        #region Abstract Method
        protected override void OnCreateAction(InquiryActionResult<PMS_T001> result)
        {
            isNewRecord = true;
            MasterEntity = new PMS_T001();
            MasterEntity.ValidateAsync().Wait();
            DefaultValues();

            var msg = new NotificationMessage(ts_code_vm);
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        protected override void OnDiscardAction(InquiryActionResult<PMS_T001> result)
        { }
        protected override void OnFevoriteAction(InquiryActionResult<PMS_T001> result)
        { }
        protected override void OnFlipAction(InquiryActionResult<PMS_T001> result)
        { }
        protected override void OnHelpAction(InquiryActionResult<PMS_T001> result)
        { }
        protected override void OnPrintAction(InquiryActionResult<PMS_T001> result)
        {
            CursorControl.SetBusyState();

            try
            {

                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_id + "!@" + doc_cat_vm + "!@" + (REQ_PARA_OBJ.doc_type ?? doc_cat_vm) + "!@" + MasterEntity.project_id + "!@" + AppSessionState.UserID + "!@" + (Utilities.NullIf(REQ_PARA_OBJ.emp_id) ?? AppSessionState.EmpId) + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + (REQ_PARA_OBJ.party_code ?? "") + "!@!@" + REQ_PARA_OBJ.active + "!@" + REQ_PARA_OBJ.t_status + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy");
                MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_MM_T003>(MC_TEMP, Request, "MM_T003_BL", "MM", "LoadDocumentWithDocumentNumber", 0, "");

                object[] objDataSource = new object[4];
                string[] objDataSourceName = new string[4];

                //MC_TEMP.MasterEntity.Clear();
                //MC_TEMP.MasterEntity.Add(MasterEntity);

                objDataSource[0] = MC_TEMP.PROJECT_LIST;

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[2] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_id).ToList();
                objDataSource[3] = Result;

                objDataSourceName[0] = "dsMaster";
                objDataSourceName[1] = "dsIndentItems";
                objDataSourceName[2] = "dsCompany";
                objDataSourceName[3] = "dsLocation";


                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORT_STD\\TXN\\Indent.rdlc", "");
            }
            catch (Exception ex) { }
        }
        protected override void OnRemoveAction(InquiryActionResult<PMS_T001> result)
        {
        }
        protected override void OnSaveAction(InquiryActionResult<PMS_T001> result)
        {
        }
        protected override void OnDocumentAction()
        { }
        protected override void OnRefreshCommand(InquiryActionResult<PMS_T001> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnLedgerViewCommand(InquiryActionResult<PMS_T001> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnValidateCommand(InquiryActionResult<PMS_T001> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnTraceCommand(InquiryActionResult<PMS_T001> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnMailCommand(InquiryActionResult<PMS_T001> result)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Filters
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
            if (BACKFLIP_COLLECTION != null)
            {
                BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool FLTR_BACKFLIP(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FLTR_STR_BACKFLIP))
                {
                    return (data.doc_no != null && data.doc_no.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                        data.doc_date != null && data.doc_date.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                        data.date_start != null && data.date_start.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                        data.date_end != null && data.date_end.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                        data.project_id != null && data.project_id.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                        data.project_name != null && data.project_name.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                        data.para1 != null && data.para1.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                        data.para2 != null && data.para2.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                        data.short_text != null && data.short_text.ToString().ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                        data.party_code != null && data.party_code.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                        data.party_name != null && data.party_name.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                        data.doc_cat != null && data.ref_doc_cat.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                        data.comp_code != null && data.comp_code.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                        data.t_display != null && data.t_display.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower()) ||
                        data.emp_name != null && data.emp_name.ToLower().Contains(FLTR_STR_BACKFLIP.ToLower())
                       );
                }
                return true;
            }
            return false;
        }

        #endregion

    }

    public interface ITS_VIEW_MODEL
    {
        string Name { get; }
        STD_LIST_BE doc_info_para { get; set; }

    }
}
