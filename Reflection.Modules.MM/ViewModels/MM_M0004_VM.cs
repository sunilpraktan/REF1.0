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
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;

namespace Reflection.Modules.MM.ViewModels
{
    public class MM_M0004_VM : WorkspaceViewModel<ADM_M016>
    {
        bool blNew = true;
        WebServiceRepository<ADM_M016> repository = new WebServiceRepository<ADM_M016>();
        WebServiceRepository<MultipleContext_ADM_M016> repository_M = new WebServiceRepository<MultipleContext_ADM_M016>();
        private ICollectionView _dataGridCollection;
        private string _filterString;
        private string _filterStringItm;
        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = SelectedADM_M016.HasErrors;
        }

        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private ICollectionView _SelectedItemTpList;
        public ICollectionView SelectedItemTpList
        {
            get { return _SelectedItemTpList; }
            set { _SelectedItemTpList = value; RaisePropertyChanged("SelectedItemTpList"); }
        }
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandItm
        {
            get;
            private set;
        }
        private List<ADM_M016> _SelectedList;
        public List<ADM_M016> SelectedList
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

        private List<ADM_M015_P> _SelectedItmTpList;
        public List<ADM_M015_P> SelectedItmTpList
        {
            get { return _SelectedItmTpList; }
            set
            {
                if (_SelectedItmTpList != value)
                {
                    _SelectedItmTpList = value;

                    //if (PropertyChanged != null)
                    //{
                    RaisePropertyChanged("SelectedItmTpList");
                    //}
                }
            }
        }

        private ObservableCollection<ADM_M015_P> _ItmTpList;
        public ObservableCollection<ADM_M015_P> ItmTpList
        {
            get { return _ItmTpList; }
            set
            {
                _ItmTpList = value;
                RaisePropertyChanged("ItmTpList");
            }
        }


        private ADM_M016 _SelectedADM_M016;
        public ADM_M016 SelectedADM_M016
        {
            get
            {
                this.ErrorExist = _SelectedADM_M016.HasErrors;
                return _SelectedADM_M016;
            }
            set
            {
                if (_SelectedADM_M016 != value)
                {
                    _SelectedADM_M016 = value;
                    this.ErrorExist = _SelectedADM_M016.HasErrors;
                    RaisePropertyChanged("SelectedADM_M016");
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

        public MM_M0004_VM(string ts_code)
            : base()
        {
            ADM_M016.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);

            SelectedList = new List<ADM_M016>();
            SelectedADM_M016 = new ADM_M016();
            SelectedItmTpList = new List<ADM_M015_P>();
            SelectedADM_M016.ValidateAsync().Wait();
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
            SelectionChangedCommandItm = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                AddLocations(items);
            });
            LoadInitialData();
            DefaultValues();
        }
        private void AddLocations(IList CatList)
        {
            IList list = CatList as IList;
            List<ADM_M015_P> SelectedCatDetailsTemp = list.Cast<ADM_M015_P>().ToList();
            if (SelectedCatDetailsTemp.Count > 0)
            {
                SelectedADM_M016.ItemTypeCd = SelectedCatDetailsTemp[0].ItemTypeCd;
                SelectedADM_M016.ItemTypeNm = SelectedCatDetailsTemp[0].ItemTypeNm;
            }
        }
        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<ADM_M016> tSelectedItemsList = list.Cast<ADM_M016>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedADM_M016 = (ADM_M016)tSelectedItemsList[0];
                blNew = false;

                SelectedTabControlIndex = 0;
            }
        }

        private void LoadInitialData()
        {
            try
            {
                MultipleContext_ADM_M016 MC = new MultipleContext_ADM_M016();
                MC = repository_M.GetDataWithReturnDomainObject<MultipleContext_ADM_M016>(MC, "ADM_M016_Data", "SubItmTpMaster", "Administration", "", 0, "");
                SelectedList = MC.SubItmTp;

                SelectedItemTpList = CollectionViewSource.GetDefaultView(MC.ItmTp);
                SelectedItemTpList.Filter = new Predicate<object>(FilterItem);
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
        private void DefaultValues()
        {
            SelectedADM_M016.client = AppSessionState.client;
            SelectedADM_M016.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            SelectedADM_M016.add_by = AppSessionState.UserID;
            SelectedADM_M016.editby = AppSessionState.UserID;
        }
        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<ADM_M016> result)
        {
            try
            {
                this.SelectedADM_M016.EndEdit();
                SelectedADM_M016.client = AppSessionState.client;
                SelectedADM_M016.comp_code = AppSessionState.OBJ_COMPANY.comp_code.ToString();
                SelectedADM_M016.add_by = AppSessionState.UserID.ToString();
                if (blNew == true)
                {
                    SelectedADM_M016 = repository.SaveWithReturnDomainObject<ADM_M016>(SelectedADM_M016, "SubItmTpMaster", "Administration");
                    SelectedList.Add(SelectedADM_M016);

                    blNew = false;
                }
                else if (blNew == false)
                {
                    SelectedADM_M016.editby = AppSessionState.UserID.ToString();
                    string response = repository.Update<ADM_M016>(SelectedADM_M016, "SubItmTpMaster", "Administration");
                }
                _dataGridCollection.Refresh();
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
        protected override void OnCreateAction(InquiryActionResult<ADM_M016> result)
        {
            blNew = true;
            SelectedADM_M016 = new ADM_M016();
            SelectedADM_M016.ValidateAsync().Wait();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M016> result)
        {
            if (SelectedADM_M016.SubItemTpCd != null)
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
                    SelectedADM_M016.CancelEdit();
                    string response = repository.Delete(SelectedADM_M016.SubItemTpCd, "SubItmTpMaster", "Administration");
                    SelectedList.Remove(SelectedADM_M016);
                    _dataGridCollection.Refresh();
                    SelectedADM_M016 = new ADM_M016();
                    blNew = true;
                }
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M016> result)
        {
            SelectedADM_M016.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M016> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M016> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M016 = SelectedADM_M016;
        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M016> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M016 = SelectedADM_M016;
        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M016> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M016 = SelectedADM_M016;
        }

        #endregion

        #region FilterMethods
        public bool FilterItem(object obj)
        {
            var data = obj as ADM_M015_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringItm))
                {
                    return (data.ItemTypeCd != null && data.ItemTypeCd.ToString().ToLower().Contains(_filterStringItm.ToLower())) ||
                           (data.ItemTypeNm != null && data.ItemTypeNm.ToString().ToLower().Contains(_filterStringItm.ToLower()));
                }
                return true;
            }
            return false;
        }
        public string FilterStringItm
        {
            get { return _filterStringItm; }
            set
            {
                _filterStringItm = value;
                RaisePropertyChanged("FilterStringItm");
                FilterCollectionCat();
            }
        }
        private void FilterCollectionCat()
        {
            if (_SelectedItemTpList != null)
            {
                _SelectedItemTpList.Refresh();
            }
        }
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
            var data = obj as ADM_M016;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.SubItemTpCd != null && data.SubItemTpCd.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.SubItemTpNm != null && data.SubItemTpNm.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.ItemTypeNm != null && data.ItemTypeNm.ToString().ToLower().Contains(_filterString.ToLower()));

                }
                return true;
            }
            return false;
        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<ADM_M016> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M016> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M016> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M016> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M016> result)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
