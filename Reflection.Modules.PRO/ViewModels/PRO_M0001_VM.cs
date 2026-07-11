using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Services;
using System.Windows.Data;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity.Admin;
using System.ComponentModel;
using Reflection.BusinessEntity;
using System.Collections.Specialized;
using GalaSoft.MvvmLight.Command;

namespace Reflection.Modules.PRO.ViewModels
{
    public class PRO_M0001_VM : WorkspaceViewModel<ADM_M001_M>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ADM_M001_M>> repository = new WebServiceRepository<List<ADM_M001_M>>();
        WebServiceRepository<MultipleContext_ADM_M001_M> repository_MC = new WebServiceRepository<MultipleContext_ADM_M001_M>();
        WebServiceRepository<MultipleContext_ADM_M001_M> repository_MCTemp = new WebServiceRepository<MultipleContext_ADM_M001_M>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region Declarations       

        private MultipleContext_ADM_M001_M _MC;
        public MultipleContext_ADM_M001_M MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ADM_M001_M _MCTemp;
        public MultipleContext_ADM_M001_M MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_ADM_M001_M _MCTemp1;
        public MultipleContext_ADM_M001_M MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private ADM_M001_M _MasterEntity;
        public ADM_M001_M MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private int _dgSelectedIndexPO;
        public int dgSelectedIndexPO
        {
            get
            { return _dgSelectedIndexPO; }
            set
            {
                if (_dgSelectedIndexPO != value)
                {
                    _dgSelectedIndexPO = value;
                    RaisePropertyChanged("dgSelectedIndexPO");
                }
            }
        }

        #endregion

        #region ICollectionView

        private ObservableCollection<ADM_M001_M> _POCollection;
        public ObservableCollection<ADM_M001_M> POCollection
        {
            get { return _POCollection; }
            set
            {
                if (_POCollection != value)
                {
                    _POCollection = value;
                    POCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("POCollection");
                }
            }
        }

        private ICollectionView _POCollection1;
        public ICollectionView POCollection1
        {
            get { return _POCollection1; }
            set { _POCollection1 = value; RaisePropertyChanged("POCollection1"); }
        }

        private List<ADM_M001_M> _SelectedList;
        public List<ADM_M001_M> SelectedList
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

        private List<COM_T003> _AttachmentCollection;
        public List<COM_T003> AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set
            {
                if (_AttachmentCollection != value)
                {
                    _AttachmentCollection = value;
                    RaisePropertyChanged("AttachmentCollection");
                }
            }
        }
        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdSelectionChanged_ITEM { get; private set; }
        #endregion

        #region Event Handler

        #endregion

        #region Constructor
        public PRO_M0001_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M001_M();
            POCollection = new ObservableCollection<ADM_M001_M>();

            MC = new MultipleContext_ADM_M001_M();
            MCTemp = new MultipleContext_ADM_M001_M();
            MCTemp1 = new MultipleContext_ADM_M001_M();
            cmdSelectionChanged_ITEM = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_ITEM(items); });
            POCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);

            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M001_M>(MC, Request, "PurchaseOrganisationMaster", "Administration", "LoadInitialData", 0, "");

                DefaultValues();

                POCollection = MC.POList;
                //SelectedList = (MC.POList).ToList();
                SelectedList = POCollection.ToList();

                POCollection1 = CollectionViewSource.GetDefaultView(MC.POList);
                POCollection1.Filter = new Predicate<object>(Filter);

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
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private void SelectionChanged_ITEM(object InputValue)
        {
            try
            {
                MasterEntity = (ADM_M001_M)InputValue;
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ADM_M001_M item in e.NewItems)
                    {
                        item.client = AppSessionState.client;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.Click = true;
                        item.userid = AppSessionState.UserID;
                        //item.ts_code = ts_code_vm;
                        item.active = true;
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

        private bool Validation()
        {
            if (MasterEntity.po_code == null || MasterEntity.po_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter the PO Code...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.pur_org == null || MasterEntity.pur_org == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter the Purchase Organisation...");
                showMessageService.ShowMessage();
                return false;
            }

            return true;
        }

        #endregion

        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<ADM_M001_M> result)
        {
            try
            {
                List<ADM_M001_M> RequestList = new List<ADM_M001_M>();
                foreach (ADM_M001_M item in POCollection)
                {
                    if (item.Click == true)
                    {
                        item.comp_code = MasterEntity.comp_code;
                        item.add_by = AppSessionState.UserID;
                        item.editby = MasterEntity.editby;
                        //item.active = MasterEntity.active;
                        item.user_source1 = AppSessionState.UserSource1;
                        item.user_source2 = AppSessionState.UserSource2;

                        RequestList.Add(item);

                        MasterEntity.po_code = item.po_code;   //For Validation Purpose
                        MasterEntity.pur_org = item.pur_org;   //For Validation Purpose

                    }
                }
                if (Validation() == true)
                {
                    string strReturn = repository.Save<List<ADM_M001_M>>(RequestList, "PurchaseOrganisationMaster", "Administration");

                    if (SelectedList != null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved and Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                }

                //SetBusinessEntitiesAfterLoad("Save", "");
                //isNewRecord = false;
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

        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MC.POList != null)
                {
                    POCollection.Clear();
                    //MC.RevenueList = (ObservableCollection<ACC_M003_X>)obj.XMLToObject(MC.RevenueList, MC.RevenueList);

                }
                else
                {
                    MC.POList = new ObservableCollection<ADM_M001_M>();
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
            //if (!string.IsNullOrEmpty(MasterEntity.ItemCode))
            //{            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
            //    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.ItemCode.Replace("/", "--"), DocumentList = MCTemp.Attachment });
            //}
        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M001_M> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M001_M> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M001_M> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M001_M> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M001_M> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M001_M> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M001_M();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M001_M> result)
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
        protected override void OnDiscardAction(InquiryActionResult<ADM_M001_M> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M001_M> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M001_M> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M001_M> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M001_M> result)
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
            if (_POCollection1 != null)
            {
                _POCollection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ADM_M001_M;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.po_code != null && data.po_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.pur_org != null && data.pur_org.ToString().ToLower().Contains(_filterString.ToLower())
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
