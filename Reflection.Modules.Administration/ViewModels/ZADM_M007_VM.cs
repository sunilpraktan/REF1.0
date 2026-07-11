using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using System.Collections;
using Reflection.BusinessEntity;

namespace Reflection.Modules.Administration.ViewModels
{
    public class ZADM_M007_VM : WorkspaceViewModel<ZADM_M007>
    {
        bool blNew = true;
        WebServiceRepository<List<ZADM_M007>> repository_list = new WebServiceRepository<List<ZADM_M007>>();
        WebServiceRepository<ZADM_M007> repository = new WebServiceRepository<ZADM_M007>();
        private ICollectionView _dataGridCollection;
        private string _filterString;

        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }

        private List<ZADM_M007> _SelectedList;
        public List<ZADM_M007> SelectedList
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

        private ZADM_M007 _SelectedZADM_M007;
        public ZADM_M007 SelectedZADM_M007
        {
            get
            {
                this.ErrorExist = _SelectedZADM_M007.HasErrors;
                return _SelectedZADM_M007;
            }
            set
            {
                if (_SelectedZADM_M007 != value)
                {
                    _SelectedZADM_M007 = value;
                    RaisePropertyChanged("SelectedZADM_M007");
                    value.BeginEdit();
                }
            }
        }

        private int _selectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _selectedTabControlIndex; }
            set
            {
                if (_selectedTabControlIndex != value)
                {
                    _selectedTabControlIndex = value;
                    RaisePropertyChanged("SelectedTabControlIndex");
                }
            }
        }


        public ZADM_M007_VM(string ts_code) : base()
        {
            SelectedList = new List<ZADM_M007>();
            SelectedZADM_M007 = new ZADM_M007();
            SelectedZADM_M007.ValidateAsync().Wait();
            SelectionChangedCommand = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedList(items);
            });
            LoadInitialData();
        }

        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<ZADM_M007> tSelectedItemsList = list.Cast<ZADM_M007>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedZADM_M007 = (ZADM_M007)tSelectedItemsList[0];
                blNew = false;

                SelectedTabControlIndex = 0;
            }
        }

        private void LoadInitialData()
        {
            try
            {
                SelectedList = repository_list.GetDataWithReturnDomainObject<List<ZADM_M007>>(SelectedList, "ZADM_M007_Data", "ILDMaster", "Administration", "", 0, "");
                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);
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

        #region · Command Actions ·

        protected override void OnSaveAction(InquiryActionResult<ZADM_M007> result)
        {
            try
            {
                this.SelectedZADM_M007.EndEdit();
                if (blNew == true)
                {
                    SelectedZADM_M007.add_by = AppSessionState.UserID;
                    SelectedZADM_M007 = repository.SaveWithReturnDomainObject<ZADM_M007>(SelectedZADM_M007, "ILDMaster", "Administration");
                    SelectedList.Add(SelectedZADM_M007);
                    _dataGridCollection.Refresh();
                    blNew = false;
                }
                else if (blNew == false)
                {
                    string response = repository.Update<ZADM_M007>(SelectedZADM_M007, "ILDMaster", "Administration");
                }
                if (SelectedZADM_M007.ild_id.ToString() != null || SelectedZADM_M007.ild_id.ToString() == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Data Saved Successfully");
                    showMessageService.ShowMessage();
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Data Can Not Saved Please Try Again");
                    showMessageService.ShowMessage();
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
        protected override void OnCreateAction(InquiryActionResult<ZADM_M007> result)
        {
            blNew = true;
            SelectedZADM_M007 = new ZADM_M007();
            _dataGridCollection.Refresh();
            SelectedZADM_M007.ValidateAsync().Wait();
        }
        protected override void OnRemoveAction(InquiryActionResult<ZADM_M007> result)
        {

            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            showMessageService.ButtonSetup = DialogButton.Ok;
            showMessageService.Caption = "Delete Changes";
            showMessageService.Text =
                String.Format(
                    "This record will delete forever '{0}'",
                        this.Title);

            if (showMessageService.ShowMessage() == DialogResult.Ok)
            {
                SelectedZADM_M007.CancelEdit();
                string response = repository.Delete(SelectedZADM_M007.ild_id, "ILDMaster", "Administration");
                SelectedList.Remove(SelectedZADM_M007);
                _dataGridCollection.Refresh();
                SelectedZADM_M007 = new ZADM_M007();
            }
            blNew = true;
        }
        protected override void OnDiscardAction(InquiryActionResult<ZADM_M007> result)
        {
            SelectedZADM_M007.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ZADM_M007> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ZADM_M007> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M007 = SelectedZADM_M007;
        }
        protected override void OnHelpAction(InquiryActionResult<ZADM_M007> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M007 = SelectedZADM_M007;
        }
        protected override void OnPrintAction(InquiryActionResult<ZADM_M007> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M007 = SelectedZADM_M007;
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ZADM_M007> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ZADM_M007> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ZADM_M007> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ZADM_M007> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ZADM_M007> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region FilterMethods

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
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }

        public bool Filter(object obj)
        {
            var data = obj as ZADM_M007;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.ild_id != null && data.ild_id.ToString().Contains(_filterString.ToLower())) ||
                        (data.tip_type != null && data.tip_type.ToString().Contains(_filterString.ToLower())) ||
                         (data.ild != null && data.ild.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }

        


        #endregion
    }
}
