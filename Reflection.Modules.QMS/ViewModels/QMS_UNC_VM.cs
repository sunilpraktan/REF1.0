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
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.QMS.ViewModels
{
    public class QMS_UNC_VM : WorkspaceViewModel<QMS_T001>
    {
        WebServiceRepository<MultipleContext_QMS_T001> repository_MC = new WebServiceRepository<MultipleContext_QMS_T001>();
        WebServiceRepository<MultipleContext_QMS_T001> repository_MCTemp = new WebServiceRepository<MultipleContext_QMS_T001>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region AutoSuggest TextBox Declaration Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(QMS_UNC_VM));
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

        private AutoSuggestTextViewModel<dynamic> _ASBenchValues { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBenchValues
        {
            get { return _ASBenchValues; }
            set
            {
                if (_ASBenchValues != value)
                {
                    _ASBenchValues = value; RaisePropertyChanged("ASBenchValues");
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

        #endregion

        #region Declaration
        private QMS_T001 _MasterEntity;
        public QMS_T001 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value;
                    RaisePropertyChanged("MasterEntity");
                }
            }
        }

        private List<QMS_T001_A> _MasterEquipmentEntity;
        public List<QMS_T001_A> MasterEquipmentEntity
        {
            get { return _MasterEquipmentEntity; }
            set
            {
                if (_MasterEquipmentEntity != value)
                {
                    _MasterEquipmentEntity = value;
                    RaisePropertyChanged("MasterEquipmentEntity");
                }
            }
        }

        private ObservableCollection<QMS_T001_B> _TestTypeEntity;
        public ObservableCollection<QMS_T001_B> TestTypeEntity
        {
            get { return _TestTypeEntity; }
            set
            {
                if (_TestTypeEntity != value)
                {
                    _TestTypeEntity = value;
                    RaisePropertyChanged("TestTypeEntity");
                }
            }
        }

        private ObservableCollection<QMS_T001_C> _ResultEntity;
        public ObservableCollection<QMS_T001_C> ResultEntity
        {
            get { return _ResultEntity; }
            set
            {
                if (_ResultEntity != value)
                {
                    _ResultEntity = value;
                    RaisePropertyChanged("ResultEntity");
                }
            }
        }

        private ObservableCollection<QMS_M003_B> _ParameterEntity;
        public ObservableCollection<QMS_M003_B> ParameterEntity
        {
            get { return _ParameterEntity; }
            set
            {
                if (_ParameterEntity != value)
                {
                    _ParameterEntity = value;
                    RaisePropertyChanged("ParameterEntity");
                }
            }
        }

        private ObservableCollection<QMS_T001_E> _TaskListEntity;
        public ObservableCollection<QMS_T001_E> TaskListEntity
        {
            get { return _TaskListEntity; }
            set { _TaskListEntity = value; RaisePropertyChanged("TaskListEntity"); }
        }

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
        private ObservableCollection<ShowReading> _ShowEntity;
        public ObservableCollection<ShowReading> ShowEntity
        {
            get { return _ShowEntity; }
            set { _ShowEntity = value; RaisePropertyChanged("ShowEntity"); }
        }
        private ICollectionView _TestTypeDataGrid;
        public ICollectionView TestTypeDataGrid
        {
            get { return _TestTypeDataGrid; }
            set { _TestTypeDataGrid = value; RaisePropertyChanged("TestTypeDataGrid"); }
        }
        public class ShowReading : ObjectBase
        {
            private bool _select;
            public bool select
            {
                get { return _select; }
                set { _select = value; RaisePropertyChanged("select"); }
            }
            private decimal? _values;
            public decimal? values
            {
                get { return _values; }
                set { _values = value; RaisePropertyChanged("values"); }
            }
        }

        List<QMS_T001_B> TypeAEntity = new List<QMS_T001_B>();

        #endregion

        #region Relay Commands Declaration
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdTypeA { get; private set; }
        public RelayCommand<object> CmdTypeB { get; private set; }
        public RelayCommand<object> CmdBudget { get; private set; }
        public RelayCommand<object> CmdAddTestType { get; private set; }
        public RelayCommand<object> CmdAddBenchmarks { get; private set; }
        public RelayCommand<object> CmdCustReport { get; private set; }

        #endregion

        #region Constructor
        public QMS_UNC_VM() : base()
        {
            MasterEntity = new QMS_T001();
            MC = new MultipleContext_QMS_T001();
            MCTemp = new MultipleContext_QMS_T001();
            ShowEntity = new ObservableCollection<ShowReading>();
            TypeAEntity = new List<QMS_T001_B>();

            CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(items => { if (items == null) { return; } LoadDocumentByDocumentNumber(items, "FlipGridReference"); });
            CmdAddTestType = new RelayCommand<object>(items => { if (items == null) { return; } InsertTestType(items); });
            CmdAddBenchmarks = new RelayCommand<object>(items => { if (items == null) { return; } InsertBenchmarks(items); });
            
            LoadInitialData();
        }

        #endregion

        #region User Defined Functions
        private void LoadInitialData()
        {
            try
            {
                MasterEntity.doc_cat = "CC";
                MasterEntity.doc_type = "CC";
                string Request = "LoadInitialDataForUncertainty" + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_T001>(MC, Request, "CalibrationView", "QMS", "LoadInitialDataForUncertainty", 0, "");

                FlipGridData = MC.DocumentDataFlipGrid;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
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
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                QMS_T001Flip ParameterEntityObject = new QMS_T001Flip();

                if (((IEnumerable)ParameterObject).Cast<QMS_T001Flip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<QMS_T001Flip>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.doc_no + "!@" + ParameterEntityObject.test_code;
                    MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_T001>(MCTemp, Request, "CalibrationView", "QMS", "LoadDocumentByDocumentNumberForUncertainty", 0, "");
                }
                if (MCTemp.MasterEntity.Count > 0)
                {
                    MasterEntity = MCTemp.MasterEntity[0];
                }
                MC.TestType = MCTemp.TestType;
                MC.MasterHeader = MCTemp.MasterHeader;
                MC.UnitHeader = MCTemp.UnitHeader;
                MC.BenchHeader = MCTemp.BenchHeader;

                TestTypeEntity = MCTemp.TestTypeEntity;
                ParameterEntity = MCTemp.ParameterEntity;
                TaskListEntity = MCTemp.TaskListEntity;
                MasterEquipmentEntity = MCTemp.MasterEquipment.ToList();

                if (MCTemp.Attachment != null)
                {
                    AttachmentCollection = MCTemp.Attachment;
                }
                else
                {
                    MCTemp.Attachment = new List<COM_T003>();
                }

                var ttc = TestTypeEntity.GroupBy(X => X.test_type_code).Select(Y => Y.First()).ToList();

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_T001_B)x).test_type_name ?? "");
                TheFilter = (o, prefix) => (((QMS_T001_B)o).test_type_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ASTestType = new AutoSuggestTextViewModel<dynamic>(ttc.ToList(), TheFilter, SuggestedValue, "test_type_name", true);
                ASTestType.AutoSuggestVM.IsEmptyValueAllowed = true;

                MasterEntity.user_source1 = null;
                MasterEntity.user_source2 = null;
                SelectedTabControlIndex = 1;

                var msg = new NotificationMessage("QMS_UNC_VM");
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
        private void TypeA()
        {
            List<QMS_T001_B> temp = new List<QMS_T001_B>();
            temp = (from o in TestTypeEntity where o.column_value2 == MasterEntity.BenchValue && o.test_type_name == MasterEntity.user_source1 select o).ToList();
            TypeAEntity = new List<QMS_T001_B>();

            #region Value Assigning
            if (temp != null)
            {
                foreach (var o in temp)
                {
                    if (o.value31 != null && ShowEntity[0].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value,
                            unit_code = o.unit_code,
                            image1 = MC.FormulaDetails[0].image1,
                            image2 = MC.FormulaDetails[0].image2
                        });
                    }
                    if (o.value32 != null && ShowEntity[1].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value
                        });
                    }
                    if (o.value33 != null && ShowEntity[2].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value,
                        });
                    }

                    if (o.value34 != null && ShowEntity[3].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value,
                        });
                    }
                    if (o.value35 != null && ShowEntity[4].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value,
                        });
                    }
                    if (o.value36 != null && ShowEntity[5].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value,
                        });
                    }
                    if (o.value37 != null && ShowEntity[6].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value,
                        });
                    }
                    if (o.value38 != null && ShowEntity[7].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value,
                        });
                    }
                    if (o.value39 != null && ShowEntity[8].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value,
                        });
                    }
                    if (o.value40 != null && ShowEntity[9].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value,
                        });
                    }
                    if (o.value41 != null && ShowEntity[10].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value,
                        });
                    }
                    if (o.value42 != null && ShowEntity[11].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value,
                        });
                    }
                    if (o.value43 != null && ShowEntity[12].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value,
                        });
                    }
                    if (o.value44 != null && ShowEntity[13].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value,
                        });
                    }
                    if (o.value45 != null && ShowEntity[14].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value,
                        });
                    }
                    if (o.value46 != null && ShowEntity[15].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value,
                        });
                    }
                    if (o.value47 != null && ShowEntity[16].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value,
                        });
                    }
                    if (o.value48 != null && ShowEntity[17].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value,
                        });
                    }
                    if (o.value49 != null && ShowEntity[18].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value,
                        });
                    }
                    if (o.value50 != null && ShowEntity[19].select == true)
                    {
                        TypeAEntity.Add(new QMS_T001_B()
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
                            value32 = null,
                            value33 = null,
                            value34 = null,
                            value35 = null,
                            value36 = null,
                            value37 = null,
                            value38 = null,
                            value39 = null,
                            value40 = null,
                            value41 = null,
                            value42 = null,
                            value43 = null,
                            value44 = null,
                            value45 = null,
                            value46 = null,
                            value47 = null,
                            value48 = null,
                            value49 = null,
                            value50 = null,
                            value51 = o.value51,
                            value52 = o.value52,
                            value53 = o.value53,
                            degree_of_frdm = o.degree_of_frdm,
                            dev_value = o.dev_value,
                            dev_mean_value = o.dev_mean_value,
                            dev_per_value = o.dev_per_value,
                        });
                    }
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

            List<QMS_T001_B> tempEntity = new List<QMS_T001_B>();
            decimal? min_value = 0;
            decimal? max_value = 0;
            decimal? avg_value = 0;
            int count;

            foreach (var columns in temp)
            {
                if (columns.value31 != null && ShowEntity[0].select == true)
                {
                    count = 1;
                    avg_value = columns.value31;
                    min_value = columns.value31;
                    max_value = columns.value31;
                }
                if (columns.value32 != null && ShowEntity[1].select == true)
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
                }
                if (columns.value33 != null && ShowEntity[2].select == true)
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
                }
                if (columns.value34 != null && ShowEntity[3].select == true)
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
                }
                if (columns.value35 != null && ShowEntity[4].select == true)
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
                } 
                if (columns.value36 != null && ShowEntity[5].select == true)
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
                }
                if (columns.value37 != null && ShowEntity[6].select == true)
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
                }
                if (columns.value38 != null && ShowEntity[7].select == true)
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
                }
                if (columns.value39 != null && ShowEntity[8].select == true)
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
                }
                if (columns.value40 != null && ShowEntity[9].select == true)
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
                }
                if (columns.value41 != null && ShowEntity[10].select == true)
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
                }
                if (columns.value42 != null && ShowEntity[11].select == true)
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
                }
                if (columns.value43 != null && ShowEntity[12].select == true)
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
                }
                if (columns.value44 != null && ShowEntity[13].select == true)
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
                }
                if (columns.value45 != null && ShowEntity[14].select == true)
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
                }
                if (columns.value46 != null && ShowEntity[15].select == true)
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
                }
                if (columns.value47 != null && ShowEntity[16].select == true)
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
                }
                if (columns.value48 != null && ShowEntity[17].select == true)
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
                }
                if (columns.value49 != null && ShowEntity[18].select == true)
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
                }
                if (columns.value50 != null && ShowEntity[19].select == true)
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
                }
                columns.value51 = min_value;
                columns.value52 = max_value;
                columns.value53 = avg_value;
            }
            #endregion

            //int n = 0; //Count of readings -- n-1 is degree of freedom
            decimal? x;

            foreach (var o in temp)
            {
                o.degree_of_frdm = 0;
                o.dev_value = 0;
                if (o.value31 != null && ShowEntity[0].select == true) //x
                {
                    x = o.value31 - o.value53;
                    x = x * x;
                    o.degree_of_frdm++;
                    o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                }
                if (o.value32 != null && ShowEntity[1].select == true) //x
                {
                    x = o.value32 - o.value53;
                    x = x * x;
                    o.degree_of_frdm++;
                    o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                }
                if (o.value33 != null && ShowEntity[2].select == true) //x
                {
                    x = o.value33 - o.value53;
                    x = x * x;
                    o.degree_of_frdm++;
                    o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                }
                if (o.value34 != null && ShowEntity[3].select == true) //x
                {
                    x = o.value34 - o.value53;
                    x = x * x;
                    o.degree_of_frdm++;
                    o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                }
                if (o.value35 != null && ShowEntity[4].select == true) //x
                {
                    x = o.value35 - o.value53;
                    x = x * x;
                    o.degree_of_frdm++;
                    o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                }
                if (o.value36 != null && ShowEntity[5].select == true) //x
                {
                    x = o.value36 - o.value53;
                    x = x * x;
                    o.degree_of_frdm++;
                    o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                }
                if (o.value37 != null && ShowEntity[6].select == true) //x
                {
                    x = o.value37 - o.value53;
                    x = x * x;
                    o.degree_of_frdm++;
                    o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                }
                if (o.value38 != null && ShowEntity[7].select == true) //x
                {
                    x = o.value38 - o.value53;
                    x = x * x;
                    o.degree_of_frdm++;
                    o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                }
                if (o.value39 != null && ShowEntity[8].select == true) //x
                {
                    x = o.value39 - o.value53;
                    x = x * x;
                    o.degree_of_frdm++;
                    o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                }
                if (o.value40 != null && ShowEntity[9].select == true) //x
                {
                    x = o.value40 - o.value53;
                    x = x * x;
                    o.degree_of_frdm++;
                    o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                }
                if (o.value41 != null && ShowEntity[10].select == true) //x
                {
                    x = o.value41 - o.value53;
                    x = x * x;
                    o.degree_of_frdm++;
                    o.dev_value = Convert.ToDecimal(o.dev_value) + x;
                }
                decimal? m = Convert.ToDecimal((double)1 / (o.degree_of_frdm - 1));
                o.dev_value = Convert.ToDecimal(Math.Sqrt((double)(m * o.dev_value)));
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
                }
            }
            #endregion
        }
        private void TypeB()
        {
            
        }
        private void Budget(object InputValue)
        {

        }
        private void InsertTestType(object InputValue)
        {
            string Request = "";
            QMS_T001_B POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = TestTypeEntity.Where(x => x.test_type_name.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_T001_B>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_T001_B>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    var BenchValues = from o in TestTypeEntity where o.test_type_code == POPUPEntityObject.test_type_code select o;

                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((QMS_T001_B)x).column_value2 ?? "");
                    TheFilter = (o, prefix) => (((QMS_T001_B)o).column_value2 ?? "").ToString().ToLower().Contains(prefix.ToString().ToLower());
                    ASBenchValues = new AutoSuggestTextViewModel<dynamic>(BenchValues.ToList(), TheFilter, SuggestedValue, "column_value2", true);
                    ASBenchValues.AutoSuggestVM.IsEmptyValueAllowed = true;

                    var MasterList = from o in TestTypeEntity where o.master_inst == POPUPEntityObject.master_inst select o;
                    if (MasterList.ToList().Count > 0)
                    {
                        MasterEquipmentEntity = (from m in MCTemp.MasterEquipment where m.ItemCode == MasterList.ToList()[0].master_inst select m).ToList();
                    }
                }
            }
            catch (Exception ex) { }
        }
        private void InsertBenchmarks(object InputValue)
        {
            string Request = "";
            QMS_T001_B POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = TestTypeEntity.Where(x => x.column_value2.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<QMS_T001_B>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_T001_B>().ToList()[0];
                }
                if (POPUPEntityObject != null)
                {
                    List<QMS_T001_B> temp = new List<QMS_T001_B>();
                    temp = (from o in TestTypeEntity where o.column_value2 == MasterEntity.BenchValue && o.test_type_name == MasterEntity.user_source1 select o).ToList();
                    ShowEntity = new ObservableCollection<ShowReading>();
                    if (temp != null && temp.Count > 0)
                    {
                        if (temp[0].value31 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value31
                            });
                        }
                        if (temp[0].value32 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value32
                            });
                        }
                        if (temp[0].value33 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value33
                            });
                        }
                        if (temp[0].value34 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value34
                            });
                        }
                        if (temp[0].value35 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value35
                            });
                        }
                        if (temp[0].value36 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value36
                            });
                        }
                        if (temp[0].value37 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value37
                            });
                        }
                        if (temp[0].value38 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value38
                            });
                        }
                        if (temp[0].value39 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value39
                            });
                        }
                        if (temp[0].value40 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value40
                            });
                        }
                        if (temp[0].value41 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value41
                            });
                        }
                        if (temp[0].value42 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value42
                            });
                        }
                        if (temp[0].value43 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value43
                            });
                        }
                        if (temp[0].value44 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value44
                            });
                        }
                        if (temp[0].value45 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value45
                            });
                        }
                        if (temp[0].value46 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value46
                            });
                        }
                        if (temp[0].value47 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value47
                            });
                        }
                        if (temp[0].value48 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value48
                            });
                        }
                        if (temp[0].value49 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value49
                            });
                        }
                        if (temp[0].value50 != null)
                        {
                            ShowEntity.Add(new ShowReading()
                            {
                                values = temp[0].value50
                            });
                        }
                    }
                }
            }
            catch (Exception ex) { }
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
                            data.EmpNm != null && data.EmpNm.ToLower().Contains(_filterString.ToLower())
                            );
                }
                return true;
            }
            return false;
        }
        #endregion

        #endregion

        #region Abstract Command Actions
        protected override void OnCreateAction(InquiryActionResult<QMS_T001> result)
        {
            MasterEntity = new QMS_T001();
            ShowEntity = new ObservableCollection<ShowReading>();
            TestTypeEntity = new ObservableCollection<QMS_T001_B>();
            ParameterEntity = new ObservableCollection<QMS_M003_B>();
            TaskListEntity = new ObservableCollection<QMS_T001_E>();
            MasterEquipmentEntity = new List<QMS_T001_A>();
            SelectedTabControlIndex = 0;
        }

        protected override void OnDiscardAction(InquiryActionResult<QMS_T001> result)
        {

        }

        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.doc_no))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MCTemp.Attachment });
            }
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
                TypeA();
                TypeB();

                object[] objDataSource = new object[6];
                string[] objDataSourceName = new string[6];

                //string Request = "LoadReportData" + "!@" + MasterEntity.doc_no + "!@" + MasterEntity.test_code;
                //MCTemp = repository_MC.GetDataWithReturnDomainObject<MultipleContext_QMS_T001>(MCTemp, Request, "CalibrationView", "QMS", "LoadReportData", 0, "");

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var locResult = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[0] = locResult;

                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[1] = CmpResult;

                objDataSource[2] = MCTemp.MasterEntity;
                objDataSource[3] = TypeAEntity;
                objDataSource[4] = MasterEquipmentEntity;

                objDataSourceName[0] = "dsLocation";
                objDataSourceName[1] = "dsCompany";
                objDataSourceName[2] = "dsCalibrationMaster";
                objDataSourceName[3] = "dsDataSheet1";
                objDataSourceName[4] = "dsMasterInst";

                string ReportName = "";
                var SystemDocumentObject = (from o in MC.DocTypeInfo where o.doc_cat == MasterEntity.doc_cat select o).ToList();
                if (SystemDocumentObject.Count > 0)
                {
                    ReportName = SystemDocumentObject[0].report_name.Split(',')[4];
                    MasterEntity.report_no = SystemDocumentObject[0].report_no.Split(',')[3];
                }

                ReportingServices.ReportManager ReportManager = new ReportingServices.ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\QMS\\" + ReportName, "UncertaintyBudget"); //Calibration.rdlc
            }
            catch (Exception ex)
            {

            }
        }

        protected override void OnRemoveAction(InquiryActionResult<QMS_T001> result)
        {

        }

        protected override void OnSaveAction(InquiryActionResult<QMS_T001> result)
        {
            MasterEntity.BenchValue = MasterEntity.BenchValue;
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
        #endregion
    }
}
