using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Reflection.ReportingServices;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class CRM_T004_VM : WorkspaceViewModel<CRM_T004>
    {
        #region Variable Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        bool isNewRecord = true;
        WebServiceRepository<CRM_T004> repository = new WebServiceRepository<CRM_T004>();
        WebServiceRepository<MultipleContext_CRM_T004> repository_MC = new WebServiceRepository<MultipleContext_CRM_T004>();
        WebServiceRepository<MultipleContext_CRM_T004> repository_MCTemp = new WebServiceRepository<MultipleContext_CRM_T004>();

        ObjectSerializationService obj = new ObjectSerializationService();

        private CRM_T004 _MasterEntity;
        public CRM_T004 MasterEntity
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
                    RaisePropertyChanged(nameof(MasterEntity));
                    value.BeginEdit();
                }
            }
        }

        private CRM_T004 _MasterEntityTemp;
        public CRM_T004 MasterEntityTemp
        {
            get
            {
                return _MasterEntityTemp;
            }
            set
            {
                if (_MasterEntityTemp != value)
                {
                    _MasterEntityTemp = value;
                    RaisePropertyChanged("MasterEntityTemp");
                    value.BeginEdit();
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

        MultipleContext_CRM_T004 _MC = new MultipleContext_CRM_T004();
        public MultipleContext_CRM_T004 MC
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

        MultipleContext_CRM_T004 _MCTemp = new MultipleContext_CRM_T004();
        public MultipleContext_CRM_T004 MCTemp
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

        private ObservableCollection<CRM_T004_A> _ItemsEntity;
        public ObservableCollection<CRM_T004_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value;
                    RaisePropertyChanged("ItemsEntity");
                }
            }
        }

        NumberToEnglish num = new NumberToEnglish();

        private List<CRM_T004_Flip> _FlipGridData;
        public List<CRM_T004_Flip> FlipGridData
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

        private List<COM_T003> _AttachmentCollection;
        public List<COM_T003> AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set { _AttachmentCollection = value; RaisePropertyChanged("AttachmentCollection"); }
        }

        public List<ADM_M001_A_P> _SalesOrganisationList;
        public List<ADM_M001_A_P> SalesOrganisationList
        {
            get
            {
                return _SalesOrganisationList;
            }
            set
            {
                _SalesOrganisationList = value;
                RaisePropertyChanged("SalesOrganisationList");
            }
        }

        public List<ADM_M001_H_P> _SalesGroupList;
        public List<ADM_M001_H_P> SalesGroupList
        {
            get
            {
                return _SalesGroupList;
            }
            set
            {
                _SalesGroupList = value;
                RaisePropertyChanged("SalesGroupList");
            }
        }
        public List<ADM_M003> _ObjPlant = new List<ADM_M003>();
        private List<ADM_M003> ObjPlant
        {
            get { return _ObjPlant; }
            set
            {
                if (_ObjPlant != value)
                {
                    _ObjPlant = value;
                }
            }
        }
        public List<ADM_M002> _ObjCompany = new List<ADM_M002>();
        private List<ADM_M002> ObjCompany
        {
            get { return _ObjCompany; }
            set
            {
                if (_ObjCompany != value)
                {
                    _ObjCompany = value;
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
        #endregion

        #region ICollection
        private ICollectionView _flipDataGridCollection;// BF COllection
        public ICollectionView FlipDataGridCollection
        {
            get { return _flipDataGridCollection; }
            set { _flipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }

        private ICollectionView _plantCollection;
        public ICollectionView PlantCollection
        {
            get { return _plantCollection; }
            set { _plantCollection = value; RaisePropertyChanged("PlantCollection"); }
        }
        private ICollectionView _companyCollection;
        public ICollectionView CompanyCollection
        {
            get { return _companyCollection; }
            set { _companyCollection = value; RaisePropertyChanged("CompanyCollection"); }
        }
        private ICollectionView _CustomerCollection;
        public ICollectionView CustomerCollection
        {
            get { return _CustomerCollection; }
            set { _CustomerCollection = value; RaisePropertyChanged("CustomerCollection"); }
        }
        private ICollectionView _partyTypeCollection;
        public ICollectionView PartyTypeCollection
        {
            get { return _partyTypeCollection; }
            set { _partyTypeCollection = value; RaisePropertyChanged("PartyTypeCollection"); }
        }
        private ICollectionView _EmpCollection;
        public ICollectionView EmpCollection
        {
            get { return _EmpCollection; }
            set { _EmpCollection = value; RaisePropertyChanged("EmpCollection"); }
        }
        private ICollectionView _monthYearCollection;
        public ICollectionView MonthYearCollection
        {
            get { return _monthYearCollection; }
            set { _monthYearCollection = value; RaisePropertyChanged("MonthYearCollection"); }
        }
        private ICollectionView _UomCollectionForDataDrid;
        public ICollectionView UomCollectionForDataDrid
        {
            get { return _UomCollectionForDataDrid; }
            set { _UomCollectionForDataDrid = value; RaisePropertyChanged("UomCollectionForDataDrid"); }
        }
        private ICollectionView _sales_orgCollection;
        public ICollectionView Salse_OrgCollection
        {
            get { return _sales_orgCollection; }
            set
            {
                _sales_orgCollection = value;
                RaisePropertyChanged("Salse_OrgCollection");
            }
        }

        private ICollectionView _salse_GroupCollection;
        public ICollectionView Salse_GroupCollection
        {
            get { return _salse_GroupCollection; }
            set
            {
                _salse_GroupCollection = value;
                RaisePropertyChanged("Salse_GroupCollection");
            }
        }
        #endregion

        #region StringList
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
        List<string> _StringListEmp;
        public List<string> StringListEmp
        {
            get { return _StringListEmp; }
            set
            {
                if (_StringListEmp != value)
                {
                    _StringListEmp = value;
                }
            }
        }

        List<string> _StringListPlant;
        public List<string> StringListPlant
        {
            get { return _StringListPlant; }
            set
            {
                if (_StringListPlant != value)
                {
                    _StringListPlant = value;
                }
            }
        }

        List<string> _StringListCompany;
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
        List<string> _StringListUom;
        public List<string> StringListUom
        {
            get { return _StringListUom; }
            set
            {
                if (_StringListUom != value)
                {
                    _StringListUom = value;
                }
            }
        }

        List<string> _StringListPartyType;
        public List<string> StringListPartyType
        {
            get { return _StringListPartyType; }
            set
            {
                if (_StringListPartyType != value)
                {
                    _StringListPartyType = value;
                }
            }
        }
        List<string> _StringListMonthYear;
        public List<string> StringListMonthYear
        {
            get { return _StringListMonthYear; }
            set
            {
                if (_StringListMonthYear != value)
                {
                    _StringListMonthYear = value;
                }
            }
        }
        private List<string> _strListSalesOrg;
        public List<string> StringListSalesOrg
        {
            get { return _strListSalesOrg; }
            set
            {
                if (_strListSalesOrg != value)
                {
                    _strListSalesOrg = value;
                }
            }
        }

        private List<string> _strListSalesGroup;
        public List<string> StringListSalesGroup
        {
            get { return _strListSalesGroup; }
            set
            {
                if (_strListSalesGroup != value)
                {
                    _strListSalesGroup = value;
                }
            }
        }
        #endregion

        #region Relay Command

        public RelayCommand<object> CmdAddCustomerForGrid { get; private set; }
        public RelayCommand<object> CmdAddEmp { get; private set; }
        public RelayCommand<object> CmdAddPartyType { get; private set; }
        public RelayCommand<object> CmdAddPlant { get; private set; }
        public RelayCommand<object> CmdAddCompany { get; private set; }
        public RelayCommand<object> CmdAddUomForGrid { get; private set; }
        public RelayCommand<object> CmdAddMonthYear { get; private set; }
        public RelayCommand<object> CommandSalseOrg { get; private set; }
        public RelayCommand<object> CommandSalseGroup { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocumentNo { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand CommandForLoad { get; private set; }
        public RelayCommand<object> CmdSelectWeek { get; private set; }
        #endregion

        #region Construtor
        public CRM_T004_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new CRM_T004();
            ItemsEntity = new ObservableCollection<CRM_T004_A>();
            FlipGridData = new List<CRM_T004_Flip>();
            MC = new MultipleContext_CRM_T004();
            MCTemp = new MultipleContext_CRM_T004();
            MasterEntity.ValidateAsync().Wait();
            CRM_T004_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);

            CmdAddEmp = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmp(items); });
            CmdAddCustomerForGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCustomerForGrid(cmdPara, true, true, true); });
            CmdAddPartyType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPartyType(cmdPara, true, true, true); });
            CmdAddPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
            CmdAddCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
            CmdAddUomForGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUnitForGrid(cmdPara, true, true, true); });
            CmdAddMonthYear = new RelayCommand<object>(items => { if (items == null) { return; } InsertMonthYear(items); });
            CommandSalseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseOrg(items); });
            CommandSalseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseGroup(items); });
            CmdLoadDocumentByDocumentNo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
            CmdDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
            CommandForLoad = new RelayCommand(() => { Load(); });
            CmdSelectWeek = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWeek(cmdPara, true, true, true); });
            LoadInitialData();
            
        }
        #endregion

        #region Event Handler

        void ModelUpdated_Item(object sender, EventArgs e)
        {
            if (ItemsEntity.Count > dgSelectedIndexItem)
            {
                //This will get called when the property of an object inside the collection changes
                //this.ErrorExist = MasterEntity.HasErrors; 
                if (sender.ToString() == "value1" || sender.ToString() == "active")
                {
                    if (dgSelectedIndexItem != -1)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].value1 > 0)
                        {
                            ItemsEntity[dgSelectedIndexItem].value2 = num.AmountInWords(Convert.ToDecimal(ItemsEntity[dgSelectedIndexItem].value1));
                        }
                        else
                        {
                            ItemsEntity[dgSelectedIndexItem].value2 = "";
                        }
                    }
                }
               
            }
            this.ErrorExist = false;/*MasterEntity.HasErrors;*/
            if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = ItemsEntity[dgSelectedIndexItem].HasErrors;
            }
        }
        #endregion

        #region LoadInitialData
        private void LoadInitialData()
        {
            try
            {
                MasterEntity.doc_cat = "CO";
                MasterEntity.doc_type = "CO";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type+"!@"+AppSessionState.so_code +"!@"+ AppSessionState.sg_code + "!@" + AppSessionState.EmpId;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_CRM_T004>(MC, Request, "Closure", "CRM", " ", 0, "");

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

                CustomerCollection = CollectionViewSource.GetDefaultView(MC.PartyDetails);
                CustomerCollection.Filter = new Predicate<object>(Filter_Customer);
                StringListCustomer = MC.PartyDetails.Select(x => x.bill_doc.ToString()).ToList();

                EmpCollection = CollectionViewSource.GetDefaultView(MC.EmpDetails);
                EmpCollection.Filter = new Predicate<object>(Filter_Emp);
                StringListEmp = MC.EmpDetails.Select(x => x.EmpId.ToString()).ToList();

                PartyTypeCollection = CollectionViewSource.GetDefaultView(MC.PartyType);
                PartyTypeCollection.Filter = new Predicate<object>(Filter_PartyType);
                StringListPartyType = MC.PartyType.Select(x => x.PartyType.ToString()).ToList();

                UomCollectionForDataDrid = CollectionViewSource.GetDefaultView(MC.UomDetails);
                UomCollectionForDataDrid.Filter = new Predicate<object>(Filter_Uom);
                StringListUom = MC.UomDetails.Select(x => x.unit_code.ToString()).ToList();

                MonthYearCollection = CollectionViewSource.GetDefaultView(MC.MonthAndYear);
                MonthYearCollection.SortDescriptions.Add(new SortDescription("calender_year", ListSortDirection.Descending));
                MonthYearCollection.Filter = new Predicate<object>(Filter_MonthYear);
                StringListMonthYear = MC.MonthAndYear.Select(x => x.short_desc.ToString()).ToList();

                ObjPlant = (List<ADM_M003>)AppSessionState.ADM_M003_List;

                PlantCollection = CollectionViewSource.GetDefaultView(ObjPlant.ToList());
                PlantCollection.Filter = new Predicate<object>(Filter_Plant);
                StringListPlant = ObjPlant.Select(x => x.location_Id).ToList();


                ObjCompany = (List<ADM_M002>)AppSessionState.ADM_M002_List;

                CompanyCollection = CollectionViewSource.GetDefaultView(ObjCompany.ToList());
                CompanyCollection.Filter = new Predicate<object>(Filter_Company);
                StringListCompany = ObjCompany.Select(x => x.comp_code).ToList();

                if (ObjCompany.Count != 0)
                {
                    if (ObjCompany.Count == 1)
                    {
                        MasterEntity.company = ObjCompany[0].comp_code;
                        MasterEntity.CompanyNm= ObjCompany[0].CompName;
                    }
                }
                else
                {
                    MasterEntity.so_code = "";
                }
                SalesOrganisationList = (List<ADM_M001_A_P>)AppSessionState.ADM_M001_A_List;
                Salse_OrgCollection = CollectionViewSource.GetDefaultView(SalesOrganisationList);
                Salse_OrgCollection.Filter = new Predicate<object>(Filter_SalesOrg);
                StringListSalesOrg = SalesOrganisationList.Select(x => x.so_code).ToList();
                if (SalesOrganisationList.Count != 0)
                {
                    if (SalesOrganisationList.Count == 1)
                    {
                        MasterEntity.so_code = SalesOrganisationList[0].so_code;
                        MasterEntity.sales_org = SalesOrganisationList[0].sales_org;
                    }
                }
                else
                {
                    MasterEntity.so_code = "";
                }
                SalesGroupList = (List<ADM_M001_H_P>)AppSessionState.ADM_M001_H_List;
                Salse_GroupCollection = CollectionViewSource.GetDefaultView(SalesGroupList);
                Salse_GroupCollection.Filter = new Predicate<object>(Filter_SalesGroup);
                StringListSalesGroup = SalesGroupList.Select(x => x.sg_code).ToList();

                if (SalesGroupList.Count != 0)
                {
                    if (SalesGroupList.Count == 1)
                    {
                        MasterEntity.sg_code = SalesGroupList[0].sg_code;
                        MasterEntity.sg_name = SalesGroupList[0].sg_name;
                    }
                }
                else
                {
                    MasterEntity.sg_code = "";
                }

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

        #region USerDefineFunction   
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_cat = "CO";
            MasterEntity.doc_type = "CO";
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.EmpId = AppSessionState.EmpId;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.t_status = "Open";
            MasterEntity.doc_no = "";
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.active = true;
            MasterEntity.client = AppSessionState.client;
        }
        private bool Validation()
        {
            if (ItemsEntity.Count < 1)
            {

                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Atleast One Record.");
                showMessageService.ShowMessage();
                return false;
            }
        
            if (MasterEntity.EmpId == null || MasterEntity.EmpId == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Sales Person Is Required", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.location_Id == null || MasterEntity.location_Id == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Location Id Is Required", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.comp_code == null || MasterEntity.comp_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Company Code Is Required", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            
            if (MasterEntity.t_status == null || MasterEntity.t_status == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Status Field Is Required", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.so_code == null || MasterEntity.so_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("So Code Is Required", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.sg_code == null || MasterEntity.sg_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("SG Code Is Required", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            if (dgSelectedIndexItem != -1)
            {
                foreach (var o in ItemsEntity)
                {
                    if (o.PartyId == null || o.PartyId == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Party ID Is Required", this.Title);
                        showMessageService.ShowMessage();
                        return false;
                    }
                    if (o.t_status == null || o.t_status == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Status Is Required", this.Title);
                        showMessageService.ShowMessage();
                        return false;
                    }
                    if (o.week_no == null )
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Week no Is Required", this.Title);
                        showMessageService.ShowMessage();
                        return false;
                    }
                    if ((o.project_name == null || o.project_name=="") && (o.site_location==null || o.site_location==""))
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Please Select Project Name & Project Location In Sales Inquiry", this.Title);
                        showMessageService.ShowMessage();
                        return false;
                    }
                    
                }
            }
            if (dgSelectedIndexItem != -1)
            {
                for (int j = ItemsEntity.Count - 1; j >= 0; j--)
                {
                    if (Convert.ToInt32(ItemsEntity[j].week_no) > 5)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Week Can not be Greater Than Five...");
                        showMessageService.ShowMessage();
                        ItemsEntity[j].week_no = null;
                        return false;
                    }
                }
            }
            return true;
        }

//        
        #endregion

        #region RelayCommandImplementation
        private void InsertEmp(object InputValue)
        {
            string Request = "";
            ADM_M024_POP POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.EmpDetails.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_POP>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.EmpId = POPUPEntityObject.EmpId;
                MasterEntity.EmpName = POPUPEntityObject.EmpName;
            }
        }
        private void InsertCustomerForGrid(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            SEL_T003_POP POPUPEntityObject = null;

            //Command Parameter Read section

            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    { POPUPEntityObject = MC.PartyDetails.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                    catch (Exception ex) { }
                }
            }
            else if (InputValue != null)
            {
                if (((IEnumerable)InputValue).Cast<SEL_T003_POP>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T003_POP>().ToList()[0];
                }

            }

            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(x => x.PartyId == POPUPEntityObject.PartyId).FirstOrDefault();
                var IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.PartyId == POPUPEntityObject.PartyId).FirstOrDefault());

                if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                {
                    ItemsEntity.Add(new CRM_T004_A()
                    {
                        id = 0,
                        active = true,
                        PartyId = POPUPEntityObject.PartyId,
                        PartyNm = POPUPEntityObject.CustomerNm,
                        PartyType = POPUPEntityObject.PartyType,
                        project_name = POPUPEntityObject.para3,
                        site_location = POPUPEntityObject.project_location,
                        ref_doc_no = POPUPEntityObject.bill_doc,
                        ref_doc_cat = POPUPEntityObject.ref_doc_cat,
                        ref_doc_type = POPUPEntityObject.ref_doc_type,
                        ref_doc_date = POPUPEntityObject.ref_doc_date,
                        location_Id = AppSessionState.location_Id,
                        comp_code = AppSessionState.comp_code,                  
                        add_by = AppSessionState.UserID,
                        editby = AppSessionState.UserID
                    });
                }
                else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        ItemsEntity[dgSelectedIndexItem].PartyId = POPUPEntityObject.PartyId;
                        ItemsEntity[dgSelectedIndexItem].PartyNm = POPUPEntityObject.CustomerNm;
                        ItemsEntity[dgSelectedIndexItem].PartyType = POPUPEntityObject.PartyType;
                        ItemsEntity[dgSelectedIndexItem].project_name = POPUPEntityObject.para3;
                        ItemsEntity[dgSelectedIndexItem].site_location = POPUPEntityObject.project_location;
                        ItemsEntity[dgSelectedIndexItem].ref_doc_no = POPUPEntityObject.bill_doc;
                        ItemsEntity[dgSelectedIndexItem].ref_doc_cat = POPUPEntityObject.ref_doc_cat;
                        ItemsEntity[dgSelectedIndexItem].ref_doc_type = POPUPEntityObject.ref_doc_type;
                        ItemsEntity[dgSelectedIndexItem].ref_doc_date = POPUPEntityObject.ref_doc_date;
                        ItemsEntity[dgSelectedIndexItem].active = true;

                    }
                    else if (ItemsEntity[dgSelectedIndexItem].PartyId != POPUPEntityObject.PartyId)
                    {
                        ItemsEntity[dgSelectedIndexItem].PartyId = POPUPEntityObject.PartyId;
                        ItemsEntity[dgSelectedIndexItem].PartyNm = POPUPEntityObject.CustomerNm;
                        ItemsEntity[dgSelectedIndexItem].PartyType = POPUPEntityObject.PartyType;
                        ItemsEntity[dgSelectedIndexItem].project_name = POPUPEntityObject.para3;
                        ItemsEntity[dgSelectedIndexItem].site_location = POPUPEntityObject.project_location;
                        ItemsEntity[dgSelectedIndexItem].ref_doc_no = POPUPEntityObject.bill_doc;
                        ItemsEntity[dgSelectedIndexItem].ref_doc_cat = POPUPEntityObject.ref_doc_cat;
                        ItemsEntity[dgSelectedIndexItem].ref_doc_type = POPUPEntityObject.ref_doc_type;
                        ItemsEntity[dgSelectedIndexItem].ref_doc_date = POPUPEntityObject.ref_doc_date;
                    }
                }
            }
        }
        private void InsertPartyType(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M028_B_P POPUPEntityObject = null;

            //Command Parameter Read section

            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    { POPUPEntityObject = MC.PartyType.Where(x => x.PartyType.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                    catch (Exception ex) { }
                }
            }
            else if (InputValue != null)
            {
                if (((IEnumerable)InputValue).Cast<ADM_M028_B_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_B_P>().ToList()[0];
                }

            }

            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(x => x.PartyType == POPUPEntityObject.PartyType).FirstOrDefault();
                var IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.PartyType == POPUPEntityObject.PartyType).FirstOrDefault());

                if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                {
                    ItemsEntity.Add(new CRM_T004_A()
                    {
                        id = 0,
                        active = true,
                        PartyType = POPUPEntityObject.PartyType,                      
                        location_Id = AppSessionState.location_Id,
                        comp_code = AppSessionState.comp_code,
                        t_status = "Draft",
                        add_by = AppSessionState.UserID,
                        editby = AppSessionState.UserID
                    });
                }
                else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        ItemsEntity[dgSelectedIndexItem].PartyType = POPUPEntityObject.PartyType;              
                    }
                    else if (ItemsEntity[dgSelectedIndexItem].PartyType != POPUPEntityObject.PartyType)
                    {
                        ItemsEntity[dgSelectedIndexItem].PartyType = POPUPEntityObject.PartyType;
                     
                    }
                }
            }
        } 
        private void InsertPlant(object InputValue)
        {
            string Request = "";
            ADM_M003 POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject =ObjPlant.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            #endregion
            //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
            if (POPUPEntityObject != null)
            {

                MasterEntity.plant = POPUPEntityObject.location_Id;
                MasterEntity.LocationNm = POPUPEntityObject.LoctnNm;
            }
        }
        private void InsertCompany(object InputValue)
        {
            string Request = "";
            ADM_M002 POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject =ObjCompany.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            #endregion
            //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
            if (POPUPEntityObject != null)
            {

                MasterEntity.company = POPUPEntityObject.comp_code;
                MasterEntity.CompanyNm = POPUPEntityObject.CompName;
            }
        }
        private void InsertUnitForGrid(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M038_B_P POPUPEntityObject = null;
            //Command Parameter Read section
            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    { POPUPEntityObject = MC.UomDetails.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                    catch (Exception ex) { }
                }
            }
            else if (InputValue != null)
            {
                if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }

            }

            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(x => x.unit_code == POPUPEntityObject.unit_code).FirstOrDefault();
                var IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault());
                if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allow to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                    }
                    else if (ItemsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                    {
                        ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                    }
                }
            }
        }
        private void InsertSalseOrg(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M001_A_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SalesOrg.Where(x => x.so_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_A_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.so_code = POPUPEntityObject.so_code;
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
        private void InsertSalseGroup(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M001_H_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SalesGroup.Where(x => x.sg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_H_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.sg_code = POPUPEntityObject.sg_code;
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
        private void InsertMonthYear(object InputValue)
        {
            string Request = "";
            ACC_M001A_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.MonthAndYear.Where(x => x.short_desc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ACC_M001A_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M001A_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {

                    MasterEntity.monthyear = POPUPEntityObject.short_desc + '-' + POPUPEntityObject.calender_year;
                    MasterEntity.month = POPUPEntityObject.post_mon.ToString();
                    MasterEntity.year = POPUPEntityObject.post_year.ToString();            
                }
            }
            catch (Exception ex) { }
        }
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i && ItemsEntity[dgSelectedIndexItem].id == 0)
                {
                    ItemsEntity.RemoveAt(i);
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
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {

            string Request = "";

            CRM_T004_Flip ParameterEntityObject = null;
            MasterEntity = new CRM_T004();
            ItemsEntity = new ObservableCollection<CRM_T004_A>();

            if (((IEnumerable)ParameterObject).Cast<CRM_T004_Flip>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<CRM_T004_Flip>().ToList()[0];
                Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.doc_no;
                SelectedTabControlIndex = 0;
                isNewRecord = false;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_CRM_T004>(MCTemp, Request, "Closure", "CRM", "LoadDocumentByDocumentNumber", 0, "");
               
                if (MCTemp.MasterEntity.Count > 0)
                {
                    MasterEntity = MCTemp.MasterEntity[0];
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("This Record Is Inactive...");
                    showMessageService.ShowMessage();
                }
                ItemsEntity = MCTemp.ItemsEntity;

                SetBusinessEntitiesAfterLoad("Save", "");

                AttachmentCollection = MCTemp.Attachment;
                if(MCTemp.Attachment!=null)
                {
                    AttachmentCollection = MCTemp.Attachment;
                }
                else
                {
                    AttachmentCollection = new List<COM_T003>();
                }
            }
            MasterEntity.ts_code = ts_code_vm;
        }
        private void InsertWeek(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                if (ItemsEntity[dgSelectedIndexItem].week_date.Value.Day <= 7)
                {
                    ItemsEntity[dgSelectedIndexItem].week_no = 1.ToString();
                }
                else if (ItemsEntity[dgSelectedIndexItem].week_date.Value.Day > 7 && ItemsEntity[dgSelectedIndexItem].week_date.Value.Day <= 14)
                {
                    ItemsEntity[dgSelectedIndexItem].week_no = 2.ToString();
                }
                else if (ItemsEntity[dgSelectedIndexItem].week_date.Value.Day > 14 && ItemsEntity[dgSelectedIndexItem].week_date.Value.Day <= 21)
                {
                    ItemsEntity[dgSelectedIndexItem].week_no = 3.ToString();
                }
                else if (ItemsEntity[dgSelectedIndexItem].week_date.Value.Day > 21 && ItemsEntity[dgSelectedIndexItem].week_date.Value.Day <= 28)
                {
                    ItemsEntity[dgSelectedIndexItem].week_no = 4.ToString();
                }
                else if (ItemsEntity[dgSelectedIndexItem].week_date.Value.Day > 28)
                {
                    ItemsEntity[dgSelectedIndexItem].week_no = 5.ToString();
                }

            }
            catch (Exception ex)
            {

                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Party...", this.Title);
                showMessageService.ShowMessage();
                ItemsEntity = new ObservableCollection<CRM_T004_A>();

            }
        }

     
        private void Load()
        {
            try
            {
                string Request = "";
                if (MasterEntity.t_status != null || MasterEntity.t_status != " ")
                {
                    Request = "Load" + "!@" + MasterEntity.t_status + "!@" + AppSessionState.EmpId;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_CRM_T004>(MCTemp, Request, "Closure", "CRM", "", 0, "");
                    ItemsEntity = MCTemp.ItemsEntity;

                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("First Select Status.....", this.Title);
                    showMessageService.ShowMessage();
                }
            }
            catch (Exception ex)
            {

                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Cannot Show Data...", this.Title);
                showMessageService.ShowMessage();
            }

        }
        #endregion

        #region Filter
        private string _FilterStringFlipGrid;
        public string FilterStrinFlipGrid
        {
            get { return _FilterStringFlipGrid; }
            set
            {
                _FilterStringFlipGrid = value;
                RaisePropertyChanged("FilterStringFlipGrid");
                Filter_FlipGrid();
            }
        }
        private void Filter_FlipGrid()
        {
            if (_flipDataGridCollection != null)
            {
                _flipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as CRM_T004_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringFlipGrid))
                {
                    return ((data.doc_no != null) && data.doc_no.ToLower().Contains(_FilterStringFlipGrid.ToLower())) ||
                        ((data.EmpName != null) && data.EmpName.ToLower().Contains(_FilterStringFlipGrid.ToLower())) ||
                        ((data.EmpId != null) && data.EmpId.ToLower().Contains(_FilterStringFlipGrid.ToLower())) ||
                        ((data.company != null) && data.company.ToLower().Contains(_FilterStringFlipGrid.ToLower())) ||
                        ((data.plant != null) && data.plant.ToLower().Contains(_FilterStringFlipGrid.ToLower())) ||
                        ((data.month != null) && data.month.ToLower().Contains(_FilterStringFlipGrid.ToLower())) ||
                        ((data.year != null) && data.year.ToLower().Contains(_FilterStringFlipGrid.ToLower()));
                        
                }
                return true;
            }
            return false;
        }

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
            var data = obj as SEL_T003_POP;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringCustomer))
                {
                    return ((data.PartyId != null) && data.PartyId.ToLower().Contains(_FilterStringCustomer.ToLower())) ||
                         ((data.bill_doc != null) && data.bill_doc.ToLower().Contains(_FilterStringCustomer.ToLower())) ||
                         ((data.para3 != null) && data.para3.ToLower().Contains(_FilterStringCustomer.ToLower())) ||
                         ((data.project_location != null) && data.project_location.ToLower().Contains(_FilterStringCustomer.ToLower())) ||
                        ((data.CustomerNm != null) && data.CustomerNm.ToLower().Contains(_FilterStringCustomer.ToLower()));
                    
                }
                return true;
            }
            return false;
        }

        private string _FilterStringEmp;
        public string FilterStringEmp
        {
            get { return _FilterStringEmp; }
            set
            {
                _FilterStringEmp = value;
                RaisePropertyChanged("FilterStringEmp");
                Filter_Emp();
            }
        }
        private void Filter_Emp()
        {
            if (_EmpCollection != null)
            {
                _EmpCollection.Refresh();
            }
        }
        public bool Filter_Emp(object obj)
        {
            var data = obj as ADM_M024_POP;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringEmp))
                {
                    return ((data.EmpId != null) && data.EmpId.ToLower().Contains(_FilterStringEmp.ToLower())) ||
                        ((data.EmpName!= null) && data.EmpName.ToLower().Contains(_FilterStringEmp.ToLower()));

                }
                return true;
            }
            return false;
        }
        
        private string _FilterStringPartyType;
        public string FilterStringPartyType
        {
            get { return _FilterStringPartyType; }
            set
            {
                _FilterStringPartyType = value;
                RaisePropertyChanged("FilterStringPartyType");
                Filter_PartyType();
            }
        }
        private void Filter_PartyType()
        {
            if (_partyTypeCollection != null)
            {
                _partyTypeCollection.Refresh();
            }
        }
        public bool Filter_PartyType(object obj)
        {
            var data = obj as ADM_M028_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringPartyType))
                {
                    return ((data.PartyType != null) && data.PartyType.ToLower().Contains(_FilterStringPartyType.ToLower())) ||
                        ((data.PartyType_Nm!= null) && data.PartyType_Nm.ToLower().Contains(_FilterStringPartyType.ToLower()));

                }
                return true;
            }
            return false;
        }
        
        private string _FilterStringMOnthYear;
        public string FilterStringMOnthYear
        {
            get { return _FilterStringMOnthYear; }
            set
            {
                _FilterStringMOnthYear = value;
                RaisePropertyChanged("FilterStringMOnthYear");
                Filter_MonthYear();
            }
        }
        private void Filter_MonthYear()
        {
            if (_monthYearCollection != null)
            {
                _monthYearCollection.Refresh();
            }
        }
        public bool Filter_MonthYear(object obj)
        {
            var data = obj as ACC_M001A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringMOnthYear))
                {
                    return ((data.short_desc != null) && data.short_desc.ToLower().Contains(_FilterStringMOnthYear.ToLower())) ||
                        ((data.posting_period!= null) && data.posting_period.ToLower().Contains(_FilterStringMOnthYear.ToLower()));

                }
                return true;
            }
            return false;
        }
        
        private string _FilterStringPlant;
        public string FilterStringPlant
        {
            get { return _FilterStringPlant; }
            set
            {
                _FilterStringPlant = value;
                RaisePropertyChanged("FilterStringPlant");
                Filter_Plant();
            }
        }
        private void Filter_Plant()
        {
            if (_plantCollection != null)
            {
                _plantCollection.Refresh();
            }
        }
        public bool Filter_Plant(object obj)
        {
            var data = obj as ADM_M003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringPlant))
                {
                    return ((data.location_Id != null) && data.location_Id.ToLower().Contains(_FilterStringPlant.ToLower())) ||
                        ((data.LoctnNm != null) && data.LoctnNm.ToLower().Contains(_FilterStringPlant.ToLower()));

                }
                return true;
            }
            return false;
        }

        private string _FilterStringCompany;
        public string FilterStringCompany
        {
            get { return _FilterStringCompany; }
            set
            {
                _FilterStringCompany = value;
                RaisePropertyChanged("FilterStringCompany");
                Filter_Company();
            }
        }
        private void Filter_Company()
        {
            if (_companyCollection != null)
            {
                _companyCollection.Refresh();
            }
        }
        public bool Filter_Company(object obj)
        {
            var data = obj as ADM_M002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringCompany))
                {
                    return ((data.comp_code != null) && data.comp_code.ToLower().Contains(_FilterStringCompany.ToLower())) ||
                        ((data.CompName != null) && data.CompName.ToLower().Contains(_FilterStringCompany.ToLower()));

                }
                return true;
            }
            return false;
        }
        private string _filterStringUom;
        public string filterStringUom
        {
            get { return _filterStringUom; }
            set
            {
                _filterStringUom = value;
                RaisePropertyChanged("filterStringUom");
                Filter_UomCollection();
            }
        }
        private void Filter_UomCollection()
        {
            if (UomCollectionForDataDrid != null)
            {
                UomCollectionForDataDrid.Refresh();
            }
        }
        public bool Filter_Uom(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(filterStringUom))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringUom.ToLower())) ||
                           (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringUom.ToLower()));

                }
                return true;
            }
            return false;
        }
        private string _filterString_SalesOrg;
        public string FilterString_SalesOrg
        {
            get { return _filterString_SalesOrg; }
            set
            {
                _filterString_SalesOrg = value;
                RaisePropertyChanged("FilterString_SalesOrg");
                FilterCollection_SalesOrg();
            }
        }
        private void FilterCollection_SalesOrg()
        {
            if (_sales_orgCollection != null)
            {
                _sales_orgCollection.Refresh();
            }
        }
        public bool Filter_SalesOrg(object obj)
        {
            var data = obj as ADM_M001_A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SalesOrg))
                {
                    return (data.so_code != null && data.so_code.ToString().ToLower().Contains(_filterString_SalesOrg.ToLower())) ||
                       (data.sales_org != null && data.sales_org.ToString().ToLower().Contains(_filterString_SalesOrg.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_SalesGroup;
        public string FilterString_SalesGroup
        {
            get { return _filterString_SalesGroup; }
            set
            {
                _filterString_SalesGroup = value;
                RaisePropertyChanged("FilterString_SalesGroup");
                FilterCollection_SalesGroup();
            }
        }
        private void FilterCollection_SalesGroup()
        {
            if (_salse_GroupCollection != null)
            {
                _salse_GroupCollection.Refresh();
            }
        }
        public bool Filter_SalesGroup(object obj)
        {
            var data = obj as ADM_M001_H_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SalesGroup))
                {
                    return (data.sg_code != null && data.sg_code.ToString().ToLower().Contains(_filterString_SalesGroup.ToLower())) ||
                       (data.sg_name != null && data.sg_name.ToString().ToLower().Contains(_filterString_SalesGroup.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Abstract Method
        protected override void OnCreateAction(InquiryActionResult<CRM_T004> result)
        {
            isNewRecord = true;
            MasterEntity = new CRM_T004();
            MC.ItemsEntity = new ObservableCollection<CRM_T004_A>();
            MasterEntity.ValidateAsync().Wait();
            ItemsEntity.Clear();
            FlipDataGridCollection.Refresh();

            DefaultValues();
        }

        protected override void OnDiscardAction(InquiryActionResult<CRM_T004> result)
        {
           
        }

        protected override void OnFevoriteAction(InquiryActionResult<CRM_T004> result)
        {
            
        }

        protected override void OnFlipAction(InquiryActionResult<CRM_T004> result)
        {
           
        }

        protected override void OnHelpAction(InquiryActionResult<CRM_T004> result)
        {
            
        }

        protected override void OnPrintAction(InquiryActionResult<CRM_T004> result)
        {
            try
            {
                string Request = "LoadDocumentByDocumentNumber" + "!@" + MasterEntity.doc_no;
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_CRM_T004>(MCTemp, Request, "Closure", "CRM", "LoadDocumentByDocumentNumber", 0, "");

                object[] objDataSource = new object[6];
                string[] objDataSourceName = new string[6];

                objDataSource[0] = MCTemp.MasterEntity;
                objDataSource[1] = MCTemp.ItemsEntity;


                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[2] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[3] = Result;

                objDataSourceName[0] = "dsCRM_T004";
                objDataSourceName[1] = "dsCRM_T004_A";
                objDataSourceName[2] = "dsCompany";
                objDataSourceName[3] = "dsLocation";

                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\WeekwiseClosure.rdlc", "WeekwiseClosure");

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
        protected override void OnDocumentAction()
        {
           if(!string.IsNullOrEmpty(MasterEntity.doc_no))
            {
                
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MCTemp.Attachment, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<CRM_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<CRM_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<CRM_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<CRM_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<CRM_T004> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnRemoveAction(InquiryActionResult<CRM_T004> result)
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
                this.MasterEntity.EndEdit();
                string response = repository.Delete(MasterEntity.doc_no, "Closure", "CRM");


                MasterEntity = new CRM_T004();
                ItemsEntity = new ObservableCollection<CRM_T004_A>();
                isNewRecord = true;

                FlipDataGridCollection.Refresh();
            }
        }

        protected override void OnSaveAction(InquiryActionResult<CRM_T004> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.XmlDataDocument_CRM_T004_A = obj.ObjectToXML(ItemsEntity);

                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<CRM_T004>(MasterEntity, "Closure", "CRM");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<CRM_T004>(MasterEntity, "Closure", "CRM");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");

                    if (MasterEntity.doc_no != null || MasterEntity.doc_no != " ")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();
                    }

                    isNewRecord = false;

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
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MasterEntity.XmlDataDocument_FlipGrid != null && isNewRecord == true && ParameterOption1 == "Save")
            {
                MC.DocumentDataFlipGrid = (List<CRM_T004_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                FlipDataGridCollection.Refresh();
                FlipDataGridCollection.SortDescriptions.Add(new SortDescription("doc_no", ListSortDirection.Descending));

            }
            if (MasterEntity.XmlDataDocument_CRM_T004_A != null)
            {
                ItemsEntity.Clear();
                ItemsEntity = (ObservableCollection<CRM_T004_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_CRM_T004_A, MC.ItemsEntity);
               
            }
            else
            {
                MC.ItemsEntity = new ObservableCollection<CRM_T004_A>();
            }
            MasterEntity.ts_code = ts_code_vm;
        }

        

        #endregion
    }
}
