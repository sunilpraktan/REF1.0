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
using System.Windows;
using Reflection.Presentation.Services;
using Reflection.Presentation.ViewModel;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.Production.ViewModels
{
    public class EPR_T001_VM : WorkspaceViewModel<EPR_T001>
    {


        bool blNew = true;
        WebServiceRepository<EPR_T001> repository = new WebServiceRepository<EPR_T001>();
        WebServiceRepository<string> repositoryStatus = new WebServiceRepository<string>();
        WebServiceRepository<MultipleContext_EPR_T001> repositoryM = new WebServiceRepository<MultipleContext_EPR_T001>();
        MultipleContext_EPR_T001 MCTemp = new MultipleContext_EPR_T001();


        private ICollectionView _dataGridCollection;
        private int _dgSelectedIndex;
        private string _filterString;
        private string _filterStringPlant;
        private string _filterStringMachineType;
        private string _filterStringMachine;
        private string _filterStringModel;
        private string _filterStringProduct;
        private string _filterStringBallDia;
        private string _filterStringBallMake;
        private string _filterStringWireMake;
        private string _filterStringBallType;
        private string _filterStringINK;
        private string _filterStringILD;
        private string _filterStringSalesOrder;
        private string _filterStringCustomer;



        #region Methods
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private bool _post;
        public bool post
        {
            get { return _post; }
            set
            {
                if (_post != value)
                {
                    _post = value;
                    RaisePropertyChanged("post");
                }
            }
        }
        private bool _stop;
        public bool stop
        {
            get { return _stop; }
            set
            {
                if (_stop != value)
                {
                    _stop = value;
                    RaisePropertyChanged("stop");
                }
            }
        }
        #endregion

        #region AutoSuggest Textbox Declaration
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(EPR_T001_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

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

        private AutoSuggestTextViewModel<dynamic> _ASMachine { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASMachine
        {
            get { return _ASMachine; }
            set
            {
                if (_ASMachine != value)
                {
                    _ASMachine = value; RaisePropertyChanged("ASMachine");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASMake { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASMake
        {
            get { return _ASMake; }
            set
            {
                if (_ASMake != value)
                {
                    _ASMake = value; RaisePropertyChanged("ASMake");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASPackUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPackUnit
        {
            get { return _ASPackUnit; }
            set
            {
                if (_ASPackUnit != value)
                {
                    _ASPackUnit = value; RaisePropertyChanged("ASPackUnit");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASWireMake { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWireMake
        {
            get { return _ASWireMake; }
            set
            {
                if (_ASWireMake != value)
                {
                    _ASWireMake = value; RaisePropertyChanged("ASWireMake");
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
        private AutoSuggestTextViewModel<dynamic> _ASLocationdg { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLocationdg
        {
            get { return _ASLocationdg; }
            set
            {
                if (_ASLocationdg != value)
                {
                    _ASLocationdg = value; RaisePropertyChanged("ASLocationdg");
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
                    if (SourceName == "MachineCode")
                    { ASDefault = ASMachine; }
                    else if (SourceName == "Make")
                    { ASDefault = ASMake; }
                    else if (SourceName == "WireMake")
                    { ASDefault = ASWireMake; }
                    else if (SourceName == "Locationdg")
                    { ASDefault = ASLocationdg; }
                }
            }
        }
        #endregion


        #region ICollection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private ICollectionView _CollectionPlant;
        public ICollectionView CollectionPlant
        {
            get { return _CollectionPlant; }
            set { _CollectionPlant = value; RaisePropertyChanged("CollectionPlant"); }
        }

        private ICollectionView _CollectionMachineType;
        public ICollectionView CollectionMachineType
        {
            get { return _CollectionMachineType; }
            set { _CollectionMachineType = value; RaisePropertyChanged("CollectionMachineType"); }
        }

        private ICollectionView _CollectionMachine;
        public ICollectionView CollectionMachine
        {
            get { return _CollectionMachine; }
            set { _CollectionMachine = value; RaisePropertyChanged("CollectionMachine"); }
        }

        private ICollectionView _CollectionModel;
        public ICollectionView CollectionModel
        {
            get { return _CollectionModel; }
            set { _CollectionModel = value; RaisePropertyChanged("CollectionModel"); }
        }

        private ICollectionView _CollectionProduct;
        public ICollectionView CollectionProduct
        {
            get { return _CollectionProduct; }
            set { _CollectionProduct = value; RaisePropertyChanged("CollectionProduct"); }
        }

        private ICollectionView _CollectionBallDia;
        public ICollectionView CollectionBallDia
        {
            get { return _CollectionBallDia; }
            set { _CollectionBallDia = value; RaisePropertyChanged("CollectionBallDia"); }
        }

        private ICollectionView _CollectionBallMake;
        public ICollectionView CollectionBallMake
        {
            get { return _CollectionBallMake; }
            set { _CollectionBallMake = value; RaisePropertyChanged("CollectionBallMake"); }
        }

        private ICollectionView _CollectionWireMake;
        public ICollectionView CollectionWireMake
        {
            get { return _CollectionWireMake; }
            set { _CollectionWireMake = value; RaisePropertyChanged("CollectionWireMake"); }
        }

        private ICollectionView _CollectionBallType;
        public ICollectionView CollectionBallType
        {
            get { return _CollectionBallType; }
            set { _CollectionBallType = value; RaisePropertyChanged("CollectionBallType"); }
        }

        private ICollectionView _CollectionINK;
        public ICollectionView CollectionINK
        {
            get { return _CollectionINK; }
            set { _CollectionINK = value; RaisePropertyChanged("CollectionINK"); }
        }

        private ICollectionView _CollectionILD;
        public ICollectionView CollectionILD
        {
            get { return _CollectionILD; }
            set { _CollectionILD = value; RaisePropertyChanged("CollectionILD"); }
        }

        private ICollectionView _CollectionSalesOrder;
        public ICollectionView CollectionSalesOrder
        {
            get { return _CollectionSalesOrder; }
            set { _CollectionSalesOrder = value; RaisePropertyChanged("CollectionSalesOrder"); }
        }

        private ICollectionView _CollectionCustomer;
        public ICollectionView CollectionCustomer
        {
            get { return _CollectionCustomer; }
            set { _CollectionCustomer = value; RaisePropertyChanged("CollectionCustomer"); }
        }

        private ICollectionView _ShiftCollection;
        public ICollectionView ShiftCollection
        {
            get { return _ShiftCollection; }
            set { _ShiftCollection = value; RaisePropertyChanged("ShiftCollection"); }
        }
        private ICollectionView _PkgUnitCollection;
        public ICollectionView PkgUnitCollection
        {
            get { return _PkgUnitCollection; }
            set { _PkgUnitCollection = value; RaisePropertyChanged("PkgUnitCollection"); }
        }

        private ICollectionView _BShiftCollection;
        public ICollectionView BShiftCollection
        {
            get { return _BShiftCollection; }
            set
            {
                _BShiftCollection = value;
                RaisePropertyChanged("BShiftCollection");
            }
        }

        #endregion

        #region RelayCommand
        public RelayCommand<object> CmdAdddMachine { get; private set; }
        public RelayCommand<object> CmdAddMake { get; private set; }
        public RelayCommand<object> CmdAddWireMake { get; private set; }
        public RelayCommand<object> Cmdaddlocationdg { get; private set; }
        public RelayCommand<IList> SelectionChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandILDDetails
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandPlant
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandMachineType
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandMachine
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandModel
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandProduct
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandBallDia
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandBallMake
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandWireMake
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandBallType
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandINK
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandSalesOrder
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandCustomer
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedCommandILD
        {
            get;
            private set;
        }
        public RelayCommand<IList> CellChangedCommand
        {
            get;
            private set;
        }

        private RelayCommand _buttonClickCommand;
        public RelayCommand ButtonClickCommand
        {
            get;
            private set;
        }
        public RelayCommand CmdForCancelMachine { get; private set; }
        public RelayCommand CmdForStopMachine { get; private set; }
        public RelayCommand<object> cmdOpenAttachments { get; private set; }
        public RelayCommand<object> CommandLocations { get; private set; }
        public RelayCommand<object> CommandPkgUnit { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region EPR_T001
        private List<EPR_T001> _SelectedList;
        public List<EPR_T001> SelectedList
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

        private EPR_T001 _SelectedEPR_T001;
        public EPR_T001 SelectedEPR_T001
        {
            get
            {
                //this.ErrorExist = _SelectedEPR_T001.HasErrors;
                return _SelectedEPR_T001;
            }
            set
            {
                if (_SelectedEPR_T001 != value)
                {
                    _SelectedEPR_T001 = value;
                    //this.ErrorExist = _SelectedEPR_T001.HasErrors;
                    RaisePropertyChanged("SelectedEPR_T001");
                    value.BeginEdit();
                }
            }
        }
        #endregion

        #region EPR_T001
        private static ObservableCollection<EPR_T001> _GoodsDetails = new ObservableCollection<EPR_T001>();
        public ObservableCollection<EPR_T001> GoodsDetails
        {
            get { return _GoodsDetails; }
            set
            {
                if (_GoodsDetails != value)
                {
                    _GoodsDetails = value;

                    RaisePropertyChanged("GoodsDetails");
                }
            }
        }


        #endregion

        #region RPT_EPR_T001
        private static ObservableCollection<RPT_EPR_T001> _RPTDetails = new ObservableCollection<RPT_EPR_T001>();
        public ObservableCollection<RPT_EPR_T001> RPTDetails
        {
            get { return _RPTDetails; }
            set
            {
                if (_RPTDetails != value)
                {
                    _RPTDetails = value;

                    RaisePropertyChanged("RPTDetails");
                }
            }
        }


        #endregion

        #region ADM_M003 poup Plant
        private List<ADM_M003_P> _SelectedPlantList;
        public List<ADM_M003_P> SelectedPalntList
        {
            get { return _SelectedPlantList; }
            set
            {
                if (_SelectedPlantList != value)
                {
                    _SelectedPlantList = value;
                    RaisePropertyChanged("SelectedPalntList");
                }
            }
        }
        #endregion

        #region ZADM_M013 poup Machine Type
        private List<ZADM_M013_P_machine_type> _SelectedMachineList;
        public List<ZADM_M013_P_machine_type> SelectedMachineList
        {
            get { return _SelectedMachineList; }
            set
            {
                if (_SelectedMachineList != value)
                {
                    _SelectedMachineList = value;
                    RaisePropertyChanged("SelectedMachineList");
                }
            }
        }
        #endregion

        #region ZADM_M013 poup Machine
        private List<ZADM_M013_P> _SelectedMCList;
        public List<ZADM_M013_P> SelectedMCList
        {
            get { return _SelectedMCList; }
            set
            {
                if (_SelectedMCList != value)
                {
                    _SelectedMCList = value;
                    RaisePropertyChanged("SelectedMCList");
                }
            }
        }
        #endregion

        #region ZADM_M009 poup Model
        private List<ZADM_M009_P> _SelectedModelList;
        public List<ZADM_M009_P> SelectedModelList
        {
            get { return _SelectedModelList; }
            set
            {
                if (_SelectedModelList != value)
                {
                    _SelectedModelList = value;
                    RaisePropertyChanged("SelectedModelList");
                }
            }
        }
        #endregion

        #region ADM_M022 poup Product
        private List<ADM_M022_P_ESSEM> _SelectedProductList;
        public List<ADM_M022_P_ESSEM> SelectedProductList
        {
            get { return _SelectedProductList; }
            set
            {
                if (_SelectedProductList != value)
                {
                    _SelectedProductList = value;
                    RaisePropertyChanged("SelectedProductList");
                }
            }
        }
        #endregion

        #region ZADM_M001_P  BallDia
        private List<ZADM_M001_P> _SelectedBallDiaList;
        public List<ZADM_M001_P> SelectedBallDiaList
        {
            get { return _SelectedBallDiaList; }
            set
            {
                if (_SelectedBallDiaList != value)
                {
                    _SelectedBallDiaList = value;
                    RaisePropertyChanged("SelectedBallDiaList");
                }
            }
        }
        #endregion

        #region ADM_M032_P  BallMake
        private List<ADM_M032_P> _SelectedBallMakeList;
        public List<ADM_M032_P> SelectedBallMakeList
        {
            get { return _SelectedBallMakeList; }
            set
            {
                if (_SelectedBallMakeList != value)
                {
                    _SelectedBallMakeList = value;
                    RaisePropertyChanged("SelectedBallMakeList");
                }
            }
        }
        #endregion

        #region ADM_M032_P  WireMake
        private List<ADM_M032_P> _SelectedWireMakeList;
        public List<ADM_M032_P> SelectedWireMakeList
        {
            get { return _SelectedWireMakeList; }
            set
            {
                if (_SelectedWireMakeList != value)
                {
                    _SelectedWireMakeList = value;
                    RaisePropertyChanged("SelectedWireMakeList");
                }
            }
        }
        #endregion

        #region ZADM_M002_P  BallType
        private List<ZADM_M002_P> _SelectedBallTypeList;
        public List<ZADM_M002_P> SelectedBallTypeList
        {
            get { return _SelectedBallTypeList; }
            set
            {
                if (_SelectedBallTypeList != value)
                {
                    _SelectedBallTypeList = value;
                    RaisePropertyChanged("SelectedBallTypeList");
                }
            }
        }
        #endregion

        #region ZADM_M006_P  INK
        private List<ZADM_M006_P> _SelectedINKList;
        public List<ZADM_M006_P> SelectedINKList
        {
            get { return _SelectedINKList; }
            set
            {
                if (_SelectedINKList != value)
                {
                    _SelectedINKList = value;
                    RaisePropertyChanged("SelectedINKList");
                }
            }
        }
        #endregion

        #region ZADM_M007_P  ILD
        private List<ZADM_M007_P> _SelectedILDList;
        public List<ZADM_M007_P> SelectedILDList
        {
            get { return _SelectedILDList; }
            set
            {
                if (_SelectedILDList != value)
                {
                    _SelectedILDList = value;
                    RaisePropertyChanged("SelectedILDList");
                }
            }
        }
        #endregion

        #region SEL_T001_P  Sales Order
        private List<SEL_T001_P> _SelectedSalesOrderList;
        public List<SEL_T001_P> SelectedSalesOrderList
        {
            get { return _SelectedSalesOrderList; }
            set
            {
                if (_SelectedSalesOrderList != value)
                {
                    _SelectedSalesOrderList = value;
                    RaisePropertyChanged("SelectedSalesOrderList");
                }
            }
        }
        #endregion

        #region ADM_M028_popup  cutomer
        private List<ADM_M028_P> _SelectedCustomerList;
        public List<ADM_M028_P> SelectedCustomerList
        {
            get { return _SelectedCustomerList; }
            set
            {
                if (_SelectedCustomerList != value)
                {
                    _SelectedCustomerList = value;
                    RaisePropertyChanged("SelectedCustomerList");
                }
            }
        }
        #endregion

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
                var msg = new NotificationMessage("EPR_T001_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
            }

        }

        MultipleContext_EPR_T001 _MC = new MultipleContext_EPR_T001();
        public MultipleContext_EPR_T001 MC
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
        public List<ADM_M003> _locationList1;
        public List<ADM_M003> LocationList1
        {
            get
            {
                return _locationList1;
            }
            set
            {
                _locationList1 = value;
                RaisePropertyChanged("LocationList1");
            }
        }

        #region
        public EPR_T001_VM(string ts_code)
            : base()
        {
            this.ts_code_vm = ts_code;
            SelectedList = new List<EPR_T001>();
            SelectedEPR_T001 = new EPR_T001();
            SelectedPalntList = new List<ADM_M003_P>();
            SelectedMachineList = new List<ZADM_M013_P_machine_type>();
            SelectedMCList = new List<ZADM_M013_P>();
            SelectedModelList = new List<ZADM_M009_P>();
            SelectedProductList = new List<ADM_M022_P_ESSEM>();
            SelectedBallDiaList = new List<ZADM_M001_P>();
            SelectedBallMakeList = new List<ADM_M032_P>();
            SelectedWireMakeList = new List<ADM_M032_P>();
            SelectedBallTypeList = new List<ZADM_M002_P>();
            SelectedINKList = new List<ZADM_M006_P>();
            SelectedILDList = new List<ZADM_M007_P>();
            SelectedSalesOrderList = new List<SEL_T001_P>();
            SelectedCustomerList = new List<ADM_M028_P>();

            GoodsDetails = new ObservableCollection<EPR_T001>();

            MC = new MultipleContext_EPR_T001();

            post = true;
            stop = true;
            CmdForCancelMachine = new RelayCommand(() => { StatusChangeMachine(); });
            CmdForStopMachine = new RelayCommand(() => { StatusStopItem(); });

            SelectedEPR_T001.ValidateAsync().Wait();
            ButtonClickCommand = new RelayCommand(GetButtonILD);

            SelectedEPR_T001.client = AppSessionState.client;
            SelectedEPR_T001.start_dt = DateTime.Now.Date;
            SelectedEPR_T001.Rpt_Date = DateTime.Now.Date;
            SelectedEPR_T001.location_Id = AppSessionState.location_Id;
            SelectedEPR_T001.user_source1 = AppSessionState.UserSource1;
            SelectedEPR_T001.user_source2 = AppSessionState.UserSource2;
            SelectedEPR_T001.userid = AppSessionState.UserID;
            try
            {
                SelectedEPR_T001.RptMachineType = "All";
                SelectedEPR_T001.ReportType = "Report";

            }
            catch
            {

            }
            LoadInitialData();
        }
        public EPR_T001_VM(string ts_code, string doc_no)
            : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            SelectedList = new List<EPR_T001>();
            SelectedEPR_T001 = new EPR_T001();
            SelectedPalntList = new List<ADM_M003_P>();
            SelectedMachineList = new List<ZADM_M013_P_machine_type>();
            SelectedMCList = new List<ZADM_M013_P>();
            SelectedModelList = new List<ZADM_M009_P>();
            SelectedProductList = new List<ADM_M022_P_ESSEM>();
            SelectedBallDiaList = new List<ZADM_M001_P>();
            SelectedBallMakeList = new List<ADM_M032_P>();
            SelectedWireMakeList = new List<ADM_M032_P>();
            SelectedBallTypeList = new List<ZADM_M002_P>();
            SelectedINKList = new List<ZADM_M006_P>();
            SelectedILDList = new List<ZADM_M007_P>();
            SelectedSalesOrderList = new List<SEL_T001_P>();
            SelectedCustomerList = new List<ADM_M028_P>();

            GoodsDetails = new ObservableCollection<EPR_T001>();

            MC = new MultipleContext_EPR_T001();

            post = true;
            stop = true;
            CmdForCancelMachine = new RelayCommand(() => { StatusChangeMachine(); });
            CmdForStopMachine = new RelayCommand(() => { StatusStopItem(); });

            SelectedEPR_T001.ValidateAsync().Wait();
            ButtonClickCommand = new RelayCommand(GetButtonILD);

            SelectedEPR_T001.client = AppSessionState.client;
            SelectedEPR_T001.start_dt = DateTime.Now.Date;
            SelectedEPR_T001.Rpt_Date = DateTime.Now.Date;
            SelectedEPR_T001.location_Id = AppSessionState.location_Id;
            SelectedEPR_T001.user_source1 = AppSessionState.UserSource1;
            SelectedEPR_T001.user_source2 = AppSessionState.UserSource2;
            SelectedEPR_T001.userid = AppSessionState.UserID;
            try
            {
                SelectedEPR_T001.RptMachineType = "All";
                SelectedEPR_T001.ReportType = "Report";

            }
            catch
            {

            }
            LoadInitialData();
        }

        #endregion
        private void StatusChangeMachine()
        {
            if (GoodsDetails[dgSelectedIndex].status == "Open" || GoodsDetails[dgSelectedIndex].status == "004")
            {
                string Request = "StatusCancelled" + "!@" + GoodsDetails[dgSelectedIndex].id + "!@" + GoodsDetails[dgSelectedIndex].machinecode + "!@" + GoodsDetails[dgSelectedIndex].ItemCode;
                string reader = repositoryStatus.Update<string>(Request, "CancelStatusILDChart", "Production");

                int intreader = Convert.ToInt32(reader);

                if (intreader >= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("This Machine Status Is cancelled..", this.Title);
                    showMessageService.ShowMessage();

                    GoodsDetails[dgSelectedIndex].status = "006";
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("This Machine Status Is not cancelled..", this.Title);
                    showMessageService.ShowMessage();
                    post = true;
                }
            }
            else if (GoodsDetails[dgSelectedIndex].status == "Current" || GoodsDetails[dgSelectedIndex].status == "012")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("This Machine Status is Current, So you can't Cancelled ..", this.Title);
                showMessageService.ShowMessage();
                post = true;
            }
            else if (GoodsDetails[dgSelectedIndex].status == "Stopped" || GoodsDetails[dgSelectedIndex].status == "015")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("This Machine Status is Stopped, So you can't Cancelled ..", this.Title);
                showMessageService.ShowMessage();
                post = true;
            }
        }
        private void StatusStopItem()
        {
            if (GoodsDetails[dgSelectedIndex].status == "Current" || GoodsDetails[dgSelectedIndex].status == "012")
            {
                string Request = "StatusStop" + "!@" + GoodsDetails[dgSelectedIndex].id + "!@" + GoodsDetails[dgSelectedIndex].machinecode + "!@" + GoodsDetails[dgSelectedIndex].ItemCode;
                string reader = repositoryStatus.Update<string>(Request, "StopStatusILDChart", "Production");

                int intreader = Convert.ToInt32(reader);

                if (intreader >= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("This Machine Status Is Stopped..", this.Title);
                    showMessageService.ShowMessage();

                    GoodsDetails[dgSelectedIndex].status = "015";
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("This Machine Status Is not Stopped..", this.Title);
                    showMessageService.ShowMessage();
                    post = true;
                }
            }
            else if (GoodsDetails[dgSelectedIndex].status == "Stopped" || GoodsDetails[dgSelectedIndex].status == "015")
            {
                string Request = "StatusCurrent" + "!@" + GoodsDetails[dgSelectedIndex].id + "!@" + GoodsDetails[dgSelectedIndex].machinecode + "!@" + GoodsDetails[dgSelectedIndex].ItemCode;
                string reader = repositoryStatus.Update<string>(Request, "CurrentStatusILDChart", "Production");

                int intreader = Convert.ToInt32(reader);

                if (intreader >= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("This Machine Status Is Current..", this.Title);
                    showMessageService.ShowMessage();

                    GoodsDetails[dgSelectedIndex].status = "012";
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("This Machine Status Is not Convert to Current..", this.Title);
                    showMessageService.ShowMessage();
                    post = true;
                }
            }
            else
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("This Machine Status Is Open So you can't Convert To Current ..", this.Title);
                showMessageService.ShowMessage();
                post = true;
            }


        }

        private void OpenDocumentViewer(object InputValue)
        {
            WebServiceRepository<MultipleContext_Attachments> repository_MCAttachments = new WebServiceRepository<MultipleContext_Attachments>();
            List<COM_T003> Attachments = new List<COM_T003>();
            EPR_T001 EntityObjectParameter = new EPR_T001();
            MultipleContext_Attachments MCAttachments = new MultipleContext_Attachments();
            try
            {
                if (InputValue != null)
                {
                    EntityObjectParameter = ((IEnumerable)InputValue).Cast<EPR_T001>().ToList()[0];
                }
                string Request = "GetAllFiles" + "!@" + AppSessionState.client + "!@" + (EntityObjectParameter.comp_code ?? AppSessionState.comp_code) + "!@" + (EntityObjectParameter.location_Id ?? AppSessionState.location_Id) + "!@" + (EntityObjectParameter.doc_cat ?? "") + "!@" + (EntityObjectParameter.doc_cat ?? "") + "!@" + EntityObjectParameter.ItemCode;
                //MCAttachments = repository_MCAttachments.GetData<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Reflection.BusinessLogic.ReflectionFileHandlingServices");
                MCAttachments = repository_MCAttachments.GetDataWithReturnDomainObject<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                if (!string.IsNullOrEmpty(EntityObjectParameter.ItemCode))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = EntityObjectParameter.ItemCode.Replace("/", "--"), DocumentList = MCAttachments.Attachments, client = AppSessionState.client, comp_code = (SelectedEPR_T001.comp_code ?? AppSessionState.comp_code) });
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
        private void GetSelectedList(IList DataList)
        {
            IList list = DataList as IList;
            List<EPR_T001> tSelectedItemsList = list.Cast<EPR_T001>().ToList();
            if (tSelectedItemsList.Count > 0)
            {
                SelectedEPR_T001 = (EPR_T001)tSelectedItemsList[0];
                //GoodsDetails = new ObservableCollection<EPR_T001>();
                blNew = false;
            }
        }

        private void GetSelectedGoodDetails(IList IssueList)
        {
            try
            {
                IList list = IssueList as IList;

                List<EPR_T001> SelectedItemsList2 = list.Cast<EPR_T001>().ToList();
                if (SelectedItemsList2.Count > 0)
                {
                    SelectedEPR_T001 = (EPR_T001)SelectedItemsList2[0];

                    string request = "";
                    request = AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + SelectedEPR_T001.machine_id + "!@" + SelectedEPR_T001.machinecode;

                    MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MC, "EPR_T001_Data", "ILDChart", "Production", "LoadAll", 0, request);
                    MC.GoodsDetails = MCTemp.GoodsDetails;
                    GoodsDetails = new ObservableCollection<EPR_T001>();
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

        private void GetSelectedPlant(IList PlantList)
        {
            IList list = PlantList as IList;
            List<ADM_M003_P> GetSelectedPlantTemp = list.Cast<ADM_M003_P>().ToList();

            if (GetSelectedPlantTemp.Count > 0)
            {
                SelectedEPR_T001.location_Id = Convert.ToString(GetSelectedPlantTemp[0].location_Id);
                SelectedEPR_T001.PlantName = GetSelectedPlantTemp[0].LoctnNm;
            }
        }

        private void GetSelectedMachineType(IList MachineTypeList)
        {
            IList list = MachineTypeList as IList;
            List<ZADM_M013_P_machine_type> GetSelectedMachineTypeTemp = list.Cast<ZADM_M013_P_machine_type>().ToList();

            if (GetSelectedMachineTypeTemp.Count > 0)
            {
                SelectedEPR_T001.MachineType = GetSelectedMachineTypeTemp[0].mctype;
            }

            //var MachineList = (from o in MC.Machine
            //                   where o.mctype == SelectedEPR_T001.MachineType.
            //                   select o).ToList();

            //CollectionMachine = CollectionViewSource.GetDefaultView(MachineList);
            //CollectionMachine.Filter = new Predicate<object>(FilterMachine);           

        }

        //private void GetSelectedMachine(IList MachineList)
        //{
        //    try
        //    {
        //        IList list = MachineList as IList;
        //        List<ZADM_M013_P> SelectedMachineTemp = list.Cast<ZADM_M013_P>().ToList();

        //        if (SelectedMachineTemp.Count > 0 && dgSelectedIndex != -1)
        //        {
        //            var q = GoodsDetails.Where(X => X.machine_id == SelectedMachineTemp[0].machine_id).FirstOrDefault();

        //            if (q != null)
        //            {
        //                if (GoodsDetails.Count() > dgSelectedIndex)
        //                {
        //                    GoodsDetails[dgSelectedIndex].machine_id = SelectedMachineTemp[0].machine_id;
        //                    GoodsDetails[dgSelectedIndex].machinecode = SelectedMachineTemp[0].machinecode;
        //                }
        //            }
        //            else
        //            {
        //                if (GoodsDetails.Count() <= dgSelectedIndex)
        //                {
        //                    GoodsDetails.Add(new EPR_T001()
        //                    {
        //                        machine_id = SelectedMachineTemp[0].machine_id,
        //                        machinecode = SelectedMachineTemp[0].machinecode
        //                    });
        //                }
        //                else
        //                {
        //                    GoodsDetails[dgSelectedIndex].machine_id = SelectedMachineTemp[0].machine_id;
        //                    GoodsDetails[dgSelectedIndex].machinecode = SelectedMachineTemp[0].machinecode;
        //                }
        //            }
        //        }
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

        private void InsertMachine(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                //AppSessionState.StringListValue = StringListUOM;
                string Request = "";
                ZADM_M013_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Machine.Where(x => x.machinecode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M013_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    //var InputValueIfExists = GoodsDetails.Where(X => X.machinecode == POPUPEntityObject.machinecode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    //int IndexOfExistValue = GoodsDetails.IndexOf(GoodsDetails.Where(X => X.unit_code == POPUPEntityObject.machinecode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    //if (dgSelectedIndex >= 0 && GoodsDetails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    //{
                    //    if (GoodsDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    //    {
                    //        GoodsDetails[dgSelectedIndex].machinecode = POPUPEntityObject.machinecode;
                    //    }
                    //    else if (GoodsDetails[dgSelectedIndex].machinecode != POPUPEntityObject.machinecode)
                    //    {
                    //        GoodsDetails[dgSelectedIndex].machinecode = "";
                    //    }
                    //}
                    if (dgSelectedIndex >= 0 && GoodsDetails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        GoodsDetails[dgSelectedIndex].machinecode = POPUPEntityObject.machinecode;


                        SelectedEPR_T001.active = true;
                    }
                    else if (GoodsDetails[dgSelectedIndex].machinecode != POPUPEntityObject.machinecode)
                    {
                        GoodsDetails[dgSelectedIndex].machinecode = POPUPEntityObject.machinecode;

                        SelectedEPR_T001.active = true;
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

        private void InsertLocation(object InputValue)
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
                            { POPUPEntityObject = LocationList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    SelectedEPR_T001.location_Id = POPUPEntityObject.location_Id;
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

        private void InsertLocationdg(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                //AppSessionState.StringListValue = StringListUOM;
                string Request = "";
                ADM_M003 POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = LocationList1.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {

                    if (dgSelectedIndex >= 0 && GoodsDetails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        GoodsDetails[dgSelectedIndex].location_Id = POPUPEntityObject.location_Id;


                        SelectedEPR_T001.active = true;
                    }
                    else if (GoodsDetails[dgSelectedIndex].location_Id != POPUPEntityObject.location_Id)
                    {
                        GoodsDetails[dgSelectedIndex].location_Id = POPUPEntityObject.location_Id;

                        SelectedEPR_T001.active = true;
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
        private void GetSelectedModel(IList ModelList)
        {

            try
            {
                IList list = ModelList as IList;
                List<ZADM_M009_P> SelectedModelTemp = list.Cast<ZADM_M009_P>().ToList();

                if (SelectedModelTemp.Count > 0 && dgSelectedIndex != -1)
                {
                    var q = GoodsDetails.Where(X => X.model_id == SelectedModelTemp[0].model_id).FirstOrDefault();

                    if (q != null)
                    {
                        if (GoodsDetails.Count() > dgSelectedIndex)
                        {
                            GoodsDetails[dgSelectedIndex].model_id = SelectedModelTemp[0].model_id;
                            GoodsDetails[dgSelectedIndex].model_code = SelectedModelTemp[0].modelno;
                        }
                    }
                    else
                    {
                        if (GoodsDetails.Count() <= dgSelectedIndex)
                        {
                            GoodsDetails.Add(new EPR_T001() { model_id = SelectedModelTemp[0].model_id, model_code = SelectedModelTemp[0].modelno });
                        }
                        else
                        {
                            GoodsDetails[dgSelectedIndex].model_id = SelectedModelTemp[0].model_id;
                            GoodsDetails[dgSelectedIndex].model_code = SelectedModelTemp[0].modelno;

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

        private void GetSelectedProduct(IList ProductList)
        {
            try
            {
                IList list = ProductList as IList;
                List<ADM_M022_P_ESSEM> SelectedProductTemp = list.Cast<ADM_M022_P_ESSEM>().ToList();

                if (SelectedProductTemp.Count > 0 && dgSelectedIndex != -1)
                {
                    var q = GoodsDetails.Where(X => X.ItemCode == SelectedProductTemp[0].ItemCode).FirstOrDefault();

                    if (q != null)
                    {
                        if (GoodsDetails.Count() > dgSelectedIndex)
                        {
                            GoodsDetails[dgSelectedIndex].ItemCode = SelectedProductTemp[0].ItemCode;
                            GoodsDetails[dgSelectedIndex].shank_len = Convert.ToString(SelectedProductTemp[0].shanklen);
                            GoodsDetails[dgSelectedIndex].needle_dia = Convert.ToString(SelectedProductTemp[0].needledia);
                            GoodsDetails[dgSelectedIndex].needle = Convert.ToString(SelectedProductTemp[0].needlelen);

                        }
                    }
                    else
                    {
                        if (GoodsDetails.Count() <= dgSelectedIndex)
                        {
                            GoodsDetails.Add(new EPR_T001()
                            {
                                ItemCode = SelectedProductTemp[0].ItemCode,
                                shank_len = Convert.ToString(SelectedProductTemp[0].shanklen),
                                needle_dia = Convert.ToString(SelectedProductTemp[0].needledia),
                                needle = Convert.ToString(SelectedProductTemp[0].needlelen),

                            });
                        }
                        else
                        {
                            GoodsDetails[dgSelectedIndex].ItemCode = SelectedProductTemp[0].ItemCode;
                            GoodsDetails[dgSelectedIndex].shank_len = Convert.ToString(SelectedProductTemp[0].shanklen);
                            GoodsDetails[dgSelectedIndex].needle_dia = Convert.ToString(SelectedProductTemp[0].needledia);
                            GoodsDetails[dgSelectedIndex].needle = Convert.ToString(SelectedProductTemp[0].needlelen);

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

        private void GetSelectedBallDia(IList BallDiaList)
        {
            try
            {
                IList list = BallDiaList as IList;
                List<ZADM_M001_P> SelectedBallDiaTemp = list.Cast<ZADM_M001_P>().ToList();

                if (SelectedBallDiaTemp.Count > 0 && dgSelectedIndex != -1)
                {
                    var q = GoodsDetails.Where(X => X.ball_dia == Convert.ToString(SelectedBallDiaTemp[0].Ball_dia)).FirstOrDefault();

                    if (q != null)
                    {
                        if (GoodsDetails.Count() > dgSelectedIndex)
                        {
                            GoodsDetails[dgSelectedIndex].ball_dia = Convert.ToString(SelectedBallDiaTemp[0].Ball_dia);
                        }
                    }
                    else
                    {
                        if (GoodsDetails.Count() <= dgSelectedIndex)
                        {
                            GoodsDetails.Add(new EPR_T001() { ball_dia = Convert.ToString(SelectedBallDiaTemp[0].Ball_dia) });
                        }
                        else
                        {
                            GoodsDetails[dgSelectedIndex].ball_dia = Convert.ToString(SelectedBallDiaTemp[0].Ball_dia);

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

        //private void GetSelectedBallMake(IList BallMakeList)
        //{
        //    try
        //    {
        //        IList list = BallMakeList as IList;
        //        List<ADM_M032_P> SelectedBallMakeTemp = list.Cast<ADM_M032_P>().ToList();

        //        if (SelectedBallMakeTemp.Count > 0 && dgSelectedIndex != -1)
        //        {
        //            var q = GoodsDetails.Where(X => X.ball_make == Convert.ToString(SelectedBallMakeTemp[0].Make)).FirstOrDefault();

        //            if (q != null)
        //            {
        //                if (GoodsDetails.Count() > dgSelectedIndex)
        //                {
        //                    GoodsDetails[dgSelectedIndex].ball_make = Convert.ToString(SelectedBallMakeTemp[0].Make);
        //                }
        //            }
        //            else
        //            {
        //                if (GoodsDetails.Count() <= dgSelectedIndex)
        //                {
        //                    GoodsDetails.Add(new EPR_T001() { ball_make = Convert.ToString(SelectedBallMakeTemp[0].Make) });
        //                }
        //                else
        //                {
        //                    GoodsDetails[dgSelectedIndex].ball_make = Convert.ToString(SelectedBallMakeTemp[0].Make);
        //                }
        //            }
        //        }
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


        private void InsertMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                //AppSessionState.StringListValue = StringListUOM;
                string Request = "";
                ADM_M032_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BallMake.Where(x => x.Make.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M032_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {

                    if (dgSelectedIndex >= 0 && GoodsDetails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        GoodsDetails[dgSelectedIndex].ball_make = POPUPEntityObject.Make;


                        SelectedEPR_T001.active = true;
                    }
                    else if (GoodsDetails[dgSelectedIndex].ball_make != POPUPEntityObject.Make)
                    {
                        GoodsDetails[dgSelectedIndex].ball_make = POPUPEntityObject.Make;

                        SelectedEPR_T001.active = true;
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

        //private void GetSelectedWireMake(IList WireMakeList)
        //{
        //    try
        //    {
        //        IList list = WireMakeList as IList;
        //        List<ADM_M032_P> SelectedWireMakeTemp = list.Cast<ADM_M032_P>().ToList();

        //        if (SelectedWireMakeTemp.Count > 0 && dgSelectedIndex != -1)
        //        {
        //            var q = GoodsDetails.Where(X => X.wire_make == Convert.ToString(SelectedWireMakeTemp[0].Make)).FirstOrDefault();

        //            if (q != null)
        //            {
        //                if (GoodsDetails.Count() > dgSelectedIndex)
        //                {
        //                    GoodsDetails[dgSelectedIndex].wire_make = Convert.ToString(SelectedWireMakeTemp[0].Make);
        //                }
        //            }
        //            else
        //            {
        //                if (GoodsDetails.Count() <= dgSelectedIndex)
        //                {
        //                    GoodsDetails.Add(new EPR_T001() { wire_make = Convert.ToString(SelectedWireMakeTemp[0].Make) });
        //                }
        //                else
        //                {
        //                    GoodsDetails[dgSelectedIndex].wire_make = Convert.ToString(SelectedWireMakeTemp[0].Make);
        //                }
        //            }
        //        }
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

        private void InsertWireMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                //AppSessionState.StringListValue = StringListUOM;
                string Request = "";
                ADM_M032_P POPUPEntityObject = null;
                dgSelectedIndex = dgSelectedIndex;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WireMake.Where(x => x.Make.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M032_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {

                    if (dgSelectedIndex >= 0 && GoodsDetails.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {

                        GoodsDetails[dgSelectedIndex].wire_make = POPUPEntityObject.Make;


                        SelectedEPR_T001.active = true;
                    }
                    else if (GoodsDetails[dgSelectedIndex].wire_make != POPUPEntityObject.Make)
                    {
                        GoodsDetails[dgSelectedIndex].wire_make = POPUPEntityObject.Make;

                        SelectedEPR_T001.active = true;
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

        private void GetSelectedBallType(IList BallTypeList)
        {
            try
            {
                IList list = BallTypeList as IList;
                List<ZADM_M002_P> SelectedBallTypeTemp = list.Cast<ZADM_M002_P>().ToList();

                if (SelectedBallTypeTemp.Count > 0 && dgSelectedIndex != -1)
                {
                    var q = GoodsDetails.Where(X => X.ball_type == Convert.ToString(SelectedBallTypeTemp[0].ball_type)).FirstOrDefault();

                    if (q != null)
                    {
                        if (GoodsDetails.Count() > dgSelectedIndex)
                        {
                            GoodsDetails[dgSelectedIndex].ball_type = Convert.ToString(SelectedBallTypeTemp[0].ball_type);
                        }
                    }
                    else
                    {
                        if (GoodsDetails.Count() <= dgSelectedIndex)
                        {
                            GoodsDetails.Add(new EPR_T001() { ball_type = Convert.ToString(SelectedBallTypeTemp[0].ball_type) });
                        }
                        else
                        {
                            GoodsDetails[dgSelectedIndex].ball_type = Convert.ToString(SelectedBallTypeTemp[0].ball_type);
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

        private void GetSelectedINK(IList INKList)
        {
            try
            {
                IList list = INKList as IList;
                List<ZADM_M006_P> SelectedINKTemp = list.Cast<ZADM_M006_P>().ToList();

                if (SelectedINKTemp.Count > 0 && dgSelectedIndex != -1)
                {
                    var q = GoodsDetails.Where(X => X.ink == Convert.ToString(SelectedINKTemp[0].ink)).FirstOrDefault();

                    if (q != null)
                    {
                        if (GoodsDetails.Count() > dgSelectedIndex)
                        {
                            GoodsDetails[dgSelectedIndex].ink = Convert.ToString(SelectedINKTemp[0].ink);
                        }
                    }
                    else
                    {
                        if (GoodsDetails.Count() <= dgSelectedIndex)
                        {
                            GoodsDetails.Add(new EPR_T001() { ink = Convert.ToString(SelectedINKTemp[0].ink) });
                        }
                        else
                        {
                            GoodsDetails[dgSelectedIndex].ink = Convert.ToString(SelectedINKTemp[0].ink);

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

        private void GetSelectedILD(IList ILDList)
        {
            try
            {
                IList list = ILDList as IList;
                List<ZADM_M007_P> SelectedILDTemp = list.Cast<ZADM_M007_P>().ToList();

                if (SelectedILDTemp.Count > 0 && dgSelectedIndex != -1)
                {
                    var q = GoodsDetails.Where(X => X.ild == Convert.ToString(SelectedILDTemp[0].ild)).FirstOrDefault();

                    if (q != null)
                    {
                        if (GoodsDetails.Count() > dgSelectedIndex)
                        {
                            GoodsDetails[dgSelectedIndex].ild = Convert.ToString(SelectedILDTemp[0].ild);
                        }
                    }
                    else
                    {
                        if (GoodsDetails.Count() <= dgSelectedIndex)
                        {
                            GoodsDetails.Add(new EPR_T001() { ild = Convert.ToString(SelectedILDTemp[0].ild) });
                        }
                        else
                        {
                            GoodsDetails[dgSelectedIndex].ild = Convert.ToString(SelectedILDTemp[0].ild);

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

        private void GetButtonILD()
        {
            try
            {
                //SelectedList = new List<EPR_T001>();
                //SelectedEPR_T001.location_Id = AppSessionState.location_Id;
                SelectedEPR_T001.start_dt = DateTime.Now.Date;
                string request;
                request = AppSessionState.comp_code + "!@" + SelectedEPR_T001.location_Id + "!@" + SelectedEPR_T001.machine_id + "!@" + SelectedEPR_T001.machinecode;
                MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTemp, "MM_T001_A_Data", "ILDChart", "Production", "Load", 0, request);
                SelectedList = MCTemp.ILDChart;

                if (SelectedList != null)
                {
                    GoodsDetails = new ObservableCollection<EPR_T001>(SelectedList);

                    //SelectedEPR_T001.plant = SelectedList[0].plant;
                    //for (int i = 0; i < GoodsDetails.Count; i++)
                    //{
                    //    GoodsDetails[i].active = false;
                    //}

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

        private void GetSelectedSalesOrder(IList SOList)
        {
            try
            {
                IList list = SOList as IList;
                List<SEL_T001_P> GetSelectedSOTemp = list.Cast<SEL_T001_P>().ToList();

                if (GetSelectedSOTemp.Count > 0)
                {
                    SelectedEPR_T001.sono = GetSelectedSOTemp[0].sono;
                }

                //IList list = ILDList as IList;
                //List<ZADM_M007_P> SelectedILDTemp = list.Cast<ZADM_M007_P>().ToList();

                //if (SelectedILDTemp.Count > 0 && dgSelectedIndex != -1)
                //{
                //    var q = GoodsDetails.Where(X => X.ild == Convert.ToString(SelectedILDTemp[0].ild)).FirstOrDefault();

                //    if (q != null)
                //    {
                //        if (GoodsDetails.Count() > dgSelectedIndex)
                //        {
                //            GoodsDetails[dgSelectedIndex].ild = Convert.ToString(SelectedILDTemp[0].ild);
                //        }
                //    }
                //    else
                //    {
                //        if (GoodsDetails.Count() <= dgSelectedIndex)
                //        {
                //            GoodsDetails.Add(new EPR_T001() { ild = Convert.ToString(SelectedILDTemp[0].ild) });
                //        }
                //        else
                //        {
                //            GoodsDetails[dgSelectedIndex].ild = Convert.ToString(SelectedILDTemp[0].ild);

                //        }
                //    }
                //}
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

        private void GetSelectedCustomer(IList CutomerList)
        {
            try
            {
                IList list = CutomerList as IList;
                List<ADM_M028_P> GetSelectedSOTemp = list.Cast<ADM_M028_P>().ToList();

                if (GetSelectedSOTemp.Count > 0)
                {
                    SelectedEPR_T001.PartyId = GetSelectedSOTemp[0].PartyId;
                    SelectedEPR_T001.PartyName = GetSelectedSOTemp[0].PartyNm;
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

        private void GetSelectedConversion(IList CutomerList)
        {
            try
            {

                var MachineList = (from o in MC.ILDChart
                                   where o.machine_id == GoodsDetails[dgSelectedIndex].machine_id
                                   && o.shift == GoodsDetails[dgSelectedIndex].shift
                                   && o.conv == GoodsDetails[dgSelectedIndex].conv
                                   && o.start_dt == GoodsDetails[dgSelectedIndex].start_dt
                                   && o.status == "012"

                                   select o).ToList();

                if (MachineList.Count > 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("This Conversion already exists for this Machine and Start Date Change it.", this.Title);
                    showMessageService.ShowMessage();
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
        private void InsertPkgUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M017_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        POPUPEntityObject = MC.PkgUnitList.Where(x => x.pkgunit.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M017_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M017_P>().ToList()[0];
                    }

                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = GoodsDetails.Where(x => x.pack_style == POPUPEntityObject.id).FirstOrDefault();
                    var IndexOfExistValue = GoodsDetails.IndexOf(GoodsDetails.Where(X => X.pack_style == POPUPEntityObject.id).FirstOrDefault());
                    if (dgSelectedIndex >= 0 && GoodsDetails.Count > dgSelectedIndex)
                    {
                        if (GoodsDetails[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            GoodsDetails[dgSelectedIndex].pack_style = POPUPEntityObject.id;
                            GoodsDetails[dgSelectedIndex].PackingUnit = POPUPEntityObject.pkgunit;
                            GoodsDetails[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (GoodsDetails[dgSelectedIndex].id != POPUPEntityObject.id)
                        {
                            GoodsDetails[dgSelectedIndex].pack_style = POPUPEntityObject.id;
                            GoodsDetails[dgSelectedIndex].PackingUnit = POPUPEntityObject.pkgunit;
                            GoodsDetails[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T001 newObj = new EPR_T001();
                for (int i = GoodsDetails.Count - 1; i >= 0; i--)
                {
                    bool xx = GoodsDetails[i].ComparePropertiesTo(newObj);
                    if (GoodsDetails[i].ComparePropertiesTo(newObj) == true && GoodsDetails.Count > 1)
                    {
                        GoodsDetails.RemoveAt(i);
                        if (GoodsDetails.Count == 0)
                        {
                            GoodsDetails.Add(newObj);
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
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    //GetButtonILD(doc_no_vm);

                    AppSessionState.ViewOtherRecordAllowed = true;
                }
                SelectedEPR_T001.location_Id = AppSessionState.location_Id;
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
                    Request = SelectedEPR_T001.client + "!@" + SelectedEPR_T001.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }
        private void LoadInitialData()
        {
            try
            {

                string request = "";
                request = AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + SelectedEPR_T001.machine_id + "!@" + SelectedEPR_T001.machinecode;
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MC, "EPR_T001_Data", "ILDChart", "Production", "LoadAll", 0, request);
                SelectedList = MC.ILDChart;
                //SelectedEPR_T001.plant = SelectedList[0].plant;

                #region Command Initialisation
                CmdAdddMachine = new RelayCommand<object>(items => { if (items == null) { return; } InsertMachine(items, false, false, true); });
                CmdAddMake = new RelayCommand<object>(items => { if (items == null) { return; } InsertMake(items, false, false, true); });
                CmdAddWireMake = new RelayCommand<object>(items => { if (items == null) { return; } InsertWireMake(items, false, false, true); });
                CommandLocations = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLocation(cmdPara); });// confirm assignment
                Cmdaddlocationdg = new RelayCommand<object>(items => { if (items == null) { return; } InsertLocationdg(items, false, false, true); });
                SelectionChangedCommand = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    GetSelectedList(items);
                });
                SelectionChangedCommandILDDetails = new RelayCommand<IList>(
                items =>
                {
                    if (items == null)
                    {
                        return;
                    }
                    //GetSelectedGoodDetails(items);
                    GetSelectedList(items);

                });

                SelectionChangedCommandPlant = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }

                  GetSelectedPlant(items);
              });

                SelectionChangedCommandMachineType = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }

                GetSelectedMachineType(items);
            });

                SelectionChangedCommandModel = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }

                  GetSelectedModel(items);
              });

                SelectionChangedCommandProduct = new RelayCommand<IList>(
              items =>
              {
                  if (items == null)
                  {
                      return;
                  }

                  GetSelectedProduct(items);
              });

                SelectionChangedCommandBallDia = new RelayCommand<IList>(
            items =>
            {
                if (items == null)
                {
                    return;
                }

                GetSelectedBallDia(items);
            });


                SelectionChangedCommandBallType = new RelayCommand<IList>(
          items =>
          {
              if (items == null)
              {
                  return;
              }

              GetSelectedBallType(items);
          });
                SelectionChangedCommandINK = new RelayCommand<IList>(
         items =>
         {
             if (items == null)
             {
                 return;
             }

             GetSelectedINK(items);
         });

                SelectionChangedCommandILD = new RelayCommand<IList>(
        items =>
        {
            if (items == null)
            {
                return;
            }

            GetSelectedILD(items);
        });

                SelectionChangedCommandSalesOrder = new RelayCommand<IList>(
                 items =>
                 {
                     if (items == null)
                     {
                         return;
                     }

                     GetSelectedSalesOrder(items);
                 });

                SelectionChangedCommandCustomer = new RelayCommand<IList>(
                  items =>
                  {
                      if (items == null)
                      {
                          return;
                      }

                      GetSelectedCustomer(items);
                  });
                CellChangedCommand = new RelayCommand<IList>(
                         items =>
                         {
                             if (items == null)
                             {
                                 return;
                             }

                             GetSelectedConversion(items);
                         });
                cmdOpenAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenDocumentViewer(cmdPara); });

                //ButtonClickCommand = new RelayCommand<IList>(
                // items =>
                // {
                //     if (items == null)
                //     {
                //         return;
                //     }

                //     GetButtonILD(items);
                // });
                CommandPkgUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPkgUOM(cmdPara, false, true, true); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                #endregion
                GoodsDetails = new ObservableCollection<EPR_T001>();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M013_P)x).machinecode);
                TheFilter = (o, prefix) => (((ZADM_M013_P)o).machinecode ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.Machine, TheFilter, SuggestedValue, "machinecode", "machinecode", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M013_P)x).machinecode);
                TheFilter = (o, prefix) => (((ZADM_M013_P)o).machinecode ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASMachine = new AutoSuggestTextViewModel<dynamic>(MC.Machine, TheFilter, SuggestedValue, "machinecode", "machinecode", true);
                ASMachine.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M032_P)x).Make);
                TheFilter = (o, prefix) => (((ADM_M032_P)o).Make ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASMake = new AutoSuggestTextViewModel<dynamic>(MC.BallMake, TheFilter, SuggestedValue, "ball_make", "Make", true);
                ASMake.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M032_P)x).Make);
                TheFilter = (o, prefix) => (((ADM_M032_P)o).Make ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASWireMake = new AutoSuggestTextViewModel<dynamic>(MC.WireMake, TheFilter, SuggestedValue, "wire_make", "Make", true);
                ASWireMake.AutoSuggestVM.IsEmptyValueAllowed = true;

                LocationList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASLocation = new AutoSuggestTextViewModel<dynamic>(LocationList, TheFilter, SuggestedValue, "location_Id", true);
                ASLocation.AutoSuggestVM.IsEmptyValueAllowed = true;

                LocationList1 = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASLocationdg = new AutoSuggestTextViewModel<dynamic>(LocationList, TheFilter, SuggestedValue, "location_Id", "location_Id", true);
                ASLocationdg.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M017_P)x).pkgunit);
                TheFilter = (o, prefix) => (((ZADM_M017_P)o).pkgunit ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASPackUnit = new AutoSuggestTextViewModel<dynamic>(MC.PkgUnitList, TheFilter, SuggestedValue, "pkgunit", "unit_code", true);
                ASPackUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                CollectionPlant = CollectionViewSource.GetDefaultView(MC.plant);
                CollectionPlant.Filter = new Predicate<object>(FilterPlant);

                CollectionMachineType = CollectionViewSource.GetDefaultView(MC.MachineType);
                CollectionMachineType.Filter = new Predicate<object>(FilterMachineType);

                CollectionMachine = CollectionViewSource.GetDefaultView(MC.Machine);
                CollectionMachine.Filter = new Predicate<object>(FilterMachine);

                CollectionModel = CollectionViewSource.GetDefaultView(MC.Model);
                CollectionModel.Filter = new Predicate<object>(FilterModel);

                CollectionProduct = CollectionViewSource.GetDefaultView(MC.Product);
                CollectionProduct.Filter = new Predicate<object>(FilterProduct);

                CollectionBallDia = CollectionViewSource.GetDefaultView(MC.BallDia);
                CollectionBallDia.Filter = new Predicate<object>(FilterBallDia);

                CollectionBallMake = CollectionViewSource.GetDefaultView(MC.BallMake);
                CollectionBallMake.Filter = new Predicate<object>(FilterBallMake);

                CollectionWireMake = CollectionViewSource.GetDefaultView(MC.WireMake);
                CollectionWireMake.Filter = new Predicate<object>(FilterWireMake);

                CollectionBallType = CollectionViewSource.GetDefaultView(MC.BallType);
                CollectionBallType.Filter = new Predicate<object>(FilterBallType);

                CollectionINK = CollectionViewSource.GetDefaultView(MC.INK);
                CollectionINK.Filter = new Predicate<object>(FilterINK);

                CollectionILD = CollectionViewSource.GetDefaultView(MC.ILD);
                CollectionILD.Filter = new Predicate<object>(FilterILD);

                CollectionSalesOrder = CollectionViewSource.GetDefaultView(MC.SalesOrder);
                CollectionSalesOrder.Filter = new Predicate<object>(FilterSalesOrder);

                CollectionCustomer = CollectionViewSource.GetDefaultView(MC.Customer);
                CollectionCustomer.Filter = new Predicate<object>(FilterCustomer);

                DataGridCollection = CollectionViewSource.GetDefaultView(SelectedList);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                var Shift = (from o in MC.ShiftList where o.shift != "All" select o).ToList();
                ShiftCollection = CollectionViewSource.GetDefaultView(Shift);

                PkgUnitCollection = CollectionViewSource.GetDefaultView(MC.PkgUnitList);
                PkgUnitCollection.Filter = new Predicate<object>(Filter_PkgUnit);

                BShiftCollection = CollectionViewSource.GetDefaultView(MC.ShiftList);
                SelectedTabControlIndex = 0;
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

        #region · Command Actions ·

        //private bool ValidationShift()
        //{
        //    try
        //    {
        //for (int i = 0; i < GoodsDetails.Count; i++)
        //{
        //    if (GoodsDetails[i].shift == null)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format("Field 'Shift' is required.", this.Title);
        //        showMessageService.ShowMessage();
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //foreach (EPR_T001 item in GoodsDetails)
        //{
        //    if (item.shift == null)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        protected override void OnSaveAction(InquiryActionResult<EPR_T001> result)
        {
            try
            {
                this.SelectedEPR_T001.EndEdit();
                ObjectSerializationService objSer = new ObjectSerializationService();

                if (ValidateControls() == true)
                {
                    if (ValidateControls123() == false)
                    {
                        
                        SelectedEPR_T001.comp_code = AppSessionState.comp_code;
                        SelectedEPR_T001.client = AppSessionState.client;
                        //SelectedEPR_T001.location_Id = AppSessionState.location_Id;
                        SelectedEPR_T001.editby = AppSessionState.UserID;
                        SelectedEPR_T001.add_by = AppSessionState.UserID;
                        if (blNew == true || blNew == false)
                        {
                            //SelectedEPR_T001.XmlDataDocument_EPR_T001 = objSer.ObjectToXML(GoodsDetails);
                            //SelectedEPR_T001 = repository.SaveWithReturnDomainObject<EPR_T001>(SelectedEPR_T001, "ILDChart", "Production");
                            //SelectedList.Add(SelectedEPR_T001);                        
                            //_dataGridCollection.Refresh();
                            //blNew = false;
                            List<EPR_T001> obj_col = new List<EPR_T001>();
                            foreach (var item in GoodsDetails)
                            {
                                if (item.Select == true)
                                {
                                    obj_col.Add(item);
                                }
                            }
                            //SelectedEPR_T001.XmlDataDocument_EPR_T001 = objSer.ObjectToXML(GoodsDetails);
                            SelectedEPR_T001.XmlDataDocument_EPR_T001 = objSer.ObjectToXML(obj_col);
                            SelectedEPR_T001.model_id = 0;
                            SelectedEPR_T001.machine_id = 0;
                            SelectedEPR_T001 = repository.UpdateWithReturnDomainObject<EPR_T001>(SelectedEPR_T001, "ILDChart", "Production");
                            SelectedList.Add(SelectedEPR_T001);
                        }
                        //else if (blNew == false)
                        //{                        
                        //      SelectedEPR_T001.XmlDataDocument_EPR_T001 = objSer.ObjectToXML(GoodsDetails);
                        //      SelectedEPR_T001 = repository.UpdateWithReturnDomainObject<EPR_T001>(SelectedEPR_T001, "ILDChart", "Production");
                        //      SelectedList.Add(SelectedEPR_T001);                                              
                        //}
                        _dataGridCollection.Refresh();
                        MessageBox.Show("Record Saved Successfully");
                        SelectedEPR_T001.Rpt_Date = DateTime.Now.Date;
                        try
                        {
                            SelectedEPR_T001.RptMachineType = "All";
                            SelectedEPR_T001.ReportType = "Report";

                        }
                        catch
                        {

                        }
                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Atleast One Record", this.Title);
                    showMessageService.ShowMessage();
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
        protected override void OnCreateAction(InquiryActionResult<EPR_T001> result)
        {
            blNew = true;

            GoodsDetails = new ObservableCollection<EPR_T001>();
            GoodsDetails.Clear();

            _dataGridCollection.Refresh();
            SelectedEPR_T001 = new EPR_T001();
            SelectedEPR_T001.start_dt = DateTime.Now.Date;
            SelectedEPR_T001.location_Id = AppSessionState.location_Id;
            SelectedEPR_T001.ValidateAsync().Wait();
        }
        protected override void OnRemoveAction(InquiryActionResult<EPR_T001> result)
        {
            //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //showMessageService.ButtonSetup = DialogButton.Ok;
            //showMessageService.Caption = "Delete Changes";
            //showMessageService.Text =
            //    String.Format(
            //        "This record will delete forever '{0}'",
            //            this.Title);

            //if (showMessageService.ShowMessage() == DialogResult.Ok)
            //{                

            //    this.SelectedEPR_T001.EndEdit();
            //    ObjectSerializationService objSer = new ObjectSerializationService();
            //    SelectedEPR_T001.XmlDataDocument_EPR_T001 = objSer.ObjectToXML(GoodsDetails);
            //    string xdoc = objSer.ObjectToXML(SelectedEPR_T001);
            //    string response = repository.Delete(xdoc, "ILDChart", "Production");
            //    SelectedList = new List<EPR_T001>();
            //    SelectedList.Add(SelectedEPR_T001);
            //    GoodsDetails = new ObservableCollection<EPR_T001>(SelectedList);
            //    _dataGridCollection.Refresh();
            //    SelectedEPR_T001.start_dt = DateTime.Now.Date;    
            //}
        }
        protected override void OnDiscardAction(InquiryActionResult<EPR_T001> result)
        {
            SelectedEPR_T001.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<EPR_T001> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<EPR_T001> result)
        {
            SelectedList = SelectedList;
            SelectedEPR_T001 = SelectedEPR_T001;
        }
        protected override void OnHelpAction(InquiryActionResult<EPR_T001> result)
        {
            SelectedList = SelectedList;
            SelectedEPR_T001 = SelectedEPR_T001;
        }
        protected override void OnPrintAction(InquiryActionResult<EPR_T001> result)
        {
            SelectedList = SelectedList;
            SelectedEPR_T001 = SelectedEPR_T001;
            string request = "";
            if (AppSessionState.comp_code == "1")
            {

                request = AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + SelectedEPR_T001.RptMachineType.ToString() + "!@" + Convert.ToDateTime(SelectedEPR_T001.start_dt).ToString("MM/dd/yyyy");
                MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTemp, "EPR_T001_Data", "ILDChart", "Production", "RPTINK", 0, request);

            }
            //else
            //{
            //    request = AppSessionState.comp_code + "!@" + SelectedEPR_T001.location_Id + "!@" + SelectedEPR_T001.machine_id + "!@" + SelectedEPR_T001.machinecode;
            //    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTemp, "MM_T001_A_Data", "ILDChart", "Production", "Load", 0, request);
            //}

            object[] objDataSource = new object[3];
            string[] objDataSourceName = new string[3];
            //MC.Delivery_Note.Clear();
            //MC.Delivery_Note.Add(SelectedLOG_T001_A);          

            List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
            ////var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == SelectedEPR_T001.comp_code).ToList();
            var CmpResult = TempCmpList.ToList();
            //var CmpResult = TempCmpList.Where(Cmp => Cmp.CompAbbre == "SPPL").ToList();
            objDataSource[0] = CmpResult;


            List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
            var Result = TempList.Where(loc => loc.location_Id == AppSessionState.location_Id).ToList();
            //var Result = TempList.ToList();
            objDataSource[1] = Result;
            if (AppSessionState.comp_code == "1")
            {
                objDataSource[2] = MCTemp.RptILDChart;
            }
            else
            {
                objDataSource[2] = MCTemp.ILDChart;
            }
            objDataSourceName[0] = "dsCompany";
            objDataSourceName[1] = "dsLocation";
            objDataSourceName[2] = "DsILDReport1";


            ReportManager ReportManager = new ReportManager();
            ////ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\Rpt_ConversionNote.rdlc");



            //////RPTDetails = MCTemp.RPTINK;
            ////RPTDetails = MCTemp.RPTINK;
            ////object objDS = new object();
            ////objDS = MCTemp.RptILDChart;
            ////ReportManager ReportManager = new ReportingServices.ReportManager();
            if (SelectedEPR_T001.ReportType == "Ink Chart")
            {
                //Ink chart
                //ReportManager.DisplayReport(objDS, "DSILDInk", "\\Production\\Rpt_ILD_Ink.rdlc");
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\InkChart.rdlc", "InkChart");
            }
            else if (SelectedEPR_T001.ReportType == "Ball Chart")
            {
                //Ball Chart
                //ReportManager.DisplayReport(objDS, "DsILDBall", "\\Production\\Rpt_ILD_Ball.rdlc");
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\BallChart.rdlc", "BallChart");
            }
            else if (SelectedEPR_T001.ReportType == "Diamensional Chart")
            {
                //Diamensional Chart
                //ReportManager.DisplayReport(objDS, "DsILDDiamensional", "\\Production\\Rpt_ILD_Diamensional.rdlc");
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\DimensionalChart.rdlc", "DimensionalChart");
            }
            else if (SelectedEPR_T001.ReportType == "Report")
            {
                //Pending change : Hardcoded location check
                if (AppSessionState.location_Id == "1")
                {
                    //ReportManager.DisplayReport(objDS, "DsILDReport1", "\\Production\\RPT_ILDProcessReportForUnit1.rdlc");
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\ILDProcessReportFor1.rdlc", "ILDProcessReport");

                }
                else if (AppSessionState.location_Id == "2")
                {
                    //ReportManager.DisplayReport(objDS, "DsILDReport1", "\\Production\\RPT_ILDProcessReportForUnit2.rdlc");
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\ILDProcessReportFor2.rdlc", "ILDProcessReport");
                }
                else if (AppSessionState.location_Id == "3")
                {
                    //ReportManager.DisplayReport(objDS, "DsILDReport1", "\\Production\\RPT_ILDProcessReportForUnit3.rdlc");

                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\ILDProcessReportFor3.rdlc", "ILDProcessReport");

                }
                else
                {

                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\ILDProcessForCRI.rdlc", "ILDProcessReport");
                }
            }



        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<EPR_T001> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters For Plant
        private void FilterCollectionPlant()
        {
            if (_CollectionPlant != null)
            {
                _CollectionPlant.Refresh();
            }
        }
        public string FilterStringPlant
        {
            get { return _filterStringPlant; }
            set
            {
                _filterStringPlant = value;
                RaisePropertyChanged("FilterStringPlant");
                FilterCollectionPlant();
            }
        }
        public bool FilterPlant(object obj)
        {
            var data = obj as ADM_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringPlant))
                {
                    return (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_filterStringPlant.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Machine Type
        private void FilterCollectionMachineType()
        {
            if (_CollectionMachineType != null)
            {
                _CollectionMachineType.Refresh();
            }
        }
        public string FilterStringMachineType
        {
            get { return _filterStringMachineType; }
            set
            {
                _filterStringMachineType = value;
                RaisePropertyChanged("FilterStringMachineType");
                FilterCollectionMachineType();
            }
        }
        public bool FilterMachineType(object obj)
        {
            var data = obj as ZADM_M013_P_machine_type;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMachineType))
                {
                    return (data.mctype != null && data.mctype.ToString().ToLower().Contains(_filterStringMachineType.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Machine
        private void FilterCollectionMachine()
        {
            if (_CollectionMachine != null)
            {
                _CollectionMachine.Refresh();
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
        public bool FilterMachine(object obj)
        {
            var data = obj as ZADM_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringMachine))
                {
                    return (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterStringMachine.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Model
        private void FilterCollectionModel()
        {
            if (_CollectionModel != null)
            {
                _CollectionModel.Refresh();
            }
        }
        public string FilterStringModel
        {
            get { return _filterStringModel; }
            set
            {
                _filterStringModel = value;
                RaisePropertyChanged("FilterStringModel");
                FilterCollectionModel();
            }
        }
        public bool FilterModel(object obj)
        {
            var data = obj as ZADM_M009_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringModel))
                {
                    return (data.modelno != null && data.modelno.ToString().ToLower().Contains(_filterStringModel.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Product
        private void FilterCollectionProduct()
        {
            if (_CollectionProduct != null)
            {
                _CollectionProduct.Refresh();
            }
        }
        public string FilterStringProduct
        {
            get { return _filterStringProduct; }
            set
            {
                _filterStringProduct = value;
                RaisePropertyChanged("FilterStringProduct");
                FilterCollectionProduct();
            }
        }
        public bool FilterProduct(object obj)
        {
            var data = obj as ADM_M022_P_ESSEM;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringProduct))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterStringProduct.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For BallDia
        private void FilterCollectionBallDia()
        {
            if (_CollectionBallDia != null)
            {
                _CollectionBallDia.Refresh();
            }
        }
        public string FilterStringBallDia
        {
            get { return _filterStringBallDia; }
            set
            {
                _filterStringBallDia = value;
                RaisePropertyChanged("FilterStringBallDia");
                FilterCollectionBallDia();
            }
        }
        public bool FilterBallDia(object obj)
        {
            var data = obj as ZADM_M001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringBallDia))
                {
                    return (data.Ball_dia != null && data.Ball_dia.ToString().ToLower().Contains(_filterStringBallDia.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For BallMake
        private void FilterCollectionBallMake()
        {
            if (_CollectionBallMake != null)
            {
                _CollectionBallMake.Refresh();
            }
        }
        public string FilterStringBallMake
        {
            get { return _filterStringBallMake; }
            set
            {
                _filterStringBallMake = value;
                RaisePropertyChanged("FilterStringBallMake");
                FilterCollectionBallMake();
            }
        }
        public bool FilterBallMake(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringBallMake))
                {
                    return (data.Make != null && data.Make.ToString().ToLower().Contains(_filterStringBallMake.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For WireMake
        private void FilterCollectionWireMake()
        {
            if (_CollectionWireMake != null)
            {
                _CollectionWireMake.Refresh();
            }
        }
        public string FilterStringWireMake
        {
            get { return _filterStringWireMake; }
            set
            {
                _filterStringWireMake = value;
                RaisePropertyChanged("FilterStringWireMake");
                FilterCollectionWireMake();
            }
        }
        public bool FilterWireMake(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringWireMake))
                {
                    return (data.Make != null && data.Make.ToString().ToLower().Contains(_filterStringWireMake.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For BallType
        private void FilterCollectionBallType()
        {
            if (_CollectionBallType != null)
            {
                _CollectionBallType.Refresh();
            }
        }
        public string FilterStringBallType
        {
            get { return _filterStringBallType; }
            set
            {
                _filterStringBallType = value;
                RaisePropertyChanged("FilterStringBallType");
                FilterCollectionBallType();
            }
        }
        public bool FilterBallType(object obj)
        {
            var data = obj as ZADM_M002_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringBallType))
                {
                    return (data.ball_type != null && data.ball_type.ToString().ToLower().Contains(_filterStringBallType.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For INK
        private void FilterCollectionINK()
        {
            if (_CollectionINK != null)
            {
                _CollectionINK.Refresh();
            }
        }
        public string FilterStringINK
        {
            get { return _filterStringINK; }
            set
            {
                _filterStringINK = value;
                RaisePropertyChanged("FilterStringINK");
                FilterCollectionINK();
            }
        }
        public bool FilterINK(object obj)
        {
            var data = obj as ZADM_M006_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringINK))
                {
                    return (data.ink != null && data.ink.ToString().ToLower().Contains(_filterStringINK.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For ILD
        private void FilterCollectionILD()
        {
            if (_CollectionILD != null)
            {
                _CollectionILD.Refresh();
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
        public bool FilterILD(object obj)
        {
            var data = obj as ZADM_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringILD))
                {
                    return (data.ild != null && data.ild.ToString().ToLower().Contains(_filterStringILD.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For SalesOrder
        private void FilterCollectionSalesOrder()
        {
            if (_CollectionSalesOrder != null)
            {
                _CollectionSalesOrder.Refresh();
            }
        }
        public string FilterStringSalesOrder
        {
            get { return _filterStringSalesOrder; }
            set
            {
                _filterStringSalesOrder = value;
                RaisePropertyChanged("FilterStringSalesOrder");
                FilterCollectionSalesOrder();
            }
        }
        public bool FilterSalesOrder(object obj)
        {
            var data = obj as SEL_T001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringSalesOrder))
                {
                    return (data.sono != null && data.sono.ToString().ToLower().Contains(_filterStringSalesOrder.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Customer
        private void FilterCollectionCustomer()
        {
            if (_CollectionCustomer != null)
            {
                _CollectionCustomer.Refresh();
            }
        }
        public string FilterStringCustomer
        {
            get { return _filterStringCustomer; }
            set
            {
                _filterStringCustomer = value;
                RaisePropertyChanged("FilterStringCustomer");
                FilterCollectionCustomer();
            }
        }
        public bool FilterCustomer(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringCustomer))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterStringCustomer.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region "Filter for Back Content Datagrid"
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
            var data = obj as EPR_T001;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    //return (data.ref_doc != null && data.ref_doc.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    //        (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    //        (data.post_date != null && data.post_date.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    //        (data.PlantName != null && data.PlantName.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    //        (data.mov_tp != null && data.mov_tp.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    //        (data.Dept_Name != null && data.Dept_Name.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    //        (data.notes != null && data.notes.ToString().ToLower().Contains(_filterString.ToLower())) ||
                    //        (data.Req_Name != null && data.Req_Name.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }
        #region Pkg Unit

        private string _filterString_PkgUnit;
        public string FilterString_PkgUnit
        {
            get { return _filterString_PkgUnit; }
            set
            {
                _filterString_PkgUnit = value;
                RaisePropertyChanged("FilterString_PkgUnit");
                FilterCollection_PkgUnit();
            }
        }
        private void FilterCollection_PkgUnit()
        {
            if (_PkgUnitCollection != null)
            {
                _PkgUnitCollection.Refresh();
            }
        }
        public bool Filter_PkgUnit(object obj)
        {
            var data = obj as ZADM_M017_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_PkgUnit))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_PkgUnit.ToLower()) ||
                        data.pkgunit != null && data.pkgunit.ToString().ToLower().Contains(_filterString_PkgUnit.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion
        #endregion



        private bool ValidateControls()
        {
            int cnt = 0;
            try
            {
                if (GoodsDetails.Count > 0)
                {
                    foreach (var item in GoodsDetails)
                    {
                        if (item.Select == true)
                        {
                            cnt = cnt + 1;
                        }
                    }
                    if (cnt == 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private bool ValidateControls123()
        {
            int cnt = 0;
            try
            {
                if (GoodsDetails.Count > 0)
                {
                    foreach (var item in GoodsDetails)
                    {
                        if (item.Select == true)
                        {
                            if (item.shift == null || item.shift == "" || item.ball_make == null || item.ball_make == "" || item.wire_make == null || item.wire_make == "")
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Shift,Wire Make,Ball Make Should be Compalsary.", this.Title);
                                showMessageService.ShowMessage();
                                cnt = cnt + 1;
                                break;
                            }
                        }


                    }
                    if (cnt == 0)
                    {
                        return false;

                    }
                    else
                    {
                        return true;

                    }

                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


    }
}
