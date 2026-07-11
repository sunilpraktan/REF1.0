using System;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.CustomerRelation;
using System.Collections.Generic;
using Reflection.Presentation.ViewModel;
using System.Threading.Tasks;
using System.Reflection;
using System.IO;
using Reflection.Presentation.Core.VirtualDesktops;
using GalaSoft.MvvmLight.Ioc;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Services.Convertors;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.QMS;

namespace Reflection.Modules.ADM.ViewModels
{
    public class ADM_T001_VM : WorkspaceViewModel<Approval>
    {
        #region AutoSuggest TextBox Declaration Region
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _ASDocDesc { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocDesc
        {
            get { return _ASDocDesc; }
            set
            {
                if (_ASDocDesc != value)
                {
                    _ASDocDesc = value;
                    RaisePropertyChanged("ASDocDesc");
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
                    _ASEmployee = value;
                    RaisePropertyChanged("ASEmployee");
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
                    _ASStatus = value;
                    RaisePropertyChanged("ASStatus");
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
                    _ASDefault = value;
                    RaisePropertyChanged("ASDefault");
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
            try
            {
                if (dgCellInfo != null)
                {
                    var column = dgCellInfo.Column as DataGridColumn;
                    if (column != null)
                    {
                        string headerName = column.Header.ToString();
                        string SourceName = column.SortMemberPath.ToString();
                        if (SourceName == "EmpName")
                        { ASDefault = ASEmployee; }
                    }
                }
            }
            catch (Exception ex) { }
        }

        #endregion

        #region Variable Declaration
        WebServiceRepository<string> repository2 = new WebServiceRepository<string>();
        WebServiceRepository<List<Approval>> repository = new WebServiceRepository<List<Approval>>();
        WebServiceRepository<MultipleContext_DocApprove> repository_MC = new WebServiceRepository<MultipleContext_DocApprove>();
        ObjectSerializationService obj = new ObjectSerializationService();

        MultipleContext_DocApprove _MC = new MultipleContext_DocApprove();
        public MultipleContext_DocApprove MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value;

                    RaisePropertyChanged("MC");
                }
            }
        }

        MultipleContext_DocApprove _MCTemp = new MultipleContext_DocApprove();
        public MultipleContext_DocApprove MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value;
                    RaisePropertyChanged("MCTemp");
                }
            }
        }

        private int _dgSelectedIndex;
        public int dgSelectedIndex
        {
            get
            {
                return _dgSelectedIndex;
            }
            set
            {
                if (_dgSelectedIndex != value)
                {

                    _dgSelectedIndex = value;
                    RaisePropertyChanged("dgSelectedIndex");
                }
            }
        }

        private List<ADM_M043_P> _WorkflowDataListCollection;
        public List<ADM_M043_P> WorkflowDataListCollection
        {
            get { return _WorkflowDataListCollection; }
            set
            {
                if (_WorkflowDataListCollection != value)
                {
                    _WorkflowDataListCollection = value;
                    RaisePropertyChanged("_WorkflowDataListCollection");
                }
            }
        }

        #endregion Variable Declaration

        #region ICollectionView
        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            private set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
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

        private List<Approval> _RequestList;
        public List<Approval> RequestList
        {
            get { return _RequestList; }
            set
            {
                if (_RequestList != value)
                {
                    _RequestList = value;
                    RaisePropertyChanged("RequestList");
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

        private ICollectionView _selectedGridCollection;
        public ICollectionView SelectedGridCollection
        {
            get { return _selectedGridCollection; }
            private set { _selectedGridCollection = value; RaisePropertyChanged("SelectedGridCollection"); }
        }

        #endregion ICollectionView

        #region Relay Commands Declaration
        public RelayCommand<object> CommandViewDocument { get; private set; }
        public RelayCommand<object> CmdFilterApprovals { get; private set; }
        public RelayCommand<object> CmdAddEmployee { get; private set; }
        public RelayCommand<object> CmdForwardTo { get; private set; }
        public RelayCommand<object> CmdAddDocDesc { get; private set; }
        public RelayCommand<object> CmdInsert_t_status { get; private set; }

        #endregion Relay Commands Declaration

        #region   Selected List

        private Approval _masterentity;
        public Approval MasterEntity
        {
            get { return _masterentity; }

            set
            {
                if (_masterentity != value)
                {
                    _masterentity = value;

                    RaisePropertyChanged("MasterEntity");

                }
            }

        }
        private Approval _SELECTED_OBJ;
        public Approval SELECTED_OBJ
        {
            get { return _SELECTED_OBJ; }

            set
            {
                _SELECTED_OBJ = value;
                RaisePropertyChanged("SELECTED_OBJ");
            }

        }
        private List<Approval> _SelectedList;
        public List<Approval> SelectedList
        {
            get
            {

                return _SelectedList;
            }
            set
            {
                if (_SelectedList != value)
                {
                    _SelectedList = value;

                    RaisePropertyChanged("SelectedList");

                }
            }
        }

        private List<ADM_M002> _CompanyList = new List<ADM_M002>();
        public List<ADM_M002> CompanyList
        {
            get { return _CompanyList; }
            set
            {
                if (_CompanyList != value)
                {
                    _CompanyList = value;
                }
            }
        }

        #endregion Selected List

        #region Constructor
        public ADM_T001_VM(string ts_code) : base()
        {
            NotificationDataCollection = new List<NotificationData>();
            RequestList = new List<Approval>();
            MasterEntity = new Approval();
            SELECTED_OBJ = new Approval();

            CommandViewDocument = new RelayCommand<object>(items => { if (items == null) { return; } ViewDocument(items); });
            CmdFilterApprovals = new RelayCommand<object>(items => { if (items == null) { return; } FilterApproval(items); });
            CmdAddEmployee = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmployee(items); });
            CmdForwardTo = new RelayCommand<object>(items => { if (items == null) { return; } ForwardTo(items); });
            CmdAddDocDesc = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocDesc(items); });
            CmdInsert_t_status = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_t_status(cmdPara); });
            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void Inspection_Processing_RR_Call(object item)
        {
            try
            {
                if (SELECTED_OBJ != null)
                {
                    QMS_T003 IL_OBJ = new QMS_T003();
                    IL_OBJ.doc_no = SELECTED_OBJ.doc_no;
                    IL_OBJ.doc_cat = SELECTED_OBJ.doc_cat;
                    IL_OBJ.doc_type = SELECTED_OBJ.doc_type;
                    IL_OBJ.comp_code = SELECTED_OBJ.comp_code;
                    IL_OBJ.location_id = SELECTED_OBJ.location_id;
                    IL_OBJ.tl_code = SELECTED_OBJ.tl_code;
                    IL_OBJ.ts_code = "QM29";
                    IL_OBJ.userid = AppSessionState.UserID;
                    IL_OBJ.session_id = AppSessionState.session_id;
                    IL_OBJ.client = AppSessionState.client;

                    AppSessionState.ViewTitle = "Inspection Processing : Result Recording";
                    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.QMS.dll");
                    Assembly assembly = Assembly.LoadFile(path1);
                    Type type = assembly.GetType("Reflection.Modules.QMS.Views.QMS_T012");
                    if (type != null)
                    {
                        dynamic instance = Activator.CreateInstance(type, "QM29", IL_OBJ.doc_no, IL_OBJ);
                        SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
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
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.UserID + "!@" + MasterEntity.doc_cat + "!@" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(DateTime.Now.ToShortDateString()).ToString("MM/dd/yyyy") + "!@"; // + "02";
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_DocApprove>(MC, Request, "ADM_T001_BL", "ADM", "", 0, "");

                SelectedList = MC.ApprovalList;

                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                WorkflowDataListCollection = MC.WorkFlowList;

                NotificationDataCollection = MC.NotificationData;

                AttachmentCollection = MC.Attachment;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M043_D_P)x).doc_desc);
                TheFilter = (o, prefix) => (((ADM_M043_D_P)o).doc_desc.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M043_D_P)o).ref_doc_cat.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                ASDocDesc = new AutoSuggestTextViewModel<dynamic>(MC.DocDesc, TheFilter, SuggestedValue, "doc_desc", true);
                ASDocDesc.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpName);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpName.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpId.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                ASEmployee = new AutoSuggestTextViewModel<dynamic>(MC.Employees, TheFilter, SuggestedValue, "user_name", "EmpName", true);
                ASEmployee.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASStatus = new AutoSuggestTextViewModel<dynamic>(MC.StatusData, TheFilter, SuggestedValue, "t_status", true);
                ASStatus.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpName);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpName.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpId.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.Employees, TheFilter, SuggestedValue, "user_name", "EmpName", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                DateTime d = DateTime.UtcNow;
                d = d.AddDays(-7);
                MasterEntity.FrmDate = d;
                MasterEntity.ToDate = DateTime.UtcNow;
                MasterEntity.t_display = "Pending";
                MasterEntity.appro_status = "01";

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
                List<Approval> RequestList = new List<Approval>();
                foreach (Approval item in SelectedList)
                {
                    if (item.Click == true)
                    {
                        RequestList.Add(item);
                        List<NotificationData> objNotifyData = new List<NotificationData>();
                        List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>()
                        {
                            new KeyValuePair<string, string>("[EMP]",RequestList[0].CreatorName),
                            new KeyValuePair<string, string>("[DOC]",RequestList[0].doc_desc),
                            new KeyValuePair<string, string>("[DOCNO]",RequestList[0].doc_no),
                            new KeyValuePair<string, string>("[DOCDATE]",RequestList[0].create_date.ToString()),
                            new KeyValuePair<string,string>("[APRNE]",RequestList[0].ApproverName),
                            new KeyValuePair<string, string>("[APRDATE]",DateTime.Now.ToString()),
                            new KeyValuePair<string, string>("[COMP]",AppSessionState.CompanyName),
                            new KeyValuePair<string, string>("[Attn]",MC.NotificationData[0].EmpName),
                        };

                        objNotifyData = NotificationDataCollection.Where(x => x.alert_name == AlertName && x.doc_cat == RequestList[0].doc_cat).ToList();

                        foreach (NotificationData VarData in objNotifyData)
                        {
                            foreach (KeyValuePair<string, string> kvp in kvpList)
                            {
                                VarData.subject = VarData.subject.Replace(kvp.Key, kvp.Value);
                                VarData.msg_body = VarData.msg_body.Replace(kvp.Key, kvp.Value);
                            }
                            Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, MC.ApprovalList[0].CreatorEmailId, MC.ApprovalList[0].ApproverEmailId, VarData.bcc_mail_id, VarData.subject, VarData.msg_body, null);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void ViewDocumentOrg(object InputValue)
        {
            try
            {
                Approval POPUPEntityObject = null;
                SYS_AUTH userAuth = new SYS_AUTH();
                if (InputValue != null && ((IEnumerable)InputValue).Cast<Approval>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<Approval>().ToList()[0];
                    //ReSet default company
                    AppSessionState.comp_code = POPUPEntityObject.comp_code;
                    AppSessionState.location_Id = POPUPEntityObject.location_id;
                    AppSessionState.OBJ_COMPANY = AppSessionState.COMPANY_LIST.Where(item => item.comp_code == POPUPEntityObject.comp_code).ToList()[0];
                    AppSessionState.OBJ_LOCATION = AppSessionState.LOCATION_LIST.Where(item => item.location_id == POPUPEntityObject.location_id && item.comp_code == POPUPEntityObject.comp_code).ToList()[0];
                    //AppSessionState.AppsessionNotifyobject.CurrenctCompany = AppSessionState.OBJ_COMPANY.comp_name;

                    Messenger.Default.Send<NotificationMessage>(new NotificationMessage("RESET"));
                }
                var docdetails = ((List<SYS_AUTH>)AppSessionState.ADM_AUTH_LIST).Where(X => X.ts_code == POPUPEntityObject.TranCode).FirstOrDefault();
                userAuth = docdetails;
                //AppSessionState.UserAuthSingle = userAuth;
                AppSessionState.ViewTitle = userAuth.ts_name;
                AppSessionState.TransValue = POPUPEntityObject.doc_no;
                AppSessionState.TransValueType = POPUPEntityObject.doc_no;
                AppSessionState.TransParameter = "NO";
                AppSessionState.ViewOtherRecordAllowed = false;
                //AppSessionState.TransId = userAuth.menu_code.ToString();
                AppSessionState.TransactionCode = userAuth.ts_code;

                if (userAuth.class_file != null && userAuth.class_file != "")
                {
                    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userAuth.ts_namespace);
                    Assembly assembly = Assembly.LoadFile(path1);
                    Type type = assembly.GetType(userAuth.class_file);
                    if (type != null)
                    {
                        dynamic instance = Activator.CreateInstance(type, userAuth.ts_code, POPUPEntityObject.doc_no);
                        SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
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
        private void ViewDocument(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                ReflectionFunctionService objRef = new ReflectionFunctionService();
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    
                    AppSessionState.comp_code = SELECTED_OBJ.comp_code;
                    AppSessionState.location_Id = SELECTED_OBJ.location_id;
                    AppSessionState.OBJ_COMPANY = AppSessionState.COMPANY_LIST.Where(item => item.comp_code == SELECTED_OBJ.comp_code).ToList()[0];
                    AppSessionState.OBJ_LOCATION = AppSessionState.LOCATION_LIST.Where(item => item.location_id == SELECTED_OBJ.location_id && item.comp_code == SELECTED_OBJ.comp_code).ToList()[0];

                    STD_LIST_BE OBJ_BE = new STD_LIST_BE();
                    OBJ_BE.doc_no = InputValue.ToString();
                    OBJ_BE.ts_code = SELECTED_OBJ.ts_code;
                    OBJ_BE.doc_cat = SELECTED_OBJ.doc_cat;
                    OBJ_BE.doc_type = SELECTED_OBJ.doc_type;
                    OBJ_BE.comp_code = SELECTED_OBJ.comp_code;
                    OBJ_BE.location_id = SELECTED_OBJ.location_id;
                    OBJ_BE.req_code = "VIEW";
                    OBJ_BE.request = "VIEW_DOC" + "!@" + AppSessionState.client + "!@" + OBJ_BE.comp_code + "!@" + OBJ_BE.location_id + "!@" + OBJ_BE.doc_cat + "!@" + OBJ_BE.doc_type + "!@" + OBJ_BE.doc_no;
                    if (SELECTED_OBJ.doc_cat == "IL") // NOTE: hardcoded for inspection lot, this will open result recording instead of Lot. this is temp provision.
                    {
                        Inspection_Processing_RR_Call(SELECTED_OBJ);
                    }
                    else
                    {
                        objRef.Invoke_Documet(OBJ_BE);
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertEmployee(object InputValue)
        {
            string Request = "";
            ADM_M024_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Employees.Where(x => x.EmpName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M024_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.UserId = POPUPEntityObject.UserId;
                    MasterEntity.approver_id = POPUPEntityObject.EmpId;
                    MasterEntity.user_name = POPUPEntityObject.EmpName;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertDocDesc(object InputValue)
        {
            string Request = "";
            ADM_M043_D_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DocDesc.Where(x => x.doc_desc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M043_D_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M043_D_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.doc_cat = POPUPEntityObject.ref_doc_cat;
                    MasterEntity.doc_desc = POPUPEntityObject.doc_desc;
                }
            }
            catch (Exception ex) { }
        }
        private void ForwardTo(object InputValue)
        {
            string Request = "";
            Approval POPUPEntityObject = null;
            try
            {
                if (InputValue != null && ((IEnumerable)InputValue).Cast<Approval>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<Approval>().ToList()[0];
                }
                Request = POPUPEntityObject.doc_type + "!@" + POPUPEntityObject.doc_no + "!@" + POPUPEntityObject.ts_code + "!@" + POPUPEntityObject.UserId + "!@" + POPUPEntityObject.authority + "!@" + MasterEntity.approver_id + "!@" + AppSessionState.UserID + "!@" + "Forwarded" + "!@" + MasterEntity.remarks;
                string strReturn = repository2.GetDataWithReturnDomainObject<string>("", Request, "ApprovalInsert", "Communication", "", 0, "");

                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Record has been forwarded...");
                showMessageService.ShowMessage();
            }
            catch (Exception ex) { }
        }
        private void FilterApproval(object InputValue)
        {
            try
            {
                string Request = "REFRESH" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.UserID + "!@" + MasterEntity.doc_cat + "!@" + Convert.ToDateTime(MasterEntity.FrmDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.ToDate).ToString("MM/dd/yyyy") + "!@" + MasterEntity.appro_status;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_DocApprove>(MCTemp, Request, "ADM_T001_BL", "ADM", "", 0, "");

                SelectedList = MCTemp.ApprovalList;
                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);
            }
            catch (Exception ex) { }
        }
        private void Insert_t_status(object InputValue)
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
                            { POPUPEntityObject = MC.StatusData.Where(x => x.t_status.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_display.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.appro_status = POPUPEntityObject.t_status;
                    MasterEntity.t_display = POPUPEntityObject.t_display;
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


        #region Abstract Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<Approval> result)
        {
            try
            {
                List<Approval> RequestList = new List<Approval>();
                foreach (Approval item in SelectedList)
                {
                    if (item.Click == true)
                    {
                        item.appro_status = "05";
                        RequestList.Add(item);
                    }
                }
                string strReturn = repository.Save<List<Approval>>(RequestList, "ADM_T001_BL", "ADM");
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
        protected override void OnCreateAction(InquiryActionResult<Approval> result)
        {
            try
            {
                List<Approval> RequestList = new List<Approval>();
                foreach (Approval item in SelectedList)
                {
                    if (item.Click == true)
                    {
                        if (item.authority == "Decision")
                        {
                            item.appro_status = "02";
                            item.editby = AppSessionState.UserID;
                            RequestList.Add(item);
                        }
                    }
                }
                string strReturn = repository.Update<List<Approval>>(RequestList, "ADM_T001_BL", "ADM");
                foreach (Approval item in SelectedList)
                {
                    if (item.Click == true)
                    {
                        //if (RequestList[0].doc_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnInsert") >= 0)
                        //{
                        //    NotifyMessage("OnInsert");
                        //}
                        if (RequestList[0].doc_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnApprovalDone") >= 0)
                        {
                            NotifyMessage("OnApprovalDone");
                        }
                    }
                }
                //for (int i = SelectedList.Count - 1; i >= 0; i--)
                //{
                //    if (SelectedList[i].Click == true)
                //    {
                //        SelectedList.Remove(SelectedList[i]);
                //    }
                //}
                SelectedList = (from o in SelectedList where o.appro_status != "02" select o).ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);
            }
            catch (Exception ex)
            {

            }
        }
        protected override void OnRemoveAction(InquiryActionResult<Approval> result)
        {
            List<Approval> RequestList = new List<Approval>();
            foreach (Approval item in SelectedList)
            {
                if (item.Click == true)
                {
                    item.appro_status = "08";
                    item.editby = AppSessionState.UserID;
                    RequestList.Add(item);
                }
            }
            string strReturn = repository.Save<List<Approval>>(RequestList, "ADM_T001_BL", "ADM");
        }
        protected override void OnDiscardAction(InquiryActionResult<Approval> result)
        {
            try
            {
                string Request = "REFRESH" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.UserID + "!@" + MasterEntity.doc_cat + "!@" + Convert.ToDateTime(MasterEntity.FrmDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.ToDate).ToString("MM/dd/yyyy") + "!@" + MasterEntity.appro_status;
                //string Request = "REFRESH" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.UserID;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_DocApprove>(MCTemp, Request, "ADM_T001_BL", "ADM", "", 0, "");

                SelectedList = MCTemp.ApprovalList;

                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);

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
        protected override void OnFevoriteAction(InquiryActionResult<Approval> result)
        {
        }
        protected override void OnFlipAction(InquiryActionResult<Approval> result)
        {
        }
        protected override void OnHelpAction(InquiryActionResult<Approval> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<Approval> result)
        {
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<Approval> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<Approval> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<Approval> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<Approval> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<Approval> result)
        {
            throw new NotImplementedException();
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
                FilterCollection();
            }
        }
        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as Approval;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_FlipGrid))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.create_date != null && data.create_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.doc_desc != null && data.doc_desc.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.note_subject != null && data.note_subject.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.obj_name != null && data.obj_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.order_no != null && data.order_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           //(data.obj_name != null && data.obj_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.party_name != null && data.party_name.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.approvar_remark != null && data.approvar_remark.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.CreatorName != null && data.CreatorName.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.appro_status != null && data.appro_status.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.note_messagebody != null && data.note_messagebody.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.remarks != null && data.remarks.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.sender != null && data.sender.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));

                }
                return true;
            }
            return false;
        }



        #endregion
    }
}
