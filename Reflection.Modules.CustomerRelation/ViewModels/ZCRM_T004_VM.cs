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
using System.ComponentModel;
using System.Linq;
using System.Windows.Data;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;

using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class ZCRM_T004_VM : WorkspaceViewModel<ZCRM_T004>
    {
        bool NewRecord = true;
        #region AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(SEL_T001_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _ASt_status { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASt_status
        {
            get { return _ASt_status; }
            set
            {
                if (_ASt_status != value)
                {
                    _ASt_status = value; RaisePropertyChanged("ASt_status");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDocType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDocType
        {
            get { return _ASDocType; }
            set
            {
                if (_ASDocType != value)
                {
                    _ASDocType = value; RaisePropertyChanged("ASDocType");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASEmpName { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASEmpName
        {
            get { return _ASEmpName; }
            set
            {
                if (_ASEmpName != value)
                {
                    _ASEmpName = value; RaisePropertyChanged("ASEmpName");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASLocation { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLocation
        {
            get { return _ASLocation; }
            set
            {
                if (_ASLocation != value)
                {
                    _ASLocation = value; RaisePropertyChanged("ASLocation");
                }
            }
        }
        #endregion

        WebServiceRepository<ZCRM_T004> repository = new WebServiceRepository<ZCRM_T004>();
        WebServiceRepository<MultipleContext_ZCRM_T004> repository_MC = new WebServiceRepository<MultipleContext_ZCRM_T004>();
        WebServiceRepository<MultipleContext_ZCRM_T004> repository_MCTemp = new WebServiceRepository<MultipleContext_ZCRM_T004>();

        ObjectSerializationService obj = new ObjectSerializationService();

        #region Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }

        private bool _IsDocumentViewerShow;
        public bool IsDocumentViewerShow
        {
            get
            {
                return _IsDocumentViewerShow;
            }
            set
            {
                if (_IsDocumentViewerShow != value)
                {
                    _IsDocumentViewerShow = value;
                    RaisePropertyChanged("IsDocumentViewerShow");
                }
            }
        }
        private ZCRM_T004 _MasterEntity;
        public ZCRM_T004 MasterEntity
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
        private ZCRM_T004 _MasterEntityTemp;
        public ZCRM_T004 MasterEntityTemp
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
        MultipleContext_ZCRM_T004 _MC = new MultipleContext_ZCRM_T004();
        public MultipleContext_ZCRM_T004 MC
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
        MultipleContext_ZCRM_T004 _MCTemp = new MultipleContext_ZCRM_T004();
        public MultipleContext_ZCRM_T004 MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value;

                    RaisePropertyChanged("MC");
                }
            }
        }
        private List<ZCRM_T004Flip> _FlipGridData;
        public List<ZCRM_T004Flip> FlipGridData
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
        private string _LocalVariable;
        public string LocalVariable
        {
            get
            {
                return _LocalVariable;
            }
            set
            {
                if (_LocalVariable != value)
                {

                    _LocalVariable = value;
                    RaisePropertyChanged("LocalVariable");
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

        private bool _isTabChangeAllowed = true;
        public bool isTabChangeAllowed
        {
            get { return _isTabChangeAllowed; }
            set
            {
                if (_isTabChangeAllowed != value)
                {
                    _isTabChangeAllowed = value; RaisePropertyChanged("isTabChangeAllowed");
                }
            }
        }
        public List<ADM_M003> _locationList;
        public List<ADM_M003> LocationList
        {
            get
            {
                return _locationList;
            }
            set
            {
                _locationList = value;
                RaisePropertyChanged("LocationList");
            }
        }
        
        void ModelUpdated_Master(object sender, EventArgs e)
        {
           

        }
        
        #endregion

        #region Collection
        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private ICollectionView _partyCollection;
        public ICollectionView PartyCollection
        {
            get { return _partyCollection; }
            set { _partyCollection = value; RaisePropertyChanged("PartyCollection"); }
        }
        private ICollectionView _itemCollection;
        public ICollectionView ItemCollection
        {
            get { return _itemCollection; }
            set { _itemCollection = value; RaisePropertyChanged("ItemCollection"); }
        }
        private ICollectionView _unitCollection;
        public ICollectionView UnitCollection
        {
            get { return _unitCollection; }
            set { _unitCollection = value; RaisePropertyChanged("UnitCollection"); }
        }

        private ICollectionView _contactInfoCollection;
        public ICollectionView ContactInfoCollection
        {
            get { return _contactInfoCollection; }
            set { _contactInfoCollection = value; RaisePropertyChanged("ContactInfoCollection"); }
        }

        private ICollectionView _partyAddressCollection;
        public ICollectionView PartyAddressCollection
        {
            get { return _partyAddressCollection; }
            set { _partyAddressCollection = value; RaisePropertyChanged("PartyAddressCollection"); }
        }

        private ICollectionView _paymethodCollection;
        public ICollectionView PayMethodCollection
        {
            get { return _paymethodCollection; }
            set { _paymethodCollection = value; RaisePropertyChanged("PayMethodCollection"); }
        }
        private List<COM_T003> _AttachmentCollection;
        public List<COM_T003> AttachmentCollection
        {
            get { return _AttachmentCollection; }
            set
            {
                if (_AttachmentCollection != value)
                {
                    _AttachmentCollection = value;
                    RaisePropertyChanged("AttachmentCollection");
                }
            }
        }

        #endregion

        #region StringList
        List<string> _stringListParty;
        public List<string> StringListParty
        {
            get { return _stringListParty; }
            set
            {
                if (_stringListParty != value)
                {
                    _stringListParty = value;
                }
            }
        }
        List<string> _strListItem;
        public List<string> StringListItem
        {
            get { return _strListItem; }
            set
            {
                if (_strListItem != value)
                {
                    _strListItem = value;
                }
            }
        }
        List<string> _stringListUOM;
        public List<string> StringListUOM
        {
            get { return _stringListUOM; }
            set
            {
                if (_stringListUOM != value)
                {
                    _stringListUOM = value;
                }
            }
        }
        List<string> _stringListContactInfo;
        public List<string> StringListContactInfo
        {
            get { return _stringListContactInfo; }
            set
            {
                if (_stringListContactInfo != value)
                {
                    _stringListContactInfo = value;
                }
            }
        }
        List<string> _stringListPartyAddress;
        public List<string> StringListPartyAddress
        {
            get { return _stringListPartyAddress; }
            set
            {
                if (_stringListPartyAddress != value)
                {
                    _stringListPartyAddress = value;
                }
            }
        }
        private List<string> _stringListPayMethod;
        public List<string> StringListPayMethod
        {
            get { return _stringListPayMethod; }
            set
            {
                if (_stringListPayMethod != value)
                {
                    _stringListPayMethod = value;
                }
            }
        }
        #endregion
        
        #region Relay Commands Declaration
        public RelayCommand<object> CmdAddParty { get; private set; }
        public RelayCommand<object> CmdAddItem { get; private set; }
        public RelayCommand<object> CmdAddUOM { get; private set; }
        public RelayCommand<object> CmdAddContactInfoMaster { get; private set; }
        public RelayCommand<object> CmdAddPartyAddress { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdAddPayMethod { get; private set; }
        public RelayCommand<object> CmdCalculateEmd { get; private set; }
        public RelayCommand<object> CmdInsert_t_status { get; private set; }
        public RelayCommand<object> CommandDocType { get; private set; }
        public RelayCommand<object> CommandEmp { get; private set; }
        public RelayCommand<object> CmdInsertPlant { get; private set; }
        public RelayCommand<object> CommandLoadHistory { get; private set; }
        public RelayCommand<object> CommandFltrDocType { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }

        #endregion

        #region User Defined Functions
        private void DefaultValues()
        {
           
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_cat = this.doc_cat_vm;
            MasterEntity.doc_type = this.doc_cat_vm;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.EmpId = AppSessionState.EmpId;
            MasterEntity.EmpName = AppSessionState.EmpName;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.t_status = "004";
            MasterEntity.doc_no = "";
            MasterEntity.doc_date = DateTime.Now;

            MasterEntity.Fltr_FrmDate = DateTime.Now.AddMonths(-1);
            MasterEntity.Fltr_ToDate = DateTime.Now;
            MasterEntity.Fltr_doc_type = MasterEntity.doc_type;
        }
        #endregion

        #region Validation
        private bool Validation()
        {
            if (MasterEntity.doc_type == null || MasterEntity.doc_type == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Doc Type...");
                showMessageService.ShowMessage();
                return false;
            }
           
           

            return true;
        }
        #endregion

        #region Constructor
        public ZCRM_T004_VM(string doc_cat, string ts_code)
            : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            IsDocumentViewerShow = false;
            MasterEntityTemp = new ZCRM_T004();
            MasterEntity = new ZCRM_T004();

            FlipGridData = new List<ZCRM_T004Flip>();
            MC = new MultipleContext_ZCRM_T004();
            MCTemp = new MultipleContext_ZCRM_T004();
            MasterEntity.ValidateAsync().Wait();
            ZCRM_T004.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);

            LoadInitialData();
        }
        public ZCRM_T004_VM(string doc_cat, string ts_code, string doc_no)
           : base()
        {
            this.doc_cat_vm = doc_cat;
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            IsDocumentViewerShow = false;
            MasterEntityTemp = new ZCRM_T004();
            MasterEntity = new ZCRM_T004();

            FlipGridData = new List<ZCRM_T004Flip>();
            MC = new MultipleContext_ZCRM_T004();
            MCTemp = new MultipleContext_ZCRM_T004();
            MasterEntity.ValidateAsync().Wait();
            ZCRM_T004.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);


            
           LoadInitialData();
        }
        private void LoadInitialData()
        {
            try
            {
                
                MasterEntity.doc_cat = this.doc_cat_vm;
                MasterEntity.doc_type = this.doc_cat_vm;
               // string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat;
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + (MasterEntity.doc_no ?? "") + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "");
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ZCRM_T004>(MC, Request, "ProjectTender", "PM", "LoadAll", 0, "");

                #region Command Initialisation
                CmdAddParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items, NewRecord); });
                CmdAddItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
                CmdAddUOM = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_UOM(cmdPara, false, true, true); });
                CmdAddContactInfoMaster = new RelayCommand<object>(items => { if (items == null) { return; } InsertContactPerson(items); });
                CmdAddPartyAddress = new RelayCommand<object>(items => { if (items == null) { return; } InsertPartyAddress(items, NewRecord); });
                CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CmdAddPayMethod = new RelayCommand<object>(items => { if (items == null) { return; } InsertPayMethod(items); });
                CmdCalculateEmd = new RelayCommand<object>(items => { if (items == null) { return; } calculateEmd(); });
                CmdInsert_t_status = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_t_status(cmdPara); });
                CommandDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocType(items); });
                CommandEmp = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmp(items); });
                CmdInsertPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
                CommandLoadHistory = new RelayCommand<object>(items => { if (items == null) { return; } LoadHistory(); });
                CommandFltrDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrDocType(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                #endregion

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASt_status = new AutoSuggestTextViewModel<dynamic>(MC.t_statusList, TheFilter, SuggestedValue, "t_display", true);
                ASt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M002)x).doc_type_user);
                TheFilter = (o, prefix) => (((SYS_M002)o).doc_type_user ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M002)o).doc_desc_user ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASDocType = new AutoSuggestTextViewModel<dynamic>(MC.DocumentTypes, TheFilter, SuggestedValue, "doc_type_user", true);
                ASDocType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASEmpName = new AutoSuggestTextViewModel<dynamic>(MC.Sellers, TheFilter, SuggestedValue, "EmpId", true);
                ASEmpName.AutoSuggestVM.IsEmptyValueAllowed = true;

                LocationList = ((List<ADM_M003>)AppSessionState.ADM_M003_List).Where(item => item.comp_code == AppSessionState.comp_code).ToList();
                // var LocList = (from o in LocationList where o.location_Id == AppSessionState.location_Id select o).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASLocation = new AutoSuggestTextViewModel<dynamic>(LocationList, TheFilter, SuggestedValue, "location_Id", true);
                ASLocation.AutoSuggestVM.IsEmptyValueAllowed = true;

                

                PartyCollection = CollectionViewSource.GetDefaultView(MC.PartyMaster);
                PartyCollection.Filter = new Predicate<object>(FilterParty);
                StringListParty = MC.PartyMaster.Select(x => x.PartyId).ToList();

                ItemCollection = CollectionViewSource.GetDefaultView(MC.ItemList);
                ItemCollection.Filter = new Predicate<object>(FilterItems);
                StringListItem = MC.ItemList.Select(x => x.ItemCode).ToList();

                UnitCollection = CollectionViewSource.GetDefaultView(MC.UnitList.ToList());
                UnitCollection.Filter = new Predicate<object>(FilterUom);
                StringListUOM = MC.UnitList.Select(x => x.unit_code).ToList();

                PayMethodCollection = CollectionViewSource.GetDefaultView(MC.PayMethodList.ToList());
                PayMethodCollection.Filter = new Predicate<object>(Filter_PayMethod);
                StringListPayMethod = MC.PayMethodList.Select(x => x.pay_method).ToList();

                DefaultValues();


            }
            catch (Exception ex)
            { }
        }
        
        #endregion

        #region Relay command Definitions
        private void InsertParty(object InputValue, bool OverrideValue)
        {
            string Request = "";
            string RequestParameterData = "";
            ADM_M028_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.PartyId = POPUPEntityObject.PartyId;
                MasterEntity.PartyNm = POPUPEntityObject.PartyNm;
               // RequestParameterData = "LoadPartyDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.PartyId;
                RequestParameterData = "LoadPartyDetails" + "!@" + AppSessionState.client + "!@" + MasterEntity.comp_code + "!@" + MasterEntity.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_no + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + MasterEntity.PartyId;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ZCRM_T004>(MC, RequestParameterData, "ProjectTender", "PM", "", 0, "");

                //MC.ItemList = MCTemp.ItemList;
                //MC.MachinShiftList = MCTemp.MachinShiftList;
                if (MC.ContactInfoMaster.Count == 1)
                {
                    MasterEntity.contact_per_nm = MC.ContactInfoMaster[0].PersonName;
                }
                else
                {
                    MasterEntity.contact_per_nm = "";
                }
                ContactInfoCollection = CollectionViewSource.GetDefaultView(MC.ContactInfoMaster);
                ContactInfoCollection.Filter = new Predicate<object>(Filter_ContactInfo);
                StringListContactInfo = MC.ContactInfoMaster.Select(x => x.ContInfoId.ToString()).ToList();
          
                PartyAddressCollection = CollectionViewSource.GetDefaultView(MC.PartyAddress);
                PartyAddressCollection.Filter = new Predicate<object>(Filter_Address);
                StringListPartyAddress = MC.PartyAddress.Select(x => x.Location.ToString()).ToList();

            }
        }
        private void InsertItem(object InputValue)
        {
            string Request = "";
            ADM_M022_POPUP POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ItemList.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_POPUP>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                MasterEntity.ItemName = POPUPEntityObject.ItemName;
                MasterEntity.unit_code = POPUPEntityObject.unit_code;
            }

        }
        private void Insert_UOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M038_B_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.unit_code = POPUPEntityObject.unit_code;
                MasterEntity.unit_name = POPUPEntityObject.unit_name;
            }


        }
        private void InsertContactPerson(object InputValue)
        {
            string Request = "";
            ADM_M028_C_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ContactInfoMaster.Where(x => x.ContInfoId.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_C_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {

                MasterEntity.ContInfoId = POPUPEntityObject.ContInfoId;
                MasterEntity.contact_per_nm = POPUPEntityObject.PersonName;
            }

        }
        private void InsertPartyAddress(object InputValue, bool OverrideValue)
        {
            string Request = "";
            ADM_M028_D POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PartyAddress.Where(x => x.Location.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_D>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
            {
                //MasterEntity.bill_address_id = POPUPEntityObject.SrNo;
                //MasterEntity.billing_address = POPUPEntityObject.Location;
                //MasterEntity.country_nm = POPUPEntityObject.CntryName;      //add by sachin magar
                //MasterEntity.state_nm = POPUPEntityObject.StatName;
                //MasterEntity.city = POPUPEntityObject.City;
                //MasterEntity.address = POPUPEntityObject.Add1;
                //MasterEntity.address1 = POPUPEntityObject.Add2;
                //MasterEntity.pincode = POPUPEntityObject.PinCode;
            }
        }
        private void InsertPayMethod(object InputValue)
        {
            string Request = "";
            ACC_M021_P POPUPEntityObject = null;
            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PayMethodList.Where(x => x.pay_method.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M021_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.pay_mode = POPUPEntityObject.pay_method;
            }
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            string ParametersStringValue = "";
            ZCRM_T004Flip ParameterEntityObject = null;
            MasterEntity = new ZCRM_T004();

            if (((IEnumerable)ParameterObject).Cast<ZCRM_T004Flip>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ZCRM_T004Flip>().ToList()[0];
                Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + doc_cat_vm + "!@" + MasterEntity.doc_type + "!@" + ParameterEntityObject.doc_no + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + AppSessionState.so_code + "!@" + (AppSessionState.sg_code ?? "") + "!@" + ParameterEntityObject.PartyId;
                
                NewRecord = false;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ZCRM_T004>(MCTemp, Request, "ProjectTender", "PM", "LoadDocumentByDocumentNumber", 0, "");
                MasterEntity = MCTemp.DocumentMaster[0];
               // MC.ContactInfoMaster = MCTemp.ContactInfoMaster;

                ContactInfoCollection = CollectionViewSource.GetDefaultView(MCTemp.ContactInfoMaster);
                ContactInfoCollection.Filter = new Predicate<object>(Filter_ContactInfo);
                StringListContactInfo = MCTemp.ContactInfoMaster.Select(x => x.ContInfoId.ToString()).ToList();

                if (MCTemp.Attachment != null)
                {
                    AttachmentCollection = MCTemp.Attachment;
                }
                else
                {
                    MCTemp.Attachment = new List<COM_T003>();
                }
                SelectedTabControlIndex = 0;
                SetBusinessEntitiesAfterLoad(ParametersStringValue, "Save");
                NewRecord = false;
            }
        }
        private void LoadHistory()
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + (MasterEntity.Fltr_doc_type ?? this.doc_cat_vm) + "!@!@!@" + AppSessionState.EmpId + "!@!@!@!@!@!@!@" + MasterEntity.active + "!@!@!@" + Convert.ToDateTime(MasterEntity.Fltr_FrmDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.Fltr_ToDate).ToString("MM/dd/yyyy");
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ZCRM_T004>(MCTemp, Request, "ProjectTender", "PM", "LoadHistory", 0, "");

                //MC.DocumentDataFlipGrid = MCTemp.DocumentDataFlipGrid;

                FlipGridData = MCTemp.DocumentDataFlipGrid.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                MasterEntity.ts_code = ts_code_vm;
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertFltrDocType(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M002 POPUPEntityObject = null;
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DocumentTypes.Where(x => x.doc_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<SYS_M002>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M002>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.Fltr_doc_type = POPUPEntityObject.doc_type;
                }
            }
            catch (Exception Ex) { }
        }
        private void InsertPlant(object InputValue)
        {
            try
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
                            { POPUPEntityObject = LocationList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.LoctnNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                if (POPUPEntityObject != null)
                {
                    MasterEntity.location_Id = POPUPEntityObject.location_Id;
                    MasterEntity.LoctnNm = POPUPEntityObject.LoctnNm;
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
        private void InsertEmp(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M024_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Sellers.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.EmpName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.EmpId = POPUPEntityObject.EmpId;
                    MasterEntity.EmpName = POPUPEntityObject.EmpName;
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
        private void Insert_t_status(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0013 POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.t_statusList.Where(x => x.t_status.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_display.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0013>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.t_status = POPUPEntityObject.t_status;
                    MasterEntity.t_display = POPUPEntityObject.t_display;
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
        private void InsertDocType(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M002 POPUPEntityObject = null;
                IEnumerable<SYS_M002> BEType = new List<SYS_M002>();
                #region Command Parameter Read Section
                try
                {
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.DocumentTypes.Where(x => x.doc_type_user.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M002>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                            
                    if (POPUPEntityObject != null)
                {
                        MasterEntity.doc_cat = POPUPEntityObject.doc_cat;
                        MasterEntity.doc_type = POPUPEntityObject.doc_type;
                        
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
        private void calculateEmd()
        {

            if (MasterEntity.emd_amt != 0)
            {
                if (MasterEntity.received_amt >=0)
                {
                    MasterEntity.emd_deduction = Convert.ToDecimal(MasterEntity.emd_amt) - Convert.ToDecimal(MasterEntity.received_amt);
                }
            }

        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                    AppSessionState.ViewOtherRecordAllowed = true;
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
        private void Invoke_Reference_Document(object InputValue)
        {
            try
            {
                string Request = "";
                ReflectionFunctionService objRef = new ReflectionFunctionService();
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = MasterEntity.client + "!@" + MasterEntity.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region AbstractMethod
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
            {
                MC.DocumentDataFlipGrid = (List<ZCRM_T004Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                DataGridCollection.Refresh();
            }
        }
        protected override void OnCreateAction(InquiryActionResult<ZCRM_T004> result)
        {
            NewRecord = true;
            MasterEntity = new ZCRM_T004();
            MasterEntity.ValidateAsync().Wait();
            DefaultValues();
        }

        protected override void OnDiscardAction(InquiryActionResult<ZCRM_T004> result)
        {
            MasterEntity.CancelEdit();
        }

        protected override void OnFevoriteAction(InquiryActionResult<ZCRM_T004> result)
        {
            
        }

        protected override void OnFlipAction(InquiryActionResult<ZCRM_T004> result)
        {
            
        }

        protected override void OnHelpAction(InquiryActionResult<ZCRM_T004> result)
        {
            
        }

        protected override void OnPrintAction(InquiryActionResult<ZCRM_T004> result)
        {
            
        }

        protected override void OnRemoveAction(InquiryActionResult<ZCRM_T004> result)
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
                string response = repository.Delete(MasterEntity.doc_no, "ProjectTender", "PM");
               
                MasterEntity = new ZCRM_T004();
                NewRecord = true;

            }
        }

        protected override void OnSaveAction(InquiryActionResult<ZCRM_T004> result)
        {
            if (Validation() == true)
            {
                this.MasterEntity.EndEdit();
                if (NewRecord == true)
                {
                    MasterEntity = repository.SaveWithReturnDomainObject<ZCRM_T004>(MasterEntity, "ProjectTender", "PM");
                }
                else if (NewRecord == false)
                {
                    MasterEntity = repository.UpdateWithReturnDomainObject<ZCRM_T004>(MasterEntity, "ProjectTender", "PM");
                }
                SetBusinessEntitiesAfterLoad("Save", "");
                if (MasterEntity.doc_no != null && NewRecord == true)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Data Saved Successfully");
                    showMessageService.ShowMessage();
                }
                if (MasterEntity.doc_no != null && NewRecord == false)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Data Updated Successfully");
                    showMessageService.ShowMessage();
                }
                NewRecord = false;

            }
        }

        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.doc_no))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MCTemp.Attachment, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
            }
        }
        #endregion

        #region Filters
        private string _filterString_FlipGrid;
        public string FilterString_FlipGrid
        {
            get { return _filterString_FlipGrid; }
            set
            {
                _filterString_FlipGrid = value;
                RaisePropertyChanged("FilterString_FlipGrid");
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
            var data = obj as ZCRM_T004Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return

                        (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.contact_per_nm != null && data.contact_per_nm.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterString_party;
        public string FilterString_party
        {
            get { return _filterString_party; }
            set
            {
                _filterString_party = value;
                RaisePropertyChanged("FilterString_party");
                FilterCollectionParty();
            }
        }
        private void FilterCollectionParty()
        {
            if (_partyCollection != null)
            {
                _partyCollection.Refresh();
            }
        }
        public bool FilterParty(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_party))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_party.ToLower()) ||
                        data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_party.ToLower()));
                }
                return true;
            }
            return false;
        }

        private string _filterStringItem;
        private void FilterCollectionItem()
        {
            if (_itemCollection != null)
            {
                _itemCollection.Refresh();
            }
        }
        public string FilterStringItem
        {
            get { return _filterStringItem; }
            set
            {
                _filterStringItem = value;
                RaisePropertyChanged("FilterStringItem");
                FilterCollectionItem();
            }
        }
        public bool FilterItems(object obj)
        {
            var data = obj as ADM_M022_POPUP;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringItem))
                {
                    return (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterStringItem.ToLower())) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringItem.ToLower()));

                }
                return true;
            }
            return false;
        }

        private string _filterString_uom;
        public string FilterString_uom
        {
            get { return _filterString_uom; }
            set
            {
                _filterString_uom = value;
                RaisePropertyChanged("FilterString_uom"); 
                FilterCollectionuom();
            }
        }
        private void FilterCollectionuom()
        {
            if (_unitCollection != null)
            {
                _unitCollection.Refresh();
            }
        }
        public bool FilterUom(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_uom))
                {
                    return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterString_uom.ToLower()));
                }
                return true;
            }
            return false;
        }


        private string _filterString_ContactInfo;
        public string FilterString_ContactInfo
        {
            get { return _filterString_ContactInfo; }
            set
            {
                _filterString_ContactInfo = value;
                RaisePropertyChanged("FilterString_ContactInfo");
                FilterCollection_ContactInfo();
            }
        }
        private void FilterCollection_ContactInfo()
        {
            if (_contactInfoCollection != null)
            {
                _contactInfoCollection.Refresh();
            }
        }
        public bool Filter_ContactInfo(object obj)
        {
            var data = obj as ADM_M028_C_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ContactInfo))
                {
                    return (data.PersonName != null && data.PersonName.ToString().ToLower().Contains(_filterString_ContactInfo.ToLower()) ||
                         data.Location != null && data.Location.ToString().ToLower().Contains(_filterString_ContactInfo.ToLower())
                        );
                }
                return true;
            }
            return false;
        }


        private string _filterString_Address;
        public string FilterString_Address
        {
            get { return _filterString_Address; }
            set
            {
                _filterString_Address = value;
                RaisePropertyChanged("FilterString_Address");
                FilterCollection_Address();
            }
        }
        private void FilterCollection_Address()
        {
            if (_partyAddressCollection != null)
            {
                _partyAddressCollection.Refresh();
            }

        }
        public bool Filter_Address(object obj)
        {
            var data = obj as ADM_M028_D;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Address))
                {
                    return (data.Location != null && data.Location.ToString().ToLower().Contains(_filterString_Address.ToLower()) ||
                         data.Add1 != null && data.Add1.ToString().ToLower().Contains(_filterString_Address.ToLower()));
                }
                return true;
            }
            return false;
        }


        private string _filterString_PayMethod;
        public string FilterString_PayMethod
        {
            get { return _filterString_PayMethod; }
            set
            {
                _filterString_PayMethod = value;
                RaisePropertyChanged("FilterString_PayTerms");
                FilterCollection_PayMethod();
            }
        }
        private void FilterCollection_PayMethod()
        {
            if (_paymethodCollection != null)
            {
                _paymethodCollection.Refresh();
            }
        }
        public bool Filter_PayMethod(object obj)
        {
            var data = obj as ACC_M021_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_PayMethod))
                {
                    return (data.pay_code != null && data.pay_code.ToString().ToLower().Contains(_filterString_PayMethod.ToLower()) ||
                        data.pay_method != null && data.pay_method.ToString().ToLower().Contains(_filterString_PayMethod.ToLower()));
                }
                return true;
            }
            return false;
        }

        protected override void OnRefreshCommand(InquiryActionResult<ZCRM_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ZCRM_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ZCRM_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ZCRM_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ZCRM_T004> result)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
