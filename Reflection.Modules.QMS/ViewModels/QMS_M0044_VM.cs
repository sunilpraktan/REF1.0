using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity.QMS;
using System.Collections.Specialized;
using System.Collections;
namespace Reflection.Modules.QMS.ViewModels
{
    class QMS_M0044_VM: WorkspaceViewModel<QMS_M0044>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<QMS_M0044>> repository = new WebServiceRepository<List<QMS_M0044>>();
        WebServiceRepository<MC_QMS_M0044> repository_MC = new WebServiceRepository<MC_QMS_M0044>();
        ObjectSerializationService obj = new ObjectSerializationService();


        #region Declaration
        public string ts_code_vm { get; set; }
        #endregion

        #region Entities
        private QMS_M0044 _MasterEntity;
        public QMS_M0044 MasterEntity
        {
            get { return _MasterEntity; }
            set { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); }
        }


        private MC_QMS_M0044 _MC;
        public MC_QMS_M0044 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }
        #endregion
        #region ICollectionView

        private ObservableCollection<QMS_M0044> _ItemsCollection;
        public ObservableCollection<QMS_M0044> ItemsCollection
        {
            get { return _ItemsCollection; }
            set
            {
                if (_ItemsCollection != value)
                {
                    _ItemsCollection = value;
                    ItemsCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("ItemsCollection");
                }
            }
        }
        #endregion
        #region ICollectionView
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

        public QMS_M0044_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new QMS_M0044();
            MC = new MC_QMS_M0044();
            ItemsCollection = new ObservableCollection<QMS_M0044>();
            ItemsCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            LoadInitialData();
        }
        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_QMS_M0044>(MC, Request, "QMS_M0044_BL", "QMS", "LOAD_INI", 0, "");
                ItemsCollection = MC.MASTER_LIST;
                ITEM_LIST = MC.ITEM_LIST;
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
        private bool Validation()//return true is green signal for save
        {
            return true;

        }

        #endregion
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (QMS_M0044 item in e.NewItems)
                    {
                        item.client = AppSessionState.client;
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

        #region Abstract Methods
        string strReturn = "";
        protected override void OnCreateAction(InquiryActionResult<QMS_M0044> result)
        {
            MasterEntity = new QMS_M0044();

            isNewRecord = true;

        }

        protected override void OnDiscardAction(InquiryActionResult<QMS_M0044> result)
        {

        }

        protected override void OnDocumentAction()
        {
        }
        protected override void OnRefreshCommand(InquiryActionResult<QMS_M0044> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_M0044> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_M0044> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_M0044> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_M0044> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<QMS_M0044> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<QMS_M0044> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<QMS_M0044> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<QMS_M0044> result)
        {

        }

        protected override void OnRemoveAction(InquiryActionResult<QMS_M0044> result)
        {

        }

        protected override void OnSaveAction(InquiryActionResult<QMS_M0044> result)
        {
            try
            {
                List<QMS_M0044> RequestList = new List<QMS_M0044>();
                foreach (QMS_M0044 item in ItemsCollection)
                {
                    if (item.selected == true)
                    {

                        RequestList.Add(item);
                    }
                }
                if (Validation() == true)
                {
                    strReturn = repository.Save<List<QMS_M0044>>(RequestList, "QMS_M0044_BL", "QMS");

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


        #endregion
    }
}
