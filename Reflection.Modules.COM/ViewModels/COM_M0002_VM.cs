using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.BusinessEntity;
using Reflection.Presentation.Services;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace Reflection.Modules.COM.ViewModels
{
    public class COM_M0002_VM : WorkspaceViewModel<STD_BE_A>
    {
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }
        IShowMessageViewService sms;
        WebServiceRepository<List<STD_BE_A>> repository = new WebServiceRepository<List<STD_BE_A>>();
        WebServiceRepository<MC_GEN_BE> repository_MC = new WebServiceRepository<MC_GEN_BE>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region Declarations       

        private MC_GEN_BE _MC;
        public MC_GEN_BE MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MC_GEN_BE _MC_TEMP;
        public MC_GEN_BE MC_TEMP
        {
            get { return _MC_TEMP; }
            set { _MC_TEMP = value; RaisePropertyChanged("MC_TEMP"); }
        }

        private STD_BE_A _StandardEntity;
        public STD_BE_A StandardEntity
        {
            get
            { return _StandardEntity; }
            set
            {
                _StandardEntity = value;
                RaisePropertyChanged("StandardEntity");
            }
        }
        private ObservableCollection<STD_BE_A> _StandardEntityList;
        public ObservableCollection<STD_BE_A> StandardEntityList
        {
            get
            {
                return _StandardEntityList;
            }
            set
            {
                if (_StandardEntityList != value)
                {
                    _StandardEntityList = value;
                    _StandardEntityList.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("StandardEntityList");
                }
            }
        }

        #endregion

        #region Constructor
        public COM_M0002_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            StandardEntity = new STD_BE_A();
            StandardEntityList = new ObservableCollection<STD_BE_A>();
            MC = new MC_GEN_BE();
            MC_TEMP = new MC_GEN_BE();
            sms = this.GetViewService<IShowMessageViewService>();
            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_GEN_BE>(MC, Request, "COM_M0002_BL", "COM", "LOAD_INI", 0, "");

                StandardEntityList = MC.STD_ENTITY_COL;
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private bool Validation()
        {
            foreach (var o in StandardEntityList)
            {
                int flag = 0;
                if (o.selected == true)
                {
                    foreach (var p in StandardEntityList)
                    {
                        if (o.obj_type == p.obj_type)
                        {
                            flag++;
                        }
                    }
                    if (flag > 1)
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Duplicate Record not allowed for the Country {0} and Product Group {1} and Company {2}", o.ctry_code, o.group_code, o.comp_code); sms.ShowMessage();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(o.obj_type))
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Object Type code required for the object name {0} ", o.obj_name); sms.ShowMessage();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(o.obj_name))
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Object Name required for the object Type code {0} ", o.obj_type); sms.ShowMessage();
                        return false;
                    }
                }
            }
            return true;
        }

        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (STD_BE_A item in e.NewItems)
                    {
                        item.client = AppSessionState.client;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.selected = true;
                        item.userid = AppSessionState.UserID;
                        item.ts_code = ts_code_vm;
                        item.active = "1";
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Replace)
                { }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                { }
                if (e.Action == NotifyCollectionChangedAction.Move)
                { }
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        #endregion

        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<STD_BE_A> result)
        {
            //try
            //{
            //    List<STD_BE_A> RequestList = new List<STD_BE_A>();
            //    foreach (STD_BE_A item in StandardEntityList)
            //    {
            //        if (item.selected == true)
            //        {
            //            RequestList.Add(item);
            //        }
            //    }
            //    if (Validation() == true)
            //    {
            //        string strReturn = repository.Save<List<STD_BE_A>>(RequestList, "COM_M0002_BL", "COM");

            //        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record Saved Successfully!", this.Title); sms.ShowMessage();
            //    }
            //}
            //catch (Exception ex)
            //{
            //    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            //}
        }
        protected override void OnDocumentAction()
        { }
        protected override void OnRefreshCommand(InquiryActionResult<STD_BE_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<STD_BE_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<STD_BE_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<STD_BE_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<STD_BE_A> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<STD_BE_A> result)
        {
            StandardEntity = new STD_BE_A();
        }
        protected override void OnRemoveAction(InquiryActionResult<STD_BE_A> result)
        {
            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Delete Changes"; sms.Text = String.Format("This record will be Deleted forever", this.Title);
            if (sms.ShowMessage() == DialogResult.Ok)
            {
                //string response = repository.Delete(StandardEntity.SrNo, "FormReceivedFrmCustomer", "CRM");  
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<STD_BE_A> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<STD_BE_A> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<STD_BE_A> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<STD_BE_A> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<STD_BE_A> result)
        {

        }

        #endregion

        #region Filters For DataGrid   

        private ICollectionView _ITEMS_COLLECTION_VIVE;
        public ICollectionView ITEMS_COLLECTION_VIVE
        {
            get { return _ITEMS_COLLECTION_VIVE; }
            set { _ITEMS_COLLECTION_VIVE = value; RaisePropertyChanged("ITEMS_COLLECTION_VIVE"); }
        }

        private string _FLTR_STRING_VIEW;
        public string FLTR_STRING_VIEW
        {
            get { return _FLTR_STRING_VIEW; }
            set
            {
                if (_FLTR_STRING_VIEW != value)
                {
                    _FLTR_STRING_VIEW = value;
                    RaisePropertyChanged("FLTR_STRING_VIEW");
                    FilterCollection();
                }
            }
        }
        private void FilterCollection()
        {
            if (_ITEMS_COLLECTION_VIVE != null)
            {
                _ITEMS_COLLECTION_VIVE.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as STD_BE_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FLTR_STRING_VIEW))
                {
                    return (data.obj_type != null && (data.obj_type ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.obj_name != null && (data.obj_name ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.obj_group != null && (data.obj_group ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower())
                            );
                }
                return true;
            }
            return false;
        }



        #endregion

    }


}





