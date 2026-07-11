using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using System.Windows;
using Reflection.BusinessEntity.Admin;
using Reflection.BusinessEntity;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Services;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Reflection.BusinessEntity.ADM;
using System.Collections.Specialized;

namespace Reflection.Modules.MM.ViewModels
{
    public class MM_M0012_VM : WorkspaceViewModel<STD_BE_A>
    {
        bool isNewRecord = true;
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

        private STD_BE_A _MasterEntity;
        public STD_BE_A MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }
        private ObservableCollection<STD_BE_A> _ItemsEntity;
        public ObservableCollection<STD_BE_A> ItemsEntity
        {
            get
            {
                return _ItemsEntity;
            }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value;
                    ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("ItemsEntity");
                }
            }
        }
        private int _dgSelectedIndex;
        public int dgSelectedIndex
        {
            get
            { return _dgSelectedIndex; }
            set
            {
                if (_dgSelectedIndex != value)
                {
                    _dgSelectedIndex = value;
                    RaisePropertyChanged("dgSelectedIndex");
                }
            }
        }
        private STD_BE_A _ItemEntityObject;
        public STD_BE_A ItemEntityObject
        {
            get
            {
                return _ItemEntityObject;
            }
            set
            {
                if (_ItemEntityObject != value)
                {
                    _ItemEntityObject = value;
                    RaisePropertyChanged("ItemEntityObject");
                }
            }
        }

        private List<STD_BE_A> _SelectedList;
        public List<STD_BE_A> SelectedList
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

        private ICollectionView _ITEMS_COLLECTION_VIVE;
        public ICollectionView ITEMS_COLLECTION_VIVE
        {
            get { return _ITEMS_COLLECTION_VIVE; }
            set { _ITEMS_COLLECTION_VIVE = value; RaisePropertyChanged("ITEMS_COLLECTION_VIVE"); }
        }
        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdSelectionChanged_ITEM { get; private set; }
        #endregion

        #region Constructor
        public MM_M0012_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new STD_BE_A();
            ItemEntityObject = new STD_BE_A();
            SelectedList = new List<STD_BE_A>();
            ItemsEntity = new ObservableCollection<STD_BE_A>();
            MC = new MC_GEN_BE();
            MC_TEMP = new MC_GEN_BE();
            sms = this.GetViewService<IShowMessageViewService>();
            cmdSelectionChanged_ITEM = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_ITEM(items); });
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_GEN_BE>(MC, Request, "MM_M0031_BL", "MM", "LOAD_INI", 0, "");

                DefaultValues();
                ItemsEntity = MC.ItemsEntity;
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void DefaultValues()
        {
            MasterEntity.client = AppSessionState.client;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.userid = AppSessionState.UserID;
        }
        private bool Validation()
        {
            foreach (var o in ItemsEntity)
            {
                int flag = 0;
                if (o.selected == true)
                {
                    foreach (var p in ItemsEntity)
                    {
                        if (o.group_code == p.group_code)
                        {
                            flag++;
                        }
                    }
                    if (flag > 1)
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Duplicate Record not allowed for the Country {0} and Product Group {1} and Company {2}", o.ctry_code, o.group_code, o.comp_code); sms.ShowMessage();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(o.group_code))
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Group code required", this.Title); sms.ShowMessage();
                        return false;
                    }
                    if (string.IsNullOrWhiteSpace(o.group_name))
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Group name required", this.Title);
                        sms.ShowMessage(); return false;
                    }
                }
            }
            return true;
        }
        private void SelectionChanged_ITEM(object InputValue)
        {
            try
            {
                ItemEntityObject = (STD_BE_A)InputValue;
            }
            catch (Exception ex) { }
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
            try
            {
                List<STD_BE_A> RequestList = new List<STD_BE_A>();
                foreach (STD_BE_A item in ItemsEntity)
                {
                    if (item.selected == true)
                    {
                        RequestList.Add(item);
                    }
                }
                if (Validation() == true)
                {
                    string strReturn = repository.Save<List<STD_BE_A>>(RequestList, "MM_M0031_BL", "MM");

                    if (SelectedList != null)
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record Saved and Updated Successfully!", this.Title); sms.ShowMessage();
                    }
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
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
            isNewRecord = true;
            MasterEntity = new STD_BE_A();
            ItemEntityObject = new STD_BE_A();
            SelectedList = new List<STD_BE_A>();
            ItemsEntity = new ObservableCollection<STD_BE_A>();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<STD_BE_A> result)
        {
            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Delete Changes"; sms.Text = String.Format("This record will be Deleted forever", this.Title);
            if (sms.ShowMessage() == DialogResult.Ok)
            {
                //string response = repository.Delete(MasterEntity.SrNo, "FormReceivedFrmCustomer", "CRM");  
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

        #region Filters

        #region Filters For DataGrid   

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
                if (!string.IsNullOrEmpty(_FLTR_STRING_VIEW))
                {
                    return (data.group_cat != null && (data.group_cat ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.group_code != null && (data.group_code ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.group_name != null && (data.group_name ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.hsn_code != null && (data.hsn_code ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.short_text != null && (data.short_text ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.ctry_code != null && (data.ctry_code ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.comp_code != null && (data.comp_code ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower()) ||
                            data.cat_name != null && (data.cat_name ?? "").ToString().ToLower().Contains(_FLTR_STRING_VIEW.ToLower())
                            );
                }
                return true;
            }
            return false;
        }



        #endregion

        #endregion
    }

}





