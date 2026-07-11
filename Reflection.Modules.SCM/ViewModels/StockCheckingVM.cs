using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;

namespace Reflection.Modules.SCM.ViewModels
{
    public class StockCheckingVM : WorkspaceViewModel<CurrentStock>
    {

        WebServiceRepository<CurrentStock> repository = new WebServiceRepository<CurrentStock>();
        WebServiceRepository<MultipleContext_CurrentStock> repositoryM = new WebServiceRepository<MultipleContext_CurrentStock>();
        MultipleContext_CurrentStock MCTemp = new MultipleContext_CurrentStock();

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        MultipleContext_CurrentStock _MC = new MultipleContext_CurrentStock();
        public MultipleContext_CurrentStock MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value;

                    RaisePropertyChanged("MC");
                }
            }
        }
        private ICollectionView _CollectionItem;
        public ICollectionView CollectionItem
        {
            get { return _CollectionItem; }
            set { _CollectionItem = value; RaisePropertyChanged("CollectionItem"); }
        }

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
       


        #region CurrentStock
        private List<CurrentStock> _SelectedList;
        public List<CurrentStock> SelectedList
        {
            get { return _SelectedList; }
            set
            {
                if (_SelectedList != value)
                {
                    _SelectedList = value;
                    RaisePropertyChanged("SelectedList");
                }
            }
        }
        private CurrentStock _SelectedCurrentStock;
        public CurrentStock SelectedCurrentStock
        {
            get
            {
                this.ErrorExist = _SelectedCurrentStock.HasErrors;
                return _SelectedCurrentStock;
            }
            set
            {
                if (_SelectedCurrentStock != value)
                {
                    _SelectedCurrentStock = value;
                    //this.ErrorExist = _SelectedCurrentStock.HasErrors;
                    RaisePropertyChanged("SelectedCurrentStock");
                    value.BeginEdit();
                }
            }
        }
        #endregion
        public RelayCommand<IList> SelectionChangedCommandItem
        {
            get;
            private set;
        }
        private RelayCommand _LoadCommand;
        public RelayCommand LoadCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }

        public StockCheckingVM(string ts_code):base()
        {
            this.ts_code_vm = ts_code;
           SelectedCurrentStock = new CurrentStock();
            MC = new MultipleContext_CurrentStock();
            
            LoadInitialData();
        }
       
        private void GetSelectedItem(IList DeptList)
        {
            IList list = DeptList as IList;
            List<ADM_M022_ESSEM_PopUp> GetSelectedRequesterDetailsTemp = list.Cast<ADM_M022_ESSEM_PopUp>().ToList();
            if (GetSelectedRequesterDetailsTemp.Count > 0)
            {
                SelectedCurrentStock.ItemCode = GetSelectedRequesterDetailsTemp[0].ItemCode;

            }

        }
        private void LoadInitialData()
        {
            try
            {
                
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_CurrentStock>(MC, "MM_T001_Data", "StockChecking", "SCM", "LoadCurrentStock",0,"");

                #region Command Initialisation
                SelectionChangedCommandItem = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }

                  GetSelectedItem(items);
              });
                LoadCommand = new RelayCommand(Load);
               
                #endregion
                CollectionItem = CollectionViewSource.GetDefaultView(MC.ItemList);
                CollectionItem.Filter = new Predicate<object>(FilterItems);
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        private void Load()
        {
            MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_CurrentStock>(MC, "MM_T001_Data", "StockChecking", "SCM", "CurrentStock", 0, SelectedCurrentStock.ItemCode);
           //// DataGridCollection = CollectionViewSource.GetDefaultView(MCTemp.CurrentStock_details);this is in use
        }
        //private void WindowEvetCall(object InputValue)
        //{
        //    try
        //    {
        //        if (doc_no_vm != null && ts_code_vm != null)
        //        {
        //            LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
        //            isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
        //            AppSessionState.ViewOtherRecordAllowed = true;
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
        //private void Invoke_Reference_Document(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ReflectionFunctionService objRef = new ReflectionFunctionService();
        //        #region Command Parameter Read Section

        //        if (InputValue.GetType() == typeof(string) && InputValue != null)
        //        {
        //            //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
        //            Request = MasterEntity.client + "!@" + MasterEntity.comp_code + "!@" + InputValue.ToString();
        //            objRef.Invoke_Documet(Request, Request);
        //        }
        //        #endregion
        //    }
        //    catch (Exception ex)
        //    { }
        //}



        #region Filters For Items
        private void FilterCollectionItem()
        {
            if (_CollectionItem != null)
            {
                _CollectionItem.Refresh();
            }
        }
        private string _filterStringItem;
        public string FilterStringItem
        {
            get { return _filterStringItem; }
            set
            {
                _filterStringItem = value;
                RaisePropertyChanged("FilterStringItem");
                FilterCollectionItem();
            }
        }
        public bool FilterItems(object obj)
        {
            var data = obj as ADM_M022_ESSEM_PopUp;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringItem))
                {
                    return (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterStringItem.ToLower())) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringItem.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion





        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<CurrentStock> result)
        {

        }
        protected override void OnCreateAction(InquiryActionResult<CurrentStock> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<CurrentStock> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<CurrentStock> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<CurrentStock> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<CurrentStock> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<CurrentStock> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<CurrentStock> result)
        {

        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<CurrentStock> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<CurrentStock> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<CurrentStock> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<CurrentStock> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<CurrentStock> result)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

