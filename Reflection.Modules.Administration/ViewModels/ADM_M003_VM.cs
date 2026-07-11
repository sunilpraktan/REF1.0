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

    public class ADM_M003_VM : WorkspaceViewModel<ADM_M003>
    {
        bool blNew = true;
        WebServiceRepository<ADM_M003> repository = new WebServiceRepository<ADM_M003>();
        WebServiceRepository<MultipleContextADM_M003> repositoryM = new WebServiceRepository<MultipleContextADM_M003>();
        private ICollectionView _dataGridCollection;
        private string _filterString;
        private string _filterStringcountry;
        private string _filterStringstate;
        private string _filterStringact;
        private string _filterStringcomp;


        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = SelectedADM_M003.HasErrors;
        }

        #region "Declaration"

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


        #endregion

        #region "ICollectionView"        
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
        private ICollectionView _actCollection;
        public ICollectionView actCollection
        {
            get { return _actCollection; }
            set { _actCollection = value; RaisePropertyChanged("actCollection"); }
        }
        private ICollectionView _compCollection;
        public ICollectionView compCollection
        {
            get { return _compCollection; }
            set { _compCollection = value; RaisePropertyChanged("compCollection"); }
        }
        private ICollectionView _BusinessPlaceCollection;
        public ICollectionView BusinessPlaceCollection
        {
            get { return _BusinessPlaceCollection; }
            set { _BusinessPlaceCollection = value; RaisePropertyChanged("BusinessPlaceCollection"); }
        }
        #endregion

        #region "RelayCommand"       
        public RelayCommand SortState { get; private set; }
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
        public RelayCommand<object> SelectionChangedCommandact
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandcomp
        {
            get;
            private set;
        }
        public RelayCommand<object> CMDBusinessPlace
        {
            get;
            private set;
        }
        #endregion



        private List<ADM_M003> _SelectedList;
        public List<ADM_M003> SelectedList
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
        private List<ADM_M012_P> _SelectedCountryList;
        public List<ADM_M012_P> SelectedCountryList
        {
            get { return _SelectedCountryList; }
            set
            {
                if (_SelectedCountryList != value)
                {
                    _SelectedCountryList = value;


                    RaisePropertyChanged("SelectedCountryList");

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


                    RaisePropertyChanged("SelectedStateList");

                }
            }
        }


        private List<ADM_M002_P> _SelectedCompanyList;
        public List<ADM_M002_P> SelectedCompanyList
        {
            get { return _SelectedCompanyList; }
            set
            {
                if (_SelectedCompanyList != value)
                {
                    _SelectedCompanyList = value;
                    RaisePropertyChanged("SelectedCompanyList");
                }
            }
        }

        private ObservableCollection<ADM_M013_P> _SelectedStateListOrg;
        public ObservableCollection<ADM_M013_P> SelectedStateListOrg
        {
            get { return _SelectedStateListOrg; }
            set
            {
                if (_SelectedStateListOrg != value)
                {
                    _SelectedStateListOrg = value;
                    RaisePropertyChanged("SelectedStateListOrg");
                }
            }
        }
        private ADM_M003 _SelectedADM_M003;
        public ADM_M003 SelectedADM_M003
        {
            get
            {
                this.ErrorExist = _SelectedADM_M003.HasErrors;
                return _SelectedADM_M003;
            }
            set
            {
                if (_SelectedADM_M003 != value)
                {
                    _SelectedADM_M003 = value;


                    RaisePropertyChanged("SelectedADM_M003");
                    if (_SelectedADM_M003 != null)
                    {
                        value.BeginEdit();
                    }

                    //}
                }
            }
        }




        MultipleContextADM_M003 _LOC = new MultipleContextADM_M003();
        public MultipleContextADM_M003 LOC
        {
            get { return _LOC; }
            set
            {
                if (_LOC != value)
                {
                    _LOC = value;

                    RaisePropertyChanged("LOC");
                }
            }
        }

        public ADM_M003_VM()
            : base()
        {
            SelectedList = new List<ADM_M003>();
            SelectedADM_M003 = new ADM_M003();
            SelectedADM_M003.ValidateAsync().Wait();
            SelectedStateList = new ObservableCollection<Reflection.BusinessEntity.ADM_M013_P>();
            ADM_M003.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);

            //SelectionChangedCommand = new RelayCommand<object>(
            //items =>
            //{
            //    if (items == null)
            //    {
            //        //SelectedList = null;
            //        return;
            //    }
               //GetSelectedList(items);
            //});
            SelectionChangedCommand = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
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
            SelectionChangedCommandact = new RelayCommand<object>(
         items =>
         {
             if (items == null)
             {
                 return;
             }
             GetSelectedListact(items);
         });
            SelectionChangedCommandcomp = new RelayCommand<object>(
           items =>
           {
               if (items == null)
               {
                   return;
               }
               GetSelectedListcomp(items);
           });
            CMDBusinessPlace = new RelayCommand<object>(
           items =>
           {
          if (items == null)
          {
              return;
          }
          GetSelectedBusinessPlace(items);
           });
            LoadInitialData();
            SelectedStateListOrg = SelectedStateList;
        }

        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.client;
                // LOC = repositoryM.GetDataWithReturnDomainObject<MultipleContextADM_M003>(LOC, "ADM_M003_Data", "LocationMaster", "Administration", "", 0, "");
                LOC = repositoryM.GetDataWithReturnDomainObject<MultipleContext2>(LOC, Request, "LocationMaster", "Administration", "LoadInitialData", 0, "");
                SelectedList = LOC.Locationes;
                SelectedStateList = LOC.States;

                countryCollection = CollectionViewSource.GetDefaultView(LOC.Countrys);
                countryCollection.Filter = new Predicate<object>(Filtercountry);

                actCollection = CollectionViewSource.GetDefaultView(LOC.Activityes);
                actCollection.Filter = new Predicate<object>(Filteract);

                compCollection = CollectionViewSource.GetDefaultView(LOC.Companyes);
                compCollection.Filter = new Predicate<object>(Filtercomp);

                BusinessPlaceCollection = CollectionViewSource.GetDefaultView(LOC.BusinessPlace);
                BusinessPlaceCollection.Filter = new Predicate<object>(FilterBusinessPlace);

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
        //private void GetSelectedList(object DataList)
        //{
        //    IList list = DataList as IList;
        //    List<ADM_M003> tSelectedItemsList = list.Cast<ADM_M003>().ToList();
        //    if (tSelectedItemsList.Count > 0)
        //    {
        //        SelectedADM_M003 = (ADM_M003)tSelectedItemsList[0];
        //        blNew = false;
        //        SelectedTabControlIndex = 0;
        //    }
        //}
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            ADM_M003 ParameterEntityObject = null;
            try
            {
                if (((IEnumerable)ParameterObject).Cast<ADM_M003>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ADM_M003>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.location_Id + "!@" + ParameterEntityObject.comp_code + "!@" + AppSessionState.client;
                    LOC = repositoryM.GetDataWithReturnDomainObject<MultipleContext2>(LOC, Request, "LocationMaster", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                    if (LOC.Locationes.Count > 0)
                    {
                        SelectedADM_M003 = LOC.Locationes[0];
                        SelectedADM_M003.editby = AppSessionState.UserID;
                    }




                    SelectedTabControlIndex = 0;



                    blNew = false;
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
        private void GetSelectedListcountry(object country)
        {
            IList list = country as IList;
            List<Reflection.BusinessEntity.ADM_M012_P> tSelectedItemsList = list.Cast<Reflection.BusinessEntity.ADM_M012_P>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedADM_M003.country_code = tSelectedItemsList[0].country_code;
                SelectedADM_M003.CountryName = tSelectedItemsList[0].CntryName;


                var myItem = (from o in SelectedStateListOrg
                              where o.country_code == tSelectedItemsList[0].country_code
                              select o).ToList();
                stateCollection = CollectionViewSource.GetDefaultView(myItem.ToList());
                stateCollection.Filter = new Predicate<object>(Filterstate);
            }
        }
        private void GetSelectedListstate(object state)
        {
            IList list = state as IList;
            List<Reflection.BusinessEntity.ADM_M013_P> tSelectedItemsList = list.Cast<Reflection.BusinessEntity.ADM_M013_P>().ToList();
            if (tSelectedItemsList.Count > 0)
            {

                SelectedADM_M003.StateName = tSelectedItemsList[0].StatName;
                SelectedADM_M003.state_code = tSelectedItemsList[0].state_code;
            }
        }
        private void GetSelectedListact(object act)
        {
            IList list = act as IList;
            List<ADM_M004_P> tSelectedItemsList = list.Cast<ADM_M004_P>().ToList();
            if (tSelectedItemsList.Count > 0)
            {

                SelectedADM_M003.ActivityName = tSelectedItemsList[0].activtNm;
                SelectedADM_M003.activity_code = tSelectedItemsList[0].activity_code;
            }
        }
        private void GetSelectedListcomp(object state)
        {
            IList list = state as IList;
            List<ADM_M002_P> tSelectedItemsList = list.Cast<ADM_M002_P>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedADM_M003.comp_code = tSelectedItemsList[0].comp_code;
                SelectedADM_M003.CompanyName = tSelectedItemsList[0].CompName;

            }
        }
        private void GetSelectedBusinessPlace(object state)
        {
            IList list = state as IList;
            List<ADM_M003_C_P> tSelectedItemsList = list.Cast<ADM_M003_C_P>().ToList();
            if (tSelectedItemsList.Count > 0)
            {

                SelectedADM_M003.buss_place = tSelectedItemsList[0].buss_place;
                SelectedADM_M003.plc_name = tSelectedItemsList[0].plc_name;
                SelectedADM_M003.bisness_state_code = tSelectedItemsList[0].bisness_state_code;

            }
        }
        private void GetSelectedState(int request)
        {
            //var MyState = (from o in SelectedStateListOrg
            //               where o.CntryCode == request
            //               select o).ToList();
            //SelectedStateList = (List<ADM_M013_PopUp>)MyState.ToList();

        }

        //#region Methods
        //public event PropertyChangedEventHandler PropertyChanged;
        //public void RaisePropertychanged(string propertyName)
        //{
        //    // take a copy to prevent thread issues
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}



        //#endregion

        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<ADM_M003> result)
        {
            try
            {
                this.SelectedADM_M003.EndEdit();
                SelectedADM_M003.client = AppSessionState.client;
                SelectedADM_M003.add_by = AppSessionState.UserID;
                SelectedADM_M003.editby = AppSessionState.UserID;
                if (Validation() == true)
                {
                    if (blNew == true)
                    {
                        SelectedADM_M003 = repository.SaveWithReturnDomainObject<ADM_M003>(SelectedADM_M003, "LocationMaster", "Administration");
                        SelectedList.Add(SelectedADM_M003);
                        _dataGridCollection.Refresh();
                        blNew = false;
                    }
                    else if (blNew == false)
                    {
                        string response = repository.Update<ADM_M003>(SelectedADM_M003, "LocationMaster", "Administration");
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
        //protected override void OnExportAction(InquiryActionResult<ADM_M003> result)
        //{
        //    try
        //    {
        //        ExportToExcel<ADM_M003, List<ADM_M003>> export = new ExportToExcel<ADM_M003, List<ADM_M003>>();
        //        ICollectionView view = CollectionViewSource.GetDefaultView(DataGridCollection);
        //        export.dataToPrint = (List<ADM_M003>)view.SourceCollection;
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
        protected override void OnCreateAction(InquiryActionResult<ADM_M003> result)
        {
            SelectedADM_M003 = new ADM_M003();
            blNew = true;
            SelectedADM_M003.ValidateAsync().Wait();
            _dataGridCollection.Refresh();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M003> result)
        {
            if (SelectedADM_M003.location_Id != null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Delete Changes";
                showMessageService.Text =
                    String.Format(
                        "This record will Be Deleted forever '{0}'",
                            this.Title);

                if (showMessageService.ShowMessage() == DialogResult.Ok)
                {
                    string response = repository.Delete(SelectedADM_M003.location_Id, "LocationMaster", "Administration");
                    SelectedList.Remove(SelectedADM_M003);
                    _dataGridCollection.Refresh();
                    SelectedADM_M003 = new ADM_M003();
                    blNew = true;
                }
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M003> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M003 = SelectedADM_M003;
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M003> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M003> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M003 = SelectedADM_M003;
        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M003> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M003 = SelectedADM_M003;
        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M003> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M003 = SelectedADM_M003;
        }
        protected override void OnDocumentAction()
        {
            throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M003> result)
        {
            throw new NotImplementedException();
        }
        private bool Validation()
        {
            if (SelectedADM_M003.comp_code == null || SelectedADM_M003.comp_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Company...");
                showMessageService.ShowMessage();
                return false;
            }
            if (SelectedADM_M003.country_code == null || SelectedADM_M003.country_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Country and State...");
                showMessageService.ShowMessage();
                return false;
            }
            if (SelectedADM_M003.state_code == null || SelectedADM_M003.state_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select State...");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        #endregion

        #region "Filter"  
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
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString.ToString().ToLower())) ||
                           (data.MailId != null && data.MailId.ToString().ToLower().Contains(_filterString.ToString().ToLower())) ||
                           (data.City != null && data.City.ToString().ToLower().Contains(_filterString.ToString().ToLower())) ||
                           (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString.ToString().ToLower())) ||
                           (data.CompanyName != null && data.CompanyName.ToString().ToLower().Contains(_filterString.ToString().ToLower())) ||
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
                RaisePropertyChanged("FilterStringcountry");
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
                    return (data.CntryName != null && data.CntryName.ToString().ToLower().Contains(_filterStringcountry.ToString().ToLower())) ||
                           (data.country_code != null && data.country_code.ToString().ToLower().Contains(_filterStringcountry.ToString().ToLower()));
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
                RaisePropertyChanged("FilterStringstate");
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
                    return (data.StatName != null && data.StatName.ToString().ToLower().Contains(_filterStringstate.ToString().ToLower())) ||
                           (data.state_code != null && data.state_code.ToString().ToLower().Contains(_filterStringstate.ToString().ToLower()));
                }
                return true;
            }
            return false;
        }
        //activity filter
        public string FilterStringact
        {
            get { return _filterStringact; }
            set
            {
                _filterStringact = value;
                RaisePropertyChanged("FilterStringact");
                FilterCollectionact();
            }
        }
        private void FilterCollectionact()
        {
            if (_actCollection != null)
            {
                _actCollection.Refresh();
            }
        }
        public bool Filteract(object obj)
        {
            var data = obj as ADM_M004_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringact))
                {
                    return (data.activtNm != null && data.activtNm.ToString().ToLower().Contains(_filterStringact.ToString().ToLower())) ||
                           (data.activity_code != null && data.activity_code.ToString().ToLower().Contains(_filterStringact.ToString().ToLower()));
                }
                return true;
            }
            return false;
        }
        //company filter
        public string FilterStringcomp
        {
            get { return _filterStringcomp; }
            set
            {
                _filterStringcomp = value;
                RaisePropertyChanged("FilterStringcomp");
                FilterCollectioncomp();
            }
        }

        public int _selectedTabControlIndex { get; private set; }

        private void FilterCollectioncomp()
        {
            if (_compCollection != null)
            {
                _compCollection.Refresh();
            }
        }
        public bool Filtercomp(object obj)
        {
            var data = obj as ADM_M002_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringcomp))
                {
                    return (data.CompName != null && data.CompName.ToString().ToLower().Contains(_filterStringcomp.ToString().ToLower())) ||
                           (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterStringcomp.ToString().ToLower()));
                }
                return true;
            }
            return false;
        }
        public string _filterStringBusinessPlace;
        public string FilterStringBusinessPlace
        {
            get { return _filterStringBusinessPlace; }
            set
            {
                _filterStringBusinessPlace = value;
                RaisePropertyChanged("FilterStringBusinessPlace");
                FilterCollectionBusinessPlace();
            }
        }
        private void FilterCollectionBusinessPlace()
        {
            if (_BusinessPlaceCollection != null)
            {
                _BusinessPlaceCollection.Refresh();
            }
        }
        public bool FilterBusinessPlace(object obj)
        {
            var data = obj as ADM_M003_C_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringBusinessPlace))
                {
                    return (data.buss_place != null && data.buss_place.ToLower().Contains(_filterStringBusinessPlace.ToLower())) ||
                        (data.plc_name != null && data.plc_name.ToLower().Contains(_filterStringBusinessPlace.ToLower()));
                }
                return true;
            }
            return false;
        }

        
        #endregion
    }
}
