using Reflection.BusinessEntity.Finance;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.Presentation.Services;
using System.Windows.Data;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Collections.ObjectModel;

namespace Reflection.Modules.FICO.ViewModels
{
    public class FICO_M0012_VM : WorkspaceViewModel<ACC_M003_K>
    {
        bool isNewRecord = true;
        WebServiceRepository<List<ACC_M003_K>> repository = new WebServiceRepository<List<ACC_M003_K>>();
        WebServiceRepository<MultipleContext_ACC_M003_K> repository_MC = new WebServiceRepository<MultipleContext_ACC_M003_K>();

        #region Declarations       

        private MultipleContext_ACC_M003_K _MC;
        public MultipleContext_ACC_M003_K MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }




        private ACC_M003_K _MasterEntity;
        public ACC_M003_K MasterEntity
        {
            get
            { return _MasterEntity; }
            set
            {
                _MasterEntity = value;
                RaisePropertyChanged("MasterEntity");
            }
        }

        private int _dgSelectedIndexCategory;
        public int dgSelectedIndexCategory
        {
            get
            { return _dgSelectedIndexCategory; }
            set
            {
                if (_dgSelectedIndexCategory != value)
                {
                    _dgSelectedIndexCategory = value;
                    RaisePropertyChanged("_dgSelectedIndexCategory");
                }
            }
        }

        #endregion
        #region ICollectionView

        private ObservableCollection<ACC_M003_K> _DCCollection;
        public ObservableCollection<ACC_M003_K> DCCollection
        {
            get { return _DCCollection; }
            set
            {
                if (_DCCollection != value)
                {
                    _DCCollection = value;
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

        private List<ACC_M003_K> _SelectedList;
        public List<ACC_M003_K> SelectedList
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
        #region Constructor
        public FICO_M0012_VM(string ts_code) : base()
        {
            MasterEntity = new ACC_M003_K();
            DCCollection = new ObservableCollection<ACC_M003_K>();

            MC = new MultipleContext_ACC_M003_K();



            LoadInitialData();
        }
        #endregion
        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.OBJ_COMPANY.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_M003_K>(MC, Request, "AccountCategoryMaster", "Finance", "LoadInitialData", 0, "");

                DefaultValues();

                DCCollection = MC.CATList;
                //SelectedList = (MC.POList).ToList();
                SelectedList = DCCollection.ToList();

                DCCollection1 = CollectionViewSource.GetDefaultView(MC.CATList);
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

        private bool Validation()
        {
            foreach (var o in DCCollection)
            {
                if (o.acc_cat == null || o.acc_cat == "")
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Enter Account Category");

                    showMessageService.ShowMessage();
                    return false;

                }

            }


            return true;
        }
        #endregion
        #region Abstract Command Actions
        protected override void OnSaveAction(InquiryActionResult<ACC_M003_K> result)
        {
            try
            {
                List<ACC_M003_K> RequestList = new List<ACC_M003_K>();
                foreach (ACC_M003_K item in DCCollection)
                {
                    if (item.Click == true)
                    {
                        item.client = AppSessionState.client;
                        item.add_by = AppSessionState.UserID;
                        item.add_date = System.DateTime.Now;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.edit_date = System.DateTime.Now;


                        RequestList.Add(item);




                    }
                }
                if (Validation() == true)
                {

                    string strReturn = repository.Save<List<ACC_M003_K>>(RequestList, "AccountCategoryMaster", "Finance");


                    if (SelectedList != null)
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

        //private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        //{
        //    try
        //    {
        //        if (MC.DCList != null)
        //        {
        //            DCCollection.Clear();
        //            //MC.RevenueList = (ObservableCollection<ACC_M003_X>)obj.XMLToObject(MC.RevenueList, MC.RevenueList);

        //        }
        //        else
        //        {
        //            MC.DCList = new ObservableCollection<ACC_M003_K>();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format(ex.Message, this.Title);
        //        showMessageService.ShowMessage();
        //    }
        //}
        protected override void OnDocumentAction()
        {
            //if (!string.IsNullOrEmpty(MasterEntity.ItemCode))
            //{            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
            //    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.ItemCode.Replace("/", "--"), DocumentList = MCTemp.Attachment });
            //}
        }
        protected override void OnRefreshCommand(InquiryActionResult<ACC_M003_K> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_M003_K> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_M003_K> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_M003_K> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_M003_K> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnCreateAction(InquiryActionResult<ACC_M003_K> result)
        {
            isNewRecord = true;
            MasterEntity = new ACC_M003_K();

            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ACC_M003_K> result)
        {
            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text = String.Format("This record will be Deleted forever", this.Title);
            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {

            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ACC_M003_K> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ACC_M003_K> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ACC_M003_K> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ACC_M003_K> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ACC_M003_K> result)
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
            var data = obj as ACC_M003_K;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.acc_cat != null && data.acc_cat.ToString().ToLower().Contains(_filterString.ToLower())

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
