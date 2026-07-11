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
using System.Collections.Specialized;
using Reflection.BusinessEntity.Production;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Controls;
using System.Windows.Controls;
using System.Windows;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Common;

namespace Reflection.Modules.Production.ViewModels
{
    public class ENG_T004_VM : WorkspaceViewModel<ENG_T004>
    {
        #region AutoSuggest TextBox Declaration Region

        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(ENG_T004_VM));
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

        private AutoSuggestTextViewModel<dynamic> _AS_FilterByLocation { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_FilterByLocation
        {
            get { return _AS_FilterByLocation; }
            set
            {
                if (_AS_FilterByLocation != value)
                {
                    _AS_FilterByLocation = value; RaisePropertyChanged("AS_FilterByLocation");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_FilterByModelNo { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_FilterByModelNo
        {
            get { return _AS_FilterByModelNo; }
            set
            {
                if (_AS_FilterByModelNo != value)
                {
                    _AS_FilterByModelNo = value; RaisePropertyChanged("AS_FilterByModelNo");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_FilterByBallDia { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_FilterByBallDia
        {
            get { return _AS_FilterByBallDia; }
            set
            {
                if (_AS_FilterByBallDia != value)
                {
                    _AS_FilterByBallDia = value; RaisePropertyChanged("AS_FilterByBallDia");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_FilterByILD { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_FilterByILD
        {
            get { return _AS_FilterByILD; }
            set
            {
                if (_AS_FilterByILD != value)
                {
                    _AS_FilterByILD = value; RaisePropertyChanged("AS_FilterByILD");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_ILDRef { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ILDRef
        {
            get { return _AS_ILDRef; }
            set
            {
                if (_AS_ILDRef != value)
                {
                    _AS_ILDRef = value; RaisePropertyChanged("AS_ILDRef");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_PartyRef { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PartyRef
        {
            get { return _AS_PartyRef; }
            set
            {
                if (_AS_PartyRef != value)
                {
                    _AS_PartyRef = value; RaisePropertyChanged("AS_PartyRef");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_FilterByInk { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_FilterByInk
        {
            get { return _AS_FilterByInk; }
            set
            {
                if (_AS_FilterByInk != value)
                {
                    _AS_FilterByInk = value; RaisePropertyChanged("AS_FilterByInk");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_FilterCustomer { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_FilterCustomer
        {
            get { return _AS_FilterCustomer; }
            set
            {
                if (_AS_FilterCustomer != value)
                {
                    _AS_FilterCustomer = value; RaisePropertyChanged("AS_FilterCustomer");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Customer { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Customer
        {
            get { return _AS_Customer; }
            set
            {
                if (_AS_Customer != value)
                {
                    _AS_Customer = value; RaisePropertyChanged("AS_Customer");
                }
            }
        }
        #endregion

        #region Declaration
        bool isNewRecord = true;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        WebServiceRepository<ENG_T004> repository = new WebServiceRepository<ENG_T004>();
        WebServiceRepository<MultipleContext_ENG_T004> repository_MC = new WebServiceRepository<MultipleContext_ENG_T004>();
        WebServiceRepository<MultipleContext_ENG_T004> repository_MCTemp = new WebServiceRepository<MultipleContext_ENG_T004>();

        ObjectSerializationService obj = new ObjectSerializationService();

        private bool _EnableCheckBox;
        public bool EnableCheckBox
        {
            get { return _EnableCheckBox; }
            set
            {
                if (_EnableCheckBox != value)
                {
                    _EnableCheckBox = value;
                    RaisePropertyChanged("EnableCheckBox");
                }
            }
        }

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
        private MultipleContext_ENG_T004 _MC = new MultipleContext_ENG_T004();
        public MultipleContext_ENG_T004 MC
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

        private MultipleContext_ENG_T004 _MCTemp = new MultipleContext_ENG_T004();
        public MultipleContext_ENG_T004 MCTemp
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

        private MultipleContext_ENG_T004 _MCTemp1 = new MultipleContext_ENG_T004();
        public MultipleContext_ENG_T004 MCTemp1
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
        private ENG_T004 _MasterEntity;
        public ENG_T004 MasterEntity
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

        private ObservableCollection<ENG_T004_A> _ParaDetailEntity;
        public ObservableCollection<ENG_T004_A> ParaDetailEntity
        {
            get { return _ParaDetailEntity; }
            set
            {
                if (_ParaDetailEntity != value)
                {
                    _ParaDetailEntity = value; RaisePropertyChanged("ParaDetailEntity");
                }
            }
        }

        private ObservableCollection<ENG_T004_B> _BallDetailEntity;
        public ObservableCollection<ENG_T004_B> BallDetailEntity
        {
            get { return _BallDetailEntity; }
            set
            {
                if (_BallDetailEntity != value)
                {
                    _BallDetailEntity = value; RaisePropertyChanged("BallDetailEntity");
                }
            }
        }
        private ObservableCollection<ENG_T004_B> _InkDetailEntity;
        public ObservableCollection<ENG_T004_B> InkDetailEntity
        {
            get { return _InkDetailEntity; }
            set
            {
                if (_InkDetailEntity != value)
                {
                    _InkDetailEntity = value; RaisePropertyChanged("InkDetailEntity");
                }
            }
        }

        private ObservableCollection<ENG_T004_B> _WireDetailEntity;
        public ObservableCollection<ENG_T004_B> WireDetailEntity
        {
            get { return _WireDetailEntity; }
            set
            {
                if (_WireDetailEntity != value)
                {
                    _WireDetailEntity = value; RaisePropertyChanged("WireDetailEntity");
                }
            }
        }


        private ObservableCollection<ENG_T004_B> _ControlParaDetailEntity;
        public ObservableCollection<ENG_T004_B> ControlParaDetailEntity
        {
            get { return _ControlParaDetailEntity; }
            set
            {
                if (_ControlParaDetailEntity != value)
                {
                    _ControlParaDetailEntity = value; RaisePropertyChanged("ControlParaDetailEntity");
                }
            }
        }

        private ObservableCollection<ENG_T004_B> _ToolsDetailEntity;
        public ObservableCollection<ENG_T004_B> ToolsDetailEntity
        {
            get { return _ToolsDetailEntity; }
            set
            {
                if (_ToolsDetailEntity != value)
                {
                    _ToolsDetailEntity = value; RaisePropertyChanged("ToolsDetailEntity");
                }
            }
        }

        private ObservableCollection<ENG_T004_B> _DrillsDetailEntity;
        public ObservableCollection<ENG_T004_B> DrillsDetailEntity
        {
            get { return _DrillsDetailEntity; }
            set
            {
                if (_DrillsDetailEntity != value)
                {
                    _DrillsDetailEntity = value; RaisePropertyChanged("DrillsDetailEntity");
                }
            }
        }

        private ObservableCollection<ENG_T004_B> _SparesDetailEntity;
        public ObservableCollection<ENG_T004_B> SparesDetailEntity
        {
            get { return _SparesDetailEntity; }
            set
            {
                if (_SparesDetailEntity != value)
                {
                    _SparesDetailEntity = value; RaisePropertyChanged("SparesDetailEntity");
                }
            }
        }

        private ObservableCollection<ENG_T004_C> _ReferencesEntity;
        public ObservableCollection<ENG_T004_C> ReferencesEntity
        {
            get { return _ReferencesEntity; }
            set
            {
                if (_ReferencesEntity != value)
                {
                    _ReferencesEntity = value;
                    ReferencesEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForParameter);
                    RaisePropertyChanged("ReferencesEntity");
                }
            }
        }
        private ObservableCollection<ENG_T004_D> _PartyEntity;
        public ObservableCollection<ENG_T004_D> PartyEntity
        {
            get { return _PartyEntity; }
            set
            {
                if (_PartyEntity != value)
                {
                    _PartyEntity = value;
                    PartyEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForParameter);
                    RaisePropertyChanged("PartyEntity");
                }
            }
        }
        private int _dgSelectedIndexTools;
        public int dgSelectedIndexTools
        {
            get { return _dgSelectedIndexTools; }
            set
            {
                if (_dgSelectedIndexTools != value)
                {
                    _dgSelectedIndexTools = value;
                    RaisePropertyChanged("dgSelectedIndexTools");
                }
            }
        }

        private int _dgSelectedIndexReferences;
        public int dgSelectedIndexReferences
        {
            get { return _dgSelectedIndexReferences; }
            set
            {
                if (_dgSelectedIndexReferences != value)
                {
                    _dgSelectedIndexReferences = value;
                    RaisePropertyChanged("dgSelectedIndexReferences");
                }
            }
        }
        private int _dgSelectedIndexParty;
        public int dgSelectedIndexParty
        {
            get { return _dgSelectedIndexParty; }
            set
            {
                if (_dgSelectedIndexParty != value)
                {
                    _dgSelectedIndexParty = value;
                    RaisePropertyChanged("dgSelectedIndexParty");
                }
            }
        }

        private int _dgSelectedIndexDrills;
        public int dgSelectedIndexDrills
        {
            get { return _dgSelectedIndexDrills; }
            set
            {
                if (_dgSelectedIndexDrills != value)
                {
                    _dgSelectedIndexDrills = value;
                    RaisePropertyChanged("dgSelectedIndexDrills");

                }
            }
        }

        private int _dgSelectedIndexSpares;
        public int dgSelectedIndexSpares
        {
            get { return _dgSelectedIndexSpares; }
            set
            {
                if (_dgSelectedIndexSpares != value)
                {
                    _dgSelectedIndexSpares = value;
                    RaisePropertyChanged("dgSelectedIndexSpares");

                }
            }
        }

        private int _dgSelectedIndexParaDetails;
        public int dgSelectedIndexParaDetails
        {
            get { return _dgSelectedIndexParaDetails; }
            set
            {
                if (_dgSelectedIndexParaDetails != value)
                {
                    _dgSelectedIndexParaDetails = value;
                    RaisePropertyChanged("dgSelectedIndexParaDetails");

                }
            }
        }

        private int _dgSelectedIndexBallDetails;
        public int dgSelectedIndexBallDetails
        {
            get { return _dgSelectedIndexBallDetails; }
            set
            {
                if (_dgSelectedIndexBallDetails != value)
                {
                    _dgSelectedIndexBallDetails = value;
                    RaisePropertyChanged("dgSelectedIndexBallDetails");

                }
            }
        }

        private int _dgSelectedIndexWireDetails;
        public int dgSelectedIndexWireDetails
        {
            get { return _dgSelectedIndexWireDetails; }
            set
            {
                if (_dgSelectedIndexWireDetails != value)
                {
                    _dgSelectedIndexWireDetails = value;
                    RaisePropertyChanged("dgSelectedIndexWireDetails");

                }
            }
        }

        private int _dgSelectedIndexInkDetails;
        public int dgSelectedIndexInkDetails
        {
            get { return _dgSelectedIndexInkDetails; }
            set
            {
                if (_dgSelectedIndexInkDetails != value)
                {
                    _dgSelectedIndexInkDetails = value;
                    RaisePropertyChanged("dgSelectedIndexInkDetails");

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

        #region . StringList .

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

        private List<ENG_T004_P> _FlipGridData;
        public List<ENG_T004_P> FlipGridData
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

        private List<ENG_T004_P> _SelectedList;
        public List<ENG_T004_P> SelectedList
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

        List<string> _StringListBallDia;
        public List<string> StringListBallDia
        {
            get { return _StringListBallDia; }
            set
            {
                if (_StringListBallDia != value)
                {
                    _StringListBallDia = value;
                }
            }
        }

        List<string> _StringListWireDia;
        public List<string> StringListWireDia
        {
            get { return _StringListWireDia; }
            set
            {
                if (_StringListWireDia != value)
                {
                    _StringListWireDia = value;
                }
            }
        }

        List<string> _StringListWireType;
        public List<string> StringListWireType
        {
            get { return _StringListWireType; }
            set
            {
                if (_StringListWireType != value)
                {
                    _StringListWireType = value;
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

        private List<string> _StringListSelectedItem;
        public List<string> StringListSelectedItem
        {
            get { return _StringListSelectedItem; }
            set
            {
                if (_StringListSelectedItem != value)
                {
                    _StringListSelectedItem = value;
                }
            }
        }

        private List<string> _StringListSelectedDrillItem;
        public List<string> StringListSelectedDrillItem
        {
            get { return _StringListSelectedDrillItem; }
            set
            {
                if (_StringListSelectedDrillItem != value)
                {
                    _StringListSelectedDrillItem = value;
                }
            }
        }

        private List<string> _StringListSelectedSpareItem;
        public List<string> StringListSelectedSpareItem
        {
            get { return _StringListSelectedSpareItem; }
            set
            {
                if (_StringListSelectedSpareItem != value)
                {
                    _StringListSelectedSpareItem = value;
                }
            }
        }

        private List<string> _StringListItem1;
        public List<string> StringListItem1
        {
            get { return _StringListItem1; }
            set
            {
                if (_StringListItem1 != value)
                {
                    _StringListItem1 = value;
                }
            }
        }

        private List<string> _StringListDrillsItem;
        public List<string> StringListDrillsItem
        {
            get { return _StringListDrillsItem; }
            set
            {
                if (_StringListDrillsItem != value)
                {
                    _StringListDrillsItem = value;
                }
            }
        }

        private List<string> _StringListSparesItem;
        public List<string> StringListSparesItem
        {
            get { return _StringListSparesItem; }
            set
            {
                if (_StringListSparesItem != value)
                {
                    _StringListSparesItem = value;
                }
            }
        }

        private List<string> _StringListBackflipData;
        public List<string> StringListBackflipData
        {
            get { return _StringListBackflipData; }
            set
            {
                if (_StringListBackflipData != value)
                {
                    _StringListBackflipData = value;
                }
            }
        }

        private List<string> _StringListSelectedParaData;
        public List<string> StringListSelectedParaData
        {
            get { return _StringListSelectedParaData; }
            set
            {
                if (_StringListSelectedParaData != value)
                {
                    _StringListSelectedParaData = value;
                }
            }
        }

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

        private List<string> _StringListInk;
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

        private List<string> _StringListILD;
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
        private List<string> _StringListParty;
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

        private List<string> _StringListModel;
        public List<string> StringListModel
        {
            get { return _StringListModel; }
            set
            {
                if (_StringListModel != value)
                {
                    _StringListModel = value;
                }
            }
        }
        private List<string> _StringListStationno;
        public List<string> StringListStationno
        {
            get { return _StringListStationno; }
            set
            {
                if (_StringListStationno != value)
                {
                    _StringListStationno = value;
                }
            }
        }
        private List<string> _StringListStationnoTools;
        public List<string> StringListStationnoTools
        {
            get { return _StringListStationnoTools; }
            set
            {
                if (_StringListStationnoTools != value)
                {
                    _StringListStationnoTools = value;
                }
            }
        }

        private List<string> _StringListSpecType;
        public List<string> StringListSpecType
        {
            get { return _StringListSpecType; }
            set
            {
                if (_StringListSpecType != value)
                {
                    _StringListSpecType = value;
                }
            }
        }

        private List<string> _StringListInstrument;
        public List<string> StringListInstrument
        {
            get { return _StringListInstrument; }
            set
            {
                if (_StringListInstrument != value)
                {
                    _StringListInstrument = value;
                }
            }
        }
        private List<string> _StringListWorking;
        public List<string> StringListWorking
        {
            get { return _StringListWorking; }
            set
            {
                if (_StringListWorking != value)
                {
                    _StringListWorking = value;
                }
            }
        }



        //make

        private List<string> _StringListToolsMake;
        public List<string> StringListToolsMake
        {
            get { return _StringListToolsMake; }
            set
            {
                if (_StringListToolsMake != value)
                {
                    _StringListToolsMake = value;
                    RaisePropertyChanged("StringListToolsMake");
                }
            }
        }
        private List<string> _StringListDrillsMake;
        public List<string> StringListDrillsMake
        {
            get { return _StringListDrillsMake; }
            set
            {
                if (_StringListDrillsMake != value)
                {
                    _StringListDrillsMake = value;
                    RaisePropertyChanged("StringListDrillsMake");
                }
            }
        }
        private List<string> _StringListSparesMake;
        public List<string> StringListSparesMake
        {
            get { return _StringListSparesMake; }
            set
            {
                if (_StringListSparesMake != value)
                {
                    _StringListSparesMake = value;
                    RaisePropertyChanged("StringListSparesMake");
                }
            }
        }
        private List<string> _StringListBallMake;
        public List<string> StringListBallMake
        {
            get { return _StringListBallMake; }
            set
            {
                if (_StringListBallMake != value)
                {
                    _StringListBallMake = value;
                    RaisePropertyChanged("StringListBallMake");
                }
            }
        }
        private List<string> _StringListWireMake;
        public List<string> StringListWireMake
        {
            get { return _StringListWireMake; }
            set
            {
                if (_StringListWireMake != value)
                {
                    _StringListWireMake = value;
                    RaisePropertyChanged("StringListWireMake");
                }
            }
        }
        private List<string> _StringListInkMake;
        public List<string> StringListInkMake
        {
            get { return _StringListInkMake; }
            set
            {
                if (_StringListInkMake != value)
                {
                    _StringListInkMake = value;
                    RaisePropertyChanged("StringListInkMake");
                }
            }
        }
        #endregion

        #region . Relay Command Declaration .
        public RelayCommand<object> cmdInsertItem { get; private set; }
        public RelayCommand<object> cmdInsertModel { get; private set; }
        public RelayCommand<object> cmdInsertItemOnToolsGrid { get; private set; }
        public RelayCommand<object> cmdInsertSelectedItemOnToolsGrid { get; private set; }
        public RelayCommand<object> cmdInsertSelectedItemOnDrillsGrid { get; private set; }
        public RelayCommand<object> cmdInsertSelectedItemOnSparesGrid { get; private set; }
        public RelayCommand<object> cmdInsertItemOnDrillsGrid { get; private set; }
        public RelayCommand<object> cmdInsertItemOnSparesGrid { get; private set; }
        public RelayCommand<object> CmdAInsertAlternateItem { get; private set; }
        public RelayCommand<object> cmdInsertInk { get; private set; }
        public RelayCommand<object> cmdInsertIld { get; private set; }
        public RelayCommand<object> cmdInsertILD_Ref { get; private set; }
        public RelayCommand<object> cmdInsertMachine { get; private set; }
        public RelayCommand<object> cmdInsertCustomer { get; private set; }
        public RelayCommand<object> cmdInsertUnit { get; private set; }
        public RelayCommand<object> cmdInsertSpecificationType { get; private set; }
        public RelayCommand<object> cmdInsertSpecificationPara { get; private set; }
        public RelayCommand<object> cmdInsertWireType { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> cmdInsertPlant { get; private set; }
        public RelayCommand<object> cmdInsertselectedParaDocNo { get; private set; }
        public RelayCommand<object> cmdInsertselectedToolDocNo { get; private set; }
        public RelayCommand<object> cmdInsertselectedDrillDocNo { get; private set; }
        public RelayCommand<object> cmdInsertselectedSpareDocNo { get; private set; }
        public RelayCommand<object> cmdAddSelectedData { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowTools { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowDrills { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowSpares { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowParameterDetails { get; private set; }
        public RelayCommand<object> cmdInsertSelectedParaOnGrid { get; private set; }
        public RelayCommand<object> cmdInsertBallDiameter { get; private set; }
        public RelayCommand<object> cmdInsertWireDiameter { get; private set; }
        public RelayCommand<object> cmdInkDetailsInk { get; private set; }
        public RelayCommand<object> cmdOpenAttachments { get; private set; }
        public RelayCommand<object> cmdOpenItemView { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowBallDetails { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowWireDetails { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowInkDetails { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowPartyDetails { get; private set; }

        public RelayCommand<object> cmdInsertInstrument { get; private set; }
        public RelayCommand<object> cmdInsertWorking { get; private set; }
        public RelayCommand<object> cmdInsertDrillsWorking { get; private set; }
        public RelayCommand<object> cmdInsertSparesWorking { get; private set; }
        public RelayCommand<object> cmdInsertPartyOnGrid { get; private set; }

        //make     
        //public RelayCommand<IList> cmdToolsMake { get; private set; }
        //public RelayCommand<IList> cmdDrillsMake { get; private set; }
        //public RelayCommand<IList> cmdSparesMake { get; private set; }
        //public RelayCommand<IList> cmdBallMake { get; private set; }
        //public RelayCommand<IList> cmdWireMake { get; private set; }
        //public RelayCommand<IList> cmdInkMake { get; private set; }

        public RelayCommand<object> cmdToolsMake { get; private set; }
        public RelayCommand<object> cmdDrillsMake { get; private set; }
        public RelayCommand<object> cmdSparesMake { get; private set; }
        public RelayCommand<object> cmdBallMake { get; private set; }
        public RelayCommand<object> cmdWireMake { get; private set; }
        public RelayCommand<object> cmdInkMake { get; private set; }
        // Commands to Filter View

        public RelayCommand<object> cmdFilterByPlant { get; private set; }
        public RelayCommand<object> cmdFilterByBallDia { get; private set; }
        public RelayCommand<object> cmdFilterByInk { get; private set; }
        public RelayCommand<object> cmdFilterByILD { get; private set; }
        public RelayCommand<object> cmdFilterByModelNo { get; private set; }
        public RelayCommand<object> cmdFilterByCust { get; private set; }

        public RelayCommand<object> cmdLoad { get; private set; }
        public RelayCommand<object> cmdInsertStationType { get; private set; }
        public RelayCommand<object> cmdInsertStationTypeTools { get; private set; }
        public RelayCommand<object> cmdInsertStationTypeDrills { get; private set; }
        public RelayCommand<object> cmdInsertStationTypeSpares { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdPrintReport { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        #endregion

        #region . ICollection .
        private ICollectionView _ParaSearchCollection;
        public ICollectionView ParaSearchCollection
        {
            get { return _ParaSearchCollection; }
            set { _ParaSearchCollection = value; RaisePropertyChanged("ParaSearchCollection"); }
        }

        private ICollectionView _ToolsSearchCollection;
        public ICollectionView ToolsSearchCollection
        {
            get { return _ToolsSearchCollection; }
            set { _ToolsSearchCollection = value; RaisePropertyChanged("ToolsSearchCollection"); }
        }

        private ICollectionView _DrillsSearchCollection;
        public ICollectionView DrillsSearchCollection
        {
            get { return _DrillsSearchCollection; }
            set { _DrillsSearchCollection = value; RaisePropertyChanged("DrillsSearchCollection"); }
        }

        private ICollectionView _SparesSearchCollection;
        public ICollectionView SparesSearchCollection
        {
            get { return _SparesSearchCollection; }
            set { _SparesSearchCollection = value; RaisePropertyChanged("SparesSearchCollection"); }
        }

        private ICollectionView _BackFlipCollection;
        public ICollectionView BackFlipCollection
        {
            get { return _BackFlipCollection; }
            set { _BackFlipCollection = value; RaisePropertyChanged("BackFlipCollection"); }
        }

        private ICollectionView _SelectedParaItemCollection;
        public ICollectionView SelectedParaItemCollection
        {
            get { return _SelectedParaItemCollection; }
            set { _SelectedParaItemCollection = value; RaisePropertyChanged("SelectedParaItemCollection"); }
        }

        private ICollectionView _SelectedItemToolCollection;
        public ICollectionView SelectedItemToolCollection
        {
            get { return _SelectedItemToolCollection; }
            set { _SelectedItemToolCollection = value; RaisePropertyChanged("SelectedItemToolCollection"); }
        }

        private ICollectionView _SelectedDrillItemCollection;
        public ICollectionView SelectedDrillItemCollection
        {
            get { return _SelectedDrillItemCollection; }
            set { _SelectedDrillItemCollection = value; RaisePropertyChanged("SelectedDrillItemCollection"); }
        }

        private ICollectionView _SelectedSpareItemCollection;
        public ICollectionView SelectedSpareItemCollection
        {
            get { return _SelectedSpareItemCollection; }
            set { _SelectedSpareItemCollection = value; RaisePropertyChanged("SelectedSpareItemCollection"); }
        }

        private ICollectionView _ItemCollection;
        public ICollectionView ItemCollection
        {
            get { return _ItemCollection; }
            set { _ItemCollection = value; RaisePropertyChanged("ItemCollection"); }
        }

        private ICollectionView _ItemCollection1;
        public ICollectionView ItemCollection1
        {
            get { return _ItemCollection1; }
            set { _ItemCollection1 = value; RaisePropertyChanged("ItemCollection1"); }
        }

        private ICollectionView _ToolsItemCollection;
        public ICollectionView ToolsItemCollection
        {
            get { return _ToolsItemCollection; }
            set { _ToolsItemCollection = value; RaisePropertyChanged("ToolsItemCollection"); }
        }

        private ICollectionView _DrillsItemCollection;
        public ICollectionView DrillsItemCollection
        {
            get { return _DrillsItemCollection; }
            set { _DrillsItemCollection = value; RaisePropertyChanged("DrillsItemCollection"); }
        }

        private ICollectionView _SparesItemCollection;
        public ICollectionView SparesItemCollection
        {
            get { return _SparesItemCollection; }
            set { _SparesItemCollection = value; RaisePropertyChanged("SparesItemCollection"); }
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

        private ICollectionView _ILDCollection;
        public ICollectionView ILDCollection
        {
            get { return _ILDCollection; }
            set
            {
                _ILDCollection = value;
                RaisePropertyChanged("ILDCollection");
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

        private ICollectionView _plantCollection;
        public ICollectionView plantCollection
        {
            get { return _plantCollection; }
            set { _plantCollection = value; RaisePropertyChanged("plantCollection"); }
        }

        private ICollectionView _UomCollection;
        public ICollectionView UomCollection
        {
            get { return _UomCollection; }
            set { _UomCollection = value; RaisePropertyChanged("UomCollection"); }
        }

        private ICollectionView _ModelCollection;
        public ICollectionView ModelCollection
        {
            get { return _ModelCollection; }
            set { _ModelCollection = value; RaisePropertyChanged("ModelCollection"); }
        }

        private ICollectionView _StationnoCollection;
        public ICollectionView StationnoCollection
        {
            get { return _StationnoCollection; }
            set { _StationnoCollection = value; RaisePropertyChanged("StationnoCollection"); }
        }

        private ICollectionView _SpecTypeCollection;
        public ICollectionView SpecTypeCollection
        {
            get { return _SpecTypeCollection; }
            set { _SpecTypeCollection = value; RaisePropertyChanged("SpecTypeCollection"); }
        }
        private ICollectionView _SpecParaCollection;
        public ICollectionView SpecParaCollection
        {
            get { return _SpecParaCollection; }
            set { _SpecParaCollection = value; RaisePropertyChanged("SpecParaCollection"); }
        }

        private ICollectionView _WireTypeCollection;
        public ICollectionView WireTypeCollection
        {
            get { return _WireTypeCollection; }
            set
            {
                _WireTypeCollection = value;
                RaisePropertyChanged("WireTypeCollection");
            }
        }

        private ICollectionView _GradeCollection;
        public ICollectionView GradeCollection
        {
            get { return _GradeCollection; }
            set
            {
                _GradeCollection = value;
                RaisePropertyChanged("GradeCollection");
            }
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

        private List<COM_T003_Files> _AttachmentCollectionFiles;
        public List<COM_T003_Files> AttachmentCollectionFiles
        {
            get { return _AttachmentCollectionFiles; }
            set
            {
                if (_AttachmentCollectionFiles != value)
                {
                    _AttachmentCollectionFiles = value;
                    RaisePropertyChanged("AttachmentCollectionFiles");
                }
            }
        }

        private ICollectionView _BallDiaCollection;
        public ICollectionView BallDiaCollection
        {
            get { return _BallDiaCollection; }
            set
            {
                _BallDiaCollection = value;
                RaisePropertyChanged("BallDiaCollection");
            }
        }

        private ICollectionView _WireDiaCollection;
        public ICollectionView WireDiaCollection
        {
            get { return _WireDiaCollection; }
            set
            {
                _WireDiaCollection = value;
                RaisePropertyChanged("WireDiaCollection");
            }
        }

        private ICollectionView _ToolsMakeCollection;
        public ICollectionView ToolsMakeCollection
        {
            get { return _ToolsMakeCollection; }
            set { _ToolsMakeCollection = value; RaisePropertyChanged("ToolsMakeCollection"); }
        }

        private ICollectionView _InstrumentCollection;
        public ICollectionView InstrumentCollection
        {
            get { return _InstrumentCollection; }
            set { _InstrumentCollection = value; RaisePropertyChanged("InstrumentCollection"); }
        }
        private ICollectionView _WorkingCollection;
        public ICollectionView WorkingCollection
        {
            get { return _WorkingCollection; }
            set { _WorkingCollection = value; RaisePropertyChanged("WorkingCollection"); }
        }
        #endregion

        #region Model Entity updated
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            if (sender.ToString() == "tol_minus" || sender.ToString() == "tol_plus" || sender.ToString() == "para_value" || sender.ToString() == "active")
            {
                CalRangeValues();
            }
            this.ErrorExist = false;/*MasterEntity.HasErrors;*/
        }

        void CalRangeValues()
        {
            if (ParaDetailEntity.Count > 0 && dgSelectedIndexParaDetails != -1)
            {
                //ParaDetailEntity[dgSelectedIndexParaDetails].range = (Convert.ToDecimal(ParaDetailEntity[dgSelectedIndexParaDetails].para_value) - ParaDetailEntity[dgSelectedIndexParaDetails].tol_minus).ToString() + "-" + (Convert.ToDecimal(ParaDetailEntity[dgSelectedIndexParaDetails].para_value) + ParaDetailEntity[dgSelectedIndexParaDetails].tol_plus).ToString();
                ParaDetailEntity[dgSelectedIndexParaDetails].range = String.Format("{0:0.0000}", (Convert.ToDecimal(ParaDetailEntity[dgSelectedIndexParaDetails].para_value) - ParaDetailEntity[dgSelectedIndexParaDetails].tol_minus)).ToString() + "-" + String.Format("{0:0.0000}", (Convert.ToDecimal(ParaDetailEntity[dgSelectedIndexParaDetails].para_value) + ParaDetailEntity[dgSelectedIndexParaDetails].tol_plus)).ToString();
            }
        }
        #endregion
        #region . Constructor .btnLoad
        public ENG_T004_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new ENG_T004();
            ParaDetailEntity = new ObservableCollection<ENG_T004_A>();
            ControlParaDetailEntity = new ObservableCollection<ENG_T004_B>();
            ToolsDetailEntity = new ObservableCollection<ENG_T004_B>();
            DrillsDetailEntity = new ObservableCollection<ENG_T004_B>();
            SparesDetailEntity = new ObservableCollection<ENG_T004_B>();
            BallDetailEntity = new ObservableCollection<ENG_T004_B>();
            WireDetailEntity = new ObservableCollection<ENG_T004_B>();
            InkDetailEntity = new ObservableCollection<ENG_T004_B>();
            ReferencesEntity = new ObservableCollection<ENG_T004_C>();
            PartyEntity = new ObservableCollection<ENG_T004_D>();

            ReferencesEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForParameter);

            ENG_T004_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            FlipGridData = new List<ENG_T004_P>();
            EnableCheckBox = false;

            MasterEntity.ValidateAsync().Wait();



            LoadInitialData();
        }
        public ENG_T004_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new ENG_T004();
            ParaDetailEntity = new ObservableCollection<ENG_T004_A>();
            ControlParaDetailEntity = new ObservableCollection<ENG_T004_B>();
            ToolsDetailEntity = new ObservableCollection<ENG_T004_B>();
            DrillsDetailEntity = new ObservableCollection<ENG_T004_B>();
            SparesDetailEntity = new ObservableCollection<ENG_T004_B>();
            BallDetailEntity = new ObservableCollection<ENG_T004_B>();
            WireDetailEntity = new ObservableCollection<ENG_T004_B>();
            InkDetailEntity = new ObservableCollection<ENG_T004_B>();
            ReferencesEntity = new ObservableCollection<ENG_T004_C>();
            PartyEntity = new ObservableCollection<ENG_T004_D>();

            ReferencesEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForParameter);

            ENG_T004_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            FlipGridData = new List<ENG_T004_P>();
            EnableCheckBox = false;

            MasterEntity.ValidateAsync().Wait();



            LoadInitialData();
        }

        private void LoadInitialData()
        {
            try
            {
                MasterEntity.doc_type = "TD";
                MasterEntity.doc_cat = "TD";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ENG_T004>(MC, Request, "TDS", "Production", "LoadInitialData", 0, "");

                #region Command Initialisation .
                cmdInsertInk = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertInk(cmdPara); });
                cmdInsertIld = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertIld(cmdPara); });
                cmdInsertUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUnit(cmdPara); });
                cmdInsertMachine = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertMachine(cmdPara); });
                cmdInsertCustomer = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCustomer(cmdPara); });

                cmdInsertILD_Ref = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertILD_Ref(cmdPara, true, true, true); });
                cmdInsertSpecificationType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSpecificationType(cmdPara, true, true, true); });
                cmdInsertSpecificationPara = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSpecificationPara(cmdPara, false, true, true); });
                cmdInsertItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara); });
                cmdInsertItemOnToolsGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItemForToolsGrid(cmdPara, true, true, true); });
                cmdInsertSelectedParaOnGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSelectedParasOnGrid(cmdPara, true, true, true); });
                cmdInsertSelectedItemOnToolsGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSelectedItemForToolsGrid(cmdPara, true, true, true); });
                cmdInsertSelectedItemOnDrillsGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSelectedItemForDrillsGrid(cmdPara, true, true, true); });
                cmdInsertSelectedItemOnSparesGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSelectedItemForSparesGrid(cmdPara, true, true, true); });
                cmdInsertItemOnDrillsGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItemForDrillsGrid(cmdPara, true, true, true); });
                cmdInsertItemOnSparesGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItemForSparesGrid(cmdPara, true, true, true); });
                CmdAInsertAlternateItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertAlternateItem(cmdPara, true, true, true); });
                cmdInsertModel = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertModel(cmdPara); });
                cmdInsertWireType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWireType(cmdPara); });
                cmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                cmdInsertPlant = new RelayCommand<object>(items => { if (items == null) { return; } InsertPlant(items); });
                cmdInsertselectedParaDocNo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertselectedParaDocNo(cmdPara); });
                cmdInsertselectedToolDocNo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertselectedToolDocNo(cmdPara); });
                cmdInsertselectedDrillDocNo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertselectedDrillDocNo(cmdPara); });
                cmdInsertselectedSpareDocNo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertselectedSpareDocNo(cmdPara); });
                cmdAddSelectedData = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadItemDetails(cmdPara); });
                cmdDeleteDataGridRowTools = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Tools(cmdPara); });
                cmdDeleteDataGridRowDrills = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Drills(cmdPara); });
                cmdDeleteDataGridRowSpares = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Spares(cmdPara); });
                cmdDeleteDataGridRowParameterDetails = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_ParameterDetails(cmdPara); });
                cmdInsertBallDiameter = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBallDiameter(cmdPara, true, true, true); });
                cmdInsertWireDiameter = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWireDiameter(cmdPara, true, true, true); });
                cmdOpenAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenDocumentViewer(cmdPara); });
                cmdOpenItemView = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OpenItemViewer(cmdPara); });
                cmdInkDetailsInk = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertInkDetailsInk(cmdPara, true, true, true); });
                cmdDeleteDataGridRowBallDetails = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_BallDetails(cmdPara); });
                cmdDeleteDataGridRowWireDetails = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_WireDetails(cmdPara); });
                cmdDeleteDataGridRowInkDetails = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_InkDetails(cmdPara); });
                cmdDeleteDataGridRowPartyDetails = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_PartyDetails(cmdPara); });

                cmdInsertInstrument = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertInstrument(cmdPara, true, true, true); });
                cmdInsertWorking = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWorking(cmdPara, true, true, true); });
                cmdInsertDrillsWorking = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDrillsWorking(cmdPara, true, true, true); });
                cmdInsertSparesWorking = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSparesWorking(cmdPara, true, true, true); });

                //make
                //It was throwing Exception : unable to cast object of type system.string to type system.collection.ilist
                //cmdToolsMake = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertToolsMake(cmdPara, false, true, true); });
                //cmdDrillsMake = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertDrillsMake(cmdPara, false, true, true); });
                //cmdSparesMake = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertSparesMake(cmdPara, false, true, true); });
                //cmdBallMake = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertBallMake(cmdPara, false, true, true); });
                //cmdWireMake = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertWireMake(cmdPara, false, true, true); });
                //cmdInkMake = new RelayCommand<IList>(cmdPara => { if (cmdPara == null) { return; } InsertInkMake(cmdPara, false, true, true); });

                cmdToolsMake = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertToolsMake(cmdPara, false, true, true); });
                cmdDrillsMake = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDrillsMake(cmdPara, false, true, true); });
                cmdSparesMake = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSparesMake(cmdPara, false, true, true); });
                cmdBallMake = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBallMake(cmdPara, false, true, true); });
                cmdWireMake = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertWireMake(cmdPara, false, true, true); });
                cmdInkMake = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertInkMake(cmdPara, false, true, true); });

                cmdInsertStationType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertStationNumber(cmdPara, true, true, true); });
                cmdInsertStationTypeTools = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertStationNumberTools(cmdPara, true, true, true); });
                cmdInsertStationTypeDrills = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertStationNumberDrills(cmdPara, true, true, true); });
                cmdInsertStationTypeSpares = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertStationNumberSpares(cmdPara, true, true, true); });
                
                cmdInsertPartyOnGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertPartyForGrid(cmdPara, true, true, true); });
                //Filter for View
                cmdFilterByPlant = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } FilterByPlant(cmdPara); });
                cmdFilterByBallDia = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } FilterByBallDia(cmdPara); });
                cmdFilterByInk = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } FilterByInk(cmdPara); });
                cmdFilterByILD = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } FilterByILD(cmdPara); });
                cmdFilterByModelNo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } FilterByModelNo(cmdPara); });
                cmdFilterByCust = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } FilterByCustomer(cmdPara); });
                cmdLoad = new RelayCommand<object>(items => { if (items == null) { return; } LoadTDSView(); });
                cmdPrintReport = new GalaSoft.MvvmLight.Command.RelayCommand(() => { PrintExportReport(); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion

                FlipGridData = MC.BackflipList.ToList();
                BackFlipCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                BackFlipCollection.Filter = new Predicate<object>(Filter_FlipGrid);
                StringListBackflipData = MC.BackflipList.Select(x => x.doc_no).ToList();

                #region AutoSuggest Initialisation for view filters

                plantList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_FilterByLocation = new AutoSuggestTextViewModel<dynamic>(plantList, TheFilter, SuggestedValue, "location_Id", true);
                AS_FilterByLocation.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M009_P)x).modelno.ToString());
                TheFilter = (o, prefix) => (((ZADM_M009_P)o).modelno.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ZADM_M009_P)o).model_id.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                AS_FilterByModelNo = new AutoSuggestTextViewModel<dynamic>(MC.ModelList, TheFilter, SuggestedValue, "modelno", true);
                AS_FilterByModelNo.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M001_P)x).ball_dia_id.ToString());
                TheFilter = (o, prefix) => (((ZADM_M001_P)o).ball_dia_id.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ZADM_M001_P)o).Ball_dia.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                AS_FilterByBallDia = new AutoSuggestTextViewModel<dynamic>(MC.BallDiaList, TheFilter, SuggestedValue, "ball_dia_id", true);
                AS_FilterByBallDia.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M006_P)x).ink);
                TheFilter = (o, prefix) => (((ZADM_M006_P)o).ink ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_FilterByInk = new AutoSuggestTextViewModel<dynamic>(MC.Ink, TheFilter, SuggestedValue, "ink", true);
                AS_FilterByInk.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M007_P)x).ild);
                TheFilter = (o, prefix) => (((ZADM_M007_P)o).ild ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ZADM_M007_P)o).ild_id.ToString() ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_FilterByILD = new AutoSuggestTextViewModel<dynamic>(MC.Ref_ILD, TheFilter, SuggestedValue, "ild", true);
                AS_FilterByILD.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_FilterCustomer = new AutoSuggestTextViewModel<dynamic>(MC.CustomerList, TheFilter, SuggestedValue, "PartyId", true);
                AS_FilterCustomer.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_Customer = new AutoSuggestTextViewModel<dynamic>(MC.CustomerList, TheFilter, SuggestedValue, "PartyId", true);
                AS_Customer.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M007_P)x).ild);
                TheFilter = (o, prefix) => (((ZADM_M007_P)o).ild ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_ILDRef = new AutoSuggestTextViewModel<dynamic>(MC.Ref_ILD, TheFilter, SuggestedValue, "ild", true);
                AS_ILDRef.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyId);
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M028_P)o).PartyNm ?? "").ToString().ToLower().Contains(prefix.ToLower()); 
                AS_PartyRef = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyId", true);
                AS_PartyRef.AutoSuggestVM.IsEmptyValueAllowed = true;
                #endregion

                var Tools = (from o in MC.ItemList where o.SubCatCode == "SC39" || o.SubCatCode == "SC12" select o).ToList();
                ToolsItemCollection = CollectionViewSource.GetDefaultView(Tools);
                ToolsItemCollection.Filter = new Predicate<object>(Filter_ToolsItem);
                StringListItem1 = MC.ItemList.Select(x => x.ItemCode).ToList();

                var Drills = (from o in MC.ItemList where o.SubCatCode == "SC07" select o).ToList();
                DrillsItemCollection = CollectionViewSource.GetDefaultView(Drills);
                DrillsItemCollection.Filter = new Predicate<object>(Filter_DrillsItem);
                StringListDrillsItem = MC.ItemList.Select(x => x.ItemCode).ToList();

                var Spares = (from o in MC.ItemList where o.SubCatCode == "SC29" select o).ToList();
                SparesItemCollection = CollectionViewSource.GetDefaultView(Spares);
                SparesItemCollection.Filter = new Predicate<object>(Filter_SparesItem);
                StringListSparesItem = MC.ItemList.Select(x => x.ItemCode).ToList();

                InkCollection = CollectionViewSource.GetDefaultView(MC.Ink.ToList());
                InkCollection.Filter = new Predicate<object>(Filter_InkMasterCollection);
                StringListInk = MC.Ink.Select(x => x.ink).ToList();

                ILDCollection = CollectionViewSource.GetDefaultView(MC.ILD.ToList());
                ILDCollection.Filter = new Predicate<object>(Filter_ILDMasterCollection);
                StringListILD = MC.ILD.Select(x => x.ild).ToList();

                PartyCollection = CollectionViewSource.GetDefaultView(MC.PartyMaster.ToList());
                PartyCollection.Filter = new Predicate<object>(Filter_PartyMaster);
                StringListParty = MC.PartyMaster.Select(x => x.PartyId).ToList();

                plantList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                plantCollection = CollectionViewSource.GetDefaultView(plantList);
                plantCollection.Filter = new Predicate<object>(Filter_Plant);
                StringListplant = plantList.Select(x => x.location_Id).ToList();

                ModelCollection = CollectionViewSource.GetDefaultView(MC.ModelList.ToList());
                ModelCollection.Filter = new Predicate<object>(Filter_Model);
                StringListModel = MC.ModelList.Select(x => x.model_id.ToString()).ToList();

                StationnoCollection = CollectionViewSource.GetDefaultView(MC.StationNoList.ToList());
                StationnoCollection.Filter = new Predicate<object>(Filter_Stationno);
                StringListStationno = MC.StationNoList.Select(x => x.value_code.ToString()).ToList();

                SpecTypeCollection = CollectionViewSource.GetDefaultView(MC.SpecificationTypeList.ToList());
                SpecTypeCollection.Filter = new Predicate<object>(Filter_SpecType);
                StringListSpecType = MC.SpecificationTypeList.Select(x => x.spec_type_code.ToString()).ToList();

                SpecParaCollection = CollectionViewSource.GetDefaultView(MC.SpecificationParaList.ToList());
                SpecParaCollection.Filter = new Predicate<object>(Filter_SpecPara);
                StringListSpecType = MC.SpecificationParaList.Select(x => x.spec_para_code.ToString()).ToList();

                WireTypeCollection = CollectionViewSource.GetDefaultView(MC.WireTypeList.ToList());
                WireTypeCollection.Filter = new Predicate<object>(Filter_WireTypeCollection);
                StringListWireType = MC.WireTypeList.Select(x => x.wire_type).ToList();

                GradeCollection = CollectionViewSource.GetDefaultView(MC.GradeList.ToList());
                GradeCollection.Filter = new Predicate<object>(Filter_Grade);
                StringListGrade = MC.GradeList.Select(x => x.grade_code).ToList();

                BallDiaCollection = CollectionViewSource.GetDefaultView(MC.BallDiaList.ToList());
                BallDiaCollection.Filter = new Predicate<object>(Filter_BallDia);
                StringListBallDia = MC.BallDiaList.Select(x => x.ball_dia_id.ToString()).ToList();

                WireDiaCollection = CollectionViewSource.GetDefaultView(MC.WireDiaList.ToList());
                WireDiaCollection.Filter = new Predicate<object>(Filter_WireDia);
                StringListWireDia = MC.WireDiaList.Select(x => x.wire_size_id.ToString()).ToList();

                // Make
                ToolsMakeCollection = CollectionViewSource.GetDefaultView(MC.ParamValueList.ToList());
                ToolsMakeCollection.Filter = new Predicate<object>(Filter_Make);
                StringListToolsMake = MC.ParamValueList.Select(x => x.parametervalue.ToString()).ToList();

                InstrumentCollection = CollectionViewSource.GetDefaultView(MC.InstrumentList.ToList());
                InstrumentCollection.Filter = new Predicate<object>(Filter_Instrument);
                StringListInstrument = MC.InstrumentList.Select(x => x.spec_para_code.ToString()).ToList();

                WorkingCollection = CollectionViewSource.GetDefaultView(MC.WorkingList.ToList());
                WorkingCollection.Filter = new Predicate<object>(Filter_Working);
                StringListWorking = MC.WorkingList.Select(x => x.spec_para_code.ToString()).ToList();

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
        private void LoadItemDetails(object InputValue)
        {
            try
            {
                string Request = "LoadItemDetails";
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ENG_T004>(MC, Request, "TDS", "Production", "LoadItemDetails", 0, "");

                var para = (from o in MC.SelectedParameterDetails where o.doc_no == MasterEntity.doc_no4 select o).ToList();
                SelectedParaItemCollection = CollectionViewSource.GetDefaultView(para.ToList());
                SelectedParaItemCollection.Filter = new Predicate<object>(Filter_SelectedParaItem);
                StringListSelectedParaData = MC.SelectedParameterDetails.Select(x => x.spec_para_code).ToList();

                var Tools = (from o in MC.SelectedItemDetails where o.type == "Tools" && o.doc_no == MasterEntity.doc_no1 select o).ToList();
                SelectedItemToolCollection = CollectionViewSource.GetDefaultView(Tools.ToList());
                SelectedItemToolCollection.Filter = new Predicate<object>(Filter_ToolItem);
                StringListSelectedItem = MC.SelectedItemDetails.Select(x => x.ItemCode).ToList();

                var Drills = (from o in MC.SelectedItemDetails where o.type == "Drills" && o.doc_no == MasterEntity.doc_no2 select o).ToList();
                SelectedDrillItemCollection = CollectionViewSource.GetDefaultView(Drills.ToList());
                SelectedDrillItemCollection.Filter = new Predicate<object>(Filter_DrillItem);
                StringListSelectedDrillItem = MC.SelectedItemDetails.Select(x => x.ItemCode).ToList();

                var Spares = (from o in MC.SelectedItemDetails where o.type == "Spares" && o.doc_no == MasterEntity.doc_no3 select o).ToList();
                SelectedSpareItemCollection = CollectionViewSource.GetDefaultView(Spares.ToList());
                SelectedSpareItemCollection.Filter = new Predicate<object>(Filter_SpareItem);
                StringListSelectedSpareItem = MC.SelectedItemDetails.Select(x => x.ItemCode).ToList();
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

        #region Event Handler
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (ReferencesEntity.Count > dgSelectedIndexReferences && dgSelectedIndexReferences >= 0)
            {
                this.ErrorExist = false; /* ParameterEntity[dgSelectedIndexParaCode].HasErrors;*/
            }

        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
            if (ReferencesEntity.Count > dgSelectedIndexReferences && dgSelectedIndexReferences >= 0)
            {
                this.ErrorExist = false;/*ParameterEntity[dgSelectedIndexItem].HasErrors;*/
            }
        }
        private void CollectionChangedNotifyForParameter(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (ENG_T004_C item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (ENG_T004_C item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ENG_T004_C item in e.NewItems)
                    {
                        item.doc_no = MasterEntity.doc_no;
                        item.doc_cat = MasterEntity.doc_cat;
                        item.doc_type = MasterEntity.doc_type;
                        item.active = true;
                        item.t_status = "001";
                        item.add_by = AppSessionState.UserID;
                        item.comp_code = AppSessionState.comp_code;
                        item.location_Id = AppSessionState.location_Id;
                        item.editby = AppSessionState.UserID;
                        item.user_source1 = AppSessionState.UserSource1;
                        item.user_source2 = AppSessionState.UserSource2;
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region . User Defined Function .

        private void OpenDocumentViewer(object InputValue)
        {
            //if (!string.IsNullOrEmpty(MasterEntity.ItemCode.ToString()))
            //{
            //    //this.IsDocumentViewerShow = !IsDocumentViewerShow;
            //    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.ItemCode.ToString().Replace("/", "--"), DocumentList = MCTemp.AttachmentList, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            //}

            WebServiceRepository<MultipleContext_Attachments> repository_MCAttachments = new WebServiceRepository<MultipleContext_Attachments>();
            List<COM_T003> Attachments = new List<COM_T003>();
            ENG_T004_B EntityObjectParameter = new ENG_T004_B();
            MultipleContext_Attachments MCAttachments = new MultipleContext_Attachments();
            try
            {
                if (InputValue != null)
                {
                    EntityObjectParameter = ((IEnumerable)InputValue).Cast<ENG_T004_B>().ToList()[0];
                }
                //string Request = "GetAllFiles" + "!@" + EntityObjectParameter.ItemCode;
                string Request = "GetAllFiles" + "!@" + AppSessionState.client + "!@" + (EntityObjectParameter.comp_code ?? AppSessionState.comp_code) + "!@" + (EntityObjectParameter.location_Id ?? AppSessionState.location_Id) + "!@!@!@" + EntityObjectParameter.doc_no + "!@" + EntityObjectParameter.id;
                MCAttachments = repository_MCAttachments.GetDataWithReturnDomainObject<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                if (!string.IsNullOrEmpty(EntityObjectParameter.ItemCode))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), Row_ID = EntityObjectParameter.id.ToString(), DocumentList = MCAttachments.Attachments, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>(); showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        private void OpenItemViewer(object InputValue)
        {
            try
            {
                ENG_T004_B objItem = (ENG_T004_B)InputValue;
                if (objItem != null)
                {
                    var FileList = AttachmentCollection.Where(x => x.doc_no == objItem.ItemCode).ToList();
                    if (!string.IsNullOrEmpty(objItem.ItemCode.ToString()))
                    {
                        Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = objItem.ItemCode.ToString().Replace("/", "--"), DocumentList = FileList, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>(); showMessageService.ButtonSetup = DialogButton.Ok; showMessageService.Caption = "Message"; showMessageService.Text = String.Format(ex.Message, this.Title); showMessageService.ShowMessage();
            }
        }
        private void DeleteDataGridRow_Tools(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ToolsDetailEntity.Count > i && ToolsDetailEntity[dgSelectedIndexTools].id == 0)
                {
                    ToolsDetailEntity.RemoveAt(i);
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
        private void DeleteDataGridRow_Drills(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (DrillsDetailEntity.Count > i && DrillsDetailEntity[dgSelectedIndexDrills].id == 0)
                {
                    DrillsDetailEntity.RemoveAt(i);
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
        private void DeleteDataGridRow_Spares(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (SparesDetailEntity.Count > i && SparesDetailEntity[dgSelectedIndexSpares].id == 0)
                {
                    SparesDetailEntity.RemoveAt(i);
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
        private void DeleteDataGridRow_ParameterDetails(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ParaDetailEntity.Count > i && ParaDetailEntity[dgSelectedIndexParaDetails].id == 0)
                {
                    ParaDetailEntity.RemoveAt(i);
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
        private void DeleteDataGridRow_BallDetails(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (BallDetailEntity.Count > i && BallDetailEntity[dgSelectedIndexBallDetails].id == 0)
                {
                    BallDetailEntity.RemoveAt(i);
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
        private void DeleteDataGridRow_WireDetails(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (WireDetailEntity.Count > i && WireDetailEntity[dgSelectedIndexWireDetails].id == 0)
                {
                    WireDetailEntity.RemoveAt(i);
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
        private void DeleteDataGridRow_InkDetails(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (InkDetailEntity.Count > i && InkDetailEntity[dgSelectedIndexInkDetails].id == 0)
                {
                    InkDetailEntity.RemoveAt(i);
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

        private void DeleteDataGridRow_PartyDetails(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (PartyEntity.Count > i && PartyEntity[dgSelectedIndexParty].id == 0)
                {
                    PartyEntity.RemoveAt(i);
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
            try
            {
                ENG_T004_P ParameterEntityObject = null;

                if (ParameterObject != null)
                {
                    if (((IEnumerable)ParameterObject).Cast<ENG_T004_P>().ToList().Count > 0)
                    {
                        ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ENG_T004_P>().ToList()[0];
                        isNewRecord = false;

                        string Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.doc_no + "!@" + AppSessionState.location_Id;
                        MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ENG_T004>(MC, Request, "TDS", "Production", "LoadInitialData", 0, "");

                        ToolsDetailEntity = new ObservableCollection<ENG_T004_B>();
                        DrillsDetailEntity = new ObservableCollection<ENG_T004_B>();
                        SparesDetailEntity = new ObservableCollection<ENG_T004_B>();
                        BallDetailEntity = new ObservableCollection<ENG_T004_B>();
                        WireDetailEntity = new ObservableCollection<ENG_T004_B>();
                        InkDetailEntity = new ObservableCollection<ENG_T004_B>();
                        MasterEntity = MCTemp.MasterEntity[0];
                        ParaDetailEntity = MCTemp.ParaDetailEntity;
                        ReferencesEntity = MCTemp.ReferencesList;
                        PartyEntity = MCTemp.PartyList;
                        MasterEntity.ts_code = ts_code_vm;
                        //Tools/Drills/Spares Data
                        foreach (var data in MCTemp.ControlParaDetailEntity)
                        {
                            if (data.type == "Tools")
                            {
                                ToolsDetailEntity.Add(data);
                            }
                            else if (data.type == "Drills")
                            {
                                DrillsDetailEntity.Add(data);
                            }
                            else if (data.type == "Spares")
                            {
                                SparesDetailEntity.Add(data);
                            }
                            else if (data.type == "Ball")
                            {
                                BallDetailEntity.Add(data);
                            }
                            else if (data.type == "Wire")
                            {
                                WireDetailEntity.Add(data);
                            }
                            else if (data.type == "Ink")
                            {
                                InkDetailEntity.Add(data);
                            }
                        }

                        //Attachment Data
                        if (MCTemp.Attachment != null)
                        {
                            AttachmentCollection = MCTemp.Attachment;
                        }
                        else
                        {
                            MCTemp.Attachment = new List<COM_T003>();
                        }
                        SelectedTabControlIndex = 0;
                        EnableCheckBox = true;

                        if (MasterEntity.location_Id != null && MasterEntity.location_Id != "")
                        {
                            var abc = from o in MC.MachineList
                                      where o.location_Id == MasterEntity.location_Id
                                      select o;

                            MachineCollection = CollectionViewSource.GetDefaultView(abc.ToList());
                            MachineCollection.Filter = new Predicate<object>(Filter_Machine);
                            StringListMachine = MC.MachineList.Select(x => x.machinecode).ToList();
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
        private void InsertInkDetailsInk(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M006_P POPUPEntityObject = null;

                //if (_FilterStringSearchTools != "")
                //{
                //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                //    showMessageService.ButtonSetup = DialogButton.Ok;
                //    showMessageService.Caption = "Message";
                //    showMessageService.Text = String.Format("Please Clear the Text: " + _FilterStringSearchTools);
                //    showMessageService.ShowMessage();
                //}
                //else
                {
                    try
                    {
                        if (InputValue.GetType() == typeof(string) && InputValue != null)
                        {
                            Request = InputValue.ToString();
                            if (Request.Length > 0)
                            {
                                try
                                { POPUPEntityObject = MC.Ink.Where(x => x.ink.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                                catch (Exception ex) { }
                            }
                        }
                        else if (InputValue != null)
                        {
                            if (((IEnumerable)InputValue).Cast<ZADM_M006_P>().Count() > 0)
                            {
                                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M006_P>().ToList()[0];
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
                    if (POPUPEntityObject != null)
                    {
                        var InputValueIfExists = InkDetailEntity.Where(x => x.ink == POPUPEntityObject.ink).FirstOrDefault();
                        int IndexOfExistValue = InkDetailEntity.IndexOf(InkDetailEntity.Where(X => X.ink == POPUPEntityObject.ink).FirstOrDefault());
                        //Insert
                        if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && InkDetailEntity.Count == dgSelectedIndexInkDetails)
                        {
                            InkDetailEntity.Add(new ENG_T004_B()
                            {
                                id = 0,
                                type = "Ink",
                                ink_id = POPUPEntityObject.ink_id,
                                ink = POPUPEntityObject.ink,
                                active = true,
                                location_Id = AppSessionState.location_Id,
                                comp_code = AppSessionState.comp_code,
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID,
                                t_status = "001"
                            });
                        }
                        else if (dgSelectedIndexInkDetails >= 0 && InkDetailEntity.Count > dgSelectedIndexInkDetails)
                        {
                            if (InkDetailEntity[dgSelectedIndexInkDetails].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                            {
                                InkDetailEntity[dgSelectedIndexInkDetails].ink_id = POPUPEntityObject.ink_id;
                                InkDetailEntity[dgSelectedIndexInkDetails].ink = POPUPEntityObject.ink;
                                InkDetailEntity[dgSelectedIndexInkDetails].location_Id = AppSessionState.location_Id;
                                InkDetailEntity[dgSelectedIndexInkDetails].comp_code = AppSessionState.comp_code;
                                InkDetailEntity[dgSelectedIndexInkDetails].add_by = AppSessionState.UserID;
                                InkDetailEntity[dgSelectedIndexInkDetails].editby = AppSessionState.UserID;
                                InkDetailEntity[dgSelectedIndexInkDetails].active = true;
                                InkDetailEntity[dgSelectedIndexInkDetails].type = "Ink";
                                InkDetailEntity[dgSelectedIndexInkDetails].t_status = "001";
                            }
                            else if (InkDetailEntity[dgSelectedIndexInkDetails].ink != POPUPEntityObject.ink)
                            {
                                InkDetailEntity[dgSelectedIndexInkDetails].ink_id = 0;
                                InkDetailEntity[dgSelectedIndexInkDetails].ink = "";
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
        private void DefaultValues()
        {
            MasterEntity.doc_cat = "TD";
            MasterEntity.doc_type = "TD";
            MasterEntity.location_Id = AppSessionState.location_Id;

            var abc1 = from o in plantList
                       where o.location_Id == MasterEntity.location_Id
                       select o;

            MasterEntity.LoctnNm = abc1.ToList()[0].LoctnNm;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            //MasterEntity.add_date = DateTime.Now;
            //MasterEntity.edit_date = DateTime.Now;
            MasterEntity.t_status = "001";
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.active = true;
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.revision_no = 1;
            MasterEntity.revision_date = DateTime.Now;

            if (MasterEntity.location_Id != null && MasterEntity.location_Id != "")
            {
                var abc = from o in MC.MachineList
                          where o.location_Id == MasterEntity.location_Id
                          select o;

                MachineCollection = CollectionViewSource.GetDefaultView(abc.ToList());
                MachineCollection.Filter = new Predicate<object>(Filter_Machine);
                StringListMachine = MC.MachineList.Select(x => x.machinecode).ToList();
            }
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;

        }
        private void InsertItem(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M022_P POPUPEntityObject = null;
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.ItemList.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex)
                            {
                            }
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
                    MasterEntity.ItemName = POPUPEntityObject.ItemName;
                    MasterEntity.unit_code = POPUPEntityObject.unit_code;
                    MasterEntity.ink_id = POPUPEntityObject.ink_id;
                    MasterEntity.ild_id = POPUPEntityObject.ild_id;
                    MasterEntity.ink = POPUPEntityObject.ink;
                    MasterEntity.ild = POPUPEntityObject.ild;
                    MasterEntity.wire_type_id = POPUPEntityObject.wire_type_id;
                    MasterEntity.Wire_Type = POPUPEntityObject.wire_type;

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

                    if (MasterEntity.location_Id != null && MasterEntity.location_Id != "")

                    {
                        var abc = from o in MC.MachineList
                                  where o.location_Id == MasterEntity.location_Id
                                  select o;

                        MachineCollection = CollectionViewSource.GetDefaultView(abc.ToList());
                        MachineCollection.Filter = new Predicate<object>(Filter_Machine);
                        StringListMachine = MC.MachineList.Select(x => x.machinecode).ToList();
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
        private void InsertUnit(object InputValue)
        {
            try
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
                catch (Exception ex)
                {

                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format(ex.Message, this.Title);
                    showMessageService.ShowMessage();
                }
                if (POPUPEntityObject != null)
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
        private void InsertInk(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M006_P POPUPEntityObject = null;
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Ink.Where(x => x.ink.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex)
                            {
                            }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M006_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.ink_id = POPUPEntityObject.ink_id;
                    MasterEntity.ink = POPUPEntityObject.ink;

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
        private void InsertIld(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M007_P POPUPEntityObject = null;
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.ILD.Where(x => x.ild.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex)
                            {
                            }
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
                    MasterEntity.ild_id = POPUPEntityObject.ild_id;
                    MasterEntity.ild = POPUPEntityObject.ild;
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
        private void InsertModel(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M009_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.ModelList.Where(x => x.model_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M009_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.model_id = POPUPEntityObject.model_id;
                    MasterEntity.modelno = POPUPEntityObject.modelno;
                    MasterEntity.modeldesc = POPUPEntityObject.modeldesc;

                    if (POPUPEntityObject.modelno != "" && POPUPEntityObject.modelno != null)
                    {
                        var abc = (from data in MC.ItemList
                                   where data.model_id == POPUPEntityObject.model_id
                                   select data).ToList();

                        ItemCollection = CollectionViewSource.GetDefaultView(abc.ToList());
                        ItemCollection.Filter = new Predicate<object>(Filter_Item);
                        StringListItem = abc.Select(x => x.ItemCode).ToList();

                    }
                    else
                    {
                        var Item = (from o in MC.ItemList where o.CatCode == "FG" select o).ToList();
                        ItemCollection = CollectionViewSource.GetDefaultView(Item.ToList());
                        ItemCollection.Filter = new Predicate<object>(Filter_Item);
                        StringListItem = Item.Select(x => x.ItemCode).ToList();
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
        private void InsertMachine(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M013_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                try
                {

                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.MachineList.Where(x => x.machinecode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M013_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.machinecode = POPUPEntityObject.machinecode;
                    MasterEntity.machine_id = POPUPEntityObject.machine_id;
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
        private void InsertWireType(object InputValue)
        {
            try
            {

            }
            catch (Exception)
            {

                throw;
            }
            string Request = "";
            ZADM_M004_P POPUPEntityObject = null;

            #region Command Parameter Read Section
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WireTypeList.Where(x => x.wire_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M004_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            #endregion
            if (POPUPEntityObject != null)
            {
                MasterEntity.wire_type_id = POPUPEntityObject.wire_type_id;
                MasterEntity.Wire_Type = POPUPEntityObject.wire_type;
            }
        }

        private void InsertStationNumber(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M030_P POPUPEntityObject = null;

                if (_FilterStringSearchPara != "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Clear the Text: " + _FilterStringSearchPara);
                    showMessageService.ShowMessage();

                }
                else
                {
                    #region Command Parameter Read Section
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.StationNoList.Where(x => x.parametervalue.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                        var InputValueIfExists = ParaDetailEntity.Where(X => X.parametervalue == POPUPEntityObject.parametervalue).FirstOrDefault(); // Prefer Primary Key for this instruction.
                        int IndexOfExistValue = ParaDetailEntity.IndexOf(ParaDetailEntity.Where(X => X.parametervalue == POPUPEntityObject.parametervalue).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.
                        var LineId = ParaDetailEntity.Count + 1;
                        if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ParaDetailEntity.Count == dgSelectedIndexParaDetails)
                        {
                            ParaDetailEntity.Add(new ENG_T004_A()
                            {
                                id = 0,
                                line_id = LineId,
                                sr_no = POPUPEntityObject.parametervalue,
                                //sr_no = POPUPEntityObject.value_code,
                                comp_code = AppSessionState.comp_code,
                                location_Id = AppSessionState.location_Id,
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID,
                                t_status = "001",
                                active = true,
                            });
                        }
                        else if (dgSelectedIndexParaDetails >= 0 && ParaDetailEntity.Count > dgSelectedIndexParaDetails) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                        {
                            if (ParaDetailEntity[dgSelectedIndexParaDetails].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                            {
                                if (ParaDetailEntity[dgSelectedIndexParaDetails].line_id == 0)
                                {
                                    ParaDetailEntity[dgSelectedIndexParaDetails].line_id = ParaDetailEntity.Count;
                                }
                                ParaDetailEntity[dgSelectedIndexParaDetails].sr_no = POPUPEntityObject.parametervalue;
                                //ParaDetailEntity[dgSelectedIndexParaDetails].sr_no = POPUPEntityObject.value_code;
                                ParaDetailEntity[dgSelectedIndexParaDetails].comp_code = AppSessionState.comp_code;
                                ParaDetailEntity[dgSelectedIndexParaDetails].location_Id = AppSessionState.location_Id;
                                ParaDetailEntity[dgSelectedIndexParaDetails].add_by = AppSessionState.UserID;
                                ParaDetailEntity[dgSelectedIndexParaDetails].editby = AppSessionState.UserID;
                                ParaDetailEntity[dgSelectedIndexParaDetails].t_status = "001";
                                ParaDetailEntity[dgSelectedIndexParaDetails].active = true;
                            }
                            else if (ParaDetailEntity[dgSelectedIndexParaDetails].parametervalue != POPUPEntityObject.parametervalue)
                            {
                                ParaDetailEntity[dgSelectedIndexParaDetails].sr_no = POPUPEntityObject.parametervalue; ;
                                //ParaDetailEntity[dgSelectedIndexParaDetails].sr_no = POPUPEntityObject.value_code;
                            }
                        }
                    }


                    #region Clear Empty Row
                    ENG_T004_A newObj = new ENG_T004_A();
                    for (int i = ParaDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = ParaDetailEntity[i].ComparePropertiesTo(newObj);
                        if (ParaDetailEntity[i].ComparePropertiesTo(newObj) == true && ParaDetailEntity.Count > 1)
                        {
                            ParaDetailEntity.RemoveAt(i);
                            if (ParaDetailEntity.Count == 0)
                            {
                                ParaDetailEntity.Add(newObj);
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
        private void InsertStationNumberTools(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M030_P POPUPEntityObject = null;

                if (_FilterStringSearchPara != "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Clear the Text: " + _FilterStringSearchPara);
                    showMessageService.ShowMessage();

                }
                else
                {
                    #region Command Parameter Read Section
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.StationNoList.Where(x => x.parametervalue.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                        var InputValueIfExists = ToolsDetailEntity.Where(X => X.parametervalue == POPUPEntityObject.parametervalue).FirstOrDefault(); // Prefer Primary Key for this instruction.
                        int IndexOfExistValue = ToolsDetailEntity.IndexOf(ToolsDetailEntity.Where(X => X.parametervalue == POPUPEntityObject.parametervalue).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                        if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ToolsDetailEntity.Count == dgSelectedIndexTools)
                        {
                            ToolsDetailEntity.Add(new ENG_T004_B()
                            {
                                id = 0,
                                stn_no = POPUPEntityObject.parametervalue,
                                //stn_no = POPUPEntityObject.value_code,
                                comp_code = AppSessionState.comp_code,
                                location_Id = AppSessionState.location_Id,
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID,
                                t_status = "001",
                                active = true,
                            });
                        }
                        else if (dgSelectedIndexTools >= 0 && ToolsDetailEntity.Count > dgSelectedIndexTools) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                        {
                            if (ToolsDetailEntity[dgSelectedIndexTools].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                            {
                                ToolsDetailEntity[dgSelectedIndexTools].stn_no = POPUPEntityObject.parametervalue;
                                //ToolsDetailEntity[dgSelectedIndexTools].stn_no = POPUPEntityObject.value_code;
                                ToolsDetailEntity[dgSelectedIndexTools].comp_code = AppSessionState.comp_code;
                                ToolsDetailEntity[dgSelectedIndexTools].location_Id = AppSessionState.location_Id;
                                ToolsDetailEntity[dgSelectedIndexTools].add_by = AppSessionState.UserID;
                                ToolsDetailEntity[dgSelectedIndexTools].editby = AppSessionState.UserID;
                                ToolsDetailEntity[dgSelectedIndexTools].t_status = "001";
                                ToolsDetailEntity[dgSelectedIndexTools].active = true;
                            }
                            else if (ToolsDetailEntity[dgSelectedIndexTools].parametervalue != POPUPEntityObject.parametervalue)
                            {
                                ToolsDetailEntity[dgSelectedIndexTools].stn_no = POPUPEntityObject.parametervalue; ;
                                //ToolsDetailEntity[dgSelectedIndexTools].stn_no = POPUPEntityObject.value_code;
                            }
                        }
                    }


                    #region Clear Empty Row
                    ENG_T004_B newObj = new ENG_T004_B();
                    for (int i = ToolsDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = ToolsDetailEntity[i].ComparePropertiesTo(newObj);
                        if (ToolsDetailEntity[i].ComparePropertiesTo(newObj) == true && ToolsDetailEntity.Count > 1)
                        {
                            ToolsDetailEntity.RemoveAt(i);
                            if (ToolsDetailEntity.Count == 0)
                            {
                                ToolsDetailEntity.Add(newObj);
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
        private void InsertStationNumberDrills(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M030_P POPUPEntityObject = null;

                if (_FilterStringSearchPara != "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Clear the Text: " + _FilterStringSearchPara);
                    showMessageService.ShowMessage();

                }
                else
                {
                    #region Command Parameter Read Section
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.StationNoList.Where(x => x.parametervalue.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                        var InputValueIfExists = DrillsDetailEntity.Where(X => X.parametervalue == POPUPEntityObject.parametervalue).FirstOrDefault(); // Prefer Primary Key for this instruction.
                        int IndexOfExistValue = DrillsDetailEntity.IndexOf(DrillsDetailEntity.Where(X => X.parametervalue == POPUPEntityObject.parametervalue).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                        if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && DrillsDetailEntity.Count == dgSelectedIndexDrills)
                        {
                            DrillsDetailEntity.Add(new ENG_T004_B()
                            {
                                id = 0,
                                stn_no = POPUPEntityObject.parametervalue,
                                //stn_no = POPUPEntityObject.value_code,
                                comp_code = AppSessionState.comp_code,
                                location_Id = AppSessionState.location_Id,
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID,
                                t_status = "001",
                                active = true,
                            });
                        }
                        else if (dgSelectedIndexDrills >= 0 && DrillsDetailEntity.Count > dgSelectedIndexDrills) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                        {
                            if (DrillsDetailEntity[dgSelectedIndexDrills].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                            {
                                DrillsDetailEntity[dgSelectedIndexDrills].stn_no = POPUPEntityObject.parametervalue;
                                // DrillsDetailEntity[dgSelectedIndexDrills].stn_no = POPUPEntityObject.value_code;
                                DrillsDetailEntity[dgSelectedIndexDrills].comp_code = AppSessionState.comp_code;
                                DrillsDetailEntity[dgSelectedIndexDrills].location_Id = AppSessionState.location_Id;
                                DrillsDetailEntity[dgSelectedIndexDrills].add_by = AppSessionState.UserID;
                                DrillsDetailEntity[dgSelectedIndexDrills].editby = AppSessionState.UserID;
                                DrillsDetailEntity[dgSelectedIndexDrills].t_status = "001";
                                DrillsDetailEntity[dgSelectedIndexDrills].active = true;
                            }
                            else if (DrillsDetailEntity[dgSelectedIndexDrills].parametervalue != POPUPEntityObject.parametervalue)
                            {
                                DrillsDetailEntity[dgSelectedIndexDrills].stn_no = POPUPEntityObject.parametervalue; ;
                                //DrillsDetailEntity[dgSelectedIndexDrills].stn_no = POPUPEntityObject.value_code;
                            }
                        }
                    }


                    #region Clear Empty Row
                    ENG_T004_B newObj = new ENG_T004_B();
                    for (int i = DrillsDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = DrillsDetailEntity[i].ComparePropertiesTo(newObj);
                        if (DrillsDetailEntity[i].ComparePropertiesTo(newObj) == true && DrillsDetailEntity.Count > 1)
                        {
                            DrillsDetailEntity.RemoveAt(i);
                            if (DrillsDetailEntity.Count == 0)
                            {
                                DrillsDetailEntity.Add(newObj);
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
        private void InsertStationNumberSpares(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M030_P POPUPEntityObject = null;

                if (_FilterStringSearchPara != "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Clear the Text: " + _FilterStringSearchPara);
                    showMessageService.ShowMessage();

                }
                else
                {
                    #region Command Parameter Read Section
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.StationNoList.Where(x => x.parametervalue.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                        var InputValueIfExists = SparesDetailEntity.Where(X => X.parametervalue == POPUPEntityObject.parametervalue).FirstOrDefault(); // Prefer Primary Key for this instruction.
                        int IndexOfExistValue = SparesDetailEntity.IndexOf(SparesDetailEntity.Where(X => X.parametervalue == POPUPEntityObject.parametervalue).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                        if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && SparesDetailEntity.Count == dgSelectedIndexSpares)
                        {
                            SparesDetailEntity.Add(new ENG_T004_B()
                            {
                                id = 0,
                                stn_no = POPUPEntityObject.parametervalue,
                                //stn_no = POPUPEntityObject.value_code,
                                comp_code = AppSessionState.comp_code,
                                location_Id = AppSessionState.location_Id,
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID,
                                t_status = "001",
                                active = true,
                            });
                        }
                        else if (dgSelectedIndexSpares >= 0 && SparesDetailEntity.Count > dgSelectedIndexSpares) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                        {
                            if (SparesDetailEntity[dgSelectedIndexSpares].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                            {
                                SparesDetailEntity[dgSelectedIndexSpares].stn_no = POPUPEntityObject.parametervalue;
                                //SparesDetailEntity[dgSelectedIndexSpares].stn_no = POPUPEntityObject.value_code;
                                SparesDetailEntity[dgSelectedIndexSpares].comp_code = AppSessionState.comp_code;
                                SparesDetailEntity[dgSelectedIndexSpares].location_Id = AppSessionState.location_Id;
                                SparesDetailEntity[dgSelectedIndexSpares].add_by = AppSessionState.UserID;
                                SparesDetailEntity[dgSelectedIndexSpares].editby = AppSessionState.UserID;
                                SparesDetailEntity[dgSelectedIndexSpares].t_status = "001";
                                SparesDetailEntity[dgSelectedIndexSpares].active = true;
                            }
                            else if (SparesDetailEntity[dgSelectedIndexSpares].parametervalue != POPUPEntityObject.parametervalue)
                            {
                                SparesDetailEntity[dgSelectedIndexSpares].stn_no = POPUPEntityObject.parametervalue; ;
                                //SparesDetailEntity[dgSelectedIndexSpares].stn_no = POPUPEntityObject.value_code;
                            }
                        }
                    }


                    #region Clear Empty Row
                    ENG_T004_B newObj = new ENG_T004_B();
                    for (int i = SparesDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = SparesDetailEntity[i].ComparePropertiesTo(newObj);
                        if (SparesDetailEntity[i].ComparePropertiesTo(newObj) == true && SparesDetailEntity.Count > 1)
                        {
                            SparesDetailEntity.RemoveAt(i);
                            if (SparesDetailEntity.Count == 0)
                            {
                                SparesDetailEntity.Add(newObj);
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
        private void InsertSpecificationType(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ENG_T002 POPUPEntityObject = null;

                if (_FilterStringSearchPara != "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Clear the Text: " + _FilterStringSearchPara);
                    showMessageService.ShowMessage();

                }
                else
                {
                    #region Command Parameter Read Section
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SpecificationTypeList.Where(x => x.spec_type_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        if (((IEnumerable)InputValue).Cast<ENG_T002>().Count() > 0)
                        {
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T002>().ToList()[0];
                        }
                    }

                    #endregion

                    if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                    {
                        var InputValueIfExists = ParaDetailEntity.Where(X => X.spec_type_code == POPUPEntityObject.spec_type_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                        int IndexOfExistValue = ParaDetailEntity.IndexOf(ParaDetailEntity.Where(X => X.spec_type_code == POPUPEntityObject.spec_type_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                        if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ParaDetailEntity.Count == dgSelectedIndexParaDetails)
                        {
                            ParaDetailEntity.Add(new ENG_T004_A()
                            {
                                id = 0,
                                spec_type_code = POPUPEntityObject.spec_type_code,
                                spec_type = POPUPEntityObject.spec_type,
                                comp_code = AppSessionState.comp_code,
                                location_Id = AppSessionState.location_Id,
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID,
                                t_status = "001",
                                active = true,
                            });
                        }
                        else if (dgSelectedIndexParaDetails >= 0 && ParaDetailEntity.Count > dgSelectedIndexParaDetails) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                        {
                            if (ParaDetailEntity[dgSelectedIndexParaDetails].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                            {
                                ParaDetailEntity[dgSelectedIndexParaDetails].spec_type_code = POPUPEntityObject.spec_type_code;
                                ParaDetailEntity[dgSelectedIndexParaDetails].spec_type = POPUPEntityObject.spec_type;
                                ParaDetailEntity[dgSelectedIndexParaDetails].comp_code = AppSessionState.comp_code;
                                ParaDetailEntity[dgSelectedIndexParaDetails].location_Id = AppSessionState.location_Id;
                                ParaDetailEntity[dgSelectedIndexParaDetails].add_by = AppSessionState.UserID;
                                ParaDetailEntity[dgSelectedIndexParaDetails].editby = AppSessionState.UserID;
                                ParaDetailEntity[dgSelectedIndexParaDetails].t_status = "001";
                                ParaDetailEntity[dgSelectedIndexParaDetails].active = true;
                            }
                            else if (ParaDetailEntity[dgSelectedIndexParaDetails].spec_type_code != POPUPEntityObject.spec_type_code)
                            {
                                ParaDetailEntity[dgSelectedIndexParaDetails].spec_type_code = POPUPEntityObject.spec_type_code; ;
                                ParaDetailEntity[dgSelectedIndexParaDetails].spec_type = POPUPEntityObject.spec_type;
                            }
                        }
                    }


                    #region Clear Empty Row
                    ENG_T004_A newObj = new ENG_T004_A();
                    for (int i = ParaDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = ParaDetailEntity[i].ComparePropertiesTo(newObj);
                        if (ParaDetailEntity[i].ComparePropertiesTo(newObj) == true && ParaDetailEntity.Count > 1)
                        {
                            ParaDetailEntity.RemoveAt(i);
                            if (ParaDetailEntity.Count == 0)
                            {
                                ParaDetailEntity.Add(newObj);
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


        private void InsertBallDiameter(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M001_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BallDiaList.Where(x => x.ball_dia_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M001_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M001_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = BallDetailEntity.Where(X => X.ball_dia_id == POPUPEntityObject.ball_dia_id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = BallDetailEntity.IndexOf(BallDetailEntity.Where(X => X.ball_dia_id == POPUPEntityObject.ball_dia_id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && BallDetailEntity.Count == dgSelectedIndexBallDetails)
                    {
                        BallDetailEntity.Add(new ENG_T004_B()
                        {
                            id = 0,
                            type = "Ball",
                            ball_dia_id = POPUPEntityObject.ball_dia_id,
                            Ball_dia = POPUPEntityObject.ball_dia,
                            active = true,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID,
                            t_status = "001"
                        });
                    }
                    else if (dgSelectedIndexBallDetails >= 0 && BallDetailEntity.Count > dgSelectedIndexBallDetails) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (BallDetailEntity[dgSelectedIndexBallDetails].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            BallDetailEntity[dgSelectedIndexBallDetails].type = "Ball";
                            BallDetailEntity[dgSelectedIndexBallDetails].ball_dia_id = POPUPEntityObject.ball_dia_id;
                            BallDetailEntity[dgSelectedIndexBallDetails].Ball_dia = POPUPEntityObject.ball_dia;
                            BallDetailEntity[dgSelectedIndexBallDetails].active = true;
                            BallDetailEntity[dgSelectedIndexBallDetails].location_Id = AppSessionState.location_Id;
                            BallDetailEntity[dgSelectedIndexBallDetails].comp_code = AppSessionState.comp_code;
                            BallDetailEntity[dgSelectedIndexBallDetails].add_by = AppSessionState.UserID;
                            BallDetailEntity[dgSelectedIndexBallDetails].editby = AppSessionState.UserID;
                            BallDetailEntity[dgSelectedIndexBallDetails].t_status = "001";
                        }
                        else if (BallDetailEntity[dgSelectedIndexBallDetails].ball_dia_id != POPUPEntityObject.ball_dia_id)
                        {
                            //BallDetailEntity[dgSelectedIndexBallDetails].ball_dia_id = "";
                            //BallDetailEntity[dgSelectedIndexBallDetails].spec_type = "";
                        }
                    }
                }


                #region Clear Empty Row
                ENG_T004_B newObj = new ENG_T004_B();
                for (int i = BallDetailEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = BallDetailEntity[i].ComparePropertiesTo(newObj);
                    if (BallDetailEntity[i].ComparePropertiesTo(newObj) == true && BallDetailEntity.Count > 1)
                    {
                        BallDetailEntity.RemoveAt(i);
                        if (BallDetailEntity.Count == 0)
                        {
                            BallDetailEntity.Add(newObj);
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
        private void InsertWireDiameter(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M003_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WireDiaList.Where(x => x.wire_size_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M003_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M003_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = WireDetailEntity.Where(X => X.wire_dia_id == POPUPEntityObject.wire_size_id).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = WireDetailEntity.IndexOf(WireDetailEntity.Where(X => X.wire_dia_id == POPUPEntityObject.wire_size_id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && WireDetailEntity.Count == dgSelectedIndexWireDetails)
                    {
                        WireDetailEntity.Add(new ENG_T004_B()
                        {
                            id = 0,
                            type = "Wire",
                            wire_dia_id = POPUPEntityObject.wire_size_id,
                            wire_size = POPUPEntityObject.wire_size,
                            active = true,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID,
                            t_status = "001"
                        });
                    }
                    else if (dgSelectedIndexWireDetails >= 0 && WireDetailEntity.Count > dgSelectedIndexWireDetails) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (WireDetailEntity[dgSelectedIndexWireDetails].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                        {
                            WireDetailEntity[dgSelectedIndexWireDetails].type = "Wire";
                            WireDetailEntity[dgSelectedIndexWireDetails].wire_dia_id = POPUPEntityObject.wire_size_id;
                            WireDetailEntity[dgSelectedIndexWireDetails].wire_size = POPUPEntityObject.wire_size;
                            WireDetailEntity[dgSelectedIndexWireDetails].active = true;
                            WireDetailEntity[dgSelectedIndexWireDetails].location_Id = AppSessionState.location_Id;
                            WireDetailEntity[dgSelectedIndexWireDetails].comp_code = AppSessionState.comp_code;
                            WireDetailEntity[dgSelectedIndexWireDetails].add_by = AppSessionState.UserID;
                            WireDetailEntity[dgSelectedIndexWireDetails].editby = AppSessionState.UserID;
                            WireDetailEntity[dgSelectedIndexWireDetails].t_status = "001";

                        }
                        else if (WireDetailEntity[dgSelectedIndexWireDetails].wire_dia_id != POPUPEntityObject.wire_size_id)
                        {
                            //WireDetailEntity[dgSelectedIndexWireDetails].wire_dia_id = "";
                            //WireDetailEntity[dgSelectedIndexBallDetails].spec_type = "";
                        }
                    }
                }


                #region Clear Empty Row
                ENG_T004_B newObj = new ENG_T004_B();
                for (int i = WireDetailEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = WireDetailEntity[i].ComparePropertiesTo(newObj);
                    if (WireDetailEntity[i].ComparePropertiesTo(newObj) == true && WireDetailEntity.Count > 1)
                    {
                        WireDetailEntity.RemoveAt(i);
                        if (WireDetailEntity.Count == 0)
                        {
                            WireDetailEntity.Add(newObj);
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
        private void InsertItemForToolsGrid(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M022_P POPUPEntityObject = null;

                if (_FilterStringSearchTools != "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Clear the Text: " + _FilterStringSearchTools);
                    showMessageService.ShowMessage();
                }
                else
                {
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
                            if (((IEnumerable)InputValue).Cast<ADM_M022_P>().Count() > 0)
                            {
                                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
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
                    if (POPUPEntityObject != null)
                    {
                        var InputValueIfExists = ToolsDetailEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                        int IndexOfExistValue = ToolsDetailEntity.IndexOf(ToolsDetailEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());
                        //Insert
                        if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ToolsDetailEntity.Count == dgSelectedIndexTools)
                        {
                            ToolsDetailEntity.Add(new ENG_T004_B()
                            {
                                id = 0,
                                type = "Tools",
                                ItemCode = POPUPEntityObject.ItemCode,
                                ItemName = POPUPEntityObject.ItemName,
                                active = true,
                                location_Id = AppSessionState.location_Id,
                                comp_code = AppSessionState.comp_code,
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID,
                                t_status = "001"

                            });
                        }

                        else if (dgSelectedIndexTools >= 0 && ToolsDetailEntity.Count > dgSelectedIndexTools)
                        {
                            if (ToolsDetailEntity[dgSelectedIndexTools].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                            {

                                ToolsDetailEntity[dgSelectedIndexTools].ItemCode = POPUPEntityObject.ItemCode;
                                ToolsDetailEntity[dgSelectedIndexTools].ItemName = POPUPEntityObject.ItemName;
                                ToolsDetailEntity[dgSelectedIndexTools].location_Id = AppSessionState.location_Id;
                                ToolsDetailEntity[dgSelectedIndexTools].comp_code = AppSessionState.comp_code;
                                ToolsDetailEntity[dgSelectedIndexTools].add_by = AppSessionState.UserID;
                                ToolsDetailEntity[dgSelectedIndexTools].editby = AppSessionState.UserID;
                                ToolsDetailEntity[dgSelectedIndexTools].active = true;
                                ToolsDetailEntity[dgSelectedIndexTools].type = "Tools";
                                ToolsDetailEntity[dgSelectedIndexTools].t_status = "001";
                            }
                            else if (ToolsDetailEntity[dgSelectedIndexTools].ItemCode != POPUPEntityObject.ItemCode)
                            {
                                ToolsDetailEntity[dgSelectedIndexTools].ItemCode = "";
                                ToolsDetailEntity[dgSelectedIndexTools].ItemName = "";
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
        private void InsertSelectedParasOnGrid(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ENG_T004_A POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.SelectedParameterDetails.Where(x => x.spec_para_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ENG_T004_A>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T004_A>().ToList()[0];
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
            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ParaDetailEntity.Where(x => x.spec_para_code == POPUPEntityObject.spec_para_code).FirstOrDefault();
                if (NewRow == true)
                {
                    ParaDetailEntity.Add(new ENG_T004_A()
                    {
                        spec_type = POPUPEntityObject.spec_type,
                        range = POPUPEntityObject.range,
                        spec_para_code = POPUPEntityObject.spec_para_code,
                        spec_type_code = POPUPEntityObject.spec_type_code,
                        parameter = POPUPEntityObject.parameter,
                        instrument = POPUPEntityObject.parameter,
                        para_value = POPUPEntityObject.para_value,
                        tol_minus = POPUPEntityObject.tol_minus,
                        tol_plus = POPUPEntityObject.tol_plus,
                        frequency = POPUPEntityObject.frequency,
                        instrument_code = POPUPEntityObject.instrument_code,
                        remark = POPUPEntityObject.remark,
                        t_status = POPUPEntityObject.t_status,
                        active = POPUPEntityObject.active,
                        sr_no = POPUPEntityObject.sr_no,

                        id = 0,
                        location_Id = AppSessionState.location_Id,
                        comp_code = AppSessionState.comp_code,
                        add_by = AppSessionState.UserID,
                        editby = AppSessionState.UserID,
                    });
                }

            }
        }
        private void InsertSelectedItemForToolsGrid(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ENG_T004_B POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.SelectedItemDetails.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ENG_T004_B>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T004_B>().ToList()[0];
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
            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ToolsDetailEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                if (NewRow == true)
                {
                    ToolsDetailEntity.Add(new ENG_T004_B()
                    {
                        stn_no = POPUPEntityObject.stn_no,
                        ItemCode = POPUPEntityObject.ItemCode,
                        ItemName = POPUPEntityObject.ItemName,
                        MakeCode = POPUPEntityObject.MakeCode,
                        Make = POPUPEntityObject.Make,
                        make = POPUPEntityObject.make,
                        bin_no = POPUPEntityObject.bin_no,
                        section_type = POPUPEntityObject.section_type,
                        quantity = POPUPEntityObject.quantity,
                        life_days = POPUPEntityObject.life_days,
                        life_qty = POPUPEntityObject.life_qty,
                        t_status = POPUPEntityObject.t_status,
                        active = POPUPEntityObject.active,
                        type = POPUPEntityObject.type,
                        work_type = POPUPEntityObject.work_type,
                        Working = POPUPEntityObject.Working,
                        id = 0,
                        location_Id = AppSessionState.location_Id,
                        comp_code = AppSessionState.comp_code,
                        add_by = AppSessionState.UserID,
                        editby = AppSessionState.UserID,


                    });
                }

            }
        }
        private void InsertItemForDrillsGrid(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M022_P POPUPEntityObject = null;
                if (_FilterStringSearchDrills != "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Clear the Text: " + _FilterStringSearchDrills);
                    showMessageService.ShowMessage();
                }
                else
                {
                    try
                    {
                        if (InputValue.GetType() == typeof(string) && InputValue != null)
                        {
                            Request = InputValue.ToString();
                            if (Request.Length > 0)
                            {
                                try
                                { POPUPEntityObject = MC.ItemList.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                                catch (Exception ex)
                                {
                                }
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
                        var InputValueIfExists = DrillsDetailEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                        int IndexOfExistValue = DrillsDetailEntity.IndexOf(DrillsDetailEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());
                        //Insert
                        if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && DrillsDetailEntity.Count == dgSelectedIndexDrills)
                        {
                            DrillsDetailEntity.Add(new ENG_T004_B()
                            {
                                id = 0,
                                type = "Drills",
                                ItemCode = POPUPEntityObject.ItemCode,
                                ItemName = POPUPEntityObject.ItemName,
                                active = true,
                                location_Id = AppSessionState.location_Id,
                                comp_code = AppSessionState.comp_code,
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID,
                                posting_period = "1",
                                fin_year = "16-17",
                                t_status = "001"

                            });
                        }

                        else if (dgSelectedIndexDrills >= 0 && DrillsDetailEntity.Count > dgSelectedIndexDrills)
                        {
                            if (DrillsDetailEntity[dgSelectedIndexDrills].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                            {

                                DrillsDetailEntity[dgSelectedIndexDrills].ItemCode = POPUPEntityObject.ItemCode;
                                DrillsDetailEntity[dgSelectedIndexDrills].ItemName = POPUPEntityObject.ItemName;
                                DrillsDetailEntity[dgSelectedIndexDrills].location_Id = AppSessionState.location_Id;
                                DrillsDetailEntity[dgSelectedIndexDrills].comp_code = AppSessionState.comp_code;
                                DrillsDetailEntity[dgSelectedIndexDrills].add_by = AppSessionState.UserID;
                                DrillsDetailEntity[dgSelectedIndexDrills].editby = AppSessionState.UserID;
                                DrillsDetailEntity[dgSelectedIndexDrills].fin_year = "16-17";
                                DrillsDetailEntity[dgSelectedIndexDrills].posting_period = "1";
                                DrillsDetailEntity[dgSelectedIndexDrills].active = true;
                                DrillsDetailEntity[dgSelectedIndexDrills].type = "Drills";
                                DrillsDetailEntity[dgSelectedIndexDrills].t_status = "001";

                            }
                            else if (DrillsDetailEntity[dgSelectedIndexDrills].ItemCode != POPUPEntityObject.ItemCode)
                            {
                                DrillsDetailEntity[dgSelectedIndexDrills].ItemCode = "";
                                DrillsDetailEntity[dgSelectedIndexDrills].ItemName = "";
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

        private void InsertPartyForGrid(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
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
                                { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                                catch (Exception ex)
                                {
                                }
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
                        var InputValueIfExists = PartyEntity.Where(x => x.PartyId == POPUPEntityObject.PartyId).FirstOrDefault();
                        int IndexOfExistValue = PartyEntity.IndexOf(PartyEntity.Where(X => X.PartyId == POPUPEntityObject.PartyId).FirstOrDefault());
                        //Insert
                        if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && PartyEntity.Count == dgSelectedIndexParty)
                        {
                            PartyEntity.Add(new ENG_T004_D()
                            {
                                id = 0,
                                
                                PartyId = POPUPEntityObject.PartyId,
                                PartyNm = POPUPEntityObject.PartyNm,
                                active = true,
                                location_Id = AppSessionState.location_Id,
                                comp_code = AppSessionState.comp_code,
                                client = AppSessionState.client,
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID,
                                t_status = "001"

                            });
                        }

                        else if (dgSelectedIndexParty >= 0 && DrillsDetailEntity.Count > dgSelectedIndexParty)
                        {
                            if (DrillsDetailEntity[dgSelectedIndexDrills].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                            {

                            PartyEntity[dgSelectedIndexParty].PartyId = POPUPEntityObject.PartyId;
                            PartyEntity[dgSelectedIndexParty].PartyNm = POPUPEntityObject.PartyNm;
                            PartyEntity[dgSelectedIndexParty].location_Id = AppSessionState.location_Id;
                            PartyEntity[dgSelectedIndexParty].comp_code = AppSessionState.comp_code;
                            PartyEntity[dgSelectedIndexParty].client = AppSessionState.client;
                            PartyEntity[dgSelectedIndexParty].add_by = AppSessionState.UserID;
                            PartyEntity[dgSelectedIndexParty].editby = AppSessionState.UserID;
                            PartyEntity[dgSelectedIndexParty].active = true;
                            PartyEntity[dgSelectedIndexParty].t_status = "001";

                            }
                            else if (PartyEntity[dgSelectedIndexParty].PartyId != POPUPEntityObject.PartyId)
                            {
                            PartyEntity[dgSelectedIndexParty].PartyId = "";
                            PartyEntity[dgSelectedIndexParty].PartyNm = "";
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
        private void InsertSelectedItemForDrillsGrid(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ENG_T004_B POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.SelectedItemDetails.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ENG_T004_B>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T004_B>().ToList()[0];
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
            if (POPUPEntityObject != null)
            {

                if (NewRow == true)
                {
                    DrillsDetailEntity.Add(new ENG_T004_B()
                    {
                        stn_no = POPUPEntityObject.stn_no,
                        ItemCode = POPUPEntityObject.ItemCode,
                        ItemName = POPUPEntityObject.ItemName,
                        MakeCode = POPUPEntityObject.MakeCode,
                        Make = POPUPEntityObject.Make,
                        make = POPUPEntityObject.make,
                        section_type = POPUPEntityObject.section_type,
                        drill_spec = POPUPEntityObject.drill_spec,
                        quantity = POPUPEntityObject.quantity,
                        degree = POPUPEntityObject.degree,
                        drill_section = POPUPEntityObject.drill_section,
                        type = POPUPEntityObject.type,
                        active = POPUPEntityObject.active,
                        t_status = POPUPEntityObject.t_status,
                        bin_no = POPUPEntityObject.bin_no,
                        tol_plus = POPUPEntityObject.tol_plus,
                        tol_minus = POPUPEntityObject.tol_minus,
                        life_days = POPUPEntityObject.life_days,
                        life_qty = POPUPEntityObject.life_qty,
                        work_type = POPUPEntityObject.work_type,
                        Working = POPUPEntityObject.Working,

                        id = 0,
                        location_Id = AppSessionState.location_Id,
                        comp_code = AppSessionState.comp_code,
                        add_by = AppSessionState.UserID,
                        editby = AppSessionState.UserID,
                    });
                }

            }
        }
        private void InsertItemForSparesGrid(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M022_P POPUPEntityObject = null;
                if (_FilterStringSearchSpares != "")
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Please Clear the Text: " + _FilterStringSearchSpares);
                    showMessageService.ShowMessage();
                }
                else
                {
                    try
                    {
                        if (InputValue.GetType() == typeof(string) && InputValue != null)
                        {
                            Request = InputValue.ToString();
                            if (Request.Length > 0)
                            {
                                try
                                { POPUPEntityObject = MC.ItemList.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                                catch (Exception ex)
                                {
                                }
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
                        var InputValueIfExists = SparesDetailEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                        int IndexOfExistValue = SparesDetailEntity.IndexOf(SparesDetailEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());
                        //Insert
                        if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && SparesDetailEntity.Count == dgSelectedIndexSpares)
                        {
                            SparesDetailEntity.Add(new ENG_T004_B()
                            {
                                id = 0,
                                type = "Spares",
                                ItemCode = POPUPEntityObject.ItemCode,
                                ItemName = POPUPEntityObject.ItemName,
                                active = true,
                                location_Id = AppSessionState.location_Id,
                                comp_code = AppSessionState.comp_code,
                                add_by = AppSessionState.UserID,
                                editby = AppSessionState.UserID,
                                posting_period = "1",
                                fin_year = "16-17",
                                t_status = "001"

                            });
                        }

                        else if (dgSelectedIndexSpares >= 0 && SparesDetailEntity.Count > dgSelectedIndexSpares)
                        {
                            if (SparesDetailEntity[dgSelectedIndexSpares].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                            {

                                SparesDetailEntity[dgSelectedIndexSpares].ItemCode = POPUPEntityObject.ItemCode;
                                SparesDetailEntity[dgSelectedIndexSpares].ItemName = POPUPEntityObject.ItemName;
                                SparesDetailEntity[dgSelectedIndexSpares].location_Id = AppSessionState.location_Id;
                                SparesDetailEntity[dgSelectedIndexSpares].comp_code = AppSessionState.comp_code;
                                SparesDetailEntity[dgSelectedIndexSpares].add_by = AppSessionState.UserID;
                                SparesDetailEntity[dgSelectedIndexSpares].editby = AppSessionState.UserID;
                                SparesDetailEntity[dgSelectedIndexSpares].fin_year = "16-17";
                                SparesDetailEntity[dgSelectedIndexSpares].posting_period = "1";
                                SparesDetailEntity[dgSelectedIndexSpares].active = true;
                                SparesDetailEntity[dgSelectedIndexSpares].type = "Spares";
                                SparesDetailEntity[dgSelectedIndexSpares].t_status = "001";
                            }
                            else if (SparesDetailEntity[dgSelectedIndexSpares].ItemCode != POPUPEntityObject.ItemCode)
                            {
                                SparesDetailEntity[dgSelectedIndexSpares].ItemCode = "";
                                SparesDetailEntity[dgSelectedIndexSpares].ItemName = "";
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
        private void InsertSelectedItemForSparesGrid(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ENG_T004_B POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.SelectedItemDetails.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ENG_T004_B>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T004_B>().ToList()[0];
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
            if (POPUPEntityObject != null)
            {
                if (NewRow == true)
                {
                    SparesDetailEntity.Add(new ENG_T004_B()
                    {
                        stn_no = POPUPEntityObject.stn_no,
                        ItemCode = POPUPEntityObject.ItemCode,
                        ItemName = POPUPEntityObject.ItemName,
                        MakeCode = POPUPEntityObject.MakeCode,
                        Make = POPUPEntityObject.Make,
                        make = POPUPEntityObject.make,
                        section_type = POPUPEntityObject.section_type,
                        quantity = POPUPEntityObject.quantity,
                        life_days = POPUPEntityObject.life_days,
                        life_qty = POPUPEntityObject.life_qty,
                        t_status = POPUPEntityObject.t_status,
                        type = POPUPEntityObject.type,
                        active = POPUPEntityObject.active,
                        bin_no = POPUPEntityObject.bin_no,
                        work_type = POPUPEntityObject.work_type,
                        Working = POPUPEntityObject.Working,

                        id = 0,
                        location_Id = AppSessionState.location_Id,
                        comp_code = AppSessionState.comp_code,
                        add_by = AppSessionState.UserID,
                        editby = AppSessionState.UserID,
                    });
                }
            }
        }
        private void InsertAlternateItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M022_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ItemList.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
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
                var InputValueIfExists = ControlParaDetailEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                int IndexOfExistValue = ControlParaDetailEntity.IndexOf(ControlParaDetailEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());
                //Insert
                if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ControlParaDetailEntity.Count == dgSelectedIndexTools)
                {
                    ControlParaDetailEntity.Add(new ENG_T004_B()
                    {
                        id = 0,
                        alternate_item = POPUPEntityObject.ItemCode,
                        alternate_itemName = POPUPEntityObject.ItemName,

                    });
                }
                //update
                else if (dgSelectedIndexTools >= 0 && ControlParaDetailEntity.Count > dgSelectedIndexTools)
                {
                    if (ControlParaDetailEntity[dgSelectedIndexTools].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                    {
                        ControlParaDetailEntity[dgSelectedIndexTools].alternate_item = POPUPEntityObject.ItemCode;
                        ControlParaDetailEntity[dgSelectedIndexTools].alternate_itemName = POPUPEntityObject.ItemName;


                    }
                    else if (ControlParaDetailEntity[dgSelectedIndexTools].ItemCode != POPUPEntityObject.ItemCode)
                    {
                        ControlParaDetailEntity[dgSelectedIndexTools].alternate_item = "";
                        ControlParaDetailEntity[dgSelectedIndexTools].alternate_itemName = "";
                    }
                }

            }
        }
        private void InsertSpecificationPara(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                //AppSessionState.StringListValue = StringListUom;
                string Request = "";
                ENG_T003 POPUPEntityObject = null;
                dgSelectedIndexParaDetails = dgSelectedIndexParaDetails;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.SpecificationParaList.Where(x => x.spec_para_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ENG_T003>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T003>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ParaDetailEntity.Where(X => X.spec_para_code == POPUPEntityObject.spec_para_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ParaDetailEntity.IndexOf(ParaDetailEntity.Where(X => X.spec_para_code == POPUPEntityObject.spec_para_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexParaDetails >= 0 && ParaDetailEntity.Count > dgSelectedIndexParaDetails) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ParaDetailEntity[dgSelectedIndexParaDetails].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ParaDetailEntity[dgSelectedIndexParaDetails].spec_para_code = POPUPEntityObject.spec_para_code;
                            ParaDetailEntity[dgSelectedIndexParaDetails].parameter = POPUPEntityObject.parameter;
                        }
                        else if (ParaDetailEntity[dgSelectedIndexParaDetails].spec_para_code != POPUPEntityObject.spec_para_code)
                        {
                            ParaDetailEntity[dgSelectedIndexParaDetails].spec_para_code = POPUPEntityObject.spec_para_code;
                            ParaDetailEntity[dgSelectedIndexParaDetails].parameter = POPUPEntityObject.parameter;
                        }
                    }
                }
                #region Clear Empty Row
                ENG_T004_A newObj = new ENG_T004_A();
                for (int i = ParaDetailEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ParaDetailEntity[i].ComparePropertiesTo(newObj);
                    if (ParaDetailEntity[i].ComparePropertiesTo(newObj) == true && ParaDetailEntity.Count > 1)
                    {
                        ParaDetailEntity.RemoveAt(i);
                        if (ParaDetailEntity.Count == 0)
                        {
                            ParaDetailEntity.Add(newObj);
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
        private void InsertInstrument(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                //AppSessionState.StringListValue = StringListUom;
                string Request = "";
                ENG_T003 POPUPEntityObject = null;
                dgSelectedIndexParaDetails = dgSelectedIndexParaDetails;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.InstrumentList.Where(x => x.spec_para_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ENG_T003>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T003>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ParaDetailEntity.Where(X => X.instrument_code == POPUPEntityObject.spec_para_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ParaDetailEntity.IndexOf(ParaDetailEntity.Where(X => X.instrument_code == POPUPEntityObject.spec_para_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexParaDetails >= 0 && ParaDetailEntity.Count > dgSelectedIndexParaDetails) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ParaDetailEntity[dgSelectedIndexParaDetails].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ParaDetailEntity[dgSelectedIndexParaDetails].instrument_code = POPUPEntityObject.spec_para_code;
                            ParaDetailEntity[dgSelectedIndexParaDetails].instrument = POPUPEntityObject.parameter;
                        }
                        else if (ParaDetailEntity[dgSelectedIndexParaDetails].instrument_code != POPUPEntityObject.spec_para_code)
                        {
                            ParaDetailEntity[dgSelectedIndexParaDetails].instrument_code = POPUPEntityObject.spec_para_code;
                            ParaDetailEntity[dgSelectedIndexParaDetails].instrument = POPUPEntityObject.parameter;
                        }
                    }
                }
                #region Clear Empty Row
                ENG_T004_A newObj = new ENG_T004_A();
                for (int i = ParaDetailEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ParaDetailEntity[i].ComparePropertiesTo(newObj);
                    if (ParaDetailEntity[i].ComparePropertiesTo(newObj) == true && ParaDetailEntity.Count > 1)
                    {
                        ParaDetailEntity.RemoveAt(i);
                        if (ParaDetailEntity.Count == 0)
                        {
                            ParaDetailEntity.Add(newObj);
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

        private void InsertWorking(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                //AppSessionState.StringListValue = StringListUom;
                string Request = "";
                ENG_T003 POPUPEntityObject = null;
                dgSelectedIndexTools = dgSelectedIndexTools;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WorkingList.Where(x => x.spec_para_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ENG_T003>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T003>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ToolsDetailEntity.Where(X => X.work_type == POPUPEntityObject.spec_para_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ToolsDetailEntity.IndexOf(ToolsDetailEntity.Where(X => X.work_type == POPUPEntityObject.spec_para_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexTools >= 0 && ParaDetailEntity.Count > dgSelectedIndexTools) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ToolsDetailEntity[dgSelectedIndexTools].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ToolsDetailEntity[dgSelectedIndexTools].work_type = POPUPEntityObject.spec_para_code;
                            ToolsDetailEntity[dgSelectedIndexTools].Working = POPUPEntityObject.parameter;
                        }
                        else if (ToolsDetailEntity[dgSelectedIndexTools].work_type != POPUPEntityObject.spec_para_code)
                        {
                            ToolsDetailEntity[dgSelectedIndexTools].work_type = POPUPEntityObject.spec_para_code;
                            ToolsDetailEntity[dgSelectedIndexTools].Working = POPUPEntityObject.parameter;
                        }
                    }
                }
                #region Clear Empty Row
                ENG_T004_B newObj = new ENG_T004_B();
                for (int i = ToolsDetailEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = ToolsDetailEntity[i].ComparePropertiesTo(newObj);
                    if (ToolsDetailEntity[i].ComparePropertiesTo(newObj) == true && ToolsDetailEntity.Count > 1)
                    {
                        ToolsDetailEntity.RemoveAt(i);
                        if (ToolsDetailEntity.Count == 0)
                        {
                            ToolsDetailEntity.Add(newObj);
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

        private void InsertDrillsWorking(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                //AppSessionState.StringListValue = StringListUom;
                string Request = "";
                ENG_T003 POPUPEntityObject = null;
                dgSelectedIndexDrills = dgSelectedIndexDrills;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WorkingList.Where(x => x.spec_para_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ENG_T003>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T003>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = DrillsDetailEntity.Where(X => X.work_type == POPUPEntityObject.spec_para_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = DrillsDetailEntity.IndexOf(DrillsDetailEntity.Where(X => X.work_type == POPUPEntityObject.spec_para_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexDrills >= 0 && DrillsDetailEntity.Count > dgSelectedIndexDrills) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (DrillsDetailEntity[dgSelectedIndexDrills].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            DrillsDetailEntity[dgSelectedIndexDrills].work_type = POPUPEntityObject.spec_para_code;
                            DrillsDetailEntity[dgSelectedIndexDrills].Working = POPUPEntityObject.parameter;
                        }
                        else if (DrillsDetailEntity[dgSelectedIndexDrills].work_type != POPUPEntityObject.spec_para_code)
                        {
                            DrillsDetailEntity[dgSelectedIndexDrills].work_type = POPUPEntityObject.spec_para_code;
                            DrillsDetailEntity[dgSelectedIndexDrills].Working = POPUPEntityObject.parameter;
                        }
                    }
                }
                #region Clear Empty Row
                ENG_T004_B newObj = new ENG_T004_B();
                for (int i = DrillsDetailEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = DrillsDetailEntity[i].ComparePropertiesTo(newObj);
                    if (DrillsDetailEntity[i].ComparePropertiesTo(newObj) == true && DrillsDetailEntity.Count > 1)
                    {
                        DrillsDetailEntity.RemoveAt(i);
                        if (DrillsDetailEntity.Count == 0)
                        {
                            DrillsDetailEntity.Add(newObj);
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

        private void InsertSparesWorking(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                //AppSessionState.StringListValue = StringListUom;
                string Request = "";
                ENG_T003 POPUPEntityObject = null;
                dgSelectedIndexSpares = dgSelectedIndexSpares;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WorkingList.Where(x => x.spec_para_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ENG_T003>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T003>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = SparesDetailEntity.Where(X => X.work_type == POPUPEntityObject.spec_para_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = SparesDetailEntity.IndexOf(SparesDetailEntity.Where(X => X.work_type == POPUPEntityObject.spec_para_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexSpares >= 0 && SparesDetailEntity.Count > dgSelectedIndexSpares) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (SparesDetailEntity[dgSelectedIndexSpares].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            SparesDetailEntity[dgSelectedIndexSpares].work_type = POPUPEntityObject.spec_para_code;
                            SparesDetailEntity[dgSelectedIndexSpares].Working = POPUPEntityObject.parameter;
                        }
                        else if (SparesDetailEntity[dgSelectedIndexSpares].work_type != POPUPEntityObject.spec_para_code)
                        {
                            SparesDetailEntity[dgSelectedIndexSpares].work_type = POPUPEntityObject.spec_para_code;
                            SparesDetailEntity[dgSelectedIndexSpares].Working = POPUPEntityObject.parameter;
                        }
                    }
                }
                #region Clear Empty Row
                ENG_T004_B newObj = new ENG_T004_B();
                for (int i = SparesDetailEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = SparesDetailEntity[i].ComparePropertiesTo(newObj);
                    if (SparesDetailEntity[i].ComparePropertiesTo(newObj) == true && SparesDetailEntity.Count > 1)
                    {
                        SparesDetailEntity.RemoveAt(i);
                        if (SparesDetailEntity.Count == 0)
                        {
                            SparesDetailEntity.Add(newObj);
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
        private void InsertselectedParaDocNo(object InputValue)
        {
            string Request = "";
            ENG_T004_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BackflipList.Where(x => x.ink.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T004_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.doc_no4 = POPUPEntityObject.doc_no;
            }
        }
        private void InsertselectedToolDocNo(object InputValue)
        {
            string Request = "";
            ENG_T004_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BackflipList.Where(x => x.ink.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T004_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.doc_no1 = POPUPEntityObject.doc_no;
            }
        }
        private void InsertselectedDrillDocNo(object InputValue)
        {
            string Request = "";
            ENG_T004_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BackflipList.Where(x => x.ink.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T004_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.doc_no2 = POPUPEntityObject.doc_no;
            }
        }
        private void InsertselectedSpareDocNo(object InputValue)
        {
            string Request = "";
            ENG_T004_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.BackflipList.Where(x => x.ink.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T004_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.doc_no3 = POPUPEntityObject.doc_no;
            }
        }




        private bool Validation()
        {
            if (MasterEntity.modelno == null || MasterEntity.modelno == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Model..");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.ItemCode == null || MasterEntity.ItemCode == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Product..");
                showMessageService.ShowMessage();
                return false;
            }
            //if (MasterEntity.machinecode == null || MasterEntity.machinecode == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Enter Machine Code");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            if (MasterEntity.location_Id == null || MasterEntity.location_Id == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Plant..");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }

        // make
        private void InsertToolsMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    var InputValueIfExists = ToolsDetailEntity.Where(X => X.make == POPUPEntityObject.parametervalue).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ToolsDetailEntity.IndexOf(ToolsDetailEntity.Where(X => X.make == POPUPEntityObject.parametervalue).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexTools >= 0 && ToolsDetailEntity.Count > dgSelectedIndexTools) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ToolsDetailEntity[dgSelectedIndexTools].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ToolsDetailEntity[dgSelectedIndexTools].make = POPUPEntityObject.parametervalue;
                        }
                        else if (ToolsDetailEntity[dgSelectedIndexTools].make != POPUPEntityObject.parametervalue)
                        {
                            ToolsDetailEntity[dgSelectedIndexTools].make = POPUPEntityObject.parametervalue;
                        }
                    }
                    #region Clear Empty Row
                    ENG_T004_B newObj = new ENG_T004_B();
                    for (int i = ToolsDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = ToolsDetailEntity[i].ComparePropertiesTo(newObj);
                        if (ToolsDetailEntity[i].ComparePropertiesTo(newObj) == true && ToolsDetailEntity.Count > 1)
                        {
                            ToolsDetailEntity.RemoveAt(i);
                            if (ToolsDetailEntity.Count == 0)
                            {
                                ToolsDetailEntity.Add(newObj);
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
        private void InsertDrillsMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    var InputValueIfExists = DrillsDetailEntity.Where(X => X.make == POPUPEntityObject.parametervalue).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = DrillsDetailEntity.IndexOf(DrillsDetailEntity.Where(X => X.make == POPUPEntityObject.parametervalue).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexDrills >= 0 && DrillsDetailEntity.Count > dgSelectedIndexDrills) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (DrillsDetailEntity[dgSelectedIndexDrills].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            DrillsDetailEntity[dgSelectedIndexDrills].make = POPUPEntityObject.parametervalue;
                        }
                        else if (DrillsDetailEntity[dgSelectedIndexDrills].make != POPUPEntityObject.parametervalue)
                        {
                            DrillsDetailEntity[dgSelectedIndexDrills].make = POPUPEntityObject.parametervalue;
                        }
                    }
                    #region Clear Empty Row
                    ENG_T004_B newObj = new ENG_T004_B();
                    for (int i = DrillsDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = DrillsDetailEntity[i].ComparePropertiesTo(newObj);
                        if (DrillsDetailEntity[i].ComparePropertiesTo(newObj) == true && DrillsDetailEntity.Count > 1)
                        {
                            DrillsDetailEntity.RemoveAt(i);
                            if (DrillsDetailEntity.Count == 0)
                            {
                                DrillsDetailEntity.Add(newObj);
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
        private void InsertSparesMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    var InputValueIfExists = SparesDetailEntity.Where(X => X.make == POPUPEntityObject.parametervalue).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = SparesDetailEntity.IndexOf(SparesDetailEntity.Where(X => X.make == POPUPEntityObject.parametervalue).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexSpares >= 0 && SparesDetailEntity.Count > dgSelectedIndexSpares) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (SparesDetailEntity[dgSelectedIndexSpares].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            SparesDetailEntity[dgSelectedIndexSpares].make = POPUPEntityObject.parametervalue;
                        }
                        else if (SparesDetailEntity[dgSelectedIndexSpares].make != POPUPEntityObject.parametervalue)
                        {
                            SparesDetailEntity[dgSelectedIndexSpares].make = POPUPEntityObject.parametervalue;
                        }
                    }
                    #region Clear Empty Row
                    ENG_T004_B newObj = new ENG_T004_B();
                    for (int i = SparesDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = SparesDetailEntity[i].ComparePropertiesTo(newObj);
                        if (SparesDetailEntity[i].ComparePropertiesTo(newObj) == true && SparesDetailEntity.Count > 1)
                        {
                            SparesDetailEntity.RemoveAt(i);
                            if (SparesDetailEntity.Count == 0)
                            {
                                SparesDetailEntity.Add(newObj);
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
        private void InsertBallMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    var InputValueIfExists = BallDetailEntity.Where(X => X.make == POPUPEntityObject.parametervalue).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = BallDetailEntity.IndexOf(BallDetailEntity.Where(X => X.make == POPUPEntityObject.parametervalue).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexBallDetails >= 0 && BallDetailEntity.Count > dgSelectedIndexBallDetails) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (BallDetailEntity[dgSelectedIndexBallDetails].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            BallDetailEntity[dgSelectedIndexBallDetails].make = POPUPEntityObject.parametervalue;
                        }
                        else if (BallDetailEntity[dgSelectedIndexBallDetails].make != POPUPEntityObject.parametervalue)
                        {
                            BallDetailEntity[dgSelectedIndexBallDetails].make = POPUPEntityObject.parametervalue;
                        }
                    }
                    #region Clear Empty Row
                    ENG_T004_B newObj = new ENG_T004_B();
                    for (int i = BallDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = BallDetailEntity[i].ComparePropertiesTo(newObj);
                        if (BallDetailEntity[i].ComparePropertiesTo(newObj) == true && BallDetailEntity.Count > 1)
                        {
                            BallDetailEntity.RemoveAt(i);
                            if (BallDetailEntity.Count == 0)
                            {
                                BallDetailEntity.Add(newObj);
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
        private void InsertWireMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    var InputValueIfExists = WireDetailEntity.Where(X => X.make == POPUPEntityObject.parametervalue).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = WireDetailEntity.IndexOf(WireDetailEntity.Where(X => X.make == POPUPEntityObject.parametervalue).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexWireDetails >= 0 && WireDetailEntity.Count > dgSelectedIndexWireDetails) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (WireDetailEntity[dgSelectedIndexWireDetails].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            WireDetailEntity[dgSelectedIndexWireDetails].make = POPUPEntityObject.parametervalue;
                        }
                        else if (WireDetailEntity[dgSelectedIndexWireDetails].make != POPUPEntityObject.parametervalue)
                        {
                            WireDetailEntity[dgSelectedIndexWireDetails].make = POPUPEntityObject.parametervalue;
                        }
                    }
                    #region Clear Empty Row
                    ENG_T004_B newObj = new ENG_T004_B();
                    for (int i = WireDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = WireDetailEntity[i].ComparePropertiesTo(newObj);
                        if (WireDetailEntity[i].ComparePropertiesTo(newObj) == true && WireDetailEntity.Count > 1)
                        {
                            WireDetailEntity.RemoveAt(i);
                            if (WireDetailEntity.Count == 0)
                            {
                                WireDetailEntity.Add(newObj);
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
        private void InsertInkMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    var InputValueIfExists = InkDetailEntity.Where(X => X.make == POPUPEntityObject.parametervalue).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = InkDetailEntity.IndexOf(InkDetailEntity.Where(X => X.make == POPUPEntityObject.parametervalue).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexInkDetails >= 0 && InkDetailEntity.Count > dgSelectedIndexInkDetails) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (InkDetailEntity[dgSelectedIndexInkDetails].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            InkDetailEntity[dgSelectedIndexInkDetails].make = POPUPEntityObject.parametervalue;
                        }
                        else if (InkDetailEntity[dgSelectedIndexInkDetails].make != POPUPEntityObject.parametervalue)
                        {
                            InkDetailEntity[dgSelectedIndexInkDetails].make = POPUPEntityObject.parametervalue;
                        }
                    }
                    #region Clear Empty Row
                    ENG_T004_B newObj = new ENG_T004_B();
                    for (int i = InkDetailEntity.Count - 1; i >= 0; i--)
                    {
                        bool xx = InkDetailEntity[i].ComparePropertiesTo(newObj);
                        if (InkDetailEntity[i].ComparePropertiesTo(newObj) == true && InkDetailEntity.Count > 1)
                        {
                            InkDetailEntity.RemoveAt(i);
                            if (InkDetailEntity.Count == 0)
                            {
                                InkDetailEntity.Add(newObj);
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
        
        private void ClearFilterString()//For searchbox set the black value to the filterstring
        {
            FilterStringSearchPara = "";
            _FilterStringSearchPara = "";
            FilterStringSearchTools = "";
            _FilterStringSearchTools = "";
            FilterStringSearchDrills = "";
            _FilterStringSearchDrills = "";
            FilterStringSearchSpares = "";
            _FilterStringSearchSpares = "";
        }

        private void LoadTDSView()
        {
            try
            {
                if ((MasterEntity.lctn_id_filter != "" || MasterEntity.lctn_id_filter != null) ||
                    (MasterEntity.modelno != "" || MasterEntity.modelno != null) ||
                     (MasterEntity.ild_filter != "" || MasterEntity.ild_filter != null))
                {
                    string Request = "LoadTDSFilterView" + "!@" + MasterEntity.lctn_id_filter + "!@" + MasterEntity.model_id_filter + "!@" + MasterEntity.ild_id_filter + "!@" + MasterEntity.cycle_type_filter + "!@" + MasterEntity.Cust_id_filter; //+ "!@" + MasterEntity.ink_id_filter
                    MCTemp1 = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ENG_T004>(MCTemp1, Request, "TDS", "Production", "", 0, "");

                    isNewRecord = false;

                    SelectedList = MCTemp1.BackflipList.ToList();

                    BackFlipCollection = CollectionViewSource.GetDefaultView(_SelectedList);
                    BackFlipCollection.Filter = new Predicate<object>(Filter_FlipGrid);
                    StringListBackflipData = MC.BackflipList.Select(x => x.doc_no).ToList();
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Following Fields Are Mandatory \n1.Location \n2.Model\n3.Ink \n4.Ild \nPlease select all them and Try Again... ");
                    showMessageService.ShowMessage();
                }
            }
            catch (Exception ex) { }
        }

        private void PrintExportReport()
        {
            CursorControl.SetBusyState();
            try
            {
                string ReportName = "";

                if (ReportOption == "Mesurement Data Sheet" || ReportOption == "Tooling Data Sheet" || ReportOption == "Data Sheet")
                {
                    string Request = "";
                    if (ReportOption == "Mesurement Data Sheet")
                    {
                        ReportName = "TDS_Mesurement.rdlc";
                    }
                    else if (ReportOption == "Tooling Data Sheet")
                    {
                        ReportName = "TDS_TDS.rdlc";
                    }
                    else if (ReportOption == "Data Sheet")
                    {
                        ReportName = "TDS_DS.rdlc";
                    }
                    Request = "LoadDocumentByDocumentNumber" + "!@" + MasterEntity.doc_no + "!@" + AppSessionState.location_Id;
                    //MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ENG_T004>(MCTemp, "LOG_T001_A_Data", "DeliveryNote", "SCM", "LoadAll", 0, Request);
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ENG_T004>(MCTemp, Request, "TDS", "Production", "", 0, "LoadDocumentByDocumentNumber");


                    object[] objDataSource = new object[7];
                    string[] objDataSourceName = new string[7];


                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[0] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[1] = Result;

                    objDataSource[2] = MCTemp.MasterEntity;
                    objDataSource[3] = MCTemp.ParaDetailEntity;
                    objDataSource[4] = MCTemp.ControlParaDetailEntity;
                    objDataSource[5] = MCTemp.ReferencesList;
                    objDataSource[6] = MCTemp.PartyList;

                    objDataSourceName[0] = "dsCompany";
                    objDataSourceName[1] = "dsLocation";
                    objDataSourceName[2] = "dsTDS_ENG_T004";
                    objDataSourceName[3] = "dsTDS_ENG_T004_A";
                    objDataSourceName[4] = "dsTDS_ENG_T004_B";
                    objDataSourceName[5] = "dsTDS_ENG_T004_C";
                    objDataSourceName[6] = "dsTDS_ENG_T004_D";

                    ReportManager ReportManager = new ReportManager();

                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\" + ReportName, ReportName);

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

        protected override void OnCreateAction(InquiryActionResult<ENG_T004> result)
        {
            isNewRecord = true;
            MasterEntity = new ENG_T004();
            ParaDetailEntity = new ObservableCollection<ENG_T004_A>();
            ControlParaDetailEntity = new ObservableCollection<ENG_T004_B>();
            ToolsDetailEntity = new ObservableCollection<ENG_T004_B>();
            DrillsDetailEntity = new ObservableCollection<ENG_T004_B>();
            SparesDetailEntity = new ObservableCollection<ENG_T004_B>();
            BallDetailEntity = new ObservableCollection<ENG_T004_B>();
            WireDetailEntity = new ObservableCollection<ENG_T004_B>();
            InkDetailEntity = new ObservableCollection<ENG_T004_B>();
            ReferencesEntity = new ObservableCollection<ENG_T004_C>();
            PartyEntity = new ObservableCollection<ENG_T004_D>();
            DefaultValues();
            ClearFilterString();
            EnableCheckBox = false;
        }
        protected override void OnDiscardAction(InquiryActionResult<ENG_T004> result)
        {

        }
        protected override void OnFevoriteAction(InquiryActionResult<ENG_T004> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ENG_T004> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ENG_T004> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ENG_T004> result)
        {
            try
            {
                if (MasterEntity.doc_no != null && MasterEntity.doc_no != " ")
                {
                    string Request = "Rpt_TDS" + "!@" + MasterEntity.doc_no;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ENG_T004>(MCTemp, Request, "TDS", "Production", "", 0, "Rpt_TDS");


                    object[] objDataSource = new object[11];
                    string[] objDataSourceName = new string[11];

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[0] = Result;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    objDataSource[2] = MCTemp.MasterEntity;
                    objDataSource[3] = MCTemp.RptWire_Ball_details;
                    objDataSource[4] = MCTemp.RptToolsDetails;
                    objDataSource[5] = MCTemp.RptDrillsDetails;
                    objDataSource[6] = MCTemp.RptSparesDetails;
                    objDataSource[7] = MCTemp.MediaList;


                    objDataSourceName[0] = "dsLocation";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsRptMasterEntity";
                    objDataSourceName[3] = "dsRptWire_Ball_details";
                    objDataSourceName[4] = "dsRptToolsDetails";
                    objDataSourceName[5] = "dsRptDrillsDetails";
                    objDataSourceName[6] = "dsRptSparesDetails";
                    objDataSourceName[7] = "dsMedia";


                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Production\\Rpt_TDS.rdlc", "TDSReport");

                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Select TDS No.....", this.Title);
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
        protected override void OnRemoveAction(InquiryActionResult<ENG_T004> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<ENG_T004> result)
        {
            try
            {
                if (Validation() == true)
                {
                    if (MasterEntity.revision == true)
                    {
                        MasterEntity.revision_no = (MasterEntity.revision_no + 1);
                        MasterEntity.ref_doc_no = MasterEntity.doc_no;
                        MasterEntity.revision_date = DateTime.Now;
                        //isNewRecord = true;
                    }
                    MasterEntity.XmlDataDocument_ENG_T004_A = obj.ObjectToXML(ParaDetailEntity);
                    var data = ToolsDetailEntity.Concat(DrillsDetailEntity).Concat(SparesDetailEntity).Concat(BallDetailEntity).Concat(WireDetailEntity).Concat(InkDetailEntity);
                    MasterEntity.XmlDataDocument_ENG_T004_B = obj.ObjectToXML(data.ToList());
                    MasterEntity.XmlDataDocument_ENG_T004_C = obj.ObjectToXML(ReferencesEntity);
                    MasterEntity.XmlDataDocument_ENG_T004_D = obj.ObjectToXML(PartyEntity);

                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ENG_T004>(MasterEntity, "TDS", "Production");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ENG_T004>(MasterEntity, "TDS", "Production");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    BackFlipCollection.Refresh();
                    isNewRecord = false;
                    if ((MasterEntity.doc_no != null || MasterEntity.doc_no != "") && isNewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();
                    }
                    EnableCheckBox = true;
                    ClearFilterString();
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
            try
            {

                MasterEntity.ts_code = ts_code_vm;
                if (MasterEntity.XmlDataDocument_FlipGrid != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.BackflipList = (List<ENG_T004_P>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.BackflipList);
                    FlipGridData.Add(MC.BackflipList[0]);
                    BackFlipCollection.Refresh();
                }
                if (MasterEntity.XmlDataDocument_ENG_T004_A != null)
                {
                    ParaDetailEntity.Clear();
                    ParaDetailEntity = (ObservableCollection<ENG_T004_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ENG_T004_A, MC.ParaDetailEntity);
                }
                else
                {
                    MC.ParaDetailEntity = new ObservableCollection<ENG_T004_A>();
                }
                if (MasterEntity.XmlDataDocument_ENG_T004_B != null)
                {
                    ControlParaDetailEntity.Clear();
                    ControlParaDetailEntity = (ObservableCollection<ENG_T004_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ENG_T004_B, MC.ControlParaDetailEntity);

                    ToolsDetailEntity.Clear();
                    DrillsDetailEntity.Clear();
                    SparesDetailEntity.Clear();
                    WireDetailEntity.Clear();
                    BallDetailEntity.Clear();
                    InkDetailEntity.Clear();
                    foreach (var data in ControlParaDetailEntity)
                    {
                        if (data.type == "Tools")
                        {
                            ToolsDetailEntity.Add(data);
                        }
                        else if (data.type == "Drills")
                        {
                            DrillsDetailEntity.Add(data);
                        }
                        else if (data.type == "Spares")
                        {
                            SparesDetailEntity.Add(data);
                        }
                        else if (data.type == "Wire")
                        {
                            WireDetailEntity.Add(data);
                        }
                        else if (data.type == "Ball")
                        {
                            BallDetailEntity.Add(data);
                        }
                        else if (data.type == "Ink")
                        {
                            InkDetailEntity.Add(data);
                        }
                    }
                }
                else
                {
                    MC.ControlParaDetailEntity = new ObservableCollection<ENG_T004_B>();
                    ToolsDetailEntity = new ObservableCollection<ENG_T004_B>();
                    DrillsDetailEntity = new ObservableCollection<ENG_T004_B>();
                    SparesDetailEntity = new ObservableCollection<ENG_T004_B>();
                    InkDetailEntity = new ObservableCollection<ENG_T004_B>();
                }
                if (MasterEntity.XmlDataDocument_ENG_T004_C != null)
                {
                    ReferencesEntity.Clear();
                    ReferencesEntity = (ObservableCollection<ENG_T004_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ENG_T004_C, MC.ReferencesList);
                }
                else
                {
                    MC.ReferencesList = new ObservableCollection<ENG_T004_C>();
                }
                if (MasterEntity.XmlDataDocument_ENG_T004_D != null)
                {
                    PartyEntity.Clear();
                    PartyEntity = (ObservableCollection<ENG_T004_D>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ENG_T004_D, MC.PartyList);
                }
                else
                {
                    MC.PartyList = new ObservableCollection<ENG_T004_D>();
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
            //if (!string.IsNullOrEmpty(MasterEntity.ItemCode.ToString()))
            //{
            //    //this.IsDocumentViewerShow = !IsDocumentViewerShow;
            //    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.ItemCode.ToString().Replace("/", "--"), DocumentList = MCTemp.AttachmentList, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            //}

            if (!string.IsNullOrEmpty(MasterEntity.doc_no))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MCTemp.Attachment, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<ENG_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ENG_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ENG_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ENG_T004> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ENG_T004> result)
        {
            throw new NotImplementedException();
        }

        #region Filter for View 
        private void FilterByPlant(object InputValue)
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
                            { POPUPEntityObject = plantList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M003>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.lctn_id_filter = POPUPEntityObject.location_Id;
                    MasterEntity.lctn_filter = POPUPEntityObject.LoctnNm;
                }
                var msg = new NotificationMessage("ENG_T004_VM");
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
            //this code was written for filtering the TDS view data at client Side itself
            //ie. in VM But As per client requirment server trip is given for filtering

            //try
            //{
            //    string Request = "";
            //    ADM_M003 POPUPEntityObject = null;
            //    #region Command Parameter Read Section
            //    try
            //    {
            //        if (InputValue.GetType() == typeof(string) && InputValue != null)
            //        {
            //            Request = InputValue.ToString();
            //            if (Request.Length > 0)
            //            {
            //                try
            //                { POPUPEntityObject = plantList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
            //                catch (Exception ex) { }
            //            }
            //        }
            //        else if (InputValue != null)
            //        {
            //            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
            //        }
            //    }
            //    catch (Exception ex) { }

            //    #endregion

            //    if (POPUPEntityObject != null)
            //    {

            //        MasterEntity.lctn_id_filter = POPUPEntityObject.location_Id;
            //        MasterEntity.lctn_filter = POPUPEntityObject.LoctnNm;

            //        var LocWiseView = (from o in MC.BackflipList
            //                           where o.location_Id == MasterEntity.lctn_id_filter
            //                           select o).ToList();


            //        BackFlipCollection = CollectionViewSource.GetDefaultView(LocWiseView.ToList());
            //        BackFlipCollection.Filter = new Predicate<object>(Filter_FlipGrid);
            //        BackFlipCollection.Refresh();

            //    }
            //    else
            //    {
            //        if (MC.BackflipList != null)
            //        {
            //            FlipGridData = MC.BackflipList.ToList();
            //            BackFlipCollection = CollectionViewSource.GetDefaultView(FlipGridData);
            //            BackFlipCollection.Filter = new Predicate<object>(Filter_FlipGrid);
            //            StringListBackflipData = MC.BackflipList.Select(x => x.doc_no).ToList();
            //        }
            //    }
            //    var msg = new NotificationMessage("ENG_T004_VM");
            //    Messenger.Default.Send<NotificationMessage>(msg);
            //}

            //catch (Exception ex)
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format(ex.Message, this.Title);
            //    showMessageService.ShowMessage();
            //}
        }
        private void FilterByBallDia(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M001_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.BallDiaList.Where(x => x.ball_dia_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M001_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.ball_dia_filter = POPUPEntityObject.ball_dia_id;
                }
                var msg = new NotificationMessage("ENG_T004_VM");
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
        private void FilterByInk(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M006_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Ink.Where(x => x.ink.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M006_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.ink_filter = POPUPEntityObject.ink;
                    MasterEntity.ink_id_filter = POPUPEntityObject.ink_id;
                }
                var msg = new NotificationMessage("ENG_T004_VM");
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
        private void FilterByILD(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M007_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Ref_ILD.Where(x => x.ild.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M007_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.ild_id_filter = POPUPEntityObject.ild_id;
                    MasterEntity.ild_filter = POPUPEntityObject.ild;

                }
                var msg = new NotificationMessage("ENG_T004_VM");
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
        private void FilterByModelNo(object InputValue)
        {
            try
            {
                string Request = "";
                ZADM_M009_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.ModelList.Where(x => x.modelno.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M009_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.modelno_filter = POPUPEntityObject.modelno;
                    MasterEntity.model_id_filter = POPUPEntityObject.model_id;
                }
                var msg = new NotificationMessage("ENG_T004_VM");
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
        private void FilterByCustomer(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.CustomerList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.Cust_id_filter = POPUPEntityObject.PartyId;
                    MasterEntity.Cust_nm_filter = POPUPEntityObject.PartyNm;
                }
                var msg = new NotificationMessage("ENG_T004_VM");
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
        private void InsertCustomer(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.CustomerList.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion

                if (POPUPEntityObject != null)
                {
                    MasterEntity.customer_id = POPUPEntityObject.PartyId;
                }
                var msg = new NotificationMessage("ENG_T004_VM");
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
        private void InsertILD_Ref(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M007_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ILD.Where(x => x.ild.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ZADM_M007_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M007_P>().ToList()[0];
                    }
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (MasterEntity.ild != null && MasterEntity.ild != "")
                    {
                        //var InputValueIfExists = DetailEntity.Where(X => X.gl_code == POPUPEntityObject.gl_name).FirstOrDefault(); // Prefer Primary Key for this instruction.
                        //int IndexOfExistValue = DetailEntity.IndexOf(DetailEntity.Where(X => X.gl_code == POPUPEntityObject.gl_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                        if (NewRow == true && (AllowDuplicate == true) && ReferencesEntity.Count == dgSelectedIndexReferences)
                        {
                            ReferencesEntity.Add(new ENG_T004_C()
                            {

                                id = 0,
                                location_Id = AppSessionState.location_Id,
                                comp_code = AppSessionState.comp_code,
                                editby = AppSessionState.UserID,
                                add_by = AppSessionState.UserID,
                                t_status = "001",
                                active = true,

                            });
                        }
                        else if (dgSelectedIndexReferences >= 0 && ReferencesEntity.Count > dgSelectedIndexReferences) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                        {
                            if (ReferencesEntity[dgSelectedIndexReferences].id == 0) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                            {
                                ReferencesEntity[dgSelectedIndexReferences].active = true;
                                ReferencesEntity[dgSelectedIndexReferences].location_Id = AppSessionState.location_Id;
                                ReferencesEntity[dgSelectedIndexReferences].comp_code = AppSessionState.comp_code;
                                ReferencesEntity[dgSelectedIndexReferences].add_by = AppSessionState.UserID;
                                ReferencesEntity[dgSelectedIndexReferences].editby = AppSessionState.UserID;
                                ReferencesEntity[dgSelectedIndexReferences].t_status = "001";
                            }
                            else if (ReferencesEntity[dgSelectedIndexReferences].ild != POPUPEntityObject.ild)
                            {
                                ReferencesEntity[dgSelectedIndexReferences].ild = POPUPEntityObject.ild;
                            }
                        }
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("please select ILD...");
                        showMessageService.ShowMessage();
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

        #region . Filters .

        #region . Machine .
        private string _filterString_Machine;
        public string filterString_Machine
        {
            get { return _filterString_Machine; }
            set
            {
                _filterString_Machine = value;
                RaisePropertyChanged("filterString_Machine");
                FilterCollection_Machine();
            }
        }
        private void FilterCollection_Machine()
        {
            if (MachineCollection != null)
            {
                MachineCollection.Refresh();
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
                           (data.machinesrno != null && data.machinesrno.ToString().ToLower().Contains(_filterString_Machine.ToLower())) ||
                           (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_Machine.ToLower())) ||
                           (data.machinedesc != null && data.machinedesc.ToString().ToLower().Contains(_filterString_Machine.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . ItemCode .
        private string _filterString_ItemMasterCollection;
        public string FilterString_ItemMasterCollection
        {
            get { return _filterString_ItemMasterCollection; }
            set
            {
                _filterString_ItemMasterCollection = value;
                RaisePropertyChanged("FilterString_ItemMasterCollection");
                Filter_ItemList();
            }
        }
        private void Filter_ItemList()
        {
            if (_ItemCollection != null)
            {
                _ItemCollection.Refresh();
            }
        }
        public bool Filter_Item(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ItemMasterCollection))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_ItemMasterCollection.ToLower())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_ItemMasterCollection.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . SelectedToolData .
        private string _filterString_SelectedParaItem;
        public string filterString_SelectedParaItem
        {
            get { return _filterString_SelectedParaItem; }
            set
            {
                _filterString_SelectedParaItem = value;
                RaisePropertyChanged("filterString_SelectedParaItem");
                Filter_SelectedParaItem();
            }
        }
        private void Filter_SelectedParaItem()
        {
            if (SelectedParaItemCollection != null)
            {
                SelectedParaItemCollection.Refresh();
            }
        }
        public bool Filter_SelectedParaItem(object obj)
        {
            var data = obj as ENG_T004_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SelectedParaItem))
                {
                    return (data.spec_type_code != null && data.spec_type_code.ToString().ToLower().Contains(_filterString_SelectedParaItem.ToLower())) ||
                           (data.spec_para_code != null && data.spec_para_code.ToString().ToLower().Contains(_filterString_SelectedParaItem.ToLower())) ||
                           (data.tol_minus != null && data.tol_minus.ToString().ToLower().Contains(_filterString_SelectedParaItem.ToLower())) ||
                           (data.tol_plus != null && data.tol_plus.ToString().ToLower().Contains(_filterString_SelectedParaItem.ToLower())) ||
                           (data.frequency != null && data.frequency.ToString().ToLower().Contains(_filterString_SelectedParaItem.ToLower())) ||
                           (data.para_value != null && data.para_value.ToString().ToLower().Contains(_filterString_SelectedParaItem.ToLower())) ||
                           (data.range != null && data.range.ToString().ToLower().Contains(_filterString_SelectedParaItem.ToLower())) ||
                           (data.instrument_code != null && data.instrument_code.ToString().ToLower().Contains(_filterString_SelectedParaItem.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_SelectedParaItem.ToLower())) ||
                           (data.active != null && data.active.ToString().ToLower().Contains(_filterString_SelectedParaItem.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . SelectedToolData .
        private string _filterString_ToolItem;
        public string filterString_ToolItem
        {
            get { return _filterString_ToolItem; }
            set
            {
                _filterString_ToolItem = value;
                RaisePropertyChanged("filterString_ToolItem");
                Filter_ToolItem();
            }
        }
        private void Filter_ToolItem()
        {
            if (SelectedItemToolCollection != null)
            {
                SelectedItemToolCollection.Refresh();
            }
        }
        public bool Filter_ToolItem(object obj)
        {
            var data = obj as ENG_T004_B;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ToolItem))
                {
                    return (data.stn_no != null && data.stn_no.ToString().ToLower().Contains(_filterString_ToolItem.ToLower())) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_ToolItem.ToLower())) ||
                           (data.Make != null && data.Make.ToString().ToLower().Contains(_filterString_ToolItem.ToLower())) ||
                           (data.section_type != null && data.section_type.ToString().ToLower().Contains(_filterString_ToolItem.ToLower())) ||
                           (data.quantity != null && data.quantity.ToString().ToLower().Contains(_filterString_ToolItem.ToLower())) ||
                           (data.life_days != null && data.life_days.ToString().ToLower().Contains(_filterString_ToolItem.ToLower())) ||
                           (data.life_qty != null && data.life_qty.ToString().ToLower().Contains(_filterString_ToolItem.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_ToolItem.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . SelectedDrillData .
        private string _filterString_DrillItem;
        public string filterString_DrillItem
        {
            get { return _filterString_DrillItem; }
            set
            {
                _filterString_DrillItem = value;
                RaisePropertyChanged("filterString_DrillItem");
                Filter_DrillItem();
            }
        }
        private void Filter_DrillItem()
        {
            if (SelectedDrillItemCollection != null)
            {
                SelectedDrillItemCollection.Refresh();
            }
        }
        public bool Filter_DrillItem(object obj)
        {
            var data = obj as ENG_T004_B;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_DrillItem))
                {
                    return (data.stn_no != null && data.stn_no.ToString().ToLower().Contains(_filterString_DrillItem.ToLower())) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_DrillItem.ToLower())) ||
                           (data.Make != null && data.Make.ToString().ToLower().Contains(_filterString_DrillItem.ToLower())) ||
                           (data.section_type != null && data.section_type.ToString().ToLower().Contains(_filterString_DrillItem.ToLower())) ||
                           (data.quantity != null && data.quantity.ToString().ToLower().Contains(_filterString_DrillItem.ToLower())) ||
                           (data.life_days != null && data.life_days.ToString().ToLower().Contains(_filterString_DrillItem.ToLower())) ||
                           (data.life_qty != null && data.life_qty.ToString().ToLower().Contains(_filterString_DrillItem.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_DrillItem.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . SelectedSpareData .
        private string _filterString_SpareItem;
        public string filterString_SpareItem
        {
            get { return _filterString_SpareItem; }
            set
            {
                _filterString_SpareItem = value;
                RaisePropertyChanged("filterString_SpareItem");
                Filter_SpareItem();
            }
        }
        private void Filter_SpareItem()
        {
            if (SelectedSpareItemCollection != null)
            {
                SelectedSpareItemCollection.Refresh();
            }
        }
        public bool Filter_SpareItem(object obj)
        {
            var data = obj as ENG_T004_B;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SpareItem))
                {
                    return (data.stn_no != null && data.stn_no.ToString().ToLower().Contains(_filterString_SpareItem.ToLower())) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_SpareItem.ToLower())) ||
                           (data.Make != null && data.Make.ToString().ToLower().Contains(_filterString_SpareItem.ToLower())) ||
                           (data.section_type != null && data.section_type.ToString().ToLower().Contains(_filterString_SpareItem.ToLower())) ||
                           (data.quantity != null && data.quantity.ToString().ToLower().Contains(_filterString_SpareItem.ToLower())) ||
                           (data.life_days != null && data.life_days.ToString().ToLower().Contains(_filterString_SpareItem.ToLower())) ||
                           (data.life_qty != null && data.life_qty.ToString().ToLower().Contains(_filterString_SpareItem.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_SpareItem.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . ToolsItem  .
        private string _filterString_ToolsItem;
        public string filterString_ToolsItem
        {
            get { return _filterString_ToolsItem; }
            set
            {
                _filterString_ToolsItem = value;
                RaisePropertyChanged("filterString_ToolsItem");
                Filter_ToolsItemList();
            }
        }
        private void Filter_ToolsItemList()
        {
            try
            {
                if (ToolsItemCollection != null)
                {
                    ToolsItemCollection.Refresh();
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
        public bool Filter_ToolsItem(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ToolsItem))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_ToolsItem.ToLower())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_ToolsItem.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . DrillsItem  .
        private string _filterString_DrillsItem;
        public string filterString_DrillsItem
        {
            get { return _filterString_DrillsItem; }
            set
            {
                _filterString_DrillsItem = value;
                RaisePropertyChanged("filterString_DrillsItem");
                Filter_DrillsItemList();
            }
        }
        private void Filter_DrillsItemList()
        {
            if (_DrillsItemCollection != null)
            {
                _DrillsItemCollection.Refresh();
            }
        }
        public bool Filter_DrillsItem(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_DrillsItem))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_DrillsItem.ToLower())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_DrillsItem.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . SparesItem  .
        private string _filterString_SparesItem;
        public string filterString_SparesItem
        {
            get { return _filterString_SparesItem; }
            set
            {
                _filterString_SparesItem = value;
                RaisePropertyChanged("filterString_SparesItem");
                Filter_SparesItemList();
            }
        }
        private void Filter_SparesItemList()
        {
            if (SparesItemCollection != null)
            {
                SparesItemCollection.Refresh();
            }
        }
        public bool Filter_SparesItem(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SparesItem))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_SparesItem.ToLower())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_SparesItem.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Ink .
        private string _filterString_InkMasterCollection;
        public string FilterString_InkMasterCollection
        {
            get { return _filterString_InkMasterCollection; }
            set
            {
                _filterString_InkMasterCollection = value;
                RaisePropertyChanged("FilterString_InkMasterCollection");
                FilterCollection_InkMasterCollection();
            }
        }
        private void FilterCollection_InkMasterCollection()
        {
            if (_InkCollection != null)
            {
                _InkCollection.Refresh();
            }
        }
        public bool Filter_InkMasterCollection(object obj)
        {
            var data = obj as ZADM_M006_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_InkMasterCollection))
                {
                    return (data.ink != null && data.ink.ToString().ToLower().Contains(_filterString_InkMasterCollection.ToLower())) ||
                           (data.ink_id != null && data.ink_id.ToString().ToLower().Contains(_filterString_InkMasterCollection.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . ILD .
        private string _filterString_ILDMasterCollection;
        public string FilterString_ILDMasterCollection
        {
            get { return _filterString_ILDMasterCollection; }
            set
            {
                _filterString_ILDMasterCollection = value;
                RaisePropertyChanged("FilterString_ILDMasterCollection");
                FilterCollection_ILDMasterCollection();
            }
        }
        private void FilterCollection_ILDMasterCollection()
        {
            if (_ILDCollection != null)
            {
                _ILDCollection.Refresh();
            }
        }
        public bool Filter_ILDMasterCollection(object obj)
        {
            var data = obj as ZADM_M007_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_ILDMasterCollection))
                {
                    return (data.ild != null && data.ild.ToString().ToLower().Contains(_filterString_ILDMasterCollection.ToLower())) ||
                           (data.ild_id != null && data.ild_id.ToString().ToLower().Contains(_filterString_ILDMasterCollection.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Unit .
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
                if (!string.IsNullOrEmpty(_filterStringUom))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringUom.ToLower())) ||
                           (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringUom.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Model .
        private string _filterStringModel;
        public string FilterStringModel
        {
            get { return _filterStringModel; }
            set
            {
                _filterStringModel = value;
                RaisePropertyChanged("FilterStringModel");
                Filter_ModelCollection();
            }
        }
        private void Filter_ModelCollection()
        {
            if (_ModelCollection != null)
            {
                _ModelCollection.Refresh();
            }
        }
        public bool Filter_Model(object obj)
        {
            var data = obj as ZADM_M009_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringModel))
                {
                    return (data.model_id.ToString() != null && data.model_id.ToString().ToLower().Contains(_filterStringModel.ToString().ToLower())) ||
                           (data.modelno != null && data.modelno.ToString().ToLower().Contains(_filterStringModel.ToString().ToLower())) ||
                           (data.modeldesc != null && data.modeldesc.ToString().ToLower().Contains(_filterStringModel.ToString().ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Party Master .
        private string _filterString_PartyMaster;
        public string FilterString_PartyMaster
        {
            get { return _filterString_PartyMaster; }
            set
            {
                _filterString_PartyMaster = value;
                RaisePropertyChanged("FilterString_PartyMaster");
                FilterCollection_PartyMaster();
            }
        }
        private void FilterCollection_PartyMaster()
        {
            if (_PartyCollection != null)
            {
                _PartyCollection.Refresh();
            }
        }
        public bool Filter_PartyMaster(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_PartyMaster))
                {
                    return (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_filterString_PartyMaster.ToLower())) ||
                           (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_PartyMaster.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region .Specification Type .
        private string _filterStringSpecType;
        public string filterStringSpecType
        {
            get { return _filterStringSpecType; }
            set
            {
                _filterStringSpecType = value;
                RaisePropertyChanged("filterStringSpecType");
                Filter_SpecTypeCollection();
            }
        }
        private void Filter_SpecTypeCollection()
        {
            if (SpecTypeCollection != null)
            {
                SpecTypeCollection.Refresh();
            }
        }
        public bool Filter_SpecType(object obj)
        {
            var data = obj as ENG_T002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringSpecType))
                {
                    return (data.spec_type != null && data.spec_type.ToString().ToLower().Contains(_filterStringSpecType.ToLower())) ||
                           (data.spec_type_code != null && data.spec_type_code.ToString().ToLower().Contains(_filterStringSpecType.ToLower())) ||
                           (data.spec_details != null && data.spec_details.ToString().ToLower().Contains(_filterStringSpecType.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region .Station No .
        private string _filterStationNo;
        public string filterStationNo
        {
            get { return _filterStationNo; }
            set
            {
                _filterStationNo = value;
                RaisePropertyChanged("filterStationNo");
                Filter_StationNoCollection();
            }
        }
        private void Filter_StationNoCollection()
        {
            if (StationnoCollection != null)
            {
                StationnoCollection.Refresh();
            }
        }
        public bool Filter_Stationno(object obj)
        {
            var data = obj as ADM_M030_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStationNo))
                {
                    return (data.parametervalue != null && data.parametervalue.ToString().ToLower().Contains(_filterStationNo.ToLower())) ||
                           (data.para_code != null && data.para_code.ToString().ToLower().Contains(_filterStationNo.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region .Specification Parameter .
        private string _filterStringSpecPara;
        public string filterStringSpecPara
        {
            get { return _filterStringSpecPara; }
            set
            {
                _filterStringSpecPara = value;
                RaisePropertyChanged("filterStringSpecPara");
                Filter_SpecParaCollection();
            }
        }
        private void Filter_SpecParaCollection()
        {
            if (_SpecParaCollection != null)
            {
                _SpecParaCollection.Refresh();
            }
        }
        public bool Filter_SpecPara(object obj)
        {
            var data = obj as ENG_T003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringSpecPara))
                {
                    return (data.spec_para_code != null && data.spec_para_code.ToString().ToLower().Contains(_filterStringSpecPara.ToLower())) ||
                           (data.parameter != null && data.parameter.ToString().ToLower().Contains(_filterStringSpecPara.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion        

        #region .Specification Instrument .
        private string _filterStringInstrument;
        public string filterStringInstrument
        {
            get { return _filterStringInstrument; }
            set
            {
                _filterStringInstrument = value;
                RaisePropertyChanged("filterStringInstrument");
                Filter_InstrumentCollection();
            }
        }
        private void Filter_InstrumentCollection()
        {
            if (_InstrumentCollection != null)
            {
                _InstrumentCollection.Refresh();
            }
        }
        public bool Filter_Instrument(object obj)
        {
            var data = obj as ENG_T003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(filterStringInstrument))
                {
                    return (data.spec_para_code != null && data.spec_para_code.ToString().ToLower().Contains(filterStringInstrument.ToLower())) ||
                           (data.parameter != null && data.parameter.ToString().ToLower().Contains(filterStringInstrument.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region .Specification Working .
        private string _filterStringWorking;
        public string filterStringWorking
        {
            get { return _filterStringWorking; }
            set
            {
                _filterStringWorking = value;
                RaisePropertyChanged("filterStringWorking");
                Filter_WorkingCollection();
            }
        }
        private void Filter_WorkingCollection()
        {
            if (_WorkingCollection != null)
            {
                _WorkingCollection.Refresh();
            }
        }
        public bool Filter_Working(object obj)
        {
            var data = obj as ENG_T003;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringWorking))
                {
                    return (data.spec_para_code != null && data.spec_para_code.ToString().ToLower().Contains(_filterStringWorking.ToLower())) ||
                           (data.parameter != null && data.parameter.ToString().ToLower().Contains(_filterStringWorking.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . WireType .
        private string _filterString_WireTypeCollection;
        public string filterString_WireTypeCollection
        {
            get { return _filterString_WireTypeCollection; }
            set
            {
                _filterString_WireTypeCollection = value;
                RaisePropertyChanged("filterString_WireTypeCollection");
                FilterCollection_WireTypeCollection();
            }
        }
        private void FilterCollection_WireTypeCollection()
        {
            if (WireTypeCollection != null)
            {
                WireTypeCollection.Refresh();
            }
        }
        public bool Filter_WireTypeCollection(object obj)
        {
            var data = obj as ZADM_M004_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_WireTypeCollection))
                {
                    return (data.wire_type != null && data.wire_type.ToString().ToLower().Contains(_filterString_WireTypeCollection.ToLower())) ||
                           (data.wire_type_id != null && data.wire_type_id.ToString().ToLower().Contains(_filterString_WireTypeCollection.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . Grade .
        private string _filterString_GradeCollection;
        public string filterString_GradeCollection
        {
            get { return _filterString_GradeCollection; }
            set
            {
                _filterString_GradeCollection = value;
                RaisePropertyChanged("filterString_GradeCollection");
                FilterCollection_GradeCollection();
            }
        }
        private void FilterCollection_GradeCollection()
        {
            if (GradeCollection != null)
            {
                GradeCollection.Refresh();
            }
        }
        public bool Filter_Grade(object obj)
        {
            var data = obj as ADM_M045_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_GradeCollection))
                {
                    return (data.grade_code != null && data.grade_code.ToString().ToLower().Contains(_filterString_GradeCollection.ToLower())) ||
                           (data.grade_name != null && data.grade_name.ToString().ToLower().Contains(_filterString_GradeCollection.ToLower()));
                }
                return true;
            }
            return false;
        }


        #endregion

        #region . FlipGrid .
        private string _filterString_FlipGrid;
        public string filterString_FlipGrid
        {
            get { return _filterString_FlipGrid; }
            set
            {
                _filterString_FlipGrid = value;
                RaisePropertyChanged("filterString_FlipGrid");
                FilterCollection_FlipGrid();
            }
        }
        private void FilterCollection_FlipGrid()
        {
            if (BackFlipCollection != null)
            {
                BackFlipCollection.Refresh();
            }
        }
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as ENG_T004_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_FlipGrid))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.modelno != null && data.modelno.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.wire_type != null && data.wire_type.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.ink != null && data.ink.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.ild != null && data.ild.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.revision_no != null && data.revision_no.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_filterString_FlipGrid.ToLower()));
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
            if (plantCollection != null)
            {
                plantCollection.Refresh();
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

        #region .WireDia .
        private string _filterString_WireDia;
        public string filterString_WireDia
        {
            get { return _filterString_WireDia; }
            set
            {
                _filterString_WireDia = value;
                RaisePropertyChanged("filterString_WireDia");
                FilterCollection_WireDia();
            }
        }
        private void FilterCollection_WireDia()
        {
            if (WireDiaCollection != null)
            {
                WireDiaCollection.Refresh();
            }
        }
        public bool Filter_WireDia(object obj)
        {
            var data = obj as ZADM_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_WireDia))
                {
                    return (data.wire_size != null && data.wire_size.ToString().ToLower().Contains(_filterString_WireDia.ToLower())) ||
                           (data.wire_size_id != null && data.wire_size_id.ToString().ToLower().Contains(_filterString_WireDia.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region .BallDia .
        private string _filterString_BallDia;
        public string filterString_BallDia
        {
            get { return _filterString_BallDia; }
            set
            {
                _filterString_BallDia = value;
                RaisePropertyChanged("filterString_BallDia");
                FilterCollection_BallDia();
            }
        }
        private void FilterCollection_BallDia()
        {
            if (BallDiaCollection != null)
            {
                BallDiaCollection.Refresh();
            }
        }
        public bool Filter_BallDia(object obj)
        {
            var data = obj as ZADM_M001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_BallDia))
                {
                    return (data.ball_dia != null && data.ball_dia.ToString().ToLower().Contains(_filterString_BallDia.ToLower())) ||
                           (data.ball_dia_id != null && data.ball_dia_id.ToString().ToLower().Contains(_filterString_BallDia.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . SearchPara .
        private string _FilterStringSearchPara = "";
        public string FilterStringSearchPara
        {
            get { return _FilterStringSearchPara; }
            set
            {
                _FilterStringSearchPara = value;
                RaisePropertyChanged("FilterStringSearchPara");
                FilterCollectionSearchPara();
            }
        }
        private void FilterCollectionSearchPara()
        {
            try
            {
                ParaSearchCollection = CollectionViewSource.GetDefaultView(ParaDetailEntity);
                ParaSearchCollection.Filter = new Predicate<object>(FilterParaSearch);
                if (_ParaSearchCollection != null)
                {
                    _ParaSearchCollection.Refresh();
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
        public bool FilterParaSearch(object obj)
        {
            var data = obj as ENG_T004_A;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringSearchPara))
                {
                    return (data.spec_type != null && data.spec_type.ToString().ToLower().Contains(_FilterStringSearchPara.ToString().ToLower()) ||
                           (data.spec_type_code != null && data.spec_type_code.ToString().ToLower().Contains(_FilterStringSearchPara.ToString())) ||
                           (data.parameter != null && data.parameter.ToString().ToLower().Contains(_FilterStringSearchPara.ToString().ToLower())) ||
                           (data.spec_para_code != null && data.spec_para_code.ToString().ToLower().Contains(_FilterStringSearchPara.ToString()))) ||
                           (data.para_value != null && data.para_value.ToString().ToLower().Contains(_FilterStringSearchPara.ToString().ToLower())) ||
                           (data.tol_minus != null && data.tol_minus.ToString().ToLower().Contains(_FilterStringSearchPara.ToString().ToLower())) ||
                           (data.tol_plus != null && data.tol_plus.ToString().ToLower().Contains(_FilterStringSearchPara.ToString().ToLower())) ||
                           (data.range != null && data.range.ToString().ToLower().Contains(_FilterStringSearchPara.ToString().ToLower())) ||
                           (data.frequency != null && data.frequency.ToString().ToLower().Contains(_FilterStringSearchPara.ToString().ToLower())) ||
                           (data.instrument_code != null && data.instrument_code.ToString().ToLower().Contains(_FilterStringSearchPara.ToString().ToLower())) ||
                           (data.remark != null && data.remark.ToString().ToLower().Contains(_FilterStringSearchPara.ToString().ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . SearchTools .
        private string _FilterStringSearchTools = "";
        public string FilterStringSearchTools
        {
            get { return _FilterStringSearchTools; }
            set
            {
                _FilterStringSearchTools = value;
                RaisePropertyChanged("FilterStringSearchTools");
                FilterCollectionSearchTools();
            }
        }
        private void FilterCollectionSearchTools()
        {
            try
            {
                ToolsSearchCollection = CollectionViewSource.GetDefaultView(ToolsDetailEntity);
                ToolsSearchCollection.Filter = new Predicate<object>(FilterToolSearch);
                if (_ToolsSearchCollection != null)
                {
                    _ToolsSearchCollection.Refresh();
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
        public bool FilterToolSearch(object obj)
        {
            var data = obj as ENG_T004_B;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringSearchTools))
                {
                    return (data.stn_no != null && data.stn_no.ToString().ToLower().Contains(_FilterStringSearchTools.ToString().ToLower()) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_FilterStringSearchTools.ToString())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_FilterStringSearchTools.ToString().ToLower())) ||
                           (data.Make != null && data.Make.ToString().ToLower().Contains(_FilterStringSearchTools.ToString()))) ||
                           (data.section_type != null && data.section_type.ToString().ToLower().Contains(_FilterStringSearchTools.ToString().ToLower())) ||
                           (data.quantity != null && data.quantity.ToString().ToLower().Contains(_FilterStringSearchTools.ToString().ToLower())) ||
                           (data.life_days != null && data.life_days.ToString().ToLower().Contains(_FilterStringSearchTools.ToString().ToLower())) ||
                           (data.life_qty != null && data.life_qty.ToString().ToLower().Contains(_FilterStringSearchTools.ToString().ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_FilterStringSearchTools.ToString().ToLower())) ||
                           (data.active != null && data.active.ToString().ToLower().Contains(_FilterStringSearchTools.ToString().ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . SearchDrills .
        private string _FilterStringSearchDrills = "";
        public string FilterStringSearchDrills
        {
            get { return _FilterStringSearchDrills; }
            set
            {
                _FilterStringSearchDrills = value;
                RaisePropertyChanged("FilterStringSearchDrills");
                FilterCollectionSearchDrills();
            }
        }
        private void FilterCollectionSearchDrills()
        {
            try
            {
                DrillsSearchCollection = CollectionViewSource.GetDefaultView(DrillsDetailEntity);
                DrillsSearchCollection.Filter = new Predicate<object>(FilterDrillSearch);
                if (_DrillsSearchCollection != null)
                {
                    _DrillsSearchCollection.Refresh();
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
        public bool FilterDrillSearch(object obj)
        {
            var data = obj as ENG_T004_B;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringSearchDrills))
                {
                    return (data.stn_no.ToString() != null && data.stn_no.ToString().ToLower().Contains(_FilterStringSearchDrills.ToString().ToLower()) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_FilterStringSearchDrills.ToString())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_FilterStringSearchDrills.ToString().ToLower())) ||
                           (data.Make != null && data.Make.ToString().ToLower().Contains(_FilterStringSearchDrills.ToString()))) ||
                           (data.section_type != null && data.section_type.ToString().ToLower().Contains(_FilterStringSearchDrills.ToString().ToLower())) ||
                           (data.quantity != null && data.quantity.ToString().ToLower().Contains(_FilterStringSearchDrills.ToString().ToLower())) ||
                           (data.life_days != null && data.life_days.ToString().ToLower().Contains(_FilterStringSearchDrills.ToString().ToLower())) ||
                           (data.life_qty != null && data.life_qty.ToString().ToLower().Contains(_FilterStringSearchDrills.ToString().ToLower())) ||
                           (data.degree != null && data.degree.ToString().ToLower().Contains(_FilterStringSearchDrills.ToString().ToLower())) ||
                           (data.drill_spec != null && data.drill_spec.ToString().ToLower().Contains(_FilterStringSearchDrills.ToString().ToLower())) ||
                           (data.drill_section != null && data.drill_section.ToString().ToLower().Contains(_FilterStringSearchDrills.ToString().ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_FilterStringSearchDrills.ToString().ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region . SearchSpares .
        private string _FilterStringSearchSpares = "";
        public string FilterStringSearchSpares
        {
            get { return _FilterStringSearchSpares; }
            set
            {
                _FilterStringSearchSpares = value;
                RaisePropertyChanged("FilterStringSearchSpares");
                FilterCollectionSearchSpares();
            }
        }
        private void FilterCollectionSearchSpares()
        {
            try
            {
                SparesSearchCollection = CollectionViewSource.GetDefaultView(SparesDetailEntity);
                SparesSearchCollection.Filter = new Predicate<object>(FilterSpareSearch);
                if (_SparesSearchCollection != null)
                {
                    _SparesSearchCollection.Refresh();
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
        public bool FilterSpareSearch(object obj)
        {
            var data = obj as ENG_T004_B;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringSearchSpares))
                {
                    return (data.stn_no != null && data.stn_no.ToString().ToLower().Contains(_FilterStringSearchSpares.ToString().ToLower()) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_FilterStringSearchSpares.ToString())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_FilterStringSearchSpares.ToString().ToLower())) ||
                           (data.Make != null && data.Make.ToString().ToLower().Contains(_FilterStringSearchSpares.ToString()))) ||
                           (data.section_type != null && data.section_type.ToString().ToLower().Contains(_FilterStringSearchSpares.ToString().ToLower())) ||
                           (data.quantity != null && data.quantity.ToString().ToLower().Contains(_FilterStringSearchSpares.ToString().ToLower())) ||
                           (data.life_days != null && data.life_days.ToString().ToLower().Contains(_FilterStringSearchSpares.ToString().ToLower())) ||
                           (data.life_qty != null && data.life_qty.ToString().ToLower().Contains(_FilterStringSearchSpares.ToString().ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_FilterStringSearchSpares.ToString().ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion
        //make
        #region .BallDia .
        private string _FilterString_Make;
        public string FilterString_Make
        {
            get { return _FilterString_Make; }
            set
            {
                _FilterString_Make = value;
                RaisePropertyChanged("FilterString_Make");
                FilterCollection_Make();
            }
        }
        private void FilterCollection_Make()
        {
            if (ToolsMakeCollection != null)
            {
                ToolsMakeCollection.Refresh();
            }
        }
        public bool Filter_Make(object obj)
        {
            var data = obj as ADM_M030_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_Make))
                {
                    return (data.parametervalue != null && data.parametervalue.ToString().ToLower().Contains(_FilterString_Make.ToLower()));
                }
                return true;
            }
            return false;
        }


        #endregion
        #endregion
    }
}
