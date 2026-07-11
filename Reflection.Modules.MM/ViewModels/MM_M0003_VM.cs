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

namespace Reflection.Modules.MM.ViewModels
{
    public class MM_M0003_VM : WorkspaceViewModel<ADM_M015>
    {
        bool blNew = true;
        WebServiceRepository<List<ADM_M015>> repository_list = new WebServiceRepository<List<ADM_M015>>();
        WebServiceRepository<ADM_M015> repository = new WebServiceRepository<ADM_M015>();
        WebServiceRepository<MultipleContext_ADM_M015> repository_M = new WebServiceRepository<MultipleContext_ADM_M015>();
        private ICollectionView _dataGridCollection;
        private string _filterString;
        private string _filterStringSubCat;
        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = SelectedADM_M015.HasErrors;
        }


        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private ICollectionView _SelectedSubCatList;
        public ICollectionView SelectedSubCatList
        {
            get { return _SelectedSubCatList; }
            set { _SelectedSubCatList = value; RaisePropertyChanged("SelectedSubCatList"); }
        }

        public RelayCommand<IList> SelectionChangedCommandSubcat
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }

        private List<ADM_M015> _SelectedList;
        public List<ADM_M015> SelectedList
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

        private ADM_M015 _SelectedADM_M015;
        public ADM_M015 SelectedADM_M015
        {
            get
            {
                this.ErrorExist = _SelectedADM_M015.HasErrors;
                return _SelectedADM_M015;
            }
            set
            {
                if (_SelectedADM_M015 != value)
                {
                    _SelectedADM_M015 = value;
                    this.ErrorExist = _SelectedADM_M015.HasErrors;
                    RaisePropertyChanged("SelectedADM_M015");
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
        public MM_M0003_VM(string ts_code)
            : base()
        {
            ADM_M015.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);

            SelectedList = new List<ADM_M015>();
            SelectedADM_M015 = new ADM_M015();
            SelectedADM_M015.ValidateAsync().Wait();
            SelectionChangedCommand = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {

                    return;
                }
                GetSelectedList(items);
            });
            SelectionChangedCommandSubcat = new RelayCommand<IList>(
             items =>
             {
                 if (items == null)
                 {
                     return;
                 }
                 AddSubcategory(items);
             });
            LoadInitialData();
            DefaultValues();
        }
        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<ADM_M015> tSelectedItemsList = list.Cast<ADM_M015>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedADM_M015 = (ADM_M015)tSelectedItemsList[0];
                blNew = false;

                SelectedTabControlIndex = 0;
            }
        }
        private void UpdateEntity()
        {

        }
        private void DefaultValues()
        {
            SelectedADM_M015.client = AppSessionState.client;
            SelectedADM_M015.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            SelectedADM_M015.add_by = AppSessionState.UserID;
            SelectedADM_M015.editby = AppSessionState.UserID;
        }
        void LoadInitialData()
        {
            try
            {
                MultipleContext_ADM_M015 MC = new MultipleContext_ADM_M015();
                MC = repository_M.GetDataWithReturnDomainObject<MultipleContext_ADM_M015>(MC, "ADM_M015_Data", "ItemTypeMaster", "Administration", "", 0, "");
                SelectedList = MC.ItemTypeList.ToList();
                SelectedSubCatList = CollectionViewSource.GetDefaultView(MC.SubCategoryList);
                SelectedSubCatList.Filter = new Predicate<object>(FilterSubCategory);

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
        private void Update(string action)
        {

        }
        private void AddSubcategory(IList CatList)
        {
            IList list = CatList as IList;
            List<ADM_M019_P> SelectedSubCatDetailsTemp = list.Cast<ADM_M019_P>().ToList();
            if (SelectedSubCatDetailsTemp.Count > 0)
            {
                SelectedADM_M015.SubCatCode = SelectedSubCatDetailsTemp[0].SubCatCode;
                SelectedADM_M015.SubCatName = SelectedSubCatDetailsTemp[0].SubCatName;
            }
        }

        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<ADM_M015> result)
        {
            try
            {
                this.SelectedADM_M015.EndEdit();
                SelectedADM_M015.client = AppSessionState.client;
                SelectedADM_M015.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                SelectedADM_M015.add_by = AppSessionState.UserID.ToString();
                if (blNew == true)
                {
                    SelectedADM_M015 = repository.SaveWithReturnDomainObject<ADM_M015>(SelectedADM_M015, "ItemTypeMaster", "Administration");
                    SelectedList.Add(SelectedADM_M015);
                    blNew = false;
                }
                else if (blNew == false)
                {
                    SelectedADM_M015.editby = AppSessionState.UserID.ToString();

                    string str = repository.Update<ADM_M015>(SelectedADM_M015, "ItemTypeMaster", "Administration");
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
        protected override void OnCreateAction(InquiryActionResult<ADM_M015> result)
        {
            blNew = true;
            SelectedADM_M015 = new ADM_M015();
            _dataGridCollection.Refresh();
            SelectedADM_M015.ValidateAsync().Wait();
            DefaultValues();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M015> result)
        {
            if (SelectedADM_M015.ItemTypeCd != null)
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
                    this.SelectedADM_M015.EndEdit();
                    string response = repository.Delete(SelectedADM_M015.ItemTypeCd, "ItemTypeMaster", "Administration");
                    SelectedList.Remove(SelectedADM_M015);
                    _dataGridCollection.Refresh();
                    SelectedADM_M015 = new ADM_M015();
                    blNew = true;
                }
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M015> result)
        {
            SelectedADM_M015.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M015> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M015> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M015 = SelectedADM_M015;
        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M015> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M015 = SelectedADM_M015;
        }

        protected override void OnPrintAction(InquiryActionResult<ADM_M015> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M015 = SelectedADM_M015;
        }

        #endregion

        #region FilterMethods

        public bool FilterSubCategory(object obj)
        {
            var data = obj as ADM_M019_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringSubCat))
                {
                    return (data.SubCatCode != null && data.SubCatCode.ToString().ToLower().Contains(_filterStringSubCat.ToLower()) ||
                        data.SubCatName != null && data.SubCatName.ToString().ToLower().Contains(_filterStringSubCat.ToLower()));
                }
                return true;
            }
            return false;
        }
        public string FilterStringSubCat
        {
            get { return _filterStringSubCat; }
            set
            {
                _filterStringSubCat = value;
                RaisePropertyChanged("FilterStringSubCat");
                FilterCollectionSubCat();
            }
        }
        private void FilterCollectionSubCat()
        {
            if (_SelectedSubCatList != null)
            {
                _SelectedSubCatList.Refresh();
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
            var data = obj as ADM_M015;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.ItemTypeCd != null && data.ItemTypeCd.ToString().ToLower().Contains(_filterString.ToLower())) ||
                         (data.ItemTypeNm != null && data.ItemTypeNm.ToString().ToLower().Contains(_filterString.ToLower())) ||
                         (data.SubCatName != null && data.SubCatName.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }

        protected override void OnDocumentAction()
        {
        }

        protected override void OnRefreshCommand(InquiryActionResult<ADM_M015> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M015> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M015> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M015> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M015> result)
        {
            throw new NotImplementedException();
        }


        #endregion

    }
}
