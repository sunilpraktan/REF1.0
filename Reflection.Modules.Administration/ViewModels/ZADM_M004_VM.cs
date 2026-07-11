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
    public class ZADM_M004_VM : WorkspaceViewModel<ZADM_M004>
    {
        bool blNew = true;
        WebServiceRepository<List<ZADM_M004>> repository_list = new WebServiceRepository<List<ZADM_M004>>();
        WebServiceRepository<ZADM_M004> repository = new WebServiceRepository<ZADM_M004>();
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

        private List<ZADM_M004> _SelectedList;
        public List<ZADM_M004> SelectedList
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

        private ZADM_M004 _SelectedZADM_M004;
        public ZADM_M004 SelectedZADM_M004
        {
            get
            {
                this.ErrorExist = _SelectedZADM_M004.HasErrors;
                return _SelectedZADM_M004;
            }
            set
            {
                if (_SelectedZADM_M004 != value)
                {
                    _SelectedZADM_M004 = value;
                    RaisePropertyChanged("SelectedZADM_M004");
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

        public ZADM_M004_VM()
            : base()
        {
            SelectedList = new List<ZADM_M004>();
            SelectedZADM_M004 = new ZADM_M004();
            SelectedZADM_M004.ValidateAsync().Wait();
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
            List<ZADM_M004> tSelectedItemsList = list.Cast<ZADM_M004>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedZADM_M004 = (ZADM_M004)tSelectedItemsList[0];
                blNew = false;

                SelectedTabControlIndex = 0;
            }
        }
        private void LoadInitialData()
        {
            try
            {
                SelectedList = repository_list.GetDataWithReturnDomainObject<List<ZADM_M004>>(SelectedList, "ZADM_M004_Data", "WireTypeMaster", "Administration", "", 0, "");
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

        protected override void OnSaveAction(InquiryActionResult<ZADM_M004> result)
        {
            try
            {
                this.SelectedZADM_M004.EndEdit();
                if (blNew == true)
                {
                    SelectedZADM_M004.add_by = AppSessionState.UserID;
                    SelectedZADM_M004 = repository.SaveWithReturnDomainObject<ZADM_M004>(SelectedZADM_M004, "WireTypeMaster", "Administration");
                    SelectedList.Add(SelectedZADM_M004);
                    _dataGridCollection.Refresh();
                    blNew = false;
                }
                else if (blNew == false)
                {
                    string response = repository.Update<ZADM_M004>(SelectedZADM_M004, "WireTypeMaster", "Administration");
                }

                if (SelectedZADM_M004.wire_type_id.ToString() != null || SelectedZADM_M004.wire_type_id.ToString() == "")
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
        protected override void OnCreateAction(InquiryActionResult<ZADM_M004> result)
        {
            blNew = true;
            SelectedZADM_M004 = new ZADM_M004();
            _dataGridCollection.Refresh();
            SelectedZADM_M004.ValidateAsync().Wait();
        }
        protected override void OnRemoveAction(InquiryActionResult<ZADM_M004> result)
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
                SelectedZADM_M004.CancelEdit();
                string response = repository.Delete(SelectedZADM_M004.wire_type_id, "WireTypeMaster", "Administration");
                SelectedList.Remove(SelectedZADM_M004);
                _dataGridCollection.Refresh();
                SelectedZADM_M004 = new ZADM_M004();
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ZADM_M004> result)
        {
            SelectedZADM_M004.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ZADM_M004> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ZADM_M004> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M004 = SelectedZADM_M004;
        }
        protected override void OnHelpAction(InquiryActionResult<ZADM_M004> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M004 = SelectedZADM_M004;
        }
        protected override void OnPrintAction(InquiryActionResult<ZADM_M004> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M004 = SelectedZADM_M004;
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ZADM_M004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ZADM_M004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ZADM_M004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ZADM_M004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ZADM_M004> result)
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
            var data = obj as ZADM_M004;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.wire_type != null && data.wire_type.ToString().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }

        


        #endregion
    }
}
