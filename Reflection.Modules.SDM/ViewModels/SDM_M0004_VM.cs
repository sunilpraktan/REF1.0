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
using System.Collections.Specialized;
using GalaSoft.MvvmLight.Command;

namespace Reflection.Modules.SDM.ViewModels
{
    public class SDM_M0004_VM : WorkspaceViewModel<ADM_M001_C>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ADM_M001_C>> repository = new WebServiceRepository<List<ADM_M001_C>>();
        WebServiceRepository<MultipleContext_ADM_M001_C> repository_MC = new WebServiceRepository<MultipleContext_ADM_M001_C>();
        WebServiceRepository<MultipleContext_ADM_M001_C> repository_MCTemp = new WebServiceRepository<MultipleContext_ADM_M001_C>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region Declarations       

        private MultipleContext_ADM_M001_C _MC;
        public MultipleContext_ADM_M001_C MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ADM_M001_C _MCTemp;
        public MultipleContext_ADM_M001_C MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }



        private ADM_M001_C _MasterEntity;
        public ADM_M001_C MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private int _dgSelectedIndexdistributionchannel;
        public int dgSelectedIndexdistributionchannel
        {
            get
            { return _dgSelectedIndexdistributionchannel; }
            set
            {
                if (_dgSelectedIndexdistributionchannel != value)
                {
                    _dgSelectedIndexdistributionchannel = value;
                    RaisePropertyChanged("_dgSelectedIndexdistributionchannel");
                }
            }
        }

        #endregion

        #region ICollectionView

        private ObservableCollection<ADM_M001_C> _DCCollection;
        public ObservableCollection<ADM_M001_C> DCCollection
        {
            get { return _DCCollection; }
            set
            {
                if (_DCCollection != value)
                {
                    _DCCollection = value;
                    DCCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("DCCollection");
                }
            }
        }

        private ICollectionView _DCCollection1;
        public ICollectionView DCCollection1
        {
            get { return _DCCollection1; }
            set { _DCCollection1 = value; RaisePropertyChanged("DCCollection1"); }
        }

        private List<ADM_M001_C> _SelectedList;
        public List<ADM_M001_C> SelectedList
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
        #endregion
        #region Relay Commands Declaration
        public RelayCommand<object> cmdSelectionChanged_ITEM { get; private set; }
        #endregion
        #region Constructor
        public SDM_M0004_VM(string ts_code) : base()
        {
            MasterEntity = new ADM_M001_C();
            DCCollection = new ObservableCollection<ADM_M001_C>();

            MC = new MultipleContext_ADM_M001_C();
            MCTemp = new MultipleContext_ADM_M001_C();

            cmdSelectionChanged_ITEM = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_ITEM(items); });
            DCCollection.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            LoadInitialData();
        }
        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ADM_M001_C>(MC, Request, "SalesDistributionChannel", "Administration", "LoadInitialData", 0, "");

                DefaultValues();

                DCCollection = MC.DCList;
                //SelectedList = (MC.POList).ToList();
                SelectedList = DCCollection.ToList();

                DCCollection1 = CollectionViewSource.GetDefaultView(MC.DCList);
                DCCollection1.Filter = new Predicate<object>(Filter);

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

            MasterEntity.active = true;
            MasterEntity.client = AppSessionState.client;
        }
        private void SelectionChanged_ITEM(object InputValue)
        {
            try
            {
                MasterEntity = (ADM_M001_C)InputValue;
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ADM_M001_C item in e.NewItems)
                    {
                        item.client = AppSessionState.client;
                        //item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
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
            if (MasterEntity.dc_code == null || MasterEntity.dc_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter the DC Code...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.dc_name == null || MasterEntity.dc_name == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter the Distribution Channel Name...");
                showMessageService.ShowMessage();
                return false;
            }

            return true;
        }
        #endregion

        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<ADM_M001_C> result)
        {
            try
            {
                List<ADM_M001_C> RequestList = new List<ADM_M001_C>();
                foreach (ADM_M001_C item in DCCollection)
                {
                    if (item.Click == true)
                    {
                        item.client = AppSessionState.client;

                        RequestList.Add(item);

                        MasterEntity.dc_code = item.dc_code;   //For Validation Purpose
                        MasterEntity.dc_name = item.dc_name;   //For Validation Purpose

                    }
                }
                if (Validation() == true)
                {
                    string strReturn = repository.Save<List<ADM_M001_C>>(RequestList, "SalesDistributionChannel", "Administration");

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
                if (MC.DCList != null)
                {
                    DCCollection.Clear();
                    //MC.RevenueList = (ObservableCollection<ACC_M003_X>)obj.XMLToObject(MC.RevenueList, MC.RevenueList);

                }
                else
                {
                    MC.DCList = new ObservableCollection<ADM_M001_C>();
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
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M001_C> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M001_C> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ADM_M001_C> result)
        {
            isNewRecord = true;
            MasterEntity = new ADM_M001_C();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M001_C> result)
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
        protected override void OnDiscardAction(InquiryActionResult<ADM_M001_C> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M001_C> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M001_C> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M001_C> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M001_C> result)
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
            if (_DCCollection1 != null)
            {
                _DCCollection1.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ADM_M001_C;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.dc_code != null && data.dc_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.dc_name != null && data.dc_name.ToString().ToLower().Contains(_filterString.ToLower())
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
