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

namespace Reflection.Modules.ADM.ViewModels
{
    public class ADM_M0001_VM : WorkspaceViewModel<ADM_M001>
    {
        bool blNew = true;
        WebServiceRepository<ADM_M001> repository = new WebServiceRepository<ADM_M001>();
        WebServiceRepository<MultipleContext> repositoryM = new WebServiceRepository<MultipleContext>();
        private ICollectionView _dataGridCollection;
        private string _filterString;
        private string _filterStringcountry;
        private string _filterStringstate;

        void Model_ItemUpdated(object sender, EventArgs e)
        {

            this.ErrorExist = SelectedADM_M001.HasErrors;

        }


        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private ICollectionView _countryCollection;
        public ICollectionView countryCollection
        {
            get { return _countryCollection; }
            set { _countryCollection = value; RaisePropertyChanged("countryCollection"); }
        }
        private ICollectionView _stateCollection;
        public ICollectionView stateCollection
        {
            get { return _stateCollection; }
            set { _stateCollection = value; RaisePropertyChanged("stateCollection"); }
        }
        public RelayCommand<object> SelectionChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandcountry
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandstate
        {
            get;
            private set;
        }


        private List<ADM_M001> _SelectedList;
        public List<ADM_M001> SelectedList
        {
            get { return _SelectedList; }
            set
            {
                if (_SelectedList != value)
                {
                    _SelectedList = value;

                    this.NotifyPropertyChanged("SelectedList");
                    //RaisePropertychanged("SelectedList");

                }
            }
        }

        private List<ADM_M012_P> _SelectedCountryList;
        public List<ADM_M012_P> SelectedCountryList
        {
            get { return _SelectedCountryList; }
            set
            {
                if (_SelectedCountryList != value)
                {
                    _SelectedCountryList = value;

                    this.NotifyPropertyChanged("SelectedCountryList");
                    //RaisePropertychanged("SelectedCountryList");

                }
            }
        }

        private ObservableCollection<ADM_M013_P> _SelectedStateList;
        public ObservableCollection<ADM_M013_P> SelectedStateList
        {
            get { return _SelectedStateList; }
            set
            {
                if (_SelectedStateList != value)
                {
                    _SelectedStateList = value;

                    this.NotifyPropertyChanged("SelectedStateList");
                    //RaisePropertychanged("SelectedStateList");

                }
            }
        }

        private ObservableCollection<ADM_M013_P> _SelectedStateListOrg1;
        public ObservableCollection<ADM_M013_P> SelectedStateListOrg1
        {
            get { return _SelectedStateListOrg1; }
            set
            {
                if (_SelectedStateListOrg1 != value)
                {
                    _SelectedStateListOrg1 = value;
                    this.NotifyPropertyChanged("SelectedStateListOrg1");
                    //RaisePropertychanged("SelectedStateListOrg1");
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
        private ADM_M001 _SelectedADM_M001;
        public ADM_M001 SelectedADM_M001
        {
            get
            {
                this.ErrorExist = _SelectedADM_M001.HasErrors;
                return _SelectedADM_M001;
            }
            set
            {
                if (_SelectedADM_M001 != value)
                {
                    _SelectedADM_M001 = value;
                    this.ErrorExist = _SelectedADM_M001.HasErrors;
                    //this.NotifyPropertyChanged("SelectedADM_M001");
                    RaisePropertyChanged("SelectedADM_M001");
                    if (_SelectedADM_M001 != null)
                    { value.BeginEdit(); }
                }
            }
        }
        MultipleContext _MC = new MultipleContext();
        public MultipleContext MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value;
                    RaisePropertyChanged("isNewRecord");
                }
            }
        }
        public ADM_M0001_VM(string ts_code)
            : base()
        {
            SelectedList = new List<ADM_M001>();
            SelectedStateList = new ObservableCollection<ADM_M013_P>();
            SelectedCountryList = new List<ADM_M012_P>();
            SelectedADM_M001 = new ADM_M001();
            SelectedADM_M001.ValidateAsync().Wait();
            ADM_M001.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            SelectionChangedCommand = new RelayCommand<object>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedList(items);
            });
            SelectionChangedCommandcountry = new RelayCommand<object>(
           items =>
           {
               if (items == null)
               {
                   return;
               }
               GetSelectedListcountry(items);
           });
            SelectionChangedCommandstate = new RelayCommand<object>(
           items =>
           {
               if (items == null)
               {
                   return;
               }
               GetSelectedListstate(items);
           });
            LoadInitialData();
            SelectedStateListOrg1 = SelectedStateList;


        }

        private void LoadInitialData()
        {
            try
            {
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext>(MC, "ADM_M001_Data", "ADM_M0001_BL", "ADM", "", 0, "");
                SelectedList = MC.Companies;

                SelectedStateList = MC.States;
                countryCollection = CollectionViewSource.GetDefaultView(MC.Countrys);
                countryCollection.Filter = new Predicate<object>(Filtercountry);

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
        private void GetSelectedList(object DataList)
        {
            IList list = DataList as IList;
            List<ADM_M001> tSelectedItemsList = list.Cast<ADM_M001>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedADM_M001 = (ADM_M001)tSelectedItemsList[0];
                blNew = false;
            }
            SelectedTabControlIndex = 0;
        }
        private void GetSelectedListcountry(object country)
        {
            IList list = country as IList;
            List<ADM_M012_P> tSelectedItemsList = list.Cast<ADM_M012_P>().ToList();
            if (tSelectedItemsList.Count > 0)
            {

                SelectedADM_M001.CountryName = tSelectedItemsList[0].CntryName;
                SelectedADM_M001.country_code = tSelectedItemsList[0].country_code;

                var myItem = (from o in SelectedStateListOrg1
                              where o.country_code == tSelectedItemsList[0].country_code
                              select o).ToList();
                stateCollection = CollectionViewSource.GetDefaultView((List<ADM_M013_P>)myItem.ToList());
                stateCollection.Filter = new Predicate<object>(Filterstate);
            }
        }
        private void GetSelectedListstate(object state)
        {
            IList list = state as IList;
            List<ADM_M013_P> tSelectedItemsList = list.Cast<ADM_M013_P>().ToList();
            if (tSelectedItemsList.Count > 0)
            {

                SelectedADM_M001.StateName = tSelectedItemsList[0].StatName;
                SelectedADM_M001.state_code = tSelectedItemsList[0].state_code;

            }
        }
        private void GetSelectedState1(int request)
        {
            //var MyState = (from o in SelectedStateListOrg1
            //               where o.CntryCode == request
            //               select o).ToList();
            //SelectedStateList = (List<ADM_M013>)MyState.ToList();

        }





        #region · Command Actions ·

        protected override void OnSaveAction(InquiryActionResult<ADM_M001> result)
        {
            try
            {
                this.SelectedADM_M001.EndEdit();
                SelectedADM_M001.add_by = AppSessionState.UserID;
                SelectedADM_M001.editby = AppSessionState.UserID;

                if (blNew == true)
                {
                    SelectedADM_M001 = repository.SaveWithReturnDomainObject<ADM_M001>(SelectedADM_M001, "ADM_M0001_BL", "ADM");
                    SelectedList.Add(SelectedADM_M001);
                    _dataGridCollection.Refresh();
                    blNew = false;
                    this.StatusMessage = "Document Number COM00001 generated successfully!";
                    this.NotificationMessage = "Notification Number COM00001 generated successfully!";
                }
                else if (blNew == false)
                {
                    string response = repository.Update<ADM_M001>(SelectedADM_M001, "ADM_M0001_BL", "ADM");
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
        //protected override void OnExportAction(InquiryActionResult<ADM_M001> result)
        //{
        //    try
        //    {
        //        ExportToExcel<ADM_M001, List<ADM_M001>> export = new ExportToExcel<ADM_M001, List<ADM_M001>>();
        //        ICollectionView view = CollectionViewSource.GetDefaultView(DataGridCollection);
        //        export.dataToPrint = (List<ADM_M001>)view.SourceCollection;
        //        export.GenerateReport();
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
        protected override void OnCreateAction(InquiryActionResult<ADM_M001> result)
        {
            blNew = true;
            SelectedADM_M001 = new ADM_M001();
            SelectedADM_M001.ValidateAsync().Wait();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M001> result)
        {
            if (SelectedADM_M001.group_code != null)
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
                    string response = repository.Delete(SelectedADM_M001.group_code, "ADM_M0001_BL", "ADM");
                    SelectedList.Remove(SelectedADM_M001);
                    _dataGridCollection.Refresh();
                    SelectedADM_M001 = new ADM_M001();
                    blNew = true;
                }
            }

        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M001> result)
        {
            SelectedADM_M001.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M001> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M001> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M001 = SelectedADM_M001;
        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M001> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M001 = SelectedADM_M001;
        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M001> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M001 = SelectedADM_M001;
        }

        #endregion

        #region "Filter"
        public string FilterString
        {
            get { return _filterString; }
            set
            {
                _filterString = value;
                this.NotifyPropertyChanged("FilterString");
                //RaisePropertychanged("FilterString");
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
            var data = obj as ADM_M001;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.GrpName != null && data.GrpName.ToString().ToLower().Contains(_filterString.ToString().ToLower())) ||
                           (data.group_code != null && data.group_code.ToString().ToLower().Contains(_filterString.ToString().ToLower())) ||
                           (data.City != null && data.City.ToString().ToLower().Contains(_filterString.ToString().ToLower())) ||
                           (data.WebSite != null && data.WebSite.ToString().ToLower().Contains(_filterString.ToString().ToLower())) ||
                           (data.PhOffi != null && data.PhOffi.ToString().ToLower().Contains(_filterString.ToString().ToLower()));
                }
                return true;
            }
            return false;
        }
        //country filter
        public string FilterStringcountry
        {
            get { return _filterStringcountry; }
            set
            {
                _filterStringcountry = value;
                this.NotifyPropertyChanged("FilterStringcountry");
                //RaisePropertychanged("FilterStringcountry");
                FilterCollectioncountry();
            }
        }
        private void FilterCollectioncountry()
        {
            if (_countryCollection != null)
            {
                _countryCollection.Refresh();
            }
        }
        public bool Filtercountry(object obj)
        {
            var data = obj as ADM_M012_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringcountry))
                {
                    return (data.CntryName != null && data.CntryName.ToString().ToLower().Contains(_filterStringcountry.ToString().ToLower()) ||
                           (data.country_code != null && data.country_code.ToString().ToLower().Contains(_filterStringcountry.ToString().ToLower())));
                }
                return true;
            }
            return false;
        }
        //state filter
        public string FilterStringstate
        {
            get { return _filterStringstate; }
            set
            {
                _filterStringstate = value;
                this.NotifyPropertyChanged("FilterStringstate");
                //RaisePropertychanged("FilterStringstate");
                FilterCollectionstate();
            }
        }
        private void FilterCollectionstate()
        {
            if (_stateCollection != null)
            {
                _stateCollection.Refresh();
            }
        }
        public bool Filterstate(object obj)
        {
            var data = obj as ADM_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringstate))
                {
                    return (data.StatName != null && data.StatName.ToString().ToLower().Contains(_filterStringstate.ToString().ToLower()) ||
                           (data.state_code != null && data.state_code.ToString().ToLower().Contains(_filterStringstate.ToString().ToLower())));
                }
                return true;
            }
            return false;
        }

        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }

        protected override void OnRefreshCommand(InquiryActionResult<ADM_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M001> result)
        {
            throw new NotImplementedException();
        }
        #endregion

    }
}
