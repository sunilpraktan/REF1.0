using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
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
using Reflection.BusinessEntity.ENG;
using Reflection.BusinessEntity.ADM;
using Reflection.Presentation.Common;
using System.IO;
using System.Reflection;
using GalaSoft.MvvmLight.Ioc;
using Reflection.Presentation.Core.VirtualDesktops;
using Reflection.BusinessEntity.GEN;
using System.Windows.Forms;

namespace Reflection.Modules.ENG.ViewModels
{
    public class ENG_T011_VM : WorkspaceViewModel<ENG_T005>
    {
        bool NewRecord = true;

        WebServiceRepository<ENG_T005> REPO = new WebServiceRepository<ENG_T005>();
        WebServiceRepository<MC_ENG_BE> REPO_MC = new WebServiceRepository<MC_ENG_BE>();
        WebServiceRepository<MC_ENG_BE> REPO_MC_TEMP = new WebServiceRepository<MC_ENG_BE>();
        ObjectSerializationService obj = new ObjectSerializationService();

        #region Enumerables & AutoSuggest Initialization

        private IEnumerable _ITEM_LIST;
        public IEnumerable ITEM_LIST
        {
            get { return _ITEM_LIST; }
            set
            {
                _ITEM_LIST = value;

                RaisePropertyChanged("ITEM_LIST");
            }
        }

        private IEnumerable _VCHAR_LIST;
        public IEnumerable VCHAR_LIST
        {
            get { return _VCHAR_LIST; }
            set
            {
                _VCHAR_LIST = value;
                RaisePropertyChanged("VCHAR_LIST");
            }
        }
        private IEnumerable _DEPT_LIST;
        public IEnumerable DEPT_LIST
        {
            get { return _DEPT_LIST; }
            set
            {
                _DEPT_LIST = value;

                RaisePropertyChanged("DEPT_LIST");
            }
        }
        private IEnumerable _PROFILE_LIST;
        public IEnumerable PROFILE_LIST
        {
            get { return _PROFILE_LIST; }
            set
            {
                _PROFILE_LIST = value;

                RaisePropertyChanged("PROFILE_LIST");
            }
        }
        private IEnumerable _METHOD_LIST;
        public IEnumerable METHOD_LIST
        {
            get { return _METHOD_LIST; }
            set
            {
                _METHOD_LIST = value;

                RaisePropertyChanged("METHOD_LIST");
            }
        }
        private IEnumerable _CHAR_GROUP_LIST;
        public IEnumerable CHAR_GROUP_LIST
        {
            get { return _CHAR_GROUP_LIST; }
            set
            {
                _CHAR_GROUP_LIST = value;

                RaisePropertyChanged("CHAR_GROUP_LIST");
            }
        }
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(ENG_T011_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

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

                    if (SourceName == "wc_code")
                    {AS_DEFAULT = AS_WORK_CENTER;}
                    else if (SourceName == "control_key")
                    { AS_DEFAULT = AS_CONTROL_KEY; }
                    else if (SourceName == "unit_code")
                    { AS_DEFAULT = AS_UOM; }
                    else if (SourceName == "op_code")
                    { AS_DEFAULT = AS_OPERATION; }
                   
                    if (SourceName == "char_code")
                    { AS_DEFAULT1 = AS_CHAR; }
                    else if (SourceName == "insp_method")
                    { AS_DEFAULT1 = AS_INSP_METHOD; }
                    else if (SourceName == "samp_pro_char")
                    { AS_DEFAULT1 = AS_PROCEDURE; }
                    else if (SourceName == "sample_uom")
                    { AS_DEFAULT1 = AS_QUOM; }
                    else if (SourceName == "insp_qual")
                    { AS_DEFAULT1 = AS_QUALIFICATION; }

                    //if (SourceName == "para_type")
                    //{ AS_DEFAULT2 = AS_PARA_TYPE; }
                    //else if (SourceName == "gc_or_ss")
                    //{ AS_DEFAULT2 = AS_PROFILE; }
                    ////else if (SourceName == "inspector")
                    ////{ AS_DEFAULT2 = AS_EMPLOYEE; }

                    if (SourceName == "item_code_R")
                    { AS_DEFAULT3 = AS_COMPONANT; }
                    else if (SourceName == "unit_code_R")
                    { AS_DEFAULT3 = AS_UOM; }

                  
                }
            }
        }
        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }

        private AutoSuggestTextViewModel<dynamic> _AS_DEFAULT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DEFAULT
        {
            get { return _AS_DEFAULT; }
            set
            {
                if (_AS_DEFAULT != value)
                {
                    _AS_DEFAULT = value; RaisePropertyChanged("AS_DEFAULT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_DEFAULT1 { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DEFAULT1
        {
            get { return _AS_DEFAULT1; }
            set
            {
                if (_AS_DEFAULT1 != value)
                {
                    _AS_DEFAULT1 = value; RaisePropertyChanged("AS_DEFAULT1");
                }
            }
        }
        //private AutoSuggestTextViewModel<dynamic> _AS_DEFAULT2 { get; set; }
        //public AutoSuggestTextViewModel<dynamic> AS_DEFAULT2
        //{
        //    get { return _AS_DEFAULT2; }
        //    set
        //    {
        //        if (_AS_DEFAULT2 != value)
        //        {
        //            _AS_DEFAULT2 = value; RaisePropertyChanged("AS_DEFAULT2");
        //        }
        //    }
        //}
        private AutoSuggestTextViewModel<dynamic> _AS_DEFAULT3 { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_DEFAULT3
        {
            get { return _AS_DEFAULT3; }
            set
            {
                if (_AS_DEFAULT3 != value)
                {
                    _AS_DEFAULT3 = value; RaisePropertyChanged("AS_DEFAULT3");
                }
            }
        }
        
        private AutoSuggestTextViewModel<dynamic> _AS_COMPANY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_COMPANY
        {
            get { return _AS_COMPANY; }
            set
            {
                if (_AS_COMPANY != value)
                {
                    _AS_COMPANY = value; RaisePropertyChanged("AS_COMPANY");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_LOCATION { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_LOCATION
        {
            get { return _AS_LOCATION; }
            set
            {
                if (_AS_LOCATION != value)
                {
                    _AS_LOCATION = value; RaisePropertyChanged("AS_LOCATION");
                }
            }
        }
        
        private AutoSuggestTextViewModel<dynamic> _AS_USAGE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_USAGE
        {
            get { return _AS_USAGE; }
            set
            {
                if (_AS_USAGE != value)
                {
                    _AS_USAGE = value; RaisePropertyChanged("AS_USAGE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_WORK_CENTER { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_WORK_CENTER
        {
            get { return _AS_WORK_CENTER; }
            set
            {
                if (_AS_WORK_CENTER != value)
                {
                    _AS_WORK_CENTER = value; RaisePropertyChanged("AS_WORK_CENTER");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_BOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_BOM
        {
            get { return _AS_BOM; }
            set
            {
                if (_AS_BOM != value)
                {
                    _AS_BOM = value; RaisePropertyChanged("AS_BOM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_ITEM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_ITEM
        {
            get { return _AS_ITEM; }
            set
            {
                if (_AS_ITEM != value)
                {
                    _AS_ITEM = value; RaisePropertyChanged("AS_ITEM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_COMPONANT { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_COMPONANT
        {
            get { return _AS_COMPONANT; }
            set
            {
                if (_AS_COMPONANT != value)
                {
                    _AS_COMPONANT = value; RaisePropertyChanged("AS_COMPONANT");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_UOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_UOM
        {
            get { return _AS_UOM; }
            set
            {
                if (_AS_UOM != value)
                {
                    _AS_UOM = value; RaisePropertyChanged("AS_UOM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_QUOM { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_QUOM
        {
            get { return _AS_QUOM; }
            set
            {
                if (_AS_QUOM != value)
                {
                    _AS_QUOM = value; RaisePropertyChanged("AS_QUOM");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_OPERATION { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_OPERATION
        {
            get { return _AS_OPERATION; }
            set
            {
                if (_AS_OPERATION != value)
                {
                    _AS_OPERATION = value; RaisePropertyChanged("AS_OPERATION");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_CONTROL_KEY { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CONTROL_KEY
        {
            get { return _AS_CONTROL_KEY; }
            set
            {
                if (_AS_CONTROL_KEY != value)
                {
                    _AS_CONTROL_KEY = value; RaisePropertyChanged("AS_CONTROL_KEY");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_INSP_METHOD { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_INSP_METHOD
        {
            get { return _AS_INSP_METHOD; }
            set
            {
                if (_AS_INSP_METHOD != value)
                {
                    _AS_INSP_METHOD = value; RaisePropertyChanged("AS_INSP_METHOD");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_PROCEDURE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PROCEDURE
        {
            get { return _AS_PROCEDURE; }
            set
            {
                if (_AS_PROCEDURE != value)
                {
                    _AS_PROCEDURE = value; RaisePropertyChanged("AS_PROCEDURE");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_QUALIFICATION { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_QUALIFICATION
        {
            get { return _AS_QUALIFICATION; }
            set
            {
                if (_AS_QUALIFICATION != value)
                {
                    _AS_QUALIFICATION = value; RaisePropertyChanged("AS_QUALIFICATION");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_CHAR { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_CHAR
        {
            get { return _AS_CHAR; }
            set
            {
                if (_AS_CHAR != value)
                {
                    _AS_CHAR = value; RaisePropertyChanged("AS_CHAR");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_EMPLOYEE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_EMPLOYEE
        {
            get { return _AS_EMPLOYEE; }
            set
            {
                if (_AS_EMPLOYEE != value)
                {
                    _AS_EMPLOYEE = value; RaisePropertyChanged("AS_EMPLOYEE");
                }
            }
        }
        //private AutoSuggestTextViewModel<dynamic> _AS_PROFILE { get; set; }
        //public AutoSuggestTextViewModel<dynamic> AS_PROFILE
        //{
        //    get { return _AS_PROFILE; }
        //    set
        //    {
        //        if (_AS_PROFILE != value)
        //        {
        //            _AS_PROFILE = value; RaisePropertyChanged("AS_PROFILE");
        //        }
        //    }
        //}
        private AutoSuggestTextViewModel<dynamic> _AS_PARA_TYPE { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_PARA_TYPE
        {
            get { return _AS_PARA_TYPE; }
            set
            {
                if (_AS_PARA_TYPE != value)
                {
                    _AS_PARA_TYPE = value; RaisePropertyChanged("AS_PARA_TYPE");
                }
            }
        }

        #endregion

        #region Relay Command Decleration

        public RelayCommand<object> cmdExecuteVC { get; private set; } // This command will create dependacy char spec as per classification.
        public RelayCommand<object> cmdSC_ENG_T005_R { get; private set; }
        public RelayCommand<object> cmdSC_ENG_T005_A { get; private set; }
        public RelayCommand<object> cmdSC_ENG_T005_B { get; private set; }
        public RelayCommand<object> cmdSC_ENG_T005_C { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> AssignmentEntityRowDeleteCommand { get; private set; }
        public RelayCommand<object> InspCharEntityRowDeleteCommand { get; private set; }
        public RelayCommand<object> OperationEntityRowDeleteCommand { get; private set; }
        public RelayCommand<object> SelectedSetEntityRowDeleteCommand { get; private set; }
        public RelayCommand<object> cmdInsertChar { get; private set; }
        public RelayCommand<object> cmdInsertComponant { get; private set; }
        public RelayCommand<object> cmdLoadDocumentByDocNo { get; private set; }
        public GalaSoft.MvvmLight.Command.RelayCommand CmdCheckBoxChange { get; private set; }
        public RelayCommand<object> CmdProfile { get; private set; }
        public RelayCommand<object> CmdParaType { get; private set; }
        public RelayCommand<object> cmdInsertOperation { get; private set; }
        public RelayCommand<object> cmdInsertLocationOP { get; private set; }
        public RelayCommand<object> cmdLoadBackFlip { get; private set; }
        public RelayCommand<object> cmdInsertBOM { get; private set; }
        public RelayCommand<object> cmdOperationAttachments { get; private set; }
        //public RelayCommand<object> cmdInsertCompany { get; private set; }
        public RelayCommand<object> cmdStyleFormating { get; private set; }

        #endregion

        #region Variable Decleration
        private int _TabIndexItem;
        public int TabIndexItem
        {
            get { return _TabIndexItem; }
            set
            {
                if (_TabIndexItem != value)
                {
                    _TabIndexItem = value;
                    RaisePropertyChanged("TabIndexItem");
                }
            }
        }
        public string task_list_type_vm { get; set; }
        public string ts_code_vm { get; set; }
        public string doc_cat_vm { get; set; }
        public string doc_no_vm { get; set; }
        private bool EntityChangeEnable = true;
        IShowMessageViewService sms;
        private bool _Copy;
        public bool Copy
        {
            get { return _Copy; }
            set
            {
                if (_Copy != value)
                {
                    _Copy = value; RaisePropertyChanged("Copy");
                }
            }
        }

        private ENG_T005 _MasterEntity;
        public ENG_T005 MasterEntity
        {
            get { return _MasterEntity; }
            set
            {
                if (_MasterEntity != value)
                {
                    _MasterEntity = value; RaisePropertyChanged("MasterEntity");
                }
            }
        }

        private ObservableCollection<ENG_T005_A> _OperationEntity;
        public ObservableCollection<ENG_T005_A> OperationEntity
        {
            get { return _OperationEntity; }
            set
            {
                if (_OperationEntity != value)
                {
                    _OperationEntity = value;
                    OperationEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForOperationEntity);
                    RaisePropertyChanged("OperationEntity");
                }
            }
        }

        private ObservableCollection<ENG_T005_R> _ComponantEntity;
        public ObservableCollection<ENG_T005_R> ComponantEntity
        {
            get { return _ComponantEntity; }
            set
            {
                if (_ComponantEntity != value)
                {
                    _ComponantEntity = value;
                    ComponantEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForComponantEntity);
                    RaisePropertyChanged("ComponantEntity");
                }
            }
        }

        private ObservableCollection<ENG_T005_B> _CharEntity;
        public ObservableCollection<ENG_T005_B> CharEntity
        {
            get { return _CharEntity; }
            set
            {
                if (_CharEntity != value)
                {
                    _CharEntity = value;
                    CharEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForCharEntity);
                    RaisePropertyChanged("CharEntity");
                }
            }
        }

        private ObservableCollection<ENG_T005_C> _SelectedSetEntity;
        public ObservableCollection<ENG_T005_C> SelectedSetEntity
        {
            get { return _SelectedSetEntity; }
            set
            {
                if (_SelectedSetEntity != value)
                {
                    _SelectedSetEntity = value;
                    SelectedSetEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSelectedSetEntity);
                    RaisePropertyChanged("SelectedSetEntity");
                }
            }
        }

        private ObservableCollection<ENG_T005_M> _AssignmentEntity;
        public ObservableCollection<ENG_T005_M> AssignmentEntity
        {
            get { return _AssignmentEntity; }
            set
            {
                if (_AssignmentEntity != value)
                {
                    _AssignmentEntity = value;
                    AssignmentEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForAssignmentEntity);
                    RaisePropertyChanged("AssignmentEntity");
                }
            }
        }

        private ENG_T005_R _ENG_T005_R_OBJ;
        public ENG_T005_R ENG_T005_R_OBJ
        {
            get
            {
                return _ENG_T005_R_OBJ;
            }
            set
            {
                if (_ENG_T005_R_OBJ != value)
                {
                    _ENG_T005_R_OBJ = value;
                    RaisePropertyChanged("ENG_T005_R_OBJ");
                }
            }
        }
        private ENG_T005_A _ENG_T005_A_OBJ;
        public ENG_T005_A ENG_T005_A_OBJ
        {
            get
            {
                return _ENG_T005_A_OBJ;
            }
            set
            {
                if (_ENG_T005_A_OBJ != value)
                {
                    _ENG_T005_A_OBJ = value;
                    RaisePropertyChanged("ENG_T005_A_OBJ");
                    FilterCharactristics();
                    FilterSelectedSetDataGrid();
                    FilterComponants();
                }
            }
        }
        private ENG_T005_B _ENG_T005_B_OBJ;
        public ENG_T005_B ENG_T005_B_OBJ
        {
            get
            {
                return _ENG_T005_B_OBJ;
            }
            set
            {
                if (_ENG_T005_B_OBJ != value)
                {
                    _ENG_T005_B_OBJ = value;
                    RaisePropertyChanged("ENG_T005_B_OBJ");
                    FilterSelectedSetDataGrid();
                }
            }
        }
        private ENG_T005_C _ENG_T005_C_OBJ;
        public ENG_T005_C ENG_T005_C_OBJ
        {
            get
            {
                return _ENG_T005_C_OBJ;
            }
            set
            {
                if (_ENG_T005_C_OBJ != value)
                {
                    _ENG_T005_C_OBJ = value;
                    RaisePropertyChanged("ENG_T005_C_OBJ");
                }
            }
        }

        private STD_REQ_PARA_BE _REQ_PARA_OBJ;
        public STD_REQ_PARA_BE REQ_PARA_OBJ
        {
            get
            {
                return _REQ_PARA_OBJ;
            }
            set
            {
                if (_REQ_PARA_OBJ != value)
                {
                    _REQ_PARA_OBJ = value;
                    RaisePropertyChanged(nameof(REQ_PARA_OBJ));
                }
            }
        }

        private STD_LIST_BE _STD_LIST_OBJ;
        public STD_LIST_BE STD_LIST_OBJ
        {
            get
            {
                return _STD_LIST_OBJ;
            }
            set
            {
                if (_STD_LIST_OBJ != value)
                {
                    _STD_LIST_OBJ = value;
                    RaisePropertyChanged(nameof(STD_LIST_OBJ));
                }
            }
        }

        private int _dgIndex_R;
        public int dgIndex_R
        {
            get { return _dgIndex_R; }
            set
            {
                if (_dgIndex_R != value)
                {
                    _dgIndex_R = value;
                    RaisePropertyChanged("dgIndex_R");
                }
            }
        }

        private int _dgIndex_A;
        public int dgIndex_A
        {
            get { return _dgIndex_A; }
            set
            {
                if (_dgIndex_A != value)
                {
                    _dgIndex_A = value;
                    RaisePropertyChanged("dgIndex_A");
                    //FilterCharactristics();
                    //FilterComponants();
                }
            }
        }

        private int _dgIndex_B;
        public int dgIndex_B
        {
            get { return _dgIndex_B; }
            set
            {
                if (_dgIndex_B != value)
                {
                    _dgIndex_B = value;
                    RaisePropertyChanged("dgIndex_B");
                }
            }
        }

        private int _dgIndex_C;
        public int dgIndex_C
        {
            get { return _dgIndex_C; }
            set
            {
                if (_dgIndex_C != value)
                {
                    _dgIndex_C = value;
                    RaisePropertyChanged("dgIndex_C");
                }
            }
        }

        private MC_ENG_BE _MC;
        public MC_ENG_BE MC
        {
            get { return _MC; }
            set { _MC = value; RaisePropertyChanged("MC"); }
        }

        private MC_ENG_BE _MC_TEMP;
        public MC_ENG_BE MC_TEMP
        {
            get { return _MC_TEMP; }
            set { _MC_TEMP = value; RaisePropertyChanged("MC_TEMP"); }
        }

        private ICollectionView _BACKFLIP_COLLECTION;
        public ICollectionView BACKFLIP_COLLECTION
        {
            get { return _BACKFLIP_COLLECTION; }
            set { _BACKFLIP_COLLECTION = value; RaisePropertyChanged("BACKFLIP_COLLECTION"); }
        }

        

        private ICollectionView _ItemCodeCollection;
        public ICollectionView ItemCodeCollection
        {
            get { return _ItemCodeCollection; }
            set { _ItemCodeCollection = value; RaisePropertyChanged("ItemCodeCollection"); }
        }

        private ICollectionView _ComponantCollection;
        public ICollectionView ComponantCollection
        {
            get { return _ComponantCollection; }
            set { _ComponantCollection = value; RaisePropertyChanged("ComponantCollection"); }
        }

        private ICollectionView _ParameterCollection;
        public ICollectionView ParameterCollection
        {
            get { return _ParameterCollection; }
            set { _ParameterCollection = value; RaisePropertyChanged("ParameterCollection"); }
        }

        public List<ADM_M003> _PlantList = new List<ADM_M003>();
        private List<ADM_M003> PlantList
        {
            get { return _PlantList; }
            set
            {
                if (_PlantList != value)
                {
                    _PlantList = value;
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

        private ICollectionView _CharactristicsCollection;
        public ICollectionView CharactristicsCollection
        {
            get { return _CharactristicsCollection; }
            set
            {
                _CharactristicsCollection = value;
                RaisePropertyChanged("CharactristicsCollection");
            }
        }

        private ICollectionView _SelectedDataGridCollection;
        public ICollectionView SelectedDataGridCollection
        {
            get { return _SelectedDataGridCollection; }
            set
            {
                _SelectedDataGridCollection = value;
                RaisePropertyChanged("SelectedDataGridCollection");
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

        #region Constructor
        public ENG_T011_VM(string ts_code, string doc_cat, string task_list_type) : base()
        {
            this.ts_code_vm = ts_code;
            this.task_list_type_vm = task_list_type;
            this.doc_cat_vm = doc_cat;
            MasterEntity = new ENG_T005();
            CharEntity = new ObservableCollection<ENG_T005_B>();
            OperationEntity = new ObservableCollection<ENG_T005_A>();
            ComponantEntity = new ObservableCollection<ENG_T005_R>();
            SelectedSetEntity = new ObservableCollection<ENG_T005_C>();
            AssignmentEntity = new ObservableCollection<ENG_T005_M>();
            MC = new MC_ENG_BE();
            MC_TEMP = new MC_ENG_BE();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            sms = this.GetViewService<IShowMessageViewService>();
            ENG_T005_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Operation);
            OperationEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForOperationEntity);
            ComponantEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForComponantEntity);
            CharEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForCharEntity);
            SelectedSetEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSelectedSetEntity);
            AssignmentEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForAssignmentEntity);
            

            REQ_PARA_OBJ.from_date = DateTime.Now;
            REQ_PARA_OBJ.to_date = DateTime.Now;

            CommandInitialisation();
        }
        public ENG_T011_VM(string ts_code, string doc_cat, string task_list_type, string doc_no) : base()
        {
            this.ts_code_vm = ts_code;
            this.task_list_type_vm = task_list_type;
            this.doc_cat_vm = doc_cat;
            this.doc_no_vm = doc_no;

            MasterEntity = new ENG_T005();
            CharEntity = new ObservableCollection<ENG_T005_B>();
            OperationEntity = new ObservableCollection<ENG_T005_A>();
            SelectedSetEntity = new ObservableCollection<ENG_T005_C>();
            ComponantEntity = new ObservableCollection<ENG_T005_R>();
            AssignmentEntity = new ObservableCollection<ENG_T005_M>();
            MC = new MC_ENG_BE();
            MC_TEMP = new MC_ENG_BE();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            sms = this.GetViewService<IShowMessageViewService>();
            ENG_T005_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Operation);
            OperationEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForOperationEntity);
            ComponantEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForComponantEntity);
            CharEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForCharEntity);
            SelectedSetEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSelectedSetEntity);
            AssignmentEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForAssignmentEntity);
            
            REQ_PARA_OBJ.from_date = DateTime.Now;
            REQ_PARA_OBJ.to_date = DateTime.Now;

            CommandInitialisation();
        }
        public ENG_T011_VM(string ts_code, STD_LIST_BE STD_OBJ) : base()
        {
            STD_LIST_OBJ = new STD_LIST_BE();
            STD_LIST_OBJ = STD_OBJ;

            MasterEntity = new ENG_T005();
            CharEntity = new ObservableCollection<ENG_T005_B>();
            OperationEntity = new ObservableCollection<ENG_T005_A>();
            SelectedSetEntity = new ObservableCollection<ENG_T005_C>();
            ComponantEntity = new ObservableCollection<ENG_T005_R>();
            AssignmentEntity = new ObservableCollection<ENG_T005_M>();
            MC = new MC_ENG_BE();
            MC_TEMP = new MC_ENG_BE();
            REQ_PARA_OBJ = new STD_REQ_PARA_BE();
            sms = this.GetViewService<IShowMessageViewService>();
            ENG_T005_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Operation);
            OperationEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForOperationEntity);
            ComponantEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForComponantEntity);
            CharEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForCharEntity);
            SelectedSetEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSelectedSetEntity);
            AssignmentEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForAssignmentEntity);

            REQ_PARA_OBJ.from_date = DateTime.Now;
            REQ_PARA_OBJ.to_date = DateTime.Now;

            CommandInitialisation();
        }
        #endregion

        #region User Define Methods

        #region CharEntity Methods
        private void CommandInitialisation()
        {
            #region Relay Command Initalization
            cmdExecuteVC = new RelayCommand<object>(items => { if (items == null) { return; } ExecuteVC(items); });
            cmdSC_ENG_T005_A = new RelayCommand<object>(items => { if (items == null) { return; } SC_ENG_T005_A(items); });
            cmdSC_ENG_T005_B = new RelayCommand<object>(items => { if (items == null) { return; } SC_ENG_T005_B(items); });
            cmdSC_ENG_T005_C = new RelayCommand<object>(items => { if (items == null) { return; } SC_ENG_T005_C(items); });
            cmdSC_ENG_T005_R = new RelayCommand<object>(items => { if (items == null) { return; } SC_ENG_T005_R(items); });
            cmdInvoke_Reference_Document = new RelayCommand<object>(items => { if (items == null) { return; } Invoke_Reference_Document(items); });
            cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
            AssignmentEntityRowDeleteCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteAssignmentEntityRow(cmdPara); });
            InspCharEntityRowDeleteCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteInspCharEntityRow(cmdPara); });
            OperationEntityRowDeleteCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteOperationEntityRow(cmdPara); });
            SelectedSetEntityRowDeleteCommand = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteSelectedSetEntityRow(cmdPara); });
            cmdInsertChar = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCharacteristics(cmdPara, true, true, true); });
            cmdInsertComponant = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertComponant(cmdPara, true, true, true); });
            cmdLoadDocumentByDocNo = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
            CmdCheckBoxChange = new GalaSoft.MvvmLight.Command.RelayCommand(() => { CheckBoxSelectionChange(); });
            CmdProfile = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertParaProfileOrGroup(cmdPara, false, true, true); });
            CmdParaType = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertParameterType(cmdPara, true, true, true); });
            cmdInsertOperation = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertOperation(cmdPara, true, true, true); });
            cmdInsertLocationOP = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLocationOP(cmdPara, true, true, true); });
            cmdLoadBackFlip = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadBackFlipData(cmdPara); });
            cmdInsertBOM = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertBOM(cmdPara); });
            cmdOperationAttachments = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } OperationAttachments(cmdPara); });
            //cmdInsertCompany = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCompany(cmdPara); });
            cmdStyleFormating = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } StyleFormating(cmdPara); });
            #endregion
        }
        private void LoadInitialData(string company, string location)
        {
            try
            {
                
                string Request = "LOAD_INI" + "!@" + AppSessionState.client + "!@" + company + "!@" + location + "!@" + this.doc_cat_vm + "!@" + task_list_type_vm;
                MC = REPO_MC.GetDataWithReturnDomainObject<MC_ENG_BE>(MC, Request, "ENG_T005_BL", "ENG", "LoadInitialData", 0, "");

                #region Enumerables & AutoSuggest Initalization

                ITEM_LIST = MC.STD_ITEM_LIST;
                VCHAR_LIST = MC.VCHAR_LIST;
                DEPT_LIST = MC.DEPT_LIST;
                PROFILE_LIST = MC.CLASS_GROUP_LIST;
                CHAR_GROUP_LIST = MC.CHAR_GROUP_LIST;
                METHOD_LIST = MC.METHOD_LIST;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).value_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).value_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_DEFAULT  = new AutoSuggestTextViewModel<dynamic>(MC.STANDARD_LIST, TheFilter, SuggestedValue, "value_code", true);
                AS_DEFAULT1 = new AutoSuggestTextViewModel<dynamic>(MC.STANDARD_LIST, TheFilter, SuggestedValue, "value_code", true);
                //AS_DEFAULT2 = new AutoSuggestTextViewModel<dynamic>(MC.STANDARD_LIST, TheFilter, SuggestedValue, "value_code", true);
                AS_DEFAULT3 = new AutoSuggestTextViewModel<dynamic>(MC.STANDARD_LIST, TheFilter, SuggestedValue, "value_code", true);
                

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M0002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0002)o).comp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_COMPANY = new AutoSuggestTextViewModel<dynamic>(MC.COMPANY_LIST, TheFilter, SuggestedValue, "comp_code", true);
                AS_COMPANY.AutoSuggestVM.IsEmptyValueAllowed = true;

                List<ADM_M0003> LOC_LIST_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == AppSessionState.OBJ_COMPANY.comp_code).ToList();
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_id", true);
                AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = false; AS_LOCATION.AutoSuggestVM.IsFreeTextAllowed = false;

                ////NOTE: use separate dataset
                //List<ADM_M0003> LOC_LIST_OBJ_OP = MC.LOCATION_LIST.Where(item => item.comp_code == AppSessionState.OBJ_COMPANY.comp_code).ToList();
                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
                //TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                //AS_LOCATION_OP = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ_OP, TheFilter, SuggestedValue, "location_id", true);
                //AS_LOCATION_OP.AutoSuggestVM.IsEmptyValueAllowed = false; AS_LOCATION_OP.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).wc_code ?? "");
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).wc_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_LIST_BE)o).wc_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_WORK_CENTER = new AutoSuggestTextViewModel<dynamic>(MC.WC_LIST.Where(x => x.location_id == MasterEntity.location_id).ToList(), TheFilter, SuggestedValue, "wc_code", "wc_code", true);
                AS_WORK_CENTER.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).value_code ?? "");
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).value_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_LIST_BE)o).value_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_USAGE = new AutoSuggestTextViewModel<dynamic>(MC.USAGE_LIST, TheFilter, SuggestedValue, "value_code", true);
                AS_USAGE.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).bom_no ?? "");
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).bom_no ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_LIST_BE)o).short_text ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_BOM = new AutoSuggestTextViewModel<dynamic>(MC.BOM_LIST, TheFilter, SuggestedValue, "bom_no", "bom_no", true);
                AS_BOM.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code ?? "");
                TheFilter = (o, prefix) => (((STD_ITEM)o).item_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_ITEM)o).item_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_ITEM = new AutoSuggestTextViewModel<dynamic>(MC.STD_ITEM_LIST, TheFilter, SuggestedValue, "item_code", true);
                AS_ITEM.AutoSuggestVM.IsEmptyValueAllowed = false; AS_ITEM.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code ?? "");
                TheFilter = (o, prefix) => (((STD_ITEM)o).item_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_ITEM)o).item_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_COMPONANT = new AutoSuggestTextViewModel<dynamic>(MC.COMPONANT_LIST, TheFilter, SuggestedValue, "item_code", true);
                AS_COMPONANT.AutoSuggestVM.IsEmptyValueAllowed = false; AS_COMPONANT.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((UOMS)o).unit_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_UOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                AS_UOM.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((UOMS)x).unit_code ?? "");
                TheFilter = (o, prefix) => (((UOMS)o).unit_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((UOMS)o).unit_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_QUOM = new AutoSuggestTextViewModel<dynamic>(MC.UOM_LIST, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                AS_QUOM.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).value_code ?? "");
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).value_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_LIST_BE)o).value_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_PARA_TYPE = new AutoSuggestTextViewModel<dynamic>(MC.PARA_TYPE_LIST, TheFilter, SuggestedValue, "value_code", true);
                AS_PARA_TYPE.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).value_code ?? "");
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).value_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_LIST_BE)o).value_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_INSP_METHOD = new AutoSuggestTextViewModel<dynamic>(MC.METHOD_LIST, TheFilter, SuggestedValue, "value_code", true);
                AS_INSP_METHOD.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).value_code ?? "");
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).value_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_LIST_BE)o).value_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_PROCEDURE = new AutoSuggestTextViewModel<dynamic>(MC.PROCEDURE_LIST, TheFilter, SuggestedValue, "value_code", true);
                AS_PROCEDURE.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).value_code ?? "");
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).value_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_LIST_BE)o).value_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_QUALIFICATION = new AutoSuggestTextViewModel<dynamic>(MC.QUALIFICATION_LIST, TheFilter, SuggestedValue, "value_code", true);
                AS_QUALIFICATION.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ENG_T005_B)x).char_code ?? "");
                TheFilter = (o, prefix) => (((ENG_T005_B)o).char_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((ENG_T005_B)o).char_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_CHAR = new AutoSuggestTextViewModel<dynamic>(MC.VCHAR_LIST, TheFilter, SuggestedValue, "char_code", true);
                AS_CHAR.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).value_code ?? "");
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).value_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_LIST_BE)o).value_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                AS_CONTROL_KEY = new AutoSuggestTextViewModel<dynamic>(MC.KEY_DATA_LIST, TheFilter, SuggestedValue, "value_code", true);
                AS_CONTROL_KEY.AutoSuggestVM.IsEmptyValueAllowed = true;

                ////var SelectedSetOrGroupCode = (from o in MC.GroupSetMaster where o.Seperator == "SelectedSet" select o);
                //var SelectedSetOrGroupCode = (from o in MC.CLASS_GROUP_LIST where o.class_code == "SelectedSet" select o);
                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((Classification)x).class_code ?? "");
                ////TheFilter = (o, prefix) => (((Classification)o).para_prof_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((Classification)o).Name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                //TheFilter = (o, prefix) => (((Classification)o).class_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((Classification)o).class_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                ////AS_PROFILE = new AutoSuggestTextViewModel<dynamic>(SelectedSetOrGroupCode, TheFilter, SuggestedValue, "gc_or_ss", "para_prof_code", true);
                //AS_PROFILE = new AutoSuggestTextViewModel<dynamic>(SelectedSetOrGroupCode, TheFilter, SuggestedValue, "class_code", "class_code", true);
                //AS_PROFILE.AutoSuggestVM.IsEmptyValueAllowed = true;

                //SuggestedValue = new ValueConverter(x => x == null ? "" : ((Classification)x).profile_code ?? "");
                //TheFilter = (o, prefix) => (((Classification)o).profile_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((Classification)o).profile_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                //AS_PROFILE = new AutoSuggestTextViewModel<dynamic>(MC.CLASS_GROUP_LIST, TheFilter, SuggestedValue, "gc_or_ss", "profile_code", true);
                //AS_PROFILE.AutoSuggestVM.IsEmptyValueAllowed = true; AS_PROFILE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_PERSONNEL)x).emp_id);
                TheFilter = (o, prefix) => (((STD_PERSONNEL)o).emp_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_PERSONNEL)o).emp_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_EMPLOYEE = new AutoSuggestTextViewModel<dynamic>(MC.PERSONNEL_LIST, TheFilter, SuggestedValue, "emp_id", true);
                AS_EMPLOYEE.AutoSuggestVM.IsEmptyValueAllowed = true;AS_EMPLOYEE.AutoSuggestVM.IsFreeTextAllowed = false;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).op_code);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).op_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((STD_LIST_BE)o).op_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                AS_OPERATION = new AutoSuggestTextViewModel<dynamic>(MC.OPERATION_LIST, TheFilter, SuggestedValue, "op_code", true);
                AS_OPERATION.AutoSuggestVM.IsEmptyValueAllowed = true; AS_OPERATION.AutoSuggestVM.IsFreeTextAllowed = false;



                #endregion
                DefaultValues();
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private bool Validation()
        {
            if (MasterEntity.valid_from == null)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Requird";
                showMessageService.Text = String.Format("Valid From Date is Required");
                showMessageService.ShowMessage();
                return false;
            }
            if (Copy == true)
            {
                NewRecord = true;

            }
            //if (MasterEntity.item_code == null || MasterEntity.item_code == "")
            //{
            //    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
            //    showMessageService.ButtonSetup = DialogButton.Ok;
            //    showMessageService.Caption = "Required";
            //    showMessageService.Text = String.Format("Item Code is Required");
            //    showMessageService.ShowMessage();
            //    return false;
            //}
            if (OperationEntity.Count < 1)
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Operation Code In Operation Tab");
                showMessageService.ShowMessage();
                return false;
            }

            if (CharEntity.Count > 1)
            {
                foreach (var o in CharEntity)
                {
                    int flag = 0;
                    if (o.active == "1")
                    {
                        foreach (var p in CharEntity)
                        {
                            if (o.char_code == p.char_code || (o.fcode == p.fcode && !string.IsNullOrWhiteSpace(o.fcode)))
                            {
                                flag++;
                            }
                        }
                        if (flag > 1)
                        {
                            sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(String.Format("Cannot Save Duplicate Charactristics {0} or Formula Code {1}", o.char_code, o.fcode), this.Title); sms.ShowMessage();
                            return false;
                        }
                    }

                    
                }
            }

            return true;
        }
        private void DefaultValues()
        {
            MasterEntity.doc_type = this.doc_cat_vm;
            MasterEntity.doc_cat = this.doc_cat_vm;
            MasterEntity.tl_type = this.task_list_type_vm;
            MasterEntity.doc_date = System.DateTime.Now;
            MasterEntity.active = "1";
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.location_id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.t_status = "01";
            MasterEntity.valid_from = System.DateTime.Now;
            MasterEntity.group_counter = "1";
            MasterEntity.plan_counter = 1;

            DateTime d = DateTime.UtcNow;
            d = d.AddMonths(-1);
            REQ_PARA_OBJ.from_date = d;
            REQ_PARA_OBJ.to_date = DateTime.UtcNow;
            REQ_PARA_OBJ.active = true;
            REQ_PARA_OBJ.comp_code = AppSessionState.OBJ_COMPANY.comp_code;

        }
        private void Logging()
        {
            MasterEntity.ts_code = this.ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.session_id = AppSessionState.session_id;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MasterEntity.XDOC_R != null)
            {
                ComponantEntity.Clear();
                ComponantEntity = (ObservableCollection<ENG_T005_R>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_R, MC.ComponantEntity);
            }
            else
            {
                MC.ComponantEntity = new ObservableCollection<ENG_T005_R>();
            }

            if (MasterEntity.XDOC_A != null)
            {
                OperationEntity.Clear();
                OperationEntity = (ObservableCollection<ENG_T005_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_A, MC.OperationEntity);
            }
            else
            {
                MC.OperationEntity = new ObservableCollection<ENG_T005_A>();
            }

            if (MasterEntity.XDOC_B != null)
            {
                CharEntity.Clear();
                CharEntity = (ObservableCollection<ENG_T005_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_B, MC.CharEntity);
            }
            else
            {
                MC.CharEntity = new ObservableCollection<ENG_T005_B>();
            }

            if (MasterEntity.XDOC_C != null)
            {
                SelectedSetEntity.Clear();
                SelectedSetEntity = (ObservableCollection<ENG_T005_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_C, MC.SelectedSetEntity);
            }
            else
            {
                MC.SelectedSetEntity = new ObservableCollection<ENG_T005_C>();
            }
            if (MasterEntity.XDOC_M != null)
            {
                AssignmentEntity.Clear();
                AssignmentEntity = (ObservableCollection<ENG_T005_M>)new ObjectSerializationService().XMLToObject(MasterEntity.XDOC_M, MC.AssignmentEntity);
            }
            else
            {
                MC.AssignmentEntity = new ObservableCollection<ENG_T005_M>();
            }

            MasterEntity.ts_code = ts_code_vm;
            MasterEntity.userid = AppSessionState.UserID;
            MasterEntity.user_source1 = AppSessionState.UserSource1;
            MasterEntity.user_source2 = AppSessionState.UserSource2;
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
                DefaultValues();
                LoadInitialData(MasterEntity.comp_code, MasterEntity.location_id);
                DefaultValues();
                if (doc_no_vm != null && ts_code_vm != null)
                {
                    LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                }
                if(STD_LIST_OBJ != null)
                {
                    if (STD_LIST_OBJ.request_type == "VC" && STD_LIST_OBJ.request=="VC")
                    {
                        List<STD_LIST_BE> list_obj = new List<STD_LIST_BE>();
                        list_obj.Add(STD_LIST_OBJ);
                        LoadDocumentByDocumentNumber(list_obj, "DocumentNo");
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void ExecuteVC(object InputValue)
        {
            try
            {
                CursorControl.SetBusyState();
                STD_LIST_OBJ = new STD_LIST_BE();
                if (STD_LIST_OBJ != null)
                {
                    STD_LIST_OBJ.request = "VC";
                    STD_LIST_OBJ.request_type = "VC";
                    STD_LIST_OBJ.doc_no = MasterEntity.doc_no;
                    STD_LIST_OBJ.comp_code = MasterEntity.comp_code;
                    STD_LIST_OBJ.location_id = MasterEntity.location_id;
                    STD_LIST_OBJ.doc_cat = MasterEntity.doc_cat;
                    STD_LIST_OBJ.doc_type = MasterEntity.doc_type;
                    STD_LIST_OBJ.op_no = ENG_T005_A_OBJ.op_no;
                    STD_LIST_OBJ.op_seq = ENG_T005_A_OBJ.id;
                    STD_LIST_OBJ.row_id = ENG_T005_A_OBJ.id;
                    STD_LIST_OBJ.char_code = ENG_T005_B_OBJ.char_code;
                    STD_LIST_OBJ.class_code = ENG_T005_B_OBJ.ref_class;

                    if (!string.IsNullOrWhiteSpace(STD_LIST_OBJ.doc_no ?? ""))
                    {
                        AppSessionState.TransactionCode = "TS99";
                        AppSessionState.ViewTitle = "Dependency View";
                        string class_file = "Reflection.Modules.ENG.Views.ENG_T013";
                        string ts_namespace = "Reflection.Modules.ENG.dll";

                        if (class_file != null && class_file != "")
                        {
                            string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, ts_namespace);
                            Assembly assembly = Assembly.LoadFile(path1);
                            Type type = assembly.GetType(class_file);
                            if (type != null)
                            {
                                dynamic instance = Activator.CreateInstance(type, "TS99", STD_LIST_OBJ);
                                //SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().ShowDialog(instance); // Commented because ShowDialog screen not closing on close button if open twice afer flip.
                                SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                            }
                        }
                    }

                }
                else
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Reference Document Number!", this.Title); sms.ShowMessage();
                }
            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void SC_ENG_T005_R(object InputValue)
        {
            try
            {
                ENG_T005_R_OBJ = (ENG_T005_R)InputValue;
            }
            catch (Exception ex) { }
        }
        private void SC_ENG_T005_A(object InputValue)
        {
            try
            {
                ENG_T005_A_OBJ = (ENG_T005_A)InputValue;
                FilterCharactristics();
                FilterComponants();

                if (ENG_T005_A_OBJ != null && MC.WC_LIST.Count > 0)
                {
                    SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).wc_code ?? "");
                    TheFilter = (o, prefix) => (((STD_LIST_BE)o).wc_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_LIST_BE)o).wc_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                    AS_WORK_CENTER = new AutoSuggestTextViewModel<dynamic>(MC.WC_LIST.Where(x => x.location_id == ENG_T005_A_OBJ.location_id).ToList(), TheFilter, SuggestedValue, "wc_code", "wc_code", true);
                    AS_WORK_CENTER.AutoSuggestVM.IsEmptyValueAllowed = true;

                }
            }
            catch (Exception ex) { }
        }
        private void SC_ENG_T005_B(object InputValue)
        {
            try
            {
                ENG_T005_B_OBJ = (ENG_T005_B)InputValue;
                FilterSelectedSetDataGrid();
                //FilterComponants();
            }
            catch (Exception ex) { }
        }
        private void SC_ENG_T005_C(object InputValue)
        {
            try
            {
                ENG_T005_C_OBJ = (ENG_T005_C)InputValue;
            }
            catch (Exception ex) { }
        }
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            EntityChangeEnable = false;
            string Request = "";
            STD_LIST_BE ParameterEntityObject = null;

            if (((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList().Count > 0)
            {
                ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<STD_LIST_BE>().ToList()[0];

                if (MasterEntity.comp_code != ParameterEntityObject.comp_code) // call when document loading of different company
                {
                    LoadInitialData(ParameterEntityObject.comp_code, ParameterEntityObject.location_id);
                }


                Request = "LOAD_DOC_BY_DOC_NO" + "!@" + AppSessionState.client + "!@" + (ParameterEntityObject.comp_code ?? "") + "!@" + (ParameterEntityObject.location_id ?? "") + "!@" + (ParameterEntityObject.doc_cat ?? "") + "!@" + (ParameterEntityObject.doc_type ?? "") + "!@" + (ParameterEntityObject.doc_no ?? "") + "!@" + (ParameterEntityObject.request ?? "") + "!@" + "!@" + (ParameterEntityObject.char_code ?? "") + "!@" + (ParameterEntityObject.op_no ?? "") + "!@" + (ParameterEntityObject.class_code ?? "") + "!@" + (ParameterEntityObject.class_no ?? "") + "!@TLC";
                NewRecord = false;

                MC_TEMP = REPO_MC_TEMP.GetDataWithReturnDomainObject<MC_ENG_BE>(MC_TEMP, Request, "ENG_T005_BL", "ENG", "LoadDocumentByDocumentNumber", 0, "");

                if (MC_TEMP.MasterEntityTask != null)
                {
                    if (MC_TEMP.MasterEntityTask.Count > 0)
                    {
                        MasterEntity = MC_TEMP.MasterEntityTask[0];
                        OperationEntity = MC_TEMP.OperationEntity;
                        CharEntity = MC_TEMP.CharEntity;
                        SelectedSetEntity = MC_TEMP.SelectedSetEntity;
                        ComponantEntity = MC_TEMP.ComponantEntity;
                        AssignmentEntity = MC_TEMP.AssignmentEntity;
                    }
                }
            }
            SelectedTabControlIndex = 0;
            MasterEntity.ts_code = ts_code_vm;
            EntityChangeEnable = true;
            var msg = new NotificationMessage(ts_code_vm);
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        private void LoadBackFlipData(object Parameter)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LOAD_BACKFLIP" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (REQ_PARA_OBJ.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + (REQ_PARA_OBJ.active_code ?? "") + "!@" + (REQ_PARA_OBJ.t_status ?? "") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(REQ_PARA_OBJ.to_date).ToString("MM/dd/yyyy");
                MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_SDM_BE>(MC_TEMP, Request, "ENG_T005_BL", "ENG", "LoadAll", 0, "");

                BACKFLIP_COLLECTION = CollectionViewSource.GetDefaultView(MC_TEMP.BACK_FLIP_LIST.ToList());
                BACKFLIP_COLLECTION.Filter = new Predicate<object>(FLTR_BACKFLIP);

                Messenger.Default.Send<NotificationMessage>(new NotificationMessage(ts_code_vm));
            }
            catch (Exception ex)
            { sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage(); }
        }
        private void DeleteInspCharEntityRow(object InputValue)
        {
            try
            {
                if (ENG_T005_B_OBJ != null && (ENG_T005_B_OBJ.id == 0 || Copy == true))
                {
                    if (SelectedSetEntity.Count > 0)
                    {
                        var itemsToRemove = SelectedSetEntity.Where(x => x.op_no == ENG_T005_B_OBJ.op_no && x.char_code == ENG_T005_B_OBJ.char_code).ToList();
                        foreach (var item in itemsToRemove)
                        {
                            SelectedSetEntity.Remove(SelectedSetEntity.Where(x => x.op_no == ENG_T005_B_OBJ.op_no && x.char_code == ENG_T005_B_OBJ.char_code && x.prof_code == item.prof_code).Single());
                        }
                    }
                    if (CharEntity.Count > 0)
                    {
                        CharEntity.Remove(ENG_T005_B_OBJ);
                        //CharEntity.Remove(CharEntity.Where(x => x.op_no == ENG_T005_B_OBJ.op_no && x.char_code == ENG_T005_B_OBJ.char_code).Single());
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertCharacteristics(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ENG_T005_B POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.VCHAR_LIST.Where(x => x.char_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ENG_T005_B>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T005_B>().ToList()[0];
                    }
                }
                #endregion
                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (ENG_T005_B_OBJ != null) // && (ENG_T005_B_OBJ.id == null || ENG_T005_B_OBJ.id == 0)
                    {
                        //ENG_T005_B_OBJ = POPUPEntityObject;
                        if(ENG_T005_B_OBJ.id == null)
                        {
                            ENG_T005_B_OBJ.id = 0;
                        }
                        
                        ENG_T005_B_OBJ.char_type = POPUPEntityObject.char_type;
                        ENG_T005_B_OBJ.char_code = POPUPEntityObject.char_code;
                        ENG_T005_B_OBJ.char_group = POPUPEntityObject.char_group;
                        ENG_T005_B_OBJ.group_name = POPUPEntityObject.group_name;
                        ENG_T005_B_OBJ.char_name = POPUPEntityObject.char_name;
                        ENG_T005_B_OBJ.char_no = POPUPEntityObject.char_no;
                        ENG_T005_B_OBJ.short_text = POPUPEntityObject.short_text;
                        ENG_T005_B_OBJ.op_no = OperationEntity[dgIndex_A].op_no;
                        ENG_T005_B_OBJ.char_ver = POPUPEntityObject.char_ver;
                        ENG_T005_B_OBJ.ver_date = POPUPEntityObject.ver_date;
                        ENG_T005_B_OBJ.low_limit = POPUPEntityObject.low_limit;
                        ENG_T005_B_OBJ.up_limit = POPUPEntityObject.up_limit;
                        ENG_T005_B_OBJ.valid_from = POPUPEntityObject.valid_from;
                        ENG_T005_B_OBJ.char_location = POPUPEntityObject.char_location;
                        ENG_T005_B_OBJ.way_char = POPUPEntityObject.way_char;
                        ENG_T005_B_OBJ.insp_qual = POPUPEntityObject.insp_qual;
                        ENG_T005_B_OBJ.tol_key = POPUPEntityObject.tol_key;
                        ENG_T005_B_OBJ.long_text = POPUPEntityObject.long_text;
                        ENG_T005_B_OBJ.lang_key = POPUPEntityObject.lang_key;
                        ENG_T005_B_OBJ.dc_place = POPUPEntityObject.dc_place;
                        ENG_T005_B_OBJ.unit_code = POPUPEntityObject.unit_code;
                        ENG_T005_B_OBJ.target_value = POPUPEntityObject.target_value;
                        ENG_T005_B_OBJ.value1 = POPUPEntityObject.value1;
                        ENG_T005_B_OBJ.value2 = POPUPEntityObject.value2;
                        ENG_T005_B_OBJ.low_limit = POPUPEntityObject.low_limit;
                        ENG_T005_B_OBJ.up_limit = POPUPEntityObject.up_limit;
                        ENG_T005_B_OBJ.low_limit1 = POPUPEntityObject.low_limit1;
                        ENG_T005_B_OBJ.up_limit1 = POPUPEntityObject.up_limit1;
                        ENG_T005_B_OBJ.low_tol_limit = POPUPEntityObject.low_tol_limit;
                        ENG_T005_B_OBJ.up_tol_limit = POPUPEntityObject.up_tol_limit;
                        ENG_T005_B_OBJ.sample_uom = POPUPEntityObject.sample_uom;
                        ENG_T005_B_OBJ.sampl_qty_factor = POPUPEntityObject.sampl_qty_factor;
                        ENG_T005_B_OBJ.samp_pro_char = POPUPEntityObject.samp_pro_char ?? ENG_T005_B_OBJ.samp_pro_char;
                        ENG_T005_B_OBJ.ref_class = POPUPEntityObject.ref_class;
                        ENG_T005_B_OBJ.spec_info = POPUPEntityObject.spec_info;

                        ENG_T005_B_OBJ.t_status = "01";
                        ENG_T005_B_OBJ.active = "1";
                        ENG_T005_B_OBJ.comp_code = MasterEntity.comp_code;
                        ENG_T005_B_OBJ.location_id = (ENG_T005_A_OBJ.location_id ?? MasterEntity.location_id);
                        ENG_T005_B_OBJ.line_id_op = ENG_T005_A_OBJ.line_id;
                        ENG_T005_B_OBJ.op_row_id = ENG_T005_A_OBJ.id;
                    }
                    else
                    {
                        IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("First Fill Operation Tab Details And Then Select Characteristics"); sms.ShowMessage();
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        #endregion

        #region OperationEntity Methods
        private void DeleteOperationEntityRow(object InputValue) // NOTE: add componant section in this block
        {
            try
            {
                int i = (int)InputValue;
                if (OperationEntity.Count > i && (OperationEntity[dgIndex_A].id == 0 || Copy == true))
                {
                    if (CharEntity.Count > 0)
                    {
                        var itemsToRemove = CharEntity.Where(x => x.op_no == ENG_T005_A_OBJ.op_no).ToList();
                        foreach (var item in itemsToRemove)
                        {
                            CharEntity.Remove(CharEntity.Where(x => x.op_no == ENG_T005_A_OBJ.op_no && x.char_code == item.char_code).Single());
                        }
                    }
                    if (SelectedSetEntity.Count > 0)
                    {
                        var itemsToRemove = SelectedSetEntity.Where(x => x.op_no == ENG_T005_A_OBJ.op_no).ToList();
                        foreach (var item in itemsToRemove)
                        {
                            SelectedSetEntity.Remove(SelectedSetEntity.Where(x => x.op_no == ENG_T005_A_OBJ.op_no && x.char_code == item.char_code && x.prof_code == item.prof_code).Single());
                        }
                    }
                    OperationEntity.RemoveAt(i);
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void FilterComponants()
        {
            try
            {
                if (ComponantEntity != null && ComponantEntity.Count > 0 && ENG_T005_A_OBJ != null)
                {
                    if(ENG_T005_A_OBJ.id > 0)
                    {
                        ComponantCollection = CollectionViewSource.GetDefaultView(ComponantEntity);
                        ComponantCollection.Filter = adv => ((ENG_T005_R)adv).op_row_id.Equals(ENG_T005_A_OBJ.id);
                        ComponantCollection.Refresh();
                    }
                    else
                    {
                        ComponantCollection = CollectionViewSource.GetDefaultView(ComponantEntity);
                        //ComponantCollection.Filter = adv => (((ENG_T005_R)adv).line_id_A.Equals(ENG_T005_A_OBJ.line_id) && ((ENG_T005_R)adv).op_row_id.Equals(ENG_T005_A_OBJ.id));
                        ComponantCollection.Filter = adv => ((ENG_T005_R)adv).line_id_A.Equals(ENG_T005_A_OBJ.line_id);
                        ComponantCollection.Refresh();
                    }
                    
                }
            }
            catch (Exception ex)
            { }
        }
        private void FilterCharactristics()
        {
            try
            {
                if (CharEntity != null && CharEntity.Count > 0 && ENG_T005_A_OBJ != null)
                {
                    CharactristicsCollection = CollectionViewSource.GetDefaultView(CharEntity);
                    CharactristicsCollection.Filter = adv => ((ENG_T005_B)adv).op_no.Equals(ENG_T005_A_OBJ.op_no);
                    CharactristicsCollection.Refresh();
                }
            }
            catch (Exception ex)
            { }
        }
        private void FilterSelectedSetDataGrid()
        {
            try
            {
                if (SelectedSetEntity != null && SelectedSetEntity.Count > 0 && ENG_T005_B_OBJ != null)
                {
                    SelectedDataGridCollection = CollectionViewSource.GetDefaultView(SelectedSetEntity);
                    SelectedDataGridCollection.Filter = adv => ((ENG_T005_C)adv).op_no.Equals(ENG_T005_B_OBJ.op_no) && ((ENG_T005_C)adv).char_code.Equals(ENG_T005_B_OBJ.char_code);
                    SelectedDataGridCollection.Refresh();
                }
            }
            catch (Exception ex)
            { }
        }
        #endregion

        #region ComponantEntity Methods
        private void DeleteAssignmentEntityRow(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ComponantEntity.Count > i && (ComponantEntity[dgIndex_R].id == 0 || NewRecord == true))
                {
                    ComponantEntity.RemoveAt(i);

                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertComponant(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                STD_ITEM POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.COMPONANT_LIST.Where(x => x.item_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_ITEM>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_ITEM>().ToList()[0];
                    }
                }
                #endregion
                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    if (ENG_T005_R_OBJ != null)
                    {
                        ENG_T005_R_OBJ.id = 0;
                        ENG_T005_R_OBJ.item_code = POPUPEntityObject.item_code;
                        ENG_T005_R_OBJ.item_name = POPUPEntityObject.item_name;
                        ENG_T005_R_OBJ.line_id_A = ENG_T005_A_OBJ.line_id;
                        ENG_T005_R_OBJ.active = "1";
                        ENG_T005_R_OBJ.client = AppSessionState.client;
                        ENG_T005_R_OBJ.comp_code = MasterEntity.comp_code;
                        ENG_T005_R_OBJ.location_id = ENG_T005_A_OBJ.location_id;
                        ENG_T005_R_OBJ.doc_no = MasterEntity.doc_no;
                        ENG_T005_R_OBJ.group_counter = MasterEntity.group_counter;
                        ENG_T005_R_OBJ.int_counter = MasterEntity.plan_counter;
                        ENG_T005_R_OBJ.tl_type = MasterEntity.tl_type;
                        ENG_T005_R_OBJ.valid_from = MasterEntity.valid_from;
                        ENG_T005_R_OBJ.node_no = MasterEntity.plan_counter;
                        ENG_T005_R_OBJ.op_row_id = ENG_T005_A_OBJ.id;
                        ENG_T005_R_OBJ.bom_no = POPUPEntityObject.bom_no;
                        ENG_T005_R_OBJ.bom_cat = POPUPEntityObject.bom_cat;
                        ENG_T005_R_OBJ.bom_item_row_id = POPUPEntityObject.item_row_id;
                        ENG_T005_R_OBJ.bom_no_alt = POPUPEntityObject.bom_no_alt;
                        ENG_T005_R_OBJ.qty = POPUPEntityObject.qty;
                        ENG_T005_R_OBJ.unit_code = POPUPEntityObject.unit_code;
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        #endregion

        #region SelectedSetEntity Methods
        private void DeleteSelectedSetEntityRow(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (ENG_T005_C_OBJ != null)
                {
                    if (SelectedSetEntity.Count > i && (ENG_T005_C_OBJ.id == 0 || Copy == true))
                    {
                        SelectedSetEntity.Remove(SelectedSetEntity.Where(x => x.op_no == ENG_T005_C_OBJ.op_no && x.char_code == ENG_T005_C_OBJ.char_code && x.prof_code == ENG_T005_C_OBJ.prof_code).Single());
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void CheckBoxSelectionChange()
        {
            try
            {
                if (ENG_T005_C_OBJ.ind_gc_or_ss == true)
                {
                    var SelectedSetOrGroupCode = (from o in MC.CLASS_GROUP_LIST where o.separator == "GroupCode" select o);
                    PROFILE_LIST = SelectedSetOrGroupCode;

                    //var SelectedSetOrGroupCode = (from o in MC.GroupSetMaster where o.Seperator == "GroupCode" select o);
                    //var SelectedSetOrGroupCode = (from o in MC.CLASS_GROUP_LIST where o.separator == "GroupCode" select o);
                    //SuggestedValue = new ValueConverter(x => x == null ? "" : ((Group_Set)x).para_prof_code ?? "");
                    //TheFilter = (o, prefix) => (((Group_Set)o).para_prof_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((Group_Set)o).Name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                    //AS_PROFILE = new AutoSuggestTextViewModel<dynamic>(SelectedSetOrGroupCode, TheFilter, SuggestedValue, "gc_or_ss", "para_prof_code", true);
                    //AS_PROFILE.AutoSuggestVM.IsEmptyValueAllowed = true;
                }
                else if (ENG_T005_C_OBJ.ind_gc_or_ss == false || ENG_T005_C_OBJ.ind_gc_or_ss == null)
                {
                    //var SelectedSetOrGroupCode = (from o in MC.CLASS_GROUP_LIST where o.separator == "SelectedSet" select o);
                    //SuggestedValue = new ValueConverter(x => x == null ? "" : ((Group_Set)x).para_prof_code ?? "");
                    //TheFilter = (o, prefix) => (((Group_Set)o).para_prof_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((Group_Set)o).Name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                    //AS_PROFILE = new AutoSuggestTextViewModel<dynamic>(SelectedSetOrGroupCode, TheFilter, SuggestedValue, "gc_or_ss", "para_prof_code", true);
                    //AS_PROFILE.AutoSuggestVM.IsEmptyValueAllowed = true;

                    var SelectedSetOrGroupCode = (from o in MC.CLASS_GROUP_LIST where o.separator == "SelectedSet" select o);
                    PROFILE_LIST = SelectedSetOrGroupCode;
                }
            }
            catch (Exception ex) { }
        }
        private void InsertParaProfileOrGroup(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                //Group_Set POPUPEntityObject = null;
                Classification POPUPEntityObject = null;

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
                            POPUPEntityObject = MC.CLASS_GROUP_LIST.Where(x => x.para_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            //POPUPEntityObject = MC.CLASS_GROUP_LIST.Where(x => x.para_prof_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<Classification>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<Classification>().ToList()[0];
                    }
                }
                #endregion

                if (POPUPEntityObject != null && ENG_T005_C_OBJ != null) // Only enter in the code block if ENtity Not null.
                {
                    //ENG_T005_C_OBJ.gc_or_ss = POPUPEntityObject.para_prof_code;
                    ENG_T005_C_OBJ.prof_code = POPUPEntityObject.para_code;
                    ENG_T005_C_OBJ.plant_gc = POPUPEntityObject.location_id;
                    ENG_T005_C_OBJ.line_id_ic = CharEntity[dgIndex_B].line_id;
                    ENG_T005_C_OBJ.line_id_op = ENG_T005_A_OBJ.line_id;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertParameterType(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                QMS_M032_P POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            //POPUPEntityObject = MC.ParaTypeMaster.Where(x => x.para_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<QMS_M032_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<QMS_M032_P>().ToList()[0];
                    }
                }
                #endregion
                if (POPUPEntityObject != null && ENG_T005_B_OBJ != null) // Only enter in the code block if ENtity Not null.
                {
                    if (CharEntity.Count > 0)
                    {
                        if (NewRow == true && AllowDuplicate == true)
                        {
                            SelectedSetEntity.Add(new ENG_T005_C()
                            {
                                id = 0,
                                prof_type = POPUPEntityObject.para_type,
                                para_name = POPUPEntityObject.cat_type_desc,
                                op_no = ENG_T005_B_OBJ.op_no,
                                char_code = ENG_T005_B_OBJ.char_code,
                                comp_code = MasterEntity.comp_code,
                                location_id = MasterEntity.location_id,
                                t_status = "01",
                                active = "01",
                                line_id_ic = CharEntity[dgIndex_B].char_no,
                                line_id_op = ENG_T005_A_OBJ.line_id
                            });
                        }
                        else if (dgIndex_C >= 0 && SelectedSetEntity.Count > dgIndex_C) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                        {
                            ENG_T005_C_OBJ.prof_type = POPUPEntityObject.para_type;
                            ENG_T005_C_OBJ.para_name = POPUPEntityObject.cat_type_desc;
                            ENG_T005_C_OBJ.op_no = ENG_T005_B_OBJ.op_no;
                            ENG_T005_C_OBJ.char_code = ENG_T005_B_OBJ.char_code;
                            ENG_T005_C_OBJ.comp_code = MasterEntity.comp_code;
                            ENG_T005_C_OBJ.location_id = MasterEntity.location_id;
                            ENG_T005_C_OBJ.t_status = "01";
                            ENG_T005_C_OBJ.active = "1";
                            ENG_T005_C_OBJ.line_id_op = ENG_T005_A_OBJ.line_id;

                        }
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("First Fill Insp.Char Tab Details And Then Select Parameter Type");
                        showMessageService.ShowMessage();
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertOperation(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.OPERATION_LIST.Where(x => x.op_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }
                #endregion
                if (POPUPEntityObject != null && ENG_T005_A_OBJ != null) // Only enter in the code block if ENtity Not null.
                {
                    ENG_T005_A_OBJ.op_code = POPUPEntityObject.op_code;
                    ENG_T005_A_OBJ.op_name = POPUPEntityObject.op_name;
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void InsertLocationOP(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M0003 POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.LOCATION_LIST.Where(x => x.location_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M0003>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0003>().ToList()[0];
                    }
                }
                #endregion
                if (POPUPEntityObject != null && ENG_T005_A_OBJ != null) // Only enter in the code block if ENtity Not null.
                {
                    ENG_T005_A_OBJ.location_id = POPUPEntityObject.location_id;
                    if (ENG_T005_A_OBJ != null && MC.WC_LIST.Count > 0)
                    {
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).wc_code ?? "");
                        TheFilter = (o, prefix) => (((STD_LIST_BE)o).wc_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_LIST_BE)o).wc_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                        AS_WORK_CENTER = new AutoSuggestTextViewModel<dynamic>(MC.WC_LIST.Where(x => x.location_id == ENG_T005_A_OBJ.location_id).ToList(), TheFilter, SuggestedValue, "wc_code", "wc_code", true);
                        AS_WORK_CENTER.AutoSuggestVM.IsEmptyValueAllowed = true;

                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }

        private void InsertBOM(object InputValue)
        {
            try
            {
                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;

                #region Command Parameter Read Section
                // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        {
                            POPUPEntityObject = MC.BOM_LIST.Where(x => x.bom_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                        }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<STD_LIST_BE>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }
                #endregion
                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    MasterEntity.bom_no = POPUPEntityObject.bom_no;
                    if (!string.IsNullOrWhiteSpace(MasterEntity.bom_no))
                    {
                        CursorControl.SetBusyState();
                        Request = "LOAD_BOM_DATA" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + (MasterEntity.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + MasterEntity.bom_no;
                        MC_TEMP = REPO_MC.GetDataWithReturnDomainObject<MC_SDM_BE>(MC_TEMP, Request, "ENG_T005_BL", "ENG", "LoadAll", 0, "");

                        if (!string.IsNullOrWhiteSpace(MasterEntity.bom_no) && MC_TEMP.STD_ITEM_LIST != null)
                        {
                            if (MC_TEMP.COMPONANT_LIST.Count > 0)
                            {
                                MC.COMPONANT_LIST = MC_TEMP.COMPONANT_LIST;

                                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_ITEM)x).item_code ?? "");
                                TheFilter = (o, prefix) => (((STD_ITEM)o).item_code ?? "").ToLower().Contains(prefix.ToString().ToLower()) || (((STD_ITEM)o).item_name ?? "").ToLower().Contains(prefix.ToString().ToLower());
                                AS_COMPONANT = new AutoSuggestTextViewModel<dynamic>(MC.COMPONANT_LIST, TheFilter, SuggestedValue, "item_code", true);
                                AS_COMPONANT.AutoSuggestVM.IsEmptyValueAllowed = false; AS_COMPONANT.AutoSuggestVM.IsFreeTextAllowed = false;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        //private void InsertCompany(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ADM_M0002 POPUPEntityObject = null;
        //        #region Command Parameter Read Section
        //        try
        //        {
        //            if (InputValue.GetType() == typeof(string) && InputValue != null)
        //            {
        //                Request = InputValue.ToString();
        //                if (Request.Length > 0)
        //                {
        //                    try
        //                    { POPUPEntityObject = MC.COMPANY_LIST.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                    catch (Exception ex) { }
        //                }
        //            }
        //            else if (InputValue != null)
        //            {
        //                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M0002>().ToList()[0];
        //            }
        //        }
        //        catch (Exception ex) { }

        //        #endregion
        //        if (POPUPEntityObject != null)
        //        {
        //            //if (MasterEntity.comp_code != POPUPEntityObject.comp_code)
        //            //{
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;
        //            LoadInitialData(MasterEntity.comp_code, MasterEntity.location_id);
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;

        //            List<ADM_M0003> LOC_LIST_OBJ = MC.LOCATION_LIST.Where(item => item.comp_code == MasterEntity.comp_code).ToList();
        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0003)x).location_id);
        //            TheFilter = (o, prefix) => (((ADM_M0003)o).location_id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0003)o).location_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //            AS_LOCATION = new AutoSuggestTextViewModel<dynamic>(LOC_LIST_OBJ, TheFilter, SuggestedValue, "location_id", true);
        //            AS_LOCATION.AutoSuggestVM.IsEmptyValueAllowed = true;
        //            if (LOC_LIST_OBJ.Count == 1)
        //            {
        //                MasterEntity.location_id = LOC_LIST_OBJ[0].location_id;
        //            }
        //            else
        //            {
        //                MasterEntity.location_id = null;
        //            }
        //        }
        //        //}
        //    }
        //    catch (Exception ex)
        //    {
        //        sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
        //    }
        //}

        #endregion
        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<ENG_T005> result)
        {
            MasterEntity = new ENG_T005();
            CharEntity = new ObservableCollection<ENG_T005_B>();
            OperationEntity = new ObservableCollection<ENG_T005_A>();
            ComponantEntity = new ObservableCollection<ENG_T005_R>();
            SelectedSetEntity = new ObservableCollection<ENG_T005_C>();
            AssignmentEntity = new ObservableCollection<ENG_T005_M>();
            ENG_T005_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Operation);
            OperationEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForOperationEntity);
            ComponantEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForComponantEntity);
            CharEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForCharEntity);
            SelectedSetEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSelectedSetEntity);
            AssignmentEntity.CollectionChanged += new NotifyCollectionChangedEventHandler(CollectionChangedNotifyForAssignmentEntity);
            DefaultValues();
            NewRecord = true;
            var msg = new NotificationMessage(ts_code_vm);
            Messenger.Default.Send<NotificationMessage>(msg);
        }
        protected override void OnDiscardAction(InquiryActionResult<ENG_T005> result)
        {

        }
        protected override void OnDocumentAction()
        {
            if (!string.IsNullOrEmpty(MasterEntity.doc_no))
            {            
                Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MC_TEMP.ATTACHMENT_LIST, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
            }
        }
        private void StyleFormating(object Parameter)
        {
            try
            {
                CursorControl.SetBusyState();
                if (ENG_T005_B_OBJ != null)
                {
                    if (!string.IsNullOrWhiteSpace(ENG_T005_B_OBJ.doc_no ?? ""))
                    {
                        ENG_T005_B_OBJ.doc_cat = MasterEntity.doc_cat;
                        ENG_T005_B_OBJ.doc_type = MasterEntity.doc_type;
                        SYS_AUTH userAuth = new SYS_AUTH();
                        userAuth.ts_code = "GN01";
                        userAuth.ts_name = "Result Style";
                        AppSessionState.TransactionCode = userAuth.ts_code;
                        AppSessionState.ViewTitle = userAuth.ts_name;
                        userAuth.ts_namespace = "Reflection.Modules.Settings.dll";
                        userAuth.class_file = "Reflection.Modules.Settings.Views.S0021";

                        if (userAuth.class_file != null && userAuth.class_file != "")
                        {
                            string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, userAuth.ts_namespace);
                            Assembly assembly = Assembly.LoadFile(path1);
                            Type type = assembly.GetType(userAuth.class_file);
                            if (type != null)
                            {
                                dynamic instance = Activator.CreateInstance(type, ENG_T005_B_OBJ);
                                SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                            }
                        }
                    }

                }
                else
                {
                    sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format("Please Select Reference Document Number!", this.Title); sms.ShowMessage();
                }

            }
            catch (Exception ex)
            { //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void OperationAttachments(object InputValue)
        {
            CursorControl.SetBusyState();
            WebServiceRepository<MultipleContext_Attachments> REPO_ATTACH = new WebServiceRepository<MultipleContext_Attachments>();
            List<COM_T003> Attachments = new List<COM_T003>();
            ENG_T005_A EntityObjectParameter = new ENG_T005_A();
            MultipleContext_Attachments MCAttachments = new MultipleContext_Attachments();
            try
            {
                if (InputValue != null)
                {
                    EntityObjectParameter = ((IEnumerable)InputValue).Cast<ENG_T005_A>().ToList()[0];
                }
                string Request = "GetAllFiles" + "!@" + AppSessionState.client + "!@" + (EntityObjectParameter.comp_code ?? AppSessionState.OBJ_COMPANY.comp_code) + "!@" + (EntityObjectParameter.location_id ?? AppSessionState.OBJ_LOCATION.location_id) + "!@" + (doc_cat_vm ?? "") + "!@" + doc_cat_vm + "!@" + EntityObjectParameter.doc_no + "!@" + EntityObjectParameter.id.ToString();
                MCAttachments = REPO_ATTACH.GetDataWithReturnDomainObject<MultipleContext_Attachments>(MCAttachments, Request, "GetAllFiles", "Administration", "LoadDocumentByDocumentNumber", 0, "");
                if (!string.IsNullOrEmpty(EntityObjectParameter.id.ToString()))
                {
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), Row_ID = EntityObjectParameter.id.ToString(), DocumentList = MCAttachments.Attachments, client = AppSessionState.client, comp_code = MasterEntity.comp_code });
                }

            }
            catch (Exception ex)
            {
                sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        protected override void OnFevoriteAction(InquiryActionResult<ENG_T005> result)
        {

        }
        protected override void OnFlipAction(InquiryActionResult<ENG_T005> result)
        {

        }
        protected override void OnHelpAction(InquiryActionResult<ENG_T005> result)
        {

        }
        protected override void OnPrintAction(InquiryActionResult<ENG_T005> result)
        {

        }
        protected override void OnRemoveAction(InquiryActionResult<ENG_T005> result)
        {

        }
        protected override void OnSaveAction(InquiryActionResult<ENG_T005> result)
        {
            try
            {
                if (Validation() == true)
                {
                    if (string.IsNullOrWhiteSpace(MasterEntity.tl_use)) // NOTE: Hardcoded for Testing      
                    {
                        MasterEntity.tl_use = "06";
                    }
                    Logging();
                    MasterEntity.XDOC_A = obj.ObjectToXML(OperationEntity);
                    MasterEntity.XDOC_B = obj.ObjectToXML(CharEntity);
                    MasterEntity.XDOC_C = obj.ObjectToXML(SelectedSetEntity);
                    MasterEntity.XDOC_R = obj.ObjectToXML(ComponantEntity);
                    MasterEntity.XDOC_M = obj.ObjectToXML(AssignmentEntity);
                    
                    this.MasterEntity.EndEdit();
                    if (NewRecord == true)
                    {
                        MasterEntity = REPO.SaveWithReturnDomainObject<ENG_T005>(MasterEntity, "ENG_T005_BL", "ENG");
                        Copy = false;
                    }
                    else if (NewRecord == false)
                    {
                        MasterEntity = REPO.UpdateWithReturnDomainObject<ENG_T005>(MasterEntity, "ENG_T005_BL", "ENG");
                    }
                    SetBusinessEntitiesAfterLoad("Save", "");
                    if (MasterEntity.doc_no != null || MasterEntity.doc_no != "" && MasterEntity.active == "1")
                    {
                        TabIndexItem = 0;
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("Record saved Successfully ........");
                        showMessageService.ShowMessage();
                    }
                    SelectedTabControlIndex = 0;
                    
                    NewRecord = false; // This flag required to placed at the bottom of function to use status in SetBusinessEntitiesAfterSave method. i.e. FlipGrid collection is not required to set in Flip DataGrid after Update. but required after Insert document. 
                    var msg = new NotificationMessage(ts_code_vm);
                    Messenger.Default.Send<NotificationMessage>(msg);
                }
            }
            catch (Exception ex)
            {
                IShowMessageViewService sms = this.GetViewService<IShowMessageViewService>(); sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        protected override void OnRefreshCommand(InquiryActionResult<ENG_T005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ENG_T005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ENG_T005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ENG_T005> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ENG_T005> result)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Filters

        #region Filter For Flip Grid
        private string _FLTR_STR_BACKFLIP;
        public string FLTR_STR_BACKFLIP
        {
            get { return _FLTR_STR_BACKFLIP; }
            set
            {
                _FLTR_STR_BACKFLIP = value;
                RaisePropertyChanged("FLTR_STR_BACKFLIP");
                FLTR_COLL_BACKFLIP();
            }
        }
        private void FLTR_COLL_BACKFLIP()
        {
            if (_BACKFLIP_COLLECTION != null)
            {
                _BACKFLIP_COLLECTION.Refresh();
            }
        }
        public bool FLTR_BACKFLIP(object obj)
        {
            var data = obj as STD_LIST_BE;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FLTR_STR_BACKFLIP))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.valid_from != null && data.valid_from.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.short_text != null && data.short_text.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.tl_name != null && data.tl_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.item_code != null && data.item_code.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.item_name != null && data.item_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.doc_cat != null && data.doc_cat.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.cat_name != null && data.cat_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.comp_code != null && data.comp_code.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.t_display != null && data.t_display.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower())) ||
                        (data.cat_name != null && data.cat_name.ToString().ToLower().Contains(_FLTR_STR_BACKFLIP.ToLower()));
                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filter For Work Center
        //private string _FilterStringItemCode;
        //public string FilterStringItemCode
        //{
        //    get { return _FilterStringItemCode; }
        //    set
        //    {
        //        _FilterStringItemCode = value;
        //        RaisePropertyChanged("FilterStringItemCode");
        //        FilterItemCode();
        //    }
        //}
        //private void FilterItemCode()
        //{
        //    if (_ItemCodeCollection != null)
        //    {
        //        _ItemCodeCollection.Refresh();
        //    }
        //}
        //public bool FilterItemCollection(object obj)
        //{
        //    var data = obj as STD_LIST_BE;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_FilterStringItemCode))
        //        {
        //            return (data.item_code != null && data.item_code.ToLower().Contains(_FilterStringItemCode.ToLower()) ||
        //                    data.item_name != null && data.item_name.ToString().ToLower().Contains(_FilterStringItemCode.ToLower())
        //                    );
        //        }
        //        return true;
        //    }
        //    return false;
        //}
        #endregion


        #region Filter For Parameter Collection
        //private string _FilterStringPara;
        //public string FilterStringPara
        //{
        //    get { return _FilterStringPara; }
        //    set
        //    {
        //        _FilterStringPara = value;
        //        RaisePropertyChanged("FilterStringPara");
        //        FilterPara();
        //    }
        //}
        //private void FilterPara()
        //{
        //    if (_ParameterCollection != null)
        //    {
        //        _ParameterCollection.Refresh();
        //    }
        //}
        //public bool FilterParameterCollection(object obj)
        //{
        //    var data = obj as QMS_M032_P;
        //    if (data != null)
        //    {
        //        if (!string.IsNullOrEmpty(_FilterStringPara))
        //        {
        //            return (data.para_type != null && data.para_type.ToLower().Contains(_FilterStringPara.ToLower()) ||
        //                    data.cat_type_desc != null && data.cat_type_desc.ToString().ToLower().Contains(_FilterStringPara.ToLower())

        //                    );
        //        }
        //        return true;
        //    }
        //    return false;
        //}

        #endregion

        #endregion

        #region Event Handler
        void ModelUpdated_Operation(object sender, EventArgs e)
        {
            try
            {
                if (EntityChangeEnable == true && ENG_T005_A_OBJ != null)
                {
                    //This will get called when the property of an object inside the collection changes
                    if (sender.ToString() == "location_id")
                    {
                        if (MC.WC_LIST.Where(x => x.location_id == ENG_T005_A_OBJ.location_id && x.wc_code == ENG_T005_A_OBJ.wc_code).ToList().Count == 0)
                        {
                            ENG_T005_A_OBJ.wc_code = null;
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
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false; /*MasterEntity.HasErrors;*/
            if (OperationEntity.Count > dgIndex_A && dgIndex_A >= 0)
            {
                this.ErrorExist = false;/*ParameterEntity[dgSelectedIndexItem].HasErrors;*/
            }
        }

        private void CollectionChangedNotifyForOperationEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ENG_T005_A item in e.NewItems)
                    {
                        item.id = 0;
                        item.active = "1";
                        item.client = AppSessionState.client;
                        item.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        item.location_id = AppSessionState.OBJ_LOCATION.location_id;
                        item.t_status = "01";
                        item.valid_from = System.DateTime.Now;
                        item.line_id = OperationEntity.Count;
                        item.valid_from = MasterEntity.valid_from;
                        item.doc_no = MasterEntity.doc_no;
                        item.doc_cat = MasterEntity.doc_cat;
                        item.doc_type = MasterEntity.doc_type;
                        item.op_no = (OperationEntity.Count * 10).ToString();
                        item.op_seq = OperationEntity.Count;
                        item.base_qty = 1;

                        if(MC.OPERATION_LIST != null)
                        {
                            if (MC.OPERATION_LIST.Count == 1)
                            {
                                item.op_code = MC.OPERATION_LIST[0].op_code;
                                item.op_name = MC.OPERATION_LIST[0].op_name;
                            }
                        }

                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove) //NOTE: use this section to remove dependant entries. like if Operation remove then all char data need to remove from Char Entity
                {
                    ENG_T005_A temp = (ENG_T005_A)e.OldItems[0];
                    var itemToRemove1 = OperationEntity.Where(x => (x.op_no == temp.op_no && x.op_no == "")).ToList();

                    foreach (var a in itemToRemove1)
                    {
                        if (a.op_no == "")
                        {
                            OperationEntity.Remove(a);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void CollectionChangedNotifyForCharEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ENG_T005_B item in e.NewItems)
                    {
                        item.id = 0;
                        item.active = "1";
                        item.char_no = CharEntity.Count;
                        item.line_id = CharEntity.Count;
                        item.comp_code = ENG_T005_A_OBJ.comp_code;
                        item.location_id = ENG_T005_A_OBJ.location_id;
                        item.client = AppSessionState.client;
                        item.t_status = "01";
                        item.valid_from = MasterEntity.valid_from;
                        item.line_id = CharEntity.Count;
                        item.op_no = ENG_T005_A_OBJ.op_no;
                        item.line_id_op = ENG_T005_A_OBJ.line_id;
                        item.op_row_id = ENG_T005_A_OBJ.id;
                        item.doc_no = MasterEntity.doc_no;
                        item.doc_cat = MasterEntity.doc_cat;
                        item.doc_type = MasterEntity.doc_type;

                        if (MC.PROCEDURE_LIST != null)
                        {
                            if (MC.PROCEDURE_LIST.Count == 1)
                            {
                                item.samp_pro_char = MC.PROCEDURE_LIST[0].value_code;
                            }
                        }

                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove) //NOTE: use this section to remove dependant entries. like if Operation remove then all char data need to remove from Char Entity
                {
                    ENG_T005_B temp = (ENG_T005_B)e.OldItems[0];
                    var itemToRemove1 = OperationEntity.Where(x => (x.op_no == temp.op_no && x.op_no == "")).ToList();

                    foreach (var a in itemToRemove1)
                    {
                        if (a.op_no == "")
                        {
                            OperationEntity.Remove(a);
                        }
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        private void CollectionChangedNotifyForSelectedSetEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ENG_T005_C item in e.NewItems)
                    {
                        item.id = 0;
                        item.active = "1";
                        item.comp_code = ENG_T005_A_OBJ.comp_code;
                        item.location_id = ENG_T005_A_OBJ.location_id;
                        item.client = AppSessionState.client;
                        item.t_status = "01";
                        item.op_no = ENG_T005_A_OBJ.op_no;
                        item.line_id_op = ENG_T005_A_OBJ.line_id;
                        item.op_row_id = ENG_T005_A_OBJ.id;
                        item.doc_no = MasterEntity.doc_no;
                        item.line_id_ic = ENG_T005_B_OBJ.line_id;
                        item.char_code = ENG_T005_B_OBJ.char_code;
                        item.char_row_id = ENG_T005_B_OBJ.id;
                        item.doc_cat = MasterEntity.doc_cat;
                        item.doc_type = MasterEntity.doc_type;

                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {}
            }
            catch (Exception ex)
            { }
        }
        private void CollectionChangedNotifyForComponantEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ENG_T005_R item in e.NewItems)
                    {
                        item.id = 0;
                        item.active = "1";
                        item.comp_code = ENG_T005_A_OBJ.comp_code;
                        item.location_id = ENG_T005_A_OBJ.location_id;
                        item.client = AppSessionState.client;
                        item.op_row_id = ENG_T005_A_OBJ.id;
                        item.line_id_A = ENG_T005_A_OBJ.line_id;
                        item.valid_from = MasterEntity.valid_from;
                        item.doc_no = MasterEntity.doc_no;

                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {}
            }
            catch (Exception ex)
            { }
        }
        private void CollectionChangedNotifyForAssignmentEntity(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (ENG_T005_M item in e.NewItems)
                    {
                        item.id = 0;
                        item.active = "1";
                        item.comp_code = MasterEntity.comp_code;
                        item.location_id = MasterEntity.location_id;
                        item.client = AppSessionState.client;
                        item.valid_from = MasterEntity.valid_from;
                        item.doc_no = MasterEntity.doc_no;

                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {}
            }
            catch (Exception ex)
            { }
        }


        #endregion
    }
}
