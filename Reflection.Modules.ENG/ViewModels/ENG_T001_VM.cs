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
using Reflection.BusinessEntity.ENG;
using System.Collections.Specialized;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.ENG.ViewModels
{
    public class ENG_T001_VM : WorkspaceViewModel<ENG_T001>
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
                    if (SourceName == "item_code")
                    { AS_DEFAULT = AS_COMPONANT; }
                    else if (SourceName == "item_code_alt")
                    { AS_DEFAULT = AS_ITEM_ALT; }

                }
            }
        }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
        private AutoSuggestTextViewModel<dynamic> _AS_DEFAULT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DEFAULT
        {
            get { return _AS_DEFAULT; }
            set
            {
                if (_AS_DEFAULT != value)
                {
                    _AS_DEFAULT = value; RaisePropertyChanged("AS_DEFAULT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_COMPANY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_COMPANY
        {
            get { return _AS_COMPANY; }
            set
            {
                if (_AS_COMPANY != value)
                {
                    _AS_COMPANY = value; RaisePropertyChanged("AS_COMPANY");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_LOCATION { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_LOCATION
        {
            get { return _AS_LOCATION; }
            set
            {
                if (_AS_LOCATION != value)
                {
                    _AS_LOCATION = value; RaisePropertyChanged("AS_LOCATION");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ITEM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ITEM
        {
            get { return _AS_ITEM; }
            set
            {
                if (_AS_ITEM != value)
                {
                    _AS_ITEM = value; RaisePropertyChanged("AS_ITEM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_UOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM
        {
            get { return _AS_UOM; }
            set
            {
                if (_AS_UOM != value)
                {
                    _AS_UOM = value; RaisePropertyChanged("AS_UOM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_BOM_CAT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_BOM_CAT
        {
            get { return _AS_BOM_CAT; }
            set
            {
                if (_AS_BOM_CAT != value)
                {
                    _AS_BOM_CAT = value; RaisePropertyChanged("AS_BOM_CAT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_COMPONANT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_COMPONANT
        {
            get { return _AS_COMPONANT; }
            set
            {
                if (_AS_COMPONANT != value)
                {
                    _AS_COMPONANT = value; RaisePropertyChanged("AS_COMPONANT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_UOM_A { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM_A
        {
            get { return _AS_UOM_A; }
            set
            {
                if (_AS_UOM_A != value)
                {
                    _AS_UOM_A = value; RaisePropertyChanged("AS_UOM_A");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ITEM_ALT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ITEM_ALT
        {
            get { return _AS_ITEM_ALT; }
            set
            {
                if (_AS_ITEM_ALT != value)
                {
                    _AS_ITEM_ALT = value; RaisePropertyChanged("AS_ITEM_ALT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_LINE_CAT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_LINE_CAT
        {
            get { return _AS_LINE_CAT; }
            set
            {
                if (_AS_LINE_CAT != value)
                {
                    _AS_LINE_CAT = value; RaisePropertyChanged("AS_LINE_CAT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_IND_USE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_IND_USE
        {
            get { return _AS_IND_USE; }
            set
            {
                if (_AS_IND_USE != value)
                {
                    _AS_IND_USE = value; RaisePropertyChanged("AS_IND_USE");
                }
            }
        }

        #endregion

        #region Declaration

        bool isNewRecord = true;

        WebServiceRepository<ENG_T001> REPO = new WebServiceRepository<ENG_T001>();
        WebServiceRepository<MC_ENG_BE> REPO_MC = new WebServiceRepository<MC_ENG_BE>();
        WebServiceRepository<MC_ENG_BE> REPO_MC_TEMP = new WebServiceRepository<MC_ENG_BE>();

        ObjectSerializationService obj = new ObjectSerializationService();

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        public string doc_cat_vm { get; set; }
        IShowMessageViewService sms;
        private MC_ENG_BE _MC = new MC_ENG_BE();
        public MC_ENG_BE MC
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

        private MC_ENG_BE _MC_TEMP = new MC_ENG_BE();
        public MC_ENG_BE MC_TEMP
        {
            get { return _MC_TEMP; }
            set
            {
                if (_MC_TEMP != value)
                {
                    _MC_TEMP = value; RaisePropertyChanged("MC_TEMP");
                }
            }
        }
        private STD_DOC_TYPE _DOC_TYPE_OBJ;
        public STD_DOC_TYPE DOC_TYPE_OBJ
        {
            get { return _DOC_TYPE_OBJ; }
            set
            {
                if (_DOC_TYPE_OBJ != value)
                {
                    _DOC_TYPE_OBJ = value;
                    RaisePropertyChanged(nameof(DOC_TYPE_OBJ));
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

        private ObservableCollection<ENG_T001_A> _ItemsEntity;
        public ObservableCollection<ENG_T001_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value;
                    ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItemsEntity);
                    RaisePropertyChanged("ItemsEntity");
                }
            }
        }
        private ObservableCollection<ENG_T001_C> _AssignmentEntity;
        public ObservableCollection<ENG_T001_C> AssignmentEntity
        {
            get { return _AssignmentEntity; }
            set
            {
                if (_AssignmentEntity != value)
                {
                    _AssignmentEntity = value;
                    AssignmentEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForAssignmentEntity);
                    RaisePropertyChanged("AssignmentEntity");
                }
            }
        }
        private ENG_T001_A _ENG_T001_A_OBJ;
        public ENG_T001_A ENG_T001_A_OBJ
        {
            get
            {
                return _ENG_T001_A_OBJ;
            }
            set
            {
                if (_ENG_T001_A_OBJ != value)
                {
                    _ENG_T001_A_OBJ = value;
                    RaisePropertyChanged("ENG_T001_A_OBJ");
                }
            }
        }
        private ENG_T001_C _ENG_T001_C_OBJ;
        public ENG_T001_C ENG_T001_C_OBJ
        {
            get
            {
                return _ENG_T001_C_OBJ;
            }
            set
            {
                if (_ENG_T001_C_OBJ != value)
                {
                    _ENG_T001_C_OBJ = value;
                    RaisePropertyChanged("ENG_T001_C_OBJ");
                }
            }
        }
        private STD_REQ_PARA_BE _REQ_PARA_OBJ;
        public STD_REQ_PARA_BE REQ_PARA_OBJ
        {
            get
            {
                return _REQ_PARA_OBJ;
            }
            set
            {
                if (_REQ_PARA_OBJ != value)
                {
                    _REQ_PARA_OBJ = value;
                    RaisePropertyChanged(nameof(REQ_PARA_OBJ));
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
        private DataGridColumn _DG_COL_OBJ;
        public DataGridColumn DG_COL_OBJ
        {
            get
            {
                return _DG_COL_OBJ;
            }
            set
            {
                if (_DG_COL_OBJ != value)
                {
                    _DG_COL_OBJ = value;
                    RaisePropertyChanged(nameof(DG_COL_OBJ));
                }
            }
        }
        private bool _ReadOnlyItem;
        public bool ReadOnlyItem
        {
            get
            {
                return _ReadOnlyItem;
            }
            set
            {
                if (_ReadOnlyItem != value)
                {
                    _ReadOnlyItem = value;
                    RaisePropertyChanged("ReadOnlyItem");
                }
            }
        }
        #endregion

        #region List

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

        #region Collection & IEnumerable
        private IEnumerable _LINE_CAT_LIST;
        public IEnumerable LINE_CAT_LIST
        {
            get { return _LINE_CAT_LIST; }
            set { _LINE_CAT_LIST = value; RaisePropertyChanged("LINE_CAT_LIST"); }
        }
        private IEnumerable _COMPONANT_LIST;
        public IEnumerable COMPONANT_LIST
        {
            get { return _COMPONANT_LIST; }
            set { _COMPONANT_LIST = value; RaisePropertyChanged("COMPONANT_LIST"); }
        }

        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }

        private ICollectionView _ITEM_COLLECTION;
        public ICollectionView ITEM_COLLECTION
        {
            get { return _ITEM_COLLECTION; }
            set
            {
                _ITEM_COLLECTION = value;

                RaisePropertyChanged("ITEM_COLLECTION");
            }
        }
        private void FLTR_COL_ITEM()
        {
            if (_ITEM_COLLECTION != null)
            {
                _ITEM_COLLECTION.Refresh();
            }
        }
        private string _FLTR_STR_ITEM;
        public string FLTR_STR_ITEM
        {
            get { return _FLTR_STR_ITEM; }
            set
            {
                _FLTR_STR_ITEM = value;
                RaisePropertyChanged("FLTR_STR_ITEM");
                FLTR_COL_ITEM();
            }
        }
        public bool ITEM_FILTER(object obj)
        {
            var data = obj as STD_ITEM;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FLTR_STR_ITEM))
                {
                    return ((data.item_code != null) && data.item_code.ToLower().Contains(_FLTR_STR_ITEM.ToLower())) ||
                           (data.item_name != null && data.item_name.ToString().ToLower().Contains(_FLTR_STR_ITEM.ToLower())) ||
                           (data.cat_code != null && data.cat_code.ToString().ToLower().Contains(_FLTR_STR_ITEM.ToLower())) ||
                           (data.sub_cat != null && data.sub_cat.ToString().ToLower().Contains(_FLTR_STR_ITEM.ToLower()));

                }
                return true;
            }
            return false;
        }
        #endregion


        #region Relay Command Declaration
        public RelayCommand<object> cmdSelectItemsBulk { get; private set; }
        public RelayCommand<object> cmdInsertItemList { get; private set; }
        public RelayCommand<object> cmdInsertObject { get; private set; } // Item or any other object at Header level
        public RelayCommand<object> cmdInsertComponant { get; private set; } // item or any other data for Item Level
        public RelayCommand<object> CmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocNo { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdSC_ENG_T001_A { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        //public RelayCommand<object> cmdInsertCompany { get; private set; }
        #endregion

        #region Constructor
        public ENG_T001_VM(string ts_code, string doc_cat) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;
            MasterEntity = new ENG_T001();
            MC = new MC_ENG_BE();
            MC_TEMP = new MC_ENG_BE();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            MM_T001.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            ENG_T001_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            ItemsEntity = new ObservableCollection<ENG_T001_A>();
            ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItemsEntity);
            AssignmentEntity = new ObservableCollection<ENG_T001_C>();
            AssignmentEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForAssignmentEntity);
            sms = this.GetViewService<IShowMessageViewService>();
            MasterEntity.ValidateAsync().Wait();
            REQ_PARA_OBJ.from_date = DateTime.Now;
            REQ_PARA_OBJ.to_date = DateTime.Now;
            DOC_TYPE_OBJ = new STD_DOC_TYPE();
            CommandInitialisation();

        }
        public ENG_T001_VM(string ts_code,string doc_cat, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;
            this.doc_no_vm = doc_no;
            MasterEntity = new ENG_T001();
            MC = new MC_ENG_BE();
            MC_TEMP = new MC_ENG_BE();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            MM_T001.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            ENG_T001_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            ItemsEntity = new ObservableCollection<ENG_T001_A>();
            ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItemsEntity);
            AssignmentEntity = new ObservableCollection<ENG_T001_C>();
            AssignmentEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForAssignmentEntity);
            sms = this.GetViewService<IShowMessageViewService>();
            MasterEntity.ValidateAsync().Wait();
            REQ_PARA_OBJ.from_date = DateTime.Now;
            REQ_PARA_OBJ.to_date = DateTime.Now;
            DOC_TYPE_OBJ = new STD_DOC_TYPE();
            CommandInitialisation();
        }
        private void Model_ItemUpdated(object sender, EventArgs e)
        {
            if(ENG_T001_A_OBJ != null)
            {
                ENG_T001_A_OBJ.selected = true;
                if (ENG_T001_A_OBJ.ind_freeze == "1" || ENG_T001_A_OBJ.ind_var == "1") //(ENG_T001_A_OBJ.ind_var == "1" || ENG_T001_A_OBJ.ind_var == null)
                {
                    ENG_T001_A_OBJ.read_only = true;
                }
                else
                {
                    ENG_T001_A_OBJ.read_only = false;
                }
            }
        }
        private void CommandInitialisation()
        {
            #region Command Initialisation
            cmdSelectItemsBulk = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } SelectItemsBulk(cmdPara); });
            cmdInsertItemList = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItemList(cmdPara); });
            cmdInsertObject = new RelayCommand<object>(items => { if (items == null) { return; } InsertObject(items); });
            cmdInsertComponant = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertComponant(cmdPara); });
            cmdLoadDocumentByDocNo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
            CmdDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdSC_ENG_T001_A = new RelayCommand<object>(items => { if (items == null) { return; } SC_ENG_T001_A(items); });
            cmdLoadBackFlip = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadBackFlipData(cmdPara); });
            //cmdInsertCompany = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCompany(cmdPara); });

            #endregion
        }
        private void LoadInitialData(string company, string location)
        {
            try
            {

                MasterEntity.doc_cat = "BM";
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + company + "!@" + location + "!@" + doc_cat_vm + "!@" + doc_cat_vm;
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_ENG_BE>(MC, Request, "ENG_T001_BL", "ENG", "LOAD_INI", 0, "");

                LINE_CAT_LIST = MC.LINE_CAT_LIST;
                COMPONANT_LIST = MC.COMPONANT_LIST;


                #region AutoSuggest Initialization

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M0002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0002)o).comp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", true);
                AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = true;

                List<ADM_M0003> LOC_LIST_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == AppSessionState.OBJ_COMPANY.comp_code).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_id", true);
                AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = false; AS_LOCATION.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code);
                TheFilter = (o, prefix) => (((STD_ITEM)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ITEM = new AutoSuggestTextViewModel<dynamic>(MC.ITEM_LIST, TheFilter, SuggestedValue, "item_code", true);
                AS_ITEM.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ITEM.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code);
                TheFilter = (o, prefix) => (((STD_ITEM)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COMPONANT = new AutoSuggestTextViewModel<dynamic>(MC.COMPONANT_LIST, TheFilter, SuggestedValue, "item_code", true);
                AS_COMPONANT.AutoSuggestVM.IsEmptyValueAllowed = true; AS_COMPONANT.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => ((UOMS)o).unit_code.ToLower().Contains(prefix);
                AS_UOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM.AutoSuggestVM.IsEmptyValueAllowed = false; AS_UOM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).cat_code);
                TheFilter = (o, prefix) => ((STD_LIST_BE)o).cat_code.ToLower().Contains(prefix) || ((STD_LIST_BE)o).cat_name.ToLower().Contains(prefix);
                AS_BOM_CAT = new AutoSuggestTextViewModel<dynamic>(MC.BOM_CAT_LIST, TheFilter, SuggestedValue, "cat_code", true);
                AS_BOM_CAT.AutoSuggestVM.IsEmptyValueAllowed = false; AS_BOM_CAT.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => ((UOMS)o).unit_code.ToLower().Contains(prefix);
                AS_UOM_A = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM_A.AutoSuggestVM.IsEmptyValueAllowed = false; AS_UOM_A.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code);
                TheFilter = (o, prefix) => (((STD_ITEM)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ITEM_ALT = new AutoSuggestTextViewModel<dynamic>(MC.COMPONANT_LIST, TheFilter, SuggestedValue, "item_code", true);
                AS_ITEM_ALT.AutoSuggestVM.IsEmptyValueAllowed = true; AS_ITEM_ALT.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).ind_code);
                TheFilter = (o, prefix) => ((STD_LIST_BE)o).ind_code.ToLower().Contains(prefix) || ((STD_LIST_BE)o).ind_name.ToLower().Contains(prefix);
                AS_IND_USE = new AutoSuggestTextViewModel<dynamic>(MC.USAGE_LIST, TheFilter, SuggestedValue, "ind_usage", "ind_code", true);
                AS_IND_USE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_IND_USE.AutoSuggestVM.IsFreeTextAllowed = false;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).cat_code);
                //TheFilter = (o, prefix) => ((STD_LIST_BE)o).cat_code.ToLower().Contains(prefix) || ((STD_LIST_BE)o).cat_name.ToLower().Contains(prefix);
                //AS_LINE_CAT = new AutoSuggestTextViewModel<dynamic>(MC.LINE_CAT_LIST, TheFilter, SuggestedValue, "line_cat", "cat_code", true);
                //AS_LINE_CAT.AutoSuggestVM.IsEmptyValueAllowed = false; AS_LINE_CAT.AutoSuggestVM.IsFreeTextAllowed = false;


                #endregion

                ITEM_COLLECTION = (ICollectionView)CollectionViewSource.GetDefaultView(MC.COMPONANT_LIST);
                ITEM_COLLECTION.Filter = new Predicate<object>(ITEM_FILTER);

                DefaultValues();
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok;sms.Caption = "Message";sms.Text = String.Format(ex.Message, this.Title);sms.ShowMessage();
            }
        }
        private void LoadBackFlipData(object Parameter)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (REQ_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + (REQ_PARA_OBJ.active_code ?? "") + "!@" + (REQ_PARA_OBJ.t_status ?? "") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy");
                MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_SDM_BE>(MC_TEMP, Request, "ENG_T001_BL", "ENG", "LoadAll", 0, "");

                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC_TEMP.BACK_FLIP_LIST.ToList());
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(FLTR_BACKFLIP);

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        //private void InsertCompany(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ADM_M0002 POPUPEntityObject = null;
        //        #region Command Parameter Read Section
        //        try
        //        {
        //            if (InputValue.GetType() == typeof(string) && InputValue != null)
        //            {
        //                Request = InputValue.ToString();
        //                if (Request.Length > 0)
        //                {
        //                    try
        //                    { POPUPEntityObject = MC.COMPANY_LIST.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                    catch (Exception ex) { }
        //                }
        //            }
        //            else if (InputValue != null)
        //            {
        //                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0002>().ToList()[0];
        //            }
        //        }
        //        catch (Exception ex) { }

        //        #endregion
        //        if (POPUPEntityObject != null)
        //        {
        //            //if (MasterEntity.comp_code != POPUPEntityObject.comp_code)
        //            //{
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;
        //            LoadInitialData(MasterEntity.comp_code, MasterEntity.location_id);
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;

        //            List<ADM_M0003> LOC_LIST_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == MasterEntity.comp_code).ToList();
        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
        //            TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //            AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_id", true);
        //            AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = true;
        //            if (LOC_LIST_OBJ.Count == 1)
        //            {
        //                MasterEntity.location_id = LOC_LIST_OBJ[0].location_id;
        //            }
        //            else
        //            {
        //                MasterEntity.location_id = null;
        //            }
        //        }
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
        //    }
        //}
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            string ParametersStringValue = "";
            STD_LIST_BE ParameterEntityObject = null;

            if (((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList()[0];

                if (MasterEntity.comp_code != ParameterEntityObject.comp_code) // call when document loading of different company
                {
                    LoadInitialData(ParameterEntityObject.comp_code, ParameterEntityObject.location_id);
                }

                MasterEntity = new ENG_T001();
                ItemsEntity = new ObservableCollection<ENG_T001_A>();
                Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + ParameterEntityObject.comp_code + "!@" + ParameterEntityObject.location_id + "!@" + ParameterEntityObject.doc_cat + "!@" + ParameterEntityObject.doc_type + "!@" + ParameterEntityObject.doc_no;
                isNewRecord = false;

                MC_TEMP = REPO_MC_TEMP.GetDataWithReturnDomainObject<MC_ENG_BE>(MC_TEMP, Request, "ENG_T001_BL", "ENG", "LOAD_DOC_BY_DOC_NO", 0, "");
                SelectedTabControlIndex = 0;
                if (MC_TEMP.MasterEntity.Count > 0)
                {
                    MasterEntity = MC_TEMP.MasterEntity[0];
                    ItemsEntity = MC_TEMP.ItemsEntity;
                    AssignmentEntity = MC_TEMP.BOMAssignmentEntity;
                }
                SetBusinessEntitiesAfterLoad(ParametersStringValue, "Save");
            }
            MasterEntity.ts_code = ts_code_vm;
            var msg = new NotificationMessage(ts_code_vm);
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        #endregion

        #region User Defined Function
        private void DefaultValues()
        {
            MasterEntity.doc_cat = doc_cat_vm;
            MasterEntity.doc_type = doc_cat_vm;
            
            if(MC.DOC_TYPE_LIST != null)
            {
                if (MC.DOC_TYPE_LIST.Count > 0)
                {
                    DOC_TYPE_OBJ = (from o in MC.DOC_TYPE_LIST where o.doc_cat == doc_cat_vm && o.default_doc == true select o).FirstOrDefault(); // NOTE: make default compulsoary in Master or system master
                    if (DOC_TYPE_OBJ != null)
                    {
                        MasterEntity.doc_type = DOC_TYPE_OBJ.doc_type;
                    }
                }
            }

            MasterEntity.client = AppSessionState.client;
            MasterEntity.location_id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.client = AppSessionState.client;
            
            MasterEntity.t_status = "01";
            MasterEntity.doc_no = "";
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.active = "1";
            MasterEntity.counter_no = 1;
            MasterEntity.bom_qty = 1;
            MasterEntity.doc_date = DateTime.UtcNow;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;

            DateTime d = DateTime.UtcNow;
            d = d.AddMonths(-1);
            REQ_PARA_OBJ.from_date = d;
            REQ_PARA_OBJ.to_date = DateTime.UtcNow;
            REQ_PARA_OBJ.active = true;
            REQ_PARA_OBJ.active_code = "1";
            REQ_PARA_OBJ.comp_code = AppSessionState.OBJ_COMPANY.comp_code;

            
        }
        private void Logging()
        {
            MasterEntity.ts_code = this.ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private void InsertObject(object InputValue)
        {
            string Request = "";
            STD_ITEM POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ITEM_LIST.Where(x => x.item_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }

                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_ITEM>().ToList()[0];
                }
            }
            catch (Exception ex) { }
            if (POPUPEntityObject != null)
            {
                MasterEntity.item_code = POPUPEntityObject.item_code;
                MasterEntity.item_name = POPUPEntityObject.item_name;
                MasterEntity.item_cat = POPUPEntityObject.item_cat;
                MasterEntity.unit_code = POPUPEntityObject.unit_code;
            }
        }
        private void InsertComponant(object InputValue)
        {
            string Request = "";
            STD_ITEM POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.COMPONANT_LIST.Where(x => x.item_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex){}
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_ITEM>().ToList()[0];
                }
                if (POPUPEntityObject != null && ENG_T001_A_OBJ != null)
                {
                    ENG_T001_A_OBJ.item_code = POPUPEntityObject.item_code;
                    ENG_T001_A_OBJ.item_name = POPUPEntityObject.item_name;
                    ENG_T001_A_OBJ.unit_code = POPUPEntityObject.unit_code;
                    ENG_T001_A_OBJ.sub_cat = POPUPEntityObject.item_subcat;
                    ENG_T001_A_OBJ.ind_sku = POPUPEntityObject.ind_sku;
                }
            }
            catch (Exception ex) { }
            
        }
        private void InsertItemList(object InputValue)
        {
            try
            {
                if (MC.COMPONANT_LIST != null)
                {
                    foreach (var item in MC.COMPONANT_LIST)
                    {
                        if (item.selected == true)
                        {
                            ItemsEntity.Add(new ENG_T001_A()); // This will just add new row and assign MM_T003_A_OBJ to newly added row.
                            InsertComponant(item.item_code);
                            item.selected = false;
                        }
                    }
                }

            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForItemsEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ENG_T001_A item in e.NewItems)
                    {
                        item.id = 0;
                        item.selected = true;
                        item.line_id = ItemsEntity.Count();
                        item.qty = 1;
                        item.active = "1";
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.location_id = (MasterEntity.location_id ?? AppSessionState.OBJ_LOCATION.location_id);
                        item.client = AppSessionState.client;
                        item.doc_no = MasterEntity.doc_no;
                        item.valid_from = MasterEntity.valid_from;
                        item.valid_to = MasterEntity.valid_to;
                        item.t_status = "01";
                        item.ind_usage = "A";
                        item.line_cat = "M";

                        ENG_T001_A_OBJ = item; // New row created and added to object instance// when item get added without row adding but this function all like from InsertItemList(). other place instance of row created but from bulk adding it is not.

                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                { }
            }
            catch (Exception ex)
            { }
        }
        private void SC_ENG_T001_A(object InputValue)
        {
            try
            {
                ENG_T001_A_OBJ = (ENG_T001_A)InputValue;
                if (ENG_T001_A_OBJ != null)
                {
                    if (ENG_T001_A_OBJ.ind_freeze == "1" || ENG_T001_A_OBJ.ind_var == "1")
                    {
                        ENG_T001_A_OBJ.read_only = true;
                    }
                    else
                    {
                        ENG_T001_A_OBJ.read_only = false;
                    }
                }
            }
            catch (Exception ex) { }
        }
        private bool Validation()
        {

            //if (MasterEntity.item_code == null || MasterEntity.item_code == "")
            //{
            //    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Item Code...", this.Title); sms.ShowMessage();
            //    return false;
            //}
            if (MasterEntity.bom_cat == null || MasterEntity.bom_cat == "")
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Category of BOM...", this.Title); sms.ShowMessage();
                return false;
            }
            if (MasterEntity.bom_qty == null)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Enter Quantity...", this.Title); sms.ShowMessage();
                return false;
            }

            if (ItemsEntity.Count < 1)//when form is blank and we tryy to save the record
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert Item In DataGrid........", this.Title); sms.ShowMessage();
                return false;
            }
            
            #region . Validation for Item Duplication, null Unit Code and Null or 0 Quantity For All Active Unsaved Items .

            foreach (var o in ItemsEntity)
            {
                int flag = 0;
                if (o.id == 0 && o.active == "1")
                {
                    foreach (var p in ItemsEntity)
                    {
                        if (o.item_code == p.item_code && o.sku == p.sku && p.active == "1")
                        {
                            flag++;
                        }
                    }
                    if (flag > 1)
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(String.Format("Cannot Save Duplicate Item {0} and Parameter {1}", o.item_code, o.sku_desc), this.Title); sms.ShowMessage();
                        return false;
                    }
                }

                if (o.item_code != null && o.item_code != "")
                {
                    if (o.qty == null || o.qty == 0)
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(String.Format("Quantity cannot be null or 0 for item {0} and Parameter {1}", o.item_code, o.sku_desc), this.Title); sms.ShowMessage();
                        return false;
                    }

                    if (o.unit_code == null || o.unit_code == "")
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(String.Format("Please Enter Valid Unit Code for the item {0} and Parameter {1}", o.item_code, o.sku_desc), this.Title); sms.ShowMessage();
                        return false;
                    }
                }
            }
            #endregion
            return true;
        }
        private void DeleteDataGridRow_Item(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemsEntity.Count > i && ENG_T001_A_OBJ.id == 0)
                {
                    ItemsEntity.RemoveAt(i);
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        private void CollectionChangedNotifyForAssignmentEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ENG_T001_C item in e.NewItems)
                    {
                        item.active = "1";
                        item.comp_code = MasterEntity.comp_code;
                        item.location_id = MasterEntity.location_id;
                        item.client = AppSessionState.client;
                        item.valid_from = MasterEntity.valid_from;
                        item.doc_no = MasterEntity.doc_no;

                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                { }
            }
            catch (Exception ex)
            { }
        }

        private void WindowEvetCall(object InputValue)
        {
            try
            {
                DefaultValues();
                LoadInitialData(MasterEntity.comp_code, MasterEntity.location_id);
                DefaultValues();
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    AppSessionState.ViewOtherRecordAllowed = true;
                }
                

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
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

        private void SelectItemsBulk(object InputValue) // can be remove this function, we hahe include this code in Function of OK Button below the popup window.
        {
            try
            {
                DataGridColumn dgCol = (DataGridColumn)InputValue;
                
                if (InputValue != null && dgCol != null) //DG_COL_OBJ != null
                {
                    foreach (var item in ItemsEntity)
                    {
                        if (dgCol.SortMemberPath == "selected" && (item.ind_freeze != "1" || item.ind_freeze == null) && (item.ind_var != "1" || item.ind_var == null))
                        {
                            item.selected = true;
                        }
                        if (dgCol.SortMemberPath == "ind_freeze")
                        {
                            item.ind_freeze = "1";
                            item.selected = true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        #endregion

        #region Abstract Methods
        protected override void OnSaveAction(InquiryActionResult<ENG_T001> result)
        {
            try
            {
                if (Validation() == true)
                {
                    Logging();
                    List<ENG_T001_A> RequestList = new List<ENG_T001_A>();
                    foreach (ENG_T001_A item in ItemsEntity)
                    {
                        if (item.selected == true)
                        {
                            RequestList.Add(item);
                        }
                    }
                    MasterEntity.XDOC_A = obj.ObjectToXML(RequestList);
                    MasterEntity.XDOC_C = obj.ObjectToXML(AssignmentEntity);

                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true || (isNewRecord == false && MasterEntity.copy==true))
                    {
                        MasterEntity = REPO.SaveWithReturnDomainObject<ENG_T001>(MasterEntity, "ENG_T001_BL", "ENG");
                    }


                    else if (isNewRecord == false)
                    {
                        MasterEntity = REPO.UpdateWithReturnDomainObject<ENG_T001>(MasterEntity, "ENG_T001_BL", "ENG");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Data Saved Successfully", this.Title); sms.ShowMessage();
                    isNewRecord = false;

                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        protected override void OnCreateAction(InquiryActionResult<ENG_T001> result)
        {
            isNewRecord = true;
            //if (MasterEntity.comp_code != AppSessionState.OBJ_COMPANY.comp_code) // call when document loading of different company. call before Master Entity instance is being created.
            //{
            //    LoadInitialData(AppSessionState.OBJ_COMPANY.comp_code, AppSessionState.OBJ_LOCATION.location_id);
            //}
            MasterEntity = new ENG_T001();
            MC.ItemsEntity = new ObservableCollection<ENG_T001_A>();
            ItemsEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItemsEntity);
            MasterEntity.ValidateAsync().Wait();
            ItemsEntity.Clear();
            AssignmentEntity = new ObservableCollection<ENG_T001_C>();
            AssignmentEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForAssignmentEntity);

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
                string response = REPO.Delete(MasterEntity.doc_no, "ENG_T001_BL", "ENG");


                MasterEntity = new ENG_T001();
                ItemsEntity = new ObservableCollection<ENG_T001_A>();
                isNewRecord = true;
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
                CursorControl.SetBusyState();
                object[] objDataSource = new object[2];
                string[] objDataSourceName = new string[2];

                if (MC.MasterEntity != null)
                {
                    if (MC.MasterEntity.Count > 0)
                    {
                        MC.MasterEntity.Clear();
                        MC.MasterEntity.Add(MasterEntity);
                    }
                    else
                    {
                        MC.MasterEntity.Add(_MasterEntity);
                    }
                }
                objDataSource[0] = MC.MasterEntity;
                objDataSource[1] = ItemsEntity;

                objDataSourceName[0] = "dsMaster";
                objDataSourceName[1] = "dsItem";

                ReportManager ReportManager = new ReportManager();

                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORTS_STD\\TXN\\" + DOC_TYPE_OBJ.report_name, getParametersList(null), DOC_TYPE_OBJ.doc_type_name);

            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private Dictionary<string, string> getParametersList(string paraValue)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("rpt_title", DOC_TYPE_OBJ.doc_type_name);
                result.Add("comp_code", AppSessionState.OBJ_COMPANY.comp_code);
                result.Add("comp_name", AppSessionState.OBJ_COMPANY.comp_name);
                result.Add("location_id", MasterEntity.location_id);
                //result.Add("PrintOption", paraValue);
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
            return result;
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
                result.Add("item_name", MasterEntity.item_name);
                result.Add("item_code", MasterEntity.item_code);
                result.Add("bom_name", MasterEntity.bom_name);
                result.Add("doc_date", Convert.ToString(MasterEntity.doc_date));

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
            return result;
        }
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.doc_no))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MC_TEMP.ATTACHMENT_LIST, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) });
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
            if (MasterEntity.XDOC_A != null)
            {
                MC.ItemsEntity = (ObservableCollection<ENG_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_A, MC.ItemsEntity);
                ItemsEntity.Clear();
                ItemsEntity = MC.ItemsEntity;
            }
            else
            {
                MC.ItemsEntity = new ObservableCollection<ENG_T001_A>();
            }
            if (MasterEntity.XDOC_C != null)
            {
                AssignmentEntity.Clear();
                AssignmentEntity = (ObservableCollection<ENG_T001_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_C, MC.BOMAssignmentEntity);
            }
            else
            {
                MC.BOMAssignmentEntity = new ObservableCollection<ENG_T001_C>();
            }
        }
        #endregion

        #region Filters

        private string _FLTR_STR_BACKFLIP;
        public string FLTR_STR_BACKFLIP
        {
            get { return _FLTR_STR_BACKFLIP; }
            set
            {
                _FLTR_STR_BACKFLIP = value;
                RaisePropertyChanged("FLTR_STR_BACKFLIP");
                FLTR_COLL_BACKFLIP();
            }
        }
        private void FLTR_COLL_BACKFLIP()
        {
            if (BACKFLIP_COLLECTION != null)
            {
                BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool FLTR_BACKFLIP(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FLTR_STR_BACKFLIP))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.valid_from != null && data.valid_from.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.short_text != null && data.short_text.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.bom_name != null && data.bom_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.item_code != null && data.item_code.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.item_name != null && data.item_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.cat_name != null && data.cat_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.t_display != null && data.t_display.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.cat_name != null && data.cat_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

    }
}
