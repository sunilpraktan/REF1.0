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
//using Reflection.BusinessEntity.PMS.ViewModels;
using Reflection.BusinessEntity.ADM;
using System.Data;
using Reflection.BusinessEntity.FICO;

namespace Reflection.Modules.PMS.ViewModels
{
    public class PMS_T003_VM : WorkspaceViewModel<PMS_T001>, ITS_VIEW_MODEL
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

        private AutoSuggestTextViewModel<dynamic> _AS_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_TYPE
        {
            get { return _AS_TYPE; }
            set
            {
                if (_AS_TYPE != value)
                {
                    _AS_TYPE = value; RaisePropertyChanged("AS_TYPE");
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

        private AutoSuggestTextViewModel<dynamic> _AS_CURRENCY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CURRENCY
        {
            get { return _AS_CURRENCY; }
            set
            {
                if (_AS_CURRENCY != value)
                {
                    _AS_CURRENCY = value; RaisePropertyChanged("AS_CURRENCY");
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
        private AutoSuggestTextViewModel<dynamic> _AS_PHASE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PHASE
        {
            get { return _AS_PHASE; }
            set
            {
                if (_AS_PHASE != value)
                {
                    _AS_PHASE = value; RaisePropertyChanged("AS_PHASE");
                }
            }
        }



        #endregion

        #region Variable Declaration

        WebServiceRepository<PMS_T002> REPO = new WebServiceRepository<PMS_T002>();
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

        private PMS_T002 _MasterEntity;
        public PMS_T002 MasterEntity
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
        public RelayCommand<object> cmdInsertCompany { get; private set; }
        public RelayCommand<object> cmdInsertLocation { get; private set; }
        public RelayCommand<object> cmdInsertStatus { get; private set; }
        public RelayCommand<object> cmdInsertType { get; private set; }
        public RelayCommand<object> cmdInsertEmployee { get; private set; }
        public RelayCommand<object> cmdInsertParty { get; private set; }
        public RelayCommand<object> cmdInsertCurrency { get; private set; }
        public RelayCommand<STD_LIST_BE> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdOpenAttachments { get; private set; }
        public RelayCommand<object> cmdCreate { get; private set; }
        public RelayCommand<object> cmdSave { get; private set; }
        public RelayCommand<object> cmdDocumentAttachment { get; private set; }

        #endregion

        #region DefalutValue
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_cat = doc_cat_vm;
            MasterEntity.doc_type = doc_cat_vm;
            MasterEntity.location_id = ProjectEntity.location_id;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.active = "1";
            MasterEntity.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
            MasterEntity.t_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_display).FirstOrDefault();
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.emp_id = AppSessionState.EmpId;
            MasterEntity.emp_name = AppSessionState.EmpName;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;

            MasterEntity.client = AppSessionState.client;
            MasterEntity.comp_code = CTR_PARA_OBJ.comp_code;
            MasterEntity.project_id = CTR_PARA_OBJ.project_id;
            MasterEntity.pro_type = ProjectEntity.pro_type;
            MasterEntity.curr_code = ProjectEntity.curr_code;
            MasterEntity.cc_code = ProjectEntity.cc_code;
            MasterEntity.pc_code = ProjectEntity.pc_code;
            MasterEntity.party_code = ProjectEntity.party_code;
            MasterEntity.party_name = ProjectEntity.party_name;
            MasterEntity.project_no = CTR_PARA_OBJ.project_no;
            MasterEntity.project_name = CTR_PARA_OBJ.project_name;
            MasterEntity.parent_id = (string.IsNullOrWhiteSpace(CTR_PARA_OBJ.element_id) ? null : CTR_PARA_OBJ.element_id);
            MasterEntity.seq_no = 1;

            ScheduleEntity.active = "1";
            ScheduleEntity.client = AppSessionState.client;
            ScheduleEntity.comp_code = MasterEntity.comp_code;
            ScheduleEntity.date_actual = DateTime.Now;
            ScheduleEntity.date_actual_finish = DateTime.Now;
            ScheduleEntity.date_finish = DateTime.Now;
            ScheduleEntity.date_forecast = DateTime.Now;
            ScheduleEntity.date_forecast_finish = DateTime.Now;
            ScheduleEntity.date_schedule = DateTime.Now;
            ScheduleEntity.length_actual =0;
            ScheduleEntity.length_forecast = 0;
            ScheduleEntity.length_schedule = 0;
            ScheduleEntity.project_id = MasterEntity.project_id;
            ScheduleEntity.project_no = MasterEntity.project_no;
            ScheduleEntity.date_revised = DateTime.Now;

            MainTabIndex = 1;
            
        }
        #endregion

        #region Constructor
        public PMS_T003_VM(string ts_code, string doc_cat) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            MasterEntity = new PMS_T002();
            ProjectEntity = new PMS_T001();
            ScheduleEntity = new PMS_T006();
            CTR_PARA_OBJ = new STD_LIST_BE();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            MC = new MC_PMS_BE();
            MC_TEMP = new MC_PMS_BE();
            PMS_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            sms = this.GetViewService<IShowMessageViewService>();
            CommandInitialization();
            LoadInitialData();
            DefaultValues();
        }
        public PMS_T003_VM(string ts_code, string doc_cat, STD_LIST_BE para_obj) : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            MasterEntity = new PMS_T002();
            ScheduleEntity = new PMS_T006();
            ProjectEntity = new PMS_T001();
            CTR_PARA_OBJ = new STD_LIST_BE();
            CTR_PARA_OBJ = para_obj;
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            MC = new MC_PMS_BE();
            MC_TEMP = new MC_PMS_BE();
            PMS_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            sms = this.GetViewService<IShowMessageViewService>();
            CommandInitialization();
            LoadInitialData();
            DefaultValues();
            //if (!string.IsNullOrWhiteSpace(para_obj.doc_no))
            //{
            //    LoadDocumentByDocumentNumber(para_obj);
            //}
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
                cmdInsertCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
                cmdInsertLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertLocation(items); });
                cmdInsertStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertStatus(items); });
                cmdInsertType = new RelayCommand<object>(items => { if (items == null) { return; } InsertType(items); });
                cmdInsertEmployee = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertEmployee(cmdPara); });
                cmdInsertParty = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertParty(cmdPara); });
                cmdInsertCurrency = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCurrency(cmdPara); });
                cmdLoadDocumentByDocumentNumber = new RelayCommand<STD_LIST_BE>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara); }); // confirm assignment
                cmdCreate = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Create(cmdPara); });
                cmdSave = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Save(cmdPara); });
                //cmdOpenAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenDocumentViewer(cmdPara); });
                cmdDocumentAttachment = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DocumentAttachment(cmdPara); });
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
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + (CTR_PARA_OBJ.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (CTR_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + (CTR_PARA_OBJ.project_id ?? "") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + CTR_PARA_OBJ.org_code + "!@" + (CTR_PARA_OBJ.group_code ?? "");
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_SDM_BE>(MC, Request, "PMS_T002_BL", "PMS", "LoadAll", 0, "");

                if(MC.PROJECT_LIST != null)
                {
                    if(MC.PROJECT_LIST.Count > 0)
                    {
                        ProjectEntity = MC.PROJECT_LIST[0];
                    }
                }
                #region Autosuggest

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                //TheFilter = (o, prefix) => (((ADM_M0002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0002)o).comp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", true);
                //AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(MC.LOCATION_LIST, TheFilter, SuggestedValue, "location_id", true);
                AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = false; AS_LOCATION.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_STATUS = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_status", true);
                AS_STATUS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_STATUS.AutoSuggestVM.IsFreeTextAllowed = false;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).type_code);
                //TheFilter = (o, prefix) => (((STD_LIST_BE)o).type_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).type_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //AS_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.TYPE_LIST, TheFilter, SuggestedValue, "type_code", true);
                //AS_TYPE.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id);
                TheFilter = (o, prefix) => (((STD_PERSONNEL)o).emp_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PERSONNEL)o).emp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_EMPLOYEE = new AutoSuggestTextViewModel<dynamic>(MC.PERSONNEL_LIST, TheFilter, SuggestedValue, "emp_id", true);
                AS_EMPLOYEE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_EMPLOYEE.AutoSuggestVM.IsFreeTextAllowed = false;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PARTY)x).party_code);
                //TheFilter = (o, prefix) => (((STD_PARTY)o).party_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PARTY)o).party_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //AS_PARTY = new AutoSuggestTextViewModel<dynamic>(MC.PARTY_LIST, TheFilter, SuggestedValue, "party_code", true);
                //AS_PARTY.AutoSuggestVM.IsEmptyValueAllowed = true;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((FICO_M0033)x).curr_code);
                //TheFilter = (o, prefix) => (((FICO_M0033)o).curr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((FICO_M0033)o).curr_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //AS_CURRENCY = new AutoSuggestTextViewModel<dynamic>(MC.CURR_LIST, TheFilter, SuggestedValue, "curr_code", true);
                //AS_CURRENCY.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_UOM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((FICO_M0019)x).cc_code);
                TheFilter = (o, prefix) => (((FICO_M0019)o).cc_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((FICO_M0019)o).cc_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COST_CENTER = new AutoSuggestTextViewModel<dynamic>(MC.COST_CENTER_LIST, TheFilter, SuggestedValue, "cc_code", true);
                AS_COST_CENTER.AutoSuggestVM.IsEmptyValueAllowed = true; AS_COST_CENTER.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((FICO_M0020)x).pc_code);
                TheFilter = (o, prefix) => (((FICO_M0020)o).pc_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((FICO_M0020)o).pc_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_PROFIT_CENTER = new AutoSuggestTextViewModel<dynamic>(MC.PROFIT_CENTER_LIST, TheFilter, SuggestedValue, "pc_code", true);
                AS_PROFIT_CENTER.AutoSuggestVM.IsEmptyValueAllowed = true; AS_PROFIT_CENTER.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).element_name);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).element_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).element_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_PHASE = new AutoSuggestTextViewModel<dynamic>(MC.PHASE_LIST, TheFilter, SuggestedValue, "element_name", true);
                AS_PHASE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_PHASE.AutoSuggestVM.IsFreeTextAllowed = true;

                #endregion
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
                if (!string.IsNullOrEmpty(MasterEntity.element_id))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.element_id.Replace("/", "--"), DocumentList = MC_TEMP.ATTACHMENT_LIST, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
                }
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
                MasterEntity = new PMS_T002();
                ScheduleEntity = new PMS_T006();
                MasterEntity.ValidateAsync().Wait();
                DefaultValues();

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
                    if (string.IsNullOrWhiteSpace(MasterEntity.element_id))
                    {
                        isNewRecord = true;
                    }
                    else
                    {
                        isNewRecord = false;
                    }
                    MasterEntity.ts_code = ts_code_vm;
                    MasterEntity.userid = AppSessionState.UserID;
                    MasterEntity.XDOC_A = SER_OBJ.ObjectToXML(ScheduleEntity);

                    if (isNewRecord == true)
                    {
                        MasterEntity = REPO.SaveWithReturnDomainObject<PMS_T002>(MasterEntity, "PMS_T002_BL", "PMS");
                        if (!string.IsNullOrWhiteSpace(MasterEntity.XDOC_A))
                        {
                            //ScheduleEntity.Clear();
                            MC.SCHEDULE_LIST = (List<PMS_T006>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_A, MC.SCHEDULE_LIST);
                            MC_TEMP.SCHEDULE_LIST = MC.SCHEDULE_LIST;
                            if (MC.SCHEDULE_LIST.Where(x => x.active == "1").ToList().Count > 0)
                            {
                                ScheduleEntity = MC.SCHEDULE_LIST.Where(x => x.active == "1").ToList()[0];
                            }
                            else
                            {
                                ScheduleEntity = new PMS_T006();
                            }
                        }
                        List<STD_LIST_BE> SLBE = new List<STD_LIST_BE>();
                        STD_LIST_BE SLBE_TEMP = new STD_LIST_BE();

                        SLBE_TEMP.client = MasterEntity.client;
                        SLBE_TEMP.ts_code = MasterEntity.ts_code;
                        SLBE_TEMP.comp_code = MasterEntity.comp_code;
                        SLBE_TEMP.location_id = MasterEntity.location_id;
                        SLBE_TEMP.project_id = MasterEntity.project_id;
                        SLBE_TEMP.element_id = MasterEntity.element_id;
                        //SLBE.value_code = "REFRESH_PS";
                        SLBE.Add(SLBE_TEMP);
                        Messenger.Default.Send<NotificationMessage>(new NotificationMessage(SLBE, "REFRESH_PS"));
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = REPO.UpdateWithReturnDomainObject<PMS_T002>(MasterEntity, "PMS_T002_BL", "PMS");
                        if (!string.IsNullOrWhiteSpace(MasterEntity.XDOC_A))
                        {
                            //ScheduleEntity.Clear();
                            MC.SCHEDULE_LIST = (List<PMS_T006>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_A, MC.SCHEDULE_LIST);
                            MC_TEMP.SCHEDULE_LIST = MC.SCHEDULE_LIST;
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

                    ScheduleEntity.ind_revised = null;
                    isNewRecord = false;
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = "Record save successfully!"; sms.ShowMessage();

                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertCompany(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0002 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.COMPANY_LIST.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0002>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    if (MasterEntity.comp_code != POPUPEntityObject.comp_code)
                    {
                        MasterEntity.comp_code = POPUPEntityObject.comp_code;
                    }
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
        private void InsertType(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.TYPE_LIST.Where(x => x.type_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.pro_type = POPUPEntityObject.type_code;
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
        private void InsertParty(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                STD_PARTY POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.PARTY_LIST.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_PARTY>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.party_code = POPUPEntityObject.party_code;
                    MasterEntity.party_name = POPUPEntityObject.party_name;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void InsertCurrency(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M037 POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.CURRENCY_LIST.Where(x => x.curr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M037>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.curr_code = POPUPEntityObject.curr_code;
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

                string Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + ParameterObject.comp_code + "!@" + ParameterObject.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + ParameterObject.doc_no + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm;
                MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_PMS_BE>(MC_TEMP, Request, "PMS_T002_BL", "PMS", "LoadAll", 0, "");
                if (MC_TEMP.ELEMENT_LIST != null)
                {
                    if (MC_TEMP.ELEMENT_LIST.Count > 0)
                    {
                        MasterEntity = MC_TEMP.ELEMENT_LIST[0];
                    }
                    if (MC_TEMP.SCHEDULE_LIST != null)
                    {
                        if (MC_TEMP.SCHEDULE_LIST.Count > 0)
                        {
                            if (MC_TEMP.SCHEDULE_LIST.Where(x => x.active == "1").ToList().Count > 0)
                            {
                                ScheduleEntity = MC_TEMP.SCHEDULE_LIST.Where(x => x.active == "1").ToList()[0];
                            }
                            else
                            {
                                ScheduleEntity = new PMS_T006();
                            }
                        }
                    }
                    Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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
                if (!string.IsNullOrWhiteSpace(InputValue.element_id) && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(InputValue);
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
                if (MasterEntity.comp_code == null)
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please input Company........"); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.location_id == null)
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please input Location........"); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.emp_id == null)
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please input Responsible Person........"); sms.ShowMessage();
                    return false;
                }
                if (MasterEntity.curr_code == null)
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please input Currency........"); sms.ShowMessage();
                    return false;
                }
                if (ScheduleEntity.date_schedule.HasValue && ProjectEntity.date_start.HasValue)
                {
                    if (ScheduleEntity.date_schedule.Value.Date < ProjectEntity.date_start.Value.Date)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Scheduled Start Date should not less than Master Project Start Date!");
                        showMessageService.ShowMessage();

                        return false;
                    }
                }
                if (ScheduleEntity.date_finish.HasValue && ScheduleEntity.date_finish.HasValue)
                {
                    if (ScheduleEntity.date_finish.Value.Date > ProjectEntity.date_end.Value.Date)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Scheduled End Date should not exceed date of Master Project End Date!");
                        showMessageService.ShowMessage();

                        return false;
                    }
                    if (ScheduleEntity.date_finish.Value.Date < ProjectEntity.date_start.Value.Date || ScheduleEntity.date_finish.Value.Date < ScheduleEntity.date_schedule.Value.Date)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Scheduled End Date should not less than start date of Phase Element or Project Start Date!");
                        showMessageService.ShowMessage();

                        return false;
                    }
                }

                
                //if (MasterEntity.uom_time == null)
                //{
                //    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Required"; sms.Text = String.Format("Please input Project Name........"); sms.ShowMessage();
                //    return false;
                //}

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
        protected override void OnCreateAction(InquiryActionResult<PMS_T001> result)
        {
            isNewRecord = true;
            MasterEntity = new PMS_T002();
            MasterEntity.ValidateAsync().Wait();
            DefaultValues();
            Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
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

    }
}
