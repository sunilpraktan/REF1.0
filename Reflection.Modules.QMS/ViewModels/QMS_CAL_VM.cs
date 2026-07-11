using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using Reflection.BusinessEntity.QMS;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.VirtualDesktops;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Data;
using Reflection.BusinessEntity;
using Reflection.Presentation.Common;

namespace Reflection.Modules.QMS.ViewModels
{
    public class QMS_CAL_VM : WorkspaceViewModel<QMS_T001>
    {
        WebServiceRepository<QMS_T002> repository = new WebServiceRepository<QMS_T002>();
        WebServiceRepository<List<QMS_T001>> repository1 = new WebServiceRepository<List<QMS_T001>>();
        WebServiceRepository<MultipleContext_QMS_T001> repository_MC = new WebServiceRepository<MultipleContext_QMS_T001>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region Declaration

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private QMS_T001 _MasterEntity;
        public QMS_T001 MasterEntity
        {
            get { return _MasterEntity; }
            set { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); }
        }

        private MultipleContext_QMS_T001 _MC;
        public MultipleContext_QMS_T001 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_QMS_T001 _MCTemp;
        public MultipleContext_QMS_T001 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_QMS_T001 _MCTemp1;
        public MultipleContext_QMS_T001 MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private ICollectionView _InstInfoCollection;
        public ICollectionView InstInfoCollection
        {
            get { return _InstInfoCollection; }
            set { _InstInfoCollection = value; RaisePropertyChanged("InstInfoCollection"); }
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
        #endregion

        #region Relay Command Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }

        public RelayCommand<object> CmdLoadFromDateToDate { get; private set; }
        public RelayCommand<object> CmdViewDocument { get; private set; }
        public RelayCommand<object> CmdViewCalibration { get; private set; }
        public RelayCommand<object> CmdLoadByStatus { get; private set; }
        public RelayCommand<object> CmdInstrumentInfo { get; private set; }
        public RelayCommand<object> CmdGenerateServiceRequest { get; private set; }
        public RelayCommand<object> CmdSetReminder { get; private set; }

        #endregion

        #region Constructor
        public QMS_CAL_VM(string ts_code) : base()
        {
            CursorControl.SetBusyState();
            this.ts_code_vm = ts_code;
            MasterEntity = new QMS_T001();
            MC = new MultipleContext_QMS_T001();
            MCTemp = new MultipleContext_QMS_T001();
            LoadInitialData();
        }
        public QMS_CAL_VM(string ts_code, string doc_no) : base()
        {
            CursorControl.SetBusyState();
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new QMS_T001();
            MC = new MultipleContext_QMS_T001();
            MCTemp = new MultipleContext_QMS_T001();
            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                CursorControl.SetBusyState();

                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CmdLoadFromDateToDate = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadFromDateToDate(cmdPara); });
                CmdViewDocument = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } ViewDocument(cmdPara); });
                CmdViewCalibration = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } ViewCalibration(cmdPara); });
                CmdLoadByStatus = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadByStatus(cmdPara); });
                CmdInstrumentInfo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InstrumentInfo(cmdPara); });
                CmdGenerateServiceRequest = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } GenerateServiceRequest(cmdPara); });
                CmdSetReminder = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } MailDocuments(cmdPara); });


                string Request = "LoadInitialData" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_T001>(MC, Request, "CalibrationCalender", "QMS", "LoadInitialData", 0, "");

                DefaultValues();

                DataGridCollection = CollectionViewSource.GetDefaultView(from o in MC.MasterEntity where o.t_status == MasterEntity.t_status select o);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                NotificationDataCollection = MC.NotificationData;

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

            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.FromDate = DateTime.Now;
            MasterEntity.ToDate = DateTime.Now;
            MasterEntity.t_status = "Completed";
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
        }
        private void LoadFromDateToDate(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadFromDateToDate" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + Convert.ToDateTime(MasterEntity.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.ToDate).ToString("MM/dd/yyyy") + "!@" + MasterEntity.t_status;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_T001>(MCTemp, Request, "CalibrationCalender", "QMS", "LoadInitialData", 0, "");

                DataGridCollection = CollectionViewSource.GetDefaultView(MCTemp.MasterEntity);
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
                    //LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    //AppSessionState.ViewOtherRecordAllowed = true;
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
                QMS_T001 POPUPEntityObject = null;
                SYS_AUTH userAuth = new SYS_AUTH();
                if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_T001>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_T001>().ToList()[0];
                    POPUPEntityObject.TranCode = MC.DocTypeInfo.Where(x => x.doc_type == "RF" && x.doc_cat == "RF").Select(x => x.TranCode).FirstOrDefault();
                }

                //var docdetails = ((ADM_AUTH)AppSessionState.ADM_AUTH_OBJ).Where(X => X.TranCode == POPUPEntityObject.TranCode).FirstOrDefault();
                //userAuth = docdetails;
                //AppSessionState.UserAuthSingle = userAuth;
                //AppSessionState.ViewTitle = userAuth.DisTitl;
                AppSessionState.TransValue = POPUPEntityObject.ref_doc_no;
                AppSessionState.TransValueType = POPUPEntityObject.ref_doc_no;
                AppSessionState.TransParameter = "No";
                AppSessionState.ViewOtherRecordAllowed = false;
                //AppSessionState.TransId = userAuth.ts_code.ToString();
                //AppSessionState.TransactionCode = userAuth.ts_code;

                if (userAuth.class_file != null && userAuth.class_file != "")
                {
                    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userAuth.ts_nspath);
                    Assembly assembly = Assembly.LoadFile(path1);
                    Type type = assembly.GetType(userAuth.class_file);
                    if (type != null)
                    {
                        dynamic instance = Activator.CreateInstance(type);
                        SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                        //instance.Id = Guid.NewGuid();
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
        private void ViewCalibration(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                QMS_T001 POPUPEntityObject = null;
                //UserAuthontication_Result userAuth = new UserAuthontication_Result();
                //if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_T001>().Count() > 0)
                //{
                //    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_T001>().ToList()[0];
                //    POPUPEntityObject.TranCode = MC.DocTypeInfo.Where(x => x.doc_type == "CC" && x.doc_cat == "CC").Select(x => x.TranCode).FirstOrDefault();
                //}

                //var docdetails = AppSessionState.UserAuthorisations.Where(X => X.TranCode == POPUPEntityObject.TranCode).FirstOrDefault();
                //userAuth = docdetails;
                //AppSessionState.UserAuthSingle = userAuth;
                //AppSessionState.ViewTitle = userAuth.DisTitl;
                //AppSessionState.TransValue = POPUPEntityObject.doc_no + "!@" + POPUPEntityObject.test_code;
                //AppSessionState.TransValueType = POPUPEntityObject.doc_no + "!@" + POPUPEntityObject.test_code;
                //AppSessionState.TransParameter = "FromCalender";
                //AppSessionState.ViewOtherRecordAllowed = false;
                //AppSessionState.TransId = userAuth.id.ToString();
                //AppSessionState.TransactionCode = userAuth.TranCode;

                //if (userAuth.SbModCod != null && userAuth.SbModCod != "" && userAuth.ClsFileName != null && userAuth.ClsFileName != "")
                //{
                //    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userAuth.Nspace);
                //    Assembly assembly = Assembly.LoadFile(path1);
                //    Type type = assembly.GetType(userAuth.ClsFileName);
                //    if (type != null)
                //    {
                //        dynamic instance = Activator.CreateInstance(type);
                //        SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                //    }
                //}
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
        private void LoadByStatus(object InputValue)
        {
            try
            {
                if (((IEnumerable)InputValue).Cast<String>().Count() > 0)
                {
                    DataGridCollection = CollectionViewSource.GetDefaultView(from o in MC.MasterEntity where o.t_status == MasterEntity.t_status select o);
                    DataGridCollection.Filter = new Predicate<object>(Filter);
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
        private void InstrumentInfo(object InputValue)
        {
            try
            {
                QMS_T001 POPUPEntityObject = null;
                if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_T001>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_T001>().ToList()[0];
                    InstInfoCollection = CollectionViewSource.GetDefaultView((from o in MC.MasterEntity where o.inst_code == POPUPEntityObject.inst_code select o).ToList());
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
        private void GenerateServiceRequest(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                QMS_T001 POPUPEntityObject = null;
                if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_T001>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_T001>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    QMS_T002 RequestEntity = new QMS_T002();

                    RequestEntity.ref_doc_no = POPUPEntityObject.ref_doc_no; // sales order/grn/po
                    RequestEntity.doc_cat = "RF";
                    RequestEntity.doc_type = "RF";
                    RequestEntity.doc_no = POPUPEntityObject.ref_doc_no;
                    RequestEntity.last_date = POPUPEntityObject.cal_date;
                    RequestEntity.next_date = POPUPEntityObject.next_date;
                    RequestEntity.due_date = POPUPEntityObject.next_date;
                    RequestEntity.t_status = "Open";
                    RequestEntity.location_Id = AppSessionState.location_Id;
                    RequestEntity.comp_code = AppSessionState.comp_code;
                    RequestEntity.user_source1 = AppSessionState.UserSource1;
                    RequestEntity.user_source2 = AppSessionState.UserSource2;
                    RequestEntity.add_by = AppSessionState.UserID;
                    RequestEntity.editby = AppSessionState.UserID;
                    RequestEntity.active = true;

                    RequestEntity = repository.SaveWithReturnDomainObject<QMS_T002>(RequestEntity, "CalibrationCalender", "QMS");

                    if (RequestEntity.doc_no != null && RequestEntity.doc_no != "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Request Generated with Request No: {0}", RequestEntity.doc_no);
                        showMessageService.ShowMessage();
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
        private void MailDocuments(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                string subject = "";
                string msg_body = "";
                if (NotificationDataCollection.Count > 0)
                {
                    subject = NotificationDataCollection[0].subject;
                    msg_body = NotificationDataCollection[0].msg_body;
                }
                var temp = from o in (List<ADM_M003>)AppSessionState.ADM_M003_List
                           where o.location_Id == MasterEntity.location_Id
                           select o;

                string location_Nm = temp.ToList()[0].LoctnNm;

                foreach (var o in MC.MasterEntity)
                {
                    if (o.Select == true && o.PartyId != null)
                    {
                        List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>()
                            {
                                new KeyValuePair<string, string>("[due_date]",Convert.ToDateTime(o.next_date).ToString("dd/MM/yyyy")),
                                new KeyValuePair<string, string>("[inst_code]", o.inst_code),
                                new KeyValuePair<string, string>("[inst_id]", o.inst_id),
                                new KeyValuePair<string, string>("[inst_name]", o.inst_name),
                                new KeyValuePair<string, string>("[EmpName]", AppSessionState.EmpName),
                                new KeyValuePair<string, string>("[CompanyName]",AppSessionState.CompanyName),
                                new KeyValuePair<string, string>("[location_Nm]",location_Nm)
                            };
                        foreach (KeyValuePair<string, string> kvp in kvpList)
                        {
                            //subject = subject.Replace(kvp.Key, kvp.Value);
                            msg_body = msg_body.Replace(kvp.Key, kvp.Value);
                        }
                        Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, o.to_mail_id, "",null, subject, msg_body, null);
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

        #region Filters For DataGrid
        private string _filterString;
        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                RaisePropertyChanged("FilterString");
                FilterCollection();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as QMS_T001;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.inst_code != null && data.inst_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.test_code != null && data.test_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.test_name != null && data.test_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.inst_name != null && data.inst_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.cal_type != null && data.cal_type.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.po_no != null && data.po_no.ToString().ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Abstract Command Actions
        protected override void OnCreateAction(InquiryActionResult<QMS_T001> result)
        {
            LoadInitialData();
        }

        protected override void OnDiscardAction(InquiryActionResult<QMS_T001> result)
        {

        }

        protected override void OnDocumentAction()
        {

        }

        protected override void OnFevoriteAction(InquiryActionResult<QMS_T001> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<QMS_T001> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<QMS_T001> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<QMS_T001> result)
        {

        }

        protected override void OnRemoveAction(InquiryActionResult<QMS_T001> result)
        {

        }

        protected override void OnSaveAction(InquiryActionResult<QMS_T001> result)
        {
            try
            {
                CursorControl.SetBusyState();
                List<QMS_T001> RequestEntity = new List<QMS_T001>();
                foreach (var item in MC.MasterEntity)
                {
                    if (item.Select == true)
                    {
                        item.editby = AppSessionState.UserID;
                        RequestEntity.Add(item);
                    }
                }
                if (RequestEntity.Count > 0)
                {
                    RequestEntity = repository1.UpdateWithReturnDomainObject<List<QMS_T001>>(RequestEntity, "CalibrationCalender", "QMS");

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Status Updated...");
                    showMessageService.ShowMessage();
                }
                LoadByStatus("Filter");
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

        protected override void OnRefreshCommand(InquiryActionResult<QMS_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_T001> result)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
