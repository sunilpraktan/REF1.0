using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.BusinessEntity.QMS;
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
using Reflection.Presentation.Common;

namespace Reflection.Modules.QMS.ViewModels
{
    public class QMS_T002_VM : WorkspaceViewModel<QMS_T002>
    {
        int srno = 1;
        bool isNewRecord = true;
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        WebServiceRepository<QMS_T002> repository = new WebServiceRepository<QMS_T002>();
        WebServiceRepository<MultipleContext_QMS_T002> repository_MC = new WebServiceRepository<MultipleContext_QMS_T002>();
        WebServiceRepository<MultipleContext_QMS_T002> repository_MCTemp = new WebServiceRepository<MultipleContext_QMS_T002>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(QMS_T002_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASDefault2 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault2
        {
            get { return _ASDefault2; }
            set
            {
                if (_ASDefault2 != value)
                {
                    _ASDefault2 = value; RaisePropertyChanged("ASDefault2");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDefault3 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault3
        {
            get { return _ASDefault3; }
            set
            {
                if (_ASDefault3 != value)
                {
                    _ASDefault3 = value; RaisePropertyChanged("ASDefault3");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASParty { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASParty
        {
            get { return _ASParty; }
            set
            {
                if (_ASParty != value)
                {
                    _ASParty = value; RaisePropertyChanged("ASParty");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASSono { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSono
        {
            get { return _ASSono; }
            set
            {
                if (_ASSono != value)
                {
                    _ASSono = value; RaisePropertyChanged("ASSono");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASGRNDoc { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGRNDoc
        {
            get { return _ASGRNDoc; }
            set
            {
                if (_ASGRNDoc != value)
                {
                    _ASGRNDoc = value; RaisePropertyChanged("ASGRNDoc");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASRefDoc { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRefDoc
        {
            get { return _ASRefDoc; }
            set
            {
                if (_ASRefDoc != value)
                {
                    _ASRefDoc = value; RaisePropertyChanged("ASRefDoc");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASLab { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLab
        {
            get { return _ASLab; }
            set
            {
                if (_ASLab != value)
                {
                    _ASLab = value; RaisePropertyChanged("ASLab");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAccCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccCode
        {
            get { return _ASAccCode; }
            set
            {
                if (_ASAccCode != value)
                {
                    _ASAccCode = value; RaisePropertyChanged("ASAccCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAccScope { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccScope
        {
            get { return _ASAccScope; }
            set
            {
                if (_ASAccScope != value)
                {
                    _ASAccScope = value; RaisePropertyChanged("ASAccScope");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASGridTestCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGridTestCode
        {
            get { return _ASGridTestCode; }
            set
            {
                if (_ASGridTestCode != value)
                {
                    _ASGridTestCode = value; RaisePropertyChanged("ASGridTestCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASParaValue { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASParaValue
        {
            get { return _ASParaValue; }
            set
            {
                if (_ASParaValue != value)
                {
                    _ASParaValue = value; RaisePropertyChanged("ASParaValue");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASRangeUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRangeUnit
        {
            get { return _ASRangeUnit; }
            set
            {
                if (_ASRangeUnit != value)
                {
                    _ASRangeUnit = value; RaisePropertyChanged("ASRangeUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASInstCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASInstCode
        {
            get { return _ASInstCode; }
            set
            {
                if (_ASInstCode != value)
                {
                    _ASInstCode = value; RaisePropertyChanged("ASInstCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASLabCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLabCode
        {
            get { return _ASLabCode; }
            set
            {
                if (_ASLabCode != value)
                {
                    _ASLabCode = value; RaisePropertyChanged("ASLabCode");
                }
            }
        }


        private AutoSuggestTextViewModel<dynamic> _ASAssignedTo { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAssignedTo
        {
            get { return _ASAssignedTo; }
            set
            {
                if (_ASAssignedTo != value)
                {
                    _ASAssignedTo = value; RaisePropertyChanged("ASAssignedTo");
                }
            }
        }


        private AutoSuggestTextViewModel<dynamic> _ASResolutionUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASResolutionUnit
        {
            get { return _ASResolutionUnit; }
            set
            {
                if (_ASResolutionUnit != value)
                {
                    _ASResolutionUnit = value; RaisePropertyChanged("ASResolutionUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASLeastCountUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLeastCountUnit
        {
            get { return _ASLeastCountUnit; }
            set
            {
                if (_ASLeastCountUnit != value)
                {
                    _ASLeastCountUnit = value; RaisePropertyChanged("ASLeastCountUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAccuracyDownUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccuracyDownUnit
        {
            get { return _ASAccuracyDownUnit; }
            set
            {
                if (_ASAccuracyDownUnit != value)
                {
                    _ASAccuracyDownUnit = value; RaisePropertyChanged("ASAccuracyDownUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAccuracyUpUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccuracyUpUnit
        {
            get { return _ASAccuracyUpUnit; }
            set
            {
                if (_ASAccuracyUpUnit != value)
                {
                    _ASAccuracyUpUnit = value; RaisePropertyChanged("ASAccuracyUpUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASUpperRangeUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUpperRangeUnit
        {
            get { return _ASUpperRangeUnit; }
            set
            {
                if (_ASUpperRangeUnit != value)
                {
                    _ASUpperRangeUnit = value; RaisePropertyChanged("ASUpperRangeUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASLowerRangeUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASLowerRangeUnit
        {
            get { return _ASLowerRangeUnit; }
            set
            {
                if (_ASLowerRangeUnit != value)
                {
                    _ASLowerRangeUnit = value; RaisePropertyChanged("ASLowerRangeUnit");
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
                    if (SourceName == "ItemCode")
                    { ASDefault = ASAccCode; }
                    else if (SourceName == "ItemScope")
                    { ASDefault = ASAccScope; }
                    else if (SourceName == "para_value")
                    { ASDefault1 = ASParaValue; }
                    else if (SourceName == "inst_code")
                    { ASDefault3 = ASInstCode; }
                    else if (SourceName == "range_unit")
                    { ASDefault3 = ASRangeUnit; }
                    else if (SourceName == "lower_range_unit")
                    { ASDefault3 = ASLowerRangeUnit; }
                    else if (SourceName == "upper_range_unit")
                    { ASDefault3 = ASUpperRangeUnit; }
                    else if (SourceName == "accuracy_up_unit")
                    { ASDefault3 = ASAccuracyUpUnit; }
                    else if (SourceName == "accuracy_down_unit")
                    { ASDefault3 = ASAccuracyDownUnit; }
                    else if (SourceName == "least_count_unit")
                    { ASDefault3 = ASLeastCountUnit; }
                    else if (SourceName == "resolution_unit")
                    { ASDefault3 = ASResolutionUnit; }
                    else if (SourceName == "lab_code")
                    { ASDefault2 = ASLabCode; }
                    else if (SourceName == "assigned_to")
                    { ASDefault2 = ASAssignedTo; }
                }
            }
        }

        #endregion

        #region Declaration

        private QMS_T002 _MasterEntity;
        public QMS_T002 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged("MasterEntity");
                }
            }
        }

        private ObservableCollection<QMS_T002_A> _ItemEntity;
        public ObservableCollection<QMS_T002_A> ItemEntity
        {
            get { return _ItemEntity; }
            set
            {
                if (ItemEntity != value)
                {
                    _ItemEntity = value;
                    ItemEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("ItemEntity");
                }
            }
        }

        private ObservableCollection<QMS_T002_B> _InstrumentEntity;
        public ObservableCollection<QMS_T002_B> InstrumentEntity
        {
            get { return _InstrumentEntity; }
            set
            {
                if (_InstrumentEntity != value)
                {
                    _InstrumentEntity = value;
                    InstrumentEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForInstrument);
                    RaisePropertyChanged("InstrumentEntity");
                }
            }
        }

        private ObservableCollection<QMS_T002_C> _TestEntity;
        public ObservableCollection<QMS_T002_C> TestEntity
        {
            get { return _TestEntity; }
            set
            {
                if (TestEntity != value)
                {
                    _TestEntity = value;
                    TestEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTest);
                    RaisePropertyChanged("TestEntity");
                }
            }
        }

        private ObservableCollection<QMS_T002_D> _ParameterEntity;
        public ObservableCollection<QMS_T002_D> ParameterEntity
        {
            get { return _ParameterEntity; }
            set
            {
                if (ParameterEntity != value)
                {
                    _ParameterEntity = value;
                    ParameterEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForParameter);
                    RaisePropertyChanged("ParameterEntity");
                }
            }
        }

        private int _dgSelectedIndexItem;
        public int dgSelectedIndexItem
        {
            get { return _dgSelectedIndexItem; }
            set
            {
                if (dgSelectedIndexItem != value)
                {
                    _dgSelectedIndexItem = value;
                    RaisePropertyChanged("dgSelectedIndexItem");
                }
            }
        }

        private int _dgSelectedIndexPara;
        public int dgSelectedIndexPara
        {
            get { return _dgSelectedIndexPara; }
            set
            {
                if (_dgSelectedIndexPara != value)
                {
                    _dgSelectedIndexPara = value;
                    FilterParaValueCollection();
                    RaisePropertyChanged("dgSelectedIndexPara");
                }
            }
        }

        private int _dgSelectedIndexInst;
        public int dgSelectedIndexInst
        {
            get { return _dgSelectedIndexInst; }
            set
            {
                if (_dgSelectedIndexInst != value)
                {
                    _dgSelectedIndexInst = value;
                    FilterTestDataGrid();
                    RaisePropertyChanged("dgSelectedIndexInst");
                }
            }
        }

        private int _dgSelectedIndexTest;
        public int dgSelectedIndexTest
        {
            get { return _dgSelectedIndexTest; }
            set
            {
                if (_dgSelectedIndexTest != value)
                {
                    _dgSelectedIndexTest = value;
                    RaisePropertyChanged("dgSelectedIndexTest");
                }
            }
        }

        private MultipleContext_QMS_T002 _MC;
        public MultipleContext_QMS_T002 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_QMS_T002 _MCTemp;
        public MultipleContext_QMS_T002 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_QMS_T002 _MCTemp1;
        public MultipleContext_QMS_T002 MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private List<QMS_T002Flip> _FlipGridData;
        public List<QMS_T002Flip> FlipGridData
        {
            get { return _FlipGridData; }
            set { _FlipGridData = value; RaisePropertyChanged("FlipGridData"); }
        }

        private int _SelectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _SelectedTabControlIndex; }
            set { _SelectedTabControlIndex = value; RaisePropertyChanged("SelectedTabControlIndex"); }
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

        #region ICollectionView
        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }

        private ICollectionView _TestCollection;
        public ICollectionView TestCollection
        {
            get { return _TestCollection; }
            set
            {
                if (TestCollection != value)
                {
                    _TestCollection = value;
                    RaisePropertyChanged("TestCollection");
                }
            }

        }

        private ICollectionView _TestDataGrid;
        public ICollectionView TestDataGrid
        {
            get { return _TestDataGrid; }
            set
            {
                if (TestDataGrid != value)
                {
                    _TestDataGrid = value;
                    RaisePropertyChanged("TestDataGrid");
                }
            }
        }

        private ICollectionView _AccessoryDataGrid;
        public ICollectionView AccessoryDataGrid
        {
            get { return _AccessoryDataGrid; }
            set
            {
                if (_AccessoryDataGrid != value)
                {
                    _AccessoryDataGrid = value;
                    RaisePropertyChanged("AccessoryDataGrid");
                }
            }
        }

        private ICollectionView _ParameterDataGrid;
        public ICollectionView ParameterDataGrid
        {
            get { return _ParameterDataGrid; }
            set
            {
                if (_ParameterDataGrid != value)
                {
                    _ParameterDataGrid = value;
                    RaisePropertyChanged("ParameterDataGrid");
                }
            }
        }

        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        //public RelayCommand<object> CmdLoadDocumentByRefDocNumber { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CmdAddParty { get; private set; }
        public RelayCommand<object> CmdAddInstrument { get; private set; }
        public RelayCommand<object> CmdAddSono { get; private set; }
        public RelayCommand<object> CmdAddGRNDoc { get; private set; }
        public RelayCommand<object> CmdAddRefDoc { get; private set; }
        public RelayCommand<object> CmdAddLab { get; private set; }
        public RelayCommand<object> CmdAddAccCode { get; private set; }
        public RelayCommand<object> CmdAddParaValue { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowParameter { get; private set; }
        public RelayCommand<object> CmdAddTest { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowInst { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowTest { get; private set; }
        public RelayCommand<object> CmdLoadItemDetails { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByBarcodeNo { get; private set; }
        public RelayCommand<object> CmdAddInspectionLab { get; private set; }
        public RelayCommand<object> CmdAddAssignedPerson { get; private set; }
        public RelayCommand<object> CmdAddRangeUnit { get; private set; }
        public RelayCommand<object> CmdAddLowerRangeUnit { get; private set; }
        public RelayCommand<object> CmdAddUpperRangeUnit { get; private set; }
        public RelayCommand<object> CmdAddAccuracyUpUnit { get; private set; }
        public RelayCommand<object> CmdAddAccuracyDownUnit { get; private set; }
        public RelayCommand<object> CmdAddLeastCountUnit { get; private set; }
        public RelayCommand<object> CmdAddResolutionUnit { get; private set; }

        #endregion

        #region Event Handler
        private void CollectionChangedNotifyForInstrument(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (QMS_T002_B item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (QMS_T002_B item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (QMS_T002_B item in e.NewItems)
                    {
                        if (InstrumentEntity.Count >= 1 && dgSelectedIndexInst < InstrumentEntity.Count)
                        {
                            item.srno = srno++;
                            //so details
                            item.sono = MasterEntity.sono;
                            item.so_doc_cat = MasterEntity.so_doc_cat;
                            item.so_doc_type = MasterEntity.so_doc_type;
                            item.so_item_row_id = MasterEntity.so_item_row_id;
                            item.so_item_line_id = MasterEntity.so_item_line_id;
                            item.ItemCode = MasterEntity.ItemCode;
                            //Ref Details
                            item.ref_doc_no = MasterEntity.ref_doc_no;
                            item.ref_doc_cat = MasterEntity.ref_doc_cat;
                            item.ref_doc_type = MasterEntity.ref_doc_type;
                            item.ref_item_row_id = MasterEntity.ref_item_row_id;
                            item.ref_item_line_id = MasterEntity.ref_item_line_id;
                            //Inst details
                            item.inst_code = MasterEntity.inst_code;
                            item.inst_name = MasterEntity.inst_name;
                            item.inst_srno = MasterEntity.inst_srno;
                            item.qty = 1;
                            item.insp_cat = MasterEntity.insp_cat;
                            //Defauls Fields
                            item.t_status = "Open";
                            item.active = true;
                            item.add_by = AppSessionState.UserID;
                            item.editby = AppSessionState.UserID;
                            item.location_Id = AppSessionState.location_Id;
                            item.comp_code = AppSessionState.comp_code;
                            item.user_source1 = AppSessionState.UserSource1;
                            item.user_source2 = AppSessionState.UserSource2;
                            item.PropertyChanged += EntityViewModelPropertyChanged;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void CollectionChangedNotifyForTest(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (QMS_T002_C item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (QMS_T002_C item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (QMS_T002_C item in e.NewItems)
                    {
                        if (InstrumentEntity.Count >= 1 && dgSelectedIndexInst < InstrumentEntity.Count)
                        {
                            item.srno = InstrumentEntity[dgSelectedIndexInst].srno;
                            item.inst_row_id = InstrumentEntity[dgSelectedIndexInst].id;
                            item.exp_date = MasterEntity.exp_date;
                            item.deletion_id = DateTime.Now.Ticks.GetHashCode();
                            item.t_status = "Draft";
                            item.active = true;
                            item.add_by = AppSessionState.UserID;
                            item.editby = AppSessionState.UserID;
                            item.location_Id = AppSessionState.location_Id;
                            item.comp_code = AppSessionState.comp_code;
                            item.user_source1 = AppSessionState.UserSource1;
                            item.user_source2 = AppSessionState.UserSource2;
                            item.PropertyChanged += EntityViewModelPropertyChanged;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (QMS_T002_A item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (QMS_T002_A item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (QMS_T002_A item in e.NewItems)
                    {
                        if (InstrumentEntity.Count >= 1 && dgSelectedIndexInst < InstrumentEntity.Count)
                        {
                            item.srno = InstrumentEntity[dgSelectedIndexInst].srno;
                            item.inst_row_id = InstrumentEntity[dgSelectedIndexInst].id;
                            item.active = true;
                            item.add_by = AppSessionState.UserID;
                            item.editby = AppSessionState.UserID;
                            item.location_Id = AppSessionState.location_Id;
                            item.comp_code = AppSessionState.comp_code;
                            item.user_source1 = AppSessionState.UserSource1;
                            item.user_source2 = AppSessionState.UserSource2;
                            item.PropertyChanged += EntityViewModelPropertyChanged;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void CollectionChangedNotifyForParameter(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (QMS_T002_D item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (QMS_T002_D item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (QMS_T002_D item in e.NewItems)
                    {
                        if (InstrumentEntity.Count >= 1 && dgSelectedIndexInst < InstrumentEntity.Count)
                        {
                            item.srno = InstrumentEntity[dgSelectedIndexInst].srno;
                            item.inst_row_id = InstrumentEntity[dgSelectedIndexInst].id;
                            item.active = true;
                            item.add_by = AppSessionState.UserID;
                            item.editby = AppSessionState.UserID;
                            item.location_Id = AppSessionState.location_Id;
                            item.comp_code = AppSessionState.comp_code;
                            item.user_source1 = AppSessionState.UserSource1;
                            item.user_source2 = AppSessionState.UserSource2;
                            item.PropertyChanged += EntityViewModelPropertyChanged;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (ItemEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = false; /* ParameterEntity[dgSelectedIndexParaCode].HasErrors;*/
            }
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
            if (ItemEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = false;/*ItemEntity[dgSelectedIndexItem].HasErrors;*/
            }
            if (ParameterEntity.Count > dgSelectedIndexPara && dgSelectedIndexPara >= 0)
            {
                this.ErrorExist = false;/*ParameterEntity[dgSelectedIndexPara].HasErrors;*/
            }
            if (InstrumentEntity.Count > dgSelectedIndexInst && dgSelectedIndexInst >= 0)
            {
                this.ErrorExist = false;/*RequestEntity[dgSelectedIndexRequest].HasErrors;*/
            }
        }
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            if (sender.ToString() == "last_date" || sender.ToString() == "cal_freq" || sender.ToString() == "cal_period")
            {
                CalDueDate();
            }
            if (sender.ToString() == "serv_type")
            {
                FilterTest();
            }
        }
        void ModelUpdated_Instrument(object sender, EventArgs e)
        {
            if (sender.ToString() == "last_date" || sender.ToString() == "cal_freq" || sender.ToString() == "cal_period")
            {
                CalInstDueDate();
            }
        }
        private void CalDueDate()
        {
            if (MasterEntity.last_date != null)
            {
                // Calculation for due date -- Starts
                MasterEntity.due_date = MasterEntity.last_date;
                if (MasterEntity.cal_period == "Days")
                {
                    MasterEntity.due_date = Convert.ToDateTime(MasterEntity.last_date).AddDays(Convert.ToDouble(MasterEntity.cal_freq));
                }
                else if (MasterEntity.cal_period == "Months")
                {
                    MasterEntity.due_date = Convert.ToDateTime(MasterEntity.last_date).AddMonths(Convert.ToInt32(MasterEntity.cal_freq));
                }
                else if (MasterEntity.cal_period == "Years")
                {
                    MasterEntity.due_date = Convert.ToDateTime(MasterEntity.last_date).AddYears(Convert.ToInt32(MasterEntity.cal_freq));
                }
                MasterEntity.next_date = MasterEntity.due_date;
                // Calculation for due date -- End
            }
        }
        private void CalInstDueDate()
        {
            if (InstrumentEntity != null && InstrumentEntity.Count > dgSelectedIndexInst && dgSelectedIndexInst != -1)
            {
                if (InstrumentEntity[dgSelectedIndexInst].last_date != null)
                {
                    // Calculation for due date -- Starts
                    InstrumentEntity[dgSelectedIndexInst].due_date = InstrumentEntity[dgSelectedIndexInst].last_date;
                    if (InstrumentEntity[dgSelectedIndexInst].cal_period == "Days")
                    {
                        InstrumentEntity[dgSelectedIndexInst].due_date = Convert.ToDateTime(InstrumentEntity[dgSelectedIndexInst].last_date).AddDays(Convert.ToDouble(InstrumentEntity[dgSelectedIndexInst].cal_freq));
                    }
                    else if (InstrumentEntity[dgSelectedIndexInst].cal_period == "Months")
                    {
                        InstrumentEntity[dgSelectedIndexInst].due_date = Convert.ToDateTime(InstrumentEntity[dgSelectedIndexInst].last_date).AddMonths(Convert.ToInt32(InstrumentEntity[dgSelectedIndexInst].cal_freq));
                    }
                    else if (InstrumentEntity[dgSelectedIndexInst].cal_period == "Years")
                    {
                        InstrumentEntity[dgSelectedIndexInst].due_date = Convert.ToDateTime(InstrumentEntity[dgSelectedIndexInst].last_date).AddYears(Convert.ToInt32(InstrumentEntity[dgSelectedIndexInst].cal_freq));
                    }
                    InstrumentEntity[dgSelectedIndexInst].next_date = InstrumentEntity[dgSelectedIndexInst].due_date;
                    // Calculation for due date -- End
                }
            }

        }
        private void FilterParaValueCollection()
        {
            try
            {
                if (ParameterEntity.Count > dgSelectedIndexPara && dgSelectedIndexPara >= 0)
                {
                    List<QMS_M009_F> temp1 = (from o in MC.ParameterValue where o.para_code == ParameterEntity[dgSelectedIndexPara].para_code select o).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_F)x).para_value ?? "");
                    TheFilter = (o, prefix) => (((QMS_M009_F)o).para_value ?? "").ToLower().Contains(prefix.ToString().ToLower());
                    ASParaValue = new AutoSuggestTextViewModel<dynamic>(temp1, TheFilter, SuggestedValue, "para_value", "para_value", true);
                    ASParaValue.AutoSuggestVM.IsEmptyValueAllowed = true;
                }
            }
            catch (Exception ex) { }
        }
        private void FilterTestDataGrid()
        {
            try
            {
                if (TestEntity != null && TestEntity.Count > 0 && dgSelectedIndexInst >= 0)
                {
                    TestDataGrid = CollectionViewSource.GetDefaultView(TestEntity);
                    TestDataGrid.Filter = adv => ((QMS_T002_C)adv).srno.Equals(InstrumentEntity[dgSelectedIndexInst].srno);
                    TestDataGrid.Refresh();
                }
                if (ItemEntity != null && ItemEntity.Count > 0 && dgSelectedIndexInst >= 0)
                {
                    AccessoryDataGrid = CollectionViewSource.GetDefaultView(ItemEntity);
                    AccessoryDataGrid.Filter = adv => ((QMS_T002_A)adv).srno.Equals(InstrumentEntity[dgSelectedIndexInst].srno);
                    AccessoryDataGrid.Refresh();
                }
                if (ParameterEntity != null && ParameterEntity.Count > 0 && dgSelectedIndexInst >= 0)
                {
                    ParameterDataGrid = CollectionViewSource.GetDefaultView(ParameterEntity);
                    ParameterDataGrid.Filter = adv => ((QMS_T002_D)adv).srno.Equals(InstrumentEntity[dgSelectedIndexInst].srno);
                    ParameterDataGrid.Refresh();
                }
            }
            catch (Exception ex) { }
        }
        private void FilterTest()
        {
            if (MasterEntity.serv_type == "Test Inspection")
            {
                TestCollection = CollectionViewSource.GetDefaultView(MC.TestCode.Where(x => x.insp_type == "22"));
                TestCollection.Filter = new Predicate<object>(FilterTest);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009Flip)x).test_code ?? "");
                TheFilter = (o, prefix) => (((QMS_M009Flip)o).test_name ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M009Flip)o).test_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASGridTestCode = new AutoSuggestTextViewModel<dynamic>(MC.TestCode.Where(x => x.insp_type == "22"), TheFilter, SuggestedValue, "test_code", "test_code", true);
                ASGridTestCode.AutoSuggestVM.IsEmptyValueAllowed = true;
            }
            else if (MasterEntity.serv_type == "Calibration Inspection")
            {
                TestCollection = CollectionViewSource.GetDefaultView(MC.TestCode.Where(x => x.insp_type == "21"));
                TestCollection.Filter = new Predicate<object>(FilterTest);

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009Flip)x).test_code ?? "");
                TheFilter = (o, prefix) => (((QMS_M009Flip)o).test_name ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M009Flip)o).test_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASGridTestCode = new AutoSuggestTextViewModel<dynamic>(MC.TestCode.Where(x => x.insp_type == "21"), TheFilter, SuggestedValue, "test_code", "test_code", true);
                ASGridTestCode.AutoSuggestVM.IsEmptyValueAllowed = true;
            }
        }
        #endregion

        #region Constructor
        public QMS_T002_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            CursorControl.SetBusyState();
            MasterEntity = new QMS_T002();
            ItemEntity = new ObservableCollection<QMS_T002_A>();
            MC = new MultipleContext_QMS_T002();
            MCTemp = new MultipleContext_QMS_T002();
            FlipGridData = new List<QMS_T002Flip>();
            InstrumentEntity = new ObservableCollection<QMS_T002_B>();
            TestEntity = new ObservableCollection<QMS_T002_C>();
            ParameterEntity = new ObservableCollection<QMS_T002_D>();
            QMS_T002.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            QMS_T002_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Instrument);
            LoadInitialData();
            DefaultValues();
        }
        public QMS_T002_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            CursorControl.SetBusyState();
            MasterEntity = new QMS_T002();
            ItemEntity = new ObservableCollection<QMS_T002_A>();
            MC = new MultipleContext_QMS_T002();
            MCTemp = new MultipleContext_QMS_T002();
            FlipGridData = new List<QMS_T002Flip>();
            InstrumentEntity = new ObservableCollection<QMS_T002_B>();
            TestEntity = new ObservableCollection<QMS_T002_C>();
            ParameterEntity = new ObservableCollection<QMS_T002_D>();
            QMS_T002.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            QMS_T002_B.ModelEntityUpdated += new EventHandler(ModelUpdated_Instrument);
            LoadInitialData();
            DefaultValues();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                #region Commands
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
                //CmdLoadDocumentByRefDocNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByRefDocNumber(items); });
                CmdDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowItem(cmdPara); });
                CmdAddParty = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertParty(cmdPara); });
                CmdAddInstrument = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertInstrument(cmdPara, true, false, true); });
                CmdAddSono = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertSono(cmdPara); });
                CmdAddRefDoc = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertRefDoc(cmdPara); });
                CmdAddLab = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLab(cmdPara); });
                CmdAddAccCode = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertAccCode(cmdPara, true, false, true); });
                CmdAddParaValue = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertParaValue(cmdPara, false, false, true); });
                CmdDeleteDataGridRowParameter = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowParameter(cmdPara); });
                CmdAddTest = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTest(cmdPara, true, false, true); });
                CmdDeleteDataGridRowInst = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowInst(cmdPara); });
                CmdDeleteDataGridRowTest = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowTest(cmdPara); });
                CmdLoadItemDetails = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadItemDetails(); });
                CmdLoadDocumentByBarcodeNo = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
                CmdAddInspectionLab = new RelayCommand<object>(items => { if (items == null) { return; } InsertInspectionLab(items, true, false, true); });
                CmdAddAssignedPerson = new RelayCommand<object>(items => { if (items == null) { return; } InsertAssignedPerson(items, true, false, true); });
                CmdAddGRNDoc = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertGRNDoc(cmdPara); });
                CmdAddRangeUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertRangeUnit(cmdPara, true, false, true); });
                CmdAddLowerRangeUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLowerRangeUnit(cmdPara, true, false, true); });
                CmdAddUpperRangeUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUpperRangeUnit(cmdPara, true, false, true); });
                CmdAddAccuracyUpUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertAccuracyUpUnit(cmdPara, true, false, true); });
                CmdAddAccuracyDownUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertAccuracyDownUnit(cmdPara, true, false, true); });
                CmdAddLeastCountUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLeastCountUnit(cmdPara, true, false, true); });
                CmdAddResolutionUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertResolutionUnit(cmdPara, true, false, true); });

                #endregion
                MasterEntity.doc_cat = "RF";
                MasterEntity.doc_type = "RF";
                string Request = "LoadInitialData" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_T002>(MC, Request, "ServiceRequest", "QMS", "", 0, "");

                #region AutoSuggest Initialisation

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M028_P)x).PartyNm ?? "");
                TheFilter = (o, prefix) => (((ADM_M028_P)o).PartyNm ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M028_P)o).PartyId ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASParty = new AutoSuggestTextViewModel<dynamic>(MC.PartyMaster, TheFilter, SuggestedValue, "PartyNm", true);
                ASParty.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_PUR_T005_RefDoc)x).ref_item_row_id.ToString() ?? "");
                TheFilter = (o, prefix) => (((SEL_T003_PUR_T005_RefDoc)o).ref_doc_no ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((SEL_T003_PUR_T005_RefDoc)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToString().ToLower()) || (((SEL_T003_PUR_T005_RefDoc)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToString().ToLower());
                ASRefDoc = new AutoSuggestTextViewModel<dynamic>(MC.RefDocData, TheFilter, SuggestedValue, "ref_item_row_id", true);
                ASRefDoc.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_PUR_T005_RefDoc)x).ref_item_row_id.ToString() ?? "");
                TheFilter = (o, prefix) => (((SEL_T003_PUR_T005_RefDoc)o).sono ?? "").ToLower().Contains(prefix.ToString().ToLower()) || ((SEL_T003_PUR_T005_RefDoc)o).ref_doc_date.ToString().ToLower().Contains(prefix.ToString().ToLower());
                ASSono = new AutoSuggestTextViewModel<dynamic>(MC.RefDocData.Where(x => x.doc_cat == "SO"), TheFilter, SuggestedValue, "ref_item_row_id", true);
                ASSono.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_PUR_T005_RefDoc)x).ref_item_row_id.ToString() ?? "");
                TheFilter = (o, prefix) => (((SEL_T003_PUR_T005_RefDoc)o).sono ?? "").ToLower().Contains(prefix.ToString().ToLower()) || ((SEL_T003_PUR_T005_RefDoc)o).ref_doc_date.ToString().ToLower().Contains(prefix.ToString().ToLower());
                ASGRNDoc = new AutoSuggestTextViewModel<dynamic>(MC.RefDocData.Where(x => x.doc_cat == "GR"), TheFilter, SuggestedValue, "ref_item_row_id", true);
                ASGRNDoc.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_B_P)x).lab_name ?? "");
                TheFilter = (o, prefix) => (((ADM_M003_B_P)o).lab_name ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003_B_P)o).lab_code ?? "").ToString().ToLower().Contains(prefix.ToString().ToLower());
                ASLab = new AutoSuggestTextViewModel<dynamic>(MC.Laboratory, TheFilter, SuggestedValue, "lab_name", true);
                ASLab.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_PopUp_Inst)x).ItemCode ?? "");
                TheFilter = (o, prefix) => (((ADM_M022_PopUp_Inst)o).ItemName).ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M022_PopUp_Inst)o).ItemCode).ToString().ToLower().Contains(prefix.ToString().ToLower());
                ASAccCode = new AutoSuggestTextViewModel<dynamic>(MC.AccItem, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASAccCode.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASAccCode.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M004_P)x).ItemScope ?? "");
                TheFilter = (o, prefix) => (((QMS_M004_P)o).ItemScope).ToLower().Contains(prefix.ToString().ToLower());
                ASAccScope = new AutoSuggestTextViewModel<dynamic>(MC.AccScope, TheFilter, SuggestedValue, "ItemScope", "ItemScope", true);
                ASAccScope.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_PopUp_Inst)x).ItemCode ?? "");
                TheFilter = (o, prefix) => (((ADM_M022_PopUp_Inst)o).ItemCode).ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M022_PopUp_Inst)o).ItemName).ToString().ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.AccItem, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_F)x).para_value ?? "");
                TheFilter = (o, prefix) => (((QMS_M009_F)o).para_value ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault1 = new AutoSuggestTextViewModel<dynamic>(MC.ParameterValue, TheFilter, SuggestedValue, "para_value", "para_value", true);
                ASDefault1.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault1.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009Flip)x).test_name ?? "");
                TheFilter = (o, prefix) => (((QMS_M009Flip)o).test_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault2 = new AutoSuggestTextViewModel<dynamic>(MC.TestCode, TheFilter, SuggestedValue, "test_name", "test_name", true);
                ASDefault2.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault2.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M003_P)x).inst_name ?? "");
                TheFilter = (o, prefix) => (((QMS_M003_P)o).inst_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M003_P)o).inst_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault3 = new AutoSuggestTextViewModel<dynamic>(MC.Instrument, TheFilter, SuggestedValue, "inst_name", "inst_name", true);
                ASDefault3.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault3.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009Flip)x).test_code ?? "");
                TheFilter = (o, prefix) => (((QMS_M009Flip)o).test_name ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M009Flip)o).test_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASGridTestCode = new AutoSuggestTextViewModel<dynamic>(MC.TestCode, TheFilter, SuggestedValue, "test_code", "test_code", true);
                ASGridTestCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                //for instrument entity
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASRangeUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "range_unit", "unit_code", true);
                ASRangeUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASLowerRangeUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "lower_range_unit", "unit_code", true);
                ASLowerRangeUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASUpperRangeUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "upper_range_unit", "unit_code", true);
                ASUpperRangeUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASAccuracyUpUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "accuracy_up_unit", "unit_code", true);
                ASAccuracyUpUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASAccuracyDownUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "accuracy_down_unit", "unit_code", true);
                ASAccuracyDownUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASLeastCountUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "least_count_unit", "unit_code", true);
                ASLeastCountUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASResolutionUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "resolution_unit", "unit_code", true);
                ASResolutionUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M003_P)x).inst_code ?? "");
                TheFilter = (o, prefix) => (((QMS_M003_P)o).inst_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M003_P)o).inst_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASInstCode = new AutoSuggestTextViewModel<dynamic>(MC.Instrument, TheFilter, SuggestedValue, "inst_code", "inst_code", true);
                ASInstCode.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASInstCode.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003_B_P)x).lab_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M003_B_P)o).lab_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M003_B_P)o).lab_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASLabCode = new AutoSuggestTextViewModel<dynamic>(MC.Laboratory, TheFilter, SuggestedValue, "lab_code", "lab_code", true);
                ASLabCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpName ?? "");
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASAssignedTo = new AutoSuggestTextViewModel<dynamic>(MC.Employees, TheFilter, SuggestedValue, "assigned_to_name", "EmpName", true);
                ASAssignedTo.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion

                FlipGridData = MC.DocumentDataFlipGrid;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                foreach (var p in MC.AdditionalParameter)
                {
                    ParameterEntity.Add(new QMS_T002_D()
                    {
                        para_code = p.para_code,
                        para_name = p.para_name
                    });
                }
                FilterParaValueCollection();

                TestCollection = CollectionViewSource.GetDefaultView(MC.TestCode);
                TestCollection.Filter = new Predicate<object>(FilterTest);

               
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
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.active = true;
            MasterEntity.qty = 1;
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.req_date = DateTime.Now;
            MasterEntity.t_status = "Open";
            MasterEntity.doc_cat = "RF";
            MasterEntity.doc_type = "RF";
            MasterEntity.insp_cat = "Lab";
        }
        private void Logging()
        {
            MasterEntity.ts_code = this.ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;

            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.add_date = System.DateTime.Now;
            MasterEntity.edit_date = System.DateTime.Now;

            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            QMS_T002Flip ParameterEntityObject = new QMS_T002Flip();
            try
            {
                CursorControl.SetBusyState();
                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterObject;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_T002>(MCTemp, Request, "ServiceRequest", "QMS", "LoadDocumentByDocumentNumber", 0, "");
                }
                else if (((IEnumerable)ParameterObject).Cast<QMS_T002Flip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<QMS_T002Flip>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.doc_no + "!@" + ParameterEntityObject.barcode;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_T002>(MCTemp, Request, "ServiceRequest", "QMS", "LoadDocumentByDocumentNumber", 0, "");
                }
                if (MCTemp.MasterEntity.Count > 0)
                {
                    MasterEntity = MCTemp.MasterEntity[0];
                }
                ItemEntity = MCTemp.ItemEntity;
                ParameterEntity = MCTemp.ParameterEntity;
                InstrumentEntity = MCTemp.InstrumentEntity;
                TestEntity = MCTemp.TestEntity;

                if (MCTemp.Attachment != null)
                {
                    AttachmentCollection = MCTemp.Attachment;
                }
                else
                {
                    MCTemp.Attachment = new List<COM_T003>();
                }

                SelectedTabControlIndex = 0;
                isNewRecord = false;
                MasterEntity.ts_code = ts_code_vm;
                var msg = new NotificationMessage("QMS_T002_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
                SetPopupSuggestionDataAfterLoad();
                FilterTest();
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
        private void WindowEvetCall(object InputValue)
        {
            try
            {
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    //isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
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
        private void DeleteDataGridRowItem(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ItemEntity.Count > i && ItemEntity[dgSelectedIndexItem].id == 0)
                {
                    ItemEntity.RemoveAt(i);
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
        private void DeleteDataGridRowParameter(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ParameterEntity.Count > i && ParameterEntity[dgSelectedIndexPara].id == 0)
                {
                    ParameterEntity.RemoveAt(i);
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
                            { POPUPEntityObject = MC.PartyMaster.Where(x => x.PartyNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList().Count > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.PartyId = POPUPEntityObject.PartyId;
                    MasterEntity.PartyNm = POPUPEntityObject.PartyNm;
                    MasterEntity.ContInfoId = POPUPEntityObject.id;
                    MasterEntity.cont_per_name = POPUPEntityObject.PersonName;
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
        private void InsertInstrument(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M003_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Instrument.Where(x => x.inst_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M003_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M003_P>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    if (InstrumentEntity.Count > dgSelectedIndexInst && dgSelectedIndexInst != -1)
                    {
                        InstrumentEntity[dgSelectedIndexInst].inst_code = POPUPEntityObject.inst_code;
                        InstrumentEntity[dgSelectedIndexInst].inst_name = POPUPEntityObject.inst_name;
                        if (InstrumentEntity[dgSelectedIndexInst].model_no != POPUPEntityObject.model_no)
                        {
                            InstrumentEntity[dgSelectedIndexInst].model_no = POPUPEntityObject.model_no;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].inst_srno != POPUPEntityObject.inst_srno)
                        {
                            InstrumentEntity[dgSelectedIndexInst].inst_srno = POPUPEntityObject.inst_srno;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].inst_id != POPUPEntityObject.inst_id)
                        {
                            InstrumentEntity[dgSelectedIndexInst].inst_id = POPUPEntityObject.inst_id;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].inst_make != POPUPEntityObject.inst_make)
                        {
                            InstrumentEntity[dgSelectedIndexInst].inst_make = POPUPEntityObject.inst_make;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].range != POPUPEntityObject.range)
                        {
                            InstrumentEntity[dgSelectedIndexInst].range = POPUPEntityObject.range;
                            InstrumentEntity[dgSelectedIndexInst].range_unit = POPUPEntityObject.range_unit;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].accuracy_up != POPUPEntityObject.accuracy_up)
                        {
                            InstrumentEntity[dgSelectedIndexInst].accuracy_up = POPUPEntityObject.accuracy_up;
                            InstrumentEntity[dgSelectedIndexInst].accuracy_up_unit = POPUPEntityObject.accuracy_up_unit;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].accuracy_down != POPUPEntityObject.accuracy_down)
                        {
                            InstrumentEntity[dgSelectedIndexInst].accuracy_down = POPUPEntityObject.accuracy_down;
                            InstrumentEntity[dgSelectedIndexInst].accuracy_down_unit = POPUPEntityObject.accuracy_down_unit;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].least_count != POPUPEntityObject.least_count)
                        {
                            InstrumentEntity[dgSelectedIndexInst].least_count = POPUPEntityObject.least_count;
                            InstrumentEntity[dgSelectedIndexInst].least_count_unit = POPUPEntityObject.least_count_unit;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].resolution != POPUPEntityObject.resolution)
                        {
                            InstrumentEntity[dgSelectedIndexInst].resolution = POPUPEntityObject.resolution;
                            InstrumentEntity[dgSelectedIndexInst].resolution_unit = POPUPEntityObject.resolution_unit;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].upper_range != POPUPEntityObject.upper_range)
                        {
                            InstrumentEntity[dgSelectedIndexInst].upper_range = POPUPEntityObject.upper_range;
                            InstrumentEntity[dgSelectedIndexInst].upper_range_unit = POPUPEntityObject.upper_range_unit;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].lower_range != POPUPEntityObject.lower_range)
                        {
                            InstrumentEntity[dgSelectedIndexInst].lower_range = POPUPEntityObject.lower_range;
                            InstrumentEntity[dgSelectedIndexInst].lower_range_unit = POPUPEntityObject.lower_range_unit;
                        }
                        var msg = new NotificationMessage("QMS_T002_VM");
                        Messenger.Default.Send<NotificationMessage>(msg);
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
        private void InsertRefDoc(object InputValue)
        {
            try
            {
                string Request = "";
                SEL_T003_PUR_T005_RefDoc POPUPEntityObject = null;

                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.RefDocData.Where(x => x.ref_item_row_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<SEL_T003_PUR_T005_RefDoc>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T003_PUR_T005_RefDoc>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    if (POPUPEntityObject.doc_cat == "GR")
                    {
                        MasterEntity.ref_doc_no = POPUPEntityObject.ref_doc_no;
                        MasterEntity.ref_doc_cat = POPUPEntityObject.doc_cat;
                        MasterEntity.ref_doc_type = POPUPEntityObject.ref_doc_type;
                        MasterEntity.sono = POPUPEntityObject.sono;
                        MasterEntity.ref_item_row_id = POPUPEntityObject.ref_item_row_id;
                        MasterEntity.ref_item_line_id = POPUPEntityObject.ref_item_line_id;
                        MasterEntity.cust_name = POPUPEntityObject.PartyNm;
                        MasterEntity.inst_code = POPUPEntityObject.ItemCode;
                        MasterEntity.inst_name = POPUPEntityObject.ItemName;
                        MasterEntity.inst_srno = POPUPEntityObject.ItemCode;
                        MasterEntity.grn_item_row_id = POPUPEntityObject.ref_item_row_id;
                        MasterEntity.grn_no = POPUPEntityObject.ref_doc_no;
                    }
                    else
                    {
                        MasterEntity.ref_doc_no = POPUPEntityObject.ref_doc_no;
                        MasterEntity.ref_doc_cat = POPUPEntityObject.doc_cat;
                        MasterEntity.ref_doc_type = POPUPEntityObject.ref_doc_type;
                        MasterEntity.sono = POPUPEntityObject.sono;
                        MasterEntity.ref_item_row_id = POPUPEntityObject.ref_item_row_id;
                        MasterEntity.ref_item_line_id = POPUPEntityObject.ref_item_line_id;
                        MasterEntity.cust_name = POPUPEntityObject.PartyNm;
                        MasterEntity.inst_code = POPUPEntityObject.ItemCode;
                        MasterEntity.inst_name = POPUPEntityObject.ItemName;
                        MasterEntity.inst_srno = POPUPEntityObject.ItemCode;
                    }
                    var msg = new NotificationMessage("QMS_T002_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);
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
        private void InsertSono(object InputValue)
        {
            try
            {
                string Request = "";
                SEL_T003_PUR_T005_RefDoc POPUPEntityObject = null;

                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.RefDocData.Where(x => (x.doc_cat == "SO" && x.ref_item_row_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true)).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<SEL_T003_PUR_T005_RefDoc>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T003_PUR_T005_RefDoc>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.so_doc_cat = POPUPEntityObject.doc_cat;
                    MasterEntity.so_doc_type = POPUPEntityObject.ref_doc_type;
                    MasterEntity.sono = POPUPEntityObject.sono;
                    MasterEntity.so_item_row_id = POPUPEntityObject.ref_item_row_id;
                    MasterEntity.so_item_line_id = POPUPEntityObject.ref_item_line_id;
                    MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                    MasterEntity.cust_name = POPUPEntityObject.PartyNm;

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T003_PUR_T005_RefDoc)x).ref_item_row_id.ToString() ?? "");
                    TheFilter = (o, prefix) => (((SEL_T003_PUR_T005_RefDoc)o).ref_doc_no ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((SEL_T003_PUR_T005_RefDoc)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToString().ToLower()) || (((SEL_T003_PUR_T005_RefDoc)o).ItemName ?? "").ToString().ToLower().Contains(prefix.ToString().ToLower());
                    ASRefDoc = new AutoSuggestTextViewModel<dynamic>(MC.RefDocData.Where(x => x.sono == MasterEntity.sono), TheFilter, SuggestedValue, "ref_item_row_id", true);
                    ASRefDoc.AutoSuggestVM.IsEmptyValueAllowed = true;

                    var msg = new NotificationMessage("QMS_T002_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);
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
        private void InsertGRNDoc(object InputValue)
        {
            try
            {
                string Request = "";
                SEL_T003_PUR_T005_RefDoc POPUPEntityObject = null;

                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.RefDocData.Where(x => (x.doc_cat == "GR" && x.ref_item_row_id.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true)).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<SEL_T003_PUR_T005_RefDoc>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T003_PUR_T005_RefDoc>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.grn_no = POPUPEntityObject.ref_doc_no;
                    MasterEntity.grn_item_row_id = POPUPEntityObject.ref_item_row_id;

                    var msg = new NotificationMessage("QMS_T002_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);
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
        private void InsertLab(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M003_B_P POPUPEntityObject = null;
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Laboratory.Where(x => x.lab_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M003_B_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_B_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.lab_code = POPUPEntityObject.lab_code;
                    MasterEntity.lab_name = POPUPEntityObject.lab_name;
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
        private void InsertAccCode(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M022_PopUp_Inst POPUPEntityObject = null;
            try
            {
                #region Command Parameter Read Section
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.AccItem.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M022_PopUp_Inst>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_PopUp_Inst>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null)
                {
                    //var InputValueIfExists = ItemEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                    //int IndexOfExistValue = ItemEntity.IndexOf(ItemEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());
                    if (dgSelectedIndexItem >= 0 && ItemEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_T002_A> temp = ItemEntity.ToList();
                        temp = (from o in temp where o.srno == InstrumentEntity[dgSelectedIndexInst].srno select o).ToList();
                        if (temp.Count > 0 && dgSelectedIndexItem < temp.Count && dgSelectedIndexItem != -1)
                        {
                            temp[dgSelectedIndexItem].ItemCode = POPUPEntityObject.ItemCode;
                            temp[dgSelectedIndexItem].ItemName = POPUPEntityObject.ItemName;
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
        private void InsertParaValue(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M009_F POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.ParameterValue.Where(x => x.para_value.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_F>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_F>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    if (dgSelectedIndexPara >= 0 && ParameterEntity.Count > dgSelectedIndexPara) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_T002_D> temp = ParameterEntity.ToList();
                        temp = (from o in temp where o.srno == InstrumentEntity[dgSelectedIndexInst].srno select o).ToList();
                        if (temp.Count > 0 && dgSelectedIndexPara < temp.Count && dgSelectedIndexPara != -1)
                        {
                            temp[dgSelectedIndexPara].value_code = POPUPEntityObject.value_code;
                            temp[dgSelectedIndexPara].para_value = POPUPEntityObject.para_value;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void SetPopupSuggestionDataAfterLoad()
        {
            ASLab.AutoSuggestVM.Suggestion = MC.Laboratory.Find(x => x.lab_code == MasterEntity.lab_code);
            ASParty.AutoSuggestVM.Suggestion = MC.PartyMaster.Find(x => x.PartyId == MasterEntity.PartyId);
            ASRefDoc.AutoSuggestVM.Suggestion = MC.RefDocData.Find(x => x.ref_doc_no == MasterEntity.ref_doc_no);
        }
        private void InsertTest(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M009Flip POPUPEntityObject = null;

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.TestCode.Where(x => x.test_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009Flip>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009Flip>().ToList()[0];
                }

                if (POPUPEntityObject != null)
                {
                    List<QMS_T002_C> temp1 = TestEntity.ToList();
                    temp1 = (from o in temp1 where o.srno == InstrumentEntity[dgSelectedIndexInst].srno select o).ToList();
                    var InputValueIfExists = temp1.Where(x => x.test_code == POPUPEntityObject.test_code).FirstOrDefault();
                    int IndexOfExistValue = temp1.IndexOf(TestEntity.Where(X => X.test_code == POPUPEntityObject.test_code).FirstOrDefault());

                    if (NewRow == true && (AllowDuplicate == false || IndexOfExistValue == -1) && temp1.Count == dgSelectedIndexTest)
                    {
                        TestEntity.Add(new QMS_T002_C()
                        {
                            test_code = POPUPEntityObject.test_code,
                            test_name = POPUPEntityObject.test_name,
                            insp_type_name = POPUPEntityObject.insp_type_name,
                            exp_date = MasterEntity.exp_date
                        });
                    }
                    else if (dgSelectedIndexTest >= 0 && TestEntity.Count > dgSelectedIndexTest) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_T002_C> temp = TestEntity.ToList();
                        temp = (from o in temp where o.srno == InstrumentEntity[dgSelectedIndexInst].srno select o).ToList();
                        if (temp.Count > 0 && dgSelectedIndexTest < temp.Count && dgSelectedIndexTest != -1)
                        {
                            temp[dgSelectedIndexTest].test_code = POPUPEntityObject.test_code;
                            temp[dgSelectedIndexTest].test_name = POPUPEntityObject.test_name;
                            temp[dgSelectedIndexTest].insp_type_name = POPUPEntityObject.insp_type_name;
                            //temp[dgSelectedIndexTest].exp_date = MasterEntity.exp_date;
                        }
                    }
                }
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
        private void DeleteDataGridRowInst(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (InstrumentEntity.Count > i && InstrumentEntity[dgSelectedIndexInst].id == 0)
                {
                    List<QMS_T002_C> TestIfExists = (from o in TestEntity where o.srno == InstrumentEntity[dgSelectedIndexInst].srno select o).ToList();
                    //if (TestIfExists.Count > 0)
                    //{
                    //    foreach (var item in TestIfExists)
                    //    {
                    //        TestEntity.Remove(item);
                    //    }
                    //}
                    InstrumentEntity.RemoveAt(i);
                    if (InstrumentEntity.Count == 0)
                    {
                        InstrumentEntity = new ObservableCollection<QMS_T002_B>();
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
        private void DeleteDataGridRowTest(object InputValue)
        {
            try
            {
                QMS_T002_C POPUPEntityObject = null;
                if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_T002_C>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_T002_C>().ToList()[0];
                }
                if (TestEntity.Count > 0)
                {
                    List<QMS_T002_C> temp = TestEntity.ToList();
                    foreach (var a in temp)
                    {
                        if (a.id == 0 && a.deletion_id == POPUPEntityObject.deletion_id)
                        {
                            TestEntity.Remove(a);
                        }
                    }
                }
                if (TestEntity.Count == 0)
                {
                    TestEntity = new ObservableCollection<QMS_T002_C>();
                }
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
        private async void LoadItemDetails()
        {
            try
            {
                if (MasterEntity.inst_code != null && MasterEntity.inst_code != "")
                {
                    string Request = "LoadItemDetails" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + MasterEntity.inst_code;
                    MCTemp1 = await repository_MC.GetDataWithReturnDomainObjectASynchronus<MultipleContext_QMS_T002>(MC, Request, "ServiceRequest", "QMS", "", 0, "");

                    if (MCTemp1.Instrument.Count > 0 && InstrumentEntity.Count > dgSelectedIndexInst && dgSelectedIndexInst != -1)
                    {
                        InstrumentEntity[dgSelectedIndexInst].inst_code = MCTemp1.Instrument[0].inst_code;
                        InstrumentEntity[dgSelectedIndexInst].inst_name = MCTemp1.Instrument[0].inst_name;
                        if (InstrumentEntity[dgSelectedIndexInst].model_no != MCTemp1.Instrument[0].model_no)
                        {
                            InstrumentEntity[dgSelectedIndexInst].model_no = MCTemp1.Instrument[0].model_no;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].inst_srno != MCTemp1.Instrument[0].inst_srno)
                        {
                            InstrumentEntity[dgSelectedIndexInst].inst_srno = MCTemp1.Instrument[0].inst_srno;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].inst_id != MCTemp1.Instrument[0].inst_id)
                        {
                            InstrumentEntity[dgSelectedIndexInst].inst_id = MCTemp1.Instrument[0].inst_id;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].inst_make != MCTemp1.Instrument[0].inst_make)
                        {
                            InstrumentEntity[dgSelectedIndexInst].inst_make = MCTemp1.Instrument[0].inst_make;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].range != MCTemp1.Instrument[0].range)
                        {
                            InstrumentEntity[dgSelectedIndexInst].range = MCTemp1.Instrument[0].range;
                            InstrumentEntity[dgSelectedIndexInst].range_unit = MCTemp1.Instrument[0].range_unit;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].accuracy_up != MCTemp1.Instrument[0].accuracy_up)
                        {
                            InstrumentEntity[dgSelectedIndexInst].accuracy_up = MCTemp1.Instrument[0].accuracy_up;
                            InstrumentEntity[dgSelectedIndexInst].accuracy_up_unit = MCTemp1.Instrument[0].accuracy_up_unit;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].accuracy_down != MCTemp1.Instrument[0].accuracy_down)
                        {
                            InstrumentEntity[dgSelectedIndexInst].accuracy_down = MCTemp1.Instrument[0].accuracy_down;
                            InstrumentEntity[dgSelectedIndexInst].accuracy_down_unit = MCTemp1.Instrument[0].accuracy_down_unit;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].least_count != MCTemp1.Instrument[0].least_count)
                        {
                            InstrumentEntity[dgSelectedIndexInst].least_count = MCTemp1.Instrument[0].least_count;
                            InstrumentEntity[dgSelectedIndexInst].least_count_unit = MCTemp1.Instrument[0].least_count_unit;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].resolution != MCTemp1.Instrument[0].resolution)
                        {
                            InstrumentEntity[dgSelectedIndexInst].resolution = MCTemp1.Instrument[0].resolution;
                            InstrumentEntity[dgSelectedIndexInst].resolution_unit = MCTemp1.Instrument[0].resolution_unit;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].upper_range != MCTemp1.Instrument[0].upper_range)
                        {
                            InstrumentEntity[dgSelectedIndexInst].upper_range = MCTemp1.Instrument[0].upper_range;
                            InstrumentEntity[dgSelectedIndexInst].upper_range_unit = MCTemp1.Instrument[0].upper_range_unit;
                        }
                        if (InstrumentEntity[dgSelectedIndexInst].lower_range != MCTemp1.Instrument[0].lower_range)
                        {
                            InstrumentEntity[dgSelectedIndexInst].lower_range = MCTemp1.Instrument[0].lower_range;
                            InstrumentEntity[dgSelectedIndexInst].lower_range_unit = MCTemp1.Instrument[0].lower_range_unit;
                        }
                        var msg = new NotificationMessage("QMS_T002_VM");
                        Messenger.Default.Send<NotificationMessage>(msg);
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
        private void InsertInspectionLab(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M003_B_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Laboratory.Where(x => x.lab_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M003_B_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_B_P>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    if (dgSelectedIndexTest >= 0 && TestEntity.Count > dgSelectedIndexTest) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_T002_C> temp = TestEntity.ToList();
                        temp = (from o in temp where o.srno == InstrumentEntity[dgSelectedIndexInst].srno select o).ToList();
                        if (temp.Count > 0 && dgSelectedIndexTest < temp.Count && dgSelectedIndexTest != -1)
                        {
                            temp[dgSelectedIndexTest].lab_code = POPUPEntityObject.lab_code;
                            temp[dgSelectedIndexTest].lab_name = POPUPEntityObject.lab_name;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertAssignedPerson(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M024_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Employees.Where(x => x.EmpName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    if (dgSelectedIndexTest >= 0 && TestEntity.Count > dgSelectedIndexTest) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_T002_C> temp = TestEntity.ToList();
                        temp = (from o in temp where o.srno == InstrumentEntity[dgSelectedIndexInst].srno select o).ToList();
                        if (temp.Count > 0 && dgSelectedIndexTest < temp.Count && dgSelectedIndexTest != -1)
                        {
                            temp[dgSelectedIndexTest].assigned_to = POPUPEntityObject.EmpId;
                            temp[dgSelectedIndexTest].assigned_to_name = POPUPEntityObject.EmpName;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertRangeUnit(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitCode.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    if (InstrumentEntity.Count > dgSelectedIndexInst && dgSelectedIndexInst != -1)
                    {
                        InstrumentEntity[dgSelectedIndexInst].range_unit = POPUPEntityObject.unit_code;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertLowerRangeUnit(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitCode.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    if (InstrumentEntity.Count > dgSelectedIndexInst && dgSelectedIndexInst != -1)
                    {
                        InstrumentEntity[dgSelectedIndexInst].lower_range_unit = POPUPEntityObject.unit_code;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertUpperRangeUnit(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitCode.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    if (InstrumentEntity.Count > dgSelectedIndexInst && dgSelectedIndexInst != -1)
                    {
                        InstrumentEntity[dgSelectedIndexInst].upper_range_unit = POPUPEntityObject.unit_code;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertAccuracyUpUnit(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitCode.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    if (InstrumentEntity.Count > dgSelectedIndexInst && dgSelectedIndexInst != -1)
                    {
                        InstrumentEntity[dgSelectedIndexInst].accuracy_up_unit = POPUPEntityObject.unit_code;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertAccuracyDownUnit(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitCode.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    if (InstrumentEntity.Count > dgSelectedIndexInst && dgSelectedIndexInst != -1)
                    {
                        InstrumentEntity[dgSelectedIndexInst].accuracy_down_unit = POPUPEntityObject.unit_code;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertLeastCountUnit(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitCode.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    if (InstrumentEntity.Count > dgSelectedIndexInst && dgSelectedIndexInst != -1)
                    {
                        InstrumentEntity[dgSelectedIndexInst].least_count_unit = POPUPEntityObject.unit_code;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertResolutionUnit(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UnitCode.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    if (InstrumentEntity.Count > dgSelectedIndexInst && dgSelectedIndexInst != -1)
                    {
                        InstrumentEntity[dgSelectedIndexInst].resolution_unit = POPUPEntityObject.unit_code;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region Abstract Methods
        private bool Validation()
        {
            if (MasterEntity.cal_type == null || MasterEntity.cal_type == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("please select Inspection Type...");
                showMessageService.ShowMessage();
                return false;
            }
            if (TestEntity.Count == 0)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("please select at least one Test...");
                showMessageService.ShowMessage();
                return false;
            }
            foreach (var o in ItemEntity)
            {
                int flag = 0;
                if (o.id == 0 && o.active == true)
                {
                    foreach (var p in ItemEntity)
                    {
                        if (o.ItemCode == p.ItemCode)
                        {
                            flag++;
                        }
                    }
                    if (flag > 1)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Cannot Save Duplicate Acceessory: {0} ", o.ItemName);
                        showMessageService.ShowMessage();
                        return false;
                    }
                }
            }
            foreach (var o in TestEntity)
            {
                int flag = 0;
                if (o.id == 0 && o.active == true)
                {
                    foreach (var p in TestEntity)
                    {
                        if (o.test_code == p.test_code)
                        {
                            flag++;
                        }
                    }
                    if (flag > 1)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Cannot Save Duplicate Test: {0} ", o.test_name);
                        showMessageService.ShowMessage();
                        return false;
                    }
                }
            }
            return true;
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.XmlDataDocument_QMS_T002_A != null)
                {
                    ItemEntity.Clear();
                    MC.ItemEntity = (ObservableCollection<QMS_T002_A>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_T002_A, MC.ItemEntity);
                    ItemEntity = MC.ItemEntity;
                }
                else
                {
                    MC.ItemEntity = new ObservableCollection<QMS_T002_A>();
                }
                if (MasterEntity.XmlDataDocument_QMS_T002Flip != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<QMS_T002Flip>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_T002Flip, MC.DocumentDataFlipGrid);
                    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                    DataGridCollection.Refresh();
                }
                if (MasterEntity.XmlDataDocument_QMS_T002_D != null)
                {
                    ParameterEntity.Clear();
                    MC.ParameterEntity = (ObservableCollection<QMS_T002_D>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_T002_D, MC.ParameterEntity);
                    ParameterEntity = MC.ParameterEntity;
                }
                else
                {
                    MC.ParameterEntity = new ObservableCollection<QMS_T002_D>();
                }
                if (MasterEntity.XmlDataDocument_QMS_T002_B != null)
                {
                    InstrumentEntity.Clear();
                    MC.InstrumentEntity = (ObservableCollection<QMS_T002_B>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_T002_B, MC.InstrumentEntity);
                    InstrumentEntity = MC.InstrumentEntity;
                }
                else
                {
                    MC.InstrumentEntity = new ObservableCollection<QMS_T002_B>();
                }
                if (MasterEntity.XmlDataDocument_QMS_T002_C != null)
                {
                    TestEntity.Clear();
                    MC.TestEntity = (ObservableCollection<QMS_T002_C>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_T002_C, MC.TestEntity);
                    TestEntity = MC.TestEntity;
                }
                else
                {
                    MC.TestEntity = new ObservableCollection<QMS_T002_C>();
                }
                MasterEntity.ts_code = ts_code_vm;
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
        protected override void OnCreateAction(InquiryActionResult<QMS_T002> result)
        {
            MasterEntity = new QMS_T002();
            ItemEntity = new ObservableCollection<QMS_T002_A>();
            InstrumentEntity = new ObservableCollection<QMS_T002_B>();
            TestEntity = new ObservableCollection<QMS_T002_C>();
            ParameterEntity = new ObservableCollection<QMS_T002_D>();

            DefaultValues();
            isNewRecord = true;
        }
        protected override void OnDiscardAction(InquiryActionResult<QMS_T002> result)
        {

        }
        protected override void OnDocumentAction()
        {
            CursorControl.SetBusyState();
            if (!string.IsNullOrEmpty(MasterEntity.doc_no))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MCTemp.Attachment });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<QMS_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_T002> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnFevoriteAction(InquiryActionResult<QMS_T002> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<QMS_T002> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<QMS_T002> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<QMS_T002> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<QMS_T002> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<QMS_T002> result)
        {
            try
            {
                CursorControl.SetBusyState();
                if (Validation() == true)
                {
                    Logging();
                    MasterEntity.XmlDataDocument_QMS_T002_A = obj.ObjectToXML(ItemEntity);
                    MasterEntity.XmlDataDocument_QMS_T002_B = obj.ObjectToXML(InstrumentEntity);
                    MasterEntity.XmlDataDocument_QMS_T002_C = obj.ObjectToXML(TestEntity);
                    MasterEntity.XmlDataDocument_QMS_T002_D = obj.ObjectToXML(ParameterEntity);
                    this.MasterEntity.EndEdit();

                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<QMS_T002>(MasterEntity, "ServiceRequest", "QMS");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<QMS_T002>(MasterEntity, "ServiceRequest", "QMS");
                    }

                    if (MasterEntity.doc_no != null && isNewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    else if (MasterEntity.doc_no != null && isNewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    isNewRecord = false;

                    var msg = new NotificationMessage("QMS_T002_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);
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

        #region BF Filter
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
            var data = obj as QMS_T002Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.doc_no != null && data.doc_no.ToLower().Contains(_filterString.ToLower()) ||
                            data.doc_date.ToString() != null && data.doc_date.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.serv_type != null && data.serv_type.ToLower().Contains(_filterString.ToLower()) ||
                            data.cal_type != null && data.cal_type.ToLower().Contains(_filterString.ToLower()) ||
                            data.cust_name != null && data.cust_name.ToLower().Contains(_filterString.ToLower()) ||
                            data.t_status != null && data.t_status.ToLower().Contains(_filterString.ToLower()) ||
                            data.inst_name != null && data.inst_name.ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }

        private string _filterStringTest;
        public string FilterStringTest
        {
            get { return _filterStringTest; }
            set
            {
                _filterStringTest = value;
                RaisePropertyChanged("FilterStringTest");
                FilterTestCollection();
            }
        }
        private void FilterTestCollection()
        {
            if (_TestCollection != null)
            {
                _TestCollection.Refresh();
            }
        }
        public bool FilterTest(object obj)
        {
            var data = obj as QMS_M009Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringTest))
                {
                    return (data.test_code != null && data.test_code.ToLower().Contains(_filterStringTest.ToLower()) ||
                            data.test_name != null && data.test_name.ToLower().Contains(_filterStringTest.ToLower())
                            );
                }
                return true;
            }
            return false;
        }

       
        #endregion
    }
}
