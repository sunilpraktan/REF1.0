using Reflection.Presentation.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.BusinessEntity.QMS;
using Reflection.WebServices.Gateway;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Collections;
using Reflection.Presentation.Services;
using System.Windows.Data;
using System.Collections.Specialized;
using System.Windows.Controls;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using GalaSoft.MvvmLight.Messaging;
using System.Windows;
using System.Globalization;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Common;

namespace Reflection.Modules.QMS.ViewModels
{
    public class QMS_T001_VM : WorkspaceViewModel<QMS_T001>
    {
        int mn;
        internal string TestTypeParameter;
        bool isNewRecord = true;
        WebServiceRepository<QMS_T001> repository = new WebServiceRepository<QMS_T001>();
        WebServiceRepository<MultipleContext_QMS_T001> repository_MC = new WebServiceRepository<MultipleContext_QMS_T001>();
        WebServiceRepository<MultipleContext_QMS_T001> repository_MCTemp = new WebServiceRepository<MultipleContext_QMS_T001>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(QMS_T001_VM));
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
        private AutoSuggestTextViewModel<dynamic> _ASEmployee { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASEmployee
        {
            get { return _ASEmployee; }
            set
            {
                if (_ASEmployee != value)
                {
                    _ASEmployee = value; RaisePropertyChanged("ASEmployee");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAuthEmployee { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAuthEmployee
        {
            get { return _ASAuthEmployee; }
            set
            {
                if (_ASAuthEmployee != value)
                {
                    _ASAuthEmployee = value; RaisePropertyChanged("ASAuthEmployee");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASTracibility { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTracibility
        {
            get { return _ASTracibility; }
            set
            {
                if (_ASTracibility != value)
                {
                    _ASTracibility = value; RaisePropertyChanged("ASTracibility");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDefault4 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault4
        {
            get { return _ASDefault4; }
            set
            {
                if (_ASDefault4 != value)
                {
                    _ASDefault4 = value; RaisePropertyChanged("ASDefault4");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASEqCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASEqCode
        {
            get { return _ASEqCode; }
            set
            {
                if (_ASEqCode != value)
                {
                    _ASEqCode = value; RaisePropertyChanged("ASEqCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASRig { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRig
        {
            get { return _ASRig; }
            set
            {
                if (_ASRig != value)
                {
                    _ASRig = value; RaisePropertyChanged("ASRig");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPO { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPO
        {
            get { return _ASPO; }
            set
            {
                if (_ASPO != value)
                {
                    _ASPO = value; RaisePropertyChanged("ASPO");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASUnitCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUnitCode
        {
            get { return _ASUnitCode; }
            set
            {
                if (_ASUnitCode != value)
                {
                    _ASUnitCode = value; RaisePropertyChanged("ASUnitCode");
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

        private AutoSuggestTextViewModel<dynamic> _ASTaskList { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTaskList
        {
            get { return _ASTaskList; }
            set
            {
                if (_ASTaskList != value)
                {
                    _ASTaskList = value; RaisePropertyChanged("ASTaskList");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBValue1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBValue1
        {
            get { return _ASBValue1; }
            set
            {
                if (_ASBValue1 != value)
                {
                    _ASBValue1 = value; RaisePropertyChanged("ASBValue1");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBValue2 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBValue2
        {
            get { return _ASBValue2; }
            set
            {
                if (_ASBValue2 != value)
                {
                    _ASBValue2 = value; RaisePropertyChanged("ASBValue2");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBValue3 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBValue3
        {
            get { return _ASBValue3; }
            set
            {
                if (_ASBValue3 != value)
                {
                    _ASBValue3 = value; RaisePropertyChanged("ASBValue3");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBValue4 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBValue4
        {
            get { return _ASBValue4; }
            set
            {
                if (_ASBValue4 != value)
                {
                    _ASBValue4 = value; RaisePropertyChanged("ASBValue4");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBValue5 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBValue5
        {
            get { return _ASBValue5; }
            set
            {
                if (_ASBValue5 != value)
                {
                    _ASBValue5 = value; RaisePropertyChanged("ASBValue5");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBValue6 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBValue6
        {
            get { return _ASBValue6; }
            set
            {
                if (_ASBValue6 != value)
                {
                    _ASBValue6 = value; RaisePropertyChanged("ASBValue6");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBValue7 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBValue7
        {
            get { return _ASBValue7; }
            set
            {
                if (_ASBValue7 != value)
                {
                    _ASBValue7 = value; RaisePropertyChanged("ASBValue7");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBValue8 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBValue8
        {
            get { return _ASBValue8; }
            set
            {
                if (_ASBValue8 != value)
                {
                    _ASBValue8 = value; RaisePropertyChanged("ASBValue8");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBValue9 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBValue9
        {
            get { return _ASBValue9; }
            set
            {
                if (_ASBValue9 != value)
                {
                    _ASBValue9 = value; RaisePropertyChanged("ASBValue9");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASBValue10 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBValue10
        {
            get { return _ASBValue10; }
            set
            {
                if (_ASBValue10 != value)
                {
                    _ASBValue10 = value; RaisePropertyChanged("ASBValue10");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDefault5 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault5
        {
            get { return _ASDefault5; }
            set
            {
                if (_ASDefault5 != value)
                {
                    _ASDefault5 = value; RaisePropertyChanged("ASDefault5");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASStdEnvCond { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASStdEnvCond
        {
            get { return _ASStdEnvCond; }
            set
            {
                if (_ASStdEnvCond != value)
                {
                    _ASStdEnvCond = value; RaisePropertyChanged("ASStdEnvCond");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASEnvValueUnitCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASEnvValueUnitCode
        {
            get { return _ASEnvValueUnitCode; }
            set
            {
                if (_ASEnvValueUnitCode != value)
                {
                    _ASEnvValueUnitCode = value; RaisePropertyChanged("ASEnvValueUnitCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASSiteEmployee { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASSiteEmployee
        {
            get { return _ASSiteEmployee; }
            set
            {
                if (_ASSiteEmployee != value)
                {
                    _ASSiteEmployee = value; RaisePropertyChanged("ASSiteEmployee");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASParaValueUnitCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASParaValueUnitCode
        {
            get { return _ASParaValueUnitCode; }
            set
            {
                if (_ASParaValueUnitCode != value)
                {
                    _ASParaValueUnitCode = value; RaisePropertyChanged("ASParaValueUnitCode");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASParaName { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASParaName
        {
            get { return _ASParaName; }
            set
            {
                if (_ASParaName != value)
                {
                    _ASParaName = value; RaisePropertyChanged("ASParaName");
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
            try
            {
                if (dgCellInfo != null)
                {
                    var column = dgCellInfo.Column as DataGridColumn;
                    if (column != null)
                    {
                        string headerName = column.Header.ToString();
                        string SourceName = column.SortMemberPath.ToString();
                        if (SourceName == "para_value")
                        { ASDefault1 = ASParaValue; }
                        else if (SourceName == "unit_code")
                        { ASDefault = ASUnitCode; }
                        else if (SourceName == "column_value1")
                        { ASDefault = ASBValue1; }
                        else if (SourceName == "column_value2")
                        { ASDefault = ASBValue2; }
                        else if (SourceName == "column_value3")
                        { ASDefault = ASBValue3; }
                        else if (SourceName == "column_value4")
                        { ASDefault = ASBValue4; }
                        else if (SourceName == "column_value5")
                        { ASDefault = ASBValue5; }
                        else if (SourceName == "column_value6")
                        { ASDefault = ASBValue6; }
                        else if (SourceName == "column_value7")
                        { ASDefault = ASBValue7; }
                        else if (SourceName == "column_value8")
                        { ASDefault = ASBValue8; }
                        else if (SourceName == "column_value9")
                        { ASDefault = ASBValue9; }
                        else if (SourceName == "column_value10")
                        { ASDefault = ASBValue10; }
                        else if (SourceName == "tl_code")
                        { ASDefault3 = ASTaskList; }
                        else if (SourceName == "ItemCode")
                        { ASDefault4 = ASEqCode; }
                        else if (SourceName == "tr_code")
                        { ASDefault4 = ASEqCode; }
                        else if (SourceName == "unit_code")
                        { ASDefault4 = ASEqCode; }
                        else if (SourceName == "std_value_unit")
                        { ASDefault5 = ASEnvValueUnitCode; }
                        else if (SourceName == "env_code")
                        { ASDefault5 = ASStdEnvCond; }
                        else if (SourceName == "para_value_unit")
                        { ASDefault1 = ASParaValueUnitCode; }
                        else if (SourceName == "para_name")
                        { ASDefault1 = ASParaName; }
                    }
                }
            }
            catch (Exception ex) { }
        }

        #endregion

        #region Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }
        #region Entities
        private QMS_T001 _MasterEntity;
        public QMS_T001 MasterEntity
        {
            get { return _MasterEntity; }
            set { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); }
        }

        private ObservableCollection<QMS_T001_A> _MasterEquipmentEntity;
        public ObservableCollection<QMS_T001_A> MasterEquipmentEntity
        {
            get { return _MasterEquipmentEntity; }
            set { _MasterEquipmentEntity = value; RaisePropertyChanged("MasterEquipmentEntity"); }
        }

        private ObservableCollection<QMS_T001_B> _TestTypeEntity;
        public ObservableCollection<QMS_T001_B> TestTypeEntity
        {
            get { return _TestTypeEntity; }
            set
            {
                _TestTypeEntity = value;
                TestTypeEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTestType);
                RaisePropertyChanged("TestTypeEntity");
            }
        }

        private ObservableCollection<QMS_T001_C> _ResultEntity;
        public ObservableCollection<QMS_T001_C> ResultEntity
        {
            get { return _ResultEntity; }
            set { _ResultEntity = value; RaisePropertyChanged("ResultEntity"); }
        }

        private ObservableCollection<QMS_M003_B> _ParameterEntity;
        public ObservableCollection<QMS_M003_B> ParameterEntity
        {
            get { return _ParameterEntity; }
            set
            {
                _ParameterEntity = value;
                ParameterEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForParameter);
                RaisePropertyChanged("ParameterEntity");
            }
        }

        private ObservableCollection<QMS_T001_E> _TaskListEntity;
        public ObservableCollection<QMS_T001_E> TaskListEntity
        {
            get { return _TaskListEntity; }
            set { _TaskListEntity = value; RaisePropertyChanged("TaskListEntity"); }
        }

        private ObservableCollection<QMS_T001_F> _EnvCondEntity;
        public ObservableCollection<QMS_T001_F> EnvCondEntity
        {
            get { return _EnvCondEntity; }
            set
            {
                if (_EnvCondEntity != value)
                {
                    _EnvCondEntity = value;
                    EnvCondEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForEnvCond);
                    RaisePropertyChanged("EnvCondEntity");
                }
            }
        }

        #endregion

        #region Datagrid Indexes

        private int _dgSelectedIndexParameter;
        public int dgSelectedIndexParameter
        {
            get { return _dgSelectedIndexParameter; }
            set
            {
                _dgSelectedIndexParameter = value;
                FilterParaValueCollection();
                RaisePropertyChanged("dgSelectedIndexParameter");
            }
        }

        private int _dgSelectedIndexTestType;
        public int dgSelectedIndexTestType
        {
            get { return _dgSelectedIndexTestType; }
            set
            {
                _dgSelectedIndexTestType = value;
                DisplayExpUncertainty();
                RaisePropertyChanged("dgSelectedIndexTestType");
            }
        }

        private int _dgSelectedIndexTaskList;
        public int dgSelectedIndexTaskList
        {
            get { return _dgSelectedIndexTaskList; }
            set { _dgSelectedIndexTaskList = value; RaisePropertyChanged("dgSelectedIndexTaskList"); }
        }

        private int _dgSelectedIndexMasterEquipment;
        public int dgSelectedIndexMasterEquipment
        {
            get { return _dgSelectedIndexMasterEquipment; }
            set { _dgSelectedIndexMasterEquipment = value; RaisePropertyChanged("dgSelectedIndexMasterEquipment"); }
        }

        private int _dgSelectedIndexUnc;
        public int dgSelectedIndexUnc
        {
            get { return _dgSelectedIndexUnc; }
            set
            {
                _dgSelectedIndexUnc = value;
                TypeA(true);
                RaisePropertyChanged("dgSelectedIndexUnc");
            }
        }

        private int _dgSelectedIndexEnvCond;
        public int dgSelectedIndexEnvCond
        {
            get { return _dgSelectedIndexEnvCond; }
            set
            {
                _dgSelectedIndexEnvCond = value;
                RaisePropertyChanged("dgSelectedIndexEnvCond");
            }
        }

        #endregion

        private MultipleContext_QMS_T001 _MC;
        public MultipleContext_QMS_T001 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_QMS_T001 _MCTemp;
        public MultipleContext_QMS_T001 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private MultipleContext_QMS_T001 _MCTemp1;
        public MultipleContext_QMS_T001 MCTemp1
        {
            get { return _MCTemp1; }
            set { _MCTemp1 = value; RaisePropertyChanged("MCTemp1"); }
        }

        private List<QMS_T001Flip> _FlipGridData;
        public List<QMS_T001Flip> FlipGridData
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

        List<QMS_T001_B_UNC> TypeAEntity = new List<QMS_T001_B_UNC>();

        private string _decimal_digits;
        public string decimal_digits
        {
            get { return _decimal_digits; }
            set { _decimal_digits = value; RaisePropertyChanged("decimal_digits"); }
        }

        #endregion

        #region ICollectionView

        private ICollectionView _dataGridCollection;
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
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

        private ICollectionView _TestTypeDataGrid;
        public ICollectionView TestTypeDataGrid
        {
            get { return _TestTypeDataGrid; }
            set { _TestTypeDataGrid = value; RaisePropertyChanged("TestTypeDataGrid"); }
        }

        private ICollectionView _EnvCondDataGrid;
        public ICollectionView EnvCondDataGrid
        {
            get { return _EnvCondDataGrid; }
            set { _EnvCondDataGrid = value; RaisePropertyChanged("EnvCondDataGrid"); }
        }

        private ICollectionView _UOMCollection;// UOM Collection
        public ICollectionView UOMCollection
        {
            get { return _UOMCollection; }
            set { _UOMCollection = value; RaisePropertyChanged("UOMCollection"); }
        }

        private List<QMS_M009_D> _BenchValueList1;
        public List<QMS_M009_D> BenchValueList1
        {
            get { return _BenchValueList1; }
            set { _BenchValueList1 = value; RaisePropertyChanged("BenchValueList1"); }
        }

        private List<QMS_M009_D> _BenchValueList2;
        public List<QMS_M009_D> BenchValueList2
        {
            get { return _BenchValueList2; }
            set { _BenchValueList2 = value; RaisePropertyChanged("BenchValueList2"); }
        }

        private List<QMS_M009_D> _BenchValueList3;
        public List<QMS_M009_D> BenchValueList3
        {
            get { return _BenchValueList3; }
            set { _BenchValueList3 = value; RaisePropertyChanged("BenchValueList3"); }
        }

        private List<QMS_M009_D> _BenchValueList4;
        public List<QMS_M009_D> BenchValueList4
        {
            get { return _BenchValueList4; }
            set { _BenchValueList4 = value; RaisePropertyChanged("BenchValueList4"); }
        }

        private List<QMS_M009_D> _BenchValueList5;
        public List<QMS_M009_D> BenchValueList5
        {
            get { return _BenchValueList5; }
            set { _BenchValueList5 = value; RaisePropertyChanged("BenchValueList5"); }
        }

        private List<QMS_M009_D> _BenchValueList6;
        public List<QMS_M009_D> BenchValueList6
        {
            get { return _BenchValueList6; }
            set { _BenchValueList6 = value; RaisePropertyChanged("BenchValueList6"); }
        }

        private List<QMS_M009_D> _BenchValueList7;
        public List<QMS_M009_D> BenchValueList7
        {
            get { return _BenchValueList7; }
            set { _BenchValueList7 = value; RaisePropertyChanged("BenchValueList7"); }
        }

        private List<QMS_M009_D> _BenchValueList8;
        public List<QMS_M009_D> BenchValueList8
        {
            get { return _BenchValueList8; }
            set { _BenchValueList8 = value; RaisePropertyChanged("BenchValueList8"); }
        }

        private List<QMS_M009_D> _BenchValueList9;
        public List<QMS_M009_D> BenchValueList9
        {
            get { return _BenchValueList9; }
            set { _BenchValueList9 = value; RaisePropertyChanged("BenchValueList9"); }
        }

        private List<QMS_M009_D> _BenchValueList10;
        public List<QMS_M009_D> BenchValueList10
        {
            get { return _BenchValueList10; }
            set { _BenchValueList10 = value; RaisePropertyChanged("BenchValueList10"); }
        }

        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }

        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByRefDocNumber { get; private set; }
        public RelayCommand<object> CmdAddEmployee { get; private set; }
        public RelayCommand<object> CmdAddAuthEmployee { get; private set; }
        public RelayCommand<object> CmdAddTracibility { get; private set; }
        public RelayCommand<object> CmdAddRig { get; private set; }
        public RelayCommand<object> CmdAddUOM { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowParameter { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowTestType { get; private set; }
        public RelayCommand<object> CmdAddParaValue { get; private set; }
        public RelayCommand<object> CmdAddColumnValue1 { get; private set; }
        public RelayCommand<object> CmdAddColumnValue2 { get; private set; }
        public RelayCommand<object> CmdAddColumnValue3 { get; private set; }
        public RelayCommand<object> CmdAddColumnValue4 { get; private set; }
        public RelayCommand<object> CmdAddColumnValue5 { get; private set; }
        public RelayCommand<object> CmdAddColumnValue6 { get; private set; }
        public RelayCommand<object> CmdAddColumnValue7 { get; private set; }
        public RelayCommand<object> CmdAddColumnValue8 { get; private set; }
        public RelayCommand<object> CmdAddColumnValue9 { get; private set; }
        public RelayCommand<object> CmdAddColumnValue10 { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowTaskList { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowMasterEquipment { get; private set; }
        public RelayCommand<object> CmdAddTaskList { get; private set; }
        public RelayCommand<object> CmdCustReport { get; private set; }
        public RelayCommand<object> CmdAddEqCode { get; private set; }
        public RelayCommand<object> CmdUncertaintyBudgetReport { get; private set; }
        public RelayCommand<object> CmdAddEnvCond { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowEnvCondition { get; private set; }
        public RelayCommand<object> CmdAddSiteEmployee { get; private set; }

        #endregion

        #region Event Handler
        private void CollectionChangedNotifyForParameter(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (QMS_M003_B item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (QMS_M003_B item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (QMS_M003_B item in e.NewItems)
                    {
                        if (ParameterEntity.Count >= 1 && dgSelectedIndexParameter < ParameterEntity.Count)
                        {
                            item.para_type = "CC";
                            item.inst_code = MasterEntity.inst_code;
                            item.active = true;
                            item.add_by = AppSessionState.UserID;
                            item.editby = AppSessionState.UserID;
                            item.comp_code = AppSessionState.comp_code;
                            item.location_Id = AppSessionState.location_Id;
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
            if (ParameterEntity.Count > dgSelectedIndexParameter && dgSelectedIndexParameter >= 0)
            {
                this.ErrorExist = false; /* ParameterEntity[dgSelectedIndexParaCode].HasErrors;*/
            }
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
            if (ParameterEntity.Count > dgSelectedIndexParameter && dgSelectedIndexParameter >= 0)
            {
                this.ErrorExist = false;/*ParameterEntity[dgSelectedIndexItem].HasErrors;*/
            }
        }
        private void FilterParaValueCollection()
        {
            try
            {
                if (ParameterEntity.Count > dgSelectedIndexParameter && dgSelectedIndexParameter >= 0)
                {
                    List<QMS_M009_F> temp1 = (from o in MC.Parameter where o.para_code == ParameterEntity[dgSelectedIndexParameter].para_code select o).ToList();

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_F)x).para_value ?? "");
                    TheFilter = (o, prefix) => (((QMS_M009_F)o).para_value ?? "").ToLower().Contains(prefix.ToString().ToLower());
                    ASParaValue = new AutoSuggestTextViewModel<dynamic>(temp1, TheFilter, SuggestedValue, "para_value", "para_value", false);
                    ASParaValue.AutoSuggestVM.IsEmptyValueAllowed = true;
                }
            }
            catch (Exception ex) { }
        }
        private void CollectionChangedNotifyForTestType(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (QMS_T001_B item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (QMS_T001_B item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (QMS_T001_B item in e.NewItems)
                    {
                        if (TestTypeEntity.Count >= 1 && dgSelectedIndexTestType < TestTypeEntity.Count)
                        {
                            item.deletion_id = mn++;
                            item.test_type_code = TestTypeParameter;
                            item.add_by = AppSessionState.UserID;
                            item.editby = AppSessionState.UserID;
                            item.active = true;
                            item.location_Id = AppSessionState.location_Id;
                            item.comp_code = AppSessionState.comp_code;
                            item.user_source1 = AppSessionState.UserSource1;
                            item.user_source2 = AppSessionState.UserSource2;
                            item.coverage_factor = (from o in MC.TestType where o.test_type_code == TestTypeParameter select o.coverage_factor).FirstOrDefault();
                            item.conf_level = (from o in MC.TestType where o.test_type_code == TestTypeParameter select o.conf_level).FirstOrDefault();
                            item.PropertyChanged += EntityViewModelPropertyChanged;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void CollectionChangedNotifyForEnvCond(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (QMS_T001_F item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (QMS_T001_F item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    if (TestTypeParameter != null)
                    {
                        foreach (QMS_T001_F item in e.NewItems)
                        {
                            item.test_type_code = TestTypeParameter;
                            item.deletion_id = mn++;
                            item.add_by = AppSessionState.UserID;
                            item.editby = AppSessionState.UserID;
                            item.active = true;
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
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            if (sender.ToString() == "copy")
            {
                if (MasterEntity.copy == true)
                {
                    isNewRecord = true;
                }
            }
        }
        void ModelUpdated_EnvCond(object sender, EventArgs e)
        {
            if (sender.ToString() == "r_std_value")
            {
                EnvVariation();
            }
        }
        void ModelUpdated_TestType(object sender, EventArgs e)
        {
            CursorControl.SetBusyState();
            if (sender.ToString() == "value1" || sender.ToString() == "value2" || sender.ToString() == "value3" || sender.ToString() == "value4" || sender.ToString() == "value5"
                || sender.ToString() == "value6" || sender.ToString() == "value7" || sender.ToString() == "value8" || sender.ToString() == "value9" || sender.ToString() == "value10"
                || sender.ToString() == "value11" || sender.ToString() == "value12" || sender.ToString() == "value13" || sender.ToString() == "value14" || sender.ToString() == "value15"
                || sender.ToString() == "value16" || sender.ToString() == "value17" || sender.ToString() == "value18" || sender.ToString() == "value19" || sender.ToString() == "value20")
            {
                CalMasterOutput(true);
            }
            else if (sender.ToString() == "value31" || sender.ToString() == "value32" || sender.ToString() == "value33" || sender.ToString() == "value34" || sender.ToString() == "value35"
                || sender.ToString() == "value36" || sender.ToString() == "value37" || sender.ToString() == "value38" || sender.ToString() == "value39" || sender.ToString() == "value40"
                || sender.ToString() == "value41" || sender.ToString() == "value42" || sender.ToString() == "value43" || sender.ToString() == "value44" || sender.ToString() == "value45"
                || sender.ToString() == "value46" || sender.ToString() == "value47" || sender.ToString() == "value48" || sender.ToString() == "value49" || sender.ToString() == "value50")
            {
                CalUnitOutput(true);
            }
            else if (sender.ToString() == "value21" || sender.ToString() == "value22" || sender.ToString() == "value23"
                || sender.ToString() == "value51" || sender.ToString() == "value52" || sender.ToString() == "value53")
            {
                CalVariation(true);
            }
            else if (sender.ToString() == "select31" || sender.ToString() == "select32" || sender.ToString() == "select33" || sender.ToString() == "select34" || sender.ToString() == "select35"
                || sender.ToString() == "select36" || sender.ToString() == "select37" || sender.ToString() == "select38" || sender.ToString() == "select39" || sender.ToString() == "select40"
                || sender.ToString() == "select41" || sender.ToString() == "select42" || sender.ToString() == "select43" || sender.ToString() == "select44" || sender.ToString() == "select45"
                || sender.ToString() == "select46" || sender.ToString() == "select47" || sender.ToString() == "select48" || sender.ToString() == "select49" || sender.ToString() == "select50")
            {
                TypeA(true);
            }
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
        }
        private void EnvVariation()
        {
            try
            {
                List<QMS_T001_F> tempEntity = new List<QMS_T001_F>();
                tempEntity = (from o in EnvCondEntity where o.test_type_code == TestTypeParameter select o).ToList();
                if (tempEntity.Count > dgSelectedIndexEnvCond && dgSelectedIndexEnvCond >= 0)
                {
                    tempEntity = (from o in tempEntity where o.test_type_code == tempEntity[dgSelectedIndexEnvCond].test_type_code && o.deletion_id == tempEntity[dgSelectedIndexEnvCond].deletion_id select o).ToList();
                    foreach (var o in tempEntity)
                    {
                        o.variation = Convert.ToDecimal(o.r_std_value) - Convert.ToDecimal(o.std_value);
                        o.variation_per = o.variation * 100 / Convert.ToDecimal(o.std_value);
                    }
                }
            }
            catch (Exception ex)
            { }

        }
        private void CalMasterOutput(bool Compute)
        {
            try
            {
                List<QMS_T001_B> tempEntity = new List<QMS_T001_B>();
                decimal? min_value = 0;
                decimal? max_value = 0;
                decimal? avg_value = 0;
                int count;
                tempEntity = (from o in TestTypeEntity where o.test_type_code == TestTypeParameter select o).ToList();
                if (tempEntity.Count > dgSelectedIndexTestType && dgSelectedIndexTestType >= 0)
                {
                    tempEntity = (from o in tempEntity where o.test_type_code == tempEntity[dgSelectedIndexTestType].test_type_code && o.deletion_id == tempEntity[dgSelectedIndexTestType].deletion_id select o).ToList();
                }
                foreach (var columns in tempEntity)
                {
                    if (columns.value1 != null)
                    {
                        count = 1;
                        avg_value = columns.value1;
                        min_value = columns.value1;
                        max_value = columns.value1;
                    }
                    if (columns.value2 != null)
                    {
                        count = 2;
                        avg_value = (columns.value1 + columns.value2) / count;
                        if (columns.value2 < min_value)
                        {
                            min_value = columns.value2;
                        }
                        if (columns.value2 > max_value)
                        {
                            max_value = columns.value2;
                        }
                    }
                    if (columns.value3 != null)
                    {
                        count = 3;
                        avg_value = (columns.value1 + columns.value2 + columns.value3) / count;
                        if (columns.value3 < min_value)
                        {
                            min_value = columns.value3;
                        }
                        if (columns.value3 > max_value)
                        {
                            max_value = columns.value3;
                        }
                    }
                    if (columns.value4 != null)
                    {
                        count = 4;
                        avg_value = (columns.value1 + columns.value2 + columns.value3 + columns.value4) / count;
                        if (columns.value4 < min_value)
                        {
                            min_value = columns.value4;
                        }
                        if (columns.value4 > max_value)
                        {
                            max_value = columns.value4;
                        }
                    }
                    if (columns.value5 != null)
                    {
                        count = 5;
                        avg_value = (columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5) / count;
                        if (columns.value5 < min_value)
                        {
                            min_value = columns.value5;
                        }
                        if (columns.value5 > max_value)
                        {
                            max_value = columns.value5;
                        }
                    }
                    if (columns.value6 != null)
                    {
                        count = 6;
                        if (columns.test_type_code == "AC Voltage" || columns.test_type_code == "DC Voltage")
                        {
                            avg_value = ((columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5) / 5) + ((columns.value6) / 1);
                        }
                        else
                        {
                            avg_value = (columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5
                                     + columns.value6) / count;
                        }
                        if (columns.value6 < min_value)
                        {
                            min_value = columns.value6;
                        }
                        if (columns.value6 > max_value)
                        {
                            max_value = columns.value6;
                        }
                    }
                    if (columns.value7 != null)
                    {
                        count = 7;
                        if (columns.test_type_code == "AC Voltage" || columns.test_type_code == "DC Voltage")
                        {
                            avg_value = ((columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5) / 5) + ((columns.value6 + columns.value7) / 2);
                        }
                        else
                        {
                            avg_value = (columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5
                                     + columns.value6 + columns.value7) / count;
                        }
                        if (columns.value7 < min_value)
                        {
                            min_value = columns.value7;
                        }
                        if (columns.value7 > max_value)
                        {
                            max_value = columns.value7;
                        }
                    }
                    if (columns.value8 != null)
                    {
                        count = 8;
                        if (columns.test_type_code == "AC Voltage" || columns.test_type_code == "DC Voltage")
                        {
                            avg_value = ((columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5) / 5) + ((columns.value6 + columns.value7 + columns.value8) / 3);
                        }
                        else
                        {
                            avg_value = (columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5
                                     + columns.value6 + columns.value7 + columns.value8) / count;
                        }
                        if (columns.value8 < min_value)
                        {
                            min_value = columns.value8;
                        }
                        if (columns.value8 > max_value)
                        {
                            max_value = columns.value8;
                        }
                    }
                    if (columns.value9 != null)
                    {
                        count = 9;
                        if (columns.test_type_code == "AC Voltage" || columns.test_type_code == "DC Voltage")
                        {
                            avg_value = ((columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5) / 5) + ((columns.value6 + columns.value7 + columns.value8 + columns.value9) / 4);
                        }
                        else
                        {
                            avg_value = (columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5
                                     + columns.value6 + columns.value7 + columns.value8 + columns.value9) / count;
                        }
                        if (columns.value9 < min_value)
                        {
                            min_value = columns.value9;
                        }
                        if (columns.value9 > max_value)
                        {
                            max_value = columns.value9;
                        }
                    }
                    if (columns.value10 != null)
                    {
                        count = 10;
                        if (columns.test_type_code == "AC Voltage" || columns.test_type_code == "DC Voltage")
                        {
                            avg_value = ((columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5) / 5) + ((columns.value6 + columns.value7 + columns.value8 + columns.value9 + columns.value10) / 5);
                        }
                        else
                        {
                            avg_value = (columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5
                                     + columns.value6 + columns.value7 + columns.value8 + columns.value9 + columns.value10) / count;
                        }
                        if (columns.value10 < min_value)
                        {
                            min_value = columns.value10;
                        }
                        if (columns.value10 > max_value)
                        {
                            max_value = columns.value10;
                        }
                    }
                    if (columns.value11 != null)
                    {
                        count = 11;
                        avg_value = (columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5
                                     + columns.value6 + columns.value7 + columns.value8 + columns.value9 + columns.value10
                                     + columns.value11) / count;
                        if (columns.value11 < min_value)
                        {
                            min_value = columns.value11;
                        }
                        if (columns.value11 > max_value)
                        {
                            max_value = columns.value11;
                        }
                    }
                    if (columns.value12 != null)
                    {
                        count = 12;
                        avg_value = (columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5
                                     + columns.value6 + columns.value7 + columns.value8 + columns.value9 + columns.value10
                                     + columns.value11 + columns.value12) / count;
                        if (columns.value12 < min_value)
                        {
                            min_value = columns.value12;
                        }
                        if (columns.value12 > max_value)
                        {
                            max_value = columns.value12;
                        }
                    }
                    if (columns.value13 != null)
                    {
                        count = 13;
                        avg_value = (columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5
                                     + columns.value6 + columns.value7 + columns.value8 + columns.value9 + columns.value10
                                     + columns.value11 + columns.value12 + columns.value13) / count;
                        if (columns.value13 < min_value)
                        {
                            min_value = columns.value13;
                        }
                        if (columns.value13 > max_value)
                        {
                            max_value = columns.value13;
                        }
                    }
                    if (columns.value14 != null)
                    {
                        count = 14;
                        avg_value = (columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5
                                     + columns.value6 + columns.value7 + columns.value8 + columns.value9 + columns.value10
                                     + columns.value11 + columns.value12 + columns.value13 + columns.value14) / count;
                        if (columns.value14 < min_value)
                        {
                            min_value = columns.value14;
                        }
                        if (columns.value14 > max_value)
                        {
                            max_value = columns.value14;
                        }
                    }
                    if (columns.value15 != null)
                    {
                        count = 15;
                        avg_value = (columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5
                                     + columns.value6 + columns.value7 + columns.value8 + columns.value9 + columns.value10
                                     + columns.value11 + columns.value12 + columns.value13 + columns.value14 + columns.value15) / count;
                        if (columns.value15 < min_value)
                        {
                            min_value = columns.value15;
                        }
                        if (columns.value15 > max_value)
                        {
                            max_value = columns.value15;
                        }
                    }
                    if (columns.value16 != null)
                    {
                        count = 16;
                        avg_value = (columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5
                                     + columns.value6 + columns.value7 + columns.value8 + columns.value9 + columns.value10
                                     + columns.value11 + columns.value12 + columns.value13 + columns.value14 + columns.value15
                                     + columns.value16) / count;
                        if (columns.value16 < min_value)
                        {
                            min_value = columns.value16;
                        }
                        if (columns.value16 > max_value)
                        {
                            max_value = columns.value16;
                        }
                    }
                    if (columns.value17 != null)
                    {
                        count = 17;
                        avg_value = (columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5
                                     + columns.value6 + columns.value7 + columns.value8 + columns.value9 + columns.value10
                                     + columns.value11 + columns.value12 + columns.value13 + columns.value14 + columns.value15
                                     + columns.value16 + columns.value17) / count;
                        if (columns.value17 < min_value)
                        {
                            min_value = columns.value17;
                        }
                        if (columns.value17 > max_value)
                        {
                            max_value = columns.value17;
                        }
                    }
                    if (columns.value18 != null)
                    {
                        count = 18;
                        avg_value = (columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5
                                     + columns.value6 + columns.value7 + columns.value8 + columns.value9 + columns.value10
                                     + columns.value11 + columns.value12 + columns.value13 + columns.value14 + columns.value15
                                     + columns.value16 + columns.value17 + columns.value18) / count;
                        if (columns.value18 < min_value)
                        {
                            min_value = columns.value18;
                        }
                        if (columns.value18 > max_value)
                        {
                            max_value = columns.value18;
                        }
                    }
                    if (columns.value19 != null)
                    {
                        count = 19;
                        avg_value = (columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5
                                     + columns.value6 + columns.value7 + columns.value8 + columns.value9 + columns.value10
                                     + columns.value11 + columns.value12 + columns.value13 + columns.value14 + columns.value15
                                     + columns.value16 + columns.value17 + columns.value18 + columns.value19) / count;
                        if (columns.value19 < min_value)
                        {
                            min_value = columns.value19;
                        }
                        if (columns.value19 > max_value)
                        {
                            max_value = columns.value19;
                        }
                    }
                    if (columns.value20 != null)
                    {
                        count = 20;
                        avg_value = (columns.value1 + columns.value2 + columns.value3 + columns.value4 + columns.value5
                                     + columns.value6 + columns.value7 + columns.value8 + columns.value9 + columns.value10
                                     + columns.value11 + columns.value12 + columns.value13 + columns.value14 + columns.value15
                                     + columns.value16 + columns.value17 + columns.value18 + columns.value19 + columns.value20) / count;
                        if (columns.value20 < min_value)
                        {
                            min_value = columns.value20;
                        }
                        if (columns.value20 > max_value)
                        {
                            max_value = columns.value20;
                        }
                    }
                    columns.value21 = min_value;
                    columns.value22 = max_value;
                    columns.value23 = avg_value;
                }
            }
            catch (Exception ex)
            { }
        }
        private void CalUnitOutput(bool Compute)
        {
            try
            {
                List<QMS_T001_B> tempEntity = new List<QMS_T001_B>();
                decimal? min_value = 0;
                decimal? max_value = 0;
                decimal? avg_value = 0;
                int count;

                if (TestTypeEntity.Count > dgSelectedIndexTestType && dgSelectedIndexTestType >= 0)
                {
                    if (TestTypeParameter != null)
                    {
                        List<QMS_T001_B> tempEntity_Code = (from o in TestTypeEntity where o.test_type_code == TestTypeParameter select o).ToList();
                        tempEntity = (from o in tempEntity_Code where o.test_type_code == tempEntity_Code[dgSelectedIndexTestType].test_type_code && o.deletion_id == tempEntity_Code[dgSelectedIndexTestType].deletion_id select o).ToList();
                    }
                }
                foreach (var columns in tempEntity)
                {
                    if (columns.value31 != null)
                    {
                        count = 1;
                        avg_value = columns.value31;
                        min_value = columns.value31;
                        max_value = columns.value31;
                        columns.select31 = true;
                    }
                    if (columns.value32 != null)
                    {
                        count = 2;
                        avg_value = (columns.value31 + columns.value32) / count;
                        if (columns.value32 < min_value)
                        {
                            min_value = columns.value32;
                        }
                        if (columns.value32 > max_value)
                        {
                            max_value = columns.value32;
                        }
                        columns.select32 = true;
                    }
                    if (columns.value33 != null)
                    {
                        count = 3;
                        avg_value = (columns.value31 + columns.value32 + columns.value33) / count;
                        if (columns.value33 < min_value)
                        {
                            min_value = columns.value33;
                        }
                        if (columns.value33 > max_value)
                        {
                            max_value = columns.value33;
                        }
                        columns.select33 = true;
                    }
                    if (columns.value34 != null)
                    {
                        count = 4;
                        avg_value = (columns.value31 + columns.value32 + columns.value33 + columns.value34) / count;
                        if (columns.value34 < min_value)
                        {
                            min_value = columns.value34;
                        }
                        if (columns.value34 > max_value)
                        {
                            max_value = columns.value34;
                        }
                        columns.select34 = true;
                    }
                    if (columns.value35 != null)
                    {
                        count = 5;
                        avg_value = (columns.value31 + columns.value32 + columns.value33 + columns.value34 + columns.value35) / count;
                        if (columns.value35 < min_value)
                        {
                            min_value = columns.value35;
                        }
                        if (columns.value35 > max_value)
                        {
                            max_value = columns.value35;
                        }
                        columns.select35 = true;
                    }
                    if (columns.value36 != null)
                    {
                        count = 6;
                        avg_value = (columns.value31 + columns.value32 + columns.value33 + columns.value34 + columns.value35
                                     + columns.value36) / count;
                        if (columns.value36 < min_value)
                        {
                            min_value = columns.value36;
                        }
                        if (columns.value36 > max_value)
                        {
                            max_value = columns.value36;
                        }
                        columns.select36 = true;
                    }
                    if (columns.value37 != null)
                    {
                        count = 7;
                        avg_value = (columns.value31 + columns.value32 + columns.value33 + columns.value34 + columns.value35
                                     + columns.value36 + columns.value37) / count;
                        if (columns.value37 < min_value)
                        {
                            min_value = columns.value37;
                        }
                        if (columns.value37 > max_value)
                        {
                            max_value = columns.value37;
                        }
                        columns.select37 = true;
                    }
                    if (columns.value38 != null)
                    {
                        count = 8;
                        avg_value = (columns.value31 + columns.value32 + columns.value33 + columns.value34 + columns.value35
                                     + columns.value36 + columns.value37 + columns.value38) / count;
                        if (columns.value38 < min_value)
                        {
                            min_value = columns.value38;
                        }
                        if (columns.value38 > max_value)
                        {
                            max_value = columns.value38;
                        }
                        columns.select38 = true;
                    }
                    if (columns.value39 != null)
                    {
                        count = 9;
                        avg_value = (columns.value31 + columns.value32 + columns.value33 + columns.value34 + columns.value35
                                     + columns.value36 + columns.value37 + columns.value38 + columns.value39) / count;
                        if (columns.value39 < min_value)
                        {
                            min_value = columns.value39;
                        }
                        if (columns.value39 > max_value)
                        {
                            max_value = columns.value39;
                        }
                        columns.select39 = true;
                    }
                    if (columns.value40 != null)
                    {
                        count = 10;
                        avg_value = (columns.value31 + columns.value32 + columns.value33 + columns.value34 + columns.value35
                                     + columns.value36 + columns.value37 + columns.value38 + columns.value39 + columns.value40) / count;
                        if (columns.value40 < min_value)
                        {
                            min_value = columns.value40;
                        }
                        if (columns.value40 > max_value)
                        {
                            max_value = columns.value40;
                        }
                        columns.select40 = true;
                    }
                    if (columns.value41 != null)
                    {
                        count = 11;
                        avg_value = (columns.value31 + columns.value32 + columns.value33 + columns.value34 + columns.value35
                                     + columns.value36 + columns.value37 + columns.value38 + columns.value39 + columns.value40
                                     + columns.value41) / count;
                        if (columns.value41 < min_value)
                        {
                            min_value = columns.value41;
                        }
                        if (columns.value41 > max_value)
                        {
                            max_value = columns.value41;
                        }
                        columns.select41 = true;
                    }
                    if (columns.value42 != null)
                    {
                        count = 12;
                        avg_value = (columns.value31 + columns.value32 + columns.value33 + columns.value34 + columns.value35
                                     + columns.value36 + columns.value37 + columns.value38 + columns.value39 + columns.value40
                                     + columns.value41 + columns.value42) / count;
                        if (columns.value42 < min_value)
                        {
                            min_value = columns.value42;
                        }
                        if (columns.value42 > max_value)
                        {
                            max_value = columns.value42;
                        }
                        columns.select42 = true;
                    }
                    if (columns.value43 != null)
                    {
                        count = 13;
                        avg_value = (columns.value31 + columns.value32 + columns.value33 + columns.value34 + columns.value35
                                     + columns.value36 + columns.value37 + columns.value38 + columns.value39 + columns.value40
                                     + columns.value41 + columns.value42 + columns.value43) / count;
                        if (columns.value43 < min_value)
                        {
                            min_value = columns.value43;
                        }
                        if (columns.value43 > max_value)
                        {
                            max_value = columns.value43;
                        }
                        columns.select43 = true;
                    }
                    if (columns.value44 != null)
                    {
                        count = 14;
                        avg_value = (columns.value31 + columns.value32 + columns.value33 + columns.value34 + columns.value35
                                     + columns.value36 + columns.value37 + columns.value38 + columns.value39 + columns.value40
                                     + columns.value41 + columns.value42 + columns.value43 + columns.value44) / count;
                        if (columns.value44 < min_value)
                        {
                            min_value = columns.value44;
                        }
                        if (columns.value44 > max_value)
                        {
                            max_value = columns.value44;
                        }
                        columns.select44 = true;
                    }
                    if (columns.value45 != null)
                    {
                        count = 15;
                        avg_value = (columns.value31 + columns.value32 + columns.value33 + columns.value34 + columns.value35
                                     + columns.value36 + columns.value37 + columns.value38 + columns.value39 + columns.value40
                                     + columns.value41 + columns.value42 + columns.value43 + columns.value44 + columns.value45) / count;
                        if (columns.value45 < min_value)
                        {
                            min_value = columns.value45;
                        }
                        if (columns.value45 > max_value)
                        {
                            max_value = columns.value45;
                        }
                        columns.select45 = true;
                    }
                    if (columns.value46 != null)
                    {
                        count = 16;
                        avg_value = (columns.value31 + columns.value32 + columns.value33 + columns.value34 + columns.value35
                                     + columns.value36 + columns.value37 + columns.value38 + columns.value39 + columns.value40
                                     + columns.value41 + columns.value42 + columns.value43 + columns.value44 + columns.value45
                                     + columns.value46) / count;
                        if (columns.value46 < min_value)
                        {
                            min_value = columns.value46;
                        }
                        if (columns.value46 > max_value)
                        {
                            max_value = columns.value46;
                        }
                        columns.select46 = true;
                    }
                    if (columns.value47 != null)
                    {
                        count = 17;
                        avg_value = (columns.value31 + columns.value32 + columns.value33 + columns.value34 + columns.value35
                                     + columns.value36 + columns.value37 + columns.value38 + columns.value39 + columns.value40
                                     + columns.value41 + columns.value42 + columns.value43 + columns.value44 + columns.value45
                                     + columns.value46 + columns.value47) / count;
                        if (columns.value47 < min_value)
                        {
                            min_value = columns.value47;
                        }
                        if (columns.value47 > max_value)
                        {
                            max_value = columns.value47;
                        }
                        columns.select47 = true;
                    }
                    if (columns.value48 != null)
                    {
                        count = 18;
                        avg_value = (columns.value31 + columns.value32 + columns.value33 + columns.value34 + columns.value35
                                     + columns.value36 + columns.value37 + columns.value38 + columns.value39 + columns.value40
                                     + columns.value41 + columns.value42 + columns.value43 + columns.value44 + columns.value45
                                     + columns.value46 + columns.value47 + columns.value48) / count;
                        if (columns.value48 < min_value)
                        {
                            min_value = columns.value48;
                        }
                        if (columns.value48 > max_value)
                        {
                            max_value = columns.value48;
                        }
                        columns.select48 = true;
                    }
                    if (columns.value49 != null)
                    {
                        count = 19;
                        avg_value = (columns.value31 + columns.value32 + columns.value33 + columns.value34 + columns.value35
                                     + columns.value36 + columns.value37 + columns.value38 + columns.value39 + columns.value40
                                     + columns.value41 + columns.value42 + columns.value43 + columns.value44 + columns.value45
                                     + columns.value46 + columns.value47 + columns.value48 + columns.value49) / count;
                        if (columns.value49 < min_value)
                        {
                            min_value = columns.value49;
                        }
                        if (columns.value49 > max_value)
                        {
                            max_value = columns.value49;
                        }
                        columns.select49 = true;
                    }
                    if (columns.value50 != null)
                    {
                        count = 20;
                        avg_value = (columns.value31 + columns.value32 + columns.value33 + columns.value34 + columns.value35
                                     + columns.value36 + columns.value37 + columns.value38 + columns.value39 + columns.value40
                                     + columns.value41 + columns.value42 + columns.value43 + columns.value44 + columns.value45
                                     + columns.value46 + columns.value47 + columns.value48 + columns.value49 + columns.value50) / count;
                        if (columns.value50 < min_value)
                        {
                            min_value = columns.value50;
                        }
                        if (columns.value50 > max_value)
                        {
                            max_value = columns.value50;
                        }
                        columns.select50 = true;
                    }
                    columns.value51 = min_value;
                    columns.value52 = max_value;
                    columns.value53 = avg_value;
                    FormulaBuilder(true);
                }
            }
            catch (Exception ex)
            { }
        }
        private void CalVariation(bool Compute)
        {
            try
            {
                if (MC.TestType != null && MC.TestType.Count > 0)
                {
                    decimal? temp_accuracy = null;
                    QMS_M009_B InputValue = MC.TestType.Where(X => X.test_type_code == TestTypeParameter).FirstOrDefault();

                    if (InputValue.formula_code == "SD10001")
                    {
                        List<QMS_T001_B> tempEntity = new List<QMS_T001_B>();
                        string hdr_name = "";
                        if (TestTypeEntity.Count > dgSelectedIndexTestType && dgSelectedIndexTestType >= 0)
                        {
                            if (TestTypeParameter != null)
                            {
                                List<QMS_T001_B> tempEntity_Code = (from o in TestTypeEntity where o.test_type_code == TestTypeParameter select o).ToList();
                                tempEntity = (from o in tempEntity_Code where o.test_type_code == tempEntity_Code[dgSelectedIndexTestType].test_type_code && o.deletion_id == tempEntity_Code[dgSelectedIndexTestType].deletion_id select o).ToList();
                                List<QMS_M009_B> temp_hdr = (from o in MC.TestType where o.test_type_code == TestTypeParameter select o).ToList();
                                hdr_name = temp_hdr[0].op_hdr;
                            }
                        }
                        if (MC.MasterValueEntity != null && MC.MasterValueEntity.Count > 0 && TestTypeEntity != null && TestTypeEntity.Count > 0 && MC.MasterHeader != null)
                        {
                            List<QMS_M009_J> tempMasterValue = new List<QMS_M009_J>();
                            tempMasterValue = MC.MasterValueEntity.Where(x => x.test_type_code == TestTypeParameter).ToList();
                            foreach (var q in tempMasterValue)
                            {
                                foreach (var p in tempEntity)
                                {
                                    if (Convert.ToInt32(p.value_id1) == q.value_id1 && Convert.ToInt32(p.value_id2) == q.value_id2 && Convert.ToInt32(p.value_id3) == q.value_id3 && Convert.ToInt32(p.value_id4) == q.value_id4 && Convert.ToInt32(p.value_id5) == q.value_id5 &&
                                        Convert.ToInt32(p.value_id6) == q.value_id6 && Convert.ToInt32(p.value_id7) == q.value_id7 && Convert.ToInt32(p.value_id8) == q.value_id8 && Convert.ToInt32(p.value_id9) == q.value_id9 && Convert.ToInt32(p.value_id10) == q.value_id10)
                                    {
                                        temp_accuracy = q.accuracy_up;
                                    }
                                }
                            }
                        }
                        foreach (var o in tempEntity)
                        {
                            if (hdr_name == "Average")
                            {
                                o.value61 = Convert.ToDecimal(o.value53) - Convert.ToDecimal(o.value23);
                            }
                            else if (hdr_name == "Minimum")
                            {
                                o.value61 = Convert.ToDecimal(o.value51) - Convert.ToDecimal(o.value21);
                            }
                            else if (hdr_name == "Maximum")
                            {
                                o.value61 = Convert.ToDecimal(o.value52) - Convert.ToDecimal(o.value22);
                            }

                            if (MasterEntity.accuracy_up_unit == "% of FS" || MasterEntity.accuracy_down_unit == "% of FS")
                            {
                                o.value62 = (o.value61 * 100) / Convert.ToDecimal(MasterEntity.upper_range); // Variation in %
                            }
                            else
                            {
                                o.value62 = o.value61 * 100 / o.value23; // Variation in %
                            }
                            // Accuracy Calculation for High Voltage Probe & Divider
                            if (MasterEntity.test_code == "HVC-Divid" || MasterEntity.test_code == "HVC-Probe")
                            {
                                if (temp_accuracy != null)
                                {
                                    o.m_accuracy = temp_accuracy * o.value53 / 100;
                                }
                            }
                            // Do not Calculate The accuracy for other Tests
                            else
                            {
                                o.m_accuracy = o.m_accuracy;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void FormulaBuilder(bool compute)
        {
            try
            {
                if (MC.TestType != null && MC.TestType.Count > 0)
                {
                    QMS_M009_B InputValue = MC.TestType.Where(X => X.test_type_code == TestTypeParameter).FirstOrDefault();
                    List<QMS_T001_B> tempEntity1 = new List<QMS_T001_B>();

                    #region Standard Deviation Calculation
                    if (InputValue.formula_code == "SD10001")
                    {
                        //int n = 0; //Count of readings -- n-1 is degree of freedom
                        decimal? x;

                        if (TestTypeEntity.Count > dgSelectedIndexTestType && dgSelectedIndexTestType >= 0)
                        {
                            if (TestTypeParameter != null)
                            {
                                List<QMS_T001_B> tempEntity_Code = (from o in TestTypeEntity where o.test_type_code == TestTypeParameter select o).ToList();
                                tempEntity1 = (from o in tempEntity_Code where o.test_type_code == tempEntity_Code[dgSelectedIndexTestType].test_type_code && o.deletion_id == tempEntity_Code[dgSelectedIndexTestType].deletion_id select o).ToList();
                            }
                        }

                        foreach (var o in tempEntity1)
                        {
                            o.degree_of_frdm = 0;
                            o.dev_value = 0;
                            if (o.value31 != null) //x
                            {
                                x = o.value31 - o.value53;
                                x = x * x;
                                o.degree_of_frdm++;
                                o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                            }
                            if (o.value32 != null) //x
                            {
                                x = o.value32 - o.value53;
                                x = x * x;
                                o.degree_of_frdm++;
                                o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                            }
                            if (o.value33 != null) //x
                            {
                                x = o.value33 - o.value53;
                                x = x * x;
                                o.degree_of_frdm++;
                                o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                            }
                            if (o.value34 != null) //x
                            {
                                x = o.value34 - o.value53;
                                x = x * x;
                                o.degree_of_frdm++;
                                o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                            }
                            if (o.value35 != null) //x
                            {
                                x = o.value35 - o.value53;
                                x = x * x;
                                o.degree_of_frdm++;
                                o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                            }
                            if (o.value36 != null) //x
                            {
                                x = o.value36 - o.value53;
                                x = x * x;
                                o.degree_of_frdm++;
                                o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                            }
                            if (o.value37 != null) //x
                            {
                                x = o.value37 - o.value53;
                                x = x * x;
                                o.degree_of_frdm++;
                                o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                            }
                            if (o.value38 != null) //x
                            {
                                x = o.value38 - o.value53;
                                x = x * x;
                                o.degree_of_frdm++;
                                o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                            }
                            if (o.value39 != null) //x
                            {
                                x = o.value39 - o.value53;
                                x = x * x;
                                o.degree_of_frdm++;
                                o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                            }
                            if (o.value40 != null) //x
                            {
                                x = o.value40 - o.value53;
                                x = x * x;
                                o.degree_of_frdm++;
                                o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                            }

                            decimal? m = Convert.ToDecimal((double)1 / (o.degree_of_frdm - 1));
                            o.dev_value = Convert.ToDecimal(Math.Sqrt((double)(m * o.dev_value)));
                            if (Convert.ToDecimal(o.dev_value) != 0)
                            {
                                o.dev_mean_value = o.dev_value / Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(o.degree_of_frdm)));

                                o.dev_per_value = o.dev_value * 100; // deviation in %

                                o.degree_of_frdm = o.degree_of_frdm - 1;
                            }
                        }
                    }
                    #endregion

                    #region ATS Calculation Part
                    else if (InputValue.formula_code == "L350" || InputValue.formula_code == "S350")
                    {
                        if (TestTypeEntity.Count > dgSelectedIndexTestType && dgSelectedIndexTestType >= 0)
                        {
                            if (TestTypeParameter != null)
                            {
                                List<QMS_T001_B> tempEntity_Code = (from o in TestTypeEntity where o.test_type_code == TestTypeParameter select o).ToList();
                                tempEntity1 = (from o in tempEntity_Code where o.test_type_code == tempEntity_Code[dgSelectedIndexTestType].test_type_code && o.column_value1 == tempEntity_Code[dgSelectedIndexTestType].column_value1 && o.deletion_id == tempEntity_Code[dgSelectedIndexTestType].deletion_id select o).ToList();
                            }
                        }

                        foreach (var o in tempEntity1)
                        {
                            o.value61 = o.value23 / o.value53;
                            o.value63 = o.value61 * o.value62;

                            o.value64 = (o.value23 - o.value53) / o.value23;
                            o.value65 = o.value64 * 100;
                        }
                    }

                    #endregion
                }
            }
            catch (Exception ex)
            { }
        }
        private void TypeA(object InputValue)
        {
            try
            {
                if ((bool)InputValue == true)
                {
                    List<QMS_T001_B> temp = new List<QMS_T001_B>();
                    temp = (from o in TestTypeEntity where o.test_type_code == TestTypeParameter select o).ToList();
                    if (temp.Count > dgSelectedIndexTestType && dgSelectedIndexTestType >= 0)
                    {
                        temp = (from o in temp where o.test_type_code == temp[dgSelectedIndexTestType].test_type_code && o.tm_id == temp[dgSelectedIndexTestType].tm_id && o.deletion_id == temp[dgSelectedIndexTestType].deletion_id select o).ToList();
                    }
                    TypeAEntity = new List<QMS_T001_B_UNC>();

                    #region Value Assigning
                    if (temp != null)
                    {
                        foreach (var o in temp)
                        {
                            if (o.value31 != null && o.select31 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value31,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                            if (o.value32 != null && o.select32 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value32,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                            if (o.value33 != null && o.select33 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value33,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                            if (o.value34 != null && o.select34 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value34,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                            if (o.value35 != null && o.select35 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value35,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                            if (o.value36 != null && o.select36 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value36,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                            if (o.value37 != null && o.select37 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value37,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                            if (o.value38 != null && o.select38 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value38,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                            if (o.value39 != null && o.select39 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value39,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                            if (o.value40 != null && o.select40 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value40,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                            if (o.value41 != null && o.select41 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value41,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                            if (o.value42 != null && o.select42 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value42,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                            if (o.value43 != null && o.select43 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value43,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                            if (o.value44 != null && o.select44 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value44,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                            if (o.value45 != null && o.select45 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value45,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                            if (o.value46 != null && o.select46 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value46,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                            if (o.value47 != null && o.select47 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value47,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                            if (o.value48 != null && o.select48 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value48,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                            if (o.value49 != null && o.select49 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value49,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                            if (o.value50 != null && o.select50 == true)
                            {
                                TypeAEntity.Add(new QMS_T001_B_UNC()
                                {
                                    column_value1 = o.column_value1,
                                    column_value2 = o.column_value2,
                                    column_value3 = o.column_value3,
                                    column_value4 = o.column_value4,
                                    column_value5 = o.column_value5,
                                    column_value6 = o.column_value6,
                                    column_value7 = o.column_value7,
                                    column_value8 = o.column_value8,
                                    column_value9 = o.column_value9,
                                    column_value10 = o.column_value10,
                                    value31 = o.value50,
                                    value51 = o.value51,
                                    value52 = o.value52,
                                    value53 = o.value53,
                                    degree_of_frdm = o.degree_of_frdm,
                                    dev_value = o.dev_value,
                                    dev_mean_value = o.dev_mean_value,
                                    dev_per_value = o.dev_per_value,
                                    unit_code = o.unit_code,
                                });
                            }
                        }
                        if (TypeAEntity.Count > 0 && temp.Count > 0)
                        {
                            TypeAEntity[0].image1 = MCTemp1.FormulaDetails[0].image1;
                            TypeAEntity[0].image2 = MCTemp1.FormulaDetails[0].image2;
                            TypeAEntity[0].m_resolution = temp[0].m_resolution;
                            TypeAEntity[0].m_uncertainty = temp[0].m_uncertainty;
                            TypeAEntity[0].coverage_factor = temp[0].coverage_factor;
                            TypeAEntity[0].conf_level = temp[0].conf_level;
                        }
                    }
                    foreach (var t in TypeAEntity)
                    {
                        t.value60 = t.value31 - t.value53;
                        t.value59 = t.value60 * t.value60;
                    }

                    #endregion

                    #region Standard Deviation Calculation

                    #region Calculate Average Value

                    decimal? min_value = 0;
                    decimal? max_value = 0;
                    decimal? avg_value = 0;

                    foreach (var columns in temp)
                    {
                        avg_value = 0;
                        if (TypeAEntity.Count > 0)
                        {
                            min_value = TypeAEntity[0].value31;
                            max_value = TypeAEntity[0].value31;
                            foreach (var o in TypeAEntity)
                            {
                                avg_value += o.value31;
                                if (o.value31 < min_value)
                                {
                                    min_value = o.value31;
                                }
                                if (o.value31 > max_value)
                                {
                                    max_value = o.value31;
                                }
                            }
                            avg_value = avg_value / TypeAEntity.Count;
                        }
                        columns.value51 = min_value;
                        columns.value52 = max_value;
                        columns.value53 = avg_value;

                        // Accuracy Calculation for High Voltage Probe & Divider
                        //if (MasterEntity.test_code == "HVC-Divid" || MasterEntity.test_code == "HVC-Probe")
                        //{
                        //    if (columns.m_accuracy != null)
                        //    {
                        //        columns.m_accuracy = columns.m_accuracy * columns.value53 / 100;
                        //    }
                        //}
                        //// Do not Calculate The accuracy for other Tests
                        //else
                        //{
                        //    columns.m_accuracy = columns.m_accuracy;
                        //}
                    }
                    #endregion

                    //int n = 0; //Count of readings -- n-1 is degree of freedom
                    decimal? x;

                    foreach (var o in temp)
                    {
                        o.degree_of_frdm = 0;
                        o.dev_value = 0;
                        if (o.value31 != null && o.select31 == true) //x
                        {
                            x = o.value31 - o.value53;
                            x = x * x;
                            o.degree_of_frdm++;
                            o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                        }
                        if (o.value32 != null && o.select32 == true) //x
                        {
                            x = o.value32 - o.value53;
                            x = x * x;
                            o.degree_of_frdm++;
                            o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                        }
                        if (o.value33 != null && o.select33 == true) //x
                        {
                            x = o.value33 - o.value53;
                            x = x * x;
                            o.degree_of_frdm++;
                            o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                        }
                        if (o.value34 != null && o.select34 == true) //x
                        {
                            x = o.value34 - o.value53;
                            x = x * x;
                            o.degree_of_frdm++;
                            o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                        }
                        if (o.value35 != null && o.select35 == true) //x
                        {
                            x = o.value35 - o.value53;
                            x = x * x;
                            o.degree_of_frdm++;
                            o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                        }
                        if (o.value36 != null && o.select36 == true) //x
                        {
                            x = o.value36 - o.value53;
                            x = x * x;
                            o.degree_of_frdm++;
                            o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                        }
                        if (o.value37 != null && o.select37 == true) //x
                        {
                            x = o.value37 - o.value53;
                            x = x * x;
                            o.degree_of_frdm++;
                            o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                        }
                        if (o.value38 != null && o.select38 == true) //x
                        {
                            x = o.value38 - o.value53;
                            x = x * x;
                            o.degree_of_frdm++;
                            o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                        }
                        if (o.value39 != null && o.select39 == true) //x
                        {
                            x = o.value39 - o.value53;
                            x = x * x;
                            o.degree_of_frdm++;
                            o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                        }
                        if (o.value40 != null && o.select40 == true) //x
                        {
                            x = o.value40 - o.value53;
                            x = x * x;
                            o.degree_of_frdm++;
                            o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                        }
                        if (o.value41 != null && o.select41 == true) //x
                        {
                            x = o.value41 - o.value53;
                            x = x * x;
                            o.degree_of_frdm++;
                            o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                        }
                        if (o.degree_of_frdm != 0 && o.degree_of_frdm != 1)
                        {
                            decimal? m;
                            m = Convert.ToDecimal((double)1 / (o.degree_of_frdm - 1));
                            o.dev_value = Convert.ToDecimal(Math.Sqrt((double)(m * o.dev_value)));
                        }
                        if (Convert.ToDecimal(o.dev_value) != 0)
                        {
                            o.dev_mean_value = o.dev_value / Convert.ToDecimal(Math.Sqrt(Convert.ToDouble(o.degree_of_frdm)));

                            o.dev_per_value = o.dev_value * 100;///Convert.ToDecimal(MasterEntity.range); // deviation in %

                            o.degree_of_frdm = o.degree_of_frdm - 1;
                        }
                    }
                    if (temp.Count > 0)
                    {
                        foreach (var item in TypeAEntity)
                        {
                            item.dev_value = temp[0].dev_value;
                            item.dev_mean_value = temp[0].dev_mean_value;
                            item.dev_per_value = temp[0].dev_per_value;
                            item.degree_of_frdm = temp[0].degree_of_frdm;
                            item.m_accuracy = temp[0].m_accuracy;
                        }
                    }

                    foreach (var o in temp)
                    {
                        decimal? U1 = 0, U2 = 0, U3 = 0, U4 = 0, Ua = 0, Uc;
                        o.sensitivity_coeff = 1;
                        if (o.m_uncertainty != null)
                        {
                            U1 = o.m_uncertainty / 2;
                            U1 = U1 * o.sensitivity_coeff;    // Sensitivity Coefficient = 1;
                        }
                        if (o.m_accuracy != null)
                        {
                            U2 = o.m_accuracy / Convert.ToDecimal(Math.Sqrt((double)3));
                            U2 = U2 * o.sensitivity_coeff;    // Sensitivity Coefficient = 1;
                        }
                        if (o.m_resolution != null)
                        {
                            decimal? u3 = Convert.ToDecimal(o.m_resolution) / 2;
                            U3 = u3 / Convert.ToDecimal(Math.Sqrt((double)3));
                            U3 = U3 * o.sensitivity_coeff;    // Sensitivity Coefficient = 1;
                        }
                        if (MasterEntity.resolution != null)
                        {
                            decimal? u4 = Convert.ToDecimal(MasterEntity.resolution) / 2;
                            U4 = u4 / Convert.ToDecimal(Math.Sqrt((double)3));
                            U4 = U4 * o.sensitivity_coeff;    // Sensitivity Coefficient = 1;
                        }
                        Ua = o.dev_mean_value;
                        Ua = Ua * o.sensitivity_coeff;    // Sensitivity Coefficient = 1;

                        o.combine_uncertainty = Convert.ToDecimal(Math.Sqrt(Convert.ToDouble((U1 * U1) + (U2 * U2) + (U3 * U3) + (U4 * U4) + (Ua * Ua))));
                        o.eff_degree_of_frdm = Convert.ToDecimal(4 * Math.Pow(Convert.ToDouble(o.combine_uncertainty / Ua), 4));
                        o.expanded_uncertainty = o.coverage_factor * o.combine_uncertainty;
                        if (MasterEntity.test_code == "HVC-Probe" || MasterEntity.test_code == "HVC-Divid")
                        {
                            o.expanded_uncertainty_per = o.expanded_uncertainty * 100 / Convert.ToDecimal(o.value53);
                        }
                        else if (o.unit_code == "%")
                        {
                            o.expanded_uncertainty_per = o.expanded_uncertainty;
                        }
                        else
                        {
                            o.expanded_uncertainty_per = o.expanded_uncertainty * 100 / Convert.ToDecimal(o.value53);
                        }
                    }

                    DisplayExpUncertainty();
                    #endregion
                }
            }
            catch (Exception ex)
            { }
        }
        private void TypeB(object InputValue)
        {
            try
            {
                if (TestTypeEntity.Count > 0 && MasterEquipmentEntity.Count > 0)
                {
                    if ((TestTypeEntity[dgSelectedIndexTestType].m_accuracy == null) && (TestTypeEntity[dgSelectedIndexTestType].m_resolution == null) && (TestTypeEntity[dgSelectedIndexTestType].m_uncertainty == null))
                    {
                        MasterEquipmentEntity[0].report_parameter1 = "U1";
                    }
                    else if ((TestTypeEntity[dgSelectedIndexTestType].m_accuracy != null) && (TestTypeEntity[dgSelectedIndexTestType].m_resolution == null) && (TestTypeEntity[dgSelectedIndexTestType].m_uncertainty == null))
                    {
                        MasterEquipmentEntity[0].report_parameter1 = "U2";
                    }
                    else if ((TestTypeEntity[dgSelectedIndexTestType].m_accuracy == null) && (TestTypeEntity[dgSelectedIndexTestType].m_resolution != null) && (TestTypeEntity[dgSelectedIndexTestType].m_uncertainty == null))
                    {
                        MasterEquipmentEntity[0].report_parameter1 = "U2";
                    }
                    else if ((TestTypeEntity[dgSelectedIndexTestType].m_accuracy == null) && (TestTypeEntity[dgSelectedIndexTestType].m_resolution == null) && (TestTypeEntity[dgSelectedIndexTestType].m_uncertainty != null))
                    {
                        MasterEquipmentEntity[0].report_parameter1 = "U2";
                    }
                    else if ((TestTypeEntity[dgSelectedIndexTestType].m_accuracy != null) && (TestTypeEntity[dgSelectedIndexTestType].m_resolution != null) && (TestTypeEntity[dgSelectedIndexTestType].m_uncertainty == null))
                    {
                        MasterEquipmentEntity[0].report_parameter1 = "U3";
                    }
                    else if ((TestTypeEntity[dgSelectedIndexTestType].m_accuracy != null) && (TestTypeEntity[dgSelectedIndexTestType].m_resolution == null) && (TestTypeEntity[dgSelectedIndexTestType].m_uncertainty != null))
                    {
                        MasterEquipmentEntity[0].report_parameter1 = "U3";
                    }
                    else if ((TestTypeEntity[dgSelectedIndexTestType].m_accuracy == null) && (TestTypeEntity[dgSelectedIndexTestType].m_resolution != null) && (TestTypeEntity[dgSelectedIndexTestType].m_uncertainty != null))
                    {
                        MasterEquipmentEntity[0].report_parameter1 = "U3";
                    }
                    else if ((TestTypeEntity[dgSelectedIndexTestType].m_accuracy != null) && (TestTypeEntity[dgSelectedIndexTestType].m_resolution != null) && (TestTypeEntity[dgSelectedIndexTestType].m_uncertainty != null))
                    {
                        MasterEquipmentEntity[0].report_parameter1 = "U4";
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void DisplayExpUncertainty()
        {
            List<QMS_T001_B> temp = new List<QMS_T001_B>();
            temp = (from o in TestTypeEntity where o.test_type_code == TestTypeParameter select o).ToList();
            if (temp.Count > dgSelectedIndexTestType && dgSelectedIndexTestType >= 0)
            {
                temp = (from o in temp where o.test_type_code == temp[dgSelectedIndexTestType].test_type_code && o.tm_id == temp[dgSelectedIndexTestType].tm_id && o.deletion_id == temp[dgSelectedIndexTestType].deletion_id select o).ToList();
            }
            foreach (var o in temp)
            {
                MasterEntity.avg_value = o.value53;
                MasterEntity.dev_value = o.dev_value;
                MasterEntity.dev_mean_value = o.dev_mean_value;
                MasterEntity.degree_of_frdm = o.degree_of_frdm;
                MasterEntity.combine_uncertainty = o.combine_uncertainty;
                MasterEntity.eff_degree_of_frdm = o.eff_degree_of_frdm;
                MasterEntity.coverage_factor = o.coverage_factor;
                MasterEntity.conf_level = o.conf_level;
                MasterEntity.expanded_uncertainty = o.expanded_uncertainty;
                MasterEntity.unit_code = o.unit_code;
                if (MasterEntity.test_code == "HVC-Probe" || MasterEntity.test_code == "HVC-Divid")
                {
                    MasterEntity.expanded_uncertainty_per = o.expanded_uncertainty_per;
                }
                else
                {
                    MasterEntity.expanded_uncertainty_per = o.expanded_uncertainty_per;
                }
            }
        }

        #endregion

        #region Constructor
        public QMS_T001_VM() : base()
        {
            CursorControl.SetBusyState();
            MasterEntity = new QMS_T001();
            TestTypeEntity = new ObservableCollection<QMS_T001_B>();
            ParameterEntity = new ObservableCollection<QMS_M003_B>();
            TaskListEntity = new ObservableCollection<QMS_T001_E>();
            MasterEquipmentEntity = new ObservableCollection<QMS_T001_A>();
            EnvCondEntity = new ObservableCollection<QMS_T001_F>();
            MC = new MultipleContext_QMS_T001();
            MCTemp = new MultipleContext_QMS_T001();
            MCTemp1 = new MultipleContext_QMS_T001();
            QMS_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            QMS_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_TestType);
            QMS_T001_F.ModelEntityUpdated += new EventHandler(ModelUpdated_EnvCond);
            LoadInitialData();
        }
        public QMS_T001_VM(string ts_code) : base()
        {
            CursorControl.SetBusyState();
            this.ts_code_vm = ts_code;
            MasterEntity = new QMS_T001();
            TestTypeEntity = new ObservableCollection<QMS_T001_B>();
            ParameterEntity = new ObservableCollection<QMS_M003_B>();
            TaskListEntity = new ObservableCollection<QMS_T001_E>();
            MasterEquipmentEntity = new ObservableCollection<QMS_T001_A>();
            EnvCondEntity = new ObservableCollection<QMS_T001_F>();
            MC = new MultipleContext_QMS_T001();
            MCTemp = new MultipleContext_QMS_T001();
            MCTemp1 = new MultipleContext_QMS_T001();
            QMS_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            QMS_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_TestType);
            QMS_T001_F.ModelEntityUpdated += new EventHandler(ModelUpdated_EnvCond);
            LoadInitialData();
        }
        public QMS_T001_VM(string ts_code, string doc_no) : base()
        {
            CursorControl.SetBusyState();
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            MasterEntity = new QMS_T001();
            TestTypeEntity = new ObservableCollection<QMS_T001_B>();
            ParameterEntity = new ObservableCollection<QMS_M003_B>();
            TaskListEntity = new ObservableCollection<QMS_T001_E>();
            MasterEquipmentEntity = new ObservableCollection<QMS_T001_A>();
            EnvCondEntity = new ObservableCollection<QMS_T001_F>();
            MC = new MultipleContext_QMS_T001();
            MCTemp = new MultipleContext_QMS_T001();
            MCTemp1 = new MultipleContext_QMS_T001();
            QMS_T001.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            QMS_T001_B.ModelEntityUpdated += new EventHandler(ModelUpdated_TestType);
            QMS_T001_F.ModelEntityUpdated += new EventHandler(ModelUpdated_EnvCond);
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
                //if (doc_no_vm != null && ts_code_vm != null)
                //{
                //    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                //    //isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                //    AppSessionState.ViewOtherRecordAllowed = true;
                //}
                if (MCTemp1.DocTypeInfo != null && MCTemp1.DocTypeInfo.Count > 0)
                {
                    if (doc_no_vm != null && AppSessionState.TransactionCode == MCTemp1.DocTypeInfo[0].TranCode && AppSessionState.TransParameter.ToString() == "FromDue")
                    {
                        LoadDocumentByRefDocNumber(AppSessionState.TransValue);
                        
                    }
                    else if (doc_no_vm != null && AppSessionState.TransactionCode == MCTemp1.DocTypeInfo[0].TranCode && AppSessionState.TransParameter.ToString() == "FromCalender")
                    {
                        LoadDocumentByDocumentNumber(AppSessionState.TransValue, "DocumentNo");
                        isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                    }
                    else if (doc_no_vm != null && AppSessionState.TransactionCode == MCTemp1.DocTypeInfo[0].TranCode)
                    {
                        LoadDocumentByDocumentNumber(AppSessionState.TransValue, "DocumentNo");
                    }

                    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                    AppSessionState.TransValue = null;
                    AppSessionState.TransParameter = null;
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
        private void LoadInitialData()
        {
            try
            {
                #region Commands
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
                CmdLoadDocumentByRefDocNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByRefDocNumber(items); });
                CmdAddEmployee = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmployee(items); });
                CmdAddAuthEmployee = new RelayCommand<object>(items => { if (items == null) { return; } InsertAuthEmployee(items); });
                CmdAddEqCode = new RelayCommand<object>(items => { if (items == null) { return; } InsertEquipementCode(items, true, true, true); });
                CmdAddTracibility = new RelayCommand<object>(items => { if (items == null) { return; } InsertTracibility(items, true, true, true); });
                CmdAddRig = new RelayCommand<object>(items => { if (items == null) { return; } InsertRig(items); });
                CmdAddUOM = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOM(cmdPara, false, false, true); });
                cmdDeleteDataGridRowParameter = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowParameter(cmdPara); });
                cmdDeleteDataGridRowTestType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowTestType(cmdPara); });
                CmdAddParaValue = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertParaValue(cmdPara, false, false, true); });
                CmdAddColumnValue1 = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertColumnValue1(cmdPara, false, false, true); });
                CmdAddColumnValue2 = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertColumnValue2(cmdPara, false, false, true); });
                CmdAddColumnValue3 = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertColumnValue3(cmdPara, false, false, true); });
                CmdAddColumnValue4 = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertColumnValue4(cmdPara, false, false, true); });
                CmdAddColumnValue5 = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertColumnValue5(cmdPara, false, false, true); });
                CmdAddColumnValue6 = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertColumnValue6(cmdPara, false, false, true); });
                CmdAddColumnValue7 = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertColumnValue7(cmdPara, false, false, true); });
                CmdAddColumnValue8 = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertColumnValue8(cmdPara, false, false, true); });
                CmdAddColumnValue9 = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertColumnValue9(cmdPara, false, false, true); });
                CmdAddColumnValue10 = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertColumnValue10(cmdPara, false, false, true); });
                CmdAddTaskList = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTaskList(cmdPara, false, false, true); });
                cmdDeleteDataGridRowTaskList = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowTaskList(cmdPara); });
                cmdDeleteDataGridRowMasterEquipment = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowMasterEquipment(cmdPara); });
                CmdCustReport = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } CustReport(cmdPara); });
                CmdUncertaintyBudgetReport = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } UncertaintyBudgetReport(cmdPara); });
                CmdAddEnvCond = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertEnvCond(cmdPara, false, false, true); });
                cmdDeleteDataGridRowEnvCondition = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowEnvCond(cmdPara); });
                CmdAddSiteEmployee = new RelayCommand<object>(items => { if (items == null) { return; } InsertSiteEmployee(items); });

                #endregion
                MasterEntity.doc_cat = "CC";
                MasterEntity.doc_type = "CC";
                string Request = "LoadInitialData" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type;
                MCTemp1 = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_T001>(MCTemp1, Request, "CalibrationView", "QMS", "LoadInitialData", 0, "");

                FlipGridData = MCTemp1.DocumentDataFlipGrid;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                //DataGridCollection.Filter = new Predicate<object>(Filter);

                #region AutoSuggest Initialisation

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpName ?? "");
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASEmployee = new AutoSuggestTextViewModel<dynamic>(MCTemp1.Employees, TheFilter, SuggestedValue, "EmpName", true);
                ASEmployee.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpName ?? "");
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASAuthEmployee = new AutoSuggestTextViewModel<dynamic>(MCTemp1.Employees, TheFilter, SuggestedValue, "EmpName", true);
                ASAuthEmployee.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M010_P)x).tr_name ?? "");
                TheFilter = (o, prefix) => (((QMS_M010_P)o).tr_name ?? "").ToLower().Contains(prefix.ToString().ToLower()) || ((QMS_M010_P)o).tr_code.ToLower().Contains(prefix.ToString().ToLower());
                ASTracibility = new AutoSuggestTextViewModel<dynamic>(MCTemp1.Tracibility, TheFilter, SuggestedValue, "tr_name", true);
                ASTracibility.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M008_P)x).rig_name ?? "");
                TheFilter = (o, prefix) => (((QMS_M008_P)o).rig_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M008_P)o).rig_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASRig = new AutoSuggestTextViewModel<dynamic>(MCTemp1.Rig, TheFilter, SuggestedValue, "rig_name", true);
                ASRig.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_F)x).para_value ?? "");
                TheFilter = (o, prefix) => (((QMS_M009_F)o).para_value ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault1 = new AutoSuggestTextViewModel<dynamic>(MCTemp1.Parameter, TheFilter, SuggestedValue, "para_value", "para_value", true);
                ASDefault1.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault1.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MCTemp1.UnitCode, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M024Flip)x).tl_code ?? "");
                TheFilter = (o, prefix) => (((QMS_M024Flip)o).tl_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault3 = new AutoSuggestTextViewModel<dynamic>(MCTemp1.TaskList, TheFilter, SuggestedValue, "tl_code", "tl_code", true);
                ASDefault3.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault3.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M024Flip)x).tl_code ?? "");
                TheFilter = (o, prefix) => (((QMS_M024Flip)o).tl_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M024Flip)o).short_text ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASTaskList = new AutoSuggestTextViewModel<dynamic>(MCTemp1.TaskList, TheFilter, SuggestedValue, "tl_code", "tl_code", true);
                ASTaskList.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASUnitCode = new AutoSuggestTextViewModel<dynamic>(MCTemp1.UnitCode, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASUnitCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M003_P)x).inst_code ?? "");
                TheFilter = (o, prefix) => (((QMS_M003_P)o).inst_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault4 = new AutoSuggestTextViewModel<dynamic>(MCTemp1.EqCode, TheFilter, SuggestedValue, "ItemCode", "inst_code", true);
                ASDefault4.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault4.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M003_P)x).inst_code ?? "");
                TheFilter = (o, prefix) => (((QMS_M003_P)o).inst_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASEqCode = new AutoSuggestTextViewModel<dynamic>(MCTemp1.EqCode, TheFilter, SuggestedValue, "ItemCode", "inst_code", true);
                ASEqCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M017)x).env_code ?? "");
                TheFilter = (o, prefix) => (((QMS_M017)o).env_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M017)o).env_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault5 = new AutoSuggestTextViewModel<dynamic>(MCTemp1.StdEnvCond, TheFilter, SuggestedValue, "env_code", "env_code", true);
                ASDefault5.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault5.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M017)x).env_code ?? "");
                TheFilter = (o, prefix) => (((QMS_M017)o).env_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M017)o).env_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASStdEnvCond = new AutoSuggestTextViewModel<dynamic>(MCTemp1.StdEnvCond, TheFilter, SuggestedValue, "env_code", "env_code", true);
                ASStdEnvCond.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASEnvValueUnitCode = new AutoSuggestTextViewModel<dynamic>(MCTemp1.UnitCode, TheFilter, SuggestedValue, "std_value_unit", "unit_code", true);
                ASEnvValueUnitCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpName ?? "");
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASSiteEmployee = new AutoSuggestTextViewModel<dynamic>(MCTemp1.Employees, TheFilter, SuggestedValue, "EmpName", true);
                ASSiteEmployee.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASParaValueUnitCode = new AutoSuggestTextViewModel<dynamic>(MCTemp1.UnitCode, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASParaValueUnitCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_F)x).para_name ?? "");
                TheFilter = (o, prefix) => (((QMS_M009_F)o).para_name ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M009_F)o).para_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASParaName = new AutoSuggestTextViewModel<dynamic>(MCTemp1.Parameter, TheFilter, SuggestedValue, "para_name", "para_name", true);
                ASParaName.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion

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
        private void DefaultValues()
        {
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.active = true;
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.cal_date = DateTime.Now;
            MasterEntity.t_status = "Draft";
            MasterEntity.doc_cat = "CC";
            MasterEntity.doc_type = "CC";
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
            try
            {
                CursorControl.SetBusyState();
                string Request = "";
                QMS_T001Flip ParameterEntityObject = new QMS_T001Flip();

                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterObject;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_T001>(MCTemp, Request, "CalibrationView", "QMS", "LoadDocumentByDocumentNumber", 0, "");
                }
                else if (((IEnumerable)ParameterObject).Cast<QMS_T001Flip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<QMS_T001Flip>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.doc_no + "!@" + ParameterEntityObject.test_code;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_T001>(MCTemp, Request, "CalibrationView", "QMS", "LoadDocumentByDocumentNumber", 0, "");
                }
                if (MCTemp.MasterEntity.Count > 0)
                {
                    MasterEntity = MCTemp.MasterEntity[0];
                }
                TestTypeEntity = MCTemp.TestTypeEntity;
                ParameterEntity = MCTemp.ParameterEntity;
                MC.TestType = MCTemp.TestType;
                MC.BenchHeader = MCTemp.BenchHeader;
                MC.HeaderValue = MCTemp.HeaderValue;
                MC.MasterHeader = MCTemp.MasterHeader;
                //MC.MasterValueEntity = MCTemp.MasterValueEntity;
                MC.UnitHeader = MCTemp.UnitHeader;
                TaskListEntity = MCTemp.TaskListEntity;
                MasterEquipmentEntity = MCTemp.MasterEquipment;
                EnvCondEntity = MCTemp.EnvCondEntity;
                MC.MasterValueEntity = MCTemp.MasterValueEntity;
                MC.UncertaintyScope = MCTemp.UncertaintyScope;

                List<QMS_M024Flip> TempTasks = MCTemp1.TaskList;
                foreach (var item in TaskListEntity)
                {
                    QMS_M024Flip task = (from o in MCTemp1.TaskList where o.tl_code == item.tl_code select o).FirstOrDefault();
                    TempTasks.Remove(task);
                }

                if (TestTypeEntity.Count > 0)
                {
                    for (mn = 1; mn <= TestTypeEntity.Count; mn++)
                    {
                        TestTypeEntity[mn - 1].deletion_id = mn;
                    }
                }
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M024Flip)x).tl_code ?? "");
                TheFilter = (o, prefix) => (((QMS_M024Flip)o).tl_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M024Flip)o).short_text ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASTaskList = new AutoSuggestTextViewModel<dynamic>(TempTasks, TheFilter, SuggestedValue, "tl_code", "tl_code", false);
                ASTaskList.AutoSuggestVM.IsEmptyValueAllowed = true;

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
                TestTypeParameter = null;
                MasterEntity.ts_code = ts_code_vm;
                var msg = new NotificationMessage("QMS_T001_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
                SetPopupSuggestionDataAfterLoad();
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
        private void LoadDocumentByRefDocNumber(object ParameterObject)
        {
            try
            {
                CursorControl.SetBusyState();
                if (ParameterObject != null)
                {
                    if (AppSessionState.TransValue == null)
                    {
                        string barcode = ParameterObject.ToString();
                        if (barcode.Length >= 10)
                        {
                            string Request = "LoadDocumentByRefDocNumber" + "!@" + ParameterObject;
                            ParameterEntity = new ObservableCollection<QMS_M003_B>();
                            MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_T001>(MC, Request, "CalibrationView", "QMS", "LoadDocumentByRefDocNumber", 0, "");
                        }
                    }
                    else
                    {
                        string Request = "LoadDocumentByRefDocNumber" + "!@" + ParameterObject;
                        MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_T001>(MC, Request, "CalibrationView", "QMS", "LoadDocumentByRefDocNumber", 0, "");
                    }

                    #region AutoSuggest Initialisation

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId ?? "");
                    TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M024_P)o).EmpName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                    ASParaValue = new AutoSuggestTextViewModel<dynamic>(MC.Employees, TheFilter, SuggestedValue, "EmpId", false);
                    ASParaValue.AutoSuggestVM.IsEmptyValueAllowed = true;
                    ASParaValue.AutoSuggestVM.IsFreeTextAllowed = true;

                    //SuggestedValue = new ValueConverter(x => x == null ? "" : ((Inst_Pur_Details_P)x).po_no ?? "");
                    //TheFilter = (o, prefix) => ((Inst_Pur_Details_P)o).po_no.ToLower().Contains(prefix.ToString().ToLower());
                    //ASPO = new AutoSuggestTextViewModel<dynamic>(MC.PurOrder, TheFilter, SuggestedValue, "po_no", false);
                    //ASPO.AutoSuggestVM.IsEmptyValueAllowed = true;

                    #endregion

                    #region RefDocCollection

                    if (MC.RefDocCollection.Count > 0)
                    {
                        MasterEntity.barcode = MC.RefDocCollection[0].barcode;
                        MasterEntity.ref_doc_no = MC.RefDocCollection[0].doc_no;
                        MasterEntity.PartyId = MC.RefDocCollection[0].PartyId;
                        MasterEntity.PartyNm = MC.RefDocCollection[0].PartyNm;
                        MasterEntity.inst_code = MC.RefDocCollection[0].inst_code;
                        MasterEntity.inst_name = MC.RefDocCollection[0].inst_name;
                        MasterEntity.test_code = MC.RefDocCollection[0].test_code;
                        MasterEntity.cal_freq = Convert.ToInt32(MC.RefDocCollection[0].cal_freq);
                        MasterEntity.cal_period = MC.RefDocCollection[0].cal_period;
                        MasterEntity.last_date = MC.RefDocCollection[0].last_date;
                        MasterEntity.next_date = MC.RefDocCollection[0].next_date;
                        MasterEntity.due_date = MC.RefDocCollection[0].due_date;
                        MasterEntity.serv_type = MC.RefDocCollection[0].serv_type;
                        MasterEntity.cal_type = MC.RefDocCollection[0].cal_type;
                        MasterEntity.lab_code = MC.RefDocCollection[0].lab_code;
                        MasterEntity.lab_name = MC.RefDocCollection[0].lab_name;
                        MasterEntity.po_no = MC.RefDocCollection[0].po_no;
                        MasterEntity.resolution = MC.RefDocCollection[0].resolution;
                        MasterEntity.insp_cat = MC.RefDocCollection[0].insp_cat;
                        MasterEntity.EmpId = MC.RefDocCollection[0].assigned_to;
                        MasterEntity.EmpNm = MC.RefDocCollection[0].assigned_to_name;
                        //scalar
                        MasterEntity.test_name = MC.RefDocCollection[0].test_name;
                        MasterEntity.inst_id = MC.RefDocCollection[0].inst_id;
                        MasterEntity.inst_make = MC.RefDocCollection[0].inst_make;
                        MasterEntity.inst_srno = MC.RefDocCollection[0].inst_srno;
                        MasterEntity.model_no = MC.RefDocCollection[0].model_no;
                        MasterEntity.least_count = MC.RefDocCollection[0].least_count;
                        MasterEntity.range = MC.RefDocCollection[0].range;
                        MasterEntity.accuracy_up = MC.RefDocCollection[0].accuracy_up;
                        MasterEntity.cont_per_name = MC.RefDocCollection[0].cont_per_name;
                        MasterEntity.insp_lot_no = MC.RefDocCollection[0].insp_lot_no;
                        MasterEntity.cust_name = MC.RefDocCollection[0].cust_name;
                        MasterEntity.range_unit = MC.RefDocCollection[0].range_unit;
                        MasterEntity.accuracy_up_unit = MC.RefDocCollection[0].accuracy_up_unit;
                        MasterEntity.least_count_unit = MC.RefDocCollection[0].least_count_unit;
                        MasterEntity.resolution_unit = MC.RefDocCollection[0].resolution_unit;
                        MasterEntity.upper_range = MC.RefDocCollection[0].upper_range;
                        MasterEntity.lower_range = MC.RefDocCollection[0].lower_range;
                        MasterEntity.upper_range_unit = MC.RefDocCollection[0].upper_range_unit;
                        MasterEntity.lower_range_unit = MC.RefDocCollection[0].lower_range_unit;
                        MasterEntity.accuracy_down = MC.RefDocCollection[0].accuracy_down;
                        MasterEntity.accuracy_down_unit = MC.RefDocCollection[0].accuracy_down_unit;
                    }
                    #endregion

                    #region For Additional Parameters
                    List<QMS_M009_F> temp = MC.Parameter.GroupBy(x => x.para_code).Select(x => x.FirstOrDefault()).ToList();
                    foreach (var item in temp)
                    {
                        QMS_M003_B tempParaEntity = new QMS_M003_B();
                        tempParaEntity.para_code = item.para_code;
                        tempParaEntity.para_name = item.para_name;
                        tempParaEntity.unit_code = item.unit_code;
                        tempParaEntity.allow_null = item.allow_null;
                        tempParaEntity.inst_code = MasterEntity.inst_code;

                        List<QMS_M009_F> temp1 = (from o in MC.Parameter where o.para_code == item.para_code select o).ToList();
                        if (temp1.Count == 1)
                        {
                            tempParaEntity.value_code = item.value_code;
                            tempParaEntity.para_value = item.para_value;
                            tempParaEntity.unit_code = item.unit_value;
                            tempParaEntity.allow_null = item.allow_null;
                            tempParaEntity.inst_code = MasterEntity.inst_code;
                        }

                        ParameterEntity.Add(tempParaEntity);
                        FilterParaValueCollection();
                    }
                    #endregion

                    #region Task List
                    TaskListEntity = MC.TaskListEntity;

                    List<QMS_M024Flip> TempTasks = MCTemp1.TaskList;
                    foreach (var item in TaskListEntity)
                    {
                        QMS_M024Flip task = (from o in MCTemp1.TaskList where o.tl_code == item.tl_code select o).FirstOrDefault();
                        TempTasks.Remove(task);
                    }

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M024Flip)x).tl_code ?? "");
                    TheFilter = (o, prefix) => (((QMS_M024Flip)o).tl_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M024Flip)o).short_text ?? "").ToLower().Contains(prefix.ToString().ToLower());
                    ASTaskList = new AutoSuggestTextViewModel<dynamic>(TempTasks, TheFilter, SuggestedValue, "tl_code", "tl_code", false);
                    ASTaskList.AutoSuggestVM.IsEmptyValueAllowed = true;

                    #endregion
                    MasterEntity.ts_code = ts_code_vm;
                    SetPopupSuggestionDataAfterLoad();
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
        private void InsertEmployee(object InputValue)
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
                        { POPUPEntityObject = MCTemp1.Employees.Where(x => x.EmpName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; } 
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M024_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.EmpId = POPUPEntityObject.EmpId;
                    MasterEntity.EmpNm = POPUPEntityObject.EmpName;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertAuthEmployee(object InputValue)
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
                        { POPUPEntityObject = MCTemp1.Employees.Where(x => x.EmpName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M024_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.authEmpId = POPUPEntityObject.EmpId;
                    MasterEntity.authEmpNm = POPUPEntityObject.EmpName;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertEquipementCode(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                        {
                            POPUPEntityObject = MCTemp1.EqCode.Where(x => x.inst_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
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
                    //var InputValueIfExists = MasterEquipmentEntity.Where(x => x.ItemCode == POPUPEntityObject.inst_code).FirstOrDefault();
                    var IndexOfExistValue = -1;  // MasterEquipmentEntity.IndexOf(MasterEquipmentEntity.Where(X => X.ItemCode == POPUPEntityObject.inst_code).FirstOrDefault());

                    //if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && MasterEquipmentEntity.Count == dgSelectedIndexMasterEquipment)
                    //{
                    //    MasterEquipmentEntity.Add(new QMS_T001_A()
                    //    {
                    //        id = 0,
                    //        ItemCode = POPUPEntityObject.inst_code,
                    //        ItemName = POPUPEntityObject.inst_name,
                    //        range = POPUPEntityObject.range,
                    //        resolution = POPUPEntityObject.resolution,
                    //        accuracy = POPUPEntityObject.accuracy,
                    //        due_date = POPUPEntityObject.due_date,
                    //        tr_code = POPUPEntityObject.tr_code,
                    //        tr_name = POPUPEntityObject.tr_name,

                    //        active = true,
                    //        t_status = "Draft",
                    //        location_Id = AppSessionState.location_Id,
                    //        comp_code = AppSessionState.comp_code,
                    //        add_by = AppSessionState.UserID,
                    //        editby = AppSessionState.UserID,
                    //        add_date = DateTime.Now,
                    //        edit_date = DateTime.Now,
                    //        user_source1 = AppSessionState.UserSource1,
                    //        user_source2 = AppSessionState.UserSource2,

                    //});

                    //}
                    //else 

                    if (dgSelectedIndexMasterEquipment >= 0 && MasterEquipmentEntity.Count > dgSelectedIndexMasterEquipment)
                    {
                        if (MasterEquipmentEntity[dgSelectedIndexMasterEquipment].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                        {
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].ItemCode = POPUPEntityObject.inst_code;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].ItemName = POPUPEntityObject.inst_name;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].range = POPUPEntityObject.range;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].resolution = POPUPEntityObject.resolution;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].accuracy_up = POPUPEntityObject.accuracy_up;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].due_date = POPUPEntityObject.due_date;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].tr_code = POPUPEntityObject.tr_code;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].tr_name = POPUPEntityObject.tr_name;

                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].location_Id = AppSessionState.location_Id;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].comp_code = AppSessionState.comp_code;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].add_by = AppSessionState.UserID;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].add_date = DateTime.Now;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].editby = AppSessionState.UserID;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].edit_date = DateTime.Now;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].active = true;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].t_status = "Draft";
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].user_source1 = AppSessionState.UserSource1;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].user_source2 = AppSessionState.UserSource2;
                        }
                        else if (MasterEquipmentEntity[dgSelectedIndexMasterEquipment].ItemCode != POPUPEntityObject.inst_code)
                        {
                            //MasterEquipmentEntity[dgSelectedIndexMasterEquipment].ItemCode = "";

                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].ItemCode = POPUPEntityObject.inst_code;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].ItemName = POPUPEntityObject.inst_name;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].range = POPUPEntityObject.range;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].resolution = POPUPEntityObject.resolution;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].accuracy_up = POPUPEntityObject.accuracy_up;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].due_date = POPUPEntityObject.due_date;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].tr_code = POPUPEntityObject.tr_code;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].tr_name = POPUPEntityObject.tr_name;

                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].location_Id = AppSessionState.location_Id;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].comp_code = AppSessionState.comp_code;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].add_by = AppSessionState.UserID;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].add_date = DateTime.Now;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].editby = AppSessionState.UserID;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].edit_date = DateTime.Now;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].active = true;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].t_status = "Draft";
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].user_source1 = AppSessionState.UserSource1;
                            MasterEquipmentEntity[dgSelectedIndexMasterEquipment].user_source2 = AppSessionState.UserSource2;
                        }
                    }
                }
                #region Clear Empty Row
                QMS_T001_A newObj = new QMS_T001_A();
                for (int i = MasterEquipmentEntity.Count - 1; i >= 0; i--)
                {
                    bool xx = MasterEquipmentEntity[i].ComparePropertiesTo(newObj);
                    if (MasterEquipmentEntity[i].ComparePropertiesTo(newObj) == true && MasterEquipmentEntity.Count > 1)
                    {
                        MasterEquipmentEntity.RemoveAt(i);
                        if (MasterEquipmentEntity.Count == 0)
                        {
                            MasterEquipmentEntity.Add(newObj);
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
        private void InsertTracibility(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            QMS_M010_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MCTemp1.Tracibility.Where(x => x.tr_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M010_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M010_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEquipmentEntity[dgSelectedIndexMasterEquipment].tr_code = POPUPEntityObject.tr_code;
                    MasterEquipmentEntity[dgSelectedIndexMasterEquipment].tr_name = POPUPEntityObject.tr_name;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertRig(object InputValue)
        {
            string Request = "";
            QMS_M008_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MCTemp1.Rig.Where(x => x.rig_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M008_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M008_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.rig_code = POPUPEntityObject.rig_code;
                    MasterEntity.rig_name = POPUPEntityObject.rig_name;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertUOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                        { POPUPEntityObject = MCTemp1.UnitCode.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    if (dgSelectedIndexTestType >= 0 && TestTypeEntity.Count > dgSelectedIndexTestType)
                    {
                        if (TestTypeEntity[dgSelectedIndexTestType].test_type_code != null)
                        {
                            TestTypeEntity[dgSelectedIndexTestType].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (TestTypeEntity[dgSelectedIndexTestType].unit_code != POPUPEntityObject.unit_code && TestTypeEntity[dgSelectedIndexTestType].test_type_code != null)
                        {
                            TestTypeEntity[dgSelectedIndexTestType].unit_code = POPUPEntityObject.unit_code;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void DeleteDataGridRowParameter(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ParameterEntity.Count > i && ParameterEntity[dgSelectedIndexParameter].id == 0)
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
        private void DeleteDataGridRowTestType(object InputValue)
        {
            try
            {
                QMS_T001_B POPUPEntityObject = null;
                if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_T001_B>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_T001_B>().ToList()[0];
                }
                if (TestTypeEntity.Count > 0)
                {
                    List<QMS_T001_B> temp = TestTypeEntity.ToList();
                    foreach (var a in temp)
                    {
                        if (a.tm_id == 0 && a.deletion_id == POPUPEntityObject.deletion_id)
                        {
                            TestTypeEntity.Remove(a);
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
        private void DeleteDataGridRowTaskList(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (TaskListEntity.Count > i && TaskListEntity[dgSelectedIndexTaskList].id == 0)
                {
                    TaskListEntity.RemoveAt(i);
                }
                if (TaskListEntity.Count == 0)
                {
                    TaskListEntity = new ObservableCollection<QMS_T001_E>();
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
        private void DeleteDataGridRowMasterEquipment(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (MasterEquipmentEntity.Count > i && MasterEquipmentEntity[dgSelectedIndexMasterEquipment].id == 0)
                {
                    MasterEquipmentEntity.RemoveAt(i);
                }
                if (MasterEquipmentEntity.Count == 0)
                {
                    MasterEquipmentEntity = new ObservableCollection<QMS_T001_A>();
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
        private void DeleteDataGridRowEnvCond(object InputValue)
        {
            try
            {
                QMS_T001_F POPUPEntityObject = null;
                if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_T001_F>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_T001_F>().ToList()[0];
                }
                if (TestTypeEntity.Count > 0)
                {
                    List<QMS_T001_F> temp = EnvCondEntity.ToList();
                    foreach (var a in temp)
                    {
                        if (a.id == 0 && a.deletion_id == POPUPEntityObject.deletion_id)
                        {
                            EnvCondEntity.Remove(a);
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
        private void InsertTaskList(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            QMS_M024Flip POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MCTemp1.TaskList.Where(x => x.tl_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M024Flip>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M024Flip>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    if (dgSelectedIndexTaskList >= 0 && TaskListEntity.Count > dgSelectedIndexTaskList) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (MasterEntity.test_code != null) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            TaskListEntity[dgSelectedIndexTaskList].tl_code = POPUPEntityObject.tl_code;
                            TaskListEntity[dgSelectedIndexTaskList].short_text = POPUPEntityObject.short_text;
                            TaskListEntity[dgSelectedIndexTaskList].active = true;
                            List<QMS_M024Flip> TempTasks = MCTemp1.TaskList;
                            foreach (var item in TaskListEntity)
                            {
                                QMS_M024Flip task = (from o in MCTemp1.TaskList where o.tl_code == item.tl_code select o).FirstOrDefault();
                                TempTasks.Remove(task);
                            }

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M024Flip)x).tl_code ?? "");
                            TheFilter = (o, prefix) => (((QMS_M024Flip)o).tl_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M024Flip)o).short_text ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASTaskList = new AutoSuggestTextViewModel<dynamic>(TempTasks, TheFilter, SuggestedValue, "tl_code", "tl_code", false);
                            ASTaskList.AutoSuggestVM.IsEmptyValueAllowed = true;
                        }
                        else if (TaskListEntity[dgSelectedIndexTaskList].tl_code != POPUPEntityObject.tl_code && MasterEntity.test_code != null)
                        {
                            TaskListEntity[dgSelectedIndexTaskList].tl_code = POPUPEntityObject.tl_code;
                            TaskListEntity[dgSelectedIndexTaskList].short_text = POPUPEntityObject.short_text;
                            TaskListEntity[dgSelectedIndexTaskList].active = true;
                            List<QMS_M024Flip> TempTasks = MCTemp1.TaskList;
                            foreach (var item in TaskListEntity)
                            {
                                QMS_M024Flip task = (from o in MCTemp1.TaskList where o.tl_code == item.tl_code select o).FirstOrDefault();
                                TempTasks.Remove(task);
                            }

                            SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M024Flip)x).tl_code ?? "");
                            TheFilter = (o, prefix) => (((QMS_M024Flip)o).tl_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M024Flip)o).short_text ?? "").ToLower().Contains(prefix.ToString().ToLower());
                            ASTaskList = new AutoSuggestTextViewModel<dynamic>(TempTasks, TheFilter, SuggestedValue, "tl_code", "tl_code", false);
                            ASTaskList.AutoSuggestVM.IsEmptyValueAllowed = true;
                        }
                    }
                }
            }
            catch (Exception ex) { }
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
                        { POPUPEntityObject = MC.Parameter.Where(x => x.para_value.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    if (dgSelectedIndexParameter >= 0 && ParameterEntity.Count > dgSelectedIndexParameter)
                    {
                        if (ParameterEntity[dgSelectedIndexParameter].value_code == null)
                        {
                            ParameterEntity[dgSelectedIndexParameter].value_code = POPUPEntityObject.value_code;
                            ParameterEntity[dgSelectedIndexParameter].para_value = POPUPEntityObject.para_value;
                        }
                        else if (ParameterEntity[dgSelectedIndexParameter].value_code != POPUPEntityObject.value_code && ParameterEntity[dgSelectedIndexParameter].value_code != null)
                        {
                            ParameterEntity[dgSelectedIndexParameter].value_code = POPUPEntityObject.value_code;
                            ParameterEntity[dgSelectedIndexParameter].para_value = POPUPEntityObject.para_value;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void InsertColumnValue1(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M009_D POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.HeaderValue.Where(x => x.column_value.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    List<QMS_M009_B> tempTestType = MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    List<QMS_T001_B> temp = new List<QMS_T001_B>();
                    temp = TestTypeEntity.ToList();
                    foreach (var o in TestTypeEntity)
                    {
                        if (o.test_type_code != TestTypeParameter && o.test_type_code != null)
                        {
                            temp.Remove(o);
                        }
                        //else if (o.test_type_code == null)
                        //{
                        //    o.test_type_code = TestTypeParameter;
                        //    o.master_inst = tempTestType[0].master_inst;
                        //    o.master_inst_name = tempTestType[0].master_inst_name;
                        //    o.test_type_code = TestTypeParameter;
                        //    o.column_value1 = POPUPEntityObject.column_value;
                        //    o.value_id1 = POPUPEntityObject.value_id;
                        //    o.deletion_id = mn++;
                        //}
                    }

                    if (dgSelectedIndexTestType >= 0 && temp.Count > dgSelectedIndexTestType) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        //foreach (var a in TestTypeEntity)
                        //{
                        //if ((temp[dgSelectedIndexTestType].test_type_code == a.test_type_code) && (a.deletion_id == temp[dgSelectedIndexTestType].deletion_id))
                        //{
                        temp[dgSelectedIndexTestType].master_inst = tempTestType[0].master_inst;
                        temp[dgSelectedIndexTestType].master_inst_name = tempTestType[0].master_inst_name;
                        temp[dgSelectedIndexTestType].test_type_code = TestTypeParameter;
                        temp[dgSelectedIndexTestType].column_value1 = POPUPEntityObject.column_value;
                        temp[dgSelectedIndexTestType].value_id1 = POPUPEntityObject.value_id;
                        temp[dgSelectedIndexTestType].deletion_id = mn++;
                        //}
                        //}
                    }
                    var msg = new NotificationMessage("MasterValues");
                    Messenger.Default.Send<NotificationMessage>(msg);
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertColumnValue2(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M009_D POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.HeaderValue.Where(x => x.column_value.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    List<QMS_M009_B> tempTestType = MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    List<QMS_T001_B> temp = new List<QMS_T001_B>();
                    temp = TestTypeEntity.ToList();
                    foreach (var o in TestTypeEntity)
                    {
                        if (o.test_type_code != TestTypeParameter && o.test_type_code != null)
                        {
                            temp.Remove(o);
                        }
                        //else if (o.test_type_code == null)
                        //{
                        //    o.test_type_code = TestTypeParameter;
                        //    o.master_inst = tempTestType[0].master_inst;
                        //    o.master_inst_name = tempTestType[0].master_inst_name;
                        //    o.test_type_code = TestTypeParameter;
                        //    o.column_value2 = POPUPEntityObject.column_value;
                        //    o.value_id2 = POPUPEntityObject.value_id;
                        //}
                    }

                    if (dgSelectedIndexTestType >= 0 && temp.Count > dgSelectedIndexTestType) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        //foreach (var a in TestTypeEntity)
                        //{
                        //if ((temp[dgSelectedIndexTestType].test_type_code == a.test_type_code) && (a.deletion_id == temp[dgSelectedIndexTestType].deletion_id))
                        //{
                        temp[dgSelectedIndexTestType].master_inst = tempTestType[0].master_inst;
                        temp[dgSelectedIndexTestType].master_inst_name = tempTestType[0].master_inst_name;
                        temp[dgSelectedIndexTestType].test_type_code = TestTypeParameter;
                        temp[dgSelectedIndexTestType].column_value2 = POPUPEntityObject.column_value;
                        temp[dgSelectedIndexTestType].value_id2 = POPUPEntityObject.value_id;
                        //}
                        //}
                    }
                    var msg = new NotificationMessage("MasterValues");
                    Messenger.Default.Send<NotificationMessage>(msg);
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertColumnValue3(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M009_D POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.HeaderValue.Where(x => x.column_value.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    List<QMS_M009_B> tempTestType = MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    List<QMS_T001_B> temp = new List<QMS_T001_B>();
                    temp = TestTypeEntity.ToList();
                    foreach (var o in TestTypeEntity)
                    {
                        if (o.test_type_code != TestTypeParameter && o.test_type_code != null)
                        {
                            temp.Remove(o);
                        }
                        //else if (o.test_type_code == null)
                        //{
                        //    o.test_type_code = TestTypeParameter;
                        //    o.master_inst = tempTestType[0].master_inst;
                        //    o.master_inst_name = tempTestType[0].master_inst_name;
                        //    o.test_type_code = TestTypeParameter;
                        //    o.column_value3 = POPUPEntityObject.column_value;
                        //    o.value_id3 = POPUPEntityObject.value_id;
                        //}
                    }

                    if (dgSelectedIndexTestType >= 0 && temp.Count > dgSelectedIndexTestType) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        //foreach (var a in TestTypeEntity)
                        //{
                        //if ((temp[dgSelectedIndexTestType].test_type_code == a.test_type_code) && (a.deletion_id == temp[dgSelectedIndexTestType].deletion_id))
                        //{
                        temp[dgSelectedIndexTestType].master_inst = tempTestType[0].master_inst;
                        temp[dgSelectedIndexTestType].master_inst_name = tempTestType[0].master_inst_name;
                        temp[dgSelectedIndexTestType].test_type_code = TestTypeParameter;
                        temp[dgSelectedIndexTestType].column_value3 = POPUPEntityObject.column_value;
                        temp[dgSelectedIndexTestType].value_id3 = POPUPEntityObject.value_id;
                        //}
                        //}
                    }
                    var msg = new NotificationMessage("MasterValues");
                    Messenger.Default.Send<NotificationMessage>(msg);
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertColumnValue4(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M009_D POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.HeaderValue.Where(x => x.column_value.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    List<QMS_M009_B> tempTestType = MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    List<QMS_T001_B> temp = new List<QMS_T001_B>();
                    temp = TestTypeEntity.ToList();
                    foreach (var o in TestTypeEntity)
                    {
                        if (o.test_type_code != TestTypeParameter && o.test_type_code != null)
                        {
                            temp.Remove(o);
                        }
                        //else if (o.test_type_code == null)
                        //{
                        //    o.test_type_code = TestTypeParameter;
                        //    o.master_inst = tempTestType[0].master_inst;
                        //    o.master_inst_name = tempTestType[0].master_inst_name;
                        //    o.test_type_code = TestTypeParameter;
                        //    o.column_value4 = POPUPEntityObject.column_value;
                        //    o.value_id4 = POPUPEntityObject.value_id;
                        //}
                    }

                    if (dgSelectedIndexTestType >= 0 && temp.Count > dgSelectedIndexTestType) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        //foreach (var a in TestTypeEntity)
                        //{
                        //if ((temp[dgSelectedIndexTestType].test_type_code == a.test_type_code) && (a.deletion_id == temp[dgSelectedIndexTestType].deletion_id))
                        //{
                        temp[dgSelectedIndexTestType].master_inst = tempTestType[0].master_inst;
                        temp[dgSelectedIndexTestType].master_inst_name = tempTestType[0].master_inst_name;
                        temp[dgSelectedIndexTestType].test_type_code = TestTypeParameter;
                        temp[dgSelectedIndexTestType].column_value4 = POPUPEntityObject.column_value;
                        temp[dgSelectedIndexTestType].value_id4 = POPUPEntityObject.value_id;
                        //}
                        //}
                    }
                    var msg = new NotificationMessage("MasterValues");
                    Messenger.Default.Send<NotificationMessage>(msg);
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertColumnValue5(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M009_D POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.HeaderValue.Where(x => x.column_value.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    List<QMS_M009_B> tempTestType = MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    List<QMS_T001_B> temp = new List<QMS_T001_B>();
                    temp = TestTypeEntity.ToList();
                    foreach (var o in TestTypeEntity)
                    {
                        if (o.test_type_code != TestTypeParameter && o.test_type_code != null)
                        {
                            temp.Remove(o);
                        }
                        //else if (o.test_type_code == null)
                        //{
                        //    o.test_type_code = TestTypeParameter;
                        //    o.master_inst = tempTestType[0].master_inst;
                        //    o.master_inst_name = tempTestType[0].master_inst_name;
                        //    o.test_type_code = TestTypeParameter;
                        //    o.column_value5 = POPUPEntityObject.column_value;
                        //    o.value_id5 = POPUPEntityObject.value_id;
                        //}
                    }

                    if (dgSelectedIndexTestType >= 0 && temp.Count > dgSelectedIndexTestType) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        //foreach (var a in TestTypeEntity)
                        //{
                        //if ((temp[dgSelectedIndexTestType].test_type_code == a.test_type_code) && (a.deletion_id == temp[dgSelectedIndexTestType].deletion_id))
                        //{
                        temp[dgSelectedIndexTestType].master_inst = tempTestType[0].master_inst;
                        temp[dgSelectedIndexTestType].master_inst_name = tempTestType[0].master_inst_name;
                        temp[dgSelectedIndexTestType].test_type_code = TestTypeParameter;
                        temp[dgSelectedIndexTestType].column_value5 = POPUPEntityObject.column_value;
                        temp[dgSelectedIndexTestType].value_id5 = POPUPEntityObject.value_id;
                        //}
                        //}
                    }
                    var msg = new NotificationMessage("MasterValues");
                    Messenger.Default.Send<NotificationMessage>(msg);
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertColumnValue6(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M009_D POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.HeaderValue.Where(x => x.column_value.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    List<QMS_M009_B> tempTestType = MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    List<QMS_T001_B> temp = new List<QMS_T001_B>();
                    temp = TestTypeEntity.ToList();
                    foreach (var o in TestTypeEntity)
                    {
                        if (o.test_type_code != TestTypeParameter && o.test_type_code != null)
                        {
                            temp.Remove(o);
                        }
                        //else if (o.test_type_code == null)
                        //{
                        //    o.test_type_code = TestTypeParameter;
                        //    o.master_inst = tempTestType[0].master_inst;
                        //    o.master_inst_name = tempTestType[0].master_inst_name;
                        //    o.test_type_code = TestTypeParameter;
                        //    o.column_value6 = POPUPEntityObject.column_value;
                        //    o.value_id6 = POPUPEntityObject.value_id;
                        //}
                    }

                    if (dgSelectedIndexTestType >= 0 && temp.Count > dgSelectedIndexTestType) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        //foreach (var a in TestTypeEntity)
                        //{
                        //if ((temp[dgSelectedIndexTestType].test_type_code == a.test_type_code) && (a.deletion_id == temp[dgSelectedIndexTestType].deletion_id))
                        //{
                        temp[dgSelectedIndexTestType].master_inst = tempTestType[0].master_inst;
                        temp[dgSelectedIndexTestType].master_inst_name = tempTestType[0].master_inst_name;
                        temp[dgSelectedIndexTestType].test_type_code = TestTypeParameter;
                        temp[dgSelectedIndexTestType].column_value6 = POPUPEntityObject.column_value;
                        temp[dgSelectedIndexTestType].value_id6 = POPUPEntityObject.value_id;
                        //}
                        //}
                    }
                    var msg = new NotificationMessage("MasterValues");
                    Messenger.Default.Send<NotificationMessage>(msg);
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertColumnValue7(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M009_D POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.HeaderValue.Where(x => x.column_value.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    List<QMS_M009_B> tempTestType = MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    List<QMS_T001_B> temp = new List<QMS_T001_B>();
                    temp = TestTypeEntity.ToList();
                    foreach (var o in TestTypeEntity)
                    {
                        if (o.test_type_code != TestTypeParameter && o.test_type_code != null)
                        {
                            temp.Remove(o);
                        }
                        //else if (o.test_type_code == null)
                        //{
                        //    o.test_type_code = TestTypeParameter;
                        //    o.master_inst = tempTestType[0].master_inst;
                        //    o.master_inst_name = tempTestType[0].master_inst_name;
                        //    o.test_type_code = TestTypeParameter;
                        //    o.column_value7 = POPUPEntityObject.column_value;
                        //    o.value_id7 = POPUPEntityObject.value_id;
                        //}
                    }

                    if (dgSelectedIndexTestType >= 0 && temp.Count > dgSelectedIndexTestType) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        //foreach (var a in TestTypeEntity)
                        //{
                        //if ((temp[dgSelectedIndexTestType].test_type_code == a.test_type_code) && (a.deletion_id == temp[dgSelectedIndexTestType].deletion_id))
                        //{
                        temp[dgSelectedIndexTestType].master_inst = tempTestType[0].master_inst;
                        temp[dgSelectedIndexTestType].master_inst_name = tempTestType[0].master_inst_name;
                        temp[dgSelectedIndexTestType].test_type_code = TestTypeParameter;
                        temp[dgSelectedIndexTestType].column_value7 = POPUPEntityObject.column_value;
                        temp[dgSelectedIndexTestType].value_id7 = POPUPEntityObject.value_id;
                        //}
                        //}
                    }
                    var msg = new NotificationMessage("MasterValues");
                    Messenger.Default.Send<NotificationMessage>(msg);
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertColumnValue8(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M009_D POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.HeaderValue.Where(x => x.column_value.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    List<QMS_M009_B> tempTestType = MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    List<QMS_T001_B> temp = new List<QMS_T001_B>();
                    temp = TestTypeEntity.ToList();
                    foreach (var o in TestTypeEntity)
                    {
                        if (o.test_type_code != TestTypeParameter && o.test_type_code != null)
                        {
                            temp.Remove(o);
                        }
                        //else if (o.test_type_code == null)
                        //{
                        //    o.test_type_code = TestTypeParameter;
                        //    o.master_inst = tempTestType[0].master_inst;
                        //    o.master_inst_name = tempTestType[0].master_inst_name;
                        //    o.test_type_code = TestTypeParameter;
                        //    o.column_value8 = POPUPEntityObject.column_value;
                        //    o.value_id8 = POPUPEntityObject.value_id;
                        //}
                    }

                    if (dgSelectedIndexTestType >= 0 && temp.Count > dgSelectedIndexTestType) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        //foreach (var a in TestTypeEntity)
                        //{
                        //if ((temp[dgSelectedIndexTestType].test_type_code == a.test_type_code) && (a.deletion_id == temp[dgSelectedIndexTestType].deletion_id))
                        //{
                        temp[dgSelectedIndexTestType].master_inst = tempTestType[0].master_inst;
                        temp[dgSelectedIndexTestType].master_inst_name = tempTestType[0].master_inst_name;
                        temp[dgSelectedIndexTestType].test_type_code = TestTypeParameter;
                        temp[dgSelectedIndexTestType].column_value8 = POPUPEntityObject.column_value;
                        temp[dgSelectedIndexTestType].value_id8 = POPUPEntityObject.value_id;
                        //}
                        //}
                    }
                    var msg = new NotificationMessage("MasterValues");
                    Messenger.Default.Send<NotificationMessage>(msg);
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertColumnValue9(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M009_D POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.HeaderValue.Where(x => x.column_value.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    List<QMS_M009_B> tempTestType = MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    List<QMS_T001_B> temp = new List<QMS_T001_B>();
                    temp = TestTypeEntity.ToList();
                    foreach (var o in TestTypeEntity)
                    {
                        if (o.test_type_code != TestTypeParameter && o.test_type_code != null)
                        {
                            temp.Remove(o);
                        }
                        //else if (o.test_type_code == null)
                        //{
                        //    o.test_type_code = TestTypeParameter;
                        //    o.master_inst = tempTestType[0].master_inst;
                        //    o.master_inst_name = tempTestType[0].master_inst_name;
                        //    o.test_type_code = TestTypeParameter;
                        //    o.column_value9 = POPUPEntityObject.column_value;
                        //    o.value_id9 = POPUPEntityObject.value_id;
                        //}
                    }

                    if (dgSelectedIndexTestType >= 0 && temp.Count > dgSelectedIndexTestType) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        //foreach (var a in TestTypeEntity)
                        //{
                        //if ((temp[dgSelectedIndexTestType].test_type_code == a.test_type_code) && (a.deletion_id == temp[dgSelectedIndexTestType].deletion_id))
                        //{
                        temp[dgSelectedIndexTestType].master_inst = tempTestType[0].master_inst;
                        temp[dgSelectedIndexTestType].master_inst_name = tempTestType[0].master_inst_name;
                        temp[dgSelectedIndexTestType].test_type_code = TestTypeParameter;
                        temp[dgSelectedIndexTestType].column_value9 = POPUPEntityObject.column_value;
                        temp[dgSelectedIndexTestType].value_id9 = POPUPEntityObject.value_id;
                        //}
                        //}
                    }
                    var msg = new NotificationMessage("MasterValues");
                    Messenger.Default.Send<NotificationMessage>(msg);
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertColumnValue10(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M009_D POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.HeaderValue.Where(x => x.column_value.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    List<QMS_M009_B> tempTestType = MC.TestType.Where(x => x.test_type_code == TestTypeParameter).ToList();
                    List<QMS_T001_B> temp = new List<QMS_T001_B>();
                    temp = TestTypeEntity.ToList();
                    foreach (var o in TestTypeEntity)
                    {
                        if (o.test_type_code != TestTypeParameter && o.test_type_code != null)
                        {
                            temp.Remove(o);
                        }
                        //else if (o.test_type_code == null)
                        //{
                        //    o.test_type_code = TestTypeParameter;
                        //    o.master_inst = tempTestType[0].master_inst;
                        //    o.master_inst_name = tempTestType[0].master_inst_name;
                        //    o.test_type_code = TestTypeParameter;
                        //    o.column_value10 = POPUPEntityObject.column_value;
                        //    o.value_id10 = POPUPEntityObject.value_id;
                        //}
                    }

                    if (dgSelectedIndexTestType >= 0 && temp.Count > dgSelectedIndexTestType) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        //foreach (var a in TestTypeEntity)
                        //{
                        //if ((temp[dgSelectedIndexTestType].test_type_code == a.test_type_code) && (a.deletion_id == temp[dgSelectedIndexTestType].deletion_id))
                        //{
                        temp[dgSelectedIndexTestType].master_inst = tempTestType[0].master_inst;
                        temp[dgSelectedIndexTestType].master_inst_name = tempTestType[0].master_inst_name;
                        temp[dgSelectedIndexTestType].test_type_code = TestTypeParameter;
                        temp[dgSelectedIndexTestType].column_value10 = POPUPEntityObject.column_value;
                        temp[dgSelectedIndexTestType].value_id10 = POPUPEntityObject.value_id;
                        //}
                        //}
                    }
                    var msg = new NotificationMessage("MasterValues");
                    Messenger.Default.Send<NotificationMessage>(msg);
                }
            }
            catch (Exception ex)
            { }
        }
        private void CustReport(object InputValue)
        {
            try
            {
                object[] objDataSource = new object[8];
                string[] objDataSourceName = new string[8];
                if (MasterEntity.doc_no != null)
                {
                    string Request = "LoadReportData" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + MasterEntity.doc_no + "!@" + MasterEntity.test_code;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_T001>(MCTemp, Request, "CalibrationView", "QMS", "LoadReportData", 0, "");

                    AssignHeaders();

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var locResult = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[0] = locResult;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[1] = CmpResult;

                    if (MCTemp.MasterEntity.Count > 0 && MCTemp.EnvCondEntity.Count > 0)
                    {
                        string strTemp = " ± " + string.Format("{0:n1}", MCTemp.EnvCondEntity.Where(x => x.env_code == "TMP").FirstOrDefault().upper_value - MCTemp.EnvCondEntity.Where(x => x.env_code == "TMP").FirstOrDefault().std_value);
                        MCTemp.MasterEntity[0].temperature = string.Format("{0:n1}", Convert.ToDecimal(MCTemp.EnvCondEntity.Where(x => x.env_code == "TMP").FirstOrDefault().r_std_value)) + strTemp + " " + MCTemp.EnvCondEntity.Where(x => x.env_code == "TMP").FirstOrDefault().std_value_unit;
                        string strHmd = " ± " + string.Format("{0:n1}", MCTemp.EnvCondEntity.Where(x => x.env_code == "HMD").FirstOrDefault().upper_value - MCTemp.EnvCondEntity.Where(x => x.env_code == "HMD").FirstOrDefault().std_value);
                        MCTemp.MasterEntity[0].humidity = string.Format("{0:n1}", Convert.ToDecimal(MCTemp.EnvCondEntity.Where(x => x.env_code == "HMD").FirstOrDefault().r_std_value)) + strHmd + " " + MCTemp.EnvCondEntity.Where(x => x.env_code == "HMD").FirstOrDefault().std_value_unit;
                    }
                    if (MCTemp.RptDatasheet.Count > 0)
                    {
                        if (MCTemp.RptDatasheet[0].formula_code == "S350" || MCTemp.RptDatasheet[0].formula_code == "L350")
                        {
                            objDataSource[3] = MCTemp.RptDatasheet.Where(x => (x.test_type_code == "Test" || x.test_type_code == "Test Resul")).ToList();
                            objDataSource[4] = MCTemp.RptDatasheet.Where(x => x.test_type_code == "Test at 30").ToList();
                            objDataSource[6] = MCTemp.RptDatasheet.Where(x => x.test_type_code == "Test at -3").ToList();
                        }
                        else if (MCTemp.RptDatasheet[0].formula_code == "SD10001")
                        {
                            objDataSource[3] = MCTemp.RptDatasheet.Where(x => x.test_type_code == MCTemp.RptDatasheet[0].test_type_code).ToList();
                            objDataSource[4] = MCTemp.RptDatasheet.Where(x => x.test_type_code != MCTemp.RptDatasheet[0].test_type_code).ToList();

                            //List<RptTestType> temptest = (List<RptTestType>)objDataSource[3];
                            //if (temptest != null && temptest.Count != MCTemp.RptDatasheet.Count)
                            //{
                            //    objDataSource[4] = MCTemp.RptDatasheet.Where(x => x.test_type_code == MCTemp.RptDatasheet[temptest.Count].test_type_code).ToList();
                            //}
                            //else
                            //{
                            //    List<RptTestType> temptest1 = new List<RptTestType>();
                            //    temptest1.Add(MCTemp.RptDatasheet[0]);
                            //    objDataSource[4] = temptest1;
                            //}
                        }
                    }

                    objDataSource[5] = MCTemp.MasterEquipment;
                    objDataSource[7] = MCTemp.ParameterEntity;
                    //objDataSource[8] = MCTemp.EnvCondEntity;

                    objDataSourceName[0] = "dsLocation";
                    objDataSourceName[1] = "dsCompany";
                    objDataSourceName[2] = "dsCalibrationMaster";
                    objDataSourceName[3] = "dsDatasheet1";
                    objDataSourceName[4] = "dsDatasheet2";
                    objDataSourceName[5] = "dsMasterInst";
                    objDataSourceName[6] = "dsDatasheet3";
                    objDataSourceName[7] = "dsParameter";
                    //objDataSourceName[8] = "dsEnvCondition";

                    string ReportName = "";
                    var SystemDocumentObject = (from o in MCTemp1.DocTypeInfo where o.doc_cat == MasterEntity.doc_cat select o).ToList();
                    if (SystemDocumentObject != null && SystemDocumentObject.Count > 0 && MCTemp.RptDatasheet.Count > 0 && MCTemp.MasterEntity.Count > 0)
                    {
                        if (MCTemp.RptDatasheet[0].formula_code == "S350" || MCTemp.RptDatasheet[0].formula_code == "L350")
                        {
                            ReportName = SystemDocumentObject[0].report_name.Split(',')[1];
                        }
                        else if (MasterEntity.test_code == "HVC-Divid" || MasterEntity.test_code == "HVC-Probe")
                        {
                            ReportName = SystemDocumentObject[0].report_name.Split(',')[1];
                            if (SystemDocumentObject[0].report_no != null)
                            {
                                MCTemp.MasterEntity[0].report_no = SystemDocumentObject[0].report_no.Split(',')[1];
                            }
                        }
                        else if (MasterEntity.test_code == "TAN_D & CA")
                        {
                            ReportName = SystemDocumentObject[0].report_name.Split(',')[2];
                            if (SystemDocumentObject[0].report_no != null)
                            {
                                MCTemp.MasterEntity[0].report_no = SystemDocumentObject[0].report_no.Split(',')[2];
                            }
                        }
                        else if (MasterEntity.test_code == "RES_CAL_DC")
                        {
                            ReportName = SystemDocumentObject[0].report_name.Split(',')[3];
                            if (SystemDocumentObject[0].report_no != null)
                            {
                                MCTemp.MasterEntity[0].report_no = SystemDocumentObject[0].report_no.Split(',')[3];
                            }
                        }
                    }
                    objDataSource[2] = MCTemp.MasterEntity;

                    ReportingServices.ReportManager ReportManager = new ReportingServices.ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\QMS\\" + ReportName, getParametersList2(), "CustomerCalibration"); //Calibration.rdlc
                }
            }
            catch (Exception ex) { }
        }
        private bool Validation()
        {
            if (MasterEntity.inst_code == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("please Select Instrument...");
                showMessageService.ShowMessage();
                return false;
            }
            foreach (var o in ParameterEntity)
            {
                if (o.allow_null == false)
                {
                    if (o.value_code == null || o.value_code == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("please enter value for: {0}", o.para_name);
                        showMessageService.ShowMessage();
                        return false;
                    }
                }
            }

            foreach (var o in MasterEquipmentEntity)
            {
                int flag = 0;
                if (o.id == 0 && o.active == true)
                {
                    foreach (var p in MasterEquipmentEntity)
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
                        showMessageService.Text = String.Format("Cannot Save Duplicate Master Equipment : {0} ", o.ItemName);
                        showMessageService.ShowMessage();
                        return false;
                    }
                }
            }

            //Validation for Uncertainty Scope
            //if (MC.UncertaintyScope != null && MC.UncertaintyScope.Count > 0)
            //{
            //    foreach (var o in TestTypeEntity)
            //    {
            //        foreach (var p in MC.UncertaintyScope)
            //        {
            //            if (MasterEntity.test_code == p.test_code && o.test_type_code == p.test_type_code && o.active == true)
            //            {
            //                if (p.ind_valid == true)
            //                {
            //                    if (Convert.ToInt32(p.value_id1) == o.value_id1 && Convert.ToInt32(p.value_id2) == o.value_id2 && Convert.ToInt32(p.value_id3) == o.value_id3 && Convert.ToInt32(p.value_id4) == o.value_id4 && Convert.ToInt32(p.value_id5) == o.value_id5 &&
            //                        Convert.ToInt32(p.value_id6) == o.value_id6 && Convert.ToInt32(p.value_id7) == o.value_id7 && Convert.ToInt32(p.value_id8) == o.value_id8 && Convert.ToInt32(p.value_id9) == o.value_id9 && Convert.ToInt32(p.value_id10) == o.value_id10)
            //                    {
            //                        if (o.expanded_uncertainty_per > p.unc_u_value)
            //                        {
            //                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //                            showMessageService.ButtonSetup = DialogButton.Ok;
            //                            showMessageService.Caption = "Message";
            //                            showMessageService.Text = String.Format("Expanded uncertainty is greater for {0}", o.column_value2 + " " + o.unit_code);
            //                            showMessageService.ShowMessage();
            //                            return false;
            //                        }
            //                        else if (o.expanded_uncertainty_per < p.unc_l_value)
            //                        {
            //                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //                            showMessageService.ButtonSetup = DialogButton.Ok;
            //                            showMessageService.Caption = "Message";
            //                            showMessageService.Text = String.Format("Expanded uncertainty is lower for {0}", o.column_value2 + " " + o.unit_code);
            //                            showMessageService.ShowMessage();
            //                            return false;
            //                        }
            //                    }
            //                }
            //            }
            //        }
            //    }
            //}
            return true;
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.XmlDataDocument_QMS_T001Flip != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MCTemp1.DocumentDataFlipGrid = (List<QMS_T001Flip>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_T001Flip, MCTemp1.DocumentDataFlipGrid);
                    FlipGridData.Add(MCTemp1.DocumentDataFlipGrid[0]);
                    DataGridCollection.Refresh();
                }
                if (MasterEntity.XmlDataDocument_QMS_T001_A != null)
                {
                    MasterEquipmentEntity.Clear();
                    MCTemp1.MasterEquipment = (ObservableCollection<QMS_T001_A>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_T001_A, MCTemp1.MasterEquipment);
                    MasterEquipmentEntity = MCTemp1.MasterEquipment;
                }
                else
                {
                    MasterEquipmentEntity = new ObservableCollection<QMS_T001_A>();
                }
                if (MasterEntity.XmlDataDocument_QMS_T001_B != null)
                {
                    TestTypeEntity.Clear();
                    MCTemp1.TestTypeEntity = (ObservableCollection<QMS_T001_B>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_T001_B, MCTemp1.TestTypeEntity);
                    TestTypeEntity = MCTemp1.TestTypeEntity;
                }
                else
                {
                    TestTypeEntity = new ObservableCollection<QMS_T001_B>();
                }
                if (MasterEntity.XmlDataDocument_QMS_M003_B != null)
                {
                    ParameterEntity.Clear();
                    MCTemp1.ParameterEntity = (ObservableCollection<QMS_M003_B>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M003_B, MCTemp1.ParameterEntity);
                    ParameterEntity = MCTemp1.ParameterEntity;
                }
                else
                {
                    ParameterEntity = new ObservableCollection<QMS_M003_B>();
                }
                if (MasterEntity.XmlDataDocument_QMS_M009_B != null)
                {
                    MC.TestType.Clear();
                    MC.TestType = (List<QMS_M009_B>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M009_B, MC.TestType);
                }
                else
                {
                    MC.TestType = new List<QMS_M009_B>();
                }
                if (MasterEntity.XmlDataDocument_QMS_M009_C != null)
                {
                    MC.BenchHeader.Clear();
                    MC.BenchHeader = (List<QMS_M009_C>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M009_C, MC.BenchHeader);
                }
                else
                {
                    MC.BenchHeader = new List<QMS_M009_C>();
                }
                if (MasterEntity.XmlDataDocument_QMS_M009_D != null)
                {
                    MC.HeaderValue.Clear();
                    MC.HeaderValue = (List<QMS_M009_D>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M009_D, MC.HeaderValue);
                }
                else
                {
                    MC.HeaderValue = new List<QMS_M009_D>();
                }
                if (MasterEntity.XmlDataDocument_QMS_M009_E_M != null)
                {
                    MC.MasterHeader.Clear();
                    MC.MasterHeader = (List<QMS_M009_E>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M009_E_M, MC.MasterHeader);
                }
                else
                {
                    MC.MasterHeader = new List<QMS_M009_E>();
                }
                if (MasterEntity.XmlDataDocument_QMS_M009_E_I != null)
                {
                    MC.UnitHeader.Clear();
                    MC.UnitHeader = (List<QMS_M009_E>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M009_E_I, MC.UnitHeader);
                }
                else
                {
                    MC.UnitHeader = new List<QMS_M009_E>();
                }
                if (MasterEntity.XmlDataDocument_QMS_T001_E != null)
                {
                    TaskListEntity.Clear();
                    MCTemp1.TaskListEntity = (ObservableCollection<QMS_T001_E>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_T001_E, MCTemp1.TaskListEntity);
                    TaskListEntity = MCTemp1.TaskListEntity;
                }
                else
                {
                    MCTemp1.TaskListEntity = new ObservableCollection<QMS_T001_E>();
                }
                if (MasterEntity.XmlDataDocument_QMS_T001_F != null)
                {
                    EnvCondEntity.Clear();
                    MCTemp1.EnvCondEntity = (ObservableCollection<QMS_T001_F>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_T001_F, MCTemp1.EnvCondEntity);
                    EnvCondEntity = MCTemp1.EnvCondEntity;
                }
                else
                {
                    EnvCondEntity = new ObservableCollection<QMS_T001_F>();
                }
                if (MasterEntity.XmlDataDocument_QMS_M009_J != null)
                {
                    MC.MasterValueEntity.Clear();
                    MC.MasterValueEntity = (List<QMS_M009_J>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M009_J, MC.MasterValueEntity);
                }
                else
                {
                    MC.MasterValueEntity = new List<QMS_M009_J>();
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
        private void SetPopupSuggestionDataAfterLoad()
        {
            ASEmployee.AutoSuggestVM.Suggestion = MCTemp1.Employees.Find(x => x.EmpId == MasterEntity.EmpId);
            ASRig.AutoSuggestVM.Suggestion = MCTemp1.Rig.Find(x => x.rig_code == MasterEntity.rig_code);
            ASTracibility.AutoSuggestVM.Suggestion = MCTemp1.Tracibility.Find(x => x.tr_code == MasterEntity.tr_code);
        }
        private void UncertaintyBudgetReport(object InputValue)
        {
            try
            {
                TypeA(true);
                TypeB(InputValue);

                object[] objDataSource = new object[7];
                string[] objDataSourceName = new string[7];

                //string Request = "LoadReportData" + "!@" + MasterEntity.doc_no + "!@" + MasterEntity.test_code;
                //MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_T001>(MCTemp, Request, "CalibrationView", "QMS", "LoadReportData", 0, "");

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var locResult = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[0] = locResult;

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[1] = CmpResult;

                MCTemp.MasterEntity = new List<QMS_T001>();
                MCTemp.MasterEntity.Add(MasterEntity);
                objDataSource[2] = MCTemp.MasterEntity;
                objDataSource[3] = TypeAEntity;
                objDataSource[4] = MasterEquipmentEntity.Where(x => x.ItemCode == (from o in TestTypeEntity where o.test_type_code == TestTypeParameter select o.master_inst).FirstOrDefault()).ToList();
                objDataSource[5] = EnvCondEntity.Where(x => x.test_type_code == TestTypeParameter).ToList();

                objDataSourceName[0] = "dsLocation";
                objDataSourceName[1] = "dsCompany";
                objDataSourceName[2] = "dsCalibrationMaster";
                objDataSourceName[3] = "dsDataSheet1";
                objDataSourceName[4] = "dsMasterInst";
                objDataSourceName[5] = "dsEnvCondition";

                string ReportName = "";
                var SystemDocumentObject = (from o in MCTemp1.DocTypeInfo where o.doc_cat == MasterEntity.doc_cat select o).ToList();
                if (SystemDocumentObject.Count > 0)
                {
                    ReportName = SystemDocumentObject[0].report_name.Split(',')[1];
                    if (SystemDocumentObject[0].report_no != null)
                    {
                        MasterEntity.report_no = SystemDocumentObject[0].report_no.Split(',')[1];
                    }
                }

                ReportingServices.ReportManager ReportManager = new ReportingServices.ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\QMS\\" + ReportName, "UncertaintyBudget"); //Calibration.rdlc
            }
            catch (Exception ex)
            {

            }
        }
        private void InsertEnvCond(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M017 POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MCTemp1.StdEnvCond.Where(x => x.env_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M017>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M017>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    if (dgSelectedIndexEnvCond >= 0 && EnvCondEntity.Count > dgSelectedIndexEnvCond) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_T001_F> temp = EnvCondEntity.ToList();
                        temp = (from o in temp where o.test_type_code == TestTypeParameter select o).ToList();
                        temp[dgSelectedIndexEnvCond].env_name = POPUPEntityObject.env_name;
                        temp[dgSelectedIndexEnvCond].env_code = POPUPEntityObject.env_code;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertSiteEmployee(object InputValue)
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
                        { POPUPEntityObject = MCTemp1.Employees.Where(x => x.EmpName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M024_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.siteEmpId = POPUPEntityObject.EmpId;
                    MasterEntity.siteEmpNm = POPUPEntityObject.EmpName;
                }
            }
            catch (Exception ex) { }
        }

        #endregion

        #region Filters

        #region Filters For DataGrid
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
            var data = obj as QMS_T001Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.inst_name != null && data.inst_name.ToLower().Contains(_filterString.ToLower()) ||
                            data.test_name != null && data.test_name.ToLower().Contains(_filterString.ToLower()) ||
                            data.doc_no != null && data.doc_no.ToLower().Contains(_filterString.ToLower()) ||
                            data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.EmpNm != null && data.EmpNm.ToLower().Contains(_filterString.ToLower()) ||
                            data.t_status != null && data.t_status.ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }
        #endregion

        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<QMS_T001> result)
        {
            MasterEntity = new QMS_T001();
            ParameterEntity = new ObservableCollection<QMS_M003_B>();
            TestTypeEntity = new ObservableCollection<QMS_T001_B>();
            TaskListEntity = new ObservableCollection<QMS_T001_E>();
            MasterEquipmentEntity = new ObservableCollection<QMS_T001_A>();
            MC.TestType = new List<QMS_M009_B>();
            TestTypeDataGrid = CollectionViewSource.GetDefaultView(TestTypeEntity);
            EnvCondEntity = new ObservableCollection<QMS_T001_F>();
            TestTypeParameter = null;

            DefaultValues();
        }
        protected override void OnDiscardAction(InquiryActionResult<QMS_T001> result)
        {

        }
        protected override void OnDocumentAction()
        {
            try
            {
                CursorControl.SetBusyState();
                if (!string.IsNullOrEmpty(MasterEntity.doc_no))
                {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MCTemp.Attachment });
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
        protected override void OnRefreshCommand(InquiryActionResult<QMS_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_T001> result)
        {
            throw new NotImplementedException();
        }
        protected override void OnFevoriteAction(InquiryActionResult<QMS_T001> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<QMS_T001> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<QMS_T001> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<QMS_T001> result)
        {
            try
            {
                object[] objDataSource = new object[6];
                string[] objDataSourceName = new string[6];

                string Request = "LoadReportData" + "!@" + MasterEntity.doc_no + "!@" + MasterEntity.test_code + "!@" + MasterEntity.doc_no;
                MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_T001>(MCTemp, Request, "CalibrationView", "QMS", "LoadReportData", 0, "");

                AssignHeaders();

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var locResult = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[0] = locResult;

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[1] = CmpResult;

                objDataSource[2] = MCTemp.MasterEntity;
                objDataSource[3] = MCTemp.ParameterEntity;
                objDataSource[4] = MCTemp.RptDatasheet.Where(x => x.test_type_code == MCTemp.RptDatasheet[0].test_type_code).ToList();
                List<RptTestType> temptest = (List<RptTestType>)objDataSource[4];
                if (temptest.Count != MCTemp.RptDatasheet.Count)
                {
                    objDataSource[5] = MCTemp.RptDatasheet.Where(x => x.test_type_code == MCTemp.RptDatasheet[temptest.Count].test_type_code).ToList();
                }
                else
                {
                    List<RptTestType> temptest1 = new List<RptTestType>();
                    temptest1.Add(MCTemp.RptDatasheet[0]);
                    objDataSource[5] = temptest1;
                }

                objDataSourceName[0] = "dsLocation";
                objDataSourceName[1] = "dsCompany";
                objDataSourceName[2] = "dsCalibrationMaster";
                objDataSourceName[3] = "dsCalibrationParameter";
                objDataSourceName[4] = "dsDatasheet1";
                objDataSourceName[5] = "dsDatasheet2";

                string ReportName = "";
                var SystemDocumentObject = (from o in MCTemp1.DocTypeInfo where o.doc_cat == MasterEntity.doc_cat select o).ToList();
                if (SystemDocumentObject != null && SystemDocumentObject.Count > 0)
                {
                    ReportName = SystemDocumentObject[0].report_name.Split(',')[0];
                }

                ReportingServices.ReportManager ReportManager = new ReportingServices.ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\QMS\\" + ReportName, getParametersList(), "CalibrationReport"); //Calibration.rdlc
            }
            catch (Exception ex)
            {

            }
        }
        private Dictionary<string, string> getParametersList()
        {
            List<RptTestType> tempDatasheet = MCTemp.RptDatasheet.GroupBy(x => x.test_type_code).Select(Z => Z.FirstOrDefault()).ToList();
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                if (tempDatasheet.Count == 1)
                {
                    result.Add("H_BH1", tempDatasheet[0].hdr_name1);
                    result.Add("H_BH2", tempDatasheet[0].hdr_name2);
                    result.Add("H_BH3", tempDatasheet[0].hdr_name3);
                    result.Add("H_BH4", tempDatasheet[0].hdr_name4);
                    result.Add("H_BH5", tempDatasheet[0].hdr_name5);
                    result.Add("H_BH6", tempDatasheet[0].hdr_name6);
                    result.Add("H_BH7", tempDatasheet[0].hdr_name7);
                    result.Add("H_BH8", tempDatasheet[0].hdr_name8);
                    result.Add("H_BH9", tempDatasheet[0].hdr_name9);
                    result.Add("H_BH10", tempDatasheet[0].hdr_name10);
                    result.Add("H_MR1", tempDatasheet[0].value_header1);
                    result.Add("H_MR2", tempDatasheet[0].value_header2);
                    result.Add("H_MR3", tempDatasheet[0].value_header3);
                    result.Add("H_MR4", tempDatasheet[0].value_header4);
                    result.Add("H_MR5", tempDatasheet[0].value_header5);
                    result.Add("H_MR6", tempDatasheet[0].value_header6);
                    result.Add("H_MR7", tempDatasheet[0].value_header7);
                    result.Add("H_MR8", tempDatasheet[0].value_header8);
                    result.Add("H_MR9", tempDatasheet[0].value_header9);
                    result.Add("H_MR10", tempDatasheet[0].value_header10);
                    if (MC.MasterHeader.Count > 0)
                    {
                        result.Add("H_MRC1", tempDatasheet[0].op_hdr1);
                        result.Add("H_MRC2", tempDatasheet[0].op_hdr2);
                        result.Add("H_MRC3", tempDatasheet[0].op_hdr3);
                    }
                    result.Add("H_ER1", tempDatasheet[0].value_header31);
                    result.Add("H_ER2", tempDatasheet[0].value_header32);
                    result.Add("H_ER3", tempDatasheet[0].value_header33);
                    result.Add("H_ER4", tempDatasheet[0].value_header34);
                    result.Add("H_ER5", tempDatasheet[0].value_header35);
                    result.Add("H_ER6", tempDatasheet[0].value_header36);
                    result.Add("H_ER7", tempDatasheet[0].value_header37);
                    result.Add("H_ER8", tempDatasheet[0].value_header38);
                    result.Add("H_ER9", tempDatasheet[0].value_header39);
                    result.Add("H_ER10", tempDatasheet[0].value_header40);
                    if (MC.UnitHeader.Count > 0)
                    {
                        result.Add("H_ERC1", tempDatasheet[0].op_hdr1);
                        result.Add("H_ERC2", tempDatasheet[0].op_hdr2);
                        result.Add("H_ERC3", tempDatasheet[0].op_hdr3);
                    }
                }
                else if (tempDatasheet.Count == 2)
                {
                    result.Add("H_BH1", tempDatasheet[0].hdr_name1);
                    result.Add("H_BH2", tempDatasheet[0].hdr_name2);
                    result.Add("H_BH3", tempDatasheet[0].hdr_name3);
                    result.Add("H_BH4", tempDatasheet[0].hdr_name4);
                    result.Add("H_BH5", tempDatasheet[0].hdr_name5);
                    result.Add("H_BH6", tempDatasheet[0].hdr_name6);
                    result.Add("H_BH7", tempDatasheet[0].hdr_name7);
                    result.Add("H_BH8", tempDatasheet[0].hdr_name8);
                    result.Add("H_BH9", tempDatasheet[0].hdr_name9);
                    result.Add("H_BH10", tempDatasheet[0].hdr_name10);
                    result.Add("H_MR1", tempDatasheet[0].value_header1);
                    result.Add("H_MR2", tempDatasheet[0].value_header2);
                    result.Add("H_MR3", tempDatasheet[0].value_header3);
                    result.Add("H_MR4", tempDatasheet[0].value_header4);
                    result.Add("H_MR5", tempDatasheet[0].value_header5);
                    result.Add("H_MR6", tempDatasheet[0].value_header6);
                    result.Add("H_MR7", tempDatasheet[0].value_header7);
                    result.Add("H_MR8", tempDatasheet[0].value_header8);
                    result.Add("H_MR9", tempDatasheet[0].value_header9);
                    result.Add("H_MR10", tempDatasheet[0].value_header10);
                    if (MC.MasterHeader.Count > 0)
                    {
                        result.Add("H_MRC1", tempDatasheet[0].op_hdr1);
                        result.Add("H_MRC2", tempDatasheet[0].op_hdr2);
                        result.Add("H_MRC3", tempDatasheet[0].op_hdr3);
                    }
                    result.Add("H_ER1", tempDatasheet[0].value_header31);
                    result.Add("H_ER2", tempDatasheet[0].value_header32);
                    result.Add("H_ER3", tempDatasheet[0].value_header33);
                    result.Add("H_ER4", tempDatasheet[0].value_header34);
                    result.Add("H_ER5", tempDatasheet[0].value_header35);
                    result.Add("H_ER6", tempDatasheet[0].value_header36);
                    result.Add("H_ER7", tempDatasheet[0].value_header37);
                    result.Add("H_ER8", tempDatasheet[0].value_header38);
                    result.Add("H_ER9", tempDatasheet[0].value_header39);
                    result.Add("H_ER10", tempDatasheet[0].value_header40);
                    if (MC.UnitHeader.Count > 0)
                    {
                        result.Add("H_ERC1", tempDatasheet[0].op_hdr1);
                        result.Add("H_ERC2", tempDatasheet[0].op_hdr2);
                        result.Add("H_ERC3", tempDatasheet[0].op_hdr3);
                    }

                    result.Add("H_BH11", tempDatasheet[1].hdr_name1);
                    result.Add("H_BH12", tempDatasheet[1].hdr_name2);
                    result.Add("H_BH13", tempDatasheet[1].hdr_name3);
                    result.Add("H_BH14", tempDatasheet[1].hdr_name4);
                    result.Add("H_BH15", tempDatasheet[1].hdr_name5);
                    result.Add("H_BH16", tempDatasheet[1].hdr_name6);
                    result.Add("H_BH17", tempDatasheet[1].hdr_name7);
                    result.Add("H_BH18", tempDatasheet[1].hdr_name8);
                    result.Add("H_BH19", tempDatasheet[1].hdr_name9);
                    result.Add("H_BH20", tempDatasheet[1].hdr_name10);
                    result.Add("H_MR11", tempDatasheet[1].value_header1);
                    result.Add("H_MR12", tempDatasheet[1].value_header2);
                    result.Add("H_MR13", tempDatasheet[1].value_header3);
                    result.Add("H_MR14", tempDatasheet[1].value_header4);
                    result.Add("H_MR15", tempDatasheet[1].value_header5);
                    result.Add("H_MR16", tempDatasheet[1].value_header6);
                    result.Add("H_MR17", tempDatasheet[1].value_header7);
                    result.Add("H_MR18", tempDatasheet[1].value_header8);
                    result.Add("H_MR19", tempDatasheet[1].value_header9);
                    result.Add("H_MR20", tempDatasheet[1].value_header10);
                    if (MC.MasterHeader.Count > 0)
                    {
                        result.Add("H_MRC4", tempDatasheet[1].op_hdr1);
                        result.Add("H_MRC5", tempDatasheet[1].op_hdr2);
                        result.Add("H_MRC6", tempDatasheet[1].op_hdr3);
                    }
                    result.Add("H_ER11", tempDatasheet[1].value_header31);
                    result.Add("H_ER12", tempDatasheet[1].value_header32);
                    result.Add("H_ER13", tempDatasheet[1].value_header33);
                    result.Add("H_ER14", tempDatasheet[1].value_header34);
                    result.Add("H_ER15", tempDatasheet[1].value_header35);
                    result.Add("H_ER16", tempDatasheet[1].value_header36);
                    result.Add("H_ER17", tempDatasheet[1].value_header37);
                    result.Add("H_ER18", tempDatasheet[1].value_header38);
                    result.Add("H_ER19", tempDatasheet[1].value_header39);
                    result.Add("H_ER20", tempDatasheet[1].value_header40);
                    if (MC.UnitHeader.Count > 0)
                    {
                        result.Add("H_ERC4", tempDatasheet[1].op_hdr1);
                        result.Add("H_ERC5", tempDatasheet[1].op_hdr2);
                        result.Add("H_ERC6", tempDatasheet[1].op_hdr3);
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
            return result;
        }
        private Dictionary<string, string> getParametersList2()
        {
            List<RptTestType> tempDatasheet = MCTemp.RptDatasheet.GroupBy(x => x.test_type_code).Select(Z => Z.FirstOrDefault()).ToList();
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                if (tempDatasheet.Count == 1)
                {
                    if (MC.MasterHeader.Count > 0)
                    {
                        result.Add("H_MRC1", tempDatasheet[0].hdr_name1);
                        result.Add("H_MRC2", tempDatasheet[0].hdr_name2);
                        result.Add("H_MRC3", tempDatasheet[0].hdr_name3);
                    }
                    if (MC.UnitHeader.Count > 0)
                    {
                        result.Add("H_ERC1", tempDatasheet[0].hdr_name1);
                        result.Add("H_ERC2", tempDatasheet[0].hdr_name2);
                        result.Add("H_ERC3", tempDatasheet[0].hdr_name3);
                    }
                    if (MC.MasterHeader.Count > 0)
                    {
                        result.Add("H_MRC4", null);
                        result.Add("H_MRC5", null);
                        result.Add("H_MRC6", null);
                    }
                    if (MC.UnitHeader.Count > 0)
                    {
                        result.Add("H_ERC4", null);
                        result.Add("H_ERC5", null);
                        result.Add("H_ERC6", null);
                    }
                }
                else if (tempDatasheet.Count == 2)
                {
                    if (MC.MasterHeader.Count > 0)
                    {
                        result.Add("H_MRC1", tempDatasheet[0].hdr_name1);
                        result.Add("H_MRC2", tempDatasheet[0].hdr_name2);
                        result.Add("H_MRC3", tempDatasheet[0].hdr_name3);
                    }
                    if (MC.UnitHeader.Count > 0)
                    {
                        result.Add("H_ERC1", tempDatasheet[0].hdr_name1);
                        result.Add("H_ERC2", tempDatasheet[0].hdr_name2);
                        result.Add("H_ERC3", tempDatasheet[0].hdr_name3);
                    }
                    //result.Add("H_BH11", tempDatasheet[1].hdr_name1);
                    if (MC.MasterHeader.Count > 0)
                    {
                        result.Add("H_MRC4", tempDatasheet[1].hdr_name1);
                        result.Add("H_MRC5", tempDatasheet[1].hdr_name2);
                        result.Add("H_MRC6", tempDatasheet[1].hdr_name3);
                    }
                    if (MC.UnitHeader.Count > 0)
                    {
                        result.Add("H_ERC4", tempDatasheet[1].hdr_name1);
                        result.Add("H_ERC5", tempDatasheet[1].hdr_name2);
                        result.Add("H_ERC6", tempDatasheet[1].hdr_name3);
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
            return result;
        }
        protected override void OnRemoveAction(InquiryActionResult<QMS_T001> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<QMS_T001> result)
        {
            try
            {
                CursorControl.SetBusyState();
                if (Validation() == true)
                {
                    Logging();
                    MasterEntity.XmlDataDocument_QMS_T001_B = obj.ObjectToXML(TestTypeEntity);
                    MasterEntity.XmlDataDocument_QMS_M003_B = obj.ObjectToXML(ParameterEntity);
                    MasterEntity.XmlDataDocument_QMS_T001_E = obj.ObjectToXML(TaskListEntity);
                    MasterEntity.XmlDataDocument_QMS_T001_A = obj.ObjectToXML(MasterEquipmentEntity);
                    MasterEntity.XmlDataDocument_QMS_T001_F = obj.ObjectToXML(EnvCondEntity);
                    MasterEntity.XmlDataDocument_QMS_M009_B = "";
                    MasterEntity.XmlDataDocument_QMS_M009_C = "";
                    MasterEntity.XmlDataDocument_QMS_M009_D = "";
                    MasterEntity.XmlDataDocument_QMS_M009_E_I = "";
                    MasterEntity.XmlDataDocument_QMS_M009_E_M = "";
                    MasterEntity.XmlDataDocument_QMS_M009_J = "";

                    this.MasterEntity.EndEdit();

                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<QMS_T001>(MasterEntity, "CalibrationView", "QMS");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<QMS_T001>(MasterEntity, "CalibrationView", "QMS");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
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
                    isNewRecord = false;
                    var msg = new NotificationMessage("QMS_T001_VM");
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
        private void AssignHeaders()
        {
            int k = 1;
            foreach (var item in MCTemp.RptDatasheet)
            {
                item.hdr_id = k;
                List<QMS_M009_C> tempBenchHeader = (from z in MC.BenchHeader where z.test_type_code == item.test_type_code select z).ToList();
                if (tempBenchHeader != null && tempBenchHeader.Count >= 1)
                {
                    for (int i = 0; i < tempBenchHeader.Count; i++)
                    {
                        if (i == 0)
                        {
                            item.hdr_name1 = tempBenchHeader[i].hdr_name;
                        }
                        else if (i == 1)
                        {
                            item.hdr_name2 = tempBenchHeader[i].hdr_name;
                        }
                        else if (i == 2)
                        {
                            item.hdr_name3 = tempBenchHeader[i].hdr_name;
                        }
                        else if (i == 3)
                        {
                            item.hdr_name4 = tempBenchHeader[i].hdr_name;
                        }
                        else if (i == 4)
                        {
                            item.hdr_name5 = tempBenchHeader[i].hdr_name;
                        }
                        else if (i == 5)
                        {
                            item.hdr_name6 = tempBenchHeader[i].hdr_name;
                        }
                        else if (i == 6)
                        {
                            item.hdr_name7 = tempBenchHeader[i].hdr_name;
                        }
                        else if (i == 7)
                        {
                            item.hdr_name8 = tempBenchHeader[i].hdr_name;
                        }
                        else if (i == 8)
                        {
                            item.hdr_name9 = tempBenchHeader[i].hdr_name;
                        }
                        else if (i == 9)
                        {
                            item.hdr_name10 = tempBenchHeader[i].hdr_name;
                        }
                    }
                }

                List<QMS_M009_E> tempMasterHeader = (from z in MC.MasterHeader where z.test_type_code == item.test_type_code select z).ToList();
                if (tempMasterHeader != null && tempMasterHeader.Count > 0)
                {
                    for (int i = 0; i < tempMasterHeader.Count; i++)
                    {
                        if (i == 0)
                        {
                            item.value_header1 = tempMasterHeader[i].short_name;
                        }
                        else if (i == 1)
                        {
                            item.value_header2 = tempMasterHeader[i].short_name;
                        }
                        else if (i == 2)
                        {
                            item.value_header3 = tempMasterHeader[i].short_name;
                        }
                        else if (i == 3)
                        {
                            item.value_header4 = tempMasterHeader[i].short_name;
                        }
                        else if (i == 4)
                        {
                            item.value_header5 = tempMasterHeader[i].short_name;
                        }
                        else if (i == 5)
                        {
                            item.value_header6 = tempMasterHeader[i].short_name;
                        }
                        else if (i == 6)
                        {
                            item.value_header7 = tempMasterHeader[i].short_name;
                        }
                        else if (i == 7)
                        {
                            item.value_header8 = tempMasterHeader[i].short_name;
                        }
                        else if (i == 8)
                        {
                            item.value_header9 = tempMasterHeader[i].short_name;
                        }
                        else if (i == 9)
                        {
                            item.value_header10 = tempMasterHeader[i].short_name;
                        }
                        else if (i == 10)
                        {
                            item.value_header11 = tempMasterHeader[i].short_name;
                        }
                        else if (i == 11)
                        {
                            item.value_header12 = tempMasterHeader[i].short_name;
                        }
                        else if (i == 12)
                        {
                            item.value_header13 = tempMasterHeader[i].short_name;
                        }
                        else if (i == 13)
                        {
                            item.value_header14 = tempMasterHeader[i].short_name;
                        }
                        else if (i == 14)
                        {
                            item.value_header15 = tempMasterHeader[i].short_name;
                        }
                        else if (i == 15)
                        {
                            item.value_header16 = tempMasterHeader[i].short_name;
                        }
                        else if (i == 16)
                        {
                            item.value_header17 = tempMasterHeader[i].short_name;
                        }
                        else if (i == 17)
                        {
                            item.value_header18 = tempMasterHeader[i].short_name;
                        }
                        else if (i == 18)
                        {
                            item.value_header19 = tempMasterHeader[i].short_name;
                        }
                        else if (i == 19)
                        {
                            item.value_header20 = tempMasterHeader[i].short_name;
                        }
                    }
                }

                List<QMS_M009_E> tempUnitHeader = (from z in MC.UnitHeader where z.test_type_code == item.test_type_code select z).ToList();
                if (tempUnitHeader != null && tempUnitHeader.Count > 0)
                {
                    for (int i = 0; i < tempUnitHeader.Count; i++)
                    {
                        if (i == 0)
                        {
                            item.value_header31 = tempUnitHeader[i].short_name;
                        }
                        else if (i == 1)
                        {
                            item.value_header32 = tempUnitHeader[i].short_name;
                        }
                        else if (i == 2)
                        {
                            item.value_header33 = tempUnitHeader[i].short_name;
                        }
                        else if (i == 3)
                        {
                            item.value_header34 = tempUnitHeader[i].short_name;
                        }
                        else if (i == 4)
                        {
                            item.value_header35 = tempUnitHeader[i].short_name;
                        }
                        else if (i == 5)
                        {
                            item.value_header36 = tempUnitHeader[i].short_name;
                        }
                        else if (i == 6)
                        {
                            item.value_header37 = tempUnitHeader[i].short_name;
                        }
                        else if (i == 7)
                        {
                            item.value_header38 = tempUnitHeader[i].short_name;
                        }
                        else if (i == 8)
                        {
                            item.value_header39 = tempUnitHeader[i].short_name;
                        }
                        else if (i == 9)
                        {
                            item.value_header40 = tempUnitHeader[i].short_name;
                        }
                        else if (i == 10)
                        {
                            item.value_header41 = tempUnitHeader[i].short_name;
                        }
                        else if (i == 11)
                        {
                            item.value_header42 = tempUnitHeader[i].short_name;
                        }
                        else if (i == 12)
                        {
                            item.value_header43 = tempUnitHeader[i].short_name;
                        }
                        else if (i == 13)
                        {
                            item.value_header44 = tempUnitHeader[i].short_name;
                        }
                        else if (i == 14)
                        {
                            item.value_header45 = tempUnitHeader[i].short_name;
                        }
                        else if (i == 15)
                        {
                            item.value_header46 = tempUnitHeader[i].short_name;
                        }
                        else if (i == 16)
                        {
                            item.value_header47 = tempUnitHeader[i].short_name;
                        }
                        else if (i == 17)
                        {
                            item.value_header48 = tempUnitHeader[i].short_name;
                        }
                        else if (i == 18)
                        {
                            item.value_header49 = tempUnitHeader[i].short_name;
                        }
                        else if (i == 19)
                        {
                            item.value_header50 = tempUnitHeader[i].short_name;
                        }
                    }
                }

                List<QMS_M009_B> tempTestType = (from z in MC.TestType where z.test_type_code == item.test_type_code select z).ToList();
                if (tempTestType != null && tempTestType.Count > 0)
                {
                    for (int i = 0; i < tempTestType.Count; i++)
                    {
                        if (tempTestType[i].op_hdr == "Minimum")
                        {
                            item.op_hdr1 = tempTestType[i].op_hdr;
                        }
                        else if (tempTestType[i].op_hdr == "Maximum")
                        {
                            item.op_hdr2 = tempTestType[i].op_hdr;
                        }
                        else if (tempTestType[i].op_hdr == "Average")
                        {
                            item.op_hdr3 = tempTestType[i].op_hdr;
                        }
                    }
                }
                k++;
            }
        }

      

        #endregion

    }
    public class QMSDecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    value = DoUserFormat(value, Settings.decimal_digits.ToString());
                    return value;
                }
                return value;
            }
            catch (Exception Ex) { return value; }
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                if (value != null)
                {
                    value = DoUserFormat(value, Settings.decimal_digits.ToString());
                    return value;
                }
                return value;
            }
            catch (Exception Ex) { return value; }
        }
        public string DoUserFormat(object value, string decimal_digit)
        {
            string str = value.ToString();
            if (str.Contains(NumberFormatInfo.CurrentInfo.NegativeSign))
            {
                str = NumberFormatInfo.CurrentInfo.NegativeSign + str.Replace(NumberFormatInfo.CurrentInfo.NegativeSign, string.Empty);
            }
            if (str.Contains(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator))
            {
                int ind = str.IndexOf(NumberFormatInfo.CurrentInfo.NumberDecimalSeparator);
                if (ind == -1)
                {
                    return str;
                }
                else
                {
                    if (str.Contains(NumberFormatInfo.CurrentInfo.NegativeSign))
                    {
                        str = NumberFormatInfo.CurrentInfo.NegativeSign + str.Replace(NumberFormatInfo.CurrentInfo.NegativeSign, string.Empty);
                    }
                    string s;
                    int digitinput = System.Convert.ToInt32(decimal_digit); //user input
                    switch (digitinput)
                    {
                        case 0:
                            s = string.Format("{0:0}", System.Convert.ToDecimal(str));
                            return s;
                        case 1:
                            s = string.Format("{0:0.0}", System.Convert.ToDecimal(str));
                            return s;
                        case 2:
                            s = string.Format("{0:0.00}", System.Convert.ToDecimal(str));
                            return s;
                        case 3:
                            s = string.Format("{0:0.000}", System.Convert.ToDecimal(str));
                            return s;
                        case 4:
                            s = string.Format("{0:0.0000}", System.Convert.ToDecimal(str));
                            return s;
                        case 5:
                            s = string.Format("{0:0.00000}", System.Convert.ToDecimal(str));
                            return s;
                        case 6:
                            s = string.Format("{0:0.000000}", System.Convert.ToDecimal(str));
                            return s;
                        case 7:
                            s = string.Format("{0:0.0000000}", System.Convert.ToDecimal(str));
                            return s;
                        case 8:
                            s = string.Format("{0:0.00000000}", System.Convert.ToDecimal(str));
                            return s;
                    }
                }
            }
            return str;
        }
    }
}
