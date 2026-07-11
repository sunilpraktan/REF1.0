using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services.Convertors;
using System.Windows;
using System.Collections.Specialized;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.COM;
using Reflection.BusinessEntity.ADM;
using System.Reflection;
using System.IO;
using Reflection.Presentation.Core.VirtualDesktops;
using GalaSoft.MvvmLight.Ioc;

namespace Reflection.Modules.PRO.ViewModels
{
    public class PRO_U0001_VM : WorkspaceViewModel<PUR_T001_A>
    {

        #region Declaration
       
        private STD_LIST_BE _ITEM_OBJ;
        public STD_LIST_BE ITEM_OBJ
        {
            get
            {
                return _ITEM_OBJ;
            }
            set
            {
                if (_ITEM_OBJ != value)
                {
                    _ITEM_OBJ = value;
                    RaisePropertyChanged("ITEM_OBJ");
                }
            }
        }

        private List<STD_LIST_BE> _ITEM_LIST_OBJ;
        public List<STD_LIST_BE> ITEM_LIST_OBJ
        {
            get
            {
                return _ITEM_LIST_OBJ;
            }
            set
            {
                if (_ITEM_LIST_OBJ != value)
                {
                    _ITEM_LIST_OBJ = value;
                    RaisePropertyChanged("ITEM_LIST_OBJ");
                }
            }
        }

        private ICollectionView _DataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _DataGridCollection; }
            set { _DataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }


        #endregion

        #region RelayCommand
        public RelayCommand<object> cmdReturnPR { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }

        #endregion

       
        public PRO_U0001_VM(string doc_cat, object para_obj) : base()
        {
            CursorControl.SetBusyState();
            ITEM_OBJ = new STD_LIST_BE();
            ITEM_LIST_OBJ = new List<STD_LIST_BE>();
            CommandInitialization();

            ITEM_LIST_OBJ = (List<STD_LIST_BE>)para_obj;
            DataGridCollection = CollectionViewSource.GetDefaultView(para_obj);
            DataGridCollection.Filter = new Predicate<object>(FilterItemsList);
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
                    //Request = MasterEntity.client + "!@" + MasterEntity.comp_code + "!@" + InputValue.ToString();
                    //objRef.Invoke_Documet(Request, Request);
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
                //if (REF_OBJECT != null && REF_OBJECT.req_code == "VIEW")
                //{
                //    //List<STD_LIST_BE> STD_LIST_OBJ = new List<STD_LIST_BE>();
                //    //STD_LIST_OBJ.Add(REF_OBJECT);
                //    LoadInitialData();
                //    LoadBackFilpDetailstemp(REF_OBJECT.doc_no);
                //}
                //else if (doc_no_vm != null && ts_code_vm != null)
                //{
                //    //LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                //    LoadBackFilpDetailstemp(doc_no_vm);
                //    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                //    AppSessionState.ViewOtherRecordAllowed = true;
                //}
                //else
                //{
                //    LoadInitialData();
                //    DefaultValues();
                //}
                var msg = new NotificationMessage("PRO_U0001_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
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
        private void CommandInitialization()
        {
            cmdReturnPR = new RelayCommand<object>(items => { if (items == null) { return; } ReturnPR(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
        }
        private void ReturnPR(object Parameter)
        {
            try
            {
                CursorControl.SetBusyState();
                List<STD_LIST_BE> IL_OBJ = new List<STD_LIST_BE>();

                foreach (var item in ITEM_LIST_OBJ)
                {
                    if (item.selected==true)
                    {
                        IL_OBJ.Add(item);
                    }
                }
                

                if (IL_OBJ != null)
                {
                    if (IL_OBJ.Count > 0)
                    {
                        Messenger.Default.Send<NotificationMessage>(new NotificationMessage(IL_OBJ, "SELECTED_PR_ITEMS"));
                        this.Close();
                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Data not exists", this.Title);
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
        }

        private string _FLTR_STR_ITEMS;
        public string FLTR_STR_ITEMS
        {
            get { return _FLTR_STR_ITEMS; }
            set
            {
                _FLTR_STR_ITEMS = value;
                RaisePropertyChanged("FLTR_STR_ITEMS");
                FilterCollection_Items();
            }
        }
        private void FilterCollection_Items()
        {
            if (_DataGridCollection != null)
            {
                _DataGridCollection.Refresh();
            }
        }
        public bool FilterItemsList(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FLTR_STR_ITEMS))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(FLTR_STR_ITEMS.ToLower()) ||
                           (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(FLTR_STR_ITEMS.ToLower())) ||
                           (data.item_code != null && data.item_code.ToString().ToLower().Contains(FLTR_STR_ITEMS.ToLower())) ||
                           (data.item_name != null && data.item_name.ToString().ToLower().Contains(FLTR_STR_ITEMS.ToLower())) ||
                           (data.doc_type_name != null && data.doc_type_name.ToString().ToLower().Contains(FLTR_STR_ITEMS.ToLower())) ||
                           (data.ref_doc_cat != null && data.ref_doc_cat.ToString().ToLower().Contains(FLTR_STR_ITEMS.ToLower())) ||
                           (data.ref_doc_type != null && data.ref_doc_type.ToString().ToLower().Contains(FLTR_STR_ITEMS.ToLower())) ||
                           (data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(FLTR_STR_ITEMS.ToLower())) ||
                           (data.po_code != null && data.po_code.ToString().ToLower().Contains(FLTR_STR_ITEMS.ToLower())) ||
                           (data.pg_code != null && data.pg_code.ToString().ToLower().Contains(FLTR_STR_ITEMS.ToLower())) ||
                           (data.location_id != null && data.location_id.ToString().ToLower().Contains(FLTR_STR_ITEMS.ToLower())) ||
                           (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(FLTR_STR_ITEMS.ToLower())) ||
                           (data.party_code != null && data.party_code.ToString().ToLower().Contains(FLTR_STR_ITEMS.ToLower())) ||
                           (data.party_name != null && data.party_name.ToString().ToLower().Contains(FLTR_STR_ITEMS.ToLower())) ||
                           (data.emp_id != null && data.emp_id.ToString().ToLower().Contains(FLTR_STR_ITEMS.ToLower())) ||
                           data.emp_name != null && data.emp_name.ToString().ToLower().Contains(FLTR_STR_ITEMS.ToLower()));

                }
                return true;
            }
            return false;
        }


        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<PUR_T001_A> result)
        {}
        protected override void OnCreateAction(InquiryActionResult<PUR_T001_A> result)
        {}
        protected override void OnRemoveAction(InquiryActionResult<PUR_T001_A> result)
        {}
        protected override void OnDiscardAction(InquiryActionResult<PUR_T001_A> result)
        {}
        protected override void OnFevoriteAction(InquiryActionResult<PUR_T001_A> result)
        {}
        protected override void OnFlipAction(InquiryActionResult<PUR_T001_A> result)
        {}
        protected override void OnHelpAction(InquiryActionResult<PUR_T001_A> result)
        {}
        protected override void OnPrintAction(InquiryActionResult<PUR_T001_A> result)
        {}
        protected override void OnDocumentAction()
        {}
        protected override void OnRefreshCommand(InquiryActionResult<PUR_T001_A> result)
        {}
        protected override void OnLedgerViewCommand(InquiryActionResult<PUR_T001_A> result)
        {}
        protected override void OnValidateCommand(InquiryActionResult<PUR_T001_A> result)
        {}
        protected override void OnTraceCommand(InquiryActionResult<PUR_T001_A> result)
        {}
        protected override void OnMailCommand(InquiryActionResult<PUR_T001_A> result)
        {}
        #endregion
    }
}
