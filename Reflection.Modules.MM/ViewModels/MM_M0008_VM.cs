using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Services;
using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Specialized;
using Reflection.BusinessEntity.MM;
using System.ComponentModel;
using System.Windows.Data;

namespace Reflection.Modules.MM.ViewModels
{
    public class MM_M0008_VM : WorkspaceViewModel<MM_M0011>
    {
        WebServiceRepository<List<MM_M0011>> repository = new WebServiceRepository<List<MM_M0011>>();
        WebServiceRepository<MM_M0011_MC> repository_MC = new WebServiceRepository<MM_M0011_MC>();
        ObjectSerializationService obj = new ObjectSerializationService();

        
        #region Declarations       

        private MM_M0011_MC _MC;
        public MM_M0011_MC MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }


        private MM_M0011 _MasterEntity;
        public MM_M0011 MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        #endregion

        #region ICollectionView

        private ObservableCollection<MM_M0011> _ITCollection;
        public ObservableCollection<MM_M0011> ITCollection
        {
            get { return _ITCollection; }
            set
            {
                if (_ITCollection != value)
                {
                    _ITCollection = value;
                    ITCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("ITCollection");
                }
            }
        }
        //private ICollectionView _BACKFLIP_COLLECTION;
        //public ICollectionView BACKFLIP_COLLECTION
        //{
        //    get { return _BACKFLIP_COLLECTION; }
        //    set { _BACKFLIP_COLLECTION = value;
        //        BACKFLIP_COLLECTION.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
        //        RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        //}
        private IEnumerable _COMPANY_LIST;
        public IEnumerable COMPANY_LIST
        {
            get { return _COMPANY_LIST; }
            set
            {
                _COMPANY_LIST = value;
                RaisePropertyChanged("COMPANY_LIST");
            }
        }
        private IEnumerable _DOC_CAT_LIST;
        public IEnumerable DOC_CAT_LIST
        {
            get { return _DOC_CAT_LIST; }
            set
            {
                _DOC_CAT_LIST = value;
                RaisePropertyChanged("DOC_CAT_LIST");
            }
        }
        private IEnumerable _ITEM_CAT_LIST;
        public IEnumerable ITEM_CAT_LIST
        {
            get { return _ITEM_CAT_LIST; }
            set
            {
                _ITEM_CAT_LIST = value;
                RaisePropertyChanged("ITEM_CAT_LIST");
            }
        }
        #endregion
        #region Relay Commands Declaration


        #endregion
        #region Constructor
        public MM_M0008_VM(string ts_code) : base()
        {
            MasterEntity = new MM_M0011();
            //ITCollection = new ObservableCollection<MM_M0011>();
            MC = new MM_M0011_MC();
            //BACKFLIP_COLLECTION.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            LoadInitialData();
        }

        #endregion
        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MM_M0011_MC>(MC, Request, "MM_M0011_BL", "MM", "LOAD_INI", 0, "");
                //BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC.MASTER_ENTITY_LIST);
                //BACKFLIP_COLLECTION.Filter = new Predicate<object>(Filter);
                ITCollection = MC.MASTER_ENTITY_LIST;
                COMPANY_LIST = MC.COMPANY_LIST;
                DOC_CAT_LIST = MC.DOC_CAT_LIST;
                ITEM_CAT_LIST = MC.ITEM_CAT_LIST;

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
        private bool Validation()
        {
            return true;

        }

        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (MM_M0011 item in e.NewItems)
                    {
                        item.client = AppSessionState.client;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.selected = true;
                        item.userid = AppSessionState.UserID;
                        //item.ts_code = ts_code_vm;
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
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
        }
        #endregion

        #region Abstract Command Actions
        string strReturn = "";
        protected override void OnSaveAction(InquiryActionResult<MM_M0011> result)
        {
            try
            {
                List<MM_M0011> RequestList = new List<MM_M0011>();
                foreach (MM_M0011 item in ITCollection)
                {
                    if (item.selected == true)
                    {
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        RequestList.Add(item);
                    }
                }
                if (Validation() == true)
                {
                    strReturn = repository.Save<List<MM_M0011>>(RequestList, "MM_M0011_BL", "MM");

                    if (strReturn != "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
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

        
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<MM_M0011> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MM_M0011> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MM_M0011> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MM_M0011> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MM_M0011> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<MM_M0011> result)
        {
            MasterEntity = new MM_M0011();
        }
        protected override void OnRemoveAction(InquiryActionResult<MM_M0011> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text = String.Format("This record will be Deleted forever", this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
                //string response = repository.Delete(MasterEntity.SrNo, "FormReceivedFrmCustomer", "CRM");  
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<MM_M0011> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<MM_M0011> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<MM_M0011> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<MM_M0011> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<MM_M0011> result)
        {

        }

        #endregion
        #region Filters

        #region Filters For DataGrid   

        private string _filterString;
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
        private void FilterCollection()
        {
            //if (_ITCollection != null)
            //{
            //    _ITCollection.Refresh();
            //}
        }
        public bool Filter(object obj)
        {
            var data = obj as MM_M0011;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_filterString.ToLower()) ||
                        data.item_cat != null && data.item_cat.ToString().ToLower().Contains(_filterString.ToLower()) ||
                        data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterString.ToLower())
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
