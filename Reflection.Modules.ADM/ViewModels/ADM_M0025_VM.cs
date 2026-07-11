using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity.ADM;
using System.Collections.Specialized;
using Reflection.BusinessEntity;

namespace Reflection.Modules.ADM.ViewModels
{
   public class ADM_M0025_VM:WorkspaceViewModel<ADM_M025>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ADM_M025>> repository = new WebServiceRepository<List<ADM_M025>>();
        WebServiceRepository<MC_ADM_M0025> repository_MC = new WebServiceRepository<MC_ADM_M0025>();
        ObjectSerializationService obj = new ObjectSerializationService();


        #region Declaration
        public string ts_code_vm { get; set; }
        #endregion

        #region Entities
        private ADM_M025 _MasterEntity;
        public ADM_M025 MasterEntity
        {
            get { return _MasterEntity; }
            set { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); }
        }


        private MC_ADM_M0025 _MC;
        public MC_ADM_M0025 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }
        #endregion
        #region ICollectionView

        private ObservableCollection<ADM_M025> _ItemsCollection;
        public ObservableCollection<ADM_M025> ItemsCollection
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

        public ADM_M0025_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new ADM_M025();
            MC = new MC_ADM_M0025();
            ItemsCollection = new ObservableCollection<ADM_M025>();
            ItemsCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            LoadInitialData();
        }
        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LOAD_INI" + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_ADM_M0025>(MC, Request, "ADM_M0025_BL", "ADM", "LOAD_INI", 0, "");
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
                    foreach (ADM_M025 item in e.NewItems)
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
        protected override void OnCreateAction(InquiryActionResult<ADM_M025> result)
        {
            MasterEntity = new ADM_M025();

            isNewRecord = true;

        }

        protected override void OnDiscardAction(InquiryActionResult<ADM_M025> result)
        {

        }

        protected override void OnDocumentAction()
        {
        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M025> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M025> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M025> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<ADM_M025> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<ADM_M025> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<ADM_M025> result)
        {

        }

        protected override void OnRemoveAction(InquiryActionResult<ADM_M025> result)
        {

        }

        protected override void OnSaveAction(InquiryActionResult<ADM_M025> result)
        {
            try
            {
                List<ADM_M025> RequestList = new List<ADM_M025>();
                foreach (ADM_M025 item in ItemsCollection)
                {
                    if (item.selected == true)
                    {

                        RequestList.Add(item);
                    }
                }
                if (Validation() == true)
                {
                    strReturn = repository.Save<List<ADM_M025>>(RequestList, "ADM_M025_BL", "ADM");

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
