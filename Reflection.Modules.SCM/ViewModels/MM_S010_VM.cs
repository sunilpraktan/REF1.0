using Reflection.BusinessEntity.SCM;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using System.Collections;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Collections.Specialized;
using GalaSoft.MvvmLight.Messaging;

namespace Reflection.Modules.SCM.ViewModels
{
    class MM_S010_VM : WorkspaceViewModel<MM_S010>
    {
        #region Variable Declaration
        bool isNewRecord = true;

        WebServiceRepository<MM_S010> repository = new WebServiceRepository<MM_S010>();
        WebServiceRepository<MultipleContext_MM_S010> repository_MC = new WebServiceRepository<MultipleContext_MM_S010>();
        WebServiceRepository<MultipleContext_MM_S010> repository_MCTemp = new WebServiceRepository<MultipleContext_MM_S010>();
        WebServiceRepository<MultipleContext_MM_S010> repository_MCTemp1 = new WebServiceRepository<MultipleContext_MM_S010>();
        ObjectSerializationService obj = new ObjectSerializationService();

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private MultipleContext_MM_S010 _MC = new MultipleContext_MM_S010();
        public MultipleContext_MM_S010 MC
        {
            get { return _MC; }
            set
            {
                if (_MC != value)
                {
                    _MC = value; RaisePropertyChanged("MC");
                }
            }
        }

        private MultipleContext_MM_S010 _MCTemp = new MultipleContext_MM_S010();
        public MultipleContext_MM_S010 MCTemp
        {
            get { return _MCTemp; }
            set
            {
                if (_MCTemp != value)
                {
                    _MCTemp = value; RaisePropertyChanged("MCTemp");
                }
            }
        }

        private MultipleContext_MM_S010 _MCTemp1 = new MultipleContext_MM_S010();
        public MultipleContext_MM_S010 MCTemp1
        {
            get { return _MCTemp1; }
            set
            {
                if (_MCTemp1 != value)
                {
                    _MCTemp1 = value; RaisePropertyChanged("MCTemp");
                }
            }
        }

        string store_location;

        private string _MStoreLoc;
        public string MStoreLoc
        {
            get { return _MStoreLoc; }
            set
            {
                if (_MStoreLoc != value)
                {
                    _MStoreLoc = value;
                    RaisePropertyChanged("MStoreLoc");
                }
            }
        }

        private MM_S010 _MasterEntity;
        public MM_S010 MasterEntity
        {
            get { return _MasterEntity; }
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

        private ObservableCollection<MM_S010_A> _ItemsEntity;
        public ObservableCollection<MM_S010_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value;
                    ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("ItemsEntity");
                }
            }
        }

        public List<ADM_M002> _companyList;
        public List<ADM_M002> CompanyList
        {
            get { return _companyList; }
            set
            {
                _companyList = value;
                RaisePropertyChanged("CompanyList");
            }
        }

        public List<ADM_M003> _plantList;
        public List<ADM_M003> plantList
        {
            get { return _plantList; }
            set
            {
                _plantList = value;
                RaisePropertyChanged("plantList");
            }
        }

        private List<MM_M001> _StoreLocList = new List<MM_M001>();
        public List<MM_M001> StoreLocList
        {
            get { return _StoreLocList; }
            set
            {
                if (_StoreLocList != value)
                {
                    _StoreLocList = value;
                }
            }
        }

        private List<MM_S010_A> _ItemList;
        public List<MM_S010_A> ItemList
        {
            get { return _ItemList; }
            set { if (_ItemList != value) { _ItemList = value; RaisePropertyChanged("ItemList"); } }
        }

        private int _dgSelectedIndexItem;
        public int dgSelectedIndexItem
        {
            get { return _dgSelectedIndexItem; }
            set
            {
                if (_dgSelectedIndexItem != value)
                {
                    _dgSelectedIndexItem = value;
                    RaisePropertyChanged("dgSelectedIndexItem");
                }
            }
        }

        private int _dgSelectedIndex;
        public int dgSelectedIndex
        {
            get { return _dgSelectedIndex; }
            set
            {
                if (_dgSelectedIndex != value)
                {
                    _dgSelectedIndex = value;
                    RaisePropertyChanged("dgSelectedIndex");
                    //FilterBatchDataGrid();
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

        private List<MM_S010_BackFlip> _FlipGridData;
        public List<MM_S010_BackFlip> FlipGridData
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
            set
            {
                _AttachmentCollection = value;
                RaisePropertyChanged("AttachmentCollection");
            }
        }

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

        private bool _EnableComboBox;
        public bool EnableComboBox
        {
            get { return _EnableComboBox; }
            set
            {
                if (_EnableComboBox != value)
                {
                    _EnableComboBox = value;
                    RaisePropertyChanged("EnableComboBox");
                }
            }
        }


        #endregion

        #region ICollection for Popup Control
        private ICollectionView _CompanyCollection;
        public ICollectionView CompanyCollection
        {
            get { return _CompanyCollection; }
            set { _CompanyCollection = value; RaisePropertyChanged("CompanyCollection"); }
        }

        private ICollectionView _plantCollection;
        public ICollectionView plantCollection
        {
            get { return _plantCollection; }
            set { _plantCollection = value; RaisePropertyChanged("plantCollection"); }
        }

        private ICollectionView _FinYearCollection;
        public ICollectionView FinYearCollection
        {
            get { return _FinYearCollection; }
            set { _FinYearCollection = value; RaisePropertyChanged("FinYearCollection"); }
        }

        private ICollectionView _PostPeriodCollection;
        public ICollectionView PostPeriodCollection
        {
            get { return _PostPeriodCollection; }
            set { _PostPeriodCollection = value; RaisePropertyChanged("PostPeriodCollection"); }
        }

        private ICollectionView _StoreLocCollection;
        public ICollectionView StoreLocCollection
        {
            get { return _StoreLocCollection; }
            set { _StoreLocCollection = value; RaisePropertyChanged("StoreLocCollection"); }
        }

        private ICollectionView _MStoreLocCollection;
        public ICollectionView MStoreLocCollection
        {
            get { return _MStoreLocCollection; }
            set { _MStoreLocCollection = value; RaisePropertyChanged("MStoreLocCollection"); }
        }

        private ICollectionView _CategoryCollection;
        public ICollectionView CategoryCollection
        {
            get { return _CategoryCollection; }
            set { _CategoryCollection = value; RaisePropertyChanged("CategoryCollection"); }
        }

        private ICollectionView _SubCategoryCollection;
        public ICollectionView SubCategoryCollection
        {
            get { return _SubCategoryCollection; }
            set { _SubCategoryCollection = value; RaisePropertyChanged("SubCategoryCollection"); }
        }

        private ICollectionView _ItemTypeCollection;
        public ICollectionView ItemTypeCollection
        {
            get { return _ItemTypeCollection; }
            set { _ItemTypeCollection = value; RaisePropertyChanged("ItemTypeCollection"); }
        }

        private ICollectionView _SubItemTypeCollection;
        public ICollectionView SubItemTypeCollection
        {
            get { return _SubItemTypeCollection; }
            set { _SubItemTypeCollection = value; RaisePropertyChanged("SubItemTypeCollection"); }
        }

        private ICollectionView _ItemCollection;
        public ICollectionView ItemCollection
        {
            get { return _ItemCollection; }
            set { _ItemCollection = value; RaisePropertyChanged("ItemCollection"); }
        }

        private ICollectionView _UOMCollection;
        public ICollectionView UOMCollection
        {
            get { return _UOMCollection; }
            set { _UOMCollection = value; RaisePropertyChanged("UOMCollection"); }
        }


        private ICollectionView _MakeCollection;
        public ICollectionView MakeCollection
        {
            get { return _MakeCollection; }
            set { _MakeCollection = value; RaisePropertyChanged("MakeCollection"); }
        }

        private ICollectionView _TypeCollection;
        public ICollectionView TypeCollection
        {
            get { return _TypeCollection; }
            set { _TypeCollection = value; RaisePropertyChanged("TypeCollection"); }
        }

        private ICollectionView _MatConditionCollection;
        public ICollectionView MatConditionCollection
        {
            get { return _MatConditionCollection; }
            set { _MatConditionCollection = value; RaisePropertyChanged("MatConditionCollection"); }
        }

        private ICollectionView _BackflipCollection;
        public ICollectionView BackflipCollection
        {
            get { return _BackflipCollection; }
            set { _BackflipCollection = value; RaisePropertyChanged("BackflipCollection"); }
        }

        private ICollectionView _InkCollection;
        public ICollectionView InkCollection
        {
            get { return _InkCollection; }
            set { _InkCollection = value; RaisePropertyChanged("InkCollection"); }
        }

        private ICollectionView _IldCollection;
        public ICollectionView IldCollection
        {
            get { return _IldCollection; }
            set { _IldCollection = value; RaisePropertyChanged("IldCollection"); }
        }

        private ICollectionView _GradeCollection;
        public ICollectionView GradeCollection
        {
            get { return _GradeCollection; }
            set { _GradeCollection = value; RaisePropertyChanged("GradeCollection"); }
        }

        private ICollectionView _UOMCollection1;
        public ICollectionView UOMCollection1
        {
            get { return _UOMCollection1; }
            set { _UOMCollection1 = value; RaisePropertyChanged("UOMCollection1"); }
        }

        #endregion

        #region StringList Variables
        private List<string> _stringListCompany;
        public List<string> StringListCompany
        {
            get { return _stringListCompany; }
            set
            {
                if (_stringListCompany != value)
                {
                    _stringListCompany = value;
                }
            }
        }

        private List<string> _stringListplant;
        public List<string> StringListplant
        {
            get { return _stringListplant; }
            set
            {
                if (_stringListplant != value)
                {
                    _stringListplant = value;
                }
            }
        }

        private List<string> _stringListFinYear;
        public List<string> StringListFinYear
        {
            get { return _stringListFinYear; }
            set
            {
                if (_stringListFinYear != value)
                {
                    _stringListFinYear = value;
                }
            }
        }

        private List<string> _stringListPostPeriod;
        public List<string> stringListPostPeriod
        {
            get { return _stringListPostPeriod; }
            set
            {
                if (_stringListPostPeriod != value)
                {
                    _stringListPostPeriod = value;
                }
            }
        }

        private List<string> _strListStoreLoc;
        public List<string> StringListStoreLoc
        {
            get { return _strListStoreLoc; }
            set
            {
                if (_strListStoreLoc != value)
                {
                    _strListStoreLoc = value;
                }
            }
        }

        private List<string> _StringListCategory;
        public List<string> StringListCategory
        {
            get { return _StringListCategory; }
            set
            {
                if (_StringListCategory != value)
                {
                    _StringListCategory = value;
                }
            }
        }

        private List<string> _StringListSubCategory;
        public List<string> StringListSubCategory
        {
            get { return _StringListSubCategory; }
            set
            {
                if (_StringListSubCategory != value)
                {
                    _StringListSubCategory = value;
                }
            }
        }

        private List<string> _StringListItemType;
        public List<string> StringListItemType
        {
            get { return _StringListItemType; }
            set
            {
                if (_StringListItemType != value)
                {
                    _StringListItemType = value;
                }
            }
        }

        private List<string> _StringListSubItemType;
        public List<string> StringListSubItemType
        {
            get { return _StringListSubItemType; }
            set
            {
                if (_StringListSubItemType != value)
                {
                    _StringListSubItemType = value;
                }
            }
        }

        private List<string> _StringListItem;
        public List<string> StringListItem
        {
            get { return _StringListItem; }
            set
            {
                if (_StringListItem != value)
                {
                    _StringListItem = value;
                }
            }
        }

        private List<string> _StringListUom;
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

        private List<string> _StringListUom1;
        public List<string> StringListUom1
        {
            get { return _StringListUom1; }
            set
            {
                if (_StringListUom1 != value)
                {
                    _StringListUom1 = value;
                }
            }
        }

        List<string> _strListMake;
        public List<string> StringListMake
        {
            get { return _strListMake; }
            set
            {
                if (_strListMake != value)
                {
                    _strListMake = value;
                    RaisePropertyChanged("StringListMake");
                }
            }
        }

        private List<string> _StringListBackflip;
        public List<string> StringListBackflip
        {
            get { return _StringListBackflip; }
            set
            {
                if (_StringListBackflip != value)
                {
                    _StringListBackflip = value;
                }
            }
        }


        List<string> _StringListInk;
        public List<string> StringListInk
        {
            get { return _StringListInk; }
            set
            {
                if (_StringListInk != value)
                {
                    _StringListInk = value;
                }
            }
        }

        List<string> _StringListIld;
        public List<string> StringListIld
        {
            get { return _StringListIld; }
            set
            {
                if (_StringListIld != value)
                {
                    _StringListIld = value;
                }
            }
        }

        List<string> _StringListGrade;
        public List<string> StringListGrade
        {
            get { return _StringListGrade; }
            set
            {
                if (_StringListGrade != value)
                {
                    _StringListGrade = value;
                }
            }
        }
        #endregion

        #region Relay Commands Declaration

        public RelayCommand<object> cmdInsertCompany { get; private set; }
        public RelayCommand<object> cmdInsertPlant { get; private set; }
        public RelayCommand<object> cmdInsertFinyear { get; private set; }
        public RelayCommand<object> cmdInsertPostPeriod { get; private set; }
        public RelayCommand<object> cmdInsertMStoreLoc { get; private set; }
        public RelayCommand<object> cmdInsertCategory { get; private set; }
        public RelayCommand<object> cmdInsertSubCategory { get; private set; }
        public RelayCommand<object> cmdInsertItemType { get; private set; }
        public RelayCommand<object> cmdInsertSubItemType { get; private set; }
        public RelayCommand<object> cmdInsertItem { get; private set; }
        public RelayCommand cmdLoad { get; private set; }
        public RelayCommand<object> cmdInsertUOM { get; private set; }
        public RelayCommand<object> cmdInsertUOM1 { get; private set; }
        public RelayCommand<IList> cmdMake { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<bool> CheckedCommand { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }

        #endregion

        #region Constructor
        public MM_S010_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            IsDocumentViewerShow = false;
            MasterEntity = new MM_S010();
            ItemsEntity = new ObservableCollection<MM_S010_A>();
            ItemList = new List<MM_S010_A>();
            MC = new MultipleContext_MM_S010();
            MCTemp = new MultipleContext_MM_S010();
            EnableComboBox = false;
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);

            LoadInitialData();
        }
        public MM_S010_VM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            IsDocumentViewerShow = false;
            MasterEntity = new MM_S010();
            ItemsEntity = new ObservableCollection<MM_S010_A>();
            ItemList = new List<MM_S010_A>();
            MC = new MultipleContext_MM_S010();
            MCTemp = new MultipleContext_MM_S010();
            EnableComboBox = false;
            ItemsEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);

            LoadInitialData();
        }
        #endregion

        #region Abstract Methods
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.doc_no.ToString()))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.ToString(), DocumentList = MCTemp1.AttachmentData, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
            }
        }
        protected override void OnSaveAction(InquiryActionResult<MM_S010> result)
        {
            ItemList.Clear();
            if (ItemsEntity.Count > 0)
            {
                foreach (MM_S010_A item in ItemsEntity)
                {
                    if (item.check == true)
                    {
                        ItemList.Add(item);
                    }
                }
            }
            if (Validation() == true)
            {
                try
                {
                    MasterEntity.XmlDataDocument_MM_S010_A = obj.ObjectToXML(ItemList);
                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<MM_S010>(MasterEntity, "PhysicalStock", "SCM");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<MM_S010>(MasterEntity, "PhysicalStock", "SCM");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (FlipGridData != null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();
                    }
                    MasterEntity = new MM_S010();
                    ItemsEntity.Clear();
                    DefaultValues();
                    isNewRecord = false;
                    EnableComboBox = false;
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
            //else
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Item Code AND Unit Code Is Required");
            //    showMessageService.ShowMessage();
            //}
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            MasterEntity.ts_code = ts_code_vm;
            if (MasterEntity.XmlDataDocument_MM_S010_A != null)
            {
                ItemsEntity.Clear();
                ItemsEntity = (ObservableCollection<MM_S010_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_MM_S010_A, MC.ItemEntity);
            }
            else
            {
                MC.ItemEntity = new ObservableCollection<MM_S010_A>();
            }

            if (MasterEntity.XmlDataDocument_FlipGrid != null && isNewRecord == true && ParameterOption1 == "Save")
            {
                MC.BackFlipEntity = (List<MM_S010_BackFlip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.BackFlipEntity);
                FlipGridData.Add(MC.BackFlipEntity[0]);
                BackflipCollection.Refresh();
                BackflipCollection.SortDescriptions.Add(new SortDescription("doc_no", ListSortDirection.Descending));
            }
        }
        protected override void OnCreateAction(InquiryActionResult<MM_S010> result)
        {
            isNewRecord = true;
            EnableComboBox = false;
            MasterEntity = new MM_S010();
            DefaultValues();
            ItemsEntity = new ObservableCollection<MM_S010_A>();
        }
        protected override void OnRemoveAction(InquiryActionResult<MM_S010> result)
        { }
        protected override void OnDiscardAction(InquiryActionResult<MM_S010> result)
        { }
        protected override void OnPrintAction(InquiryActionResult<MM_S010> result)
        { }
        protected override void OnFlipAction(InquiryActionResult<MM_S010> result)
        { }
        protected override void OnHelpAction(InquiryActionResult<MM_S010> result)
        { }
        protected override void OnFevoriteAction(InquiryActionResult<MM_S010> result)
        { }
        protected override void OnRefreshCommand(InquiryActionResult<MM_S010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MM_S010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MM_S010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MM_S010> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MM_S010> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters

        #region . Company .
        private string _filterString_Company;
        public string FilterString_Company
        {
            get { return _filterString_Company; }
            set
            {
                _filterString_Company = value;
                RaisePropertyChanged("FilterString_Company");
                FilterCollection_Company();
            }
        }
        private void FilterCollection_Company()
        {
            if (_CompanyCollection != null)
            {
                _CompanyCollection.Refresh();
            }
        }
        public bool Filter_Company(object obj)
        {
            var data = obj as ADM_M002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Company))
                {
                    return (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_filterString_Company.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Plant .
        private string _filterString_Plant;
        public string FilterString_Plant
        {
            get { return _filterString_Plant; }
            set
            {
                _filterString_Plant = value;
                RaisePropertyChanged("FilterString_Plant");
                FilterCollection_Plant();
            }
        }
        private void FilterCollection_Plant()
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
                if (!string.IsNullOrEmpty(_filterString_Plant))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString_Plant.ToLower()) ||
                                data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterString_Plant.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . FinYear .
        private string _filterString_FinYear;
        public string filterString_FinYear
        {
            get { return _filterString_FinYear; }
            set
            {
                _filterString_FinYear = value;
                RaisePropertyChanged("filterString_FinYear");
                FilterCollection_FinYear();
            }
        }
        private void FilterCollection_FinYear()
        {
            if (_FinYearCollection != null)
            {
                _FinYearCollection.Refresh();
            }
        }
        public bool Filter_FinYear(object obj)
        {
            var data = obj as ACC_M001A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Plant))
                {
                    return (data.fin_year != null && data.fin_year.ToString().ToLower().Contains(_filterString_Plant.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . PostPeriod .
        private string _filterString_PostPeriod;
        public string filterString_PostPeriod
        {
            get { return _filterString_PostPeriod; }
            set
            {
                _filterString_PostPeriod = value;
                RaisePropertyChanged("filterString_PostPeriod");
                FilterCollection_PostPeriod();
            }
        }
        private void FilterCollection_PostPeriod()
        {
            if (_PostPeriodCollection != null)
            {
                _PostPeriodCollection.Refresh();
            }
        }
        public bool Filter_PostPeriod(object obj)
        {
            var data = obj as ACC_M001A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_PostPeriod))
                {
                    return (data.posting_period != null && data.posting_period.ToString().ToLower().Contains(_filterString_PostPeriod.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Store Loc .
        private string _filterString_StoreLoc;
        public string FilterString_StoreLoc
        {
            get { return _filterString_StoreLoc; }
            set
            {
                _filterString_StoreLoc = value;
                RaisePropertyChanged("FilterString_StoreLoc");
                FilterCollection_StoreLoc();
            }
        }
        private void FilterCollection_StoreLoc()
        {
            if (StoreLocCollection != null)
            {
                _StoreLocCollection.Refresh();
            }
        }
        public bool Filter_StoreLoc(object obj)
        {
            var data = obj as MM_M001;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_StoreLoc))
                {
                    return (data.store_code != null && data.store_code.ToString().ToLower().Contains(_filterString_StoreLoc.ToLower()) ||
                        data.store_name != null && data.store_name.ToString().ToLower().Contains(_filterString_StoreLoc.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . MStore Loc .

        private string _filterString_MStoreLoc;
        public string FilterString_MStoreLoc
        {
            get { return _filterString_MStoreLoc; }
            set
            {
                _filterString_MStoreLoc = value;
                RaisePropertyChanged("FilterString_MStoreLoc");
                FilterCollection_MStoreLoc();
            }
        }
        private void FilterCollection_MStoreLoc()
        {
            if (MStoreLocCollection != null)
            {
                _MStoreLocCollection.Refresh();
            }
        }
        public bool Filter_MStoreLoc(object obj)
        {
            var data = obj as MM_M001;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_MStoreLoc))
                {
                    return (data.store_code != null && data.store_code.ToString().ToLower().Contains(_filterString_MStoreLoc.ToLower()) ||
                        data.store_name != null && data.store_name.ToString().ToLower().Contains(_filterString_MStoreLoc.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Category .
        private string _filterString_Category;
        public string filterString_Category
        {
            get { return _filterString_Category; }
            set
            {
                _filterString_Category = value;
                RaisePropertyChanged("filterString_Category");
                FilterCollection_Category();
            }
        }
        private void FilterCollection_Category()
        {
            if (CategoryCollection != null)
            {
                _CategoryCollection.Refresh();
            }
        }
        public bool Filter_Category(object obj)
        {
            var data = obj as ADM_M018_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Category))
                {
                    return (data.CatCode != null && data.CatCode.ToString().ToLower().Contains(_filterString_Category.ToLower())) ||
                           (data.CatName != null && data.CatName.ToString().ToLower().Contains(_filterString_Category.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . SubCategory .
        private string _filterString_SubCategory;
        public string filterString_SubCategory
        {
            get { return _filterString_SubCategory; }
            set
            {
                _filterString_SubCategory = value;
                RaisePropertyChanged("filterString_SubCategory");
                FilterCollection_SubCategory();
            }
        }
        private void FilterCollection_SubCategory()
        {
            if (SubCategoryCollection != null)
            {
                _SubCategoryCollection.Refresh();
            }
        }
        public bool Filter_SubCategory(object obj)
        {
            var data = obj as ADM_M019_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SubCategory))
                {
                    return (data.SubCatCode != null && data.SubCatCode.ToString().ToLower().Contains(_filterString_SubCategory.ToLower())) ||
                           (data.SubCatName != null && data.SubCatName.ToString().ToLower().Contains(_filterString_SubCategory.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . ItemType .
        private string _filterString_ItemType;
        public string filterString_ItemType
        {
            get { return _filterString_ItemType; }
            set
            {
                _filterString_ItemType = value;
                RaisePropertyChanged("filterString_ItemType");
                FilterCollection_ItemType();
            }
        }
        private void FilterCollection_ItemType()
        {
            if (ItemTypeCollection != null)
            {
                _ItemTypeCollection.Refresh();
            }
        }
        public bool Filter_ItemType(object obj)
        {
            var data = obj as ADM_M015_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ItemType))
                {
                    return (data.ItemTypeCd != null && data.ItemTypeCd.ToString().ToLower().Contains(_filterString_ItemType.ToLower())) ||
                           (data.ItemTypeNm != null && data.ItemTypeNm.ToString().ToLower().Contains(_filterString_ItemType.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region .Sub ItemType .
        private string _filterString_SubItemType;
        public string filterString_SubItemType
        {
            get { return _filterString_SubItemType; }
            set
            {
                _filterString_SubItemType = value;
                RaisePropertyChanged("filterString_SubItemType");
                FilterCollection_SubItemType();
            }
        }
        private void FilterCollection_SubItemType()
        {
            if (SubItemTypeCollection != null)
            {
                _SubItemTypeCollection.Refresh();
            }
        }
        public bool Filter_SubItemType(object obj)
        {
            var data = obj as ADM_M016_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SubItemType))
                {
                    return (data.SubItemTpCd != null && data.SubItemTpCd.ToString().ToLower().Contains(_filterString_SubItemType.ToLower())) ||
                           (data.SubItemTpNm != null && data.SubItemTpNm.ToString().ToLower().Contains(_filterString_SubItemType.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Item .
        private string _FilterString_Item;
        public string FilterString_Item
        {
            get { return _FilterString_Item; }
            set
            {
                _FilterString_Item = value;
                RaisePropertyChanged("FilterString_Item");
                FilterCollection_Item();
            }
        }
        private void FilterCollection_Item()
        {
            if (ItemCollection != null)
            {
                _ItemCollection.Refresh();
            }
        }
        public bool Filter_Item(object obj)
        {
            var data = obj as MM_S010_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_Item))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_FilterString_Item.ToLower())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_FilterString_Item.ToLower())) ||
                           (data.StockUnt != null && data.StockUnt.ToString().ToLower().Contains(_FilterString_Item.ToLower())) ||
                           (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_FilterString_Item.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . UOM .
        private string _filterString_UOM;
        public string FilterString_UOM
        {
            get { return _filterString_UOM; }
            set
            {
                _filterString_UOM = value;
                RaisePropertyChanged("FilterString_UOM");
                FilterCollection_UOM();
            }
        }
        private void FilterCollection_UOM()
        {
            if (UOMCollection != null)
            {
                _UOMCollection.Refresh();
            }
        }
        public bool Filter_UOM(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_UOM))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_UOM.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Make
        private string _filterStringMake;
        private void FilterCollectionMake()
        {
            if (_MakeCollection != null)
            {
                _MakeCollection.Refresh();
            }
        }
        public string FilterStringMake
        {
            get { return _filterStringMake; }
            set
            {
                _filterStringMake = value;
                RaisePropertyChanged("FilterStringMake");
                FilterCollectionMake();
            }
        }
        public bool FilterMake(object obj)
        {
            var data = obj as ADM_M030_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMake))
                {
                    return data.parametervalue != null && data.parametervalue.ToString().ToLower().Contains(_filterStringMake.ToLower());
                }
                return true;
            }
            return false;
        }

        #endregion

        #region . BackFlip .
        private string _filterString_Backflip;
        public string FilterString_Backflip
        {
            get { return _filterString_Backflip; }
            set
            {
                _filterString_Backflip = value;
                RaisePropertyChanged("FilterString_Backflip");
                FilterCollection_Backflip();
            }
        }
        private void FilterCollection_Backflip()
        {
            if (_BackflipCollection != null)
            {
                _BackflipCollection.Refresh();
            }
        }
        public bool Filter_Backflip(object obj)
        {
            var data = obj as MM_S010_BackFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Backflip))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_Backflip.ToLower()) ||
                            data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_Backflip.ToLower()) ||
                            data.plann_date != null && data.plann_date.ToString().ToLower().Contains(_filterString_Backflip.ToLower()) ||
                            data.post_date != null && data.post_date.ToString().ToLower().Contains(_filterString_Backflip.ToLower())
                           );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Ink .

        private string _FilterStringInk;
        public string FilterStringInk
        {
            get { return _FilterStringInk; }
            set
            {
                _FilterStringInk = value;
                RaisePropertyChanged("FilterStringInk");
                Filter_Ink();
            }
        }
        private void Filter_Ink()
        {
            if (_InkCollection != null)
            {
                _InkCollection.Refresh();
            }
        }
        public bool Filter_Ink(object obj)
        {
            var data = obj as ZADM_M006_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringInk))
                {
                    return (data.ink != null && data.ink.ToString().ToLower().Contains(_FilterStringInk.ToLower())) ||
                           (data.desc != null && data.desc.ToString().ToLower().Contains(_FilterStringInk.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region . Ild .
        private string _FilterStringIld;
        public string FilterStringIld
        {
            get { return _FilterStringIld; }
            set
            {
                _FilterStringIld = value;
                RaisePropertyChanged("FilterStringIld");
                Filter_Ild();
            }
        }
        private void Filter_Ild()
        {
            if (_IldCollection != null)
            {
                _IldCollection.Refresh();
            }
        }
        public bool Filter_Ild(object obj)
        {
            var data = obj as ZADM_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringIld))
                {
                    return (data.ild != null && data.ild.ToString().ToLower().Contains(_FilterStringIld.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region . Grade .
        private string _FilterStringGrade;
        public string FilterStringGrade
        {
            get { return _FilterStringGrade; }
            set
            {
                _FilterStringGrade = value;
                RaisePropertyChanged("FilterStringGrade");
                Filter_Grade();
            }
        }
        private void Filter_Grade()
        {
            if (_GradeCollection != null)
            {
                _GradeCollection.Refresh();
            }
        }
        public bool Filter_Grade(object obj)
        {
            var data = obj as ADM_M045_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringGrade))
                {
                    return (data.grade_code != null && data.grade_code.ToString().ToLower().Contains(_FilterStringGrade.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . UOM1 .
        private string _filterString_UOM1;
        public string FilterString_UOM1
        {
            get { return _filterString_UOM1; }
            set
            {
                _filterString_UOM1 = value;
                RaisePropertyChanged("FilterString_UOM1");
                FilterCollection_UOM1();
            }
        }
        private void FilterCollection_UOM1()
        {
            if (UOMCollection1 != null)
            {
                _UOMCollection1.Refresh();
            }
        }
        public bool Filter_UOM1(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_UOM1))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_UOM1.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter For Search Box
        private string _FilterStringSearchItems = "";
        public string FilterStringSearchItems
        {
            get { return _FilterStringSearchItems; }
            set
            {
                _FilterStringSearchItems = value;
                RaisePropertyChanged("FilterStringSearchItems");
                FilterCollectionSearchItems();
            }
        }
        private void FilterCollectionSearchItems()
        {
            try
            {
                ItemCollection = CollectionViewSource.GetDefaultView(ItemsEntity);
                ItemCollection.Filter = new Predicate<object>(FilterItemSearch);
                if (_ItemCollection != null)
                {
                    _ItemCollection.Refresh();
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
        public bool FilterItemSearch(object obj)
        {
            var data = obj as MM_S010_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringSearchItems))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_FilterStringSearchItems.ToString()) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_FilterStringSearchItems.ToString().ToLower())) ||
                           (data.make != null && data.make.ToString().ToLower().Contains(_FilterStringSearchItems.ToString().ToLower())) ||
                           (data.type != null && data.type.ToString().ToLower().Contains(_FilterStringSearchItems.ToString()))) ||
                           (data.grade != null && data.grade.ToString().ToLower().Contains(_FilterStringSearchItems.ToString().ToLower())) ||
                           (data.prebook_qty != null && data.prebook_qty.ToString().ToLower().Contains(_FilterStringSearchItems.ToString().ToLower())) ||
                           (data.rate != null && data.rate.ToString().ToLower().Contains(_FilterStringSearchItems.ToString().ToLower())) ||
                           (data.qty_unit_entry != null && data.qty_unit_entry.ToString().ToLower().Contains(_FilterStringSearchItems.ToString().ToLower())) ||
                           (data.qty_diff != null && data.qty_diff.ToString().ToLower().Contains(_FilterStringSearchItems.ToString().ToLower())) ||
                           (data.shortage_access != null && data.shortage_access.ToString().ToLower().Contains(_FilterStringSearchItems.ToString().ToLower())) ||
                           (data.varience != null && data.varience.ToString().ToLower().Contains(_FilterStringSearchItems.ToString().ToLower())) ||
                           (data.book_value != null && data.book_value.ToString().ToLower().Contains(_FilterStringSearchItems.ToString().ToLower())) ||
                           (data.phy_count_value != null && data.phy_count_value.ToString().ToLower().Contains(_FilterStringSearchItems.ToString().ToLower())) ||
                           (data.remark != null && data.remark.ToString().ToLower().Contains(_FilterStringSearchItems.ToString().ToLower())) ||
                           (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_FilterStringSearchItems.ToString().ToLower()));

                }
                return true;
            }
            return false;
        }
        #endregion

        #endregion

        #region User Defined Functions
        private void CheckAll(bool select)
        {
            int flag = 0;
            try
            {
                if (select == true)
                {
                    foreach (var o in ItemsEntity)
                    {
                        if (o.ItemCode != "" && o.ItemCode != null)
                        {
                            o.check = true;
                        }
                        else
                        {
                            flag++;
                        }
                    }
                }
                else
                {
                    foreach (var o in ItemsEntity)
                    {
                        o.check = false;
                    }
                }
                if (ItemsEntity.Count == 0 || ItemsEntity == null)
                {
                    flag++;
                }
            }
            catch
            { }
            if (flag > 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Item First", this.Title);
                showMessageService.ShowMessage();
                MasterEntity.ChkAll = false;
            }
        }
        private void DefaultValues()
        {
            MasterEntity.client = AppSessionState.client;
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_cat = "PS";
            MasterEntity.doc_type = "PS";
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.t_status = "001";
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.post_date = DateTime.Now;
            MasterEntity.plann_date = DateTime.Now;
            MasterEntity.store_code = MStoreLoc;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
        }
        private void LoadInitialData()
        {
            try
            {
                MasterEntity.doc_cat = "PS";
                MasterEntity.doc_type = "PS";

                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_MM_S010>(MC, Request, "PhysicalStock", "SCM", "LoadAll", 0, "");

                var BackFlip = (from o in MC.BackFlipEntity where o.user_source1 != "FG" select o).ToList();
                #region Command Initialization
                cmdInsertCompany = new RelayCommand<object>(items => { if (items == null) { return; } InsertCompany(items); });
                cmdInsertPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
                cmdInsertFinyear = new RelayCommand<object>(items => { if (items == null) { return; } InsertFinYear(items); });
                cmdInsertPostPeriod = new RelayCommand<object>(items => { if (items == null) { return; } InsertPostPeriod(items); });
                cmdInsertMStoreLoc = new RelayCommand<object>(items => { if (items == null) { return; } InsertMStoreLoc(items); });
                cmdInsertCategory = new RelayCommand<object>(items => { if (items == null) { return; } InsertCategory(items); });
                cmdInsertSubCategory = new RelayCommand<object>(items => { if (items == null) { return; } InsertSubCategory(items); });
                cmdInsertItemType = new RelayCommand<object>(items => { if (items == null) { return; } InsertItemType(items); });
                cmdInsertSubItemType = new RelayCommand<object>(items => { if (items == null) { return; } InsertSubItemType(items); });
                cmdLoad = new RelayCommand(() => { LoadItemDetails(); });
                cmdInsertItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara, true, true, true); });
                cmdInsertUOM = new RelayCommand<object>(items => { if (items == null) { return; } InsertUOM(items, false, true, true); });
                cmdInsertUOM1 = new RelayCommand<object>(items => { if (items == null) { return; } InsertUOM1(items); });
                CheckedCommand = new RelayCommand<bool>(CheckAll);
                cmdMake = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertMake(cmdPara, false, true, true); });
                CmdDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
                cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara); });
                MM_S010.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
                MM_S010_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

               
                #endregion

                FlipGridData = BackFlip.ToList();
                BackflipCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                BackflipCollection.Filter = new Predicate<object>(Filter_Backflip);
                StringListBackflip = FlipGridData.Select(x => x.doc_no).ToList();

                CompanyList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                CompanyCollection = CollectionViewSource.GetDefaultView(CompanyList);
                CompanyCollection.Filter = new Predicate<object>(Filter_Company);
                StringListCompany = CompanyList.Select(x => x.comp_code).ToList();

                plantList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                plantCollection = CollectionViewSource.GetDefaultView(plantList);
                plantCollection.Filter = new Predicate<object>(Filter_Plant);
                StringListplant = plantList.Select(x => x.location_Id).ToList();

                PostPeriodCollection = CollectionViewSource.GetDefaultView(MC.PostPeriod);
                PostPeriodCollection.Filter = new Predicate<object>(Filter_PostPeriod);
                stringListPostPeriod = MC.PostPeriod.Select(x => x.posting_period).ToList();

                StoreLocList = (List<MM_M001>)AppSessionState.store_location;
                StoreLocCollection = CollectionViewSource.GetDefaultView(StoreLocList);
                StoreLocCollection.Filter = new Predicate<object>(Filter_StoreLoc);
                //store_location = (from o in StoreLocList
                //                  where o.location_Id == AppSessionState.location_Id && o.default_storage_loc == Convert.ToBoolean(1)
                //                  select o.store_code).ToList()[0];
                //StringListStoreLoc = StoreLocList.Select(x => x.store_code).ToList();
                //MStoreLoc = store_location;
                //StoreLocList = (List<MM_M001>)AppSessionState.store_location;
                //if ((from o in StoreLocList
                //     where o.location_Id == AppSessionState.location_Id //&& o.default_storage_loc == Convert.ToBoolean(1)
                //     select o.store_code).ToList().Count == 1)
                //{
                //    store_location = (from o in StoreLocList where o.location_Id == AppSessionState.location_Id select o.store_code).ToList()[0];
                //}
                if (StoreLocList.Count == 1)
                {
                    store_location = StoreLocList[0].store_code;
                }

                MStoreLocCollection = CollectionViewSource.GetDefaultView(StoreLocList);
                MStoreLocCollection.Filter = new Predicate<object>(Filter_MStoreLoc);

                var Category = (from o in MC.CategoryList where o.CatCode != "FG" select o).ToList();
                CategoryCollection = CollectionViewSource.GetDefaultView(Category);
                CategoryCollection.Filter = new Predicate<object>(Filter_Category);
                StringListCategory = Category.Select(x => x.CatCode).ToList();

                UOMCollection = CollectionViewSource.GetDefaultView(MC.UOMList);
                UOMCollection.Filter = new Predicate<object>(Filter_UOM);
                StringListUom = MC.UOMList.Select(x => x.unit_code).ToList();

                List<ADM_M030_P> makelist = (from o in MC.ParamValueList where o.para_code == "1002" select o).ToList();
                MakeCollection = CollectionViewSource.GetDefaultView(makelist);
                MakeCollection.Filter = new Predicate<object>(FilterMake);
                StringListMake = makelist.Select(x => x.parametervalue).ToList();

                var Typelist = (from o in MC.ParamValueList where o.para_code == "1001" select o).ToList();
                TypeCollection = CollectionViewSource.GetDefaultView(Typelist.ToList());

                var matconlist = (from o in MC.ParamValueList where o.para_code == "1003" select o).ToList();
                MatConditionCollection = CollectionViewSource.GetDefaultView(matconlist.ToList());

                UOMCollection1 = CollectionViewSource.GetDefaultView(MC.UOMList);
                UOMCollection1.Filter = new Predicate<object>(Filter_UOM1);
                StringListUom1 = MC.UOMList.Select(x => x.unit_code).ToList();

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
        private void LoadItemDetails()
        {
            try
            {
                if (Validation1() == true)
                {
                    if (MasterEntity.doc_no == null || MasterEntity.doc_no == "")
                    {
                        MasterEntity.NewRecord = true;
                    }
                    else
                    {
                        MasterEntity.NewRecord = false;
                    }
                    string RequestParameter = "LoadItemDetails" + "!@" + MasterEntity.doc_cat + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.user_source1 + "!@" + MasterEntity.SubCatCode + "!@" + MasterEntity.ItemTypeCd + "!@" + MasterEntity.SubItemTpCd + "!@" + MasterEntity.unit_code + "!@" + Convert.ToDateTime(MasterEntity.post_date).ToString("MM/dd/yyyy") + "!@" + MasterEntity.Count + "!@" + MasterEntity.LoadItems + "!@" + MasterEntity.NewRecord + "!@" + MasterEntity.doc_no + "!@" + MasterEntity.Grade + "!@" + MasterEntity.localimport;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_MM_S010>(MCTemp, RequestParameter, "PhysicalStock", "SCM", "LoadAll", 0, "");

                    ItemsEntity.Clear();
                    if (MasterEntity.ManualEntry == true)
                    {
                        ItemCollection = CollectionViewSource.GetDefaultView(MCTemp.ItemEntity);
                        ItemCollection.Filter = new Predicate<object>(Filter_Item);
                        StringListItem = MCTemp.ItemEntityPop.Select(x => x.ItemCode).ToList();
                    }
                    else
                    {
                        ItemsEntity = MCTemp.ItemEntity;
                    }
                    for (int i = 0; i < ItemsEntity.Count; i++)
                    {
                        ItemsEntity[i].make = MCTemp.ItemEntity[i].grade;
                        ItemsEntity[i].type = MCTemp.ItemEntity[i].ink;
                        ItemsEntity[i].mat_cond = MCTemp.ItemEntity[i].ild;
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
        private void InsertCompany(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M002 POPUPEntityObject = null;
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
                            { POPUPEntityObject = CompanyList.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.comp_code = POPUPEntityObject.comp_code;
                    MasterEntity.CompName = POPUPEntityObject.CompName;
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
        private void InsertPlant(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;
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
                            { POPUPEntityObject = plantList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
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
        private void InsertFinYear(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M001A_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.FinYear.Where(x => x.fin_year.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M001A_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.fin_year = POPUPEntityObject.fin_year;
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
        private void InsertPostPeriod(object InputValue)
        {
            try
            {
                string Request = "";
                ACC_M001A_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.PostPeriod.Where(x => x.posting_period.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_M001A_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.posting_period = POPUPEntityObject.posting_period;
                    MasterEntity.fin_year = POPUPEntityObject.fin_year;
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
        private void InsertMStoreLoc(object InputValue)
        {
            try
            {
                string Request = "";
                MM_M001 POPUPEntityObject = null;
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
                            { POPUPEntityObject = StoreLocList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M001>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MStoreLoc = POPUPEntityObject.store_code;
                    MasterEntity.store_code = MStoreLoc;
                    MasterEntity.store_name = POPUPEntityObject.store_name;
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
        private void InsertCategory(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M018_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.CategoryList.Where(x => x.CatCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M018_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.user_source1 = POPUPEntityObject.CatCode;
                    MasterEntity.CatName = POPUPEntityObject.CatName;

                    if (POPUPEntityObject.CatCode != "" || POPUPEntityObject.CatCode != null)
                    {
                        var abc = from data in MC.SubCategoryList
                                  where data.CatCode == POPUPEntityObject.CatCode
                                  select data;

                        SubCategoryCollection = CollectionViewSource.GetDefaultView(abc.ToList());
                        SubCategoryCollection.Filter = new Predicate<object>(Filter_SubCategory);
                        StringListSubCategory = MC.SubCategoryList.Select(x => x.SubCatCode).ToList();
                    }
                    else
                    {
                        SubCategoryCollection = CollectionViewSource.GetDefaultView(MC.SubCategoryList.ToList());
                        SubCategoryCollection.Filter = new Predicate<object>(Filter_SubCategory);
                        StringListSubCategory = MC.SubCategoryList.Select(x => x.SubCatCode).ToList();
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
        private void InsertSubCategory(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M019_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.SubCategoryList.Where(x => x.SubCatCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M019_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.SubCatCode = POPUPEntityObject.SubCatCode;
                    MasterEntity.SubCatName = POPUPEntityObject.SubCatName;
                    if (POPUPEntityObject.SubCatCode != "" && POPUPEntityObject.SubCatCode != null)
                    {
                        var myItem = (from o in MC.ItemTypeList
                                      where o.SubCatCode == POPUPEntityObject.SubCatCode
                                      select o).ToList();

                        ItemTypeCollection = CollectionViewSource.GetDefaultView(myItem.ToList());
                        ItemTypeCollection.Filter = new Predicate<object>(Filter_ItemType);
                        StringListItemType = MC.ItemTypeList.Select(x => x.ItemTypeCd).ToList();
                    }
                    else
                    {
                        ItemTypeCollection = CollectionViewSource.GetDefaultView(MC.ItemTypeList.ToList());
                        ItemTypeCollection.Filter = new Predicate<object>(Filter_ItemType);
                        StringListItemType = MC.ItemTypeList.Select(x => x.ItemTypeCd).ToList();
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
        private void InsertItemType(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M015_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.ItemTypeList.Where(x => x.ItemTypeCd.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M015_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.ItemTypeCd = POPUPEntityObject.ItemTypeCd;
                    MasterEntity.ItemTypeNm = POPUPEntityObject.ItemTypeNm;
                    if (POPUPEntityObject.ItemTypeCd != "" && POPUPEntityObject.ItemTypeCd != null)
                    {
                        var myItem = (from o in MC.SubItemTypeList
                                      where o.ItemTypeCd == POPUPEntityObject.ItemTypeCd
                                      select o).ToList();

                        SubItemTypeCollection = CollectionViewSource.GetDefaultView(myItem.ToList());
                        SubItemTypeCollection.Filter = new Predicate<object>(Filter_SubItemType);
                        StringListSubItemType = MC.SubItemTypeList.Select(x => x.SubItemTpCd).ToList();
                    }
                    else
                    {
                        SubItemTypeCollection = CollectionViewSource.GetDefaultView(MC.SubItemTypeList.ToList());
                        SubItemTypeCollection.Filter = new Predicate<object>(Filter_SubItemType);
                        StringListSubItemType = MC.SubItemTypeList.Select(x => x.SubItemTpCd).ToList();
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
        private void InsertSubItemType(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M016_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.SubItemTypeList.Where(x => x.SubItemTpCd.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M016_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.SubItemTpCd = POPUPEntityObject.SubItemTpCd;
                    MasterEntity.SubItemTpNm = POPUPEntityObject.SubItemTpNm;

                    var myItem = (from o in MC.itemsList
                                  where o.SubItenTpCd == POPUPEntityObject.SubItemTpCd
                                  select o).ToList();
                    ItemCollection = CollectionViewSource.GetDefaultView(myItem.ToList());
                    ItemCollection.Filter = new Predicate<object>(Filter_Item);
                    StringListItem = MC.itemsList.Select(x => x.ItemCode).ToList();
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
        private void InsertItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                MM_S010_A POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ItemEntityPop.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<MM_S010_A>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_S010_A>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (dgSelectedIndexItem != -1)
                    {
                        var InputValueIfExists = ItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                        int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                        if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                        {
                            ItemsEntity.Add(new MM_S010_A()
                            {
                                id = 0,
                                ItemCode = POPUPEntityObject.ItemCode,
                                ItemName = POPUPEntityObject.ItemName,
                                SubCatCode = POPUPEntityObject.SubCatCode,
                                StockUnt = Convert.ToBoolean(POPUPEntityObject.StockUnt),
                                location_Id = AppSessionState.location_Id,
                                sku = POPUPEntityObject.sku,
                                unit_code = POPUPEntityObject.unit_code,
                                comp_code = AppSessionState.comp_code,
                                prebook_qty = POPUPEntityObject.prebook_qty,
                                store_code = MStoreLoc,
                                fin_year = MasterEntity.fin_year,
                                posting_period = MasterEntity.posting_period,
                                t_status = "001",
                                make = POPUPEntityObject.grade,
                                type = POPUPEntityObject.ink,
                                mat_cond = POPUPEntityObject.ild,
                                qty_unit_entry = POPUPEntityObject.qty_unit_entry,
                                active = true,
                                rate = POPUPEntityObject.rate,
                                post_date = POPUPEntityObject.post_date,
                                quantity = POPUPEntityObject.quantity,
                                entry_unit = POPUPEntityObject.entry_unit,
                                diff_amt = POPUPEntityObject.diff_amt,
                                user_source2 = POPUPEntityObject.user_source2,
                                varience = POPUPEntityObject.varience,
                            });
                        }
                        else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                        {
                            if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                            {
                                ItemsEntity[dgSelectedIndexItem].ItemCode = POPUPEntityObject.ItemCode;
                                ItemsEntity[dgSelectedIndexItem].ItemName = POPUPEntityObject.ItemName;
                                ItemsEntity[dgSelectedIndexItem].SubCatCode = POPUPEntityObject.SubCatCode;
                                ItemsEntity[dgSelectedIndexItem].StockUnt = Convert.ToBoolean(POPUPEntityObject.StockUnt);
                                ItemsEntity[dgSelectedIndexItem].sku = POPUPEntityObject.sku;
                                ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                                ItemsEntity[dgSelectedIndexItem].prebook_qty = POPUPEntityObject.prebook_qty;
                                ItemsEntity[dgSelectedIndexItem].store_code = MStoreLoc;
                                ItemsEntity[dgSelectedIndexItem].make = POPUPEntityObject.grade;
                                ItemsEntity[dgSelectedIndexItem].type = POPUPEntityObject.ink;
                                ItemsEntity[dgSelectedIndexItem].mat_cond = POPUPEntityObject.ild;
                                ItemsEntity[dgSelectedIndexItem].qty_unit_entry = POPUPEntityObject.qty_unit_entry;
                                ItemsEntity[dgSelectedIndexItem].active = true;
                                ItemsEntity[dgSelectedIndexItem].rate = POPUPEntityObject.rate;
                                ItemsEntity[dgSelectedIndexItem].post_date = POPUPEntityObject.post_date;
                                ItemsEntity[dgSelectedIndexItem].quantity = POPUPEntityObject.quantity;
                                //ItemsEntity[dgSelectedIndexItem].entry_unit = MasterEntity.unit_code;
                                ItemsEntity[dgSelectedIndexItem].diff_amt = POPUPEntityObject.diff_amt;
                                ItemsEntity[dgSelectedIndexItem].user_source2 = POPUPEntityObject.user_source2;
                                ItemsEntity[dgSelectedIndexItem].varience = POPUPEntityObject.varience;
                            }
                            else if (ItemsEntity[dgSelectedIndexItem].ItemCode != POPUPEntityObject.ItemCode)
                            {
                                ItemsEntity[dgSelectedIndexItem].ItemCode = "";
                                ItemsEntity[dgSelectedIndexItem].ItemName = "";
                            }
                        }
                        Calculation(true);
                    }
                }
                #region Clear Empty Row
                MM_S010_A newObj = new MM_S010_A();
                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
                    {
                        ItemsEntity.RemoveAt(i);
                        if (ItemsEntity.Count == 0)
                        {
                            ItemsEntity.Add(newObj);
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
        private void InsertUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UOMList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                        {
                            ItemsEntity[dgSelectedIndexItem].unit_code = "";
                        }
                    }
                }
                #region Clear Empty Row
                MM_S010_A newObj = new MM_S010_A();
                for (int i = ItemsEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
                    if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
                    {
                        ItemsEntity.RemoveAt(i);
                        if (ItemsEntity.Count == 0)
                        {
                            ItemsEntity.Add(newObj);
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
        private void InsertUOM1(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.UOMList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.unit_code = POPUPEntityObject.unit_code;
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
        //Below 4 methods are for calculations of physical stock
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            //////////////////////////////////Temp Test
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (MM_S010_A item in e.NewItems)
                    item.PropertyChanged += this.MyType_PropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (MM_S010_A item in e.OldItems)
                    item.PropertyChanged -= this.MyType_PropertyChanged;

            /////////////////////////////////Temp Test End
            //different kind of changes that may have occurred in collection
            if (e.Action == NotifyCollectionChangedAction.Add && ItemsEntity.Count > 0)
            {
                foreach (MM_S010_A item in e.NewItems)
                {
                    //Adde items Schedules Default Values from Items Entity
                    if (ItemsEntity.Count > 0 && ItemsEntity.Count > dgSelectedIndexItem)
                    {
                        item.t_status = "001";
                        item.editby = AppSessionState.UserID;
                        item.location_Id = AppSessionState.location_Id;
                        item.comp_code = AppSessionState.comp_code;
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                }
                if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItemItem].HasErrors;*/
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
                this.ErrorExist = false;/*MasterEntity.HasErrors;*/
                if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItemItem].HasErrors;*/
                }
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            { }
            if (e.Action == NotifyCollectionChangedAction.Move)
            {
            }
        }
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "prebook_qty" || e.PropertyName == "qty_unit_entry" || e.PropertyName == "rate")
            {
                Calculation(true);
            }
            if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
            }
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false;/*MasterEntity.HasErrors;*/
            if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = false; /*ItemsEntity[dgSelectedIndexItemItem].HasErrors;*/
            }

        }
        private void Calculation(bool compute)
        {
            try
            {
                if (compute == true)
                {
                    if (ItemsEntity.Count != null && ItemsEntity.Count > 0)
                    {
                        for (int i = 0; i < ItemsEntity.Count; i++)
                        {
                            ItemsEntity[i].active = true;
                            if (ItemsEntity[i].active != false)
                            {
                                ItemsEntity[i].qty_diff = (ItemsEntity[i].prebook_qty) - (ItemsEntity[i].qty_unit_entry);
                                ItemsEntity[i].shortage_access = (ItemsEntity[i].qty_unit_entry) - (ItemsEntity[i].prebook_qty);
                                if (ItemsEntity[i].prebook_qty != 0)
                                {
                                    ItemsEntity[i].varience = ((ItemsEntity[i].qty_diff) / (ItemsEntity[i].prebook_qty)) * 100;
                                }
                                ItemsEntity[i].book_value = (ItemsEntity[i].prebook_qty) * (ItemsEntity[i].rate);
                                ItemsEntity[i].phy_count_value = (ItemsEntity[i].qty_unit_entry) * (ItemsEntity[i].rate);
                            }
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
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            if (sender.ToString() == "qty_unit_entry" || sender.ToString() == "rate")
            {
                if (ItemsEntity.Count > 0 && dgSelectedIndexItem != -1 && dgSelectedIndexItem < ItemsEntity.Count)
                {
                    ItemsEntity[dgSelectedIndexItem].active = true;
                }
                Calculation(true);
            }
            if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = false;/*ItemsEntity[dgSelectedIndexItem].HasErrors;*/
            }
            //this.ErrorExist = false; /*MasterEntity.HasErrors;*/
        }
        private void InsertMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M030_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.ParamValueList.Where(x => x.parametervalue.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M030_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M030_P>().ToList()[0];
                    }
                }
                #endregion
                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.make == POPUPEntityObject.parametervalue).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.make == POPUPEntityObject.parametervalue).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].make = POPUPEntityObject.parametervalue;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].make != POPUPEntityObject.parametervalue)
                        {
                            ItemsEntity[dgSelectedIndexItem].make = "";
                        }
                    }
                    #region Clear Empty Row
                    MM_S010_A newObj = new MM_S010_A();
                    for (int i = ItemsEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = ItemsEntity[i].ComparePropertiesTo(newObj);
                        if (ItemsEntity[i].ComparePropertiesTo(newObj) == true && ItemsEntity.Count > 1)
                        {
                            ItemsEntity.RemoveAt(i);
                            if (ItemsEntity.Count == 0)
                            {
                                ItemsEntity.Add(newObj);
                            }
                        }
                    }
                    #endregion
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
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i && ItemsEntity[dgSelectedIndexItem].id == 0)
                {
                    ItemsEntity.RemoveAt(i);
                    Calculation(true);
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
        private void GenerateSku()
        {
            string makecode = "";
            string typecode = "";
            string matconcode = "";
            foreach (var o in ItemList)
            {
                if (o.id == 0)
                {
                    makecode = "";
                    typecode = "";
                    matconcode = "";
                    if (o.make != null && o.make != "" && o.type != null && o.type != "" && o.mat_cond != null && o.mat_cond != "")
                    {
                        makecode = MC.ParamValueList.Where(X => X.parametervalue.Trim() == o.make.Trim() && X.para_code == "1002").Select(x => x.value_code).FirstOrDefault();
                        typecode = MC.ParamValueList.Where(X => X.parametervalue.Trim() == o.type.Trim() && X.para_code == "1001").Select(x => x.value_code).FirstOrDefault();
                        matconcode = MC.ParamValueList.Where(X => X.parametervalue.Trim() == o.mat_cond.Trim() && X.para_code == "1003").Select(x => x.value_code).FirstOrDefault();

                        o.sku = makecode + "/" + typecode + "/" + matconcode;
                        o.sku_desc = "Make:" + o.make + "\t" + "Type:" + o.type + "\t" + "MaterialCondition:" + o.mat_cond;
                    }
                }
            }
        }
        private bool Validation()
        {
            if (MasterEntity.posting_period == null || MasterEntity.posting_period == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Posting Period is Required");
                showMessageService.ShowMessage();
                return false;
            }
            if (ItemsEntity.Count < 1)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Item Code is Required");
                showMessageService.ShowMessage();
                return false;
            }
            if (ItemList.Count < 1)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Check The Check Box To Save The Record");
                showMessageService.ShowMessage();
                return false;
            }
            else
            {
                GenerateSku();
                #region . Validation for Item Duplication, null Unit Code and Null or 0 Quantity For All Active Unsaved Items .

                foreach (var o in ItemList)
                {
                    int flag = 0;
                    if (o.id == 0 && o.active == true)
                    {
                        foreach (var p in ItemList)
                        {
                            if (o.ItemCode == p.ItemCode && o.sku == p.sku && o.sku_desc == p.sku_desc && p.active == true)
                            {
                                flag++;
                            }
                        }
                    }
                    if (o.ItemCode != null && o.ItemCode != "")
                    {
                        if (o.unit_code == null || o.unit_code == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Enter Valid Unit Code for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.make == null || o.make == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select The Make");
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.type == null || o.type == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select The Type");
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.mat_cond == null || o.mat_cond == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select The Material Condition");
                            showMessageService.ShowMessage();
                            return false;
                        }
                    }
                }
                #endregion
            }
            return true;
        }
        private bool Validation1()
        {
            if (MasterEntity.user_source1 == null || MasterEntity.user_source1 == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Category Code");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.LoadItems == null && EnableComboBox == true || MasterEntity.LoadItems == "" && EnableComboBox == true)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select All/Pending To Load Items");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.posting_period == null || MasterEntity.posting_period == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Posting Period is Required");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.fin_year == null || MasterEntity.fin_year == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Financial Year is Required");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject)
        {
            string Request = "";
            string ParametersStringValue = "";
            MM_S010_BackFlip POPUPEntityObject = null;
            if (ParameterObject.GetType() == typeof(string) && ParameterObject != null)
            {
                ParametersStringValue = ParameterObject.ToString().Trim();
                if (ParametersStringValue.Length > 0)
                {
                    try
                    { Request = "LoadALL" + "!@" + ParametersStringValue; }
                    catch (Exception ex) { }
                }
            }

            else if (ParameterObject != null)
            {
                if (((IEnumerable)ParameterObject).Cast<MM_S010_BackFlip>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)ParameterObject).Cast<MM_S010_BackFlip>().ToList()[0];

                    isNewRecord = false;
                    string RequestParameterData = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + POPUPEntityObject.doc_no;
                    MCTemp1 = repository_MCTemp1.GetDataWithReturnDomainObject<MultipleContext_MM_S010>(MCTemp1, RequestParameterData, "PhysicalStock", "SCM", "", 0, "");

                    if (MCTemp1.MasterEntity.Count > 0 && MCTemp1.ItemEntity.Count > 0)
                    {
                        MasterEntity.ts_code = ts_code_vm;
                        MasterEntity = MCTemp1.MasterEntity[0];
                        ItemsEntity = MCTemp1.ItemEntity;
                        MasterEntity.unit_code = ItemsEntity[0].unit_code;
                        SelectedTabControlIndex = 0;
                        isNewRecord = false;
                        EnableComboBox = true;

                        AttachmentCollection = MCTemp1.AttachmentData;
                        if (MCTemp1.AttachmentData != null)
                        {
                            AttachmentCollection = MCTemp1.AttachmentData;
                        }
                        else
                        {
                            MCTemp1.AttachmentData = new List<COM_T003>();
                        }
                    }
                }
            }
        }
        private void ClearFilterString()// This function is used to clear the search Box On Data Grid
        {
            FilterStringSearchItems = "";
            _FilterStringSearchItems = "";
        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm);
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

    }
}
