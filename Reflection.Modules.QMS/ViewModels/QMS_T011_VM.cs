using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity.QMS;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using Reflection.ReportingServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using System.Reflection;
using GalaSoft.MvvmLight.Ioc;
using Reflection.Presentation.Core.VirtualDesktops;
using System.IO;
using Reflection.BusinessEntity;
using Reflection.Presentation.Common;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity.CustomerRelation;

namespace Reflection.Modules.QMS.ViewModels
{
    public class QMS_T011_VM : WorkspaceViewModel<QMS_T003>
    {
        
        //WebServiceRepository<List<QMS_T003>> REPO = new WebServiceRepository<List<QMS_T003>>();
        WebServiceRepository<MC_QMS_T003> REPO_MC = new WebServiceRepository<MC_QMS_T003>();

        #region Decleration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }
        private QMS_T003 _MasterEntity;
        public QMS_T003 MasterEntity
        {
            get { return _MasterEntity; }
            set { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); }
        }

        private MC_QMS_T003 _MC;
        public MC_QMS_T003 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }
        private MC_QMS_T003 _MC_TEMP;
        public MC_QMS_T003 MC_TEMP
        {
            get { return _MC_TEMP; }
            set { _MC_TEMP = value; RaisePropertyChanged("MC_TEMP"); }
        }

        private STD_REQ_PARA_BE _REQ_PARA;
        public STD_REQ_PARA_BE REQ_PARA
        {
            get
            {
                return _REQ_PARA;
            }
            set
            {
                if (_REQ_PARA != value)
                {
                    _REQ_PARA = value;
                    RaisePropertyChanged(nameof(REQ_PARA));
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
                    _STD_LIST_OBJ = value;
                    RaisePropertyChanged("STD_LIST_OBJ");
                }
            }
        }
        #endregion

        #region Relay Command Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdViewInspLotDocument { get; private set; }
        public RelayCommand<object> cmdLoadByStatus { get; private set; }
        public RelayCommand<object> cmdInspection_Processing_RR { get; private set; }
        public RelayCommand<object> cmdInspection_Processing_DR { get; private set; }
        public RelayCommand<object> cmdInspection_Processing_UD { get; private set; }
        public RelayCommand<object> cmdRelease { get; private set; }
        public RelayCommand<object> cmdPrint { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }

        #endregion

        #region Constructor
        public QMS_T011_VM(string ts_code, string doc_cat) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;
            MasterEntity = new QMS_T003();
            MC = new MC_QMS_T003();
            MC_TEMP = new MC_QMS_T003();
            LoadInitializeCommands();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public QMS_T011_VM(string ts_code, string doc_cat, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;
            this.doc_no_vm = doc_no;
            MasterEntity = new QMS_T003();
            MC = new MC_QMS_T003();
            MC_TEMP = new MC_QMS_T003();
            LoadInitializeCommands();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        #endregion

        #region Functions
        private void NotificationMessageReceived(NotificationMessage msg)
        {
            if (msg.Sender != null)
            {
                if (msg.Sender.GetType() == typeof(STD_LIST_BE))
                {
                    //STD_LIST_BE OBJ_STD = (STD_LIST_BE)msg.Sender;
                    //if (OBJ_STD.request == "UD_UPDATE")
                    //{
                    //    MasterEntity.insp_end_date = OBJ_STD.date_end;
                    //}
                }
                if (msg.Sender.GetType() == typeof(QMS_T003))
                {
                    if (msg.Notification == "UD_UPDATE" && msg.Target.ToString() == "IL")
                    {
                        MasterEntity = (QMS_T003)msg.Sender;
                    }
                    
                }
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
                    Request = AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + InputValue.ToString();
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
                REQ_PARA = new STD_REQ_PARA_BE();
                REQ_PARA.from_date = DateTime.Now;
                REQ_PARA.to_date = DateTime.Now;
                REQ_PARA.active = true;
                REQ_PARA.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                REQ_PARA.location_id = AppSessionState.OBJ_LOCATION.location_id;

                LoadBackFlipData("IL");
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
      
        private void ViewInspLotDocument(object InputValue)
        {
            QMS_T003 EntityObject = null;
            if (InputValue != null)
            {
                EntityObject = ((IEnumerable)InputValue).Cast<QMS_T003>().ToList()[0];
                AppSessionState.ViewTitle = "";
                AppSessionState.ViewTitle = EntityObject.doc_desc;
            }
            string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, EntityObject.ts_namespace);
            Assembly assembly = Assembly.LoadFile(path1);
            Type type = assembly.GetType(EntityObject.ts_class_file);
            if (type != null)
            {
                dynamic instance = Activator.CreateInstance(type, EntityObject.ts_code, EntityObject.doc_no);
                SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
            }
        }
        private void LoadByStatus(object item)
        { }
        private void Inspection_Processing_RR_Call(object item)
        {
            try
            {
                if (((IEnumerable)item).Cast<QMS_T003>().ToList().Count > 0)
                {
                    QMS_T003 ParameterEntityObject = ((IEnumerable)item).Cast<QMS_T003>().ToList()[0];
                    AppSessionState.ViewTitle = "Inspection Processing : Result Recording";
                    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.QMS.dll");
                    Assembly assembly = Assembly.LoadFile(path1);
                    Type type = assembly.GetType("Reflection.Modules.QMS.Views.QMS_T012");
                    if (type != null)
                    {
                        dynamic instance = Activator.CreateInstance(type, "QM29", ParameterEntityObject.doc_no, ParameterEntityObject);
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
        private void Inspection_Processing_DR_Call(object item)
        {
            try
            {
                //if (((IEnumerable)item).Cast<QMS_T003>().ToList().Count > 0)
                //{
                //    QMS_T003 ParameterEntityObject = ((IEnumerable)item).Cast<QMS_T003>().ToList()[0];
                //    AppSessionState.ViewTitle = "Inspection Processing : Defect Recording";
                //    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.QMS.dll");
                //    Assembly assembly = Assembly.LoadFile(path1);
                //    Type type = assembly.GetType("Reflection.Modules.QMS.Views.QMS_T013");
                //    if (type != null)
                //    {
                //        dynamic instance = Activator.CreateInstance(type, "QM30", ParameterEntityObject, "L");
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
        private void Inspection_Processing_UD_Call(object item)
        {
            try
            {
                if (((IEnumerable)item).Cast<QMS_T003>().ToList().Count > 0)
                {
                    QMS_T003 ParameterEntityObject = ((IEnumerable)item).Cast<QMS_T003>().ToList()[0];
                    STD_LIST_BE STD_OBJ = new STD_LIST_BE();
                    STD_OBJ.ts_code = "QM31";
                    AppSessionState.ViewTitle = "Inspection Processing : Usage Decision";
                    string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.QMS.dll");
                    Assembly assembly = Assembly.LoadFile(path1);
                    Type type = assembly.GetType("Reflection.Modules.QMS.Views.QMS_T014");
                    if (type != null)
                    {
                        dynamic instance = Activator.CreateInstance(type, STD_OBJ, ParameterEntityObject);
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
        private void Release_Inspection(object item)
        {
            try
            {
                WebServiceRepository<List<Approval>> repository = new WebServiceRepository<List<Approval>>();
                List<Approval> RequestList = new List<Approval>();
                foreach (QMS_T003 obj in MC.INSP_LOT_LIST)
                {
                    if (obj.selected == true)
                    {
                        //item.appro_status = "02";
                        //item.editby = AppSessionState.UserID;
                        //RequestList.Add(item);
                    }
                }
                string strReturn = repository.Update<List<Approval>>(RequestList, "ADM_T001_BL", "ADM");
                
            }
            catch (Exception ex)
            {

            }
        }

        private void PrintReport(object item)
        {
            CursorControl.SetBusyState();
            string LotNo = "";
            string Request = "";
            try
            {

                foreach (var obj in MC.INSP_LOT_LIST)
                {
                    if(obj.selected==true)
                    {
                        LotNo = LotNo + "," + obj.doc_no;
                    }
                }

                if (!string.IsNullOrWhiteSpace(LotNo))
                {
                    Request = "REPORT" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + LotNo + "!@" + (REQ_PARA.emp_id ?? AppSessionState.EmpId) + "!@" + (REQ_PARA.userid ?? AppSessionState.UserID) + "!@" + (REQ_PARA.t_status ?? "01") + "!@" + (REQ_PARA.active_code ?? "") + "!@" + Convert.ToDateTime(REQ_PARA.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA.to_date).ToString("MM/dd/yyyy"); // NOTE: status ned to set dynamic and default
                    MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_QMS_T003>(MC_TEMP, Request, "QMS_T003_BL", "QMS", "Report", 0, "");

                }
                
                {
                    string ReportName = "";

                    object[] objDataSource = new object[6];
                    string[] objDataSourceName = new string[6];
                    

                    
                    objDataSource[0] = AppSessionState.COMPANY_LIST.Where(loc => loc.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[1] = AppSessionState.LOCATION_LIST.Where(loc => loc.comp_code == MasterEntity.comp_code && loc.location_id==MasterEntity.location_id).ToList();
                    objDataSource[2] = MC_TEMP.MASTER_LIST;
                    objDataSource[3] = MC_TEMP.SUMMURY_RR;
                    objDataSource[4] = MC.RPT_SETTING;
                    objDataSource[5] = MC_TEMP.TEST_HEADER;
                    //objDataSource[4] = dgItemsEntity;
                    //objDataSource[5] = TotalDocumentTaxes;
                    ////objDataSource[6] = TermsConditionEntity;
                    //objDataSource[7] = ResultBillingAddress;

                    objDataSourceName[0] = "dsCompany";
                    objDataSourceName[1] = "dsLocation";
                    objDataSourceName[2] = "dsMaster";
                    objDataSourceName[3] = "dsRRA";
                    objDataSourceName[4] = "dsSETTING";
                    objDataSourceName[5] = "dsTestHeader";
                    //objDataSourceName[4] = "dsTax";
                    //objDataSourceName[5] = "dsSchedule";
                    //objDataSourceName[6] = "dsTC";
                    //objDataSourceName[7] = "dsBillingAddress";

                    var ReportStringList = (from o in MC.DOC_TYPE_LIST where o.doc_type == MasterEntity.doc_cat select o).ToList();
                    if (MasterEntity.doc_type == "IL")
                    {
                        ReportName = ReportStringList[0].report_name.Split(',')[0];

                    }
                    else
                    {
                        ReportName = ReportStringList[0].report_name.Split(',')[0];
                    }

                    ReportManager ReportManager = new ReportManager();
                    string ReportDisplayName = MasterEntity.party_name + "_" + MasterEntity.doc_no + "_" + MasterEntity.doc_date.Value.ToShortDateString();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORTS_STD\\TXN\\" + ReportName, getParametersList(), ReportDisplayName);

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
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                if (MC.RPT_SETTING.Count > 0)
                {
                    result.Add("hl_margin", MC.RPT_SETTING[0].header_left_margin);
                    result.Add("hr_margin", MC.RPT_SETTING[0].header_right_margin);
                    result.Add("ht_margin", MC.RPT_SETTING[0].header_top_margin);
                    result.Add("hb_margin", MC.RPT_SETTING[0].header_bottom_margin);
                    result.Add("fl_margin", MC.RPT_SETTING[0].footer_left_margin);
                    result.Add("fr_margin", MC.RPT_SETTING[0].footer_right_margin);
                    result.Add("ft_margin", MC.RPT_SETTING[0].footer_top_margin);
                    result.Add("fb_margin", MC.RPT_SETTING[0].footer_bottom_margin);
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Update Report Setting", this.Title);
                    showMessageService.ShowMessage();
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
            return result;
        }
        private void LoadBackFlipData(object Parameter)
        {
            try
            {
                CursorControl.SetBusyState();

                string Request = "LOAD_INSP_LOT" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + (REQ_PARA.emp_id ?? AppSessionState.EmpId) + "!@" + (REQ_PARA.userid ?? AppSessionState.UserID) + "!@" + (REQ_PARA.t_status ?? "") + "!@" + (REQ_PARA.active_code ?? "") + "!@" + Convert.ToDateTime(REQ_PARA.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA.to_date).ToString("MM/dd/yyyy"); // NOTE: status ned to set dynamic and default
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_QMS_T003>(MC, Request, "QMS_T003_BL", "QMS", "LOAD_INSP_LOT", 0, "");

                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC.INSP_LOT_LIST);
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(FLTR_BACKFLIP);

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
        private void LoadInitializeCommands()
        {
            try
            {
                #region Relay Command Initialization

                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdViewInspLotDocument = new RelayCommand<object>(items => { if (items == null) { return; } ViewInspLotDocument(items); });
                cmdLoadByStatus = new RelayCommand<object>(items => { if (items == null) { return; } LoadByStatus(items); });
                cmdInspection_Processing_RR = new RelayCommand<object>(items => { if (items == null) { return; } Inspection_Processing_RR_Call(items); });
                cmdInspection_Processing_DR = new RelayCommand<object>(items => { if (items == null) { return; } Inspection_Processing_DR_Call(items); });
                cmdInspection_Processing_UD = new RelayCommand<object>(items => { if (items == null) { return; } Inspection_Processing_UD_Call(items); });
                cmdRelease = new RelayCommand<object>(items => { if (items == null) { return; } Release_Inspection(items); });
                cmdPrint= new RelayCommand<object>(items => { if (items == null) { return; } PrintReport(items); });
                cmdLoadBackFlip = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadBackFlipData(cmdPara); });
                #endregion
            }
            catch (Exception ex)
            { }
        }

        #endregion

        #region Collection and Filter For Flip

        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }

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
            if (_BACKFLIP_COLLECTION != null)
            {
                _BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool FLTR_BACKFLIP(object obj)
        {
            var data = obj as QMS_T003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FLTR_STR_BACKFLIP))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        //(data.valid_from != null && data.valid_from.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.item_code != null && data.item_code.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.item_name != null && data.item_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.barcode != null && data.barcode.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.party_name != null && data.party_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.tl_name != null && data.tl_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.tl_code != null && data.tl_code.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.barcode != null && data.barcode.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        //(data.short_text != null && data.short_text.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        //(data.cat_name != null && data.cat_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.t_status != null && data.t_status.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.wc_code != null && data.wc_code.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.sono != null && data.sono.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.order_no != null && data.order_no.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.emp_name != null && data.emp_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.location_id != null && data.location_id.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.t_display != null && data.t_display.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.order_no != null && data.order_no.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Abstract Command


        protected override void OnCreateAction(InquiryActionResult<QMS_T003> result) // Inspection done code block.
        {
            try
            {
                //List<STD_LIST_BE> RequestList = new List<STD_LIST_BE>();
                //foreach (var item in MC.INSP_LOT_LIST)
                //{
                //    if (item.selected == true)
                //    {
                //        item.t_status = "02";
                //        item.userid = AppSessionState.UserID;
                //        RequestList.Add(item);
                //    }
                //}
               
                //foreach (var item in MC.INSP_LOT_LIST)
                //{
                //    if (item.selected == true)
                //    {
                //        item.selected = false;
                //    }
                //}
                //MasterEntity.ts_code = ts_code_vm;
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnDiscardAction(InquiryActionResult<QMS_T003> result) // Inspection data refresh code block.
        {
            try
            {
                LoadBackFlipData("IL");
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

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<QMS_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_T003> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<QMS_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFlipAction(InquiryActionResult<QMS_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<QMS_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<QMS_T003> result)
        {
            
        }

        protected override void OnRemoveAction(InquiryActionResult<QMS_T003> result) // Inspection Hold code block.
        {
            try
            {
                //List<QMS_T003> RequestList = new List<QMS_T003>();
                //foreach (QMS_T003 item in MC.MasterEntity)
                //{
                //    if (item.t_select == true)
                //    {
                //        item.t_status = "010";
                //        item.user_source1 = item.user_source1;
                //        item.userid = AppSessionState.UserID;
                //        RequestList.Add(item);
                //    }
                //}
                //if (RequestList.Count > 0)
                //{
                //    string strReturn = repository.Update<List<QMS_T003>>(RequestList, "QMS_T002_BL", "QMS");
                //    List<QMS_T003> SelectedList = (from o in MC.MasterEntity where o.t_status != "002" select o).ToList();
                //    DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                //    DataGridCollection.Filter = new Predicate<object>(Filter);
                //}
                //foreach (QMS_T003 item in MC.MasterEntity)
                //{
                //    if (item.t_select == true)
                //    {
                //        item.t_select = false;
                //    }
                //}
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnSaveAction(InquiryActionResult<QMS_T003> result) // // Inspection Rejection code block.
        {
            try
            {
                //List<QMS_T003> RequestList = new List<QMS_T003>();
                //foreach (QMS_T003 item in MC.MasterEntity)
                //{
                //    if (item.t_select == true)
                //    {
                //        item.t_status = "008";
                //        item.user_source1 = item.user_source1;
                //        item.userid = AppSessionState.UserID;
                //        RequestList.Add(item);
                //    }
                //}
                //if (RequestList.Count > 0)
                //{
                //    string strReturn = repository.Update<List<QMS_T003>>(RequestList, "QMS_T002_BL", "QMS");
                //    List<QMS_T003> SelectedList = (from o in MC.MasterEntity where o.t_status != "002" select o).ToList();
                //    DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                //    DataGridCollection.Filter = new Predicate<object>(Filter);
                //}
                //foreach (QMS_T003 item in MC.MasterEntity)
                //{
                //    if (item.t_select == true)
                //    {
                //        item.t_select = false;
                //    }
                //}
            }
            catch (Exception ex)
            {

            }
        }


        #endregion
    }
}
