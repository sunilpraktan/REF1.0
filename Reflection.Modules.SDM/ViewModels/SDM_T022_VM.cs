using System;
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
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;
using System.Reflection;
using System.IO;
using Reflection.Presentation.Core.VirtualDesktops;
using GalaSoft.MvvmLight.Ioc;

namespace Reflection.Modules.SDM.ViewModels
{
    public class SDM_T022_VM : WorkspaceViewModel<STD_LIST_BE>
    {
        #region . Variable Declaration And Object .
        bool NewRecord = true;
        WebServiceRepository<MC_MM_T001> REPO_MC = new WebServiceRepository<MC_MM_T001>();
        ObjectSerializationService obj = new ObjectSerializationService();
        IShowMessageViewService sms;

        private MC_MM_T001 _MC;
        public MC_MM_T001 MC
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

        private STD_LIST_BE _STD_LIST_OBJ;
        public STD_LIST_BE STD_LIST_OBJ
        {
            get
            {
                return _STD_LIST_OBJ;
            }
            set
            {
                if (_STD_LIST_OBJ != value)
                {
                    _STD_LIST_OBJ = value; RaisePropertyChanged("STD_LIST_OBJ");
                }
            }
        }

        private ADM_M0010 _DOC_TYPE_OBJ;
        public ADM_M0010 DOC_TYPE_OBJ
        {
            get { return _DOC_TYPE_OBJ; }
            set
            {
                if (_DOC_TYPE_OBJ != value)
                {
                    _DOC_TYPE_OBJ = value;

                    RaisePropertyChanged("DOC_TYPE_OBJ");
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

        private ICollectionView _GRID_COLLECTION;
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

        #endregion


        #region . Relay Commands .
        public RelayCommand<object> cmdExecuteGRN { get; private set; } // This command will create balance GRN for the Sales Order.
        public RelayCommand<object> cmdExecuteOrder { get; private set; } // This command will create balance Service Order for the Sales Order.
        public RelayCommand<object> cmdExecuteBilling { get; private set; } // This command will create balance Invoices for the Sales Order.
        public RelayCommand<object> cmdRefresh { get; private set; } // This command will get refresh RM Orders.
        public RelayCommand<object> cmdExecuteReferenceDocument { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }

        #endregion

        #region . Constructor .
        public SDM_T022_VM() : base()
        {
            MC = new MC_MM_T001();
            REQ_PARA = new STD_REQ_PARA_BE();
            CommandInitialization();
            sms = this.GetViewService<IShowMessageViewService>();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        #endregion

        #region . User Defined Functions .
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Sender != null)
            {
                if (msg.Sender.GetType() == typeof(STD_LIST_BE))
                {
                    STD_LIST_BE OBJ_STD = (STD_LIST_BE)msg.Sender;
                    if (OBJ_STD.request == "BillingDocCreated")
                    {
                        STD_LIST_OBJ.billing_doc_no = OBJ_STD.billing_doc_no;
                    }
                }
            }
        }

        private void CommandInitialization()
        {
            cmdExecuteGRN = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteGRN(items); });
            cmdExecuteOrder = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteOrder(items); });
            cmdExecuteBilling = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteBilling(items); });
            cmdRefresh = new RelayCommand<object>(items => { if (items == null) { return; } LoadData(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
        }

        private void LoadData(object para)
        {
            try
            {
                string Request = "LOAD_INI_OUTSOURCE" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@!@!@" + AppSessionState.EmpId + "!@" + (REQ_PARA.party_code ?? "") + "!@" + (REQ_PARA.t_status ?? "") + "!@" + (REQ_PARA.active.HasValue ? REQ_PARA.active.ToString() : "") + "!@" + Convert.ToDateTime(REQ_PARA.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA.to_date).ToString("MM/dd/yyyy");
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "MM_T001_BL", "MM", "LoadAll", 0, "");

                GRID_COLLECTION = CollectionViewSource.GetDefaultView(MC.GRID_COLLECTION);
                GRID_COLLECTION.Filter = new Predicate<object>(FILTER_GRID_COLLECTION);

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void ExecuteGRN(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                if (STD_LIST_OBJ != null)
                {
                    if (!string.IsNullOrWhiteSpace(STD_LIST_OBJ.ref_doc_no ?? ""))
                    {
                        //STD_LIST_OBJ.doc_cat = doc_cat_vm;
                        //STD_LIST_OBJ.doc_type = doc_type_vm;
                        //string Request = "EXECUTE_GRN" + "!@" + AppSessionState.client + "!@" + STD_OBJ.comp_code + "!@" + STD_OBJ.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + STD_OBJ.ref_doc_no + "!@" + STD_OBJ.ref_doc_cat + "!@" + STD_OBJ.ref_doc_type + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.UserID;

                        SYS_AUTH userAuth = new SYS_AUTH();
                        userAuth = ((List<SYS_AUTH>)AppSessionState.ADM_AUTH_LIST).Where(X => X.ts_code == DOC_TYPE_OBJ.ts_code_gr).FirstOrDefault();
                        //userAuth = docdetails;
                        AppSessionState.TransactionCode = userAuth.ts_code;
                        AppSessionState.ViewTitle = userAuth.ts_name;
                        //AppSessionState.TransValue = POPUPEntityObject.doc_no;
                        //AppSessionState.TransValueType = POPUPEntityObject.doc_no;
                        //AppSessionState.TransParameter = "NO";
                        //AppSessionState.ViewOtherRecordAllowed = false;


                        if (userAuth.class_file != null && userAuth.class_file != "")
                        {
                            string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userAuth.ts_namespace);
                            Assembly assembly = Assembly.LoadFile(path1);
                            Type type = assembly.GetType(userAuth.class_file);
                            if (type != null)
                            {
                                dynamic instance = Activator.CreateInstance(type, userAuth.ts_code, STD_LIST_OBJ);
                                SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                            }
                        }
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
        private void ExecuteOrder(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                if (STD_LIST_OBJ != null)
                {
                    if (!string.IsNullOrWhiteSpace(STD_LIST_OBJ.ref_doc_no ?? ""))
                    {
                        if (STD_LIST_OBJ.counter1 > 1)
                        {
                            ADM_M0010 NR_DOC_TYPE_OBJ = MC.DOCTYPE_LIST.Where(x => x.doc_cat == "NR" && x.ind_default == "1").ToList()[0];
                            STD_LIST_OBJ.doc_cat = NR_DOC_TYPE_OBJ.doc_cat ?? "NR"; // NOTE: Make it dynamic selection
                            STD_LIST_OBJ.doc_type = NR_DOC_TYPE_OBJ.doc_type ?? "PM05"; // NOTE: Make it dynamic selection, we can configure in setting to get it dynamically because this screen can be use for any document creation.
                            STD_LIST_OBJ.ts_code = NR_DOC_TYPE_OBJ.ts_code_or;
                            STD_LIST_OBJ.type_code = "BULK_PROCESS";

                            SYS_AUTH userAuth = new SYS_AUTH();
                            userAuth = ((List<SYS_AUTH>)AppSessionState.ADM_AUTH_LIST).Where(X => X.ts_code == NR_DOC_TYPE_OBJ.ts_code_or).FirstOrDefault();
                            AppSessionState.TransactionCode = userAuth.ts_code;
                            AppSessionState.ViewTitle = userAuth.ts_name;
                            userAuth.ts_namespace = "Reflection.Modules.PPC.dll";
                            userAuth.class_file = "Reflection.Modules.PPC.Views.PPC_C001";

                            if (userAuth.class_file != null && userAuth.class_file != "")
                            {
                                string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userAuth.ts_namespace);
                                Assembly assembly = Assembly.LoadFile(path1);
                                Type type = assembly.GetType(userAuth.class_file);
                                if (type != null)
                                {
                                    dynamic instance = Activator.CreateInstance(type, userAuth.ts_code, STD_LIST_OBJ);
                                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().ShowDialog(instance);
                                }
                            }
                        }
                        else if (STD_LIST_OBJ.counter1 == 1 && STD_LIST_OBJ.int_value1 == STD_LIST_OBJ.int_value2)
                        {
                            ADM_M0010 NR_DOC_TYPE_OBJ = MC.DOCTYPE_LIST.Where(x => x.doc_cat == "NR" && x.ind_default == "1").ToList()[0];
                            STD_LIST_OBJ.doc_cat = NR_DOC_TYPE_OBJ.doc_cat ?? "NR"; // NOTE: Make it dynamic selection
                            STD_LIST_OBJ.doc_type = NR_DOC_TYPE_OBJ.doc_type ?? "PM05"; // NOTE: Make it dynamic selection, we can configure in setting to get it dynamically because this screen can be use for any document creation.
                            STD_LIST_OBJ.ts_code = NR_DOC_TYPE_OBJ.ts_code_or;
                            STD_LIST_OBJ.type_code = "SINGLE_PROCESS";

                            SYS_AUTH userAuth = new SYS_AUTH();
                            userAuth = ((List<SYS_AUTH>)AppSessionState.ADM_AUTH_LIST).Where(X => X.ts_code == NR_DOC_TYPE_OBJ.ts_code_or).FirstOrDefault();
                            AppSessionState.TransactionCode = userAuth.ts_code;
                            AppSessionState.ViewTitle = userAuth.ts_name;

                            if (userAuth.class_file != null && userAuth.class_file != "")
                            {
                                string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userAuth.ts_namespace);
                                Assembly assembly = Assembly.LoadFile(path1);
                                Type type = assembly.GetType(userAuth.class_file);
                                if (type != null)
                                {
                                    dynamic instance = Activator.CreateInstance(type, userAuth.ts_code, STD_LIST_OBJ);
                                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                                }
                            }
                        }
                        else
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Object not exists for order processing", this.Title); sms.ShowMessage();
                        }
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
        private void ExecuteBilling(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                if (STD_LIST_OBJ != null)
                {
                    if (!string.IsNullOrWhiteSpace(STD_LIST_OBJ.ref_doc_no ?? ""))
                    {
                        if (STD_LIST_OBJ.counter1 > 1000000)
                        {
                            ADM_M0010 SI_DOC_TYPE_OBJ = MC.DOCTYPE_LIST.Where(x => x.doc_cat == "SI" && x.ind_default == "1").ToList()[0];
                            STD_LIST_OBJ.doc_cat = SI_DOC_TYPE_OBJ.doc_cat ?? "SI"; // NOTE: Make it dynamic selection
                            STD_LIST_OBJ.doc_type = SI_DOC_TYPE_OBJ.doc_type ?? "SI"; // NOTE: Make it dynamic selection, we can configure in setting to get it dynamically because this screen can be use for any document creation.
                            STD_LIST_OBJ.ts_code = SI_DOC_TYPE_OBJ.ts_code_si;
                            STD_LIST_OBJ.type_code = "BULK_PROCESS";

                            SYS_AUTH userAuth = new SYS_AUTH();
                            userAuth = ((List<SYS_AUTH>)AppSessionState.ADM_AUTH_LIST).Where(X => X.ts_code == SI_DOC_TYPE_OBJ.ts_code_si).FirstOrDefault();
                            AppSessionState.TransactionCode = userAuth.ts_code;
                            AppSessionState.ViewTitle = userAuth.ts_name;
                            userAuth.ts_namespace = "Reflection.Modules.FICO.dll";
                            userAuth.class_file = "Reflection.Modules.FICO.Views.FICO_C001";

                            if (userAuth.class_file != null && userAuth.class_file != "")
                            {
                                string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userAuth.ts_namespace);
                                Assembly assembly = Assembly.LoadFile(path1);
                                Type type = assembly.GetType(userAuth.class_file);
                                if (type != null)
                                {
                                    dynamic instance = Activator.CreateInstance(type, userAuth.ts_code, STD_LIST_OBJ);
                                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().ShowDialog(instance);
                                }
                            }
                        }
                        else //if (STD_LIST_OBJ.counter1 == 1)
                        {
                            ADM_M0010 SI_DOC_TYPE_OBJ = MC.DOCTYPE_LIST.Where(x => x.doc_cat == "SI" && x.ind_default == "1").ToList()[0];
                            STD_LIST_OBJ.doc_cat = SI_DOC_TYPE_OBJ.doc_cat ?? "SI"; // NOTE: Make it dynamic selection
                            STD_LIST_OBJ.doc_type = SI_DOC_TYPE_OBJ.doc_type ?? "SI"; // NOTE: Make it dynamic selection, we can configure in setting to get it dynamically because this screen can be use for any document creation.
                            STD_LIST_OBJ.ts_code = SI_DOC_TYPE_OBJ.ts_code_or;
                            STD_LIST_OBJ.ref_doc_cat = "SO"; // NOTE: Make it dynamic selection
                            STD_LIST_OBJ.ref_doc_type = "SO"; // NOTE: Make it dynamic selection
                            STD_LIST_OBJ.ref_doc_no = STD_LIST_OBJ.order_no;
                            STD_LIST_OBJ.type_code = "SINGLE_PROCESS";

                            SYS_AUTH userAuth = new SYS_AUTH();
                            userAuth = ((List<SYS_AUTH>)AppSessionState.ADM_AUTH_LIST).Where(X => X.ts_code == SI_DOC_TYPE_OBJ.ts_code_si).FirstOrDefault();
                            AppSessionState.TransactionCode = userAuth.ts_code;
                            AppSessionState.ViewTitle = userAuth.ts_name;

                            if (userAuth.class_file != null && userAuth.class_file != "")
                            {
                                string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userAuth.ts_namespace);
                                Assembly assembly = Assembly.LoadFile(path1);
                                Type type = assembly.GetType(userAuth.class_file);
                                if (type != null)
                                {
                                    dynamic instance = Activator.CreateInstance(type, userAuth.ts_code, STD_LIST_OBJ);
                                    SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                                }
                            }
                        }
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

        private void WindowEvetCall(object InputValue)
        {
            try
            {
                REQ_PARA.active = true;
                REQ_PARA.from_date = DateTime.Now;
                REQ_PARA.to_date = DateTime.Now;
                REQ_PARA.t_status = "02"; // NOTE: make it dynamic

                LoadData(null);
                //Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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
                    Request = AppSessionState.client + "!@" + STD_LIST_OBJ.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        #endregion      

        #region . Command Actions .
        protected override void OnSaveAction(InquiryActionResult<STD_LIST_BE> result)
        { }
        protected override void OnCreateAction(InquiryActionResult<STD_LIST_BE> result)
        { }
        protected override void OnRemoveAction(InquiryActionResult<STD_LIST_BE> result)
        { }
        protected override void OnDiscardAction(InquiryActionResult<STD_LIST_BE> result)
        { }
        protected override void OnFevoriteAction(InquiryActionResult<STD_LIST_BE> result)
        { }
        protected override void OnFlipAction(InquiryActionResult<STD_LIST_BE> result)
        { }
        protected override void OnHelpAction(InquiryActionResult<STD_LIST_BE> result)
        { }
        protected override void OnPrintAction(InquiryActionResult<STD_LIST_BE> result)
        { }
        protected override void OnDocumentAction()
        { }
        protected override void OnRefreshCommand(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnLedgerViewCommand(InquiryActionResult<STD_LIST_BE> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnValidateCommand(InquiryActionResult<STD_LIST_BE> result)
        { }
        protected override void OnTraceCommand(InquiryActionResult<STD_LIST_BE> result)
        { }
        protected override void OnMailCommand(InquiryActionResult<STD_LIST_BE> result)
        { }
        
        private void OnExportAction()
        { }
        private void OpenDocumentViewer(object InputValue)
        { }
        #endregion

        #region . Filter Function .
        private string _FILTER_STRING_GRID; //vendor
        public string FILTER_STRING_GRID
        {
            get { return _FILTER_STRING_GRID; }
            set
            {
                _FILTER_STRING_GRID = value;
                RaisePropertyChanged("FILTER_STRING_GRID");
                REFRESH_GRID_FILTER();
            }
        }
        private void REFRESH_GRID_FILTER()
        {
            if (GRID_COLLECTION != null)
            {
                GRID_COLLECTION.Refresh();
            }
        }
        public bool FILTER_GRID_COLLECTION(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FILTER_STRING_GRID))
                {
                    return (data.order_no != null && (data.order_no ?? "").ToString().ToLower().Contains(_FILTER_STRING_GRID.ToLower())) ||
                        (data.order_date != null && (data.order_date.ToString() ?? "").ToString().ToLower().Contains(_FILTER_STRING_GRID.ToLower())) ||
                        (data.doc_no != null && (data.doc_no ?? "").ToString().ToLower().Contains(_FILTER_STRING_GRID.ToLower())) ||
                        (data.party_code != null && (data.party_code ?? "").ToString().ToLower().Contains(_FILTER_STRING_GRID.ToLower())) ||
                        (data.party_name != null && (data.party_name ?? "").ToString().ToLower().Contains(_FILTER_STRING_GRID.ToLower())) ||
                        (data.cn_text != null && (data.cn_text ?? "").ToString().ToLower().Contains(_FILTER_STRING_GRID.ToLower())) ||
                        (data.party_ref_no != null && (data.party_ref_no ?? "").ToString().ToLower().Contains(_FILTER_STRING_GRID.ToLower())) ||
                        (data.ref_doc_no != null && (data.ref_doc_no ?? "").ToString().ToLower().Contains(_FILTER_STRING_GRID.ToLower())) ||
                        (data.emp_id != null && (data.emp_id ?? "").ToString().ToLower().Contains(_FILTER_STRING_GRID.ToLower())) ||
                        (data.emp_name != null && (data.emp_name ?? "").ToString().ToLower().Contains(_FILTER_STRING_GRID.ToLower())) ||
                        (data.order_to_plant != null && (data.order_to_plant ?? "").ToString().ToLower().Contains(_FILTER_STRING_GRID.ToLower())) ||
                        (data.location_id != null && (data.location_id ?? "").ToString().ToLower().Contains(_FILTER_STRING_GRID.ToLower())) ||
                        (data.comp_code != null && (data.comp_code ?? "").ToString().ToLower().Contains(_FILTER_STRING_GRID.ToLower())) ||
                        (data.t_status != null && (data.t_status ?? "").ToString().ToLower().Contains(_FILTER_STRING_GRID.ToLower())) ||
                        (data.t_display != null && (data.t_display ?? "").ToString().ToLower().Contains(_FILTER_STRING_GRID.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion
    }
}
