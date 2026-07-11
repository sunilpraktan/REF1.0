using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using Reflection.BusinessEntity.Production;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using System.Windows.Controls;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ReflectionSystem;

namespace Reflection.Modules.PPC.ViewModels
{
    public class PPC_M0003_VM : WorkspaceViewModel<ENG_T001>
    {
        #region AutoSuggest Textbox Declaration Region

        private DataGridCellInfo _cellInfo;
        public DataGridCellInfo CellInfo
        {
            get { return _cellInfo; }
            set
            {
                _cellInfo = value;
                SetAutoTextSource(_cellInfo);
                RaisePropertyChanged("CellInfo");
            }
        }

        private void SetAutoTextSource(DataGridCellInfo dgCellInfo)
        {
            if (dgCellInfo != null)
            {
                var column = dgCellInfo.Column as DataGridColumn;
                if (column != null)
                {
                    string headerName = column.Header.ToString();
                    string SourceName = column.SortMemberPath.ToString();
                    if (SourceName == "ItemCode")
                    { ASDefault = ASGridItem; }
                    //else if (SourceName == "defect_type")
                    //{ ASDefault1 = AS_Defect; }


                }
            }
        }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
        private AutoSuggestTextViewModel<dynamic> _ASDefault { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault
        {
            get { return _ASDefault; }
            set
            {
                if (_ASDefault != value)
                {
                    _ASDefault = value; RaisePropertyChanged("ASDefault");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASItem { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItem
        {
            get { return _ASItem; }
            set
            {
                if (_ASItem != value)
                {
                    _ASItem = value; RaisePropertyChanged("ASItem");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUnit
        {
            get { return _ASUnit; }
            set
            {
                if (_ASUnit != value)
                {
                    _ASUnit = value; RaisePropertyChanged("ASUnit");
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

        private AutoSuggestTextViewModel<dynamic> _ASBomCat { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBomCat
        {
            get { return _ASBomCat; }
            set
            {
                if (_ASBomCat != value)
                {
                    _ASBomCat = value; RaisePropertyChanged("ASBomCat");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASGridItem { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGridItem
        {
            get { return _ASGridItem; }
            set
            {
                if (_ASGridItem != value)
                {
                    _ASGridItem = value; RaisePropertyChanged("ASGridItem");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASGridUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGridUnit
        {
            get { return _ASGridUnit; }
            set
            {
                if (_ASGridUnit != value)
                {
                    _ASGridUnit = value; RaisePropertyChanged("ASGridUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAltItem { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAltItem
        {
            get { return _ASAltItem; }
            set
            {
                if (_ASAltItem != value)
                {
                    _ASAltItem = value; RaisePropertyChanged("ASAltItem");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASItemCat { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItemCat
        {
            get { return _ASItemCat; }
            set
            {
                if (_ASItemCat != value)
                {
                    _ASItemCat = value; RaisePropertyChanged("ASItemCat");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASUseInd { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUseInd
        {
            get { return _ASUseInd; }
            set
            {
                if (_ASUseInd != value)
                {
                    _ASUseInd = value; RaisePropertyChanged("ASUseInd");
                }
            }
        }
        #endregion

        #region Declaration

        bool isNewRecord = true;

        WebServiceRepository<ENG_T001> repository = new WebServiceRepository<ENG_T001>();
        WebServiceRepository<MultipleContext_ENG_T001> repository_MC = new WebServiceRepository<MultipleContext_ENG_T001>();
        WebServiceRepository<MultipleContext_ENG_T001> repository_MCTemp = new WebServiceRepository<MultipleContext_ENG_T001>();

        ObjectSerializationService obj = new ObjectSerializationService();

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        private MultipleContext_ENG_T001 _MC = new MultipleContext_ENG_T001();
        public MultipleContext_ENG_T001 MC
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

        private MultipleContext_ENG_T001 _MCTemp = new MultipleContext_ENG_T001();
        public MultipleContext_ENG_T001 MCTemp
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

        private ENG_T001 _MasterEntity;
        public ENG_T001 MasterEntity
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

        private List<ADM_M031_P> _ParameterTemp = new List<ADM_M031_P>();
        public List<ADM_M031_P> ParameterTemp
        {
            get { return _ParameterTemp; }
            set
            {
                if (_ParameterTemp != value)
                {
                    _ParameterTemp = value;
                }
            }
        }

        private List<ADM_M031_P> _SelectedParaValueCollection = new List<ADM_M031_P>();
        public List<ADM_M031_P> SelectedParaValueCollection
        {
            get { return _SelectedParaValueCollection; }
            set
            {
                if (_SelectedParaValueCollection != value)
                {
                    _SelectedParaValueCollection = value;
                    RaisePropertyChanged("SelectedParaValueCollection");
                }
            }
        }

        private bool _parameter;
        public bool parameter
        {
            get { return _parameter; }
            set
            {
                if (_parameter != value)
                {
                    _parameter = value;
                    RaisePropertyChanged("parameter");
                }
            }
        }

        private ObservableCollection<ENG_T001_A> _ItemsEntity;
        public ObservableCollection<ENG_T001_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value; RaisePropertyChanged("ItemsEntity");
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

        #region List

        private List<ENG_T001Flip> _FlipGridData;
        public List<ENG_T001Flip> FlipGridData
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

        private int _ParadgSelectedIndex;
        public int ParadgSelectedIndex
        {
            get
            {
                return _ParadgSelectedIndex;
            }
            set
            {
                if (_ParadgSelectedIndex != value)
                {
                    _ParadgSelectedIndex = value;
                    RaisePropertyChanged("ParadgSelectedIndex");
                }
            }
        }

        private int _dgSelectedIndex;
        public int dgSelectedIndex
        {
            get
            {
                return _dgSelectedIndex;
            }
            set
            {
                if (_dgSelectedIndex != value)
                {
                    _dgSelectedIndex = value;
                    RaisePropertyChanged("dgSelectedIndex");

                }
            }
        }

        #endregion

        #region Collection

        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }

        private ICollectionView _CustomerCollection;
        public ICollectionView CustomerCollection
        {
            get { return _CustomerCollection; }
            set { _CustomerCollection = value; RaisePropertyChanged("CustomerCollection"); }
        }

        private ICollectionView _ItemCollection;
        public ICollectionView ItemCollection
        {
            get { return _ItemCollection; }
            set { _ItemCollection = value; RaisePropertyChanged("ItemCollection"); }
        }

        private ICollectionView _ItemCollectionForGrid;
        public ICollectionView ItemCollectionForGrid
        {
            get { return _ItemCollectionForGrid; }
            set { _ItemCollectionForGrid = value; RaisePropertyChanged("ItemCollectionForGrid"); }
        }

        private ICollectionView _AlternateItemCollection;
        public ICollectionView AlternateItemCollection
        {
            get { return _AlternateItemCollection; }
            set { _AlternateItemCollection = value; RaisePropertyChanged("AlternateItemCollection"); }
        }

        private ICollectionView _UomCollection;
        public ICollectionView UomCollection
        {
            get { return _UomCollection; }
            set { _UomCollection = value; RaisePropertyChanged("UomCollection"); }
        }

        private ICollectionView _UomCollectionForDataDrid;
        public ICollectionView UomCollectionForDataDrid
        {
            get { return _UomCollectionForDataDrid; }
            set { _UomCollectionForDataDrid = value; RaisePropertyChanged("UomCollectionForDataDrid"); }
        }

        private ICollectionView _BomCollection;
        public ICollectionView BomCollection
        {
            get { return _BomCollection; }
            set { _BomCollection = value; RaisePropertyChanged("BomCollection"); }
        }

        private ICollectionView _DocTypeCollection;
        public ICollectionView DocTypeCollection
        {
            get { return _DocTypeCollection; }
            set { _DocTypeCollection = value; RaisePropertyChanged("DocTypeCollection"); }
        }

        private ICollectionView _DataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _DataGridCollection; }
            set { _DataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private ICollectionView _DetailDataCollection;
        public ICollectionView DetailDataCollection
        {
            get { return _DetailDataCollection; }
            set { _DetailDataCollection = value; RaisePropertyChanged("DetailDataCollection"); }
        }

        private ICollectionView _ParameterCollection;
        public ICollectionView ParameterCollection
        {
            get { return _ParameterCollection; }
            set
            {
                _ParameterCollection = value;
                RaisePropertyChanged("ParameterCollection");
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

        List<string> _StringListItem;
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

        List<string> _StringListItemForGrid;
        public List<string> StringListItemForGrid
        {
            get { return _StringListItemForGrid; }
            set
            {
                if (_StringListItemForGrid != value)
                {
                    _StringListItemForGrid = value;
                }
            }
        }

        List<string> _StringListAlternateItem;
        public List<string> StringListAlternateItem
        {
            get { return _StringListAlternateItem; }
            set
            {
                if (_StringListAlternateItem != value)
                {
                    _StringListAlternateItem = value;
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

        List<string> _StringListBom;
        public List<string> StringListBom
        {
            get { return _StringListBom; }
            set
            {
                if (_StringListBom != value)
                {
                    _StringListBom = value;
                }
            }
        }

        List<string> _StringListDocType;
        public List<string> StringListDocType
        {
            get { return _StringListDocType; }
            set
            {
                if (_StringListDocType != value)
                {
                    _StringListDocType = value;
                }
            }
        }



        #endregion

        #region Relay Command Declaration
        public RelayCommand<object> CmdAddCustomer { get; private set; }
        public RelayCommand<object> CmdAddItem { get; private set; }
        public RelayCommand<object> CmdAddItemForGrid { get; private set; }
        public RelayCommand<object> CmdAddAlternateItem { get; private set; }
        public RelayCommand<object> CmdAddUom { get; private set; }
        public RelayCommand<object> CmdAddUomForGrid { get; private set; }
        public RelayCommand<object> CmdAddBom { get; private set; }
        public RelayCommand<object> CmdAddDocType { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CollectionChangedCommand { get; private set; }
        public RelayCommand<IList> SelectionChangedParaValCommand { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<IList> cmdselectionchangeforParameter { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region Constructor
        public PPC_M0003_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            parameter = false;
            MasterEntity = new ENG_T001();
            FlipGridData = new List<ENG_T001Flip>();
            MM_T001.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            ENG_T001_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            ItemsEntity = new ObservableCollection<ENG_T001_A>();

            MasterEntity.ValidateAsync().Wait();

            LoadInitialData();
        }
        public PPC_M0003_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.ts_code_vm = doc_no;
            parameter = false;
            MasterEntity = new ENG_T001();
            FlipGridData = new List<ENG_T001Flip>();
            MM_T001.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            ENG_T001_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            ItemsEntity = new ObservableCollection<ENG_T001_A>();

            MasterEntity.ValidateAsync().Wait();

            LoadInitialData();
        }
        private void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = MasterEntity.HasErrors;
        }
        private void LoadInitialData()
        {
            try
            {

                MasterEntity.doc_cat = "BM";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ENG_T001>(MC, Request, "Bill Of Material", "Production", "LoadInitialData", 0, "");

                #region Command Initialisation
                CmdAddCustomer = new RelayCommand<object>(items => { if (items == null) { return; } InsertCustomer(items, isNewRecord); });
                CmdAddItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
                CmdAddItemForGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItemForGrid(cmdPara, true, true, true); });
                CmdAddAlternateItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertAlternateItem(cmdPara, true, true, true); });
                CmdAddUom = new RelayCommand<object>(items => { if (items == null) { return; } InsertUnit(items); });
                CmdAddUomForGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUnitForGrid(cmdPara, true, true, true); });
                CmdAddBom = new RelayCommand<object>(items => { if (items == null) { return; } InsertBom(items); });
                CmdAddDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocType(items); });
                CollectionChangedCommand = new RelayCommand<object>(items => { if (items == null) { return; } CollectionChanged(items); });
                SelectionChangedParaValCommand = new RelayCommand<IList>(items => { if (items == null) { return; } GetSelectedParaValue(items); });
                CommandLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CmdDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
                cmdselectionchangeforParameter = new RelayCommand<IList>(Items => { if (Items == null) { return; } GetselectedSkuParameter(Items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion

                #region AutoSuggest Initialization
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_POPUP)x).ItemCode);
                TheFilter = (o, prefix) => (((ADM_M022_POPUP)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M022_POPUP)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASItem = new AutoSuggestTextViewModel<dynamic>(MC.ItemDetails, TheFilter, SuggestedValue, "ItemCode", true);
                ASItem.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => ((ADM_M038_B_P)o).unit_code.ToLower().Contains(prefix);
                ASUnit = new AutoSuggestTextViewModel<dynamic>(MC.UOMDetails, TheFilter, SuggestedValue, "unit_code", true);
                ASUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M013_P)x).doc_type);
                TheFilter = (o, prefix) => ((SYS_M013_P)o).doc_type.ToLower().Contains(prefix) || ((SYS_M013_P)o).doc_desc.ToLower().Contains(prefix);
                ASDocType = new AutoSuggestTextViewModel<dynamic>(MC.DocTypeDetails, TheFilter, SuggestedValue, "doc_type", true);
                ASDocType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M050)x).bom_cat);
                TheFilter = (o, prefix) => ((SYS_M050)o).bom_cat.ToLower().Contains(prefix) || ((SYS_M050)o).cat_name.ToLower().Contains(prefix);
                ASBomCat = new AutoSuggestTextViewModel<dynamic>(MC.BOMCategory, TheFilter, SuggestedValue, "bom_cat", true);
                ASBomCat.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_POPUP)x).ItemCode);
                TheFilter = (o, prefix) => (((ADM_M022_POPUP)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M022_POPUP)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASGridItem = new AutoSuggestTextViewModel<dynamic>(MC.ItemDetailsForGrid, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASGridItem.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => ((ADM_M038_B_P)o).unit_code.ToLower().Contains(prefix);
                ASGridUnit = new AutoSuggestTextViewModel<dynamic>(MC.UOMDetails, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASGridUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_POPUP)x).ItemCode);
                TheFilter = (o, prefix) => ((ADM_M022_POPUP)o).ItemCode.ToLower().Contains(prefix) || ((ADM_M022_POPUP)o).ItemName.ToLower().Contains(prefix);
                ASAltItem = new AutoSuggestTextViewModel<dynamic>(MC.ItemDetailsForGrid, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASAltItem.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M041)x).item_cat_bom);
                TheFilter = (o, prefix) => ((SYS_M041)o).item_cat_bom.ToLower().Contains(prefix) || ((SYS_M041)o).cat_desc.ToLower().Contains(prefix);
                ASItemCat = new AutoSuggestTextViewModel<dynamic>(MC.LineCategory, TheFilter, SuggestedValue, "item_cat_bom", "item_cat_bom", true);
                ASItemCat.AutoSuggestVM.IsEmptyValueAllowed = false; ASItemCat.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M040)x).ind_usage);
                TheFilter = (o, prefix) => ((SYS_M040)o).ind_usage.ToLower().Contains(prefix) || ((SYS_M040)o).usage_desc.ToLower().Contains(prefix);
                ASUseInd = new AutoSuggestTextViewModel<dynamic>(MC.Indicator_consumption, TheFilter, SuggestedValue, "ind_usage", "ind_usage", true);
                ASUseInd.AutoSuggestVM.IsEmptyValueAllowed = false; ASUseInd.AutoSuggestVM.IsFreeTextAllowed = false;

                #endregion

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGridData);

                CustomerCollection = CollectionViewSource.GetDefaultView(MC.CustomerDetails);
                CustomerCollection.Filter = new Predicate<object>(Filter_Customer);
                StringListCustomer = MC.CustomerDetails.Select(x => x.PartyId.ToString()).ToList();

                ItemCollection = CollectionViewSource.GetDefaultView(MC.ItemDetails);
                ItemCollection.Filter = new Predicate<object>(Filter_ItemCode);
                StringListItem = MC.ItemDetails.Select(x => x.ItemCode.ToString()).ToList();

                ItemCollectionForGrid = CollectionViewSource.GetDefaultView(MC.ItemDetailsForGrid);
                ItemCollectionForGrid.Filter = new Predicate<object>(FilterAlternateItem);
                StringListAlternateItem = MC.ItemDetailsForGrid.Select(x => x.ItemCode.ToString()).ToList();

                AlternateItemCollection = CollectionViewSource.GetDefaultView(MC.ItemDetailsForGrid);
                AlternateItemCollection.Filter = new Predicate<object>(FilterAlternateItem);
                StringListAlternateItem = MC.ItemDetailsForGrid.Select(x => x.ItemCode.ToString()).ToList();

                UomCollection = CollectionViewSource.GetDefaultView(MC.UOMDetails);
                UomCollection.Filter = new Predicate<object>(Filter_Uom);
                StringListUom = MC.UOMDetails.Select(x => x.unit_code.ToString()).ToList();

                BomCollection = CollectionViewSource.GetDefaultView(MC.BOMCategory);
                BomCollection.Filter = new Predicate<object>(Filter_BomCat);
                StringListBom = MC.BOMCategory.Select(x => x.bom_cat.ToString()).ToList();

                DocTypeCollection = CollectionViewSource.GetDefaultView(MC.DocTypeDetails);
                DocTypeCollection.Filter = new Predicate<object>(Filter_DocType);
                StringListDocType = MC.DocTypeDetails.Select(x => x.doc_type_doc_no.ToString()).ToList();

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
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            string ParametersStringValue = "";
            ENG_T001Flip ParameterEntityObject = null;
            MasterEntity = new ENG_T001();
            ItemsEntity = new ObservableCollection<ENG_T001_A>();

            if (((IEnumerable)ParameterObject).Cast<ENG_T001Flip>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ENG_T001Flip>().ToList()[0];
                Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.doc_no;
                isNewRecord = false;

                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ENG_T001>(MCTemp, Request, "Bill Of Material", "Production", "LoadDocumentByDocumentNumber", 0, "");
                SelectedTabControlIndex = 0;
                if (MCTemp.MasterEntity.Count > 0)
                {
                    MasterEntity = MCTemp.MasterEntity[0];
                    ItemsEntity = MCTemp.ItemsEntity;
                    MasterEntity.ts_code = ts_code_vm;
                }

                SetBusinessEntitiesAfterLoad(ParametersStringValue, "Save");

                AttachmentCollection = MCTemp.AttachmentData;
                if (MCTemp.AttachmentData != null)
                {
                    AttachmentCollection = MCTemp.AttachmentData;
                }
                else
                {
                    MCTemp.AttachmentData = new List<COM_T003>();
                }
            }
            MasterEntity.ts_code = ts_code_vm;
            var msg = new NotificationMessage("PPC_M0003_VM");
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        #endregion

        #region User Defined Function
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_cat = "BM";
            MasterEntity.doc_type = "BM";
            MasterEntity.client = AppSessionState.client;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.t_status = "001";
            MasterEntity.doc_no = "";
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.active = true;
            MasterEntity.fin_year = "16-17";
            MasterEntity.posting_period = "1";
            MasterEntity.counter_no = 1;
            MasterEntity.bom_qty = 1;
            MasterEntity.doc_date = DateTime.UtcNow;
        }
        private void InsertCustomer(object InputValue, bool OverrideValue)
        {
            string Request = "";
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
                            POPUPEntityObject = MC.CustomerDetails.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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
                    { POPUPEntityObject = MC.UOMDetails.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
        private void InsertDocType(object InputValue)
        {
            string Request = "";
            SYS_M013_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DocTypeDetails.Where(x => x.doc_type_doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M013_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.doc_type_user = POPUPEntityObject.doc_type_user;
            }
        }
        private void InsertBom(object InputValue)
        {

            string Request = "";
            SYS_M050 POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BOMCategory.Where(x => x.bom_cat.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M050>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.bom_cat = POPUPEntityObject.bom_cat;
            }
        }
        private void InsertUnit(object InputValue)
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
                        { POPUPEntityObject = MC.UOMDetails.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
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
                        { POPUPEntityObject = MC.ItemDetails.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
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
                MasterEntity.CatCode = POPUPEntityObject.CatCode;
                MasterEntity.unit_code = POPUPEntityObject.unit_code;

            }
        }
        private void InsertItemForGrid(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                        { POPUPEntityObject = MC.ItemDetailsForGrid.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
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
                var InputValueIfExists = ItemsEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());
                //Insert
                if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                {
                    ItemsEntity.Add(new ENG_T001_A()
                    {
                        id = 0,
                        line_id = ItemsEntity.Count() + 1,
                        ItemCode = POPUPEntityObject.ItemCode,
                        ItemName = POPUPEntityObject.ItemName,
                        unit_code = POPUPEntityObject.unit_code,
                        SubCatCode = POPUPEntityObject.SubCatCode,
                        StockUnt = POPUPEntityObject.StockUnt,
                        active = true,
                        location_Id = AppSessionState.location_Id,
                        comp_code = AppSessionState.comp_code,
                        add_by = AppSessionState.UserID,
                        editby = AppSessionState.UserID,
                        t_status = "001"

                    });
                }
                //update
                else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                    {
                        ItemsEntity[dgSelectedIndexItem].ItemCode = POPUPEntityObject.ItemCode;
                        ItemsEntity[dgSelectedIndexItem].ItemName = POPUPEntityObject.ItemName;
                        ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        ItemsEntity[dgSelectedIndexItem].SubCatCode = POPUPEntityObject.SubCatCode;
                        ItemsEntity[dgSelectedIndexItem].StockUnt = POPUPEntityObject.StockUnt;
                        ItemsEntity[dgSelectedIndexItem].location_Id = AppSessionState.location_Id;
                        ItemsEntity[dgSelectedIndexItem].comp_code = AppSessionState.comp_code;
                        ItemsEntity[dgSelectedIndexItem].add_by = AppSessionState.UserID;
                        ItemsEntity[dgSelectedIndexItem].editby = AppSessionState.UserID;
                        ItemsEntity[dgSelectedIndexItem].fin_year = "16-17";
                        ItemsEntity[dgSelectedIndexItem].posting_period = "1";
                        ItemsEntity[dgSelectedIndexItem].active = true;
                        ItemsEntity[dgSelectedIndexItem].t_status = "001";
                        if (!ItemsEntity[dgSelectedIndexItem].line_id.HasValue)
                        {
                            ItemsEntity[dgSelectedIndexItem].line_id = ItemsEntity.Count;
                        }

                    }
                    else if (ItemsEntity[dgSelectedIndexItem].ItemCode != POPUPEntityObject.ItemCode)
                    {
                        ItemsEntity[dgSelectedIndexItem].ItemCode = "";
                        ItemsEntity[dgSelectedIndexItem].ItemName = "";
                    }
                }

            }
        }
        private void InsertAlternateItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                        { POPUPEntityObject = MC.ItemDetailsForGrid.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
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
                var InputValueIfExists = ItemsEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());
                //Insert
                if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                {
                    ItemsEntity.Add(new ENG_T001_A()
                    {
                        id = 0,
                        alternate_ItemCode = POPUPEntityObject.ItemCode,
                        AlternateItemName = POPUPEntityObject.ItemName,

                    });
                }
                //update
                else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                    {
                        ItemsEntity[dgSelectedIndexItem].alternate_ItemCode = POPUPEntityObject.ItemCode;
                        ItemsEntity[dgSelectedIndexItem].AlternateItemName = POPUPEntityObject.ItemName;


                    }
                    else if (ItemsEntity[dgSelectedIndexItem].ItemCode != POPUPEntityObject.ItemCode)
                    {
                        ItemsEntity[dgSelectedIndexItem].alternate_ItemCode = POPUPEntityObject.ItemCode;
                        ItemsEntity[dgSelectedIndexItem].AlternateItemName = POPUPEntityObject.ItemName;

                    }
                }

            }
        }
        private bool Validation()
        {

            if (MasterEntity.ItemCode == null || MasterEntity.ItemCode == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Item Code...");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.bom_cat == null || MasterEntity.bom_cat == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Category of BOM...");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.bom_qty == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Quantity...");
                showMessageService.ShowMessage();
                return false;
            }

            if (ItemsEntity.Count < 1)//when form is blank and we tryy to save the record
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Insert Item In DataGrid........");
                showMessageService.ShowMessage();

                return false;
            }

            #region . Validation for Item Duplication, null Unit Code and Null or 0 Quantity For All Active Unsaved Items .

            foreach (var o in ItemsEntity)
            {
                int flag = 0;
                if (o.id == 0 && o.active == true)
                {
                    foreach (var p in ItemsEntity)
                    {
                        if (o.ItemCode == p.ItemCode && o.sku == p.sku && p.active == true)
                        {
                            flag++;
                        }
                    }
                    if (flag > 1)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                        showMessageService.ShowMessage();
                        return false;
                    }
                }

                if (o.ItemCode != null && o.ItemCode != "")
                {
                    if (o.qty == null || o.qty == 0)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Quantity cannot be null or 0 for item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                        showMessageService.ShowMessage();
                        return false;
                    }

                    if (o.unit_code == null || o.unit_code == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Valid Unit Code for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                        showMessageService.ShowMessage();
                        return false;
                    }

                }
                //#region . Parameter Validation .
                //// Validation For All Parameter Values Selected or Not

                //if (o.StockUnt == true && o.active == true && o.id == 0)
                //{
                //    var paralist = (from p in MC.ParameterDetails where p.SubCatCode == o.SubCatCode select p).ToList();

                //    if (paralist.Count > 0)
                //    {
                //        string[] SkuList = new string[100];           //string array
                //        List<string> SkuListt = new List<string>();    // stringlist

                //        if (o.sku != null && o.sku != "")
                //        {
                //            SkuList = o.sku.Split('/');
                //            SkuListt = SkuList.ToList();

                //            foreach (var item in SkuList)
                //            {
                //                if (item == "")
                //                {
                //                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //                    showMessageService.ButtonSetup = DialogButton.Ok;
                //                    showMessageService.Caption = "Parameter Validation";
                //                    showMessageService.Text = String.Format("All Parameters of item {0} are not selected..!!! \n If you can see All Parameter Values Selected Please Select the Same Values Again ", o.ItemCode);
                //                    showMessageService.ShowMessage();
                //                    return false;
                //                }
                //            }
                //        }
                //        else
                //        {
                //            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //            showMessageService.ButtonSetup = DialogButton.Ok;
                //            showMessageService.Caption = "Parameter Validation";
                //            showMessageService.Text = String.Format("All Parameters of item {0} are not selected\n If you can see All Parameter Value Selected Please Select the Same Values Again ", o.ItemCode);
                //            showMessageService.ShowMessage();
                //            return false;
                //        }
                //    }

                //}
                //#endregion
            }

            #endregion

            return true;
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
        private void CollectionChanged(object DataList)
        {
            string[] TempSkuList = new string[100];
            List<string> TempParaValueList = new List<string>();
            IList list = DataList as IList;
            int a = dgSelectedIndexItem;
            try
            {
                if (ItemsEntity[dgSelectedIndexItem].id == 0 && ItemsEntity.Count > 0 && dgSelectedIndexItem < ItemsEntity.Count && dgSelectedIndexItem != -1)
                {
                    List<ENG_T001_A> SelectedRowlist = list.Cast<ENG_T001_A>().ToList();

                    if (SelectedRowlist[0].ind_sku == true)
                    {
                        var paramlist = (from o in MC.ParameterDetails where o.SubCatCode == SelectedRowlist[0].sub_cat select o).ToList();

                        ParameterTemp = paramlist.ToList();

                        if (paramlist.Count > 0 && ItemsEntity[dgSelectedIndexItem].sku != "" && ItemsEntity[dgSelectedIndexItem].sku != null)
                        {
                            TempSkuList = ItemsEntity[dgSelectedIndexItem].sku.Split('/');

                            for (int i = 0; i < paramlist.Count; i++)
                            {
                                TempParaValueList = (from o in MC.ParameterValueDetails where o.value_code == TempSkuList[i] select o.parametervalue).ToList();
                                if (TempParaValueList.Count > 0)
                                {
                                    paramlist[i].parametervalue = TempParaValueList[0];
                                }
                            }

                            ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                        }
                        else
                        {
                            foreach (var o in ParameterTemp)
                            {
                                o.parametervalue = null; o.value_code = null;
                            }
                            ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                        }

                        if (paramlist.Count > 0) //&& SelectedParaValueCollection.Count != paramlist.Count)
                        {
                            SelectedParaValueCollection = new List<ADM_M031_P>();

                            for (int i = 0; i < paramlist.Count; i++)
                            {
                                SelectedParaValueCollection.Add(new ADM_M031_P()
                                {

                                    dgselectedindex = dgSelectedIndex,
                                    para_code = paramlist[i].para_code,
                                    para_name = paramlist[i].para_name

                                });
                            }


                            if (ItemsEntity[dgSelectedIndexItem].sku_desc != null)
                            {
                                SelectedParaValueCollection = ParameterCollection.Cast<ADM_M031_P>().ToList();

                                foreach (var o in SelectedParaValueCollection)
                                {
                                    o.dgselectedindex = dgSelectedIndex;
                                    foreach (var p in MC.ParameterValueDetails)
                                    {
                                        if (o.para_code == p.para_code && o.parametervalue == p.parametervalue)
                                        {
                                            o.value_code = p.value_code;
                                        }
                                    }
                                }
                            }

                        }
                    }
                }
                else if (ItemsEntity[dgSelectedIndexItem].id != 0 && ItemsEntity.Count > 0 && dgSelectedIndexItem < ItemsEntity.Count)
                {

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
        private void GetSelectedParaValue(IList parameter)
        {
            try
            {

                IList list = parameter as IList;
                List<ADM_M031_P> SelectedParaValueList = list.Cast<ADM_M031_P>().ToList();
                int a = ParadgSelectedIndex;
                int b = dgSelectedIndexItem;
                if (dgSelectedIndexItem != -1 && SelectedParaValueList.Count > 0 && ItemsEntity[dgSelectedIndexItem].StockUnt == true)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0)
                    {
                        #region 
                        if (SelectedParaValueList.Count > 0 && SelectedParaValueList[0].parametervalue != null && SelectedParaValueList[0].parametervalue != "")// && SelectedParaValueCollection.dgselectedindex.contains)
                        {
                            for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                            {
                                if (SelectedParaValueCollection[i].para_code == SelectedParaValueList[0].para_code && SelectedParaValueCollection[i].dgselectedindex <= dgSelectedIndexItem)
                                {
                                    SelectedParaValueCollection[i].parametervalue = SelectedParaValueList[0].parametervalue;

                                    var paravaluetemp = (from o in MC.ParameterValueDetails where o.para_code == SelectedParaValueCollection[i].para_code && o.parametervalue == SelectedParaValueCollection[i].parametervalue select o).ToList();

                                    if (paravaluetemp.Count > 0)
                                    {
                                        SelectedParaValueCollection[i].value_code = paravaluetemp[0].value_code;
                                    }
                                }
                            }

                            // SKU Description
                            GetSkuDescription();

                            //Function for calculating SKU
                            CalculateSku();
                        }
                        #endregion
                    }
                    else if (ItemsEntity[dgSelectedIndexItem].id != 0)
                    {

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
        private void GetSkuDescription()
        {
            try
            {
                if (ItemsEntity[dgSelectedIndexItem].sku_desc == null || ItemsEntity[dgSelectedIndexItem].sku_desc == "")
                {
                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if ((ItemsEntity[dgSelectedIndexItem].sku_desc == "" || ItemsEntity[dgSelectedIndexItem].sku_desc == null) && SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                        {
                            ItemsEntity[dgSelectedIndexItem].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                        else if (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                        {
                            ItemsEntity[dgSelectedIndexItem].sku_desc = ItemsEntity[dgSelectedIndexItem].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                    }
                }
                else
                {
                    ItemsEntity[dgSelectedIndexItem].sku_desc = "";

                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if ((ItemsEntity[dgSelectedIndexItem].sku_desc == "" || ItemsEntity[dgSelectedIndexItem].sku_desc == null) && SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                        {
                            ItemsEntity[dgSelectedIndexItem].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                        }
                        else if (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                        {
                            ItemsEntity[dgSelectedIndexItem].sku_desc = ItemsEntity[dgSelectedIndexItem].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
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
        private void CalculateSku()
        {
            try
            {
                if (ItemsEntity[dgSelectedIndexItem].sku == null || ItemsEntity[dgSelectedIndexItem].sku == "")
                {
                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].sku == "" || ItemsEntity[dgSelectedIndexItem].sku == null)
                        {
                            ItemsEntity[dgSelectedIndexItem].sku = SelectedParaValueCollection[i].value_code;
                        }
                        else
                        {
                            ItemsEntity[dgSelectedIndexItem].sku = ItemsEntity[dgSelectedIndexItem].sku + "/" + SelectedParaValueCollection[i].value_code;
                        }
                    }
                }
                else
                {
                    ItemsEntity[dgSelectedIndexItem].sku = "";

                    for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].sku == "" || ItemsEntity[dgSelectedIndexItem].sku == null)
                        {
                            ItemsEntity[dgSelectedIndexItem].sku = SelectedParaValueCollection[i].value_code;
                        }
                        else
                        {
                            ItemsEntity[dgSelectedIndexItem].sku = ItemsEntity[dgSelectedIndexItem].sku + "/" + SelectedParaValueCollection[i].value_code;
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
        private void GetselectedSkuParameter(Object InputList)
        {
            IList list = InputList as IList;
            try
            {

                if (dgSelectedIndexItem != -1 && ItemsEntity.Count > 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    List<ENG_T001_A> selectedlist = list.Cast<ENG_T001_A>().ToList();

                    if (ItemsEntity.Count > 0)
                    {

                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ItemsEntity[dgSelectedIndexItem].StockUnt == true)
                        {
                            parameter = true;
                        }
                        else
                        {
                            parameter = false;
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
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
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

        #region Abstract Methods
        protected override void OnSaveAction(InquiryActionResult<ENG_T001> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.XmlDataDocument_ENG_T001_A = obj.ObjectToXML(ItemsEntity);

                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ENG_T001>(MasterEntity, "Bill Of Material", "Production");
                    }


                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ENG_T001>(MasterEntity, "Bill Of Material", "Production");
                    }
                    parameter = false;
                    SetBusinessEntitiesAfterLoad("Save", "");
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Data Saved Successfully");
                    showMessageService.ShowMessage();

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

        protected override void OnCreateAction(InquiryActionResult<ENG_T001> result)
        {
            isNewRecord = true;
            parameter = false;
            MasterEntity = new ENG_T001();
            MC.ItemsEntity = new ObservableCollection<ENG_T001_A>();
            MasterEntity.ValidateAsync().Wait();
            ItemsEntity.Clear();
            FlipDataGridCollection.Refresh();

            DefaultValues();
        }

        protected override void OnRemoveAction(InquiryActionResult<ENG_T001> result)
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
                string response = repository.Delete(MasterEntity.doc_no, "Bill Of Material", "Production");


                MasterEntity = new ENG_T001();
                ItemsEntity = new ObservableCollection<ENG_T001_A>();
                isNewRecord = true;
                parameter = false;

                FlipDataGridCollection.Refresh();
            }
        }

        protected override void OnDiscardAction(InquiryActionResult<ENG_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnPrintAction(InquiryActionResult<ENG_T001> result)
        {
            try
            {
                string Request = "BM_Report" + "!@" + MasterEntity.doc_no + "!@" + MasterEntity.unit_code;

                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ENG_T001>(MCTemp, Request, "Bill Of Material", "Production", "LoadAll", 0, "");


                object[] objDataSource = new object[3];
                string[] objDataSourceName = new string[3];

                //MCTemp.MasterEntity.Clear();
                //MCTemp.MasterEntity.Add(MasterEntity);

                objDataSource[0] = MCTemp.RptBillOfMaterial;

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[1] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[2] = Result;

                objDataSourceName[0] = "dsRpt_BillOfMaterial";
                objDataSourceName[1] = "dsCompany";
                objDataSourceName[2] = "dsLocation";

                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\BillOfMaterial.rdlc", getParametersList(), "");
            }
            catch (Exception ex) { }
        }



        protected override void OnFlipAction(InquiryActionResult<ENG_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnHelpAction(InquiryActionResult<ENG_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<ENG_T001> result)
        {
            throw new NotImplementedException();
        }


        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("prepare_by", AppSessionState.Name);
                result.Add("doc_no", MasterEntity.doc_no);
                result.Add("ItemName", MasterEntity.ItemName);
                result.Add("ItemCode", MasterEntity.ItemCode);
                result.Add("bom_name", MasterEntity.bom_name);
                result.Add("doc_date", Convert.ToString(MasterEntity.doc_date));

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
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.doc_no))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MCTemp.AttachmentData, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<ENG_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ENG_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ENG_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ENG_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ENG_T001> result)
        {
            throw new NotImplementedException();
        }

        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            MasterEntity.ts_code = ts_code_vm;
            if (MasterEntity.XmlDataDocument_ENG_T001_A != null)
            {
                MC.ItemsEntity = (ObservableCollection<ENG_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ENG_T001_A, MC.ItemsEntity);
                ItemsEntity.Clear();
                ItemsEntity = MC.ItemsEntity;
            }
            else
            {
                MC.ItemsEntity = new ObservableCollection<ENG_T001_A>();
            }
            if (MasterEntity.XmlDataDocument_FlipGrid != null && isNewRecord == true && ParameterOption1 == "Save")
            {
                MC.DocumentDataFlipGrid = (List<ENG_T001Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                FlipDataGridCollection.Refresh();
            }
        }
        #endregion

        #region  Filters

        #region Filter For Doc Type
        private string _filterStringDocType;
        public string filterStringDocType
        {
            get { return _filterStringDocType; }
            set
            {
                _filterStringDocType = value;
                RaisePropertyChanged("filterStringDocType");
                Filter_DocTypeCollection();
            }
        }
        private void Filter_DocTypeCollection()
        {
            if (_DocTypeCollection != null)
            {
                _DocTypeCollection.Refresh();
            }
        }
        public bool Filter_DocType(object obj)
        {
            var data = obj as SYS_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(filterStringDocType))
                {
                    return (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_filterStringDocType.ToLower())) ||
                           (data.doc_desc != null && data.doc_desc.ToString().ToLower().Contains(_filterStringDocType.ToLower()));

                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter For BOM Cat
        private string _filterStringBomCat;
        public string filterStringBomCat
        {
            get { return _filterStringBomCat; }
            set
            {
                _filterStringBomCat = value;
                RaisePropertyChanged("filterStringBomCat");
                Filter_BomCatCollection();
            }
        }
        private void Filter_BomCatCollection()
        {
            if (_BomCollection != null)
            {
                _BomCollection.Refresh();
            }
        }
        public bool Filter_BomCat(object obj)
        {
            var data = obj as SYS_M050;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(filterStringBomCat))
                {
                    return (data.bom_cat != null && data.bom_cat.ToString().ToLower().Contains(_filterStringBomCat.ToLower())) ||
                           (data.cat_name != null && data.cat_name.ToString().ToLower().Contains(_filterStringBomCat.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filter For Item Code
        private string _filterStringItemCode;
        public string filterStringItemCode
        {
            get { return _filterStringItemCode; }
            set
            {
                _filterStringItemCode = value;
                RaisePropertyChanged("filterStringItemCode");
                Filter_ItemCodeCollection();
            }
        }
        private void Filter_ItemCodeCollection()
        {
            if (_ItemCollection != null)
            {
                _ItemCollection.Refresh();
            }
        }
        public bool Filter_ItemCode(object obj)
        {
            var data = obj as ADM_M022_POPUP;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(filterStringItemCode))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringItemCode.ToLower())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterStringItemCode.ToLower()));

                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter For Unit
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
            if (_UomCollection != null)
            {
                _UomCollection.Refresh();
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
        #endregion

        #region Filter For Flip Grid Data
        private string _FilterStringFlipGridData;
        public string FilterStringFlipGridData
        {
            get { return _FilterStringFlipGridData; }
            set
            {
                _FilterStringFlipGridData = value;
                RaisePropertyChanged("FilterStringFlipGridData");
                Filter_FlipGrid();
            }
        }
        private void Filter_FlipGrid()
        {
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGridData(object obj)
        {
            var data = obj as ENG_T001Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringFlipGridData))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.bom_cat != null && data.bom_cat.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region  Filter For Customer
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
                if (!string.IsNullOrEmpty(FilterStringCustomer))
                {
                    return (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_FilterStringCustomer.ToLower())) ||
                           (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_FilterStringCustomer.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filter For Alternate Item
        private string _FilterStringAlternateItem;
        public string FilterStringAlternateItem
        {
            get { return _FilterStringAlternateItem; }
            set
            {
                _FilterStringAlternateItem = value;
                RaisePropertyChanged("FilterStringAlternateItem");
                Filter_AlternateItem();
            }
        }
        private void Filter_AlternateItem()
        {
            if (_AlternateItemCollection != null)
            {
                _AlternateItemCollection.Refresh();
            }
        }
        public bool FilterAlternateItem(object obj)
        {
            var data = obj as ADM_M022_POPUP;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringAlternateItem))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_FilterStringAlternateItem.ToLower())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_FilterStringAlternateItem.ToLower()));

                }
                return true;
            }
            return false;
        }




        #endregion

        #endregion

    }
}
