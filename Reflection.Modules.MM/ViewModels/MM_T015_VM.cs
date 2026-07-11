using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls;
using System.Collections.Specialized;
using Reflection.BusinessEntity.MM;
using Reflection.Presentation.Common;

namespace Reflection.Modules.MM.ViewModels
{
    public class MM_T015_VM : WorkspaceViewModel<MM_T011>
    {

        #region Variable Declaration

        WebServiceRepository<MM_T011> REPOSITORY_OBJ = new WebServiceRepository<MM_T011>();
        WebServiceRepository<MC_MM_T011> REPOSITORY_OBJ_TEMP = new WebServiceRepository<MC_MM_T011>();
        MC_MM_T011 MC = new MC_MM_T011();
        MC_MM_T011 MCTEMP = new MC_MM_T011();
        ObjectSerializationService SERIALIZATION_OBJ = new ObjectSerializationService();
        IShowMessageViewService sms;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }


        private MM_T011 _MasterEntity;
        public MM_T011 MasterEntity
        {
            get
            {
                return _MasterEntity;
            }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged("MasterEntity");
                }
            }
        }

        private ObservableCollection<MM_T011> _ItemsEntity;
        public ObservableCollection<MM_T011> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value;
                    _ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("ItemsEntity");
                }
            }
        }

        private EPR_T001_A _REF_DOC;
        public EPR_T001_A REF_DOC
        {
            get
            {
                return _REF_DOC;
            }
            set
            {
                if (_REF_DOC != value)
                {
                    _REF_DOC = value;
                    RaisePropertyChanged(nameof(REF_DOC));
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
        private IEnumerable _ITEM_LIST;
        public IEnumerable ITEM_LIST
        {
            get { return _ITEM_LIST; }
            set
            {
                _ITEM_LIST = value;

                RaisePropertyChanged("ITEM_LIST");
            }
        }


        #endregion

        #region Autosuggest Initialization

        private AutoSuggestTextViewModel<dynamic> _AS_ITEM { get; set; }
        
        private AutoSuggestTextViewModel<dynamic> _AS_UOM { get; set; }
        

        #endregion

       
        #region RelayCommand

        public RelayCommand<object> cmdInsertMaterial { get; private set; }
        public RelayCommand<object> cmdInsertUnit { get; private set; }
        public RelayCommand<object> cmdDataGridRowDelete { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }

        #endregion

        #region . Constructor .
        public MM_T015_VM(string ts_code, string doc_cat)
            : base()
        {
            sms = GetViewService<IShowMessageViewService>();
            ts_code_vm = ts_code;
            doc_cat_vm = doc_cat;
            MasterEntity = new MM_T011();
            ItemsEntity = new ObservableCollection<MM_T011>();
            MC = new MC_MM_T011();
            CommandInitialisation();
        }
        public MM_T015_VM(string ts_code, string doc_cat, string doc_no)
            : base()
        {
            ts_code_vm = ts_code;
            doc_cat_vm = doc_cat;
            doc_no_vm = doc_no;
            sms = GetViewService<IShowMessageViewService>();
            ts_code_vm = ts_code;
            doc_cat_vm = doc_cat;
            MasterEntity = new MM_T011();
            ItemsEntity = new ObservableCollection<MM_T011>();
            MC = new MC_MM_T011();
            MCTEMP = new MC_MM_T011();
            CommandInitialisation();


        }
        public MM_T015_VM(string ts_code, string doc_cat, EPR_T001_A REF_ORDER)
            : base()
        {
            ts_code_vm = ts_code;
            doc_cat_vm = doc_cat;
            REF_DOC = REF_ORDER;
            sms = GetViewService<IShowMessageViewService>();
            ts_code_vm = ts_code;
            doc_cat_vm = doc_cat;
            MasterEntity = new MM_T011();
            ItemsEntity = new ObservableCollection<MM_T011>();
            MC = new MC_MM_T011();
            MCTEMP = new MC_MM_T011();
            CommandInitialisation();

        }

        #endregion

        #region Command Functions

        private void InsertUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                UOMS POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUP_ENTITY_OBJ = MC.UOM_LIST.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<UOMS>().ToList()[0];
                    }
                }
                #endregion

                if (POPUP_ENTITY_OBJ != null)
                {
                    MasterEntity.unit_code = POPUP_ENTITY_OBJ.unit_code;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void InsertMaterial(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify) // NOTE: do not allow to add Material without MasterEntity fields like comp_code,Location etc.
        {
            try
            {
                string Request = "";
                STD_ITEM POPUP_ENTITY_OBJ = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUP_ENTITY_OBJ = MC.ITEM_LIST.Where(x => x.item_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_ITEM>().Count() > 0)
                    {
                        POPUP_ENTITY_OBJ = ((IEnumerable)InputValue).Cast<STD_ITEM>().ToList()[0];
                    }
                }
                #endregion
                if (POPUP_ENTITY_OBJ != null && MasterEntity != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.obj_no = POPUP_ENTITY_OBJ.item_code;
                    MasterEntity.obj_name = POPUP_ENTITY_OBJ.item_name;
                    MasterEntity.unit_code = POPUP_ENTITY_OBJ.unit_code;
                    MasterEntity.active = "1";
                    MasterEntity.qty = 1;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        #endregion

        #region Change Notification
      
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                try
                {
                    foreach (MM_T011 item in e.NewItems)
                    {
                        item.client = AppSessionState.client;
                        item.active = "1";

                        if (REF_DOC != null)
                        {
                            if (!string.IsNullOrWhiteSpace(REF_DOC.order_no))
                            {
                                item.order_no = REF_DOC.order_no;
                                item.op_no = REF_DOC.operation_no;
                                item.op_name = REF_DOC.operation_desc;
                                item.op_row_id = REF_DOC.id;
                                item.item_no = REF_DOC.id;
                                item.op_row_id = REF_DOC.id;
                                item.comp_code = REF_DOC.comp_code;
                            }
                        }

                    }
                }
                catch (Exception ex)
                { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
            }
            if (e.Action == NotifyCollectionChangedAction.Replace)
            { }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            { }
            if (e.Action == NotifyCollectionChangedAction.Move)
            { }
        }
        #endregion

        #region . User Defined Function.
        private void CommandInitialisation()
        {
            cmdInsertMaterial = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertMaterial(cmdPara, true, true, true); });
            cmdInsertUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOM(cmdPara, false, true, true); });
            cmdDataGridRowDelete = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow_Item(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
        }
        private void LoadInitialData()
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + REF_DOC.order_no + "!@" + REF_DOC.operation_no + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm;
                MC = REPOSITORY_OBJ_TEMP.GetDataWithReturnDomainObject<MC_MM_T011>(MC, Request, "MM_T011_BL", "MM", Request, 0, "LOAD_INI");

                UNIT_LIST = MC.UOM_LIST;
                ITEM_LIST = MC.ITEM_LIST;

                if (MC.ITEMS_ENTITY_LIST != null)
                {
                    if (MC.ITEMS_ENTITY_LIST.Count > 0)
                    {
                        ItemsEntity = MC.ITEMS_ENTITY_LIST;
                    }
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
     
        
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                ItemsEntity.Remove(MasterEntity);
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                LoadInitialData();
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        
        private void Logging()
        {
            MasterEntity.ts_code = this.ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;

            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private bool Validation()
        {
            if (ItemsEntity.Count < 1)//when form is blank and we save the record
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Item........"); sms.ShowMessage();
                return false;
            }
            else
            {
                // Validation for Quantity Item Duplication and Unit Code For Item Details
                foreach (var o in ItemsEntity)
                {
                    if (!string.IsNullOrWhiteSpace(o.obj_no))
                    {
                        int flag = 0; //duplicate entry is allowed so commented : pending delete
                        if (o.id == 0)
                        {
                            foreach (var p in ItemsEntity)
                            {
                                if (o.obj_no == p.obj_no)
                                {
                                    flag++;
                                }
                            }
                            if (flag > 1)
                            {
                                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Cannot Save Duplicate Item {0}", o.obj_no); sms.ShowMessage();
                                return false;
                            }
                        }
                        if (o.qty == null || o.qty == 0 || o.qty.HasValue == false)
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Quantity cannot be null or 0 for the item {0}", o.obj_no); sms.ShowMessage();
                            return false;
                        }
                        if (string.IsNullOrWhiteSpace(o.unit_code))
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Enter Valid Unit Code for the item {0}", o.obj_no); sms.ShowMessage();
                            return false;
                        }
                    }
                    else
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("please select Item ........"); sms.ShowMessage();
                        return false;
                    }
                }
            }
            return true;
        }

        #endregion
       
        
       
        #region Abstract Commands

        protected override void OnSaveAction(InquiryActionResult<MM_T011> result)
        {
            try
            {
                CursorControl.SetBusyState();
                Logging();

                if (Validation() == true)
                {
                    MCTEMP.ITEMS_ENTITY_LIST = ItemsEntity;

                    //MasterEntity.XDOC_A = SERIALIZATION_OBJ.ObjectToXML(ItemsEntity);
                    MCTEMP = REPOSITORY_OBJ_TEMP.SaveWithReturnDomainObject<MC_MM_T011>(MCTEMP, "MM_T011_BL", "MM");
                    ItemsEntity = MCTEMP.ITEMS_ENTITY_LIST;
                }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        protected override void OnCreateAction(InquiryActionResult<MM_T011> result)
        {
            MasterEntity = new MM_T011();
            ItemsEntity = new ObservableCollection<MM_T011>();
        }
        protected override void OnRemoveAction(InquiryActionResult<MM_T011> result)
        {
            sms.ButtonSetup = DialogButton.Ok;
            sms.Caption = "Delete Changes";
            sms.Text = String.Format("This record will delete forever '{0}'", this.Title);

            if (sms.ShowMessage() == DialogResult.Ok)
            {
                this.MasterEntity.CancelEdit();
                string response = REPOSITORY_OBJ.Delete(MasterEntity.id.ToString(), "MM_T011_BL", "MM");
                MasterEntity = new MM_T011();
                ItemsEntity = new ObservableCollection<MM_T011>();
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<MM_T011> result)
        {
            MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<MM_T011> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<MM_T011> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<MM_T011> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<MM_T011> result)
        {
        }
        protected override void OnDocumentAction()
        {
        }
        protected override void OnRefreshCommand(InquiryActionResult<MM_T011> result)
        {
        }
        protected override void OnLedgerViewCommand(InquiryActionResult<MM_T011> result)
        {
        }
        protected override void OnValidateCommand(InquiryActionResult<MM_T011> result)
        {
        }
        protected override void OnTraceCommand(InquiryActionResult<MM_T011> result)
        {
        }
        protected override void OnMailCommand(InquiryActionResult<MM_T011> result)
        {
        }

        #endregion

    }
}
