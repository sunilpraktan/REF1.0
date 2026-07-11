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
    public class ZADM_M005_VM : WorkspaceViewModel<ZADM_M005>
    {
        bool blNew = true;
        WebServiceRepository<List<ZADM_M005>> repository_list = new WebServiceRepository<List<ZADM_M005>>();
        WebServiceRepository<ZADM_M005> repository = new WebServiceRepository<ZADM_M005>();
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

        private List<ZADM_M005> _SelectedList;
        public List<ZADM_M005> SelectedList
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

        private ZADM_M005 _SelectedZADM_M005;
        public ZADM_M005 SelectedZADM_M005
        {
            get
            {
                this.ErrorExist = _SelectedZADM_M005.HasErrors;
                return _SelectedZADM_M005;
            }
            set
            {
                if (_SelectedZADM_M005 != value)
                {
                    _SelectedZADM_M005 = value;
                    RaisePropertyChanged("SelectedZADM_M005");
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


        public ZADM_M005_VM() : base()
        {
            SelectedList = new List<ZADM_M005>();
            SelectedZADM_M005 = new ZADM_M005();
            SelectedZADM_M005.ValidateAsync().Wait();
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
            List<ZADM_M005> tSelectedItemsList = list.Cast<ZADM_M005>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedZADM_M005 = (ZADM_M005)tSelectedItemsList[0];
                blNew = false;

                SelectedTabControlIndex = 0;
            }
        }
        private void LoadInitialData()
        {
            try
            {
                SelectedList = repository_list.GetDataWithReturnDomainObject<List<ZADM_M005>>(SelectedList, "ZADM_M005_Data", "UsedIn_Master", "Administration", "", 0, "");
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

        protected override void OnSaveAction(InquiryActionResult<ZADM_M005> result)
        {
            try
            {
                this.SelectedZADM_M005.EndEdit();
                if (blNew == true)
                {
                    SelectedZADM_M005.add_by = AppSessionState.UserID;
                    SelectedZADM_M005 = repository.SaveWithReturnDomainObject<ZADM_M005>(SelectedZADM_M005, "UsedIn_Master", "Administration");
                    SelectedList.Add(SelectedZADM_M005);
                    _dataGridCollection.Refresh();
                    blNew = false;
                }
                else if (blNew == false)
                {
                    string response = repository.Update<ZADM_M005>(SelectedZADM_M005, "UsedIn_Master", "Administration");
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
        protected override void OnCreateAction(InquiryActionResult<ZADM_M005> result)
        {
            blNew = true;
            SelectedZADM_M005 = new ZADM_M005();
            _dataGridCollection.Refresh();
            SelectedZADM_M005.ValidateAsync().Wait();
        }
        protected override void OnRemoveAction(InquiryActionResult<ZADM_M005> result)
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
                SelectedZADM_M005.CancelEdit();
                string response = repository.Delete(SelectedZADM_M005.usedin_id, "UsedIn_Master", "Administration");
                SelectedList.Remove(SelectedZADM_M005);
                _dataGridCollection.Refresh();
                SelectedZADM_M005 = new ZADM_M005();
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ZADM_M005> result)
        {
            SelectedZADM_M005.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ZADM_M005> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ZADM_M005> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M005 = SelectedZADM_M005;
        }
        protected override void OnHelpAction(InquiryActionResult<ZADM_M005> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M005 = SelectedZADM_M005;
        }
        protected override void OnPrintAction(InquiryActionResult<ZADM_M005> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M005 = SelectedZADM_M005;
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ZADM_M005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ZADM_M005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ZADM_M005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ZADM_M005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ZADM_M005> result)
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
            var data = obj as ZADM_M005;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.usedin_id != null && data.usedin_id.ToString().Contains(_filterString.ToLower())) ||
                         (data.usedin != null && data.usedin.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }

        


        #endregion
    }
    
}
