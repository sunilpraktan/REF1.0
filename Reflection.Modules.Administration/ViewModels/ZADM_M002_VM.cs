
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;

namespace Reflection.Modules.Administration.ViewModels
{
    public class ZADM_M002_VM : WorkspaceViewModel<ZADM_M002>
    {

        bool blNew = true;
        WebServiceRepository<List<ZADM_M002>> repository_list = new WebServiceRepository<List<ZADM_M002>>();
        WebServiceRepository<ZADM_M002> repository = new WebServiceRepository<ZADM_M002>();
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

        private List<ZADM_M002> _SelectedList;
        public List<ZADM_M002> SelectedList
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

        private ZADM_M002 _SelectedZADM_M002;
        public ZADM_M002 SelectedZADM_M002
        {
            get { return _SelectedZADM_M002; }
            set
            {
                if (_SelectedZADM_M002 != value)
                {
                    _SelectedZADM_M002 = value;
                    RaisePropertyChanged("SelectedZADM_M002");
                    //value.BeginEdit();                    
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

        public ZADM_M002_VM(string ts_code)
            : base()
        {
            SelectedList = new List<ZADM_M002>();
            SelectedZADM_M002 = new ZADM_M002();
            SelectionChangedCommand = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    //SelectedList = null;
                    return;
                }
                GetSelectedList(items);
            });
            LoadInitialData();
        }
        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<ZADM_M002> tSelectedItemsList = list.Cast<ZADM_M002>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedZADM_M002 = (ZADM_M002)tSelectedItemsList[0];
                
                blNew = false;

                SelectedTabControlIndex = 0;
            }
            //SelectedZADM_M002 = new ZADM_M002();
        }
        private void LoadInitialData()
        {
            try
            {
                SelectedList = repository_list.GetDataWithReturnDomainObject<List<ZADM_M002>>(SelectedList, "ZADM_M002_Data", "BallTypeMaster", "Administration", "", 0, "");
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
        protected override void OnSaveAction(InquiryActionResult<ZADM_M002> result)
        {
            try
            {
                this.SelectedZADM_M002.EndEdit();
                if (blNew == true)
                {
                    SelectedZADM_M002.add_by = AppSessionState.UserID;
                    SelectedZADM_M002 = repository.SaveWithReturnDomainObject<ZADM_M002>(SelectedZADM_M002, "BallTypeMaster", "Administration");
                    SelectedList.Add(SelectedZADM_M002);
                    _dataGridCollection.Refresh();
                    blNew = false;
                }
                else if (blNew == false)
                {
                    string response = repository.Update<ZADM_M002>(SelectedZADM_M002, "BallTypeMaster", "Administration");
                }
                if (SelectedZADM_M002.ball_type_id.ToString() != null || SelectedZADM_M002.ball_type_id.ToString() == "")
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
        protected override void OnCreateAction(InquiryActionResult<ZADM_M002> result)
        {
            blNew = true;
            SelectedZADM_M002 = new ZADM_M002();
        }
        protected override void OnRemoveAction(InquiryActionResult<ZADM_M002> result)
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
                SelectedZADM_M002.CancelEdit();
                string response = repository.Delete(SelectedZADM_M002.ball_type_id, "BallTypeMaster", "Administration");
                SelectedList.Remove(SelectedZADM_M002);
                SelectedZADM_M002 = new ZADM_M002();
                _dataGridCollection.Refresh();
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ZADM_M002> result)
        {
            SelectedZADM_M002.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ZADM_M002> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ZADM_M002> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M002 = SelectedZADM_M002;
        }
        protected override void OnHelpAction(InquiryActionResult<ZADM_M002> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M002 = SelectedZADM_M002;
        }
        protected override void OnPrintAction(InquiryActionResult<ZADM_M002> result)
        {
            SelectedList = SelectedList;
            SelectedZADM_M002 = SelectedZADM_M002;
        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ZADM_M002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ZADM_M002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ZADM_M002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ZADM_M002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ZADM_M002> result)
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
            var data = obj as ZADM_M002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.ball_type_id != null && data.ball_type_id.ToString().Contains(_filterString.ToLower())) ||
                         (data.ball_type  != null && data.ball_type.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }

        


        #endregion

    }
}

