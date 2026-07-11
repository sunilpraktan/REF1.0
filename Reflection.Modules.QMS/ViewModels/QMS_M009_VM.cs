using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using System.Collections.ObjectModel;
using Reflection.BusinessEntity;
using Reflection.Presentation.Services;
using System.Collections.Specialized;
using Reflection.Presentation.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity.QMS;
using System.Windows;
using Reflection.Presentation.Services.Convertors;
using Reflection.Presentation.Common;

namespace Reflection.Modules.QMS.ViewModels
{
    public class QMS_M009_VM : WorkspaceViewModel<QMS_M009_A>
    {
        int deletion_id = 0;
        bool isNewRecord = true;
        internal string TestTypeParameter;
        WebServiceRepository<QMS_M009_A> repository = new WebServiceRepository<QMS_M009_A>();
        WebServiceRepository<MultipleContext_QMS_M009> repository_MC = new WebServiceRepository<MultipleContext_QMS_M009>();
        WebServiceRepository<MultipleContext_QMS_M009> repository_MCTemp = new WebServiceRepository<MultipleContext_QMS_M009>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(QMS_M009_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        // 3 variables for dependent datagrids which does not lost the selected value of datagrid.
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

        private AutoSuggestTextViewModel<dynamic> _ASDefault6 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault6
        {
            get { return _ASDefault6; }
            set
            {
                if (_ASDefault6 != value)
                {
                    _ASDefault6 = value; RaisePropertyChanged("ASDefault6");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDefault7 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault7
        {
            get { return _ASDefault7; }
            set
            {
                if (_ASDefault7 != value)
                {
                    _ASDefault7 = value; RaisePropertyChanged("ASDefault7");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASDefault8 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDefault8
        {
            get { return _ASDefault8; }
            set
            {
                if (_ASDefault8 != value)
                {
                    _ASDefault8 = value; RaisePropertyChanged("ASDefault8");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCat { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCat
        {
            get { return _ASCat; }
            set
            {
                if (_ASCat != value)
                {
                    _ASCat = value; RaisePropertyChanged("ASCat");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASInspType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASInspType
        {
            get { return _ASInspType; }
            set
            {
                if (_ASInspType != value)
                {
                    _ASInspType = value; RaisePropertyChanged("ASInspType");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASTP { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTP
        {
            get { return _ASTP; }
            set
            {
                if (_ASTP != value)
                {
                    _ASTP = value; RaisePropertyChanged("ASTP");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASWI { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASWI
        {
            get { return _ASWI; }
            set
            {
                if (_ASWI != value)
                {
                    _ASWI = value; RaisePropertyChanged("ASWI");
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

        private AutoSuggestTextViewModel<dynamic> _ASParaValueUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASParaValueUnit
        {
            get { return _ASParaValueUnit; }
            set
            {
                if (_ASParaValueUnit != value)
                {
                    _ASParaValueUnit = value; RaisePropertyChanged("ASParaValueUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASTestTypeUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTestTypeUnit
        {
            get { return _ASTestTypeUnit; }
            set
            {
                if (_ASTestTypeUnit != value)
                {
                    _ASTestTypeUnit = value; RaisePropertyChanged("ASTestTypeUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASHeaderUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASHeaderUnit
        {
            get { return _ASHeaderUnit; }
            set
            {
                if (_ASHeaderUnit != value)
                {
                    _ASHeaderUnit = value; RaisePropertyChanged("ASHeaderUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASHeaderValueUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASHeaderValueUnit
        {
            get { return _ASHeaderValueUnit; }
            set
            {
                if (_ASHeaderValueUnit != value)
                {
                    _ASHeaderValueUnit = value; RaisePropertyChanged("ASHeaderValueUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASCalMaster { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCalMaster
        {
            get { return _ASCalMaster; }
            set
            {
                if (_ASCalMaster != value)
                {
                    _ASCalMaster = value; RaisePropertyChanged("ASCalMaster");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASFormulaCode { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASFormulaCode
        {
            get { return _ASFormulaCode; }
            set
            {
                if (_ASFormulaCode != value)
                {
                    _ASFormulaCode = value; RaisePropertyChanged("ASFormulaCode");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASEnvCond { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASEnvCond
        {
            get { return _ASEnvCond; }
            set
            {
                if (_ASEnvCond != value)
                {
                    _ASEnvCond = value; RaisePropertyChanged("ASEnvCond");
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
        private AutoSuggestTextViewModel<dynamic> _ASItemService { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItemService
        {
            get { return _ASItemService; }
            set
            {
                if (_ASItemService != value)
                {
                    _ASItemService = value; RaisePropertyChanged("ASItemService");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASStandardValuesUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASStandardValuesUnit
        {
            get { return _ASStandardValuesUnit; }
            set
            {
                if (_ASStandardValuesUnit != value)
                {
                    _ASStandardValuesUnit = value; RaisePropertyChanged("ASStandardValuesUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASTestType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASTestType
        {
            get { return _ASTestType; }
            set
            {
                if (_ASTestType != value)
                {
                    _ASTestType = value; RaisePropertyChanged("ASTestType");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASEnvCondUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASEnvCondUnit
        {
            get { return _ASEnvCondUnit; }
            set
            {
                if (_ASEnvCondUnit != value)
                {
                    _ASEnvCondUnit = value; RaisePropertyChanged("ASEnvCondUnit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASResolutionunit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASResolutionunit
        {
            get { return _ASResolutionunit; }
            set
            {
                if (_ASResolutionunit != value)
                {
                    _ASResolutionunit = value; RaisePropertyChanged("ASResolutionunit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASResolutionUnitMaster { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASResolutionUnitMaster
        {
            get { return _ASResolutionUnitMaster; }
            set
            {
                if (_ASResolutionUnitMaster != value)
                {
                    _ASResolutionUnitMaster = value; RaisePropertyChanged("ASResolutionUnitMaster");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASUncertaintyUnitMaster { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASUncertaintyUnitMaster
        {
            get { return _ASUncertaintyUnitMaster; }
            set
            {
                if (_ASUncertaintyUnitMaster != value)
                {
                    _ASUncertaintyUnitMaster = value; RaisePropertyChanged("ASUncertaintyUnitMaster");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASInspectionChar { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASInspectionChar
        {
            get { return _ASInspectionChar; }
            set
            {
                if (_ASInspectionChar != value)
                {
                    _ASInspectionChar = value; RaisePropertyChanged("ASInspectionChar");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASAccuracyUpUnitMaster { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccuracyUpUnitMaster
        {
            get { return _ASAccuracyUpUnitMaster; }
            set
            {
                if (_ASAccuracyUpUnitMaster != value)
                {
                    _ASAccuracyUpUnitMaster = value; RaisePropertyChanged("ASAccuracyUpUnitMaster");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASAccuracyDownUnitMaster { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASAccuracyDownUnitMaster
        {
            get { return _ASAccuracyDownUnitMaster; }
            set
            {
                if (_ASAccuracyDownUnitMaster != value)
                {
                    _ASAccuracyDownUnitMaster = value; RaisePropertyChanged("ASAccuracyDownUnitMaster");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASValueFromUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASValueFromUnit
        {
            get { return _ASValueFromUnit; }
            set
            {
                if (_ASValueFromUnit != value)
                {
                    _ASValueFromUnit = value; RaisePropertyChanged("ASValueFromUnit");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASValueToUnit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASValueToUnit
        {
            get { return _ASValueToUnit; }
            set
            {
                if (_ASValueToUnit != value)
                {
                    _ASValueToUnit = value; RaisePropertyChanged("ASValueToUnit");
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

        private AutoSuggestTextViewModel<dynamic> _ASMasterHeader { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASMasterHeader
        {
            get { return _ASMasterHeader; }
            set
            {
                if (_ASMasterHeader != value)
                {
                    _ASMasterHeader = value; RaisePropertyChanged("ASMasterHeader");
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
                    { ASDefault = ASUnitCode; }
                    else if (SourceName == "master_inst")
                    { ASDefault = ASCalMaster; }
                    else if (SourceName == "tl_code")
                    { ASDefault4 = ASTaskList; }
                    else if (SourceName == "para_unit_code")
                    { ASDefault5 = ASUnitCode; }
                    else if (SourceName == "value_unit_code")
                    { ASDefault6 = ASUnitCode; }
                    else if (SourceName == "master_unit_code")
                    { ASDefault7 = ASStandardValuesUnit; }
                    else if (SourceName == "test_type_code")
                    { ASDefault7 = ASTestType; }
                    else if (SourceName == "header_name")
                    { ASDefault7 = ASMasterHeader; }
                    else if (SourceName == "uncertainty_unit_master")
                    { ASDefault7 = ASUncertaintyUnitMaster; }
                    else if (SourceName == "accuracy_up_unit_master")
                    { ASDefault7 = ASAccuracyUpUnitMaster; }
                    else if (SourceName == "accuracy_down_unit_master")
                    { ASDefault7 = ASAccuracyDownUnitMaster; }
                    else if (SourceName == "resolution_unit_master")
                    { ASDefault7 = ASResolutionUnitMaster; }
                    else if (SourceName == "env_code")
                    { ASDefault8 = ASEnvCond; }
                    else if (SourceName == "std_value_unit")
                    { ASDefault8 = ASEnvCondUnit; }
                    else if (SourceName == "resolution_unit")
                    { ASDefault8 = ASResolutionunit; }
                    else if (SourceName == "insp_char")
                    { ASDefault2 = ASInspectionChar; }
                    else if (SourceName == "value_from_unit")
                    { ASDefault3 = ASValueFromUnit; }
                    else if (SourceName == "value_to_unit")
                    { ASDefault3 = ASValueToUnit; }
                    else if (SourceName == "hdr_unit_code")
                    { ASDefault2 = ASHeaderUnit; }                    
                }
            }
        }

        #endregion

        #region Declaration
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        #region Entities
        private QMS_M009_A _MasterEntity;
        public QMS_M009_A MasterEntity
        {
            get { return _MasterEntity; }
            set { _MasterEntity = value; RaisePropertyChanged("MasterEntity"); }
        }

        private ObservableCollection<QMS_M009_B> _TestTypeEntity;
        public ObservableCollection<QMS_M009_B> TestTypeEntity
        {
            get { return _TestTypeEntity; }
            set
            {
                _TestTypeEntity = value;
                TestTypeEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTestType);
                RaisePropertyChanged("TestTypeEntity");
            }
        }

        private ObservableCollection<QMS_M009_C> _TestHeaderEntity;
        public ObservableCollection<QMS_M009_C> TestHeaderEntity
        {
            get { return _TestHeaderEntity; }
            set
            {
                if (TestHeaderEntity != value)
                {
                    _TestHeaderEntity = value;
                    TestHeaderEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTestHeader);
                    RaisePropertyChanged("TestHeaderEntity");
                }
            }
        }

        private ObservableCollection<QMS_M009_D> _HeaderValueEntity;
        public ObservableCollection<QMS_M009_D> HeaderValueEntity
        {
            get { return _HeaderValueEntity; }
            set
            {
                _HeaderValueEntity = value;
                HeaderValueEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForHeaderValue);
                RaisePropertyChanged("HeaderValueEntity");
            }
        }

        private ObservableCollection<QMS_M009_E> _MasterHeaderEntity;
        public ObservableCollection<QMS_M009_E> MasterHeaderEntity
        {
            get { return _MasterHeaderEntity; }
            set
            {
                _MasterHeaderEntity = value;
                MasterHeaderEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForMasterHeader);
                RaisePropertyChanged("MasterHeaderEntity");
            }
        }

        private ObservableCollection<QMS_M009_E> _InstHeaderEntity;
        public ObservableCollection<QMS_M009_E> InstHeaderEntity
        {
            get { return _InstHeaderEntity; }
            set
            {
                _InstHeaderEntity = value;
                InstHeaderEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForInstHeader);
                RaisePropertyChanged("InstHeaderEntity");
            }
        }

        private ObservableCollection<QMS_M009_F> _ParameterEntity;
        public ObservableCollection<QMS_M009_F> ParameterEntity
        {
            get { return _ParameterEntity; }
            set
            {
                _ParameterEntity = value;
                ParameterEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForParameter);
                RaisePropertyChanged("ParameterEntity");
            }
        }

        private ObservableCollection<QMS_M009_G> _ParameterValueEntity;
        public ObservableCollection<QMS_M009_G> ParameterValueEntity
        {
            get { return _ParameterValueEntity; }
            set
            {
                _ParameterValueEntity = value;
                ParameterValueEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForParameterValue);
                RaisePropertyChanged("ParameterValueEntity");
            }
        }

        private ObservableCollection<QMS_M009_H> _TaskListEntity;
        public ObservableCollection<QMS_M009_H> TaskListEntity
        {
            get { return _TaskListEntity; }
            set
            {
                _TaskListEntity = value;
                RaisePropertyChanged("TaskListEntity");
            }
        }

        private ObservableCollection<QMS_M009_J> _MasterValueEntity;
        public ObservableCollection<QMS_M009_J> MasterValueEntity
        {
            get { return _MasterValueEntity; }
            set
            {
                _MasterValueEntity = value;
                MasterValueEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForMasterValue);
                RaisePropertyChanged("MasterValueEntity");
            }
        }

        private ObservableCollection<QMS_M009_K> _EnvConditionEntity;
        public ObservableCollection<QMS_M009_K> EnvConditionEntity
        {
            get { return _EnvConditionEntity; }
            set
            {
                _EnvConditionEntity = value;
                EnvConditionEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForEnvCond);
                RaisePropertyChanged("EnvConditionEntity");
            }
        }
        #endregion

        #region Datagrid Indexes
        private int _dgSelectedIndexParaCode;
        public int dgSelectedIndexParaCode
        {
            get { return _dgSelectedIndexParaCode; }
            set
            {
                _dgSelectedIndexParaCode = value;
                FilterParaCodeDataGrid();
                RaisePropertyChanged("dgSelectedIndexParaCode");
            }
        }

        private int _dgSelectedIndexParaValue;
        public int dgSelectedIndexParaValue
        {
            get { return _dgSelectedIndexParaValue; }
            set { _dgSelectedIndexParaValue = value; RaisePropertyChanged("dgSelectedIndexParaValue"); }
        }

        private int _dgSelectedIndexTestType;
        public int dgSelectedIndexTestType
        {
            get { return _dgSelectedIndexTestType; }
            set
            {
                if (TestTypeEntity != null && dgSelectedIndexTestType != value && value < TestTypeEntity.Count)
                {
                    _dgSelectedIndexTestType = value;
                    FilterTestTypeDataGrid();
                    RaisePropertyChanged("dgSelectedIndexTestType");
                }
            }
        }

        private int _dgSelectedIndexHeader;
        public int dgSelectedIndexHeader
        {
            get { return _dgSelectedIndexHeader; }
            set
            {
                _dgSelectedIndexHeader = value;
                //FilterTestHeaderDataGrid();
                RaisePropertyChanged("dgSelectedIndexHeader");
            }
        }

        private int _dgSelectedIndexHeaderValue;
        public int dgSelectedIndexHeaderValue
        {
            get { return _dgSelectedIndexHeaderValue; }
            set { _dgSelectedIndexHeaderValue = value; RaisePropertyChanged("dgSelectedIndexHeaderValue"); }
        }

        private int _dgSelectedIndexMasterHeader;
        public int dgSelectedIndexMasterHeader
        {
            get { return _dgSelectedIndexMasterHeader; }
            set { _dgSelectedIndexMasterHeader = value; RaisePropertyChanged("dgSelectedIndexMasterHeader"); }
        }

        private int _dgSelectedIndexInstHeader;
        public int dgSelectedIndexInstHeader
        {
            get { return _dgSelectedIndexInstHeader; }
            set { _dgSelectedIndexInstHeader = value; RaisePropertyChanged("dgSelectedIndexInstHeader"); }
        }

        private int _dgSelectedIndexTaskList;
        public int dgSelectedIndexTaskList
        {
            get { return _dgSelectedIndexTaskList; }
            set { _dgSelectedIndexTaskList = value; RaisePropertyChanged("dgSelectedIndexTaskList"); }
        }

        private int _dgSelectedIndexMasterValue;
        public int dgSelectedIndexMasterValue
        {
            get { return _dgSelectedIndexMasterValue; }
            set { _dgSelectedIndexMasterValue = value; RaisePropertyChanged("dgSelectedIndexMasterValue"); }
        }

        private int _dgSelectedIndexEnvCond;
        public int dgSelectedIndexEnvCond
        {
            get { return _dgSelectedIndexEnvCond; }
            set { _dgSelectedIndexEnvCond = value; RaisePropertyChanged("dgSelectedIndexEnvCond"); }
        }

        #endregion

        private MultipleContext_QMS_M009 _MC;
        public MultipleContext_QMS_M009 MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MultipleContext_QMS_M009 _MCTemp;
        public MultipleContext_QMS_M009 MCTemp
        {
            get { return _MCTemp; }
            set { _MCTemp = value; RaisePropertyChanged("MCTemp"); }
        }

        private List<QMS_M009Flip> _FlipGridData;
        public List<QMS_M009Flip> FlipGridData
        {
            get { return _FlipGridData; }
            set { _FlipGridData = value; RaisePropertyChanged("FlipGridData"); }
        }

        private int _SelectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get { return _SelectedTabControlIndex; }
            set
            {
                if (_SelectedTabControlIndex != value)
                {
                    _SelectedTabControlIndex = value;
                    RaisePropertyChanged("SelectedTabControlIndex");
                }
            }
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

        #region Temp Collection
        private ICollectionView _ParaValueDataGrid;
        public ICollectionView ParaValueDataGrid
        {
            get { return _ParaValueDataGrid; }
            set { _ParaValueDataGrid = value; RaisePropertyChanged("ParaValueDataGrid"); }
        }

        private ICollectionView _TestTypeDataGrid;
        public ICollectionView TestTypeDataGrid
        {
            get { return _TestTypeDataGrid; }
            set { _TestTypeDataGrid = value; RaisePropertyChanged("TestTypeDataGrid"); }
        }

        private ICollectionView _MasterHeaderDataGrid;
        public ICollectionView MasterHeaderDataGrid
        {
            get { return _MasterHeaderDataGrid; }
            set { _MasterHeaderDataGrid = value; RaisePropertyChanged("MasterHeaderDataGrid"); }
        }

        private ICollectionView _InstHeaderDataGrid;
        public ICollectionView InstHeaderDataGrid
        {
            get { return _InstHeaderDataGrid; }
            set { _InstHeaderDataGrid = value; RaisePropertyChanged("InstHeaderDataGrid"); }
        }

        private ICollectionView _HeaderValueDataGrid;
        public ICollectionView HeaderValueDataGrid
        {
            get { return _HeaderValueDataGrid; }
            set { _HeaderValueDataGrid = value; RaisePropertyChanged("HeaderValueDataGrid"); }
        }

        private ICollectionView _MasterValueDataGrid;
        public ICollectionView MasterValueDataGrid
        {
            get { return _MasterValueDataGrid; }
            set { _MasterValueDataGrid = value; RaisePropertyChanged("MasterValueDataGrid"); }
        }

        private ICollectionView _EnvCondDataGrid;
        public ICollectionView EnvCondDataGrid
        {
            get { return _EnvCondDataGrid; }
            set { _EnvCondDataGrid = value; RaisePropertyChanged("EnvCondDataGrid"); }
        }

        #endregion

        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdAddCalMaster { get; private set; }
        public RelayCommand<object> CmdAddCat { get; private set; }
        public RelayCommand<object> CmdAddInspType { get; private set; }
        public RelayCommand<object> CmdAddTp { get; private set; }
        public RelayCommand<object> CmdAddWi { get; private set; }
        public RelayCommand<object> CmdAddUOMParaCode { get; private set; }
        public RelayCommand<object> CmdAddUOMParaValue { get; private set; }
        public RelayCommand<object> CmdAddUOMTestType { get; private set; }
        public RelayCommand<object> CmdAddUOMHeader { get; private set; }
        public RelayCommand<object> CmdAddUOMHeaderValue { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowParaCode { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowParaValue { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowTestType { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowHeader { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowHeaderValue { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowMasterHeader { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowInstHeader { get; private set; }
        public RelayCommand<object> cmdFilterTestHeaderDataGrid { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowTaskList { get; private set; }
        public RelayCommand<object> CmdAddTaskList { get; private set; }
        public RelayCommand<object> CmdAddItem { get; private set; }
        public RelayCommand<object> CmdAddFormulaCode { get; private set; }
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
        public RelayCommand<object> CmdAddMasterHeader { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowMasterValue { get; private set; }
        public RelayCommand<object> CmdAddEnvCond { get; private set; }
        public RelayCommand<object> cmdDeleteDataGridRowEnvCond { get; private set; }
        public RelayCommand<object> CmdAddInspectionChar { get; private set; }
        public RelayCommand<object> CmdAddAccuracyUpUnit { get; private set; }
        public RelayCommand<object> CmdAddAccuracyDownUnit { get; private set; }
        public RelayCommand<object> CmdAddResolutionUnit { get; private set; }
        public RelayCommand<object> CmdAddUncertaintyUnit { get; private set; }

        #endregion

        #region Event Handler
        void MyType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (ParameterEntity.Count > dgSelectedIndexParaCode && dgSelectedIndexParaCode >= 0)
            {
                this.ErrorExist = false; /* ParameterEntity[dgSelectedIndexParaCode].HasErrors;*/
            }
            else if (ParameterValueEntity.Count > dgSelectedIndexParaValue && dgSelectedIndexParaValue >= 0)
            {
                this.ErrorExist = false; /* ParameterValueEntity[dgSelectedIndexParaValue].HasErrors;*/
            }
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
            if (ParameterEntity.Count > dgSelectedIndexParaCode && dgSelectedIndexParaCode >= 0)
            {
                this.ErrorExist = false;/*ParameterEntity[dgSelectedIndexItem].HasErrors;*/
            }
        }
        private void CollectionChangedNotifyForTestType(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (MasterEntity.test_code != null)
                {
                    //////////////////////////////////Temp Test
                    if (e.NewItems != null && e.NewItems.Count != 0)
                        foreach (QMS_M009_B item in e.NewItems)
                            item.PropertyChanged += this.MyType_PropertyChanged;

                    if (e.OldItems != null && e.OldItems.Count != 0)
                        foreach (QMS_M009_B item in e.OldItems)
                            item.PropertyChanged -= this.MyType_PropertyChanged;

                    /////////////////////////////////Temp Test End
                    //different kind of changes that may have occurred in collection
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach (QMS_M009_B item in e.NewItems)
                        {
                            item.test_code = MasterEntity.test_code;
                            item.active = true;
                            item.add_by = AppSessionState.UserID;
                            item.comp_code = AppSessionState.comp_code;
                            item.location_Id = AppSessionState.location_Id;
                            item.editby = AppSessionState.UserID;
                            item.user_source1 = AppSessionState.UserSource1;
                            item.user_source2 = AppSessionState.UserSource2;
                            item.PropertyChanged += EntityViewModelPropertyChanged;
                        }
                    }
                    if (e.Action == NotifyCollectionChangedAction.Remove)
                    {
                        QMS_M009_B temp = (QMS_M009_B)e.OldItems[0];
                        foreach (var itemToRemove in TestHeaderEntity.Where(x => (x.test_type_code == temp.test_type_code && x.hdr_id == 0)).ToList())
                        {
                            TestHeaderEntity.Remove(itemToRemove);
                        }

                        foreach (var itemToRemove in MasterHeaderEntity.Where(x => (x.test_type_code == temp.test_type_code && x.header_id == 0)).ToList())
                        {
                            MasterHeaderEntity.Remove(itemToRemove);
                        }

                        foreach (var itemToRemove in InstHeaderEntity.Where(x => (x.test_type_code == temp.test_type_code && x.header_id == 0)).ToList())
                        {
                            InstHeaderEntity.Remove(itemToRemove);
                        }
                    }
                }
                else if (e.NewItems != null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("please Enter Test Id...", this.Title);
                    showMessageService.ShowMessage();
                }
            }
            catch (Exception ex)
            { }
        }
        private void CollectionChangedNotifyForTestHeader(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (QMS_M009_C item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (QMS_M009_C item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (QMS_M009_C item in e.NewItems)
                    {
                        item.srno = deletion_id++;
                        item.test_type_code = TestTypeEntity[dgSelectedIndexTestType].test_type_code;
                        item.active = true;
                        item.add_by = AppSessionState.UserID;
                        item.editby = AppSessionState.UserID;
                        item.user_source1 = AppSessionState.UserSource1;
                        item.user_source2 = AppSessionState.UserSource2;
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    QMS_M009_C temp = (QMS_M009_C)e.OldItems[0];
                    var itemToRemove1 = HeaderValueEntity.Where(x => (x.hdr_id == temp.hdr_id && x.hdr_id == 0)).ToList();

                    foreach (var a in itemToRemove1)
                    {
                        if (a.value_id == 0)
                        {
                            HeaderValueEntity.Remove(a);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void CollectionChangedNotifyForHeaderValue(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (QMS_M009_D item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (QMS_M009_D item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (QMS_M009_D item in e.NewItems)
                    {
                        item.srno = TestHeaderEntity[dgSelectedIndexHeader].srno;
                        item.hdr_id = TestHeaderEntity[dgSelectedIndexHeader].hdr_id;
                        item.active = true;
                        item.add_by = AppSessionState.UserID;
                        item.editby = AppSessionState.UserID;
                        item.def_bit = true;
                        item.deletion_id = DateTime.Now.Ticks.GetHashCode();
                        item.user_source1 = AppSessionState.UserSource1;
                        item.user_source2 = AppSessionState.UserSource2;
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void CollectionChangedNotifyForMasterHeader(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (QMS_M009_E item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (QMS_M009_E item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (QMS_M009_E item in e.NewItems)
                    {
                        item.test_type_code = TestTypeEntity[dgSelectedIndexTestType].test_type_code;
                        item.active = true;
                        item.rdg_type = "CM";
                        item.deletion_id = DateTime.Now.Ticks.GetHashCode();
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void CollectionChangedNotifyForInstHeader(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (QMS_M009_E item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (QMS_M009_E item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (QMS_M009_E item in e.NewItems)
                    {
                        item.test_type_code = TestTypeEntity[dgSelectedIndexTestType].test_type_code;
                        item.active = true;
                        item.rdg_type = "UUC";
                        item.deletion_id = DateTime.Now.Ticks.GetHashCode();
                        item.PropertyChanged += EntityViewModelPropertyChanged;
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
                if (MasterEntity.test_code != null)
                {
                    //////////////////////////////////Temp Test
                    if (e.NewItems != null && e.NewItems.Count != 0)
                        foreach (QMS_M009_F item in e.NewItems)
                            item.PropertyChanged += this.MyType_PropertyChanged;

                    if (e.OldItems != null && e.OldItems.Count != 0)
                        foreach (QMS_M009_F item in e.OldItems)
                            item.PropertyChanged -= this.MyType_PropertyChanged;

                    /////////////////////////////////Temp Test End
                    //different kind of changes that may have occurred in collection
                    if (e.Action == NotifyCollectionChangedAction.Add)
                    {
                        foreach (QMS_M009_F item in e.NewItems)
                        {
                            item.test_code = MasterEntity.test_code;
                            item.active = true;
                            item.add_by = AppSessionState.UserID;
                            item.comp_code = AppSessionState.comp_code;
                            item.location_Id = AppSessionState.location_Id;
                            item.editby = AppSessionState.UserID;
                            item.user_source1 = AppSessionState.UserSource1;
                            item.user_source2 = AppSessionState.UserSource2;
                            item.PropertyChanged += EntityViewModelPropertyChanged;
                        }
                    }
                    if (e.Action == NotifyCollectionChangedAction.Remove)
                    {
                        QMS_M009_F temp = (QMS_M009_F)e.OldItems[0];
                        foreach (var itemToRemove in ParameterValueEntity.Where(x => (x.para_code == temp.para_code && x.id == 0)).ToList())
                        {
                            ParameterValueEntity.Remove(itemToRemove);
                        }
                    }
                }
                else if (e.NewItems != null)
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("please Enter Test Id...", this.Title);
                    showMessageService.ShowMessage();
                }
            }
            catch (Exception ex)
            { }
        }
        private void CollectionChangedNotifyForParameterValue(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (QMS_M009_G item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (QMS_M009_G item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (QMS_M009_G item in e.NewItems)
                    {
                        if (ParameterEntity.Count >= 1 && dgSelectedIndexParaCode != -1 && dgSelectedIndexParaCode < ParameterEntity.Count)
                        {
                            if (ParameterEntity[dgSelectedIndexParaCode].para_code != null)
                            {
                                item.para_code = ParameterEntity[dgSelectedIndexParaCode].para_code;
                                item.active = true;
                                item.add_by = AppSessionState.UserID;
                                item.comp_code = AppSessionState.comp_code;
                                item.location_Id = AppSessionState.location_Id;
                                item.editby = AppSessionState.UserID;
                                item.user_source1 = AppSessionState.UserSource1;
                                item.user_source2 = AppSessionState.UserSource2;
                                item.PropertyChanged += EntityViewModelPropertyChanged;
                            }
                            else
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Please enter parameter code...");
                                showMessageService.ShowMessage();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void CollectionChangedNotifyForMasterValue(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                //////////////////////////////////Temp Test
                if (e.NewItems != null && e.NewItems.Count != 0)
                    foreach (QMS_M009_J item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (QMS_M009_J item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (QMS_M009_J item in e.NewItems)
                    {
                        if (TestTypeParameter != null && TestTypeParameter != "")
                        {
                            item.deletion_id = deletion_id++;
                            item.test_code = MasterEntity.test_code;
                            item.test_type_code = TestTypeParameter;
                            item.due_date = (from x in MC.CalMaster where x.inst_code == (from o in TestTypeEntity where o.test_type_code == TestTypeParameter select o.master_inst).FirstOrDefault() select x.due_date).FirstOrDefault();
                            item.active = true;
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
                    foreach (QMS_M009_K item in e.NewItems)
                        item.PropertyChanged += this.MyType_PropertyChanged;

                if (e.OldItems != null && e.OldItems.Count != 0)
                    foreach (QMS_M009_K item in e.OldItems)
                        item.PropertyChanged -= this.MyType_PropertyChanged;

                /////////////////////////////////Temp Test End
                //different kind of changes that may have occurred in collection
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (QMS_M009_K item in e.NewItems)
                    {
                        if (TestTypeParameter != null && TestTypeParameter != "")
                        {
                            item.deletion_id = deletion_id++;
                            item.test_code = MasterEntity.test_code;
                            item.test_type_code = TestTypeParameter;
                            item.active = true;
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
            }
            catch (Exception ex)
            { }
        }
        void ModelUpdated_BenchValues(object sender, EventArgs e)
        {
            if (sender.ToString() == "value_from" || sender.ToString() == "value_from_unit" || sender.ToString() == "value_to" || sender.ToString() == "value_to_unit")
            {
                AssignColumnValue();
            }
        }
        private void AssignColumnValue()
        {
            try
            {
                if (dgSelectedIndexHeaderValue >= 0 && HeaderValueEntity.Count > dgSelectedIndexHeaderValue)
                {
                    List<QMS_M009_D> temp = HeaderValueEntity.ToList();
                    List<QMS_M009_C> temp1 = TestHeaderEntity.ToList();
                    temp = (from o in temp where o.srno == temp1[dgSelectedIndexHeader].srno select o).ToList();
                    string column_value = temp[dgSelectedIndexHeaderValue].value_from + " " + temp[dgSelectedIndexHeaderValue].value_from_unit + " to " + temp[dgSelectedIndexHeaderValue].value_to + " " + temp[dgSelectedIndexHeaderValue].value_to_unit;
                    if (column_value == temp[dgSelectedIndexHeaderValue].column_value)
                    {
                        temp[dgSelectedIndexHeaderValue].column_value = column_value;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        #endregion

        #region Constructor
        public QMS_M009_VM(string ts_code) : base()
        {
            this.ts_code_vm = ts_code;
            CursorControl.SetBusyState();
            MasterEntity = new QMS_M009_A();
            TestTypeEntity = new ObservableCollection<QMS_M009_B>();
            TestHeaderEntity = new ObservableCollection<QMS_M009_C>();
            HeaderValueEntity = new ObservableCollection<QMS_M009_D>();
            MasterHeaderEntity = new ObservableCollection<QMS_M009_E>();
            InstHeaderEntity = new ObservableCollection<QMS_M009_E>();
            ParameterEntity = new ObservableCollection<QMS_M009_F>();
            ParameterValueEntity = new ObservableCollection<QMS_M009_G>();
            TaskListEntity = new ObservableCollection<QMS_M009_H>();
            MasterValueEntity = new ObservableCollection<QMS_M009_J>();
            EnvConditionEntity = new ObservableCollection<QMS_M009_K>();
            QMS_M009_D.ModelEntityUpdated += new EventHandler(ModelUpdated_BenchValues);
            //TestTypeEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTestType);
            TestHeaderEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTestHeader);
            HeaderValueEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForHeaderValue);
            MasterHeaderEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForMasterHeader);
            InstHeaderEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForInstHeader);
            ParameterEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForParameter);
            ParameterValueEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForParameterValue);
            MasterValueEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForMasterValue);
            EnvConditionEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForEnvCond);
            MC = new MultipleContext_QMS_M009();
            MCTemp = new MultipleContext_QMS_M009();
            FlipGridData = new List<QMS_M009Flip>();
            LoadInitialData();
            DefaultValues();
        }
        public QMS_M009_VM(string ts_code, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            CursorControl.SetBusyState();
            MasterEntity = new QMS_M009_A();
            TestTypeEntity = new ObservableCollection<QMS_M009_B>();
            TestHeaderEntity = new ObservableCollection<QMS_M009_C>();
            HeaderValueEntity = new ObservableCollection<QMS_M009_D>();
            MasterHeaderEntity = new ObservableCollection<QMS_M009_E>();
            InstHeaderEntity = new ObservableCollection<QMS_M009_E>();
            ParameterEntity = new ObservableCollection<QMS_M009_F>();
            ParameterValueEntity = new ObservableCollection<QMS_M009_G>();
            TaskListEntity = new ObservableCollection<QMS_M009_H>();
            MasterValueEntity = new ObservableCollection<QMS_M009_J>();
            EnvConditionEntity = new ObservableCollection<QMS_M009_K>();
            QMS_M009_D.ModelEntityUpdated += new EventHandler(ModelUpdated_BenchValues);
            //TestTypeEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTestType);
            TestHeaderEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTestHeader);
            HeaderValueEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForHeaderValue);
            MasterHeaderEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForMasterHeader);
            InstHeaderEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForInstHeader);
            ParameterEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForParameter);
            ParameterValueEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForParameterValue);
            MasterValueEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForMasterValue);
            EnvConditionEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForEnvCond);
            MC = new MultipleContext_QMS_M009();
            MCTemp = new MultipleContext_QMS_M009();
            FlipGridData = new List<QMS_M009Flip>();
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
                CmdAddCalMaster = new RelayCommand<object>(items => { if (items == null) { return; } InsertCalMaster(items, false, false, true); });
                CmdAddCat = new RelayCommand<object>(items => { if (items == null) { return; } InsertCat(items); });
                CmdAddInspType = new RelayCommand<object>(items => { if (items == null) { return; } InsertInspType(items); });
                CmdAddTp = new RelayCommand<object>(items => { if (items == null) { return; } InsertTpCode(items); });
                CmdAddWi = new RelayCommand<object>(items => { if (items == null) { return; } InsertWiCode(items); });
                CmdAddUOMParaCode = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOMParaCode(cmdPara, false, false, true); });
                CmdAddUOMParaValue = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOMParaValue(cmdPara, false, false, true); });
                CmdAddUOMTestType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOMTestType(cmdPara, false, false, true); });
                CmdAddUOMHeader = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOMHeader(cmdPara, false, false, true); });
                CmdAddUOMHeaderValue = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUOMHeaderValue(cmdPara, false, false, true); });
                cmdDeleteDataGridRowParaCode = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowParaCode(cmdPara); });
                cmdDeleteDataGridRowParaValue = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowParaValue(cmdPara); });
                cmdDeleteDataGridRowTestType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowTestType(cmdPara); });
                cmdDeleteDataGridRowHeader = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowHeader(cmdPara); });
                cmdDeleteDataGridRowHeaderValue = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowHeaderValue(cmdPara); });
                cmdDeleteDataGridRowMasterHeader = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowMasterHeader(cmdPara); });
                cmdDeleteDataGridRowInstHeader = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowInstHeader(cmdPara); });
                cmdDeleteDataGridRowTaskList = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowTaskList(cmdPara); });
                cmdFilterTestHeaderDataGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } FilterTestHeaderDataGrid(cmdPara); });
                CmdAddTaskList = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertTaskList(cmdPara, false, false, true); });
                CmdAddItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertItem(cmdPara); });
                CmdAddFormulaCode = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertFormulaCode(cmdPara, false, false, true); });
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
                CmdAddMasterHeader = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertMasterHeader(cmdPara, false, false, true); });
                cmdDeleteDataGridRowMasterValue = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowMasterValue(cmdPara); });
                CmdAddEnvCond = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertEnvCond(cmdPara, false, false, true); });
                cmdDeleteDataGridRowEnvCond = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRowEnvCond(cmdPara); });
                CmdAddInspectionChar = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertInspectionCharHeader(cmdPara, false, false, true); });
                CmdAddAccuracyUpUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertAccuracyUpUnitMaster(cmdPara, false, false, true); });
                CmdAddAccuracyDownUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertAccuracyDownUnitMaster(cmdPara, false, false, true); });
                CmdAddResolutionUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertResolutionUnitMaster(cmdPara, false, false, true); });
                CmdAddUncertaintyUnit = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertUncertaintyUnitMaster(cmdPara, false, false, true); });

                #endregion
                string Request = "LoadInitialData" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_M009>(MC, Request, "TestIdentificationMaster", "Administration", "LoadInitialData", 0, "");

                FlipGridData = MC.DocumentDataFlipGrid;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                #region AutoSuggest Initialisation

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M018_P)x).CatName ?? "");
                TheFilter = (o, prefix) => (((ADM_M018_P)o).CatName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCat = new AutoSuggestTextViewModel<dynamic>(MC.Cat, TheFilter, SuggestedValue, "CatName", true);
                ASCat.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M006_P)x).tp_desc ?? "");
                TheFilter = (o, prefix) => (((QMS_M006_P)o).tp_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M006_P)o).tp_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASTP = new AutoSuggestTextViewModel<dynamic>(MC.TpCode, TheFilter, SuggestedValue, "tp_desc", true);
                ASTP.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M007_P)x).wi_desc ?? "");
                TheFilter = (o, prefix) => (((QMS_M007_P)o).wi_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M007_P)o).wi_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASWI = new AutoSuggestTextViewModel<dynamic>(MC.WiCode, TheFilter, SuggestedValue, "wi_desc", true);
                ASWI.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M013_P)x).insp_type_name ?? "");
                TheFilter = (o, prefix) => (((QMS_M013_P)o).insp_type ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M013_P)o).insp_type_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASInspType = new AutoSuggestTextViewModel<dynamic>(MC.InspType, TheFilter, SuggestedValue, "insp_type_name", true);
                ASInspType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code).ToLower().Contains(prefix.ToString().ToLower());
                ASUnitCode = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASUnitCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M003_P)x).inst_name ?? "");
                TheFilter = (o, prefix) => (((QMS_M003_P)o).inst_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M003_P)o).inst_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASCalMaster = new AutoSuggestTextViewModel<dynamic>(MC.CalMaster, TheFilter, SuggestedValue, "master_inst_name", "inst_name", true);
                ASCalMaster.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASParaValueUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASParaValueUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASTestTypeUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASTestTypeUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASHeaderUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASHeaderUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASHeaderValueUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASHeaderValueUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M024Flip)x).tl_code ?? "");
                TheFilter = (o, prefix) => (((QMS_M024Flip)o).tl_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M024Flip)o).short_text ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASTaskList = new AutoSuggestTextViewModel<dynamic>(MC.TaskList, TheFilter, SuggestedValue, "tl_code", "tl_code", true);
                ASTaskList.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault2 = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASDefault2.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault2.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault3 = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASDefault3.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault3.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M024Flip)x).tl_code ?? "");
                TheFilter = (o, prefix) => (((QMS_M024Flip)o).tl_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault4 = new AutoSuggestTextViewModel<dynamic>(MC.TaskList, TheFilter, SuggestedValue, "tl_code", "tl_code", true);
                ASDefault4.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault4.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code).ToLower().Contains(prefix.ToString().ToLower());
                ASDefault5 = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASDefault5.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault5.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault6 = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASDefault6.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault6.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault7 = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASDefault7.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault7.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASStandardValuesUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASStandardValuesUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemName ?? "");
                TheFilter = (o, prefix) => (((ADM_M022_P)o).ItemCode ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ADM_M022_P)o).ItemName ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASItemService = new AutoSuggestTextViewModel<dynamic>(MC.ItemService, TheFilter, SuggestedValue, "ItemName", true);
                ASItemService.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M011)x).formula_desc ?? "");
                TheFilter = (o, prefix) => (((QMS_M011)o).formula_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M011)o).formula_desc ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASFormulaCode = new AutoSuggestTextViewModel<dynamic>(MC.FormulaCode, TheFilter, SuggestedValue, "formula_desc", "formula_desc", true);
                ASFormulaCode.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M017)x).env_code ?? "");
                TheFilter = (o, prefix) => (((QMS_M017)o).env_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M017)o).env_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASEnvCond = new AutoSuggestTextViewModel<dynamic>(MC.EnvCond, TheFilter, SuggestedValue, "env_code", "env_code", true);
                ASEnvCond.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M017)x).env_name ?? "");
                TheFilter = (o, prefix) => (((QMS_M017)o).env_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((QMS_M017)o).env_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASDefault8 = new AutoSuggestTextViewModel<dynamic>(MC.EnvCond, TheFilter, SuggestedValue, "env_name", "env_name", true);
                ASDefault8.AutoSuggestVM.IsEmptyValueAllowed = true;
                ASDefault8.AutoSuggestVM.IsFreeTextAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASEnvCondUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "std_value_unit", "unit_code", true);
                ASEnvCondUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASResolutionunit = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "resolution_unit", "unit_code", true);
                ASResolutionunit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASResolutionUnitMaster = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "resolution_unit", "unit_code", true);
                ASResolutionUnitMaster.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASAccuracyUpUnitMaster = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "accuracy_up_unit", "unit_code", true);
                ASAccuracyUpUnitMaster.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASAccuracyDownUnitMaster = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "accuracy_down_unit", "unit_code", true);
                ASAccuracyDownUnitMaster.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASUncertaintyUnitMaster = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "uncertainty_unit", "unit_code", true);
                ASUncertaintyUnitMaster.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M030_I_P)x).insp_char ?? "");
                TheFilter = (o, prefix) => (((QMS_M030_I_P)o).insp_char ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASInspectionChar = new AutoSuggestTextViewModel<dynamic>(MC.InspectionChar, TheFilter, SuggestedValue, "insp_char", "insp_char", true);
                ASInspectionChar.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASValueFromUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "value_from_unit", "unit_code", true);
                ASValueFromUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASValueToUnit = new AutoSuggestTextViewModel<dynamic>(MC.UnitCode, TheFilter, SuggestedValue, "value_to_unit", "unit_code", true);
                ASValueToUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

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
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.active = true;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            QMS_M009Flip ParameterEntityObject = new QMS_M009Flip();

            try
            {
                CursorControl.SetBusyState();
                if (((IEnumerable)ParameterObject).Cast<QMS_M009Flip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<QMS_M009Flip>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + ParameterEntityObject.test_code;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_M009>(MCTemp, Request, "TestIdentificationMaster", "Administration", "LoadDocumentByDocumentNumber", 0, "");

                    if (MCTemp.MasterEntity.Count > 0)
                    {
                        MasterEntity = MCTemp.MasterEntity[0];
                    }
                    TestTypeEntity = MCTemp.TestTypeEntity;
                    MC.TestTypeEntity = MCTemp.TestTypeEntity;
                    if (TestTypeEntity.Count > 0)
                    {
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_B)x).test_type_name ?? "");
                        TheFilter = (o, prefix) => (((QMS_M009_B)o).test_type_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                        ASTestType = new AutoSuggestTextViewModel<dynamic>(TestTypeEntity, TheFilter, SuggestedValue, "test_type_name", "test_type_name", false);
                        ASTestType.AutoSuggestVM.IsEmptyValueAllowed = true;
                    }
                    TestHeaderEntity = MCTemp.TestHeaderEntity;
                    HeaderValueEntity = MCTemp.HeaderValueEntity;
                    MasterHeaderEntity = MCTemp.MasterHeaderEntity;
                    InstHeaderEntity = MCTemp.InstHeaderEntity;
                    ParameterEntity = MCTemp.ParameterEntity;
                    ParameterValueEntity = MCTemp.ParameterValueEntity;
                    TaskListEntity = MCTemp.TaskListEntity;
                    MasterValueEntity = MCTemp.MasterValueEntity;
                    EnvConditionEntity = MCTemp.EnvConditionEntity;

                    SelectedTabControlIndex = 0;
                    isNewRecord = false;

                    if (MCTemp.Attachment != null)
                    {
                        AttachmentCollection = MCTemp.Attachment;
                    }
                    else
                    {
                        MCTemp.Attachment = new List<COM_T003>();
                    }
                }
                MasterEntity.ts_code = ts_code_vm;
                var msg = new NotificationMessage("QMS_M009_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
                SetPopupSuggestionDataAfterLoad();
                SetPopupForStandards();
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
        private void InsertCalMaster(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M003_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.CalMaster.Where(x => x.inst_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M003_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M003_P>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    if (dgSelectedIndexTestType >= 0 && TestTypeEntity.Count > dgSelectedIndexTestType)
                    {
                        if (TestTypeEntity[dgSelectedIndexTestType].test_type_code != null)
                        {
                            TestTypeEntity[dgSelectedIndexTestType].master_inst = POPUPEntityObject.inst_code;
                            TestTypeEntity[dgSelectedIndexTestType].master_inst_name = POPUPEntityObject.inst_name;
                        }
                        else if (TestTypeEntity[dgSelectedIndexTestType].master_inst != POPUPEntityObject.inst_code && TestTypeEntity[dgSelectedIndexTestType].test_type_code != null)
                        {
                            TestTypeEntity[dgSelectedIndexTestType].master_inst = POPUPEntityObject.inst_code;
                            TestTypeEntity[dgSelectedIndexTestType].master_inst_name = POPUPEntityObject.inst_name;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void InsertFormulaCode(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M011 POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.FormulaCode.Where(x => x.formula_desc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M011>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M011>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    if (dgSelectedIndexTestType >= 0 && TestTypeEntity.Count > dgSelectedIndexTestType)
                    {
                        if (TestTypeEntity[dgSelectedIndexTestType].test_type_code != null)
                        {
                            TestTypeEntity[dgSelectedIndexTestType].formula_code = POPUPEntityObject.formula_code;
                            TestTypeEntity[dgSelectedIndexTestType].formula_desc = POPUPEntityObject.formula_desc;
                        }
                        else if (TestTypeEntity[dgSelectedIndexTestType].formula_code != POPUPEntityObject.formula_code && TestTypeEntity[dgSelectedIndexTestType].test_type_code != null)
                        {
                            TestTypeEntity[dgSelectedIndexTestType].formula_code = POPUPEntityObject.formula_code;
                            TestTypeEntity[dgSelectedIndexTestType].formula_desc = POPUPEntityObject.formula_desc;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void InsertCat(object InputValue)
        {
            string Request = "";
            ADM_M018_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Cat.Where(x => x.CatName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M018_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M018_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.CatCode = POPUPEntityObject.CatCode;
                MasterEntity.CatName = POPUPEntityObject.CatName;
            }
        }
        private void InsertInspType(object InputValue)
        {
            string Request = "";
            QMS_M013_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.InspType.Where(x => x.insp_type_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M013_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M013_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.insp_type = POPUPEntityObject.insp_type;
                MasterEntity.insp_type_name = POPUPEntityObject.insp_type_name;
            }
        }
        private void InsertTpCode(object InputValue)
        {
            string Request = "";
            QMS_M006_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.TpCode.Where(x => x.tp_desc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M006_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M006_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.tp_code = POPUPEntityObject.tp_code;
                MasterEntity.tp_desc = POPUPEntityObject.tp_desc;
            }
        }
        private void InsertWiCode(object InputValue)
        {
            string Request = "";
            QMS_M007_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.WiCode.Where(x => x.wi_desc.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M007_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M007_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.wi_code = POPUPEntityObject.wi_code;
                MasterEntity.wi_desc = POPUPEntityObject.wi_desc;
            }
        }
        private void InsertUOMParaCode(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    if (dgSelectedIndexParaCode >= 0 && ParameterEntity.Count > dgSelectedIndexParaCode) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ParameterEntity[dgSelectedIndexParaCode].para_code != null) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ParameterEntity[dgSelectedIndexParaCode].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (ParameterEntity[dgSelectedIndexParaCode].unit_code != POPUPEntityObject.unit_code && ParameterEntity[dgSelectedIndexParaCode].para_code != null)
                        {
                            ParameterEntity[dgSelectedIndexParaCode].unit_code = POPUPEntityObject.unit_code;
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertUOMParaValue(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    if (dgSelectedIndexParaValue >= 0 && ParameterValueEntity.Count > dgSelectedIndexParaValue)
                    {
                        if (ParameterValueEntity[dgSelectedIndexParaValue].value_code != null)
                        {
                            ParameterValueEntity[dgSelectedIndexParaValue].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (ParameterValueEntity[dgSelectedIndexParaValue].unit_code != POPUPEntityObject.unit_code && ParameterValueEntity[dgSelectedIndexParaValue].value_code != null)
                        {
                            ParameterValueEntity[dgSelectedIndexParaValue].unit_code = POPUPEntityObject.unit_code;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void InsertUOMTestType(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    if (dgSelectedIndexTestType >= 0 && TestTypeEntity.Count > dgSelectedIndexTestType) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (TestTypeEntity[dgSelectedIndexTestType].test_type_code != null) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
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
            {

            }
        }
        private void InsertUOMHeader(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    if (dgSelectedIndexHeader >= 0 && TestHeaderEntity.Count > dgSelectedIndexHeader)
                    {
                        if (TestHeaderEntity[dgSelectedIndexHeader].hdr_name != null)
                        {
                            TestHeaderEntity[dgSelectedIndexHeader].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (TestHeaderEntity[dgSelectedIndexHeader].unit_code != POPUPEntityObject.unit_code && TestHeaderEntity[dgSelectedIndexHeader].hdr_name != null)
                        {
                            TestHeaderEntity[dgSelectedIndexHeader].unit_code = POPUPEntityObject.unit_code;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void InsertUOMHeaderValue(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    if (dgSelectedIndexHeaderValue >= 0 && HeaderValueEntity.Count > dgSelectedIndexHeaderValue)
                    {
                        if (HeaderValueEntity[dgSelectedIndexHeaderValue].column_value != null)
                        {
                            HeaderValueEntity[dgSelectedIndexHeaderValue].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (HeaderValueEntity[dgSelectedIndexHeaderValue].unit_code != POPUPEntityObject.unit_code && HeaderValueEntity[dgSelectedIndexHeaderValue].column_value != null)
                        {
                            HeaderValueEntity[dgSelectedIndexHeaderValue].unit_code = POPUPEntityObject.unit_code;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void DeleteDataGridRowParaCode(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ParameterEntity.Count > i)
                {
                    ParameterEntity.RemoveAt(i);
                }
                if (ParameterEntity.Count == 0)
                {
                    ParameterEntity = new ObservableCollection<QMS_M009_F>();
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
        private void DeleteDataGridRowParaValue(object InputValue)
        {
            try
            {
                QMS_M009_G POPUPEntityObject = null;
                if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_G>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_G>().ToList()[0];
                }
                if (ParameterValueEntity.Count > 0)
                {
                    List<QMS_M009_G> temp = ParameterValueEntity.ToList();
                    foreach (var a in temp)
                    {
                        if (a.id == 0 && a.value_code == POPUPEntityObject.value_code)
                        {
                            ParameterValueEntity.Remove(a);
                        }
                    }
                }
                //int i = (int)InputValue;
                //if (ParameterValueEntity.Count > i && ParameterValueEntity[dgSelectedIndexParaValue].id == 0)
                //{
                //    ParameterValueEntity.RemoveAt(i);
                //}
                if (ParameterValueEntity.Count == 0)
                {
                    ParameterValueEntity = new ObservableCollection<QMS_M009_G>();
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
                int i = (int)InputValue;
                if (TestTypeEntity.Count > i && TestTypeEntity[dgSelectedIndexTestType].id == 0)
                {
                    TestTypeEntity.RemoveAt(i);
                }
                if (TestTypeEntity.Count == 0)
                {
                    TestTypeEntity = new ObservableCollection<QMS_M009_B>();
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
        private void DeleteDataGridRowHeader(object InputValue)
        {
            try
            {
                QMS_M009_C POPUPEntityObject = null;
                if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_C>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_C>().ToList()[0];
                }
                if (TestHeaderEntity.Count > 0)
                {
                    List<QMS_M009_C> temp = TestHeaderEntity.ToList();
                    foreach (var a in temp)
                    {
                        if (a.hdr_id == 0 && a.srno == POPUPEntityObject.srno)
                        {
                            TestHeaderEntity.Remove(a);
                        }
                    }
                }
                //int i = (int)InputValue;
                //if (TestHeaderEntity.Count > i && TestHeaderEntity[dgSelectedIndexHeader].hdr_id == 0)
                //{
                //    TestHeaderEntity.RemoveAt(i);
                //}
                if (TestHeaderEntity.Count == 0)
                {
                    TestHeaderEntity = new ObservableCollection<QMS_M009_C>();
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
        private void DeleteDataGridRowHeaderValue(object InputValue)
        {
            try
            {
                QMS_M009_D POPUPEntityObject = null;
                if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_D>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_D>().ToList()[0];
                }
                if (HeaderValueEntity.Count > 0)
                {
                    List<QMS_M009_D> temp = HeaderValueEntity.ToList();
                    foreach (var a in temp)
                    {
                        if (a.value_id == 0 && a.deletion_id == POPUPEntityObject.deletion_id)
                        {
                            HeaderValueEntity.Remove(a);
                        }
                    }
                }
                //int i = (int)InputValue;
                //if (HeaderValueEntity.Count > i && HeaderValueEntity[dgSelectedIndexHeaderValue].value_id == 0)
                //{
                //    HeaderValueEntity.RemoveAt(i);
                //}
                if (HeaderValueEntity.Count == 0)
                {
                    HeaderValueEntity = new ObservableCollection<QMS_M009_D>();
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
        private void DeleteDataGridRowMasterHeader(object InputValue)
        {
            try
            {
                QMS_M009_E POPUPEntityObject = null;
                if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_E>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_E>().ToList()[0];
                }
                if (MasterHeaderEntity.Count > 0)
                {
                    List<QMS_M009_E> temp = MasterHeaderEntity.ToList();
                    foreach (var a in temp)
                    {
                        if (a.header_id == 0 && a.deletion_id == POPUPEntityObject.deletion_id)
                        {
                            MasterHeaderEntity.Remove(a);
                        }
                    }
                }
                //int i = (int)InputValue;
                //if (MasterHeaderEntity.Count > i && MasterHeaderEntity[dgSelectedIndexMasterHeader].header_id == 0)
                //{
                //    MasterHeaderEntity.RemoveAt(i);
                //}
                if (MasterHeaderEntity.Count == 0)
                {
                    MasterHeaderEntity = new ObservableCollection<QMS_M009_E>();
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
        private void DeleteDataGridRowInstHeader(object InputValue)
        {
            try
            {
                QMS_M009_E POPUPEntityObject = null;
                if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_E>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_E>().ToList()[0];
                }
                if (InstHeaderEntity.Count > 0)
                {
                    List<QMS_M009_E> temp = InstHeaderEntity.ToList();
                    foreach (var a in temp)
                    {
                        if (a.header_id == 0 && a.deletion_id == POPUPEntityObject.deletion_id)
                        {
                            InstHeaderEntity.Remove(a);
                        }
                    }
                }
                //int i = (int)InputValue;
                //if (InstHeaderEntity.Count > i && InstHeaderEntity[dgSelectedIndexInstHeader].header_id == 0)
                //{
                //    InstHeaderEntity.RemoveAt(i);
                //}
                if (InstHeaderEntity.Count == 0)
                {
                    InstHeaderEntity = new ObservableCollection<QMS_M009_E>();
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
                    TaskListEntity = new ObservableCollection<QMS_M009_H>();
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
        private void DeleteDataGridRowMasterValue(object InputValue)
        {
            try
            {
                QMS_M009_J POPUPEntityObject = null;
                if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_J>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_J>().ToList()[0];
                }
                if (InstHeaderEntity.Count > 0)
                {
                    List<QMS_M009_J> temp = MasterValueEntity.ToList();
                    foreach (var a in temp)
                    {
                        if (a.header_id == 0 && a.deletion_id == POPUPEntityObject.deletion_id)
                        {
                            MasterValueEntity.Remove(a);
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
        private void DeleteDataGridRowEnvCond(object InputValue)
        {
            try
            {
                QMS_M009_K POPUPEntityObject = null;
                if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_K>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_K>().ToList()[0];
                }
                if (InstHeaderEntity.Count > 0)
                {
                    List<QMS_M009_K> temp = EnvConditionEntity.ToList();
                    foreach (var a in temp)
                    {
                        if (a.id == 0 && a.deletion_id == POPUPEntityObject.deletion_id)
                        {
                            EnvConditionEntity.Remove(a);
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
                        { POPUPEntityObject = MC.TaskList.Where(x => x.tl_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                        }
                        else if (TaskListEntity[dgSelectedIndexTaskList].tl_code != POPUPEntityObject.tl_code && MasterEntity.test_code != null)
                        {
                            TaskListEntity[dgSelectedIndexTaskList].tl_code = POPUPEntityObject.tl_code;
                            TaskListEntity[dgSelectedIndexTaskList].short_text = POPUPEntityObject.short_text;
                            TaskListEntity[dgSelectedIndexTaskList].active = true;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void InsertItem(object InputValue)
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
                        { POPUPEntityObject = MC.ItemService.Where(x => x.ItemName.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M022_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    if (MasterEntity.ItemCode == POPUPEntityObject.ItemCode)
                    {
                        MasterEntity.ItemCode = POPUPEntityObject.ItemCode;
                    }
                    if (MasterEntity.ItemName == POPUPEntityObject.ItemName)
                    {
                        MasterEntity.ItemName = POPUPEntityObject.ItemName;
                    }
                    if (MasterEntity.test_code == POPUPEntityObject.ItemCode)
                    {
                        MasterEntity.test_code = POPUPEntityObject.ItemCode;
                    }
                    if (MasterEntity.test_name == POPUPEntityObject.ItemName)
                    {
                        MasterEntity.test_name = POPUPEntityObject.ItemName;
                    }
                    if (MasterEntity.CatCode == POPUPEntityObject.CatCode)
                    {
                        MasterEntity.CatCode = POPUPEntityObject.CatCode;
                    }
                    if (MasterEntity.CatName == POPUPEntityObject.CatName)
                    {
                        MasterEntity.CatName = POPUPEntityObject.CatName;
                    }
                    var msg = new NotificationMessage("QMS_M009_VM");
                    Messenger.Default.Send<NotificationMessage>(msg);
                    SetPopupSuggestionDataAfterLoad();
                }
            }
            catch (Exception ex) { }
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
                        { POPUPEntityObject = HeaderValueEntity.Where(x => x.column_value.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
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
                    if (dgSelectedIndexMasterValue >= 0 && MasterValueEntity.Count > dgSelectedIndexMasterValue) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_M009_J> temp = MasterValueEntity.ToList();
                        temp = (from o in temp where o.test_type_code == TestTypeParameter select o).ToList();
                        temp[dgSelectedIndexMasterValue].value_id1 = POPUPEntityObject.value_id;
                        temp[dgSelectedIndexMasterValue].column_value1 = POPUPEntityObject.column_value;
                    }
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
                        { POPUPEntityObject = HeaderValueEntity.Where(x => x.column_value.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
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
                    if (dgSelectedIndexMasterValue >= 0 && MasterValueEntity.Count > dgSelectedIndexMasterValue) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_M009_J> temp = MasterValueEntity.ToList();
                        temp = (from o in temp where o.test_type_code == TestTypeParameter select o).ToList();
                        temp[dgSelectedIndexMasterValue].value_id2 = POPUPEntityObject.value_id;
                        temp[dgSelectedIndexMasterValue].column_value2 = POPUPEntityObject.column_value;
                    }
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
                        { POPUPEntityObject = HeaderValueEntity.Where(x => x.column_value.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
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
                    if (dgSelectedIndexMasterValue >= 0 && MasterValueEntity.Count > dgSelectedIndexMasterValue) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_M009_J> temp = MasterValueEntity.ToList();
                        temp = (from o in temp where o.test_type_code == TestTypeParameter select o).ToList();
                        temp[dgSelectedIndexMasterValue].value_id3 = POPUPEntityObject.value_id;
                        temp[dgSelectedIndexMasterValue].column_value3 = POPUPEntityObject.column_value;
                    }
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
                        { POPUPEntityObject = HeaderValueEntity.Where(x => x.column_value.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
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
                    if (dgSelectedIndexMasterValue >= 0 && MasterValueEntity.Count > dgSelectedIndexMasterValue) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_M009_J> temp = MasterValueEntity.ToList();
                        temp = (from o in temp where o.test_type_code == TestTypeParameter select o).ToList();
                        temp[dgSelectedIndexMasterValue].value_id4 = POPUPEntityObject.value_id;
                        temp[dgSelectedIndexMasterValue].column_value4 = POPUPEntityObject.column_value;
                    }
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
                        { POPUPEntityObject = HeaderValueEntity.Where(x => x.column_value.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
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
                    if (dgSelectedIndexMasterValue >= 0 && MasterValueEntity.Count > dgSelectedIndexMasterValue) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_M009_J> temp = MasterValueEntity.ToList();
                        temp = (from o in temp where o.test_type_code == TestTypeParameter select o).ToList();
                        temp[dgSelectedIndexMasterValue].value_id5 = POPUPEntityObject.value_id;
                        temp[dgSelectedIndexMasterValue].column_value5 = POPUPEntityObject.column_value;
                    }
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
                        { POPUPEntityObject = HeaderValueEntity.Where(x => x.column_value.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
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
                    if (dgSelectedIndexMasterValue >= 0 && MasterValueEntity.Count > dgSelectedIndexMasterValue) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_M009_J> temp = MasterValueEntity.ToList();
                        temp = (from o in temp where o.test_type_code == TestTypeParameter select o).ToList();
                        temp[dgSelectedIndexMasterValue].value_id6 = POPUPEntityObject.value_id;
                        temp[dgSelectedIndexMasterValue].column_value6 = POPUPEntityObject.column_value;
                    }
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
                        { POPUPEntityObject = HeaderValueEntity.Where(x => x.column_value.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
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
                    if (dgSelectedIndexMasterValue >= 0 && MasterValueEntity.Count > dgSelectedIndexMasterValue) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_M009_J> temp = MasterValueEntity.ToList();
                        temp = (from o in temp where o.test_type_code == TestTypeParameter select o).ToList();
                        temp[dgSelectedIndexMasterValue].value_id7 = POPUPEntityObject.value_id;
                        temp[dgSelectedIndexMasterValue].column_value7 = POPUPEntityObject.column_value;
                    }
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
                        { POPUPEntityObject = HeaderValueEntity.Where(x => x.column_value.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
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
                    if (dgSelectedIndexMasterValue >= 0 && MasterValueEntity.Count > dgSelectedIndexMasterValue) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_M009_J> temp = MasterValueEntity.ToList();
                        temp = (from o in temp where o.test_type_code == TestTypeParameter select o).ToList();
                        temp[dgSelectedIndexMasterValue].value_id8 = POPUPEntityObject.value_id;
                        temp[dgSelectedIndexMasterValue].column_value8 = POPUPEntityObject.column_value;
                    }
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
                        { POPUPEntityObject = HeaderValueEntity.Where(x => x.column_value.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
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
                    if (dgSelectedIndexMasterValue >= 0 && MasterValueEntity.Count > dgSelectedIndexMasterValue) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_M009_J> temp = MasterValueEntity.ToList();
                        temp = (from o in temp where o.test_type_code == TestTypeParameter select o).ToList();
                        temp[dgSelectedIndexMasterValue].value_id9 = POPUPEntityObject.value_id;
                        temp[dgSelectedIndexMasterValue].column_value9 = POPUPEntityObject.column_value;
                    }
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
                        { POPUPEntityObject = HeaderValueEntity.Where(x => x.column_value.ToString().Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
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
                    if (dgSelectedIndexMasterValue >= 0 && MasterValueEntity.Count > dgSelectedIndexMasterValue) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_M009_J> temp = MasterValueEntity.ToList();
                        temp = (from o in temp where o.test_type_code == TestTypeParameter select o).ToList();
                        temp[dgSelectedIndexMasterValue].value_id10 = POPUPEntityObject.value_id;
                        temp[dgSelectedIndexMasterValue].column_value10 = POPUPEntityObject.column_value;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertMasterHeader(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M009_E POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MasterHeaderEntity.Where(x => x.rdg_header.Equals(Request, StringComparison.OrdinalIgnoreCase) == true && x.test_type_code == TestTypeParameter).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_E>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M009_E>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    if (dgSelectedIndexMasterValue >= 0 && MasterValueEntity.Count > dgSelectedIndexMasterValue) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_M009_J> temp = MasterValueEntity.ToList();
                        temp = (from o in temp where o.test_type_code == TestTypeParameter select o).ToList();
                        temp[dgSelectedIndexMasterValue].header_id = POPUPEntityObject.header_id;
                        temp[dgSelectedIndexMasterValue].header_name = POPUPEntityObject.rdg_header;
                    }
                }
            }
            catch (Exception ex)
            { }
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
                        { POPUPEntityObject = MC.EnvCond.Where(x => x.env_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    if (dgSelectedIndexEnvCond >= 0 && EnvConditionEntity.Count > dgSelectedIndexEnvCond) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_M009_K> temp = EnvConditionEntity.ToList();
                        temp = (from o in temp where o.test_type_code == TestTypeParameter select o).ToList();
                        temp[dgSelectedIndexEnvCond].env_name = POPUPEntityObject.env_name;
                        temp[dgSelectedIndexEnvCond].env_code = POPUPEntityObject.env_code;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void FilterParaCodeDataGrid()
        {
            try
            {
                //if (ParameterEntity != null && ParameterEntity.Count <= dgSelectedIndexParaCode)
                //{
                //    IsEnableParaValueGrid = true;
                //}
                if (ParameterValueEntity != null && ParameterValueEntity.Count > 0 && dgSelectedIndexParaCode >= 0)
                {
                    ParaValueDataGrid = CollectionViewSource.GetDefaultView(ParameterValueEntity);
                    ParaValueDataGrid.Filter = adv => (((QMS_M009_G)adv).para_code ?? "").Equals(ParameterEntity[dgSelectedIndexParaCode].para_code);
                    ParaValueDataGrid.Refresh();
                }
            }
            catch (Exception ex)
            { }
        }
        private void FilterTestTypeDataGrid()
        {
            try
            {
                if (TestHeaderEntity != null && TestHeaderEntity.Count > 0 && dgSelectedIndexTestType >= 0)
                {
                    TestTypeDataGrid = CollectionViewSource.GetDefaultView(TestHeaderEntity);
                    TestTypeDataGrid.Filter = adv => (((QMS_M009_C)adv).test_type_code ?? "").Equals(TestTypeEntity[dgSelectedIndexTestType].test_type_code);
                    TestTypeDataGrid.Refresh();
                }
                if (HeaderValueEntity != null && HeaderValueEntity.Count > 0 && dgSelectedIndexHeader >= 0)
                {
                    HeaderValueDataGrid = CollectionViewSource.GetDefaultView(HeaderValueEntity);
                    HeaderValueDataGrid.Filter = adv => ((QMS_M009_D)adv).hdr_id.Equals(TestHeaderEntity[dgSelectedIndexHeader].hdr_id);
                    HeaderValueDataGrid.Refresh();
                }
                if (MasterHeaderEntity != null && MasterHeaderEntity.Count > 0 && dgSelectedIndexTestType >= 0)
                {
                    MasterHeaderDataGrid = CollectionViewSource.GetDefaultView(MasterHeaderEntity);
                    MasterHeaderDataGrid.Filter = adv => (((QMS_M009_E)adv).test_type_code ?? "").Equals(TestTypeEntity[dgSelectedIndexTestType].test_type_code);
                    MasterHeaderDataGrid.Refresh();
                }
                if (InstHeaderEntity != null && InstHeaderEntity.Count > 0 && dgSelectedIndexTestType >= 0)
                {
                    InstHeaderDataGrid = CollectionViewSource.GetDefaultView(InstHeaderEntity);
                    InstHeaderDataGrid.Filter = adv => (((QMS_M009_E)adv).test_type_code ?? "").Equals(TestTypeEntity[dgSelectedIndexTestType].test_type_code);
                    InstHeaderDataGrid.Refresh();
                }
            }
            catch (Exception ex)
            { }
        }
        private void FilterTestHeaderDataGrid(object InputValue)
        {
            try
            {
                if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M009_C>().Count() > 0)
                {
                    QMS_M009_C tempTestHeader = new QMS_M009_C();
                    tempTestHeader = ((IEnumerable)InputValue).Cast<QMS_M009_C>().ToList()[0];
                    dgSelectedIndexHeader = TestHeaderEntity.IndexOf(tempTestHeader);

                    if (HeaderValueEntity != null && HeaderValueEntity.Count > 0 && dgSelectedIndexHeader >= 0)
                    {
                        if (TestHeaderEntity[dgSelectedIndexHeader].srno != null)
                        {
                            HeaderValueDataGrid = CollectionViewSource.GetDefaultView(HeaderValueEntity);
                            HeaderValueDataGrid.Filter = adv => (((QMS_M009_D)adv).srno.ToString() ?? "").Equals(TestHeaderEntity[dgSelectedIndexHeader].srno.ToString());
                            HeaderValueDataGrid.Refresh();
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private bool Validation()
        {
            if (MasterEntity.ItemCode == null || MasterEntity.ItemCode == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("please select Service...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.test_code == null || MasterEntity.test_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("please Enter Test Id...");
                showMessageService.ShowMessage();
                return false;
            }
            else if (MasterEntity.test_name == null || MasterEntity.test_name == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("please Enter Test Name...");
                showMessageService.ShowMessage();
                return false;
            }
            if (TaskListEntity.Count > 0)
            {
                //foreach(var o in TaskListEntity)
                //{

                //}
            }
            return true;
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.XmlDataDocument_QMS_M009Flip != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<QMS_M009Flip>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M009Flip, MC.DocumentDataFlipGrid);
                    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                    DataGridCollection.Refresh();
                }
                if (MasterEntity.XmlDataDocument_QMS_M009_B != null)
                {
                    TestTypeEntity.Clear();
                    MC.TestTypeEntity = (ObservableCollection<QMS_M009_B>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M009_B, MC.TestTypeEntity);
                    TestTypeEntity = MC.TestTypeEntity;
                }
                else
                {
                    MC.TestTypeEntity = new ObservableCollection<QMS_M009_B>();
                }
                if (MasterEntity.XmlDataDocument_QMS_M009_C != null)
                {
                    TestHeaderEntity.Clear();
                    MC.TestHeaderEntity = (ObservableCollection<QMS_M009_C>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M009_C, MC.TestHeaderEntity);
                    TestHeaderEntity = MC.TestHeaderEntity;
                }
                else
                {
                    MC.TestHeaderEntity = new ObservableCollection<QMS_M009_C>();
                }
                if (MasterEntity.XmlDataDocument_QMS_M009_D != null)
                {
                    HeaderValueEntity.Clear();
                    MC.HeaderValueEntity = (ObservableCollection<QMS_M009_D>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M009_D, MC.HeaderValueEntity);
                    HeaderValueEntity = MC.HeaderValueEntity;
                }
                else
                {
                    MC.HeaderValueEntity = new ObservableCollection<QMS_M009_D>();
                }
                if (MasterEntity.XmlDataDocument_QMS_M009_E_M != null)
                {
                    MasterHeaderEntity.Clear();
                    MC.MasterHeaderEntity = (ObservableCollection<QMS_M009_E>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M009_E_M, MC.MasterHeaderEntity);
                    MasterHeaderEntity = MC.MasterHeaderEntity;
                }
                else
                {
                    MC.MasterHeaderEntity = new ObservableCollection<QMS_M009_E>();
                }
                if (MasterEntity.XmlDataDocument_QMS_M009_E_I != null)
                {
                    InstHeaderEntity.Clear();
                    MC.InstHeaderEntity = (ObservableCollection<QMS_M009_E>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M009_E_I, MC.InstHeaderEntity);
                    InstHeaderEntity = MC.InstHeaderEntity;
                }
                else
                {
                    MC.InstHeaderEntity = new ObservableCollection<QMS_M009_E>();
                }
                if (MasterEntity.XmlDataDocument_QMS_M009_F != null)
                {
                    ParameterEntity.Clear();
                    MC.ParameterEntity = (ObservableCollection<QMS_M009_F>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M009_F, MC.ParameterEntity);
                    ParameterEntity = MC.ParameterEntity;
                }
                else
                {
                    MC.ParameterEntity = new ObservableCollection<QMS_M009_F>();
                }
                if (MasterEntity.XmlDataDocument_QMS_M009_G != null)
                {
                    ParameterValueEntity.Clear();
                    MC.ParameterValueEntity = (ObservableCollection<QMS_M009_G>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M009_G, MC.ParameterValueEntity);
                    ParameterValueEntity = MC.ParameterValueEntity;
                }
                else
                {
                    MC.ParameterValueEntity = new ObservableCollection<QMS_M009_G>();
                }
                if (MasterEntity.XmlDataDocument_QMS_M009_H != null)
                {
                    TaskListEntity.Clear();
                    MC.TaskListEntity = (ObservableCollection<QMS_M009_H>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M009_H, MC.TaskListEntity);
                    TaskListEntity = MC.TaskListEntity;
                }
                else
                {
                    MC.TaskListEntity = new ObservableCollection<QMS_M009_H>();
                }
                if (MasterEntity.XmlDataDocument_QMS_M009_J != null)
                {
                    MasterValueEntity.Clear();
                    MC.MasterValueEntity = (ObservableCollection<QMS_M009_J>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M009_J, MC.MasterValueEntity);
                    MasterValueEntity = MC.MasterValueEntity;
                }
                else
                {
                    MC.MasterValueEntity = new ObservableCollection<QMS_M009_J>();
                }
                if (MasterEntity.XmlDataDocument_QMS_M009_K != null)
                {
                    EnvConditionEntity.Clear();
                    MC.EnvConditionEntity = (ObservableCollection<QMS_M009_K>)obj.XMLToObject(MasterEntity.XmlDataDocument_QMS_M009_K, MC.EnvConditionEntity);
                    EnvConditionEntity = MC.EnvConditionEntity;
                }
                else
                {
                    MC.EnvConditionEntity = new ObservableCollection<QMS_M009_K>();
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
            ASCat.AutoSuggestVM.Suggestion = //ASCat.DomainObjectCollection.Select(x => x.CatCode == MasterEntity.CatCode);
                                             MC.Cat.Find(x => x.CatCode == MasterEntity.CatCode);
            ASInspType.AutoSuggestVM.Suggestion = MC.InspType.Find(x => x.insp_type == MasterEntity.insp_type);
            ASTP.AutoSuggestVM.Suggestion = MC.TpCode.Find(x => x.tp_code == MasterEntity.tp_code);
            ASWI.AutoSuggestVM.Suggestion = MC.WiCode.Find(x => x.wi_code == MasterEntity.wi_code);
            ASItemService.AutoSuggestVM.Suggestion = MC.ItemService.Find(x => x.ItemCode == MasterEntity.ItemCode);
        }
        private void SetPopupForStandards()
        {
            #region AutoSuggestInitialization

            SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_M009_B)x).test_type_name ?? "");
            TheFilter = (o, prefix) => (((QMS_M009_B)o).test_type_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
            ASTestType = new AutoSuggestTextViewModel<dynamic>(TestTypeEntity, TheFilter, SuggestedValue, "test_type_name", "test_type_name", true);
            ASTestType.AutoSuggestVM.IsEmptyValueAllowed = true;

            #endregion
        }
        private void InsertInspectionCharHeader(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M030_I_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.InspectionChar.Where(x => x.insp_char.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_M030_I_P>().ToList().Count > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M030_I_P>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null)
                {
                    if (dgSelectedIndexHeader >= 0 && TestHeaderEntity.Count > dgSelectedIndexHeader)
                    {
                        TestHeaderEntity[dgSelectedIndexHeader].insp_char = POPUPEntityObject.insp_char;
                        TestHeaderEntity[dgSelectedIndexHeader].hdr_name = POPUPEntityObject.char_desc;
                        TestHeaderEntity[dgSelectedIndexHeader].hdr_desc = POPUPEntityObject.char_desc;
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }
        private void InsertAccuracyUpUnitMaster(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    if (dgSelectedIndexMasterValue >= 0 && MasterValueEntity.Count > dgSelectedIndexMasterValue) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_M009_J> temp = MasterValueEntity.ToList();
                        temp = (from o in temp where o.test_type_code == TestTypeParameter select o).ToList();
                        temp[dgSelectedIndexMasterValue].accuracy_up_unit = POPUPEntityObject.unit_code;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertAccuracyDownUnitMaster(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    if (dgSelectedIndexMasterValue >= 0 && MasterValueEntity.Count > dgSelectedIndexMasterValue) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_M009_J> temp = MasterValueEntity.ToList();
                        temp = (from o in temp where o.test_type_code == TestTypeParameter select o).ToList();
                        temp[dgSelectedIndexMasterValue].accuracy_down_unit = POPUPEntityObject.unit_code;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertResolutionUnitMaster(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    if (dgSelectedIndexMasterValue >= 0 && MasterValueEntity.Count > dgSelectedIndexMasterValue) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_M009_J> temp = MasterValueEntity.ToList();
                        temp = (from o in temp where o.test_type_code == TestTypeParameter select o).ToList();
                        temp[dgSelectedIndexMasterValue].resolution_unit = POPUPEntityObject.unit_code;
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void InsertUncertaintyUnitMaster(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    if (dgSelectedIndexMasterValue >= 0 && MasterValueEntity.Count > dgSelectedIndexMasterValue) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        List<QMS_M009_J> temp = MasterValueEntity.ToList();
                        temp = (from o in temp where o.test_type_code == TestTypeParameter select o).ToList();
                        temp[dgSelectedIndexMasterValue].uncertainty_unit = POPUPEntityObject.unit_code;
                    }
                }
            }
            catch (Exception ex)
            { }
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
            var data = obj as QMS_M009Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.test_code != null && data.test_code.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.test_name != null && data.test_name.ToString().ToLower().Contains(_filterString.ToLower()) ||
                            data.insp_type_name != null && data.insp_type_name.ToLower().Contains(_filterString.ToLower()) ||
                            data.test_desc != null && data.test_desc.ToString().ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }

        #endregion

        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<QMS_M009_A> result)
        {
            MasterEntity = new QMS_M009_A();
            TestTypeEntity = new ObservableCollection<QMS_M009_B>();
            TestHeaderEntity = new ObservableCollection<QMS_M009_C>();
            HeaderValueEntity = new ObservableCollection<QMS_M009_D>();
            MasterHeaderEntity = new ObservableCollection<QMS_M009_E>();
            InstHeaderEntity = new ObservableCollection<QMS_M009_E>();
            ParameterEntity = new ObservableCollection<QMS_M009_F>();
            ParameterValueEntity = new ObservableCollection<QMS_M009_G>();
            TaskListEntity = new ObservableCollection<QMS_M009_H>();
            MasterValueEntity = new ObservableCollection<QMS_M009_J>();
            EnvConditionEntity = new ObservableCollection<QMS_M009_K>();

            DefaultValues();
            isNewRecord = true;
        }
        protected override void OnDiscardAction(InquiryActionResult<QMS_M009_A> result)
        {

        }
        protected override void OnDocumentAction()
        {
            try
            {
                CursorControl.SetBusyState();
                if (!string.IsNullOrEmpty(MasterEntity.test_code))
                {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.test_code.Replace("/", "--"), DocumentList = MCTemp.Attachment, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
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
        protected override void OnFevoriteAction(InquiryActionResult<QMS_M009_A> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<QMS_M009_A> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<QMS_M009_A> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<QMS_M009_A> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<QMS_M009_A> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<QMS_M009_A> result)
        {
            try
            {
                CursorControl.SetBusyState();
                MasterEntity.editby = AppSessionState.UserID;
                MasterEntity.XmlDataDocument_QMS_M009_B = obj.ObjectToXML(TestTypeEntity);
                MasterEntity.XmlDataDocument_QMS_M009_C = obj.ObjectToXML(TestHeaderEntity);
                MasterEntity.XmlDataDocument_QMS_M009_D = obj.ObjectToXML(HeaderValueEntity);
                MasterEntity.XmlDataDocument_QMS_M009_E_M = obj.ObjectToXML(MasterHeaderEntity);
                MasterEntity.XmlDataDocument_QMS_M009_E_I = obj.ObjectToXML(InstHeaderEntity);
                MasterEntity.XmlDataDocument_QMS_M009_F = obj.ObjectToXML(ParameterEntity);
                MasterEntity.XmlDataDocument_QMS_M009_G = obj.ObjectToXML(ParameterValueEntity);
                MasterEntity.XmlDataDocument_QMS_M009_H = obj.ObjectToXML(TaskListEntity);
                MasterEntity.XmlDataDocument_QMS_M009_J = obj.ObjectToXML(MasterValueEntity);
                MasterEntity.XmlDataDocument_QMS_M009_K = obj.ObjectToXML(EnvConditionEntity);

                this.MasterEntity.EndEdit();
                if (Validation() == true)
                {
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<QMS_M009_A>(MasterEntity, "TestIdentificationMaster", "Administration");
                    }
                    else if (isNewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<QMS_M009_A>(MasterEntity, "TestIdentificationMaster", "Administration");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");

                    if (MasterEntity.test_code != null && isNewRecord == true)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Saved Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    if (MasterEntity.test_code != null && isNewRecord == false)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record Updated Successfully", this.Title);
                        showMessageService.ShowMessage();
                    }
                    isNewRecord = false;
                    SetPopupForStandards();
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
        protected override void OnRefreshCommand(InquiryActionResult<QMS_M009_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<QMS_M009_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<QMS_M009_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<QMS_M009_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<QMS_M009_A> result)
        {
            throw new NotImplementedException();
        }



        #endregion
    }
}