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

namespace Reflection.Modules.Administration.ViewModels
{
    public class ADM_M034_VM : WorkspaceViewModel<ADM_M034>
    {
        bool blNew = true;
        WebServiceRepository<ADM_M034> repository = new WebServiceRepository<ADM_M034>();
        WebServiceRepository<MultipleContextADM_M034> repository_m = new WebServiceRepository<MultipleContextADM_M034>();
        private ICollectionView _dataGridCollection;
        private string _filterString;
        private string _filterStringSubCat;
        private string _filterStringParam;

        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private ICollectionView _SubCatCollection;
        public ICollectionView SubCatCollection
        {
            get { return _SubCatCollection; }
            set { _SubCatCollection = value; RaisePropertyChanged("SubCatCollection"); }
        }
        private ICollectionView _ParamCollection;
        public ICollectionView ParamCollection
        {
            get { return _ParamCollection; }
            set { _ParamCollection = value; RaisePropertyChanged("ParamCollection"); }
        }
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandParam
        {
            get;
            private set;
        }
        private List<ADM_M034> _SelectedList;
        public List<ADM_M034> SelectedList
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
        public RelayCommand<IList> SelectionChangedCommandSubCat
        {
            get;
            private set;
        }
        private ADM_M034 _SelectedADM_M034;
        public ADM_M034 SelectedADM_M034
        {
            get
            {
                this.ErrorExist = _SelectedADM_M034.HasErrors;
                return _SelectedADM_M034;
            }
            set
            {
                if (_SelectedADM_M034 != value)
                {
                    _SelectedADM_M034 = value;
                    RaisePropertyChanged("SelectedADM_M034");
                    value.BeginEdit();
                }
            }
        }
        MultipleContextADM_M034 _MC = new MultipleContextADM_M034();
        public MultipleContextADM_M034 MC
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
        public ADM_M034_VM()
            : base()
        {
            SelectedList = new List<ADM_M034>();
            SelectedADM_M034 = new ADM_M034();
            SelectedADM_M034.ValidateAsync().Wait();
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
            SelectionChangedCommandSubCat = new RelayCommand<IList>(
       items =>
       {
           if (items == null)
           {
               return;
           }
           AddSubCategory(items);
       });
            SelectionChangedCommandParam = new RelayCommand<IList>(
           items =>
           {
               if (items == null)
               {
                   return;
               }
               AddParameter(items);
           });
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            try
            {
                MultipleContextADM_M034 MC = new MultipleContextADM_M034();
                string Request = "LoadInitialData" + "!@" + AppSessionState.location_Id;
                MC = repository_m.GetDataWithReturnDomainObject<MultipleContextADM_M034>(MC, Request, "CatParameterMaster", "Administration", "LoadInitialData", 0, "");
               // MC = repository_m.GetDataWithReturnDomainObject<MultipleContextADM_M034>(MC, "ADM_M034_Data", "CatParameterMaster", "Administration", "", 0, "");
                SelectedList = MC.PARAM;
                SubCatCollection = CollectionViewSource.GetDefaultView(MC.Subcat);
                SubCatCollection.Filter = new Predicate<object>(FilterSubCat);

                ParamCollection = CollectionViewSource.GetDefaultView(MC.ParamList);
                ParamCollection.Filter = new Predicate<object>(FilterParam);

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
        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<ADM_M034> tSelectedItemsList = list.Cast<ADM_M034>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedADM_M034 = (ADM_M034)tSelectedItemsList[0];
                blNew = false;
            }
        }
        private void AddSubCategory(IList CatList)
        {

            IList list = CatList as IList;
            List<ADM_M019> SelectedCatDetailsTemp = list.Cast<ADM_M019>().ToList();
            if (SelectedCatDetailsTemp.Count > 0)
            {
                SelectedADM_M034.SubCatCode = SelectedCatDetailsTemp[0].SubCatCode;
                SelectedADM_M034.SubCatName = SelectedCatDetailsTemp[0].SubCatName;
            }
        }
        private void AddParameter(IList ParamList)
        {

            IList list = ParamList as IList;
            List<ADM_M031> SelectedParamDetailsTemp = list.Cast<ADM_M031>().ToList();
            if (SelectedParamDetailsTemp.Count > 0)
            {
                SelectedADM_M034.para_code = SelectedParamDetailsTemp[0].para_code.ToString();
                SelectedADM_M034.para_name = SelectedParamDetailsTemp[0].para_name;
            }
        }

        #region · Command Actions ·

        protected override void OnDocumentAction()
        {
            this.ShowZoomWindow = !ShowZoomWindow;
        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M034> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M034> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M034> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M034> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M034> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnSaveAction(InquiryActionResult<ADM_M034> result)
        {
            try
            {
                this.SelectedADM_M034.EndEdit();
                SelectedADM_M034.add_by = AppSessionState.UserID.ToString();
                if (blNew == true)
                {
                    SelectedADM_M034 = repository.SaveWithReturnDomainObject<ADM_M034>(SelectedADM_M034, "CatParameterMaster", "Administration");
                    SelectedList.Add(SelectedADM_M034);
                    _dataGridCollection.Refresh();
                    blNew = false;
                }
                else if (blNew == false)
                {
                    string response = repository.Update<ADM_M034>(SelectedADM_M034, "CatParameterMaster", "Administration");
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
        protected override void OnCreateAction(InquiryActionResult<ADM_M034> result)
        {
            blNew = true;
            SelectedADM_M034 = new ADM_M034();
            SelectedADM_M034.ValidateAsync().Wait();
            MC.ParamList = new ObservableCollection<ADM_M031>();
            _dataGridCollection.Refresh();
            //SelectedADM_M034 = new ADM_M034();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M034> result)
        {
            try
            {
                this.SelectedADM_M034.CancelEdit();
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Save Changes";
                showMessageService.Text =
                    String.Format(
                        "This record will delete forever '{0}'",
                            this.Title);

                if (showMessageService.ShowMessage() == DialogResult.Ok)
                {
                    string response = repository.Delete(SelectedADM_M034.add_by, "CatParameterMaster", "Administration");
                    SelectedList.Remove(SelectedADM_M034);
                    _dataGridCollection.Refresh();
                    SelectedADM_M034 = new ADM_M034();
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
        protected override void OnDiscardAction(InquiryActionResult<ADM_M034> result)
        {
            this.SelectedADM_M034.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M034> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M034> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M034 = SelectedADM_M034;
        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M034> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M034 = SelectedADM_M034;
        }

        protected override void OnPrintAction(InquiryActionResult<ADM_M034> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M034 = SelectedADM_M034;
        }

        #endregion

        #region Filters For Param
        public string FilterStringParam
        {
            get { return _filterStringParam; }
            set
            {
                _filterStringParam = value;
                RaisePropertyChanged("FilterStringParam");
                FilterCollectionParam();
            }
        }
        private void FilterCollectionParam()
        {
            if (_ParamCollection != null)
            {
                _ParamCollection.Refresh();
            }
        }
        public bool FilterParam(object obj)
        {
            var data = obj as ADM_M031;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringParam))
                {
                    return (data.para_code != null && data.para_code.ToString().ToLower().Contains(_filterStringParam.ToLower())) ||
                        (data.para_name != null && data.para_name.ToString().ToLower().Contains(_filterStringParam.ToLower())) ;

                }
                return true;
            }
            return false;
        }
        #endregion

        //Subcategory filter
        public bool FilterSubCat(object obj)
        {
            var data = obj as ADM_M019;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringSubCat))
                {
                    return (data.SubCatName != null && data.SubCatName.ToString().ToLower().Contains(_filterStringSubCat.ToLower()));
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
            if (_SubCatCollection != null)
            {
                _SubCatCollection.Refresh();
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
            var data = obj as ADM_M034;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return
                        //data.id.ToString().ToLower().Contains(_filterString.ToLower()) ||
                        data.SubCatName.ToString().ToLower().Contains(_filterString.ToLower());
                        //data.CatParamName.ToString().ToLower().Contains(_filterString.ToLower());

                }
                return true;
            }
            return false;
        }

        
    }
}
