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

namespace Reflection.Modules.QMS.ViewModels
{
    class QMS_M0002_VM: WorkspaceViewModel<QMS_M0002>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<QMS_M0002>> repository = new WebServiceRepository<List<QMS_M0002>>();
        WebServiceRepository<MC_QMS_M0002> repository_MC = new WebServiceRepository<MC_QMS_M0002>();
        ObjectSerializationService obj = new ObjectSerializationService();


        #region Declaration
        public string ts_code_vm { get; set; }
        #endregion

        #region Entities
        private QMS_M0002 _MasterEntity;
        public QMS_M0002 MasterEntity
        {
            get { return _MasterEntity; }
            set { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); }
        }


        private MC_QMS_M0002 _MC;
        public MC_QMS_M0002 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }
        #endregion
        #region ICollectionView

        private ObservableCollection<QMS_M0002> _ItemsCollection;
        public ObservableCollection<QMS_M0002> ItemsCollection
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

        public QMS_M0002_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new QMS_M0002();
            MC = new MC_QMS_M0002();
            ItemsCollection = new ObservableCollection<QMS_M0002>();
            ItemsCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            LoadInitialData();
        }
        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_QMS_M0002>(MC, Request, "QMS_M0002_BL", "QMS", "LOAD_INI", 0, "");
                ItemsCollection = MC.MASTER_LIST;
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
                    foreach (QMS_M0002 item in e.NewItems)
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
        protected override void OnCreateAction(InquiryActionResult<QMS_M0002> result)
        {
            MasterEntity = new QMS_M0002();

            isNewRecord = true;

        }

        protected override void OnDiscardAction(InquiryActionResult<QMS_M0002> result)
        {

        }

        protected override void OnDocumentAction()
        {
        }
        protected override void OnRefreshCommand(InquiryActionResult<QMS_M0002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_M0002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_M0002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_M0002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_M0002> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<QMS_M0002> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<QMS_M0002> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<QMS_M0002> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<QMS_M0002> result)
        {

        }

        protected override void OnRemoveAction(InquiryActionResult<QMS_M0002> result)
        {

        }

        protected override void OnSaveAction(InquiryActionResult<QMS_M0002> result)
        {
            try
            {
                List<QMS_M0002> RequestList = new List<QMS_M0002>();
                foreach (QMS_M0002 item in ItemsCollection)
                {
                    if (item.selected == true)
                    {

                        RequestList.Add(item);
                    }
                }
                if (Validation() == true)
                {
                    strReturn = repository.Save<List<QMS_M0002>>(RequestList, "QMS_M0002_BL", "QMS");

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
