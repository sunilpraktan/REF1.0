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
using Reflection.ReportingServices;
using Reflection.BusinessEntity.Admin;

namespace Reflection.Modules.Production.ViewModels
{
    public class EPR_T002VM : WorkspaceViewModel<EPR_T002>
    {
        #region Variable Declaration
        bool isNewRecord = true;
        bool Flag = false;
        WebServiceRepository<List<EPR_T002>> repository = new WebServiceRepository<List<EPR_T002>>();
        WebServiceRepository<MultipleContext_EPR_T002> repositoryM = new WebServiceRepository<MultipleContext_EPR_T002>();

        ObjectSerializationService obj = new ObjectSerializationService();

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        private MultipleContext_EPR_T002 _MC = new MultipleContext_EPR_T002();     // Need for Load Initial Data
        public MultipleContext_EPR_T002 MC
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

        private MultipleContext_EPR_T002 _MCTemp = new MultipleContext_EPR_T002();   // For Loading Ild Chart
        public MultipleContext_EPR_T002 MCTemp
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

        private MultipleContext_EPR_T002 _MCTemp2 = new MultipleContext_EPR_T002();    // Loading BackFlip Data and Report
        public MultipleContext_EPR_T002 MCTemp2
        {
            get { return _MCTemp2; }
            set
            {
                if (_MCTemp2 != value)
                {
                    _MCTemp2 = value; RaisePropertyChanged("MCTemp2");
                }
            }
        }

        private ObservableCollection<EPR_T002> _MasterEntity;
        //Data source for Items DataGrid
        public ObservableCollection<EPR_T002> MasterEntity
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

        private List<EPR_T002> _TobeSaveEntity = new List<EPR_T002>();
        //Data source for Items DataGrid
        public List<EPR_T002> TobeSaveEntity
        {
            get
            {
                return _TobeSaveEntity;
            }
            set
            {
                if (_TobeSaveEntity != value)
                {
                    _TobeSaveEntity = value;
                    RaisePropertyChanged("TobeSaveEntity");
                }
            }
        }

        // This Object is Used for backflip Searching
        private EPR_T002 _SelectedEPR_T002;
        public EPR_T002 SelectedEPR_T002
        {
            get
            {
                return _SelectedEPR_T002;
            }
            set
            {
                if (_SelectedEPR_T002 != value)
                {
                    _SelectedEPR_T002 = value;
                    RaisePropertyChanged("SelectedEPR_T002");
                }
            }
        }

        private ObservableCollection<EPR_T002> _BackFlipEntity;
        //Data source for Items DataGrid
        public ObservableCollection<EPR_T002> BackFlipEntity
        {
            get
            {
                return _BackFlipEntity;
            }
            set
            {
                if (_BackFlipEntity != value)
                {
                    _BackFlipEntity = value;
                    RaisePropertyChanged("BackFlipEntity");
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

        private DateTime? _Date;
        public DateTime? Date
        {
            get
            {
                return _Date;
            }
            set
            {
                if (_Date != value)
                {
                    _Date = value;
                    RaisePropertyChanged("Date");
                }
            }
        }

        private int _pack_style;
        public int pack_style
        {
            get
            {
                return _pack_style;
            }
            set
            {
                if (_pack_style != value)
                {
                    _pack_style = value;
                    RaisePropertyChanged("pack_style");
                }
            }
        }

        private string _PackingUnit;
        public string PackingUnit
        {
            get
            {
                return _PackingUnit;
            }
            set
            {
                if (_PackingUnit != value)
                {
                    _PackingUnit = value;
                    RaisePropertyChanged("PackingUnit");
                }
            }
        }

        private string _machinecode;
        public string machinecode
        {
            get
            {
                return _machinecode;
            }
            set
            {
                if (_machinecode != value)
                {
                    _machinecode = value;
                    RaisePropertyChanged("machinecode");
                }
            }
        }
        private string _Unit;
        public string Unit
        {
            get
            {
                return _Unit;
            }
            set
            {
                if (_Unit != value)
                {
                    _Unit = value;
                    RaisePropertyChanged("Unit");
                }
            }
        }

        private List<ADM_M042_P> _Shift;
        public List<ADM_M042_P> Shift
        {
            get
            {
                return _Shift;
            }
            set
            {
                if (_Shift != value)
                {
                    _Shift = value;                    
                }
            }
        }

        private string _PrintOption;
        public string PrintOption
        {
            get
            {
                return _PrintOption;
            }
            set
            {
                if (_PrintOption != value)
                {
                    _PrintOption = value;
                    RaisePropertyChanged("PrintOption");
                }
            }
        }

        private string _LabelStatus;
        public string LabelStatus
        {
            get
            {
                return _LabelStatus;
            }
            set
            {
                if (_LabelStatus != value)
                {
                    _LabelStatus = value;
                    RaisePropertyChanged("LabelStatus");
                }
            }
        }

        #endregion

        #region ICollection for Popup Control

        private ICollectionView _UnitCollection;
        public ICollectionView UnitCollection
        {
            get { return _UnitCollection; }
            set
            {
                _UnitCollection = value;
                RaisePropertyChanged("UnitCollection");
            }
        }

        private ICollectionView _PackingUnitCollection;
        public ICollectionView PackingUnitCollection
        {
            get { return _PackingUnitCollection; }
            set
            {
                _PackingUnitCollection = value;
                RaisePropertyChanged("PackingUnitCollection");
            }
        }

        private ICollectionView _InkCollection;
        public ICollectionView InkCollection
        {
            get { return _InkCollection; }
            set
            {
                _InkCollection = value;
                RaisePropertyChanged("InkCollection");
            }
        }

        private ICollectionView _IldCollection;
        public ICollectionView IldCollection
        {
            get { return _IldCollection; }
            set
            {
                _IldCollection = value;
                RaisePropertyChanged("IldCollection");
            }
        }

        private ICollectionView _PkgUnitCollection;
        public ICollectionView PkgUnitCollection
        {
            get { return _PkgUnitCollection; }
            set
            {
                _PkgUnitCollection = value;
                RaisePropertyChanged("PkgUnitCollection");
            }
        }

        private ICollectionView _CustomerProductCollection;
        public ICollectionView CustomerProductCollection
        {
            get { return _CustomerProductCollection; }
            set
            {
                _CustomerProductCollection = value;
                RaisePropertyChanged("CustomerProductCollection");
            }
        }

        private ICollectionView _BallMakeCollection;
        public ICollectionView BallMakeCollection
        {
            get { return _BallMakeCollection; }
            set
            {
                _BallMakeCollection = value;
                RaisePropertyChanged("BallMakeCollection");
            }
        }

        private ICollectionView _WireMakeCollection;
        public ICollectionView WireMakeCollection
        {
            get { return _WireMakeCollection; }
            set
            {
                _WireMakeCollection = value;
                RaisePropertyChanged("WireMakeCollection");
            }
        }

        private ICollectionView _ShiftCollection;
        public ICollectionView ShiftCollection
        {
            get { return _ShiftCollection; }
            set
            {
                _ShiftCollection = value;
                RaisePropertyChanged("ShiftCollection");
            }
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
        private ICollectionView _GradeCollection2;
        public ICollectionView GradeCollection2
        {
            get { return _GradeCollection2; }
            set
            {
                _GradeCollection2 = value;
                RaisePropertyChanged("GradeCollection2");
            }
        }

        private ICollectionView _MachineCollection;
        public ICollectionView MachineCollection
        {
            get { return _MachineCollection; }
            set
            {
                _MachineCollection = value;
                RaisePropertyChanged("MachineCollection");
            }
        }

        private ICollectionView _BPkgUnitCollection;
        public ICollectionView BPkgUnitCollection
        {
            get { return _BPkgUnitCollection; }
            set
            {
                _BPkgUnitCollection = value;
                RaisePropertyChanged("BPkgUnitCollection");
            }
        }

        private ICollectionView _ItemCollection;
        public ICollectionView ItemCollection
        {
            get { return _ItemCollection; }
            set
            {
                _ItemCollection = value;
                RaisePropertyChanged("ItemCollection");
            }
        }

        private ICollectionView _BInkCollection;
        public ICollectionView BInkCollection
        {
            get { return _BInkCollection; }
            set
            {
                _BInkCollection = value;
                RaisePropertyChanged("BInkCollection");
            }
        }

        private ICollectionView _BIldCollection;
        public ICollectionView BIldCollection
        {
            get { return _BIldCollection; }
            set
            {
                _BIldCollection = value;
                RaisePropertyChanged("BIldCollection");
            }
        }

        private ICollectionView _BackFlipCollection;
        public ICollectionView BackFlipCollection
        {
            get { return _BackFlipCollection; }
            set
            {
                _BackFlipCollection = value;
                RaisePropertyChanged("BackFlipCollection");
            }
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

        private ICollectionView _MachineOperatorCollection;
        public ICollectionView MachineOperatorCollection
        {
            get { return _MachineOperatorCollection; }
            set
            {
                _MachineOperatorCollection = value;
                RaisePropertyChanged("MachineOperatorCollection");
            }
        }

        private ICollectionView _ItemCollection2;
        public ICollectionView ItemCollection2
        {
            get { return _ItemCollection2; }
            set
            {
                _ItemCollection2 = value;
                RaisePropertyChanged("ItemCollection2");
            }
        }
        private ICollectionView _ItemCollection3;
        public ICollectionView ItemCollection3
        {
            get { return _ItemCollection3; }
            set
            {
                _ItemCollection3 = value;
                RaisePropertyChanged("ItemCollection3");
            }
        }

        private ICollectionView _MachineCollection2;
        public ICollectionView MachineCollection2
        {
            get { return _MachineCollection2; }
            set
            {
                _MachineCollection2 = value;
                RaisePropertyChanged("MachineCollection2");
            }
        }
        private ICollectionView _MachineMasterCollection;
        public ICollectionView MachineMasterCollection
        {
            get { return _MachineMasterCollection; }
            set
            {
                _MachineMasterCollection = value;
                RaisePropertyChanged("MachineMasterCollection");
            }
        }

        private ICollectionView _BreakdownReasonCollection;
        public ICollectionView BreakdownReasonCollection
        {
            get { return _BreakdownReasonCollection; }
            set
            {
                _BreakdownReasonCollection = value;
                RaisePropertyChanged("BreakdownReasonCollection");
            }
        }

        private ICollectionView _ShiftInchargeCollection;
        public ICollectionView ShiftInchargeCollection
        {
            get { return _ShiftInchargeCollection; }
            set
            {
                _ShiftInchargeCollection = value;
                RaisePropertyChanged("ShiftInchargeCollection");
            }
        }

        private ICollectionView _PDIDupBarcode;
        public ICollectionView PDIDupBarcode
        {
            get { return _PDIDupBarcode; }
            set
            {
                _PDIDupBarcode = value;
                RaisePropertyChanged("PDIDupBarcode");
            }
        }
        
        #endregion

        #region StringList Variables

        private List<string> _stringListUOM;
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

        private List<string> _stringListPkgUOM;
        public List<string> StringListPkgUOM
        {
            get { return _stringListPkgUOM; }
            set
            {
                if (_stringListPkgUOM != value)
                {
                    _stringListPkgUOM = value;
                }
            }
        }

        private List<string> _stringListInk;
        public List<string> StringListInk
        {
            get { return _stringListInk; }
            set
            {
                if (_stringListInk != value)
                {
                    _stringListInk = value;
                }
            }
        }

        private List<string> _stringListIld;
        public List<string> StringListIld
        {
            get { return _stringListIld; }
            set
            {
                if (_stringListIld != value)
                {
                    _stringListIld = value;
                }
            }
        }

        private List<string> _stringListWireMake;
        public List<string> StringListWireMake
        {
            get { return _stringListWireMake; }
            set
            {
                if (_stringListWireMake != value)
                {
                    _stringListWireMake = value;
                }
            }
        }

        private List<string> _stringListBallMake;
        public List<string> StringListBallMake
        {
            get { return _stringListBallMake; }
            set
            {
                if (_stringListBallMake != value)
                {
                    _stringListBallMake = value;
                }
            }
        }

        private List<string> _stringListCustProd;
        public List<string> StringListCustProd
        {
            get { return _stringListCustProd; }
            set
            {
                if (_stringListCustProd != value)
                {
                    _stringListCustProd = value;
                }
            }
        }

        private List<string> _stringListParty;
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

        private List<string> _stringListOperator;
        public List<string> StringListOperator
        {
            get { return _stringListOperator; }
            set
            {
                if (_stringListOperator != value)
                {
                    _stringListOperator = value;
                }
            }
        }

        private List<string> _stringListSIncharge;
        public List<string> StringListSIncharge
        {
            get { return _stringListSIncharge; }
            set
            {
                if (_stringListSIncharge != value)
                {
                    _stringListSIncharge = value;
                }
            }
        }

        private List<string> _stringListMachine;
        public List<string> StringListMachine
        {
            get { return _stringListMachine; }
            set
            {
                if (_stringListMachine != value)
                {
                    _stringListMachine = value;
                }
            }
        }
        private List<string> _stringListMachineMaster;
        public List<string> StringListMachineMaster
        {
            get { return _stringListMachineMaster; }
            set
            {
                if (_stringListMachineMaster != value)
                {
                    _stringListMachineMaster = value;
                }
            }
        }

        private List<string> _stringListProduct;
        public List<string> StringListProduct
        {
            get { return _stringListProduct; }
            set
            {
                if (_stringListProduct != value)
                {
                    _stringListProduct = value;
                }
            }
        }

        private List<string> _stringListPDIDupBarcode;
        public List<string> StringListPDIDupBarcode
        {
            get { return _stringListPDIDupBarcode; }
            set
            {
                if (_stringListPDIDupBarcode != value)
                {
                    _stringListPDIDupBarcode = value;
                }
            }
        }
        
        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdMultipleSelect { get; private set; }
        public RelayCommand<object> CommandPackingUnit { get; private set; }
        public RelayCommand CommandLoadIldDetails { get; private set; }
        public RelayCommand<object> CommandUnit { get; private set; }
        public RelayCommand<object> CommandPkgUnit { get; private set; }
        public RelayCommand<object> CommandCustomerProduct { get; private set; }
        public RelayCommand<object> CommandInk { get; private set; }
        public RelayCommand<object> CommandIld { get; private set; }
        public RelayCommand<object> CommandBallMake { get; private set; }
        public RelayCommand<object> CommandWireMake { get; private set; }
        public RelayCommand<object> cmdParty { get; private set; }
        public RelayCommand<object> cmdMachineOperator { get; private set; }
        public RelayCommand<object> cmdShiftIncharge { get; private set; }
        public RelayCommand<object> cmdCopyAndPaste { get; private set; }
        public RelayCommand<object> CommandMachine2 { get; private set; }
        public RelayCommand<object> CommandInsertItem { get; private set; }
        public RelayCommand<object> CommandPDIDupBarcode { get; private set; }
        public RelayCommand<IList> CommandMachineMaster { get; private set; }
        public RelayCommand<IList> CmdInsertItem { get; private set; }

        // BackFlip
        public RelayCommand<IList> CommandMachine { get; private set; }
        public RelayCommand<IList> CommandBPkgUnit { get; private set; }
        public RelayCommand<IList> CommandItem { get; private set; }
        public RelayCommand<IList> CommandBInk { get; private set; }
        public RelayCommand<IList> CommandBIld { get; private set; }
        public RelayCommand CommandLoadLabelGenration { get; private set; }
        public RelayCommand CommandPrint2 { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        
        #endregion

        #region Constructor
        public EPR_T002VM(string ts_code): base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new ObservableCollection<EPR_T002>();
            SelectedEPR_T002 = new EPR_T002();
            MC = new MultipleContext_EPR_T002();
            MCTemp = new MultipleContext_EPR_T002();
            MCTemp2 = new MultipleContext_EPR_T002();
            PrintOption = "All";
            LabelStatus = "Unused";
          
            Date = DateTime.Now;
            SelectedEPR_T002.prod_dt = DateTime.Now;
            SelectedEPR_T002.client = AppSessionState.client;
            SelectedEPR_T002.record_type = "01";
            SelectedEPR_T002.user_source1 = AppSessionState.UserSource1;
            SelectedEPR_T002.user_source2 = AppSessionState.UserSource2;
            SelectedEPR_T002.userid = AppSessionState.UserID;
            //SelectedEPR_T002.from_date = DateTime.Now;
            //SelectedEPR_T002.to_date = DateTime.Now;
            EPR_T002.ModelEntityUpdated += new EventHandler(ModelUpdated_Calculation);

            LoadInitialData();
        }
        public EPR_T002VM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new ObservableCollection<EPR_T002>();
            SelectedEPR_T002 = new EPR_T002();
            MC = new MultipleContext_EPR_T002();
            MCTemp = new MultipleContext_EPR_T002();
            MCTemp2 = new MultipleContext_EPR_T002();
            PrintOption = "All";
            LabelStatus = "Unused";
            Date = DateTime.Now;
            SelectedEPR_T002.prod_dt = DateTime.Now;
            SelectedEPR_T002.from_date = DateTime.Now;
            SelectedEPR_T002.to_date = DateTime.Now;
            SelectedEPR_T002.client = AppSessionState.client;
            SelectedEPR_T002.record_type = "01";
            SelectedEPR_T002.user_source1 = AppSessionState.UserSource1;
            SelectedEPR_T002.user_source2 = AppSessionState.UserSource2;
            SelectedEPR_T002.userid = AppSessionState.UserID;
            EPR_T002.ModelEntityUpdated += new EventHandler(ModelUpdated_Calculation);

            LoadInitialData();
        }
        #endregion

        #region UserDefinedFunctions

        private void LoadInitialData()
        {
            string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + "LG";
            MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T002> (MC, Request, "LabelGenerationMaster", "Production", "LoadAll", 0, "");

            #region Command Initialisation

            CommandInsertItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertDataGridRow_Item(items, true, true, true); });
            CommandMachine2 = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertMachineCode(cmdPara, false, true, true); });


            cmdMultipleSelect = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } MultipleSelect(cmdPara); });
            CommandPackingUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPackingUnit(cmdPara); });
            CommandInk = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertInk(cmdPara, false, true, true); });
            CommandIld = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertIld(cmdPara, false, true, true); });

            CommandLoadIldDetails = new RelayCommand(() => { LoadIldDetails(); });
            CommandUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOM(cmdPara, false, true, true); });
            CommandPkgUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPkgUOM(cmdPara, false, true, true); });
            CommandCustomerProduct = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCustomerProduct(cmdPara, false, true, true); });
            CommandBallMake = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBallMake(cmdPara, false, true, true); });
            CommandWireMake = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWireMake(cmdPara, false, true, true); });
            cmdParty = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertParty(cmdPara, false, true, true); });
            cmdMachineOperator = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertMachineOperator(cmdPara, false, true, true); });
            cmdShiftIncharge = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertShiftIncharge(cmdPara, false, true, true); });
            cmdCopyAndPaste = new RelayCommand<object>(items => { if (items == null) { return; } InsertRow_CopyPaste(items); });
            CommandPDIDupBarcode = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPDIBarcode(cmdPara, false, true, true); });
            CommandMachineMaster = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertMachineMaster(cmdPara); });
            CmdInsertItem = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertItemMaster(cmdPara); });
            //BackFlip
            CommandLoadLabelGenration = new RelayCommand(() => { LoadLabelGenerationDetails(); });
            CommandMachine = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertMachine(cmdPara); });
            CommandBPkgUnit = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertBPkgUnit(cmdPara); });
            CommandItem = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara); });
            CommandBInk = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertBInk(cmdPara); });
            CommandBIld = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertBIld(cmdPara); });


            CommandPrint2 = new RelayCommand(() => { Print2(); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

            
            

            #endregion
            UnitCollection = CollectionViewSource.GetDefaultView(MC.UnitList);
            UnitCollection.Filter = new Predicate<object>(Filter_Unit);
            StringListUOM = MC.UnitList.Select(x => x.unit_code).ToList();

            PackingUnitCollection = CollectionViewSource.GetDefaultView(MC.PkgUnitList);

            PkgUnitCollection = CollectionViewSource.GetDefaultView(MC.PkgUnitList);
            PkgUnitCollection.Filter = new Predicate<object>(Filter_PkgUnit);
            StringListPkgUOM = MC.PkgUnitList.Select(x => x.pkgunit).ToList();

            CustomerProductCollection = CollectionViewSource.GetDefaultView(MC.CustomerProductList);
            CustomerProductCollection.Filter = new Predicate<object>(Filter_CustProduct);
            StringListCustProd = MC.CustomerProductList.Select(x => x.CustomerProductName).ToList();

            InkCollection = CollectionViewSource.GetDefaultView(MC.InkList);
            InkCollection.Filter = new Predicate<object>(Filter_Ink);
            StringListInk = MC.InkList.Select(x => x.ink).ToList();

            IldCollection = CollectionViewSource.GetDefaultView(MC.IldList);
            IldCollection.Filter = new Predicate<object>(Filter_Ild);
            StringListIld = MC.IldList.Select(x => x.ild).ToList();

            BallMakeCollection = CollectionViewSource.GetDefaultView(MC.BallMakeList);
            BallMakeCollection.Filter = new Predicate<object>(Filter_BallMake);
            StringListBallMake = MC.BallMakeList.Select(x => x.Make).ToList();

            WireMakeCollection = CollectionViewSource.GetDefaultView(MC.WireMakeList);
            WireMakeCollection.Filter = new Predicate<object>(Filter_WireMake);
            StringListWireMake = MC.WireMakeList.Select(x => x.Make).ToList();

            Shift = (from o in MC.ShiftList where o.shift != "All" select o).ToList();
            ShiftCollection = CollectionViewSource.GetDefaultView(Shift);

            BShiftCollection = CollectionViewSource.GetDefaultView(MC.ShiftList);

            GradeCollection2 = CollectionViewSource.GetDefaultView(MC.GradeList);

            MachineCollection = CollectionViewSource.GetDefaultView(MC.MachineList);
            MachineCollection.Filter = new Predicate<object>(Filter_Machine);

            BPkgUnitCollection = CollectionViewSource.GetDefaultView(MC.BPkgUnitList);
            BPkgUnitCollection.Filter = new Predicate<object>(Filter_BPkgUnit);

            ItemCollection = CollectionViewSource.GetDefaultView(MC.ItemList);
            ItemCollection.Filter = new Predicate<object>(Filter_ItemCode);

            BInkCollection = CollectionViewSource.GetDefaultView(MC.BInkList);
            BInkCollection.Filter = new Predicate<object>(BFilter_Ink);

            BIldCollection = CollectionViewSource.GetDefaultView(MC.BIldList);
            BIldCollection.Filter = new Predicate<object>(BFilter_Ild);

            PartyCollection = CollectionViewSource.GetDefaultView(MC.PartyList);
            PartyCollection.Filter = new Predicate<object>(Filter_Party);

            MachineOperatorCollection = CollectionViewSource.GetDefaultView(MC.EmployeeList);
            MachineOperatorCollection.Filter = new Predicate<object>(Filter_MachineOperator);
            StringListOperator = MC.EmployeeList.Select(x => x.EmpId).ToList();

            MachineCollection2 = CollectionViewSource.GetDefaultView(MC.MachineList2);
            MachineCollection2.Filter = new Predicate<object>(Filter_Machine2);
            StringListMachine = MC.MachineList2.Select(x => x.machinecode).ToList();

            ItemCollection2 = CollectionViewSource.GetDefaultView(MC.ItemList2);
            ItemCollection2.Filter = new Predicate<object>(Filter_ItemCode2);
            StringListProduct = MC.ItemList2.Select(x => x.ItemCode).ToList();

            ShiftInchargeCollection = CollectionViewSource.GetDefaultView(MC.SInchargeList);
            ShiftInchargeCollection.Filter = new Predicate<object>(Filter_ShiftIncharge);
            StringListSIncharge = MC.SInchargeList.Select(x => x.EmpId).ToList();

            PDIDupBarcode = CollectionViewSource.GetDefaultView(MC.PDIDupBarcodeList);
            StringListPDIDupBarcode = MC.PDIDupBarcodeList.Select(x => x.barcode_no).ToList();

            ItemCollection3 = CollectionViewSource.GetDefaultView(MC.ItemList2);
            ItemCollection3.Filter = new Predicate<object>(Filter_Item);

            MachineMasterCollection = CollectionViewSource.GetDefaultView(MC.MachineListMaster);
            MachineMasterCollection.Filter = new Predicate<object>(Filter_Machine2);
            StringListMachineMaster = MC.MachineListMaster.Select(x => x.machinecode).ToList();
        }
        private void InsertPackingUnit(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M017_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PkgUnitList.Where(x => x.pkgunit.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M017_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    pack_style = POPUPEntityObject.id;
                    PackingUnit = POPUPEntityObject.pkgunit;
                    Unit = POPUPEntityObject.unit_code;
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
        
        private void MultipleSelect(object InputValue)
        {
            try
            {
                if (MasterEntity.Count > 0)
                {
                    foreach (var item in MasterEntity)
                    {
                        item.auto_sort = true;
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
        private void InsertMachineMaster(IList InputValue)
        {
            try
            {
                int stringmachine_id = 0;
                string stringmachinecode = "";
                SelectedEPR_T002.machinecode = "";
               
                foreach (ZADM_M013_P temp in MC.MachineListMaster)
                {
                    if (temp.Select == true)
                    {
                        //stringmachine_id = stringmachine_id + "," + temp.machine_id;
                        stringmachinecode = stringmachinecode + "," + temp.machinecode;
                    }
                }
                //SelectedEPR_T002.machine_id = stringmachine_id.TrimStart(new char[] { ',' });
                SelectedEPR_T002.machinecode = stringmachinecode.ToString().TrimStart(new char[] { ',' });

                //IList list = InputValue as IList;
                //List<ZADM_M013_P> GetSelectedMachine = list.Cast<ZADM_M013_P>().ToList();

                //if (GetSelectedMachine.Count > 0)
                //{
                //    SelectedEPR_T002.machine_id = GetSelectedMachine[0].machine_id;
                //    SelectedEPR_T002.machinecode = GetSelectedMachine[0].machinecode;
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
        private void InsertItemMaster(IList InputValue)
        {
            try
            {
                string stringItemCode = "";
                string stringItemName = "";
                SelectedEPR_T002.ItemCode = "";

                foreach (ADM_M022_P temp in MC.ItemList2)
                {
                    if (temp.Select == true)
                    {
                        stringItemCode = stringItemCode + "," + temp.ItemCode;
                        stringItemName = stringItemName + "," + temp.ItemName;
                    }
                }
                SelectedEPR_T002.ItemCode = stringItemCode.TrimStart(new char[] { ',' });
                SelectedEPR_T002.ItemName = stringItemName.ToString().TrimStart(new char[] { ',' });

                //IList list = InputValue as IList;
                //List<ZADM_M013_P> GetSelectedMachine = list.Cast<ZADM_M013_P>().ToList();

                //if (GetSelectedMachine.Count > 0)
                //{
                //    SelectedEPR_T002.machine_id = GetSelectedMachine[0].machine_id;
                //    SelectedEPR_T002.machinecode = GetSelectedMachine[0].machinecode;
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
        private void LoadIldDetails()
        {
            try
            {
                if (Date == null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.OkCancel;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select production date ", this.Title);
                    showMessageService.ShowMessage();
                }
                else
                {
                    //CultureInfo currentCulture = Thread.CurrentThread.CurrentCulture;
                    //System.Globalization.CultureInfo cultureinfo = new System.Globalization.CultureInfo("en-US");
                    //DateTime dt = DateTime.Parse(Date.Value.ToString(), cultureinfo);

                    string Request = "LoadIldDetails" + "!@" + Convert.ToDateTime(Date).ToString("MM/dd/yyyy") + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + SelectedEPR_T002.machinecode + "!@" + SelectedEPR_T002.ItemCode;
                    //string Request = "LoadIldDetails" + "!@" + Date.ToString() + "!@" + AppSessionState.location_Id;
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T002>(MCTemp, Request, "LabelGenerationMaster", "Production", "LoadAll", 0, "");

                    foreach (var o in MCTemp.LabelGenerationFromILD)
                    {
                        int IndexOfExistRow = MasterEntity.IndexOf(MasterEntity.Where(X => X.shift == o.shift && X.ItemCode == o.ItemCode
                                                && X.ink_id == o.ink_id && X.ild_id == o.ild_id && X.wire_make == o.wire_make && X.ball_make
                                                == o.ball_make && X.machine_id == o.machine_id && X.active == true && X.prod_dt == Date && X.conversion==o.conversion).FirstOrDefault());

                        if (IndexOfExistRow == -1)
                        {
                            o.entry_dt = DateTime.Now;
                            o.add_by = AppSessionState.UserID;
                            o.editby = AppSessionState.UserID;
                            o.location_Id = AppSessionState.location_Id;
                            o.comp_code = AppSessionState.comp_code;
                            o.client = AppSessionState.client;
                            o.ts_code = ts_code_vm;
                            o.doc_cat = "LG";
                            o.doc_type = "LG";
                            o.active = true;
                            o.prod_dt = Date;
                            //o.pack_style = pack_style;
                            //o.PackingUnit = PackingUnit;
                            //o.unit_code = Unit;

                            MasterEntity.Add(o);
                        }
                    }

                    foreach (var item in MC.MachineListMaster)
                    {
                        if(item.Select==true)
                        {
                            item.Select = false;
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
        private void InsertMachineCode(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

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
                        { POPUPEntityObject = MC.MachineList2.Where(x => x.machinecode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<ZADM_M013_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M013_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.machinecode == POPUPEntityObject.machinecode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.machinecode == POPUPEntityObject.machinecode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].machine_id = POPUPEntityObject.machine_id;
                            MasterEntity[dgSelectedIndex].machinecode = POPUPEntityObject.machinecode;
                        }
                        else if (MasterEntity[dgSelectedIndex].machine_id != POPUPEntityObject.machine_id)
                        {
                            MasterEntity[dgSelectedIndex].machine_id = POPUPEntityObject.machine_id;
                            MasterEntity[dgSelectedIndex].machinecode = POPUPEntityObject.machinecode;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
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
                        { POPUPEntityObject = MC.UnitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (MasterEntity[dgSelectedIndex].unit_code != POPUPEntityObject.unit_code)
                        {
                            MasterEntity[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
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
        private void InsertPkgUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                ZADM_M017_P POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.PkgUnitList.Where(x => x.pkgunit.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<ZADM_M017_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M017_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.pack_style == POPUPEntityObject.id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.pack_style == POPUPEntityObject.id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].pack_style = POPUPEntityObject.id;
                            MasterEntity[dgSelectedIndex].PackingUnit = POPUPEntityObject.pkgunit;
                            MasterEntity[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (MasterEntity[dgSelectedIndex].id != POPUPEntityObject.id)
                        {
                            MasterEntity[dgSelectedIndex].pack_style = POPUPEntityObject.id;
                            MasterEntity[dgSelectedIndex].PackingUnit = POPUPEntityObject.pkgunit;
                            MasterEntity[dgSelectedIndex].unit_code = POPUPEntityObject.unit_code;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
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
        private void InsertParty(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.PartyList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.PartyId == POPUPEntityObject.PartyId).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.PartyId == POPUPEntityObject.PartyId).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].PartyId = POPUPEntityObject.PartyId;
                            MasterEntity[dgSelectedIndex].PartyNm = POPUPEntityObject.PartyNm;
                        }
                        else if (MasterEntity[dgSelectedIndex].PartyId != POPUPEntityObject.PartyId)
                        {
                            MasterEntity[dgSelectedIndex].PartyId = POPUPEntityObject.PartyId;
                            MasterEntity[dgSelectedIndex].PartyNm = POPUPEntityObject.PartyNm;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
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
        private void InsertMachineOperator(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                ADM_M024_P POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.EmployeeList.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<ADM_M024_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.PartyId == POPUPEntityObject.PartyId).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.PartyId == POPUPEntityObject.PartyId).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].m_operator = POPUPEntityObject.EmpId;
                            MasterEntity[dgSelectedIndex].OperatorNm = POPUPEntityObject.EmpName;
                        }
                        else if (MasterEntity[dgSelectedIndex].m_operator != POPUPEntityObject.EmpId)
                        {
                            MasterEntity[dgSelectedIndex].m_operator = POPUPEntityObject.EmpId;
                            MasterEntity[dgSelectedIndex].OperatorNm = POPUPEntityObject.EmpName;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
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
        private void InsertShiftIncharge(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                ADM_M024_P POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.SInchargeList.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<ADM_M024_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.PartyId == POPUPEntityObject.PartyId).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.PartyId == POPUPEntityObject.PartyId).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].shift_incharge = POPUPEntityObject.EmpId;
                            MasterEntity[dgSelectedIndex].InchargeNm = POPUPEntityObject.EmpName;
                        }
                        else if (MasterEntity[dgSelectedIndex].m_operator != POPUPEntityObject.EmpId)
                        {
                            MasterEntity[dgSelectedIndex].shift_incharge = POPUPEntityObject.EmpId;
                            MasterEntity[dgSelectedIndex].InchargeNm = POPUPEntityObject.EmpName;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
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
        private void InsertCustomerProduct(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M020_P POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.CustomerProductList.Where(x => x.CustomerProductName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<ZADM_M020_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M020_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.CustomerProductName == POPUPEntityObject.CustomerProductName).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.CustomerProductName == POPUPEntityObject.CustomerProductName).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].CustomerProductName = POPUPEntityObject.CustomerProductName;
                            //scalar name to be mapped
                        }
                        else if (MasterEntity[dgSelectedIndex].id != POPUPEntityObject.id)
                        {
                            MasterEntity[dgSelectedIndex].CustomerProductName = POPUPEntityObject.CustomerProductName;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
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
        private void InsertPDIBarcode(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ECRM_T004_P POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.PDIDupBarcodeList.Where(x => x.barcode_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<ECRM_T004_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ECRM_T004_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.barcode == POPUPEntityObject.barcode_no).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.barcode == POPUPEntityObject.barcode_no).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].barcode = POPUPEntityObject.barcode_no;
                            //scalar name to be mapped
                        }
                        else if (MasterEntity[dgSelectedIndex].barcode != POPUPEntityObject.barcode_no)
                        {
                            MasterEntity[dgSelectedIndex].barcode = POPUPEntityObject.barcode_no;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
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
        private void InsertInk(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                ZADM_M006_P POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.InkList.Where(x => x.ink.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<ZADM_M006_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M006_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.ink_id == POPUPEntityObject.ink_id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.ink_id == POPUPEntityObject.ink_id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].ink_id = POPUPEntityObject.ink_id;
                            MasterEntity[dgSelectedIndex].Ink = POPUPEntityObject.ink;
                        }
                        else if (MasterEntity[dgSelectedIndex].Ink != POPUPEntityObject.ink)
                        {
                            MasterEntity[dgSelectedIndex].ink_id = POPUPEntityObject.ink_id;
                            MasterEntity[dgSelectedIndex].Ink = POPUPEntityObject.ink;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
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
        private void InsertIld(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

                string Request = "";
                ZADM_M007_P POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.IldList.Where(x => x.ild.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<ZADM_M007_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M007_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.ild_id == POPUPEntityObject.ild_id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.ild_id == POPUPEntityObject.ild_id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].ild_id = POPUPEntityObject.ild_id;
                            MasterEntity[dgSelectedIndex].Ild = POPUPEntityObject.ild;
                        }
                        else if (MasterEntity[dgSelectedIndex].Ild != POPUPEntityObject.ild)
                        {
                            MasterEntity[dgSelectedIndex].ild_id = POPUPEntityObject.ild_id;
                            MasterEntity[dgSelectedIndex].Ild = POPUPEntityObject.ild;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
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

        private void InsertBallMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

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
                        { POPUPEntityObject = MC.BallMakeList.Where(x => x.MakeCode.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<ADM_M032_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M032_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.ball_make == POPUPEntityObject.MakeCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.ball_make == POPUPEntityObject.MakeCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].ball_make = POPUPEntityObject.MakeCode;
                            MasterEntity[dgSelectedIndex].BallMake = POPUPEntityObject.Make;
                        }
                        else if (MasterEntity[dgSelectedIndex].id != POPUPEntityObject.MakeCode)
                        {
                            MasterEntity[dgSelectedIndex].ball_make = POPUPEntityObject.MakeCode;
                            MasterEntity[dgSelectedIndex].BallMake = POPUPEntityObject.Make;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
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
        private void InsertWireMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {

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
                        { POPUPEntityObject = MC.BallMakeList.Where(x => x.MakeCode.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (((IEnumerable)InputValue).Cast<ADM_M032_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M032_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.ball_make == POPUPEntityObject.MakeCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.ball_make == POPUPEntityObject.MakeCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            MasterEntity[dgSelectedIndex].wire_make = POPUPEntityObject.MakeCode;
                            MasterEntity[dgSelectedIndex].WireMake = POPUPEntityObject.Make;
                        }
                        else if (MasterEntity[dgSelectedIndex].id != POPUPEntityObject.MakeCode)
                        {
                            MasterEntity[dgSelectedIndex].wire_make = POPUPEntityObject.MakeCode;
                            MasterEntity[dgSelectedIndex].WireMake = POPUPEntityObject.Make;
                        }
                    }
                }
                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
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
        private bool Validations()
        {
            
            string Message = "";
            int flag = 0;
            foreach (var o in MasterEntity)
            {
                Message = "Following Fields Are Compulsory For All Checked Rows Please Check Row Index {0}";
                flag = 0;
                if (o.check == true)
                {
                    if (o.shift == null || o.shift == "")
                    {
                        Message += "\n =>Please select Shift ";
                        flag = 1;
                    }
                    if (o.machine_id == null || o.machine_id == 0)
                    {
                        Message += "\n =>Machine Cannot Be Blank or 0 ";
                        flag = 1;
                    }
                    if (o.ItemCode == null || o.ItemCode == "")
                    {
                        Message += "\n =>Product Cannot Be Null or Blank ";
                        flag = 1;
                    }
                    if (o.ink_id == null || o.ink_id == 0)
                    {
                        Message += "\n =>Ink Cannot Be Blank or 0 ";
                        flag = 1;
                    }
                    if (o.ild_id == null || o.ild_id == 0)
                    {
                        Message += "\n =>Ild Cannot Be Blank or 0 ";
                        flag = 1;
                    }
                    if (o.unit_code == null || o.unit_code == "")
                    {
                        Message += "\n =>Please select unit code ";
                        flag = 1;
                    }
                    if (o.pack_style == null || o.pack_style == 0)
                    {
                        Message += "\n =>Please select Pack Unit ";
                        flag = 1;
                    }
                    if (o.ball_make == null || o.ball_make == 0)
                    {
                        Message += "\n =>Please select Ball Make ";
                        flag = 1;
                    }
                    if (o.wire_make == null || o.wire_make == 0)
                    {
                        Message += "\n =>Please select Wire Make ";
                        flag = 1;
                    }
                    if (o.counter_qty == null)
                    {
                        Message += "\n =>Counter Quantity Cannot be null or 0 ";
                        flag = 1;
                    }
                    if (o.a_qty == null)
                    {
                        Message += "\n =>A Grade Quantity Cannot be null";
                        flag = 1;
                    }
                    //if (o.b_qty == null)
                    //{
                    //    Message += "\n =>B Grade Quantity Cannot be null ";
                    //    flag = 1;
                    //}
                    //if (o.c_qty == null)
                    //{
                    //    Message += "\n =>C Grade Quantity Cannot be null ";
                    //    flag = 1;
                    //}
                    if (o.tip_wt_1 == null)
                    {
                        Message += "\n =>Please Enter Avg Wt1 ";
                        flag = 1;
                    }
                    if (o.tip_wt_2 == null )
                    {
                        Message += "\n =>Please Enter Avg Wt2 ";
                        flag = 1;
                    }
                    if (o.tip_wt_3 == null)
                    {
                        Message += "\n =>Please Enter Avg Wt3 ";
                        flag = 1;
                    }
                    if (o.tip_ave_wt == null || o.tip_ave_wt == 0)
                    {
                        Message += "\n =>Please Enter Avg Weight ";
                        flag = 1;
                    }
                    if (o.blank_wt == null || o.blank_wt == 0)
                    {
                        Message += "\n =>Please Enter Avg Blank Weight ";
                        flag = 1;
                    }
                    if (o.conversion == null || o.conversion == "")
                    {
                        Message += "\n =>Please Enter conversion ";
                        flag = 1;
                    }


                    if (flag == 1)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Validation";
                        showMessageService.Text = string.Format(Message, MasterEntity.IndexOf(o));
                        showMessageService.ShowMessage();
                        return false;
                    }                             
                }
            }
            return true;
        }

        void ModelUpdated_Calculation(object sender, EventArgs e)
        {
            try
            {
                if (sender.ToString() == "tip_wt_1" || sender.ToString() == "tip_wt_2" || sender.ToString() == "tip_wt_3")
                {
                    if (dgSelectedIndex != -1 && MasterEntity.Count > 0 && dgSelectedIndex < MasterEntity.Count && MasterEntity[dgSelectedIndex].pack_style > 0)
                    {
                        float pkgQty = (from o in MC.PkgUnitList where o.id == MasterEntity[dgSelectedIndex].pack_style select o).ToList()[0].pkgqty;
                        if (MasterEntity[dgSelectedIndex].tip_wt_1 > 0 && MasterEntity[dgSelectedIndex].tip_wt_2 > 0
                            && MasterEntity[dgSelectedIndex].tip_wt_3 > 0)
                        {
                            MasterEntity[dgSelectedIndex].tip_ave_wt = MasterEntity[dgSelectedIndex].tip_wt_1 +
                                MasterEntity[dgSelectedIndex].tip_wt_2 + MasterEntity[dgSelectedIndex].tip_wt_3;
                            MasterEntity[dgSelectedIndex].tip_ave_wt /= 3;
                            if (AppSessionState.comp_code != "1")
                            {
                                MasterEntity[dgSelectedIndex].tip_ave_wt = MasterEntity[dgSelectedIndex].tip_ave_wt / Convert.ToDecimal(pkgQty);
                            }
                        }
                        else if (MasterEntity[dgSelectedIndex].tip_wt_1 > 0 && MasterEntity[dgSelectedIndex].tip_wt_2 > 0)
                        {
                            MasterEntity[dgSelectedIndex].tip_ave_wt = MasterEntity[dgSelectedIndex].tip_wt_1 + MasterEntity[dgSelectedIndex].tip_wt_2;
                            MasterEntity[dgSelectedIndex].tip_ave_wt /= 2;
                            if (AppSessionState.comp_code != "1")
                            {
                                MasterEntity[dgSelectedIndex].tip_ave_wt = MasterEntity[dgSelectedIndex].tip_ave_wt / Convert.ToDecimal(pkgQty);
                            }
                        }
                        else
                        {
                            if (AppSessionState.comp_code == "1")
                            {
                                MasterEntity[dgSelectedIndex].tip_ave_wt = MasterEntity[dgSelectedIndex].tip_wt_1;
                            }
                            else
                            {
                                MasterEntity[dgSelectedIndex].tip_ave_wt = MasterEntity[dgSelectedIndex].tip_wt_1/ Convert.ToDecimal(pkgQty);
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

        private void InsertRow_CopyPaste(object InputRow)
        {
            try
            {
                EPR_T002 EntityObject = null;
                if (InputRow != null && dgSelectedIndex != -1 && MasterEntity.Count > 0 && dgSelectedIndex < MasterEntity.Count)
                {
                    if (((IEnumerable)InputRow).Cast<EPR_T002>().Count() > 0)
                    {
                        EntityObject = ((IEnumerable)InputRow).Cast<EPR_T002>().ToList()[0];
                        MasterEntity.Add(new EPR_T002()
                        {
                            entry_dt = EntityObject.entry_dt,
                            prod_dt = EntityObject.prod_dt,
                            ItemCode = EntityObject.ItemCode,
                            pack_style = EntityObject.pack_style,
                            ink_id = EntityObject.ink_id,
                            ild_id = EntityObject.ild_id,
                            batch_no = EntityObject.batch_no,
                            machine_id = EntityObject.machine_id,
                            machinecode = EntityObject.machinecode,
                            shift = EntityObject.shift,
                            conversion = EntityObject.conversion,
                            tip_wt_1 = EntityObject.tip_wt_1,
                            tip_wt_2 = EntityObject.tip_wt_2,
                            tip_wt_3 = EntityObject.tip_wt_3,
                            tip_ave_wt = EntityObject.tip_ave_wt,
                            unit_code = EntityObject.unit_code,
                            wire_make = EntityObject.wire_make,
                            ball_make = EntityObject.ball_make,
                            active = EntityObject.active,
                            add_by = EntityObject.add_by,
                            location_Id = EntityObject.location_Id,
                            comp_code = EntityObject.comp_code,
                            doc_type = EntityObject.doc_type,
                            doc_cat = EntityObject.doc_cat,
                            fin_year = EntityObject.fin_year,
                            posting_period = EntityObject.posting_period,
                            conversion_no = EntityObject.conversion_no,
                            Ink = EntityObject.Ink,
                            Ild = EntityObject.Ild,
                            BallMake = EntityObject.BallMake,
                            WireMake = EntityObject.WireMake,
                            PackingUnit = EntityObject.PackingUnit,
                            ItemName = EntityObject.ItemName,
                            client = EntityObject.client,
                            check = false,
                            a_qty = 0,
                            b_qty = 0,
                            c_qty = 0,
                            blank_wt = EntityObject.blank_wt,
                            auto_sort = EntityObject.auto_sort
                        });
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
        private void InsertDataGridRow_Item(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M022_P POPUPEntityObject = null;
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
                        { POPUPEntityObject = MC.ItemList2.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = MasterEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = MasterEntity.IndexOf(MasterEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && MasterEntity.Count == dgSelectedIndex)
                    {
                        MasterEntity.Add(new EPR_T002()
                        {
                            id = 0,
                            ItemCode = POPUPEntityObject.ItemCode,
                            ItemName = POPUPEntityObject.ItemName,
                            comp_code = AppSessionState.comp_code,
                            client = AppSessionState.client,
                            location_Id = AppSessionState.location_Id,
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID,
                            fin_year = "16-17",
                            posting_period = "3",
                            active = true,
                            entry_dt = DateTime.Now,
                            doc_cat = "LG",
                            doc_type = "LG",
                            prod_dt = Date,
                            a_qty = 0,
                            b_qty = 0,
                            c_qty = 0,
                            tip_ave_wt = 0,
                            blank_wt = 0,
                            conversion_no = "",
                            auto_sort = false,
                            check = false
                        });
                    }
                    else if (dgSelectedIndex >= 0 && MasterEntity.Count > dgSelectedIndex) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity[dgSelectedIndex].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            MasterEntity[dgSelectedIndex].ItemCode = POPUPEntityObject.ItemCode;
                            MasterEntity[dgSelectedIndex].ItemName = POPUPEntityObject.ItemName;                      
                            MasterEntity[dgSelectedIndex].comp_code = AppSessionState.comp_code;
                            MasterEntity[dgSelectedIndex].client = AppSessionState.client;
                            MasterEntity[dgSelectedIndex].location_Id = AppSessionState.location_Id;
                            MasterEntity[dgSelectedIndex].add_by = AppSessionState.UserID;
                            MasterEntity[dgSelectedIndex].editby = AppSessionState.UserID;
                            MasterEntity[dgSelectedIndex].active = true;
                            MasterEntity[dgSelectedIndex].entry_dt = DateTime.Now;
                            MasterEntity[dgSelectedIndex].doc_cat = "LG";
                            MasterEntity[dgSelectedIndex].doc_type = "LG";
                            MasterEntity[dgSelectedIndex].prod_dt = Date;
                            MasterEntity[dgSelectedIndex].a_qty = 0;
                            MasterEntity[dgSelectedIndex].b_qty = 0;
                            MasterEntity[dgSelectedIndex].c_qty = 0;
                            MasterEntity[dgSelectedIndex].tip_ave_wt = 0;
                            //MasterEntity[dgSelectedIndex].blank_wt = 0;
                            MasterEntity[dgSelectedIndex].conversion_no = "";
                        }
                        else if (MasterEntity[dgSelectedIndex].ItemCode != POPUPEntityObject.ItemCode)
                        {
                            MasterEntity[dgSelectedIndex].ItemCode = "";
                            MasterEntity[dgSelectedIndex].ItemName = "";
                        }
                    }
                }


                #region Clear Empty Row
                EPR_T002 newObj = new EPR_T002();
                for (int i = MasterEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEntity[i].ComparePropertiesTo(newObj) == true && MasterEntity.Count > 1)
                    {
                        MasterEntity.RemoveAt(i);
                        if (MasterEntity.Count == 0)
                        {
                            MasterEntity.Add(newObj);
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
        //BackFlip
        private void LoadLabelGenerationDetails()
        {
            try
            {
                bool Label_used = false;

                //if (SelectedEPR_T002.machine_id == null || SelectedEPR_T002.machinecode == "All")
                //{
                //    SelectedEPR_T002.machine_id = null;
                //}
                //if (SelectedEPR_T002.pack_style == null || SelectedEPR_T002.PackingUnit == "All")
                //{
                //    SelectedEPR_T002.pack_style = 0;
                //}
                //if (SelectedEPR_T002.ItemCode == null || SelectedEPR_T002.ItemCode == "")
                //{
                //    SelectedEPR_T002.ItemCode = "All";
                //}
                //if (SelectedEPR_T002.conversion == null)
                //{
                //    SelectedEPR_T002.conversion = "All";
                //}
                //if (SelectedEPR_T002.shift == null)
                //{
                //    SelectedEPR_T002.shift = "All";
                //}
                //if (SelectedEPR_T002.ink_id == null || SelectedEPR_T002.Ink == "All")
                //{
                //    SelectedEPR_T002.ink_id = 0;
                //}
                //if (SelectedEPR_T002.ild_id == null || SelectedEPR_T002.Ild == "All")
                //{
                //    SelectedEPR_T002.ild_id = 0;
                //}
                //if (SelectedEPR_T002.grade == null)
                //{
                //    SelectedEPR_T002.grade = "A";
                //}

                if (LabelStatus == "Used")
                {
                    Label_used = true;
                }
                
                string Request = "LoadLGDetails" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + SelectedEPR_T002.machine_id + "!@" + SelectedEPR_T002.pack_style + "!@" + SelectedEPR_T002.ItemCode
                        + "!@" + SelectedEPR_T002.conversion + "!@" + SelectedEPR_T002.shift + "!@" + SelectedEPR_T002.ink_id + "!@" + SelectedEPR_T002.ild_id + "!@" + "" + "!@" + SelectedEPR_T002.grade + "!@" + Label_used + "!@" + "LG" + "!@" + "" + "!@" + SelectedEPR_T002.from_date.ToString() + "!@" + SelectedEPR_T002.to_date.ToString() + "!@" + SelectedEPR_T002.entry_dt.ToString() + "!@" + SelectedEPR_T002.machinecode;

                MCTemp2 = repositoryM.GetDataWithReturnDomainObject<MultipleContext_EPR_T002>(MCTemp2, Request, "LabelGenerationMaster", "Production", "LoadAll", 0, "");

                if (MCTemp2.LabelGenBackFlipList.Count >= 0)
                {
                    BackFlipCollection = CollectionViewSource.GetDefaultView(MCTemp2.LabelGenBackFlipList);
                    BackFlipCollection.Filter = new Predicate<object>(Filter_FlipGrid);

                    BackFlipCollection.Refresh();
                }
                foreach (var item in MC.MachineList)
                {
                    if(item.Select==true)
                    {
                        item.Select = false;
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
        private void InsertMachine(IList InputValue)
        {
            try
            {
                int stringmachine_id = 0;
                string stringmachinecode = "";
                SelectedEPR_T002.machinecode = "";
                foreach (ZADM_M013_P temp in MC.MachineList)
                {
                    if (temp.Select == true)
                    {
                        //stringmachine_id = stringmachine_id + "," + temp.machine_id;
                        stringmachinecode = stringmachinecode + "," + temp.machinecode;
                    }
                }
                //SelectedEPR_T002.machine_id = stringmachine_id.ToString().TrimStart(new char[] { ',' });
                SelectedEPR_T002.machinecode = stringmachinecode.ToString().TrimStart(new char[] { ',' });

                //IList list = InputValue as IList;
                //List<ZADM_M013_P> GetSelectedMachine = list.Cast<ZADM_M013_P>().ToList();

                //if (GetSelectedMachine.Count > 0)
                //{
                //    SelectedEPR_T002.machine_id = GetSelectedMachine[0].machine_id;
                //    SelectedEPR_T002.machinecode = GetSelectedMachine[0].machinecode;
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
        private void InsertBPkgUnit(IList InputValue)
        {
            try
            {

                IList list = InputValue as IList;
                List<ZADM_M017_P> GetSelectedPkgUnit = list.Cast<ZADM_M017_P>().ToList();

                if (GetSelectedPkgUnit.Count > 0)
                {
                    SelectedEPR_T002.pack_style = GetSelectedPkgUnit[0].id;
                    SelectedEPR_T002.PackingUnit = GetSelectedPkgUnit[0].pkgunit;
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
        private void InsertItem(IList InputValue)
        {
            try
            {

                IList list = InputValue as IList;
                List<ADM_M022_P> GetSelectedItem = list.Cast<ADM_M022_P>().ToList();

                if (GetSelectedItem.Count > 0)
                {
                    SelectedEPR_T002.ItemCode = GetSelectedItem[0].ItemCode;
                    SelectedEPR_T002.ItemName = GetSelectedItem[0].ItemName;
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
        private void InsertBInk(IList InputValue)
        {
            try
            {

                IList list = InputValue as IList;
                List<ZADM_M006_P> GetSelectedInk = list.Cast<ZADM_M006_P>().ToList();

                if (GetSelectedInk.Count > 0)
                {
                    SelectedEPR_T002.ink_id = GetSelectedInk[0].ink_id;
                    SelectedEPR_T002.Ink = GetSelectedInk[0].ink;
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
        private void InsertBIld(IList InputValue)
        {
            try
            {

                IList list = InputValue as IList;
                List<ZADM_M007_P> GetSelectedIld = list.Cast<ZADM_M007_P>().ToList();

                if (GetSelectedIld.Count > 0)
                {
                    SelectedEPR_T002.ild_id = GetSelectedIld[0].ild_id;
                    SelectedEPR_T002.Ild = GetSelectedIld[0].ild;
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

        private void Print2()
        {
            try
            {
                if (MCTemp2.LabelGenBackFlipList != null && MCTemp2.LabelGenBackFlipList.Count > 0 && MC.SettingsList.Count > 0)
                {
                    if (PrintOption == "All")
                    {
                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        QRCodeService QRGenerator = new QRCodeService();
                        foreach (RptLabelGen item in MCTemp2.RptLabelGenList)
                        {
                            if (MC.SettingsList[0].scan_source == "Barcode")
                            {
                                item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.barcode, 15, "");
                            }
                            else if (MC.SettingsList[0].scan_source == "Batch")
                            {
                                item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.batch_no, 15, "");
                            }

                        }

                        objDataSource[0] = MCTemp2.RptLabelGenList;
                        objDataSourceName[0] = "dsRptLabelGen";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report2, MC.SettingsList[0].report2);
                    }
                    else if (PrintOption == "All But No Odd Lot")
                    {
                        int count = MCTemp2.LabelGenBackFlipList.Count(x => x.label_complete_stat == true);

                        if (count > 0)
                        {
                            foreach (var k in MCTemp2.RptLabelGenList)
                            {
                                k.check = false;
                            }

                            foreach (var o in MCTemp2.LabelGenBackFlipList)
                            {
                                if (o.label_complete_stat == true)
                                {
                                    foreach (var p in MCTemp2.RptLabelGenList)
                                    {
                                        if ((p.batch_no == o.batch_no || p.batch_no == o.cust_batch_no) && p.check != true)
                                        {
                                            p.check = true;
                                        }
                                    }
                                }
                            }

                            object[] objDataSource = new object[3];
                            string[] objDataSourceName = new string[3];

                            QRCodeService QRGenerator = new QRCodeService();
                            foreach (RptLabelGen item in MCTemp2.RptLabelGenList)
                            {
                                if (MC.SettingsList[0].scan_source == "Barcode")
                                {
                                    item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.barcode, 15, "");
                                }
                                else if (MC.SettingsList[0].scan_source == "Batch")
                                {
                                    item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.batch_no, 15, "");
                                }

                            }

                            objDataSource[0] = MCTemp2.RptLabelGenList.Where(x => x.check == true);
                            objDataSourceName[0] = "dsRptLabelGen";

                            ReportManager ReportManager = new ReportManager();
                            ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name, MC.SettingsList[0].report_name);
                        }

                    }
                    else if (PrintOption == "Selected")
                    {
                        int count = MCTemp2.LabelGenBackFlipList.Count(x => x.check == true);

                        if (count > 0)
                        {
                            foreach (var k in MCTemp2.RptLabelGenList)
                            {
                                k.check = false;
                            }

                            foreach (var o in MCTemp2.LabelGenBackFlipList)
                            {
                                if (o.check == true)
                                {
                                    foreach (var p in MCTemp2.RptLabelGenList)
                                    {
                                        if ((p.batch_no == o.batch_no || p.batch_no == o.cust_batch_no) && p.check != true)
                                        {
                                            p.check = true;
                                        }
                                    }
                                }
                            }

                            object[] objDataSource = new object[3];
                            string[] objDataSourceName = new string[3];

                            QRCodeService QRGenerator = new QRCodeService();
                            foreach (RptLabelGen item in MCTemp2.RptLabelGenList)
                            {
                                if (MC.SettingsList[0].scan_source == "Barcode")
                                {
                                    item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.barcode, 15, "");
                                }
                                else if (MC.SettingsList[0].scan_source == "Batch")
                                {
                                    item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.batch_no, 15, "");
                                }

                            }

                            objDataSource[0] = MCTemp2.RptLabelGenList.Where(x => x.check == true);
                            objDataSourceName[0] = "dsRptLabelGen";

                            ReportManager ReportManager = new ReportManager();
                            ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report2, MC.SettingsList[0].report2);
                        }
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Select Print Option", this.Title);
                        showMessageService.ShowMessage();
                    }


                }
                else if (MCTemp2.LabelGenBackFlipList == null || MCTemp2.LabelGenBackFlipList.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Load the Data First...", this.Title);
                    showMessageService.ShowMessage();
                }
                else if (MC.SettingsList.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Report Setting Not Found", this.Title);
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
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    //LoadLabelGenerationDetails(doc_no_vm);
                   
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
                    Request = SelectedEPR_T002.client + "!@" + SelectedEPR_T002.comp_code + "!@" + InputValue.ToString();
                    objRef.Invoke_Documet(Request, Request);
                }
                #endregion
            }
            catch (Exception ex)
            { }
        }

       
        #endregion

        #region · Command Actions ·

        protected override void OnSaveAction(InquiryActionResult<EPR_T002> result)
        {
            try
            {
                TobeSaveEntity = new List<EPR_T002>();
                if (isNewRecord == true)
                {
                    foreach (var o in MasterEntity)  //First Selected Rows Will be Added To New Collection
                    {
                        if (o.check == true)
                        {
                            TobeSaveEntity.Add(o);
                        }
                    }

                    if (TobeSaveEntity.Count > 0)   // If At Least One Row is Selected The Only It Will Save
                    {
                        if (Validations() == true)
                        {
                            string reader = repository.Save<List<EPR_T002>>(TobeSaveEntity, "LabelGenerationMaster", "Production");
                            int intreader = Convert.ToInt32(reader);

                            if (intreader > 0) // intreader is always greater than 0 if data is saved
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Saved Successfully", this.Title);
                                showMessageService.ShowMessage();

                                foreach (var o in TobeSaveEntity)
                                {
                                    for (int i = MasterEntity.Count - 1; i >= 0; i--)
                                    {
                                        MasterEntity.Remove(o);
                                    }
                                }
                            }
                        }
                    }
                    else  // if No rows are selected it will give Message
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Select At Least One Row", this.Title);
                        showMessageService.ShowMessage();
                    }
                    SelectedEPR_T002.prod_dt = Date;
                    SelectedEPR_T002.ts_code = ts_code_vm;
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
        protected override void OnCreateAction(InquiryActionResult<EPR_T002> result)
        {
            isNewRecord = true;
            MasterEntity = new ObservableCollection<EPR_T002>();
            SelectedEPR_T002 = new EPR_T002();
            Date = DateTime.Now;
            SelectedEPR_T002.prod_dt = DateTime.Now;
            SelectedEPR_T002.ts_code = ts_code_vm;
            SelectedEPR_T002.record_type = "01";
        }
        protected override void OnRemoveAction(InquiryActionResult<EPR_T002> result)
        {        
        }
        protected override void OnDiscardAction(InquiryActionResult<EPR_T002> result)
        {
        }
        protected override void OnFevoriteAction(InquiryActionResult<EPR_T002> result)
        {
        }
        protected override void OnFlipAction(InquiryActionResult<EPR_T002> result)
        {
        }
        protected override void OnHelpAction(InquiryActionResult<EPR_T002> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<EPR_T002> result)
        {
            try
            {
                if (MCTemp2.LabelGenBackFlipList != null && MCTemp2.LabelGenBackFlipList.Count > 0 && MC.SettingsList.Count > 0)
                {
                    if (PrintOption == "All")
                    {
                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        QRCodeService QRGenerator = new QRCodeService();
                        foreach (RptLabelGen item in MCTemp2.RptLabelGenList)
                        {
                            if (MC.SettingsList[0].scan_source == "Barcode")
                            {
                                item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.barcode, 15, "");
                            }
                            else if (MC.SettingsList[0].scan_source == "Batch")
                            {
                                item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.batch_no, 15, "");
                            }


                        }

                        objDataSource[0] = MCTemp2.RptLabelGenList;
                        objDataSourceName[0] = "dsRptLabelGen";

                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name, MC.SettingsList[0].report_name);
                    }
                    else if (PrintOption == "All But No Odd Lot")
                    {
                        int count = MCTemp2.LabelGenBackFlipList.Count(x => x.label_complete_stat == true);

                        if (count > 0)
                        {
                            foreach (var k in MCTemp2.RptLabelGenList)
                            {
                                k.check = false;
                            }

                            foreach (var o in MCTemp2.LabelGenBackFlipList)
                            {
                                if (o.label_complete_stat == true)
                                {
                                    foreach (var p in MCTemp2.RptLabelGenList)
                                    {
                                        if ((p.batch_no == o.batch_no || p.batch_no == o.cust_batch_no) && p.check != true)
                                        {
                                            p.check = true;
                                        }
                                    }
                                }
                            }

                            object[] objDataSource = new object[3];
                            string[] objDataSourceName = new string[3];

                            QRCodeService QRGenerator = new QRCodeService();
                            foreach (RptLabelGen item in MCTemp2.RptLabelGenList)
                            {
                                if (MC.SettingsList[0].scan_source == "Barcode")
                                {
                                    item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.barcode, 15, "");
                                }
                                else if (MC.SettingsList[0].scan_source == "Batch")
                                {
                                    item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.batch_no, 15, "");
                                }

                            }

                            objDataSource[0] = MCTemp2.RptLabelGenList.Where(x => x.check == true);
                            objDataSourceName[0] = "dsRptLabelGen";

                            ReportManager ReportManager = new ReportManager();
                            ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name, MC.SettingsList[0].report_name);
                        }

                    }
                    else if (PrintOption == "Selected")
                    {
                        int count = MCTemp2.LabelGenBackFlipList.Count(x => x.check == true);

                        if (count > 0)
                        {
                            foreach (var k in MCTemp2.RptLabelGenList)
                            {
                                k.check = false;
                            }

                            foreach (var o in MCTemp2.LabelGenBackFlipList)
                            {
                                if (o.check == true)
                                {
                                    foreach (var p in MCTemp2.RptLabelGenList)
                                    {
                                        if ((p.batch_no == o.batch_no || p.batch_no == o.cust_batch_no) && p.check != true)
                                        {
                                            p.check = true;
                                        }
                                    }
                                }
                            }

                            object[] objDataSource = new object[3];
                            string[] objDataSourceName = new string[3];

                            QRCodeService QRGenerator = new QRCodeService();
                            foreach (RptLabelGen item in MCTemp2.RptLabelGenList)
                            {
                                if (MC.SettingsList[0].scan_source == "Barcode")
                                {
                                    item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.barcode, 15, "");
                                }
                                else if (MC.SettingsList[0].scan_source == "Batch")
                                {
                                    item.qr_batch = QRGenerator.RenderQrCodeForLabel(item.batch_no, 15, "");
                                }

                            }

                            objDataSource[0] = MCTemp2.RptLabelGenList.Where(x => x.check == true);
                            objDataSourceName[0] = "dsRptLabelGen";

                            ReportManager ReportManager = new ReportManager();
                            ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Label\\" + MC.SettingsList[0].report_name, MC.SettingsList[0].report_name);
                        }
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Select Print Option", this.Title);
                        showMessageService.ShowMessage();
                    }


                }
                else if (MCTemp2.LabelGenBackFlipList == null || MCTemp2.LabelGenBackFlipList.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Load the Data First...", this.Title);
                    showMessageService.ShowMessage();
                }
                else if (MC.SettingsList.Count <= 0)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Report Setting Not Found", this.Title);
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
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<EPR_T002> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters

        #region Unit

        private string _filterString_Unit;
        public string FilterString_Unit
        {
            get { return _filterString_Unit; }
            set
            {
                _filterString_Unit = value;
                RaisePropertyChanged("FilterString_Unit");
                FilterCollection_Unit();
            }
        }
        private void FilterCollection_Unit()
        {
            if (_UnitCollection != null)
            {
                _UnitCollection.Refresh();
            }
        }
        public bool Filter_Unit(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Unit))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_Unit.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

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

        #region Customer Production

        private string _filterString_CustProduct;
        public string FilterString_CustProduct
        {
            get { return _filterString_CustProduct; }
            set
            {
                _filterString_CustProduct = value;
                RaisePropertyChanged("FilterString_CustProduct");
                FilterCollection_CustProduct();
            }
        }
        private void FilterCollection_CustProduct()
        {
            if (_CustomerProductCollection != null)
            {
                _CustomerProductCollection.Refresh();
            }
        }
        public bool Filter_CustProduct(object obj)
        {
            var data = obj as ZADM_M020_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_CustProduct))
                {
                    return (data.CustomerProductName != null && data.CustomerProductName.ToString().ToLower().Contains(_filterString_CustProduct.ToLower()) ||
                        data.ProductName != null && data.ProductName.ToString().ToLower().Contains(_filterString_CustProduct.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Ball Make

        private string _filterString_BallMake;
        public string FilterString_BallMake
        {
            get { return _filterString_BallMake; }
            set
            {
                _filterString_BallMake = value;
                RaisePropertyChanged("FilterString_BallMake");
                FilterCollection_BallMake();
            }
        }
        private void FilterCollection_BallMake()
        {
            if (_BallMakeCollection != null)
            {
                _BallMakeCollection.Refresh();
            }
        }
        public bool Filter_BallMake(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BallMake))
                {
                    return (data.MakeCode != null && data.MakeCode.ToString().ToLower().Contains(_filterString_BallMake.ToLower()) ||
                        data.Make != null && data.Make.ToString().ToLower().Contains(_filterString_BallMake.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Wire Make

        private string _filterString_WireMake;
        public string FilterString_WireMake
        {
            get { return _filterString_WireMake; }
            set
            {
                _filterString_WireMake = value;
                RaisePropertyChanged("FilterString_WireMake");
                FilterCollection_WireMake();
            }
        }
        private void FilterCollection_WireMake()
        {
            if (_WireMakeCollection != null)
            {
                _WireMakeCollection.Refresh();
            }
        }
        public bool Filter_WireMake(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_WireMake))
                {
                    return (data.MakeCode != null && data.MakeCode.ToString().ToLower().Contains(_filterString_WireMake.ToLower()) ||
                        data.Make != null && data.Make.ToString().ToLower().Contains(_filterString_WireMake.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Party
        private string _filterString_Party;
        public string FilterString_Party
        {
            get { return _filterString_Party; }
            set
            {
                _filterString_Party = value;
                RaisePropertyChanged("FilterString_Party");
                FilterCollection_Party();
            }
        }
        private void FilterCollection_Party()
        {
            if (_PartyCollection != null)
            {
                _PartyCollection.Refresh();
            }
        }
        public bool Filter_Party(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Party))
                {
                    return (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_Party.ToLower()) ||
                        data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_Party.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region MachineOperator
        private string _filterString_MachineOperator;
        public string FilterString_MachineOperator
        {
            get { return _filterString_MachineOperator; }
            set
            {
                _filterString_MachineOperator = value;
                RaisePropertyChanged("FilterString_MachineOperator");
                FilterCollection_MachineOperator();
            }
        }
        private void FilterCollection_MachineOperator()
        {
            if (_MachineOperatorCollection != null)
            {
                _MachineOperatorCollection.Refresh();
            }
        }
        public bool Filter_MachineOperator(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_MachineOperator))
                {
                    return (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterString_MachineOperator.ToLower()) ||
                        data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterString_MachineOperator.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region MachineOperator
        private string _filterString_ShiftIncharge;
        public string FilterString_ShiftIncharge
        {
            get { return _filterString_ShiftIncharge; }
            set
            {
                _filterString_ShiftIncharge = value;
                RaisePropertyChanged("FilterString_ShiftIncharge");
                FilterCollection_ShiftIncharge();
            }
        }
        private void FilterCollection_ShiftIncharge()
        {
            if (_ShiftInchargeCollection != null)
            {
                _ShiftInchargeCollection.Refresh();
            }
        }
        public bool Filter_ShiftIncharge(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ShiftIncharge))
                {
                    return (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterString_ShiftIncharge.ToLower()) ||
                        data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterString_ShiftIncharge.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Ink
        private string _filterString_Ink;
        public string FilterString_Ink
        {
            get { return _filterString_Ink; }
            set
            {
                _filterString_Ink = value;
                RaisePropertyChanged("FilterString_Ink");
                FilterCollection_Ink();
            }
        }
        private void FilterCollection_Ink()
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
                if (!string.IsNullOrEmpty(_filterString_Ink))
                {
                    return (data.ink != null && data.ink.ToString().ToLower().Contains(_filterString_Ink.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Ild
        private string _filterString_Ild;
        public string FilterString_Ild
        {
            get { return _filterString_Ild; }
            set
            {
                _filterString_Ild = value;
                RaisePropertyChanged("FilterString_Ild");
                FilterCollection_Ild();
            }
        }
        private void FilterCollection_Ild()
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
                if (!string.IsNullOrEmpty(_filterString_Ild))
                {
                    return (data.ild != null && data.ild.ToString().ToLower().Contains(_filterString_Ild.ToLower()) ||
                        data.tip_type != null && data.tip_type.ToString().ToLower().Contains(_filterString_Ild.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        //Backflip

        #region FlipGrid
        private string _filterString_FlipGrid;
        public string FilterString_FlipGrid
        {
            get { return _filterString_FlipGrid; }
            set
            {
                _filterString_FlipGrid = value;
                RaisePropertyChanged("FilterString_FlipGrid");
                FilterCollection_FlipGrid();
            }
        }
        private void FilterCollection_FlipGrid()
        {
            if (_BackFlipCollection != null)
            {
                _BackFlipCollection.Refresh();
            }
        }
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as EPR_T002_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterString_FlipGrid))
                {
                    return (data.shift != null && data.shift.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.Ink != null && data.Ink.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.Ild != null && data.Ild.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.PackingUnit != null && data.PackingUnit.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.conversion != null && data.conversion.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.BallMake != null && data.BallMake.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.WireMake != null && data.WireMake.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.a_qty != null && data.a_qty.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.b_qty != null && data.b_qty.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.c_qty != null && data.c_qty.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.counter_qty != null && data.counter_qty.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.tip_wt_1 != null && data.tip_wt_1.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.tip_wt_2 != null && data.tip_wt_2.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.tip_wt_3 != null && data.tip_wt_3.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.blank_wt != null && data.blank_wt.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.entry_dt != null && data.entry_dt.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                        (data.prod_dt != null && data.prod_dt.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Machine

        private string _filterString_Machine;
        public string FilterString_Machine
        {
            get { return _filterString_Machine; }
            set
            {
                _filterString_Machine = value;
                RaisePropertyChanged("FilterString_Machine");
                FilterCollection_Machine();
            }
        }
        private void FilterCollection_Machine()
        {
            if (_MachineCollection != null)
            {
                _MachineCollection.Refresh();
            }
        }
        public bool Filter_Machine(object obj)
        {
            var data = obj as ZADM_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Machine))
                {
                    return (data.machine_id != null && data.machine_id.ToString().ToLower().Contains(_filterString_Machine.ToLower())) ||
                        (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_Machine.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Machine

        private string _filterString_Machine2;
        public string FilterString_Machine2
        {
            get { return _filterString_Machine2; }
            set
            {
                _filterString_Machine2 = value;
                RaisePropertyChanged("FilterString_Machine2");
                FilterCollection_Machine2();
            }
        }
        private void FilterCollection_Machine2()
        {
            if (_MachineCollection2 != null)
            {
                _MachineCollection2.Refresh();
            }
        }
        public bool Filter_Machine2(object obj)
        {
            var data = obj as ZADM_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Machine2))
                {
                    return (data.machine_id != null && data.machine_id.ToString().ToLower().Contains(_filterString_Machine2.ToLower())) ||
                        (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_Machine2.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion
        #region Machine Master

        private string _filterString_MachineMaster;
        public string FilterString_MachineMaster
        {
            get { return _filterString_MachineMaster; }
            set
            {
                _filterString_MachineMaster = value;
                RaisePropertyChanged("FilterString_MachineMaster");
                FilterCollection_MachineMaster();
            }
        }
        private void FilterCollection_MachineMaster()
        {
            if (_MachineMasterCollection != null)
            {
                _MachineMasterCollection.Refresh();
            }
        }
        public bool Filter_MachineMaster(object obj)
        {
            var data = obj as ZADM_M013_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_MachineMaster))
                {
                    return (data.machine_id != null && data.machine_id.ToString().ToLower().Contains(_filterString_MachineMaster.ToLower())) ||
                        (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_MachineMaster.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region BPackUnit

        private string _filterString_BPkgUnit;
        public string FilterString_BPkgUnit
        {
            get { return _filterString_BPkgUnit; }
            set
            {
                _filterString_BPkgUnit = value;
                RaisePropertyChanged("FilterString_BPkgUnit");
                FilterCollection_BPkgUnit();
            }
        }
        private void FilterCollection_BPkgUnit()
        {
            if (_BPkgUnitCollection != null)
            {
                _BPkgUnitCollection.Refresh();
            }
        }
        public bool Filter_BPkgUnit(object obj)
        {
            var data = obj as ZADM_M017_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BPkgUnit))
                {
                    return (data.pkgunit != null && data.pkgunit.ToString().ToLower().Contains(_filterString_BPkgUnit.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Product

        private string _filterString_ItemCode;
        public string FilterString_ItemCode
        {
            get { return _filterString_ItemCode; }
            set
            {
                _filterString_ItemCode = value;
                RaisePropertyChanged("FilterString_ItemCode");
                FilterCollection_ItemCode();
            }
        }
        private void FilterCollection_ItemCode()
        {
            if (_ItemCollection != null)
            {
                _ItemCollection.Refresh();
            }
        }
        public bool Filter_ItemCode(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ItemCode))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_ItemCode.ToLower()) ||
                        data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_ItemCode.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Product

        private string _filterString_ItemCode2;
        public string FilterString_ItemCode2
        {
            get { return _filterString_ItemCode2; }
            set
            {
                _filterString_ItemCode2 = value;
                RaisePropertyChanged("FilterString_ItemCode2");
                FilterCollection_ItemCode2();
            }
        }
        private void FilterCollection_ItemCode2()
        {
            if (_ItemCollection2 != null)
            {
                _ItemCollection2.Refresh();
            }
        }
        public bool Filter_ItemCode2(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ItemCode2))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_ItemCode2.ToLower()) ||
                        data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_ItemCode2));
                }
                return true;
            }
            return false;
        }

        #endregion
        #region Product2

        private string _filterString_ItemCode3;
        public string FilterString_ItemCode3
        {
            get { return _filterString_ItemCode3; }
            set
            {
                _filterString_ItemCode3 = value;
                RaisePropertyChanged("FilterString_ItemCode3");
                FilterCollection_ItemCode3();
            }
        }
        private void FilterCollection_ItemCode3()
        {
            if (_ItemCollection3 != null)
            {
                _ItemCollection3.Refresh();
            }
        }
        public bool Filter_Item(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ItemCode3))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_ItemCode3.ToLower()) ||
                        data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_ItemCode3));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Ink
        private string _BfilterString_Ink;
        public string BFilterString_Ink
        {
            get { return _BfilterString_Ink; }
            set
            {
                _BfilterString_Ink = value;
                RaisePropertyChanged("BFilterString_Ink");
                BFilterCollection_Ink();
            }
        }
        private void BFilterCollection_Ink()
        {
            if (_BInkCollection != null)
            {
                _BInkCollection.Refresh();
            }
        }
        public bool BFilter_Ink(object obj)
        {
            var data = obj as ZADM_M006_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_BfilterString_Ink))
                {
                    return (data.ink != null && data.ink.ToString().ToLower().Contains(_BfilterString_Ink.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Ild
        private string _BfilterString_Ild;
        public string BFilterString_Ild
        {
            get { return _BfilterString_Ild; }
            set
            {
                _BfilterString_Ild = value;
                RaisePropertyChanged("BFilterString_Ild");
                BFilterCollection_Ild();
            }
        }
        private void BFilterCollection_Ild()
        {
            if (_BIldCollection != null)
            {
                _BIldCollection.Refresh();
            }
        }
        public bool BFilter_Ild(object obj)
        {
            var data = obj as ZADM_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_BfilterString_Ild))
                {
                    return (data.ild != null && data.ild.ToString().ToLower().Contains(_BfilterString_Ild.ToLower()) ||
                        data.tip_type != null && data.tip_type.ToString().ToLower().Contains(_BfilterString_Ild.ToLower()));
                }
                return true;
            }
            return false;
        }

        
        #endregion

        #endregion
    }
}
