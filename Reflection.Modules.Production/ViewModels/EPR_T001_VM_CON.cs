using GalaSoft.MvvmLight.Command;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.Production;
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
using Reflection.ReportingServices;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using GalaSoft.MvvmLight.Messaging;
using System.IO;
using System.Collections.ObjectModel;
using Reflection.Presentation.Controls;
using System.Windows;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.Production.ViewModels
{
    public class EPR_T001_VM_CON : WorkspaceViewModel<EPR_T001_New>
    {
        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(EPR_T001_VM_CON));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }
      
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
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

        private AutoSuggestTextViewModel<dynamic> _ASCompCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCompCode
        {
            get { return _ASCompCode; }
            set
            {
                if (_ASCompCode != value)
                {
                    _ASCompCode = value; RaisePropertyChanged("ASCompCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASFltrStatus { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFltrStatus
        {
            get { return _ASFltrStatus; }
            set
            {
                if (_ASFltrStatus != value)
                {
                    _ASFltrStatus = value; RaisePropertyChanged("ASFltrStatus");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASRefDocType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRefDocType
        {
            get { return _ASRefDocType; }
            set
            {
                if (_ASRefDocType != value)
                {
                    _ASRefDocType = value; RaisePropertyChanged("ASRefDocType");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASViewPlant{ get; set; }
        public AutoSuggestTextViewModel<dynamic> ASViewPlant
        {
            get { return _ASViewPlant; }
            set
            {
                if (_ASViewPlant != value)
                {
                    _ASViewPlant = value; RaisePropertyChanged("ASViewPlant");
                }
            }
        }
        #endregion 


        bool isNewRecord = true;
        WebServiceRepository<EPR_T001_New> repository = new WebServiceRepository<EPR_T001_New>();
        WebServiceRepository<MultipleContext_EPR_T001_Conv> repository_MC = new WebServiceRepository<MultipleContext_EPR_T001_Conv>();
        WebServiceRepository<MultipleContext_EPR_T001_Conv> repository_MCTemp = new WebServiceRepository<MultipleContext_EPR_T001_Conv>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region Variable Declaration
        private MultipleContext_EPR_T001_Conv _MC = new MultipleContext_EPR_T001_Conv();
        public MultipleContext_EPR_T001_Conv MC
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

        private MultipleContext_EPR_T001_Conv _MCTemp = new MultipleContext_EPR_T001_Conv();
        public MultipleContext_EPR_T001_Conv MCTemp
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

        private MultipleContext_EPR_T001_Conv _MCTemp1 = new MultipleContext_EPR_T001_Conv();
        public MultipleContext_EPR_T001_Conv MCTemp1
        {
            get { return _MCTemp1; }
            set
            {
                if (_MCTemp1 != value)
                {
                    _MCTemp1 = value; RaisePropertyChanged("MCTemp1");
                }
            }
        }

        private EPR_T001_New _MasterEntity;
        public EPR_T001_New MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                    value.BeginEdit();
                }
            }
        }

        private EPR_T001_New _MasterEntityTemp;
        public EPR_T001_New MasterEntityTemp
        {
            get { return _MasterEntityTemp; }
            set
            {
                if (_MasterEntityTemp != value)
                {
                    _MasterEntityTemp = value; RaisePropertyChanged("MasterEntityTemp");
                    value.BeginEdit();
                }
            }
        }

        private List<ECRM_T002_AFeedbackRpt> _RptFeedback;
        public List<ECRM_T002_AFeedbackRpt> RptFeedback
        {
            get { return _RptFeedback; }
            set
            {
                if (_RptFeedback != value)
                {
                    _RptFeedback = value;
                    RaisePropertyChanged("RptFeedback");
                }
            }
        }

        private List<EPR_T001_Flip> _FlipGridData;
        public List<EPR_T001_Flip> FlipGridData
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

        public ObservableCollection<EPR_T001_P1> _CurrentMachineCollection;
        public ObservableCollection<EPR_T001_P1> CurrentMachineCollection
        {
            get { return _CurrentMachineCollection; }
            set
            {
                _CurrentMachineCollection = value;
                RaisePropertyChanged("CurrentMachineCollection");
            }
        }
        // adding new field

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

        private int _dgSelectedIndexCurrentMcDetails;
        public int dgSelectedIndexCurrentMcDetails
        {
            get { return _dgSelectedIndexCurrentMcDetails; }
            set
            {
                if (_dgSelectedIndexCurrentMcDetails != value)
                {
                    _dgSelectedIndexCurrentMcDetails = value;
                    RaisePropertyChanged("dgSelectedIndexCurrentMcDetails");

                }
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

        public List<ADM_M002> _CompanyList;
        public List<ADM_M002> CompanyList
        {
            get { return _CompanyList; }
            set
            {
                _CompanyList = value;
                RaisePropertyChanged("CompanyList");
            }
        }

        public List<ADM_M043_D> _ApprovalData { get; set; }
        public List<ADM_M043_D> ApprovalData
        {
            get
            {
                return _ApprovalData;
            }
            set
            {
                if (_ApprovalData != value)
                {
                    _ApprovalData = value;
                    RaisePropertyChanged("ApprovalData");
                }
            }
        }
        #endregion

        #region ICollectionView
        private ICollectionView _DataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _DataGridCollection; }
            set { _DataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private ICollectionView _CurrentProductCollection;
        public ICollectionView CurrentProductCollection
        {
            get { return _CurrentProductCollection; }
            set { _CurrentProductCollection = value; RaisePropertyChanged("CurrentProductCollection"); }
        }

        private ICollectionView _MachineCollection;
        public ICollectionView MachineCollection
        {
            get { return _MachineCollection; }
            set { _MachineCollection = value; RaisePropertyChanged("MachineCollection"); }
        }

        private ICollectionView _ProductionPlanningCollection;
        public ICollectionView ProductionPlanningCollection
        {
            get { return _ProductionPlanningCollection; }
            set { _ProductionPlanningCollection = value; RaisePropertyChanged("ProductionPlanningCollection"); }
        }

        private ICollectionView _ModelMasterCollection;
        public ICollectionView ModelMasterCollection
        {
            get { return _ModelMasterCollection; }
            set { _ModelMasterCollection = value; RaisePropertyChanged("ModelMasterCollection"); }
        }

        private ICollectionView _INKMasterCollection;
        public ICollectionView INKMasterCollection
        {
            get { return _INKMasterCollection; }
            set { _INKMasterCollection = value; RaisePropertyChanged("INKMasterCollection"); }
        }

        private ICollectionView _WireMakeCollection;
        public ICollectionView WireMakeCollection
        {
            get { return _WireMakeCollection; }
            set { _WireMakeCollection = value; RaisePropertyChanged("WireMakeCollection"); }
        }

        private ICollectionView _WireSizeCollection;
        public ICollectionView WireSizeCollection
        {
            get { return _WireSizeCollection; }
            set { _WireSizeCollection = value; RaisePropertyChanged("WireSizeCollection"); }
        }

        private ICollectionView _PartyCollection;
        public ICollectionView PartyCollection
        {
            get { return _PartyCollection; }
            set { _PartyCollection = value; RaisePropertyChanged("PartyCollection"); }
        }

        private ICollectionView _ILDMasterCollection;
        public ICollectionView ILDMasterCollection
        {
            get { return _ILDMasterCollection; }
            set { _ILDMasterCollection = value; RaisePropertyChanged("ILDMasterCollection"); }
        }

        private ICollectionView _BallMakeCollection;
        public ICollectionView BallMakeCollection
        {
            get { return _BallMakeCollection; }
            set { _BallMakeCollection = value; RaisePropertyChanged("BallMakeCollection"); }
        }

        private ICollectionView _ItemCollection;
        public ICollectionView ItemCollection
        {
            get { return _ItemCollection; }
            set { _ItemCollection = value; RaisePropertyChanged("ItemCollection"); }
        }

        private ICollectionView _PkgUnitCollection;
        public ICollectionView PkgUnitCollection
        {
            get { return _PkgUnitCollection; }
            set { _PkgUnitCollection = value; RaisePropertyChanged("PkgUnitCollection"); }
        }

        private ICollectionView _BallTypeCollection;
        public ICollectionView BallTypeCollection
        {
            get { return _BallTypeCollection; }
            set { _BallTypeCollection = value; RaisePropertyChanged("BallTypeCollection"); }
        }

        private ICollectionView _ShiftCollection;
        public ICollectionView ShiftCollection
        {
            get { return _ShiftCollection; }
            set { _ShiftCollection = value; RaisePropertyChanged("ShiftCollection"); }
        }

        private ICollectionView _ProductDetailsCollection;
        public ICollectionView ProductDetailsCollection
        {
            get { return _ProductDetailsCollection; }
            set { _ProductDetailsCollection = value; RaisePropertyChanged("ProductDetailsCollection"); }
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

        #region StringLists

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

        List<string> _StringListProductionPlanning;
        public List<string> StringListProductionPlanning
        {
            get { return _StringListProductionPlanning; }
            set
            {
                if (_StringListProductionPlanning != value)
                {
                    _StringListProductionPlanning = value;
                }
            }
        }

        List<string> _StringListModelMaster;
        public List<string> StringListModelMaster
        {
            get { return _StringListModelMaster; }
            set
            {
                if (_StringListModelMaster != value)
                {
                    _StringListModelMaster = value;
                }
            }
        }

        List<string> _StringListINK;
        public List<string> StringListINK
        {
            get { return _StringListINK; }
            set
            {
                if (_StringListINK != value)
                {
                    _StringListINK = value;
                }
            }
        }

        List<string> _StringListWireMake;
        public List<string> StringListWireMake
        {
            get { return _StringListWireMake; }
            set
            {
                if (_StringListWireMake != value)
                {
                    _StringListWireMake = value;
                }
            }
        }

        List<string> _StringListWireSize;
        public List<string> StringListWireSize
        {
            get { return _StringListWireSize; }
            set
            {
                if (_StringListWireSize != value)
                {
                    _StringListWireSize = value;
                }
            }
        }

        List<string> _StringListParty;
        public List<string> StringListParty
        {
            get { return _StringListParty; }
            set
            {
                if (_StringListParty != value)
                {
                    _StringListParty = value;
                }
            }
        }

        List<string> _StringListILD;
        public List<string> StringListILD
        {
            get { return _StringListILD; }
            set
            {
                if (_StringListILD != value)
                {
                    _StringListILD = value;
                }
            }
        }

        List<string> _StringListBallMake;
        public List<string> StringListBallMake
        {
            get { return _StringListBallMake; }
            set
            {
                if (_StringListBallMake != value)
                {
                    _StringListBallMake = value;
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

        List<string> _StringListPkgUnit;
        public List<string> StringListPkgUnit
        {
            get { return _StringListPkgUnit; }
            set
            {
                if (_StringListPkgUnit != value)
                {
                    _StringListPkgUnit = value;
                }
            }
        }

        List<string> _StringListBallType;
        public List<string> StringListBallType
        {
            get { return _StringListBallType; }
            set
            {
                if (_StringListBallType != value)
                {
                    _StringListBallType = value;
                }
            }
        }

        #endregion

        #region Relay Commands Declaration

        #region Relay Commands Declaration : Ref Doc
        public RelayCommand<object> CMDInsertRef_DocType { get; private set; }
        public RelayCommand<object> CmdAddProductionPlanning { get; private set; }
        public RelayCommand<object> CmdAddMachine { get; private set; }
        #endregion

        #region Relay Commands Declaration : Product to Be Converted
        public RelayCommand<object> CmdAddModel { get; private set; }
        public RelayCommand<object> CmdAddINK { get; private set; }
        public RelayCommand<object> CmdAddWireMake { get; private set; }
        public RelayCommand<object> CmdAddWireSize { get; private set; }
        public RelayCommand<object> CmdAddParty { get; private set; }
        public RelayCommand<object> CmdAddILD { get; private set; }
        public RelayCommand<object> CmdAddBallMake { get; private set; }
        public RelayCommand<object> CmdAddItem { get; private set; }
        public RelayCommand<object> CmdAddPkgUnit { get; private set; }
        public RelayCommand<object> CmdAddBallType { get; private set; }
        public RelayCommand<object> CmdAddLocation { get; private set; }
        public RelayCommand<object> CmdAddCompCode { get; private set; }
        public RelayCommand<object> CmdAddFltrStatus { get; private set; }
        public RelayCommand<object> CmdAddFltrPlant { get; private set; }
        #endregion

        #region Relay Commands Declaration :Other Commands
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdFeedbackRpt { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CommandForLoadBackFlip { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CmdAttachment { get; private set; }
        public RelayCommand<object> CommandLoadHistory { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion
        #endregion

        #region Constructor
        public EPR_T001_VM_CON(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new EPR_T001_New();
            MasterEntityTemp = new EPR_T001_New();
            FlipGridData = new List<EPR_T001_Flip>();
            MC = new MultipleContext_EPR_T001_Conv();
            MCTemp = new MultipleContext_EPR_T001_Conv();
            MCTemp1 = new MultipleContext_EPR_T001_Conv();
            CurrentMachineCollection = new ObservableCollection<EPR_T001_P1>();
            ApprovalData = new List<ADM_M043_D>();
            MasterEntity.ValidateAsync().Wait();

            LoadInitialData();

           
                
                // if (AppSessionState.TransValue != null && AppSessionState.TransactionCode == MC.DocumentTypes[1].TranCode )
                //{
                //    LoadDocumentByDocumentNumber(AppSessionState.TransValue, "DocumentNo");
                //    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                //    AppSessionState.TransValue = null;
                //    AppSessionState.TransId = null;
                //    AppSessionState.TransParameter = null;
                //    AppSessionState.ViewOtherRecordAllowed = true;
                //}
               
         
        }
        public EPR_T001_VM_CON(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new EPR_T001_New();
            MasterEntityTemp = new EPR_T001_New();
            FlipGridData = new List<EPR_T001_Flip>();
            MC = new MultipleContext_EPR_T001_Conv();
            MCTemp = new MultipleContext_EPR_T001_Conv();
            MCTemp1 = new MultipleContext_EPR_T001_Conv();
            CurrentMachineCollection = new ObservableCollection<EPR_T001_P1>();
            ApprovalData = new List<ADM_M043_D>();
            MasterEntity.ValidateAsync().Wait();

            LoadInitialData();

        }
        #endregion

        #region LoadInitialData
        private void LoadInitialData()
        {
            try
            {
                MasterEntity.doc_type = "CN";
                MasterEntity.doc_cat = "CN";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T001_Conv>(MC, Request, "LoadConversionNote2_Data", "Production", "LoadInitialData", 0, "");

                #region .Command Initialisation .

                #region .Relay Command Initialisation : Ref Document .
                CMDInsertRef_DocType = new RelayCommand<object>(items => { if (items == null) { return; } Insert_RefDocType(items); });
                CmdAddProductionPlanning = new RelayCommand<object>(items => { if (items == null) { return; } InsertProductionPlanning(items); });
                CmdAddMachine = new RelayCommand<object>(items => { if (items == null) { return; } InsertMachine(items); });
                #endregion

                #region .Relay Command Initialisation : Product To Be Converted .

                CmdAddModel = new RelayCommand<object>(items => { if (items == null) { return; } InsertModel(items); });
                CmdAddINK = new RelayCommand<object>(items => { if (items == null) { return; } InsertINK(items); });
                CmdAddWireMake = new RelayCommand<object>(items => { if (items == null) { return; } InsertWireMake(items); });
                CmdAddWireSize = new RelayCommand<object>(items => { if (items == null) { return; } InsertWireSize(items); });
                CmdAddParty = new RelayCommand<object>(items => { if (items == null) { return; } InsertParty(items); });
                CmdAddILD = new RelayCommand<object>(items => { if (items == null) { return; } InsertILD(items); });
                CmdAddBallMake = new RelayCommand<object>(items => { if (items == null) { return; } InsertBallMake(items); });
                CmdAddItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertItem(items); });
                CmdAddPkgUnit = new RelayCommand<object>(items => { if (items == null) { return; } InsertPkgUnit(items); });
                CmdAddBallType = new RelayCommand<object>(items => { if (items == null) { return; } InsertBallType(items); });
                CmdAddLocation = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLocation(cmdPara); });
                CmdAddCompCode = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCompCode(cmdPara); });
                CmdAddFltrStatus = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrStatus(items); });
                CmdAddFltrPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertFltrPlant(items); });
                #endregion



                CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                cmdFeedbackRpt = new GalaSoft.MvvmLight.Command.RelayCommand(() => { FeedbackReport(); });
                CommandForLoadBackFlip = new GalaSoft.MvvmLight.Command.RelayCommand(Load);
                CmdAttachment = new GalaSoft.MvvmLight.Command.RelayCommand(LoadAttachmentRecord);
                CommandLoadHistory = new RelayCommand<object>(items => { if (items == null) { return; } LoadHistory(); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(MC.DocumentDataFlipGrid);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                #region AutoSuggest Initialisation

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M013_P)x).doc_type_user ?? "");
                TheFilter = (o, prefix) => (((SYS_M013_P)o).doc_type_user ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((SYS_M013_P)o).doc_desc_user ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASRefDocType = new AutoSuggestTextViewModel<dynamic>(MC.DocumentTypes, TheFilter, SuggestedValue, "ref_doc_type", true);
                ASRefDocType.AutoSuggestVM.IsEmptyValueAllowed = true;

                

                plantList = (List<ADM_M003>)AppSessionState.ADM_M003_List;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASLocation = new AutoSuggestTextViewModel<dynamic>(plantList, TheFilter, SuggestedValue, "location_Id", true);
                ASLocation.AutoSuggestVM.IsEmptyValueAllowed = true;



                CompanyList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M002)o).CompName ?? "").ToString().ToLower().Contains(prefix.ToLower()); ;
                ASCompCode = new AutoSuggestTextViewModel<dynamic>(CompanyList, TheFilter, SuggestedValue, "comp_code", true);
                ASCompCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                #region AutoSuggest Initialisation : Filters AutoSuggest

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASFltrStatus = new AutoSuggestTextViewModel<dynamic>(MC.t_StatusList, TheFilter, SuggestedValue, "t_display", true);
                ASFltrStatus.AutoSuggestVM.IsEmptyValueAllowed = true;

                plantList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASViewPlant = new AutoSuggestTextViewModel<dynamic>(plantList, TheFilter, SuggestedValue, "location_Id", true);
                ASViewPlant.AutoSuggestVM.IsEmptyValueAllowed = false;


                #endregion
                #endregion

                List<PPC_M001_P> TempMachineList_CN = (from o in MC.MachineList_CN
                                                       where o.location_Id == AppSessionState.location_Id
                                                       select o).ToList();

                MachineCollection = CollectionViewSource.GetDefaultView(TempMachineList_CN);
                MachineCollection.Filter = new Predicate<object>(MachineFilter);
                StringListMachine = TempMachineList_CN.Select(x => x.machinecode.ToString()).ToList();

                //MachineCollection = CollectionViewSource.GetDefaultView(MC.MachineList_CN);
                //MachineCollection.Filter = new Predicate<object>(MachineFilter);
                //StringListMachine = MC.MachineList_CN.Select(x => x.machinecode.ToString()).ToList();

                //ProductionPlanningCollection = CollectionViewSource.GetDefaultView(MC.ProductionPlanningList);
                //ProductionPlanningCollection.Filter = new Predicate<object>(ProductionPlanningFilter);
                //StringListProductionPlanning = MC.ProductionPlanningList.Select(x => x.plan_no).ToList();

                //var abc1 = (from o in MC.ProductionPlanningList where o.doc_type == "PP" select o).ToList();
                //ProductDetailsCollection = CollectionViewSource.GetDefaultView(abc1);
                //ProductDetailsCollection.Filter = new Predicate<object>(Filter);


                ModelMasterCollection = CollectionViewSource.GetDefaultView(MC.ModelMasterList);
                ModelMasterCollection.Filter = new Predicate<object>(ModelMasterFilter);
                StringListModelMaster = MC.ModelMasterList.Select(x => x.modelno).ToList();

                INKMasterCollection = CollectionViewSource.GetDefaultView(MC.INKMasterList);
                INKMasterCollection.Filter = new Predicate<object>(INKMasterFilter);
                StringListINK = MC.INKMasterList.Select(x => x.ink).ToList();

                WireMakeCollection = CollectionViewSource.GetDefaultView(MC.WireMakeList);
                WireMakeCollection.Filter = new Predicate<object>(WireMakeFilter);
                StringListWireMake = MC.WireMakeList.Select(x => x.Make).ToList();

                WireSizeCollection = CollectionViewSource.GetDefaultView(MC.WireSizeList);
                WireSizeCollection.Filter = new Predicate<object>(WireSizeFilter);
                StringListWireSize = MC.WireSizeList.Select(x => x.wire_size.ToString()).ToList();

                PartyCollection = CollectionViewSource.GetDefaultView(MC.PartyList);
                PartyCollection.Filter = new Predicate<object>(PartyFilter);
                StringListParty = MC.PartyList.Select(x => x.PartyNm).ToList();

                ILDMasterCollection = CollectionViewSource.GetDefaultView(MC.ILDMasterList);
                ILDMasterCollection.Filter = new Predicate<object>(ILDMasterFilter);
                StringListILD = MC.ILDMasterList.Select(x => x.ild).ToList();

                BallMakeCollection = CollectionViewSource.GetDefaultView(MC.BallMakeList);
                BallMakeCollection.Filter = new Predicate<object>(BallMakeFilter);
                StringListBallMake = MC.BallMakeList.Select(x => x.Make).ToList();

                ItemCollection = CollectionViewSource.GetDefaultView(MC.ItemList);
                ItemCollection.Filter = new Predicate<object>(ItemFilter);
                StringListItem = MC.ItemList.Select(x => x.ItemName).ToList();

                PkgUnitCollection = CollectionViewSource.GetDefaultView(MC.PkgUnitList);
                PkgUnitCollection.Filter = new Predicate<object>(PkgUnitFilter);
                StringListPkgUnit = MC.PkgUnitList.Select(x => x.unit_code).ToList();

                BallTypeCollection = CollectionViewSource.GetDefaultView(MC.BallTypeList);
                BallTypeCollection.Filter = new Predicate<object>(PkgUnitFilter);
                StringListBallType = MC.BallTypeList.Select(x => x.ball_type).ToList();

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

        #region Filters

        #region Filter for Back Content Datagrid
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
            if (_DataGridCollection != null)
            {
                _DataGridCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as EPR_T001_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return ((data.order_no != null) && data.order_no.ToLower().Contains(_filterString.ToLower()) ||
                            (data.ItemCode != null) && data.ItemCode.ToLower().Contains(_filterString.ToLower()) ||
                            (data.ItemName != null) && data.ItemName.ToLower().Contains(_filterString.ToLower()) ||
                            (data.machinecode != null) && data.machinecode.ToLower().Contains(_filterString.ToLower()) ||
                            (data.start_dt != null) && data.start_dt.ToString().Contains(_filterString.ToLower()) ||
                            (data.prod_plan != null) && data.prod_plan.ToLower().Contains(_filterString.ToLower()) ||
                            (data.id != null) && data.id.ToString().Contains(_filterString.ToLower())
                            );

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
            var data = obj as PPC_M001_P;
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

        #region Filters For ProductionPlanning
        private string _filterStringProductionPlanning;
        private void FilterCollectionProductionPlanning()
        {
            if (_ProductionPlanningCollection != null)
            {
                _ProductionPlanningCollection.Refresh();
            }
        }
        public string FilterStringProductionPlanning
        {
            get { return _filterStringProductionPlanning; }
            set
            {
                _filterStringProductionPlanning = value;
                RaisePropertyChanged("FilterStringProductionPlanning");
                FilterCollectionProductionPlanning();
            }
        }
        public bool ProductionPlanningFilter(object obj)
        {
            var data = obj as PPC_T004_A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringProductionPlanning))
                {
                    return ((data.ItemCode != null) && data.ItemCode.ToString().ToLower().Contains(_filterStringProductionPlanning.ToLower()) ||
                            (data.ItemName != null) && data.ItemName.ToString().ToLower().Contains(_filterStringProductionPlanning.ToLower()) ||
                            (data.machine_id != null) && data.machine_id.ToString().ToLower().Contains(_filterStringProductionPlanning.ToLower()) ||
                            (data.machine_no != null) && data.machine_no.ToString().ToLower().Contains(_filterStringProductionPlanning.ToLower()) ||
                            (data.para1 != null) && data.para1.ToLower().Contains(_filterStringProductionPlanning.ToLower()) ||
                            (data.para10 != null) && data.para10.ToLower().Contains(_filterStringProductionPlanning.ToLower()) ||
                            (data.para2 != null) && data.para2.ToLower().Contains(_filterStringProductionPlanning.ToLower()) ||
                            (data.para3 != null) && data.para3.ToLower().Contains(_filterStringProductionPlanning.ToLower()) ||
                            (data.para4 != null) && data.para4.ToLower().Contains(_filterStringProductionPlanning.ToLower()) ||
                            (data.para5 != null) && data.para5.ToLower().Contains(_filterStringProductionPlanning.ToLower()) ||
                            (data.para6 != null) && data.para6.ToLower().Contains(_filterStringProductionPlanning.ToLower()) ||
                            (data.para7 != null) && data.para7.ToLower().Contains(_filterStringProductionPlanning.ToLower()) ||
                            (data.para8 != null) && data.para8.ToLower().Contains(_filterStringProductionPlanning.ToLower()) ||
                            (data.para9 != null) && data.para9.ToLower().Contains(_filterStringProductionPlanning.ToLower()) ||
                            (data.plan_date != null) && data.plan_date.ToString().ToLower().Contains(_filterStringProductionPlanning.ToLower()) ||
                            (data.plan_no != null) && data.plan_no.ToString().ToLower().Contains(_filterStringProductionPlanning.ToLower()) ||
                            (data.plan_qty != null) && data.plan_qty.ToString().Contains(_filterStringProductionPlanning.ToLower()) ||
                            (data.sales_order_no != null) && data.sales_order_no.ToString().ToLower().Contains(_filterStringProductionPlanning.ToLower()) ||
                            (data.unit_code != null) && data.unit_code.ToString().ToLower().Contains(_filterStringProductionPlanning.ToLower())
                            );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For ModelMaster
        private string _filterStringModelMaster;
        private void FilterCollectionModelMaster()
        {
            if (_ModelMasterCollection != null)
            {
                _ModelMasterCollection.Refresh();
            }
        }
        public string FilterStringModelMaster
        {
            get { return _filterStringModelMaster; }
            set
            {
                _filterStringModelMaster = value;
                RaisePropertyChanged("FilterStringModelMaster");
                FilterCollectionModelMaster();
            }
        }
        public bool ModelMasterFilter(object obj)
        {
            var data = obj as ZADM_M009_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringModelMaster))
                {
                    return ((data.modeldesc != null) && data.modeldesc.ToLower().Contains(_filterStringModelMaster.ToLower()) ||
                        (data.modelno != null) && data.modelno.ToLower().Contains(_filterStringModelMaster.ToLower()) ||
                        (data.model_id != null) && data.model_id.ToString().Contains(_filterStringModelMaster.ToLower()) ||
                        (data.basicmodel != null) && data.basicmodel.ToLower().Contains(_filterStringModelMaster.ToLower())
                        );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For INKMaster
        private string _filterStringINK;
        private void FilterCollectionINK()
        {
            if (_INKMasterCollection != null)
            {
                _INKMasterCollection.Refresh();
            }
        }
        public string FilterStringINK
        {
            get { return _filterStringINK; }
            set
            {
                _filterStringINK = value;
                RaisePropertyChanged("FilterStringINKMaster");
                FilterCollectionINK();
            }
        }
        public bool INKMasterFilter(object obj)
        {
            var data = obj as ZADM_M006_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringINK))
                {
                    return ((data.desc != null) && data.desc.ToLower().Contains(_filterStringINK.ToLower()) ||
                            (data.ink != null) && data.ink.ToLower().Contains(_filterStringINK.ToLower()) ||
                            (data.ink_id != null) && data.ink_id.ToString().Contains(_filterStringINK.ToLower()) ||
                            (data.make != null) && data.make.ToString().Contains(_filterStringINK.ToLower())
                           );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter For WireMake
        private string _filterStringWireMake;
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
        private void FilterCollectionWireMake()
        {
            if (_WireMakeCollection != null)
            {
                _WireMakeCollection.Refresh();
            }
        }
        public bool WireMakeFilter(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringWireMake))
                {
                    return ((data.Make != null) && data.Make.ToLower().Contains(_filterStringWireMake.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For WireSize
        private string _filterStringWireSize;
        public string FilterStringWireSize
        {
            get { return _filterStringWireSize; }
            set
            {
                _filterStringWireSize = value;
                RaisePropertyChanged("FilterStringWireSize");
                FilterCollectionWireSize();
            }
        }
        private void FilterCollectionWireSize()
        {
            if (_WireSizeCollection != null)
            {
                _WireSizeCollection.Refresh();
            }
        }
        public bool WireSizeFilter(object obj)
        {
            var data = obj as ZADM_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringWireSize))
                {
                    return ((data.wire_size.ToString() != null) && data.wire_size.ToString().Contains(_filterStringWireSize));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Party
        private string _filterStringParty;
        private void FilterCollectionParty()
        {
            if (_PartyCollection != null)
            {
                _PartyCollection.Refresh();
            }
        }
        public string FilterStringParty
        {
            get { return _filterStringParty; }
            set
            {
                _filterStringParty = value;
                RaisePropertyChanged("FilterStringParty");
                FilterCollectionParty();
            }
        }
        public bool PartyFilter(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringParty))
                {
                    return ((data.PartyId != null) && data.PartyId.ToLower().Contains(_filterStringParty.ToLower()) ||
                            (data.PartyNm != null) && data.PartyNm.ToLower().Contains(_filterStringParty.ToLower())
                           );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For ILDMaster
        private string _filterStringILD;
        private void FilterCollectionILD()
        {
            if (_ILDMasterCollection != null)
            {
                _ILDMasterCollection.Refresh();
            }
        }
        public string FilterStringILD
        {
            get { return _filterStringILD; }
            set
            {
                _filterStringILD = value;
                RaisePropertyChanged("FilterStringILDMaster");
                FilterCollectionILD();
            }
        }
        public bool ILDMasterFilter(object obj)
        {
            var data = obj as ZADM_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringILD))
                {
                    return ((data.ild != null) && data.ild.ToLower().Contains(_filterStringILD.ToLower()) ||
                            (data.ild_id != null) && data.ild_id.ToString().Contains(_filterStringILD.ToLower()) ||
                            (data.desc != null) && data.desc.ToString().Contains(_filterStringILD.ToLower()) ||
                            (data.ild_type != null) && data.ild_type.ToString().Contains(_filterStringILD.ToLower()) ||
                            (data.show_ild != null) && data.show_ild.ToString().Contains(_filterStringILD.ToLower()) ||
                            (data.tip_type != null) && data.tip_type.ToString().Contains(_filterStringILD.ToLower())
                            );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For BallMake
        private string _filterStringBallMake;
        private void FilterCollectionBallMake()
        {
            if (_BallMakeCollection != null)
            {
                _BallMakeCollection.Refresh();
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
        public bool BallMakeFilter(object obj)
        {
            var data = obj as ADM_M032_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringBallMake))
                {
                    return ((data.Make != null) && data.Make.ToLower().Contains(_filterStringBallMake.ToLower()) ||
                            (data.MakeCode != null) && data.MakeCode.ToString().Contains(_filterStringBallMake.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Item
        private string _filterStringItem;
        private void FilterCollectionItem()
        {
            if (_ItemCollection != null)
            {
                _ItemCollection.Refresh();
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
        public bool ItemFilter(object obj)
        {
            var data = obj as ADM_M022_P_ESSEM;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringItem))
                {
                    return ((data.ItemCode != null) && data.ItemCode.ToLower().Contains(_filterStringItem.ToLower()) ||
                            (data.ItemName != null) && data.ItemName.ToLower().Contains(_filterStringItem.ToLower()) ||
                            (data.prdct_code != null) && data.prdct_code.ToLower().Contains(_filterStringItem.ToLower())
                            );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For PkgUnit
        private string _filterStringPkgUnit;
        private void FilterCollectionPkgUnit()
        {
            if (_PkgUnitCollection != null)
            {
                _PkgUnitCollection.Refresh();
            }
        }
        public string FilterStringPkgUnit
        {
            get { return _filterStringPkgUnit; }
            set
            {
                _filterStringPkgUnit = value;
                RaisePropertyChanged("FilterStringPkgUnit");
                FilterCollectionPkgUnit();
            }
        }
        public bool PkgUnitFilter(object obj)
        {
            var data = obj as ZADM_M017_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringPkgUnit))
                {
                    return ((data.pkgunit != null) && data.pkgunit.ToLower().Contains(_filterStringPkgUnit.ToLower()) ||
                            (data.unit_code != null) && data.unit_code.ToLower().Contains(_filterStringPkgUnit.ToLower())
                            );
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Ball Type
        private string _filterStringBallType;
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
        private void FilterCollectionBallType()
        {
            if (_BallTypeCollection != null)
            {
                _BallTypeCollection.Refresh();
            }
        }
        public bool BallTypeFilter(object obj)
        {
            var data = obj as ZADM_M002_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringBallType))
                {
                    return ((data.ball_type != null) && data.ball_type.ToLower().Contains(_filterStringBallType.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion
        #endregion

        #region User Defined Functions

        #region User Defined Functions : Ref Document

        private void InsertMachine(object InputValue)
        {
            try
            {
                string Request = "";
                string RequestParameterData = "";
               PPC_M001_P POPUPEntityObject = null;
                if ((MasterEntity.status == "001" || MasterEntity.status == "Draft")
                    || (MasterEntity.status == "004" || MasterEntity.status == "Open")
                    || MasterEntity.status == "" || MasterEntity.status == null)
                {

                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            {
                                POPUPEntityObject = MC.MachineList_CN.Where(x => x.machinecode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.location_Id.Equals(MasterEntity.location_Id, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }

                            catch (Exception ex)
                            {
                            }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<PPC_M001_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PPC_M001_P>().ToList()[0];
                    }

                    if (POPUPEntityObject != null)
                    {

                        MasterEntity.machinecode = POPUPEntityObject.machinecode;
                        MasterEntity.machine_id = POPUPEntityObject.machine_id;
                        MasterEntity.wc_code = POPUPEntityObject.wc_code;


                        List<EPR_T001_New> TempCurrentMachineList = (from o in MC.MasterEntityPrev
                                                                     where o.machine_id == POPUPEntityObject.machine_id
                                                                     && o.machinecode == POPUPEntityObject.machinecode
                                                                     select o).ToList();

                        List<EPR_T001_New> CurrentMachineList = new List<EPR_T001_New>();

                        if (TempCurrentMachineList.Count > 0)
                        {
                            EPR_T001_New CurrentMachineList2 = TempCurrentMachineList.OrderByDescending(m => m.id).First();
                            CurrentMachineList.Add(CurrentMachineList2);
                            MasterEntity.pre_order_no = CurrentMachineList2.order_no;
                        }
               
                        CurrentProductCollection = CollectionViewSource.GetDefaultView(CurrentMachineList);

                        //--------- OLD CODE => SERVER TRIP-------
                        //Request = "LoadPreviousMachine" + "!@" + MasterEntity.machine_id + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                        //MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_EPR_T001_Conv>(MCTemp, Request, "ConversionNote2", "Production", "LoadMachineDetail", 0, "");
                        //if (MCTemp.MasterEntityPrev.Count > 0)
                        //{
                        //    MasterEntityTemp = MCTemp.MasterEntityPrev[0];
                        //}
                    }

                }

                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "You Can not Changed Machine While Running";
                    //showMessageService.Text = String.Format(ex.Message, this.Title);
                    showMessageService.ShowMessage();
                }
                var msg = new NotificationMessage("EPR_T001_VM_CON");
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex)
            {
                //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //showMessageService.ButtonSetup = DialogButton.Ok;
                //showMessageService.Caption = "Message";
                //showMessageService.Text = String.Format(ex.Message, this.Title);
                //showMessageService.ShowMessage();
            }


        }
        private void InsertProductionPlanning(object InputValue)
        {
            try
            {
                string Request = "";
                string RequestParameterData = "";
                PPC_T004_A_P POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ProductionPlanningList.Where(x => x.plan_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<PPC_T004_A_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PPC_T004_A_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.prod_plan = POPUPEntityObject.plan_no;
                    MasterEntity.plan_item_row_id = POPUPEntityObject.plan_item_row_id;

                    if (string.IsNullOrWhiteSpace(POPUPEntityObject.para1))
                    {
                        MasterEntity.ink_id = null;  
                    }
                    else
                    {

                        MasterEntity.ink_id = Convert.ToInt32(POPUPEntityObject.para1);
                        //MasterEntity.ink_id = Int32.Parse(POPUPEntityObject.para1);
                    }
                    MasterEntity.ink = (from o in MC.INKMasterList where o.ink_id == MasterEntity.ink_id select o.ink).FirstOrDefault();

                    if (string.IsNullOrWhiteSpace(POPUPEntityObject.para5))
                    {
                        MasterEntity.ild_id = null;
                    }
                    else
                    {
                        MasterEntity.ild_id = Convert.ToInt32(POPUPEntityObject.para5);
                    }
                    // else
                    //{
                    //    MasterEntity.ild_id = Int32.Parse(POPUPEntityObject.para5);
                    //}
                    MasterEntity.ild = (from o in MC.ILDMasterList where o.ild_id == MasterEntity.ild_id select o.ild).FirstOrDefault();

                    MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                    MasterEntity.ItemName = POPUPEntityObject.ItemName;

                    MasterEntity.machine_id = Convert.ToInt32(POPUPEntityObject.machine_id);
                    MasterEntity.machinecode = POPUPEntityObject.machine_no;
                    MasterEntity.wc_code  = POPUPEntityObject.wc_code;

                    MasterEntity.unit_code = POPUPEntityObject.unit_code;
                    MasterEntity.qty = POPUPEntityObject.plan_qty;
                    MasterEntity.total_len = POPUPEntityObject.total_len;

                    if (string.IsNullOrWhiteSpace( POPUPEntityObject.para4 ))
                    {
                        MasterEntity.model_id = 0;
                    }
                    else
                    {
                        MasterEntity.model_id = Convert.ToInt32(POPUPEntityObject.para4);
                    }

                    if (string.IsNullOrWhiteSpace(POPUPEntityObject.para2))
                    {
                        MasterEntity.wire_make_id = null;
                    }
                    else
                    {
                        MasterEntity.wire_make_id = Convert.ToInt32(POPUPEntityObject.para2);
                    }
                    MasterEntity.wire_make = (from o in MC.WireMakeList where o.MakeCode == MasterEntity.wire_make_id select o.Make).FirstOrDefault();

                    if (string.IsNullOrWhiteSpace(POPUPEntityObject.para8 ))
                    {
                        MasterEntity.wire_size_id = null;
                    }
                    else
                    {
                        MasterEntity.wire_size_id = Convert.ToInt32(POPUPEntityObject.para8);
                    }
                    MasterEntity.wire_size = (from o in MC.WireSizeList  where o.wire_size_id  == MasterEntity.wire_size_id  select o.wire_size).FirstOrDefault();


                    if (string.IsNullOrWhiteSpace(POPUPEntityObject.para3))
                    {
                        MasterEntity.ball_make_id = null;
                    }
                    else
                    {
                        MasterEntity.ball_make_id = Convert.ToInt32(POPUPEntityObject.para3);
                    }
                    MasterEntity.ball_make = (from o in MC.BallMakeList where o.MakeCode == MasterEntity.ball_make_id select o.Make).FirstOrDefault();

                   
                    MasterEntity.ball_dia = POPUPEntityObject.para6;

                    if (string.IsNullOrWhiteSpace(POPUPEntityObject.para7))
                    {
                        MasterEntity.ball_type_id = null; 
                    }
                    else
                    {
                        MasterEntity.ball_type_id = Convert.ToInt32(POPUPEntityObject.para7);
                    }
                    MasterEntity.ball_type = (from o in MC.BallTypeList  where o.ball_type_id == MasterEntity.ball_type_id select o.ball_type).FirstOrDefault();

                    MasterEntity.model_code = POPUPEntityObject.para9;

                    MasterEntity.lifeTest = POPUPEntityObject.lifeTest;
                    MasterEntity.TestDone = POPUPEntityObject.TestDone;

                    MasterEntity.PartyId = POPUPEntityObject.PartyId;
                    MasterEntity.PartyName = POPUPEntityObject.PartyNm ;

                    MasterEntity.location_Id = POPUPEntityObject.location_Id;
                    MasterEntity.comp_code  = POPUPEntityObject.comp_code;
                    MasterEntity.pre_order_no = POPUPEntityObject.pre_order_no;
                    //MasterEntity.PackingUnit  = POPUPEntityObject.PackingUnit;
                    // MasterEntity.tds_no = POPUPEntityObject.tds;


                    #region *** OLD CODE :  IT SHOULD BE DELETED AFTER SUCCESSFUL LIVE TESTING AT CLIENT SIDE ***
                    //MasterEntity.ink_id = POPUPEntityObject.ink_id;
                    //MasterEntity.ink = POPUPEntityObject.para1;

                    //MasterEntity.ild_id = POPUPEntityObject.ild_id;
                    //MasterEntity.ild = POPUPEntityObject.para5;

                    //MasterEntity.wire_make_id = POPUPEntityObject.wire_make_id;
                    //MasterEntity.wire_make = POPUPEntityObject.para2;

                    //MasterEntity.ball_make_id = POPUPEntityObject.ball_make_id;
                    //MasterEntity.ball_make = POPUPEntityObject.para3;

                    //MasterEntity.ball_type_id = POPUPEntityObject.ball_type_id;
                    //MasterEntity.ball_type = POPUPEntityObject.para7;

                    //MasterEntity.wire_size_id = POPUPEntityObject.wire_size_id;
                    //MasterEntity.wire_size = Convert.ToDecimal(POPUPEntityObject.para8);
                    #endregion

                    List<EPR_T001_New> TempCurrentMachineList = (from o in MC.MasterEntityPrev
                                                             where o.machine_id == POPUPEntityObject.machine_id
                                                             && o.machinecode == POPUPEntityObject.machine_no
                                                             select o).ToList();

                    List<EPR_T001_New> CurrentMachineList = new List<EPR_T001_New> ();

                    if (TempCurrentMachineList.Count > 0)
                    {
                        EPR_T001_New CurrentMachineList2 = TempCurrentMachineList.OrderByDescending(m => m.id).First();
                        CurrentMachineList.Add(CurrentMachineList2);
                        MasterEntity.pre_order_no = CurrentMachineList2.order_no;
                    }

                    CurrentProductCollection = CollectionViewSource.GetDefaultView( CurrentMachineList);

                    //--------- OLD CODE => SERVER TRIP-------
                    //Request = "LoadPreviousMachine" + "!@" + MasterEntity.machine_id + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                    //MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_EPR_T001_Conv>(MCTemp, Request, "ConversionNote2", "Production", "LoadMachineDetail", 0, "");
                    //if (MCTemp.MasterEntityPrev.Count > 0)
                    //{
                    //    MasterEntityTemp = MCTemp.MasterEntityPrev[0];

                    //}

                    ProductDetailsCollection = CollectionViewSource.GetDefaultView(MC.ProductionPlanningList.Where(X => X.plan_no == MasterEntity.prod_plan  ).ToList());
                    ProductDetailsCollection.Refresh();
                }
                var msg = new NotificationMessage("EPR_T001_VM_CON");
                Messenger.Default.Send<NotificationMessage>(msg);
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

        private void Insert_RefDocType(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M013_P POPUPEntityObject = null;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
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
                    if (((IEnumerable)InputValue).Cast<SYS_M013_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M013_P>().ToList()[0];
                    }
                }

                #endregion
                if (POPUPEntityObject != null)
                {
                   
                    MasterEntity.ref_doc_type = POPUPEntityObject.doc_type_user;

                    if (MasterEntity.ref_doc_type == "CN")
                    {

                        var abc = (from o in MC.ProductionPlanningList where o.doc_type == "CN" select o).ToList();
                        //ProductDetailsCollection = CollectionViewSource.GetDefaultView(abc);
                        //ProductDetailsCollection.Filter = new Predicate<object>(Filter);
                        //StringListRefDocNo = abc.Select(x => x.batch_no).ToList();

                        ProductionPlanningCollection = CollectionViewSource.GetDefaultView(abc);
                        ProductionPlanningCollection.Filter = new Predicate<object>(ProductionPlanningFilter);
                        StringListProductionPlanning = MC.ProductionPlanningList.Select(x => x.plan_no).ToList();

                    }
                    else
                    {
                        var abc = (from o in MC.ProductionPlanningList where o.doc_type == "PP" select o).ToList();
                        //ProductDetailsCollection = CollectionViewSource.GetDefaultView(abc);
                        //ProductDetailsCollection.Filter = new Predicate<object>(Filter);
                        //   StringListRefDocNo = abc.Select(x => x.batch_no).ToList();

                        ProductionPlanningCollection = CollectionViewSource.GetDefaultView(abc);
                        ProductionPlanningCollection.Filter = new Predicate<object>(ProductionPlanningFilter);
                        StringListProductionPlanning = MC.ProductionPlanningList.Select(x => x.plan_no).ToList();

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
        #endregion

        #region User Defined Functions : Other

        private void DefaultValues()
        {
            MasterEntity.doc_cat = "CN";
            MasterEntity.doc_type = "CN";
            MasterEntity.order_type = "N";
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.start_dt = DateTime.Now;
            MasterEntity.pro_dt = DateTime.Now;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.active = true;
            MasterEntity.appr = true;
            MasterEntity.status = "001";
            MasterEntity.t_display = (from o in MC.t_StatusList where o.t_status == MasterEntity.status select o.t_display).FirstOrDefault();
            MasterEntity.Fltr_FrmDate  = DateTime.Now;
            MasterEntity.Fltr_ToDate  = DateTime.Now;
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;

        }
        private bool Validation()
        {

            if (MasterEntity.machinecode == null || MasterEntity.machinecode == "" || MasterEntity.machine_id==0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Machine Code... ");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.ink == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Ink... ");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.ild == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Ild... ");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.lifeTest == true && MasterEntity.TestDone == false) //MasterEntity.lifeTest == false && MasterEntity.TestDone == false ||
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Unable Save Conversion Note While LifeTest/Writting Test is Not Done");
                showMessageService.ShowMessage();
                return false;

            }
            if (MasterEntity.lifeTest == true && MasterEntity.TestDone == true || MasterEntity.TestDone == true && MasterEntity.lifeTest == false)
            {

            }
            return true;
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                EPR_T001_Flip ParameterEntityObject = null;
                MasterEntity = new EPR_T001_New();

                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterObject;
                }
                else if (((IEnumerable)ParameterObject).Cast<EPR_T001_Flip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<EPR_T001_Flip>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.order_no + "!@" + ParameterEntityObject.pre_order_no + "!@" + ParameterEntityObject.machine_id + "!@" + ParameterEntityObject.ItemCode;
                }
                if (Request != "")
                {
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_EPR_T001_Conv>(MCTemp, Request, "LoadConversionNote2_Data", "Production", "LoadDocumentByDocumentNumber", 0, "");

                    MasterEntity = MCTemp.MasterEntity[0];

                    if (MCTemp.MasterEntityPrev.Count  > 0)
                    {
                        CurrentProductCollection = CollectionViewSource.GetDefaultView(MCTemp.MasterEntityPrev.ToList());
                    }

                    ApprovalData = MCTemp.ApprovalData;
                    //  MasterEntityTemp = MCTemp.MasterEntityPrev[0];

                    AttachmentCollection = MCTemp.AttachmentData;
                    if (MCTemp.AttachmentData != null)
                    {
                        AttachmentCollection = MCTemp.AttachmentData;
                        MC.AttachmentData = MCTemp.AttachmentData;
                    }
                    else
                    {
                        MCTemp.AttachmentData = new List<COM_T003>();
                    }

                    isNewRecord = false;
                    SelectedTabControlIndex = 0;
                    MasterEntity.ts_code = ts_code_vm;
                    ProductDetailsCollection = CollectionViewSource.GetDefaultView(MC.ProductionPlanningList.Where(X => X.plan_no == MasterEntity.prod_plan ).ToList());
                    ProductDetailsCollection.Refresh();
                }
                var msg = new NotificationMessage("EPR_T001_VM_CON");
                Messenger.Default.Send<NotificationMessage>(msg);
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
            try
            {
                MasterEntity.ts_code = ts_code_vm;
                if (MasterEntity.XmlDataDocument_EPR_T001_Flip != null  && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<EPR_T001_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_EPR_T001_Flip, MC.DocumentDataFlipGrid);
                    if (MC.DocumentDataFlipGrid.Count > 0)
                    {
                        FlipGridData.Add(MC.DocumentDataFlipGrid[0]);

                        DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                        DataGridCollection.Filter = new Predicate<object>(Filter);
                        DataGridCollection.Refresh();
                       // DataGridCollection.SortDescriptions.Add(new SortDescription("order_no", ListSortDirection.Descending));
                    }  
                }
                var msg = new NotificationMessage("EPR_T001_VM_CON");
                Messenger.Default.Send<NotificationMessage>(msg);
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
        private void FeedbackReport()
        {
            if ((MasterEntity.prod_plan == null || MasterEntity.prod_plan == " ") && MasterEntity.PartyId == null || MasterEntity.PartyId == " ")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Select Either plann no. or Customer....", this.Title);
                showMessageService.ShowMessage();
            }
            else
            {
                if (MasterEntity.prod_plan != null && MasterEntity.prod_plan != " ")
                {
                    string Request = "LoadFeedbackRpt" + "!@" + MasterEntity.prod_plan + "!@" + MasterEntity.ItemCode + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTemp, Request, "LoadConversionNote2_Data", "Production", "", 0, "FeedBack ");
                    RptFeedback = MCTemp.RptFeedback;

                    if (RptFeedback.Count > 0)
                    {
                        object[] objDataSource = new object[3];
                        string[] objDataSourceName = new string[3];

                        objDataSource[0] = MCTemp.RptFeedback;

                        objDataSourceName[0] = "dsFeedbackRpt";
                        ReportManager ReportManager = new ReportManager();
                        ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\QualityFeedBack.rdlc", "FeedBack");
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Their is no feedback....", this.Title);
                        showMessageService.ShowMessage();
                    }
                }

                else if (MasterEntity.PartyId != null || MasterEntity.PartyId != " ")
                {
                    if (MasterEntity.ItemCode == null || MasterEntity.ItemCode == " ")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please select Product...", this.Title);
                        showMessageService.ShowMessage();
                    }
                    else
                    {
                        string Request = "LoadFeedbackRpt2" + "!@" + MasterEntity.PartyId + "!@" + MasterEntity.ItemCode + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                        MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_EPR_T001>(MCTemp, Request, "LoadConversionNote2_Data", "Production", "", 0, "FeedBack ");
                        RptFeedback = MCTemp.RptFeedback;
                        if (RptFeedback.Count > 0)
                        {
                            object[] objDataSource = new object[3];
                            string[] objDataSourceName = new string[3];

                            objDataSource[0] = MCTemp.RptFeedback;

                            objDataSourceName[0] = "dsFeedbackRpt";
                            ReportManager ReportManager = new ReportManager();
                            ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\CRM\\QualityFeedBack.rdlc", "FeedBack");
                        }
                        else
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Their is no feedback....", this.Title);
                            showMessageService.ShowMessage();
                        }

                    }
                }
            }
        }
        private void Load()
        {
            if (MasterEntity.Fromdate != null && MasterEntity.ToDate != null)
            {
                if (MasterEntity.temp_status != null && MasterEntity.temp_status != "")
                {
                    string Request = "LoadFromDateToDate" + "!@" + Convert.ToDateTime(MasterEntity.Fromdate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.ToDate).ToString("MM/dd/yyyy") + "!@" + MasterEntity.temp_status + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_EPR_T001_Conv>(MCTemp, Request, "ConversionNote2", "Production", "LoadFromDateToDate", 0, "");

                    FlipGridData = MCTemp.DocumentDataFlipGrid.ToList();
                    DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                    DataGridCollection.Filter = new Predicate<object>(Filter);
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Status....", this.Title);
                    showMessageService.ShowMessage();
                }
            }
        }
        private void LoadAttachmentRecord()
        {
            if (!string.IsNullOrEmpty(MasterEntity.ItemCode))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.ItemCode.Replace("/", "--"), DocumentList = MCTemp.AttachmentData, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
            }
        }
        private void LoadHistory()
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadHistory" + "!@" + MasterEntity.Fltr_location_Id + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.EmpId + "!@" + Convert.ToDateTime(MasterEntity.Fltr_FrmDate).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.Fltr_ToDate).ToString("MM/dd/yyyy") + "!@" + MasterEntity.Fltr_t_status + "!@" + AppSessionState.client;
                MCTemp1 = repository_MC.GetDataWithReturnDomainObject<MultipleContext_EPR_T001_Conv>(MCTemp, Request, "LoadConversionNote2_Data", "Production", "LoadHistory", 0, "");

                MC.DocumentDataFlipGrid = MCTemp1.DocumentDataFlipGrid;
                DataGridCollection = CollectionViewSource.GetDefaultView(MC.DocumentDataFlipGrid);
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

        #region User Defined Functions : Product To Be Converted Tab

        private void InsertModel(object InputValue)
        {
            try
            {
                string Request = "";
                string RequestParameterData = "";
                ZADM_M009_P POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ModelMasterList.Where(x => x.modeldesc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M009_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M009_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.model_id = POPUPEntityObject.model_id;
                    MasterEntity.model_code = POPUPEntityObject.modelno;
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
        private void InsertINK(object InputValue)
        {
            try
            {
                string Request = "";
                string RequestParameterData = "";
                ZADM_M006_P POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.INKMasterList.Where(x => x.ink.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M006_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M006_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.ink = POPUPEntityObject.ink;
                    MasterEntity.ink_id = POPUPEntityObject.ink_id;
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
        private void InsertWireMake(object InputValue)
        {
            try
            {
                string Request = "";
                string RequestParameterData = "";
                ADM_M032_P POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WireMakeList.Where(x => x.Make.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M032_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M032_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.wire_make = POPUPEntityObject.Make;
                    MasterEntity.wire_make_id = POPUPEntityObject.MakeCode;
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
        private void InsertWireSize(object InputValue)
        {
            string Request = "";
            string RequestParameterData = "";
            ZADM_M003_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WireSizeList.Where(x => x.wire_size.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M003_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M003_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.wire_size = POPUPEntityObject.wire_size;
                    MasterEntity.wire_size_id = POPUPEntityObject.wire_size_id;
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
        private void InsertParty(object InputValue)
        {
            try
            {
                string Request = "";
                string RequestParameterData = "";
                ADM_M028_P POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PartyList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.PartyId = POPUPEntityObject.PartyId;
                    MasterEntity.PartyName = POPUPEntityObject.PartyNm;
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
        private void InsertILD(object InputValue)
        {
            try
            {
                string Request = "";
                string RequestParameterData = "";
                ZADM_M007_P POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ILDMasterList.Where(x => x.ild.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M007_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M007_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ild = POPUPEntityObject.ild;
                    MasterEntity.ild_id = POPUPEntityObject.ild_id;
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
        private void InsertBallMake(object InputValue)
        {
            try
            {
                string Request = "";
                string RequestParameterData = "";
                ADM_M032_P POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BallMakeList.Where(x => x.Make.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M032_P>().ToList().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M032_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ball_make = POPUPEntityObject.Make;
                    MasterEntity.ball_make_id = POPUPEntityObject.MakeCode;
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
        private void InsertItem(object InputValue)
        {

            try
            {
                string Request = "";
                string RequestParameterData = "";
                ADM_M022_P_ESSEM POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {


                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ItemList.Where(x => x.ItemName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M022_P_ESSEM>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P_ESSEM>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                    MasterEntity.ItemName = POPUPEntityObject.ItemName;
                    MasterEntity.shank_len = POPUPEntityObject.shanklen;
                    MasterEntity.needle_dia = POPUPEntityObject.needledia;
                    MasterEntity.needle = POPUPEntityObject.needlelen;
                    MasterEntity.ball_dia = POPUPEntityObject.ball_dia.ToString();
                    MasterEntity.ball_type = POPUPEntityObject.ball_type;
                    MasterEntity.lifeTest = POPUPEntityObject.lifeTest;
                    MasterEntity.TestDone = POPUPEntityObject.TestDone;

                    if (MasterEntity.model_id == null || MasterEntity.model_id == 0)
                    {
                        MasterEntity.model_id = POPUPEntityObject.Model_id;
                        MasterEntity.model_code = POPUPEntityObject.ModelCode;
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
        private void InsertPkgUnit(object InputValue)
        {
            try
            {
                string Request = "";
                string RequestParameterData = "";
                ZADM_M017_P POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.PkgUnitList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M017_P>().ToList().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M017_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.pack_style = POPUPEntityObject.id;
                    MasterEntity.PackingUnit = POPUPEntityObject.pkgunit;
                    MasterEntity.Unit = POPUPEntityObject.unit_code;
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
        private void InsertBallType(object InputValue)
        {
            try
            {
                string Request = "";
                string RequestParameterData = "";
                ZADM_M002_P POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BallTypeList.Where(x => x.ball_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M002_P>().ToList().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M002_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.ball_type = POPUPEntityObject.ball_type;
                    MasterEntity.ball_type_id = POPUPEntityObject.ball_type_id;
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
                            { POPUPEntityObject = plantList.Where(x => x.location_Id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        if (((IEnumerable)InputValue).Cast<ADM_M003>().Count() > 0)
                        {
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                        }
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.location_Id  = POPUPEntityObject.location_Id;
                    MasterEntity.location_nm = POPUPEntityObject.LoctnNm;
                    MasterEntity.machinecode = null;
                    MasterEntity.machine_id = 0;

                    List<PPC_M001_P> TempMachineList_CN = (from o in MC.MachineList_CN
                                                           where o.location_Id == MasterEntity.location_Id
                                                           select o).ToList();

                    MachineCollection = CollectionViewSource.GetDefaultView(TempMachineList_CN);
                    MachineCollection.Filter = new Predicate<object>(MachineFilter);
                    StringListMachine = TempMachineList_CN.Select(x => x.machinecode.ToString()).ToList();
                }
                var msg = new NotificationMessage("EPR_T001_VM_CON");
                Messenger.Default.Send<NotificationMessage>(msg);
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
        private void InsertCompCode(object InputValue)
        {
            try
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
                            { POPUPEntityObject = CompanyList.Where(x => x.comp_code.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        if (((IEnumerable)InputValue).Cast<ADM_M002>().Count() > 0)
                        {
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002>().ToList()[0];
                        }
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.comp_code = POPUPEntityObject.comp_code;

                }
                var msg = new NotificationMessage("EPR_T001_VM_CON");
                Messenger.Default.Send<NotificationMessage>(msg);
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
        private void InsertFltrStatus(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M0013 POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space 
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.t_StatusList.Where(x => x.t_display.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M0013>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0013>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.Fltr_t_status = POPUPEntityObject.t_status;
                    MasterEntity.Fltr_t_display = POPUPEntityObject.t_display;
                }
            }
            catch (Exception Ex) { }
        }
        private void InsertFltrPlant(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003 POPUPEntityObject = null;

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
                    if (((IEnumerable)InputValue).Cast<ADM_M003>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                    }
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.Fltr_location_Id = POPUPEntityObject.location_Id;
                    //MasterEntity.Fltr_t_display = POPUPEntityObject.LoctnNm;
                }
            }
            catch (Exception Ex) { }
        }
        #endregion

        #endregion

        #region Abstract Action
        protected override void OnCreateAction(InquiryActionResult<EPR_T001_New> result)
        {
            isNewRecord = true;
            MasterEntity = new EPR_T001_New();
            MasterEntityTemp = new EPR_T001_New();
            MasterEntity.ValidateAsync().Wait();
          //  DataGridCollection.Refresh();

            List<EPR_T001_New> tempList = new List<EPR_T001_New>();
            ProductDetailsCollection = CollectionViewSource.GetDefaultView(tempList);
            ProductDetailsCollection.Refresh();

            List<EPR_T001_New> tempList1 = new List<EPR_T001_New>();
            CurrentProductCollection = CollectionViewSource.GetDefaultView(tempList1);
            CurrentProductCollection.Refresh();

            LoadInitialData();
            DefaultValues();

            var msg = new NotificationMessage("EPR_T001_VM_CON");
            Messenger.Default.Send<NotificationMessage>(msg);
        }

        protected override void OnDiscardAction(InquiryActionResult<EPR_T001_New> result)
        {

        }

        protected override void OnFevoriteAction(InquiryActionResult<EPR_T001_New> result)
        {

        }

        protected override void OnFlipAction(InquiryActionResult<EPR_T001_New> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<EPR_T001_New> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<EPR_T001_New> result)
        {
            try
            {
                WebServiceRepository<List<COM_T003>> repository2 = new WebServiceRepository<List<COM_T003>>();
                 

                if (MasterEntity.machine_id != null)
                {
                    string Request = "";
                    Request = "ConversionNoteRpt" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + MasterEntity.machine_id.ToString() + "!@" + MasterEntity.order_no + "!@" + MasterEntity.pre_order_no + "!@" + MasterEntity.ItemCode;

                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_EPR_T001_Conv>(MCTemp, Request, "ConversionNote2", "Production", "", 0, "");

                    if (MCTemp.AttachmentData.Count >0)
                    {

                        if (!string.IsNullOrEmpty(MasterEntity.ItemCode))
                        {
                            Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.ItemCode.Replace("/", "--"), DocumentList = MCTemp.AttachmentData, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
                            
                            // List<COM_T003> files = MCTemp.AttachmentData
                            //.OrderBy(x => x.id)
                            //.GroupBy(x => x.file_index)
                            //.Select(group => new { Group = group, Count = group.Count() })
                            //.SelectMany(groupWithCount => groupWithCount.Group.Select(b => b)
                            //.Zip(Enumerable.Range(1, groupWithCount.Count), (j, i) => new COM_T003 { Index = i, FilePath = j.url, IsUploaded = true, NewFileName = j.file_name, id = j.id, doc_no = j.doc_no })).ToList();

                            // if (files.Any())
                            // {  
                            //     foreach (var f in files)
                            //     {
                            //         AttachmentCollection.Add(f);                       

                            //         var tempFilePath = System.Environment.CurrentDirectory + "\\temp\\" + f.FilePath + ".xps";

                            //         if (!Directory.Exists(Path.GetDirectoryName(tempFilePath)))
                            //         {
                            //             Directory.CreateDirectory(Path.GetDirectoryName(tempFilePath));
                            //         }

                            //         if (!File.Exists(tempFilePath))
                            //         {
                            //             byte[] byteReturnValue = repository2.DownloadFile(f.NewFileName, MasterEntity.ItemCode, tempFilePath);
                            //             MemoryStream stream = new MemoryStream(byteReturnValue, true);
                            //             var fileStream = new FileStream(MCTemp.AttachmentData[0].FilePath.Replace(".xps", ""), FileMode.CreateNew, FileAccess.ReadWrite);
                            //             stream.CopyTo(fileStream);
                            //             fileStream.Dispose();
                            //         }
                            //     }
                            // }
                        }
                    }

                    object[] objDataSource = new object[5];
                    string[] objDataSourceName = new string[5];

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == AppSessionState.comp_code).ToList();
                    objDataSource[0] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    //var Result = TempList.Where(loc => loc.location_Id == AppSessionState.location_Id).ToList();
                    //var Result2 = MC.RPTINK.Where(CN => CN.order_no != MasterEntity.order_no).ToList();
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    var Result1 = MCTemp.RPTINK.Where(CN => CN.order_no == MasterEntity.order_no).ToList();
                    var Result2 = MCTemp.RPTINK.Where(CN => CN.order_no != MasterEntity.order_no).ToList();
                    objDataSource[1] = Result;

                    objDataSource[2] = Result1;
                    objDataSource[3] = Result2;
                    objDataSource[4] = MCTemp.Rptapproval;


                    objDataSourceName[0] = "dsCompany";
                    objDataSourceName[1] = "dsLocation";
                    objDataSourceName[2] = "DSILDInk";
                    objDataSourceName[3] = "DSILDInk1";
                    objDataSourceName[4] = "dsRptapproval";


                    ReportManager ReportManager = new ReportManager();
                    //ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\Rpt_ConversionNote.rdlc", "ConversionNote");
                    string ReportDisplayName = MasterEntity.PartyName + "_" + MasterEntity.order_no;
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\" + MC.DocumentTypes[0].report_name, getParametersList(), ReportDisplayName);
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Select Machine", this.Title);
                    showMessageService.ShowMessage();
                }
            }
            catch (Exception ex)
            {

            }
        }


        protected override void OnRemoveAction(InquiryActionResult<EPR_T001_New> result)
        {
            try
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Delete Changes";
                showMessageService.Text =
                    String.Format(
                        "This record will delete forever '{0}'",
                            this.Title);

                if (showMessageService.ShowMessage() == DialogResult.Ok)
                {
                    this.MasterEntity.CancelEdit();
                    string response = repository.Delete(MasterEntity.order_no, "ConversionNote2", "Production");

                    MasterEntity = new EPR_T001_New();
                    isNewRecord = true;
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

        protected override void OnSaveAction(InquiryActionResult<EPR_T001_New> result)
        {
            try
            {


                if (Validation() == true)
                {
                    if (MasterEntity.location_Id == null || MasterEntity.location_Id == "")
                    {
                        MasterEntity.location_Id=AppSessionState.location_Id;
                    }
                    if (MasterEntity.comp_code == null || MasterEntity.comp_code == "")
                    {
                        MasterEntity.comp_code = AppSessionState.comp_code;
                    }

                    this.MasterEntity.EndEdit();

                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<EPR_T001_New>(MasterEntity, "ConversionNote2", "Production");
                        if (MasterEntity.order_no != null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Data Saved Successfully");
                            showMessageService.ShowMessage();
                        }
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<EPR_T001_New>(MasterEntity, "ConversionNote2", "Production");
                        if (MasterEntity.order_no != null)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Data Update Successfully");
                            showMessageService.ShowMessage();
                        }
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
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
        protected override void OnDocumentAction()
        {
            try
            {
                CursorControl.SetBusyState();

                if (!string.IsNullOrEmpty(MasterEntity.order_no))
                {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.order_no.Replace("/", "--"), DocumentList = MCTemp.AttachmentData, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
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
        protected override void OnRefreshCommand(InquiryActionResult<EPR_T001_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<EPR_T001_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<EPR_T001_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<EPR_T001_New> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<EPR_T001_New> result)
        {
            throw new NotImplementedException();
        }
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                if (MC.AttachmentData != null && MC.AttachmentData.Count > 0)
                {
                    string path1 = Path.Combine(@"file:\" + AppDomain.CurrentDomain.BaseDirectory, "temp//" + AppSessionState.client + "//" + MasterEntity.comp_code + "//" + MC.AttachmentData[0].url);
                    result.Add("ImagePath", path1);
                }
                else
                {
                    result.Add("ImagePath", @"file:\" + AppDomain.CurrentDomain.BaseDirectory);
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
            return result;
        }

        
    }


    #endregion
}

