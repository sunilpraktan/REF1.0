using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using System.ComponentModel;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services.Convertors;
using Reflection.BusinessEntity.ADM;

namespace Reflection.Modules.Production.ViewModels
{

    public class ESO_T001_VM_2 : WorkspaceViewModel<ESO_T001>
    {

        bool isNewRecord = true;
        
        WebServiceRepository<ESO_T001> repository = new WebServiceRepository<ESO_T001>();
        WebServiceRepository<MultipleContext_ESO_T001_A> repository_MC = new WebServiceRepository<MultipleContext_ESO_T001_A>();
        WebServiceRepository<MultipleContext_ESO_T001_A> repository_MCTemp = new WebServiceRepository<MultipleContext_ESO_T001_A>();
        WebServiceRepository<MultipleContext_ESO_T001_A> repository_MCTemp1 = new WebServiceRepository<MultipleContext_ESO_T001_A>();
        WebServiceRepository<MultipleContext_ESO_T001_A> repository_MCTemp5 = new WebServiceRepository<MultipleContext_ESO_T001_A>();

        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
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

        private AutoSuggestTextViewModel<dynamic> _AS_Unit { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Unit
        {
            get { return _AS_Unit; }
            set
            {
                if (_AS_Unit != value)
                {
                    _AS_Unit = value; RaisePropertyChanged("AS_Unit");
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

        private AutoSuggestTextViewModel<dynamic> _AS_ShiftIncharge { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ShiftIncharge
        {
            get { return _AS_ShiftIncharge; }
            set
            {
                if (_AS_ShiftIncharge != value)
                {
                    _AS_ShiftIncharge = value; RaisePropertyChanged("AS_ShiftIncharge");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _AS_Batch { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_Batch
        {
            get { return _AS_Batch; }
            set
            {
                if (_AS_Batch != value)
                {
                    _AS_Batch = value; RaisePropertyChanged("AS_Batch");
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
        private AutoSuggestTextViewModel<dynamic> _ASShift { get; set; }
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
                    if (SourceName == "dfctdsc")
                    { ASDefault = AS_Defect; }
                    else if (SourceName == "defect_type")
                    { ASDefault1 = AS_Defect; }


                }
            }
        }



        #endregion

        #region  Declaration   
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        private ESO_T001 _MasterEntity;
        public ESO_T001 MasterEntity
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

        private ESO_T001 _MasterEntityTemp;
        public ESO_T001 MasterEntityTemp
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
                    FilterDefectDataGrid();
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

        MultipleContext_ESO_T001_A _MC = new MultipleContext_ESO_T001_A();
        public MultipleContext_ESO_T001_A MC
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

        MultipleContext_ESO_T001_A _MCTemp = new MultipleContext_ESO_T001_A();
        public MultipleContext_ESO_T001_A MCTemp
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

        MultipleContext_ESO_T001_A _MCTemp5 = new MultipleContext_ESO_T001_A();
        public MultipleContext_ESO_T001_A MCTemp5
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

        MultipleContext_ESO_T001_A _MCTemp1 = new MultipleContext_ESO_T001_A();
        public MultipleContext_ESO_T001_A MCTemp1
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

        private ObservableCollection<ESO_T001_A> _SortingDetails;
        public ObservableCollection<ESO_T001_A> SortingDetails
        {
            get { return _SortingDetails; }
            set
            {
                if (_SortingDetails != value)
                {
                    _SortingDetails = value;
                    RaisePropertyChanged("SortingDetails");
                }
            }
        }

        private ObservableCollection<ESO_T001_B> _DefectEntity;
        public ObservableCollection<ESO_T001_B> DefectEntity
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

        List<ZADM_M016_P> _DefectList = new List<ZADM_M016_P>();
        public List<ZADM_M016_P> DefectList
        {
            get { return _DefectList; }
            set
            {
                if (_DefectList != value)
                {
                    _DefectList = value;

                    RaisePropertyChanged("DefectList");
                }
            }
        }

        private List<ESO_T001Flip> _FlipGridData;
        public List<ESO_T001Flip> FlipGridData
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

        private List<ESO_T001_rpt> _dgReportMaster;
        public List<ESO_T001_rpt> dgReportMaster
        {
            get { return _dgReportMaster; }
            set
            {
                if (_dgReportMaster != value)
                {
                    _dgReportMaster = value;


                    RaisePropertyChanged("dgReportMaster");

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

        #region ModelEntityUpdate
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = MasterEntity.HasErrors;
            if (sender.ToString() == "uc_qty" || sender.ToString() == "excess_qty" || sender.ToString() == "refill_qty" || sender.ToString() == "sample_qty")
            {
                cal();
            }
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            if (sender.ToString() == "rej_qty1" || sender.ToString() == "rej_qty2" || sender.ToString() == "active")
            {
                CalculateDefect(true);
            }
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/

        }
        void ModelUpdated_Defect(object sender, EventArgs e)
        {
            if (sender.ToString() == "rej_qty1" || sender.ToString() == "rej_qty2" || sender.ToString() == "active")
            {
                CalculateDefectEntity(true);
            }
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/

        }
        void ModelUpdated_Defect_TranCode(object sender, EventArgs e)
        {
            if (sender.ToString() == "total" && MC.DocTypeInfo[0].TranCode == "Sorting2")
            {
                cal();
            }
        }
        private void CalculateDefect(bool compute)
        {
            try
            {
                if (compute == true)
                {
                    if (SortingDetails != null && SortingDetails.Count > 0 && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < SortingDetails.Count)
                    {
                        if ((SortingDetails[dgSelectedIndexItem].rej_qty1 > 0 || SortingDetails[dgSelectedIndexItem].rej_qty2 > 0) && SortingDetails[dgSelectedIndexItem].active != false)
                        {
                            SortingDetails[dgSelectedIndexItem].total = (Convert.ToDecimal(SortingDetails[dgSelectedIndexItem].rej_qty1) + Convert.ToDecimal(SortingDetails[dgSelectedIndexItem].rej_qty2));
                        }
                    }
                }
                cal();
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
        private void CalculateDefectEntity(bool compute)
        {
            try
            {
                if (compute == true)
                {
                    int i = 0;
                    List<ESO_T001_B> temp = new List<ESO_T001_B>();
                    foreach (var item in DefectEntity)
                    {
                        if (item.parent_defect == SortingDetails[dgSelectedIndexItem].defect_type)
                        {
                            temp.Add(item);
                        }
                    }
                    foreach (var a in DefectEntity)
                    {
                        foreach (var b in temp)
                        {
                            if (a.deletion_id == b.deletion_id)
                            {
                                i = DefectEntity.IndexOf(a);
                            }
                        }
                    }
                    if (DefectEntity != null && DefectEntity.Count > 0 && dgSelectedIndexDefect < DefectEntity.Count)
                    {
                        if ((DefectEntity[i].rej_qty1 > 0 || DefectEntity[i].rej_qty2 > 0) && DefectEntity[i].active != false)
                        {
                            DefectEntity[i].total = (Convert.ToDecimal(DefectEntity[i].rej_qty1) + Convert.ToDecimal(DefectEntity[i].rej_qty2));
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
        private void cal()
        {
            try
            {
                MasterEntity.tot_rej = 0;
                for (int i = 0; i < SortingDetails.Count; i++)
                {
                    if (SortingDetails[i].total == null)
                    {
                        SortingDetails[i].total = 0;
                    }
                    MasterEntity.tot_rej = MasterEntity.tot_rej + SortingDetails[i].total;

                }
                MasterEntity.tot_rej = MasterEntity.tot_rej + Convert.ToDecimal(MasterEntity.refill_qty) + Convert.ToDecimal(MasterEntity.sample_qty);

                if (Convert.ToDecimal(MasterEntity.counter_qty) > 0)
                {
                    MasterEntity.sorted_qty = 0;
                    MasterEntity.sorted_qty = Convert.ToDecimal((MasterEntity.sorted_qty) + Convert.ToDecimal(MasterEntity.uc_qty) + Convert.ToDecimal(MasterEntity.excess_qty) - Convert.ToDecimal(MasterEntity.tot_rej)) /*- Convert.ToDecimal(MasterEntity.sample_qty)*/;
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

        #region ICollection
        private ICollectionView _dataGridCollection;// BF COllection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
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

        private ICollectionView _UOMCollection;// UOM Collection
        public ICollectionView UOMCollection
        {
            get { return _UOMCollection; }
            set
            {
                _UOMCollection = value;
                RaisePropertyChanged("UOMCollection");
            }
        }

        private ICollectionView _DefectListCollection;// Defect List For popup Collection
        public ICollectionView DefectListCollection
        {
            get { return _DefectListCollection; }
            set
            {
                _DefectListCollection = value;
                RaisePropertyChanged("DefectListCollection");
            }
        }

        private ICollectionView _SubDefectCollection;
        public ICollectionView SubDefectCollection
        {
            get { return _SubDefectCollection; }
            set
            {
                _SubDefectCollection = value;
                RaisePropertyChanged("SubDefectCollection");
            }
        }

        private ICollectionView _ShiftCollection; // shift Collection
        public ICollectionView ShiftCollection
        {
            get { return _ShiftCollection; }
            set
            {
                _ShiftCollection = value;
                RaisePropertyChanged("ShiftCollection");
            }
        }

        private ICollectionView _ShiftInchargeCollection;// Shiftincharge Collection
        public ICollectionView ShiftInchargeCollection
        {
            get { return _ShiftInchargeCollection; }
            set
            {
                _ShiftInchargeCollection = value;
                RaisePropertyChanged("ShiftInchargeCollection");
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

        private ICollectionView _OperatorCollection; // OPerator popup
        public ICollectionView OperatorCollection
        {
            get { return _OperatorCollection; }
            set
            {
                _OperatorCollection = value;
                RaisePropertyChanged("OperatorCollection");
            }
        }

        private ICollectionView _DocumentDataCollection;// Document Collection for BF
        public ICollectionView DocumentDataCollection
        {
            get { return _DocumentDataCollection; }
            set
            {
                _DocumentDataCollection = value;
                RaisePropertyChanged("DocumentDataCollection");
            }
        }

        private ICollectionView _DefectDataCollection;// Defect Collection for BF
        public ICollectionView DefectDataCollection
        {
            get { return _DefectDataCollection; }
            set
            {
                _DefectDataCollection = value;
                RaisePropertyChanged("DefectDataCollection");
            }
        }
        private ICollectionView _SortybyCollection; // Barcode details
        public ICollectionView SortybyCollection
        {
            get { return _SortybyCollection; }
            set
            {
                _SortybyCollection = value;
                RaisePropertyChanged("SortybyCollection");
            }
        }

        private ICollectionView _DefectDataGridCollection;
        public ICollectionView DefectDataGridCollection
        {
            get { return _DefectDataGridCollection; }
            set
            {
                _DefectDataGridCollection = value;
                RaisePropertyChanged("DefectDataGridCollection");
            }
        }

        private ICollectionView _machinecollection;
        public ICollectionView machinecollection
        {
            get { return _machinecollection; }
            set
            {
                _machinecollection = value;
                RaisePropertyChanged("machinecollection");
            }
        }

        #endregion

        #region StringLists

        List<string> _stringListMachine;
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

        private List<string> _StringListSubDefect;
        public List<string> StringListSubDefect
        {
            get { return _StringListSubDefect; }
            set
            {
                if (_StringListSubDefect != value)
                {
                    _StringListSubDefect = value;
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

        List<string> _StringListShiftIncharge;
        public List<string> StringListShiftIncharge
        {
            get { return _StringListShiftIncharge; }
            set
            {
                if (_StringListShiftIncharge != value)
                {
                    _StringListShiftIncharge = value;
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

        List<string> _StringListDocData;
        public List<string> StringListDocData
        {
            get { return _StringListDocData; }
            set
            {
                if (_StringListDocData != value)
                {
                    _StringListDocData = value;
                }
            }
        }

        List<string> _StringListDefData;
        public List<string> StringListDefData
        {
            get { return _StringListDefData; }
            set
            {
                if (_StringListDefData != value)
                {
                    _StringListDefData = value;
                }
            }
        }
        List<string> _StringListSortby;
        public List<string> StringListSortby
        {
            get { return _StringListSortby; }
            set
            {
                if (_StringListSortby != value)
                {
                    _StringListSortby = value;
                }
            }
        }

        private List<string> _StringListmachine;
        public List<string> StringListmachine
        {
            get { return _StringListmachine; }
            set
            {
                if (_StringListmachine != value)
                {
                    _StringListmachine = value;
                }
            }
        }
        #endregion

        #region Relay Commands Declaration
        public GalaSoft.MvvmLight.Command.RelayCommand CMDDefectDataGrid { get; private set; }
        public RelayCommand<object> CmdDefect { get; private set; }
        public RelayCommand<object> CmdAddMachine { get; private set; }
        public RelayCommand<object> CmdAddUOM { get; private set; }
        public RelayCommand<object> CmdAddDefList { get; private set; }
        public RelayCommand<object> CmdAddShift { get; private set; }
        public RelayCommand<object> CmdAddShiftIncharge { get; private set; }
        public RelayCommand<object> CmdAddBatchDetails { get; private set; }
        public RelayCommand<object> CmdAddOperators { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdLoadDefectDetails { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowBatch { get; private set; }
        public RelayCommand<IList> CellChangedCommand { get; private set; }
        public RelayCommand<Boolean> ManualSortingChangedCommand { get; private set; }
        public RelayCommand<Boolean> AutomaticSortingChangedCommand { get; private set; }
        public RelayCommand<object> SelectedDateChangedCommand { get; private set; }
        public RelayCommand<object> CmdAddSortBy { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CommandForLoadBackFlip { get; private set; }
        public RelayCommand<object> CmdDefectEntityRow { get; private set; }
        public RelayCommand<object> CMDMachine { get; private set; }
        public RelayCommand<object> CmdInsert_t_status { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand cmdLoadFromFilter { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> CmdInsertGrade { get; private set; }

        #endregion

        #region Constructor

        public ESO_T001_VM_2(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            MasterEntity = new ESO_T001();
            SortingDetails = new ObservableCollection<ESO_T001_A>();
            DefectEntity = new ObservableCollection<ESO_T001_B>();
            MC = new MultipleContext_ESO_T001_A();
            MCTemp = new MultipleContext_ESO_T001_A();
            MCTemp1 = new MultipleContext_ESO_T001_A();
            SODetails = new ObservableCollection<PPC_T003_Batch>();
            MasterEntity.ValidateAsync().Wait();
            ESO_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            ESO_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            ESO_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Defect);
            ESO_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Defect_TranCode);
            
            LoadInitialData();

            //if (MC.DocTypeInfo.Count > 0)
            //{
            //    if (AppSessionState.TransValue != null && AppSessionState.TransactionCode == MC.DocTypeInfo[0].TranCode)
            //    {
            //        LoadDocumentByDocumentNumber(AppSessionState.TransValue, "DocumentNo");
            //        isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
            //        AppSessionState.TransValue = null;
            //        AppSessionState.TransId = null;
            //        AppSessionState.TransParameter = null;
            //        AppSessionState.ViewOtherRecordAllowed = true;
            //    }
            //}
        }
        public ESO_T001_VM_2(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new ESO_T001();
            SortingDetails = new ObservableCollection<ESO_T001_A>();
            DefectEntity = new ObservableCollection<ESO_T001_B>();
            MC = new MultipleContext_ESO_T001_A();
            MCTemp = new MultipleContext_ESO_T001_A();
            MCTemp1 = new MultipleContext_ESO_T001_A();
            SODetails = new ObservableCollection<PPC_T003_Batch>();
            MasterEntity.ValidateAsync().Wait();
            ESO_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            ESO_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            ESO_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Defect);
            ESO_T001_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Defect_TranCode);

            LoadInitialData();

        }
        private void LoadInitialData()
        {
            try
            {
                MasterEntity.doc_type = "SR";
                MasterEntity.doc_cat = "SR";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_type + "!@" + MasterEntity.doc_cat;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ESO_T001_A>(MC, Request, "Sorting2", "Production", "LoadInitialData", 0, "");
                #region Command Initialization
                CMDDefectDataGrid = new GalaSoft.MvvmLight.Command.RelayCommand(FilterDefectDataGrid);
                CmdDefect = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDefect(cmdPara, true, true, true); });
                CmdAddMachine = new RelayCommand<object>(items => { if (items == null) { return; } InsertMachine(items, isNewRecord); });
                CmdAddUOM = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOM(cmdPara); });
                CmdAddDefList = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDefList(cmdPara, true, true, true); });
                CmdAddShift = new RelayCommand<object>(items => { if (items == null) { return; } InsertShift(items); });
                CmdAddShiftIncharge = new RelayCommand<object>(items => { if (items == null) { return; } InsertShiftIncharge(items); });
                CmdAddBatchDetails = new RelayCommand<object>(items => { if (items == null) { return; } InsertBatchDetails(items); });
                CmdAddOperators = new RelayCommand<object>(items => { if (items == null) { return; } InsertOperators(items); });
                CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                cmdDeleteDataGridRowBatch = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Defect(cmdPara); });
                ManualSortingChangedCommand = new RelayCommand<bool>(ManualSortingChangeUpdate);
                AutomaticSortingChangedCommand = new RelayCommand<bool>(AutomaticSortingChangeUpdate);
                SelectedDateChangedCommand = new RelayCommand<object>(items => { if (items == null) { return; } MachineColour(items, isNewRecord); });
                CmdAddSortBy = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSortBy(cmdPara, true, true, true); });
                CommandForLoadBackFlip = new GalaSoft.MvvmLight.Command.RelayCommand(Load);
                CmdDefectEntityRow = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDefectEntityRow(cmdPara); });
                CMDMachine = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insertmachine(cmdPara, true, true, true); });
                cmdLoadFromFilter = new GalaSoft.MvvmLight.Command.RelayCommand(() => { LoadFromFilters(); });
                CmdInsert_t_status = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_t_status(cmdPara); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                CmdInsertGrade = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertGrade(cmdPara); });
                #endregion

                #region AutoSuggest Initialisation
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M016_P)x).dfctdsc.ToString());
                TheFilter = (o, prefix) => (((ZADM_M016_P)o).dfctcda.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.DefectList, TheFilter, SuggestedValue, "defect_type", "dfctdsc", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M016_P)x).dfctdsc.ToString());
                TheFilter = (o, prefix) => (((ZADM_M016_P)o).dfctcda.ToString() ?? "").ToLower().Contains(prefix.ToLower());
                ASDefault1 = new AutoSuggestTextViewModel<dynamic>(MC.DefectList, TheFilter, SuggestedValue, "defect_type", "dfctdsc", true);
                ASDefault1.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M013_P)x).machinecode);
                TheFilter = (o, prefix) => (((ZADM_M013_P)o).machinecode ?? "").ToLower().Contains(prefix.ToLower());
                AS_Machine = new AutoSuggestTextViewModel<dynamic>(MC.MachineCodeList, TheFilter, SuggestedValue, "machinecode", true);
                AS_Machine.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToLower());
                AS_Unit = new AutoSuggestTextViewModel<dynamic>(MC.UOMList, TheFilter, SuggestedValue, "unit_code", true);
                AS_Unit.AutoSuggestVM.IsEmptyValueAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToLower());
                AS_Operator = new AutoSuggestTextViewModel<dynamic>(MC.ShiftIncharge, TheFilter, SuggestedValue, "EmpId", true);
                AS_Operator.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M042_P)x).shift);
                TheFilter = (o, prefix) => (((ADM_M042_P)o).shift ?? "").ToLower().Contains(prefix.ToLower());
                AS_Shift = new AutoSuggestTextViewModel<dynamic>(MC.Shift, TheFilter, SuggestedValue, "shift", true);
                AS_Shift.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName ?? "").Contains(prefix.ToLower());
                AS_ShiftIncharge = new AutoSuggestTextViewModel<dynamic>(MC.ShiftIncharge, TheFilter, SuggestedValue, "EmpId", true);
                AS_ShiftIncharge.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PPC_T003_Batch)x).barcode);
                TheFilter = (o, prefix) => (((PPC_T003_Batch)o).barcode ?? "").ToLower().Contains(prefix.ToLower());
                AS_Batch = new AutoSuggestTextViewModel<dynamic>(MC.BatchDetails, TheFilter, SuggestedValue, "barcode", true);
                AS_Batch.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASt_status = new AutoSuggestTextViewModel<dynamic>(MC.t_statusList, TheFilter, SuggestedValue, "t_display", true);
                ASt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M030_P)x).parametervalue);
                TheFilter = (o, prefix) => (((ADM_M030_P)o).value_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M030_P)o).parametervalue ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASGrade = new AutoSuggestTextViewModel<dynamic>(MC.GradeList, TheFilter, SuggestedValue, "parametervalue", true);
                ASGrade.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M042_P)x).shift);
                TheFilter = (o, prefix) => ((ADM_M042_P)o).shift.ToLower().Contains(prefix.ToLower());
                ASShift = new AutoSuggestTextViewModel<dynamic>(MC.Shift, TheFilter, SuggestedValue, "shift", true);
                ASShift.AutoSuggestVM.IsEmptyValueAllowed = true;

                MasterEntity.ToDate = DateTime.Now;

                var TempUnit_Id = (from o in MC.UOMList
                                   where o.unit_name == "PCS"
                                   select o).ToList();

                MasterEntity.unit_code = TempUnit_Id[0].unit_code;
                MasterEntity.ButtonAIsChecked = true;
                MasterEntity.ButtonBIsChecked = false;
                if (MasterEntity.ButtonAIsChecked == true)
                {
                    MasterEntity.sort_type = "MS";

                    if (MC.DefectList.Count > 0) //DefectCollection
                    {
                        SortingDetails = new ObservableCollection<ESO_T001_A>();
                        SortingDetails.Clear();

                        var DefectList = (from o in MC.DefectList
                                          where o.scope == "Manual"
                                          select o).ToList();
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M016_P)x).dfctdsc.ToString());
                        TheFilter = (o, prefix) => (((ZADM_M016_P)o).dfctcda.ToString() ?? "").ToLower().Contains(prefix.ToLower()) || (((ZADM_M016_P)o).dfctdsc ?? "").ToLower().Contains(prefix.ToLower());
                        AS_Defect = new AutoSuggestTextViewModel<dynamic>(DefectList, TheFilter, SuggestedValue, "defect_type", "dfctdsc", true);
                        AS_Defect.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                }
                DefaultValues();

                #endregion

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                MachineCollection = CollectionViewSource.GetDefaultView(MC.MachineCodeList);
                MachineCollection.Filter = new Predicate<object>(MachineFilter);
                StringListMachine = MC.MachineCodeList.Select(x => x.machinecode.ToString()).ToList();

                UOMCollection = CollectionViewSource.GetDefaultView(MC.UOMList);
                UOMCollection.Filter = new Predicate<object>(UOMFilter);
                StringListUOM = MC.UOMList.Select(x => x.unit_code.ToString()).ToList();

                var MainDefect = (from o in MC.DefectList where o.defect_type != "Sub Defect" select o).ToList();
                DefectListCollection = CollectionViewSource.GetDefaultView(MainDefect);
                DefectListCollection.Filter = new Predicate<object>(DefectFilter);
                StringListDefect = MainDefect.Select(x => x.dfctdsc.ToString()).ToList();

                var SubDefect = (from A in MC.DefectList where A.defect_type == "Sub Defect" select A).ToList();
                SubDefectCollection = CollectionViewSource.GetDefaultView(SubDefect);
                SubDefectCollection.Filter = new Predicate<object>(SubDefectFilter);
                StringListSubDefect = SubDefect.Select(X => X.dfctdsc.ToString()).ToList();

                ShiftCollection = CollectionViewSource.GetDefaultView(MC.Shift);
                ShiftCollection.Filter = new Predicate<object>(FilterShift);
                StringListShift = MC.Shift.Select(x => x.shift.ToString()).ToList();

                ShiftInchargeCollection = CollectionViewSource.GetDefaultView(MC.ShiftIncharge);
                ShiftInchargeCollection.Filter = new Predicate<object>(FilterShiftIncharge);
                StringListShiftIncharge = MC.ShiftIncharge.Select(x => x.EmpName.ToString()).ToList();

                BatchCollection = CollectionViewSource.GetDefaultView(MC.BatchDetails);
                BatchCollection.Filter = new Predicate<object>(BatchFilter);
                StringListBatch = MC.BatchDetails.Select(x => x.barcode.ToString()).ToList();

                SortybyCollection = CollectionViewSource.GetDefaultView(MC.SortBy);
                SortybyCollection.Filter = new Predicate<object>(FilterSortBy);
                StringListSortby = MC.SortBy.Select(x => x.sort_by.ToString()).ToList();

                machinecollection = CollectionViewSource.GetDefaultView(MC.Machine);
                machinecollection.Filter = new Predicate<object>(Filtermachine);
                StringListmachine = MC.Machine.Select(x => x.machinecode).ToList();

                DateTime now = DateTime.Now;
                DateTime lastDayLastMonth = new DateTime(now.Year, now.Month, 1);
                MasterEntity.FrmDate = lastDayLastMonth.AddDays(-60);
                MasterEntity.SortingDate = lastDayLastMonth.AddDays(-60);

                MasterEntity.ToDate = DateTime.Now;

                MasterEntity.unit_code = TempUnit_Id[0].unit_code;
                MasterEntity.ButtonAIsChecked = true;
                MasterEntity.ButtonBIsChecked = false;

                if (MasterEntity.ButtonAIsChecked == true)
                {
                    MasterEntity.sort_type = "MS";

                    if (MC.DefectList.Count > 0) //DefectCollection
                    {
                        SortingDetails = new ObservableCollection<ESO_T001_A>();
                        SortingDetails.Clear();

                        var DefectList = (from o in MC.DefectList where o.scope == "Manual" && o.defect_type != "Sub Defect" select o).ToList();
                        DefectListCollection = CollectionViewSource.GetDefaultView(DefectList);
                        DefectListCollection.Filter = new Predicate<object>(DefectFilter);

                    }
                }
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

        #region User Defined Function
        private void RemoveReferenceDocuments()
        {
            try
            {
                if (string.IsNullOrWhiteSpace(MasterEntity.barcode) == false)
                {
                    MC.BatchDetails.Remove(MC.BatchDetails.Single(s => s.barcode == MasterEntity.barcode));
                    var abc1 = (from o in MC.BatchDetails where o.doc_type == "PC" select o).ToList();
                    BatchCollection = CollectionViewSource.GetDefaultView(MC.BatchDetails);
                    BatchCollection.Filter = new Predicate<object>(BatchFilter);
                    StringListBatch = MC.BatchDetails.Select(x => x.barcode.ToString()).ToList();
                }
            }
            catch (Exception ex)
            {
            }

        }
        private void FilterDefectDataGrid()
        {
            try
            {
                if (DefectEntity != null && DefectEntity.Count > 0 && DefectEntity.Count > 0 && dgSelectedIndexItem >= 0)
                {
                    DefectDataGridCollection = CollectionViewSource.GetDefaultView(DefectEntity);
                    DefectDataGridCollection.Filter = adv => ((ESO_T001_B)adv).parent_defect.Equals(SortingDetails[dgSelectedIndexItem].defect_type);
                    DefectDataGridCollection.Refresh();
                }
            }
            catch (Exception ex)
            { }
        }
        private void DefaultValues()
        {
            MasterEntity.doc_cat = "SR";
            MasterEntity.doc_type = "SR";
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.t_status = "002";
            MasterEntity.doc_no = "";
            MasterEntity.active = true;
            MasterEntity.add_date = DateTime.Now;
            MasterEntity.entry_dt = System.DateTime.Now;
            MasterEntity.prod_dt = System.DateTime.Now;
            MasterEntity.ToDate = DateTime.Now;
            MasterEntity.ButtonAIsChecked = true;
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
            if (MasterEntity.ButtonAIsChecked == true)
            {
                MasterEntity.sort_type = "MS";
                ManualSortingChangeUpdate(true);
            }

        }
        private void ManualSortingChangeUpdate(bool check)
        {
            try
            {

                if (MasterEntity.ButtonAIsChecked == true)
                {
                    MasterEntity.sort_type = "MS";

                    if (MC.DefectList.Count > 0) //DefectCollection
                    {
                        SortingDetails = new ObservableCollection<ESO_T001_A>();
                        SortingDetails.Clear();
                        var DefectList1 = (from o in MC.DefectList
                                           where o.scope == "Manual" && o.defect_type != "Sub Defect"
                                           select o).ToList();
                        DefectListCollection = CollectionViewSource.GetDefaultView(DefectList1);
                        DefectListCollection.Filter = new Predicate<object>(DefectFilter);

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M016_P)x).dfctdsc.ToString());
                        TheFilter = (o, prefix) => (((ZADM_M016_P)o).dfctcda.ToString() ?? "").ToLower().Contains(prefix) || (((ZADM_M016_P)o).dfctdsc ?? "").ToLower().Contains(prefix);
                        AS_Defect = new AutoSuggestTextViewModel<dynamic>(DefectList1, TheFilter, SuggestedValue, "defect_type", "dfctdsc", true);
                        AS_Defect.AutoSuggestVM.IsEmptyValueAllowed = true;
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
        private void AutomaticSortingChangeUpdate(bool check)
        {
            if (MasterEntity.ButtonBIsChecked == true)
            {
                MasterEntity.sort_type = "AS";
                if (dgSelectedIndexItem > 0)
                {
                    SortingDetails[dgSelectedIndexItem].sort_by = (AppSessionState.comp_code == "1") ? "JAM" : "Ball Check Machine";
                }
                try
                {
                    if (MC.DefectList.Count > 0) //DefectCollection
                    {
                        SortingDetails = new ObservableCollection<ESO_T001_A>();
                        SortingDetails.Clear();

                        var DefectList1 = (from o in MC.DefectList
                                           where o.scope == "Automatic" && o.defect_type != "Sub Defect"
                                           select o).ToList();
                        DefectListCollection = CollectionViewSource.GetDefaultView(DefectList1);
                        DefectListCollection.Filter = new Predicate<object>(DefectFilter);

                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M016_P)x).dfctdsc);
                        TheFilter = (o, prefix) => (((ZADM_M016_P)o).dfctcda.ToString() ?? "").ToLower().Contains(prefix) || (((ZADM_M016_P)o).dfctdsc ?? "").Contains(prefix);
                        AS_Defect = new AutoSuggestTextViewModel<dynamic>(DefectList1, TheFilter, SuggestedValue, "defect_type", "dfctdsc", true);
                        AS_Defect.AutoSuggestVM.IsEmptyValueAllowed = true;
                        //----------------------------
                        SortingDetails.Add(new ESO_T001_A()
                        {
                            defect_type = DefectList1[0].dfctdsc,
                            rej_qty1 = 0,
                            rej_qty2 = 0,
                            total = 0,
                            sort_by = (AppSessionState.comp_code == "1") ? "JAM" : "Ball Check Machine",
                            id = 0,
                            active = true,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            add_by = AppSessionState.UserID,
                            posting_period = "1",
                            fin_year = "16-17",
                            t_status = "002"
                        });
                    }
                }
                catch
                { }
            }
        }
        private void InsertMachine(object InputValue, bool OverrideValue)
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
                        { POPUPEntityObject = MC.MachineCodeList.Where(x => x.machinecode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
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
                MasterEntity.machine_id = POPUPEntityObject.machine_id;


                if (MasterEntity.ButtonBIsChecked == true || MasterEntity.ButtonAIsChecked == true)
                {
                    RequestParameterData = "LoadMachineDetail" + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.machinecode + "!@" + Convert.ToDateTime(MasterEntity.prod_dt).ToString("MM/dd/yyyy") + "!@" + MasterEntity.sort_type;
                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ESO_T001_A>(MCTemp, RequestParameterData, "Sorting2", "Production", "LoadMachineDetail", 0, "");
                    MC.MasterEntity = MCTemp.MasterEntity;
                    MC.SortingDetails = MCTemp.SortingDetails;
                    MC.DefectEntity = MCTemp.DefectEntity;
                    if (MC.MasterEntity.Count > 0)
                    {
                        MasterEntity = MC.MasterEntity[0];
                        SortingDetails = MC.SortingDetails;
                        DefectEntity = MC.DefectEntity;
                        if (MasterEntity.sort_type == "MS")
                        {
                            MasterEntity.ButtonAIsChecked = true;
                            MasterEntity.ButtonBIsChecked = false;
                        }
                        else if (MasterEntity.sort_type == "AS")
                        {
                            MasterEntity.ButtonBIsChecked = true;
                            MasterEntity.ButtonAIsChecked = false;
                        }
                        isNewRecord = false;
                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Required";
                    showMessageService.Text = String.Format("Please Select Sorting Type", this.Title);
                    showMessageService.ShowMessage();
                }
            }
        }
        private void MachineColour(object InputValue, bool OverrideValue)
        {
            string RequestParameterData = "";
            if (MasterEntity.prod_dt != null)
            {
                RequestParameterData = "LoadMachineColour" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + Convert.ToDateTime(MasterEntity.prod_dt).ToString("MM/dd/yyyy");
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ESO_T001_A>(MCTemp, RequestParameterData, "Sorting2", "Production", "LoadMachineDetail", 0, "");

                MachineCollection = CollectionViewSource.GetDefaultView(MCTemp.MachineCodeList);
                MachineCollection.Filter = new Predicate<object>(MachineFilter);
                StringListMachine = MC.MasterEntity.Select(x => x.machine_id.ToString()).ToList();
            }
        }
        private void InsertUOM(object InputValue)
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
                        { POPUPEntityObject = MC.UOMList.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
        private void InsertDefList(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                        { POPUPEntityObject = MC.DefectList.Where(x => x.dfctdsc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    var InputValueIfExists = SortingDetails.Where(x => x.defect_type == POPUPEntityObject.dfctdsc).FirstOrDefault();
                    int IndexOfExistValue = SortingDetails.IndexOf(SortingDetails.Where(X => X.defect_type == POPUPEntityObject.dfctdsc).FirstOrDefault());
                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && SortingDetails.Count == dgSelectedIndexItem)
                    {
                        SortingDetails.Add(new ESO_T001_A()
                        {
                            id = 0,
                            rej_qty1 = 0,
                            rej_qty2 = 0,
                            total = 0,
                            defect_type = POPUPEntityObject.dfctdsc,
                            active = true,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            add_by = AppSessionState.UserID,
                            posting_period = "1",
                            fin_year = "15-16",
                            t_status = "002"

                        });
                        if (dgSelectedIndexItem != 0)
                        {
                            if (SortingDetails[0].sort_by != null)
                            {
                                SortingDetails[dgSelectedIndexItem - 1].sort_by = SortingDetails[0].sort_by;
                            }
                        }
                    }
                    else if (dgSelectedIndexItem >= 0 && SortingDetails.Count > dgSelectedIndexItem)
                    {
                        if (SortingDetails[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                        {
                            SortingDetails[dgSelectedIndexItem].defect_type = POPUPEntityObject.dfctdsc;

                            SortingDetails[dgSelectedIndexItem].location_Id = AppSessionState.location_Id;
                            SortingDetails[dgSelectedIndexItem].comp_code = AppSessionState.comp_code;
                            SortingDetails[dgSelectedIndexItem].add_by = AppSessionState.UserID;
                            SortingDetails[dgSelectedIndexItem].fin_year = "15-16";
                            SortingDetails[dgSelectedIndexItem].posting_period = "1";
                            SortingDetails[dgSelectedIndexItem].active = true;
                        }
                        else if (SortingDetails[dgSelectedIndexItem].defect_type != POPUPEntityObject.dfctdsc)
                        {
                            SortingDetails[dgSelectedIndexItem].defect_type = "";
                        }
                    }
                }

                ESO_T001_A newObj = new ESO_T001_A();
                for (int i = SortingDetails.Count - 1; i >= 0; i--)
                {
                    bool xx = SortingDetails[i].ComparePropertiesTo(newObj);
                    if (SortingDetails[i].ComparePropertiesTo(newObj) == true && SortingDetails.Count > 1)
                    {
                        SortingDetails.RemoveAt(i);
                        if (SortingDetails.Count == 0)
                        {
                            SortingDetails.Add(newObj);
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
        private void InsertDefect(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M016_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {

                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DefectList.Where(x => x.dfctdsc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }

                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M016_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    //var InputValueIfExists = TaskDetailsEntity.Where(X => X.title == POPUPEntityObject.title).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    //int IndexOfExistValue = TaskDetailsEntity.IndexOf(TaskDetailsEntity.Where(X => X.title == POPUPEntityObject.title).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.
                    List<ESO_T001_B> temp = new List<ESO_T001_B>();
                    temp = DefectEntity.ToList();
                    foreach (var o in DefectEntity)
                    {
                        if (o.parent_defect != SortingDetails[dgSelectedIndexItem].defect_type)
                        {
                            temp.Remove(o);
                        }
                    }

                    if (NewRow == true && (AllowDuplicate == true) && temp.Count == dgSelectedIndexDefect)
                    {
                        DefectEntity.Add(new ESO_T001_B()
                        {
                            id = 0,
                            rej_qty1 = 0,
                            rej_qty2 = 0,
                            total = 0,
                            defect_type = POPUPEntityObject.dfctdsc,
                            parent_defect = SortingDetails[dgSelectedIndexItem].defect_type,
                            deletion_id = DateTime.Now.Ticks.GetHashCode(),
                            active = true,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            add_by = AppSessionState.UserID,
                            posting_period = "1",
                            fin_year = "15-16",
                            t_status = "002"
                        });
                    }
                    else if (dgSelectedIndexDefect >= 0 && DefectEntity.Count > dgSelectedIndexDefect) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        foreach (var a in DefectEntity)
                        {
                            if (temp[dgSelectedIndexDefect].defect_type == a.defect_type && a.id == 0)
                            {
                                a.defect_type = POPUPEntityObject.dfctdsc;
                                a.parent_defect = SortingDetails[dgSelectedIndexItem].defect_type;
                                a.deletion_id = DateTime.Now.Ticks.GetHashCode();
                                a.active = true;
                                a.location_Id = AppSessionState.location_Id;
                                a.comp_code = AppSessionState.comp_code;
                                a.add_by = AppSessionState.UserID;
                                a.posting_period = "1";
                                a.fin_year = "15-16";
                                a.t_status = "002";
                                a.rej_qty1 = 0;
                                a.rej_qty2 = 0;
                                a.total = 0;
                            }
                        }
                    }
                }
                #region Clear Empty Row
                ESO_T001_B newObj = new ESO_T001_B();
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
        private void InsertSortBy(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ESO_T001Sort POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.SortBy.Where(x => x.sort_by.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ESO_T001Sort>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = SortingDetails.Where(x => x.sort_by == POPUPEntityObject.sort_by).FirstOrDefault();
                var IndexOfExistValue = SortingDetails.IndexOf(SortingDetails.Where(X => X.sort_by == POPUPEntityObject.sort_by).FirstOrDefault());
                if (dgSelectedIndexItem >= 0 && SortingDetails.Count > dgSelectedIndexItem)
                {
                    if (SortingDetails[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        SortingDetails[dgSelectedIndexItem].sort_by = POPUPEntityObject.sort_by;
                    }
                    else if (SortingDetails[dgSelectedIndexItem].sort_by != POPUPEntityObject.sort_by)
                    {
                        SortingDetails[dgSelectedIndexItem].sort_by = POPUPEntityObject.sort_by;
                    }
                }
            }

            ESO_T001_A newObj = new ESO_T001_A();
            for (int i = SortingDetails.Count - 1; i >= 0; i--)
            {
                bool xx = SortingDetails[i].ComparePropertiesTo(newObj);
                if (SortingDetails[i].ComparePropertiesTo(newObj) == true && SortingDetails.Count > 1)
                {
                    SortingDetails.RemoveAt(i);
                    if (SortingDetails.Count == 0)
                    {
                        SortingDetails.Add(newObj);
                    }
                }
            }
        }
        private void Insertmachine(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ESO_T001Sort POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Machine.Where(x => x.machinecode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ESO_T001Sort>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = DefectEntity.Where(x => x.machinecode == POPUPEntityObject.machinecode).FirstOrDefault();
                var IndexOfExistValue = DefectEntity.IndexOf(DefectEntity.Where(X => X.machinecode == POPUPEntityObject.machinecode).FirstOrDefault());
                if (dgSelectedIndexDefect >= 0 && DefectEntity.Count > dgSelectedIndexDefect)
                {
                    if (DefectEntity[dgSelectedIndexDefect].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        DefectEntity[dgSelectedIndexDefect].machinecode = POPUPEntityObject.machinecode;
                    }
                    else if (DefectEntity[dgSelectedIndexDefect].machinecode != POPUPEntityObject.machinecode)
                    {
                        DefectEntity[dgSelectedIndexDefect].machinecode = POPUPEntityObject.machinecode;
                    }
                }
            }

            ESO_T001_B newObj = new ESO_T001_B();
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
        private void InsertOperators(object InputValue)
        {
            string Request = "";
            ADM_M024_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ShiftIncharge.Where(x => x.EmpName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
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
                MasterEntity.OperatorName = POPUPEntityObject.EmpName;
                MasterEntity.EmpId = POPUPEntityObject.EmpId;
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
                        { POPUPEntityObject = MC.Shift.Where(x => x.shift.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
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
        private void InsertShiftIncharge(object InputValue)
        {
            string Request = "";
            ADM_M024_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ShiftIncharge.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
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
                MasterEntity.shift_incharge = POPUPEntityObject.EmpId;
                MasterEntity.ShiftInchargeName = POPUPEntityObject.EmpName;
            }
        }
        private void InsertBatchDetails(object InputValue)
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
                                    MasterEntity.counter_qty = POPUPEntityObject.counter_q;
                                    MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                                    MasterEntity.ItemName = POPUPEntityObject.ItemName;
                                    MasterEntity.machinecode = POPUPEntityObject.machinecode;
                                    MasterEntity.machine_id = POPUPEntityObject.machine_id;
                                    MasterEntity.wc_code = POPUPEntityObject.wc_code;
                                    MasterEntity.prod_dt = POPUPEntityObject.prod_date;
                                    MasterEntity.uc_qty = POPUPEntityObject.quantity;
                                    MasterEntity.shift_incharge = POPUPEntityObject.shift_incharge;
                                    MasterEntity.ShiftInchargeName = POPUPEntityObject.ShiftInchargeName;
                                    MasterEntity.shift = POPUPEntityObject.shift1;
                                    MasterEntity.unit_code = POPUPEntityObject.unit_code;
                                    MasterEntity.OperatorName = POPUPEntityObject.operatornm;
                                    MasterEntity.EmpId = POPUPEntityObject.m_operator;
                                    MasterEntity.order_no = POPUPEntityObject.doc_no;
                                    MasterEntity.grade = POPUPEntityObject.grade;
                                    MasterEntity.counter_remark = POPUPEntityObject.counter_remark;

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
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Entered Barcode is Used.\n Press OK To Re-Sacn Barcode OR Press Cancel To Cancel Re-Scan", this.Title);
                            showMessageService.ShowMessage();

                            if (showMessageService.ShowMessage() == DialogResult.Ok)
                            {
                                string Request1 = "RescanBarcode" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id + "!@" + Request;
                                MCTemp5 = repository_MCTemp5.GetDataWithReturnDomainObject<MultipleContext_ESO_T001_A>(MCTemp5, Request1, "Sorting2", "Production", "LoadInitialData", 0, "");

                                if (MCTemp5.RescanBarcode != null)
                                {
                                    if (MCTemp5.RescanBarcode.Count > 0)
                                    {
                                        MasterEntity = MCTemp5.RescanBarcode[0];
                                        SODetails = MCTemp5.SODetails;
                                        DefaultValues();
                                        MasterEntity.t_status = "021";
                                    }
                                    else
                                    {
                                        showMessageService.ButtonSetup = DialogButton.OkCancel;
                                        showMessageService.Caption = "Message";
                                        showMessageService.Text = String.Format("Entered Barcode is Invalid", this.Title);
                                        showMessageService.ShowMessage();
                                    }
                                }
                                else
                                {
                                    showMessageService.ButtonSetup = DialogButton.OkCancel;
                                    showMessageService.Caption = "Message";
                                    showMessageService.Text = String.Format("Entered Barcode is Invalid", this.Title);
                                    showMessageService.ShowMessage();
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
                    MasterEntity.counter_qty = POPUPEntityObject.counter_q;
                    MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                    MasterEntity.ItemName = POPUPEntityObject.ItemName;
                    MasterEntity.machinecode = POPUPEntityObject.machinecode;
                    MasterEntity.machine_id = POPUPEntityObject.machine_id;
                    MasterEntity.wc_code = POPUPEntityObject.wc_code;
                    MasterEntity.prod_dt = POPUPEntityObject.prod_date;
                    MasterEntity.uc_qty = POPUPEntityObject.quantity;
                    MasterEntity.shift_incharge = POPUPEntityObject.shift_incharge;
                    MasterEntity.ShiftInchargeName = POPUPEntityObject.ShiftInchargeName;
                    MasterEntity.shift = POPUPEntityObject.shift1;
                    MasterEntity.unit_code = POPUPEntityObject.unit_code;
                    MasterEntity.OperatorName = POPUPEntityObject.operatornm;
                    MasterEntity.EmpId = POPUPEntityObject.m_operator;
                    MasterEntity.order_no = POPUPEntityObject.doc_no;
                    MasterEntity.grade = POPUPEntityObject.grade;
                    MasterEntity.counter_remark = POPUPEntityObject.counter_remark;
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
                var msg = new NotificationMessage("ESO_T001_VM_2");
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            #endregion
            catch (Exception ex) { }
        }
        private void DeleteDataGridRow_Defect(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (SortingDetails.Count > i && SortingDetails[dgSelectedIndexItem].id == 0)
                {
                    SortingDetails.RemoveAt(i);
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
        private void DeleteDefectEntityRow(object InputValue)
        {
            try
            {
                ESO_T001_B POPUPEntityObject = null;
                if (InputValue != null && ((IEnumerable)InputValue).Cast<ESO_T001_B>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ESO_T001_B>().ToList()[0];
                }
                if (DefectEntity.Count > 0)
                {
                    List<ESO_T001_B> temp = DefectEntity.ToList();
                    foreach (var a in temp)
                    {
                        if (a.id == 0 && a.deletion_id == POPUPEntityObject.deletion_id)
                        {
                            DefectEntity.Remove(a);
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
        private void Load()
        {
            if (MasterEntity.FrmDate != null && MasterEntity.ToDate != null)
            {
                string Request = "LoadFromDateToDate" + "!@" + MasterEntity.FrmDate.ToString() + "!@" + MasterEntity.ToDate.ToString() + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ESO_T001_A>(MCTemp, Request, "Sorting2", "Production", "", 0, "FeedBack ");
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
        private void LoadFromFilters()
        {
            try
            {
                if (Validation1() ==true)
                {
                    string RequestParameter = "LoadFromFilters" + "!@" + MasterEntity.EmpId1 + "!@" + MasterEntity.qc_person1 + "!@" + MasterEntity.Fromdt.ToString() + "!@" + MasterEntity.Todt.ToString() + "!@" + MasterEntity.con_no + "!@" + MasterEntity.sshift + "!@" + MasterEntity.machine + "!@" + MasterEntity.item + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id;
                    MCTemp1 = repository_MCTemp1.GetDataWithReturnDomainObject<MultipleContext_ESO_T001_A>(MCTemp1, RequestParameter, "Sorting2", "Production", "LoadInitialData", 0, "");

                    FlipGridData = MCTemp1.DocumentDataFlipGrid.ToList();
                    DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                    DataGridCollection.Filter = new Predicate<object>(Filter);
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
        private bool Validation()
        {
            //if (SortingDetails.Count < 1)
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Message";
            //    showMessageService.Text = String.Format("Please Select Defect...");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            if (dgSelectedIndexItem != -1)
            {
                foreach (var o in SortingDetails)
                {
                    if (o.sort_by == null || o.sort_by == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Please Enter Sort By");
                        showMessageService.ShowMessage();
                        return false;
                    }
                    //if (o.defect_type == null || o.defect_type == "")
                    //{
                    //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    //    showMessageService.ButtonSetup = DialogButton.Ok;
                    //    showMessageService.Caption = "Message";
                    //    showMessageService.Text = String.Format("Please Enter Defect");
                    //    showMessageService.ShowMessage();
                    //    return false;
                    //}
                }
            }
            if (MasterEntity.machinecode == null || MasterEntity.machinecode == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Machine Code... ");
                showMessageService.ShowMessage();
                return false;
            }

            if (MasterEntity.unit_code == null || MasterEntity.unit_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Unit... ");
                showMessageService.ShowMessage();
                return false;
            }

            return true;
        }

        private bool Validation1()
        {
            if (MasterEntity.Fromdt == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select From Date... ");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.Todt == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select To Date... ");
                showMessageService.ShowMessage();
                return false;
            }
            return true;
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            ESO_T001Flip ParameterEntityObject = null;
            MasterEntity = new ESO_T001();
            try
            {
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null)
                {
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterObject;
                    isNewRecord = false;
                }
                else if (((IEnumerable)ParameterObject).Cast<ESO_T001Flip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ESO_T001Flip>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.doc_no;
                    isNewRecord = false;
                }
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ESO_T001_A>(MCTemp, Request, "Sorting2", "Production", "LoadDocumentByDocumentNumber", 0, "");
                MC.MasterEntity = MCTemp.MasterEntity;
                MC.SortingDetails = MCTemp.SortingDetails;
                MC.DefectEntity = MCTemp.DefectEntity;
                SODetails = MCTemp.SODetails;
                SelectedTabControlIndex = 0;
                cal();
                if (MasterEntity != null)
                {
                    MasterEntity = MC.MasterEntity[0];
                    SortingDetails = MC.SortingDetails;
                    DefectEntity = MC.DefectEntity;
                    if (MasterEntity.sort_type == "AS")
                    {
                        MasterEntity.ButtonBIsChecked = true;
                        MasterEntity.ButtonAIsChecked = false;
                    }
                    else if (MasterEntity.sort_type == "MS")
                    {
                        MasterEntity.ButtonBIsChecked = false;
                        MasterEntity.ButtonAIsChecked = true;
                    }
                }
                SetPopupSuggestionDataAfterLoad();
                MasterEntity.ts_code = ts_code_vm;
                var msg = new NotificationMessage("ESO_T001_VM_2");
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
                if (MasterEntity.XmlDataDocument_ESO_T001_A != null)
                {
                    SortingDetails.Clear();
                    SortingDetails = (ObservableCollection<ESO_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ESO_T001_A, MC.SortingDetails);
                }
                else
                {
                    MC.SortingDetails = new ObservableCollection<ESO_T001_A>();
                }
                if (MasterEntity.XmlDataDocument_ESO_T001FLIP != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<ESO_T001Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ESO_T001FLIP, MC.DocumentDataFlipGrid);
                    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                    DataGridCollection.Refresh();
                    DataGridCollection.SortDescriptions.Add(new SortDescription("doc_no", ListSortDirection.Descending));
                    RemoveReferenceDocuments();
                }

                if (MasterEntity.XmlDataDocument_ESO_T001FLIP != null && MasterEntity.XmlDataDocument_ESO_T001_B != null)
                {
                    DefectEntity.Clear();
                    DefectEntity = (ObservableCollection<ESO_T001_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ESO_T001_B, MC.DefectEntity);
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
        private void SetPopupSuggestionDataAfterLoad()
        {
            AS_Machine.AutoSuggestVM.Suggestion = MC.MachineCodeList.Find(x => x.machinecode == MasterEntity.machinecode);

            AS_Unit.AutoSuggestVM.Suggestion = MC.UOMList.Find(x => x.unit_code == MasterEntity.unit_code);

            AS_Operator.AutoSuggestVM.Suggestion = MC.ShiftIncharge.Find(x => x.EmpId == MasterEntity.EmpId);

            AS_Shift.AutoSuggestVM.Suggestion = MC.Shift.Find(x => x.shift == MasterEntity.shift);

            AS_ShiftIncharge.AutoSuggestVM.Suggestion = MC.ShiftIncharge.Find(x => x.EmpId == MasterEntity.shift_incharge);

            AS_Batch.AutoSuggestVM.Suggestion = MC.BatchDetails.Find(x => x.barcode == MasterEntity.barcode);
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
       
        #endregion

        #region Command Actions
        protected override void OnSaveAction(InquiryActionResult<ESO_T001> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.editby = AppSessionState.UserID;
                    MasterEntity.XmlDataDocument_ESO_T001_A = obj.ObjectToXML(SortingDetails);
                    MasterEntity.XmlDataDocument_ESO_T001_B = obj.ObjectToXML(DefectEntity);
                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ESO_T001>(MasterEntity, "Sorting2", "Production");
                        RemoveReferenceDocuments();
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<ESO_T001>(MasterEntity, "Sorting2", "Production");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");

                    if (MasterEntity.doc_no != null || MasterEntity.doc_no != " ")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();
                    }

                    if (MasterEntity.sort_type == "AS")
                    {
                        MasterEntity.ButtonBIsChecked = true;
                        MasterEntity.ButtonAIsChecked = false;
                    }
                    else if (MasterEntity.sort_type == "MS")
                    {
                        MasterEntity.ButtonBIsChecked = false;
                        MasterEntity.ButtonAIsChecked = true;
                    }
                    isNewRecord = false;
                    cal();
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
        protected override void OnCreateAction(InquiryActionResult<ESO_T001> result)
        {
            var temp = MasterEntity.prod_dt;
            var tempEntrydt = MasterEntity.entry_dt;
            isNewRecord = true;
            MasterEntity = new ESO_T001();
            SODetails.Clear();
            SortingDetails = new ObservableCollection<ESO_T001_A>();
            DefectEntity = new ObservableCollection<ESO_T001_B>();
            MasterEntity.ValidateAsync().Wait();
            DefaultValues();
            MasterEntity.ButtonAIsChecked = true;
            MasterEntity.ButtonBIsChecked = false;
            if (MasterEntity.ButtonAIsChecked == true)
            {
                MasterEntity.sort_type = "MS";
                ManualSortingChangeUpdate(true);
                // DefectListCollection.Refresh();      
            }
            MasterEntity.unit_code = "PICs";
            MasterEntity.prod_dt = temp;
            MasterEntity.entry_dt = tempEntrydt;
            var msg = new NotificationMessage("ESO_T001_VM_2");
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        protected override void OnRemoveAction(InquiryActionResult<ESO_T001> result)
        {
            try
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
                    string response = repository.Delete(MasterEntity.doc_no, "Sorting2", "Production");
                    MasterEntity = new ESO_T001();
                    SortingDetails = new ObservableCollection<ESO_T001_A>();

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
        protected override void OnDiscardAction(InquiryActionResult<ESO_T001> result)
        {
        }
        protected override void OnFevoriteAction(InquiryActionResult<ESO_T001> result)
        {
        }
        protected override void OnFlipAction(InquiryActionResult<ESO_T001> result)
        {
        }
        protected override void OnHelpAction(InquiryActionResult<ESO_T001> result)
        {
        }
        protected override void OnPrintAction(InquiryActionResult<ESO_T001> result)
        {

        }
        protected override void OnDocumentAction()
        {

        }
        protected override void OnRefreshCommand(InquiryActionResult<ESO_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ESO_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ESO_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ESO_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ESO_T001> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters

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

        #region Filters For UOM
        private string _filterStringUOM;
        private void FilterCollectionUOM()
        {
            if (_UOMCollection != null)
            {
                _UOMCollection.Refresh();
            }
        }
        public string FilterStringUOM
        {
            get { return _filterStringUOM; }
            set
            {
                _filterStringUOM = value;
                RaisePropertyChanged("FilterStringUOM");
                FilterCollectionUOM();
            }
        }
        public bool UOMFilter(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringUOM))
                {
                    return ((data.unit_code != null) && data.unit_code.ToLower().Contains(_filterStringUOM.ToLower()));
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
            if (_DefectListCollection != null)
            {
                _DefectListCollection.Refresh();
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
                    return ((data.dfctdsc != null) && data.dfctdsc.ToLower().Contains(_filterStringDefect.ToLower())) ||
                           ((data.dfctcda != null) && data.dfctcda.ToString().ToLower().Contains(_filterStringDefect.ToLower())); ;
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filters For Sub Defect
        private string _filterStringSubDefect;
        public string FilterStringSubDefect
        {
            get { return _filterStringSubDefect; }
            set
            {
                _filterStringSubDefect = value;
                RaisePropertyChanged("filterStringSubDefect");
                FilterCollectionSubDefect();
            }
        }
        private void FilterCollectionSubDefect()
        {
            if (_SubDefectCollection != null)
            {
                _SubDefectCollection.Refresh();
            }
        }

        public bool SubDefectFilter(object obj)
        {
            var data = obj as ZADM_M016_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringSubDefect))
                {
                    return ((data.dfctdsc != null) && data.dfctdsc.ToLower().Contains(_filterStringSubDefect.ToLower())) ||
                           ((data.dfctcda != null) && data.dfctcda.ToString().ToLower().Contains(_filterStringSubDefect.ToLower())); ;
                }
                return true;
            }
            return false;
        }
        #endregion

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
            if (_dataGridCollection != null)
            {
                _dataGridCollection.Refresh();
            }
        }
        public bool Filter(object obj)
        {
            var data = obj as ESO_T001Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.shift != null && data.shift.ToString().ToLower().Contains(_filterString.ToLower())) ||
                           (data.shift_incharge != null && data.shift_incharge.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter string Barcode
        private string _filterString_Barcode;
        public string filterString_Barcode
        {
            get { return _filterString_Barcode; }
            set
            {
                _filterString_Barcode = value;
                RaisePropertyChanged("filterString_Barcode");
                FilterCollectionBarcode();
            }
        }
        private void FilterCollectionBarcode()
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
                if (!string.IsNullOrEmpty(_filterString_Barcode))
                {
                    return (data.batch_no != null && data.batch_no.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                        (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                        (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                        (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                        (data.prod_date != null && data.prod_date.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                        (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_filterString_Barcode.ToLower())) ||
                           (data.barcode != null && data.barcode.ToString().ToLower().Contains(_filterString_Barcode.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter string Operator
        private string _FilterStringOperator;
        public string FilterStringOperator
        {
            get { return _FilterStringOperator; }
            set
            {
                _FilterStringOperator = value;
                RaisePropertyChanged("FilterStringOperator");
                FilterCollectionOperator();
            }
        }
        private void FilterCollectionOperator()
        {
            if (_OperatorCollection != null)
            {
                _OperatorCollection.Refresh();
            }
        }
        public bool FilterOperator(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringOperator))
                {
                    return (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_FilterStringOperator.ToLower())) ||
                           (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_FilterStringOperator.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter string Shift Incharge
        private string _FilterStringShiftIncharge;
        public string FilterStringShiftIncharge
        {
            get { return _FilterStringShiftIncharge; }
            set
            {
                _FilterStringShiftIncharge = value;
                RaisePropertyChanged("FilterStringShiftIncharge");
                FilterCollectionShiftIncharge();
            }
        }
        private void FilterCollectionShiftIncharge()
        {
            if (_ShiftInchargeCollection != null)
            {
                _ShiftInchargeCollection.Refresh();
            }
        }
        public bool FilterShiftIncharge(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterStringShiftIncharge))
                {
                    return (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_FilterStringShiftIncharge.ToLower())) ||
                           (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_FilterStringShiftIncharge.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter string Shift
        private string _FilterStringShift;
        public string FilterStringShift
        {
            get { return _FilterStringShift; }
            set
            {
                _FilterStringShift = value;
                RaisePropertyChanged("FilterStringShift");
                FilterCollectionShift();
            }
        }
        private void FilterCollectionShift()
        {
            if (_ShiftCollection != null)
            {
                _ShiftCollection.Refresh();
            }
        }
        public bool FilterShift(object obj)
        {
            var data = obj as ADM_M042_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.shift != null && data.shift.ToString().ToLower().Contains(_FilterStringShift.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter for Sort by

        private string _FilterStringSortBy;
        public string FilterStringSoryBy
        {
            get { return _FilterStringSortBy; }
            set
            {
                _FilterStringSortBy = value;
                RaisePropertyChanged("FilterStringSoryBy");
                FilterCollectionSortBy();
            }
        }
        private void FilterCollectionSortBy()
        {
            if (_SortybyCollection != null)
            {
                _SortybyCollection.Refresh();
            }
        }
        public bool FilterSortBy(object obj)
        {
            var data = obj as ESO_T001Sort;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringSoryBy))
                {
                    return (data.sort_by != null && data.sort_by.ToString().ToLower().Contains(_FilterStringSortBy.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region  Filter For machine

        private string _FilterStringmachine;
        public string FilterStringmachine
        {
            get { return _FilterStringmachine; }
            set
            {
                _FilterStringmachine = value;
                RaisePropertyChanged("FilterStringmachine");
                FilterCollectionmachine();
            }
        }
        private void FilterCollectionmachine()
        {
            if (_machinecollection != null)
            {
                _machinecollection.Refresh();
            }
        }
        public bool Filtermachine(object obj)
        {
            var data = obj as ESO_T001Sort;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringSoryBy))
                {
                    return (data.machinecode != null && data.machinecode.ToString().ToLower().Contains(_FilterStringmachine.ToLower()));
                }
                return true;
            }
            return false;
        }

        
        #endregion
        #endregion
    }
}
