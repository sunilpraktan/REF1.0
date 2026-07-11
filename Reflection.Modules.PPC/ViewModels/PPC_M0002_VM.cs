using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity.PPC;
using System.Collections.Specialized;

namespace Reflection.Modules.PPC.ViewModels
{
    class PPC_M0002_VM:WorkspaceViewModel<PPC_M0002>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<PPC_M0002>> repository = new WebServiceRepository<List<PPC_M0002>>();
        WebServiceRepository<MC_PPC_M0002> repository_MC = new WebServiceRepository<MC_PPC_M0002>();
        ObjectSerializationService obj = new ObjectSerializationService();


        #region Declaration
        public string ts_code_vm { get; set; }
        #endregion

        #region Entities
        private PPC_M0002 _MasterEntity;
        public PPC_M0002 MasterEntity
        {
            get { return _MasterEntity; }
            set { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); }
        }


        private MC_PPC_M0002 _MC;
        public MC_PPC_M0002 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }
        #endregion
        #region ICollectionView

        private ObservableCollection<PPC_M0002> _ItemsCollection;
        public ObservableCollection<PPC_M0002> ItemsCollection
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

        public PPC_M0002_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new PPC_M0002();
            MC = new MC_PPC_M0002();
            ItemsCollection = new ObservableCollection<PPC_M0002>();
            ItemsCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            LoadInitialData();
        }
        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_PPC_M0002>(MC, Request, "PPC_M0002_BL", "PPC", "LOAD_INI", 0, "");
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
                    foreach (PPC_M0002 item in e.NewItems)
                    {
                        item.client = AppSessionState.client;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.location_id = AppSessionState.OBJ_LOCATION.location_id;
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
        protected override void OnCreateAction(InquiryActionResult<PPC_M0002> result)
        {
            MasterEntity = new PPC_M0002();

            isNewRecord = true;

        }

        protected override void OnDiscardAction(InquiryActionResult<PPC_M0002> result)
        {

        }

        protected override void OnDocumentAction()
        {
        }
        protected override void OnRefreshCommand(InquiryActionResult<PPC_M0002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PPC_M0002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PPC_M0002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PPC_M0002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PPC_M0002> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<PPC_M0002> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<PPC_M0002> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<PPC_M0002> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<PPC_M0002> result)
        {

        }

        protected override void OnRemoveAction(InquiryActionResult<PPC_M0002> result)
        {

        }

        protected override void OnSaveAction(InquiryActionResult<PPC_M0002> result)
        {
            try
            {
                List<PPC_M0002> RequestList = new List<PPC_M0002>();
                foreach (PPC_M0002 item in ItemsCollection)
                {
                    if (item.selected == true)
                    {

                        RequestList.Add(item);
                    }
                }
                if (Validation() == true)
                {
                    strReturn = repository.Save<List<PPC_M0002>>(RequestList, "PPC_M0002_BL", "PPC");

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

