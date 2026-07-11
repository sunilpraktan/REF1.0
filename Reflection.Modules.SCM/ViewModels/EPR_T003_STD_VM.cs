using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using System.Collections.Specialized;
using Reflection.ReportingServices;
using System.Windows;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ReflectionSystem;
// for TreeView
using System.Data;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;
using Reflection.BusinessEntity.MM;

namespace Reflection.Modules.SCM.ViewModels
{
    public class EPR_T003_STD_VM : WorkspaceViewModel<EPR_T003_A>
    {
        #region . Variable Declaration And Object .

        // for tree view start
        DataSet _ItemsSet = new DataSet();
        public DataSet ItemsSet
        {
            get { return _ItemsSet; }
            set
            {
                if (_ItemsSet != value)
                {
                    _ItemsSet = value;

                    RaisePropertyChanged("ItemsSet");
                }
            }
        }
        DataView _ItemsView = new DataView();
        public DataView ItemsView
        {
            get { return _ItemsView; }
            set
            {
                if (_ItemsView != value)
                {
                    _ItemsView = value;

                    RaisePropertyChanged("ItemsView");
                }
            }
        }
        DataView _ItemsViewTrace = new DataView();
        public DataView ItemsViewTrace
        {
            get { return _ItemsViewTrace; }
            set
            {
                if (_ItemsViewTrace != value)
                {
                    _ItemsViewTrace = value;

                    RaisePropertyChanged("ItemsViewTrace");
                }
            }
        }
        // for tree view end

        private bool NewRecord = true;
        private bool EntityChangeEnable = true;
        private string ts_code_vm { get; set; }
        private string doc_no_vm { get; set; }
        private string doc_cat_vm { get; set; }

        WebServiceRepository<EPR_T003_A> repository = new WebServiceRepository<EPR_T003_A>();
        WebServiceRepository<ObservableCollection<EPR_T003_A>> repositoryLst = new WebServiceRepository<ObservableCollection<EPR_T003_A>>();
        WebServiceRepository<MC_EPR_T003> repository_MC = new WebServiceRepository<MC_EPR_T003>();
        ObjectSerializationService obj = new ObjectSerializationService();
        IShowMessageViewService sms;

        MC_EPR_T003 _MC = new MC_EPR_T003();
        public MC_EPR_T003 MC
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

        MC_EPR_T003 _MCTemp = new MC_EPR_T003();
        public MC_EPR_T003 MCTemp
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

        private EPR_T003_A _MASTER_ENTITY;
        public EPR_T003_A MASTER_ENTITY
        {
            get
            {
                return _MASTER_ENTITY;
            }
            set
            {
                if (_MASTER_ENTITY != value)
                {
                    _MASTER_ENTITY = value;
                    RaisePropertyChanged("MASTER_ENTITY");
                }
            }
        }

        private EPR_T003_B _ITEMS_ENTITY;
        public EPR_T003_B ITEMS_ENTITY
        {
            get
            {
                return _ITEMS_ENTITY;
            }
            set
            {
                if (_ITEMS_ENTITY != value)
                {
                    _ITEMS_ENTITY = value;
                    RaisePropertyChanged("ITEMS_ENTITY");
                }
            }
        }

        private ObservableCollection<EPR_T003_A> _MASTER_ENTITY_LIST;
        public ObservableCollection<EPR_T003_A> MASTER_ENTITY_LIST
        {
            get
            {
                return _MASTER_ENTITY_LIST;
            }
            set
            {
                if (_MASTER_ENTITY_LIST != value)
                {
                    _MASTER_ENTITY_LIST = value;
                    RaisePropertyChanged("MASTER_ENTITY_LIST");
                }
            }
        }

        private ObservableCollection<EPR_T003_B> _ITEMS_ENTITY_LIST;
        public ObservableCollection<EPR_T003_B> ITEMS_ENTITY_LIST
        {
            get
            {
                return _ITEMS_ENTITY_LIST;
            }
            set
            {
                if (_ITEMS_ENTITY_LIST != value)
                {
                    _ITEMS_ENTITY_LIST = value;
                    RaisePropertyChanged("ITEMS_ENTITY_LIST");
                }
            }
        }


        private ObservableCollection<EPR_T003_A> _MASTER_ENTITY_HU_LIST;
        public ObservableCollection<EPR_T003_A> MASTER_ENTITY_HU_LIST
        {
            get
            {
                return _MASTER_ENTITY_HU_LIST;
            }
            set
            {
                if (_MASTER_ENTITY_HU_LIST != value)
                {
                    _MASTER_ENTITY_HU_LIST = value;
                    RaisePropertyChanged("MASTER_ENTITY_HU_LIST");
                }
            }
        }
        private ObservableCollection<EPR_T003_A> _ITEMS_ENTITY_HU_LIST;
        public ObservableCollection<EPR_T003_A> ITEMS_ENTITY_HU_LIST
        {
            get
            {
                return _ITEMS_ENTITY_HU_LIST;
            }
            set
            {
                if (_ITEMS_ENTITY_HU_LIST != value)
                {
                    _ITEMS_ENTITY_HU_LIST = value;
                    ITEMS_ENTITY_HU_LIST.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotify_HU_ITEMS);
                    RaisePropertyChanged("ITEMS_ENTITY_HU_LIST");
                }
            }
        }

        private ObservableCollection<EPR_T003_A> _MASTER_ENTITY_HU_VIEW;
        public ObservableCollection<EPR_T003_A> MASTER_ENTITY_HU_VIEW
        {
            get
            {
                return _MASTER_ENTITY_HU_VIEW;
            }
            set
            {
                if (_MASTER_ENTITY_HU_VIEW != value)
                {
                    _MASTER_ENTITY_HU_VIEW = value;
                    RaisePropertyChanged("MASTER_ENTITY_HU_VIEW");
                }
            }
        }
        private ICollectionView _LabelCollection;
        public ICollectionView LabelCollection
        {
            get { return _LabelCollection; }
            set
            {
                _LabelCollection = value;
                RaisePropertyChanged("LabelCollection");
            }
        }
        //private ObservableCollection<EPR_T003_A> _ITEMS_ENTITY_HU_VIEW;
        //public ObservableCollection<EPR_T003_A> ITEMS_ENTITY_HU_VIEW
        //{
        //    get
        //    {
        //        return _ITEMS_ENTITY_HU_VIEW;
        //    }
        //    set
        //    {
        //        if (_ITEMS_ENTITY_HU_VIEW != value)
        //        {
        //            _ITEMS_ENTITY_HU_VIEW = value;
        //            RaisePropertyChanged("ITEMS_ENTITY_HU_VIEW");
        //        }
        //    }
        //}

        private EPR_T003_A _MASTER_ENTITY_HU;
        public EPR_T003_A MASTER_ENTITY_HU
        {
            get
            {
                return _MASTER_ENTITY_HU;
            }
            set
            {
                if (_MASTER_ENTITY_HU != value)
                {
                    _MASTER_ENTITY_HU = value;
                    RaisePropertyChanged("MASTER_ENTITY_HU");
                }
            }
        }

        private EPR_T003_A _ITEMS_ENTITY_HU;
        public EPR_T003_A ITEMS_ENTITY_HU
        {
            get
            {
                return _ITEMS_ENTITY_HU;
            }
            set
            {
                if (_ITEMS_ENTITY_HU != value)
                {
                    _ITEMS_ENTITY_HU = value;
                    RaisePropertyChanged("ITEMS_ENTITY_HU");
                }
            }
        }


        private STD_REQ_PARA_BE _REQ_PARA_OBJ;
        public STD_REQ_PARA_BE REQ_PARA_OBJ
        {
            get { return _REQ_PARA_OBJ; }
            set
            {
                if (_REQ_PARA_OBJ != value)
                {
                    _REQ_PARA_OBJ = value;

                    RaisePropertyChanged("REQ_PARA_OBJ");
                }
            }
        }
        private string _BarcodeValue;
        public string BarcodeValue
        {
            get { return _BarcodeValue; }
            set
            {
                if (_BarcodeValue != value)
                {
                    _BarcodeValue = value;

                    RaisePropertyChanged("BarcodeValue");
                }
            }
        }
        private decimal? _PackingLimit;
        public decimal? PackingLimit
        {
            get { return _PackingLimit; }
            set
            {
                if (_PackingLimit != value)
                {
                    _PackingLimit = value;

                    RaisePropertyChanged("PackingLimit");
                }
            }
        }
        private decimal? _PackingLimitHU;
        public decimal? PackingLimitHU
        {
            get { return _PackingLimitHU; }
            set
            {
                if (_PackingLimitHU != value)
                {
                    _PackingLimitHU = value;

                    RaisePropertyChanged("PackingLimitHU");
                }
            }
        }
        private string _ind_residue_packing;
        public string ind_residue_packing // NOTE: Not using in VM because it is control in Backend. remove from here if not required in VM.
        {
            get { return _ind_residue_packing; }
            set
            {
                if (_ind_residue_packing != value)
                {
                    _ind_residue_packing = value;

                    RaisePropertyChanged("ind_residue_packing");
                }
            }
        }
        private string _BarcodeValueWIP;
        public string BarcodeValueWIP
        {
            get { return _BarcodeValueWIP; }
            set
            {
                if (_BarcodeValueWIP != value)
                {
                    _BarcodeValueWIP = value;

                    RaisePropertyChanged("BarcodeValueWIP");
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

        private int _selectedHUCount;
        public int SelectedHUCount // Current Selected HU in View section for Display Purpose 
        {
            get { return _selectedHUCount; }
            set
            {
                if (_selectedHUCount != value)
                {
                    _selectedHUCount = value;
                    RaisePropertyChanged("SelectedHUCount");
                }
            }
        }
        private int _totalHUCount;
        public int TotalHUCount // Current Available HU in View section for Display Purpose 
        {
            get { return _totalHUCount; }
            set
            {
                if (_totalHUCount != value)
                {
                    _totalHUCount = value;
                    RaisePropertyChanged("TotalHUCount");
                }
            }
        }
        private decimal? _packedQty;
        public decimal? PackedQty // Current Packed Quantity for Display Purpose . Not in use currently because text box is used for available count of HUs for selected item and total qty of all count of HUs
        {
            get { return _packedQty; }
            set
            {
                if (_packedQty != value)
                {
                    _packedQty = value;

                    RaisePropertyChanged("PackedQty");
                }
            }
        }
        private int? _hu_count;
        public int? hu_count // available count of HUs for selected item and total qty of all count of HUs
        {
            get { return _hu_count; }
            set
            {
                if (_hu_count != value)
                {
                    _hu_count = value;

                    RaisePropertyChanged("hu_count");
                }
            }
        }
        private decimal? _hu_qty;
        public decimal? hu_qty // total qty of all count of HUs for selected item.
        {
            get { return _hu_qty; }
            set
            {
                if (_hu_qty != value)
                {
                    _hu_qty = value;

                    RaisePropertyChanged("hu_qty");
                }
            }
        }

        #endregion
        #region. AutoSuggest TextBox Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(EPR_T003_STD_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
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
        private AutoSuggestTextViewModel<dynamic> _AS_DOC_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DOC_TYPE
        {
            get { return _AS_DOC_TYPE; }
            set
            {
                if (_AS_DOC_TYPE != value)
                {
                    _AS_DOC_TYPE = value; RaisePropertyChanged("AS_DOC_TYPE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_STORE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_STORE
        {
            get { return _AS_STORE; }
            set
            {
                if (_AS_STORE != value)
                {
                    _AS_STORE = value; RaisePropertyChanged("AS_STORE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_HU_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_HU_TYPE
        {
            get { return _AS_HU_TYPE; }
            set
            {
                if (_AS_HU_TYPE != value)
                {
                    _AS_HU_TYPE = value; RaisePropertyChanged("AS_HU_TYPE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_PACK_MATERIAL { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PACK_MATERIAL
        {
            get { return _AS_PACK_MATERIAL; }
            set
            {
                if (_AS_PACK_MATERIAL != value)
                {
                    _AS_PACK_MATERIAL = value; RaisePropertyChanged("AS_PACK_MATERIAL");
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
        private AutoSuggestTextViewModel<dynamic> _AS_UOM_PKG_MAT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM_PKG_MAT
        {
            get { return _AS_UOM_PKG_MAT; }
            set
            {
                if (_AS_UOM_PKG_MAT != value)
                {
                    _AS_UOM_PKG_MAT = value; RaisePropertyChanged("AS_UOM_PKG_MAT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_UOM_WT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM_WT
        {
            get { return _AS_UOM_WT; }
            set
            {
                if (_AS_UOM_WT != value)
                {
                    _AS_UOM_WT = value; RaisePropertyChanged("AS_UOM_WT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_UOM_VOL { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM_VOL
        {
            get { return _AS_UOM_VOL; }
            set
            {
                if (_AS_UOM_VOL != value)
                {
                    _AS_UOM_VOL = value; RaisePropertyChanged("AS_UOM_VOL");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_UOM_DIM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM_DIM
        {
            get { return _AS_UOM_DIM; }
            set
            {
                if (_AS_UOM_DIM != value)
                {
                    _AS_UOM_DIM = value; RaisePropertyChanged("AS_UOM_DIM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_STATUS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_STATUS
        {
            get { return _AS_STATUS; }
            set
            {
                if (_AS_STATUS != value)
                {
                    _AS_STATUS = value; RaisePropertyChanged("AS_STATUS");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_WC_CODE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_WC_CODE
        {
            get { return _AS_WC_CODE; }
            set
            {
                if (_AS_WC_CODE != value)
                {
                    _AS_WC_CODE = value; RaisePropertyChanged("AS_WC_CODE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ITEM_CODE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ITEM_CODE
        {
            get { return _AS_ITEM_CODE; }
            set
            {
                if (_AS_ITEM_CODE != value)
                {
                    _AS_ITEM_CODE = value; RaisePropertyChanged("AS_ITEM_CODE");
                }
            }
        }

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
                    if (SourceName == "unit_code")
                    { AS_DEFAULT = AS_UOM; }

                }
            }
        }

        #endregion
        #region . Relay Commands .
        public RelayCommand<object> cmd_Split_HU { get; private set; }
        public RelayCommand<object> cmdEmptyHU { get; private set; }
        public RelayCommand<object> cmdLoadDocuments { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdTracePrint { get; private set; }
        public RelayCommand<object> cmdSelectionChangedPacking1 { get; private set; }
        public RelayCommand<object> cmdSelectionChangedPacking2 { get; private set; }
        public RelayCommand<object> cmdSelectionChangedHUPacking1 { get; private set; }
        public RelayCommand<object> cmdSelectionChangedHUPacking2 { get; private set; }
        public RelayCommand<object> cmdSelectionChangedView { get; private set; } // This is only for Counting HU in View Section
        public RelayCommand<object> cmdLoadHUData { get; private set; }
        public RelayCommand<object> cmdLoadMaterialForPacking { get; private set; }
        public RelayCommand<object> cmdLOAD_HU_VIEW_DATA { get; private set; }
        public RelayCommand<object> cmdLOAD_TRACE_DATA { get; private set; }
        public RelayCommand<object> cmdPacking { get; private set; }
        public RelayCommand<object> cmdSplitPacking { get; private set; }
        public RelayCommand<object> cmdPackingHU { get; private set; }
        public RelayCommand<object> cmdMergePacking { get; private set; }
        public RelayCommand<object> cmdInserPackingMaterail { get; private set; }
        public RelayCommand<object> cmdInserPackingMaterailHU { get; private set; }
        public RelayCommand<object> cmdBarcodeScan { get; private set; }
        public RelayCommand<object> cmdBarcodeScanWIP { get; private set; }
        public RelayCommand<object> cmdSelectAllView { get; private set; }
        public RelayCommand<object> cmdExecuteConversion { get; private set; }
        public RelayCommand<object> cmdSelect_ContentChartHU { get; private set; } // Invoke when user select checkBox from Content Chart. then it will auto select in View Tab.
        public RelayCommand<object> cmdUnSelect_ContentChartHU { get; private set; } // Invoke when user Unselect checkBox from Content Chart. then it will auto un select in View Tab.
        private void InitialzeCommands()
        {
            cmdSelect_ContentChartHU = new RelayCommand<object>(items => { if (items == null) { return; } Select_ContentChartHU(items); });
            cmdUnSelect_ContentChartHU = new RelayCommand<object>(items => { if (items == null) { return; } UnSelect_ContentChartHU(items); });
            cmd_Split_HU = new RelayCommand<object>(items => { if (items == null) { return; } Split_HU(items); });
            cmdEmptyHU = new RelayCommand<object>(items => { if (items == null) { return; } MakeEmptyHU(items); });
            //cmdLoadDocuments = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentWithDocumentNumber(items, "FlipGridReference"); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            //cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdSelectionChangedPacking1 = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_Packing1(items); });
            cmdSelectionChangedPacking2 = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_Packing2(items); });
            cmdSelectionChangedHUPacking1 = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_HUPacking1(items); });
            cmdSelectionChangedHUPacking2 = new RelayCommand<object>(items => { if (items == null) { return; } SelectionChanged_HUPacking2(items); });
            cmdSelectionChangedView = new RelayCommand<object>(items => { if (items == null) { return; } GetCount(items); });
            cmdTracePrint = new RelayCommand<object>(items => { if (items == null) { return; } TracePrint(items); });
            cmdLoadHUData = new RelayCommand<object>(items => { if (items == null) { return; } LoadHUData(items); });
            cmdLoadMaterialForPacking = new RelayCommand<object>(items => { if (items == null) { return; } LoadMaterialForPacking(items); });
            cmdLOAD_HU_VIEW_DATA = new RelayCommand<object>(items => { if (items == null) { return; } LOAD_HU_VIEW_DATA(items); });
            cmdLOAD_TRACE_DATA = new RelayCommand<object>(items => { if (items == null) { return; } LOAD_TRACE_DATA(items); });
            cmdPacking = new RelayCommand<object>(items => { if (items == null) { return; } ExecutePacking(items); });
            cmdSplitPacking = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteSplitPacking(items); });
            cmdPackingHU = new RelayCommand<object>(items => { if (items == null) { return; } ExecutePackingHU(items); });
            cmdMergePacking = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteMergePacking(items); });
            cmdInserPackingMaterail = new RelayCommand<object>(items => { if (items == null) { return; } InserPackingMaterail(items); });
            cmdInserPackingMaterailHU = new RelayCommand<object>(items => { if (items == null) { return; } InserPackingMaterailHU(items); });
            cmdBarcodeScan = new RelayCommand<object>(items => { if (items == null) { return; } InsertScannedBarcode(items); });
            cmdBarcodeScanWIP = new RelayCommand<object>(items => { if (items == null) { return; } InsertScannedBarcodeWIP(items); });
            cmdSelectAllView = new RelayCommand<object>(items => { if (items == null) { return; } SelectAllViewRows(items); });
            cmdExecuteConversion = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteConversion(items); });
        }
        private void Select_ContentChartHU(object InputValue) // can be remove this function, we hahe include this code in Function of OK Button below the popup window.
        {
            try
            {
                string STR_OBI_ITEM_HU = (string)InputValue;
                if (MASTER_ENTITY_HU_VIEW != null)
                {
                    MASTER_ENTITY_HU_VIEW.Where(x=> x.doc_no == STR_OBI_ITEM_HU).ToList()[0].selected=true;
                }
            }
            catch (Exception ex) { }
        }
        private void UnSelect_ContentChartHU(object InputValue) // can be remove this function, we hahe include this code in Function of OK Button below the popup window.
        {
            try
            {
                string STR_OBI_ITEM_HU = (string)InputValue;
                if (MASTER_ENTITY_HU_VIEW != null)
                {
                    MASTER_ENTITY_HU_VIEW.Where(x => x.doc_no == STR_OBI_ITEM_HU).ToList()[0].selected = false;
                }
            }
            catch (Exception ex) { }
        }
        private void Split_HU(object InputValue) // This will split selected HU in to two part as per split qty in parameter.
        {
            try
            {
                CursorControl.SetBusyState();
                string strSplitQty = (string)InputValue;
                if (ITEMS_ENTITY_HU_LIST != null && ITEMS_ENTITY_HU != null && !string.IsNullOrWhiteSpace(strSplitQty))
                {
                    if (ITEMS_ENTITY_HU.level_no == 1)
                    {
                        string Request = "Split_HU" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + ITEMS_ENTITY_HU.doc_no + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + strSplitQty;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "EPR_T003_STD", "SCM", "LoadAll", 0, "");

                        if (ITEMS_ENTITY_HU_LIST != null)
                        {
                            if (ITEMS_ENTITY_HU_LIST.Count > 0)
                            {
                                ITEMS_ENTITY_HU_LIST.Remove(ITEMS_ENTITY_HU);
                            }

                        }
                    }
                    else
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Split of Hu can only possible at first level of packing", this.Title); sms.ShowMessage();

                    }
                }
                else
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Input required to Split HU", this.Title); sms.ShowMessage();

                }
            }
            catch (Exception ex) { }
        }
        private void MakeEmptyHU(object InputValue) // can be remove this function, we hahe include this code in Function of OK Button below the popup window.
        {
            try
            {
                CursorControl.SetBusyState();
                EPR_T003_A OBI_ITEM_HU = (EPR_T003_A)InputValue;
                if (ITEMS_ENTITY_HU_LIST != null)
                {
                    string Request = "MakeEmptyHU" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + OBI_ITEM_HU.doc_no + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "EPR_T003_STD", "SCM", "LoadAll", 0, "");

                    if (ITEMS_ENTITY_HU_LIST != null)
                    {
                        if (ITEMS_ENTITY_HU_LIST.Count > 0)
                        {
                            ITEMS_ENTITY_HU_LIST.Remove(OBI_ITEM_HU);
                        }

                    }
                }
            }
            catch (Exception ex) { }
        }
        private void SelectAllViewRows(object InputValue) // can be remove this function, we hahe include this code in Function of OK Button below the popup window.
        {
            try
            {
                if (MASTER_ENTITY_HU_VIEW != null)
                {
                    if (MASTER_ENTITY_HU_VIEW.Count > 0)
                    {
                        foreach (var item in MASTER_ENTITY_HU_VIEW)
                        {
                            if (item.hu_h_level == null)
                            {
                                item.selected = !item.selected;
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void SelectionChanged_Packing1(object InputValue)
        {
            try
            {
                MASTER_ENTITY = (EPR_T003_A)InputValue;
            }
            catch (Exception ex) { }
        }
        private void SelectionChanged_Packing2(object InputValue)
        {
            try
            {
                ITEMS_ENTITY = (EPR_T003_B)InputValue;
            }
            catch (Exception ex) { }
        }
        private void SelectionChanged_HUPacking1(object InputValue)
        {
            try
            {
                MASTER_ENTITY_HU = (EPR_T003_A)InputValue;
            }
            catch (Exception ex) { }
        }
        private void SelectionChanged_HUPacking2(object InputValue)
        {
            try
            {
                ITEMS_ENTITY_HU = (EPR_T003_A)InputValue;
                GetCount(null);
            }
            catch (Exception ex) { }
        }
        private void ExecutePacking(object InputValue)
        {

        }
        private void ExecuteSplitPacking(object InputValue)
        {
            CursorControl.SetBusyState();
            try
            {
                EntityChangeEnable = false;
                if (MASTER_ENTITY != null && ITEMS_ENTITY != null)
                {
                    DefaultValues(doc_cat_vm);
                    MASTER_ENTITY.ind_packing = "S";
                    if (ITEMS_ENTITY_LIST.Count > 0 && MASTER_ENTITY_LIST.Count > 0 && !string.IsNullOrWhiteSpace(ITEMS_ENTITY.batch_no) && !string.IsNullOrWhiteSpace(MASTER_ENTITY.item_code_pack) && !string.IsNullOrWhiteSpace(MASTER_ENTITY.pack_type) && ITEMS_ENTITY.packing_qty.HasValue && ITEMS_ENTITY.partial_qty.HasValue)
                    {
                        MC_EPR_T003 MC_OBJ = new MC_EPR_T003();
                        MC_OBJ.MASTER_ENTITY_LIST = new ObservableCollection<EPR_T003_A>();
                        MC_OBJ.ITEMS_ENTITY_LIST = new ObservableCollection<EPR_T003_B>();
                        MC_OBJ.MASTER_ENTITY_HU_LIST = new ObservableCollection<EPR_T003_A>();
                        MC_OBJ.ITEMS_ENTITY_HU_LIST = new ObservableCollection<EPR_T003_A>();

                        MASTER_ENTITY.tot_qty = ITEMS_ENTITY.partial_qty;
                        MASTER_ENTITY.unit_code = ITEMS_ENTITY.unit_code;
                        MASTER_ENTITY.store_code = MASTER_ENTITY.store_code ?? ITEMS_ENTITY.store_code;
                        MASTER_ENTITY.packing_type = "C";

                        if (Validation(MASTER_ENTITY.ind_packing) == true)
                        {
                            MASTER_ENTITY.ItemCode = ITEMS_ENTITY.item_code; // NOTE: Temp assignment. no need to assign but in case of identical packing on single item in a carton this will help.
                            MC_OBJ.MASTER_ENTITY_LIST.Add(MASTER_ENTITY); // NOTE: use MASTER_ENTITY_LIST for all Master record to save so that we can use logic in backend SP as per ind_packing.
                            MC_OBJ.ITEMS_ENTITY_LIST.Add(ITEMS_ENTITY);

                            MC_OBJ = repository_MC.SaveWithReturnDomainObject<MC_EPR_T003>(MC_OBJ, "EPR_T003_STD", "SCM");
                            if (MASTER_ENTITY_LIST != null)
                            {
                                if (MASTER_ENTITY_LIST.Count > 0)
                                {
                                    MASTER_ENTITY_LIST.Clear();
                                }
                            }
                            if (MASTER_ENTITY_HU_LIST != null)
                            {
                                if (MASTER_ENTITY_HU_LIST.Count > 0)
                                {
                                    MASTER_ENTITY_HU_LIST.Clear();
                                }
                            }
                            if (ITEMS_ENTITY_HU_LIST != null)
                            {
                                if (ITEMS_ENTITY_HU_LIST.Count > 0)
                                {
                                    ITEMS_ENTITY_HU_LIST.Clear();
                                }
                            }

                            foreach (EPR_T003_A item in MC_OBJ.MASTER_ENTITY_LIST)
                            {
                                EPR_T003_A objNew = new EPR_T003_A();
                                item.CopyPropertiesTo<EPR_T003_A>(objNew);
                                MASTER_ENTITY_LIST.Add(objNew);
                                ITEMS_ENTITY_HU_LIST.Add(objNew);
                            }
                            //foreach (EPR_T003_A item in MC_OBJ.MASTER_ENTITY_HU_LIST)
                            //{
                            //    EPR_T003_A objNew = new EPR_T003_A();
                            //    item.CopyPropertiesTo<EPR_T003_A>(objNew);
                            //    MASTER_ENTITY_HU_LIST.Add(objNew);
                            //}
                            //foreach (EPR_T003_A item in MC_OBJ.ITEMS_ENTITY_HU_LIST)
                            //{
                            //    EPR_T003_A objNew = new EPR_T003_A();
                            //    item.CopyPropertiesTo<EPR_T003_A>(objNew);
                            //    ITEMS_ENTITY_HU_LIST.Add(objNew);
                            //}
                            //ObservableCollection<EPR_T003_A> MasterEntityListObj = new ObservableCollection<EPR_T003_A>();
                            //ObservableCollection<EPR_T003_B> SelectedItemEntityList = new ObservableCollection<EPR_T003_B>();


                            //SelectedItemEntityList.Add(ITEMS_ENTITY);
                            //MASTER_ENTITY.XmlDataDocument_EPR_T003_B = obj.ObjectToXML(SelectedItemEntityList);
                            //MasterEntityListObj.Add(MASTER_ENTITY);

                            //MasterEntityListObj = repositoryLst.SaveWithReturnDomainObject<ObservableCollection<EPR_T003_A>>(MasterEntityListObj, "EPR_T003_STD", "SCM");
                            //MASTER_ENTITY_LIST = MasterEntityListObj;

                            //foreach (EPR_T003_A item in MasterEntityListObj)
                            //{
                            //    EPR_T003_A objNew = new EPR_T003_A();
                            //    item.CopyPropertiesTo<EPR_T003_A>(objNew);
                            //    MASTER_ENTITY_HU_LIST.Add(objNew);
                            //}

                            RemoveUpdateReferenceDocuments(MASTER_ENTITY.ind_packing);
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record saved Successfully ........"); sms.ShowMessage();
                        }

                    }
                    else
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Input required parameters", this.Title); sms.ShowMessage();
                    }

                }
                EntityChangeEnable = true;
            }
            catch (Exception ex)
            {
                EntityChangeEnable = true;
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void ExecutePackingHU(object InputValue)
        {
            CursorControl.SetBusyState();
            try
            {
                EntityChangeEnable = false;
                if (MASTER_ENTITY_HU != null && MASTER_ENTITY_HU != null)
                {
                    DefaultValues(doc_cat_vm);
                    MASTER_ENTITY_HU.ind_packing = "H";
                    MASTER_ENTITY_HU.packing_type = "C";//This is consider as complete Packing.
                    if (ITEMS_ENTITY_HU_LIST.Count > 0 && MASTER_ENTITY_HU_LIST.Count > 0 && !string.IsNullOrWhiteSpace(MASTER_ENTITY_HU.item_code_pack) && !string.IsNullOrWhiteSpace(MASTER_ENTITY_HU.pack_type))
                    {
                        if (Validation(MASTER_ENTITY_HU.ind_packing) == true)
                        {
                            MC_EPR_T003 MC_OBJ = new MC_EPR_T003();
                            MC_OBJ.MASTER_ENTITY_LIST = new ObservableCollection<EPR_T003_A>();
                            MC_OBJ.MASTER_ENTITY_HU_LIST = new ObservableCollection<EPR_T003_A>();
                            MC_OBJ.ITEMS_ENTITY_HU_LIST = new ObservableCollection<EPR_T003_A>();
                            MC_OBJ.MASTER_ENTITY_LIST.Add(MASTER_ENTITY_HU); // NOTE: use MASTER_ENTITY_LIST for all Master record to save so that we can use logic in backend SP as per ind_packing.

                            foreach (var item in ITEMS_ENTITY_HU_LIST)
                            {
                                if (item.selected == true)
                                {
                                    MC_OBJ.ITEMS_ENTITY_HU_LIST.Add(item);
                                    MASTER_ENTITY_HU.unit_code = item.unit_code;
                                    MASTER_ENTITY_HU.ItemCode = item.item_code;
                                }
                            }

                            MC_OBJ = repository_MC.SaveWithReturnDomainObject<MC_EPR_T003>(MC_OBJ, "EPR_T003_STD_HU", "SCM");
                            if (MC_OBJ.MASTER_ENTITY_HU_LIST.Count > 0)
                            {
                                MASTER_ENTITY_HU = MC_OBJ.MASTER_ENTITY_HU_LIST[0];
                                ITEMS_ENTITY_HU_LIST.Add(MASTER_ENTITY_HU);
                                MASTER_ENTITY_HU = new EPR_T003_A();

                            }

                            foreach (var item in MASTER_ENTITY_HU_LIST.ToList())
                            {
                                MASTER_ENTITY_HU_LIST.Remove(item);
                            }

                            foreach (var item in ITEMS_ENTITY_HU_LIST.ToList())
                            {
                                if (item.selected == true)
                                {
                                    ITEMS_ENTITY_HU_LIST.Remove(item);
                                }
                            }


                            //if (MASTER_ENTITY_HU_LIST != null)
                            //{
                            //    if (MASTER_ENTITY_HU_LIST.Count > 0)
                            //    {
                            //        MASTER_ENTITY_HU_LIST.Clear();
                            //    }
                            //}
                            //if (ITEMS_ENTITY_HU_LIST != null)
                            //{
                            //    if (ITEMS_ENTITY_HU_LIST.Count > 0)
                            //    {
                            //        ITEMS_ENTITY_HU_LIST.Clear();
                            //    }
                            //}
                            //foreach (EPR_T003_A item in MC_OBJ.MASTER_ENTITY_HU_LIST)
                            //{
                            //    EPR_T003_A objNew = new EPR_T003_A();
                            //    item.CopyPropertiesTo<EPR_T003_A>(objNew);
                            //    MASTER_ENTITY_HU_LIST.Add(objNew);
                            //}
                            //foreach (EPR_T003_A item in MC_OBJ.ITEMS_ENTITY_HU_LIST)
                            //{
                            //    EPR_T003_A objNew = new EPR_T003_A();
                            //    item.CopyPropertiesTo<EPR_T003_A>(objNew);
                            //    ITEMS_ENTITY_HU_LIST.Add(objNew);
                            //}

                            //RemoveUpdateReferenceDocuments(MASTER_ENTITY_HU.ind_packing);
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record saved Successfully ........"); sms.ShowMessage();
                        }

                    }
                    else
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert External Handling Unit Details first!", this.Title); sms.ShowMessage();
                        ITEMS_ENTITY_HU.selected = false;
                    }

                }
                EntityChangeEnable = true;
            }
            catch (Exception ex)
            {
                EntityChangeEnable = true;
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void ExecuteMergePacking(object InputValue)
        {
            CursorControl.SetBusyState();
            try
            {
                EntityChangeEnable = false;
                if (MASTER_ENTITY != null && ITEMS_ENTITY != null)
                {
                    DefaultValues(doc_cat_vm);
                    MASTER_ENTITY.doc_type = "ML";
                    MASTER_ENTITY.ind_packing = "M";
                    if (ITEMS_ENTITY_LIST.Count > 0 && MASTER_ENTITY_LIST.Count > 0 && !string.IsNullOrWhiteSpace(MASTER_ENTITY.item_code_pack) && !string.IsNullOrWhiteSpace(MASTER_ENTITY.pack_type))
                    {
                        MC_EPR_T003 MC_OBJ = new MC_EPR_T003();
                        MC_OBJ.MASTER_ENTITY_LIST = new ObservableCollection<EPR_T003_A>();
                        MC_OBJ.ITEMS_ENTITY_LIST = new ObservableCollection<EPR_T003_B>();
                        MC_OBJ.MASTER_ENTITY_HU_LIST = new ObservableCollection<EPR_T003_A>();
                        MC_OBJ.ITEMS_ENTITY_HU_LIST = new ObservableCollection<EPR_T003_A>();
                        // NOTE: use MASTER_ENTITY_LIST for all Master record to save so that we can use logic in backend SP as per ind_packing.
                        MASTER_ENTITY.tot_qty = 0;
                        MASTER_ENTITY.packing_type = "C";
                        foreach (EPR_T003_B item in ITEMS_ENTITY_LIST)
                        {
                            if (item.selected == true)
                            {
                                MC_OBJ.ITEMS_ENTITY_LIST.Add(item);
                                MASTER_ENTITY.tot_qty = (MASTER_ENTITY.tot_qty ?? 0) + item.partial_qty;
                                MASTER_ENTITY.unit_code = item.unit_code;
                                MASTER_ENTITY.store_code = item.store_code;
                                MASTER_ENTITY.ItemCode = item.item_code;
                            }
                        }
                        if (Validation(MASTER_ENTITY.ind_packing) == true)
                        {

                            MC_OBJ.MASTER_ENTITY_LIST.Add(MASTER_ENTITY);

                            MC_OBJ = repository_MC.SaveWithReturnDomainObject<MC_EPR_T003>(MC_OBJ, "EPR_T003_STD_MERGE", "SCM");
                            if (MASTER_ENTITY_LIST != null)
                            {
                                if (MASTER_ENTITY_LIST.Count > 0)
                                {
                                    MASTER_ENTITY_LIST.Clear();
                                }
                            }
                            if (MASTER_ENTITY_HU_LIST != null)
                            {
                                if (MASTER_ENTITY_HU_LIST.Count > 0)
                                {
                                    MASTER_ENTITY_HU_LIST.Clear();
                                }
                            }
                            if (ITEMS_ENTITY_HU_LIST != null)
                            {
                                if (ITEMS_ENTITY_HU_LIST.Count > 0)
                                {
                                    ITEMS_ENTITY_HU_LIST.Clear();
                                }
                            }

                            foreach (EPR_T003_A item in MC_OBJ.MASTER_ENTITY_LIST)
                            {
                                EPR_T003_A objNew = new EPR_T003_A();
                                item.CopyPropertiesTo<EPR_T003_A>(objNew);
                                MASTER_ENTITY_LIST.Add(objNew);
                                ITEMS_ENTITY_HU_LIST.Add(objNew);
                            }


                            RemoveUpdateReferenceDocuments(MASTER_ENTITY.ind_packing);
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record saved Successfully ........"); sms.ShowMessage();
                        }

                    }
                    else
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Input required parameters", this.Title); sms.ShowMessage();
                    }

                }
                EntityChangeEnable = true;
            }
            catch (Exception ex)
            {
                EntityChangeEnable = true;
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void ExecuteConversion(object InputValue)
        {
            CursorControl.SetBusyState();
            try
            {
                EntityChangeEnable = false;
                if (MASTER_ENTITY_HU != null && MASTER_ENTITY_HU != null)
                {
                    DefaultValues(doc_cat_vm);
                    MASTER_ENTITY_HU.ind_packing = "H";
                    if (ITEMS_ENTITY_HU_LIST.Count > 0 && MASTER_ENTITY_HU_LIST.Count > 0 && !string.IsNullOrWhiteSpace(MASTER_ENTITY_HU.item_code_pack) && !string.IsNullOrWhiteSpace(MASTER_ENTITY_HU.pack_type))
                    {
                        if (Validation(MASTER_ENTITY_HU.ind_packing) == true)
                        {
                            MC_EPR_T003 MC_OBJ = new MC_EPR_T003();
                            MC_OBJ.MASTER_ENTITY_LIST = new ObservableCollection<EPR_T003_A>();
                            MC_OBJ.MASTER_ENTITY_HU_LIST = new ObservableCollection<EPR_T003_A>();
                            MC_OBJ.ITEMS_ENTITY_HU_LIST = new ObservableCollection<EPR_T003_A>();
                            MC_OBJ.MASTER_ENTITY_LIST.Add(MASTER_ENTITY_HU); // NOTE: use MASTER_ENTITY_LIST for all Master record to save so that we can use logic in backend SP as per ind_packing.

                            foreach (var item in ITEMS_ENTITY_HU_LIST)
                            {
                                if (item.selected == true)
                                {
                                    MC_OBJ.ITEMS_ENTITY_HU_LIST.Add(item);
                                    MASTER_ENTITY_HU.unit_code = item.unit_code;
                                }
                            }
                            MC_OBJ = repository_MC.SaveWithReturnDomainObject<MC_EPR_T003>(MC_OBJ, "EPR_T003_STD_HU", "SCM");
                            if (MC_OBJ.MASTER_ENTITY_HU_LIST.Count > 0)
                            {
                                MASTER_ENTITY_HU = MC_OBJ.MASTER_ENTITY_HU_LIST[0];
                                ITEMS_ENTITY_HU_LIST.Add(MASTER_ENTITY_HU);
                                MASTER_ENTITY_HU = new EPR_T003_A();

                            }
                            foreach (var item in MASTER_ENTITY_HU_LIST.ToList())
                            {
                                MASTER_ENTITY_HU_LIST.Remove(item);
                            }

                            foreach (var item in ITEMS_ENTITY_HU_LIST.ToList())
                            {
                                if (item.selected == true)
                                {
                                    ITEMS_ENTITY_HU_LIST.Remove(item);
                                }
                            }
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Record saved Successfully ........"); sms.ShowMessage();
                        }
                    }
                    else
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert External Handling Unit Details first!", this.Title); sms.ShowMessage();
                        ITEMS_ENTITY_HU.selected = false;
                    }
                }
                EntityChangeEnable = true;
            }
            catch (Exception ex)
            {
                EntityChangeEnable = true;
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private bool Validation(string ind_packing)
        {
            try
            {
                sms.ButtonSetup = DialogButton.Ok;
                sms.Caption = "Message";

                if ((ind_packing == "S" || ind_packing == "P" || ind_packing == "M") && (string.IsNullOrWhiteSpace(MASTER_ENTITY.pack_type) == true || string.IsNullOrWhiteSpace(MASTER_ENTITY.store_code) == true || string.IsNullOrWhiteSpace(MASTER_ENTITY.item_code_pack) == true || string.IsNullOrWhiteSpace(MASTER_ENTITY.uom_item_code_pack) == true || MASTER_ENTITY.qty_item_code_pack.HasValue != true || MASTER_ENTITY.net_wt.HasValue != true || MASTER_ENTITY.tare_wt.HasValue != true || MASTER_ENTITY.gross_wt.HasValue != true))
                {
                    sms.Text = String.Format("Packing Material Information required", this.Title); sms.ShowMessage();
                    return false;
                }
                if ((ind_packing == "H") && (string.IsNullOrWhiteSpace(MASTER_ENTITY_HU.pack_type) == true || string.IsNullOrWhiteSpace(MASTER_ENTITY_HU.store_code) == true || string.IsNullOrWhiteSpace(MASTER_ENTITY_HU.item_code_pack) == true || string.IsNullOrWhiteSpace(MASTER_ENTITY_HU.uom_item_code_pack) == true || MASTER_ENTITY_HU.qty_item_code_pack.HasValue != true || MASTER_ENTITY_HU.net_wt.HasValue != true || MASTER_ENTITY_HU.tare_wt.HasValue != true || MASTER_ENTITY_HU.gross_wt.HasValue != true))
                {
                    sms.Text = String.Format("Packing Material Information required", this.Title); sms.ShowMessage();
                    return false;
                }
                if (ind_packing == "S" || ind_packing == "P")
                {
                    if (ITEMS_ENTITY.partial_qty.HasValue != true || ITEMS_ENTITY.packing_qty.HasValue != true || string.IsNullOrWhiteSpace(ITEMS_ENTITY.store_code) == true || string.IsNullOrWhiteSpace(ITEMS_ENTITY.unit_code) == true)
                    {
                        sms.Text = String.Format("Packing Material Information required", this.Title); sms.ShowMessage();
                        return false;
                    }
                }
                if ((ind_packing == "S" || ind_packing == "P" || ind_packing == "M") && (MASTER_ENTITY.ind_packing == "M"))
                {
                    int xc = 0;
                    foreach (EPR_T003_B item in ITEMS_ENTITY_LIST)
                    {
                        if (item.selected == true)
                        {
                            xc = xc + 1;
                            if (item.selected.HasValue != true || item.partial_qty.HasValue != true || item.packing_qty.HasValue != true || string.IsNullOrWhiteSpace(item.store_code) == true || string.IsNullOrWhiteSpace(item.unit_code) == true)
                            {
                                sms.Text = String.Format("Packing Material Information required", this.Title); sms.ShowMessage();
                                return false;
                            }
                        }
                    }
                    if (xc == 0)
                    {
                        sms.Text = String.Format("Material not selected for Packing", this.Title); sms.ShowMessage();
                        return false;
                    }
                }
                if ((ind_packing == "H") && (MASTER_ENTITY_HU.ind_packing == "H"))
                {
                    int xc = 0;
                    foreach (EPR_T003_A item in ITEMS_ENTITY_HU_LIST)
                    {
                        if (item.selected == true)
                        {
                            xc = xc + 1;
                        }
                    }
                    if (xc == 0)
                    {
                        sms.Text = String.Format("Handling Units not selected for Packing", this.Title); sms.ShowMessage();
                        return false;
                    }
                }
                return true;

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
            return true;
        }
        private void LoadMaterialForPacking(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                //if (REQ_PARA_OBJ.from_date.HasValue != true)
                //{
                //    sms.ButtonSetup = DialogButton.OkCancel; sms.Caption = "Message"; sms.Text = String.Format("Please Select production date ", this.Title); sms.ShowMessage();
                //}
                //else
                //{
                string Request = "LoadMaterialForPacking" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + REQ_PARA_OBJ.wc_code + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@!@!@!@" + REQ_PARA_OBJ.item_code + "!@!@!@" + (REQ_PARA_OBJ.from_date.HasValue ? Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") : "") + "!@" + (REQ_PARA_OBJ.to_date.HasValue ? Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy") : "") + "!@" + REQ_PARA_OBJ.store_code;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "EPR_T003_STD", "SCM", "LoadAll", 0, "");

                if (ITEMS_ENTITY_LIST != null)
                {
                    if (ITEMS_ENTITY_LIST.Count > 0)
                    {
                        ITEMS_ENTITY_LIST.Clear();
                    }
                    if (MCTemp.ITEMS_ENTITY_LIST != null)
                    {
                        if (MCTemp.ITEMS_ENTITY_LIST.Count > 0)
                        {
                            ITEMS_ENTITY_LIST = MCTemp.ITEMS_ENTITY_LIST;
                        }
                        else
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Material Record Not Found for Selected Filters", this.Title); sms.ShowMessage();
                        }
                    }
                    else
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Material Record Not Found for Selected Filters", this.Title); sms.ShowMessage();
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
        private void LoadHUData(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                //if (REQ_PARA_OBJ.from_date.HasValue != true)
                //{
                //    sms.ButtonSetup = DialogButton.OkCancel; sms.Caption = "Message"; sms.Text = String.Format("Please Select production date ", this.Title); sms.ShowMessage();
                //}
                //else
                //{
                string Request = "LoadHUsForPacking" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + REQ_PARA_OBJ.wc_code + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@!@!@!@" + REQ_PARA_OBJ.item_code + "!@!@!@" + (REQ_PARA_OBJ.from_date.HasValue ? Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") : "") + "!@" + (REQ_PARA_OBJ.to_date.HasValue ? Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy") : "") + "!@" + REQ_PARA_OBJ.store_code;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "EPR_T003_STD", "SCM", "LoadAll", 0, "");

                ITEMS_ENTITY_HU_LIST = MCTemp.ITEMS_ENTITY_HU_LIST;
               
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
        private void LOAD_HU_VIEW_DATA(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                if (MASTER_ENTITY_HU_VIEW != null)
                {
                    if (MASTER_ENTITY_HU_VIEW.Count > 0)
                    {
                        MASTER_ENTITY_HU_VIEW.Clear();
                    }
                }
                string Request = "LOAD_HU_VIEW_DATA" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + REQ_PARA_OBJ.wc_code + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm + "!@" + REQ_PARA_OBJ.para1 + "!@!@!@" + REQ_PARA_OBJ.item_code + "!@!@!@" + (REQ_PARA_OBJ.from_date.HasValue ? Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") : "") + "!@" + (REQ_PARA_OBJ.to_date.HasValue ? Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy") : "") + "!@" + REQ_PARA_OBJ.store_code;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_EPR_T003>(MC, Request, "EPR_T003_STD", "SCM", "LoadAll", 0, "");

                foreach (var item in MCTemp.MASTER_ENTITY_HU_LIST)
                {
                    if (!MASTER_ENTITY_HU_VIEW.Any(x => x.barcode == item.barcode))
                    {
                        MASTER_ENTITY_HU_VIEW.Add(item);
                    }
                    //else if(MASTER_ENTITY_HU_VIEW.Any(x => Convert.ToDateTime(x.carton_pack_dt).Date < Convert.ToDateTime("03/03/2020"))) // NOTE: remove this loop only when CRI Go Live.
                    //{
                    //    MASTER_ENTITY_HU_VIEW.Add(item);
                    //}
                }

                var objCollection = (from o in MASTER_ENTITY_HU_VIEW where o.hu_h_level == null select o).ToList();
                TotalHUCount = objCollection.Count;
                LabelCollection = CollectionViewSource.GetDefaultView(objCollection);
                LabelCollection.Filter = new Predicate<object>(Filter_HU_View);

                // for tree view start
                if (ItemsSet != null)
                {
                    if(ItemsSet.Tables.Count > 0)
                    {
                        ItemsSet.Relations.RemoveAt(0);
                        ItemsSet.Tables.Clear();
                    }
                    ItemsSet.Tables.Add(ConvertToDataTable(MASTER_ENTITY_HU_VIEW));
                }
                else
                {
                    ItemsSet.Tables.Add(ConvertToDataTable(MASTER_ENTITY_HU_VIEW));
                }
                
                //ItemsSet.Relations.Add("FK", ItemsSet.Tables[0].Columns["Id"], ItemsSet.Tables[0].Columns["ParentID"]);

                if (ItemsSet.Relations.Count == 0)
                {
                    ItemsSet.Relations.Add("rsParentChild",
                            ItemsSet.Tables[0].Columns["doc_no"],
                            ItemsSet.Tables[0].Columns["hu_h_level"], false);
                    ItemsView = ItemsSet.Tables[0].DefaultView;
                    ItemsView.RowFilter = "hu_h_level IS NULL"; //see what happens when i am commented out
                }

                // for tree view end
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void LOAD_TRACE_DATA(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                
                string Request = "LOAD_TRACE_DATA" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + (REQ_PARA_OBJ.location_id ?? AppSessionState.location_Id) + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + REQ_PARA_OBJ.barcode;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_EPR_T003>(MC, Request, "EPR_T003_STD", "SCM", "LoadAll", 0, "");

                // for tree view start
                if (ItemsSet != null)
                {
                    if (ItemsSet.Tables.Count > 0)
                    {
                        ItemsSet.Relations.RemoveAt(0);
                        ItemsSet.Tables.Clear();
                    }
                    ItemsSet.Tables.Add(ConvertToDataTable(MCTemp.MASTER_ENTITY_HU_LIST));
                }
                else
                {
                    ItemsSet.Tables.Add(ConvertToDataTable(MCTemp.MASTER_ENTITY_HU_LIST));
                }

                if (ItemsSet.Relations.Count == 0)
                {
                    ItemsSet.Relations.Add("rsParentChild",
                            ItemsSet.Tables[0].Columns["doc_no"],
                            ItemsSet.Tables[0].Columns["hu_h_level"], false);
                    ItemsViewTrace = ItemsSet.Tables[0].DefaultView;
                    ItemsViewTrace.RowFilter = "hu_h_level IS NULL"; //see what happens when i am commented out
                }

                // for tree view end
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }
        private void InserPackingMaterail(object InputValue)
        {
            try
            {
                string Request = "";
                STD_ITEM POPUPEntityObject = null;
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
                            POPUPEntityObject = MC.STD_ITEM_LIST_PKG.Where(x => x.item_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.item_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_ITEM>().ToList()[0];
                }

                #endregion
                if (MASTER_ENTITY != null && POPUPEntityObject != null)
                {
                    MASTER_ENTITY.unit_code = POPUPEntityObject.unit_code;
                    MASTER_ENTITY.uom_item_code_pack = POPUPEntityObject.unit_code;
                    MASTER_ENTITY.qty_item_code_pack = 1;
                    MASTER_ENTITY.ItemName = POPUPEntityObject.item_name;
                    MASTER_ENTITY.tare_wt = POPUPEntityObject.net_wt;
                    //MASTER_ENTITY.net_wt = POPUPEntityObject.net_wt;
                    MASTER_ENTITY.weight_unit = POPUPEntityObject.weight_unit;
                    MASTER_ENTITY.volume = POPUPEntityObject.volume;
                    MASTER_ENTITY.volume_unit = POPUPEntityObject.volume_unit;
                    MASTER_ENTITY.ItemCode = POPUPEntityObject.ItemCode;
                    MASTER_ENTITY.user_source1 = POPUPEntityObject.unit_code;
                    MASTER_ENTITY.packing_type = "C";
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void InserPackingMaterailHU(object InputValue)
        {
            try
            {
                string Request = "";
                STD_ITEM POPUPEntityObject = null;
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
                            POPUPEntityObject = MC.STD_ITEM_LIST_PKG.Where(x => x.item_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.item_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_ITEM>().ToList()[0];
                }

                #endregion
                if (MASTER_ENTITY != null && POPUPEntityObject != null)
                {
                    MASTER_ENTITY_HU.unit_code = POPUPEntityObject.unit_code;
                    MASTER_ENTITY_HU.uom_item_code_pack = POPUPEntityObject.unit_code;
                    MASTER_ENTITY_HU.qty_item_code_pack = 1;
                    MASTER_ENTITY_HU.ItemName = POPUPEntityObject.item_name;
                    MASTER_ENTITY_HU.tare_wt = POPUPEntityObject.net_wt;
                    //MASTER_ENTITY_HU.net_wt = POPUPEntityObject.net_wt;
                    MASTER_ENTITY_HU.weight_unit = POPUPEntityObject.weight_unit;
                    MASTER_ENTITY_HU.volume = POPUPEntityObject.volume;
                    MASTER_ENTITY_HU.volume_unit = POPUPEntityObject.volume_unit;
                    MASTER_ENTITY_HU.ItemCode = POPUPEntityObject.ItemCode;
                    MASTER_ENTITY.user_source1 = POPUPEntityObject.unit_code;
                    MASTER_ENTITY.packing_type = "C";
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }

        }
        private void InsertScannedBarcode(object InputValue)
        {
            try
            {
                EPR_T003_A POPUPEntityObject = null;
                BarcodeValue = InputValue.ToString();
                if (BarcodeValue.Length > 9 && ITEMS_ENTITY_HU_LIST != null)
                {
                    if (ITEMS_ENTITY_HU_LIST.Where(x => x.selected == true).ToList().Count < PackingLimit)
                    {
                        POPUPEntityObject = ITEMS_ENTITY_HU_LIST.Where(X => X.barcode == BarcodeValue).FirstOrDefault();
                        if (POPUPEntityObject != null)
                        {
                            if (!string.IsNullOrWhiteSpace(MASTER_ENTITY_HU.item_code_pack) && ITEMS_ENTITY_HU_LIST.Count > 0)
                            {
                                int T = 0;
                                foreach (var item1 in ITEMS_ENTITY_HU_LIST)
                                {
                                    foreach (var item2 in ITEMS_ENTITY_HU_LIST)
                                    {
                                        if (item1.selected == true && item2.selected == true && (item1.item_code != item2.item_code || (item1.sku ?? "") != (item2.sku ?? "")))
                                        {
                                            T = T + 1;
                                        }
                                    }
                                }
                                if (T > 0)
                                {
                                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("This Handling Unit contains different Material other than already Packed Material!", this.Title); sms.ShowMessage();
                                }
                                else
                                {
                                    POPUPEntityObject.selected = true;
                                    ITEMS_ENTITY_HU_LIST.OrderBy(x => x.selected).ToList();
                                }

                            }
                            else
                            {
                                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert External Handling Unit Details first!", this.Title); sms.ShowMessage();
                            }
                        }
                        else
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Handling Unit not exists or already Packed", this.Title); sms.ShowMessage();
                        }
                    }
                    else
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Packing of Number of Handling Unit Limit is Completed", this.Title); sms.ShowMessage();
                        ITEMS_ENTITY_HU.selected = false;
                    }
                    BarcodeValue = "";
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertScannedBarcodeWIP(object InputValue)
        {
            try
            {
                BarcodeValueWIP = InputValue.ToString();
                if (BarcodeValueWIP.Length > 9)
                {
                    string Request = "LoadMaterialForPackingOnBarcodeScanning" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + BarcodeValueWIP + "!@" + AppSessionState.UserID + "!@" + AppSessionState.EmpId + "!@" + ts_code_vm;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "EPR_T003_STD", "SCM", "LoadAll", 0, "");

                    if (ITEMS_ENTITY_LIST != null && MCTemp.ITEMS_ENTITY_LIST != null)
                    {
                        if (MCTemp.ITEMS_ENTITY_LIST.Count > 0)
                        {
                            if (ITEMS_ENTITY_LIST.Count > 0)
                            {
                                ITEMS_ENTITY_LIST.Clear();
                            }
                            ITEMS_ENTITY_LIST = MCTemp.ITEMS_ENTITY_LIST;
                        }
                    }
                    else
                    {
                        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert External Handling Unit Details first!", this.Title); sms.ShowMessage();
                    }

                }
                BarcodeValueWIP = "";
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        #endregion
        #region . Constructor .
        public EPR_T003_STD_VM(string doc_cat, string ts_code) : base()
        {
            ReportOption = "Barcode";
            this.ts_code_vm = ts_code;
            this.doc_cat_vm = doc_cat;
            MC = new MC_EPR_T003();
            MCTemp = new MC_EPR_T003();
            MASTER_ENTITY = new EPR_T003_A();
            ITEMS_ENTITY = new EPR_T003_B();
            MASTER_ENTITY_HU = new EPR_T003_A();
            ITEMS_ENTITY_HU = new EPR_T003_A();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();

            MASTER_ENTITY_LIST = new ObservableCollection<EPR_T003_A>();
            ITEMS_ENTITY_LIST = new ObservableCollection<EPR_T003_B>();
            MASTER_ENTITY_HU_LIST = new ObservableCollection<EPR_T003_A>();
            ITEMS_ENTITY_HU_LIST = new ObservableCollection<EPR_T003_A>();
            MASTER_ENTITY_HU_VIEW = new ObservableCollection<EPR_T003_A>();

            ITEMS_ENTITY_HU_LIST.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotify_HU_ITEMS);

            EPR_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            EPR_T003_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            sms = this.GetViewService<IShowMessageViewService>();
            SelectedHUCount = 0;
            TotalHUCount = 0;
            PackedQty = 0;
            hu_count = 0;
            hu_qty = 0;
            InitialzeCommands();
        }
        #endregion

        void GetCount(object para)
        {
            SelectedHUCount = 0;
            PackedQty = 0;
            hu_count = 0;
            hu_qty = 0;

            if (ITEMS_ENTITY_HU_LIST != null) 
            {
                foreach (EPR_T003_A item in ITEMS_ENTITY_HU_LIST)
                {
                    if (item.item_code == ITEMS_ENTITY_HU.item_code)
                    {
                        hu_count++;
                        hu_qty = hu_qty + item.tot_qty;
                    }
                }
            }
            
            //following code not in use at but not sure for both.
            if (MASTER_ENTITY_HU_VIEW != null)
            {
                foreach (EPR_T003_A item in MASTER_ENTITY_HU_VIEW)
                {
                    if (item.selected == true)
                    {
                        SelectedHUCount++;
                    }
                }
            }
            if(ITEMS_ENTITY_HU_LIST != null)
            {
                foreach (EPR_T003_A item in ITEMS_ENTITY_HU_LIST)
                {
                    if (item.selected == true)
                    {
                        PackedQty = PackedQty + item.tot_qty;
                    }
                }
            }

        }
        void TracePrint(object para)
        {
            try
            {
                string report_name = "";
                report_name = "ALLTYPEPKTSTICKERFORMAT.rdlc";
                //ItemsSet.Tables.Add(ConvertToDataTable(MCTemp.MASTER_ENTITY_HU_LIST));
                CursorControl.SetBusyState();
                QRCodeService QRGenerator = new QRCodeService();
                object[] objDataSource = new object[3];
                string[] objDataSourceName = new string[3];
                List<RptLabelGen> rptListObj = new List<RptLabelGen>();

                foreach (DataTable table in ItemsSet.Tables)
                {

                    foreach (DataRow dr in table.Rows)
                    {
                        if (dr["selected"].ToString() == "True")
                        {
                            RptLabelGen lblObj = new RptLabelGen();
                            lblObj.ball_dia = Convert.ToDecimal(dr["ball_dia"].ToString());
                            lblObj.ball_type = dr["ball_type"].ToString();
                            lblObj.wire_type = dr["wire_type"].ToString();
                            lblObj.barcode = dr["barcode"].ToString();
                            lblObj.batch_no = dr["batch_no"].ToString();
                            lblObj.batch_no_m = dr["batch_no"].ToString();
                            lblObj.ild = dr["Ild"].ToString();
                            lblObj.ink = dr["Ink"].ToString();
                            lblObj.ItemCode = dr["item_code"].ToString();
                            lblObj.ItemName = dr["item_name"].ToString();
                            lblObj.label_qty = Convert.ToDecimal(dr["tot_qty"].ToString());
                            lblObj.machinecode = dr["wc_code"].ToString();
                            lblObj.modelno = dr["modelno"].ToString();
                            lblObj.net_wt = Convert.ToDecimal(dr["net_wt"].ToString());
                            lblObj.qr_batch = QRGenerator.RenderQrCodeForLabel(dr["barcode"].ToString(), 15, "");
                            lblObj.tot_qty = Convert.ToDecimal(dr["tot_qty"].ToString());
                            lblObj.unit_code = dr["unit_code"].ToString();
                            lblObj.doc_type = dr["doc_type"].ToString();
                            lblObj.pack_type = dr["pack_type"].ToString();
                            lblObj.total_len = dr["total_len"].ToString();
                            lblObj.weight_unit = dr["weight_unit"].ToString();
                            lblObj.gross_wt = Convert.ToDecimal(dr["gross_wt"].ToString());

                            rptListObj.Add(lblObj);
                        }
                    }
                }

                objDataSource[0] = rptListObj;
                objDataSourceName[0] = "dsRptLabelGen";
                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + report_name, MC.DOC_TYPE_SETTINGS_LIST[0].report_name);




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
            try
            {
                if (EntityChangeEnable == true)
                {
                    if ((sender.ToString() == "item_code_pack" || sender.ToString() == "unit_price") && MASTER_ENTITY != null)
                    {
                        if (!string.IsNullOrWhiteSpace(MASTER_ENTITY.item_code_pack))
                        {
                            STD_ITEM ITEM_OBJ = MC.STD_ITEM_LIST_PKG.Where(x => x.item_code.Equals(MASTER_ENTITY.item_code_pack, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            MASTER_ENTITY.unit_code = ITEM_OBJ.unit_code;
                            MASTER_ENTITY.uom_item_code_pack = ITEM_OBJ.unit_code;
                            MASTER_ENTITY.qty_item_code_pack = 1;
                            MASTER_ENTITY.ItemName = ITEM_OBJ.item_name;
                            MASTER_ENTITY.tare_wt = ITEM_OBJ.net_wt;
                            //MASTER_ENTITY.net_wt = ITEM_OBJ.net_wt;
                            MASTER_ENTITY.weight_unit = ITEM_OBJ.weight_unit;
                            MASTER_ENTITY.volume = ITEM_OBJ.volume;
                            MASTER_ENTITY.volume_unit = ITEM_OBJ.volume_unit;
                            MASTER_ENTITY.ItemCode = ITEM_OBJ.ItemCode;
                            MASTER_ENTITY.user_source1 = ITEM_OBJ.unit_code;
                            MASTER_ENTITY.packing_type = "C";
                        }
                        if (!string.IsNullOrWhiteSpace(MASTER_ENTITY_HU.item_code_pack))
                        {
                            STD_ITEM ITEM_OBJ = MC.STD_ITEM_LIST_PKG.Where(x => x.item_code.Equals(MASTER_ENTITY_HU.item_code_pack, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            MASTER_ENTITY_HU.unit_code = ITEM_OBJ.unit_code;
                            MASTER_ENTITY_HU.uom_item_code_pack = ITEM_OBJ.unit_code;
                            MASTER_ENTITY_HU.qty_item_code_pack = 1;
                            MASTER_ENTITY_HU.ItemName = ITEM_OBJ.item_name;
                            MASTER_ENTITY_HU.tare_wt = ITEM_OBJ.net_wt;
                            //MASTER_ENTITY_HU.net_wt = ITEM_OBJ.net_wt;
                            MASTER_ENTITY_HU.weight_unit = ITEM_OBJ.weight_unit;
                            MASTER_ENTITY_HU.volume = ITEM_OBJ.volume;
                            MASTER_ENTITY_HU.volume_unit = ITEM_OBJ.volume_unit;
                            MASTER_ENTITY_HU.ItemCode = ITEM_OBJ.ItemCode;
                            MASTER_ENTITY_HU.user_source1 = ITEM_OBJ.unit_code;
                            MASTER_ENTITY_HU.packing_type = "C";
                        }
                    }
                    if (MASTER_ENTITY_HU != null && ITEMS_ENTITY_HU_LIST != null && sender.ToString() == "selected")
                    {
                        if (!string.IsNullOrWhiteSpace(MASTER_ENTITY_HU.item_code_pack) && ITEMS_ENTITY_HU_LIST.Count > 0)
                        {
                            if (ITEMS_ENTITY_HU_LIST.Where(x => x.selected == true).ToList().Count <= PackingLimit) // && ITEMS_ENTITY_HU.selected==true
                            {
                                STD_ITEM ITEM_OBJ = MC.STD_ITEM_LIST_PKG.Where(x => x.item_code.Equals(MASTER_ENTITY_HU.item_code_pack, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                                MASTER_ENTITY_HU.gross_wt = ITEMS_ENTITY_HU_LIST.Where(item => item.active != false && item.selected == true).Sum(item => Convert.ToDecimal(item.gross_wt ?? 0));
                                MASTER_ENTITY_HU.net_wt = ITEMS_ENTITY_HU_LIST.Where(item => item.active != false && item.selected == true).Sum(item => Convert.ToDecimal(item.net_wt ?? 0));
                                MASTER_ENTITY_HU.tare_wt = (ITEM_OBJ.net_wt ?? 0) + ITEMS_ENTITY_HU_LIST.Where(item => item.active != false && item.level_no != 1 && item.packing_type != "R" && item.selected == true).Sum(item => Convert.ToDecimal(item.tare_wt ?? 0));
                                MASTER_ENTITY_HU.loading_wt = ITEMS_ENTITY_HU_LIST.Where(item => item.active != false && item.selected == true).Sum(item => Convert.ToDecimal(item.loading_wt ?? 0));
                                MASTER_ENTITY_HU.tare_volume = ITEMS_ENTITY_HU_LIST.Where(item => item.active != false && item.selected == true).Sum(item => Convert.ToDecimal(item.tare_volume ?? 0));
                                MASTER_ENTITY_HU.volume = ITEMS_ENTITY_HU_LIST.Where(item => item.active != false && item.selected == true).Sum(item => Convert.ToDecimal(item.volume ?? 0));
                                MASTER_ENTITY_HU.volume_loading = ITEMS_ENTITY_HU_LIST.Where(item => item.active != false && item.selected == true).Sum(item => Convert.ToDecimal(item.volume_loading ?? 0));
                                MASTER_ENTITY_HU.tot_qty = ITEMS_ENTITY_HU_LIST.Where(item => item.active != false && item.selected == true).Sum(item => Convert.ToDecimal(item.tot_qty ?? 0));
                                MASTER_ENTITY_HU.weight_unit = ITEMS_ENTITY_HU.weight_unit;
                                MASTER_ENTITY_HU.volume_unit = ITEMS_ENTITY_HU.volume_unit;
                                MASTER_ENTITY_HU.unit_code = ITEMS_ENTITY_HU.unit_code;
                                ITEMS_ENTITY_HU.client = AppSessionState.client;
                                MASTER_ENTITY_HU.packing_type = "C";
                            }
                            else if (ITEMS_ENTITY_HU.selected == true)
                            {
                                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Packing of Number of Handling Unit Limit is Completed", this.Title); sms.ShowMessage();
                                ITEMS_ENTITY_HU.selected = false;
                            }
                        }
                        //else
                        //{
                        //    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Insert External Handling Unit Details first!", this.Title); sms.ShowMessage();
                        //}

                    }
                    if ((sender.ToString() == "tare_wt" || sender.ToString() == "net_wt") && MASTER_ENTITY != null)
                    {
                        if (!string.IsNullOrWhiteSpace(MASTER_ENTITY.item_code_pack))
                        {
                            if (MASTER_ENTITY.net_wt.HasValue && MASTER_ENTITY.tare_wt.HasValue)
                            {
                                MASTER_ENTITY.gross_wt = MASTER_ENTITY.net_wt + MASTER_ENTITY.tare_wt;
                            }
                        }
                        if (!string.IsNullOrWhiteSpace(MASTER_ENTITY_HU.item_code_pack))
                        {
                            if (MASTER_ENTITY_HU.net_wt.HasValue && MASTER_ENTITY_HU.tare_wt.HasValue)
                            {
                                MASTER_ENTITY_HU.gross_wt = MASTER_ENTITY_HU.net_wt + MASTER_ENTITY_HU.tare_wt;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            try
            {
                if ((sender.ToString() == "qty" || sender.ToString() == "unit_price"))
                {

                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void DefaultValues(string doc_cat_info)
        {
            MASTER_ENTITY.doc_cat = this.doc_cat_vm;
            MASTER_ENTITY.doc_type = this.doc_cat_vm;
            MASTER_ENTITY.ts_code = this.ts_code_vm;
            MASTER_ENTITY.userid = AppSessionState.UserID;
            MASTER_ENTITY.active = true;
            MASTER_ENTITY.t_status = "001";
            MASTER_ENTITY.carton_pack_dt = DateTime.Now;
            MASTER_ENTITY.client = AppSessionState.client;
            MASTER_ENTITY.comp_code = AppSessionState.comp_code;
            MASTER_ENTITY.location_Id = AppSessionState.location_Id;
            MASTER_ENTITY.user_source1 = AppSessionState.UserSource1;
            MASTER_ENTITY.user_source2 = AppSessionState.UserSource2;
            MASTER_ENTITY.userid = AppSessionState.UserID;

            MASTER_ENTITY.packing_type = "C";
            MASTER_ENTITY_HU.packing_type = "C";
            MASTER_ENTITY_HU.doc_cat = this.doc_cat_vm;
            MASTER_ENTITY_HU.doc_type = this.doc_cat_vm;
            MASTER_ENTITY_HU.ts_code = this.ts_code_vm;
            MASTER_ENTITY_HU.userid = AppSessionState.UserID;
            MASTER_ENTITY_HU.active = true;
            MASTER_ENTITY_HU.t_status = "001";
            MASTER_ENTITY_HU.carton_pack_dt = DateTime.Now;
            MASTER_ENTITY_HU.client = AppSessionState.client;
            MASTER_ENTITY_HU.comp_code = AppSessionState.comp_code;
            MASTER_ENTITY_HU.location_Id = AppSessionState.location_Id;
            MASTER_ENTITY_HU.user_source1 = AppSessionState.UserSource1;
            MASTER_ENTITY_HU.user_source2 = AppSessionState.UserSource2;
            MASTER_ENTITY_HU.userid = AppSessionState.UserID;

            if (MC.DOC_TYPE_SETTINGS_LIST != null)
            {
                if (MC.DOC_TYPE_SETTINGS_LIST.Where(x => x.doc_type == doc_cat_vm).ToList().Count > 0)
                {
                    PackingLimit = MC.DOC_TYPE_SETTINGS_LIST.Where(x => x.doc_type == doc_cat_vm).ToList()[0].no_of_bags;
                    PackingLimitHU = MC.DOC_TYPE_SETTINGS_LIST.Where(x => x.doc_type == doc_cat_vm).ToList()[0].no_of_cartons;
                    ind_residue_packing = MC.DOC_TYPE_SETTINGS_LIST.Where(x => x.doc_type == doc_cat_vm).ToList()[0].ind_residue_packing;
                }
            }

        }
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    //LoadDocumentWithDocumentNumber(doc_no_vm, "DocumentNo");
                }
                else
                {
                    LoadInitialData(doc_cat_vm, null);
                    DefaultValues(doc_cat_vm);
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void LoadInitialData(string doc_cat_info, string ReferenceDoc)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + this.doc_cat_vm + "!@!@" + AppSessionState.EmpId;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "EPR_T003_STD", "SCM", "LoadAll", 0, "");

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains((prefix ?? "").ToLower());
                AS_DEFAULT = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                AS_DEFAULT.AutoSuggestVM.IsEmptyValueAllowed = true; AS_DEFAULT.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_DOC_TYPE)x).doc_cat);
                TheFilter = (o, prefix) => ((STD_DOC_TYPE)o).doc_cat.ToLower().Contains(prefix.ToLower()) || (((STD_DOC_TYPE)o).doc_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_DOC_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.DOC_TYPE_LIST, TheFilter, SuggestedValue, "doc_type", true);
                AS_DOC_TYPE.AutoSuggestVM.IsEmptyValueAllowed = false; AS_DOC_TYPE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code);
                TheFilter = (o, prefix) => (((STD_ITEM)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ITEM_CODE = new AutoSuggestTextViewModel<dynamic>(MC.STD_ITEM_LIST, TheFilter, SuggestedValue, "item_code", true);
                AS_ITEM_CODE.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M054)x).pack_type);
                TheFilter = (o, prefix) => (((SYS_M054)o).pack_type ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((SYS_M054)o).pack_desc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_HU_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.HU_TYPE_LIST, TheFilter, SuggestedValue, "pack_type", true);
                AS_HU_TYPE.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((MM_M0001)x).store_code);
                TheFilter = (o, prefix) => (((MM_M0001)o).store_code ?? "").ToLower().Contains(prefix.ToLower()) || (((MM_M0001)o).store_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_STORE = new AutoSuggestTextViewModel<dynamic>(MC.STORE_LIST, TheFilter, SuggestedValue, "store_code", true);
                AS_STORE.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_status);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_STATUS = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_status", true);
                AS_STATUS.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_M001_P)x).wc_code);
                TheFilter = (o, prefix) => (((PPC_M001_P)o).wc_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((PPC_M001_P)o).machinedesc ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_WC_CODE = new AutoSuggestTextViewModel<dynamic>(MC.STD_WC_LIST, TheFilter, SuggestedValue, "wc_code", true);
                AS_WC_CODE.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code);
                TheFilter = (o, prefix) => (((STD_ITEM)o).item_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_ITEM)o).item_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_PACK_MATERIAL = new AutoSuggestTextViewModel<dynamic>(MC.STD_ITEM_LIST_PKG, TheFilter, SuggestedValue, "item_code", true);
                AS_PACK_MATERIAL.AutoSuggestVM.IsEmptyValueAllowed = true;

                List<UOMS> UOM_WT = MC.UOM_LIST.Where(x => x.unit_code != null).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM_WT = new AutoSuggestTextViewModel<dynamic>(UOM_WT, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM_WT.AutoSuggestVM.IsEmptyValueAllowed = true;

                List<UOMS> UOM_VOL = MC.UOM_LIST.Where(x => x.unit_code != null).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM_VOL = new AutoSuggestTextViewModel<dynamic>(UOM_VOL, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM_VOL.AutoSuggestVM.IsEmptyValueAllowed = true;

                List<UOMS> UOM_PKG_MAT = MC.UOM_LIST.Where(x => x.unit_code != null).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM_PKG_MAT = new AutoSuggestTextViewModel<dynamic>(UOM_PKG_MAT, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM_PKG_MAT.AutoSuggestVM.IsEmptyValueAllowed = true;

                List<UOMS> UOM_DIM = MC.UOM_LIST.Where(x => x.unit_code != null).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code);
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((UOMS)o).unit_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_UOM_DIM = new AutoSuggestTextViewModel<dynamic>(UOM_DIM, TheFilter, SuggestedValue, "unit_code", true);
                AS_UOM_DIM.AutoSuggestVM.IsEmptyValueAllowed = true;

                if (MC.DOC_TYPE_SETTINGS_LIST.Count > 0)
                {
                    MASTER_ENTITY_HU.tot_no_bags = MC.DOC_TYPE_SETTINGS_LIST[0].no_of_bags;
                    MASTER_ENTITY_HU.gross_wt = MC.DOC_TYPE_SETTINGS_LIST[0].gross_wt;
                    //Scan_Source = MC.DOC_TYPE_SETTINGS_LIST[0].scan_source;
                    //Scan_Length = MC.DOC_TYPE_SETTINGS_LIST[0].min_length;
                }


            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void RemoveUpdateReferenceDocuments(string ind_pack)
        {
            if (ind_pack == "S")
            {
                ITEMS_ENTITY_LIST.Remove(ITEMS_ENTITY);
                ITEMS_ENTITY = new EPR_T003_B();
            }
            else if (ind_pack == "M")
            {
                ITEMS_ENTITY_LIST.Where(l => l.selected == true).ToList().All(i => ITEMS_ENTITY_LIST.Remove(i));
            }
            else if (ITEMS_ENTITY.qty > 0 && ITEMS_ENTITY.partial_qty.HasValue)
            {
                ITEMS_ENTITY.qty = (decimal)(ITEMS_ENTITY.qty - ITEMS_ENTITY.partial_qty);
            }


        }
        private void CollectionChangedNotify_HU_ITEMS(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {

                if (e.Action == NotifyCollectionChangedAction.Add)
                {

                    foreach (EPR_T003_A new_item in e.NewItems)
                    {
                        //if (MASTER_ENTITY_HU != null && ITEMS_ENTITY_HU_LIST != null)
                        //{
                        //    if (!string.IsNullOrWhiteSpace(MASTER_ENTITY_HU.item_code_pack) && ITEMS_ENTITY_HU_LIST.Count > 0)
                        //    {
                        //        MASTER_ENTITY_HU.gross_wt = ITEMS_ENTITY_HU_LIST.Where(item => item.active != false && item.selected == true).Sum(item => Convert.ToDecimal(item.gross_wt ?? 0));
                        //        MASTER_ENTITY_HU.net_wt = ITEMS_ENTITY_HU_LIST.Where(item => item.active != false && item.selected == true).Sum(item => Convert.ToDecimal(item.net_wt ?? 0));
                        //        MASTER_ENTITY_HU.tare_wt = ITEMS_ENTITY_HU_LIST.Where(item => item.active != false && item.selected == true).Sum(item => Convert.ToDecimal(item.tare_wt ?? 0));
                        //        MASTER_ENTITY_HU.loading_wt = ITEMS_ENTITY_HU_LIST.Where(item => item.active != false && item.selected == true).Sum(item => Convert.ToDecimal(item.loading_wt ?? 0));
                        //        MASTER_ENTITY_HU.tare_volume = ITEMS_ENTITY_HU_LIST.Where(item => item.active != false && item.selected == true).Sum(item => Convert.ToDecimal(item.tare_volume ?? 0));
                        //        MASTER_ENTITY_HU.volume = ITEMS_ENTITY_HU_LIST.Where(item => item.active != false && item.selected == true).Sum(item => Convert.ToDecimal(item.volume ?? 0));
                        //        MASTER_ENTITY_HU.volume_loading = ITEMS_ENTITY_HU_LIST.Where(item => item.active != false && item.selected == true).Sum(item => Convert.ToDecimal(item.volume_loading ?? 0));
                        //        MASTER_ENTITY_HU.weight_unit = new_item.weight_unit;
                        //        MASTER_ENTITY_HU.volume_unit = new_item.volume_unit;
                        //    }
                        //    new_item.client = AppSessionState.client;
                        //}




                    }

                }

                if (e.Action == NotifyCollectionChangedAction.Replace)
                {

                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    EPR_T003_A temp = (EPR_T003_A)e.OldItems[0];


                }
                if (e.Action == NotifyCollectionChangedAction.Move)
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
        #region . label QR Report .
        private string _ReportOption;
        public string ReportOption
        {
            get { return _ReportOption; }
            set
            {
                if (_ReportOption != value)
                {
                    _ReportOption = value;
                }
            }
        }
        #endregion
        #region . Command Actions .
        protected override void OnSaveAction(InquiryActionResult<EPR_T003_A> result)
        {
            try
            {
                if (Validation(MASTER_ENTITY.ind_packing) == true)
                {
                    MASTER_ENTITY.XmlDataDocument_EPR_T003_B = obj.ObjectToXML(ITEMS_ENTITY);
                    MC_EPR_T003 MCTemp = new MC_EPR_T003();
                    MCTemp.MASTER_ENTITY_LIST[0] = MASTER_ENTITY;
                    if (NewRecord == true)
                    {
                        MCTemp = repository_MC.SaveWithReturnDomainObject<MC_MM_T001>(MCTemp, "MM_EPR_T003_STD", "SCM");
                    }
                    else if (NewRecord == false)
                    {
                        MCTemp = repository_MC.UpdateWithReturnDomainObject<MC_MM_T001>(MCTemp, "MM_EPR_T003_STD", "SCM");
                        //MASTER_ENTITY = repository.UpdateWithReturnDomainObject<MM_T001>(MASTER_ENTITY, "MM_T001_STD", "SCM");
                    }
                    NewRecord = false;
                    MASTER_ENTITY = MCTemp.MASTER_ENTITY_LIST[0];
                    //ITEMS_ENTITY_HU_LIST = MCTemp.ITEMS_ENTITY_LIST;
                    MASTER_ENTITY.ts_code = ts_code_vm;
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Operation"; sms.Text = String.Format("Record created successfully!"); sms.ShowMessage();
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Validation"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        protected override void OnCreateAction(InquiryActionResult<EPR_T003_A> result)
        {
            try
            {
                //MC = new MC_EPR_T003();
                //MCTemp = new MC_EPR_T003();
                MASTER_ENTITY = new EPR_T003_A();
                ITEMS_ENTITY = new EPR_T003_B();
                MASTER_ENTITY_HU = new EPR_T003_A();
                ITEMS_ENTITY_HU = new EPR_T003_A();
                REQ_PARA_OBJ = new STD_REQ_PARA_BE();

                MASTER_ENTITY_LIST = new ObservableCollection<EPR_T003_A>();
                ITEMS_ENTITY_LIST = new ObservableCollection<EPR_T003_B>();
                MASTER_ENTITY_HU_LIST = new ObservableCollection<EPR_T003_A>();
                ITEMS_ENTITY_HU_LIST = new ObservableCollection<EPR_T003_A>();
                MASTER_ENTITY_HU_VIEW = new ObservableCollection<EPR_T003_A>();
                GetCount(null);
                DefaultValues(doc_cat_vm);
            }
            catch (Exception ex)
            { }
        }
        protected override void OnRemoveAction(InquiryActionResult<EPR_T003_A> result)
        {

        }
        protected override void OnDiscardAction(InquiryActionResult<EPR_T003_A> result)
        { }
        protected override void OnFevoriteAction(InquiryActionResult<EPR_T003_A> result)
        { }
        protected override void OnFlipAction(InquiryActionResult<EPR_T003_A> result)
        {
        }
        protected override void OnHelpAction(InquiryActionResult<EPR_T003_A> result)
        { }
        protected override void OnPrintAction(InquiryActionResult<EPR_T003_A> result)
        {
            try
            {
                string ReportName = "LabelGenerationCRI.rdlc";
                if (ReportOption == "PKT STICKER")
                {
                    ReportName = "ALLTYPEPKTSTICKERFORMAT.rdlc";
                }
                else if (ReportOption == "INNER CARTON STICKER")
                {
                    ReportName = "ALLTYPEINNERCARTONSTICKERFORMAT.rdlc";
                }
                else if (ReportOption == "MASTER CARTON STICKER (EXPORT)")
                {
                    ReportName = "MASTERCARTONSTICKERFORMAT(EXPORT).rdlc";
                }
                else if (ReportOption == "MASTER CARTON STICKER (DOMESTIC)")
                {
                    ReportName = "MASTERCARTONSTICKERFORMAT(DOMESTIC).rdlc";
                }
                else if (ReportOption == "Barcode")
                {
                    ReportName = "LabelGenerationCRI.rdlc";
                }
                CursorControl.SetBusyState();
                QRCodeService QRGenerator = new QRCodeService();
                object[] objDataSource = new object[3];
                string[] objDataSourceName = new string[3];
                string row_id = "";
                List<RptLabelGen> rptListObj = new List<RptLabelGen>();
                foreach (EPR_T003_A item in MASTER_ENTITY_HU_VIEW)
                {
                    if (item.selected == true)
                    {
                        RptLabelGen lblObj = new RptLabelGen();
                        lblObj.ball_dia = item.ball_dia;
                        lblObj.ball_type = item.ball_type;
                        lblObj.wire_type = item.wire_type;
                        lblObj.barcode = item.barcode;
                        lblObj.batch_no = item.batch_no;
                        lblObj.batch_no_m = item.batch_no;
                        lblObj.ild = item.Ild;
                        lblObj.ink = item.Ink;
                        lblObj.ItemCode = item.item_code;
                        lblObj.ItemName = item.item_name;
                        lblObj.label_qty = item.tot_qty;
                        lblObj.machinecode = item.wc_code;
                        lblObj.modelno = item.modelno;
                        lblObj.net_wt = item.net_wt;
                        lblObj.qr_batch = QRGenerator.RenderQrCodeForLabel(item.barcode, 15, "");
                        lblObj.tot_qty = item.tot_qty;
                        lblObj.unit_code = item.unit_code;
                        lblObj.doc_type = item.doc_type;
                        lblObj.pack_type = item.pack_type;
                        lblObj.total_len = item.total_len;
                        lblObj.weight_unit = item.weight_unit;
                        lblObj.gross_wt = item.gross_wt;

                        if (row_id == "")
                        {
                            row_id = item.id.ToString();
                        }
                        else
                        {
                            row_id = row_id + "," + item.id.ToString();
                        }


                        rptListObj.Add(lblObj);
                    }
                }
                
                string Request = "Update_Print_Indicator" + "!@" + AppSessionState.client + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + this.doc_cat_vm + "!@" + this.doc_cat_vm + "!@" + row_id + "!@" + AppSessionState.EmpId;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MCTemp, Request, "EPR_T003_STD", "SCM", "LoadAll", 0, "");

                //int count = MCTemp2.LabelGenBackFlipList.Count(x => x.label_complete_stat == true);
                //objDataSource[0] = MCTemp2.RptLabelGenList.Where(x => x.check == true);

                objDataSource[0] = rptListObj;
                objDataSourceName[0] = "dsRptLabelGen";
                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + ReportName, MC.DOC_TYPE_SETTINGS_LIST[0].report_name);




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
        { }
        protected override void OnRefreshCommand(InquiryActionResult<EPR_T003_A> result)
        {
            LoadInitialData(doc_cat_vm,null);
        }
        protected override void OnLedgerViewCommand(InquiryActionResult<EPR_T003_A> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnValidateCommand(InquiryActionResult<EPR_T003_A> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnTraceCommand(InquiryActionResult<EPR_T003_A> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnMailCommand(InquiryActionResult<EPR_T003_A> result)
        {
            throw new NotImplementedException();
        }
        private void OnExportAction()
        { }
        #endregion

        #region Filters

        private string _FilterString_HU_View;
        public string FilterString_HU_View
        {
            get { return _FilterString_HU_View; }
            set
            {
                _FilterString_HU_View = value;
                RaisePropertyChanged("FilterString_HU_View");
                FilterCollection_HU_View();
            }
        }
        private void FilterCollection_HU_View()
        {
            if (LabelCollection != null)
            {
                LabelCollection.Refresh();
            }
        }
        public bool Filter_HU_View(object obj)
        {
            var data = obj as EPR_T003_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_HU_View))
                {
                    return (data.item_code != null && data.item_code.ToString().ToLower().Contains(_FilterString_HU_View.ToLower()) ||
                            data.item_name != null && data.item_name.ToString().ToLower().Contains(_FilterString_HU_View.ToLower()) ||
                            data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_FilterString_HU_View.ToLower()) ||
                            data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_FilterString_HU_View.ToLower())
                       );
                }
                return true;
            }
            return false;
        }

        #endregion
    }
}
