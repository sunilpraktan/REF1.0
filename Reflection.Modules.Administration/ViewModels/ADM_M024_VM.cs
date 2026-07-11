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
using Microsoft.Win32;
using System.IO;
using System.Windows.Media.Imaging;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using Reflection.ReportingServices;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.Administration.ViewModels
{
    public class ADM_M024_VM : WorkspaceViewModel<ADM_M024>
    {
        bool blNew = true;
        WebServiceRepository<ADM_M024> repository = new WebServiceRepository<ADM_M024>();
        WebServiceRepository<MultipleContext_ADM_M024> repositoryM = new WebServiceRepository<MultipleContext_ADM_M024>();
        WebServiceRepository<MultipleContext_ADM_M024> repository_MCTemp = new WebServiceRepository<MultipleContext_ADM_M024>();


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
        private RequestParameters _RequestPara;
        public RequestParameters RequestPara
        {
            get { return _RequestPara; }
            set
            {
                if (_RequestPara != value)
                {
                    _RequestPara = value;

                    RaisePropertyChanged("RequestPara");
                }
            }
        }

        #region ICollectionView
        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set
            {
                _dataGridCollection = value;
                RaisePropertyChanged("DataGridCollection");
            }
        }
        private ICollectionView _LocationCollection;
        public ICollectionView LocationCollection
        {
            get { return _LocationCollection; }
            set { _LocationCollection = value; RaisePropertyChanged("LocationCollection"); }
        }
        private ICollectionView _DepartmentCollection;
        public ICollectionView DepartmentCollection
        {
            get { return _DepartmentCollection; }
            set { _DepartmentCollection = value; RaisePropertyChanged("DepartmentCollection"); }
        }
        private ICollectionView _DisignationCollection;
        public ICollectionView DisignationCollection
        {
            get { return _DisignationCollection; }
            set { _DisignationCollection = value; RaisePropertyChanged("DisignationCollection"); }
        }
        private ICollectionView _EmployeeTypeCollection;
        public ICollectionView EmployeeTypeCollection
        {
            get { return _EmployeeTypeCollection; }
            set { _EmployeeTypeCollection = value; RaisePropertyChanged("EmployeeTypeCollection"); }
        }

        private ICollectionView _PurchaseGroupCollection;
        public ICollectionView PurchaseGroupCollection
        {
            get { return _PurchaseGroupCollection; }
            set
            {
                _PurchaseGroupCollection = value;
                RaisePropertyChanged("PurchaseGroupCollection");
            }
        }

        private ICollectionView _SalesGroupCollection;
        public ICollectionView SalesGroupCollection
        {
            get { return _SalesGroupCollection; }
            set
            {
                _SalesGroupCollection = value;
                RaisePropertyChanged("SalesGroupCollection");
            }
        }

        private ICollectionView _CustomerCollection;
        public ICollectionView CustomerCollection
        {
            get { return _CustomerCollection; }
            set
            {
                _CustomerCollection = value;
                RaisePropertyChanged("CustomerCollection");
            }
        }
        private ICollectionView _CompanyCollection;
        public ICollectionView CompanyCollection
        {
            get { return _CompanyCollection; }
            set { _CompanyCollection = value; RaisePropertyChanged("CompanyCollection"); }
        }

        #endregion

        #region StringList

        List<string> _StringListLocation;
        public List<string> StringListLocation
        {
            get { return _StringListLocation; }
            set
            {
                if (_StringListLocation != value)
                {
                    _StringListLocation = value;
                }
            }
        }
        List<string> _StringListDepartment;
        public List<string> StringListDepartment
        {
            get { return _StringListDepartment; }
            set
            {
                if (_StringListDepartment != value)
                {
                    _StringListDepartment = value;
                }
            }
        }
        List<string> _StringListDisignation;
        public List<string> StringListDisignation
        {
            get { return _StringListDisignation; }
            set
            {
                if (_StringListDisignation != value)
                {
                    _StringListDisignation = value;
                }
            }
        }
        List<string> _StringListEmployeeType;
        public List<string> StringListEmployeeType
        {
            get { return _StringListEmployeeType; }
            set
            {
                if (_StringListEmployeeType != value)
                {
                    _StringListEmployeeType = value;
                }
            }
        }
        List<string> _StringListSalesGroup;
        public List<string> StringListSalesGroup
        {
            get { return _StringListSalesGroup; }
            set
            {
                if (_StringListSalesGroup != value)
                {
                    _StringListSalesGroup = value;
                }
            }
        }

        List<string> _StringListPurchaseGroup;
        public List<string> StringListPurchaseGroup
        {
            get { return _StringListPurchaseGroup; }
            set
            {
                if (_StringListPurchaseGroup != value)
                {
                    _StringListPurchaseGroup = value;
                }
            }
        }
        List<string> _StringListCustomer;
        public List<string> StringListCustomer
        {
            get { return _StringListCustomer; }
            set
            {
                if (_StringListCustomer != value)
                {
                    _StringListCustomer = value;
                }
            }
        }
        private List<string> _StringListCompany;
        public List<string> StringListCompany
        {
            get { return _StringListCompany; }
            set
            {
                if (_StringListCompany != value)
                {
                    _StringListCompany = value;
                }
            }
        }
        #endregion

        #region Declaration

        private ADM_M024 _MasterEntity;
        public ADM_M024 MasterEntity
        {
            get
            {
                return _MasterEntity;
            }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged("MasterEntity");

                }
            }
        }

        private List<ADM_M024_P> _FlipGridData;
        public List<ADM_M024_P> FlipGridData
        {
            get { return _FlipGridData; }
            set
            {
                if (_FlipGridData != value)
                {
                    _FlipGridData = value;
                    RaisePropertyChanged("FlipGridData");
                }
            }
        }

        MultipleContext_ADM_M024 _MC = new MultipleContext_ADM_M024();
        public MultipleContext_ADM_M024 MC
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
        MultipleContext_ADM_M024 _MCTemp = new MultipleContext_ADM_M024();
        public MultipleContext_ADM_M024 MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value;
                    RaisePropertyChanged("MCTemp");
                }
            }
        }

        private ObservableCollection<ADM_M024_C> _CustEntity;
        public ObservableCollection<ADM_M024_C> CustEntity
        {
            get
            {
                return _CustEntity;
            }
            set
            {
                if (_CustEntity != value)
                {
                    _CustEntity = value;
                    CustEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForCust);
                    RaisePropertyChanged("CustEntity");
                }
            }
        }

        private ObservableCollection<ADM_M024_A> _SalesEntity;
        public ObservableCollection<ADM_M024_A> SalesEntity
        {
            get { return _SalesEntity; }
            set
            {
                if (_SalesEntity != value)
                {
                    _SalesEntity = value;
                    SalesEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSales);
                    RaisePropertyChanged("SalesEntity");
                }
            }
        }
        private ObservableCollection<ADM_M024_B> _PurchaseEntity;
        public ObservableCollection<ADM_M024_B> PurchaseEntity
        {
            get { return _PurchaseEntity; }
            set
            {
                if (_PurchaseEntity != value)
                {
                    _PurchaseEntity = value;
                    PurchaseEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForPurchase);
                    RaisePropertyChanged("PurchaseEntity");
                }
            }
        }

        private int _dgSelectedIndexSales;
        public int dgSelectedIndexSales
        {
            get
            {
                return _dgSelectedIndexSales;
            }
            set
            {
                if (_dgSelectedIndexSales != value)
                {
                    _dgSelectedIndexSales = value;
                    RaisePropertyChanged("dgSelectedIndexSales");
                }
            }
        }

        private int _dgSelectedIndexPurchase;
        public int dgSelectedIndexPurchase
        {
            get
            {
                return _dgSelectedIndexPurchase;
            }
            set
            {
                if (_dgSelectedIndexPurchase != value)
                {
                    _dgSelectedIndexPurchase = value;
                    RaisePropertyChanged("dgSelectedIndexPurchase");
                }
            }
        }
        private int _dgSelectedIndexItem;
        public int dgSelectedIndexItem
        {
            get
            {
                return _dgSelectedIndexItem;
            }
            set
            {
                if (_dgSelectedIndexItem != value)
                {
                    _dgSelectedIndexItem = value;
                    RaisePropertyChanged("dgSelectedIndexItem");
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
        #endregion

        #region RelayComand
        public RelayCommand<object> CmdAddLocation { get; private set; }
        public RelayCommand<object> CmdAddDepartment { get; private set; }
        public RelayCommand<object> CmdAddDisignation { get; private set; }
        public RelayCommand<object> CmdAddCustomerForGrid { get; private set; }
        public RelayCommand<object> CmdLoadDocumentById { get; private set; }
        public RelayCommand<object> CmdSalesGroup { get; private set; }
        public RelayCommand<object> CmdPurchaseGroup { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowSalesEntity { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowPurchaseEntity { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowCustEntity { get; private set; }
        public RelayCommand<object> CmdAddCompany { get; private set; }
        public RelayCommand OpenCommand { get; private set; }
        public RelayCommand cmdOpenSignature { get; private set; }
        public RelayCommand<object> CmdAddEmployeeType { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        public RelayCommand ExportCommand { get; private set; }

        #endregion

        #region Constructors

        public ADM_M024_VM()
            : base()
        {
            MasterEntity = new ADM_M024();
            MasterEntity.ValidateAsync().Wait();

            SalesEntity = new ObservableCollection<ADM_M024_A>();
            PurchaseEntity = new ObservableCollection<ADM_M024_B>();
            CustEntity = new ObservableCollection<ADM_M024_C>();
            FlipGridData = new List<ADM_M024_P>();

            cmdOpenSignature = new RelayCommand(OpenSignature);
            OpenCommand = new RelayCommand(OpenFile);
            MCTemp = new MultipleContext_ADM_M024();
            ADM_M024.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            RequestPara = new RequestParameters();

            CustEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForCust);
            SalesEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSales);
            PurchaseEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForPurchase);

            CmdAddLocation = new RelayCommand<object>(items => { if (items == null) { return; } InsertLocation(items); });
            CmdAddDepartment = new RelayCommand<object>(items => { if (items == null) { return; } InsertDepartment(items); });
            CmdAddDisignation = new RelayCommand<object>(items => { if (items == null) { return; } InsertDisignation(items); });
            CmdAddCustomerForGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCustomerForGrid(cmdPara, true, false, true); });
            CmdLoadDocumentById = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentById(cmdPara, "FlipGridReference"); });
            CmdSalesGroup = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSalesGroup(cmdPara, true, false, true); });
            CmdPurchaseGroup = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPurchaseGroup(cmdPara, true, false, true); });
            CmdDeleteDataGridRowSalesEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_SalesEntity(cmdPara); });
            CmdDeleteDataGridRowPurchaseEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_PurchaseEntity(cmdPara); });
            CmdDeleteDataGridRowCustEntity = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_CustEntity(cmdPara); });
            CmdAddCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            CmdAddEmployeeType = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmployeeType(items); });
            cmdLoadBackFlip = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadBackFlipData(cmdPara); });

            ExportCommand = new RelayCommand(ExportCommandPrint);
            LoadInitialData();
        }

        private void LoadInitialData()
        {
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id;
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_ADM_M024>(MC, Request, "Employee_Master", "Administration", "", 0, "");

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                //LocationCollection = CollectionViewSource.GetDefaultView(MC.Locations);
                //LocationCollection.Filter = new Predicate<object>(FilterLocation);
                //StringListLocation = MC.Locations.Select(x => x.LoctnNm.ToString()).ToList();

                DepartmentCollection = CollectionViewSource.GetDefaultView(MC.Departments);
                DepartmentCollection.Filter = new Predicate<object>(FilterDepartment);
                StringListDepartment = MC.Departments.Select(x => x.DeptName.ToString()).ToList();

                DisignationCollection = CollectionViewSource.GetDefaultView(MC.Disignations);
                DisignationCollection.Filter = new Predicate<object>(FilterDisignation);
                StringListDisignation = MC.Disignations.Select(x => x.DesigName.ToString()).ToList();

                //SalesGroupCollection = CollectionViewSource.GetDefaultView(MC.SalesGroup);
                //SalesGroupCollection.Filter = new Predicate<object>(Filter_Sales);
                //StringListSalesGroup = MC.SalesGroup.Select(x => x.sg_code.ToString()).ToList();

                //PurchaseGroupCollection = CollectionViewSource.GetDefaultView(MC.PurchaseGroup);
                //PurchaseGroupCollection.Filter = new Predicate<object>(Filter_Purchase);
                //StringListPurchaseGroup = MC.PurchaseGroup.Select(x => x.pg_code.ToString()).ToList();

                CustomerCollection = CollectionViewSource.GetDefaultView(MC.Customers);
                CustomerCollection.Filter = new Predicate<object>(Filter_Customer);
                StringListCustomer = MC.Customers.Select(x => x.PartyNm.ToString()).ToList();

                CompanyCollection = CollectionViewSource.GetDefaultView(MC.Company);
                CompanyCollection.Filter = new Predicate<object>(Filter_Company);
                StringListCompany = MC.Company.Select(x => x.CompName.ToString()).ToList();

                EmployeeTypeCollection = CollectionViewSource.GetDefaultView(MC.EmployeeTypeList);
                EmployeeTypeCollection.Filter = new Predicate<object>(FilterEmployeeType);
                StringListEmployeeType = MC.EmployeeTypeList.Select(x => x.empl_type_name.ToString()).ToList();
                DefaultValues();

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

        #endregion

        #region Open Image

        string imageName;
        private void OpenFile()
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif;*.png)|*.jpg;*.bmp;*.gif;*.png";
                fldlg.ShowDialog();
                {
                    imageName = fldlg.FileName;
                    MasterEntity.Photo = File.ReadAllBytes(imageName);
                }

                fldlg = null;
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
        private void OpenSignature()
        {
            try
            {
                FileDialog fldlg = new OpenFileDialog();
                fldlg.InitialDirectory = Environment.SpecialFolder.MyPictures.ToString();
                fldlg.Filter = "Image File (*.jpg;*.bmp;*.gif)|*.jpg;*.bmp;*.gif";
                fldlg.ShowDialog();
                {
                    imageName = fldlg.FileName;
                    MasterEntity.digi_sign = File.ReadAllBytes(imageName);
                }
                fldlg = null;
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
            img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Bmp);
            memoryStream.Seek(0, SeekOrigin.Begin);
            bitmapImage.StreamSource = memoryStream;
            bitmapImage.EndInit();

            return bitmapImage;
        }

        #endregion

        #region User defined Functions        
        private void LoadDocumentById(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                ADM_M024_P ParameterEntityObject = null;
                MasterEntity = new ADM_M024();

                if (((IEnumerable)ParameterObject).Cast<ADM_M024_P>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ADM_M024_P>().ToList()[0];
                    Request = "LoadDocumentById" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@!@!@" + ParameterEntityObject.EmpId;
                    //Request = "LoadDocumentById" + "!@" + ParameterEntityObject.EmpId + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.client;
                    SelectedTabControlIndex = 0;
                    blNew = false;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ADM_M024>(MCTemp, Request, "Employee_Master", "Administration", "LoadDocumentByDocumentNumber", 0, "");

                    if (MCTemp.Employees.Count > 0)
                    {
                        MasterEntity = MCTemp.Employees[0];
                    }
                    SalesEntity = MCTemp.SalesEntity;
                    PurchaseEntity = MCTemp.PurchaseEntity;
                    CustEntity = MCTemp.CustEntity;

                    //PartyCollection = CollectionViewSource.GetDefaultView(CustEntity);
                    //PartyCollection.Filter = new Predicate<object>(FilterParty);
                    //if (PartyCollection != null)
                    //{
                    //    List<ADM_M024_C> party = PartyCollection.SourceCollection.Cast<ADM_M024_C>().ToList();
                    //    foreach (var cur in party)
                    //    {
                    //        CustEntity.Add(cur);
                    //    }
                    //}              
                }
                if (MasterEntity.id != 0)
                {
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
        private void InsertCustomerForGrid(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;

                if (_filterStringParty != "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Clear the Text: " + _filterStringParty);
                    showMessageService.ShowMessage();
                }
                //Command Parameter Read section
                else
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            {
                                POPUPEntityObject = MC.Customers.Where(x => x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                    else if (InputValue != null)
                    {
                        if (((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                        {
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                        }

                    }

                    if (POPUPEntityObject != null)
                    {
                        if (MasterEntity.EmpId != null && MasterEntity.EmpId != " ")
                        {
                            var InputValueIfExists = CustEntity.Where(x => x.PartyId == POPUPEntityObject.PartyId).FirstOrDefault();
                            var IndexOfExistValue = CustEntity.IndexOf(CustEntity.Where(X => X.PartyId == POPUPEntityObject.PartyId).FirstOrDefault());

                            if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && CustEntity.Count == dgSelectedIndexItem)
                            {
                                CustEntity.Add(new ADM_M024_C()
                                {
                                    id = 0,
                                    active = true,
                                    PartyId = POPUPEntityObject.PartyId,
                                    PartyNm = POPUPEntityObject.PartyNm,
                                    Location = POPUPEntityObject.Location,
                                    grpNm = POPUPEntityObject.grpNm
                                });
                            }
                            else if (dgSelectedIndexItem >= 0 && CustEntity.Count > dgSelectedIndexItem)
                            {
                                if (CustEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                                {
                                    CustEntity[dgSelectedIndexItem].PartyId = POPUPEntityObject.PartyId;
                                    CustEntity[dgSelectedIndexItem].PartyNm = POPUPEntityObject.PartyNm;
                                    CustEntity[dgSelectedIndexItem].Location = POPUPEntityObject.Location;
                                    CustEntity[dgSelectedIndexItem].grpNm = POPUPEntityObject.grpNm;
                                    CustEntity[dgSelectedIndexItem].active = true;

                                }
                                else if (CustEntity[dgSelectedIndexItem].PartyId != POPUPEntityObject.PartyId)
                                {
                                    CustEntity[dgSelectedIndexItem].PartyId = POPUPEntityObject.PartyId;
                                    CustEntity[dgSelectedIndexItem].PartyNm = POPUPEntityObject.PartyNm;
                                    CustEntity[dgSelectedIndexItem].Location = POPUPEntityObject.Location;
                                    CustEntity[dgSelectedIndexItem].grpNm = POPUPEntityObject.grpNm;
                                }
                            }
                        }
                        else
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Required";
                            showMessageService.Text = String.Format("Please Enter Employee id...");
                            showMessageService.ShowMessage();
                        }
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
        private void InsertSalesGroup(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M001_H_P POPUPEntityObject = null;
                dgSelectedIndexSales = dgSelectedIndexSales;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MC.SalesGroup.Where(x => x.sg_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M001_H_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_H_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (MasterEntity.EmpId != null && MasterEntity.EmpId != " ")
                    {
                        var InputValueIfExists = SalesEntity.Where(X => X.sg_code == POPUPEntityObject.sg_code && X.so_code == POPUPEntityObject.so_code && X.location_Id == POPUPEntityObject.location_Id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                        int IndexOfExistValue = SalesEntity.IndexOf(SalesEntity.Where(X => X.sg_code == POPUPEntityObject.sg_code && X.so_code == POPUPEntityObject.so_code && X.location_Id == POPUPEntityObject.location_Id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                        if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && SalesEntity.Count == dgSelectedIndexSales)
                        {
                            SalesEntity.Add(new ADM_M024_A()
                            {
                                id = 0,
                                active = true,
                                sg_code = POPUPEntityObject.sg_code,
                                so_code = POPUPEntityObject.so_code,
                                comp_code = POPUPEntityObject.comp_code,
                                location_Id = POPUPEntityObject.location_Id,
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID

                            });
                        }
                        else if (dgSelectedIndexSales >= 0 && SalesEntity.Count > dgSelectedIndexSales) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                        {
                            if (SalesEntity[dgSelectedIndexSales].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                            {
                                SalesEntity[dgSelectedIndexSales].sg_code = POPUPEntityObject.sg_code;
                                SalesEntity[dgSelectedIndexSales].so_code = POPUPEntityObject.so_code;
                                SalesEntity[dgSelectedIndexSales].comp_code = POPUPEntityObject.comp_code;
                                SalesEntity[dgSelectedIndexSales].location_Id = POPUPEntityObject.location_Id;

                            }
                            else if (SalesEntity[dgSelectedIndexSales].sg_code != POPUPEntityObject.sg_code)
                            {
                                SalesEntity[dgSelectedIndexSales].sg_code = POPUPEntityObject.sg_code;
                                SalesEntity[dgSelectedIndexSales].so_code = POPUPEntityObject.so_code;
                                SalesEntity[dgSelectedIndexSales].comp_code = POPUPEntityObject.comp_code;
                                SalesEntity[dgSelectedIndexSales].location_Id = POPUPEntityObject.location_Id;

                            }
                        }
                    }

                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Please Enter Employee id...");
                        showMessageService.ShowMessage();
                    }
                }
                #region Clear Empty Row
                ADM_M024_A newObj = new ADM_M024_A();
                for (int i = SalesEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = SalesEntity[i].ComparePropertiesTo(newObj);
                    if (SalesEntity[i].ComparePropertiesTo(newObj) == true && SalesEntity.Count > 1)
                    {
                        SalesEntity.RemoveAt(i);
                        if (SalesEntity.Count == 0)
                        {
                            SalesEntity.Add(newObj);
                        }
                    }
                }
                #endregion
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
        private void InsertPurchaseGroup(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M001_P_P POPUPEntityObject = null;
                dgSelectedIndexPurchase = dgSelectedIndexPurchase;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MC.PurchaseGroup.Where(x => x.pg_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M001_P_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_P_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (MasterEntity.EmpId != null && MasterEntity.EmpId != " ")
                    {
                        var InputValueIfExists = PurchaseEntity.Where(X => X.pg_code == POPUPEntityObject.pg_code && X.po_code == POPUPEntityObject.po_code && X.location_Id == POPUPEntityObject.location_Id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                        int IndexOfExistValue = PurchaseEntity.IndexOf(PurchaseEntity.Where(X => X.pg_code == POPUPEntityObject.pg_code && X.po_code == POPUPEntityObject.po_code && X.location_Id == POPUPEntityObject.location_Id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                        if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && PurchaseEntity.Count == dgSelectedIndexPurchase)
                        {
                            PurchaseEntity.Add(new ADM_M024_B()
                            {
                                id = 0,
                                active = true,
                                pg_code = POPUPEntityObject.pg_code,
                                po_code = POPUPEntityObject.po_code,
                                comp_code = POPUPEntityObject.comp_code,
                                location_Id = POPUPEntityObject.location_Id,
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID

                            });
                        }
                        else if (dgSelectedIndexPurchase >= 0 && PurchaseEntity.Count > dgSelectedIndexPurchase) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                        {
                            if (PurchaseEntity[dgSelectedIndexPurchase].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                            {
                                PurchaseEntity[dgSelectedIndexPurchase].pg_code = POPUPEntityObject.pg_code;
                                PurchaseEntity[dgSelectedIndexPurchase].po_code = POPUPEntityObject.po_code;
                                PurchaseEntity[dgSelectedIndexPurchase].comp_code = POPUPEntityObject.comp_code;
                                PurchaseEntity[dgSelectedIndexPurchase].location_Id = POPUPEntityObject.location_Id;

                            }
                            else if (PurchaseEntity[dgSelectedIndexPurchase].pg_code != POPUPEntityObject.pg_code)
                            {
                                PurchaseEntity[dgSelectedIndexPurchase].pg_code = POPUPEntityObject.pg_code;
                                PurchaseEntity[dgSelectedIndexPurchase].po_code = POPUPEntityObject.po_code;
                                PurchaseEntity[dgSelectedIndexPurchase].comp_code = POPUPEntityObject.comp_code;
                                PurchaseEntity[dgSelectedIndexPurchase].location_Id = POPUPEntityObject.location_Id;

                            }
                        }
                    }

                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Please Enter Employee id...");
                        showMessageService.ShowMessage();
                    }
                }
                #region Clear Empty Row
                ADM_M024_B newObj = new ADM_M024_B();
                for (int i = PurchaseEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = PurchaseEntity[i].ComparePropertiesTo(newObj);
                    if (PurchaseEntity[i].ComparePropertiesTo(newObj) == true && PurchaseEntity.Count > 1)
                    {
                        PurchaseEntity.RemoveAt(i);
                        if (PurchaseEntity.Count == 0)
                        {
                            PurchaseEntity.Add(newObj);
                        }
                    }
                }
                #endregion
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
        private void DeleteDataGridRow_SalesEntity(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (SalesEntity.Count > i && SalesEntity[dgSelectedIndexSales].id == 0)
                {
                    SalesEntity.RemoveAt(i);
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
        private void DeleteDataGridRow_PurchaseEntity(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (PurchaseEntity.Count > i && PurchaseEntity[dgSelectedIndexPurchase].id == 0)
                {
                    PurchaseEntity.RemoveAt(i);
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
        private void DeleteDataGridRow_CustEntity(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (CustEntity.Count > i && CustEntity[dgSelectedIndexItem].id == 0)
                {
                    CustEntity.RemoveAt(i);
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
        private void DefaultValues()
        {
            MasterEntity.client = AppSessionState.client;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.active = true;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private void CollectionChangedNotifyForSales(object sender, NotifyCollectionChangedEventArgs e)
        {
            //////////////////////////////////Temp Test
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (ADM_M024_A item in e.NewItems)
                    item.PropertyChanged += this.MyType_PropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (ADM_M024_A item in e.OldItems)
                    item.PropertyChanged -= this.MyType_PropertyChanged;

            /////////////////////////////////Temp Test End
            //different kind of changes that may have occurred in collection
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (ADM_M024_A item in e.NewItems)
                {
                    //Added items
                    item.EmpId = MasterEntity.EmpId;
                    item.PropertyChanged += EntityViewModelPropertyChanged;
                }
            }
        }
        private void CollectionChangedNotifyForPurchase(object sender, NotifyCollectionChangedEventArgs e)
        {
            //////////////////////////////////Temp Test
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (ADM_M024_B item in e.NewItems)
                    item.PropertyChanged += this.MyType_PropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (ADM_M024_B item in e.OldItems)
                    item.PropertyChanged -= this.MyType_PropertyChanged;

            /////////////////////////////////Temp Test End
            //different kind of changes that may have occurred in collection
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (ADM_M024_B item in e.NewItems)
                {
                    //Added items
                    item.EmpId = MasterEntity.EmpId;
                    item.PropertyChanged += EntityViewModelPropertyChanged;
                }
            }
        }
        private void CollectionChangedNotifyForCust(object sender, NotifyCollectionChangedEventArgs e)
        {
            //////////////////////////////////Temp Test
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (ADM_M024_C item in e.NewItems)
                    item.PropertyChanged += this.MyType_PropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (ADM_M024_C item in e.OldItems)
                    item.PropertyChanged -= this.MyType_PropertyChanged;

            /////////////////////////////////Temp Test End
            //different kind of changes that may have occurred in collection
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (ADM_M024_C item in e.NewItems)
                {
                    //Added items
                    item.EmpId = MasterEntity.EmpId;
                    item.PropertyChanged += EntityViewModelPropertyChanged;
                }
            }
        }
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (CustEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = false; /*dgItemsEntity[dgSelectedIndexItem].HasErrors;*/
            }
            if (SalesEntity.Count > dgSelectedIndexSales && dgSelectedIndexSales >= 0)
            {
                this.ErrorExist = false; /*dgItemsEntity[dgSelectedIndexSales].HasErrors;*/
            }
            if (PurchaseEntity.Count > dgSelectedIndexPurchase && dgSelectedIndexPurchase >= 0)
            {
                this.ErrorExist = false; /*dgItemsEntity[dgSelectedIndexPurchase].HasErrors;*/
            }
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false;/*MasterEntity.HasErrors;*/
            if (CustEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = CustEntity[dgSelectedIndexItem].HasErrors;
            }
            if (SalesEntity.Count > dgSelectedIndexSales && dgSelectedIndexSales >= 0)
            {
                this.ErrorExist = SalesEntity[dgSelectedIndexSales].HasErrors;
            }
            if (PurchaseEntity.Count > dgSelectedIndexPurchase && dgSelectedIndexPurchase >= 0)
            {
                this.ErrorExist = PurchaseEntity[dgSelectedIndexPurchase].HasErrors;
            }
        }
        private void InsertLocation(object InputValue)
        {
            string Request = "";
            ADM_M003_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Locations.Where(x => x.LoctnNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M003_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.LoctnNm = POPUPEntityObject.LoctnNm;
                MasterEntity.location_Id = POPUPEntityObject.location_Id;
            }

        }
        private void InsertDepartment(object InputValue)
        {
            string Request = "";
            ADM_M025_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Departments.Where(x => x.DeptName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M025_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M025_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.DeptName = POPUPEntityObject.DeptName;
                MasterEntity.dept_code = POPUPEntityObject.dept_code;
            }

        }
        private void InsertDisignation(object InputValue)
        {
            string Request = "";
            ADM_M026_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MC.Disignations.Where(x => x.DesigName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M026_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M026_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.DesigName = POPUPEntityObject.DesigName;
                MasterEntity.desig_code = POPUPEntityObject.desig_code;
            }

        }
        private void InsertCompany(object InputValue)
        {
            string Request = "";
            ADM_M002_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Company.Where(x => x.CompName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M002_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }
            #endregion

            if (POPUPEntityObject != null)
            {
                MasterEntity.comp_code = POPUPEntityObject.comp_code;
                MasterEntity.CompName = POPUPEntityObject.CompName;


                if (POPUPEntityObject.comp_code != "" || POPUPEntityObject.comp_code != null)
                {
                    var abc = (from data in MC.Locations
                               where data.comp_code == POPUPEntityObject.comp_code
                               select data).ToList();

                    LocationCollection = CollectionViewSource.GetDefaultView(abc.ToList());
                    LocationCollection.Filter = new Predicate<object>(FilterLocation);
                    StringListLocation = MC.Locations.Select(x => x.LoctnNm).ToList();
                }

                else
                {
                    LocationCollection = CollectionViewSource.GetDefaultView(MC.Locations);
                    LocationCollection.Filter = new Predicate<object>(FilterLocation);
                    StringListLocation = MC.Locations.Select(x => x.LoctnNm).ToList();
                }
            }

        }
        private void InsertEmployeeType(object InputValue)
        {
            string Request = "";
            HRM_M004_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.EmployeeTypeList.Where(x => x.empl_type_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<HRM_M004_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<HRM_M004_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.emp_type = POPUPEntityObject.empl_type;
                MasterEntity.empl_type_name = POPUPEntityObject.empl_type_name;
            }

        }

        private void LoadBackFlipData(object InputValue)
        {
            try
            {
                //string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + RequestPara.location_Id + "!@" + (RequestPara.doc_cat ?? "SO") + "!@" + (Utilities.NullIf(RequestPara.doc_type_user) ?? "") + "!@" + (Utilities.NullIf(RequestPara.t_status) ?? "") + "!@" + RequestPara.active + "!@" + (Utilities.NullIf(RequestPara.EmpId) ?? AppSessionState.EmpId) + "!@" + Utilities.NullIf(RequestPara.PartyId) + "!@" + AppSessionState.so_code + "!@" + AppSessionState.sg_code + "!@" + Convert.ToDateTime(RequestPara.FromDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(RequestPara.ToDate).ToString("MM/dd/yyyy") + "!@" + AppSessionState.UserID + "!@" + MasterEntity.ts_code;
                string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + RequestPara.From + "!@" + RequestPara.To + "!@" + RequestPara.active;
                MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_SEL_T001>(MCTemp, Request, "Employee_Master", "Administration", "LoadAll", 0, "");


                FlipGridData = MCTemp.DocumentDataFlipGrid.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
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
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            if (sender.ToString() == "comp_code")
            {
                SetSOCompany();
            }
        }
        private void SetSOCompany()
        {
            try
            {
                if (MasterEntity.comp_code != null && MC.SalesGroup != null && MC.PurchaseGroup != null)
                {
                    SalesGroupCollection = CollectionViewSource.GetDefaultView(MC.SalesGroup.Where(x => x.comp_code == MasterEntity.comp_code).ToList());
                    SalesGroupCollection.Filter = new Predicate<object>(Filter_Sales);
                    StringListSalesGroup = MC.SalesGroup.Where(x => x.comp_code == MasterEntity.comp_code).Select(x => x.sg_code.ToString()).ToList();

                    PurchaseGroupCollection = CollectionViewSource.GetDefaultView(MC.PurchaseGroup.Where(x => x.comp_code == MasterEntity.comp_code).ToList());
                    PurchaseGroupCollection.Filter = new Predicate<object>(Filter_Purchase);
                    StringListPurchaseGroup = MC.PurchaseGroup.Where(x => x.comp_code == MasterEntity.comp_code).Select(x => x.pg_code.ToString()).ToList();
                }
            }
            catch (Exception ex) { }
        }


        #endregion

        #region Methods
        //public event PropertyChangedEventHandler PropertyChanged;
        //public void RaisePropertyChanged(string propertyName)
        //{
        //    // take a copy to prevent thread issues
        //    PropertyChangedEventHandler handler = PropertyChanged;
        //    if (handler != null)
        //    {
        //        handler(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}
        #endregion

        #region Abstract Command Actions
        private bool Validation()
        {
            try
            {
                if (MasterEntity.EmpId == null || MasterEntity.EmpId == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Employee Id Is Required", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.EmpFName == null || MasterEntity.EmpFName == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Please Enter Employee Name...", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.EmpLName == null || MasterEntity.EmpLName == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Please Enter Employee Last Name...", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }
                if (MasterEntity.location_Id == null || MasterEntity.location_Id == "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Please Enter Plant...", this.Title);
                    showMessageService.ShowMessage();
                    return false;
                }

                // Validation for Customer Details
                //foreach (var o in CustEntity)
                //{
                //    int flag = 0;
                //    if (o.id == 0 && o.active == true)
                //    {
                //        foreach (var p in CustEntity)
                //        {
                //            if (o.PartyId == p.PartyId)
                //            {
                //                flag++;
                //            }
                //        }
                //        if (flag > 1)
                //        {
                //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //            showMessageService.ButtonSetup = DialogButton.Ok;
                //            showMessageService.Caption = "Message";
                //            showMessageService.Text = String.Format("Cannot Save Duplicate Customer {0} ", o.PartyNm);
                //            showMessageService.ShowMessage();
                //            return false;
                //        }
                //    }
                //}                       
            }
            catch (Exception ex)
            {

            }
            return true;
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.XmlDataDocument_ADM_M024_A != null)
                {
                    SalesEntity.Clear();
                    SalesEntity = (ObservableCollection<ADM_M024_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ADM_M024_A, MC.SalesEntity);
                    MasterEntity = MasterEntity;
                }
                else
                {
                    SalesEntity = new ObservableCollection<ADM_M024_A>();
                }
                if (MasterEntity.XmlDataDocument_ADM_M024_B != null)
                {
                    PurchaseEntity.Clear();
                    PurchaseEntity = (ObservableCollection<ADM_M024_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ADM_M024_B, MC.PurchaseEntity);
                    MasterEntity = MasterEntity;
                }
                else
                {
                    PurchaseEntity = new ObservableCollection<ADM_M024_B>();
                }
                if (MasterEntity.XmlDataDocument_ADM_M024_C != null)
                {
                    CustEntity.Clear();
                    CustEntity = (ObservableCollection<ADM_M024_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ADM_M024_C, MC.CustEntity);
                    MasterEntity = MasterEntity;
                }
                else
                {
                    CustEntity = new ObservableCollection<ADM_M024_C>();
                }
                if (MasterEntity.XmlDataDocument_ADM_M024BackFlip != null && blNew == true && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<ADM_M024_P>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ADM_M024BackFlip, MC.DocumentDataFlipGrid);
                    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                    DataGridCollection.Refresh();
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
        protected override void OnSaveAction(InquiryActionResult<ADM_M024> result)
        {
            try
            {
                if (Validation() == true)
                {
                    // DefaultValues();
                    this.MasterEntity.EndEdit();


                    ObjectSerializationService obj = new ObjectSerializationService();
                    MasterEntity.XmlDataDocument_ADM_M024_A = obj.ObjectToXML(SalesEntity);
                    MasterEntity.XmlDataDocument_ADM_M024_B = obj.ObjectToXML(PurchaseEntity);
                    MasterEntity.XmlDataDocument_ADM_M024_C = obj.ObjectToXML(CustEntity);

                    if (blNew == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ADM_M024>(MasterEntity, "Employee_Master", "Administration");
                    }
                    else if (blNew == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ADM_M024>(MasterEntity, "Employee_Master", "Administration");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");

                    if (MasterEntity.id != 0 && blNew == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Updated Successfully");
                        showMessageService.ShowMessage();
                    }
                    if (MasterEntity.id != 0 && blNew == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();
                        blNew = false;
                    }
                    FilterStringParty = "";
                    _filterStringParty = "";
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

        //protected override void OnExportAction(InquiryActionResult<ADM_M024> result)
        //{
        //    try
        //    {
        //        ExportToExcel<ADM_M024, List<ADM_M024>> export = new ExportToExcel<ADM_M024, List<ADM_M024>>();
        //        ICollectionView view = CollectionViewSource.GetDefaultView(DataGridCollection);
        //        export.dataToPrint = (List<ADM_M024>)view.SourceCollection;
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
        protected override void OnCreateAction(InquiryActionResult<ADM_M024> result)
        {
            MasterEntity = new ADM_M024();
            SalesEntity = new ObservableCollection<ADM_M024_A>();
            PurchaseEntity = new ObservableCollection<ADM_M024_B>();
            CustEntity = new ObservableCollection<ADM_M024_C>();
            blNew = true;
            MasterEntity.ValidateAsync().Wait();
            _dataGridCollection.Refresh();
            DefaultValues();
            FilterStringParty = "";
            _filterStringParty = "";

        }
        protected override void OnRemoveAction(InquiryActionResult<ADM_M024> result)
        {
            try
            {
                if (MasterEntity.EmpId != null)
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Save Changes";
                    showMessageService.Text =
                        String.Format(
                            "This record will delete forever '{0}'",
                                this.Title);

                    if (showMessageService.ShowMessage() == DialogResult.Ok)
                    {
                        this.MasterEntity.CancelEdit();
                        string response = repository.Delete(MasterEntity.EmpId, "Employee_Master", "Administration");
                        _dataGridCollection.Refresh();
                        MasterEntity = new ADM_M024();
                        blNew = true;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        protected override void OnDiscardAction(InquiryActionResult<ADM_M024> result)
        {
        }
        protected override void OnFevoriteAction(InquiryActionResult<ADM_M024> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ADM_M024> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ADM_M024> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ADM_M024> result)
        {
            try
            {
                //string Request = "Party_Report" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                string Request = "Employee_Report" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.EmpId;

                //MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ADM_M024>(MCTemp, Request, "PartyMaster", "Administration", "", 0, "");
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ADM_M024>(MCTemp, Request, "Employee_Master", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                object[] objDataSource = new object[3];
                string[] objDataSourceName = new string[3];



                objDataSource[0] = MCTemp.Employees;

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[1] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[2] = Result;



                objDataSourceName[0] = "dsEmp";
                objDataSourceName[1] = "dsCompany";
                objDataSourceName[2] = "dsLocation";


                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Admin\\EmployeeDocument.rdlc", getParametersList(), "");
            }
            catch (Exception ex) { }
        }
        private void ExportCommandPrint()
        {
            try
            {
                //string Request = "Party_Report" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                // string Request = AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id;

                //MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ADM_M024>(MCTemp, Request, "PartyMaster", "Administration", "", 0, "");
                // MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ADM_M024>(MCTemp, Request, "Employee_Master", "Administration", "LoadDocumentByDocumentNumber", 0, "");


                object[] objDataSource = new object[3];
                string[] objDataSourceName = new string[3];

                objDataSource[0] = MCTemp.DocumentDataFlipGrid;

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[1] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[2] = Result;



                objDataSourceName[0] = "dsEmp";
                objDataSourceName[1] = "dsCompany";
                objDataSourceName[2] = "dsLocation";


                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Admin\\EmployeeReport.rdlc", getParametersList(), "");
            }
            catch (Exception ex) { }
        }
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.EmpId.ToString()))
            {
                //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.EmpId.ToString().Replace("/", "--"), DocumentList = MCTemp.AttachmentList, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<ADM_M024> result)
        {

        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ADM_M024> result)
        {

        }

        protected override void OnValidateCommand(InquiryActionResult<ADM_M024> result)
        {

        }

        protected override void OnTraceCommand(InquiryActionResult<ADM_M024> result)
        {

        }

        protected override void OnMailCommand(InquiryActionResult<ADM_M024> result)
        {

        }
        #endregion

        #region Filters

        #region Filters for CustEntity(Observable Collection)

        private string _filterStringParty = "";
        public string FilterStringParty
        {
            get { return _filterStringParty; }
            set
            {
                _filterStringParty = value;
                RaisePropertyChanged("FilterStringParty");
                //PartyCollection = CollectionViewSource.GetDefaultView(CustEntity);
                //PartyCollection.Filter = new Predicate<object>(FilterParty);
                FilterCollectionParty();
            }
        }
        private void FilterCollectionParty()
        {
            try
            {
                PartyCollection = CollectionViewSource.GetDefaultView(CustEntity);
                PartyCollection.Filter = new Predicate<object>(FilterParty);
                if (_PartyCollection != null)
                {
                    _PartyCollection.Refresh();
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
        public bool FilterParty(object obj)
        {
            var data = obj as ADM_M024_C;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringParty))
                {
                    return (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterStringParty.ToString().ToLower()) ||
                           (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterStringParty.ToString().ToLower())) ||
                           (data.Location != null && data.Location.ToString().ToLower().Contains(_filterStringParty.ToString().ToLower())) ||
                           (data.grpNm != null && data.grpNm.ToString().ToLower().Contains(_filterStringParty.ToString().ToLower())));
                }
                return true;
            }
            return false;
        }

        private ICollectionView _PartyCollection;
        public ICollectionView PartyCollection
        {
            get { return _PartyCollection; }
            set
            {
                _PartyCollection = value;
                RaisePropertyChanged("PartyCollection");
            }
        }


        #endregion

        #region Filter Location
        private string _filterStringLocation;
        public bool FilterLocation(object obj)
        {
            var data = obj as ADM_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringLocation))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterStringLocation.ToString().ToLower()) ||
                           (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterStringLocation.ToString().ToLower())));
                }
                return true;
            }
            return false;
        }
        public string FilterStringLocation
        {
            get { return _filterStringLocation; }
            set
            {
                _filterStringLocation = value;
                RaisePropertyChanged("FilterStringLocation");
                FilterCollectionLocation();
            }
        }
        private void FilterCollectionLocation()
        {
            if (_LocationCollection != null)
            {
                _LocationCollection.Refresh();
            }
        }

        #endregion

        #region Filter Department
        private string _filterStringDepartment;
        public bool FilterDepartment(object obj)
        {
            var data = obj as ADM_M025_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringDepartment))
                {
                    return (data.dept_code != null && data.dept_code.ToString().ToLower().Contains(_filterStringDepartment.ToString().ToLower()) ||
                            data.DeptName != null && data.DeptName.ToString().ToLower().Contains(_filterStringDepartment.ToLower()));
                }
                return true;
            }
            return false;
        }
        public string FilterStringDepartment
        {
            get { return _filterStringDepartment; }
            set
            {
                _filterStringDepartment = value;
                RaisePropertyChanged("FilterStringDepartment");
                FilterCollectionDepartment();
            }
        }
        private void FilterCollectionDepartment()
        {
            if (_DepartmentCollection != null)
            {
                _DepartmentCollection.Refresh();
            }
        }
        #endregion

        #region Filter Disignation
        private string _filterStringDisignation;
        public bool FilterDisignation(object obj)
        {
            var data = obj as ADM_M026_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringDisignation))
                {
                    return (data.desig_code != null && data.desig_code.ToString().ToLower().Contains(_filterStringDisignation.ToString().ToLower()) ||
                           (data.DesigName != null && data.DesigName.ToString().ToLower().Contains(_filterStringDisignation.ToString().ToLower())));
                }
                return true;
            }
            return false;
        }
        public string FilterStringDisignation
        {
            get { return _filterStringDisignation; }
            set
            {
                _filterStringDisignation = value;
                RaisePropertyChanged("FilterStringDisignation");
                FilterCollectionDisignation();
            }
        }
        private void FilterCollectionDisignation()
        {
            if (_DisignationCollection != null)
            {
                _DisignationCollection.Refresh();
            }
        }
        #endregion

        #region Filter for Customer

        private string _FilterStringCustomer;
        public string FilterStringCustomer
        {
            get { return _FilterStringCustomer; }
            set
            {
                _FilterStringCustomer = value;
                RaisePropertyChanged("FilterStringCustomer");
                Filter_Customer();
            }
        }
        private void Filter_Customer()
        {
            if (_CustomerCollection != null)
            {
                _CustomerCollection.Refresh();
            }
        }
        public bool Filter_Customer(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringCustomer))
                {
                    return ((data.PartyId != null) && data.PartyId.ToLower().Contains(_FilterStringCustomer.ToLower())) ||
                        ((data.PartyNm != null) && data.PartyNm.ToLower().Contains(_FilterStringCustomer.ToLower())) ||
                        ((data.Location != null) && data.Location.ToLower().Contains(_FilterStringCustomer.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filter Employee Type
        private string _filterStringEmployeeType;
        public bool FilterEmployeeType(object obj)
        {
            var data = obj as HRM_M004_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringEmployeeType))
                {
                    return (data.empl_type != null && data.empl_type.ToString().ToLower().Contains(_filterStringEmployeeType.ToString().ToLower()) ||
                            data.empl_type_name != null && data.empl_type_name.ToString().ToLower().Contains(_filterStringEmployeeType.ToLower()));
                }
                return true;
            }
            return false;
        }
        public string FilterStringEmployeeType
        {
            get { return _filterStringEmployeeType; }
            set
            {
                _filterStringEmployeeType = value;
                RaisePropertyChanged("FilterStringEmployeeType");
                FilterCollectionEmployeeType();
            }
        }
        private void FilterCollectionEmployeeType()
        {
            if (_EmployeeTypeCollection != null)
            {
                _EmployeeTypeCollection.Refresh();
            }
        }
        #endregion

        #region Filter for sales

        private string _FilterStringSales;
        public string FilterStringSales
        {
            get { return _FilterStringSales; }
            set
            {
                _FilterStringSales = value;
                RaisePropertyChanged("FilterStringSales");
                FilterCollectionSales();
            }
        }
        private void FilterCollectionSales()
        {
            if (_SalesGroupCollection != null)
            {
                _SalesGroupCollection.Refresh();
            }
        }
        public bool Filter_Sales(object obj)
        {
            var data = obj as ADM_M001_H_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringSales))
                {
                    return ((data.sg_name != null) && data.sg_name.ToLower().Contains(_FilterStringSales.ToLower())) ||
                        ((data.so_code != null) && data.so_code.ToLower().Contains(_FilterStringSales.ToLower())) ||
                        ((data.sg_code != null) && data.sg_code.ToLower().Contains(_FilterStringSales.ToLower())) ||
                        ((data.comp_code != null) && data.comp_code.ToLower().Contains(_FilterStringSales.ToLower())
                        );

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filter for Purchase

        private string _FilterStringPurchase;
        public string FilterStringPurchase
        {
            get { return _FilterStringPurchase; }
            set
            {
                _FilterStringPurchase = value;
                RaisePropertyChanged("FilterStringPurchase");
                FilterCollectionPurchase();
            }
        }
        private void FilterCollectionPurchase()
        {
            if (_PurchaseGroupCollection != null)
            {
                _PurchaseGroupCollection.Refresh();
            }
        }
        public bool Filter_Purchase(object obj)
        {
            var data = obj as ADM_M001_P_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringPurchase))
                {
                    return ((data.pg_name != null) && data.pg_name.ToLower().Contains(_FilterStringPurchase.ToLower())) ||
                        ((data.po_code != null) && data.po_code.ToLower().Contains(_FilterStringPurchase.ToLower())) ||
                        ((data.pg_code != null) && data.pg_code.ToLower().Contains(_FilterStringPurchase.ToLower())) ||
                        ((data.comp_code != null) && data.comp_code.ToLower().Contains(_FilterStringPurchase.ToLower())) ||
                        ((data.LoctnNm != null) && data.LoctnNm.ToLower().Contains(_FilterStringPurchase.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filter String
        private string _filterString;
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
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterString.ToString().ToLower())) ||
                        (data.EmpFName != null && data.EmpFName.ToString().ToLower().Contains(_filterString.ToString().ToLower())) ||
                        (data.EmpLName != null && data.EmpLName.ToString().ToLower().Contains(_filterString.ToString().ToLower())) ||
                        (data.EmpMobNo != null && data.EmpMobNo.ToString().ToLower().Contains(_filterString.ToString().ToLower())) ||
                        (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString.ToString().ToLower())) ||
                        (data.DeptName != null && data.DeptName.ToString().ToLower().Contains(_filterString.ToString().ToLower()));


                }
                return true;
            }
            return false;
        }
        #endregion
        #region Filter Location
        private string _filterStringCompany;
        public bool Filter_Company(object obj)
        {
            var data = obj as ADM_M002_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringCompany))
                {
                    return (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterStringCompany.ToString().ToLower()) ||
                           (data.CompName != null && data.CompName.ToString().ToLower().Contains(_filterStringCompany.ToString().ToLower())));
                }
                return true;
            }
            return false;
        }
        public string FilterStringCompany
        {
            get { return _filterStringCompany; }
            set
            {
                _filterStringCompany = value;
                RaisePropertyChanged("FilterStringCompany");
                FilterCollectionCompany();
            }
        }
        private void FilterCollectionCompany()
        {
            if (_CompanyCollection != null)
            {
                _CompanyCollection.Refresh();
            }
        }



        #endregion

        #endregion
    }
}
