using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using Reflection.BusinessEntity.Finance;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.WebServices.Gateway;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0017_VM : WorkspaceViewModel<ACC_M003_X>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ACC_M003_X>> repository = new WebServiceRepository<List<ACC_M003_X>>();
        WebServiceRepository<MultipleContext_ACC_M003_X> repository_MC = new WebServiceRepository<MultipleContext_ACC_M003_X>();
        WebServiceRepository<MultipleContext_ACC_M003_X> repository_MCTemp = new WebServiceRepository<MultipleContext_ACC_M003_X>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region Declarations        

        private MultipleContext_ACC_M003_X _MC;
        public MultipleContext_ACC_M003_X MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_ACC_M003_X _MCTemp;
        public MultipleContext_ACC_M003_X MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_ACC_M003_X _MCTemp1;
        public MultipleContext_ACC_M003_X MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private ACC_M003_X _MasterEntity;
        public ACC_M003_X MasterEntity
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

        private ObservableCollection<ACC_M003_X> _TransactionKeyCollection;
        public ObservableCollection<ACC_M003_X> TransactionKeyCollection
        {
            get { return _TransactionKeyCollection; }
            set
            {
                if (_TransactionKeyCollection != value)
                {
                    _TransactionKeyCollection = value;
                    RaisePropertyChanged("TransactionKeyCollection");
                }
            }
        }

        private List<ACC_M003_X> _SelectedList;
        public List<ACC_M003_X> SelectedList
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

        #endregion

        #region Event Handler

        #endregion

        #region Constructor
        public FICO_M0017_VM(string ts_code) : base()
        {
            MasterEntity = new ACC_M003_X();
            TransactionKeyCollection = new ObservableCollection<ACC_M003_X>();

            MC = new MultipleContext_ACC_M003_X();
            MCTemp = new MultipleContext_ACC_M003_X();
            MCTemp1 = new MultipleContext_ACC_M003_X();

            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData";// + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_M003_X>(MC, Request, "AccountModifierForMT", "Finance", "LoadInitialData", 0, "");

                DefaultValues();

                TransactionKeyCollection = MC.TransactionKeyEntity;
                //SelectedList = (MC.TransactionKeyEntity).ToList();
                SelectedList = TransactionKeyCollection.ToList();

                //TransactionKeyCollection.Filter = new Predicate<object>(Filter);

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
            //    MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            //    MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            //    MasterEntity.add_by = AppSessionState.UserID;
            //    MasterEntity.editby = AppSessionState.UserID;
            //    MasterEntity.entry_dt = DateTime.Now;
            //    MasterEntity.active = true;
            //    MasterEntity.doc_cat = "FR";
            //    MasterEntity.doc_type = "FR";
            //    MasterEntity.user_source1 = AppSessionState.UserSource1;
            //    MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private bool Validation()
        {
            //    if (MasterEntity.tb_code == null || MasterEntity.tb_code == "")
            //    {
            //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //        showMessageService.ButtonSetup = DialogButton.Ok;
            //        showMessageService.Caption = "Message";
            //        showMessageService.Text = String.Format("Please Enter the Test Bed No...");
            //        showMessageService.ShowMessage();
            //        return false;
            //    }
            //    else if (MasterEntity.project == null || MasterEntity.project == "")
            //    {
            //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //        showMessageService.ButtonSetup = DialogButton.Ok;
            //        showMessageService.Caption = "Message";
            //        showMessageService.Text = String.Format("Please Enter the Project...");
            //        showMessageService.ShowMessage();
            //        return false;
            //    }
            return true;
        }
        #endregion

        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<ACC_M003_X> result)
        {
            try
            {
                List<ACC_M003_X> RequestList = new List<ACC_M003_X>();
                foreach (ACC_M003_X item in TransactionKeyCollection)
                {
                    if (item.Click == true)
                    {
                        RequestList.Add(item);

                    }
                }
                string strReturn = repository.Save<List<ACC_M003_X>>(RequestList, "AccountModifierForMT", "Finance");

                if (SelectedList != null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Record Saved and Updated Successfully", this.Title);
                    showMessageService.ShowMessage();
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
                if (MC.TransactionKeyEntity != null)
                {
                    TransactionKeyCollection.Clear();
                    //MC.TransactionKeyEntity = (ObservableCollection<ACC_M003_X>)obj.XMLToObject(MC.TransactionKeyEntity, MC.TransactionKeyEntity);
                    var tempTranKeyEntity = MC.TransactionKeyEntity;
                    TransactionKeyCollection = tempTranKeyEntity;
                }
                else
                {
                    MC.TransactionKeyEntity = new ObservableCollection<ACC_M003_X>();
                }
                //if (MasterEntity.XmlDataDocument_ESEL_T001_Flip != null && isNewRecord == true && ParameterOption1 == "Save")
                //{
                //    MC.BackFlipEntity = (List<ESEL_T001_A_BackFlip>)obj.XMLToObject(MasterEntity.XmlDataDocument_ESEL_T001_Flip, MC.BackFlipEntity);
                //    FlipGridData.Add(MC.BackFlipEntity[0]);
                //    DataGridCollection.Refresh();
                //}
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
        protected override void OnRefreshCommand(InquiryActionResult<ACC_M003_X> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M003_X> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M003_X> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M003_X> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M003_X> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ACC_M003_X> result)
        {
            isNewRecord = true;
            MasterEntity = new ACC_M003_X();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ACC_M003_X> result)
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
        protected override void OnDiscardAction(InquiryActionResult<ACC_M003_X> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_M003_X> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ACC_M003_X> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ACC_M003_X> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ACC_M003_X> result)
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
            if (_TransactionKeyCollection != null)
            {
                //_TransactionKeyCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ACC_M003_X;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.mov_tp != null && data.mov_tp.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.val_update != null && data.val_update.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.qty_update != null && data.qty_update.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.key_value != null && data.key_value.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.mov_ind != null && data.mov_ind.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.cons_post != null && data.cons_post.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.sp_stock != null && data.sp_stock.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.acc_var != null && data.acc_var.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.client != null && data.client.ToString().ToLower().Contains(_filterString.ToLower())
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
