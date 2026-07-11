using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.QMS;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Reflection.Modules.QMS.ViewModels
{
    public class QMS_T003_VM : WorkspaceViewModel<QMS_T003>
    {
        bool NewRecord = true;

        WebServiceRepository<MC_QMS_T003> REPO_OBJ = new WebServiceRepository<MC_QMS_T003>();
        IShowMessageViewService sms;

        #region Decleration
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
        private STD_LIST_BE _STD_OBJ;
        public STD_LIST_BE STD_OBJ
        {
            get { return _STD_OBJ; }
            set { _STD_OBJ = value; RaisePropertyChanged("STD_OBJ"); }
        }
        private IEnumerable _ITEM_LIST;
        public IEnumerable ITEM_LIST
        {
            get { return _ITEM_LIST; }
            set { _ITEM_LIST = value; RaisePropertyChanged("ITEM_LIST"); }
        }
        private IEnumerable _INSP_TYPE_LIST;
        public IEnumerable INSP_TYPE_LIST
        {
            get { return _INSP_TYPE_LIST; }
            set { _INSP_TYPE_LIST = value; RaisePropertyChanged("INSP_TYPE_LIST"); }
        }
        private IEnumerable _PLANT_LIST;
        public IEnumerable PLANT_LIST
        {
            get { return _PLANT_LIST; }
            set { _PLANT_LIST = value; RaisePropertyChanged("PLANT_LIST"); }
        }
        private IEnumerable _STATUS_LIST;
        public IEnumerable STATUS_LIST
        {
            get { return _STATUS_LIST; }
            set { _STATUS_LIST = value; RaisePropertyChanged("STATUS_LIST"); }
        }
        private IEnumerable _UOM_LIST;
        public IEnumerable UOM_LIST
        {
            get { return _UOM_LIST; }
            set { _UOM_LIST = value; RaisePropertyChanged("UOM_LIST"); }
        }
        private IEnumerable _TASK_LIST;
        public IEnumerable TASK_LIST
        {
            get { return _TASK_LIST; }
            set { _TASK_LIST = value; RaisePropertyChanged("TASK_LIST"); }
        }
        private IEnumerable _SAMPLE_PRO_LIST;
        public IEnumerable SAMPLE_PRO_LIST
        {
            get { return _SAMPLE_PRO_LIST; }
            set { _SAMPLE_PRO_LIST = value; RaisePropertyChanged("SAMPLE_PRO_LIST"); }
        }
        private IEnumerable _EMPLOYEE_LIST;
        public IEnumerable EMPLOYEE_LIST
        {
            get { return _EMPLOYEE_LIST; }
            set { _EMPLOYEE_LIST = value; RaisePropertyChanged("EMPLOYEE_LIST"); }
        }
        private IEnumerable _FUN_LOC_LIST;
        public IEnumerable FUN_LOC_LIST
        {
            get { return _FUN_LOC_LIST; }
            set { _FUN_LOC_LIST = value; RaisePropertyChanged("FUN_LOC_LIST"); }
        }
        private int _tbIndex;
        public int tbIndex
        {
            get { return _tbIndex; }
            set
            {
                if (_tbIndex != value)
                {
                    _tbIndex = value;
                    RaisePropertyChanged("tbIndex");
                }
            }
        }
        
        #endregion

        #region Relay Command Decleration
        public RelayCommand<object> cmdInvokeDocument { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdLoadDocument { get; private set; }
        public RelayCommand<object> cmdInsertObject { get; private set; }
        public RelayCommand<object> cmdInsertInspType { get; private set; }
        #endregion

        #region Constructor
        public QMS_T003_VM(string ts_code,string doc_cat) : base()
        {
            STD_OBJ = new STD_LIST_BE();
            STD_OBJ.ts_code = ts_code;
            STD_OBJ.doc_cat = doc_cat;
            STD_OBJ.doc_type = doc_cat;
            MasterEntity = new QMS_T003();
            MC = new MC_QMS_T003();
            MC_TEMP = new MC_QMS_T003();
            sms = this.GetViewService<IShowMessageViewService>();
            InitializeCommands();
        }
        public QMS_T003_VM(STD_LIST_BE OBJ_LIST) : base()
        {
            STD_OBJ = OBJ_LIST;
            MasterEntity = new QMS_T003();
            MC = new MC_QMS_T003();
            MC_TEMP = new MC_QMS_T003();
            sms = this.GetViewService<IShowMessageViewService>();
            InitializeCommands();
        }

        #endregion

        #region User Define Methods
        private void InvokeDocument(object InputValue)
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
                LoadInitialData();
                DefaultValues();
                //if (doc_no_vm != null && ts_code_vm != null)
                //{
                //    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
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
        private void DefaultValues()
        {
            MasterEntity.client = AppSessionState.client;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.location_id = AppSessionState.location_Id;
            MasterEntity.emp_id = AppSessionState.EmpId;
            MasterEntity.doc_date = System.DateTime.Now;
            MasterEntity.insp_start_date = System.DateTime.Now;
            MasterEntity.insp_start_time = System.DateTime.Now.ToShortTimeString();
            MasterEntity.lot_create_date = System.DateTime.Now;
            MasterEntity.lot_create_time = System.DateTime.Now.ToShortTimeString();
            MasterEntity.posting_date = System.DateTime.Now;
            MasterEntity.insp_lot_qty = 1;
            MasterEntity.qty_actual = 1;
            MasterEntity.sample_size = 1;
            MasterEntity.doc_cat = STD_OBJ.doc_cat;
            MasterEntity.doc_type = STD_OBJ.doc_type;

            MasterEntity.active = "1";
            MasterEntity.t_status = "01"; // NOTE: Hardcoded
        }
        private void Logging()
        {
            MasterEntity.ts_code = STD_OBJ.ts_code;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private bool Validation()
        {
            if (string.IsNullOrWhiteSpace(MasterEntity.item_code))
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Item Code...", this.Title); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.obj_no))
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Object Code...", this.Title); sms.ShowMessage();
                return false;
            }
            if (string.IsNullOrWhiteSpace(MasterEntity.location_id))
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select location Code...", this.Title); sms.ShowMessage();
                return false;
            }
            if (MasterEntity.doc_source == null || MasterEntity.doc_source == "")
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Lot Origin...", this.Title); sms.ShowMessage();
                return false;
            }
            if (MasterEntity.insp_type == null || MasterEntity.insp_type == "")
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Inspection Type...", this.Title); sms.ShowMessage();
                return false;
            }
            if (MasterEntity.sample_size == null || !MasterEntity.sample_size.HasValue)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Enter Sample Size....", this.Title); sms.ShowMessage();
                return false;
            }
            if (MasterEntity.insp_lot_qty == null)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Enter The Insp.Lot Qty....", this.Title); sms.ShowMessage();
                return false;
            }
            
            return true;
        }
        private void InitializeCommands()
        {
            cmdInvokeDocument = new RelayCommand<object>(items => { if (items == null) { return; } InvokeDocument(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdLoadDocument = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocument(items, "REF"); });
            cmdInsertObject = new RelayCommand<object>(items => { if (items == null) { return; } InsertObject(items); });
            cmdInsertInspType = new RelayCommand<object>(items => { if (items == null) { return; } InsertInspType(items); });
        }
        private void LoadInitialData()
        {
            try
            {
                MasterEntity.doc_cat = "IL";
                MasterEntity.doc_type = "IL";
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + STD_OBJ.doc_cat;
                MC = REPO_OBJ.GetDataWithReturnDomainObject<MC_QMS_T003>(MC, Request, "QMS_T003_BL", "QMS", "LoadInitialData", 0, "");

                ITEM_LIST = MC.MATERIAL_LIST;
                INSP_TYPE_LIST = MC.INSP_TYPE_LOT_ORG;
                SAMPLE_PRO_LIST = MC.PROCEDURE_LIST;
                EMPLOYEE_LIST = MC.PERSONNEL_LIST;
                FUN_LOC_LIST = MC.FUNC_LOCATION_LIST;
                STATUS_LIST = MC.STATUS_LIST;
                UOM_LIST = MC.UOM_LIST;
                
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertInspType(object InputValue)
        {
            try
            {
                string Request = "";
                QMS_M0047 POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.INSP_TYPE_LOT_ORG.Where(x => x.insp_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M0047>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.insp_type = POPUPEntityObject.insp_type;
                    MasterEntity.doc_source = POPUPEntityObject.lot_origin;
                    MasterEntity.OriginName = POPUPEntityObject.lo_text;

                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertObject(object InputValue)
        {
            try
            {
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
                            { POPUPEntityObject = MC.MATERIAL_LIST.Where(x => x.obj_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    MasterEntity.obj_no = POPUPEntityObject.obj_code;
                    MasterEntity.tl_code = POPUPEntityObject.doc_no;
                    MasterEntity.item_code = POPUPEntityObject.item_code;
                    MasterEntity.item_name = POPUPEntityObject.item_name;
                    MasterEntity.asset_number = POPUPEntityObject.equip_no;
                    MasterEntity.unit_code_sample = POPUPEntityObject.unit_code;
                    MasterEntity.unit_code_base = POPUPEntityObject.unit_code;
                    //MasterEntity.task_list_type = POPUPEntityObject.tl_type;
                    //MasterEntity.task_list_usage = POPUPEntityObject.tl_use;
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void LoadDocument(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            string ParametersStringValue = "";
            QMS_T003_Flip ParameterEntityObject = null;
            if (ParameterObject.GetType() == typeof(string) && ParameterObject != null)
            {
                ParametersStringValue = ParameterObject.ToString();
                Request = "LOAD_DOC" + "!@" + ParametersStringValue;
                NewRecord = false;
                MC_TEMP = REPO_OBJ.GetDataWithReturnDomainObject<MC_QMS_T003>(MC_TEMP, Request, "QMS_T003_BL", "QMS", "LOAD_DOC", 0, "");

                if (MC_TEMP.MASTER_LIST.Count > 0)
                {
                    MasterEntity = MC_TEMP.MASTER_LIST[0];
                }
            }
            else if (((IEnumerable)ParameterObject).Cast<QMS_T003_Flip>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<QMS_T003_Flip>().ToList()[0];
                Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.doc_no;
                NewRecord = false;
                MC_TEMP = REPO_OBJ.GetDataWithReturnDomainObject<MC_QMS_T003>(MC_TEMP, Request, "QMS_T003_BL", "QMS", "LOAD_DOC", 0, "");

                if (MC_TEMP.MASTER_LIST.Count > 0)
                {
                    MasterEntity = MC_TEMP.MASTER_LIST[0];
                } 
            }
            tbIndex = 0;
        }

        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<QMS_T003> result)
        {
            MasterEntity = new QMS_T003();
            NewRecord = true;
            DefaultValues();
        }

        protected override void OnDiscardAction(InquiryActionResult<QMS_T003> result)
        {
           
        }

        protected override void OnDocumentAction()
        {
           
        }

        protected override void OnFevoriteAction(InquiryActionResult<QMS_T003> result)
        {
            
        }

        protected override void OnFlipAction(InquiryActionResult<QMS_T003> result)
        {
            
        }

        protected override void OnHelpAction(InquiryActionResult<QMS_T003> result)
        {
          
        }

        protected override void OnPrintAction(InquiryActionResult<QMS_T003> result)
        {
           
        }

        protected override void OnRemoveAction(InquiryActionResult<QMS_T003> result)
        {
           
        }

        protected override void OnSaveAction(InquiryActionResult<QMS_T003> result)
        {
            try
            {
                if (Validation() == true)
                {
                    Logging();
                    this.MasterEntity.EndEdit();
                    MC_TEMP.MASTER_LIST = new List<QMS_T003>();
                    MC_TEMP.MASTER_LIST.Add(MasterEntity);

                    if (NewRecord == true)
                    {
                        MC_TEMP = REPO_OBJ.SaveWithReturnDomainObject<MC_QMS_T003>(MC_TEMP, "QMS_T003_BL", "QMS");
                    }
                    else if (NewRecord == false)
                    {
                        MC_TEMP = REPO_OBJ.UpdateWithReturnDomainObject<MC_QMS_T003>(MC_TEMP, "QMS_T003_BL", "QMS");
                    }
                    if(MC_TEMP.MASTER_LIST != null)
                    {
                        if (MC_TEMP.MASTER_LIST.Count > 0)
                        {
                            MasterEntity = MC_TEMP.MASTER_LIST[0];
                        }
                        else
                        {
                            MasterEntity = new QMS_T003();
                        }
                    }
                    
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Data Saved Successfully", this.Title); sms.ShowMessage();
                    NewRecord = false;
                }
            }
            catch (Exception ex)
            {

                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
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
        #endregion

        #region Filters
        
        
        #endregion
    }
}
