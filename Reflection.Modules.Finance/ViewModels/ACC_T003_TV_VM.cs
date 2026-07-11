using Reflection.Presentation.ViewModel;
using Reflection.WebServices.Gateway;
using Reflection.Presentation.Core.Services;
using Reflection.Presentation.Core.Windows;
using System.Windows.Data;
using GalaSoft.MvvmLight.Command;
using Reflection.Presentation.Services;
using System;
using System.Collections.Generic;
using System.Collections;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Reflection.BusinessEntity;
using Reflection.ReportingServices;
using System.Collections.Specialized;
using GalaSoft.MvvmLight.Messaging;
using Reflection.BusinessEntity.CustomerRelation;

namespace Reflection.Modules.Finance.ViewModels
{
    public class ACC_T003_TV_VM : WorkspaceViewModel<ACC_T003>
    {
        #region Declaration

        bool isNewRecord = true;

        WebServiceRepository<ACC_T003> repository = new WebServiceRepository<ACC_T003>();
        WebServiceRepository<MultipleContext_ACC_T003> repository_MC = new WebServiceRepository<MultipleContext_ACC_T003>();
        WebServiceRepository<MultipleContext_ACC_T003> repository_MCTemp = new WebServiceRepository<MultipleContext_ACC_T003>();
        ObjectSerializationService obj = new ObjectSerializationService();

        private MultipleContext_ACC_T003 _MC = new MultipleContext_ACC_T003();
        public MultipleContext_ACC_T003 MC
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

        private List<Approval> _ApprovalData = new List<Approval>();
        public List<Approval> ApprovalData
        {
            get { return _ApprovalData; }
            set
            {
                if (_ApprovalData != value)
                {
                    _ApprovalData = value; RaisePropertyChanged("ApprovalData");
                }
            }
        }

        private MultipleContext_ACC_T003 _MCTemp = new MultipleContext_ACC_T003();
        public MultipleContext_ACC_T003 MCTemp
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

        private ACC_T003 _MasterEntity;
        public ACC_T003 MasterEntity
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

        private ObservableCollection<ACC_T003_A> _ItemsEntity;
        public ObservableCollection<ACC_T003_A> ItemsEntity
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

        private ObservableCollection<ACC_T003_C> _EmployeeEntity;
        public ObservableCollection<ACC_T003_C> EmployeeEntity
        {
            get { return _EmployeeEntity; }
            set
            {
                if (_EmployeeEntity != value)
                {
                    _EmployeeEntity = value; RaisePropertyChanged("EmployeeEntity");
                    EmployeeEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForEmployee);
                    RaisePropertyChanged("EmployeeEntity");
                }
            }
        }
        private bool _IsDocumentViewerShow;
        public bool IsDocumentViewerShow
        {
            get
            {
                return _IsDocumentViewerShow;
            }
            set
            {
                if (_IsDocumentViewerShow != value)
                {
                    _IsDocumentViewerShow = value;
                    RaisePropertyChanged("IsDocumentViewerShow");
                }
            }
        }

        private ObservableCollection<ACC_T003_D> _WorkOrderEntity;
        public ObservableCollection<ACC_T003_D> WorkOrderEntity
        {
            get { return _WorkOrderEntity; }
            set
            {
                if (_WorkOrderEntity != value)
                {
                    _WorkOrderEntity = value; RaisePropertyChanged("WorkOrderEntity");
                }
            }
        }

        private ObservableCollection<ACC_T003_E> _TransporterEntity;
        public ObservableCollection<ACC_T003_E> TransporterEntity
        {
            get { return _TransporterEntity; }
            set
            {
                if (_TransporterEntity != value)
                {
                    _TransporterEntity = value; RaisePropertyChanged("TransporterEntity");
                    TransporterEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForTransporter);
                    RaisePropertyChanged("TransporterEntity");
                }
            }
        }

        private ObservableCollection<ACC_T003_F> _AdvanceEntity;
        public ObservableCollection<ACC_T003_F> AdvanceEntity
        {
            get { return _AdvanceEntity; }
            set
            {
                if (_AdvanceEntity != value)
                {
                    _AdvanceEntity = value; RaisePropertyChanged("AdvanceEntity");
                    AdvanceEntity.CollectionChanged += new System.Collections.Specialized.NotifyCollectionChangedEventHandler(CollectionChangedNotifyForAdvance);
                    RaisePropertyChanged("AdvanceEntity");
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
        private List<ADM_M001_A_P> _SalesOrganisationList;
        public List<ADM_M001_A_P> SalesOrganisationList
        {
            get
            {
                return _SalesOrganisationList;
            }
            set
            {
                _SalesOrganisationList = value;
                RaisePropertyChanged("SalesOrganisationList");
            }
        }

        private List<ADM_M001_H_P> _SalesGroupList;
        public List<ADM_M001_H_P> SalesGroupList
        {
            get
            {
                return _SalesGroupList;
            }
            set
            {
                _SalesGroupList = value;
                RaisePropertyChanged("SalesGroupList");
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
        NumberToEnglish num = new NumberToEnglish();
        #endregion

        #region List
        private List<ACC_T003_Flip> _FlipGridData;
        public List<ACC_T003_Flip> FlipGridData
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

        private int _dgSelectedIndexEmp;
        public int dgSelectedIndexEmp
        {
            get
            {
                return _dgSelectedIndexEmp;
            }
            set
            {
                if (_dgSelectedIndexEmp != value)
                {
                    _dgSelectedIndexEmp = value;
                    RaisePropertyChanged("dgSelectedIndexEmp");

                }
            }
        }

        private int _dgSelectedIndexWork;
        public int dgSelectedIndexWork
        {
            get
            {
                return _dgSelectedIndexWork;
            }
            set
            {
                if (_dgSelectedIndexWork != value)
                {
                    _dgSelectedIndexWork = value;
                    RaisePropertyChanged("dgSelectedIndexWork");

                }
            }
        }

        private int _dgSelectedIndexTransport;
        public int dgSelectedIndexTransport
        {
            get
            {
                return _dgSelectedIndexTransport;
            }
            set
            {
                if (_dgSelectedIndexTransport != value)
                {
                    _dgSelectedIndexTransport = value;
                    RaisePropertyChanged("dgSelectedIndexTransport");

                }
            }
        }

        private int _dgSelectedIndexAdvance;
        public int dgSelectedIndexAdvance
        {
            get
            {
                return _dgSelectedIndexAdvance;
            }
            set
            {
                if (_dgSelectedIndexAdvance != value)
                {
                    _dgSelectedIndexAdvance = value;
                    RaisePropertyChanged("dgSelectedIndexAdvance");

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

        private ICollectionView _CustomerCollection;
        public ICollectionView CustomerCollection
        {
            get { return _CustomerCollection; }
            set { _CustomerCollection = value; RaisePropertyChanged("CustomerCollection"); }
        }

        private ICollectionView _EmpCollection;
        public ICollectionView EmpCollection
        {
            get { return _EmpCollection; }
            set { _EmpCollection = value; RaisePropertyChanged("EmpCollection"); }
        }

        private ICollectionView _EmployeeCollection;
        public ICollectionView EmployeeCollection
        {
            get { return _EmployeeCollection; }
            set { _EmployeeCollection = value; RaisePropertyChanged("EmployeeCollection"); }
        }

        private ICollectionView _HeadCollection;
        public ICollectionView HeadCollection
        {
            get { return _HeadCollection; }
            set { _HeadCollection = value; RaisePropertyChanged("HeadCollection"); }
        }

        private ICollectionView _LocationCollection;
        public ICollectionView LocationCollection
        {
            get { return _LocationCollection; }
            set { _LocationCollection = value; RaisePropertyChanged("LocationCollection"); }
        }

        private ICollectionView _sales_orgCollection;
        public ICollectionView Salse_OrgCollection
        {
            get { return _sales_orgCollection; }
            set
            {
                _sales_orgCollection = value;
                RaisePropertyChanged("Salse_OrgCollection");
            }
        }

        private ICollectionView _salse_GroupCollection;
        public ICollectionView Salse_GroupCollection
        {
            get { return _salse_GroupCollection; }
            set
            {
                _salse_GroupCollection = value;
                RaisePropertyChanged("Salse_GroupCollection");
            }
        }
        private ICollectionView _VehicleCollection;
        public ICollectionView VehicleCollection
        {
            get { return _VehicleCollection; }
            set
            {
                _VehicleCollection = value;
                RaisePropertyChanged("VehicleCollection");
            }
        }
        private ICollectionView _DriverCollection;
        public ICollectionView DriverCollection
        {
            get { return _DriverCollection; }
            set
            {
                _DriverCollection = value;
                RaisePropertyChanged("DriverCollection");
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
        private ICollectionView _ProjectCollection;
        public ICollectionView ProjectCollection
        {
            get { return _ProjectCollection; }
            set
            {
                _ProjectCollection = value;
                RaisePropertyChanged("ProjectCollection");
            }
        }
        #endregion

        #region StringList

        List<string> _StringListCustomer;
        public List<string> StringListCustomer
        {
            get { return _StringListCustomer; }
            set
            {
                if (_StringListCustomer != value)
                {
                    _StringListCustomer = value;
                }
            }
        }

        List<string> _StringListEmp;
        public List<string> StringListEmp
        {
            get { return _StringListEmp; }
            set
            {
                if (_StringListEmp != value)
                {
                    _StringListEmp = value;
                }
            }
        }
        List<string> _StringListEmployee;
        public List<string> StringListEmployee
        {
            get { return _StringListEmployee; }
            set
            {
                if (_StringListEmployee != value)
                {
                    _StringListEmployee = value;
                }
            }
        }
        List<string> _StringListHead;
        public List<string> StringListHead
        {
            get { return _StringListHead; }
            set
            {
                if (_StringListHead != value)
                {
                    _StringListHead = value;
                }
            }
        }
        private List<string> _stringListLocation;
        public List<string> StringListLocation
        {
            get { return _stringListLocation; }
            set
            {
                if (_stringListLocation != value)
                {
                    _stringListLocation = value;
                }
            }
        }

        private List<string> _strListSalesOrg;
        public List<string> StringListSalesOrg
        {
            get { return _strListSalesOrg; }
            set
            {
                if (_strListSalesOrg != value)
                {
                    _strListSalesOrg = value;
                }
            }
        }

        private List<string> _strListSalesGroup;
        public List<string> StringListSalesGroup
        {
            get { return _strListSalesGroup; }
            set
            {
                if (_strListSalesGroup != value)
                {
                    _strListSalesGroup = value;
                }
            }
        }
        private List<string> _strListVehicle;
        public List<string> StringListVehicle
        {
            get { return _strListVehicle; }
            set
            {
                if (_strListVehicle != value)
                {
                    _strListVehicle = value;
                }
            }
        }
        private List<string> _strListDriver;
        public List<string> strListDriver
        {
            get { return _strListDriver; }
            set
            {
                if (_strListDriver != value)
                {
                    _strListDriver = value;
                }
            }
        }
        private List<string> _strListProject;
        public List<string> strListProject
        {
            get { return _strListProject; }
            set
            {
                if (_strListProject != value)
                {
                    _strListProject = value;
                }
            }
        }
        #endregion

        #region Filters

        // Filter Backflip
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
        public bool Filter_FlipGrid(object obj)
        {
            var data = obj as ACC_T003_Flip;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringFlipGridData))
                {
                    return (data.doc_no != null && data.doc_no.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.doc_date != null && data.doc_date.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower())) ||
                           (data.t_status != null && data.t_status.ToString().ToLower().Contains(_FilterStringFlipGridData.ToLower()));
                }
                return true;
            }
            return false;
        }

        // Filter Party Details
        private string _FilterStringCustomer;
        public string FilterStringCustomer
        {
            get { return _FilterStringCustomer; }
            set
            {
                _FilterStringCustomer = value;
                RaisePropertyChanged("FilterStringCustomer");
                Filter_Customer();
            }
        }
        private void Filter_Customer()
        {
            if (_CustomerCollection != null)
            {
                _CustomerCollection.Refresh();
            }
        }
        public bool Filter_Customer(object obj)
        {
            var data = obj as ADM_M028_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringCustomer))
                {
                    return (data.PartyId != null && data.PartyId.ToString().ToLower().Contains(_FilterStringCustomer.ToLower())) ||
                           (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_FilterStringCustomer.ToLower()));

                }
                return true;
            }
            return false;
        }

        // Filter Employee For Master
        private string _FilterStringEmp;
        public string FilterStringEmp
        {
            get { return _FilterStringEmp; }
            set
            {
                _FilterStringEmp = value;
                RaisePropertyChanged("FilterStringEmp");
                Filter_Emp();
            }
        }
        private void Filter_Emp()
        {
            if (_EmpCollection != null)
            {
                _EmpCollection.Refresh();
            }
        }
        public bool Filter_Emp(object obj)
        {
            var data = obj as ADM_M024_POP;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringEmp))
                {
                    return (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_FilterStringEmp.ToLower())) ||
                           (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_FilterStringEmp.ToLower()));

                }
                return true;
            }
            return false;
        }

        // Filter Employee For Grid
        private string _FilterStringEmployee;
        public string FilterStringEmployee
        {
            get { return _FilterStringEmployee; }
            set
            {
                _FilterStringEmployee = value;
                RaisePropertyChanged("FilterStringEmployee");
                Filter_Employee();
            }
        }
        private void Filter_Employee()
        {
            if (_EmployeeCollection != null)
            {
                _EmployeeCollection.Refresh();
            }
        }
        public bool Filter_Employee(object obj)
        {
            var data = obj as ADM_M024_POP;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringEmployee))
                {
                    return (data.EmpId != null && data.EmpId.ToString().ToLower().Contains(_FilterStringEmployee.ToLower())) ||
                           (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_FilterStringEmployee.ToLower()));

                }
                return true;
            }
            return false;
        }

        // Filter Head Details
        private string _FilterStringHead;
        public string FilterStringHead
        {
            get { return _FilterStringHead; }
            set
            {
                _FilterStringHead = value;
                RaisePropertyChanged("FilterStringHead");
                Filter_Head();
            }
        }
        private void Filter_Head()
        {
            if (_HeadCollection != null)
            {
                _HeadCollection.Refresh();
            }
        }
        public bool Filter_Head(object obj)
        {
            var data = obj as ACC_T003_B_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringHead))
                {
                    return (data.head_code != null && data.head_code.ToString().ToLower().Contains(_FilterStringHead.ToLower())) ||
                           (data.description != null && data.description.ToString().ToLower().Contains(_FilterStringHead.ToLower()));

                }
                return true;
            }
            return false;
        }

        // Filter Location
        private string _FilterString_Location;
        public string FilterString_Location
        {
            get { return _FilterString_Location; }
            set
            {
                _FilterString_Location = value;
                RaisePropertyChanged("FilterString_Location");
                FilterCollection_Location();
            }
        }
        private void FilterCollection_Location()
        {
            if (_LocationCollection != null)
            {
                _LocationCollection.Refresh();
            }
        }
        public bool Filter_Location(object obj)
        {
            var data = obj as ADM_M003_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_FilterString_Location))
                {
                    return (data.location_Id != null && data.location_Id.ToString().ToLower().Contains(_FilterString_Location.ToLower())) ||
                        (data.LoctnNm != null && data.LoctnNm.ToString().ToLower().Contains(_FilterString_Location.ToLower()));


                }
                return true;
            }
            return false;
        }

        // Filter Sales Organization
        private string _filterString_SalesOrg;
        public string FilterString_SalesOrg
        {
            get { return _filterString_SalesOrg; }
            set
            {
                _filterString_SalesOrg = value;
                RaisePropertyChanged("FilterString_SalesOrg");
                FilterCollection_SalesOrg();
            }
        }
        private void FilterCollection_SalesOrg()
        {
            if (_sales_orgCollection != null)
            {
                _sales_orgCollection.Refresh();
            }
        }
        public bool Filter_SalesOrg(object obj)
        {
            var data = obj as ADM_M001_A_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SalesOrg))
                {
                    return (data.so_code != null && data.so_code.ToString().ToLower().Contains(_filterString_SalesOrg.ToLower())) ||
                       (data.sales_org != null && data.sales_org.ToString().ToLower().Contains(_filterString_SalesOrg.ToLower()));
                }
                return true;
            }
            return false;
        }

        // Filter Sales Group
        private string _filterString_SalesGroup;
        public string FilterString_SalesGroup
        {
            get { return _filterString_SalesGroup; }
            set
            {
                _filterString_SalesGroup = value;
                RaisePropertyChanged("FilterString_SalesGroup");
                FilterCollection_SalesGroup();
            }
        }
        private void FilterCollection_SalesGroup()
        {
            if (_salse_GroupCollection != null)
            {
                _salse_GroupCollection.Refresh();
            }
        }
        public bool Filter_SalesGroup(object obj)
        {
            var data = obj as ADM_M001_H_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_SalesGroup))
                {
                    return (data.sg_code != null && data.sg_code.ToString().ToLower().Contains(_filterString_SalesGroup.ToLower())) ||
                       (data.sg_name != null && data.sg_name.ToString().ToLower().Contains(_filterString_SalesGroup.ToLower()));
                }
                return true;
            }
            return false;
        }

        // Filter Vehicle Details
        private string _FilterStringVehicle;
        public string FilterStringVehicle
        {
            get { return _FilterStringVehicle; }
            set
            {
                _FilterStringVehicle = value;
                RaisePropertyChanged("FilterStringVehicle");
                Filter_Vehicle();
            }
        }
        private void Filter_Vehicle()
        {
            if (_VehicleCollection != null)
            {
                _VehicleCollection.Refresh();
            }
        }
        public bool Filter_Vehicle(object obj)
        {
            var data = obj as ACC_T003_H_POPUP;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringVehicle))
                {
                    return (data.vehicle_id != null && data.vehicle_id.ToString().ToLower().Contains(_FilterStringVehicle.ToLower())) ||
                          (data.vehicle_name != null && data.vehicle_name.ToString().ToLower().Contains(_FilterStringVehicle.ToLower())) ||
                          (data.driver_name != null && data.driver_name.ToString().ToLower().Contains(_FilterStringVehicle.ToLower())) ||
                          (data.vehicle_no != null && data.vehicle_no.ToString().ToLower().Contains(_FilterStringVehicle.ToLower()));

                }
                return true;
            }
            return false;
        }

        // Filter Driver Details
        private string _FilterStringDriver;
        public string FilterStringDriver
        {
            get { return _FilterStringDriver; }
            set
            {
                _FilterStringDriver = value;
                RaisePropertyChanged("FilterStringDriver");
                Filter_Driver();
            }
        }
        private void Filter_Driver()
        {
            if (_DriverCollection != null)
            {
                _DriverCollection.Refresh();
            }
        }
        public bool Filter_Driver(object obj)
        {
            var data = obj as ADM_M024_POP;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(FilterStringDriver))
                {
                    return (data.driver_id != null && data.driver_id.ToString().ToLower().Contains(_FilterStringDriver.ToLower())) ||
                           (data.EmpName != null && data.EmpName.ToString().ToLower().Contains(_FilterStringDriver.ToLower()));

                }
                return true;
            }
            return false;
        }
        #region . DocType .
        private string _filterString_doctype;
        public string FilterString_doctype
        {
            get { return _filterString_doctype; }
            set
            {
                _filterString_doctype = value;
                RaisePropertyChanged("FilterString_doctype");
                FilterCollection_doctype();
            }
        }
        private void FilterCollection_doctype()
        {
            if (_doc_typeCollection != null)
            {
                _doc_typeCollection.Refresh();
            }
        }
        public bool doctype_Filter(object obj)
        {
            var data = obj as SYS_M002;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_doctype))
                {


                    return (data.doc_type != null && data.doc_type.ToString().ToLower().Contains(_filterString_doctype.ToLower())) ||
                           (data.doc_desc != null && data.doc_desc.ToString().ToLower().Contains(_filterString_doctype.ToLower()));


                }
                return true;
            }
            return false;
        }
        #endregion
        #region . Project .
        private string _filterString_Project;
        public string FilterString_Project
        {
            get { return _filterString_Project; }
            set
            {
                _filterString_Project = value;
                RaisePropertyChanged("FilterString_Project");
                FilterCollection_Project();
            }
        }
        private void FilterCollection_Project()
        {
            if (_ProjectCollection != null)
            {
                _ProjectCollection.Refresh();
            }
        }
        public bool Project_Filter(object obj)
        {
            var data = obj as PRO_T001_P;
            if (data != null)
            {
                if (!string.IsNullOrEmpty(_filterString_Project))
                {


                    return (data.project_id != null && data.project_id.ToString().ToLower().Contains(_filterString_Project.ToLower())) ||
                           (data.project_name != null && data.project_name.ToString().ToLower().Contains(_filterString_Project.ToLower())) ||
                           (data.PartyNm != null && data.PartyNm.ToString().ToLower().Contains(_filterString_Project.ToLower())) ||
                           (data.ref_doc_no != null && data.ref_doc_no.ToString().ToLower().Contains(_filterString_Project.ToLower()));
                }
                return true;
            }
            return false;
        }
        #endregion
        #endregion

        #region Relay Command

        public RelayCommand<object> CmdAddCustomer { get; private set; }
        public RelayCommand<object> CmdAddCustomerForGrid { get; private set; }
        public RelayCommand<object> CmdAddEmp { get; private set; }
        public RelayCommand<object> CmdAddEmployeeForGrid { get; private set; }
        public RelayCommand<object> CmdAddHead { get; private set; }
        public RelayCommand<object> CmdAddVehicle { get; private set; }
        public RelayCommand<object> CmdAddDriver { get; private set; }
        public RelayCommand<object> cmdLocation { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowItem { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowEmp { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowWork { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowTransport { get; private set; }
        public RelayCommand<object> CmdDeleteDataGridRowAdvance { get; private set; }
        public RelayCommand<object> CommandLoadDocumentByDocumentNumber { get; private set; }
        public RelayCommand<object> CommandSalseOrg { get; private set; }
        public RelayCommand<object> CommandSalseGroup { get; private set; }
        public RelayCommand<IList> dgSelectionChanged { get; private set; }
        public RelayCommand<object> cmdDocType { get; private set; }
        public RelayCommand<object> cmdInsertEmployee { get; private set; }
        public RelayCommand<object> CmdInsetProjectGrid { get; private set; }
        #endregion

        #region Construtor
        public ACC_T003_TV_VM() : base()

        {
            IsDocumentViewerShow = false;
            MasterEntity = new ACC_T003();
            ItemsEntity = new ObservableCollection<ACC_T003_A>();
            EmployeeEntity = new ObservableCollection<ACC_T003_C>();
            WorkOrderEntity = new ObservableCollection<ACC_T003_D>();
            TransporterEntity = new ObservableCollection<ACC_T003_E>();
            AdvanceEntity = new ObservableCollection<ACC_T003_F>();
            FlipGridData = new List<ACC_T003_Flip>();
            MC = new MultipleContext_ACC_T003();
            MCTemp = new MultipleContext_ACC_T003();
            MasterEntity.ValidateAsync().Wait();
            ACC_T003.ModelEntityUpdated += new EventHandler(ModelUpdated_Master);
            ACC_T003_A.ModelEntityUpdated += new EventHandler(ModelUpdated_Item);
            ACC_T003_F.ModelEntityUpdated += new EventHandler(ModelUpdated_Advance);
            ACC_T003_C.ModelEntityUpdated += new EventHandler(ModelUpdated_Employee);

            CmdAddCustomer = new RelayCommand<object>(items => { if (items == null) { return; } InsertCustomer(items); });
            CmdAddEmp = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmp(items); });
            CmdAddCustomerForGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertCustomerForGrid(cmdPara, true, true, true); });
            CmdAddEmployeeForGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertEmployeeForGrid(cmdPara, true, true, true); });
            CmdAddHead = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertHead(cmdPara, true, true, true); });
            CmdAddVehicle = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertVehicle(cmdPara, true, true, true); });
            CmdAddDriver = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertDriver(cmdPara, true, true, true); });
            CommandLoadDocumentByDocumentNumber = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } LoadDocumentByDocumentNumber(cmdPara, "FlipGridReference"); });
            CmdDeleteDataGridRowItem = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Item(cmdPara); });
            CmdDeleteDataGridRowEmp = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Emp(cmdPara); });
            CmdDeleteDataGridRowWork = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Work(cmdPara); });
            CmdDeleteDataGridRowTransport = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Transport(cmdPara); });
            CmdDeleteDataGridRowAdvance = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } DeleteDataGridRow_Advance(cmdPara); });
            // cmdLocation = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertLocation(cmdPara); });
            CommandSalseOrg = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseOrg(items); });
            CommandSalseGroup = new RelayCommand<object>(items => { if (items == null) { return; } InsertSalseGroup(items); });
            cmdDocType = new RelayCommand<object>(items => { if (items == null) { return; } InsertDocType(items); });
            cmdInsertEmployee = new RelayCommand<object>(items => { if (items == null) { return; } InsertEmployee(items); });
            CmdInsetProjectGrid = new RelayCommand<object>(cmdPara => { if (cmdPara == null) { return; } InsertProjectForGrid(cmdPara, true, true, true); });
            LoadInitialData();
            if (AppSessionState.TransValue != null && AppSessionState.TransactionCode == MC.DocTypeInfo[0].TranCode)
            {
                LoadDocumentByDocumentNumber(AppSessionState.TransValue, "DocumentNo");
                isTabChangeAllowed = AppSessionState.ViewOtherRecordAllowed;
                AppSessionState.ViewOtherRecordAllowed = true;
            }
        }
        private void LoadInitialData()
        {
            try
            {
                MasterEntity.doc_cat = "TV";
                MasterEntity.doc_type = "TV";
                string Request = "LoadInitialData" + "!@" + AppSessionState.comp_code + "!@" + AppSessionState.location_Id.ToString() + "!@" + MasterEntity.doc_cat + "!@" + MasterEntity.doc_type + "!@" + AppSessionState.EmpId + "!@" + AppSessionState.UserID;
                MC = repository_MC.GetDataWithReturnDomainObject<MultipleContext_ACC_T003>(MC, Request, "ExpensesVoucher", "Finance", " ", 0, "");

                FlipGridData = MC.DocumentDataFlipGrid.ToList();
                FlipDataGridCollection = CollectionViewSource.GetDefaultView(FlipGridData);
                FlipDataGridCollection.Filter = new Predicate<object>(Filter_FlipGrid);

                CustomerCollection = CollectionViewSource.GetDefaultView(MC.CustomerDetails);
                CustomerCollection.Filter = new Predicate<object>(Filter_Customer);
                StringListCustomer = MC.CustomerDetails.Select(x => x.PartyId.ToString()).ToList();

                EmpCollection = CollectionViewSource.GetDefaultView(MC.EmpDetails);
                EmpCollection.Filter = new Predicate<object>(Filter_Emp);
                StringListEmp = MC.EmpDetails.Select(x => x.EmpId.ToString()).ToList();

                EmployeeCollection = CollectionViewSource.GetDefaultView(MC.EmpDetails);
                EmployeeCollection.Filter = new Predicate<object>(Filter_Employee);
                StringListEmployee = MC.EmpDetails.Select(x => x.EmpId.ToString()).ToList();

                HeadCollection = CollectionViewSource.GetDefaultView(MC.HeadDetailsForGrid);
                HeadCollection.Filter = new Predicate<object>(Filter_Head);
                StringListHead = MC.HeadDetailsForGrid.Select(x => x.head_code.ToString()).ToList();

                LocationCollection = CollectionViewSource.GetDefaultView(MC.LocationMaster);
                LocationCollection.Filter = new Predicate<object>(Filter_Location);
                StringListLocation = MC.LocationMaster.Select(x => x.LoctnNm).ToList();

                VehicleCollection = CollectionViewSource.GetDefaultView(MC.VehicleDetails);
                VehicleCollection.Filter = new Predicate<object>(Filter_Vehicle);
                StringListVehicle = MC.VehicleDetails.Select(x => x.vehicle_no).ToList();

                DriverCollection = CollectionViewSource.GetDefaultView(MC.DriverDetails);
                DriverCollection.Filter = new Predicate<object>(Filter_Driver);
                strListDriver = MC.DriverDetails.Select(x => x.EmpId).ToList();

                doc_typeCollection = CollectionViewSource.GetDefaultView(MC.DocTypeInfo);
                doc_typeCollection.Filter = new Predicate<object>(doctype_Filter);

                ProjectCollection = CollectionViewSource.GetDefaultView(MC.Project);
                ProjectCollection.Filter = new Predicate<object>(Project_Filter);
                strListProject = MC.Project.Select(x => x.project_id).ToList();

                SalesOrganisationList = (List<ADM_M001_A_P>)AppSessionState.ADM_M001_A_List;
                Salse_OrgCollection = CollectionViewSource.GetDefaultView(SalesOrganisationList);
                Salse_OrgCollection.Filter = new Predicate<object>(Filter_SalesOrg);
                StringListSalesOrg = SalesOrganisationList.Select(x => x.so_code).ToList();
                if (SalesOrganisationList.Count != 0)
                {
                    if (SalesOrganisationList.Count == 1)
                    {
                        MasterEntity.so_code = SalesOrganisationList[0].so_code;
                        MasterEntity.sales_org = SalesOrganisationList[0].sales_org;
                    }
                }
                else
                {
                    MasterEntity.so_code = "";
                }
                SalesGroupList = (List<ADM_M001_H_P>)AppSessionState.ADM_M001_H_List;
                Salse_GroupCollection = CollectionViewSource.GetDefaultView(SalesGroupList);
                Salse_GroupCollection.Filter = new Predicate<object>(Filter_SalesGroup);
                StringListSalesGroup = SalesGroupList.Select(x => x.sg_code).ToList();

                if (SalesGroupList.Count != 0)
                {
                    if (SalesGroupList.Count == 1)
                    {
                        MasterEntity.sg_code = SalesGroupList[0].sg_code;
                        MasterEntity.sg_name = SalesGroupList[0].sg_name;
                    }
                }
                else
                {
                    MasterEntity.sg_code = "";
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

        #region Event Handler
        void ModelUpdated_Master(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            //this.ErrorExist = MasterEntity.HasErrors;
            if (sender.ToString() == "approved_amt" || sender.ToString() == "advance" || sender.ToString() == "active")
            {
                CalBalance();
            }
            if (sender.ToString() == "grand_total")
            {

                if (MasterEntity.grand_total > 0)
                {
                    MasterEntity.amt_in_words = num.AmountInWords(Convert.ToDecimal(MasterEntity.grand_total));
                }
                else
                {
                    MasterEntity.amt_in_words = "";
                }
            }
        }
        void ModelUpdated_Item(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            //this.ErrorExist = MasterEntity.HasErrors; 
            if (sender.ToString() == "qty" || sender.ToString() == "unit_price" || sender.ToString() == "amount" || sender.ToString() == "standard_amt" || sender.ToString() == "active")
            {
                CalSubTotal(true);
                CalGrandTotal(true);

            }
            if (sender.ToString() == "sub_total" || sender.ToString() == "active")
            {
                CalGrandTotal(true);
            }

            if (sender.ToString() == "approved_amt" || sender.ToString() == "active")
            {
                CalculateApprovedAmt(true);
            }
            this.ErrorExist = false;/*MasterEntity.HasErrors;*/
            if (ItemsEntity.Count > dgSelectedIndexItem && dgSelectedIndexItem >= 0)
            {
                this.ErrorExist = ItemsEntity[dgSelectedIndexItem].HasErrors;
            }
        }
        void ModelUpdated_Advance(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            //this.ErrorExist = MasterEntity.HasErrors;
            if (sender.ToString() == "amount" || sender.ToString() == "paid_amt" || sender.ToString() == "paid_by_amt" || sender.ToString() == "active")
            {
                CalculateAdvance(true);
            }

            this.ErrorExist = false;/*MasterEntity.HasErrors;*/
            if (AdvanceEntity.Count > dgSelectedIndexAdvance && dgSelectedIndexAdvance >= 0)
            {
                this.ErrorExist = AdvanceEntity[dgSelectedIndexAdvance].HasErrors;
            }
        }
        void ModelUpdated_Employee(object sender, EventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            //this.ErrorExist = MasterEntity.HasErrors;
            if (sender.ToString() == "no_of_day" || sender.ToString() == "day_charge" || sender.ToString() == "active")
            {
                CalNoOfDays(true);
            }
            if (sender.ToString() == "expense_amt" || sender.ToString() == "no_of_day" || sender.ToString() == "day_charge" || sender.ToString() == "active")
            {
                CalNetBalence(true);
            }
            this.ErrorExist = false;/*MasterEntity.HasErrors;*/
            if (AdvanceEntity.Count > dgSelectedIndexAdvance && dgSelectedIndexAdvance >= 0)
            {
                this.ErrorExist = AdvanceEntity[dgSelectedIndexAdvance].HasErrors;
            }
        }

        #endregion

        #region User Defined Function
        private void DefaultValues()
        {
            MasterEntity.doc_cat = "TV";
            MasterEntity.doc_type = "TV";
            MasterEntity.location_Id = AppSessionState.location_Id;
            MasterEntity.comp_code = AppSessionState.comp_code;
            MasterEntity.client = AppSessionState.client;
            MasterEntity.add_by = AppSessionState.UserID;
            MasterEntity.editby = AppSessionState.UserID;
            MasterEntity.EmpId = AppSessionState.EmpId;
            MasterEntity.EmpName = AppSessionState.EmpName;
            MasterEntity.t_status = "001";
            MasterEntity.doc_no = "";
            MasterEntity.doc_date = DateTime.Now;
            MasterEntity.active = true;

        }
        private bool Validation()
        {
            if (ItemsEntity.Count < 1)
            {

                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Message";
                showMessageService.Text = String.Format("Please Enter Atleast One Record In Expenses Detail...");
                showMessageService.ShowMessage();
                return false;
            }
            if (dgSelectedIndexWork != -1)
            {
                foreach (var o in WorkOrderEntity)
                {
                    if (o.PartyId == null || o.PartyId == "")
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Required";
                        showMessageService.Text = String.Format("Party ID Is Required", this.Title);
                        showMessageService.ShowMessage();
                        return false;
                    }
                }
            }
            if (dgSelectedIndexEmp != -1)
            {
                foreach (var o in EmployeeEntity)
                {
                    if (o.EmpName != null && o.EmpName != "")
                    {
                        if (o.int_ext == null || o.int_ext == "")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Required";
                            showMessageService.Text = String.Format("Please Select Additional Person As External In Employee Details...", this.Title);
                            showMessageService.ShowMessage();
                            return false;
                        }
                    }
                }
            }
            if (MasterEntity.location_Id == null || MasterEntity.location_Id == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Location Id Is Required", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.comp_code == null || MasterEntity.comp_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("Company Code Is Required", this.Title);
                showMessageService.ShowMessage();
                return false;
            }

            if (MasterEntity.so_code == null || MasterEntity.so_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("So Code Is Required", this.Title);
                showMessageService.ShowMessage();
                return false;
            }
            if (MasterEntity.sg_code == null || MasterEntity.sg_code == "")
            {
                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                showMessageService.ButtonSetup = DialogButton.Ok;
                showMessageService.Caption = "Required";
                showMessageService.Text = String.Format("SG Code Is Required", this.Title);
                showMessageService.ShowMessage();
                return false;
            }

            return true;
        }
        //Collection Changed Methods For Transporter
        public void EntityViewModelPropertyChangedForTransporter(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false;/*MasterEntity.HasErrors;*/
            if (TransporterEntity.Count > dgSelectedIndexTransport && dgSelectedIndexTransport >= 0)
            {
                this.ErrorExist = TransporterEntity[dgSelectedIndexTransport].HasErrors;
            }

        }
        void MyType_PropertyChangedForTransporter(object sender, PropertyChangedEventArgs e)
        {

            if (TransporterEntity.Count > dgSelectedIndexTransport && dgSelectedIndexTransport >= 0)
            {
                this.ErrorExist = false; /*dgItemsEntity[dgSelectedIndexItem].HasErrors;*/
            }
        }
        private void CollectionChangedNotifyForTransporter(object sender, NotifyCollectionChangedEventArgs e)
        {
            //////////////////////////////////Temp Test
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (ACC_T003_E item in e.NewItems)
                    item.PropertyChanged += this.MyType_PropertyChangedForTransporter;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (ACC_T003_E item in e.OldItems)
                    item.PropertyChanged -= this.MyType_PropertyChangedForTransporter;

            /////////////////////////////////Temp Test End
            //different kind of changes that may have occurred in collection
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (ACC_T003_E item in e.NewItems)
                {
                    //Added items
                    item.id = 0;
                    item.add_by = AppSessionState.UserID;
                    item.comp_code = AppSessionState.comp_code;
                    item.location_Id = AppSessionState.location_Id;
                    item.active = true;

                    item.PropertyChanged += EntityViewModelPropertyChangedForTransporter;
                }
                if (TransporterEntity.Count > dgSelectedIndexTransport && dgSelectedIndexTransport >= 0)
                {
                    this.ErrorExist = TransporterEntity[dgSelectedIndexTransport].HasErrors;
                }
            }
        }

        //Collection Changed Methods for Advance
        public void EntityViewModelPropertyChangedForAdvance(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false;/*MasterEntity.HasErrors;*/
            if (AdvanceEntity.Count > dgSelectedIndexAdvance && dgSelectedIndexAdvance >= 0)
            {
                this.ErrorExist = AdvanceEntity[dgSelectedIndexAdvance].HasErrors;
            }

        }
        void MyType_PropertyChangedForAdvance(object sender, PropertyChangedEventArgs e)
        {

            if (AdvanceEntity.Count > dgSelectedIndexAdvance && dgSelectedIndexAdvance >= 0)
            {
                this.ErrorExist = false; /*dgItemsEntity[dgSelectedIndexItem].HasErrors;*/
            }
        }
        private void CollectionChangedNotifyForAdvance(object sender, NotifyCollectionChangedEventArgs e)
        {
            //////////////////////////////////Temp Test
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (ACC_T003_F item in e.NewItems)
                    item.PropertyChanged += this.MyType_PropertyChangedForAdvance;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (ACC_T003_F item in e.OldItems)
                    item.PropertyChanged -= this.MyType_PropertyChangedForAdvance;

            /////////////////////////////////Temp Test End
            //different kind of changes that may have occurred in collection
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (ACC_T003_F item in e.NewItems)
                {
                    //Added items
                    item.id = 0;
                    item.add_by = AppSessionState.UserID;
                    item.comp_code = AppSessionState.comp_code;
                    item.location_Id = AppSessionState.location_Id;
                    item.active = true;


                    item.PropertyChanged += EntityViewModelPropertyChangedForAdvance;
                }
                if (AdvanceEntity.Count > dgSelectedIndexAdvance && dgSelectedIndexAdvance >= 0)
                {
                    this.ErrorExist = AdvanceEntity[dgSelectedIndexAdvance].HasErrors;
                }
            }
        }

        //Collection Changed Methods For Employee
        public void EntityViewModelPropertyChangedForEmployee(object sender, PropertyChangedEventArgs e)
        {
            //This will get called when the property of an object inside the collection changes
            this.ErrorExist = false;/*MasterEntity.HasErrors;*/
            if (EmployeeEntity.Count > dgSelectedIndexEmp && dgSelectedIndexEmp >= 0)
            {
                this.ErrorExist = EmployeeEntity[dgSelectedIndexEmp].HasErrors;
            }

        }
        void MyType_PropertyChangedForEmployee(object sender, PropertyChangedEventArgs e)
        {

            if (EmployeeEntity.Count > dgSelectedIndexEmp && dgSelectedIndexEmp >= 0)
            {
                this.ErrorExist = false; /*dgItemsEntity[dgSelectedIndexItem].HasErrors;*/
            }
        }
        private void CollectionChangedNotifyForEmployee(object sender, NotifyCollectionChangedEventArgs e)
        {
            //////////////////////////////////Temp Test
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (ACC_T003_C item in e.NewItems)
                    item.PropertyChanged += this.MyType_PropertyChangedForEmployee;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (ACC_T003_C item in e.OldItems)
                    item.PropertyChanged -= this.MyType_PropertyChangedForEmployee;

            /////////////////////////////////Temp Test End
            //different kind of changes that may have occurred in collection
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                foreach (ACC_T003_C item in e.NewItems)
                {
                    //Added items
                    item.id = 0;
                    item.add_by = AppSessionState.UserID;
                    item.comp_code = AppSessionState.comp_code;
                    item.location_Id = AppSessionState.location_Id;
                    item.active = true;


                    item.PropertyChanged += EntityViewModelPropertyChangedForEmployee;
                }
                if (EmployeeEntity.Count > dgSelectedIndexEmp && dgSelectedIndexEmp >= 0)
                {
                    this.ErrorExist = EmployeeEntity[dgSelectedIndexEmp].HasErrors;
                }
            }
        }
        #endregion

        #region Relay Command Implementation

        private void InsertCustomer(object InputValue)
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
                            {
                                POPUPEntityObject = MC.CustomerDetails.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
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
                    MasterEntity.PartyId = POPUPEntityObject.PartyId;
                    MasterEntity.CustomerNm = POPUPEntityObject.PartyNm;
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
        private void InsertEmp(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M024_POP POPUPEntityObject = null;
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            {
                                POPUPEntityObject = MC.EmpDetails.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0];
                            }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_POP>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.EmpId = POPUPEntityObject.EmpId;
                    MasterEntity.EmpName = POPUPEntityObject.EmpName;
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
        private void InsertHead(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ACC_T003_B_P POPUPEntityObject = null;

                //Command Parameter Read section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.HeadDetailsForGrid.Where(x => x.head_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_T003_B_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_T003_B_P>().ToList()[0];
                    }

                }

                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = ItemsEntity.Where(x => x.head_code == POPUPEntityObject.head_code).FirstOrDefault();
                    var IndexOfExistValue = ItemsEntity.IndexOf(ItemsEntity.Where(X => X.head_code == POPUPEntityObject.head_code).FirstOrDefault());

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && ItemsEntity.Count == dgSelectedIndexItem)
                    {
                        ItemsEntity.Add(new ACC_T003_A()
                        {
                            id = 0,
                            active = true,
                            head_code = POPUPEntityObject.head_code,
                            description = POPUPEntityObject.description,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            t_status = "001",
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID
                        });
                    }
                    else if (dgSelectedIndexItem >= 0 && ItemsEntity.Count > dgSelectedIndexItem)
                    {
                        if (ItemsEntity[dgSelectedIndexItem].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            ItemsEntity[dgSelectedIndexItem].head_code = POPUPEntityObject.head_code;
                            ItemsEntity[dgSelectedIndexItem].description = POPUPEntityObject.description;

                        }
                        else if (ItemsEntity[dgSelectedIndexItem].head_code != POPUPEntityObject.head_code)
                        {
                            ItemsEntity[dgSelectedIndexItem].head_code = POPUPEntityObject.head_code;
                            ItemsEntity[dgSelectedIndexItem].description = POPUPEntityObject.description;
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
        private void InsertCustomerForGrid(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M028_P POPUPEntityObject = null;

                //Command Parameter Read section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.CustomerDetails.Where(x => x.PartyId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M028_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M028_P>().ToList()[0];
                    }

                }

                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = WorkOrderEntity.Where(x => x.PartyId == POPUPEntityObject.PartyId).FirstOrDefault();
                    var IndexOfExistValue = WorkOrderEntity.IndexOf(WorkOrderEntity.Where(X => X.PartyId == POPUPEntityObject.PartyId).FirstOrDefault());

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && WorkOrderEntity.Count == dgSelectedIndexWork)
                    {
                        WorkOrderEntity.Add(new ACC_T003_D()
                        {
                            id = 0,
                            active = true,
                            PartyId = POPUPEntityObject.PartyId,
                            PartyNm = POPUPEntityObject.PartyNm,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            t_status = "001",
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID
                        });
                    }
                    else if (dgSelectedIndexWork >= 0 && WorkOrderEntity.Count > dgSelectedIndexWork)
                    {
                        if (WorkOrderEntity[dgSelectedIndexWork].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            WorkOrderEntity[dgSelectedIndexWork].PartyId = POPUPEntityObject.PartyId;
                            WorkOrderEntity[dgSelectedIndexWork].PartyNm = POPUPEntityObject.PartyNm;
                            WorkOrderEntity[dgSelectedIndexWork].active = true;

                        }
                        else if (WorkOrderEntity[dgSelectedIndexWork].PartyId != POPUPEntityObject.PartyId)
                        {
                            WorkOrderEntity[dgSelectedIndexWork].PartyId = POPUPEntityObject.PartyId;
                            WorkOrderEntity[dgSelectedIndexWork].PartyNm = POPUPEntityObject.PartyNm;
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
        private void InsertEmployeeForGrid(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M024_POP POPUPEntityObject = null;

                //Command Parameter Read section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.EmpDetails.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M024_POP>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_POP>().ToList()[0];
                    }

                }

                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = EmployeeEntity.Where(x => x.EmpId == POPUPEntityObject.EmpId).FirstOrDefault();
                    var IndexOfExistValue = EmployeeEntity.IndexOf(EmployeeEntity.Where(X => X.EmpId == POPUPEntityObject.EmpId).FirstOrDefault());

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && EmployeeEntity.Count == dgSelectedIndexEmp)
                    {
                        EmployeeEntity.Add(new ACC_T003_C()
                        {
                            id = 0,
                            active = true,
                            EmpId = POPUPEntityObject.EmpId,
                            EmpName = POPUPEntityObject.EmpName,
                            int_ext = "Internal",
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            t_status = "001",
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID
                        });
                    }
                    else if (dgSelectedIndexEmp >= 0 && EmployeeEntity.Count > dgSelectedIndexEmp)
                    {
                        if (EmployeeEntity[dgSelectedIndexEmp].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            EmployeeEntity[dgSelectedIndexEmp].EmpId = POPUPEntityObject.EmpId;
                            EmployeeEntity[dgSelectedIndexEmp].EmpName = POPUPEntityObject.EmpName;
                            EmployeeEntity[_dgSelectedIndexEmp].int_ext = "Internal";
                            EmployeeEntity[dgSelectedIndexEmp].active = true;

                        }
                        else if (EmployeeEntity[dgSelectedIndexEmp].EmpId != POPUPEntityObject.EmpId)
                        {
                            EmployeeEntity[dgSelectedIndexEmp].EmpId = POPUPEntityObject.EmpId;
                            EmployeeEntity[dgSelectedIndexEmp].EmpName = POPUPEntityObject.EmpName;
                            EmployeeEntity[_dgSelectedIndexEmp].int_ext = "Internal";
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
        private void InsertSalseOrg(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M001_A_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SalesOrg.Where(x => x.so_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_A_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.so_code = POPUPEntityObject.so_code;
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
        private void InsertSalseGroup(object InputValue)
        {
            try
            {
                string Request = "";
                ADM_M001_H_P POPUPEntityObject = null;
                #region Command Parameter Read Section
                try
                {
                    if (InputValue.GetType() == typeof(string) && InputValue != null)
                    {
                        Request = InputValue.ToString();
                        if (Request.Length > 0)
                        {
                            try
                            { POPUPEntityObject = MC.SalesGroup.Where(x => x.sg_code.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M001_H_P>().ToList()[0];
                    }
                }
                catch (Exception ex) { }

                #endregion
                if (POPUPEntityObject != null)
                {
                    MasterEntity.sg_code = POPUPEntityObject.sg_code;
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
        private void InsertVehicle(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ACC_T003_H_POPUP POPUPEntityObject = null;

                //Command Parameter Read section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.VehicleDetails.Where(x => x.vehicle_no.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ACC_T003_H_POPUP>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ACC_T003_H_POPUP>().ToList()[0];
                    }

                }

                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = TransporterEntity.Where(x => x.vehicle_no == POPUPEntityObject.vehicle_no).FirstOrDefault();
                    var IndexOfExistValue = TransporterEntity.IndexOf(TransporterEntity.Where(X => X.vehicle_no == POPUPEntityObject.vehicle_no).FirstOrDefault());

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && TransporterEntity.Count == dgSelectedIndexTransport)
                    {
                        TransporterEntity.Add(new ACC_T003_E()
                        {
                            id = 0,
                            active = true,
                            vehicle_id = POPUPEntityObject.vehicle_id,
                            vehicle_no = POPUPEntityObject.vehicle_no,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            t_status = "001",
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID
                        });
                    }
                    else if (dgSelectedIndexTransport >= 0 && TransporterEntity.Count > dgSelectedIndexTransport)
                    {
                        if (TransporterEntity[dgSelectedIndexTransport].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            TransporterEntity[dgSelectedIndexTransport].vehicle_id = POPUPEntityObject.vehicle_id;
                            TransporterEntity[dgSelectedIndexTransport].vehicle_no = POPUPEntityObject.vehicle_no;
                            TransporterEntity[dgSelectedIndexTransport].active = true;

                        }
                        else if (TransporterEntity[dgSelectedIndexTransport].vehicle_id != POPUPEntityObject.vehicle_id)
                        {
                            TransporterEntity[dgSelectedIndexTransport].vehicle_id = POPUPEntityObject.vehicle_id;
                            TransporterEntity[dgSelectedIndexTransport].vehicle_no = POPUPEntityObject.vehicle_no;

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
        private void InsertDriver(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                ADM_M024_POP POPUPEntityObject = null;

                //Command Parameter Read section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.DriverDetails.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<ADM_M024_POP>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_POP>().ToList()[0];
                    }

                }

                if (POPUPEntityObject != null)
                {
                    var InputValueIfExists = TransporterEntity.Where(x => x.driver_id == POPUPEntityObject.EmpId).FirstOrDefault();
                    var IndexOfExistValue = TransporterEntity.IndexOf(TransporterEntity.Where(X => X.driver_id == POPUPEntityObject.EmpId).FirstOrDefault());

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && TransporterEntity.Count == dgSelectedIndexTransport)
                    {
                        TransporterEntity.Add(new ACC_T003_E()
                        {
                            id = 0,
                            active = true,
                            driver_id = POPUPEntityObject.EmpId,
                            transporter = POPUPEntityObject.EmpName,
                            location_Id = AppSessionState.location_Id,
                            comp_code = AppSessionState.comp_code,
                            t_status = "001",
                            add_by = AppSessionState.UserID,
                            editby = AppSessionState.UserID
                        });
                    }
                    else if (dgSelectedIndexTransport >= 0 && TransporterEntity.Count > dgSelectedIndexTransport)
                    {
                        if (TransporterEntity[dgSelectedIndexTransport].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            TransporterEntity[dgSelectedIndexTransport].driver_id = POPUPEntityObject.EmpId;
                            TransporterEntity[dgSelectedIndexTransport].transporter = POPUPEntityObject.EmpName;
                            TransporterEntity[dgSelectedIndexTransport].active = true;

                        }
                        else if (TransporterEntity[dgSelectedIndexTransport].driver_id != POPUPEntityObject.EmpId)
                        {
                            TransporterEntity[dgSelectedIndexTransport].driver_id = POPUPEntityObject.EmpId;
                            TransporterEntity[dgSelectedIndexTransport].transporter = POPUPEntityObject.EmpName;

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
        private void LoadDocumentByDocumentNumber(object ParameterObject, string ParameterReference)
        {
            try
            {
                string Request = "";
                ACC_T003_Flip ParameterEntityObject = null;
                MasterEntity = new ACC_T003();
                ItemsEntity = new ObservableCollection<ACC_T003_A>();
                EmployeeEntity = new ObservableCollection<ACC_T003_C>();
                WorkOrderEntity = new ObservableCollection<ACC_T003_D>();
                TransporterEntity = new ObservableCollection<ACC_T003_E>();
                AdvanceEntity = new ObservableCollection<ACC_T003_F>();

                if (ParameterObject.GetType() == typeof(string) && ParameterObject != null) // This Block of code read parameter . First for string and Entity Object in else part.
                {
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterObject;
                    SelectedTabControlIndex = 0;
                    isNewRecord = false;

                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ACC_T003>(MCTemp, Request, "ExpensesVoucher", "Finance", "LoadDocumentByDocumentNumber", 0, "");
                    if (MCTemp.MasterEntity.Count > 0)
                    {
                        MasterEntity = MCTemp.MasterEntity[0];
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("This Record Is Inactive...");
                        showMessageService.ShowMessage();
                    }
                    ItemsEntity = MCTemp.ItemsEntity;
                    EmployeeEntity = MCTemp.Employee;
                    WorkOrderEntity = MCTemp.WorkOrder;
                    TransporterEntity = MCTemp.Transport;
                    AdvanceEntity = MCTemp.Advance;

                    if (MCTemp.Attachment != null)
                    {
                        AttachmentCollection = MCTemp.Attachment;
                    }
                    else
                    {
                        MCTemp.Attachment = new List<COM_T003>();
                    }

                    CalGrandTotal(true);

                    CalculateAdvance(true);

                    if (dgSelectedIndexItem != -1)
                    {
                        if (MasterEntity.grand_total > 0)
                        {
                            MasterEntity.amt_in_words = num.AmountInWords(Convert.ToDecimal(MasterEntity.grand_total));
                        }
                    }
                    else
                    {
                        MasterEntity.amt_in_words = "";
                    }
                }
                else if (((IEnumerable)ParameterObject).Cast<ACC_T003_Flip>().ToList().Count > 0)
                {
                    ParameterEntityObject = ((IEnumerable)ParameterObject).Cast<ACC_T003_Flip>().ToList()[0];
                    Request = "LoadDocumentByDocumentNumber" + "!@" + ParameterEntityObject.doc_no;
                    SelectedTabControlIndex = 0;
                    isNewRecord = false;

                    MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ACC_T003>(MCTemp, Request, "ExpensesVoucher", "Finance", "LoadDocumentByDocumentNumber", 0, "");
                    if (MCTemp.MasterEntity.Count > 0)
                    {
                        MasterEntity = MCTemp.MasterEntity[0];
                    }
                    else
                    {
                        IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                        showMessageService.ButtonSetup = DialogButton.Ok;
                        showMessageService.Caption = "Message";
                        showMessageService.Text = String.Format("This Record Is Inactive...");
                        showMessageService.ShowMessage();
                    }
                    ItemsEntity = MCTemp.ItemsEntity;
                    EmployeeEntity = MCTemp.Employee;
                    WorkOrderEntity = MCTemp.WorkOrder;
                    TransporterEntity = MCTemp.Transport;
                    AdvanceEntity = MCTemp.Advance;
                    MC.ApprovalData = MCTemp.ApprovalData;
                    ApprovalData = MCTemp.ApprovalData;
                    if (MCTemp.Attachment != null)
                    {
                        AttachmentCollection = MCTemp.Attachment;
                    }
                    else
                    {
                        MCTemp.Attachment = new List<COM_T003>();
                    }

                    CalGrandTotal(true);

                    CalculateAdvance(true);

                    if (dgSelectedIndexItem != -1)
                    {
                        if (MasterEntity.grand_total > 0)
                        {
                            MasterEntity.amt_in_words = num.AmountInWords(Convert.ToDecimal(MasterEntity.grand_total));
                        }
                    }
                    else
                    {
                        MasterEntity.amt_in_words = "";
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
        private void DeleteDataGridRow_Item(object InputValue)
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
        private void DeleteDataGridRow_Emp(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (EmployeeEntity.Count > i && EmployeeEntity[dgSelectedIndexEmp].id == 0)
                {
                    EmployeeEntity.RemoveAt(i);
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
        private void DeleteDataGridRow_Work(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (WorkOrderEntity.Count > i && WorkOrderEntity[dgSelectedIndexWork].id == 0)
                {
                    WorkOrderEntity.RemoveAt(i);
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
        private void DeleteDataGridRow_Transport(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (TransporterEntity.Count > i && TransporterEntity[dgSelectedIndexTransport].id == 0)
                {
                    TransporterEntity.RemoveAt(i);
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
        private void DeleteDataGridRow_Advance(object InputValue)
        {
            try
            {
                int i = (int)InputValue;
                if (AdvanceEntity.Count > i && AdvanceEntity[dgSelectedIndexAdvance].id == 0)
                {
                    AdvanceEntity.RemoveAt(i);
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

        //private void InsertLocation(object InputValue)
        //{
        //    try
        //    {
        //        string Request = "";
        //        ADM_M003_P POPUPEntityObject = null;

        //        #region Command Parameter Read Section
        //        // This Block of code read parameter and load Entity with Data from Collection to insert/edit into the Row.
        //        if (InputValue.GetType() == typeof(string) && InputValue != null)
        //        {
        //            //Request = InputValue.ToString().Trim(); // for w/o or ignore space as and if required
        //            Request = InputValue.ToString();
        //            if (Request.Length > 0)
        //            {
        //                try
        //                { POPUPEntityObject = MC.LocationMaster.Where(x => x.LoctnNm.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
        //                catch (Exception ex) { }
        //            }
        //        }
        //        else if (InputValue != null)
        //        {
        //            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M003_P>().ToList()[0];
        //        }

        //        #endregion

        //        if (POPUPEntityObject != null) // Only enter in the code block if ENtity Not null.
        //        {
        //            MasterEntity.location_Id = POPUPEntityObject.location_Id;
        //            MasterEntity.location = POPUPEntityObject.LoctnNm;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //    }

        //}
        private void InsertDocType(object InputValue)
        {
            try
            {
                string Request = "";
                SYS_M002 POPUPEntityObject = null;
                IEnumerable<SYS_M002> BEType = new List<SYS_M002>();

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
                            { POPUPEntityObject = MC.DocTypeInfo.Where(x => x.doc_type.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        if (((IEnumerable)InputValue).Cast<SYS_M002>().Count() > 0)
                        {
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<SYS_M002>().ToList()[0];
                        }
                    }
                }
                catch (Exception ex) { }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.doc_type = POPUPEntityObject.doc_type;
                    MasterEntity.doc_desc = POPUPEntityObject.doc_desc;
                    MasterEntity.doc_cat = POPUPEntityObject.doc_cat;
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
                ADM_M024_POP POPUPEntityObject = null;
                IEnumerable<ADM_M024_POP> BEType = new List<ADM_M024_POP>();

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
                            { POPUPEntityObject = MC.EmpDetails.Where(x => x.EmpId.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                            catch (Exception ex) { }
                        }
                    }
                    else if (InputValue != null)
                    {
                        if (((IEnumerable)InputValue).Cast<ADM_M024_POP>().Count() > 0)
                        {   
                            POPUPEntityObject = ((IEnumerable)InputValue).Cast<ADM_M024_POP>().ToList()[0];
                        }
                    }
                }
                catch (Exception ex) { }
                if (POPUPEntityObject != null)
                {
                    MasterEntity.EmpId = POPUPEntityObject.EmpId;
                    MasterEntity.EmpName = POPUPEntityObject.EmpName;
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
        private void InsertProjectForGrid(object InputValue, bool NewRow, bool AllowDuplicate, bool AllowModify)
        {
            try
            {
                string Request = "";
                PRO_T001_P POPUPEntityObject = null;

                //Command Parameter Read section

                if (InputValue.GetType() == typeof(string) && InputValue != null)
                {
                    Request = InputValue.ToString();
                    if (Request.Length > 0)
                    {
                        try
                        { POPUPEntityObject = MC.Project.Where(x => x.project_id.Equals(Request, StringComparison.OrdinalIgnoreCase) == true).ToList()[0]; }
                        catch (Exception ex) { }
                    }
                }
                else if (InputValue != null)
                {
                    if (((IEnumerable)InputValue).Cast<PRO_T001_P>().Count() > 0)
                    {
                        POPUPEntityObject = ((IEnumerable)InputValue).Cast<PRO_T001_P>().ToList()[0];
                    }

                }

                if (POPUPEntityObject != null)
                {
                    MasterEntity.gl_code = POPUPEntityObject.project_id;
                    var InputValueIfExists = WorkOrderEntity.Where(x => x.project_id == POPUPEntityObject.project_id).FirstOrDefault();
                    var IndexOfExistValue = WorkOrderEntity.IndexOf(WorkOrderEntity.Where(X => X.project_id == POPUPEntityObject.project_id).FirstOrDefault());

                    if (NewRow == true && (AllowDuplicate == true || IndexOfExistValue == -1) && WorkOrderEntity.Count == dgSelectedIndexWork)
                    {
                        WorkOrderEntity.Add(new ACC_T003_D()
                        {

                            project_id = POPUPEntityObject.project_id,
                            work_order_no = POPUPEntityObject.ref_doc_no,
                        });
                    }
                    else if (dgSelectedIndexWork >= 0 && WorkOrderEntity.Count > dgSelectedIndexWork)
                    {
                        if (WorkOrderEntity[dgSelectedIndexWork].id == 0 && ((IndexOfExistValue == -1) || (IndexOfExistValue != -1 && AllowDuplicate == true))) // It will allowe to add unique value or Duplicate value if AllowDuplicate Status == True, id=0 indicates it will add or edit for New record only.
                        {
                            WorkOrderEntity[dgSelectedIndexWork].project_id = POPUPEntityObject.project_id;
                            WorkOrderEntity[dgSelectedIndexWork].work_order_no = POPUPEntityObject.ref_doc_no;

                        }
                        else if (WorkOrderEntity[dgSelectedIndexWork].project_id != POPUPEntityObject.project_id)
                        {
                            WorkOrderEntity[dgSelectedIndexWork].project_id = POPUPEntityObject.project_id;
                            WorkOrderEntity[dgSelectedIndexWork].work_order_no = POPUPEntityObject.ref_doc_no;
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
        #endregion

        #region Abstract Methods
        protected override void OnCreateAction(InquiryActionResult<ACC_T003> result)
        {
            try
            {
                isNewRecord = true;
                MasterEntity = new ACC_T003();
                MasterEntity.ValidateAsync().Wait();
                ItemsEntity = new ObservableCollection<ACC_T003_A>();
                EmployeeEntity = new ObservableCollection<ACC_T003_C>();
                WorkOrderEntity = new ObservableCollection<ACC_T003_D>();
                TransporterEntity = new ObservableCollection<ACC_T003_E>();
                AdvanceEntity = new ObservableCollection<ACC_T003_F>();

                FlipDataGridCollection.Refresh();
                if (SalesOrganisationList.Count != 0)
                {
                    if (SalesOrganisationList.Count == 1)
                    {
                        MasterEntity.so_code = SalesOrganisationList[0].so_code;
                        MasterEntity.sales_org = SalesOrganisationList[0].sales_org;
                    }
                }
                else
                {
                    MasterEntity.so_code = "";
                }
                if (SalesGroupList.Count != 0)
                {
                    if (SalesGroupList.Count == 1)
                    {
                        MasterEntity.sg_code = SalesGroupList[0].sg_code;
                        MasterEntity.sg_name = SalesGroupList[0].sg_name;
                    }
                }
                else
                {
                    MasterEntity.sg_code = "";
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

        protected override void OnDiscardAction(InquiryActionResult<ACC_T003> result)
        {

        }

        protected override void OnFevoriteAction(InquiryActionResult<ACC_T003> result)
        {
            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
            this.ShowZoomWindow = !ShowZoomWindow;
            //try
            //{
            //    if (!string.IsNullOrEmpty(MasterEntity.doc_no))
            //    {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
            //        Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MCTemp.Attachment });
            //    }
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

        protected override void OnFlipAction(InquiryActionResult<ACC_T003> result)
        {

        }

        protected override void OnHelpAction(InquiryActionResult<ACC_T003> result)
        {

        }

        protected override void OnPrintAction(InquiryActionResult<ACC_T003> result)
        {
            try
            {
                //string Request = "LoadDocumentByDocumentNumber" + "!@" + MasterEntity.doc_no;

                //MCTemp = repository_MCTemp.GetDataWithReturnDomainObject<MultipleContext_ACC_T003>(MCTemp, Request, "ExpensesVoucher", "Finance", "LoadDocumentByDocumentNumber", 0, "");
                object[] objDataSource = new object[8];
                string[] objDataSourceName = new string[8];

                objDataSource[2] = MCTemp.MasterEntity;
                objDataSource[3] = MCTemp.ItemsEntity;
                objDataSource[4] = MCTemp.Employee;
                objDataSource[5] = MCTemp.WorkOrder;
                objDataSource[6] = MCTemp.Transport;
                objDataSource[7] = MCTemp.Advance;


                List<ADM_M002> TempCmpList = (List<ADM_M002>)AppSessionState.ADM_M002_List;
                var CmpResult = TempCmpList.Where(Cmp => Cmp.comp_code == MasterEntity.comp_code).ToList();
                objDataSource[0] = CmpResult;

                List<ADM_M003> TempList = (List<ADM_M003>)AppSessionState.ADM_M003_List;
                var Result = TempList.Where(loc => loc.location_Id == MasterEntity.location_Id).ToList();
                objDataSource[1] = Result;

                objDataSourceName[0] = "dsCompany";
                objDataSourceName[1] = "dsLocation";
                objDataSourceName[2] = "dsTourMaster";
                objDataSourceName[3] = "dsTourExpense";
                objDataSourceName[4] = "dsTourEmployee";
                objDataSourceName[5] = "dsTourWork";
                objDataSourceName[6] = "dsTourTransport";
                objDataSourceName[7] = "dsTourAdvance";

                ReportManager ReportManager = new ReportManager();
                ReportManager.DisplayReport(objDataSource, objDataSourceName, "\\Finance\\TourVoucher.rdlc", "TourVoucher");

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

        protected override void OnRemoveAction(InquiryActionResult<ACC_T003> result)
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
                    string response = repository.Delete(MasterEntity.doc_no, "ExpensesVoucher", "Finance");


                    MasterEntity = new ACC_T003();
                    ItemsEntity = new ObservableCollection<ACC_T003_A>();
                    EmployeeEntity = new ObservableCollection<ACC_T003_C>();
                    WorkOrderEntity = new ObservableCollection<ACC_T003_D>();
                    TransporterEntity = new ObservableCollection<ACC_T003_E>();
                    AdvanceEntity = new ObservableCollection<ACC_T003_F>();

                    isNewRecord = true;

                    FlipDataGridCollection.Refresh();
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
        protected override void OnSaveAction(InquiryActionResult<ACC_T003> result)
        {
            try
            {
                if (Validation() == true)
                {
                    MasterEntity.XmlDataDocument_ACC_T003_A = obj.ObjectToXML(ItemsEntity);
                    MasterEntity.XmlDataDocument_ACC_T003_C = obj.ObjectToXML(EmployeeEntity);
                    MasterEntity.XmlDataDocument_ACC_T003_D = obj.ObjectToXML(WorkOrderEntity);
                    MasterEntity.XmlDataDocument_ACC_T003_E = obj.ObjectToXML(TransporterEntity);
                    MasterEntity.XmlDataDocument_ACC_T003_F = obj.ObjectToXML(AdvanceEntity);

                    this.MasterEntity.EndEdit();
                    if (isNewRecord == true)
                    {
                        MasterEntity = repository.SaveWithReturnDomainObject<ACC_T003>(MasterEntity, "ExpensesVoucher", "Finance");

                        if (MasterEntity.doc_no != null || MasterEntity.doc_no != " ")
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
                        if (MasterEntity.t_status == "002" || MasterEntity.t_status == "007")
                        {
                            IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                            showMessageService.ButtonSetup = DialogButton.Ok;
                            showMessageService.Caption = "Message";
                            showMessageService.Text = String.Format("You Can Not Edit..Once The Status Is Approved... ");
                            showMessageService.ShowMessage();
                        }
                        else
                        {

                            MasterEntity = repository.UpdateWithReturnDomainObject<ACC_T003>(MasterEntity, "ExpensesVoucher", "Finance");

                            if (MasterEntity.doc_no != null || MasterEntity.doc_no != " ")
                            {
                                IShowMessageViewService showMessageService = this.GetViewService<IShowMessageViewService>();
                                showMessageService.ButtonSetup = DialogButton.Ok;
                                showMessageService.Caption = "Message";
                                showMessageService.Text = String.Format("Data Updated Successfully");
                                showMessageService.ShowMessage();
                            }
                        }
                    }

                    SetBusinessEntitiesAfterLoad("Save", "");

                    if (MasterEntity.grand_total > 0)
                    {
                        MasterEntity.amt_in_words = num.AmountInWords(Convert.ToDecimal(MasterEntity.grand_total));
                    }
                    else
                    {
                        MasterEntity.amt_in_words = "";
                    }

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
                if (!string.IsNullOrEmpty(MasterEntity.doc_no))
                {            //this.IsDocumentViewerShow = !IsDocumentViewerShow;
                    Messenger.Default.Send<DocumentViewerPayload>(new DocumentViewerPayload() { DocumentNumber = MasterEntity.doc_no.Replace("/", "--"), DocumentList = MCTemp.Attachment, client = AppSessionState.client, comp_code = (MasterEntity.comp_code ?? AppSessionState.comp_code) });
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
        protected override void OnRefreshCommand(InquiryActionResult<ACC_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnLedgerViewCommand(InquiryActionResult<ACC_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnValidateCommand(InquiryActionResult<ACC_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnTraceCommand(InquiryActionResult<ACC_T003> result)
        {
            throw new NotImplementedException();
        }

        protected override void OnMailCommand(InquiryActionResult<ACC_T003> result)
        {
            throw new NotImplementedException();
        }
        private void SetBusinessEntitiesAfterLoad(string ParameterOption1, string ParameterOption2)
        {
            try
            {
                if (MasterEntity.XmlDataDocument_FlipGrid != null && isNewRecord == true && ParameterOption1 == "Save")
                {
                    MC.DocumentDataFlipGrid = (List<ACC_T003_Flip>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_FlipGrid, MC.DocumentDataFlipGrid);
                    FlipGridData.Add(MC.DocumentDataFlipGrid[0]);
                    FlipDataGridCollection.Refresh();
                    FlipDataGridCollection.SortDescriptions.Add(new SortDescription("doc_no", ListSortDirection.Descending));
                }
                if (MasterEntity.XmlDataDocument_ACC_T003_A != null)
                {
                    ItemsEntity.Clear();
                    ItemsEntity = (ObservableCollection<ACC_T003_A>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_T003_A, MC.ItemsEntity);

                }
                else
                {
                    MC.ItemsEntity = new ObservableCollection<ACC_T003_A>();
                }
                if (MasterEntity.XmlDataDocument_ACC_T003_C != null)
                {
                    EmployeeEntity.Clear();
                    EmployeeEntity = (ObservableCollection<ACC_T003_C>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_T003_C, MC.Employee);

                }
                else
                {
                    MC.Employee = new ObservableCollection<ACC_T003_C>();
                }
                if (MasterEntity.XmlDataDocument_ACC_T003_D != null)
                {
                    WorkOrderEntity.Clear();
                    WorkOrderEntity = (ObservableCollection<ACC_T003_D>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_T003_D, MC.WorkOrder);

                }
                else
                {
                    MC.WorkOrder = new ObservableCollection<ACC_T003_D>();
                }
                if (MasterEntity.XmlDataDocument_ACC_T003_E != null)
                {
                    TransporterEntity.Clear();
                    TransporterEntity = (ObservableCollection<ACC_T003_E>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_T003_E, MC.Transport);

                }
                else
                {
                    MC.Transport = new ObservableCollection<ACC_T003_E>();
                }
                if (MasterEntity.XmlDataDocument_ACC_T003_F != null)
                {
                    AdvanceEntity.Clear();
                    AdvanceEntity = (ObservableCollection<ACC_T003_F>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_ACC_T003_F, MC.Advance);

                }
                else
                {
                    MC.Advance = new ObservableCollection<ACC_T003_F>();
                }
                if (MasterEntity.XmlDataDocument_Approval != null)
                {
                    MC.ApprovalData.Clear();
                    MC.ApprovalData = (List<Approval>)new ObjectSerializationService().XMLToObject(MasterEntity.XmlDataDocument_Approval, MC.ApprovalData);

                }
                else
                {
                    MC.ApprovalData = new List<Approval>();
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
        //Calculation For Master
        private void CalBalance()
        {
            try
            {
                //MasterEntity.approved_amt = MasterEntity.grand_total;
                if (MasterEntity.approved_amt != null && MasterEntity.approved_amt != 0)
                {
                    if (MasterEntity.advance != null && MasterEntity.advance != 0 || MasterEntity.advance == 0)
                    {
                        MasterEntity.bal_amount = Convert.ToDecimal(MasterEntity.advance) - Convert.ToDecimal(MasterEntity.approved_amt);
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
        //Calculation For Expense Detail 
        private void CalSubTotal(bool compute)
        {
            try
            {
                if (compute == true)
                {
                    if (ItemsEntity.Count > 0 && ItemsEntity.Count > dgSelectedIndexItem && ItemsEntity.Count > dgSelectedIndexItem)
                    {
                        ItemsEntity[dgSelectedIndexItem].sub_total = (Convert.ToDecimal(ItemsEntity[dgSelectedIndexItem].qty) * Convert.ToDecimal(ItemsEntity[dgSelectedIndexItem].unit_price)) + Convert.ToDecimal(ItemsEntity[dgSelectedIndexItem].amount) + Convert.ToDecimal(ItemsEntity[dgSelectedIndexItem].standard_amt);
                        ItemsEntity[dgSelectedIndexItem].approved_amt = ItemsEntity[dgSelectedIndexItem].sub_total;

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
        private void CalGrandTotal(bool compute)
        {
            try
            {
                if (compute == true)
                {

                    if (dgSelectedIndexItem != -1)
                    {
                        if (ItemsEntity.Count > 0 && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < ItemsEntity.Count && ItemsEntity.Count > dgSelectedIndexItem)
                        {
                            MasterEntity.grand_total = 0;
                            for (int i = 0; i < ItemsEntity.Count; i++)
                            {
                                if (ItemsEntity[i].active == true)
                                {
                                    MasterEntity.grand_total = MasterEntity.grand_total + Convert.ToDecimal(ItemsEntity[i].sub_total);
                                }

                            }
                            MasterEntity.approved_amt = MasterEntity.grand_total;
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

        //Calculation For Advance Detail
        private void CalculateAdvance(bool compute)
        {
            try
            {
                if (compute == true)
                {

                    if (dgSelectedIndexAdvance != -1)
                    {
                        if (AdvanceEntity.Count > 0 && dgSelectedIndexAdvance >= 0 && dgSelectedIndexAdvance < AdvanceEntity.Count && ItemsEntity.Count > dgSelectedIndexItem)
                        {
                            MasterEntity.advance = 0;
                            for (int i = 0; i < AdvanceEntity.Count; i++)
                            {
                                if (AdvanceEntity[i].active == true)
                                {
                                    MasterEntity.advance = MasterEntity.advance + Convert.ToDecimal(AdvanceEntity[i].amount) + Convert.ToDecimal(AdvanceEntity[i].paid_amt) + Convert.ToDecimal(AdvanceEntity[i].paid_by_amt);
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
        private void CalculateApprovedAmt(bool compute)
        {
            try
            {
                if (compute == true)
                {

                    if (dgSelectedIndexItem != -1)
                    {
                        if (ItemsEntity.Count > 0 && dgSelectedIndexItem >= 0 && dgSelectedIndexItem < ItemsEntity.Count && ItemsEntity.Count > dgSelectedIndexItem)
                        {
                            MasterEntity.approved_amt = 0;

                            for (int i = 0; i < ItemsEntity.Count; i++)
                            {
                                if (ItemsEntity[i].active == true)
                                {
                                    MasterEntity.approved_amt = MasterEntity.approved_amt + Convert.ToDecimal(ItemsEntity[i].approved_amt);
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
        private void CalNoOfDays(bool compute)
        {
            try
            {
                if (compute == true)
                {
                    if (dgSelectedIndexEmp != -1)
                    {
                        if (EmployeeEntity.Count > 0 && EmployeeEntity.Count > dgSelectedIndexEmp)
                        {
                            EmployeeEntity[dgSelectedIndexEmp].total_amt = Convert.ToDecimal(EmployeeEntity[dgSelectedIndexEmp].no_of_day) * Convert.ToDecimal(EmployeeEntity[dgSelectedIndexEmp].day_charge);
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
        private void CalNetBalence(bool compute)
        {
            try
            {
                if (compute == true)
                {
                    if (dgSelectedIndexEmp != -1)
                    {
                        if (EmployeeEntity.Count > 0 && EmployeeEntity.Count > dgSelectedIndexEmp)
                        {
                            EmployeeEntity[dgSelectedIndexEmp].net_balance = Convert.ToDecimal(EmployeeEntity[dgSelectedIndexEmp].total_amt) - Convert.ToDecimal(EmployeeEntity[dgSelectedIndexEmp].expense_amt);

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


        #endregion

    }
}