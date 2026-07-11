using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Reflection.ReportingServices;
using Reflection.Presentation.Controls;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI.Core;
using System.Windows;
using Reflection.Presentation.Services.Convertors;

namespace Reflection.Modules.SCM.ViewModels
{
    class MM_T001_MC_VM : WorkspaceViewModel<MM_T001>
    {
        void ModelEntityUpdated(object sender, EventArgs e)
        {
            if (sender.ToString() == "para6" || sender.ToString() == "qty" || sender.ToString() == "active")
            {
                CalculateWeight(true);
            }
            this.ErrorExist = MasterEntity.HasErrors;
        }

        #region AutoSuggest
        //public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(MM_T001_MC_VM));
        //public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

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
                    { ASDefault = ASItem; }

                }
            }
        }

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

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

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

        private AutoSuggestTextViewModel<dynamic> _ASItem { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItem
        {
            get { return _ASItem; }
            set
            {
                if (_ASItem != value)
                {
                    _ASItem = value; RaisePropertyChanged("ASItem");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASInk { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASInk
        {
            get { return _ASInk; }
            set
            {
                if (_ASInk != value)
                {
                    _ASInk = value; RaisePropertyChanged("ASInk");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASIld { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASIld
        {
            get { return _ASIld; }
            set
            {
                if (_ASIld != value)
                {
                    _ASIld = value; RaisePropertyChanged("ASIld");
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
        private AutoSuggestTextViewModel<dynamic> _ASDitem { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDitem
        {
            get { return _ASDitem; }
            set
            {
                if (_ASDitem != value)
                {
                    _ASDitem = value; RaisePropertyChanged("ASDitem");
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

        private AutoSuggestTextViewModel<dynamic> _ASType { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASType
        {
            get { return _ASType; }
            set
            {
                if (_ASType != value)
                {
                    _ASType = value; RaisePropertyChanged("ASType");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASMatcond { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASMatcond
        {
            get { return _ASMatcond; }
            set
            {
                if (_ASMatcond != value)
                {
                    _ASMatcond = value; RaisePropertyChanged("ASMatcond");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASdunit { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASdunit
        {
            get { return _ASdunit; }
            set
            {
                if (_ASdunit != value)
                {
                    _ASdunit = value; RaisePropertyChanged("ASdunit");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASGrade1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASGrade1
        {
            get { return _ASGrade1; }
            set
            {
                if (_ASGrade1 != value)
                {
                    _ASGrade1 = value; RaisePropertyChanged("ASGrade1");
                }
            }
        }

        #endregion

        #region Declaration
        bool NewRecord = true;
        WebServiceRepository<MM_T001> repository = new WebServiceRepository<MM_T001>();
        WebServiceRepository<MC_MM_T001> repository_MC = new WebServiceRepository<MC_MM_T001>();
        WebServiceRepository<MC_MM_T001> repository_MCTemp = new WebServiceRepository<MC_MM_T001>();
        WebServiceRepository<MC_MM_T001> Repository_Temp = new WebServiceRepository<MC_MM_T001>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MC_MM_T001 _MC = new MC_MM_T001();
        public MC_MM_T001 MC
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
        public string ts_code_vm { get; set; }
        public string doc_no_vm { get; set; }

        private MC_MM_T001 _MCTemp = new MC_MM_T001();
        public MC_MM_T001 MCTemp
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

        private MC_MM_T001 _Temp = new MC_MM_T001();
        public MC_MM_T001 Temp
        {
            get { return _Temp; }
            set
            {
                if (_Temp != value)
                {
                    _Temp = value; RaisePropertyChanged("Temp");
                }
            }
        }

        private MM_T001 _MasterEntity;
        public MM_T001 MasterEntity
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

        private ObservableCollection<MM_T001_A> _ItemsEntity;
        public ObservableCollection<MM_T001_A> ItemsEntity
        {
            get { return _ItemsEntity; }
            set
            {
                if (_ItemsEntity != value)
                {
                    _ItemsEntity = value; RaisePropertyChanged("ItemsEntity");
                }
            }
        }

        private List<MM_M001> _StoreLocList = new List<MM_M001>();
        public List<MM_M001> StoreLocList
        {
            get { return _StoreLocList; }
            set
            {
                if (_StoreLocList != value)
                {
                    _StoreLocList = value;
                }
            }
        }
        string store_location;

        private bool _PostDateEditable;
        public bool PostDateEditable
        {
            get { return _PostDateEditable; }
            set { _PostDateEditable = value; RaisePropertyChanged("PostDateEditable"); }
        }

        private bool _GridEditable;
        public bool GridEditable
        {
            get { return _GridEditable; }
            set
            {
                if (_GridEditable != value)
                {
                    _GridEditable = value;
                    RaisePropertyChanged("GridEditable");
                }
            }
        }

        private bool _parameter;
        public bool parameter
        {
            get { return _parameter; }
            set
            {
                if (_parameter != value)
                {
                    _parameter = value;
                    RaisePropertyChanged("parameter");
                }
            }
        }
        public int _SelectedTabControlIndex;
        public int SelectedTabControlIndex
        {
            get
            {
                return _SelectedTabControlIndex;
            }
            set
            {
                _SelectedTabControlIndex = value;
                RaisePropertyChanged("SelectedTabControlIndex");
            }
        }
        #endregion

        #region List
        private List<MM_T001Flip> _FlipGridData;
        public List<MM_T001Flip> FlipGridData
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
        #endregion

        #region Collection
        private ICollectionView _FlipDataGridCollection;
        public ICollectionView FlipDataGridCollection
        {
            get { return _FlipDataGridCollection; }
            set { _FlipDataGridCollection = value; RaisePropertyChanged("FlipDataGridCollection"); }
        }

        private ICollectionView _MovementTypeCollection;
        public ICollectionView MovementTypeCollection
        {
            get { return _MovementTypeCollection; }
            set { _MovementTypeCollection = value; RaisePropertyChanged("MovementTypeCollection"); }

        }

        private ICollectionView _InkCollection;
        public ICollectionView InkCollection
        {
            get { return _InkCollection; }
            set { _InkCollection = value; RaisePropertyChanged("InkCollection"); }
        }

        private ICollectionView _IldCollection;
        public ICollectionView IldCollection
        {
            get { return _IldCollection; }
            set { _IldCollection = value; RaisePropertyChanged("IldCollection"); }
        }

        private ICollectionView _GradeCollection;
        public ICollectionView GradeCollection
        {
            get { return _GradeCollection; }
            set { _GradeCollection = value; RaisePropertyChanged("GradeCollection"); }
        }

        private ICollectionView _SourceItemCollection;
        public ICollectionView SourceItemCollection
        {
            get { return _SourceItemCollection; }
            set { _SourceItemCollection = value; RaisePropertyChanged("SourceItemCollection"); }
        }

        private ICollectionView _RMItemCollection;
        public ICollectionView RMItemCollection
        {
            get { return _RMItemCollection; }
            set { _RMItemCollection = value; RaisePropertyChanged("RMItemCollection"); }
        }

        private ICollectionView _UnitCollection;
        public ICollectionView UnitCollection
        {
            get { return _UnitCollection; }
            set { _UnitCollection = value; RaisePropertyChanged("UnitCollection"); }
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

        private ICollectionView _MakeCollection;
        public ICollectionView MakeCollection
        {
            get { return _MakeCollection; }
            set { _MakeCollection = value; RaisePropertyChanged("MakeCollection"); }
        }

        private ICollectionView _TypeCollection;
        public ICollectionView TypeCollection
        {
            get { return _TypeCollection; }
            set { _TypeCollection = value; RaisePropertyChanged("TypeCollection"); }
        }

        private ICollectionView _MaterialConditionCollection;
        public ICollectionView MaterialConditionCollection
        {
            get { return _MaterialConditionCollection; }
            set { _MaterialConditionCollection = value; RaisePropertyChanged("MaterialConditionCollection"); }
        }
        #endregion

        #region StringList
        List<string> _StringListMovementType;
        public List<string> StringListMovementType
        {
            get { return _StringListMovementType; }
            set
            {
                if (_StringListMovementType != value)
                {
                    _StringListMovementType = value;
                }
            }
        }

        List<string> _StringListInk;
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

        List<string> _StringListIld;
        public List<string> StringListIld
        {
            get { return _StringListIld; }
            set
            {
                if (_StringListIld != value)
                {
                    _StringListIld = value;
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

        List<string> _StringListSourceItem;
        public List<string> StringListSourceItem
        {
            get { return _StringListSourceItem; }
            set
            {
                if (_StringListSourceItem != value)
                {
                    _StringListSourceItem = value;
                }
            }
        }

        List<string> _StringListRMItem;
        public List<string> StringListRMItem
        {
            get { return _StringListRMItem; }
            set
            {
                if (_StringListRMItem != value)
                {
                    _StringListRMItem = value;
                }
            }
        }

        List<string> _StringListUnit;
        public List<string> StringListUnit
        {
            get { return _StringListUnit; }
            set
            {
                if (_StringListUnit != value)
                {
                    _StringListUnit = value;
                }
            }
        }

        List<string> _StringListMake;
        public List<string> StringListMake
        {
            get { return _StringListMake; }
            set
            {
                if (_StringListMake != value)
                {
                    _StringListMake = value;
                }
            }
        }

        List<string> _StringListType;
        public List<string> StringListType
        {
            get { return _StringListType; }
            set
            {
                if (_StringListType != value)
                {
                    _StringListType = value;
                }
            }
        }

        List<string> _StringListMaterialCondition;
        public List<string> StringListMaterialCondition
        {
            get { return _StringListMaterialCondition; }
            set
            {
                if (_StringListMaterialCondition != value)
                {
                    _StringListMaterialCondition = value;
                }
            }
        }

        #endregion

        #region Relay Command Declaration
        public RelayCommand<object> CmdAddMovementType { get; private set; }
        public RelayCommand<object> CmdAddMCSourceItem { get; private set; }
        public RelayCommand<object> CmdAddMCDestinationItem { get; private set; }
        public RelayCommand<object> CmdMCSourceGrade { get; private set; }
        public RelayCommand<object> CmdMCDestinationGrade { get; private set; }
        public RelayCommand<object> CmdMCSourceUnit { get; private set; }
        public RelayCommand<object> CmdMCDestinationUnit { get; private set; }
        public RelayCommand<object> CmdMCSourceInk { get; private set; }
        public RelayCommand<object> CmdMCDestinationInk { get; private set; }
        public RelayCommand<object> CmdMCSourceIld { get; private set; }
        public RelayCommand<object> CmdMCDestinationIld { get; private set; }
        public RelayCommand<object> CmdMake { get; private set;}
        public RelayCommand<object> CmdType { get; private set; }
        public RelayCommand<object> CMDMaterialCondition { get; private set;}
        public RelayCommand<object> CmdLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRow { get; private set; }
        public RelayCommand<object> CmdAddGrade { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CmdRowChange { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CmdLoadFromProductionDateAndGrade { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }

        #endregion

        #region Constructor
        public MM_T001_MC_VM(string ts_code):base()
        {
            this.ts_code_vm = ts_code;
            parameter = false;
            PostDateEditable = true;
            GridEditable = true;
            MasterEntity = new MM_T001();
            MasterEntity.mov_tp = "126";
            FlipGridData = new List<MM_T001Flip>();
            ItemsEntity = new ObservableCollection<MM_T001_A>();
            MM_T001_A.ModelEntityUpdated += new EventHandler(ModelEntityUpdated);
            MasterEntity.ValidateAsync().Wait();
            
            LoadInitialData();
        }

        public MM_T001_MC_VM(string ts_code,string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            parameter = false;
            PostDateEditable = true;
            GridEditable = true;
            MasterEntity = new MM_T001();
            MasterEntity.mov_tp = "126";
            FlipGridData = new List<MM_T001Flip>();
            ItemsEntity = new ObservableCollection<MM_T001_A>();
            MM_T001_A.ModelEntityUpdated += new EventHandler(ModelEntityUpdated);
            MasterEntity.ValidateAsync().Wait();

            LoadInitialData();
        }
        private void LoadInitialData()
        {
            try
            {
                DefaultValues();
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type;
                MC = repository_MC.GetDataWithReturnDomainObject<MC_MM_T001>(MC, Request, "ProductConversion_Essem", "SCM", "LoadInitialData", 0, "");

                #region Command Initialisation
                CmdAddMovementType = new RelayCommand<object>(items => { if (items == null) { return; } InsertMovementType(items); });
                CmdAddMCSourceItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertMCSourceItem(items, true, true, true); });
                CmdAddMCDestinationItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertMCDestinationItem(items, true, true, true); });
                CmdMCSourceUnit = new RelayCommand<object>(items => { if (items == null) { return; } InsertMCSourceUnit(items, true, true, true); });
                CmdMCDestinationUnit = new RelayCommand<object>(items => { if (items == null) { return; } InsertMCDestinationUnit(items, true, true, true); });
                CmdMCSourceInk = new RelayCommand<object>(items => { if (items == null) { return; } InsertMCSourceInk(items, true, true, true); });
                CmdMCSourceIld = new RelayCommand<object>(items => { if (items == null) { return; } InsertMCSourceIld(items, true, true, true); });
                CmdMCSourceGrade = new RelayCommand<object>(items => { if (items == null) { return; } InsertMCSourceGrade(items, true, true, true); });
                CmdMCDestinationGrade = new RelayCommand<object>(items => { if (items == null) { return; } InsertMCDestinationGrade(items, true, true, true); });
                CmdMake = new RelayCommand<object>(items => { if (items == null) { return; } InsertMCMake(items, true, true, true); });
                CmdType = new RelayCommand<object>(items => { if (items == null) { return; } InsertMCType(items, true, true, true); });
                CMDMaterialCondition = new RelayCommand<object>(items => { if (items == null) { return; } InsertMCMaterialCondition(items, true, true, true); });
                CmdLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
                CmdDeleteDataGridRow = new RelayCommand<object>(items => { if (items == null) { return; } DeleteDataGridRow(items); });
                CmdLoadFromProductionDateAndGrade = new GalaSoft.MvvmLight.Command.RelayCommand(Load);
                CmdRowChange = new GalaSoft.MvvmLight.Command.RelayCommand(SelectionChanged);
                CmdAddGrade = new RelayCommand<object>(items => { if (items == null) { return; } InsertMasterGrade(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });

                #endregion
                #region AutoSuggest Initialization
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M045_P)x).grade_code);
                TheFilter = (o, prefix) => ((ADM_M045_P)o).grade_code.ToLower().Contains(prefix.ToLower()) || ((ADM_M045_P)o).grade_name.ToLower().Contains(prefix.ToLower());
                ASGrade = new AutoSuggestTextViewModel<dynamic>(MC.GradeDetails, TheFilter, SuggestedValue, "Grade", true);
                ASGrade.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_POPUP)x).ItemCode);
                TheFilter = (o, prefix) => ((ADM_M022_POPUP)o).ItemCode.ToLower().Contains(prefix.ToLower()) || ((ADM_M022_POPUP)o).ItemName.ToLower().Contains(prefix.ToLower());
                ASItem = new AutoSuggestTextViewModel<dynamic>(MC.SourceItemDetails, TheFilter, SuggestedValue, "ItemCode","ItemCode", true);
                ASItem.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M045_P)x).grade_code);
                TheFilter = (o, prefix) => ((ADM_M045_P)o).grade_code.ToLower().Contains(prefix.ToLower()) || ((ADM_M045_P)o).grade_name.ToLower().Contains(prefix.ToLower());
                ASGrade1 = new AutoSuggestTextViewModel<dynamic>(MC.GradeDetails, TheFilter, SuggestedValue, "Grade", true);
                ASGrade1.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M006_P)x).ink);
                TheFilter = (o, prefix) => ((ZADM_M006_P)o).ink.ToLower().Contains(prefix.ToLower());
                ASInk = new AutoSuggestTextViewModel<dynamic>(MC.InkDetails, TheFilter, SuggestedValue, "ink","para1", true);
                ASInk.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ZADM_M007_P)x).show_ild);
                TheFilter = (o, prefix) => ((ZADM_M007_P)o).show_ild.ToLower().Contains(prefix.ToLower());
                ASIld = new AutoSuggestTextViewModel<dynamic>(MC.IldDetails, TheFilter, SuggestedValue,"para2", "show_ild", true);
                ASIld.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => ((ADM_M038_B_P)o).unit_code.ToLower().Contains(prefix.ToLower());
                ASUnit = new AutoSuggestTextViewModel<dynamic>(MC.UOMDetails, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_POPUP)x).ItemCode);
                TheFilter = (o, prefix) => ((ADM_M022_POPUP)o).ItemCode.ToLower().Contains(prefix.ToLower())|| ((ADM_M022_POPUP)o).ItemName.ToLower().Contains(prefix.ToLower());
                ASDitem = new AutoSuggestTextViewModel<dynamic>(MC.RMItemDetails, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDitem.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M030_P)x).parametervalue);
                TheFilter = (o, prefix) => ((ADM_M030_P)o).parametervalue.ToLower().Contains(prefix.ToLower());
                ASMake = new AutoSuggestTextViewModel<dynamic>(MC.MakeDetails, TheFilter, SuggestedValue, "para3", "parametervalue", true);
                ASMake.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M030_P)x).parametervalue);
                TheFilter = (o, prefix) => ((ADM_M030_P)o).parametervalue.ToLower().Contains(prefix.ToLower());
                ASType = new AutoSuggestTextViewModel<dynamic>(MC.TypeDetails, TheFilter, SuggestedValue, "para4", "parametervalue", true);
                ASType.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M030_P)x).parametervalue);
                TheFilter = (o, prefix) => ((ADM_M030_P)o).parametervalue.ToLower().Contains(prefix.ToLower());
                ASMatcond = new AutoSuggestTextViewModel<dynamic>(MC.MaterialConditionDetails, TheFilter, SuggestedValue, "mat_con", "parametervalue", true);
                ASMatcond.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => ((ADM_M038_B_P)o).unit_code.ToLower().Contains(prefix.ToLower());
                ASdunit = new AutoSuggestTextViewModel<dynamic>(MC.UOMDetails, TheFilter, SuggestedValue, "ri_unit_cd", "unit_code", true);
                ASdunit.AutoSuggestVM.IsEmptyValueAllowed = true;

                #endregion

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGridData);

                MovementTypeCollection = CollectionViewSource.GetDefaultView(MC.MovementDetails);
                MovementTypeCollection.Filter = new Predicate<object>(Filter_MovementType);
                StringListMovementType = MC.MovementDetails.Select(x => x.mov_tp.ToString()).ToList();

                InkCollection = CollectionViewSource.GetDefaultView(MC.InkDetails);
                InkCollection.Filter = new Predicate<object>(Filter_Ink);
                StringListInk = MC.InkDetails.Select(x => x.ink.ToString()).ToList();

                IldCollection = CollectionViewSource.GetDefaultView(MC.IldDetails);
                IldCollection.Filter = new Predicate<object>(Filter_Ild);
                StringListIld = MC.IldDetails.Select(x => x.ild.ToString()).ToList();

                GradeCollection = CollectionViewSource.GetDefaultView(MC.GradeDetails);
                GradeCollection.Filter = new Predicate<object>(Filter_Grade);
                StringListGrade = MC.GradeDetails.Select(x => x.grade_code.ToString()).ToList();

                SourceItemCollection = CollectionViewSource.GetDefaultView(MC.SourceItemDetails);
                SourceItemCollection.Filter = new Predicate<object>(Filter_Item);
                StringListSourceItem = MC.SourceItemDetails.Select(x => x.ItemCode.ToString()).ToList();

                RMItemCollection = CollectionViewSource.GetDefaultView(MC.RMItemDetails);
                RMItemCollection.Filter = new Predicate<object>(Filter_DestinationItem);
                StringListRMItem = MC.RMItemDetails.Select(x => x.ItemCode.ToString()).ToList();

                UnitCollection = CollectionViewSource.GetDefaultView(MC.UOMDetails);
                UnitCollection.Filter = new Predicate<object>(Filter_Unit);
                StringListUnit = MC.UOMDetails.Select(x => x.unit_code.ToString()).ToList();

                MakeCollection = CollectionViewSource.GetDefaultView(MC.MakeDetails);
                MakeCollection.Filter = new Predicate<object>(Filter_Make);
                StringListMake = MC.MakeDetails.Select(x => x.parametervalue.ToString()).ToList();

                TypeCollection = CollectionViewSource.GetDefaultView(MC.TypeDetails);
                TypeCollection.Filter = new Predicate<object>(Filter_Type);
                StringListType = MC.TypeDetails.Select(x => x.parametervalue.ToString()).ToList();

                MaterialConditionCollection = CollectionViewSource.GetDefaultView(MC.MaterialConditionDetails);
                MaterialConditionCollection.Filter = new Predicate<object>(Filter_MaterialCondition);
                StringListMaterialCondition = MC.MaterialConditionDetails.Select(x => x.parametervalue.ToString()).ToList();

                StoreLocList = (List<MM_M001>)AppSessionState.store_location;
                store_location = (from o in StoreLocList
                                  where o.location_Id == AppSessionState.location_Id //&& o.default_storage_loc == Convert.ToBoolean(1)
                                  select o.store_code).ToList()[0];
                //if (StoreLocList.Count == 1)
                //{
                //    store_location = StoreLocList[0].store_code;
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
        #endregion

        #region User Define Functions
        private void CalculateWeight(bool compute)
        {
            try
            {
                if (compute == true)
                {
                   
                    if (ItemsEntity.Count != null && ItemsEntity.Count > 0 && dgSelectedIndexItem < ItemsEntity.Count)
                    {
                        for (int i = 0; i < ItemsEntity.Count; i++)
                        {
                            if (ItemsEntity[i].unit_code== "PICs")
                            {
                                if ((ItemsEntity[i].qty > 0 || ItemsEntity[i].para6 > 0) && ItemsEntity[i].active != false)
                                {
                                    ItemsEntity[i].ri_qty = (Convert.ToDecimal(ItemsEntity[i].qty) * Convert.ToDecimal(ItemsEntity[i].para6));
                                    ItemsEntity[i].ri_qty = ItemsEntity[i].ri_qty / 1000;
                                }
                            }
                            else if(ItemsEntity[i].unit_code == "THOUSAND")
                            {
                                if ((ItemsEntity[i].qty > 0 || ItemsEntity[i].para6 > 0) && ItemsEntity[i].active != false)
                                {
                                    ItemsEntity[i].ri_qty = (Convert.ToDecimal(ItemsEntity[i].qty) * Convert.ToDecimal(ItemsEntity[i].para6));
                                    ItemsEntity[i].ri_qty = ItemsEntity[i].ri_qty;
                                }
                            }
                            else if (ItemsEntity[i].unit_code == "GROSS")
                            {
                                if ((ItemsEntity[i].qty > 0 || ItemsEntity[i].para6 > 0) && ItemsEntity[i].active != false)
                                {
                                    ItemsEntity[i].ri_qty = (Convert.ToDecimal(ItemsEntity[i].qty) * Convert.ToDecimal(ItemsEntity[i].para6));
                                    ItemsEntity[i].ri_qty = (ItemsEntity[i].ri_qty * 144)/1000;
                                }
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
        private void Load()
        {
            if (MasterEntity.From_Date != null && MasterEntity.ToDate != null && MasterEntity.Grade != null)
            {
                string Request = "LoadFromProductionDateAndGrade" + "!@" + Convert.ToDateTime(MasterEntity.From_Date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(MasterEntity.ToDate).ToString("MM/dd/yyyy") + "!@" + MasterEntity.Grade + "!@" + AppSessionState.location_Id + "!@" + AppSessionState.comp_code;
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_MM_T001>(MCTemp, Request, "ProductConversion_Essem", "SCM", "", 0, "");

                foreach (var item in MCTemp.ItemsEntity)
                {
                    item.comp_code = AppSessionState.comp_code;
                    item.location_Id = AppSessionState.location_Id;
                    item.line_id = 0;
                    item.add_by = AppSessionState.UserID;
                    item.debcr_ind = "D";
                    item.posting_period = "1";
                    item.fin_year = "16-17";
                    item.active = true;
                    item.t_status = "Draft";
                    item.store_code = store_location;                   
               
                    ItemsEntity.Add(item);
                    
                }
                CalculateWeight(true);


            }
            else
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Production Date And Grade", this.Title);
                showMessageService.ShowMessage();

            }
        }
        private void DefaultValues()
        {
            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.doc_cat = "MC";
            MasterEntity.doc_type = "MC";
            MasterEntity.doc_code = "MC";
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.dept_code = AppSessionState.dept_code;
            MasterEntity.t_status = "001";
            MasterEntity.doc_no = "";
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.post_date = DateTime.Now;
            MasterEntity.active = true;
            MasterEntity.fin_year = "16-17";
            MasterEntity.posting_period = "1";
            MasterEntity.client = AppSessionState.client;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
            MasterEntity.userid = AppSessionState.UserID;
        }
        private bool Validation()
        {
            if (MasterEntity.mov_tp == null || MasterEntity.mov_tp == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Movement Type");
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.post_date == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Posting Date");
                showMessageService.ShowMessage();
                return false;
            }

            if (ItemsEntity.Count < 1)//when form is blank and we tryy to save the record
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Select Item For Conversion");
                showMessageService.ShowMessage();

                return false;
            }

            else
            {
                GenerateSku();
                GenerateSku2();
                #region . Validation for Item Duplication, null Unit Code and Null or 0 Quantity For All Active Unsaved Items .

                foreach (var o in ItemsEntity)
                {
                    int flag = 0;
                    if (o.id == 0 && o.active == true)
                    {
                        foreach (var p in ItemsEntity)
                        {
                            if (o.ItemCode == p.ItemCode && o.sku == p.sku && o.user_source1 == p.user_source1  && p.active == true && o.para1==p.para1 && o.para2 == p.para2 && o.ri_item == p.ri_item && o.para3 == p.para3 && o.para4 == p.para4 && o.mat_con == p.mat_con)
                            {
                                flag++;
                            }
                        }
                        if (flag > 1)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Cannot Save Duplicate Item {0}", o.ItemCode);
                            showMessageService.ShowMessage();
                            return false;
                        }
                    }

                    if (o.ItemCode != null && o.ItemCode != "")
                    {
                        if (o.qty == null || o.qty == 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Quantity cannot be null or 0 for item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                            showMessageService.ShowMessage();
                            return false;
                        }

                        if (o.unit_code == null || o.unit_code == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Enter Valid Unit Code for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.user_source1 == null || o.user_source1 == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select The Grade");
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.para1 == null || o.para1 == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select The Ink");
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.para2 == null || o.para2 == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select The Ild");
                            showMessageService.ShowMessage();
                            return false;
                        }
                        
                        if (o.ri_item == null || o.ri_item == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select The Item To which you want to Convert");
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.para3 == null || o.para3 == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select The Make");
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.para4 == null || o.para4 == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select The Type");
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.mat_con == null || o.mat_con == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select The Material Condition");
                            showMessageService.ShowMessage();
                            return false;
                        }
                        if (o.ri_unit_cd == null || o.ri_unit_cd == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Please Select The Destination Unit");
                            showMessageService.ShowMessage();
                            return false;
                        }
                    }

                }

                #endregion

            }

            return true;
        }
        private void GenerateSku()
        {
            string Grade = "";
            string Ink = "";
            String Ild = "";

            foreach (var o in ItemsEntity)
            {
                if (o.id == 0 && o.StockUnt==true)
                {
                    Grade = "";
                    Ink = "";
                    Ild = "";

                    if (o.user_source1 != null && o.user_source1 != "" && o.para1!=null && o.para1 !="" && o.para2!=null && o.para2 !="")
                    {
                        Grade = MC.ParameterValueDetails.Where(X => X.parametervalue.Trim() == o.user_source1.Trim() && X.para_code == "1004").Select(x => x.value_code).FirstOrDefault();
                        Ink = MC.ParameterValueDetails.Where(X => X.parametervalue.Trim() == o.para1.Trim() && X.para_code == "1005").Select(x => x.value_code).FirstOrDefault();
                        Ild = MC.ParameterValueDetails.Where(X => X.parametervalue.Trim() == o.para2.Trim() && X.para_code == "1006").Select(x => x.value_code).FirstOrDefault();

                        o.sku = Grade + "/" + Ink + "/" + Ild;
                        o.sku_desc = "Grade:" + o.user_source1 + "\t" + "Ink:" + o.para1 + "\t" + "Ild:" + o.para2;

                    }
                }

            }
        }
        private void GenerateSku2()
        {
            string Make = "";
            string Type = "";
            String MaterialCondition = "";

            foreach (var o in ItemsEntity)
            {
                if (o.id == 0 && o.StockUnt==true)
                {
                    Make = "";
                    Type = "";
                    MaterialCondition = "";

                    if (o.para3 != null && o.para3 != "" && o.para4 != null && o.para4 != "" && o.mat_con != null && o.mat_con != "")
                    {
                        Make = MC.ParameterValueDetails.Where(X => X.parametervalue.Trim() == o.para3.Trim() && X.para_code == "1002").Select(x => x.value_code).FirstOrDefault();
                        Type = MC.ParameterValueDetails.Where(X => X.parametervalue.Trim() == o.para4.Trim() && X.para_code == "1001").Select(x => x.value_code).FirstOrDefault();
                        MaterialCondition = MC.ParameterValueDetails.Where(X => X.parametervalue.Trim() == o.mat_con.Trim() && X.para_code == "1003").Select(x => x.value_code).FirstOrDefault();

                        o.ri_sku = Make + "/" + Type + "/" + MaterialCondition;
                       
                    }
                }

            }
        }
        private void SelectionChanged()
        {
            try
            {
                if (dgSelectedIndexItem != -1 && dgSelectedIndexItem < ItemsEntity.Count && ItemsEntity.Count > 0)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0)
                    {
                        GridEditable = true;
                    }
                    else
                    {

                        GridEditable = false;
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
        private void DeleteDataGridRow(object InputValue)
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
        private void InsertMovementType(object InputValue)
        {
            string Request = "";
            MM_M004_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.MovementDetails.Where(x => x.mov_tp.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<MM_M004_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.mov_tp = POPUPEntityObject.mov_tp;
                MasterEntity.mov_name = POPUPEntityObject.mov_name;

            }
        }
        private void InsertMasterGrade(object InputValue)
        {
            string Request = "";
            ADM_M045_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.GradeDetails.Where(x => x.grade_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M045_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }

            if (POPUPEntityObject != null)
            {
                MasterEntity.Grade = POPUPEntityObject.grade_code;
            }
        }
        private void InsertMCSourceItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M022_POPUP POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.SourceItemDetails.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_POPUP>().ToList()[0];
                }

            }
            catch (Exception ex) { }
            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(x => x.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault();
                int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault());
                //Insert
                if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                {
                    ItemsEntity.Add(new MM_T001_A()
                    {

                        ItemCode = POPUPEntityObject.ItemCode,
                        ItemNm = POPUPEntityObject.ItemName,
                        user_source1 = POPUPEntityObject.Grade,
                        unit_code = POPUPEntityObject.unit_code,
                        para1 = POPUPEntityObject.ink,
                        para2 = POPUPEntityObject.ild,
                        SubCatCode = POPUPEntityObject.SubCatCode,
                        StockUnt = Convert.ToBoolean(POPUPEntityObject.StockUnt),

                        location_Id = AppSessionState.location_Id,
                        comp_code = AppSessionState.comp_code,
                        add_by = AppSessionState.UserID,
                        debcr_ind = "D",
                        posting_period = "1",
                        fin_year = "16-17",
                        line_id = 0,
                        active = true,
                        t_status = "Draft",
                        store_code = store_location,
                        para6 = POPUPEntityObject.para6,

                    });
                }
                //update
                else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true)))
                    {
                        ItemsEntity[dgSelectedIndexItem].ItemCode = POPUPEntityObject.ItemCode;
                        ItemsEntity[dgSelectedIndexItem].ItemNm = POPUPEntityObject.ItemName;
                        ItemsEntity[dgSelectedIndexItem].user_source1 = POPUPEntityObject.Grade;
                        ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        ItemsEntity[dgSelectedIndexItem].para1 = POPUPEntityObject.ink;
                        ItemsEntity[dgSelectedIndexItem].para2 = POPUPEntityObject.ild;
                        ItemsEntity[dgSelectedIndexItem].SubCatCode = POPUPEntityObject.SubCatCode;
                        ItemsEntity[dgSelectedIndexItem].StockUnt = POPUPEntityObject.StockUnt;
                        ItemsEntity[dgSelectedIndexItem].location_Id = AppSessionState.location_Id;
                        ItemsEntity[dgSelectedIndexItem].comp_code = AppSessionState.comp_code;
                        ItemsEntity[dgSelectedIndexItem].add_by = AppSessionState.UserID;
                        ItemsEntity[dgSelectedIndexItem].fin_year = "16-17";
                        ItemsEntity[dgSelectedIndexItem].posting_period = "1";
                        ItemsEntity[dgSelectedIndexItem].line_id = 0;
                        ItemsEntity[dgSelectedIndexItem].active = true;
                        ItemsEntity[dgSelectedIndexItem].t_status = "Draft";
                        ItemsEntity[dgSelectedIndexItem].debcr_ind = "D";
                        ItemsEntity[dgSelectedIndexItem].store_code = store_location;
                        ItemsEntity[dgSelectedIndexItem].para6 = POPUPEntityObject.para6;
                    }
                    else if (ItemsEntity[dgSelectedIndexItem].ItemCode != POPUPEntityObject.ItemCode)
                    {
                        ItemsEntity[dgSelectedIndexItem].ItemCode = "";
                        ItemsEntity[dgSelectedIndexItem].ItemNm = "";
                    }
                }
            }
        }
        private void InsertMCSourceGrade(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M045_P POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.GradeDetails.Where(x => x.grade_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null  && ((IEnumerable)InputValue).Cast<ADM_M045_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M045_P>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.user_source1 == POPUPEntityObject.grade_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.user_source1 == POPUPEntityObject.grade_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].user_source1 = POPUPEntityObject.grade_code;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].user_source1 != POPUPEntityObject.grade_code)
                        {
                            ItemsEntity[dgSelectedIndexItem].user_source1 = POPUPEntityObject.grade_code;
                        }
                    }
                }
                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
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
        private void InsertMCDestinationGrade(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M045_P POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.GradeDetails.Where(x => x.grade_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M045_P>().Count()>0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M045_P>().ToList()[0];
                }
                #endregion
                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.para5 == POPUPEntityObject.grade_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.para5 == POPUPEntityObject.grade_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].para5 = POPUPEntityObject.grade_code;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].para5 != POPUPEntityObject.grade_code)
                        {
                            ItemsEntity[dgSelectedIndexItem].para5 = POPUPEntityObject.grade_code;
                        }
                    }
                }
                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
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
        private void InsertMCSourceUnit(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section
                
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {                
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UOMDetails.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count()>0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }
                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                        {
                            ItemsEntity[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        }
                    }
                }
                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
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
        private void InsertMCDestinationUnit(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M038_B_P POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {

                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.UOMDetails.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count()>0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) 
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.ri_unit_cd == POPUPEntityObject.unit_code).FirstOrDefault();
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.ri_unit_cd == POPUPEntityObject.unit_code).FirstOrDefault()); 

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) 
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) 
                        {
                            ItemsEntity[dgSelectedIndexItem].ri_unit_cd = POPUPEntityObject.unit_code;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].ri_unit_cd != POPUPEntityObject.unit_code)
                        {
                            ItemsEntity[dgSelectedIndexItem].ri_unit_cd = POPUPEntityObject.unit_code;
                        }
                    }
                }
                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
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
        private void InsertMCSourceInk(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M006_P POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {

                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.InkDetails.Where(x => x.ink.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M006_P>().Count()>0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M006_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.para1 == POPUPEntityObject.ink).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.para1 == POPUPEntityObject.ink).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].para1 = POPUPEntityObject.ink;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].para1 != POPUPEntityObject.ink)
                        {
                            ItemsEntity[dgSelectedIndexItem].para1 = POPUPEntityObject.ink;
                        }
                    }
                }
                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
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
        private void InsertMCSourceIld(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ZADM_M007_P POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {

                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.IldDetails.Where(x => x.ild.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ZADM_M007_P>().Count()>0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ZADM_M007_P>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null) 
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.para2 == POPUPEntityObject.ild).FirstOrDefault(); 
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.para2 == POPUPEntityObject.ild).FirstOrDefault()); 

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem) 
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].para2 = POPUPEntityObject.show_ild;
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].para2 != POPUPEntityObject.show_ild)
                        {
                            ItemsEntity[dgSelectedIndexItem].para2 = POPUPEntityObject.show_ild;
                        }
                    }
                }
                #region Clear Empty Row
                MM_T001_A newObj = new MM_T001_A();
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
        private void InsertMCDestinationItem(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M022_POPUP POPUPEntityObject = null;
                dgSelectedIndexItem = dgSelectedIndexItem;
                #region Command Parameter Read Section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.RMItemDetails.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M022_POPUP>().Count()>0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_POPUP>().ToList()[0];
                }

                #endregion

                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = ItemsEntity.Where(X => X.ri_item == POPUPEntityObject.ild).FirstOrDefault();
                    int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.ri_item == POPUPEntityObject.ild).FirstOrDefault());

                    if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].ri_item = POPUPEntityObject.ItemCode;
                            ItemsEntity[dgSelectedIndexItem].ri_unit_cd = "KG";
                            ItemsEntity[dgSelectedIndexItem].para4 = "Local";
                            ItemsEntity[dgSelectedIndexItem].mat_con = "New";
                        }
                        else if (ItemsEntity[dgSelectedIndexItem].ri_item != POPUPEntityObject.ItemCode)
                        {
                            ItemsEntity[dgSelectedIndexItem].ri_item = POPUPEntityObject.ItemCode;
                            ItemsEntity[dgSelectedIndexItem].ri_unit_cd = "KG";
                            ItemsEntity[dgSelectedIndexItem].para4 = "Local";
                            ItemsEntity[dgSelectedIndexItem].mat_con = "New";
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
        private void InsertMCMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M030_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.MakeDetails.Where(x => x.parametervalue.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M030_P>().Count()>0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M030_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }
            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(X => X.para3 == POPUPEntityObject.parametervalue).FirstOrDefault();
                int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.para3 == POPUPEntityObject.parametervalue).FirstOrDefault());

                if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        ItemsEntity[dgSelectedIndexItem].para3 = POPUPEntityObject.parametervalue;
                    }
                    else if (ItemsEntity[dgSelectedIndexItem].para3 != POPUPEntityObject.parametervalue)
                    {
                        ItemsEntity[dgSelectedIndexItem].para3 = POPUPEntityObject.parametervalue;
                    }
                }
            }
        }
        private void InsertMCType(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M030_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.TypeDetails.Where(x => x.parametervalue.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M030_P>().Count()>0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M030_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }
            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(X => X.para4 == POPUPEntityObject.parametervalue).FirstOrDefault();
                int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.para4 == POPUPEntityObject.parametervalue).FirstOrDefault());

                if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        ItemsEntity[dgSelectedIndexItem].para4 = POPUPEntityObject.parametervalue;
                    }
                    else if (ItemsEntity[dgSelectedIndexItem].para4 != POPUPEntityObject.parametervalue)
                    {
                        ItemsEntity[dgSelectedIndexItem].para4 = POPUPEntityObject.parametervalue;
                    }
                }
            }
        }
        private void InsertMCMaterialCondition(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            ADM_M030_P POPUPEntityObject = null;
            try
            {
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.MaterialConditionDetails.Where(x => x.parametervalue.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex)
                        {
                        }
                    }
                }
                else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M030_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M030_P>().ToList()[0];
                }
            }
            catch (Exception ex) { }
            if (POPUPEntityObject != null)
            {
                var InputValueIfExists = ItemsEntity.Where(X => X.mat_con == POPUPEntityObject.parametervalue).FirstOrDefault();
                int IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.mat_con == POPUPEntityObject.parametervalue).FirstOrDefault());

                if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                {
                    if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        ItemsEntity[dgSelectedIndexItem].mat_con = POPUPEntityObject.parametervalue;
                    }
                    else if (ItemsEntity[dgSelectedIndexItem].mat_con != POPUPEntityObject.parametervalue)
                    {
                        ItemsEntity[dgSelectedIndexItem].mat_con = POPUPEntityObject.parametervalue;
                    }
                }
            }
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            string Request = "";
            string ParametersStringValue = "";
            MM_T001Flip ParameterEntityObject = null;
            MasterEntity = new MM_T001();
            ItemsEntity = new ObservableCollection<MM_T001_A>();
            if (((IEnumerable)ParameterObject).Cast<MM_T001Flip>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<MM_T001Flip>().ToList()[0];
                Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.doc_no;
                NewRecord = false;
                GridEditable = false;
                MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MC_MM_T001>(MCTemp, Request, "ProductConversion_Essem", "SCM", "LoadDocumentByDocumentNumber", 0, "");
                MasterEntity = MCTemp.MasterEntity[0];
                ItemsEntity = MCTemp.ItemsEntity;
                MasterEntity.ts_code = ts_code_vm;
                SetBusinessEntitiesAfterLoad(ParametersStringValue, "Save");
                SelectedTabControlIndex = 0;
                PostDateEditable = false;
                AttachmentCollection = MCTemp.AttachmentData;
                if (MCTemp.AttachmentData != null)
                {
                    AttachmentCollection = MCTemp.AttachmentData;
                }
                else
                {
                    MCTemp.AttachmentData = new List<COM_T003>();
                }
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

        #region Abstract MEthods
        protected override void OnCreateAction(InquiryActionResult<MM_T001> result)
        {
            NewRecord = true;
            PostDateEditable = true;
            GridEditable = true;
            MasterEntity = new MM_T001();
            MasterEntity.mov_tp = "126";
            MC.ItemsEntity = new ObservableCollection<MM_T001_A>();
            MasterEntity.ValidateAsync().Wait();
            ItemsEntity.Clear();
            FlipDataGridCollection.Refresh();
            DefaultValues();
            MasterEntity.post_date = DateTime.Now;
        }

        protected override void OnDiscardAction(InquiryActionResult<MM_T001> result)
        {
            MasterEntity.CancelEdit();
            MasterEntity = new MM_T001();
        }
        
        protected override void OnFevoriteAction(InquiryActionResult<MM_T001> result)
        {    
        }

        protected override void OnFlipAction(InquiryActionResult<MM_T001> result)
        {
        }

        protected override void OnHelpAction(InquiryActionResult<MM_T001> result)
        {  
        }

        protected override void OnPrintAction(InquiryActionResult<MM_T001> result)
        {
            try
            {
                {
                    string Request = "LoadDocumentByDocumentNumber" + "!@" + MasterEntity.doc_no;
                    Temp = Repository_Temp.GetDataWithReturnDomainObject<MC_MM_T001>(Temp, Request, "ProductConversion_Essem", "SCM", Request, 0, "");

                    object[] objDataSource = new object[4];
                    string[] objDataSourceName = new string[4];
                    objDataSource[0] = Temp.MasterEntity;
                    objDataSource[1] = Temp.ItemsEntity;

                    List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                    var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                    objDataSource[2] = CmpResult;

                    List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                    var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                    objDataSource[3] = Result;

                    objDataSourceName[0] = "dsMasterData";
                    objDataSourceName[1] = "dsItemData";
                    objDataSourceName[2] = "dsCompany";
                    objDataSourceName[3] = "dsLocation";

                    ReportManager ReportManager = new ReportManager();
                    ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\SCM\\MaterialConversion.rdlc", getParametersList(), "");
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
        private Dictionary<string, string> getParametersList()
        {
            Dictionary<string, string> result = new Dictionary<string, string>();
            try
            {
                result.Add("prepare_by", AppSessionState.Name);
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
        protected override void OnRemoveAction(InquiryActionResult<MM_T001> result)
        {
            
            //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //showMessageService.ButtonSetup = DialogButton.Ok;
            //showMessageService.Caption = "Delete Changes";
            //showMessageService.Text = String.Format("This record will be Deleted forever '{0}'",this.Title);
            //if (showMessageService.ShowMessage() == DialogResult.Ok)
            //{
            //    this.MasterEntity.EndEdit();
            //    string response = repository.Delete(MasterEntity.doc_no, "ProductConversion_Essem", "SCM");
            //    MasterEntity = new MM_T001();
            //    MasterEntity.mov_tp = "126";
            //    ItemsEntity = new ObservableCollection<MM_T001_A>();
            //    NewRecord = true;
            //    PostDateEditable = true;
            //    GridEditable = true;
            //    parameter = false;

            //    FlipDataGridCollection.Refresh();
            //}
        }

        protected override void OnSaveAction(InquiryActionResult<MM_T001> result)
        {
            try
            {
                ObjectSerializationService obj = new ObjectSerializationService();

                this.MasterEntity.EndEdit();
                if (Validation() == true)
                {
                    MasterEntity.XmlDataDocument_MM_T001_A = obj.ObjectToXML(ItemsEntity);
                    if (NewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<MM_T001>(MasterEntity, "ProductConversion_Essem", "SCM");
                    }


                    else if (NewRecord == false)
                    {
                        MasterEntity = repository.UpdateWithReturnDomainObject<MM_T001>(MasterEntity, "ProductConversion_Essem", "SCM");
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");
                    PostDateEditable = false;
                    GridEditable = false;
                    if (MasterEntity.doc_no != null && MasterEntity.doc_no != "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Data Saved Successfully");
                        showMessageService.ShowMessage();

                        NewRecord = false;
                        parameter = false;
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
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.doc_no))
            {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MCTemp.AttachmentData, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<MM_T001> result)
        {
            throw new NotImplementedException();
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            MasterEntity.ts_code = ts_code_vm;
            if (MasterEntity.XmlDataDocument_MM_T001_A != null)
            {
                MC.ItemsEntity = (ObservableCollection<MM_T001_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_MM_T001_A, MC.ItemsEntity);
                ItemsEntity.Clear();
                ItemsEntity = MC.ItemsEntity;
            }
            else
            {
                MC.ItemsEntity = new ObservableCollection<MM_T001_A>();
            }

            if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
            {
                MC.DocumentDataFlipGrid = (List<MM_T001Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                FlipDataGridCollection.Refresh();
            }
        }
        #endregion

        #region Filters

        #region Filter For Flip Grid Data
        private string _FilterStringFlipGridData;
        public string FilterStringFlipGridData
        {
            get { return _FilterStringFlipGridData; }
            set
            {
                _FilterStringFlipGridData = value;
                RaisePropertyChanged("FilterStringFlipGridData");
                Filter_FlipGrid();
            }
        }
        private void Filter_FlipGrid()
        {
            if (_FlipDataGridCollection != null)
            {
                _FlipDataGridCollection.Refresh();
            }
        }
        public bool Filter_FlipGridData(object obj)
        {
            var data = obj as MM_T001Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringFlipGridData))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.mov_tp != null && data.mov_tp.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filter For Movement Type
        private string _FilterStringMovementType;
        public string FilterStringMovementType
        {
            get { return _FilterStringMovementType; }
            set
            {
                _FilterStringMovementType = value;
                RaisePropertyChanged("FilterStringMovementType");
                Filter_MovementType();
            }
        }
        private void Filter_MovementType()
        {
            if (_MovementTypeCollection != null)
            {
                _MovementTypeCollection.Refresh();
            }
        }
        public bool Filter_MovementType(object obj)
        {
            var data = obj as MM_M004_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringMovementType))
                {
                    return (data.mov_tp != null && data.mov_tp.ToString().ToLower().Contains(_FilterStringMovementType.ToLower())) ||
                           (data.mov_tp_name != null && data.mov_tp_name.ToString().ToLower().Contains(_FilterStringMovementType.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filter For Ink Data

        private string _FilterStringInk;
        public string FilterStringInk
        {
            get { return _FilterStringInk; }
            set
            {
                _FilterStringInk = value;
                RaisePropertyChanged("FilterStringInk");
                Filter_Ink();
            }
        }
        private void Filter_Ink()
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
                if (!string.IsNullOrEmpty(FilterStringInk))
                {
                    return (data.ink != null && data.ink.ToString().ToLower().Contains(_FilterStringInk.ToLower())) ||
                           (data.desc != null && data.desc.ToString().ToLower().Contains(_FilterStringInk.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filter For Ild
        private string _FilterStringIld;
        public string FilterStringIld
        {
            get { return _FilterStringIld; }
            set
            {
                _FilterStringIld = value;
                RaisePropertyChanged("FilterStringIld");
                Filter_Ild();
            }
        }
        private void Filter_Ild()
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
                if (!string.IsNullOrEmpty(FilterStringIld))
                {
                    return (data.ild != null && data.ild.ToString().ToLower().Contains(_FilterStringIld.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filter For Grade
        private string _FilterStringGrade;
        public string FilterStringGrade
        {
            get { return _FilterStringGrade; }
            set
            {
                _FilterStringGrade = value;
                RaisePropertyChanged("FilterStringGrade");
                Filter_Grade();
            }
        }
        private void Filter_Grade()
        {
            if (_GradeCollection != null)
            {
                _GradeCollection.Refresh();
            }
        }
        public bool Filter_Grade(object obj)
        {
            var data = obj as ADM_M045_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringGrade))
                {
                    return (data.grade_code != null && data.grade_code.ToString().ToLower().Contains(_FilterStringGrade.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter Source Item
        private string _FilterStringSourceItem;
        public string FilterStringSourceItem
        {
            get { return _FilterStringSourceItem; }
            set
            {
                _FilterStringSourceItem = value;
                RaisePropertyChanged("FilterStringSourceItem");
                Filter_Item();
            }
        }
        private void Filter_Item()
        {
            if (_SourceItemCollection != null)
            {
                _SourceItemCollection.Refresh();
            }
        }
        public bool Filter_Item(object obj)
        {
            var data = obj as ADM_M022_POPUP;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringSourceItem))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(FilterStringSourceItem.ToLower())) ||
                        (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(FilterStringSourceItem.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter For RM Item
        private string _FilterStringDestinationItem;
        public string FilterStringDestinationItem
        {
            get { return _FilterStringDestinationItem; }
            set
            {
                _FilterStringDestinationItem = value;
                RaisePropertyChanged("FilterStringDestinationItem");
                Filter_DestinationItem();
            }
        }
        private void Filter_DestinationItem()
        {
            if (_RMItemCollection != null)
            {
                _RMItemCollection.Refresh();
            }
        }
        public bool Filter_DestinationItem(object obj)
        {
            var data = obj as ADM_M022_POPUP;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringDestinationItem))
                {
                    return (data.ItemCode != null && data.ItemCode.ToString().ToLower().Contains(_FilterStringDestinationItem.ToLower())) ||
                        (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_FilterStringDestinationItem.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filter For Unit

        private string _FilterStringUnit;
        public string FilterStringUnit
        {
            get { return _FilterStringUnit; }
            set
            {
                _FilterStringUnit = value;
                RaisePropertyChanged("FilterStringUnit");
                Filter_Unit();
            }
        }
        private void Filter_Unit()
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
                if (!string.IsNullOrEmpty(FilterStringUnit))
                {
                    return (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_FilterStringUnit.ToLower())) ||
                        (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_FilterStringUnit.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter For Make
        private string _FilterStringMake;
        public string FilterStringMake
        {
            get { return _FilterStringMake; }
            set
            {
                _FilterStringMake = value;
                RaisePropertyChanged("FilterStringMake");
                Filter_Make();
            }
        }
        private void Filter_Make()
        {
            if (_MakeCollection != null)
            {
                _MakeCollection.Refresh();
            }
        }
        public bool Filter_Make(object obj)
        {
            var data = obj as ADM_M030_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringMake))
                {
                    return (data.parametervalue != null && data.parametervalue.ToString().ToLower().Contains(_FilterStringMake.ToLower())) ||
                           (data.para_code != null && data.para_code.ToString().ToLower().Contains(_FilterStringMake.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter For Type
        private string _FilterStringType;
        public string FilterStringType
        {
            get { return _FilterStringType; }
            set
            {
                _FilterStringType = value;
                RaisePropertyChanged("FilterStringType");
                Filter_Type();
            }
        }
        private void Filter_Type()
        {
            if (_TypeCollection != null)
            {
                _TypeCollection.Refresh();
            }
        }
        public bool Filter_Type(object obj)
        {
            var data = obj as ADM_M030_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringType))
                {
                    return (data.parametervalue != null && data.parametervalue.ToString().ToLower().Contains(_FilterStringType.ToLower())) ||
                           (data.para_code != null && data.para_code.ToString().ToLower().Contains(_FilterStringType.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        #region Filter For Material Condition
        private string _FilterStringMaterialCondition;
        public string FilterStringMaterialCondition
        {
            get { return _FilterStringMaterialCondition; }
            set
            {
                _FilterStringMaterialCondition = value;
                RaisePropertyChanged("FilterStringMaterialCondition");
                Filter_MaterialCondition();
            }
        }
        private void Filter_MaterialCondition()
        {
            if (_MaterialConditionCollection != null)
            {
                _MaterialConditionCollection.Refresh();
            }
        }
        public bool Filter_MaterialCondition(object obj)
        {
            var data = obj as ADM_M030_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringMaterialCondition))
                {
                    return (data.parametervalue != null && data.parametervalue.ToString().ToLower().Contains(_FilterStringMaterialCondition.ToLower())) ||
                           (data.para_code != null && data.para_code.ToString().ToLower().Contains(_FilterStringMaterialCondition.ToLower()));
                }
                return true;
            }
            return false;
        }

       


        #endregion

        #endregion
    }
}
