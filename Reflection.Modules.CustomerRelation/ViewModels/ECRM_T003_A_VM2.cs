using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.CustomerRelation.ViewModels
{
    public class ECRM_T003_A_VM2 : WorkspaceViewModel<ECRM_T003_A_New>
    {
        bool isNewRecord = true;
        WebServiceRepository<ECRM_T003_A_New> repository = new WebServiceRepository<ECRM_T003_A_New>();
        WebServiceRepository<MultipleContext_ECRM_T003> repository_MC = new WebServiceRepository<MultipleContext_ECRM_T003>();
        WebServiceRepository<MultipleContext_ECRM_T003> repository_MCTemp = new WebServiceRepository<MultipleContext_ECRM_T003>();
        WebServiceRepository<MultipleContext_ECRM_T003> repository_MCTemp1 = new WebServiceRepository<MultipleContext_ECRM_T003>();
        WebServiceRepository<MultipleContext_ECRM_T003> repository_MCTemp5 = new WebServiceRepository<MultipleContext_ECRM_T003>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest Initalization Regin
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
                    if (SourceName == "parameter")
                    { ASDefault1 = AS_Parameter; }
                    else if (SourceName == "dfctcda")
                    { ASDefault = AS_Defects; }
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

        private AutoSuggestTextViewModel<dynamic> _ASDefault1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault1
        {
            get { return _ASDefault1; }
            set
            {
                if (_ASDefault1 != value)
                {
                    _ASDefault1 = value; RaisePropertyChanged("ASDefault1");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Barcode { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Barcode
        {
            get { return _AS_Barcode; }
            set
            {
                if (_AS_Barcode != value)
                {
                    _AS_Barcode = value; RaisePropertyChanged("AS_Barcode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Machine { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Machine
        {
            get { return _AS_Machine; }
            set
            {
                if (_AS_Machine != value)
                {
                    _AS_Machine = value; RaisePropertyChanged("AS_Machine");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Operator { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Operator
        {
            get { return _AS_Operator; }
            set
            {
                if (_AS_Operator != value)
                {
                    _AS_Operator = value; RaisePropertyChanged("AS_Operator");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Shift { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Shift
        {
            get { return _AS_Shift; }
            set
            {
                if (_AS_Shift != value)
                {
                    _AS_Shift = value; RaisePropertyChanged("AS_Shift");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_TestType { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_TestType
        {
            get { return _AS_TestType; }
            set
            {
                if (_AS_TestType != value)
                {
                    _AS_TestType = value; RaisePropertyChanged("AS_TestType");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Party { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Party
        {
            get { return _AS_Party; }
            set
            {
                if (_AS_Party != value)
                {
                    _AS_Party = value; RaisePropertyChanged("AS_Party");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_Defect { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Defect
        {
            get { return _AS_Defect; }
            set
            {
                if (_AS_Defect != value)
                {
                    _AS_Defect = value; RaisePropertyChanged("AS_Defect");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Parameter { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Parameter
        {
            get { return _AS_Parameter; }
            set
            {
                if (_AS_Parameter != value)
                {
                    _AS_Parameter = value; RaisePropertyChanged("AS_Parameter");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Defects { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Defects
        {
            get { return _AS_Defects; }
            set
            {
                if (_AS_Defects != value)
                {
                    _AS_Defects = value; RaisePropertyChanged("AS_Defects");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Sono { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Sono
        {
            get { return _AS_Sono; }
            set
            {
                if (_AS_Sono != value)
                {
                    _AS_Sono = value; RaisePropertyChanged("AS_Sono");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Sample { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Sample
        {
            get { return _AS_Sample; }
            set
            {
                if (_AS_Sample != value)
                {
                    _AS_Sample = value; RaisePropertyChanged("AS_Sample");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_WTMachine { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_WTMachine
        {
            get { return _AS_WTMachine; }
            set
            {
                if (_AS_WTMachine != value)
                {
                    _AS_WTMachine = value; RaisePropertyChanged("AS_WTMachine");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Item { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Item
        {
            get { return _AS_Item; }
            set
            {
                if (_AS_Item != value)
                {
                    _AS_Item = value; RaisePropertyChanged("AS_Item");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_TipType { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_TipType
        {
            get { return _AS_TipType; }
            set
            {
                if (_AS_TipType != value)
                {
                    _AS_TipType = value; RaisePropertyChanged("AS_TipType");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_BallMake { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_BallMake
        {
            get { return _AS_BallMake; }
            set
            {
                if (_AS_BallMake != value)
                {
                    _AS_BallMake = value; RaisePropertyChanged("AS_BallMake");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_BallSize { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_BallSize
        {
            get { return _AS_BallSize; }
            set
            {
                if (_AS_BallSize != value)
                {
                    _AS_BallSize = value; RaisePropertyChanged("AS_BallSize");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_WireMake { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_WireMake
        {
            get { return _AS_WireMake; }
            set
            {
                if (_AS_WireMake != value)
                {
                    _AS_WireMake = value; RaisePropertyChanged("AS_WireMake");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_WireSize { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_WireSize
        {
            get { return _AS_WireSize; }
            set
            {
                if (_AS_WireSize != value)
                {
                    _AS_WireSize = value; RaisePropertyChanged("AS_WireSize");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Ink { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Ink
        {
            get { return _AS_Ink; }
            set
            {
                if (_AS_Ink != value)
                {
                    _AS_Ink = value; RaisePropertyChanged("AS_Ink");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_DocType { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DocType
        {
            get { return _AS_DocType; }
            set
            {
                if (_AS_DocType != value)
                {
                    _AS_DocType = value; RaisePropertyChanged("AS_DocType");
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

        private AutoSuggestTextViewModel<dynamic> _ASqcperson;
        public AutoSuggestTextViewModel<dynamic> ASqcperson
        {
            get { return _ASqcperson; }
            set
            {
                if (_ASqcperson != value)
                {
                    _ASqcperson = value; RaisePropertyChanged("ASqcperson");
                }
            }
        }
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

        private AutoSuggestTextViewModel<dynamic> _ASShift;
        public AutoSuggestTextViewModel<dynamic> ASShift
        {
            get { return _ASShift; }
            set
            {
                if (_ASShift != value)
                {
                    _ASShift = value; RaisePropertyChanged("ASShift");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASGrade { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGrade
        {
            get { return _ASGrade; }
            set
            {
                if (_ASGrade != value)
                {
                    _ASGrade = value; RaisePropertyChanged("ASGrade");
                }
            }
        }
        #endregion

        #region Variable Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private ECRM_T003_A_New _MasterEntity;
        public ECRM_T003_A_New MasterEntity
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

        private ECRM_T003_A_New _MasterEntityTemp;
        public ECRM_T003_A_New MasterEntityTemp
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

        private int _dgSelectedIndexDefect;
        public int dgSelectedIndexDefect
        {
            get
            {
                return _dgSelectedIndexDefect;
            }
            set
            {
                if (_dgSelectedIndexDefect != value)
                {
                    _dgSelectedIndexDefect = value;
                    RaisePropertyChanged("dgSelectedIndexDefect");
                }
            }
        }

        MultipleContext_ECRM_T003 _MC = new MultipleContext_ECRM_T003();
        public MultipleContext_ECRM_T003 MC
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

        MultipleContext_ECRM_T003 _MCTemp = new MultipleContext_ECRM_T003();
        public MultipleContext_ECRM_T003 MCTemp
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

        MultipleContext_ECRM_T003 _MCTemp1 = new MultipleContext_ECRM_T003();
        public MultipleContext_ECRM_T003 MCTemp1
        {
            get { return _MCTemp1; }
            set
            {
                if (_MCTemp1 != value)
                {
                    _MCTemp1 = value;

                    RaisePropertyChanged("MCTemp1");
                }
            }
        }

        MultipleContext_ECRM_T003 _MCTemp5 = new MultipleContext_ECRM_T003();
        public MultipleContext_ECRM_T003 MCTemp5
        {
            get { return _MCTemp5; }
            set
            {
                if (_MCTemp5 != value)
                {
                    _MCTemp5 = value;

                    RaisePropertyChanged("MCTemp5");
                }
            }
        }

        private ObservableCollection<ECRM_T003_B_New> _ItemsEntity;
        public ObservableCollection<ECRM_T003_B_New> ItemsEntity
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

        private ObservableCollection<ECRM_T003_D_New> _DefectEntity;
        public ObservableCollection<ECRM_T003_D_New> DefectEntity
        {
            get { return _DefectEntity; }
            set
            {
                if (_DefectEntity != value)
                {
                    _DefectEntity = value;
                    RaisePropertyChanged("DefectEntity");
                }
            }
        }

        private ObservableCollection<PPC_T003_Batch> _SODetails;
        public ObservableCollection<PPC_T003_Batch> SODetails
        {
            get { return _SODetails; }
            set
            {
                if (_SODetails != value)
                {
                    _SODetails = value;
                    RaisePropertyChanged("SODetails");
                }
            }
        }

        private List<ECRM_T003_AFlip> _FlipGridData;
        public List<ECRM_T003_AFlip> FlipGridData
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

        private string _barcode;
        public string barcode
        {
            get { return _barcode; }
            set
            {
                if (_barcode != value)
                {
                    _barcode = value;
                    RaisePropertyChanged("barcode");
                }
            }
        }

        private Nullable<bool> _hide;
        public Nullable<bool> hide
        {
            get { return _hide; }
            set
            {
                {
                    _hide = value;
                    RaisePropertyChanged("hide");
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

        #endregion

        #region Collections

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private ICollectionView _ConvLotCollection;// ConvLot Collection
        public ICollectionView ConvLotCollection
        {
            get { return _ConvLotCollection; }
            set
            {
                _ConvLotCollection = value;
                RaisePropertyChanged("ConvLotCollection");
            }
        }

        private ICollectionView _MachineCollection;// Machine Collection
        public ICollectionView MachineCollection
        {
            get { return _MachineCollection; }
            set
            {
                _MachineCollection = value;
                RaisePropertyChanged("MachineCollection");
            }
        }
        private ICollectionView _ShiftCollection;// Shift Collection
        public ICollectionView ShiftCollection
        {
            get { return _ShiftCollection; }
            set
            {
                _ShiftCollection = value;
                RaisePropertyChanged("ShiftCollection");
            }
        }
        private ICollectionView _ILDChartCollection;
        public ICollectionView ILDChartCollection
        {
            get { return _ILDChartCollection; }
            set
            {
                _ILDChartCollection = value;
                RaisePropertyChanged("ILDChartCollection");
            }
        }

        private ICollectionView _DefectCollection;
        public ICollectionView DefectCollection
        {
            get { return _DefectCollection; }
            set
            {
                _DefectCollection = value;
                RaisePropertyChanged("DefectCollection");
            }
        }

        private ICollectionView _RefDocTypeCollection;
        public ICollectionView RefDocTypeCollection
        {
            get { return _RefDocTypeCollection; }
            set
            {
                _RefDocTypeCollection = value;
                RaisePropertyChanged("RefDocTypeCollection");
            }
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


        private ICollectionView _TestTypeCollection;
        public ICollectionView TestTypeCollection
        {
            get { return _TestTypeCollection; }
            set
            {
                _TestTypeCollection = value;
                RaisePropertyChanged("TestTypeCollection");
            }
        }
        private ICollectionView _BatchCollection; // Barcode details
        public ICollectionView BatchCollection
        {
            get { return _BatchCollection; }
            set
            {
                _BatchCollection = value;
                RaisePropertyChanged("BatchCollection");
            }
        }

        private ICollectionView _OperatorCollection;
        public ICollectionView OperatorCollection
        {
            get { return _OperatorCollection; }
            set
            {
                _OperatorCollection = value;
                RaisePropertyChanged("OperatorCollection");
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

        #endregion

        #region StringLists

        List<string> _StringListConvLot;
        public List<string> StringListConvLot
        {
            get { return _StringListConvLot; }
            set
            {
                if (_StringListConvLot != value)
                {
                    _StringListConvLot = value;
                }
            }
        }

        List<string> _StringListMachine;
        public List<string> StringListMachine
        {
            get { return _StringListMachine; }
            set
            {
                if (_StringListMachine != value)
                {
                    _StringListMachine = value;
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

        List<string> _StringListShift;
        public List<string> StringListShift
        {
            get { return _StringListShift; }
            set
            {
                if (_StringListShift != value)
                {
                    _StringListShift = value;
                }
            }
        }

        List<string> _StringListILDChart;
        public List<string> StringListILDChart
        {
            get { return _StringListILDChart; }
            set
            {
                if (_StringListILDChart != value)
                {
                    _StringListILDChart = value;
                }
            }
        }

        List<string> _StringListDefect;
        public List<string> StringListDefect
        {
            get { return _StringListDefect; }
            set
            {
                if (_StringListDefect != value)
                {
                    _StringListDefect = value;
                }
            }
        }

        List<string> _StringListParameter;
        public List<string> StringListParameter
        {
            get { return _StringListParameter; }
            set
            {
                if (_StringListParameter != value)
                {
                    _StringListParameter = value;
                }
            }
        }


        List<string> _StrListRefdoctype;
        public List<string> StrListRefdoctype
        {
            get { return _StrListRefdoctype; }
            set
            {
                if (_StrListRefdoctype != value)
                {
                    _StrListRefdoctype = value;
                }
            }
        }

        List<string> _StringListTestType;
        public List<string> StringListTestType
        {
            get { return _StringListTestType; }
            set
            {
                if (_StringListTestType != value)
                {
                    _StringListTestType = value;
                }
            }
        }

        List<string> _StringListBatch;
        public List<string> StringListBatch
        {
            get { return _StringListBatch; }
            set
            {
                if (_StringListBatch != value)
                {
                    _StringListBatch = value;
                }
            }
        }

        List<string> _StringListOperator;
        public List<string> StringListOperator
        {
            get { return _StringListOperator; }
            set
            {
                if (_StringListOperator != value)
                {
                    _StringListOperator = value;
                }
            }
        }

        List<string> _StringListProdctBack;
        public List<string> StringListProdctBack
        {
            get { return _StringListProdctBack; }
            set
            {
                if (_StringListProdctBack != value)
                {
                    _StringListProdctBack = value;
                }
            }
        }

        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> CmdAddConvLot { get; private set; }
        public RelayCommand<object> CmdAddMachine { get; private set; }
        public RelayCommand<object> CmdCustomer { get; private set; }
        public RelayCommand<object> CmdAddShift { get; private set; }
        public RelayCommand<object> CmdAddILDChart { get; private set; }
        public RelayCommand<object> CmdAddDefect { get; private set; }
        public RelayCommand<object> CmdAddTestType { get; private set; }
        public RelayCommand<object> CmdBarcode { get; private set; }
        public RelayCommand<object> CmdAddOperator { get; private set; }
        public RelayCommand<object> CMDLoadDocumentByDocumentNo { get; private set; }
        public RelayCommand<object> CmdItemAction { get; private set; }
        public RelayCommand<object> CmdDefect { get; private set; }
        public RelayCommand<object> CMDRefdoctype { get; private set; }
        public RelayCommand<object> CmdDefectAction { get; private set; }
        public RelayCommand<object> CmdParameter { get; private set; }
        public RelayCommand<object> CMDAddSono { get; private set; }
        public RelayCommand<object> CMDAddSano { get; private set; }
        public RelayCommand<IList> CellChangedCommand { get; private set; }
        public RelayCommand<object> CmdItemCode { get; private set; }
        public RelayCommand<object> CmdWtmachine { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CmDLoadFromFilter { get; private set; }
        public RelayCommand<object> CMDBallSize { get; private set; }
        public RelayCommand<object> CmdInsert_t_status { get; private set; }
        public RelayCommand<object> CmdInsertGrade { get; private set; }
        #endregion

        #region Constructor
        public ECRM_T003_A_VM2(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new ECRM_T003_A_New();
            MasterEntityTemp = new ECRM_T003_A_New();
            ItemsEntity = new ObservableCollection<ECRM_T003_B_New>();
            DefectEntity = new ObservableCollection<ECRM_T003_D_New>();
            SODetails = new ObservableCollection<PPC_T003_Batch>();
            FlipGridData = new List<ECRM_T003_AFlip>();
            MC = new MultipleContext_ECRM_T003();
            MCTemp = new MultipleContext_ECRM_T003();
            MCTemp5 = new MultipleContext_ECRM_T003();
            MasterEntity.ValidateAsync().Wait();
            ECRM_T003_A_New.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            LoadInitialData();
        }
        public ECRM_T003_A_VM2(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new ECRM_T003_A_New();
            MasterEntityTemp = new ECRM_T003_A_New();
            ItemsEntity = new ObservableCollection<ECRM_T003_B_New>();
            DefectEntity = new ObservableCollection<ECRM_T003_D_New>();
            SODetails = new ObservableCollection<PPC_T003_Batch>();
            FlipGridData = new List<ECRM_T003_AFlip>();
            MC = new MultipleContext_ECRM_T003();
            MCTemp = new MultipleContext_ECRM_T003();
            MCTemp5 = new MultipleContext_ECRM_T003();
            MasterEntity.ValidateAsync().Wait();
            ECRM_T003_A_New.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            LoadInitialData();
        }
        #endregion

        #region User Defined Functions
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
        private void InsertGrade(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M030_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.GradeList.Where(x => x.value_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.parametervalue.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M030_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.grade = POPUPEntityObject.parametervalue;
                    //MasterEntity.t_display = POPUPEntityObject.t_display;
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
        private void RemoveReferenceDocuments()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(MasterEntity.barcode) == false)
                {
                    MC.BatchDetails.Remove(MC.BatchDetails.Single(s => s.barcode == MasterEntity.barcode));
                }
            }
            catch (Exception ex)
            {
            }

        }
        private void InsertBallSize(object InputValue)
        {
            string Request = "";

            ZADM_M001_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.BallSizeData.Where(x => x.ball_dia.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M001_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.ball_size = POPUPEntityObject.ball_dia.ToString();

            }
        }
        private void LoadFromfilter()
        {
            if (MasterEntity.Fromdate != null && MasterEntity.ToDate != null)
            {
                string Request = "LoadFromDateToDate" + "!@" + MasterEntity.Fromdate.ToString() + "!@" + MasterEntity.ToDate.ToString() + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code +"!@" + MasterEntity.qc_person1 +"!@" + MasterEntity.item +"!@"+ MasterEntity.machine + "!@" + MasterEntity.sshift+"!@"+ MasterEntity.con_no;
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ECRM_T003>(MCTemp, Request, "WritingTest2", "CRM", "LoadInitialData", 0, "");

                FlipGridData = MCTemp.DocumentDataFlipGrid.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);
            }
            else
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Date....", this.Title);
                showMessageService.ShowMessage();

            }
        }
        private void InsertWritingTestMachine(object InputValue)
        {
            string Request = "";

            ZADM_M013_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.WTMachineData.Where(x => x.machinecode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M013_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.wt_machine = POPUPEntityObject.machinecode;

            }
        }
        private void InsertItem(object InputValue)
        {
            string Request = "";
            string RequestParameterData = "";
            ADM_M022_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.ItemData.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.ItemCode = POPUPEntityObject.ItemCode;

            }
        }
        private void InsertSalesOrder(object InputValue)
        {
            string Request = "";

            SEL_T001_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.SalesOrderData.Where(x => x.sono.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T001_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.sono = POPUPEntityObject.sono;
            }
        }
        private void InsertSampleAnalysisNo(object InputValue)
        {
            string Request = "";
            string RequestParameterData = "";
            ECRM_T001_A_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.SampleData.Where(x => x.sa_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ECRM_T001_A_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.sa_no = POPUPEntityObject.sa_no;
            }
        }
        private void OtherDefaults()
        {
            MasterEntity.tm = 25;
            //MasterEntity.tmp = "25";
            //MasterEntity.humdt = "55%";
            //MasterEntity.timeto = DateTime.Now.ToString(" HH:mm");
            MasterEntity.amnild = 0;
            MasterEntity.amxild = 0;
            MasterEntity.aavgoo = 0;
            MasterEntity.aavild = 0;
            MasterEntity.tavgoo = 0;
        }
        private void LoadInitialData()
        {
            try
            {
                MasterEntity.Ref_doc_type = "Production Counter Entry";
                MasterEntity.ref_doctp = "PC";
                MasterEntity.doc_type = "WT";
                MasterEntity.doc_cat = "WT";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ECRM_T003>(MC, Request, "WritingTest2", "CRM", "LoadInitialData", 0, "");
                #region Commands
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CmdCustomer = new RelayCommand<object>(items => { if (items == null) { return; } InsertCustomer(items); });
                CmdAddConvLot = new RelayCommand<object>(items => { if (items == null) { return; } InsertConvLot(items); });
                CmdAddMachine = new RelayCommand<object>(items => { if (items == null) { return; } InsertMachine(items); });
                CmdAddShift = new RelayCommand<object>(items => { if (items == null) { return; } InsertShift(items); });
                CmdAddILDChart = new RelayCommand<object>(items => { if (items == null) { return; } InsertILD(items); });
                CmdAddDefect = new RelayCommand<object>(items => { if (items == null) { return; } InsertDefect(items, true, true, true); });
                CmdAddOperator = new RelayCommand<object>(items => { if (items == null) { return; } InsertOperator(items); });
                CmdAddTestType = new RelayCommand<object>(items => { if (items == null) { return; } InsertTestType(items); });
                CmdBarcode = new RelayCommand<object>(items => { if (items == null) { return; } InsertBarcodeDetails(items); });
                CMDLoadDocumentByDocumentNo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CmdItemAction = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
                CmdDefect = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDefectList(cmdPara, true, true, true); });
                CMDRefdoctype = new RelayCommand<object>(items => { if (items == null) { return; } InsertReferenceDocType(items); });
                CmdDefectAction = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Defect(cmdPara); });
                CmdParameter = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertParameters(cmdPara, true, true, true); });
                CellChangedCommand = new RelayCommand<IList>(items => { if (items == null) { return; } CellChangeUpdate(items); });
                CMDAddSono = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalesOrder(items); });
                CMDAddSano = new RelayCommand<object>(items => { if (items == null) { return; } InsertSampleAnalysisNo(items); });
                CmdItemCode = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
                CmdWtmachine = new RelayCommand<object>(items => { if (items == null) { return; } InsertWritingTestMachine(items); });
                CmDLoadFromFilter = new GalaSoft.MvvmLight.Command.RelayCommand(() => { LoadFromfilter(); });
                CMDBallSize = new RelayCommand<object>(items => { if (items == null) { return; } InsertBallSize(items); });
                CmdInsert_t_status = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_t_status(cmdPara); });
                CmdInsertGrade = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertGrade(cmdPara); });
                #endregion
                OtherDefaults();
                #region AutoSuggest Regin
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_T003_Batch)x).barcode);
                TheFilter = (o, prefix) => (((PPC_T003_Batch)o).barcode ?? "").ToLower().Contains(prefix.ToLower());
                AS_Barcode = new AutoSuggestTextViewModel<dynamic>(MC.BatchDetails, TheFilter, SuggestedValue, "barcode", true);
                AS_Barcode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M013_P)x).machinecode);
                TheFilter = (o, prefix) => (((ZADM_M013_P)o).machinecode ?? "").ToLower().Contains(prefix.ToLower());
                AS_Machine = new AutoSuggestTextViewModel<dynamic>(MC.MachineCodeList, TheFilter, SuggestedValue, "machinecode", true);
                AS_Machine.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpLName ?? "").ToLower().Contains(prefix.ToLower());
                AS_Operator = new AutoSuggestTextViewModel<dynamic>(MC.EmpList, TheFilter, SuggestedValue, "EmpId", true);
                AS_Operator.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpLName ?? "").ToLower().Contains(prefix.ToLower());
                ASqcperson = new AutoSuggestTextViewModel<dynamic>(MC.EmpList, TheFilter, SuggestedValue, "EmpId", true);
                ASqcperson.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M042_P)x).shift);
                TheFilter = (o, prefix) => (((ADM_M042_P)o).shift ?? "").ToLower().Contains(prefix.ToLower());
                AS_Shift = new AutoSuggestTextViewModel<dynamic>(MC.Shift, TheFilter, SuggestedValue, "shift", true);
                AS_Shift.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M042_P)x).shift);
                TheFilter = (o, prefix) => (((ADM_M042_P)o).shift ?? "").ToLower().Contains(prefix.ToLower());
                ASShift = new AutoSuggestTextViewModel<dynamic>(MC.Shift, TheFilter, SuggestedValue, "shift", true);
                ASShift.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ECRM_T003_C_P)x).test_code);
                TheFilter = (o, prefix) => (((ECRM_T003_C_P)o).test_code ?? "").ToLower().Contains(prefix.ToLower()) || (((ECRM_T003_C_P)o).test_desc ?? "").ToLower().Contains(prefix.ToLower());
                AS_TestType = new AutoSuggestTextViewModel<dynamic>(MC.TestType, TheFilter, SuggestedValue, "test_code", true);
                AS_TestType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToLower().Contains(prefix.ToLower());
                AS_Party = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyId", true);
                AS_Party.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M016_P)x).dfctcda.ToString());
                TheFilter = (o, prefix) => (((ZADM_M016_P)o).dfctcda.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ZADM_M016_P)o).dfctdsc ?? "").ToLower().Contains(prefix.ToLower());
                AS_Defect = new AutoSuggestTextViewModel<dynamic>(MC.DefectList, TheFilter, SuggestedValue, "defect", "dfctcda", true);
                AS_Defect.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M016_P)x).dfctcda.ToString());
                TheFilter = (o, prefix) => (((ZADM_M016_P)o).dfctcda.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ZADM_M016_P)o).dfctdsc ?? "").ToLower().Contains(prefix.ToLower());
                AS_Defects = new AutoSuggestTextViewModel<dynamic>(MC.DefectList, TheFilter, SuggestedValue, "dfctdsc", "dfctcda", true);
                AS_Defects.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ENG_T003_P)x).spec_para_code);
                TheFilter = (o, prefix) => (((ENG_T003_P)o).spec_para_code ?? "").ToLower().Contains(prefix.ToLower()) || (((ENG_T003_P)o).parameter ?? "").ToLower().Contains(prefix.ToLower());
                AS_Parameter = new AutoSuggestTextViewModel<dynamic>(MC.ParameterMaster, TheFilter, SuggestedValue, "parameters", "spec_para_code", true);
                AS_Parameter.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P)x).sono);
                TheFilter = (o, prefix) => (((SEL_T001_P)o).sono ?? "").ToLower().Contains(prefix.ToLower());
                AS_Sono = new AutoSuggestTextViewModel<dynamic>(MC.SalesOrderData, TheFilter, SuggestedValue, "sono", true);
                AS_Sono.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ECRM_T001_A_P)x).sa_no);
                TheFilter = (o, prefix) => (((ECRM_T001_A_P)o).sa_no ?? "").ToLower().Contains(prefix.ToLower());
                AS_Sample = new AutoSuggestTextViewModel<dynamic>(MC.SampleData, TheFilter, SuggestedValue, "sa_no", true);
                AS_Sample.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M013_P)x).machinecode);
                TheFilter = (o, prefix) => (((ZADM_M013_P)o).machinecode ?? "").ToLower().Contains(prefix.ToLower());
                AS_WTMachine = new AutoSuggestTextViewModel<dynamic>(MC.WTMachineData, TheFilter, SuggestedValue, "machinecode", true);
                AS_WTMachine.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode);
                TheFilter = (o, prefix) => (((ADM_M022_P)o).ItemCode ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M022_P)o).ItemName ?? "").ToLower().Contains(prefix.ToLower());
                AS_Item = new AutoSuggestTextViewModel<dynamic>(MC.ItemData, TheFilter, SuggestedValue, "ItemCode", true);
                AS_Item.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ENG_T003_P)x).parameter);
                TheFilter = (o, prefix) => (((ENG_T003_P)o).parameter ?? "").ToLower().Contains(prefix.ToLower()) || (((ENG_T003_P)o).para_details ?? "").ToLower().Contains(prefix.ToLower());
                ASDefault1 = new AutoSuggestTextViewModel<dynamic>(MC.ParameterMaster, TheFilter, SuggestedValue, "parameters", "parameter", true);
                ASDefault1.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault1.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M007_P)x).tip_type);
                TheFilter = (o, prefix) => (((ZADM_M007_P)o).tip_type ?? "").ToLower().Contains(prefix.ToLower());
                AS_TipType = new AutoSuggestTextViewModel<dynamic>(MC.TipTypeData, TheFilter, SuggestedValue, "tip_type", true);
                AS_TipType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M001_P)x).ball_dia.ToString());
                TheFilter = (o, prefix) => (((ZADM_M001_P)o).ball_dia.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ZADM_M001_P)o).ball_dia_id.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                AS_BallSize = new AutoSuggestTextViewModel<dynamic>(MC.BallSizeData, TheFilter, SuggestedValue, "ball_size", true);
                AS_BallSize.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M003_P)x).wire_size.ToString());
                TheFilter = (o, prefix) => (((ZADM_M003_P)o).wire_size.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ZADM_M003_P)o).wire_size_id.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                AS_WireSize = new AutoSuggestTextViewModel<dynamic>(MC.WireSizeData, TheFilter, SuggestedValue, "wire_size", true);
                AS_WireSize.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M006_P)x).ink.ToString());
                TheFilter = (o, prefix) => (((ZADM_M006_P)o).ink ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ZADM_M006_P)o).ink_id.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                AS_Ink = new AutoSuggestTextViewModel<dynamic>(MC.InkMaster, TheFilter, SuggestedValue, "ink", true);
                AS_Ink.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M013_P)x).doc_type);
                TheFilter = (o, prefix) => (((SYS_M013_P)o).doc_type ?? "").ToLower().Contains(prefix.ToLower()) || (((SYS_M013_P)o).doc_desc ?? "").ToLower().Contains(prefix.ToLower());
                AS_DocType = new AutoSuggestTextViewModel<dynamic>(MC.DocTypeData, TheFilter, SuggestedValue, "doc_type", true);
                AS_DocType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M032_P)x).make.ToString());
                TheFilter = (o, prefix) => (((ADM_M032_P)o).MakeCode.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M032_P)o).make ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_BallMake = new AutoSuggestTextViewModel<dynamic>(MC.BallMakeData, TheFilter, SuggestedValue, "ball_make", true);
                AS_BallMake.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M032_P1)x).make.ToString());
                TheFilter = (o, prefix) => (((ADM_M032_P1)o).MakeCode.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M032_P1)o).make ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_WireMake = new AutoSuggestTextViewModel<dynamic>(MC.WireMakeData, TheFilter, SuggestedValue, "wire_make", true);
                AS_WireMake.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToLower());
                ASUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitMaster, TheFilter, SuggestedValue, "unit_code", true);
                ASUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASt_status = new AutoSuggestTextViewModel<dynamic>(MC.t_statusList, TheFilter, SuggestedValue, "t_display", true);
                ASt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M030_P)x).parametervalue);
                TheFilter = (o, prefix) => (((ADM_M030_P)o).value_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M030_P)o).parametervalue ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASGrade = new AutoSuggestTextViewModel<dynamic>(MC.GradeList, TheFilter, SuggestedValue, "parametervalue", true);
                ASGrade.AutoSuggestVM.IsEmptyValueAllowed = true;

                DefectCollection = CollectionViewSource.GetDefaultView(MC.DefectList);
                DefectCollection.Filter = new Predicate<object>(DefectFilter);
                StringListDefect = MC.DefectList.Select(x => x.dfctdsc.ToString()).ToList();

                ParameterCollection = CollectionViewSource.GetDefaultView(MC.ParameterMaster);
                ParameterCollection.Filter = new Predicate<object>(ParameterFilter);
                StringListParameter = MC.ParameterMaster.Select(x => x.parameter.ToString()).ToList();

                RefDocTypeCollection = CollectionViewSource.GetDefaultView(MC.RefDocType);
                RefDocTypeCollection.Filter = new Predicate<object>(Refdoctype_Filter);
                StrListRefdoctype = MC.RefDocType.Select(x => x.doc_desc_user.ToString()).ToList();

                var barcode = (from o in MC.BatchDetails where o.doc_type == "PC" select o).ToList();
                BatchCollection = CollectionViewSource.GetDefaultView(barcode);
                BatchCollection.Filter = new Predicate<object>(BatchFilter);
                StringListBatch = MC.BatchDetails.Select(x => x.RefDocNo.ToString()).ToList();

                DefaultValues();


                #endregion
            }
            catch (Exception ex)
            { }
        }
        private bool WtCompare()//chk wt(A>B>C)
        {
            try
            {
                int i = 0;
                try
                {
                    if (ItemsEntity[dgSelectedIndexItem].wbtsta <= 3 && ItemsEntity[dgSelectedIndexItem].watstb <= 3 && ItemsEntity[dgSelectedIndexItem].wbtsta >= ItemsEntity[dgSelectedIndexItem].waclgc && ItemsEntity[dgSelectedIndexItem].watstb >= ItemsEntity[dgSelectedIndexItem].waclgc)
                    {
                        i = 0;
                        if (ItemsEntity[dgSelectedIndexItem].waclgc == 0)
                        {
                            ItemsEntity[dgSelectedIndexItem].waclgc = ItemsEntity[dgSelectedIndexItem].watstb;
                        }

                        RowCalculation();
                    }
                    if (ItemsEntity[dgSelectedIndexItem].watstb > ItemsEntity[dgSelectedIndexItem].wbtsta)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Weight";
                        showMessageService.Text =
                            String.Format("B Weight Should be Less than A Weight'{0}'", this.Title);
                        showMessageService.ShowMessage();
                        i = 1;
                    }
                    else if (ItemsEntity[dgSelectedIndexItem].wbtsta > 3)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Weight";
                        showMessageService.Text =
                            String.Format("A Weight Should Be Less than 3'{0}'", this.Title);
                        showMessageService.ShowMessage();
                        i = 1;
                    }
                    else if (ItemsEntity[dgSelectedIndexItem].watstb > 3)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Weight";
                        showMessageService.Text =
                            String.Format("B Weight Should Be Less than 3'{0}'", this.Title);
                        showMessageService.ShowMessage();
                        i = 1;
                    }
                    if (i == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {

                }

                if (i == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return true;
            }

        }
        private void RowCalculation()
        {//calculate gooping, actual gooping, target gooping
            try
            {
                decimal weighta;
                decimal weightc;
                decimal weightb;
                decimal ild;
                decimal gooping;
                decimal mulfact;
                int MType;
                try
                {
                    MType = Convert.ToInt32(MasterEntity.tm);
                }
                catch (Exception ex)
                {
                    MType = 200;
                }
                if (MType == 200)
                {
                    mulfact = Convert.ToDecimal(0.5);
                }
                else
                if (MType == 100)
                {
                    mulfact = 1;
                }
                else if (MType == 50)
                {
                    mulfact = 2;
                }
                else
                {
                    mulfact = 4;
                }
                try
                {
                    weighta = Convert.ToDecimal(ItemsEntity[dgSelectedIndexItem].wbtsta);
                }
                catch (Exception ex)
                {
                    weighta = 0;
                }

                try
                {
                    weightb = Convert.ToDecimal(ItemsEntity[dgSelectedIndexItem].watstb);
                }
                catch (Exception ex)
                {
                    weightb = 0;
                }

                try
                {
                    weightc = Convert.ToDecimal(ItemsEntity[dgSelectedIndexItem].waclgc);
                }
                catch (Exception ex)
                {
                    weightc = 0;

                }

                ild = Convert.ToDecimal((weighta - weightb) * 1000 * mulfact);

                decimal weight = (weighta - weightc);

                if (weight == 0 || weight == Convert.ToDecimal(0.0))
                {
                    gooping = 0;
                }
                else
                {
                    gooping = Convert.ToDecimal((weightb - weightc) / (weight) * 100);
                }

                try
                {
                    ItemsEntity[dgSelectedIndexItem].gooping = Math.Round(gooping, 6);
                    MasterEntity.tavgoo = (ItemsEntity.Sum(t => t.gooping));
                    MasterEntity.aavgoo = (ItemsEntity.Sum(t => t.gooping)) / ItemsEntity.Count; ;

                }
                catch (Exception ex)
                {

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CellChangeUpdate(IList InputValue)//Check For Duplicate Refill No
        {
            if (dgSelectedIndexItem != -1 && ItemsEntity.Count > 0 && ItemsEntity.Count > dgSelectedIndexItem && InputValue.Count > 0)
            {
                IList list = InputValue as IList;
                List<ECRM_T003_B_New> SelectedILDDetailsTemp = list.Cast<ECRM_T003_B_New>().ToList();
                {
                    if (SelectedILDDetailsTemp.Count > 0 && ItemsEntity[dgSelectedIndexItem].refilno != null)
                    {
                        if (ItemsEntity.Count > 0)
                        {
                            IEnumerable<ECRM_T003_B_New> distinctrefilno = (from o in ItemsEntity where o.refilno == SelectedILDDetailsTemp[0].refilno select o).ToList();
                            if (distinctrefilno.Count() <= 1)
                            {
                                WtCompare();
                            }
                            else
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Weight";
                                showMessageService.Text =
                                    String.Format("Refill No Should not be Duplicate'{0}'", this.Title);
                                showMessageService.ShowMessage();
                            }
                        }
                        try
                        {
                            foreach (var item in ItemsEntity)
                            {
                                if (item.wbtsta == (decimal)(0.00) || item.watstb == (decimal)(0.00))
                                {
                                    hide = true;
                                }
                                else
                                {
                                    hide = false;
                                }
                            }
                        }
                        catch
                        {

                        }
                    }
                }
            }
        }
        private void InsertCustomer(object InputValue)
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

            }
        }
        private void InsertBarcodeDetails(object InputValue)
        {
            try
            {
                #region Insert Barcode Details
                string Request = "";
                PPC_T003_Batch POPUPEntityObject = null;
                barcode = InputValue.ToString();
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length >= 10)
                    {
                        var InputValueIfExists = MC.BatchDetails.Where(X => X.barcode == Request).FirstOrDefault();//Checking Weather Barcode is Valid or Not By Checking in Business Entity
                        if (InputValueIfExists != null)
                        {
                            try
                            {
                                POPUPEntityObject = MC.BatchDetails.Where(x => (x.barcode ?? "").Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; //If Barcode is Valid Get All the Information in PopupEntityObject
                                if (POPUPEntityObject != null)
                                {
                                    MasterEntity.barcode = POPUPEntityObject.barcode;
                                    MasterEntity.machinecode = POPUPEntityObject.machinecode;
                                    MasterEntity.shift = POPUPEntityObject.shift1;
                                    MasterEntity.EmpId = POPUPEntityObject.shift_incharge;
                                    MasterEntity.EmpNm = POPUPEntityObject.shift_incharge;
                                    MasterEntity.prdct_code = POPUPEntityObject.ItemCode;
                                    MasterEntity.itemname = POPUPEntityObject.ItemName;
                                    MasterEntity.order_no = POPUPEntityObject.doc_no;
                                    MasterEntity.Conv_lot = POPUPEntityObject.Conv_lot.ToString();
                                    MasterEntity.prddt = POPUPEntityObject.prod_date;
                                    MasterEntity.modlno = POPUPEntityObject.model_code;
                                    MasterEntity.ink = POPUPEntityObject.ink;
                                    MasterEntity.ball_make = POPUPEntityObject.ball_make;
                                    MasterEntity.ball_size = POPUPEntityObject.ball_dia;
                                    MasterEntity.wire_make = POPUPEntityObject.wire_make;
                                    MasterEntity.wire_size = POPUPEntityObject.wire_size;
                                    MasterEntity.counter_qty = POPUPEntityObject.counter_q;
                                    MasterEntity.tmnild = POPUPEntityObject.min_val;
                                    MasterEntity.tmxild = POPUPEntityObject.max_val;
                                    MasterEntity.tiptp = POPUPEntityObject.tip_type;
                                    MasterEntity.unit_code = POPUPEntityObject.unit_code;
                                    MasterEntity.wc_code = POPUPEntityObject.wc_code;
                                    MasterEntity.uhdec = POPUPEntityObject.remark1;
                                    MasterEntity.grade = POPUPEntityObject.grade;
                                    MasterEntity.counter_remark = POPUPEntityObject.counter_remark;
                                    MasterEntity.test_code = POPUPEntityObject.test_code;
                                    SODetails.Clear();
                                    SODetails.Add(new PPC_T003_Batch()
                                    {
                                        sono = POPUPEntityObject.sono,
                                        PartyId = POPUPEntityObject.PartyId,
                                        PartyName = POPUPEntityObject.PartyName,
                                        quantity1 = POPUPEntityObject.quantity1,
                                        ItemCode1 = POPUPEntityObject.ItemCode1,
                                        ItemName1 = POPUPEntityObject.ItemName1,
                                        sodate = POPUPEntityObject.sodate
                                    });
                                }
                            }
                            catch (Exception ex) { }
                        }
                        else
                        {
                            IShowMessageViewService ShowMessage2 = this.GetViewService<IShowMessageViewService>();
                            ShowMessage2.ButtonSetup = DialogButton.OkCancel;
                            ShowMessage2.Caption = "Message";
                            ShowMessage2.Text = String.Format("Entered Barcode is Used.\n Press OK To Re-Sacn Barcode OR Press Cancel To Cancel Re-Scan", this.Title);
                            ShowMessage2.ShowMessage();

                            if (ShowMessage2.ShowMessage() == DialogResult.Ok)
                            {
                                string Request1 = "RescanBarcode" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + Request;
                                MCTemp5 = repository_MCTemp5.GetDataWithReturnDomainObject<MultipleContext_ECRM_T003>(MCTemp5, Request1, "WritingTest2", "CRM", "LoadInitialData", 0, "");

                                if (MCTemp5.RescanBarcode != null)
                                {
                                    if (MCTemp5.RescanBarcode.Count > 0)
                                    {
                                        MasterEntity = MCTemp5.RescanBarcode[0];
                                        SODetails = MCTemp5.SODetails;
                                        Calculation(true);
                                        DefaultValues();
                                        OtherDefaults();
                                        MasterEntity.t_status = "021";
                                    }
                                    else
                                    {
                                        ShowMessage2.ButtonSetup = DialogButton.OkCancel;
                                        ShowMessage2.Caption = "Message";
                                        ShowMessage2.Text = String.Format("Entered Barcode is Invalid", this.Title);
                                        ShowMessage2.ShowMessage();
                                    }
                                }
                                else
                                {
                                    ShowMessage2.ButtonSetup = DialogButton.OkCancel;
                                    ShowMessage2.Caption = "Message";
                                    ShowMessage2.Text = String.Format("Entered Barcode is Invalid", this.Title);
                                    ShowMessage2.ShowMessage();
                                }
                            }
                        }
                    }
                }

                else if (InputValue != null && ((IEnumerable)InputValue).Cast<PPC_T003_Batch>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PPC_T003_Batch>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.barcode = POPUPEntityObject.barcode;
                    MasterEntity.machinecode = POPUPEntityObject.machinecode;
                    MasterEntity.shift = POPUPEntityObject.shift1;
                    MasterEntity.EmpId = POPUPEntityObject.shift_incharge;
                    MasterEntity.EmpNm = POPUPEntityObject.shift_incharge;
                    MasterEntity.prdct_code = POPUPEntityObject.ItemCode;
                    MasterEntity.itemname = POPUPEntityObject.ItemName;
                    MasterEntity.order_no = POPUPEntityObject.doc_no;
                    MasterEntity.Conv_lot = POPUPEntityObject.Conv_lot.ToString();
                    MasterEntity.prddt = POPUPEntityObject.prod_date;
                    MasterEntity.modlno = POPUPEntityObject.model_code;
                    MasterEntity.ink = POPUPEntityObject.ink;
                    MasterEntity.ball_make = POPUPEntityObject.ball_make;
                    MasterEntity.ball_size = POPUPEntityObject.ball_dia;
                    MasterEntity.wire_make = POPUPEntityObject.wire_make;
                    MasterEntity.wire_size = POPUPEntityObject.wire_size;
                    MasterEntity.counter_qty = POPUPEntityObject.counter_q;
                    MasterEntity.tmnild = POPUPEntityObject.min_val;
                    MasterEntity.tmxild = POPUPEntityObject.max_val;
                    MasterEntity.tiptp = POPUPEntityObject.tip_type;
                    MasterEntity.unit_code = POPUPEntityObject.unit_code;
                    MasterEntity.wc_code = POPUPEntityObject.wc_code;
                    MasterEntity.uhdec = POPUPEntityObject.remark1;
                    MasterEntity.grade = POPUPEntityObject.grade;
                    MasterEntity.counter_remark = POPUPEntityObject.counter_remark;
                    MasterEntity.test_code = POPUPEntityObject.test_code;
                    SODetails.Clear();
                    SODetails.Add(new PPC_T003_Batch()
                    {
                        sono = POPUPEntityObject.sono,
                        PartyId = POPUPEntityObject.PartyId,
                        PartyName = POPUPEntityObject.PartyName,
                        quantity1 = POPUPEntityObject.quantity1,
                        ItemCode1 = POPUPEntityObject.ItemCode1,
                        ItemName1 = POPUPEntityObject.ItemName1,
                        sodate = POPUPEntityObject.sodate
                    });
                }
            }
            #endregion

            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format(ex.Message, this.Title);
                showMessageService.ShowMessage();
            }
            var msg = new NotificationMessage("ECRM_T003_A_VM2");
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        private void InsertConvLot(object InputValue)
        {
            string Request = "";
            string RequestParameterData = "";
            EPR_T001_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            //POPUPEntityObject = MC.MasterEntity.Where(x => x.Conv_lot.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<EPR_T001_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.Conv_lot = POPUPEntityObject.Conv_lot.ToString();

            }
        }
        private void InsertMachine(object InputValue)
        {
            string Request = "";
            string RequestParameterData = "";
            ZADM_M013_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.MachineCodeList.Where(x => x.machinecode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M013_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.machinecode = POPUPEntityObject.machinecode;
                MasterEntity.mchn_id = POPUPEntityObject.machine_id;

            }
        }
        private void InsertShift(object InputValue)
        {
            string Request = "";
            ADM_M042_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.Shift.Where(x => x.shift.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M042_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.shift = POPUPEntityObject.shift;

            }
        }
        private void InsertILD(object InputValue)
        {
            string Request = "";
            string RequestParameterData = "";
            ZADM_M007_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.ILD.Where(x => x.ild.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M007_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {


            }
        }
        private void InsertReferenceDocType(object InputValue)
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
                        {
                            POPUPEntityObject = MC.RefDocType.Where(x => x.doc_desc_user.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
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
                MasterEntity.Ref_doc_type = POPUPEntityObject.doc_desc_user;
                MasterEntity.ref_doctp = POPUPEntityObject.doc_type_user;

                if (MasterEntity.ref_doctp == "CN")
                {

                    var ConvNote = (from o in MC.BatchDetails where o.doc_type == "CN" select o).ToList();
                    BatchCollection = CollectionViewSource.GetDefaultView(ConvNote);
                    BatchCollection.Filter = new Predicate<object>(BatchFilter);
                    StringListBatch = ConvNote.Select(x => x.RefDocNo).ToList();
                }
                else
                {
                    var barcode = (from o in MC.BatchDetails where o.doc_type == "PC" select o).ToList();
                    BatchCollection = CollectionViewSource.GetDefaultView(barcode);
                    BatchCollection.Filter = new Predicate<object>(BatchFilter);
                    StringListBatch = barcode.Select(x => x.RefDocNo).ToList();
                }
            }
        }
        private void DefaultRefDocType()
        {
            MasterEntity.Ref_doc_type = "Production Counter Entry";
            MasterEntity.ref_doctp = "PC";
            var ConvNote = (from o in MC.BatchDetails where o.doc_type == "PC" select o).ToList();
            BatchCollection = CollectionViewSource.GetDefaultView(ConvNote);
            BatchCollection.Filter = new Predicate<object>(BatchFilter);
            StringListBatch = ConvNote.Select(x => x.RefDocNo).ToList();
        }
        private void DeleteDataGridRow_Defect(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (DefectEntity.Count > i && DefectEntity[dgSelectedIndexDefect].id == 0)
                {
                    DefectEntity.RemoveAt(i);
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
        private void InsertDefect(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M016_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MC.DefectList.Where(x => x.dfctcda.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M016_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M016_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = ItemsEntity.Where(x => x.defects == POPUPEntityObject.dfctcda.ToString()).FirstOrDefault();
                    var IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.defects == POPUPEntityObject.dfctcda.ToString()).FirstOrDefault());
                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].defects = POPUPEntityObject.dfctcda.ToString();
                            ItemsEntity[dgSelectedIndexItem].DefectNm = POPUPEntityObject.dfctdsc;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].defects != POPUPEntityObject.dfctcda.ToString())
                        {
                            ItemsEntity[dgSelectedIndexItem].defects = POPUPEntityObject.dfctcda.ToString();
                            ItemsEntity[dgSelectedIndexItem].DefectNm = POPUPEntityObject.dfctdsc;
                        }
                    }
                }
                #region Clear Empty Row
                ECRM_T003_B_New newObj = new ECRM_T003_B_New();
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
        private void InsertDefectList(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ZADM_M016_P POPUPEntityObject = null;
            try
            {
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DefectList.Where(x => x.dfctcda.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M016_P>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = DefectEntity.Where(x => x.defect == POPUPEntityObject.dfctcda.ToString()).FirstOrDefault();
                    int IndexOfExistValue = DefectEntity.IndexOf(DefectEntity.Where(X => X.defect == POPUPEntityObject.dfctcda.ToString()).FirstOrDefault());
                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && DefectEntity.Count == dgSelectedIndexDefect)
                    {
                        DefectEntity.Add(new ECRM_T003_D_New()
                        {
                            id = 0,
                            defect = POPUPEntityObject.dfctcda.ToString(),
                            DefectNm = POPUPEntityObject.dfctdsc,
                            active = true,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            add_by = AppSessionState.UserID,
                            posting_period = "1",
                            fin_year = "15-16",
                            t_status = "001"
                        });
                    }
                    else if (dgSelectedIndexDefect >= 0 && DefectEntity.Count > dgSelectedIndexDefect)
                    {
                        if (DefectEntity[dgSelectedIndexDefect].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                        {
                            DefectEntity[dgSelectedIndexDefect].defect = POPUPEntityObject.dfctcda.ToString();
                            DefectEntity[dgSelectedIndexDefect].DefectNm = POPUPEntityObject.dfctdsc;
                            DefectEntity[dgSelectedIndexDefect].location_Id = AppSessionState.location_Id;
                            DefectEntity[dgSelectedIndexDefect].comp_code = AppSessionState.comp_code;
                            DefectEntity[dgSelectedIndexDefect].add_by = AppSessionState.UserID;
                            DefectEntity[dgSelectedIndexDefect].fin_year = "15-16";
                            DefectEntity[dgSelectedIndexDefect].posting_period = "1";
                            DefectEntity[dgSelectedIndexDefect].active = true;
                            DefectEntity[dgSelectedIndexDefect].t_status = "001";
                        }
                        else if (DefectEntity[dgSelectedIndexDefect].defect != POPUPEntityObject.dfctcda.ToString())
                        {
                            DefectEntity[dgSelectedIndexDefect].defect = "";
                            DefectEntity[dgSelectedIndexDefect].DefectNm = "";
                        }
                    }
                }
                ECRM_T003_D_New newObj = new ECRM_T003_D_New();
                for (int i = DefectEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = DefectEntity[i].ComparePropertiesTo(newObj);
                    if (DefectEntity[i].ComparePropertiesTo(newObj) == true && DefectEntity.Count > 1)
                    {
                        DefectEntity.RemoveAt(i);
                        if (DefectEntity.Count == 0)
                        {
                            DefectEntity.Add(newObj);
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
        private void InsertOperator(object InputValue)
        {
            string Request = "";
            string RequestParameterData = "";
            ADM_M024_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.EmpList.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.EmpId = POPUPEntityObject.EmpId;
                MasterEntity.EmpNm = POPUPEntityObject.EmpLName;

            }
        }
        private void InsertTestType(object InputValue)
        {
            string Request = "";
            string RequestParameterData = "";
            ECRM_T003_C_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.TestType.Where(x => x.test_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ECRM_T003_C_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.test_code = POPUPEntityObject.test_code;

            }
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            string ParametersStringValue = "";
            ECRM_T003_AFlip POPUPEntityObject = null;
            string RequestParameterData = "";

            if (ParameterObject.GetType() == typeof(string) && ParameterObject != null)
            {
                ParametersStringValue = ParameterObject.ToString().Trim();
                if (ParametersStringValue.Length > 0)
                {
                    RequestParameterData = "LoadDocumentByDocumentNumber" + "!@" + ParameterObject;
                }
            }

            else if (ParameterObject != null)
            {
                if (((IEnumerable)ParameterObject).Cast<ECRM_T003_AFlip>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)ParameterObject).Cast<ECRM_T003_AFlip>().ToList()[0];
                    RequestParameterData = "LoadDocumentByDocumentNumber" + "!@" + POPUPEntityObject.wtno;
                }
            }
            MCTemp1 = repository_MCTemp1.GetDataWithReturnDomainObject<MultipleContext_ECRM_T003>(MCTemp1, RequestParameterData, "WritingTest2", "CRM", "LoadInitialData", 0, "");

            if (MCTemp1.MasterEntity.Count > 0 || MCTemp1.ItemEntity.Count > 0)
            {
                MasterEntity = MCTemp1.MasterEntity[0];
                ItemsEntity = MCTemp1.ItemEntity;
                DefectEntity = MCTemp1.DefectEntity;
                SODetails = MCTemp1.SODetails;
                AttachmentCollection = MCTemp.AttachmentData;
                if (MCTemp.AttachmentData != null)
                {
                    AttachmentCollection = MCTemp.AttachmentData;
                }
                else
                {
                    MCTemp.AttachmentData = new List<COM_T003>();
                }
                SelectedTabControlIndex = 0;
                isNewRecord = false;
                MasterEntity.ts_code = ts_code_vm;
                DefaultRefDocType();
                var msg = new NotificationMessage("ECRM_T003_A_VM2");
                Messenger.Default.Send<NotificationMessage>(msg);
            }

        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MasterEntity.XmlDataDocument_ECRM_T003_B != null && ParameterOption1 == "Save")
            {
                ItemsEntity.Clear();
                MC.ItemEntity = (ObservableCollection<ECRM_T003_B_New>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ECRM_T003_B, MC.ItemEntity);

                ItemsEntity = MC.ItemEntity;
            }

            if (MasterEntity.XmlDataDocument_ECRM_T003_D != null && ParameterOption1 == "Save")
            {
                DefectEntity.Clear();
                MC.DefectEntity = (ObservableCollection<ECRM_T003_D_New>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ECRM_T003_D, MC.DefectEntity);
                DefectEntity = MC.DefectEntity;
            }
            if (MasterEntity.XmlDataDocument_FlipGrid != null && isNewRecord == true && ParameterOption1 == "Save")
            {
                MC.DocumentDataFlipGrid = (List<ECRM_T003_AFlip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                DataGridCollection.Refresh();
            }
            MasterEntity.ts_code = ts_code_vm;
        }
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.active = true;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.wtdt = DateTime.Now;
            MasterEntity.prddt = DateTime.Now;
            MasterEntity.doc_cat = "WT";
            MasterEntity.doc_type = "WT";
            MasterEntity.t_status = "001";
            MasterEntity.ToDate = DateTime.Now;
            MasterEntity.Fromdate = DateTime.Now;


        }
        private bool Validation()
        {
            try
            {
                int i = 0;
                try
                {
                    if (MasterEntity.shift == "" || MasterEntity.shift == null)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text =
                            String.Format("Shift Required", this.Title);
                        showMessageService.ShowMessage();
                        i = 1;
                    }


                    for (int P = 0; P < ItemsEntity.Count; P++)
                    {

                        if (ItemsEntity[P].refilno == "" || ItemsEntity[P].refilno == null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Refil No";
                            showMessageService.Text =
                                String.Format("Refil No Required", this.Title);
                            showMessageService.ShowMessage();
                            i = 1;
                            break;
                        }
                        else if (ItemsEntity[P].watstb > ItemsEntity[P].wbtsta)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Weight";
                            showMessageService.Text =
                                String.Format("B Weight Should be Less than A Weight'{0}'", this.Title);
                            showMessageService.ShowMessage();
                            i = 1;
                            break;
                        }
                        else if (ItemsEntity[P].wbtsta > 3)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Weight";
                            showMessageService.Text =
                                String.Format("A Weight Should Be Less than 3'{0}'", this.Title);
                            showMessageService.ShowMessage();
                            i = 1;
                            break;
                        }
                        else if (ItemsEntity[P].watstb > 3)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Weight";
                            showMessageService.Text =
                                String.Format("B Weight Should Be Less than 3'{0}'", this.Title);
                            showMessageService.ShowMessage();
                            i = 1;
                            break;
                        }

                    }
                    if (i == 0)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                }
                catch (Exception ex)
                {

                }

                if (i == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
            }

            return true;
        }
        private void InsertParameters(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ENG_T003_P POPUPEntityObject = null;
            try
            {
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ParameterMaster.Where(x => x.spec_para_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T003_P>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = DefectEntity.Where(x => x.parameters == POPUPEntityObject.spec_para_code).FirstOrDefault();
                    int IndexOfExistValue = DefectEntity.IndexOf(DefectEntity.Where(X => X.parameters == POPUPEntityObject.spec_para_code).FirstOrDefault());
                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && DefectEntity.Count == dgSelectedIndexDefect)
                    {
                        DefectEntity.Add(new ECRM_T003_D_New()
                        {
                            id = 0,
                            parameters = POPUPEntityObject.spec_para_code,
                            parameterNm = POPUPEntityObject.parameter,
                            active = true,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            add_by = AppSessionState.UserID,
                            posting_period = "1",
                            fin_year = "15-16",
                            t_status = "001"
                        });
                    }
                    else if (dgSelectedIndexDefect >= 0 && DefectEntity.Count > dgSelectedIndexDefect)
                    {
                        if (DefectEntity[dgSelectedIndexDefect].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                        {
                            DefectEntity[dgSelectedIndexDefect].parameters = POPUPEntityObject.spec_para_code;
                            DefectEntity[dgSelectedIndexDefect].parameterNm = POPUPEntityObject.parameter;
                            DefectEntity[dgSelectedIndexDefect].location_Id = AppSessionState.location_Id;
                            DefectEntity[dgSelectedIndexDefect].comp_code = AppSessionState.comp_code;
                            DefectEntity[dgSelectedIndexDefect].add_by = AppSessionState.UserID;
                            DefectEntity[dgSelectedIndexDefect].fin_year = "15-16";
                            DefectEntity[dgSelectedIndexDefect].posting_period = "1";
                            DefectEntity[dgSelectedIndexDefect].active = true;
                            DefectEntity[dgSelectedIndexDefect].t_status = "001";
                        }
                        else if (DefectEntity[dgSelectedIndexDefect].parameters != POPUPEntityObject.parameter)
                        {
                            DefectEntity[dgSelectedIndexDefect].parameters = "";
                            DefectEntity[dgSelectedIndexDefect].parameterNm = "";

                        }


                    }

                }

                ECRM_T003_D_New newObj = new ECRM_T003_D_New();
                for (int i = DefectEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = DefectEntity[i].ComparePropertiesTo(newObj);
                    if (DefectEntity[i].ComparePropertiesTo(newObj) == true && DefectEntity.Count > 1)
                    {
                        DefectEntity.RemoveAt(i);
                        if (DefectEntity.Count == 0)
                        {
                            DefectEntity.Add(newObj);
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
        void ModelUpdated_Master(object sender, EventArgs e)
        {

            if (sender.ToString() == "tmnild" || sender.ToString() == "tmxild" || sender.ToString() == "check_qty")
            {

                Calculation(true);

            }
        }
        private void Calculation(bool compute)
        {
            try
            {
                if (compute == true)
                {
                    MasterEntity.tavild = (MasterEntity.tmnild + MasterEntity.tmxild) / 2;
                    MasterEntity.Ranget = MasterEntity.tmxild - MasterEntity.tmnild;
                    MasterEntity.batch_qty = Convert.ToDecimal(MasterEntity.counter_qty) - Convert.ToDecimal(MasterEntity.check_qty);
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
        #endregion

        #region Filters

        #region Filters For BF
        private string _filterString;
        private void FilterCollection()
        {
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
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
        public bool Filter(object obj)
        {
            var data = obj as ECRM_T003_AFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString))
                {
                    return ((data.wtno != null) && data.wtno.ToLower().Contains(_filterString.ToLower()) ||
                           (data.machinecode != null) && data.machinecode.ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For ConvLot
        private string _filterStringConvLot;
        private void FilterCollectionConvLot()
        {
            if (_ConvLotCollection != null)
            {
                _ConvLotCollection.Refresh();
            }
        }
        public string FilterStringConvLot
        {
            get { return _filterStringConvLot; }
            set
            {
                _filterStringConvLot = value;
                RaisePropertyChanged("FilterStringConvLot");
                FilterCollectionConvLot();
            }
        }
        public bool ConvLotFilter(object obj)
        {
            var data = obj as EPR_T001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringConvLot))
                {
                    return (data.Conv_lot != null && data.Conv_lot.ToString().ToLower().Contains(_filterStringConvLot.ToLower())) ||
                   (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterStringConvLot.ToLower())) ||
                   (data.start_dt != null && data.start_dt.ToString().ToLower().Contains(_filterStringConvLot.ToLower())) ||
                   (data.Status != null && data.Status.ToString().ToLower().Contains(_filterStringConvLot.ToLower())) ||
                   (data.id != null && data.id.ToString().ToLower().Contains(_filterStringConvLot.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Machine
        private string _filterStringMachine;
        private void FilterCollectionMachine()
        {
            if (_MachineCollection != null)
            {
                _MachineCollection.Refresh();
            }
        }
        public string FilterStringMachine
        {
            get { return _filterStringMachine; }
            set
            {
                _filterStringMachine = value;
                RaisePropertyChanged("FilterStringMachine");
                FilterCollectionMachine();
            }
        }
        public bool MachineFilter(object obj)
        {
            var data = obj as ZADM_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringMachine))
                {
                    return ((data.machinecode != null) && data.machinecode.ToLower().Contains(_filterStringMachine.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Shift
        private string _filterStringShift;
        private void FilterCollectionShift()
        {
            if (_ShiftCollection != null)
            {
                _ShiftCollection.Refresh();
            }
        }
        public string FilterStringShift
        {
            get { return _filterStringShift; }
            set
            {
                _filterStringShift = value;
                RaisePropertyChanged("FilterStringShift");
                FilterCollectionShift();
            }
        }
        public bool ShiftFilter(object obj)
        {
            var data = obj as ADM_M042_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringShift))
                {
                    return ((data.shift != null) && data.shift.ToLower().Contains(_filterStringShift.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For ILD
        private string _filterStringILD;
        private void FilterCollectionILD()
        {
            if (_ILDChartCollection != null)
            {
                _ILDChartCollection.Refresh();
            }
        }
        public string FilterStringILD
        {
            get { return _filterStringILD; }
            set
            {
                _filterStringILD = value;
                RaisePropertyChanged("FilterStringILD");
                FilterCollectionILD();
            }
        }
        public bool ILDFilter(object obj)
        {
            var data = obj as ZADM_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringILD))
                {
                    return ((data.ild != null) && data.ild.ToLower().Contains(_filterStringILD.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Defect
        private string _filterStringDefect;
        private void FilterCollectionDefect()
        {
            if (_DefectCollection != null)
            {
                _DefectCollection.Refresh();
            }
        }
        public string FilterStringDefect
        {
            get { return _filterStringDefect; }
            set
            {
                _filterStringDefect = value;
                RaisePropertyChanged("FilterStringDefect");
                FilterCollectionDefect();
            }
        }
        public bool DefectFilter(object obj)
        {
            var data = obj as ZADM_M016_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringDefect))
                {
                    return ((data.dfctdsc != null) && data.dfctdsc.ToLower().Contains(_filterStringDefect.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Operator
        private string _filterStringOperator;
        private void FilterCollectionOperator()
        {
            if (_OperatorCollection != null)
            {
                _OperatorCollection.Refresh();
            }
        }
        public string FilterStringOperator
        {
            get { return _filterStringOperator; }
            set
            {
                _filterStringOperator = value;
                RaisePropertyChanged("FilterStringOperator");
                FilterCollectionOperator();
            }
        }
        public bool OperatorFilter(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringOperator))
                {
                    return ((data.EmpId != null) && data.EmpId.ToLower().Contains(_filterStringOperator.ToLower()) ||
                        (data.EmpLName != null) && data.EmpLName.ToLower().Contains(_filterStringOperator.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For TestType

        private string _filterStringTestType;
        private void FilterCollectionTestType()
        {
            if (_TestTypeCollection != null)
            {
                _TestTypeCollection.Refresh();
            }
        }
        public string FilterStringTestType
        {
            get { return _filterStringTestType; }
            set
            {
                _filterStringTestType = value;
                RaisePropertyChanged("FilterStringTestType");
                FilterCollectionTestType();
            }
        }
        public bool TestTypeFilter(object obj)
        {
            var data = obj as ECRM_T003_C_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringTestType))
                {
                    return ((data.test_code != null) && data.test_code.ToLower().Contains(_filterStringTestType.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter for Batch
        private string _FilterStringBatch;
        public string FilterStringBatch
        {
            get { return _FilterStringBatch; }
            set
            {
                _FilterStringBatch = value;
                RaisePropertyChanged("FilterStringBatch");
                FilterCollectionBatch();
            }
        }
        private void FilterCollectionBatch()
        {
            if (_BatchCollection != null)
            {
                _BatchCollection.Refresh();
            }
        }
        public bool BatchFilter(object obj)
        {
            var data = obj as PPC_T003_Batch;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringBatch))
                {
                    return (data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.shift1 != null && data.shift1.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.shift2 != null && data.shift2.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.shift3 != null && data.shift3.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.shift_incharge != null && data.shift_incharge.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.counter_q != null && data.counter_q.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.machine_id != null && data.machine_id.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.prod_date != null && data.prod_date.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.RefDocNo != null && data.RefDocNo.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.barcode != null && data.barcode.ToString().ToLower().Contains(_FilterStringBatch.ToLower())) ||
                           (data.quantity != null && data.quantity.ToString().ToLower().Contains(_FilterStringBatch.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter For Parameter
        private string _FilterStringParameter;
        public string FilterStringParameter
        {
            get { return _FilterStringParameter; }
            set
            {
                _FilterStringParameter = value;
                RaisePropertyChanged("FilterStringParameter");
                FilterParameterCollection();
            }
        }
        private void FilterParameterCollection()
        {
            if (_ParameterCollection != null)
            {
                _ParameterCollection.Refresh();
            }
        }
        public bool ParameterFilter(object obj)
        {
            var data = obj as ENG_T003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringParameter))
                {
                    return (data.parameter != null && data.parameter.ToString().ToLower().Contains(_FilterStringParameter.ToLower())) ||
                           (data.para_details != null && data.para_details.ToString().ToLower().Contains(_FilterStringParameter.ToLower())) ||
                           (data.spec_para_code != null && data.spec_para_code.ToString().ToLower().Contains(_FilterStringParameter.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filter For Ref Doc Type
        private string _FilterStringRefDocType;
        public string FilterStringRefDocType
        {
            get { return _FilterStringRefDocType; }
            set
            {
                _FilterStringRefDocType = value;
                RaisePropertyChanged("FilterStringRefDocType");
                FilterCollectionRefDocType();
            }
        }
        private void FilterCollectionRefDocType()
        {
            if (_RefDocTypeCollection != null)
            {
                _RefDocTypeCollection.Refresh();
            }
        }
        public bool Refdoctype_Filter(object obj)
        {
            var data = obj as SYS_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringRefDocType))
                {
                    return (data.doc_desc_user != null && data.doc_desc_user.ToString().ToLower().Contains(_FilterStringRefDocType.ToLower())) ||
                           (data.doc_type_user != null && data.doc_type_user.ToString().ToLower().Contains(_FilterStringRefDocType.ToLower()));

                }
                return true;
            }
            return false;
        }
        #endregion
        #endregion

        #region Abstract Command Actions
        protected override void OnCreateAction(InquiryActionResult<ECRM_T003_A_New> result)
        {
            isNewRecord = true;
            MasterEntity = new ECRM_T003_A_New();
            ItemsEntity = new ObservableCollection<ECRM_T003_B_New>();
            DefectEntity = new ObservableCollection<ECRM_T003_D_New>();
            MasterEntity.ValidateAsync().Wait();
            SODetails.Clear();
            ItemsEntity.Clear();
            DefaultRefDocType();
            OtherDefaults();
            DefaultValues();

            var msg = new NotificationMessage("ECRM_T003_A_VM2");
            Messenger.Default.Send<NotificationMessage>(msg);

        }

        protected override void OnDiscardAction(InquiryActionResult<ECRM_T003_A_New> result)
        {

        }

        protected override void OnFevoriteAction(InquiryActionResult<ECRM_T003_A_New> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<ECRM_T003_A_New> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<ECRM_T003_A_New> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<ECRM_T003_A_New> result)
        {

        }

        protected override void OnRemoveAction(InquiryActionResult<ECRM_T003_A_New> result)
        {

        }

        protected override void OnSaveAction(InquiryActionResult<ECRM_T003_A_New> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.editby = AppSessionState.UserID;
                    MasterEntity.XmlDataDocument_ECRM_T003_B = obj.ObjectToXML(ItemsEntity);
                    MasterEntity.XmlDataDocument_ECRM_T003_D = obj.ObjectToXML(DefectEntity);

                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ECRM_T003_A_New>(MasterEntity, "WritingTestForProduction2", "Production");
                        RemoveReferenceDocuments();
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ECRM_T003_A_New>(MasterEntity, "WritingTestForProduction2", "Production");
                    }

                    if (MasterEntity.amnild < MasterEntity.tmnild)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Actual Min ILD is Less Than Target Min ILD", this.Title);
                        showMessageService.ShowMessage();
                    }

                    if (MasterEntity.amxild > MasterEntity.tmxild)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Actual Max ILD is Greater Than Target Max ILD", this.Title);
                        showMessageService.ShowMessage();
                    }


                    SetBusinessEntitiesAfterLoad("Save", "");
                    var msg = new NotificationMessage("ECRM_T003_A_VM2");
                    Messenger.Default.Send<NotificationMessage>(msg);
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
            DefaultRefDocType();
        }

        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ECRM_T003_A_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ECRM_T003_A_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ECRM_T003_A_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ECRM_T003_A_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ECRM_T003_A_New> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Event Handler
        void My_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = false;
            }
            else if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = false;
            }
        }

        private void CollectionChangedNotifyForItemsEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (ECRM_T003_B_New item in e.NewItems)
                        item.PropertyChanged += this.My_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (ECRM_T003_B_New item in e.OldItems)
                        item.PropertyChanged -= this.My_PropertyChanged;


                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ECRM_T003_B_New item in e.NewItems)
                    {
                        item.id = 0;
                        item.active = true;
                        item.add_by = AppSessionState.UserID;
                        item.comp_code = AppSessionState.comp_code;
                        item.location_Id = AppSessionState.location_Id;
                        item.editby = AppSessionState.UserID;
                        item.fin_year = "16-17";
                        item.posting_period = "9";
                        item.t_status = "001";
                    }
                }


            }
            catch (Exception ex)
            { }
        }

        
        #endregion
    }
}
