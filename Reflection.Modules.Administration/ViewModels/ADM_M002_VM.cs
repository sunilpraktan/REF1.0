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
using Microsoft.Win32;
using System.Windows;
using System.IO;
using System.Windows.Media.Imaging;
using Reflection.BusinessEntity;
using Reflection.Presentation.ViewModel;
using GalaSoft.MvvmLight.Command;
using Reflection.ReportingServices;

namespace Reflection.Modules.Administration.ViewModels
{
    public class ADM_M002_VM : WorkspaceViewModel<ADM_M002>
    {
        bool blNew = true;
        WebServiceRepository<ADM_M002> repository = new WebServiceRepository<ADM_M002>();
        WebServiceRepository<MultipleContext2> repositoryCM = new WebServiceRepository<MultipleContext2>();
        private ICollectionView _dataGridCollection;
        private string _filterString;
        private string _filterStringcountry;
        private string _filterStringstate;
        private string _filterStringgrp;
        private string _filterStringemp;


        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = SelectedADM_M002.HasErrors;
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
        private ICollectionView _grpCollection;
        public ICollectionView grpCollection
        {
            get { return _grpCollection; }
            set { _grpCollection = value; RaisePropertyChanged("grpCollection"); }
        }
        private ICollectionView _empCollection;
        public ICollectionView empCollection
        {
            get { return _empCollection; }
            set { _empCollection = value; RaisePropertyChanged("empCollection"); }
        }
        private ICollectionView _CurrencyCollection;
        public ICollectionView CurrencyCollection
        {
            get { return _CurrencyCollection; }
            set { _CurrencyCollection = value; RaisePropertyChanged("CurrencyCollection"); }
        }
        private ICollectionView _BusinessPlaceCollection;
        public ICollectionView BusinessPlaceCollection
        {
            get { return _BusinessPlaceCollection; }
            set { _BusinessPlaceCollection = value; RaisePropertyChanged("BusinessPlaceCollection"); }
        }

        public RelayCommand SortState { get; private set; }
        public RelayCommand<object> SelectionChangedCommand { get; private set; }
        //public RelayCommand<IList> SelectionChangedCommand
        //{
        //    get;
        //    private set;
        //}
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
        public RelayCommand<object> SelectionChangedCommandgrp
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandemp
        {
            get;
            private set;
        }

        public RelayCommand<object> SelectionChangedCommandregcountry
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandregstate
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandCurrency
        {
            get;
            private set;
        }
        public RelayCommand<object> CMDBusinessPlace
        {
            get;
            private set;
        }
        private RelayCommand _openCommand;
        public RelayCommand OpenCommand
        {
            get;
            private set;
        }
        private RelayCommand _openCommand2;
        public RelayCommand OpenCommand2
        {
            get;
            private set;
        }

        private List<ADM_M002> _SelectedList;
        public List<ADM_M002> SelectedList
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
        private List<ADM_M012_P> _SelectedCountryList1;
        public List<ADM_M012_P> SelectedCountryList1
        {
            get { return _SelectedCountryList1; }
            set
            {
                if (_SelectedCountryList1 != value)
                {
                    _SelectedCountryList1 = value;
                    RaisePropertyChanged("SelectedCountryList1");

                }
            }
        }
        private ObservableCollection<ADM_M013_P> _SelectedStateList1;
        public ObservableCollection<ADM_M013_P> SelectedStateList1
        {
            get { return _SelectedStateList1; }
            set
            {
                if (_SelectedStateList1 != value)
                {
                    _SelectedStateList1 = value;
                    RaisePropertyChanged("SelectedStateList1");
                }
            }
        }
        private List<ADM_M001> _SelectedGroupList;
        public List<ADM_M001> SelectedGroupList
        {
            get { return _SelectedGroupList; }
            set
            {
                if (_SelectedGroupList != value)
                {
                    _SelectedGroupList = value;
                    RaisePropertyChanged("SelectedGroupList");
                }
            }
        }

        private ObservableCollection<ADM_M026_P> _DesignationList;
        public ObservableCollection<ADM_M026_P> DesignationList
        {
            get { return _DesignationList; }
            set
            {
                _DesignationList = value;
                RaisePropertyChanged("DesignationList");
            }
        }

        private ObservableCollection<ADM_M037_P> _CurrencyList;
        public ObservableCollection<ADM_M037_P> CurrencyList
        {
            get { return _CurrencyList; }
            set
            {
                _CurrencyList = value;
                RaisePropertyChanged("CurrencyList");
            }
        }
        private List<ADM_M024_P> _SelectedEmployeeList;
        public List<ADM_M024_P> SelectedEmployeeList
        {
            get { return _SelectedEmployeeList; }
            set
            {
                if (_SelectedEmployeeList != value)
                {
                    _SelectedEmployeeList = value;
                    RaisePropertyChanged("SelectedEmployeeList");
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
                    RaisePropertyChanged("SelectedStateListOrg1");
                }

            }

        }


        private ADM_M002 _SelectedADM_M002;
        public ADM_M002 SelectedADM_M002
        {
            get
            {
                this.ErrorExist = _SelectedADM_M002.HasErrors;
                return _SelectedADM_M002;
            }
            set
            {
                if (_SelectedADM_M002 != value)
                {
                    _SelectedADM_M002 = value;
                    RaisePropertyChanged("SelectedADM_M002");
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



        MultipleContext2 _CM2 = new MultipleContext2();
        public MultipleContext2 CM2
        {
            get { return _CM2; }
            set
            {
                if (_CM2 != value)
                {
                    _CM2 = value;
                    RaisePropertyChanged("CM2");
                }
            }

        }
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("prepare_by", AppSessionState.Name);
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
            return result;
        }
        public ADM_M002_VM()
            : base()
        {
            ADM_M002.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            SelectedList = new List<ADM_M002>();
            SelectedCountryList1 = new List<ADM_M012_P>();
            SelectedStateList1 = new ObservableCollection<ADM_M013_P>();
            SelectedGroupList = new List<ADM_M001>();
            SelectedEmployeeList = new List<ADM_M024_P>();
            DesignationList = new ObservableCollection<ADM_M026_P>();
            CurrencyList = new ObservableCollection<ADM_M037_P>();

            SelectedADM_M002 = new ADM_M002();

            SelectedADM_M002.ValidateAsync().Wait();
            OpenCommand = new RelayCommand(OpenFile);
            OpenCommand2 = new RelayCommand(OpenFile2);
            //SelectionChangedCommand = new RelayCommand<IList>(
            //items =>
            //{
            //    if (items == null)
            //    {
            //        //SelectedList = null;
            //        return;
            //    }
            //    GetSelectedList(items);

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
            SelectionChangedCommandgrp = new RelayCommand<object>(
             items =>
             {
                 if (items == null)
                 {
                     return;
                 }
                 GetSelectedListgrp(items);
             });
            SelectionChangedCommandemp = new RelayCommand<object>(
           items =>
           {
               if (items == null)
               {
                   return;
               }
               GetSelectedListemp(items);
           });

            SelectionChangedCommandregcountry = new RelayCommand<object>(
            items =>
            {
                if (items == null)
                {
                    return;
                }
                GetSelectedListregcountry(items);
            });
            SelectionChangedCommandregstate = new RelayCommand<object>(
           items =>
           {
               if (items == null)
               {
                   return;
               }
               GetSelectedListregstate(items);
           });
            SelectionChangedCommandCurrency = new RelayCommand<object>(
         items =>
         {
             if (items == null)
             {
                 return;
             }
             GetSelectedListCurrency(items);
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
            SelectedStateListOrg1 = SelectedStateList1;

        }

        #region Open Image
        string imageName;
        private void OpenFile()
        {
            try
            {

                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.Gif)|*.jpg;*.bmp;*.Gif";
                fldlg.ShowDialog();
                {

                    imageName = fldlg.FileName;

                    SelectedADM_M002.CompLogo = File.ReadAllBytes(imageName);

                }

                fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        private void OpenFile2()
        {
            try
            {

                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.Gif)|*.jpg;*.bmp;*.Gif";
                fldlg.ShowDialog();
                {

                    imageName = fldlg.FileName;

                    SelectedADM_M002.CompLogo2 = File.ReadAllBytes(imageName);

                }

                fldlg = null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
        public BitmapImage ImageFromBytearray(byte[] imageData)
        {

            if (imageData == null)
                return null;
            MemoryStream strm = new MemoryStream();
            strm.Write(imageData, 0, imageData.Length);
            strm.Position = 0;
            System.Drawing.Image img = System.Drawing.Image.FromStream(strm);

            BitmapImage bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            MemoryStream memoryStream = new MemoryStream();
            img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Gif);
            memoryStream.Seek(0, SeekOrigin.Begin);
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.EndInit();

            return bitmapImage;
        }
        #endregion
        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.client;

                CM2 = repositoryCM.GetDataWithReturnDomainObject<MultipleContext2>(CM2, Request, "Company_Master", "Administration", "LoadInitialData", 0, "");
                SelectedList = CM2.CompanyMaster;
                SelectedStateList1 = CM2.Shtate;
                DesignationList = CM2.Designation;

                countryCollection = CollectionViewSource.GetDefaultView(CM2.Kntry);
                countryCollection.Filter = new Predicate<object>(Filtercountry);

                grpCollection = CollectionViewSource.GetDefaultView(CM2.GroupCode);
                grpCollection.Filter = new Predicate<object>(Filtergrp);

                empCollection = CollectionViewSource.GetDefaultView(CM2.Employee);
                empCollection.Filter = new Predicate<object>(Filteremp);

                CurrencyCollection = CollectionViewSource.GetDefaultView(CM2.Currency);
                CurrencyCollection.Filter = new Predicate<object>(FilterCurrency);

                BusinessPlaceCollection = CollectionViewSource.GetDefaultView(CM2.BusinessPlace);
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
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            ADM_M002 ParameterEntityObject = null;
            try
            {
                if (((IEnumerable)ParameterObject).Cast<ADM_M002>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ADM_M002>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.comp_code + "!@" + AppSessionState.client;
                    //MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ADM_M028>(MCTemp, Request, "PartyMaster", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                    CM2 = repositoryCM.GetDataWithReturnDomainObject<MultipleContext2>(CM2, Request, "Company_Master", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                    if (CM2.CompanyMaster.Count > 0)
                    {
                        SelectedADM_M002 = CM2.CompanyMaster[0];
                        SelectedADM_M002.editby = AppSessionState.UserID;
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
        //private void GetSelectedList(IList DataList)
        //{
        //    IList list = DataList as IList;
        //    List<ADM_M002> tSelectedItemsList = list.Cast<ADM_M002>().ToList();
        //    if (tSelectedItemsList.Count > 0)
        //    {
        //        SelectedADM_M002 = tSelectedItemsList[0];
        //        SelectedTabControlIndex = 0;
        //        blNew = false;
        //    }
        //}
        private void GetSelectedListcountry(object country)
        {
            IList list = country as IList;
            List<ADM_M012_P> tSelectedItemsList = list.Cast<ADM_M012_P>().ToList();
            if (tSelectedItemsList.Count > 0)
            {

                SelectedADM_M002.CountryName = tSelectedItemsList[0].CntryName;
                SelectedADM_M002.country_code = tSelectedItemsList[0].country_code;

                var myItem = (from o in SelectedStateListOrg1
                              where o.country_code == tSelectedItemsList[0].country_code
                              select o).ToList();
                stateCollection = CollectionViewSource.GetDefaultView(myItem.ToList());
                stateCollection.Filter = new Predicate<object>(Filterstate);
            }
        }
        private void GetSelectedListstate(object state)
        {
            IList list = state as IList;
            List<ADM_M013_P> tSelectedItemsList = list.Cast<ADM_M013_P>().ToList();
            if (tSelectedItemsList.Count > 0)
            {

                SelectedADM_M002.StateName = tSelectedItemsList[0].StatName;
                SelectedADM_M002.state_code = tSelectedItemsList[0].state_code;

            }
        }
        private void GetSelectedListCurrency(object state)
        {
            IList list = state as IList;
            List<ADM_M037_P> tSelectedItemsList = list.Cast<ADM_M037_P>().ToList();
            if (tSelectedItemsList.Count > 0)
            {

                SelectedADM_M002.curr_code = tSelectedItemsList[0].curr_code;
                SelectedADM_M002.curr_name = tSelectedItemsList[0].curr_name;

            }
        }
        private void GetSelectedBusinessPlace(object state)
        {
            IList list = state as IList;
            List<ADM_M003_C_P> tSelectedItemsList = list.Cast<ADM_M003_C_P>().ToList();
            if (tSelectedItemsList.Count > 0)
            {

                SelectedADM_M002.buss_place = tSelectedItemsList[0].buss_place;
                SelectedADM_M002.plc_name = tSelectedItemsList[0].plc_name;

            }
        }
        private void GetSelectedListemp(object emp)
        {
            IList list = emp as IList;
            List<ADM_M024_P> tSelectedItemsList = list.Cast<ADM_M024_P>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedADM_M002.ContPerNm = tSelectedItemsList[0].EmpId;
                SelectedADM_M002.EmployeeName = tSelectedItemsList[0].EmpName;

                var mydesig = (from o in DesignationList
                               where o.desig_code == tSelectedItemsList[0].desig_code
                               select o).ToList();

                SelectedADM_M002.PrsnlMobNo = tSelectedItemsList[0].EmpMobNo;
                SelectedADM_M002.DesignationName = "";
                SelectedADM_M002.desig_code = "";
                if (mydesig.ToList().Count > 0)
                {
                    SelectedADM_M002.DesignationName = mydesig.ToList()[0].DesigName;
                    SelectedADM_M002.desig_code = mydesig.ToList()[0].desig_code;
                }
            }
        }

        private void GetSelectedListgrp(object state)
        {
            IList list = state as IList;
            List<ADM_M001_PG> tSelectedItemsList = list.Cast<ADM_M001_PG>().ToList();
            if (tSelectedItemsList.Count > 0)
            {

                SelectedADM_M002.GroupName = tSelectedItemsList[0].GrpName;
                SelectedADM_M002.group_code = tSelectedItemsList[0].group_code;
                SelectedADM_M002.client = tSelectedItemsList[0].client;

            }
        }

        private void GetSelectedListregcountry(object country)
        {
            IList list = country as IList;
            List<ADM_M012_P> tSelectedItemsList = list.Cast<ADM_M012_P>().ToList();
            if (tSelectedItemsList.Count > 0)
            {

                SelectedADM_M002.regCountryName = tSelectedItemsList[0].CntryName;
                SelectedADM_M002.reg_country = tSelectedItemsList[0].country_code;
                var myItem = (from o in SelectedStateListOrg1
                              where o.country_code == tSelectedItemsList[0].country_code
                              select o).ToList();
                stateCollection = CollectionViewSource.GetDefaultView(myItem.ToList());
                stateCollection.Filter = new Predicate<object>(Filterstate);
            }
        }
        private void GetSelectedListregstate(object state)
        {
            IList list = state as IList;
            List<ADM_M013_P> tSelectedItemsList = list.Cast<ADM_M013_P>().ToList();
            if (tSelectedItemsList.Count > 0)
            {

                SelectedADM_M002.regStateName = tSelectedItemsList[0].StatName;
                SelectedADM_M002.reg_state = tSelectedItemsList[0].state_code;
            }
        }



        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<ADM_M002> result)
        {
            try
            {
                this.SelectedADM_M002.EndEdit();
                // SelectedADM_M002.client = AppSessionState.client;
                SelectedADM_M002.add_by = AppSessionState.UserID.ToString();
                SelectedADM_M002.editby = AppSessionState.UserID.ToString();

                if (blNew == true)
                {
                    SelectedADM_M002 = repository.SaveWithReturnDomainObject<ADM_M002>(SelectedADM_M002, "Company_Master", "Administration");
                    SelectedList.Add(SelectedADM_M002);
                    _dataGridCollection.Refresh();
                    blNew = false;
                }
                else if (blNew == false)
                {
                    string response = repository.Update<ADM_M002>(SelectedADM_M002, "Company_Master", "Administration");
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
        //protected override void OnExportAction(InquiryActionResult<ADM_M002> result)
        //{
        //    try
        //    {
        //        ExportToExcel<ADM_M002, List<ADM_M002>> export = new ExportToExcel<ADM_M002, List<ADM_M002>>();
        //        ICollectionView view = CollectionViewSource.GetDefaultView(DataGridCollection);
        //        export.dataToPrint = (List<ADM_M002>)view.SourceCollection;
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
        protected override void OnCreateAction(InquiryActionResult<ADM_M002> result)
        {
            SelectedADM_M002 = new ADM_M002();
            blNew = true;
            SelectedADM_M002.ValidateAsync().Wait();
            _dataGridCollection.Refresh();
        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M002> result)
        {
            if (SelectedADM_M002.comp_code != null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Delete Changes";
                showMessageService.Text =
                    String.Format(
                        "This record will be Deleted forever '{0}'",
                            this.Title);

                if (showMessageService.ShowMessage() == DialogResult.Ok)
                {

                    string response = repository.Delete(SelectedADM_M002.comp_code, "Company_Master", "Administration");
                    SelectedList.Remove(SelectedADM_M002);
                    _dataGridCollection.Refresh();
                    SelectedADM_M002 = new ADM_M002();
                    blNew = true;
                }
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M002> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M002 = SelectedADM_M002;
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M002> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M002> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M002 = SelectedADM_M002;
        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M002> result)
        {
            SelectedList = SelectedList;
            SelectedADM_M002 = SelectedADM_M002;
        }

        protected override void OnPrintAction(InquiryActionResult<ADM_M002> result)
        {
            try
            {

                string Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.client + "!@" + SelectedADM_M002.comp_code;

                //MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ADM_M024>(MCTemp, Request, "PartyMaster", "Administration", "", 0, "");
                CM2 = repositoryCM.GetDataWithReturnDomainObject<MultipleContext2>(CM2, Request, "Company_Master", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                object[] objDataSource = new object[1];
                string[] objDataSourceName = new string[1];



                objDataSource[0] = CM2.CompanyMaster;

                //List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                //var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                //objDataSource[1] = CmpResult;

                //List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                //var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                //objDataSource[2] = Result;



                objDataSourceName[0] = "dsCompany";
                //objDataSourceName[1] = "dsCompany";
                //objDataSourceName[2] = "dsLocation";


                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Admin\\CompanyReport.rdlc", getParametersList(), "");
            }
            catch (Exception ex) { }
        }

        #endregion

        #region"FILTER"        
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
            var data = obj as ADM_M002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterString.ToLower())) ||

                           (data.CompName != null && data.CompName.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.CompAbbre != null && data.CompAbbre.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.City != null && data.City.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.PinCode != null && data.PinCode.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.MailId != null && data.MailId.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.GroupName != null && data.GroupName.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.WebSite != null && data.WebSite.ToString().ToLower().Contains(_filterString.ToLower()));


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
                    return (data.CntryName != null && data.CntryName.ToLower().Contains(_filterStringcountry.ToLower())) ||
                        (data.country_code != null && data.country_code.ToLower().Contains(_filterStringcountry.ToLower())
                        );
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

        //state filter

        public string _filterStringCurrency;
        public string FilterStringCurrency
        {
            get { return _filterStringCurrency; }
            set
            {
                _filterStringCurrency = value;
                RaisePropertyChanged("FilterStringCurrency");
                FilterCollectionCurrency();
            }
        }
        private void FilterCollectionCurrency()
        {
            if (_CurrencyCollection != null)
            {
                _CurrencyCollection.Refresh();
            }
        }
        public bool FilterCurrency(object obj)
        {
            var data = obj as ADM_M037_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringCurrency))
                {
                    return (data.curr_code != null && data.curr_code.ToLower().Contains(_filterStringCurrency.ToLower())) ||
                        (data.curr_name != null && data.curr_name.ToLower().Contains(_filterStringCurrency.ToLower())
                        );
                }
                return true;
            }
            return false;
        }
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
                    return (data.StatName != null && data.StatName.ToLower().Contains(_filterStringstate.ToLower()) ||
                        data.state_code != null && data.state_code.ToLower().Contains(_filterStringstate.ToLower())
                        );
                }
                return true;
            }
            return false;
        }

        //GROUP filter
        public string FilterStringgrp
        {
            get { return _filterStringgrp; }
            set
            {
                _filterStringgrp = value;
                RaisePropertyChanged("FilterStringgrp");
                FilterCollectiongrp();
            }
        }
        private void FilterCollectiongrp()
        {
            if (_grpCollection != null)
            {
                _grpCollection.Refresh();
            }
        }
        public bool Filtergrp(object obj)
        {
            var data = obj as ADM_M001_PG;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringgrp))
                {
                    return (data.GrpName != null && data.GrpName.ToLower().Contains(_filterStringgrp.ToLower())) ||
                           (data.group_code != null && data.group_code.ToLower().Contains(_filterStringgrp.ToLower())
                        );
                }
                return true;
            }
            return false;
        }

        //employee filter
        public string FilterStringemp
        {
            get { return _filterStringemp; }
            set
            {
                _filterStringemp = value;
                RaisePropertyChanged("FilterStringemp");
                FilterCollectionemp();
            }
        }
        private void FilterCollectionemp()
        {
            if (_empCollection != null)
            {
                _empCollection.Refresh();
            }
        }
        public bool Filteremp(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringemp))
                {
                    return (data.EmpId != null && data.EmpId.ToLower().Contains(_filterStringemp.ToLower())) ||
                            (data.EmpName != null && data.EmpName.ToLower().Contains(_filterStringemp.ToLower())
                           );
                }
                return true;
            }
            return false;
        }

        protected override void OnDocumentAction()
        {

        }

        protected override void OnRefreshCommand(InquiryActionResult<ADM_M002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M002> result)
        {
            throw new NotImplementedException();
        }



        #endregion
    }
}
