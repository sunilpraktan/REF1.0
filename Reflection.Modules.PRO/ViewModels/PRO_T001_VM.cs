using Reflection.Presentation.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using Reflection.Presentation.Services;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using System.Windows.Controls;
using Reflection.Presentation.Controls.AutoSuggestTextBox.GUI;
using Reflection.Presentation.Controls;
using GalaSoft.MvvmLight.Messaging;
using Reflection.Presentation.Services.Convertors;
using System.Windows;
using System.Collections.Specialized;
using Reflection.Presentation.Common;
using Reflection.BusinessEntity.COM;
using Reflection.BusinessEntity.ADM;
using System.Reflection;
using System.IO;
using Reflection.Presentation.Core.VirtualDesktops;
using GalaSoft.MvvmLight.Ioc;

namespace Reflection.Modules.PRO.ViewModels
{
    public class PRO_T001_VM : WorkspaceViewModel<PUR_T001_A>
    {
        bool NewRecord = true;
        WebServiceRepository<PUR_T001_A> repository = new WebServiceRepository<PUR_T001_A>();
        WebServiceRepository<MultipleContext_PUR_T001_A> repositoryM = new WebServiceRepository<MultipleContext_PUR_T001_A>();
        ObjectSerializationService objSer = new ObjectSerializationService();

        #region Auto Suggest Initalization Region
        public static readonly DependencyProperty AutoSuggestTextViewModelProperty = DependencyProperty.Register("AutoSuggestTextViewModel", typeof(AutoSuggestTextViewModel<dynamic>), typeof(PRO_T001_VM));
        public AutoSuggestTextViewModel<dynamic> AutoSuggestTextViewModel { get { return (AutoSuggestTextViewModel<dynamic>)GetValue(AutoSuggestTextViewModelProperty); } set { SetValue(AutoSuggestTextViewModelProperty, value); } }

        public Func<object, string, bool> TheFilter { get; set; }
        public static IValueConverter SuggestedValue { get; set; }
        public AutoSuggestViewModel AutoSuggestVM { get; set; }
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
                    else if (SourceName == "unit_code")
                    { ASDefault = ASUnit; }
                    else if (SourceName == "user_source1")
                    {
                        ASDefault = ASParameterValues2;
                        //var MakeData = (from o in MC.ParamValueList where o.para_code == "27" select o).ToList();
                        //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M030_P)x).parametervalue);
                        //TheFilter = (o, prefix) => (((ADM_M030_P)o).para_code  ?? "").ToString().ToLower().Contains("27") && (((ADM_M030_P)o).parametervalue ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        //ASParameterValues = new AutoSuggestTextViewModel<dynamic>(MakeData, TheFilter, SuggestedValue, "para1", "parametervalue", true);
                        //ASParameterValues.AutoSuggestVM.IsEmptyValueAllowed = true;
                        //ASDefault = ASParameterValues;
                    }
                    else if (SourceName == "user_source2")
                    {
                        ASDefault = ASParameterValues3;
                        //var TypeData = (from o in MC.ParamValueList where o.para_code == "28" select o).ToList();
                        //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M030_P)x).parametervalue);
                        //TheFilter = (o, prefix) => (((ADM_M030_P)o).para_code ?? "").ToString().ToLower().Contains("28") && (((ADM_M030_P)o).parametervalue ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        //ASParameterValues = new AutoSuggestTextViewModel<dynamic>(TypeData, TheFilter, SuggestedValue, "para2", "parametervalue", true);
                        //ASParameterValues.AutoSuggestVM.IsEmptyValueAllowed = true;
                        //ASDefault = ASParameterValues;
                    }
                    else if (SourceName == "sono")
                    { ASDefault = ASOrder; }
                    else if (SourceName == "item_cat")
                    { ASDefault = ASItemCat; }
                    else if (SourceName == "t_status_i")
                    { ASDefault = ASStatusItem; }
                    else if (SourceName == "bom_no")
                    { ASDefault = ASBOMRef; }
                    else if (SourceName == "pr_order_no")
                    { ASDefault = AS_OPERATIONS; }

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

        private AutoSuggestTextViewModel<dynamic> _ASRequester { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASRequester
        {
            get { return _ASRequester; }
            set
            {
                if (_ASRequester != value)
                {
                    _ASRequester = value; RaisePropertyChanged("ASRequester");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPriority { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPriority
        {
            get { return _ASPriority; }
            set
            {
                if (_ASPriority != value)
                {
                    _ASPriority = value; RaisePropertyChanged("ASPriority");
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
        private AutoSuggestTextViewModel<dynamic> _ASCompany { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASCompany
        {
            get { return _ASCompany; }
            set
            {
                if (_ASCompany != value)
                {
                    _ASCompany = value; RaisePropertyChanged("ASCompany");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASPlant { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPlant
        {
            get { return _ASPlant; }
            set
            {
                if (_ASPlant != value)
                {
                    _ASPlant = value; RaisePropertyChanged("ASPlant");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASDepartment { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASDepartment
        {
            get { return _ASDepartment; }
            set
            {
                if (_ASDepartment != value)
                {
                    _ASDepartment = value; RaisePropertyChanged("ASDepartment");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASProject { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASProject
        {
            get { return _ASProject; }
            set
            {
                if (_ASProject != value)
                {
                    _ASProject = value; RaisePropertyChanged("ASProject");
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

        private AutoSuggestTextViewModel<dynamic> _ASOrder { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASOrder
        {
            get { return _ASOrder; }
            set
            {
                if (_ASOrder != value)
                {
                    _ASOrder = value; RaisePropertyChanged("ASOrder");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASItemCat { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASItemCat
        {
            get { return _ASItemCat; }
            set
            {
                if (_ASItemCat != value)
                {
                    _ASItemCat = value; RaisePropertyChanged("ASItemCat");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASStatusItem { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASStatusItem
        {
            get { return _ASStatusItem; }
            set
            {
                if (_ASStatusItem != value)
                {
                    _ASStatusItem = value; RaisePropertyChanged("ASStatusItem");
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
        private AutoSuggestTextViewModel<dynamic> _ASBOMRef { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASBOMRef
        {
            get { return _ASBOMRef; }
            set
            {
                if (_ASBOMRef != value)
                {
                    _ASBOMRef = value; RaisePropertyChanged("ASBOMRef");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _AS_OPERATIONS { get; set; }
        public AutoSuggestTextViewModel<dynamic> AS_OPERATIONS
        {
            get { return _AS_OPERATIONS; }
            set
            {
                if (_AS_OPERATIONS != value)
                {
                    _AS_OPERATIONS = value; RaisePropertyChanged("AS_OPERATIONS");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASPurOrg { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPurOrg
        {
            get { return _ASPurOrg; }
            set
            {
                if (_ASPurOrg != value)
                {
                    _ASPurOrg = value; RaisePropertyChanged("ASPurOrg");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASPurGrp { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASPurGrp
        {
            get { return _ASPurGrp; }
            set
            {
                if (_ASPurGrp != value)
                {
                    _ASPurGrp = value; RaisePropertyChanged("ASPurGrp");
                }
            }
        }

        private AutoSuggestTextViewModel<dynamic> _ASParameterValues { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASParameterValues
        {
            get { return _ASParameterValues; }
            set
            {
                if (_ASParameterValues != value)
                {
                    _ASParameterValues = value; RaisePropertyChanged("ASParameterValues");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASParameterValues2 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASParameterValues2
        {
            get { return _ASParameterValues2; }
            set
            {
                if (_ASParameterValues2 != value)
                {
                    _ASParameterValues2 = value; RaisePropertyChanged("ASParameterValues2");
                }
            }
        }


        private AutoSuggestTextViewModel<dynamic> _ASParameterValues3 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASParameterValues3
        {
            get { return _ASParameterValues3; }
            set
            {
                if (_ASParameterValues3 != value)
                {
                    _ASParameterValues3 = value; RaisePropertyChanged("ASParameterValues3");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASParameterValues4 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASParameterValues4
        {
            get { return _ASParameterValues4; }
            set
            {
                if (_ASParameterValues4 != value)
                {
                    _ASParameterValues4 = value; RaisePropertyChanged("ASParameterValues4");
                }
            }
        }
        private AutoSuggestTextViewModel<dynamic> _ASParameterValues5 { get; set; }
        public AutoSuggestTextViewModel<dynamic> ASParameterValues5
        {
            get { return _ASParameterValues5; }
            set
            {
                if (_ASParameterValues5 != value)
                {
                    _ASParameterValues5 = value; RaisePropertyChanged("ASParameterValues5");
                }
            }
        }
        #endregion

        #region Declaration
        private ICollectionView _dataGridCollection;
        public string ts_code_vm { get; set; }
        public string doc_cat_vm { get; set; }
        public string doc_no_vm { get; set; }
        private bool _EntityChangeEnable;
        private bool EntityChangeEnable
        {
            get { return _EntityChangeEnable; }
            set
            {
                if (_EntityChangeEnable != value)
                {
                    _EntityChangeEnable = value; RaisePropertyChanged("EntityChangeEnable");
                }
            }
        }

        private int _dgSelectedIndex;
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
        private List<PUR_T001_A> _SelectedList;
        public List<PUR_T001_A> SelectedList
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
        private STD_LIST_BE _REF_OBJECT;
        public STD_LIST_BE REF_OBJECT
        {
            get { return _REF_OBJECT; }
            set
            {
                if (_REF_OBJECT != value)
                {
                    _REF_OBJECT = value; RaisePropertyChanged("REF_OBJECT");
                }
            }
        }
        private PUR_T001_A _MasterEntity;
        public PUR_T001_A MasterEntity
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
                    value.BeginEdit();
                }
            }
        }
        private PUR_T001_B _ITEM_OBJ;
        public PUR_T001_B ITEM_OBJ
        {
            get
            {
                return _ITEM_OBJ;
            }
            set
            {
                if (_ITEM_OBJ != value)
                {
                    _ITEM_OBJ = value;
                    RaisePropertyChanged("ITEM_OBJ");
                }
            }
        }
        private List<ADM_M002> _CompanyList = new List<ADM_M002>();
        public List<ADM_M002> CompanyList
        {
            get { return _CompanyList; }
            set
            {
                if (_CompanyList != value)
                {
                    _CompanyList = value;
                }
            }
        }
        public List<ADM_M003> _locationList;
        public List<ADM_M003> LocationList
        {
            get
            {
                return _locationList;
            }
            set
            {
                _locationList = value;
                RaisePropertyChanged("LocationList");
            }
        }

        string CompanyName;

        private PUR_T001_AFlip _FilpEntity;
        public PUR_T001_AFlip FilpEntity
        {
            get
            {

                return _FilpEntity;
            }
            set
            {
                if (_FilpEntity != value)
                {
                    _FilpEntity = value;
                    RaisePropertyChanged("FilpEntity");

                }
            }
        }


        private List<PUR_T001_AFlip> _FlipGridData;
        public List<PUR_T001_AFlip> FlipGridData
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

        private List<ADM_M031_P> _SelectedParaValueCollection = new List<ADM_M031_P>();
        public List<ADM_M031_P> SelectedParaValueCollection
        {
            get { return _SelectedParaValueCollection; }
            set
            {
                if (_SelectedParaValueCollection != value)
                {
                    _SelectedParaValueCollection = value;
                    RaisePropertyChanged("SelectedParaValueCollection");
                }
            }
        }
        private int _ParadgSelectedIndex;

        public int ParadgSelectedIndex
        {
            get
            {
                return _ParadgSelectedIndex;
            }
            set
            {
                if (_ParadgSelectedIndex != value)
                {
                    _ParadgSelectedIndex = value;
                    RaisePropertyChanged("ParadgSelectedIndex");
                }
            }
        }
        private List<ADM_M031_P> _ParameterTemp = new List<ADM_M031_P>();
        public List<ADM_M031_P> ParameterTemp
        {
            get { return _ParameterTemp; }
            set
            {
                if (_ParameterTemp != value)
                {
                    _ParameterTemp = value;
                }
            }
        }
        private ICollectionView _doc_typeCollection;
        public ICollectionView doc_typeCollection
        {
            get { return _doc_typeCollection; }
            set
            {
                _doc_typeCollection = value;
                RaisePropertyChanged("doc_typeCollection");
            }
        }
        private ICollectionView _SOCollection;
        public ICollectionView SOCollection
        {
            get { return _SOCollection; }
            set
            {
                _SOCollection = value;
                RaisePropertyChanged("SOCollection");
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
        public List<ADM_M001_M_P> _PurchaseOrganisationList;
        public List<ADM_M001_M_P> PurchaseOrganisationList
        {
            get
            {
                return _PurchaseOrganisationList;
            }
            set
            {
                _PurchaseOrganisationList = value;
                RaisePropertyChanged("PurchaseOrganisationList");
            }
        }
        public List<ADM_M001_P_P> _PurchaseGroupList;
        public List<ADM_M001_P_P> PurchaseGroupList
        {
            get
            {
                return _PurchaseGroupList;
            }
            set
            {
                _PurchaseGroupList = value;
                RaisePropertyChanged("PurchaseGroupList");
            }
        }

        List<ADM_M022_P> _ItemList = new List<ADM_M022_P>();
        public List<ADM_M022_P> ItemList
        {
            get { return _ItemList; }
            set
            {
                if (_ItemList != value)
                {
                    _ItemList = value;

                    RaisePropertyChanged("ItemList");
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
                    _isTabChangeAllowed = value;
                    RaisePropertyChanged("isTabChangeAllowed");
                }
            }
        }
        MultipleContext_PUR_T001_A _MC = new MultipleContext_PUR_T001_A();
        public MultipleContext_PUR_T001_A MC
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
        MultipleContext_PUR_T001_A MCTemp = new MultipleContext_PUR_T001_A();

        private SearchEntity _SearchEntityObject;
        public SearchEntity SearchEntityObject
        {
            get
            {
                return _SearchEntityObject;
            }
            set
            {
                if (_SearchEntityObject != value)
                {
                    _SearchEntityObject = value;
                    RaisePropertyChanged(nameof(SearchEntityObject));
                }
            }
        }
#pragma warning disable CS0108 // Member hides inherited member; missing new keyword
        #endregion
        #region Validation Region
        void Model_ItemUpdated(object sender, EventArgs e)
        {
            this.ErrorExist = MasterEntity.HasErrors;

        }


        #endregion

        #region Schedule Declaration
        // Selected Index for Items DataGrid 
        private int _dgSelectedIndexItemSchedule;
        public int dgSelectedIndexItemSchedule
        {
            get
            {
                return _dgSelectedIndexItemSchedule;
            }
            set
            {
                if (_dgSelectedIndexItemSchedule != value)
                {
                    _dgSelectedIndexItemSchedule = value;
                    RaisePropertyChanged("dgSelectedIndexItemSchedule");
                }
            }
        }

        private ObservableCollection<PUR_T001_C> _dgItemScheduleEntity;
        public ObservableCollection<PUR_T001_C> dgItemScheduleEntity
        {
            get
            {
                return _dgItemScheduleEntity;
            }
            set
            {
                if (_dgItemScheduleEntity != value)
                {
                    _dgItemScheduleEntity = value;
                    _dgItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
                    RaisePropertyChanged("dgItemScheduleEntity");
                }
            }
        }

        private List<COM_T011> _ReleaseList;
        public List<COM_T011> ReleaseList
        {
            get
            {
                return _ReleaseList;
            }
            set
            {
                if (_ReleaseList != value)
                {
                    _ReleaseList = value;
                    RaisePropertyChanged("ReleaseList");
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
                    FilterScheduleDataGrid();
                }
            }
        }

        private ICollectionView _dataGridviewFilter;
        // This DataGridView filter Schedule Lines for selected item. it will show only schedule for selected item.
        public ICollectionView DataGridViewFilter
        {
            get { return _dataGridviewFilter; }
            set { _dataGridviewFilter = value; RaisePropertyChanged("DataGridViewFilter"); }
        }

        #endregion

        #region ICollection
        public ICollectionView DataGridCollection
        {
            get { return _dataGridCollection; }
            set { _dataGridCollection = value; RaisePropertyChanged("DataGridCollection"); }
        }
        private ICollectionView _PriorityCollection;
        public ICollectionView PriorityCollection
        {
            get { return _PriorityCollection; }
            set
            {
                _PriorityCollection = value;

                RaisePropertyChanged("PriorityCollection");
            }
        }


        private ICollectionView _EmpCollection;
        public ICollectionView EmpCollection
        {
            get { return _EmpCollection; }
            set
            {
                _EmpCollection = value;

                RaisePropertyChanged("EmpCollection");
            }
        }

        private ICollectionView _ItemsCollection;
        public ICollectionView ItemsCollection
        {
            get { return _ItemsCollection; }
            set
            {
                _ItemsCollection = value;

                RaisePropertyChanged("ItemsCollection");
            }
        }

        private ICollectionView _uomCollection;
        public ICollectionView uomCollection
        {
            get { return _uomCollection; }
            set
            {
                _uomCollection = value;

                RaisePropertyChanged("uomCollection");
            }
        }

        private ICollectionView _itemcategoryCollection;
        public ICollectionView itemcategoryCollection
        {
            get { return _itemcategoryCollection; }
            set
            {
                _itemcategoryCollection = value;
                RaisePropertyChanged("itemcategoryCollection");
            }
        }

        private List<NotificationData> _NotificationDataCollection;
        public List<NotificationData> NotificationDataCollection
        {
            get { return _NotificationDataCollection; }
            set
            {
                if (_NotificationDataCollection != value)
                {
                    _NotificationDataCollection = value;
                    RaisePropertyChanged("NotificationDataCollection");
                }
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

        private ICollectionView _ParameterCollection;
        public ICollectionView ParameterCollection
        {
            get { return _ParameterCollection; }
            set
            {
                _ParameterCollection = value;
                RaisePropertyChanged("ParameterCollection")
                ;
            }
        }

        //private ICollectionView _ParameterValueCollection;
        //public ICollectionView ParameterValueCollection
        //{
        //    get { return _ParameterValueCollection; }
        //    set
        //    {
        //        _ParameterValueCollection = value;
        //        RaisePropertyChanged("ParameterValueCollection");
        //    }
        //}

        private ICollectionView _TotalParameterCollection;
        public ICollectionView TotalParameterCollection
        {
            get { return _TotalParameterCollection; }
            set
            {
                _TotalParameterCollection = value;
                RaisePropertyChanged("TotalParameterCollection")
               ;
            }
        }



        #endregion

        #region StringList Variables
        List<string> _strListPriority;
        public List<string> StringListPriority
        {
            get { return _strListPriority; }
            set
            {
                if (_strListPriority != value)
                {
                    _strListPriority = value;
                }
            }
        }


        List<string> _strListEmployee;
        public List<string> StringListEmployee
        {
            get { return _strListEmployee; }
            set
            {
                if (_strListEmployee != value)
                {
                    _strListEmployee = value;
                }
            }
        }

        List<string> _strListType;
        public List<string> StringListType
        {
            get { return _strListType; }
            set
            {
                if (_strListType != value)
                {
                    _strListType = value;
                }
            }
        }

        List<string> _strListDept;
        public List<string> StringListDept
        {
            get { return _strListDept; }
            set
            {
                if (_strListDept != value)
                {
                    _strListDept = value;
                }
            }
        }

        List<string> _stringListItems;
        public List<string> StringListItems
        {
            get { return _stringListItems; }
            set
            {
                if (_stringListItems != value)
                {
                    _stringListItems = value;
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


        List<string> _stringListPlant;
        public List<string> stringListPlant
        {
            get { return _stringListPlant; }
            set
            {
                if (_stringListPlant != value)
                {
                    _stringListPlant = value;
                }
            }
        }

        List<string> _stringListStoreLoc;
        public List<string> stringListStoreLoc
        {
            get { return _stringListStoreLoc; }
            set
            {
                if (_stringListStoreLoc != value)
                {
                    _stringListStoreLoc = value;
                }
            }
        }

        List<string> _stringListBatch;
        public List<string> stringListBatch
        {
            get { return _stringListBatch; }
            set
            {
                if (_stringListBatch != value)
                {
                    _stringListBatch = value;
                }
            }
        }
        List<string> _stringListItemCategory;
        public List<string> StringListItemCategory
        {
            get { return _stringListItemCategory; }
            set
            {
                if (_stringListItemCategory != value)
                {
                    _stringListItemCategory = value;
                }
            }
        }

        private List<string> _StringListSO;
        public List<string> StringListSO
        {
            get { return _StringListSO; }
            set
            {
                if (_StringListSO != value)
                {
                    _StringListSO = value;
                }
            }
        }

        List<string> _strListIndent;
        public List<string> StringListIndent
        {
            get { return _strListIndent; }
            set
            {
                if (_strListIndent != value)
                {
                    _strListIndent = value;
                }
            }
        }


        #endregion

        #region RelayCommand
        public RelayCommand<object> cmdGeneratePR { get; private set; }
        public RelayCommand<object> cmdInvoke_Reference_Document { get; private set; }
        public RelayCommand<object> cmdWindowLoadEvent { get; private set; }
        public RelayCommand<object> cmdInsertDepartment { get; private set; }
        public RelayCommand<object> cmdInsertProjectElement { get; private set; }
        public RelayCommand<object> cmdInsertStatusItem { get; private set; }
        public RelayCommand<object> CommandDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CommandDeleteScheduleItem { get; private set; }
        public RelayCommand<object> cmdInsertOperation { get; private set; }
        public RelayCommand<object> SelectionChangedCommandPriority
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandEmp
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommandItems
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectionChangedCommanduom
        {
            get;
            private set;
        }
        public RelayCommand<object> DataGridRowDeleteCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> ParameterPopupCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> CollectionChangedMethod
        {
            get;
            private set;
        }
        public RelayCommand<object> SelectedCommand_itemcategory { get; private set; }
        public RelayCommand<IList> CollectionChangedCommand
        {
            get;
            private set;
        }
        public RelayCommand<IList> SelectionChangedParaValCommand
        {
            get;
            private set;
        }
        public RelayCommand<object> CommandAddItemCategory { get; private set; }
        public RelayCommand<IList> SelectionChangeCommandItemDetails { get; private set; }
        public RelayCommand<IList> CommandLoadDataFromBackFlip { get; private set; }
        public RelayCommand<object> CmdAddSO { get; private set; }
        public RelayCommand<object> CmdAddBOM { get; private set; }
        public RelayCommand<object> CmdInsert_t_status { get; private set; }
        public RelayCommand<object> SelectionChangedCommandPurchaseGroup { get; private set; }
        public RelayCommand<object> CommandLoadBackFlipData { get; private set; }

        // SKU Hardcoded Command
        public RelayCommand<object> cmdMasterMake { get; private set; }
        public RelayCommand<object> CommandInsertMake { get; private set; }
        public RelayCommand<object> CommandInsertType { get; private set; }
        public RelayCommand<object> cmdMasterType { get; private set; }
        //public RelayCommand<object> CmdInsertCompany { get; private set; }
        //public RelayCommand<object> CmdInsertLocationId { get; private set; }

        private string _MasterMake;
        public string MasterMake
        {
            get { return _MasterMake; }
            set { _MasterMake = value; RaisePropertyChanged("MasterMake"); }
        }
        private string _MasterMakeCode;
        public string MasterMakeCode
        {
            get { return _MasterMakeCode; }
            set { _MasterMakeCode = value; RaisePropertyChanged("MasterMakeCode"); }
        }
        private string _MasterType;
        public string MasterType
        {
            get { return _MasterType; }
            set { _MasterType = value; RaisePropertyChanged("MasterType"); }
        }
        private string _MasterTypeCode;
        public string MasterTypeCode
        {
            get { return _MasterTypeCode; }
            set { _MasterTypeCode = value; RaisePropertyChanged("MasterTypeCode"); }
        }

        #endregion

        #region PUR_T001_B

        private ObservableCollection<PUR_T001_B> _Pur_Req_Details = new ObservableCollection<PUR_T001_B>();
        public ObservableCollection<PUR_T001_B> Pur_Req_Details
        {
            get { return _Pur_Req_Details; }
            set
            {
                if (_Pur_Req_Details != value)
                {
                    _Pur_Req_Details = value;
                    _Pur_Req_Details.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
                    RaisePropertyChanged("Pur_Req_Details");
                }
            }
        }
        public PUR_T001_B _SelectedPUR_T001_B { get; private set; }
        public PUR_T001_B SelectedPUR_T001_B
        {
            get { return _SelectedPUR_T001_B; }
            set
            {
                if (_SelectedPUR_T001_B != value)
                {
                    _SelectedPUR_T001_B = value;
                    RaisePropertyChanged("SelectedPUR_T001_B");
                    // value.BeginEdit();
                }
            }
        }
        private List<PUR_T001_B> _SelectedPUR_T001_B_List;
        public List<PUR_T001_B> SelectedPUR_T001_B_List
        {
            get
            {
                return _SelectedPUR_T001_B_List;
            }
            set
            {
                _SelectedPUR_T001_B_List = value;
                RaisePropertyChanged("SelectedPUR_T001_B_List");
            }
        }

        #endregion

        public PRO_T001_VM(string doc_cat,string ts_code)
            : base()
        {
            CursorControl.SetBusyState();
            this.ts_code_vm = ts_code;
            doc_cat_vm = doc_cat;
            parameter = false;
            SearchEntityObject = new SearchEntity();
            MasterEntity = new PUR_T001_A();
            ITEM_OBJ = new PUR_T001_B();
            Pur_Req_Details = new ObservableCollection<PUR_T001_B>();//detail table observable collection
            dgItemScheduleEntity = new ObservableCollection<PUR_T001_C>();
            FlipGridData = new List<PUR_T001_AFlip>();
            ApprovalData = new List<ADM_M043_D>();
            MC = new MultipleContext_PUR_T001_A();
            MCTemp = new MultipleContext_PUR_T001_A();
            MasterEntity.ValidateAsync().Wait();
            NotificationDataCollection = new List<NotificationData>();

            PUR_T001_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            PUR_T001_B.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            PUR_T001_C.ModelEntityUpdated += new EventHandler(ModelUpdatedShedule);

            Pur_Req_Details.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            dgItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);

            CommandInitialization();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public PRO_T001_VM(string doc_cat, string ts_code, string doc_no)
            : base()
        {
            CursorControl.SetBusyState();
            this.ts_code_vm = ts_code;
            this.doc_no_vm = doc_no;
            doc_cat_vm = doc_cat;
            parameter = false;
            SearchEntityObject = new SearchEntity();
            MasterEntity = new PUR_T001_A();
            ITEM_OBJ = new PUR_T001_B();
            Pur_Req_Details = new ObservableCollection<PUR_T001_B>();//detail table observable collection
            dgItemScheduleEntity = new ObservableCollection<PUR_T001_C>();
            FlipGridData = new List<PUR_T001_AFlip>();
            ApprovalData = new List<ADM_M043_D>();
            MC = new MultipleContext_PUR_T001_A();
            MCTemp = new MultipleContext_PUR_T001_A();
            MasterEntity.ValidateAsync().Wait();
            NotificationDataCollection = new List<NotificationData>();

            PUR_T001_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            PUR_T001_B.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            PUR_T001_C.ModelEntityUpdated += new EventHandler(ModelUpdatedShedule);

            Pur_Req_Details.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            dgItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
            CommandInitialization();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }
        public PRO_T001_VM(string ts_code, STD_LIST_BE REF_OBJ) : base()
        {
            CursorControl.SetBusyState();
            this.ts_code_vm = ts_code;
            this.doc_no_vm = REF_OBJ.doc_no;
            doc_cat_vm = REF_OBJ.doc_cat;
            REF_OBJECT = new STD_LIST_BE();
            REF_OBJECT = REF_OBJ;

            parameter = false;
            SearchEntityObject = new SearchEntity();
            MasterEntity = new PUR_T001_A();
            ITEM_OBJ = new PUR_T001_B();
            Pur_Req_Details = new ObservableCollection<PUR_T001_B>();//detail table observable collection
            dgItemScheduleEntity = new ObservableCollection<PUR_T001_C>();
            FlipGridData = new List<PUR_T001_AFlip>();
            ApprovalData = new List<ADM_M043_D>();
            MC = new MultipleContext_PUR_T001_A();
            MCTemp = new MultipleContext_PUR_T001_A();
            MasterEntity.ValidateAsync().Wait();
            NotificationDataCollection = new List<NotificationData>();

            PUR_T001_A.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            PUR_T001_B.ModelEntityUpdated += new EventHandler(Model_ItemUpdated);
            PUR_T001_C.ModelEntityUpdated += new EventHandler(ModelUpdatedShedule);

            Pur_Req_Details.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForItem);
            dgItemScheduleEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForSchedule);
            CommandInitialization();
            Messenger.Default.Register<NotificationMessage>(this, NotificationMessageReceived);
        }

        private void LoadBackFilpDetailstemp(Object ParameterObject)
        {
            try
            {
                string Request = "";
                if (ParameterObject.GetType() == typeof(string))
                {
                    Request = "LoadDocumentFromBackFilp" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id.ToString() + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + ParameterObject.ToString() + "!@" + AppSessionState.EmpId + "!@" + "" + "!@" + AppSessionState.UserID;
                }
                else
                {
                    IList list = ParameterObject as IList;
                    List<PUR_T001_AFlip> GetSelectedChangedTemp = list.Cast<PUR_T001_AFlip>().ToList();

                    FilpEntity = (PUR_T001_AFlip)GetSelectedChangedTemp[0];
                    Request = "LoadDocumentFromBackFilp" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id.ToString() + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + FilpEntity.req_no + "!@" + AppSessionState.EmpId + "!@" + "" + "!@" + AppSessionState.UserID;
                }
                
                MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_PUR_T001_A>(MCTemp, Request, "PRO_T001_BL", "PRO", "LoadDocumentFromBackFilp", 0, "");
                MasterEntity = MCTemp.Pur_Req[0];
                Pur_Req_Details = MCTemp.Pur_Req_Details;
                dgItemScheduleEntity = MCTemp.Pur_Req_Schedule;
                ReleaseList = MCTemp.WORKFLOW_LIST;
                AttachmentCollection = MCTemp.Attachment;
                ApprovalData = MCTemp.APPROVALS;

                SelectedTabControlIndex = 0;
                NewRecord = false;
                parameter = false;
                MasterEntity.ts_code = ts_code_vm;
                var msg = new NotificationMessage("PRO_T001_VM");
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
                if (REF_OBJECT != null && REF_OBJECT.req_code == "VIEW")
                {
                    //List<STD_LIST_BE> STD_LIST_OBJ = new List<STD_LIST_BE>();
                    //STD_LIST_OBJ.Add(REF_OBJECT);
                    LoadInitialData();
                    LoadBackFilpDetailstemp(REF_OBJECT.doc_no);
                }
                else if (doc_no_vm != null && ts_code_vm != null)
                {
                    //LoadDocumentByDocumentNumber(doc_no_vm, "DocumentNo");
                    LoadBackFilpDetailstemp(doc_no_vm);
                    isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                    AppSessionState.ViewOtherRecordAllowed = true;
                }
                else
                {
                    LoadInitialData();
                    DefaultValues();
                }
                var msg = new NotificationMessage("PRO_T001_VM");
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
                            { POPUPEntityObject = MC.STATUS_LIST.Where(x => x.t_status.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_display.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
        private void InsertPriority(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M040_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Priorities.Where(x => x.pr_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M040_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }
                #endregion
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {
                    MasterEntity.priority = POPUPEntityObject.pr_code;
                    MasterEntity.priorityNm = POPUPEntityObject.text_name;

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
            try
            {
                string Request = "";
                ADM_M024_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.Employees.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_P>().ToList()[0];
                    }

                }
                catch (Exception ex) { }
                #endregion
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {
                    MasterEntity.EmpId = POPUPEntityObject.EmpId;
                    MasterEntity.EmpNm = POPUPEntityObject.EmpName;
                    MasterEntity.dept_code = POPUPEntityObject.dept_code;
                    MasterEntity.dept_name = POPUPEntityObject.DeptName;


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
        private void InsertDataGridRow_Item(object InputValue, bool NewRow, object item_obj)
        {
            string Request = "";
            ADM_M022_P POPUPEntityObject = null;
            STD_LIST_BE OBJ_SL = null;
            dgSelectedIndexItem = dgSelectedIndexItem;
            #region Command Parameter Read Section
            if (item_obj != null && item_obj.GetType() == typeof(STD_LIST_BE)) // if function called from PR Automation
            {
                OBJ_SL = (STD_LIST_BE)item_obj;
            }
            else
            {
                OBJ_SL = new STD_LIST_BE();
            }

            // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    {
                        POPUPEntityObject = MC.ItemList.Where(x => x.ItemCode.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];

                    }
                    catch (Exception ex)
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message: Material not exists!";
                        showMessageService.Text = String.Format("Material not exists or not assign its category for this document!", this.Title);
                        showMessageService.ShowMessage();
                    }
                }
            }
            else if (InputValue != null)
            {
                if (((IEnumerable)InputValue).Cast<ADM_M022_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M022_P>().ToList()[0];
                }
            }

            #endregion

            if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
            {
                //var InputValueIfExists = Pur_Req_Details.Where(X => X.ItemCode == POPUPEntityObject.ItemCode).FirstOrDefault(); // Prefer Primary Key for this instruction.
                int IndexOfExistValue = Pur_Req_Details.IndexOf(Pur_Req_Details.Where(X => X.ItemCode == POPUPEntityObject.ItemCode && X.ref_doc_cat== OBJ_SL.ref_doc_cat && X.ref_item_row_id == OBJ_SL.item_row_id).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.
                if(IndexOfExistValue >= 0)
                {
                    dgSelectedIndexItem = IndexOfExistValue;
                }

                if (NewRow == true && (IndexOfExistValue == -1) && Pur_Req_Details.Count == dgSelectedIndexItem)
                {
                    Pur_Req_Details.Add(new PUR_T001_B()
                    {
                        ItemCode = POPUPEntityObject.ItemCode,
                        description = POPUPEntityObject.ItemName,
                        unit_code = POPUPEntityObject.unit_code,
                        SubCatCode = POPUPEntityObject.SubCatCode,
                        SubCatName = POPUPEntityObject.SubCatName,
                        StockUnt = POPUPEntityObject.StockUnt,
                        //line_id = Pur_Req_Details.Count +1,
                        location_Id = AppSessionState.OBJ_LOCATION.location_id,
                        comp_code = AppSessionState.OBJ_COMPANY.comp_code,
                        add_by = AppSessionState.UserID,
                        active = true,
                        t_status = MasterEntity.t_status,
                        t_display = MasterEntity.t_display,
                         
                    });

                    if (OBJ_SL != null)
                    {
                        if (OBJ_SL.item_code != null) // This is because if function call by PR Builk then item_code must be exists and if call from regular item selection from popup then control should not enter into this function block
                        {
                            Pur_Req_Details[dgSelectedIndexItem].ref_doc_cat = OBJ_SL.ref_doc_cat;
                            Pur_Req_Details[dgSelectedIndexItem].ref_doc_no = OBJ_SL.ref_doc_no;
                            Pur_Req_Details[dgSelectedIndexItem].ref_item_row_id = OBJ_SL.item_row_id;
                            Pur_Req_Details[dgSelectedIndexItem].qty = OBJ_SL.qty;
                            Pur_Req_Details[dgSelectedIndexItem].unit_code = OBJ_SL.unit_code;
                            if (OBJ_SL.ref_doc_cat == "SO")
                            {
                                Pur_Req_Details[dgSelectedIndexItem].sono = OBJ_SL.ref_doc_no;
                            }
                            else if (OBJ_SL.ref_doc_cat == "OR")
                            {
                                Pur_Req_Details[dgSelectedIndexItem].order_no = OBJ_SL.ref_doc_no;
                            }
                        }
                    }
                    
                }
                else if (dgSelectedIndexItem >= 0 && Pur_Req_Details.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                {
                    if (Pur_Req_Details[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True
                    {
                        Pur_Req_Details[dgSelectedIndexItem].ItemCode = POPUPEntityObject.ItemCode;
                        Pur_Req_Details[dgSelectedIndexItem].description = POPUPEntityObject.ItemName;
                        Pur_Req_Details[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                        Pur_Req_Details[dgSelectedIndexItem].StockUnt = Convert.ToBoolean(POPUPEntityObject.StockUnt);
                        Pur_Req_Details[dgSelectedIndexItem].active = true;
                        Pur_Req_Details[dgSelectedIndexItem].SubCatCode = POPUPEntityObject.SubCatCode;
                        //Pur_Req_Details[dgSelectedIndexItem].line_id = Pur_Req_Details.Count + 1;
                        Pur_Req_Details[dgSelectedIndexItem].location_Id = AppSessionState.OBJ_LOCATION.location_id;
                        Pur_Req_Details[dgSelectedIndexItem].comp_code = AppSessionState.OBJ_COMPANY.comp_code;
                        Pur_Req_Details[dgSelectedIndexItem].add_by = AppSessionState.UserID;
                        Pur_Req_Details[dgSelectedIndexItem].t_status = MasterEntity.t_status;
                        Pur_Req_Details[dgSelectedIndexItem].t_display = MasterEntity.t_display;
                    }
                    else if (Pur_Req_Details[dgSelectedIndexItem].ItemCode != POPUPEntityObject.ItemCode)
                    {
                        Pur_Req_Details[dgSelectedIndexItem].ItemCode = "";
                        Pur_Req_Details[dgSelectedIndexItem].description = "";
                    }
                }


            }
            //#region Clear Empty Row
            //PUR_T001_B newObj = new PUR_T001_B();
            //for (int i = Pur_Req_Details.Count - 1; i >= 0; i--)
            //{
            //    bool xx = Pur_Req_Details[i].ComparePropertiesTo(newObj);
            //    if (Pur_Req_Details[i].ComparePropertiesTo(newObj) == true && Pur_Req_Details.Count > 1)
            //    {
            //        Pur_Req_Details.RemoveAt(i);
            //        //if (Pur_Req_Details.Count == 0)
            //        //{
            //        //    Pur_Req_Details.Add(newObj);
            //        //}
            //    }
            //}
            //#endregion  
        }
        private void InsertDataGridRow_Uom(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    {
                        POPUPEntityObject = MC.uoms.Where(x => x.unit_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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
            }
            else if (InputValue != null)
            {
                if (((IEnumerable)InputValue).Cast<ADM_M038_B_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M038_B_P>().ToList()[0];
                }
            }

            #endregion

            if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
            {
                var InputValueIfExists = Pur_Req_Details.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault(); // Prefer Primary Key for this instruction.
                int IndexOfExistValue = Pur_Req_Details.IndexOf(Pur_Req_Details.Where(X => X.unit_code == POPUPEntityObject.unit_code).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                if (dgSelectedIndexItem >= 0 && Pur_Req_Details.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                {
                    if (Pur_Req_Details[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        Pur_Req_Details[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                    }
                    else if (Pur_Req_Details[dgSelectedIndexItem].unit_code != POPUPEntityObject.unit_code)
                    {
                        Pur_Req_Details[dgSelectedIndexItem].unit_code = POPUPEntityObject.unit_code;
                    }
                }
            }
            #region Clear Empty Row
            PUR_T001_B newObj = new PUR_T001_B();
            for (int i = Pur_Req_Details.Count - 1; i >= 0; i--)
            {
                bool xx = Pur_Req_Details[i].ComparePropertiesTo(newObj);
                if (Pur_Req_Details[i].ComparePropertiesTo(newObj) == true && Pur_Req_Details.Count > 1)
                {
                    Pur_Req_Details.RemoveAt(i);
                    if (Pur_Req_Details.Count == 0)
                    {
                        Pur_Req_Details.Add(newObj);
                    }
                }
            }

            #endregion

        }
        private void InsertDataGridRow_ItemCategory(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            string Request = "";
            SYS_M008_P POPUPEntityObject = null;
            dgSelectedIndexItem = dgSelectedIndexItem;
            #region Command Parameter Read Section
            // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
            if (InputValue.GetType() == typeof(string) && InputValue != null)
            {
                //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
                Request = InputValue.ToString();
                if (Request.Length > 0)
                {
                    try
                    { POPUPEntityObject = MC.ItemCategoryList.Where(x => x.item_cat.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                    catch (Exception ex) { }
                }
            }
            else if (InputValue != null)
            {
                if (((IEnumerable)InputValue).Cast<SYS_M008_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M008_P>().ToList()[0];
                }
            }

            #endregion

            //if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
            //{
            //    var InputValueIfExists = Pur_Req_Details.Where(X => X.item_cat == POPUPEntityObject.item_cat).FirstOrDefault(); // Prefer Primary Key for this instruction.
            //    int IndexOfExistValue = Pur_Req_Details.IndexOf(Pur_Req_Details.Where(X => X.item_cat == POPUPEntityObject.item_cat).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

            //    if (dgSelectedIndexItem >= 0 && Pur_Req_Details.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
            //    {
            //        if (Pur_Req_Details[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
            //        {
            //            Pur_Req_Details[dgSelectedIndexItem].item_cat = POPUPEntityObject.item_cat;
            //        }
            //        else if (Pur_Req_Details[dgSelectedIndexItem].item_cat != POPUPEntityObject.item_cat)
            //        {
            //            Pur_Req_Details[dgSelectedIndexItem].item_cat = "";
            //        }
            //    }
            //}
            if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
            {

                Pur_Req_Details[dgSelectedIndexItem].item_cat = POPUPEntityObject.item_cat;

            }
            #region Clear Empty Row
            PUR_T001_B newObj = new PUR_T001_B();
            for (int i = Pur_Req_Details.Count - 1; i >= 0; i--)
            {
                bool xx = Pur_Req_Details[i].ComparePropertiesTo(newObj);
                if (Pur_Req_Details[i].ComparePropertiesTo(newObj) == true && Pur_Req_Details.Count > 1)
                {
                    Pur_Req_Details.RemoveAt(i);
                    if (Pur_Req_Details.Count == 0)
                    {
                        Pur_Req_Details.Add(newObj);
                    }
                }
            }
            #endregion
        }
        private void ItemDetailsSelectionChangedMethod(IList InputList)// this method call when you click Pur_Req_Detail grid AND set Parameter true if stocking unit is true for selected Item.
        {
            IList list = InputList as IList;
            try
            {
                if (dgSelectedIndexItem != -1 && Pur_Req_Details.Count > 0 && Pur_Req_Details.Count > dgSelectedIndexItem)
                {
                    List<PUR_T001_B> selectedlist = list.Cast<PUR_T001_B>().ToList();
                    if (selectedlist.Count > 0)
                    {
                        ITEM_OBJ = selectedlist[0];
                    }
                    if (selectedlist.Count > 0)
                    {
                        if (Pur_Req_Details[dgSelectedIndexItem].id == 0 && Pur_Req_Details[dgSelectedIndexItem].StockUnt == true)
                        {
                            parameter = true;
                        }
                        else
                        {
                            parameter = false;
                        }
                    }
                }

                if (Pur_Req_Details.Count > 0 && dgSelectedIndexItem != -1 && Pur_Req_Details.Count > dgSelectedIndexItem)
                {
                    if (MC.BOM_List.Count() > 0)
                    {

                        var BOMItems = (from data in MC.BOM_List where data.ItemCode == Pur_Req_Details[dgSelectedIndexItem].ItemCode select data);

                        //New PopUP - BOM Reference
                        SuggestedValue = new ValueConverter(x => x == null ? "" : ((ENG_T001_P)x).doc_no);
                        TheFilter = (o, prefix) => (((ENG_T001_P)o).doc_no ?? "").ToString().ToLower().Contains(prefix.ToLower());
                        ASBOMRef = new AutoSuggestTextViewModel<dynamic>(BOMItems, TheFilter, SuggestedValue, "bom_no", "doc_no", true);
                        ASBOMRef.AutoSuggestVM.IsEmptyValueAllowed = true;
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
        private void InsertDeptment(object InputValue)
        {
            try
            {

                string Request = "";
                ADM_M025_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.DepartmentList.Where(x => x.dept_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M025_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                //if (POPUPEntityObject != null && MasterEntity.EmpId != POPUPEntityObject.EmpId) //Application:New/Update.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                if (POPUPEntityObject != null)
                {

                    MasterEntity.dept_code = POPUPEntityObject.dept_code;
                    MasterEntity.dept_name = POPUPEntityObject.dept_name;
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
        private void InsertOperation(object InputValue)
        {
            try
            {

                string Request = "";
                STD_LIST_BE POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.PRODUCTION_ORDER_OPERATIONS.Where(x => x.ref_doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<STD_LIST_BE>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {

                    Pur_Req_Details[dgSelectedIndexItem].order_no = POPUPEntityObject.order_no;
                    Pur_Req_Details[dgSelectedIndexItem].order_res_row_id = POPUPEntityObject.row_id;
                    Pur_Req_Details[dgSelectedIndexItem].op_row_id = POPUPEntityObject.row_id;
                    Pur_Req_Details[dgSelectedIndexItem].operation_no = POPUPEntityObject.operation_no;
                    Pur_Req_Details[dgSelectedIndexItem].operation_desc = POPUPEntityObject.operation_desc;
                    Pur_Req_Details[dgSelectedIndexItem].item_cat = "B";
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
        private void InsertItemStatus(object InputValue)
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
                            { POPUPEntityObject = MC.STATUS_LIST.Where(x => x.t_status.Equals(Request, StringComparison.OrdinalIgnoreCase) == true || x.t_display.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
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
                    Pur_Req_Details[dgSelectedIndexItem].t_status = POPUPEntityObject.t_status;
                    Pur_Req_Details[dgSelectedIndexItem].t_display = POPUPEntityObject.t_display;
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
        private void InsertPurchaseGroup(object InputValue)
        {
            try
            {
                //ADM_M028_PopUp
                string Request = "";
                ADM_M001_P_P POPUPEntityObject = null;
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
                            { POPUPEntityObject = MC.Purchase_groupList.Where(x => x.pg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_P_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {
                    MasterEntity.pg_code = POPUPEntityObject.pg_code;
                    MasterEntity.pg_name = POPUPEntityObject.pg_name;
                    MasterEntity.po_code = POPUPEntityObject.po_code;
                    MasterEntity.pur_org = POPUPEntityObject.pur_org;
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
        private void InsertProjectElement(object InputValue)
        {
            string Request = "";
            PRO_T001_P POPUPEntityObject = null;
            dgSelectedIndexItem = dgSelectedIndexItem;
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
                        POPUPEntityObject = MC.Project.Where(x => x.element_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
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
            }
            else if (InputValue != null)
            {
                if (((IEnumerable)InputValue).Cast<PRO_T001_P>().Count() > 0)
                {
                    POPUPEntityObject = ((IEnumerable)InputValue).Cast<PRO_T001_P>().ToList()[0];
                }
            }
            #endregion
            if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
            {
                ITEM_OBJ.element_id = POPUPEntityObject.element_id;
                ITEM_OBJ.element_name = POPUPEntityObject.element_name;
                ITEM_OBJ.element_no = POPUPEntityObject.element_no;
                ITEM_OBJ.project_id = POPUPEntityObject.project_id;
                ITEM_OBJ.project_name = POPUPEntityObject.project_name;
                ITEM_OBJ.project_no = POPUPEntityObject.project_no;
                ITEM_OBJ.ref_doc_cat = POPUPEntityObject.ref_doc_cat;
                ITEM_OBJ.ref_doc_no = POPUPEntityObject.ref_doc_no;
                ITEM_OBJ.ref_item_row_id = POPUPEntityObject.ref_item_row_id;

                if (!string.IsNullOrWhiteSpace(ITEM_OBJ.project_id) && !string.IsNullOrWhiteSpace(ITEM_OBJ.element_id) && !string.IsNullOrWhiteSpace(ITEM_OBJ.sono) && !string.IsNullOrWhiteSpace(ITEM_OBJ.ItemCode))
                {
                    CursorControl.SetBusyState();
                    // Check material exists or not in Project Sales Order
                    Request = "CHECK_ITEM_EXISTS" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + ITEM_OBJ.project_id + "!@" + ITEM_OBJ.element_id + "!@" + ITEM_OBJ.sono + "!@" + ITEM_OBJ.ItemCode;
                    //MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_PUR_T002_A>(MCTemp, Request, "PRO_T001_BL", "PRO", "LoadAll", 0, "");
                    MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_PUR_T001_A>(MCTemp, Request, "PRO_T001_BL", "PRO", "LoadAll", 0, "");
                    if (MCTemp.PRODUCTION_ORDER_OPERATIONS != null)
                    {
                        if (MCTemp.PRODUCTION_ORDER_OPERATIONS.Count == 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = "Material not exists in Project order";
                            showMessageService.ShowMessage();
                        }
                    }
                }

            }
        }
        private void CollectionChanged(IList DataList)//this method is called when you click Item Description Toggle Button
        {
            IList list = DataList as IList;
            int a = dgSelectedIndexItem;
            string[] TempSkuList = new string[100];
            List<string> TempParaValueList = new List<string>();
            try
            {
                if (Pur_Req_Details[dgSelectedIndexItem].id == 0 && Pur_Req_Details.Count > 0 && dgSelectedIndexItem < Pur_Req_Details.Count)//if Pur_Req_Detail collection is nor empty 
                {
                    List<PUR_T001_B> SelectedRowlist = list.Cast<PUR_T001_B>().ToList();

                    if (SelectedRowlist[0].StockUnt == true)
                    {
                        var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();// select those parameter which matches selected item subcat_code.
                        ParameterTemp = paramlist.ToList();

                        if (paramlist.Count > 0 && Pur_Req_Details[dgSelectedIndexItem].sku != "" && Pur_Req_Details[dgSelectedIndexItem].sku != null)
                        {
                            TempSkuList = Pur_Req_Details[dgSelectedIndexItem].sku.Split('/');

                            for (int i = 0; i < paramlist.Count; i++)
                            {
                                TempParaValueList = (from o in MC.ParamValueList where o.value_code == TempSkuList[i] select o.parametervalue).ToList();
                                if (TempParaValueList.Count > 0)
                                {
                                    paramlist[i].parametervalue = TempParaValueList[0];
                                }
                            }

                            ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                        }
                        else
                        {
                            foreach (var o in ParameterTemp)
                            {
                                o.parametervalue = null; o.value_code = null;
                            }
                            ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                        }

                        if (paramlist.Count > 0) //&& SelectedParaValueCollection.Count != paramlist.Count)
                        {
                            SelectedParaValueCollection = new List<ADM_M031_P>();

                            for (int i = 0; i < paramlist.Count; i++)
                            {
                                SelectedParaValueCollection.Add(new ADM_M031_P()
                                {
                                    // ItemCode = SelectedRowlist[0].ItemCode,
                                    dgselectedindex = dgSelectedIndexItem,
                                    //  value_code = SelectedParaValueList[0].value_code,
                                    para_code = paramlist[i].para_code,
                                    para_name = paramlist[i].para_name
                                });
                            }
                        }
                        if (Pur_Req_Details[dgSelectedIndexItem].sku_desc != null)
                        {
                            SelectedParaValueCollection = ParameterCollection.Cast<ADM_M031_P>().ToList();

                            foreach (var o in SelectedParaValueCollection)
                            {
                                o.dgselectedindex = dgSelectedIndexItem;
                                foreach (var p in MC.ParamValueList)
                                {
                                    if (o.para_code == p.para_code && o.parametervalue == p.parametervalue)
                                    {
                                        o.value_code = p.value_code;
                                    }
                                }
                            }
                        }

                    }

                }
                else if (Pur_Req_Details[dgSelectedIndexItem].id != 0 && Pur_Req_Details.Count > 0 && dgSelectedIndexItem < Pur_Req_Details.Count)
                {
                    //List<PUR_T001_B> SelectedRowlist = list.Cast<PUR_T001_B>().ToList();
                    //string[] TempSkuList = new string[100];
                    //List<string> TempParaValueList = new List<string>();

                    //if (SelectedRowlist[0].StockUnt == true)
                    //{
                    //    var paramlist = (from o in MC.ParameterList where o.SubCatCode == SelectedRowlist[0].SubCatCode select o).ToList();
                    //    if (paramlist.Count > 0 && Pur_Req_Details[dgSelectedIndexItem].sku != "" && Pur_Req_Details[dgSelectedIndexItem].sku != null)
                    //    {
                    //        TempSkuList = Pur_Req_Details[dgSelectedIndexItem].sku.Split('/');

                    //        for (int i = 0; i < paramlist.Count; i++)
                    //        {
                    //            TempParaValueList = (from o in MC.ParamValueList where o.value_code == TempSkuList[i] select o.parametervalue).ToList();
                    //            paramlist[i].parametervalue = TempParaValueList[0];
                    //        }

                    //        ParameterCollection = CollectionViewSource.GetDefaultView(paramlist.ToList());
                    //    }
                    //}
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
        private void GetSelectedParaValue(IList parameter)// this method called when you select parameter value from combobox
        {
            IList list = parameter as IList;
            List<ADM_M031_P> SelectedParaValueList = list.Cast<ADM_M031_P>().ToList();
            int a = ParadgSelectedIndex;
            int b = dgSelectedIndexItem;

            try
            {
                if (dgSelectedIndexItem != -1 && SelectedParaValueList.Count > 0 && Pur_Req_Details[dgSelectedIndexItem].StockUnt == true)
                {
                    if (Pur_Req_Details[dgSelectedIndexItem].id == 0)
                    {
                        #region 
                        if (SelectedParaValueList.Count > 0 && SelectedParaValueList[0].parametervalue != null && SelectedParaValueList[0].parametervalue != "")// && SelectedParaValueCollection.dgselectedindex.contains)
                        {
                            for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                            {
                                if (SelectedParaValueCollection[i].para_code == SelectedParaValueList[0].para_code && SelectedParaValueCollection[i].dgselectedindex == dgSelectedIndexItem)
                                {
                                    SelectedParaValueCollection[i].parametervalue = SelectedParaValueList[0].parametervalue;

                                    var paravaluetemp = (from o in MC.ParamValueList where o.para_code == SelectedParaValueCollection[i].para_code && o.parametervalue == SelectedParaValueCollection[i].parametervalue select o).ToList();

                                    if (paravaluetemp.Count > 0)
                                    {
                                        SelectedParaValueCollection[i].value_code = paravaluetemp[0].value_code;
                                    }
                                }
                            }

                            // SKU Description
                            GetSkuDescription();

                            //Function for calculating SKU
                            CalculateSku();


                        }
                        #endregion
                    }
                    else if (Pur_Req_Details[dgSelectedIndexItem].id != 0)
                    {

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
        private void GetSkuDescription()
        {
            if (Pur_Req_Details[dgSelectedIndexItem].sku_desc == null || Pur_Req_Details[dgSelectedIndexItem].sku_desc == "")
            {
                for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                {
                    if (Pur_Req_Details[dgSelectedIndexItem].sku_desc == "" || Pur_Req_Details[dgSelectedIndexItem].sku_desc == null && (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA"))
                    {
                        Pur_Req_Details[dgSelectedIndexItem].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                    }
                    else if (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                    {
                        Pur_Req_Details[dgSelectedIndexItem].sku_desc = Pur_Req_Details[dgSelectedIndexItem].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                    }
                }
            }
            else
            {
                Pur_Req_Details[dgSelectedIndexItem].sku_desc = "";

                for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                {
                    if (Pur_Req_Details[dgSelectedIndexItem].sku_desc == "" || Pur_Req_Details[dgSelectedIndexItem].sku_desc == null && (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA"))
                    {
                        Pur_Req_Details[dgSelectedIndexItem].sku_desc = SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                    }
                    else if (String.IsNullOrEmpty(SelectedParaValueCollection[i].parametervalue) || SelectedParaValueCollection[i].parametervalue.Trim() != "NA")
                    {
                        Pur_Req_Details[dgSelectedIndexItem].sku_desc = Pur_Req_Details[dgSelectedIndexItem].sku_desc + SelectedParaValueCollection[i].para_name + ":" + SelectedParaValueCollection[i].parametervalue + "\t";
                    }
                }
            }
        }
        private void InsertSO(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                SEL_T001_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SalesList.Where(x => x.sono.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<SEL_T001_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion


                var InputValueIfExists = Pur_Req_Details.Where(X => X.sono == POPUPEntityObject.sono).FirstOrDefault(); // Prefer Primary Key for this instruction.
                int IndexOfExistValue = Pur_Req_Details.IndexOf(Pur_Req_Details.Where(X => X.sono == POPUPEntityObject.sono).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                if (dgSelectedIndexItem >= 0 && Pur_Req_Details.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                {
                    if (Pur_Req_Details[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                    {
                        Pur_Req_Details[dgSelectedIndexItem].sono = POPUPEntityObject.sono;
                        Pur_Req_Details[dgSelectedIndexItem].note = POPUPEntityObject.party_name;
                        Pur_Req_Details[dgSelectedIndexItem].ref_doc_cat = POPUPEntityObject.ref_doc_cat;
                        Pur_Req_Details[dgSelectedIndexItem].ref_doc_no = POPUPEntityObject.ref_doc_no;
                        Pur_Req_Details[dgSelectedIndexItem].ref_item_row_id = POPUPEntityObject.id;
                    }
                    else if (Pur_Req_Details[dgSelectedIndexItem].sono != POPUPEntityObject.sono)
                    {
                        Pur_Req_Details[dgSelectedIndexItem].sono = POPUPEntityObject.sono;
                        Pur_Req_Details[dgSelectedIndexItem].note = POPUPEntityObject.party_name;
                        Pur_Req_Details[dgSelectedIndexItem].ref_doc_cat = POPUPEntityObject.ref_doc_cat;
                        Pur_Req_Details[dgSelectedIndexItem].ref_doc_no = POPUPEntityObject.ref_doc_no;
                        Pur_Req_Details[dgSelectedIndexItem].ref_item_row_id = POPUPEntityObject.id;
                    }
                }
                #region Clear Empty Row
                PUR_T001_B newObj = new PUR_T001_B();
                for (int i = Pur_Req_Details.Count - 1; i >= 0; i--)
                {
                    bool xx = Pur_Req_Details[i].ComparePropertiesTo(newObj);
                    if (Pur_Req_Details[i].ComparePropertiesTo(newObj) == true && Pur_Req_Details.Count > 1)
                    {
                        Pur_Req_Details.RemoveAt(i);
                        if (Pur_Req_Details.Count == 0)
                        {
                            Pur_Req_Details.Add(newObj);
                        }
                    }
                }

                #endregion
            }
            catch (Exception ex)
            {

            }
        }
        private void InsertBOM(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ENG_T001_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Control.
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.BOM_List.Where(x => x.doc_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ENG_T001_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion


                if (POPUPEntityObject != null) //Application:New Record Only.Condition: Only enter in the code block if EntityObject is Not null and not assigning same value again if event fire twice.
                {

                    Pur_Req_Details[dgSelectedIndexItem].bom_no = POPUPEntityObject.doc_no;

                }
                if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
                {
                    var InputValueIfExists = Pur_Req_Details.Where(X => X.bom_no == POPUPEntityObject.doc_no).FirstOrDefault(); // Prefer Primary Key for this instruction.
                    int IndexOfExistValue = Pur_Req_Details.IndexOf(Pur_Req_Details.Where(X => X.bom_no == POPUPEntityObject.doc_no).FirstOrDefault()); // Prefer Primary/Unique Key of Row for this instruction.

                    if (dgSelectedIndexItem >= 0 && Pur_Req_Details.Count > dgSelectedIndexItem) //Update Row: If Old or Blank row get added, then Edit Rule will applicable in this Loop.
                    {
                        if (Pur_Req_Details[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            Pur_Req_Details[dgSelectedIndexItem].bom_no = POPUPEntityObject.doc_no;
                        }
                        else if (Pur_Req_Details[dgSelectedIndexItem].bom_no != POPUPEntityObject.doc_no)
                        {
                            Pur_Req_Details[dgSelectedIndexItem].bom_no = POPUPEntityObject.doc_no;
                        }
                    }
                }
                #region Clear Empty Row
                PUR_T001_B newObj = new PUR_T001_B();
                for (int i = Pur_Req_Details.Count - 1; i >= 0; i--)
                {
                    bool xx = Pur_Req_Details[i].ComparePropertiesTo(newObj);
                    if (Pur_Req_Details[i].ComparePropertiesTo(newObj) == true && Pur_Req_Details.Count > 1)
                    {
                        Pur_Req_Details.RemoveAt(i);
                        if (Pur_Req_Details.Count == 0)
                        {
                            Pur_Req_Details.Add(newObj);
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

        private void CalculateSku()
        {
            if (Pur_Req_Details[dgSelectedIndexItem].sku == null || Pur_Req_Details[dgSelectedIndexItem].sku == "")
            {
                for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                {
                    if (Pur_Req_Details[dgSelectedIndexItem].sku == "" || Pur_Req_Details[dgSelectedIndexItem].sku == null)
                    {
                        Pur_Req_Details[dgSelectedIndexItem].sku = SelectedParaValueCollection[i].value_code;
                    }
                    else
                    {
                        Pur_Req_Details[dgSelectedIndexItem].sku = Pur_Req_Details[dgSelectedIndexItem].sku + "/" + SelectedParaValueCollection[i].value_code;
                    }
                }
            }
            else
            {
                Pur_Req_Details[dgSelectedIndexItem].sku = "";

                for (int i = 0; i < SelectedParaValueCollection.Count; i++)
                {
                    if (Pur_Req_Details[dgSelectedIndexItem].sku == "" || Pur_Req_Details[dgSelectedIndexItem].sku == null)
                    {
                        Pur_Req_Details[dgSelectedIndexItem].sku = SelectedParaValueCollection[i].value_code;
                    }
                    else
                    {
                        Pur_Req_Details[dgSelectedIndexItem].sku = Pur_Req_Details[dgSelectedIndexItem].sku + "/" + SelectedParaValueCollection[i].value_code;
                    }
                }
            }
        }
        private void DeleteDataGridRow_Item(object InputValue)
        {
            int i = (int)InputValue;
            if (Pur_Req_Details.Count > i && Pur_Req_Details[dgSelectedIndexItem].id == 0)
            {
                Pur_Req_Details.RemoveAt(i);
            }
        }
        private void LoadInitialData()
        {
            CursorControl.SetBusyState();
            try
            {
                string Request = "LoadInitialData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id.ToString() + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@!@" + AppSessionState.EmpId + "!@" + "" + "!@" + AppSessionState.UserID;
                
                MC = repositoryM.GetDataWithReturnDomainObject<MultipleContext_PUR_T001_A>(MC, Request, "PRO_T001_BL", "PRO", "LoadAll", 0, "");
                // MC = repositoryM.GetData<MultipleContext_PUR_T001_A>(MC, Request, "PRO_T001_BL", "Reflection.BusinessLogic.PUR_T001_ABL");
                
                #region Auto Suggest Initialization Region

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode);
                TheFilter = (o, prefix) => (((ADM_M022_P)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M022_P)o).ItemName.ToString().ToLower() ?? "").Contains(prefix.ToLower());
                ASDefault = new AutoSuggestTextViewModel<dynamic>(MC.ItemList, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASDefault.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M040_P)x).pr_code);
                TheFilter = (o, prefix) => (((ADM_M040_P)o).pr_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M040_P)o).text_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPriority = new AutoSuggestTextViewModel<dynamic>(MC.Priorities, TheFilter, SuggestedValue, "pr_code", true);
                ASPriority.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M024_P)x).EmpId);
                TheFilter = (o, prefix) => (((ADM_M024_P)o).EmpId ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M024_P)o).EmpName.ToString().ToLower() ?? "").Contains(prefix.ToLower());
                ASRequester = new AutoSuggestTextViewModel<dynamic>(MC.Employees, TheFilter, SuggestedValue, "EmpId", true);
                ASRequester.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M022_P)x).ItemCode);
                TheFilter = (o, prefix) => (((ADM_M022_P)o).ItemCode ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M022_P)o).ItemName.ToString().ToLower() ?? "").Contains(prefix.ToLower());
                ASItem = new AutoSuggestTextViewModel<dynamic>(MC.ItemList, TheFilter, SuggestedValue, "ItemCode", "ItemCode", true);
                ASItem.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M038_B_P)x).unit_code);
                TheFilter = (o, prefix) => (((ADM_M038_B_P)o).unit_code ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASUnit = new AutoSuggestTextViewModel<dynamic>(MC.uoms, TheFilter, SuggestedValue, "unit_code", "unit_code", true);
                ASUnit.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SEL_T001_P)x).sono);
                TheFilter = (o, prefix) => (((SEL_T001_P)o).sono ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((SEL_T001_P)o).PartyId ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((SEL_T001_P)o).roundup_total.ToString().ToLower() ?? "").Contains(prefix.ToLower()) ||
                                           (((SEL_T001_P)o).quantity.ToString().ToLower() ?? "").Contains(prefix.ToLower()) ||
                                           (((SEL_T001_P)o).party_name ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((SEL_T001_P)o).address ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASOrder = new AutoSuggestTextViewModel<dynamic>(MC.SalesList, TheFilter, SuggestedValue, "sono", "sono", true);
                ASOrder.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((SYS_M008_P)x).item_cat);
                TheFilter = (o, prefix) => (((SYS_M008_P)o).item_cat ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASItemCat = new AutoSuggestTextViewModel<dynamic>(MC.ItemCategoryList, TheFilter, SuggestedValue, "item_cat", "item_cat", true);
                ASItemCat.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASt_status = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_display", true);
                ASt_status.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M0013)x).t_display);
                TheFilter = (o, prefix) => (((ADM_M0013)o).t_display ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M0013)o).t_status ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASStatusItem = new AutoSuggestTextViewModel<dynamic>(MC.STATUS_LIST, TheFilter, SuggestedValue, "t_display", true);
                ASStatusItem.AutoSuggestVM.IsEmptyValueAllowed = true;

                //New PopUP - Purchase Group
                //PurchaseGroupList = (List<ADM_M001_P_P>)AppSessionState.ADM_M001_P_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_P_P)x).pg_code);
                TheFilter = (o, prefix) => (((ADM_M001_P_P)o).pg_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M001_P_P)o).po_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M001_P_P)o).pur_org ?? "").ToString().ToLower().Contains(prefix.ToLower()) ||
                                           (((ADM_M001_P_P)o).pg_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPurGrp = new AutoSuggestTextViewModel<dynamic>(MC.Purchase_groupList, TheFilter, SuggestedValue, "pg_code", true);
                ASPurGrp.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M030_P)x).value_code);
                TheFilter = (o, prefix) => (((ADM_M030_P)o).value_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M030_P)o).parametervalue ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASParameterValues = new AutoSuggestTextViewModel<dynamic>(MC.ParamValueList, TheFilter, SuggestedValue, "user_source1", "value_code", true);
                ASParameterValues.AutoSuggestVM.IsEmptyValueAllowed = true;

                CompanyList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M002)x).comp_code);
                TheFilter = (o, prefix) => (((ADM_M002)o).comp_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M002)o).CompName ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASCompany = new AutoSuggestTextViewModel<dynamic>(CompanyList, TheFilter, SuggestedValue, "comp_code", true);
                ASCompany.AutoSuggestVM.IsEmptyValueAllowed = true;

                LocationList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
                TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
                ASPlant = new AutoSuggestTextViewModel<dynamic>(LocationList, TheFilter, SuggestedValue, "location_Id", true);
                ASPlant.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M025_P)x).dept_code);
                TheFilter = (o, prefix) => (((ADM_M025_P)o).dept_code ?? "").ToLower().Contains(prefix.ToLower()) || ((ADM_M025_P)o).dept_name.ToLower().Contains(prefix.ToLower());
                ASDepartment = new AutoSuggestTextViewModel<dynamic>(MC.DepartmentList, TheFilter, SuggestedValue, "dept_code", true);
                ASDepartment.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((PRO_T001_P)x).element_id);
                TheFilter = (o, prefix) => (((PRO_T001_P)o).element_id ?? "").ToLower().Contains(prefix.ToLower()) || ((PRO_T001_P)o).element_name.ToLower().Contains(prefix.ToLower());
                ASProject = new AutoSuggestTextViewModel<dynamic>(MC.Project, TheFilter, SuggestedValue, "element_id", true);
                ASProject.AutoSuggestVM.IsEmptyValueAllowed = true;

                SuggestedValue = new ValueConverter(x => x == null ? "" : ((STD_LIST_BE)x).ref_doc_no);
                TheFilter = (o, prefix) => (((STD_LIST_BE)o).ref_doc_no ?? "").ToLower().Contains(prefix.ToLower()) || ((STD_LIST_BE)o).order_no.ToLower().Contains(prefix.ToLower());
                AS_OPERATIONS = new AutoSuggestTextViewModel<dynamic>(MC.PRODUCTION_ORDER_OPERATIONS, TheFilter, SuggestedValue, "ref_doc_no", true);
                AS_OPERATIONS.AutoSuggestVM.IsEmptyValueAllowed = true; AS_OPERATIONS.AutoSuggestVM.IsFreeTextAllowed = false;

                #endregion

                FlipGridData = MC.DocumentDataFlipGrid;
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                // This loop added to add complete url of the image. NOT: use proper method for this, this is temporary coding.
                foreach (var item in MC.ItemList)
                {
                    if(!string.IsNullOrWhiteSpace(item.source))
                    {
                        item.source = AppSessionState.RootDirectory + "ERP_Documents/" +  AppSessionState.client + "/" + AppSessionState.OBJ_COMPANY.comp_code + "/" + (item.source ?? "");
                    }
                }

                ItemsCollection = (ICollectionView)CollectionViewSource.GetDefaultView(MC.ItemList.ToList());
                ItemsCollection.Filter = new Predicate<object>(ItemsFilter);

                NotificationDataCollection = MC.NotificationData;

                DefaultValues();

                MasterEntity.deadline = DateTime.Now;
                MasterEntity.date_start = DateTime.Now;

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
        private void CommandInitialization()
        {
            CursorControl.SetBusyState();
            try
            {
                #region Command Initialisation
                cmdGeneratePR = new RelayCommand<object>(items => { if (items == null) { return; } GeneratePR(items); });
                cmdInsertDepartment = new RelayCommand<object>(items => { if (items == null) { return; } InsertDeptment(items); });
                cmdInsertProjectElement = new RelayCommand<object>(items => { if (items == null) { return; } InsertProjectElement(items); });
                cmdWindowLoadEvent = new RelayCommand<object>(items => { if (items == null) { return; } WindowEvetCall(items); });
                CommandDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
                CommandDeleteScheduleItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_ItemSchedule(cmdPara); });
                cmdInsertOperation = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertOperation(cmdPara); });
                CommandLoadBackFlipData = new RelayCommand<object>(items => { if (items == null) { return; } LoadBackFlipData(items); });
                cmdInsertStatusItem = new RelayCommand<object>(items => { if (items == null) { return; } InsertItemStatus(items); });
                SelectionChangedCommandPurchaseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertPurchaseGroup(items); });
                SelectionChangedCommandPriority = new RelayCommand<object>(
                items =>
                {
                    if (items == null) { return; }
                    InsertPriority(items);
                });

                SelectionChangedCommandEmp = new RelayCommand<object>(
                items =>
                {
                    if (items == null) { return; }

                    InsertEmployee(items);
                });

                SelectionChangedCommandItems = new RelayCommand<object>(
                cmdPara =>
                {
                    if (cmdPara == null) { return; }
                    InsertDataGridRow_Item(cmdPara, true, null);
                });

                SelectionChangedCommanduom = new RelayCommand<object>
                     (cmdPara =>
                     {
                         if (cmdPara == null) { return; }
                         InsertDataGridRow_Uom(cmdPara, false, true, true);
                     });


                CommandAddItemCategory = new RelayCommand<object>
                (cmdPara =>
                {
                    if (cmdPara == null) { return; }
                    InsertDataGridRow_ItemCategory(cmdPara, false, true, true);
                });

                CollectionChangedCommand = new RelayCommand<IList>(
                 items => { if (items == null) { return; } CollectionChanged(items); });

                SelectionChangedParaValCommand = new RelayCommand<IList>(
                items => { if (items == null) { return; } GetSelectedParaValue(items); });

                DataGridRowDeleteCommand = new RelayCommand<object>(
                items => { if (items == null) { return; } DeleteDataGridRow_Item(items); });

                CommandLoadDataFromBackFlip = new RelayCommand<IList>
                (cmdPara => { if (cmdPara == null) { return; } LoadBackFilpDetailstemp(cmdPara); });
                SelectionChangeCommandItemDetails = new RelayCommand<IList>(items => { if (items == null) { return; } ItemDetailsSelectionChangedMethod(items); });

                CmdAddSO = new RelayCommand<object>
                       (cmdPara =>
                       {
                           if (cmdPara == null) { return; }
                           InsertSO(cmdPara, false, true, true);
                       });

                CmdAddBOM = new RelayCommand<object>
                     (cmdPara =>
                     {
                         if (cmdPara == null) { return; }
                         InsertBOM(cmdPara, false, true, true);
                     });

                CmdInsert_t_status = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } Insert_t_status(cmdPara); });
                CommandInsertMake = new RelayCommand<object>
               (cmdPara => { if (cmdPara == null) { return; } InsertMake(cmdPara, false, true, true); });
                CommandInsertType = new RelayCommand<object>
               (cmdPara => { if (cmdPara == null) { return; } InsertType(cmdPara, false, true, true); });
                cmdMasterMake = new RelayCommand<object>(items => { if (items == null) { return; } InsertMasterMake(items); }); cmdMasterType = new RelayCommand<object>(items => { if (items == null) { return; } InsertMasterType(items); });
                //CmdInsertCompany = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCompany(cmdPara); });
                //CmdInsertLocationId = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLocationId(cmdPara); });
                #endregion
            }
            catch (Exception ex)
            {
                //sms.ButtonSetup = DialogButton.Ok; sms.Caption = "Message"; sms.Text = String.Format(ex.Message, this.Title); sms.ShowMessage();
            }
        }
        private void DefaultValues()
        {
            EntityChangeEnable = true;
            MasterEntity.doc_cat = doc_cat_vm;
            MasterEntity.doc_type = doc_cat_vm;
            MasterEntity.comp_code = AppSessionState.OBJ_COMPANY.comp_code;
            MasterEntity.active = true;
            MasterEntity.priority = "H";
            MasterEntity.location_Id = AppSessionState.OBJ_LOCATION.location_id;
            MasterEntity.t_status = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_status).FirstOrDefault();
            MasterEntity.t_display = (from o in MC.STATUS_LIST where o.ind_default == "1" select o.t_display).FirstOrDefault();
            MasterEntity.date_start = DateTime.Now;
            MasterEntity.deadline = DateTime.Now;
            MasterEntity.dept_code = AppSessionState.dept_code;
            if (MC.Purchase_groupList.Count == 1)
            {
                MasterEntity.po_code = MC.Purchase_groupList[0].po_code;
                MasterEntity.pg_code = MC.Purchase_groupList[0].pg_code;
                MasterEntity.pg_name = MC.Purchase_groupList[0].pg_name;
                MasterEntity.pur_org = MC.Purchase_groupList[0].pur_org;
            }
            else
            {
                MasterEntity.po_code = AppSessionState.po_code;
                MasterEntity.pg_code = AppSessionState.pg_code;
            }
            SearchEntityObject.from_date = DateTime.Now.Date;
            SearchEntityObject.to_date = DateTime.Now.Date;
            SearchEntityObject.active = true;
            MasterEntity.EmpId = AppSessionState.EmpId;
            MasterEntity.EmpNm = AppSessionState.EmpName;
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
        public string ConvertDataTableToHTML()
        {
            string html = "<table>";
            //add header row
            html += "<tr bgcolor=#e0e0eb>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Item Code </span></strong></p> </td>";
            html += "<td width=10%> <p><strong><span style=color:#000080;> Item Name </span></strong></p> </td>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Quantity </span></strong></p> </td>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Unit </span></strong></p> </td>";
            html += "<td width=5%> <p><strong><span style=color:#000080;> Unit Price </span></strong></p> </td>";
            html += "</tr>";

            foreach (var item in Pur_Req_Details)
            {
                if (item.active == true)
                {
                    html += "<tr bgcolor=#d9e6f2>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.ItemCode + "</p></span></strong></p> </td>";
                    html += "<td width=10%> <p><strong><span style=color:#000080;> " + item.description + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.qty.ToString() + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + item.unit_code + "</span></strong></p> </td>";
                    html += "<td width=5%> <p><strong><span style=color:#000080;> " + (item.cost.HasValue ? decimal.Round(item.cost.Value, 2).ToString() : "") + "</span></strong></p> </td>";
                    html += "</tr>";
                }
            }
            html += "</table>";

            return html;
        }
        private void NotifyMessage(string AlertName, string operation)
        {
            try
            {
                List<NotificationData> objNotifyData = new List<NotificationData>();
                List<NotificationData> objNotifyDataTemp = new List<NotificationData>();
                NotificationData objNotifyDataObject = new NotificationData();
                string xx = ConvertDataTableToHTML();
                objNotifyDataTemp = NotificationDataCollection.Where(x => x.alert_name == AlertName).ToList();
                objNotifyDataTemp[0].CopyPropertiesTo<NotificationData>(objNotifyDataObject);
                objNotifyData.Add(objNotifyDataObject);
                foreach (NotificationData VarData in objNotifyData)
                {
                    List<KeyValuePair<string, string>> kvpList = new List<KeyValuePair<string, string>>()
                    {
                        new KeyValuePair<string, string>("[EMP]",AppSessionState.Name),
                        new KeyValuePair<string, string>("[DOC]", "Pruchase Requisition"),
                        new KeyValuePair<string, string>("[OPR]", operation),
                        new KeyValuePair<string, string>("[DOCNO]", MasterEntity.req_no),
                        new KeyValuePair<string, string>("[Comp]","M/s: " +AppSessionState.CompanyName),
                        new KeyValuePair<string, string>("[TSTS]", MasterEntity.t_display),
                        new KeyValuePair<string, string>("[Attn]",VarData.EmpName),
                        new KeyValuePair<string, string>("[CUST]",""),
                        new KeyValuePair<string, string>("[CUR]",""),
                        new KeyValuePair<string, string>("[OVAL]",""),
                        new KeyValuePair<string, string>("[DOCDATE]", MasterEntity.date_start.ToString()),
                        new KeyValuePair<string, string>("[MODDT]", DateTime.Now.ToString()),
                        new KeyValuePair<string, string>("[PREF]", ""), 
                        new KeyValuePair<string, string>("[INCO]", ""),
                        new KeyValuePair<string, string>("[ITEM_TABLE]", xx),
                    };

                    foreach (KeyValuePair<string, string> kvp in kvpList)
                    {
                        VarData.subject = VarData.subject.Replace(kvp.Key, kvp.Value);
                        VarData.msg_body = VarData.msg_body.Replace(kvp.Key, kvp.Value);
                    }
                    VarData.cc_mail_id = (VarData.cc_mail_id ?? "") + ";" + (AppSessionState.EmpEmailId ?? "");
                    Task t = MailMessenger.SendMailAsync(AppSessionState.MailAccount, VarData.to_mail_id, VarData.cc_mail_id, VarData.bcc_mail_id, VarData.subject, VarData.msg_body, null);
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
        
        #region · Command Actions ·
        protected override void OnSaveAction(InquiryActionResult<PUR_T001_A> result)
        {
            try
            {
                CursorControl.SetBusyState();
                Logging();
                //MasterEntity.XmlDataDocument_PUR_T001_B = objSer.ObjectToXML(Pur_Req_Details);
                //MasterEntity.XmlDataDocument_PUR_T001_C = objSer.ObjectToXML(dgItemScheduleEntity);
                this.MasterEntity.EndEdit();
                if (validation() == true)
                {
                    MCTemp.Pur_Req = new List<PUR_T001_A>();
                    MCTemp.Pur_Req.Add(MasterEntity);
                    MCTemp.Pur_Req_Details = Pur_Req_Details;
                    MCTemp.Pur_Req_Schedule = dgItemScheduleEntity;

                    if (NewRecord == true)
                    {
                        

                        MCTemp = repositoryM.SaveWithReturnDomainObject<MultipleContext_PUR_T001_A>(MCTemp, "PRO_T001_BL", "PRO");
                        //MasterEntity = repository.SaveWithReturnDomainObject<PUR_T001_A>(MasterEntity, "", "PurchaseRequisition", "Reflection.BusinessLogic.PUR_T001_ABL");
                        SetBusinessEntitiesAfterLoad("Save", "");
                        if (MasterEntity.req_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnInsert") >= 0)
                        {
                            NotifyMessage("OnInsert", "Created");
                        }
                        if (MasterEntity.req_no != null && NotificationDataCollection.FindIndex(f => f.alert_name == "OnApproval") >= 0)
                        {
                            NotifyMessage("OnApproval", "Created");
                        }

                    }
                    else if (NewRecord == false)
                    {
                        //MasterEntity = repository.UpdateWithReturnDomainObject<PUR_T001_A>(MasterEntity, "PRO_T001_BL", "PRO");
                        MCTemp = repositoryM.UpdateWithReturnDomainObject<MultipleContext_PUR_T001_A>(MCTemp, "PRO_T001_BL", "PRO");
                        //MasterEntity = repository.UpdateWithReturnDomainObject<PUR_T001_A>(MasterEntity, "", "PurchaseRequisition", "Reflection.BusinessLogic.PUR_T001_ABL");
                        SetBusinessEntitiesAfterLoad("Save", "");
                    }
                    
                    NewRecord = false;
                    _dataGridCollection.SortDescriptions.Add(new SortDescription("req_no", ListSortDirection.Descending));
                }

                var msg = new NotificationMessage("PRO_T001_VM");
                Messenger.Default.Send<NotificationMessage>(msg);
            }
            catch (Exception ex) { }
        }

        private bool validation()
        {
            if (MasterEntity.pg_code == null || MasterEntity.pg_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Purchage Organisation details required!");
                showMessageService.ShowMessage();
                return false;
            }
            if ( string.IsNullOrWhiteSpace(MasterEntity.dept_code))
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Department required!");
                showMessageService.ShowMessage();
                return false;
            }
            // Validation for record modification depends on workflow and status
            foreach (var o in MC.DOC_TYPE_LIST)
            {

                if (o.doc_cat == MasterEntity.doc_cat && o.Workflow_id_temp != null)
                {
                    if (MasterEntity.t_status == (from x in MC.STATUS_LIST where x.ind_released == "1" select x.t_status).FirstOrDefault())
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("You cannot edit record once it is Approved");
                        showMessageService.ShowMessage();
                        return false;
                    }

                }

            }

            if (Pur_Req_Details.Count < 1)//when form is blank and we save the record
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("At Least Insert One Item........");
                showMessageService.ShowMessage();

                return false;
            }
            else
            {
                foreach (var o in Pur_Req_Details)
                {
                    if (o.ItemCode != null && o.ItemCode != "" && o.description != null)
                    {
                        int flag = 0;
                        if (o.id == 0)
                        {
                            foreach (var p in Pur_Req_Details)
                            {
                                if (o.ItemCode == p.ItemCode && o.description == p.description && o.sku == p.sku && o.line_id == p.line_id && o.sono == p.sono)
                                {
                                    flag++;
                                }
                            }
                            if (flag > 1)
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Cannot Save Duplicate Item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                                showMessageService.ShowMessage();
                                return false;
                            }
                        }


                        // Validation For All Parameter Values Selected or Not

                        if (o.StockUnt == true && o.id == 0)
                        {
                            var paralist = (from p in MC.ParameterList where p.SubCatCode == o.SubCatCode select p).ToList();

                            if (paralist.Count > 0)
                            {
                                string[] SkuList = new string[100];           //string array
                                List<string> SkuListt = new List<string>();    // stringlist

                                if (o.sku != null && o.sku != "")
                                {
                                    SkuList = o.sku.Split('/');
                                    SkuListt = SkuList.ToList();

                                    foreach (var item in SkuList)
                                    {
                                        if (item == "")
                                        {
                                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                            showMessageService.ButtonSetup = DialogButton.Ok;
                                            showMessageService.Caption = "Parameter Validation";
                                            showMessageService.Text = String.Format("All Parameters of item {0} of index {1} are not selected..!!! \n Check Parameter at index {2} is selected or not. \n ", o.ItemCode, Pur_Req_Details.IndexOf(o), SkuList.ToList().IndexOf(item));
                                            showMessageService.ShowMessage();
                                            return false;
                                        }
                                    }
                                }
                                else
                                {
                                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                    showMessageService.ButtonSetup = DialogButton.Ok;
                                    showMessageService.Caption = "Parameter Validation";
                                    showMessageService.Text = String.Format("All Parameters of item {0} of index {1} are not selected\n If you can see All Parameter Value Selected Please Select the Same Values Again ", o.ItemCode, Pur_Req_Details.IndexOf(o));
                                    showMessageService.ShowMessage();
                                    return false;
                                }
                            }

                        }

                        
                        if (o.qty == null || o.qty == 0)
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("Quantity cannot be null or 0 for the item {0} and Parameter {1}", o.ItemCode, o.sku_desc);
                            showMessageService.ShowMessage();
                            return false;
                        }


                    }
                    else
                    {

                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("please select Item ........");
                        showMessageService.ShowMessage();
                        return false;
                    }

                }

            }
            return true;

        }

        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            if (MCTemp.Pur_Req != null)
            {
                if (MCTemp.Pur_Req.Count > 0)
                {
                    MasterEntity = MCTemp.Pur_Req[0];
                    Pur_Req_Details.Clear();
                    Pur_Req_Details = MCTemp.Pur_Req_Details;
                    dgItemScheduleEntity.Clear();
                    dgItemScheduleEntity = MCTemp.Pur_Req_Schedule;

                    // NOTE: need to update
                    ReleaseList = MCTemp.WORKFLOW_LIST;
                    //MC.Pur_Req_Details = (ObservableCollection<PUR_T001_B>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_PUR_T001_B, MC.Pur_Req_Details);
                    //Pur_Req_Details.Clear();
                    //Pur_Req_Details = MC.Pur_Req_Details;
                }

            }
            else
            {
                MC.Pur_Req_Details = new ObservableCollection<PUR_T001_B>();
                MC.Pur_Req_Schedule = new ObservableCollection<PUR_T001_C>();
            }


            if (MasterEntity.XmlDataDocument_FlipGrid != null && NewRecord == true && ParameterOption1 == "Save")
            {
                MC.DocumentDataFlipGrid = (List<PUR_T001_AFlip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
            }
            MasterEntity.ts_code = ts_code_vm;
        }

        protected override void OnCreateAction(InquiryActionResult<PUR_T001_A> result)
        {

            NewRecord = true;
            MasterEntity = new PUR_T001_A();
            ITEM_OBJ = new PUR_T001_B();
            MasterEntity.ValidateAsync().Wait();
            Pur_Req_Details = new ObservableCollection<PUR_T001_B>();
            dgItemScheduleEntity = new ObservableCollection<PUR_T001_C>();
            //Pur_Req_Details.Clear();

            DefaultValues();


            _dataGridCollection.Refresh();
            var msg = new NotificationMessage("PRO_T001_VM");
            Messenger.Default.Send<NotificationMessage>(msg);


        }
        protected override void OnRemoveAction(InquiryActionResult<PUR_T001_A> result)
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
                string response = repository.Delete(MasterEntity.req_no, "PRO_T001_BL", "PRO");
                //SelectedList.Remove(MasterEntity);
                _dataGridCollection.Refresh();
                MasterEntity = new PUR_T001_A();
                Pur_Req_Details = new ObservableCollection<PUR_T001_B>();
                NewRecord = true;
            }
        }
        protected override void OnDiscardAction(InquiryActionResult<PUR_T001_A> result)
        {
            MasterEntity.CancelEdit();
        }
        protected override void OnFevoriteAction(InquiryActionResult<PUR_T001_A> result)
        {
            SelectedList = SelectedList;
        }
        protected override void OnFlipAction(InquiryActionResult<PUR_T001_A> result)
        {
            SelectedList = SelectedList;
            MasterEntity = MasterEntity;
        }
        protected override void OnHelpAction(InquiryActionResult<PUR_T001_A> result)
        {
            SelectedList = SelectedList;
            MasterEntity = MasterEntity;
        }
        protected override void OnPrintAction(InquiryActionResult<PUR_T001_A> result)
        {
            try
            {
                CursorControl.SetBusyState();
                ReportManager ReportManager = new ReportManager();
                object[] objDataSource = new object[6];
                string[] objDataSourceName = new string[6];
                string ReportName = "";


                var CmpResult = AppSessionState.COMPANY_LIST.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[0] = CmpResult;

                var Result = AppSessionState.LOCATION_LIST.Where(loc => loc.location_id == MasterEntity.location_Id).ToList();
                objDataSource[1] = Result;

                if (MC.Pur_Req != null)
                {
                    if (MC.Pur_Req.Count > 0)
                    {
                        MC.Pur_Req.Clear();
                        MC.Pur_Req.Add(MasterEntity);
                    }
                    else
                    {
                        MC.Pur_Req.Add(MasterEntity);
                    }
                }

                objDataSource[2] = MC.Pur_Req;
                objDataSource[3] = Pur_Req_Details;
                objDataSource[4] = dgItemScheduleEntity;
                objDataSource[5] = ReleaseList;

                objDataSourceName[0] = "dsCompany";
                objDataSourceName[1] = "dsLocation";
                objDataSourceName[2] = "dsMaster";
                objDataSourceName[3] = "dsItems";
                objDataSourceName[4] = "dsSchedule";
                objDataSourceName[5] = "dsRS";

                if (MC.DOC_TYPE_LIST != null)
                {
                    if (MC.DOC_TYPE_LIST.Count > 0)
                    {
                        var DOC_TYPE_OBJ = (from o in MC.DOC_TYPE_LIST where o.doc_cat == doc_cat_vm && o.doc_type == MasterEntity.doc_type select o).FirstOrDefault();
                        if (DOC_TYPE_OBJ.ind_digital == "0")
                        {
                            ReportName = DOC_TYPE_OBJ.report_name.Split(',')[1];
                        }
                        else
                        {
                            ReportName = DOC_TYPE_OBJ.report_name.Split(',')[0];
                        }
                    }
                }

                string ReportDisplayName = (MasterEntity.EmpNm ?? "") + "_" + MasterEntity.req_no + "_" + MasterEntity.date_start.Value.ToShortDateString();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\REPORTS_STD\\TXN\\" + ReportName, ReportDisplayName);

            }
            catch (Exception ex) { }
        }

        //protected override void OnExportAction(InquiryActionResult<PUR_T001_A> result)
        //{
        //    try
        //    {
        //        List<PUR_T001_A> Export_List = new List<PUR_T001_A>();
        //        foreach (var o in DataGridCollection)
        //        {
        //            PUR_T001_A Data = o as PUR_T001_A;
        //            Export_List.Add(Data);
        //        }

        //        //--------------------------------------

        //        ExportToExcel<PUR_T001_A, List<PUR_T001_A>> export = new ExportToExcel<PUR_T001_A, List<PUR_T001_A>>();
        //        ICollectionView view = CollectionViewSource.GetDefaultView(Export_List);
        //        export.dataToPrint = (List<PUR_T001_A>)view.SourceCollection;

        //        export.GenerateReport();
        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format(ex.Message, this.Title);
        //        showMessageService.ShowMessage();
        //    }

        //}


        protected override void OnDocumentAction()
        {
            //throw new NotImplementedException();
        }
        protected override void OnRefreshCommand(InquiryActionResult<PUR_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<PUR_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<PUR_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<PUR_T001_A> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<PUR_T001_A> result)
        {
            throw new NotImplementedException();
        }
        #endregion

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

        #region filters

        private string _filterString;
        private string _filterStringPriority;
        private string _filterStringEmp;
        private string _filterStringItems;
        private string _filterStringuom;
        #region Filters For Priority
        private void FilterCollectionPriority()
        {
            if (_PriorityCollection != null)
            {
                _PriorityCollection.Refresh();
            }
        }
        public string FilterStringPriority
        {
            get { return _filterStringPriority; }
            set
            {
                _filterStringPriority = value;
                RaisePropertyChanged("FilterStringPriority");
                FilterCollectionPriority();
            }
        }
        public bool PriorityFilter(object obj)
        {
            var data = obj as ADM_M040_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringPriority))
                {
                    return (data.priority != null && data.priority.ToString().ToLower().Contains(_filterStringPriority.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Emp
        private void FilterCollectionEmp()
        {
            if (_EmpCollection != null)
            {
                _EmpCollection.Refresh();
            }
        }
        public string FilterStringEmp
        {
            get { return _filterStringEmp; }
            set
            {
                _filterStringEmp = value;
                RaisePropertyChanged("FilterStringEmp");
                FilterCollectionEmp();
            }
        }
        public bool EmpFilter(object obj)
        {
            var data = obj as ADM_M024_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringEmp))
                {
                    return (data.EmpName != null && data.EmpName.ToLower().Contains(_filterStringEmp.ToLower())) ||
                            (data.EmpFName != null && data.EmpFName.ToLower().Contains(_filterStringEmp.ToLower())) ||
                             (data.EmpId != null && data.EmpId.ToLower().Contains(_filterStringEmp.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For Items
        private void FilterCollectionItems()
        {
            if (_ItemsCollection != null)
            {
                _ItemsCollection.Refresh();
            }
        }
        public string FilterStringItems
        {
            get { return _filterStringItems; }
            set
            {
                _filterStringItems = value;
                RaisePropertyChanged("FilterStringItems");
                FilterCollectionItems();
            }
        }
        public bool ItemsFilter(object obj)
        {
            var data = obj as ADM_M022_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringItems))
                {
                    return ((data.ItemCode != null) && data.ItemCode.ToLower().Contains(_filterStringItems.ToLower())) ||
                           (data.ItemName != null && data.ItemName.ToString().ToLower().Contains(_filterStringItems.ToLower())) ||
                           (data.SubCatName != null && data.SubCatName.ToString().ToLower().Contains(_filterStringItems.ToLower())) ||
                           (data.CatCode != null && data.CatCode.ToString().ToLower().Contains(_filterStringItems.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion

        #region Filters For uom
        private void FilterCollectionuom()
        {
            if (_uomCollection != null)
            {
                _uomCollection.Refresh();
            }
        }
        public string FilterStringuom
        {
            get { return _filterStringuom; }
            set
            {
                _filterStringuom = value;
                RaisePropertyChanged("FilterStringuom");
                FilterCollectionuom();
            }
        }
        public bool uomFilter(object obj)
        {
            var data = obj as ADM_M038_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterStringuom))
                {
                    return (data.unit_name != null && data.unit_name.ToString().ToLower().Contains(_filterStringuom.ToLower())) ||
                        (data.unit_code != null && data.unit_code.ToString().ToLower().Contains(_filterStringuom.ToLower()));

                }
                return true;
            }
            return false;
        }

        #endregion


        #region itemcategory
        //itemcategory
        private string _filterString_itemcategory;
        public string FilterString_itemcategory
        {
            get { return _filterString_itemcategory; }
            set
            {
                _filterString_itemcategory = value;
                RaisePropertyChanged("FilterString_itemcategory");
                FilterCollectionitemcategory();
            }
        }
        private void FilterCollectionitemcategory()
        {
            if (_itemcategoryCollection != null)
            {
                _itemcategoryCollection.Refresh();
            }
        }
        public bool Filteritemcategory(object obj)
        {
            var data = obj as SYS_M008_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_itemcategory))
                {
                    return (data.item_cat != null && data.item_cat.ToString().ToLower().Contains(_filterString_itemcategory.ToLower()) ||
                        data.cat_desc != null && data.cat_desc.ToString().ToLower().Contains(_filterString_itemcategory.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion

        //SO No Filters
        private string _FilterString_SO;
        public string FilterString_SO
        {
            get { return _FilterString_SO; }
            set
            {
                _FilterString_SO = value;
                RaisePropertyChanged("FilterString_SO");
                FilterCollection_SO();
            }
        }
        private void FilterCollection_SO()
        {
            if (_SOCollection != null)
            {
                _SOCollection.Refresh();
            }

        }
        public bool Filter_SO(object obj)
        {
            var data = obj as SEL_T001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_SO))
                {
                    return (data.sono != null && data.sono.ToString().ToLower().Contains(_FilterString_SO.ToLower())) ||
                           (data.sodate != null && data.sodate.ToString().ToLower().Contains(_FilterString_SO.ToLower())) ||
                           (data.roundup_total != null && data.roundup_total.ToString().ToLower().Contains(_FilterString_SO.ToLower())) ||
                           (data.quantity.ToString() != null && data.quantity.ToString().ToLower().Contains(_FilterString_SO.ToLower())) ||
                           (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_FilterString_SO.ToLower())) ||
                           (data.party_name != null && data.party_name.ToString().ToLower().Contains(_FilterString_SO.ToLower())) ||
                           (data.address != null && data.address.ToString().ToLower().Contains(_FilterString_SO.ToLower()));

                }
                return true;
            }
            return false;
        }



        #region "Filter for Back Content Datagrid"
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
            var data = obj as PUR_T001_AFlip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString))
                {
                    return (data.req_no != null && data.req_no.ToString().ToLower().Contains(_filterString.ToLower())) ||
                      (data.date_start != null && data.date_start.ToString().ToLower().Contains(_filterString.ToLower())) ||
                      (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_filterString.ToLower())) ||
                      (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_filterString.ToLower())) ||
                      (data.t_display != null && data.t_display.ToString().ToLower().Contains(_filterString.ToLower())) ||
                      (data.status_remark != null && data.status_remark.ToString().ToLower().Contains(_filterString.ToLower())) ||
                      (data.req_ref != null && data.req_ref.ToString().ToLower().Contains(_filterString.ToLower())) ||
                      (data.pg_name != null && data.pg_name.ToString().ToLower().Contains(_filterString.ToLower())) ||
                      (data.pur_org != null && data.pur_org.ToString().ToLower().Contains(_filterString.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion
        #endregion

        #region Schedule Region

        // This function will invoke on changes of Observable Collection.
        private void CollectionChangedNotifyForSchedule(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Temp Test
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (PUR_T001_C item in e.NewItems)
                    item.PropertyChanged += this.Schedule_PropertyChanged;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (PUR_T001_C item in e.OldItems)
                    item.PropertyChanged -= this.Schedule_PropertyChanged;

            // Temp Test End

            if (e.Action == NotifyCollectionChangedAction.Add && Pur_Req_Details.Count > 0) // Schedule can only enable to add if items exists in Items Entity.
            {
                try
                {
                    foreach (PUR_T001_C item in e.NewItems)
                    {
                        //Adde items Schedules Default Values from Items Entity
                        item.line_id = (dgItemScheduleEntity.Count - 1) + 1;
                        item.t_status = Pur_Req_Details[dgSelectedIndexItem].t_status;
                        item.item_line_id = Pur_Req_Details[dgSelectedIndexItem].line_id;
                        item.t_display = Pur_Req_Details[dgSelectedIndexItem].t_display;
                        item.active = true;
                        item.exp_date = Pur_Req_Details[dgSelectedIndexItem].expected_date;
                        item.req_no = Pur_Req_Details[dgSelectedIndexItem].req_no;
                        item.req_item_row_id = Pur_Req_Details[dgSelectedIndexItem].id;
                        item.PropertyChanged += EntityViewModelPropertyChanged;
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
            if (e.Action == NotifyCollectionChangedAction.Replace)
            {
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
            }
            if (e.Action == NotifyCollectionChangedAction.Move)
            {

            }
        }

        // This function will invoke on changes of Observable Collection.
        private void CollectionChangedNotifyForItem(object sender, NotifyCollectionChangedEventArgs e)
        {
            try
            {
                if (e.Action == NotifyCollectionChangedAction.Add)
                {
                    foreach (PUR_T001_B item in e.NewItems)
                    {
                        //Added items
                        if (Pur_Req_Details != null)
                        {
                            if (item.line_id == 0 || item.line_id == null) // NOTE: This event calls twice and to protect this to increse same line_id twice, this if condition added on 14/12/2022, also update same logic to other VM. Also this logic added to check max value and then increase one, earlier it was assigning row count to new value but if there are 5 item and one deleted then it was assigning same number again.
                            {
                                int maxValue = Pur_Req_Details.Max(x => x.line_id);
                                item.line_id = maxValue + 1;
                            }

                            // Commented this function because Explode BOM was not working if qty already exists
                            //if ((MasterEntity.doc_type=="RS" || MasterEntity.doc_type == "SO") && (item.quantity == 0 || item.quantity == null)) // NOTE: This event calls twice and to protect this to increse same line_id twice, this if condition added on 14/12/2022, also update same logic to other VM. Also this logic added to check max value and then increase one, earlier it was assigning row count to new value but if there are 5 item and one deleted then it was assigning same number again.
                            //{
                            //    item.quantity = 1;
                            //}
                            //if (ItemsEntity.Count > 0)
                            //{
                            //    int maxValue = ItemsEntity.Max(x => x.line_id);
                            //    item.line_id = maxValue++;
                            //}
                            //else
                            //{
                            //    item.line_id = ItemsEntity.Count;
                            //}

                        }
                        else
                        {
                            item.line_id = 1;
                        }
                        //item.line_id = (Pur_Req_Details.Count - 1) + 1;
                        item.active = true;
                        item.comp_code = MasterEntity.comp_code;
                        item.expected_date = DateTime.Now.Date;
                        item.item_cat = "A";
                        item.location_Id = MasterEntity.location_Id;
                        item.pg_code = AppSessionState.pg_code;
                        item.po_code = AppSessionState.po_code;
                        item.t_status = MasterEntity.t_status;
                        item.t_display = MasterEntity.t_display;
                        item.PropertyChanged += EntityViewModelPropertyChanged;
                        item.user_source1 = MasterMake;
                        item.para1 = MasterMakeCode;
                        item.user_source2 = MasterType;
                        item.para2 = MasterTypeCode;
                        if (string.IsNullOrEmpty(MasterMakeCode) == false)
                        {
                            item.sku = item.para1 + "/" + item.para2 + "/10630";
                            item.sku_desc = "Make : " + item.user_source1 + ", Type : " + item.user_source2;
                        }
                    }
                }

                if (e.Action == NotifyCollectionChangedAction.Replace)
                {
                    this.ErrorExist = false; /*MasterEntity.HasErrors;*/
                    if (Pur_Req_Details.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = Pur_Req_Details[dgSelectedIndexItem].HasErrors;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Remove)
                {
                    PUR_T001_B temp = (PUR_T001_B)e.OldItems[0];
                    foreach (var itemToRemove in dgItemScheduleEntity.Where(x => (x.item_line_id == temp.line_id && x.id == 0)).ToList())
                    {
                        dgItemScheduleEntity.Remove(itemToRemove);
                    }
                    foreach (PUR_T001_B item in e.OldItems)
                    {
                        item.PropertyChanged -= EntityViewModelPropertyChanged;
                    }
                    if (Pur_Req_Details.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                    {
                        this.ErrorExist = Pur_Req_Details[dgSelectedIndexItem].HasErrors;
                    }
                }
                if (e.Action == NotifyCollectionChangedAction.Move)
                {
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
        void Schedule_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                if (e.PropertyName == "qty")
                {
                    if (MasterEntity.doc_type != "OP")
                    {
                        #region Check Schedule Qty Total should not exceed PR Item Qty.
                        decimal? TotalQtyOfScheduleForItem = dgItemScheduleEntity.Where(item => item.item_line_id == Pur_Req_Details[dgSelectedIndexItem].line_id).Sum(item => item.qty);
                        decimal? PRQty = Pur_Req_Details[dgSelectedIndexItem].qty;
                        if (TotalQtyOfScheduleForItem > PRQty)
                        {
                            //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            //showMessageService.ButtonSetup = DialogButton.Ok;
                            //showMessageService.Caption = "Schedule Information";
                            //showMessageService.Text = String.Format("Schedule quantity exceeding PR Line Item limit.", this.Title);
                            //showMessageService.ShowMessage();
                        }
                    }
                    #endregion
                }
                else if (e.PropertyName == "exp_date")
                {
                    #region Check Schedule Date greater than PR Date.
                    List<PUR_T001_C> data = new List<PUR_T001_C>();
                    data = dgItemScheduleEntity.Where(item => item.item_line_id == Pur_Req_Details[dgSelectedIndexItem].line_id).ToList();
                    var date = data.Select(x => x.exp_date);
                    foreach (var verObj in date)
                    {
                        var ScheduleDate = Convert.ToDateTime(verObj).Date;
                        var PRDate = Convert.ToDateTime(MasterEntity.date_start).Date;

                        if (ScheduleDate < PRDate)
                        {
                            //IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            //showMessageService.ButtonSetup = DialogButton.Ok;
                            //showMessageService.Caption = "PR Schedule Information";
                            //showMessageService.Text = String.Format("Schedule Date Should be greater than PR Date.", this.Title);
                            //showMessageService.ShowMessage();
                        }
                    }
                    #endregion
                }
                if (Pur_Req_Details.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = Pur_Req_Details[dgSelectedIndexItem].HasErrors;
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

        //This will get called when the property of an object inside the collection changes
        void ModelUpdatedShedule(object sender, EventArgs e)
        {
            if (EntityChangeEnable == true)
            {

            }
        }

        // FilterScheduleDataGrid : Filter for Schedule Items as per selected item in Pur_Req_Details. This filter is work for ObserverableCollection.
        private void FilterScheduleDataGrid()
        {
            try
            {
                if (dgItemScheduleEntity != null && dgItemScheduleEntity.Count > 0 && dgSelectedIndexItem >= 0
                        && Pur_Req_Details != null && Pur_Req_Details.Count > 0 && Pur_Req_Details.Count > dgSelectedIndexItem)
                {
                    if (Pur_Req_Details[dgSelectedIndexItem].ItemCode != null)
                    {
                        DataGridViewFilter = CollectionViewSource.GetDefaultView(dgItemScheduleEntity);
                        DataGridViewFilter.Filter = adv => ((PUR_T001_C)adv).item_line_id.Equals(Pur_Req_Details[dgSelectedIndexItem].line_id);
                        DataGridViewFilter.Refresh();
                    }
                }
            }
            catch (Exception ex)
            { }
        }
        public void EntityViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            try
            {
                //This will get called when the property of an object inside the collection changes
                this.ErrorExist = false;/*MasterEntity.HasErrors;*/
                if (Pur_Req_Details.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
                {
                    this.ErrorExist = Pur_Req_Details[dgSelectedIndexItem].HasErrors;
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

        private void DeleteDataGridRow_ItemSchedule(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (dgItemScheduleEntity.Count > i)
                {
                    dgItemScheduleEntity.RemoveAt(i);
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
        private void LoadBackFlipData(object Parameter)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "LoadBackFlipData" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.UserID + "!@" + SearchEntityObject.active + "!@" + Convert.ToDateTime(SearchEntityObject.from_date).ToString("MM/dd/yyyy") + "!@" + Convert.ToDateTime(SearchEntityObject.to_date).ToString("MM/dd/yyyy") + "!@" + AppSessionState.po_code + "!@" + AppSessionState.pg_code;

                MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_PUR_T001_A>(MCTemp, Request, "PRO_T001_BL", "PRO", "LoadAll", 0, "");

                FlipGridData = MCTemp.DocumentDataFlipGrid.ToList();
                DataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                DataGridCollection.Filter = new Predicate<object>(Filter);

                //var msg = new NotificationMessage("SEL_T001_VM");
                //Messenger.Default.Send<NotificationMessage>(msg);
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

        private void GeneratePR(object Parameter)
        {
            try
            {
                CursorControl.SetBusyState();
                string Request = "GENERATE_PR_DATA" + "!@" + AppSessionState.client + "!@" + AppSessionState.OBJ_COMPANY.comp_code + "!@" + AppSessionState.OBJ_LOCATION.location_id + "!@" + doc_cat_vm + "!@" + doc_cat_vm + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.UserID + "!@" + MasterEntity.po_code + "!@" + MasterEntity.pg_code;

                MCTemp = repositoryM.GetDataWithReturnDomainObject<MultipleContext_PUR_T001_A>(MCTemp, Request, "PRO_T001_BL", "PRO", "LoadAll", 0, "");

                if (MCTemp.STANDARD_LIST != null)
                {
                    if (MCTemp.STANDARD_LIST.Count > 0)
                    {
                        AppSessionState.TransactionCode = "UC01";
                        AppSessionState.ViewTitle = "MATERIAL LIST";

                        string path1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Reflection.Modules.PRO.dll");
                        Assembly assembly = Assembly.LoadFile(path1);
                        Type type = assembly.GetType("Reflection.Modules.PRO.Views.PRO_U0001");
                        if (type != null)
                        {
                            dynamic instance = Activator.CreateInstance(type, AppSessionState.TransactionCode, MCTemp.STANDARD_LIST);
                            SimpleIoc.Default.GetInstance<IVirtualDesktopManager>().Show(instance);
                        }
                    }
                }
                else
                {
                    IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                    showMessageService.ButtonSetup = DialogButton.Ok;
                    showMessageService.Caption = "Message";
                    showMessageService.Text = String.Format("Data not exists", this.Title);
                    showMessageService.ShowMessage();
                }

                //var msg = new NotificationMessage("SEL_T001_VM");
                //Messenger.Default.Send<NotificationMessage>(msg);
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

        private void NotificationMessageReceived(NotificationMessage msg)
        {
            // NOTE: instead of hardcoded "POS_CUST" value, use variable like type_code from STD_LIST_BE so that we can use everyware and use notification value as a generic. like we can use it for identify calling screen so that it will get by right screen and not all, even that can also done by STD_LIST_BE object.
            if (msg.Notification == "SELECTED_PR_ITEMS")
            {
                foreach (var item in (List<STD_LIST_BE>)msg.Sender)
                {
                    if (item.selected == true)
                    {
                        dgSelectedIndexItem=Pur_Req_Details.Count;
                        InsertDataGridRow_Item(item.item_code, true, item);
                        if (Pur_Req_Details.Count > 0)
                        {
                            Pur_Req_Details[dgSelectedIndexItem].ref_doc_cat = item.ref_doc_cat;
                            Pur_Req_Details[dgSelectedIndexItem].ref_doc_no = item.ref_doc_no;
                            Pur_Req_Details[dgSelectedIndexItem].ref_item_row_id = item.item_row_id;

                            if(item.ref_doc_cat=="SO")
                            {
                                Pur_Req_Details[dgSelectedIndexItem].sono = item.ref_doc_no;
                                Pur_Req_Details[dgSelectedIndexItem].order_no = item.ref_doc_no;
                            }
                            else if(item.ref_doc_cat == "OR")
                            {
                                Pur_Req_Details[dgSelectedIndexItem].order_no = item.ref_doc_no;
                            }
                        }
                    }
                }
            }
        }


        #endregion

        #region SKU for Hardcoded Screen
        private void InsertMake(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    Pur_Req_Details[dgSelectedIndexItem].para1 = POPUPEntityObject.value_code;
                    Pur_Req_Details[dgSelectedIndexItem].user_source1 = POPUPEntityObject.parametervalue;
                    CalculateSkuHardcoded();
                }
                else
                {
                    Pur_Req_Details[dgSelectedIndexItem].user_source1 = null;
                    Pur_Req_Details[dgSelectedIndexItem].para1 = null;
                    Pur_Req_Details[dgSelectedIndexItem].sku = null;
                    Pur_Req_Details[dgSelectedIndexItem].sku_desc = null;
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
        private void InsertType(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
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
                    Pur_Req_Details[dgSelectedIndexItem].para2 = POPUPEntityObject.value_code;
                    Pur_Req_Details[dgSelectedIndexItem].user_source2 = POPUPEntityObject.parametervalue;
                    CalculateSkuHardcoded();
                }
                else
                {
                    Pur_Req_Details[dgSelectedIndexItem].user_source2 = null;
                    Pur_Req_Details[dgSelectedIndexItem].para2 = null;
                    Pur_Req_Details[dgSelectedIndexItem].sku = null;
                    Pur_Req_Details[dgSelectedIndexItem].sku_desc = null;
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
        private void InsertMasterMake(object InputValue)
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
                            {
                                POPUPEntityObject = MC.ParamValueList.Where(x => x.parametervalue.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
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
                    MasterMake = POPUPEntityObject.parametervalue;
                    MasterMakeCode = POPUPEntityObject.value_code;
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
        private void InsertMasterType(object InputValue)
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
                            {
                                POPUPEntityObject = MC.ParamValueList.Where(x => x.parametervalue.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
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
                    MasterType = POPUPEntityObject.parametervalue;
                    MasterTypeCode = POPUPEntityObject.value_code;
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
        private void CalculateSkuHardcoded()
        {
            if (Pur_Req_Details[dgSelectedIndexItem].user_source1 != null && Pur_Req_Details[dgSelectedIndexItem].user_source1 != "" && Pur_Req_Details[dgSelectedIndexItem].user_source2 != null && Pur_Req_Details[dgSelectedIndexItem].user_source2 != "")
            {
                Pur_Req_Details[dgSelectedIndexItem].sku = Pur_Req_Details[dgSelectedIndexItem].para1 + "/" + Pur_Req_Details[dgSelectedIndexItem].para2 + "/10630";
                Pur_Req_Details[dgSelectedIndexItem].sku_desc = "Make : " + Pur_Req_Details[dgSelectedIndexItem].user_source1 + ", Type : " + Pur_Req_Details[dgSelectedIndexItem].user_source2;
            }
        }
        //private void InsertCompany(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ADM_M002 POPUPEntityObject = null;
        //        #region Command Parameter Read Section
        //        try
        //        {
        //            if (InputValue.GetType() == typeof(string) && InputValue != null)
        //            {
        //                Request = InputValue.ToString();
        //                if (Request.Length > 0)
        //                {
        //                    try
        //                    { POPUPEntityObject = CompanyList.Where(x => x.comp_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                    catch (Exception ex) { }
        //                }
        //            }
        //            else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M002>().Count() > 0)
        //            {
        //                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M002>().ToList()[0];
        //            }
        //        }
        //        catch (Exception ex) { }

        //        #endregion
        //        if (POPUPEntityObject != null)
        //        {
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;

        //            //Filter Company Wise Sales Org
        //            //var CompanyWisePurOrg = (from o in PurchaseGroupList
        //            //                         where o.comp_code == MasterEntity.comp_code
        //            //                         select o).ToList();

        //            //SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M001_P_P)x).po_code);
        //            //TheFilter = (o, prefix) => (((ADM_M001_P_P)o).po_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M001_P_P)o).pur_org ?? "").ToString().ToLower().Contains(prefix.ToLower())
        //            //|| (((ADM_M001_P_P)o).pg_code ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M001_P_P)o).pg_name ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //            //ASPurOrg = new AutoSuggestTextViewModel<dynamic>(CompanyWisePurOrg, TheFilter, SuggestedValue, "po_code", true);

        //            //////Set Default values if count is 1                 
        //            //if (CompanyWisePurOrg != null && CompanyWisePurOrg.Count == 1)
        //            //{
        //            //    MasterEntity.pg_code = CompanyWisePurOrg[0].pg_code;
        //            //    MasterEntity.pg_name = CompanyWisePurOrg[0].pg_name;
        //            //    MasterEntity.po_code = CompanyWisePurOrg[0].po_code;
        //            //    MasterEntity.pg_name = CompanyWisePurOrg[0].pg_name;

        //            //}

        //            //Filter Company Wise Location
        //            var CompanyWiseLocation = (from o in LocationList
        //                                       where o.comp_code == MasterEntity.comp_code
        //                                       select o).ToList();
        //            SuggestedValue = new ValueConverter(x => x == null ? "" : ((ADM_M003)x).location_Id);
        //            TheFilter = (o, prefix) => (((ADM_M003)o).location_Id ?? "").ToString().ToLower().Contains(prefix.ToLower()) || (((ADM_M003)o).LoctnNm ?? "").ToString().ToLower().Contains(prefix.ToLower());
        //            ASPlant = new AutoSuggestTextViewModel<dynamic>(CompanyWiseLocation, TheFilter, SuggestedValue, "location_Id", true);

        //            //Set Default values if  count is 1
        //            if (CompanyWiseLocation != null && CompanyWiseLocation.Count == 1)
        //            {
        //                MasterEntity.location_Id = CompanyWiseLocation[0].location_Id;
        //                MasterEntity.comp_code = CompanyWiseLocation[0].comp_code;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format(ex.Message, this.Title);
        //        showMessageService.ShowMessage();
        //    }
        //}
        //private void InsertLocationId(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ADM_M003 POPUPEntityObject = null;
        //        #region Command Parameter Read Section
        //        try
        //        {
        //            if (InputValue.GetType() == typeof(string) && InputValue != null)
        //            {
        //                Request = InputValue.ToString();
        //                if (Request.Length > 0)
        //                {
        //                    try
        //                    { POPUPEntityObject = LocationList.Where(x => x.location_Id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                    catch (Exception ex) { }
        //                }
        //            }
        //            else if (InputValue != null && ((IEnumerable)InputValue).Cast<ADM_M003>().Count() > 0)
        //            {
        //                POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003>().ToList()[0];
        //            }
        //        }
        //        catch (Exception ex) { }

        //        #endregion
        //        if (POPUPEntityObject != null)
        //        {
        //            MasterEntity.location_Id = POPUPEntityObject.location_Id;
        //            MasterEntity.comp_code = POPUPEntityObject.comp_code;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
        //        showMessageService.ButtonSetup = DialogButton.Ok;
        //        showMessageService.Caption = "Message";
        //        showMessageService.Text = String.Format(ex.Message, this.Title);
        //        showMessageService.ShowMessage();
        //    }
        //}


        #endregion
    }
}
